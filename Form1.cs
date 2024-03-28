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
        // Static field to store a reference to the current instance of FormDashboard
        private static FormDashboard currentInstance;

        DoubleAgent.AxControl.AxControl newAgent;
        SpeechRecognitionEngine speechRecognizer;

        public FormDashboard()
        {
            InitializeComponent();

            // Set the currentInstance to this instance of FormDashboard
            currentInstance = this;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            newAgent = new DoubleAgent.AxControl.AxControl();
            newAgent.CreateControl();
            newAgent.Characters.Load(StaticInfo.charName, StaticInfo.charFileLocation);
            loadSpeechRecognition();
            newAgent.Characters[charName].Show();
        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            newAgent.Characters[StaticInfo.charName].Show();
        }

        private void ButtonHide_Click(object sender, EventArgs e)
        {
            newAgent.Characters[StaticInfo.charName].Hide();
        }

        private void ButtonSpeak_Click(object sender, EventArgs e)
        {
            newAgent.Characters[StaticInfo.charName].Speak(TextSpeak.Text);
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
        static void speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Access the newAgent field through the currentInstance
            DoubleAgent.AxControl.AxControl newAgent = currentInstance.newAgent;

            switch (e.Result.Text)
            {
                case "hey " + StaticInfo.charName:
                case "hi " + StaticInfo.charName:
                case "hello " + StaticInfo.charName:
                    newAgent.Characters[StaticInfo.charName].Speak("Well hello there! I hope you're doing fine today.");
                    break;
                case StaticInfo.charName + " open notepad":
                    newAgent.Characters[StaticInfo.charName].Play("Acknowledge");
                    newAgent.Characters[StaticInfo.charName].Speak("Okay.");
                    Process.Start("notepad.exe", "");
                    break;
                case StaticInfo.charName + " open youtube":
                    newAgent.Characters[StaticInfo.charName].Play("Acknowledge");
                    newAgent.Characters[StaticInfo.charName].Speak("Okay.");
                    Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://youtube.com");
                    break;
                case StaticInfo.charName + " what time":
                    // Get current time
                    DateTime currentTime = DateTime.Now;
                    // Speak current time
                    newAgent.Characters[StaticInfo.charName].Speak("The time is " + currentTime.ToString("h:mm tt") + ". Have a nice day!");
                    break;
                default:
                    newAgent.Characters[StaticInfo.charName].Speak("I'm sorry. I don't understand that yet.");
                    break;
            }
        }

    }
}
