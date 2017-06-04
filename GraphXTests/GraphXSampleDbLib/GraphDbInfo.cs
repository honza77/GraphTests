using System.Linq;
using GraphXSampleDbLib.Model;


namespace GraphXSampleDbLib
{
    public class GraphDbInfo
    {
        #region full DB graphs

        public static DbDataGraph GetZooDbModelGraph()
        {
            return GetDbModelGraph("Server=localhost;DataBase=zoo;Integrated Security=SSPI");
        }

        public static DbDataGraph GetDbModelGraph(string connString)
        {
            using (var dbInfo = new DbInfo(connString))
            {
                return GetDbModelGraph(dbInfo);
            }
        }

        private static DbDataGraph GetDbModelGraph(DbInfo dbInfo)
        {
            var dbGraph = new DbDataGraph();

            // add vertexes (tables)
            var tableNames = dbInfo.ListTableNames();
            dbGraph.AddVertexRange(tableNames.Select(s=> new DbDataVertex(s)));

            // add edges (FKs)
            var vertices = dbGraph.Vertices.ToDictionary(v => v.ToString(), v => v);

            foreach (var vertice in dbGraph.Vertices)
            {
                var tableFKs = dbInfo.ReadTableFks(vertice.TableName);
                dbGraph.AddEdgeRange(tableFKs.Select(fk => new DbDataEdge(vertice, vertices[fk])));
            }

            return dbGraph;
        }

        #endregion
    }
}
