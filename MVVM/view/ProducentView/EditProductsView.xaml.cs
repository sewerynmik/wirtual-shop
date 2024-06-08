using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view.ProducentView
{
    public partial class EditProductsView : UserControl
    {
        private int itemID;
        public EditProductsView(int id)
        {
            itemID = id;
            InitializeComponent();
            DataContext = this;
            LoadDataFromDatabase(id);
            LoadProducents();
        }

        public Przedmioty SelectedProduct { get; set; } = new();
        public Collection<Producenci> ProducentsList { get; set; } = new();

        private void LoadDataFromDatabase(int id)
        {
            var sql = "SELECT * FROM \"przedmioty\" WHERE \"przedmiot_id\" = :id";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("id", id));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cenaString = reader.GetString(3);
                            var cena = JsonSerializer.Deserialize<Cena>(cenaString);

                            var kategoria = reader.GetString(4);

                            SelectedProduct = new Przedmioty
                            {
                                PrzedmiotId = reader.GetInt32(0),
                                Nazwa = reader.GetString(1),
                                ProducentId = reader.GetInt32(2),
                                Cena = cena,
                                Kategoria = kategoria
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

        private void LoadProducents()
        {
            var sql = $"SELECT \"producent_id\", \"nazwa\" FROM \"producenci\"";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProducentsList.Add(new Producenci()
                            {
                                ProducentId = reader.GetInt32(0),
                                Nazwa = reader.GetString(1),
                            });
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
                UpdateProduct();
                MessageBox.Show("Przedmiot został zaktualizowany.");
                App.MainVm.CurrentView = new MyProductsView();
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne dane.");
            }
        }
        
        private bool ValidateFields()
        {
            var nazwaT = (TextBox)Nazwa.Template.FindName("input", Nazwa);
            var cenaXT = (TextBox)CenaX.Template.FindName("input", CenaX);
            var cenaYT = (TextBox)CenaY.Template.FindName("input", CenaY);
            var kategoriaT = (TextBox)Kategoria.Template.FindName("input", Kategoria);

            if (string.IsNullOrWhiteSpace(nazwaT.Text) || string.IsNullOrWhiteSpace(cenaXT.Text) || string.IsNullOrWhiteSpace(cenaYT.Text) || string.IsNullOrWhiteSpace(kategoriaT.Text))
            {
                MessageBox.Show("Wszystkie pola są wymagane.");
                return false;
            }
            
            if (!decimal.TryParse(cenaXT.Text, out _))
            {
                MessageBox.Show("Pierwsza wartość musi być liczbą.");
                return false;
            }

            if (cenaYT.Text.Length > 3)
            {
                MessageBox.Show("Waluta nie może mieć więcej niż 3 litery.");
                return false;
            }

            return true;
        }


        
        private void UpdateProduct()
        {
            try
            {
                var nazwaT = (TextBox)Nazwa.Template.FindName("input", Nazwa);
                var nazwa = nazwaT.Text;
                
                var cenaXT = (TextBox)CenaX.Template.FindName("input", CenaX);
                var cenaX = cenaXT.Text;
                
                var cenaYT = (TextBox)CenaY.Template.FindName("input", CenaY);
                var cenaY = cenaYT.Text;
                
                var kategoriaT = (TextBox)Kategoria.Template.FindName("input", Kategoria);
                var kategoria = kategoriaT.Text;
                
                var sql = "UPDATE \"przedmioty\" SET \"nazwa\" = :nazwa, \"cena\" = CENA(:cenaX, :cenaY), \"kategoria\" = :kategoria WHERE \"przedmiot_id\" = :id";
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("nazwa", nazwa));
                    command.Parameters.Add(new OracleParameter("cenaX", cenaX));
                    command.Parameters.Add(new OracleParameter("cenaY", cenaY));
                    command.Parameters.Add(new OracleParameter("kategoria", kategoria));
                    command.Parameters.Add(new OracleParameter("id", itemID));

                    Console.WriteLine(SelectedProduct.Cena.X);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji produktu: " + exception.Message);
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.MainVm.CurrentView = new MyProductsView();
        }
    }
}
