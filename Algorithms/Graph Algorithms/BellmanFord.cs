namespace Algorithms.Graph_Algorithms
{
    // Used to determine shortest path on weighted graph with negative values with a set start-node.
    // Unlike Dijkstra's algorithm, Bellman-Ford works on negative weight values.

    // Time complexity: O (V * E)
    // Space complexity: O (V + E)

    // E - Edge
    // V - Vertex (node)
    public int BellmanFord (int[][] times, int n, int k)
    {
        Dictionary<int, int> nodeDistance = new();
        for (int i = 1; i <= n; i++)
        {
            // If we specified '-1' instead of 'int.MaxValue' we would never get the solution.
            // 'nodeDistance[edge[0]] + edge[2] < nodeDistance[edge[1]]' would never be true becuase '-1' is always smaller.
            nodeDistance.Add(i, int.MaxValue);
        }    
        nodeDistance[k] = 0;

        // Define min distance to each node.
        for (int i = 0; i < n - 1; i++)
        {
            bool updateOccurred = false;

            foreach (var edge in times)
            {
                if (nodeDistance[edge[0]] != int.MaxValue && nodeDistance[edge[0]] + edge[2] < nodeDistance[edge[1]])
                {
                    nodeDistance[edge[1]] = nodeDistance[edge[0]] + edge[2];
                    updateOccurred = true;
                }
            }

            if (!updateOccurred)
                break;
        }

        // Find negative self-recursion.
        foreach (var edge in times)
        {
            if (nodeDistance[edge[0]] + edge[2] < nodeDistance[edge[1]])
                return -1;
        }

        return nodeDistance.Values.Max() == int.MaxValue ? -1 : nodeDistance.Values.Max();
    }
}
