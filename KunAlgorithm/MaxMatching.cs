using System;
using System.Collections.Generic;
using System.Linq;

namespace KunAlgorithm
{
    public static class MaxMatching
    {
        private static int[] matchings;
        private static Graph currentGraph;

        public static List<Tuple<int, int>> Get(Graph graph)
        {
            matchings = new int[graph.Vertices];
            currentGraph = graph;

            InitialFillingMatchings();

            bool[] visited = new bool[graph.Vertices];

            for (int vertice = 0; vertice < graph.Vertices; vertice++)
            {
                DFS(vertice, visited);
            }

            return TransfotmToTuples(matchings);
        }

        private static void InitialFillingMatchings()
        {
            for (int i = 0; i < matchings.Length; i++)
            {
                matchings[i] = -1;
            }
        }

        private static bool DFS(int vertice, bool[] visited)
        {
            if (visited[vertice])
            {
                return false;
            }

            visited[vertice] = true;

            List<int> connectedVertices = GetConnectedVertices(vertice);

            foreach (var connectedVertice in connectedVertices)
            {
                if (matchings[connectedVertice] == -1 || DFS(matchings[connectedVertice], visited))
                {
                    matchings[connectedVertice] = vertice;
                    return true;
                }
            }

            return false;
        }

        private static List<int> GetConnectedVertices(int vertice)
        {
            List<int> connectedVertices = new List<int>();
            for (int i = 0; i < currentGraph.Vertices; i++)
            {
                if (currentGraph.Matrix[vertice, i] == 1)
                {
                    connectedVertices.Add(i);
                }
            }

            return connectedVertices;
        }

        private static List<Tuple<int, int>> TransfotmToTuples(int[] matchings)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            for (int i = 0; i < matchings.Length; i++)
            {
                if (matchings[i] == -1)
                {
                    continue;
                }

                if (!result.Any(e => e.Item1 == matchings[i] && e.Item2 == i))
                {
                    result.Add(Tuple.Create<int, int>(i, matchings[i]));
                }
            }

            return result;
        }
    }
}
