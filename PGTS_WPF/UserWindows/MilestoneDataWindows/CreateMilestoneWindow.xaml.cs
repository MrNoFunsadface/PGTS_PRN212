using BLL.DTOs;
using BLL.Services.Interfaces;
using PGTS_WPF.Helper;
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

namespace PGTS_WPF.UserWindows.MilestoneDataWindows
{
    /// <summary>
    /// Interaction logic for CreateMilestoneWindow.xaml
    /// </summary>
    public partial class CreateMilestoneWindow : Window
    {
        private readonly int _pregnancyId;
        private readonly IMilestoneService _milestoneService;
        private readonly UserSession _userSession;
        public CreateMilestoneWindow(int pregnancyId, IMilestoneService milestoneService, UserSession userSession)
        {

            InitializeComponent();
            _pregnancyId = pregnancyId;
            _milestoneService = milestoneService;
            _userSession = userSession;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var milestoneDate = dpDate.SelectedDate;
            var milestoneDescription = txtDescription.Text;

            var milestone = new MilestoneRequestDTO
            {
                Date = DateOnly.FromDateTime(milestoneDate.Value),
                Descriptions = milestoneDescription.ToString(),
                PregnancyId = _pregnancyId,
            };

            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(milestone);
            bool isValid = Validator.TryValidateObject(milestone, context, validationResults, true);

            if (!isValid)
            {
                MessageBox.Show(validationResults[0].ErrorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var response = _milestoneService.Add(milestone);

            if (response.Success)
            {
                MessageBox.Show("Milestone created successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }   
    }
}
