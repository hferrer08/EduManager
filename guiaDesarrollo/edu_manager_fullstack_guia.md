# ✅ Guía de Desarrollo Fullstack - Proyecto EduManager

## 🧱 Objetivo General
Desarrollar una plataforma de gestión educativa (EduManager) con:
- Backend: ASP.NET Core + PostgreSQL
- Frontend: React + TailwindCSS
- Autenticación: JWT

---

## 🔄 Flujo General

### 🧱 1. Base de Datos
- [x] Crear tablas relacionales - LISTO
- [x] Insertar datos iniciales (roles, usuarios, etc.) - LISTO

### 🛠️ 2. Backend en .NET (en progreso)

#### 2.1 CRUD Controllers
- [x] UsuariosController - LISTO
- [x] RolesController - LISTO
- [x] UsuariosRolesController - LISTO
- [x] CursosController - LISTO
- [x] CursoUsuarioController - LISTO
- [x] ClasesController - LISTO
- [x] EvaluacionController - LISTO
- [x] EvaNotumController - LISTO

#### 2.2 Endpoints personalizados
- [ ] /usuarios/{id}/roles
- [ ] /cursos/{id}/usuarios
- [ ] Evaluaciones por curso o usuario

#### 2.3 Autenticación JWT
- [ ] Instalar paquete JwtBearer
- [ ] Configurar en Program.cs
- [ ] Crear AuthController
  - [ ] /login que entrega token
  - [ ] Validar usuario con base de datos
- [ ] Aplicar [Authorize] a controladores
- [ ] Probar en Postman con token

---

### 🌐 3. Frontend en React

#### 3.1 Inicialización
- [ ] Crear proyecto con Vite
- [ ] Configurar TailwindCSS
- [ ] React Router (estructura de rutas)

#### 3.2 Módulos por entidad

| Módulo           | Componentes sugeridos                   |
|------------------|------------------------------------------|
| Auth             | Login, PrivateRoute, useAuth (contexto) |
| Usuarios         | Lista, Formulario, Detalle               |
| Roles            | Lista, Formulario                       |
| Cursos           | Lista, Formulario, Detalle              |
| Clases           | Lista, Formulario                       |
| Evaluaciones     | Lista, Formulario, Notas                |

---

### 🔐 4. JWT en React
- [ ] Guardar token en localStorage
- [ ] AuthContext (login, logout, usuario)
- [ ] fetchConToken para peticiones seguras
- [ ] Rutas protegidas con <PrivateRoute />
- [ ] Mostrar datos del usuario logueado

---

### 📋 5. Flujo recomendado

1. Backend CRUD
2. Validar con Postman
3. Agregar JWT
4. Iniciar proyecto React
5. Crear login y contexto
6. Crear cada módulo uno por uno
7. Probar flujo completo
8. Mejorar UX/UI (errores, loaders, etc.)
9. Deploy final (Render/Vercel)

---

### 💡 Buenas Prácticas
- Separar carpetas por dominio
- Reutilizar componentes
- Aplicar diseño responsivo
- Escribir código limpio y documentado

---

⚡ Tip final: este proyecto es más largo, tómate tu tiempo y avanza con orden. Puedes revisar este checklist cada día para evaluar tu progreso.

