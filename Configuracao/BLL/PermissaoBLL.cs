using Models;
using DAL;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermissaoBLL
    {
        public void Inserir(Permissao _permissao)
        {
            if (_permissao.Descricao.Length < 4 || _permissao.Descricao.Length > 145)
            {
                throw new Exception("Descrição pequena(menos de 4 caracteres) ou grande (mais de 145 caracteres ");
            }

            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Inserir(_permissao);
        }

        public List<Permissao> BuscarTodasPermissoes()
        {
            PermissaoDAL permissaoDAL = new PermissaoDAL();
            return permissaoDAL.BuscarTodasPermissoes();
        }

        public void Alterar(Permissao _permissao)
        {
            if (_permissao.Descricao.Length < 4 || _permissao.Descricao.Length > 145)
            {
                throw new Exception("Descrição pequena(menos de 4 caracteres) ou grande (mais de 145 caracteres ");
            }

            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Alterar(_permissao);

        }
        public void Excluir(Permissao _id)
        {
            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Excluir(_id);
        }
    }
}
