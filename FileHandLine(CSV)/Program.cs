using System.Text;

class FileHandling
{
    private const string FilePath = "data.csv";

    static void Main()
    {
        EnsureFileExists();

        while (true)
        {
            Console.WriteLine("\n=== CSV File Menu ===");
            Console.WriteLine("1. Add Record");
            Console.WriteLine("2. Edit Record by ID");
            Console.WriteLine("3. Delete Record by ID");
            Console.WriteLine("4. Display Record by ID");
            Console.WriteLine("5. Display All Records");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()?.Trim();
            switch (choice)
            {
                case "1": AddRecord(); break;
                case "2": EditRecord(); break;
                case "3": DeleteRecord(); break;
                case "4": DisplayRecordById(); break;
                case "5": DisplayAllRecords(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }

    // Ensure CSV file exists with header
    private static void EnsureFileExists()
    {
        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "ID,Name,Age\n", Encoding.UTF8);
        }
    }

    // Escape CSV fields
    private static string EscapeCsv(string field)
    {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            field = field.Replace("\"", "\"\"");
            return $"\"{field}\"";
        }
        return field;
    }

    // Read all records from CSV (excluding header)
    private static List<string[]> ReadAllRecords()
    {
        return File.ReadAllLines(FilePath)
                   .Skip(1) // skip header
                   .Where(line => !string.IsNullOrWhiteSpace(line))
                   .Select(line => ParseCsvLine(line))
                   .ToList();
    }

    // Parse CSV line into fields (basic handling)
    private static string[] ParseCsvLine(string line)
    {
        var fields = new List<string>();
        bool inQuotes = false;
        StringBuilder field = new StringBuilder();

        foreach (char c in line)
        {
            if (c == '"' && !inQuotes)
            {
                inQuotes = true;
            }
            else if (c == '"' && inQuotes)
            {
                inQuotes = false;
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(field.ToString());
                field.Clear();
            }
            else
            {
                field.Append(c);
            }
        }
        fields.Add(field.ToString());
        return fields.ToArray();
    }

    // Write all records back to CSV
    private static void WriteAllRecords(List<string[]> records)
    {
        var lines = new List<string> { "ID,Name,Age" };
        lines.AddRange(records.Select(r => $"{r[0]},{EscapeCsv(r[1])},{r[2]}"));
        File.WriteAllLines(FilePath, lines, Encoding.UTF8);
    }

    // Add a new record
    private static void AddRecord()
    {
        Console.Write("Enter ID (integer): ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var records = ReadAllRecords();
        if (records.Any(r => r[0] == id.ToString()))
        {
            Console.WriteLine("ID already exists.");
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
            Console.WriteLine("Invalid Age.");
            return;
        }

        records.Add(new string[] { id.ToString(), name, age.ToString() });
        WriteAllRecords(records);
        Console.WriteLine("Record added successfully.");
    }

    // Edit a record by ID
    private static void EditRecord()
    {
        Console.Write("Enter ID to edit: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var records = ReadAllRecords();
        var record = records.FirstOrDefault(r => r[0] == id.ToString());
        if (record == null)
        {
            Console.WriteLine("Record not found.");
            return;
        }

        Console.Write($"Enter new Name (current: {record[1]}): ");
        string name = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(name))
        {
            record[1] = name;
        }

        Console.Write($"Enter new Age (current: {record[2]}): ");
        string ageInput = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(ageInput) && int.TryParse(ageInput, out int age) && age >= 0)
        {
            record[2] = age.ToString();
        }

        WriteAllRecords(records);
        Console.WriteLine("Record updated successfully.");
    }

    // Delete a record by ID
    private static void DeleteRecord()
    {
        Console.Write("Enter ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var records = ReadAllRecords();
        int removed = records.RemoveAll(r => r[0] == id.ToString());

        if (removed > 0)
        {
            WriteAllRecords(records);
            Console.WriteLine("Record deleted successfully.");
        }
        else
        {
            Console.WriteLine("Record not found.");
        }
    }

    // Display a record by ID
    private static void DisplayRecordById()
    {
        Console.Write("Enter ID to display: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var record = ReadAllRecords().FirstOrDefault(r => r[0] == id.ToString());
        if (record != null)
        {
            Console.WriteLine($"ID: {record[0]}, Name: {record[1]}, Age: {record[2]}");
        }
        else
        {
            Console.WriteLine("Record not found.");
        }
    }

    // Display all records
    private static void DisplayAllRecords()
    {
        var records = ReadAllRecords();
        if (records.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        Console.WriteLine("\nID\tName\tAge");
        Console.WriteLine("----------------------");
        foreach (var r in records)
        {
            Console.WriteLine($"{r[0]}\t{r[1]}\t{r[2]}");
        }
    }
}
