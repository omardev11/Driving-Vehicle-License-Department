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






    }
}
