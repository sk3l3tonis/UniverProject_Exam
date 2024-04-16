namespace UniverProject
{
    partial class WorkerForm
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
            tabControl = new TabControl();
            tabPageApplications = new TabPage();
            flowLayoutPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dateTimePicker = new DateTimePicker();
            label4 = new Label();
            tabPageLevels = new TabPage();
            buttonSaveChangesLevels = new Button();
            dataGridViewLevels = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            MaxPoints = new DataGridViewTextBoxColumn();
            tabPageSpecilaties = new TabPage();
            buttonSaveChangesSpecialties = new Button();
            dataGridViewSpecialties = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            IdEducationLevel = new DataGridViewComboBoxColumn();
            tabControl.SuspendLayout();
            tabPageApplications.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            panel1.SuspendLayout();
            tabPageLevels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLevels).BeginInit();
            tabPageSpecilaties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecialties).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageApplications);
            tabControl.Controls.Add(tabPageLevels);
            tabControl.Controls.Add(tabPageSpecilaties);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(984, 496);
            tabControl.TabIndex = 0;
            // 
            // tabPageApplications
            // 
            tabPageApplications.Controls.Add(flowLayoutPanel);
            tabPageApplications.Controls.Add(dateTimePicker);
            tabPageApplications.Controls.Add(label4);
            tabPageApplications.Location = new Point(4, 29);
            tabPageApplications.Name = "tabPageApplications";
            tabPageApplications.Padding = new Padding(3);
            tabPageApplications.Size = new Size(976, 463);
            tabPageApplications.TabIndex = 0;
            tabPageApplications.Text = "Заявления";
            tabPageApplications.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(panel1);
            flowLayoutPanel.Location = new Point(32, 75);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(938, 382);
            flowLayoutPanel.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(925, 125);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(797, 52);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 2;
            label3.Text = "Статус";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(174, 52);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 1;
            label2.Text = "№938475";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 51);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 0;
            label1.Text = "Дата";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(79, 24);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(250, 27);
            dateTimePicker.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 26);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 0;
            label4.Text = "Дата";
            // 
            // tabPageLevels
            // 
            tabPageLevels.Controls.Add(buttonSaveChangesLevels);
            tabPageLevels.Controls.Add(dataGridViewLevels);
            tabPageLevels.Location = new Point(4, 29);
            tabPageLevels.Name = "tabPageLevels";
            tabPageLevels.Padding = new Padding(3);
            tabPageLevels.Size = new Size(976, 463);
            tabPageLevels.TabIndex = 1;
            tabPageLevels.Text = "Уровни образования";
            tabPageLevels.UseVisualStyleBackColor = true;
            // 
            // buttonSaveChangesLevels
            // 
            buttonSaveChangesLevels.Location = new Point(844, 424);
            buttonSaveChangesLevels.Name = "buttonSaveChangesLevels";
            buttonSaveChangesLevels.Size = new Size(94, 29);
            buttonSaveChangesLevels.TabIndex = 1;
            buttonSaveChangesLevels.Text = "Сохранить";
            buttonSaveChangesLevels.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLevels
            // 
            dataGridViewLevels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLevels.Columns.AddRange(new DataGridViewColumn[] { Id, Title, MaxPoints });
            dataGridViewLevels.Location = new Point(17, 16);
            dataGridViewLevels.Name = "dataGridViewLevels";
            dataGridViewLevels.RowHeadersWidth = 51;
            dataGridViewLevels.Size = new Size(940, 397);
            dataGridViewLevels.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 125;
            // 
            // Title
            // 
            Title.HeaderText = "Наименование";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.Width = 350;
            // 
            // MaxPoints
            // 
            MaxPoints.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            MaxPoints.HeaderText = "Максимальный балл при поступлении";
            MaxPoints.MinimumWidth = 6;
            MaxPoints.Name = "MaxPoints";
            MaxPoints.Width = 199;
            // 
            // tabPageSpecilaties
            // 
            tabPageSpecilaties.Controls.Add(buttonSaveChangesSpecialties);
            tabPageSpecilaties.Controls.Add(dataGridViewSpecialties);
            tabPageSpecilaties.Location = new Point(4, 29);
            tabPageSpecilaties.Name = "tabPageSpecilaties";
            tabPageSpecilaties.Size = new Size(976, 463);
            tabPageSpecilaties.TabIndex = 2;
            tabPageSpecilaties.Text = "Направления";
            tabPageSpecilaties.UseVisualStyleBackColor = true;
            // 
            // buttonSaveChangesSpecialties
            // 
            buttonSaveChangesSpecialties.Location = new Point(847, 426);
            buttonSaveChangesSpecialties.Name = "buttonSaveChangesSpecialties";
            buttonSaveChangesSpecialties.Size = new Size(94, 29);
            buttonSaveChangesSpecialties.TabIndex = 1;
            buttonSaveChangesSpecialties.Text = "Сохранить";
            buttonSaveChangesSpecialties.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSpecialties
            // 
            dataGridViewSpecialties.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSpecialties.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, IdEducationLevel });
            dataGridViewSpecialties.Location = new Point(17, 13);
            dataGridViewSpecialties.Name = "dataGridViewSpecialties";
            dataGridViewSpecialties.RowHeadersWidth = 51;
            dataGridViewSpecialties.Size = new Size(945, 404);
            dataGridViewSpecialties.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Наименование";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 450;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Код специальности";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 250;
            // 
            // IdEducationLevel
            // 
            IdEducationLevel.HeaderText = "Уровень образования";
            IdEducationLevel.MinimumWidth = 6;
            IdEducationLevel.Name = "IdEducationLevel";
            IdEducationLevel.Width = 125;
            // 
            // WorkerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 511);
            Controls.Add(tabControl);
            Name = "WorkerForm";
            Text = "WorkerForm";
            tabControl.ResumeLayout(false);
            tabPageApplications.ResumeLayout(false);
            tabPageApplications.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPageLevels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewLevels).EndInit();
            tabPageSpecilaties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecialties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPageApplications;
        private TabPage tabPageLevels;
        private TabPage tabPageSpecilaties;
        private FlowLayoutPanel flowLayoutPanel;
        private DateTimePicker dateTimePicker;
        private Label label4;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridViewLevels;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn MaxPoints;
        private DataGridView dataGridViewSpecialties;
        private Button buttonSaveChangesLevels;
        private Button buttonSaveChangesSpecialties;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewComboBoxColumn IdEducationLevel;
    }
}