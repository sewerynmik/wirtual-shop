using System;
using System.Collections.ObjectModel;
using System.Text.Json;
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
                    {
                        var adresString = reader.GetString(3);
                        
                        var adres = JsonSerializer.Deserialize<Adres>(adresString);
                        
                        ProducersList.Add(new Producenci
                        {
                            ProducentId = reader.GetInt32(0),
                            Nazwa = reader.GetString(1),
                            KodPocztowy = reader.GetString(2),
                            Adres = adres
                        });
                    }
                    
                }
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void Edit(object sender, RoutedEventArgs e)
    {
        var producent = (Producenci)((Button)sender).DataContext;

        var producentId = producent.ProducentId;
        
        var editProducersView = new EditProducersView(producentId);
        
        App.MainVm.CurrentView = editProducersView;
    }

    private void Del(object sender, RoutedEventArgs e)
    {
        var producent = (Producenci)((Button)sender).DataContext;

        var producentId = producent.ProducentId;

        var sqlCheckProducts = "SELECT COUNT(*) FROM \"przedmioty\" WHERE \"producent_id\" = :id";
        int productsCount = 0;

        try
        {
            using (var command = new OracleCommand(sqlCheckProducts, App.Con))
            {
                command.Parameters.Add(new OracleParameter("id", producentId));
                productsCount = Convert.ToInt32(command.ExecuteScalar());
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            return;
        }

        if (productsCount > 0)
        {
            MessageBox.Show("Nie można usunąć tego producenta, ponieważ jest powiązany z produktami.");
            return;
        }

        var sqlDeleteProducent = "DELETE FROM \"producenci\" WHERE \"producent_id\" = :id";

        try
        {
            using (var command = new OracleCommand(sqlDeleteProducent, App.Con))
            {
                command.Parameters.Add(new OracleParameter("id", producentId));
                command.ExecuteNonQuery();
            }
            
            ProducersList.Remove(producent);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void AddNewProducent_Click(object sender, RoutedEventArgs e)
    {
        var addProducersView = new AddProducersView();
        
        App.MainVm.CurrentView = addProducersView;
    }
}