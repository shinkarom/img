namespace img
{
    partial class FormSettings
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
            this.checkedListBoxPaths = new System.Windows.Forms.CheckedListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.checkBoxDisableBack = new System.Windows.Forms.CheckBox();
            this.checkBoxShowToolTip = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkedListBoxPaths
            // 
            this.checkedListBoxPaths.FormattingEnabled = true;
            this.checkedListBoxPaths.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxPaths.Name = "checkedListBoxPaths";
            this.checkedListBoxPaths.Size = new System.Drawing.Size(290, 274);
            this.checkedListBoxPaths.TabIndex = 0;
            this.checkedListBoxPaths.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBoxPaths.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(213, 373);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(303, 373);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(314, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add...";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(314, 41);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Enabled = false;
            this.buttonUp.Location = new System.Drawing.Point(314, 70);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 5;
            this.buttonUp.Text = "Move Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Enabled = false;
            this.buttonDown.Location = new System.Drawing.Point(314, 99);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 6;
            this.buttonDown.Text = "Move Down";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // checkBoxDisableBack
            // 
            this.checkBoxDisableBack.AutoSize = true;
            this.checkBoxDisableBack.Location = new System.Drawing.Point(15, 314);
            this.checkBoxDisableBack.Name = "checkBoxDisableBack";
            this.checkBoxDisableBack.Size = new System.Drawing.Size(125, 17);
            this.checkBoxDisableBack.TabIndex = 7;
            this.checkBoxDisableBack.Text = "Disable moving back";
            this.checkBoxDisableBack.UseVisualStyleBackColor = true;
            this.checkBoxDisableBack.CheckedChanged += new System.EventHandler(this.checkBoxDisableBack_CheckedChanged);
            // 
            // checkBoxShowToolTip
            // 
            this.checkBoxShowToolTip.AutoSize = true;
            this.checkBoxShowToolTip.Location = new System.Drawing.Point(17, 339);
            this.checkBoxShowToolTip.Name = "checkBoxShowToolTip";
            this.checkBoxShowToolTip.Size = new System.Drawing.Size(84, 17);
            this.checkBoxShowToolTip.TabIndex = 8;
            this.checkBoxShowToolTip.Text = "Show tooltip";
            this.checkBoxShowToolTip.UseVisualStyleBackColor = true;
            this.checkBoxShowToolTip.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(401, 402);
            this.Controls.Add(this.checkBoxShowToolTip);
            this.Controls.Add(this.checkBoxDisableBack);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkedListBoxPaths);
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxPaths;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.CheckBox checkBoxDisableBack;
        private System.Windows.Forms.CheckBox checkBoxShowToolTip;
    }
}