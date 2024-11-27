namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        private static string GenerateRandomString()
        {
            int randomTextLength = Random.Shared.Next(minValue: 5, maxValue: 50);
            return GenerateRandomString(randomTextLength);
        }

        private static string GenerateRandomString(int length)
        {
            char[] symbols = new char[length];
            for (var i = 0; i < length; i++)
            {
                int randomLetterIndex = Random.Shared.Next(maxValue: 26);
                symbols[i] = (char)('a' + randomLetterIndex);
            }

            return new string(symbols);
        }
    }
}
