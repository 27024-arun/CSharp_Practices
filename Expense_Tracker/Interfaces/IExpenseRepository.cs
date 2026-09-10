using Expense_Tracker.Models;

namespace Expense_Tracker.Interfaces
{
    /// <summary>
    /// IExpenseRepository is the interface for the method of expense categories.
    /// </summary>
    internal interface IExpenseRepository
    {
        /// <summary>
        /// AddExpense method is the blueprint for adding expense in repository.
        /// </summary>
        /// <param name="expense">Expense details of the user.</param>
        public void AddExpense(Expense expense);

        /// <summary>
        /// GetAllExpense method is the blueprint for returning all the expense from repository.
        /// </summary>
        /// <returns>Returns the list of expenses of user.</returns>
        public List<Expense> GetAllExpense();

        /// <summary>
        /// GetExpenseById method is the blueprint for returning a particular expense by using their id.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the Expense.</param>
        /// <returns>Returns a particular Expense.</returns>
        Expense? GetExpenseById(string id);

        /// <summary>
        /// UpdateExpense method is the blueprint for updating expense of the user.
        /// </summary>
        /// <param name="expense">Expense details of the user.</param>
        /// <returns>Returns whether the data is updated or not.</returns>
        public bool UpdateExpense(Expense expense);

        /// <summary>
        /// DeleteExpense method is the blueprint for deleting expense of the user.
        /// </summary>
        /// <param name="id">Id the unique identifier of the expense.</param>
        /// <returns>Returns whether the expense is deleted or not.</returns>
        public bool DeleteExpense(string id);
    }
}