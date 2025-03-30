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

        public PregnancyMainWindow(IPregnancyService pregnancyService, IWindowManager windowManager)
        {
            InitializeComponent();
            _pregnancyService = pregnancyService;
            _windowManager = windowManager;
            LoadPregnancies();
        }

        private void LoadPregnancies(string search = null)
        {
            _pregnanciesList = _pregnancyService.GetAll(search).Data.ToList();
            PregnanciesDataGrid.ItemsSource = _pregnanciesList;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txtSearch.Text;
            LoadPregnancies(searchText);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<CreatePregnancyWindow>();
            LoadPregnancies(txtSearch.Text);
        }

        private void btnGrowth_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnMilestones_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var pregnancyId = button.Tag;
                _windowManager.ShowDialog<EditPregnancyWindow>(pregnancyId);
                LoadPregnancies(txtSearch.Text);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var pregnancyId = button.Tag;
                _windowManager.ShowDialog<DeletePregnancyWindow>(pregnancyId);
                LoadPregnancies(txtSearch.Text);
            }
        }
    }
}
