using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphXSampleDbLib;

namespace GraphXSampleDbLibTests
{
    [TestClass]
    public class DbInfoTests
    {
        private string _connString;

        [TestInitialize]
        public void Init()
        {
            _connString = "Server=localhost;DataBase=zoo;Integrated Security=SSPI";
        }

        [TestMethod]
        public void ListTableNamesTest()
        {
            using (var dbInfo = new DbInfo(_connString))
            {
                var tables = dbInfo.ListTableNames().ToList(); 
                Assert.IsTrue(tables.Any()); // !! enumerate inside using
            }
        }
    }
}
