using System.Data;
using MySql.Data.MySqlClient;

namespace TaskManagementSystem
{
    public partial class UsersForm : Form
    {
        private DataTable usersTable;
        private DatabaseConnection dbConnection = new DatabaseConnection();

        public UsersForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            dataGridViewUsers = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            lblTitle = new Label();
            panelControls = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            cmbRole = new ComboBox();
            lblRole = new Label();
            cmbDepartment = new ComboBox();
            lblDepartment = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            panelControls.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(12, 50);
            dataGridViewUsers.MultiSelect = false;
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(776, 250);
            dataGridViewUsers.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.Location = new Point(12, 306);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEdit.Location = new Point(93, 306);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(174, 306);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Location = new Point(713, 306);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(144, 24);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Manage Users";
            // 
            // panelControls
            // 
            panelControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelControls.Controls.Add(btnCancel);
            panelControls.Controls.Add(btnSave);
            panelControls.Controls.Add(cmbRole);
            panelControls.Controls.Add(lblRole);
            panelControls.Controls.Add(cmbDepartment);
            panelControls.Controls.Add(lblDepartment);
            panelControls.Controls.Add(txtPhone);
            panelControls.Controls.Add(lblPhone);
            panelControls.Controls.Add(txtEmail);
            panelControls.Controls.Add(lblEmail);
            panelControls.Controls.Add(txtLastName);
            panelControls.Controls.Add(lblLastName);
            panelControls.Controls.Add(txtFirstName);
            panelControls.Controls.Add(lblFirstName);
            panelControls.Location = new Point(12, 335);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(776, 103);
            panelControls.TabIndex = 6;
            panelControls.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(695, 74);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(614, 74);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(489, 32);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 23);
            cmbRole.TabIndex = 11;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(448, 35);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(33, 15);
            lblRole.TabIndex = 10;
            lblRole.Text = "Role:";
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(292, 32);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(150, 23);
            cmbDepartment.TabIndex = 9;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(225, 35);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(73, 15);
            lblDepartment.TabIndex = 8;
            lblDepartment.Text = "Department:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(69, 32);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(150, 23);
            txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(3, 35);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(44, 15);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Phone:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(489, 6);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(448, 9);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(292, 6);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(150, 23);
            txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(225, 9);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(66, 15);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(69, 6);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(150, 23);
            txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(3, 9);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(67, 15);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name:";
            // 
            // UsersForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(panelControls);
            Controls.Add(lblTitle);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewUsers);
            Name = "UsersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Users";
            Load += UsersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private int editingUserId = -1;
        private bool isAddMode = false;

        private void LoadData()
        {
            usersTable = new DataTable();
            using (var conn = dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT u.user_id, u.first_name, u.last_name, u.email, u.phone, 
                           u.department_id, d.department_name, u.role_id, r.role_name, u.created_at
                    FROM users u
                    LEFT JOIN departments d ON u.department_id = d.department_id
                    LEFT JOIN roles r ON u.role_id = r.role_id";
                using (var cmd = new MySqlCommand(query, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(usersTable);
                }
            }

            dataGridViewUsers.DataSource = usersTable;
            dataGridViewUsers.Columns["user_id"].Visible = false;
            dataGridViewUsers.Columns["department_id"].Visible = false;
            dataGridViewUsers.Columns["role_id"].Visible = false;
            // Optionally, show created_at or format it
            if (dataGridViewUsers.Columns.Contains("created_at"))
                dataGridViewUsers.Columns["created_at"].HeaderText = "Created At";

            LoadDepartments();
            LoadRoles();
        }

        private void LoadDepartments()
        {
            cmbDepartment.Items.Clear();
            using (var conn = dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT department_id, department_name FROM departments";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbDepartment.Items.Add(new
                        {
                            Text = reader.GetString("department_name"),
                            Value = reader.GetInt32("department_id")
                        });
                    }
                }
            }
            cmbDepartment.DisplayMember = "Text";
            cmbDepartment.ValueMember = "Value";
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            using (var conn = dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT role_id, role_name FROM roles";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbRole.Items.Add(new
                        {
                            Text = reader.GetString("role_name"),
                            Value = reader.GetInt32("role_id")
                        });
                    }
                }
            }
            cmbRole.DisplayMember = "Text";
            cmbRole.ValueMember = "Value";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddMode = true;
            editingUserId = -1;

            // Clear form fields
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            cmbDepartment.SelectedIndex = -1;
            cmbRole.SelectedIndex = -1;

            // Show the panel
            panelControls.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isAddMode = false;
            DataGridViewRow row = dataGridViewUsers.SelectedRows[0];
            editingUserId = row.Cells["user_id"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["user_id"].Value) : -1;

            // Populate form fields with null checks
            txtFirstName.Text = row.Cells["first_name"].Value != DBNull.Value ? row.Cells["first_name"].Value.ToString() : "";
            txtLastName.Text = row.Cells["last_name"].Value != DBNull.Value ? row.Cells["last_name"].Value.ToString() : "";
            txtEmail.Text = row.Cells["email"].Value != DBNull.Value ? row.Cells["email"].Value.ToString() : "";
            txtPhone.Text = row.Cells["phone"].Value != DBNull.Value ? row.Cells["phone"].Value.ToString() : "";

            // Set department and role with null checks
            int departmentId = row.Cells["department_id"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["department_id"].Value) : -1;
            int roleId = row.Cells["role_id"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["role_id"].Value) : -1;

            for (int i = 0; i < cmbDepartment.Items.Count; i++)
            {
                dynamic item = cmbDepartment.Items[i]; 
                if (item.Value == departmentId)
                {
                    cmbDepartment.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbRole.Items.Count; i++)
            {
                dynamic item = cmbRole.Items[i];
                if (item.Value == roleId)
                {
                    cmbRole.SelectedIndex = i;
                    break;
                }
            }

            // Show the panel
            panelControls.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridViewUsers.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["user_id"].Value);

                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM users WHERE user_id = @UserId";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();

                        LogAction("Delete", userId, $"Deleted user with ID {userId}");
                    }
                }

                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbDepartment.SelectedIndex == -1 ||
                cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            dynamic selectedDepartment = cmbDepartment.SelectedItem;
            int departmentId = selectedDepartment.Value;

            dynamic selectedRole = cmbRole.SelectedItem;
            int roleId = selectedRole.Value;

            using (var conn = dbConnection.GetConnection())
            {
                conn.Open();
                if (isAddMode)
                {
                    string insertQuery = @"
                        INSERT INTO users (first_name, last_name, email, phone, department_id, role_id)
                        VALUES (@FirstName, @LastName, @Email, @Phone, @DepartmentId, @RoleId)";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                        cmd.Parameters.AddWithValue("@RoleId", roleId);
                        cmd.ExecuteNonQuery();

                        // Get the new user's ID
                        long newUserId = cmd.LastInsertedId;
                        LogAction("Add", (int)newUserId, $"Added user '{firstName} {lastName}'");
                    }
                }
                else
                {
                    string updateQuery = @"
                        UPDATE users
                        SET first_name = @FirstName, last_name = @LastName, email = @Email, phone = @Phone,
                            department_id = @DepartmentId, role_id = @RoleId
                        WHERE user_id = @UserId";
                    using (var cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                        cmd.Parameters.AddWithValue("@RoleId", roleId);
                        cmd.Parameters.AddWithValue("@UserId", editingUserId);
                        cmd.ExecuteNonQuery();

                        LogAction("Edit", editingUserId, $"Edited user '{firstName} {lastName}'");
                    }
                }
            }

            LoadData();
            panelControls.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelControls.Visible = false;
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
                
        }

        private void LogAction(string action, int? recordId, string details)
        {
            // Optionally, replace '1' with the actual current user ID if available
            int? userId = 1; 
            using (var conn = dbConnection.GetConnection())
            {
                conn.Open();
                string logQuery = @"
                    INSERT INTO logs (user_id, action, table_name, record_id, details, log_time)
                    VALUES (@user_id, @action, @table_name, @record_id, @details, NOW())";
                using (var cmd = new MySqlCommand(logQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", (object?)userId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@table_name", "user");
                    cmd.Parameters.AddWithValue("@record_id", (object?)recordId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@details", details);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}