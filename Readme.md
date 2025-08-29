# Formula 1 API

A comprehensive .NET Web API for managing Formula 1 drivers and calculating championship standings. This API connects to real F1 data, stores drivers in a database, calculates points per season/round, and allows users to create and manage their own custom drivers alongside real ones.

## 🏁 Features

- **Real F1 Data Integration**: Automatically fetches and stores current season F1 drivers(https://f1api.dev/)
- **Points Calculation**: Calculate championship points by season and round
- **Custom Driver Management**: Create, update, and delete your own custom drivers
- **Database Storage**: Stores both real and custom drivers in the same database
- **RESTful API**: Clean API endpoints for all operations
- **AutoMapper Integration**: Efficient object mapping between DTOs and entities
- **Entity Framework Core**: Modern ORM for database operations

## 🛠️ Technologies Used

- **.NET 8** - Web API Framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database engine
- **AutoMapper** - Object-to-object mapping
- **Swagger/OpenAPI** - API documentation
- **System.Text.Json** - JSON serialization

## 📋 Prerequisites

- **.NET 8 SDK**
- **PostgreSQL**
- **Visual Studio 2022** or **Visual Studio Code** (recommended)
- **Git** (for cloning the repository)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/lucasspanholo/API-Formula-1.git
cd formula1-api
```

### 2. Database Configuration

#### PostgreSQL on local DB (Recommended for development)

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=f1database;Username=yourusername;Password=yourpassword;Include Error Detail=true"
  }
}
```

### 3. Install Dependencies

```bash
dotnet restore
```

### 4. Database Migration

Create and apply the database migrations:

```bash
# Create initial migration (if not already created)
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
```

### 5. Run the Application

```bash
dotnet run
```

The API will be available at:
- **HTTP**: `http://localhost:5000`
- **Swagger UI**: `https://localhost:5162/swagger`

## 📚 API Endpoints

### Drivers

| Method | Endpoint                             | Description                                                                                                                                |
|--------|--------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| `GET` | `/GetDriversByYear/{year}`           | Get all real drivers who raced that year                                                                                                   |
| `GET` | `/GetStandingsByRace/{year}/{round}` | Get championship standings by the round on tha year <br/>This endpoint is presenting an error when calculating the championship standings. |


### My Drivers (Custom Drivers)

| Method | Endpoint               | Description |
|--------|------------------------|-------------|
| `GET` | `/GetMyDrivers`        | Get all drivers |
| `GET` | `/GetDriversById/{id}` | Get custom driver by ID |
| `POST` | `/CreateDriver`        | Create a new custom driver |
| `PUT` | `/UpdateMyDriver/{id}` | Update custom driver |
| `DELETE` | `/DeleteDriver/{id}`   | Delete custom driver |

## 🔧 Configuration

### Development Settings

For development, you can modify `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "your-development-connection-string"
  }
}
```


### Testing with Swagger

1. Navigate to `https://localhost:5162/swagger`
2. Explore and test all available endpoints
3. Use the "Try it out" feature to make API calls


## 📁 Project Structure

```
API_Formula1/
├── Controllers/           # API Controllers
│   ├── F1Controller.cs
│   └── MyDriversController.cs
├── Models/               # Entity Models
├── Services/             # Business Logic
├── Data/                 # Database Context
│   └── AppDbContext.cs
├── DTOs/                 # Data Transfer Objects
├── Migrations/           # EF Core Migrations
├── Program.cs           # Application Entry Point
└── appsettings.json     # Configuration
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'feat: Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request


---

**Happy Racing! 🏎️**