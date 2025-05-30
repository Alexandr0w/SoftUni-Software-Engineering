SELECT
	[AgeGroup],
	COUNT([AgeGroup]) AS [WizzardCount]
FROM
(
	SELECT 
		CASE 
			WHEN [Age] <= 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 51 AND 60 THEN '[21-30]'
			WHEN [Age] > 60 THEN '[61+]'
		END AS [AgeGroup]
	FROM [WizzardDeposits]
) AS w
GROUP BY [AgeGroup]