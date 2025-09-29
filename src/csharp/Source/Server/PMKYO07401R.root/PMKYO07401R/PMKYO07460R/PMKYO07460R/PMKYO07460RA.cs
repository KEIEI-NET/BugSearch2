//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   DC���o�E�X�VDB����N���X
//                  :   PMKYO07460R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   ���m
// Date             :   2009.3.30
//----------------------------------------------------------------------
// Update Note      :
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
    /// �������׃f�[�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ׂ̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCDepsitDtlDB : RemoteDB
    {
        /// <summary>
        /// �������׃f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCDepsitDtlDB()
            : base("PMKYO07461D", "Broadleaf.Application.Remoting.ParamData.DCDepsitDtlWork", "DEPSITDTLRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �������׃f�[�^�擾
        /// </summary>
        /// <param name="depsitDtlList">�������׃f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int Search(out ArrayList depsitDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  depsitDtlList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �������׃f�[�^�擾
        /// </summary>
        /// <param name="depsitDtlList">�������׃f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList depsitDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            depsitDtlList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, MONEYKINDCODERF, MONEYKINDNAMERF, MONEYKINDDIVRF, DEPOSITRF, VALIDITYTERMRF FROM DEPSITDTLRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
                depsitDtlList.Add(this.CopyToDepsitDtlWorkFromReader(ref myReader));
            }

            if (depsitDtlList.Count > 0)
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
        /// �N���X�i�[���� Reader �� depsitDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCDepsitDtlWork CopyToDepsitDtlWorkFromReader(ref SqlDataReader myReader)
        {
            DCDepsitDtlWork depsitDtlWork = new DCDepsitDtlWork();

            this.CopyToDepsitDtlWorkFromReader(ref myReader, ref depsitDtlWork);

            return depsitDtlWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� depsitDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="depsitDtlWork">depsitDtlWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
		private void CopyToDepsitDtlWorkFromReader(ref SqlDataReader myReader, ref DCDepsitDtlWork depsitDtlWork)
        {
            if (myReader != null && depsitDtlWork != null)
            {
				# region �N���X�֊i�[
				depsitDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				depsitDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				depsitDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				depsitDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				depsitDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				depsitDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				depsitDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				depsitDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				depsitDtlWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
				depsitDtlWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
				depsitDtlWork.DepositRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITROWNORF"));
				depsitDtlWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
				depsitDtlWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
				depsitDtlWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
				depsitDtlWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
				depsitDtlWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
				# endregion
            }
        }
 */
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

        // ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
		/// �N���X�i�[���� Reader �� depsitDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>�I�u�W�F�N�g</returns>
		public DCDepsitDtlWork CopyToDepsitDtlWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCDepsitDtlWork depsitDtlWork = new DCDepsitDtlWork();

			this.CopyToDepsitDtlWorkFromReaderSCM(ref myReader, ref depsitDtlWork, tableNm);

			return depsitDtlWork;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� depsitDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="depsitDtlWork">depsitDtlWork �I�u�W�F�N�g</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToDepsitDtlWorkFromReaderSCM(ref SqlDataReader myReader, ref DCDepsitDtlWork depsitDtlWork, string tableNm)
		{
			if (myReader != null && depsitDtlWork != null)
			{
				# region �N���X�֊i�[
				depsitDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				depsitDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				depsitDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				depsitDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				depsitDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				depsitDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				depsitDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				depsitDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				depsitDtlWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSRF"));
				depsitDtlWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEPOSITSLIPNORF"));
				depsitDtlWork.DepositRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEPOSITROWNORF"));
				depsitDtlWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "MONEYKINDCODERF"));
				depsitDtlWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MONEYKINDNAMERF"));
				depsitDtlWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "MONEYKINDDIVRF"));
				depsitDtlWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DEPOSITRF"));
				depsitDtlWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "VALIDITYTERMRF"));
				# endregion
			}
		}
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �������׃f�[�^�폜
        /// </summary>
        /// <param name="dcDepsitDtlWorkList">�������׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Delete(ArrayList dcDepsitDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcDepsitDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �������׃f�[�^�폜
        /// </summary>
        /// <param name="dcDepsitDtlWorkList">�������׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcDepsitDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCDepsitDtlWork dcDepsitDtlWork in dcDepsitDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                /* --- DEL 2009/04/27 ---------->>>>>
               sqlCommand.CommandText = "DELETE FROM DEPSITDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND DEPOSITROWNORF=@FINDDEPOSITROWNO";
                --- DEL 2009/04/27 ----------<<<<< */
                sqlCommand.CommandText = "DELETE FROM DEPSITDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"; //ADD 2009/04/27 �����s�ԍ�->�폜����

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                //SqlParameter findParaDepositRowNo = sqlCommand.Parameters.Add("@FINDDEPOSITROWNO", SqlDbType.Int);// DEL 2009/04/27

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = dcDepsitDtlWork.EnterpriseCode;
                findParaAcptAnOdrStatus.Value = dcDepsitDtlWork.AcptAnOdrStatus;
                findParaDepositSlipNo.Value = dcDepsitDtlWork.DepositSlipNo;
                //findParaDepositRowNo.Value = dcDepsitDtlWork.DepositRowNo;// DEL 2009/04/27

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �������׃f�[�^���폜����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �������׃f�[�^�o�^
        /// </summary>
        /// <param name="dcDepsitDtlWorkList">�������׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Insert(ArrayList dcDepsitDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcDepsitDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �������׃f�[�^�o�^
        /// </summary>
        /// <param name="dcDepsitDtlWorkList">�������׃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcDepsitDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCDepsitDtlWork dcDepsitDtlWork in dcDepsitDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO DEPSITDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, MONEYKINDCODERF, MONEYKINDNAMERF, MONEYKINDDIVRF, DEPOSITRF, VALIDITYTERMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACPTANODRSTATUS, @DEPOSITSLIPNO, @DEPOSITROWNO, @MONEYKINDCODE, @MONEYKINDNAME, @MONEYKINDDIV, @DEPOSIT, @VALIDITYTERM)";
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
                SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                SqlParameter paraDepositRowNo = sqlCommand.Parameters.Add("@DEPOSITROWNO", SqlDbType.Int);
                SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcDepsitDtlWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcDepsitDtlWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcDepsitDtlWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcDepsitDtlWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcDepsitDtlWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcDepsitDtlWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcDepsitDtlWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcDepsitDtlWork.LogicalDeleteCode);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dcDepsitDtlWork.AcptAnOdrStatus);
                paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(dcDepsitDtlWork.DepositSlipNo);
                paraDepositRowNo.Value = SqlDataMediator.SqlSetInt32(dcDepsitDtlWork.DepositRowNo);
                paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(dcDepsitDtlWork.MoneyKindCode);
                paraMoneyKindName.Value = SqlDataMediator.SqlSetString(dcDepsitDtlWork.MoneyKindName);
                paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(dcDepsitDtlWork.MoneyKindDiv);
                paraDeposit.Value = SqlDataMediator.SqlSetInt64(dcDepsitDtlWork.Deposit);
                paraValidityTerm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcDepsitDtlWork.ValidityTerm);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �������׃f�[�^��o�^����
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
            //sqlCommand.CommandText = "DELETE FROM DEPSITDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM DEPSITDTLRF WHERE   EXISTS ").Append(Environment.NewLine);
            sb.Append("(SELECT DEPSITDTLRF.ACPTANODRSTATUSRF FROM DEPSITMAINRF  WHERE DEPSITMAINRF.ENTERPRISECODERF=@FINDENTERPRISECODE ").Append(Environment.NewLine);
            sb.Append(" AND DEPSITMAINRF.ENTERPRISECODERF = DEPSITDTLRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" AND DEPSITMAINRF.ACPTANODRSTATUSRF = DEPSITDTLRF.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            sb.Append(" AND DEPSITMAINRF.DEPOSITSLIPNORF = DEPSITDTLRF.DEPOSITSLIPNORF ").Append(Environment.NewLine);
            sb.Append(" AND DEPSITMAINRF.ADDUPSECCODERF = @FINDSECTIONCODERF) ").Append(Environment.NewLine);
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
