using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Shapes;
using BLL.DTOs;
using ScottPlot;

namespace PGTS_WPF.UserWindows.MilestoneWindows
{
    public partial class MilestoneChartWindow : Window
    {
        private readonly List<MilestoneResponseDTO> _milestones;

        // Constructor that initializes the window and sets up the milestones
        public MilestoneChartWindow(List<MilestoneResponseDTO> milestones)
        {
            InitializeComponent();
            _milestones = milestones;
            LoadMilestoneChart(); // Load chart after the milestones are set
        }

        // Load the milestone chart
        private void LoadMilestoneChart()
        {
            // Prepare the milestone dates and indices (for plotting purposes)
            var dates = _milestones.Select(m => m.Date.ToDateTime(TimeOnly.MinValue)).ToArray();
            var indices = Enumerable.Range(1, dates.Length).Select(i => (double)i).ToArray();

            // Convert dates to OADate format for plotting (date values for x-axis)
            double[] xValues = dates.Select(d => d.ToOADate()).ToArray();
            double[] yValues = indices.ToArray(); // Indices for y-values

            // Add scatter points, annotations, horizontal lines, and customize the axes
            
            AddHorizontalLines(xValues, indices);
            AddScatterPoints(xValues, yValues);
            AddAnnotations(dates, indices);
            CustomizeAxes(); // Customize the axes for the plot
            MilestonePlot.Refresh(); // Refresh the plot to display the changes
        }

        // Add horizontal lines for each milestone to span the graph
        private void AddHorizontalLines(double[] xValues, double[] indices)
        {
            double xMin = xValues.Min(); // Get minimum x-value (start of x-axis)
            double xMax = xValues.Max(); // Get maximum x-value (end of x-axis)

            // Loop through all milestones and add a horizontal line at each y-value
            for (int i = 0; i < _milestones.Count; i++)
            {
                var y = indices[i]; // Get the y-value for the current milestone
                // Create a horizontal line from the min x-value to the max x-value at the current y-position
                var line = MilestonePlot.Plot.Add.Line(xMin, y, xMax, y);
                line.LineStyle.Color = ScottPlot.Color.FromHex("#FFDAB9"); // Set the line color
                line.LineStyle.Width = 1; // Set line width
            }
        }

        // Add scatter points to the plot
        private void AddScatterPoints(double[] xValues, double[] yValues)
        {
            var scatter = MilestonePlot.Plot.Add.Scatter(xValues, yValues, ScottPlot.Color.FromHex("#FF6F61"));
            scatter.LineStyle.Width = 0; // Set line width to 0 (only markers visible)
            scatter.MarkerStyle.Size = 20; // Adjust marker size
            scatter.MarkerStyle.Shape = ScottPlot.MarkerShape.FilledCircle; // Set marker shape to filled circle
        }

        // Add annotations for each milestone
        private void AddAnnotations(DateTime[] dates, double[] indices)
        {
            // Loop through all milestones and add corresponding annotations (text labels)
            for (int i = 0; i < _milestones.Count; i++)
            {
                var text = MilestonePlot.Plot.Add.Text(
                    _milestones[i].Descriptions, // Use the description of the milestone as the label
                    x: dates[i].ToOADate() + 5, // Position slightly to the right of the date
                    y: indices[i] + 0.2 // Slightly offset vertically for spacing
                );

                // Customize the appearance of the annotations
                text.LabelFontSize = 16; // Set font size
                text.LabelFontColor = ScottPlot.Color.FromHex("#FF6F61"); // Set text color
                text.LabelBackgroundColor = ScottPlot.Color.FromHex("#FAF3E0"); // Set background color
            }
        }

        // Customize the axes for the plot
        private void CustomizeAxes()
        {
            MilestonePlot.Plot.Title("Pregnancy Milestone Timeline"); // Set the plot title
            MilestonePlot.Plot.XLabel("Date"); // Set the x-axis label
            MilestonePlot.Plot.YLabel("Milestone Events"); // Set the y-axis label

            // Get a reference to the bottom axis (x-axis)
            var bottomAxis = MilestonePlot.Plot.Axes.Bottom;

            // Set the tick generator for the bottom axis to DateTimeAutomatic
            bottomAxis.TickGenerator = new ScottPlot.TickGenerators.DateTimeAutomatic();

            // Prepare milestone dates and labels for custom ticks
            double[] milestoneDates = _milestones.Select(m => m.Date.ToDateTime(TimeOnly.MinValue).ToOADate()).ToArray();
            string[] milestoneLabels = _milestones.Select(m => m.Date.ToDateTime(TimeOnly.MinValue).ToString("MMM dd, yyyy")).ToArray();

            // Set custom ticks for the x-axis based on the milestone dates and labels
            bottomAxis.SetTicks(milestoneDates, milestoneLabels);

            // Rotate the labels by 45 degrees to prevent overlap
            MilestonePlot.Plot.Axes.Bottom.TickLabelStyle.Rotation = 25; // Rotate labels by 25 degrees
            MilestonePlot.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.UpperLeft;

            // Making the left and right axes invisible
            MilestonePlot.Plot.Axes.Left.IsVisible = false;
            MilestonePlot.Plot.Axes.Right.IsVisible = false;

            // Customize appearance of axis labels (make them bold)
            MilestonePlot.Plot.Axes.Bottom.Label.Bold = true;

            // Customize the grid lines appearance
            MilestonePlot.Plot.Grid.LineWidth = 1; // Adjust grid line width
            MilestonePlot.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#FFDAB9"); // Set grid line color
        }
    }
}