UPDATE [Contacts]
SET [Website] = LOWER('www.' + REPLACE(Name, ' ', '') + '.com')
FROM [Contacts] AS c
JOIN [Authors] AS a ON c.[Id] = a.[ContactId]
WHERE [Website] IS NULL