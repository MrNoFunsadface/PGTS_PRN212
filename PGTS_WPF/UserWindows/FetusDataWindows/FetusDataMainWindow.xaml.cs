using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Entities;
using PGTS_WPF.Helper;
using PGTS_WPF.UserWindows.PregnancyWindows;
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

namespace PGTS_WPF.UserWindows.FetusDataWindows
{
    /// <summary>
    /// Interaction logic for FetusDataMainWindow.xaml
    /// </summary>
    public partial class FetusDataMainWindow : Window
    {
        private readonly int _pregnancyId;
        private readonly IFetusDataService _fetusDataService;
        private readonly IWindowManager _windowManager;
        private List<FetusDataResponseDTO> _fetusList;

        public FetusDataMainWindow(int pregnancyId, IFetusDataService fetusDataService, IWindowManager windowManager)
        {
            InitializeComponent();
            _pregnancyId = pregnancyId;
            _fetusDataService = fetusDataService;
            _windowManager = windowManager;
            LoadFetusData();
        }

        private void LoadFetusData(string? search = "", DateOnly? from = null, DateOnly? to = null)
        {
            _fetusList = _fetusDataService.GetByPregnancyId(_pregnancyId, search, from, to).Data.ToList();
            FetusDataGrid.ItemsSource = _fetusList;
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

            LoadFetusData(search, from, to);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<CreateFetusDataWindow>(_pregnancyId);
            btnSearch_Click(sender, e);
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

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            _windowManager.ShowDialog<FetusDataChartWindow>(_fetusList);
        }
    }
}
