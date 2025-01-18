# EBookShop: A .NET Core MVC Web Application

A fully functional .NET Core MVC application designed with modular architecture, incorporating Entity Framework, repository patterns, Bootstrap styling, and essential features like authentication, file upload, and rich text editing.

---

## Features

- **Modular Architecture**: Separation of concerns using class libraries for `Models`, `DataAccess`, and `Utilities`.
- **Entity Framework Integration**: Simplified data management with code-first migrations and database seeding.
- **Repository Pattern**: Centralized data access logic with `UnitOfWork`.
- **Bootstrap Integration**: Enhanced UI using a custom Bootstrap theme.
- **File Upload**: Image management with efficient storage in `wwwroot`.
- **Rich Text Editor**: TinyMCE integration for text formatting.
- **Authentication**: Identity framework for user registration, login, and role management.
- **AJAX-Powered DataTables**: Dynamic and interactive data grids.
- **Responsive Design**: Mobile-friendly UI with Bootstrap.

---

## Getting Started

### Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- SQL Server or PostgreSQL
- IDE: [Visual Studio](https://visualstudio.microsoft.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/)
- [Node.js](https://nodejs.org/) (for front-end dependencies)

---

### Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/username/repository-name.git
   cd repository-name

2.  **Set up Database**
	- Open appsettings.json and configure your database connection string:
	``` json
	"ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;Trusted_Connection=True;"
   }

3. **Apply Migrations**
   Run the following command to create the database schema:
   ```bash
   dotnet ef database update

4. **Restore Client-Side Libraries Install front-end dependencies using LibMan:**
   ```bash
   libman restore

5. . **Run the Application Start the application locally:**
   ```bash
   dotnet run

## Technologies Used

- **Back-End**: .NET Core MVC, Entity Framework Core  
- **Front-End**: Bootstrap, DataTables, TinyMCE  
- **Database**: SQL Server or PostgreSQL  
- **Tools**: LibMan, NuGet, Visual Studio  

---

## Contributing

We welcome contributions! To get started:

1. Fork the repository.  
2. Create a new branch for your feature or bug fix.  
3. Commit your changes.  
4. Push the branch and create a pull request.  

---

## License

This project is licensed under the [MIT License](LICENSE).

---

## Contact

For questions or feedback, reach out to:

- **Author**: [Nirajan](mailto:nirajanshrestha672@gmail.com)  
- **GitHub**: [nirajan128](https://github.com/nirajan128)


