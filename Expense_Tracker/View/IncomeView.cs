using Expense_Tracker.Models;
using Expense_Tracker.Services;

namespace Expense_Tracker.View
{
    /// <summary>
    /// IncomeView class is the class which consists of view level activities of income.
    /// </summary>
    internal class IncomeView
    {
        private readonly IncomeServices _incomeServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeView"/> class.
        /// </summary>
        /// <param name="incomeServices">IncomeServices is the service instance.</param>
        public IncomeView(IncomeServices incomeServices)
        {
            this._incomeServices = incomeServices;
        }

        /// <summary>
        /// AddIncome method is used to get income details from the user.
        /// </summary>
        internal void AddIncome()
        {
            decimal amount = ViewHelper.GetAmount();

            if (amount <= 0)
            {
                return;
            }

            Console.WriteLine("\nCategories of Income: ");
            foreach (var i in Enum.GetValues(typeof(IncomeCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetCategory("Enter the type of Income [1-7]: ");
            if (categoryData < 1 || categoryData > Enum.GetValues(typeof(IncomeCategory)).Length)
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();
            this._incomeServices.AddIncome(amount, date, (IncomeCategory)categoryData);
            ViewHelper.WriteColored("Income Added Successfully.", ConsoleColor.Green);
        }

        /// <summary>
        /// DeleteExpense is used to get income detail of the method that should be deleted.
        /// </summary>
        internal void DeleteIncome()
        {
            if (this._incomeServices.IsIncomeEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            this.ViewIncome();

            string id = ViewHelper.GetIncomeID("Income Id", this._incomeServices);

            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            if (this._incomeServices.DeleteIncome(id))
            {
                ViewHelper.WriteColored("Income Deleted Successfully.", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored("Income ID Not Found.", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// EditIncome method is used to get details of the income that should be edited.
        /// </summary>
        internal void EditIncome()
        {
            if (this._incomeServices.IsIncomeEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            this.ViewIncome();

            string? id = ViewHelper.GetIncomeID("Income Id", this._incomeServices);
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            decimal amount = ViewHelper.GetAmount();

            Console.WriteLine("\nCategories of Income: ");
            foreach (var i in Enum.GetValues(typeof(IncomeCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetCategory("Enter the type of Income[1 - 7]:");
            if (categoryData < 1 || categoryData > Enum.GetValues(typeof(IncomeCategory)).Length)
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();
            this._incomeServices.EditIncome(id, amount, date, (IncomeCategory)categoryData);
            ViewHelper.WriteColored("Income is edited.", ConsoleColor.Green);
        }

        /// <summary>
        /// ViewIncome method is used to display details of the income.
        /// </summary>
        internal void ViewIncome()
        {
            if (this._incomeServices.IsIncomeEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            List<Income> income = this._incomeServices.ViewIncome();
            ViewHelper.PrintIncomeTabledFormat(income);
        }
    }
}
