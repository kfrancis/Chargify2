using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Chargify2
{
    public static class Utils
    {
        public static string CalculateSignature(this string message, string secret)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
            byte[] messageBytes = encoding.GetBytes(message);
            byte[] hashMessage = hmacsha1.ComputeHash(messageBytes);
            string hexaHash = "";
            foreach (byte b in hashMessage) { hexaHash += String.Format("{0:x2}", b); }
            return hexaHash;
        }

        public static string ToQueryString(this Hashtable hashtable)
        {
            string tmp = "";
            IDictionaryEnumerator myEnumerator = hashtable.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                if (tmp.Length > 0) tmp += "&";
                tmp += myEnumerator.Key + "=" + myEnumerator.Value;
            }
            return tmp;
        }

        public static IEnumerable<U> Map<T, U>(this IEnumerable<T> s, Func<T, U> f)
        {
            foreach (var item in s)
                yield return f(item);
        }
    }
}
