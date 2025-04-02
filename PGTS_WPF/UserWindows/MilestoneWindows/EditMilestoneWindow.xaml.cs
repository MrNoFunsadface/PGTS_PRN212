using BLL.DTOs;
using BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace PGTS_WPF.UserWindows.MilestoneWindows
{
    /// <summary>
    /// Interaction logic for EditMilestoneWindow.xaml
    /// </summary>
    public partial class EditMilestoneWindow : Window
    {
        private readonly int _milestoneId;
        private readonly IMilestoneService _milestoneService;
        public EditMilestoneWindow(int milestoneId, IMilestoneService milestoneService)
        {
            InitializeComponent();
            _milestoneId = milestoneId;
            _milestoneService = milestoneService;
            LoadMilestoneData();
        }

        private void LoadMilestoneData()
        {
            var milestone = _milestoneService.GetById(_milestoneId).Data;
            txtDescriptions.Text = milestone.Descriptions;
            dpDate.SelectedDate = milestone.Date.ToDateTime(TimeOnly.MinValue);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
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
                PregnancyId = _milestoneService.GetById(_milestoneId).Data.PregnancyId,
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

            var response = _milestoneService.Update(_milestoneId, milestone);
            if (response.Success)
            {
                MessageBox.Show(response.Message, "Milestone Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Milestone Update Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
