namespace ContactsApp.UI
{
    partial class About
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
            this.ContactsAppLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.MailHyperlink = new System.Windows.Forms.LinkLabel();
            this.emailLabel = new System.Windows.Forms.Label();
            this.GitHubLabel = new System.Windows.Forms.Label();
            this.GithubHyperlink = new System.Windows.Forms.LinkLabel();
            this.DateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ContactsAppLabel
            // 
            this.ContactsAppLabel.AutoSize = true;
            this.ContactsAppLabel.Font = new System.Drawing.Font("Microsoft YaHei", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContactsAppLabel.Location = new System.Drawing.Point(12, 19);
            this.ContactsAppLabel.Name = "ContactsAppLabel";
            this.ContactsAppLabel.Size = new System.Drawing.Size(128, 25);
            this.ContactsAppLabel.TabIndex = 0;
            this.ContactsAppLabel.Text = "ContactsApp";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(14, 44);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(43, 13);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "v. 1.0.0";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(13, 78);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(115, 13);
            this.AuthorLabel.TabIndex = 2;
            this.AuthorLabel.Text = "Author: Ivan Evsyukov";
            // 
            // MailHyperlink
            // 
            this.MailHyperlink.AutoSize = true;
            this.MailHyperlink.Location = new System.Drawing.Point(120, 127);
            this.MailHyperlink.Name = "MailHyperlink";
            this.MailHyperlink.Size = new System.Drawing.Size(88, 13);
            this.MailHyperlink.TabIndex = 3;
            this.MailHyperlink.TabStop = true;
            this.MailHyperlink.Text = "evsyukov@list.ru";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(14, 127);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(100, 13);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "e-mail for feedback:";
            // 
            // GitHubLabel
            // 
            this.GitHubLabel.AutoSize = true;
            this.GitHubLabel.Location = new System.Drawing.Point(13, 144);
            this.GitHubLabel.Name = "GitHubLabel";
            this.GitHubLabel.Size = new System.Drawing.Size(43, 13);
            this.GitHubLabel.TabIndex = 5;
            this.GitHubLabel.Text = "GitHub:";
            // 
            // GithubHyperlink
            // 
            this.GithubHyperlink.AutoSize = true;
            this.GithubHyperlink.Location = new System.Drawing.Point(120, 144);
            this.GithubHyperlink.Name = "GithubHyperlink";
            this.GithubHyperlink.Size = new System.Drawing.Size(212, 13);
            this.GithubHyperlink.TabIndex = 6;
            this.GithubHyperlink.TabStop = true;
            this.GithubHyperlink.Text = "https://github.com/evsyukov/ContactsApp";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(13, 236);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(105, 13);
            this.DateLabel.TabIndex = 7;
            this.DateLabel.Text = "2019 Ivan Evsyukov";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 258);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.GithubHyperlink);
            this.Controls.Add(this.GitHubLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.MailHyperlink);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ContactsAppLabel);
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ContactsAppLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.LinkLabel MailHyperlink;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label GitHubLabel;
        private System.Windows.Forms.LinkLabel GithubHyperlink;
        private System.Windows.Forms.Label DateLabel;
    }
}