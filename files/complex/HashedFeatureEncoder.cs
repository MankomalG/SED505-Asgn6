// files/complex/HashedFeatureEncoder.cs
using System;
using System.Collections.Generic;

namespace HashedFeatureCTR
{
    /// <summary>
    /// Implementation of the Hashed Feature pattern for mixed categorical + numeric features.
    /// </summary>
    public class HashedFeatureEncoder : IFeatureEncoder
    {
        public int NumBuckets { get; }

        public HashedFeatureEncoder(int numBuckets)
        {
            if (numBuckets <= 0)
                throw new ArgumentOutOfRangeException(nameof(numBuckets), "numBuckets must be positive.");

            NumBuckets = numBuckets;
        }

        public double[] Encode(
            Dictionary<string, string> categorical,
            Dictionary<string, double>? numeric = null)
        {
            var vector = new double[NumBuckets];

            // 1) Categorical features: "name=value" -> hash bucket
            foreach (var kv in categorical)
            {
                string key = $"{kv.Key}={kv.Value}";
                int rawHash = key.GetHashCode();
                int index = Math.Abs(rawHash) % NumBuckets;

                int sign = (rawHash % 2 == 0) ? 1 : -1;
                vector[index] += sign;
            }

            // 2) Numeric features: hash the feature name, add numeric value
            if (numeric != null)
            {
                foreach (var kv in numeric)
                {
                    string key = kv.Key;
                    double value = kv.Value;

                    int rawHash = key.GetHashCode();
                    int index = Math.Abs(rawHash) % NumBuckets;

                    vector[index] += value;
                }
            }

            return vector;
        }
    }
}
