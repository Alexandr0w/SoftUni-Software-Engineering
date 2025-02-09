INSERT INTO [Leagues]([Name]) VALUES
	('Eredivisie')

INSERT INTO [Teams]([Name], [City], [LeagueId]) VALUES
	('PSV', 'Eindhoven', 6),
	('Ajax', 'Amsterdam', 6)

INSERT INTO [Players]([Name], [Position]) VALUES
	('Luuk de Jong', 'Forward'),
	('Josip Sutalo', 'Defender')

INSERT INTO [Matches]([HomeTeamId], [AwayTeamId], [MatchDate], [HomeTeamGoals], [AwayTeamGoals], [LeagueId]) VALUES
	(98, 97, '2024-11-02 20:45:00', 3, 2, 6)

INSERT INTO [PlayersTeams]([PlayerId], [TeamId]) VALUES
	(2305, 97),
	(2306, 98)

INSERT INTO [PlayerStats]([PlayerId], [Goals], [Assists]) VALUES
	(2305, 2, 0),
	(2306, 2, 0)

INSERT INTO [TeamStats]([TeamId], [Wins], [Draws], [Losses]) VALUES
	(97, 15, 1, 3),
	(98, 14, 3, 2)
