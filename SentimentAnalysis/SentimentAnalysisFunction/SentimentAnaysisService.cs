using Microsoft.Extensions.ML;
using SentimentAnalysis.Models;

namespace BookApp.SentimentAnalysisFunction
{
    public class SentimentAnaysisService : ISentimentAnaysisService
    {
        private readonly PredictionEnginePool<SentimentInput, SentimentOutput> predictionEnginePool;

        public SentimentAnaysisService(PredictionEnginePool<SentimentInput, SentimentOutput> predictionEnginePool)
        {
            this.predictionEnginePool = predictionEnginePool;
        }

        public Sentiment GetSentiment(string text)
        {
            var input = new SentimentInput
            {
                Text = text
            };

            var prediction = predictionEnginePool.Predict(modelName: "SentimentAnalysisModel", example: input);

            var confidence = prediction.Prediction == "0" ? prediction.Score[0] : prediction.Score[1];
            if (confidence < 0.95)
                return Sentiment.Neutral;

            return (prediction.Prediction=="1") ? Sentiment.Positive : Sentiment.Negative;

        }
    }
}