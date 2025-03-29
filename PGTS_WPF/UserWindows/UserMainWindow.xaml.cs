using BLL.Services.Interfaces;
using PGTS_WPF.Helper;
using PGTS_WPF.Helpers;
using System.Windows;

namespace PGTS_WPF.UserWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        private readonly IUserService _userService;
        private readonly UserSession _userSession;
        private readonly IWindowManager _windowManager;

        public UserMainWindow(IUserService userService, IWindowManager windowManager, UserSession userSession)
        {
            InitializeComponent();
            _userService = userService;
            _windowManager = windowManager;
            _userSession = userSession;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            var user = _userService.GetById(_userSession.UserResponse.Id).Data;

            if (user != null)
            {
                _userSession.UserResponse = user;
            }

            WelcomeTextBlock.Text = $"Welcome, {_userSession.UserResponse.Name}";
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnSecurity_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnPregnancies_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnMilestones_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnGrowthChart_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }
    }
}
