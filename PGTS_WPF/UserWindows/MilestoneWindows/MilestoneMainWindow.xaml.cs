using BLL.DTOs;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using PGTS_WPF.Helper;
using PGTS_WPF.UserWindows.FetusDataWindows;
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
        private readonly int _pregnancyId;
        private readonly IMilestoneService _milestoneService;
        private readonly IWindowManager _windowManager;
        private List<MilestoneResponseDTO> _milestoneList;

        public MilestoneMainWindow(int pregnancyId, IMilestoneService milestoneService, IWindowManager windowManager)
        {
            InitializeComponent();
            _pregnancyId = pregnancyId;
            _milestoneService = milestoneService;
            _windowManager = windowManager;
            LoadMilestoneData();
        }

        private void LoadMilestoneData(string? search = "", DateOnly? from = null, DateOnly? to = null)
        {
            _milestoneList = _milestoneService.GetByPregnancyId(_pregnancyId, search, from, to).Data.ToList();
            MilestoneDataGrid.ItemsSource = _milestoneList;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            DateOnly? from = null;
            DateOnly? to = null;

            if (dpFrom.SelectedDate.HasValue)
            {
                from = DateOnly.FromDateTime(dpFrom.SelectedDate.Value);
            }
            if (dpTo.SelectedDate.HasValue)
            {
                to = DateOnly.FromDateTime(dpTo.SelectedDate.Value);
            }

            LoadMilestoneData(search, from, to);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<CreateMilestoneWindow>(_pregnancyId);
            btnSearch_Click(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var milestoneId = button.Tag;
                _windowManager.ShowDialog<EditFetusDataWindow>(milestoneId);
                btnSearch_Click(sender, e);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var milestoneId = button.Tag;
                _windowManager.ShowDialog<DeleteFetusDataWindow>(milestoneId);
                btnSearch_Click(sender, e);
            }
        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<FetusDataChartWindow>(_milestoneList);
        }
    }
}
