using System;
using System.Collections.Generic;

namespace ThatBlokeCalledJay.Common.Extensions
{
    /// <summary></summary>
    public static class CommonExtensions
    {
        /// <summary>Add KeyValue to dictionary. if key doesn't exist, key will be created with the new value. If the key does exist, the value will be updated.</summary>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> data, TKey key, TValue value)
        {
            if (data == null)
                data = new Dictionary<TKey, TValue>();

            if (!data.ContainsKey(key))
                data.Add(key, value);
            else
                data[key] = value;
        }

        /// <summary>
        /// Return specified value if it is not null or empty, otherwise return <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetValueOrDefault(this string value, string defaultValue = "")
        {
            return string.IsNullOrWhiteSpace(value)
                ? defaultValue
                : value;
        }

        /// <summary>
        /// Returns the <see cref="DateTimeOffset"/> value as a Formatted string. If dateTime is null, defaultValue string will be returned.
        /// </summary>
        public static string FormatStringOrDefault(this DateTimeOffset? dateTime, string defaultValue = "", string format = "yyyy-MM-dd HH:mm:ss")
        {
            return dateTime.HasValue == false ? defaultValue : dateTime.Value.ToString(format);
        }
    }
}