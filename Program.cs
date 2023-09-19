namespace Sentiment_analysis_console_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) {
            Console.Clear();

            var sampleData = new SentimentAnalysis.ModelInput();

            //prompt user
            Console.WriteLine("Please write a comment for sentiment analysis");
            string userInput = Console.ReadLine();
            userInput = userInput == null ? "no value entered" : userInput;
            Console.Clear();
            
            //save user input to model input
            sampleData.Comment_text = userInput;

            //Load model and predict output
            var result = SentimentAnalysis.Predict(sampleData);

            // Find the class with the highest probability (predicted class)
            int index = Array.IndexOf(result.Score, result.Score.Max());

            // Get the confidence score for the predicted class
            float confidenceScore = result.Score[index];

            // format message
            string msg = $"Your statement was: {userInput}\n" +
                $"This statement was identified as: {(result.PredictedLabel == 0 ? "Not toxic" : "Toxic")}\n" +
                $"The model is {Math.Round(confidenceScore * 100,0)} percent sure about this prediction";
            
            Console.WriteLine(msg);
                Console.ReadKey();
            }

        }
    }
}