using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TaskManagementSystem
{
    public partial class ResetPasswordForm : Form
    {
        private string resetToken;

        public ResetPasswordForm(string token)
        {
            InitializeComponent();
            resetToken = token;
        }

        public ResetPasswordForm()
        {
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            string newPassword = newPasswordTextBox.Text.Trim();
            string confirmPassword = confirmPasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Create a database connection
                DatabaseConnection dbConnection = new DatabaseConnection();
                using (MySqlConnection connection = dbConnection.GetConnection())
                {
                    connection.Open();

                    // Query to update the password
                    string query = "UPDATE accounts SET password = @Password, reset_token = NULL, token_expiry = NULL WHERE reset_token = @Token";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Password", newPassword); // Ideally, hash the password before saving
                        command.Parameters.AddWithValue("@Token", resetToken);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password has been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid or expired token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetPasswordForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
