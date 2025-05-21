using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;

namespace TaskManagementSystem
{
    public partial class DashboardMainForm : Form
    {
        // Sample data tables
        private DataTable usersTable;
        private DataTable tasksTable;
        private DataTable projectsTable;
        private System.ComponentModel.IContainer components;
        private DataTable logsTable;
        private readonly DatabaseConnection dbConnection = new DatabaseConnection();

        public DashboardMainForm()
        {
            InitializeComponent();
            LoadAllDataFromDatabase();
            UpdateDashboard();
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            managementToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            tasksToolStripMenuItem = new ToolStripMenuItem();
            projectsToolStripMenuItem = new ToolStripMenuItem();
            departmentsToolStripMenuItem = new ToolStripMenuItem();
            rolesToolStripMenuItem = new ToolStripMenuItem();
            taskAssignmentsToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            var exportToExcelToolStripMenuItem = new ToolStripMenuItem();
            exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            exportToExcelToolStripMenuItem.Size = new Size(180, 22);
            exportToExcelToolStripMenuItem.Text = "Export to Excel";
            exportToExcelToolStripMenuItem.Click += exportToExcelToolStripMenuItem_Click;
            reportsToolStripMenuItem.DropDownItems.Add(exportToExcelToolStripMenuItem);
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            panelHeader = new Panel();
            lblDashboardTitle = new Label();
            lblCurrentDate = new Label();
            panelStats = new Panel();
            tableLayoutPanelStats = new TableLayoutPanel();
            panelUsers = new Panel();
            lblUserCount = new Label();
            lblUsersTitle = new Label();
            panelTasks = new Panel();
            lblTaskCount = new Label();
            lblTasksTitle = new Label();
            panelProjects = new Panel();
            lblProjectCount = new Label();
            lblProjectsTitle = new Label();
            panelDepartments = new Panel();
            lblDepartmentCount = new Label();
            lblDepartmentsTitle = new Label();
            panelTaskStatus = new Panel();
            panelTaskStatusChart = new Panel();
            lblTaskStatusTitle = new Label();
            panelRecentActivity = new Panel();
            dataGridViewRecentActivity = new DataGridView();
            lblRecentActivityTitle = new Label();
            panelQuickActions = new Panel();
            btnRefreshDashboard = new Button();
            btnAddTask = new Button();
            btnAddProject = new Button();
            btnAddUser = new Button();
            lblQuickActionsTitle = new Label();
            panelProjectProgress = new Panel();
            dataGridViewProjects = new DataGridView();
            lblProjectProgressTitle = new Label();
            timerRefresh = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelHeader.SuspendLayout();
            panelStats.SuspendLayout();
            tableLayoutPanelStats.SuspendLayout();
            panelUsers.SuspendLayout();
            panelTasks.SuspendLayout();
            panelProjects.SuspendLayout();
            panelDepartments.SuspendLayout();
            panelTaskStatus.SuspendLayout();
            panelRecentActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecentActivity).BeginInit();
            panelQuickActions.SuspendLayout();
            panelProjectProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, managementToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1370, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // managementToolStripMenuItem
            // 
            managementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usersToolStripMenuItem, tasksToolStripMenuItem, projectsToolStripMenuItem, departmentsToolStripMenuItem, rolesToolStripMenuItem, taskAssignmentsToolStripMenuItem });
            managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            managementToolStripMenuItem.Size = new Size(90, 20);
            managementToolStripMenuItem.Text = "Management";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(168, 22);
            usersToolStripMenuItem.Text = "Users";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;
            // 
            // tasksToolStripMenuItem
            // 
            tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            tasksToolStripMenuItem.Size = new Size(168, 22);
            tasksToolStripMenuItem.Text = "Tasks";
            tasksToolStripMenuItem.Click += tasksToolStripMenuItem_Click;
            // 
            // projectsToolStripMenuItem
            // 
            projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            projectsToolStripMenuItem.Size = new Size(168, 22);
            projectsToolStripMenuItem.Text = "Projects";
            projectsToolStripMenuItem.Click += projectsToolStripMenuItem_Click;
            // 
            // departmentsToolStripMenuItem
            // 
            departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            departmentsToolStripMenuItem.Size = new Size(168, 22);
            departmentsToolStripMenuItem.Text = "Departments";
            departmentsToolStripMenuItem.Click += departmentsToolStripMenuItem_Click;
            // 
            // rolesToolStripMenuItem
            // 
            rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            rolesToolStripMenuItem.Size = new Size(168, 22);
            rolesToolStripMenuItem.Text = "Roles";
            rolesToolStripMenuItem.Click += rolesToolStripMenuItem_Click;
            // 
            // taskAssignmentsToolStripMenuItem
            // 
            taskAssignmentsToolStripMenuItem.Name = "taskAssignmentsToolStripMenuItem";
            taskAssignmentsToolStripMenuItem.Size = new Size(168, 22);
            taskAssignmentsToolStripMenuItem.Text = "Task Assignments";
            taskAssignmentsToolStripMenuItem.Click += taskAssignmentsToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logsToolStripMenuItem, exportToExcelToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(59, 20);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // logsToolStripMenuItem
            // 
            logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            logsToolStripMenuItem.Size = new Size(99, 22);
            logsToolStripMenuItem.Text = "Logs";
            logsToolStripMenuItem.Click += logsToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 727);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1370, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 17);
            statusLabel.Text = "Ready";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(0, 122, 204);
            panelHeader.Controls.Add(lblDashboardTitle);
            panelHeader.Controls.Add(lblCurrentDate);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.ForeColor = Color.White;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Margin = new Padding(4, 3, 4, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1370, 69);
            panelHeader.TabIndex = 2;
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardTitle.Location = new Point(14, 16);
            lblDashboardTitle.Margin = new Padding(4, 0, 4, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(352, 32);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Task Management Dashboard";
            // 
            // lblCurrentDate
            // 
            lblCurrentDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrentDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentDate.Location = new Point(1020, 16);
            lblCurrentDate.Margin = new Padding(4, 0, 4, 0);
            lblCurrentDate.Name = "lblCurrentDate";
            lblCurrentDate.Size = new Size(336, 37);
            lblCurrentDate.TabIndex = 1;
            lblCurrentDate.Text = "Monday, January 1, 2023";
            lblCurrentDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelStats
            // 
            panelStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelStats.Controls.Add(tableLayoutPanelStats);
            panelStats.Location = new Point(14, 104);
            panelStats.Margin = new Padding(4, 3, 4, 3);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(1353, 115);
            panelStats.TabIndex = 3;
            // 
            // tableLayoutPanelStats
            // 
            tableLayoutPanelStats.ColumnCount = 4;
            tableLayoutPanelStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelStats.Controls.Add(panelUsers, 0, 0);
            tableLayoutPanelStats.Controls.Add(panelTasks, 1, 0);
            tableLayoutPanelStats.Controls.Add(panelProjects, 2, 0);
            tableLayoutPanelStats.Controls.Add(panelDepartments, 3, 0);
            tableLayoutPanelStats.Dock = DockStyle.Fill;
            tableLayoutPanelStats.Location = new Point(0, 0);
            tableLayoutPanelStats.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanelStats.Name = "tableLayoutPanelStats";
            tableLayoutPanelStats.RowCount = 1;
            tableLayoutPanelStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelStats.Size = new Size(1353, 115);
            tableLayoutPanelStats.TabIndex = 0;
            tableLayoutPanelStats.Paint += tableLayoutPanelStats_Paint;
            // 
            // panelUsers
            // 
            panelUsers.BackColor = Color.FromArgb(41, 128, 185);
            panelUsers.Controls.Add(lblUserCount);
            panelUsers.Controls.Add(lblUsersTitle);
            panelUsers.Dock = DockStyle.Fill;
            panelUsers.ForeColor = Color.White;
            panelUsers.Location = new Point(12, 12);
            panelUsers.Margin = new Padding(12);
            panelUsers.Name = "panelUsers";
            panelUsers.Size = new Size(314, 91);
            panelUsers.TabIndex = 0;
            // 
            // lblUserCount
            // 
            lblUserCount.Dock = DockStyle.Fill;
            lblUserCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserCount.Location = new Point(0, 29);
            lblUserCount.Margin = new Padding(4, 0, 4, 0);
            lblUserCount.Name = "lblUserCount";
            lblUserCount.Size = new Size(314, 62);
            lblUserCount.TabIndex = 1;
            lblUserCount.Text = "0";
            lblUserCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsersTitle
            // 
            lblUsersTitle.Dock = DockStyle.Top;
            lblUsersTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsersTitle.Location = new Point(0, 0);
            lblUsersTitle.Margin = new Padding(4, 0, 4, 0);
            lblUsersTitle.Name = "lblUsersTitle";
            lblUsersTitle.Size = new Size(314, 29);
            lblUsersTitle.TabIndex = 0;
            lblUsersTitle.Text = "Total Users";
            lblUsersTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblUsersTitle.Click += lblUsersTitle_Click;
            // 
            // panelTasks
            // 
            panelTasks.BackColor = Color.FromArgb(46, 204, 113);
            panelTasks.Controls.Add(lblTaskCount);
            panelTasks.Controls.Add(lblTasksTitle);
            panelTasks.Dock = DockStyle.Fill;
            panelTasks.ForeColor = Color.White;
            panelTasks.Location = new Point(350, 12);
            panelTasks.Margin = new Padding(12);
            panelTasks.Name = "panelTasks";
            panelTasks.Size = new Size(314, 91);
            panelTasks.TabIndex = 1;
            // 
            // lblTaskCount
            // 
            lblTaskCount.Dock = DockStyle.Fill;
            lblTaskCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTaskCount.Location = new Point(0, 29);
            lblTaskCount.Margin = new Padding(4, 0, 4, 0);
            lblTaskCount.Name = "lblTaskCount";
            lblTaskCount.Size = new Size(314, 62);
            lblTaskCount.TabIndex = 1;
            lblTaskCount.Text = "0";
            lblTaskCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTasksTitle
            // 
            lblTasksTitle.Dock = DockStyle.Top;
            lblTasksTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTasksTitle.Location = new Point(0, 0);
            lblTasksTitle.Margin = new Padding(4, 0, 4, 0);
            lblTasksTitle.Name = "lblTasksTitle";
            lblTasksTitle.Size = new Size(314, 29);
            lblTasksTitle.TabIndex = 0;
            lblTasksTitle.Text = "Active Tasks";
            lblTasksTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelProjects
            // 
            panelProjects.BackColor = Color.FromArgb(230, 126, 34);
            panelProjects.Controls.Add(lblProjectCount);
            panelProjects.Controls.Add(lblProjectsTitle);
            panelProjects.Dock = DockStyle.Fill;
            panelProjects.ForeColor = Color.White;
            panelProjects.Location = new Point(688, 12);
            panelProjects.Margin = new Padding(12);
            panelProjects.Name = "panelProjects";
            panelProjects.Size = new Size(314, 91);
            panelProjects.TabIndex = 2;
            // 
            // lblProjectCount
            // 
            lblProjectCount.Dock = DockStyle.Fill;
            lblProjectCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProjectCount.Location = new Point(0, 29);
            lblProjectCount.Margin = new Padding(4, 0, 4, 0);
            lblProjectCount.Name = "lblProjectCount";
            lblProjectCount.Size = new Size(314, 62);
            lblProjectCount.TabIndex = 1;
            lblProjectCount.Text = "0";
            lblProjectCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProjectsTitle
            // 
            lblProjectsTitle.Dock = DockStyle.Top;
            lblProjectsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectsTitle.Location = new Point(0, 0);
            lblProjectsTitle.Margin = new Padding(4, 0, 4, 0);
            lblProjectsTitle.Name = "lblProjectsTitle";
            lblProjectsTitle.Size = new Size(314, 29);
            lblProjectsTitle.TabIndex = 0;
            lblProjectsTitle.Text = "Active Projects";
            lblProjectsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDepartments
            // 
            panelDepartments.BackColor = Color.FromArgb(155, 89, 182);
            panelDepartments.Controls.Add(lblDepartmentCount);
            panelDepartments.Controls.Add(lblDepartmentsTitle);
            panelDepartments.Dock = DockStyle.Fill;
            panelDepartments.ForeColor = Color.White;
            panelDepartments.Location = new Point(1026, 12);
            panelDepartments.Margin = new Padding(12);
            panelDepartments.Name = "panelDepartments";
            panelDepartments.Size = new Size(315, 91);
            panelDepartments.TabIndex = 3;
            // 
            // lblDepartmentCount
            // 
            lblDepartmentCount.Dock = DockStyle.Fill;
            lblDepartmentCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartmentCount.Location = new Point(0, 29);
            lblDepartmentCount.Margin = new Padding(4, 0, 4, 0);
            lblDepartmentCount.Name = "lblDepartmentCount";
            lblDepartmentCount.Size = new Size(315, 62);
            lblDepartmentCount.TabIndex = 1;
            lblDepartmentCount.Text = "0";
            lblDepartmentCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDepartmentsTitle
            // 
            lblDepartmentsTitle.Dock = DockStyle.Top;
            lblDepartmentsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDepartmentsTitle.Location = new Point(0, 0);
            lblDepartmentsTitle.Margin = new Padding(4, 0, 4, 0);
            lblDepartmentsTitle.Name = "lblDepartmentsTitle";
            lblDepartmentsTitle.Size = new Size(315, 29);
            lblDepartmentsTitle.TabIndex = 0;
            lblDepartmentsTitle.Text = "Departments";
            lblDepartmentsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTaskStatus
            // 
            panelTaskStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelTaskStatus.BackColor = Color.White;
            panelTaskStatus.BorderStyle = BorderStyle.FixedSingle;
            panelTaskStatus.Controls.Add(panelTaskStatusChart);
            panelTaskStatus.Controls.Add(lblTaskStatusTitle);
            panelTaskStatus.Location = new Point(14, 226);
            panelTaskStatus.Margin = new Padding(4, 3, 4, 3);
            panelTaskStatus.Name = "panelTaskStatus";
            panelTaskStatus.Size = new Size(326, 254);
            panelTaskStatus.TabIndex = 4;
            // 
            // panelTaskStatusChart
            // 
            panelTaskStatusChart.Dock = DockStyle.Fill;
            panelTaskStatusChart.Location = new Point(0, 35);
            panelTaskStatusChart.Margin = new Padding(4, 3, 4, 3);
            panelTaskStatusChart.Name = "panelTaskStatusChart";
            panelTaskStatusChart.Size = new Size(324, 217);
            panelTaskStatusChart.TabIndex = 1;
            panelTaskStatusChart.Paint += panelTaskStatusChart_Paint;
            // 
            // lblTaskStatusTitle
            // 
            lblTaskStatusTitle.BackColor = Color.FromArgb(0, 122, 204);
            lblTaskStatusTitle.Dock = DockStyle.Top;
            lblTaskStatusTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTaskStatusTitle.ForeColor = Color.White;
            lblTaskStatusTitle.Location = new Point(0, 0);
            lblTaskStatusTitle.Margin = new Padding(4, 0, 4, 0);
            lblTaskStatusTitle.Name = "lblTaskStatusTitle";
            lblTaskStatusTitle.Size = new Size(324, 35);
            lblTaskStatusTitle.TabIndex = 0;
            lblTaskStatusTitle.Text = "Task Status";
            lblTaskStatusTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelRecentActivity
            // 
            panelRecentActivity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRecentActivity.BackColor = Color.White;
            panelRecentActivity.BorderStyle = BorderStyle.FixedSingle;
            panelRecentActivity.Controls.Add(dataGridViewRecentActivity);
            panelRecentActivity.Controls.Add(lblRecentActivityTitle);
            panelRecentActivity.Location = new Point(348, 226);
            panelRecentActivity.Margin = new Padding(4, 3, 4, 3);
            panelRecentActivity.Name = "panelRecentActivity";
            panelRecentActivity.Size = new Size(1019, 254);     
            panelRecentActivity.TabIndex = 5;
            // 
            // dataGridViewRecentActivity
            // 
            dataGridViewRecentActivity.AllowUserToAddRows = false;
            dataGridViewRecentActivity.AllowUserToDeleteRows = false;
            dataGridViewRecentActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRecentActivity.BackgroundColor = Color.White;
            dataGridViewRecentActivity.BorderStyle = BorderStyle.None;
            dataGridViewRecentActivity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRecentActivity.Dock = DockStyle.Fill;
            dataGridViewRecentActivity.Location = new Point(0, 35);
            dataGridViewRecentActivity.Margin = new Padding(4, 3, 4, 3);
            dataGridViewRecentActivity.Name = "dataGridViewRecentActivity";
            dataGridViewRecentActivity.ReadOnly = true;
            dataGridViewRecentActivity.RowHeadersVisible = false;
            dataGridViewRecentActivity.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRecentActivity.Size = new Size(1017, 217);
            dataGridViewRecentActivity.TabIndex = 1;
            dataGridViewRecentActivity.CellContentClick += dataGridViewRecentActivity_CellContentClick;
            // 
            // lblRecentActivityTitle
            // 
            lblRecentActivityTitle.BackColor = Color.FromArgb(0, 122, 204);
            lblRecentActivityTitle.Dock = DockStyle.Top;
            lblRecentActivityTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecentActivityTitle.ForeColor = Color.White;
            lblRecentActivityTitle.Location = new Point(0, 0);
            lblRecentActivityTitle.Margin = new Padding(4, 0, 4, 0);
            lblRecentActivityTitle.Name = "lblRecentActivityTitle";
            lblRecentActivityTitle.Size = new Size(1017, 35);
            lblRecentActivityTitle.TabIndex = 0;
            lblRecentActivityTitle.Text = "Recent Activity";
            lblRecentActivityTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelQuickActions
            // 
            panelQuickActions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelQuickActions.BackColor = Color.White;
            panelQuickActions.BorderStyle = BorderStyle.FixedSingle;
            panelQuickActions.Controls.Add(btnRefreshDashboard);
            panelQuickActions.Controls.Add(btnAddTask);
            panelQuickActions.Controls.Add(btnAddProject);
            panelQuickActions.Controls.Add(btnAddUser);
            panelQuickActions.Controls.Add(lblQuickActionsTitle);
            panelQuickActions.Location = new Point(15, 486);
            panelQuickActions.Margin = new Padding(4, 3, 4, 3);
            panelQuickActions.Name = "panelQuickActions";
            panelQuickActions.Size = new Size(326, 230);
            panelQuickActions.TabIndex = 7;
            // 
            // btnRefreshDashboard
            // 
            btnRefreshDashboard.BackColor = Color.FromArgb(52, 152, 219);
            btnRefreshDashboard.FlatAppearance.BorderSize = 0;
            btnRefreshDashboard.FlatStyle = FlatStyle.Flat;
            btnRefreshDashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefreshDashboard.ForeColor = Color.White;
            btnRefreshDashboard.Location = new Point(13, 181);
            btnRefreshDashboard.Margin = new Padding(4, 3, 4, 3);
            btnRefreshDashboard.Name = "btnRefreshDashboard";
            btnRefreshDashboard.Size = new Size(299, 35);
            btnRefreshDashboard.TabIndex = 4;
            btnRefreshDashboard.Text = "Refresh Dashboard";
            btnRefreshDashboard.UseVisualStyleBackColor = false;
            btnRefreshDashboard.Click += btnRefreshDashboard_Click;
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.FromArgb(46, 204, 113);
            btnAddTask.FlatAppearance.BorderSize = 0;
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTask.ForeColor = Color.White;
            btnAddTask.Location = new Point(13, 98);
            btnAddTask.Margin = new Padding(4, 3, 4, 3);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(299, 35);
            btnAddTask.TabIndex = 3;
            btnAddTask.Text = "Add New Task";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnAddProject
            // 
            btnAddProject.BackColor = Color.FromArgb(230, 126, 34);
            btnAddProject.FlatAppearance.BorderSize = 0;
            btnAddProject.FlatStyle = FlatStyle.Flat;
            btnAddProject.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddProject.ForeColor = Color.White;
            btnAddProject.Location = new Point(13, 140);
            btnAddProject.Margin = new Padding(4, 3, 4, 3);
            btnAddProject.Name = "btnAddProject";
            btnAddProject.Size = new Size(299, 35);
            btnAddProject.TabIndex = 2;
            btnAddProject.Text = "Add New Project";
            btnAddProject.UseVisualStyleBackColor = false;
            btnAddProject.Click += btnAddProject_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.FromArgb(41, 128, 185);
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(13, 57);
            btnAddUser.Margin = new Padding(4, 3, 4, 3);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(299, 35);
            btnAddUser.TabIndex = 1;
            btnAddUser.Text = "Add New User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // lblQuickActionsTitle
            // 
            lblQuickActionsTitle.BackColor = Color.FromArgb(0, 122, 204);
            lblQuickActionsTitle.Dock = DockStyle.Top;
            lblQuickActionsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuickActionsTitle.ForeColor = Color.White;
            lblQuickActionsTitle.Location = new Point(0, 0);
            lblQuickActionsTitle.Margin = new Padding(4, 0, 4, 0);
            lblQuickActionsTitle.Name = "lblQuickActionsTitle";
            lblQuickActionsTitle.Size = new Size(324, 35);
            lblQuickActionsTitle.TabIndex = 0;
            lblQuickActionsTitle.Text = "Quick Actions";
            lblQuickActionsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelProjectProgress
            // 
            panelProjectProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelProjectProgress.BackColor = Color.White;
            panelProjectProgress.BorderStyle = BorderStyle.FixedSingle;
            panelProjectProgress.Controls.Add(dataGridViewProjects);
            panelProjectProgress.Controls.Add(lblProjectProgressTitle);
            panelProjectProgress.Location = new Point(347, 487);
            panelProjectProgress.Margin = new Padding(4, 3, 4, 3);
            panelProjectProgress.Name = "panelProjectProgress";
            panelProjectProgress.Size = new Size(1019, 230);
            panelProjectProgress.TabIndex = 8;
            // 
            // dataGridViewProjects
            // 
            dataGridViewProjects.AllowUserToAddRows = false;
            dataGridViewProjects.AllowUserToDeleteRows = false;
            dataGridViewProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProjects.BackgroundColor = Color.White;
            dataGridViewProjects.BorderStyle = BorderStyle.None;
            dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProjects.Dock = DockStyle.Fill;
            dataGridViewProjects.Location = new Point(0, 35);
            dataGridViewProjects.Margin = new Padding(4, 3, 4, 3);
            dataGridViewProjects.Name = "dataGridViewProjects";
            dataGridViewProjects.ReadOnly = true;
            dataGridViewProjects.RowHeadersVisible = false;
            dataGridViewProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProjects.Size = new Size(1017, 193);
            dataGridViewProjects.TabIndex = 1;
            // 
            // lblProjectProgressTitle
            // 
            lblProjectProgressTitle.BackColor = Color.FromArgb(0, 122, 204);
            lblProjectProgressTitle.Dock = DockStyle.Top;
            lblProjectProgressTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProjectProgressTitle.ForeColor = Color.White;
            lblProjectProgressTitle.Location = new Point(0, 0);
            lblProjectProgressTitle.Margin = new Padding(4, 0, 4, 0);
            lblProjectProgressTitle.Name = "lblProjectProgressTitle";
            lblProjectProgressTitle.Size = new Size(1017, 35);
            lblProjectProgressTitle.TabIndex = 0;
            lblProjectProgressTitle.Text = "project ";
            lblProjectProgressTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerRefresh
            // 
            timerRefresh.Interval = 60000;
            timerRefresh.Tick += timerRefresh_Tick;
            // 
            // DashboardMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1370, 749);
            Controls.Add(panelProjectProgress);
            Controls.Add(panelQuickActions);
            Controls.Add(panelRecentActivity);
            Controls.Add(panelTaskStatus);
            Controls.Add(panelStats);
            Controls.Add(panelHeader);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1164, 718);
            Name = "DashboardMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task Management System - Dashboard";
            Load += DashboardMainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelStats.ResumeLayout(false);
            tableLayoutPanelStats.ResumeLayout(false);
            panelUsers.ResumeLayout(false);
            panelTasks.ResumeLayout(false);
            panelProjects.ResumeLayout(false);
            panelDepartments.ResumeLayout(false);
            panelTaskStatus.ResumeLayout(false);
            panelRecentActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecentActivity).EndInit();
            panelQuickActions.ResumeLayout(false);
            panelProjectProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskAssignmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStats;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.Label lblUsersTitle;
        private System.Windows.Forms.Panel panelTasks;
        private System.Windows.Forms.Label lblTaskCount;
        private System.Windows.Forms.Label lblTasksTitle;
        private System.Windows.Forms.Panel panelProjects;
        private System.Windows.Forms.Label lblProjectCount;
        private System.Windows.Forms.Label lblProjectsTitle;
        private System.Windows.Forms.Panel panelDepartments;
        private System.Windows.Forms.Label lblDepartmentCount;
        private System.Windows.Forms.Label lblDepartmentsTitle;
        private System.Windows.Forms.Panel panelTaskStatus;
        private System.Windows.Forms.Panel panelTaskStatusChart;
        private System.Windows.Forms.Label lblTaskStatusTitle;
        private System.Windows.Forms.Panel panelRecentActivity;
        private System.Windows.Forms.DataGridView dataGridViewRecentActivity;
        private System.Windows.Forms.Label lblRecentActivityTitle;
        private System.Windows.Forms.Panel panelQuickActions;
        private System.Windows.Forms.Button btnRefreshDashboard;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lblQuickActionsTitle;
        private System.Windows.Forms.Panel panelProjectProgress;
        private System.Windows.Forms.DataGridView dataGridViewProjects;
        private System.Windows.Forms.Label lblProjectProgressTitle;
        private System.Windows.Forms.Timer timerRefresh;

        private void DashboardMainForm_Load(object sender, EventArgs e)
        {
            // Set current date
            lblCurrentDate.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy");

            // Start the refresh timer
            timerRefresh.Start();
        }

        private void LoadAllDataFromDatabase()
        {
            LoadUsersFromDatabase();
            LoadProjectsFromDatabase();
            LoadTasksFromDatabase();
            LoadLogsFromDatabase();
        }

        private void LoadUsersFromDatabase()
        {
            usersTable = new DataTable();
            try
            {
                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            u.user_id, u.first_name, u.last_name, u.email, 
                            d.department_name, r.role_name
                        FROM users u
                        LEFT JOIN departments d ON u.department_id = d.department_id
                        LEFT JOIN roles r ON u.role_id = r.role_id";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(usersTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load users from the database.\n\nDetails: " + ex.Message,
                    "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usersTable = new DataTable();
            }
        }

        private void LoadTasksFromDatabase()
        {
            tasksTable = new DataTable();
            try
            {
                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
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
                    ";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(tasksTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load tasks from the database.\n\nDetails: " + ex.Message,
                    "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tasksTable = new DataTable();
            }
        }

        private void LoadProjectsFromDatabase()
        {
            projectsTable = new DataTable();
            try
            {
                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            p.project_id, 
                            p.project_name, 
                            CONCAT(u.first_name, ' ', u.last_name) AS manager_name,
                            p.start_date, 
                            p.end_date, 
                            p.budget,
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load projects from the database.\n\nDetails: " + ex.Message,
                    "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                projectsTable = new DataTable();
            }
        }

        private void LoadLogsFromDatabase()
        {
            logsTable = new DataTable();
            try
            {
                using (var conn = dbConnection.GetConnection())
                using (var cmd = new MySqlCommand(@"
                    SELECT 
                        l.log_id,
                        CONCAT(u.first_name, ' ', u.last_name) AS user_name,
                        l.action,
                        l.log_time,
                        CONCAT(
                            'Table: ', l.table_name,
                            IFNULL(CONCAT(', Project: ', p.project_name), ''),
                            IFNULL(CONCAT(', Record ID: ', l.record_id), '')
                        ) AS details
                    FROM logs l
                    LEFT JOIN users u ON l.user_id = u.user_id
                    LEFT JOIN projects p ON l.project_id = p.project_id
                    ORDER BY l.log_time DESC
                    LIMIT 50
                ", conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(logsTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load logs from the database.\n\nDetails: " + ex.Message,
                    "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logsTable = new DataTable();
            }
        }

        private void UpdateDashboard()
        {
            // Update statistics
            lblUserCount.Text = usersTable.Rows.Count.ToString();

            int activeTasks = 0;
            foreach (DataRow row in tasksTable.Rows)
            {
                if (row["status"].ToString() != "Completed")
                    activeTasks++;
            }
            lblTaskCount.Text = activeTasks.ToString();

            lblProjectCount.Text = projectsTable.Rows.Count.ToString();

            // Get unique departments
            var departments = new HashSet<string>();
            foreach (DataRow row in usersTable.Rows)
            {
                departments.Add(row["department_name"].ToString());
            }
            lblDepartmentCount.Text = departments.Count.ToString();

            // Update recent activity
            DataView recentActivityView = logsTable != null ? new DataView(logsTable) : new DataView(new DataTable());
            recentActivityView.Sort = "log_time DESC";
            dataGridViewRecentActivity.DataSource = recentActivityView;

            // Format the recent activity grid
            if (dataGridViewRecentActivity.Columns.Count > 0)
            {
                dataGridViewRecentActivity.Columns["log_id"].Visible = false;
                dataGridViewRecentActivity.Columns["log_time"].DefaultCellStyle.Format = "g";
            }

            // Update project 
            dataGridViewProjects.DataSource = projectsTable;

            // Format the projects grid
            if (dataGridViewProjects.Columns.Count > 0)
            {
                dataGridViewProjects.Columns["project_id"].Visible = false;
                dataGridViewProjects.Columns["start_date"].DefaultCellStyle.Format = "d";
                dataGridViewProjects.Columns["end_date"].DefaultCellStyle.Format = "d";
            }

            // Refresh the task status chart
            panelTaskStatusChart.Invalidate();
        }

        private void panelTaskStatusChart_Paint(object sender, PaintEventArgs e)
        {
            // Count tasks by status
            int notStarted = 0;
            int inProgress = 0;
            int completed = 0;

            foreach (DataRow row in tasksTable.Rows)
            {
                string status = row["status"].ToString();
                if (status == "Not Started")
                    notStarted++;
                else if (status == "In Progress")
                    inProgress++;
                else if (status == "Completed")
                    completed++;
            }

            // Calculate total and percentages
            int total = notStarted + inProgress + completed;
            if (total == 0) return; // Avoid division by zero

            float notStartedPct = (float)notStarted / total;
            float inProgressPct = (float)inProgress / total;
            float completedPct = (float)completed / total;

            // Define colors
            Color notStartedColor = Color.FromArgb(231, 76, 60); // Red
            Color inProgressColor = Color.FromArgb(241, 196, 15); // Yellow
            Color completedColor = Color.FromArgb(46, 204, 113); // Green

            // Draw pie chart
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calculate chart dimensions
            Rectangle chartRect = new Rectangle(30, 30, panelTaskStatusChart.Width - 60, panelTaskStatusChart.Height - 100);

            // Draw segments
            float startAngle = 0;

            if (completedPct > 0)
            {
                float sweepAngle = completedPct * 360;
                using (SolidBrush brush = new SolidBrush(completedColor))
                {
                    g.FillPie(brush, chartRect, startAngle, sweepAngle);
                }
                startAngle += sweepAngle;
            }

            if (inProgressPct > 0)
            {
                float sweepAngle = inProgressPct * 360;
                using (SolidBrush brush = new SolidBrush(inProgressColor))
                {
                    g.FillPie(brush, chartRect, startAngle, sweepAngle);
                }
                startAngle += sweepAngle;
            }

            if (notStartedPct > 0)
            {
                float sweepAngle = notStartedPct * 360;
                using (SolidBrush brush = new SolidBrush(notStartedColor))
                {
                    g.FillPie(brush, chartRect, startAngle, sweepAngle);
                }
            }

            // Draw legend
            int legendY = chartRect.Bottom + 10;

            // Completed legend
            g.FillRectangle(new SolidBrush(completedColor), 30, legendY, 15, 15);
            g.DrawString($"Completed ({completed})", new Font("Segoe UI", 9), Brushes.Black, 50, legendY);

            // In Progress legend
            legendY += 20;
            g.FillRectangle(new SolidBrush(inProgressColor), 30, legendY, 15, 15);
            g.DrawString($"In Progress ({inProgress})", new Font("Segoe UI", 9), Brushes.Black, 50, legendY);

            // Not Started legend
            legendY += 20;
            g.FillRectangle(new SolidBrush(notStartedColor), 30, legendY, 15, 15);
            g.DrawString($"Not Started ({notStarted})", new Font("Segoe UI", 9), Brushes.Black, 50, legendY);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.ShowDialog();
            UpdateDashboard(); // Refresh dashboard after form closes
        }

        private void tasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TasksForm tasksForm = new TasksForm();
            tasksForm.ShowDialog();
            UpdateDashboard(); // Refresh dashboard after form closes
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectsForm projectsForm = new ProjectsForm();
            projectsForm.ShowDialog();
            UpdateDashboard(); // Refresh dashboard after form closes
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentsForm departmentsForm = new DepartmentsForm();
            departmentsForm.ShowDialog();
            UpdateDashboard(); // Refresh dashboard after form closes
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RolesForm rolesForm = new RolesForm();
            rolesForm.ShowDialog();
            UpdateDashboard(); // Refresh dashboard after form closes
        }

        private void taskAssignmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskAssignmentsForm taskAssignmentsForm = new TaskAssignmentsForm();
            taskAssignmentsForm.ShowDialog();
            UpdateDashboard(); // Refresh dashboard after form closes
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogsForm logsForm = new LogsForm();
            logsForm.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.ShowDialog();
            UpdateDashboard(); // Refresh dashboard after form closes
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            TasksForm tasksForm = new TasksForm();
            tasksForm.ShowDialog();
            UpdateDashboard(); // Refresh dashboard after form closes
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            ProjectsForm projectsForm = new ProjectsForm();
            projectsForm.ShowDialog();
            UpdateDashboard(); // Refresh dashboard after form closes
        }

        private void btnRefreshDashboard_Click(object sender, EventArgs e)
        {
            // In a real application, this would reload data from the database
            UpdateDashboard();
            statusLabel.Text = "Dashboard refreshed at " + DateTime.Now.ToString("g");
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            // Auto-refresh the dashboard every minute
            UpdateDashboard();
            lblCurrentDate.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy");
            statusLabel.Text = "Dashboard auto-refreshed at " + DateTime.Now.ToString("g");
        }

        private void lblUsersTitle_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanelStats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewRecentActivity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Example: Export projectsTable with filtering
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.Title = "Export Report to Excel";
                sfd.FileName = "ProjectReport.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            // You can filter the DataTable before exporting if needed
                            DataView dv = new DataView(projectsTable);

                            // Example: Filter by department (customize as needed)
                            // dv.RowFilter = "department_name = 'IT'";

                            var ws = workbook.Worksheets.Add(dv.ToTable("ProjectsReport"));

                            var firstTable = ws.Tables.FirstOrDefault();
                            if (firstTable != null)
                            {
                                firstTable.ShowAutoFilter = true; // Enable Excel filtering
                            }

                            // Optional: Adjust column widths
                            ws.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Report exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to export report.\n\nDetails: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    // Custom DataGridViewProgressColumn for showing progress bars
    public class DataGridViewProgressColumn : DataGridViewColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }
    }

    public class DataGridViewProgressCell : DataGridViewTextBoxCell
    {
        protected override void Paint(Graphics g, Rectangle clipBounds, Rectangle cellBounds,
            int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue,
            string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // First paint the cell background
            base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue,
                errorText, cellStyle, advancedBorderStyle, paintParts);

            if (value != null && int.TryParse(value.ToString(), out int progressValue))
            {
                // Ensure progress is between 0 and 100
                progressValue = Math.Max(0, Math.Min(100, progressValue));

                // Calculate progress bar rectangle
                Rectangle progressRect = new Rectangle(
                    cellBounds.X + 2,
                    cellBounds.Y + 2,
                    (int)((cellBounds.Width - 4) * ((double)progressValue / 100)),
                    cellBounds.Height - 4);

                // Choose color based on progress
                Color progressColor;
                if (progressValue < 30)
                    progressColor = Color.FromArgb(231, 76, 60); // Red
                else if (progressValue < 70)
                    progressColor = Color.FromArgb(241, 196, 15); // Yellow
                else
                    progressColor = Color.FromArgb(46, 204, 113); // Green

                // Draw progress bar
                using (Brush brush = new SolidBrush(progressColor))
                {
                    g.FillRectangle(brush, progressRect);
                }

                // Draw progress text
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    using (Brush textBrush = new SolidBrush(Color.Black))
                    {
                        g.DrawString(progressValue + "%", cellStyle.Font, textBrush, cellBounds, sf);
                    }
                }
            }
        }
    }
}