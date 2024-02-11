using System.Text.RegularExpressions;

namespace Scrabejer
{
    internal class DictionaryScavenger
    {
        public static readonly Dictionary<char, int> CHARACTER_POINTS = new Dictionary<char, int>()
        {
            { 'a', 1},
            { 'b', 3},
            { 'c', 3},
            { 'd', 2 },
            { 'e', 1},
            { 'f', 4 },
            { 'g', 2 },
            { 'h', 4 },
            { 'i',1 },
            { 'j',8 },
            { 'k',5 },
            { 'l',1 },
            { 'm',3 },
            { 'n',1 },
            { 'o',1 },
            { 'p',3 },
            { 'q',10 },
            { 'r',1 },
            { 's',1 },
            { 't',1 },
            { 'u',1 },
            { 'v',4 },
            { 'w',4 },
            { 'x',8 },
            { 'y',4 },
            { 'z',10 },
        };

        public static readonly List<string> INVALID_RETURN = new() { "Invalid Regex Pattern!" };

        private readonly ScrabbleDictionaries dictionaries;
   
        public string RegexPattern { get; set; }
        public string LettersInBank { get; set; }

        private readonly List<string> validWords = new();
        public List<string> ValidWords
        {
            get
            {
                validWords.Clear();
                validWords.AddRange(getWordsForRegexAndLetters(RegexPattern, LettersInBank));
                return validWords;
            }
        }

        public DictionaryScavenger()
        {
            dictionaries = new ScrabbleDictionaries();
        }



        private string[] scrabbleWords;
        public void SetLanguage(ScrabbleDictionaryLanguage lang)
        {
            scrabbleWords = dictionaries[lang];
        }
        private IEnumerable<string> getWordsForRegexAndLetters(string regexPattern, string letters)
        {
            regexPattern = regexPattern.ToLower();
            letters = letters.ToLower();
            List<string> validWords = new();

            Regex regex;
            try
            {
                regex = new Regex("^" + regexPattern + "$", RegexOptions.Singleline);
            }
            catch
            {
                return INVALID_RETURN;
            }

            bool paranOpen = false;
            foreach (char c in regexPattern)
            {
                if (c == '(' || c == '[') paranOpen = true;
                else if (c == ')' || c == ']') paranOpen = false;
                else if (!paranOpen && char.IsLetter(c))
                    letters += c;
            }

            foreach (var word in scrabbleWords)
            {
                if (word.ContainsOnlyOnce(letters) && regex.IsMatch(word)) validWords.Add(word);
            }
            return validWords.OrderByDescending(word => getPoints(word));
        }

        private static int getPoints(string word)
        {
            int points = 0;
            foreach (char c in word)
            {
                CHARACTER_POINTS.TryGetValue(c, out int pt);
                points += pt;
            }
            return points;
        }



    }
}
