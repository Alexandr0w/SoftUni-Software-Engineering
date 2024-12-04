using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository repo;

        [SetUp]
        public void Setup()
        {
            repo = new InfluencerRepository();
        }

        [Test]
        public void InfluencerRepository_EnsureCtorInitializesEmptyList()
        {
            Assert.IsNotNull(repo.Influencers);
        }

        [Test]
        public void RegisterInfluencer_ThrowsWithNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => repo.RegisterInfluencer(null!));
        }

        [Test]
        public void RegisterInfluencer_ThrowsWhenAddingAlreadyExistingInfluencer()
        {
            Influencer influencer = new Influencer("Infl_UserName", 15000);

            repo.RegisterInfluencer(influencer);

            Assert.Throws<InvalidOperationException>(() => repo.RegisterInfluencer(influencer));
        }

        [Test]
        public void RegisterInfluencer_ValidRegistration()
        {
            Influencer influencer = new Influencer("Infl_UserName", 15000);

            var actualResult = repo.RegisterInfluencer(influencer);
            var expectedResult = $"Successfully added influencer Infl_UserName with 15000";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(repo.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveInfluencer_ThrowsWhenTryToRemoveWithNullParam()
        {
            Assert.Throws<ArgumentNullException>(() => repo.RemoveInfluencer(null!));
        }

        [Test]
        public void RemoveInfluencer_ReturnsTrueIfRemovedSuccessfully()
        {
            Influencer influencer = new Influencer("Infl_UserName", 15000);

            repo.RegisterInfluencer(influencer);

            Assert.That(repo.RemoveInfluencer("Infl_UserName"), Is.True);
        }

        [Test]
        public void RemoveInfluencer_ReturnsFalseIfNotRemovedSuccessfully()
        {
            Assert.That(repo.RemoveInfluencer("Infl_UserName"), Is.False);
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ReturnsCorrectEntity()
        {
            Influencer influencer1 = new Influencer("Infl_UserName1", 15000);
            Influencer influencer2 = new Influencer("Infl_UserName2", 25000);
            Influencer influencer3 = new Influencer("Infl_UserName3", 17000);

            repo.RegisterInfluencer(influencer1);
            repo.RegisterInfluencer(influencer2);
            repo.RegisterInfluencer(influencer3);

            var mostFollowers = repo.GetInfluencerWithMostFollowers().Followers;
            var expectedFollowers = influencer2.Followers;

            Influencer returnedInfluencer = repo.GetInfluencerWithMostFollowers();

            Assert.That(mostFollowers, Is.EqualTo(expectedFollowers));
            Assert.That(influencer2, Is.SameAs(returnedInfluencer));
        }

        [Test]
        public void GetInfluencer_ReturnsCorrectEntity()
        {
            Influencer influencer1 = new Influencer("Infl_UserName1", 15000);
            Influencer influencer2 = new Influencer("Infl_UserName2", 25000);
            Influencer influencer3 = new Influencer("Infl_UserName3", 17000);

            repo.RegisterInfluencer(influencer1);
            repo.RegisterInfluencer(influencer2);
            repo.RegisterInfluencer(influencer3);

            var returnedInfluencer = repo.GetInfluencer("Infl_UserName3");

            Assert.That(influencer3, Is.SameAs(returnedInfluencer));
        }

        [Test]
        public void GetInfluencer_ReturnsNullWhenNoMatchFound()
        {
            Influencer influencer1 = new Influencer("Infl_UserName1", 15000);
            Influencer influencer2 = new Influencer("Infl_UserName2", 25000);
            Influencer influencer3 = new Influencer("Infl_UserName3", 17000);

            repo.RegisterInfluencer(influencer1);
            repo.RegisterInfluencer(influencer2);
            repo.RegisterInfluencer(influencer3);

            var returnedInfluencer = repo.GetInfluencer("Infl_UserName4");

            Assert.IsNull(returnedInfluencer);
        }
    }
}