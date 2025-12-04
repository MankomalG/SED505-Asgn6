// files/complex/IOnlineModel.cs
namespace HashedFeatureCTR
{
    /// <summary>
    /// Abstraction for online learning models that can be updated one example at a time.
    /// </summary>
    public interface IOnlineModel
    {
        double Predict(double[] features);
        void Update(double[] features, int label);
    }
}
