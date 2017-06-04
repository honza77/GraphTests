using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphXSampleDbLib;

namespace GraphXSampleDbLibTests
{
    [TestClass]
    public class DbInfoTests
    {
        private string _connString;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

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
                var tables = dbInfo.ListTableNames();

                // !!enumerate before dbInfo Dispose (inside using):

                var any = false;
                foreach (var table in tables)
                {
                    any = true;
                    TestContext.WriteLine($"{table}");
                }

                Assert.IsTrue(any);
            }
        }

        [TestMethod]
        public void ListTableFksTest()
        {
            using (var dbInfo = new DbInfo(_connString))
            {
                var usersTableFks = dbInfo.ReadTableFKs("Users"); 

                var any = false;
                foreach (var fk in usersTableFks)
                {
                    any = true;
                    TestContext.WriteLine($"{fk}");
                }

                Assert.IsTrue(any);
            }
        }

        [TestMethod]
        public void ReadAllFKs()
        {
            using (var dbInfo = new DbInfo(_connString))
            {
                var tables = dbInfo.ListTableNames().ToList();

                var any = false;
                foreach (var fk in dbInfo.ReadAllFKs())
                {
                    any = true;
                    Assert.IsNotNull(tables.FirstOrDefault(t => t == fk.Item1));
                    Assert.IsNotNull(tables.FirstOrDefault(t => t == fk.Item2));
                    TestContext.WriteLine($"{fk}");
                }

                Assert.IsTrue(any);
            }
        }

        [TestMethod]
        public void ReadAlltablesFKs()
        {
            using (var dbInfo = new DbInfo(_connString))
            {
                foreach (var table in dbInfo.ListTableNames())
                {
                    TestContext.WriteLine($"{table}");
                    
                    foreach (var fk in dbInfo.ReadTableFKs(table))
                    {
                        TestContext.WriteLine($"\t - {fk}");
                    }
                }
            }
        }
    }
}
