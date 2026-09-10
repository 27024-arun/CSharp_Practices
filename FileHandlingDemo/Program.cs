using System.Text;

namespace FileHandlingDemo
{
    internal class Program
    {
        private const string FilePath = "data.csv";

        static void Main()
        {
            try
            {
                Console.WriteLine("=== CSV File Writer ===");

                // Ensure file exists and has a header
                if (!File.Exists(FilePath))
                {
                    File.WriteAllText(FilePath, "ID,Name,Age\n", Encoding.UTF8);
                    Console.WriteLine("CSV file created with header.");
                }

                // Get user input
                Console.Write("Enter ID (integer): ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Must be an integer.");
                    return;
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    return;
                }

                Console.Write("Enter Age (integer): ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
                {
                    Console.WriteLine("Invalid Age. Must be a non-negative integer.");
                    return;
                }

                // Append data to CSV
                string csvLine = $"{id},{EscapeCsv(name)},{age}";
                File.AppendAllText(FilePath, csvLine + Environment.NewLine, Encoding.UTF8);

                Console.WriteLine("Data successfully written to CSV file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Escapes commas and quotes in CSV fields
        private static string EscapeCsv(string field)
        {
            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                field = field.Replace("\"", "\"\"");
                return $"\"{field}\"";
            }
            return field;
        }
    }
}