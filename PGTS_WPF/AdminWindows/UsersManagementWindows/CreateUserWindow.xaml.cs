using BLL.DTOs;
using BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace PGTS_WPF.AdminWindows.UsersManagementWindows
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private readonly IUserService _userService;

        public CreateUserWindow(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var email = txtEmail.Text;
            var password = txtPassword.Password;
            var confirmPassword = txtConfirmPassword.Password;
            var phone = txtPhone.Text;
            var status = cboStatus.SelectedIndex;
            var admin = cboAdmin.SelectedIndex;

            var user = new UserRequestDTO
            {
                Name = name,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                Phone = phone,
                isActive = status == 0 ? true : false,
                isAdmin = admin == 0 ? true : false
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
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
