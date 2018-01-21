void Main()
{
	 ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
        cmdStartInfo.FileName = @"C:\Windows\System32\cmd.exe";
        cmdStartInfo.RedirectStandardOutput = true;
        cmdStartInfo.RedirectStandardError = true;
        cmdStartInfo.RedirectStandardInput = true;
        cmdStartInfo.UseShellExecute = false;
        cmdStartInfo.CreateNoWindow = true;

        Process cmdProcess = new Process();
        cmdProcess.StartInfo = cmdStartInfo;
        cmdProcess.ErrorDataReceived += cmd_Error;
        cmdProcess.OutputDataReceived += cmd_DataReceived;
        cmdProcess.EnableRaisingEvents = true;
        cmdProcess.Start();
        cmdProcess.BeginOutputReadLine();
        cmdProcess.BeginErrorReadLine();

        cmdProcess.StandardInput.WriteLine("dir");     //Execute ping bing.com
        cmdProcess.StandardInput.WriteLine("exit");                  //Execute exit.

        cmdProcess.WaitForExit();
}

static void cmd_DataReceived(object sender, DataReceivedEventArgs e)
{
   Console.WriteLine(e.Data);
}

static void cmd_Error(object sender, DataReceivedEventArgs e)
{
   Console.WriteLine("Error from other process");
   Console.WriteLine(e.Data);
}
 
