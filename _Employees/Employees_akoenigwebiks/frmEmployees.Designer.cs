namespace Employees
{
    partial class frmEmployees
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
            this.btSearchWorkerByCode = new System.Windows.Forms.Button();
            this.pStatus = new System.Windows.Forms.Panel();
            this.rdbWidow = new System.Windows.Forms.RadioButton();
            this.rdbDivorce = new System.Windows.Forms.RadioButton();
            this.rdbMarride = new System.Windows.Forms.RadioButton();
            this.rdbSingle = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btSearchWorkerByID = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btAddWorker = new System.Windows.Forms.Button();
            this.btNewWorker = new System.Windows.Forms.Button();
            this.btForward = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCelphone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSearchWorkerByCode
            // 
            this.btSearchWorkerByCode.Location = new System.Drawing.Point(635, 661);
            this.btSearchWorkerByCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSearchWorkerByCode.Name = "btSearchWorkerByCode";
            this.btSearchWorkerByCode.Size = new System.Drawing.Size(289, 64);
            this.btSearchWorkerByCode.TabIndex = 72;
            this.btSearchWorkerByCode.Text = "חיפוש עובד לפי קוד";
            this.btSearchWorkerByCode.UseVisualStyleBackColor = true;
            // 
            // pStatus
            // 
            this.pStatus.Controls.Add(this.rdbWidow);
            this.pStatus.Controls.Add(this.rdbDivorce);
            this.pStatus.Controls.Add(this.rdbMarride);
            this.pStatus.Controls.Add(this.rdbSingle);
            this.pStatus.Location = new System.Drawing.Point(279, 167);
            this.pStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pStatus.Name = "pStatus";
            this.pStatus.Size = new System.Drawing.Size(243, 213);
            this.pStatus.TabIndex = 64;
            // 
            // rdbWidow
            // 
            this.rdbWidow.AutoSize = true;
            this.rdbWidow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rdbWidow.Location = new System.Drawing.Point(83, 150);
            this.rdbWidow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbWidow.Name = "rdbWidow";
            this.rdbWidow.Size = new System.Drawing.Size(68, 26);
            this.rdbWidow.TabIndex = 0;
            this.rdbWidow.TabStop = true;
            this.rdbWidow.Text = "אלמן";
            this.rdbWidow.UseVisualStyleBackColor = true;
            // 
            // rdbDivorce
            // 
            this.rdbDivorce.AutoSize = true;
            this.rdbDivorce.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rdbDivorce.Location = new System.Drawing.Point(79, 106);
            this.rdbDivorce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbDivorce.Name = "rdbDivorce";
            this.rdbDivorce.Size = new System.Drawing.Size(67, 26);
            this.rdbDivorce.TabIndex = 0;
            this.rdbDivorce.TabStop = true;
            this.rdbDivorce.Text = "גרוש";
            this.rdbDivorce.UseVisualStyleBackColor = true;
            // 
            // rdbMarride
            // 
            this.rdbMarride.AutoSize = true;
            this.rdbMarride.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rdbMarride.Location = new System.Drawing.Point(83, 66);
            this.rdbMarride.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbMarride.Name = "rdbMarride";
            this.rdbMarride.Size = new System.Drawing.Size(63, 26);
            this.rdbMarride.TabIndex = 0;
            this.rdbMarride.TabStop = true;
            this.rdbMarride.Text = "נשוי";
            this.rdbMarride.UseVisualStyleBackColor = true;
            // 
            // rdbSingle
            // 
            this.rdbSingle.AutoSize = true;
            this.rdbSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rdbSingle.Location = new System.Drawing.Point(83, 20);
            this.rdbSingle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbSingle.Name = "rdbSingle";
            this.rdbSingle.Size = new System.Drawing.Size(64, 26);
            this.rdbSingle.TabIndex = 0;
            this.rdbSingle.TabStop = true;
            this.rdbSingle.Text = "רווק";
            this.rdbSingle.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbFemale);
            this.panel1.Controls.Add(this.rdbMale);
            this.panel1.Location = new System.Drawing.Point(587, 167);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 213);
            this.panel1.TabIndex = 65;
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rdbFemale.Location = new System.Drawing.Point(79, 103);
            this.rdbFemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(69, 26);
            this.rdbFemale.TabIndex = 0;
            this.rdbFemale.TabStop = true;
            this.rdbFemale.Text = "נקבה";
            this.rdbFemale.UseVisualStyleBackColor = true;
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rdbMale.Location = new System.Drawing.Point(88, 36);
            this.rdbMale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(56, 26);
            this.rdbMale.TabIndex = 0;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "זכר";
            this.rdbMale.UseVisualStyleBackColor = true;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(261, 123);
            this.dtpDateOfBirth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(160, 22);
            this.dtpDateOfBirth.TabIndex = 63;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(143, 124);
            this.txtAge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(88, 22);
            this.txtAge.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(173, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 22);
            this.label7.TabIndex = 46;
            this.label7.Text = "גיל";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(295, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 22);
            this.label6.TabIndex = 45;
            this.label6.Text = "תאריך לידה";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(449, 124);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(88, 22);
            this.txtLastName.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(449, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 22);
            this.label5.TabIndex = 44;
            this.label5.Text = "שם משפחה";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(589, 124);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(88, 22);
            this.txtFirstName.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(589, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 22);
            this.label4.TabIndex = 43;
            this.label4.Text = "שם פרטי";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(715, 124);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(88, 22);
            this.txtID.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(715, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 42;
            this.label3.Text = "מספר זהות";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(833, 124);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(49, 22);
            this.txtCode.TabIndex = 53;
            this.txtCode.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(843, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 22);
            this.label2.TabIndex = 47;
            this.label2.Text = "קוד";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(361, -4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 46);
            this.label1.TabIndex = 41;
            this.label1.Text = "רשימת עובדים";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btSearchWorkerByID
            // 
            this.btSearchWorkerByID.Location = new System.Drawing.Point(295, 661);
            this.btSearchWorkerByID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSearchWorkerByID.Name = "btSearchWorkerByID";
            this.btSearchWorkerByID.Size = new System.Drawing.Size(289, 64);
            this.btSearchWorkerByID.TabIndex = 73;
            this.btSearchWorkerByID.Text = "חיפוש עובד לפי מספר זהות";
            this.btSearchWorkerByID.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(256, 591);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(137, 42);
            this.button6.TabIndex = 71;
            this.button6.Text = "מחיקה";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(444, 591);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 42);
            this.button5.TabIndex = 70;
            this.button5.Text = "עדכון";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btAddWorker
            // 
            this.btAddWorker.Location = new System.Drawing.Point(628, 591);
            this.btAddWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddWorker.Name = "btAddWorker";
            this.btAddWorker.Size = new System.Drawing.Size(137, 42);
            this.btAddWorker.TabIndex = 69;
            this.btAddWorker.Text = "הוספת עובד";
            this.btAddWorker.UseVisualStyleBackColor = true;
            // 
            // btNewWorker
            // 
            this.btNewWorker.Location = new System.Drawing.Point(788, 591);
            this.btNewWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btNewWorker.Name = "btNewWorker";
            this.btNewWorker.Size = new System.Drawing.Size(137, 42);
            this.btNewWorker.TabIndex = 68;
            this.btNewWorker.Text = "חדש";
            this.btNewWorker.UseVisualStyleBackColor = true;
            // 
            // btForward
            // 
            this.btForward.Location = new System.Drawing.Point(280, 401);
            this.btForward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btForward.Name = "btForward";
            this.btForward.Size = new System.Drawing.Size(205, 60);
            this.btForward.TabIndex = 67;
            this.btForward.Text = ">>>>";
            this.btForward.UseVisualStyleBackColor = true;
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(563, 401);
            this.btBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(205, 60);
            this.btBack.TabIndex = 66;
            this.btBack.Text = "<<<<";
            this.btBack.UseVisualStyleBackColor = true;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(259, 540);
            this.txtCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(88, 22);
            this.txtCity.TabIndex = 60;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(405, 540);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(88, 22);
            this.txtNumber.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(280, 495);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 22);
            this.label12.TabIndex = 52;
            this.label12.Text = "עיר";
            // 
            // txtCelphone
            // 
            this.txtCelphone.Location = new System.Drawing.Point(677, 540);
            this.txtCelphone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCelphone.Name = "txtCelphone";
            this.txtCelphone.Size = new System.Drawing.Size(88, 22);
            this.txtCelphone.TabIndex = 57;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(427, 495);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 22);
            this.label11.TabIndex = 50;
            this.label11.Text = "מספר";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(699, 495);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 22);
            this.label9.TabIndex = 49;
            this.label9.Text = "נייד";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(525, 540);
            this.txtStreet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(88, 22);
            this.txtStreet.TabIndex = 61;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(547, 495);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 22);
            this.label10.TabIndex = 48;
            this.label10.Text = "רחוב";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(797, 540);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(88, 22);
            this.txtTelephone.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(819, 495);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 22);
            this.label8.TabIndex = 51;
            this.label8.Text = "טלפון";
            // 
            // frmEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 762);
            this.Controls.Add(this.btSearchWorkerByCode);
            this.Controls.Add(this.pStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSearchWorkerByID);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btAddWorker);
            this.Controls.Add(this.btNewWorker);
            this.Controls.Add(this.btForward);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCelphone);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label8);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEmployees";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "frmEmployees";
            this.Load += new System.EventHandler(this.frmEmployees_Load);
            this.pStatus.ResumeLayout(false);
            this.pStatus.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSearchWorkerByCode;
        private System.Windows.Forms.Panel pStatus;
        private System.Windows.Forms.RadioButton rdbWidow;
        private System.Windows.Forms.RadioButton rdbDivorce;
        private System.Windows.Forms.RadioButton rdbMarride;
        private System.Windows.Forms.RadioButton rdbSingle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbFemale;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSearchWorkerByID;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btAddWorker;
        private System.Windows.Forms.Button btNewWorker;
        private System.Windows.Forms.Button btForward;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCelphone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label8;
    }
}