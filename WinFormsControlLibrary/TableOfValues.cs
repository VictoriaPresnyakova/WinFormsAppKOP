﻿using System;
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

        // Метод отчистки строк.
        public void ClearRows()
        {
            dataGridView.Rows.Clear();
        }

        // Публичное свойство для установки и получения индекса выбранной строки.
        public int SelectedRowIndex
        {
            get
            {
                if (dataGridView.SelectedRows.Count > 0)
                    return dataGridView.SelectedRows[0].Index;
                return -1;
            }
            set
            {
                if (value >= 0 && value < dataGridView.RowCount)
                    dataGridView.Rows[value].Selected = true;
            }
        }

        // Публичный параметризованный метод для получения объекта из выбранной строки.
        public T GetSelectedObject<T>() where T : new()
        {
            T obj = new T();
            if (SelectedRowIndex >= 0)
            {
                var row = dataGridView.Rows[SelectedRowIndex];
                foreach (var column in dataGridView.Columns.Cast<DataGridViewColumn>())
                {
                    var property = typeof(T).GetProperty(column.DataPropertyName);
                    if (property != null)
                    {
                        object cellValue = row.Cells[column.Index].Value;
                        if (cellValue != null)
                        {
                            property.SetValue(obj, cellValue);
                        }
                    }
                }
            }
            return obj;
        }

        // Параметризованный метод для установки значения ячейки из списка.
        public void SetCellValueFromList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                dataGridView.Rows.Add();
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    var property = typeof(T).GetProperty(dataGridView.Columns[j].DataPropertyName);
                    if ((property != null))
                    {
                        dataGridView.Rows[i].Cells[j].Value = property.GetValue(list[i]);
                    }
                }
            }
        }
    }
}
