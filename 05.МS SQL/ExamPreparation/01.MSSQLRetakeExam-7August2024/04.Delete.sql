DELETE 
FROM [Orders] 
WHERE [ShoeId] IN (SELECT Id FROM Shoes WHERE Model = 'Joyride Run Flyknit')
DELETE 
FROM [ShoesSizes] 
WHERE [ShoeId] IN (SELECT Id FROM Shoes WHERE Model = 'Joyride Run Flyknit')
DELETE 
FROM [Shoes] 
WHERE [Model] = 'Joyride Run Flyknit'