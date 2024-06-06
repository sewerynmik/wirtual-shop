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
        
        var deleteZamPrzeSql = $"DELETE FROM \"zam_prze\" WHERE \"id_zam\" = :id";
        try
        {
            using (var command = new OracleCommand(deleteZamPrzeSql, App.Con))
            {
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            return;
        }
        
        var deleteProductSql = $"DELETE FROM \"zamowienia\" WHERE \"zamowienie_id\" = :id";
        try
        {
            using (var command = new OracleCommand(deleteProductSql, App.Con))
            {
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();
            }

            // Usunięcie produktu z listy wyświetlanych produktów
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