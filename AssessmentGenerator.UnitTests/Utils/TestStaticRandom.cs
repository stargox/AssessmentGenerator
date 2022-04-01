using AssessmentGenerator.Models;
using System.Collections.Generic;

namespace AssessmentGenerator.UnitTests.Utils
{
    public class TestStaticRandom : IRandom
    {
        private IList<int> _values;
        private int _currentPosition;

        public TestStaticRandom(IList<int> values) => _values = values;

        public int Next(int maxValue)
        {
            return _values[_currentPosition++];
        }
    }
}
