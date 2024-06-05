using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Oracle.ManagedDataAccess.Client;
using System.Windows;
using bazy3.Entities;


namespace bazy3.MVVM.view.AdminView;

public partial class OrdersView : UserControl
{
    public OrdersView()
    {
        InitializeComponent();
        LoadDataFromDatabase();
        ItemsControl.ItemsSource = OrdersList;
    }
    
    public ObservableCollection<Zamowienia> OrdersList { get; } = new();

    private void LoadDataFromDatabase()
    {
        var sql = "SELECT * FROM \"zamowienia\"";
        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        OrdersList.Add(new Zamowienia
                        {
                            ZamowienieId = reader.GetInt32(0),
                            NrZamowienia = reader.GetInt64(1),
                            KlienitId = reader.GetInt32(2),
                            Data = reader.GetDateTime(4)
                        });
                }
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}