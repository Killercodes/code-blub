<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Management.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.InteropServices.dll</Reference>
  <Namespace>System.Management</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

//using System.Management;

void Main()
{		
	ManagementObjectCollection mbsList = null;
    ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
    mbsList = mbs.Get();
    string id = "";
    foreach (ManagementObject mo in mbsList)
    {
        id = mo["ProcessorID"].ToString();
    }
	
	 ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
    ManagementObjectCollection moc = mos.Get();
    string motherBoard = "";
    foreach (ManagementObject mo in moc)
    {
        motherBoard = (string)mo["SerialNumber"];
    }
	
	string uniqueSystemId = id + motherBoard;
	Console.WriteLine(uniqueSystemId);
}

// Define other methods and classes here
