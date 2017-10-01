using System;
using Amazon.Polly;
using Amazon.Polly.Model;
using System.IO;
using System.Configuration;

public class Polly
{
    AmazonPollyClient AWSPollyClient;
    SynthesizeSpeechRequest sreq;
    SynthesizeSpeechResponse sres;

    string dir = "mp3\\";

    public Polly()
	{
        string access = ConfigurationManager.AppSettings["Access"].ToString();
        string secret = ConfigurationManager.AppSettings["Secret"].ToString();
        //Amazon.Runtime.AWSCredentials credentials = new Amazon.Runtime.StoredProfileAWSCredentials("GMBabel");
        AWSPollyClient = new AmazonPollyClient(access, secret, Amazon.RegionEndpoint.USWest2);
        sreq = new SynthesizeSpeechRequest();
        sreq.OutputFormat = OutputFormat.Mp3;
        sreq.VoiceId = VoiceId.Amy;
        sreq.TextType = TextType.Text;
    }

    public string sendText(string UIString)
    {
        sreq.Text = UIString;
        sres = AWSPollyClient.SynthesizeSpeech(sreq);

        string fileName = mp3Name();
        fileName = fileName + ".mp3";
        using (var fileStream = File.Create(dir + fileName))
        {
            sres.AudioStream.CopyTo(fileStream);
            fileStream.Flush();
            fileStream.Close();
        }
        return fileName;
    }

    private string mp3Name()
    {
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string [] fileArray =Directory.GetFiles(dir);
        
        if(fileArray.Length < 1)
        {
            return "0001";
        }
        else
        {
            Array.Sort(fileArray);
            string tempString = fileArray[fileArray.Length - 1];
            tempString = tempString.Split('\\')[1];
            tempString = tempString.Remove(tempString.Length - 4);
            int tempInteger = Int32.Parse(tempString) +1;
            string returnString = tempInteger.ToString().PadLeft(4);
            return returnString;
        }
    }

    public void clear()
    {

    }
}
