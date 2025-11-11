# URL Shortener App – .NET 9 Blazor Interactive Server

This project is a URL Shortener application built using .NET 9 Blazor Interactive Server. It demonstrates how to turn long, complex URLs into short, shareable links while showcasing Blazor's real-time interactivity, component-based architecture, and modern server-side rendering capabilities.

## 🚀 Features

- Convert long URLs into short, user-friendly links
- Store and manage links using Entity Framework Core
- Clean UI based on an external CSS template
- Fully interactive Blazor components
- Repository + Service Layer architecture
- Custom helper utilities for URL generation
- Server-side execution using Blazor Interactive Server

## 📋 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (LocalDB, Express, or full version)
- Visual Studio 2022 or VS Code with C# extensions

## 🛠️ Installation & Setup

1. **Clone the repository**
   ```bash
    git clone https://github.com/JOSIAHTHEPROGRAMMER/URL_Shortener.git
    cd URL_Shortener
    ```

2. **Restore dependencies**
    ```bash
    dotnet restore
    ```

3. **Update database connection string**

    - Open appsettings.json
    
    - Modify the DefaultConnection string to match your SQL Server instance
    
4. **Run database migrations**
    ```bash
    dotnet ef database update
    ```

5. Run the application
    ```bash
    dotnet run
    ```
--- 

## 🌐 Access the Application
The application will be available at:
https://localhost:7049/
