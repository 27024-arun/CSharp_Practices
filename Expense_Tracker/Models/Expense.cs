namespace Expense_Tracker.Models
{
    /// <summary>
    /// Expense class is the class which consists of property of expenses.
    /// </summary>
    internal class Expense : TransactionModel
    {
        /// <summary>
        /// Gets or sets the expense category.
        /// </summary>
        /// <value>The expense category.</value>
        public ExpenseCategory Category { get; set; }
    }
}