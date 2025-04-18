﻿using BLL.Services.Interfaces;
using System.Windows;

namespace PGTS_WPF.UserWindows.MilestoneWindows
{
    /// <summary>
    /// Interaction logic for DeleteMilestoneWindow.xaml
    /// </summary>
    public partial class DeleteMilestoneWindow : Window
    {
        private readonly int _milestoneId;
        private readonly IMilestoneService _milestoneService;

        public DeleteMilestoneWindow(int milestoneId, IMilestoneService milestoneService)
        {
            InitializeComponent();
            _milestoneId = milestoneId;
            _milestoneService = milestoneService;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            var response = _milestoneService.Delete(_milestoneId);
            if (response.Success)
            {

                MessageBox.Show(response.Message, "Deleted Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
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
