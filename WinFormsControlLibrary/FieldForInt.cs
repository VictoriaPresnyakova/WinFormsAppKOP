using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsControlLibrary
{
    public partial class FieldForInt : UserControl
    {
        private EventHandler? _textChangedEvent;
        private event Action? _errorOccured;
        public string Error { get; private set; }

        public FieldForInt()
        {
            InitializeComponent();
            Error = string.Empty;

        }

        public event Action AnErrorOccurred
        {
            add { _errorOccured += value; }
            remove { _errorOccured -= value; }
        }


        public int? TextBoxValue
        {
            get
            {
                if (checkBox.Checked)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    Error = "not a number";
                    _errorOccured?.Invoke();
                    return null;
                }
                if (!int.TryParse(textBox.Text, out int number))
                {
                    Error = "not a number";
                    _errorOccured?.Invoke();
                    return null;
                }
               
                return number;
                
            }
            set
            {
                textBox.Text = value?.ToString();
                checkBox.Checked = (value == null);

            }
        }

        public event EventHandler TextChangedEvent
        {
            add
            {
                _textChangedEvent += value;
            }
            remove
            {
                _textChangedEvent -= value;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox.Text, out int number))
            {
                TextBoxValue = number;
            }
            _textChangedEvent?.Invoke(sender, e);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == '-');
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked) { 
                textBox.ReadOnly = true;
                textBox.Text = null;
            }
            else { textBox.ReadOnly = false; }
            _textChangedEvent?.Invoke(sender, e);

        }

    }
}
