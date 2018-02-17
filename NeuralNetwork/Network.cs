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

        private const int IsBias = 1;
        private const int NotBias = 0;
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

    }
}

