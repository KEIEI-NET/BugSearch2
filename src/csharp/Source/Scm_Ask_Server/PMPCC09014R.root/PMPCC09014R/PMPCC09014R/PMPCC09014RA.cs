//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC���Аݒ�}�X�^�����e
// �v���O�����T�v   : PCC���Аݒ�}�X�^�����eDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q 
// �C �� ��  2013.02.12  �C�����e : SCM��Q��10342,10343�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q 
// �C �� ��  2013/09/13  �C�����e : SCM�d�|�ꗗ��10571�Ή� �Q�Ƒq�ɃR�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070147-00 �쐬�S�� : ���N�n��
// �� �� ��  2014/07/23  �C�����e : SCM�d�|�ꗗ��10659��1���݌ɐ��\���敪�̒ǉ�     
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30746 ���� ��
// �C �� ��  2014/09/04  �C�����e : SCM�d�|�ꗗ��10678�Ή��@�񓚔[���\���敪�ǉ�
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PCC���Аݒ�}�X�^�����e�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC���Аݒ�}�X�^�����e�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.04</br>
    /// <br></br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2014/07/23</br>
    /// <br>Update Note: Redmine#43080��1���݌ɐ��\���敪�̒ǉ�</br>
    /// </remarks>
    [Serializable]
    public class PccCmpnyStDB : RemoteDB, IPccCmpnyStDB
    {

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public PccCmpnyStDB() : base("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork", "PCCCMPNYSTRF")
        {
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
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
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //�g�����U�N�V������������

        #region IPccCmpnyStDB �����o

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Write(ref object pccCmpnyStWorkList)
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
                // write���s
                status = WriteProc(ref pccCmpnyStWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Write");
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
        /// PCC���Аݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int WriteProc(ref object pccCmpnyStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;

            ArrayList pccCmpnyStWorkArrList = null;
            ArrayList pccCmpnyStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCmpnyStWorkList != null)
                {
                    pccCmpnyStWorkArrList = pccCmpnyStWorkList as ArrayList;

                }
                if (pccCmpnyStWorkArrList == null || pccCmpnyStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCmpnyStWorkArrListNew = new ArrayList();
                for (int i = 0; i < pccCmpnyStWorkArrList.Count; i++)
                {
                    PccCmpnyStWork pccCmpnyStWorkEach = pccCmpnyStWorkArrList[i] as PccCmpnyStWork;
                    status = this.WriteCmpnyStProcEach(ref pccCmpnyStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    pccCmpnyStWorkArrListNew.Add(pccCmpnyStWorkEach);
                }

                pccCmpnyStWorkList = pccCmpnyStWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCmpnyStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Write");
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
        /// PCC���Аݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCmpnyStWorkEach">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteCmpnyStProcEach(ref PccCmpnyStWork pccCmpnyStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Select�R�}���h�̐���
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCMPNYSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            //Redmind #24310
            findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccCmpnyStWorkEach.UpdateDateTime)
                {
                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                    if (pccCmpnyStWorkEach.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("     UPDATE PCCCMPNYSTRF SET CREATEDATETIMERF=@CREATEDATETIME ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       UPDATEDATETIMERF=@UPDATEDATETIME ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       LOGICALDELETECODERF=@LOGICALDELETECODE ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQORIGINALEPCDRF=@INQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQORIGINALSECCDRF=@INQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQOTHEREPCDRF=@INQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQOTHERSECCDRF=@INQOTHERSECCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCCOMPANYCODERF=@PCCCOMPANYCODE ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCWAREHOUSECDRF=@PCCWAREHOUSECD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCPRIWAREHOUSECD1RF=@PCCPRIWAREHOUSECD1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCPRIWAREHOUSECD2RF=@PCCPRIWAREHOUSECD2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCPRIWAREHOUSECD3RF=@PCCPRIWAREHOUSECD3 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       GOODSNODSPDIVRF=@GOODSNODSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       LISTPRCDSPDIVRF=@LISTPRCDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       COSTDSPDIVRF=@COSTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       SHELFDSPDIVRF=@SHELFDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       COMMENTDSPDIVRF=@COMMENTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       SPMTCNTDSPDIVRF=@SPMTCNTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       ACPTCNTDSPDIVRF=@ACPTCNTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELGDNODSPDIVRF=@PRTSELGDNODSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELLSPRDSPDIVRF=@PRTSELLSPRDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELSELFDSPDIVRF=@PRTSELSELFDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLNAME1RF=@PCCSUPLNAME1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLNAME2RF=@PCCSUPLNAME2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLKANARF=@PCCSUPLKANA ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLSNMRF=@PCCSUPLSNM ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLPOSTNORF=@PCCSUPLPOSTNO ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLADDR1RF=@PCCSUPLADDR1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLADDR2RF=@PCCSUPLADDR2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLADDR3RF=@PCCSUPLADDR3 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLTELNO1RF=@PCCSUPLTELNO1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLTELNO2RF=@PCCSUPLTELNO2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSUPLFAXNORF=@PCCSUPLFAXNO ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PCCSLIPPRTDIVRF=@PCCSLIPPRTDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       STCKSTCOMMENT1RF=@STCKSTCOMMENT1 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       STCKSTCOMMENT2RF=@STCKSTCOMMENT2 ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       STCKSTCOMMENT3RF=@STCKSTCOMMENT3 ").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                sqlTxt.Append(" ,       WAREHOUSEDSPDIVRF=@WAREHOUSEDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       CANCELDSPDIVRF=@CANCELDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       GOODSNODSPDIVODRF=@GOODSNODSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       LISTPRCDSPDIVODRF=@LISTPRCDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       COSTDSPDIVODRF=@COSTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       SHELFDSPDIVODRF=@SHELFDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       STOCKDSPDIVODRF=@STOCKDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       COMMENTDSPDIVODRF=@COMMENTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       SPMTCNTDSPDIVODRF=@SPMTCNTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       ACPTCNTDSPDIVODRF=@ACPTCNTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELGDNODSPDIVODRF=@PRTSELGDNODSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELLSPRDSPDIVODRF=@PRTSELLSPRDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELSELFDSPDIVODRF=@PRTSELSELFDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRTSELSTCKDSPDIVODRF=@PRTSELSTCKDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       WAREHOUSEDSPDIVODRF=@WAREHOUSEDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       CANCELDSPDIVODRF=@CANCELDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQODRDSPDIVSETRF=@INQODRDSPDIVSET ").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                sqlTxt.Append(" ,       PCCPRIWAREHOUSECD4RF=@PCCPRIWAREHOUSECD4 ").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                sqlTxt.Append(" ,       PRSNTSTKCTDSPDIVODRF=@PRSNTSTKCTDSPDIVOD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       PRSNTSTKCTDSPDIVRF=@PRSNTSTKCTDSPDIV ").Append(Environment.NewLine);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                sqlTxt.Append(" ,       ANSDELIDTDSPDIVRF=@ANSDELIDTDSPDIV ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       ANSDELIDTDSPDIVODRF=@ANSDELIDTDSPDIVOD ").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHEREPCDRF=@FINDINQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();
                //KEY�R�}���h���Đݒ�
                ////Redmind #24310
                findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);

                //�R�l�N�V����������擾�Ή�����������
                //�X�V�w�b�_����ݒ�
                pccCmpnyStWorkEach.UpdateDateTime = DateTime.Now;

            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                if (pccCmpnyStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //�V�K�쐬����SQL���𐶐�
                sqlTxt.Append("     INSERT INTO PCCCMPNYSTRF").Append(Environment.NewLine);
                sqlTxt.Append("      (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCWAREHOUSECDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLKANARF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLSNMRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLPOSTNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLFAXNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT3RF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                sqlTxt.Append("     , WAREHOUSEDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STOCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSTCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , WAREHOUSEDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQODRDSPDIVSETRF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                sqlTxt.Append("     , PCCPRIWAREHOUSECD4RF").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVRF").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                sqlTxt.Append("     , ANSDELIDTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ANSDELIDTDSPDIVODRF").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                sqlTxt.Append("    ) VALUES (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCWAREHOUSECD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCPRIWAREHOUSECD1").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCPRIWAREHOUSECD2").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCPRIWAREHOUSECD3").Append(Environment.NewLine);
                sqlTxt.Append("     , @GOODSNODSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @LISTPRCDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @COSTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @SHELFDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @COMMENTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @SPMTCNTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @ACPTCNTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELGDNODSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELLSPRDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELSELFDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLNAME1").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLNAME2").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLKANA").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLSNM").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLPOSTNO").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLADDR1").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLADDR2").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLADDR3").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLTELNO1").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLTELNO2").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSUPLFAXNO").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCSLIPPRTDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @STCKSTCOMMENT1").Append(Environment.NewLine);
                sqlTxt.Append("     , @STCKSTCOMMENT2").Append(Environment.NewLine);
                sqlTxt.Append("     , @STCKSTCOMMENT3").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                sqlTxt.Append("     , @WAREHOUSEDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @CANCELDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @GOODSNODSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @LISTPRCDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @COSTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @SHELFDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @STOCKDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @COMMENTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @SPMTCNTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @ACPTCNTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELGDNODSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELLSPRDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELSELFDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRTSELSTCKDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @WAREHOUSEDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @CANCELDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQODRDSPDIVSET").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                sqlTxt.Append("     , @PCCPRIWAREHOUSECD4").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                sqlTxt.Append("     , @PRSNTSTKCTDSPDIVOD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PRSNTSTKCTDSPDIV").Append(Environment.NewLine);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                sqlTxt.Append("     , @ANSDELIDTDSPDIV").Append(Environment.NewLine);
                sqlTxt.Append("     , @ANSDELIDTDSPDIVOD").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                sqlTxt.Append("     )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�o�^�w�b�_����ݒ�
                pccCmpnyStWorkEach.UpdateDateTime = DateTime.Now;
                pccCmpnyStWorkEach.CreateDateTime = DateTime.Now;
                pccCmpnyStWorkEach.LogicalDeleteCode = 0;
            }
            if (!myReader.IsClosed) myReader.Close();
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
            SqlParameter paraPccCompanyCode = sqlCommand.Parameters.Add("@PCCCOMPANYCODE", SqlDbType.Int);
            SqlParameter paraPccWarehouseCd = sqlCommand.Parameters.Add("@PCCWAREHOUSECD", SqlDbType.NChar);
            SqlParameter paraPccPriWarehouseCd1 = sqlCommand.Parameters.Add("@PCCPRIWAREHOUSECD1", SqlDbType.NChar);
            SqlParameter paraPccPriWarehouseCd2 = sqlCommand.Parameters.Add("@PCCPRIWAREHOUSECD2", SqlDbType.NChar);
            SqlParameter paraPccPriWarehouseCd3 = sqlCommand.Parameters.Add("@PCCPRIWAREHOUSECD3", SqlDbType.NChar);
            SqlParameter paraGoodsNoDspDiv = sqlCommand.Parameters.Add("@GOODSNODSPDIV", SqlDbType.Int);
            SqlParameter paraListPrcDspDiv = sqlCommand.Parameters.Add("@LISTPRCDSPDIV", SqlDbType.Int);
            SqlParameter paraCostDspDiv = sqlCommand.Parameters.Add("@COSTDSPDIV", SqlDbType.Int);
            SqlParameter paraShelfDspDiv = sqlCommand.Parameters.Add("@SHELFDSPDIV", SqlDbType.Int);
            SqlParameter paraCommentDspDiv = sqlCommand.Parameters.Add("@COMMENTDSPDIV", SqlDbType.Int);
            SqlParameter paraSpmtCntDspDiv = sqlCommand.Parameters.Add("@SPMTCNTDSPDIV", SqlDbType.Int);
            SqlParameter paraAcptCntDspDiv = sqlCommand.Parameters.Add("@ACPTCNTDSPDIV", SqlDbType.Int);
            SqlParameter paraPrtSelGdNoDspDiv = sqlCommand.Parameters.Add("@PRTSELGDNODSPDIV", SqlDbType.Int);
            SqlParameter paraPrtSelLsPrDspDiv = sqlCommand.Parameters.Add("@PRTSELLSPRDSPDIV", SqlDbType.Int);
            SqlParameter paraPrtSelSelfDspDiv = sqlCommand.Parameters.Add("@PRTSELSELFDSPDIV", SqlDbType.Int);
            SqlParameter paraPccSuplName1 = sqlCommand.Parameters.Add("@PCCSUPLNAME1", SqlDbType.NVarChar);
            SqlParameter paraPccSuplName2 = sqlCommand.Parameters.Add("@PCCSUPLNAME2", SqlDbType.NVarChar);
            SqlParameter paraPccSuplKana = sqlCommand.Parameters.Add("@PCCSUPLKANA", SqlDbType.NVarChar);
            SqlParameter paraPccSuplSnm = sqlCommand.Parameters.Add("@PCCSUPLSNM", SqlDbType.NVarChar);
            SqlParameter paraPccSuplPostNo = sqlCommand.Parameters.Add("@PCCSUPLPOSTNO", SqlDbType.NVarChar);
            SqlParameter paraPccSuplAddr1 = sqlCommand.Parameters.Add("@PCCSUPLADDR1", SqlDbType.NVarChar);
            SqlParameter paraPccSuplAddr2 = sqlCommand.Parameters.Add("@PCCSUPLADDR2", SqlDbType.NVarChar);
            SqlParameter paraPccSuplAddr3 = sqlCommand.Parameters.Add("@PCCSUPLADDR3", SqlDbType.NVarChar);
            SqlParameter paraPccSuplTelNo1 = sqlCommand.Parameters.Add("@PCCSUPLTELNO1", SqlDbType.NVarChar);
            SqlParameter paraPccSuplTelNo2 = sqlCommand.Parameters.Add("@PCCSUPLTELNO2", SqlDbType.NVarChar);
            SqlParameter paraPccSuplFaxNo = sqlCommand.Parameters.Add("@PCCSUPLFAXNO", SqlDbType.NVarChar);
            SqlParameter paraPccSlipPrtDiv = sqlCommand.Parameters.Add("@PCCSLIPPRTDIV", SqlDbType.Int);
            SqlParameter paraStckComment1 = sqlCommand.Parameters.Add("@STCKSTCOMMENT1", SqlDbType.NVarChar);
            SqlParameter paraStckComment2 = sqlCommand.Parameters.Add("@STCKSTCOMMENT2", SqlDbType.NVarChar);
            SqlParameter paraStckComment3 = sqlCommand.Parameters.Add("@STCKSTCOMMENT3", SqlDbType.NVarChar);
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            SqlParameter paraWarehouseDspDiv = sqlCommand.Parameters.Add("@WAREHOUSEDSPDIV", SqlDbType.Int);
            SqlParameter paraCancelDspDiv = sqlCommand.Parameters.Add("@CANCELDSPDIV", SqlDbType.Int);
            SqlParameter paraGoodsNoDspDivOd = sqlCommand.Parameters.Add("@GOODSNODSPDIVOD", SqlDbType.Int);
            SqlParameter paraListPrcDspDivOd = sqlCommand.Parameters.Add("@LISTPRCDSPDIVOD", SqlDbType.Int);
            SqlParameter paraCostDspDivOd = sqlCommand.Parameters.Add("@COSTDSPDIVOD", SqlDbType.Int);
            SqlParameter paraShelfDspDivOd = sqlCommand.Parameters.Add("@SHELFDSPDIVOD", SqlDbType.Int);
            SqlParameter paraStockDspDivOd = sqlCommand.Parameters.Add("@STOCKDSPDIVOD", SqlDbType.Int);
            SqlParameter paraCommentDspDivOd = sqlCommand.Parameters.Add("@COMMENTDSPDIVOD", SqlDbType.Int);
            SqlParameter paraSpmtCntDspDivOd = sqlCommand.Parameters.Add("@SPMTCNTDSPDIVOD", SqlDbType.Int);
            SqlParameter paraAcptCntDspDivOd = sqlCommand.Parameters.Add("@ACPTCNTDSPDIVOD", SqlDbType.Int);
            SqlParameter paraPrtSelGdNoDspDivOd = sqlCommand.Parameters.Add("@PRTSELGDNODSPDIVOD", SqlDbType.Int);
            SqlParameter paraPrtSelLsPrDspDivOd = sqlCommand.Parameters.Add("@PRTSELLSPRDSPDIVOD", SqlDbType.Int);
            SqlParameter paraPrtSelSelfDspDivOd = sqlCommand.Parameters.Add("@PRTSELSELFDSPDIVOD", SqlDbType.Int);
            SqlParameter paraPrtSelStckDspDivOd = sqlCommand.Parameters.Add("@PRTSELSTCKDSPDIVOD", SqlDbType.Int);
            SqlParameter paraWarehouseDspDivOd = sqlCommand.Parameters.Add("@WAREHOUSEDSPDIVOD", SqlDbType.Int);
            SqlParameter paraCancelDspDivOd = sqlCommand.Parameters.Add("@CANCELDSPDIVOD", SqlDbType.Int);
            SqlParameter paraInqOdrDspDivSet = sqlCommand.Parameters.Add("@INQODRDSPDIVSET", SqlDbType.Int);
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            SqlParameter paraPccPriWarehouseCd4 = sqlCommand.Parameters.Add("@PCCPRIWAREHOUSECD4", SqlDbType.NChar);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            SqlParameter paraPrsntStkCtDspDivOd = sqlCommand.Parameters.Add("@PRSNTSTKCTDSPDIVOD", SqlDbType.SmallInt);
            SqlParameter paraPrsntStkCtDspDiv = sqlCommand.Parameters.Add("@PRSNTSTKCTDSPDIV", SqlDbType.SmallInt);
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            SqlParameter paraAnsDeliDtDspDiv = sqlCommand.Parameters.Add("@ANSDELIDTDSPDIV", SqlDbType.SmallInt);
            SqlParameter paraAnsDeliDtDspDivOd = sqlCommand.Parameters.Add("@ANSDELIDTDSPDIVOD", SqlDbType.SmallInt);
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

            //Prameter�I�u�W�F�N�g�̍쐬
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCmpnyStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCmpnyStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.LogicalDeleteCode);
            //Redmind #24310
            paraInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
            paraInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
            paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PccCompanyCode);
            paraPccWarehouseCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccWarehouseCd);
            paraPccPriWarehouseCd1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccPriWarehouseCd1);
            paraPccPriWarehouseCd2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccPriWarehouseCd2);
            paraPccPriWarehouseCd3.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccPriWarehouseCd3);
            paraGoodsNoDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.GoodsNoDspDiv);
            paraListPrcDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.ListPrcDspDiv);
            paraCostDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CostDspDiv);
            paraShelfDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.ShelfDspDiv);
            paraCommentDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CommentDspDiv);
            paraSpmtCntDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.SpmtCntDspDiv);
            paraAcptCntDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.AcptCntDspDiv);
            paraPrtSelGdNoDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelGdNoDspDiv);
            paraPrtSelLsPrDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelLsPrDspDiv);
            paraPrtSelSelfDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelSelfDspDiv);
            paraPccSuplName1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplName1);
            paraPccSuplName2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplName2);
            paraPccSuplKana.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplKana);
            paraPccSuplSnm.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplSnm);
            paraPccSuplPostNo.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplPostNo);
            paraPccSuplAddr1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplAddr1);
            paraPccSuplAddr2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplAddr2);
            paraPccSuplAddr3.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplAddr3);
            paraPccSuplTelNo1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplTelNo1);
            paraPccSuplTelNo2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplTelNo2);
            paraPccSuplFaxNo.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccSuplFaxNo);
            paraPccSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PccSlipPrtDiv);
            paraStckComment1.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.StckStComment1);
            paraStckComment2.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.StckStComment2);
            paraStckComment3.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.StckStComment3);
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            paraWarehouseDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.WarehouseDspDiv);
            paraCancelDspDiv.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CancelDspDiv);
            paraGoodsNoDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.GoodsNoDspDivOd);
            paraListPrcDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.ListPrcDspDivOd);
            paraCostDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CostDspDivOd);
            paraShelfDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.ShelfDspDivOd);
            paraStockDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.StockDspDivOd);
            paraCommentDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CommentDspDivOd);
            paraSpmtCntDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.SpmtCntDspDivOd);
            paraAcptCntDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.AcptCntDspDivOd);
            paraPrtSelGdNoDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelGdNoDspDivOd);
            paraPrtSelLsPrDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelLsPrDspDivOd);
            paraPrtSelSelfDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelSelfDspDivOd);
            paraPrtSelStckDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.PrtSelStckDspDivOd);
            paraWarehouseDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.WarehouseDspDivOd);
            paraCancelDspDivOd.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.CancelDspDivOd);
            paraInqOdrDspDivSet.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.InqOdrDspDivSet);
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            paraPccPriWarehouseCd4.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.PccPriWarehouseCd4);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            paraPrsntStkCtDspDivOd.Value = SqlDataMediator.SqlSetShort(pccCmpnyStWorkEach.PrsntStkCtDspDivOd);
            paraPrsntStkCtDspDiv.Value = SqlDataMediator.SqlSetShort(pccCmpnyStWorkEach.PrsntStkCtDspDiv);
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            paraAnsDeliDtDspDiv.Value = SqlDataMediator.SqlSetShort(pccCmpnyStWorkEach.AnsDeliDtDspDiv);
            paraAnsDeliDtDspDivOd.Value = SqlDataMediator.SqlSetShort(pccCmpnyStWorkEach.AnsDeliDtDspDivOd);
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="parsePccCmpnyStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Search(out object pccCmpnyStWorkList, PccCmpnyStWork parsePccCmpnyStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            pccCmpnyStWorkList = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(out pccCmpnyStWorkList, parsePccCmpnyStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Search");
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
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="parsePccCmpnyStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int SearchProc(out object pccCmpnyStWorkList, PccCmpnyStWork parsePccCmpnyStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCmpnyStWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCWAREHOUSECDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLKANARF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLSNMRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLPOSTNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLFAXNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT3RF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                sqlTxt.Append("     , WAREHOUSEDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STOCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSTCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , WAREHOUSEDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQODRDSPDIVSETRF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                sqlTxt.Append("     , PCCPRIWAREHOUSECD4RF").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVRF").Append(Environment.NewLine);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                sqlTxt.Append("     , ANSDELIDTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ANSDELIDTDSPDIVODRF").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                sqlTxt.Append("      FROM PCCCMPNYSTRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalEpCd))
                {
                    sqlTxt.Append("    INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parsePccCmpnyStWork.InqOriginalEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalEpCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parsePccCmpnyStWork.InqOriginalSecCd);
                }
                if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOtherEpCd))
                {
                    if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalEpCd) || !string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalSecCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append( Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parsePccCmpnyStWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalEpCd) || !string.IsNullOrEmpty(parsePccCmpnyStWork.InqOriginalSecCd) || !string.IsNullOrEmpty(parsePccCmpnyStWork.InqOtherEpCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append( Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parsePccCmpnyStWork.InqOtherSecCd);
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
                sqlTxt.Append("  ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromSearch(myReader, out al);

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCmpnyStDB.SearchProc", status);
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


            pccCmpnyStWorkList = al;

            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Read(ref object pccCmpnyStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref pccCmpnyStWorkList, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Read");
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
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int ReadProc(ref object pccCmpnyStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            PccCmpnyStWork wkPccCmpnyStWorkOld = null;
            PccCmpnyStWork wkPccCmpnyStWorkNew = null;
            ArrayList alOld = new ArrayList();
            if (pccCmpnyStWorkList != null)
            {
                wkPccCmpnyStWorkOld = pccCmpnyStWorkList as PccCmpnyStWork;
            }
            else
            {
                return status;
            }
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCmpnyStWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCWAREHOUSECDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCPRIWAREHOUSECD3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLNAME2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLKANARF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLSNMRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLPOSTNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLADDR3RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLTELNO2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSUPLFAXNORF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT1RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT2RF").Append(Environment.NewLine);
                sqlTxt.Append("     , STCKSTCOMMENT3RF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                sqlTxt.Append("     , WAREHOUSEDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , LISTPRCDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COSTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SHELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , STOCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , COMMENTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , SPMTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ACPTCNTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELGDNODSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELLSPRDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSELFDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRTSELSTCKDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , WAREHOUSEDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CANCELDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQODRDSPDIVSETRF").Append(Environment.NewLine);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                sqlTxt.Append("     , PCCPRIWAREHOUSECD4RF").Append(Environment.NewLine);
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVODRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PRSNTSTKCTDSPDIVRF").Append(Environment.NewLine);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                sqlTxt.Append("     , ANSDELIDTDSPDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("     , ANSDELIDTDSPDIVODRF").Append(Environment.NewLine);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                sqlTxt.Append("      FROM PCCCMPNYSTRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHEREPCDRF=@FINDINQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);

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

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                
                //KEY�R�}���h���Đݒ�
                //Redmind #24310
                findParaInqOriginalEpCd.Value = wkPccCmpnyStWorkOld.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value =wkPccCmpnyStWorkOld.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(wkPccCmpnyStWorkOld.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(wkPccCmpnyStWorkOld.InqOtherSecCd);
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromRead(myReader, ref wkPccCmpnyStWorkNew);
                if (wkPccCmpnyStWorkNew == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCmpnyStDB.ReadProc", status);
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


            pccCmpnyStWorkList = wkPccCmpnyStWorkNew;

            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int LogicalDelete(ref object pccCmpnyStWorkList)
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
                status = LogicalDeleteProc(ref pccCmpnyStWorkList, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.LogicalDelete");
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
        /// PCC���Аݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int LogicalDeleteProc(ref object pccCmpnyStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccCmpnyStWorkArrList = null;
            ArrayList pccCmpnyStWorkArrListNew = null;
            try
            {
                if (pccCmpnyStWorkList != null)
                {
                    pccCmpnyStWorkArrList = pccCmpnyStWorkList as ArrayList;

                }
                if (pccCmpnyStWorkArrList == null || pccCmpnyStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCmpnyStWorkArrListNew = new ArrayList();
                for (int i = 0; i < pccCmpnyStWorkArrList.Count; i++)
                {
                    PccCmpnyStWork pccCmpnyStWorkEach = pccCmpnyStWorkArrList[i] as PccCmpnyStWork;
                    status = LogicalDeleteProcCmpnyEach(ref pccCmpnyStWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCmpnyStWorkArrListNew.Add(pccCmpnyStWorkEach);


                }
                pccCmpnyStWorkList = pccCmpnyStWorkArrListNew as object;

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemGrpWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpWorkDB.LogicalDeleteProc Exception=" + ex.Message);
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
        /// PCC���Аݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCmpnyStWorkEach">PCC���Аݒ�</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDeleteProcCmpnyEach(ref PccCmpnyStWork pccCmpnyStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCMPNYSTRF ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);


            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            //Redmind #24310
            findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccCmpnyStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //���݂̘_���폜�敪���擾
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE PCCCMPNYSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                //Redmind #24310
                findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);

                //�X�V�w�b�_����ݒ�
                //�X�V�w�b�_����ݒ�
                pccCmpnyStWorkEach.UpdateDateTime = DateTime.Now;

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

                if (logicalDelCd == 0) pccCmpnyStWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g

            }
            else
            {
                if (logicalDelCd == 1) pccCmpnyStWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������

            }

            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCmpnyStWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCmpnyStWorkEach.UpdateDateTime);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Delete(ref object pccCmpnyStWorkList)
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

                status = DeleteProc(ref pccCmpnyStWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.Delete");
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
        /// PCC���Аݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int DeleteProc(ref object pccCmpnyStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccCmpnyStWorkArrList = null;
            ArrayList pccCmpnyStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCmpnyStWorkList != null)
                {
                    pccCmpnyStWorkArrList = pccCmpnyStWorkList as ArrayList;

                }
                if (pccCmpnyStWorkArrList == null || pccCmpnyStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCmpnyStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCmpnyStWorkArrList.Count; i++)
                {
                    PccCmpnyStWork pccCmpnyStWorkEach = pccCmpnyStWorkArrList[i] as PccCmpnyStWork;
                    status = DeleteProcCmpnyStEach(ref pccCmpnyStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCmpnyStWorkArrListNew.Add(pccCmpnyStWorkEach);

                }

                pccCmpnyStWorkList = pccCmpnyStWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemGrpWorkDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpWorkDB.Delete Exception=" + ex.Message);
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
        /// PCC���Аݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCmpnyStWorkEach">PCC���Аݒ�O���[�v</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private int DeleteProcCmpnyStEach(ref PccCmpnyStWork pccCmpnyStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCMPNYSTRF ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);


            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            //Redmind #24310
            findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccCmpnyStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCCMPNYSTRF ").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                //Redmind #24310
                findParaInqOriginalEpCd.Value = pccCmpnyStWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = pccCmpnyStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccCmpnyStWorkEach.InqOtherSecCd);
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
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccCmpnyStWorkList)
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
                status = RevivalLogicalDeleteProc(ref pccCmpnyStWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCmpnyStDB.RevivalLogicalDelete");
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
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object pccCmpnyStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteProc(ref  pccCmpnyStWorkList, 1, ref sqlConnection, ref  sqlTransaction);
        }


        #endregion

        #region ��������
        /// <summary>
        /// PCC���Аݒ�f�[�^�擾����
        /// </summary>
        /// <param name="myReader">PCC���Аݒ�f�[�^Reader</param>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>PCC���Аݒ�f�[�^</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyListFromSearch(SqlDataReader myReader, out ArrayList pccCmpnyStWorkList)
        {
            pccCmpnyStWorkList = new ArrayList();
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
            //PCC���ЃR�[�h
            int colIndex_PccCompanyCode = 0;
            //PCC�q�ɃR�[�h
            int colIndex_PccWarehouseCd = 0;
            //PCC�D��q�ɃR�[�h1
            int colIndex_PccPriWarehouseCd1 = 0;
            //PCC�D��q�ɃR�[�h2
            int colIndex_PccPriWarehouseCd2 = 0;
            //PCC�D��q�ɃR�[�h3
            int colIndex_PccPriWarehouseCd3 = 0;
            //�i�ԕ\���敪
            int colIndex_GoodsNoDspDiv = 0;
            //�W�����i�\���敪
            int colIndex_ListPrcDspDiv = 0;
            //�d�؉��i�\���敪
            int colIndex_CostDspDiv = 0;
            //�I�ԕ\���敪
            int colIndex_ShelfDspDiv = 0;
            //�R�����g�\���敪
            int colIndex_CommentDspDiv = 0;
            //�o�א��\���敪
            int colIndex_SpmtCntDspDiv = 0;
            //�󒍐��\���敪
            int colIndex_AcptCntDspDiv = 0;
            //���i�I��i�ԕ\���敪
            int colIndex_PrtSelGdNoDspDiv = 0;
            //���i�I��W�����i�\���敪
            int colIndex_PrtSelLsPrDspDiv = 0;
            //���i�I��I�ԕ\���敪
            int colIndex_PrtSelSelfDspDiv = 0;
            //PCC�����於��1
            int colIndex_PccSuplName1 = 0;
            //PCC�����於��2
            int colIndex_PccSuplName2 = 0;
            //PCC������J�i����
            int colIndex_PccSuplKana = 0;
            //PCC�����旪��
            int colIndex_PccSuplSnm = 0;
            //PCC������X�֔ԍ�
            int colIndex_PccSuplPostNo = 0;
            //PCC������Z��1
            int colIndex_PccSuplAddr1 = 0;
            //PCC������Z��2
            int colIndex_PccSuplAddr2 = 0;
            //PCC������Z��3
            int colIndex_PccSuplAddr3 = 0;
            //PCC������d�b�ԍ�1
            int colIndex_PccSuplTelNo1 = 0;
            //PCC������d�b�ԍ�2
            int colIndex_PccSuplTelNo2 = 0;
            //PCC������FAX�ԍ�
            int colIndex_PccSuplFaxNo = 0;
            //�`�[���s�敪�iPCC�j
            int colIndex_PccSlipPrtDiv = 0;
            //�`�[���s�敪�iPCC�j
            int colIndex_StckStComment1 = 0;
            //�`�[���s�敪�iPCC�j
            int colIndex_StckStComment2 = 0;
            //�`�[���s�敪�iPCC�j
            int colIndex_StckStComment3 = 0;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            //�q�ɕ\���敪(�⍇��)
            int colIndex_WarehouseDspDiv = 0;
            //����\���敪(�⍇��)
            int colIndex_CancelDspDiv = 0;
            //�i�ԕ\���敪(����)
            int colIndex_GoodsNoDspDivOd = 0;
            //�W�����i�\���敪(����)
            int colIndex_ListPrcDspDivOd = 0;
            //�d�؉��i�\���敪(����)
            int colIndex_CostDspDivOd = 0;
            //�I�ԕ\���敪(����)
            int colIndex_ShelfDspDivOd = 0;
            //�݌ɕ\���敪(����)
            int colIndex_StockDspDivOd = 0;
            //�R�����g�\���敪(����)
            int colIndex_CommentDspDivOd = 0;
            //�o�א��\���敪(����)
            int colIndex_SpmtCntDspDivOd = 0;
            //�󒍐��\���敪(����)
            int colIndex_AcptCntDspDivOd = 0;
            //���i�I��i�ԕ\���敪(����)
            int colIndex_PrtSelGdNoDspDivOd = 0;
            //���i�I��W�����i�\���敪(����)
            int colIndex_PrtSelLsPrDspDivOd = 0;
            //���i�I��I�ԕ\���敪(����)
            int colIndex_PrtSelSelfDspDivOd = 0;
            //���i�I���݌ɕ\���敪(����)
            int colIndex_PrtSelStckDspDivOd = 0;
            //�q�ɕ\���敪(����)
            int colIndex_WarehouseDspDivOd = 0;
            //����\���敪(����)
            int colIndex_CancelDspDivOd = 0;
            //�⍇�������\���敪�ݒ�
            int colIndex_InqOdrDspDivSet = 0;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PCC�D��q�ɃR�[�h4
            int colIndex_PccPriWarehouseCd4 = 0;
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            int colIndex_PrsntStkCtDspDivOd = 0;
            //���݌ɐ��\���敪(�⍇��)
            int colIndex_PrsntStkCtDspDiv = 0;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            int colIndex_AnsDeliDtDspDiv = 0;
            // �񓚔[���\���敪(����)
            int colIndex_AnsDeliDtDspDivOd = 0;
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
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
                //PCC���ЃR�[�h	
                colIndex_PccCompanyCode = myReader.GetOrdinal("PCCCOMPANYCODERF");
                //PCC�q�ɃR�[�h	
                colIndex_PccWarehouseCd = myReader.GetOrdinal("PCCWAREHOUSECDRF");
                //PCC�D��q�ɃR�[�h1	
                colIndex_PccPriWarehouseCd1 = myReader.GetOrdinal("PCCPRIWAREHOUSECD1RF");
                //PCC�D��q�ɃR�[�h2	
                colIndex_PccPriWarehouseCd2 = myReader.GetOrdinal("PCCPRIWAREHOUSECD2RF");
                //PCC�D��q�ɃR�[�h3	
                colIndex_PccPriWarehouseCd3 = myReader.GetOrdinal("PCCPRIWAREHOUSECD3RF");
                //�i�ԕ\���敪	
                colIndex_GoodsNoDspDiv = myReader.GetOrdinal("GOODSNODSPDIVRF");
                //�W�����i�\���敪	
                colIndex_ListPrcDspDiv = myReader.GetOrdinal("LISTPRCDSPDIVRF");
                //�d�؉��i�\���敪	
                colIndex_CostDspDiv = myReader.GetOrdinal("COSTDSPDIVRF");
                //�I�ԕ\���敪	
                colIndex_ShelfDspDiv = myReader.GetOrdinal("SHELFDSPDIVRF");
                //�R�����g�\���敪	
                colIndex_CommentDspDiv = myReader.GetOrdinal("COMMENTDSPDIVRF");
                //�o�א��\���敪	
                colIndex_SpmtCntDspDiv = myReader.GetOrdinal("SPMTCNTDSPDIVRF");
                //�󒍐��\���敪	
                colIndex_AcptCntDspDiv = myReader.GetOrdinal("ACPTCNTDSPDIVRF");
                //���i�I��i�ԕ\���敪	
                colIndex_PrtSelGdNoDspDiv = myReader.GetOrdinal("PRTSELGDNODSPDIVRF");
                //���i�I��W�����i�\���敪	
                colIndex_PrtSelLsPrDspDiv = myReader.GetOrdinal("PRTSELLSPRDSPDIVRF");
                //���i�I��I�ԕ\���敪	
                colIndex_PrtSelSelfDspDiv = myReader.GetOrdinal("PRTSELSELFDSPDIVRF");
                //PCC�����於��1	
                colIndex_PccSuplName1 = myReader.GetOrdinal("PCCSUPLNAME1RF");
                //PCC�����於��2	
                colIndex_PccSuplName2 = myReader.GetOrdinal("PCCSUPLNAME2RF");
                //PCC������J�i����	
                colIndex_PccSuplKana = myReader.GetOrdinal("PCCSUPLKANARF");
                //PCC�����旪��	
                colIndex_PccSuplSnm = myReader.GetOrdinal("PCCSUPLSNMRF");
                //PCC������X�֔ԍ�	
                colIndex_PccSuplPostNo = myReader.GetOrdinal("PCCSUPLPOSTNORF");
                //PCC������Z��1	
                colIndex_PccSuplAddr1 = myReader.GetOrdinal("PCCSUPLADDR1RF");
                //PCC������Z��2	
                colIndex_PccSuplAddr2 = myReader.GetOrdinal("PCCSUPLADDR2RF");
                //PCC������Z��3	
                colIndex_PccSuplAddr3 = myReader.GetOrdinal("PCCSUPLADDR3RF");
                //PCC������d�b�ԍ�1	
                colIndex_PccSuplTelNo1 = myReader.GetOrdinal("PCCSUPLTELNO1RF");
                //PCC������d�b�ԍ�2	
                colIndex_PccSuplTelNo2 = myReader.GetOrdinal("PCCSUPLTELNO2RF");
                //PCC������FAX�ԍ�	
                colIndex_PccSuplFaxNo = myReader.GetOrdinal("PCCSUPLFAXNORF");
                //�`�[���s�敪�iPCC�j	
                colIndex_PccSlipPrtDiv = myReader.GetOrdinal("PCCSLIPPRTDIVRF");
                //�݌ɏ󋵃R�����g1	
                colIndex_StckStComment1 = myReader.GetOrdinal("STCKSTCOMMENT1RF");
                //�݌ɏ󋵃R�����g12	
                colIndex_StckStComment2 = myReader.GetOrdinal("STCKSTCOMMENT2RF");
                //�݌ɏ󋵃R�����g3
                colIndex_StckStComment3 = myReader.GetOrdinal("STCKSTCOMMENT3RF");
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                //�q�ɕ\���敪(�⍇��)
                colIndex_WarehouseDspDiv = myReader.GetOrdinal("WAREHOUSEDSPDIVRF");
                //����\���敪(�⍇��)
                colIndex_CancelDspDiv = myReader.GetOrdinal("CANCELDSPDIVRF");
                //�i�ԕ\���敪(����)
                colIndex_GoodsNoDspDivOd = myReader.GetOrdinal("GOODSNODSPDIVODRF");
                //�W�����i�\���敪(����)
                colIndex_ListPrcDspDivOd = myReader.GetOrdinal("LISTPRCDSPDIVODRF");
                //�d�؉��i�\���敪(����)
                colIndex_CostDspDivOd = myReader.GetOrdinal("COSTDSPDIVODRF");
                //�I�ԕ\���敪(����)
                colIndex_ShelfDspDivOd = myReader.GetOrdinal("SHELFDSPDIVODRF");
                //�݌ɕ\���敪(����)
                colIndex_StockDspDivOd = myReader.GetOrdinal("STOCKDSPDIVODRF");
                //�R�����g�\���敪(����)
                colIndex_CommentDspDivOd = myReader.GetOrdinal("COMMENTDSPDIVODRF");
                //�o�א��\���敪(����)
                colIndex_SpmtCntDspDivOd = myReader.GetOrdinal("SPMTCNTDSPDIVODRF");
                //�󒍐��\���敪(����)
                colIndex_AcptCntDspDivOd = myReader.GetOrdinal("ACPTCNTDSPDIVODRF");
                //���i�I��i�ԕ\���敪(����)
                colIndex_PrtSelGdNoDspDivOd = myReader.GetOrdinal("PRTSELGDNODSPDIVODRF");
                //���i�I��W�����i�\���敪(����)
                colIndex_PrtSelLsPrDspDivOd = myReader.GetOrdinal("PRTSELLSPRDSPDIVODRF");
                //���i�I��I�ԕ\���敪(����)
                colIndex_PrtSelSelfDspDivOd = myReader.GetOrdinal("PRTSELSELFDSPDIVODRF");
                //���i�I���݌ɕ\���敪(����)
                colIndex_PrtSelStckDspDivOd = myReader.GetOrdinal("PRTSELSTCKDSPDIVODRF");
                //�q�ɕ\���敪(����)
                colIndex_WarehouseDspDivOd = myReader.GetOrdinal("WAREHOUSEDSPDIVODRF");
                //����\���敪(����)
                colIndex_CancelDspDivOd = myReader.GetOrdinal("CANCELDSPDIVODRF");
                //�⍇�������\���敪�ݒ�
                colIndex_InqOdrDspDivSet = myReader.GetOrdinal("INQODRDSPDIVSETRF");
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                //PCC�D��q�ɃR�[�h4	
                colIndex_PccPriWarehouseCd4 = myReader.GetOrdinal("PCCPRIWAREHOUSECD4RF");
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                //���݌ɐ��\���敪(����)
                colIndex_PrsntStkCtDspDivOd = myReader.GetOrdinal("PRSNTSTKCTDSPDIVODRF");
                //���݌ɐ��\���敪(�⍇��)
                colIndex_PrsntStkCtDspDiv = myReader.GetOrdinal("PRSNTSTKCTDSPDIVRF");
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                // �񓚔[���\���敪(�⍇��)
                colIndex_AnsDeliDtDspDiv = myReader.GetOrdinal("ANSDELIDTDSPDIVRF");
                // �񓚔[���\���敪(����)
                colIndex_AnsDeliDtDspDivOd = myReader.GetOrdinal("ANSDELIDTDSPDIVODRF");
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            }
            while (myReader.Read())
            {

                PccCmpnyStWork pccCmpnyStWork = new PccCmpnyStWork();
                //�쐬����	 
                pccCmpnyStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //�X�V����	            
                pccCmpnyStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //�_���폜�敪	            
                pccCmpnyStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //�⍇������ƃR�[�h	            
                pccCmpnyStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                //�⍇�������_�R�[�h	            
                pccCmpnyStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                //�⍇�����ƃR�[�h	            
                pccCmpnyStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                //�⍇���拒�_�R�[�h	            
                pccCmpnyStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                //PCC���ЃR�[�h	            
                pccCmpnyStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                //PCC�q�ɃR�[�h	            
                pccCmpnyStWork.PccWarehouseCd = SqlDataMediator.SqlGetString(myReader, colIndex_PccWarehouseCd);
                //PCC�D��q�ɃR�[�h1	            
                pccCmpnyStWork.PccPriWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd1);
                //PCC�D��q�ɃR�[�h2	            
                pccCmpnyStWork.PccPriWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd2);
                //PCC�D��q�ɃR�[�h3	            
                pccCmpnyStWork.PccPriWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd3);
                //�i�ԕ\���敪	            
                pccCmpnyStWork.GoodsNoDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsNoDspDiv);
                //�W�����i�\���敪	            
                pccCmpnyStWork.ListPrcDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ListPrcDspDiv);
                //�d�؉��i�\���敪	            
                pccCmpnyStWork.CostDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CostDspDiv);
                //�I�ԕ\���敪	            
                pccCmpnyStWork.ShelfDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ShelfDspDiv);
                //�R�����g�\���敪	            
                pccCmpnyStWork.CommentDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CommentDspDiv);
                //�o�א��\���敪	            
                pccCmpnyStWork.SpmtCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SpmtCntDspDiv);
                //�󒍐��\���敪	            
                pccCmpnyStWork.AcptCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_AcptCntDspDiv);
                //���i�I��i�ԕ\���敪	            
                pccCmpnyStWork.PrtSelGdNoDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelGdNoDspDiv);
                //���i�I��W�����i�\���敪	            
                pccCmpnyStWork.PrtSelLsPrDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelLsPrDspDiv);
                //���i�I��I�ԕ\���敪	            
                pccCmpnyStWork.PrtSelSelfDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelSelfDspDiv);
                //PCC�����於��1	            
                pccCmpnyStWork.PccSuplName1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplName1);
                //PCC�����於��2	            
                pccCmpnyStWork.PccSuplName2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplName2);
                //PCC������J�i����	            
                pccCmpnyStWork.PccSuplKana = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplKana);
                //PCC�����旪��	            
                pccCmpnyStWork.PccSuplSnm = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplSnm);
                //PCC������X�֔ԍ�	            
                pccCmpnyStWork.PccSuplPostNo = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplPostNo);
                //PCC������Z��1	            
                pccCmpnyStWork.PccSuplAddr1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr1);
                //PCC������Z��2	            
                pccCmpnyStWork.PccSuplAddr2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr2);
                //PCC������Z��3	            
                pccCmpnyStWork.PccSuplAddr3 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr3);
                //PCC������d�b�ԍ�1	            
                pccCmpnyStWork.PccSuplTelNo1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplTelNo1);
                //PCC������d�b�ԍ�2	            
                pccCmpnyStWork.PccSuplTelNo2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplTelNo2);
                //PCC������FAX�ԍ�	            
                pccCmpnyStWork.PccSuplFaxNo = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplFaxNo);
                //�`�[���s�敪�iPCC�j	            
                pccCmpnyStWork.PccSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccSlipPrtDiv);
                //�`�[���s�敪�iPCC�j	            
                pccCmpnyStWork.StckStComment1 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment1);
                //�`�[���s�敪�iPCC�j	            
                pccCmpnyStWork.StckStComment2 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment2);
                //�`�[���s�敪�iPCC�j	            
                pccCmpnyStWork.StckStComment3 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment3);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                //�q�ɕ\���敪(�⍇��)
                pccCmpnyStWork.WarehouseDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_WarehouseDspDiv);
                //����\���敪(�⍇��)
                pccCmpnyStWork.CancelDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CancelDspDiv);
                //�i�ԕ\���敪(����)
                pccCmpnyStWork.GoodsNoDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsNoDspDivOd);
                //�W�����i�\���敪(����)
                pccCmpnyStWork.ListPrcDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_ListPrcDspDivOd);
                //�d�؉��i�\���敪(����)
                pccCmpnyStWork.CostDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CostDspDivOd);
                //�I�ԕ\���敪(����)
                pccCmpnyStWork.ShelfDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_ShelfDspDivOd);
                //�݌ɕ\���敪(����)
                pccCmpnyStWork.StockDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_StockDspDivOd);
                //�R�����g�\���敪(����)
                pccCmpnyStWork.CommentDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CommentDspDivOd);
                //�o�א��\���敪(����)
                pccCmpnyStWork.SpmtCntDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_SpmtCntDspDivOd);
                //�󒍐��\���敪(����)
                pccCmpnyStWork.AcptCntDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_AcptCntDspDivOd);
                //���i�I��i�ԕ\���敪(����)
                pccCmpnyStWork.PrtSelGdNoDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelGdNoDspDivOd);
                //���i�I��W�����i�\���敪(����)
                pccCmpnyStWork.PrtSelLsPrDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelLsPrDspDivOd);
                //���i�I��I�ԕ\���敪(����)
                pccCmpnyStWork.PrtSelSelfDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelSelfDspDivOd);
                //���i�I���݌ɕ\���敪(����)
                pccCmpnyStWork.PrtSelStckDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelStckDspDivOd);
                //�q�ɕ\���敪(����)
                pccCmpnyStWork.WarehouseDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_WarehouseDspDivOd);
                //����\���敪(����)
                pccCmpnyStWork.CancelDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CancelDspDivOd);
                //�⍇�������\���敪�ݒ�
                pccCmpnyStWork.InqOdrDspDivSet = SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOdrDspDivSet);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                //PCC�D��q�ɃR�[�h4	            
                pccCmpnyStWork.PccPriWarehouseCd4 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd4);
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                //���݌ɐ��\���敪(����)
                pccCmpnyStWork.PrsntStkCtDspDivOd = SqlDataMediator.SqlGetShort(myReader, colIndex_PrsntStkCtDspDivOd);
                //���݌ɐ��\���敪(�⍇��)
                pccCmpnyStWork.PrsntStkCtDspDiv = SqlDataMediator.SqlGetShort(myReader, colIndex_PrsntStkCtDspDiv);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                pccCmpnyStWorkList.Add(pccCmpnyStWork);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                // �񓚔[���\���敪(�⍇��)
                pccCmpnyStWork.AnsDeliDtDspDiv = SqlDataMediator.SqlGetShort(myReader, colIndex_AnsDeliDtDspDiv);
                // �񓚔[���\���敪(����)
                pccCmpnyStWork.AnsDeliDtDspDivOd = SqlDataMediator.SqlGetShort(myReader, colIndex_AnsDeliDtDspDivOd);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// PCC���Аݒ�f�[�^�擾����
        /// </summary>
        /// <param name="myReader">PCC���Аݒ�f�[�^Reader</param>
        /// <param name="pccCmpnyStWork">PCC���Аݒ�f�[�^</param>
        /// <returns>PCC���Аݒ�f�[�^</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyListFromRead(SqlDataReader myReader, ref PccCmpnyStWork pccCmpnyStWork)
        {
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
            //PCC���ЃR�[�h
            int colIndex_PccCompanyCode = 0;
            //PCC�q�ɃR�[�h
            int colIndex_PccWarehouseCd = 0;
            //PCC�D��q�ɃR�[�h1
            int colIndex_PccPriWarehouseCd1 = 0;
            //PCC�D��q�ɃR�[�h2
            int colIndex_PccPriWarehouseCd2 = 0;
            //PCC�D��q�ɃR�[�h3
            int colIndex_PccPriWarehouseCd3 = 0;
            //�i�ԕ\���敪
            int colIndex_GoodsNoDspDiv = 0;
            //�W�����i�\���敪
            int colIndex_ListPrcDspDiv = 0;
            //�d�؉��i�\���敪
            int colIndex_CostDspDiv = 0;
            //�I�ԕ\���敪
            int colIndex_ShelfDspDiv = 0;
            //�R�����g�\���敪
            int colIndex_CommentDspDiv = 0;
            //�o�א��\���敪
            int colIndex_SpmtCntDspDiv = 0;
            //�󒍐��\���敪
            int colIndex_AcptCntDspDiv = 0;
            //���i�I��i�ԕ\���敪
            int colIndex_PrtSelGdNoDspDiv = 0;
            //���i�I��W�����i�\���敪
            int colIndex_PrtSelLsPrDspDiv = 0;
            //���i�I��I�ԕ\���敪
            int colIndex_PrtSelSelfDspDiv = 0;
            //PCC�����於��1
            int colIndex_PccSuplName1 = 0;
            //PCC�����於��2
            int colIndex_PccSuplName2 = 0;
            //PCC������J�i����
            int colIndex_PccSuplKana = 0;
            //PCC�����旪��
            int colIndex_PccSuplSnm = 0;
            //PCC������X�֔ԍ�
            int colIndex_PccSuplPostNo = 0;
            //PCC������Z��1
            int colIndex_PccSuplAddr1 = 0;
            //PCC������Z��2
            int colIndex_PccSuplAddr2 = 0;
            //PCC������Z��3
            int colIndex_PccSuplAddr3 = 0;
            //PCC������d�b�ԍ�1
            int colIndex_PccSuplTelNo1 = 0;
            //PCC������d�b�ԍ�2
            int colIndex_PccSuplTelNo2 = 0;
            //PCC������FAX�ԍ�
            int colIndex_PccSuplFaxNo = 0;
            //�`�[���s�敪�iPCC�j
            int colIndex_PccSlipPrtDiv = 0;
            //�`�[���s�敪�iPCC�j
            int colIndex_StckStComment1 = 0;
            //�`�[���s�敪�iPCC�j
            int colIndex_StckStComment2 = 0;
            //�`�[���s�敪�iPCC�j
            int colIndex_StckStComment3 = 0;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            //�q�ɕ\���敪(�⍇��)
            int colIndex_WarehouseDspDiv = 0;
            //����\���敪(�⍇��)
            int colIndex_CancelDspDiv = 0;
            //�i�ԕ\���敪(����)
            int colIndex_GoodsNoDspDivOd = 0;
            //�W�����i�\���敪(����)
            int colIndex_ListPrcDspDivOd = 0;
            //�d�؉��i�\���敪(����)
            int colIndex_CostDspDivOd = 0;
            //�I�ԕ\���敪(����)
            int colIndex_ShelfDspDivOd = 0;
            //�݌ɕ\���敪(����)
            int colIndex_StockDspDivOd = 0;
            //�R�����g�\���敪(����)
            int colIndex_CommentDspDivOd = 0;
            //�o�א��\���敪(����)
            int colIndex_SpmtCntDspDivOd = 0;
            //�󒍐��\���敪(����)
            int colIndex_AcptCntDspDivOd = 0;
            //���i�I��i�ԕ\���敪(����)
            int colIndex_PrtSelGdNoDspDivOd = 0;
            //���i�I��W�����i�\���敪(����)
            int colIndex_PrtSelLsPrDspDivOd = 0;
            //���i�I��I�ԕ\���敪(����)
            int colIndex_PrtSelSelfDspDivOd = 0;
            //���i�I���݌ɕ\���敪(����)
            int colIndex_PrtSelStckDspDivOd = 0;
            //�q�ɕ\���敪(����)
            int colIndex_WarehouseDspDivOd = 0;
            //����\���敪(����)
            int colIndex_CancelDspDivOd = 0;
            //�⍇�������\���敪�ݒ�
            int colIndex_InqOdrDspDivSet = 0;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PCC�D��q�ɃR�[�h4
            int colIndex_PccPriWarehouseCd4 = 0;
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            int colIndex_PrsntStkCtDspDivOd = 0;
            //���݌ɐ��\���敪(�⍇��)
            int colIndex_PrsntStkCtDspDiv = 0;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            int colIndex_AnsDeliDtDspDiv = 0;
            // �񓚔[���\���敪(����)
            int colIndex_AnsDeliDtDspDivOd = 0;
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            if (myReader.HasRows)
            {
                pccCmpnyStWork = new PccCmpnyStWork();
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
                //PCC���ЃR�[�h	
                colIndex_PccCompanyCode = myReader.GetOrdinal("PCCCOMPANYCODERF");
                //PCC�q�ɃR�[�h	
                colIndex_PccWarehouseCd = myReader.GetOrdinal("PCCWAREHOUSECDRF");
                //PCC�D��q�ɃR�[�h1	
                colIndex_PccPriWarehouseCd1 = myReader.GetOrdinal("PCCPRIWAREHOUSECD1RF");
                //PCC�D��q�ɃR�[�h2	
                colIndex_PccPriWarehouseCd2 = myReader.GetOrdinal("PCCPRIWAREHOUSECD2RF");
                //PCC�D��q�ɃR�[�h3	
                colIndex_PccPriWarehouseCd3 = myReader.GetOrdinal("PCCPRIWAREHOUSECD3RF");
                //�i�ԕ\���敪	
                colIndex_GoodsNoDspDiv = myReader.GetOrdinal("GOODSNODSPDIVRF");
                //�W�����i�\���敪	
                colIndex_ListPrcDspDiv = myReader.GetOrdinal("LISTPRCDSPDIVRF");
                //�d�؉��i�\���敪	
                colIndex_CostDspDiv = myReader.GetOrdinal("COSTDSPDIVRF");
                //�I�ԕ\���敪	
                colIndex_ShelfDspDiv = myReader.GetOrdinal("SHELFDSPDIVRF");
                //�R�����g�\���敪	
                colIndex_CommentDspDiv = myReader.GetOrdinal("COMMENTDSPDIVRF");
                //�o�א��\���敪	
                colIndex_SpmtCntDspDiv = myReader.GetOrdinal("SPMTCNTDSPDIVRF");
                //�󒍐��\���敪	
                colIndex_AcptCntDspDiv = myReader.GetOrdinal("ACPTCNTDSPDIVRF");
                //���i�I��i�ԕ\���敪	
                colIndex_PrtSelGdNoDspDiv = myReader.GetOrdinal("PRTSELGDNODSPDIVRF");
                //���i�I��W�����i�\���敪	
                colIndex_PrtSelLsPrDspDiv = myReader.GetOrdinal("PRTSELLSPRDSPDIVRF");
                //���i�I��I�ԕ\���敪	
                colIndex_PrtSelSelfDspDiv = myReader.GetOrdinal("PRTSELSELFDSPDIVRF");
                //PCC�����於��1	
                colIndex_PccSuplName1 = myReader.GetOrdinal("PCCSUPLNAME1RF");
                //PCC�����於��2	
                colIndex_PccSuplName2 = myReader.GetOrdinal("PCCSUPLNAME2RF");
                //PCC������J�i����	
                colIndex_PccSuplKana = myReader.GetOrdinal("PCCSUPLKANARF");
                //PCC�����旪��	
                colIndex_PccSuplSnm = myReader.GetOrdinal("PCCSUPLSNMRF");
                //PCC������X�֔ԍ�	
                colIndex_PccSuplPostNo = myReader.GetOrdinal("PCCSUPLPOSTNORF");
                //PCC������Z��1	
                colIndex_PccSuplAddr1 = myReader.GetOrdinal("PCCSUPLADDR1RF");
                //PCC������Z��2	
                colIndex_PccSuplAddr2 = myReader.GetOrdinal("PCCSUPLADDR2RF");
                //PCC������Z��3	
                colIndex_PccSuplAddr3 = myReader.GetOrdinal("PCCSUPLADDR3RF");
                //PCC������d�b�ԍ�1	
                colIndex_PccSuplTelNo1 = myReader.GetOrdinal("PCCSUPLTELNO1RF");
                //PCC������d�b�ԍ�2	
                colIndex_PccSuplTelNo2 = myReader.GetOrdinal("PCCSUPLTELNO2RF");
                //PCC������FAX�ԍ�	
                colIndex_PccSuplFaxNo = myReader.GetOrdinal("PCCSUPLFAXNORF");
                //�`�[���s�敪�iPCC�j	
                colIndex_PccSlipPrtDiv = myReader.GetOrdinal("PCCSLIPPRTDIVRF");
                //�`�[���s�敪�iPCC�j	
                colIndex_StckStComment1 = myReader.GetOrdinal("STCKSTCOMMENT1RF");
                //�`�[���s�敪�iPCC�j	
                colIndex_StckStComment2 = myReader.GetOrdinal("STCKSTCOMMENT2RF");
                //�`�[���s�敪�iPCC�j	
                colIndex_StckStComment3 = myReader.GetOrdinal("STCKSTCOMMENT3RF");
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                //�q�ɕ\���敪(�⍇��)
                colIndex_WarehouseDspDiv = myReader.GetOrdinal("WAREHOUSEDSPDIVRF");
                //����\���敪(�⍇��)
                colIndex_CancelDspDiv = myReader.GetOrdinal("CANCELDSPDIVRF");
                //�i�ԕ\���敪(����)
                colIndex_GoodsNoDspDivOd = myReader.GetOrdinal("GOODSNODSPDIVODRF");
                //�W�����i�\���敪(����)
                colIndex_ListPrcDspDivOd = myReader.GetOrdinal("LISTPRCDSPDIVODRF");
                //�d�؉��i�\���敪(����)
                colIndex_CostDspDivOd = myReader.GetOrdinal("COSTDSPDIVODRF");
                //�I�ԕ\���敪(����)
                colIndex_ShelfDspDivOd = myReader.GetOrdinal("SHELFDSPDIVODRF");
                //�݌ɕ\���敪(����)
                colIndex_StockDspDivOd = myReader.GetOrdinal("STOCKDSPDIVODRF");
                //�R�����g�\���敪(����)
                colIndex_CommentDspDivOd = myReader.GetOrdinal("COMMENTDSPDIVODRF");
                //�o�א��\���敪(����)
                colIndex_SpmtCntDspDivOd = myReader.GetOrdinal("SPMTCNTDSPDIVODRF");
                //�󒍐��\���敪(����)
                colIndex_AcptCntDspDivOd = myReader.GetOrdinal("ACPTCNTDSPDIVODRF");
                //���i�I��i�ԕ\���敪(����)
                colIndex_PrtSelGdNoDspDivOd = myReader.GetOrdinal("PRTSELGDNODSPDIVODRF");
                //���i�I��W�����i�\���敪(����)
                colIndex_PrtSelLsPrDspDivOd = myReader.GetOrdinal("PRTSELLSPRDSPDIVODRF");
                //���i�I��I�ԕ\���敪(����)
                colIndex_PrtSelSelfDspDivOd = myReader.GetOrdinal("PRTSELSELFDSPDIVODRF");
                //���i�I���݌ɕ\���敪(����)
                colIndex_PrtSelStckDspDivOd = myReader.GetOrdinal("PRTSELSTCKDSPDIVODRF");
                //�q�ɕ\���敪(����)
                colIndex_WarehouseDspDivOd = myReader.GetOrdinal("WAREHOUSEDSPDIVODRF");
                //����\���敪(����)
                colIndex_CancelDspDivOd = myReader.GetOrdinal("CANCELDSPDIVODRF");
                //�⍇�������\���敪�ݒ�
                colIndex_InqOdrDspDivSet = myReader.GetOrdinal("INQODRDSPDIVSETRF");
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                //PCC�D��q�ɃR�[�h4	
                colIndex_PccPriWarehouseCd4 = myReader.GetOrdinal("PCCPRIWAREHOUSECD4RF");
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                //���݌ɐ��\���敪(����)
                colIndex_PrsntStkCtDspDivOd = myReader.GetOrdinal("PRSNTSTKCTDSPDIVODRF");
                //���݌ɐ��\���敪(�⍇��)
                colIndex_PrsntStkCtDspDiv = myReader.GetOrdinal("PRSNTSTKCTDSPDIVRF");
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                // �񓚔[���\���敪(�⍇��)
                colIndex_AnsDeliDtDspDiv = myReader.GetOrdinal("ANSDELIDTDSPDIVRF");
                // �񓚔[���\���敪(����)
                colIndex_AnsDeliDtDspDivOd = myReader.GetOrdinal("ANSDELIDTDSPDIVODRF");
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

            }
            if(myReader.Read())
            {

                //�쐬����	 
                pccCmpnyStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //�X�V����	            
                pccCmpnyStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //�_���폜�敪	            
                pccCmpnyStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //�⍇������ƃR�[�h	            
                pccCmpnyStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                //�⍇�������_�R�[�h	            
                pccCmpnyStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                //�⍇�����ƃR�[�h	            
                pccCmpnyStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                //�⍇���拒�_�R�[�h	            
                pccCmpnyStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                //PCC���ЃR�[�h	            
                pccCmpnyStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                //PCC�q�ɃR�[�h	            
                pccCmpnyStWork.PccWarehouseCd = SqlDataMediator.SqlGetString(myReader, colIndex_PccWarehouseCd);
                //PCC�D��q�ɃR�[�h1	            
                pccCmpnyStWork.PccPriWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd1);
                //PCC�D��q�ɃR�[�h2	            
                pccCmpnyStWork.PccPriWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd2);
                //PCC�D��q�ɃR�[�h3	            
                pccCmpnyStWork.PccPriWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd3);
                //�i�ԕ\���敪	            
                pccCmpnyStWork.GoodsNoDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsNoDspDiv);
                //�W�����i�\���敪	            
                pccCmpnyStWork.ListPrcDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ListPrcDspDiv);
                //�d�؉��i�\���敪	            
                pccCmpnyStWork.CostDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CostDspDiv);
                //�I�ԕ\���敪	            
                pccCmpnyStWork.ShelfDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ShelfDspDiv);
                //�R�����g�\���敪	            
                pccCmpnyStWork.CommentDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CommentDspDiv);
                //�o�א��\���敪	            
                pccCmpnyStWork.SpmtCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SpmtCntDspDiv);
                //�󒍐��\���敪	            
                pccCmpnyStWork.AcptCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_AcptCntDspDiv);
                //���i�I��i�ԕ\���敪	            
                pccCmpnyStWork.PrtSelGdNoDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelGdNoDspDiv);
                //���i�I��W�����i�\���敪	            
                pccCmpnyStWork.PrtSelLsPrDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelLsPrDspDiv);
                //���i�I��I�ԕ\���敪	            
                pccCmpnyStWork.PrtSelSelfDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelSelfDspDiv);
                //PCC�����於��1	            
                pccCmpnyStWork.PccSuplName1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplName1);
                //PCC�����於��2	            
                pccCmpnyStWork.PccSuplName2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplName2);
                //PCC������J�i����	            
                pccCmpnyStWork.PccSuplKana = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplKana);
                //PCC�����旪��	            
                pccCmpnyStWork.PccSuplSnm = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplSnm);
                //PCC������X�֔ԍ�	            
                pccCmpnyStWork.PccSuplPostNo = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplPostNo);
                //PCC������Z��1	            
                pccCmpnyStWork.PccSuplAddr1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr1);
                //PCC������Z��2	            
                pccCmpnyStWork.PccSuplAddr2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr2);
                //PCC������Z��3	            
                pccCmpnyStWork.PccSuplAddr3 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplAddr3);
                //PCC������d�b�ԍ�1	            
                pccCmpnyStWork.PccSuplTelNo1 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplTelNo1);
                //PCC������d�b�ԍ�2	            
                pccCmpnyStWork.PccSuplTelNo2 = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplTelNo2);
                //PCC������FAX�ԍ�	            
                pccCmpnyStWork.PccSuplFaxNo = SqlDataMediator.SqlGetString(myReader, colIndex_PccSuplFaxNo);
                //�`�[���s�敪�iPCC�j	            
                pccCmpnyStWork.PccSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccSlipPrtDiv);
                //�݌ɏ󋵃R�����g1            
                pccCmpnyStWork.StckStComment1 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment1);
                //�݌ɏ󋵃R�����g2            
                pccCmpnyStWork.StckStComment2 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment2);
                //�݌ɏ󋵃R�����g3	            
                pccCmpnyStWork.StckStComment3 = SqlDataMediator.SqlGetString(myReader, colIndex_StckStComment3);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                //�q�ɕ\���敪(�⍇��)
                pccCmpnyStWork.WarehouseDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_WarehouseDspDiv);
                //����\���敪(�⍇��)
                pccCmpnyStWork.CancelDspDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CancelDspDiv);
                //�i�ԕ\���敪(����)
                pccCmpnyStWork.GoodsNoDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsNoDspDivOd);
                //�W�����i�\���敪(����)
                pccCmpnyStWork.ListPrcDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_ListPrcDspDivOd);
                //�d�؉��i�\���敪(����)
                pccCmpnyStWork.CostDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CostDspDivOd);
                //�I�ԕ\���敪(����)
                pccCmpnyStWork.ShelfDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_ShelfDspDivOd);
                //�݌ɕ\���敪(����)
                pccCmpnyStWork.StockDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_StockDspDivOd);
                //�R�����g�\���敪(����)
                pccCmpnyStWork.CommentDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CommentDspDivOd);
                //�o�א��\���敪(����)
                pccCmpnyStWork.SpmtCntDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_SpmtCntDspDivOd);
                //�󒍐��\���敪(����)
                pccCmpnyStWork.AcptCntDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_AcptCntDspDivOd);
                //���i�I��i�ԕ\���敪(����)
                pccCmpnyStWork.PrtSelGdNoDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelGdNoDspDivOd);
                //���i�I��W�����i�\���敪(����)
                pccCmpnyStWork.PrtSelLsPrDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelLsPrDspDivOd);
                //���i�I��I�ԕ\���敪(����)
                pccCmpnyStWork.PrtSelSelfDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelSelfDspDivOd);
                //���i�I���݌ɕ\���敪(����)
                pccCmpnyStWork.PrtSelStckDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_PrtSelStckDspDivOd);
                //�q�ɕ\���敪(����)
                pccCmpnyStWork.WarehouseDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_WarehouseDspDivOd);
                //����\���敪(����)
                pccCmpnyStWork.CancelDspDivOd = SqlDataMediator.SqlGetInt32(myReader, colIndex_CancelDspDivOd);
                //�⍇�������\���敪�ݒ�
                pccCmpnyStWork.InqOdrDspDivSet = SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOdrDspDivSet);
                // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                //PCC�D��q�ɃR�[�h4	            
                pccCmpnyStWork.PccPriWarehouseCd4 = SqlDataMediator.SqlGetString(myReader, colIndex_PccPriWarehouseCd4);
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                //���݌ɐ��\���敪(����)
                pccCmpnyStWork.PrsntStkCtDspDivOd = SqlDataMediator.SqlGetShort(myReader, colIndex_PrsntStkCtDspDivOd);
                //���݌ɐ��\���敪(�⍇��)
                pccCmpnyStWork.PrsntStkCtDspDiv = SqlDataMediator.SqlGetShort(myReader, colIndex_PrsntStkCtDspDiv);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪��SqlGetShort -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                // �񓚔[���\���敪(�⍇��)
                pccCmpnyStWork.AnsDeliDtDspDiv = SqlDataMediator.SqlGetShort(myReader, colIndex_AnsDeliDtDspDiv);
                // �񓚔[���\���敪(����)
                pccCmpnyStWork.AnsDeliDtDspDivOd = SqlDataMediator.SqlGetShort(myReader, colIndex_AnsDeliDtDspDivOd);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }


        #endregion

    }
}
