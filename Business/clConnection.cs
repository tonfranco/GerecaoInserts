using System;
using System.Collections.Generic;
using System.Text;
using Persistencia.Classes;

namespace Business
{
    public class clConnection
    {
        private string _strUser = string.Empty;
        private string _strPWD = string.Empty;
        private string _strServerName = string.Empty;
        private clDataAccess _objDataAccess = null;
        private string strTemplateWindowsAut = @"Data Source={0};";
        private string strTemplateSqlAut = @"Data Source={0};User ID={1};PWD={2};";

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

        public enum ConnectionType
        {
            WindowsAuthentication = 1,
            SQLAuthentication = 2
        }

        public bool connection(ConnectionType connectionType)
        {
            bool bRet = false;

            try
            {
                switch (connectionType)
                {
                    case ConnectionType.WindowsAuthentication:
                        _objDataAccess = new clDataAccess(string.Format(strTemplateWindowsAut, _strServerName));
                        bRet = _objDataAccess.verificaConnexao(clDataAccess.TipoBanco.SQLServer);
                        break;
                    case ConnectionType.SQLAuthentication:
                        _objDataAccess = new clDataAccess(string.Format(strTemplateSqlAut, _strServerName, _strUser, _strPWD));
                        bRet = _objDataAccess.verificaConnexao(clDataAccess.TipoBanco.SQLServer);
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

            return bRet;
        }
    }
}
