namespace Test
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
            this.txtlogebay = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLogHistory = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtlogebay
            // 
            this.txtlogebay.Location = new System.Drawing.Point(529, 153);
            this.txtlogebay.Name = "txtlogebay";
            this.txtlogebay.Size = new System.Drawing.Size(390, 400);
            this.txtlogebay.TabIndex = 9;
            this.txtlogebay.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLogHistory
            // 
            this.txtLogHistory.Location = new System.Drawing.Point(56, 153);
            this.txtLogHistory.Name = "txtLogHistory";
            this.txtLogHistory.Size = new System.Drawing.Size(390, 400);
            this.txtLogHistory.TabIndex = 7;
            this.txtLogHistory.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 621);
            this.Controls.Add(this.txtlogebay);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLogHistory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtlogebay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txtLogHistory;
    }
}

