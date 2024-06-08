using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types; // Importuj namespace OracleDecimal
using System;
using System.Windows.Controls;

namespace bazy3.MVVM.view.ProducentView
{
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();
            WyswietlProcentPrzedmiotowProducenta();
        }

        private void WyswietlProcentPrzedmiotowProducenta()
        {
            string sql = @"
                DECLARE
                    v_procent NUMBER;
                BEGIN
                    v_procent := procent_przedmiotow_producenta(:p_producent_id);
                    :result := v_procent;
                END;
            ";

            try
            {
                using (var command = new OracleCommand(sql, App.Con))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.Add("p_producent_id", OracleDbType.Int32).Value = App.UserId;
                    command.Parameters.Add("result", OracleDbType.Decimal).Direction = System.Data.ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    OracleDecimal result = (OracleDecimal)command.Parameters["result"].Value;

                    if (!result.IsNull)
                    {
                        string procent = result.ToString();
                        if (procent.Length >= 5)
                        {
                            string procent2 = procent.Substring(0, 5);
                            ProcentPrzedmiotowTextBox.Text = procent2; 
                        }
                        else
                        {
                            ProcentPrzedmiotowTextBox.Text = procent;
                        }
                    }
                    else
                    {
                        ProcentPrzedmiotowTextBox.Text = "Wartość niezdefiniowana";
                    }
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędów
                Console.WriteLine("Błąd: " + ex.Message);
            }
        }
    }
}