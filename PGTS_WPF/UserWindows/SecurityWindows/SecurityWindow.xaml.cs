using PGTS_WPF.Helper;
using System.Windows;

namespace PGTS_WPF.UserWindows.SecurityWindows
{
    /// <summary>
    /// Interaction logic for SecurityWindow.xaml
    /// </summary>
    public partial class SecurityWindow : Window
    {
        private readonly IWindowManager _windowManager;

        public SecurityWindow(IWindowManager windowManager)
        {
            InitializeComponent();
            _windowManager = windowManager;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<ChangePasswordWindow>();
        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<DeleteAccountWindow>();
        }
    }
}
