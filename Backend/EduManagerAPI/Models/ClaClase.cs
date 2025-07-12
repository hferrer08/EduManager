using System;
using System.Collections.Generic;

namespace EduManagerAPI.Models;

public partial class ClaClase
{
    public int Claseid { get; set; }

    public int? Cursoid { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly? Fechaclase { get; set; }

    public int? Duracionminutos { get; set; }

    public virtual CurCurso? Curso { get; set; }
}
