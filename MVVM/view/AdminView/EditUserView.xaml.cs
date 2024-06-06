using System;
using System.Windows;
using System.Windows.Controls;
using Oracle.ManagedDataAccess.Client;
using bazy3.Entities;

namespace bazy3.MVVM.view.AdminView
{
    public partial class EditUserView : UserControl
    {
        private int userId;
        
        public EditUserView(int id)
        {
            userId = id;
            InitializeComponent();
            DataContext = this;
            LoadUserData(id);
        }

        public Klienci SelectedUser { get; set; } = new Klienci();
        
        private void LoadUserData(int id)
        {
            var sql = "SELECT * FROM \"klienci\" WHERE \"klient_id\" = :id";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("id", id));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("keks");

                            SelectedUser = new Klienci
                            {
                                KlientId = reader.GetInt32(0),
                                Imie = reader.GetString(1),
                                Nazwisko = reader.GetString(2),
                                Pesel = reader.GetInt64(3),
                                Email = reader.GetString(4),
                                NrTel = reader.GetInt64(5)
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
                UpdateUser();
                MessageBox.Show("Dane klienta zostały zaktualizowane.");
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
        
        private void UpdateUser()
        {
            try
            {
                var imieT = (TextBox)Imie.Template.FindName("input", Imie);
                var nazwiskoT = (TextBox)Nazwisko.Template.FindName("input", Nazwisko);
                var peselT = (TextBox)Pesel.Template.FindName("input", Pesel);
                var emailT = (TextBox)Email.Template.FindName("input", Email);
                var nrTelT = (TextBox)NrTel.Template.FindName("input", NrTel);

                var sql = "UPDATE \"klienci\" SET \"imie\" = :imie, \"nazwisko\" = :nazwisko, \"pesel\" = :pesel, \"email\" = :email, \"nr_tel\" = :nrTel WHERE \"klient_id\" = :id";
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("imie", imieT.Text));
                    command.Parameters.Add(new OracleParameter("nazwisko", nazwiskoT.Text));
                    command.Parameters.Add(new OracleParameter("pesel", peselT.Text));
                    command.Parameters.Add(new OracleParameter("email", emailT.Text));
                    command.Parameters.Add(new OracleParameter("nrTel", nrTelT.Text));
                    command.Parameters.Add(new OracleParameter("id", userId));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji danych klienta: " + exception.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.MainVm.CurrentView = new UsersView();
        }
    }
}
