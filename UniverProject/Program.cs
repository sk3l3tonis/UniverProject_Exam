using Npgsql; 

namespace UniverProject
{
    internal static class Program
    {
        public static NpgsqlConnection con = new("Host=localhost; port=5432; username=postgres; password=1212321; database=UniversityDB;");
        public static ApplicationContext context = new();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            context.MainForm = new AuthorizationForm();
            Application.Run(context);
        }
        public static void ChangeForm(Form oldForm, Form newForm)
        {
            context.MainForm = newForm;
            newForm.Show();
            oldForm.Hide();
        }
    }
}