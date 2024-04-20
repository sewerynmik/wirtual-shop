namespace bazy3.Entities;

public class Przedmioty
{
    public int PrzedmiotId { get; set; }
    public string Nazwa { get; set; }
    public int ProducentId { get; set; }
    public decimal Cena { get; set; }
    public int Ilosc { get; set; }
}