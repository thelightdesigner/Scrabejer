namespace Scrabejer
{
    public partial class Form1 : Form
    {
        private readonly ScrabbleDictionary dictionary = new ScrabbleDictionary();
        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            SetValidWords();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void SetValidWords()
        {
            listBox1.Items.Clear();
            dictionary.RegexPattern = textBox2.Text;
            dictionary.LettersInBank = textBox1.Text;
            listBox1.Items.AddRange(dictionary.ValidWords.ToArray());
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            SetValidWords();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


      /*  private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        } */

       /* private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size += new Size(100,100);

        } */

      /*  private void button3_Click(object sender, EventArgs e)
        {

            Button button = new Button();
            button.Text = "add colums";
            button.BackColor = Color.White;
            
            tableLayoutPanel1.Controls.Add(button, 0, 0);

            button.Click += new EventHandler(mysteryButtonClicked);
        } */

     /*   private void mysteryButtonClicked(object sender, EventArgs e)
        {
            if (sender is not Button b)
            {
                MessageBox.Show("dang");
                return;
            }
            tableLayoutPanel1.ColumnCount += 1;

            Button button = new();
            button.Text = "new";
            button.BackColor = Color.Red;

            tableLayoutPanel1.Controls.Add(button, tableLayoutPanel1.ColumnCount - 1, 0);


        } */
    }
}