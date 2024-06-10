using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;
using MessageBox = System.Windows.Forms.MessageBox;
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

    public ObservableCollection<PrzePro> CardList { get; } = new();

    private void LoadDataFromDatabase()
    {
        
        var sql = $"SELECT * FROM \"prze_pro\"";
        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cenaString = reader.GetString(3);
                        
                        var cena = JsonSerializer.Deserialize<Cena>(cenaString);
                        
                        var kategoria = reader.GetString(4);
                        var kategoria2 = $"../../../images/{kategoria}.png";
                        
                        CardList.Add(new PrzePro
                        {
                            Id = reader.GetInt32(0),
                            Nazwa = reader.GetString(1),
                            Producent = reader.GetString(2),
                            Cena = cena,
                            Kategoria = kategoria,
                            Kategoria2 = kategoria2
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

    private void Del(object sender, RoutedEventArgs e)
    {
        var id = (int)((Button)sender).CommandParameter;

        var checkSql = $"SELECT COUNT(*) FROM \"zam_prze\" WHERE \"id_prze\" = :id";
        try
        {
            int count;
            using (var command = new OracleCommand(checkSql, App.Con))
            {
                command.Parameters.Add(new OracleParameter("id", id));
                count = Convert.ToInt32(command.ExecuteScalar());
            }

            if (count > 0)
            {
                MessageBox.Show("Nie można usunąć produktu, ponieważ jest powiązany z zamówieniem.");
                return;
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            return;
        }

        var sql = $"BEGIN DELPRODUCT(:id); END;";
        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                command.Parameters.Add(new OracleParameter("id", id));
                command.ExecuteNonQuery();
            }
        
            var itemToRemove = CardList.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                CardList.Remove(itemToRemove);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }


    private void Edit(object sender, RoutedEventArgs e)
    {
        var id = (int)((Button)sender).CommandParameter;
        
        var editProductsView = new EditProductsView(id);
        
        App.MainVm.CurrentView = editProductsView;
    }

    private void AddNewProduct_Click(object sender, RoutedEventArgs e)
    {
        var addProductsView = new AddProductsView();
        
        App.MainVm.CurrentView = addProductsView;
    }
    
    private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tex = (TextBox)FilterTextBox.Template.FindName("input", FilterTextBox);
        var filterText = tex.Text.ToLower();
        if (string.IsNullOrWhiteSpace(filterText))
        {
            ItemsControl.ItemsSource = CardList;
        }
        else
        {
            var filteredList = new ObservableCollection<PrzePro>(CardList.Where(item => item.Nazwa.ToLower().Contains(filterText)));
            ItemsControl.ItemsSource = filteredList;
        }
    }
    
    private void ZwiekszCeneProcentowoButton_Click(object sender, RoutedEventArgs e)
    {
        WywolajProcedureZwiekszCeneProcentowo(5);
    }

    private void WywolajProcedureZwiekszCeneProcentowo(int procent)
    {
        string sql = "zwieksz_cene_procentowo";

        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("p_procent", OracleDbType.Int32).Value = procent;

                command.ExecuteNonQuery();
                
                CardList.Clear();
                
                LoadDataFromDatabase();
                
                ItemsControl.ItemsSource = CardList;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }
}