using System;
using System.Threading.Tasks;
using Chargify2.Model;
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
            var result = client.ReadCall(knownCallId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Call));
            Assert.AreEqual(knownCallId, result.id);
        }

        [TestMethod]
        public async Task Can_Retrieve_Call_Async()
        {
            // Arrange
            string knownCallId = "<call id>";
            var client = GetClient();

            var result = await client.ReadCallAsync(knownCallId);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Call));
            Assert.AreEqual(knownCallId, result.id);
        }

        private Client GetClient()
        {
            var client = new Client("<api key>", "<api_password>", "<api secret>");
            return client;
        }
    }
}
