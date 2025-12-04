// files/simple/SimpleHashedFeatureEncoder.cs
using System;

namespace HashedFeatureSimple
{
    /// <summary>
    /// Simple implementation of the Hashed Feature pattern for one categorical feature.
    /// </summary>
    public class SimpleHashedFeatureEncoder : IFeatureEncoder
    {
        public double[] Encode(string value, int numBuckets)
        {
            if (numBuckets <= 0)
                throw new ArgumentOutOfRangeException(nameof(numBuckets), "numBuckets must be positive.");

            var features = new double[numBuckets];

            // 1) Hash the string to an integer
            int rawHash = value.GetHashCode();

            // 2) Map hash to [0, numBuckets)
            int index = Math.Abs(rawHash) % numBuckets;

            // 3) Optional signed hashing: +1 or -1
            int sign = (rawHash % 2 == 0) ? 1 : -1;

            features[index] += sign;

            return features;
        }
    }
}
