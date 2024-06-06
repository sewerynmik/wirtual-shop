using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view.AdminView
{
    public partial class EditProducersView : UserControl
    {
        private int producerId;
        
        public EditProducersView(int id)
        {
            producerId = id;
            InitializeComponent();
            DataContext = this;
            LoadProducerData(id);
        }

        public Producenci SelectedProducer { get; set; } = new Producenci();
        
        private void LoadProducerData(int id)
        {
            var sql = "SELECT * FROM \"producenci\" WHERE \"producent_id\" = :id";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("id", id));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var adresString = reader.GetString(3);
                        
                            var adres = JsonSerializer.Deserialize<Adres>(adresString);
                            
                            SelectedProducer = new Producenci
                            {
                                ProducentId = reader.GetInt32(0),
                                Nazwa = reader.GetString(1),
                                KodPocztowy = reader.GetString(2),
                                Adres = adres
                                
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
                UpdateProducer();
                MessageBox.Show("Producent został zaktualizowany.");
                App.MainVm.CurrentView = new ProducersView();
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
        
        private void UpdateProducer()
        {
            try
            {
                var nazwaT = (TextBox)Nazwa.Template.FindName("input", Nazwa);
                var kodPocztowyT = (TextBox)KodPocztowy.Template.FindName("input", KodPocztowy);
                var adresXT = (TextBox)AdresX.Template.FindName("input", AdresX);
                var adresYT = (TextBox)AdresY.Template.FindName("input", AdresY);

                var sql = "UPDATE \"producenci\" SET \"nazwa\" = :nazwa, \"kod_pocztowy\" = :kodPocztowy, \"adres\" = ADRES(:adresX, :adresY) WHERE \"producent_id\" = :id";
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("nazwa", nazwaT.Text));
                    command.Parameters.Add(new OracleParameter("kodPocztowy", kodPocztowyT.Text));
                    command.Parameters.Add(new OracleParameter("adresX", adresXT.Text));
                    command.Parameters.Add(new OracleParameter("adresY", adresYT.Text));
                    command.Parameters.Add(new OracleParameter("id", producerId));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji producenta: " + exception.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.MainVm.CurrentView = new ProducersView();
        }
    }
}
