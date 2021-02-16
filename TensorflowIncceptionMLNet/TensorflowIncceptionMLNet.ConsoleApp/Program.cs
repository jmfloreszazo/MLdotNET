using System;
using System.IO;

namespace TensorflowIncceptionMLNet.ConsoleApp
{
    class Program
    {        
        static void Main(string[] args)
        {
            string _assetsPath = Path.Combine(Environment.CurrentDirectory, "TestImages");
            var imagePath = Path.Combine(_assetsPath, "Bay.jpg");

            var prediction = new ImageClassificationPredictor();
            prediction.Initialize();

            var result = prediction.Predict(imagePath);

            Console.WriteLine ($"Image ({imagePath}) is a picture of {result.PredictedLabelValue} with a confidence of {result.Score[1]:P2}");

        }
    }
}
