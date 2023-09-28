using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsControlLibrary;

namespace WinFormsControlLibrary
{
    public partial class TableOfValues : UserControl
    {
        public TableOfValues()
        {
            InitializeComponent();
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Метод для конфигурации строк
        public void ConfigureColumns(List<GridColumnConfig> columnConfigs)
        {
            dataGridView.Columns.Clear();
            foreach (var config in columnConfigs)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    HeaderText = config.HeaderText,
                    Width = config.Width,
                    Visible = config.Visible
                };
                column.DataPropertyName = config.PropertyName;
                dataGridView.Columns.Add(column);
            }
        }
    }
}
