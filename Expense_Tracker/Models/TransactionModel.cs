namespace Expense_Tracker.Models
{
    /// <summary>
    /// TransactionModel is the abstract class whether the properties and field of transaction is declared.
    /// </summary>
    internal abstract class TransactionModel
    {
        /// <summary>
        /// Gets or Sets the Id of the transaction.
        /// </summary>
        /// <value>Id is the unique identifier for the transaction.</value>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the amount of the transaction.
        /// </summary>
        /// <value>Amount is the transaction amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or Sets the Date of the transaction.
        /// </summary>
        /// <value>Date is the date of transaction..</value>
        public DateOnly Date { get; set; }
    }
}
