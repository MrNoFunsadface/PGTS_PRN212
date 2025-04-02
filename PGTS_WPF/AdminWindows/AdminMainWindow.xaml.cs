using BLL.Services.Interfaces;
using PGTS_WPF.AdminWindows.UserRequestsWindows;
using PGTS_WPF.AdminWindows.UsersManagementWindows;
using PGTS_WPF.AuthenticationWindows;
using PGTS_WPF.Helper;
using PGTS_WPF.Helpers;
using System.Windows;

namespace PGTS_WPF.AdminWindows
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private readonly IUserService _userService;
        private readonly UserSession _userSession;
        private readonly IWindowManager _windowManager;

        public AdminMainWindow(IUserService userService, UserSession userSession, IWindowManager windowManager)
        {
            InitializeComponent();
            _userService = userService;
            _userSession = userSession;
            _windowManager = windowManager;
            LoadUserData();
        }
        private void LoadUserData()
        {
            var user = _userService.GetById(_userSession.UserResponse.Id).Data;

            if (user != null)
            {
                _userSession.UserResponse = user;
            }

            WelcomeTextBlock.Text = $"Welcome, {_userSession.UserResponse.Name}";
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowWindow<UsersManagementWindow>();
        }

        private void btnRequests_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowWindow<UserRequestsMainWindow>();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowWindow<LoginWindow>();
            Close();
        }
    }
}
