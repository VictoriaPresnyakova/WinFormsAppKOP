namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? val = fieldForInt1.TextBoxValue;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listOfValues1.LoadValues(new List<string> { "1111", "2222", "3333" });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listOfValues1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = listOfValues1.Value;
        }
    }
}