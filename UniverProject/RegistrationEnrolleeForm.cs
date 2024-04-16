using System.Drawing.Printing;
using System.Text.RegularExpressions;
using Npgsql;

namespace UniverProject
{
    public partial class RegistrationEnrolleeForm : Form
    {
        private string? fileName;
        private readonly string? login;
        private readonly string? password;
        private int userId;
        private readonly Random? rand;
        private readonly int applicationId;
        private bool isProgramEvent = false;

        public RegistrationEnrolleeForm(int? applicationNumber = null, int userGroup = 1)
        {
            InitializeComponent();
            comboBoxEducationalLevel.SelectedIndexChanged += ComboBoxEducationalLevel_SelectedIndexChanged;
            comboBoxEducationalLevel.Items.AddRange(GetEducationLevels().ToArray());
            if (applicationNumber != null)
            {
                applicationId = (int)applicationNumber;
                Text = "Заявление №" + applicationId;
                labelDate.Visible = true;
                labelStatus.Visible = true;
                labelDateText.Visible = true;
                comboBoxStatus.Visible = true;
                labelComment.Visible = true;
                textBoxComment.Visible = true;
                buttonAttachDocument.Text = "Посмотреть скан документа об образовании";

                textBoxFio.Enabled = false;
                textBoxPassport.Enabled = false;
                textBoxPhone.Enabled = false;
                textBoxEmail.Enabled = false;
                maskedTextBoxSnils.Enabled = false;
                textBoxFioParent.Enabled = false;
                textBoxInstitution.Enabled = false;
                textBoxPoints.Enabled = false;
                comboBoxEducationalLevel.Enabled = false;
                comboBoxSpecialty1.Enabled = false;
                FillFields((int)applicationNumber);
                if (fileName != null)
                    labelFileAttached.Visible = true;
                if (userGroup != 1)
                {
                    buttonApply.Visible = false;
                    comboBoxStatus.Enabled = true;
                    textBoxComment.Enabled = true;
                    buttonBack.Visible = true;
                }
                else buttonApply.Text = "Распечатать заявление";
                return;
            }
            Size = new Size(1385, 783);
            rand = new Random();
            login = GenerateStringWithNumbers();
            password = GenerateStringWithNumbers();
            textBoxPhone.KeyPress += TextBoxOnlyDigits_KeyPress;
            textBoxPassport.KeyPress += TextBoxOnlyDigits_KeyPress;
            maskedTextBoxSnils.KeyPress += TextBoxOnlyDigits_KeyPress;
            textBoxPoints.KeyPress += TextBoxDigitsAndCommon_KeyPress;
            comboBoxSpecialty1.SelectedIndexChanged += ComboBoxSpecialty1_SelectedIndexChanged;
            comboBoxSpecialty2.SelectedIndexChanged += ComboBoxSpecialty2_SelectedIndexChanged;
            comboBoxSpecialty3.SelectedIndexChanged += ComboBoxSpecialty3_SelectedIndexChanged;
            comboBoxSpecialty4.SelectedIndexChanged += ComboBoxSpecialty4_SelectedIndexChanged;
        }

        private void FillFields(int applicationId)
        {
            Program.con.Open();
            string sql = $"select application.*, id_education_level from application inner join specialty on application.specialty_1=specialty.id where application.id = {applicationId}";
            NpgsqlCommand cmd = new(sql, Program.con);
            var reader = cmd.ExecuteReader();
            int educationLevel = 0;
            int spec1 = 0;
            int? spec2 = null, spec3 = null, spec4 = null, spec5 = null;
            while (reader.Read())
            {
                isProgramEvent = true;
                comboBoxStatus.SelectedItem = (string)reader.GetValue(1);
                labelDateText.Text = ((DateTime)reader.GetValue(2)).ToShortDateString();
                educationLevel = (int)reader.GetValue(9) - 1;
                spec1 = (int)reader.GetValue(3);
                if (reader.GetValue(4) != DBNull.Value)
                    spec2 = (int)reader.GetValue(4);
                if (reader.GetValue(5) != DBNull.Value)
                    spec3 = (int)reader.GetValue(5);
                if (reader.GetValue(6) != DBNull.Value)
                    spec4 = (int)reader.GetValue(6);
                if (reader.GetValue(7) != DBNull.Value)
                    spec5 = (int)reader.GetValue(7);
                if (reader.GetValue(8) != DBNull.Value)
                    textBoxComment.Text = (string)reader.GetValue(8);
                isProgramEvent = false;
            }
            reader.Close();
            cmd.Cancel();
            sql = $"select * from enrollee where id = {applicationId}";
            cmd = new(sql, Program.con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBoxFio.Text = (string)reader.GetValue(1);
                textBoxPassport.Text = (string)reader.GetValue(2);
                maskedTextBoxSnils.Text = (string)reader.GetValue(3);
                textBoxEmail.Text = (string)reader.GetValue(4);
                textBoxPhone.Text = (string)reader.GetValue(5);
                textBoxFioParent.Text = (string)reader.GetValue(6);
                textBoxPoints.Text = (double)reader.GetValue(7) + "";
                fileName = (string)reader.GetValue(8);
                textBoxInstitution.Text = (string)reader.GetValue(9);
            }
            Program.con.Close();
            comboBoxEducationalLevel.SelectedIndex = educationLevel;
            comboBoxSpecialty1.SelectedItem = GetTitleBySpecialtyId(spec1);
            comboBoxSpecialty2.SelectedItem = (spec2 != null) ? GetTitleBySpecialtyId((int)spec2) : "";
            comboBoxSpecialty3.SelectedItem = (spec3 != null) ? GetTitleBySpecialtyId((int)spec3) : "";
            comboBoxSpecialty4.SelectedItem = (spec4 != null) ? GetTitleBySpecialtyId((int)spec4) : "";
            comboBoxSpecialty5.SelectedItem = (spec5 != null) ? GetTitleBySpecialtyId((int)spec5) : "";
        }

