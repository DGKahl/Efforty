
namespace Efforty
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
            this.cbTasks = new System.Windows.Forms.ComboBox();
            this.btnNewTask = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSelectedActivity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveActivity = new System.Windows.Forms.Button();
            this.btnChangeActivity = new System.Windows.Forms.Button();
            this.btnNewActivity = new System.Windows.Forms.Button();
            this.lbActivities = new System.Windows.Forms.ListBox();
            this.btnShowResults = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTasks
            // 
            this.cbTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTasks.FormattingEnabled = true;
            this.cbTasks.Location = new System.Drawing.Point(6, 19);
            this.cbTasks.Name = "cbTasks";
            this.cbTasks.Size = new System.Drawing.Size(354, 21);
            this.cbTasks.TabIndex = 1;
            this.cbTasks.SelectedIndexChanged += new System.EventHandler(this.cbTasks_SelectedIndexChanged);
            // 
            // btnNewTask
            // 
            this.btnNewTask.Location = new System.Drawing.Point(6, 99);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(109, 23);
            this.btnNewTask.TabIndex = 2;
            this.btnNewTask.Text = "  Neu...";
            this.btnNewTask.UseVisualStyleBackColor = true;
            this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblSelectedActivity);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnEditTask);
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.btnNewTask);
            this.groupBox1.Controls.Add(this.btnDeleteTask);
            this.groupBox1.Controls.Add(this.btnEnd);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.cbTasks);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aufgaben";
            // 
            // lblSelectedActivity
            // 
            this.lblSelectedActivity.AutoSize = true;
            this.lblSelectedActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedActivity.Location = new System.Drawing.Point(54, 45);
            this.lblSelectedActivity.Name = "lblSelectedActivity";
            this.lblSelectedActivity.Size = new System.Drawing.Size(39, 13);
            this.lblSelectedActivity.TabIndex = 8;
            this.lblSelectedActivity.Text = "(keine)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tätigkeit: ";
            // 
            // btnEditTask
            // 
            this.btnEditTask.Enabled = false;
            this.btnEditTask.Location = new System.Drawing.Point(129, 99);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(109, 23);
            this.btnEditTask.TabIndex = 6;
            this.btnEditTask.Text = "   Editieren...";
            this.btnEditTask.UseVisualStyleBackColor = true;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(129, 70);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(109, 23);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Enabled = false;
            this.btnDeleteTask.Location = new System.Drawing.Point(251, 99);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(109, 23);
            this.btnDeleteTask.TabIndex = 4;
            this.btnDeleteTask.Text = "Löschen";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(251, 70);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(109, 23);
            this.btnEnd.TabIndex = 3;
            this.btnEnd.Text = "Ende";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 70);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnRemoveActivity);
            this.groupBox2.Controls.Add(this.btnChangeActivity);
            this.groupBox2.Controls.Add(this.btnNewActivity);
            this.groupBox2.Controls.Add(this.lbActivities);
            this.groupBox2.Location = new System.Drawing.Point(12, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 117);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tätigkeiten";
            // 
            // btnRemoveActivity
            // 
            this.btnRemoveActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveActivity.Location = new System.Drawing.Point(257, 77);
            this.btnRemoveActivity.Name = "btnRemoveActivity";
            this.btnRemoveActivity.Size = new System.Drawing.Size(103, 23);
            this.btnRemoveActivity.TabIndex = 9;
            this.btnRemoveActivity.Text = "Löschen";
            this.btnRemoveActivity.UseVisualStyleBackColor = true;
            this.btnRemoveActivity.Click += new System.EventHandler(this.btnRemoveActivity_Click);
            // 
            // btnChangeActivity
            // 
            this.btnChangeActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeActivity.Location = new System.Drawing.Point(257, 48);
            this.btnChangeActivity.Name = "btnChangeActivity";
            this.btnChangeActivity.Size = new System.Drawing.Size(103, 23);
            this.btnChangeActivity.TabIndex = 8;
            this.btnChangeActivity.Text = "Ändern...";
            this.btnChangeActivity.UseVisualStyleBackColor = true;
            this.btnChangeActivity.Click += new System.EventHandler(this.btnChangeActivity_Click);
            // 
            // btnNewActivity
            // 
            this.btnNewActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewActivity.Location = new System.Drawing.Point(257, 19);
            this.btnNewActivity.Name = "btnNewActivity";
            this.btnNewActivity.Size = new System.Drawing.Size(103, 23);
            this.btnNewActivity.TabIndex = 7;
            this.btnNewActivity.Text = "Neu...";
            this.btnNewActivity.UseVisualStyleBackColor = true;
            this.btnNewActivity.Click += new System.EventHandler(this.btnAddActivity_Click);
            // 
            // lbActivities
            // 
            this.lbActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbActivities.FormattingEnabled = true;
            this.lbActivities.Location = new System.Drawing.Point(7, 20);
            this.lbActivities.Name = "lbActivities";
            this.lbActivities.Size = new System.Drawing.Size(244, 82);
            this.lbActivities.TabIndex = 0;
            this.lbActivities.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbActivities_MouseDoubleClick);
            // 
            // btnShowResults
            // 
            this.btnShowResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowResults.Location = new System.Drawing.Point(12, 288);
            this.btnShowResults.Name = "btnShowResults";
            this.btnShowResults.Size = new System.Drawing.Size(366, 37);
            this.btnShowResults.TabIndex = 5;
            this.btnShowResults.Text = "Auswertung";
            this.btnShowResults.UseVisualStyleBackColor = true;
            this.btnShowResults.Click += new System.EventHandler(this.btnShowResults_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 334);
            this.Controls.Add(this.btnShowResults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(405, 373);
            this.Name = "Form1";
            this.Text = "Übersicht";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbTasks;
        private System.Windows.Forms.Button btnNewTask;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveActivity;
        private System.Windows.Forms.Button btnChangeActivity;
        private System.Windows.Forms.Button btnNewActivity;
        private System.Windows.Forms.ListBox lbActivities;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnShowResults;
        private System.Windows.Forms.Label lblSelectedActivity;
        private System.Windows.Forms.Label label1;
    }
}

