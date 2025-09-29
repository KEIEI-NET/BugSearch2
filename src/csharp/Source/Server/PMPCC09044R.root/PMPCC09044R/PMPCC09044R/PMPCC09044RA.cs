//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�i�ڃO���[�v�}�X�^�����e
// �v���O�����T�v   : PCC�i�ڃO���[�v�}�X�^�����eDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.07.20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2013/05/30  �C�����e : 2013/99/99�z�M SCM��Q��10541�Ή� 
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
using Microsoft.Win32;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PCC�i�ڃO���[�v�}�X�^�����e�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�i�ڃO���[�v�}�X�^�����e�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.07.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PccItemGrpDB : RemoteDB, IPccItemGrpDB
    {
        #region [Const]
        private const string SOFTWARESTR = "SOFTWARE";
        private const string USER_AP_PATH = "Broadleaf\\Product\\Partsman\\SCM_NS_AP";
        private const string DataBaseMess = ";DataBase=SCM_DB;uid=sa;pwd=bl.sun.japan";
        #endregion

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public PccItemGrpDB() : base("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork", "PCCITEMGRPRF")
        {
        }

        #region [�R�l�N�V������������]

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
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
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }

        #endregion  //�g�����U�N�V������������

        #region IPccItemGrpDB �����o

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Write(ref object pccItemGrpWorkList, ref object pccItemStWorkList)
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
                status = WriteGrpProc(ref pccItemGrpWorkList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (pccItemStWorkList != null)
                    {
                        // write���s
                        status = WriteStProc(ref pccItemStWorkList, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Write");
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
        /// PCC�i�ڃO���[�v�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteGrpProc(ref object pccItemGrpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            ArrayList pccItemGrpWorkArrList = null;
            ArrayList pccItemGrpWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccItemGrpWorkList != null)
                {
                    pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;

                }
                if (pccItemGrpWorkArrList == null || pccItemGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemGrpWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccItemGrpWorkArrList.Count; i++ )
                {
                    PccItemGrpWork pccItemGrpWorkEach = pccItemGrpWorkArrList[i] as PccItemGrpWork;
                    if (pccItemGrpWorkEach.UpdateFlag == 2)
                    {
                        status = this.DeleteProcGrpEach(ref pccItemGrpWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    }
                    else
                    {
                        status = this.WriteGrpProcEach(ref pccItemGrpWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccItemGrpWorkArrListNew.Add(pccItemGrpWorkEach);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    
                }

                pccItemGrpWorkList = pccItemGrpWorkArrListNew as object;
               
           }
           catch (SqlException ex)
           {
               status = base.WriteSQLErrorLog(ex, "PccItemGrpWork.Write", status);
           }
          catch (Exception ex)
           {
               base.WriteErrorLog(ex, "PccItemGrpWork.Write");
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
        /// <param name="pccItemGrpWorkEach">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteGrpProcEach(ref PccItemGrpWork pccItemGrpWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Select�R�}���h�̐���
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMGRPRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            //remdime 24299
            findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccItemGrpWorkEach.UpdateDateTime)
                {
                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                    if (pccItemGrpWorkEach.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCITEMGRPRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , PCCCOMPANYCODERF=@PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMGROUPCODERF=@ITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMGROUPNAMERF=@ITEMGROUPNAME").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMGRPDSPODRRF=@ITEMGRPDSPODR").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append(" , ITEMGRPIMGCODERF=@ITEMGRPIMGCODE").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //KEY�R�}���h���Đݒ�
                //remdime 24299
                findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);

                //�R�l�N�V����������擾�Ή�����������
                //�X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemGrpWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                //�R�l�N�V����������擾�Ή�����������
            }

            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                if (pccItemGrpWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //�V�K�쐬����SQL���𐶐�
                sqlTxt.Append("INSERT INTO PCCITEMGRPRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMGROUPNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMGRPDSPODRRF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append("    ,ITEMGRPIMGCODERF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMGROUPNAME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMGRPDSPODR").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append("    ,@ITEMGRPIMGCODE").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�o�^�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemGrpWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetInsertHeader(ref flhd, obj);
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
            SqlParameter paraItemGroupCode = sqlCommand.Parameters.Add("@ITEMGROUPCODE", SqlDbType.Int);
            SqlParameter paraItemGroupName = sqlCommand.Parameters.Add("@ITEMGROUPNAME", SqlDbType.NVarChar);
            SqlParameter paraItemGrpDspOdr = sqlCommand.Parameters.Add("@ITEMGRPDSPODR", SqlDbType.Int);
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            SqlParameter paraItemGrpImgCode = sqlCommand.Parameters.Add("@ITEMGRPIMGCODE", SqlDbType.SmallInt);
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemGrpWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemGrpWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.LogicalDeleteCode);
            //Remine 24299 �̏C��
            paraInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            paraInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
            paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.PccCompanyCode);
            paraItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
            paraItemGroupName.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.ItemGroupName);
            paraItemGrpDspOdr.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGrpDspOdr);
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            paraItemGrpImgCode.Value = SqlDataMediator.SqlSetInt16(pccItemGrpWorkEach.ItemGrpImgCode);
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteStProc(ref object pccItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;


            SqlDataReader myReader = null;

            ArrayList pccItemStWorkArrList = null;
            ArrayList pccItemStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccItemStWorkList != null)
                {
                    pccItemStWorkArrList = pccItemStWorkList as ArrayList;

                }
                if (pccItemStWorkArrList == null || pccItemStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemStWorkArrListNew = new ArrayList();


                for (int i = 0; i < pccItemStWorkArrList.Count; i++)
                {
                    PccItemStWork pccItemStWorkEach = pccItemStWorkArrList[i] as PccItemStWork;
                    if (pccItemStWorkEach.UpdateFlag == 2)
                    {
                        status = DeleteStProcEach(ref pccItemStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    }
                    else
                    {
                        status = WriteStProcEach(ref pccItemStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccItemStWorkArrListNew.Add(pccItemStWorkEach);

                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                }
                pccItemStWorkList = pccItemStWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWork.Write", status);
            }
           
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWork.Write");
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
        /// <param name="pccItemStWorkEach">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WriteStProcEach(ref PccItemStWork pccItemStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //Select�R�}���h�̐���
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
            sqlTxt.Append(" FROM PCCITEMSTRF").Append(Environment.NewLine);
            sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            SqlParameter findParaItemDspPos1 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS1", SqlDbType.Int);
            SqlParameter findParaItemDspPos2 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS2", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            //remdime 24299
            findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
            findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
            findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccItemStWorkEach.UpdateDateTime)
                {
                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                    if (pccItemStWorkEach.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCITEMSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , PCCCOMPANYCODERF=@PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMGROUPCODERF=@ITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMDSPPOS1RF=@ITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMDSPPOS2RF=@ITEMDSPPOS2").Append(Environment.NewLine);
                sqlTxt.Append(" , BLGOODSCODERF=@BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMQTYRF=@ITEMQTY").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMSELECTDIVRF=@ITEMSELECTDIV").Append(Environment.NewLine);

                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                //remdime 24299
                findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
                findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
                findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
                //�R�l�N�V����������擾�Ή�����������
                //�X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemStWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                //�R�l�N�V����������擾�Ή�����������
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                if (pccItemStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //�V�K�쐬����SQL���𐶐�
                sqlTxt.Append("INSERT INTO PCCITEMSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMDSPPOS1RF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMDSPPOS2RF").Append(Environment.NewLine);
                sqlTxt.Append("    ,BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMQTYRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMSELECTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMDSPPOS2").Append(Environment.NewLine);
                sqlTxt.Append("    ,@BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMQTY").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMSELECTDIV").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //�o�^�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemStWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetInsertHeader(ref flhd, obj);
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
            SqlParameter paraItemGroupCode = sqlCommand.Parameters.Add("@ITEMGROUPCODE", SqlDbType.Int);
            SqlParameter paraItemDspPos1 = sqlCommand.Parameters.Add("@ITEMDSPPOS1", SqlDbType.Int);
            SqlParameter paraItemDspPos2 = sqlCommand.Parameters.Add("@ITEMDSPPOS2", SqlDbType.Int);
            SqlParameter paraBlGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraItemQty = sqlCommand.Parameters.Add("@ITEMQTY", SqlDbType.Int);
            SqlParameter paraItemSelectDiv = sqlCommand.Parameters.Add("@ITEMSELECTDIV", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.LogicalDeleteCode);
            //Redmine 24299
            paraInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            paraInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
            paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.PccCompanyCode);
            paraItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
            paraItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
            paraItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
            paraBlGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.BLGoodsCode);
            paraItemQty.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemQty);
            paraItemSelectDiv.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemSelectDiv);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;

        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="parsePccItemGrpWork">PCC�i�ڃO���[�v�����p�����[�^</param>
        /// <param name="parsePccItemStWork">PCC�i�ڐݒ茟���p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Search(out object pccItemGrpWorkList, out  object pccItemStWorkList, PccItemGrpWork parsePccItemGrpWork, PccItemStWork parsePccItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pccItemGrpWorkList = null;
            pccItemStWorkList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchGrpProc(out pccItemGrpWorkList, parsePccItemGrpWork, readMode, logicalMode, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // write���s
                    status = SearchStProc(out  pccItemStWorkList, parsePccItemStWork,  readMode, logicalMode, ref  sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Search");
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
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="parsePccItemGrpWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchGrpProc(out object pccItemGrpWorkList, PccItemGrpWork parsePccItemGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccItemGrpWorkList = null;
            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMGROUPNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMGRPDSPODRRF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append("      ,ITEMGRPIMGCODERF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                sqlTxt.Append("    FROM PCCITEMGRPRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd))
                {
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parsePccItemGrpWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parsePccItemGrpWork.InqOtherSecCd);
                
                }

                if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                {
                    if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherSecCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append(" INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parsePccItemGrpWork.InqOriginalEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parsePccItemGrpWork.InqOriginalSecCd);
                }

                //�_���폜�敪
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    if (!string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalEpCd.Trim()) || !string.IsNullOrEmpty(parsePccItemGrpWork.InqOriginalSecCd))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlTxt.Append("  ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();

                status = this.CopyToGrpWorkListFromReader(ref myReader, ref al);
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemGrpDB.SearchGrpProc", status);
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
            pccItemGrpWorkList = al;

            return status;
        }
        
        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="parsePccItemStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchStProc(out object pccItemStWorkList, PccItemStWork parsePccItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            pccItemStWorkList = null;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("      CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMDSPPOS1RF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMDSPPOS2RF").Append(Environment.NewLine);
                sqlTxt.Append("      ,BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMQTYRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMSELECTDIVRF").Append(Environment.NewLine);

                sqlTxt.Append("    FROM PCCITEMSTRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd))
                {
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parsePccItemStWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parsePccItemStWork.InqOtherSecCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemStWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                {
                    if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOtherSecCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parsePccItemStWork.InqOriginalEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccItemStWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parsePccItemStWork.InqOriginalSecCd);
                }
                //�_���폜�敪
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    if (!string.IsNullOrEmpty(parsePccItemStWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePccItemStWork.InqOriginalEpCd.Trim()) || !string.IsNullOrEmpty(parsePccItemStWork.InqOriginalSecCd))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlTxt.Append("    ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF,INQOTHEREPCDRF, INQOTHERSECCDRF, ITEMGROUPCODERF, ITEMDSPPOS1RF,ITEMDSPPOS2RF").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();
                status = CopyToStWorkListFromReader(ref myReader, ref al);
               
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCmpnyStDB.Write", status);
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
            pccItemStWorkList = al;

            return status;
        }
       
        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        /// 
        public int Read(ref object pccItemGrpWorkList,ref object pccItemStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadGrpProc(ref pccItemGrpWorkList, readMode, logicalMode, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // write���s
                    status = ReadStProc(ref  pccItemStWorkList,  readMode, logicalMode, ref  sqlConnection);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Read");
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
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int ReadGrpProc(ref object pccItemGrpWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
           
            ArrayList pccItemGrpWorkArrList = null;
            ArrayList pccItemGrpWorkArrListNew = null;
            try
            {
                if (pccItemGrpWorkList != null)
                {
                    pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                  
                }
                if (pccItemGrpWorkArrList == null || pccItemGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemGrpWorkArrListNew = new ArrayList();
         
               
             foreach (PccItemGrpWork pccItemGrpWorkEach in pccItemGrpWorkArrList)
             {
                StringBuilder sqlTxt = new StringBuilder();
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);

                //Select�R�}���h�̐���
                sqlTxt.Append("SELECT").Append(Environment.NewLine);
                sqlTxt.Append("  CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,ITEMGROUPNAMERF").Append(Environment.NewLine);
                sqlTxt.Append(" ,ITEMGRPDSPODRRF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                sqlTxt.Append(" ,ITEMGRPIMGCODERF").Append(Environment.NewLine);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
              
                sqlTxt.Append("FROM").Append(Environment.NewLine);
                sqlTxt.Append("  PCCITEMGRPRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("WHERE").Append(Environment.NewLine);
                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine); //�_���폜�敪
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlTxt.Append("  ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, ITEMGROUPCODERF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                status = this.CopyToGrpWorkListFromReader(ref myReader, ref pccItemGrpWorkArrListNew);
               
                pccItemGrpWorkList = pccItemGrpWorkArrListNew as object;
            }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemGrpWorkDB.ReadProc",status);
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
        /// PCC�i�ڃO���[�v�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        /// 
        public int ReadStProc(ref object pccItemStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
           
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList pccItemStWorkArrList = null;
            ArrayList pccItemStWorkArrListNew = null;
            try
            {
                if (pccItemStWorkList != null)
                {
                    pccItemStWorkArrList = pccItemStWorkList as ArrayList;

                }
                if (pccItemStWorkArrList == null || pccItemStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemStWorkArrListNew = new ArrayList();

                foreach (PccItemStWork pccItemStWorkEach in pccItemStWorkArrList)
                {
                    StringBuilder sqlTxt = new StringBuilder(string.Empty);
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                    sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                    sqlTxt.Append("      CREATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMGROUPCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMDSPPOS1RF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMDSPPOS2RF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,BLGOODSCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMQTYRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMSELECTDIVRF").Append(Environment.NewLine);

                    sqlTxt.Append("    FROM PCCITEMSTRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                    sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine); //�_���폜�敪
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "  AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    }
                    if (!string.IsNullOrEmpty(wkstring))
                    {
                        sqlTxt.Append(wkstring).Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }

                    sqlTxt.Append("  ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, ITEMGROUPCODERF,ITEMDSPPOS1RF,ITEMDSPPOS2RF").Append(Environment.NewLine);
                    sqlCommand.CommandText = sqlTxt.ToString();

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    //Remine 24299
                    findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                    findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    myReader = sqlCommand.ExecuteReader();
                    status = CopyToStWorkListFromReader(ref myReader, ref pccItemStWorkArrListNew);
                   
                    pccItemStWorkList = pccItemStWorkArrListNew as object;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.ReadProc", status);
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
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDelete(ref object pccItemGrpWorkList, ref object pccItemStWorkList)
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

                // LogicalDelete���s
                status = LogicalDeleteGrpProc(ref pccItemGrpWorkList, 0, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // write���s
                    if (pccItemStWorkList != null)
                    {
                        status = LogicalDeleteStProc(ref  pccItemStWorkList, 0, ref  sqlConnection, ref  sqlTransaction);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        PMBLGdsCdWork pMBLGdsCdWork = null;
                        ArrayList pccItemGrpWorkArrList = null;
                         if (pccItemGrpWorkList != null)
                         {
                             pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                         }
                         if (pccItemGrpWorkArrList.Count > 0)
                         {
                             PccItemGrpWork pccItemGrpWork = pccItemGrpWorkArrList[0] as PccItemGrpWork;
                             if (pccItemGrpWork.PccCompanyCode != 0)
                             {
                                 pMBLGdsCdWork = new PMBLGdsCdWork();
                                 pMBLGdsCdWork.InqOriginalEpCd = pccItemGrpWork.InqOriginalEpCd.Trim();	//@@@@20230303
                                 pMBLGdsCdWork.InqOriginalSecCd = pccItemGrpWork.InqOriginalSecCd;
                                 pMBLGdsCdWork.InqOtherEpCd = pccItemGrpWork.InqOtherEpCd;
                                 pMBLGdsCdWork.InqOtherSecCd = pccItemGrpWork.InqOtherSecCd;
                                 status = LogicalDeletePMBLGdsCdProc(ref  pMBLGdsCdWork, 0, ref  sqlConnection, ref  sqlTransaction);
                             }
                         }
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.LogicalDelete");
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
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDeleteGrpProc(ref object pccItemGrpWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccItemGrpWorkArrList = null;
            ArrayList pccItemGrpWorkArrListNew = null;
            try
            {
                if (pccItemGrpWorkList != null)
                {
                    pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                   
                }
                if (pccItemGrpWorkArrList == null || pccItemGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemGrpWorkArrListNew = new ArrayList();


                for (int i = 0; i < pccItemGrpWorkArrList.Count; i++ )
                {
                    PccItemGrpWork pccItemGrpWorkEach = pccItemGrpWorkArrList[i] as PccItemGrpWork;
                    status = LogicalDeleteProcGrpEach(ref pccItemGrpWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItemGrpWorkArrListNew.Add(pccItemGrpWorkEach);
                   
                   
                }
                pccItemGrpWorkList = pccItemGrpWorkArrListNew as object;
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
        /// PCC�i�ڐݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccItemGrpWorkEach">PCC�i�ڃO���[�v</param>
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
        public int LogicalDeleteProcGrpEach(ref PccItemGrpWork pccItemGrpWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMGRPRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccItemGrpWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //���݂̘_���폜�敪���擾
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE PCCITEMGRPRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
               
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);

                //�X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemGrpWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
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
                if (logicalDelCd == 0) pccItemGrpWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
            }
            else
            {
                if (logicalDelCd == 1) pccItemGrpWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������
            }

            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemGrpWorkEach.UpdateDateTime);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
       
        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        /// 
        public int LogicalDeleteStProc(ref object pccItemStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList pccItemStWorkArrList = null;
            ArrayList pccItemStWorkArrListNew = null;

            try
            {
                if (pccItemStWorkList != null)
                {
                    pccItemStWorkArrList = pccItemStWorkList as ArrayList;

                }
                if (pccItemStWorkArrList == null || pccItemStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccItemStWorkArrList.Count; i++)
                {
                    PccItemStWork pccItemStWorkEach = pccItemStWorkArrList[i] as PccItemStWork;
                    status = LogicalDeleteProcStEach(ref pccItemStWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItemStWorkArrListNew.Add(pccItemStWorkEach);

                    pccItemStWorkList = pccItemStWorkArrListNew as object;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWorkDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // myReader�̎ߕ�
                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccItemStWorkEach">PCC�i�ڐݒ�f�[�^���X�g</param>
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
        public int LogicalDeleteProcStEach(ref PccItemStWork pccItemStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(",  LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("   AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            SqlParameter findParaItemDspPos1 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS1", SqlDbType.Int);
            SqlParameter findParaItemDspPos2 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS2", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
            findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
            findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccItemStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //���݂̘_���폜�敪���擾
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                sqlTxt.Append("UPDATE PCCITEMSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
                findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
                findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
                //�X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccItemStWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                if (!myReader.IsClosed) myReader.Close();

                //�_���폜���[�h�̏ꍇ
                if (procMode == 0)
                {
                    if (logicalDelCd == 0) pccItemStWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                }
                else
                {
                    if (logicalDelCd == 1) pccItemStWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������
                }

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.LogicalDeleteCode);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccItemStWorkEach.UpdateDateTime);

                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }
            return status;

        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Delete(ref object pccItemGrpWorkList, ref object pccItemStWorkList)
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

                // Delete���s
                status = DeleteGrpProc(ref pccItemGrpWorkList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (pccItemStWorkList != null)
                    {
                        // write���s
                        status = DeleteStProc(ref  pccItemStWorkList, ref  sqlConnection, ref  sqlTransaction);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        PMBLGdsCdWork pMBLGdsCdWork = null;
                        ArrayList pccItemGrpWorkArrList = null;
                        if (pccItemGrpWorkList != null)
                        {
                            pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                        }
                        if (pccItemGrpWorkArrList.Count > 0)
                        {
                            PccItemGrpWork pccItemGrpWork = pccItemGrpWorkArrList[0] as PccItemGrpWork;
                            if (pccItemGrpWork.PccCompanyCode != 0)
                            {
                                pMBLGdsCdWork = new PMBLGdsCdWork();
                                pMBLGdsCdWork.InqOriginalEpCd = pccItemGrpWork.InqOriginalEpCd.Trim();	//@@@@20230303
                                pMBLGdsCdWork.InqOriginalSecCd = pccItemGrpWork.InqOriginalSecCd;
                                pMBLGdsCdWork.InqOtherEpCd = pccItemGrpWork.InqOtherEpCd;
                                pMBLGdsCdWork.InqOtherSecCd = pccItemGrpWork.InqOtherSecCd;
                                status = DeletePMBLGdsCdProc(ref  pMBLGdsCdWork, ref  sqlConnection, ref  sqlTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Delete");
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
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeleteGrpProc(ref object pccItemGrpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccItemGrpWorkArrList = null;
            ArrayList pccItemGrpWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccItemGrpWorkList != null)
                {
                    pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;

                }
                if (pccItemGrpWorkArrList == null || pccItemGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemGrpWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccItemGrpWorkArrList.Count; i++)
                {
                    PccItemGrpWork pccItemGrpWorkEach = pccItemGrpWorkArrList[i] as PccItemGrpWork;
                    status = DeleteProcGrpEach(ref pccItemGrpWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItemGrpWorkArrListNew.Add(pccItemGrpWorkEach);

                }

                pccItemGrpWorkList = pccItemGrpWorkArrListNew as object;
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
        /// PCC�i�ڐݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccItemGrpWorkEach">PCC�i�ڃO���[�v</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private int DeleteProcGrpEach(ref PccItemGrpWork pccItemGrpWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMGRPRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);


            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccItemGrpWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCITEMGRPRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = pccItemGrpWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemGrpWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemGrpWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemGrpWorkEach.ItemGroupCode);
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
        /// PCC�i�ڐݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeleteStProc(ref object pccItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccItemStWorkArrList = null;
            ArrayList pccItemStWorkArrListNew = null;
            try
            {
                if (pccItemStWorkList != null)
                {
                    pccItemStWorkArrList = pccItemStWorkList as ArrayList;

                }
                if (pccItemStWorkArrList == null || pccItemStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItemStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccItemStWorkArrList.Count; i++)
                {
                    PccItemStWork pccItemStWorkEach = pccItemStWorkArrList[i] as PccItemStWork;
                    status = DeleteStProcEach(ref pccItemStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItemStWorkArrListNew.Add(pccItemStWorkEach);
                }
                pccItemStWorkList = pccItemStWorkArrListNew as object;

            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWorkDB.Delete Exception=" + ex.Message);
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
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemStWorkEach">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeleteStProcEach(ref PccItemStWork pccItemStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCITEMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
            sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);

            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);


            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaItemGroupCode = sqlCommand.Parameters.Add("@FINDITEMGROUPCODE", SqlDbType.Int);
            SqlParameter findParaItemDspPos1 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS1", SqlDbType.Int);
            SqlParameter findParaItemDspPos2 = sqlCommand.Parameters.Add("@FINDITEMDSPPOS2", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
            findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
            findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
            findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
            findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                if (_updateDateTime != pccItemStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCITEMSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMGROUPCODERF = @FINDITEMGROUPCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS1RF = @FINDITEMDSPPOS1").Append(Environment.NewLine);
                sqlTxt.Append("  AND ITEMDSPPOS2RF = @FINDITEMDSPPOS2").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = pccItemStWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pccItemStWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccItemStWorkEach.InqOtherSecCd);
                findParaItemGroupCode.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemGroupCode);
                findParaItemDspPos1.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos1);
                findParaItemDspPos2.Value = SqlDataMediator.SqlSetInt32(pccItemStWorkEach.ItemDspPos2);
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

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
  
        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccItemGrpWorkList,ref object pccItemStWorkList)
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

                // RevivalLogicalDelete���s
                status = RevivalLogicalDeleteGrpProc(ref pccItemGrpWorkList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (pccItemStWorkList != null)
                    {
                        // write���s
                        status = RevivalLogicalDeleteStProc(ref  pccItemStWorkList, ref  sqlConnection, ref  sqlTransaction);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        PMBLGdsCdWork pMBLGdsCdWork = null;
                        ArrayList pccItemGrpWorkArrList = null;
                        if (pccItemGrpWorkList != null)
                        {
                            pccItemGrpWorkArrList = pccItemGrpWorkList as ArrayList;
                        }
                        if (pccItemGrpWorkArrList.Count > 0)
                        {
                            PccItemGrpWork pccItemGrpWork = pccItemGrpWorkArrList[0] as PccItemGrpWork;
                            if (pccItemGrpWork.PccCompanyCode != 0)
                            {
                                pMBLGdsCdWork = new PMBLGdsCdWork();
                                pMBLGdsCdWork.InqOriginalEpCd = pccItemGrpWork.InqOriginalEpCd.Trim();	//@@@@20230303
                                pMBLGdsCdWork.InqOriginalSecCd = pccItemGrpWork.InqOriginalSecCd;
                                pMBLGdsCdWork.InqOtherEpCd = pccItemGrpWork.InqOtherEpCd;
                                pMBLGdsCdWork.InqOtherSecCd = pccItemGrpWork.InqOtherSecCd;
                                status = RevivalLogicalDeletePMBLGdsCdProc(ref  pMBLGdsCdWork, ref  sqlConnection, ref  sqlTransaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.RevivalLogicalDelete");
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
        /// PCC�i�ڃO���[�v�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteGrpProc(ref object pccItemGrpWorkList,  ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteGrpProc(ref pccItemGrpWorkList, 1,ref sqlConnection,ref sqlTransaction);
        }
       
        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteStProc(ref object pccItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStProc(ref  pccItemStWorkList, 1, ref sqlConnection, ref  sqlTransaction);
        }

        /// <summary>
        /// PCCBL�R�[�h�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WritePMBLGdsCd(ref object pMBLGdsCdWorkList)
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
                status = WritePMBLGdsCdProc(ref pMBLGdsCdWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.WritePMBLGdsCd");
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
        /// PCCBL�R�[�h�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WritePMBLGdsCdProc(ref object pMBLGdsCdWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;

            ArrayList pMBLGdsCdWorkArrList = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pMBLGdsCdWorkList != null)
                {
                    pMBLGdsCdWorkArrList = pMBLGdsCdWorkList as ArrayList;

                }
                if (pMBLGdsCdWorkArrList == null || pMBLGdsCdWorkArrList.Count == 0)
                {
                    return status;
                }
                status = this.WritePMBLGdsCdProcEach(ref pMBLGdsCdWorkArrList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
               
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "WritePMBLGdsCdProc.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WritePMBLGdsCdProc.Write");
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
        /// PCCBL�R�[�h�o�^�A�X�V����
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int WritePMBLGdsCdProcEach(ref ArrayList pMBLGdsCdWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            ArrayList pMBLGdsCdWorkListNew = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (pMBLGdsCdWorkList == null && pMBLGdsCdWorkList.Count == 0)
            {
                return status;
            }
            PMBLGdsCdWork pMBLGdsCdWork = pMBLGdsCdWorkList[0] as PMBLGdsCdWork;
            //Select�R�}���h�̐���
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append(" DELETE").Append(Environment.NewLine);
            sqlTxt.Append("  FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PMBLGDSCDRF ").Append(Environment.NewLine);
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
            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWork.InqOriginalEpCd);
            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWork.InqOriginalSecCd);
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWork.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWork.InqOtherSecCd);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical); 
            sqlCommand.ExecuteNonQuery();

            foreach (PMBLGdsCdWork pMBLGdsCdWorkEach in pMBLGdsCdWorkList)
            {
                sqlTxt = new StringBuilder();
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

                //�V�K�쐬����SQL���𐶐�
                sqlTxt.Append("     INSERT INTO PMBLGDSCDRF ").Append(Environment.NewLine);
                sqlTxt.Append("      (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("     ) VALUES (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     , @PCCCOMPANYCODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("     , @BLGOODSFULLNAME").Append(Environment.NewLine);
                sqlTxt.Append("     , @BLGOODSHALFNAME").Append(Environment.NewLine);
                sqlTxt.Append("     )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�o�^�w�b�_����ݒ�
                pMBLGdsCdWorkEach.UpdateDateTime = DateTime.Now;
                pMBLGdsCdWorkEach.CreateDateTime = DateTime.Now;
                pMBLGdsCdWorkEach.LogicalDeleteCode = 0;

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                SqlParameter paraPccCompanyCode = sqlCommand.Parameters.Add("@PCCCOMPANYCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsHalfName = sqlCommand.Parameters.Add("@BLGOODSHALFNAME", SqlDbType.NVarChar);

                //Prameter�I�u�W�F�N�g�̍쐬
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMBLGdsCdWorkEach.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMBLGdsCdWorkEach.UpdateDateTime);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pMBLGdsCdWorkEach.LogicalDeleteCode);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalEpCd);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalSecCd);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);
                paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(pMBLGdsCdWorkEach.PccCompanyCode);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pMBLGdsCdWorkEach.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.BLGoodsFullName);
                paraBLGoodsHalfName.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.BLGoodsHalfName);
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
                sqlCommand.ExecuteNonQuery();
                pMBLGdsCdWorkListNew.Add(pMBLGdsCdWorkEach);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            pMBLGdsCdWorkList = pMBLGdsCdWorkListNew;
            return status;
        }

        /// <summary>
        /// PCCBL�R�[�h�}�X�^�����e��������
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int ReadPMBLGdsCd(ref object pMBLGdsCdWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadPMBLGdsCdProc(ref pMBLGdsCdWorkList, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.ReadPMBLGdsCd");
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
        /// PCCBL�R�[�h�}�X�^�����e��������
        /// </summary>
        /// <param name="objPMBLGdsCdWork">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int ReadPMBLGdsCdProc(ref object objPMBLGdsCdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            PMBLGdsCdWork wkPMBLGdsCdWorkOld = null;
            PMBLGdsCdWork wkPMBLGdsCdWorkNew = null;
            ArrayList alOld = new ArrayList();
            if (objPMBLGdsCdWork != null)
            {
                wkPMBLGdsCdWorkOld = objPMBLGdsCdWork as PMBLGdsCdWork;
            }
            else
            {
                return status;
            }
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
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
                sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("FROM").Append(Environment.NewLine);
                sqlTxt.Append("  PMBLGDSCDRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("WHERE").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND BLGOODSCODERF=@FINDBLGOODSCODE").Append(Environment.NewLine);
                //�_���폜�敪
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(wkPMBLGdsCdWorkOld.InqOriginalEpCd);
                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(wkPMBLGdsCdWorkOld.InqOriginalSecCd);
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(wkPMBLGdsCdWorkOld.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(wkPMBLGdsCdWorkOld.InqOtherSecCd);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(wkPMBLGdsCdWorkOld.BLGoodsCode);
                sqlCommand.CommandText = sqlTxt.ToString();
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {

                    wkPMBLGdsCdWorkNew = CopyPMBLGdsCdWorkFromSQL(myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (wkPMBLGdsCdWorkNew == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccItemGrpDB.ReadPMBLGdsCdProc", status);
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
            objPMBLGdsCdWork = wkPMBLGdsCdWorkNew;
            return status;
        }
       
        /// <summary>
        /// PCCBL�R�[�h�}�X�^�����e��������
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <param name="parsePMBLGdsCdWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchPMBLGdsCd(out object pMBLGdsCdWorkList, PMBLGdsCdWork parsePMBLGdsCdWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pMBLGdsCdWorkList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchPMBLGdsCdProc(out pMBLGdsCdWorkList, parsePMBLGdsCdWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemGrpDB.Search");
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
        /// PCCBL�R�[�h�}�X�^�����e��������
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <param name="parsePMBLGdsCdWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchPMBLGdsCdProc(out object pMBLGdsCdWorkList, PMBLGdsCdWork parsePMBLGdsCdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pMBLGdsCdWorkList = null;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null; 
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
                sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("FROM").Append(Environment.NewLine);
                sqlTxt.Append("  PMBLGDSCDRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("WHERE").Append(Environment.NewLine);
                if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherEpCd))
                {
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    //KEY�R�}���h���Đݒ�
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parsePMBLGdsCdWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherEpCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parsePMBLGdsCdWork.InqOtherSecCd);
                }
                if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                {
                    if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherSecCd))
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCDRF").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCDRF", SqlDbType.NChar);
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parsePMBLGdsCdWork.InqOriginalEpCd);
                }
                if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherEpCd) || !string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOtherSecCd) || !string.IsNullOrEmpty(parsePMBLGdsCdWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                    {
                        sqlTxt.Append("  AND ");
                    }
                    sqlTxt.Append("  INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parsePMBLGdsCdWork.InqOriginalSecCd);
                }
                //�_���폜�敪
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlCommand.CommandText = sqlTxt.ToString();
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                status = CopyPMBLGdsCdWorkListFromReader(ref myReader, ref al);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccItemGrpDB.SearchPMBLGdsCdProc", status);
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
            pMBLGdsCdWorkList = al;
            return status;
        }

        /// <summary>
        /// PMBL�R�[�h,PCC�i�ڃO���[�v,PCC�i�ڐݒ茟������
        /// </summary>
        /// <param name="retInfosList">PMBL�R�[�h,PCC�i�ڃO���[�v,PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="paraWorksList">PMBL�R�[�h,PCC�i�ڃO���[�v,PCC�i�ڐݒ茟���p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchFourInfos(out object retInfosList, ref object paraWorksList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retInfosList = null;
            CustomSerializeArrayList retInfosCustomSerializeList = new CustomSerializeArrayList();
            SqlConnection sqlConnection = null;
            //PMBL�R�[�h�����p�����[�^
            PMBLGdsCdWork paraPMBLGdsCdWork = null;
            //PCC�i�ڃO���[�v�����p�����[�^
            PccItemGrpWork paraPccItemGrpWork = null;
            //PCC�i�ڐݒ茟���p�����[�^
            PccItemStWork paraPccItemStWork = null;
            //PCCBL�R�[�h�f�[�^���X�g
            object pMBLGdsCdWorkObj = null;
            //PCC�i�ڃO���[�v�f�[�^���X�g
            object pccItemGrpWorkObj = null;
            //CC�i�ڐݒ�f�[�^���X�g
            object pccItemStWorkObj = null;
            //PCCBL�R�[�h�f�[�^���X�g
            ArrayList pMBLGdsCdWorkList = new ArrayList();
            //PCC�i�ڃO���[�v�f�[�^���X�g
            ArrayList pccItemGrpWorkList = new ArrayList();
            //CC�i�ڐݒ�f�[�^���X�g
            ArrayList pccItemStWorkList = new ArrayList();
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�����p�����[�^�`�F�b�N
                CustomSerializeArrayList paramArray = paraWorksList as CustomSerializeArrayList;
                if (paramArray == null || paramArray.Count <= 0)
                {
                    base.WriteErrorLog(null, "�v���O�����G���[�B�p�����[�^�����ݒ�ł�");
                    return status;
                }
                //�ʁX�̌����p�����[�^�̎擾
                for (int i = 0; i < paramArray.Count; i++)
                {
                    //PMBL�R�[�h�����p�����[�^
                    if (paramArray[i].GetType().Equals(typeof(PMBLGdsCdWork)))
                    {
                        paraPMBLGdsCdWork = paramArray[i] as PMBLGdsCdWork;
                        continue;
                    }
                    //PCC�i�ڃO���[�v�����p�����[�^
                    if (paramArray[i].GetType().Equals(typeof(PccItemGrpWork)))
                    {
                        paraPccItemGrpWork = paramArray[i] as PccItemGrpWork;
                        continue;
                    }
                    //PCC�i�ڐݒ茟���p�����[�^
                    if (paramArray[i].GetType().Equals(typeof(PccItemStWork)))
                    {
                        paraPccItemStWork = paramArray[i] as PccItemStWork;
                        continue;
                    }
                }
                int statusAll = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (paraPMBLGdsCdWork != null)
                {
                    //PCCBL�R�[�h�}�X�^�����e��������
                    status = SearchPMBLGdsCdProc(out pMBLGdsCdWorkObj, paraPMBLGdsCdWork, readMode, logicalMode, ref sqlConnection);
                    statusAll = status;
                }
                if (paraPccItemGrpWork != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //PCC�i�ڃO���[�v��������
                        status = SearchGrpProc(out pccItemGrpWorkObj, paraPccItemGrpWork, readMode, logicalMode, ref sqlConnection);
                        if (statusAll == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            statusAll = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                if (paraPccItemStWork != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //PCC�i�ڐݒ茟������
                        status = SearchStProc(out pccItemStWorkObj, paraPccItemStWork, readMode, logicalMode, ref sqlConnection);
                        if (statusAll == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            statusAll = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            status = statusAll;
                        }
                    }
                }
                if (pMBLGdsCdWorkObj != null)
                {
                    pMBLGdsCdWorkList = pMBLGdsCdWorkObj as ArrayList;
                }
                if (pccItemGrpWorkObj != null)
                {
                    pccItemGrpWorkList = pccItemGrpWorkObj as ArrayList;
                }
                if (pccItemStWorkObj != null)
                {
                    pccItemStWorkList = pccItemStWorkObj as ArrayList;
                }
                //PCCBL�R�[�h�f�[�^���X�g
                retInfosCustomSerializeList.Add(pMBLGdsCdWorkList);
                //PCC�i�ڃO���[�v�f�[�^���X�g
                retInfosCustomSerializeList.Add(pccItemGrpWorkList);
                //CC�i�ڐݒ�f�[�^���X�g
                retInfosCustomSerializeList.Add(pccItemStWorkList);
                retInfosList = retInfosCustomSerializeList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.SearchFourInfos");
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
        /// PCCBL�R�[�h�_���폜����
        /// </summary>
        /// <param name="pMBLGdsCdWork">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        /// 
        public int LogicalDeletePMBLGdsCdProc(ref PMBLGdsCdWork pMBLGdsCdWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            try
            {
                if (pMBLGdsCdWork == null)
                {
                    return status;
                }
                status = LogicalDeletePMBLGdsCdProcEach(ref pMBLGdsCdWork, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWorkDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // myReader�̎ߕ�
                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// PCCBL�R�[�h�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pMBLGdsCdWorkEach">PCCBL�R�[�h�f�[�^���X�g</param>
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
        public int LogicalDeletePMBLGdsCdProcEach(ref PMBLGdsCdWork pMBLGdsCdWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder(string.Empty);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);
            sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PMBLGDSCDRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);

            //KEY�R�}���h���Đݒ�
            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalEpCd);
            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalSecCd);
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);
            sqlCommand.CommandText = sqlTxt.ToString();
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //���݂̘_���폜�敪���擾
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                sqlTxt.Append("UPDATE PMBLGDSCDRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = pMBLGdsCdWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pMBLGdsCdWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);
                //�X�V�w�b�_����ݒ�
                pMBLGdsCdWorkEach.UpdateDateTime = DateTime.Now;
                if (!myReader.IsClosed) myReader.Close();

                //�_���폜���[�h�̏ꍇ
                if (procMode == 0)
                {
                    if (logicalDelCd == 0) pMBLGdsCdWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                }
                else
                {
                    if (logicalDelCd == 1) pMBLGdsCdWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������
                }

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pMBLGdsCdWorkEach.LogicalDeleteCode);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMBLGdsCdWorkEach.UpdateDateTime);

                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }
            return status;

        }

        /// <summary>
        /// PCCBL�R�[�h�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pMBLGdsCdWork">PCCBL�R�[�h��f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeletePMBLGdsCdProc(ref PMBLGdsCdWork pMBLGdsCdWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pMBLGdsCdWork == null)
                {
                    return status;
                }
                status = DeletePMBLGdsCdProcEach(ref pMBLGdsCdWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
               
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccItemStWorkDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccItemStWorkDB.Delete Exception=" + ex.Message);
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
        /// PCCBL�R�[�h�}�X�^�����e��������
        /// </summary>
        /// <param name="pMBLGdsCdWorkEach">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DeletePMBLGdsCdProcEach(ref PMBLGdsCdWork pMBLGdsCdWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
            sqlTxt.Append("     , PCCCOMPANYCODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSCODERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSFULLNAMERF").Append(Environment.NewLine);
            sqlTxt.Append("     , BLGOODSHALFNAMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PMBLGDSCDRF  WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
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

            //KEY�R�}���h���Đݒ�
            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalEpCd);
            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOriginalSecCd);
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PMBLGDSCDRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = pMBLGdsCdWorkEach.InqOriginalEpCd.Trim();	//@@@@20230303
                findParaInqOriginalSecCd.Value = pMBLGdsCdWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pMBLGdsCdWorkEach.InqOtherSecCd);
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

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCCBL�R�[�h�}�X�^�����e��������
        /// </summary>
        /// <param name="pMBLGdsCdWork">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeletePMBLGdsCdProc(ref PMBLGdsCdWork pMBLGdsCdWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeletePMBLGdsCdProc(ref  pMBLGdsCdWork, 1, ref sqlConnection, ref  sqlTransaction);
        }

#endregion

        #region ��������

        /// <summary>
        /// �o�l�a�k�R�[�h�f�[�^�擾����
        /// </summary>
        /// <param name="myReader">�o�l�a�k�R�[�h�f�[�^Reader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private PMBLGdsCdWork CopyPMBLGdsCdWorkFromSQL(SqlDataReader myReader)
        {
            PMBLGdsCdWork pMBLGdsCdWork = new PMBLGdsCdWork();
            //�쐬����
            pMBLGdsCdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //�X�V����
            pMBLGdsCdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //�_���폜�敪
            pMBLGdsCdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //�⍇������ƃR�[�h
            pMBLGdsCdWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF")).Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            pMBLGdsCdWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
            //�⍇�����ƃR�[�h
            pMBLGdsCdWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
            //�⍇���拒�_�R�[�h
            pMBLGdsCdWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
            //PCC���ЃR�[�h
            pMBLGdsCdWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PCCCOMPANYCODERF"));
            //BL���i�R�[�h
            pMBLGdsCdWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //BL���i�R�[�h���́i�S�p�j
            pMBLGdsCdWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            //BL���i�R�[�h���́i���p�j
            pMBLGdsCdWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            return pMBLGdsCdWork;
        }

        /// <summary>
        /// �o�l�a�k�R�[�h�擾����
        /// </summary>
        /// <param name="myReader">�o�l�a�k�R�[�hReader</param>
        /// <param name="pMBLGdsCdWorkList">�o�l�a�k�R�[�h�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyPMBLGdsCdWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pMBLGdsCdWorkList)
        {
            pMBLGdsCdWorkList = new ArrayList();
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
            //BL���i�R�[�h
            int colIndex_BLGoodsCode = 0;
            //BL���i�R�[�h���́i�S�p�j
            int colIndex_BLGoodsFullName = 0;
            //BL���i�R�[�h���́i���p�j
            int colIndex_BLGoodsHalfName = 0;
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
                    //PCC���ЃR�[�h
                    colIndex_PccCompanyCode = myReader.GetOrdinal("PCCCOMPANYCODERF");
                    //BL���i�R�[�h
                    colIndex_BLGoodsCode = myReader.GetOrdinal("BLGOODSCODERF");
                    //BL���i�R�[�h���́i�S�p�j
                    colIndex_BLGoodsFullName = myReader.GetOrdinal("BLGOODSFULLNAMERF");
                    //BL���i�R�[�h���́i���p�j
                    colIndex_BLGoodsHalfName = myReader.GetOrdinal("BLGOODSHALFNAMERF");
                }
                while (myReader.Read())
                {
                    PMBLGdsCdWork pMBLGdsCdWork = new PMBLGdsCdWork();
                    //�쐬����
                    pMBLGdsCdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //�X�V����
                    pMBLGdsCdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //�_���폜�敪
                    pMBLGdsCdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //�⍇������ƃR�[�h
                    pMBLGdsCdWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd).Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    pMBLGdsCdWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //�⍇�����ƃR�[�h
                    pMBLGdsCdWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //�⍇���拒�_�R�[�h
                    pMBLGdsCdWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //PCC���ЃR�[�h
                    pMBLGdsCdWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                    //BL���i�R�[�h
                    pMBLGdsCdWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsCode);
                    //BL���i�R�[�h���́i�S�p�j
                    pMBLGdsCdWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, colIndex_BLGoodsFullName);
                    //BL���i�R�[�h���́i���p�j
                    pMBLGdsCdWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, colIndex_BLGoodsHalfName);
                    pMBLGdsCdWorkList.Add(pMBLGdsCdWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pMBLGdsCdWorkList.Count == 0)
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
        /// PCC�i�ڃO���[�v�擾����
        /// </summary>
        /// <param name="myReader">PPCC�i�ڃO���[�vReader</param>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyToGrpWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccItemGrpWorkList)
        {
            pccItemGrpWorkList = new ArrayList();
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
            //�i�ڃO���[�v�R�[�h
            int colIndex_ItemGroupCode = 0;
            //�i�ڃO���[�v����
            int colIndex_ItemGroupName = 0;
            //�i�ڃO���[�v�\������
            int colIndex_ItemGrpDspOdr = 0;
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�i�ڃO���[�v�摜�R�[�h
            int colIndex_ItemGrpImgCode = 0;
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
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
                    //PCC���ЃR�[�h
                    colIndex_PccCompanyCode = myReader.GetOrdinal("PCCCOMPANYCODERF");
                    //�i�ڃO���[�v�R�[�h
                    colIndex_ItemGroupCode = myReader.GetOrdinal("ITEMGROUPCODERF");
                    //�i�ڃO���[�v����
                    colIndex_ItemGroupName = myReader.GetOrdinal("ITEMGROUPNAMERF");
                    //�i�ڃO���[�v�\������
                    colIndex_ItemGrpDspOdr = myReader.GetOrdinal("ITEMGRPDSPODRRF");
                    // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //�i�ڃO���[�v�摜�R�[�h
                    colIndex_ItemGrpImgCode = myReader.GetOrdinal("ITEMGRPIMGCODERF");
                    // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                }
                while (myReader.Read())
                {
                    PccItemGrpWork wkPccItemGrpWork = new PccItemGrpWork();
                    //�쐬����
                    wkPccItemGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //�X�V����
                    wkPccItemGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //�_���폜�敪
                    wkPccItemGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //�⍇������ƃR�[�h
                    wkPccItemGrpWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd).Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    wkPccItemGrpWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //�⍇�����ƃR�[�h
                    wkPccItemGrpWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //�⍇���拒�_�R�[�h
                    wkPccItemGrpWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //PCC���ЃR�[�h
                    wkPccItemGrpWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                    //�i�ڃO���[�v�R�[�h
                    wkPccItemGrpWork.ItemGroupCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemGroupCode);
                    //�i�ڃO���[�v����
                    wkPccItemGrpWork.ItemGroupName = SqlDataMediator.SqlGetString(myReader, colIndex_ItemGroupName);
                    //�i�ڃO���[�v�\������
                    wkPccItemGrpWork.ItemGrpDspOdr = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemGrpDspOdr);
                    // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //�i�ڃO���[�v�摜�R�[�h
                    wkPccItemGrpWork.ItemGrpImgCode = SqlDataMediator.SqlGetInt16(myReader, colIndex_ItemGrpImgCode);
                    // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    pccItemGrpWorkList.Add(wkPccItemGrpWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccItemGrpWorkList.Count == 0)
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
        /// PCC�i�ڐݒ�擾����
        /// </summary>
        /// <param name="myReader">PPCC�i�ڐݒ�Reader</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyToStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccItemStWorkList)
        {
            pccItemStWorkList = new ArrayList();
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
            //�i�ڃO���[�v�R�[�h
            int colIndex_ItemGroupCode = 0;
            //�i�ڕ\���ʒu1
            int colIndex_ItemDspPos1 = 0;
            //�i�ڕ\���ʒu2
            int colIndex_ItemDspPos2 = 0;
            //BL���i�R�[�h
            int colIndex_BLGoodsCode = 0;
            //�i��QTY
            int colIndex_ItemQty = 0;
            //�i�ڑI���敪
            int colIndex_ItemSelectDiv = 0;
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
                    //PCC���ЃR�[�h
                    colIndex_PccCompanyCode = myReader.GetOrdinal("PCCCOMPANYCODERF");
                    //�i�ڃO���[�v�R�[�h
                    colIndex_ItemGroupCode = myReader.GetOrdinal("ITEMGROUPCODERF");
                    //�i�ڕ\���ʒu1
                    colIndex_ItemDspPos1 = myReader.GetOrdinal("ITEMDSPPOS1RF");
                    //�i�ڕ\���ʒu2
                    colIndex_ItemDspPos2 = myReader.GetOrdinal("ITEMDSPPOS2RF");
                    //BL���i�R�[�h
                    colIndex_BLGoodsCode = myReader.GetOrdinal("BLGOODSCODERF");
                    //�i��QTY
                    colIndex_ItemQty = myReader.GetOrdinal("ITEMQTYRF");
                    //�i�ڑI���敪
                    colIndex_ItemSelectDiv = myReader.GetOrdinal("ITEMSELECTDIVRF");
                }
                while (myReader.Read())
                {
                    PccItemStWork wkPccItemStWork = new PccItemStWork();
                    //�쐬����
                    wkPccItemStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //�X�V����
                    wkPccItemStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //�_���폜�敪
                    wkPccItemStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //�⍇������ƃR�[�h
                    wkPccItemStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd).Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    wkPccItemStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //�⍇�����ƃR�[�h
                    wkPccItemStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //�⍇���拒�_�R�[�h
                    wkPccItemStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //PCC���ЃR�[�h
                    wkPccItemStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PccCompanyCode);
                    //�i�ڃO���[�v�R�[�h
                    wkPccItemStWork.ItemGroupCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemGroupCode);
                    //�i�ڕ\���ʒu1
                    wkPccItemStWork.ItemDspPos1 = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemDspPos1);
                    //�i�ڕ\���ʒu2
                    wkPccItemStWork.ItemDspPos2 = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemDspPos2);
                    //BL���i�R�[�h
                    wkPccItemStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsCode);
                    //�i��QTY
                    wkPccItemStWork.ItemQty = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemQty);
                    //�i�ڑI���敪
                    wkPccItemStWork.ItemSelectDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemSelectDiv);

                    pccItemStWorkList.Add(wkPccItemStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccItemStWorkList.Count == 0)
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

        #endregion
    }
}
