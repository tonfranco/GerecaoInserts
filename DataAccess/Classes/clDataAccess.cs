using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Windows.Forms;


namespace Persistencia.Classes
{
    public class clDataAccess
    {
        #region Enum com os tipos de Banco
        public enum TipoBanco
        {
            SQLServer = 0,
            Oracle = 1,
            OLDB = 2
        }
        #endregion

        #region Variáveis Globais
        //private string strConnStringSQL = @"Data Source=.;INITIAL CATALOG=teste;USER ID=sa;PWD=toncs";
        private string _strConnStringSQL = @"Data Source=D4010S001E869\SQL2000;INITIAL CATALOG=BOOK_RELATORIO_DEV;USER ID=sa;PWD=super";
        private string strConnStringOracle = @"Data Source=D4010S001E869\SQL2000;INITIAL CATALOG=BOOK_RELATORIO_DEV;USER ID=sa;PWD=super";
        private string strConnStringOLDB = @"Data Source=D4010S001E869\SQL2000;INITIAL CATALOG=BOOK_RELATORIO_DEV;USER ID=sa;PWD=super";
        #endregion

        #region Construtor
        public clDataAccess(string strConnectionString)
        {
            try
            {
                _strConnStringSQL = strConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public clDataAccess()
        {

        }
        #endregion

        #region Método Genérico de Execução de Query
        /// <summary>
        /// Método genérico que chama os métodos correspondentes ao Tipo do Banco para execução do comando.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tipoBanco"></param>
        /// <returns>Se o número de linhas afetadas for maior que 0 retorna TRUE</returns>
        public bool executaQuery(string query, TipoBanco tipoBanco)
        {
            Application.DoEvents();
            bool bRet = false;

            try
            {
                switch (tipoBanco)
                {
                    case TipoBanco.SQLServer:
                        bRet = executaQuerySQL(query);
                        break;
                    case TipoBanco.Oracle:
                        bRet = executaQueryOracle(query);
                        break;
                    case TipoBanco.OLDB:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                bRet = false;
                throw ex;
            }
            finally
            {

            }
            return bRet;
        }
        #endregion

        #region Execução de Query no Banco SQL
        /// <summary>
        /// Método responsável por executar o Comando passado por parâmetro no Banco SQL Server
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Se o número de linhas afetadas for maior que 0 retorna TRUE</returns>
        private bool executaQuerySQL(string query)
        {
            Application.DoEvents();
            bool bRet = false;
            SqlConnection sqlConn = null;
            SqlCommand cmd = null;
            try
            {
                using (sqlConn = new SqlConnection(_strConnStringSQL))
                {
                    using (cmd = new SqlCommand(query, sqlConn))
                    {
                        sqlConn.Open();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandTimeout = 6000;
                        if (cmd.ExecuteNonQuery() > 0)
                            bRet = true;
                        else
                            bRet = false;
                    }
                }
            }
            catch (Exception ex)
            {
                bRet = false;
                throw ex;
            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed)
                    sqlConn.Close();

                if (cmd != null)
                    cmd.Dispose();
            }
            return bRet;

        }
        #endregion

        #region Execução de Query no Banco Oracle
        /// <summary>
        /// Método responsável por executar o Comando passado por parâmetro no Banco ORACLE
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Se o número de linhas afetadas for maior que 0 retorna TRUE</returns>
        private bool executaQueryOracle(string query)
        {
            bool bRet = false;
            OracleConnection orlConn = null;
            OracleCommand cmd = null;
            try
            {
                using (orlConn = new OracleConnection(strConnStringOracle))
                {
                    using (cmd = new OracleCommand(query, orlConn))
                    {
                        orlConn.Open();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandTimeout = 6000;
                        if (cmd.ExecuteNonQuery() > 0)
                            bRet = true;
                        else
                            bRet = false;
                    }
                }
            }
            catch (Exception ex)
            {
                bRet = false;
                throw ex;
            }
            finally
            {
                if (orlConn.State != System.Data.ConnectionState.Closed)
                    orlConn.Close();

                if (cmd != null)
                    cmd.Dispose();
            }
            return bRet;
        }
        #endregion

        #region Método Genérico de Execução de Select
        /// <summary>
        /// Método genérico que chama os métodos correspondentes ao Tipo do Banco para execução do SELECT.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tipoBanco"></param>
        /// <returns>DataTable com o resultado do Select</returns>
        public DataTable executaQueryPesquisa(string query, TipoBanco tipoBanco)
        {
            Application.DoEvents();
            DataTable dtRet = null;
            try
            {
                switch (tipoBanco)
                {
                    case TipoBanco.SQLServer:
                        dtRet = executaPesquisaSQL(query);
                        break;
                    case TipoBanco.Oracle:
                        dtRet = executaPesquisaOracle(query);
                        break;
                    case TipoBanco.OLDB:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRet;
        }
        #endregion

        #region Método responsável por executar o Select no Banco SQL Server
        /// <summary>
        /// Método responsável por executar o Select passado por parâmetro, no Banco SQL Server
        /// </summary>
        /// <param name="query"></param>
        /// <returns>DataTable com o resultado do Select</returns>
        private DataTable executaPesquisaSQL(string query)
        {
            SqlConnection sqlConn = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                using (sqlConn = new SqlConnection(_strConnStringSQL))
                {
                    using (cmd = new SqlCommand(query, sqlConn))
                    {
                        using (da = new SqlDataAdapter(cmd))
                        {
                            using (dt = new DataTable())
                            {
                                sqlConn.Open();
                                cmd.CommandType = System.Data.CommandType.Text;
                                // cmd.CommandTimeout = 6000;
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed)
                    sqlConn.Close();

                if (cmd != null)
                    cmd.Dispose();
            }
        }
        #endregion

        #region Método responsável por executar o Select no Banco ORACLE
        /// <summary>
        /// Método responsável por executar o Select passado por parâmetro no Banco ORACLE
        /// </summary>
        /// <param name="query"></param>
        /// <returns>DataTable com o resultado do Select</returns>
        private DataTable executaPesquisaOracle(string query)
        {
            OracleConnection orclConn = null;
            OracleCommand cmd = null;
            OracleDataAdapter da = null;
            DataTable dt = null;
            try
            {
                using (orclConn = new OracleConnection(strConnStringOracle))
                {
                    using (cmd = new OracleCommand(query, orclConn))
                    {
                        using (da = new OracleDataAdapter(cmd))
                        {
                            using (dt = new DataTable())
                            {
                                orclConn.Open();
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.CommandTimeout = 6000;
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (orclConn.State != System.Data.ConnectionState.Closed)
                    orclConn.Close();

                if (cmd != null)
                    cmd.Dispose();
            }
        }
        #endregion

        #region Método responsável por executar o Select (OLDB)
        /// <summary>
        /// Método responsável por executar o Select passado por parâmetro. Conexão OLDB
        /// </summary>
        /// <param name="query"></param>
        /// <returns>DataTable com o resultado do Select</returns>
        private DataTable executaPesquisaOLDB(string query)
        {
            OleDbConnection OLDBConn = null;
            OleDbCommand cmd = null;
            OleDbDataAdapter da = null;
            DataTable dt = null;
            try
            {
                using (OLDBConn = new OleDbConnection(strConnStringOLDB))
                {
                    using (cmd = new OleDbCommand(query, OLDBConn))
                    {
                        using (da = new OleDbDataAdapter(cmd))
                        {
                            using (dt = new DataTable())
                            {
                                OLDBConn.Open();
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.CommandTimeout = 6000;
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (OLDBConn.State != System.Data.ConnectionState.Closed)
                {
                    OLDBConn.Close();
                    OLDBConn.Dispose();
                }

                if (cmd != null)
                    cmd.Dispose();
            }
        }
        #endregion

        #region Executa Procedure.
        /// <summary>
        /// Método genérico que chama os métodos correspondentes ao Tipo do Banco para execução da Procedure.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tipoBanco"></param>
        /// <returns></returns>
        public bool executaProc(string nameProc, TipoBanco tipoBanco, object[] values, string[] parametros, SqlDbType[] sqlDBType)
        {
            bool bRet = false;
            try
            {
                switch (tipoBanco)
                {
                    case TipoBanco.SQLServer:
                        bRet = executaProcSQL(nameProc, values, parametros, sqlDBType);
                        break;
                    case TipoBanco.Oracle:
                        break;
                    case TipoBanco.OLDB:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                bRet = false;
                throw ex;
            }
            finally
            {

            }
            return bRet;
        }
        #endregion

        #region Executa Procedure no Banco SQL.
        /// <summary>
        /// Método responsável por executar Procedure. Banco SQL
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private bool executaProcSQL(string nameProc, object[] values, string[] parametros, SqlDbType[] sqlDBType)
        {
            if (values.Length != parametros.Length)//Número de valores e de parâmetros devem ser iguais
                return false;

            SqlConnection sqlConn = null;
            SqlCommand cmd = null;

            bool bRet = false;
            try
            {
                using (sqlConn = new SqlConnection(_strConnStringSQL))
                {
                    using (cmd = new SqlCommand(nameProc, sqlConn))
                    {
                        sqlConn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < parametros.Length; i++)
                            cmd.Parameters.Add(string.Format("{0}", parametros[i]), sqlDBType[i]);

                        for (int i = 0; i < values.Length; i++)
                            cmd.Parameters[i].Value = values[i];

                        if (cmd.ExecuteNonQuery() > 0)
                            bRet = true;
                        else
                            bRet = false;
                    }
                }
            }
            catch (Exception ex)
            {
                bRet = false;
                throw ex;
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                    sqlConn.Close();
            }
            return bRet;
        }
        #endregion
        
        #region Método que verifica conexão
        /// <summary>
        /// Método genérico que verifica conexão de acordo com o Banco(sql, oracle, etc.)
        /// </summary>
        /// <param name="strConnection"></param>
        /// <param name="tipoBanco"></param>
        /// <returns></returns>
        public bool verificaConnexao(TipoBanco tipoBanco)
        {
            bool bRet = false;

            try
            {
                switch (tipoBanco)
                {
                    case TipoBanco.SQLServer:
                        bRet = verificaConexaoSQL();
                        break;
                    case TipoBanco.Oracle:
                        break;
                    case TipoBanco.OLDB:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                bRet = false;
                throw;
            }
            return bRet;
        }
        #endregion
        
        #region Método que verifica conexão SQL Server
        /// <summary>
        /// Método responsável por verificar conexão no banco SQL.
        /// </summary>
        /// <param name="strConnection"></param>
        /// <returns></returns>
        private bool verificaConexaoSQL()
        {
            bool bRet = false;
            SqlConnection cn = null;

            try
            {
                using (cn = new SqlConnection(_strConnStringSQL))
                {
                    cn.Open();
                    if (cn.State != ConnectionState.Closed)
                        cn.Close();

                    bRet = true;
                }
            }
            catch (Exception ex)
            {
                bRet = false;
                throw ex;
            }
            return bRet;
        }
        #endregion
    }
}
