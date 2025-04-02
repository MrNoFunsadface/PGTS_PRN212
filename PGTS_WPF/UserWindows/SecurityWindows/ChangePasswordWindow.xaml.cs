using BLL.DTOs;
using BLL.Services.Interfaces;
using PGTS_WPF.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace PGTS_WPF.UserWindows.SecurityWindows
{
    /// <summary>
    /// Interaction logic for ResetPasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        private readonly IUserService _userService;
        private readonly UserSession _userSession;

        public ChangePasswordWindow(IUserService userService, UserSession userSession)
        {
            InitializeComponent();
            _userService = userService;
            _userSession = userSession;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var currentPassword = txtPassword.Password;
            var newPassword = txtNewPassword.Password;
            var confirmPassword = txtConfirmNewPassword.Password;

            var resetPassword = new UserResetPasswordDTO
            {
                Password = newPassword,
                ConfirmPassword = confirmPassword,
            };

            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(resetPassword);
            bool isValid = Validator.TryValidateObject(resetPassword, context, validationResults, true);

            if (!isValid)
            {
                string errors = string.Join(Environment.NewLine, validationResults.Select(vr => vr.ErrorMessage));
                MessageBox.Show($"Validation failed:\n{errors}");
                return;
            }

            if (currentPassword != _userSession.UserResponse.Password)
            {
                MessageBox.Show("Wrong old password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var response = _userService.ChangePassword(_userSession.UserResponse.Id, resetPassword);

            if (response.Success)
            {
                MessageBox.Show(response.Message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
