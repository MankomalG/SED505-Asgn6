// files/complex/CtrExampleProgram.cs
using System;
using System.Collections.Generic;

namespace HashedFeatureCTR
{
    /// <summary>
    /// Complex demo: CTR prediction with hashed features + online logistic regression.
    /// </summary>
    internal class CtrExampleProgram
    {
        public static void Run(string[] args)
        {
            int numBuckets = 1 << 15; // 32768 buckets
            IFeatureEncoder encoder = new HashedFeatureEncoder(numBuckets);
            IOnlineModel model = new OnlineLogisticRegression(numBuckets, learningRate: 0.05);

            // One training example: user clicked the ad (label = 1)
            var categorical = new Dictionary<string, string>
            {
                { "user_id", "U123456" },
                { "ad_id", "AD789" },
                { "device_type", "mobile" },
                { "country", "CA" },
                { "referrer_domain", "news.example.com" }
            };

            var numeric = new Dictionary<string, double>
            {
                { "hour_of_day", 14 },
                { "days_since_signup", 30 }
            };

            int label = 1; // clicked

            double[] features = encoder.Encode(categorical, numeric);

            Console.WriteLine("=== Before training on this example ===");
            Console.WriteLine($"Predicted CTR: {model.Predict(features):F4}");
            Console.WriteLine();

            // Perform several online updates with the same example (for demo purposes)
            for (int i = 0; i < 100; i++)
            {
                model.Update(features, label);
            }

            Console.WriteLine("=== After training on this example ===");
            Console.WriteLine($"Predicted CTR: {model.Predict(features):F4}");
        }
    }
}
