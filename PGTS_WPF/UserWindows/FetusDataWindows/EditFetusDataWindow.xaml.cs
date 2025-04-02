using BLL.DTOs;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Interaction logic for EditFetusDataWindow.xaml
    /// </summary>
    public partial class EditFetusDataWindow : Window
    {
        private readonly int _fetusId;
        private readonly IFetusDataService _fetusDataService;

        public EditFetusDataWindow(int fetusId, IFetusDataService fetusDataService)
        {
            InitializeComponent();
            _fetusId = fetusId;
            _fetusDataService = fetusDataService;
            LoadFetusData();
        }

        private void LoadFetusData()
        {
            var fetus = _fetusDataService.GetById(_fetusId).Data;
            txtWeight.Text = fetus.Weight.ToString();
            txtHeight.Text = fetus.Height.ToString();
            txtHeadCircumference.Text = fetus.HeadCircumference.ToString();
            dpDate.SelectedDate = fetus.Date.ToDateTime(TimeOnly.MinValue);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
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
                PregnancyId = _fetusDataService.GetById(_fetusId).Data.PregnancyId,
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

            var response = _fetusDataService.Update(_fetusId, fetus);
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
