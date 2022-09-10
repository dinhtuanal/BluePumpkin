namespace App.Helpers
{
    public static class Helper
    {
        public static string convertJoinEventStatus(string statusNumber)
        {

            if (statusNumber.Equals("0"))
            {
                return "InActive";
            }

            if (statusNumber.Equals("1"))
            {
                return "Failed";
            }

            if (statusNumber.Equals("2"))
            {
                return "Peding";
            }

            if (statusNumber.Equals("3"))
            {
                return "Accepted";
            }

            if (statusNumber.Equals("4"))
            {
                return "Won";
            }

            return null;
        }

        public static string convertEventStatus(string statusNumber)
        {

            if (statusNumber.Equals("0"))
            {
                return "InActive";
            }

            if (statusNumber.Equals("1"))
            {
                return "Finished";
            }

            if (statusNumber.Equals("2"))
            {
                return "Happening";
            }

            if (statusNumber.Equals("3"))
            {
                return "Upcomming";
            }

            return null;
        }
    }
}
