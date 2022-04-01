using AssessmentGenerator.Models;
using System;

namespace AssessmentGenerator.UnitTests.Utils
{
    public class TestRandom : IRandom
    {
        private readonly Random _random = new Random();

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}
