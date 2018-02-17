using System;
using NUnit;

using NUnit.Framework;

namespace NeuralNetworks.Tests
{
    [TestFixture]
    public class NetworkTests
    {
        private Network _network;

        [SetUp]
        public void SetUp()
        {
            _network = new Network(new[] { 2, 3, 1 });
        }


        [Test]
        public void Instance_NumberofLayers_Success()
        {
            //Arrange
            var expectedOutput = 3;

            //Act
            var actualOutput = _network.NumberOfLayers;

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
