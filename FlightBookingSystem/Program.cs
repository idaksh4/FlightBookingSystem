using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightBookingSystem
{
    class Program
    {
        static List<Flight> flights = new List<Flight>();
        static List<User> users = new List<User>();
        static User? currentUser = null;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n==== Flight Booking System ====");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Add Flight");
                Console.WriteLine("4. View Flights");
                Console.WriteLine("5. Book Flight");
                Console.WriteLine("6. Cancel Booking");
                Console.WriteLine("7. View My Bookings");
                Console.WriteLine("8. Logout");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";


                switch (choice)
                {
                    case "1": RegisterUser(); break;
                    case "2": LoginUser(); break;
                    case "3": AddFlight(); break;
                    case "4": ViewFlights(); break;
                    case "5": BookFlight(); break;
                    case "6": CancelBooking(); break;
                    case "7": ViewBookings(); break;
                    case "8": Logout(); break;
                    case "9": return;
                    default: Console.WriteLine("Invalid choice. Try again."); break;
                }
            }
        }

        static void RegisterUser()
        {
            Console.Write("Enter a username: ");
            string username = Console.ReadLine() ?? "";

            if (users.Exists(u => u.Username == username))
            {
                Console.WriteLine("Username already exists. Try logging in.");
                return;
            }

            Console.Write("Enter a password: ");
            string password = Console.ReadLine() ?? "";

            bool isAdmin = username.ToLower() == "admin";
            users.Add(new User(username, password, isAdmin));
            Console.WriteLine(isAdmin ? "Admin registered successfully!" : "Registration successful!");
        }

        static void LoginUser()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Enter your password: ");
            string password = Console.ReadLine() ?? "";

            User? user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }


            if (user != null)
            {
                currentUser = user;
                Console.WriteLine($"Login successful! Welcome, {user.Username}");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        static void Logout()
        {
            currentUser = null;
            Console.WriteLine("Logged out successfully.");
        }

        static void AddFlight()
        {
            if (currentUser == null || !currentUser.IsAdmin)
            {
                Console.WriteLine("Access denied. Only admins can add flights.");
                return;
            }

            Console.Write("Enter flight number: ");
            string flightNumber = Console.ReadLine() ?? "";

            Console.Write("Enter origin: ");
            string origin = Console.ReadLine() ?? "";

            Console.Write("Enter destination: ");
            string destination = Console.ReadLine() ?? "";

            Console.Write("Enter departure time (yyyy-mm-dd hh:mm): ");
            DateTime departureTime;
            while (!DateTime.TryParse(Console.ReadLine(), out departureTime))
            {
                Console.Write("Invalid format. Please re-enter (yyyy-mm-dd hh:mm): ");
            }

            Console.Write("Enter total seats: ");
            int totalSeats;
            while (!int.TryParse(Console.ReadLine(), out totalSeats) || totalSeats <= 0)
            {
                Console.Write("Invalid number. Enter a positive integer: ");
            }

            Flight flight = new Flight(flightNumber, origin, destination, departureTime, totalSeats);
            flights.Add(flight);

            Console.WriteLine("Flight added successfully!");
        }

        static void ViewFlights()
        {
            if (flights.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }

            Console.WriteLine("\n--- Available Flights ---");
            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight Number : {flight.FlightNumber}");
                Console.WriteLine($"Origin        : {flight.Origin}");
                Console.WriteLine($"Destination   : {flight.Destination}");
                Console.WriteLine($"Departure     : {flight.DepartureTime}");
                Console.WriteLine($"Seats Left    : {flight.SeatsLeft}/{flight.TotalSeats}");
                Console.WriteLine(new string('-', 40));
            }
        }

        static void BookFlight()
        {
            if (currentUser == null)
            {
                Console.WriteLine("You must be logged in to book a flight.");
                return;
            }

            Console.Write("Enter flight number to book: ");
            string flightNumber = Console.ReadLine() ?? "";

            Flight? selectedFlight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

            if (selectedFlight == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }


            if (selectedFlight == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            if (selectedFlight.SeatsLeft <= 0)
            {
                Console.WriteLine("No seats available on this flight.");
                return;
            }

            selectedFlight.SeatsLeft--;
            currentUser.Bookings.Add(new Booking(currentUser, selectedFlight));
            Console.WriteLine("Booking confirmed!");
        }

        static void CancelBooking()
        {
            if (currentUser == null)
            {
                Console.WriteLine("You must be logged in to cancel a booking.");
                return;
            }

            Console.Write("Enter flight number to cancel booking: ");
            string flightNumber = Console.ReadLine() ?? "";

            var booking = currentUser.Bookings.FirstOrDefault(b => b.Flight.FlightNumber == flightNumber);
            if (booking != null)
            {
                booking.Flight.SeatsLeft++;
                currentUser.Bookings.Remove(booking);
                Console.WriteLine("Booking cancelled.");
            }
            else
            {
                Console.WriteLine("No booking found for this flight.");
            }
        }

        static void ViewBookings()
        {
            if (currentUser == null)
            {
                Console.WriteLine("Please log in to view your bookings.");
                return;
            }

            if (currentUser.Bookings.Count == 0)
            {
                Console.WriteLine("You have no bookings.");
                return;
            }

            Console.WriteLine("\n--- Your Bookings ---");
            foreach (var booking in currentUser.Bookings)
            {
                var flight = booking.Flight;
                Console.WriteLine($"Flight: {flight.FlightNumber} | {flight.Origin} → {flight.Destination} | {flight.DepartureTime} | Seat confirmed");
            }
        }
    }
}