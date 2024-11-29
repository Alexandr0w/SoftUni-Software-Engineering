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

        [SetUp]
        public void Setup()
        {
            league = new League();
            testTeam = new Team("test");
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

            bool result = league.RemoveTeam("None");

            Assert.AreEqual(1, league.Teams.Count);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RemoveTeam_WhenTeamExist_Return“rue()
        {
            league.AddTeam(testTeam);

            bool result = league.RemoveTeam("test");

            Assert.AreEqual(0, league.Teams.Count);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void PlayMatch_WhenAwayTeamDoesNotExist_ThrowsAnException()
        {
            league.AddTeam(new Team("home team"));
            league.AddTeam(new Team("away team"));

            var exception = Assert.Throws<InvalidOperationException>
                (() => league.PlayMatch("home team", "none", 2, 3)
            );

            Assert.AreEqual("One or both teams do not exist.", exception.Message);
        }

        [Test]  
        public void PlayMatch_WhenHomeTeamDoesNotExist_ThrowsAnException()
        {
            league.AddTeam(new Team("home team"));
            league.AddTeam(new Team("away team"));

            var exception = Assert.Throws<InvalidOperationException>
                (() => league.PlayMatch("none", "away team", 2, 3)
            );

            Assert.AreEqual("One or both teams do not exist.", exception.Message);
        }

        [Test]  
        public void PlayMatch_Draw_AddsPointsCorrectly()
        {
            Team homeTeam = new Team("home team");
            Team awayTeam = new Team("away team");

            league.AddTeam(homeTeam);
            league.AddTeam(awayTeam);

            league.PlayMatch("home team", "away team", 3, 3);

            Assert.AreEqual(1, homeTeam.Draws);
            Assert.AreEqual(1, awayTeam.Draws);
        }

        [Test]
        public void PlayMatch_WhenHomeWins_AddsPointsCorrectly()
        {
            Team homeTeam = new Team("home team");
            Team awayTeam = new Team("away team");

            league.AddTeam(homeTeam);
            league.AddTeam(awayTeam);

            league.PlayMatch("home team", "away team", 5, 3);

            Assert.AreEqual(1, homeTeam.Wins);
            Assert.AreEqual(1, awayTeam.Loses);
        }

        [Test]
        public void PlayMatch_WhenAwayWins_AddPointsCorrectly()
        {
            Team homeTeam = new Team("home team");
            Team awayTeam = new Team("away team");

            league.AddTeam(homeTeam);
            league.AddTeam(awayTeam);

            league.PlayMatch("home team", "away team", 1, 3);

            Assert.AreEqual(1, homeTeam.Loses);
            Assert.AreEqual(1, awayTeam.Wins);
        }

        [Test]
        public void GetTeamInfo_WhenTeamDoesNotExist_ThrowsAnException()
        {
            league.AddTeam(new Team("home team"));

            var exception = Assert.Throws<InvalidOperationException>
                (() => league.GetTeamInfo("None")
            );

            Assert.AreEqual("Team does not exist.", exception.Message);
        }

        [Test]
        public void GetTeamInfo_ReturnsCorrectData()
        {
            var team = new Team("home team");

            league.AddTeam(team);

            string result = league.GetTeamInfo("home team");

            Assert.AreEqual(team.ToString(), result);   
        }
    }
}