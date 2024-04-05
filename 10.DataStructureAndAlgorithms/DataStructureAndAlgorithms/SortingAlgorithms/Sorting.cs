using System.Collections;

namespace SortingAlgorithms
{
    public class Sorting
    {
        void BubleSort(ArrayList list)
        {
            //We check if the list is null or has 0 or 1 elements.In such cases, the list is already considered sorted, and there's no need to perform any sorting operations.
            //We use nested loops to iterate through the list and compare adjacent elements.
            //If the elements are in the wrong order, we swap them.
            //We use the Comparer.Default.Compare method to compare elements, which allows the bubble sort algorithm to work with any type of elements that implement the IComparable interface.
            //Finally, we demonstrate the usage of the BubbleSort method with an example ArrayList containing integers.

            if (list == null || list.Count <= 1)
            {
                // If the list is null or has 0 or 1 elements, it is already sorted
                return;
            }
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    // Compare adjacent elements and swap if they are in the wrong order
                    if (Comparer.Default.Compare(list[j], list[j + 1]) > 0)
                    {
                        object temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        void SelectionSort(ArrayList list)
        {
            //It iterates through the list, finding the index of the minimum element in the unsorted part of the list.
            //Once the index of the minimum element is found, it swaps the minimum element with the current element.
            //This process is repeated until the list is sorted.
            //Selection Sort has a time complexity of O(n^2) in the worst case, making it inefficient for large lists but suitable for small lists or partially sorted lists.

            if (list == null || list.Count <= 1)
            {
                // If the list is null or has 0 or 1 elements, it is already sorted
                return;
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    // Find the index of the minimum element in the unsorted part of the list
                    if ((int)list[j] < (int)list[minIndex])
                    {
                        minIndex = j;
                    }
                }
                // Swap the minimum element with the current element
                if (minIndex != i)
                {
                    object temp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = temp;
                }
            }
        }

        void InsertionSort(ArrayList list)
        {
            //We iterate through the list starting from the second element(index 1).
            //For each element, we save its value and compare it with the elements to its left in the sorted sublist.
            //We shift the larger elements one position to the right to make space for the current element.
            //Once we find the correct position for the current element, we insert it into the sorted sublist.
            //We repeat this process until all elements are sorted.
            //Insertion Sort has a time complexity of O(n^2) in the worst case but performs efficiently for small lists or partially sorted lists.


            if (list == null || list.Count <= 1)
            {
                // If the list is null or has 0 or 1 elements, it is already sorted
                return;
            }

            for (int i = 1; i < list.Count; i++)
            {
                object key = list[i];
                int j = i - 1;

                // Move elements of list[0..i-1], that are greater than key, to one position ahead of their current position
                while (j >= 0 && (int)list[j] > (int)key)
                {
                    list[j + 1] = list[j];
                    j = j - 1;
                }
                list[j + 1] = key;
            }
        }

        void BinarySort(ArrayList list)
        {
            if (list == null || list.Count <= 1)
            {
                // If the list is null or has 0 or 1 elements, it is already sorted
                return;
            }

            for (int i = 1; i < list.Count; i++)
            {
                object key = list[i];
                int left = 0;
                int right = i - 1;

                // Use binary search to find the correct position to insert the key
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    // If key is less than the middle element, search in the left half
                    if ((int)key < (int)list[mid])
                    {
                        right = mid - 1;
                    }
                    // If key is greater than the middle element, search in the right half
                    else
                    {
                        left = mid + 1;
                    }
                }

                // Shift elements to make space for the key
                for (int j = i - 1; j >= left; j--)
                {
                    list[j + 1] = list[j];
                }

                // Insert the key into its correct position
                list[left] = key;
            }
        }

        public class MergeSort
        {
            //The MergeSort method is the entry point for the Merge Sort algorithm.It calls the MergeSortHelper method, which recursively sorts the list.
            //The MergeSortHelper method divides the list into two halves, recursively sorts each half, and then merges the sorted halves using the Merge method.
            //The Merge method merges two sorted arrays into a single sorted array.
            //Merge Sort has a time complexity of O(n log n) in all cases, making it efficient for sorting large lists.

            public ArrayList list;

            public MergeSort(ArrayList list)
            {
                this.list = list;
            }

            void Sort()
            {
                if (list == null || list.Count <= 1)
                {
                    // If the list is null or has 0 or 1 elements, it is already sorted
                    return;
                }

                ArrayList sortedList = MergeSortHelper(list);
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = sortedList[i];
                }
            }

