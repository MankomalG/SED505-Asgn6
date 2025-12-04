// files/complex/IFeatureEncoder.cs
using System.Collections.Generic;

namespace HashedFeatureCTR
{
    /// <summary>
    /// Interface for encoders that map raw feature dictionaries into numeric vectors.
    /// </summary>
    public interface IFeatureEncoder
    {
        double[] Encode(
            Dictionary<string, string> categorical,
            Dictionary<string, double>? numeric = null);
    }
}
