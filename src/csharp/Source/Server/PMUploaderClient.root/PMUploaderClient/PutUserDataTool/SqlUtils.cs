using System;

using System.Data.SqlClient;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace PutUserDataTool
{
    public class SqlUtils
    {
        /// <summary>
        /// SqlConnection��������
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
        /// PMC�܂���LSM��胆�[�U�[DB�ւ̐ڑ�������擾
        /// </summary>
        /// <returns>���[�U�[DB�ڑ�������</returns>
        public static string GetConnectionString()
        {
            string connectionText = String.Empty;

            //�ڑ�������擾
            LoginInfoAcquisition clientSqlConnectionInfo = new LoginInfoAcquisition();
            connectionText = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_UserAP, ConstantManagement_SF_PRO.IndexCode_UserDB);

            return connectionText;
        }

        /// <summary>
        /// SqlConnection���
        /// ��O�͑S�Ė���
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
        /// SqlCommand���
        /// ��O�͑S�Ė���
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
        /// SqlDataReader���
        /// ��O�͑S�Ė���
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
