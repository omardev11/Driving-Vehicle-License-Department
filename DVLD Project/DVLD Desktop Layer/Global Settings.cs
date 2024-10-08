using System.Security.Cryptography;
using System.Text;
using System;

namespace DVLDDesltopFrontLayer
{
    public  class Global_Settings
    {
        public static int UserID 
        { get
            {
                return Login_Screen._UserID;
            }
        }
 	public static int  NewLocalDrivingLicenseService { get { return 1; } }
	public static int RenewDrivingLicenseService { get { return 2; } }
	public static int ReplacementforaLostDrivingLicense { get { return 3; } }
	public static int ReplacementforaDamagedDrivingLicense { get { return 4; } }
	public static int ReleaseDetainedDrivingLicsense { get { return 5; } }
	public static int NewInternationalLicense { get { return 6; } }
	public static int RetakeTest { get { return 7; } }

        public static int DetainLicenseApplicationTypeID { get { return 8; } }

        public static string StoreFineFeesForDetainedLicenseTemparory = "";



        public static byte StatusNew { get { return 1; } }
        public static byte StatusCancelled { get { return 2; } }
        public static byte StatusCompeletted { get { return 3; } }

        public static byte IssueReasonForFirstTime { get { return 1; } }
        public static byte IssueReasonForRenew { get { return 2; } }
        public static byte IssueReaasonForDamaged { get { return 3; } }
        public static byte IssueReasonForLost { get { return 4; } }


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





    }
}
