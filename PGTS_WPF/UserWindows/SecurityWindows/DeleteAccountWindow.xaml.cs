using BLL.Services.Interfaces;
using PGTS_WPF.Helpers;
using System;
using System.Collections.Generic;
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
            var response = _userService.Delete(_userSession.UserResponse.Id, false);
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
