using System;
using System.Collections.ObjectModel;
using System.Windows;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace bazy3.MVVM.view.ProducentView;

public partial class MyProductsView : UserControl
{
    public MyProductsView()
    {
        InitializeComponent();
        InitializeComponent();
        LoadDataFromDatabase();
        ItemsControl.ItemsSource = CardList;
    }

    public ObservableCollection<PrzePro> CardList { get; } = new();

    private void LoadDataFromDatabase()
    {
        var sql = $"SELECT * FROM \"karty\" WHERE \"producent_id\" = "+ App.UserId;
        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        CardList.Add(new PrzePro
                        {
                            Id = reader.GetInt32(0),
                            Nazwa = reader.GetString(1),
                            Producent = reader.GetString(2),
                            // Cena = reader.GetDecimal(3),
                        });
                }
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void Add(object sender, RoutedEventArgs e)
    {
        
    }
}