using System;
using System.Collections.Generic;

namespace EduManagerAPI.Models;

public partial class EvaEvaluacion
{
    public int Evaluacionid { get; set; }

    public int? Cursoid { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly? Fechapublicacion { get; set; }

    public DateOnly? Fechaentrega { get; set; }

    public string? Tipo { get; set; }

    public virtual CurCurso? Curso { get; set; }

    public virtual ICollection<EvaNotum> EvaNota { get; set; } = new List<EvaNotum>();
}
