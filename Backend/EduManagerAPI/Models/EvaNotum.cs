using System;
using System.Collections.Generic;

namespace EduManagerAPI.Models;

public partial class EvaNotum
{
    public int Notaid { get; set; }

    public int? Evaluacionid { get; set; }

    public int? Usuarioid { get; set; }

    public decimal? Puntajeobtenido { get; set; }

    public string? Comentarios { get; set; }

    public DateTime? Fechacalificacion { get; set; }

    public virtual EvaEvaluacion? Evaluacion { get; set; }

    public virtual GenUsuario? Usuario { get; set; }
}
