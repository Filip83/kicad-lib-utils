namespace KicadUtils
{
    partial class CompSpreadSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompSpreadSheet));
            this.SprSheetTootlStrip = new System.Windows.Forms.ToolStrip();
            this.Prop = new System.Windows.Forms.ToolStripButton();
            this.spreadSheet = new System.Windows.Forms.DataGridView();
            this.spName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spPinNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spOrientation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.spPinType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.spGraphicStyle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.spNameSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spNumberSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update = new System.Windows.Forms.ToolStripButton();
            this.SprSheetTootlStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spreadSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // SprSheetTootlStrip
            // 
            this.SprSheetTootlStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.SprSheetTootlStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Prop,
            this.Update});
            this.SprSheetTootlStrip.Location = new System.Drawing.Point(0, 0);
            this.SprSheetTootlStrip.Name = "SprSheetTootlStrip";
            this.SprSheetTootlStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.SprSheetTootlStrip.Size = new System.Drawing.Size(948, 31);
            this.SprSheetTootlStrip.TabIndex = 0;
            this.SprSheetTootlStrip.Text = "SprToolTip";
            // 
            // Prop
            // 
            this.Prop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Prop.Image = ((System.Drawing.Image)(resources.GetObject("Prop.Image")));
            this.Prop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Prop.Name = "Prop";
            this.Prop.Size = new System.Drawing.Size(28, 28);
            this.Prop.Text = "Properties";
            this.Prop.ToolTipText = "Component Properties";
            this.Prop.Click += new System.EventHandler(this.Prop_Click);
            // 
            // spreadSheet
            // 
            this.spreadSheet.AllowUserToAddRows = false;
            this.spreadSheet.AllowUserToDeleteRows = false;
            this.spreadSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spreadSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.spName,
            this.spPinNumber,
            this.spOrientation,
            this.spPinType,
            this.spGraphicStyle,
            this.spNameSize,
            this.spNumberSize,
            this.spLength});
            this.spreadSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadSheet.Location = new System.Drawing.Point(0, 31);
            this.spreadSheet.Name = "spreadSheet";
            this.spreadSheet.Size = new System.Drawing.Size(948, 507);
            this.spreadSheet.TabIndex = 1;
            this.spreadSheet.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.spreadSheet_CellEndEdit);
            this.spreadSheet.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.Compare);
            // 
            // spName
            // 
            this.spName.HeaderText = "Name";
            this.spName.Name = "spName";
            // 
            // spPinNumber
            // 
            this.spPinNumber.HeaderText = "Pin Number";
            this.spPinNumber.Name = "spPinNumber";
            // 
            // spOrientation
            // 
            this.spOrientation.HeaderText = "Orientation";
            this.spOrientation.Name = "spOrientation";
            // 
            // spPinType
            // 
            this.spPinType.HeaderText = "Pin Type";
            this.spPinType.Name = "spPinType";
            // 
            // spGraphicStyle
            // 
            this.spGraphicStyle.HeaderText = "Graphic Style";
            this.spGraphicStyle.Name = "spGraphicStyle";
            // 
            // spNameSize
            // 
            this.spNameSize.HeaderText = "Name Size";
            this.spNameSize.Name = "spNameSize";
            // 
            // spNumberSize
            // 
            this.spNumberSize.HeaderText = "Number Size";
            this.spNumberSize.Name = "spNumberSize";
            // 
            // spLength
            // 
            this.spLength.HeaderText = "Length";
            this.spLength.Name = "spLength";
            // 
            // Update
            // 
            this.Update.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Update.Image = ((System.Drawing.Image)(resources.GetObject("Update.Image")));
            this.Update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(28, 28);
            this.Update.Text = "Update";
            this.Update.ToolTipText = "Update Changes";
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // CompSpreadSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 538);
            this.Controls.Add(this.spreadSheet);
            this.Controls.Add(this.SprSheetTootlStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompSpreadSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pin Spread Sheet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompSpreadSheet_FormClosed);
            this.SprSheetTootlStrip.ResumeLayout(false);
            this.SprSheetTootlStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spreadSheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip SprSheetTootlStrip;
        private System.Windows.Forms.DataGridView spreadSheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn spName;
        private System.Windows.Forms.DataGridViewTextBoxColumn spPinNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn spOrientation;
        private System.Windows.Forms.DataGridViewComboBoxColumn spPinType;
        private System.Windows.Forms.DataGridViewComboBoxColumn spGraphicStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn spNameSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn spNumberSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn spLength;
        private System.Windows.Forms.ToolStripButton Prop;
        private System.Windows.Forms.ToolStripButton Update;
    }
}