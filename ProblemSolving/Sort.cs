namespace ProblemSolving
{
    public static class Sort
    {

        public static string SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // Assume the current element is the smallest.
                int minIndex = i;

                // We search for the smallest in the unordered part
                for (int j = i + 1; j < n; j++)
                {
                    var currentNum = arr[j];
                    var minIndexNum = arr[minIndex];
                    if (currentNum < minIndexNum)
                        minIndex = j;
                }

                //If we find a smaller element, we replace it.
                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

            return string.Join(" , ", arr);
        }
        public static string BubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
            return string.Join(" , ", arr);
        }
    }
}
