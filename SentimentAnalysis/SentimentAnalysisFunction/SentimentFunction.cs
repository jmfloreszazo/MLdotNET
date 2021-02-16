using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BookApp.SentimentAnalysisFunction
{
    public class SentimentFunction
    {
        private readonly ISentimentAnaysisService _sentimentAnaysisService;
        public SentimentFunction(ISentimentAnaysisService sentimentAnaysisService)
        {
            _sentimentAnaysisService = sentimentAnaysisService;
        }

        [FunctionName("GetSentiment")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var result = _sentimentAnaysisService.GetSentiment(requestBody);
            return new OkObjectResult(result);
        }
    }
}
