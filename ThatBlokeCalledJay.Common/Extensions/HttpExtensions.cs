using System.Net;

namespace ThatBlokeCalledJay.Common.Extensions
{
    public static class HttpExtensions
    {
        /// <summary>
        /// Indicates whether the statusCode is between code 200 and 299 inclusive. Returns false if statusCode is null.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static bool IsSuccessStatusCode(this HttpStatusCode? statusCode)
        {
            if (statusCode == null)
                return false;

            var intCode = (int)statusCode;

            return Ensure.IsBetween(intCode, "", 200, 299, false);
        }
    }
}