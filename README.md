# EduManager

Sistema de gestión de cursos fullstack con arquitectura monolítica.

---

## Descripción

EduManager es una aplicación para la gestión integral de cursos, usuarios y roles. Incluye funcionalidades para administración de cursos, usuarios con múltiples roles, autenticación y autorización, y gestión de inscripciones.

Está construido con:

- **Backend:** .NET 7 (o .NET Core)
- **Base de datos:** PostgreSQL
- **Frontend:** React

---

## Estructura del proyecto

EduManager/
│
├── Backend/ # Proyecto backend en .NET - API
│
├── Frontend/ # Aplicación React
│
├── Database/ # Scripts para base de datos, migraciones, etc.
│
└── README.md # Este archivo
---

## Requisitos previos

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- [Node.js y npm](https://nodejs.org/)
- [PostgreSQL](https://www.postgresql.org/download/)

---


## Autenticación y autorización
- El backend incluye JWT para autenticación.
- El frontend maneja la sesión y roles para mostrar diferentes vistas según el usuario.

## Roles de usuario
- Administrador
- Profesor
- Estudiante
- Invitado

Cada usuario puede tener uno o más roles asignados.

## Funcionalidades principales
- Gestión de usuarios y roles
- Creación y administración de cursos
- Inscripción y seguimiento de estudiantes en cursos
- Panel de administración con filtros y reportes
- Autorización por roles para restringir accesos

## Desarrollo
- El backend usa Entity Framework Core con migraciones y PostgreSQL como base de datos.
- El frontend usa React con hooks y Context API para el estado global.





