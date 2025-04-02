using BLL.DTOs;
using BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace PGTS_WPF.AuthenticationWindows
{
    /// <summary>
    /// Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : Window
    {
        private readonly IUserService _userService;

        public ForgotPasswordWindow(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnResetPassword_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text;
            var password = txtNewPassword.Password;
            var confirmPassword = txtConfirmNewPassword.Password;

            var resetPassword = new UserResetPasswordDTO
            {
                Password = password,
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

            var response = _userService.ForgotPassword(email, resetPassword);
            if (response.Success)
            {
                MessageBox.Show(response.Message, "Password reset successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Password reset failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
