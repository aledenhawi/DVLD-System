# DVLD (Driving & Vehicle License Department) System 🚗💳

## 📖 About The Project
The **DVLD System** is a comprehensive desktop application designed primarily for **educational purposes (مشروع تعليمي)**. It is a simple but real-world project that simulates the core daily operations of a Driving and Vehicle License Department. 

This system handles everything from managing personal records and scheduling driving tests to issuing licenses and tracking detained documents. It serves as an excellent practical showcase of desktop application development, database architecture, and user interface design.

## ✨ Key Features
* **Authentication & Security:** Secure login interface with user and account management.
* **People & Driver Management:** Robust CRUD (Create, Read, Update, Delete) operations with advanced filtering to manage personal profiles and driver records.
* **License Applications Workflow:** Full lifecycle tracking for Local and International Driving Licenses (including scheduling Vision, Written, and Street tests).
* **License History Tracking:** Detailed visual history of all active, expired, and revoked licenses associated with a specific person.
* **Detained Licenses Module:** Manage detained licenses, calculate fines, process payments, and release licenses.
* **Loging errors :** Logging every error happin in try catch to event log using reflection to show all details.

## 🛠️ Skills & Technologies Used
* **Programming Language:** C#
* **Framework:** .NET Framework (Windows Forms / WinForms)
* **Database Management:** Microsoft SQL Server
* **Data Access:** ADO.NET / 3-Tier Architecture (Presentation, Business logic, and Data Access layers)
* **UI/UX Design:** Custom styling and interactive data grids for a clean, user-friendly enterprise experience.

## 📸 Screenshots

Here is a look at the core forms and interfaces of the system:

### 1. Login Screen
*Secure entry point for system administrators and employees.*
![Login Screen](<Images/Login Screen.png>)

### 2. Manage People Dashboard
*Comprehensive grid view to easily filter, add, and manage registered individuals.*
![Manage People](<Images/Manage People.png>)

### 3. Driving License Applications
*Track the status of applications, schedule tests via context menus, and issue final licenses.*
![Applications](<Images/Local Driving License Applications Managment.png>)

### 4. Driving Licenses History
*A detailed profile view showing all active and historical licenses for a driver.*
![License History](<Images/Person Licenses History.png>)

### 5. Manage Detained Licenses
*System to track confiscated licenses, view fine amounts, and manage the release process.*
![Detained Licenses](<Images/Detained Licenses Mangment.png>)

## 🚀 How to Run the Project
1. Clone the repository: 
   ```bash
   git clone [https://github.com/aledenhawi/DVDL-System.git](https://github.com/aledenhawi/DVDL-System.git)

2. Restore the SQL Server Database (make sure to execute the provided .sql script or attach the .mdf file).

3. Open the project in Visual Studio.

4. Update the SQL Connection String in the App.config file to match your local server instance.

5. Build and Run the application.

## 🤝 Purpose & Feedback
This project was built to apply software engineering concepts to a real-world scenario. Because it is a learning project, 
feedback, code reviews, and suggestions for improvement are always welcome!
