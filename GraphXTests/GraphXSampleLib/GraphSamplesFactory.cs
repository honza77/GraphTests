using QuickGraph;

namespace GraphXSampleLib
{
    class GraphSamplesFactory
    {

        public BidirectionalGraph<int, IEdge<int>> FirstSimpleExample()
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();

            graph.AddVertex(1);
            graph.AddVertex(2);

            var edge1 = new Edge<int>(1, 2);

            graph.AddEdge(edge1);

            return graph;
        }
    }
}
