using BLL.DTOs;
using BLL.Services.Interfaces;
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

namespace PGTS_WPF.AdminWindows.UsersManagementWindows
{
    /// <summary>
    /// Interaction logic for UsersManagementWindow.xaml
    /// </summary>
    public partial class UsersManagementWindow : Window
    {
        private readonly IUserService _userService;
        private readonly IWindowManager _windowManager;
        private List<UserResponseDTO>? _userList;

        public UsersManagementWindow(IUserService userService, IWindowManager windowManager)
        {
            InitializeComponent();
            _userService = userService;
            _windowManager = windowManager;
            LoadUsers();
        }

        private void LoadUsers(string search = null)
        {
            _userList = _userService.GetAll(search).Data.ToList();
            UsersDataGrid.ItemsSource = _userList;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txtSearch.Text;
            LoadUsers(searchText);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<CreateUserWindow>();
            btnSearch_Click(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var userId = button.Tag;
                _windowManager.ShowDialog<EditUserWindow>(userId);
                btnSearch_Click(sender, e);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var userId = button.Tag;
                _windowManager.ShowDialog<DeleteUserWindow>(userId);
                btnSearch_Click(sender, e);
            }
        }
    }
}
