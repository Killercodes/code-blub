using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

using Microsoft.Xrm.Sdk;
using System.Net;
using Microsoft.Xrm.Client.Services;
using System.Configuration;
using Microsoft.Xrm.Sdk.Messages;
using System.ServiceModel;
using System.Diagnostics;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Tools;
using System.Xml;


namespace CRM2011Plugin
{
    public class CreateCRMandADusers : IPlugin
    {
        //private static string adusername = null, adpassword = null, addomain = null, securityrole = null, adrootpath = null, createuser_domain = null;


        /*Pass these values to the unsecure config while registering step
         * 
  <Settings>
        <setting name="adusername">
            <value>administrator</value>
        </setting>
        
        <setting name="adpassword">
            <value>abc_123</value>
        </setting>

        <setting name="addomain">
            <value>MyDomain</value>
        </setting>

        <setting name="securityrole">
            <value>77987FB1-942F-E111-9689-000C295BE9F1</value>
        </setting>

        <setting name="adrootpath">
            <value>LDAP://WIN-?/CN=Users,DC=?,DC=com</value>
        </setting>

       <setting name="createuser_domain">
            <value>DOMAIN\\</value>
        </setting>
  </Settings>



        **/




        private static string adusername = null; 
       private static string adpassword  = null; 
       private static string addomain = null;
       private static string securityrole = null;
        private static string adrootpath = null;
        private static string createuser_domain = null;
                         

        public CreateCRMandADusers(string unsecureConfig, string secureConfig)
       {
           XmlDocument doc = new XmlDocument();
           doc.LoadXml(unsecureConfig);

           adusername = GetValueNode(doc, "adusername");
           adpassword = GetValueNode(doc, "adpassword");
           addomain = GetValueNode(doc, "addomain");
           securityrole = GetValueNode(doc, "securityrole");
           adrootpath = GetValueNode(doc, "adrootpath");
           createuser_domain = GetValueNode(doc, "createuser_domain");
        }

        private static string GetValueNode(XmlDocument doc, string key)
        {
            XmlNode node = doc.SelectSingleNode(String.Format("Settings/setting[@name='{0}']", key));

            if (node != null)
            {
                return node.SelectSingleNode("value").InnerText;
            }
            return string.Empty;
        }
     
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)
            serviceProvider.GetService(typeof(IPluginExecutionContext));

            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            Entity entity;

            // Check if the input parameters property bag contains a target
            // of the create operation and that target is of type Entity.
            if (context.InputParameters.Contains("Target") &&
            context.InputParameters["Target"] is Entity)
            {

                // Obtain the target business entity from the input parameters.
                entity = (Entity)context.InputParameters["Target"];

                // Verify that the entity represents a student.(here new_student is entity name)
                if (entity.LogicalName != "new_staffs") { return; }
            }

            else
            {
                return;
            }
                   

            try
            {
              

                Guid staff_guid = (Guid)context.OutputParameters["id"];

                string loginusername_string = null, loginpassword_string = null, firstname_string = null, lastname_string = null, contactnumber_string = null, emailaddress_string = null; 

                if (entity.Attributes.Contains("new_loginusername"))
                {
                    loginusername_string = entity.GetAttributeValue<string>("new_loginusername");
                }

                if (entity.Attributes.Contains("new_loginpassword"))
                {

                    loginpassword_string = entity.GetAttributeValue<string>("new_loginpassword");
                }

                if (entity.Attributes.Contains("new_firstname"))
                {
                    firstname_string = entity.GetAttributeValue<string>("new_firstname");
                }

                if (entity.Attributes.Contains("new_lastname"))
                {
                    lastname_string = entity.GetAttributeValue<string>("new_lastname");
                }

                if (entity.Attributes.Contains("new_contactnumber"))
                {
                    contactnumber_string = entity.GetAttributeValue<string>("new_contactnumber");
                }

                if (entity.Attributes.Contains("emailaddress"))
                {
                    emailaddress_string = entity.GetAttributeValue<string>("emailaddress");
                }
                
                //emailaddress_string = emailid;

                //Check if the loginusername and loginpassword are supplied for the user to be created in AD
                if ((loginusername_string != null) && (loginpassword_string != null))
                {
                    using (new Impersonator(adusername, addomain, adpassword))
                    {                        
                        Create_AD_User(loginusername_string, loginpassword_string, firstname_string, lastname_string, emailaddress_string, contactnumber_string, tracingService, service);
                    }
                }
            }

