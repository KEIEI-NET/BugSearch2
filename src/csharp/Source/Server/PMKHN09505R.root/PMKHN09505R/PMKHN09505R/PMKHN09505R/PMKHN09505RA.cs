//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi�s�ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �C �� ��  2010/04/06  �C�����e : ���_���}�X�^�������̃L�[�C��
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
using Broadleaf.Library.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ԕi�s�ݒ菈��READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi�s�ݒ菈��READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    [Serializable]
    public class GoodsNotReturnProcDB : RemoteDB, IGoodsNotReturnProcDB
    {

        # region �� Constructor
        /// <summary>
        /// �ԕi�s�ݒ菈��READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ԕi�s�ݒ菈��READ�̎��f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public GoodsNotReturnProcDB()
        {
        }
        #endregion

        #region ���ԕi�s�ݒ�̉�ʌ�������

        /// <summary>
        /// �ԕi�s�ݒ�̉�ʌ�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="goodsNotReturnList">�����p�����[�^</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԕi�s�ݒ��ʌ������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int ReadDBData(string enterpriseCodes, string salesSlipNum, out ArrayList goodsNotReturnList, out string retMessage)
        {
            return ReadDBDataProc(enterpriseCodes, salesSlipNum, out goodsNotReturnList, out retMessage);
        }

        /// <summary>
        /// �ԕi�s�ݒ�̉�ʌ�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="goodsNotReturnList">�����p�����[�^</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԕi�s�ݒ��ʌ������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int ReadDBDataProc(string enterpriseCodes, string salesSlipNum, out ArrayList goodsNotReturnList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMessage = string.Empty;
            goodsNotReturnList = new ArrayList();
            GoodsNotReturnWork goodsNotReturnWork = null;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
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
                sqlStr = " SELECT SALESSLIPRF.CUSTOMERSNMRF, SALESSLIPRF.RESULTSADDUPSECCDRF, SALESSLIPRF.LOGICALDELETECODERF, SALESDETAILRF.LOGICALDELETECODERF AS DTLLOGICALDELETECODERF, SALESSLIPRF.SECTIONCODERF, SALESSLIPRF.CUSTOMERCODERF, "
                + " SALESSLIPRF.CUSTOMERNAMERF, SALESSLIPRF.SALESDATERF, SALESSLIPRF.SALESSLIPCDRF, SALESSLIPRF.ACPTANODRSTATUSRF, "
                + " SECINFOSETRF.SECTIONGUIDENMRF, SALESDETAILRF.SALESSLIPCDDTLRF, SALESDETAILRF.SALESSLIPDTLNUMRF, SALESDETAILRF.GOODSNORF, SALESDETAILRF.GOODSNORF, "
                + " SALESDETAILRF.GOODSNAMERF, SALESDETAILRF.MAKERNAMERF, SALESDETAILRF.SHIPMENTCNTRF, "
                + " SALESDETAILRF.ACCEPTANORDERCNTRF, SALESDETAILRF.ACPTANODRADJUSTCNTRF, "
                + " SALESDETAILRF.ACPTANODRREMAINCNTRF, RETURNUPPERSTRF.RETUPPERCNTRF, RETURNUPPERSTRF.UPDATEDATETIMERF "
                + " FROM SALESSLIPRF WITH (READUNCOMMITTED) "
                + " INNER JOIN SALESDETAILRF WITH (READUNCOMMITTED) ON ( "
                + " SALESSLIPRF.ACPTANODRSTATUSRF = SALESDETAILRF.ACPTANODRSTATUSRF "
                + " AND SALESSLIPRF.ENTERPRISECODERF = SALESDETAILRF.ENTERPRISECODERF "
                + " AND SALESSLIPRF.SALESSLIPNUMRF = SALESDETAILRF.SALESSLIPNUMRF) "
                + " LEFT JOIN SECINFOSETRF WITH (READUNCOMMITTED) ON ( "
                + " SECINFOSETRF.LOGICALDELETECODERF = 0 "
                // -- ADD 2010/04/06 ------------------->>>
                + " AND SECINFOSETRF.ENTERPRISECODERF = SALESSLIPRF.ENTERPRISECODERF "
                // -- ADD 2010/04/06 -------------------<<<
                + " AND SECINFOSETRF.SECTIONCODERF = SALESSLIPRF.RESULTSADDUPSECCDRF ) "
                + " LEFT JOIN RETURNUPPERSTRF WITH (READUNCOMMITTED) ON ( "
                + " RETURNUPPERSTRF.LOGICALDELETECODERF = 0 "
                + " AND SALESDETAILRF.ENTERPRISECODERF = RETURNUPPERSTRF.ENTERPRISECODERF "
                + " AND SALESDETAILRF.ACPTANODRSTATUSRF = RETURNUPPERSTRF.ACPTANODRSTATUSRF "
                + " AND SALESDETAILRF.SALESSLIPDTLNUMRF = RETURNUPPERSTRF.SALESSLIPDTLNUMRF) "
                + " WHERE "
                + " SALESSLIPRF.DEBITNOTEDIVRF = 0 "
                + " AND SALESSLIPRF.ENTERPRISECODERF = @FINDENTERPRISECODERF "
                + " AND SALESSLIPRF.SALESSLIPNUMRF = @FINDSALESSLIPNUMRF "
                + " AND SALESSLIPRF.ACPTANODRSTATUSRF = @ACPTANODRSTATUS ";

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUMRF", SqlDbType.NChar);
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipNum);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);

                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsNotReturnWork = new GoodsNotReturnWork();
                    goodsNotReturnWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    goodsNotReturnWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsNotReturnWork.DtlLogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLLOGICALDELETECODERF"));
                    goodsNotReturnWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    goodsNotReturnWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    goodsNotReturnWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    goodsNotReturnWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                    goodsNotReturnWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    goodsNotReturnWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    goodsNotReturnWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    goodsNotReturnWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    goodsNotReturnWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsNotReturnWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsNotReturnWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    goodsNotReturnWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    goodsNotReturnWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    goodsNotReturnWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    goodsNotReturnWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));
                    goodsNotReturnWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                    goodsNotReturnWork.RetUpperCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETUPPERCNTRF"));
                    
                    goodsNotReturnList.Add(goodsNotReturnWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.Search Exception=" + ex.Message);
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
        #endregion

        #region ���ԕi�s�ݒ�̉�ʍX�V����
        /// <summary>
        /// �ԕi�s�ݒ�̉�ʍX�V����
        /// </summary>
        /// <param name="goodsNotReturnList">�X�V�p�����[�^</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԕi�s�ݒ��ʍX�V���s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int UpdateReturnUpper(ref ArrayList goodsNotReturnList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();



#if DEBUG
                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                string retSql = string.Empty;
                DateTime updateTime = new DateTime();

                // �X�V�w�b�_���
                ReturnUpperStWork returnUpperStWork = new ReturnUpperStWork();
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)returnUpperStWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                // �o�^�w�b�_���
                ReturnUpperStWork ReturnInsertStWork = new ReturnUpperStWork();
                object objInsert = (object)this;
                IFileHeader insertIf = (IFileHeader)ReturnInsertStWork;
                FileHeader fileInsert = new FileHeader(objInsert);
                fileInsert.SetInsertHeader(ref insertIf, objInsert);

                foreach (GoodsNotReturnWork goodsNotReturnWork in goodsNotReturnList) 
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �ԕi����������͂̏ꍇ�A�X�V���Ȃ�
                        if (goodsNotReturnWork.RetUpperCnt == -1)
                        {
                            continue;
                        }
                        // ������x�ԕi����ݒ�}�X�^�̍X�V������������
                        status = SearchReturnUpperSt(goodsNotReturnWork.EnterpriseCode, goodsNotReturnWork.AcptAnOdrStatus,
                            goodsNotReturnWork.SalesSlipDtlNum, ref sqlConnection, ref sqlTransaction, ref sqlCommand,
                            out retMessage, out updateTime);


                        // �ԕi��������߂ōX�V�̏ꍇ�A�V�K����
                        if (goodsNotReturnWork.UpdateDateTime == DateTime.MinValue)
                        {
                            // ���ɑ��[�����X�V����Ă��܂��B
                            //status = SearchReturnUpperStCount(goodsNotReturnWork.EnterpriseCode, goodsNotReturnWork.AcptAnOdrStatus,
                            //    goodsNotReturnWork.SalesSlipDtlNum, ref sqlConnection, ref sqlTransaction, ref sqlCommand,
                            //    out retMessage);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                status = InsertReturnUpperSt(goodsNotReturnWork, ReturnInsertStWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand, out retMessage);
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                            else
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                        }
                        else
                        {
                            // �����G���[�̏ꍇ�A���[���o�b�N����
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            // �������ʂ��Ȃ��̏ꍇ�A���ɑ��[�����폜����Ă��܂��B
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            }
                            // �������ʂ̍X�V�����Ə����������ʂ̍X�V�������Ⴂ�ꍇ�A���ɑ��[�����X�V����Ă��܂��B
                            if (updateTime != goodsNotReturnWork.UpdateDateTime)
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                            // �G���[���Ȃ��̏ꍇ�A�X�V����B
                            status = UpdateReturnUpperSt(goodsNotReturnWork, returnUpperStWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                    }
                }
                // �G���[���Ȃ��̏ꍇ�A�R�~�b�g����B
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();

                }
                // �G���[������̏ꍇ�A���[���o�b�N����B
                else
                {
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                // �G���[������̏ꍇ�A���[���o�b�N����B
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.ShipmentDirections Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                // �G���[������̏ꍇ�A���[���o�b�N����B
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + e.Message);
                retMessage = e.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
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

        #region ���ԕi�s�ݒ�̉�ʒǉ�����
        /// <summary>
        /// �ԕi�s�ݒ�̉�ʒǉ�����
        /// </summary>
        /// <param name="goodsNotReturnWork">�ǉ��p�����[�^</param>
        /// <param name="ReturnInsertStWork">���ʈ�p�����[�^</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">sqlCommand�I�u�W�F�N�g</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԕi�s�ݒ��ʒǉ����s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int InsertReturnUpperSt(GoodsNotReturnWork goodsNotReturnWork, ReturnUpperStWork ReturnInsertStWork,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            retMessage = string.Empty;
            string retSql = string.Empty;
            try
            {

                retSql = "INSERT INTO RETURNUPPERSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, SALESSLIPDTLNUMRF, RETUPPERCNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACPTANODRSTATUS, @SALESSLIPDTLNUM, @RETUPPERCNT)";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@RETUPPERCNT", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(ReturnInsertStWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(ReturnInsertStWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ReturnInsertStWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(ReturnInsertStWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(ReturnInsertStWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(ReturnInsertStWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(ReturnInsertStWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(ReturnInsertStWork.LogicalDeleteCode);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(goodsNotReturnWork.AcptAnOdrStatus);
                paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(goodsNotReturnWork.SalesSlipDtlNum);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetDouble(goodsNotReturnWork.RetUpperCnt);

                // �ԕi����ݒ�}�X�^�pSQL
                sqlCommand.CommandText = retSql;
                // �ԕi����ݒ�}�X�^��o�^����
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.ShipmentDataAllSearch Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region ���ԕi����ݒ�}�X�^�̍X�V�����̎擾����
        /// <summary>
        /// �ԕi����ݒ�}�X�^�̍X�V�����̎擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipDtlNum">���㖾�גʔ�</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">sqlCommand�I�u�W�F�N�g</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <param name="updateDateTime">�X�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԕi����ݒ�}�X�^�̍X�V�����̎擾�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchReturnUpperSt(string enterpriseCode, Int32 acptAnOdrStatus, Int64 salesSlipDtlNum,
                    ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    ref SqlCommand sqlCommand, out string retMessage, out DateTime updateDateTime)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            updateDateTime = new DateTime();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                retMessage = string.Empty;
                string sqlStr = string.Empty;

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, SALESSLIPDTLNUMRF, RETUPPERCNTRF FROM RETURNUPPERSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM";


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acptAnOdrStatus);
                findParaSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(salesSlipDtlNum);

                // �ԕi����ݒ�}�X�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.ShipmentDataAllSearch Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region ���ԕi����ݒ�}�X�^�̍X�V����
        /// <summary>
        /// �ԕi����ݒ�}�X�^�̍X�V����
        /// </summary>
        /// <param name="goodsNotReturnWork">�X�V�p�����[�^</param>
        /// <param name="returnUpperStWork">�X�V���ʈ�p�����[�^</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">sqlCommand�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԕi����ݒ�}�X�^�̍X�V�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int UpdateReturnUpperSt(GoodsNotReturnWork goodsNotReturnWork, ReturnUpperStWork returnUpperStWork,
                    ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            string retSql = string.Empty;

            retSql = "UPDATE RETURNUPPERSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , SALESSLIPDTLNUMRF=@SALESSLIPDTLNUM , RETUPPERCNTRF=@RETUPPERCNT WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM";

            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
            SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
            SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@RETUPPERCNT", SqlDbType.Int);

            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(returnUpperStWork.UpdateDateTime);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(returnUpperStWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(returnUpperStWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(returnUpperStWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(returnUpperStWork.LogicalDeleteCode);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(goodsNotReturnWork.AcptAnOdrStatus);
            paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(goodsNotReturnWork.SalesSlipDtlNum);
            paraDebitNoteDiv.Value = SqlDataMediator.SqlSetDouble(goodsNotReturnWork.RetUpperCnt);


            //Parameter�I�u�W�F�N�g�̍쐬(�����p)
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
            SqlParameter findParaSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNotReturnWork.EnterpriseCode);
            findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(goodsNotReturnWork.AcptAnOdrStatus);
            findParaSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(goodsNotReturnWork.SalesSlipDtlNum);

            // �ԕi����ݒ�}�X�^�pSQL
            sqlCommand.CommandText = retSql;
            // �ԕi����ݒ�}�X�^���X�V����
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
        #endregion
    }
}
