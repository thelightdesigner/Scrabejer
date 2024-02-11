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
        public ScrabbleDictionaries()
        {
            this[ScrabbleDictionaryLanguage.COLLINS] = JsonSerializer.Deserialize<string[]>(Encoding.Default.GetString(Properties.Resources.collins));
            this[ScrabbleDictionaryLanguage.WEBSTER] = JsonSerializer.Deserialize<string[]>(Encoding.Default.GetString(Properties.Resources.webster));
        }
    }
    public enum ScrabbleDictionaryLanguage
    {
        WEBSTER,
        COLLINS
    }
}
