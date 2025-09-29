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
    /// <br>Update Note: ��DB�����Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/06/18</br>
    /// </remarks>
    [Serializable]
    public class VersionChkTkdWorkDB : RemoteWithAppLockDB, IVersionChkTKDWorkDB
    {
        /// <summary>
        /// ���[�U�[�o�[�W�����`�F�b�NDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        public VersionChkTkdWorkDB()
        {
        }

        private string CurrentVersion = string.Empty;
        private string TargetVersion  = string.Empty;
        private string ErrorMessage   = string.Empty;
        private string MergedVersion  = string.Empty;
        private Int32 ErrorCode = 0;
        private int MergeCheckResult = 0;

        // -- ADD 2010/06/18 ----------------------------------->>>
        /// <summary>
        /// ���[�U�[DB�̃o�[�W��������Ԃ��܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2010/06/14</br>
        /// </remarks>
        public int VersionCheckDB(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            return VersionCheckDBProc(out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
        }
        // -- ADD 2010/06/18 -----------------------------------<<<

        /// <summary>
        /// ���[�U�[DB�̃o�[�W��������Ԃ��܂�
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        // -- UPD 2010/06/14 ------------------------------------------>>>
        //public int VersionCheckDB(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        private int VersionCheckDBProc(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        // -- UPD 2010/06/14 ------------------------------------------<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CurrentVersion = string.Empty;
            TargetVersion = string.Empty;
            ErrorMessage = string.Empty;
            ErrorCode = 0;
            MergeCheckResult = 0;

            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            // -- DEL 2010/06/18 ------------------------------------->>>
            //string ServerCode = ConstantManagement_SF_PRO.ServerCode_OfferAP;
            //string IndexCode = ConstantManagement_SF_PRO.IndexCode_OfferDB;
            //string ProductCode = ConstantManagement_SF_PRO.ProductCode;
            // -- DEL 2010/06/18 -------------------------------------<<<
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);

            retSqlConnection = new SqlConnection(connectionText);
            string coon = retSqlConnection.DataSource;
            //retSqlConnection.Open();   // DEL 2010/06/18

            SqlDataReader myReader = null;  // ADD 2010/06/18
            SqlCommand sqlCommand = null;   // ADD 2010/06/18
            try
            {
                retSqlConnection.Open();   // ADD 2010/06/18

                // -- UPD 2010/06/18 ---------------------------------------------->>>
                //// AP��DB������
                //status = GetDBServerRegistryValue(ProductCode, ServerCode, IndexCode, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
                //if (status == -9)
                //{
                //    // AP��DB���ʋ�
                //    status = GetDBServerShareRegistryValue(ProductCode, ServerCode, IndexCode, coon, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
                //}

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, retSqlConnection);

                sqlText += " SELECT " + Environment.NewLine;
                sqlText += "  MAX(OFFERVERSIONRF) AS OFFERVERSION " + Environment.NewLine;
                sqlText += " FROM DATAVERMNGOFFRF " + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    CurrentVersion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFERVERSION"));
                }
                // -- UPD 2010/06/18 ----------------------------------------------<<<

            }
            // -- UPD 2010/06/18 ------------------------>>>
            //catch
            //{
            //}
            catch(SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            // -- UPD 2010/06/18 ------------------------<<<
            finally
            {
                // -- ADD 2010/06/18 -------------------->>>
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                // -- ADD 2010/06/18 --------------------<<<

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
        public int VersionCheckAP(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CurrentVersion = string.Empty;
            TargetVersion  = string.Empty;
            ErrorMessage   = string.Empty;
            ErrorCode = 0;
            MergeCheckResult = 0;

            string ServerCode  = ConstantManagement_SF_PRO.ServerCode_OfferAP;
            string ProductCode = ConstantManagement_SF_PRO.ProductCode;

            // AP�̂�
            status = GetAPServerVersion(ProductCode, ServerCode, out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage, out MergedVersion);

            return status;
        }

        /// <summary>
        /// AP�o�[�W�����擾
        /// </summary>
        /// <remarks>
        /// <param name="productCode">���i�R�[�h</param>
        /// <param name="serverCode">�T�[�o�[�R�[�h</param>
        /// </remarks>
        public int GetAPServerVersion(string productCode, string serverCode, out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage, out string MergedVersion)
        {
            int ret = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int _requiredServerVersion = 0;
            // ���삷�郌�W�X�g���E�L�[�̖��O
            string rKeyName = @String.Format("SOFTWARE\\Broadleaf\\Service\\{0}\\{1}", productCode, serverCode);
            // �擾�������s���ΏۂƂȂ郌�W�X�g���̒l�̖��O
            string rGetValueName = "RequiredServerVersion";

            CurrentVersion = "";
            TargetVersion  = "";
            ErrorCode = 0;
            ErrorMessage   = "";
            MergedVersion  = "";

            // ���W�X�g���̎擾
            try
            {
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

            // ���삷�郌�W�X�g���E�L�[�̖��O
            string rKeyName = @String.Format(@"SOFTWARE\Broadleaf\Service\{0}\{1}\share\{2}\{3}", ProductCode, ServiceCode, IndexCode, conn);

            CurrentVersion = "";
            TargetVersion  = "";
            ErrorCode = 0;
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



        /// <summary>
        /// DBServer���W�X�g�����擾(localhost)
        /// </summary>
        /// <param name="ProductCode">�v���_�N�g�R�[�h</param>
        /// <param name="ServiceCode">�T�[�r�X USER_AP��</param>
        /// <param name="IndexCode">�C���f�b�N�X�R�[�h USER_DB��</param>
        /// <returns>���W�X�g���l</returns>
        private int GetDBServerRegistryValue(string ProductCode, string ServiceCode, string IndexCode, out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int ret = -9;
            // ���삷�郌�W�X�g���E�L�[�̖��O
            string rKeyName = @String.Format(@"SOFTWARE\Broadleaf\Service\{0}\{1}\localhost\{2}", ProductCode, ServiceCode, IndexCode);

            CurrentVersion = "";
            TargetVersion  = "";
            ErrorCode = 0;
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
    }
}