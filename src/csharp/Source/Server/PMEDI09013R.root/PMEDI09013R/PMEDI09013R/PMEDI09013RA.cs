//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : EDI�A�g�ݒ�}�X�^�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : EDI�A�g�ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11370098-00  �쐬�S�� : ���O
// �� �� ��  2017/11/16   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// EDI�A�g�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : EDI�A�g�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/11/16</br>
    /// </remarks>
    [Serializable]
    public class EDICooperatStDB : RemoteDB, IEDICooperatStDB
    {
        /// <summary>
        /// EDI�A�g�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public EDICooperatStDB()
            : base("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork", "EDICOOPERATSTRF")
        {

        }

        # region [Search]
        /// <summary>
        ///EDI�A�g�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="paraObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="refObj">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI�A�g�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public int Search(object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out object refObj)
        {
            SqlConnection sqlConnection = null;
            refObj = null;
            ArrayList eDICooperatStList = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�l�N�V��������
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    EDICooperatStWork paraWork = (EDICooperatStWork)paraObj;
                    // EDI�A�g�ݒ�}�X�^�Ώێ擾
                    status = SearchProc(paraWork, readMode, logicalMode, out eDICooperatStList, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        refObj = (object)eDICooperatStList;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.Search Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        /// <summary>
        ///EDI�A�g�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="paraWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="eDICooperatStList">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI�A�g�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        private int SearchProc(EDICooperatStWork paraWork, int readMode, ConstantManagement.LogicalMode logicalMode, out ArrayList eDICooperatStList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            eDICooperatStList = new ArrayList();
            SqlCommand sqlCommand = null;
            using (sqlCommand = new SqlCommand("", sqlConnection))
             {
                 try
                 {
                     StringBuilder sqlText = new StringBuilder();
                     # region [SELECT��]
                     sqlText.AppendLine(" SELECT ");
                     sqlText.AppendLine(" CREATEDATETIMERF, ");      // �쐬����
                     sqlText.AppendLine(" ENTERPRISECODERF, ");      // ��ƃR�[�h
                     sqlText.AppendLine(" FILEHEADERGUIDRF, ");      // GUID
                     sqlText.AppendLine(" UPDEMPLOYEECODERF, ");     // �X�V�]�ƈ��R�[�h
                     sqlText.AppendLine(" UPDASSEMBLYID1RF, ");      // �X�V�A�Z���u��ID1
                     sqlText.AppendLine(" UPDASSEMBLYID2RF, ");      // �X�V�A�Z���u��ID2
                     sqlText.AppendLine(" UPDATEDATETIMERF, ");      // �X�V����
                     sqlText.AppendLine(" LOGICALDELETECODERF, ");   // �_���폜�敪
                     sqlText.AppendLine(" SECTIONCODERF, ");         // ���_�R�[�h
                     sqlText.AppendLine(" CUSTOMERCODERF, ");        // ���Ӑ�R�[�h
                     sqlText.AppendLine(" GOODSKINDCODERF, ");       // ���i����
                     sqlText.AppendLine(" COOPERATOFFICECODERF, ");  // �A�g���Ə��R�[�h
                     sqlText.AppendLine(" COOPERATCUSTCODERF,");     // �A�g���Ӑ�R�[�h
                     sqlText.AppendLine(" TRADCOMPCDRF, ");          // ���i���R�[�h
                     sqlText.AppendLine(" TRADCOMPNAMERF, ");        // ���i������
                     sqlText.AppendLine(" GOODSCODERF, ");           // ���i�R�[�h
                     sqlText.AppendLine(" INCREASEBLGOODSCODERF, ");    // �l��BL���i�R�[�h
                     sqlText.AppendLine(" DISCOUNTBLGOODSCODERF ");    // �l��BL���i�R�[�h
                     sqlText.AppendLine(" FROM EDICOOPERATSTRF WITH (READUNCOMMITTED) ");        //EDI�A�g�ݒ�}�X�^
                     sqlText.AppendLine(MakeWhereString(ref sqlCommand, paraWork, logicalMode));
                     # endregion

                     sqlCommand.CommandText = sqlText.ToString();
                     // �N�G�����s���̃^�C���A�E�g���Ԃ�3600�b�ɐݒ肷��
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            EDICooperatStWork eDICooperatStWork = new EDICooperatStWork();
                            eDICooperatStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            eDICooperatStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            eDICooperatStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            eDICooperatStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                            eDICooperatStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                            eDICooperatStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                            eDICooperatStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                            eDICooperatStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            eDICooperatStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                            eDICooperatStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                            eDICooperatStWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                            eDICooperatStWork.CooperatOfficeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COOPERATOFFICECODERF"));
                            eDICooperatStWork.CooperatCustCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COOPERATCUSTCODERF"));
                            eDICooperatStWork.TradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPCDRF"));
                            eDICooperatStWork.TradCompName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPNAMERF"));
                            eDICooperatStWork.GoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCODERF"));
                            eDICooperatStWork.IncreaseBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INCREASEBLGOODSCODERF"));
                            eDICooperatStWork.DiscountBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISCOUNTBLGOODSCODERF"));
                            eDICooperatStList.Add(eDICooperatStWork);
                        }

                        // �������ʂ�����ꍇ
                        if (eDICooperatStList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }

                 }
                 catch (SqlException ex)
                 {
                     // ���N���X�ɗ�O��n���ď������Ă��炤
                     status = base.WriteSQLErrorLog(ex);
                 }
                 catch (Exception ex)
                 {
                     status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                     base.WriteErrorLog(ex, "EDICooperatStDB.SearchProc Exception=" + ex.Message, status);
                 }
             }
             return status;
         }

        # endregion

        # region [Delete]
        /// <summary>
        /// EDI�A�g�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">EDICooperatStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI�A�g�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public int Delete(object parabyte)
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�l�N�V��������
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    EDICooperatStWork eDICooperatStWork = parabyte as EDICooperatStWork;
                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    // EDI�A�g�ݒ�}�X�^�Ώە����폜
                    status = this.DeleteProc(eDICooperatStWork, ref sqlConnection, ref sqlTransaction);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.Delete Exception=" + ex.Message, status);
                }
                finally
                {
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

                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="eDICooperatStWork">EDI�A�g�ݒ�}�X�^���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI�A�g�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        private int DeleteProc(EDICooperatStWork eDICooperatStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" UPDATEDATETIMERF ");
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" EDICOOPERATSTRF");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                    sqlText.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                    #endregion
                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (updateDateTime != eDICooperatStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        StringBuilder sqlTextDel = new StringBuilder();
                        #region
                        sqlTextDel.AppendLine(" DELETE ");
                        sqlTextDel.AppendLine(" FROM ");
                        sqlTextDel.AppendLine(" EDICOOPERATSTRF");
                        sqlTextDel.AppendLine(" WHERE ");
                        sqlTextDel.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                        sqlTextDel.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                        sqlTextDel.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                        #endregion
                        sqlCommand.CommandText = sqlTextDel.ToString();

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);
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
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                }
                catch (SqlException ex)
                {
                    // ���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.DeleteProc Exception=" + ex.Message, status);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (myReader.IsClosed == false)
                        {
                            myReader.Close();
                        }
                    }
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }
            return status;
        }
        # endregion

        #region [write]
        /// <summary>
        /// EDI�A�g�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="eDICooperatStObj">EDI�A�g�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI�A�g�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public int Write(ref object eDICooperatStObj)
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�l�N�V��������
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    EDICooperatStWork eDICooperatStWork = (EDICooperatStWork)eDICooperatStObj;

                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    // EDI�A�g�ݒ�}�X�^�f�[�^�o�^
                    status = WriteProc(ref eDICooperatStWork, ref sqlConnection, ref sqlTransaction);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.Write Exception=" + ex.Message, status);
                }
                finally
                {
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

                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="eDICooperatStWork">�ǉ��E�X�V����EDI�A�g�ݒ�}�X�^���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDICooperatStWork �Ɋi�[����Ă���EDI�A�g�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        private int WriteProc(ref EDICooperatStWork eDICooperatStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (eDICooperatStWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" UPDATEDATETIMERF ");
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" EDICOOPERATSTRF");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                    sqlText.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                    #endregion
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (updateDateTime != eDICooperatStWork.UpdateDateTime)
                        {
                            if (eDICooperatStWork.UpdateDateTime == DateTime.MinValue)
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

                        StringBuilder sqlTextUp = new StringBuilder();
                        #region
                        sqlTextUp.AppendLine(" UPDATE ");
                        sqlTextUp.AppendLine(" EDICOOPERATSTRF");
                        sqlTextUp.AppendLine(" SET");
                        sqlTextUp.AppendLine(" CREATEDATETIMERF=@CREATEDATETIME");
                        sqlTextUp.AppendLine(" , UPDATEDATETIMERF=@UPDATEDATETIME");
                        sqlTextUp.AppendLine(" , ENTERPRISECODERF=@ENTERPRISECODE");
                        sqlTextUp.AppendLine(" , FILEHEADERGUIDRF=@FILEHEADERGUID");
                        sqlTextUp.AppendLine(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE");
                        sqlTextUp.AppendLine(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1");
                        sqlTextUp.AppendLine(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2");
                        sqlTextUp.AppendLine(" , LOGICALDELETECODERF=@LOGICALDELETECODE");
                        sqlTextUp.AppendLine(" , SECTIONCODERF=@SECTIONCODE");
                        sqlTextUp.AppendLine(" , CUSTOMERCODERF=@CUSTOMERCODE");
                        sqlTextUp.AppendLine(" , GOODSKINDCODERF=@GOODSKINDCODE");
                        sqlTextUp.AppendLine(" , COOPERATOFFICECODERF=@COOPERATOFFICECODE");
                        sqlTextUp.AppendLine(" , COOPERATCUSTCODERF=@COOPERATCUSTCODE");
                        sqlTextUp.AppendLine(" , TRADCOMPCDRF=@TRADCOMPCD");
                        sqlTextUp.AppendLine(" , TRADCOMPNAMERF=@TRADCOMPNAME");
                        sqlTextUp.AppendLine(" , GOODSCODERF=@GOODSCODE");
                        sqlTextUp.AppendLine(" , INCREASEBLGOODSCODERF=@INCREASEBLGOODSCODE");
                        sqlTextUp.AppendLine(" , DISCOUNTBLGOODSCODERF=@DISCOUNTBLGOODSCODE");
                        sqlTextUp.AppendLine(" WHERE ");
                        sqlTextUp.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                        sqlTextUp.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                        sqlTextUp.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                        #endregion
                        sqlCommand.CommandText = sqlTextUp.ToString();

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)eDICooperatStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (eDICooperatStWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        StringBuilder sqlTextIns = new StringBuilder();
                        #region
                        sqlTextIns.AppendLine(" INSERT INTO ");
                        sqlTextIns.AppendLine(" EDICOOPERATSTRF");
                        sqlTextIns.AppendLine(" (CREATEDATETIMERF");
                        sqlTextIns.AppendLine(" , UPDATEDATETIMERF");
                        sqlTextIns.AppendLine(" , ENTERPRISECODERF");
                        sqlTextIns.AppendLine(" , FILEHEADERGUIDRF");
                        sqlTextIns.AppendLine(" , UPDEMPLOYEECODERF");
                        sqlTextIns.AppendLine(" , UPDASSEMBLYID1RF");
                        sqlTextIns.AppendLine(" , UPDASSEMBLYID2RF");
                        sqlTextIns.AppendLine(" , LOGICALDELETECODERF");
                        sqlTextIns.AppendLine(" , SECTIONCODERF");
                        sqlTextIns.AppendLine(" , CUSTOMERCODERF");
                        sqlTextIns.AppendLine(" , GOODSKINDCODERF");
                        sqlTextIns.AppendLine(" , COOPERATOFFICECODERF");
                        sqlTextIns.AppendLine(" , COOPERATCUSTCODERF");
                        sqlTextIns.AppendLine(" , TRADCOMPCDRF");
                        sqlTextIns.AppendLine(" , TRADCOMPNAMERF");
                        sqlTextIns.AppendLine(" , GOODSCODERF");
                        sqlTextIns.AppendLine(" , INCREASEBLGOODSCODERF");
                        sqlTextIns.AppendLine(" , DISCOUNTBLGOODSCODERF");
                        sqlTextIns.AppendLine(" ) VALUES (");
                        sqlTextIns.AppendLine(" @CREATEDATETIME");
                        sqlTextIns.AppendLine(" , @UPDATEDATETIME");
                        sqlTextIns.AppendLine(" , @ENTERPRISECODE");
                        sqlTextIns.AppendLine(" , @FILEHEADERGUID");
                        sqlTextIns.AppendLine(" , @UPDEMPLOYEECODE");
                        sqlTextIns.AppendLine(" , @UPDASSEMBLYID1");
                        sqlTextIns.AppendLine(" , @UPDASSEMBLYID2");
                        sqlTextIns.AppendLine(" , @LOGICALDELETECODE");
                        sqlTextIns.AppendLine(" , @SECTIONCODE");
                        sqlTextIns.AppendLine(" , @CUSTOMERCODE");
                        sqlTextIns.AppendLine(" , @GOODSKINDCODE");
                        sqlTextIns.AppendLine(" , @COOPERATOFFICECODE");
                        sqlTextIns.AppendLine(" , @COOPERATCUSTCODE");
                        sqlTextIns.AppendLine(" , @TRADCOMPCD");
                        sqlTextIns.AppendLine(" , @TRADCOMPNAME");
                        sqlTextIns.AppendLine(" , @GOODSCODE");
                        sqlTextIns.AppendLine(" , @INCREASEBLGOODSCODE");
                        sqlTextIns.AppendLine(" , @DISCOUNTBLGOODSCODE )");
                        #endregion
                        sqlCommand.CommandText = sqlTextIns.ToString();
                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)eDICooperatStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                    SqlParameter paraCooperatOfficeCode = sqlCommand.Parameters.Add("@COOPERATOFFICECODE", SqlDbType.NVarChar);
                    SqlParameter paraCooperatCustCode = sqlCommand.Parameters.Add("@COOPERATCUSTCODE", SqlDbType.NVarChar);
                    SqlParameter paraTradCompCd = sqlCommand.Parameters.Add("@TRADCOMPCD", SqlDbType.NVarChar);
                    SqlParameter paraTradCompName = sqlCommand.Parameters.Add("@TRADCOMPNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsCode = sqlCommand.Parameters.Add("@GOODSCODE", SqlDbType.NVarChar);
                    SqlParameter paraIncreaseBLGoodsCode = sqlCommand.Parameters.Add("@INCREASEBLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraDiscountBLGoodsCode = sqlCommand.Parameters.Add("@DISCOUNTBLGOODSCODE", SqlDbType.Int);

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDICooperatStWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDICooperatStWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(eDICooperatStWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);
                    paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.GoodsKindCode);
                    paraCooperatOfficeCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.CooperatOfficeCode);
                    paraCooperatCustCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.CooperatCustCode);
                    paraTradCompCd.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.TradCompCd);
                    paraTradCompName.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.TradCompName);
                    paraGoodsCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.GoodsCode);
                    paraIncreaseBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.IncreaseBLGoodsCode);
                    paraDiscountBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.DiscountBLGoodsCode);
                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "EDICooperatStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "EDICooperatStDB.WriteProc Exception=" + ex.Message, status);
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

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// EDI�A�g�ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="eDICooperatStObj">�_���폜����EDI�A�g�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : EDI�A�g�ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        public int LogicalDelete(ref object eDICooperatStObj)
        {
            return this.LogicalDeleteProc(ref eDICooperatStObj, 0);
        }

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="eDICooperatStObj">�_���폜����������EDI�A�g�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :EDI�A�g�ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        public int RevivalLogicalDelete(ref object eDICooperatStObj)
        {
            return this.LogicalDeleteProc(ref eDICooperatStObj, 1);
        }

        /// <summary>
        ///EDI�A�g�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="eDICooperatStObj">�_���폜�𑀍삷��EDI�A�g�ݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : EDI�A�g�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        private int LogicalDeleteProc(ref object eDICooperatStObj, int procMode)
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�l�N�V��������
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    EDICooperatStWork paraList = eDICooperatStObj as EDICooperatStWork;
                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    // EDI�A�g�ݒ�}�X�^�Ώۘ_���폜
                    status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
                    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                    eDICooperatStObj = paraList;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.LogicalDeleteProc Exception=" + ex.Message, status);
                }
                finally
                {
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

                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        ///EDI�A�g�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="eDICooperatStWork">�_���폜�𑀍삷��EDI�A�g�ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : EDI�A�g�ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        private int LogicalDeleteProc(ref EDICooperatStWork eDICooperatStWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            int logicalDelCd = 0;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" UPDATEDATETIMERF ");
                    sqlText.AppendLine(" , LOGICALDELETECODERF ");
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" EDICOOPERATSTRF");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                    sqlText.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                    #endregion
                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (updateDateTime != eDICooperatStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        StringBuilder sqlTextUpd = new StringBuilder();
                        #region
                        sqlTextUpd.AppendLine(" UPDATE ");
                        sqlTextUpd.AppendLine(" EDICOOPERATSTRF");
                        sqlTextUpd.AppendLine(" SET ");
                        sqlTextUpd.AppendLine(" UPDATEDATETIMERF=@UPDATEDATETIME");
                        sqlTextUpd.AppendLine(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE");
                        sqlTextUpd.AppendLine(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1");
                        sqlTextUpd.AppendLine(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2");
                        sqlTextUpd.AppendLine(" , LOGICALDELETECODERF=@LOGICALDELETECODE");
                        sqlTextUpd.AppendLine(" WHERE ");
                        sqlTextUpd.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                        sqlTextUpd.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                        sqlTextUpd.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                        #endregion
                        sqlCommand.CommandText = sqlTextUpd.ToString();

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)eDICooperatStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    // �_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // ���ɍ폜�ς݂̏ꍇ����
                            return status;
                        }
                        else if (logicalDelCd == 0) eDICooperatStWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                        else eDICooperatStWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            eDICooperatStWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDICooperatStWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                }
                catch (SqlException ex)
                {
                    // ���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.DeleteProc Exception=" + ex.Message, status);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (myReader.IsClosed == false)
                        {
                            myReader.Close();
                        }
                    }
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }
            return status;
        }
        #endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, EDICooperatStWork paraWork, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder SqlText = new StringBuilder();
            SqlText.AppendLine("WHERE ");

            // ��ƃR�[�h
            SqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

            // �_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                SqlText.AppendLine(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                SqlText.AppendLine(" AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE");
            }

            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            SqlText.AppendLine(" ORDER BY SECTIONCODERF, CUSTOMERCODERF");

            return SqlText.ToString();
        }

        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }
        # endregion
    }
}
