# Bokningssystem – Backend

Detta är backend-delen av mitt bokningssystem byggt som inlämningsuppgift i kursen **Objektorienterad Programmering – Avancerad**.

## Tech-stack

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core + SQL Server
- Clean-ish Architecture (API, Application, Domain, Infrastructure)
- Enhetstester (Application.Tests)
- GitHub Actions (build & test – kommer läggas till)

## Projektstruktur

- `API/` – Web API (controllers, DTOs, validering, auth)
- `Application/` – tjänstelager, affärslogik
- `CleanArchitecture.Domain/` – domänmodeller
- `Infrastructure/` – EF Core, DbContext, databasåtkomst
- `Application.Tests/` – enhetstester

## Hur man kör backend lokalt

1. Klona repot  
   ```bash
   git clone https://github.com/<ditt-användarnamn>/<ditt-repo-namn>.git


