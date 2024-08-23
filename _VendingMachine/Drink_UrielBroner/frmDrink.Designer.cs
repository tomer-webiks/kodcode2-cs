namespace Drink
{
    partial class MyDrinks
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
            this.txtNewDrink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSugar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCoffee = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCocoa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMilk = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btPlus = new System.Windows.Forms.Button();
            this.btMinus = new System.Windows.Forms.Button();
            this.dgvAllDrinks = new System.Windows.Forms.DataGridView();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sugar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coffee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cocoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Milk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btAddDrink = new System.Windows.Forms.Button();
            this.btUpdateDrink = new System.Windows.Forms.Button();
            this.btDeleteDrink = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllDrinks)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewDrink
            // 
            this.txtNewDrink.Location = new System.Drawing.Point(470, 68);
            this.txtNewDrink.Name = "txtNewDrink";
            this.txtNewDrink.Size = new System.Drawing.Size(86, 22);
            this.txtNewDrink.TabIndex = 0;
            this.txtNewDrink.TextChanged += new System.EventHandler(this.txtNewDrink_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(577, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "שם סוג שתיה חדש";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "סוכר";
            // 
            // cmbSugar
            // 
            this.cmbSugar.FormattingEnabled = true;
            this.cmbSugar.Items.AddRange(new object[] {
            "0.0",
            "0.5",
            "1.0",
            "1.5",
            "2.0",
            "2.5",
            "3.0"});
            this.cmbSugar.Location = new System.Drawing.Point(748, 198);
            this.cmbSugar.Name = "cmbSugar";
            this.cmbSugar.Size = new System.Drawing.Size(45, 24);
            this.cmbSugar.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(685, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "קפה";
            // 
            // cmbCoffee
            // 
            this.cmbCoffee.FormattingEnabled = true;
            this.cmbCoffee.Items.AddRange(new object[] {
            "0.0",
            "0.5",
            "1.0",
            "1.5",
            "2.0",
            "2.5",
            "3.0"});
            this.cmbCoffee.Location = new System.Drawing.Point(678, 198);
            this.cmbCoffee.Name = "cmbCoffee";
            this.cmbCoffee.Size = new System.Drawing.Size(45, 24);
            this.cmbCoffee.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(622, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "קקאו";
            // 
            // cmbCocoa
            // 
            this.cmbCocoa.FormattingEnabled = true;
            this.cmbCocoa.Items.AddRange(new object[] {
            "0.0",
            "0.5",
            "1.0",
            "1.5",
            "2.0",
            "2.5",
            "3.0"});
            this.cmbCocoa.Location = new System.Drawing.Point(615, 198);
            this.cmbCocoa.Name = "cmbCocoa";
            this.cmbCocoa.Size = new System.Drawing.Size(45, 24);
            this.cmbCocoa.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(556, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "חלב";
            // 
            // cmbMilk
            // 
            this.cmbMilk.FormattingEnabled = true;
            this.cmbMilk.Items.AddRange(new object[] {
            "0.0",
            "0.5",
            "1.0",
            "1.5",
            "2.0",
            "2.5",
            "3.0"});
            this.cmbMilk.Location = new System.Drawing.Point(549, 198);
            this.cmbMilk.Name = "cmbMilk";
            this.cmbMilk.Size = new System.Drawing.Size(45, 24);
            this.cmbMilk.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(486, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "מחיר";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(486, 198);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(41, 22);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.Text = "2";
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // btPlus
            // 
            this.btPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btPlus.Location = new System.Drawing.Point(455, 190);
            this.btPlus.Name = "btPlus";
            this.btPlus.Size = new System.Drawing.Size(23, 31);
            this.btPlus.TabIndex = 5;
            this.btPlus.Text = "+";
            this.btPlus.UseVisualStyleBackColor = true;
            this.btPlus.Click += new System.EventHandler(this.btPlus_Click);
            // 
            // btMinus
            // 
            this.btMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btMinus.Location = new System.Drawing.Point(436, 190);
            this.btMinus.Name = "btMinus";
            this.btMinus.Size = new System.Drawing.Size(23, 31);
            this.btMinus.TabIndex = 6;
            this.btMinus.Text = "-";
            this.btMinus.UseVisualStyleBackColor = true;
            this.btMinus.Click += new System.EventHandler(this.btMinus_Click);
            // 
            // dgvAllDrinks
            // 
            this.dgvAllDrinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllDrinks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name1,
            this.Sugar,
            this.Coffee,
            this.Cocoa,
            this.Milk,
            this.Price});
            this.dgvAllDrinks.Location = new System.Drawing.Point(92, 348);
            this.dgvAllDrinks.Name = "dgvAllDrinks";
            this.dgvAllDrinks.RowHeadersWidth = 51;
            this.dgvAllDrinks.RowTemplate.Height = 24;
            this.dgvAllDrinks.Size = new System.Drawing.Size(776, 243);
            this.dgvAllDrinks.TabIndex = 7;
            // 
            // Name1
            // 
            this.Name1.HeaderText = "שם";
            this.Name1.MinimumWidth = 6;
            this.Name1.Name = "Name1";
            this.Name1.Width = 125;
            // 
            // Sugar
            // 
            this.Sugar.HeaderText = "סוכר";
            this.Sugar.MinimumWidth = 6;
            this.Sugar.Name = "Sugar";
            this.Sugar.Width = 125;
            // 
            // Coffee
            // 
            this.Coffee.HeaderText = "קפה";
            this.Coffee.MinimumWidth = 6;
            this.Coffee.Name = "Coffee";
            this.Coffee.Width = 125;
            // 
            // Cocoa
            // 
            this.Cocoa.HeaderText = "קקאו";
            this.Cocoa.MinimumWidth = 6;
            this.Cocoa.Name = "Cocoa";
            this.Cocoa.Width = 125;
            // 
            // Milk
            // 
            this.Milk.HeaderText = "חלב";
            this.Milk.MinimumWidth = 6;
            this.Milk.Name = "Milk";
            this.Milk.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "מחיר";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 125;
            // 
            // btAddDrink
            // 
            this.btAddDrink.Location = new System.Drawing.Point(273, 163);
            this.btAddDrink.Name = "btAddDrink";
            this.btAddDrink.Size = new System.Drawing.Size(98, 72);
            this.btAddDrink.TabIndex = 8;
            this.btAddDrink.Text = "הוספת סוג שתיה";
            this.btAddDrink.UseVisualStyleBackColor = true;
            this.btAddDrink.Click += new System.EventHandler(this.btAddDrink_Click);
            // 
            // btUpdateDrink
            // 
            this.btUpdateDrink.Location = new System.Drawing.Point(148, 163);
            this.btUpdateDrink.Name = "btUpdateDrink";
            this.btUpdateDrink.Size = new System.Drawing.Size(98, 72);
            this.btUpdateDrink.TabIndex = 8;
            this.btUpdateDrink.Text = "עדכון סוג שתיה";
            this.btUpdateDrink.UseVisualStyleBackColor = true;
            this.btUpdateDrink.Click += new System.EventHandler(this.btUpdateDrink_Click);
            // 
            // btDeleteDrink
            // 
            this.btDeleteDrink.Location = new System.Drawing.Point(12, 163);
            this.btDeleteDrink.Name = "btDeleteDrink";
            this.btDeleteDrink.Size = new System.Drawing.Size(98, 72);
            this.btDeleteDrink.TabIndex = 8;
            this.btDeleteDrink.Text = "מחיקת סוג שתיה";
            this.btDeleteDrink.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(12, 258);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(98, 72);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "שמירת שינויים";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // MyDrinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 617);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btDeleteDrink);
            this.Controls.Add(this.btUpdateDrink);
            this.Controls.Add(this.btAddDrink);
            this.Controls.Add(this.dgvAllDrinks);
            this.Controls.Add(this.btMinus);
            this.Controls.Add(this.btPlus);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbMilk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCocoa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCoffee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSugar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewDrink);
            this.Name = "MyDrinks";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "תכנון מכונת משקאות";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllDrinks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewDrink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSugar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCoffee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCocoa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMilk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btPlus;
        private System.Windows.Forms.Button btMinus;
        private System.Windows.Forms.DataGridView dgvAllDrinks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sugar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coffee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cocoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Milk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Button btAddDrink;
        private System.Windows.Forms.Button btUpdateDrink;
        private System.Windows.Forms.Button btDeleteDrink;
        private System.Windows.Forms.Button btSave;
    }
}