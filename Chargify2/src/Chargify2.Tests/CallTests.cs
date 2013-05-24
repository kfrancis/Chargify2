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
            string knownCallId = "50306403dc8d3da45a406d2c3167365292fef445";
            var client = GetClient();

            // Act
            var callResult = client.ReadCall(knownCallId);

            // Assert
            Assert.IsNotNull(callResult);
            Assert.IsTrue(callResult.id == knownCallId);
        }

        private Client GetClient()
        {
            var client = new Client("5caeb840-80b1-0130-018d-0265669c19df", "6ZIE3odwU7HXFcwidhKS", "Foc_FSMEm-1IyQ0nev5h");
            return client;
        }
    }
}
