using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;
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
}