            private ArrayList MergeSortHelper(ArrayList list)
            {
                if (list.Count <= 1)
                {
                    // Base case: If the list has 0 or 1 element, it is already sorted
                    return list;
                }

                // Divide the list into two halves
                int mid = list.Count / 2;
                ArrayList leftHalf = new ArrayList();
                ArrayList rightHalf = new ArrayList();
                for (int i = 0; i < mid; i++)
                {
                    leftHalf.Add(list[i]);
                }
                for (int i = mid; i < list.Count; i++)
                {
                    rightHalf.Add(list[i]);
                }

                // Recursively sort each half
                leftHalf = MergeSortHelper(leftHalf);
                rightHalf = MergeSortHelper(rightHalf);

                // Merge the sorted halves
                return Merge(leftHalf, rightHalf);
            }

            private ArrayList Merge(ArrayList left, ArrayList right)
            {
                ArrayList merged = new ArrayList();
                int leftIndex = 0, rightIndex = 0;

                while (leftIndex < left.Count && rightIndex < right.Count)
                {
                    if ((int)left[leftIndex] <= (int)right[rightIndex])
                    {
                        merged.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        merged.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }

                // Add remaining elements from left and right halves (if any)
                while (leftIndex < left.Count)
                {
                    merged.Add(left[leftIndex]);
                    leftIndex++;
                }
                while (rightIndex < right.Count)
                {
                    merged.Add(right[rightIndex]);
                    rightIndex++;
                }

                return merged;
            }
        }

        public class QuickSort
        {
            //The Sort method is the entry point for the Quick Sort algorithm.It calls the QuickSortHelper method to recursively sort the list.
            //The QuickSortHelper method partitions the list around a pivot element and recursively sorts the sub-arrays before and after the pivot.
            //The Partition method partitions the list around the pivot element and returns the index of the pivot element.
            //Quick Sort has an average time complexity of O(n log n) and a worst-case time complexity of O(n^2). However, it is often faster in practice compared to other O(n log n) sorting algorithms like Merge Sort and Heap Sort.

            public ArrayList list;

            public QuickSort(ArrayList list)
            {
                this.list = list;
            }

            void Sort(ArrayList list)
            {
                if (list == null || list.Count <= 1)
                {
                    // If the list is null or has 0 or 1 elements, it is already sorted
                    return;
                }

                QuickSortHelper(list, 0, list.Count - 1);
            }

            private static void QuickSortHelper(ArrayList list, int low, int high)
            {
                if (low < high)
                {
                    // Partition the list and get the index of the pivot element
                    int pivotIndex = Partition(list, low, high);

                    // Recursively sort the sub-arrays before and after the pivot
                    QuickSortHelper(list, low, pivotIndex - 1);
                    QuickSortHelper(list, pivotIndex + 1, high);
                }
            }

            private static int Partition(ArrayList list, int low, int high)
            {
                // Choose the rightmost element as the pivot
                int pivot = (int)list[high];
                int i = low - 1;

                // Partition the list around the pivot
                for (int j = low; j < high; j++)
                {
                    if ((int)list[j] < pivot)
                    {
                        i++;
                        Swap(list, i, j);
                    }
                }

                // Move the pivot element to its correct position
                Swap(list, i + 1, high);

                // Return the index of the pivot element
                return i + 1;
            }

            private static void Swap(ArrayList list, int index1, int index2)
            {
                object temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
            }
        }

        public class HeapSort
        {
            public ArrayList list;

            public HeapSort(ArrayList list)
            {
                this.list = list;
            }

            void Sort(ArrayList list)
            {
                if (list == null || list.Count <= 1)
                {
                    // If the list is null or has 0 or 1 elements, it is already sorted
                    return;
                }

                // Build a max heap
                BuildMaxHeap(list);

                // Extract elements from the heap one by one
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    // Move the current root to the end
                    Swap(list, 0, i);

                    // Call MaxHeapify on the reduced heap
                    MaxHeapify(list, i, 0);
                }
            }

            private static void BuildMaxHeap(ArrayList list)
            {
                // Build a max heap by repeatedly calling MaxHeapify
                for (int i = list.Count / 2 - 1; i >= 0; i--)
                {
                    MaxHeapify(list, list.Count, i);
                }
            }

            private static void MaxHeapify(ArrayList list, int heapSize, int index)
            {
                int largest = index; // Initialize largest as root
                int leftChild = 2 * index + 1; // Left child index
                int rightChild = 2 * index + 2; // Right child index

                // If left child is larger than root
                if (leftChild < heapSize && (int)list[leftChild] > (int)list[largest])
                {
                    largest = leftChild;
                }

                // If right child is larger than largest so far
                if (rightChild < heapSize && (int)list[rightChild] > (int)list[largest])
                {
                    largest = rightChild;
                }

                // If largest is not root
                if (largest != index)
                {
                    // Swap the root with the largest element
                    Swap(list, index, largest);

                    // Recursively heapify the affected sub-tree
                    MaxHeapify(list, heapSize, largest);
                }
            }

            private static void Swap(ArrayList list, int index1, int index2)
            {
                object temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
            }

        }
    }
}
