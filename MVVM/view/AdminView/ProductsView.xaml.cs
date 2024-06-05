using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace bazy3.MVVM.view.AdminView;

public partial class ProductsView : UserControl
{
    public ProductsView()
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

    private void Del(object sender, RoutedEventArgs e)
    {
        var id = (int)((Button)sender).CommandParameter;

        okno win = new okno(id);
        win.ShowDialog();
    }
}