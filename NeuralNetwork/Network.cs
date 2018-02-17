using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NeuralNetworks
{
    public class Network
    {
        public int[] Sizes { get; set; }
        public int NumberOfLayers { get; set; }
        public List<double[,]> Biases { get; set; }
        public List<double[,]> Weights { get; set; }

        public Network(int[] sizes)
        {
            Sizes = sizes;
            NumberOfLayers = sizes.Length;
            Biases = CreateBiasMatrices(sizes);
            Weights = CreateBiasMatrices(sizes);
        }

        private List<double[,]> CreateBiasMatrices(int[] sizes)
        {
            var biasMatrices = new List<double[,]>();
            var random = new Random();
            for (int i = 1; i < sizes.Length; i++)
            {
                biasMatrices.Add(new double[sizes[i], 1]);
                for (int j = 0; j < sizes[i]; j++)
                {
                        biasMatrices[i-1][j, 0] = random.NextDouble();
                }
            }
            return biasMatrices;
        }

        private List<double[,]> CreateWeightMatrices(int[] sizes)
        {
            var weightMatrices = new List<double[,]>();
            var random = new Random();
            for (int i = 0; i < sizes.Length; i++)
            {
                weightMatrices.Add(new double[sizes[i], sizes[i+1]]);
                for (int j = 0; j < sizes[i]; j++)
                {
                    for (int k = 0; k < sizes[i+1]; k++)
                    {
                        weightMatrices[i][j, k] = random.NextDouble();
                    }
                }
            }
            return weightMatrices;
        }

        public double[] EvalSigmoideFunction(double[] zet)
        {
            var outputActivation = new double[zet.Length]; 
            for (int i = 0; i < zet.Length; i++)
            {
                outputActivation[i] = 1 / (1 + Math.Exp(-zet[i]));
            }
            return outputActivation;
        }

        public double[] FeedForward(double[] input, List<double[,]> weights, List<double[,]> biases)
        {
            double[] sigmoideInput;
            for (int i = 0; i < biases.Count; i++)
            {
                sigmoideInput = PrepareInputForSigmoide(input, weights[i], biases[i]);
                input = EvalSigmoideFunction(input);
            }
            return new double[input.Length];
        }

        private double[] PrepareInputForSigmoide(double[] input, double[,] weightMatrix, double[,] biasVector)
        {
            double[] inputForSigmoide = new double[biasVector.Length];
            for (int i = 0; i < biasVector.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    inputForSigmoide[i] += input[j] * weightMatrix[i, j];
                }
                inputForSigmoide[i] -= biasVector[i,1];
            }
            return inputForSigmoide;
        }
    }
}

