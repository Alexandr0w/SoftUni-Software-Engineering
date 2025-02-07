DELETE
FROM [ProductsClients]
WHERE [ClientId] = 11

DELETE
FROM [Invoices]
WHERE [ClientID] = 11

DELETE 
FROM [Clients]
WHERE SUBSTRING([NumberVAT], 1, 2) = 'IT'