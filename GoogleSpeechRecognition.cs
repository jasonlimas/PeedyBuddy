using System;
using System.IO;
using Google.Cloud.Speech.V1;
using NAudio.Wave;

public class GoogleSpeechRecognition
{
    private SpeechClient _speechClient;
    public event Action<string> SpeechRecognized;

    public GoogleSpeechRecognition()
    {
        // Create an instance of the SpeechClient using your Google Cloud credentials
        _speechClient = SpeechClient.Create();
    }

    public void StartListening()
    {
        // Start capturing audio from the microphone and perform speech recognition
        byte[] audioData = CaptureAudio();
        RecognizeSpeechAsync(audioData);
    }

    private byte[] CaptureAudio()
    {
        // Set up audio capture from the default microphone
        using (WaveInEvent waveIn = new WaveInEvent())
        {
            // Configure audio format
            waveIn.WaveFormat = new WaveFormat(16000, 16, 1); // 16 kHz sample rate, 16-bit PCM, mono

            // Create a MemoryStream to store captured audio
            using (MemoryStream outputStream = new MemoryStream())
            {
                // Event handler for when audio data is available
                waveIn.DataAvailable += (sender, e) =>
                {
                    // Write the captured audio data to the MemoryStream
                    outputStream.Write(e.Buffer, 0, e.BytesRecorded);
                };

                // Start audio capture
                waveIn.StartRecording();

                // Wait for a pause in speech or a specified maximum duration
                System.Threading.Thread.Sleep(5000); // Capture for 5 seconds (adjust as needed)

                // Stop audio capture
                waveIn.StopRecording();

                // Return the captured audio data as a byte array
                return outputStream.ToArray();
            }
        }
    }

    private async void RecognizeSpeechAsync(byte[] audioData)
    {
        // Perform speech recognition on the audio data
        RecognitionConfig config = new RecognitionConfig
        {
            Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
            SampleRateHertz = 16000,
            LanguageCode = "en-US",
        };
        RecognitionAudio audio = RecognitionAudio.FromBytes(audioData);

        // Perform asynchronous speech recognition
        RecognizeResponse response = await _speechClient.RecognizeAsync(config, audio);

        // Extract and raise the SpeechRecognized event with the recognized text
        if (response.Results.Count > 0)
        {
            string recognizedText = response.Results[0].Alternatives[0].Transcript;
            SpeechRecognized?.Invoke(recognizedText);
        }
        else
        {
            SpeechRecognized?.Invoke("No speech recognized.");
        }
    }
}