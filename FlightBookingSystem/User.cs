using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Booking> Bookings { get; set; } = new List<Booking>();
    public bool IsAdmin { get; set; }

    public User(string username, string password, bool isAdmin = false)
    {
        Username = username;
        Password = password;
        IsAdmin = isAdmin;
    }
}