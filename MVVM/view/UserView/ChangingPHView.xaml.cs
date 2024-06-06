using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using bazy3.MVVM.viewModel;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view;

public partial class ChangingPHView : UserControl
{
    public ChangingPHView()
    {
        InitializeComponent();
    }

    private void Change(object sender, RoutedEventArgs e)
    {
        try
        {
            var newval = ((TextBox)newvalue.Template.FindName("input", newvalue)).Text;
            
            if (ValidatePhoneNumber(newval) == false)
            {
                var mesblock = (TextBlock)Mess;
                mesblock.Opacity = 1;
                return;
            }

            var sql = $"UPDATE \"klienci\" SET \"nr_tel\" = :nr_tel WHERE \"klient_id\" = :userId";

            using (var command = new OracleCommand(sql, App.Con))
            {
                command.Parameters.Add(new OracleParameter("nr_tel", newval));
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

    private bool ValidatePhoneNumber(string PH)
    {
        var mesblock = (TextBlock)Mess;
        
        var regexPattern = @"^\d{9}$";
        var regex = new Regex(regexPattern);
        if (!regex.IsMatch(PH))
        {
            mesblock.Text = "Numer powinien zawiarać tylko cyfry";
            return false;
        }
            
            
        if (PH.Length > 9)
        {
            mesblock.Text = "Numer za długi";
            return false;
        }

        if (PH.Length < 9)
        {
            mesblock.Text = "Numer za krótki";
            return false;
        }
        
        return true;
    }
}