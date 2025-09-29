//**********************************************************************//
// System           :   �r�e�D�m�d�s
// Sub System       :
// Program name     :   ���R���[�󎚈ʒu�ݒ�@�����[�g�I�u�W�F�N�g
//                  :   SFANL08234R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   �����@���l
// Date             :   2007.05.24
//----------------------------------------------------------------------//
// Update Note      :
//----------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
	/// ���R���[�󎚈ʒu�ݒ�@�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R���[�󎚈ʒu�ݒ�}�X�^�擾���s���N���X�ł��B</br>
	/// <br>Programmer : 22011�@�����@���l</br>
	/// <br>Date       : 2007.05.24</br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
    public class FrePrtPSetDLDB : RemoteDB, IFrePrtPSetDLDB
	{
		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�@�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22011 �����@���l</br>
		/// <br>Date       : 2007.05.24</br>
		/// </remarks>
		public FrePrtPSetDLDB()
//            : base("SFANL08123D", "Broadleaf.Application.Remoting.ParamData.FrePrtPSetWork", "FREPRTPSETRF")
		{
        }

        #region ���R���[�󎚈ʒu�ݒ�E�w�i�摜�̎擾����
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�E�w�i�摜�̎擾���s���܂��B
        /// </summary>
        /// <param name="frePrtPSetWorkByte">���R���[�󎚈ʒu�ݒ�f�[�^�p�����[�^(�L�[�l�݂̂��w��)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[�󎚈ʒu�ݒ�����擾���܂�</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2007.05.24</br>
        /// </remarks>
        public int Read( ref byte[] frePrtPSetWorkByte, out bool msgDiv, out string errMsg )
        {
            return ReadProc( ref frePrtPSetWorkByte, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�E�w�i�摜�̎擾���s���܂��B
        /// </summary>
        /// <param name="frePrtPSetWorkByte">���R���[�󎚈ʒu�ݒ�f�[�^�p�����[�^(�L�[�l�݂̂��w��)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int ReadProc( ref byte[] frePrtPSetWorkByte, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msgDiv = false;
            errMsg = "";

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (_connectionText == null || _connectionText == "") return status;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;


            try
            {
                // XML�̓ǂݍ���
                FrePrtPSetWork frePrtPSetWork = (FrePrtPSetWork)XmlByteSerializer.Deserialize(frePrtPSetWorkByte, typeof(FrePrtPSetWork));

                //DB�ڑ��E�g�����U�N�V�����J�n
                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // ���R���[�󎚈ʒu�擾�������C��
                status = ReadFrePrtPSetWork(ref frePrtPSetWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    frePrtPSetWorkByte = XmlByteSerializer.Serialize(frePrtPSetWork);
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "Read Exception\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�󎚈ʒu�ݒ���Ǎ����ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Read Exception\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�E�w�i�摜�擾���C������
        /// </summary>
        /// <param name="frePrtPSetWork">���R���[�󎚈ʒu�ݒ�f�[�^�p�����[�^(�L�[�l�݂̂��w��)</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[�󎚈ʒu�ݒ�����擾���܂�</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2007.05.24</br>
        /// </remarks>
        private int ReadFrePrtPSetWork(ref FrePrtPSetWork frePrtPSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                // Select�R�}���h�̐���
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM FREPRTPSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO AND SLIPORPRTPPRDIVCDRF=@FINDSLIPORPRTPPRDIVCD");

                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
                    SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);
                    SqlParameter findParaPrintPaperUseDivcd = sqlCommand.Parameters.Add("@FINDSLIPORPRTPPRDIVCD", SqlDbType.Int);
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                    findParaPrintPaperUseDivcd.Value = frePrtPSetWork.PrintPaperUseDivcd;
                    findEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                    
                    //�^�C���A�E�g���Ԑݒ�
                    RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        #region �N���X�֑��
                        frePrtPSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        frePrtPSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        frePrtPSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        frePrtPSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        frePrtPSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        frePrtPSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        frePrtPSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        frePrtPSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        frePrtPSetWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                        frePrtPSetWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
                        frePrtPSetWork.PrintPaperUseDivcd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERUSEDIVCDRF"));
                        frePrtPSetWork.PrintPaperDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERDIVCDRF"));
                        frePrtPSetWork.ExtractionPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGIDRF"));
                        frePrtPSetWork.ExtractionPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGCLASSIDRF"));
                        frePrtPSetWork.OutputPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
                        frePrtPSetWork.OutputPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
                        frePrtPSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
                        frePrtPSetWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                        frePrtPSetWork.PrtPprUserDerivNoCmt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTPPRUSERDERIVNOCMTRF"));
                        frePrtPSetWork.PrintPositionVer = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPOSITIONVERRF"));
                        frePrtPSetWork.MergeablePrintPosVer = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MERGEABLEPRINTPOSVERRF"));
                        frePrtPSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                        frePrtPSetWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
                        frePrtPSetWork.FreePrtPprItemGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
                        frePrtPSetWork.FormFeedLineCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FORMFEEDLINECOUNTRF"));
                        frePrtPSetWork.EdgeCharProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDGECHARPROCDIVCDRF"));
                        frePrtPSetWork.PrtPprBgImageRowPos = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGEROWPOSRF"));
                        frePrtPSetWork.PrtPprBgImageColPos = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGECOLPOSRF"));
                        frePrtPSetWork.TakeInImageGroupCd = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("TAKEINIMAGEGROUPCDRF"));
                        frePrtPSetWork.FreePrtPprSpPrpseCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSPPRPSECDRF"));
                        frePrtPSetWork.PrintPosClassData = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("PRINTPOSCLASSDATARF"));
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        #endregion
                    }
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }

        #endregion

        #region ���R���[�󎚈ʒu�ݒ茟������
        /// <summary>
		/// ���R���[�󎚈ʒu�ݒ茟������
		/// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="OutputFormFileName">�o�̓t�@�C����</param>
		/// <param name="frePrtPSetWorkListkByte">�����������R���[�󎚈ʒu�ݒ胊�X�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�󎚈ʒu�ݒ�����������܂�</br>
		/// <br>           : ���o�̓t�@�C�������w�莞�A�S���X�g���擾���܂�</br>
		/// <br>Programmer : 22011 �����@���l</br>
		/// <br>Date        : 2007.05.24</br>
		/// </remarks>
        public int Search( string EnterpriseCode, string OutputFormFileName, out byte[] frePrtPSetWorkListkByte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            return SearchProc( EnterpriseCode, OutputFormFileName, out frePrtPSetWorkListkByte, readMode, logicalMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ茟������
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="OutputFormFileName">�o�̓t�@�C����</param>
        /// <param name="frePrtPSetWorkListkByte">�����������R���[�󎚈ʒu�ݒ胊�X�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int SearchProc( string EnterpriseCode, string OutputFormFileName, out byte[] frePrtPSetWorkListkByte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			frePrtPSetWorkListkByte = null;
            SqlConnection sqlConnection = null;
            msgDiv = false;
            errMsg = "";

            try
            {
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                ArrayList retobj;
                status = SearchProc(EnterpriseCode, OutputFormFileName, ref sqlConnection, out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�֕ϊ����A���X�g�̃o�C�i����
                    FrePrtPSetWork[] frePrtPSetWorkList = (FrePrtPSetWork[])retobj.ToArray(typeof(FrePrtPSetWork));
                    frePrtPSetWorkListkByte = XmlByteSerializer.Serialize(frePrtPSetWorkList);
                }
                else
                {
                    frePrtPSetWorkListkByte = null;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "Search SQLException\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�󎚈ʒu�ݒ��񌟍����ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Search Exception\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
			return status;
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ茟���������C��
		/// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="OutputFormFileName">�o�̓t�@�C����</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <param name="retobj">�����������R���[�󎚈ʒu�ݒ胊�X�g(ArrayList)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�󎚈ʒu�ݒ�����������܂�</br>
		/// <br>           : ���o�̓t�@�C�������w�莞�A�S���X�g���擾���܂�</br>
		/// <br>Programmer : 22011 �����@���l</br>
		/// <br>Date       : 2007.05.24</br>
		/// </remarks>
		private int SearchProc(string EnterpriseCode,string OutputFormFileName,ref SqlConnection sqlConnection, out ArrayList retobj)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;

			retobj = null;
			ArrayList al = new ArrayList();
			
            try 
			{				
				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM FREPRTPSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE");

				// �o�̓t�@�C�����w�肪����ꍇ�͌��������ɓ����
				if( OutputFormFileName != null && OutputFormFileName != "")
				{
                    sb.Append(" AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME ");
				}
                sb.Append(" ORDER BY OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF"); 

				using(sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
				{
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);                    
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = EnterpriseCode;
                 
					// �o�̓t�@�C�����w�肪����ꍇ�͌��������ɓ����
					if( OutputFormFileName != null && OutputFormFileName != "")
					{
						SqlParameter paraOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NChar);
						paraOutputFormFileName.Value = OutputFormFileName;
					}

                    //�^�C���A�E�g���Ԑݒ�
                    RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);
					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						FrePrtPSetWork frePrtPSetWork = new FrePrtPSetWork();
                        frePrtPSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        frePrtPSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        frePrtPSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        frePrtPSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        frePrtPSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        frePrtPSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        frePrtPSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        frePrtPSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        frePrtPSetWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                        frePrtPSetWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
                        frePrtPSetWork.PrintPaperUseDivcd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERUSEDIVCDRF"));
                        frePrtPSetWork.PrintPaperDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERDIVCDRF"));
                        frePrtPSetWork.ExtractionPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGIDRF"));
                        frePrtPSetWork.ExtractionPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGCLASSIDRF"));
                        frePrtPSetWork.OutputPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
                        frePrtPSetWork.OutputPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
                        frePrtPSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
                        frePrtPSetWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                        frePrtPSetWork.PrtPprUserDerivNoCmt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTPPRUSERDERIVNOCMTRF"));
                        frePrtPSetWork.PrintPositionVer = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPOSITIONVERRF"));
                        frePrtPSetWork.MergeablePrintPosVer = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MERGEABLEPRINTPOSVERRF"));
                        frePrtPSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                        frePrtPSetWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
                        frePrtPSetWork.FreePrtPprItemGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
                        frePrtPSetWork.FormFeedLineCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FORMFEEDLINECOUNTRF"));
                        frePrtPSetWork.EdgeCharProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDGECHARPROCDIVCDRF"));
                        frePrtPSetWork.PrtPprBgImageRowPos = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGEROWPOSRF"));
                        frePrtPSetWork.PrtPprBgImageColPos = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGECOLPOSRF"));
                        frePrtPSetWork.TakeInImageGroupCd = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("TAKEINIMAGEGROUPCDRF"));
                        frePrtPSetWork.FreePrtPprSpPrpseCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSPPRPSECDRF"));
                        //frePrtPSetWork.PrintPosClassData = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("PRINTPOSCLASSDATARF"));
                        al.Add(frePrtPSetWork);
					}
                    if(al.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();
			
			retobj = al;
			return status;
        }
        #endregion

        #region ���R���[�I���K�C�h��񌟍�����
        /// <summary>
        /// ���R���[�I���K�C�h��񌟍�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="printPaperUseDivcd">���[�敪�R�[�h(1:���[,2:�`�[)</param>
        /// <param name="printPaperDivCd">���[�敪�R�[�h(1:�������[,2:�������[,3:�N�����[,4:�������[)</param>
        /// <param name="dataInputSystem ">�f�[�^���̓V�X�e��(0:����,1:SF,2:BK,3:SH)</param>
        /// <param name="frePrtPSetSearchRetWork">�󎚈ʒu�ݒ胏�[�N�N���X�z��</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu�ݒ茟�����ʃN���X���[�NLIST���擾���܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.05.09</br>
        /// <br>Update Note : 22011 �����@���l</br>
        /// <br>            : �K�C�h�̃T�[�`��DL�p�����[�g�ɓ���</br>
        /// </remarks>
        public int Search( string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem, out byte[] frePrtPSetSearchRetWork, out bool msgDiv, out string errMsg )
        {
            return SearchProc( enterpriseCode, printPaperUseDivcd, printPaperDivCd, dataInputSystem, out frePrtPSetSearchRetWork, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�I���K�C�h��񌟍�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="printPaperUseDivcd">���[�敪�R�[�h(1:���[,2:�`�[)</param>
        /// <param name="printPaperDivCd">���[�敪�R�[�h(1:�������[,2:�������[,3:�N�����[,4:�������[)</param>
        /// <param name="dataInputSystem ">�f�[�^���̓V�X�e��(0:����,1:SF,2:BK,3:SH)</param>
        /// <param name="frePrtPSetSearchRetWork">�󎚈ʒu�ݒ胏�[�N�N���X�z��</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchProc( string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem, out byte[] frePrtPSetSearchRetWork, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            msgDiv = false;
            errMsg = string.Empty;
            frePrtPSetSearchRetWork = null;

            SqlConnection sqlConnection = null;
            try
            {
                ArrayList retobj;

                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                StringBuilder paraStr = new StringBuilder("Search Para: ");
                paraStr.Append("enterpriseCode ,").Append(enterpriseCode);
                paraStr.Append("printPaperUseDivcd ,").Append(printPaperUseDivcd);
                paraStr.Append("printPaperDivCd ,").Append(printPaperDivCd);
                if (dataInputSystem != null && dataInputSystem.Length > 0)
                {
                    paraStr.Append("dataInputSystem ");
                    foreach (int systemDivCd in dataInputSystem)
                        paraStr.Append(systemDivCd);
                }

                status = SearchFrePrtPSetProc(enterpriseCode, printPaperUseDivcd, printPaperDivCd, dataInputSystem, out retobj, sqlConnection);
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�֕ϊ����A���X�g�̃o�C�i����
                    FrePrtPSetWork[] frePrtPSetWorkList = (FrePrtPSetWork[])retobj.ToArray(typeof(FrePrtPSetWork));
                    frePrtPSetSearchRetWork = XmlByteSerializer.Serialize(frePrtPSetWorkList);
                }
                else
                {
                    frePrtPSetSearchRetWork = null;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FrePrtPSetDLDB_Search SQLException\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�I���K�C�h���擾�������Ƀ^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePrtPSetDLDB_Search Exception\n"+ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null) sqlConnection.Close();
            }

            return status;
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// ���R���[�I���K�C�h��񌟍������i���C�����j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="printPaperUseDivcd">���[�敪�R�[�h(1:���[,2:�`�[)</param>
        /// <param name="printPaperDivCd">���[�敪�R�[�h(1:�������[,2:�������[,3:�N�����[,4:�������[)</param>
        /// <param name="dataInputSystem ">�f�[�^���̓V�X�e��(0:����,1:SF,2:BK,3:SH)</param>
        /// <param name="frePrtPSetSearchRetWork">�󎚈ʒu�ݒ胏�[�N�N���X�z��</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu�ݒ茟�����ʃN���X���[�NLIST���擾���܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.05.09</br>
        /// <br>Update Note : 22011 �����@���l</br>
        /// <br>            : �K�C�h�̃T�[�`��DL�p�����[�g�ɓ���</br>
        /// </remarks>
        private int SearchFrePrtPSetProc(string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem, out ArrayList frePrtPSetSearchRetWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            frePrtPSetSearchRetWork = new ArrayList();

            try
            {
                //Select�R�}���h�̐���
                SqlCommand sqlCommand = new SqlCommand("SELECT ENTERPRISECODERF, UPDATEDATETIMERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF, DISPLAYNAMERF, FREEPRTPPRITEMGRPCDRF, PRTPPRUSERDERIVNOCMTRF, DATAINPUTSYSTEMRF FROM FREPRTPSETRF", sqlConnection);

                // WHERE���𐶐�
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterpriseCode, printPaperUseDivcd, printPaperDivCd, dataInputSystem);

                // �^�C���A�E�g���Ԑݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    FrePrtPSetWork frePrtPSetSearchRetWk = new FrePrtPSetWork();

                    #region �f�[�^�̃R�s�[
                    frePrtPSetSearchRetWk.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    frePrtPSetSearchRetWk.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    frePrtPSetSearchRetWk.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    frePrtPSetSearchRetWk.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
                    frePrtPSetSearchRetWk.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                    frePrtPSetSearchRetWk.FreePrtPprItemGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
                    frePrtPSetSearchRetWk.PrtPprUserDerivNoCmt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTPPRUSERDERIVNOCMTRF"));
                    frePrtPSetSearchRetWk.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                    #endregion

                    frePrtPSetSearchRetWork.Add(frePrtPSetSearchRetWk);
                }

                

                if (frePrtPSetSearchRetWork.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// WHERE���쐬����
        /// </summary>
        /// <param name="sqlCommand">SQL�R�}���h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="printPaperUseDivcd">���[�敪�R�[�h(1:���[,2:�`�[)</param>
        /// <param name="printPaperDivCd">���[�敪�R�[�h(1:�������[,2:�������[,3:�N�����[,4:�������[)</param>
        /// <param name="dataInputSystem ">�f�[�^���̓V�X�e��(0:����,1:SF,2:BK,3:SH)</param>
        /// <returns>WHERE��</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem)
        {
            StringBuilder whereString = new StringBuilder();

            // ��ƃR�[�h�͕K�{����
            whereString.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = enterpriseCode;

            // ���[�敪�R�[�h(1:���[,2:�`�[)
            if (printPaperUseDivcd != 0)
            {
                whereString.Append(" AND ");
                whereString.Append("PRINTPAPERUSEDIVCDRF=@FINDPRINTPAPERUSEDIVCD");
                SqlParameter findParaPrintPaperUseDivcd = sqlCommand.Parameters.Add("@FINDPRINTPAPERUSEDIVCD", SqlDbType.Int);
                findParaPrintPaperUseDivcd.Value = printPaperUseDivcd;
            }

            // ���[�敪�R�[�h(1:�������[,2:�������[,3:�N�����[,4:�������[)
            if (printPaperDivCd != 0)
            {
                whereString.Append(" AND ");
                whereString.Append("PRINTPAPERDIVCDRF=@FINDPRINTPAPERDIVCD");
                SqlParameter findParaPrintPaperDivCd = sqlCommand.Parameters.Add("@FINDPRINTPAPERDIVCD", SqlDbType.Int);
                findParaPrintPaperDivCd.Value = printPaperDivCd;
            }

            // �f�[�^���̓V�X�e��(0:����,1:SF,2:BK,3:SH)
            if (dataInputSystem != null && dataInputSystem.Length > 0)
            {
                whereString.Append(" AND ");
                whereString.Append("DATAINPUTSYSTEMRF IN (");
                StringBuilder wkStr = new StringBuilder();
                foreach (int systemDivCd in dataInputSystem)
                {
                    if (wkStr.Length > 0)
                        wkStr.Append(",");
                    wkStr.Append(systemDivCd);
                }
                whereString.Append(wkStr.ToString()).Append(")");
            }

            return whereString.ToString();
        }
        #endregion

        #region �󎚈ʒu�����폜
        /// <summary>
        /// ���R���[�󎚈ʒu���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">FrePrtPSetWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int DeleteFrePrtPSet( byte[] parabyte, out bool msgDiv, out string errMsg )
        {
            return DeleteFrePrtPSetProc( parabyte, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�󎚈ʒu���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">FrePrtPSetWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int DeleteFrePrtPSetProc( byte[] parabyte, out bool msgDiv, out string errMsg )
        {
            int status;
            msgDiv = false;
            errMsg = "";
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
            List<SlipPrtSetWork> deleteSlipList = new List<SlipPrtSetWork>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
            
            sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // XML�̓ǂݍ���
                FrePrtPSetWork frePrtPSetWork = (FrePrtPSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(FrePrtPSetWork));

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                if ( frePrtPSetWork.PrintPaperUseDivcd == 2 )
                {
                    // �`�[����ݒ�̒��o
                    deleteSlipList = SearchSlipPrtSet( frePrtPSetWork, ref sqlConnection );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �󎚈ʒu�f�[�^�����폜
                status = DeleteFrePrtPSetProc(frePrtPSetWork, sqlConnection, sqlTransaction);

                // �\�[�g�������폜
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = DeleteFrePprSrtOProc(frePrtPSetWork, sqlConnection, sqlTransaction);
                }
                // ���o���������폜
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = DeleteFrePprECndProc(frePrtPSetWork, sqlConnection, sqlTransaction);
                }
                // �`�[����ݒ�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �`�[�̎�
                    if (frePrtPSetWork.PrintPaperUseDivcd == 2)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
                        //SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                        ////status = slipPrtSetDB.Delete(frePrtPSetWork.EnterpriseCode, frePrtPSetWork.DataInputSystem, frePrtPSetWork.OutputFormFileName + frePrtPSetWork.UserPrtPprIdDerivNo.ToString(), sqlConnection, sqlTransaction);
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 ADD
                        //int slipPrtKind = 30;   // 30:����`�[
                        //status = slipPrtSetDB.Delete( frePrtPSetWork.EnterpriseCode, frePrtPSetWork.DataInputSystem, slipPrtKind, frePrtPSetWork.OutputFormFileName + frePrtPSetWork.UserPrtPprIdDerivNo.ToString(), ref sqlConnection, ref sqlTransaction );
                        //if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR )
                        //{
                        //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        //}
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 ADD
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
                        DeleteSlipPrtSet( deleteSlipList, ref sqlConnection, ref sqlTransaction );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
                    }
                }
                // �󎚈ʒu�U�֏��폜
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //���[�̎�
                    if (frePrtPSetWork.PrintPaperUseDivcd == 1)
                    {
                        FreePprGrpDB freePprGrpDB = new FreePprGrpDB();
                        status = freePprGrpDB.DeleteFrePprGrTrProc(frePrtPSetWork.EnterpriseCode, frePrtPSetWork.OutputFormFileName, frePrtPSetWork.UserPrtPprIdDerivNo, sqlConnection, sqlTransaction);
                    }
                }


                // �R�~�b�gor���[���o�b�N����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null)
                        sqlTransaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                // ���[���o�b�N
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.DeleteFrePrtPSet SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�󎚈ʒu�ݒ���폜���ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                // ���[���o�b�N
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
                base.WriteErrorLog(ex, "FreePprGrpDB.DeleteFrePrtPSet Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null) sqlConnection.Close();
            }

            return status;
        }

        /// <summary>
        /// �`�[����ݒ�폜�Ώے��o
        /// </summary>
        /// <param name="frePrtPSetWork"></param>
        /// <param name="sqlConnection"></param>
        private List<SlipPrtSetWork> SearchSlipPrtSet( FrePrtPSetWork frePrtPSetWork, ref SqlConnection sqlConnection )
        {
            List<SlipPrtSetWork> slipPrtSetWorkList = new List<SlipPrtSetWork>();

            SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();
            ArrayList retList;
            SlipPrtSetWork paraWork = new SlipPrtSetWork();
            paraWork.EnterpriseCode = frePrtPSetWork.EnterpriseCode;

            int status = slipPrtSetDB.Search( out retList, paraWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                foreach ( SlipPrtSetWork slipPrtSetWork in retList )
                {
                    //if ( slipPrtSetWork.EnterpriseCode == frePrtPSetWork.EnterpriseCode
                    //    && slipPrtSetWork.OutputFormFileName == frePrtPSetWork.OutputFormFileName
                    //    && slipPrtSetWork.SpecialPurpose2 == frePrtPSetWork.UserPrtPprIdDerivNo.ToString() )
                    if ( slipPrtSetWork.EnterpriseCode == frePrtPSetWork.EnterpriseCode
                        && slipPrtSetWork.OutputFormFileName == frePrtPSetWork.OutputFormFileName)
                    {
                        slipPrtSetWorkList.Add( slipPrtSetWork );
                    }
                }
            }

            return slipPrtSetWorkList;
        }

        /// <summary>
        /// �`�[����ݒ�폜����
        /// </summary>
        /// <param name="slipPrtSetWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        private void DeleteSlipPrtSet( List<SlipPrtSetWork> slipPrtSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();

            foreach ( SlipPrtSetWork slipPrtSetWork in slipPrtSetWorkList )
            {
                // �폜
                slipPrtSetDB.Delete( slipPrtSetWork.EnterpriseCode, slipPrtSetWork.DataInputSystem, slipPrtSetWork.SlipPrtKind, slipPrtSetWork.SlipPrtSetPaperId, ref sqlConnection, ref sqlTransaction );
            }
        }

        #region ���R���[�󎚈ʒu���𕨗��폜
        /// <summary>
        /// ���R���[�󎚈ʒu���𕨗��폜���܂�
        /// </summary>
        /// <param name="frePrtPSetWork">���R���[�󎚈ʒu���[�N</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteFrePrtPSetProc(FrePrtPSetWork frePrtPSetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPRTPSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO", sqlConnection, sqlTransaction);

                //Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);
                
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                
                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != frePrtPSetWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        if (!myReader.IsClosed) myReader.Close();
                        return status;
                    }

                    sqlCommand.CommandText = "DELETE FROM FREPRTPSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                    findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();
                    return status;
                }
                if (!myReader.IsClosed) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FrePrtPSetDLDB.DeleteFreePprGrpProc SQLException=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePrtPSetDLDB.DeleteFreePprGrpProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion

        #region ���R���[�\�[�g�����𕨗��폜
        /// <summary>
        /// ���R���[�\�[�g�����𕨗��폜���܂�
        /// </summary>
        /// <param name="frePrtPSetWork">���R���[�󎚈ʒu���[�N</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteFrePprSrtOProc(FrePrtPSetWork frePrtPSetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("SELECT ENTERPRISECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPPRSRTORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO ", sqlConnection, sqlTransaction);

                //Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    sqlCommand.CommandText = "DELETE FROM FREPPRSRTORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                    findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                }
                if (!myReader.IsClosed) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FrePrtPSetDLDB.DeleteFrePprSrtOProc SQLException=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePrtPSetDLDB.DeleteFrePprSrtOProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion

        #region ���R���[���o�������𕨗��폜
        /// <summary>
        /// ���R���[���o�������𕨗��폜���܂�
        /// </summary>
        /// <param name="frePrtPSetWork">���R���[�󎚈ʒu���[�N</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteFrePprECndProc(FrePrtPSetWork frePrtPSetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("SELECT ENTERPRISECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPPRECNDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO ", sqlConnection, sqlTransaction);

                //Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    sqlCommand.CommandText = "DELETE FROM FREPPRECNDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                    findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                }
                if (!myReader.IsClosed) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FrePrtPSetDLDB.DeleteFrePprECndProc SQLException=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePrtPSetDLDB.DeleteFrePprECndProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion

    #endregion
    }
}