using System;

using System.Data.SqlClient;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace PutUserDataTool
{
    public class SqlUtils
    {
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : Hirose</br>
        /// <br>Date       : 2015/03/19</br>
        /// </remarks>
        public static SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            string connectionText = GetConnectionString();

            if (connectionText == null || connectionText == String.Empty) return null;

            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }

        /// <summary>
        /// PMCまたはLSMよりユーザーDBへの接続文字列取得
        /// </summary>
        /// <returns>ユーザーDB接続文字列</returns>
        public static string GetConnectionString()
        {
            string connectionText = String.Empty;

            //接続文字列取得
            LoginInfoAcquisition clientSqlConnectionInfo = new LoginInfoAcquisition();
            connectionText = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_UserAP, ConstantManagement_SF_PRO.IndexCode_UserDB);

            return connectionText;
        }

        /// <summary>
        /// SqlConnection解放
        /// 例外は全て無視
        /// </summary>
        /// <param name="connection"></param>
        public static void CloseQuietly(SqlConnection connection)
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch
            {
                //ignore
            }
        }

        /// <summary>
        /// SqlCommand解放
        /// 例外は全て無視
        /// </summary>
        /// <param name="command"></param>
        public static void CloseQuietly(SqlCommand command)
        {
            try
            {
                if (command != null)
                {
                    command.Dispose();
                }
            }
            catch
            {
                //ignore
            }
        }

        /// <summary>
        /// SqlDataReader解放
        /// 例外は全て無視
        /// </summary>
        /// <param name="reader"></param>
        public static void CloseQuietly(SqlDataReader reader)
        {
            try
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            catch
            {
                //ignore
            }
        }
    }
}
