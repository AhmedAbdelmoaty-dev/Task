# Products Management API & Angular Frontend

## Overview

This project implements a **Products Management system** with a **Products table** using **Angular 18** for the frontend and **.NET 8** for the backend. The system supports full **CRUD operations** and follows **Clean Architecture** principles with **CQRS (Command Query Responsibility Segregation)** and **Fluent Validation**.

## Features

### Backend (.NET 8)

- **CRUD Operations**:  
  - **Create** a new product  
  - **Read/Get** products with optional query parameters  
  - **Update** existing product  
  - **Delete** product  

- **Query Parameters for GET**:  
  - `isDeleted`: Filter deleted products  
  - `pageIndex` / `pageNumber`: Pagination support  
  - `searchString`: Search products by name or description  

- **Architecture & Patterns**:  
  - Clean Architecture  
  - CQRS (Commands and Queries separation)  
  - Fluent Validation for input validation  

- **Technologies**:  
  - .NET 8  
  - Entity Framework Core
  - mySql  
  - Fluent Validation  

### Frontend (Angular 18)

- Angular 18 implementation for interacting with the backend API.  
- CRUD forms for products management.  
- Search, pagination, and filter functionalities in the UI.  

## Folder Structure

### Backend

