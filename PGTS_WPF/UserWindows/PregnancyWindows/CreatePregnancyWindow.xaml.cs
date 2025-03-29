using AutoMapper.Execution;
using BLL.DTOs;
using BLL.Services.Interfaces;
using PGTS_WPF.Helpers;
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

namespace PGTS_WPF.UserWindows.PregnancyWindows
{
    /// <summary>
    /// Interaction logic for CreatePregnancyWindow.xaml
    /// </summary>
    public partial class CreatePregnancyWindow : Window
    {
        private readonly IPregnancyService _pregnancyService;
        private readonly UserSession _userSession;

        public CreatePregnancyWindow(IPregnancyService pregnancyService, UserSession userSession)
        {
            InitializeComponent();
            _pregnancyService = pregnancyService;
            _userSession = userSession;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
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
                UserId = _userSession.UserResponse.Id
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

            var response = _pregnancyService.Add(pregnancy);
            if (response.Success)
            {
                MessageBox.Show(response.Message, "Created Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }
            else
            {
                MessageBox.Show(response.Message, "Created Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
