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
using BLL.DTOs;
using ScottPlot;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PGTS_WPF.UserWindows.FetusDataWindows
{
    /// <summary>
    /// Interaction logic for FetusDataChartWindow.xaml
    /// </summary>
    public partial class FetusDataChartWindow : Window
    {
        private readonly List<FetusDataResponseDTO> _fetusData;
        public FetusDataChartWindow(List<FetusDataResponseDTO> fetusData)
        {
            InitializeComponent();
            _fetusData = fetusData;
            LoadCharts();
        }

        private void LoadCharts()
        {
            var dates = _fetusData.Select(fd => fd.Date.ToDateTime(TimeOnly.MinValue)).ToArray();

            // Weight Chart
            var weights = _fetusData.Select(fd => fd.Weight).ToArray();
            WeightPlot.Plot.Add.Scatter(dates.Select(d => d.ToOADate()).ToArray(), weights);
            WeightPlot.Plot.Title("Weight Over Time");
            WeightPlot.Plot.Axes.DateTimeTicksBottom();
            WeightPlot.Plot.YLabel("Weight (kg)");
            WeightPlot.Refresh();

            // Height Chart
            //var heights = fetusData.Select(fd => fd.Height).ToArray();
            //HeightPlot.Plot.AddScatter(dates.Select(d => d.ToOADate()).ToArray(), heights);
            //HeightPlot.Plot.Title("Height Over Time");
            //HeightPlot.Plot.XAxis.DateTimeFormat(true);
            //HeightPlot.Plot.YLabel("Height (cm)");
            //HeightPlot.Refresh();

            //// Head Circumference Chart
            //var headCircumferences = fetusData.Select(fd => fd.HeadCircumference).ToArray();
            //HeadCircumferencePlot.Plot.AddScatter(dates.Select(d => d.ToOADate()).ToArray(), headCircumferences);
            //HeadCircumferencePlot.Plot.Title("Head Circumference Over Time");
            //HeadCircumferencePlot.Plot.XAxis.DateTimeFormat(true);
            //HeadCircumferencePlot.Plot.YLabel("Head Circumference (cm)");
            //HeadCircumferencePlot.Refresh();
        }
    }
}
