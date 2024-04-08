using System;
using System.Windows;
using System.Windows.Input;

namespace bazy3
{
    public partial class User2 : Window
    {
        public User2()
        {
            InitializeComponent();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void User2_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void minimalise(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}