using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���R���[�O���[�vDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R���[�O���[�v�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 22011�@�����@���l</br>
	/// <br>Date       : 2007.05.22</br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class FreePprGrpDB : RemoteDB, IRemoteDB, IFreePprGrpDB
	{
		#region Constructor
		/// <summary>
		/// ���R���[�O���[�vDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 22011�@�����@���l</br>
		/// <br>Date       : 2007.05.22</br>
		/// </remarks>
		public FreePprGrpDB() :
		base("SFANL08224D", "Broadleaf.Application.Remoting.ParamData.FreePprGrpWork", "FREEPPRGRPRF")
		{
		}
		#endregion

        #region ���R���[�O���[�vLIST�擾 Search
        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retObj">��������</param>
		/// <param name="paraObj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int SearchFreePprGrp( out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            return SearchFreePprGrpProc( out retObj, paraObj, readMode, logicalMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int SearchFreePprGrpProc( out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
		{
            msgDiv = false;
            errMsg = "";
            retObj = new ArrayList();
            SqlConnection sqlConnection = null;
            FreePprGrpWork freePprGrpWork = new FreePprGrpWork();
            int status = 0;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.SearchFreePprGrp");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            // XML�̓ǂݍ���
            freePprGrpWork = (FreePprGrpWork)paraObj;

            try
            {
                bool nextData;
                int retTotalCnt;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;


                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("SearchFreePprGrp Para: EnterpriseCode {0}", freePprGrpWork.EnterpriseCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                status = SearchFreePprGrpProc(out retObj, out retTotalCnt, out nextData, freePprGrpWork, readMode, logicalMode, 0, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.SearchFreePprGrp SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v��񌟍����ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.SearchFreePprGrp Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }


        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retObj">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
        /// <param name="freePprGrpWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        private int SearchFreePprGrpProc(out object retObj, out int retTotalCnt, out bool nextData, FreePprGrpWork freePprGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

            retObj = new ArrayList();

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;
			if (_readCnt > 0) _readCnt += 1;

			//�����R�[�h�����ŏ�����
			nextData = false;
			ArrayList al = new ArrayList();
			try 
			{	
                sqlCommand = new SqlCommand("SELECT * FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY FREEPRTPPRGROUPCDRF", sqlConnection);

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = freePprGrpWork.EnterpriseCode;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				while(myReader.Read())
				{
					FreePprGrpWork wkFreePprGrpWork = new FreePprGrpWork();

                    wkFreePprGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFreePprGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFreePprGrpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFreePprGrpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFreePprGrpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFreePprGrpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFreePprGrpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFreePprGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFreePprGrpWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    wkFreePprGrpWork.FreePrtPprGroupNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPNMRF"));

					al.Add(wkFreePprGrpWork);
				}
                if(al.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "SectionInfo.SearchFreePprGrpProc SQL Exception=" + ex.Message, status);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"SectionInfo.SearchFreePprGrpProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
            }
            retObj = (object)al;
			return status;
        }

        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retList">��������</param>
		/// <param name="freePprGrpWork">��������</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int SearchFreePprGrp( out ArrayList retList, FreePprGrpWork freePprGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out bool msgDiv, out string errMsg )
        {
            return SearchFreePprGrpProc( out retList, freePprGrpWork, readMode, logicalMode, ref sqlConnection, out msgDiv, out errMsg );
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="freePprGrpWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int SearchFreePprGrpProc( out ArrayList retList, FreePprGrpWork freePprGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";
			retList = new ArrayList();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.SearchFreePprGrp");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			try 
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("SearchFreePprGrp Para: EnterpriseCode {0}", freePprGrpWork.EnterpriseCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

				//�f�[�^�Ǎ�
                sqlCommand = new SqlCommand("SELECT * FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY FREEPRTPPRGROUPCDRF", sqlConnection);
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = freePprGrpWork.EnterpriseCode;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);
                myReader = sqlCommand.ExecuteReader();

				while(myReader.Read())
				{
					FreePprGrpWork wkFreePprGrpWork = new FreePprGrpWork();
                    wkFreePprGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFreePprGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFreePprGrpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFreePprGrpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFreePprGrpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFreePprGrpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFreePprGrpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFreePprGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFreePprGrpWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    wkFreePprGrpWork.FreePrtPprGroupNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPNMRF"));
					retList.Add(wkFreePprGrpWork);
				}
				if(retList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.SearchFreePprGrpProc SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v��񌟍����ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.SearchFreePprGrpProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
            }

			return status;
		}
		#endregion

		#region ���R���[�O���[�v���擾 ReadFreePprGrp
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�v��߂��܂�
		/// </summary>
		/// <param name="parabyte">FreePprGrpWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int ReadFreePprGrp( ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg )
        {
            return ReadFreePprGrpProc( ref parabyte, readMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�v��߂��܂�
        /// </summary>
        /// <param name="parabyte">FreePprGrpWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int ReadFreePprGrpProc( ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			FreePprGrpWork freePprGrpWork = new FreePprGrpWork();
			SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.ReadFreePprGrp");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
			
            try 
			{
				// XML�̓ǂݍ���
				freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte,typeof(FreePprGrpWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("ReadFreePprGrp Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}", freePprGrpWork.EnterpriseCode, freePprGrpWork.FreePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

				//Select�R�}���h�̐���	
                sqlCommand = new SqlCommand("SELECT * FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
                    freePprGrpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    freePprGrpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    freePprGrpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    freePprGrpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    freePprGrpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    freePprGrpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    freePprGrpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    freePprGrpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    freePprGrpWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    freePprGrpWork.FreePrtPprGroupNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPNMRF"));
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.ReadFreePprGrp SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v���Ǎ����ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.ReadFreePprGrp Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(freePprGrpWork);
			return status;
		}

		#endregion

		#region ���R���[�O���[�v���o�^���X�V WriteFreePprGrp
		/// <summary>
		/// ���R���[�O���[�v����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">FreePprGrpWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int WriteFreePprGrp( ref byte[] parabyte, out bool msgDiv, out string errMsg )
        {
            return WriteFreePprGrpProc( ref parabyte, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�O���[�v����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">FreePprGrpWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int WriteFreePprGrpProc( ref byte[] parabyte, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.WriteFreePprGrp");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			try 
			{
				// XML�̓ǂݍ���
				FreePprGrpWork freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte,typeof(FreePprGrpWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("WriteFreePprGrp Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}", freePprGrpWork.EnterpriseCode, freePprGrpWork.FreePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

				myReader = sqlCommand.ExecuteReader();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != freePprGrpWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (freePprGrpWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    sqlCommand.CommandText = "UPDATE FREEPPRGRPRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , FREEPRTPPRGROUPCDRF=@FREEPRTPPRGROUPCD , FREEPRTPPRGROUPNMRF=@FREEPRTPPRGROUPNM WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD";

					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)freePprGrpWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (freePprGrpWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = "INSERT INTO FREEPPRGRPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FREEPRTPPRGROUPCDRF, FREEPRTPPRGROUPNMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FREEPRTPPRGROUPCD, @FREEPRTPPRGROUPNM)";
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)freePprGrpWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(!myReader.IsClosed)myReader.Close();

				//Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter paraFreePrtPprGroupNm = sqlCommand.Parameters.Add("@FREEPRTPPRGROUPNM", SqlDbType.NVarChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freePprGrpWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freePprGrpWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(freePprGrpWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(freePprGrpWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(freePprGrpWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(freePprGrpWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(freePprGrpWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(freePprGrpWork.LogicalDeleteCode);
                paraFreePrtPprGroupCd.Value = SqlDataMediator.SqlSetInt32(freePprGrpWork.FreePrtPprGroupCd);
                paraFreePrtPprGroupNm.Value = SqlDataMediator.SqlSetString(freePprGrpWork.FreePrtPprGroupNm);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(freePprGrpWork);
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.WriteFreePprGrp SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v��񏑂����ݒ��ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.WriteFreePprGrp Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			return status;
		}

		#endregion

        #region ���R���[�O���[�v��񁕎��R���[�O���[�v�U�֏�񕨗��폜 DeleteFreePprGrpAll
        /// <summary>
		/// ���R���[�O���[�v���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte1">���R���[�O���[�v�I�u�W�F�N�g</param>
		/// <param name="parabyte2">���R���[�O���[�v�U�փI�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns></returns>
        public int DeleteFreePprGrpAll( ref byte[] parabyte1, ref byte[] parabyte2, out bool msgDiv, out string errMsg )
        {
            return DeleteFreePprGrpAllProc( ref parabyte1, ref parabyte2, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�O���[�v���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte1">���R���[�O���[�v�I�u�W�F�N�g</param>
        /// <param name="parabyte2">���R���[�O���[�v�U�փI�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns></returns>
        private int DeleteFreePprGrpAllProc( ref byte[] parabyte1, ref byte[] parabyte2, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTrans = null;
            msgDiv = false;
            errMsg = "";
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            
            // XML�̓ǂݍ���
            FreePprGrpWork freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte1, typeof(FreePprGrpWork));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.DeleteFreePprGrpAll");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return status;

			sqlConnection = new SqlConnection(connectionText);
			sqlConnection.Open();

            try
            {
                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("DeleteFreePprGrpAll Para: EnterpriseCode {0}", freePprGrpWork.EnterpriseCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                status = DeleteFreePprGrp(ref freePprGrpWork, sqlConnection, sqlTrans);
            
                if (status == 0)
                {
                    if (parabyte2 != null)
                    {
                        status = DeleteFrePprGrTr(ref parabyte2, sqlConnection, sqlTrans);

                        if (status == 0)
                            sqlTrans.Commit();
                        else
                            sqlTrans.Rollback();
                    }
                    else
                    {
                        sqlTrans.Commit();
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                }


            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex,"FreePprGrpDB.DeleteFreePprGrpAll SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v���폜���ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.DeleteFreePprGrpAll Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlTrans.Dispose();
            }
			return status;
		}

		/// <summary>
		/// ���R���[�O���[�v���𕨗��폜���܂�
		/// </summary>
        /// <param name="freePprGrpWork">���R���[�O���[�v���[�N</param>
		/// <param name="sqlConnection"></param>
		/// <param name="sqlTrans"></param>
        /// <returns></returns>
        private int DeleteFreePprGrp(ref FreePprGrpWork freePprGrpWork, SqlConnection sqlConnection, SqlTransaction sqlTrans)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection, sqlTrans);

				//Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != freePprGrpWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(!myReader.IsClosed)myReader.Close();
						return status;
					}

                    sqlCommand.CommandText = "DELETE FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD";
					//KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = freePprGrpWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = freePprGrpWork.FreePrtPprGroupCd;
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					if(!myReader.IsClosed)myReader.Close();
					return status;
				}
				if(!myReader.IsClosed)myReader.Close();

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
         	}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.DeleteFreePprGrp Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
            }

			return status;
		}
		#endregion

		#region ���R���[�O���[�v�U��LIST�擾 SearchFrePprGrTr
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="retbyte">��������(FrePprGrTrWork�̔z��)</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv"></param>
        /// <param name="errMsg"></param>
		/// <returns>STATUS</returns>
        public int SearchFrePprGrTr( out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            return SearchFrePprGrTrProc( out retbyte, parabyte, readMode, logicalMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retbyte">��������(FrePprGrTrWork�̔z��)</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv"></param>
        /// <param name="errMsg"></param>
        /// <returns>STATUS</returns>
        private int SearchFrePprGrTrProc( out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
		{
			bool nextData;
			int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            msgDiv = false;
            SqlConnection sqlConnection = null;
            FrePprGrTrWork frePprGrTrWork = null;
            errMsg = "";

            // XML�̓ǂݍ���
            frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte, typeof(FrePprGrTrWork));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.SearchFrePprGrTr");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            try
            {
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("SearchFrePprGrTr Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}", frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                status = SearchFrePprGrTrProc(out retbyte, out retTotalCnt, out nextData, frePprGrTrWork, readMode, logicalMode, 0, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.SearchFrePprGrTr SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v�U�֏�񌟍����ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.SearchFrePprGrTr Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�����R���[�O���[�v�R�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂�
		/// </summary>
        /// <param name="retbyte">��������(FrePprGrTrWork�̔z��)</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
        /// <param name="frePprGrTrWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        private int SearchFrePprGrTrProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, FrePprGrTrWork frePprGrTrWork, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			retbyte = null;

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;
			if (_readCnt > 0) _readCnt += 1;
			//�����R�[�h�����ŏ�����
			nextData = false;

			ArrayList al = new ArrayList();
			try
			{				
				//�f�[�^�Ǎ�
                sqlCommand = new SqlCommand("SELECT * FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);

                //�p�����[�^�ݒ�
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				//int retCnt = 0;
				while(myReader.Read())
				{
					FrePprGrTrWork wkFrePprGrTrWork = new FrePprGrTrWork();

                    frePprGrTrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    frePprGrTrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    frePprGrTrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    frePprGrTrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    frePprGrTrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    frePprGrTrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    frePprGrTrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    frePprGrTrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    frePprGrTrWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    frePprGrTrWork.TransferCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRANSFERCODERF"));
                    frePprGrTrWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    frePprGrTrWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                    frePprGrTrWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    frePprGrTrWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));

                    al.Add(frePprGrTrWork);
				}
                if(al.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.SearchFreePprGrpProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
            }

			// XML�֕ϊ����A������̃o�C�i����
			FrePprGrTrWork[] FrePprGrTrWorks = (FrePprGrTrWork[])al.ToArray(typeof(FrePprGrTrWork));
			retbyte = XmlByteSerializer.Serialize(FrePprGrTrWorks);

			return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�����R���[�O���[�v�R�[�h�̎��R���[�O���[�v����LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="enterpriseCode">�����p��ƃR�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int SearchFrePprGrTrAll( out object retObj, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            return SearchFrePprGrTrAllProc( out retObj, enterpriseCode, readMode, logicalMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�����R���[�O���[�v�R�[�h�̎��R���[�O���[�v����LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="enterpriseCode">�����p��ƃR�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int SearchFrePprGrTrAllProc( out object retObj, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";
            retObj = new ArrayList();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.SearchFrePprGrTrAll");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�f�[�^�Ǎ�
                sqlCommand = new SqlCommand("SELECT * FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);


                //�p�����[�^�ݒ�
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = enterpriseCode;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("SearchFrePprGrTrAll Para: EnterpriseCode {0}", enterpriseCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    FrePprGrTrWork wkFrePprGrTrWork = new FrePprGrTrWork();

                    wkFrePprGrTrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFrePprGrTrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFrePprGrTrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFrePprGrTrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFrePprGrTrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFrePprGrTrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFrePprGrTrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFrePprGrTrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFrePprGrTrWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    wkFrePprGrTrWork.TransferCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRANSFERCODERF"));
                    wkFrePprGrTrWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    wkFrePprGrTrWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                    wkFrePprGrTrWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    wkFrePprGrTrWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));

                    al.Add(wkFrePprGrTrWork);
                }
                if(al.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.SearchFreePprGrpAll SQLException=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.SearchFreePprGrpAll Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)al;

            return status;
        }
        #endregion

        #region ���R���[�O���[�v���׏��擾 ReadFreePprGrpDtl
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�E���R���[�O���[�v�R�[�h�E���R���[�O���[�v�U�փR�[�h�̎��R���[�O���[�v�U�ւ�߂��܂�
        /// </summary>
        /// <param name="parabyte">FrePprGrTrWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int ReadFrePprGrTr( ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg )
        {
            return ReadFrePprGrTrProc( ref parabyte, readMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�E���R���[�O���[�v�R�[�h�E���R���[�O���[�v�U�փR�[�h�̎��R���[�O���[�v�U�ւ�߂��܂�
        /// </summary>
        /// <param name="parabyte">FrePprGrTrWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int ReadFrePprGrTrProc( ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            FrePprGrTrWork frePprGrTrWork = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.Read");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            try
            {
                // XML�̓ǂݍ���
                frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte, typeof(FrePprGrTrWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("ReadFrePprGrTr Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}, TransferCode{2}", frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, frePprGrTrWork.TransferCode), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                //Select�R�}���h�̐���	
                sqlCommand = new SqlCommand("SELECT * FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE", sqlConnection);
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter findParaTransferCode = sqlCommand.Parameters.Add("@FINDTRANSFERCODE", SqlDbType.Int);
                
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                findParaTransferCode.Value = frePprGrTrWork.TransferCode;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    frePprGrTrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    frePprGrTrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    frePprGrTrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    frePprGrTrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    frePprGrTrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    frePprGrTrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    frePprGrTrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    frePprGrTrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    frePprGrTrWork.FreePrtPprGroupCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRGROUPCDRF"));
                    frePprGrTrWork.TransferCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRANSFERCODERF"));
                    frePprGrTrWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    frePprGrTrWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                    frePprGrTrWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    frePprGrTrWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.ReadFrePprGrTr SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v�U�֏��Ǎ����ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.ReadFrePprGrTr Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            // XML�֕ϊ����A������̃o�C�i����
            parabyte = XmlByteSerializer.Serialize(frePprGrTrWork);
            return status;
        }
        #endregion

        #region ���R���[�O���[�v�U�֏��o�^���X�V WriteFrePprGrTr
        /// <summary>
		/// ���R���[�O���[�v�U�֏���o�^�A�X�V���܂�
		/// </summary>
        /// <param name="paraobj">FrePprGrTrWorkList</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int WriteFrePprGrTr( ref object paraobj, out bool msgDiv, out string errMsg )
        {
            return WriteFrePprGrTrProc( ref paraobj, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�O���[�v�U�֏���o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">FrePprGrTrWorkList</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int WriteFrePprGrTrProc( ref object paraobj, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.WriteFrePprGrTr");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			try 
			{
				// XML�̓ǂݍ���
				//FrePprGrTrWork frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte,typeof(FrePprGrTrWork));
                
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);


                foreach (FrePprGrTrWork frePprGrTrWork in (List<FrePprGrTrWork>)paraobj)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                    //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                    //jobAcs.StartWriteServiceJob(string.Format("WriteFrePprGrTr Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}, TransferCode{2}", frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, frePprGrTrWork.TransferCode), sqlConnection);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                    //�U�փR�[�h�̍̔�
                    if (frePprGrTrWork.TransferCode == 0)
                    {
                        frePprGrTrWork.TransferCode = (GetLastTransferCode(frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, out msgDiv, out errMsg) + 1);
                    }
                    //�\�����ʂ̍̔�
                    if (frePprGrTrWork.DisplayOrder == 0)
                    {
                        frePprGrTrWork.DisplayOrder = (GetLastDisplayOrder(frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, out msgDiv, out errMsg) + 1);
                        
                    }
                    //DB�֏�������
                    status = WriteFrePprGrTr(frePprGrTrWork, ref sqlConnection, ref sqlTransaction);
                    if (status != 0) break;
                }
				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				//parabyte = XmlByteSerializer.Serialize(frePprGrTrWork);
			}
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.WriteFrePprGrTr SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v�U�֏�񏑂����ݎ��ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.WriteFrePprGrTr Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if(sqlConnection != null)
                {
                    // �R�~�b�gor���[���o�b�N
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
			return status;
		}

        /// <summary>
        /// ���R���[�O���[�v�U�֏���o�^�A�X�V���܂�
        /// </summary>
        /// <param name="frePprGrTrWork">���R���[�O���[�v�U��</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteFrePprGrTr(FrePprGrTrWork frePprGrTrWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //����O���[�v���Ɋ��ɓ����󎚈ʒu��񂪊֘A�Â����Ă��邩�`�F�b�N
                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF, DISPLAYORDERRF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF<>@FINDTRANSFERCODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO", sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode         = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd      = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter findParaTransferCode           = sqlCommand.Parameters.Add("@FINDTRANSFERCODE", SqlDbType.Int);
                SqlParameter findParaOutPutFormFileName     = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NChar);
                SqlParameter findParaUserPrtPprIdDerivNo    = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.NChar);
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value        = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value     = frePprGrTrWork.FreePrtPprGroupCd;
                findParaTransferCode.Value          = frePprGrTrWork.TransferCode;
                findParaOutPutFormFileName.Value    = frePprGrTrWork.OutputFormFileName;
                findParaUserPrtPprIdDerivNo.Value   = frePprGrTrWork.UserPrtPprIdDerivNo;
                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    // �O���[�v���ɓo�^�f�[�^�����������ꍇ�d���G���[�Ƃ��ď���
                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    return status;
                }
                if (!myReader.IsClosed) myReader.Close();


                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF, DISPLAYORDERRF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE", sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd2 = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter findParaTransferCode2 = sqlCommand.Parameters.Add("@FINDTRANSFERCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode2.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd2.Value = frePprGrTrWork.FreePrtPprGroupCd;
                findParaTransferCode2.Value = frePprGrTrWork.TransferCode;

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != frePprGrTrWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (frePprGrTrWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
							//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    sqlCommand.CommandText = "UPDATE FREPPRGRTRRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , FREEPRTPPRGROUPCDRF=@FREEPRTPPRGROUPCD , TRANSFERCODERF=@TRANSFERCODE , DISPLAYORDERRF=@DISPLAYORDER , DISPLAYNAMERF=@DISPLAYNAME , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , USERPRTPPRIDDERIVNORF=@USERPRTPPRIDDERIVNO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE";
					//KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                    findParaTransferCode.Value = frePprGrTrWork.TransferCode;
                    
					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)frePprGrTrWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (frePprGrTrWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = "INSERT INTO FREPPRGRTRRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FREEPRTPPRGROUPCDRF, TRANSFERCODERF, DISPLAYORDERRF, DISPLAYNAMERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FREEPRTPPRGROUPCD, @TRANSFERCODE, @DISPLAYORDER, @DISPLAYNAME, @OUTPUTFORMFILENAME, @USERPRTPPRIDDERIVNO)";
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)frePprGrTrWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(!myReader.IsClosed)myReader.Close();

				//Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter paraTransferCode = sqlCommand.Parameters.Add("@TRANSFERCODE", SqlDbType.Int);
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                SqlParameter paraDisplayName = sqlCommand.Parameters.Add("@DISPLAYNAME", SqlDbType.NVarChar);
                SqlParameter paraOutputFormFileName = sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter paraUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@USERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(frePprGrTrWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(frePprGrTrWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(frePprGrTrWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(frePprGrTrWork.LogicalDeleteCode);

                paraFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                paraDisplayOrder.Value = frePprGrTrWork.DisplayOrder;
                paraDisplayName.Value = frePprGrTrWork.DisplayName;
                paraOutputFormFileName.Value = frePprGrTrWork.OutputFormFileName;
                paraUserPrtPprIdDerivNo.Value = frePprGrTrWork.UserPrtPprIdDerivNo;
                paraTransferCode.Value = frePprGrTrWork.TransferCode;

				sqlCommand.ExecuteNonQuery();
                
				status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch ( SqlException ex ) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch( Exception ex )
            {
                base.WriteErrorLog( ex, "FreePprGrpDB.WriteFrePprGrTrWork Exception=" + ex.Message );
                status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if( sqlCommand != null )sqlCommand.Dispose();
                if( !myReader.IsClosed )myReader.Close();
            }
			return status;
        }
		#endregion

        #region ���R���[�O���[�v�U�֏�񏉊��o�^����
        /// <summary>
        /// ���R���[�O���[�v�U�֏���S�O���[�v�ɓo�^���܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="displayName">�o�͖���</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqltrance">�g�����U�N�V�������</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>�X�e�[�^�X</returns>
        public int EntryFrePprGrTr( string enterpriseCode, string displayName, string outputFormFileName, Int32 userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction sqltrance, out bool msgDiv, out string errMsg )
        {
            return EntryFrePprGrTrProc( enterpriseCode, displayName, outputFormFileName, userPrtPprIdDerivNo, sqlConnection, sqltrance, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�O���[�v�U�֏���S�O���[�v�ɓo�^���܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="displayName">�o�͖���</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqltrance">�g�����U�N�V�������</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>�X�e�[�^�X</returns>
        private int EntryFrePprGrTrProc( string enterpriseCode, string displayName, string outputFormFileName, Int32 userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction sqltrance, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.EntryFrePprGrTr");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            try
            {
                //�p�����[�^�[�����[�N�N���X�ɃZ�b�g
                FrePprGrTrWork frePprGrTrWork = new FrePprGrTrWork();
                frePprGrTrWork.EnterpriseCode = enterpriseCode;
                frePprGrTrWork.OutputFormFileName = outputFormFileName;
                frePprGrTrWork.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                frePprGrTrWork.DisplayName = displayName;
                frePprGrTrWork.DisplayOrder = (GetLastDisplayOrder(enterpriseCode, 0, out msgDiv, out errMsg)+1);
                frePprGrTrWork.TransferCode = (GetLastTransferCode(enterpriseCode, 0, out msgDiv, out errMsg)+1);
                frePprGrTrWork.FreePrtPprGroupCd = 0;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("EntryFrePprGrTr Para: enterpriseCode {0}, displayName{1}, outputFormFileName{2}, userPrtPprIdDerivNo{3}", enterpriseCode, displayName, outputFormFileName, userPrtPprIdDerivNo), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                //�V�K�쐬����SQL���𐶐�
                sqlCommand = new SqlCommand("INSERT INTO FREPPRGRTRRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FREEPRTPPRGROUPCDRF, TRANSFERCODERF, DISPLAYORDERRF, DISPLAYNAMERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FREEPRTPPRGROUPCD, @TRANSFERCODE, @DISPLAYORDER, @DISPLAYNAME, @OUTPUTFORMFILENAME, @USERPRTPPRIDDERIVNO)");
                // �R�l�N�V��������ݒ�
                sqlCommand.Connection = sqlConnection;

                //�o�^�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)frePprGrTrWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetInsertHeader(ref flhd, obj);
            
                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                // �g�����U�N�V�����̐ݒ�
                if (sqltrance != null) sqlCommand.Transaction = sqltrance;// �g�����U�N�V�����̐ݒ�

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter paraTransferCode = sqlCommand.Parameters.Add("@TRANSFERCODE", SqlDbType.Int);
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                SqlParameter paraDisplayName = sqlCommand.Parameters.Add("@DISPLAYNAME", SqlDbType.NVarChar);
                SqlParameter paraOutputFormFileName = sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter paraUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@USERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(frePprGrTrWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(frePprGrTrWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(frePprGrTrWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(frePprGrTrWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(frePprGrTrWork.LogicalDeleteCode);

                paraFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                paraDisplayOrder.Value = frePprGrTrWork.DisplayOrder;
                paraDisplayName.Value = frePprGrTrWork.DisplayName;
                paraOutputFormFileName.Value = frePprGrTrWork.OutputFormFileName;
                paraUserPrtPprIdDerivNo.Value = frePprGrTrWork.UserPrtPprIdDerivNo;
                paraTransferCode.Value = frePprGrTrWork.TransferCode;

                sqlCommand.ExecuteNonQuery();

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.EntryFrePprGrTr SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v�U��(�S�O���[�v�p)��񏑂����ݎ��ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.EntryFrePprGrTr Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
            }

            return status;
        }
        #endregion

        #region ���R���[�O���[�v�U�֏�񕨗��폜 DeleteFrePprGrTr
        /// <summary>
		/// ���R���[�O���[�v�U�֏��𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���R���[�O���[�v�U�փI�u�W�F�N�g</param>
		/// <param name="sqlConnection"></param>
		/// <param name="sqlTrans"></param>
        /// <returns></returns>
        private int DeleteFrePprGrTr(ref byte[] parabyte,SqlConnection sqlConnection, SqlTransaction sqlTrans)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
				// XML�̓ǂݍ���
               	FrePprGrTrWork[] ew = (FrePprGrTrWork[])XmlByteSerializer.Deserialize(parabyte,typeof(FrePprGrTrWork[]));
				FrePprGrTrWork frePprGrTrWork = ew[0];
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection,sqlTrans);
               
				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
               
				//Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                
                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
                myReader = sqlCommand.ExecuteReader();

                if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    sqlCommand.CommandText = "DELETE FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD";
					//KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                }
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					if(!myReader.IsClosed)myReader.Close();
					return status;
				}
				if(!myReader.IsClosed)myReader.Close();
                
				sqlCommand.ExecuteNonQuery();
                
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"FreePprGrpDB.DeleteFrePprGrTr Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
			finally
			{
                if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}
			return status;
		}
		#endregion

        #region ���R���[�O���[�v�U�֏�񕨗��폜
        /// <summary>
		/// ���R���[�O���[�v�U�֏��𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">FrePprGrTrWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int DtlDelete( byte[] parabyte, out bool msgDiv, out string errMsg )
        {
            return DtlDeleteProc( parabyte, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�O���[�v�U�֏��𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">FrePprGrTrWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int DtlDeleteProc( byte[] parabyte, out bool msgDiv, out string errMsg )
		{
			int status;
			SqlConnection sqlConnection = null;
            msgDiv = false;
            errMsg = "";
            // XML�̓ǂݍ���
            FrePprGrTrWork frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte, typeof(FrePprGrTrWork));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.DtlDelete");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

			sqlConnection = new SqlConnection(connectionText);
			sqlConnection.Open();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
            //jobAcs.StartWriteServiceJob(string.Format("DtlDelete Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}, TransferCode{2}", frePprGrTrWork.EnterpriseCode, frePprGrTrWork.FreePrtPprGroupCd, frePprGrTrWork.TransferCode), sqlConnection);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = DtlDeleteProc(frePprGrTrWork, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.DtlDelete SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v���폜���ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.DtlDelete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
            }
			sqlConnection.Close();
			return status;
		}

		/// <summary>
		/// ���R���[�O���[�v�U�֏��𕨗��폜���܂�
		/// </summary>
        /// <param name="frePprGrTrWork">���R���[�O���[�v�U�փ��[�N</param>
		/// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int DtlDeleteProc(FrePprGrTrWork frePprGrTrWork, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FREEPRTPPRGROUPCDRF, TRANSFERCODERF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE", sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                SqlParameter findParaTransferCode = sqlCommand.Parameters.Add("@FINDTRANSFERCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                findParaTransferCode.Value = frePprGrTrWork.TransferCode;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

					if (_updateDateTime != frePprGrTrWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(!myReader.IsClosed)myReader.Close();
						return status;
					}

                    sqlCommand.CommandText = "DELETE FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD AND TRANSFERCODERF=@FINDTRANSFERCODE";
					//KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = frePprGrTrWork.EnterpriseCode;
                    findParaFreePrtPprGroupCd.Value = frePprGrTrWork.FreePrtPprGroupCd;
                    findParaTransferCode.Value = frePprGrTrWork.TransferCode;
                }
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					if(myReader.IsClosed == false)myReader.Close();
					return status;
				}
				if(!myReader.IsClosed)myReader.Close();

				sqlCommand.ExecuteNonQuery();
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
                base.WriteErrorLog(ex, "FreePprGrpDB.DtlDeleteProc Exception=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}
			return status;
		}
		#endregion

        #region ���R���[�O���[�v�U�֏�񕨗��폜
        /// <summary>
        /// ���R���[�O���[�v�U�֏��𕨗��폜���܂�(�󎚈ʒu�ݒ�̃L�[�w��)
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h</param>
        /// <param name="outputFormFileName">�o�̓t�@�C������</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}��</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTrans">�g�����U�N�V����</param>
        /// <returns></returns>
        public int DeleteFrePprGrTrProc( string enterprisecode, string outputFormFileName, int userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction sqlTrans )
        {
            return DeleteFrePprGrTrProcProc( enterprisecode, outputFormFileName, userPrtPprIdDerivNo, sqlConnection, sqlTrans );
        }
        /// <summary>
        /// ���R���[�O���[�v�U�֏��𕨗��폜���܂�(�󎚈ʒu�ݒ�̃L�[�w��)
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h</param>
        /// <param name="outputFormFileName">�o�̓t�@�C������</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}��</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="sqlTrans">�g�����U�N�V����</param>
        /// <returns></returns>
        private int DeleteFrePprGrTrProcProc( string enterprisecode, string outputFormFileName, int userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction sqlTrans )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.DtlDelete");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
            
            try
            {
                sqlCommand = new SqlCommand("SELECT ENTERPRISECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO", sqlConnection, sqlTrans);
                                                                      �@�@�@�@�@�@�@�@�@�@�@�@�@�@
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NChar);
                SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = enterprisecode;
                findParaOutputFormFileName.Value = outputFormFileName;
                findParaUserPrtPprIdDerivNo.Value = userPrtPprIdDerivNo;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("DeleteFrePprGrTrProc Para: EnterpriseCode {0}, outputFormFileName{1}, userPrtPprIdDerivNo{2}", enterprisecode, outputFormFileName, userPrtPprIdDerivNo), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    sqlCommand.CommandText = "DELETE FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = enterprisecode;
                    findParaOutputFormFileName.Value = outputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = userPrtPprIdDerivNo;
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
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.DeleteFrePprGrTrProc Exception=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.DeleteFrePprGrTrProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, string.Empty, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion

        #region ���R���[�O���[�v�}�X�^�폜�`�F�b�N
        /// <summary>
		/// ���R���[�O���[�v�}�X�^�폜�`�F�b�N����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="checkFlg">�`�F�b�N����[true:�폜�n�j][false:�폜�m�f]</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        public int DeleteCheck( string enterpriseCode, Int32 freePrtPprGroupCd, out string message, out bool checkFlg, out bool msgDiv, out string errMsg )
        {
            return DeleteCheckProc( enterpriseCode, freePrtPprGroupCd, out message, out checkFlg, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�O���[�v�}�X�^�폜�`�F�b�N����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="checkFlg">�`�F�b�N����[true:�폜�n�j][false:�폜�m�f]</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        private int DeleteCheckProc( string enterpriseCode, Int32 freePrtPprGroupCd, out string message, out bool checkFlg, out bool msgDiv, out string errMsg )
		{
			int status = 0;
			SqlConnection sqlConnection = null;
			checkFlg = true;
			message = "";
            msgDiv = false;
            errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.DeleteCheck");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

			try
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("DeleteCheck Para: EnterpriseCode {0}, FreePrtPprGroupCd{1}", enterpriseCode, freePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

				status = ReadFreePprGrp(enterpriseCode, freePrtPprGroupCd, ref sqlConnection);



				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// OK
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					checkFlg = false;
					message = "���̎��R���[�O���[�v�͊��ɑ��[���ɂč폜����Ă��܂��B";
				}
				else
				{
					// �G���[
				}
																															   
				if ((!checkFlg) || (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)) return status;

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
			}
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.DeleteCheck SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "���R���[�O���[�v���폜�`�F�b�N���ɃT�[�o�[�Ń^�C���A�E�g���������܂����B";
                }
            }
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"FreePprGrpDB.DeleteCheck Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        	}
			finally
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
				if(sqlConnection != null)sqlConnection.Close();
			}
			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ���R���[�O���[�v�R�[�h�̑��݃`�F�b�N���܂�
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        private int ReadFreePprGrp(string enterpriseCode, Int32 freePrtPprGroupCd, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

            try
            {
                //Select�R�}���h�̐���	
                sqlCommand = new SqlCommand("SELECT FREEPRTPPRGROUPCDRF FROM FREEPPRGRPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = enterpriseCode;
                findParaFreePrtPprGroupCd.Value = freePrtPprGroupCd;

                //�^�C���A�E�g���Ԑݒ�
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.ReadFreePprGrp Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}
			return status;
		}
		#endregion

        #region �ŏI�U�փR�[�h�̔ԏ���
        /// <summary>
        /// �ŏI�U�փR�[�h�̔ԏ���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�ŏI�U�փR�[�h</returns>
        public int GetLastTransferCode( string enterpriseCode, int freePrtPprGroupCd, out bool msgDiv, out string errMsg )
        {
            return GetLastTransferCodeProc( enterpriseCode, freePrtPprGroupCd, out msgDiv, out errMsg );
        }
        /// <summary>
        /// �ŏI�U�փR�[�h�̔ԏ���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�ŏI�U�փR�[�h</returns>
        private int GetLastTransferCodeProc( string enterpriseCode, int freePrtPprGroupCd, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int lastTransferCode = 0;
            msgDiv = false;
            errMsg = string.Empty;


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.GetLastTransferCode");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            try
            {
                //SQL������
                sqlConnection = CreateSqlConnection();
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("GetLastTransferCode Para: enterpriseCode {0}, freePrtPprGroupCd {1}", enterpriseCode, freePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                // Select�R�}���h�̐���
                SqlCommand sqlCommand = new SqlCommand("SELECT TRANSFERCODE=MAX(TRANSFERCODERF) FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);
                // ��ƃR�[�h
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = enterpriseCode;
                // ���R���[�O���[�v�R�[�h
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                findParaFreePrtPprGroupCd.Value = freePrtPprGroupCd;

                // �^�C���A�E�g���Ԑݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    lastTransferCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRANSFERCODE"));
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.GetLastTransferCode SQLException = " + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "�ŏI�U�փR�[�h�̔ԏ������Ƀ^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.GetLastTransferCode Exception = "+ ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlConnection != null) sqlConnection.Close();
            }

            return lastTransferCode;
        }
        #endregion

        #region �ŏI�U�փR�[�h�̔ԏ���
        /// <summary>
        /// �ŏI�U�փR�[�h�̔ԏ���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�ŏI�U�փR�[�h</returns>
        public int GetLastDisplayOrder( string enterpriseCode, int freePrtPprGroupCd, out bool msgDiv, out string errMsg )
        {
            return GetLastDisplayOrderProc( enterpriseCode, freePrtPprGroupCd, out msgDiv, out errMsg );
        }
        /// <summary>
        /// �ŏI�U�փR�[�h�̔ԏ���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�ŏI�U�փR�[�h</returns>
        private int GetLastDisplayOrderProc( string enterpriseCode, int freePrtPprGroupCd, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int lastDisplayOrder = 0;
            msgDiv = false;
            errMsg = string.Empty;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFANL08225R", "FreePprGrpDB.GetLastDisplayOrder");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            try
            {
                //SQL������
                sqlConnection = CreateSqlConnection();
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("GetLastDisplayOrder Para: enterpriseCode {0}, freePrtPprGroupCd {1}", enterpriseCode, freePrtPprGroupCd), sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL

                // Select�R�}���h�̐���
                SqlCommand sqlCommand = new SqlCommand("SELECT DISPLAYORDER=MAX(DISPLAYORDERRF) FROM FREPPRGRTRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND FREEPRTPPRGROUPCDRF=@FINDFREEPRTPPRGROUPCD", sqlConnection);
                // ��ƃR�[�h
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = enterpriseCode;
                // ���R���[�O���[�v�R�[�h
                SqlParameter findParaFreePrtPprGroupCd = sqlCommand.Parameters.Add("@FINDFREEPRTPPRGROUPCD", SqlDbType.Int);
                findParaFreePrtPprGroupCd.Value = freePrtPprGroupCd;

                // �^�C���A�E�g���Ԑݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    lastDisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDER"));
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.GetLastDisplayOrder SQLException = " + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "�ŏI�\�����ʍ̔ԏ������Ƀ^�C���A�E�g���������܂����B";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreePprGrpDB.GetLastDisplayOrder Exception = "+ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                if (sqlConnection != null) sqlConnection.Close();
            }

            return lastDisplayOrder;
        }
        #endregion

        #region �R�l�N�V������񐶐�
        /// <summary>
        /// �R�l�N�V������񐶐�
        /// </summary>
        /// <returns>�R�l�N�V�������</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            return new SqlConnection(connectionText);
        }
        #endregion
    }
}
