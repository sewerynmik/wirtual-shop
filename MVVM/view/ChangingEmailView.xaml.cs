using System;
using System.Windows;
using System.Windows.Controls;
using bazy3.MVVM.viewModel;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view
{
    public partial class ChangingEmailView : UserControl
    {
        public ChangingEmailView()
        {
            InitializeComponent();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            try
            {
                var newval = (TextBlock)newvalue.Template.FindName("haselko", newvalue);

                string sql = $"UPDATE KLIENCI SET \"email\" = :email WHERE \"klient_id\" = :userId";
                
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.Parameters.Add(new OracleParameter("email", newval.Text));
                    command.Parameters.Add(new OracleParameter("userId", App.UserId));
                    
                    command.ExecuteNonQuery();
                }

                var optionvm = new OptionsViewModel();
                App.MainVm.CurrentView = optionvm;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}