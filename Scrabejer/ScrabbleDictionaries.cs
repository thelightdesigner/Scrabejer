using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Scrabejer
{
    internal class ScrabbleDictionaries : Dictionary<ScrabbleDictionaryLanguage, string[]>
    {
        
        public string[] Collins { get; private set; } = new string[] { };
        public string[] Webster { get; private set; } = new string[] { };

        public ScrabbleDictionaries()
        {
            Collins = JsonSerializer.Deserialize<string[]>(Encoding.Default.GetString(Properties.Resources.collins));
            Webster = JsonSerializer.Deserialize<string[]>(Encoding.Default.GetString(Properties.Resources.webster));
            this[ScrabbleDictionaryLanguage.WEBSTER] = Webster;
            this[ScrabbleDictionaryLanguage.COLLINS] = Collins;
        }

        
    }
    public enum ScrabbleDictionaryLanguage
    {
        WEBSTER,
        COLLINS,
        NONE
    }
}
