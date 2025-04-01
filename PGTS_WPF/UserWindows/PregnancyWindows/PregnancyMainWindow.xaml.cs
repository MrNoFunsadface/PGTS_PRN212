using BLL.DTOs;
using BLL.Services.Interfaces;
using PGTS_WPF.Helper;
using PGTS_WPF.UserWindows.FetusDataWindows;
using PGTS_WPF.UserWindows.MilestoneDataWindows;
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

namespace PGTS_WPF.UserWindows.PregnancyWindows
{
    /// <summary>
    /// Interaction logic for PregnancyMainWindow.xaml
    /// </summary>
    public partial class PregnancyMainWindow : Window
    {
        private readonly IPregnancyService _pregnancyService;
        private readonly IWindowManager _windowManager;
        private List<PregnancyResponseDTO> _pregnanciesList;
        private readonly IMilestoneService _milestoneDataService;

        public PregnancyMainWindow(IPregnancyService pregnancyService, IWindowManager windowManager)
        {
            InitializeComponent();
            _pregnancyService = pregnancyService;
            _windowManager = windowManager;
            LoadPregnancies();
        }

        private void LoadPregnancies(DateOnly? from = null, DateOnly? to = null)
        {
            _pregnanciesList = _pregnancyService.GetAll(from, to).Data.ToList();
            PregnanciesDataGrid.ItemsSource = _pregnanciesList;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
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

            LoadPregnancies(from, to);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<CreatePregnancyWindow>();
            btnSearch_Click(sender, e);
        }

        private void btnGrowth_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var pregnancyId = button.Tag;
                _windowManager.ShowDialog<FetusDataMainWindow>(pregnancyId);
                btnSearch_Click(sender, e);
            }
        }

        private void btnMilestones_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var pregnancyId = button.Tag;
                _windowManager.ShowDialog<MilestoneDataWindow>(pregnancyId);
                btnSearch_Click(sender, e);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var pregnancyId = button.Tag;
                _windowManager.ShowDialog<EditPregnancyWindow>(pregnancyId);
                btnSearch_Click(sender, e);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var pregnancyId = button.Tag;
                _windowManager.ShowDialog<DeletePregnancyWindow>(pregnancyId);
                btnSearch_Click(sender, e);
            }
        }
    }
}
