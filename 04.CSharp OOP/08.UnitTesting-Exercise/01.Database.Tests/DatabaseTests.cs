namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private const int MaxDatabaseSize = 16;

        [TestCaseSource(nameof(GetValidDatabaseSize))]
        public void DatabaseShouldBeInitializedCorrectly(int n)
        {
            int[] data = GenerateRandomArray(n);

            Database database = new Database(data);

            AssertCorrectContent(database, data);
        }

        [Test]
        public void AddShouldWorkCorrectly()
        {
            int[] data = GenerateRandomArray(MaxDatabaseSize);

            Database database = new Database();

            for (int i = 0; i < MaxDatabaseSize; i++)
            {
                database.Add(data[i]);

                AssertCorrectContent(database, data.Take(i + 1).ToArray());
            }
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            int[] data = GenerateRandomArray(MaxDatabaseSize);

            Database database = new Database(data.ToArray());

            for (int i = 0; i < MaxDatabaseSize; i++)
            {
                database.Remove();
                AssertCorrectContent(database, data.Take(MaxDatabaseSize - (i + 1)).ToArray());
            }
        }

        [Test]
        public void AddWhenCapacityLimitIsReachedShouldThrowException()
        {
            Database database = new Database(GenerateRandomArray(MaxDatabaseSize));

            Assert.Throws<InvalidOperationException>(
                () => database.Add(Random.Shared.Next())    
            );
        }

        [Test]
        public void RemoveFromEmptyDatabaseShouldThrowAnException()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(
                () => database.Remove()
            );
        }

        public static IEnumerable<object[]> GetValidDatabaseSize()
        {
            for (int i = 0; i <= MaxDatabaseSize; i++)
            {
                yield return new object[] { i };
            }
        }

        private static int[] GenerateRandomArray(int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = Random.Shared.Next();
            }

            return result;
        }

        private static void AssertCorrectContent(Database database, int[] expectedData)
        {
            Assert.That(database.Count, Is.EqualTo(expectedData.Length));

            int[] fetchResult = database.Fetch();
            Assert.That(fetchResult, Is.Not.SameAs(expectedData));
            Assert.That(fetchResult, Has.Length.EqualTo(expectedData.Length));
            Assert.That(fetchResult, Is.EqualTo(expectedData));
        }
    }
}
