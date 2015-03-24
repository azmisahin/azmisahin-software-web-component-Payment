namespace com.azmisahin.PlugIn.Payment
{
    class Extensions
    {
        public static string GetUserIP
        {
            get { return System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(1).ToString(); }
        }
    }
}