using System;
using System.Collections.Generic;
using System.Linq;
using QuickGraph;
using QuickGraph.Algorithms;

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
            Func<TEdge, double> edgeCost = e => 1; // constant cost

            // algorithm build arround 'command pattern': 
            var tryGetPaths = graph.ShortestPathsDijkstra(edgeWeights: edgeCost, source: startVertex);

            // act:
            IEnumerable<TEdge> edgePath;
            if (!tryGetPaths(endVertex, out edgePath))
            {
                yield break;
            }

            // return path:
            foreach (var edge in edgePath)
            {
                yield return edge;
            }
        }

        public static IEnumerable<TEdge> FindShortestPath<TVertex, TEdge>(
                                            IUndirectedGraph<TVertex, TEdge> graph, 
                                            TVertex startVertex, 
                                            TVertex endVertex)
                                        where TEdge : class, IEdge<TVertex>
        {
            Func<TEdge, double> edgeCost = e => 1; // constant cost

            if (!(graph.Vertices.Any(v => v.Equals(startVertex))
                  && graph.Vertices.Any(v => v.Equals(endVertex))))
            {
                yield break;
            }

            var tryGetPaths = graph.ShortestPathsDijkstra(edgeWeights: edgeCost, source: startVertex);


            // query path for given vertices
            IEnumerable<TEdge> edgePath;
            if (!tryGetPaths(endVertex, out edgePath))
            {
                yield break;
            }

            foreach (var edge in edgePath)
            {
                yield return edge;

            }
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
    }
}
