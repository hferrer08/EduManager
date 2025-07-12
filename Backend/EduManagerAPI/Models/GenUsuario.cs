using System;
using System.Collections.Generic;

namespace EduManagerAPI.Models;

public partial class GenUsuario
{
    public int Usuarioid { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseñahash { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual ICollection<CurCurso> CurCursos { get; set; } = new List<CurCurso>();

    public virtual ICollection<CurCursousuario> CurCursousuarios { get; set; } = new List<CurCursousuario>();

    public virtual ICollection<EvaNotum> EvaNota { get; set; } = new List<EvaNotum>();

    public virtual ICollection<UsuUsuariorol> UsuUsuariorols { get; set; } = new List<UsuUsuariorol>();
}
