using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ThatBlokeCalledJay.Common
{
    /// <summary></summary>
    public class CommonUtilities
    {
        /// <summary>
        /// Get a class's public, static or const string values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> GetOptionValues<T>() where T : class
        {
            var type = typeof(T);

            const BindingFlags flags = BindingFlags.Static | BindingFlags.Public;

            return type.GetFields(flags).Select(f => (string)f.GetValue(null)).ToList();
        }
    }
}