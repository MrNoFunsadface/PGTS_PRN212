using BLL.DTOs;
using BLL.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace PGTS_WPF.UserWindows.FetusDataWindows
{
    /// <summary>
    /// Interaction logic for CreateFetusDataWindow.xaml
    /// </summary>
    public partial class CreateFetusDataWindow : Window
    {
        private readonly int _pregnancyId;
        private readonly IFetusDataService _fetusDataService;

        public CreateFetusDataWindow(int pregnancyId, IFetusDataService fetusDataService)
        {
            InitializeComponent();
            _pregnancyId = pregnancyId;
            _fetusDataService = fetusDataService;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            decimal weight;
            decimal height;
            decimal headCircumference;
            var date = dpDate.SelectedDate;

            if (!decimal.TryParse(txtWeight.Text, out weight))
            {
                MessageBox.Show("Weight must be a decimal.");
                return;
            }

            if (!decimal.TryParse(txtHeight.Text, out height))
            {
                MessageBox.Show("Height must be a decimal.");
                return;
            }

            if (!decimal.TryParse(txtHeadCircumference.Text, out headCircumference))
            {
                MessageBox.Show("Head Circumference must be a decimal.");
                return;
            }

            if (!date.HasValue)
            {
                MessageBox.Show("Date is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var fetus = new FetusDataRequestDTO
            {
                PregnancyId = _pregnancyId,
                Weight = weight,
                Height = height,
                HeadCircumference = headCircumference,
                Date = DateOnly.FromDateTime(date.Value)
            };

            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(fetus);
            bool isValid = Validator.TryValidateObject(fetus, context, validationResults, true);

            if (!isValid)
            {
                string errors = string.Join(Environment.NewLine, validationResults.Select(vr => vr.ErrorMessage));
                MessageBox.Show($"Validation failed:\n{errors}");
                return;
            }

            var response = _fetusDataService.Add(fetus);
            if (response.Success)
            {
                MessageBox.Show(response.Message, "Fetus Data Added", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Fetus Data Add Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
