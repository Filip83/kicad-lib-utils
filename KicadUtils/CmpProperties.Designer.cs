namespace KicadUtils
{
    partial class CmpProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CmpProperties));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmpDeisg = new System.Windows.Forms.TextBox();
            this.cmpName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openBtn = new System.Windows.Forms.Button();
            this.docuDesc = new System.Windows.Forms.RichTextBox();
            this.docuFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.docuKeyWord = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.FootPrints = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 541);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmpDeisg);
            this.tabPage1.Controls.Add(this.cmpName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 515);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Properties";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmpDeisg
            // 
            this.cmpDeisg.Location = new System.Drawing.Point(143, 56);
            this.cmpDeisg.Name = "cmpDeisg";
            this.cmpDeisg.Size = new System.Drawing.Size(128, 20);
            this.cmpDeisg.TabIndex = 10;
            // 
            // cmpName
            // 
            this.cmpName.Location = new System.Drawing.Point(143, 26);
            this.cmpName.Name = "cmpName";
            this.cmpName.Size = new System.Drawing.Size(288, 20);
            this.cmpName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Reference designator";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Component name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.openBtn);
            this.tabPage2.Controls.Add(this.docuDesc);
            this.tabPage2.Controls.Add(this.docuFile);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.docuKeyWord);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 515);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Docu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(471, 47);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 10;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // docuDesc
            // 
            this.docuDesc.Location = new System.Drawing.Point(144, 93);
            this.docuDesc.Name = "docuDesc";
            this.docuDesc.Size = new System.Drawing.Size(402, 202);
            this.docuDesc.TabIndex = 13;
            this.docuDesc.Text = "";
            // 
            // docuFile
            // 
            this.docuFile.Location = new System.Drawing.Point(144, 47);
            this.docuFile.Name = "docuFile";
            this.docuFile.Size = new System.Drawing.Size(313, 20);
            this.docuFile.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Documentation File";
            // 
            // docuKeyWord
            // 
            this.docuKeyWord.Location = new System.Drawing.Point(144, 21);
            this.docuKeyWord.Name = "docuKeyWord";
            this.docuKeyWord.Size = new System.Drawing.Size(402, 20);
            this.docuKeyWord.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Key Words";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Description:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.FootPrints);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(577, 515);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Footprints Hints";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FootPrints
            // 
            this.FootPrints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FootPrints.Location = new System.Drawing.Point(0, 0);
            this.FootPrints.Name = "FootPrints";
            this.FootPrints.Size = new System.Drawing.Size(577, 515);
            this.FootPrints.TabIndex = 0;
            this.FootPrints.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CancelBtn);
            this.panel1.Controls.Add(this.OkBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 441);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 100);
            this.panel1.TabIndex = 1;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(320, 43);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(175, 43);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 8;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CmpProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 541);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CmpProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Component Properties";
            this.Load += new System.EventHandler(this.CmpProperties_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.TextBox cmpDeisg;
        private System.Windows.Forms.TextBox cmpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox docuFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox docuKeyWord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox docuDesc;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox FootPrints;
    }
}