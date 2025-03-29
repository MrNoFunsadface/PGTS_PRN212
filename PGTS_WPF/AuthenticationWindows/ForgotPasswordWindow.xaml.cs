using BLL.DTOs;
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
