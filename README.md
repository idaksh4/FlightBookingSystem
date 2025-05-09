# ✈️ Flight Booking System (Console App in C#)

A simple, console-based flight booking system developed in C# using .NET. This project demonstrates core programming concepts like object-oriented design, user authentication, collections, and conditional logic — ideal for learning and showcasing backend software development skills.

---

## 🔧 Features

- 👥 User Registration & Login (with admin access)
- ✈️ Admin-only Flight Management (add flights)
- 📋 View All Available Flights
- 🧾 Book a Flight (logged-in users only)
- ❌ Cancel Bookings
- 📂 View My Bookings
- 🔐 Session-based Login/Logout

---

## 💻 Tech Stack

- Language: **C#**
- Framework: **.NET Console Application**
- Architecture: Simple layered structure with models, user logic, and in-memory data store

---

## 🗂️ Project Structure

```plaintext
FlightBookingSystem/
│
├── Program.cs          # Main application logic
├── Flight.cs           # Flight model
├── User.cs             # User model with admin support
├── Booking.cs          # Booking model
└── README.md           # Project documentation
```

---

## 🚀 Getting Started

1. **Clone the repository**

```bash
git clone https://github.com/yourusername/FlightBookingSystem.git
cd FlightBookingSystem
```

2. **Run the project**

```bash
dotnet run
```

> Requires .NET SDK. You can download it from [dotnet.microsoft.com](https://dotnet.microsoft.com/).

---

## 🧪 Sample Demo

- Register a user or login with username `admin` (admin rights)
- Admins can add flights
- Other users can view flights, book, cancel, and view personal bookings

---

## 📌 Future Enhancements (Ideas)

- Add persistent storage with SQLite or a file system
- Track multiple passengers per flight
- Add seat mapping
- Build a GUI or web version using Blazor/ASP.NET

---

## 📄 License

This project is open-source and free to use for learning purposes.

---

## 🙋‍♂️ Author

**Daksh Gupta**  
[LinkedIn](https://www.linkedin.com/in/daksh-gupta-dtu/) • [GitHub](https://github.com/idaksh4)
