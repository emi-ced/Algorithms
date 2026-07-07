namespace Algorithms.Graph_Algorithms
{
    // Time complexity: O(E + V)
    // Space complexity: O(E + V) 

    // E - Edge
    // V - Vertex (node)
    public class TopologicalSort
    {
        public List<int> TopologicalSortInternal(int n, int[][] edges)
        {
            Dictionary<int, List<int>> adjacencyList = new();

            for (int i = 0; i < n; i++)
                adjacencyList.Add(i, new List<int>());

            foreach (var edge in edges)
                adjacencyList[edge[1]].Add(edge[0]);

            HashSet<int> visitedVertices = new();
            HashSet<int> processedVertices = new();
            List<int> result = new();

            for (int i = 0; i < n; i++)
            {
                var cyclePresent = DFS(i, adjacencyList, visitedVertices, processedVertices, result);
                
                if (cyclePresent)
                    return [];
            }

            return result;
        }

        private bool DFS(int vertex, Dictionary<int, List<int>> adjacencyList, HashSet<int> visitedVertices, HashSet<int> processedVertices, List<int> result)
        {
            if (visitedVertices.Contains(vertex))
                return true;

            if (processedVertices.Contains(vertex))
                return false;

            visitedVertices.Add(vertex);
            processedVertices.Add(vertex);

            foreach (var adjacentVertex in adjacencyList[vertex])
            {
                var cyclePresent = DFS(adjacentVertex, adjacencyList, visitedVertices, processedVertices, result);

                if (cyclePresent)
                    return true;
            }

            visitedVertices.Remove(vertex);
            result.Add(vertex);

            return false;
        }
    }
}
