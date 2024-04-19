using System.Windows;
using System.Windows.Input;

namespace bazy3;

public partial class Producent : Window
{
    public Producent()
    {
        InitializeComponent();
    }

    private void Quit(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Producent_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    private void Minimalise(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
}