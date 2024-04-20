namespace bazy3.Entities;

public class Klienci
{
    public int KlientId { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public long Pesel { get; set; }
    public string Email { get; set; }
    public long NrTel { get; set; }
}