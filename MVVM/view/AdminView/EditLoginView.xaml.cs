using System;
using System.Windows;
using System.Windows.Controls;
using Oracle.ManagedDataAccess.Client;
using bazy3.Entities;

namespace bazy3.MVVM.view.AdminView
{
    public partial class EditLoginView : UserControl
    {
        private int loginId;
        
        public EditLoginView(int id)
        {
            loginId = id;
            InitializeComponent();
            DataContext = this;
            LoadLoginData(id);
        }

        public Login SelectedLogin { get; set; } = new Login();
        
        private void LoadLoginData(int id)
        {
            var sql = "SELECT * FROM \"login\" WHERE \"klient_id\" = :id";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("id", id));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SelectedLogin = new Login
                            {
                                LoginId = reader.GetInt32(0),
                                KlientId = reader.GetInt32(1),
                                LoginName = reader.GetString(2),
                                Haslo = reader.GetString(3),
                            };
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                UpdateLogin();
                MessageBox.Show("Dane logowania zostały zaktualizowane.");
                App.MainVm.CurrentView = new UsersView(); 
            }
        }
        
        private bool ValidateFields()
        {
            var loginT = (TextBox)LoginName.Template.FindName("input", LoginName);
            var hasloPB = (TextBox)Haslo.Template.FindName("input", Haslo);

            if (string.IsNullOrEmpty(loginT.Text) || string.IsNullOrEmpty(hasloPB.Text))
            {
                MessageBox.Show("Login i hasło są wymagane.");
                return false;
            }

            return true; 
        }
        
        private void UpdateLogin()
        {
            try
            {
                var loginT = (TextBox)LoginName.Template.FindName("input", LoginName);
                var hasloPB = (TextBox)Haslo.Template.FindName("input", Haslo);

                var sql = "BEGIN EDITLOGIN(:login, :haslo, :id); END;";
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("login", loginT.Text));
                    command.Parameters.Add(new OracleParameter("haslo", hasloPB.Text));
                    command.Parameters.Add(new OracleParameter("id", loginId));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji danych logowania: " + exception.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.MainVm.CurrentView = new UsersView();
        }
    }
}
