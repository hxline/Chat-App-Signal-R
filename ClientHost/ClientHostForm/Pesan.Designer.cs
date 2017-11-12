namespace ClientHostForm
{
    partial class Pesan
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
            this.textPesan = new System.Windows.Forms.TextBox();
            this.buttonKirim = new System.Windows.Forms.Button();
            this.listPesan = new System.Windows.Forms.ListBox();
            this.listOnline = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.buttonUsername = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textPesan
            // 
            this.textPesan.Location = new System.Drawing.Point(12, 12);
            this.textPesan.Name = "textPesan";
            this.textPesan.Size = new System.Drawing.Size(100, 20);
            this.textPesan.TabIndex = 0;
            // 
            // buttonKirim
            // 
            this.buttonKirim.Location = new System.Drawing.Point(127, 10);
            this.buttonKirim.Name = "buttonKirim";
            this.buttonKirim.Size = new System.Drawing.Size(75, 23);
            this.buttonKirim.TabIndex = 1;
            this.buttonKirim.Text = "Kirim";
            this.buttonKirim.UseVisualStyleBackColor = true;
            this.buttonKirim.Click += new System.EventHandler(this.buttonKirim_Click);
            // 
            // listPesan
            // 
            this.listPesan.FormattingEnabled = true;
            this.listPesan.Location = new System.Drawing.Point(15, 197);
            this.listPesan.Name = "listPesan";
            this.listPesan.Size = new System.Drawing.Size(300, 95);
            this.listPesan.TabIndex = 2;
            // 
            // listOnline
            // 
            this.listOnline.FormattingEnabled = true;
            this.listOnline.Location = new System.Drawing.Point(15, 74);
            this.listOnline.Name = "listOnline";
            this.listOnline.Size = new System.Drawing.Size(300, 95);
            this.listOnline.TabIndex = 3;
            this.listOnline.DoubleClick += new System.EventHandler(this.listOnline_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Online";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pesan";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(296, 168);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(225, 12);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(100, 20);
            this.textUsername.TabIndex = 7;
            // 
            // buttonUsername
            // 
            this.buttonUsername.Location = new System.Drawing.Point(331, 9);
            this.buttonUsername.Name = "buttonUsername";
            this.buttonUsername.Size = new System.Drawing.Size(22, 23);
            this.buttonUsername.TabIndex = 8;
            this.buttonUsername.Text = "L";
            this.buttonUsername.UseVisualStyleBackColor = true;
            this.buttonUsername.Click += new System.EventHandler(this.buttonUsername_Click);
            // 
            // Pesan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 304);
            this.Controls.Add(this.buttonUsername);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listOnline);
            this.Controls.Add(this.listPesan);
            this.Controls.Add(this.buttonKirim);
            this.Controls.Add(this.textPesan);
            this.Name = "Pesan";
            this.Text = "Pesan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textPesan;
        private System.Windows.Forms.Button buttonKirim;
        private System.Windows.Forms.ListBox listPesan;
        private System.Windows.Forms.ListBox listOnline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Button buttonUsername;
    }
}

