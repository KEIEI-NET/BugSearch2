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
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
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
    /// �x�����׃}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �x�����׃}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCPaymentDtlDB : RemoteDB
    {
        /// <summary>
        /// �x�����׃}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCPaymentDtlDB()
            : base("PMKYO07521D", "Broadleaf.Application.Remoting.ParamData.DCPaymentDtlWork", "PAYMENTDTLRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �x�����׃}�X�^�f�[�^�擾
        /// </summary>
        /// <param name="paymentDtlList">�x�����׃}�X�^�f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int Search(out ArrayList paymentDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  paymentDtlList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �x�����׃}�X�^�f�[�^�擾
        /// </summary>
        /// <param name="paymentDtlList">�x�����׃}�X�^�f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList paymentDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            paymentDtlList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, MONEYKINDCODERF, MONEYKINDNAMERF, MONEYKINDDIVRF, PAYMENTRF, VALIDITYTERMRF FROM PAYMENTDTLRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
                paymentDtlList.Add(this.CopyToPaymentDtlWorkFromReader(ref myReader));
            }

            if (paymentDtlList.Count > 0)
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
        private DCPaymentDtlWork CopyToPaymentDtlWorkFromReader(ref SqlDataReader myReader)
        {
            DCPaymentDtlWork paymentDtlWork = new DCPaymentDtlWork();

			this.CopyToPaymentDtlWorkFromReader(ref myReader, ref paymentDtlWork);

            return paymentDtlWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� paymentDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paymentDtlWork">paymentDtlWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private void CopyToPaymentDtlWorkFromReader(ref SqlDataReader myReader, ref DCPaymentDtlWork paymentDtlWork)
        {
            if (myReader != null && paymentDtlWork != null)
            {
				# region �N���X�֊i�[
				paymentDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				paymentDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				paymentDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				paymentDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				paymentDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				paymentDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				paymentDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				paymentDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				paymentDtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
				paymentDtlWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
				paymentDtlWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
				paymentDtlWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
				paymentDtlWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
				paymentDtlWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
				paymentDtlWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
				paymentDtlWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
				# endregion
            }
        }
*/
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

        // ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
		/// �N���X�i�[���� Reader �� paymentSlpWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>�I�u�W�F�N�g</returns>
		public DCPaymentDtlWork CopyToPaymentDtlWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCPaymentDtlWork paymentDtlWork = new DCPaymentDtlWork();

			this.CopyToPaymentDtlWorkFromReaderSCM(ref myReader, ref paymentDtlWork, tableNm);

			return paymentDtlWork;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� paymentDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="paymentDtlWork">paymentDtlWork �I�u�W�F�N�g</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToPaymentDtlWorkFromReaderSCM(ref SqlDataReader myReader, ref DCPaymentDtlWork paymentDtlWork, string tableNm)
		{
			if (myReader != null && paymentDtlWork != null)
			{
				# region �N���X�֊i�[
				paymentDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				paymentDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				paymentDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				paymentDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				paymentDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				paymentDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				paymentDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				paymentDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				paymentDtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALRF"));
				paymentDtlWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PAYMENTSLIPNORF"));
				paymentDtlWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PAYMENTROWNORF"));
				paymentDtlWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "MONEYKINDCODERF"));
				paymentDtlWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MONEYKINDNAMERF"));
				paymentDtlWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "MONEYKINDDIVRF"));
				paymentDtlWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "PAYMENTRF"));
				paymentDtlWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "VALIDITYTERMRF"));
				# endregion
			}
		}
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �x�����׃f�[�^�폜
        /// </summary>
        /// <param name="dcPaymentDtlWorkList">�x�����׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Delete(ArrayList dcPaymentDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcPaymentDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �x�����׃f�[�^�폜
        /// </summary>
        /// <param name="dcPaymentDtlWorkList">�x�����׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcPaymentDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCPaymentDtlWork dcPaymentDtlWork in dcPaymentDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                /* --- DEL 2009/04/27 ---------->>>>>
                sqlCommand.CommandText = "DELETE FROM PAYMENTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO AND PAYMENTROWNORF=@FINDPAYMENTROWNO";
                --- DEL 2009/04/27 ----------<<<<< */
                sqlCommand.CommandText = "DELETE FROM PAYMENTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO"; // ADD 2009/04/27�@�x���s�ԍ�->�폜����

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
                //SqlParameter findParaPaymentRowNo = sqlCommand.Parameters.Add("@FINDPAYMENTROWNO", SqlDbType.Int); // DEL 2009/04/27

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = dcPaymentDtlWork.EnterpriseCode;
                findParaSupplierFormal.Value = dcPaymentDtlWork.SupplierFormal;
                findParaPaymentSlipNo.Value = dcPaymentDtlWork.PaymentSlipNo;
                //findParaPaymentRowNo.Value = dcPaymentDtlWork.PaymentRowNo; // DEL 2009/04/27
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �x�����׃f�[�^���폜����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �x�����׃f�[�^�o�^
        /// </summary>
        /// <param name="dcPaymentDtlWorkList">�x�����׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Insert(ArrayList dcPaymentDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcPaymentDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �x�����׃f�[�^�o�^
        /// </summary>
        /// <param name="dcPaymentDtlWorkList">�x�����׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcPaymentDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCPaymentDtlWork dcPaymentDtlWork in dcPaymentDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO PAYMENTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, MONEYKINDCODERF, MONEYKINDNAMERF, MONEYKINDDIVRF, PAYMENTRF, VALIDITYTERMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SUPPLIERFORMAL, @PAYMENTSLIPNO, @PAYMENTROWNO, @MONEYKINDCODE, @MONEYKINDNAME, @MONEYKINDDIV, @PAYMENT, @VALIDITYTERM)";
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                SqlParameter paraPaymentRowNo = sqlCommand.Parameters.Add("@PAYMENTROWNO", SqlDbType.Int);
                SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPaymentDtlWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcPaymentDtlWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcPaymentDtlWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcPaymentDtlWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcPaymentDtlWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcPaymentDtlWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcPaymentDtlWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentDtlWork.LogicalDeleteCode);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dcPaymentDtlWork.SupplierFormal);
                paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(dcPaymentDtlWork.PaymentSlipNo);
                paraPaymentRowNo.Value = SqlDataMediator.SqlSetInt32(dcPaymentDtlWork.PaymentRowNo);
                paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(dcPaymentDtlWork.MoneyKindCode);
                paraMoneyKindName.Value = SqlDataMediator.SqlSetString(dcPaymentDtlWork.MoneyKindName);
                paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(dcPaymentDtlWork.MoneyKindDiv);
                paraPayment.Value = SqlDataMediator.SqlSetInt64(dcPaymentDtlWork.Payment);
                paraValidityTerm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcPaymentDtlWork.ValidityTerm);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �x�����׃f�[�^��o�^����
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
            //sqlCommand.CommandText = "DELETE FROM PAYMENTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM PAYMENTDTLRF WHERE  EXISTS ").Append(Environment.NewLine);
            sb.Append("(SELECT PAYMENTDTLRF.PAYMENTSLIPNORF FROM PAYMENTSLPRF  WHERE PAYMENTSLPRF.ENTERPRISECODERF=@FINDENTERPRISECODE ").Append(Environment.NewLine);
            sb.Append(" AND PAYMENTSLPRF.ENTERPRISECODERF = PAYMENTDTLRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" AND PAYMENTSLPRF.PAYMENTSLIPNORF = PAYMENTDTLRF.PAYMENTSLIPNORF ").Append(Environment.NewLine);
            sb.Append(" AND PAYMENTSLPRF.ADDUPSECCODERF = @FINDSECTIONCODERF) ").Append(Environment.NewLine);
            sqlCommand.CommandText = sb.ToString();
            
            //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
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
