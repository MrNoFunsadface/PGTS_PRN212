using BLL.DTOs;
using BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Windows;

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
            var password = txtPassword.Password;
            var confirmPassword = txtConfirmPassword.Password;
            var phone = txtPhone.Text;

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
                Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
