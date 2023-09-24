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
            this.listOfValues1 = new WinFormsApp.ListOfValues();
            this.fieldForInt1 = new WinFormsApp.FieldForInt();
            this.SuspendLayout();
            // 
            // listOfValues1
            // 
            this.listOfValues1.Location = new System.Drawing.Point(232, 38);
            this.listOfValues1.Name = "listOfValues1";
            this.listOfValues1.Size = new System.Drawing.Size(225, 225);
            this.listOfValues1.TabIndex = 1;
            this.listOfValues1.Value = "";
            // 
            // fieldForInt1
            // 
            this.fieldForInt1.Location = new System.Drawing.Point(36, 185);
            this.fieldForInt1.Name = "fieldForInt1";
            this.fieldForInt1.Size = new System.Drawing.Size(225, 225);
            this.fieldForInt1.TabIndex = 2;
            this.fieldForInt1.TextBoxValue = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fieldForInt1);
            this.Controls.Add(this.listOfValues1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private ListOfValues listOfValues1;
        private FieldForInt fieldForInt1;
    }
}