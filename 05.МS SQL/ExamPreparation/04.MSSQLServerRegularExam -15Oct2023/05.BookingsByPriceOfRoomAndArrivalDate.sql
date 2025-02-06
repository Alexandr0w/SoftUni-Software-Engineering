SELECT 
FORMAT([ArrivalDate], 'yyyy-MM-dd') AS [ArrivalDate], [AdultsCount], [ChildrenCount]
FROM [Bookings] AS b
	JOIN [Rooms] AS r ON b.[RoomId] = r.[Id]
ORDER BY r.[Price] DESC,
	     [ArrivalDate]