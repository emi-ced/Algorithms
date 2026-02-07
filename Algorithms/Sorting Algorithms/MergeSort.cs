namespace Algorithms
{
    // Time complexity: O(n * log n)
    // The array is split 'log n' times and for each one we merge the two sections.
    
    // Space complexity : O(n + log n)
    // Where 'log n' represents the max depth of the recursion call stack.
    internal class MergeSort
    {
        public int[] SortArray(int[] nums)
        {
            MergeSortInternal(0, nums.Length, nums);

            return nums;
        }

        private void MergeSortInternal(int startIndex, int endIndex, int[] nums)
        {
            if (startIndex >= endIndex)
                return;

            int midIndex = startIndex + ((endIndex - startIndex) / 2);

            MergeSortInternal(startIndex, midIndex, nums);
            MergeSortInternal(midIndex, endIndex, nums);
            Merge(nums, startIndex, midIndex, endIndex);
        }

        private void Merge(int[] nums, int startIndex, int midIndex, int endIndex)
        {
            int[] leftHalf = new int[midIndex - startIndex];
            int[] rightHalf = new int[endIndex - midIndex];

            for (int i = startIndex; i < midIndex; i++)
                leftHalf[i - startIndex] = nums[i];

            for (int j = midIndex; j < endIndex; j++)
                rightHalf[j - midIndex] = nums[j];

            int mainIndex = startIndex;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < midIndex - startIndex && rightIndex < endIndex - midIndex)
            {
                if (leftHalf[leftIndex] <= rightHalf[rightIndex])
                {
                    nums[mainIndex] = leftHalf[leftIndex];
                    leftIndex++;
                }
                else
                {
                    nums[mainIndex] = rightHalf[rightIndex];
                    rightIndex++;
                }

                mainIndex++;
            }

            while (leftIndex < midIndex - startIndex)
            {
                nums[mainIndex] = leftHalf[leftIndex];
                mainIndex++;
                leftIndex++;
            }

            while (rightIndex < endIndex - midIndex)
            {
                nums[mainIndex] = rightHalf[rightIndex];
                mainIndex++;
                rightIndex++;
            }
        }
    }
}
