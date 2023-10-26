﻿using WinFormsControlLibrary;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // componentlBox1.AddInListBox<>
            Person person1 = new Person("P1", 30, 180);
            Person person2 = new Person("P2", 18, 175);
            Person person3 = new Person("P3", 20, 170);
            componentlBox1.SetLayoutInfo("name {Name} Age {Age} Height {Height}", "{", "}");
            componentlBox1.AddInListBox(new List<Person> { person1, person2, person3 });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? val = fieldForInt1.TextBoxValue;
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

        private void buttonTable_Click(object sender, EventArgs e)
        {
            var pdfgenerator = new TablePdfComponent1();
            var tables = new TableData[]
            {
            new TableData
            {
                Columns = 3,
                Data = new string[][]
                {
                    new string[] { "value 1", "value 2", "value 3" },
                    new string[] { "value 1", "value 2", "value 3" },
                    new string[] {"value 1", "value 2", "value 3" }
                }
            },
            new TableData
            {
                Columns = 3,
                Data = new string[][]
                {
                    new string[] { "value 1", "value 2", "value 3" },
                    new string[] { "value 1", "value 2", "value 3" },
                    new string[] {"value 1", "value 2", "value 3" }
                }
            },            };
            try
            {
                pdfgenerator.GeneratePdf("c:\\users\\60652\\downloads\\table.pdf", "title", tables);
                Console.WriteLine("pdf файл успешно создан.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ошибка: {ex.Message}");
            }
        }

        private void buttonCustomTable_Click(object sender, EventArgs e)
        {
            CustomTablePdfComponent2 generator = new CustomTablePdfComponent2();

            var columnConfigs = new List<ColumnConfig>
            {
                new ColumnConfig { Width = 100f, PropertyName = "Age", ShowName = "Age"},
                new ColumnConfig { Width = 140f, PropertyName = "Name", ShowName = "Name" },
                new ColumnConfig { Width = 160f, PropertyName = "Height", ShowName = "Height" },
            };

            Person person1 = new Person("P1", 30, 180);
            Person person2 = new Person("P2", 18, 175);
            Person person3 = new Person("P3", 20, 170);


            generator.GenerateDocument("c:\\users\\60652\\downloads\\customtable.pdf", "Sample Document", 100f, 50f, new List<Person> { person1, person2, person3 }, columnConfigs);

        }

        private void buttonHistogram_Click(object sender, EventArgs e)
        {
           

            var generator = new GistogramPdfComponent3();
            var data = new List<HistogramData>
            {
                new HistogramData { SeriesName = "Series 1", Data = new double[] { 10, 20, 30, 40, 50 } },
                new HistogramData { SeriesName = "Series 2", Data = new double[] { 15, 25, 35, 45, 55 } }
            };

            generator.GenerateHistogramDocument("C:\\Users\\60652\\Downloads\\gist.pdf", "Histogram Document", "Chart Title", LegendPosition.TopRight, data);

        }
    }
}