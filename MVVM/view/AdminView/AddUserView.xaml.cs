using System;
using System.Text.RegularExpressions;
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
        }

        private bool ValidateFields()
        {
            var imieT = (TextBox)Imie.Template.FindName("input", Imie);
            var nazwiskoT = (TextBox)Nazwisko.Template.FindName("input", Nazwisko);
            var peselT = (TextBox)Pesel.Template.FindName("input", Pesel);
            var emailT = (TextBox)Email.Template.FindName("input", Email);
            var nrTelT = (TextBox)NrTel.Template.FindName("input", NrTel);

            var loginT = (TextBox)Login.Template.FindName("input", Login);
            var hasloPB = (PasswordBox)Haslo.Template.FindName("input", Haslo);
            var haslo = hasloPB.Password;

            if (string.IsNullOrEmpty(imieT.Text) || imieT.Text.Length < 3)
            {
                MessageBox.Show("Imię musi mieć co najmniej 3 znaki.");
                return false;
            }

            if (string.IsNullOrEmpty(nazwiskoT.Text) || nazwiskoT.Text.Length < 3)
            {
                MessageBox.Show("Nazwisko musi mieć co najmniej 3 znaki.");
                return false;
            }

            if (!Regex.IsMatch(peselT.Text, @"^\d{11}$"))
            {
                MessageBox.Show("PESEL musi składać się z 11 cyfr.");
                return false;
            }

            if (!Regex.IsMatch(emailT.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Wprowadź poprawny adres email.");
                return false;
            }

            if (!Regex.IsMatch(nrTelT.Text, @"^\d{9}$"))
            {
                MessageBox.Show("Numer telefonu musi składać się z 9 cyfr.");
                return false;
            }

            if (string.IsNullOrEmpty(loginT.Text) || loginT.Text.Length < 3)
            {
                MessageBox.Show("Login musi mieć co najmniej 3 znaki.");
                return false;
            }

            if (string.IsNullOrEmpty(haslo) || haslo.Length < 6)
            {
                MessageBox.Show("Hasło musi mieć co najmniej 6 znaków.");
                return false;
            }

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

                var sqlClient = "BEGIN ADDUSER(:imie, :nazwisko, :pesel, :email, :nrTel, :login, :haslo); END;";
                using (var command = new OracleCommand(sqlClient, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("imie", imieT.Text));
                    command.Parameters.Add(new OracleParameter("nazwisko", nazwiskoT.Text));
                    command.Parameters.Add(new OracleParameter("pesel", peselT.Text));
                    command.Parameters.Add(new OracleParameter("email", emailT.Text));
                    command.Parameters.Add(new OracleParameter("nrTel", nrTelT.Text));
                    command.Parameters.Add(new OracleParameter("login", loginT.Text));
                    command.Parameters.Add(new OracleParameter("haslo", haslo));
                    
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania klienta i logowania: " + exception.Message);
            }
        }
        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.MainVm.CurrentView = new UsersView();
        }
    }
}
