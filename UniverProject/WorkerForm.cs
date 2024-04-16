using Npgsql;

namespace UniverProject
{
    public partial class WorkerForm : Form
    {
        public WorkerForm()
        {
            InitializeComponent();
            LoadData();
            dataGridViewLevels.CellValueChanged += DataGridViewLevels_CellValueChanged;
            dataGridViewSpecialties.CellValueChanged += DataGridViewSpecialties_CellValueChanged;
            FormClosing += WorkerForm_FormClosing;
        }
        private void WorkerForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!LeaveForm())
                e.Cancel = true;
        }

        private void DataGridViewLevels_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            buttonSaveChangesLevels.Enabled = true;
        }

        private void DataGridViewSpecialties_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            buttonSaveChangesSpecialties.Enabled = true;
        }

        public void LoadData()
        {
            Program.con.Open();
            string sql = $"select * from education_level";
            NpgsqlCommand cmd = new(sql, Program.con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridViewLevels.Rows.Add((int)reader.GetValue(0), (string)reader.GetValue(1), (int)reader.GetValue(2) + "");
            }
            reader.Close();
            Program.con.Close();

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dataGridViewSpecialties.Columns[3];
            column.Items.AddRange(RegistrationEnrolleeForm.GetEducationLevels().ToArray());

            Program.con.Open();
            sql = $"select specialty.id, specialty.title, code, education_level.title from specialty inner join education_level on education_level.id=specialty.id_education_level";
            cmd = new(sql, Program.con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridViewSpecialties.Rows.Add((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3));
            }
            Program.con.Close();

            LoadApplications();
        }

        private void buttonSaveChangesLevels_Click(object sender, EventArgs e)
        {
            SaveLevels();
        }

        private void LoadApplications()
        {
            Program.con.Open();
            string sql = $"select * from application where date = '{DateOnly.FromDateTime(dateTimePicker.Value)}'";
            NpgsqlCommand cmd = new(sql, Program.con);
            var reader = cmd.ExecuteReader();
            flowLayoutPanel.Controls.Clear();
            while (reader.Read())
            {
                Panel panel = new Panel()
                {
                    Location = new Point(3, 3),
                    Name = (int)reader.GetValue(0) + "",
                    Size = new Size(1223, 108)
                };
                panel.DoubleClick += panel_DoubleClick;
                Label date = new Label()
                {
                    AutoSize = true,
                    Location = new Point(47, 39),
                    Text = ((DateTime)reader.GetValue(2)).ToShortDateString()
                };
                Label number = new Label()
                {
                    AutoSize = true,
                    Location = new Point(249, 39),
                    Text = "Заявление №" + (int)reader.GetValue(0)
                };
                Label status = new Label()
                {
                    AutoSize = true,
                    Location = new Point(1093, 39),
                    Text = ((string)reader.GetValue(1)).ToUpper()
                };
                panel.Controls.AddRange(new Label[] { date, number, status });
                flowLayoutPanel.Controls.Add(panel);
            }
            Program.con.Close();
        }

        private bool SaveLevels()
        {
            foreach (DataGridViewRow row in dataGridViewLevels.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[1].Value == null || row.Cells[2].Value == null)
                    {
                        MessageBox.Show("Поля в таблице не могут быть пустыми!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!int.TryParse((string)row.Cells[2].Value, out int points))
                    {
                        MessageBox.Show("Поле Максимальное количество баллов при поступлении может содержать только целочисленные значения!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            Program.con.Open();
            NpgsqlCommand cmd;
            foreach (DataGridViewRow row in dataGridViewLevels.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[0].Value != null)
                    {
                        cmd = new NpgsqlCommand($"update education_level set title = '{(string)row.Cells[1].Value}', " +
                            $"max_points = {int.Parse((string)row.Cells[2].Value)} where id= {(int)row.Cells[0].Value}", Program.con);
                    }
                    else
                    {
                        cmd = new NpgsqlCommand($"insert into education_level(title, max_points) values(" +
                            $"'{(string)row.Cells[1].Value}', {int.Parse((string)row.Cells[2].Value)})", Program.con);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            Program.con.Close();
            buttonSaveChangesLevels.Enabled = false;
            return true;
        }

        private void buttonSaveChangesSpecialties_Click(object sender, EventArgs e)
        {
            SaveSpecialties();
        }

        private bool SaveSpecialties()
        {
            foreach (DataGridViewRow row in dataGridViewSpecialties.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[3].Value == null)
                    {
                        MessageBox.Show("Поля в таблице не могут быть пустыми!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (((string)row.Cells[2].Value).Length > 10)
                    {
                        MessageBox.Show("Поле Код специальности не может быть превышать 10 символов!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            Program.con.Open();
            NpgsqlCommand cmd;
            foreach (DataGridViewRow row in dataGridViewSpecialties.Rows)
            {
                if (!row.IsNewRow)
                {
                    var comboBox = (DataGridViewComboBoxCell)row.Cells[3];
                    var idEducationLevel = comboBox.Items.IndexOf(comboBox.Value);
                    if (row.Cells[0].Value != null)
                    {

                        cmd = new NpgsqlCommand($"update specialty set title = '{(string)row.Cells[1].Value}', " +
                            $"id_education_level = {idEducationLevel}, code = '{(string)row.Cells[3].Value}' where id= {(int)row.Cells[0].Value}", Program.con);
                    }
                    else
                    {
                        cmd = new NpgsqlCommand($"insert into specialty(title, code, id_education_level) values(" +
                            $"'{(string)row.Cells[1].Value}', {idEducationLevel}, '{(string)row.Cells[3].Value}')", Program.con);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            Program.con.Close();
            buttonSaveChangesSpecialties.Enabled = false;
            return true;
        }

        private void panel_DoubleClick(object sender, EventArgs e)
        {
            if (!LeaveForm())
                return;
            Panel panel = (Panel)sender;
            Program.ChangeForm(this, new RegistrationEnrolleeForm(int.Parse(panel.Name), 2));
        }

        private bool LeaveForm()
        {
            if (buttonSaveChangesLevels.Enabled)
            {
                var result = MessageBox.Show("На странице Уровни образования остались несохраненные изменения, сохранить перед выходом?", "Сохранение изменений", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    if (!SaveLevels())
                        return false;
            }

            if (buttonSaveChangesSpecialties.Enabled)
            {
                var result = MessageBox.Show("На странице Направления остались несохраненные изменения, сохранить перед выходом?", "Сохранение изменений", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    if (!SaveSpecialties())
                        return false;
            }
            return true;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadApplications();
        }
    }
}
