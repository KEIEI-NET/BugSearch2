//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/11  �C�����e : R�N���X��public Method��SQL�������ʖ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/28  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/01  �C�����e : Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine#8293 ���_�Ǘ��^�`�[���t���t���o����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/12/05  �C�����e : Redmine#8482 ���_�Ǘ��@�l���݂̂̓����f�[�^�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/12/06  �C�����e : Redmine#8293 ��ʂ̏I�����t�{�V�X�e�������d�l�̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : �e�c ���V
// �C �� ��  2014/02/20  �C�����e : �d�|�ꗗ��2292�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����f�[�^READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^���M����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class APDepsitMainDB : RemoteDB
    {
        /// <summary>
        /// �����f�[�^READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APDepsitMainDB()
        {
        }
        #region [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
// DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �����f�[�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="depsitMainArrList">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchDepsitMain(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList depsitMainArrList, out string retMessage)
        {
            return SearchDepsitMainProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  depsitMainArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �����f�[�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="depsitMainArrList">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchDepsitMainProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList depsitMainArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            depsitMainArrList = new ArrayList();
            APDepsitMainWork depsitMainWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, SALESSLIPNUMRF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, DEPOSITDATERF, ADDUPADATERF, DEPOSITTOTALRF, DEPOSITRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, AUTODEPOSITCDRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, DEPOSITINPUTAGENTCDRF, DEPOSITINPUTAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, CLAIMCODERF, CLAIMNAMERF, CLAIMNAME2RF, CLAIMSNMRF, OUTLINERF, BANKCODERF, BANKNAMERF FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // �����f�[�^�pSQL
				sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    depsitMainWork = new APDepsitMainWork();

                    depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                    depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                    depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                    depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                    depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    depsitMainWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                    depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
                    depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                    depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                    depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                    depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                    depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                    depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                    depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
                    depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
                    depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                    depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                    depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
                    depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
                    depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                    depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                    depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                    depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                    depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                    depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                    depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));

                    depsitMainArrList.Add(depsitMainWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
*/
        // DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �����f�[�^�X�V
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="depsitMainList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int UpdateDepsitMain(string enterPriseCode, ArrayList depsitMainList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateDepsitMainProc(enterPriseCode, depsitMainList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �����f�[�^�X�V
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="depsitMainList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int UpdateDepsitMainProc(string enterPriseCode, ArrayList depsitMainList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �S�ăf�[�^���폜����
            status = DeleteDepsitMain(enterPriseCode, depsitMainList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �o�^����
                status = InsertDepsitMain(enterPriseCode, depsitMainList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �����f�[�^�폜
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="depsitMainList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int DeleteDepsitMain(string enterPriseCode, ArrayList depsitMainList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteDepsitMainProc(enterPriseCode, depsitMainList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �����f�[�^�폜
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="depsitMainList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int DeleteDepsitMainProc(string enterPriseCode, ArrayList depsitMainList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APDepsitMainWork depsitMainWork in depsitMainList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaAcptAnOdrStatus.Value = depsitMainWork.AcptAnOdrStatus;
                findParaDepositSlipNo.Value = depsitMainWork.DepositSlipNo;

                sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // ���s
                sqlCommand.ExecuteNonQuery();
            }

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
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �����f�[�^�V�K
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="depsitMainList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int InsertDepsitMain(string enterPriseCode, ArrayList depsitMainList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertDepsitMainProc(enterPriseCode, depsitMainList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �����f�[�^�V�K
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="depsitMainList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int InsertDepsitMainProc(string enterPriseCode, ArrayList depsitMainList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APDepsitMainWork depsitMainWork in depsitMainList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO DEPSITMAINRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, SALESSLIPNUMRF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, DEPOSITDATERF, ADDUPADATERF, DEPOSITTOTALRF, DEPOSITRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, AUTODEPOSITCDRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, DEPOSITINPUTAGENTCDRF, DEPOSITINPUTAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, CLAIMCODERF, CLAIMNAMERF, CLAIMNAME2RF, CLAIMSNMRF, OUTLINERF, BANKCODERF, BANKNAMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACPTANODRSTATUS, @DEPOSITDEBITNOTECD, @DEPOSITSLIPNO, @SALESSLIPNUM, @INPUTDEPOSITSECCD, @ADDUPSECCODE, @UPDATESECCD, @SUBSECTIONCODE, @INPUTDAYRF, @DEPOSITDATE, @ADDUPADATE, @DEPOSITTOTAL, @DEPOSIT, @FEEDEPOSIT, @DISCOUNTDEPOSIT, @AUTODEPOSITCD, @DRAFTDRAWINGDATE, @DRAFTKIND, @DRAFTKINDNAME, @DRAFTDIVIDE, @DRAFTDIVIDENAME, @DRAFTNO, @DEPOSITALLOWANCE, @DEPOSITALWCBLNCE, @DEBITNOTELINKDEPONO, @LASTRECONCILEADDUPDT, @DEPOSITAGENTCODE, @DEPOSITAGENTNM, @DEPOSITINPUTAGENTCD, @DEPOSITINPUTAGENTNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @CLAIMCODE, @CLAIMNAME, @CLAIMNAME2, @CLAIMSNM, @OUTLINE, @BANKCODE, @BANKNAME)";

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
                SqlParameter paraDepositDebitNoteCd = sqlCommand.Parameters.Add("@DEPOSITDEBITNOTECD", SqlDbType.Int);
                SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAYRF", SqlDbType.Int);
                SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);
                SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                SqlParameter paraDepositTotal = sqlCommand.Parameters.Add("@DEPOSITTOTAL", SqlDbType.BigInt);
                SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                SqlParameter paraFeeDeposit = sqlCommand.Parameters.Add("@FEEDEPOSIT", SqlDbType.BigInt);
                SqlParameter paraDiscountDeposit = sqlCommand.Parameters.Add("@DISCOUNTDEPOSIT", SqlDbType.BigInt);
                SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                SqlParameter paraDebitNoteLinkDepoNo = sqlCommand.Parameters.Add("@DEBITNOTELINKDEPONO", SqlDbType.Int);
                SqlParameter paraLastReconcileAddUpDt = sqlCommand.Parameters.Add("@LASTRECONCILEADDUPDT", SqlDbType.Int);
                SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                SqlParameter paraDepositInputAgentCd = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTCD", SqlDbType.NChar);
                SqlParameter paraDepositInputAgentNm = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTNM", SqlDbType.NVarChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitMainWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.LogicalDeleteCode);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);
                paraDepositDebitNoteCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositDebitNoteCd);
                paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depsitMainWork.SalesSlipNum);
                paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.InputDepositSecCd);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.AddUpSecCode);
                paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdateSecCd);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.SubSectionCode);
                paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.InputDay);
                paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DepositDate);
                paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.AddUpADate);
                paraDepositTotal.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositTotal);
                paraDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.Deposit);
                paraFeeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.FeeDeposit);
                paraDiscountDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DiscountDeposit);
                paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AutoDepositCd);
                paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftDrawingDate);
                paraDraftKind.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftKind);
                paraDraftKindName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftKindName);
                paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftDivide);
                paraDraftDivideName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftDivideName);
                paraDraftNo.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftNo);
                paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAllowance);
                paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAlwcBlnce);
                paraDebitNoteLinkDepoNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DebitNoteLinkDepoNo);
                paraLastReconcileAddUpDt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.LastReconcileAddUpDt);
                paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentCode);
                paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentNm);
                paraDepositInputAgentCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentCd);
                paraDepositInputAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentNm);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.CustomerCode);
                paraCustomerName.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName);
                paraCustomerName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName2);
                paraCustomerSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerSnm);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.ClaimCode);
                paraClaimName.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName);
                paraClaimName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName2);
                paraClaimSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimSnm);
                paraOutline.Value = SqlDataMediator.SqlSetString(depsitMainWork.Outline);
                paraBankCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.BankCode);
                paraBankName.Value = SqlDataMediator.SqlSetString(depsitMainWork.BankName);

                sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                sqlCommand.ExecuteNonQuery();
            }

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

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
		/// �����f�[�^�擾
		/// </summary>
		/// <param name="resultList">���ʃf�[�^</param>
		/// <param name="sendDataWork">��M�f�[�^</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <returns></returns>
		public int SearchSCM(out ArrayList resultList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchSCMProc(out  resultList, sendDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// �����f�[�^�擾
		/// </summary>
		/// <param name="resultList">���ʃf�[�^</param>
		/// <param name="sendDataWork">��M�f�[�^</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <returns></returns>
		private int SearchSCMProc(out ArrayList resultList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			resultList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

			StringBuilder sb = new StringBuilder();
			sb.Append(" SELECT G.CREATEDATETIMERF as G_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,G.UPDATEDATETIMERF as G_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,G.ENTERPRISECODERF as G_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,G.FILEHEADERGUIDRF as G_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,G.UPDEMPLOYEECODERF as G_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,G.UPDASSEMBLYID1RF as G_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,G.UPDASSEMBLYID2RF as G_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,G.LOGICALDELETECODERF as G_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,G.ACPTANODRSTATUSRF as G_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITDEBITNOTECDRF as G_DEPOSITDEBITNOTECDRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITSLIPNORF as G_DEPOSITSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,G.SALESSLIPNUMRF as G_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,G.INPUTDEPOSITSECCDRF as G_INPUTDEPOSITSECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,G.ADDUPSECCODERF as G_ADDUPSECCODERF ").Append(Environment.NewLine);
			sb.Append(" ,G.UPDATESECCDRF as G_UPDATESECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,G.SUBSECTIONCODERF as G_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,G.INPUTDAYRF as G_INPUTDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITDATERF as G_DEPOSITDATERF ").Append(Environment.NewLine);
			sb.Append(" ,G.ADDUPADATERF as G_ADDUPADATERF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITTOTALRF as G_DEPOSITTOTALRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITRF as G_DEPOSITRF ").Append(Environment.NewLine);
			sb.Append(" ,G.FEEDEPOSITRF as G_FEEDEPOSITRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DISCOUNTDEPOSITRF as G_DISCOUNTDEPOSITRF ").Append(Environment.NewLine);
			sb.Append(" ,G.AUTODEPOSITCDRF as G_AUTODEPOSITCDRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DRAFTDRAWINGDATERF as G_DRAFTDRAWINGDATERF ").Append(Environment.NewLine);
			sb.Append(" ,G.DRAFTKINDRF as G_DRAFTKINDRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DRAFTKINDNAMERF as G_DRAFTKINDNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,G.DRAFTDIVIDERF as G_DRAFTDIVIDERF ").Append(Environment.NewLine);
			sb.Append(" ,G.DRAFTDIVIDENAMERF as G_DRAFTDIVIDENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,G.DRAFTNORF as G_DRAFTNORF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITALLOWANCERF as G_DEPOSITALLOWANCERF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITALWCBLNCERF as G_DEPOSITALWCBLNCERF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEBITNOTELINKDEPONORF as G_DEBITNOTELINKDEPONORF ").Append(Environment.NewLine);
			sb.Append(" ,G.LASTRECONCILEADDUPDTRF as G_LASTRECONCILEADDUPDTRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITAGENTCODERF as G_DEPOSITAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITAGENTNMRF as G_DEPOSITAGENTNMRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITINPUTAGENTCDRF as G_DEPOSITINPUTAGENTCDRF ").Append(Environment.NewLine);
			sb.Append(" ,G.DEPOSITINPUTAGENTNMRF as G_DEPOSITINPUTAGENTNMRF ").Append(Environment.NewLine);
			sb.Append(" ,G.CUSTOMERCODERF as G_CUSTOMERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,G.CUSTOMERNAMERF as G_CUSTOMERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,G.CUSTOMERNAME2RF as G_CUSTOMERNAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,G.CUSTOMERSNMRF as G_CUSTOMERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,G.CLAIMCODERF as G_CLAIMCODERF ").Append(Environment.NewLine);
			sb.Append(" ,G.CLAIMNAMERF as G_CLAIMNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,G.CLAIMNAME2RF as G_CLAIMNAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,G.CLAIMSNMRF as G_CLAIMSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,G.OUTLINERF as G_OUTLINERF ").Append(Environment.NewLine);
			sb.Append(" ,G.BANKCODERF as G_BANKCODERF ").Append(Environment.NewLine);
			sb.Append(" ,G.BANKNAMERF  as G_BANKNAMERF  ").Append(Environment.NewLine);
			// �������׃f�[�^
			sb.Append(" ,H.CREATEDATETIMERF as H_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,H.UPDATEDATETIMERF as H_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,H.ENTERPRISECODERF as H_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,H.FILEHEADERGUIDRF as H_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,H.UPDEMPLOYEECODERF as H_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,H.UPDASSEMBLYID1RF as H_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,H.UPDASSEMBLYID2RF as H_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,H.LOGICALDELETECODERF as H_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,H.ACPTANODRSTATUSRF as H_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,H.DEPOSITSLIPNORF as H_DEPOSITSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,H.DEPOSITROWNORF as H_DEPOSITROWNORF ").Append(Environment.NewLine);
			sb.Append(" ,H.MONEYKINDCODERF as H_MONEYKINDCODERF ").Append(Environment.NewLine);
			sb.Append(" ,H.MONEYKINDNAMERF as H_MONEYKINDNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,H.MONEYKINDDIVRF as H_MONEYKINDDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,H.DEPOSITRF as H_DEPOSITRF ").Append(Environment.NewLine);
			sb.Append(" ,H.VALIDITYTERMRF  as H_VALIDITYTERMRF  ").Append(Environment.NewLine);

			sb.Append(" FROM DEPSITMAINRF G WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
			// �������׃f�[�^
			//sb.Append(" INNER JOIN DEPSITDTLRF H WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);  // DEL 2011/12/05
            sb.Append(" LEFT JOIN DEPSITDTLRF H WITH (READUNCOMMITTED)  ").Append(Environment.NewLine); // ADD 2011/12/05
			//	�����f�[�^.��ƃR�[�h�@���@�������׃f�[�^.��ƃR�[�h
			sb.Append(" ON G.ENTERPRISECODERF = H.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	�����f�[�^.�󒍃X�e�[�^�X�@���@�������׃f�[�^.�󒍃X�e�[�^�X
			sb.Append(" AND G.ACPTANODRSTATUSRF = H.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			//	�����f�[�^.�����`�[�ԍ��@���@�������׃f�[�^.�����`�[�ԍ�
			sb.Append(" AND G.DEPOSITSLIPNORF = H.DEPOSITSLIPNORF ").Append(Environment.NewLine);

            // ----- DEL 2011/11/01 xupz---------->>>>>
            ////	�������׃f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
            //sb.Append(" AND H.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_H ").Append(Environment.NewLine);
            ////	�������׃f�[�^.�X�V�����@���@�p�����[�^.�I�����t
            //sb.Append(" AND H.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_H ").Append(Environment.NewLine);
            // ----- DEL 2011/11/01 xupz----------<<<<<

            // ----- ADD 2011/11/01 xupz---------->>>>>
            //�f�[�^���M���o�����敪���u�����v�̏ꍇ
            if(sendDataWork.SndMesExtraCondDiv == 0)
            {
			//	�������׃f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
			sb.Append(" AND H.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_H ").Append(Environment.NewLine);
			//	�������׃f�[�^.�X�V�����@���@�p�����[�^.�I�����t
			sb.Append(" AND H.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_H ").Append(Environment.NewLine);
            }
            // ----- ADD 2011/11/01 xupz----------<<<<<

			//	�����f�[�^.�v�㋒�_�R�[�h�@���@�p�����[�^.���_�R�[�h
			sb.Append(" WHERE G.ADDUPSECCODERF=@FINDSECTIONCODE ").Append(Environment.NewLine);

            // ----- DEL 2011/11/01 xupz---------->>>>>
            ////	�����f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
            //sb.Append(" AND G.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_G ").Append(Environment.NewLine);
            ////	�����f�[�^.�X�V�����@���@�p�����[�^.�I�����t
            //sb.Append(" AND G.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_G ").Append(Environment.NewLine);
            // ----- DEL 2011/11/01 xupz----------<<<<<


            // ----- ADD 2011/11/01 xupz---------->>>>>
             //�f�[�^���M���o�����敪���u�����v�̏ꍇ
            if (sendDataWork.SndMesExtraCondDiv == 0)
            {
			//	�����f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
			sb.Append(" AND G.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_G ").Append(Environment.NewLine);
			//	�����f�[�^.�X�V�����@���@�p�����[�^.�I�����t
			sb.Append(" AND G.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_G ").Append(Environment.NewLine);
            }
            //�f�[�^���M���o�����敪���u�`�[���t�v�̏ꍇ
            else if (sendDataWork.SndMesExtraCondDiv == 1) 
            {
                //	�����f�[�^.�������t�@>=�@�p�����[�^.�J�n���t
                //sb.Append(" AND G.DEPOSITDATERF>=@FINDUPDATESTARTDATETIME_G ").Append(Environment.NewLine);  // DEL 2011/11/30
                ////	�����f�[�^.�������t�@���@�p�����[�^.�I�����t
                //sb.Append(" AND G.DEPOSITDATERF<=@FINDUPDATEENDDATETIME_G ").Append(Environment.NewLine);  // DEL 2011/11/30

                //	�����f�[�^.�������t�@>=�@�p�����[�^.�J�n���t
                sb.Append(" AND (( G.DEPOSITDATERF>=@FINDUPDATESTARTDATETIME_G ").Append(Environment.NewLine); // ADD 2011/11/30
                //	�����f�[�^.�������t�@���@�p�����[�^.�I�����t
                sb.Append(" AND G.DEPOSITDATERF<=@FINDUPDATEENDDATETIME_G ) ").Append(Environment.NewLine); // ADD 2011/11/30


                // ----- ADD 2011/11/30 tanh---------->>>>>
                // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                //sb.Append(" OR ( G.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                sb.Append(" OR ( G.UPDATEDATETIMERF>@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                sb.Append(" AND  G.UPDATEDATETIMERF<=@FINDENDTIMERF ").Append(Environment.NewLine);
                sb.Append(" AND  G.DEPOSITDATERF<=@FINDUPDATEENDDATETIME_G )) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<<
            }
            // ----- ADD K2011/11/01 xupz----------<<<<<

			sb.Append(" ORDER BY ").Append(Environment.NewLine);
			sb.Append(" G_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,G_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,G_DEPOSITSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,H_ACPTANODRSTATUSRF  ").Append(Environment.NewLine);
			sb.Append(" ,H_DEPOSITSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,H_DEPOSITROWNORF ").Append(Environment.NewLine);

			sqlText = sb.ToString();

			//Prameter�I�u�W�F�N�g�̍쐬
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_G = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_G", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_G = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_G", SqlDbType.BigInt);
			SqlParameter findParaUpdateStartDateTime_H = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_H", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_H = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_H", SqlDbType.BigInt);

			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaSectionCode.Value = sendDataWork.PmSectionCode;
			findParaUpdateStartDateTime_G.Value = sendDataWork.StartDateTime;
			findParaUpdateEndDateTime_G.Value = sendDataWork.EndDateTime;
			findParaUpdateStartDateTime_H.Value = sendDataWork.StartDateTime;
			findParaUpdateEndDateTime_H.Value = sendDataWork.EndDateTime;

            // ----- ADD 2011/11/30 tanh---------->>>>>
            //�f�[�^���M���o�����敪���u�`�[�敪�v�̏ꍇ
            if (sendDataWork.SndMesExtraCondDiv == 1)
            {
                SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                findParaSyncExecDate.Value = sendDataWork.SyncExecDate;
                SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                // DEL 2011/12/06 ----------- >>>>>>>>>>>>>>>
                //string endTimeStr = sendDataWork.EndDateTime.ToString();
                //if (endTimeStr.Length == 8)
                //{
                //    DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                //                                int.Parse(endTimeStr.Substring(4, 2)),
                //                                int.Parse(endTimeStr.Substring(6, 2)),
                //                                23, 59, 59);
                //    findParaEndTime.Value = endTime.Ticks;
                //}
                //else
                //{
                //    findParaEndTime.Value = DateTime.MinValue.Ticks;
                //}
                // DEL 2011/12/06 ----------- <<<<<<<<<<<<<<<
                findParaEndTime.Value = sendDataWork.EndDateTimeTicks; // ADD 2011/12/06
            }
            // ----- ADD 2011/11/30 tanh----------<<<<<

			// SQL��
			sqlCommand.CommandText = sqlText;
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            myReader = sqlCommand.ExecuteReader();

			ArrayList depsitMainList = new ArrayList();
			ArrayList depsitDtlList = new ArrayList();
			APDepsitDtlDB aPDepsitDtlDB = new APDepsitDtlDB();
			APDepsitMainWork tmpWorkG = new APDepsitMainWork();
			APDepsitDtlWork tmpWorkH = new APDepsitDtlWork();

			Dictionary<string, string> depsitMainDic = new Dictionary<string, string>();
			Dictionary<string, string> depsitDtlDic = new Dictionary<string, string>();

			while (myReader.Read())
			{
				// �����f�[�^
				tmpWorkG = this.CopyToDepsitMainWorkFromReaderSCM(ref myReader, "G_");
				string workG_key = tmpWorkG.EnterpriseCode + tmpWorkG.AcptAnOdrStatus.ToString() + tmpWorkG.DepositSlipNo.ToString();
				if (!string.Empty.Equals(tmpWorkG.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkG.AcptAnOdrStatus.ToString())
					&& !string.Empty.Equals(tmpWorkG.DepositSlipNo.ToString())
					&& !depsitMainDic.ContainsKey(workG_key))
				{
					depsitMainDic.Add(workG_key, workG_key);
					depsitMainList.Add(tmpWorkG);
				}
				// �������׃f�[�^
				tmpWorkH = aPDepsitDtlDB.CopyToDepsitDtlWorkFromReaderSCM(ref myReader, "H_");
				string workH_key = tmpWorkH.EnterpriseCode + tmpWorkH.AcptAnOdrStatus.ToString() 
					              + tmpWorkH.DepositSlipNo.ToString()+tmpWorkH.DepositRowNo.ToString();
				if (!string.Empty.Equals(tmpWorkH.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkH.AcptAnOdrStatus.ToString())
					&& !string.Empty.Equals(tmpWorkH.DepositSlipNo.ToString())
					&& !string.Empty.Equals(tmpWorkH.DepositRowNo.ToString())
					&& !depsitDtlDic.ContainsKey(workH_key))
				{
					depsitDtlDic.Add(workH_key, workH_key);
					depsitDtlList.Add(tmpWorkH);
				}
			}

			// �����v�ۃt���O
			if (sendDataWork.DoDepsitMainFlg)
			{
				resultList.Add(depsitMainList);
			}
			// �������הۃt���O
			if (sendDataWork.DoDepsitDtlFlg)
			{
				resultList.Add(depsitDtlList);
			}

			if (depsitMainList.Count > 0)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}

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
		/// <summary>
		/// �N���X�i�[���� Reader �� SupplierWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>�I�u�W�F�N�g</returns>
		private APDepsitMainWork CopyToDepsitMainWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			APDepsitMainWork depsitMainWork = new APDepsitMainWork();

			this.CopyToDepsitMainWorkFromReaderSCM(ref myReader, ref depsitMainWork, tableNm);

			return depsitMainWork;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� depsitMainWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="depsitMainWork">depsitMainWork �I�u�W�F�N�g</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToDepsitMainWorkFromReaderSCM(ref SqlDataReader myReader, ref APDepsitMainWork depsitMainWork, string tableNm)
		{
			if (myReader != null && depsitMainWork != null)
			{
				# region �N���X�֊i�[
				depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSRF"));
				depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEPOSITDEBITNOTECDRF"));
				depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEPOSITSLIPNORF"));
				depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPNUMRF"));
				depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INPUTDEPOSITSECCDRF"));
				depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDUPSECCODERF"));
				depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDATESECCDRF"));
				depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				depsitMainWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "INPUTDAYRF"));
				depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "DEPOSITDATERF"));
				depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ADDUPADATERF"));
				depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DEPOSITTOTALRF"));
				depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DEPOSITRF"));
				depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "FEEDEPOSITRF"));
				depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DISCOUNTDEPOSITRF"));
				depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTODEPOSITCDRF"));
				depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "DRAFTDRAWINGDATERF"));
				depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DRAFTKINDRF"));
				depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DRAFTKINDNAMERF"));
				depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DRAFTDIVIDERF"));
				depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DRAFTDIVIDENAMERF"));
				depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DRAFTNORF"));
				depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DEPOSITALLOWANCERF"));
				depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DEPOSITALWCBLNCERF"));
				depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTELINKDEPONORF"));
				depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "LASTRECONCILEADDUPDTRF"));
				depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DEPOSITAGENTCODERF"));
				depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DEPOSITAGENTNMRF"));
				depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DEPOSITINPUTAGENTCDRF"));
				depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DEPOSITINPUTAGENTNMRF"));
				depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERCODERF"));
				depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERNAMERF"));
				depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERNAME2RF"));
				depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERSNMRF"));
				depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CLAIMCODERF"));
				depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CLAIMNAMERF"));
				depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CLAIMNAME2RF"));
				depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CLAIMSNMRF"));
				depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "OUTLINERF"));
				depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BANKCODERF"));
				depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BANKNAMERF"));
				# endregion
			}
		}
		
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
    }
}
