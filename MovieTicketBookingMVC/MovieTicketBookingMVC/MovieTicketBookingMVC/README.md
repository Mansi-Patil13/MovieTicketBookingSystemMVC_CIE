# CineBook — Movie Ticket Booking System

A beginner-friendly ASP.NET MVC 5 project using C#, Razor views, Entity Framework 6, and SQL Server LocalDB.

## Features
- Home page with featured movies
- Browse and search movies by title/language and filter by genre
- Movie details and ticket price
- Booking form with customer details, show date/time, number of tickets, and seat labels
- Total price calculation and booking confirmation
- Find bookings by email and cancel eligible bookings
- Responsive dark cinema-inspired interface
- SQL sample script included

## Requirements
- Visual Studio 2019 or 2022
- ASP.NET and web development workload
- .NET Framework 4.7.2 Developer Pack/Targeting Pack
- SQL Server Express LocalDB (normally installed with Visual Studio)

## Open and run
1. Extract the ZIP file.
2. Open `MovieTicketBookingMVC.sln` in Visual Studio.
3. If Visual Studio offers to restore NuGet packages, accept it. If not, right-click the solution and choose **Restore NuGet Packages**.
4. Confirm the project targets .NET Framework 4.7.2. Install the Developer Pack if Visual Studio says the target framework is missing.
5. Set `MovieTicketBookingMVC` as the startup project.
6. Press **Ctrl+F5** or click **IIS Express**.

The connection string uses LocalDB and an MDF file under `App_Data`. Entity Framework creates the database on first access, and `MovieDbInitializer` inserts six sample movies automatically. If LocalDB is not installed, install it with Visual Studio or change the connection string to a SQL Server instance. The optional `database/MovieTicketBooking.sql` script creates a separate SQL Server database and sample data.

## Important demo notes
- This is an educational project, not a production ticketing platform.
- Seat labels are validated for count and duplicates within a single booking, but seat availability is not locked across concurrent bookings.
- No payment gateway, login system, email delivery, or QR validation is implemented.
- The "My Bookings" page uses email lookup for demonstration; add authentication/authorization before using real customer data.
- Sample movies use remote image URLs, so posters require an internet connection. Replace URLs with images you own or have permission to use.

## GitHub upload
Create a repository such as `MovieTicketBookingMVC` under your own GitHub account. Upload the project contents, including the solution, project folder, README, and SQL script. Do not upload `bin`, `obj`, `.vs`, or user-specific files. Never upload secrets or real customer data.
