using System;
using System.Diagnostics;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace DVLDdataAccessLayerSetting
{
    static class clsDVLDAccessSetting
    {
        public static string ConnectionString = "Server=.;Database=DVLDnewData;integrated security=true;";

        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }


        public static string SourceName = "DVLD";

        public static void LogError(string errormessege)
        {

            if (!EventLog.SourceExists(clsDVLDAccessSetting.SourceName))
            {
                EventLog.CreateEventSource(clsDVLDAccessSetting.SourceName, "Application");
            }
            EventLog.WriteEntry(clsDVLDAccessSetting.SourceName, errormessege, EventLogEntryType.Error);
        }

    }
}
