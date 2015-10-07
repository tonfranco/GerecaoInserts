using System;
using System.Collections.Generic;
using System.Text;
using Persistencia.Classes;
using System.Data;

namespace Business
{
    public class clLoadData
    {
        private string _strUser = string.Empty;  
        private string _strPWD = string.Empty;
        private string _strServerName = string.Empty;
        private clDataAccess _objDataAccess = null;
        private string strTemplateWindowsAut = @"Data Source={0};";
        private string strTemplateSqlAut = @"Data Source={0};User ID={1};PWD={2};";
        private string _strQuery = string.Empty;
        private bool bSqlAuthentication = false;

        public bool SqlAuthentication
        {      //teste
            get { return bSqlAuthentication; }
            set { bSqlAuthentication = value; }
        }

        public string Query
        {
            get { return _strQuery; }
            set { _strQuery = value; }
        }

        public string User
        {
            get { return _strUser; }
            set { _strUser = value; }
        }

        public string PWD
        {
            get { return _strPWD; }
            set { _strPWD = value; }
        }

        public string ServerName
        {
            get { return _strServerName; }
            set { _strServerName = value; }
        }

        public DataTable loadData()
        {
            DataTable dtRet = null;
            string strConn = string.Empty;

            if (bSqlAuthentication)
                strConn = string.Format(strTemplateSqlAut, _strServerName, _strUser, _strPWD);
            else
                strConn = string.Format(strTemplateWindowsAut, _strServerName);

            _objDataAccess = new clDataAccess(strConn);

            try
            {
                dtRet = _objDataAccess.executaQueryPesquisa(_strQuery, clDataAccess.TipoBanco.SQLServer);
            }
            catch (Exception ex)
            {
                dtRet = null;
                throw ex;
            }
            return dtRet;
        }

    }
}
