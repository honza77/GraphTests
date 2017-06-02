using System.Linq;
using GraphX.PCL.Common;
using GraphXSampleWpfApp.Models;
using QuickGraph;

namespace GraphXSampleWpfApp
{
    class Convertors
    {
        public static BidirectionalGraph<DataVertex, DataEdge> Convert(BidirectionalGraph<int, IEdge<int>> oldGraph)
        {
            var dataVertices = oldGraph.Vertices.ToDictionary(i => i, i => new DataVertex(i.ToString()));
            return oldGraph.Convert(vertexMapperFunc: i => dataVertices[i], edgeMapperFunc: e=>new DataEdge(dataVertices[e.Source], dataVertices[e.Target]));
        }

        public static BidirectionalGraph<DataVertex, DataEdge> Convert(BidirectionalGraph<string, IEdge<string>> oldGraph)
        {
            var dataVertices = oldGraph.Vertices.ToDictionary(i => i, i => new DataVertex(i.ToString()));
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
