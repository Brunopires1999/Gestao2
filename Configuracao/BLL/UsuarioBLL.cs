using Models;
using DAL;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class UsuarioBLL
    {
        private static void ValidarDados(Usuario _usuario, string _confirmacaoDeSenha)
        {
            //Todo: Validar se a senha é maior que 50 ou menor que 3 e se contém espaço
            if (_usuario.NomeUsuario.Length <= 3 || _usuario.NomeUsuario.Length >= 50)
            {
                throw new Exception("O nome de usuário deve ter entre 3 e 50 caracteres.");
            }
            if (_usuario.NomeUsuario.Contains(" "))
            {
                throw new Exception("O nome de usuário não pode conter espaços.");
            }
            //Todo: Validar se a senha é maior que 11 ou menor que 7
            if (_usuario.Senha.Length < 7 || _usuario.Senha.Length > 11)
            {
                throw new Exception("A senha deve ter entre 7 e 12 caracteres.");
            }

            //Todo: Validar se a senha não é 1234
            if (_usuario.Senha.Contains("1234567"))
            {
                throw new Exception("Não é permitido números em sequência.");
            }

            //Validar se as senhas são iguais
            if (_confirmacaoDeSenha != _usuario.Senha)
            {
                throw new Exception("O campo senha e a confirmação de senha não são iguais");
            }
        }

        public void Inserir(Usuario _usuario, string _confirmacaoDeSenha)
        {
            ValidarPermissao(2);
            //Todo: Validar se já existe um usuário com este nome.
            ValidarDados(_usuario, _confirmacaoDeSenha);

            Usuario usuario = new Usuario();
            usuario = BuscarPorIdUsuario(_usuario.Id);
            if (usuario.NomeUsuario == _usuario.NomeUsuario)
            {
                throw new Exception("Já existe um usuário com este nome");
            }

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);
        }

        public void Alterar(Usuario _usuario, string _confirmacaoDeSenha)
        {
            ValidarPermissao(3);
            ValidarDados(_usuario, _confirmacaoDeSenha);
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario);
        }

        public void Excluir(int _id)
        {
            ValidarPermissao(4);
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Excluir(_id);
        }

        public List<Usuario> BuscarTodos()
        {
            ValidarPermissao(1);
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarTodos();
        }

        public Usuario BuscarPorIdUsuario(int _IdUsuario)
        {
            ValidarPermissao(1);
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarPorIdUsuario(_IdUsuario);
        }

        public void AdicionarGrupo(int _Id, int _IdGrupoUsuario)
        {
            ValidarPermissao(10);
            if (new UsuarioDAL().ExisteRelacionamento(_Id, _IdGrupoUsuario))

                return;

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.AdicionarGrupo(_Id, _IdGrupoUsuario);
        }

        public void ValidarPermissao(int _IdDescricao)
        {
         //   if (!new UsuarioDAL().ValidarPermissao(Constantes.IdUsuarioLogado, _IdDescricao))
                throw new Exception("Você não tem permissão para executar esta operação.");
        }
    }
}