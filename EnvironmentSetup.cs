using System;

namespace PeedyBuddy
{
    public static class EnvironmentSetup
    {
        public static string GetGoogleCredentialsEnvironmentVariable()
        {
            return Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
        }
    }
}
