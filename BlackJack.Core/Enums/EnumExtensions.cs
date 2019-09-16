using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Core.Enums
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> EnumToList<T>() where T : struct
        {
            if (typeof(T).BaseType != typeof(Enum))
                throw new ArgumentException($"T must be of type {typeof(Enum).FullName}");

            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}