using ConsoleTables;
using Expense_Tracker.Models;
using Expense_Tracker.Services;

namespace Expense_Tracker.View
{
    /// <summary>
    /// ViewHelper class is the class where view level helper methods are declared.
    /// </summary>
    public class ViewHelper
    {
        /// <summary>
        /// WriteColored method is used to display message in colored format.
        /// </summary>
        /// <param name="message">Message is the data which should need to be displayed.</param>
        /// <param name="color">Colors is the particular color in which the message needs to be displayed.</param>
        public static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// ExpenseOptions method is used to display the expense menu options to user.
        /// </summary>
        /// <param name="expenseView">View is the ExpenseView class instance.</param>
        internal static void ExpenseOptions(ExpenseView expenseView)
        {
            Console.Clear();
            while (true)
            {
                string expenseMenu = $@"
Expense Options

1. Add Expense
2. View Expense
3. Edit Expense
4. Delete Expense
5. Return to Main menu
Enter Choice: ";
                Console.Write(expenseMenu);
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case (int)ExpenseMenu.AddExpense:
                        expenseView.AddExpense();
                        break;
                    case (int)ExpenseMenu.ViewExpense:
                        expenseView.ViewExpense();
                        break;
                    case (int)ExpenseMenu.EditExpense:
                        expenseView.EditExpense();
                        break;
                    case (int)ExpenseMenu.DeleteExpense:
                        expenseView.DeleteExpense();
                        break;
                    case (int)ExpenseMenu.ReturnToMainMenu:
                        Console.Clear();
                        return;
                    default:
                        ViewHelper.WriteColored("Invalid Choice", ConsoleColor.Red);
                        break;
                }
            }
        }

        /// <summary>
        /// IncomeOptions method is used to display the income menu options to the user.
        /// </summary>
        /// <param name="incomeView">View is the IncomeView class instance.</param>
        internal static void IncomeOptions(IncomeView incomeView)
        {
            Console.Clear();
            while (true)
            {
                string incomeMenu = $@"
Income Options

1. Add Income
2. View Income
3. Edit Income
4. Delete Income
5. Return to Main menu
Enter Choice: ";
                Console.Write(incomeMenu);
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case (int)IncomeMenu.AddIncome:
                        incomeView.AddIncome();
                        break;
                    case (int)IncomeMenu.ViewIncome:
                        incomeView.ViewIncome();
                        break;
                    case (int)IncomeMenu.EditIncome:
                        incomeView.EditIncome();
                        break;
                    case (int)IncomeMenu.DeleteIncome:
                        incomeView.DeleteIncome();
                        break;
                    case (int)IncomeMenu.ReturnToMainMenu:
                        Console.Clear();
                        return;
                    default:
                        ViewHelper.WriteColored("Invalid Choice", ConsoleColor.Red);
                        break;
                }
            }
        }

        /// <summary>
        /// ParintExpenseTabledFormat method is used to display list of expenses in tabled format.
        /// </summary>
        /// <param name="expenses">Expenses of the user.</param>
        internal static void PrintExpenseTabledFormat(List<Expense> expenses)
        {
            var table = new ConsoleTable("Id", "Expense Amount", "Date", "Category");
            foreach (Expense expense in expenses)
            {
                table.AddRow(expense.Id, expense.Amount, expense.Date, expense.Category);
            }

            table.Write(Format.Alternative);
        }

        /// <summary>
        /// PrtintIncomeTabledFormat method is used to display list of incomes in tabled format.
        /// </summary>
        /// <param name="incomes">Incomes of the user.</param>
        internal static void PrintIncomeTabledFormat(List<Income> incomes)
        {
            var table = new ConsoleTable("Id", "Income Amount", "Date", "Category");
            foreach (Income income in incomes)
            {
                table.AddRow(income.Id, income.Amount, income.Date, income.Category);
            }

            table.Write(Format.Alternative);
        }

        /// <summary>
        /// GetAmount method is use to get amount data from the user.
        /// </summary>
        /// <returns>Returns the amount data.</returns>
        internal static decimal GetAmount()
        {
            int tries = 3;
            string? input;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"Amount: ");
                input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal data) && data > 0)
                {
                    return data;
                }
                else
                {
                    WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
                }
            }

            WriteColored("Returning to main menu", ConsoleColor.Yellow);
            return 0;
        }

        /// <summary>
        /// GetCategoy method is used to get the category of transaction from the user.
        /// </summary>
        /// <param name="message">Message is the message displayed to the user.</param>
        /// <returns>Returns the category of transaction.</returns>
        internal static int GetCategory(string message)
        {
            int tries = 3;
            string? input;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{message}");
                input = Console.ReadLine();
                if (int.TryParse(input, out int data) && data >= 1 && data <= 7)
                {
                    return data;
                }
                else
                {
                    WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
                }
            }

            WriteColored("Returning to main menu", ConsoleColor.Yellow);
            return 0;
        }

        /// <summary>
        /// GetExpenseID method is used to get the Expense Id from the user.
        /// </summary>
        /// <param name="variableName">VariableName is the variable for which the data is allocated.</param>
        /// <param name="services">Services is the FinanceServices instance.</param>
        /// <returns>Returns the expense id.</returns>
        internal static string GetExpenseID(string variableName, ExpenseServices services)
        {
            int tries = 3;
            string? data;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{variableName}: ");
                data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data) && services.IsExpenseIdValid(data))
                {
                    return data;
                }
                else
                {
                    WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
                }
            }

            WriteColored("Returning to main menu", ConsoleColor.Yellow);
            return string.Empty;
        }

        /// <summary>
        /// GetIncomeId method is used to get the Income Id from the user.
        /// </summary>
        /// <param name="variableName">VariableName is the variable for which the data is allocated.</param>
        /// <param name="services">Services is the FinanceServices instance.</param>
        /// <returns>Returns the income id.</returns>
        internal static string GetIncomeID(string variableName, IncomeServices services)
        {
            int tries = 3;
            string? data;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{variableName}: ");
                data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data) && services.IsIncomeIdValid(data))
                {
                    return data;
                }
                else
                {
                    WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
                }
            }

            WriteColored("Returning to main menu", ConsoleColor.Yellow);
            return string.Empty;
        }

        /// <summary>
        /// GetDate method is used to get the date from the user.
        /// </summary>
        /// <returns>Returns the date.</returns>
        internal static DateOnly GetDate()
        {
            int tries = 3;
            string? input;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"\nDate (DD/MM/YYYY): ");
                input = Console.ReadLine();
                if (DateOnly.TryParse(input, out DateOnly date) && date <= DateOnly.FromDateTime(DateTime.Now))
                {
                    return date;
                }
                else
                {
                    WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
                }
            }

            WriteColored("Entered date is not valid, today's date is set as default", ConsoleColor.Yellow);
            return DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
