using PGTS_WPF.Helper;
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
