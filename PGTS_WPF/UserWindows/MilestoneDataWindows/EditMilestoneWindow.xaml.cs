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

namespace PGTS_WPF.UserWindows.MilestoneDataWindows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditMilestoneWindow : Window
    {
        private  int _pregnancyId;
        private readonly int _milestoneId;
        private readonly IMilestoneService _milestoneService;
        private readonly UserSession _userSession;
        public EditMilestoneWindow( int milestoneId,  IMilestoneService milestoneService, UserSession userSession)
        {
            InitializeComponent();
            _milestoneId = milestoneId;
            _milestoneService = milestoneService;
            _userSession = userSession;
            LoadMilestoneData();
        }

        private void LoadMilestoneData()
        {
            var milestone = _milestoneService.GetById(_milestoneId).Data;
            dpDate.SelectedDate = milestone.Date.ToDateTime(TimeOnly.MinValue);
            txtDescription.Text = milestone.Description;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var milestoneDate = dpDate.SelectedDate;
            var milestoneDescription = txtDescription.Text;

            var milestone = new MilestoneRequestDTO
            {
                PregnancyId = _pregnancyId,
                Date = DateOnly.FromDateTime(milestoneDate.Value),
                Descriptions = milestoneDescription,
            };

            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(milestone);
            bool isValid = Validator.TryValidateObject(milestone, context, validationResults, true);

            if (!isValid)
            {
                MessageBox.Show(validationResults[0].ErrorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var response = _milestoneService.Update(_milestoneId, milestone);
            if (response.Success)
            {
                MessageBox.Show("Milestone updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
