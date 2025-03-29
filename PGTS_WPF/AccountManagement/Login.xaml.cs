using System.Windows;
using BLL.Services.Interfaces;
using PGTS_WPF.User;

namespace PGTS_WPF.AccountManagement
{
    public partial class Login : Window
    {
        private readonly IUserService _userService;

        public Login()
        {
            InitializeComponent();
            _userService = (IUserService)App.ServiceProvider.GetService(typeof(IUserService));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text;
            var password = txtPassword.Password;

            var user = _userService.Login(email, password);
            if (user != null)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Registration register = new Registration();
            register.Show();
            Close();
        }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

    }
}
