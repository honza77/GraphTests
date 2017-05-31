using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphXSampleWpfApp.Models;
using QuickGraph;

namespace GraphXSampleWpfApp
{
    static class GraphSamples
    {
        public static GraphExample FirstSimpleExample()
        {
            var graph = new GraphExample();

            DataVertex v1 = new DataVertex(1);
            DataVertex v2 = new DataVertex(2);

            graph.AddVertex(v1);
            graph.AddVertex(v2);

            var edge1 = new DataEdge(v1, v2);
            graph.AddEdge(edge1);

            return graph;
        }

        public static GraphExample Example2()
        {
            var graph = new GraphExample();

            var Vs = new[]
            {
                new DataVertex(1),
                new DataVertex(2),
                new DataVertex(3),
                new DataVertex(4),
            };

            graph.AddVertex( Vs[0] );
            graph.AddVertex( Vs[1] );
            graph.AddVertex( Vs[2] );

            graph.AddEdge(new DataEdge(Vs[0], Vs[1]) );
            graph.AddEdge(new DataEdge(Vs[1], Vs[2]) );
            graph.AddEdge(new DataEdge(Vs[2], Vs[0]) );

            graph.AddVerticesAndEdge(new DataEdge(Vs[2], Vs[3]) );

            return graph;
        }
    }
}
