﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view;

public partial class ShopView : UserControl
{
    public ShopView()
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

                        CardList.Add(new PrzePro()
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


    private void AddItem(object sender, RoutedEventArgs e)
    {
        var id = (int)((Button)sender).CommandParameter;

        App.ShopBag.Add(id);
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
}