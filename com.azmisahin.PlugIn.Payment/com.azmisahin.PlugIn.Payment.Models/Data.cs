using System;
namespace com.azmisahin.PlugIn.Payment.Models
{
    [Serializable()]
    public class Data
    {
        public Request Request { get; set; }
        public Response Response { get; set; }
    }
}
