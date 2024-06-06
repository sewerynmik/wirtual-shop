using System;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view.AdminView
{
    public partial class AddUserView : UserControl
    {
        public AddUserView()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                InsertClientAndLogin();
                MessageBox.Show("Nowy klient i login zostały dodane.");
                App.MainVm.CurrentView = new UsersView();
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne dane.");
            }
        }

        private bool ValidateFields()
        {
            return true;
        }

        private void InsertClientAndLogin()
        {
            try
            {
                var imieT = (TextBox)Imie.Template.FindName("input", Imie);
                var nazwiskoT = (TextBox)Nazwisko.Template.FindName("input", Nazwisko);
                var peselT = (TextBox)Pesel.Template.FindName("input", Pesel);
                var emailT = (TextBox)Email.Template.FindName("input", Email);
                var nrTelT = (TextBox)NrTel.Template.FindName("input", NrTel);

                var loginT = (TextBox)Login.Template.FindName("input", Login);
                var hasloPB = (PasswordBox)Haslo.Template.FindName("input", Haslo);
                var haslo = hasloPB.Password;

                // Wykonaj operacje dodawania klienta do bazy danych
                var sqlClient = "INSERT INTO \"klienci\" (\"imie\", \"nazwisko\", \"pesel\", \"email\", \"nr_tel\") VALUES (:imie, :nazwisko, :pesel, :email, :nrTel)";
                using (var command = new OracleCommand(sqlClient, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("imie", imieT.Text));
                    command.Parameters.Add(new OracleParameter("nazwisko", nazwiskoT.Text));
                    command.Parameters.Add(new OracleParameter("pesel", peselT.Text));
                    command.Parameters.Add(new OracleParameter("email", emailT.Text));
                    command.Parameters.Add(new OracleParameter("nrTel", nrTelT.Text));

                    command.ExecuteNonQuery();
                }

                var klientId = GetLastInsertedClientId();

                var sqlLogin = "INSERT INTO \"login\" (\"klient_id\", \"login\", \"haslo\", \"type\") VALUES (:klientId, :login, :haslo, :type)";
                using (var command = new OracleCommand(sqlLogin, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("klientId", klientId));
                    command.Parameters.Add(new OracleParameter("login", loginT.Text));
                    command.Parameters.Add(new OracleParameter("haslo", haslo));
                    command.Parameters.Add(new OracleParameter("type", 'U')); // Zakładam, że 'U' oznacza typ użytkownika

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania klienta i logowania: " + exception.Message);
            }
        }

        private int GetLastInsertedClientId()
        {
            try
            {
                var sql = "SELECT MAX(\"klient_id\") FROM \"klienci\"";
                using (var command = new OracleCommand(sql, App.Con))
                {
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        // Jeśli nie ma żadnych danych w tabeli klienci, zwracamy wartość 1 jako początkowe klient_id
                        return 1;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas pobierania ostatniego klienta: " + exception.Message);
                // W przypadku błędu, zwracamy wartość 0 jako domyślną
                return 0;
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.MainVm.CurrentView = new UsersView(); // Zakładam, że istnieje UsersView jako widok dla klientów
        }
    }
}
