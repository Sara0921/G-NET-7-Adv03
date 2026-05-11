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
            #region Exercise 02 

            // Create leaderboard (sorted by score automatically)
            SortedDictionary<int, string> leaderboard = new()
            {
                {500, "Ahmed"},
                {200, "Sara"},
                {800, "Ali"},
                {350, "Mona"}
            };

            // Print all entries
            Console.WriteLine("Leaderboard:");
            foreach (var entry in leaderboard)
                Console.WriteLine($"Score: {entry.Key}, Player: {entry.Value}");

            // First key and first value - Using LINQ First() - O(log n) + enumeration overhead
            Console.WriteLine($"\nFirst Score: {leaderboard.First().Key}");
            Console.WriteLine($"First Player: {leaderboard.First().Value}");

            // Check if score 500 exists
            bool exists = leaderboard.ContainsKey(500);
            Console.WriteLine($"\nScore 500 exists? {exists}");

            // Safely get player with score 999
            if (leaderboard.TryGetValue(999, out string? player))
                Console.WriteLine($"Player with score 999: {player}");
            else
                Console.WriteLine("Score 999 not found");

            // Remove score 200
            leaderboard.Remove(200);

            Console.WriteLine("\nAfter removing score 200:");
            foreach (var entry in leaderboard)
            {
                Console.WriteLine($"Score: {entry.Key}, Player: {entry.Value}");
            }

            #endregion


        }
    }
}