        private void ComboBoxEducationalLevel_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var spec = GetSpecialties(comboBoxEducationalLevel.SelectedIndex + 1).ToArray();
            comboBoxSpecialty1.Items.Clear();
            comboBoxSpecialty1.Items.AddRange(spec);
            comboBoxSpecialty2.Items.Clear();
            comboBoxSpecialty2.Items.AddRange(spec);
            comboBoxSpecialty3.Items.Clear();
            comboBoxSpecialty3.Items.AddRange(spec);
            comboBoxSpecialty4.Items.Clear();
            comboBoxSpecialty4.Items.AddRange(spec);
            comboBoxSpecialty5.Items.Clear();
            comboBoxSpecialty5.Items.AddRange(spec);
        }

        private void ComboBoxSpecialty2_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxSpecialty2.SelectedIndex != -1 && comboBoxSpecialty2.SelectedIndex != 0)
                comboBoxSpecialty3.Enabled = true;
        }

        private void ComboBoxSpecialty1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxSpecialty1.SelectedIndex != -1 && comboBoxSpecialty1.SelectedIndex != 0)
                comboBoxSpecialty2.Enabled = true;
        }

        private void ComboBoxSpecialty3_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxSpecialty3.SelectedIndex != -1 && comboBoxSpecialty3.SelectedIndex != 0)
                comboBoxSpecialty4.Enabled = true;
        }

        private void ComboBoxSpecialty4_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxSpecialty4.SelectedIndex != -1 && comboBoxSpecialty4.SelectedIndex != 0)
                comboBoxSpecialty5.Enabled = true;
        }

        private void TextBoxOnlyDigits_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || e.KeyChar == ' ')
                e.Handled = true;
        }

        private void TextBoxDigitsAndCommon_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) || e.KeyChar == ' ') && e.KeyChar != ',')
                e.Handled = true;
        }

        private void buttonAttachDocument_Click(object sender, EventArgs e)
        {
            if (buttonAttachDocument.Text == "Посмотреть скан документа об образовании")
                return;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.pdf)|*.pdf";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            fileName = dialog.FileName;
            if (!string.IsNullOrEmpty(fileName))
                labelFileAttached.Visible = true;
            else MessageBox.Show("Произошла ошибка при прикреплении скана документа об образовании!", "Ошибка прикрепления файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (buttonApply.Text == "Распечатать заявление")
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                pd.Print();
                return;
            }
            if (string.IsNullOrEmpty(textBoxFio.Text) || string.IsNullOrEmpty(textBoxPassport.Text) ||
                string.IsNullOrEmpty(maskedTextBoxSnils.Text) || string.IsNullOrEmpty(textBoxEmail.Text) ||
                string.IsNullOrEmpty(textBoxPhone.Text) || string.IsNullOrEmpty(textBoxFioParent.Text) ||
                string.IsNullOrEmpty(textBoxInstitution.Text) || string.IsNullOrEmpty(textBoxPoints.Text))
            {
                MessageBox.Show("Все поля формы обязательны для заполнения!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBoxPassport.Text.Length != 10)
            {
                MessageBox.Show("Проверьте корректность заполнения поля Паспортные данные, серия и номер указываются слитно без пробелов!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!maskedTextBoxSnils.MaskCompleted || !maskedTextBoxSnils.MaskFull)
            {
                MessageBox.Show("Проверьте корректность заполнения поля СНИЛС!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!Regex.IsMatch(textBoxEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Проверьте корректность заполнения поля Электронная почта!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBoxPhone.Text.Length != 11)
            {
                MessageBox.Show("Проверьте корректность заполнения поля Телефон, номер должен состоять из 11 цифр!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBoxEducationalLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Укажите уровень образования!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBoxSpecialty1.SelectedIndex == -1 || comboBoxSpecialty1.SelectedIndex == 0)
            {
                MessageBox.Show("Укажите как минимум одно направление!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (double.Parse(textBoxPoints.Text) <= 0)
            {
                MessageBox.Show("Баллы не могут быть меньше или равны 0!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (double.Parse(textBoxPoints.Text) > GetMaxPointsByEducationalLevel(comboBoxEducationalLevel.SelectedIndex + 1))
            {
                MessageBox.Show("Указанные баллы не соответствуют выбранному уровню образования!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Необходимо прикрепить скан документа об образовании!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            userId = AddUser();
            try
            {
                AddApplication(AddEnrollee());
                MessageBox.Show("Ваше заявление принято в работу! \nВаш логин для входа в личный кабинет - " + login + ", пароль - " + password, "Успешное выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.ChangeForm(this, new AuthorizationForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подаче заявления " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            var width = 2481;
            var height = 3507;
            var g = e.Graphics;
            RectangleF rectangle = new RectangleF(0, 0, width, height);
            g.FillRectangle(new SolidBrush(Color.White), rectangle);
            var font = new Font("Times New Roman", 14, FontStyle.Regular);
            var brushText = new SolidBrush(SystemColors.ControlText);
            string text = "ЗАЯВЛЕНИЕ\n\n" + "Я, " + textBoxFio.Text + ", подал(a) документы в ВУЗ\nНа направления подготовки:\n" +
                GetCodeBySpecialtyId(comboBoxSpecialty1.SelectedIndex) + " " + GetTitleBySpecialtyId(comboBoxSpecialty1.SelectedIndex) + "\n";
            if (comboBoxSpecialty2.SelectedIndex == -1 || comboBoxSpecialty2.SelectedIndex == 0)
                text += GetCodeBySpecialtyId(comboBoxSpecialty2.SelectedIndex) + " " + GetTitleBySpecialtyId(comboBoxSpecialty2.SelectedIndex) + "\n";
            if (comboBoxSpecialty3.SelectedIndex == -1 || comboBoxSpecialty3.SelectedIndex == 0)
                text += GetCodeBySpecialtyId(comboBoxSpecialty3.SelectedIndex) + " " + GetTitleBySpecialtyId(comboBoxSpecialty3.SelectedIndex) + "\n";
            if (comboBoxSpecialty4.SelectedIndex == -1 || comboBoxSpecialty4.SelectedIndex == 0)
                text += GetCodeBySpecialtyId(comboBoxSpecialty4.SelectedIndex) + " " + GetTitleBySpecialtyId(comboBoxSpecialty4.SelectedIndex) + "\n";
            if (comboBoxSpecialty5.SelectedIndex == -1 || comboBoxSpecialty5.SelectedIndex == 0)
                text += GetCodeBySpecialtyId(comboBoxSpecialty5.SelectedIndex) + " " + GetTitleBySpecialtyId(comboBoxSpecialty5.SelectedIndex) + "\n";
            text += "\n\n\n\n" + DateTime.Now.ToShortDateString();
            DrawString(g, text, 0, 0, font, brushText);
        }

        private Point DrawString(Graphics g, String text, int x, int y, Font font, Brush brush)
        {
            foreach (String line in text.Split("\n"))
                g.DrawString(line, font, brush, x, y += 21);
            return new Point(x, y);
        }

        private int AddUser()
        {
            Program.con.Open();
            string sql = $"insert into public.user(login, password, id_user_group) values('{login}', '{password}', 1) returning id";
            NpgsqlCommand cmd = new(sql, Program.con);
            int result = (int)cmd.ExecuteScalar();
            Program.con.Close();
            return result;
        }

        private int AddEnrollee()
        {
            Program.con.Open();
            string points = textBoxPoints.Text.Replace(',', '.');
            string sql = $"insert into enrollee values({userId}, '{textBoxFio.Text}', '{textBoxPassport.Text}', '{maskedTextBoxSnils.Text}', " +
                $"'{textBoxEmail.Text}', '{textBoxPhone.Text}', '{textBoxFioParent.Text}', {points}, " +
                $"'{fileName}', '{textBoxInstitution.Text}') returning id";
            NpgsqlCommand cmd = new(sql, Program.con);
            int result = (int)cmd.ExecuteScalar();
            Program.con.Close();
            return result;
        }

        private void AddApplication(int enrolleeId)
        {
            Program.con.Open();
            string sql = $"insert into application(id, date, specialty_1, specialty_2, specialty_3, specialty_4, specialty_5) " +
                $"values({enrolleeId}, '{DateOnly.FromDateTime(DateTime.Now)}', {GetIdSpecialtyByTitle((string)comboBoxSpecialty1.SelectedItem)}, " +
                $"{((comboBoxSpecialty2.SelectedIndex == -1 || comboBoxSpecialty2.SelectedIndex == 0) ? "null" : GetIdSpecialtyByTitle((string)comboBoxSpecialty2.SelectedItem))}, " +
                $"{((comboBoxSpecialty3.SelectedIndex == -1 || comboBoxSpecialty3.SelectedIndex == 0) ? "null" : GetIdSpecialtyByTitle((string)comboBoxSpecialty3.SelectedItem))}, " +
                $"{((comboBoxSpecialty4.SelectedIndex == -1 || comboBoxSpecialty4.SelectedIndex == 0) ? "null" : GetIdSpecialtyByTitle((string)comboBoxSpecialty4.SelectedItem))}, " +
                $"{((comboBoxSpecialty5.SelectedIndex == -1 || comboBoxSpecialty5.SelectedIndex == 0) ? "null" : GetIdSpecialtyByTitle((string)comboBoxSpecialty5.SelectedItem))})";
            NpgsqlCommand cmd = new(sql, Program.con);
            cmd.ExecuteNonQuery();
            Program.con.Close();
        }

        private string GenerateStringWithNumbers()
        {
            String str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 10;
            String randomstring = "";

            for (int i = 0; i < size; i++)
            {
                int x = rand.Next(str.Length);
                randomstring += str[x];
            }
            return randomstring;
        }

        private int GetMaxPointsByEducationalLevel(int educationalLevel)
        {
            Program.con.Open();
            string sql = $"select max_points from education_level where id = {educationalLevel}";
            NpgsqlCommand cmd = new(sql, Program.con);
            int result = (int)cmd.ExecuteScalar();
            Program.con.Close();
            return result;
        }

        public static List<string> GetEducationLevels()
        {
            Program.con.Open();
            string sql = $"select title from education_level";
            NpgsqlCommand cmd = new(sql, Program.con);
            var result = new List<string>();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                result.Add((string)reader.GetValue(0));
            Program.con.Close();
            return result;
        }

        private List<string> GetSpecialties(int idEducationLevel)
        {
            Program.con.Open();
            string sql = $"select title from specialty where id_education_level = {idEducationLevel}";
            NpgsqlCommand cmd = new(sql, Program.con);
            var result = new List<string>();
            result.Add("");
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                result.Add((string)reader.GetValue(0));
            Program.con.Close();
            return result;
        }

        private int GetIdSpecialtyByTitle(string title)
        {
            Program.con.Open();
            string sql = $"select id from specialty where title = '{title}'";
            NpgsqlCommand cmd = new(sql, Program.con);
            int result = (int)cmd.ExecuteScalar();
            Program.con.Close();
            return result;
        }

        private string GetCodeBySpecialtyId(int specialtyId)
        {
            Program.con.Open();
            string sql = $"select code from specialty where id = {specialtyId}";
            NpgsqlCommand cmd = new(sql, Program.con);
            string result = (string)cmd.ExecuteScalar();
            Program.con.Close();
            return result;
        }

        private string GetTitleBySpecialtyId(int specialtyId)
        {
            Program.con.Open();
            string sql = $"select title from specialty where id = {specialtyId}";
            NpgsqlCommand cmd = new(sql, Program.con);
            string result = (string)cmd.ExecuteScalar();
            Program.con.Close();
            return result;
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isProgramEvent)
                return;
            Program.con.Open();
            string sql = $"update application set status = '{comboBoxStatus.GetItemText(comboBoxStatus.SelectedItem)}' where id = {applicationId}";
            NpgsqlCommand cmd = new(sql, Program.con);
            cmd.ExecuteNonQuery();
            Program.con.Close();
        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            if (isProgramEvent)
                return;
            Program.con.Open();
            string sql = $"update application set commentary = '{textBoxComment.Text}' where id = {applicationId}";
            NpgsqlCommand cmd = new(sql, Program.con);
            cmd.ExecuteNonQuery();
            Program.con.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Program.ChangeForm(this, new WorkerForm());
        }
    }
}
