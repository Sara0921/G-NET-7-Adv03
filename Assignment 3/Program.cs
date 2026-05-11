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
            #region Exercise 03

            // Create phone book
            Dictionary<string, string> phoneBook = new()
            {
                {"Ahmed", "01012345678"},
                {"Sara", "01198765432"},
                {"Ali", "01255555555"},
                {"Mona", "01544444444"}
            };


            // Add or update using []
            phoneBook["Omar"] = "01000000000";   // Add
            phoneBook["Ahmed"] = "01099999999"; // Update

            Console.WriteLine("After [] add/update:");
            Print(phoneBook);

            try
            {
                phoneBook.Add("Sara", "00000000000"); // duplicate key
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError using Add(): {ex.Message}");
            }

            // Try adding duplicate using TryAdd()
            bool added = phoneBook.TryAdd("Ali", "00000000000");
            Console.WriteLine($"\nTryAdd for 'Ali' succeeded? {added}");

            // Search for a contact that doesn't exist
            string searchName = "Youssef";
            if (!phoneBook.ContainsKey(searchName))
            {
                Console.WriteLine($"\n{searchName} not found");
            }

            // Get contact with fallback
            string result = phoneBook.TryGetValue(searchName, out string? phone)
                ? phone : "Not Found";

            Console.WriteLine($"Result for {searchName}: {result}");

            // Print all keys in one line
            Console.WriteLine("\nAll Names:");
            Console.WriteLine(string.Join(", ", phoneBook.Keys));

            // Print all values in one line
            Console.WriteLine("\nAll Phone Numbers:");
            Console.WriteLine(string.Join(", ", phoneBook.Values));
        }

        static void Print(Dictionary<string, string> phoneBook)
        {
            foreach (var entry in phoneBook)
                Console.WriteLine($"{entry.Key} → {entry.Value}");

            #endregion
            #region Exercise 04

            // Case-insensitive email set
            HashSet<string> emails = new(StringComparer.OrdinalIgnoreCase)
            {
                "ahmed@test.com",
                "AHMED@test.com",
                "sara@test.com",
                "Sara@Test.Com"
            };

            // Print count
            Console.WriteLine($"Email Count: {emails.Count}");

            Console.WriteLine("Stored Emails:");
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }

            // Explanation
            Console.WriteLine("\nExplanation:");
            Console.WriteLine("HashSet ignores duplicates. Case-insensitive comparer treats emails as the same.");

            // Sets A and B
            HashSet<int> setA = [1, 2, 3, 4, 5];
            HashSet<int> setB = [4, 5, 6, 7, 8];

            // Union
            var union = new HashSet<int>(setA);
            union.UnionWith(setB);
            Console.WriteLine("\nUnion:");
            Print(union);

            // Intersection
            HashSet<int>? intersect = [.. setA];
            intersect.IntersectWith(setB);
            Console.WriteLine("\nIntersection:");
            Print(intersect);

            // Except
            HashSet<int>? except = [.. setA];
            except.ExceptWith(setB);
            Console.WriteLine("\nExcept (A - B):");
            Print(except);

            // Subset check
            HashSet<int> smallSet = [1, 2];
            bool isSubset = smallSet.IsSubsetOf(setA);
            Console.WriteLine($"\nIs {{1,2}} subset of A? {isSubset}");

            #endregion
            #region Exercise 05

            // Create queue
            Queue<string> printQueue = new();

            // Enqueue documents
            printQueue.Enqueue("Report.pdf");
            printQueue.Enqueue("Invoice.pdf");
            printQueue.Enqueue("Letter.docx");
            printQueue.Enqueue("Resume.pdf");
            printQueue.Enqueue("Photo.jpg");

            // Print queue contents
            Console.WriteLine("Queue Contents:");
            Console.WriteLine(string.Join(", ", printQueue));

            Console.WriteLine($"Count: {printQueue.Count}");

            // Peek (next document)
            Console.WriteLine($"\nNext to print (Peek): {printQueue.Peek()}");

            // Process queue
            Console.WriteLine("\nProcessing Queue:");
            while (printQueue.Count > 0)
            {
                string doc = printQueue.Dequeue();
                Console.WriteLine($"Printing: {doc}");
            }

            // TryDequeue on empty queue
            Console.WriteLine("\nTrying TryDequeue on empty queue:");
            bool success = printQueue.TryDequeue(out string? result);

            Console.WriteLine($"Success? {success}");
            Console.WriteLine($"Result: {result ?? "null"}");

            // TryDequeue behaviour on Empty Queue
            // Queue is empty → nothing to remove
            // TryDequeue() returns false instead of crashing and result becomes null

            #endregion


        }
    }
}
