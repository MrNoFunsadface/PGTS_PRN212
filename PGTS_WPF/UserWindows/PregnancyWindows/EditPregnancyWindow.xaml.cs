using BLL.DTOs;
using BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace PGTS_WPF.UserWindows.PregnancyWindows
{
    /// <summary>
    /// Interaction logic for EditPregnancyWindow.xaml
    /// </summary>
    public partial class EditPregnancyWindow : Window
    {
        private readonly int _pregnancyId;
        private readonly IPregnancyService _pregnancyService;

        public EditPregnancyWindow(int pregnancyId, IPregnancyService pregnancyService)
        {
            InitializeComponent();
            _pregnancyId = pregnancyId;
            _pregnancyService = pregnancyService;
            LoadPregnancyData();
        }

        private void LoadPregnancyData()
        {
            var pregnancy = _pregnancyService.GetById(_pregnancyId).Data;
            dpConceptionDate.SelectedDate = pregnancy.ConceptionDate.ToDateTime(TimeOnly.MinValue);
            dpDueDate.SelectedDate = pregnancy.DueDate.ToDateTime(TimeOnly.MinValue);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var conceptionDate = dpConceptionDate.SelectedDate;
            var dueDate = dpDueDate.SelectedDate;

            if (!conceptionDate.HasValue)
            {
                MessageBox.Show("Conception Date is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var pregnancy = new PregnancyRequestDTO
            {
                ConceptionDate = DateOnly.FromDateTime(conceptionDate.Value),
                DueDate = dueDate.HasValue ? DateOnly.FromDateTime(dueDate.Value) : DateOnly.FromDateTime(conceptionDate.Value.AddMonths(9)),
                UserId = _pregnancyService.GetById(_pregnancyId).Data.UserId
            };

            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(pregnancy);
            bool isValid = Validator.TryValidateObject(pregnancy, context, validationResults, true);

            if (!isValid)
            {
                string errors = string.Join(Environment.NewLine, validationResults.Select(vr => vr.ErrorMessage));
                MessageBox.Show($"Validation failed:\n{errors}");
                return;
            }

            var response = _pregnancyService.Update(_pregnancyId, pregnancy);
            if (response.Success)
            {
                MessageBox.Show(response.Message, "Updated Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Updated Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
