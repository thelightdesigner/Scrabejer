using System.Collections.Generic;

namespace Scrabejer
{
    public partial class Form1 : Form
    {

        public const string VER = "v2.0.0";

        private readonly DictionaryScavenger scavenger;
        private readonly ScrabbleDictionaries scrabbleDictionarys;

       // private readonly IEnumerator<string[]> dictionaryEnumerator;
        public Form1()
        {
            InitializeComponent();
            try
            {
                scavenger = new DictionaryScavenger();
                setDictionary(ScrabbleDictionaryLanguage.WEBSTER);
            }
            catch
            {
            }
       //     dictionaryEnumerator = new List<string[]> { scrabbleDictionarys.Collins, scrabbleDictionarys.Webster }.GetEnumerator();
            
        }
        private void setValidWords()
        {
            listBox1.Items.Clear();
            scavenger.RegexPattern = textBox2.Text;
            scavenger.LettersInBank = textBox1.Text;
            listBox1.Items.AddRange(scavenger.ValidWords.ToArray());
        }
        private void setDictionary(ScrabbleDictionaryLanguage lang)
        {
            scavenger.SetLanguage(lang);
            switch (lang)
            {
                case ScrabbleDictionaryLanguage.WEBSTER:
                    button4.Image = null;
                    break;
                case ScrabbleDictionaryLanguage.COLLINS:
                    button4.Image = null;
                    break;
                default:
                    throw new ArgumentException("lang cannot be NONE.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            setValidWords();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            setValidWords();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"Scrabejer {VER}";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
        }
    }
}