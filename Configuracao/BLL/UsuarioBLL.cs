using DAL;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir(Usuario _usuario, string _confirmacaoDeSenha)
        {
            ValidarDados(_usuario, _confirmacaoDeSenha); //TODO: corrigir erro e fazer validação com if add modificacao formbuscarusuario

            Usuario usuario = new Usuario();
            usuario = BuscarPorNomeUsuario(_usuario.NomeUsuario);
            if (usuario.NomeUsuario == _usuario.NomeUsuario)
                throw new Exception("Já existe um usuário com este nome");

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);
        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            if (String.IsNullOrEmpty(_nomeUsuario))
                throw new Exception("Informe o nome do usuário.");

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarPorNomeUsuario(_nomeUsuario);
        }
        public List<Usuario> BuscarTodos()
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarTodos();
        }
        public Usuario BuscarUsuarioPorNome(string _nome_busca)
        {
            if (String.IsNullOrEmpty(_nome_busca))
            {
                throw new Exception("Informe o nome do usuário");
            }
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarPorNomeUsuario(_nome_busca);

        }


        public Usuario BuscarPorNomeAcesso(string _nome_busca)
        {
            if (String.IsNullOrEmpty(_nome_busca))
            {
                throw new Exception("Informe o nome do usuário");
            }
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarPorNomeAcesso(_nome_busca);

        }
        
        public void Alterar(Usuario _alterarUsuario)
        {
            if (_alterarUsuario.NomeUsuario.Length <= 3 || _alterarUsuario.NomeUsuario.Length > 50) // length conta o numero de caracteres
            {
                throw new Exception("O nome de usuário deve ter mais de três caracteres.");
                //TODO:verificar se ja existe um usuário com este nome
            }

            if (_alterarUsuario.NomeUsuario.Contains(" ")) // Contains verifica se tem o caracteres dentro do parenteses no caso foi space
            {
                throw new Exception("O nome do usuário não pode ter espaços");

            }

            if (_alterarUsuario.Senha.Contains("1234567"))
            {
                throw new Exception("Não é permitido números em sequência");
            }

            if (_alterarUsuario.Senha.Length < 7 || _alterarUsuario.Senha.Length > 11)
            {
                throw new Exception("A senha deve ter entre 7 e 11 caracteres.");
            }


            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_alterarUsuario);
        }
        private static void ValidarDados(Usuario _usuario, string _confirmacaoDeSenha)
        {
            if (_usuario.NomeUsuario.Length <= 3 || _usuario.NomeUsuario.Length >= 50)
                throw new Exception("O nome de usuário deve ter mais de três caracteres.");

            if (_usuario.NomeUsuario.Contains(" "))
                throw new Exception("O nome de usuário não pode conter espaço");

            if (_usuario.Senha.Contains("1234567"))
                throw new Exception("Não é permitido um número sequencial.");

            if (_usuario.Senha.Length < 7 || _usuario.Senha.Length > 11)
                throw new Exception("A senha deve ter entre 7 e 11 caracteres.");
        }
        public void Excluir(int _id)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Excluir(_id);
        }
        public void AdicionarGrupo(int _idUsuario, int _idGrupoUsuario)
        {
            if (new UsuarioDAL().ExisteRelacionamento(_idUsuario, _idGrupoUsuario))
            {
                return;
            }
        }
    }
}