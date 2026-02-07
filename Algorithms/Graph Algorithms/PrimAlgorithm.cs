namespace Algorithms.Graph_Algorithms
{
    // Time and space complexity same as Dijsktra's algorithm.
    // Time complexity: O((E + V) * log V)
    // Space complexity: O(E + V) 

    // E - Edge
    // V - Vertex (node)
    // log V - Enqueing/Dequing nodes.
    public class PrimAlgorithm
    {
        public int MinimumSpanningTree(int n, List<List<int>> edges)
        {
            PriorityQueue<(int node, int weight), int> minHeap = new();
            HashSet<int> processedNodes = new();
    
            // Initialize and set default empty lists for each node.
            Dictionary<int, List<(int node, int weight)>> adjacencyList = new();
            for (int i = 0; i < n; i++)
                adjacencyList.Add(i, new List<(int node, int weight)>());
    
            // Define all edges for each node.
            foreach(var edge in edges)
            {
                int nodeOne = edge[0];
                int nodeTwo = edge[1];
                int weight = edge[2];
    
                adjacencyList[nodeOne].Add((nodeTwo, weight));
                adjacencyList[nodeTwo].Add((nodeOne, weight));
            }
    
            int minWeight = 0;
    
            // Set starting location as first node.
            // We could also add all the adjacent nodes from first node and mark it as processed.
            minHeap.Enqueue((0, 0), 0);
    
            while (minHeap.Count > 0)
            {
                (int node, int weight) = minHeap.Dequeue();
    
                // Works on the principle that the source node has been already processed.
                if (!processedNodes.Contains(node))
                {
                    minWeight += weight;
    
                    processedNodes.Add(node);
    
                    foreach(var edge in adjacencyList[node])
                        minHeap.Enqueue(edge, edge.weight);
                }
            }
    
            return processedNodes.Count == n ? minWeight : -1;
        }
    }
}
