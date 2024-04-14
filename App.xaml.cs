using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using bazy3.MVVM.viewModel;
using Oracle.ManagedDataAccess.Client;

namespace bazy3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static OracleConnection Con { get; set; }
        public static MainViewModel MainVm { get; set; }

        public static List<int> ShopBag = new List<int>();
        
        public static int UserId { get; set; }
    }
}