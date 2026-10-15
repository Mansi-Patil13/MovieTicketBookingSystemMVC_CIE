-- SQL Server sample database setup for CineBook.
-- The MVC app uses LocalDB by default. Run this script in SQL Server Management Studio
-- only if you want to create/populate a separate SQL Server database manually.
CREATE DATABASE MovieTicketBooking;
GO
USE MovieTicketBooking;
GO
CREATE TABLE Movies (
    MovieId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Genre NVARCHAR(60) NOT NULL,
    Language NVARCHAR(30) NOT NULL,
    DurationMinutes INT NOT NULL,
    Description NVARCHAR(500) NOT NULL,
    PosterUrl NVARCHAR(500) NOT NULL,
    TicketPrice DECIMAL(10,2) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1
);
CREATE TABLE Bookings (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    MovieId INT NOT NULL FOREIGN KEY REFERENCES Movies(MovieId),
    ShowTime NVARCHAR(20) NOT NULL,
    ShowDate DATE NOT NULL,
    TicketCount INT NOT NULL,
    SeatNumbers NVARCHAR(300) NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    BookedAt DATETIME NOT NULL DEFAULT GETDATE(),
    IsCancelled BIT NOT NULL DEFAULT 0
);
INSERT INTO Movies (Title, Genre, Language, DurationMinutes, Description, PosterUrl, TicketPrice, IsActive) VALUES
('The Last Horizon', 'Adventure', 'English', 128, 'A team of explorers races against time to uncover a hidden world beyond the horizon.', 'https://images.unsplash.com/photo-1440404653325-ab127d49abc1?w=800', 220, 1),
('Midnight Promise', 'Romance', 'Hindi', 116, 'Two strangers meet on a rainy evening and discover that the city has a story of its own.', 'https://images.unsplash.com/photo-1489599849927-2ee91cede3ba?w=800', 180, 1),
('Code Red', 'Thriller', 'English', 134, 'A cyber investigator follows a trail of clues before a city-wide blackout begins.', 'https://images.unsplash.com/photo-1517604931442-7e0c8ed2963c?w=800', 250, 1),
('Laughing Matters', 'Comedy', 'Hindi', 108, 'A chaotic family reunion turns into a comedy of errors that nobody will forget.', 'https://images.unsplash.com/photo-1478720568477-152d9b164e26?w=800', 160, 1),
('Ocean of Dreams', 'Drama', 'Gujarati', 122, 'A young artist returns home and finds inspiration in the people and memories she left behind.', 'https://images.unsplash.com/photo-1518676590629-3dcbd9c5a5c9?w=800', 190, 1),
('Shadow Protocol', 'Action', 'English', 141, 'An undercover agent must make one final choice when the mission becomes personal.', 'https://images.unsplash.com/photo-1500530855697-b586d89ba3ee?w=800', 240, 1);
GO
