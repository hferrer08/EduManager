using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EduManagerAPI.Models;

namespace EduManagerAPI.Data;

public partial class AppCoreDbContext : DbContext
{
    public AppCoreDbContext()
    {
    }

    public AppCoreDbContext(DbContextOptions<AppCoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClaClase> ClaClases { get; set; }

    public virtual DbSet<CurCurso> CurCursos { get; set; }

    public virtual DbSet<CurCursousuario> CurCursousuarios { get; set; }

    public virtual DbSet<EvaEvaluacion> EvaEvaluacions { get; set; }

    public virtual DbSet<EvaNotum> EvaNota { get; set; }

    public virtual DbSet<GenUsuario> GenUsuarios { get; set; }

    public virtual DbSet<UsuRol> UsuRols { get; set; }

    public virtual DbSet<UsuUsuariorol> UsuUsuariorols { get; set; }

  /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=AppCoreDB;Username=postgres;Password=472958H");
 */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClaClase>(entity =>
        {
            entity.HasKey(e => e.Claseid).HasName("cla_clase_pkey");

            entity.ToTable("cla_clase");

            entity.HasIndex(e => e.Cursoid, "idx_cla_clase_cursoid");

            entity.HasIndex(e => e.Fechaclase, "idx_cla_clase_fecha");

            entity.Property(e => e.Claseid).HasColumnName("claseid");
            entity.Property(e => e.Cursoid).HasColumnName("cursoid");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Duracionminutos).HasColumnName("duracionminutos");
            entity.Property(e => e.Fechaclase).HasColumnName("fechaclase");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Curso).WithMany(p => p.ClaClases)
                .HasForeignKey(d => d.Cursoid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cla_clase_cursoid_fkey");
        });

        modelBuilder.Entity<CurCurso>(entity =>
        {
            entity.HasKey(e => e.Cursoid).HasName("cur_curso_pkey");

            entity.ToTable("cur_curso");

            entity.HasIndex(e => e.Activo, "idx_cur_curso_activo");

            entity.HasIndex(e => e.Creadoporusuarioid, "idx_cur_curso_creado_por");

            entity.HasIndex(e => new { e.Fechainicio, e.Fechafin }, "idx_cur_curso_fecha");

            entity.Property(e => e.Cursoid).HasColumnName("cursoid");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Creadoporusuarioid).HasColumnName("creadoporusuarioid");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fechafin).HasColumnName("fechafin");
            entity.Property(e => e.Fechainicio).HasColumnName("fechainicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Creadoporusuario).WithMany(p => p.CurCursos)
                .HasForeignKey(d => d.Creadoporusuarioid)
                .HasConstraintName("cur_curso_creadoporusuarioid_fkey");
        });

        modelBuilder.Entity<CurCursousuario>(entity =>
        {
            entity.HasKey(e => new { e.Cursoid, e.Usuarioid }).HasName("cur_cursousuario_pkey");

            entity.ToTable("cur_cursousuario");

            entity.HasIndex(e => e.Cursoid, "idx_cur_cursousuario_cursoid");

            entity.HasIndex(e => e.Estado, "idx_cur_cursousuario_estado");

            entity.HasIndex(e => e.Usuarioid, "idx_cur_cursousuario_usuarioid");

            entity.Property(e => e.Cursoid).HasColumnName("cursoid");
            entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Fechaasignacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaasignacion");

            entity.HasOne(d => d.Curso).WithMany(p => p.CurCursousuarios)
                .HasForeignKey(d => d.Cursoid)
                .HasConstraintName("cur_cursousuario_cursoid_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.CurCursousuarios)
                .HasForeignKey(d => d.Usuarioid)
                .HasConstraintName("cur_cursousuario_usuarioid_fkey");
        });

        modelBuilder.Entity<EvaEvaluacion>(entity =>
        {
            entity.HasKey(e => e.Evaluacionid).HasName("eva_evaluacion_pkey");

            entity.ToTable("eva_evaluacion");

            entity.HasIndex(e => e.Cursoid, "idx_eva_evaluacion_cursoid");

            entity.HasIndex(e => new { e.Fechapublicacion, e.Fechaentrega }, "idx_eva_evaluacion_fecha");

            entity.HasIndex(e => e.Tipo, "idx_eva_evaluacion_tipo");

            entity.Property(e => e.Evaluacionid).HasColumnName("evaluacionid");
            entity.Property(e => e.Cursoid).HasColumnName("cursoid");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fechaentrega).HasColumnName("fechaentrega");
            entity.Property(e => e.Fechapublicacion).HasColumnName("fechapublicacion");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Curso).WithMany(p => p.EvaEvaluacions)
                .HasForeignKey(d => d.Cursoid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("eva_evaluacion_cursoid_fkey");
        });

        modelBuilder.Entity<EvaNotum>(entity =>
        {
            entity.HasKey(e => e.Notaid).HasName("eva_nota_pkey");

            entity.ToTable("eva_nota");

            entity.HasIndex(e => e.Evaluacionid, "idx_eva_nota_evaluacionid");

            entity.HasIndex(e => e.Usuarioid, "idx_eva_nota_usuarioid");

            entity.Property(e => e.Notaid).HasColumnName("notaid");
            entity.Property(e => e.Comentarios).HasColumnName("comentarios");
            entity.Property(e => e.Evaluacionid).HasColumnName("evaluacionid");
            entity.Property(e => e.Fechacalificacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacalificacion");
            entity.Property(e => e.Puntajeobtenido)
                .HasPrecision(5, 2)
                .HasColumnName("puntajeobtenido");
            entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

            entity.HasOne(d => d.Evaluacion).WithMany(p => p.EvaNota)
                .HasForeignKey(d => d.Evaluacionid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("eva_nota_evaluacionid_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.EvaNota)
                .HasForeignKey(d => d.Usuarioid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("eva_nota_usuarioid_fkey");
        });

        modelBuilder.Entity<GenUsuario>(entity =>
        {
            entity.HasKey(e => e.Usuarioid).HasName("gen_usuario_pkey");

            entity.ToTable("gen_usuario");

            entity.HasIndex(e => e.Email, "gen_usuario_email_key").IsUnique();

            entity.HasIndex(e => e.Email, "idx_gen_usuario_email");

            entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Contraseñahash)
                .HasMaxLength(255)
                .HasColumnName("contraseñahash");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<UsuRol>(entity =>
        {
            entity.HasKey(e => e.Rolid).HasName("usu_rol_pkey");

            entity.ToTable("usu_rol");

            entity.HasIndex(e => e.Nombre, "usu_rol_nombre_key").IsUnique();

            entity.Property(e => e.Rolid).HasColumnName("rolid");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<UsuUsuariorol>(entity =>
        {
            entity.HasKey(e => new { e.Usuarioid, e.Rolid }).HasName("usu_usuariorol_pkey");

            entity.ToTable("usu_usuariorol");

            entity.HasIndex(e => e.Rolid, "idx_usu_usuariorol_rolid");

            entity.HasIndex(e => e.Usuarioid, "idx_usu_usuariorol_usuarioid");

            entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");
            entity.Property(e => e.Rolid).HasColumnName("rolid");
            entity.Property(e => e.Fechaasignacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaasignacion");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuUsuariorols)
                .HasForeignKey(d => d.Rolid)
                .HasConstraintName("usu_usuariorol_rolid_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuUsuariorols)
                .HasForeignKey(d => d.Usuarioid)
                .HasConstraintName("usu_usuariorol_usuarioid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
