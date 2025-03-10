﻿SELECT h.[Name] AS [HotelName],
	   r.[Price] AS [RoomPrice]
FROM [Tourists] AS t
	JOIN [Bookings] AS b ON t.[Id] = b.[TouristId]
	JOIN [Hotels] AS h ON b.[HotelId] = h.[Id]
	JOIN [Rooms] AS r ON b.[RoomId] = r.[Id]
WHERE RIGHT(t.[Name], 2) != 'EZ' 
ORDER BY r.[Price] DESC