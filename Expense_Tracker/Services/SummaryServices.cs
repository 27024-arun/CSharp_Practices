using Expense_Tracker.Interfaces;
using Expense_Tracker.Repository;

namespace Expense_Tracker.Services
{
    /// <summary>
    /// SummaryServices class is used to do the business logics of the summary.
    /// </summary>
    internal class SummaryServices
    {
        private readonly IncomeRepository _incomeRepository;
        private readonly ExpenseRepository _expenseRepository;

        public SummaryServices(IncomeRepository incomeRepository, ExpenseRepository expenseRepository)
        {
            this._incomeRepository = incomeRepository;
            this._expenseRepository = expenseRepository;
        }

        /// <summary>
        /// CalculateBalance method is used to calculate total balance of user.
        /// </summary>
        /// <param name="incomeRepository">IncomeRepository is the income repository instance.</param>
        /// <param name="expenseRepository">ExpenseRepository is the expense repository instance.</param>
        /// <returns>Returns the balance.</returns>
        internal decimal CalculateBalance()
        {
            return this.GetTotalIncome() - this.GetTotalExpense();
        }

        /// <summary>
        /// GetTotalExpense is used to get the total expense from repository.
        /// </summary>
        /// <param name="expenseRepository">ExpenseRepository is the expense repository instance.</param>
        /// <returns>Returns the total expense.</returns>
        internal decimal GetTotalExpense()
        {
            return this._expenseRepository.GetTotalExpense();
        }

        /// <summary>
        /// GetTotalIncome is used to get the total income from repository.
        /// </summary>
        /// <param name="incomeRepository">IncomeRepository is the income repository instance.</param>
        /// <returns>Returns the expense total.</returns>
        internal decimal GetTotalIncome()
        {
            return this._incomeRepository.GetTotalIncome();
        }
    }
}
