using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace mycam
{
    public class Cam
    {
        [DllImport("kernel32.dll")]
  private static extern void Sleep(int dwMilliseconds);

  [DllImport("kernel32.dll")]
  private static extern int Beep(int dwFreq, int dwDuration);

  [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowW")]
  private static extern int capCreateCaptureWindow(string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);
  private const int WS_VISIBLE = 0x10000000;
  private const int WS_CHILD = 0x40000000;

  [DllImport("user32.dll", EntryPoint = "SendMessageW")]
  private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

  [DllImport("user32.dll", EntryPoint = "SendMessageW")]
  private static extern int SendMessageFL(int hwnd, int wMsg, int wParam, string lParam);

  [DllImport("user32.dll", EntryPoint = "SendMessageW")]
  private static extern int SendMessageSD(int hwnd, int wMsg, string wParam, int lParam);

  private const int WM_USER = 0x400;
  private const int WM_CAP_DRIVER_CONNECT = (WM_CAP_START + 10);
  private const int WM_CAP_START = WM_USER;
  private const int WM_CAP_FILE_SAVEDIBA = (WM_CAP_START + 25);
  private const int WM_CAP_SET_SCALE = WM_USER + 53;
  private const int WM_CAP_SET_PREVIEW = WM_USER + 50;
  private const int WM_CAP_SET_PREVIEWRATE = WM_USER + 52;
  private const int WM_CAP_FILE_SAVEDIB = WM_USER + 25;
  private const int WM_CAP_DRIVER_DISCONNECT = WM_USER + 11;

  private string _camtitle;// = "HDCam";// pointer
  private int hWebcam;
  private const int nDevice = 0;
  private const int nFPS = 50;
  private string  _filename;// = "IMAGE.BMP";
  
  
  
  public int getCAM(string cam_title,int cam_x,int cam_y,int cam_width,int cam_height,IntPtr HWNDparent,int cam_ID)
  {
   //Beep(2000, 50);
            _camtitle = cam_title;
   hWebcam = capCreateCaptureWindow(cam_title, WS_VISIBLE + WS_CHILD, cam_x, cam_y,cam_width,cam_height, HWNDparent.ToInt32(), cam_ID);
   //Sleep(5000);
   //inSequence(sender ,e);
   return hWebcam;
  }

  public void makeBEEP(int FREQUENCY)
  {
   Beep(FREQUENCY, 50);
  }
 
  public string NewFileNAME()
  {
   DateTime DT = new DateTime();
   DT.Date.ToString();
   return "File" + DT.Date.ToString();
   
  }
  public void startCAM()
  {
   //makeBEEP(3000);
   SendMessage(hWebcam, WM_CAP_DRIVER_CONNECT, nDevice, 0);
   SendMessage(hWebcam, WM_CAP_SET_SCALE, 1, 0);
   SendMessage(hWebcam, WM_CAP_SET_PREVIEWRATE, nFPS, 0);
   SendMessage(hWebcam, WM_CAP_SET_PREVIEW, 1, 0);
   
  }

  public void captureCAM(string BMPfilename)
  {
            _filename = BMPfilename;
   //string flnm = NewFileNAME();
   //this.Text = flnm;
   //makeBEEP(3000);
    //SendMessageS(hWebcam, WM_CAP_FILE_SAVEDIBA, 0,_filename);
    SendMessageFL(hWebcam, WM_CAP_FILE_SAVEDIBA, 0, _filename);
    makeBEEP(3500);
   //}
  }

  public void stopCAM()
  {
   //SendMessage(hWebcam, WM_CAP_DRIVER_DISCONNECT, _camtitle, 0);
   SendMessageSD(hWebcam, WM_CAP_DRIVER_DISCONNECT, _camtitle, 0);
  }
 }
    
}
