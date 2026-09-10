# Expense Tracker Application

## Overview & Objectives

### Overview

The Expense Tracker Application is a console-based financial management system designed to help users track and manage their personal income and expenses. The application allows users to record multiple income sources, categorize expenses, maintain financial records during runtime, and generate summaries showing total income, total expenses, and available balance.

The application is intended for a single user and uses in-memory storage through lists and dictionaries. No database or external storage mechanism will be implemented in Version 1. The system focuses on simplicity, ease of use, and providing immediate financial visibility through a menu-driven interface.

### Objective

To develop a simple Expense Tracker Application that includes the functionality of tracking both expenses and income. This application aims to provide a user-friendly environment for individuals to manage their finances by monitoring their earnings and expenditures.

The application will:

- Allow users to record and manage income sources.
- Allow users to record and categorize expenses.
- Provide financial summaries and balance calculations.
- Support CRUD operations for income and expense records.
- Promote better financial awareness and spending control.

---

## Functional Requirements

### Income Management

- The application shall allow the user to record salary and freelancing earnings.
- Salary shall be a mandatory input before expense tracking can begin.
- Income records shall include amount, date, and category/source.
- Multiple income entries shall be supported.

### Expense Management

- The application shall allow the user to add expenses at any time.
- Each expense record shall include expense name, amount, date, and category.
- The application shall provide predefined categories such as Food, Transport, Rent, and EB Bill.
- The user shall be able to create custom categories.
- Expenses shall be classified as either Default Expenses or Additional Expenses.
- Default expenses may include Rent, EB Bill, and other recurring necessities.
- Additional expenses may include Shopping, Entertainment, Travel, and other optional expenses.
- Multiple expense entries shall be supported.

### Data Management

- The application shall be designed for a single user.
- Data shall be stored in memory using lists and/or dictionaries.
- No database or external storage shall be used.
- Each income and expense record shall have a unique identifier.
- Income IDs shall follow a format such as INC001, INC002, etc.
- Expense IDs shall follow a format such as EXP001, EXP002, etc.

### Reporting and Summary

- The application shall allow the user to view all income records.
- The application shall allow the user to view all expense records.
- The application shall display total income.
- The application shall display total expenses.
- The application shall display net balance.
- Net balance shall be calculated as Total Income minus Total Expenses.

### User Interaction

- The application shall accept user input through a console-based interface.
- The user shall be able to repeatedly add new expenses and income records during execution.
- Appropriate validation shall be performed for amount-related inputs.

---

## Non-Functional Requirements

### Usability

- The application shall provide a simple and user-friendly console interface.
- Clear prompts and messages shall be displayed for user actions.

### Performance

- The application shall provide immediate calculation of totals and balances after data updates.
- The application shall respond promptly to user actions.

### Data Handling

- Data shall be maintained only during the application runtime.
- All data shall be lost when the application is terminated.

### Maintainability

- The application shall be implemented using a modular structure to support future enhancements.

### Interface Refresh

- The console screen or menu shall be refreshed after the completion of major operations such as adding income, adding expenses, or viewing reports.

---

## Problem Statement

An Expense Tracker application is crucial because many individuals struggle to maintain a clear understanding of their personal finances despite having a steady income. While users may know how much they earn each month, they often lack visibility into where their money is spent. Expenses are typically distributed across various categories such as groceries, transportation, utilities, subscriptions, entertainment, and personal purchases. Without a structured system to track these transactions, users can easily lose control of their spending habits, leading to financial stress and difficulty in achieving savings goals.

The application plays a significant role in promoting financial discipline. When users consistently track their expenses, they become more aware of their spending behavior and are better equipped to identify unnecessary expenditures. This awareness encourages responsible financial habits, helping users stay within their budgets and allocate funds more effectively toward their priorities and long-term goals.

Another important aspect is the ability to analyze financial trends over time. By categorizing transactions and generating insights, the application helps users understand which expense categories consume the largest portion of their income and how their spending changes from month to month. These insights empower users to make proactive adjustments, improve budgeting strategies, and increase their savings potential.

---

## Technical Scope

### Text-Based Menu-Driven Interface

- Interactive user prompts for all CRUD operations.
- Clear success and error messages.

### CRUD Operations

#### Create

- Add a new record.
- Capture required fields through console input.
- Generate unique identifier automatically.

#### Read

- View all records.
- View a single record by ID.
- Display records in a readable format.

#### Update

- Update existing records using ID lookup.
- Modify one or more record attributes.

#### Delete

- Delete records using ID.
- Confirmation prompt before deletion.

### In-Memory Storage

- Store records in collections (List, Dictionary, Array, etc.).
- Data exists only during application runtime.

### Basic Validation

- Mandatory field validation.
- Numeric field validation.
- ID existence validation before update or delete.
- Prevention of empty inputs for required fields.

---

## Out of Scope (Version 1)

### User Management

- User registration.
- User authentication.
- Role-based access control.
- Password management.

### Database Integration

- Persistent database storage.

### Advanced Search and Filtering

- Filter by multiple criteria.
- Advanced financial analytics.

### Security Enhancements

- Encryption.
- Secure credential storage.
- Application authorization.

### Performance and Scalability Features

- Multi-threading.
- Caching.
- Bulk operations.

---

## Designs

### Proposed Console Menu Structure

```text
===== Expense Tracker Application =====

1. Add Income
2. View Income
3. Update Income
4. Delete Income

5. Add Expense
6. View Expense
7. Update Expense
8. Delete Expense

9. Financial Summary
10. View Records By ID

0. Exit

Enter Choice:
```

---

## Open Questions & Risks

### Open Questions

1. Should salary remain mandatory only for the first income entry or throughout application usage?
2. Should users be allowed to delete salary records after expenses have been added?
3. Should custom categories be reusable for future expense entries?
4. Should date entries be manually entered or default to the current system date?

### Risks

#### Data Loss Risk

Since all data is stored in memory, information will be lost when the application closes.

**Mitigation:** Clearly inform users that data is temporary.

#### Invalid User Inputs

Users may enter non-numeric values or incorrect formats.

**Mitigation:** Implement strong input validation and error handling.

#### Record Deletion Errors

Users may accidentally delete important records.

**Mitigation:** Require confirmation before deletion.

---

## Success Metrics

- The user is able to add, edit, remove, and list sources of income.
- The user is able to add, edit, remove, and list expenses under various categories as defined.
- The user is able to view the total expense and income for a given time period.
- The user is able to view income and expenses for a given time period.
- The user is shown appropriate messages when any application operation fails.
- Input validation prevents invalid data entry.
- Code follows the defined architecture and coding standards.
- Net balance calculations are accurate after every transaction.
- CRUD operations function successfully without data inconsistency.

---

## Assumptions

- Single-user application.
- Runs locally on a developer or user machine.
- Expected record volume is low to moderate.
- No concurrent access requirements.
- Users have basic knowledge of using a console application.
