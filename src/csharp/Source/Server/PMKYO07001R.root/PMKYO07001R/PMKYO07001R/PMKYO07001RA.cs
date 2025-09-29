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
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/25  �C�����e : #23998�@�݌Ɉړ��f�[�^�̎�M�敪�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/09/08  �C�����e : Redmine #24562 �d�����׃f�[�^�̑��M�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/09/15  �C�����e : Redmine #24562 �d�����׃f�[�^�̑��M�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/09/22  �C�����e : #25443�@�݌Ɉړ��̃V�F�A�`�F�b�N�̃t���O�ݒ�s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/01  �C�����e : Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine#8293 ���_�Ǘ��^�`�[���t���t���o����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/12/06  �C�����e : Redmine#8293 ��ʂ̏I�����t�{�V�X�e�������d�l�̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : zhlj
// �C �� ��  2013/02/07  �C�����e : 10900690-00 2013/3/13�z�M���ً̋}�Ή�
//                                  Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �f�[�^���M����READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^���M����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br></br>
    /// <br>Update Note: SCM�Ή� - ���_�Ǘ�(10704767-00) ��M���X�V������ǉ�</br>
    /// <br>Programmer : qijh</br>
    /// <br>Date       : 2011/08/10</br>
    /// <br>Update Note: Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�</br>
    /// <br>Programmer : ���|��</br>
    /// <br>Date       : 2011/11/01</br>
    /// <br>Update Note: 10900690-00 2012/3/13�z�M���ً̋}�Ή�</br>
    /// <br>           : Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�</br>
    /// <br>Programmer : zhlj</br>
    /// <br>Date       : 2013/02/07</br>
    /// </remarks>
    [Serializable]
	public class APSendMessageDB : RemoteWithAppLockDB, IAPSendMessageDB
    {
        // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>
        private SecMngSndRcvDB _SecMngSndRcvDB = null;
        /// <summary>
        /// ���_�Ǘ�����M�Ώېݒ�}�X�^�����[�g�v���p�e�B
        /// </summary>
        private SecMngSndRcvDB ScMngSndRcvDB
        {
            get
            {
                if (this._SecMngSndRcvDB == null)
                    this._SecMngSndRcvDB = new SecMngSndRcvDB();
                return this._SecMngSndRcvDB;
            }
        }
        // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<

        /// <summary>
        /// �f�[�^���M����READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APSendMessageDB()
        {
        }

        #region �� �f�[�^���M�̉�ʂ̏������f�[�^�������� ��
        /// <summary>
        /// �f�[�^���M�̉�ʂ̏������f�[�^��������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
		/// <param name="secMngSetWorkList">�����p�����[�^</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M��ʂ̏������f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
		//public int SearchLoadData(string enterpriseCodes, out APSecMngSetWork secMngSetWork, out string retMessage)
		public int SearchLoadData(string enterpriseCodes, out ArrayList secMngSetWorkList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;
			//secMngSetWork = new APSecMngSetWork();
			secMngSetWorkList = new ArrayList();

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
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				//sqlStr = "SELECT SECMNGSETRF.SECTIONCODERF, SECMNGSETRF.SYNCEXECDATERF, SECINFOSETRF.SECTIONGUIDENMRF FROM SECMNGSETRF, SECINFOSETRF WHERE SECMNGSETRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND SECMNGSETRF.KINDRF=@FINDKINDRF AND SECMNGSETRF.RECEIVECONDITIONRF=@FINDRECEIVECONDITIONRF AND SECMNGSETRF.ENTERPRISECODERF = SECINFOSETRF.ENTERPRISECODERF AND SECMNGSETRF.SECTIONCODERF = SECINFOSETRF.SECTIONCODERF AND SECMNGSETRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECINFOSETRF.LOGICALDELETECODERF=@FINDSECINFOLOGICALDELETECODE";
				sqlStr = "SELECT SECMNGSETRF.SECTIONCODERF, SECMNGSETRF.SENDDESTSECCODERF, SECMNGSETRF.SYNCEXECDATERF, SECMNGSETRF.AUTOSENDDIVRF FROM SECMNGSETRF  WHERE SECMNGSETRF.ENTERPRISECODERF=@FINDENTERPRISECODE  AND SECMNGSETRF.KINDRF=@FINDKINDRF  AND SECMNGSETRF.RECEIVECONDITIONRF=@FINDRECEIVECONDITIONRF  AND SECMNGSETRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECMNGSETRF.SECTIONCODERF, SECMNGSETRF.SENDDESTSECCODERF";
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);
                SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITIONRF", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				//SqlParameter paraSecinfoLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDSECINFOLOGICALDELETECODE", SqlDbType.Int);// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                paraKind.Value = SqlDataMediator.SqlSetInt32(0);
                paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(0);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
				//paraSecinfoLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j

                sqlCommand.CommandText = sqlStr;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
                {
					APSecMngSetWork secMngSetWork = new APSecMngSetWork();
                    secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
					//secMngSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
					secMngSetWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTSECCODERF"));
					secMngSetWork.AutoSendFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
					secMngSetWorkList.Add(secMngSetWork);
					// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
        #endregion �� �f�[�^���M�̉�ʂ̏������f�[�^�������� ��

        #region �� ���_�Ǘ��ݒ�}�X�^�̍X�V���� ��
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�̍X�V����
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="syncExecDt">���s����</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
		/// <param name="baseCode">baseCode</param>
		/// <param name="sendCode">sendCode</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̍X�V�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
		// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>
		//public int UpdateSecMngSet(string enterpriseCodes, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
		public int UpdateSecMngSet(string enterpriseCodes, string updEmployeeCode, DateTime syncExecDt, out string retMessage, string baseCode, string sendCode)
		// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
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
                sqlCommand = new SqlCommand("", sqlConnection);

                if (string.IsNullOrEmpty(updEmployeeCode))
                {
                    // ���_�Ǘ��ݒ�}�X�^���X�V����
					// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>
					//sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
					sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SENDDESTSECCODERF=@FINDSENDDESTSECCODE";
                   // UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<

					//Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }
                else
                {
                    // ���_�Ǘ��ݒ�}�X�^���X�V����
					// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>
					//sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
					sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SENDDESTSECCODERF=@FINDSENDDESTSECCODE";
					// UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updEmployeeCode);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }



                //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>
				SqlParameter findParaSectionCd = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				SqlParameter findParaSectionDestCd = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaKind.Value = SqlDataMediator.SqlSetInt32(0);
                findParaReceiveCondition.Value = SqlDataMediator.SqlSetInt32(0);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>
				findParaSectionCd.Value = SqlDataMediator.SqlSetString(baseCode);
				findParaSectionDestCd.Value = SqlDataMediator.SqlSetString(sendCode);
				// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<


                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // ���_�Ǘ��ݒ�}�X�^���X�V����
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.ShipmentDirections Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
        #endregion �� ���_�Ǘ��ݒ�}�X�^�̍X�V���� ��

        #region �� �f�[�^���M�̃f�[�^�������� ��
        #region [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        /// <summary>
        /// �f�[�^���M�̃f�[�^��������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n����</param>
        /// <param name="endingDate">�I������</param>
        /// <param name="retCSAList">��������</param>
        /// <param name="fileIds">�t�@�C��ID�z��</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
		public int SearchCustomSerializeArrayList(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, string[] fileIds, out string retMessage)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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

                retCSAList = new CustomSerializeArrayList();

                foreach (string fileId in fileIds)
                {
                    switch (fileId)
                    {
                        // ����f�[�^
                        case "SalesSlipRF":
                            // ����f�[�^���o
                            ArrayList salesSlipArrList = new ArrayList();
                            APSalesSlipDB _salesSlipDB = new APSalesSlipDB();
                            status = _salesSlipDB.SearchSalesSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out salesSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(salesSlipArrList);
                            }
                            break;
                        // ���㖾�׃f�[�^
                        case "SalesDetailRF":
                            // ���㖾�׃f�[�^���o
                            ArrayList salesDetailArrList = new ArrayList();
                            APSalesDetailDB _salesDetailDB = new APSalesDetailDB();
                            status = _salesDetailDB.SearchSalesDetail(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out salesDetailArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(salesDetailArrList);
                            }
                            break;
                        // ���㗚���f�[�^
                        case "SalesHistoryRF":
                            // ���㗚���f�[�^���o
                            ArrayList salesHistoryArrList = new ArrayList();
                            APSalesHistoryDB _salesHistoryDB = new APSalesHistoryDB();
                            status = _salesHistoryDB.SearchSalesHistory(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out salesHistoryArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(salesHistoryArrList);
                            }
                            break;
                        // ���㗚�𖾍׃f�[�^
                        case "SalesHistDtlRF":
                            // ���㗚�𖾍׃f�[�^���o
                            ArrayList salesHistDtlArrList = new ArrayList();
                            APSalesHistDtlDB _salesHistDtlDB = new APSalesHistDtlDB();
                            status = _salesHistDtlDB.SearchSalesHistDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out salesHistDtlArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(salesHistDtlArrList);
                            }
                            break;
                        // �����f�[�^
                        case "DepsitMainRF":
                            // �����f�[�^���o
                            ArrayList depsitMainArrList = new ArrayList();
                            APDepsitMainDB _depsitMainDB = new APDepsitMainDB();
                            status = _depsitMainDB.SearchDepsitMain(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out depsitMainArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(depsitMainArrList);
                            }
                            break;
                        // �������׃f�[�^
                        case "DepsitDtlRF":
                            // �������׃f�[�^���o
                            ArrayList depsitDtlArrList = new ArrayList();
                            APDepsitDtlDB _depsitDtlDB = new APDepsitDtlDB();
                            status = _depsitDtlDB.SearchDepsitDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out depsitDtlArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(depsitDtlArrList);
                            }
                            break;
                        // �d���f�[�^
                        case "StockSlipRF":
                            // �d���f�[�^���o
                            ArrayList stockSlipArrList = new ArrayList();
                            APStockSlipDB _stockSlipDB = new APStockSlipDB();
                            status = _stockSlipDB.SearchStockSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockSlipArrList);
                            }
                            break;
                        // �d�����׃f�[�^
                        case "StockDetailRF":
                            // �d�����׃f�[�^���o
                            ArrayList stockDetailArrList = new ArrayList();
                            APStockDetailDB _stockDetailDB = new APStockDetailDB();
                            status = _stockDetailDB.SearchStockDetail(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockDetailArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockDetailArrList);
                            }
                            break;
                        // �d�������f�[�^
                        case "StockSlipHistRF":
                            // �d�������f�[�^���o
                            ArrayList stockSlipHistArrList = new ArrayList();
                            APStockSlipHistDB _stockSlipHistDB = new APStockSlipHistDB();
                            status = _stockSlipHistDB.SearchStockSlipHist(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockSlipHistArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockSlipHistArrList);
                            }
                            break;
                        // �d�����𖾍׃f�[�^
                        case "StockSlHistDtlRF":
                            // �d�����𖾍׃f�[�^���o
                            ArrayList stockSlHistDtlArrList = new ArrayList();
                            APStockSlHistDtlDB _stockSlHistDtlDB = new APStockSlHistDtlDB();
                            status = _stockSlHistDtlDB.SearchStockSlHistDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockSlHistDtlArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockSlHistDtlArrList);
                            }
                            break;
                        // �x���`�[�}�X�^
                        case "PaymentSlpRF":
                            // �x���`�[�}�X�^���o
                            ArrayList paymentSlpArrList = new ArrayList();
                            APPaymentSlpDB _paymentSlpDB = new APPaymentSlpDB();
                            status = _paymentSlpDB.SearchPaymentSlp(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out paymentSlpArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(paymentSlpArrList);
                            }
                            break;
                        // �x�����׃f�[�^
                        case "PaymentDtlRF":
                            // �x�����׃f�[�^���o
                            ArrayList paymentDtlArrList = new ArrayList();
                            APPaymentDtlDB _paymentDtlDB = new APPaymentDtlDB();
                            status = _paymentDtlDB.SearchPaymentDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out paymentDtlArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(paymentDtlArrList);
                            }
                            break;
                        // �󒍃}�X�^
                        case "AcceptOdrRF":
                            // �󒍃}�X�^���o
                            ArrayList acceptOdrArrList = new ArrayList();
                            APAcceptOdrDB _acceptOdrDB = new APAcceptOdrDB();
                            status = _acceptOdrDB.SearchAcceptOdr(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out acceptOdrArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(acceptOdrArrList);
                            }
                            break;
                        // �󒍃}�X�^�i�ԗ��j
                        case "AcceptOdrCarRF":
                            // �󒍃}�X�^�i�ԗ��j���o
                            ArrayList acceptOdrCarArrList = new ArrayList();
                            APAcceptOdrCarDB _acceptOdrCarDB = new APAcceptOdrCarDB();
                            status = _acceptOdrCarDB.SearchAcceptOdrCar(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out acceptOdrCarArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(acceptOdrCarArrList);
                            }
                            break;
                        // ���㌎���W�v�f�[�^
                        case "MTtlSalesSlipRF":
                            // ���㌎���W�v�f�[�^���o
                            ArrayList mTtlSalesSlipArrList = new ArrayList();
                            APMTtlSalesSlipDB _mTtlSalesSlipDB = new APMTtlSalesSlipDB();
                            status = _mTtlSalesSlipDB.SearchMTtlSalesSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out mTtlSalesSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(mTtlSalesSlipArrList);
                            }
                            break;
                        // ���i�ʔ��㌎���W�v�f�[�^
                        case "GoodsMTtlSaSlipRF":
                            // ���i�ʔ��㌎���W�v�f�[�^���o
                            ArrayList goodsMTtlSaSlipArrList = new ArrayList();
                            APGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = new APGoodsMTtlSaSlipDB();
                            status = _goodsMTtlSaSlipDB.SearchGoodsMTtlSaSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsMTtlSaSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(goodsMTtlSaSlipArrList);
                            }
                            break;
                        // �d�������W�v�f�[�^
                        case "MTtlStockSlipRF":
                            // �d�������W�v�f�[�^
                            ArrayList mTtlStockSlipArrList = new ArrayList();
                            APMTtlStockSlipDB _mTtlStockSlipDB = new APMTtlStockSlipDB();
                            status = _mTtlStockSlipDB.SearchMTtlStockSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out mTtlStockSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(mTtlStockSlipArrList);
                            }
                            break;
                        // �݌ɒ����f�[�^
                        case "StockAdjustRF":
                            // �݌ɒ����f�[�^
                            ArrayList stockAdjustArrList = new ArrayList();
                            APStockAdjustDB _stockAdjustDB = new APStockAdjustDB();
							status = _stockAdjustDB.SearchStockAdjust(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage); 
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockAdjustArrList);
                            }
                            break;
                        // �݌ɒ������׃f�[�^
                        case "StockAdjustDtlRF":
                            // �݌ɒ������׃f�[�^
                            ArrayList stockAdjustDtlArrList = new ArrayList();
							APStockAdjustDtlDB _stockAdjustDtlDB = new APStockAdjustDtlDB();
							status = _stockAdjustDtlDB.SearchStockAdjustDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockAdjustDtlArrList);
                            }
                            break;
                        // �݌Ɉړ��f�[�^
                        case "StockMoveRF":
                            // �݌Ɉړ��f�[�^
                            ArrayList stockMoveArrList = new ArrayList();
                            APStockMoveDB _stockMoveDB = new APStockMoveDB();
							status = _stockMoveDB.SearchStockMove(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockMoveArrList);
                            }
                            break;
                        // �݌Ɏ󕥗����f�[�^
                        case "StockAcPayHistRF":
                            // �݌Ɏ󕥗����f�[�^
                            ArrayList stockAcPayHistArrList = new ArrayList();
                            APStockAcPayHistDB _stockAcPayHistDB = new APStockAcPayHistDB();
							status = _stockAcPayHistDB.SearchStockAcPayHist(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockAcPayHistArrList, out retMessage);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockAcPayHistArrList);
                            }
                            break;
                    }
                }
                return status;
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
                retMessage = ex.Message;
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
            }
            return status;
        }
		*/
        // DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

        // ADD 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
        /// �f�[�^���M�̃f�[�^��������
        /// </summary>
		/// <param name="retCSAList">��������</param>
		/// <param name="paraSendDataWork">���M�f�[�^</param>
		/// <param name="sectionCode">sectionCode</param>
        /// <param name="fileIds">�t�@�C��ID�z��</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
		/// <param name="sndRcvHisConsNo">sndRcvHisConsNo</param>
		/// <param name="updSectionCd">updSectionCd</param>
        /// <returns>STATUS</returns>
		public int SearchCustomSerializeArrayListSCM(out CustomSerializeArrayList retCSAList, APSendDataWork paraSendDataWork,
			string sectionCode, string[] fileIds, out string retMessage, out int sndRcvHisConsNo, string updSectionCd)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retCSAList = new CustomSerializeArrayList();
            retMessage = string.Empty;
			sndRcvHisConsNo = -1; 

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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

				ArrayList resultList = new ArrayList();
				ArrayList saleAcpOdrList = new ArrayList();
				ArrayList stockAcpOdrList = new ArrayList();

                foreach (string fileId in fileIds)
                {
                    switch (fileId)
                    {
						case "SalesSlipRF":
							{
								// ����f�[�^�A���㖾�׃f�[�^�A�󒍃}�X�^�A�󒍃}�X�^�i�ԗ��j
								APSalesSlipDB _salesSlipDB = new APSalesSlipDB();
								paraSendDataWork.DoSalesSlipFlg = true;
								paraSendDataWork.DoStockDetailFlg = true;
								paraSendDataWork.DoAcceptOdrFlg = true;
								paraSendDataWork.DoAcceptOdrCarFlg = true;

								status = _salesSlipDB.SearchSCM(out resultList,out saleAcpOdrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
								if (resultList != null && resultList.Count > 0)
								{
									for (int i = 0; i < resultList.Count; i++)
									{
										(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
									}
								}
							}
							break;
                        case "SalesHistoryRF":
							// ���㗚���f�[�^�A���㗚�𖾍׃f�[�^
                            APSalesHistoryDB _salesHistoryDB = new APSalesHistoryDB();
							paraSendDataWork.DoSalesHistoryFlg = true;
							paraSendDataWork.DoSalesHistDtlFlg = true;
							status = _salesHistoryDB.SearchSCM(out resultList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
                            break;

                        case "DepsitMainRF":
							// �����f�[�^�A�������׃f�[�^
                            APDepsitMainDB _depsitMainDB = new APDepsitMainDB();
							paraSendDataWork.DoDepsitMainFlg = true;
							paraSendDataWork.DoDepsitDtlFlg = true;
							status = _depsitMainDB.SearchSCM(out resultList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
                            break;

                        case "StockSlipRF":
							// �d���f�[�^�A�d�����׃f�[�^,�󒍃}�X�^
                            APStockSlipDB _stockSlipDB = new APStockSlipDB();
							paraSendDataWork.DoStockSlipFlg = true;
							paraSendDataWork.DoStockDetailFlg = true;
							paraSendDataWork.DoAcceptOdrFlg = true;
							//ArrayList newStockDtlList = new ArrayList();// DEL 2011/09/15
							//status = _stockSlipDB.SearchSCM(out resultList,out newStockDtlList, out stockAcpOdrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);// DEL 2011/09/15
							status = _stockSlipDB.SearchSCM(out resultList, out stockAcpOdrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);// ADD 2011/09/15
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
							// DEL 2011/09/15 ----------- >>>>>
							//// ADD 2011.09.08 ----------- >>>>>
							//// �d�����ׂ݂̂̏ꍇ
							//ArrayList onlyStockDtlList = new ArrayList();
							//APStockDetailDB aPSalesHistDtlDB = new APStockDetailDB();
							//string retMsg = string.Empty;
							//status = aPSalesHistDtlDB.SearchStockDetail(paraSendDataWork.PmSectionCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out onlyStockDtlList, out retMsg);
							//if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							//{
							//    if (onlyStockDtlList != null && onlyStockDtlList.Count > 0)
							//    {
							//        foreach (APStockDetailWork tmpWork in onlyStockDtlList)
							//        {
							//            newStockDtlList.Add(tmpWork);
							//        }
							//    }
							//}
							//(retCSAList as CustomSerializeArrayList).Add(newStockDtlList);
							//// ADD 2011.09.08 ----------- <<<<<
							// DEL 2011/09/15 ----------- <<<<<
                            break;

                        case "StockSlipHistRF":
							// �d�������f�[�^�A�d�����𖾍׃f�[�^
                            APStockSlipHistDB _stockSlipHistDB = new APStockSlipHistDB();
							paraSendDataWork.DoStockSlipHistFlg = true;
							paraSendDataWork.DoStockSlHistDtlFlg = true;
							status = _stockSlipHistDB.SearchSCM(out resultList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
                            break;
                        case "PaymentSlpRF":
							// �x���`�[�}�X�^,�A�x�����׃f�[�^
                            APPaymentSlpDB _paymentSlpDB = new APPaymentSlpDB();
							paraSendDataWork.DoPaymentSlpFlg = true;
							paraSendDataWork.DoPaymentDtlFlg = true;
							status = _paymentSlpDB.SearchSCM(out resultList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
                            break;

                        // ----- DEL 2011/11/01 xupz------->>>>>>
                        //// �݌ɒ����f�[�^
                        //case "StockAdjustRF":
                        //    // �݌ɒ����f�[�^
                        //    ArrayList stockAdjustArrList = new ArrayList();
                        //    APStockAdjustDB _stockAdjustDB = new APStockAdjustDB();
                        //    status = _stockAdjustDB.SearchStockAdjustSCM(paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage, paraSendDataWork.PmSectionCode);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        (retCSAList as CustomSerializeArrayList).Add(stockAdjustArrList);
                        //    }
                        //    break;
                        // ----- DEL 2011/11/01 xupz-------<<<<<<

                        // ----- ADD 2011/11/01 xupz------->>>>>>
                        // �݌ɒ����f�[�^
                        case "StockAdjustRF":
                            // �݌ɒ����f�[�^
                            ArrayList stockAdjustArrList = new ArrayList();
                            APStockAdjustDB _stockAdjustDB = new APStockAdjustDB();
                            //status = _stockAdjustDB.SearchStockAdjustSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage, paraSendDataWork.PmSectionCode);  // DEL 2011/11/30
                            //status = _stockAdjustDB.SearchStockAdjustSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/11/30 // DEL 2011/11/06
                            status = _stockAdjustDB.SearchStockAdjustSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, paraSendDataWork.EndDateTimeTicks, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/12/06
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
								(retCSAList as CustomSerializeArrayList).Add(stockAdjustArrList);
                            }
                            break;
                        // ----- ADD 2011/11/01 xupz-------<<<<<<

                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        // �݌ɒ������׃f�[�^
                        //case "StockAdjustDtlRF":
                        //    // �݌ɒ������׃f�[�^
                        //    ArrayList stockAdjustDtlArrList = new ArrayList();
                        //    APStockAdjustDtlDB _stockAdjustDtlDB = new APStockAdjustDtlDB();
                        //    status = _stockAdjustDtlDB.SearchStockAdjustDtlSCM(paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage, paraSendDataWork.PmSectionCode);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        (retCSAList as CustomSerializeArrayList).Add(stockAdjustDtlArrList);
                        //    }
                        //    break;
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz------->>>>>>
                        // �݌ɒ������׃f�[�^
                        case "StockAdjustDtlRF":
                            // �݌ɒ������׃f�[�^
                            ArrayList stockAdjustDtlArrList = new ArrayList();
							APStockAdjustDtlDB _stockAdjustDtlDB = new APStockAdjustDtlDB();
                            //status = _stockAdjustDtlDB.SearchStockAdjustDtlSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage, paraSendDataWork.PmSectionCode);  // DEL 2011/11/30
                            //status = _stockAdjustDtlDB.SearchStockAdjustDtlSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/11/30 // DEL 2011/12/06
                            status = _stockAdjustDtlDB.SearchStockAdjustDtlSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, paraSendDataWork.EndDateTimeTicks, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/12/06
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                (retCSAList as CustomSerializeArrayList).Add(stockAdjustDtlArrList);
                            }
                            break;
                        // ----- ADD 2011/11/01 xupz-------<<<<<<

                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //// �݌Ɉړ��f�[�^
                        //case "StockMoveRF":
                        //    // �݌Ɉړ��f�[�^
                        //    ArrayList stockMoveArrList = new ArrayList();
                        //    APStockMoveDB _stockMoveDB = new APStockMoveDB();
                        //    status = _stockMoveDB.SearchStockMoveSCM(paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage, paraSendDataWork.PmSectionCode);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        (retCSAList as CustomSerializeArrayList).Add(stockMoveArrList);
                        //    }
                        //    break;
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz------->>>>>>
                        // �݌Ɉړ��f�[�^
                        case "StockMoveRF":
                            // �݌Ɉړ��f�[�^
                            ArrayList stockMoveArrList = new ArrayList();
                            APStockMoveDB _stockMoveDB = new APStockMoveDB();
                            //status = _stockMoveDB.SearchStockMoveSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage, paraSendDataWork.PmSectionCode);  // DEL 2011/11/30
                            //status = _stockMoveDB.SearchStockMoveSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/11/30 // DEL 2011/12/06
                            status = _stockMoveDB.SearchStockMoveSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, paraSendDataWork.EndDateTimeTicks, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/12/06
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                (retCSAList as CustomSerializeArrayList).Add(stockMoveArrList);
                            }
                            break;					
                        // ----- ADD 2011/11/01 xupz-------<<<<<<

						case "DepositAlwRF":
							{
								// ���������}�X�^
								ArrayList depositAlwArrList = new ArrayList();
								APDepositAlwDB _depositAlwDB = new APDepositAlwDB();
								status = _depositAlwDB.Search(out depositAlwArrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									(retCSAList as CustomSerializeArrayList).Add(depositAlwArrList);
								}
							}
							break;
						case "RcvDraftDataRF":
							{
								// ����`�f�[�^
								ArrayList rcvDraftDataArrList = new ArrayList();
								APRcvDraftDataDB _rcvDraftDataDB = new APRcvDraftDataDB();
								status = _rcvDraftDataDB.Search(out rcvDraftDataArrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									(retCSAList as CustomSerializeArrayList).Add(rcvDraftDataArrList);
								}
							}
							break;
						case "PayDraftDataRF":
							{
								// �x����`�f�[�^
								ArrayList payDraftDataArrList = new ArrayList();
								APPayDraftDataDB _payDraftDataDB = new APPayDraftDataDB();
								status = _payDraftDataDB.Search(out payDraftDataArrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									(retCSAList as CustomSerializeArrayList).Add(payDraftDataArrList);
								}
							}
							break;

						default:
							break;

                    }
                }

				if(paraSendDataWork.DoAcceptOdrFlg)
				{
					for (int cnt = 0; cnt < stockAcpOdrList.Count; cnt++)
					{
						saleAcpOdrList.Add(stockAcpOdrList[cnt]);
					}

					(retCSAList as CustomSerializeArrayList).Add(saleAcpOdrList);
				}

                //if (retCSAList.Count > 0) // DEL 2013/02/07 zhlj For Redmine#34588
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
                // ���M�ԍ��𐶐�����ꍇ(SndNoCreateDiv==0)
                if (retCSAList.Count > 0 && paraSendDataWork.SndNoCreateDiv == 0)
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
                {
                    //����M�������O���M�ԍ�
                    long no = -1;
                    NumberingManager numberingManager = new NumberingManager();
                    SerialNumberCode serialnumcd = SerialNumberCode.SndRcvHisConsNo;
                    status = numberingManager.GetSerialNumber(paraSendDataWork.PmEnterpriseCode, updSectionCd.Trim(), serialnumcd, out no);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && no != -1)
                    {
                        sndRcvHisConsNo = (int)no;
                    }
                }

                return status;
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
                retMessage = ex.Message;
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
            }
            return status;
        }
		// ADD 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<


        #endregion �� �f�[�^���M�̃f�[�^�������� ��

        #region �� �f�[�^���M�̃f�[�^�X�V���� ��
        /// <summary>
        /// �f�[�^���M�̃f�[�^�X�V����
        /// </summary>
        /// <param name="enterPriseCode">��������</param>
        /// <param name="receiveList">��������</param>
        /// <param name="sectionCodeList">���_���X�g</param>
        /// <param name="stockAcPayHistCount">����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M�̃f�[�^�X�V����</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        public int UpdateCustomSerializeArrayList(string enterPriseCode, object receiveList, ArrayList sectionCodeList, ref int stockAcPayHistCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
			SqlCommand sqlCommand = null;// ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j

            ArrayList _salesSlipList = new ArrayList();                       // ����f�[�^
            ArrayList _salesDetailList = new ArrayList();                     // ���㖾�׃f�[�^
            ArrayList _salesHistoryList = new ArrayList();                    // ���㗚���f�[�^
            ArrayList _salesHistDtlList = new ArrayList();                    // ���㗚�𖾍׃f�[�^
            ArrayList _depsitMainList = new ArrayList();                      // �����f�[�^
            ArrayList _depsitDtlList = new ArrayList();                       // �������׃f�[�^
            ArrayList _stockSlipList = new ArrayList();                       // �d���f�[�^
            ArrayList _stockDetailList = new ArrayList();                     // �d�����׃f�[�^
            ArrayList _stockSlipHistList = new ArrayList();                   // �d�������f�[�^
            ArrayList _stockSlHistDtlList = new ArrayList();                  // �d�����𖾍׃f�[�^
            ArrayList _paymentSlpList = new ArrayList();                      // �x���`�[�}�X�^
            ArrayList _paymentDtlList = new ArrayList();                      // �x�����׃f�[�^
            ArrayList _acceptOdrList = new ArrayList();                       // �󒍃}�X�^
            ArrayList _acceptOdrCarList = new ArrayList();                    // �󒍃}�X�^�i�ԗ��j
            ArrayList _mTtlSalesSlipList = new ArrayList();                   // ���㌎���W�v�f�[�^
            ArrayList _goodsMTtlSaSlipList = new ArrayList();                 // ���i�ʔ��㌎���W�v�f�[�^
            ArrayList _mTtlStockSlipList = new ArrayList();                   // �d�������W�v�f�[�^
            // �� 2009.04.29 liuyang add
            ArrayList _stockAdjustList = new ArrayList();                     // �݌ɒ����f�[�^
            ArrayList _stockAdjustDtlList = new ArrayList();                  // �݌ɒ������׃f�[�^
            ArrayList _stockMoveList = new ArrayList();                       // �݌Ɉړ��f�[�^
            ArrayList _stockAcPayHistList = new ArrayList();                  // �݌Ɏ󕥗����f�[�^
            // �� 2009.04.29 liuyang add
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
			ArrayList _depositAlwList = new ArrayList();                      // ���������}�X�^
			ArrayList _rcvDraftDataList = new ArrayList();                    // ����`�f�[�^
			ArrayList _payDraftDataList = new ArrayList();                    // �x����`�f�[�^�f�[�^
			//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            CustomSerializeArrayList outreceiveList = (CustomSerializeArrayList)receiveList;

            // �ύX����
            for (int i = 0; i < outreceiveList.Count; i++)
            {
                if (outreceiveList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)outreceiveList[i];

                    if (list.Count == 0) continue;

                    if (list[0] is APSalesSlipWork)
                    {
                        // ����f�[�^
                        _salesSlipList.AddRange(list);
                    }
                    else if (list[0] is APSalesDetailWork)
                    {
                        // ���㖾�׃f�[�^
                        _salesDetailList.AddRange(list);
                    }
                    else if (list[0] is APSalesHistoryWork)
                    {
                        // ���㗚���f�[�^
                        _salesHistoryList.AddRange(list);
                    }
                    else if (list[0] is APSalesHistDtlWork)
                    {
                        // ���㗚�𖾍׃f�[�^
                        _salesHistDtlList.AddRange(list);
                    }
                    else if (list[0] is APDepsitMainWork)
                    {
                        // �����f�[�^
                        _depsitMainList.AddRange(list);
                    }
                    else if (list[0] is APDepsitDtlWork)
                    {
                        // �������׃f�[�^
                        _depsitDtlList.AddRange(list);
                    }
                    else if (list[0] is APStockSlipWork)
                    {
                        // �d���f�[�^
                        _stockSlipList.AddRange(list);
                    }
                    else if (list[0] is APStockDetailWork)
                    {
                        // �d�����׃f�[�^
                        _stockDetailList.AddRange(list);
                    }
                    else if (list[0] is APStockSlipHistWork)
                    {
                        // �d�������f�[�^
                        _stockSlipHistList.AddRange(list);
                    }
                    else if (list[0] is APStockSlHistDtlWork)
                    {
                        // �d�����𖾍׃f�[�^
                        _stockSlHistDtlList.AddRange(list);
                    }
                    else if (list[0] is APPaymentSlpWork)
                    {
                        // �x���`�[�}�X�^
                        _paymentSlpList.AddRange(list);
                    }
                    else if (list[0] is APPaymentDtlWork)
                    {
                        // �x�����׃f�[�^
                        _paymentDtlList.AddRange(list);
                    }
                    else if (list[0] is APAcceptOdrWork)
                    {
                        // �󒍃}�X�^
                        _acceptOdrList.AddRange(list);
                    }
                    else if (list[0] is APAcceptOdrCarWork)
                    {
                        // �󒍃}�X�^�i�ԗ��j
                        _acceptOdrCarList.AddRange(list);
                    }
                    else if (list[0] is APMTtlSalesSlipWork)
                    {
                        // ���㌎���ʓ`�[�f�[�^
                        _mTtlSalesSlipList.AddRange(list);
                    }
                    else if (list[0] is APGoodsMTtlSaSlipWork)
                    {
                        // ���i�����ʓ`�[�f�[�^
                        _goodsMTtlSaSlipList.AddRange(list);
                    }
                    else if (list[0] is APMTtlStockSlipWork)
                    {
                        // �d�������ʓ`�[�f�[�^
                        _mTtlStockSlipList.AddRange(list);
                    }
                    // �� 2009.04.29 liuyang add
                    else if (list[0] is APStockAdjustWork)
                    {
                        // �݌ɒ����f�[�^
                        _stockAdjustList.AddRange(list);
                    }
                    else if (list[0] is APStockAdjustDtlWork)
                    {
                        // �݌ɒ������׃f�[�^
                        _stockAdjustDtlList.AddRange(list);
                    }
                    else if (list[0] is APStockMoveWork)
                    {
                        // �݌Ɉړ��f�[�^
                        _stockMoveList.AddRange(list);
                    }
                    else if (list[0] is APStockAcPayHistWork)
                    {
                        // �݌Ɏ󕥗����f�[�^
                        _stockAcPayHistList.AddRange(list);
                    }
                    // �� 2009.04.29 liuyang add

					//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
					else if (list[0] is APDepositAlwWork)
					{
						// ���������}�X�^
						_depositAlwList.AddRange(list);
					}
					else if (list[0] is APRcvDraftDataWork)
					{
						// ����`�}�X�^
						_rcvDraftDataList.AddRange(list);
					}
					else if (list[0] is APPayDraftDataWork)
					{
						// �x����`�}�X�^
						_payDraftDataList.AddRange(list);
					}

					//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

                }
            }

            string resNm = "";
