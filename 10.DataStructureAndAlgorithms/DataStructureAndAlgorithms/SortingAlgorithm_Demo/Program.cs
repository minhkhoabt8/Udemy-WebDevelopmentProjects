// See https://aka.ms/new-console-template for more information
using SortingAlgorithms;
using System.Collections;
using System.Diagnostics;

public class SortingAlgorithmsDemo
{

    private const int NUMBER_IN_LIST = 30000000;
    private static List<int> list = new List<int>();

    static async Task Main(string[] args)
    {
        await CreateListAsync();
        await RunSortingAlgorithmsAsync();
    }

    static async Task CreateListAsync()
    {
        Random random = new Random();
        // Create a list of numbers within the desired range
        List<int> numbers = Enumerable.Range(0, NUMBER_IN_LIST).ToList();

        // Shuffle the list
        for (int i = 0; i < numbers.Count; i++)
        {
            int temp = numbers[i];
            int randomIndex = random.Next(i, numbers.Count);
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;
        }

        // Add the shuffled numbers to the main list
        list.AddRange(numbers);
    }
    static async Task RunSortingAlgorithmsAsync()
    {
        Console.WriteLine("--------------------------------------------------------------");

        await MeasureSortingAlgorithmAsync("Insertion Sort", Sorting.InsertionSort);
        await MeasureSortingAlgorithmAsync("Bubble Sort", Sorting.BubleSort);
        await MeasureSortingAlgorithmAsync("Selection Sort", Sorting.SelectionSort);
        // Add other sorting algorithms here...

        Console.WriteLine("--------------------------------------------------------------");
    }

    static async Task MeasureSortingAlgorithmAsync(string algorithmName, Func<ArrayList, Task> sortingAlgorithm)
    {
        Console.WriteLine($"Execution time of {algorithmName} with N({NUMBER_IN_LIST}):");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start(); // Start the stopwatch

        await Task.Run(() => sortingAlgorithm(list)); // Perform the sorting asynchronously

        stopwatch.Stop(); // Stop the stopwatch

        // Print the execution time
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} milliseconds");
    }
}
