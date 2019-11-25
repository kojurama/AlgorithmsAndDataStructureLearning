using System;

namespace CSharpAlgorithms
{
    public class Sorting
    {
        public static void BubbleSort(int[] array)
        {
            for (int partIndex = array.Length-1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                    }
                }
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int partIndex = array.Length-1; partIndex > 0; partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }
                Swap(array, largestAt, partIndex);
            }
        }

        public static void InsertionSort(int[] array)
        {
            for(int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int curUnsorted = array[partIndex];
                int i = 0;
                for (i = partIndex; i > 0 && array[i-1] > curUnsorted; i--)
                {
                    array[i] = array[i - 1];
                }

                array[i] = curUnsorted;

            }
        }

        public static void ShellSort(int[] array)
        {
            int gap = 1;
            while (gap < array.Length / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    for(int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                    {
                        Swap(array, j, j - gap);
                    }
                }

                gap /= 3;
            }
        }

        public static void MergeSort(int[] array)
        {
            // auxillary array to use temprorily for building the new array when merging
            int[] aux = new int[array.Length];
            // recursive method using array's perameters left most and right most index
            Sort(0, array.Length - 1);

            // recursive method to divide array into arrays of a single element
            void Sort( int low, int high)
            {
                /* break case for when the arrays get down to single element arrays the
                recursive method stops. IE when the left most index and right most index
                are equal(0) then there is no need to continue and it stops*/
                if (high <= low)
                    return;

                // defining the split index for seperating the arrays into 2
                int mid = (high + low / 2);

                // sorting the left side of the array
                Sort(low, mid);
                // sorting the right side of the array
                Sort(mid + 1, high);

                /* As we definied low, mid, and high integers for use in seperating
                the array. We make use of those integers for merging so that it merges 
                in a similar pattern. */
                Merge(low, mid, high);

            }

            void Merge(int low, int mid, int high)
            {
                // Performance statement for if both sides are already ordered.
                if (array[mid] <= array[mid + 1])
                    return;
                // start at left side of array
                int i = low;
                // start at right side of array
                int j = mid + 1;

                /* 1st) Taking data from source array. 2nd) Taken data begins at the low index and is
                3rd) transfered to auxillary array. 4th) The copied data begins at the low index and 
                5th) is the length of the array. */
                Array.Copy(array, low, aux, low, high - low + 1);

                /* Iterating loop to build auxillary array. It begins at at 0 index and iterates to
                the right. As it goes left to right it builds array smallest to biggest from a series
                of comparative if else statements. */
                for (int k = low; k <= high; k++)
                {
                    // If left array runs out of indexes then we use the right partitioned array.
                    // After switching sides we then begin to iterate there.
                    if (i > mid) array[k] = aux[j++];
                    // If right side runs out of indexes then we use left partitioned array.
                    else if (j > high) array[k] = aux[i++];
                    /* If the right array index is smaller than left side we copy the right sides 
                    elemtent into the auxillary array and then iterate over the right array. */
                    else if (aux[j] < aux[i])
                        array[k] = aux[j++];
                    // If none of these statements apply than the arrays are in order and left is copied.
                    else
                        array[k] = aux[i++];
                }
            }
        }

        public static void QuickSort(int[] array)
        {
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                    return;
                int j = Partition(low, high);
                Sort(low, j - 1);
                Sort(j + 1, high);
            }
            
            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;

                int pivot = array[low];
                while (true)
                {
                    while (array[++i] < pivot)
                    {
                        if (i == high)
                            break;
                    }
                    while (pivot < array[--j])
                    {
                        if (j == low)
                            break;
                    }

                    if (i >= j)
                        break;

                    Swap(array, i, j);
                }
                Swap(array, low, j);
                return j;
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j)
                return;
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