            catch (FaultException<OrganizationServiceFault> ex)
            {
                throw new InvalidPluginExecutionException("An error occurred in the plug-in.", ex);
            }
        }


        // This function is used to create user in active directory
        public void Create_AD_User(string username, string password, string firstname, string lastname, string emailid, string contactnumber, ITracingService tracingService, IOrganizationService service)
        {
            tracingService.Trace("Inside Create_AD_User");
            try
            {
                //  Step 1: Create a Directory Entry Object, starting at point in the AD Structure that we would like
                //          to add the user to.  This will come from the path that we selected from the Show AD Structure Tab
                //          and DataGrid.
                DirectoryEntry currentADObject = new DirectoryEntry(adrootpath);

                //  Step 2: Make sure that the AD Object that we are adding to is a container.  Meaning that it can
                //          hold other AD Objects (e.g., users, groups, etc.)
                if (currentADObject.SchemaEntry.Name == "container")
                {
                    //  Step 3: Create a User Object of type User, to be added to the Children colllllection of the 
                    //          current AD Object that we created in Step 1
                    DirectoryEntry newUserObject = currentADObject.Children.Add("CN=" + username, "User");

                    //  Step 4: Check to see if the user already exists, and if so, we will overwrite it for Demo simplicity.
                    //          In the real world, you could prompt the user to overwrite or not and code accordingly.
                    if (DirectoryEntry.Exists(newUserObject.Path))
                    {
                        // Step 4a: Remove the user object first
                        currentADObject.Children.Remove(new DirectoryEntry(newUserObject.Path));
                    }

                    //  Step 5: Add the user optional and required properties (sAMAccountName is ALWAYS REQUIRED!!)
                    newUserObject.Properties["sAMAccountName"].Add(username);
                    newUserObject.Properties["givenName"].Add(firstname); //Dont change the givenName and sn, they are the actual active directory properties
                    newUserObject.Properties["sn"].Add(lastname);
                    newUserObject.Properties["mobile"].Add(contactnumber);
                    newUserObject.Properties["mail"].Add(emailid);
                    
             
                    //  Step 6: Commit the changes to the AD data store
                    newUserObject.CommitChanges();

                    //  Step 7: Set the password for the new account, which can only be done AFTER the account exists!
                    //          We are using the "Invoke" method on the newUserObject, which uses Native AD Object under the hood to set
                    //          the password.  I've only seen this done, using the Invoke method, which is why I've used it here
                    newUserObject.Invoke("setPassword", password);

                    //  Step 8: Enable the user, if the user wants to, by setting the userAccountControl property
                    //          to the magical value of 0x0200.  The disable-user value is 0x0002
                    newUserObject.Properties["userAccountControl"].Value = 0x0200;
                    newUserObject.CommitChanges();

                    string ad_successvar = "User: " + username + " successfully created in AD!";
                    tracingService.Trace(ad_successvar);
                     
                    Create_CRM_User(username, firstname, lastname, emailid, contactnumber, tracingService, service);
                }
                else
                {
                    string ad_unsuccessvar = "You must select an AD Object that is a container, user creation in AD Failed";
                    tracingService.Trace(ad_unsuccessvar);
                }
            }

            catch (Exception ex)
            {
                string ad_exception = ex.Message + " some exception in creating the user in AD";
                tracingService.Trace(ad_exception);
            }

            finally
            {

            }

        }

        // this function is used create user in crm2011
        protected void Create_CRM_User(string domainname, string firstname, string lastname, string emailid, string contactnumber, ITracingService tracingService, IOrganizationService service)
        {             
            tracingService.Trace("Inside Create_CRM_User");
            const string BusinessUnitEntityName = "businessunit";
            const string BusinessUnitIdColumnName = "businessunitid";
            const string ParentBusinessUnitIdColumnName = "parentbusinessunitid";
            const string SystemUserEntityName = "systemuser";
            const string FirstNameColumnName = "firstname";
            const string DomainNameColumnName = "domainname";
            const string LastNameColumnName = "lastname";
            const string InternalEmailAddress = "internalemailaddress";
            const string TelephoneNumber = "address1_telephone1";

            Guid userId = Guid.Empty;


            QueryExpression businessUnitQuery = new QueryExpression
            {
                EntityName = BusinessUnitEntityName,
                ColumnSet = new Microsoft.Xrm.Sdk.Query.ColumnSet(BusinessUnitIdColumnName),

                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression(ParentBusinessUnitIdColumnName,
                            ConditionOperator.Null)
                    }
                }

            };

            // Get the business unit id from the returned entity
            EntityCollection entities = service.RetrieveMultiple(businessUnitQuery);

            Guid defaultBusinessUnitId = entities[0].Id;

            string new_domainname = createuser_domain + domainname;
            //Populate an entity with data for a new system user.
            Entity entity = new Entity(SystemUserEntityName);
            entity.Attributes.Add(DomainNameColumnName, new_domainname);
            entity.Attributes.Add(FirstNameColumnName, firstname);
            entity.Attributes.Add(LastNameColumnName, lastname);
            entity.Attributes.Add(InternalEmailAddress, emailid);
            entity.Attributes.Add(TelephoneNumber, contactnumber);
            
            entity.Attributes.Add(BusinessUnitIdColumnName, new EntityReference
            {
                Id = defaultBusinessUnitId,
                Name = BusinessUnitEntityName,
                LogicalName = BusinessUnitEntityName
            });

            userId = service.Create(entity);

            string crm_successvar = "Created CRM User with GUID " + userId.ToString();
            tracingService.Trace(crm_successvar);


            Guid security_guid = new Guid(securityrole);
        
            AssignSecurityRole(userId, security_guid, service);
        }



        protected void AssignSecurityRole(Guid prmUserId, Guid prmSecurityRoleId, IOrganizationService prmCrmWebService)
        {
            // Create new Associate Request object for creating a N:N link between User and Security 
            AssociateRequest wod_AssosiateRequest = new AssociateRequest();
            
            // Create related entity reference object for associating relationship 
            // In our case we will pass (SystemUser) record reference   

            wod_AssosiateRequest.RelatedEntities = new EntityReferenceCollection();
            wod_AssosiateRequest.RelatedEntities.Add(new EntityReference("systemuser", prmUserId));


            // Create new Relationship object for System User & Security Role entity schema and assigning it  
            // to request relationship property 

            wod_AssosiateRequest.Relationship = new Relationship("systemuserroles_association");


            // Create target entity reference object for associating relationship 
            wod_AssosiateRequest.Target = new EntityReference("role", prmSecurityRoleId);


            // Passing AssosiateRequest object to Crm Service Execute method for assigning Security Role to User 
            prmCrmWebService.Execute(wod_AssosiateRequest);
        }

    }
}
