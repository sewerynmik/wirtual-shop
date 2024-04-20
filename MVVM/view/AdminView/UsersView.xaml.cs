using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Oracle.ManagedDataAccess.Client;
using System.Windows;
using bazy3.Entities;

namespace bazy3.MVVM.view.AdminView
{
    public partial class UsersView : UserControl
    {
        public UsersView()
        {
            InitializeComponent();
            LoadDataFromDatabase();
            ItemsControl.ItemsSource = ClientList;
        }

        public ObservableCollection<Klienci> ClientList { get; } = new();

        private void LoadDataFromDatabase()
        {
            var sql = "SELECT * FROM \"klienci\"";
            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            ClientList.Add(new Klienci
                            {
                                KlientId = reader.GetInt32(0),
                                Imie = reader.GetString(1),
                                Nazwisko = reader.GetString(2),
                                Pesel = reader.GetInt64(3),
                                Email = reader.GetString(4),
                                NrTel = reader.GetInt64(5)
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
}