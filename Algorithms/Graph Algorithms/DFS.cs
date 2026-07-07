namespace Algorithms.Graph_Algorithms
{
    public class DFS
    {
        public IList<int> RecursiveDFS(TreeNode root)
        {
            List<int> result = new();
            RecursiveInternalInOrder(root, result);
            return result;
        }

        private void RecursiveInternalInOrder(TreeNode node, List<int> values)
        {
            if (node == null)
                return;

            RecursiveInternalInOrder(node.left, values);
            values.Add(node.val);
            RecursiveInternalInOrder(node.right, values);
        }

        private void RecursiveInternalPreOrder(TreeNode node, List<int> values)
        {
            if (node == null)
                return;

            values.Add(node.val);
            RecursiveInternalInOrder(node.left, values);
            RecursiveInternalInOrder(node.right, values);
        }

        private void RecursiveInternalPostOrder(TreeNode node, List<int> values)
        {
            if (node == null)
                return;

            RecursiveInternalInOrder(node.left, values);
            RecursiveInternalInOrder(node.right, values);
            values.Add(node.val);
        }

        private List<int> IterativeInOrderTraversal(TreeNode root)
        {
            List<int> result = new();
    
            Stack<TreeNode> stack = new();

            // Due to the way the nodes have to be accessed, we have to use the 
            // pointer and stack to achieve in-order traversal.
            // Once a node is popped from the stack, all of its left 
            // children have processed, and it is its turn.
            while (root != null || stack.Count > 0)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    var tempNode = stack.Pop();
                    result.Add(tempNode.val);
    
                    root = tempNode.right;
                }
            }
    
            return result;
        }

        private List<int> IterativePreOrderTraversal(TreeNode root)
        {
            Stack<TreeNode> stack = new();
            List<int> result = [];
    
            if (root != null)
                stack.Push(root);
    
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.val);
    
                if (node.right != null)
                    stack.Push(node.right);
    
                if (node.left != null)
                    stack.Push(node.left);
            }
    
            return result;
        }
        
        private List<int> IterativePostOrderTraversal(TreeNode root)
        {
            List<int> result = new();
    
            Stack<TreeNode> stack = new();
            Stack<bool> visited = new();
    
            if (root != null)
            {
                stack.Push(root);
                visited.Push(false);
            }
    
            while (stack.Count > 0)
            {
                var node  = stack.Pop();
                var isVisited = visited.Pop();
    
                if (isVisited)
                {
                    result.Add(node.val);
                }
                else
                {
                    stack.Push(node);
                    visited.Push(true);
    
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                        visited.Push(false);
                    }
    
                    if (node.left != null)
                    {
                        stack.Push(node.left);
                        visited.Push(false);
                    }
                }
            }
    
            return result;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
