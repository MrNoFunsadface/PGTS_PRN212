﻿using BLL.Services.Interfaces;
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

namespace PGTS_WPF.AdminWindows.UserRequestsWindows
{
    /// <summary>
    /// Interaction logic for ActivateUserWindow.xaml
    /// </summary>
    public partial class ActivateUserWindow : Window
    {
        private readonly int _userId;
        private readonly IUserService _userService;

        public ActivateUserWindow(int userId, IUserService userService)
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

                MessageBox.Show(response.Message, "Activate Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Activate Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
