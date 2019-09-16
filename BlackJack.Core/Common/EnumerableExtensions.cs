//Ulf Möllerström
//2019-09-18
//MAUCS3A01: "Blackjack Game"

using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Core.Common
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Random<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            //For better "randomness" one can use RandomNumberGenerator in System.Security.Cryptography
            var random = new Random();
            return enumerable.OrderBy(item => random.Next());
        }
    }
}