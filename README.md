# SDA Tithe Management System (WinForms, MVC)

A desktop application for Seventh-day Adventist churches in Rwanda to collect tithes,
keep records and report on giving. Built with C# / WinForms (.NET) and a SQLite database.

## Features
- Register, log in by role (Member, Church Leader, Admin), role-based access
- Members: pay tithe (MTN MoMo, Airtel Money, Card), summary, history, receipts (print / PDF)
- Church leaders: manage members, record cash payments, reports (week/month/year), analytics
- Admin: all churches or one, reports, analytics, members, cash payments
- Languages: English, Kinyarwanda, Kiswahili, French (choice is remembered)
- Demo data on first run: 8 churches, 48 members, about a year of payments

## Architecture (MVC)
| Layer | Folder | Role |
|---|---|---|
| Model | `Models/` | Plain data classes (User, Payment, Church, report models) |
| View | `Views/` | WinForms screens; no database access, no business rules |
| Controller | `Controllers/` | Validation, permissions, business logic |
| Data | `Data/` | SQLite repositories (parameterized SQL), schema and demo data |
| Services | `Services/` | Session, validation, password hashing, translations |

## How to run
1. Install Visual Studio 2022 or later with the ".NET desktop development" workload.
2. Clone the repository and open `SdaTithe.sln`.
3. Press F5. The database (`tithe.db`) and demo data are created on first run.

## Demo accounts
| Role | Username / phone | Password |
|---|---|---|
| Admin | `admin` | `admin123` |
| Church Leader | `leader1` ... `leader8` | `1234` |
| Member | `0788000001` | `1234` |

## Notes and limits
- Mobile money and card payments are only recorded, not charged.
- Passwords are hashed with SHA-256. A production system should use a salted
  algorithm such as PBKDF2 or BCrypt.
- All SQL uses parameters to prevent SQL injection.

## Author
Iradukunda Nicole, 28037