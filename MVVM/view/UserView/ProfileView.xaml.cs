using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using bazy3.Entities;
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

    public ObservableCollection<Zam_prze> OrderList { get; } = new();

    public void LoadDataFromDatabase()
    {
        string sql = $"SELECT * FROM ZAM WHERE \"klient_id\" =" + App.UserId;

        try
        {
            using (OracleCommand command = new OracleCommand(sql,App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        OrderList.Add(new Zam_prze()
                        {
                            IdZam = reader.GetInt32(0),
                            IdPrze = reader.GetInt32(1)
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
}