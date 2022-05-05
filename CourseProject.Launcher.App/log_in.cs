using CourseProject.DB.Interaction;

namespace CourseProject.Launcher.App
{
    public partial class log_in : Form
    {

        private readonly DBMediator _dbMediator;

        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _dbMediator = new DBMediator("Data Source=DESKTOP-HV204LL;Initial Catalog=museum;Integrated Security=true;");
        }

        private void log_in_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private async void btnEnter_click(object sender, EventArgs e)
        {
            try
            {
                var userLogin = textBox_login.Text;
                var userPassword = textBox_password.Text;

                if (string.IsNullOrEmpty(userLogin) || string.IsNullOrEmpty(userPassword))
                {
                    MessageBox.Show(this, "TODO");
                    return;
                }

                var authResult = await _dbMediator.AuthenticateAsync(userLogin, userPassword);

                if (!authResult)
                {
                    MessageBox.Show(this, "Упс, такого аккаунта не существет", "Аккаунт не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(this, "Поздравляем! Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: main application form startup
            }
            finally
            {
                textBox_password.Text = string.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox_login.Text = textBox_password.Text = string.Empty;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign_up frm_sign = new sign_up();
            frm_sign.FormClosed += (sender, eventArgs) =>
            {
                Show();
            };

            Hide();

            frm_sign.ShowDialog(this);
        }

    }
}