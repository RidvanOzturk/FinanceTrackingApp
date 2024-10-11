# Finance Tracking Application

Finance Tracking Application is a comprehensive tool designed to help users manage their personal finances effectively. Built with **ASP.NET MVC**, **Entity Framework (EF)** as the ORM tool, this application allows users to track their income and expenses by category, offering powerful features like visual data representation and detailed reporting.


https://github.com/user-attachments/assets/ecee1a10-8f87-4c0b-9dca-991d9c7c10fb


## Features

- **User Registration & Authentication**: Users can create accounts to track their financial data securely.
- **Income & Expense Management**: Users can add, edit, and delete income and expense entries, organized by custom categories.
- **Categorization**: Financial transactions are categorized into income and expense categories for better organization.
- **Visual Representation**: The app provides visual charts for a clear understanding of financial status, helping users see their spending and income trends.
- **Detailed Reporting**: Generate reports filtered by date and category, available for download in **PDF** and **Excel** formats.
- **Filtering Options**: Users can filter income and expense lists based on time range and category, enabling more focused analysis.

## Technologies Used

- **ASP.NET MVC**: Provides a structured framework for the application's web interface.
- **Entity Framework (EF)**: Used for data access and handling ORM (Object-Relational Mapping).
- **Charts.js**: Visualizes financial data in the form of charts (e.g., pie charts).
- **HTML5, CSS3, JavaScript**: Frontend technologies to ensure a responsive and user-friendly experience.
- **SQL Server**: Database system to store and retrieve financial data.

## Key Functionalities

1. **Income & Expense Management**
   - Add new income or expense entries categorized by type.
   - View a list of all entries, including sorting by date and category.
   - Edit or delete any entry directly from the list.

2. **Visual Data Representation**
   - See an overview of your income and expenses through easy-to-understand charts.
   - Breakdown of financial data in both graphical and tabular formats.

3. **Advanced Reporting**
   - Filter reports by **date range** and **category**.
   - Export your reports in **PDF** or **Excel** formats with the click of a button.

4. **User-Friendly Interface**
   - Simple, intuitive design makes it easy to navigate between income and expense sections.
   - Responsive design ensures compatibility across all devices.

## Installation & Setup

To run this project locally, follow the steps below:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/FinanceTrackingApp.git
   
### Important
Make sure to update the `appsettings.json` file with the correct connection string to match your SQL Server instance. This step is necessary for the application to connect to the database and run properly.

```json
"ConnectionStrings": {
  "DefaultConnection": "Your-SQL-Server-Connection-String"
}
