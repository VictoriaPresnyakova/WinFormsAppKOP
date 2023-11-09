using BusinessLogics;
using COP;
using COP.Info;
using COPWinForms;
using DataBaseImplements.Implements;
using Plugins;
using StudentContracts.BindingModels;
using StudentContracts.SearchModels;
using StudentContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsControlLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WinFormsApp
{
    public class PluginsConvention : IPluginsConvention
    {
        private readonly StudentLogic _studentLogic = new StudentLogic(new StudentStorage());
        private readonly EducationLogic _educationLogic = new EducationLogic(new EducationStorage());
        public ComponentLBox componentlBox1 = new ComponentLBox();

        public string PluginName { get; set; } = "Listbox";

        public UserControl GetControl
        {
            get
            {
                Load();
                return componentlBox1;
            }
        }

        public PluginsConventionElement GetElement
        {
            get
            {
                var selectedStudent = componentlBox1.GetObjectFromStr<StudentSearchModel>();
                int? id = null;
                if (selectedStudent != null) {
                    id = Convert.ToInt32((selectedStudent.Id)); 
                }
                byte[] bytes = new byte[16];
                if (!id.HasValue)
                {
                    id = -1;
                }
                BitConverter.GetBytes(id.Value).CopyTo(bytes, 0);
                return new()
                {
                    Id = new Guid(bytes)
                };
            }
        }

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                ComponentWord3 chartComponent = new ComponentWord3();

                List<DiagramData> diagramData = new List<DiagramData>
                {
                };

                string[] categories = _studentLogic.GetYears();


                List<EducationViewModel> lst = _educationLogic.Read(null);
                foreach (EducationViewModel d in lst)
                {
                    double[] temp = new double[categories.Length];
                    double[] list = _studentLogic.GetStudentCountByYear(d.Name);
                    for (int i = 0; i < list.Length; i++)
                    {
                        temp[i] = list[i];
                    }

                    diagramData.Add(new DiagramData { Seria = d.Name, Data = temp });
                }
                DiagramWord diagramWord = new(saveDocument.FileName, "Задание 3", "Название диаграммы", COPWinForms.LegendPosition.Right, diagramData, categories);
                chartComponent.CreateLineChart(diagramWord);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
               
                var list = _studentLogic.Read(null);

                string[][] data = new string[list.Count][];

                for (int i = 0; i < list.Count; i++)
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
                    pdfgenerator.GeneratePdf(saveDocument.FileName, "title", tables);
               
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try {
                ExcelTable table = new();
                var data = _studentLogic.Read(null);
                Dictionary<string, ((List<string>, List<string>), List<int>)> headers = new()
            {
                { "Идентификатор", ((new List<string> { "Id" }, new List<string> {"Идентификатор"} ), new List<int> { 30 } )},
                { "Имя", ((new List <string> { "Name"}, new List<string> { "Имя"}), new List<int> {25})},
                { "Образование", ((new List < string > { "Education_Form", "Date" } , new List < string > { "Форма обучения", "Дата" }), new List<int> { 50, 60 } )}
                };

                ExcelTableInfo<StudentViewModel> info = new(saveDocument.FileName, "My Document", data, headers);
                table.GenerateDocument(info);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteElement(PluginsConventionElement element)
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

        public Form GetForm(PluginsConventionElement element)
        {
            throw new NotImplementedException();
        }

        public Form GetThesaurus()
        {
            throw new NotImplementedException();
        }

        public void ReloadData()
        {
            throw new NotImplementedException();
        }
    }
}
