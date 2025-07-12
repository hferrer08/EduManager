using System;
using System.Collections.Generic;

namespace EduManagerAPI.Models;

public partial class UsuUsuariorol
{
    public int Usuarioid { get; set; }

    public int Rolid { get; set; }

    public DateTime? Fechaasignacion { get; set; }

    public virtual UsuRol Rol { get; set; } = null!;

    public virtual GenUsuario Usuario { get; set; } = null!;
}
