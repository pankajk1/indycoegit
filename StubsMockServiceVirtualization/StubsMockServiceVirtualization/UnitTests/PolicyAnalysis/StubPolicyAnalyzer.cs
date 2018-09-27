using System;
using CSharpStubs;

namespace PolicyAnalyis
{
    internal class StubPolicyAnalyzer : IPolicyQuote
    {
        public int GetPolicyQuote(string vehicle)
        {
            var result = 0;
            if (vehicle.ToUpper().Equals("VEHICLE1"))
            {
                result = 500;
            }

            if (vehicle.ToUpper().Equals("VEHICLE2"))
            {
                result = 300;
            }

            return result;
        }

        public string GetQuoteUsingSV(string Id)
        {
            throw new NotImplementedException();
        }
    }
}