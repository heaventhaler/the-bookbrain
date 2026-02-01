# Learnings

## Migrations

`dotnet ef migrations list` list all migrations

### MIgration löschen

1. Zu vorheriger Migration zurückgehen `dotnet ef database update <lastCorrectMigrationName>`
2. Letzte Migration entfernen: `dotnet ef migrations remove`
