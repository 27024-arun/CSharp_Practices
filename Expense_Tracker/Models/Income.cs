namespace Expense_Tracker.Models
{
    /// <summary>
    /// Income class is the class which consists of property of income.
    /// </summary>
    internal class Income : TransactionModel
    {
        /// <summary>
        /// Gets or sets the income category.
        /// </summary>
        /// <value>The income category.</value>
        public IncomeCategory Category { get; set; }
    }
}