# CenterAuth

Authentication and user management service for the Fintech ecosystem. Handles user registration, login, JWT token issuance, and Redis-backed session management.

## Architecture

3-layer architecture:

```
CenterAuth/                      # ASP.NET Core Web API (host)
├── Controllers/                  # Auth endpoints (login, register, token refresh)
├── Swagger/                      # Swagger configuration
├── Program.cs                    # DI composition and middleware pipeline
└── Dockerfile                    # Multi-stage .NET 8 build

CenterAuth.Services/             # Business logic layer
├── Interfaces/                   # Service abstractions
├── Services/                     # Auth logic, token generation, session management
└── DTO/                          # Request/response data transfer objects

CenterAuth.Repositories/         # Data access layer
├── Context/                      # EF Core DbContext (SQL Server)
├── Models/                       # Entity models
└── Repositories/                 # Repository implementations
```

## Technology stack

| Component | Version |
|---|---|
| .NET | 8.0 |
| EF Core (SQL Server) | 8.0.12 |
| JwtBearer | 8.0.12 |
| Identity tokens | 8.3.1 |
| AutoMapper | 13.0.1 |
| Swashbuckle | 6.9.0 |
| AuthOrchestrator (NuGet) | 1.1.0 |

## Commands

```bash
# Build
dotnet build

# Run
dotnet run --project CenterAuth

# Docker
docker build -f CenterAuth/Dockerfile -t centerauth .
```

## Integration

```
CenterAuth ──uses──> AuthOrchestrator (NuGet 1.1.0)
                      ├── JWT configuration
                      ├── Redis session management
                      └── User type constants

Tasker ──calls──> CenterAuth (login/register/token endpoints)
```

- **Database**: SQL Server
- **Session store**: Redis
- **Consumers**: Tasker (authenticates users via CenterAuth-issued JWTs)
