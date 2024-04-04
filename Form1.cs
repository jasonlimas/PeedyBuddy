using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Diagnostics;
using static PeedyBuddy.StaticInfo;

namespace PeedyBuddy
{
    public partial class FormDashboard : Form
    {
        DoubleAgent.AxControl.AxControl newAgent;
        SpeechRecognitionEngine speechRecognizer;

        // New
        private GoogleSpeechRecognition _speechRecognition;

        public FormDashboard()
        {
            InitializeComponent();
            InitializeAgent();

            // New
            _speechRecognition = new GoogleSpeechRecognition();
            _speechRecognition.SpeechRecognized += DisplayRecognizedSpeech;
        }

        // New, temporary i think
        private void DisplayRecognizedSpeech(string text)
        {
            // Display the recognized text in a MessageBox
            MessageBox.Show(text, "Speech Recognized");
        }

        // New, temporary
        private void ButtonTestSpeech_Click(object sender, EventArgs e)
        {
            // Start listening for speech when the Listen button is clicked
            _speechRecognition.StartListening();
        }


        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // InitializeAgent(); ?
        }

        private void InitializeAgent()
        {
            newAgent = new DoubleAgent.AxControl.AxControl();
            newAgent.CreateControl();
            newAgent.Characters.Load(StaticInfo.charName, StaticInfo.charPath);
            loadSpeechRecognition();
            newAgent.Characters[charName].Show();
        }

        // The next 3 functions below are simply for telling the agent to show itself and speak from the input parameter
        private void ShowAgent()
        {
            newAgent.Characters[StaticInfo.charName].Show();
        }

        private void HideAgent()
        {
            newAgent.Characters[StaticInfo.charName].Hide();
        }

        private void SpeakWithAgent(string text)
        {
            newAgent.Characters[StaticInfo.charName].Speak(text);
        }

        private void SpeakCurrentTime()
        {
            // Get current time
            DateTime currentTime = DateTime.Now;
            // Speak current time
            SpeakWithAgent("The time is " + currentTime.ToString("h:mm tt") + ". Have a nice day!");
        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            ShowAgent();
        }

        private void ButtonHide_Click(object sender, EventArgs e)
        {
            HideAgent();
        }

        private void ButtonSpeak_Click(object sender, EventArgs e)
        {
            SpeakWithAgent(TextSpeak.Text);
        }

        // (System.Speech.Recognition speech recog)
        private void loadSpeechRecognition()
        {
            // Initialize speech recognizer with en-US language/locale
            speechRecognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

            // Create grammar
            GrammarBuilder grammarBuilder = new GrammarBuilder(getChoiceLibrary());
            Grammar grammar = new Grammar(grammarBuilder);
            speechRecognizer.LoadGrammar(grammar);

            // Add a handler for the speech recognition event
            speechRecognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speechRecognizer_SpeechRecognized);

            // Configure the input to the speech recognizer.
            speechRecognizer.SetInputToDefaultAudioDevice();

            // Start asynchronous, continuous speech recognition.
            speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        // For building grammar (System.Speech.Recognition speech recog)
        private Choices getChoiceLibrary()
        {
            Choices choice = new Choices();

            // Greetings
            choice.Add(new string[]
            {
                "hey " + StaticInfo.charName,
                "hi " + StaticInfo.charName,
                "hello " + StaticInfo.charName
            });

            return choice;
        }

        // Handle the SpeechRecognized event. (System.Speech.Recognition speech recog)
        private void HandleSpeechRecognitionResult(SpeechRecognizedEventArgs e)
        {
            HandleSpeechRecognitionResult(e, newAgent);
        }

        private void HandleSpeechRecognitionResult(SpeechRecognizedEventArgs e, DoubleAgent.AxControl.AxControl agent)
        {
            // When Peedy is called, Google SST will start listening
            if (e.Result.Text == "hey " + StaticInfo.charName ||
                e.Result.Text == "hi " + StaticInfo.charName ||
                e.Result.Text == "hello " + StaticInfo.charName)
            {
                    // Start listening (using Google's Speech to Text) when Peedy is called
                    _speechRecognition.StartListening();
            }
        }

        private void speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            HandleSpeechRecognitionResult(e);
        }
    }
}
