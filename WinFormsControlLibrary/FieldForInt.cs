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

namespace WinFormsApp
{
    public partial class FieldForInt : UserControl
    {
        public FieldForInt()
        {
            InitializeComponent();
        }

        public string? TextBoxValue
        {
            get
            {
                
                return textBox.Text;
                
            }
            set
            {
                textBox.Text = value;

            }
        }

        private EventHandler? _textChangedEvent;
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
            if (checkBox.Checked) { textBox.Hide(); }
            else { textBox.Show(); }
        }
    }
}
