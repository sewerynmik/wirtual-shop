using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using bazy3.MVVM.viewModel;
using Oracle.ManagedDataAccess.Client;

namespace bazy3.MVVM.view;

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
            var text = (TextBox)Value.Template.FindName("input", Value);
            string email = text.Text;

            if (ValidateEmail(email) == false)
            {
                var mesblock = (TextBlock)Mess;
                mesblock.Text = "Nieprawidłowy adres email";
                mesblock.Opacity = 1;
                return;
            }

            var sql = "BEGIN EDITEMAIL(:email, :userId); END;";


            using (var command = new OracleCommand(sql, App.Con))
            {
                command.Parameters.Add(new OracleParameter("email", email));
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

    private bool ValidateEmail(string email)
    {
        string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        return Regex.IsMatch(email, pattern);
    }
}