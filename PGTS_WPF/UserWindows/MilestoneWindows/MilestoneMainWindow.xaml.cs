using BLL.DTOs;
using BLL.Services.Interfaces;
using PGTS_WPF.Helper;
using System.Windows;
using System.Windows.Controls;

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
                _windowManager.ShowDialog<EditMilestoneWindow>(milestoneId);
                btnSearch_Click(sender, e);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var milestoneId = button.Tag;
                _windowManager.ShowDialog<DeleteMilestoneWindow>(milestoneId);
                btnSearch_Click(sender, e);
            }
        }
    }
}
