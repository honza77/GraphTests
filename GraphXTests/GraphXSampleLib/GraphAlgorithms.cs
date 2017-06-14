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
    }
}
