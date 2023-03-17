using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GrupoUsuarioDAL
    {
        public void Inserir(GrupoUsuario _grupousuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO GrupoUsuario(NomeGrupo)" +
                                  "VALUES (@nomegrupo)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@nomegrupo", _grupousuario.NomeGrupo);


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
        public List<GrupoUsuario> BuscarPorID(int _idGrupoUsuario)
        {
            GrupoUsuario grupo = new GrupoUsuario();
            List<GrupoUsuario> grupoUsuarios = new List<GrupoUsuario>();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"Select TOP 100 Id, GrupoUsuario from GrupoUsuario where Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdGrupoUsuario", _idGrupoUsuario);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupo = new GrupoUsuario();
                        //grupo.IdGrupoUsuario = Convert.ToInt32(rd["IdGrupoUsuario"]);
                        grupo.NomeGrupo = rd["GrupoUsuario"].ToString();
                        grupoUsuarios.Add(grupo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar grupo" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return grupoUsuarios;
        }

        public List<GrupoUsuario> BuscarTodosGrupos()
        {
            List<GrupoUsuario> grupo_usuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,GrupoUsuario FROM GrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.Id = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupousuario.NomeGrupo = rd["GrupoUsuario"].ToString();


                        grupo_usuarios.Add(grupousuario);
                    }
                }
                return grupo_usuarios;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar buscar Grupo de Usuarios: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        public void Alterar(GrupoUsuario _grupousuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE GrupoUsuario SET GrupoUsuario = @GrupoUsuario WHERE Id = @id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@GrupoUsuario", _grupousuario.NomeGrupo);
                cmd.Parameters.AddWithValue("@Id", _grupousuario.Id);


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

        public void Excluir(GrupoUsuario _idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM GrupoUsuario WHERE id_GrupoUsuario= @id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _idGrupoUsuario.Id);


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
    }
}
