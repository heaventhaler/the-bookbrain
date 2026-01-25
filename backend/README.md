# Backend – Book Companion API 📚

## Tech Stack

- **Backend:** .NET (C#)
- **Datenbank:** PostgreSQL
- **ORM:** Entity Framework Core
- **Container:** Docker (für die DB)

## Projekt starten

```bash
dotnet run
```

PostgreSQL läuft über Docker und wird für den Betrieb benötigt.

## Architektur

Das Projekt ist klassisch geschichtet aufgebaut:

### Controllers

- Definieren die API-Endpunkte
- Greifen auf Services zu
- Arbeiten mit DTOs

### Services

- Enthalten die Geschäftslogik
- Koordinieren die Zugriffe auf Repositories

### Repositories

- Kapseln die Datenbank-Logik
- Zugriff auf PostgreSQL über Entity Framework Core

### DTOs

- Vom Controller verwendet
- Abbildung der Daten für verschiedene Use-Cases  
  (z. B. Übersicht vs. Detailansicht)

### Models

- Datenmodelle, wie sie in der Datenbank gespeichert werden

### Exceptions

- Zentrale Definition von Exceptions
- Saubere Fehlerbehandlung

### Migrations

- Änderungen am Datenmodell werden über EF-Core-Migrations versioniert

Dokumentation:  
https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

Beispiel:

```bash
dotnet ef migrations add AddBlogCreatedTimestamp
```
