//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�L�����y�[���ݒ�}�X�^�����e
// �v���O�����T�v   : PCC�L�����y�[���ݒ�}�X�^�����eDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�ˁ@�L��
// �� �� ��  2012/11/07  �C�����e : 2012/12/12�z�M SCM��Q��10422�Ή� �⍇�����ƁE���_���w��ł̎擾���\��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F��
// �� �� ��  2012/11/27  �C�����e : 2012/12/12�z�M �V�X�e���e�X�g��Q��83�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PCC�L�����y�[���ݒ�}�X�^�����e�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^�����e�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PccCpMsgStDB : RemoteDB, IPccCpMsgStDB
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public PccCpMsgStDB() : base("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork", "PCCCPMSGSTRF")
        {
        }

        #region [�R�l�N�V������������]

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }

        #endregion

        #region [�g�����U�N�V������������]

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction��������</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }

        #endregion  //�g�����U�N�V������������

        #region IPccCpMsgStDB �����o

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Write(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^
                status = WriteMsgProc(ref pccCpMsgStWorkList, ref sqlConnection,ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //PCC�L�����y�[���Ώېݒ�}�X�^
                    status = WriteTgtProc(ref pccCpTgtStWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //PCC�L�����y�[���i�ڐݒ�}�X�^
                        status = WriteItmProc(ref pccCpItmStWorkList, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Write");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
       
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^���e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteMsgProc(ref object pccCpMsgStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            ArrayList pccCpMsgStWorkArrList = null;
            ArrayList pccCpMsgStWorkArrListNew = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pccCpMsgStWorkList != null)
                {
                    pccCpMsgStWorkArrList = pccCpMsgStWorkList as ArrayList;
                }
                if (pccCpMsgStWorkArrList == null || pccCpMsgStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpMsgStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCpMsgStWorkArrList.Count; i++)
                {
                    PccCpMsgStWork pccCpMsgStWorkEach = pccCpMsgStWorkArrList[i] as PccCpMsgStWork;
                    if (pccCpMsgStWorkEach.UpdateFlag == 2)
                    {
                        status = this.DeleteProcMsgEach(ref pccCpMsgStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand,ref myReader);
                    }
                    else
                    {
                        status = WriteMsgProcEach(ref pccCpMsgStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccCpMsgStWorkArrListNew.Add(pccCpMsgStWorkEach);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpMsgStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Write");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
            }

            pccCpMsgStWorkList = pccCpMsgStWorkArrListNew as Object;

            return status;
        }

         /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^���e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpMsgStWorkEach">PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�O���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteMsgProcEach(ref PccCpMsgStWork pccCpMsgStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand,ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;;
            //Select�R�}���h�̐���
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPMSGSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccCpMsgStWorkEach.UpdateDateTime)
                {
                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                    if (pccCpMsgStWorkEach.UpdateDateTime == DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    }
                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCCPMSGSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNCODERF=@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , APPLYSTADATERF=@APPLYSTADATE").Append(Environment.NewLine);
                sqlTxt.Append(" , APPLYENDDATERF=@APPLYENDDATE").Append(Environment.NewLine);
                sqlTxt.Append(" , PCCMSGDOCCNTSRF=@PCCMSGDOCCNTS").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNNAMERF=@CAMPAIGNNAME").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNOBJDIVRF=@CAMPAIGNOBJDIV").Append(Environment.NewLine);

                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //KEY�R�}���h���Đݒ�
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
                pccCpMsgStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                if (pccCpMsgStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //�V�K�쐬����SQL���𐶐�
                sqlTxt.Append("INSERT INTO PCCCPMSGSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,APPLYSTADATERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,APPLYENDDATERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,PCCMSGDOCCNTSRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNOBJDIVRF").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@APPLYSTADATE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@APPLYENDDATE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@PCCMSGDOCCNTS").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNNAME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNOBJDIV").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�o�^�w�b�_����ݒ�
                pccCpMsgStWorkEach.UpdateDateTime = DateTime.Now;
                pccCpMsgStWorkEach.CreateDateTime = DateTime.Now;
                pccCpMsgStWorkEach.LogicalDeleteCode = 0;
            }

            if (!myReader.IsClosed) myReader.Close();
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraInqotherEpcd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            SqlParameter paraInqotherSeccd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            SqlParameter paraPccMsgDocCnts = sqlCommand.Parameters.Add("@PCCMSGDOCCNTS", SqlDbType.NVarChar);
            SqlParameter paraCampaignName = sqlCommand.Parameters.Add("@CAMPAIGNNAME", SqlDbType.NVarChar);
            SqlParameter paraCampaignObjDiv = sqlCommand.Parameters.Add("@CAMPAIGNOBJDIV", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpMsgStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpMsgStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.LogicalDeleteCode);
            paraInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
            paraInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            paraApplyStaDate.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.ApplyStaDate);
            paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.ApplyEndDate);
            paraPccMsgDocCnts.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.PccMsgDocCnts);
            paraCampaignName.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.CampaignName);
            paraCampaignObjDiv.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignObjDiv);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        ///PCC�L�����y�[���Ώېݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteTgtProc(ref object pccCpTgtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            ArrayList pccCpTgtStWorkListArrList = null;
            ArrayList pccCpTgtStWorkListArrListNew = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pccCpTgtStWorkList != null)
                {
                    pccCpTgtStWorkListArrList = pccCpTgtStWorkList as ArrayList;
                }
                if (pccCpTgtStWorkListArrList == null || pccCpTgtStWorkListArrList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                pccCpTgtStWorkListArrListNew = new ArrayList();

                for (int i = 0; i < pccCpTgtStWorkListArrList.Count; i++)
                {
                    PccCpTgtStWork pccCpTgtStWorkEach = pccCpTgtStWorkListArrList[i] as PccCpTgtStWork;
                    if (pccCpTgtStWorkEach.UpdateFlag == 2)
                    {
                        status = this.DeleteProcTgtEach(ref pccCpTgtStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    }
                    else
                    {
                        status = WriteTgtProcEach(ref pccCpTgtStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccCpTgtStWorkListArrListNew.Add(pccCpTgtStWorkEach);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.Write");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
            }

            pccCpTgtStWorkList = pccCpTgtStWorkListArrListNew as Object;

            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpTgtStWorkEach">PCC�L�����y�[���Ώېݒ�}�X�^�O���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteTgtProcEach(ref PccCpTgtStWork pccCpTgtStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand,ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Select�R�}���h�̐���
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPTGTSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqoriginalEpcd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqoriginaLSeccd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
            findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccCpTgtStWorkEach.UpdateDateTime)
                {
                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                    if (pccCpTgtStWorkEach.UpdateDateTime == DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    }
                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCCPTGTSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALEPCDRF = @INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALSECCDRF = @INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHEREPCDRF = @INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF = @INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNCODERF = @CAMPAIGNCODE").Append(Environment.NewLine);

                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //KEY�R�}���h���Đݒ�
                findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
                findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
                pccCpTgtStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                if (pccCpTgtStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //�V�K�쐬����SQL���𐶐�
                sqlTxt.Append("INSERT INTO PCCCPTGTSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�o�^�w�b�_����ݒ�
                pccCpTgtStWorkEach.UpdateDateTime = DateTime.Now;
                pccCpTgtStWorkEach.CreateDateTime = DateTime.Now;
                pccCpTgtStWorkEach.LogicalDeleteCode = 0;
            }

            if (!myReader.IsClosed) myReader.Close();
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraInqoriginalEpcd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter paraInqoriginalSeccd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter paraInqotherEpcd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            SqlParameter paraInqotherSeccd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpTgtStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpTgtStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.LogicalDeleteCode);
            paraInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
            paraInqoriginalSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
            paraInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
            paraInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private  int WriteItmProc(ref object pccCpItmStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            ArrayList pccCpItmStWorkListArrList = null;
            ArrayList pccCpItmStWorkListArrListNew = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pccCpItmStWorkList != null)
                {
                    pccCpItmStWorkListArrList = pccCpItmStWorkList as ArrayList;
                }
                if (pccCpItmStWorkListArrList == null || pccCpItmStWorkListArrList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                pccCpItmStWorkListArrListNew = new ArrayList();

                for (int i = 0; i < pccCpItmStWorkListArrList.Count; i++)
                {
                    PccCpItmStWork pccCpItmStWorkEach = pccCpItmStWorkListArrList[i] as PccCpItmStWork;
                    if (pccCpItmStWorkEach.UpdateFlag == 2)
                    {
                        status = this.DeleteProcItmEach(ref pccCpItmStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    }
                    else
                    {
                        status = WriteItmProcEach(ref pccCpItmStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccCpItmStWorkListArrListNew.Add(pccCpItmStWorkEach);

                    } if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpItmStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpItmStDB.Write");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
            }

            pccCpItmStWorkList = pccCpItmStWorkListArrListNew as Object;

            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^���e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpItmStWorkEach">PCC�L�����y�[���i�ڐݒ�}�X�^�O���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteItmProcEach(ref PccCpItmStWork pccCpItmStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand,ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Select�R�}���h�̐���
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPITMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            SqlParameter findParaCampStDiv = sqlCommand.Parameters.Add("@FINDCAMPSTDIVRF", SqlDbType.Int);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
            findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccCpItmStWorkEach.UpdateDateTime)
                {
                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                    if (pccCpItmStWorkEach.UpdateDateTime == DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    }
                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCCPITMSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);  
                sqlTxt.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNCODERF=@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPSTDIVRF=@CAMPSTDIV").Append(Environment.NewLine);
                sqlTxt.Append(" , BLGOODSCODERF=@BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , GOODSNORF=@GOODSNO").Append(Environment.NewLine);
                sqlTxt.Append(" , GOODSMAKERCDRF=@GOODSMAKERCD").Append(Environment.NewLine);
                sqlTxt.Append(" , GOODSNAMERF=@GOODSNAME").Append(Environment.NewLine);
                sqlTxt.Append(" , GOODSNAMEKANARF=@GOODSNAMEKANA").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMQTYRF=@ITEMQTY").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //KEY�R�}���h���Đݒ�
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
                findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
                pccCpItmStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                if (pccCpItmStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //�V�K�쐬����SQL���𐶐�
                sqlTxt.Append("INSERT INTO PCCCPITMSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,GOODSNORF").Append(Environment.NewLine);
                sqlTxt.Append("    ,GOODSMAKERCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,GOODSNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,GOODSNAMEKANARF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMQTYRF").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPSTDIV").Append(Environment.NewLine);
                sqlTxt.Append("    ,@BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@GOODSNO").Append(Environment.NewLine);
                sqlTxt.Append("    ,@GOODSMAKERCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@GOODSNAME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@GOODSNAMEKANA").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMQTY").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                pccCpItmStWorkEach.UpdateDateTime = DateTime.Now;
                pccCpItmStWorkEach.CreateDateTime = DateTime.Now;
                pccCpItmStWorkEach.LogicalDeleteCode = 0;
            }

            if (!myReader.IsClosed) myReader.Close();
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraInqotherEpcd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            SqlParameter paraInqotherSeccd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
            SqlParameter paraCampstDiv = sqlCommand.Parameters.Add("@CAMPSTDIV", SqlDbType.Int);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraGoodsMakercd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
            SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
            SqlParameter paraItemQty = sqlCommand.Parameters.Add("@ITEMQTY", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpItmStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpItmStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.LogicalDeleteCode);
            paraInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
            paraInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
            paraCampstDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
            paraGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
            paraGoodsMakercd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            paraGoodsName.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsName);
            paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNameKana);
            paraItemQty.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.ItemQty);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
		}

		/// <summary>
		/// PCC�L�����y�[���ݒ��񌟍�����
		/// </summary>
		/// <param name="paraObj">�����p�����[�^</param>
		/// <param name="pccCpMsgStWorkObj">PCC�L�����y�[�����b�Z�[�W�ݒ���</param>
		/// <param name="pccCpItmStWorkObj">PCC�L�����y�[���i�ڐݒ���</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ������PCC�L�����y�[���ݒ����߂��܂��B</br>
		/// <br>Programmer : huangqb</br>
		/// <br>Date       : 2011.08.11</br>
		/// </remarks>
		public int SearchPccCampaign(object paraObj, out object pccCpMsgStWorkObj, out object pccCpItmStWorkObj, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			pccCpMsgStWorkObj = new ArrayList();
			pccCpItmStWorkObj = new ArrayList();
			errMsg = string.Empty;

			try
			{
				// �R�l�N�V��������
				sqlConnection = CreateSqlConnection();
				if (sqlConnection == null) return status;
				sqlConnection.Open();

				SearchParaWork searchParaWork = (SearchParaWork)paraObj;
				ArrayList pccCpMsgStWorkList;
				ArrayList pccCpItmStWorkList;

				// PCC�L�����y�[���ݒ��񌟍�
				status = SearchPccCampaignProc(searchParaWork, out pccCpMsgStWorkList, out pccCpItmStWorkList, out errMsg, ref sqlConnection);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					pccCpMsgStWorkObj = (object)pccCpMsgStWorkList;
					pccCpItmStWorkObj = (object)pccCpItmStWorkList;
				}
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				base.WriteErrorLog(ex, "PccCpMsgStDB.SearchPccCampaign");
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

		/// <summary>
		/// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
		/// </summary>
		/// <param name="searchParaWork">�����p�����[�^</param>
		/// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�ݒ�f�[�^���X�g</param>
		/// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		///  <param name="sqlConnection">�R�l�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Programmer : ���C��</br>
		/// <br>Date       : 2011.08.11</br>
		/// </remarks>
		private int SearchPccCampaignProc(SearchParaWork searchParaWork, out ArrayList pccCpMsgStWorkList, out ArrayList pccCpItmStWorkList, out string errMsg, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			pccCpMsgStWorkList = new ArrayList();
			pccCpItmStWorkList = new ArrayList();
			errMsg = string.Empty;

            // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
            bool inqOtherEpFlg = StringChk(searchParaWork.InqOtherEpCd);   //�⍇�����Ǝw��
            bool inqOtherSecFlg = StringChk(searchParaWork.InqOtherSecCd); //�⍇���拒�_�w��
            // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            try
			{
				StringBuilder sqlTxt = new StringBuilder(string.Empty);
				StringBuilder sqlSelect = new StringBuilder(string.Empty);
				sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
				sqlSelect.Append("SELECT  ").Append(Environment.NewLine);
				sqlSelect.Append("     PCCCPMSGSTRF.CREATEDATETIMERF AS MSGSTCREATEDATETIMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.UPDATEDATETIMERF AS MSGSTUPDATEDATETIMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.LOGICALDELETECODERF AS MSGSTLOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.INQOTHEREPCDRF AS MSGSTINQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.INQOTHERSECCDRF AS MSGSTINQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.CAMPAIGNCODERF AS MSGSTCAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.APPLYSTADATERF AS MSGSTAPPLYSTADATERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.APPLYENDDATERF AS MSGSTAPPLYENDDATERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.PCCMSGDOCCNTSRF AS MSGSTPCCMSGDOCCNTSRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.CAMPAIGNNAMERF AS MSGSTCAMPAIGNNAMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.CAMPAIGNOBJDIVRF AS MSGSTCAMPAIGNOBJDIVRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.CREATEDATETIMERF AS ITMSTCREATEDATETIMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.UPDATEDATETIMERF AS ITMSTUPDATEDATETIMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.LOGICALDELETECODERF AS ITMSTLOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.INQOTHEREPCDRF AS ITMSTINQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.INQOTHERSECCDRF AS ITMSTINQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.CAMPAIGNCODERF AS ITMSTCAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.CAMPSTDIVRF AS ITMSTCAMPSTDIVRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.BLGOODSCODERF AS ITMSTBLGOODSCODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.GOODSNORF AS ITMSTGOODSNORF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.GOODSMAKERCDRF AS ITMSTGOODSMAKERCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.GOODSNAMERF AS ITMSTGOODSNAMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.GOODSNAMEKANARF AS ITMSTGOODSNAMEKANARF ").Append(Environment.NewLine);
                sqlSelect.Append("    ,PCCCPITMSTRF.ITEMQTYRF AS ITEMQTYRF ").Append(Environment.NewLine);

				sqlTxt.Append(sqlSelect);
				sqlTxt.Append("FROM PCCCPTGTSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("INNER JOIN PCCCPMSGSTRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("    ON PCCCPTGTSTRF.LOGICALDELETECODERF = PCCCPMSGSTRF.LOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHEREPCDRF = PCCCPMSGSTRF.INQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHERSECCDRF = PCCCPMSGSTRF.INQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPTGTSTRF.CAMPAIGNCODERF = PCCCPMSGSTRF.CAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlTxt.Append("LEFT JOIN PCCCPITMSTRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("    ON PCCCPMSGSTRF.LOGICALDELETECODERF = PCCCPITMSTRF.LOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHEREPCDRF = PCCCPITMSTRF.INQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHERSECCDRF = PCCCPITMSTRF.INQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.CAMPAIGNCODERF = PCCCPITMSTRF.CAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlTxt.Append("WHERE ").Append(Environment.NewLine);
				sqlTxt.Append("    PCCCPTGTSTRF.INQORIGINALEPCDRF = @FINDINQORIGINALEPCD ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPTGTSTRF.INQORIGINALSECCDRF = @FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                // --- UPD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                //sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHERSECCDRF = @FINDINQOTHERSECCD ").Append(Environment.NewLine);
                if (inqOtherEpFlg)  sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                if (inqOtherSecFlg) sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHERSECCDRF = @FINDINQOTHERSECCD ").Append(Environment.NewLine);
                // --- UPD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                sqlTxt.Append("    AND PCCCPMSGSTRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.CAMPAIGNOBJDIVRF = @FINDCAMPAIGNOBJDIVSPECIFIER ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.APPLYSTADATERF <= @FINDSEARCHDATE ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.APPLYENDDATERF >= @FINDSEARCHDATE ").Append(Environment.NewLine);

				sqlTxt.Append("UNION ").Append(Environment.NewLine);
				sqlTxt.Append(sqlSelect);
				sqlTxt.Append("FROM PCCCPMSGSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("LEFT JOIN PCCCPITMSTRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("    ON PCCCPMSGSTRF.LOGICALDELETECODERF = PCCCPITMSTRF.LOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHEREPCDRF = PCCCPITMSTRF.INQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHERSECCDRF = PCCCPITMSTRF.INQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.CAMPAIGNCODERF = PCCCPITMSTRF.CAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlTxt.Append("WHERE ").Append(Environment.NewLine);
				sqlTxt.Append("    PCCCPMSGSTRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                //sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHERSECCDRF = @FINDINQOTHERSECCD ").Append(Environment.NewLine);
                if (inqOtherEpFlg)  sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                if (inqOtherSecFlg) sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHERSECCDRF = @FINDINQOTHERSECCD ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                sqlTxt.Append("    AND PCCCPMSGSTRF.CAMPAIGNOBJDIVRF = @FINDCAMPAIGNOBJDIVALL ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.APPLYSTADATERF <= @FINDSEARCHDATE ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.APPLYENDDATERF >= @FINDSEARCHDATE ").Append(Environment.NewLine);

				sqlTxt.Append("ORDER BY PCCCPMSGSTRF.APPLYSTADATERF DESC").Append(Environment.NewLine);
				sqlCommand.CommandText = sqlTxt.ToString();

				SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
				SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
				SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
				SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
				SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				SqlParameter findParaCampaignObjDivSpecifier = sqlCommand.Parameters.Add("@FINDCAMPAIGNOBJDIVSPECIFIER", SqlDbType.Int);
				SqlParameter findParaCampaignObjDivAll = sqlCommand.Parameters.Add("@FINDCAMPAIGNOBJDIVALL", SqlDbType.Int);
				SqlParameter findParaSearchDate = sqlCommand.Parameters.Add("@FINDSEARCHDATE", SqlDbType.Int);

				findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(searchParaWork.InqOriginalEpCd);
				findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(searchParaWork.InqOriginalSecCd);
				findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(searchParaWork.InqOtherEpCd);
				findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(searchParaWork.InqOtherSecCd);
				findParaCampaignObjDivSpecifier.Value = SqlDataMediator.SqlSetInt32(1);
				findParaCampaignObjDivAll.Value = SqlDataMediator.SqlSetInt32(0);
				findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
				findParaSearchDate.Value = SqlDataMediator.SqlSetInt32(searchParaWork.SearchDate);
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
				myReader = sqlCommand.ExecuteReader();
                status = this.CopyMsgAndStWorkListFromReader(ref myReader, ref pccCpMsgStWorkList, ref pccCpItmStWorkList);
				
			}
			catch (SqlException ex)
			{
				errMsg = ex.Message;
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.SearchPccCampaignProc", status);
			}
			finally
			{
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
			}
			return status;
		}

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <param name="parsePccCpMsgStWork">�����p�����[�^</param>
        /// <param name="parsePccCpTgtStWork">�����p�����[�^</param>
        /// <param name="parsePccCpItmStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        ///  <param name="dateSearchFlag">0:���t���������Ȃ�1�F���t��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Search(out object pccCpMsgStWorkList, out object pccCpTgtStWorkList, out object pccCpItmStWorkList, PccCpMsgStWork parsePccCpMsgStWork, PccCpTgtStWork parsePccCpTgtStWork, PccCpItmStWork parsePccCpItmStWork, int readMode, ConstantManagement.LogicalMode logicalMode, int dateSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pccCpMsgStWorkList = null;
            pccCpTgtStWorkList = null;
            pccCpItmStWorkList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^
                status = SearchMsgProc(out pccCpMsgStWorkList, parsePccCpMsgStWork, readMode, logicalMode, ref sqlConnection, dateSearchFlag);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //PCC�L�����y�[���Ώېݒ�}�X�^
                    status = SearchTgtProc(out pccCpTgtStWorkList, parsePccCpTgtStWork, readMode, logicalMode, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //PCC�L�����y�[���i�ڐݒ�}�X�^
                        status = SearchItmProc(out pccCpItmStWorkList, parsePccCpItmStWork, readMode, logicalMode, ref sqlConnection);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
      
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="parsePccCpMsgStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        ///  <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="dateSearchFlag">0:���t���������Ȃ�1�F���t��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int SearchMsgProc(out object pccCpMsgStWorkList, PccCpMsgStWork parsePccCpMsgStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, int dateSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCpMsgStWorkList = null;

            // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
            bool inqOtherEpFlg = StringChk(parsePccCpMsgStWork.InqOtherEpCd);   //�⍇�����Ǝw��
            bool inqOtherSecFlg = StringChk(parsePccCpMsgStWork.InqOtherSecCd); //�⍇���拒�_�w��
            // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,APPLYSTADATERF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,APPLYENDDATERF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,PCCMSGDOCCNTSRF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNNAMERF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNOBJDIVRF ").Append(Environment.NewLine);
                sqlTxt.Append("    FROM PCCCPMSGSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (inqOtherEpFlg && inqOtherSecFlg)
                {
                    // �⍇�����ƁE���_���w�肳��Ă���
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                }
                else if (inqOtherEpFlg)
                {
                    // �⍇�����Ƃ̂ݎw�肳��Ă���
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                }
                else if (inqOtherSecFlg)
                {
                    // �⍇���拒�_�̂ݎw�肳��Ă���
                    sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                }
                else
                {
                    // �⍇�����ƁE���_���w�肳��Ă��Ȃ�
                    sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //�ȉ��̒ǉ������ׂ̈̃_�~�[
                }
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                if (dateSearchFlag == 1)
                {
                    sqlTxt.Append("   AND APPLYSTADATERF <= @FINDAPPLYSTADATE").Append(Environment.NewLine);
                    sqlTxt.Append("   AND APPLYENDDATERF >= @FINDAPPLYENDDATE").Append(Environment.NewLine);
                }
                //�_���폜�敪
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlTxt.Append("  ORDER BY INQOTHEREPCDRF,INQOTHERSECCDRF, CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                string  month = DateTime.Now.Month.ToString();
                if (month.Length == 1)
                {
                    month = "0" + month;
                }
                string day = DateTime.Now.Day.ToString();
                if (day.Length == 1)
                {
                    day = "0" + day;
                }
                string dateTime = DateTime.Now.Year + month + day;
                SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpMsgStWork.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpMsgStWork.InqOtherSecCd);
                if (dateSearchFlag == 1)
                {
                    SqlParameter findParaApplystaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
                    SqlParameter findParaApplyendDate = sqlCommand.Parameters.Add("@FINDAPPLYENDDATE", SqlDbType.Int);
                    findParaApplystaDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(dateTime));
                    findParaApplyendDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(dateTime));
                }
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();
                status = this.CopyPccCpMsgStWorkListFromReader(ref myReader, ref al);
                pccCpMsgStWorkList = al;
            }
            catch(SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.SearchMsgProc", status);
            }
            finally
            {
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
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="parsePccCpTgtStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int SearchTgtProc(out object pccCpTgtStWorkList, PccCpTgtStWork parsePccCpTgtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCpTgtStWorkList = null;

            // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
            bool inqOtherEpFlg = StringChk(parsePccCpTgtStWork.InqOtherEpCd);   //�⍇�����Ǝw��
            bool inqOtherSecFlg = StringChk(parsePccCpTgtStWork.InqOtherSecCd); //�⍇���拒�_�w��
            // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALEPCDRF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALSECCDRF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    FROM PCCCPTGTSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (inqOtherEpFlg && inqOtherSecFlg)
                {
                    // �⍇�����ƁE���_���w�肳��Ă���
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                }
                else if (inqOtherEpFlg)
                {
                    // �⍇�����Ƃ̂ݎw�肳��Ă���
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                }
                else if (inqOtherSecFlg)
                {
                    // �⍇���拒�_�̂ݎw�肳��Ă���
                    sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                }
                else
                {
                    // �⍇�����ƁE���_���w�肳��Ă��Ȃ�
                    sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //�ȉ��̒ǉ������ׂ̈̃_�~�[
                }
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                //�_���폜�敪
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlTxt.Append("  ORDER BY INQOTHEREPCDRF,INQOTHERSECCDRF, CAMPAIGNCODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpTgtStWork.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpTgtStWork.InqOtherSecCd);
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();
                status = this.CopyPccCpTgtStWorkListFromReader(ref myReader, ref al);
                pccCpTgtStWorkList = al;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.SearchTgtProc", status);
            }
            finally
            {
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
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="parsePccCpItmStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int SearchItmProc(out object pccCpItmStWorkList, PccCpItmStWork parsePccCpItmStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {           
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCpItmStWorkList = null;

            // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
            bool inqOtherEpFlg = StringChk(parsePccCpItmStWork.InqOtherEpCd);   //�⍇�����Ǝw��
            bool inqOtherSecFlg = StringChk(parsePccCpItmStWork.InqOtherSecCd); //�⍇���拒�_�w��
            // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,GOODSNORF").Append(Environment.NewLine);
                sqlTxt.Append("      ,GOODSMAKERCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,GOODSNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,GOODSNAMEKANARF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMQTYRF").Append(Environment.NewLine);
                sqlTxt.Append("    FROM PCCCPITMSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (inqOtherEpFlg && inqOtherSecFlg)
                {
                    // �⍇�����ƁE���_���w�肳��Ă���
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                }
                else if (inqOtherEpFlg)
                {
                    // �⍇�����Ƃ̂ݎw�肳��Ă���
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                }
                else if (inqOtherSecFlg)
                {
                    // �⍇���拒�_�̂ݎw�肳��Ă���
                    sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                }
                else
                {
                    // �⍇�����ƁE���_���w�肳��Ă��Ȃ�
                    sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //�ȉ��̒ǉ������ׂ̈̃_�~�[
                }
                // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                
                //�_���폜�敪
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlTxt.Append("  ORDER BY INQOTHEREPCDRF,INQOTHERSECCDRF, CAMPAIGNCODERF, CAMPSTDIVRF,BLGOODSCODERF,GOODSNORF,GOODSMAKERCDRF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpItmStWork.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpItmStWork.InqOtherSecCd);
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();
                status = this.CopyPccCpItmStWorkListFromReader(ref myReader, ref al);
                pccCpItmStWorkList = al;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.SearchItmProc", status);
            }
            finally
            {
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
            }
            return status;
        }
       
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="dateSearchFlag">0:���t���������Ȃ�1�F���t��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Read(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, int dateSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^
                status = ReadMsgProc(ref pccCpMsgStWorkList,readMode, logicalMode, ref sqlConnection, dateSearchFlag);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //PCC�L�����y�[���Ώېݒ�}�X�^
                    status = ReadTgtProc(ref pccCpTgtStWorkList, readMode, logicalMode, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //PCC�L�����y�[���i�ڐݒ�}�X�^
                        status = ReadItmProc(ref pccCpItmStWorkList, readMode, logicalMode, ref sqlConnection);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Read");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        ///  <param name="sqlConnection">�R�l�N�V����</param>
        ///  <param name="dateSearchFlag">0:���t���������Ȃ�1�F���t��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int ReadMsgProc(ref object pccCpMsgStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, int dateSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccCpMsgStWorkArrList = null;
            ArrayList pccCpMsgStWorkArrListNew = null;
            try
            {
                if (pccCpMsgStWorkList != null)
                {
                    pccCpMsgStWorkArrList = pccCpMsgStWorkList as ArrayList;

                }
                if (pccCpMsgStWorkArrList == null || pccCpMsgStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpMsgStWorkArrListNew = new ArrayList();

                foreach (PccCpMsgStWork parsePccCpMsgStWork in pccCpMsgStWorkArrList)
                {
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    bool inqOtherEpFlg = StringChk(parsePccCpMsgStWork.InqOtherEpCd);   //�⍇�����Ǝw��
                    bool inqOtherSecFlg = StringChk(parsePccCpMsgStWork.InqOtherSecCd); //�⍇���拒�_�w��
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    StringBuilder sqlTxt = new StringBuilder(string.Empty);
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                    sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                    sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,APPLYSTADATERF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,APPLYENDDATERF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,PCCMSGDOCCNTSRF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNNAMERF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNOBJDIVRF ").Append(Environment.NewLine);
                    sqlTxt.Append("    FROM PCCITEMGRPRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    if (inqOtherEpFlg && inqOtherSecFlg)
                    {
                        // �⍇�����ƁE���_���w�肳��Ă���
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    }
                    else if (inqOtherEpFlg)
                    {
                        // �⍇�����Ƃ̂ݎw�肳��Ă���
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    }
                    else if (inqOtherSecFlg)
                    {
                        // �⍇���拒�_�̂ݎw�肳��Ă���
                        sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    }
                    else
                    {
                        // �⍇�����ƁE���_���w�肳��Ă��Ȃ�
                        sqlTxt.Append("   1 = 1").Append(Environment.NewLine); // �ȉ��̒ǉ������ׂ̈̃_�~�[
                    }
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                    if (dateSearchFlag == 1)
                    {
                        sqlTxt.Append("   AND APPLYSTADATERF <= @FINDAPPLYSTADATE").Append(Environment.NewLine);
                        sqlTxt.Append("   AND APPLYENDDATERF >= @FINDAPPLYENDDATE").Append(Environment.NewLine);
                    }
                    //�_���폜�敪
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    }
                    if (!string.IsNullOrEmpty(wkstring))
                    {
                        sqlTxt.Append(wkstring).Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }

                    sqlTxt.Append("  ORDER BY INQOTHEREPCDRF,INQOTHERSECCDRF,CAMPAIGNCODERF").Append(Environment.NewLine);
                    sqlCommand.CommandText = sqlTxt.ToString();

                    string month = DateTime.Now.Month.ToString();
                    if (month.Length == 1)
                    {
                        month = "0" + month;
                    }
                    string day = DateTime.Now.Day.ToString();
                    if (day.Length == 1)
                    {
                        day = "0" + day;
                    }
                    string dateTime = DateTime.Now.Year + month + day;
                    SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                    findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpMsgStWork.InqOtherEpCd);
                    findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpMsgStWork.InqOtherSecCd);
                    findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(parsePccCpMsgStWork.CampaignCode);
                    if (dateSearchFlag == 1)
                    {
                        SqlParameter findParaApplystaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
                        SqlParameter findParaApplyendDate = sqlCommand.Parameters.Add("@FINDAPPLYENDDATE", SqlDbType.Int);
                        findParaApplystaDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(dateTime));
                        findParaApplyendDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(dateTime));
                    }
                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    myReader = sqlCommand.ExecuteReader();
                    ArrayList pccCpMsgStWorkArrListEach = new ArrayList();
                    status = this.CopyPccCpMsgStWorkListFromReader(ref myReader, ref pccCpMsgStWorkArrListNew);
                    pccCpMsgStWorkArrListNew.AddRange(pccCpMsgStWorkArrListEach);
                }
                pccCpMsgStWorkList = pccCpMsgStWorkArrListNew;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.ReadMsgProc", status);
            }
            finally
            {
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
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int ReadTgtProc(ref object pccCpTgtStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccCpTgtStWorkArrList = null;
            ArrayList pccCpTgtStWorkArrListNew = null;
            try
            {
                if (pccCpTgtStWorkList != null)
                {
                    pccCpTgtStWorkArrList = pccCpTgtStWorkList as ArrayList;
                }
                if (pccCpTgtStWorkArrList == null || pccCpTgtStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpTgtStWorkArrListNew = new ArrayList();

                foreach (PccCpTgtStWork parsePccCpTgtStWork in pccCpTgtStWorkArrList)
                {
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    bool inqOtherEpFlg = StringChk(parsePccCpTgtStWork.InqOtherEpCd);   //�⍇�����Ǝw��
                    bool inqOtherSecFlg = StringChk(parsePccCpTgtStWork.InqOtherSecCd); //�⍇���拒�_�w��
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                    StringBuilder sqlTxt = new StringBuilder(string.Empty);
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                    sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                    sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQORIGINALEPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQORIGINALSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("    FROM PCCCPTGTSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    if (inqOtherEpFlg && inqOtherSecFlg)
                    {
                        // �⍇�����ƁE���_���w�肳��Ă���
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    }
                    else if (inqOtherEpFlg)
                    {
                        // �⍇�����Ƃ̂ݎw�肳��Ă���
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    }
                    else if (inqOtherSecFlg)
                    {
                        // �⍇���拒�_�̂ݎw�肳��Ă���
                        sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    }
                    else
                    {
                        // �⍇�����ƁE���_���w�肳��Ă��Ȃ�
                        sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //�ȉ��̒ǉ������ׂ̈̃_�~�[
                    }
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);

                    //�_���폜�敪
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    }
                    if (!string.IsNullOrEmpty(wkstring))
                    {
                        sqlTxt.Append(wkstring).Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    sqlCommand.CommandText = sqlTxt.ToString();

                    SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                    findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpTgtStWork.InqOtherEpCd);
                    findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpTgtStWork.InqOtherSecCd);
                    findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(parsePccCpTgtStWork.CampaignCode);
                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    myReader = sqlCommand.ExecuteReader();
                    ArrayList pccCpTgtStWorkArrListEach = new ArrayList();
                    status = this.CopyPccCpTgtStWorkListFromReader(ref myReader, ref pccCpTgtStWorkArrListEach);
                    pccCpTgtStWorkArrListNew.AddRange(pccCpTgtStWorkArrListEach);
                }
                pccCpTgtStWorkList = pccCpTgtStWorkArrListNew;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.ReadTgtProc", status);
            }
            finally
            {
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
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int ReadItmProc(ref object pccCpItmStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList pccCpItmStWorkArrList = null;
            ArrayList pccCpItmStWorkArrListNew = null; 
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCpItmStWorkList != null)
                {
                    pccCpItmStWorkArrList = pccCpItmStWorkList as ArrayList;
                }
                if (pccCpItmStWorkArrList == null || pccCpItmStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpItmStWorkArrListNew = new ArrayList();
                foreach (PccCpItmStWork parsePccCpItmStWork in pccCpItmStWorkArrList)
                {
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    bool inqOtherEpFlg = StringChk(parsePccCpItmStWork.InqOtherEpCd);   //�⍇�����Ǝw��
                    bool inqOtherSecFlg = StringChk(parsePccCpItmStWork.InqOtherSecCd); //�⍇���拒�_�w��
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                    StringBuilder sqlTxt = new StringBuilder(string.Empty);
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                    sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                    sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("       CAMPSTDIVRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,BLGOODSCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,GOODSNORF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,GOODSMAKERCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,GOODSNAMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,GOODSNAMEKANARF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMQTYRF").Append(Environment.NewLine);
                    sqlTxt.Append("    FROM PCCCPITMSTRF WITH(READUNCOMMITTED)  ").Append(Environment.NewLine);
                    sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    if (inqOtherEpFlg && inqOtherSecFlg)
                    {
                        // �⍇�����ƁE���_���w�肳��Ă���
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    }
                    else if (inqOtherEpFlg)
                    {
                        // �⍇�����Ƃ̂ݎw�肳��Ă���
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    }
                    else if (inqOtherSecFlg)
                    {
                        // �⍇���拒�_�̂ݎw�肳��Ă���
                        sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    }
                    else
                    {
                        // �⍇�����ƁE���_���w�肳��Ă��Ȃ�
                        sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //�ȉ��̒ǉ������ׂ̈̃_�~�[
                    }
                    // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);

                    //�_���폜�敪
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    }
                    if (!string.IsNullOrEmpty(wkstring))
                    {
                        sqlTxt.Append(wkstring).Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    sqlCommand.CommandText = sqlTxt.ToString();

                    SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                    findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpItmStWork.InqOtherEpCd);
                    findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpItmStWork.InqOtherSecCd);
                    findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(parsePccCpItmStWork.CampaignCode);
                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    myReader = sqlCommand.ExecuteReader();
                    ArrayList pccCpItmStWorkArrListEach = new ArrayList();
                    status = this.CopyPccCpItmStWorkListFromReader(ref myReader, ref pccCpItmStWorkArrListEach);
                    pccCpItmStWorkArrListNew.AddRange(pccCpItmStWorkArrListEach);
                }

                pccCpItmStWorkList = pccCpItmStWorkArrListNew;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.ReadItmProc", status);
            }
            finally
            {
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
            }
            return status;
        }
       
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDelete(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);
                // PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^
                status = LogicalDeleteMsgProc(ref pccCpMsgStWorkList, 0, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //PCC�L�����y�[���Ώېݒ�}�X�^
                    status = LogicalDeleteTgtProc(ref pccCpTgtStWorkList,0, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //PCC�L�����y�[���i�ڐݒ�}�X�^
                        status = LogicalDeleteItmProc(ref pccCpItmStWorkList, 0, ref sqlConnection, ref sqlTransaction);
                
                    }
                };
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.LogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccItmStWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDeleteItmProc(ref object pccItmStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlCommand sqlCommand = null;
            ArrayList pccItmGrpWorkArrList = null;
            ArrayList pccItmGrpWorkArrListNew = null;
            try
            {
                if (pccItmStWorkList != null)
                {
                    pccItmGrpWorkArrList = pccItmStWorkList as ArrayList;

                }
                if (pccItmGrpWorkArrList == null || pccItmGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItmGrpWorkArrListNew = new ArrayList();


                for (int i = 0; i < pccItmGrpWorkArrList.Count; i++)
                {
                    PccCpItmStWork pccItmWorkEach = pccItmGrpWorkArrList[i] as PccCpItmStWork;
                    status = LogicalDeleteProcItmEach(ref pccItmWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItmGrpWorkArrListNew.Add(pccItmWorkEach);


                }
                pccItmStWorkList = pccItmGrpWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpItmStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpItmStDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {               
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }            
            return status;
        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpItmStWorkEach">PCC�i�ڃO���[�v</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDeleteProcItmEach(ref PccCpItmStWork pccCpItmStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int logicalDelCd = 0;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPITMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            SqlParameter findParaCampStDiv = sqlCommand.Parameters.Add("@FINDCAMPSTDIVRF", SqlDbType.Int);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
            findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccCpItmStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //���݂̘_���폜�敪���擾
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE PCCCPITMSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
                findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
                pccCpItmStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }

            if (!myReader.IsClosed) myReader.Close();

            //�_���폜���[�h�̏ꍇ
            if (procMode == 0)
            {

                if (logicalDelCd == 0) pccCpItmStWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g

            }
            else
            {
                if (logicalDelCd == 1) pccCpItmStWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������

            }

            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpItmStWorkEach.UpdateDateTime);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccTgtStWorkList">PPCC�L�����y�[���Ώېݒ�}�X�^�O���[�v�f�[�^���X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDeleteTgtProc(ref object pccTgtStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;           
            SqlCommand sqlCommand = null;
            ArrayList pccTgtStWorkArrList = null;
            ArrayList pccTgtStWorkArrListNew = null;
            try
            {
                if (pccTgtStWorkList != null)
                {
                    pccTgtStWorkArrList = pccTgtStWorkList as ArrayList;

                }
                if (pccTgtStWorkArrList == null || pccTgtStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccTgtStWorkArrListNew = new ArrayList();


                for (int i = 0; i < pccTgtStWorkArrList.Count; i++)
                {
                    PccCpTgtStWork pccTgtWorkEach = pccTgtStWorkArrList[i] as PccCpTgtStWork;
                    status = LogicalDeleteProcTgtEach(ref pccTgtWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccTgtStWorkArrListNew.Add(pccTgtWorkEach);


                }
                pccTgtStWorkList = pccTgtStWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {                
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpMsgStWorkEach">PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�O���[�v</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDeleteProcMsgEach(ref PccCpMsgStWork pccCpMsgStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPMSGSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);

            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccCpMsgStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //���݂̘_���폜�敪���擾
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE PCCCPMSGSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);


                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
                pccCpMsgStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }

            if (!myReader.IsClosed) myReader.Close();

            //�_���폜���[�h�̏ꍇ
            if (procMode == 0)
            {

                if (logicalDelCd == 0) pccCpMsgStWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g

            }
            else
            {
                if (logicalDelCd == 1) pccCpMsgStWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������

            }

            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpMsgStWorkEach.UpdateDateTime);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccMsgStWorkList">PCC�L�����y�[���Ώېݒ�}�X�^�^�O���[�v�f�[�^���X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDeleteMsgProc(ref object pccMsgStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
           
            SqlCommand sqlCommand = null;
            ArrayList pccMsgStWorArrList = null;
            ArrayList pccMsgStWorArrListNew = null;
            try
            {
                if (pccMsgStWorkList != null)
                {
                    pccMsgStWorArrList = pccMsgStWorkList as ArrayList;

                }
                if (pccMsgStWorArrList == null || pccMsgStWorArrList.Count == 0)
                {
                    return status;
                }
                pccMsgStWorArrListNew = new ArrayList();


                for (int i = 0; i < pccMsgStWorArrList.Count; i++)
                {
                    PccCpMsgStWork pccMsgWorkEach = pccMsgStWorArrList[i] as PccCpMsgStWork;
                    status = LogicalDeleteProcMsgEach(ref pccMsgWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccMsgStWorArrListNew.Add(pccMsgWorkEach);


                }
                pccMsgStWorkList = pccMsgStWorArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpTgtStWorkEach">PCC�L�����y�[���Ώېݒ�}�X�^�O���[�v</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDeleteProcTgtEach(ref PccCpTgtStWork pccCpTgtStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPTGTSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqoriginalEpcd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqoriginaLSeccd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
            findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccCpTgtStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //���݂̘_���폜�敪���擾
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sqlTxt.Append("UPDATE PCCCPTGTSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("WHERE").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

                sqlCommand.CommandText = sqlTxt.ToString();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaInqoriginalEpcd1 = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqoriginaLSeccd1 = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqotherEpcd1 = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqotherSeccd1 = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                SqlParameter findParaCampaignCode1 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                //KEY�R�}���h���Đݒ�
                findParaInqoriginalEpcd1.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
                findParaInqoriginaLSeccd1.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
                findParaInqotherEpcd1.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd1.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
                findParaCampaignCode1.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
                pccCpTgtStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }

            if (!myReader.IsClosed) myReader.Close();

            //�_���폜���[�h�̏ꍇ
            if (procMode == 0)
            {

                if (logicalDelCd == 0) pccCpTgtStWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g

            }
            else
            {
                if (logicalDelCd == 1) pccCpTgtStWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������

            }

            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpTgtStWorkEach.UpdateDateTime);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
       
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Delete(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                 //PCC�L�����y�[���i�ڐݒ�}�X�^
                status = DeleteItmProc(ref pccCpItmStWorkList, ref sqlConnection,ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //PCC�L�����y�[���Ώېݒ�}�X�^
                    status = DeleteTgtProc(ref pccCpTgtStWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^
                        status = DeleteMsgProc(ref pccCpMsgStWorkList, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Delete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteItmProc(ref object pccCpItmStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccCpItmStWorkArrList = null;
            ArrayList pccCpItmStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCpItmStWorkList != null)
                {
                    pccCpItmStWorkArrList = pccCpItmStWorkList as ArrayList;

                }
                if (pccCpItmStWorkArrList == null || pccCpItmStWorkArrList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                pccCpItmStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCpItmStWorkArrList.Count; i++)
                {
                    PccCpItmStWork pccItmWorkEach = pccCpItmStWorkArrList[i] as PccCpItmStWork;
                    status = DeleteProcItmEach(ref pccItmWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCpItmStWorkArrListNew.Add(pccItmWorkEach);

                }

                pccCpItmStWorkList = pccCpItmStWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpItmStDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpItmStDB.Delete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
            }
            return status;
        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpItmStWorkEach">PCC�i�ڃO���[�v</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteProcItmEach(ref PccCpItmStWork pccCpItmStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPITMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            SqlParameter findParaCampStDiv = sqlCommand.Parameters.Add("@FINDCAMPSTDIVRF", SqlDbType.Int);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
            findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccCpItmStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCCPITMSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
                findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                sqlConnection.Close();
                return status;
            }
            if (!myReader.IsClosed) myReader.Close();

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�}�X�^�O���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteTgtProc(ref object pccCpTgtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccCpTgtStWorkArrList = null;
            ArrayList pccCpTgtStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCpTgtStWorkList != null)
                {
                    pccCpTgtStWorkArrList = pccCpTgtStWorkList as ArrayList;

                }
                if (pccCpTgtStWorkArrList == null || pccCpTgtStWorkArrList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                pccCpTgtStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCpTgtStWorkArrList.Count; i++)
                {
                    PccCpTgtStWork pccTgtWorkEach = pccCpTgtStWorkArrList[i] as PccCpTgtStWork;
                    status = DeleteProcTgtEach(ref pccTgtWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCpTgtStWorkArrListNew.Add(pccTgtWorkEach);

                }

                pccCpTgtStWorkList = pccCpTgtStWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.Delete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpTgtStWorkEach">PCC�L�����y�[���Ώېݒ�}�X�^�O���[�v</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteProcTgtEach(ref PccCpTgtStWork pccCpTgtStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPTGTSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqoriginalEpcd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqoriginaLSeccd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
            findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccCpTgtStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCCPTGTSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
                findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                sqlConnection.Close();
                return status;
            }
            if (!myReader.IsClosed) myReader.Close();

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�O���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteMsgProc(ref object pccCpMsgStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccCpMsgStWorkArrList = null;
            ArrayList pccCpMsgStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCpMsgStWorkList != null)
                {
                    pccCpMsgStWorkArrList = pccCpMsgStWorkList as ArrayList;

                }
                if (pccCpMsgStWorkArrList == null || pccCpMsgStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpMsgStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCpMsgStWorkArrList.Count; i++)
                {
                    PccCpMsgStWork pccMsgWorkEach = pccCpMsgStWorkArrList[i] as PccCpMsgStWork;
                    status = DeleteProcMsgEach(ref pccMsgWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCpMsgStWorkArrListNew.Add(pccMsgWorkEach);

                }

                pccCpMsgStWorkList = pccCpMsgStWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.Delete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpMsgStWorkEach">PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�O���[�v</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteProcMsgEach(ref PccCpMsgStWork pccCpMsgStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPMSGSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);

            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccCpMsgStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCCPMSGSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                sqlConnection.Close();
                return status;
            }
            if (!myReader.IsClosed) myReader.Close();

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
 
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                //PCC�L�����y�[���i�ڐݒ�}�X�^
                status = RevivalLogicalDeleteItmProc(ref pccCpItmStWorkList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // PCC�L�����y�[���Ώېݒ�}�X�^
                    status = RevivalLogicalDeleteTgtProc(ref pccCpTgtStWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^
                        status = RevivalLogicalDeleteMsgProc(ref pccCpMsgStWorkList, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.RevivalLogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�}�X�^�O���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteItmProc(ref object pccCpItmStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteItmProc(ref pccCpItmStWorkList, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// // PCC�L�����y�[���Ώېݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpTgtStWorkList">// PCC�L�����y�[���Ώېݒ�}�X�^�O���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteTgtProc(ref object pccCpTgtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteTgtProc(ref pccCpTgtStWorkList, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        ///PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�O���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteMsgProc(ref object pccCpMsgStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteMsgProc(ref pccCpMsgStWorkList, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            return status;
        }

        #endregion

        #region ��������
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�擾����
        /// </summary>
        /// <param name="myReader">PCC�L�����y�[�����b�Z�[�W�ݒ�Reader</param>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyPccCpMsgStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccCpMsgStWorkList)
        {
            pccCpMsgStWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //�쐬����
            int colIndex_CreateDateTime = 0;
            //�X�V����
            int colIndex_UpdateDateTime = 0;
            //�_���폜�敪
            int colIndex_LogicalDeleteCode = 0;
            //�⍇�����ƃR�[�h
            int colIndex_InqOtherEpCd = 0;
            //�⍇���拒�_�R�[�h
            int colIndex_InqOtherSecCd = 0;
            //�L�����y�[���R�[�h
            int colIndex_CampaignCode = 0;
            //�K�p�J�n��
            int colIndex_ApplyStaDate = 0;
            //�K�p�I����
            int colIndex_ApplyEndDate = 0;
            //PCC���b�Z�[�W�{��
            int colIndex_PccMsgDocCnts = 0;
            //�L�����y�[������
            int colIndex_CampaignName = 0;
            //�L�����y�[���Ώۋ敪
            int colIndex_CampaignObjDiv = 0;

            try
            {
                if (myReader.HasRows)
                {
                    //�쐬����
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    //�X�V����
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    //�_���폜�敪
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    //�⍇�����ƃR�[�h
                    colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                    //�⍇���拒�_�R�[�h
                    colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                    //�L�����y�[���R�[�h
                    colIndex_CampaignCode = myReader.GetOrdinal("CAMPAIGNCODERF");
                    //�K�p�J�n��
                    colIndex_ApplyStaDate = myReader.GetOrdinal("APPLYSTADATERF");
                    //�K�p�I����
                    colIndex_ApplyEndDate = myReader.GetOrdinal("APPLYENDDATERF");
                    //PCC���b�Z�[�W�{��
                    colIndex_PccMsgDocCnts = myReader.GetOrdinal("PCCMSGDOCCNTSRF");
                    //�L�����y�[������
                    colIndex_CampaignName = myReader.GetOrdinal("CAMPAIGNNAMERF");
                    //�L�����y�[���Ώۋ敪
                    colIndex_CampaignObjDiv = myReader.GetOrdinal("CAMPAIGNOBJDIVRF");
                }
                while (myReader.Read())
                {
                    PccCpMsgStWork pccCpMsgStWork = new PccCpMsgStWork();
                    //�쐬����
                    pccCpMsgStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //�X�V����
                    pccCpMsgStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //�_���폜�敪
                    pccCpMsgStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //�⍇�����ƃR�[�h
                    pccCpMsgStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //�⍇���拒�_�R�[�h
                    pccCpMsgStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //�L�����y�[���R�[�h
                    pccCpMsgStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampaignCode);
                    //�K�p�J�n��
                    pccCpMsgStWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_ApplyStaDate);
                    //�K�p�I����
                    pccCpMsgStWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_ApplyEndDate);
                    //PCC���b�Z�[�W�{��
                    pccCpMsgStWork.PccMsgDocCnts = SqlDataMediator.SqlGetString(myReader, colIndex_PccMsgDocCnts);
                    //�L�����y�[������
                    pccCpMsgStWork.CampaignName = SqlDataMediator.SqlGetString(myReader, colIndex_CampaignName);
                    //�L�����y�[���Ώۋ敪
                    pccCpMsgStWork.CampaignObjDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampaignObjDiv);
                    pccCpMsgStWorkList.Add(pccCpMsgStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccCpMsgStWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���Ώېݒ�擾����
        /// </summary>
        /// <param name="myReader">PCC�L�����y�[���Ώېݒ�Reader</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyPccCpTgtStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccCpTgtStWorkList)
        {
            pccCpTgtStWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //�쐬����
            int colIndex_CreateDateTime = 0;
            //�X�V����
            int colIndex_UpdateDateTime = 0;
            //�_���폜�敪
            int colIndex_LogicalDeleteCode = 0;
            //�⍇������ƃR�[�h
            int colIndex_InqOriginalEpCd = 0;
            //�⍇�������_�R�[�h
            int colIndex_InqOriginalSecCd = 0;
            //�⍇�����ƃR�[�h
            int colIndex_InqOtherEpCd = 0;
            //�⍇���拒�_�R�[�h
            int colIndex_InqOtherSecCd = 0;
            //�L�����y�[���R�[�h
            int colIndex_CampaignCode = 0;
            try
            {
                if (myReader.HasRows)
                {
                    //�쐬����
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    //�X�V����
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    //�_���폜�敪
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    //�⍇������ƃR�[�h
                    colIndex_InqOriginalEpCd = myReader.GetOrdinal("INQORIGINALEPCDRF");
                    //�⍇�������_�R�[�h
                    colIndex_InqOriginalSecCd = myReader.GetOrdinal("INQORIGINALSECCDRF");
                    //�⍇�����ƃR�[�h
                    colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                    //�⍇���拒�_�R�[�h
                    colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                    //�L�����y�[���R�[�h
                    colIndex_CampaignCode = myReader.GetOrdinal("CAMPAIGNCODERF");
                }
                while (myReader.Read())
                {
                    PccCpTgtStWork pccCpTgtStWork = new PccCpTgtStWork();
                    //�쐬����
                    pccCpTgtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //�X�V����
                    pccCpTgtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //�_���폜�敪
                    pccCpTgtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //�⍇������ƃR�[�h
                    pccCpTgtStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                    //�⍇�������_�R�[�h
                    pccCpTgtStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //�⍇�����ƃR�[�h
                    pccCpTgtStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //�⍇���拒�_�R�[�h
                    pccCpTgtStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //�L�����y�[���R�[�h
                    pccCpTgtStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampaignCode);
                    pccCpTgtStWorkList.Add(pccCpTgtStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccCpTgtStWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�擾����
        /// </summary>
        /// <param name="myReader">PCC�L�����y�[���i�ڐݒ�Reader</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyPccCpItmStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccCpItmStWorkList)
        {
            pccCpItmStWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //�쐬����
            int colIndex_CreateDateTime = 0;
            //�X�V����
            int colIndex_UpdateDateTime = 0;
            //�_���폜�敪
            int colIndex_LogicalDeleteCode = 0;
            //�⍇�����ƃR�[�h
            int colIndex_InqOtherEpCd = 0;
            //�⍇���拒�_�R�[�h
            int colIndex_InqOtherSecCd = 0;
            //�L�����y�[���R�[�h
            int colIndex_CampaignCode = 0;
            //�L�����y�[���ݒ�敪
            int colIndex_CampStDiv = 0;
            //BL���i�R�[�h
            int colIndex_BLGoodsCode = 0;
            //���i�ԍ�
            int colIndex_GoodsNo = 0;
            //���i���[�J�[�R�[�h
            int colIndex_GoodsMakerCd = 0;
            //���i����
            int colIndex_GoodsName = 0;
            //���i���̃J�i
            int colIndex_GoodsNameKana = 0;
            //�i��QTY
            int colIndex_ItemQty = 0;
            try
            {
                if (myReader.HasRows)
                {
                    //�쐬����
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    //�X�V����
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    //�_���폜�敪
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    //�⍇�����ƃR�[�h
                    colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                    //�⍇���拒�_�R�[�h
                    colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                    //�L�����y�[���R�[�h
                    colIndex_CampaignCode = myReader.GetOrdinal("CAMPAIGNCODERF");
                    //�L�����y�[���ݒ�敪
                    colIndex_CampStDiv = myReader.GetOrdinal("CAMPSTDIVRF");
                    //BL���i�R�[�h
                    colIndex_BLGoodsCode = myReader.GetOrdinal("BLGOODSCODERF");
                    //���i�ԍ�
                    colIndex_GoodsNo = myReader.GetOrdinal("GOODSNORF");
                    //���i���[�J�[�R�[�h
                    colIndex_GoodsMakerCd = myReader.GetOrdinal("GOODSMAKERCDRF");
                    //���i����
                    colIndex_GoodsName = myReader.GetOrdinal("GOODSNAMERF");
                    //���i���̃J�i
                    colIndex_GoodsNameKana = myReader.GetOrdinal("GOODSNAMEKANARF");
                    //�i��QTY
                    colIndex_ItemQty = myReader.GetOrdinal("ITEMQTYRF");
                }
                while (myReader.Read())
                {
                    PccCpItmStWork pccCpItmStWork = new PccCpItmStWork();
                    //�쐬����
                    pccCpItmStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //�X�V����
                    pccCpItmStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //�_���폜�敪
                    pccCpItmStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //�⍇�����ƃR�[�h
                    pccCpItmStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //�⍇���拒�_�R�[�h
                    pccCpItmStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //�L�����y�[���R�[�h
                    pccCpItmStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampaignCode);
                    //�L�����y�[���ݒ�敪
                    pccCpItmStWork.CampStDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampStDiv);
                    //BL���i�R�[�h
                    pccCpItmStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsCode);
                    //���i�ԍ�
                    pccCpItmStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsNo);
                    //���i���[�J�[�R�[�h
                    pccCpItmStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsMakerCd);
                    //���i����
                    pccCpItmStWork.GoodsName = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsName);
                    //���i���̃J�i
                    pccCpItmStWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsNameKana);
                    //�i��QTY
                    pccCpItmStWork.ItemQty = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemQty);
                    pccCpItmStWorkList.Add(pccCpItmStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccCpItmStWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// PCC�L�����y�[���ݒ�擾����
        /// </summary>
        /// <param name="myReader">PCC�L�����y�[���i�ڐݒ�Reader</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyMsgAndStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccCpMsgStWorkList, ref ArrayList pccCpItmStWorkList)
        {
            pccCpItmStWorkList = new ArrayList();
            pccCpMsgStWorkList = new ArrayList();
            // --- UPD 2012/11/27 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��83 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // Dictionary<int, string> campaignCodeDic = new Dictionary<int, string>();
            Dictionary<string, string> campaignCodeDic = new Dictionary<string, string>();
            // --- UPD 2012/11/27 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��83 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //�쐬����
            int colIndexA_CreateDateTime = 0;
            //�X�V����
            int colIndexA_UpdateDateTime = 0;
            //�_���폜�敪
            int colIndexA_LogicalDeleteCode = 0;
            //�⍇�����ƃR�[�h
            int colIndexA_InqOtherEpCd = 0;
            //�⍇���拒�_�R�[�h
            int colIndexA_InqOtherSecCd = 0;
            //�L�����y�[���R�[�h
            int colIndexA_CampaignCode = 0;
            //�K�p�J�n��
            int colIndexA_ApplyStaDate = 0;
            //�K�p�I����
            int colIndexA_ApplyEndDate = 0;
            //PCC���b�Z�[�W�{��
            int colIndexA_PccMsgDocCnts = 0;
            //�L�����y�[������
            int colIndexA_CampaignName = 0;
            //�L�����y�[���Ώۋ敪
            int colIndexA_CampaignObjDiv = 0;

            //�쐬����
            int colIndexB_CreateDateTime = 0;
            //�X�V����
            int colIndexB_UpdateDateTime = 0;
            //�_���폜�敪
            int colIndexB_LogicalDeleteCode = 0;
            //�⍇�����ƃR�[�h
            int colIndexB_InqOtherEpCd = 0;
            //�⍇���拒�_�R�[�h
            int colIndexB_InqOtherSecCd = 0;
            //�L�����y�[���R�[�h
            int colIndexB_CampaignCode = 0;
            //�L�����y�[���ݒ�敪
            int colIndexB_CampStDiv = 0;
            //BL���i�R�[�h
            int colIndexB_BLGoodsCode = 0;
            //���i�ԍ�
            int colIndexB_GoodsNo = 0;
            //���i���[�J�[�R�[�h
            int colIndexB_GoodsMakerCd = 0;
            //���i����
            int colIndexB_GoodsName = 0;
            //���i���̃J�i
            int colIndexB_GoodsNameKana = 0;
            //�i��QTY
            int colIndexB_ItemQty = 0;
            try
            {
                if (myReader.HasRows)
                {
                    //�쐬����
                    colIndexA_CreateDateTime = myReader.GetOrdinal("MSGSTCREATEDATETIMERF");
                    //�X�V����
                    colIndexA_UpdateDateTime = myReader.GetOrdinal("MSGSTUPDATEDATETIMERF");
                    //�_���폜�敪
                    colIndexA_LogicalDeleteCode = myReader.GetOrdinal("MSGSTLOGICALDELETECODERF");
                    //�⍇�����ƃR�[�h
                    colIndexA_InqOtherEpCd = myReader.GetOrdinal("MSGSTINQOTHEREPCDRF");
                    //�⍇���拒�_�R�[�h
                    colIndexA_InqOtherSecCd = myReader.GetOrdinal("MSGSTINQOTHERSECCDRF");
                    //�L�����y�[���R�[�h
                    colIndexA_CampaignCode = myReader.GetOrdinal("MSGSTCAMPAIGNCODERF");
                    //�K�p�J�n��
                    colIndexA_ApplyStaDate = myReader.GetOrdinal("MSGSTAPPLYSTADATERF");
                    //�K�p�I����
                    colIndexA_ApplyEndDate = myReader.GetOrdinal("MSGSTAPPLYENDDATERF");
                    //PCC���b�Z�[�W�{��
                    colIndexA_PccMsgDocCnts = myReader.GetOrdinal("MSGSTPCCMSGDOCCNTSRF");
                    //�L�����y�[������
                    colIndexA_CampaignName = myReader.GetOrdinal("MSGSTCAMPAIGNNAMERF");
                    //�L�����y�[���Ώۋ敪
                    colIndexA_CampaignObjDiv = myReader.GetOrdinal("MSGSTCAMPAIGNOBJDIVRF");

                    //�쐬����
                    colIndexB_CreateDateTime = myReader.GetOrdinal("ITMSTCREATEDATETIMERF");
                    //�X�V����
                    colIndexB_UpdateDateTime = myReader.GetOrdinal("ITMSTUPDATEDATETIMERF");
                    //�_���폜�敪
                    colIndexB_LogicalDeleteCode = myReader.GetOrdinal("ITMSTLOGICALDELETECODERF");
                    //�⍇�����ƃR�[�h
                    colIndexB_InqOtherEpCd = myReader.GetOrdinal("ITMSTINQOTHEREPCDRF");
                    //�⍇���拒�_�R�[�h
                    colIndexB_InqOtherSecCd = myReader.GetOrdinal("ITMSTINQOTHERSECCDRF");
                    //�L�����y�[���R�[�h
                    colIndexB_CampaignCode = myReader.GetOrdinal("ITMSTCAMPAIGNCODERF");
                    //�L�����y�[���ݒ�敪
                    colIndexB_CampStDiv = myReader.GetOrdinal("ITMSTCAMPSTDIVRF");
                    //BL���i�R�[�h
                    colIndexB_BLGoodsCode = myReader.GetOrdinal("ITMSTBLGOODSCODERF");
                    //���i�ԍ�
                    colIndexB_GoodsNo = myReader.GetOrdinal("ITMSTGOODSNORF");
                    //���i���[�J�[�R�[�h
                    colIndexB_GoodsMakerCd = myReader.GetOrdinal("ITMSTGOODSMAKERCDRF");
                    //���i����
                    colIndexB_GoodsName = myReader.GetOrdinal("ITMSTGOODSNAMERF");
                    //���i���̃J�i
                    colIndexB_GoodsNameKana = myReader.GetOrdinal("ITMSTGOODSNAMEKANARF");
                    //�i��QTY
                    colIndexB_ItemQty = myReader.GetOrdinal("ITEMQTYRF");
                }
                while (myReader.Read())
                {
                    PccCpMsgStWork pccCpMsgStWork = new PccCpMsgStWork();
                    //�L�����y�[���R�[�h
                    pccCpMsgStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndexA_CampaignCode);
                    // --- UPD 2012/11/27 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��83 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //�⍇�����ƃR�[�h
                    pccCpMsgStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndexA_InqOtherEpCd);
                    //�⍇���拒�_�R�[�h
                    pccCpMsgStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndexA_InqOtherSecCd);
                    // if (!campaignCodeDic.ContainsKey(pccCpMsgStWork.CampaignCode))
                    if (!campaignCodeDic.ContainsKey(pccCpMsgStWork.InqOtherEpCd + ',' + pccCpMsgStWork.InqOtherSecCd + ',' + pccCpMsgStWork.CampaignCode))
                    // --- UPD 2012/11/27 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��83 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        //�쐬����
                        pccCpMsgStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndexA_CreateDateTime);
                        //�X�V����
                        pccCpMsgStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndexA_UpdateDateTime);
                        //�_���폜�敪
                        pccCpMsgStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndexA_LogicalDeleteCode);
                        // --- DEL 2012/11/27 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��83 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        ////�⍇�����ƃR�[�h
                        //pccCpMsgStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndexA_InqOtherEpCd);
                        ////�⍇���拒�_�R�[�h
                        //pccCpMsgStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndexA_InqOtherSecCd);
                        // --- DEL 2012/11/27 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��83 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        //�L�����y�[���R�[�h
                        pccCpMsgStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndexA_CampaignCode);
                        //�K�p�J�n��
                        pccCpMsgStWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, colIndexA_ApplyStaDate);
                        //�K�p�I����
                        pccCpMsgStWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, colIndexA_ApplyEndDate);
                        //PCC���b�Z�[�W�{��
                        pccCpMsgStWork.PccMsgDocCnts = SqlDataMediator.SqlGetString(myReader, colIndexA_PccMsgDocCnts);
                        //�L�����y�[������
                        pccCpMsgStWork.CampaignName = SqlDataMediator.SqlGetString(myReader, colIndexA_CampaignName);
                        //�L�����y�[���Ώۋ敪
                        pccCpMsgStWork.CampaignObjDiv = SqlDataMediator.SqlGetInt32(myReader, colIndexA_CampaignObjDiv);
                        pccCpMsgStWorkList.Add(pccCpMsgStWork);
                        // --- UPD 2012/11/27 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��83 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        // campaignCodeDic.Add(pccCpMsgStWork.CampaignCode, pccCpMsgStWork.CampaignName);
                        campaignCodeDic.Add(pccCpMsgStWork.InqOtherEpCd + ',' + pccCpMsgStWork.InqOtherSecCd + ',' + pccCpMsgStWork.CampaignCode, pccCpMsgStWork.CampaignName);
                        // --- UPD 2012/11/27 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��83 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    PccCpItmStWork pccCpItmStWork = new PccCpItmStWork();
                    //�쐬����
                    pccCpItmStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndexB_CreateDateTime);
                    //�X�V����
                    pccCpItmStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndexB_UpdateDateTime);
                    //�_���폜�敪
                    pccCpItmStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndexB_LogicalDeleteCode);
                    //�⍇�����ƃR�[�h
                    pccCpItmStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndexB_InqOtherEpCd);
                    //�⍇���拒�_�R�[�h
                    pccCpItmStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndexB_InqOtherSecCd);
                    //�L�����y�[���R�[�h
                    pccCpItmStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndexB_CampaignCode);
                    //�L�����y�[���ݒ�敪
                    pccCpItmStWork.CampStDiv = SqlDataMediator.SqlGetInt32(myReader, colIndexB_CampStDiv);
                    //BL���i�R�[�h
                    pccCpItmStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndexB_BLGoodsCode);
                    //���i�ԍ�
                    pccCpItmStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, colIndexB_GoodsNo);
                    //���i���[�J�[�R�[�h
                    pccCpItmStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, colIndexB_GoodsMakerCd);
                    //���i����
                    pccCpItmStWork.GoodsName = SqlDataMediator.SqlGetString(myReader, colIndexB_GoodsName);
                    //���i���̃J�i
                    pccCpItmStWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, colIndexB_GoodsNameKana);
                    //�i��QTY
                    pccCpItmStWork.ItemQty = SqlDataMediator.SqlGetInt32(myReader, colIndexB_ItemQty);
                    pccCpItmStWorkList.Add(pccCpItmStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccCpItmStWorkList.Count == 0 && pccCpMsgStWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���e���ݒ肳��Ă��邩�`�F�b�N
        /// </summary>
        /// <param name="para">������</param>
        /// <returns>true:�ݒ肳��Ă��� false:�ݒ肳��Ă��Ȃ�</returns>
        private bool StringChk(string para)
        {
            if ((para == null) || (para.Trim() == "")) return false;

            return true;
        }
        // --- ADD 2012/11/07 �O�� 2012/12/12�z�M�� SCM��Q��10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

    }
}
