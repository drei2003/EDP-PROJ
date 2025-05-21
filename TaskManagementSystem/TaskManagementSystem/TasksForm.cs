using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace TaskManagementSystem
{
    public partial class TasksForm : Form
    {
        private DataTable tasksTable;
        private DatabaseConnection dbConnection = new DatabaseConnection();

        public TasksForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lblAssignedTo = new System.Windows.Forms.Label();
            this.cmbAssignedTo = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.AllowUserToAddRows = false;
            this.dataGridViewTasks.AllowUserToDeleteRows = false;
            this.dataGridViewTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewTasks.MultiSelect = false;
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.ReadOnly = true;
            this.dataGridViewTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTasks.Size = new System.Drawing.Size(776, 250);
            this.dataGridViewTasks.TabIndex = 0;
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
            this.lblTitle.Size = new System.Drawing.Size(147, 24);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Manage Tasks";
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.Controls.Add(this.btnCancel);
            this.panelControls.Controls.Add(this.btnSave);
            this.panelControls.Controls.Add(this.dtpDueDate);
            this.panelControls.Controls.Add(this.lblDueDate);
            this.panelControls.Controls.Add(this.cmbStatus);
            this.panelControls.Controls.Add(this.lblStatus);
            this.panelControls.Controls.Add(this.cmbAssignedTo);
            this.panelControls.Controls.Add(this.lblAssignedTo);
            this.panelControls.Controls.Add(this.cmbProject);
            this.panelControls.Controls.Add(this.lblProject);
            this.panelControls.Controls.Add(this.txtTaskName);
            this.panelControls.Controls.Add(this.lblTaskName);
            this.panelControls.Location = new System.Drawing.Point(12, 335);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(776, 103);
            this.panelControls.TabIndex = 6;
            this.panelControls.Visible = false;
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(3, 9);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(65, 13);
            this.lblTaskName.TabIndex = 0;
            this.lblTaskName.Text = "Task Name:";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(74, 6);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(200, 20);
            this.txtTaskName.TabIndex = 1;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(280, 9);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(43, 13);
            this.lblProject.TabIndex = 2;
            this.lblProject.Text = "Project:";
            // 
            // cmbProject
            // 
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(329, 6);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(150, 21);
            this.cmbProject.TabIndex = 3;
            // 
            // lblAssignedTo
            // 
            this.lblAssignedTo.AutoSize = true;
            this.lblAssignedTo.Location = new System.Drawing.Point(485, 9);
            this.lblAssignedTo.Name = "lblAssignedTo";
            this.lblAssignedTo.Size = new System.Drawing.Size(69, 13);
            this.lblAssignedTo.TabIndex = 4;
            this.lblAssignedTo.Text = "Assigned To:";
            // 
            // cmbAssignedTo
            // 
            this.cmbAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignedTo.FormattingEnabled = true;
            this.cmbAssignedTo.Location = new System.Drawing.Point(560, 6);
            this.cmbAssignedTo.Name = "cmbAssignedTo";
            this.cmbAssignedTo.Size = new System.Drawing.Size(150, 21);
            this.cmbAssignedTo.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 36);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(74, 33);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 7;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(280, 36);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(56, 13);
            this.lblDueDate.TabIndex = 8;
            this.lblDueDate.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(342, 33);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(137, 20);
            this.dtpDueDate.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(614, 74);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(695, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TasksForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewTasks);
            this.Name = "TasksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Label lblAssignedTo;
        private System.Windows.Forms.ComboBox cmbAssignedTo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private int editingTaskId = -1;
        private bool isAddMode = false;

        private void LoadData()
        {
            try
            {
                tasksTable = new DataTable();
                using (var conn = dbConnection.GetConnection())
                using (var cmd = new MySqlCommand(@"
                    SELECT 
                        t.task_id, 
                        t.task_name, 
                        t.project_id, 
                        t.assigned_to, 
                        CONCAT(u.first_name, ' ', u.last_name) AS assigned_to_name,
                        t.status, 
                        t.due_date
                    FROM tasks t
                    LEFT JOIN users u ON t.assigned_to = u.user_id
                ", conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(tasksTable);
                }

                dataGridViewTasks.DataSource = tasksTable;
                dataGridViewTasks.Columns["task_id"].Visible = false;
                dataGridViewTasks.Columns["project_id"].Visible = false;
                dataGridViewTasks.Columns["assigned_to"].Visible = false;

                // Show the assigned_to_name column with a user-friendly header
                if (dataGridViewTasks.Columns.Contains("assigned_to_name"))
                {
                    dataGridViewTasks.Columns["assigned_to_name"].HeaderText = "Assigned To";
                    dataGridViewTasks.Columns["assigned_to_name"].Visible = true;
                }

                LoadProjects();
                LoadUsers();
                LoadStatuses();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Could not connect to the database. Please check your server settings and network connection.\n\n" +
                    "Details: " + ex.Message,
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                dataGridViewTasks.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                dataGridViewTasks.DataSource = null;
            }
        }

        private void LoadProjects()
        {
            cmbProject.Items.Clear();
            cmbProject.DisplayMember = "Text";
            cmbProject.ValueMember = "Value";

            try
            {
                using (var conn = dbConnection.GetConnection())
                using (var cmd = new MySqlCommand("SELECT project_id, project_name FROM projects", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbProject.Items.Add(new
                            {
                                Text = reader["project_name"].ToString(),
                                Value = Convert.ToInt32(reader["project_id"])
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Could not load projects from the database. Please check your server settings and network connection.\n\n" +
                    "Details: " + ex.Message,
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadUsers()
        {
            cmbAssignedTo.Items.Clear();
            cmbAssignedTo.DisplayMember = "Text";
            cmbAssignedTo.ValueMember = "Value";

            try
            {
                using (var conn = dbConnection.GetConnection())
                using (var cmd = new MySqlCommand("SELECT user_id, first_name, last_name FROM users", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbAssignedTo.Items.Add(new
                            {
                                Text = $"{reader["first_name"]} {reader["last_name"]}",
                                Value = Convert.ToInt32(reader["user_id"])
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Could not load users from the database. Please check your server settings and network connection.\n\n" +
                    "Details: " + ex.Message,
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("In Progress");
            cmbStatus.Items.Add("Completed");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddMode = true;
            editingTaskId = -1;
            txtTaskName.Text = "";
            cmbProject.SelectedIndex = -1;
            cmbAssignedTo.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            dtpDueDate.Value = DateTime.Now.AddDays(7);
            panelControls.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isAddMode = false;
            DataGridViewRow row = dataGridViewTasks.SelectedRows[0];
            editingTaskId = Convert.ToInt32(row.Cells["task_id"].Value);

            txtTaskName.Text = row.Cells["task_name"].Value?.ToString() ?? "";

            int projectId = row.Cells["project_id"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["project_id"].Value) : -1;
            for (int i = 0; i < cmbProject.Items.Count; i++)
            {
                dynamic item = cmbProject.Items[i];
                if (item.Value == projectId)
                {
                    cmbProject.SelectedIndex = i;
                    break;
                }
            }

            int assignedTo = row.Cells["assigned_to"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["assigned_to"].Value) : -1;
            for (int i = 0; i < cmbAssignedTo.Items.Count; i++)
            {
                dynamic item = cmbAssignedTo.Items[i];
                if (item.Value == assignedTo)
                {
                    cmbAssignedTo.SelectedIndex = i;
                    break;
                }
            }

            string status = row.Cells["status"].Value?.ToString() ?? "";
            cmbStatus.SelectedItem = status;

            if (row.Cells["due_date"].Value != DBNull.Value)
                dtpDueDate.Value = Convert.ToDateTime(row.Cells["due_date"].Value);
            else
                dtpDueDate.Value = DateTime.Now.AddDays(7);

            panelControls.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridViewTasks.SelectedRows[0];
                int taskId = Convert.ToInt32(row.Cells["task_id"].Value);

                try
                {
                    using (var conn = dbConnection.GetConnection())
                    using (var cmd = new MySqlCommand("DELETE FROM tasks WHERE task_id = @task_id", conn))
                    {
                        cmd.Parameters.AddWithValue("@task_id", taskId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    LogAction("Delete", taskId, null, $"Deleted task with ID {taskId}");
                    LoadData();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(
                        "Could not delete the task. Please check your server settings and network connection.\n\n" +
                        "Details: " + ex.Message,
                        "Database Connection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "An unexpected error occurred:\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskName.Text) ||
                cmbProject.SelectedIndex == -1 ||
                cmbAssignedTo.SelectedIndex == -1 ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string taskName = txtTaskName.Text;
            dynamic selectedProject = cmbProject.SelectedItem;
            int projectId = selectedProject.Value;
            dynamic selectedUser = cmbAssignedTo.SelectedItem;
            int assignedTo = selectedUser.Value;
            string status = cmbStatus.SelectedItem.ToString();
            DateTime dueDate = dtpDueDate.Value;

            try
            {
                if (isAddMode)
                {
                    using (var conn = dbConnection.GetConnection())
                    using (var cmd = new MySqlCommand(@"
                        INSERT INTO tasks (task_name, project_id, assigned_to, status, due_date)
                        VALUES (@task_name, @project_id, @assigned_to, @status, @due_date)
                    ", conn))
                    {
                        cmd.Parameters.AddWithValue("@task_name", taskName);
                        cmd.Parameters.AddWithValue("@project_id", projectId);
                        cmd.Parameters.AddWithValue("@assigned_to", assignedTo);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@due_date", dueDate.Date);
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Get the new task's ID
                        long newTaskId = cmd.LastInsertedId;
                        LogAction("Add", (int)newTaskId, projectId, $"Added task '{taskName}' to project ID {projectId}");
                    }
                }
                else
                {
                    using (var conn = dbConnection.GetConnection())
                    using (var cmd = new MySqlCommand(@"
                        UPDATE tasks
                        SET task_name = @task_name,
                            project_id = @project_id,
                            assigned_to = @assigned_to,
                            status = @status,
                            due_date = @due_date
                        WHERE task_id = @task_id
                    ", conn))
                    {
                        cmd.Parameters.AddWithValue("@task_name", taskName);
                        cmd.Parameters.AddWithValue("@project_id", projectId);
                        cmd.Parameters.AddWithValue("@assigned_to", assignedTo);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@due_date", dueDate.Date);
                        cmd.Parameters.AddWithValue("@task_id", editingTaskId);
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        LogAction("Edit", editingTaskId, projectId, $"Edited task '{taskName}' (ID {editingTaskId})");
                    }
                }

                LoadData();
                panelControls.Visible = false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Could not save the task. Please check your server settings and network connection.\n\n" +
                    "Details: " + ex.Message,
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelControls.Visible = false;
        }

        private void LogAction(string action, int? recordId, int? projectId, string details)
        {
            // Optionally, replace '1' with the actual current user ID if available
            int? userId = 1;
            using (var conn = dbConnection.GetConnection())
            {
                conn.Open();
                string logQuery = @"
                    INSERT INTO logs (user_id, action, table_name, record_id, project_id, details, log_time)
                    VALUES (@user_id, @action, @table_name, @record_id, @project_id, @details, NOW())";
                using (var cmd = new MySqlCommand(logQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", (object?)userId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@table_name", "task");
                    cmd.Parameters.AddWithValue("@record_id", (object?)recordId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@project_id", (object?)projectId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@details", details);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}