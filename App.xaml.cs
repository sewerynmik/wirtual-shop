using System.Collections.Generic;
using System.Windows;
using bazy3.MVVM.viewModel;
using Oracle.ManagedDataAccess.Client;

namespace bazy3;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static List<int> ShopBag = new();
    public static OracleConnection Con { get; set; }
    public static IMainViewModel MainVm { get; set; }

    public static int UserId { get; set; }
}