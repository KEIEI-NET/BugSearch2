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
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
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
    /// �󒍃}�X�^READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^���M����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class APAcceptOdrDB : RemoteDB
    {
        /// <summary>
        /// �󒍃}�X�^READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APAcceptOdrDB()
        {
        }
        #region [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
// DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �󒍃}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="acceptOdrArrList">�󒍃}�X�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchAcceptOdr(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList acceptOdrArrList, out string retMessage)
        {
            return SearchAcceptOdrProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  acceptOdrArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �󒍃}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="acceptOdrArrList">�󒍃}�X�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchAcceptOdrProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList acceptOdrArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            acceptOdrArrList = new ArrayList();
            APAcceptOdrWork acceptOdrWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, DATAINPUTSYSTEMRF, COMMONSEQNORF, SLIPDTLNUMRF, SLIPDTLNUMDERIVNORF, SRCLINKDATACODERF, SRCSLIPDTLNUMRF FROM ACCEPTODRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // �󒍃}�X�^�pSQL
				sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    acceptOdrWork = new APAcceptOdrWork();

                    acceptOdrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    acceptOdrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    acceptOdrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    acceptOdrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    acceptOdrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    acceptOdrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    acceptOdrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    acceptOdrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    acceptOdrWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    acceptOdrWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                    acceptOdrWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    acceptOdrWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    acceptOdrWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                    acceptOdrWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    acceptOdrWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPDTLNUMRF"));
                    acceptOdrWork.SlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDTLNUMDERIVNORF"));
                    acceptOdrWork.SrcLinkDataCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCLINKDATACODERF"));
                    acceptOdrWork.SrcSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SRCSLIPDTLNUMRF"));


                    acceptOdrArrList.Add(acceptOdrWork);
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
        /// �󒍃f�[�^�X�V
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="acceptOdrList">�󒍃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int UpdateAcceptOdr(string enterPriseCode, ArrayList acceptOdrList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateAcceptOdrProc(enterPriseCode, acceptOdrList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �󒍃f�[�^�X�V
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="acceptOdrList">�󒍃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int UpdateAcceptOdrProc(string enterPriseCode, ArrayList acceptOdrList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �S�ăf�[�^���폜����
            status = DeleteAcceptOdr(enterPriseCode, acceptOdrList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �o�^����
                status = InsertAcceptOdr(enterPriseCode, acceptOdrList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �󒍃f�[�^�폜
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="acceptOdrList">�󒍃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int DeleteAcceptOdr(string enterPriseCode, ArrayList acceptOdrList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteAcceptOdrProc(enterPriseCode, acceptOdrList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �󒍃f�[�^�폜
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="acceptOdrList">�󒍃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int DeleteAcceptOdrProc(string enterPriseCode, ArrayList acceptOdrList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APAcceptOdrWork acceptOdrWork in acceptOdrList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM ACCEPTODRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND COMMONSEQNORF=@FINDCOMMONSEQNO AND SLIPDTLNUMRF=@FINDSLIPDTLNUM AND SLIPDTLNUMDERIVNORF=@FINDSLIPDTLNUMDERIVNO";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                SqlParameter findParaCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                SqlParameter findParaSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter findParaSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@FINDSLIPDTLNUMDERIVNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaSectionCode.Value = acceptOdrWork.SectionCode;
                findParaAcptAnOdrStatus.Value = acceptOdrWork.AcptAnOdrStatus;
                findParaDataInputSystem.Value = acceptOdrWork.DataInputSystem;
                findParaCommonSeqNo.Value = acceptOdrWork.CommonSeqNo;
                findParaSlipDtlNum.Value = acceptOdrWork.SlipDtlNum;
                findParaSlipDtlNumDerivNo.Value = acceptOdrWork.SlipDtlNumDerivNo;

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
        /// �󒍃f�[�^�V�K
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="acceptOdrList">�󒍃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int InsertAcceptOdr(string enterPriseCode, ArrayList acceptOdrList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertAcceptOdrProc(enterPriseCode, acceptOdrList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �󒍃f�[�^�V�K
        /// </summary>
        /// <param name="enterPriseCode">���_�R�[�h</param>
        /// <param name="acceptOdrList">�󒍃f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int InsertAcceptOdrProc(string enterPriseCode, ArrayList acceptOdrList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APAcceptOdrWork acceptOdrWork in acceptOdrList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO ACCEPTODRRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, DATAINPUTSYSTEMRF, COMMONSEQNORF, SLIPDTLNUMRF, SLIPDTLNUMDERIVNORF, SRCLINKDATACODERF, SRCSLIPDTLNUMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @DATAINPUTSYSTEM, @COMMONSEQNO, @SLIPDTLNUM, @SLIPDTLNUMDERIVNO, @SRCLINKDATACODE, @SRCSLIPDTLNUM)";

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
                SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                SqlParameter paraSlipDtlNum = sqlCommand.Parameters.Add("@SLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter paraSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@SLIPDTLNUMDERIVNO", SqlDbType.Int);
                SqlParameter paraSrcLinkDataCode = sqlCommand.Parameters.Add("@SRCLINKDATACODE", SqlDbType.Int);
                SqlParameter paraSrcSlipDtlNum = sqlCommand.Parameters.Add("@SRCSLIPDTLNUM", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(acceptOdrWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptOdrWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptOdrWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptOdrWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(acceptOdrWork.SectionCode);
                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrWork.AcceptAnOrderNo);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrWork.AcptAnOdrStatus);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(acceptOdrWork.SalesSlipNum);
                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrWork.DataInputSystem);
                paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptOdrWork.CommonSeqNo);
                paraSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptOdrWork.SlipDtlNum);
                paraSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrWork.SlipDtlNumDerivNo);
                paraSrcLinkDataCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrWork.SrcLinkDataCode);
                paraSrcSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptOdrWork.SrcSlipDtlNum);

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
		/// �N���X�i�[���� Reader �� acceptOdrWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>�I�u�W�F�N�g</returns>
		public APAcceptOdrWork CopyToAcceptOdrWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			APAcceptOdrWork acceptOdrWork = new APAcceptOdrWork();

			this.CopyToAcceptOdrWorkFromReaderSCM(ref myReader, ref acceptOdrWork, tableNm);

			return acceptOdrWork;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� acceptOdrWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="acceptOdrWork">acceptOdrWork �I�u�W�F�N�g</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToAcceptOdrWorkFromReaderSCM(ref SqlDataReader myReader, ref APAcceptOdrWork acceptOdrWork, string tableNm)
		{
			if (myReader != null && acceptOdrWork != null)
			{
				# region �N���X�֊i�[
				acceptOdrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				acceptOdrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				acceptOdrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				acceptOdrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				acceptOdrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				acceptOdrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				acceptOdrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				acceptOdrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				acceptOdrWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				acceptOdrWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCEPTANORDERNORF"));
				acceptOdrWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSRF"));
				acceptOdrWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPNUMRF"));
				acceptOdrWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DATAINPUTSYSTEMRF"));
				acceptOdrWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "COMMONSEQNORF"));
				acceptOdrWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SLIPDTLNUMRF"));
				acceptOdrWork.SlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPDTLNUMDERIVNORF"));
				acceptOdrWork.SrcLinkDataCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SRCLINKDATACODERF"));
				acceptOdrWork.SrcSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SRCSLIPDTLNUMRF"));
				# endregion
			}
		}
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
    }
}
