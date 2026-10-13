# Electronics Shop Management System (3-Tier WinForms ERP)

**Candidate:** AHM Zafir Hasan (Zafff-e)  
**Training:** Enterprise Systems Analysis & Design with C# .NET (IsDB-BISEW Round 70)  

---

## 📌 Project Overview
A complete 3-Tier Enterprise Desktop ERP application developed in **C# Windows Forms (.NET Framework 4.8)** using **ADO.NET Disconnected Architecture** and **Microsoft SQL Server LocalDB**. Features master-detail purchase order management, dynamic product calculation, and printable invoice reports powered by **SAP Crystal Reports**.

## 🛠️ Architecture & Tech Stack
* **Architecture:** 3-Tier Enterprise Pattern
  * **Presentation Layer (GUI):** Windows Forms (FrmMain, FrmReportViewer)
  * **Business Logic Layer (BLL):** ViewModels & Repository Pattern (PurchaseRepo, PurchaseViewModel)
  * **Data Access Layer (DAL):** PurchaseGateway, Typed DataSets (.xsd), SqlConnection / SqlCommand
* **Reporting:** SAP Crystal Reports Viewer with grouped invoice slip generation
* **Database:** Microsoft SQL Server (ElectronicShopDB.mdf) with referential integrity and cascading constraints

## ⚡ Key Features
* **Master-Detail Purchasing:** Dynamic row addition, item pricing, real-time total and VAT calculations.
* **Disconnected Data Processing:** Leverages ADO.NET DataSet and SqlDataAdapter for offline transaction staging.
* **Printable Invoices:** Crystal Reports integrated with typed DataSets for aggregated sales & purchase slips.
* **Validation & Integrity:** Structured error handling and UI input validation.
