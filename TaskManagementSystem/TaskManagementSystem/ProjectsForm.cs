using System.Data;
using MySql.Data.MySqlClient;

namespace TaskManagementSystem
{
    public partial class ProjectsForm : Form
    {
        private DataTable projectsTable;
        private DatabaseConnection dbConnection = new DatabaseConnection();

        public ProjectsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.dataGridViewProjects = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblManager = new System.Windows.Forms.Label();
            this.cmbManager = new System.Windows.Forms.ComboBox();
            this.lblBudget = new System.Windows.Forms.Label();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).BeginInit();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProjects
            // 
            this.dataGridViewProjects.AllowUserToAddRows = false;
            this.dataGridViewProjects.AllowUserToDeleteRows = false;
            this.dataGridViewProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjects.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewProjects.MultiSelect = false;
            this.dataGridViewProjects.Name = "dataGridViewProjects";
            this.dataGridViewProjects.ReadOnly = true;
            this.dataGridViewProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProjects.Size = new System.Drawing.Size(776, 250);
            this.dataGridViewProjects.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 306);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(93, 306);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(174, 306);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(713, 306);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(169, 24);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Manage Projects";
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.Controls.Add(this.btnCancel);
            this.panelControls.Controls.Add(this.btnSave);
            this.panelControls.Controls.Add(this.cmbDepartment);
            this.panelControls.Controls.Add(this.lblDepartment);
            this.panelControls.Controls.Add(this.txtBudget);
            this.panelControls.Controls.Add(this.lblBudget);
            this.panelControls.Controls.Add(this.cmbManager);
            this.panelControls.Controls.Add(this.lblManager);
            this.panelControls.Controls.Add(this.dtpEndDate);
            this.panelControls.Controls.Add(this.lblEndDate);
            this.panelControls.Controls.Add(this.dtpStartDate);
            this.panelControls.Controls.Add(this.lblStartDate);
            this.panelControls.Controls.Add(this.txtProjectName);
            this.panelControls.Controls.Add(this.lblProjectName);
            this.panelControls.Location = new System.Drawing.Point(12, 335);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(776, 103);
            this.panelControls.TabIndex = 6;
            this.panelControls.Visible = false;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(3, 9);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(77, 13);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(86, 6);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(200, 20);
            this.txtProjectName.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(292, 9);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Start Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(356, 6);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(100, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(462, 9);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(523, 6);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(100, 20);
            this.dtpEndDate.TabIndex = 5;
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Location = new System.Drawing.Point(3, 35);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(52, 13);
            this.lblManager.TabIndex = 6;
            this.lblManager.Text = "Manager:";
            // 
            // cmbManager
            // 
            this.cmbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManager.FormattingEnabled = true;
            this.cmbManager.Location = new System.Drawing.Point(86, 32);
            this.cmbManager.Name = "cmbManager";
            this.cmbManager.Size = new System.Drawing.Size(200, 21);
            this.cmbManager.TabIndex = 7;
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.Location = new System.Drawing.Point(292, 35);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(44, 13);
            this.lblBudget.TabIndex = 8;
            this.lblBudget.Text = "Budget:";
            // 
            // txtBudget
            // 
            this.txtBudget.Location = new System.Drawing.Point(342, 32);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(114, 20);
            this.txtBudget.TabIndex = 9;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(462, 35);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 13);
            this.lblDepartment.TabIndex = 10;
            this.lblDepartment.Text = "Department:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(533, 32);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(150, 21);
            this.cmbDepartment.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(614, 74);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(695, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProjectsForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewProjects);
            this.Name = "ProjectsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Projects";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewProjects;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.ComboBox cmbManager;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private int editingProjectId = -1;
        private bool isAddMode = false;

        private void LoadData()
        {
            projectsTable = new DataTable();
            using (var conn = dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        p.project_id, 
                        p.project_name, 
                        p.start_date, 
                        p.end_date, 
                        p.manager_id, 
                        CONCAT(u.first_name, ' ', u.last_name) AS manager_name,
                        p.budget, 
                        p.department_id, 
                        d.department_name
                    FROM projects p
                    LEFT JOIN users u ON p.manager_id = u.user_id
                    LEFT JOIN departments d ON p.department_id = d.department_id";
                using (var cmd = new MySqlCommand(query, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(projectsTable);
                }
            }

            dataGridViewProjects.DataSource = projectsTable;
            dataGridViewProjects.Columns["project_id"].Visible = false;
            dataGridViewProjects.Columns["manager_id"].Visible = false;
            dataGridViewProjects.Columns["department_id"].Visible = false;

            LoadManagers();
            LoadDepartments();
        }

        private void LoadManagers()
        {
            cmbManager.Items.Clear();
            using (var conn = dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT user_id, CONCAT(first_name, ' ', last_name) AS full_name FROM users";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbManager.Items.Add(new
                        {
                            Text = reader.GetString("full_name"),
                            Value = reader.GetInt32("user_id")
                        });
                    }
                }
            }
            cmbManager.DisplayMember = "Text";
            cmbManager.ValueMember = "Value";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddMode = true;
            editingProjectId = -1;

            txtProjectName.Text = "";
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(3);
            cmbManager.SelectedIndex = -1;
            txtBudget.Text = "";
            cmbDepartment.SelectedIndex = -1;

            panelControls.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewProjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a project to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isAddMode = false;
            DataGridViewRow row = dataGridViewProjects.SelectedRows[0];
            editingProjectId = Convert.ToInt32(row.Cells["project_id"].Value);

            txtProjectName.Text = row.Cells["project_name"].Value.ToString();
            dtpStartDate.Value = Convert.ToDateTime(row.Cells["start_date"].Value);
            dtpEndDate.Value = Convert.ToDateTime(row.Cells["end_date"].Value);
            txtBudget.Text = row.Cells["budget"].Value.ToString();

            int managerId = Convert.ToInt32(row.Cells["manager_id"].Value);
            for (int i = 0; i < cmbManager.Items.Count; i++)
            {
                dynamic item = cmbManager.Items[i];
                if (item.Value == managerId)
                {
                    cmbManager.SelectedIndex = i;
                    break;
                }
            }

            int departmentId = Convert.ToInt32(row.Cells["department_id"].Value);
            for (int i = 0; i < cmbDepartment.Items.Count; i++)
            {
                dynamic item = cmbDepartment.Items[i];
                if (item.Value == departmentId)
                {
                    cmbDepartment.SelectedIndex = i;
                    break;
                }
            }

            panelControls.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a project to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this project?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridViewProjects.SelectedRows[0];
                int projectId = Convert.ToInt32(row.Cells["project_id"].Value);

                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM projects WHERE project_id = @project_id";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@project_id", projectId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LogAction("Delete", projectId, $"Deleted project with ID {projectId}");
                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text) ||
                cmbManager.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtBudget.Text) ||
                cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double budget;
            if (!double.TryParse(txtBudget.Text, out budget))
            {
                MessageBox.Show("Budget must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string projectName = txtProjectName.Text;
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            dynamic selectedManager = cmbManager.SelectedItem;
            int managerId = selectedManager.Value;

            dynamic selectedDepartment = cmbDepartment.SelectedItem;
            int departmentId = selectedDepartment.Value;

            using (var conn = dbConnection.GetConnection())
            {
                conn.Open();
                if (isAddMode)
                {
                    string insertQuery = @"
                        INSERT INTO projects (project_name, start_date, end_date, manager_id, budget, department_id)
                        VALUES (@project_name, @start_date, @end_date, @manager_id, @budget, @department_id)";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@project_name", projectName);
                        cmd.Parameters.AddWithValue("@start_date", startDate);
                        cmd.Parameters.AddWithValue("@end_date", endDate);
                        cmd.Parameters.AddWithValue("@manager_id", managerId);
                        cmd.Parameters.AddWithValue("@budget", budget);
                        cmd.Parameters.AddWithValue("@department_id", departmentId);
                        cmd.ExecuteNonQuery();

                        // Get the new project's ID
                        long newProjectId = cmd.LastInsertedId;
                        LogAction("Add", (int)newProjectId, $"Added project '{projectName}'");
                    }
                }
                else
                {
                    string updateQuery = @"
                        UPDATE projects
                        SET project_name = @project_name,
                            start_date = @start_date,
                            end_date = @end_date,
                            manager_id = @manager_id,
                            budget = @budget,
                            department_id = @department_id
                        WHERE project_id = @project_id";
                    using (var cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@project_name", projectName);
                        cmd.Parameters.AddWithValue("@start_date", startDate);
                        cmd.Parameters.AddWithValue("@end_date", endDate);
                        cmd.Parameters.AddWithValue("@manager_id", managerId);
                        cmd.Parameters.AddWithValue("@budget", budget);
                        cmd.Parameters.AddWithValue("@department_id", departmentId);
                        cmd.Parameters.AddWithValue("@project_id", editingProjectId);
                        cmd.ExecuteNonQuery();

                        LogAction("Edit", editingProjectId, $"Edited project '{projectName}' (ID {editingProjectId})");
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
                    cmd.Parameters.AddWithValue("@table_name", "project");
                    cmd.Parameters.AddWithValue("@record_id", (object?)recordId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@details", details);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}