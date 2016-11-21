namespace KicadUtils
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ReadPrimaryBtn = new System.Windows.Forms.Button();
            this.PrimaryLibList = new System.Windows.Forms.ListBox();
            this.SecondaryLibList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReadSecondaryBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.libOpenDlg = new System.Windows.Forms.OpenFileDialog();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.NewComponent = new System.Windows.Forms.Button();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.SaveAsBtn = new System.Windows.Forms.Button();
            this.saveLibDlg = new System.Windows.Forms.SaveFileDialog();
            this.PropBtn = new System.Windows.Forms.Button();
            this.NewLibBtn = new System.Windows.Forms.Button();
            this.primSearch = new System.Windows.Forms.TextBox();
            this.SecSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReadPrimaryBtn
            // 
            this.ReadPrimaryBtn.Location = new System.Drawing.Point(131, 12);
            this.ReadPrimaryBtn.Name = "ReadPrimaryBtn";
            this.ReadPrimaryBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadPrimaryBtn.TabIndex = 0;
            this.ReadPrimaryBtn.Text = "Read";
            this.ReadPrimaryBtn.UseVisualStyleBackColor = true;
            this.ReadPrimaryBtn.Click += new System.EventHandler(this.RadPrim_Click);
            // 
            // PrimaryLibList
            // 
            this.PrimaryLibList.FormattingEnabled = true;
            this.PrimaryLibList.Location = new System.Drawing.Point(26, 100);
            this.PrimaryLibList.Name = "PrimaryLibList";
            this.PrimaryLibList.Size = new System.Drawing.Size(220, 303);
            this.PrimaryLibList.TabIndex = 1;
            // 
            // SecondaryLibList
            // 
            this.SecondaryLibList.FormattingEnabled = true;
            this.SecondaryLibList.Location = new System.Drawing.Point(362, 100);
            this.SecondaryLibList.Name = "SecondaryLibList";
            this.SecondaryLibList.Size = new System.Drawing.Size(220, 303);
            this.SecondaryLibList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Primary libry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Secondary library";
            // 
            // ReadSecondaryBtn
            // 
            this.ReadSecondaryBtn.Location = new System.Drawing.Point(362, 12);
            this.ReadSecondaryBtn.Name = "ReadSecondaryBtn";
            this.ReadSecondaryBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadSecondaryBtn.TabIndex = 5;
            this.ReadSecondaryBtn.Text = "Read";
            this.ReadSecondaryBtn.UseVisualStyleBackColor = true;
            this.ReadSecondaryBtn.Click += new System.EventHandler(this.ReadSec_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Enabled = false;
            this.AddBtn.Location = new System.Drawing.Point(252, 100);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(46, 23);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "<<";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Enabled = false;
            this.DelBtn.Location = new System.Drawing.Point(252, 156);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(46, 23);
            this.DelBtn.TabIndex = 7;
            this.DelBtn.Text = "Delete";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // libOpenDlg
            // 
            this.libOpenDlg.Filter = "Kicad lib file (*.lib)|*.lib;";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(26, 422);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // NewComponent
            // 
            this.NewComponent.Enabled = false;
            this.NewComponent.Location = new System.Drawing.Point(212, 12);
            this.NewComponent.Name = "NewComponent";
            this.NewComponent.Size = new System.Drawing.Size(99, 23);
            this.NewComponent.TabIndex = 9;
            this.NewComponent.Text = "New Component";
            this.NewComponent.UseVisualStyleBackColor = true;
            this.NewComponent.Click += new System.EventHandler(this.NewComponent_Click);
            // 
            // OpenBtn
            // 
            this.OpenBtn.Enabled = false;
            this.OpenBtn.Location = new System.Drawing.Point(252, 212);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(46, 23);
            this.OpenBtn.TabIndex = 10;
            this.OpenBtn.Text = "Open";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // SaveAsBtn
            // 
            this.SaveAsBtn.Enabled = false;
            this.SaveAsBtn.Location = new System.Drawing.Point(131, 422);
            this.SaveAsBtn.Name = "SaveAsBtn";
            this.SaveAsBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveAsBtn.TabIndex = 11;
            this.SaveAsBtn.Text = "Save As";
            this.SaveAsBtn.UseVisualStyleBackColor = true;
            this.SaveAsBtn.Click += new System.EventHandler(this.SaveAsBtn_Click);
            // 
            // saveLibDlg
            // 
            this.saveLibDlg.Filter = "Kicad lib file (*.lib)|*.lib;";
            // 
            // PropBtn
            // 
            this.PropBtn.Enabled = false;
            this.PropBtn.Location = new System.Drawing.Point(252, 270);
            this.PropBtn.Name = "PropBtn";
            this.PropBtn.Size = new System.Drawing.Size(46, 23);
            this.PropBtn.TabIndex = 12;
            this.PropBtn.Text = "Prop";
            this.PropBtn.UseVisualStyleBackColor = true;
            this.PropBtn.Click += new System.EventHandler(this.PropBtn_Click);
            // 
            // NewLibBtn
            // 
            this.NewLibBtn.Location = new System.Drawing.Point(26, 12);
            this.NewLibBtn.Name = "NewLibBtn";
            this.NewLibBtn.Size = new System.Drawing.Size(99, 23);
            this.NewLibBtn.TabIndex = 13;
            this.NewLibBtn.Text = "New Library";
            this.NewLibBtn.UseVisualStyleBackColor = true;
            this.NewLibBtn.Click += new System.EventHandler(this.NewLib_Click);
            // 
            // primSearch
            // 
            this.primSearch.Location = new System.Drawing.Point(26, 61);
            this.primSearch.Name = "primSearch";
            this.primSearch.Size = new System.Drawing.Size(220, 20);
            this.primSearch.TabIndex = 14;
            this.primSearch.TextChanged += new System.EventHandler(this.PrimSearch_Changed);
            // 
            // SecSearch
            // 
            this.SecSearch.Location = new System.Drawing.Point(362, 61);
            this.SecSearch.Name = "SecSearch";
            this.SecSearch.Size = new System.Drawing.Size(220, 20);
            this.SecSearch.TabIndex = 15;
            this.SecSearch.TextChanged += new System.EventHandler(this.SecSearch_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Regular Expresion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Regular Expresion";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 475);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SecSearch);
            this.Controls.Add(this.primSearch);
            this.Controls.Add(this.NewLibBtn);
            this.Controls.Add(this.PropBtn);
            this.Controls.Add(this.SaveAsBtn);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.NewComponent);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.ReadSecondaryBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SecondaryLibList);
            this.Controls.Add(this.PrimaryLibList);
            this.Controls.Add(this.ReadPrimaryBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kicad Library Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadPrimaryBtn;
        private System.Windows.Forms.ListBox PrimaryLibList;
        private System.Windows.Forms.ListBox SecondaryLibList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ReadSecondaryBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.OpenFileDialog libOpenDlg;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button NewComponent;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.Button SaveAsBtn;
        private System.Windows.Forms.SaveFileDialog saveLibDlg;
        private System.Windows.Forms.Button PropBtn;
        private System.Windows.Forms.Button NewLibBtn;
        private System.Windows.Forms.TextBox primSearch;
        private System.Windows.Forms.TextBox SecSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

