namespace PeedyBuddy
{
    partial class FormDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonShow = new System.Windows.Forms.Button();
            this.ButtonHide = new System.Windows.Forms.Button();
            this.TextSpeak = new System.Windows.Forms.TextBox();
            this.ButtonSpeak = new System.Windows.Forms.Button();
            this.ButtonTestSpeech = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonShow
            // 
            this.ButtonShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonShow.Location = new System.Drawing.Point(12, 12);
            this.ButtonShow.Name = "ButtonShow";
            this.ButtonShow.Size = new System.Drawing.Size(129, 61);
            this.ButtonShow.TabIndex = 0;
            this.ButtonShow.Text = "Show";
            this.ButtonShow.UseVisualStyleBackColor = true;
            this.ButtonShow.Click += new System.EventHandler(this.ButtonShow_Click);
            // 
            // ButtonHide
            // 
            this.ButtonHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonHide.Location = new System.Drawing.Point(146, 12);
            this.ButtonHide.Name = "ButtonHide";
            this.ButtonHide.Size = new System.Drawing.Size(129, 61);
            this.ButtonHide.TabIndex = 1;
            this.ButtonHide.Text = "Hide";
            this.ButtonHide.UseVisualStyleBackColor = true;
            this.ButtonHide.Click += new System.EventHandler(this.ButtonHide_Click);
            // 
            // TextSpeak
            // 
            this.TextSpeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextSpeak.Location = new System.Drawing.Point(12, 79);
            this.TextSpeak.Name = "TextSpeak";
            this.TextSpeak.Size = new System.Drawing.Size(263, 22);
            this.TextSpeak.TabIndex = 2;
            this.TextSpeak.Text = "Hello there!";
            // 
            // ButtonSpeak
            // 
            this.ButtonSpeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSpeak.Location = new System.Drawing.Point(12, 107);
            this.ButtonSpeak.Name = "ButtonSpeak";
            this.ButtonSpeak.Size = new System.Drawing.Size(263, 44);
            this.ButtonSpeak.TabIndex = 3;
            this.ButtonSpeak.Text = "Speak";
            this.ButtonSpeak.UseVisualStyleBackColor = true;
            this.ButtonSpeak.Click += new System.EventHandler(this.ButtonSpeak_Click);
            // 
            // ButtonTestSpeech
            // 
            this.ButtonTestSpeech.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTestSpeech.Location = new System.Drawing.Point(12, 157);
            this.ButtonTestSpeech.Name = "ButtonTestSpeech";
            this.ButtonTestSpeech.Size = new System.Drawing.Size(263, 81);
            this.ButtonTestSpeech.TabIndex = 4;
            this.ButtonTestSpeech.Text = "Test Speech Recognition";
            this.ButtonTestSpeech.UseVisualStyleBackColor = true;
            this.ButtonTestSpeech.Click += new System.EventHandler(this.ButtonTestSpeech_Click);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 250);
            this.Controls.Add(this.ButtonTestSpeech);
            this.Controls.Add(this.ButtonSpeak);
            this.Controls.Add(this.TextSpeak);
            this.Controls.Add(this.ButtonHide);
            this.Controls.Add(this.ButtonShow);
            this.Name = "FormDashboard";
            this.Text = "Peedy Control Board";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonShow;
        private System.Windows.Forms.Button ButtonHide;
        private System.Windows.Forms.TextBox TextSpeak;
        private System.Windows.Forms.Button ButtonSpeak;
        private System.Windows.Forms.Button ButtonTestSpeech;
    }
}

