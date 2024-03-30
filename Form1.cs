using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public FormDashboard()
        {
            InitializeComponent();
            InitializeAgent();
        }

        private void InitializeAgent()
        {
            newAgent = new DoubleAgent.AxControl.AxControl();
            newAgent.CreateControl();
            newAgent.Characters.Load(StaticInfo.charName, StaticInfo.charFileLocation);
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

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // InitializeAgent(); ?
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

        // For building grammar
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

            // Open things
            choice.Add(new string[]
            {
                StaticInfo.charName + " open youtube",
                StaticInfo.charName + " open notepad",
                StaticInfo.charName + " what time"
            });

            return choice;
        }
    
        // Handle the SpeechRecognized event.
        private void HandleSpeechRecognitionResult(SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "hey " + StaticInfo.charName:
                case "hi " + StaticInfo.charName:
                case "hello " + StaticInfo.charName:
                    SpeakWithAgent("Well hello there! I hope you're doing fine today.");
                    break;
                case StaticInfo.charName + " open notepad":
                    SpeakWithAgent("Okay.");
                    Process.Start("notepad.exe", "");
                    break;
                case StaticInfo.charName + " open youtube":
                    SpeakWithAgent("Okay.");
                    Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://youtube.com");
                    break;
                case StaticInfo.charName + " what time":
                    SpeakCurrentTime();
                    break;
                default:
                    SpeakWithAgent("I'm sorry. I don't understand that yet.");
                    break;
            }
        }

        private void speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            HandleSpeechRecognitionResult(e);
        }

    }
}
