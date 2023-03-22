
using Models;
using System;
using System.Collections.Generic;
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
                cmd.CommandText = @"Insert into Usuario(Nome, NomeUsuario, CPF, Email, Senha, Ativo) 
                                    Values(@Nome,@NomeUsuario,@CPF,@Email,@Senha,@Ativo)";

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
                throw new Exception("Ocorreu um erro ao tentar inserir um usuário no banco de dados: " + ex.Message);
            }
            finally
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
                cmd.CommandText = @"UPDATE Usuario SET Nome = @Nome, NomeUsuario = @NomeUsuario, CPF = @CPF, Email = @Email, Senha = @Senha, Ativo = @Ativo WHERE ID= @IdUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@IdUsuario", _usuario.Id);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar atualizar o cadastro de usuário no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"DELETE FROM Usuario WHERE ID = @ID";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);

                cn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar excluir o usuário no banco de dados: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Usuario> BuscarTodos()
        {
            SqlConnection cn = new SqlConnection();
            Usuario usuario;
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, Nome, NomeUsuario, Email, CPF, Ativo from Usuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        GrupoUsuarioDAL grupoUsuarioDAL = new GrupoUsuarioDAL();
                       // usuario.GrupoUsuarios = grupoUsuarioDAL.BuscarPorIDUsuario(usuario.Id);
                        usuarios.Add(usuario);
                    }
                }
                return usuarios;
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

        public Usuario BuscarPorIdUsuario(int _IdUsuario)
        {
            Usuario usuario = new Usuario();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"Select ID, Nome, NomeUsuario, CPF, Email, Ativo
                                   From Usuario Where ID = @ID";

                cmd.Parameters.AddWithValue("@ID", _IdUsuario);
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        GrupoUsuarioDAL grupoUsuarioDAL = new GrupoUsuarioDAL();
                        //usuario.GrupoUsuarios = grupoUsuarioDAL.BuscarPorIdUsuario(usuario.Id);
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar usuário: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void AdicionarGrupo(int id, int idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT INTO UsuarioGrupoUsuario(Cod_Usuario, Cod_GrupoUsuario) VALUES (@Cod_Usuario, @Cod_GrupoUsuario)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Cod_Usuario", id);
                cmd.Parameters.AddWithValue("@Cod_GrupoUsuario", idGrupoUsuario);

                cn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um grupo no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public bool ExisteRelacionamento(int id, int idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Usuario usuario = new Usuario();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT 1 AS Retorno From UsuarioGrupoUsuario where Cod_Usuario = @Cod_Usuario and Cod_GrupoUsuario = @Cod_GrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Cod_Usuario", id);
                cmd.Parameters.AddWithValue("@Cod_GrupoUsuario", idGrupoUsuario);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um grupo no banco: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public bool ValidarPermissao(int _IdUsuario, int _IdDescricao)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT TOP 1 1 AS Resultado FROM UsuarioGrupoUsuario
                                    INNER JOIN PermissaoGrupoUsuario 
                                    ON UsuarioGrupoUsuario.Cod_GrupoUsuario = PermissaoGrupoUsuario.Cod_GrupoUsuario
                                    WHERE UsuarioGrupoUsuario.Cod_Usuario = @Cod_Usuario
                                    AND PermissaoGrupoUsuario.Cod_Descricao = @Cod_Descricao";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Cod_Usuario", _IdUsuario);
                cmd.Parameters.AddWithValue("@Cod_Descricao", _IdDescricao);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar validar permissão do usuário: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
    }
}

