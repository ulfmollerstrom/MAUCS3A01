using System.Collections.Generic;
using BlackJack.Core.Enums;

namespace BlackJack.Core.Infrastucture
{
    public class SuiteOfCards
    {
        public Suites Suite { get; set; }
        public IDictionary<Cards, int> Values { get; set; }
    }
}