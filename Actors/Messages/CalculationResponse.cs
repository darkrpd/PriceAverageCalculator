namespace Actors.Messages
{
    public class CalculationResponse
    {
        private readonly string _jsonString;

        public CalculationResponse(string jsonString)
        {
            _jsonString = jsonString;
        }

        public string JsonString
        {
            get { return _jsonString; }
        }

    }
}