using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using bazy3.MVVM.view.UserView;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view;

public partial class ProfileView : UserControl
{
    public ProfileView()
    {
        InitializeComponent();
        LoadDataFromDatabase();
        OrderCollection.ItemsSource = OrderList;
    }

    public ObservableCollection<Zamowienia> OrderList { get; } = new();

    public void LoadDataFromDatabase()
    {
        string sql = $"SELECT \"zamowienie_id\", \"nr_zamowienia\", \"data\"  FROM \"zamowienia\" WHERE \"klient_id\" =" + App.UserId;

        try
        {
            using (OracleCommand command = new OracleCommand(sql,App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        OrderList.Add(new Zamowienia()
                        {
                            ZamowienieId = reader.GetInt32(0),
                            NrZamowienia = reader.GetInt64(1),
                            Data = reader.GetDateTime(2)
                        });
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void SeeOrder(object sender, RoutedEventArgs e)
    {
        var id = (int)((Button)sender).CommandParameter;
        
        var ordeView = new OrderView(id);
        
        App.MainVm.CurrentView = ordeView;
    }
}