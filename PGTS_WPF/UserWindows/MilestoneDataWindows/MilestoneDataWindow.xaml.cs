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

namespace PGTS_WPF.UserWindows.MilestoneDataWindows
{
    /// <summary>
    /// Interaction logic for MilestoneDataWindow.xaml
    /// </summary>
    public partial class MilestoneDataWindow : Window
    {
        private readonly int _pregnancyId;
        private readonly IPregnancyService _pregnancyService;
        private readonly IMilestoneService _milestoneDataService;
        private readonly IWindowManager _windowManager;
        private List<MilestoneResponseDTO> _milestoneList;
        
        public MilestoneDataWindow(int pregnancyId, IPregnancyService pregnancyService, IMilestoneService milestoneService, IWindowManager windowManager)       
        {
            InitializeComponent();
            _pregnancyService = pregnancyService;
            _milestoneDataService = milestoneService;
            _windowManager = windowManager;
            _pregnancyId = pregnancyId;
            LoadMilestoneData();
        }
        private void LoadMilestoneData()
        {
       
            _milestoneList = _milestoneDataService.GetAll(_pregnancyId, null, null).Data.ToList();
            MilestoneDataGrid.ItemsSource = _milestoneList;
        }
        public void btnSearch_Click(object sender, RoutedEventArgs e)
        {
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
            _milestoneList = _milestoneDataService.GetAll(_pregnancyId, from, to).Data.ToList();
            MilestoneDataGrid.ItemsSource = _milestoneList;
        }
        public void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<CreateMilestoneWindow>(_pregnancyId);
            LoadMilestoneData();
        }

        public void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        public void MilestoneDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
