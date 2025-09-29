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
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �x���`�[�}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �x���`�[�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCPaymentSlpDB : RemoteDB
    {
        /// <summary>
        /// �x���`�[�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCPaymentSlpDB()
            : base("PMKYO07511D", "Broadleaf.Application.Remoting.ParamData.DCPaymentSlpWork", "PAYMENTSLPRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �x���`�[�}�X�^�f�[�^�擾
        /// </summary>
        /// <param name="paymentSlpList">�x���`�[�}�X�^�f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int Search(out ArrayList paymentSlpList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  paymentSlpList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �x���`�[�}�X�^�f�[�^�擾
        /// </summary>
        /// <param name="paymentSlpList">�x���`�[�}�X�^�f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList paymentSlpList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            paymentSlpList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEBITNOTEDIVRF, PAYMENTSLIPNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, PAYMENTINPSECTIONCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, PAYMENTDATERF, ADDUPADATERF, PAYMENTTOTALRF, PAYMENTRF, FEEPAYMENTRF, DISCOUNTPAYMENTRF, AUTOPAYMENTRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEBITNOTELINKPAYNORF, PAYMENTAGENTCODERF, PAYMENTAGENTNAMERF, PAYMENTINPUTAGENTCDRF, PAYMENTINPUTAGENTNMRF, OUTLINERF, BANKCODERF, BANKNAMERF FROM PAYMENTSLPRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
                paymentSlpList.Add(this.CopyToPaymentSlpWorkFromReader(ref myReader));
            }

            if (paymentSlpList.Count > 0)
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
        /// �N���X�i�[���� Reader �� paymentSlpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCPaymentSlpWork CopyToPaymentSlpWorkFromReader(ref SqlDataReader myReader)
        {
            DCPaymentSlpWork paymentSlpWork = new DCPaymentSlpWork();

			this.CopyToPaymentSlpWorkFromReader(ref myReader, ref paymentSlpWork);

            return paymentSlpWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� paymentSlpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paymentSlpWork">paymentSlpWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private void CopyToPaymentSlpWorkFromReader(ref SqlDataReader myReader, ref DCPaymentSlpWork paymentSlpWork)
        {
            if (myReader != null && paymentSlpWork != null)
			{
				# region �N���X�֊i�[
				paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
				paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
				paymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
				paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
				paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
				paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
				paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
				paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
				paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
				paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
				paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
				paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
				paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
				paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
				paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
				paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
				paymentSlpWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
				paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
				paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
				paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
				paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
				paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
				paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
				paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
				paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
				paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
				paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
				paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
				paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
				paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
				paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
				paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
				paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
				paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
				paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
				paymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
				paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
				paymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
				# endregion
            }
        }
  
  */
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

        // ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
		/// �x���`�[�}�X�^�f�[�^�擾
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
		/// �x���`�[�}�X�^�f�[�^�擾
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
			sb.Append(" SELECT M.CREATEDATETIMERF as M_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDATEDATETIMERF as M_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.ENTERPRISECODERF as M_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.FILEHEADERGUIDRF as M_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDEMPLOYEECODERF as M_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDASSEMBLYID1RF as M_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDASSEMBLYID2RF as M_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,M.LOGICALDELETECODERF as M_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DEBITNOTEDIVRF as M_DEBITNOTEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTSLIPNORF as M_PAYMENTSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERFORMALRF as M_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERSLIPNORF as M_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERCDRF as M_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERNM1RF as M_SUPPLIERNM1RF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERNM2RF as M_SUPPLIERNM2RF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUPPLIERSNMRF as M_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYEECODERF as M_PAYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYEENAMERF as M_PAYEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYEENAME2RF as M_PAYEENAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYEESNMRF as M_PAYEESNMRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTINPSECTIONCDRF as M_PAYMENTINPSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.ADDUPSECCODERF as M_ADDUPSECCODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.UPDATESECCDRF as M_UPDATESECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.SUBSECTIONCODERF as M_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.INPUTDAYRF as M_INPUTDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTDATERF as M_PAYMENTDATERF ").Append(Environment.NewLine);
			sb.Append(" ,M.ADDUPADATERF as M_ADDUPADATERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTTOTALRF as M_PAYMENTTOTALRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTRF as M_PAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,M.FEEPAYMENTRF as M_FEEPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,M.DISCOUNTPAYMENTRF as M_DISCOUNTPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,M.AUTOPAYMENTRF as M_AUTOPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTDRAWINGDATERF as M_DRAFTDRAWINGDATERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTKINDRF as M_DRAFTKINDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTKINDNAMERF as M_DRAFTKINDNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTDIVIDERF as M_DRAFTDIVIDERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTDIVIDENAMERF as M_DRAFTDIVIDENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.DRAFTNORF as M_DRAFTNORF ").Append(Environment.NewLine);
			sb.Append(" ,M.DEBITNOTELINKPAYNORF as M_DEBITNOTELINKPAYNORF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTAGENTCODERF as M_PAYMENTAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTAGENTNAMERF as M_PAYMENTAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTINPUTAGENTCDRF as M_PAYMENTINPUTAGENTCDRF ").Append(Environment.NewLine);
			sb.Append(" ,M.PAYMENTINPUTAGENTNMRF as M_PAYMENTINPUTAGENTNMRF ").Append(Environment.NewLine);
			sb.Append(" ,M.OUTLINERF as M_OUTLINERF ").Append(Environment.NewLine);
			sb.Append(" ,M.BANKCODERF as M_BANKCODERF ").Append(Environment.NewLine);
			sb.Append(" ,M.BANKNAMERF as M_BANKNAMERF ").Append(Environment.NewLine);
			//�x�����׃f�[�^
			sb.Append(" ,N.CREATEDATETIMERF as N_CREATEDATETIMERF").Append(Environment.NewLine);
			sb.Append(" ,N.UPDATEDATETIMERF as N_UPDATEDATETIMERF").Append(Environment.NewLine);
			sb.Append(" ,N.ENTERPRISECODERF as N_ENTERPRISECODERF").Append(Environment.NewLine);
			sb.Append(" ,N.FILEHEADERGUIDRF as N_FILEHEADERGUIDRF").Append(Environment.NewLine);
			sb.Append(" ,N.UPDEMPLOYEECODERF as N_UPDEMPLOYEECODERF").Append(Environment.NewLine);
			sb.Append(" ,N.UPDASSEMBLYID1RF as N_UPDASSEMBLYID1RF").Append(Environment.NewLine);
			sb.Append(" ,N.UPDASSEMBLYID2RF as N_UPDASSEMBLYID2RF").Append(Environment.NewLine);
			sb.Append(" ,N.LOGICALDELETECODERF as N_LOGICALDELETECODERF").Append(Environment.NewLine);
			sb.Append(" ,N.SUPPLIERFORMALRF as N_SUPPLIERFORMALRF").Append(Environment.NewLine);
			sb.Append(" ,N.PAYMENTSLIPNORF as N_PAYMENTSLIPNORF").Append(Environment.NewLine);
			sb.Append(" ,N.PAYMENTROWNORF as N_PAYMENTROWNORF").Append(Environment.NewLine);
			sb.Append(" ,N.MONEYKINDCODERF as N_MONEYKINDCODERF").Append(Environment.NewLine);
			sb.Append(" ,N.MONEYKINDNAMERF as N_MONEYKINDNAMERF").Append(Environment.NewLine);
			sb.Append(" ,N.MONEYKINDDIVRF as N_MONEYKINDDIVRF").Append(Environment.NewLine);
			sb.Append(" ,N.PAYMENTRF as N_PAYMENTRF").Append(Environment.NewLine);
			sb.Append(" ,N.VALIDITYTERMRF as N_VALIDITYTERMRF").Append(Environment.NewLine);

			sb.Append(" FROM PAYMENTSLPRF M WITH (READUNCOMMITTED)").Append(Environment.NewLine);

			//�x�����׃f�[�^
            //sb.Append("  INNER JOIN PAYMENTDTLRF N WITH (READUNCOMMITTED) ").Append(Environment.NewLine); // DEL 2011/12/05
            sb.Append("  LEFT JOIN PAYMENTDTLRF N WITH (READUNCOMMITTED) ").Append(Environment.NewLine);  // ADD 2011/12/05
			//	�x���`�[�f�[�^.��ƃR�[�h�@���@�x�����׃f�[�^.��ƃR�[�h 
			sb.Append(" ON M.ENTERPRISECODERF = N.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	�x���`�[�f�[�^.�x���`�[�ԍ��@���@�x�����׃f�[�^.�x���`�[�ԍ� PaymentSlipNoRF
			sb.Append(" AND M.PAYMENTSLIPNORF = N.PAYMENTSLIPNORF ").Append(Environment.NewLine);
		    //-----Add 2011/11/01 ���� for #26228 start----->>>>>
            if (!(receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1))
            {
            //-----Add 2011/11/01 ���� for #26228 end-----<<<<<<    
                //	�x�����׃f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
                sb.Append(" AND N.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_N ").Append(Environment.NewLine);
                //	�x�����׃f�[�^.�X�V�����@���@�p�����[�^.�I�����t
                sb.Append(" AND N.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_N ").Append(Environment.NewLine);
            }//Add 2011/11/01 ���� for #26228
			//	�x���`�[�f�[�^.�v�㋒�_�R�[�h�@���@�p�����[�^.���_�R�[�h
			sb.Append(" WHERE M.ADDUPSECCODERF=@FINDSECTIONCODE ").Append(Environment.NewLine);
		    //-----Add 2011/11/01 ���� for #26228 start----->>>>>
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                //	�x���`�[�f�[�^.�x�����t�@���@�p�����[�^.�J�n���t
                //sb.Append(" AND M.PAYMENTDATERF>=@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine); // DEL 2011/11/30
                ////	�x���`�[�f�[�^.�x�����t�@���@�p�����[�^.�I�����t
                //sb.Append(" AND M.PAYMENTDATERF<=@FINDUPDATEENDDATETIME_M ").Append(Environment.NewLine); // DEL 2011/11/30

                // ----- ADD 2011/11/30 tanh---------->>>>>

                //	�x���`�[�f�[�^.�x�����t�@���@�p�����[�^.�J�n���t
                sb.Append(" AND (( M.PAYMENTDATERF>=@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine);
                //	�x���`�[�f�[�^.�x�����t�@���@�p�����[�^.�I�����t
                sb.Append(" AND M.PAYMENTDATERF<=@FINDUPDATEENDDATETIME_M ) ").Append(Environment.NewLine);

                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sb.Append(" OR ( M.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                sb.Append(" OR ( M.UPDATEDATETIMERF>@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
                sb.Append(" AND  M.UPDATEDATETIMERF<=@FINDENDTIMERF ").Append(Environment.NewLine);
                sb.Append(" AND  M.PAYMENTDATERF<=@FINDUPDATEENDDATETIME_M )) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<<

            }
		    else
            {
            //-----Add 2011/11/01 ���� for #26228 end-----<<<<<<   
                //	�x���`�[�f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
                sb.Append(" AND M.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_M ").Append(Environment.NewLine);
                //	�x���`�[�f�[�^.�X�V�����@���@�p�����[�^.�I�����t
                sb.Append(" AND M.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_M ").Append(Environment.NewLine);
            }//Add 2011/11/01 ���� for #26228
			//	�x���`�[�f�[�^.��ƃR�[�h�@���@�p�����[�^.��ƃR�[�h
			sb.Append(" AND M.ENTERPRISECODERF=@FINDENTERPRISECODERF ").Append(Environment.NewLine);// ADD 2011/08/18 ���仁@Redmine#23746

			sb.Append(" ORDER BY ").Append(Environment.NewLine);
			sb.Append(" M_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,M_PAYMENTSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,N_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,N_PAYMENTSLIPNORF  ").Append(Environment.NewLine);
			sb.Append(" ,N_PAYMENTROWNORF ").Append(Environment.NewLine);

			sqlText = sb.ToString();

			//Prameter�I�u�W�F�N�g�̍쐬
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_M = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_M", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_M = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_M", SqlDbType.BigInt);
			SqlParameter findParaUpdateStartDateTime_N = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_N", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_N = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_N", SqlDbType.BigInt);
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);// ADD 2011/08/18 ���仁@Redmine#23746

			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;
			findParaUpdateStartDateTime_M.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_M.Value = receiveDataWork.EndDateTime;
			findParaUpdateStartDateTime_N.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_N.Value = receiveDataWork.EndDateTime;
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

			ArrayList paymentSlpList = new ArrayList();
			ArrayList paymentDtlList = new ArrayList();
			DCPaymentDtlDB dCPaymentDtlDB = new DCPaymentDtlDB();
			DCPaymentSlpWork tmpWorkM = new DCPaymentSlpWork();
			DCPaymentDtlWork tmpWorkN = new DCPaymentDtlWork();

			Dictionary<string, string> paymentSlpDic = new Dictionary<string, string>();
			Dictionary<string, string> paymentDtlDic = new Dictionary<string, string>();

			while (myReader.Read())
			{
				//	�x���`�[�f�[�^
				tmpWorkM = this.CopyToPaymentSlpWorkFromReaderSCM(ref myReader, "M_");
				string workM_key = tmpWorkM.EnterpriseCode + tmpWorkM.PaymentSlipNo.ToString();
				if (!string.Empty.Equals(tmpWorkM.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkM.PaymentSlipNo.ToString())
					&& !paymentSlpDic.ContainsKey(workM_key))
				{
					paymentSlpDic.Add(workM_key, workM_key);
					paymentSlpList.Add(tmpWorkM);
				}
				//	�x�����׃f�[�^
				tmpWorkN = dCPaymentDtlDB.CopyToPaymentDtlWorkFromReaderSCM(ref myReader, "N_");
				string workN_key = tmpWorkN.EnterpriseCode + tmpWorkN.PaymentSlipNo.ToString()
								  + tmpWorkN.SupplierFormal.ToString() + tmpWorkN.PaymentRowNo.ToString();
				if (!string.Empty.Equals(tmpWorkN.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkN.PaymentSlipNo.ToString())
					&& !string.Empty.Equals(tmpWorkN.SupplierFormal.ToString())
					&& !string.Empty.Equals(tmpWorkN.PaymentRowNo.ToString())
					&& !paymentDtlDic.ContainsKey(workN_key))
				{
					paymentDtlDic.Add(workN_key, workN_key);
					paymentDtlList.Add(tmpWorkN);
				}
			}
			// �x���`�[�v�ۃt���O
			if (receiveDataWork.DoPaymentSlpFlg)
			{
				resultList.Add(paymentSlpList);
			}
			// �x�����חv�ۃt���O
			if (receiveDataWork.DoPaymentDtlFlg)
			{
				resultList.Add(paymentDtlList);
			}

			if (paymentSlpList.Count > 0)
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
		/// �N���X�i�[���� Reader �� paymentSlpWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>�I�u�W�F�N�g</returns>
		private DCPaymentSlpWork CopyToPaymentSlpWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCPaymentSlpWork paymentSlpWork = new DCPaymentSlpWork();

			this.CopyToPaymentSlpWorkFromReaderSCM(ref myReader, ref paymentSlpWork, tableNm);

			return paymentSlpWork;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� paymentSlpWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="paymentSlpWork">paymentSlpWork �I�u�W�F�N�g</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToPaymentSlpWorkFromReaderSCM(ref SqlDataReader myReader, ref DCPaymentSlpWork paymentSlpWork, string tableNm)
		{
			if (myReader != null && paymentSlpWork != null)
			{
				# region �N���X�֊i�[
				paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTEDIVRF"));
				paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PAYMENTSLIPNORF"));
				paymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALRF"));
				paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNORF"));
				paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCDRF"));
				paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM1RF"));
				paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM2RF"));
				paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSNMRF"));
				paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PAYEECODERF"));
				paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYEENAMERF"));
				paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYEENAME2RF"));
				paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYEESNMRF"));
				paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTINPSECTIONCDRF"));
				paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDUPSECCODERF"));
				paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDATESECCDRF"));
				paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				paymentSlpWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "INPUTDAYRF"));
				paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "PAYMENTDATERF"));
				paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ADDUPADATERF"));
				paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "PAYMENTTOTALRF"));
				paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "PAYMENTRF"));
				paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "FEEPAYMENTRF"));
				paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DISCOUNTPAYMENTRF"));
				paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOPAYMENTRF"));
				paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "DRAFTDRAWINGDATERF"));
				paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DRAFTKINDRF"));
				paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DRAFTKINDNAMERF"));
				paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DRAFTDIVIDERF"));
				paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DRAFTDIVIDENAMERF"));
				paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DRAFTNORF"));
				paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTELINKPAYNORF"));
				paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTAGENTCODERF"));
				paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTAGENTNAMERF"));
				paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTINPUTAGENTCDRF"));
				paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYMENTINPUTAGENTNMRF"));
				paymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "OUTLINERF"));
				paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BANKCODERF"));
				paymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BANKNAMERF"));
				# endregion
			}
		}
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �x���`�[�}�X�^�폜
        /// </summary>
        /// <param name="dcPaymentSlpWorkList">�x���`�[�}�X�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Delete(ArrayList dcPaymentSlpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcPaymentSlpWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �x���`�[�}�X�^�폜
        /// </summary>
        /// <param name="dcPaymentSlpWorkList">�x���`�[�}�X�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcPaymentSlpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCPaymentSlpWork dcPaymentSlpWork in dcPaymentSlpWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "DELETE FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO";
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = dcPaymentSlpWork.EnterpriseCode;
                findParaPaymentSlipNo.Value = dcPaymentSlpWork.PaymentSlipNo;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �x���`�[�}�X�^���폜����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �x���`�[�}�X�^�o�^
        /// </summary>
        /// <param name="dcPaymentSlpWorkList">�x���`�[�}�X�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Insert(ArrayList dcPaymentSlpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcPaymentSlpWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �x���`�[�}�X�^�o�^
        /// </summary>
        /// <param name="dcPaymentSlpWorkList">�x���`�[�}�X�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcPaymentSlpWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCPaymentSlpWork dcPaymentSlpWork in dcPaymentSlpWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO PAYMENTSLPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEBITNOTEDIVRF, PAYMENTSLIPNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, PAYMENTINPSECTIONCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, INPUTDAYRF, PAYMENTDATERF, ADDUPADATERF, PAYMENTTOTALRF, PAYMENTRF, FEEPAYMENTRF, DISCOUNTPAYMENTRF, AUTOPAYMENTRF, DRAFTDRAWINGDATERF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEBITNOTELINKPAYNORF, PAYMENTAGENTCODERF, PAYMENTAGENTNAMERF, PAYMENTINPUTAGENTCDRF, PAYMENTINPUTAGENTNMRF, OUTLINERF, BANKCODERF, BANKNAMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DEBITNOTEDIV, @PAYMENTSLIPNO, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @PAYEECODE, @PAYEENAME, @PAYEENAME2, @PAYEESNM, @PAYMENTINPSECTIONCD, @ADDUPSECCODE, @UPDATESECCD, @SUBSECTIONCODE, @INPUTDAYRF, @PAYMENTDATE, @ADDUPADATE, @PAYMENTTOTAL, @PAYMENT, @FEEPAYMENT, @DISCOUNTPAYMENT, @AUTOPAYMENT, @DRAFTDRAWINGDATE, @DRAFTKIND, @DRAFTKINDNAME, @DRAFTDIVIDE, @DRAFTDIVIDENAME, @DRAFTNO, @DEBITNOTELINKPAYNO, @PAYMENTAGENTCODE, @PAYMENTAGENTNAME, @PAYMENTINPUTAGENTCD, @PAYMENTINPUTAGENTNM, @OUTLINE, @BANKCODE, @BANKNAME)";
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAYRF", SqlDbType.Int);
                SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                SqlParameter paraPaymentTotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                SqlParameter paraDebitNoteLinkPayNo = sqlCommand.Parameters.Add("@DEBITNOTELINKPAYNO", SqlDbType.Int);
                SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                SqlParameter paraPaymentAgentName = sqlCommand.Parameters.Add("@PAYMENTAGENTNAME", SqlDbType.NVarChar);
                SqlParameter paraPaymentInputAgentCd = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTCD", SqlDbType.NChar);
                SqlParameter paraPaymentInputAgentNm = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTNM", SqlDbType.NVarChar);
                SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPaymentSlpWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPaymentSlpWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcPaymentSlpWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.LogicalDeleteCode);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.DebitNoteDiv);
                paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.PaymentSlipNo);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.SupplierFormal);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.SupplierSlipNo);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.SupplierCd);
                paraSupplierNm1.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.SupplierNm1);
                paraSupplierNm2.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.SupplierNm2);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.SupplierSnm);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.PayeeCode);
                paraPayeeName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PayeeName);
                paraPayeeName2.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PayeeName2);
                paraPayeeSnm.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PayeeSnm);
                paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentInpSectionCd);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.AddUpSecCode);
                paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.UpdateSecCd);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.SubSectionCode);
                paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPaymentSlpWork.InputDay);
                paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPaymentSlpWork.PaymentDate);
                paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPaymentSlpWork.AddUpADate);
                paraPaymentTotal.Value = SqlDataMediator.SqlSetInt64(dcPaymentSlpWork.PaymentTotal);
                paraPayment.Value = SqlDataMediator.SqlSetInt64(dcPaymentSlpWork.Payment);
                paraFeePayment.Value = SqlDataMediator.SqlSetInt64(dcPaymentSlpWork.FeePayment);
                paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(dcPaymentSlpWork.DiscountPayment);
                paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.AutoPayment);
                paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPaymentSlpWork.DraftDrawingDate);
                paraDraftKind.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.DraftKind);
                paraDraftKindName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.DraftKindName);
                paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.DraftDivide);
                paraDraftDivideName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.DraftDivideName);
                paraDraftNo.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.DraftNo);
                paraDebitNoteLinkPayNo.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.DebitNoteLinkPayNo);
                paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentAgentCode);
                paraPaymentAgentName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentAgentName);
                paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentInputAgentCd);
                paraPaymentInputAgentNm.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.PaymentInputAgentNm);
                paraOutline.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.Outline);
                paraBankCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentSlpWork.BankCode);
                paraBankName.Value = SqlDataMediator.SqlSetString(dcPaymentSlpWork.BankName);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �x���`�[�}�X�^��o�^����
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
            //sqlCommand.CommandText = "DELETE FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            sqlCommand.CommandText = "DELETE FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND ADDUPSECCODERF = @FINDSECTIONCODERF";//ADD by Liangsd    2011/09/06
            
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
