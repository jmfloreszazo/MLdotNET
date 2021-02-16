
using Microsoft.ML.Data;

namespace TensorflowIncceptionMLNet.Model
{
    public class ImageDataInputItem
    {
        [LoadColumn(0)]
        public string ImagePath;

        [LoadColumn(1)]
        public string Label;
    }
}