namespace Expense_Tracker.Models
{
    /// <summary>
    /// MainMenuOptions enum is the enum which consists of options present in the main menu.
    /// </summary>
    internal enum MainMenuOptions
    {
        /// <summary>
        /// IncomeOptions is the enum value for income options assigned with value 1.
        /// </summary>
        IncomeOptions = 1,

        /// <summary>
        /// Expense is the enum value for expense options assigned with value 2.
        /// </summary>
        ExpenseOptions = 2,

        /// <summary>
        /// ShowSummary is the enum value for summary assigned with value 3.
        /// </summary>
        ShowSummary = 3,

        /// <summary>
        /// Exit is the enum value assigned with value 4.
        /// </summary>
        Exit = 4,
    }

    /// <summary>
    /// IncomeMenu is the enum which consists of options present in income menu.
    /// </summary>
    internal enum IncomeMenu
    {
        /// <summary>
        /// AddIncome is the enum value for adding income assigned with value 1.
        /// </summary>
        AddIncome = 1,

        /// <summary>
        /// ViewIncome is the enum value for viewing income assigned with value 2.
        /// </summary>
        ViewIncome = 2,

        /// <summary>
        /// EditIncome is the enum value for editing income assigned with value 3.
        /// </summary>
        EditIncome = 3,

        /// <summary>
        /// DeleteIncome is the enum value for deleting income assigned with value 4.
        /// </summary>
        DeleteIncome = 4,

        /// <summary>
        /// ReturnToMainMenu is the enum value for return option assigned with value 5.
        /// </summary>
        ReturnToMainMenu = 5,
    }

    /// <summary>
    /// ExpenseMenu is the enum which consists of options present in the expense menu.
    /// </summary>
    internal enum ExpenseMenu
    {
        /// <summary>
        /// AddExpense is the enum value for adding expense assigned with value 1.
        /// </summary>
        AddExpense = 1,

        /// <summary>
        /// ViewExpense is the enum value for viewing expense assigned with value 2.
        /// </summary>
        ViewExpense = 2,

        /// <summary>
        /// EditExpense is the enum value for editing expense assigned with value 3.
        /// </summary>
        EditExpense = 3,

        /// <summary>
        /// DeleteExpense is the enum value for deleting expense assigned with value 4.
        /// </summary>
        DeleteExpense = 4,

        /// <summary>
        /// ReturnToMainMenu is the enum value for return option assigned with value 5.
        /// </summary>
        ReturnToMainMenu = 5,
    }
}