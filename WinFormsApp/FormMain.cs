using BusinessLogics;
using COP;
using COP.Info;
using COPWinForms;
using StudentContracts.BindingModels;
using StudentContracts.BusinessLogicContracts;
using StudentContracts.SearchModels;
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
using Unity;
using WinFormsControlLibrary;

namespace WinFormsApp
{
    public partial class FormMain : Form
    {
        private readonly IStudentLogic _studentLogic;
        private readonly IEducationLogic _educationLogic;
        public FormMain(IEducationLogic educationLogic, IStudentLogic studentLogic)
        {
            _educationLogic = educationLogic;
            _studentLogic = studentLogic;
            InitializeComponent();
            string layoutInfo = "Форма обучения: {Education_Form} Идентификатор: {Id} ФИО: {Name} Дата поступления: {Date}";
            componentlBox1.SetLayoutInfo(layoutInfo, "{", "}");
            this.KeyDown+= form_KeyDown;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _studentLogic.Read(null);
                componentlBox1.AddInListBox(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewElement()
        {
            var form = Program.Container.Resolve<FormStudent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void UpdateElement()
        {
            var form = Program.Container.Resolve<FormStudent>();
            if (componentlBox1.SelectedIndex != -1)
            {
                var selectedStudent = componentlBox1.GetObjectFromStr<StudentSearchModel>();

                form.Id = Convert.ToInt32((selectedStudent.Id));

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите студента для редактирования");
            }
        }
        private void DeleteElement()
        {
            if (componentlBox1.SelectedIndex != -1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var selectedStudent = componentlBox1.GetObjectFromStr<StudentSearchModel>();
                    int id = Convert.ToInt32(selectedStudent.Id);
                    try
                    {
                        _studentLogic.Delete(new StudentBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите студента для удаления");
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewElement();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateElement();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteElement();
        }

        private void справочникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormEducation>();
            form.ShowDialog();
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComponentWord3 chartComponent = new ComponentWord3();

            List<DiagramData> diagramData = new List<DiagramData>
            {
            };

            string[] categories =  _studentLogic.GetYears();


            List<EducationViewModel> lst = _educationLogic.Read(null);
            foreach (EducationViewModel d in lst)
            {
                double[] temp = new double[categories.Length];
                double[] list = _studentLogic.GetStudentCountByYear(d.Name);
                for (int i = 0; i< list.Length; i++)
                {
                    temp[i] = list[i];
                }
                
                diagramData.Add(new DiagramData { Seria = d.Name, Data = temp});
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "docx|*.docx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DiagramWord diagramWord = new(dialog.FileName, "Задание 3", "Название диаграммы", COPWinForms.LegendPosition.Right, diagramData, categories);
                    chartComponent.CreateLineChart(diagramWord);
                    MessageBox.Show("Диаграмма создана успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelTable table = new();
            var data = _studentLogic.Read(null);
            Dictionary<string, ((List<string>, List<string>), List<int>)> headers = new()
            {
                { "Идентификатор", ((new List<string> { "Id" }, new List<string> {"Идентификатор"} ), new List<int> { 30 } )},
                { "Имя", ((new List <string> { "Name"}, new List<string> { "Имя"}), new List<int> {25})},
                { "Образование", ((new List < string > { "Education_Form", "Date" } , new List < string > { "Форма обучения", "Дата" }), new List<int> { 50, 60 } )}
            };
            
            using var dialog = new SaveFileDialog
            {
                Filter = "xlsx|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExcelTableInfo<StudentViewModel> info = new(dialog.FileName, "My Document", data, headers);
                    table.GenerateDocument(info);
                    MessageBox.Show("Сохарненоуспешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
            var list = _studentLogic.Read(null);

            string[][] data = new string[list.Count][];

            for (int i = 0;i < list.Count; i++)
            {
                string[] temp = new string[6];
                for (int j = 0; j < 6; j++)
                {
                    temp[j] = list[i].Av_Score[j].ToString();
                }
                data[i] = temp;
            }

            var pdfgenerator = new TablePdfComponent1();
            var tables = new TableData[]
            {
                new TableData
                {
                    Columns = 6,
                    Data = data,
                },
            };
            try
            {
                pdfgenerator.GeneratePdf(fileName, "title", tables);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ошибка: {ex.Message}");
            }
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                создатьToolStripMenuItem_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.U)
            {
                изменитьToolStripMenuItem_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                удалитьToolStripMenuItem_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                pdfToolStripMenuItem_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.T)
            {
                excelToolStripMenuItem_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                wordToolStripMenuItem_Click(sender, e);
            }

        }

    }
}
