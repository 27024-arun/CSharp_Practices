using Expense_Tracker.Models;

namespace Expense_Tracker.Interfaces
{
    /// <summary>
    /// IIncomeRepository is the interface for the method of income categories.
    /// </summary>
    internal interface IIncomeRepository
    {
        /// <summary>
        /// AddIncome method is the blueprint for adding income in repository.
        /// </summary>
        /// <param name="income">Income details of the user.</param>
        public void AddIncome(Income income);

        /// <summary>
        /// GetAllIncome method is the blueprint for returning all the income from repository.
        /// </summary>
        /// <returns>Returns the list of incomes of user.</returns>
        public List<Income> GetAllIncome();

        /// <summary>
        /// GetIncomeById method is the blueprint for returning a particular income by using their id.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the Income.</param>
        /// <returns>Returns a particular Income.</returns>
        Income? GetIncomeById(string id);

        /// <summary>
        /// UpdateIncome method is the blueprint for updating income of the user.
        /// </summary>
        /// <param name="income">Income details of the user.</param>
        /// <returns>Returns whether the data is updated or not.</returns>
        public bool UpdateIncome(Income income);

        /// <summary>
        /// DeleteIncome method is the blueprint for deleting income of the user.
        /// </summary>
        /// <param name="id">Id the unique identifier of the income.</param>
        /// <returns>Returns whether the income is deleted or not.</returns>
        public bool DeleteIncome(string id);
    }
}