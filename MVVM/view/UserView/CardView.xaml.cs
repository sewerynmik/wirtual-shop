using System;
using System.Collections.ObjectModel;
using System.Text.Json;
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

    public ObservableCollection<PrzePro> CardList2 { get; } = new();

    private void LoadDataFromDatabase()
    {
        for (var i = App.ShopBag.Count - 1; i >= 0; i--)
        {
            var sql = $"SELECT * FROM \"prze_pro\" WHERE \"przedmiot_id\" = {App.ShopBag[i]}";


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

                            CardList2.Add(new PrzePro()
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
    }

    private void Usun(object sender, RoutedEventArgs e)
    {
        var id = (int)((Button)sender).CommandParameter;

        App.ShopBag.Remove(id);

        App.MainVm.CurrentView = new CardView();
    }

    private void Buy(object sender, RoutedEventArgs e)
    {
        if (App.ShopBag.Count == 0)
        {
            return;
        }
        
        string kod = null;
        int id = 0;
        string sql = $"SELECT GENERUJ_NR_ZAM() FROM DUAL";
        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        kod = reader.GetString(0);
                    }
                }
            }
        }catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }

        sql = "SELECT NASTEPNY_ZAM_ID() FROM DUAL";

        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }

        sql = $"BEGIN ADDZAM(:id_zam, :nr_zam, :user_id); END;";

        try
        {
            using (var command = new OracleCommand(sql, App.Con))
            {
                command.Parameters.Add(new OracleParameter("id_zam", id));
                command.Parameters.Add(new OracleParameter("nr_zam", kod));
                command.Parameters.Add(new OracleParameter("user_id", App.UserId));
                command.ExecuteNonQuery();
            }

        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }

        sql = $"INSERT INTO \"zam_prze\" (\"id_zam\", \"id_prze\") VALUES ({id}, :przedmiot_id)";


        while (App.ShopBag.Count > 0)
        {
            using (var insertCommand = new OracleCommand(sql, App.Con))
            {
                insertCommand.Parameters.Add(":przedmiot_id", OracleDbType.Int32).Value = App.ShopBag[0];
                                
                insertCommand.ExecuteNonQuery();
            }

            App.ShopBag.RemoveAt(0);
        }
        App.MainVm.CurrentView = new CardView();
    }
}