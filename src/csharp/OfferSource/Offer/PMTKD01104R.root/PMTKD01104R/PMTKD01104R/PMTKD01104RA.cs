//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񋟃f�[�^�폜����DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �񋟃f�[�^�폜�����f�[�^������s���N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �C �� ��  2009/07/21  �C�����e : �^�C���A�E�g�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Microsoft.Win32;
using System.Security;
using Broadleaf.Library.Resources;

// 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>. 
using MSMC = Microsoft.SqlServer.Management.Common;
using CustomInstaller;
// 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

namespace Broadleaf.Application.Remoting
{

    internal class LogWriter
    {
        public static void Write(string msg)
        {
            //# if DEBUG
            System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\log.txt", true);
            sw.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "  " + msg);

            sw.Close();
            //# endif
        }
    }

    /// <summary>
    /// �񋟃f�[�^�폜����READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �񋟃f�[�^�폜����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.06.16</br>
    /// </remarks>
    [Serializable]
    public class OfferDataDeleteDB : RemoteDB, IOfferDataDeleteDB
    {
        # region Constructor
       /// <summary>
        /// �񋟃f�[�^�폜�����R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public OfferDataDeleteDB()
            : base("PMTKD01106D", "Broadleaf.Application.Remoting.ParamData.OfferDataDeleteWork", "OFFERDATADELETE")
        {
        }
        #endregion

        #region �񋟃f�[�^�폜����
        #region �񋟃f�[�^�폜����
        /// <summary>
        /// �񋟃f�[�^�폜����
        /// </summary>
        /// <param name="offerDataDeleteList">�񋟃f�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �񋟃f�[�^�폜�������s���N���X�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        public int DeleteOfferData(ref object offerDataDeleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                //�R���N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                UbauControl ubauControl = new UbauControl();
                UbauControl.DbMaintenanceInfo dbMaintenanceInfo = new UbauControl.DbMaintenanceInfo();
                InstallationInfo installationInfo = new InstallationInfo();

                installationInfo.ServerName = Environment.MachineName;
                installationInfo.ServerType = "DB";
                installationInfo.ServiceCode = "OFFER_DB";         //DB�̎�ރR�[�h(USER_DB,OFFER_DB���j
                installationInfo.OsAdminId = "";                        //������OK
                installationInfo.OsAdminPwd = "";                      //������OK
                installationInfo.InstallMngr = "";                      //������OK
                installationInfo.ProductCode = ConstantManagement_SF_PRO.ProductCode;      //�v���_�N�g�R�[�h(�K�{)
                installationInfo.DBTblNmLst = new string[] { };

                dbMaintenanceInfo = ubauControl.GetDbInfo(installationInfo, UbauControl.TargetSystem.LSM);

                //sa�F�؂ɐڑ��������ύX
                SqlConnectionStringBuilder saConText = new SqlConnectionStringBuilder(_connectionText);

                saConText.UserID = dbMaintenanceInfo.MyDbInfo.AdminId;
                saConText.Password = dbMaintenanceInfo.MyDbInfo.AdminPwd;
                // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //sqlConnection = new SqlConnection(_connectionText);
                sqlConnection = new SqlConnection(saConText.ConnectionString);
                // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                sqlConnection.Open();

                // �폜�������s��
                status = DeleteProc(ref offerDataDeleteList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferDataDeleteDB.Delete");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region [DeleteProc]
        /// <summary>
        /// �񋟃f�[�^�폜����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="offerDataDeleteList">�񋟃f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �񋟃f�[�^�폜�������s���N���X�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        private int DeleteProc(ref object offerDataDeleteList, ref SqlConnection sqlConnection)
        {
            // �S�ăe�[�u���������
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // �e�e�[�u���������
            int subStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                ArrayList list = offerDataDeleteList as ArrayList;
                for (int i = 0; i < list.Count; i++)
                {
                    OfferDataDeleteWork work = (OfferDataDeleteWork)list[i];
                    subStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // �����R�[�h�ɂ��A�N���A�������s��
                    switch (work.Code)
                    {
                        case 0: // �����R�[�h��0�F�������N���A
                            subStatus = DeleteDataByCode0(work.TableID, ref sqlConnection);
                            break;
                        case 9: // �����R�[�h��9�A�f�[�^�N���A�����ΏہA�����ŉ��ɂ����Ȃ�
                            break;
                    }

                    // �������ʂ̐ݒ�
                    if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        work.Result = "OK";
                    }
                    else
                    {
                        work.Result = "NG";
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferDataDeleteDB.DeleteProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region �����R�[�h��0�F�������N���A
        /// <summary>
        /// �����R�[�h��0�F�������N���A�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �񋟃f�[�^�폜�������s���N���X�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.18</br>
        private int DeleteDataByCode0(string tableId, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �g�����U�N�V�����J�n
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // �N���A����
                status = DeleteDataByCode0Proc(tableId, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode0");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// �����R�[�h��0�F�������N���A�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �񋟃f�[�^�폜�������s���N���X�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        private int DeleteDataByCode0Proc(string tableId, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder(string.Empty);
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);
                //sql��
                // 2009/07/21 >>>>>>>>>>>>>>>>>>>
                //sqlText.Append("DELETE FROM ");
                sqlText.Append("TRUNCATE TABLE ");
                // 2009/07/21 <<<<<<<<<<<<<<<<<<<
                sqlText.Append(tableId);
                sqlCommand.CommandText = sqlText.ToString();

                // ADD 2009/07/13 
                // ���R�[�h�폜����Timeout�̐ݒ�
                sqlCommand.CommandTimeout = 3600;
                // ���s
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "OfferDataDeleteDB.DeleteProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "OfferDataDeleteDB.DeleteProc" + status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #endregion

        #region �T�[�o�[�̃��W�X�g���X�V����
        /// <summary>
        /// �T�[�o�[�̃��W�X�g���X�V����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �T�[�o�[�̃��W�X�g���X�V����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        public int ServerRegeditUpdate()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string rKeyName = @String.Format("SOFTWARE\\Broadleaf\\Service\\Partsman\\OFFER_AP\\localhost\\OFFER_DB");
            try
            {
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName, true);
                // �p�X�͑��݂Ȃ�
                if (rKey == null)
                {
                    rKey = Registry.LocalMachine.CreateSubKey(rKeyName);
                }
                // �J�����g�t�H���_�̐ݒ�
                rKey.SetValue("CurrentVersion", "99.99.99.99", RegistryValueKind.String);
            }
            catch (SecurityException sex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(sex, "OfferDataDeleteDB.ServerRegeditUpdate" + status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "OfferDataDeleteDB.ServerRegeditUpdate" + status);
            }
            return status;

        }
        #endregion

        #region [�g�����U�N�V�����쐬����]
        /// <summary>
        /// �g�����U�N�V�����쐬����
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            // �g�����U�N�V�����J�n
#if DEBUG
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            return sqlTransaction;
        }
        #endregion //�g�����U�N�V�����쐬����

    }
}
