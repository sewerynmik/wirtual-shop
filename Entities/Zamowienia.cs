using System;

namespace bazy3.Entities;

public class Zamowienia
{
    public int ZamowienieId { set; get; }
    public long NrZamowienia { set; get; }
    public int KlienitId { set; get; }
    public int PrzedmiotId { set; get; }
    public DateTime Data { set; get; }
}