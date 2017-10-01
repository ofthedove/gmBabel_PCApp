using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmBabel_PCApp
{
    public class Character
    {
        public string CharName { get; set; }
        public VoiceSettings CharVoice { get; set; }

        public override string ToString()
        {
            return CharName;
        }
    }
}
