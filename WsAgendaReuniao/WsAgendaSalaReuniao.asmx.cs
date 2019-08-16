using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace WsAgendaReuniao
{
    /// <summary>
    /// Descrição resumida de WsAgendaSalaReuniao
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    [System.Web.Script.Services.ScriptService]
    public class WsAgendaSalaReuniao : System.Web.Services.WebService
    {

        [WebMethod]
        public void getFuncionarios()
        {
            List<Funcionarios> listaFuncionarios = new List<Funcionarios>();
            string cs = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Funcionarios", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Funcionarios func = new Funcionarios();
                    func.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                    func.Nome = dr["Nome"].ToString();
                    func.Setor = dr["Setor"].ToString();
                    func.Cargo = dr["Cargo"].ToString();

                    listaFuncionarios.Add(func);
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(listaFuncionarios));
            }
        }

        [WebMethod]
        public void getSalas()
        {
            List<Salas> listaSalas = new List<Salas>();
            string cs = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Salas", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Salas sl = new Salas();
                    sl.IdSala = Convert.ToInt32(dr["IdSala"]);
                    sl.NomeSala = dr["NomeSala"].ToString();

                    listaSalas.Add(sl);
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(listaSalas));
            }
        }

        [WebMethod]
        public void getPeriodos()
        {
            List<Periodos> listaPeriodos = new List<Periodos>();
            string cs = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Periodos", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Periodos pr = new Periodos();
                    pr.IdPeriodo = Convert.ToInt32(dr["IdPeriodo"]);
                    pr.NomePeriodo = dr["NomePeriodo"].ToString();

                    listaPeriodos.Add(pr);
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(listaPeriodos));
            }
        }

        [WebMethod]
        public void getReservas()
        {
            List<Reservas> listaReservas = new List<Reservas>();
            string cs = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT *
                                                    FROM dbo.Reservas R
                                                   ORDER BY R.DtReservada, R.DtDaReserva, R.Sala, R.Periodo, R.Funcionario", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Reservas rv = new Reservas();
                    rv.IdReserva = Convert.ToInt32(dr["IdReserva"]);
                    rv.DtDaReserva = Convert.ToDateTime(dr["DtDaReserva"]);
                    rv.DtReservada = Convert.ToDateTime(dr["DtReservada"]);
                    rv.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                    rv.IdPeriodo = Convert.ToInt32(dr["IdPeriodo"]);
                    rv.IdSala = Convert.ToInt32(dr["IdSala"]);
                    rv.Funcionario = dr["Funcionario"].ToString();
                    rv.Periodo = dr["Periodo"].ToString();
                    rv.Sala = dr["Sala"].ToString();

                    listaReservas.Add(rv);
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(listaReservas));
            }
        }

        [WebMethod]
        public void getValidaReserva()
        {
            List<Salas> listaSalas = new List<Salas>();
            string cs = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Salas", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Salas sl = new Salas();
                    sl.IdSala = Convert.ToInt32(dr["IdSala"]);
                    sl.NomeSala = dr["NomeSala"].ToString();

                    listaSalas.Add(sl);
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(listaSalas));
            }
        }

        [WebMethod]
        public void getAgendamentos()
        {
            List<Funcionarios> listaFuncionarios = new List<Funcionarios>();
            string cs = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Funcionarios", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Funcionarios func = new Funcionarios();
                    func.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                    func.Nome = dr["Nome"].ToString();
                    func.Setor = dr["Setor"].ToString();
                    func.Cargo = dr["Cargo"].ToString();

                    listaFuncionarios.Add(func);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listaFuncionarios));

            List<Salas> listaSalas = new List<Salas>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Salas", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Salas sl = new Salas();
                    sl.IdSala = Convert.ToInt32(dr["IdSala"]);
                    sl.NomeSala = dr["NomeSala"].ToString();

                    listaSalas.Add(sl);
                }
            }
            Context.Response.Write(js.Serialize(listaSalas));

            List<Periodos> listaPeriodos = new List<Periodos>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Periodos", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Periodos pr = new Periodos();
                    pr.IdPeriodo = Convert.ToInt32(dr["IdPeriodo"]);
                    pr.NomePeriodo = dr["NomePeriodo"].ToString();

                    listaPeriodos.Add(pr);
                }
            }
            Context.Response.Write(js.Serialize(listaPeriodos));

            List<Reservas> listaReservas = new List<Reservas>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT R.DtReservada, R.DtDaReserva, S.NomeSala, P.NomePeriodo, F.Nome
                                                    FROM dbo.Reservas R
                                                   INNER JOIN Funcionarios F ON F.IdFuncionario = R.IdFuncionario
                                                   INNER JOIN Salas S ON S.IdSala = R.IdSala
                                                   INNER JOIN Periodos P ON P.IdPeriodo = R.IdPeriodo
                                                   ORDER BY R.DtReservada, R.DtDaReserva, S.NomeSala, P.NomePeriodo, F.Nome", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Reservas rv = new Reservas();
                    rv.DtDaReserva = Convert.ToDateTime(dr["DtDaReserva"]);
                    rv.DtReservada = Convert.ToDateTime(dr["DtReservada"]);
                    rv.Funcionario = dr["Nome"].ToString();
                    rv.Periodo = dr["NomePeriodo"].ToString();
                    rv.Sala = dr["NomeSala"].ToString();

                    listaReservas.Add(rv);
                }
            }

            Context.Response.Write(js.Serialize(listaReservas));
        }

        [WebMethod]
        public void PostReservas(string dtReservada, string idfuncionario, string idsala, string idperiodo)
        {
            DateTime DtReservada = Convert.ToDateTime(dtReservada);
            int idFuncionario = Convert.ToInt32(idfuncionario);
            int idSala = Convert.ToInt32(idsala);
            int idPeriodo = Convert.ToInt32(idperiodo);
            string funcionario;
            string sala;
            string periodo;
            string message = "Funcionário não encontrado. Favor tentar novamente.";

            SqlCommand cmd;
            SqlDataReader dr;

            List<Reservas> listaReservas = new List<Reservas>();
            string cs = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            SqlConnection con;

            using (con = new SqlConnection(cs))
            {
                cmd = new SqlCommand(@"SELECT Nome FROM Funcionarios WHERE IdFuncionario = " + idFuncionario.ToString(), con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                funcionario = dr["Nome"].ToString();
            }

            if (!string.IsNullOrEmpty(funcionario))
            {
                using (con = new SqlConnection(cs))
                {
                    cmd = new SqlCommand(@"SELECT NomeSala FROM Salas WHERE IdSala = " + idSala.ToString(), con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    sala = dr["NomeSala"].ToString();
                }

                if (!string.IsNullOrEmpty(sala))
                {
                    using (con = new SqlConnection(cs))
                    {
                        cmd = new SqlCommand(@"SELECT NomePeriodo FROM Periodos WHERE IdPeriodo = " + idPeriodo.ToString(), con);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        periodo = dr["NomePeriodo"].ToString();
                    }
                    string sql = @"INSERT INTO Reservas (DtDaReserva,DtReservada,IdFuncionario,Funcionario,IdSala,Sala,IdPeriodo,Periodo)
                                                  VALUES( CONVERT(DATE, GETDATE(),10), CONVERT(DATE, @DtReservada, 10), @idFuncionario ,
                                                  @funcionario, @idSala, @sala, @idPeriodo, @periodo)";

                    con = new SqlConnection(cs);
                    int i;

                    try
                    {
                        //Cria uma objeto do tipo comando passando como 
                        SqlCommand comando = new SqlCommand(sql, con);
                        //Adicionando o valor das textBox nos parametros do comando
                        comando.Parameters.Add(new SqlParameter("@DtReservada", DtReservada));
                        comando.Parameters.Add(new SqlParameter("@idFuncionario", idFuncionario));
                        comando.Parameters.Add(new SqlParameter("@idSala", idSala));
                        comando.Parameters.Add(new SqlParameter("@idPeriodo", idPeriodo));
                        comando.Parameters.Add(new SqlParameter("@funcionario", funcionario));
                        comando.Parameters.Add(new SqlParameter("@sala", sala));
                        comando.Parameters.Add(new SqlParameter("@periodo", periodo));
                        //abre a conexao
                        con.Open();
                        //executa o comando com os parametros que foram adicionados acima
                        i = comando.ExecuteNonQuery();
                        //fecha a conexao
                        con.Close();
                    }
                    catch (Exception e)
                    {
                        message = e.ToString();
                    }
                    finally
                    {
                        con.Close();
                    }

                    con = new SqlConnection(cs);
                    cmd = new SqlCommand(@"SELECT R.DtReservada, R.DtDaReserva, S.NomeSala, P.NomePeriodo, F.Nome
                                                    FROM dbo.Reservas R
                                                   INNER JOIN Funcionarios F ON F.IdFuncionario = R.IdFuncionario
                                                   INNER JOIN Salas S ON S.IdSala = R.IdSala
                                                   INNER JOIN Periodos P ON P.IdPeriodo = R.IdPeriodo
                                                   ORDER BY R.DtReservada, R.DtDaReserva, S.NomeSala, P.NomePeriodo, F.Nome", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Reservas rv = new Reservas();
                        rv.DtDaReserva = Convert.ToDateTime(dr["DtDaReserva"]);
                        rv.DtReservada = Convert.ToDateTime(dr["DtReservada"]); ;
                        rv.Funcionario = dr["Nome"].ToString();
                        rv.Periodo = dr["NomePeriodo"].ToString();
                        rv.Sala = dr["NomeSala"].ToString();

                        listaReservas.Add(rv);
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(message));
                    Context.Response.Write(js.Serialize(listaReservas));
                }
            }
        }
    }
}
