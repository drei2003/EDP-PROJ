using System.Data;

namespace TaskManagementSystem
{
    public partial class TaskAssignmentsForm : Form
    {
        private DataTable assignmentsTable;

        public TaskAssignmentsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.dataGridViewAssignments = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            this.lblTask = new System.Windows.Forms.Label();
            this.cmbTask = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblAssignedDate = new System.Windows.Forms.Label();
            this.dtpAssignedDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssignments)).BeginInit();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAssignments
            // 
            this.dataGridViewAssignments.AllowUserToAddRows = false;
            this.dataGridViewAssignments.AllowUserToDeleteRows = false;
            this.dataGridViewAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAssignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssignments.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewAssignments.MultiSelect = false;
            this.dataGridViewAssignments.Name = "dataGridViewAssignments";
            this.dataGridViewAssignments.ReadOnly = true;
            this.dataGridViewAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAssignments.Size = new System.Drawing.Size(776, 250);
            this.dataGridViewAssignments.TabIndex = 0;
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
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(93, 306);
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
            this.lblTitle.Size = new System.Drawing.Size(246, 24);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Manage Task Assignments";
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.Controls.Add(this.btnCancel);
            this.panelControls.Controls.Add(this.btnSave);
            this.panelControls.Controls.Add(this.dtpAssignedDate);
            this.panelControls.Controls.Add(this.lblAssignedDate);
            this.panelControls.Controls.Add(this.cmbUser);
            this.panelControls.Controls.Add(this.lblUser);
            this.panelControls.Controls.Add(this.cmbTask);
            this.panelControls.Controls.Add(this.lblTask);
            this.panelControls.Location = new System.Drawing.Point(12, 335);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(776, 103);
            this.panelControls.TabIndex = 6;
            this.panelControls.Visible = false;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(3, 9);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(34, 13);
            this.lblTask.TabIndex = 0;
            this.lblTask.Text = "Task:";
            // 
            // cmbTask
            // 
            this.cmbTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTask.FormattingEnabled = true;
            this.cmbTask.Location = new System.Drawing.Point(43, 6);
            this.cmbTask.Name = "cmbTask";
            this.cmbTask.Size = new System.Drawing.Size(200, 21);
            this.cmbTask.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(249, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User:";
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(287, 6);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(200, 21);
            this.cmbUser.TabIndex = 3;
            // 
            // lblAssignedDate
            // 
            this.lblAssignedDate.AutoSize = true;
            this.lblAssignedDate.Location = new System.Drawing.Point(493, 9);
            this.lblAssignedDate.Name = "lblAssignedDate";
            this.lblAssignedDate.Size = new System.Drawing.Size(79, 13);
            this.lblAssignedDate.TabIndex = 4;
            this.lblAssignedDate.Text = "Assigned Date:";
            // 
            // dtpAssignedDate
            // 
            this.dtpAssignedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAssignedDate.Location = new System.Drawing.Point(578, 6);
            this.dtpAssignedDate.Name = "dtpAssignedDate";
            this.dtpAssignedDate.Size = new System.Drawing.Size(100, 20);
            this.dtpAssignedDate.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(614, 74);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(695, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TaskAssignmentsForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewAssignments);
            this.Name = "TaskAssignmentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Task Assignments";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssignments)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewAssignments;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.ComboBox cmbTask;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblAssignedDate;
        private System.Windows.Forms.DateTimePicker dtpAssignedDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private int editingAssignmentId = -1;
        private bool isAddMode = false;

        private void LoadData()
        {
            // In a real application, this would load data from a database
            // For this example, we'll create sample data
            assignmentsTable = new DataTable();
            assignmentsTable.Columns.Add("assignment_id", typeof(int));
            assignmentsTable.Columns.Add("task_id", typeof(int));
            assignmentsTable.Columns.Add("task_name", typeof(string));
            assignmentsTable.Columns.Add("user_id", typeof(int));
            assignmentsTable.Columns.Add("user_name", typeof(string));
            assignmentsTable.Columns.Add("assigned_date", typeof(DateTime));

            // Add sample data
            assignmentsTable.Rows.Add(1, 1, "Design database schema", 3, "Bob Johnson", DateTime.Now.AddDays(-5));
            assignmentsTable.Rows.Add(2, 2, "Create wireframes", 2, "Jane Smith", DateTime.Now.AddDays(-7));
            assignmentsTable.Rows.Add(3, 3, "Implement login system", 3, "Bob Johnson", DateTime.Now.AddDays(-2));

            // Set up the DataGridView
            dataGridViewAssignments.DataSource = assignmentsTable;
            dataGridViewAssignments.Columns["assignment_id"].Visible = false;
            dataGridViewAssignments.Columns["task_id"].Visible = false;
            dataGridViewAssignments.Columns["user_id"].Visible = false;

            // Load tasks and users for combo boxes
            LoadTasks();
            LoadUsers();
        }

        private void LoadTasks()
        {
            // In a real application, this would load from a database
            cmbTask.Items.Clear();
            cmbTask.DisplayMember = "Text";
            cmbTask.ValueMember = "Value";

            var items = new[] {
                new { Text = "Design database schema", Value = 1 },
                new { Text = "Create wireframes", Value = 2 },
                new { Text = "Implement login system", Value = 3 },
                new { Text = "Create user interface", Value = 4 },
                new { Text = "Write unit tests", Value = 5 }
            };

            foreach (var item in items)
            {
                cmbTask.Items.Add(item);
            }
        }

        private void LoadUsers()
        {
            // In a real application, this would load from a database
            cmbUser.Items.Clear();
            cmbUser.DisplayMember = "Text";
            cmbUser.ValueMember = "Value";

            var items = new[] {
                new { Text = "John Doe", Value = 1 },
                new { Text = "Jane Smith", Value = 2 },
                new { Text = "Bob Johnson", Value = 3 }
            };

            foreach (var item in items)
            {
                cmbUser.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddMode = true;
            editingAssignmentId = -1;

            // Clear form fields
            cmbTask.SelectedIndex = -1;
            cmbUser.SelectedIndex = -1;
            dtpAssignedDate.Value = DateTime.Now;

            // Show the panel
            panelControls.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewAssignments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an assignment to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this assignment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridViewAssignments.SelectedRows[0];
                int assignmentId = Convert.ToInt32(row.Cells["assignment_id"].Value);

                // In a real application, this would delete from the database
                // For this example, we'll just remove from the DataTable
                foreach (DataRow dataRow in assignmentsTable.Rows)
                {
                    if (Convert.ToInt32(dataRow["assignment_id"]) == assignmentId)
                    {
                        dataRow.Delete();
                        break;
                    }
                }

                assignmentsTable.AcceptChanges();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input
            if (cmbTask.SelectedIndex == -1 ||
                cmbUser.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a task and user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get values from form
            dynamic selectedTask = cmbTask.SelectedItem;
            int taskId = selectedTask.Value;
            string taskName = selectedTask.Text;

            dynamic selectedUser = cmbUser.SelectedItem;
            int userId = selectedUser.Value;
            string userName = selectedUser.Text;

            DateTime assignedDate = dtpAssignedDate.Value;

            if (isAddMode)
            {
                // In a real application, this would insert into the database
                // For this example, we'll just add to the DataTable
                int newId = 1;
                if (assignmentsTable.Rows.Count > 0)
                {
                    newId = assignmentsTable.AsEnumerable().Max(row => row.Field<int>("assignment_id")) + 1;
                }

                assignmentsTable.Rows.Add(newId, taskId, taskName, userId, userName, assignedDate);
            }
            else
            {
                // In a real application, this would update the database
                // For this example, we'll just update the DataTable
                foreach (DataRow row in assignmentsTable.Rows)
                {
                    if (Convert.ToInt32(row["assignment_id"]) == editingAssignmentId)
                    {
                        row["task_id"] = taskId;
                        row["task_name"] = taskName;
                        row["user_id"] = userId;
                        row["user_name"] = userName;
                        row["assigned_date"] = assignedDate;
                        break;
                    }
                }
            }

            assignmentsTable.AcceptChanges();
            panelControls.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelControls.Visible = false;
        }
    }
}