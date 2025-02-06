SELECT h.[Id], 
       h.[Name]
FROM [Hotels] AS h
	JOIN [HotelsRooms] hr ON h.[Id] = hr.[HotelId]
	JOIN [Rooms] r ON hr.[RoomId] = r.[Id]
	JOIN [Bookings] AS b ON h.[Id] = b.[HotelId] AND r.[Type] = 'VIP Apartment'
GROUP BY h.[Id], 
	     h.[Name]
ORDER BY COUNT(*) DESC