namespace Algorithms
{
    public class BinarySearch
    {
        public int BinarySearchIterative(int[] nums, int target)
        {
            int leftIndex = 0;
            int rightIndex = nums.Length - 1;

            while (leftIndex <= rightIndex)
            {
                int midIndex = leftIndex + ((rightIndex - leftIndex) / 2);

                if (nums[midIndex] < target)
                    leftIndex = midIndex + 1;
                else if (nums[midIndex] > target)
                    rightIndex = midIndex - 1;
                else
                    return midIndex;
            }

            return -1;
        }

        private int BinarySearchRecursive(int leftIndex, int rightIndex, int[] nums, int target)
        {
            if (leftIndex > rightIndex)
                return -1;
    
            int midIndex = leftIndex + ((rightIndex - leftIndex) / 2);
    
            if (nums[midIndex] < target)
                return BinarySearchRecursive(midIndex + 1, rightIndex, nums, target);
            else if (nums[midIndex] > target)
                return BinarySearchRecursive(leftIndex, midIndex - 1, nums, target);
            else
                return midIndex;
        }
    }
}
