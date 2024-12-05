namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation station;
        private string name = "Sofia Station";

        [SetUp]
        public void Setup()
        {
            this.station = new RailwayStation(name);
        }

        [Test]
        public void Constructor_ShouldInitializedCorrectly()
        {
            Assert.That(name, Is.EqualTo(station.Name));
            Assert.IsEmpty(station.ArrivalTrains);
            Assert.IsEmpty(station.DepartureTrains);
        }

        [Test]
        public void Constructor_InvalidName_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RailwayStation(null));
            Assert.Throws<ArgumentException>(() => new RailwayStation(" "));
            Assert.Throws<ArgumentException>(() => new RailwayStation("  "));
        }
        
        [Test]
        public void NewArrivalOnBoard_ShouldAddTrainToArrivalQueue()
        {
            station.NewArrivalOnBoard("Train A");

            Assert.AreEqual(1, station.ArrivalTrains.Count);
            Assert.AreEqual("Train A", station.ArrivalTrains.Peek());
        }

        [Test]
        public void TrainHasArrived_CorrectOrder_ShouldMoveTrainToDepartureQueue()
        {
            station.NewArrivalOnBoard("Train A");
            string result = station.TrainHasArrived("Train A");

            Assert.AreEqual("Train A is on the platform and will leave in 5 minutes.", result);
            Assert.IsEmpty(station.ArrivalTrains);
            Assert.AreEqual(1, station.DepartureTrains.Count);
            Assert.AreEqual("Train A", station.DepartureTrains.Peek());
        }

        [Test]
        public void TrainHasArrived_WrongOrder_ShouldReturnErrorMessage()
        {
            station.NewArrivalOnBoard("Train A");
            station.NewArrivalOnBoard("Train B");

            string result = station.TrainHasArrived("Train B");

            Assert.AreEqual("There are other trains to arrive before Train B.", result);
            Assert.AreEqual(2, station.ArrivalTrains.Count);
        }

        [Test]
        public void TrainHasLeft_WhenTrainIsFirstInQueue_ReturnsTrue()
        {
            station.DepartureTrains.Enqueue("Train A");
            station.DepartureTrains.Enqueue("Train B");

            bool result = station.TrainHasLeft("Train A");

            Assert.IsTrue(result);
            Assert.AreEqual(1, station.DepartureTrains.Count);
            Assert.AreEqual("Train B", station.DepartureTrains.Peek());
        }

        [Test]
        public void TrainHasLeft_WhenTrainIsNotFirstInQueue_ReturnsFalse()
        {
            station.DepartureTrains.Enqueue("Train A");
            station.DepartureTrains.Enqueue("Train B");

            bool result = station.TrainHasLeft("Train B");

            Assert.IsFalse(result);
            Assert.AreEqual(2, station.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasLeft_WhenQueueIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => station.TrainHasLeft("Train A"));
        }
    }
}