using BLL.Services.Implementations;
using BLL.Services.Interfaces;
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
    /// Interaction logic for DeleteFetusDataWindow.xaml
    /// </summary>
    public partial class DeleteFetusDataWindow : Window
    {
        private readonly int _fetusId;
        private readonly IFetusDataService _fetusDataService;

        public DeleteFetusDataWindow(int fetusId, IFetusDataService fetusDataService)
        {
            InitializeComponent();
            _fetusId = fetusId;
            _fetusDataService = fetusDataService;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            var response = _fetusDataService.Delete(_fetusId);
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
