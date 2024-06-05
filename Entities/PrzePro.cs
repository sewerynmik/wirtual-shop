namespace bazy3.Entities;

public class PrzePro
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Producent { get; set; }
    public Cena Cena { get; set; }
    public string Kategoria { get; set; }
    public string Kategoria2 { get; set; }
}