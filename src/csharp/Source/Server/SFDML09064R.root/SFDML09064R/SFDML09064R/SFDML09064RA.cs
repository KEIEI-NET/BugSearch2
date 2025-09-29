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


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���[�����M�Ǘ��ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�����M�Ǘ��ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class MailSndMngDB : RemoteDB , IMailSndMngDB
	{

		/// <summary>
		/// ���[�����M�Ǘ��ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public MailSndMngDB() :
		base("SFDML09066D", "Broadleaf.Application.Remoting.ParamData.MailSndMngWork", "MAILSNDMNGRF")
		{
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ��ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:MailSndMngWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ��ݒ�LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status =  SearchCntMailSndMngProc(out retCnt, parabyte, readMode,logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ��ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:MailSndMngWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ��ݒ�LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchCntMailSndMngProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			MailSndMngWork mailsndmngWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();

            try
            {
			try 
			{	
				// XML�̓ǂݍ���
				mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

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

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);

				//�f�[�^���[�h
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			sqlConnection.Close();			


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.SearchCntMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
//			return SearchMailSndMngProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status =  SearchMailSndMngProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
//			return SearchMailSndMngProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retbyte = null;
            try
            {
                status =  SearchMailSndMngProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchMailSndMngProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			MailSndMngWork mailsndmngWork = new MailSndMngWork();
			mailsndmngWork = null;

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
			try 
			{	
				// XML�̓ǂݍ���
				mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

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

				//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
				if ((readCnt > 0)&&(mailsndmngWork.MailSendMngNo == 0))
				{
					SqlCommand sqlCommandCount;
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//�����w�薳���̏ꍇ
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if ((mailsndmngWork.MailSendMngNo == 0))
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
						}
							//Next���[�h�̏ꍇ
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF",sqlConnection);
							SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
						}
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					//�����w�薳���̏ꍇ
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if ((mailsndmngWork.MailSendMngNo == 0))
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
						}
							//Next���[�h�̏ꍇ
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF",sqlConnection);
							SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
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
						sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if ((mailsndmngWork.MailSendMngNo == 0))
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY MAILSENDMNGNORF",sqlConnection);
						}
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF",sqlConnection);
							SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);

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

					al.Add(CopyToMailSndMngWorkFromReader(ref myReader));

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			MailSndMngWork[] MailSndMngWorks = (MailSndMngWork[])al.ToArray(typeof(MailSndMngWork));
			retbyte = XmlByteSerializer.Serialize(MailSndMngWorks);


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.SearchMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ��ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ��ݒ��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			MailSndMngWork mailsndmngWork = new MailSndMngWork();

            try
            {
			try 
			{			
				// XML�̓ǂݍ���
				mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

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
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO", sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
                    mailsndmngWork = CopyToMailSndMngWorkFromReader(ref myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(mailsndmngWork);


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.Read Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// ���[�����M�Ǘ��ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�����M�Ǘ��ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try 
			{
				// XML�̓ǂݍ���
				MailSndMngWork mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

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
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, MAILSENDMNGNORF FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO", sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != mailsndmngWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (mailsndmngWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    sqlCommand.CommandText = "UPDATE MAILSNDMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , MAILSENDMNGNORF=@MAILSENDMNGNO , MAILADDRESSRF=@MAILADDRESS , DIALUPCODERF=@DIALUPCODE , DIALUPCONNECTNAMERF=@DIALUPCONNECTNAME , DIALUPLOGINNAMERF=@DIALUPLOGINNAME , DIALUPPASSWORDRF=@DIALUPPASSWORD , ACCESSTELNORF=@ACCESSTELNO , POP3USERIDRF=@POP3USERID , POP3PASSWORDRF=@POP3PASSWORD , POP3SERVERNAMERF=@POP3SERVERNAME , SMTPSERVERNAMERF=@SMTPSERVERNAME , SMTPUSERIDRF=@SMTPUSERID , SMTPPASSWORDRF=@SMTPPASSWORD , SMTPAUTHUSEDIVRF=@SMTPAUTHUSEDIV , SENDERNAMERF=@SENDERNAME , POPBEFORESMTPUSEDIVRF=@POPBEFORESMTPUSEDIV , POPSERVERPORTNORF=@POPSERVERPORTNO , SMTPSERVERPORTNORF=@SMTPSERVERPORTNO , MAILSERVERTIMEOUTVALRF=@MAILSERVERTIMEOUTVAL , BACKUPSENDDIVCDRF=@BACKUPSENDDIVCD , BACKUPFORMALRF=@BACKUPFORMAL , MAILSENDDIVUNITCNTRF=@MAILSENDDIVUNITCNT WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO";
					//KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                    findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)mailsndmngWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (mailsndmngWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = "INSERT INTO MAILSNDMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, MAILSENDMNGNORF, MAILADDRESSRF, DIALUPCODERF, DIALUPCONNECTNAMERF, DIALUPLOGINNAMERF, DIALUPPASSWORDRF, ACCESSTELNORF, POP3USERIDRF, POP3PASSWORDRF, POP3SERVERNAMERF, SMTPSERVERNAMERF, SMTPUSERIDRF, SMTPPASSWORDRF, SMTPAUTHUSEDIVRF, SENDERNAMERF, POPBEFORESMTPUSEDIVRF, POPSERVERPORTNORF, SMTPSERVERPORTNORF, MAILSERVERTIMEOUTVALRF, BACKUPSENDDIVCDRF, BACKUPFORMALRF, MAILSENDDIVUNITCNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @MAILSENDMNGNO, @MAILADDRESS, @DIALUPCODE, @DIALUPCONNECTNAME, @DIALUPLOGINNAME, @DIALUPPASSWORD, @ACCESSTELNO, @POP3USERID, @POP3PASSWORD, @POP3SERVERNAME, @SMTPSERVERNAME, @SMTPUSERID, @SMTPPASSWORD, @SMTPAUTHUSEDIV, @SENDERNAME, @POPBEFORESMTPUSEDIV, @POPSERVERPORTNO, @SMTPSERVERPORTNO, @MAILSERVERTIMEOUTVAL, @BACKUPSENDDIVCD, @BACKUPFORMAL, @MAILSENDDIVUNITCNT)";
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)mailsndmngWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(myReader.IsClosed == false)myReader.Close();

                #region �l�Z�b�g
                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@MAILSENDMNGNO", SqlDbType.Int);
                SqlParameter paraMailAddress = sqlCommand.Parameters.Add("@MAILADDRESS", SqlDbType.NVarChar);
                SqlParameter paraDialUpCode = sqlCommand.Parameters.Add("@DIALUPCODE", SqlDbType.Int);
                SqlParameter paraDialUpConnectName = sqlCommand.Parameters.Add("@DIALUPCONNECTNAME", SqlDbType.NVarChar);
                SqlParameter paraDialUpLoginName = sqlCommand.Parameters.Add("@DIALUPLOGINNAME", SqlDbType.NVarChar);
                SqlParameter paraDialUpPassword = sqlCommand.Parameters.Add("@DIALUPPASSWORD", SqlDbType.NVarChar);
                SqlParameter paraAccessTelNo = sqlCommand.Parameters.Add("@ACCESSTELNO", SqlDbType.NChar);
                SqlParameter paraPop3UserId = sqlCommand.Parameters.Add("@POP3USERID", SqlDbType.NVarChar);
                SqlParameter paraPop3Password = sqlCommand.Parameters.Add("@POP3PASSWORD", SqlDbType.NVarChar);
                SqlParameter paraPop3ServerName = sqlCommand.Parameters.Add("@POP3SERVERNAME", SqlDbType.NVarChar);
                SqlParameter paraSmtpServerName = sqlCommand.Parameters.Add("@SMTPSERVERNAME", SqlDbType.NVarChar);
                SqlParameter paraSmtpUserId = sqlCommand.Parameters.Add("@SMTPUSERID", SqlDbType.NVarChar);
                SqlParameter paraSmtpPassword = sqlCommand.Parameters.Add("@SMTPPASSWORD", SqlDbType.NVarChar);
                SqlParameter paraSmtpAuthUseDiv = sqlCommand.Parameters.Add("@SMTPAUTHUSEDIV", SqlDbType.Int);
                SqlParameter paraSenderName = sqlCommand.Parameters.Add("@SENDERNAME", SqlDbType.NVarChar);
                SqlParameter paraPopBeforeSmtpUseDiv = sqlCommand.Parameters.Add("@POPBEFORESMTPUSEDIV", SqlDbType.Int);
                SqlParameter paraPopServerPortNo = sqlCommand.Parameters.Add("@POPSERVERPORTNO", SqlDbType.Int);
                SqlParameter paraSmtpServerPortNo = sqlCommand.Parameters.Add("@SMTPSERVERPORTNO", SqlDbType.Int);
                SqlParameter paraMailServerTimeoutVal = sqlCommand.Parameters.Add("@MAILSERVERTIMEOUTVAL", SqlDbType.Int);
                SqlParameter paraBackupSendDivCd = sqlCommand.Parameters.Add("@BACKUPSENDDIVCD", SqlDbType.Int);
                SqlParameter paraBackupFormal = sqlCommand.Parameters.Add("@BACKUPFORMAL", SqlDbType.Int);
                SqlParameter paraMailSendDivUnitCnt = sqlCommand.Parameters.Add("@MAILSENDDIVUNITCNT", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailsndmngWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailsndmngWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(mailsndmngWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
                paraMailAddress.Value = SqlDataMediator.SqlSetString(mailsndmngWork.MailAddress);
                paraDialUpCode.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.DialUpCode);
                paraDialUpConnectName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.DialUpConnectName);
                paraDialUpLoginName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.DialUpLoginName);
                paraDialUpPassword.Value = SqlDataMediator.SqlSetString(mailsndmngWork.DialUpPassword);
                paraAccessTelNo.Value = SqlDataMediator.SqlSetString(mailsndmngWork.AccessTelNo);
                paraPop3UserId.Value = SqlDataMediator.SqlSetString(mailsndmngWork.Pop3UserId);
                paraPop3Password.Value = SqlDataMediator.SqlSetString(mailsndmngWork.Pop3Password);
                paraPop3ServerName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.Pop3ServerName);
                paraSmtpServerName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SmtpServerName);
                paraSmtpUserId.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SmtpUserId);
                paraSmtpPassword.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SmtpPassword);
                paraSmtpAuthUseDiv.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.SmtpAuthUseDiv);
                paraSenderName.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SenderName);
                paraPopBeforeSmtpUseDiv.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.PopBeforeSmtpUseDiv);
                paraPopServerPortNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.PopServerPortNo);
                paraSmtpServerPortNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.SmtpServerPortNo);
                paraMailServerTimeoutVal.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailServerTimeoutVal);
                paraBackupSendDivCd.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.BackupSendDivCd);
                paraBackupFormal.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.BackupFormal);
                paraMailSendDivUnitCnt.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendDivUnitCnt);
                #endregion

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(mailsndmngWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.Write Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// ���[�����M�Ǘ���_���폜���܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�����M�Ǘ���_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteMailSndMngProc(ref parabyte,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteMailSndMngProc(ref parabyte,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.LogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �_���폜���[�����M�Ǘ��𕜊����܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���[�����M�Ǘ��𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteMailSndMngProc(ref parabyte,1);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteMailSndMngProc(ref parabyte,1);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.RevivalLogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// ���[�����M�Ǘ��̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�����M�Ǘ��̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int LogicalDeleteMailSndMngProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try		
			{
				// XML�̓ǂݍ���
				MailSndMngWork mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, MAILSENDMNGNORF FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO", sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != mailsndmngWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE MAILSNDMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO";
					//KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                    findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)mailsndmngWork;
                    FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					if(myReader.IsClosed == false)myReader.Close();
					sqlConnection.Close();
					return status;
				}
				sqlCommand.Cancel();
				if(myReader.IsClosed == false)myReader.Close();

				//�_���폜���[�h�̏ꍇ
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	mailsndmngWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						mailsndmngWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	mailsndmngWork.LogicalDeleteCode = 0;//�_���폜�t���O������
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailsndmngWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mailsndmngWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(mailsndmngWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.LogicalDeleteMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// ���[�����M�Ǘ��𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���[�����M�Ǘ��I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : ���[�����M�Ǘ��𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try 
			{
				// XML�̓ǂݍ���
				MailSndMngWork mailsndmngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(MailSndMngWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, MAILSENDMNGNORF FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO", sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != mailsndmngWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM MAILSNDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAILSENDMNGNORF=@FINDMAILSENDMNGNO";
					//KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.SectionCode);
                    findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailsndmngWork.MailSendMngNo);
                }
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					if(myReader.IsClosed == false)myReader.Close();
					sqlConnection.Close();
					return status;
				}
				if(myReader.IsClosed == false)myReader.Close();

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailSndMngDB.Delete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
        }

        #region CustomMethod
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="mailSndMngWork">��������</param>
        /// <param name="paramailSndMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.06.17</br>
        public int Search(out object mailSndMngWork, object paramailSndMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            mailSndMngWork = null;
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                return SearchMailSndMngProc(out mailSndMngWork, paramailSndMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MailSndMngDB.Search");
                mailSndMngWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST��S�Ė߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="objmailSndMngWork">��������</param>
        /// <param name="paramailSndMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����M�Ǘ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.06.17</br>
        private int SearchMailSndMngProc(out object objmailSndMngWork, object paramailSndMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            MailSndMngWork mailsndmngWork = new MailSndMngWork();
            mailsndmngWork = null;

            objmailSndMngWork = null;

            ArrayList al = new ArrayList();
            try
            {
                ArrayList mailsndmngWorkList = paramailSndMngWork as ArrayList;
                if (mailsndmngWorkList == null)
                {
                    mailsndmngWork = paramailSndMngWork as MailSndMngWork;
                }
                else
                {
                    if (mailsndmngWorkList.Count > 0)
                        mailsndmngWork = mailsndmngWorkList[0] as MailSndMngWork;
                }

                sqlCommand = new SqlCommand("SELECT * FROM MAILSNDMNGRF WHERE ", sqlConnection);

                //��ƃR�[�h
                sqlCommand.CommandText += "ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);
                
                //�_���폜�敪
                string wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (wkstring != "")
                {
                    sqlCommand.CommandText += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToMailSndMngWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            objmailSndMngWork = al;

            return status;
        }

        #endregion

        #region CopyToClassFromReader

        /// <summary>
        /// ���[�����M�Ǘ��N���X�i�[���� Reader �� MailSndMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>MailSndMngWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.10.17</br>
        /// </remarks>
        private MailSndMngWork CopyToMailSndMngWorkFromReader(ref SqlDataReader myReader)
        {
            MailSndMngWork wkMailSndMngWork = new MailSndMngWork();

            #region �N���X�֊i�[
            wkMailSndMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkMailSndMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkMailSndMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkMailSndMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkMailSndMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkMailSndMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkMailSndMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkMailSndMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkMailSndMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkMailSndMngWork.MailSendMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDMNGNORF"));
            wkMailSndMngWork.MailAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESSRF"));
            wkMailSndMngWork.DialUpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIALUPCODERF"));
            wkMailSndMngWork.DialUpConnectName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPCONNECTNAMERF"));
            wkMailSndMngWork.DialUpLoginName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPLOGINNAMERF"));
            wkMailSndMngWork.DialUpPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPPASSWORDRF"));
            wkMailSndMngWork.AccessTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCESSTELNORF"));
            wkMailSndMngWork.Pop3UserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3USERIDRF"));
            wkMailSndMngWork.Pop3Password = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3PASSWORDRF"));
            wkMailSndMngWork.Pop3ServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3SERVERNAMERF"));
            wkMailSndMngWork.SmtpServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPSERVERNAMERF"));
            wkMailSndMngWork.SmtpUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPUSERIDRF"));
            wkMailSndMngWork.SmtpPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPPASSWORDRF"));
            wkMailSndMngWork.SmtpAuthUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SMTPAUTHUSEDIVRF"));
            wkMailSndMngWork.SenderName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDERNAMERF"));
            wkMailSndMngWork.PopBeforeSmtpUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POPBEFORESMTPUSEDIVRF"));
            wkMailSndMngWork.PopServerPortNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POPSERVERPORTNORF"));
            wkMailSndMngWork.SmtpServerPortNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SMTPSERVERPORTNORF"));
            wkMailSndMngWork.MailServerTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSERVERTIMEOUTVALRF"));
            wkMailSndMngWork.BackupSendDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BACKUPSENDDIVCDRF"));
            wkMailSndMngWork.BackupFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BACKUPFORMALRF"));
            wkMailSndMngWork.MailSendDivUnitCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDDIVUNITCNTRF"));
            #endregion

            return wkMailSndMngWork;
        }

        #endregion
    }

}

