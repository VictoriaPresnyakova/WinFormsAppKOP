using BusinessLogics;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.VisualBasic;
using StudentContracts.BindingModels;
using StudentContracts.BusinessLogicContracts;
using StudentContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FormStudent : Form
    {
        public int Id { set { id = value; } }

        public bool is_changed = false;

        private readonly IEducationLogic educationLogic;
        private readonly IStudentLogic studentLogic;

        private int? id;

        public FormStudent(IEducationLogic _educationLogic, IStudentLogic _studentLogic)
        {
            InitializeComponent();
            educationLogic = _educationLogic;
            this.studentLogic = _studentLogic;

            userDateTimePicker1.MinValue = DateTime.Now.AddYears(-6);
            userDateTimePicker1.MaxValue = DateTime.Now;

            //userDateTimePicker1._valueChanged += new System.EventHandler(FormStudent_Load);
        }

        private void LoadData()
        {
            try
            {
                var list1 = educationLogic.Read(null);
                List<string> list = new List<string>();
                foreach (var item in list1)
                {
                    list.Add(
                        item.Name
                    );
                }
                if (list != null)
                {
                   listOfValues1.LoadValues(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            LoadData();
            if (id.HasValue)
            {
                try
                {
                    StudentViewModel view = studentLogic.Read(new StudentBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        listOfValues1.Value = view.Education_Form;
                        userDateTimePicker1.SelectedValue = view.Date;
                        textBox1.Text = view.Av_Score[0].ToString();
                        textBox2.Text = view.Av_Score[1].ToString();
                        textBox3.Text = view.Av_Score[2].ToString();
                        textBox4.Text = view.Av_Score[3].ToString();
                        textBox5.Text = view.Av_Score[4].ToString();
                        textBox6.Text = view.Av_Score[5].ToString();
                        textBox7.Text = view.Av_Score[6].ToString();
                        textBox8.Text = view.Av_Score[7].ToString();
                        textBox9.Text = view.Av_Score[8].ToString();
                        textBox10.Text = view.Av_Score[9].ToString();
                        textBox11.Text = view.Av_Score[10].ToString();
                        textBox12.Text = view.Av_Score[11].ToString();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(listOfValues1.Value))
            {
                MessageBox.Show("Выберите форму обучения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (userDateTimePicker1.SelectedValue == null)
            {
                MessageBox.Show("Заполните дату поступления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)
                || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text)
                || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text)
                || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox11.Text) || string.IsNullOrEmpty(textBox12.Text))
            {
                MessageBox.Show("Заполните средний балл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<double> values = new List<double>
                {
                    double.Parse(textBox1.Text),
                    double.Parse(textBox2.Text),
                    double.Parse(textBox3.Text),
                    double.Parse(textBox4.Text),
                    double.Parse(textBox5.Text),
                    double.Parse(textBox6.Text),
                    double.Parse(textBox7.Text),
                    double.Parse(textBox8.Text),
                    double.Parse(textBox9.Text),
                    double.Parse(textBox10.Text),
                    double.Parse(textBox11.Text),
                    double.Parse(textBox12.Text)
                };


                studentLogic.CreateOrUpdate(new StudentBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    Education_Form = listOfValues1.Value.ToString(),
                    Date = ((DateTime)userDateTimePicker1.SelectedValue).ToUniversalTime(),
                    Av_Score = values,
                }); ;
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

        private void TextChanged(object sender, EventArgs e)
        {
            is_changed= true;
        }

    }
}
