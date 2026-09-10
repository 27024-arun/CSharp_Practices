using Expense_Tracker.Interfaces;
using Expense_Tracker.Models;

namespace Expense_Tracker.Repository
{
    /// <summary>
    /// ExpenseRepository class is the class where storage of expense data is defined.
    /// </summary>
    internal class ExpenseRepository : IExpenseRepository
    {
        private readonly List<Expense> _expenses = new ();

        /// <summary>
        /// AddExpense method is used to add expense to the repository.
        /// </summary>
        /// <param name="expense">Expense is the details of expense.</param>
        public void AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
        }

        /// <summary>
        /// GetAllExpense method is used to retrieve list of expense from repository.
        /// </summary>
        /// <returns>Returns the list of expense in repository.</returns>
        public List<Expense> GetAllExpense()
        {
            return this._expenses;
        }

        /// <summary>
        /// GetExpenseById method is used to retrieve a particular expense from repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns the expense from repository.</returns>
        public Expense? GetExpenseById(string id)
        {
            return this._expenses.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// UpdateExpense method is used to update the expense details in the repository.
        /// </summary>
        /// <param name="expense">Expense is the expense details.</param>
        /// <returns>Returns whether the expense is updated or not.</returns>
        public bool UpdateExpense(Expense expense)
        {
            Expense? existing = this.GetExpenseById(expense.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Amount = expense.Amount;
            existing.Date = expense.Date;
            existing.Category = expense.Category;

            return true;
        }

        /// <summary>
        /// DeleteExpense method is used to delete a particular expense in the repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns whether the expense is deleted or not.</returns>
        public bool DeleteExpense(string id)
        {
            Expense? expense = this.GetExpenseById(id);

            if (expense == null)
            {
                return false;
            }

            this._expenses.Remove(expense);
            return true;
        }

        /// <summary>
        /// IsExpenseEmpty method is used to check whether the expense is empty.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsExpenseEmpty()
        {
            return this._expenses.Count == 0;
        }

        /// <summary>
        /// GetTotalExpense method is used get the expense total.
        /// </summary>
        /// <returns>Returns the expense total.</returns>
        internal decimal GetTotalExpense()
        {
            return this._expenses.Sum(e => e.Amount);
        }

        /// <summary>
        /// IsExpenseExists method is used to check whether the expense already exists in repository or not.
        /// </summary>
        /// <param name="id">Id is the unqiue identifier of the expense.</param>
        /// <returns>Returns whether the expense exists or not.</returns>
        internal bool IsExpenseExists(string id)
        {
            return this._expenses.Any(e => e.Id == id);
        }
    }
}
