using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Microsoft.Win32;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���[�U�[�o�[�W�����`�F�b�NDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[�o�[�W�����`�F�b�N���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2009.01.23</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class VersionChkWorkDB : RemoteWithAppLockDB, IVersionChkWorkDB
    {
        /// <summary>
        /// ���[�U�[�o�[�W�����`�F�b�NDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        public VersionChkWorkDB()
        {
        }

        private string CurrentVersion = string.Empty;
        private string TargetVersion  = string.Empty;
        private string ErrorMessage   = string.Empty;
        private string MergedVersion  = string.Empty;
        private Int32  ErrorCode      = 0;
        private int    MergeCheckResult = 0;

        /// <summary>
        /// ���[�U�[DB�̃o�[�W��������Ԃ��܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        public int VersionCheckDB(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CurrentVersion   = string.Empty;
            TargetVersion    = string.Empty;
            ErrorMessage     = string.Empty;
            ErrorCode  = 0;
            MergeCheckResult = 0;

            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string ServerCode     = ConstantManagement_SF_PRO.ServerCode_UserAP;
            string IndexCode      = ConstantManagement_SF_PRO.IndexCode_UserDB;
            string ProductCode    = ConstantManagement_SF_PRO.ProductCode;
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return status;

            retSqlConnection = new SqlConnection(connectionText);
            retSqlConnection.Open();
            try
            {
                string coon = retSqlConnection.DataSource;

                // AP��DB���ʋ�
                status = GetDBServerShareRegistryValue(ProductCode, ServerCode, IndexCode, coon, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
                if (status == -9)
                {
                    // AP��DB������
                    status = GetDBServerRegistryValue(ProductCode, ServerCode, IndexCode, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
                }
            }
            catch
            {
            }
            finally
            {
                if (retSqlConnection != null)
                {
                    retSqlConnection.Close();
                    retSqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// ���[�U�[AP�̃o�[�W��������Ԃ��܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : AP�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        public int VersionCheckAP(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage, string EnterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CurrentVersion = string.Empty;
            TargetVersion  = string.Empty;
            ErrorMessage   = string.Empty;
            ErrorCode = 0;
            MergeCheckResult = 0;

            string ServerCode  = ConstantManagement_SF_PRO.ServerCode_UserAP;
            string ProductCode = ConstantManagement_SF_PRO.ProductCode;

            // AP�̂�
            status = GetAPServerVersion(ProductCode, ServerCode, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage, out MergedVersion, EnterpriseCode);
            
            return status;
        }


        /// <summary>
        /// �}�[�W�`�F�b�N����Ԃ��܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        public int MergeCheck(out int MergeCheckResult, string EnterpriseCode, string currentVersion)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            MergeCheckResult = 0;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            string ServerCode   = ConstantManagement_SF_PRO.ServerCode_UserAP;
            string ProductCode  = ConstantManagement_SF_PRO.ProductCode;

            //�R�l�N�V��������
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return status;

            ArrayList lockState  = new ArrayList();
            SqlCommand command   = null;
            SqlDataReader reader = null;

            //SQL������
            sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            //EnterpriseCode = "0101150842020000";
            string ResourseName = string.Format("{0}-{1}-{2}", EnterpriseCode, ConstantManagement_SF_PRO.ProductCode, "Broadleaf.Application.Remoting.UserMergeDB");

            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SUBSTRING(locks.resource_description,  4,16) AS ENTERPRISE" + Environment.NewLine;
                sqlText += " ,SUBSTRING(locks.resource_description, 20, 3) AS TYPE" + Environment.NewLine;
                sqlText += " ,SUBSTRING(locks.resource_description, 23, 6) AS CODE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  sys.dm_tran_locks AS locks" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  locks.resource_type = 'APPLICATION'" + Environment.NewLine;
                sqlText += "  AND locks.resource_description LIKE '0:$[" + ResourseName + "%' escape '$'" + Environment.NewLine;

                command = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ShareCheckKey wrkKey = new ShareCheckKey();
                    wrkKey.EnterpriseCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("ENTERPRISE"));  // ��ƃR�[�h
                    lockState.Add(wrkKey);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "VersionChkWorkDB.MergeCheck Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                        sqlTransaction.Commit();
                    
                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }


            if (lockState.Count > 0)
            {
                MergeCheckResult = 1;
                return 0;
            }

            // USER_AP
            status = GetAPServerVersion(ProductCode, ServerCode, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage, out MergedVersion, EnterpriseCode);�@// MergedVersion�擾

            // OFFER_DB CurrentVersion
            CurrentVersion = currentVersion; 

            if (MergedVersion == CurrentVersion)

            {
                MergeCheckResult = 0;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                MergeCheckResult = 2;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// AP�o�[�W�����擾
        /// </summary>
        /// <remarks>
        /// <param name="productCode">���i�R�[�h</param>
        /// <param name="serverCode">�T�[�o�[�R�[�h</param>
        /// </remarks>
        public int GetAPServerVersion(string productCode, string serverCode, out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage, out string MergedVersion, string EnterpriseCode)
        {
            int ret = -9;

            // ���삷�郌�W�X�g���E�L�[�̖��O
            string rKeyName = @String.Format("SOFTWARE\\Broadleaf\\Service\\{0}\\{1}", productCode, serverCode);

            CurrentVersion = "";
            TargetVersion  = "";
            ErrorCode      = 0;
            ErrorMessage   = "";
            MergedVersion  = "";


            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            //�R�l�N�V��������
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return ret;

            //SQL������
            sqlConnection = new SqlConnection(connectionText);

            // ���W�X�g���̎擾
            try
            {
                #region DELETE 2008/03/18 sakurai
                // ���W�X�g���E�L�[�̃p�X���w�肵�ă��W�X�g�����J��
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);

                // ���W�X�g���̒l���擾
                CurrentVersion = (string)rKey.GetValue("CurrentVersion", "");
                if (CurrentVersion != "")
                {
                    TargetVersion = (string)rKey.GetValue("TargetVersion", "");
                    ErrorCode = (Int32)rKey.GetValue("ErrorCode", 0);
                    ErrorMessage = (string)rKey.GetValue("ErrorMessage", "");
                    MergedVersion = (string)rKey.GetValue("MergedVersion", "");
                    ret = 0;
                }
                // �J�������W�X�g���E�L�[�����
                rKey.Close();
                //return ret;
                #endregion

                sqlConnection.Open();

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText += " SELECT " + Environment.NewLine;
                sqlText += "  MAX(OFFERVERSIONRF) AS OFFERVERSION " + Environment.NewLine;
                sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);

                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    MergedVersion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFERVERSION"));
                }
            }
            catch (NullReferenceException)
            {
                if (CurrentVersion != "")
                    return 0;
                else
                    return -9;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return 0;
        }


        /// <summary>
        /// DBServerShare���W�X�g�����擾(Share) 
        /// </summary>
        /// <param name="ProductCode">�v���_�N�g�R�[�h</param>
        /// <param name="ServiceCode">�T�[�r�X USER_AP��</param>
        /// <param name="IndexCode">�C���f�b�N�X�R�[�h USER_DB��</param>
        /// <param name="conn">�ڑ�������</param>
        /// <returns>���W�X�g���l</returns>
        private int GetDBServerShareRegistryValue(string ProductCode, string ServiceCode, string IndexCode, string conn, out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int ret = -9;
            //string db = GetDataSource(conn);

            // ���삷�郌�W�X�g���E�L�[�̖��O
            string rKeyName = @String.Format(@"SOFTWARE\Broadleaf\Service\{0}\{1}\share\{2}\{3}", ProductCode, ServiceCode, IndexCode, conn);

            CurrentVersion = "";
            TargetVersion  = "";
            ErrorCode      = 0;
            ErrorMessage   = "";

            // ���W�X�g���̎擾
            try
            {
                // ���W�X�g���E�L�[�̃p�X���w�肵�ă��W�X�g�����J��
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);
                // ���W�X�g���̒l���擾
                CurrentVersion = (string)rKey.GetValue("CurrentVersion", "");
                if (CurrentVersion != "")
                {
                    TargetVersion  = (string)rKey.GetValue("TargetVersion", "");
                    ErrorCode      = (Int32)rKey.GetValue("ErrorCode", 0);
                    ErrorMessage   = (string)rKey.GetValue("ErrorMessage", "");
                    ret = 0;
                }
                // �J�������W�X�g���E�L�[�����
                rKey.Close();

                // �擾�������W�X�g���̒l��߂�(0�`)
                return ret;
            }
            catch (NullReferenceException)
            {
                if (CurrentVersion != "")
                    return 0;
                else
                    return -9;
            }
        }

        // DataSource���o
        private string GetDataSource(string conn)
        {
            try
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.ConnectionString = conn;
                return scsb.DataSource;
            }
            catch
            {
                return String.Empty;
            }
        }


        /// <summary>
        /// DBServer���W�X�g�����擾(localhost)
        /// </summary>
        /// <param name="ProductCode">�v���_�N�g�R�[�h</param>
        /// <param name="ServiceCode">�T�[�r�X USER_AP��</param>
        /// <param name="IndexCode">�C���f�b�N�X�R�[�h USER_DB��</param>
        /// <returns>���W�X�g���l</returns>
        private int GetDBServerRegistryValue(string ProductCode, string ServiceCode, string IndexCode, out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int ret = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // ���삷�郌�W�X�g���E�L�[�̖��O
            string rKeyName = @String.Format(@"SOFTWARE\Broadleaf\Service\{0}\{1}\localhost\{2}", ProductCode, ServiceCode, IndexCode);

            CurrentVersion = "";
            TargetVersion  = "";
            ErrorCode      = 0;
            ErrorMessage   = "";

            // ���W�X�g���̎擾
            try
            {
                RegistryKey reg_key = Registry.LocalMachine.OpenSubKey(rKeyName);

                // ���W�X�g���E�L�[�̃p�X���w�肵�ă��W�X�g�����J��
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);
                // ���W�X�g���̒l���擾
                CurrentVersion = (string)rKey.GetValue("CurrentVersion", "");
                if (CurrentVersion != "")
                {
                    TargetVersion  = (string)rKey.GetValue("TargetVersion", "");
                    ErrorCode      = (Int32)rKey.GetValue("ErrorCode", 0);
                    ErrorMessage   = (string)rKey.GetValue("ErrorMessage", "");
                    ret = 0;
                }
                // �J�������W�X�g���E�L�[�����
                rKey.Close();

                // �擾�������W�X�g���̒l��߂�
                return ret;
            }
            catch (NullReferenceException)

            {
                if (CurrentVersion != "")
                    return 0;
                else
                    return -9;
            }
        }

        /// <summary>
        /// ���[�U�[�o�[�W�����X�V����
        /// </summary>
        /// <param name="ProductCode">�v���_�N�g�R�[�h</param>
        /// <param name="ServiceCode">�T�[�r�X USER_AP��</param>
        /// <param name="IndexCode">�C���f�b�N�X�R�[�h USER_DB��</param>
        /// <returns>���W�X�g���l</returns>
        public int UpdateVersion(ref string CurrentVersion)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string ServerCode = ConstantManagement_SF_PRO.ServerCode_UserAP;
            string ProductCode = ConstantManagement_SF_PRO.ProductCode;
            
            if (ProductCode != "" && ServerCode != "")
            {
                string rKeyName = @String.Format("SOFTWARE\\Broadleaf\\Service\\{0}\\{1}", ProductCode, ServerCode);
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName, true);
                rKey.SetValue("MergedVersion", CurrentVersion, RegistryValueKind.String);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

    }
}