#if !DEBUG
            ShareCheckInfo shareCheckInfo = null;
            IntentExclusiveLockComponent intentLockObj = null;
#endif

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnectionData(true);
                sqlTransaction = this.CreateTransactionData(ref sqlConnection);

                // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>
                // ���_�Ǘ�����M�Ώۃ}�X�^�����擾
                SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();
                secMngSndRcvWork.EnterpriseCode = enterPriseCode;
                object outSecMngSndRcvList = null;
                status = this.ScMngSndRcvDB.Search(out outSecMngSndRcvList, secMngSndRcvWork, 0, ConstantManagement.LogicalMode.GetData0);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;

                int salesSlipRecvDiv = -1; // ����f�[�^��M�敪
                int stockMoveRecvDiv = -1; // �݌Ɉړ��f�[�^��M�敪
                int stockAdjustRecvDiv = -1; // �݌ɒ����f�[�^��M�敪
                int stockSlipRecvDiv = -1; // �d���f�[�^��M�敪

                ArrayList secMngSndRcvList = outSecMngSndRcvList as ArrayList;
                foreach (SecMngSndRcvWork resultSecMngSndRcvWork in secMngSndRcvList)
                {
                    // ��M�敪���擾
                    if (string.Equals("SalesSlipRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase))
                        salesSlipRecvDiv = resultSecMngSndRcvWork.SecMngRecvDiv;
                    else if (string.Equals("StockSlipRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase))
                        stockSlipRecvDiv = resultSecMngSndRcvWork.SecMngRecvDiv;
                    else if (string.Equals("StockMoveRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase))
                        stockMoveRecvDiv = resultSecMngSndRcvWork.SecMngRecvDiv;
                    else if (string.Equals("StockAdjustRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase))
                        stockAdjustRecvDiv = resultSecMngSndRcvWork.SecMngRecvDiv;
                    else
                        continue;
                }
                secMngSndRcvList.Clear(); // �������������[�X
                secMngSndRcvList = null;

#if !DEBUG
                // �V�F�A�`�F�b�N���s��
                ArrayList paramShareCheckList = new ArrayList();
                paramShareCheckList.AddRange(_salesDetailList);   // ���㖾�׃f�[�^
                paramShareCheckList.AddRange(_stockDetailList);   // �d�����׃f�[�^
                if (stockAdjustRecvDiv == 2)
                    // �݌ɍX�V����̏ꍇ
                    paramShareCheckList.AddRange(_stockAdjustDtlList);// �݌ɒ������׃f�[�^
                // ����A�d���A�݌ɒ����̃`�F�b�N�C���t�H���쐬
                this.ShareCheckInitialize(paramShareCheckList, ref shareCheckInfo, (salesSlipRecvDiv == 2), (stockSlipRecvDiv == 2));
                //if (1 == stockMoveRecvDiv)//DEL 2011/08/25 #25443
                if (2 == stockMoveRecvDiv)//ADD 2011/08/25 #25443
                    // �݌Ɉړ��̃`�F�b�N�C���t�H���쐬
                    this.ShareCheckInitForStockMove(_stockMoveList, ref shareCheckInfo);

                paramShareCheckList.Clear(); // �������������[�X
                paramShareCheckList = null;
                if (shareCheckInfo != null && shareCheckInfo.Keys != null && shareCheckInfo.Keys.Count > 0)
                {
                    status = this.ShareCheck(shareCheckInfo, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;
                }
#endif
                // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<

                resNm = GetResourceName(enterPriseCode);

                if (resNm != "")
                {
                    //�`�o���b�N
                    // �� 2009.07.06 ���m modify
                    status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                    // �� 2009.07.06 ���m modify
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                }

                // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>
#if !DEBUG
                // �C���e���g���b�N���s��
                intentLockObj = new IntentExclusiveLockComponent(); // ���b�N���i���C���X�^���X
                // �C���e���g���b�N�Ώۂ�ݒ�
                string[] targetTables = new string[]{"SALESSLIPRF", "ACCEPTODRCARRF", "SALESDETAILRF", "SALESHISTORYRF"       // ����f�[�^�A�󒍃}�X�^�i�ԗ��j�A���㖾�׃f�[�^�A���㗚���f�[�^
                                    ,"SALESHISTDTLRF","STOCKSLIPRF", "STOCKDETAILRF","STOCKSLIPHISTRF"                        // ���㗚�𖾍׃f�[�^�A�d���f�[�^�A�d�����׃f�[�^�A�d�������f�[�^
                                    ,"STOCKSLHISTDTLRF", "STOCKADJUSTRF", "STOCKADJUSTDTLRF", "STOCKMOVERF", "ACCEPTODRRF"};  // �d�����𖾍׃f�[�^�A�݌ɒ����f�[�^�A�݌ɒ������׃f�[�^�A�݌Ɉړ��f�[�^�A�󒍃}�X�^
                status = intentLockObj.IntentLock(targetTables);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;
#endif

                // ���ьn�f�[�^�̏W�v�ƍX�V�������s��------------------------------------------------------------>

                // ��M�d���f�[�^�W�v�����[�g�I�u�W�F�N�g���R�[��
                if (stockSlipRecvDiv > 0)
                {
                    // �d����M�̏ꍇ
                    status = new APTotalizeStockSlip().TotalizeReceivedStockSlip(enterPriseCode, _stockSlipList, _stockDetailList, stockSlipRecvDiv, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        return status;
                }
				
				// ��M�݌ɒ����f�[�^�W�v�����[�g�I�u�W�F�N�g���R�[��
				string retMsg = string.Empty;
				if (2 == stockAdjustRecvDiv)
				{
					// �݌ɍX�V����
					status = new APTotalizeStockAdjustDB().TotalizeStokAdjust(enterPriseCode, _stockAdjustList, _stockAdjustDtlList, sqlConnection, sqlTransaction, out retMsg);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
						return status;
				}
                
				// ��M�݌Ɉړ��f�[�^�W�v�����[�g�I�u�W�F�N�g���R�[��
                //if (1 == stockMoveRecvDiv)//DEL 2011/08/25 #23998�@�݌Ɉړ��f�[�^�̎�M�敪�ύX
                if (2 == stockMoveRecvDiv)//ADD 2011/08/25 #23998�@�݌Ɉړ��f�[�^�̎�M�敪�ύX
				{
					// �݌ɍX�V����
					status = new APTotalizeStockMoveDB().TotalizeStokMove(enterPriseCode, _stockMoveList, sqlConnection, sqlTransaction, out retMsg);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
						return status;
				}				

                // ��M����f�[�^�W�v�����[�g�I�u�W�F�N�g���R�[��
                if (salesSlipRecvDiv > 0)
                {
                    // �����M�̏ꍇ
                    status = new APTotalizeSalesSlip().TotalizeReceivedSalesSlip(enterPriseCode, _salesSlipList, _salesDetailList, salesSlipRecvDiv, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        return status;
                }

                // ���ьn�f�[�^�̏W�v�ƍX�V�������s��------------------------------------------------------------<
                // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<

                // �f�[�^�X�V����
                if (_salesSlipList != null && _salesSlipList.Count > 0)
                {
                    // ����f�[�^�X�V
                    APSalesSlipDB _salesSlipDB = new APSalesSlipDB();
                    status = _salesSlipDB.UpdateSalesSlip(enterPriseCode, _salesSlipList, ref sqlConnection, ref sqlTransaction);
                }
                // ���㖾�׃f�[�^�X�V
                if (_salesDetailList != null && _salesDetailList.Count > 0)
                {
                    APSalesDetailDB _salesDetailDB = new APSalesDetailDB();
                    status = _salesDetailDB.UpdateSalesDetail(enterPriseCode, _salesDetailList, ref sqlConnection, ref sqlTransaction);
                }
                // ���㗚���f�[�^
                if (_salesHistoryList != null && _salesHistoryList.Count > 0)
                {
                    APSalesHistoryDB _salesHistoryDB = new APSalesHistoryDB();
                    status = _salesHistoryDB.UpdateSalesHistory(enterPriseCode, _salesHistoryList, ref sqlConnection, ref sqlTransaction);
                }
                // ���㗚�𖾍׃f�[�^
                if (_salesHistDtlList != null && _salesHistDtlList.Count > 0)
                {
                    APSalesHistDtlDB _salesHistDtlDB = new APSalesHistDtlDB();
                    status = _salesHistDtlDB.UpdateSalesHistDtl(enterPriseCode, _salesHistDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // �����f�[�^
                if (_depsitMainList != null && _depsitMainList.Count > 0)
                {
                    APDepsitMainDB _depsitMainDB = new APDepsitMainDB();
                    status = _depsitMainDB.UpdateDepsitMain(enterPriseCode, _depsitMainList, ref sqlConnection, ref sqlTransaction);
                }
                // �������׃f�[�^
                if (_depsitDtlList != null && _depsitDtlList.Count > 0)
                {
                    APDepsitDtlDB _depsitDtlDB = new APDepsitDtlDB();
                    status = _depsitDtlDB.UpdateDepsitDtl(enterPriseCode, _depsitDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // �d���f�[�^
                if (_stockSlipList != null && _stockSlipList.Count > 0)
                {
                    APStockSlipDB _stockSlipDB = new APStockSlipDB();
                    status = _stockSlipDB.UpdateStockSlip(enterPriseCode, _stockSlipList, ref sqlConnection, ref sqlTransaction);
                }
                // �d�����׃f�[�^
                if (_stockDetailList != null && _stockDetailList.Count > 0)
                {
                    APStockDetailDB _stockDetailDB = new APStockDetailDB();
                    status = _stockDetailDB.UpdateStockDetail(enterPriseCode, _stockDetailList, ref sqlConnection, ref sqlTransaction);
                }
                // �d�������f�[�^
                if (_stockSlipHistList != null && _stockSlipHistList.Count > 0)
                {
                    APStockSlipHistDB _stockSlipHistDB = new APStockSlipHistDB();
                    status = _stockSlipHistDB.UpdateStockSlipHist(enterPriseCode, _stockSlipHistList, ref sqlConnection, ref sqlTransaction);
                }
                // �d�����𖾍׃f�[�^
                if (_stockSlHistDtlList != null && _stockSlHistDtlList.Count > 0)
                {
                    APStockSlHistDtlDB _stockSlHistDtlDB = new APStockSlHistDtlDB();
                    status = _stockSlHistDtlDB.UpdateStockSlHistDtl(enterPriseCode, _stockSlHistDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // �x���`�[�}�X�^
                if (_paymentSlpList != null && _paymentSlpList.Count > 0)
                {
                    APPaymentSlpDB _paymentSlpDB = new APPaymentSlpDB();
                    status = _paymentSlpDB.UpdatePayementSlp(enterPriseCode, _paymentSlpList, ref sqlConnection, ref sqlTransaction);
                }
                // �x�����׃f�[�^
                if (_paymentDtlList != null && _paymentDtlList.Count > 0)
                {
                    APPaymentDtlDB _paymentDtlDB = new APPaymentDtlDB();
                    status = _paymentDtlDB.UpdatePayementDtl(enterPriseCode, _paymentDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // �󒍃}�X�^
                if (_acceptOdrList != null && _acceptOdrList.Count > 0)
                {
                    APAcceptOdrDB _acceptOdrDB = new APAcceptOdrDB();
                    status = _acceptOdrDB.UpdateAcceptOdr(enterPriseCode, _acceptOdrList, ref sqlConnection, ref sqlTransaction);
                }
                // �󒍃}�X�^�i�ԗ��j
                if (_acceptOdrCarList != null && _acceptOdrCarList.Count > 0)
                {
                    APAcceptOdrCarDB _acceptOdrCarDB = new APAcceptOdrCarDB();
                    status = _acceptOdrCarDB.UpdateAcceptOdrCar(enterPriseCode, _acceptOdrCarList, ref sqlConnection, ref sqlTransaction);
                }
                #region [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
                // DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
                /*
                // ���㌎���ʓ`�[�f�[�^
                if (_mTtlSalesSlipList != null && _mTtlSalesSlipList.Count > 0)
                {
                    APMTtlSalesSlipDB _mTtlSalesSlipDB = new APMTtlSalesSlipDB();
                    status = _mTtlSalesSlipDB.UpdateMTtlSalesSlip(enterPriseCode, _mTtlSalesSlipList, ref sqlConnection, ref sqlTransaction);
                }
                // ���i�����ʓ`�[�f�[�^
                if (_goodsMTtlSaSlipList != null && _goodsMTtlSaSlipList.Count > 0)
                {
                    APGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = new APGoodsMTtlSaSlipDB();
                    status = _goodsMTtlSaSlipDB.UpdateGoodsMTtlSaSlip(enterPriseCode, _goodsMTtlSaSlipList, ref sqlConnection, ref sqlTransaction);
                }
                // �d�������ʓ`�[�f�[�^
                if (_mTtlStockSlipList != null && _mTtlStockSlipList.Count > 0)
                {
                    APMTtlStockSlipDB _mTtlStockSlipDB = new APMTtlStockSlipDB();
                    status = _mTtlStockSlipDB.UpdateMTtlStockSlip(enterPriseCode, _mTtlStockSlipList, ref sqlConnection, ref sqlTransaction);
                }
				 */
                // DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                #endregion [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

                // �� 2009.04.29 liuyang add
                // �݌ɒ����f�[�^
                if (_stockAdjustList != null && _stockAdjustList.Count > 0)
                {
                    APStockAdjustDB _stockAdjustDB = new APStockAdjustDB();
                    status = _stockAdjustDB.UpdateStockAdjust(enterPriseCode, _stockAdjustList, ref sqlConnection, ref sqlTransaction);
                }
                // �݌ɒ������׃f�[�^
                if (_stockAdjustDtlList != null && _stockAdjustDtlList.Count > 0)
                {
                    APStockAdjustDtlDB _stockAdjustDtlDB = new APStockAdjustDtlDB();
                    status = _stockAdjustDtlDB.UpdateStockAdjustDtl(enterPriseCode, _stockAdjustDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // �݌Ɉړ��f�[�^
                if (_stockMoveList != null && _stockMoveList.Count > 0)
                {
                    APStockMoveDB _stockMoveDB = new APStockMoveDB();
                    status = _stockMoveDB.UpdateStockMove(enterPriseCode, _stockMoveList, ref sqlConnection, ref sqlTransaction);
                }
                #region [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
                // DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
                /*
                // �݌Ɏ󕥗����f�[�^
                if (_stockAcPayHistList != null && _stockAcPayHistList.Count > 0)
                {
                    // �ΏۊO���𔻒f����
                    ArrayList result = new ArrayList();
                    foreach (APStockAcPayHistWork stockAcPayHistWork in _stockAcPayHistList)
                    {
                        // �󕥌��`�[�敪��30:�ړ��o��,31:�ړ����ׂ̏ꍇ
                        if (stockAcPayHistWork.AcPaySlipCd == 30 || stockAcPayHistWork.AcPaySlipCd == 31)
                        {
                            // ���_���ݔ��f
                            if (!ExistSectionCode(stockAcPayHistWork.BfSectionCode, sectionCodeList)
                                || !ExistSectionCode(stockAcPayHistWork.AfSectionCode, sectionCodeList))
                            {
                                // �݌Ƀ}�X�^����
                                APStockWork apStockWork = null;
                                int statusStock = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                statusStock = SearchStock(enterPriseCode, stockAcPayHistWork, out apStockWork, ref sqlConnection, ref sqlTransaction);
                                // �݌Ƀ}�X�^�o�^���Ȃ��ꍇ
                                if (statusStock == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    result.Add(stockAcPayHistWork);
                                }
                            }
                            else
                            {
                                result.Add(stockAcPayHistWork);
                            }
                        }
                        else
                        {
                            result.Add(stockAcPayHistWork);
                        }
                    }

                    stockAcPayHistCount = result.Count;

                    APStockAcPayHistDB _stockAcPayHistDB = new APStockAcPayHistDB();
                    status = _stockAcPayHistDB.UpdateStockAcPayHist(enterPriseCode, result, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    stockAcPayHistCount = 0;
                }
                // �� 2009.04.29 liuyang add
				*/
                // DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
                #endregion [--- DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]

                //-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				// ���������}�X�^
				if (_depositAlwList != null && _depositAlwList.Count > 0)
				{
					APDepositAlwDB _depositAlwDB = new APDepositAlwDB();
					_depositAlwDB.Delete(_depositAlwList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
					_depositAlwDB.Insert(_depositAlwList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
				}
				// ����`�}�X�^
				if (_rcvDraftDataList != null && _rcvDraftDataList.Count > 0)
				{
					APRcvDraftDataDB _rcvDraftDataDB = new APRcvDraftDataDB();
					_rcvDraftDataDB.Delete(_rcvDraftDataList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
					_rcvDraftDataDB.Insert(_rcvDraftDataList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
				}
				// �x����`�}�X�^
				if (_payDraftDataList != null && _payDraftDataList.Count > 0)
				{
					APPayDraftDataDB _payDraftDataDB = new APPayDraftDataDB();
					_payDraftDataDB.Delete(_payDraftDataList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
					_payDraftDataDB.Insert(_payDraftDataList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
				}
				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "ExtraAndUpdControlDB.UpdateCustomSerializeArrayList(outreceiveList)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ExtraAndUpdControlDB.UpdateCustomSerializeArrayList(outreceiveList)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>
#if !DEBUG
                if (null != intentLockObj) 
                {
                    // �C���e���g���b�N����
                    intentLockObj.UnLock();
                }
#endif
                // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<

                if (resNm != "")
                {
                    // �� 2009.07.06 ���m modify
                    //�`�o�A�����b�N
                    int status2 = Release(resNm, sqlConnection, sqlTransaction);

                    if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    // �� 2009.07.06 ���m modify
                }

                // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>
#if !DEBUG
                if (shareCheckInfo != null && shareCheckInfo.Keys != null && shareCheckInfo.Keys.Count > 0)
                    this.ShareCheck(shareCheckInfo, LockControl.Release, sqlConnection, sqlTransaction);
#endif
                // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<

                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
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
				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				if (sqlCommand != null)
				{
					sqlCommand.Cancel();
					sqlCommand.Dispose();
				}
				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }

            return status;
        }

        /// <summary>
        /// ���_��񑶍ݐ��`�F�b�N
        /// </summary>
        /// <param name="code">���_�R�[�h</param>
        /// <param name="sectionCodeList">���_���X�g</param>
        /// <returns></returns>
        private bool ExistSectionCode(string code, ArrayList sectionCodeList)
        {
            bool isExist = false;

            for (int i = 0; i < sectionCodeList.Count; i++)
            {
                if (code.Equals((string)sectionCodeList[i]))
                {
                    isExist = true;
                    break;
                }
            }

            return isExist;
        }

        /// <summary>
        /// �݌Ƀ}�X�^����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="stockAcPayHistWork">�݌Ɏ󕥗����f�[�^</param>
        /// <param name="stockWork">�݌Ƀ}�X�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchStock(string enterpriseCode, APStockAcPayHistWork stockAcPayHistWork, out APStockWork stockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockWork = new APStockWork();

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = enterpriseCode;
            findParaLogicalDeleteCode.Value = Convert.ToInt32(0);
            findParaWarehouseCode.Value = stockAcPayHistWork.WarehouseCode;
            findParaGoodsMakerCd.Value = stockAcPayHistWork.GoodsMakerCd;
            findParaGoodsNo.Value = stockAcPayHistWork.GoodsNo;

            // SQL��
            sqlCommand.CommandText = sqlText;
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
			
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                stockWork.StockCreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                stockWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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

        #endregion �� �f�[�^���M�̃f�[�^�X�V���� ��

        #region [����������]
        /// <summary>
        /// �f�[�^���擾����
        /// </summary>
        /// <param name="enterpriseCodes">���_�R�[�h</param>
        /// <param name="secMngSetWorkList">���_�}�X�^</param>
        /// <param name="retMessage">���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchSecMngSetData(string enterpriseCodes, out ArrayList secMngSetWorkList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;
            secMngSetWorkList = new ArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnectionData(true);

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // Select�R�}���h�̐���
                sqlText = "SELECT SECMNGSETRF.SECTIONCODERF, SECMNGSETRF.SYNCEXECDATERF, SECINFOSETRF.SECTIONGUIDENMRF, SECMNGEPSETRF.PMENTERPRISECODERF, SECMNGSETRF.UPDEMPLOYEECODERF  FROM SECMNGSETRF WITH (READUNCOMMITTED), SECINFOSETRF WITH (READUNCOMMITTED), SECMNGEPSETRF WITH (READUNCOMMITTED) WHERE SECMNGSETRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND SECMNGSETRF.KINDRF=@FINDKINDRF AND SECMNGSETRF.RECEIVECONDITIONRF=@FINDRECEIVECONDITIONRF AND SECMNGSETRF.ENTERPRISECODERF = SECINFOSETRF.ENTERPRISECODERF AND SECMNGSETRF.SECTIONCODERF = SECINFOSETRF.SECTIONCODERF AND SECMNGSETRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECMNGSETRF.LOGICALDELETECODERF = SECINFOSETRF.LOGICALDELETECODERF AND SECMNGEPSETRF.LOGICALDELETECODERF = SECMNGSETRF.LOGICALDELETECODERF AND SECMNGEPSETRF.ENTERPRISECODERF = SECMNGSETRF.ENTERPRISECODERF AND SECMNGEPSETRF.SECTIONCODERF = SECMNGSETRF.SECTIONCODERF";

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);
                SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITIONRF", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                paraKind.Value = SqlDataMediator.SqlSetInt32(0);
                paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(1);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
				
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    APSecMngSetWork secMngSetWork = new APSecMngSetWork();

                    secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
                    secMngSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    secMngSetWork.PmEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMENTERPRISECODERF"));
                    secMngSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));

                    secMngSetWorkList.Add(secMngSetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "ExtraAndUpdControlDB.Search Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "ExtraAndUpdControlDB.Search Exception=" + ex.Message);
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

        #region

        /// <summary>
        /// �f�[�^���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngEpSetWorkList">���_���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchSecMngEpSetData(string enterpriseCode, out ArrayList secMngEpSetWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secMngEpSetWorkList = new ArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnectionData(true);

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // Select�R�}���h�̐���
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, PMENTERPRISECODERF FROM SECMNGEPSETRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = enterpriseCode;

                sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
				
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    APSecMngEpSetWork secMngEpSetWork = new APSecMngEpSetWork();

                    secMngEpSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    secMngEpSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    secMngEpSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    secMngEpSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    secMngEpSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    secMngEpSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    secMngEpSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    secMngEpSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    secMngEpSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    secMngEpSetWork.PmEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMENTERPRISECODERF"));

                    secMngEpSetWorkList.Add(secMngEpSetWork);
                }

                // �X�e�[�^�X
                if (secMngEpSetWorkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "ExtraAndUpdControlDB.Search Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "ExtraAndUpdControlDB.Search Exception=" + ex.Message);
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


        /// <summary>
        /// ���_�����X�V���܂��B
        /// </summary>
        /// <param name="secMngSetWork">���_�}�X�^</param>
        /// <param name="newSyncExecDate">�V�b�N����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        public int UpdateSecMngSetData(APSecMngSetWork secMngSetWork, Int64 newSyncExecDate)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            string sqlStr = string.Empty;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnectionData(true);

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // Select�R�}���h�̐���
                sqlText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND SECTIONCODERF=@FINDSECTIONCODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSetWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.UpdEmployeeCode);
                paraSyncExecDate.Value = newSyncExecDate;

                //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeteleCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.EnterpriseCode);
                findParaKind.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.Kind);
                findParaReceiveCondition.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.ReceiveCondition);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.SectionCode);
                findParaLogicalDeteleCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
				
                // ���s
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "ExtraAndUpdControlDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "ExtraAndUpdControlDB.Search Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        #endregion

        # region �� [�R�l�N�V������������] ��
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
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

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlTransaction CreateTransactionData(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion �� [�R�l�N�V������������] ��

		#region IAPSendMessageDB �����o

		#endregion

        # region [�V�F�A�`�F�b�N����]
        // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
        /// <summary>
        /// �V�F�A�`�F�b�N�����擾
        /// </summary>
        /// <param name="param">�`�F�b�N�Ώۃ��X�g</param>
        /// <param name="info">�V�F�A�`�F�b�N���</param>
        /// <param name="isWdUpdForSales">����݌ɍX�V���肩(true:����)</param>
        /// <param name="isWdUpdForStock">�d���݌ɍX�V���肩(true:����)</param>
        private void ShareCheckInitialize(ArrayList param, ref ShareCheckInfo info, bool isWdUpdForSales, bool isWdUpdForStock)
        {
            if (info == null)
            {
                info = new ShareCheckInfo();
            }

            ShareCheckKey dummyKey = new ShareCheckKey();

            foreach (object item in param)
            {
                if (item is ArrayList)
                {
                    this.ShareCheckInitialize((item as ArrayList), ref info, isWdUpdForSales, isWdUpdForStock);
                    continue;
                }

                // ���㖾�׃f�[�^
                if (item is APSalesDetailWork)
                {
                    dummyKey.EnterpriseCode = (item as APSalesDetailWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as APSalesDetailWork).SectionCode;
                    // ���ς̏ꍇ�́A�q�Ƀ��b�N�����Ȃ��悤�ɏC��
                    if ((item as APSalesDetailWork).AcptAnOdrStatus != 10 && isWdUpdForSales)
                    {
                        dummyKey.WarehouseCode = (item as APSalesDetailWork).WarehouseCode;
                    }
                }
                // �d�����׃f�[�^
                else if (item is APStockDetailWork)
                {
                    dummyKey.EnterpriseCode = (item as APStockDetailWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as APStockDetailWork).SectionCode;
                    if (isWdUpdForStock)
                        dummyKey.WarehouseCode = (item as APStockDetailWork).WarehouseCode;
                }
                // �݌ɒ������׃f�[�^
                else if (item is APStockAdjustDtlWork)
                {
                    // �݌ɍX�V�Ȃ��̏ꍇ�A���Y�݌ɒ������׃f�[�^�Ȃ�
                    dummyKey.EnterpriseCode = (item as APStockAdjustDtlWork).EnterpriseCode;
                    dummyKey.WarehouseCode = (item as APStockAdjustDtlWork).WarehouseCode;
                }
                else
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(dummyKey.SectionCode))
                {
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.Type == ShareCheckType.Section &&
                                                     key.SectionCode == dummyKey.SectionCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.Section, dummyKey.SectionCode, "");
                    }

                    dummyKey.SectionCode = string.Empty;
                }
                if (!string.IsNullOrEmpty(dummyKey.WarehouseCode))
                {
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.WarehouseCode == dummyKey.WarehouseCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.WareHouse, "", dummyKey.WarehouseCode);
                    }

                    dummyKey.WarehouseCode = string.Empty;
                }
            }

        }

        /// <summary>
        /// �݌Ɉړ��̃V�F�A�`�F�b�N�����擾
        /// </summary>
        /// <param name="stockMoveList">�݌Ɉړ��f�[�^���X�g</param>
        /// <param name="info">�V�F�A�`�F�b�N���</param>
        private void ShareCheckInitForStockMove(ArrayList stockMoveList, ref ShareCheckInfo info)
        {
            if (info == null)
            {
                info = new ShareCheckInfo();
            }
            ShareCheckKey dummyKey = new ShareCheckKey();

            foreach (object item in stockMoveList)
            {
                // �݌Ɉړ��f�[�^
                if (item is APStockMoveWork)
                {
                    // �݌Ɉړ��f�[�^�̈ړ����q�ɃR�[�h
                    dummyKey.EnterpriseCode = (item as APStockMoveWork).EnterpriseCode;
                    dummyKey.WarehouseCode = (item as APStockMoveWork).BfEnterWarehCode;
                }
                else
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(dummyKey.WarehouseCode))
                {
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.WarehouseCode == dummyKey.WarehouseCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.WareHouse, "", dummyKey.WarehouseCode);
                    }
                }
            }
            foreach (object item in stockMoveList)
            {
                // �݌Ɉړ��f�[�^
                if (item is APStockMoveWork)
                {
                    // �݌Ɉړ��f�[�^�̈ړ���q�ɃR�[�h
                    dummyKey.EnterpriseCode = (item as APStockMoveWork).EnterpriseCode;
                    dummyKey.WarehouseCode = (item as APStockMoveWork).AfEnterWarehCode;
                }
                else
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(dummyKey.WarehouseCode))
                {
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.WarehouseCode == dummyKey.WarehouseCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.WareHouse, "", dummyKey.WarehouseCode);
                    }
                }
            }
        }
        // ADD 2011/08/10 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
        # endregion
    }
}
