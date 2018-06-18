using ConsoleApp1;
using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private readonly Network _network;
        private readonly Data _data;

        public UnitTest1()
        {
            _network = new Network();
            _data = new Data(_network);
        }

        [TestMethod]
        public void TestCreate()
        {
            RequestJSON createrequestJSON = new RequestJSON
            {
                user = "MAC, Inc"
            };

            string actualres = _data.CreateUpdateAsync(createrequestJSON).Result;
            Assert.IsTrue(actualres.Contains("Guid sucessfully created"));
        }

        [TestMethod]
        public void TestRead()
        {
            string actualres = _data.ReadAsync("4C47514B4357535642485644544E5945").Result;
            string expectedres = "Guid sucessfully created 4C47514B4357535642485644544E5945 and expires in 1427822745";
            Assert.AreEqual(actualres, expectedres);

        }

        [TestMethod]
        public void TestUpdate()
        {
            RequestJSON updaterequestJSON = new RequestJSON
            {
                expire = "1427822745",
                user = "Cylance, Inc"
            };

            string actualres = _data.CreateUpdateAsync(updaterequestJSON, "4C47514B4357535642485644544E5945").Result;
            Assert.IsTrue(actualres.Contains("Guid sucessfully created"));

        }

        [TestMethod]
        public async Task TestDelete()
        {
            await _data.DeleteAsync("4C47514B4357535642485644544E5945");
        }
    }
}
