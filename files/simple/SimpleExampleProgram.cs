// files/simple/SimpleExampleProgram.cs
using System;

namespace HashedFeatureSimple
{
    /// <summary>
    /// Demo program: hashes a city name into a fixed-size vector.
    /// </summary>
    internal class SimpleExampleProgram
    {
        public static void Run(string[] args)
        {
            int numBuckets = 8;
            string city = "Toronto";

            IFeatureEncoder encoder = new SimpleHashedFeatureEncoder();
            double[] vector = encoder.Encode(city, numBuckets);

            Console.WriteLine($"Hashed feature vector for city = {city}");
            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine($"Bucket {i}: {vector[i]}");
            }

            Console.WriteLine();
            Console.WriteLine("Try another city (or press Enter to exit):");

            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                double[] vector2 = encoder.Encode(input.Trim(), numBuckets);
                Console.WriteLine($"Hashed feature vector for city = {input.Trim()}");
                for (int i = 0; i < vector2.Length; i++)
                {
                    Console.WriteLine($"Bucket {i}: {vector2[i]}");
                }
            }
        }
    }
}
