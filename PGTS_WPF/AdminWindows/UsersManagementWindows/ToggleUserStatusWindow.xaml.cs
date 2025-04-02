using BLL.Services.Interfaces;
using System.Windows;

namespace PGTS_WPF.AdminWindows.UsersManagementWindows
{
    /// <summary>
    /// Interaction logic for ToggleUserStatusWindow.xaml
    /// </summary>
    public partial class ToggleUserStatusWindow : Window
    {
        private readonly int _userId;
        private readonly IUserService _userService;

        public ToggleUserStatusWindow(int userId, IUserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            var response = _userService.ToggleStatus(_userId);
            if (response.Success)
            {

                MessageBox.Show(response.Message, "Toggled Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Toggled Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
                return;
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
