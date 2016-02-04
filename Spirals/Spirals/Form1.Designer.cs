namespace Spirals
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.checkBoxCogs = new System.Windows.Forms.CheckBox();
            this.checkBoxLines = new System.Windows.Forms.CheckBox();
            this.textBoxOutput2 = new System.Windows.Forms.TextBox();
            this.listBoxCogSizes = new System.Windows.Forms.ListBox();
            this.textBoxCogSize = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxDrawAtOnce = new System.Windows.Forms.CheckBox();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddToLibrary = new System.Windows.Forms.Button();
            this.buttonLibrary = new System.Windows.Forms.Button();
            this.comboBoxQuality = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRandomise = new System.Windows.Forms.Button();
            this.labelLibrarySize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(16, 14);
            this.pictureBoxDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(854, 603);
            this.pictureBoxDisplay.TabIndex = 0;
            this.pictureBoxDisplay.TabStop = false;
            this.pictureBoxDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDisplay_Paint);
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGo.Location = new System.Drawing.Point(16, 638);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(100, 28);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "Start";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(905, 30);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(117, 63);
            this.textBoxOutput.TabIndex = 2;
            // 
            // checkBoxCogs
            // 
            this.checkBoxCogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCogs.AutoSize = true;
            this.checkBoxCogs.Checked = true;
            this.checkBoxCogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCogs.Location = new System.Drawing.Point(147, 636);
            this.checkBoxCogs.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCogs.Name = "checkBoxCogs";
            this.checkBoxCogs.Size = new System.Drawing.Size(62, 21);
            this.checkBoxCogs.TabIndex = 4;
            this.checkBoxCogs.Text = "Cogs";
            this.checkBoxCogs.UseVisualStyleBackColor = true;
            this.checkBoxCogs.CheckedChanged += new System.EventHandler(this.checkBoxCogs_CheckedChanged);
            // 
            // checkBoxLines
            // 
            this.checkBoxLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxLines.AutoSize = true;
            this.checkBoxLines.Checked = true;
            this.checkBoxLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLines.Location = new System.Drawing.Point(243, 636);
            this.checkBoxLines.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxLines.Name = "checkBoxLines";
            this.checkBoxLines.Size = new System.Drawing.Size(64, 21);
            this.checkBoxLines.TabIndex = 5;
            this.checkBoxLines.Text = "Lines";
            this.checkBoxLines.UseVisualStyleBackColor = true;
            this.checkBoxLines.CheckedChanged += new System.EventHandler(this.checkBoxLines_CheckedChanged);
            // 
            // textBoxOutput2
            // 
            this.textBoxOutput2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput2.Location = new System.Drawing.Point(905, 100);
            this.textBoxOutput2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxOutput2.Multiline = true;
            this.textBoxOutput2.Name = "textBoxOutput2";
            this.textBoxOutput2.Size = new System.Drawing.Size(117, 30);
            this.textBoxOutput2.TabIndex = 6;
            // 
            // listBoxCogSizes
            // 
            this.listBoxCogSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCogSizes.FormattingEnabled = true;
            this.listBoxCogSizes.ItemHeight = 16;
            this.listBoxCogSizes.Location = new System.Drawing.Point(905, 203);
            this.listBoxCogSizes.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxCogSizes.Name = "listBoxCogSizes";
            this.listBoxCogSizes.Size = new System.Drawing.Size(117, 196);
            this.listBoxCogSizes.TabIndex = 7;
            this.listBoxCogSizes.SelectedIndexChanged += new System.EventHandler(this.listBoxCogSizes_SelectedIndexChanged);
            // 
            // textBoxCogSize
            // 
            this.textBoxCogSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCogSize.Location = new System.Drawing.Point(905, 432);
            this.textBoxCogSize.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCogSize.Name = "textBoxCogSize";
            this.textBoxCogSize.Size = new System.Drawing.Size(117, 22);
            this.textBoxCogSize.TabIndex = 8;
            this.textBoxCogSize.TextChanged += new System.EventHandler(this.textBoxCogSize_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(905, 462);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(119, 38);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(903, 508);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(119, 44);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStop.Location = new System.Drawing.Point(16, 686);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 28);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // checkBoxDrawAtOnce
            // 
            this.checkBoxDrawAtOnce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxDrawAtOnce.AutoSize = true;
            this.checkBoxDrawAtOnce.Checked = true;
            this.checkBoxDrawAtOnce.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDrawAtOnce.Location = new System.Drawing.Point(147, 665);
            this.checkBoxDrawAtOnce.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxDrawAtOnce.Name = "checkBoxDrawAtOnce";
            this.checkBoxDrawAtOnce.Size = new System.Drawing.Size(113, 21);
            this.checkBoxDrawAtOnce.TabIndex = 16;
            this.checkBoxDrawAtOnce.Text = "Draw at once";
            this.checkBoxDrawAtOnce.UseVisualStyleBackColor = true;
            this.checkBoxDrawAtOnce.CheckedChanged += new System.EventHandler(this.checkBoxDrawAtOnce_CheckedChanged);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUndo.Location = new System.Drawing.Point(905, 560);
            this.buttonUndo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(119, 42);
            this.buttonUndo.TabIndex = 17;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(945, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cogs";
            // 
            // buttonAddToLibrary
            // 
            this.buttonAddToLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddToLibrary.Location = new System.Drawing.Point(905, 631);
            this.buttonAddToLibrary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddToLibrary.Name = "buttonAddToLibrary";
            this.buttonAddToLibrary.Size = new System.Drawing.Size(116, 43);
            this.buttonAddToLibrary.TabIndex = 19;
            this.buttonAddToLibrary.Text = "Add to Library";
            this.buttonAddToLibrary.UseVisualStyleBackColor = true;
            this.buttonAddToLibrary.Click += new System.EventHandler(this.buttonAddToLibrary_Click);
            // 
            // buttonLibrary
            // 
            this.buttonLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLibrary.Location = new System.Drawing.Point(904, 679);
            this.buttonLibrary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLibrary.Name = "buttonLibrary";
            this.buttonLibrary.Size = new System.Drawing.Size(117, 43);
            this.buttonLibrary.TabIndex = 20;
            this.buttonLibrary.Text = "Library";
            this.buttonLibrary.UseVisualStyleBackColor = true;
            this.buttonLibrary.Click += new System.EventHandler(this.buttonLibrary_Click);
            // 
            // comboBoxQuality
            // 
            this.comboBoxQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxQuality.FormattingEnabled = true;
            this.comboBoxQuality.Location = new System.Drawing.Point(202, 698);
            this.comboBoxQuality.Name = "comboBoxQuality";
            this.comboBoxQuality.Size = new System.Drawing.Size(105, 24);
            this.comboBoxQuality.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 701);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Quality";
            // 
            // buttonRandomise
            // 
            this.buttonRandomise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandomise.Location = new System.Drawing.Point(720, 679);
            this.buttonRandomise.Name = "buttonRandomise";
            this.buttonRandomise.Size = new System.Drawing.Size(150, 43);
            this.buttonRandomise.TabIndex = 23;
            this.buttonRandomise.Text = "Randomise";
            this.buttonRandomise.UseVisualStyleBackColor = true;
            this.buttonRandomise.Click += new System.EventHandler(this.buttonRandomise_Click);
            // 
            // labelLibrarySize
            // 
            this.labelLibrarySize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLibrarySize.AutoSize = true;
            this.labelLibrarySize.Location = new System.Drawing.Point(792, 644);
            this.labelLibrarySize.Name = "labelLibrarySize";
            this.labelLibrarySize.Size = new System.Drawing.Size(78, 17);
            this.labelLibrarySize.TabIndex = 24;
            this.labelLibrarySize.Text = "Entries: xxx";
            this.labelLibrarySize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 734);
            this.Controls.Add(this.labelLibrarySize);
            this.Controls.Add(this.buttonRandomise);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxQuality);
            this.Controls.Add(this.buttonLibrary);
            this.Controls.Add(this.buttonAddToLibrary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.checkBoxDrawAtOnce);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxCogSize);
            this.Controls.Add(this.listBoxCogSizes);
            this.Controls.Add(this.textBoxOutput2);
            this.Controls.Add(this.checkBoxLines);
            this.Controls.Add(this.checkBoxCogs);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.CheckBox checkBoxCogs;
        private System.Windows.Forms.CheckBox checkBoxLines;
        private System.Windows.Forms.TextBox textBoxOutput2;
        private System.Windows.Forms.ListBox listBoxCogSizes;
        private System.Windows.Forms.TextBox textBoxCogSize;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxDrawAtOnce;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddToLibrary;
        private System.Windows.Forms.Button buttonLibrary;
        private System.Windows.Forms.ComboBox comboBoxQuality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRandomise;
        private System.Windows.Forms.Label labelLibrarySize;
    }
}

