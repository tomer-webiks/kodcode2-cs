

namespace Calculator
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNumber1 = new System.Windows.Forms.TextBox();
            this.txtNumber2 = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnEquals = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtNumber1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNumber2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblResult, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOne, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEquals, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbOperator, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button4, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button7, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button8, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button9, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button10, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.button11, 4, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(69, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(639, 256);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // txtNumber1
            // 
            this.txtNumber1.Location = new System.Drawing.Point(3, 3);
            this.txtNumber1.Name = "txtNumber1";
            this.txtNumber1.Size = new System.Drawing.Size(88, 22);
            this.txtNumber1.TabIndex = 0;
            this.txtNumber1.Enter += new System.EventHandler(this.txtNumber1_Enter);
            // 
            // txtNumber2
            // 
            this.txtNumber2.Location = new System.Drawing.Point(257, 3);
            this.txtNumber2.Name = "txtNumber2";
            this.txtNumber2.Size = new System.Drawing.Size(88, 22);
            this.txtNumber2.TabIndex = 2;
            this.txtNumber2.Enter += new System.EventHandler(this.txtNumber2_Enter);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(511, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(39, 16);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "result";
            // 
            // btnOne
            // 
            this.btnOne.Location = new System.Drawing.Point(3, 54);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(90, 45);
            this.btnOne.TabIndex = 6;
            this.btnOne.Text = "1";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // btnEquals
            // 
            this.btnEquals.Location = new System.Drawing.Point(384, 3);
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new System.Drawing.Size(74, 34);
            this.btnEquals.TabIndex = 5;
            this.btnEquals.Text = "=";
            this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
            this.btnEquals.Enter += new System.EventHandler(this.btnEquals_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "2";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(257, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "3";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cmbOperator
            // 
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cmbOperator.Location = new System.Drawing.Point(130, 3);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(114, 24);
            this.cmbOperator.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 45);
            this.button3.TabIndex = 10;
            this.button3.Text = "1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(257, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 45);
            this.button4.TabIndex = 11;
            this.button4.Text = "2";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(130, 105);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 45);
            this.button5.TabIndex = 12;
            this.button5.Text = "3";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 156);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 45);
            this.button6.TabIndex = 13;
            this.button6.Text = "1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(130, 156);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 45);
            this.button7.TabIndex = 14;
            this.button7.Text = "1";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(257, 156);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(90, 45);
            this.button8.TabIndex = 15;
            this.button8.Text = "1";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(511, 54);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(90, 45);
            this.button9.TabIndex = 16;
            this.button9.Text = "3";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(511, 105);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(90, 45);
            this.button10.TabIndex = 17;
            this.button10.Text = "3";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(511, 156);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(90, 45);
            this.button11.TabIndex = 18;
            this.button11.Text = "3";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtNumber2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtNumber1;
        private System.Windows.Forms.Button btnEquals;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
    }
}

