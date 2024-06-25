using System;

namespace DateTimeApp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.btDateCount = new System.Windows.Forms.Button();
            this.tbDisp = new System.Windows.Forms.TextBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.btDayBefore = new System.Windows.Forms.Button();
            this.btDayAfter = new System.Windows.Forms.Button();
            this.btAge = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(149, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "日付";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpBirthday.Location = new System.Drawing.Point(261, 98);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(212, 31);
            this.dtpBirthday.TabIndex = 1;
            this.dtpBirthday.ValueChanged += new System.EventHandler(this.dtpBirthday_ValueChanged);
            // 
            // btDateCount
            // 
            this.btDateCount.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btDateCount.Location = new System.Drawing.Point(341, 135);
            this.btDateCount.Name = "btDateCount";
            this.btDateCount.Size = new System.Drawing.Size(159, 58);
            this.btDateCount.TabIndex = 2;
            this.btDateCount.Text = "今日までの日数";
            this.btDateCount.UseVisualStyleBackColor = true;
            this.btDateCount.Click += new System.EventHandler(this.btDateCount_Click);
            // 
            // tbDisp
            // 
            this.tbDisp.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.tbDisp.Location = new System.Drawing.Point(115, 347);
            this.tbDisp.Name = "tbDisp";
            this.tbDisp.Size = new System.Drawing.Size(509, 47);
            this.tbDisp.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("MS UI Gothic", 22F);
            this.numericUpDown2.Location = new System.Drawing.Point(140, 176);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(181, 37);
            this.numericUpDown2.TabIndex = 5;
            // 
            // btDayBefore
            // 
            this.btDayBefore.Font = new System.Drawing.Font("MS UI Gothic", 22F);
            this.btDayBefore.Location = new System.Drawing.Point(392, 223);
            this.btDayBefore.Name = "btDayBefore";
            this.btDayBefore.Size = new System.Drawing.Size(99, 41);
            this.btDayBefore.TabIndex = 6;
            this.btDayBefore.Text = "日前";
            this.btDayBefore.UseVisualStyleBackColor = true;
            this.btDayBefore.Click += new System.EventHandler(this.btDayBefore_Click);
            // 
            // btDayAfter
            // 
            this.btDayAfter.Font = new System.Drawing.Font("MS UI Gothic", 22F);
            this.btDayAfter.Location = new System.Drawing.Point(392, 270);
            this.btDayAfter.Name = "btDayAfter";
            this.btDayAfter.Size = new System.Drawing.Size(99, 41);
            this.btDayAfter.TabIndex = 6;
            this.btDayAfter.Text = "日後";
            this.btDayAfter.UseVisualStyleBackColor = true;
            // 
            // btAge
            // 
            this.btAge.Font = new System.Drawing.Font("MS UI Gothic", 22F);
            this.btAge.Location = new System.Drawing.Point(524, 189);
            this.btAge.Name = "btAge";
            this.btAge.Size = new System.Drawing.Size(139, 58);
            this.btAge.TabIndex = 7;
            this.btAge.Text = "年齢";
            this.btAge.UseVisualStyleBackColor = true;
            this.btAge.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btAge);
            this.Controls.Add(this.btDayAfter);
            this.Controls.Add(this.btDayBefore);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.tbDisp);
            this.Controls.Add(this.btDateCount);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Button btDateCount;
        private System.Windows.Forms.TextBox tbDisp;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button btDayBefore;
        private System.Windows.Forms.Button btDayAfter;
        private System.Windows.Forms.Button btAge;
    }
}