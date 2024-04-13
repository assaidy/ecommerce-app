# Software Requirements Specification for Terminal-Based E-commerce Application

## 1. Introduction

### 1.1 Purpose
This document describes the requirements for a terminal-based e-commerce application. The application will allow users to browse products, add them to a cart, and complete purchases. It will be developed using C# with a focus on object-oriented programming principles.

### 1.2 Scope
The application will be a simple, text-based interface for users to interact with an e-commerce system. It will include features for product listing, shopping cart management, and order processing.

### 1.3 Definitions, Acronyms, and Abbreviations
- **OOP**: Object-Oriented Programming
- **C#**: A programming language developed by Microsoft
- **SRS**: Software Requirements Specification

### 1.4 References
- https://dotnet.microsoft.com/en-us/learn/csharp

### 1.5 Overview
This document is structured into several sections, each detailing a specific aspect of the system.

## 2. General Description

### 2.1 Product Perspective
The system is a standalone terminal-based application. It will not interact with external systems or databases.

### 2.2 Product Functions
- **Product Listing**: Display a list of products available for purchase.
- **Shopping Cart Management**: Allow users to add products to a cart and view the cart's contents.
- **Order Processing**: Complete a purchase by processing the cart's contents.

## 3. Specific Requirements

### 3.1 Functional Requirements

#### 3.1.1 Product Listing
- The system shall display a list of products available for purchase.
- Each product listing shall include the product name, price, and a brief description.

#### 3.1.2 Shopping Cart Management
- The system shall allow users to add products to a shopping cart.
- Users shall be able to view the contents of their shopping cart.
- Users shall be able to remove products from their shopping cart.

#### 3.1.3 Order Processing
- The system shall allow users to complete a purchase by processing the contents of their shopping cart.
- Upon completion of a purchase, the system shall display a confirmation message.

### 3.2 Non-Functional Requirements

#### 3.2.1 Performance Requirements
- The system shall respond to user inputs within 2 seconds.

#### 3.2.2 Security Requirements
- The system shall not store sensitive user information.

#### 3.2.3 Software Quality Attributes
- The system shall be user-friendly, with clear and concise instructions.

## 4. System Features

### 4.1 Product Listing
- **Feature ID**: F1
- **Description**: Display a list of products available for purchase.
- **Priority**: High

### 4.2 Shopping Cart Management
- **Feature ID**: F2
- **Description**: Allow users to add products to a shopping cart, view the cart's contents, and remove products from the cart.
- **Priority**: High

### 4.3 Order Processing
- **Feature ID**: F3
- **Description**: Complete a purchase by processing the contents of the shopping cart.
- **Priority**: High

## 5. System Constraints

### 5.1 Hardware Constraints
- The application will run on any terminal with a basic text display.

### 5.2 Software Constraints
- The application will be developed using C#.

### 5.3 Other Constraints
- The application will not interact with external systems or databases.

## 6. Future Enhancements
- Integration with a database for persistent storage.
- User authentication and authorization.
- Online payment processing.

