using System;
using System.Windows;
using System.Windows.Controls;
using bazy3.MVVM.viewModel;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view
{
    public partial class ChangingPassView : UserControl
    {
        public ChangingPassView()
        {
            InitializeComponent();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT \"haslo\" FROM LOGIN WHERE \"klient_id\" = '{App.UserId}'";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        
                        var passbox = (PasswordBox)Oldpass.Template.FindName("haselko", Oldpass);
                        var newpass = (PasswordBox)Newpass.Template.FindName("haselko", Newpass);
                        var newpass2 = (PasswordBox)Newpass2.Template.FindName("haselko", Newpass2);
                        
                        if (reader.GetString(0) != passbox.Password)
                        {
                            Mess.Text = "Podano niprawidłowe hasło";
                            Mess.Opacity = 1;
                            return;
                        }
                        if (newpass.Password != newpass2.Password)
                        {
                            Mess.Text = "Nowe hasła nie są takie same";
                            Mess.Opacity = 1;
                            return;
                        }

                        if (newpass.Password.Length < 7)
                        {
                            Mess.Text = "Hasło jest za krótkie";
                            Mess.Opacity = 1;
                            return;
                        }
                        
                        sql = $"UPDATE LOGIN SET \"haslo\" = '{newpass.Password}' WHERE \"klient_id\" = '{App.UserId}'";
                        using (var updateCommand = new OracleCommand(sql, App.Con))
                        {
                            updateCommand.ExecuteNonQuery();
                        }

                        var optionvm = new OptionsViewModel();
                        App.MainVm.CurrentView = optionvm;
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