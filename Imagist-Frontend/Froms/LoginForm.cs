using Imagist_Library.Apis.UserApi.Register;
using Imagist_Library.Connectivity.Account;
using Imagist_Library.Connectivity.HTTP.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Imagist_Frontend.Froms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationManager _authentication;
        private readonly MainForm _mainForm;
        private readonly AccountClient _accountClient;

        public LoginForm(AuthenticationManager authentication, MainForm mainForm,AccountClient accountClient)
        {
            InitializeComponent();
            this._authentication=authentication;
            _mainForm = mainForm;
            this._accountClient=accountClient;
            registerPanel.Visible = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login();
        }
        private async void Login()
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            if (email == null ||email.Equals("")|| password == null||password.Equals(""))
            {
                MessageTextBox.Text = "请输入邮箱及密码";
                return;
            }

            try
            {
                var response = _authentication.Login(email, password);
                if (response.IsSuccess)
                {
                    _mainForm.InitialDataLoading();
                    _mainForm.Show();
                    _mainForm.Disposed += (sender, args) =>
                    {
                        this.Close();
                    };
                    this.Visible = false;
                }
                else
                {
                    MessageTextBox.Text = response.Msg;
                }
            }
            catch (Exception e)
            {
                MessageTextBox.Text = "服务器连接失败，请检查网络";
            }

        }

        private void GoToRegisterButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            registerPanel.Visible = true;
        }

        private void backToLoginButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
            registerPanel.Visible = false;
        }

        private string registerUserProfilePath;

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            //打开对话框选择文件
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择头像";
            dialog.Filter = PictureFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                registerUserProfilePath = dialog.FileName;
                guna2CirclePictureBox1.Load(dialog.FileName);
            }
        }

        #region
        private string PictureFilter =
        "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff;*.heic|"+
        "Windows Bitmap(*.bmp)|*.bmp|"+
        "Windows Icon(*.ico)|*.ico|"+
        "Graphics Interchange Format (*.gif)|(*.gif)|"+
        "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|"+
        "Portable Network Graphics (*.png)|*.png|"+
        "Tag Image File Format (*.tif)|*.tif;*.tiff";
        #endregion

        private async void registerButton_Click(object sender, EventArgs e)
        {
            var userName = registerUserNameTextBox.Text;
            var password = registerPasswordTextBox.Text;
            var email = registerEmailTextBox.Text;
            var photoPath = registerUserProfilePath;
            try {
                var response = _accountClient.Register(userName, email, password, photoPath);
                MessageTextBox.Text = response.Msg;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                MessageTextBox.Text = "服务器请求失败";
            }
            
            

        }
    }
}
