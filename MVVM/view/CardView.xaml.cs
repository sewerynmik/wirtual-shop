using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Oracle.ManagedDataAccess.Client;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace bazy3.MVVM.view
{
    public partial class CardView : UserControl
    {
        public ObservableCollection<CardData> CardList2 { get; } = new ObservableCollection<CardData>();

        public CardView()
        {
            InitializeComponent();
            LoadDataFromDatabase();
            CardItemsControl.ItemsSource = CardList2;
        }

        private void LoadDataFromDatabase()
        {
            for (int i = App.ShopBag.Count - 1; i >= 0; i--)
            {
                string sql = $"SELECT * FROM \"karty\" WHERE \"producent_id\" = " + App.ShopBag[i] + "";



                try
                {
                    using (var command = new OracleCommand(sql, App.Con))
                    {
                        using (var reader = command.ExecuteReader())
                        { 
                            while (reader.Read())
                            {
                                CardList2.Add(new CardData
                                {
                                    Id = reader.GetInt32(0),
                                    Nazwa = reader.GetString(1),
                                    Producent = reader.GetString(2),
                                    Cena = reader.GetDecimal(3),
                                    Ilosc = reader.GetInt32(4)
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

        private void usun(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;

            App.ShopBag.Remove(id);

            App.MainVm.CurrentView = new CardView();
        }
    }
}