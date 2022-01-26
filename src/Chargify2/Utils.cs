using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Chargify2
{
    /// <summary>
    /// Extension class
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Calculates the signature using the formula given by Chargify
        /// </summary>
        /// <param name="message">The message to use in creating the signature</param>
        /// <param name="secret">The api secret</param>
        /// <returns>The calculated signature</returns>
        public static string CalculateSignature(this string message, string secret)
        {
            var encoding = new ASCIIEncoding();
            var keyByte = encoding.GetBytes(secret);
            var hmacsha1 = new HMACSHA1(keyByte);
            var messageBytes = encoding.GetBytes(message);
            var hashMessage = hmacsha1.ComputeHash(messageBytes);
            var hexaHash = "";
            foreach (var b in hashMessage) { hexaHash += string.Format("{0:x2}", b); }
            return hexaHash;
        }

        /// <summary>
        /// Toes the query string.
        /// </summary>
        /// <param name="hashtable">The hashtable.</param>
        /// <returns>The query string</returns>
        public static string ToQueryString(this Hashtable hashtable)
        {
            var tmp = "";
            var myEnumerator = hashtable.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                if (tmp.Length > 0) tmp += "&";
                tmp += myEnumerator.Key + "=" + myEnumerator.Value;
            }
            return tmp;
        }

        /// <summary>
        /// Maps the specified s.
        /// </summary>
        /// <typeparam name="T">The type of the T.</typeparam>
        /// <typeparam name="U">The type of the U.</typeparam>
        /// <param name="s">The s.</param>
        /// <param name="f">The f.</param>
        /// <returns></returns>
        public static IEnumerable<U> Map<T, U>(this IEnumerable<T> s, Func<T, U> f)
        {
            foreach (var item in s)
                yield return f(item);
        }
    }
}
