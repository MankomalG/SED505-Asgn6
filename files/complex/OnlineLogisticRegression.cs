// files/complex/OnlineLogisticRegression.cs
using System;

namespace HashedFeatureCTR
{
    /// <summary>
    /// Simple online logistic regression trained via SGD on hashed features.
    /// </summary>
    public class OnlineLogisticRegression : IOnlineModel
    {
        private readonly double[] _weights;
        private readonly double _learningRate;

        public OnlineLogisticRegression(int numFeatures, double learningRate = 0.01)
        {
            if (numFeatures <= 0)
                throw new ArgumentOutOfRangeException(nameof(numFeatures));

            _weights = new double[numFeatures];
            _learningRate = learningRate;
        }

        private static double Sigmoid(double z)
        {
            return 1.0 / (1.0 + Math.Exp(-z));
        }

        public double Predict(double[] features)
        {
            double dot = 0.0;
            for (int i = 0; i < features.Length; i++)
            {
                dot += _weights[i] * features[i];
            }

            return Sigmoid(dot);
        }

        public void Update(double[] features, int label)
        {
            if (label != 0 && label != 1)
                throw new ArgumentOutOfRangeException(nameof(label), "Label must be 0 or 1.");

            double prediction = Predict(features);
            double error = label - prediction;

            for (int i = 0; i < features.Length; i++)
            {
                _weights[i] += _learningRate * error * features[i];
            }
        }
    }
}
