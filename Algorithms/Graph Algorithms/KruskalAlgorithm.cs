namespace Algorithms.Graph_Algorithms
{
    // Time complexity: O(E * log E)
    // Space complexity: O(E + V) 

    // E - Edge
    // V - Vertex (node)
    // log V - Enqueing/Dequing nodes.
    public class KruskalAlgorithm
    {
        public int MinimumSpanningTree(int n, List<List<int>> edges)
        {
            int totalMSTWeight = 0;
            int mstEdgeCount = 0; // Can be replaced with method from UnionFind that would return number of components.

            PriorityQueue<(int x, int y, int weight), int> minHeap = new();
            foreach (var edge in edges)
                minHeap.Enqueue((edge[0], edge[1], edge[2]), edge[2]);

            UnionFind unionFind = new(n);

            while (minHeap.Count > 0)
            {
                (int x, int y, int weight) = minHeap.Dequeue();

                if (unionFind.Union(x, y))
                {
                    totalMSTWeight += weight;
                    mstEdgeCount++;
                }
            }

            return mstEdgeCount == n - 1 ? totalMSTWeight : -1;
        }
    }

    public class UnionFind
    {
        private Dictionary<int, int> parents = new();
        private Dictionary<int, int> ranks = new();

        public UnionFind(int n)
        {
            for (int i = 0; i < n; i++)
            {
                parents.Add(i, i);
                ranks.Add(i, 0);
            }
        }

        public bool Union(int x, int y)
        {
            var xParent = FindParent(x);
            var yParent = FindParent(y);

            if (xParent == yParent)
                return false;

            if (ranks[xParent] > ranks[yParent])
            {
                parents[yParent] = xParent;
            }
            else if (ranks[yParent] > ranks[xParent])
            {
                parents[xParent] = yParent;
            }
            // Same rank for both parents.
            else
            {
                parents[yParent] = xParent;
                ranks[xParent] += 1;
            }

            return true;
        }

        public bool IsConnected()
        {
            int count = 0;

            foreach (var entry in _parents)
                count += (entry.Key == entry.Value) ? 1 : 0;
    
            return count == 1;
        }        

        private int FindParent(int x)
        {
            var node = parents[x];

            while (node != parents[node])
            {
                parents[node] = parents[parents[node]];
                node = parents[node];
            }

            return node;
        }
    }
}
