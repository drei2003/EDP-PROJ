
namespace TaskManagementSystem
{
    partial class ResetPasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Button resetButton;

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
            label1 = new Label();
            label2 = new Label();
            newPasswordTextBox = new TextBox();
            confirmPasswordTextBox = new TextBox();
            resetButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "New Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 90);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 2;
            label2.Text = "Confirm Password:";
            // 
            // newPasswordTextBox
            // 
            newPasswordTextBox.Location = new Point(30, 50);
            newPasswordTextBox.Name = "newPasswordTextBox";
            newPasswordTextBox.PasswordChar = '*';
            newPasswordTextBox.Size = new Size(240, 23);
            newPasswordTextBox.TabIndex = 1;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(30, 110);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PasswordChar = '*';
            confirmPasswordTextBox.Size = new Size(240, 23);
            confirmPasswordTextBox.TabIndex = 3;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(30, 150);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(240, 30);
            resetButton.TabIndex = 4;
            resetButton.Text = "Reset Password";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += ResetButton_Click;
            // 
            // ResetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 206);
            Controls.Add(resetButton);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(label2);
            Controls.Add(newPasswordTextBox);
            Controls.Add(label1);
            Name = "ResetPasswordForm";
            Text = "Reset Password";
            Load += ResetPasswordForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion
    }
}