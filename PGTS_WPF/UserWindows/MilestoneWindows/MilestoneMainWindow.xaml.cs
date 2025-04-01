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

namespace PGTS_WPF.UserWindows.MilestoneWindows
{
    /// <summary>
    /// Interaction logic for MilestoneMainWindow.xaml
    /// </summary>
    public partial class MilestoneMainWindow : Window
    {
        private readonly int _projectId;
        private readonly IPregnancyService _pregnancyService;
        private readonly IMilestoneService _milestoneService;
        private readonly IWindowManager _windowManager;
        private List<MilestoneResponseDTO> _milestoneList;

        public MilestoneMainWindow(int projectId, IPregnancyService pregnancyService, IMilestoneService milestoneService, IWindowManager windowManager)
        {
            InitializeComponent();
            _projectId = projectId;
            _pregnancyService = pregnancyService;
            _milestoneService = milestoneService;
            _windowManager = windowManager;
            LoadMilestoneData();
        }

        private void LoadMilestoneData(string? search = "", DateOnly? date = null)
        {
            _milestoneList = _milestoneService.GetByPregnancyId(_projectId, search, date).Data.ToList();
            MilestoneGrid.ItemsSource = _milestoneList;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            DateOnly? date = null;

            if (dpDate.SelectedDate.HasValue)
            {
                date = DateOnly.FromDateTime(dpDate.SelectedDate.Value);
            }

            LoadMilestoneData(search, date);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement CreateMilestoneWindow

            /*
            _windowManager.ShowDialog<CreateMilestoneWindow>();
            btnSearch_Click(sender, e);
            */
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement EditMilestoneWindow

            /*
            var button = sender as Button;
            if (button != null)
            {
                var milestoneId = button.Tag;
                _windowManager.ShowDialog<EditMilestoneWindow>(milestoneId);
                btnSearch_Click(sender, e);
            }
            */
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement DeleteMilestoneWindow

            /*
            var button = sender as Button;
            if (button != null)
            {
                var milestoneId = button.Tag;
                _windowManager.ShowDialog<DeleteMilestoneWindow>(milestoneId);
                btnSearch_Click(sender, e);
            }
            */
        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<MilestoneChartWindow>(_milestoneList);
        }
    }
}
