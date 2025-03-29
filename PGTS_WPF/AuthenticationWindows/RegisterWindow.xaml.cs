using BLL.DTOs;
using BLL.Services.Interfaces;
using PGTS_WPF.Helper;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserService _userService;

        public RegisterWindow(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var email = txtEmail.Text;
            var phone = txtPhone.Text;
            var password = txtPassword.Password;
            var confirmPassword = txtConfirmPassword.Password;

            var user = new UserRequestDTO
            {
                Name = name,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                Phone = phone
            };

            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(user);
            bool isValid = Validator.TryValidateObject(user, context, validationResults, true);

            if (!isValid)
            {
                string errors = string.Join(Environment.NewLine, validationResults.Select(vr => vr.ErrorMessage));
                MessageBox.Show($"Validation failed:\n{errors}");
                return;
            }

            var response = _userService.Register(user);
            if (response.Success)
            {
                MessageBox.Show(response.Message, "Registration Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
