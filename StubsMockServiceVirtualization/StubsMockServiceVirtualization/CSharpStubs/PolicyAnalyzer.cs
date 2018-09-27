using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStubs
{
    public class PolicyAnalyzer
    {
        private IPolicyQuote policyQuote;
        public PolicyAnalyzer(IPolicyQuote feed)
        {
            policyQuote = feed;
        }

        public int GetPolicyQuote(string vehicle)
        {
            return policyQuote.GetPolicyQuote(vehicle);
        }
    }

}
