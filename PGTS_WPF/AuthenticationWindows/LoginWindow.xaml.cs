using BLL.DTOs;
using BLL.Services.Interfaces;
using PGTS_WPF.AdminWindows;
using PGTS_WPF.Helper;
using PGTS_WPF.Helpers;
using PGTS_WPF.UserWindows;
using System.Windows;

namespace PGTS_WPF.AuthenticationWindows
{
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;
        private readonly UserSession _userSession;
        private readonly IWindowManager _windowManager;

        public LoginWindow(IUserService userService, IWindowManager windowManager, UserSession userSession)
        {
            InitializeComponent();
            _userService = userService;
            _windowManager = windowManager;
            _userSession = userSession;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text;
            var password = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email cannot be empty.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty.");
                return;
            }

            var userAuth = new UserLoginDTO
            {
                Email = email,
                Password = password
            };

            var response = _userService.Login(userAuth);

            if (response.Success)
            {
                MessageBox.Show(response.Message, "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                _userSession.UserResponse = response.Data;

                if (response.Data.isAdmin)
                {
                    _windowManager.ShowWindow<AdminMainWindow>();
                }
                else
                {
                    _windowManager.ShowWindow<UserMainWindow>();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowWindow<RegisterWindow>();
        }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

    }
}
