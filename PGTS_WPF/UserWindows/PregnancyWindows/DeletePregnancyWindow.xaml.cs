using BLL.Services.Interfaces;
using System.Windows;

namespace PGTS_WPF.UserWindows.PregnancyWindows
{
    /// <summary>
    /// Interaction logic for DeletePregnancyWindow.xaml
    /// </summary>
    public partial class DeletePregnancyWindow : Window
    {
        private readonly int _pregnancyId;
        private readonly IPregnancyService _pregnancyService;

        public DeletePregnancyWindow(int pregnancyId, IPregnancyService pregnancyService)
        {
            InitializeComponent();
            _pregnancyId = pregnancyId;
            _pregnancyService = pregnancyService;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            var response = _pregnancyService.Delete(_pregnancyId);
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
