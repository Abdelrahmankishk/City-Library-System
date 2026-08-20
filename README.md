# 📚 City Library System

A console-based **C# library management system** built as an Object-Oriented Programming (OOP) practice project. The project models a real-world city library branch and translates a defined set of business rules into a structured object-oriented design.

The system supports **book and copy management, member registration, borrowing and returning, borrowing history, validation, and overdue fine calculation** through a simple menu-driven console application.

## ✨ Project Highlights

- Designed from a dedicated **UML class diagram**
- Organized into **Domain, Branch, and Service** responsibilities
- Applies core OOP principles: **Encapsulation, Inheritance, Abstraction, and Polymorphism**
- Uses **interfaces** to define reusable contracts
- Uses **extension methods** for reusable string validation
- Enforces business rules through domain behavior and exceptions
- Tracks the complete lifecycle of a physical book copy
- Uses a fixed **14-day borrowing period**
- Calculates late-return fines at **10 EGP per overdue day**
- Provides a clean, menu-driven console workflow

## 🧭 System Overview

The application is designed for a librarian and provides the following operations:

| Option | Operation | Purpose |
| --- | --- | --- |
| `1` | Branch Information | Display the library branch details |
| `2` | Show All Users | Display registered members and librarians |
| `3` | Show Available Books | Display only books with available copies |
| `4` | Show All Book Copies | Display every copy and its current status |
| `5` | Borrow a Book | Create a borrowing transaction for an available copy |
| `6` | Return a Book | Return a borrowed copy and calculate any fine |
| `7` | Borrowing History | Display a member's borrowing history |
| `8` | Register New Member | Create a new member with an automatically generated ID |
| `0` | Exit | Close the application |

The main menu is displayed again after each operation until the user chooses `0`.

## 🏗️ Architecture

The UML design separates the system into three main areas:

### Domain Layer

Contains the core business entities and rules:

- `Book`
- `BookCopy`
- `BorrowTransaction`
- `LibraryUser`
- `Member`
- `Librarian`

### Branch Layer

`LibraryBranch` acts as the central library aggregate, holding and coordinating the branch's books/copies, members, and librarian information.

### Service Layer

- `LibraryService` coordinates application operations and user actions.
- `DisplayService` is responsible for presenting library information to the console.

Supporting responsibilities are separated into contracts, helpers, and extensions.

## 🗂️ Project Structure

```text
City-Library-System/
│
├── Contracts/
│   ├── IBorrowable.cs
│   └── IDisplayable.cs
│
├── Extensions/
│   └── StringExtention.cs
│
├── Helpers/
│   ├── ConsoleHelper.cs
│   └── DataSeeder.cs
│
├── images/
│   └── city_library_uml.png
│
├── Models/
│   ├── Enums/
│   │   └── CopyStatus.cs
│   ├── Book.cs
│   ├── BookCopy.cs
│   ├── BorrowTransaction.cs
│   ├── Librarian.cs
│   ├── LibraryBranch.cs
│   ├── LibraryUser.cs
│   └── Member.cs
│
├── Services/
│   ├── DisplayService.cs
│   └── LibraryService.cs
│
└── Program.cs
```

### Folder Responsibilities

| Folder | Responsibility |
| --- | --- |
| `Contracts` | Defines reusable interfaces and behavioral contracts |
| `Extensions` | Contains reusable extension methods |
| `Helpers` | Provides console utilities and initial data seeding |
| `Models` | Contains the main domain entities and enums |
| `Services` | Coordinates application operations and console presentation |
| `images` | Stores project documentation assets such as the UML diagram |

## 🧱 Main Domain Model

| Class | Responsibility |
| --- | --- |
| `LibraryUser` | Abstract base for common library-user data and behavior |
| `Member` | Represents a library member and keeps borrowing transactions |
| `Librarian` | Represents a librarian working at the branch |
| `LibraryBranch` | Represents the branch and coordinates its library data |
| `Book` | Represents a book title and its metadata |
| `BookCopy` | Represents a physical copy and controls its borrowing/return state |
| `BorrowTransaction` | Stores borrowing dates, return information, status, and fine calculation |
| `LibraryService` | Handles library workflows such as borrow, return, lookup, history, and registration |
| `DisplayService` | Handles console-oriented display operations |

## 🔄 Book & Borrowing Lifecycle

A physical copy moves through a controlled lifecycle using `CopyStatus`:

```text
                 ┌──────────────┐
                 │   Available  │
                 └──────┬───────┘
                        │ Borrow
                        ▼
                 ┌──────────────┐
                 │   Borrowed   │
                 └──────┬───────┘
                        │ Return
                        ▼
                 ┌──────────────┐
                 │   Available  │
                 └──────────────┘

        Other possible copy states:
        • Damaged
        • Reserved
```

Only an `Available` copy can be borrowed. Returning requires the copy to be currently borrowed and to have an active transaction.

## 📋 Business Rules

The implementation follows the defined business rules for each major workflow.

### Member Lookup

- The member must exist.
- Member lookup is performed using the membership ID.
- A missing member results in a `Member not found.` error.

