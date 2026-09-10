using Expense_Tracker.Interfaces;
using Expense_Tracker.Models;

namespace Expense_Tracker.Repository
{
    /// <summary>
    /// IncomeRepository class is the class where storage of income data is defined.
    /// </summary>
    internal class IncomeRepository : IIncomeRepository
    {
        private readonly List<Income> _incomes = new ();

        /// <summary>
        /// AddIncome method is used to add income to the repository.
        /// </summary>
        /// <param name="income">Income is the details of income.</param>
        public void AddIncome(Income income)
        {
            this._incomes.Add(income);
        }

        /// <summary>
        /// GetAllIncome method is used to retrieve list of incomes from repository.
        /// </summary>
        /// <returns>Returns the list of income in repository.</returns>
        public List<Income> GetAllIncome()
        {
            return this._incomes;
        }

        /// <summary>
        /// GetIncomeById method is used to retrieve a particular income from repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns the income from repository.</returns>
        public Income? GetIncomeById(string id)
        {
            return this._incomes.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// UpdateIncome method is used update income details in the repository.
        /// </summary>
        /// <param name="income">Income is the income details.</param>
        /// <returns>Returns whether the income is updated or not.</returns>
        public bool UpdateIncome(Income income)
        {
            Income? existing = this.GetIncomeById(income.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Amount = income.Amount;
            existing.Date = income.Date;
            existing.Category = income.Category;

            return true;
        }

        /// <summary>
        /// DeleteIncome method is used to delete a particular income in the repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns whether the income is deleted or not.</returns>
        public bool DeleteIncome(string id)
        {
            Income? income = this.GetIncomeById(id);

            if (income == null)
            {
                return false;
            }

            this._incomes.Remove(income);
            return true;
        }

        /// <summary>
        /// IsIncomeEmpty method is used to check whether the income is empty.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsIncomeEmpty()
        {
            return this._incomes.Count == 0;
        }

        /// <summary>
        /// GetTotalIncome method is used get the income total.
        /// </summary>
        /// <returns>Returns the income total.</returns>
        internal decimal GetTotalIncome()
        {
            return this._incomes.Sum(i => i.Amount);
        }

        /// <summary>
        /// IsIncomeExists method is used to check whether the income already exists in repository or not.
        /// </summary>
        /// <param name="id">Id is the unqiue identifier of the income.</param>
        /// <returns>Returns whether the income exists or not.</returns>
        internal bool IsIncomeExists(string id)
        {
            return this._incomes.Any(e => e.Id == id);
        }
    }
}
