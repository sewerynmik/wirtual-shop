using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Oracle.ManagedDataAccess.Client;

namespace bazy3;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        InitializeConnection();
    }

    private void InitializeConnection()
    {
        try
        {
            var builder = new OracleConnectionStringBuilder
            {
                DataSource = "127.0.0.1/freepdb1",
                UserID = "hr",
                Password = "oracle"
            };

            App.Con = new OracleConnection(builder.ConnectionString);
            App.Con.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void Quit(object sender, RoutedEventArgs routedEventArgs)
    {
        Application.Current.Shutdown();
    }

    private void Log(object sender, RoutedEventArgs e)
    {
        var textBox = (TextBox)Login.Template.FindName("input", Login);
        var lo = textBox.Text;
        var textBox2 = (PasswordBox)Pass.Template.FindName("input", Pass);
        var ps = textBox2.Password;

        var sql =
            $"SELECT \"active\", \"klient_id\", \"type\" FROM \"login\" WHERE \"login\" = '{lo}' AND \"haslo\" = '{ps}'";

        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var active = reader.GetString(0);
                        App.UserId = reader.GetInt32(1);
                        var type = reader.GetString(2);

                        if (active == "0")
                        {
                            Info.Text = "Konto jest nieaktywne";
                            Info.Visibility = Visibility.Visible;
                            return;
                        }

                        switch (type)
                        {
                            case "u":
                                var user = new User2();
                                user.InitializeComponent();
                                user.Show();
                                Close();
                                break;
                            case "p":
                                var producent = new Producent();
                                producent.InitializeComponent();
                                producent.Show();
                                Close();
                                break;
                            case "a":
                                var admin = new Admin();
                                admin.InitializeComponent();
                                admin.Show();
                                Close();
                                break;
                        }
                    }
                    else
                    {
                        Info.Text = "Podano nieprawidłowe dane logowania";
                        Info.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }
}