### Book Copy Lookup

- The copy must exist.
- Copy lookup is performed using the copy ID.
- A missing copy results in a `Book copy not found.` error.

### Borrowing

- The member must exist.
- The copy must exist.
- The copy must have `Available` status.
- The borrowing period is fixed at **14 days**.
- A borrowing transaction records the member, copy, borrowing date, and due date.

### Returning

- The copy must currently be `Borrowed`.
- The copy must have an active transaction.
- The return operation completes the active transaction.
- Returning on time produces **no fine**.
- Returning late calculates a fine based on overdue days.

### Fine Calculation

```text
Fine = Overdue Days × 10 EGP
```

The system applies a fixed rate of **10 EGP per overdue day**. If the return is on or before the due date, the fine is `0 EGP`.

### Member Registration

- Membership IDs are generated automatically using the `MEM-XXX` format.
- The phone number must contain at least one digit.
- The email must contain both `@` and `.`.
- Invalid input is rejected with a specific business-rule exception.

## 🧠 OOP Concepts Demonstrated

### Encapsulation

State is kept inside the responsible classes, while domain operations such as borrowing and returning are performed through object behavior rather than manipulating internal state directly.

### Inheritance

`LibraryUser` provides common user information for:

- `Member`
- `Librarian`

This avoids duplicating shared user-related data.

### Abstraction

`LibraryUser` is modeled as an abstract class to represent the common concept of a library user without allowing a generic library-user object to be created directly.

### Polymorphism

The common `LibraryUser` abstraction allows different user types to be treated through the same base type while retaining their specialized behavior and data.

### Interfaces

The project defines:

- `IBorrowable` — contract for borrowable behavior.
- `IDisplayable` — contract for objects that provide display behavior.

### Association, Aggregation & Composition

The class model represents relationships between the branch and its domain objects, as well as relationships between members, copies, books, and transactions. These relationships are reflected in the UML diagram and are used to model how the objects collaborate at runtime.

### Extension Methods

`StringExtention.cs` contains reusable string-related validation functionality, keeping common validation logic separate from the main business classes.

### Exception Handling

Business-rule violations are surfaced through `InvalidOperationException` with specific messages instead of silently allowing invalid state changes.

## 🛡️ Validation & Error Handling

Examples of validation and business-rule failures include:

- `Member not found.`
- `Book copy not found.`
- Copy is not available for borrowing.
- Copy is not currently borrowed.
- No active transaction exists for the copy.
- Phone number does not contain a digit.
- Invalid email format.

This approach keeps invalid operations explicit and makes the business rules easier to understand and maintain.

## 🖥️ Application Flow

```text
Program.cs
    │
    ▼
DataSeeder
    │
    ▼
LibraryService
    │
    ├── Branch Information
    ├── User Listing
    ├── Available Books
    ├── All Book Copies
    ├── Borrow
    ├── Return
    ├── Borrowing History
    └── Register Member
            │
            ▼
      DisplayService
            │
            ▼
      Console Output
```

## 💻 Example Console Menu

```text
════════════════════════════════════════
        CITY LIBRARY — MAIN MENU
════════════════════════════════════════
  1.  Branch Information
  2.  Show All Users
  3.  Show Available Books
  4.  Show All Book Copies
  5.  Borrow a Book
  6.  Return a Book
  7.  Member Borrowing History
  8.  Register New Member
────────────────────────────────────────
  0.  Exit
════════════════════════════════════════
  Enter your choice:
```

## 🚀 Getting Started

### Prerequisites

- **.NET SDK** installed
- Visual Studio, Visual Studio Code, or another C# development environment

### Clone the Repository

```bash
git clone https://github.com/Abdelrahmankishk/City-Library-System.git
cd City-Library-System
```

### Run the Application

The application starts as a console program and displays the main library menu.

## 🎯 Project Goals

This project was built to strengthen practical OOP skills by taking a set of detailed business requirements and turning them into a maintainable object-oriented design.

The main learning goals were:

- Modeling a real-world domain with classes and relationships
- Applying inheritance and abstraction appropriately
- Using interfaces and polymorphism
- Practicing encapsulation and controlled state changes
- Separating responsibilities between models and services
- Implementing reusable extension methods
- Enforcing business rules with validation and exceptions
- Designing from a UML class diagram before implementation

## 🛠️ Technologies

- **C#**
- **.NET**
- **Object-Oriented Programming (OOP)**
- **UML Class Diagram**
- **Console Application**

## 📌 Requirements Reference

The project requirements define eight main user stories covering branch information, user listing, available books, all copies, borrowing, returning, borrowing history, and member registration. They also define validation, lookup, return, and fine-calculation rules that the implementation follows.

## 📎 Repository

**GitHub:** [Abdelrahmankishk/City-Library-System](https://github.com/Abdelrahmankishk/City-Library-System)

## 👨‍💻 Author

**Abdelrahman Kishk**

- GitHub: [@Abdelrahmankishk](https://github.com/Abdelrahmankishk)
