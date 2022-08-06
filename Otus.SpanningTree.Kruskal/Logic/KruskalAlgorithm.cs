using System.Collections.Generic;
using System.Linq;
using Otus.SpanningTree.Kruskal.Logic.Dtos;

namespace Otus.SpanningTree.Kruskal.Logic
{
    public class KruskalAlgorithm
    {
        public Edge[] Run(Edge[] edges)
        {
            var spanningTree = new List<Edge>();
            var spanningTreeAdjacencyMatrix = new int[edges.Length, edges.Length];

            var sortedEdges = edges.OrderBy(x => x.Weight);

            foreach (var sortedEdge in sortedEdges)
            {
                if (IsVertexReachable(spanningTreeAdjacencyMatrix, sortedEdge.First, sortedEdge.Second)) 
                    continue;

                spanningTreeAdjacencyMatrix[sortedEdge.First, sortedEdge.Second] = 1;
                spanningTreeAdjacencyMatrix[sortedEdge.Second, sortedEdge.First] = 1;
                    
                spanningTree.Add(sortedEdge);
            }

            return spanningTree.ToArray();
        }


        #region Support Methods

        //Через поиск в глубину проверяем - можем ли дойти до точек в уже сформированном остовном дереве
        private bool IsVertexReachable(int[,] adjacencyMatrix, int vertexFrom, int vertexTo)
        {
            var stack = new Stack<int>();
            stack.Push(vertexTo);

            var usedVertexes = new List<int>();

            while (stack.Count != 0)
            {
                var currentVertex = stack.Pop();
                usedVertexes.Add(currentVertex);

                var adjacencyVertexes = GetAdjacencyVertexes(adjacencyMatrix, currentVertex);
                foreach (var adjacencyVertex in adjacencyVertexes)
                {
                    if (!usedVertexes.Contains(adjacencyVertex))
                    {
                        stack.Push(adjacencyVertex);
                    }
                }
            }

            //можно оптимизировать и вместо Contains использовать два флага в цикле, но код будет некрасивый и плохочитаемый
            return usedVertexes.Contains(vertexFrom) && usedVertexes.Contains(vertexTo);
        }

        private int[] GetAdjacencyVertexes(int[,] adjacencyMatrix, int vertex)
        {
            var adjacencyVertexes = new List<int>();

            for (var i = 0; i < adjacencyMatrix.GetLength(1); i++)
            {
                if (adjacencyMatrix[vertex, i] != 0)
                {
                    adjacencyVertexes.Add(i);
                }
            }

            return adjacencyVertexes.ToArray();
        }

         #endregion
    }
}
