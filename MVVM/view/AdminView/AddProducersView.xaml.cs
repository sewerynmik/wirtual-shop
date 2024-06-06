using System;
using System.Collections.ObjectModel;
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
                InsertProducer();
                MessageBox.Show("Nowy producent został dodany.");
                App.MainVm.CurrentView = new ProducersView();
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne dane.");
            }
        }

        private bool ValidateFields()
        {
            // Dodaj walidację pól, na przykład sprawdzenie czy pola nie są puste
            return true;
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

                var sql = "INSERT INTO \"producenci\" (\"nazwa\", \"kod_pocztowy\", \"adres\") VALUES (:nazwa, :kodPocztowy, ADRES(:adresX,:adresY))";
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("nazwa", nazwa));
                    command.Parameters.Add(new OracleParameter("kodPocztowy", kodPocztowy));
                    command.Parameters.Add(new OracleParameter("adresx", adresX));
                    command.Parameters.Add(new OracleParameter("adresy", adresY));

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
