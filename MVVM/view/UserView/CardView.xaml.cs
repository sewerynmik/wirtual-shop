using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using bazy3.Entities;
using bazy3.MVVM.viewModel;
using Oracle.ManagedDataAccess.Client;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace bazy3.MVVM.view;

public partial class CardView : UserControl
{
    public CardView()
    {
        InitializeComponent();
        LoadDataFromDatabase();
        CardItemsControl.ItemsSource = CardList2;
    }

    public ObservableCollection<CardData> CardList2 { get; } = new();

    private void LoadDataFromDatabase()
    {
        for (var i = App.ShopBag.Count - 1; i >= 0; i--)
        {
            var sql = $"SELECT * FROM \"karty\" WHERE \"producent_id\" = " + App.ShopBag[i];


            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            CardList2.Add(new CardData
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

    private void usun(object sender, RoutedEventArgs e)
    {
        var id = (int)((Button)sender).CommandParameter;

        App.ShopBag.Remove(id);

        App.MainVm.CurrentView = new CardView();
    }

    private void Buy(object sender, RoutedEventArgs e)
    {
        string kod;
        string sql = "SELECT gen_nr_zam() FROM DUAL";
        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        kod = reader.GetString(0);
                        string sq = $"INSERT INTO \"zamowienia\" (\"nr_zamowienia\", \"klient_id\", \"przedmiot_id\") VALUES (:nr_zamowienia, :klient_id, :przedmiot_id)";

                        while (App.ShopBag.Count > 0)
                        {
                            using (var insertCommand = new OracleCommand(sq, App.Con))
                            {
                                insertCommand.Parameters.Add(":nr_zamowienia", OracleDbType.Varchar2).Value = kod;
                                insertCommand.Parameters.Add(":klient_id", OracleDbType.Int32).Value = App.UserId;
                                
                                insertCommand.Parameters.Add(":przedmiot_id", OracleDbType.Int32).Value = App.ShopBag[0];
                                
                                insertCommand.ExecuteNonQuery();
                            }

                            App.ShopBag.RemoveAt(0);
                        }
                    }
                }
            }
            App.MainVm.CurrentView = new CardView();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}