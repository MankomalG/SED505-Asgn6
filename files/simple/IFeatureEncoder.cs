// files/simple/IFeatureEncoder.cs
namespace HashedFeatureSimple
{
    /// <summary>
    /// Minimal interface for a feature encoder that produces a fixed-size vector.
    /// </summary>
    public interface IFeatureEncoder
    {
        /// <summary>
        /// Encode a single categorical value into a numeric feature vector.
        /// </summary>
        double[] Encode(string value, int numBuckets);
    }
}
