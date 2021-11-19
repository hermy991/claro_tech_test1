## claro_tech_test1
### Database
#### Update Database

Install entity framework comand (`dotnet ef`) please run `dotnet tool install --global dotnet-ef`

See Comands:

- Create Migration: `dotnet ef migrations add [NombreMigracion] --verbose`
- List Migrations: `dotnet ef migrations list`
- Save Migration Script: `dotnet ef migrations script -o DB/DbScript.sql`
- Apply Migration: `dotnet ef database update`
- Rollback Migration: `dotnet ef database update [PreviousMigrationName]`
- Delete Migration: `dotnet ef migrations remove --verbose`
- Another Comands: 
```sh
dotnet ef migrations script [FromMigrationName]
dotnet ef migrations script [FromMigrationName] [To] [ToMigrationName]
```
