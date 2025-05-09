public class Flight
{
    public string FlightNumber { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public int TotalSeats { get; set; }
    public int SeatsLeft { get; set; }

    public Flight(string flightNumber, string origin, string destination, DateTime departureTime, int totalSeats)
    {
        FlightNumber = flightNumber;
        Origin = origin;
        Destination = destination;
        DepartureTime = departureTime;
        TotalSeats = totalSeats;
        SeatsLeft = totalSeats;
    }
}