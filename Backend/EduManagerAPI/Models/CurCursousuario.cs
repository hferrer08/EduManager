using System;
using System.Collections.Generic;

namespace EduManagerAPI.Models;

public partial class CurCursousuario
{
    public int Cursoid { get; set; }

    public int Usuarioid { get; set; }

    public string? Estado { get; set; }

    public DateTime? Fechaasignacion { get; set; }

    public virtual CurCurso Curso { get; set; } = null!;

    public virtual GenUsuario Usuario { get; set; } = null!;
}
