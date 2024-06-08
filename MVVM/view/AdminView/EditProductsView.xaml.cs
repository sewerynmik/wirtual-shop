using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view.AdminView
{
    public partial class EditProductsView : UserControl
    {
        private int productId;

        public EditProductsView(int id)
        {
            productId = id;
            InitializeComponent();
            DataContext = this;
            LoadProductData(id);
        }

        public Przedmioty SelectedProduct { get; set; } = new Przedmioty();

        private void LoadProductData(int id)
        {
            var sql = "SELECT * FROM \"przedmioty\" WHERE \"przedmiot_id\" = :id";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("id", id));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var cenaString = reader.GetString(3);
                        
                            var cena = JsonSerializer.Deserialize<Cena>(cenaString);

                            SelectedProduct = new Przedmioty
                            {
                                PrzedmiotId = reader.GetInt32(0),
                                Nazwa = reader.GetString(1),
                                ProducentId = reader.GetInt32(2),
                                Cena = cena,
                                Kategoria = reader.GetString(4)
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
                UpdateProduct();
                MessageBox.Show("Produkt został zaktualizowany.");
                App.MainVm.CurrentView = new ProductsView();
            }
        }

        private bool ValidateFields()
        {
            var nazwaT = (TextBox)Nazwa.Template.FindName("input", Nazwa);
            var nazwa = nazwaT.Text;

            var cenaXT = (TextBox)CenaX.Template.FindName("input", CenaX);
            var cenaX = cenaXT.Text;

            var cenaYT = (TextBox)CenaY.Template.FindName("input", CenaY);
            var cenaY = cenaYT.Text;

            var kategoriaT = (TextBox)Kategoria.Template.FindName("input", Kategoria);
            var kategoria = kategoriaT.Text;

            if (string.IsNullOrEmpty(nazwa) || nazwa.Length < 3)
            {
                MessageBox.Show("Nazwa produktu musi mieć co najmniej 3 znaki.");
                return false;
            }

            if (string.IsNullOrEmpty(cenaX))
            {
                MessageBox.Show("Nieprawidłowa cena.");
                return false;
            }

            if (string.IsNullOrEmpty(cenaY))
            {
                MessageBox.Show("Nieprawidłowa cena.");
                return false;
            }

            if (string.IsNullOrEmpty(kategoria))
            {
                MessageBox.Show("Kategoria nie może być pusta.");
                return false;
            }

            if (SelectedProduct.ProducentId <= 0)
            {
                MessageBox.Show("Wybierz poprawnego producenta.");
                return false;
            }

            return true;
        }

        private void UpdateProduct()
        {
            try
            {
                var nazwaT = (TextBox)Nazwa.Template.FindName("input", Nazwa);
                var cenaXT = (TextBox)CenaX.Template.FindName("input", CenaX);
                var cenaYT = (TextBox)CenaY.Template.FindName("input", CenaY);
                var kategoriaT = (TextBox)Kategoria.Template.FindName("input", Kategoria);

                var sql = "UPDATE \"przedmioty\" SET \"nazwa\" = :nazwa, \"producent_id\" = :producentId, \"cena\" = CENA(:cenaX, :cenaY), \"kategoria\" = :kategoria WHERE \"przedmiot_id\" = :id";
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("nazwa", nazwaT.Text));
                    command.Parameters.Add(new OracleParameter("producentId", SelectedProduct.ProducentId));
                    command.Parameters.Add(new OracleParameter("cenaX", cenaXT.Text));
                    command.Parameters.Add(new OracleParameter("cenaY", cenaYT.Text));
                    command.Parameters.Add(new OracleParameter("kategoria", kategoriaT.Text));
                    command.Parameters.Add(new OracleParameter("id", productId));

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
            App.MainVm.CurrentView = new ProductsView();
        }
    }
}
