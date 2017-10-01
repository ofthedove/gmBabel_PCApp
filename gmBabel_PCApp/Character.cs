using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class Character
{
    public string CharName { get; set; }
    public VoiceSettings CharVoice { get; set; }

    public override string ToString()
    {
        return CharName;
    }

    public static void Save(List<Character> characterList)
    {
        string filename = "characters\\charlist.xml";
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Character>));

        TextWriter writer = new StreamWriter(filename);
    }

    public static List<Character> Load()
    {
        string filename = "characters\\charlist.xml";
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Character>));

        if (File.Exists(filename))
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            TextReader reader = new StreamReader(fs);
            List<Character> characterList = (List<Character>)xmlSerializer.Deserialize(reader);
            return characterList;
        }
        else
        {
            List<Character> emptyList = new List<Character>();
            return emptyList;
        }