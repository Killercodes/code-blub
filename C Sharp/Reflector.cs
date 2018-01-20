using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

//A custom C# reflection over console

namespace killercodes_in
{
    class Reflector
    {
        const string usage = "prints assembly reflection information over console. \nUsage: Reflector [assmblyName] ...";
        
        static public void Main(string[] args)
        {
            if ((args.Length == 1 &amp;&amp; (args[0] == "?" || args[0] == "/?" || args[0] == "-?" || args[0].ToLower() == "help")))
            {
                Console.WriteLine(usage);
            }
            else
            {
                Assembly assembly = Assembly.LoadFrom(args[0]);
                Reflect(assembly);                
                String xml = ReflectXml(assembly);
                //Console.Write(xml);
            }
        }



        /// Exports the reflection information as XML
        static String ReflectXml(Assembly assembly)
        {
            StringBuilder xmlDoc = new StringBuilder();
            Func&lt;string, string, string&gt; tagIt = (tag, value) =&gt;
            {
                return string.Format("&lt;{0}&gt;{1}&lt;/{0}&gt;", tag, value);
            };               
            
            xmlDoc.AppendLine(tagIt("assembly", assembly.FullName));
            foreach (string s in assembly.GetManifestResourceNames())
            {
                xmlDoc.AppendLine(tagIt("resource", s));
            }
            
            foreach (AssemblyName a in assembly.GetReferencedAssemblies())
            {
                xmlDoc.AppendLine(tagIt("references", a.Name));
            }
            
            foreach (Module m in assembly.GetModules())
            {
                xmlDoc.AppendLine(tagIt("module", m.Name));
                foreach (Type t in m.GetTypes())
                {
                    xmlDoc.AppendLine(tagIt("class", t.Name));
                    foreach (MethodInfo mtd in t.GetMethods())
                    {
                        StringBuilder parameters = new StringBuilder();
                        foreach (ParameterInfo pra in mtd.GetParameters())
                        {
                            if (mtd.GetParameters().Count() == 1)
                                parameters.Append(pra.ParameterType);
                            else
                                parameters.Append(pra.ParameterType + ",");
                        }
                        
                        xmlDoc.AppendLine(tagIt(mtd.MemberType.ToString(), (String.Format("{0} {1}({2}) ", mtd.ReturnParameter.ParameterType.Name, mtd.Name, parameters.ToString()))));
                    }
                }
            }

            return xmlDoc.ToString();
        }


         //Prints the Reflection information which includes class, method &amp; parameters
        static void Reflect(Assembly assembly)
        {
            Printer(" Assembly: " + assembly.FullName + "/" + assembly.GetName() + "/" + assembly.EntryPoint);
            foreach (string s in assembly.GetManifestResourceNames())
            {
                Printer(" Resource: " + s);
            }

            foreach (AssemblyName a in assembly.GetReferencedAssemblies())
            {
                Printer(" ReferencedAssembly: " + a.Name);
            }

            foreach (Module m in assembly.GetModules())
            {
                Printer(" Module: " + m);
                foreach (Type t in m.GetTypes())
                {
                    Printer(" Class: " + t);
                    foreach (MethodInfo mtd in t.GetMethods())
                    {
                         StringBuilder parameters = new StringBuilder();
                        foreach (ParameterInfo pra in mtd.GetParameters())
                        {
                            if (mtd.GetParameters().Count() == 1)
                                parameters.Append(pra.ParameterType);
                            else
                                parameters.Append(pra.ParameterType + ",");
                        }
                        PrintMethod(String.Format("    {0}:{1} {2}({3}) ", mtd.MemberType, mtd.ReturnParameter.ParameterType.Name, mtd.Name, parameters.ToString()));
                    }
                }
            }
        }

        private static void Printer(String message)
        {
            String[] print = message.Split(':');
            if (print.Count() &gt; 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(print[0] + ":");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(print[1]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
            }

        }

        private static void PrintMethod(String message)
        {
            String[] print = message.Split(':');
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(print[0] + ": ");
            String[] returnType = print[1].Split(' ');
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(returnType[0] + " ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string[] para = (returnType[1]).Split('(');
            Console.Write(para[0]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("(" + para[1]);
        }
    }
}
