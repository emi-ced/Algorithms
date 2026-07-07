namespace Algorithms
{
    public class QuickSort
    {
        public int[] SortArray(int[] nums)
        {
            QuickSortInternal(0, nums.Length - 1, nums);

            return nums;
        }

        // Time: Omega(n * logn) - Theta(n * logn) - O(n * n)
        // Space: Omega(logn) - Theta(logn) - O(n)
        private void QuickSortInternal(int startIndex, int endIndex, int[] nums)
        {
            if (startIndex >= endIndex)
                return;

            // Swap random number to pivot position.
            int randomIndex = Random.Shared.Next(startIndex, endIndex);

            int randomIndexValue = nums[randomIndex];
            nums[randomIndex] = nums[endIndex];
            nums[endIndex] = randomIndexValue;
            
            int pivotValue = nums[endIndex];
            int swapIndex = startIndex;

            // We can't set 'i = startIndex + 1' because we have to 
            // place all smaller values before the pivot and increment the 'swapIndex'.
            for (int i = startIndex; i < endIndex; i++)
            {
                if (nums[i] < pivotValue)
                {
                    int tempValue = nums[i];
                    nums[i] = nums[swapIndex];
                    nums[swapIndex] = tempValue;

                    swapIndex++;
                }
            }

            nums[endIndex] = nums[swapIndex];
            nums[swapIndex] = pivotValue;

            QuickSortInternal(startIndex, swapIndex - 1, nums);
            QuickSortInternal(swapIndex + 1, endIndex, nums);
        }
    }

    /// <summary>
    /// Quick-select is a variant of quick-sort where we sort only the part of the array where the target value is located.
    /// On every iteration in best case we remove half the elements of the array.
    /// </summary>
    public class QuickSelect
    {
        // Time: Omega(n) - Theta(n) - O(n*n)
        // Space: Omega(logn) - Theta(logn) - O(n)
        private int QuickSelectRecursive(int[] nums, int left, int right, int k)
        {
            if (left >= right)
                return -1;
            
            // Swap random number to pivot position.
            int randomIndex = Random.Shared.Next(left, right);

            int randomIndexValue = nums[randomIndex];
            nums[randomIndex] = nums[right];
            nums[right] = randomIndexValue;
            
            int pivotValue = nums[right];
            int swapIndex = left;

            for (int i = left; i < right - 1; i++)
            {
                if (nums[i] < pivotValue)
                {
                    var tempValue = nums[i];
                    nums[i] = nums[swapIndex];
                    nums[swapIndex] = tempValue;

                    swapIndex++;
                }
            }

            nums[right - 1] = nums[swapIndex];
            nums[swapIndex] = pivotValue;

            if ((nums.Length - k) < swapIndex)
                return QuickSelectRecursive(nums, left, swapIndex, k);
            else if ((nums.Length - k) > swapIndex)
                return QuickSelectRecursive(nums, swapIndex + 1, right, k);
            else
                return nums[swapIndex];
        }

        // Time: Omega(n) - Theta(n) - O(n*n)
        // Space: Omega(1) - Theta(1) - O(1)
        private int QuickSelectIterative(int[] nums, int left, int right, int k)
        {
            while (left < right)
            {
                // Random pivot index.
                int pivotIndex = Random.Shared.Next(left, right);
    
                // Swap random pivot to the end of the array.
                int tempPivot = nums[pivotIndex];
                nums[pivotIndex] = nums[right - 1];
                nums[right - 1] = tempPivot;

                var pivotValue = nums[right - 1];
                var swapIndex = left;

                // Partition
                for (int i = left; i < right - 1; i++)
                {
                    // Order descending.
                    if (nums[i] > pivotValue)
                    {
                        int temp = nums[i];
                        nums[i] = nums[swapIndex];
                        nums[swapIndex] = temp;
                        
                        swapIndex++;
                    }
                }

                nums[right - 1] = nums[swapIndex];
                nums[swapIndex] = pivotValue;

                // Target is in the left partition
                if ((k -1) < swapIndex)
                    right = swapIndex;
                // Target is in the right partition
                else if ((k -1) > swapIndex)
                    left = swapIndex + 1;
                // Found the target.
                else
                    return nums[swapIndex];
            }

            return -1;
        }
    }
}
