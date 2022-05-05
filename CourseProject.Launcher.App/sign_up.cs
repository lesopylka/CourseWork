using System;

using CourseProject.DB.Interaction;

namespace CourseProject.Launcher.App
{
    public partial class sign_up : Form
    {

        private readonly DBMediator _dbMediator;

        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _dbMediator = new DBMediator("Data Source=DESKTOP-HV204LL;Initial Catalog=museum;Integrated Security=true;");
        }

        private async void btnCreate_click(object sender, EventArgs e)
        {
            try
            {
                var userLogin = textBox_login2.Text;
                var userPassword = textBox_password2.Text;

                if (string.IsNullOrEmpty(userLogin) || string.IsNullOrEmpty(userPassword))
                {
                    MessageBox.Show(this, "TODO");
                    return;
                }

                var registrationResponse = await _dbMediator.RegisterUserAsync(userLogin, userPassword);

                if (!registrationResponse)
                {
                    MessageBox.Show(this, "Упс! Попробуйте снова создать аккаунт", "Аккаунт не создан");
                    return;
                }

                MessageBox.Show(this, "Поздравляем! Аккаунт успешно создан", "Аккаунт создан");

                Close();
            }
            finally
            {
                textBox_password2.Text = string.Empty;
            }
        }

        [Obsolete]
        private async Task<bool?> CheckUserExistenceAsync(CancellationToken token = default)
        {
            return await _dbMediator.CheckUserExistenceAsync(textBox_login2.Text, token);
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '*';
            textBox_login2.MaxLength = 50;
            textBox_password2.MaxLength = 50;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox_login2.Text = textBox_password2.Text = string.Empty;
        }
    }
}
