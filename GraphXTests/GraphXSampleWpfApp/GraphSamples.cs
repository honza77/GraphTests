using GraphXSampleWpfApp.Models;

namespace GraphXSampleWpfApp
{
    static class GraphSamples
    {
        public static GraphExample FirstSimpleExample()
        {
            var graph = new GraphExample();

            // 1. add vertexes
            var v1 = new DataVertex(1);
            var v2 = new DataVertex(2);

            

            graph.AddVertex(v1);
            graph.AddVertex(v2);

            // 2. add edges
            var edge1 = new DataEdge(v1, v2);
            graph.AddEdge(edge1);

            return graph;
        }

        public static GraphExample Example2()
        {
            var graph = new GraphExample();

            // 1. add vertexes
            var vertices = new[]
            {
                new DataVertex(1),
                new DataVertex(2),
                new DataVertex(3),
                new DataVertex(4),
            };

            // 2. add edges
            graph.AddVertex( vertices[0] );
            graph.AddVertex( vertices[1] );
            graph.AddVertex( vertices[2] );

            graph.AddEdge(new DataEdge(vertices[0], vertices[1]) );
            graph.AddEdge(new DataEdge(vertices[1], vertices[2]) );
            graph.AddEdge(new DataEdge(vertices[2], vertices[0]) );

            graph.AddVerticesAndEdge(new DataEdge(vertices[2], vertices[3]) );

            return graph;
        }
    }
}
