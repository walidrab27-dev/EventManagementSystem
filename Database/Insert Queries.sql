USE EventManagementSystemDB;
GO

-- =============================================
-- 1. Insert 15 Organizers
-- =============================================
INSERT INTO Organizer (name, email)
VALUES
('Ahmed Hassan', 'ahmedhassan@gmail.com'),
('Mohamed Ali', 'mohamedali@gmail.com'),
('Omar Khaled', 'omarkhaled@gmail.com'),
('Sara Mahmoud', 'saramahmoud@gmail.com'),
('Mona Ibrahim', 'monaibrahim@gmail.com'),
('Youssef Adel', 'youssefadel@gmail.com'),
('Nour Samir', 'noursamir@gmail.com'),
('Hana Mostafa', 'hanamostafa@gmail.com'),
('Karim Tarek', 'karimtarek@gmail.com'),
('Salma Hany', 'salmahany@gmail.com'),
('Amr Wael', 'amrwael@gmail.com'),
('Dina Ashraf', 'dinaashraf@gmail.com'),
('Mahmoud Fathy', 'mahmoudfathy@gmail.com'),
('Farah Essam', 'farahessam@gmail.com'),
('Ziad Sherif', 'ziadsherif@gmail.com');
GO

-- =============================================
-- 2. Insert 15 Venues
-- =============================================
INSERT INTO Venue (name, location, capacity)
VALUES
('Cairo Conference Hall', 'Nasr City, Cairo', 500),
('Alexandria Grand Hall', 'Smouha, Alexandria', 350),
('Giza Exhibition Center', '6th of October, Giza', 1000),
('Nile View Hotel', 'Zamalek, Cairo', 200),
('New Capital Convention Center', 'New Administrative Capital', 2000),
('Mansoura Event Hall', 'Mansoura, Dakahlia', 300),
('Tanta Cultural Center', 'Tanta, Gharbia', 250),
('Luxor Heritage Hall', 'Luxor, Luxor Governorate', 400),
('Aswan Riverside Venue', 'Aswan, Aswan Governorate', 180),
('Port Said Conference Center', 'Port Said, Egypt', 320),
('Hurghada Beach Resort', 'Hurghada, Red Sea', 600),
('Sharm El Sheikh Resort', 'Sharm El Sheikh, South Sinai', 800),
('Ismailia Club Hall', 'Ismailia, Egypt', 150),
('Fayoum Cultural Palace', 'Fayoum, Egypt', 220),
('Smart Village Auditorium', 'Smart Village, Giza', 450);
GO

-- =============================================
-- 3. Insert 15 Events
-- =============================================
INSERT INTO Event
    (title, organizerId, venueId, eventDate)
VALUES
('Tech Innovation Summit', 1, 1, '2026-11-10 09:00:00'),
('Digital Marketing Conference', 2, 2, '2026-11-12 10:00:00'),
('Startup Founders Meetup', 3, 3, '2026-11-15 11:00:00'),
('Graphic Design Workshop', 4, 4, '2026-11-18 13:00:00'),
('AI and Machine Learning Forum', 5, 5, '2026-11-20 09:30:00'),
('Business Leadership Seminar', 6, 6, '2026-11-22 10:00:00'),
('Photography Masterclass', 7, 7, '2026-11-25 12:00:00'),
('Egyptian Heritage Festival', 8, 8, '2026-11-28 16:00:00'),
('Entrepreneurship Conference', 9, 9, '2026-12-02 09:00:00'),
('Cybersecurity Awareness Day', 10, 10, '2026-12-05 10:30:00'),
('Music and Arts Festival', 11, 11, '2026-12-08 17:00:00'),
('Web Development Bootcamp', 12, 12, '2026-12-12 09:00:00'),
('Career Development Fair', 13, 13, '2026-12-15 10:00:00'),
('Environmental Sustainability Forum', 14, 14, '2026-12-18 11:00:00'),
('Software Engineering Meetup', 15, 15, '2026-12-20 14:00:00');
GO

-- =============================================
-- 4. Insert 15 Attendees
-- =============================================
INSERT INTO Attendee (name, email)
VALUES
('Ali Mostafa', 'alimostafa@gmail.com'),
('Mariam Ahmed', 'mariamahmed@gmail.com'),
('Hossam Emad', 'hossamemad@gmail.com'),
('Laila Nabil', 'lailanabil@gmail.com'),
('Seif Amr', 'seifamr@gmail.com'),
('Yara Hisham', 'yarahisham@gmail.com'),
('Bassem Fawzy', 'bassemfawzy@gmail.com'),
('Reem Ashraf', 'reemashraf@gmail.com'),
('Tamer Adel', 'tameradel@gmail.com'),
('Jana Wael', 'janawael@gmail.com'),
('Fady Sameh', 'fadysameh@gmail.com'),
('Malak Ayman', 'malakayman@gmail.com'),
('Mostafa Reda', 'mostafareda@gmail.com'),
('Nada Ehab', 'nadaehab@gmail.com'),
('Adham Magdy', 'adhammagdy@gmail.com');
GO

-- =============================================
-- 5. Insert 15 Tickets
-- =============================================
INSERT INTO Ticket (eventId, attendeeId, price, checkIn)
VALUES
(1, 1, 500.00, '2026-11-10 08:45:00'),
(1, 2, 500.00, NULL),
(2, 3, 350.00, '2026-11-12 09:40:00'),
(2, 4, 350.00, NULL),
(3, 5, 250.00, '2026-11-15 10:30:00'),
(4, 6, 150.00, NULL),
(5, 7, 750.00, '2026-11-20 09:00:00'),
(5, 8, 750.00, NULL),
(6, 9, 200.00, '2026-11-22 09:45:00'),
(7, 10, 180.00, NULL),
(8, 11, 300.00, '2026-11-28 15:30:00'),
(9, 12, 400.00, NULL),
(10, 13, 100.00, '2026-12-05 10:00:00'),
(11, 14, 250.00, NULL),
(12, 15, 600.00, '2026-12-12 08:30:00');
GO

-- =============================================
-- Verify inserted records
-- =============================================
SELECT 'Organizer' AS TableName, COUNT(*) AS TotalRecords FROM Organizer
UNION ALL
SELECT 'Venue', COUNT(*) FROM Venue
UNION ALL
SELECT 'Event', COUNT(*) FROM Event
UNION ALL
SELECT 'Attendee', COUNT(*) FROM Attendee
UNION ALL
SELECT 'Ticket', COUNT(*) FROM Ticket;
GO
