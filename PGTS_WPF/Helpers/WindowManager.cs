using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace PGTS_WPF.Helper
{
    public class WindowManager : IWindowManager
    {
        private readonly IServiceProvider _serviceProvider;
        private Window _currentWindow;

        public WindowManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CloseCurrentWindow()
        {
            _currentWindow?.Close();
            _currentWindow = null;
        }


        public void ShowDialog<T>(params object[] parameters) where T : Window
        {
            var window = (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), parameters);
            window.ShowDialog();
        }

        public void ShowWindow<T>(EventHandler onClosed = null, params object[] parameters) where T : Window
        {
            _currentWindow = (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), parameters);
            if (onClosed != null)
            {
                _currentWindow.Closed += onClosed;
            }
            _currentWindow.Show();
        }

        private void ShutdownApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
