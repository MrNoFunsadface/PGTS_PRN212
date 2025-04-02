using BLL.Services.Interfaces;
using PGTS_WPF.Helpers;
using System.Windows;

namespace PGTS_WPF.UserWindows.SecurityWindows
{
    /// <summary>
    /// Interaction logic for DeleteAccountWindow.xaml
    /// </summary>
    public partial class DeleteAccountWindow : Window
    {
        private readonly IUserService _userService;
        private readonly UserSession _userSession;

        public DeleteAccountWindow(IUserService userService, UserSession userSession)
        {
            InitializeComponent();
            _userService = userService;
            _userSession = userSession;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            var response = _userService.Delete(_userSession.UserResponse.Id);
            if (response.Success)
            {

                MessageBox.Show("You will no longer be able to log in.", "Deleted Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Windows.Cast<Window>().ToList().ForEach(window => window.Close());
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Deleted Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
