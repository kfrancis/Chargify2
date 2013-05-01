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
            string knownCallId = "17dcbe33814c8995343f27e124fd0123e84f4634";
            var client = GetClient();

            // Act
            var callResult = client.ReadCall(knownCallId);

            // Assert
            Assert.IsNotNull(callResult);
            Assert.IsTrue(callResult.id == knownCallId);
        }

        private Client GetClient()
        {
            var client = new Client("", "", "");
            return client;
        }
    }
}
