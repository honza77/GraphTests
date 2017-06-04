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
            //_connString = "Server=localhost;DataBase=zoo;Integrated Security=SSPI";
            _connString = "Server=localhost;DataBase=AdventureWorks2014;Integrated Security=SSPI";
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
        public void ListSchemaTableNamesTest()
        {
            using (var dbInfo = new DbInfo(_connString))
            {
                var tables = dbInfo.ListSchemaTableNames();

                // !!enumerate before dbInfo Dispose (inside using):

                var any = false;
                foreach (var table in tables)
                {
                    any = true;
                    TestContext.WriteLine($"{table.Item1}.{table.Item2}");
                }

                Assert.IsTrue(any);
            }
        }

        //[TestMethod]
        //public void ListTableFksTest()
        //{
        //    using (var dbInfo = new DbInfo(_connString))
        //    {
        //        var usersTableFks = dbInfo.ReadTableFks("Users"); 

        //        var any = false;
        //        foreach (var fk in usersTableFks)
        //        {
        //            any = true;
        //            TestContext.WriteLine($"{fk}");
        //        }

        //        Assert.IsTrue(any);
        //    }
        //}

        [TestMethod]
        public void ReadAllFks()
        {
            using (var dbInfo = new DbInfo(_connString))
            {
                var tables = dbInfo.ListSchemaTableNames().Select(st => $"{st.Item1}.{st.Item2}").ToList();
                //var tables = dbInfo.ListTableNames().ToDictionary();

                var any = false;
                foreach (var fk in dbInfo.ReadAllFKs())
                {
                    any = true;
                    Assert.IsTrue(tables.Any(t => t == fk.Item1));
                    Assert.IsTrue(tables.Any(t => t == fk.Item2));
                    TestContext.WriteLine($"{fk}");
                }

                Assert.IsTrue(any);
            }
        }

        [TestMethod]
        public void ReadAllTablesFks()
        {
            var any = false;
            using (var dbInfo = new DbInfo(_connString))
            {
                foreach (var table in dbInfo.ListSchemaTableNames().ToList())
                {
                    TestContext.WriteLine($"{table}");
                    
                    foreach (var fk in dbInfo.ReadTableFks(schema: table.Item1, tableName: table.Item2))
                    {
                        any = true;
                        TestContext.WriteLine($"\t - {fk}");
                    }
                }
            }
            Assert.IsTrue(any);
        }
    }
}
