using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view;

public partial class ShopView : UserControl
{
    public ShopView()
    {
        InitializeComponent();
        LoadDataFromDatabase();
        ItemsControl.ItemsSource = CardList;
    }

    public ObservableCollection<CardData> CardList { get; } = new();

    private void LoadDataFromDatabase()
    {
        var sql = "SELECT * FROM \"karty\"";

        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        CardList.Add(new CardData
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
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var id = (int)((Button)sender).CommandParameter;

        App.ShopBag.Add(id);
    }
}

public class CardData
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Producent { get; set; }
    public decimal Cena { get; set; }
    public int Ilosc { get; set; }
}