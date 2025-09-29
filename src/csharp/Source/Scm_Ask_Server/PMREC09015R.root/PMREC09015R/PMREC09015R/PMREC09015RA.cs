//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^�����e
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�����eDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �� �� ��  2015.01.16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �� �� ��  2015.03.03  �C�����e : �����[�g�̈ꕔ�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���{ �G�I
// �� �� ��  2015.03.24  �C�����e : �i��redmine#3251�̑Ή�
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
    /// ���R�����h���i�֘A�ݒ�}�X�^�����e�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�����e�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �� �B</br>
    /// <br>Date       : 2015.01.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RecGoodsLkDB : RemoteDB, IRecGoodsLkDB
    {

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public RecGoodsLkDB()
            : base("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork", "RECGOODSLKRF")
        {
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
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
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //�g�����U�N�V������������

        #region IRecGoodsLkDB �����o

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int Write(ref object RecGoodsLkWorkList)
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
                status = WriteProc(ref RecGoodsLkWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecStDB.Write");
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int WriteProc(ref object RecGoodsLkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;

            ArrayList RecGoodsLkWorkArrList = null;
            ArrayList RecGoodsLkWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (RecGoodsLkWorkList != null)
                {
                    RecGoodsLkWorkArrList = RecGoodsLkWorkList as ArrayList;

                }
                if (RecGoodsLkWorkArrList == null || RecGoodsLkWorkArrList.Count == 0)
                {
                    return status;
                }
                RecGoodsLkWorkArrListNew = new ArrayList();
                for (int i = 0; i < RecGoodsLkWorkArrList.Count; i++)
                {
                    RecGoodsLkWork RecGoodsLkWorkEach = RecGoodsLkWorkArrList[i] as RecGoodsLkWork;
                    status = this.WriteCmpnyStProcEach(ref RecGoodsLkWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    RecGoodsLkWorkArrListNew.Add(RecGoodsLkWorkEach);
                }

                RecGoodsLkWorkList = RecGoodsLkWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecGoodsLkDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Write");
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="RecGoodsLkWorkEach">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int WriteCmpnyStProcEach(ref RecGoodsLkWork RecGoodsLkWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Select�R�}���h�̐���
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  RECGOODSLKRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.NChar);
            SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.NChar);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
            findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
            findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.RecDestBLGoodsCd;
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != RecGoodsLkWorkEach.UpdateDateTime)
                {
                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                    if (RecGoodsLkWorkEach.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("     UPDATE RECGOODSLKRF SET CREATEDATETIMERF=@CREATEDATETIME ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       UPDATEDATETIMERF      =@UPDATEDATETIME ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       LOGICALDELETECODERF   =@LOGICALDELETECODE ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQORIGINALEPCDRF     =@INQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQORIGINALSECCDRF    =@INQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQOTHEREPCDRF        =@INQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQOTHERSECCDRF       =@INQOTHERSECCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       CUSTOMERCODERF        =@CUSTOMERCODE ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       RECSOURCEBLGOODSCDRF  =@RECSOURCEBLGOODSCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       RECDESTBLGOODSCDRF    =@RECDESTBLGOODSCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       GOODSCOMMENTRF        =@GOODSCOMMENT ").Append(Environment.NewLine);


                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHEREPCDRF=@FINDINQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
                sqlTxt.Append("     AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();
                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
                findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.RecDestBLGoodsCd;

                //�R�l�N�V����������擾�Ή�����������
                //�X�V�w�b�_����ݒ�
                RecGoodsLkWorkEach.UpdateDateTime = DateTime.Now;

            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                if (RecGoodsLkWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //�V�K�쐬����SQL���𐶐�
                sqlTxt.Append("     INSERT INTO RECGOODSLKRF ").Append(Environment.NewLine);
                sqlTxt.Append("      (CREATEDATETIMERF      ").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF      ").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF   ").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF     ").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF    ").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF        ").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , CUSTOMERCODERF        ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF  ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF    ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSNMRF    ").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF        ").Append(Environment.NewLine);
                sqlTxt.Append("    ) VALUES (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @UPDATEDATETIME       ").Append(Environment.NewLine);
                sqlTxt.Append("     , @LOGICALDELETECODE    ").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALEPCD      ").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALSECCD     ").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHEREPCD         ").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHERSECCD        ").Append(Environment.NewLine);
                sqlTxt.Append("     , @CUSTOMERCODE         ").Append(Environment.NewLine);
                sqlTxt.Append("     , @RECSOURCEBLGOODSCD   ").Append(Environment.NewLine);
                sqlTxt.Append("     , @RECDESTBLGOODSCD     ").Append(Environment.NewLine);
                sqlTxt.Append("     , @RECDESTBLGOODSNM     ").Append(Environment.NewLine);
                sqlTxt.Append("     , @GOODSCOMMENT         ").Append(Environment.NewLine);
                sqlTxt.Append("     )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�o�^�w�b�_����ݒ�
                RecGoodsLkWorkEach.UpdateDateTime = DateTime.Now;
                RecGoodsLkWorkEach.CreateDateTime = DateTime.Now;
                RecGoodsLkWorkEach.LogicalDeleteCode = 0;
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
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.NChar);
            SqlParameter paraRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCD", SqlDbType.NChar);
            SqlParameter paraRecDestBLGoodsCd = sqlCommand.Parameters.Add("@RECDESTBLGOODSCD", SqlDbType.NChar);
            SqlParameter paraRecDestBLGoodsNm = sqlCommand.Parameters.Add("@RECDESTBLGOODSNM", SqlDbType.NChar);
            SqlParameter paraGoodsComment = sqlCommand.Parameters.Add("@GOODSCOMMENT", SqlDbType.NChar);

            //Prameter�I�u�W�F�N�g�̍쐬
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.LogicalDeleteCode);
            paraInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
            paraInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.CustomerCode);
            paraRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.RecSourceBLGoodsCd);
            paraRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.RecDestBLGoodsCd);
            paraRecDestBLGoodsNm.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.RecDestBLGoodsNm);
            paraGoodsComment.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.GoodsComment);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }


        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="parseRecGoodsLkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int Search(out object RecGoodsLkWorkList, RecGoodsLkWork parseRecGoodsLkWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            RecGoodsLkWorkList = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(out RecGoodsLkWorkList, parseRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Search");
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="parseRecGoodsLkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int SearchProc(out object RecGoodsLkWorkList, RecGoodsLkWork parseRecGoodsLkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkWorkList = null;
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
                sqlTxt.Append("     , CUSTOMERCODERF        ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF     ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSNMRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF           ").Append(Environment.NewLine);
                sqlTxt.Append("      FROM RECGOODSLKRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                //if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalEpCd))
                //{
                sqlTxt.Append("    INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOriginalEpCd);
                //}
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalEpCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOriginalSecCd);
                }
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherEpCd))
                {
                    if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalEpCd) || !string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalSecCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalEpCd) || !string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalSecCd) || !string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherEpCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOtherSecCd);
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
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkDB.SearchProc", status);
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


            RecGoodsLkWorkList = al;

            return status;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="parseRecGoodsLkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int SearchForBuyer(out object RecGoodsLkWorkList, RecGoodsLkWork parseRecGoodsLkWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            RecGoodsLkWorkList = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchForBuyerProc(out RecGoodsLkWorkList, parseRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Search");
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e���������B<br/>
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="parseRecGoodsLkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// �w����(CarpodTab)���ŗ��p����C���^�[�t�F�[�X�ƂȂ�܂��B<br/>
        /// �w���҂̃L�[���ƂȂ�A������ƃR�[�h���K�{�����ƂȂ�܂��B<br/>
        /// �܂���Ƌ��_�A���}�X�^�ŗL���ƂȂ�ڑ���ɂ�������݂̂��Ԃ���܂��B
        /// <br>Programmer : ���{ �G�I</br>
        /// <br>Date       : 2015.02.22</br>
        /// </remarks>
        public int SearchForBuyerProc(out object RecGoodsLkWorkList, RecGoodsLkWork parseRecGoodsLkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkWorkList = null;
            try
            {
                #region NOTE:���R�����h���i�֘A�}�X�^�擾�����ƓW�J�����ɂ���
                //write by ���{ �G�I
                //�S���Ӑ�A�S���_�ݒ�ɂ�����e�ڑ�����ƃR�[�h�A���_�R�[�h�ɓW�J���鏈�������킹��1��SQL�Ŏ��s���Ă��܂��B
                //AP-DB�ʐM�ʂ̔�剻��}���邽�߂ɁA�W�J������ʂɂ��邱�Ƃ��\�ł����A����͗\�������Ȃ��̂ł��̂܂܂Ƃ��Ă��܂��B
                //���דI�Ȗ��ɂ��A�W�J�����ƃ��R�����h���i�֘A�ݒ�}�X�^�擾�����𕪂���ꍇ�́A���L�̂悤��SQL�ƂȂ�܂��B
                //SELECT
                //* --�����Ɛݒ肵�Ăˁ�
                //FROM RECGOODSLKRF        AS RECGOOD WITH(READUNCOMMITTED)
                //WHERE RECGOOD.LOGICALDELETECODERF = 0
                //  AND EXISTS (
                //     SELECT 1 
                //       FROM SCMEPCNECTRF        AS SUB01 WITH(READUNCOMMITTED)
                //       INNER JOIN SCMEPSCCNTRF  AS SUB02 WITH(READUNCOMMITTED)
                //         ON    SUB02.LOGICALDELETECODERF  = 0
                //           AND SUB02.DISCDIVCDRF          = 0
                //           AND SUB02.CNECTOTHEREPCDRF     = SUB01.CNECTOTHEREPCDRF 
                //           AND (SUB02.PCCUOECOMMMETHODRF  = 1 OR SUB02.SCMCOMMMETHODRF = 1)
                //           AND SUB02.CNECTORIGINALEPCDRF  = SUB01.CNECTORIGINALEPCDRF  
                //           AND (RECGOOD.INQORIGINALSECCDRF = '000000' OR SUB02.CNECTORIGINALSECCDRF = RECGOOD.INQORIGINALSECCDRF )
                //           AND (RECGOOD.INQOTHERSECCDRF = '00' OR SUB02.CNECTOTHERSECCDRF    = RECGOOD.INQOTHERSECCDRF)
                //      WHERE SUB01.LOGICALDELETECODERF = 0
                //        AND SUB01.DISCDIVCDRF         = 0
                //        AND SUB01.CNECTORIGINALEPCDRF = @FINDCNECTORIGINALEPCD
                //        AND SUB01.CNECTOTHEREPCDRF    = RECGOOD.INQOTHEREPCDRF
                //  )
                //;
                #endregion

                #region ���R�����h���i�֘A�ݒ�}�X�^
                #endregion
                StringBuilder sqlTxt = new StringBuilder(4096);
                sqlCommand = new SqlCommand(string.Empty, sqlConnection);
                sqlTxt.AppendLine(" SELECT * FROM (");
                sqlTxt.AppendLine("   SELECT ");
                sqlTxt.AppendLine("   RECGOOD.CREATEDATETIMERF     AS CREATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECGOOD.UPDATEDATETIMERF     AS UPDATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECGOOD.LOGICALDELETECODERF  AS LOGICALDELETECODERF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTORIGINALEPCDRF  AS INQORIGINALEPCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTORIGINALSECCDRF AS INQORIGINALSECCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTOTHEREPCDRF     AS INQOTHEREPCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTOTHERSECCDRF    AS INQOTHERSECCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.CUSTOMERCODERF       AS CUSTOMERCODERF, ");
                sqlTxt.AppendLine("   RECGOOD.RECSOURCEBLGOODSCDRF AS RECSOURCEBLGOODSCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.RECDESTBLGOODSCDRF   AS RECDESTBLGOODSCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.RECDESTBLGOODSNMRF   AS RECDESTBLGOODSNMRF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSCOMMENTRF       AS GOODSCOMMENTRF, ");
                sqlTxt.AppendLine("   ROW_NUMBER() OVER ( ");
                sqlTxt.AppendLine("     PARTITION BY EPSCCNT.CNECTORIGINALEPCDRF   ,EPSCCNT.CNECTORIGINALSECCDRF   ,EPSCCNT.CNECTOTHEREPCDRF   ,EPSCCNT.CNECTOTHERSECCDRF    ,RECGOOD.RECSOURCEBLGOODSCDRF,RECGOOD.RECDESTBLGOODSCDRF ");
                sqlTxt.AppendLine("     ORDER BY     RECGOOD.INQORIGINALEPCDRF DESC,RECGOOD.INQORIGINALSECCDRF DESC,RECGOOD.INQOTHEREPCDRF DESC,RECGOOD.INQOTHERSECCDRF DESC ,RECGOOD.RECSOURCEBLGOODSCDRF,RECGOOD.RECDESTBLGOODSCDRF DESC ");
                sqlTxt.AppendLine("   ) AS ROWNUM ");
                sqlTxt.AppendLine("   FROM RECGOODSLKRF        AS RECGOOD WITH(READUNCOMMITTED) ");
                sqlTxt.AppendLine("   INNER JOIN  SCMEPCNECTRF AS EPCNECT WITH(READUNCOMMITTED) ");
                sqlTxt.AppendLine("   ON    EPCNECT.LOGICALDELETECODERF = 0 ");
                sqlTxt.AppendLine("     AND EPCNECT.DISCDIVCDRF         = 0 ");
                sqlTxt.AppendLine("     AND EPCNECT.CNECTORIGINALEPCDRF = @FINDCNECTORIGINALEPCD ");
                sqlTxt.AppendLine("     AND EPCNECT.CNECTOTHEREPCDRF    = RECGOOD.INQOTHEREPCDRF ");
                sqlTxt.AppendLine("   INNER JOIN SCMEPSCCNTRF  AS EPSCCNT WITH(READUNCOMMITTED)  ");
                sqlTxt.AppendLine("   ON    EPSCCNT.LOGICALDELETECODERF  = 0 ");
                sqlTxt.AppendLine("     AND EPSCCNT.DISCDIVCDRF          = 0 ");
                #region ADD:2015.03.24 ���{ �G�I #3251 ------------------- >>>>>
                sqlTxt.AppendLine("      AND EPSCCNT.PMUPLOADDIVRF       = 1  ");
                sqlTxt.AppendLine("      AND ISNULL(EPSCCNT.PMDBIDRF,'') != ''");
                #endregion
                sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHEREPCDRF     = EPCNECT.CNECTOTHEREPCDRF  ");
                sqlTxt.AppendLine("     AND (EPSCCNT.PCCUOECOMMMETHODRF  = 1 OR EPSCCNT.SCMCOMMMETHODRF = 1) ");
                sqlTxt.AppendLine("     AND ( ");
                sqlTxt.AppendLine("           RECGOOD.INQORIGINALEPCDRF='0000000000000000' OR ");
                sqlTxt.AppendLine("          (EPSCCNT.CNECTORIGINALEPCDRF  = EPCNECT.CNECTORIGINALEPCDRF  AND EPSCCNT.CNECTORIGINALSECCDRF = RECGOOD.INQORIGINALSECCDRF ) ");
                sqlTxt.AppendLine("         ) ");
                sqlTxt.AppendLine("     AND (RECGOOD.INQOTHERSECCDRF='00' OR EPSCCNT.CNECTOTHERSECCDRF    = RECGOOD.INQOTHERSECCDRF) ");
                sqlTxt.AppendLine("     AND EPSCCNT.CNECTORIGINALEPCDRF = @FINDCNECTORIGINALEPCD  ");
                #region ���������ݒ聕Prameter�I�u�W�F�N�g�̍쐬(�ڑ����A��̊�Ƌ��_�A���}�X�^�i�荞��
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDCNECTORIGINALEPCD", SqlDbType.NChar);//���K�{����
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOriginalEpCd);

                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalSecCd))//�ڑ������_�R�[�h
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTORIGINALSECCDRF = @FINDCNECTORIGINALSECCD ");
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDCNECTORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOriginalSecCd);
                }
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherEpCd)) //�ڑ����ƃR�[�h
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHEREPCDRF = @FINDCNECTOTHEREPCD ");
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDCNECTOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherSecCd)) //�ڑ��拒�_�R�[�h
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHERSECCDRF = @FINDCNECTOTHERSECCD");
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDCNECTOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOtherSecCd);
                }
                #endregion
                sqlTxt.AppendLine("   WHERE RECGOOD.INQOTHEREPCDRF     =  EPSCCNT.CNECTOTHEREPCDRF ");
                sqlTxt.AppendLine("     AND RECGOOD.INQOTHERSECCDRF    IN ('00',EPSCCNT.CNECTOTHERSECCDRF) ");
                sqlTxt.AppendLine("     AND RECGOOD.INQORIGINALEPCDRF  IN ('0000000000000000',EPSCCNT.CNECTORIGINALEPCDRF) ");
                sqlTxt.AppendLine("     AND RECGOOD.INQORIGINALSECCDRF IN ('000000',EPSCCNT.CNECTORIGINALSECCDRF) ");
                #region ���������ݒ聕Prameter�I�u�W�F�N�g�̍쐬(���R�����h���i�֘A�ݒ�}�X�^�ł̍i�荞��
                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlTxt.AppendLine("   AND RECGOOD.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlTxt.AppendLine("   AND RECGOOD.LOGICALDELETECODERF< @FINDLOGICALDELETECODE ");
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                #endregion
                sqlTxt.AppendLine(" ) AS SUB01  ");
                sqlTxt.AppendLine(" WHERE SUB01.ROWNUM=1  ");
                sqlTxt.AppendLine(" ORDER BY   ");
                sqlTxt.AppendLine("     SUB01.INQORIGINALEPCDRF, ");
                sqlTxt.AppendLine("     SUB01.INQORIGINALSECCDRF, ");
                sqlTxt.AppendLine("     SUB01.INQOTHEREPCDRF, ");
                sqlTxt.AppendLine("     SUB01.INQOTHERSECCDRF, ");
                sqlTxt.AppendLine("     SUB01.RECSOURCEBLGOODSCDRF, ");
                sqlTxt.AppendLine("     SUB01.RECDESTBLGOODSCDRF ");
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
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkDB.SearchProc", status);
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

            RecGoodsLkWorkList = al;
            return status;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int Read(ref object RecGoodsLkWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref RecGoodsLkWorkList, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Read");
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int ReadProc(ref object RecGoodsLkWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            RecGoodsLkWork wkRecGoodsLkWorkOld = null;
            RecGoodsLkWork wkRecGoodsLkWorkNew = null;
            ArrayList alOld = new ArrayList();
            if (RecGoodsLkWorkList != null)
            {
                wkRecGoodsLkWorkOld = RecGoodsLkWorkList as RecGoodsLkWork;
            }
            else
            {
                return status;
            }
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkWorkList = null;
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
                sqlTxt.Append("     , CUSTOMERCODERF        ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF     ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSNMRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF           ").Append(Environment.NewLine);
                sqlTxt.Append("      FROM RECGOODSLKRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHEREPCDRF=@FINDINQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
                sqlTxt.Append("     AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD").Append(Environment.NewLine);

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
                SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = wkRecGoodsLkWorkOld.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = wkRecGoodsLkWorkOld.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(wkRecGoodsLkWorkOld.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(wkRecGoodsLkWorkOld.InqOtherSecCd);
                findParaRecSourceBLGoodsCd.Value = wkRecGoodsLkWorkOld.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = wkRecGoodsLkWorkOld.RecDestBLGoodsCd;
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromRead(myReader, ref wkRecGoodsLkWorkNew);
                if (wkRecGoodsLkWorkNew == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkDB.ReadProc", status);
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


            RecGoodsLkWorkList = wkRecGoodsLkWorkNew;

            return status;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int LogicalDelete(ref object RecGoodsLkWorkList)
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
                status = LogicalDeleteProc(ref RecGoodsLkWorkList, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.LogicalDelete");
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int LogicalDeleteProc(ref object RecGoodsLkWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList RecGoodsLkWorkArrList = null;
            ArrayList RecGoodsLkWorkArrListNew = null;
            try
            {
                if (RecGoodsLkWorkList != null)
                {
                    RecGoodsLkWorkArrList = RecGoodsLkWorkList as ArrayList;

                }
                if (RecGoodsLkWorkArrList == null || RecGoodsLkWorkArrList.Count == 0)
                {
                    return status;
                }
                RecGoodsLkWorkArrListNew = new ArrayList();
                for (int i = 0; i < RecGoodsLkWorkArrList.Count; i++)
                {
                    RecGoodsLkWork RecGoodsLkWorkEach = RecGoodsLkWorkArrList[i] as RecGoodsLkWork;
                    status = LogicalDeleteProcCmpnyEach(ref RecGoodsLkWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    RecGoodsLkWorkArrListNew.Add(RecGoodsLkWorkEach);


                }
                RecGoodsLkWorkList = RecGoodsLkWorkArrListNew as object;

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecGoodsLkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.LogicalDeleteProc Exception=" + ex.Message);
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="RecGoodsLkWorkEach">���R�����h���i�֘A���Аݒ�</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int LogicalDeleteProcCmpnyEach(ref RecGoodsLkWork RecGoodsLkWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  RECGOODSLKRF ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
            SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);


            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
            findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
            findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.InqOtherSecCd;
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != RecGoodsLkWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //���݂̘_���폜�敪���擾
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE RECGOODSLKRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
                findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.InqOtherSecCd;

                //�X�V�w�b�_����ݒ�
                //�X�V�w�b�_����ݒ�
                RecGoodsLkWorkEach.UpdateDateTime = DateTime.Now;

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

                if (logicalDelCd == 0) RecGoodsLkWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g

            }
            else
            {
                if (logicalDelCd == 1) RecGoodsLkWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������

            }

            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWorkEach.UpdateDateTime);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int Delete(ref object RecGoodsLkWorkList)
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

                status = DeleteProc(ref RecGoodsLkWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Delete");
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int DeleteProc(ref object RecGoodsLkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList RecGoodsLkWorkArrList = null;
            ArrayList RecGoodsLkWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (RecGoodsLkWorkList != null)
                {
                    RecGoodsLkWorkArrList = RecGoodsLkWorkList as ArrayList;

                }
                if (RecGoodsLkWorkArrList == null || RecGoodsLkWorkArrList.Count == 0)
                {
                    return status;
                }
                RecGoodsLkWorkArrListNew = new ArrayList();

                for (int i = 0; i < RecGoodsLkWorkArrList.Count; i++)
                {
                    RecGoodsLkWork RecGoodsLkWorkEach = RecGoodsLkWorkArrList[i] as RecGoodsLkWork;
                    status = DeleteProcCmpnyStEach(ref RecGoodsLkWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    RecGoodsLkWorkArrListNew.Add(RecGoodsLkWorkEach);

                }

                RecGoodsLkWorkList = RecGoodsLkWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecGoodsLkDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Delete Exception=" + ex.Message);
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="RecGoodsLkWorkEach">���R�����h���i�֘A�ݒ�O���[�v</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        private int DeleteProcCmpnyStEach(ref RecGoodsLkWork RecGoodsLkWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  RECGOODSLKRF ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);


            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
            SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
            findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
            findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.InqOtherSecCd;
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != RecGoodsLkWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM RECGOODSLKRF ").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
                findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.InqOtherSecCd;
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object RecGoodsLkWorkList)
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
                status = RevivalLogicalDeleteProc(ref RecGoodsLkWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.RevivalLogicalDelete");
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object RecGoodsLkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteProc(ref  RecGoodsLkWorkList, 1, ref sqlConnection, ref  sqlTransaction);
        }

        #endregion

        #region ��������
        /// <summary>
        /// ���R�����h���i�֘A�f�[�^�擾����
        /// </summary>
        /// <param name="myReader">���R�����h���i�֘A�ݒ�f�[�^Reader</param>
        /// <param name="RecGoodsLkWorkList">���R�����h���i�֘A�ݒ�f�[�^���X�g</param>
        /// <returns>���R�����h���i�֘A�ݒ�f�[�^</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        private int CopyListFromSearch(SqlDataReader myReader, out ArrayList RecGoodsLkWorkList)
        {
            RecGoodsLkWorkList = new ArrayList();
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
            //���Ӑ�R�[�h
            int colIndex_CustomerCode = 0;
            //������BL���i�R�[�h
            int colIndex_RecSourceBLGoodsCd = 0;
            //������BL���i�R�[�h
            int colIndex_RecDestBLGoodsCd = 0;
            //������BL���i�R�[�h����
            int colIndex_RecDestBLGoodsNm = 0;
            //���i�R�����g
            int colIndex_GoodsComment = 0;
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
                //���Ӑ�R�[�h
                colIndex_CustomerCode = myReader.GetOrdinal("CUSTOMERCODERF");
                //������BL���i�R�[�h
                colIndex_RecSourceBLGoodsCd = myReader.GetOrdinal("RECSOURCEBLGOODSCDRF");
                //������BL���i�R�[�h
                colIndex_RecDestBLGoodsCd = myReader.GetOrdinal("RECDESTBLGOODSCDRF");
                //������BL���i�R�[�h����
                colIndex_RecDestBLGoodsNm = myReader.GetOrdinal("RECDESTBLGOODSNMRF");
                //���i�R�����g
                colIndex_GoodsComment = myReader.GetOrdinal("GOODSCOMMENTRF");
            }
            while (myReader.Read())
            {

                RecGoodsLkWork RecGoodsLkWork = new RecGoodsLkWork();
                //�쐬����	 
                RecGoodsLkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //�X�V����	            
                RecGoodsLkWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //�_���폜�敪	            
                RecGoodsLkWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //�⍇������ƃR�[�h	            
                RecGoodsLkWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                //�⍇�������_�R�[�h	            
                RecGoodsLkWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                //�⍇�����ƃR�[�h	            
                RecGoodsLkWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                //�⍇���拒�_�R�[�h	            
                RecGoodsLkWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                //���Ӑ�R�[�h
                RecGoodsLkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CustomerCode);
                //������BL���i�R�[�h
                RecGoodsLkWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecSourceBLGoodsCd);
                //������BL���i�R�[�h
                RecGoodsLkWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecDestBLGoodsCd);
                //������BL���i�R�[�h����
                RecGoodsLkWork.RecDestBLGoodsNm = SqlDataMediator.SqlGetString(myReader, colIndex_RecDestBLGoodsNm);
                //���i�R�����g
                RecGoodsLkWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsComment);

                RecGoodsLkWorkList.Add(RecGoodsLkWork);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�f�[�^�擾����
        /// </summary>
        /// <param name="myReader">���R�����h���i�֘A�ݒ�f�[�^Reader</param>
        /// <param name="RecGoodsLkWork">���R�����h���i�֘A�ݒ�f�[�^</param>
        /// <returns>���R�����h���i�֘A�ݒ�f�[�^</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        private int CopyListFromRead(SqlDataReader myReader, ref RecGoodsLkWork RecGoodsLkWork)
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
            //���Ӑ�R�[�h
            int colIndex_CustomerCode = 0;
            //������BL���i�R�[�h
            int colIndex_RecSourceBLGoodsCd = 0;
            //������BL���i�R�[�h
            int colIndex_RecDestBLGoodsCd = 0;
            //������BL���i�R�[�h����
            int colIndex_RecDestBLGoodsNm = 0;
            //���i�R�����g
            int colIndex_GoodsComment = 0;
            if (myReader.HasRows)
            {
                RecGoodsLkWork = new RecGoodsLkWork();
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
                //���Ӑ�R�[�h
                colIndex_CustomerCode = myReader.GetOrdinal("CUSTOMERCODERF");
                //������BL���i�R�[�h
                colIndex_RecSourceBLGoodsCd = myReader.GetOrdinal("RECSOURCEBLGOODSCDRF");
                //������BL���i�R�[�h
                colIndex_RecDestBLGoodsCd = myReader.GetOrdinal("RECDESTBLGOODSCDRF");
                //������BL���i�R�[�h����
                colIndex_RecDestBLGoodsNm = myReader.GetOrdinal("RECDESTBLGOODSNMRF");
                //���i�R�����g
                colIndex_GoodsComment = myReader.GetOrdinal("GOODSCOMMENTRF");

            }
            if (myReader.Read())
            {

                //�쐬����	 
                RecGoodsLkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //�X�V����	            
                RecGoodsLkWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //�_���폜�敪	            
                RecGoodsLkWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //�⍇������ƃR�[�h	            
                RecGoodsLkWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                //�⍇�������_�R�[�h	            
                RecGoodsLkWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                //�⍇�����ƃR�[�h	            
                RecGoodsLkWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                //�⍇���拒�_�R�[�h	            
                RecGoodsLkWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                //���Ӑ�R�[�h
                RecGoodsLkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CustomerCode);
                //������BL���i�R�[�h
                RecGoodsLkWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecSourceBLGoodsCd);
                //������BL���i�R�[�h
                RecGoodsLkWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecDestBLGoodsCd);
                //������BL���i�R�[�h����
                RecGoodsLkWork.RecDestBLGoodsNm = SqlDataMediator.SqlGetString(myReader, colIndex_RecDestBLGoodsNm);
                //���i�R�����g
                RecGoodsLkWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsComment);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }


        #endregion

        // --- ADD 2015/01/22 T.Miyamoto ------------------------------------------------------------------------------------------------------------------->>>>>
        #region �ySearchRcmd�����z
        /// <summary>
        /// �w�肳�ꂽ�����̃��R�����h���i�֘A�ݒ�}�X�^���LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">count</param>
        /// <param name="errMsg">�G���[msg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̃��R�����h���i�֘A�ݒ�}�X�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        /// </remarks>
        public int SearchRcmd(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            try
            {
                return SearchProcRcmd(out retobj, paraobj, readMode, logicalMode, out count, ref errMsg);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Search");
                retobj = new ArrayList();
                count = 0;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }
        #endregion

        #region �ySearchProcRcmd�z
        /// <summary>
        /// �w�肳�ꂽ�����̃��R�����h���i�֘A�ݒ�}�X�^���LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">count</param>
        /// <param name="errMsg">�G���[msg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̃��R�����h���i�֘A�ݒ�}�X�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        /// </remarks>
        private int SearchProcRcmd(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            RecGoodsLkWork RecGoodsLkWork = null;

            retobj = null;
            count = 0;
            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                RecGoodsLkWork = paraobj as RecGoodsLkWork;

                //SQL������
                sqlConnection.Open();

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += " CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += ", UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += ", LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += ", INQORIGINALEPCDRF" + Environment.NewLine;
                selectTxt += ", INQORIGINALSECCDRF" + Environment.NewLine;
                selectTxt += ", INQOTHEREPCDRF" + Environment.NewLine;
                selectTxt += ", INQOTHERSECCDRF" + Environment.NewLine;
                selectTxt += ", CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += ", RECSOURCEBLGOODSCDRF" + Environment.NewLine;
                selectTxt += ", RECDESTBLGOODSCDRF" + Environment.NewLine;
                selectTxt += ", RECDESTBLGOODSNMRF" + Environment.NewLine;
                selectTxt += ", GOODSCOMMENTRF" + Environment.NewLine;
                selectTxt += " FROM RECGOODSLKRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt += this.MakeWhereString(ref sqlCommand, RecGoodsLkWork, logicalMode);

                selectTxt += " ORDER BY" + Environment.NewLine;
                selectTxt += " INQOTHERSECCDRF" + Environment.NewLine;
                selectTxt += ", CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += ", RECSOURCEBLGOODSCDRF" + Environment.NewLine;
                selectTxt += ", RECDESTBLGOODSCDRF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (al.Count == 20000)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        retobj = al;
                        count = 20001;
                        return status;
                    }
                    RecGoodsLkWork = this.CopyToRecGoodsLkWorkFromReader(ref myReader);

                    al.Add(RecGoodsLkWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errMsg = ex.ToString();
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retobj = al;
            return status;
        }
        #endregion

        # region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�}�X�^�N���X�i�[���� Reader �� RecGoodsLkWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecGoodsLkWork</returns>
        /// <remarks>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/22</br>
        /// </remarks>
        private RecGoodsLkWork CopyToRecGoodsLkWorkFromReader(ref SqlDataReader myReader)
        {
            RecGoodsLkWork RecGoodsLkWork = new RecGoodsLkWork();

            #region �N���X�֊i�[
            RecGoodsLkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            RecGoodsLkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            RecGoodsLkWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            RecGoodsLkWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            RecGoodsLkWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
            RecGoodsLkWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
            RecGoodsLkWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
            RecGoodsLkWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
            RecGoodsLkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            RecGoodsLkWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECSOURCEBLGOODSCDRF"));
            RecGoodsLkWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECDESTBLGOODSCDRF"));
            RecGoodsLkWork.RecDestBLGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECDESTBLGOODSNMRF"));
            RecGoodsLkWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCOMMENTRF"));
            #endregion

            return RecGoodsLkWork;
        }
        #endregion

        #region �yWHERE���쐬�z
        private string MakeWhereString(ref SqlCommand sqlCommand, RecGoodsLkWork RecGoodsLkWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = string.Empty;
            retstring = " WHERE" + Environment.NewLine;

            //�_���폜�敪
            retstring += " LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            //�⍇������ƃR�[�h
            if (RecGoodsLkWork.InqOriginalEpCd.Trim() != string.Empty)
            {
                retstring += " AND INQORIGINALEPCDRF=@INQORIGINALEPCD" + Environment.NewLine;
                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
            }

            //�⍇�������_�R�[�h
            if (RecGoodsLkWork.InqOriginalSecCd.Trim() != string.Empty)
            {
                retstring += " AND INQORIGINALSECCDRF=@INQORIGINALSECCD" + Environment.NewLine;
                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
            }

            //�⍇�����ƃR�[�h
            if (RecGoodsLkWork.InqOtherEpCd.Trim() != string.Empty)
            {
                retstring += " AND INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine;
                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
            }

            //�⍇���拒�_�R�[�h
            if (RecGoodsLkWork.InqOtherSecCd.Trim() != string.Empty)
            {
                // --- UPD 2015/03/03 T.Nishi -----<<<<<
                //retstring += " AND (INQOTHERSECCDRF=@INQOTHERSECCD OR INQOTHERSECCDRF=@INQOTHERSECCDALL)" + Environment.NewLine;
                retstring += " AND (INQOTHERSECCDRF=@INQOTHERSECCD)" + Environment.NewLine;
                // --- UPD 2015/03/03 T.Nishi -----<<<<<
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                // --- DEL 2015/03/03 T.Nishi -----<<<<<
                //SqlParameter paraInqOtherSecCdAll = sqlCommand.Parameters.Add("@INQOTHERSECCDALL", SqlDbType.NChar);
                //paraInqOtherSecCdAll.Value = SqlDataMediator.SqlSetString("00");
                // --- DEL 2015/03/03 T.Nishi -----<<<<<
            }

            //���Ӑ�R�[�h
            if (RecGoodsLkWork.CustomerCode != 0)
            {
                retstring += " AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.CustomerCode);
            }

            //������BL���i�R�[�h�i�J�n�j
            if (RecGoodsLkWork.RecSourceBLGoodsCdSt != 0)
            {
                retstring += " AND RECSOURCEBLGOODSCDRF>=@RECSOURCEBLGOODSCDST" + Environment.NewLine;
                SqlParameter paraRecSourceBLGoodsCdSt = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCDST", SqlDbType.Int);
                paraRecSourceBLGoodsCdSt.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.RecSourceBLGoodsCdSt);
            }
            //������BL���i�R�[�h�i�I���j
            if (RecGoodsLkWork.RecSourceBLGoodsCdEd != 0)
            {
                retstring += " AND RECSOURCEBLGOODSCDRF<=@RECSOURCEBLGOODSCDED" + Environment.NewLine;
                SqlParameter paraRecSourceBLGoodsCdEd = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCDED", SqlDbType.Int);
                paraRecSourceBLGoodsCdEd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.RecSourceBLGoodsCdEd);
            }
            #endregion
            return retstring;
        }
        #endregion

        #region �y�폜�E�X�V�����z
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��_���폜�Ɠo�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraDelObj">�폜�pRecGoodsLkWork�I�u�W�F�N�g</param>
        /// <param name="paraUpdObj">�X�V�pRecGoodsLkWork�I�u�W�F�N�g</param>
        /// <param name="errorObj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^��_���폜�Ɠo�^�A�X�V���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        public int DeleteAndWrite(object paraDelObj, ref object paraUpdObj, out object errorObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            errorObj = null;
            ArrayList delList = null;
            ArrayList updList = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction();

                delList = paraDelObj as ArrayList;
                updList = paraUpdObj as ArrayList;

                foreach (RecGoodsLkWork RecGoodsLkWork in delList)
                {
                    object paraObj = RecGoodsLkWork as object;
                    status = this.DeleteProcRcmd(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }
                }


                foreach (RecGoodsLkWork RecGoodsLkWork in updList)
                {
                    object paraObj = RecGoodsLkWork as object;
                    if (RecGoodsLkWork.LogicalDeleteCode == 0)
                    {
                        status = this.ReadDBBeforeSave(ref paraObj, ref sqlConnection, ref sqlTransaction);
                        if (status != 0)
                        {
                            errorObj = paraObj;
                            return status;
                        }

                        status = this.WriteProcRcmd(ref paraObj, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        status = this.LogicalDeleteProcRcmd(ref paraObj, 0, ref sqlConnection, ref sqlTransaction);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.DeleteAndWrite");
                errorObj = null;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
                            //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                            //synchExecuteMng.SyncReqExecute();
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
        #endregion

        #region �y���S�폜�E���������z
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�����S�폜�A�������܂�
        /// </summary>
        /// <param name="paraDelObj">�폜�pRecGoodsLkWork�I�u�W�F�N�g</param>
        /// <param name="paraUpdObj">�X�V�pRecGoodsLkWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�����S�폜�A�������܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        public int DeleteAndRevival(object paraDelObj, ref object paraUpdObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList delList = null;
            ArrayList updList = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction();

                delList = paraDelObj as ArrayList;
                updList = paraUpdObj as ArrayList;

                foreach (RecGoodsLkWork RecGoodsLkWork in delList)
                {
                    object paraObj = RecGoodsLkWork as object;
                    status = this.DeleteProcRcmd(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }

                foreach (RecGoodsLkWork RecGoodsLkWork in updList)
                {
                    object paraObj = RecGoodsLkWork as object;
                    status = this.LogicalDeleteProcRcmd(ref paraObj, 1, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.DeleteAndWrite");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
                            //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                            //synchExecuteMng.SyncReqExecute();
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
        #endregion

        #region �yWriteRcmd�����z
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int WriteRcmd(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                status = WriteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
                //status = this.WriteProcRcmd(ref paraobj, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Write", status);
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
                            //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                            //synchExecuteMng.SyncReqExecute();
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
        #endregion

        #region �yWriteProcRcmd�z
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        private int WriteProcRcmd(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        // �R�l�N�V��������
                        sqlConnection = CreateSqlConnection();
                        if (sqlConnection == null) return status;

                        sqlConnection.Open();
                    }

                    RecGoodsLkWork RecGoodsLkWork = paraobj as RecGoodsLkWork;

                    //Select�R�}���h�̐���
                    using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, CUSTOMERCODERF, RECSOURCEBLGOODSCDRF, RECDESTBLGOODSCDRF, RECDESTBLGOODSNMRF, GOODSCOMMENTRF FROM RECGOODSLKRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD", sqlConnection))
                    {

                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                        SqlParameter findRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                        findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                        findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                        findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                        findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                        findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != RecGoodsLkWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (RecGoodsLkWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (sqlCommand != null)
                                {
                                    sqlCommand.Cancel();
                                    sqlCommand.Dispose();
                                }
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }
                            sqlCommand.CommandText = "UPDATE RECGOODSLKRF SET CREATEDATETIMERF=@CREATEDATETIME, UPDATEDATETIMERF=@UPDATEDATETIME, LOGICALDELETECODERF=@LOGICALDELETECODE, INQORIGINALEPCDRF=@INQORIGINALEPCD, INQORIGINALSECCDRF=@INQORIGINALSECCD, INQOTHEREPCDRF=@INQOTHEREPCD, INQOTHERSECCDRF=@INQOTHERSECCD, CUSTOMERCODERF=@CUSTOMERCODE, RECSOURCEBLGOODSCDRF=@RECSOURCEBLGOODSCD, RECDESTBLGOODSCDRF=@RECDESTBLGOODSCD, RECDESTBLGOODSNMRF=@RECDESTBLGOODSNM, GOODSCOMMENTRF=@GOODSCOMMENT WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD";

                            //////�X�V�w�b�_����ݒ�
                            ////object obj = (object)this;
                            ////IFileHeader flhd = (IFileHeader)campaignObjGoodsStWork;
                            ////FileHeader fileHeader = new FileHeader(obj);
                            ////fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (RecGoodsLkWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                if (sqlCommand != null)
                                {
                                    sqlCommand.Cancel();
                                    sqlCommand.Dispose();
                                }
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            RecGoodsLkWork.UpdateDateTime = DateTime.Now;
                            RecGoodsLkWork.CreateDateTime = DateTime.Now;
                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO RECGOODSLKRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, CUSTOMERCODERF, RECSOURCEBLGOODSCDRF, RECDESTBLGOODSCDRF, RECDESTBLGOODSNMRF, GOODSCOMMENTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @CUSTOMERCODE, @RECSOURCEBLGOODSCD, @RECDESTBLGOODSCD, @RECDESTBLGOODSNM, @GOODSCOMMENT)";
                            //////�o�^�w�b�_����ݒ�
                            ////object obj = (object)this;
                            ////IFileHeader flhd = (IFileHeader)campaignObjGoodsStWork;
                            ////FileHeader fileHeader = new FileHeader(obj);
                            ////fileHeader.SetInsertHeader(ref flhd, obj);
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCD", SqlDbType.Int);
                        SqlParameter paraRecDestBLGoodsCd = sqlCommand.Parameters.Add("@RECDESTBLGOODSCD", SqlDbType.Int);
                        SqlParameter paraRecDestBLGoodsNm = sqlCommand.Parameters.Add("@RECDESTBLGOODSNM", SqlDbType.NVarChar);
                        SqlParameter paraGoodsComment = sqlCommand.Parameters.Add("@GOODSCOMMENT", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWork.UpdateDateTime);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.LogicalDeleteCode);
                        paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd);
                        paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd);
                        paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd);
                        paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.CustomerCode);
                        paraRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.RecSourceBLGoodsCd);
                        paraRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.RecDestBLGoodsCd);
                        paraRecDestBLGoodsNm.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.RecDestBLGoodsNm);
                        paraGoodsComment.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.GoodsComment);

                        sqlCommand.ExecuteNonQuery();

                        paraobj = RecGoodsLkWork as object;

                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Write");
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }

            return status;
        }
        #endregion

        #region �yDeleteRcmd�����z
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">���R�����h���i�֘A�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int DeleteRcmd(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                status = this.DeleteProcRcmd(paraobj, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Delete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
                            //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                            //synchExecuteMng.SyncReqExecute();
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
        /// ���R�����h���i�֘A�ݒ�}�X�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">���R�����h���i�֘A�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int DeleteProcRcmd(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        // �R�l�N�V��������
                        sqlConnection = CreateSqlConnection();
                        if (sqlConnection == null) return status;

                        sqlConnection.Open();
                    }

                    RecGoodsLkWork RecGoodsLkWork = paraobj as RecGoodsLkWork;

                    using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, CUSTOMERCODERF, RECSOURCEBLGOODSCDRF, RECDESTBLGOODSCDRF, RECDESTBLGOODSNMRF, GOODSCOMMENTRF FROM RECGOODSLKRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD", sqlConnection))
                    {
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                        SqlParameter findRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                        findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                        findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                        findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                        findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                        findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != RecGoodsLkWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (sqlCommand != null)
                                {
                                    sqlCommand.Cancel();
                                    sqlCommand.Dispose();
                                }
                                if (!myReader.IsClosed) myReader.Close();

                                return status;
                            }

                            sqlCommand.CommandText = "DELETE FROM RECGOODSLKRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD";
                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                            findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                            findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                            findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                            findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                            findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            if (sqlCommand != null)
                            {
                                sqlCommand.Cancel();
                                sqlCommand.Dispose();
                            }
                            if (!myReader.IsClosed) myReader.Close();

                            return status;
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        sqlCommand.ExecuteNonQuery();
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Delete");
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion

        #region �yLogicalDeleteRcmd�����z
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��_���폜���܂�
        /// </summary>
        /// <param name="paraobj">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int LogicalDeleteRcmd(ref object paraobj)
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

                status = LogicalDeleteProcRcmd(ref paraobj, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLk.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region �yRevivalLogicalDeleteRcmd�����z
        /// <summary>
        /// �_���폜���R�����h���i�֘A�ݒ�}�X�^�𕜊����܂�
        /// </summary>
        /// <param name="paraobj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �_���폜���R�����h���i�֘A�ݒ�}�X�^�𕜊����܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int RevivalLogicalDeleteRcmd(ref object paraobj)
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

                status = LogicalDeleteProcRcmd(ref paraobj, 1, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLk.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region �yLogicalDeleteProcRcmd�z
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="paraobj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        private int LogicalDeleteProcRcmd(ref object paraobj, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                if (sqlConnection == null)
                {
                    // �R�l�N�V��������
                    sqlConnection = CreateSqlConnection();
                    if (sqlConnection == null) return status;

                    sqlConnection.Open();
                }

                RecGoodsLkWork RecGoodsLkWork = paraobj as RecGoodsLkWork;

                using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, CUSTOMERCODERF, RECSOURCEBLGOODSCDRF, RECDESTBLGOODSCDRF, RECDESTBLGOODSNMRF, GOODSCOMMENTRF FROM RECGOODSLKRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD", sqlConnection))
                {
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                    SqlParameter findRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                    findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                    findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                    findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                    findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                    findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); //�X�V����
                        if (_updateDateTime != RecGoodsLkWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

                            if (sqlCommand != null)
                            {
                                sqlCommand.Cancel();
                                sqlCommand.Dispose();
                            }
                            if (!myReader.IsClosed) myReader.Close();

                            return status;
                        }
                        //���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE RECGOODSLKRF SET UPDATEDATETIMERF=@UPDATEDATETIME, LOGICALDELETECODERF=@LOGICALDELETECODE WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD";
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                        findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                        findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                        findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                        findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                        findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                        if (sqlCommand != null)
                        {
                            sqlCommand.Cancel();
                            sqlCommand.Dispose();
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        return status;
                    }
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();

                    //�_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 0) RecGoodsLkWork.LogicalDeleteCode = 1; //�_���폜�t���O���Z�b�g
                        else                   RecGoodsLkWork.LogicalDeleteCode = 3; //���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1) RecGoodsLkWork.LogicalDeleteCode = 0; //�_���폜�t���O������
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; //���S�폜�̓f�[�^�Ȃ���߂�
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                    }

                    RecGoodsLkWork.UpdateDateTime = DateTime.Now;

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

                    paraobj = RecGoodsLkWork as RecGoodsLkWork;
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }

            return status;

        }
        #endregion

        #region �yReadDBBeforeSave�����z
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��
        /// </summary>
        /// <param name="paraobj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^��o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��</br>
        /// <br>Programmer : �{�{����</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        private int ReadDBBeforeSave(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        // �R�l�N�V��������
                        sqlConnection = CreateSqlConnection();
                        if (sqlConnection == null) return status;

                        sqlConnection.Open();
                    }

                    RecGoodsLkWork RecGoodsLkWork = paraobj as RecGoodsLkWork;
                    string selectTxt = string.Empty;

                    selectTxt += "SELECT " + Environment.NewLine;
                    selectTxt += " CREATEDATETIMERF" + Environment.NewLine;
                    selectTxt += ", UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += ", LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += ", INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += ", INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += ", INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += ", INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += ", CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += ", RECSOURCEBLGOODSCDRF" + Environment.NewLine;
                    selectTxt += ", RECDESTBLGOODSCDRF" + Environment.NewLine;
                    selectTxt += ", RECDESTBLGOODSNMRF" + Environment.NewLine;
                    selectTxt += ", GOODSCOMMENTRF" + Environment.NewLine;
                    selectTxt += " FROM RECGOODSLKRF" + Environment.NewLine;
                    selectTxt += " WHERE" + Environment.NewLine;
                    selectTxt += " INQORIGINALEPCDRF=@FINDINQORIGINALEPCD" + Environment.NewLine;
                    selectTxt += " AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD" + Environment.NewLine;
                    selectTxt += " AND INQOTHEREPCDRF=@FINDINQOTHEREPCD" + Environment.NewLine;
                    selectTxt += " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD" + Environment.NewLine;
                    selectTxt += " AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD" + Environment.NewLine;
                    selectTxt += " AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                    sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                    SqlParameter findRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                    findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                    findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                    findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                    findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                    findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                    sqlCommand.CommandText = selectTxt;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        return status;
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException sqlex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(sqlex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.ReadDBBeforeSave", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion
        // --- ADD 2015/01/22 T.Miyamoto -------------------------------------------------------------------------------------------------------------------<<<<<
    }
}
