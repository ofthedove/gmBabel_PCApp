using System;
using Amazon.Polly;
using Amazon.Polly.Model;
using System.IO;

public class Polly
{
    AmazonPollyClient AWSPollyClient;
    SynthesizeSpeechRequest sreq;
    SynthesizeSpeechResponse sres;

    public Polly()
	{
        Amazon.Runtime.AWSCredentials credentials = new Amazon.Runtime.StoredProfileAWSCredentials("GMBabel");
        AWSPollyClient = new AmazonPollyClient();
        sreq = new SynthesizeSpeechRequest();
        sreq.OutputFormat = OutputFormat.Mp3;
        sreq.VoiceId = VoiceId.Amy;
    }

    public string sendText(string UIString)
    {
        sreq.Text = UIString;
        sres = AWSPollyClient.SynthesizeSpeech(sreq);

        string fileName = mp3Name();
        fileName = fileName + ".mp3";
        using (var fileStream = File.Create("/mp3/" + fileName));
        return fileName;
    }

    private string mp3Name()
    {
        string [] fileArray =Directory.GetFiles("/mp3");
        
        if(fileArray == null)
        {
            return "0001";
        }
        else
        {
            Array.Sort(fileArray);
            string tempString = fileArray[fileArray.Length - 1];
            tempString = tempString.Remove(tempString.Length - 4);
            int tempInteger = Int32.Parse(tempString) +1;
            string returnString = tempInteger.ToString();
            return returnString;
        }
    }
}
