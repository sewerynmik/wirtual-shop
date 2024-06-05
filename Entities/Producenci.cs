namespace bazy3.Entities;

public class Producenci
{
    public int ProducentId { get; set; }
    public string Nazwa { get; set; }
    
    public string KodPocztowy { get; set; }
    
    public Adres Adres { get; set; }
}