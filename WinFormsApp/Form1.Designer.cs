using WinFormsControlLibrary;

namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listOfValues1 = new WinFormsControlLibrary.ListOfValues();
            this.fieldForInt1 = new WinFormsControlLibrary.FieldForInt();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableOfValues1 = new WinFormsControlLibrary.TableOfValues();
            this.buttonAddConfig = new System.Windows.Forms.Button();
            this.AddCells = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonTable = new System.Windows.Forms.Button();
            this.buttonCustomTable = new System.Windows.Forms.Button();
            this.buttonHistogram = new System.Windows.Forms.Button();
            this.componentlBox1 = new COPWinForms.ComponentLBox();
            this.SuspendLayout();
            // 
            // listOfValues1
            // 
            this.listOfValues1.Location = new System.Drawing.Point(12, 12);
            this.listOfValues1.Name = "listOfValues1";
            this.listOfValues1.Size = new System.Drawing.Size(225, 225);
            this.listOfValues1.TabIndex = 1;
            this.listOfValues1.Value = "";
            // 
            // fieldForInt1
            // 
            this.fieldForInt1.Location = new System.Drawing.Point(182, 12);
            this.fieldForInt1.Name = "fieldForInt1";
            this.fieldForInt1.Size = new System.Drawing.Size(225, 225);
            this.fieldForInt1.TabIndex = 2;
            this.fieldForInt1.TextBoxValue = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 61);
            this.button1.TabIndex = 3;
            this.button1.Text = "проверить поле";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "заполнить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 34);
            this.button3.TabIndex = 5;
            this.button3.Text = "очистить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 276);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 62);
            this.button4.TabIndex = 6;
            this.button4.Text = "получить выбранное";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 375);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(150, 31);
            this.textBox1.TabIndex = 7;
            // 
            // tableOfValues1
            // 
            this.tableOfValues1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableOfValues1.Location = new System.Drawing.Point(413, -2);
            this.tableOfValues1.Name = "tableOfValues1";
            this.tableOfValues1.SelectedRowIndex = -1;
            this.tableOfValues1.Size = new System.Drawing.Size(618, 261);
            this.tableOfValues1.TabIndex = 8;
            // 
            // buttonAddConfig
            // 
            this.buttonAddConfig.Location = new System.Drawing.Point(1081, 12);
            this.buttonAddConfig.Name = "buttonAddConfig";
            this.buttonAddConfig.Size = new System.Drawing.Size(112, 34);
            this.buttonAddConfig.TabIndex = 9;
            this.buttonAddConfig.Text = "Add config";
            this.buttonAddConfig.UseVisualStyleBackColor = true;
            this.buttonAddConfig.Click += new System.EventHandler(this.buttonAddConfig_Click);
            // 
            // AddCells
            // 
            this.AddCells.Location = new System.Drawing.Point(1081, 59);
            this.AddCells.Name = "AddCells";
            this.AddCells.Size = new System.Drawing.Size(112, 34);
            this.AddCells.TabIndex = 10;
            this.AddCells.Text = "Add Cells";
            this.AddCells.UseVisualStyleBackColor = true;
            this.AddCells.Click += new System.EventHandler(this.buttonAddCells_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1081, 112);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 34);
            this.button5.TabIndex = 11;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1081, 162);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(112, 59);
            this.button6.TabIndex = 12;
            this.button6.Text = "Get Selected";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.buttonGetSelected_Click);
            // 
            // buttonTable
            // 
            this.buttonTable.Location = new System.Drawing.Point(977, 265);
            this.buttonTable.Name = "buttonTable";
            this.buttonTable.Size = new System.Drawing.Size(137, 34);
            this.buttonTable.TabIndex = 13;
            this.buttonTable.Text = "buttonTable";
            this.buttonTable.UseVisualStyleBackColor = true;
            this.buttonTable.Click += new System.EventHandler(this.buttonTable_Click);
            // 
            // buttonCustomTable
            // 
            this.buttonCustomTable.Location = new System.Drawing.Point(977, 316);
            this.buttonCustomTable.Name = "buttonCustomTable";
            this.buttonCustomTable.Size = new System.Drawing.Size(137, 34);
            this.buttonCustomTable.TabIndex = 14;
            this.buttonCustomTable.Text = "buttonCustomTable";
            this.buttonCustomTable.UseVisualStyleBackColor = true;
            this.buttonCustomTable.Click += new System.EventHandler(this.buttonCustomTable_Click);
            // 
            // buttonHistogram
            // 
            this.buttonHistogram.Location = new System.Drawing.Point(977, 372);
            this.buttonHistogram.Name = "buttonHistogram";
            this.buttonHistogram.Size = new System.Drawing.Size(137, 34);
            this.buttonHistogram.TabIndex = 15;
            this.buttonHistogram.Text = "buttonHistogram";
            this.buttonHistogram.UseVisualStyleBackColor = true;
            this.buttonHistogram.Click += new System.EventHandler(this.buttonHistogram_Click);
            // 
            // componentlBox1
            // 
            this.componentlBox1.Location = new System.Drawing.Point(344, 265);
            this.componentlBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.componentlBox1.Name = "componentlBox1";
            this.componentlBox1.SelectedIndex = -1;
            this.componentlBox1.Size = new System.Drawing.Size(526, 282);
            this.componentlBox1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 547);
            this.Controls.Add(this.componentlBox1);
            this.Controls.Add(this.buttonHistogram);
            this.Controls.Add(this.buttonCustomTable);
            this.Controls.Add(this.buttonTable);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.AddCells);
            this.Controls.Add(this.buttonAddConfig);
            this.Controls.Add(this.tableOfValues1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fieldForInt1);
            this.Controls.Add(this.listOfValues1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListOfValues listOfValues1;
        private FieldForInt fieldForInt1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private TableOfValues tableOfValues1;
        private Button buttonAddConfig;
        private Button AddCells;
        private Button button5;
        private Button button6;
        private Button buttonTable;
        private Button buttonCustomTable;
        private Button buttonHistogram;
        private COPWinForms.ComponentLBox componentlBox1;
    }
}