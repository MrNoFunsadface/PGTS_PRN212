using BLL.DTOs;
using BLL.Services.Interfaces;
using PGTS_WPF.Helpers;
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

namespace PGTS_WPF.UserWindows
{
    /// <summary>
    /// Interaction logic for UserProfileWindow.xaml
    /// </summary>
    public partial class UserProfileWindow : Window
    {
        private readonly IUserService _userService;
        private readonly UserSession _userSession;

        public UserProfileWindow(IUserService userService, UserSession userSession)
        {
            InitializeComponent();
            _userService = userService;
            _userSession = userSession;
            LoadCurrentData();
        }

        private void LoadCurrentData()
        {
            var user = _userService.GetById(_userSession.UserResponse.Id).Data;
            txtName.Text = user.Name;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var updatedUser = new UserProfileDTO
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
            };

            var userId = _userSession.UserResponse.Id;

            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(updatedUser);
            bool isValid = Validator.TryValidateObject(updatedUser, context, validationResults, true);

            if (!isValid)
            {
                string errors = string.Join(Environment.NewLine, validationResults.Select(vr => vr.ErrorMessage));
                MessageBox.Show($"Validation failed:\n{errors}");
                return;
            }

            var response = _userService.UpdateProfile(userId, updatedUser);
            if (response.Success)
            {
                MessageBox.Show(response.Message, "Updated Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadCurrentData();
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Updated Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
