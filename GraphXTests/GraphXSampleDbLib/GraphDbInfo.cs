using System;
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
            // TODO
            DbDataGraph graph = new DbDataGraph();

            graph.AddVerticesAndEdge(new DbDataEdge(source: new DbDataVertex("v1"), target: new DbDataVertex("v2") ));

            return graph;
        }

        #endregion
    }
}
