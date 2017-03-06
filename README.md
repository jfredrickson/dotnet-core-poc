# .NET Core on cloud.gov

This is a small proof-of-concept demonstrating .NET Core on cloud.gov.

It uses Entity Framework Core and MySQL for persistence.

## Development

### Prerequisites

1. MySQL server (e.g., running on localhost). Add a database and database user for this app.
2. [.NET Core SDK](https://www.microsoft.com/net/download/core) (see [global.json](global.json) for specific version of SDK in use)

### Setup

After cloning this repository to your local machine, create `src/CoreSandbox/appsettings.Development.json` with the following content:

```json
{
  "DATABASE_URL": "mysql://USERNAME:PASSWORD@HOST:PORT/DATABASE"
}
```

Replace `USERNAME`, `PASSWORD`, `HOST`, `PORT`, and `DATABASE` with the appropriate settings for the MySQL database you configured.

### Running the App

You should now be able to debug the application locally by running it from Visual Studio Code or Visual Studio 2017.

You can also run it from the command line:

**Windows**
```
setx ASPNETCORE_ENVIRONMENT Development
cd src\CoreSandbox
dotnet restore
dotnet run
```

**Linux/macOS**
```
cd src/CoreSandbox
dotnet restore
ASPNETCORE_ENVIRONMENT=Development dotnet run
```

## cloud.gov Deployment

1. Create a MySQL [relational database service](https://cloud.gov/docs/services/relational-database/) instance for the app to use.
2. Update `manifest.yml` with the new database service name.
3. Run `build.cmd` (Windows) or `build.sh` (Linux/macOS) to create a self-contained deployment package.
4. Run `cf push` to push the package to cloud.gov.
