using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class VoiceSettings
{
    public string VoiceID { get; set; }
    public string Language { get; set; }
    public Polly.MyGender Gender { get; set; }

    public static Dictionary<string, string> LanguageOptions()
    {
        Dictionary<string, string> languageOptions = new Dictionary<string, string>();
        languageOptions.Add("cy-GB", "Welsh (United Kingdom)");
        languageOptions.Add("da-DK", "Danish (Denmark)");
        languageOptions.Add("de-DE", "German (Germany)");
        languageOptions.Add("en-AU", "English (Australia)");
        languageOptions.Add("en-GB", "English (United Kingdom)");
        languageOptions.Add("en-GB-WLS", "English (United Kingdom-Welsh)");
        languageOptions.Add("en-IN", "Indian English");
        languageOptions.Add("en-US", "English (United States)");
        languageOptions.Add("es-ES", "Spanish (Castilian)");
        languageOptions.Add("es-US", "Spanish (United States)");
        languageOptions.Add("fr-CA", "French (Canada)");
        languageOptions.Add("fr-FR", "French (France)");
        languageOptions.Add("is-IS", "Icelandic (Iceland)");
        languageOptions.Add("it-IT", "Italian (Italy)");
        languageOptions.Add("ja-JP", "Japanese (Japan)");
        languageOptions.Add("nb-NO", "Norwegian (Bokm)(Norway)");
        languageOptions.Add("nl-NL", "Dutch (Netherlands)");
        languageOptions.Add("pl-PL", "Polish (Poland)");
        languageOptions.Add("pt-BR", "Portuguese (Brazil)");
        languageOptions.Add("pt-PT", "Portuguese (Portugal)");
        languageOptions.Add("ro-RO", "Romanian (Romania)");
        languageOptions.Add("ru-RU", "Russian (Russia)");
        languageOptions.Add("sv-SE", "Swedish (Sweden)");
        languageOptions.Add("tr-TR", "Turkish (Turkey)");

        return languageOptions;
    }
}

  