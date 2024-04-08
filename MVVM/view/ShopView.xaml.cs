using System;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view
{
    public partial class ShopView : UserControl
    {
        public string[] tab = { "a", "b", "c", "d" };
        
        public ShopView()
        {
            InitializeComponent();

            string sql = $"SELECT * FROM \"karty\"";

            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {   
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i += 4)
                            {
                                Border border = new Border();
                                border.BorderThickness = new Thickness(1);
                                border.BorderBrush = Brushes.Black;
                                border.Margin = new Thickness(5);

                                StackPanel stackPanel = new StackPanel();
                                stackPanel.Orientation = Orientation.Vertical;

                                TextBlock nazwa = new TextBlock();
                                nazwa.Text = reader.GetString(i);

                                Style Cname = (Style)this.FindResource("CName");
                                nazwa.Style = Cname;
                                

                                TextBlock producent = new TextBlock();
                                producent.Text = "Producent: " + reader.GetString(i + 1);

                                TextBlock cena = new TextBlock();
                                cena.Text = "Cena: " + reader.GetDecimal(i + 2).ToString();

                                TextBlock ilosc = new TextBlock();
                                ilosc.Text = "Ilość: " + reader.GetInt32(i + 3).ToString();
                                
                                Style Crest = (Style)this.FindResource("CRest");
                                producent.Style = Crest;
                                cena.Style = Crest;
                                ilosc.Style = Crest;
                                
                                stackPanel.Children.Add(nazwa);
                                stackPanel.Children.Add(producent);
                                stackPanel.Children.Add(cena);
                                
                                stackPanel.Children.Add(ilosc);

                                Style kartaStyle = (Style)this.FindResource("karta");
                                border.Style = kartaStyle;
                                
                                border.Child = stackPanel;

                                // Dodaj border do panelu
                                panel.Children.Add(border);

                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}