namespace bazy3.Entities;

public class zam_prze_data_view
{
    public int IdZam { set; get; }
    public int IdPrze { set; get; }
    public string NazwaPrzedmiotu { set; get; }
    public string NazwaProducenta { set; get; }
    public Cena Cena { set; get; }
    public string Kategoria { set; get; }
}