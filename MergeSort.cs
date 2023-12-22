using System;

class MergeSort
{
    static void Main()
    {
        int[] array = { 12, 11, 13, 5, 6, 7, 4, 8, 43, 94, 34, 23, 64, 7, 21 };
        
        Console.WriteLine("Unsortiertes Array:");
        PrintArray(array);

        MergeSortAlgorithm(array, 0, array.Length - 1);

        Console.WriteLine("\nSortiertes Array:");
        PrintArray(array);
    }

    static void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, middle + 1, rightArray, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }

    static void MergeSortAlgorithm(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;

            MergeSortAlgorithm(array, left, middle);
            MergeSortAlgorithm(array, middle + 1, right);

            Merge(array, left, middle, right);
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
