using StudentContracts.BusinessLogicContracts;
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
    }
}
