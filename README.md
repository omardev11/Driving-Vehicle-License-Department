# Driving Vehicle License Department System

Welcome to the Driving Vehicle License Department System! This project is designed to handle various processes related to issuing, renewing, detaining, and replacing driving licenses. It is built using C# Windows Forms and SQL Server for managing the database, ensuring a smooth and efficient workflow for both users and administrators.

## Description
The Driving Vehicle License Department System enables the management of applications for obtaining driving licenses. Users can go through various tests, such as vision, written, and street tests, to qualify for a license. The system also provides features for renewing licenses, detaining or releasing detained licenses, replacing lost or damaged licenses, and issuing international licenses. Additionally, it allows administrators to manage the types of applications and tests available.

### Features:
- **User Authentication**: Login with predefined credentials to access the system.
- **License Applications**: Submit applications for vision, written, and street tests.
- **License Issuance**: Issue driving licenses upon successful completion of the required tests.
- **Renew License**: Renew existing licenses before or after expiration.
- **Detain License**: Temporarily detain licenses if needed.
- **Release Detained License**: Re-enable detained licenses.
- **License Replacement**: Replace lost or damaged licenses.
- **International License Issuance**: Issue international driving licenses.
- **Test and Application Management**: Manage test types (vision, written, street) and application categories (new, renewal, replacement, etc.).
  
## How to Use
1. **Login Credentials**:
   - **Username**: Omar11
   - **Password**: 12345

2. **Main Menu**: After logging in, you will be presented with various options to manage licenses and tests.
   - **Submit Application**: Choose between new license application, renewal, replacement, or international license.
   - **Take Tests**: Users can take vision, written, or street tests based on their application type.
   - **Manage Licenses**: Options to issue, renew, detain, release detain, or replace lost/damaged licenses.
   
3. **Database**: The system is connected to an SQL Server database where all user data, license details, test results, and application records are stored.

## Installation Instructions

### Requirements:
- **Visual Studio** (for developing and running the application)
- **SQL Server** (for managing the database)

### Steps:
1. Clone or download the repository from this link: https://github.com/omardev11/Driving-Vehicle-License-Department.git
2. Open the solution file in Visual Studio.
3. Set up the **SQL Server database** by importing the provided database schema and configuring the connection string in the project.
4. Build the project and run the application.
5. Log in using the provided credentials (Username: Omar11, Password: 12345) to start managing the driving license operations.

## Database Setup
- The database includes tables for user data, license details, application forms, test results, and more.
- **SQL Server** is used to store all the data, and you need to configure your database connection string in the app settings.

I appreciate any suggestions or improvements
