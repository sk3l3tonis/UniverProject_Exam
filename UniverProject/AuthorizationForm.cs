using Npgsql;

namespace UniverProject
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Поля не могут быть пусты!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Program.con.Open();
            string sql = $"select id from public.user where login = '{textBoxLogin.Text}' and password = '{textBoxPassword.Text}'";
            NpgsqlCommand cmd = new(sql, Program.con);
            int? userId = (int?)cmd.ExecuteScalar();
            if (userId == null)
            {
                MessageBox.Show("Неверный логин или пароль!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Program.con.Close();
                return;
            }
            sql = $"select id_user_group from public.user where id = {userId}";
            cmd = new(sql, Program.con);
            int idUserGroup = (int)cmd.ExecuteScalar();
            Program.con.Close();
            Form form = (idUserGroup == 1) ? new RegistrationEnrolleeForm(userId) : new WorkerForm();
            Program.ChangeForm(this, form);

        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            Program.ChangeForm(this, new RegistrationEnrolleeForm());
        }
    }
}
