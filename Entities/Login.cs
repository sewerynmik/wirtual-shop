using System;

namespace bazy3.Entities;

public class Login
{
    public int LoginId { get; set; }
    public int KlientId { get; set; }
    public string LoginName { get; set; }
    public string Haslo { get; set; }
    public bool Active { get; set; }
    public string Type { get; set; }
    public DateTime LastChange { get; set; }
}