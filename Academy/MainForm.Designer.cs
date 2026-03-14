namespace Academy
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageStudents = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tabPageGroups = new System.Windows.Forms.TabPage();
            this.tabPageDrections = new System.Windows.Forms.TabPage();
            this.tabPageDisciplins = new System.Windows.Forms.TabPage();
            this.tabPageTeachers = new System.Windows.Forms.TabPage();
            this.dgvDirections = new System.Windows.Forms.DataGridView();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabPageDrections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageStudents);
            this.tabControl.Controls.Add(this.tabPageGroups);
            this.tabControl.Controls.Add(this.tabPageDrections);
            this.tabControl.Controls.Add(this.tabPageDisciplins);
            this.tabControl.Controls.Add(this.tabPageTeachers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(937, 488);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageStudents
            // 
            this.tabPageStudents.Location = new System.Drawing.Point(4, 29);
            this.tabPageStudents.Name = "tabPageStudents";
            this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStudents.Size = new System.Drawing.Size(929, 529);
            this.tabPageStudents.TabIndex = 1;
            this.tabPageStudents.Text = "Students";
            this.tabPageStudents.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 454);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(937, 34);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // tabPageGroups
            // 
            this.tabPageGroups.Location = new System.Drawing.Point(4, 29);
            this.tabPageGroups.Name = "tabPageGroups";
            this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroups.Size = new System.Drawing.Size(929, 529);
            this.tabPageGroups.TabIndex = 2;
            this.tabPageGroups.Text = "Groups";
            this.tabPageGroups.UseVisualStyleBackColor = true;
            // 
            // tabPageDrections
            // 
            this.tabPageDrections.Controls.Add(this.dgvDirections);
            this.tabPageDrections.Location = new System.Drawing.Point(4, 29);
            this.tabPageDrections.Name = "tabPageDrections";
            this.tabPageDrections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDrections.Size = new System.Drawing.Size(929, 455);
            this.tabPageDrections.TabIndex = 3;
            this.tabPageDrections.Text = "Directions";
            this.tabPageDrections.UseVisualStyleBackColor = true;
            // 
            // tabPageDisciplins
            // 
            this.tabPageDisciplins.Location = new System.Drawing.Point(4, 29);
            this.tabPageDisciplins.Name = "tabPageDisciplins";
            this.tabPageDisciplins.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisciplins.Size = new System.Drawing.Size(929, 529);
            this.tabPageDisciplins.TabIndex = 4;
            this.tabPageDisciplins.Text = "Disciplins";
            this.tabPageDisciplins.UseVisualStyleBackColor = true;
            // 
            // tabPageTeachers
            // 
            this.tabPageTeachers.Location = new System.Drawing.Point(4, 29);
            this.tabPageTeachers.Name = "tabPageTeachers";
            this.tabPageTeachers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTeachers.Size = new System.Drawing.Size(929, 529);
            this.tabPageTeachers.TabIndex = 5;
            this.tabPageTeachers.Text = "Teachers";
            this.tabPageTeachers.UseVisualStyleBackColor = true;
            // 
            // dgvDirections
            // 
            this.dgvDirections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDirections.Location = new System.Drawing.Point(3, 3);
            this.dgvDirections.Name = "dgvDirections";
            this.dgvDirections.RowHeadersWidth = 51;
            this.dgvDirections.RowTemplate.Height = 24;
            this.dgvDirections.Size = new System.Drawing.Size(923, 449);
            this.dgvDirections.TabIndex = 0;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(188, 28);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 488);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Academy SPU_411";
            this.tabControl.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabPageDrections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageStudents;
        private System.Windows.Forms.TabPage tabPageGroups;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabPage tabPageDrections;
        private System.Windows.Forms.TabPage tabPageDisciplins;
        private System.Windows.Forms.TabPage tabPageTeachers;
        private System.Windows.Forms.DataGridView dgvDirections;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

