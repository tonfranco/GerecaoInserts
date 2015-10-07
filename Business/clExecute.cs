using System;
using System.Collections.Generic;
using System.Text;
using Persistencia.Classes;

namespace Business
{
    public class clExecute
    {
        private string _strUser = string.Empty;
        private string _strPWD = string.Empty;
        private string _strServerName = string.Empty;
        private clDataAccess _objDataAccess = null;
        private string strTemplateWindowsAut = @"Data Source={0};";
        private string strTemplateSqlAut = @"Data Source={0};User ID={1};PWD={2};Initial Catalog={3}";
        private string _strQuery = string.Empty;
        private string _strDataBase = string.Empty;
        private bool bSqlAuthentication = false;


        public string DataBase
        {
            get { return _strDataBase; }
            set { _strDataBase = value; }
        }

        public bool SqlAuthentication
        {
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


        public bool execute()
        {


            if (SqlAuthentication)
                strTemplateSqlAut = string.Format(strTemplateSqlAut, _strServerName, _strUser, _strPWD,_strDataBase);
            else
                strTemplateSqlAut = string.Format(strTemplateWindowsAut, _strServerName);


            _objDataAccess = new clDataAccess(strTemplateSqlAut);
            bool bRet = false;

            try
            {
                bRet = _objDataAccess.executaQuery(_strQuery, clDataAccess.TipoBanco.SQLServer);
            }
            catch (Exception ex)
            {
                bRet = false;
                throw ex;
            }
            finally
            {
                _objDataAccess = null;
            }
            return bRet;
        }
    }
}
