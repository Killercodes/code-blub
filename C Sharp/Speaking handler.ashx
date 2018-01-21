//Speak Asp.net handler, Speak.ashx
//It speaks what ever is the passed through url query string [text]
<%@ WebHandler Language="C#" Class="Speak" %>

using System;
using System.Web;

public class Speak : IHttpHandler
{
    public void ProcessRequest (HttpContext context)
    {
        System.Speech.Synthesis.SpeechSynthesizer ssy = new System.Speech.Synthesis.SpeechSynthesizer();
        string message = context.Request.QueryString["text"];
        ssy.Speak(message);
        context.Response.ContentType = "text/plain";
        context.Response.Write(message);
    }

    public bool IsReusable
    {
        get{return false;}
    }
}
