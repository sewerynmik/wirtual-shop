using System.Windows;
using System.Windows.Input;

namespace bazy3;

public partial class Admin : Window
{
    public Admin()
    {
        InitializeComponent();
    }

    private void Quit(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Admin_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    private void minimalise(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
}