using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

using NUnit.Framework;

namespace Broadleaf.Application.NUnit
{
    public sealed class NUnitUtils
    {
        private NUnitUtils() { }

        public static SqlConnection CreateScmDbConnection()
        {
            //string connectionStr = ConfigurationManager.AppSettings["ScmDBConnectionStr"];
            //if (string.IsNullOrEmpty(connectionStr))
            //{
            //    throw new Exception("�A�v���P�[�V�����\���t�@�C���� ScmDBConnectionStr���ݒ肳��Ă��܂���B");
            //}
            string connectionStr = @"packet size=4096; User id=cscmuser; Pwd=cscmuser001; data source=10.20.100.97; persist security info=False; initial catalog=SCM_DB";
            //string connectionStr = @"packet size=4096; User id=pmuser; Pwd=pmuser001; data source=10.30.20.224; persist security info=False; initial catalog=PM_USER_DB";
            return new SqlConnection(connectionStr);
        }

        public static void ExecuteAdHocSql(string sql,string[] parameters)
        {
            #region �e�X�g�f�[�^�쐬
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            try
            {
                sqlConnection = NUnitUtils.CreateScmDbConnection();
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();

                //�߂�ǂ���������p�����[�^�����Ȃ��E�E�E�B
                string[] tokens;
                foreach (string record in parameters)
                {
                    tokens = record.Split(new char[] { '\t' });
                    sqlCommand.CommandText = string.Format(sql, tokens);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                NUnitUtils.CloseQuietly(sqlCommand);
                NUnitUtils.CloseQuietly(sqlConnection);
            }
            #endregion
        }

        public static void CloseQuietly(IDbConnection obj)
        {
            try
            {
                if (obj != null)
                {
                    obj.Close();
                    obj.Dispose();
                }
            }
            catch
            {
            }
        }

        public static void CloseQuietly(IDbCommand obj)
        {
            try
            {
                if (obj != null)
                {
                    obj.Dispose();
                }
            }
            catch
            {
            }
        }

        public static void CloseQuietly(IDataReader obj)
        {
            try
            {
                if (obj != null)
                {
                    obj.Close();
                    obj.Dispose();
                }
            }
            catch
            {
            }
        }
    }
}
