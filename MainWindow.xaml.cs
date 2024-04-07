using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Oracle.ManagedDataAccess.Client;

namespace bazy3
{
    public partial class MainWindow
    {
        //private OracleConnection _con;

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
            Close();
        }

        private void Log(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)Login.Template.FindName("Loginek", Login);
            var lo = textBox.Text;
            var textBox2 = (PasswordBox)Pass.Template.FindName("Haselko", Pass);
            var ps = textBox2.Password;

            var sql = $"SELECT \"active\", \"klient_id\" FROM \"login\" WHERE \"login\" = '{lo}' AND \"haslo\" = '{ps}'";

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
                            
                            switch (active)
                            {
                                case "T":
                                    User2 user = new User2();
                                    user.InitializeComponent();
                                    user.Show();
                                    Close();
                                    break;
                            }
                        }
                        else
                        {
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
    }
}