using Expense_Tracker.Repository;
using Expense_Tracker.Services;

namespace Expense_Tracker.View
{
    /// <summary>
    /// SummaryView class is used to do the console level activities of summary.
    /// </summary>
    internal class SummaryView
    {
        private readonly SummaryServices _summaryServices;

        public SummaryView(SummaryServices summaryServices)
        {
            this._summaryServices = summaryServices;
        }

        /// <summary>
        /// ShowSummary method is used to display the summary details to the user.
        /// </summary>
        /// <param name="incomeRepository">IncomeRepository is the instance of incomeRepository.</param>
        /// <param name="expenseRepository">ExpenseRepository is the instance of expenseRepository.</param>
        internal void ShowSummary()
        {
            decimal income = this._summaryServices.GetTotalIncome();
            decimal expense = this._summaryServices.GetTotalExpense();
            decimal balance = this._summaryServices.CalculateBalance();
            Console.WriteLine($"\nTotal Income  : {income}\nTotal Expense : {expense}\nBalance       : {balance}");
        }
    }
}
