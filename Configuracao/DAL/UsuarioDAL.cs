using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _usuario)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT INTO Usuario(Nome, NomeUsuario, CPF, Email, Senha, Ativo) 
                                    VALUES(@Nome, @NomeUsuario, @CPF, @Email, @Senha, @Ativo)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);

                cn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um usuário no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            Usuario usuario = new Usuario();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Id, Nome, CPF, Email, Ativo,NomeUsuario" +
                                    "FROM Usuario WHERE NomeUsuario = @NomeUsuario";

                cmd.Parameters.AddWithValue("@NomeUsuario", _nomeUsuario);
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                      
                      
                    }
                    else
                    {
                        throw new Exception("Usuário não encontrado.");
                    }
                }
                return usuario;
            }
           catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar fazer busca de usuário por Nome de Usuário: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public Usuario BuscarPorNomeAcesso(string _nome)
        {
            Usuario usuario = new Usuario();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT id_Usuario, nome, nome_Usuario, data_Nascimento, cpf_Usuario, email, ativo FROM Usuario  WHERE nome_Usuario = @nome";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", _nome);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["id_Usuario"]);
                        usuario.Nome = rd["nome"].ToString();
                        usuario.NomeUsuario = rd["nome_Usuario"].ToString();
                        usuario.CPF= rd["cpf_Usuario"].ToString();
                        usuario.Email = rd["email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["ativo"]);
                      
                       
                        


                    }
                    else
                    {
                        throw new Exception("Usuario não encontrado.");
                    }
                    return usuario;

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar buscar todos os usuários: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Usuario> BuscarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario;

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            
            
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Id, Nome, NomeUsuario, CPF, Email, Ativo 
                                    FROM Usuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        GrupoUsuarioDAL grupoUsuarioDAL = new GrupoUsuarioDAL();
                        usuario.GrupoUsuarios = grupoUsuarioDAL.BuscarPorID(usuario.Id); 
                        
                        usuarios.Add(usuario);
                    }
                }
                return usuarios;
            { 
                cn.Close();
            }
        }
       
        public void Alterar(Usuario _usuario)
        { 
         SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
                cmd.CommandText = "UPDATE Usuario SET nome = @nome,nome_Usuario = @nome_Usuario,data_Nascimento = @data_Nascimento," +
                    "cpf_Usuario = @cpf_Usuario,senha = @senha,email = @email,ativo = @ativo WHERE id_Usuario = @id";


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@nome_Usuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@cpf_Usuario", _usuario.CPF);
                cmd.Parameters.AddWithValue("@senha", _usuario.Senha);
                cmd.Parameters.AddWithValue("@email", _usuario.Email);
                cmd.Parameters.AddWithValue("@ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@id", _usuario.Id);

                cn.Open();
                cmd.ExecuteScalar();


            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um usuário no banco " + ex.Message);


}
            finally
{
    cn.Close();
}

        }

            
        
        public void Excluir(int _id)
        {

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Excluir(_id);
        }

        public bool ExisteRelacionamento()
        {
            throw new NotImplementedException();
        }
    }
}