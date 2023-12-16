
### 1. Add MySql
```bash
dotnet add package MySql.Data
```

### 2. Edit `appsettings.Development.json` and `appsettings.json`
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=YourDatabaseName;User=root;Password=YourPassword;Port=3306;"
}
```

### 3. Create `DatabaseHelper.cs` inside Util folder and create connection with DB
```cs
private readonly string _connectionString;

public DatabaseHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
```

### 4. Export connection `GetConnection` in DatabaseHelper class

### 5. Created `UserServiece.cs` and registered the `UserService` in the dependency injection container in `Program.cs` file
(In order to use the services in side contoller class)
```cs
builder.Services.AddScoped<UserService>();
```

```cs
// use services using dependency injection
private readonly UserService _userService;

public UserController(UserService us)
{
    _userService = us;
}
```