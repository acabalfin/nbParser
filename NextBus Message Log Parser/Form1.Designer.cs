namespace NextBus_Message_Log_Parser
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
            this.filePath_in = new System.Windows.Forms.TextBox();
            this.BrowseFile = new System.Windows.Forms.Button();
            this.Parse_button = new System.Windows.Forms.Button();
            this.filePath_out = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filePath_in
            // 
            this.filePath_in.Location = new System.Drawing.Point(13, 74);
            this.filePath_in.Name = "filePath_in";
            this.filePath_in.ReadOnly = true;
            this.filePath_in.Size = new System.Drawing.Size(259, 20);
            this.filePath_in.TabIndex = 0;
            // 
            // BrowseFile
            // 
            this.BrowseFile.Location = new System.Drawing.Point(13, 32);
            this.BrowseFile.Name = "BrowseFile";
            this.BrowseFile.Size = new System.Drawing.Size(75, 23);
            this.BrowseFile.TabIndex = 1;
            this.BrowseFile.Text = "Open File";
            this.BrowseFile.UseVisualStyleBackColor = true;
            this.BrowseFile.Click += new System.EventHandler(this.BrowseFile_Click);
            // 
            // Parse_button
            // 
            this.Parse_button.Enabled = false;
            this.Parse_button.Location = new System.Drawing.Point(12, 136);
            this.Parse_button.Name = "Parse_button";
            this.Parse_button.Size = new System.Drawing.Size(75, 23);
            this.Parse_button.TabIndex = 2;
            this.Parse_button.Text = "Parse";
            this.Parse_button.UseVisualStyleBackColor = true;
            this.Parse_button.Click += new System.EventHandler(this.Parse_button_Click);
            // 
            // filePath_out
            // 
            this.filePath_out.Location = new System.Drawing.Point(13, 178);
            this.filePath_out.Name = "filePath_out";
            this.filePath_out.ReadOnly = true;
            this.filePath_out.Size = new System.Drawing.Size(259, 20);
            this.filePath_out.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File To Parse Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parsed File Location";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePath_out);
            this.Controls.Add(this.Parse_button);
            this.Controls.Add(this.BrowseFile);
            this.Controls.Add(this.filePath_in);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "NextBus Message Log Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePath_in;
        private System.Windows.Forms.Button BrowseFile;
        private System.Windows.Forms.Button Parse_button;
        private System.Windows.Forms.TextBox filePath_out;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

