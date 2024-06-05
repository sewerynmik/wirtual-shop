namespace bazy3.Entities;

public class Przedmioty
{
    public int PrzedmiotId { get; set; }
    public string Nazwa { get; set; }
    public int ProducentId { get; set; }
    public Cena Cena { get; set; }
    public string Kategoria { get; set; }
}