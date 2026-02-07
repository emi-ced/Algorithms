namespace Algorithms
{
    public class QuickSort
    {
        public int[] SortArray(int[] nums)
        {
            QuickSortInternal(0, nums.Length, nums);

            return nums;
        }

        // Time: Omega(n * logn) - Theta(n * logn) - O(n * n)
        // Space: Omega(logn) - Theta(logn) - O(n)
        private void QuickSortInternal(int startIndex, int endIndex, int[] nums)
        {
            if (startIndex >= endIndex)
                return;

            int pivotValue = nums[endIndex - 1];
            int nextAvailableSlot = startIndex;

            // We can't set 'i = startIndex + 1' because we have to define the value at 'startIndex' as smaller than pivot.
            // Otherwise the value will be moved as greater which is not always correct.
            for (int i = startIndex; i < endIndex; i++)
            {
                if (nums[i] < pivotValue)
                {
                    int tempValue = nums[i];
                    nums[i] = nums[nextAvailableSlot];
                    nums[nextAvailableSlot] = tempValue;

                    nextAvailableSlot++;
                }
            }

            nums[endIndex - 1] = nums[nextAvailableSlot];
            nums[nextAvailableSlot] = pivotValue;

            QuickSortInternal(startIndex, nextAvailableSlot, nums);
            QuickSortInternal(nextAvailableSlot + 1, endIndex, nums);
        }
    }

    /// <summary>
    /// Quick-select is a variant of quick-sort where we sort only the part of the array where the target value is located.
    /// On every iteration in best case we remove half the elements of the array.
    /// Time: Omega(n) - Theta(n) - O(n*n)
    /// Space: Omega(logn) - Theta(logn) - O(n)
    /// </summary>
    public class QuickSelect
    {
        private int QuickSelectInternal(int[] nums, int left, int right, int k)
        {
            var pivotValue = nums[right - 1];
            var swapIndex = left;

            for (int i = left; i < right; i++)
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
                return QuickSelectInternal(nums, left, swapIndex, k);
            else if ((nums.Length - k) > swapIndex)
                return QuickSelectInternal(nums, swapIndex + 1, right, k);
            else
                return nums[swapIndex];
        }
    }
}
