namespace WhiplashWindowsForms
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
            this.txtRegistrationDate = new System.Windows.Forms.TextBox();
            this.txtFirstReminder = new System.Windows.Forms.TextBox();
            this.txtSecondReminder = new System.Windows.Forms.TextBox();
            this.txtThirdReminder = new System.Windows.Forms.TextBox();
            this.btnFindDates = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRegistrationDate
            // 
            this.txtRegistrationDate.Location = new System.Drawing.Point(146, 42);
            this.txtRegistrationDate.Name = "txtRegistrationDate";
            this.txtRegistrationDate.Size = new System.Drawing.Size(166, 20);
            this.txtRegistrationDate.TabIndex = 0;
            // 
            // txtFirstReminder
            // 
            this.txtFirstReminder.Location = new System.Drawing.Point(146, 133);
            this.txtFirstReminder.Name = "txtFirstReminder";
            this.txtFirstReminder.Size = new System.Drawing.Size(166, 20);
            this.txtFirstReminder.TabIndex = 1;
            // 
            // txtSecondReminder
            // 
            this.txtSecondReminder.Location = new System.Drawing.Point(146, 168);
            this.txtSecondReminder.Name = "txtSecondReminder";
            this.txtSecondReminder.Size = new System.Drawing.Size(166, 20);
            this.txtSecondReminder.TabIndex = 2;
            // 
            // txtThirdReminder
            // 
            this.txtThirdReminder.Location = new System.Drawing.Point(146, 207);
            this.txtThirdReminder.Name = "txtThirdReminder";
            this.txtThirdReminder.Size = new System.Drawing.Size(166, 20);
            this.txtThirdReminder.TabIndex = 3;
            // 
            // btnFindDates
            // 
            this.btnFindDates.Location = new System.Drawing.Point(155, 68);
            this.btnFindDates.Name = "btnFindDates";
            this.btnFindDates.Size = new System.Drawing.Size(147, 46);
            this.btnFindDates.TabIndex = 4;
            this.btnFindDates.Text = "FindDates";
            this.btnFindDates.UseVisualStyleBackColor = true;
            this.btnFindDates.Click += new System.EventHandler(this.btnFindDates_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "RegistrationDate(dd-mm-yyyy)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Month(dd-mm-yyyy)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Week(dd-mm-yyyy)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "LastDate(dd-mm-yyyy)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(447, 281);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFindDates);
            this.Controls.Add(this.txtThirdReminder);
            this.Controls.Add(this.txtSecondReminder);
            this.Controls.Add(this.txtFirstReminder);
            this.Controls.Add(this.txtRegistrationDate);
            this.Name = "Form1";
            this.Text = "Whiplash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRegistrationDate;
        private System.Windows.Forms.TextBox txtFirstReminder;
        private System.Windows.Forms.TextBox txtSecondReminder;
        private System.Windows.Forms.TextBox txtThirdReminder;
        private System.Windows.Forms.Button btnFindDates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

