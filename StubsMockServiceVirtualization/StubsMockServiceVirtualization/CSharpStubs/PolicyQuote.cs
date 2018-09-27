using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharpStubs
{
    public class PolicyQuote : IPolicyQuote
    {
        public int GetPolicyQuote(string vehicle)
        {
            //some logic to get values from DB.etc
            throw new NotImplementedException();
        }

        //Service Virtualization
        public string virtualizationUrl = "http://localhost:8004/GetPolicyQuote/";

        public string GetQuoteUsingSV(string Id)
        {
            string rootUrl = virtualizationUrl;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(rootUrl + Id);
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();

            PolicyQuoteModel deserialized;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var jsonReader = reader.ReadToEnd();
                deserialized = JsonConvert.DeserializeObject<PolicyQuoteModel>(jsonReader);
            }

            return deserialized.Quote;
        }
    }
}
