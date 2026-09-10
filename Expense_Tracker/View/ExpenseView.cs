using Expense_Tracker.Models;
using Expense_Tracker.Services;

namespace Expense_Tracker.View
{
    /// <summary>
    /// ExpenseView class is the class which does the view level activities of expense.
    /// </summary>
    internal class ExpenseView
    {
        private readonly ExpenseServices _expenseServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseView"/> class.
        /// </summary>
        /// <param name="expenseServices">ExpenseServices is the expense service instance.</param>
        public ExpenseView(ExpenseServices expenseServices)
        {
            this._expenseServices = expenseServices;
        }

        /// <summary>
        /// AddExpense method is used to get expense details from the user.
        /// </summary>
        public void AddExpense()
        {
            decimal amount = ViewHelper.GetAmount();

            if (amount <= 0)
            {
                return;
            }

            Console.WriteLine("\nCategories of Expense: ");
            foreach (var i in Enum.GetValues(typeof(ExpenseCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetCategory("Enter the type of Expense [1-7]: ");
            if (categoryData < 1 || categoryData > Enum.GetValues(typeof(ExpenseCategory)).Length)
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();
            this._expenseServices.AddExpense(amount, date, (ExpenseCategory)categoryData);
            ViewHelper.WriteColored("Expense Added Successfully.", ConsoleColor.Green);
        }

        /// <summary>
        /// DeleteExpense is used to get expense detail of the method that should be deleted.
        /// </summary>
        internal void DeleteExpense()
        {
            if (this._expenseServices.IsExpenseEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            this.ViewExpense();

            string id = ViewHelper.GetExpenseID("Expense Id", this._expenseServices);
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            if (this._expenseServices.DeleteExpense(id))
            {
                ViewHelper.WriteColored("Expense Deleted Successfully.", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored("Expense ID Not Found.", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// EditExpense method is used to get the details of expense that should be edited.
        /// </summary>
        internal void EditExpense()
        {
            if (this._expenseServices.IsExpenseEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            this.ViewExpense();

            string? id = ViewHelper.GetExpenseID("Expense Id", this._expenseServices);
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            decimal amount = ViewHelper.GetAmount();

            Console.WriteLine("\nCategories of Expense: ");
            foreach (var i in Enum.GetValues(typeof(ExpenseCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetCategory("Enter the type of expense [1-7]:");
            if (categoryData < 1 || categoryData > Enum.GetValues(typeof(ExpenseCategory)).Length)
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();
            this._expenseServices.EditExpense(id, amount, date, (ExpenseCategory)categoryData);
            ViewHelper.WriteColored("Expense is edited.", ConsoleColor.Green);
        }

        /// <summary>
        /// ViewExpense method is used to display details of the expense.
        /// </summary>
        internal void ViewExpense()
        {
            if (this._expenseServices.IsExpenseEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            List<Expense> expense = this._expenseServices.ViewExpense();
            ViewHelper.PrintExpenseTabledFormat(expense);
        }
    }
}
