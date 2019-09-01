using System;
using System.Collections.Generic;
using System.Linq;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Search;

namespace GraphXSampleLib
{
    public class GraphAlgorithms
    {
        public static IEnumerable<TEdge> FindShortestPath<TVertex, TEdge>(
                                            IVertexAndEdgeListGraph<TVertex, TEdge> graph, 
                                            TVertex startVertex, 
                                            TVertex endVertex)
                                        where TEdge : class, IEdge<TVertex>
        {
            Func<TEdge, double> edgeCost = e => 1;

            // extension build arround algorithm 'command pattern': 
            var tryGetPaths = graph.ShortestPathsDijkstra(edgeWeights: edgeCost, source: startVertex);

            // query path for given vertices
            IEnumerable<TEdge> edgePath;
            if (!tryGetPaths(endVertex, out edgePath))
            {
                return Enumerable.Empty<TEdge>();
            }

            return edgePath;
        }

        public static IEnumerable<TEdge> FindShortestPath<TVertex, TEdge>(
                                            IUndirectedGraph<TVertex, TEdge> graph, 
                                            TVertex startVertex, 
                                            TVertex endVertex)
                                        where TEdge : class, IEdge<TVertex>
        {
            Func<TEdge, double> edgeCost = e => 1; // constant cost

            var tryGetPaths = graph.ShortestPathsDijkstra(edgeWeights: edgeCost, source: startVertex);

            IEnumerable<TEdge> edgePath;
            if (!tryGetPaths(endVertex, out edgePath))
            {
                return Enumerable.Empty<TEdge>();
            }

            return edgePath;
        }

        public static IEnumerable<TEdge> FindShortestPathUndirected<TVertex, TEdge>(
                                            IVertexAndEdgeListGraph<TVertex, TEdge> graph,
                                            TVertex startVertex,
                                            TVertex endVertex)
                                        where TEdge : class, IEdge<TVertex>
        {
            var undirectedGraph = graph.Edges.ToUndirectedGraph<TVertex, TEdge>();

            if (!(undirectedGraph.Vertices.Any(v => v.Equals(startVertex))
                  && undirectedGraph.Vertices.Any(v => v.Equals(endVertex))))
            {
                return Enumerable.Empty<TEdge>();
            }

            return FindShortestPath(undirectedGraph, startVertex, endVertex);
        }

        public static IEnumerable<TVertex> BfSearch<TVertex, TEdge>(IVertexListGraph<TVertex, TEdge> graph)
            where TEdge : class, IEdge<TVertex>
        {
            //var parents = new Dictionary<TVertex, TVertex>();
            //var distances = new Dictionary<TVertex, int>();
            //TVertex currentVertex = default(TVertex);
            //int currentDistance = 0;
            var bfs = new BreadthFirstSearchAlgorithm<TVertex, TEdge>(g: graph);



            var v1 = graph.Vertices.First();
            //bfs.Visit(v1);

            List<TVertex> outVertices = new List<TVertex>();



            //bfs.DiscoverVertex += u =>
            //{
            //    outVertices.Add(u);
            //};

            bfs.FinishVertex += u =>
            {
                outVertices.Add(u);
            };


            //bfs.di

            //bfs.TreeEdge

            bfs.Compute(v1);

            ////bfs.sto

            Func<IEnumerable<TEdge>, IEnumerable<TEdge>> searchFunc = bfs.OutEdgeEnumerator;

            //var path = searchFunc(()

            //BestFirstFrontierSearchAlgorithm<> bb =

            return outVertices;
        }
    }
}
