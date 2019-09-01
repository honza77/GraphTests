using System.Linq;
using GraphXSampleDbLib.Model;


namespace GraphXSampleDbLib
{
    public class GraphDbInfo
    {
        #region full DB graphs

        public static DbDataGraph GetDbModelGraph()
        {
            //return GetDbModelGraph("Server=localhost;DataBase=zoo;Integrated Security=SSPI");
            //return GetDbModelGraph("Server=localhost;DataBase=NORTHWND;Integrated Security=SSPI");
            return GetDbModelGraph("Server=localhost;DataBase=AdventureWorks2014;Integrated Security=SSPI");
        }

        public static DbDataGraph GetDbModelGraph(string connString)
        {
            using (var dbInfo = new DbInfo(connString))
            //using (var dbInfo = new DbInfoSimple(connString))
            {
                return GetDbModelGraph(dbInfo);
            }
        }

        private static DbDataGraph GetDbModelGraph(DbInfo dbInfo)
        {
            var dbGraph = new DbDataGraph();

            // add vertexes (tables)
            var tables = dbInfo.ListSchemaTableNames();
            dbGraph.AddVertexRange(tables.Select(t=> new DbDataVertex(tableOwner: t.Item1, tableName: t.Item2)));

            // add edges (FKs)
            var vertices = dbGraph.Vertices.ToDictionary(v => $"({v.TableOwner}, {v.TableName})", v => v);

            foreach (var vertice in dbGraph.Vertices)
            {
                var tableFkEdgess = dbInfo.ReadTableFks(vertice.TableOwner, vertice.TableName)
                                        .Select(fk => new DbDataEdge(vertices[fk.ToString()], vertice));
                dbGraph.AddEdgeRange(tableFkEdgess);
            }

            return dbGraph;
        }

        private static DbDataGraph GetDbModelGraph(DbInfoSimple dbInfo)
        {
            var dbGraph = new DbDataGraph();

            // add vertexes (tables)
            var tables = dbInfo.ListTableNames();
            dbGraph.AddVertexRange(tables.Select(t => new DbDataVertex(tableName: t)));

            // add edges (FKs)
            var vertices = dbGraph.Vertices.ToDictionary(v => v.TableName, v => v);

            foreach (var vertice in dbGraph.Vertices)
            {
                var tableFkEdgess = dbInfo.ReadTableFks(vertice.TableName)
                                        .Select(fk => new DbDataEdge(vertices[fk.ToString()], vertice));
                dbGraph.AddEdgeRange(tableFkEdgess);
            }

            return dbGraph;
        }

        #endregion
    }
}
