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


        public string? TextBoxValue
        {
            get
            {
                if (string.IsNullOrEmpty(textBox.Text) && !checkBox.Checked)
                {
                    Error = "not a number";
                    _errorOccured?.Invoke();
                    return null;
                }
                if (!checkBox.Checked && !int.TryParse(textBox.Text, out int _))
                {
                    Error = "not a number";
                    _errorOccured?.Invoke();
                    return null;
                }
                return textBox.Text;
                
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && !int.TryParse(value, out int _))
                {
                    Error = "not a number";
                    _errorOccured?.Invoke();
                    return;
                }
                textBox.Text = value;
                if (!string.IsNullOrEmpty(value)) {
                    checkBox.Checked = false;
                }
                else
                {
                    checkBox.Checked = true;
                }

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
            _textChangedEvent?.Invoke(sender, e);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked) { 
                textBox.ReadOnly = true;
                textBox.Text = null;
            }
            else { textBox.ReadOnly = false; }
        }
    }
}
