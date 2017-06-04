using System.Linq;
using QuickGraph;
using GraphX.PCL.Common;
using GraphXSampleDbLib.Model;
using GraphXSampleWpfApp.Models;

namespace GraphXSampleWpfApp
{
    class Convertors
    {
        public static BidirectionalGraph<DataVertex, DataEdge> Convert(DbDataGraph oldGraph)
        {
            var dataVertices = oldGraph.Vertices.ToDictionary(v => v, v => new DataVertex(v.ToString()));
            return oldGraph.Convert(vertexMapperFunc: i => dataVertices[i], edgeMapperFunc: e => new DataEdge(dataVertices[e.Source], dataVertices[e.Target]));
        }

        public static BidirectionalGraph<DataVertex, DataEdge> Convert<TVertex>(BidirectionalGraph<TVertex, IEdge<TVertex>> oldGraph)
        {
            var dataVertices = oldGraph.Vertices.ToDictionary(v => v, v => new DataVertex(v.ToString()));
            return oldGraph.Convert(vertexMapperFunc: i => dataVertices[i], edgeMapperFunc: e => new DataEdge(dataVertices[e.Source], dataVertices[e.Target]));
        }

        public static GraphExample ToGraphExample(BidirectionalGraph<DataVertex, DataEdge> oldGraph)
        {
            var graph = new GraphExample();

            graph.AddVertexRange(oldGraph.Vertices);
            graph.AddEdgeRange(oldGraph.Edges);

            return graph;
        }
    }
}
