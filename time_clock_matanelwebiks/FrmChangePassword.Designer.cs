namespace time_clock
{
    partial class FrmChangePassword
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
            this.lblid = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtConfrimPassword = new System.Windows.Forms.TextBox();
            this.lblConfrimPassord = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(556, 75);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(67, 16);
            this.lblid.TabIndex = 0;
            this.lblid.Text = "מספר זהות";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(314, 75);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(151, 22);
            this.txtId.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(314, 179);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(151, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(546, 179);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(83, 16);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = " סיסמא חדשה";
            // 
            // txtConfrimPassword
            // 
            this.txtConfrimPassword.Location = new System.Drawing.Point(314, 245);
            this.txtConfrimPassword.Name = "txtConfrimPassword";
            this.txtConfrimPassword.Size = new System.Drawing.Size(151, 22);
            this.txtConfrimPassword.TabIndex = 5;
            // 
            // lblConfrimPassord
            // 
            this.lblConfrimPassord.AutoSize = true;
            this.lblConfrimPassord.Location = new System.Drawing.Point(546, 245);
            this.lblConfrimPassord.Name = "lblConfrimPassord";
            this.lblConfrimPassord.Size = new System.Drawing.Size(82, 16);
            this.lblConfrimPassord.TabIndex = 4;
            this.lblConfrimPassord.Text = "אימות סיסמא";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(314, 124);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(151, 22);
            this.txtOldPassword.TabIndex = 7;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(546, 124);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(77, 16);
            this.lblOldPassword.TabIndex = 6;
            this.lblOldPassword.Text = " סיסמא ישנה";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(359, 343);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(148, 35);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "אישור";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // FrmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.txtConfrimPassword);
            this.Controls.Add(this.lblConfrimPassord);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblid);
            this.Name = "FrmChangePassword";
            this.RightToLeftLayout = true;
            this.Text = "FrmChangePassword";
            this.Load += new System.EventHandler(this.FrmChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtConfrimPassword;
        private System.Windows.Forms.Label lblConfrimPassord;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Button btnSubmit;
    }
}