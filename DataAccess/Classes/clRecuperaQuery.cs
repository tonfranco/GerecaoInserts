using System;
using System.Collections.Generic;
using System.Text;
using Persistencia.Classes;
using System.Configuration;
using DataAccess.Classes;

namespace Persistencia.Queries
{
    public class clRecuperaQuery
    {

        public static string recuperaQuery(string queryName)
        {
            string strQuery = string.Empty;

            try
            {
                strQuery = queries.ResourceManager.GetString(queryName);  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strQuery;
        }
    }
}
