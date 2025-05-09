public class Booking
{
    public User User { get; set; }
    public Flight Flight { get; set; }

    public Booking(User user, Flight flight)
    {
        User = user;
        Flight = flight;
    }
}