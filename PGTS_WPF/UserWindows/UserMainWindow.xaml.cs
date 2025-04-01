using BLL.Services.Interfaces;
using PGTS_WPF.AuthenticationWindows;
using PGTS_WPF.Helper;
using PGTS_WPF.Helpers;
using PGTS_WPF.UserWindows.MilestoneWindows;
using PGTS_WPF.UserWindows.PregnancyWindows;
using PGTS_WPF.UserWindows.SecurityWindows;
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

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<UserProfileWindow>();
            LoadUserData();
        }

        private void btnSecurity_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowWindow<SecurityWindow>();
        }

        private void btnPregnancies_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowWindow<PregnancyMainWindow>();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowWindow<LoginWindow>();
            Close();
        }

    }
}
