using Newtonsoft.Json;
using System.Text;

namespace ThatBlokeCalledJay.Common.Extensions
{
    public static class JsonExtensions
    {
        /// <summary>Serialize to Json string.</summary>
        public static string JsonSerialize<T>(this T data, JsonSerializerSettings settings = null) where T : class
        {
            return data == null
                ? null
                : settings == null ? JsonConvert.SerializeObject(data) : JsonConvert.SerializeObject(data, settings);
        }

        /// <summary>Deserialize Json string into the specified type of T.</summary>
        public static T JsonDeserialize<T>(this string jsonString, JsonSerializerSettings settings = null) where T : class
        {
            if (string.IsNullOrWhiteSpace(jsonString))
                return default(T);

            return settings == null ? JsonConvert.DeserializeObject<T>(jsonString) : JsonConvert.DeserializeObject<T>(jsonString, settings);
        }

        /// <summary>Convert byte array to UTF8 json string, then deserialize to specified type.</summary>
        public static T JsonByteArrayTo<T>(this byte[] data, JsonSerializerSettings settings = null) where T : class
        {
            if (data == null || data.Length == 0)
                return default(T);

            var json = Encoding.UTF8.GetString(data);
            return settings == null ? json.JsonDeserialize<T>() : json.JsonDeserialize<T>(settings);
        }
    }
}