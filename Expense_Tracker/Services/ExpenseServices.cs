using Expense_Tracker.Models;
using Expense_Tracker.Repository;

namespace Expense_Tracker.Services
{
    /// <summary>
    /// ExpenseServices class is used handle the expense business logic of the application.
    /// </summary>
    internal class ExpenseServices
    {
        private static int _expenseId = 200;

        private readonly ExpenseRepository _expenseRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseServices"/> class.
        /// </summary>
        /// <param name="expenseRepository">ExpenseRepository instance.</param>
        public ExpenseServices(ExpenseRepository expenseRepository)
        {
            this._expenseRepository = expenseRepository;
        }

        /// <summary>
        /// AddExpense method is used to assign user given details to expense model.
        /// </summary>
        /// <param name="amount">Amount of expense.</param>
        /// <param name="date">Date of expense.</param>
        /// <param name="category">Category of expense.</param>
        internal void AddExpense(decimal amount, DateOnly date, ExpenseCategory category)
        {
            Expense expense = new ()
            {
                Id = (_expenseId++).ToString(),
                Amount = amount,
                Date = date,
                Category = category,
            };

            this._expenseRepository.AddExpense(expense);
        }

        /// <summary>
        /// ViewExpense method is used to return list of expense to view level.
        /// </summary>
        /// <returns>Returns list of expense.</returns>
        internal List<Expense> ViewExpense()
        {
            return this._expenseRepository.GetAllExpense();
        }

        /// <summary>
        /// EditExpense method is used to validate expense details and assign new expense details to existing expense.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <param name="amount">Amount is the expense amount.</param>
        /// <param name="date">Date is the date of expense.</param>
        /// <param name="category">Category is the expense category.</param>
        /// <returns>Returns whether the expense is updated or not.</returns>
        internal bool EditExpense(string id, decimal amount, DateOnly date, ExpenseCategory category)
        {
            List<Expense> expenses = this.ViewExpense();
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expense records found.");
                return false;
            }

            Expense expense = new ()
            {
                Id = id,
                Amount = amount,
                Date = date,
                Category = category,
            };

            return this._expenseRepository.UpdateExpense(expense);
        }

        /// <summary>
        /// DeleteExpense method is used to pass the id of the expense to repository for deletion.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns whether the expense is deleted or not.</returns>
        internal bool DeleteExpense(string id)
        {
            return this._expenseRepository.DeleteExpense(id);
        }

        /// <summary>
        /// IsExpenseEmpty method is used to pass the detail whether the expense is empty or not.
        /// </summary>
        /// <returns>Returns whether the expense is empty or not.</returns>
        internal bool IsExpenseEmpty()
        {
            return this._expenseRepository.IsExpenseEmpty();
        }

        /// <summary>
        /// GetTotalExpense method is used to get the total of expense.
        /// </summary>
        /// <returns>Returns the expense total.</returns>
        internal decimal GetTotalExpense()
        {
            return this._expenseRepository.GetTotalExpense();
        }

        /// <summary>
        /// IsExpenseIdValid method is used to check whether expense id exists or not.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns whether the expense exists or not.</returns>
        internal bool IsExpenseIdValid(string id)
        {
            return this._expenseRepository.IsExpenseExists(id);
        }
    }
}
