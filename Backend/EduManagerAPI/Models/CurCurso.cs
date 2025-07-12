using System;
using System.Collections.Generic;

namespace EduManagerAPI.Models;

public partial class CurCurso
{
    public int Cursoid { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly? Fechainicio { get; set; }

    public DateOnly? Fechafin { get; set; }

    public bool? Activo { get; set; }

    public int? Creadoporusuarioid { get; set; }

    public virtual ICollection<ClaClase> ClaClases { get; set; } = new List<ClaClase>();

    public virtual GenUsuario? Creadoporusuario { get; set; }

    public virtual ICollection<CurCursousuario> CurCursousuarios { get; set; } = new List<CurCursousuario>();

    public virtual ICollection<EvaEvaluacion> EvaEvaluacions { get; set; } = new List<EvaEvaluacion>();
}
