//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ʐM�e�X�g�c�[��
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2014/09/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ʐM�e�X�g�c�[������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ʐM�e�X�g�c�[������READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2014/09/18</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
	public class APNSNetworkTestDB : RemoteDB, IAPNSNetworkTestDB
    {
        /// <summary>
        /// �f�[�^���M����READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/09/18</br>
        /// </remarks>
        public APNSNetworkTestDB()
        {
        }

        #region �� �ʐM�e�X�g�c�[���f�[�^�������� ��
        /// <summary>
        /// �f�[�^���M�̉�ʂ̏������f�[�^��������
        /// </summary>
        /// <param name="tusinTestLogList">�����p�����[�^</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M��ʂ̏������f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/09/18</br>
        /// 
        public int SearchLogData(ArrayList tusinTestLogList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMessage = string.Empty;

            if (tusinTestLogList == null || tusinTestLogList.Count == 0)
            {
                return status;
            }

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
            if (_connectionText == null || _connectionText == "")
            {
                return status;
            }

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();

            sqlCommand = new SqlCommand("", sqlConnection);
            try
            {
                // Select�R�}���h�̐���
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, MACHINEIPADDRRF, TESTDATETIMERF, TESTRESULTSRF, TESTERRCONTENTSRF FROM COMMTESTLOGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MACHINEIPADDRRF=@FINDMACHINEIPADDR";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMachineIPAddr = sqlCommand.Parameters.Add("@FINDMACHINEIPADDR", SqlDbType.NVarChar);

                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(((TusinTestLogWork)tusinTestLogList[0]).EnterpriseCode);
                findParaMachineIPAddr.Value = SqlDataMediator.SqlSetString(((TusinTestLogWork)tusinTestLogList[0]).MachineIPAddr);


                sqlCommand.CommandText = sqlStr;
                sqlCommand.CommandTimeout = 600;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

				while (myReader.Read())
                {
                    status = status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APNSNetworkTestDB.SearchLogData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion �� �f�[�^���M�̉�ʂ̏������f�[�^�������� ��

        #region �� �ʐM�e�X�g�c�[���f�[�^�o�^���� ��
        /// <summary>
        /// �ʐM�e�X�g�c�[���f�[�^�o�^
        /// </summary>
        /// <param name="tusinTestLogList">�o�^���e</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns></returns>
        public int InsertLogData(ArrayList tusinTestLogList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = string.Empty;

            if (tusinTestLogList == null || tusinTestLogList.Count == 0)
            {
                return status;
            }

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
            if (_connectionText == null || _connectionText == "")
            {
                return status;
            }

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();

            TusinTestLogWork tusinTestLogWork = (TusinTestLogWork)tusinTestLogList[0];

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, null);

            sqlText = "INSERT INTO COMMTESTLOGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, MACHINEIPADDRRF, TESTDATETIMERF, TESTRESULTSRF, TESTERRCONTENTSRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @MACHINEIPADDR, @TESTDATETIME, @TESTRESULTS, @TESTERRCONTENTS)";

            //�o�^�w�b�_����ݒ�
            object obj = (object)this;
            IFileHeader flhd = (IFileHeader)tusinTestLogWork;
            FileHeader fileHeader = new FileHeader(obj);
            fileHeader.SetInsertHeader(ref flhd, obj);

            //Prameter�I�u�W�F�N�g�̍쐬
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraMachineIPAddr = sqlCommand.Parameters.Add("@MACHINEIPADDR", SqlDbType.NVarChar);
            SqlParameter paraTestDateTime = sqlCommand.Parameters.Add("@TESTDATETIME", SqlDbType.BigInt);
            SqlParameter paraTestResults = sqlCommand.Parameters.Add("@TESTRESULTS", SqlDbType.Int);
            SqlParameter paraTestErrContents = sqlCommand.Parameters.Add("@TESTERRCONTENTS", SqlDbType.NVarChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tusinTestLogWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tusinTestLogWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(tusinTestLogWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tusinTestLogWork.LogicalDeleteCode);
            paraMachineIPAddr.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.MachineIPAddr);
            paraTestDateTime.Value = SqlDataMediator.SqlSetLong(tusinTestLogWork.TestDateTime);
            paraTestResults.Value = SqlDataMediator.SqlSetInt32(tusinTestLogWork.TestResults);
            paraTestErrContents.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.TestErrContents);

            sqlCommand.CommandText = sqlText;
            sqlCommand.CommandTimeout = 600;
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

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

            return status;
        }
        #endregion
    }
}
