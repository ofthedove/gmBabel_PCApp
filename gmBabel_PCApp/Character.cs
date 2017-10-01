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
        string dir = "characters\\";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string filename = "charlist.xml";
        if (!File.Exists(dir + filename))
        {
            using (FileStream fs = File.Create(dir + filename)) { }
        }
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Character>));

        TextWriter writer = new StreamWriter(dir + filename);

        xmlSerializer.Serialize(writer, characterList);

        writer.Close();
    }

    public static List<Character> Load()
    {
        string filename = "characters\\charlist.xml";
        List<Character> characterList = new List<Character>();

        if (File.Exists(filename))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Character>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                using (TextReader reader = new StreamReader(fs))
                {
                    characterList = (List<Character>)xmlSerializer.Deserialize(reader);
                }
            }
        }

        return characterList;
    }
}