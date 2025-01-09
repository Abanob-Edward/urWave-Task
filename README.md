# urWave Task
# Simple Product Management System

This project is a simple product management system built as a technical assessment for a Full Stack .NET Developer position.

## Technical Stack

* Backend:
    * .NET 8 Web API (Minimal API)
    * Entity Framework Core
    * SQL Server (Express Edition)
* Frontend:
    * Angular 19 (Standalone Components)
    * PrimeNG 19 Components 
    * CSS

## Required Features

* **Products List Page:**
    * Displays a list of products using a [PrimeNG Datatable].
    * Shows columns for ID, Name, Description, Price, and Created Date.
    * Implements search by product name.
    * Enables sorting for all columns.
* **Create Product Page:**
    * Provides a form to create new products.
    * Includes fields for Name (required, max 100 characters), Description (required, max 500 characters), and Price (required, positive number).
    * Validates user input and displays error messages.
    * Shows a success notification upon successful product creation.
* **Edit Product Page:**
    * Allows editing existing products.
    * Prefills the form with the product's data.
    * Uses the same validation as the create form.
    * Displays success/error notifications based on update results.
* **Delete Product:**
    * Prompts for confirmation before deleting a product.
    * Shows success/error notifications based on the deletion outcome.

## Additional Work

* **Responsiveness:** Implemented using Onion Architecture to improve the user experience on different devices.
* **Validation:** 
    * **Frontend:** Implemented client-side validation to provide immediate feedback to the user and enhance the user experience.
    * **Backend:** Implemented server-side validation to ensure data integrity and security before persisting data to the database.
    * **Database:** Utilized database constraints (e.g., data types, length restrictions, uniqueness) to maintain data consistency at the database level.

## Setup Instructions
