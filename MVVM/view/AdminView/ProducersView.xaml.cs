using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Oracle.ManagedDataAccess.Client;
using System.Windows;
using bazy3.Entities;

namespace bazy3.MVVM.view.AdminView;

public partial class ProducersView : UserControl
{
    public ProducersView()
    {
        InitializeComponent();
        LoadDataFromDatabase();
        ItemsControl.ItemsSource = ProducersList;
    }

    public ObservableCollection<Producenci> ProducersList { get; } = new();

    private void LoadDataFromDatabase()
    {
        var sql = "SELECT * FROM \"producenci\"";
        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        ProducersList.Add(new Producenci
                        {
                            ProducentId = reader.GetInt32(0),
                            Nazwa = reader.GetString(1),
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