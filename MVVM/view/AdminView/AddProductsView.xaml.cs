using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view.AdminView
{
    public partial class AddProductsView : UserControl
    {
        public AddProductsView()
        {
            InitializeComponent();
            DataContext = this;
            LoadProducents();
        }

        public Przedmioty NewProduct { get; set; } = new();
        public ObservableCollection<Producenci> ProducentsList { get; set; } = new ObservableCollection<Producenci>();

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
                InsertProduct();
                MessageBox.Show("Nowy przedmiot został dodany.");
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

            if (NewProduct.ProducentId <= 0)
            {
                MessageBox.Show("Wybierz poprawnego producenta.");
                return false;
            }

            return true;
        }

        private void InsertProduct()
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

                var sql = "BEGIN ADDPRODUCT(:nazwa, :producentId, :cenaX, :cenaY, :kategoria); END;";
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("nazwa", nazwa));
                    command.Parameters.Add(new OracleParameter("producentId", NewProduct.ProducentId));
                    command.Parameters.Add(new OracleParameter("cenaX", cenaX));
                    command.Parameters.Add(new OracleParameter("cenaY", cenaY));
                    command.Parameters.Add(new OracleParameter("kategoria", kategoria));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania produktu: " + exception.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.MainVm.CurrentView = new ProductsView();
        }
    }
}
