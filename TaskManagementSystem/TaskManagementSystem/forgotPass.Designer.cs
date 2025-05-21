using System;
    using System.Data;
    using System.Net;
    using System.Net.Mail;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;

    namespace TaskManagementSystem
    {
        partial class forgotPass
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            emailTextBox = new TextBox();
            submitButton = new Button();
            linkLabelLogin = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(225, 19);
            label1.TabIndex = 0;
            label1.Text = "Enter your email to reset password:";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(30, 60);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(240, 23);
            emailTextBox.TabIndex = 1;
            emailTextBox.TextChanged += emailTextBox_TextChanged;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(30, 100);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(240, 30);
            submitButton.TabIndex = 2;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += SubmitButton_Click;
            // 
            // linkLabelLogin
            // 
            linkLabelLogin.AutoSize = true;
            linkLabelLogin.Location = new Point(30, 140);
            linkLabelLogin.Name = "linkLabelLogin";
            linkLabelLogin.Size = new Size(79, 15);
            linkLabelLogin.TabIndex = 3;
            linkLabelLogin.TabStop = true;
            linkLabelLogin.Text = "Back to Login";
            linkLabelLogin.LinkClicked += linkLabelLogin_LinkClicked;
            // 
            // forgotPass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 182);
            Controls.Add(linkLabelLogin);
            Controls.Add(submitButton);
            Controls.Add(emailTextBox);
            Controls.Add(label1);
            Name = "forgotPass";
            Text = "Forgot Password";
            Load += forgotPass_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
            {
                string email = emailTextBox.Text.Trim();

                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please enter your email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Create a database connection
                    DatabaseConnection dbConnection = new DatabaseConnection();
                    using (MySqlConnection connection = dbConnection.GetConnection())
                    {
                        connection.Open();

                        // Query to check if the email exists in the database
                        string query = "SELECT COUNT(*) FROM accounts WHERE email = @Email";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Email", email);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count > 0)
                            {
                                // Generate a unique token
                                string resetToken = Guid.NewGuid().ToString();
                                DateTime tokenExpiry = DateTime.Now.AddHours(1); // Token valid for 1 hour

                                // Update the reset token and expiry in the accounts table
                                string updateTokenQuery = "UPDATE accounts SET reset_token = @Token, token_expiry = @Expiry WHERE email = @Email";
                                using (MySqlCommand updateCommand = new MySqlCommand(updateTokenQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Token", resetToken);
                                    updateCommand.Parameters.AddWithValue("@Expiry", tokenExpiry);
                                    updateCommand.Parameters.AddWithValue("@Email", email);
                                    updateCommand.ExecuteNonQuery();
                                }

                                // Send the reset email
                                SendResetEmail(email, resetToken);
                            }
                            else
                            {
                                MessageBox.Show("Email not found. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void SendResetEmail(string email, string token)
            {
                try
                {
                    // Open the ResetPasswordForm and pass the token
                    ResetPasswordForm resetForm = new ResetPasswordForm(token);
                    resetForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open the reset form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Add this at the bottom of forgotPass
            private void OpenResetFormButton_Click(object sender, EventArgs e)
            {
                var resetForm = new ResetPasswordForm();
                resetForm.ShowDialog();
            }

            private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                // Hide this form and show the login form
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.Show();
            }

            #endregion

            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.TextBox emailTextBox;
            private System.Windows.Forms.Button submitButton;
            private System.Windows.Forms.LinkLabel linkLabelLogin;
        }
    }