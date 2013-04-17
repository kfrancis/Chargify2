using System;
using System.Collections;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chargify2.Tests
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void Can_Calculate_Valid_Signature()
        {
            // Arrange
            string message = "test123";
            string secret = "secret";

            // Act
            var calculatedSignature = message.CalculateSignature(secret);

            // Assert
            Assert.IsNotNull(calculatedSignature);
            Assert.IsInstanceOfType(calculatedSignature, typeof(string));
            Assert.IsTrue(calculatedSignature.Length > 0);
            Assert.IsTrue(Encoding.ASCII.GetByteCount(calculatedSignature) == 40);
        }

        [TestMethod]
        public void Can_Get_QueryString_From_Hashtable()
        {
            // Arrange
            Hashtable hashtable = new Hashtable();
            hashtable.Add("key1", "value1");
            hashtable.Add("key2", "value2");
            hashtable.Add("key3", "value3");

            // Act
            var queryString = hashtable.ToQueryString();

            // Assert
            Assert.IsNotNull(queryString);
            Assert.IsInstanceOfType(queryString, typeof(string));
            Assert.IsTrue(queryString.Contains("key1=value1"));
            Assert.IsTrue(queryString.Contains("key2=value2"));
            Assert.IsTrue(queryString.Contains("key3=value3"));
        }
    }
}
