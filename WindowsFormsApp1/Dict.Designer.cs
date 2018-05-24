namespace CollinsDict
{
    partial class Dict
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dict));
            this.btnExit = new System.Windows.Forms.Button();
            this.lbWords = new System.Windows.Forms.ListBox();
            this.txtEntry = new System.Windows.Forms.RichTextBox();
            this.txInput = new System.Windows.Forms.TextBox();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.pbFlag = new System.Windows.Forms.PictureBox();
            this.ilFlags = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(575, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbWords
            // 
            this.lbWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWords.DisplayMember = "text";
            this.lbWords.FormattingEnabled = true;
            this.lbWords.Location = new System.Drawing.Point(13, 67);
            this.lbWords.Name = "lbWords";
            this.lbWords.ScrollAlwaysVisible = true;
            this.lbWords.Size = new System.Drawing.Size(187, 251);
            this.lbWords.TabIndex = 2;
            this.lbWords.ValueMember = "id";
            this.lbWords.SelectedIndexChanged += new System.EventHandler(this.lbWords_SelectedIndexChanged);
            // 
            // txtEntry
            // 
            this.txtEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntry.AutoWordSelection = true;
            this.txtEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtEntry.HideSelection = false;
            this.txtEntry.Location = new System.Drawing.Point(206, 41);
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.Size = new System.Drawing.Size(444, 277);
            this.txtEntry.TabIndex = 3;
            this.txtEntry.Text = "";
            this.txtEntry.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEntry_MouseDoubleClick);
            // 
            // txInput
            // 
            this.txInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txInput.Location = new System.Drawing.Point(13, 41);
            this.txInput.Name = "txInput";
            this.txInput.Size = new System.Drawing.Size(187, 20);
            this.txInput.TabIndex = 1;
            this.txInput.TextChanged += new System.EventHandler(this.txInput_TextChanged);
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "English To Polish dictionary",
            "Polish To English dictionary"});
            this.cbDirection.Location = new System.Drawing.Point(50, 12);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(289, 21);
            this.cbDirection.TabIndex = 4;
            this.cbDirection.SelectedIndexChanged += new System.EventHandler(this.cbDirection_SelectedIndexChanged);
            // 
            // pbFlag
            // 
            this.pbFlag.Location = new System.Drawing.Point(13, 5);
            this.pbFlag.Name = "pbFlag";
            this.pbFlag.Size = new System.Drawing.Size(32, 32);
            this.pbFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFlag.TabIndex = 6;
            this.pbFlag.TabStop = false;
            this.pbFlag.Click += new System.EventHandler(this.pbFlag_Click);
            // 
            // ilFlags
            // 
            this.ilFlags.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilFlags.ImageStream")));
            this.ilFlags.TransparentColor = System.Drawing.Color.Transparent;
            this.ilFlags.Images.SetKeyName(0, "if_Flag_of_United_Kingdom_96354.png");
            this.ilFlags.Images.SetKeyName(1, "if_Flag_of_Poland_96372.png");
            // 
            // Dict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 326);
            this.Controls.Add(this.pbFlag);
            this.Controls.Add(this.cbDirection);
            this.Controls.Add(this.txInput);
            this.Controls.Add(this.txtEntry);
            this.Controls.Add(this.lbWords);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Dict";
            this.Text = "Dict";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dict_FormClosing);
            this.Load += new System.EventHandler(this.Dict_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Dict_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lbWords;
        private System.Windows.Forms.RichTextBox txtEntry;
        private System.Windows.Forms.TextBox txInput;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.PictureBox pbFlag;
        private System.Windows.Forms.ImageList ilFlags;
    }
}

