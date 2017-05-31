using System;
using System.Collections.Generic;
using System.Linq;
using QuickGraph;
using QuickGraph.Algorithms;

namespace GraphXSampleLib
{
    public class GraphSamplesFactory
    {

        public static BidirectionalGraph<int, IEdge<int>> SimpleExample1()
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();

            graph.AddVertex(1);
            graph.AddVertex(2);

            var edge1 = new Edge<int>(1, 2);
            graph.AddEdge(edge1);

            return graph;
        }

        public static BidirectionalGraph<int, IEdge<int>> SimpleExample2()
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();

            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(new Edge<int>(1, 2));
            graph.AddEdge(new Edge<int>(2, 3));
            graph.AddEdge(new Edge<int>(3, 1));

            graph.AddVerticesAndEdge(new Edge<int>(3, 4));

            return graph;
        }

        public static BidirectionalGraph<int, IEdge<int>> QuickGraphRandomGraph(int vertexCount=200, int edgeCount=400)
        {

            var graph = new BidirectionalGraph<int, IEdge<int>>();

            int currentVertexIndex=0;

            RandomGraphFactory.Create(
                g: graph,
                vertexFactory: () => currentVertexIndex++,
                edgeFactory: (v1, v2) => new Edge<int>(v1, v2),
                rnd: new Random(),
                vertexCount: vertexCount,
                edgeCount: edgeCount,
                selfEdges: false);

            return graph;
        }

        public static BidirectionalGraph<int, IEdge<int>> CircleGraph(int vertexCount = 20)
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();

            graph.AddVertex(1);

            for (int v = 2; v <= vertexCount; v++)
            {
                graph.AddVertex(v);
                graph.AddEdge(new Edge<int>(v - 1, v));
            }

            graph.AddEdge(new Edge<int>(vertexCount, 1));

            return graph;
        }

        public static BidirectionalGraph<int, IEdge<int>> FullGraph(int vertexCount = 10)
        {
            var graph = new BidirectionalGraph<int, IEdge<int>>();


            for (int v = 1; v <= vertexCount; v++)
            {
                graph.AddVertex(v);

                for (int v2 = 1; v2 < v; v2++)
                {
                    graph.AddEdge(new Edge<int>(v2, v));
                }
            }

            return graph;
        }

        public static BidirectionalGraph<string, IEdge<string>> TreeGraph(int levels = 3, int degree = 3)
        {
            var graph = new BidirectionalGraph<string, IEdge<string>>();


            var lastLevelVertexes = new List<string>() { "1" };
            var newLevelVertexes = new List<string>();

            graph.AddVertex("1");

            for (int level = 1; level <= levels; level++)
            {
                foreach (var vertex in lastLevelVertexes)
                {
                    for (int v2 = 1; v2 <= degree; v2++)
                    {
                        string vartexName = $"{vertex}-{v2}";
                        newLevelVertexes.Add(vartexName);
                        graph.AddVertex(vartexName);
                        graph.AddEdge(new Edge<string>(vertex, vartexName));
                    }
                }

                lastLevelVertexes = newLevelVertexes.ToList();
                newLevelVertexes.Clear();
            }

            return graph;
        }
    }
}
