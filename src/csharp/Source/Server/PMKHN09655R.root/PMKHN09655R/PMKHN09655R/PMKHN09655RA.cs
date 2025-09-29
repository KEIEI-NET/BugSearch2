//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/05  �C�����e : Redmine#22750 �t�H�[�J�X�����Q�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Broadleaf.Library.Data;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/27</br>
    /// <br></br>
    /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class CampaignTargetUDB : RemoteWithAppLockDB, ICampaignTargetUDB
    {
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        /// </remarks>
        public CampaignTargetUDB()
            : base("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork", "CAMPAIGNTARGETRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̃L�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="campaignTargetObj">CampaignTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����L�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int Read(ref object campaignTargetObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CampaignTargetWork campaignTargetWork = campaignTargetObj as CampaignTargetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref campaignTargetWork, readMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// �P��̃L�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="campaignTargetWork">CampaignTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����L�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int Read(ref CampaignTargetWork campaignTargetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref campaignTargetWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̃L�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="campaignTargetWork">CampaignTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����L�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        private int ReadProc(ref CampaignTargetWork campaignTargetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                sqlText += "  ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,SALESAREACODERF" + Environment.NewLine;
                sqlText += "  ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,SALESCODERF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETRF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETPROFITRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETPROFITRF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETCOUNTRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETCOUNTRF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDPARACAMPAIGNCODE", SqlDbType.Int);
                SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDPARATARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEEDIVCD", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDPARASECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDPARACUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDPARASALESAREACODE", SqlDbType.Int);
                SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDPARABLGROUPCODE", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDPARABLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDPARASALESCODE", SqlDbType.Int);


                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToCampaignTargetWorkFromReader(ref myReader, ref campaignTargetWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion

        # region [Delete]
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�����폜����L�����y�[���ڕW�ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����L�����y�[���ڕW�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteCampaignTargetProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// �L�����y�[���ڕW�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="campaignTargetList">�L�����y�[���ڕW�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int DeleteCampaignTargetProc(ArrayList campaignTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(campaignTargetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="campaignTargetList">�L�����y�[���ڕW�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        private int DeleteProc(ArrayList campaignTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (campaignTargetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < campaignTargetList.Count; i++)
                    {
                        CampaignTargetWork campaignTargetWork = campaignTargetList[i] as CampaignTargetWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "   UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                        sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                        sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                        sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDPARACAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDPARATARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDPARASECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDPARACUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDPARASALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDPARABLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDPARABLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDPARASALESCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                        findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                        findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != campaignTargetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  CAMPAIGNTARGETRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                            sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                            sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                            findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion
        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CampaignTargetWork[] CampaignTargetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is CampaignTargetWork)
                    {
                        CampaignTargetWork wkCampaignTargetWork = paraobj as CampaignTargetWork;
                        if (wkCampaignTargetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCampaignTargetWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CampaignTargetWorkArray = (CampaignTargetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CampaignTargetWork[]));
                        }
                        catch (Exception) { }
                        if (CampaignTargetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CampaignTargetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CampaignTargetWork wkCampaignTargetWork = (CampaignTargetWork)XmlByteSerializer.Deserialize(byteArray, typeof(CampaignTargetWork));
                                if (wkCampaignTargetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCampaignTargetWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion
        # region [Search]
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="campaignTargetList">��������</param>
        /// <param name="campaignTargetObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����A�S�ẴL�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int Search(ref object campaignTargetList, object campaignTargetObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList campaignTargetArray = campaignTargetList as ArrayList;
                CampaignTargetWork campaignTargetUWork = campaignTargetObj as CampaignTargetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref campaignTargetArray, campaignTargetUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// �L�����y�[���ڕW�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="campaignTargetList">�L�����y�[���ڕW�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="campaignTargetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����A�S�ẴL�����y�[���ڕW�ݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int Search(ref ArrayList campaignTargetList, CampaignTargetWork campaignTargetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref campaignTargetList, campaignTargetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="campaignTargetList">�L�����y�[���ڕW�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="campaignTargetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����A�S�ẴL�����y�[���ڕW�ݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        private int SearchProc(ref ArrayList campaignTargetList, CampaignTargetWork campaignTargetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                sqlText += "  ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,SALESAREACODERF" + Environment.NewLine;
                sqlText += "  ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,SALESCODERF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETRF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETPROFITRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETPROFITRF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETCOUNTRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETCOUNTRF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, campaignTargetWork, logicalMode);
                # endregion


                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    campaignTargetList.Add(this.CopyToCampaignTargetWorkFromReader(ref myReader));
                }

                if (campaignTargetList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion

        # region [Write]
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="campaignTargetList">�ǉ��E�X�V����L�����y�[���ڕW�ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int Write(ref object campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = campaignTargetList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// �L�����y�[���ڕW�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="campaignTargetList">�ǉ��E�X�V����L�����y�[���ڕW�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int Write(ref ArrayList campaignTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref campaignTargetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="campaignTargetList">�ǉ��E�X�V����L�����y�[���ڕW�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        private int WriteProc(ref ArrayList campaignTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (campaignTargetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < campaignTargetList.Count; i++)
                    {
                        CampaignTargetWork campaignTargetWork = campaignTargetList[i] as CampaignTargetWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CAMPAIGNTARGETRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                        sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                        sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                        sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDPARACAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDPARATARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDPARASECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDPARACUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDPARASALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDPARABLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDPARABLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDPARASALESCODE", SqlDbType.Int);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                        findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                        findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != campaignTargetWork.UpdateDateTime)
                            {
                                if (campaignTargetWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE CAMPAIGNTARGETRF SET" + Environment.NewLine;
                            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,CAMPAIGNCODERF=@CAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  ,TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  ,SALESAREACODERF=@SALESAREACODE" + Environment.NewLine;
                            sqlText += "  ,BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                            sqlText += "  ,BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlText += "  ,SALESCODERF=@SALESCODE" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY1RF=@SALESTARGETMONEY1" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY2RF=@SALESTARGETMONEY2" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY3RF=@SALESTARGETMONEY3" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY4RF=@SALESTARGETMONEY4" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY5RF=@SALESTARGETMONEY5" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY6RF=@SALESTARGETMONEY6" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY7RF=@SALESTARGETMONEY7" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY8RF=@SALESTARGETMONEY8" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY9RF=@SALESTARGETMONEY9" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY10RF=@SALESTARGETMONEY10" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY11RF=@SALESTARGETMONEY11" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY12RF=@SALESTARGETMONEY12" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETRF=@MONTHLYSALESTARGET" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETRF=@TERMSALESTARGET" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT1RF=@SALESTARGETPROFIT1" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT2RF=@SALESTARGETPROFIT2" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT3RF=@SALESTARGETPROFIT3" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT4RF=@SALESTARGETPROFIT4" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT5RF=@SALESTARGETPROFIT5" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT6RF=@SALESTARGETPROFIT6" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT7RF=@SALESTARGETPROFIT7" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT8RF=@SALESTARGETPROFIT8" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT9RF=@SALESTARGETPROFIT9" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT10RF=@SALESTARGETPROFIT10" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT11RF=@SALESTARGETPROFIT11" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT12RF=@SALESTARGETPROFIT12" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETPROFITRF=@MONTHLYSALESTARGETPROFIT" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETPROFITRF=@TERMSALESTARGETPROFIT" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT1RF=@SALESTARGETCOUNT1" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT2RF=@SALESTARGETCOUNT2" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT3RF=@SALESTARGETCOUNT3" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT4RF=@SALESTARGETCOUNT4" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT5RF=@SALESTARGETCOUNT5" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT6RF=@SALESTARGETCOUNT6" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT7RF=@SALESTARGETCOUNT7" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT8RF=@SALESTARGETCOUNT8" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT9RF=@SALESTARGETCOUNT9" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT10RF=@SALESTARGETCOUNT10" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT11RF=@SALESTARGETCOUNT11" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT12RF=@SALESTARGETCOUNT12" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETCOUNTRF=@MONTHLYSALESTARGETCOUNT" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETCOUNTRF=@TERMSALESTARGETCOUNT" + Environment.NewLine;
                            sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                            sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                            sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                            findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignTargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (campaignTargetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CAMPAIGNTARGETRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  ,CAMPAIGNCODERF" + Environment.NewLine;
                            sqlText += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "  ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += "  ,BLGROUPCODERF" + Environment.NewLine;
                            sqlText += "  ,BLGOODSCODERF" + Environment.NewLine;
                            sqlText += "  ,SALESCODERF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY1RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY2RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY3RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY4RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY5RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY6RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY7RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY8RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY9RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY10RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY11RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY12RF" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETRF" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETRF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT1RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT2RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT3RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT4RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT5RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT6RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT7RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT8RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT9RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT10RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT11RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT12RF" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETPROFITRF" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETPROFITRF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT1RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT2RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT3RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT4RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT5RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT6RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT7RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT8RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT9RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT10RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT11RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT12RF" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETCOUNTRF" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETCOUNTRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,@CAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  ,@TARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  ,@EMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += "  ,@BLGROUPCODE" + Environment.NewLine;
                            sqlText += "  ,@BLGOODSCODE" + Environment.NewLine;
                            sqlText += "  ,@SALESCODE" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY1" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY2" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY3" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY4" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY5" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY6" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY7" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY8" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY9" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY10" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY11" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY12" + Environment.NewLine;
                            sqlText += "  ,@MONTHLYSALESTARGET" + Environment.NewLine;
                            sqlText += "  ,@TERMSALESTARGET" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT1" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT2" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT3" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT4" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT5" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT6" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT7" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT8" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT9" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT10" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT11" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT12" + Environment.NewLine;
                            sqlText += "  ,@MONTHLYSALESTARGETPROFIT" + Environment.NewLine;
                            sqlText += "  ,@TERMSALESTARGETPROFIT" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT1" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT2" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT3" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT4" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT5" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT6" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT7" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT8" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT9" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT10" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT11" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT12" + Environment.NewLine;
                            sqlText += "  ,@MONTHLYSALESTARGETCOUNT" + Environment.NewLine;
                            sqlText += "  ,@TERMSALESTARGETCOUNT)" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignTargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                        SqlParameter paraSalesTargetMoney1 = sqlCommand.Parameters.Add("@SALESTARGETMONEY1", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney2 = sqlCommand.Parameters.Add("@SALESTARGETMONEY2", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney3 = sqlCommand.Parameters.Add("@SALESTARGETMONEY3", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney4 = sqlCommand.Parameters.Add("@SALESTARGETMONEY4", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney5 = sqlCommand.Parameters.Add("@SALESTARGETMONEY5", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney6 = sqlCommand.Parameters.Add("@SALESTARGETMONEY6", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney7 = sqlCommand.Parameters.Add("@SALESTARGETMONEY7", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney8 = sqlCommand.Parameters.Add("@SALESTARGETMONEY8", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney9 = sqlCommand.Parameters.Add("@SALESTARGETMONEY9", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney10 = sqlCommand.Parameters.Add("@SALESTARGETMONEY10", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney11 = sqlCommand.Parameters.Add("@SALESTARGETMONEY11", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney12 = sqlCommand.Parameters.Add("@SALESTARGETMONEY12", SqlDbType.BigInt);
                        SqlParameter paraMonthlySalesTarget = sqlCommand.Parameters.Add("@MONTHLYSALESTARGET", SqlDbType.BigInt);
                        SqlParameter paraTermSalesTarget = sqlCommand.Parameters.Add("@TERMSALESTARGET", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit1 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT1", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit2 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT2", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit3 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT3", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit4 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT4", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit5 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT5", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit6 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT6", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit7 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT7", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit8 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT8", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit9 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT9", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit10 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT10", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit11 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT11", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit12 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT12", SqlDbType.BigInt);
                        SqlParameter paraMonthlySalesTargetProfit = sqlCommand.Parameters.Add("@MONTHLYSALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraTermSalesTargetProfit = sqlCommand.Parameters.Add("@TERMSALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetCount1 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT1", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount2 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT2", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount3 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT3", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount4 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT4", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount5 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT5", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount6 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT6", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount7 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT7", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount8 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT8", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount9 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT9", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount10 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT10", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount11 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT11", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount12 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT12", SqlDbType.Float);
                        SqlParameter paraMonthlySalesTargetCount = sqlCommand.Parameters.Add("@MONTHLYSALESTARGETCOUNT", SqlDbType.Float);
                        SqlParameter paraTermSalesTargetCount = sqlCommand.Parameters.Add("@TERMSALESTARGETCOUNT", SqlDbType.Float);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignTargetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignTargetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignTargetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.LogicalDeleteCode);
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                        paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                        paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                        paraEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);
                        paraSalesTargetMoney1.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney1);
                        paraSalesTargetMoney2.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney2);
                        paraSalesTargetMoney3.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney3);
                        paraSalesTargetMoney4.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney4);
                        paraSalesTargetMoney5.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney5);
                        paraSalesTargetMoney6.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney6);
                        paraSalesTargetMoney7.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney7);
                        paraSalesTargetMoney8.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney8);
                        paraSalesTargetMoney9.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney9);
                        paraSalesTargetMoney10.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney10);
                        paraSalesTargetMoney11.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney11);
                        paraSalesTargetMoney12.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney12);
                        paraMonthlySalesTarget.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.MonthlySalesTarget);
                        paraTermSalesTarget.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.TermSalesTarget);
                        paraSalesTargetProfit1.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit1);
                        paraSalesTargetProfit2.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit2);
                        paraSalesTargetProfit3.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit3);
                        paraSalesTargetProfit4.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit4);
                        paraSalesTargetProfit5.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit5);
                        paraSalesTargetProfit6.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit6);
                        paraSalesTargetProfit7.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit7);
                        paraSalesTargetProfit8.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit8);
                        paraSalesTargetProfit9.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit9);
                        paraSalesTargetProfit10.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit10);
                        paraSalesTargetProfit11.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit11);
                        paraSalesTargetProfit12.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit12);
                        paraMonthlySalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.MonthlySalesTargetProfit);
                        paraTermSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.TermSalesTargetProfit);
                        paraSalesTargetCount1.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount1);
                        paraSalesTargetCount2.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount2);
                        paraSalesTargetCount3.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount3);
                        paraSalesTargetCount4.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount4);
                        paraSalesTargetCount5.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount5);
                        paraSalesTargetCount6.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount6);
                        paraSalesTargetCount7.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount7);
                        paraSalesTargetCount8.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount8);
                        paraSalesTargetCount9.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount9);
                        paraSalesTargetCount10.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount10);
                        paraSalesTargetCount11.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount11);
                        paraSalesTargetCount12.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount12);
                        paraMonthlySalesTargetCount.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.MonthlySalesTargetCount);
                        paraTermSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.TermSalesTargetCount);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignTargetWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            campaignTargetList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="campaignTargetList">�_���폜����L�����y�[���ڕW�ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int LogicalDelete(ref object campaignTargetList)
        {
            return this.LogicalDelete(ref campaignTargetList, 0);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="campaignTargetList">�_���폜����������L�����y�[���ڕW�ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int RevivalLogicalDelete(ref object campaignTargetList)
        {
            return this.LogicalDelete(ref campaignTargetList, 1);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="campaignTargetList">�_���폜�𑀍삷��L�����y�[���ڕW�ݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        private int LogicalDelete(ref object campaignTargetList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = campaignTargetList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// �L�����y�[���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="campaignTargetList">�_���폜�𑀍삷��L�����y�[���ڕW�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        public int LogicalDelete(ref ArrayList campaignTargetList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref campaignTargetList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="campaignTargetList">�_���폜�𑀍삷��L�����y�[���ڕW�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        /// <br>Update Note: 2011/07/05 杍^ Redmine#22750 �t�H�[�J�X�����Q�̑Ή�</br>
        private int LogicalDeleteProc(ref ArrayList campaignTargetList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (campaignTargetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < campaignTargetList.Count; i++)
                    {
                        CampaignTargetWork campaignTargetWork = campaignTargetList[i] as CampaignTargetWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "   UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                        sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                        sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;   // ADD K2011/07/05 
                        sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDPARACAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDPARATARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDPARASECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDPARACUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDPARASALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDPARABLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDPARABLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDPARASALESCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                        findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                        findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != campaignTargetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE CAMPAIGNTARGETRF SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                            sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                            sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                            findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignTargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        // �_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // ���ɍ폜�ς݂̏ꍇ����
                                return status;
                            }
                            else if (logicalDelCd == 0) campaignTargetWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else campaignTargetWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                campaignTargetWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // ���S�폜�̓f�[�^�Ȃ���߂�
                                }

                                return status;
                            }
                        }

                        // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignTargetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignTargetWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            campaignTargetList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="campaignTargetWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignTargetWork campaignTargetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);

            // �L�����y�[���R�[�h
            retstring += "  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE" + Environment.NewLine;
            SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);

            // �ڕW�Δ�敪
            retstring += "  AND TARGETCONTRASTCDRF = @FINDTARGETCONTRASTCD" + Environment.NewLine;
            SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
            findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            if (campaignTargetWork.TargetContrastCd == 10)
            {
                // ���_�R�[�h
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }
            }

            if (campaignTargetWork.TargetContrastCd == 22)
            {
                // ���_�R�[�h
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // �]�ƈ��R�[�h
                if (string.IsNullOrEmpty(campaignTargetWork.EmployeeCode) == false)
                {
                    retstring += "AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                    SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                    findEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EmployeeCode);
                }

                // �]�ƈ��敪
                if (campaignTargetWork.EmployeeDivCd != 0)
                {
                    retstring += "AND EMPLOYEEDIVCDRF = @FINDEMPLOYEEDIVCD" + Environment.NewLine;
                    SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                    findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                }
            }

            if (campaignTargetWork.TargetContrastCd == 30)
            {
                // ���_�R�[�h
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // ���Ӑ�R�[�h
                if (campaignTargetWork.CustomerCode != 0)
                {
                    retstring += "AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);

                }
            }

            if (campaignTargetWork.TargetContrastCd == 32)
            {
                // ���_�R�[�h
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }
                 
                // �̔��G���A�R�[�h
                if (campaignTargetWork.SalesAreaCode != 0)
                {
                    retstring += "AND SALESAREACODERF = @FINDSALESAREACODE" + Environment.NewLine;
                    SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                    findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                }
            }

            if (campaignTargetWork.TargetContrastCd == 44)
            {
                // ���_�R�[�h
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // �̔��敪�R�[�h
                if (campaignTargetWork.SalesCode != 0)
                {                                   
                    retstring += "AND SALESCODERF = @FINDSALESCODE" + Environment.NewLine;
                    SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                    findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);
                }
            }

            if (campaignTargetWork.TargetContrastCd == 50)
            {
                // ���_�R�[�h
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // BL�O���[�v�R�[�h
                if (campaignTargetWork.BLGroupCode != 0)
                {
                    retstring += "AND BLGROUPCODERF = @FINDBLGROUPCODE" + Environment.NewLine;
                    SqlParameter findBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    findBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                }
            }

            if (campaignTargetWork.TargetContrastCd == 60)
            {
                // ���_�R�[�h
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // BL�R�[�h
                if (campaignTargetWork.BLGoodsCode != 0)
                {
                    retstring += "AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                }
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PartsPosCodeUWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        /// </remarks>
        private CampaignTargetWork CopyToCampaignTargetWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignTargetWork campaignTargetWork = new CampaignTargetWork();

            this.CopyToCampaignTargetWorkFromReader(ref myReader, ref campaignTargetWork);

            return campaignTargetWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="campaignTargetWork">PartsPosCodeUWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        /// </remarks>
        private void CopyToCampaignTargetWorkFromReader(ref SqlDataReader myReader, ref CampaignTargetWork campaignTargetWork)
        {
            if (myReader != null && campaignTargetWork != null)
            {
                # region �N���X�֊i�[
                campaignTargetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                campaignTargetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                campaignTargetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                campaignTargetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                campaignTargetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                campaignTargetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                campaignTargetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                campaignTargetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                campaignTargetWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));
                campaignTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
                campaignTargetWork.EmployeeDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYEEDIVCDRF"));
                campaignTargetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                campaignTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                campaignTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                campaignTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                campaignTargetWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                campaignTargetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                campaignTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                campaignTargetWork.SalesTargetMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY1RF"));
                campaignTargetWork.SalesTargetMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY2RF"));
                campaignTargetWork.SalesTargetMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY3RF"));
                campaignTargetWork.SalesTargetMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY4RF"));
                campaignTargetWork.SalesTargetMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY5RF"));
                campaignTargetWork.SalesTargetMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY6RF"));
                campaignTargetWork.SalesTargetMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY7RF"));
                campaignTargetWork.SalesTargetMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY8RF"));
                campaignTargetWork.SalesTargetMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY9RF"));
                campaignTargetWork.SalesTargetMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY10RF"));
                campaignTargetWork.SalesTargetMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY11RF"));
                campaignTargetWork.SalesTargetMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY12RF"));
                campaignTargetWork.MonthlySalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETRF"));
                campaignTargetWork.TermSalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETRF"));
                campaignTargetWork.SalesTargetProfit1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT1RF"));
                campaignTargetWork.SalesTargetProfit2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT2RF"));
                campaignTargetWork.SalesTargetProfit3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT3RF"));
                campaignTargetWork.SalesTargetProfit4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT4RF"));
                campaignTargetWork.SalesTargetProfit5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT5RF"));
                campaignTargetWork.SalesTargetProfit6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT6RF"));
                campaignTargetWork.SalesTargetProfit7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT7RF"));
                campaignTargetWork.SalesTargetProfit8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT8RF"));
                campaignTargetWork.SalesTargetProfit9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT9RF"));
                campaignTargetWork.SalesTargetProfit10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT10RF"));
                campaignTargetWork.SalesTargetProfit11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT11RF"));
                campaignTargetWork.SalesTargetProfit12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT12RF"));
                campaignTargetWork.MonthlySalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETPROFITRF"));
                campaignTargetWork.TermSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETPROFITRF"));
                campaignTargetWork.SalesTargetCount1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT1RF"));
                campaignTargetWork.SalesTargetCount2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT2RF"));
                campaignTargetWork.SalesTargetCount3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT3RF"));
                campaignTargetWork.SalesTargetCount4 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT4RF"));
                campaignTargetWork.SalesTargetCount5 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT5RF"));
                campaignTargetWork.SalesTargetCount6 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT6RF"));
                campaignTargetWork.SalesTargetCount7 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT7RF"));
                campaignTargetWork.SalesTargetCount8 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT8RF"));
                campaignTargetWork.SalesTargetCount9 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT9RF"));
                campaignTargetWork.SalesTargetCount10 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT10RF"));
                campaignTargetWork.SalesTargetCount11 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT11RF"));
                campaignTargetWork.SalesTargetCount12 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT12RF"));
                campaignTargetWork.MonthlySalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETCOUNTRF"));
                campaignTargetWork.TermSalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TERMSALESTARGETCOUNTRF"));
                # endregion
            }
        }
        # endregion
    }
}

