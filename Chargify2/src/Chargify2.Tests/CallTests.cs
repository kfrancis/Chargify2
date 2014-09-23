using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chargify2.Tests
{
    [TestClass]
    public class CallTests
    {
        [TestMethod]
        public void Can_Retrieve_Call()
        {
            // Arrange
            string knownCallId = "<call id>";
            var client = GetClient();

            // Act
            var callResult = client.ReadCall(knownCallId);

            // Assert
            Assert.IsNotNull(callResult);
            Assert.IsTrue(callResult.id == knownCallId);
        }

        private Client GetClient()
        {
            var client = new Client("<api key>", "<api_password>", "<api secret>");
            return client;
        }
    }
}
