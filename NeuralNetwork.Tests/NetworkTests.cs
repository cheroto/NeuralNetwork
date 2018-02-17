using System;
using System.Linq;
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

        [Test]
        public void Sigmoide_Correct_Output_Success()
        {
            //Arrange
            var expectedOutput = 2.56441;

            //Act
            var actualResult = _network.EvalSigmoideFunction(new []{ 1d, 2d, 3d }).Sum();

            //Assert
            Assert.AreEqual(Math.Round(expectedOutput, 4), Math.Round(actualResult, 4));
            

        }

        [Test]
        public void PrepareInputForSigmoide_Correct_Output_Success()
        {
            //Arrange
            var expectedOutput = 3;

            //Act
            var actualOutput = _network.PrepareInputForSigmoide(
                new double[] { 1, 1 }, 
                new double[,] { { 1, 1 }, { 1, 1 }, { 1, 1 } },
                new double[,] { { 1 }, { 1 }, { 1 } }).Sum();

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [Test]
        public void FeedForward_Run_Success()
        {
            //Arrange
            var input = new double[]{ 1, 1 };
            var biases = _network.Biases;
            var weights = _network.Weights;

            //Act
            var output = _network.FeedForward(input, weights, biases);

            //Assert
            Assert.Pass();

        }
    }
}
