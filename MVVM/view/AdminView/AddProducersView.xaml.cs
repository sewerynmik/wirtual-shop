using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view.AdminView
{
    public partial class AddProducersView : UserControl
    {
        public AddProducersView()
        {
            InitializeComponent();
        }

        public Producenci NewProducer { get; set; } = new();

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                if (IsUniqueProducerName(NewProducer.Nazwa))
                {
                    InsertProducer();
                    MessageBox.Show("Nowy producent został dodany.");
                    App.MainVm.CurrentView = new ProducersView();
                }
                else
                {
                    MessageBox.Show("Producent o takiej nazwie już istnieje.");
                }
            }
        }

        private bool ValidateFields()
        {
            var nazwaT = (TextBox)Nazwa.Template.FindName("input", Nazwa);
            var nazwa = nazwaT.Text;

            var kodPocztowyT = (TextBox)KodPocztowy.Template.FindName("input", KodPocztowy);
            var kodPocztowy = kodPocztowyT.Text;

            var adresXT = (TextBox)AdresX.Template.FindName("input", AdresX);
            var adresX = adresXT.Text;

            var adresYT = (TextBox)AdresY.Template.FindName("input", AdresY);
            var adresY = adresYT.Text;

            if (string.IsNullOrEmpty(nazwa) || nazwa.Length < 3)
            {
                MessageBox.Show("Nazwa producenta musi mieć co najmniej 3 znaki.");
                return false;
            }

            if (!Regex.IsMatch(kodPocztowy, @"^\d{2}-\d{3}$"))
            {
                MessageBox.Show("Kod pocztowy musi mieć format XX-XXX.");
                return false;
            }

            if (!Regex.IsMatch(adresX, @"^[a-zA-Z\s\u0100-\u017F\u00F3\u0119\u0105\u0142]+$"))
            {
                MessageBox.Show("Nierawidłowy adres.");
                return false;
            }

            if (!Regex.IsMatch(adresY, @"^\d+$"))
            {
                MessageBox.Show("Nierawidłowy adres.");
                return false;
            }

            return true;
        }

        private bool IsUniqueProducerName(string name)
        {
            var sql = "SELECT COUNT(*) FROM \"producenci\" WHERE \"nazwa\" = :name";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("name", name));
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    return count == 0;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas sprawdzania unikalności nazwy producenta: " + exception.Message);
                return false;
            }
        }

        private void InsertProducer()
        {
            try
            {
                var nazwaT = (TextBox)Nazwa.Template.FindName("input", Nazwa);
                var nazwa = nazwaT.Text;

                var kodPocztowyT = (TextBox)KodPocztowy.Template.FindName("input", KodPocztowy);
                var kodPocztowy = kodPocztowyT.Text;

                var adresXT = (TextBox)AdresX.Template.FindName("input", AdresX);
                var adresX = adresXT.Text;

                var adresYT = (TextBox)AdresY.Template.FindName("input", AdresY);
                int adresY = Convert.ToInt32(adresYT.Text);

                var sql = "BEGIN ADDPRODUCER(:nazwa, :kodPocztowy, :adresX,:adresY); END;";
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("nazwa", nazwa));
                    command.Parameters.Add(new OracleParameter("kodPocztowy", kodPocztowy));
                    command.Parameters.Add(new OracleParameter("adresX", adresX));
                    command.Parameters.Add(new OracleParameter("adresY", adresY));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania producenta: " + exception.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.MainVm.CurrentView = new ProducersView();
        }
    }
}
