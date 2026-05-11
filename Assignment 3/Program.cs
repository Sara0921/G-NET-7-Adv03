namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 01

            List<int> grades = [85, 92, 78, 95, 88, 70, 100, 65];

            // Print collection
            Console.WriteLine("All Grades:");
            Console.WriteLine(string.Join(", ", grades));

            // Count, First, Last
            Console.WriteLine($"Count: {grades.Count}");
            Console.WriteLine($"First Grade: {grades.First()}");
            Console.WriteLine($"Last Grade: {grades.Last()}");

            // Enhancement: Index from end using ^ operator
            Console.WriteLine($"Last Grade (using ^ operator): {grades[^1]}");


            //// Sort ascending
            grades.Sort();
            Console.WriteLine("\nSorted Grades:");
            Console.WriteLine(string.Join(", ", grades));

            // First grade above 90
            int firstAbove90 = grades.FirstOrDefault(g => g > 90);
            Console.WriteLine($"\nFirst grade above 90: {firstAbove90}");

            // All grades below 75
            var failingGrades = grades.Where(g => g < 75).ToList();
            Console.WriteLine("\nFailing Grades (<75):");
            Console.WriteLine(string.Join(", ", failingGrades));

            // Remove failing grades
            grades.RemoveAll(g => g < 75);
            Console.WriteLine("\nGrades after removing failing ones:");
            Console.WriteLine(string.Join(", ", grades));

            // Check if any grade equals 100
            bool hasPerfect = grades.Any(g => g == 100);
            Console.WriteLine($"\nContains 100? {hasPerfect}");

            // Convert to List<string> using .. range operator and LINQ Select
            List<string> gradeStrings = [.. grades.Select(g => $"Grade: {g}")];

            Console.WriteLine("\nString List:");
            foreach (var item in gradeStrings)
            {
                Console.WriteLine(item);
            }

            #endregion

        }
    }
}
