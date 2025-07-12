CREATE TABLE GEN_Usuario (
    UsuarioID SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    ContraseñaHash VARCHAR(255) NOT NULL,
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE USU_Rol (
    RolID SERIAL PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Descripcion TEXT
);

CREATE TABLE USU_UsuarioRol (
    UsuarioID INT REFERENCES GEN_Usuario(UsuarioID) ON DELETE CASCADE,
    RolID INT REFERENCES USU_Rol(RolID) ON DELETE CASCADE,
    FechaAsignacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (UsuarioID, RolID)
);

CREATE TABLE CUR_Curso (
    CursoID SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    FechaInicio DATE,
    FechaFin DATE,
    Activo BOOLEAN DEFAULT TRUE,
    CreadoPorUsuarioID INT REFERENCES GEN_Usuario(UsuarioID)
);

CREATE TABLE CUR_CursoUsuario (
    CursoID INT REFERENCES CUR_Curso(CursoID) ON DELETE CASCADE,
    UsuarioID INT REFERENCES GEN_Usuario(UsuarioID) ON DELETE CASCADE,
    Estado VARCHAR(20) DEFAULT 'Activo',
    FechaAsignacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (CursoID, UsuarioID)
);

CREATE TABLE CLA_Clase (
    ClaseID SERIAL PRIMARY KEY,
    CursoID INT REFERENCES CUR_Curso(CursoID) ON DELETE CASCADE,
    Titulo VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    FechaClase DATE,
    DuracionMinutos INT
);

CREATE TABLE EVA_Evaluacion (
    EvaluacionID SERIAL PRIMARY KEY,
    CursoID INT REFERENCES CUR_Curso(CursoID) ON DELETE CASCADE,
    Titulo VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    FechaPublicacion DATE,
    FechaEntrega DATE,
    Tipo VARCHAR(50)
);

CREATE TABLE EVA_Nota (
    NotaID SERIAL PRIMARY KEY,
    EvaluacionID INT REFERENCES EVA_Evaluacion(EvaluacionID) ON DELETE CASCADE,
    UsuarioID INT REFERENCES GEN_Usuario(UsuarioID) ON DELETE CASCADE,
    PuntajeObtenido DECIMAL(5,2),
    Comentarios TEXT,
    FechaCalificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- ========================================
-- ÍNDICES PARA OPTIMIZAR CONSULTAS EN AppCoreDB
-- ========================================

-- GEN_Usuario
CREATE INDEX idx_gen_usuario_email ON GEN_Usuario (Email);

-- USU_Rol
-- No es necesario, ya tiene UNIQUE(Nombre)

-- USU_UsuarioRol
CREATE INDEX idx_usu_usuariorol_rolid ON USU_UsuarioRol (RolID);
CREATE INDEX idx_usu_usuariorol_usuarioid ON USU_UsuarioRol (UsuarioID);

-- CUR_Curso
CREATE INDEX idx_cur_curso_creado_por ON CUR_Curso (CreadoPorUsuarioID);
CREATE INDEX idx_cur_curso_activo ON CUR_Curso (Activo);
CREATE INDEX idx_cur_curso_fecha ON CUR_Curso (FechaInicio, FechaFin);

-- CUR_CursoUsuario
CREATE INDEX idx_cur_cursousuario_usuarioid ON CUR_CursoUsuario (UsuarioID);
CREATE INDEX idx_cur_cursousuario_cursoid ON CUR_CursoUsuario (CursoID);
CREATE INDEX idx_cur_cursousuario_estado ON CUR_CursoUsuario (Estado);

-- CLA_Clase
CREATE INDEX idx_cla_clase_cursoid ON CLA_Clase (CursoID);
CREATE INDEX idx_cla_clase_fecha ON CLA_Clase (FechaClase);

-- EVA_Evaluacion
CREATE INDEX idx_eva_evaluacion_cursoid ON EVA_Evaluacion (CursoID);
CREATE INDEX idx_eva_evaluacion_fecha ON EVA_Evaluacion (FechaPublicacion, FechaEntrega);
CREATE INDEX idx_eva_evaluacion_tipo ON EVA_Evaluacion (Tipo);

-- EVA_Nota
CREATE INDEX idx_eva_nota_usuarioid ON EVA_Nota (UsuarioID);
CREATE INDEX idx_eva_nota_evaluacionid ON EVA_Nota (EvaluacionID);
