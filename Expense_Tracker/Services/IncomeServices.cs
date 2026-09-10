using Expense_Tracker.Models;
using Expense_Tracker.Repository;

namespace Expense_Tracker.Services
{
    /// <summary>
    /// IncomeServices class is used to handle income business logic of the application.
    /// </summary>
    internal class IncomeServices
    {
        private static int _incomeId = 100;
        private readonly IncomeRepository _incomeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeServices"/> class.
        /// </summary>
        /// <param name="incomeRepository">IncomeRepository is the income repository instance.</param>
        public IncomeServices(IncomeRepository incomeRepository)
        {
            this._incomeRepository = incomeRepository;
        }

        /// <summary>
        /// AddIncome method is used to assign user given details to income model.
        /// </summary>
        /// <param name="amount">Amount of Income.</param>
        /// <param name="date">Date of Income.</param>
        /// <param name="category">Category of Income.</param>
        internal void AddIncome(decimal amount, DateOnly date, IncomeCategory category)
        {
            Income income = new ()
            {
                Id = (_incomeId++).ToString(),
                Amount = amount,
                Date = date,
                Category = category,
            };

            this._incomeRepository.AddIncome(income);
        }

        /// <summary>
        /// ViewIncome method is used to return list of income to view level.
        /// </summary>
        /// <returns>Returns list of income.</returns>
        internal List<Income> ViewIncome()
        {
            return this._incomeRepository.GetAllIncome();
        }

        /// <summary>
        /// EditIncome method is used to validate income details and assign new income details to existing income.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <param name="amount">Amount is the amount of income.</param>
        /// <param name="date">Date is the date of income.</param>
        /// <param name="category">Category is the income category.</param>
        /// <returns>Returns whether the income is edited or not.</returns>
        internal bool EditIncome(string id, decimal amount, DateOnly date, IncomeCategory category)
        {
            List<Income> incomes = this.ViewIncome();
            if (incomes.Count == 0)
            {
                Console.WriteLine("No income records found.");
                return false;
            }

            Income newIncome = new ()
            {
                Id = id,
                Amount = amount,
                Date = date,
                Category = category,
            };
            this._incomeRepository.UpdateIncome(newIncome);
            return true;
        }

        /// <summary>
        /// DeleteIncome method is used to pass the id of the income to repository for deletion.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns whether the income is deleted or not.</returns>
        internal bool DeleteIncome(string id)
        {
            return this._incomeRepository.DeleteIncome(id);
        }

        /// <summary>
        /// IsIncomeEmpty method is used to pass the detail whether the income is empty or not.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsIncomeEmpty()
        {
            return this._incomeRepository.IsIncomeEmpty();
        }

        /// <summary>
        /// GetTotalIncome method is used to get the total of income.
        /// </summary>
        /// <returns>Returns the income total.</returns>
        internal decimal GetTotalIncome()
        {
            return this._incomeRepository.GetTotalIncome();
        }

        /// <summary>
        /// IsIncomeIdValid method is used to check whether income id exists or not.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns whether the income exists or not.</returns>
        internal bool IsIncomeIdValid(string id)
        {
            return this._incomeRepository.IsIncomeExists(id);
        }
    }
}
