using System;

namespace bazy3.Entities;

public class Login
{
    public int LoginId { get; set; }
    public int KlientId { get; set; }
    public string LoginNazwa { get; set; }
    public string Haslo { get; set; }
    public bool Active { get; set; }
    public string Type { get; set; }
    public DateTime LastChange { get; set; }
    public DateTime LastLogin { get; set; }
}