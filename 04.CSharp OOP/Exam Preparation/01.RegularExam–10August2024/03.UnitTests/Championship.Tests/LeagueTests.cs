using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Championship.Tests
{
    public class LeagueTests
    {
        private League league;
        private Team testTeam;
        private string noneTeam = "None";
        private string testTeamName = "test";
        private string homeTeamName = "home team";
        private string awayTeamName = "away team";

        [SetUp]
        public void Setup()
        {
            league = new League();
            testTeam = new Team(testTeamName);
        }

        [Test]
        public void Initialize_League_SetsCapacity_Correctly()
        {
            Assert.AreEqual(10, league.Capacity);
            Assert.AreEqual(0, league.Teams.Count);
        }

        [Test]
        public void AddTeam_WhenMaxCapacity_ThrowsAnException()
        {
            for (int i = 0; i < league.Capacity; i++)
            {
                league.AddTeam(new Team(i.ToString()));
            }

            var exception = Assert.Throws<InvalidOperationException>
                (() => league.AddTeam(testTeam)
            );

            Assert.AreEqual("League is full.", exception.Message);
        }

        [Test]
        public void AddTeam_WhenTeamExists_ThrowsAnException()
        {
            league.AddTeam(testTeam);

            var exception = Assert.Throws<InvalidOperationException>
                (() => league.AddTeam(testTeam)
            );

            Assert.AreEqual("Team already exists.", exception.Message);
        }

        [Test]
        public void AddTeam_Works_Correctly()
        {
            league.AddTeam(testTeam);

            Assert.AreEqual(1, league.Teams.Count);
        }

        [Test]
        public void RemoveTeam_WhenTeamDoesntExist_ReturnFalse()
        {
            league.AddTeam(testTeam);

            bool result = league.RemoveTeam(noneTeam);

            Assert.AreEqual(1, league.Teams.Count);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RemoveTeam_WhenTeamExist_ReturnTrue()
        {
            league.AddTeam(testTeam);

            bool result = league.RemoveTeam(testTeamName);

            Assert.AreEqual(0, league.Teams.Count);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void PlayMatch_WhenAwayTeamDoesNotExist_ThrowsAnException()
        {
            league.AddTeam(new Team(homeTeamName));
            league.AddTeam(new Team(awayTeamName));

            var exception = Assert.Throws<InvalidOperationException>
                (() => league.PlayMatch(homeTeamName, noneTeam, 2, 3)
            );

            Assert.AreEqual("One or both teams do not exist.", exception.Message);
        }

        [Test]  
        public void PlayMatch_WhenHomeTeamDoesNotExist_ThrowsAnException()
        {
            league.AddTeam(new Team(homeTeamName));
            league.AddTeam(new Team(awayTeamName));

            var exception = Assert.Throws<InvalidOperationException>
                (() => league.PlayMatch(noneTeam, awayTeamName, 2, 3)
            );

            Assert.AreEqual("One or both teams do not exist.", exception.Message);
        }

        [Test]  
        public void PlayMatch_Draw_AddsPointsCorrectly()
        {
            Team homeTeam = new Team(homeTeamName);
            Team awayTeam = new Team(awayTeamName);

            league.AddTeam(homeTeam);
            league.AddTeam(awayTeam);

            league.PlayMatch(homeTeamName, awayTeamName, 3, 3);

            Assert.AreEqual(1, homeTeam.Draws);
            Assert.AreEqual(1, awayTeam.Draws);
        }

        [Test]
        public void PlayMatch_WhenHomeWins_AddsPointsCorrectly()
        {
            Team homeTeam = new Team(homeTeamName);
            Team awayTeam = new Team(awayTeamName);

            league.AddTeam(homeTeam);
            league.AddTeam(awayTeam);

            league.PlayMatch(homeTeamName, awayTeamName, 5, 3);

            Assert.AreEqual(1, homeTeam.Wins);
            Assert.AreEqual(1, awayTeam.Loses);
        }

        [Test]
        public void PlayMatch_WhenAwayWins_AddPointsCorrectly()
        {
            Team homeTeam = new Team(homeTeamName);
            Team awayTeam = new Team(awayTeamName);

            league.AddTeam(homeTeam);
            league.AddTeam(awayTeam);

            league.PlayMatch(homeTeamName, awayTeamName, 1, 3);

            Assert.AreEqual(1, homeTeam.Loses);
            Assert.AreEqual(1, awayTeam.Wins);
        }

        [Test]
        public void GetTeamInfo_WhenTeamDoesNotExist_ThrowsAnException()
        {
            league.AddTeam(new Team(homeTeamName));

            var exception = Assert.Throws<InvalidOperationException>
                (() => league.GetTeamInfo(noneTeam)
            );

            Assert.AreEqual("Team does not exist.", exception.Message);
        }

        [Test]
        public void GetTeamInfo_ReturnsCorrectData()
        {
            var team = new Team(homeTeamName);

            league.AddTeam(team);

            string result = league.GetTeamInfo(homeTeamName);

            Assert.AreEqual(team.ToString(), result);   
        }
    }
}