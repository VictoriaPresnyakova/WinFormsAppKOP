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
    public partial class ListOfValues : UserControl
    {
        private string? SelectedValue = string.Empty;
        public ListOfValues()
        {
            InitializeComponent();

        }

        public void LoadValues(List<string> data)
        {
            if (data.Count == 0 || data is null)
            {
                return;
            }
            listBox.Items.AddRange(data.ToArray<object>());
        }

        public void Clear()
        {
            listBox.Items.Clear();

        }

        public string? Value
        {
            get
            {
                return SelectedValue;
            }
            set
            {
                if (listBox.Items.Contains(value))
                {
                    SelectedValue = value;
                }
            }
        }


        private EventHandler? _selectedChangedEvent;
        public event EventHandler SelectedChangedEvent
        {
            add
            {
                _selectedChangedEvent += value;
            }
            remove
            {
                _selectedChangedEvent -= value;
            }
        }

        private void SelectedValueChanged(object sender, EventArgs e)
        {
            _selectedChangedEvent?.Invoke(sender, e);
        }

    }
}

