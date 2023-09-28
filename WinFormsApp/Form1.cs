using WinFormsControlLibrary;

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

        private void buttonAddConfig_Click(object sender, EventArgs e)
        {
            var columnConfigs = new List<GridColumnConfig>
            {
                new GridColumnConfig { HeaderText = "Name", Width = 100, Visible = true, PropertyName = "Name" },
                new GridColumnConfig { HeaderText = "Age", Width = 80, Visible = true, PropertyName = "Age" },
                new GridColumnConfig { HeaderText = "Height", Width = 80, Visible = true, PropertyName = "Height" },
            };

            tableOfValues1.ConfigureColumns(columnConfigs);
        }

        private void buttonAddCells_Click(object sender, EventArgs e)
        {
            Person person1 = new Person("P1", 30, 180);
            Person person2 = new Person("P2", 18, 175);
            Person person3 = new Person("P3", 20, 170);
            tableOfValues1.SetCellValueFromList(new List<Person> { person1, person2, person3 });
           
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            tableOfValues1.ClearRows();
        }

        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            MessageBox.Show((tableOfValues1.GetSelectedObject<Person>()).ToString());
        }
    }
}