namespace Algorithms.Graph_Algorithms
{
    // Used to find minimum-weight path with a set start-node on a graph.
    // Works only on positive weight values.

    // Time complexity: O((E + V) * log V)
    // Space complexity: O(E + V) 

    // E - Edge
    // V - Vertex (node)
    // log V - Enqueing/Dequing nodes.
    public class DijkstraAlgorithm
    {
        public Dictionary<int, int> ShortestPath(int n, List<List<int>> edges, int src)
        {
            Dictionary<int, int> result = new();

            Dictionary<int, List<(int name, int weight)>> adjacencyList = new();

            for (int i = 0; i < n; i++)
            {
                result.Add(i, -1);
                adjacencyList.Add(i, new List<(int name, int weight)>());
            }

            // Define adjacency list using provided edges.
            foreach (var edge in edges)
            {
                var source = edge[0];
                var destination = edge[1];
                var weight = edge[2];

                adjacencyList[source].Add((destination, weight));
            }

            PriorityQueue<(int name, int weight), int> minHeap = new();
            minHeap.Enqueue((src, 0), 0);

            while (minHeap.Count > 0)
            {
                (int nodeName, int nodeWeight) = minHeap.Dequeue();

                if (result[nodeName] == -1)
                {
                    result[nodeName] = nodeWeight;

                    foreach (var neighbourNode in adjacencyList[nodeName])
                    {
                        (int neighbourName, int neighbourWeight) = neighbourNode;

                        if (result[neighbourName] == -1)
                            minHeap.Enqueue((neighbourName, neighbourWeight + nodeWeight), neighbourWeight + nodeWeight);
                    }
                }
            }

            return result;
        }
    }
}
