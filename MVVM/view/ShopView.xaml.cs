using System;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view
{
    public partial class ShopView : UserControl
    {
        public ObservableCollection<CardData> CardList { get; } = new ObservableCollection<CardData>();

        public ShopView()
        {
            InitializeComponent();
            LoadDataFromDatabase();
            ItemsControl.ItemsSource = CardList;
        }

        private void LoadDataFromDatabase()
        {
            string sql = $"SELECT * FROM \"karty\"";

            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CardList.Add(new CardData
                            {
                                Nazwa = reader.GetString(0),
                                Producent = reader.GetString(1),
                                Cena = reader.GetDecimal(2),
                                Ilosc = reader.GetInt32(3)
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
    }

    public class CardData
    {
        public string Nazwa { get; set; }
        public string Producent { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
    }
}