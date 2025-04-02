# Pregnancy Growth Tracking System

## Overview

The Pregnancy Growth Tracking System (PGTS) is a WPF application built using .NET 8. It is designed to help users track and visualize pregnancy-related growth metrics. The application features a modern user interface with MaterialDesignInXAML for theming and uses ScottPlot for rendering interactive graphs.

## Features

- **User-Friendly Interface**: A clean and intuitive UI designed with Material Design.
- **Growth Tracking**: Track various pregnancy-related metrics such as weight, fetal growth, and more.
- **Graphical Visualization**: Generate and view interactive graphs using ScottPlot.
- **Data Management**: Save, update, and manage user data securely.

## Code Structure

The application is organized into the following key components:

- **Views**: Contains XAML files defining the UI layout and design.

- **Models**: Defines the data structures and business logic.
- **Services**: Provides reusable services such as data storage, graph generation, and theme management.
- **Utilities**: Contains helper classes and utility functions.
- **Resources**: Includes styles, templates, and other shared resources.

## Third-Party Libraries

The application leverages the following third-party libraries:

1. **MaterialDesignInXAML**: Provides modern and responsive UI components with Material Design principles.
   - [GitHub Repository](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
2. **ScottPlot**: A plotting library for .NET to create interactive and high-performance graphs.
   - [GitHub Repository](https://github.com/ScottPlot/ScottPlot)

## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or later
- MSSQL 2022 or later

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/PGTS_PRN212.git
   ```
2. Open the solution in Visual Studio.
3. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
4. Build and run the application.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License

This project is licensed under the GPL-3.0 License. See the LICENSE file for details.
