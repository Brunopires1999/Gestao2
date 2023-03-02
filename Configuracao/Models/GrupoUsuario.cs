using System.Collections.Generic;

namespace Models
{
    public class GrupoUsuario
    {
        public string NomeGrupo { get; set; }
        public List<Permissao> Permissoes { get; set; }
    }
}