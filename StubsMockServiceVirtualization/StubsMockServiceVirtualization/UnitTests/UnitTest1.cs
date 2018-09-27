using CSharpStubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakes.Contrib;
using Moq;
using Mock4Net.Core;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private FluentMockServer _server;

#region Private Methods

        [TestInitialize]
        public void Initialize()
        {
            _server = FluentMockServer.Start(8004);

            _server
                .Given(
                    Requests
                        .WithUrl("/GetPolicyQuote/1")
                        .UsingGet())
                .RespondWith(
                    Responses
                        .WithStatusCode(200)
                        .WithBody(@"{ Id: ""Vehicle1"", Quote: ""500""}")
                    );
            _server
               .Given(
                   Requests
                       .WithUrl("/GetPolicyQuote/2")
                       .UsingGet())
               .RespondWith(
                   Responses
                       .WithStatusCode(200)
                       .WithBody(@"{ Id: ""Vehicle2"", Quote: ""300""}")
                   );
        }

        private IPolicyQuote GetMockForPolicyQuote()
        {
            Mock<IPolicyQuote> mockObject = new Mock<IPolicyQuote>();
            mockObject.Setup(m => m.GetPolicyQuote("Vehicle1")).Returns(500);
            mockObject.Setup(m => m.GetPolicyQuote("Vehicle2")).Returns(300);
            return mockObject.Object;
        }

        #endregion
        
        [TestMethod]
        public void TestUsingStub()
        {
            // Arrange:

            // Create the stockFeed stub
            IPolicyQuote stubObj = new PolicyAnalyis.StubPolicyAnalyzer();

            // In the completed application, stockFeed would be a real one:
            // Now, we are using the stubbed class
            var componentUnderTest = new PolicyAnalyzer(stubObj);

            // Act:
            int company1Value = componentUnderTest.GetPolicyQuote("Vehicle1");
            int company2Value = componentUnderTest.GetPolicyQuote("Vehicle2");

            // Assert:
            Assert.AreEqual(500, company1Value);
            Assert.AreEqual(300, company2Value);  
        }

        [TestMethod]
        public void TestUsingMock()
        {
            //Mockinf
            IPolicyQuote mockObj = GetMockForPolicyQuote();

            var componentUnderTest = new PolicyAnalyzer(mockObj);

            // Act:
            int company1Value = componentUnderTest.GetPolicyQuote("Vehicle1");
            int company2Value = componentUnderTest.GetPolicyQuote("Vehicle2");

            // Assert:
            Assert.AreEqual(500, company1Value);
            Assert.AreEqual(300, company2Value);       
        }

        [TestMethod]
        public void TestUsingServiceVirualization()
        {
            IPolicyQuote policyQuote = new PolicyQuote();
            var Firsttest = policyQuote.GetQuoteUsingSV ("1");
            var secondtest = policyQuote.GetQuoteUsingSV("2");

            Assert.AreEqual("500", Firsttest);
            Assert.AreEqual("300", secondtest);
        }
    }
}
