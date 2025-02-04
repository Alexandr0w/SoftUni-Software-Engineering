INSERT INTO [Brands]([Name]) VALUES
	('Timberland'),
	('Birkenstock')

INSERT INTO [Shoes]([Model], [Price], [BrandId]) VALUES
	('Pro Reaxion', 150.00, 12),
	('Laurel Cort Lace-Up', 160.00, 12),
	('Perkins Row Sandal', 170.00, 12),
	('Arizona', 80.00, 13),
	('Ben Mid Dip', 85.00, 13),
	('Gizeh', 90.00, 13)

INSERT INTO [ShoesSizes]([ShoeId], [SizeId]) VALUES
	(70, 1), (70, 2), (70, 3),
	(71, 2), (71, 3), (71, 4),
	(72, 4), (72, 5), (72, 6),
	(73, 1), (73, 3), (73, 5),
	(74, 2), (74, 4), (74, 6),
	(75, 1), (75, 2), (75, 3)

INSERT INTO [Orders] ([ShoeId], [SizeId], [UserId]) VALUES
	(70, 2, 15),
	(71, 3, 17),
	(72, 6, 18),
	(73, 5, 4),
	(74, 4, 7),
	(75, 1, 11)