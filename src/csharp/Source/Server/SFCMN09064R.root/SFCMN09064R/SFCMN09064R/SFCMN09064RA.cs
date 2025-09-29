using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using System.Diagnostics;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���[�U�[�K�C�hDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�U�[�K�C�h�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
    /// <br>Update Note	: 2009.06.01 xueqi
    ///					: ���[�U�[�K�C�h�敪���̂̓o�^���@��ύX�A���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)��ǉ��B</br>
    /// <br></br>
    /// <br>UpdataNote : 2009.06.11 panh</br>
    /// <br>           : 1.PVCS#228�Ή��B</br>
    /// <br>           : 2009.07.22 21015 �����@�F��</br>
    /// <br>           : ��Q�Ή��@�T�[�r�X�W���u�̂d�m�c���������܂�Ă��Ȃ������������C��</br>
    /// </remarks>
	[Serializable]
	public class UserGdBdUDB : RemoteDB , IUserGdBdUDB
	{
		/// <summary>
		/// ���[�U�[�K�C�hDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
        /// <br>Update Note: 2007.05.29 iwa �R���X�g���N�^���s���f�o�b�N�폜</br>
        /// </remarks>
		public UserGdBdUDB() :
            base("SFCMN09066D", "Broadleaf.Application.Remoting.ParamData.UserGdBdUWork", "USERGDBDURF")          //ADD 2009.06.11 panh FOR PVCS#228
		{
			//Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));//2007.05.29 iwa del
			//Debug.WriteLine(this.ToString() + " Constructer");//2007.05.29 iwa del
		}

		#region ���ʉ����\�b�h
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h���LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			Debug.WriteLine(this.ToString() + " SearchCnt");

			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retCnt = 0;
			status = SearchCntUserGdBdUProc(out retCnt, parabyte, readMode, logicalMode);
			return status;
		}
		
		/// <summary>
		/// ���[�U�[�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Search(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			Debug.WriteLine(this.ToString() + " Search");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retobj = null;
			status = SearchUserGdBdU(out retobj, paraobj, readMode, logicalMode);
			return status;	
		}

		/// <summary>
		/// �w�肳�ꂽUserGuideDivCd�̃��[�U�[�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchGuideDivCode(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			Debug.WriteLine(this.ToString() + " Search");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retobj = null;
			status = SearchUserGdBdUGuideDivCode(out retobj, paraobj, readMode, logicalMode);
			return status;	
		}
		
		/// <summary>
		/// �w�肳�ꂽ���[�U�[�K�C�hGuid�̃��[�U�[�K�C�h����߂��܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���[�U�[�K�C�hGuid�̃��[�U�[�K�C�h��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
			Debug.WriteLine(this.ToString() + " Read");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = ReadUserGdBdU(ref parabyte, readMode);
			return status;	
		}

		/// <summary>
		/// ���[�U�[�K�C�h����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Write(ref byte[] parabyte)
		{
			Debug.WriteLine(this.ToString() + " Write");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = WriteUserGdBdU(ref parabyte);
			return status;	
		}

		/// <summary>
		/// ���[�U�[�K�C�h���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h���𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Delete(byte[] parabyte)
		{
			Debug.WriteLine(this.ToString() + " Delete");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = DeleteUserGdBdU(parabyte);
			return status;	
		}

		/// <summary>
		/// ���[�U�[�K�C�h����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h����_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			Debug.WriteLine(this.ToString() + " LogicalDelete");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = LogicalDeleteUserGdBdU(ref parabyte);
			return status;			}

		/// <summary>
		/// �_���폜���[�U�[�K�C�h���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���[�U�[�K�C�h���𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			Debug.WriteLine(this.ToString() + " RevivalLogicalDelete");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = RevivalLogicalDeleteUserGdBdU(ref parabyte);
			return status;	
		}
		#endregion

  		#region ���[�U�[�K�C�h�}�X�^(���[�U�[�񋟕�)
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:UserGdBdUWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchCntUserGdBdU(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntUserGdBdUProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:UserGdBdUWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchCntUserGdBdUProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			UserGdBdUWork usergdbduWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				using(SqlCommand sqlCommand = new SqlCommand("SELECT COUNT (*) FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection))
				{
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommand.CommandText = sqlCommand.CommandText + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommand.CommandText = sqlCommand.CommandText + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

					//�f�[�^���[�h
					retCnt = (int)sqlCommand.ExecuteScalar();
					if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.SearchCntUserGdBdUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}
	
			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchUserGdBdU(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
			retobj = null;
			return SearchUserGdBdUProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
		}

//		/// <summary>
//		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
//		/// </summary>
//		/// <param name="retbyte">��������</param>
//		/// <param name="retTotalCnt">�����Ώۑ�����</param>
//		/// <param name="nextData">���f�[�^�L��</param>
//		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
//		/// <param name="readMode">�����敪</param>
//		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
//		/// <param name="readCnt">��������</param>		
//		/// <returns>STATUS</returns>
//		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST���w�茏�����S�Ė߂��܂��i�_���폜�����j</br>
//		/// <br>Programmer : 21015�@�����@�F��</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int SearchSpecificationUserGdBdU(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
//		{		
//			Debug.WriteLine("SearchSpecificationUserGdBdU");
//			return SearchUserGdBdUProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
//		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchUserGdBdUGuideDivCode(out object retobj,  object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
			retobj = null;
			return SearchUserGdBdUGuideDivCodeProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchUserGdBdUProc(out object retobj,out int retTotalCnt,out bool nextData,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			UserGdBdUWork usergdbduWork = new UserGdBdUWork();
			usergdbduWork = null;

			retobj = null;

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
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				usergdbduWork = paraobj as UserGdBdUWork;

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
				if ((readCnt > 0)&&(usergdbduWork.UserGuideDivCd == 0)&&(usergdbduWork.GuideCode == 0))
				{
					using(SqlCommand sqlCommandCount = new SqlCommand("",sqlConnection))
					{
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							sqlCommandCount.CommandText = "SELECT COUNT (*) FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
							//�_���폜�敪�ݒ�
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							sqlCommandCount.CommandText = "SELECT COUNT (*) FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
							//�_���폜�敪�ݒ�
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else 
						{
							sqlCommandCount.CommandText = "SELECT COUNT (*) FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
						}
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

						retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
					}
				}

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					//�f�[�^�Ǎ�
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						//�����w�薳���̏ꍇ
						if (readCnt == 0)
						{	
							sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						else
						{
							//�ꌏ�ڃ��[�h�̏ꍇ
							if ((readCnt > 0)&&(usergdbduWork.UserGuideDivCd == 0)&&(usergdbduWork.GuideCode == 0))
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
							}
								//Next���[�h�̏ꍇ
							else
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
							
								SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
								SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);
						
								paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
								paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
							}
						}
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						//�����w�薳���̏ꍇ
						if (readCnt == 0)
						{
							sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						else
						{
							//�ꌏ�ڃ��[�h�̏ꍇ
							if ((readCnt > 0)&&(usergdbduWork.UserGuideDivCd == 0)&&(usergdbduWork.GuideCode == 0))
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
							}
								//Next���[�h�̏ꍇ
							else
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

								SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
								SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);
						
								paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
								paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
							}
						}
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
						//�����w�薳���̏ꍇ
						if (readCnt == 0)
						{
							sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						else
						{
							//�ꌏ�ڃ��[�h�̏ꍇ
							if ((readCnt > 0)&&(usergdbduWork.UserGuideDivCd == 0)&&(usergdbduWork.GuideCode == 0))
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
							}
							else
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

								SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
								SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);
						
								paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
								paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
							}
						}
					}
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
							 
					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					int retCnt = 0;
					while(myReader.Read())
					{
						//�߂�l�J�E���^�J�E���g
						retCnt += 1;
						if (readCnt > 0)
						{
							//�߂�l�̌������擾�w�������𒴂����ꍇ�I��
							if (readCnt < retCnt) 
							{
								nextData = true;
								break;
							}
						}
						UserGdBdUWork wkUserGdBdUWork = new UserGdBdUWork();

						wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
						wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
						wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
						wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

						al.Add(wkUserGdBdUWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.SearchUserGdBdUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			retobj = al;

			return status;

		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchUserGdBdUGuideDivCodeProc(out object retobj,out int retTotalCnt,out bool nextData,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			UserGdBdUWork usergdbduWork = new UserGdBdUWork();
			usergdbduWork = null;

			retobj = null;

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
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				usergdbduWork = paraobj as UserGdBdUWork;

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					//�f�[�^�Ǎ�
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
						sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
					}
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

					SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					int retCnt = 0;
					while(myReader.Read())
					{
						//�߂�l�J�E���^�J�E���g
						retCnt += 1;
						if (readCnt > 0)
						{
							//�߂�l�̌������擾�w�������𒴂����ꍇ�I��
							if (readCnt < retCnt) 
							{
								nextData = true;
								break;
							}
						}
						UserGdBdUWork wkUserGdBdUWork = new UserGdBdUWork();

						wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
						wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
						wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
						wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

						al.Add(wkUserGdBdUWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.SearchUserGdBdUGuideDivCodeProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			retobj = al;

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobject">��������</param>
		/// <param name="paraobject">�����p�����[�^</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052 �R�c�@�\</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchUserGdBdUGuideDivCode(out object retobject,object paraobject, ConstantManagement.LogicalMode logicalMode)
		{		
			ArrayList userGdBdUWorkList = paraobject as ArrayList;
			return SearchUserGdBdUGuideDivCodeProc(out retobject,userGdBdUWorkList ,logicalMode);
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobject">��������</param>
		/// <param name="userGdBdUWorkList">�����p�����[�^</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052 �R�c�@�\</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchUserGdBdUGuideDivCodeProc(out object retobject,ArrayList userGdBdUWorkList, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retobject = null;

			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			UserGdBdUWork usergdbduWork = new UserGdBdUWork();
			usergdbduWork = null;

			ArrayList al = new ArrayList();
			try 
			{	
				if((userGdBdUWorkList != null)&&(userGdBdUWorkList.Count > 0))
				{
					string strsql = "";
					for(int iCnt=0; iCnt < userGdBdUWorkList.Count; iCnt++)
					{
						if(iCnt == 0)
						{
							strsql = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
						}
						else
						{
							strsql = strsql + " UNION SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
						}

						//�f�[�^�Ǎ�
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							strsql = strsql + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							strsql = strsql + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
						}
					}
		    		SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
	    			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
    				if (connectionText == null || connectionText == "") return status;


					//SQL������
					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();				

					usergdbduWork = userGdBdUWorkList[0] as UserGdBdUWork;

					using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
					{
						//�f�[�^�Ǎ�
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

							SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

							SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

						SqlParameter[] paraGuideDivCode = new SqlParameter[userGdBdUWorkList.Count];
						for(int iCnt=0; iCnt < userGdBdUWorkList.Count; iCnt++)
						{
							paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD" + iCnt.ToString(), SqlDbType.Int);
							paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((UserGdBdUWork)userGdBdUWorkList[iCnt]).UserGuideDivCd);
						}

						myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
						while(myReader.Read())
						{
							UserGdBdUWork wkUserGdBdUWork = new UserGdBdUWork();

							wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
							wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
							wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
							wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
							wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
							wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
							wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
							wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
							wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
							wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
							wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
							wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

							al.Add(wkUserGdBdUWork);

							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.SearchUserGdBdUGuideDivCodeProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			retobject = al;

			return status;

		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)��߂��܂�
		/// </summary>
		/// <param name="parabyte">UserGdBdUWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int ReadUserGdBdU(ref byte[] parabyte , int readMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			UserGdBdUWork usergdbduWork = new UserGdBdUWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection))
				{
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					if(myReader.Read())
					{
						usergdbduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						usergdbduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						usergdbduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						usergdbduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						usergdbduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						usergdbduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						usergdbduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						usergdbduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						usergdbduWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
						usergdbduWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
						usergdbduWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
						usergdbduWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.ReadUserGdBdU:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(usergdbduWork);

			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">UserGdBdUWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int WriteUserGdBdU(ref byte[] parabyte)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				UserGdBdUWork usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, USERGUIDEDIVCDRF, GUIDECODERF FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection))
				{
	
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != usergdbduWork.UpdateDateTime)
						{
							//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
							if (usergdbduWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
							else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							return status;
						}

						sqlCommand.CommandText = "UPDATE USERGDBDURF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , USERGUIDEDIVCDRF=@USERGUIDEDIVCD , GUIDECODERF=@GUIDECODE , GUIDENAMERF=@GUIDENAME , GUIDETYPERF=@GUIDETYPE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";
						//KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
						findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
						findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)usergdbduWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						if (usergdbduWork.UpdateDateTime > DateTime.MinValue)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							return status;
						}

						//�V�K�쐬����SQL���𐶐�
						sqlCommand.CommandText = "INSERT INTO USERGDBDURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, GUIDECODERF, GUIDENAMERF, GUIDETYPERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @USERGUIDEDIVCD, @GUIDECODE, @GUIDENAME, @GUIDETYPE)";
						//�o�^�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)usergdbduWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetInsertHeader(ref flhd,obj);
					}
					myReader.Close();

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
					SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
					SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
					SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@GUIDECODE", SqlDbType.Int);
					SqlParameter paraGuideName = sqlCommand.Parameters.Add("@GUIDENAME", SqlDbType.NVarChar);
					SqlParameter paraGuideType = sqlCommand.Parameters.Add("@GUIDETYPE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdbduWork.CreateDateTime);
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdbduWork.UpdateDateTime);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(usergdbduWork.FileHeaderGuid);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.LogicalDeleteCode);
					paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
					paraGuideName.Value = SqlDataMediator.SqlSetString(usergdbduWork.GuideName);
					paraGuideType.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideType);

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(usergdbduWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.WriteUserGdBdU:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			return status;

		}

		/// <summary>
		/// ���[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">UserGdBdUWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h����_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int LogicalDeleteUserGdBdU(ref byte[] parabyte)
		{
			return LogicalDeleteUserGdBdUProc(ref parabyte,0);
		}

		/// <summary>
		/// �_���폜���[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">�p�����[�^�[Work�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���[�U�[�K�C�h���𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int RevivalLogicalDeleteUserGdBdU(ref byte[] parabyte)
		{
			return LogicalDeleteUserGdBdUProc(ref parabyte,1);
		}

		/// <summary>
		/// ���[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">UserGdBdUWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h���̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int LogicalDeleteUserGdBdUProc(ref byte[] parabyte,int procMode)
		{
		//	Debug.WriteLine("LogicalDeleteUserGdBdU");

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try		
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				UserGdBdUWork usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, USERGUIDEDIVCDRF, GUIDECODERF FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection))
				{
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != usergdbduWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							return status;
						}
						//���݂̘_���폜�敪���擾
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

						sqlCommand.CommandText = "UPDATE USERGDBDURF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";
						//KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
						findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
						findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)usergdbduWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}
					myReader.Close();

					//�_���폜���[�h�̏ꍇ
					if (procMode == 0)
					{
						if		(logicalDelCd == 3)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
							return status;
						}
						else if	(logicalDelCd == 0)	usergdbduWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
						else						usergdbduWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
					}
					else
					{
						if		(logicalDelCd == 1)	usergdbduWork.LogicalDeleteCode = 0;//�_���폜�t���O������
						else
						{
							if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
							else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
							return status;
						}
					}

					//Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
					SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdbduWork.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(usergdbduWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.LogicalDeleteUserGdBdUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}
			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�{�f�B(���[�U�[�ύX��)���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���[�U�[�K�C�h�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h���𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int DeleteUserGdBdU(byte[] parabyte)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				UserGdBdUWork usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, USERGUIDEDIVCDRF, GUIDECODERF FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection))
				{
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
						if (_updateDateTime != usergdbduWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							return status;
						}

						sqlCommand.CommandText = "DELETE FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";
						//KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
						findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
						findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}
					myReader.Close();

					sqlCommand.ExecuteNonQuery();

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.DeleteUserGdBdU:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			return status;
		}
		#endregion

		#region �C���^�[�t�F�[�X�Ō��J���Ȃ����\�b�h
		/// <summary>
		/// ���[�U�[�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retList">��������</param>
		/// <param name="userGdBdUWorkList">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�R�l�N�V����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.12.28</br>
		public int Search(out ArrayList retList, UserGdBdUWork[] userGdBdUWorkList, int readMode,ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retList = null;

			SqlDataReader myReader = null;
			UserGdBdUWork usergdbduWork = null;

			ArrayList al = new ArrayList();
			try 
			{	
				if((userGdBdUWorkList != null)&&(userGdBdUWorkList.Length > 0))
				{
					string strsql = "";
					for(int iCnt=0; iCnt < userGdBdUWorkList.Length; iCnt++)
					{
						if(iCnt == 0)
						{
							strsql = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
						}
						else
						{
							strsql = strsql + " UNION SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
						}

						//�f�[�^�Ǎ�
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							strsql = strsql + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							strsql = strsql + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
						}
					}
					usergdbduWork = userGdBdUWorkList[0] as UserGdBdUWork;

					using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
					{
						//�f�[�^�Ǎ�
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

							SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

							SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

						SqlParameter[] paraGuideDivCode = new SqlParameter[userGdBdUWorkList.Length];
						for(int iCnt=0; iCnt < userGdBdUWorkList.Length; iCnt++)
						{
							paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD" + iCnt.ToString(), SqlDbType.Int);
							paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((UserGdBdUWork)userGdBdUWorkList[iCnt]).UserGuideDivCd);
						}

						UserGdBdUWork wkUserGdBdUWork = new UserGdBdUWork();
						myReader = sqlCommand.ExecuteReader();
						while(myReader.Read())
						{
							wkUserGdBdUWork = new UserGdBdUWork();
							wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
							wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
							wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
							wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
							wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
							wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
							wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
							wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
							wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
							wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
							wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
							wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

							al.Add(wkUserGdBdUWork);

							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
                base.WriteErrorLog(ex, "UserGdBdUDB.Search:" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
			}

			retList = al;

			return status;
		}

        /// <summary>
        /// ���[�U�[�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="userGdBdUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.12.28</br>
        public int Search(out ArrayList retList, UserGdBdUWork userGdBdUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retList = null;

            SqlDataReader myReader = null;
            ArrayList al = new ArrayList();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    //�f�[�^�Ǎ�
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
                    }
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(userGdBdUWork.EnterpriseCode);

                    UserGdBdUWork wkUserGdBdUWork = null;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        wkUserGdBdUWork = new UserGdBdUWork();
                        wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                        wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                        wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                        wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                        al.Add(wkUserGdBdUWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdUDB.Search:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
            }

            retList = al;

            return status;
        }
        #endregion


        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)�̎擾����
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">��������</param>
        /// <param name="readMode">���[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)�̎擾����</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        public int SearchHeader(out object retObj, object paraObj, int readMode,
            ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msgDiv = false;
            errMsg = string.Empty;
            UserGdHdUWork userGdHdUWork = null;

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //NSServiceJobAccess jobAcs = null;              //ADD 2009.06.11 panh FOR PVCS#228   //2009.07.22 kane DEL
            ArrayList al = new ArrayList();
            try
            {
                sqlConnection = CreateSqlConnection();

                sqlConnection.Open();
                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, USERGUIDEDIVNMRF, MASTEROFFERCDRF, DIVNAMECHNGDIVCDRF FROM USERGDHDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF ", sqlConnection);                                       //DEL 2009.06.11 panh FOR PVCS#228
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, USERGUIDEDIVNMRF, MASTEROFFERCDRF, DIVNAMECHNGDIVCDRF FROM USERGDHDURF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF ", sqlConnection);                  //ADD 2009.06.11 panh FOR PVCS#228
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter enterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter logicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                userGdHdUWork = (UserGdHdUWork)paraObj;
                enterpriseCode.Value = SqlDataMediator.SqlSetString(userGdHdUWork.EnterpriseCode);
                logicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                //2009.07.22 kane DEL START >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ////ADD START 2009.06.11 panh FOR PVCS#228
                //// �J�n���s���O��������
                //jobAcs = new NSServiceJobAccess("SFCMN09064R", "UserGdBdUDB.SearchHeader");
                //string paraStr = sqlCommand.CommandText.ToString();
                //jobAcs.StartWriteServiceJob(paraStr, sqlConnection);
                //2009.07.22 kane DEL END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                //�Q�ƌn�@�����������o�n�i60sec�j
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);
                //ADD END 2009.06.11 panh FOR PVCS#228

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (myReader.Read())
                {
                    UserGdHdUWork usergdhduWork = new UserGdHdUWork();
                    usergdhduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    usergdhduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    usergdhduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    usergdhduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    usergdhduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    usergdhduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    usergdhduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    usergdhduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    usergdhduWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    usergdhduWork.UserGuideDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USERGUIDEDIVNMRF"));
                    usergdhduWork.MasterOfferCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTEROFFERCDRF"));
                    usergdhduWork.DivNameChngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIVNAMECHNGDIVCDRF"));
                    al.Add(usergdhduWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            /* ---------------------- DEL START 2009.06.11 panh FOR PVCS#228----------------->>>>>
            //catch (Exception)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //    msgDiv = true;
            //    errMsg = "���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)�̓Ǎ��Ɏ��s���܂����B";
            //}
            ---------------------- DEL END   2009.06.11 panh FOR PVCS#228-----------------<<<<<*/

            //ADD START 2009.06.11 panh FOR PVCS#228
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "UserGdHdUDA.SearchHeader:", status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "�������Ƀ^�C���A�E�g���������܂����B\r\n���o�������i���čēx�������s���ĉ������B";
                }
            }
            catch (Exception e)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(e, "UserGdHdUDA.SearchHeader:", status);
            }
            //ADD END 2009.06.11 panh FOR PVCS#228
            finally
            {
                //if (!myReader.IsClosed) myReader.Close();    //DEL 2009.06.11 panh FOR PVCS#228
                if (myReader != null) myReader.Close();        //ADD 2009.06.11 panh FOR PVCS#228
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
                //2009.07.22 kane DEL START >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //ADD START 2009.06.11 panh FOR PVCS#228
                //if (jobAcs != null)
                //{
                //    jobAcs.EndWriteServiceJob(status, errMsg, "", sqlConnection);
                //}
                //ADD END 2009.06.11 panh FOR PVCS#228
                //2009.07.22 kane DEL END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            retObj = al;
            return status;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)�̍X�V����
        /// </summary>
        /// <param name="paraObj">�X�V�Ώ�</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)�̍X�V����</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        public int WriteHeader(ref object paraObj, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            msgDiv = false;
            errMsg = string.Empty;

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            //NSServiceJobAccess jobAcs = null;     //ADD 2009.06.11 panh FOR PVCS#228 // 2010/04/20 PM�Ή�
            
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;     //DEL 2009.06.11 panh FOR PVCS#228
                if (connectionText == null || connectionText == "")                      //ADD 2009.06.11 panh FOR PVCS#228
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;                 //ADD 2009.06.11 panh FOR PVCS#228

                // XML�̓ǂݍ���
                UserGdHdUWork usergdhduWork = (UserGdHdUWork)XmlByteSerializer.Deserialize((byte[])paraObj, typeof(UserGdHdUWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, USERGUIDEDIVNMRF FROM USERGDHDURF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD", sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter enterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter logicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    enterpriseCode.Value = SqlDataMediator.SqlSetString(usergdhduWork.EnterpriseCode);
                    logicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.LogicalDeleteCode);
                    findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.UserGuideDivCd);

                    //>>>2010/04/20 PM�Ή�
                    ////ADD START 2009.06.11 panh FOR PVCS#228
                    //// �J�n���s���O��������
                    //jobAcs = new NSServiceJobAccess("SFCMN09064R", "UserGdBdUDB.WriteHeader");
                    //string paraStr = sqlCommand.CommandText.ToString();
                    //jobAcs.StartWriteServiceJob(paraStr, sqlConnection);
                    ////�Q�ƌn�@�����������o�n�i60sec�j
                    //sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);
                    ////ADD END 2009.06.11 panh FOR PVCS#228
                    //<<<2010/04/20 PM�Ή�

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                        if (_updateDateTime != usergdhduWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (usergdhduWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        sqlCommand.CommandText = "UPDATE USERGDHDURF SET CREATEDATETIMERF=@CREATEDATETIME, UPDATEDATETIMERF=@UPDATEDATETIME, ENTERPRISECODERF=@ENTERPRISECODE, FILEHEADERGUIDRF=@FILEHEADERGUID, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, UPDASSEMBLYID1RF=@UPDASSEMBLYID1, UPDASSEMBLYID2RF=@UPDASSEMBLYID2, LOGICALDELETECODERF=@LOGICALDELETECODE, USERGUIDEDIVCDRF=@USERGUIDEDIVCD, USERGUIDEDIVNMRF=@USERGUIDEDIVNM, MASTEROFFERCDRF=@MASTEROFFERCD, DIVNAMECHNGDIVCDRF=@DIVNAMECHNGDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND USERGUIDEDIVCDRF=@USERGUIDEDIVCD";
                        //KEY�R�}���h���Đݒ�
                        findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.UserGuideDivCd);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)usergdhduWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = "INSERT INTO USERGDHDURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, USERGUIDEDIVNMRF, MASTEROFFERCDRF, DIVNAMECHNGDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @USERGUIDEDIVCD, @USERGUIDEDIVNM, @MASTEROFFERCD, @DIVNAMECHNGDIVCD)";
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)usergdhduWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    myReader.Close();

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
                    SqlParameter paraUserGuideDivNm = sqlCommand.Parameters.Add("@USERGUIDEDIVNM", SqlDbType.NVarChar);
                    SqlParameter paraMasterOfferCd = sqlCommand.Parameters.Add("@MASTEROFFERCD", SqlDbType.Int);
                    SqlParameter paraDivNameChngDivCd = sqlCommand.Parameters.Add("@DIVNAMECHNGDIVCD", SqlDbType.Int);

                     
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdhduWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdhduWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdhduWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(usergdhduWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(usergdhduWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(usergdhduWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(usergdhduWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.LogicalDeleteCode);
                    paraUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.UserGuideDivCd);
                    paraUserGuideDivNm.Value = SqlDataMediator.SqlSetString(usergdhduWork.UserGuideDivNm);
                    paraMasterOfferCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.MasterOfferCd);
                    paraDivNameChngDivCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.DivNameChngDivCd);

                    //>>>2010/04/20 PM�Ή�
                    ////ADD START 2009.06.11 panh FOR PVCS#228
                    //// �J�n���s���O��������
                    //jobAcs = new NSServiceJobAccess("SFCMN09064R", "UserGdBdUDB.WriteHeader");
                    //paraStr = sqlCommand.CommandText.ToString();
                    //jobAcs.StartWriteServiceJob(paraStr, sqlConnection);
                    ////ADD END 2009.06.11 panh FOR PVCS#228
                    //<<<2010/04/20 PM�Ή�

                    sqlCommand.ExecuteNonQuery();

                    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                    paraObj = XmlByteSerializer.Serialize(usergdhduWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                /* ---------------------- DEL START 2009.06.11 panh FOR PVCS#228----------------->>>>>
                //status = base.WriteSQLErrorLog(ex);
                //msgDiv = true;
                //errMsg = "���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)�̍X�V�Ɏ��s���܂����B";
                ---------------------- DEL END   2009.06.11 panh FOR PVCS#228-----------------<<<<<*/
                //ADD START 2009.06.11 panh FOR PVCS#228
                status = base.WriteSQLErrorLog(ex, "UserGdHdUDA.WriteHeader:", status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "�������Ƀ^�C���A�E�g���������܂����B\r\n���o�������i���čēx�������s���ĉ������B";
                }
                //ADD END 2009.06.11 panh FOR PVCS#228
            }
            catch (Exception ex)
            {
               /* ---------------------- DEL START 2009.06.11 panh FOR PVCS#228----------------->>>>>
               //base.WriteErrorLog(ex, "UserGdHdUDB.WriteHeader:" + ex.Message);
               //status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
               //msgDiv = true;
               //errMsg = "���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)�̍X�V�Ɏ��s���܂����B";
                ---------------------- DEL END   2009.06.11 panh FOR PVCS#228-----------------<<<<<*/
                //ADD START 2009.06.11 panh FOR PVCS#228
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "UserGdHdUDA.WriteHeader:" + ex.Message);
                //ADD END 2009.06.11 panh FOR PVCS#228
            }
            finally
            {
                /* ---------------------- DEL START 2009.06.11 panh FOR PVCS#228----------------->>>>>
                //if (!myReader.IsClosed) myReader.Close();
                //if (sqlConnection != null)
                //{
                //    sqlConnection.Dispose();
                //    sqlConnection.Close();
                //}
                ---------------------- DEL END   2009.06.11 panh FOR PVCS#228-----------------<<<<<*/

                //>>>2010/04/20 PM�Ή�
                ////ADD START 2009.06.11 panh FOR PVCS#228
                //if (myReader != null && !myReader.IsClosed)
                //{
                //    myReader.Close();
                //    myReader.Dispose();
                //}
                //if (sqlConnection != null)
                //{
                //    if (jobAcs != null)
                //    {
                //        jobAcs.EndWriteServiceJob(status, errMsg, "", sqlConnection);
                //    }
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();
                //}
                ////ADD END 2009.06.11 panh FOR PVCS#228

                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                    myReader.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
                //<<<2010/04/20 PM�Ή�
            }
            return status;
        }


        #region[CreateSqlConnection]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection�𐶐�����</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            // --- MODIFY START 2009.06.08 xueqi FOR PVCS-288 --->>>>
            //if (string.IsNullOrEmpty(connectionText)) return null;
            if (connectionText == null || connectionText == "")
                return null;
            // --- MODIFY END 2009.06.08 xueqi FOR PVCS-288 ---<<<<
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion
	}
}
