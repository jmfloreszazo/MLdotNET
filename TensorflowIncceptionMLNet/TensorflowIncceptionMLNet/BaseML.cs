using Microsoft.ML;

namespace TensorflowIncceptionMLNet
{
    public class BaseML
    {
        protected MLContext MlContext;

        public BaseML()
        {
            MlContext = new MLContext(2021);
        }
    }
}