
-- INSERTS DE PRUEBA 
-- ========================================

-- =========
-- USUARIOS
-- =========
INSERT INTO GEN_Usuario (Nombre, Email, ContraseñaHash)
VALUES
    ('Administrador General', 'admin@correo.com', 'adminhash'),
    ('Juan Estudiante', 'juan@correo.com', 'juanpasshash'),
    ('Laura Docente', 'laura@correo.com', 'laurapasshash');

-- =========
-- ROLES
-- =========
INSERT INTO USU_Rol (Nombre, Descripcion)
VALUES
    ('Administrador', 'Acceso total al sistema'),
    ('Docente', 'Crea cursos y gestiona clases'),
    ('Estudiante', 'Participa en cursos y evaluaciones');

-- ==================
-- ASIGNACIÓN DE ROLES
-- ==================
-- Admin
INSERT INTO USU_UsuarioRol (UsuarioID, RolID)
VALUES
    (1, 1);  -- Admin tiene rol Administrador

-- Estudiante
INSERT INTO USU_UsuarioRol (UsuarioID, RolID)
VALUES
    (2, 3);  -- Juan es Estudiante

-- Docente
INSERT INTO USU_UsuarioRol (UsuarioID, RolID)
VALUES
    (3, 2);  -- Laura es Docente

-- ==========
-- CURSOS
-- ==========
INSERT INTO CUR_Curso (Nombre, Descripcion, FechaInicio, FechaFin, CreadoPorUsuarioID)
VALUES
    ('Introducción a PostgreSQL', 'Curso básico para aprender PostgreSQL', '2025-08-01', '2025-09-30', 3),
    ('Fundamentos de .NET', 'Curso para iniciarse en .NET con C#', '2025-08-15', '2025-10-15', 3);

-- ====================
-- INSCRIPCIÓN A CURSOS
-- ====================
-- Juan (estudiante) inscrito en ambos cursos
INSERT INTO CUR_CursoUsuario (CursoID, UsuarioID)
VALUES
    (1, 2),
    (2, 2);

-- ==========
-- CLASES
-- ==========
INSERT INTO CLA_Clase (CursoID, Titulo, Descripcion, FechaClase, DuracionMinutos)
VALUES
    (1, 'Instalación de PostgreSQL', 'Instalaremos y configuraremos PostgreSQL', '2025-08-02', 90),
    (1, 'Consultas básicas SQL', 'SELECT, WHERE, etc.', '2025-08-05', 90),
    (2, 'Instalación de .NET SDK', 'Ambiente de desarrollo', '2025-08-16', 60);

-- ==========
-- EVALUACIONES
-- ==========
INSERT INTO EVA_Evaluacion (CursoID, Titulo, Descripcion, FechaPublicacion, FechaEntrega, Tipo)
VALUES
    (1, 'Tarea 1 - Consultas simples', 'Resolver 5 consultas básicas', '2025-08-05', '2025-08-10', 'Tarea'),
    (2, 'Evaluación inicial .NET', 'Preguntas básicas de consola y variables', '2025-08-18', '2025-08-22', 'Prueba');

-- ==========
-- NOTAS
-- ==========
INSERT INTO EVA_Nota (EvaluacionID, UsuarioID, PuntajeObtenido, Comentarios)
VALUES
    (1, 2, 9.0, 'Buen trabajo'),
    (2, 2, 8.0, 'Podrías mejorar las variables');