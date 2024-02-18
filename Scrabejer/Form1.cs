namespace Scrabejer
{
    public partial class Form1 : Form
    {
        public const string VER = "v2.0.2-debug";
        private readonly DictionaryScavenger scavenger;
        private readonly IEnumerator<ScrabbleDictionaryLanguage> dictionaryEnumerator;
        public Form1()
        {
            InitializeComponent();
            scavenger = new DictionaryScavenger();
            setLanguage(ScrabbleDictionaryLanguage.WEBSTER);
            dictionaryEnumerator = Enum.GetValues<ScrabbleDictionaryLanguage>().ToList().GetEnumerator();
            dictionaryEnumerator.MoveNext();
            ResizeRedraw = true;
        }
        private void setValidWords()
        {
            listBox1.Items.Clear();
            scavenger.RegexPattern = textBox2.Text;
            scavenger.LettersInBank = textBox1.Text;
            listBox1.Items.AddRange(scavenger.ValidWords.ToArray());
        }
        private void setLanguage(ScrabbleDictionaryLanguage lang)
        {
            scavenger.SetLanguage(lang);
            switch (lang)
            {
                case ScrabbleDictionaryLanguage.WEBSTER:
                    button4.BackgroundImage = Properties.Resources.Webster1;
                    break;
                case ScrabbleDictionaryLanguage.COLLINS:
                    button4.BackgroundImage = Properties.Resources.Collins1;
                    break;
                default:
                    throw new ArgumentException("lang invalid.");
            }
            setValidWords();
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
            if (!dictionaryEnumerator.MoveNext())
            {
                dictionaryEnumerator.Reset();
                dictionaryEnumerator.MoveNext();
            }

            setLanguage(dictionaryEnumerator.Current);
        }
    }
}