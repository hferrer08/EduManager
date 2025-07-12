# EduManagerAPI

API RESTful backend para el sistema EduManager, implementada en .NET 7 usando Entity Framework Core y PostgreSQL.

---

## Descripción

Este proyecto contiene la API que expone los servicios para la gestión de cursos, usuarios y roles. Utiliza EF Core para acceso a datos y PostgreSQL como base de datos.

---

## Requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- PostgreSQL
- Herramientas EF Core CLI (opcional):


---

## Configuración

- La cadena de conexión a la base de datos se encuentra en appsettings.json bajo "ConnectionStrings:DefaultConnection".
- La base de datos debe estar creada con las tablas necesarias (se recomienda usar Scaffold-DbContext para sincronizar el modelo).


---

## Estructura

- /Controllers: Controladores API REST
- /Data: Contexto de base de datos y configuración EF Core
- /Models: Entidades que representan tablas de la base de datos
- /Migrations: Migraciones EF Core (si se usan)

## Uso

- Los endpoints RESTful permiten CRUD sobre cursos, usuarios, roles, etc.
- Autenticación y autorización con JWT (en desarrollo).






