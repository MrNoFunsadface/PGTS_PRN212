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
            WeightPlot.Plot.Add.Scatter(dates.Select(d => d.ToOADate()).ToArray(), weights, Color.FromHex("#4caf50"));
            WeightPlot.Plot.Title("Weight Over Time");
            WeightPlot.Plot.Axes.DateTimeTicksBottom();
            WeightPlot.Plot.XLabel("Date");
            WeightPlot.Plot.YLabel("Weight (kg)");

            WeightPlot.Plot.Add.Palette = new ScottPlot.Palettes.Penumbra();

            // change figure colors
            WeightPlot.Plot.FigureBackground.Color = Color.FromHex("#181818");
            WeightPlot.Plot.DataBackground.Color = Color.FromHex("#1f1f1f");

            // change axis and grid colors
            WeightPlot.Plot.Axes.Color(Color.FromHex("#d7d7d7"));
            WeightPlot.Plot.Grid.MajorLineColor = Color.FromHex("#404040");

            // change legend colors
            WeightPlot.Plot.Legend.BackgroundColor = Color.FromHex("#404040");
            WeightPlot.Plot.Legend.FontColor = Color.FromHex("#d7d7d7");
            WeightPlot.Plot.Legend.OutlineColor = Color.FromHex("#d7d7d7");

            WeightPlot.Refresh();

            // Height Chart
            var heights = _fetusData.Select(fd => fd.Height).ToArray();
            HeightPlot.Plot.Add.Scatter(dates.Select(d => d.ToOADate()).ToArray(), heights, Color.FromHex("#4caf50"));
            HeightPlot.Plot.Title("Height Over Time");
            HeightPlot.Plot.Axes.DateTimeTicksBottom();
            HeightPlot.Plot.XLabel("Date");
            HeightPlot.Plot.YLabel("Height (cm)");

            HeightPlot.Plot.Add.Palette = new ScottPlot.Palettes.Penumbra();

            // change figure colors
            HeightPlot.Plot.FigureBackground.Color = Color.FromHex("#181818");
            HeightPlot.Plot.DataBackground.Color = Color.FromHex("#1f1f1f");

            // change axis and grid colors
            HeightPlot.Plot.Axes.Color(Color.FromHex("#d7d7d7"));
            HeightPlot.Plot.Grid.MajorLineColor = Color.FromHex("#404040");

            // change legend colors
            HeightPlot.Plot.Legend.BackgroundColor = Color.FromHex("#404040");
            HeightPlot.Plot.Legend.FontColor = Color.FromHex("#d7d7d7");
            HeightPlot.Plot.Legend.OutlineColor = Color.FromHex("#d7d7d7");

            HeightPlot.Refresh();

            // Head Circumference Chart
            var headCircumferences = _fetusData.Select(fd => fd.HeadCircumference).ToArray();
            HeadCircumferencePlot.Plot.Add.Scatter(dates.Select(d => d.ToOADate()).ToArray(), headCircumferences, Color.FromHex("#4caf50"));
            HeadCircumferencePlot.Plot.Title("Head Circumference Over Time");
            HeadCircumferencePlot.Plot.Axes.DateTimeTicksBottom();
            HeadCircumferencePlot.Plot.XLabel("Date");
            HeadCircumferencePlot.Plot.YLabel("Head Circumference (cm)");

            HeadCircumferencePlot.Plot.Add.Palette = new ScottPlot.Palettes.Penumbra();

            // change figure colors
            HeadCircumferencePlot.Plot.FigureBackground.Color = Color.FromHex("#181818");
            HeadCircumferencePlot.Plot.DataBackground.Color = Color.FromHex("#1f1f1f");

            // change axis and grid colors
            HeadCircumferencePlot.Plot.Axes.Color(Color.FromHex("#d7d7d7"));
            HeadCircumferencePlot.Plot.Grid.MajorLineColor = Color.FromHex("#404040");

            // change legend colors
            HeadCircumferencePlot.Plot.Legend.BackgroundColor = Color.FromHex("#404040");
            HeadCircumferencePlot.Plot.Legend.FontColor = Color.FromHex("#d7d7d7");
            HeadCircumferencePlot.Plot.Legend.OutlineColor = Color.FromHex("#d7d7d7");

            HeadCircumferencePlot.Refresh();
        }
    }
}
