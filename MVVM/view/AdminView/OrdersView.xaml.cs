using System;
using System.Collections.ObjectModel;
using System.Linq;
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
                            Data = reader.GetDateTime(3)
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
        
        var deleteProductSql = $"BEGIN DELZAM(:id); END;";
        try
        {
            using (var command = new OracleCommand(deleteProductSql, App.Con))
            {
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();
            }

            var itemToRemove = OrdersList.FirstOrDefault(item => item.ZamowienieId == id);
            if (itemToRemove != null)
            {
                OrdersList.Remove(itemToRemove);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            return;
        }
    }

}