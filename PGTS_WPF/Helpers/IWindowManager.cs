using System.Windows;

namespace PGTS_WPF.Helper
{
    public interface IWindowManager
    {
        void ShowWindow<T>(EventHandler onClosed = null, params object[] parameters) where T : Window;
        void ShowDialog<T>(params object[] parameters) where T : Window;
        void CloseCurrentWindow();
    }
}
