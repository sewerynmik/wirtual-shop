using System;
using System.Collections.ObjectModel;
using System.Linq;
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

        private void Edit(object sender, RoutedEventArgs e)
        {
            var id = (int)((Button)sender).CommandParameter;
            
            var editUserView = new EditUserView(id);
        
            App.MainVm.CurrentView = editUserView;
        }

        private async void Del(object sender, RoutedEventArgs e)
        {
            var id = (int)((Button)sender).CommandParameter;

            var orderExistsSql = $"SELECT COUNT(*) FROM \"zamowienia\" WHERE \"klient_id\" = :id";
            try
            {
                using (var command = new OracleCommand(orderExistsSql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("id", id));
                    var orderCount = Convert.ToInt32(command.ExecuteScalar());

                    if (orderCount > 0)
                    {
                        MessageBox.Show("Nie można usunąć klienta, ponieważ złożył zamówienie.");
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            if (App.UserId == id)
            {
                MessageBox.Show("Nie możesz usunąć samego siebie.");
                return;
            }

            var deleteClientSql = $"BEGIN DELUSER(:id); END;";
            try
            {
                using (var command = new OracleCommand(deleteClientSql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("id", id));
                    command.ExecuteNonQuery();
                }

                var itemToRemove = ClientList.FirstOrDefault(item => item.KlientId == id);
                if (itemToRemove != null)
                {
                    ClientList.Remove(itemToRemove);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditLogin(object sender, RoutedEventArgs e)
        {
            var id = (int)((Button)sender).CommandParameter;
            
            var editLoginView = new EditLoginView(id);
        
            App.MainVm.CurrentView = editLoginView;
        }

        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            
            var addUserView = new AddUserView();
        
            App.MainVm.CurrentView = addUserView;
        }
    }
}