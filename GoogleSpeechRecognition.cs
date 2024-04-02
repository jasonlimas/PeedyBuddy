using Google.Cloud.Speech.V1;
using System.Threading.Tasks;

namespace PeedyBuddy
{
    public static class GoogleSpeechRecognition
    {
        public static async Task<string> RecognizeSpeechAsync(byte[] audioData)
        {
            // Create a SpeechClient using the JSON key file credentials
            SpeechClientBuilder builder = new SpeechClientBuilder();
            SpeechClient speechClient = await builder.BuildAsync();

            // Perform speech recognition on the audio data
            RecognitionConfig config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = "en-US",
            };
            RecognitionAudio audio = RecognitionAudio.FromBytes(audioData);

            // Perform asynchronous speech recognition
            RecognizeResponse response = await speechClient.RecognizeAsync(config, audio);

            // Extract and return the recognized text
            if (response.Results.Count > 0)
            {
                return response.Results[0].Alternatives[0].Transcript;
            }
            else
            {
                return "No speech recognized.";
            }
        }
    }
}
