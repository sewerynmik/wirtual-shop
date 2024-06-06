using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view.UserView;

public partial class OrderView : UserControl
{
    private int ZamId;
    public OrderView(int id)
    {
        InitializeComponent();
        ZamId = id;
        LoadDataFromDatabase();
        OrderCollection.ItemsSource = OrderList;
    }
    
    public ObservableCollection<zam_prze_data_view> OrderList { get; } = new();
    
    public void LoadDataFromDatabase()
    {
        string sql = $"SELECT * FROM \"zam_prze_data_view\" WHERE \"id_zam\" = "+ ZamId;

        try
        {
            using (OracleCommand command = new OracleCommand(sql,App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cenaString = reader.GetString(4);
                        var cena = JsonSerializer.Deserialize<Cena>(cenaString);

                        var kategoria = reader.GetString(5);
                        var kategoria2 = $"../../../images/{kategoria}.png";

                        OrderList.Add(new zam_prze_data_view()
                        {
                            IdZam = reader.GetInt32(0),
                            IdPrze = reader.GetInt32(1),
                            NazwaPrzedmiotu = reader.GetString(2),
                            NazwaProducenta = reader.GetString(3),
                            Cena = cena,
                            Kategoria = kategoria2

                        });
                    }
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