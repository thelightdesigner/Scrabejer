using System.Text.Json;
using System.Text.RegularExpressions;

namespace Scrabejer
{
    internal class ScrabbleDictionary
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

        public const string SCRABBLE_DICTIONARY_PATH = "dictionary.json";

        public static readonly List<string> INVALID_RETURN = new() { "Invalid Regex Pattern!" };
        public string[] ScrabbleWords { get; private set; }
        public List<string> ValidWords
        {
            get
            {
                validWords.Clear();
                validWords.AddRange(GetWordsForRegexAndLetters(RegexPattern, LettersInBank));
                return validWords;
            }
        }
        private readonly List<string> validWords = new();
        public string RegexPattern { get; set; }
        public string LettersInBank { get; set; }

        public ScrabbleDictionary()
        {
            ScrabbleWords = JsonSerializer.Deserialize<string[]>(File.ReadAllText(SCRABBLE_DICTIONARY_PATH));
            if (ScrabbleWords is null)
            {
                MessageBox.Show("Failed to find and deserialize dictionary.json.");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
        private IEnumerable<string> GetWordsForRegexAndLetters(string regexPattern, string letters)
        {
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

            foreach (var word in ScrabbleWords)
            {
                bool regexIsMatch = false;
                try
                {
                    regexIsMatch = regex.IsMatch(word);
                }
                catch { }

                if (word.ContainsOnlyOnce(letters) && regexIsMatch) validWords.Add(word);
            }
            return validWords.OrderByDescending(word => GetPoints(word));
        }

        public static int GetPoints(string word)
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
