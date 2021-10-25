# HotelAPI

API for hotel room management as test for Alten

## Rules

- For the purpose of the test, we assume the hotel has only one room available
- To give a chance to everyone to book the room, the stay can’t be longer than 3 days and can’t be reserved more than 30 days in advance.
- All reservations start at least the next day of booking,
- To simplify the use case, a “DAY’ in the hotel room starts from 00:00 to 23:59:59.
- Every end-user can check the room availability, place a reservation, cancel it or modify it.
- To simplify the API is insecure.

## Requirements
 - Visual Studio 
 
 - SQL Server with a local DB
 
## Setup
The only change required is to change the connection string in appsettings.json to your local database (if it's not called localhost)

![image](https://user-images.githubusercontent.com/3581335/138747338-937fef93-96af-4bf9-83e9-37827978bda6.png)

After that if the connection string is correct, the DB will be generated for you on the first run of the application and will include all Entity Framework migrations.

## Backend API Endpoints

### (GET) api/Resvation/GetAll
Gets all reservations for the hotel in order to look for availability

### (POST) api/Resvation/Create
Creates a Reservation

### (PUT) api/Resvation/Update
Updates a Reservation

### (DELETE) api/Resvation/Delete
Deletes a reservation

## Architecture

This project is built with an N-Layer architechture including a business layer and a data layer, also includes a test project which contains tests for the service class in the business layer

![image](https://user-images.githubusercontent.com/3581335/138752361-2181bf6c-7e2c-4652-8e1a-a7da89a21ab6.png)

Includes Swagger for the documentation

![image](https://user-images.githubusercontent.com/3581335/138750555-4e1318e2-0530-49b3-b89a-1f74c1cdf330.png)

## Database Architecture

The Database only has 1 table which is for reservation with the following columns

- Id : Is primary key and the identifier for the reservations
- StartDate : Date and time in which the reservation starts
- EndDate : Date and time in which the reservavation ends
- CustomerName : Name of the person who made the reservation

![image](https://user-images.githubusercontent.com/3581335/138750764-e73764c9-fd8d-483a-acec-7d1c57757f89.png)

## Important

StartDate and EndDate will take the time as inputs with the date but all the validation will use only the date, making the reservation valid from 0:00:00 to 23:59:59 as requested, otherwise to change this we could use a validation to accept only those times or use a string with a specific format for the date that would be needed to be parsed later on.

## Tech stack

- Net core 3.1

- Entity Framework Core

- Swagger

- Automapper

- Linq

- Nunit

- Moq

## Patterns

- Dependency Injection

- Generic Repository

- N-Tier Architecture

- Data Transfer Objects

