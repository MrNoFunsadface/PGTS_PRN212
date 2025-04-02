using BLL.DTOs;
using BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace PGTS_WPF.UserWindows.MilestoneWindows
{
    /// <summary>
    /// Interaction logic for CreateMilestoneWindow.xaml
    /// </summary>
    public partial class CreateMilestoneWindow : Window
    {
        private readonly int _pregnancyId;
        private readonly IMilestoneService _milestoneService;

        public CreateMilestoneWindow(int pregnancyId, IMilestoneService milestoneService)
        {
            InitializeComponent();
            _pregnancyId = pregnancyId;
            _milestoneService = milestoneService;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var descriptions = txtDescriptions.Text;
            var date = dpDate.SelectedDate;

            if (!date.HasValue)
            {
                MessageBox.Show("Date is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var milestone = new MilestoneRequestDTO
            {
                PregnancyId = _pregnancyId,
                Descriptions = descriptions,
                Date = DateOnly.FromDateTime(date.Value)
            };

            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(milestone);
            bool isValid = Validator.TryValidateObject(milestone, context, validationResults, true);

            if (!isValid)
            {
                string errors = string.Join(Environment.NewLine, validationResults.Select(vr => vr.ErrorMessage));
                MessageBox.Show($"Validation failed:\n{errors}");
                return;
            }

            var response = _milestoneService.Add(milestone);
            if (response.Success)
            {
                MessageBox.Show(response.Message, "Milestone Added", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Milestone Add Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
