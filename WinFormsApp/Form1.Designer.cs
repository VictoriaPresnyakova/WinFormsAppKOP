﻿using WinFormsControlLibrary;

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
            this.tableOfValues1.Location = new System.Drawing.Point(413, 12);
            this.tableOfValues1.Name = "tableOfValues1";
            this.tableOfValues1.SelectedRowIndex = -1;
            this.tableOfValues1.Size = new System.Drawing.Size(662, 418);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 450);
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
    }
}