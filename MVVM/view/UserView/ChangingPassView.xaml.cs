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
            var sql = $"SELECT \"haslo\" FROM \"login\" WHERE \"klient_id\" = :userId";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("userId", App.UserId));
                    
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var passbox = (PasswordBox)Oldpass.Template.FindName("input", Oldpass);
                            var newpass = (PasswordBox)Newpass.Template.FindName("input", Newpass);
                            var newpass2 = (PasswordBox)Newpass2.Template.FindName("input", Newpass2);

                            if (reader.GetString(0) != passbox.Password)
                            {
                                Mess.Text = "Podano nieprawidłowe hasło";
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

                            sql = "BEGIN EDITPASS(:pass, :userId); END;";
                            using (var updateCommand = new OracleCommand(sql, App.Con))
                            {
                                updateCommand.Parameters.Add(new OracleParameter("pass", newpass.Password));
                                updateCommand.Parameters.Add(new OracleParameter("userId", App.UserId));
                                
                                updateCommand.ExecuteNonQuery();
                            }

                            var optionvm = new OptionsViewModel();
                            App.MainVm.CurrentView = optionvm;
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
