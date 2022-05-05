using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class sign_up : Form
    {
        DataBase dataBase = new DataBase();
        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCreate_click(object sender, EventArgs e)
        {
           
            var login = textBox_login2.Text;
            var password = textBox_password2.Text;

            string querystring = $"insert into register(login_user, password_user) values('{login}','{ password}')";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Поздравляем! Аккаунт успешно создан", "Аккаунт создан");
                log_in frm_log = new log_in();
                this.Hide();
                frm_log.ShowDialog();
            }
            else
            {
                MessageBox.Show("Упс! Попробуйте снова создать аккаунт", "Аккаунт не создан");
            }

            dataBase.closeConnection();
        }

        private Boolean checkuser()
        {
            var loginUser = textBox_login2;
            var passUser = textBox_password2;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $" select id_user, login_user, password_user from register login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Такой аккаунт уже существует!");
                return true;
            }
            else
            {
                MessageBox.Show("Успешно создан новый аккаунт!");
                return false;
            }
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '*';
            textBox_login2.MaxLength = 50;
            textBox_password2.MaxLength = 50;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox_login2.Text = "";
            textBox_password2.Text = "";
        }
    }
}
