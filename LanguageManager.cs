using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sionnach
{
    public enum language {gaeilge, bearla}
    public class LanguageManager
    {
        public static language currentLanguage;
        
        public static string NEWGAMESTRING = "IMIR";
        public static string OPTIONSSTRING = "ROGHANNA";
        public static string EXITGAMESTRING = "SCÓIR";
        public static string SOUNDSTRING = "FUAIME";
        public static string BACKSTRING = "IMIGH";
        public static string LANGUAGESTRING = "TEANGA";
        public static string FULLSCREENSTRING = "LÁNSCÁILEÁN";
        public static string APPLYSTRING = "ATHRÚ";

        public static void setLanguage(language desLanguage)
        {
            LanguageManager.currentLanguage = desLanguage;

            if (desLanguage == language.gaeilge)
            {
                NEWGAMESTRING = "IMIR";
                OPTIONSSTRING = "ROGHANNA";
                EXITGAMESTRING = "SCÓIR";
                SOUNDSTRING = "FUAIME";
                BACKSTRING = "IMIGH";
                LANGUAGESTRING = "TEANGA";
                FULLSCREENSTRING = "LÁNSCÁILEÁN";
                APPLYSTRING = "ATHRÚ";
    }
            else if (desLanguage == language.bearla)
            {
                NEWGAMESTRING = "NEW GAME";
                OPTIONSSTRING = "OPTIONS";
                EXITGAMESTRING = "EXIT";
                SOUNDSTRING = "SOUND";
                BACKSTRING = "BACK";
                LANGUAGESTRING = "LANGUAGE";
                FULLSCREENSTRING = "FULLSCREEN";
                APPLYSTRING = "APPLY";
            }
        }
    }
}
