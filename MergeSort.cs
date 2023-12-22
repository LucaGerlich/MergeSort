using System;
using System.Diagnostics;

class MergeSort
{

    static void Main()
    {
        int[] array = { 4, 2, 6, 5, 3, 1, 7 };

        Console.WriteLine("Unsortiertes Array:");
        PrintArray(array);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        MergeSortAlgorithm(array, 0, array.Length - 1);

        stopwatch.Stop();
        Console.WriteLine($"\nSortiertes Array (Laufzeit: {stopwatch.ElapsedMilliseconds} ms):");
        PrintArray(array);
    }

    //Ein Array mit Zahlen wird erstellt und ausgegeben, um den Ausgangszustand zu zeigen.
    //Dann wird die MergeSortAlgorithm-Methode aufgerufen, um das Array zu sortieren.
    //Schließlich wird das sortierte Array ausgegeben.

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

    //Diese Methode fusioniert zwei sortierte Teile des Arrays.
    //Sie nimmt das ursprüngliche Array, den linken, mittleren und rechten Index als Parameter.
    //Zwei temporäre Arrays (leftArray und rightArray) werden erstellt, um die linken und rechten Teile zu speichern.
    //Dann erfolgt der eigentliche Merge-Schritt, bei dem die Elemente verglichen und in das ursprüngliche Array zurückgeschrieben werden.

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

    //Dies ist die rekursive Methode, die den Merge-Sort-Algorithmus implementiert.
    //Sie nimmt das zu sortierende Array, den linken Index und den rechten Index als Parameter.
    //Die Methode überprüft, ob left kleiner als right ist. Wenn dies der Fall ist, wird die Mitte berechnet, und die Methode wird rekursiv für die linke und rechte Hälfte des Arrays aufgerufen.
    //Der rekursive Aufruf erfolgt, bis die Basisbedingung erfüllt ist (wenn left nicht mehr kleiner als right ist).

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
