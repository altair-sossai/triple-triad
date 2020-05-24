using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace TripleTriad.Helpers
{
    public static class EnumHelper
    {
        private static string GetDescription<T>(this T enumValue)
        {
            return enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DescriptionAttribute>()
                ?.Description ?? enumValue.ToString();
        }

        public static Dictionary<T, string> GetValuesAndDescriptions<T>()
        {
            return GetValues<T>()
                .ToDictionary(k => k, GetDescription);
        }

        public static T RandomValue<T>()
        {
            return GetValues<T>()
                .OrderBy(o => Guid.NewGuid())
                .First();
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum
                .GetValues(typeof(T))
                .Cast<T>();
        }
    }
}