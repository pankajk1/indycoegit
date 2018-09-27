using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStubs
{
    public interface IPolicyQuote
    {
        int GetPolicyQuote(string vehicle);
        string GetQuoteUsingSV(string Id);
    }
}
