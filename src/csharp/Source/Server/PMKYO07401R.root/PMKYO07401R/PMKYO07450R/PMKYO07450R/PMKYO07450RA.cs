//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/11  �C�����e : R�N���X��public Method��SQL�������ʖ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/18  �C�����e : Redmine#23746
//                                  �Ⴄ��ƃR�[�h�Ԃ̑���M�ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/11/01  �C�����e : �d�l�A�� #26228: ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine#8293 ���_�Ǘ��^�`�[���t���t���o����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/12/05  �C�����e : Redmine#8482 ���_�Ǘ��@�l���݂̂̓����f�[�^�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : �e�c ���V
// �C �� ��  2014/03/26  �C�����e : �d�|�ꗗ��2292�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����f�[�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCDepsitMainDB : RemoteDB
    {
        /// <summary>
        /// �����f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCDepsitMainDB()
            : base("PMKYO07451D", "Broadleaf.Application.Remoting.ParamData.DCDepsitMainWork", "DEPSITMAINRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*

        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �����f�[�^�擾
        /// </summary>
        /// <param name="depsitMainList">�����f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int Search(out ArrayList depsitMainList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  depsitMainList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �����f�[�^�擾
        /// </summary>
        /// <param name="depsitMainList">�����f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList depsitMainList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            depsitMainList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, SALESSLIPNUMRF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, DEPOSITDATERF, ADDUPADATERF, DEPOSITTOTALRF, DEPOSITRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, AUTODEPOSITCDRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, DEPOSITINPUTAGENTCDRF, DEPOSITINPUTAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, CLAIMCODERF, CLAIMNAMERF, CLAIMNAME2RF, CLAIMSNMRF, OUTLINERF, BANKCODERF, BANKNAMERF FROM DEPSITMAINRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
            findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;

            // SQL��
			sqlCommand.CommandText = sqlText;

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                depsitMainList.Add(this.CopyToDepsitMainWorkFromReader(ref myReader));
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
        /// <returns>�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private DCDepsitMainWork CopyToDepsitMainWorkFromReader(ref SqlDataReader myReader)
        {
            DCDepsitMainWork depsitMainWork = new DCDepsitMainWork();

			this.CopyToDepsitMainWorkFromReader(ref myReader, ref depsitMainWork);

            return depsitMainWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� depsitMainWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="depsitMainWork">depsitMainWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
		private void CopyToDepsitMainWorkFromReader(ref SqlDataReader myReader, ref DCDepsitMainWork depsitMainWork)
		{
			if (myReader != null && depsitMainWork != null)
			{
				# region �N���X�֊i�[
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
				# endregion
			}
		} 
		*/
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

        // ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
		/// �����f�[�^�擾
		/// </summary>
		/// <param name="resultList">���ʃf�[�^</param>
		/// <param name="receiveDataWork">��M�f�[�^</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <returns></returns>
		public int SearchSCM(out ArrayList resultList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchSCMProc(out  resultList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// �����f�[�^�擾
		/// </summary>
		/// <param name="resultList">���ʃf�[�^</param>
		/// <param name="receiveDataWork">��M�f�[�^</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <returns></returns>
		private int SearchSCMProc(out ArrayList resultList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
            //sb.Append(" INNER JOIN DEPSITDTLRF H WITH (READUNCOMMITTED)  ").Append(Environment.NewLine); // DEL 2011/12/05
            sb.Append(" LEFT JOIN DEPSITDTLRF H WITH (READUNCOMMITTED)  ").Append(Environment.NewLine); // ADD 2011/12/05
			//	�����f�[�^.��ƃR�[�h�@���@�������׃f�[�^.��ƃR�[�h
			sb.Append(" ON G.ENTERPRISECODERF = H.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	�����f�[�^.�󒍃X�e�[�^�X�@���@�������׃f�[�^.�󒍃X�e�[�^�X
			sb.Append(" AND G.ACPTANODRSTATUSRF = H.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			//	�����f�[�^.�����`�[�ԍ��@���@�������׃f�[�^.�����`�[�ԍ�
			sb.Append(" AND G.DEPOSITSLIPNORF = H.DEPOSITSLIPNORF ").Append(Environment.NewLine);
		    //-----Add 2011/11/01 ���� for #26228 start----->>>>>
            if (!(receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1))
            {
            //-----Add 2011/11/01 ���� for #26228 end-----<<<<<<    
			    //	�������׃f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
			    sb.Append(" AND H.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_H ").Append(Environment.NewLine);
			    //	�������׃f�[�^.�X�V�����@���@�p�����[�^.�I�����t
			    sb.Append(" AND H.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_H ").Append(Environment.NewLine);
            }//Add 2011/11/01 ���� for #26228 
			//	�����f�[�^.�v�㋒�_�R�[�h�@���@�p�����[�^.���_�R�[�h
			sb.Append(" WHERE G.ADDUPSECCODERF=@FINDSECTIONCODE ").Append(Environment.NewLine);
		    //-----Add 2011/11/01 ���� for #26228 start----->>>>>
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                //	�����f�[�^.�������t�@���@�p�����[�^.�J�n���t
                //sb.Append(" AND G.DEPOSITDATERF>=@FINDUPDATESTARTDATETIME_G ").Append(Environment.NewLine); // DEL 2011/11/30
                ////	�����f�[�^.�������t�@���@�p�����[�^.�I�����t
                //sb.Append(" AND G.DEPOSITDATERF<=@FINDUPDATEENDDATETIME_G ").Append(Environment.NewLine); // DEL 2011/11/30

                // ----- ADD 2011/11/30 tanh---------->>>>>

                //	�����f�[�^.�������t�@���@�p�����[�^.�J�n���t
                sb.Append(" AND (( G.DEPOSITDATERF>=@FINDUPDATESTARTDATETIME_G ").Append(Environment.NewLine);
                //	�����f�[�^.�������t�@���@�p�����[�^.�I�����t
                sb.Append(" AND G.DEPOSITDATERF<=@FINDUPDATEENDDATETIME_G ) ").Append(Environment.NewLine);

                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sb.Append(" OR ( G.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                sb.Append(" OR ( G.UPDATEDATETIMERF>@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
                sb.Append(" AND  G.UPDATEDATETIMERF<=@FINDENDTIMERF ").Append(Environment.NewLine);
                sb.Append(" AND  G.DEPOSITDATERF<=@FINDUPDATEENDDATETIME_G )) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<<
            }
            else
            {
            //Add 2011/11/01 ���� for #26228 end-----<<<<<<    
                //	�����f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
                sb.Append(" AND G.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_G ").Append(Environment.NewLine);
                //	�����f�[�^.�X�V�����@���@�p�����[�^.�I�����t
                sb.Append(" AND G.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_G ").Append(Environment.NewLine);
            }//Add 2011/11/01 ���� for #26228 
			//	�����f�[�^.��ƃR�[�h�@���@�p�����[�^.��ƃR�[�h
			sb.Append(" AND G.ENTERPRISECODERF=@FINDENTERPRISECODERF ").Append(Environment.NewLine);// ADD 2011/08/18 ���仁@Redmine#23746

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
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);// ADD 2011/08/18 ���仁@Redmine#23746

			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;
			findParaUpdateStartDateTime_G.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_G.Value = receiveDataWork.EndDateTime;
			findParaUpdateStartDateTime_H.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_H.Value = receiveDataWork.EndDateTime;
			findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 ���仁@Redmine#23746

            // ----- ADD 2011/11/30 tanh---------->>>>>
            //�f�[�^���M���o�����敪���u�`�[�敪�v�̏ꍇ
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                findParaSyncExecDate.Value = receiveDataWork.SyncExecDate;
                SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                findParaEndTime.Value = receiveDataWork.EndDateTimeTicks;
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
			DCDepsitDtlDB dCDepsitDtlDB = new DCDepsitDtlDB();
			DCDepsitMainWork tmpWorkG = new DCDepsitMainWork();
			DCDepsitDtlWork tmpWorkH = new DCDepsitDtlWork();

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
				tmpWorkH = dCDepsitDtlDB.CopyToDepsitDtlWorkFromReaderSCM(ref myReader, "H_");
				string workH_key = tmpWorkH.EnterpriseCode + tmpWorkH.AcptAnOdrStatus.ToString()
								  + tmpWorkH.DepositSlipNo.ToString() + tmpWorkH.DepositRowNo.ToString();
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
			if (receiveDataWork.DoDepsitMainFlg)
			{
				resultList.Add(depsitMainList);
			}
			// �������הۃt���O
			if (receiveDataWork.DoDepsitDtlFlg)
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
		private DCDepsitMainWork CopyToDepsitMainWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCDepsitMainWork depsitMainWork = new DCDepsitMainWork();

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
		private void CopyToDepsitMainWorkFromReaderSCM(ref SqlDataReader myReader, ref DCDepsitMainWork depsitMainWork, string tableNm)
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

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �����f�[�^�폜
        /// </summary>
        /// <param name="dcDepsitMainWorkList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Delete(ArrayList dcDepsitMainWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcDepsitMainWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �����f�[�^�폜
        /// </summary>
        /// <param name="dcDepsitMainWorkList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcDepsitMainWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCDepsitMainWork dcDepsitMainWork in dcDepsitMainWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "DELETE FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO";
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = dcDepsitMainWork.EnterpriseCode;
                findParaAcptAnOdrStatus.Value = dcDepsitMainWork.AcptAnOdrStatus;
                findParaDepositSlipNo.Value = dcDepsitMainWork.DepositSlipNo;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

                // �����f�[�^���폜����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �����f�[�^�o�^
        /// </summary>
        /// <param name="dcDepsitMainWorkList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Insert(ArrayList dcDepsitMainWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcDepsitMainWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �����f�[�^�o�^
        /// </summary>
        /// <param name="dcDepsitMainWorkList">�����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcDepsitMainWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCDepsitMainWork dcDepsitMainWork in dcDepsitMainWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO DEPSITMAINRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, SALESSLIPNUMRF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, DEPOSITDATERF, ADDUPADATERF, DEPOSITTOTALRF, DEPOSITRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, AUTODEPOSITCDRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, DEPOSITINPUTAGENTCDRF, DEPOSITINPUTAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, CLAIMCODERF, CLAIMNAMERF, CLAIMNAME2RF, CLAIMSNMRF, OUTLINERF, BANKCODERF, BANKNAMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACPTANODRSTATUS, @DEPOSITDEBITNOTECD, @DEPOSITSLIPNO, @SALESSLIPNUM, @INPUTDEPOSITSECCD, @ADDUPSECCODE, @UPDATESECCD, @SUBSECTIONCODE, @INPUTDAYRF, @DEPOSITDATE, @ADDUPADATE, @DEPOSITTOTAL, @DEPOSIT, @FEEDEPOSIT, @DISCOUNTDEPOSIT, @AUTODEPOSITCD, @DRAFTDRAWINGDATE, @DRAFTKIND, @DRAFTKINDNAME, @DRAFTDIVIDE, @DRAFTDIVIDENAME, @DRAFTNO, @DEPOSITALLOWANCE, @DEPOSITALWCBLNCE, @DEBITNOTELINKDEPONO, @LASTRECONCILEADDUPDT, @DEPOSITAGENTCODE, @DEPOSITAGENTNM, @DEPOSITINPUTAGENTCD, @DEPOSITINPUTAGENTNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @CLAIMCODE, @CLAIMNAME, @CLAIMNAME2, @CLAIMSNM, @OUTLINE, @BANKCODE, @BANKNAME)";
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
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcDepsitMainWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcDepsitMainWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcDepsitMainWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.LogicalDeleteCode);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.AcptAnOdrStatus);
                paraDepositDebitNoteCd.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.DepositDebitNoteCd);
                paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.DepositSlipNo);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.SalesSlipNum);
                paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.InputDepositSecCd);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.AddUpSecCode);
                paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.UpdateSecCd);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.SubSectionCode);
                paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcDepsitMainWork.InputDay);
                paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcDepsitMainWork.DepositDate);
                paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcDepsitMainWork.AddUpADate);
                paraDepositTotal.Value = SqlDataMediator.SqlSetInt64(dcDepsitMainWork.DepositTotal);
                paraDeposit.Value = SqlDataMediator.SqlSetInt64(dcDepsitMainWork.Deposit);
                paraFeeDeposit.Value = SqlDataMediator.SqlSetInt64(dcDepsitMainWork.FeeDeposit);
                paraDiscountDeposit.Value = SqlDataMediator.SqlSetInt64(dcDepsitMainWork.DiscountDeposit);
                paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.AutoDepositCd);
                paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcDepsitMainWork.DraftDrawingDate);
                paraDraftKind.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.DraftKind);
                paraDraftKindName.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.DraftKindName);
                paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.DraftDivide);
                paraDraftDivideName.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.DraftDivideName);
                paraDraftNo.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.DraftNo);
                paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(dcDepsitMainWork.DepositAllowance);
                paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(dcDepsitMainWork.DepositAlwcBlnce);
                paraDebitNoteLinkDepoNo.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.DebitNoteLinkDepoNo);
                paraLastReconcileAddUpDt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcDepsitMainWork.LastReconcileAddUpDt);
                paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.DepositAgentCode);
                paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.DepositAgentNm);
                paraDepositInputAgentCd.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.DepositInputAgentCd);
                paraDepositInputAgentNm.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.DepositInputAgentNm);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.CustomerCode);
                paraCustomerName.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.CustomerName);
                paraCustomerName2.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.CustomerName2);
                paraCustomerSnm.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.CustomerSnm);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.ClaimCode);
                paraClaimName.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.ClaimName);
                paraClaimName2.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.ClaimName2);
                paraClaimSnm.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.ClaimSnm);
                paraOutline.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.Outline);
                paraBankCode.Value = SqlDataMediator.SqlSetInt32(dcDepsitMainWork.BankCode);
                paraBankName.Value = SqlDataMediator.SqlSetString(dcDepsitMainWork.BankName);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �����f�[�^��o�^����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

		// ADD 2011.08.26 ���� ---------->>>>>
		# region [Clear]
		// R�N���X��public Method��SQL�������ʖ�
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                       //DEL by Liangsd     2011/09/06
        public void Clear(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)      //ADD by Liangsd    2011/09/06
        {
            //ClearProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//DEL by Liangsd     2011/09/06
            ClearProc(sectionCode, enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//ADD by Liangsd    2011/09/06
        }
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd     2011/09/06
        private void ClearProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//ADD by Liangsd    2011/09/06
        {
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Delete�R�}���h�̐���
            //sqlCommand.CommandText = "DELETE FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
            sqlCommand.CommandText = "DELETE FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND ADDUPSECCODERF = @FINDSECTIONCODERF";
            
			//Prameter�I�u�W�F�N�g�̍쐬
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaEnterpriseCode.Value = enterpriseCode;
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // ����f�[�^���폜����
			sqlCommand.ExecuteNonQuery();

		}
		#endregion
		// ADD 2011.08.26 ���� ----------<<<<<
    }
}
