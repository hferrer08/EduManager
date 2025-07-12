using System;
using System.Collections.Generic;

namespace EduManagerAPI.Models;

public partial class UsuRol
{
    public int Rolid { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<UsuUsuariorol> UsuUsuariorols { get; set; } = new List<UsuUsuariorol>();
}
