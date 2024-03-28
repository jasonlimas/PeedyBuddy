using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeedyBuddy
{
    public partial class FormDashboard : Form
    {
        DoubleAgent.AxControl.AxControl newAgent;

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            newAgent = new DoubleAgent.AxControl.AxControl();
            newAgent.CreateControl();
            newAgent.Characters.Load("Peedy", "E:\\Others\\Peedy.acs");
        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            newAgent.Characters["Peedy"].Show();
        }

        private void ButtonHide_Click(object sender, EventArgs e)
        {
            newAgent.Characters["Peedy"].Hide();
        }

        private void ButtonSpeak_Click(object sender, EventArgs e)
        {
            newAgent.Characters["Peedy"].Speak(TextSpeak.Text);
        }
    }
}
