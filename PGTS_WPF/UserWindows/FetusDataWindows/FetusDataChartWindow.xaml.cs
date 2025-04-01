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
using Color = ScottPlot.Color;
using System.Drawing;

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
            WeightPlot.Plot.Add.Scatter(dates.Select(d => d.ToOADate()).ToArray(), weights, Color.FromHex("#FFB6B9"));
            WeightPlot.Plot.Title("Weight Over Time");
            WeightPlot.Plot.Axes.Title.Label.Bold = true;
            WeightPlot.Plot.Axes.Title.Label.FontSize = 32;
            WeightPlot.Plot.Axes.DateTimeTicksBottom();
            WeightPlot.Plot.XLabel("Date");
            WeightPlot.Plot.Axes.Left.Label.Bold = true;
            WeightPlot.Plot.YLabel("Weight (kg)");
            WeightPlot.Plot.Axes.Bottom.Label.Bold = true;

            WeightPlot.Plot.Add.Palette = new ScottPlot.Palettes.PastelWheel();

            // change figure colors
            WeightPlot.Plot.FigureBackground.Color = Color.FromHex("#B3E5FC");
            WeightPlot.Plot.DataBackground.Color = Color.FromHex("#FAF3E0");

            // change axis and grid colors
            WeightPlot.Plot.Axes.Color(Color.FromHex("#F09EA2"));
            WeightPlot.Plot.Grid.MajorLineColor = Color.FromHex("#FFDAB9");

            // change legend colors
            WeightPlot.Plot.Legend.BackgroundColor = Color.FromHex("#FAF3E0");
            WeightPlot.Plot.Legend.FontColor = Color.FromHex("#FFB6B9");
            WeightPlot.Plot.Legend.OutlineColor = Color.FromHex("#C1E1C1");

            WeightPlot.Refresh();

            // Height Chart
            var heights = _fetusData.Select(fd => fd.Height).ToArray();
            HeightPlot.Plot.Add.Scatter(dates.Select(d => d.ToOADate()).ToArray(), heights, Color.FromHex("#FFB6B9"));
            HeightPlot.Plot.Title("Height Over Time");
            HeightPlot.Plot.Axes.Title.Label.Bold = true;
            HeightPlot.Plot.Axes.Title.Label.FontSize = 32;
            HeightPlot.Plot.Axes.DateTimeTicksBottom();
            HeightPlot.Plot.XLabel("Date");
            HeightPlot.Plot.Axes.Left.Label.Bold = true;
            HeightPlot.Plot.YLabel("Height (cm)");
            HeightPlot.Plot.Axes.Bottom.Label.Bold = true;

            HeightPlot.Plot.Add.Palette = new ScottPlot.Palettes.PastelWheel();

            // change figure colors
            HeightPlot.Plot.FigureBackground.Color = Color.FromHex("#B3E5FC");
            HeightPlot.Plot.DataBackground.Color = Color.FromHex("#FAF3E0");

            // change axis and grid colors
            HeightPlot.Plot.Axes.Color(Color.FromHex("#F09EA2"));
            HeightPlot.Plot.Grid.MajorLineColor = Color.FromHex("#FFDAB9");

            // change legend colors
            HeightPlot.Plot.Legend.BackgroundColor = Color.FromHex("#FAF3E0");
            HeightPlot.Plot.Legend.FontColor = Color.FromHex("#FFB6B9");
            HeightPlot.Plot.Legend.OutlineColor = Color.FromHex("#C1E1C1");

            HeightPlot.Refresh();

            // Head Circumference Chart
            var headCircumferences = _fetusData.Select(fd => fd.HeadCircumference).ToArray();
            HeadCircumferencePlot.Plot.Add.Scatter(dates.Select(d => d.ToOADate()).ToArray(), headCircumferences, Color.FromHex("#FFB6B9"));
            HeadCircumferencePlot.Plot.Title("Head Circumference Over Time");
            HeadCircumferencePlot.Plot.Axes.Title.Label.Bold = true;
            HeadCircumferencePlot.Plot.Axes.Title.Label.FontSize = 32;
            HeadCircumferencePlot.Plot.Axes.DateTimeTicksBottom();
            HeadCircumferencePlot.Plot.XLabel("Date");
            HeadCircumferencePlot.Plot.Axes.Left.Label.Bold = true;
            HeadCircumferencePlot.Plot.YLabel("Head Circumference (cm)");
            HeadCircumferencePlot.Plot.Axes.Bottom.Label.Bold = true;

            HeadCircumferencePlot.Plot.Add.Palette = new ScottPlot.Palettes.PastelWheel();

            // change figure colors
            HeadCircumferencePlot.Plot.FigureBackground.Color = Color.FromHex("#B3E5FC");
            HeadCircumferencePlot.Plot.DataBackground.Color = Color.FromHex("#FAF3E0");

            // change axis and grid colors
            HeadCircumferencePlot.Plot.Axes.Color(Color.FromHex("#F09EA2"));
            HeadCircumferencePlot.Plot.Grid.MajorLineColor = Color.FromHex("#FFDAB9");

            // change legend colors
            HeadCircumferencePlot.Plot.Legend.BackgroundColor = Color.FromHex("#FAF3E0");
            HeadCircumferencePlot.Plot.Legend.FontColor = Color.FromHex("#FFB6B9");
            HeadCircumferencePlot.Plot.Legend.OutlineColor = Color.FromHex("#C1E1C1");

            HeadCircumferencePlot.Refresh();
        }
    }
}
