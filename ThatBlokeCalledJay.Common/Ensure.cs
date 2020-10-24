using System;
using System.Collections.Generic;
using System.Linq;

namespace ThatBlokeCalledJay.Common
{
    /// <summary>
    /// Common Ensure Functionality
    /// </summary>
    public class Ensure
    {
        ///<exception cref="ArgumentNullException"></exception>
        public static bool NotNullOrWhiteSpace(string argument, string argumentName, bool throwException = true)
        {
            if (!string.IsNullOrWhiteSpace(argument)) return true;
            if (throwException)
                throw new ArgumentNullException(argumentName, $"Value cannot be null or empty '{argumentName}'");

            return false;
        }

        ///<exception cref="ArgumentNullException"></exception>
        public static bool NotNull(object argument, string argumentName, bool throwException = true)
        {
            if (argument != null) return true;
            if (throwException)
                throw new ArgumentNullException(argumentName, $"Value cannot be null '{argumentName}'");

            return false;
        }

        /// <summary>Ensure an IEnumerable is not null or empty.</summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool NotNullOrEmpty<T>(IEnumerable<T> collection, string argumentName, bool throwException = true)
        {
            if ((collection?.Any()).GetValueOrDefault()) return true;

            if (throwException)
                throw new ArgumentNullException(argumentName, $"Collection cannot be null or empty'{argumentName}'");

            return false;
        }

        /// <summary>
        /// Ensure the provided <paramref name="argument"/> type matches that of T<para>Note: This method will also fail if <paramref name="argument"/> is null.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool ObjectIsOfType<T>(object argument, string argumentName, bool throwException = true)
        {
            var type = typeof(T);
            var objectType = argument?.GetType();

            if (objectType == null)
            {
                if (throwException) throw new ArgumentNullException(argumentName, "Cannot compare type of null object.");
                return false;
            }

            if (type == objectType)
                return true;

            if (throwException)
                throw new ArgumentException($"Unexpected type, was expecting {type.Name} but got {objectType.Name}", argumentName);

            return false;
        }

        /// <summary>Ensure <paramref name="value"/> is equal to or more than <paramref name="minValue"/></summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool NotBelow(int value, string argumentName, int minValue, bool throwException = true)
        {
            if (value >= minValue)
                return true;

            if (throwException)
                throw new ArgumentOutOfRangeException(argumentName, $"Minimum value expected was {minValue} but was {value}");

            return false;
        }

        /// <summary>Ensure <paramref name="value"/> is equal to or more than <paramref name="minValue"/></summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool NotBelow(decimal value, string argumentName, decimal minValue, bool throwException = true)
        {
            if (value >= minValue)
                return true;

            if (throwException)
                throw new ArgumentOutOfRangeException(argumentName, $"Minimum value expected was {minValue} but was {value}");

            return false;
        }

        /// <summary>Ensure <paramref name="value"/> is equal to or less than <paramref name="maxValue"/></summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool NotAbove(int value, string argumentName, int maxValue, bool throwException = true)
        {
            if (value <= maxValue)
                return true;

            if (throwException)
                throw new ArgumentOutOfRangeException(argumentName, $"Maximum value expected was {maxValue} but was {value}");

            return false;
        }

        /// <summary>Ensure <paramref name="value"/> is equal to or less than <paramref name="maxValue"/></summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool NotAbove(decimal value, string argumentName, decimal maxValue, bool throwException = true)
        {
            if (value <= maxValue)
                return true;

            if (throwException)
                throw new ArgumentOutOfRangeException(argumentName, $"Maximum value expected was {maxValue} but was {value}");

            return false;
        }

        /// <summary>Ensure <paramref name="value"/> is more than or equal to <paramref name="minValue"/> and also less than or equal to <paramref name="maxValue"/></summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool IsBetween(int value, string argumentName, int minValue, int maxValue, bool throwException = true)
        {
            var notAbove = NotAbove(minValue, nameof(minValue), maxValue, throwException);

            if (!notAbove)
                return false;

            if (value <= maxValue && value >= minValue)
                return true;

            if (throwException)
                throw new ArgumentOutOfRangeException(argumentName, $"Value range expected was {minValue} to {maxValue} but value was {value}");

            return false;
        }

        /// <summary>Ensure <paramref name="value"/> is more than or equal to <paramref name="minValue"/> and also less than or equal to <paramref name="maxValue"/></summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool IsBetween(decimal value, string argumentName, decimal minValue, decimal maxValue, bool throwException = true)
        {
            var notAbove = NotAbove(minValue, nameof(minValue), maxValue, throwException);

            if (!notAbove)
                return false;

            if (value <= maxValue && value >= minValue)
                return true;

            if (throwException)
                throw new ArgumentOutOfRangeException(argumentName, $"Value range expected was {minValue} to {maxValue} but value was {value}");

            return false;
        }

        /// <summary></summary>
        /// <exception cref="ArgumentException"></exception>
        public static bool NotNullOrEmpty<T>(T[] argument, string argumentName, bool throwException = true)
        {
            if (argument != null && argument.Length > 0) return true;
            if (throwException)
                throw new ArgumentException($"Array cannot be null or empty'{argumentName}'", argumentName);

            return false;
        }
    }
}