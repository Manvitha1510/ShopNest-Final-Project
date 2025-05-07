# ShopNest – Smart E-Commerce Management Platform

ShopNest is an innovative ASP.NET Core MVC web application designed to simplify product and inventory management for online businesses with real-time analytics and seamless Azure deployment.

---

## Live Features

- Add/Edit/Delete Products Inventory
- Dashboard :  
  - Inventory Controls
  - Visual Analytics
  - Meet the team

---

## Data Model (ER Diagram)

```plaintext
┌───────────────┐          ┌────────────────────┐
│   Category    │◄───────┐ │     Product        │
├───────────────┤        │ ├────────────────────┤
│CategoryId (PK)│        └─┤ ProductId (PK)     │
│Name           │          │ Title              │
│Description    │          │ Description        │
└───────────────           │ Price              │
                           │ Stock              │
                           │ CategoryId (FK)    │
                           └────────────────────┘

---

## CRUD Implementation Overview

- **Create**: Adding new Product
- **view**: Displaying the products information
- **Update**: Edit excisting Products
- **Delete**: Removing the products from the list

---
## Technical Challenges & Solutions

| Challenge                          | Solution                                                                 |
|------------------------------------|--------------------------------------------------------------------------|
| Azure deployment configuration     | Resolved through systematic troubleshooting and Microsoft documentation  |
| Form validation & UI feedback      | Implemented client-side(JavaScript) + server-side(ModelState) validation |
| Data model relationships           | Established one-to-many (Category→Product) with foreign keys             |

---

## Tech Stack

- ASP.NET Core MVC (.NET 7/8)
- C#
- Chart.js (for interactive data visualization)
- fakestoreapi

---

## Folder Structure

```
/Controllers
/Models
/Services
/Views
    /Home 
    /Products
    /Manage
    /Visualisations
wwwroot/
    /img
```

---

## Run Locally

```bash
git clone https://github.com/yourusername/ShopNest-Final-Project.git
cd ShopNest-Final-Project
dotnet run
```
