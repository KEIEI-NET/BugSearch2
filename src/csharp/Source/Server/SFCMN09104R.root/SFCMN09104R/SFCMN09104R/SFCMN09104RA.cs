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
	/// �ԍ��Ǘ��ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �ԍ��Ǘ��ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 95016�@���c���@���F</br>
	/// <br>Date       : 2005.04.27</br>
	/// <br></br>
    /// <br>Update Note: 2008.05.28 20081 �D�c �E�l</br>
    /// <br>           : PM.NS�p�ɕύX</br>
	/// </remarks>
	[Serializable]
	public class NoMngSetDB : RemoteDB, IRemoteDB, INoMngSetDB // MarshalByRefObject , INoMngSetDB
	{
//		private string _connectionText;		//�R�l�N�V����������i�[�p

		/// <summary>
		/// �ԍ��̔ԃ^�C�v�������̔Ԃ���̏ꍇ�̃R�[�h
		/// </summary>
		private const string NUMBERINGDIVCD_ARI = "1";
		/// <summary>
		/// ��ƒʔԂ̏ꍇ�̋��_�R�[�h
		/// </summary>
		private const string DEFAULT_SECTIONCODE = "000000";
		/// <summary>
		/// �ԍ��̔Ԕ͈͂���ƒʔԂ̏ꍇ�̃R�[�h
		/// </summary>
		private const int	 ENTERPRISE_SEQUENCE_NUMBER = 0; 

		/// <summary>
		/// �ԍ��Ǘ��ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 95016�@���c���@���F</br>
		/// <br>Date       : 2005.04.27</br>
		/// </remarks>
		public NoMngSetDB() :
			base("SFCMN09106D", "Broadleaf.Application.Remoting.ParamData.NoMngSetWork", "STKMONEYNMRF")
		{
//			_connectionText = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
		}

		#region �ԍ��Ǘ��ݒ�

		#region ���ݎg�p���Ă��Ȃ����\�b�h 
		/*
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:NoMngSetWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		public int SearchCntNoMngSet(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntNoMngSetProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:NoMngSetWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		private int SearchCntNoMngSetProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			NoMngSetWork NoMngSetWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				// XML�̓ǂݍ���
				NoMngSetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork));

				//SQL������
				sqlConnection = new SqlConnection(_connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.EnterpriseCode);

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

			return status;
		}
		*/


		//		/// <summary>
		//		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		//		/// </summary>
		//		/// <param name="retbyte">��������</param>
		//		/// <param name="parabyte">�����p�����[�^</param>
		//		/// <param name="readMode">�����敪</param>
		//		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		//		/// <returns>STATUS</returns>
		//		public int SearchNoMngSet(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		//		{
		//			bool nextData;
		//			int retTotalCnt;
		//			ArrayList retList = null;
		//
		//			NoMngSetWork nomngsetWork = null;
		//
		//			// XML�̓ǂݍ���
		//			nomngsetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork));
		//
		//			int status = SearchNoMngSetProc(out retList,out retTotalCnt,out nextData,nomngsetWork ,readMode,logicalMode,0);
		//
		//			// XML�֕ϊ����A������̃o�C�i����
		//			NoMngSetWork[] NoMngSetWorks = (NoMngSetWork[])retList.ToArray(typeof(NoMngSetWork));
		//			retbyte = XmlByteSerializer.Serialize(NoMngSetWorks);
		//
		//			return status;
		//		}

		//		/// <summary>
		//		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		//		/// </summary>
		//		/// <param name="retbyte">��������</param>
		//		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		//		/// <param name="nextData">���f�[�^�L��</param>
		//		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		//		/// <param name="readMode">�����敪</param>
		//		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		//		/// <param name="readCnt">��������</param>		
		//		/// <returns>STATUS</returns>
		//		public int SearchSpecificationNoMngSet(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		//		{
		//			return SearchNoMngSetProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
		//		}
		
		//		/// <summary>
		//		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST��S�Ė߂��܂�
		//		/// </summary>
		//		/// <param name="retList">��������</param>
		//		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		//		/// <param name="nextData">���f�[�^�L��</param>
		//		/// <param name="parabyte">�����p�����[�^</param>
		//		/// <param name="readMode">�����敪(0:�S���擾�A1:�����̔ԗL��̍��ڂ̂ݎ擾)</param>
		//		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		//		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		//		/// <returns>STATUS</returns>
		//		private int SearchNoMngSetProc(out ArrayList retList ,out int retTotalCnt,out bool nextData,NoMngSetWork nomngsetWork, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		//		{
		//			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//			SqlConnection sqlConnection = null;
		//			SqlDataReader myReader = null;
		//
		//
		//			retbyte = null;
		//
		//			//��������0�ŏ�����
		//			retTotalCnt = 0;
		//
		//			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
		//			int _readCnt = readCnt;			
		//			if (_readCnt > 0) _readCnt += 1;
		//			//�����R�[�h�����ŏ�����
		//			nextData = false;
		//
		//			ArrayList al = new ArrayList();
		//			if(readMode == 0)
		//			{
		//				#region �S���擾�̃T�[�`
		//				try 
		//				{	
		//					// XML�̓ǂݍ���
		//					nomngsetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork));
		//
		//					//SQL������
		//					sqlConnection = new SqlConnection(_connectionText);
		//					sqlConnection.Open();				
		//
		//					//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
		//
		//					if ((readCnt > 0)&&(nomngsetWork.SectionCode == "")&&(nomngsetWork.NoCode == 0))
		//					{
		//						SqlCommand sqlCommandCount;
		//						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
		//							(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
		//						{
		//							sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
		//							//�_���폜�敪�ݒ�
		//							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		//						}
		//						else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
		//						{
		//							sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
		//							//�_���폜�敪�ݒ�
		//							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//							if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
		//							else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
		//						}
		//						else 
		//						{
		//							sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
		//						}
		//						SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//						paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
		//
		//						retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
		//					}
		//
		//					SqlCommand sqlCommand;
		//
		//					//�f�[�^�Ǎ�
		//					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
		//						(logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
		//					{
		//						//�����w�薳���̏ꍇ
		//						if (readCnt == 0)
		//						{
		//							sqlCommand = new SqlCommand("SELECT * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF, NOCODERF", sqlConnection);
		//						}
		//						else
		//						{
		//							//�ꌏ�ڃ��[�h�̏ꍇ
		//							if ((nomngsetWork.SectionCode == "")&&(nomngsetWork.NoCode == 0))
		//							{
		//								sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF, NOCODERF", sqlConnection);
		//							}
		//								//Next���[�h�̏ꍇ
		//							else
		//							{
		//								sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF>@FINDSECTIONCODE AND NOCODERF>@FINDNOCODE ORDER BY SECTIONCODERF, NOCODERF", sqlConnection);
		//
		//								SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
		//								SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);
		//								findParaSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
		//								findParaNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);
		//							}
		//						}
		//						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		//					}
		//					else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
		//					{
		//						//�����w�薳���̏ꍇ
		//						if (readCnt == 0)
		//						{
		//							sqlCommand = new SqlCommand("SELECT * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF, NOCODERF", sqlConnection);
		//						}
		//						else
		//						{
		//							//�ꌏ�ڃ��[�h�̏ꍇ
		//							if ((nomngsetWork.SectionCode == "")&&(nomngsetWork.NoCode == 0))
		//							{
		//								sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECTIONCODERF, NOCODERF", sqlConnection);
		//							}
		//								//Next���[�h�̏ꍇ
		//							else
		//							{
		//								sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF>@FINDNOCODE ORDER BY SECTIONCODERF, NOCODERF", sqlConnection);
		//
		//								SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
		//								SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);
		//								findParaSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
		//								findParaNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);
		//							}
		//						}
		//						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
		//						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
		//					}
		//					else
		//					{
		//						//�����w�薳���̏ꍇ
		//						if (readCnt == 0)
		//						{
		//							sqlCommand = new SqlCommand("SELECT * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY  SECTIONCODERF, NOCODERF", sqlConnection);
		//						}
		//						else
		//						{
		//							//�ꌏ�ڃ��[�h�̏ꍇ
		//							if ((nomngsetWork.SectionCode == "")&&(nomngsetWork.NoCode == 0))
		//							{
		//								sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY SECTIONCODERF, NOCODERF", sqlConnection);
		//							}
		//							else
		//							{
		//								sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF>@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE ORDER BY SECTIONCODERF, NOCODERF", sqlConnection);
		//
		//								SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
		//								SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);
		//								findParaSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
		//								findParaNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);
		//							}
		//						}
		//					}
		//					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
		//
		//					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
		//					int retCnt = 0;
		//					while(myReader.Read())
		//					{
		//						//�߂�l�J�E���^�J�E���g
		//						retCnt += 1;
		//						if (readCnt > 0)
		//						{
		//							//�߂�l�̌������擾�w�������𒴂����ꍇ�I��
		//							if (readCnt < retCnt) 
		//							{
		//								nextData = true;
		//								break;
		//							}
		//						}
		//						NoMngSetWork wkNoMngSetWork = new NoMngSetWork();
		//
		//						wkNoMngSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
		//						wkNoMngSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
		//						wkNoMngSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
		//						wkNoMngSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
		//						wkNoMngSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
		//						wkNoMngSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
		//						wkNoMngSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
		//						wkNoMngSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
		//						wkNoMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
		//						wkNoMngSetWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCODERF"));
		//						wkNoMngSetWork.NoPresentVal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("NOPRESENTVALRF"));
		//						wkNoMngSetWork.SettingStartNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SETTINGSTARTNORF"));
		//						wkNoMngSetWork.SettingEndNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SETTINGENDNORF"));
		//						wkNoMngSetWork.NoIncDecWidth = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOINCDECWIDTHRF"));
		//
		//						al.Add(wkNoMngSetWork);
		//
		//						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//					}
		//				}
		//				catch (SqlException ex) 
		//				{
		//					//���N���X�ɗ�O��n���ď������Ă��炤
		//					status = base.WriteSQLErrorLog(ex);
		//				}
		//				#endregion
		//			}
		//			else
		//			{
		//				//ReadMode��1�̏ꍇ�A�����̔ԗL��̃��R�[�h�̂ݒ��o
		//				try 
		//				{	
		//					notypemngWork = paraobj as NoTypeMngWork;
		//
		//					//SQL������
		//					sqlConnection = new SqlConnection(_connectionText);
		//					sqlConnection.Open();				
		//
		//					SqlCommand sqlCommand;
		//
		//					//�f�[�^�Ǎ�
		//					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
		//						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
		//						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
		//						(logicalMode == ConstantManagement.LogicalMode.GetData3))
		//					{
		//						sqlCommand = new SqlCommand("SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY NOCODERF ",sqlConnection);
		//						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		//					}
		//					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
		//						(logicalMode == ConstantManagement.LogicalMode.GetData012))
		//					{
		//						sqlCommand = new SqlCommand("SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY NOCODERF ",sqlConnection);
		//						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
		//						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
		//					}
		//					else
		//					{
		//						sqlCommand = new SqlCommand("SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY NOCODERF ",sqlConnection);
		//					}
		//					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
		//
		//					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
		//					while(myReader.Read())
		//					{
		//						NoTypeMngWork wkNoTypeMngWork = new NoTypeMngWork();
		//
		//						wkNoTypeMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
		//						wkNoTypeMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
		//						wkNoTypeMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
		//						wkNoTypeMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
		//						wkNoTypeMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
		//						wkNoTypeMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
		//						wkNoTypeMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
		//						wkNoTypeMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
		//						wkNoTypeMngWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCODERF"));
		//						wkNoTypeMngWork.NoName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NONAMERF"));
		//						wkNoTypeMngWork.NoItemPatternCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOITEMPATTERNCDRF"));
		//						wkNoTypeMngWork.NoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCHARCTERCOUNTRF"));
		//						wkNoTypeMngWork.ConsNoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSNOCHARCTERCOUNTRF"));
		//						wkNoTypeMngWork.NoDispPositionDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NODISPPOSITIONDIVCDRF"));
		//						wkNoTypeMngWork.NumberingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGDIVCDRF"));
		//						wkNoTypeMngWork.NumberingTypeDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGTYPEDIVCDRF"));
		//						wkNoTypeMngWork.NumberingAmbitDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGAMBITDIVCDRF"));
		//						wkNoTypeMngWork.NoResetTimingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NORESETTIMINGDIVCDRF"));
		//
		//						al.Add(wkNoTypeMngWork);
		//
		//						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//					}
		//				}
		//				catch (SqlException ex) 
		//				{
		//					//���N���X�ɗ�O��n���ď������Ă��炤
		//					status = base.WriteSQLErrorLog(ex);
		//				}
		//
		//			}
		//
		//			if(!myReader.IsClosed)myReader.Close();
		//			sqlConnection.Close();
		//
		//			retList = al;
		//
		//			return status;
		//
		//		}

		/*
		/// <summary>
		/// �ԍ��Ǘ��ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">NoMngSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int WriteAllNoMngSet(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			ArrayList al = new ArrayList();

			try 
			{
				// XML�̓ǂݍ���
				NoMngSetWork[] ew = (NoMngSetWork[])XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork[]));
				NoMngSetWork NoMngSetWork = null;

				sqlConnection = new SqlConnection(_connectionText);
				sqlConnection.Open();

				int n;
				for (n=0; n<ew.Length; n++)
				{
					NoMngSetWork = ew[n];

					//Select�R�}���h�̐���
					SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, NOCODERF FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE", sqlConnection);

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
					SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.SectionCode);
					findParaNoCode.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.NoCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != NoMngSetWork.UpdateDateTime)
						{
							//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
							if (NoMngSetWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
							else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

						sqlCommand.CommandText = "UPDATE NOMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , NOCODERF=@NOCODE , NOPRESENTVALRF=@NOPRESENTVAL , SETTINGSTARTNORF=@SETTINGSTARTNO , SETTINGENDNORF=@SETTINGENDNO , NOINCDECWIDTHRF=@NOINCDECWIDTH WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE";

						//KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.EnterpriseCode);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.SectionCode);
						findParaNoCode.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.NoCode);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)NoMngSetWork;
						FileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						if (NoMngSetWork.UpdateDateTime > DateTime.MinValue)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

						//�V�K�쐬����SQL���𐶐�
						sqlCommand.CommandText = "INSERT INTO NOMNGSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, NOCODERF, NOPRESENTVALRF, SETTINGSTARTNORF, SETTINGENDNORF, NOINCDECWIDTHRF) "
							+"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @NOCODE, @NOPRESENTVAL, @SETTINGSTARTNO, @SETTINGENDNO, @NOINCDECWIDTH)";

						//�o�^�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)NoMngSetWork;
						FileHeader.SetInsertHeader(ref flhd,obj);
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
					SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
					SqlParameter paraNoCode = sqlCommand.Parameters.Add("@NOCODE", SqlDbType.Int);
					SqlParameter paraNoPresentVal = sqlCommand.Parameters.Add("@NOPRESENTVAL", SqlDbType.BigInt);
					SqlParameter paraSettingStartNo = sqlCommand.Parameters.Add("@SETTINGSTARTNO", SqlDbType.BigInt);
					SqlParameter paraSettingEndNo = sqlCommand.Parameters.Add("@SETTINGENDNO", SqlDbType.BigInt);
					SqlParameter paraNoIncDecWidth = sqlCommand.Parameters.Add("@NOINCDECWIDTH", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(NoMngSetWork.CreateDateTime);
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(NoMngSetWork.UpdateDateTime);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.EnterpriseCode);
					paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(NoMngSetWork.FileHeaderGuid);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(NoMngSetWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(NoMngSetWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.LogicalDeleteCode);
					paraSectionCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.SectionCode);
					paraNoCode.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.NoCode);
					paraNoPresentVal.Value = SqlDataMediator.SqlSetInt64(NoMngSetWork.NoPresentVal);
					paraSettingStartNo.Value = SqlDataMediator.SqlSetInt64(NoMngSetWork.SettingStartNo);
					paraSettingEndNo.Value = SqlDataMediator.SqlSetInt64(NoMngSetWork.SettingEndNo);
					paraNoIncDecWidth.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.NoIncDecWidth);

					al.Add(NoMngSetWork);

					sqlCommand.ExecuteNonQuery();

				}

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				NoMngSetWork[] nomngsetWork = (NoMngSetWork[])al.ToArray(typeof(NoMngSetWork));
				parabyte = XmlByteSerializer.Serialize(nomngsetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">NoMngSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int LogicalDeleteNoMngSet(ref byte[] parabyte)
		{
			return LogicalDeleteNoMngSetProc(ref parabyte,0);
		}

		/// <summary>
		/// �_���폜�ԍ��Ǘ��ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int RevivalLogicalDeleteNoMngSet(ref byte[] parabyte)
		{
			return LogicalDeleteNoMngSetProc(ref parabyte,1);
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">NoMngSetWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		private int LogicalDeleteNoMngSetProc(ref byte[] parabyte,int procMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try		
			{
				// XML�̓ǂݍ���
				NoMngSetWork nomngsetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork));

				sqlConnection = new SqlConnection(_connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF, NOCODERF FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE", sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
				findParaSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
				findParaNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != nomngsetWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE NOMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE";

					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
					findParaNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)nomngsetWork;
					FileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					if(!myReader.IsClosed)myReader.Close();
					sqlConnection.Close();
					return status;
				}
				sqlCommand.Cancel();
				if(!myReader.IsClosed)myReader.Close();

				//�_���폜���[�h�̏ꍇ
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	nomngsetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						nomngsetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	nomngsetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(nomngsetWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(nomngsetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(nomngsetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(nomngsetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">�ԍ��Ǘ��ݒ�I�u�W�F�N�g</param>
		/// <returns></returns>
		public int DeleteNoMngSet(byte[] parabyte)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				// XML�̓ǂݍ���
				NoMngSetWork nomngsetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork));

				sqlConnection = new SqlConnection(_connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF, NOCODERF FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE", sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
				findParaSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
				findParaNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
					if (_updateDateTime != nomngsetWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE";

					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
					findParaSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
					findParaNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					if(!myReader.IsClosed)myReader.Close();
					sqlConnection.Close();
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

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			return status;
		}

		*/

		#endregion

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�A���_�R�[�h�A�ԍ��R�[�h�̔ԍ��Ǘ��ݒ����߂��܂�
		/// </summary>
		/// <param name="parabyte">NoMngSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		public int ReadNoMngSet(ref byte[] parabyte , int readMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoMngSetWork NoMngSetWork = new NoMngSetWork();

			try 
			{			
				// XML�̓ǂݍ���
				NoMngSetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork));

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
				using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE", sqlConnection))
                {
    				//Prameter�I�u�W�F�N�g�̍쐬
    				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
    				SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
    				SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

    				//Parameter�I�u�W�F�N�g�֒l�ݒ�
    				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.EnterpriseCode);
    				findParaSectionCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.SectionCode);
    				findParaNoCode.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.NoCode);

    				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    				if(myReader.Read())
    				{
    					NoMngSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
    					NoMngSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
    					NoMngSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
    					NoMngSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
    					NoMngSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
    					NoMngSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
    					NoMngSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
    					NoMngSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
    					NoMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
    					NoMngSetWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCODERF"));
    					NoMngSetWork.NoPresentVal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("NOPRESENTVALRF"));
    					NoMngSetWork.SettingStartNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SETTINGSTARTNORF"));
    					NoMngSetWork.SettingEndNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SETTINGENDNORF"));
    					NoMngSetWork.NoIncDecWidth = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOINCDECWIDTHRF"));

    					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
    				}
                }
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.ReadNoMngSet Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
    			if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(NoMngSetWork);

			return status;
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="paraobj">NoMngSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int WriteNoMngSet(ref object paraobj)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			SqlDataReader myReader = null;
			string readSectionCode = "";

			try 
			{
				//				// XML�̓ǂݍ���
				//				NoMngSetWork nomngsetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.Serializable);
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				foreach(NoMngSetWork nomngsetWork in (ArrayList)paraobj)
				{

					//Select�R�}���h�̐���
					using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, NOCODERF FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE", sqlConnection,sqlTransaction))
					{
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
						SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
						findParaSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
						findParaNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);

						myReader = sqlCommand.ExecuteReader();
						if(myReader.Read())
						{
							//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
							DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
							if (_updateDateTime != nomngsetWork.UpdateDateTime)
							{
								//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
								if (nomngsetWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
									//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
								else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
								sqlCommand.Cancel();
								if(!myReader.IsClosed)myReader.Close();
								return status;
							}

							sqlCommand.CommandText = "UPDATE NOMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , NOCODERF=@NOCODE , NOPRESENTVALRF=@NOPRESENTVAL , SETTINGSTARTNORF=@SETTINGSTARTNO , SETTINGENDNORF=@SETTINGENDNO , NOINCDECWIDTHRF=@NOINCDECWIDTH WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE";

							//KEY�R�}���h���Đݒ�
							findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
							findParaSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
							findParaNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);

							//�X�V�w�b�_����ݒ�
							object obj = (object)this;
							IFileHeader flhd = (IFileHeader)nomngsetWork;
                            FileHeader fileHeader = new FileHeader(obj);
							fileHeader.SetUpdateHeader(ref flhd,obj);
						}
						else
						{
							//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
							if (nomngsetWork.UpdateDateTime > DateTime.MinValue)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
								sqlCommand.Cancel();
								if(!myReader.IsClosed)myReader.Close();
								return status;
							}

							//�V�K�쐬����SQL���𐶐�
							sqlCommand.CommandText = "INSERT INTO NOMNGSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, NOCODERF, NOPRESENTVALRF, SETTINGSTARTNORF, SETTINGENDNORF, NOINCDECWIDTHRF) "
								+"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @NOCODE, @NOPRESENTVAL, @SETTINGSTARTNO, @SETTINGENDNO, @NOINCDECWIDTH)";

							//�o�^�w�b�_����ݒ�
							object obj = (object)this;
							IFileHeader flhd = (IFileHeader)nomngsetWork;
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
						SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
						SqlParameter paraNoCode = sqlCommand.Parameters.Add("@NOCODE", SqlDbType.Int);
						SqlParameter paraNoPresentVal = sqlCommand.Parameters.Add("@NOPRESENTVAL", SqlDbType.BigInt);
						SqlParameter paraSettingStartNo = sqlCommand.Parameters.Add("@SETTINGSTARTNO", SqlDbType.BigInt);
						SqlParameter paraSettingEndNo = sqlCommand.Parameters.Add("@SETTINGENDNO", SqlDbType.BigInt);
						SqlParameter paraNoIncDecWidth = sqlCommand.Parameters.Add("@NOINCDECWIDTH", SqlDbType.Int);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(nomngsetWork.CreateDateTime);
						paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(nomngsetWork.UpdateDateTime);
						paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
						paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(nomngsetWork.FileHeaderGuid);
						paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.UpdEmployeeCode);
						paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(nomngsetWork.UpdAssemblyId1);
						paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(nomngsetWork.UpdAssemblyId2);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.LogicalDeleteCode);
						paraSectionCode.Value = SqlDataMediator.SqlSetString(nomngsetWork.SectionCode);
						paraNoCode.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);
						paraNoPresentVal.Value = SqlDataMediator.SqlSetInt64(nomngsetWork.NoPresentVal);
						paraSettingStartNo.Value = SqlDataMediator.SqlSetInt64(nomngsetWork.SettingStartNo);
						paraSettingEndNo.Value = SqlDataMediator.SqlSetInt64(nomngsetWork.SettingEndNo);
						paraNoIncDecWidth.Value = SqlDataMediator.SqlSetInt32(nomngsetWork.NoIncDecWidth);

						//�N�G�����s
						sqlCommand.ExecuteNonQuery();

						//�ݒ�J�n�ԍ��A�ݒ�I���ԍ��d���`�F�b�N
						//�p�����[�^�̋��_�R�[�h��000000�̏ꍇ�A��ƒʔԂ̔ԍ��R�[�h�Ȃ̂ŏd���`�F�b�N�͍s���܂���B
						if(nomngsetWork.SectionCode != DEFAULT_SECTIONCODE)
						{
							//��ƃR�[�h�A�ԍ��R�[�h�ŃZ���N�g
							sqlCommand.CommandText = "SELECT * FROM NOMNGSETRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND NOCODERF = @FINDNOCODE ";
							findParaEnterpriseCode.Value	= SqlDataMediator.SqlSetString(nomngsetWork.EnterpriseCode);
							findParaNoCode.Value			= SqlDataMediator.SqlSetInt32(nomngsetWork.NoCode);
							//�N�G�����s
							myReader = sqlCommand.ExecuteReader();
							while(myReader.Read())
							{
								//���_�R�[�h���擾
								readSectionCode = SqlDataMediator.SqlGetString(myReader , myReader.GetOrdinal("SECTIONCODERF"));
								//�p�����[�^�̋��_�R�[�h�ƈႤ�ꍇ
								if(readSectionCode != nomngsetWork.SectionCode)
								{
									//�p�����[�^�̐ݒ�J�n�ԍ����擾���������_�̐ݒ�J�n�ԍ������傫���ꍇ
									if( (nomngsetWork.SettingStartNo >= SqlDataMediator.SqlGetInt64(myReader , myReader.GetOrdinal("SETTINGSTARTNORF")) 
										//�܂��̓p�����[�^�̐ݒ�J�n�ԍ����擾���������_�̐ݒ�I���ԍ������������ꍇ
										&& nomngsetWork.SettingStartNo <= SqlDataMediator.SqlGetInt64(myReader , myReader.GetOrdinal("SETTINGENDNORF")))
										//�܂��̓p�����[�^�̐ݒ�I���ԍ����擾���������_�̐ݒ�J�n�ԍ������傫���ꍇ
										|| ( nomngsetWork.SettingEndNo >= SqlDataMediator.SqlGetInt64(myReader , myReader.GetOrdinal("SETTINGSTARTNORF"))
										//�܂��̓p�����[�^�̐ݒ�I���ԍ����擾���������_�̐ݒ�I���ԍ������������ꍇ
										&& nomngsetWork.SettingEndNo <= SqlDataMediator.SqlGetInt64(myReader , myReader.GetOrdinal("SETTINGENDNORF"))) )
									{
										if(nomngsetWork.SettingStartNo == 0 && nomngsetWork.SettingEndNo == 0)
										{
										}
										else
										{
											//�ݒ肵���ԍ��������_�Ŏg�p���Ȃ̂ŏd���̃G���[�ŕԂ�
											status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
											sqlCommand.Cancel();
											if(!myReader.IsClosed)myReader.Close();
											return status;
										}
									}
								}
							}
							if(!myReader.IsClosed)myReader.Close();
						}
                    }
				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

				sqlTransaction.Commit();
				//				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				//				parabyte = XmlByteSerializer.Serialize(NoMngSetWork);

			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.WriteNoMngSet Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
			{
				if(!myReader.IsClosed)myReader.Close();

				if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ���[���o�b�N
					sqlTransaction.Rollback();
				}

                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			return status;
		}


		#endregion


		#region �ԍ��^�C�v�Ǘ�

		#region �C���^�[�t�F�[�X�Ō��J���Ă��Ȃ����\�b�h

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�A�ԍ��R�[�h�̔ԍ��^�C�v�Ǘ�����߂��܂�
		/// </summary>
		/// <param name="notypemngWork">NoMngSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <param name="sqlTransaction">�g�����U�N�V����</param>
		/// <returns>STATUS</returns>
		public int ReadNoTypeMng(ref NoTypeMngWork notypemngWork , int readMode , ref SqlConnection sqlConnection , ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			SqlDataReader myReader = null;

			try 
			{
				//Select�R�}���h�̐���	
                // 2008.05.30 upd start -------------------------------------->>
   				//SqlCommand sqlCommand = new SqlCommand("SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOCODERF=@FINDNOCODE", sqlConnection , sqlTransaction);
                string sqlTxt = string.Empty; 
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                sqlTxt += "    ,NONAMERF" + Environment.NewLine;
                sqlTxt += "    ,NOITEMPATTERNCDRF" + Environment.NewLine;
                sqlTxt += "    ,NOCHARCTERCOUNTRF" + Environment.NewLine;
                sqlTxt += "    ,CONSNOCHARCTERCOUNTRF" + Environment.NewLine;
                sqlTxt += "    ,NODISPPOSITIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,NUMBERINGDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,NUMBERINGTYPEDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,NUMBERINGAMBITDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,NORESETTIMINGDIVCDRF" + Environment.NewLine;
                sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND NOCODERF=@FINDNOCODE" + Environment.NewLine;
                SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                // 2008.05.30 upd end ----------------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
				findParaNoCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					notypemngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					notypemngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					notypemngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					notypemngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					notypemngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					notypemngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					notypemngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					notypemngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					notypemngWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCODERF"));
					notypemngWork.NoName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NONAMERF"));
					notypemngWork.NoItemPatternCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOITEMPATTERNCDRF"));
					notypemngWork.NoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCHARCTERCOUNTRF"));
					notypemngWork.ConsNoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSNOCHARCTERCOUNTRF"));
					notypemngWork.NoDispPositionDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NODISPPOSITIONDIVCDRF"));
					notypemngWork.NumberingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGDIVCDRF"));
					notypemngWork.NumberingTypeDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGTYPEDIVCDRF"));
					notypemngWork.NumberingAmbitDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGAMBITDIVCDRF"));
					notypemngWork.NoResetTimingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NORESETTIMINGDIVCDRF"));

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
    			if(!myReader.IsClosed)myReader.Close();
            }

			return status;
		}

		#endregion 

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��^�C�v�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		public int SearchNoTypeMng(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
	//		return SearchNoTypeMngProc(out retobj, paraobj ,readMode,logicalMode);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retobj = null;
            try
            {
                status =  SearchNoTypeMngProc(out retobj, paraobj ,readMode,logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.SearchNoTypeMng Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		private int SearchNoTypeMngProc(out object retobj,object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoTypeMngWork notypemngWork = new NoTypeMngWork();
			notypemngWork = null;

			retobj = null;

            string sqlTxt = string.Empty; // 2008.05.30 add
			ArrayList al = new ArrayList();
			try 
			{	
				notypemngWork = paraobj as NoTypeMngWork;

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

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
                {
    				//�f�[�^�Ǎ�
    				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
    					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
    					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
    					(logicalMode == ConstantManagement.LogicalMode.GetData3))
    				{
                        // 2008.05.30 upd start ----------------------------------->>
    					//sqlCommand.CommandText = "SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY NOCODERF ";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                        sqlTxt += "    ,NONAMERF" + Environment.NewLine;
                        sqlTxt += "    ,NOITEMPATTERNCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NOCHARCTERCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,CONSNOCHARCTERCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,NODISPPOSITIONDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGTYPEDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGAMBITDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NORESETTIMINGDIVCDRF" + Environment.NewLine;
                        sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY NOCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.30 upd end -------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
    					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
    				}
    				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
    				{
                        // 2008.05.30 upd start ----------------------------------->>
    					//sqlCommand.CommandText = "SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY NOCODERF ";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                        sqlTxt += "    ,NONAMERF" + Environment.NewLine;
                        sqlTxt += "    ,NOITEMPATTERNCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NOCHARCTERCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,CONSNOCHARCTERCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,NODISPPOSITIONDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGTYPEDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGAMBITDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NORESETTIMINGDIVCDRF" + Environment.NewLine;
                        sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY NOCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.30 upd end -------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
    					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
    					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
    				}
    				else
    				{
                        // 2008.05.30 upd start ----------------------------------->>
    					//sqlCommand.CommandText = "SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY NOCODERF ";
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                        sqlTxt += "    ,NONAMERF" + Environment.NewLine;
                        sqlTxt += "    ,NOITEMPATTERNCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NOCHARCTERCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,CONSNOCHARCTERCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,NODISPPOSITIONDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGTYPEDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGAMBITDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NORESETTIMINGDIVCDRF" + Environment.NewLine;
                        sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY NOCODERF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.30 upd end -------------------------------------<<
    				}
    				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
    				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);

    				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    				while(myReader.Read())
    				{
    					NoTypeMngWork wkNoTypeMngWork = new NoTypeMngWork();

	    				wkNoTypeMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
	    				wkNoTypeMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
	    				wkNoTypeMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
	    				wkNoTypeMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
	    				wkNoTypeMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
	    				wkNoTypeMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
	    				wkNoTypeMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
	    				wkNoTypeMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
	    				wkNoTypeMngWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCODERF"));
	    				wkNoTypeMngWork.NoName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NONAMERF"));
	    				wkNoTypeMngWork.NoItemPatternCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOITEMPATTERNCDRF"));
	    				wkNoTypeMngWork.NoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCHARCTERCOUNTRF"));
	    				wkNoTypeMngWork.ConsNoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSNOCHARCTERCOUNTRF"));
	    				wkNoTypeMngWork.NoDispPositionDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NODISPPOSITIONDIVCDRF"));
	    				wkNoTypeMngWork.NumberingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGDIVCDRF"));
	    				wkNoTypeMngWork.NumberingTypeDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGTYPEDIVCDRF"));
	    				wkNoTypeMngWork.NumberingAmbitDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGAMBITDIVCDRF"));
	    				wkNoTypeMngWork.NoResetTimingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NORESETTIMINGDIVCDRF"));

    					al.Add(wkNoTypeMngWork);

    					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
	    			}
                }
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"SecInfoSetDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
    			if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			retobj = al;
			return status;

		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retList">��������</param>
		/// <param name="notypemngWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <returns>STATUS</returns>
		public int SearchNoTypeMngProc(out ArrayList retList, NoTypeMngWork notypemngWork, int readMode, ConstantManagement.LogicalMode logicalMode,ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			//retList = null;
            string sqlTxt = string.Empty; // 2008.05.30 add
			ArrayList al = new ArrayList();
			try 
			{	
				//�p�����[�^���s���Ȃ�I��
				if(notypemngWork == null)return status;

				//SqlConnection��null�������ꍇ��������(��X�g����������Ȃ��̂ňꉞ����Ă݂�B�B�B)
				if(sqlConnection == null)
				{
					SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
					string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
					if (connectionText == null || connectionText == "") return status;
	
					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();				
				}

				sqlCommand = new SqlCommand("",sqlConnection);
				
				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.30 upd start ------------------------------------>>
					//sqlCommand.CommandText = "SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY NOCODERF ";
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                    sqlTxt += "    ,NONAMERF" + Environment.NewLine;
                    sqlTxt += "    ,NOITEMPATTERNCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NOCHARCTERCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,CONSNOCHARCTERCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,NODISPPOSITIONDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NUMBERINGDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NUMBERINGTYPEDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NUMBERINGAMBITDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NORESETTIMINGDIVCDRF" + Environment.NewLine;
                    sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " ORDER BY NOCODERF" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.30 upd end --------------------------------------<<
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.30 upd start ------------------------------------>>
					//sqlCommand.CommandText = "SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY NOCODERF ";
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                    sqlTxt += "    ,NONAMERF" + Environment.NewLine;
                    sqlTxt += "    ,NOITEMPATTERNCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NOCHARCTERCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,CONSNOCHARCTERCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,NODISPPOSITIONDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NUMBERINGDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NUMBERINGTYPEDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NUMBERINGAMBITDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NORESETTIMINGDIVCDRF" + Environment.NewLine;
                    sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " ORDER BY NOCODERF" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.30 upd end --------------------------------------<<
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
                    // 2008.05.30 upd start ------------------------------------>>
					//sqlCommand.CommandText = "SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY NOCODERF ";
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                    sqlTxt += "    ,NONAMERF" + Environment.NewLine;
                    sqlTxt += "    ,NOITEMPATTERNCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NOCHARCTERCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,CONSNOCHARCTERCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,NODISPPOSITIONDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NUMBERINGDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NUMBERINGTYPEDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NUMBERINGAMBITDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,NORESETTIMINGDIVCDRF" + Environment.NewLine;
                    sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " ORDER BY NOCODERF" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.30 upd end --------------------------------------<<
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader();
				while(myReader.Read())
				{
					NoTypeMngWork wkNoTypeMngWork = new NoTypeMngWork();

					wkNoTypeMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkNoTypeMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkNoTypeMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkNoTypeMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkNoTypeMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkNoTypeMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkNoTypeMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkNoTypeMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkNoTypeMngWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCODERF"));
					wkNoTypeMngWork.NoName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NONAMERF"));
					wkNoTypeMngWork.NoItemPatternCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOITEMPATTERNCDRF"));
					wkNoTypeMngWork.NoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCHARCTERCOUNTRF"));
					wkNoTypeMngWork.ConsNoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSNOCHARCTERCOUNTRF"));
					wkNoTypeMngWork.NoDispPositionDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NODISPPOSITIONDIVCDRF"));
					wkNoTypeMngWork.NumberingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGDIVCDRF"));
					wkNoTypeMngWork.NumberingTypeDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGTYPEDIVCDRF"));
					wkNoTypeMngWork.NumberingAmbitDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGAMBITDIVCDRF"));
					wkNoTypeMngWork.NoResetTimingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NORESETTIMINGDIVCDRF"));

					al.Add(wkNoTypeMngWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoMngSetDB.SearchNoTypeMngProc Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)
				{
					if(sqlConnection != null)
						if(sqlConnection.State == System.Data.ConnectionState.Open)
							sqlCommand.Cancel();
					sqlCommand.Dispose();
				}
				if(myReader != null)
					if(myReader.IsClosed == false)myReader.Close();
				retList = al;
			}

			return status;

		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�A�ԍ��R�[�h�̔ԍ��^�C�v�Ǘ�����߂��܂�
		/// </summary>
		/// <param name="parabyte">NoMngSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		public int ReadNoTypeMng(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoTypeMngWork notypemngWork = new NoTypeMngWork();

			try 
			{			
				// XML�̓ǂݍ���
				notypemngWork = (NoTypeMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoTypeMngWork));

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
                // 2008.05.30 upd start ------------------------------------>>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOCODERF=@FINDNOCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                sqlTxt += "    ,NONAMERF" + Environment.NewLine;
                sqlTxt += "    ,NOITEMPATTERNCDRF" + Environment.NewLine;
                sqlTxt += "    ,NOCHARCTERCOUNTRF" + Environment.NewLine;
                sqlTxt += "    ,CONSNOCHARCTERCOUNTRF" + Environment.NewLine;
                sqlTxt += "    ,NODISPPOSITIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,NUMBERINGDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,NUMBERINGTYPEDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,NUMBERINGAMBITDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,NORESETTIMINGDIVCDRF" + Environment.NewLine;
                sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND NOCODERF=@FINDNOCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.30 upd end --------------------------------------<<
                {
    				//Prameter�I�u�W�F�N�g�̍쐬
    				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
    				SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

	    			//Parameter�I�u�W�F�N�g�֒l�ݒ�
	    			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
	    			findParaNoCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCode);

    				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    				if(myReader.Read())
    				{
    					notypemngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
    					notypemngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
    					notypemngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
    					notypemngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
    					notypemngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
    					notypemngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
    					notypemngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
    					notypemngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
    					notypemngWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCODERF"));
    					notypemngWork.NoName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NONAMERF"));
    					notypemngWork.NoItemPatternCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOITEMPATTERNCDRF"));
    					notypemngWork.NoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCHARCTERCOUNTRF"));
    					notypemngWork.ConsNoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSNOCHARCTERCOUNTRF"));
    					notypemngWork.NoDispPositionDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NODISPPOSITIONDIVCDRF"));
    					notypemngWork.NumberingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGDIVCDRF"));
    					notypemngWork.NumberingTypeDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGTYPEDIVCDRF"));
    					notypemngWork.NumberingAmbitDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGAMBITDIVCDRF"));
    					notypemngWork.NoResetTimingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NORESETTIMINGDIVCDRF"));

    					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
	    			}
                }
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.ReadNoTypeMng Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
    			if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(notypemngWork);

			return status;
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ�����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">NoTypeMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int WriteNoTypeMng(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
            string sqlTxt = string.Empty; // 2008.05.30 add

			try 
			{
				// XML�̓ǂݍ���
				NoTypeMngWork notypemngWork = (NoTypeMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoTypeMngWork));

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
                // 2008.05.30 upd start ------------------------------------>>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, NOCODERF FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOCODERF=@FINDNOCODE", sqlConnection))
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND NOCODERF=@FINDNOCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.30 upd end --------------------------------------<<
                {
    				//Prameter�I�u�W�F�N�g�̍쐬
    				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
    				SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

	    			//Parameter�I�u�W�F�N�g�֒l�ݒ�
	    			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
	    			findParaNoCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCode);

    				myReader = sqlCommand.ExecuteReader();
    				if(myReader.Read())
    				{
    					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
    					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
    					if (_updateDateTime != notypemngWork.UpdateDateTime)
    					{
    						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
    						if (notypemngWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
    							//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
    						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
    						sqlCommand.Cancel();
    						if(!myReader.IsClosed)myReader.Close();
    						sqlConnection.Close();
    						return status;
    					}

                        // 2008.05.30 upd start ------------------------------------>>
	    				//sqlCommand.CommandText = "UPDATE NOTYPEMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , NOCODERF=@NOCODE , NONAMERF=@NONAME , NOITEMPATTERNCDRF=@NOITEMPATTERNCD , NOCHARCTERCOUNTRF=@NOCHARCTERCOUNT , CONSNOCHARCTERCOUNTRF=@CONSNOCHARCTERCOUNT , NODISPPOSITIONDIVCDRF=@NODISPPOSITIONDIVCD , NUMBERINGDIVCDRF=@NUMBERINGDIVCD , NUMBERINGTYPEDIVCDRF=@NUMBERINGTYPEDIVCD , NUMBERINGAMBITDIVCDRF=@NUMBERINGAMBITDIVCD , NORESETTIMINGDIVCDRF=@NORESETTIMINGDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOCODERF=@FINDNOCODE";
                        sqlTxt = string.Empty;
                        sqlTxt += "UPDATE NOTYPEMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , NOCODERF=@NOCODE" + Environment.NewLine;
                        sqlTxt += " , NONAMERF=@NONAME" + Environment.NewLine;
                        sqlTxt += " , NOITEMPATTERNCDRF=@NOITEMPATTERNCD" + Environment.NewLine;
                        sqlTxt += " , NOCHARCTERCOUNTRF=@NOCHARCTERCOUNT" + Environment.NewLine;
                        sqlTxt += " , CONSNOCHARCTERCOUNTRF=@CONSNOCHARCTERCOUNT" + Environment.NewLine;
                        sqlTxt += " , NODISPPOSITIONDIVCDRF=@NODISPPOSITIONDIVCD" + Environment.NewLine;
                        sqlTxt += " , NUMBERINGDIVCDRF=@NUMBERINGDIVCD" + Environment.NewLine;
                        sqlTxt += " , NUMBERINGTYPEDIVCDRF=@NUMBERINGTYPEDIVCD" + Environment.NewLine;
                        sqlTxt += " , NUMBERINGAMBITDIVCDRF=@NUMBERINGAMBITDIVCD" + Environment.NewLine;
                        sqlTxt += " , NORESETTIMINGDIVCDRF=@NORESETTIMINGDIVCD" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND NOCODERF=@FINDNOCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.30 upd end --------------------------------------<<

	    				//KEY�R�}���h���Đݒ�
	    				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
	    				findParaNoCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCode);

    					//�X�V�w�b�_����ݒ�
    					object obj = (object)this;
    					IFileHeader flhd = (IFileHeader)notypemngWork;
                     FileHeader fileHeader = new FileHeader(obj);
    					fileHeader.SetUpdateHeader(ref flhd,obj);
    				}
    				else
    				{
    					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
    					if (notypemngWork.UpdateDateTime > DateTime.MinValue)
    					{
	    					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
	    					sqlCommand.Cancel();
	    					if(!myReader.IsClosed)myReader.Close();
	    					sqlConnection.Close();
	    					return status;
	    				}

    					//�V�K�쐬����SQL���𐶐�
                        // 2008.05.30 upd start ------------------------------------>>
    					//sqlCommand.CommandText = "INSERT INTO NOTYPEMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, NOCODERF, NONAMERF, NOITEMPATTERNCDRF, NOCHARCTERCOUNTRF, CONSNOCHARCTERCOUNTRF, NODISPPOSITIONDIVCDRF, NUMBERINGDIVCDRF, NUMBERINGTYPEDIVCDRF, NUMBERINGAMBITDIVCDRF, NORESETTIMINGDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @NOCODE, @NONAME, @NOITEMPATTERNCD, @NOCHARCTERCOUNT, @CONSNOCHARCTERCOUNT, @NODISPPOSITIONDIVCD, @NUMBERINGDIVCD, @NUMBERINGTYPEDIVCD, @NUMBERINGAMBITDIVCD, @NORESETTIMINGDIVCD)";
                        sqlTxt = string.Empty;
                        sqlTxt += "INSERT INTO NOTYPEMNGRF" + Environment.NewLine;
                        sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                        sqlTxt += "    ,NONAMERF" + Environment.NewLine;
                        sqlTxt += "    ,NOITEMPATTERNCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NOCHARCTERCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,CONSNOCHARCTERCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,NODISPPOSITIONDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGTYPEDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NUMBERINGAMBITDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,NORESETTIMINGDIVCDRF" + Environment.NewLine;
                        sqlTxt += " )" + Environment.NewLine;
                        sqlTxt += " VALUES" + Environment.NewLine;
                        sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += "    ,@NOCODE" + Environment.NewLine;
                        sqlTxt += "    ,@NONAME" + Environment.NewLine;
                        sqlTxt += "    ,@NOITEMPATTERNCD" + Environment.NewLine;
                        sqlTxt += "    ,@NOCHARCTERCOUNT" + Environment.NewLine;
                        sqlTxt += "    ,@CONSNOCHARCTERCOUNT" + Environment.NewLine;
                        sqlTxt += "    ,@NODISPPOSITIONDIVCD" + Environment.NewLine;
                        sqlTxt += "    ,@NUMBERINGDIVCD" + Environment.NewLine;
                        sqlTxt += "    ,@NUMBERINGTYPEDIVCD" + Environment.NewLine;
                        sqlTxt += "    ,@NUMBERINGAMBITDIVCD" + Environment.NewLine;
                        sqlTxt += "    ,@NORESETTIMINGDIVCD" + Environment.NewLine;
                        sqlTxt += " )" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.30 upd end --------------------------------------<<

	    				//�o�^�w�b�_����ݒ�
	    				object obj = (object)this;
	    				IFileHeader flhd = (IFileHeader)notypemngWork;
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
    				SqlParameter paraNoCode = sqlCommand.Parameters.Add("@NOCODE", SqlDbType.Int);
    				SqlParameter paraNoName = sqlCommand.Parameters.Add("@NONAME", SqlDbType.NVarChar);
    				SqlParameter paraNoItemPatternCd = sqlCommand.Parameters.Add("@NOITEMPATTERNCD", SqlDbType.Int);
    				SqlParameter paraNoCharcterCount = sqlCommand.Parameters.Add("@NOCHARCTERCOUNT", SqlDbType.Int);
    				SqlParameter paraConsNoCharcterCount = sqlCommand.Parameters.Add("@CONSNOCHARCTERCOUNT", SqlDbType.Int);
    				SqlParameter paraNoDispPositionDivCd = sqlCommand.Parameters.Add("@NODISPPOSITIONDIVCD", SqlDbType.Int);
    				SqlParameter paraNumberingDivCd = sqlCommand.Parameters.Add("@NUMBERINGDIVCD", SqlDbType.Int);
    				SqlParameter paraNumberingTypeDivCd = sqlCommand.Parameters.Add("@NUMBERINGTYPEDIVCD", SqlDbType.Int);
    				SqlParameter paraNumberingAmbitDivCd = sqlCommand.Parameters.Add("@NUMBERINGAMBITDIVCD", SqlDbType.Int);
    				SqlParameter paraNoResetTimingDivCd = sqlCommand.Parameters.Add("@NORESETTIMINGDIVCD", SqlDbType.Int);

    				//Parameter�I�u�W�F�N�g�֒l�ݒ�
    				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(notypemngWork.CreateDateTime);
    				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(notypemngWork.UpdateDateTime);
    				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
    				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(notypemngWork.FileHeaderGuid);
    				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(notypemngWork.UpdEmployeeCode);
    				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(notypemngWork.UpdAssemblyId1);
    				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(notypemngWork.UpdAssemblyId2);
    				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.LogicalDeleteCode);
    				paraNoCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCode);
    				paraNoName.Value = SqlDataMediator.SqlSetString(notypemngWork.NoName);
    				paraNoItemPatternCd.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoItemPatternCd);
    				paraNoCharcterCount.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCharcterCount);
    				paraConsNoCharcterCount.Value = SqlDataMediator.SqlSetInt32(notypemngWork.ConsNoCharcterCount);
    				paraNoDispPositionDivCd.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoDispPositionDivCd);
    				paraNumberingDivCd.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NumberingDivCd);
    				paraNumberingTypeDivCd.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NumberingTypeDivCd);
    				paraNumberingAmbitDivCd.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NumberingAmbitDivCd);
    				paraNoResetTimingDivCd.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoResetTimingDivCd);

	    			sqlCommand.ExecuteNonQuery();

	    			// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
	    			parabyte = XmlByteSerializer.Serialize(notypemngWork);

    				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.WriteNoTypeMng Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
    			if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			return status;
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ�����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">NoTypeMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int LogicalDeleteNoTypeMng(ref byte[] parabyte)
		{
	//		return LogicalDeleteNoTypeMngProc(ref parabyte,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteNoTypeMngProc(ref parabyte,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.LogicalDeleteNoTypeMng Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �_���폜�ԍ��^�C�v�Ǘ����𕜊����܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int RevivalLogicalDeleteNoTypeMng(ref byte[] parabyte)
		{
	//		return LogicalDeleteNoTypeMngProc(ref parabyte,1);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteNoTypeMngProc(ref parabyte,1);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.RevivalLogicalDeleteNoTypeMng Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">NoTypeMngWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		private int LogicalDeleteNoTypeMngProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
            string sqlTxt = string.Empty; // 2008.05.30 add
			try		
			{
				// XML�̓ǂݍ���
				NoTypeMngWork notypemngWork = (NoTypeMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoTypeMngWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                //SQL������
                // 2008.05.30 upd start ------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, NOCODERF FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOCODERF=@FINDNOCODE", sqlConnection))
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND NOCODERF=@FINDNOCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                // 2008.05.30 upd end ---------------------------------------<<
                {
    				//Prameter�I�u�W�F�N�g�̍쐬
    				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
    				SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

    				//Parameter�I�u�W�F�N�g�֒l�ݒ�
    				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
    				findParaNoCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCode);

    				myReader = sqlCommand.ExecuteReader();
    				if(myReader.Read())
    				{
    					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
    					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
    					if (_updateDateTime != notypemngWork.UpdateDateTime)
    					{
    						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
    						sqlCommand.Cancel();
    						if(!myReader.IsClosed)myReader.Close();
    						sqlConnection.Close();
    						return status;
    					}
    					//���݂̘_���폜�敪���擾
    					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        // 2008.05.30 upd start ------------------------------------->>
    					//sqlCommand.CommandText = "UPDATE NOTYPEMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOCODERF=@FINDNOCODE";
                        sqlTxt = string.Empty;
                        sqlTxt += "UPDATE NOTYPEMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND NOCODERF=@FINDNOCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.30 upd end ---------------------------------------<<

    					//KEY�R�}���h���Đݒ�
    					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
    					findParaNoCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCode);

    					//�X�V�w�b�_����ݒ�
    					object obj = (object)this;
    					IFileHeader flhd = (IFileHeader)notypemngWork;
                        FileHeader fileHeader = new FileHeader(obj);
    					fileHeader.SetUpdateHeader(ref flhd,obj);
    				}
    				else
    				{
    					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
    					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
    					sqlCommand.Cancel();
    					if(!myReader.IsClosed)myReader.Close();
    					sqlConnection.Close();
    					return status;
    				}
    				sqlCommand.Cancel();
    				if(!myReader.IsClosed)myReader.Close();

    				//�_���폜���[�h�̏ꍇ
    				if (procMode == 0)
    				{
    					if		(logicalDelCd == 3)
    					{
    						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
    						sqlCommand.Cancel();
    						if(!myReader.IsClosed)myReader.Close();
    						sqlConnection.Close();
    						return status;
    					}
    					else if	(logicalDelCd == 0)	notypemngWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
    					else						notypemngWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
    				}
    				else
    				{
    					if		(logicalDelCd == 1)	notypemngWork.LogicalDeleteCode = 0;//�_���폜�t���O������
    					else
    					{
    						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
    						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
    						sqlCommand.Cancel();
    						if(!myReader.IsClosed)myReader.Close();
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
    				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(notypemngWork.UpdateDateTime);
    				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(notypemngWork.UpdEmployeeCode);
    				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(notypemngWork.UpdAssemblyId1);
    				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(notypemngWork.UpdAssemblyId2);
    				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.LogicalDeleteCode);

	    			sqlCommand.ExecuteNonQuery();

    				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
    				parabyte = XmlByteSerializer.Serialize(notypemngWork);

	    			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"SecInfoSetDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
    			if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			return status;
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ����𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">�ԍ��^�C�v�Ǘ��ݒ�I�u�W�F�N�g</param>
		/// <returns></returns>
		public int DeleteNoTypeMng(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
            string sqlTxt = string.Empty; // 2008.05.30 add

			try 
			{
				// XML�̓ǂݍ���
				NoTypeMngWork notypemngWork = (NoTypeMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoTypeMngWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                //SQL������
                // 2008.05.30 upd start ---------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, NOCODERF FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOCODERF=@FINDNOCODE", sqlConnection))
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NOCODERF" + Environment.NewLine;
                sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                sqlTxt += "    AND NOCODERF=@FINDNOCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))   
                // 2008.05.30 upd end ------------------------------------<<
                {
    				//Prameter�I�u�W�F�N�g�̍쐬
    				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
    				SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

    				//Parameter�I�u�W�F�N�g�֒l�ݒ�
    				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
    				findParaNoCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCode);

    				myReader = sqlCommand.ExecuteReader();
    				if(myReader.Read())
    				{
    					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
    					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
    					if (_updateDateTime != notypemngWork.UpdateDateTime)
    					{
    						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
    						sqlCommand.Cancel();
    						if(!myReader.IsClosed)myReader.Close();
    						sqlConnection.Close();
    						return status;
    					}
                        // 2008.05.30 upd start ---------------------------------->>
    					//sqlCommand.CommandText = "DELETE FROM NOTYPEMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOCODERF=@FINDNOCODE";
                        sqlTxt = string.Empty;
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM NOTYPEMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND NOCODERF=@FINDNOCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.30 upd end ------------------------------------<<

    					//KEY�R�}���h���Đݒ�
    					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(notypemngWork.EnterpriseCode);
    					findParaNoCode.Value = SqlDataMediator.SqlSetInt32(notypemngWork.NoCode);
    				}
    				else
    				{
    					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
    					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
    					sqlCommand.Cancel();
    					if(!myReader.IsClosed)myReader.Close();
    					sqlConnection.Close();
    					return status;
    				}
    				if(!myReader.IsClosed)myReader.Close();

    				sqlCommand.ExecuteNonQuery();

    				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.DeleteNoTypeMng Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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


        // 2008.05.28 del start -------------------------------------->>
		#region �ԍ��v�f�Ǘ��}�X�^

        ///// <summary>
        ///// �w�肳�ꂽ��ƃR�[�h�A�ԍ��v�f�R�[�h�̔ԍ��v�f�Ǘ�����߂��܂�
        ///// </summary>
        ///// <param name="parabyte">NoElmntMngWork�I�u�W�F�N�g</param>
        ///// <param name="readMode">�����敪</param>
        ///// <returns>STATUS</returns>
        //public int ReadNoElmntMng(ref byte[] parabyte , int readMode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //    SqlDataReader myReader = null;

        //    NoElmntMngWork noelmntmngWork = new NoElmntMngWork();

        //    try 
        //    {			
        //        // XML�̓ǂݍ���
        //        noelmntmngWork = (NoElmntMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoElmntMngWork));

        //        //�R�l�N�V����������擾�Ή�����������
        //        //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
        //        //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
        //        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //        if (connectionText == null || connectionText == "") return status;
        //        //�R�l�N�V����������擾�Ή�����������

        //        sqlConnection = new SqlConnection(connectionText);
        //        sqlConnection.Open();

        //        //Select�R�}���h�̐���	
        //        using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM NOELMNTMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOELEMENTCODERF=@FINDNOELEMENTCODE", sqlConnection))
        //        {
        //            //Prameter�I�u�W�F�N�g�̍쐬
        //            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //            SqlParameter findParaNoElementCode = sqlCommand.Parameters.Add("@FINDNOELEMENTCODE", SqlDbType.Int);

        //            //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noelmntmngWork.EnterpriseCode);
        //            findParaNoElementCode.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementCode);

        //            myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //            if(myReader.Read())
        //            {
        //                noelmntmngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
        //                noelmntmngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                noelmntmngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
        //                noelmntmngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //                noelmntmngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //                noelmntmngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //                noelmntmngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //                noelmntmngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
        //                noelmntmngWork.NoElementCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOELEMENTCODERF"));
        //                noelmntmngWork.NoElementYear = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOELEMENTYEARRF"));
        //                noelmntmngWork.NoElementMonth = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOELEMENTMONTHRF"));

        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //        }
        //    }
        //    catch (SqlException ex) 
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch(Exception ex)
        //    {
        //        base.WriteErrorLog(ex,"NoMngSetDB.ReadNoElmntMng Exception="+ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if(!myReader.IsClosed)myReader.Close();
        //        if(sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }

        //    // XML�֕ϊ����A������̃o�C�i����
        //    parabyte = XmlByteSerializer.Serialize(noelmntmngWork);

        //    return status;
        //}

        ///// <summary>
        ///// �ԍ��v�f�Ǘ�����o�^�A�X�V���܂�
        ///// </summary>
        ///// <param name="parabyte">NoElmntMngWork�I�u�W�F�N�g</param>
        ///// <returns>STATUS</returns>
        //public int WriteNoElmntMng(ref byte[] parabyte)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //    SqlDataReader myReader = null;

        //    try 
        //    {
        //        // XML�̓ǂݍ���
        //        NoElmntMngWork noelmntmngWork = (NoElmntMngWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoElmntMngWork));

        //        //�R�l�N�V����������擾�Ή�����������
        //        //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
        //        //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
        //        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //        if (connectionText == null || connectionText == "") return status;
        //        //�R�l�N�V����������擾�Ή�����������

        //        sqlConnection = new SqlConnection(connectionText);
        //        sqlConnection.Open();

        //        //Select�R�}���h�̐���
        //        using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, NOELEMENTCODERF FROM NOELMNTMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOELEMENTCODERF=@FINDNOELEMENTCODE", sqlConnection))
        //        {
        //            //Prameter�I�u�W�F�N�g�̍쐬
        //            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //            SqlParameter findParaNoElementCode = sqlCommand.Parameters.Add("@FINDNOELEMENTCODE", SqlDbType.Int);

        //            //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noelmntmngWork.EnterpriseCode);
        //            findParaNoElementCode.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementCode);

        //            myReader = sqlCommand.ExecuteReader();
        //            if(myReader.Read())
        //            {
        //                //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
        //                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
        //                if (_updateDateTime != noelmntmngWork.UpdateDateTime)
        //                {
        //                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
        //                    if (noelmntmngWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
        //                        //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
        //                    else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                    sqlCommand.Cancel();
        //                    if(!myReader.IsClosed)myReader.Close();
        //                    sqlConnection.Close();
        //                    return status;
        //                }

        //                sqlCommand.CommandText = "UPDATE NOELMNTMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , NOELEMENTCODERF=@NOELEMENTCODE , NOELEMENTYEARRF=@NOELEMENTYEAR , NOELEMENTMONTHRF=@NOELEMENTMONTH WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOELEMENTCODERF=@FINDNOELEMENTCODE";

        //                //KEY�R�}���h���Đݒ�
        //                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noelmntmngWork.EnterpriseCode);
        //                findParaNoElementCode.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementCode);

        //                //�X�V�w�b�_����ݒ�
        //                object obj = (object)this;
        //                IFileHeader flhd = (IFileHeader)noelmntmngWork;
        //                 FileHeader fileHeader = new FileHeader(obj);
        //                fileHeader.SetUpdateHeader(ref flhd,obj);
        //            }
        //            else
        //            {
        //                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
        //                if (noelmntmngWork.UpdateDateTime > DateTime.MinValue)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
        //                    sqlCommand.Cancel();
        //                    if(!myReader.IsClosed)myReader.Close();
        //                    sqlConnection.Close();
        //                    return status;
        //                }

        //                //�V�K�쐬����SQL���𐶐�
        //                sqlCommand.CommandText = "INSERT INTO NOELMNTMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, NOELEMENTCODERF, NOELEMENTYEARRF, NOELEMENTMONTHRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @NOELEMENTCODE, @NOELEMENTYEAR, @NOELEMENTMONTH)";

        //                //�o�^�w�b�_����ݒ�
        //                object obj = (object)this;
        //                IFileHeader flhd = (IFileHeader)noelmntmngWork;
        //                FileHeader fileHeader = new FileHeader(obj);
        //                fileHeader.SetInsertHeader(ref flhd,obj);
        //            }
        //            if(!myReader.IsClosed)myReader.Close();

        //            //Prameter�I�u�W�F�N�g�̍쐬
        //            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
        //            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
        //            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
        //            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
        //            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
        //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
        //            SqlParameter paraNoElementCode = sqlCommand.Parameters.Add("@NOELEMENTCODE", SqlDbType.Int);
        //            SqlParameter paraNoElementYear = sqlCommand.Parameters.Add("@NOELEMENTYEAR", SqlDbType.Int);
        //            SqlParameter paraNoElementMonth = sqlCommand.Parameters.Add("@NOELEMENTMONTH", SqlDbType.Int);

        //            //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noelmntmngWork.CreateDateTime);
        //            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noelmntmngWork.UpdateDateTime);
        //            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noelmntmngWork.EnterpriseCode);
        //            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(noelmntmngWork.FileHeaderGuid);
        //            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noelmntmngWork.UpdEmployeeCode);
        //            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noelmntmngWork.UpdAssemblyId1);
        //            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noelmntmngWork.UpdAssemblyId2);
        //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.LogicalDeleteCode);
        //            paraNoElementCode.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementCode);
        //            paraNoElementYear.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementYear);
        //            paraNoElementMonth.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementMonth);

        //            sqlCommand.ExecuteNonQuery();

        //            // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
        //            parabyte = XmlByteSerializer.Serialize(noelmntmngWork);

        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex) 
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch(Exception ex)
        //    {
        //        base.WriteErrorLog(ex,"NoMngSetDB.WriteNoElmntMng Exception="+ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if(!myReader.IsClosed)myReader.Close();
        //        if(sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }

        //    return status;
        //}
        // 2008.05.28 del end ----------------------------------------<<
        
		#endregion


		#region ���ʃ��\�b�h

        // 2008.05.28 del start ---------------------------------------------------->>
    //    /// <summary>
    //    /// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST�A�ԍ��^�C�v�Ǘ�LIST�A�ԍ��v�f�Ǘ�LIST��S�Ė߂��܂��B
    //    /// </summary>
    //    /// <param name="retNoMngSet">�������ʁi�ԍ��Ǘ��ݒ�j</param>
    //    /// <param name="retNoTypeMng">�������ʁi�ԍ��^�C�v�Ǘ��j</param>
    //    /// <param name="retNoElmntMng">�������ʁi�ԍ��v�f�Ǘ��j</param>
    //    /// <param name="enterpriseCode">�����p�����[�^(��ƃR�[�h)</param>
    //    /// <param name="searchMode">�����敪(0:ALL�A1:�����̔ԗL��̃f�[�^�̂�)</param>
    //    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
    //    /// <returns>STATUS</returns>
    //    public int Search(out object retNoMngSet, out object retNoTypeMng, out object retNoElmntMng, string enterpriseCode, int searchMode,ConstantManagement.LogicalMode logicalMode)
    //    {
    ////		return SearchProc(out retNoMngSet, out retNoTypeMng, out retNoElmntMng, enterpriseCode ,searchMode,logicalMode);
    //        int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
    //        retNoMngSet = null;
    //        retNoTypeMng = null;
    //        retNoElmntMng = null;
    //        try
    //        {
    //            status =  SearchProc(out retNoMngSet, out retNoTypeMng, out retNoElmntMng, enterpriseCode ,searchMode,logicalMode);
    //        }
    //        catch(Exception ex)
    //        {
    //            base.WriteErrorLog(ex,"NoMngSetDB.Search Exception="+ex.Message);
    //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
    //        }
    //        return status;
    //    }

        ///// <summary>
        ///// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST�A�ԍ��^�C�v�Ǘ�LIST�A�ԍ��v�f�Ǘ�LIST��S�Ė߂��܂��B
        ///// </summary>
        ///// <param name="retNoMngSet">�������ʁi�ԍ��Ǘ��ݒ�j</param>
        ///// <param name="retNoTypeMng">�������ʁi�ԍ��^�C�v�Ǘ��j</param>
        ///// <param name="retNoElmntMng">�������ʁi�ԍ��v�f�Ǘ��j</param>
        ///// <param name="enterpriseCode">�����p�����[�^</param>
        ///// <param name="searchMode">�����敪�i0:�S���擾�A1:�ԍ��̔ԋ敪��1.�����̔ԗL��̂݁j</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>STATUS</returns>
        //private int SearchProc(out object retNoMngSet, out object retNoTypeMng, out object retNoElmntMng, string enterpriseCode, int searchMode,ConstantManagement.LogicalMode logicalMode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlConnection sqlConnection = null;
        //    SqlDataReader myReader = null;

        //    retNoMngSet = null;
        //    retNoTypeMng = null;
        //    retNoElmntMng = null;
        //    ArrayList mngList = new ArrayList();
        //    ArrayList typeList = new ArrayList();
        //    ArrayList elmntList = new ArrayList();
        //    string checkSectionCode = "";

        //    try
        //    {
        //        //�R�l�N�V����������擾�Ή�����������
        //        //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
        //        //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
        //        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //        if (connectionText == null || connectionText == "") return status;
        //        //�R�l�N�V����������擾�Ή�����������

        //        //SQL������
        //        sqlConnection = new SqlConnection(connectionText);
        //        sqlConnection.Open();				

        //        using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
        //        {
        //            //�f�[�^�Ǎ�
        //            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData3))
        //            {
        //                sqlCommand.CommandText = "SELECT * "
        //                    + ", MNG.CREATEDATETIMERF AS MNG_CREATEDATETIMERF , MNG.UPDATEDATETIMERF AS MNG_UPDATEDATETIMERF , MNG.FILEHEADERGUIDRF AS MNG_FILEHEADERGUIDRF , MNG.UPDEMPLOYEECODERF AS MNG_UPDEMPLOYEECODERF , MNG.UPDASSEMBLYID1RF AS MNG_UPDASSEMBLYID1RF , MNG.UPDASSEMBLYID2RF AS MNG_UPDASSEMBLYID2RF ,MNG.LOGICALDELETECODERF AS MNG_LOGICALDELETECODERF "
        //                    + ", TYPE.CREATEDATETIMERF AS TYPE_CREATEDATETIMERF , TYPE.UPDATEDATETIMERF AS TYPE_UPDATEDATETIMERF , TYPE.FILEHEADERGUIDRF AS TYPE_FILEHEADERGUIDRF , TYPE.UPDEMPLOYEECODERF AS TYPE_UPDEMPLOYEECODERF , TYPE.UPDASSEMBLYID1RF AS TYPE_UPDASSEMBLYID1RF , TYPE.UPDASSEMBLYID2RF AS TYPE_UPDASSEMBLYID2RF ,TYPE.LOGICALDELETECODERF AS TYPE_LOGICALDELETECODERF "
        //                    + ", ELMNT.CREATEDATETIMERF AS ELMNT_CREATEDATETIMERF , ELMNT.UPDATEDATETIMERF AS ELMNT_UPDATEDATETIMERF , ELMNT.FILEHEADERGUIDRF AS ELMNT_FILEHEADERGUIDRF , ELMNT.UPDEMPLOYEECODERF AS ELMNT_UPDEMPLOYEECODERF , ELMNT.UPDASSEMBLYID1RF AS ELMNT_UPDASSEMBLYID1RF , ELMNT.UPDASSEMBLYID2RF AS ELMNT_UPDASSEMBLYID2RF ,ELMNT.LOGICALDELETECODERF AS ELMNT_LOGICALDELETECODERF "
        //                    + ", MNG.NOCODERF AS MNG_NOCODERF , TYPE.NOCODERF AS TYPE_NOCODERF "
        //                    + "FROM NOTYPEMNGRF AS TYPE LEFT OUTER JOIN NOMNGSETRF AS MNG ON TYPE.ENTERPRISECODERF = MNG.ENTERPRISECODERF "
        //                    + "AND TYPE.NOCODERF = MNG.NOCODERF "
        //                    + "LEFT OUTER JOIN NOELMNTMNGRF AS ELMNT ON TYPE.ENTERPRISECODERF = ELMNT.ENTERPRISECODERF "
        //                    + "WHERE TYPE.ENTERPRISECODERF=@FINDENTERPRISECODE AND TYPE.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
        //                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
        //                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
        //            }
        //            else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
        //            {
        //                sqlCommand.CommandText = "SELECT * "
        //                    + ", MNG.CREATEDATETIMERF AS MNG_CREATEDATETIMERF , MNG.UPDATEDATETIMERF AS MNG_UPDATEDATETIMERF , MNG.FILEHEADERGUIDRF AS MNG_FILEHEADERGUIDRF , MNG.UPDEMPLOYEECODERF AS MNG_UPDEMPLOYEECODERF , MNG.UPDASSEMBLYID1RF AS MNG_UPDASSEMBLYID1RF , MNG.UPDASSEMBLYID2RF AS MNG_UPDASSEMBLYID2RF ,MNG.LOGICALDELETECODERF AS MNG_LOGICALDELETECODERF "
        //                    + ", TYPE.CREATEDATETIMERF AS TYPE_CREATEDATETIMERF , TYPE.UPDATEDATETIMERF AS TYPE_UPDATEDATETIMERF , TYPE.FILEHEADERGUIDRF AS TYPE_FILEHEADERGUIDRF , TYPE.UPDEMPLOYEECODERF AS TYPE_UPDEMPLOYEECODERF , TYPE.UPDASSEMBLYID1RF AS TYPE_UPDASSEMBLYID1RF , TYPE.UPDASSEMBLYID2RF AS TYPE_UPDASSEMBLYID2RF ,TYPE.LOGICALDELETECODERF AS TYPE_LOGICALDELETECODERF "
        //                    + ", ELMNT.CREATEDATETIMERF AS ELMNT_CREATEDATETIMERF , ELMNT.UPDATEDATETIMERF AS ELMNT_UPDATEDATETIMERF , ELMNT.FILEHEADERGUIDRF AS ELMNT_FILEHEADERGUIDRF , ELMNT.UPDEMPLOYEECODERF AS ELMNT_UPDEMPLOYEECODERF , ELMNT.UPDASSEMBLYID1RF AS ELMNT_UPDASSEMBLYID1RF , ELMNT.UPDASSEMBLYID2RF AS ELMNT_UPDASSEMBLYID2RF ,ELMNT.LOGICALDELETECODERF AS ELMNT_LOGICALDELETECODERF "
        //                    + "FROM NOTYPEMNGRF AS TYPE LEFT OUTER JOIN NOMNGSETRF AS MNG ON TYPE.ENTERPRISECODERF = MNG.ENTERPRISECODERF " 
        //                    + "AND TYPE.NOCODERF = MNG.NOCODERF "
        //                    + "LEFT OUTER JOIN NOELMNTMNGRF AS ELMNT ON TYPE.ENTERPRISECODERF = ELMNT.ENTERPRISECODERF "
        //                    + "WHERE TYPE.ENTERPRISECODERF=@FINDENTERPRISECODE AND TYPE.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";

        //                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
        //                if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
        //                else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
        //            }
        //            else
        //            {
        //                sqlCommand.CommandText = "SELECT * "
        //                    + ", MNG.CREATEDATETIMERF AS MNG_CREATEDATETIMERF , MNG.UPDATEDATETIMERF AS MNG_UPDATEDATETIMERF , MNG.FILEHEADERGUIDRF AS MNG_FILEHEADERGUIDRF , MNG.UPDEMPLOYEECODERF AS MNG_UPDEMPLOYEECODERF , MNG.UPDASSEMBLYID1RF AS MNG_UPDASSEMBLYID1RF , MNG.UPDASSEMBLYID2RF AS MNG_UPDASSEMBLYID2RF ,MNG.LOGICALDELETECODERF AS MNG_LOGICALDELETECODERF "
        //                    + ", TYPE.CREATEDATETIMERF AS TYPE_CREATEDATETIMERF , TYPE.UPDATEDATETIMERF AS TYPE_UPDATEDATETIMERF , TYPE.FILEHEADERGUIDRF AS TYPE_FILEHEADERGUIDRF , TYPE.UPDEMPLOYEECODERF AS TYPE_UPDEMPLOYEECODERF , TYPE.UPDASSEMBLYID1RF AS TYPE_UPDASSEMBLYID1RF , TYPE.UPDASSEMBLYID2RF AS TYPE_UPDASSEMBLYID2RF ,TYPE.LOGICALDELETECODERF AS TYPE_LOGICALDELETECODERF "
        //                    + ", ELMNT.CREATEDATETIMERF AS ELMNT_CREATEDATETIMERF , ELMNT.UPDATEDATETIMERF AS ELMNT_UPDATEDATETIMERF , ELMNT.FILEHEADERGUIDRF AS ELMNT_FILEHEADERGUIDRF , ELMNT.UPDEMPLOYEECODERF AS ELMNT_UPDEMPLOYEECODERF , ELMNT.UPDASSEMBLYID1RF AS ELMNT_UPDASSEMBLYID1RF , ELMNT.UPDASSEMBLYID2RF AS ELMNT_UPDASSEMBLYID2RF ,ELMNT.LOGICALDELETECODERF AS ELMNT_LOGICALDELETECODERF "
        //                    + "FROM NOTYPEMNGRF AS TYPE LEFT OUTER JOIN NOMNGSETRF AS MNG ON TYPE.ENTERPRISECODERF = MNG.ENTERPRISECODERF " 
        //                    + "LEFT OUTER JOIN NOELMNTMNGRF AS ELMNT ON TYPE.ENTERPRISECODERF = ELMNT.ENTERPRISECODERF "
        //                    + "AND TYPE.NOCODERF = MNG.NOCODERF "
        //                    + "WHERE TYPE.ENTERPRISECODERF=@FINDENTERPRISECODE ";
        //            }

        //            if( searchMode == 1 )
        //            {
        //                sqlCommand.CommandText += "AND TYPE.NUMBERINGDIVCDRF = " + NUMBERINGDIVCD_ARI ;
        //            }

        //            sqlCommand.CommandText += "ORDER BY TYPE.NOCODERF , MNG.SECTIONCODERF ";

        //            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(enterpriseCode);

        //            myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //            while(myReader.Read())
        //            {
        //                NoMngSetWork wkNoMngSetWork = new NoMngSetWork();
        //                NoTypeMngWork wkNoTypeMngWork = new NoTypeMngWork();
        //                NoElmntMngWork wkNoElmntMngWork = new NoElmntMngWork();

        //                wkNoTypeMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("TYPE_CREATEDATETIMERF"));
        //                wkNoTypeMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("TYPE_UPDATEDATETIMERF"));
        //                wkNoTypeMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
        //                wkNoTypeMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("TYPE_FILEHEADERGUIDRF"));
        //                wkNoTypeMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TYPE_UPDEMPLOYEECODERF"));
        //                wkNoTypeMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TYPE_UPDASSEMBLYID1RF"));
        //                wkNoTypeMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TYPE_UPDASSEMBLYID2RF"));
        //                wkNoTypeMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TYPE_LOGICALDELETECODERF"));
        //                wkNoTypeMngWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TYPE_NOCODERF"));
        //                wkNoTypeMngWork.NoName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NONAMERF"));
        //                wkNoTypeMngWork.NoItemPatternCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOITEMPATTERNCDRF"));
        //                wkNoTypeMngWork.NoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCHARCTERCOUNTRF"));
        //                wkNoTypeMngWork.ConsNoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSNOCHARCTERCOUNTRF"));
        //                wkNoTypeMngWork.NoDispPositionDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NODISPPOSITIONDIVCDRF"));
        //                wkNoTypeMngWork.NumberingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGDIVCDRF"));
        //                wkNoTypeMngWork.NumberingTypeDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGTYPEDIVCDRF"));
        //                wkNoTypeMngWork.NumberingAmbitDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGAMBITDIVCDRF"));
        //                wkNoTypeMngWork.NoResetTimingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NORESETTIMINGDIVCDRF"));
        //                wkNoMngSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("MNG_CREATEDATETIMERF"));
        //                wkNoMngSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("MNG_UPDATEDATETIMERF"));
        //                wkNoMngSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
        //                wkNoMngSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("MNG_FILEHEADERGUIDRF"));
        //                wkNoMngSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MNG_UPDEMPLOYEECODERF"));
        //                wkNoMngSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MNG_UPDASSEMBLYID1RF"));
        //                wkNoMngSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MNG_UPDASSEMBLYID2RF"));
        //                wkNoMngSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MNG_LOGICALDELETECODERF"));

        //                //���_�R�[�h�擾
        //                checkSectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
        //                //�ԍ��̔Ԕ͈͂�0(��ƒʔ�)�ŋ��_�R�[�h�������Ă���ꍇ
        //                if(wkNoTypeMngWork.NumberingAmbitDivCd == ENTERPRISE_SEQUENCE_NUMBER && checkSectionCode != "")
        //                {
        //                    //���_�R�[�h��000000���Z�b�g
        //                    wkNoMngSetWork.SectionCode = DEFAULT_SECTIONCODE;
        //                }
        //                else
        //                {
        //                    //�擾�������_�R�[�h���Z�b�g
        //                    wkNoMngSetWork.SectionCode = checkSectionCode;
        //                }

        //                wkNoMngSetWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MNG_NOCODERF"));
        //                wkNoMngSetWork.NoPresentVal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("NOPRESENTVALRF"));
        //                wkNoMngSetWork.SettingStartNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SETTINGSTARTNORF"));
        //                wkNoMngSetWork.SettingEndNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SETTINGENDNORF"));
        //                wkNoMngSetWork.NoIncDecWidth = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOINCDECWIDTHRF"));
        //                wkNoElmntMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("ELMNT_CREATEDATETIMERF"));
        //                wkNoElmntMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("ELMNT_UPDATEDATETIMERF"));
        //                wkNoElmntMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
        //                wkNoElmntMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("ELMNT_FILEHEADERGUIDRF"));
        //                wkNoElmntMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ELMNT_UPDEMPLOYEECODERF"));
        //                wkNoElmntMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ELMNT_UPDASSEMBLYID1RF"));
        //                wkNoElmntMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ELMNT_UPDASSEMBLYID2RF"));
        //                wkNoElmntMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ELMNT_LOGICALDELETECODERF"));
        //                wkNoElmntMngWork.NoElementCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOELEMENTCODERF"));
        //                wkNoElmntMngWork.NoElementYear = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOELEMENTYEARRF"));
        //                wkNoElmntMngWork.NoElementMonth = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOELEMENTMONTHRF"));

        //                //�ԍ��Ǘ��ݒ�f�[�^�ɋ��_�R�[�h�������Ă��Ȃ����ADD���Ȃ�
        //                if(wkNoMngSetWork.SectionCode != "")
        //                {
        //                    mngList.Add(wkNoMngSetWork);
        //                }

        //                if(typeList.Count == 0)
        //                {
        //                    typeList.Add(wkNoTypeMngWork);
        //                }
        //                else
        //                {
        //                    if( ((NoTypeMngWork)typeList[typeList.Count -1]).NoCode != wkNoTypeMngWork.NoCode)
        //                    {
        //                        typeList.Add(wkNoTypeMngWork);
        //                    }
        //                }

        //                if(elmntList.Count == 0)
        //                {
        //                    elmntList.Add(wkNoElmntMngWork);
        //                }

        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch(Exception ex)
        //    {
        //        base.WriteErrorLog(ex,"SecInfoSetDB.SearchCnt Exception="+ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if(!myReader.IsClosed)myReader.Close();
        //        if(sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }

        //    retNoMngSet = (object)mngList;
        //    retNoTypeMng = (object)typeList;
        //    retNoElmntMng = (object)elmntList;

        //    return status;
        //}
        // 2008.05.28 del end -----------------------------------------------------<<
        
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST�A�ԍ��^�C�v�Ǘ�LIST�A�ԍ��v�f�Ǘ�LIST��S�Ė߂��܂��B
		/// </summary>
		/// <param name="retNoMngSet">�������ʁi�ԍ��Ǘ��ݒ�j</param>
		/// <param name="retNoTypeMng">�������ʁi�ԍ��^�C�v�Ǘ��j</param>
		/// <param name="enterpriseCode">�����p�����[�^(��ƃR�[�h)</param>
		/// <param name="searchMode">�����敪�i0:�S���擾�A1:�ԍ��̔ԋ敪��1.�����̔ԗL��̂݁j</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		public int Search(out object retNoMngSet, out object retNoTypeMng, string enterpriseCode, int searchMode,ConstantManagement.LogicalMode logicalMode)
		{
	//		return SearchProc(out retNoMngSet, out retNoTypeMng, enterpriseCode ,searchMode,logicalMode);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retNoMngSet = null;
            retNoTypeMng = null;
            try
            {
                status =  SearchProc(out retNoMngSet, out retNoTypeMng, enterpriseCode ,searchMode,logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST�A�ԍ��^�C�v�Ǘ�LIST�A�ԍ��v�f�Ǘ�LIST��S�Ė߂��܂��B
		/// </summary>
		/// <param name="retNoMngSet">�������ʁi�ԍ��Ǘ��ݒ�j</param>
		/// <param name="retNoTypeMng">�������ʁi�ԍ��^�C�v�Ǘ��j</param>
		/// <param name="enterpriseCode">�����p�����[�^</param>
		/// <param name="searchMode">�����敪�i0:�S���擾�A1:�ԍ��̔ԋ敪��1.�����̔ԗL��̂݁j</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		private int SearchProc(out object retNoMngSet, out object retNoTypeMng, string enterpriseCode, int searchMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			retNoMngSet = null;
			retNoTypeMng = null;
			ArrayList mngList = new ArrayList();
			ArrayList typeList = new ArrayList();
			string checkSectionCode = "";

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

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
                {
    				//�f�[�^�Ǎ�
    				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
    					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
    					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
    					(logicalMode == ConstantManagement.LogicalMode.GetData3))
    				{
    					sqlCommand.CommandText = "SELECT * "
    						+ ", MNG.CREATEDATETIMERF AS MNG_CREATEDATETIMERF , MNG.UPDATEDATETIMERF AS MNG_UPDATEDATETIMERF , MNG.FILEHEADERGUIDRF AS MNG_FILEHEADERGUIDRF , MNG.UPDEMPLOYEECODERF AS MNG_UPDEMPLOYEECODERF , MNG.UPDASSEMBLYID1RF AS MNG_UPDASSEMBLYID1RF , MNG.UPDASSEMBLYID2RF AS MNG_UPDASSEMBLYID2RF ,MNG.LOGICALDELETECODERF AS MNG_LOGICALDELETECODERF "
    						+ ", TYPE.CREATEDATETIMERF AS TYPE_CREATEDATETIMERF , TYPE.UPDATEDATETIMERF AS TYPE_UPDATEDATETIMERF , TYPE.FILEHEADERGUIDRF AS TYPE_FILEHEADERGUIDRF , TYPE.UPDEMPLOYEECODERF AS TYPE_UPDEMPLOYEECODERF , TYPE.UPDASSEMBLYID1RF AS TYPE_UPDASSEMBLYID1RF , TYPE.UPDASSEMBLYID2RF AS TYPE_UPDASSEMBLYID2RF ,TYPE.LOGICALDELETECODERF AS TYPE_LOGICALDELETECODERF "
    						+ ", MNG.NOCODERF AS MNG_NOCODERF , TYPE.NOCODERF AS TYPE_NOCODERF "
    						+ "FROM NOTYPEMNGRF AS TYPE LEFT OUTER JOIN NOMNGSETRF AS MNG ON TYPE.ENTERPRISECODERF = MNG.ENTERPRISECODERF "
    						+ "AND TYPE.NOCODERF = MNG.NOCODERF " 
    						+ "WHERE TYPE.ENTERPRISECODERF=@FINDENTERPRISECODE AND TYPE.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
    					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
    					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
    				}
    				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
    				{
    					sqlCommand.CommandText = "SELECT * "
    						+ ", MNG.CREATEDATETIMERF AS MNG_CREATEDATETIMERF , MNG.UPDATEDATETIMERF AS MNG_UPDATEDATETIMERF , MNG.FILEHEADERGUIDRF AS MNG_FILEHEADERGUIDRF , MNG.UPDEMPLOYEECODERF AS MNG_UPDEMPLOYEECODERF , MNG.UPDASSEMBLYID1RF AS MNG_UPDASSEMBLYID1RF , MNG.UPDASSEMBLYID2RF AS MNG_UPDASSEMBLYID2RF ,MNG.LOGICALDELETECODERF AS MNG_LOGICALDELETECODERF "
    						+ ", TYPE.CREATEDATETIMERF AS TYPE_CREATEDATETIMERF , TYPE.UPDATEDATETIMERF AS TYPE_UPDATEDATETIMERF , TYPE.FILEHEADERGUIDRF AS TYPE_FILEHEADERGUIDRF , TYPE.UPDEMPLOYEECODERF AS TYPE_UPDEMPLOYEECODERF , TYPE.UPDASSEMBLYID1RF AS TYPE_UPDASSEMBLYID1RF , TYPE.UPDASSEMBLYID2RF AS TYPE_UPDASSEMBLYID2RF ,TYPE.LOGICALDELETECODERF AS TYPE_LOGICALDELETECODERF "
    						+ ", MNG.NOCODERF AS MNG_NOCODERF , TYPE.NOCODERF AS TYPE_NOCODERF "
    						+ "FROM NOTYPEMNGRF AS TYPE LEFT OUTER JOIN NOMNGSETRF AS MNG ON TYPE.ENTERPRISECODERF = MNG.ENTERPRISECODERF " 
    						+ "AND TYPE.NOCODERF = MNG.NOCODERF "
    						+ "WHERE TYPE.ENTERPRISECODERF=@FINDENTERPRISECODE AND TYPE.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";

    					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
    					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
    					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
    				}
    				else
    				{
    					sqlCommand.CommandText = "SELECT * "
    						+ ", MNG.CREATEDATETIMERF AS MNG_CREATEDATETIMERF , MNG.UPDATEDATETIMERF AS MNG_UPDATEDATETIMERF , MNG.FILEHEADERGUIDRF AS MNG_FILEHEADERGUIDRF , MNG.UPDEMPLOYEECODERF AS MNG_UPDEMPLOYEECODERF , MNG.UPDASSEMBLYID1RF AS MNG_UPDASSEMBLYID1RF , MNG.UPDASSEMBLYID2RF AS MNG_UPDASSEMBLYID2RF ,MNG.LOGICALDELETECODERF AS MNG_LOGICALDELETECODERF "
    						+ ", TYPE.CREATEDATETIMERF AS TYPE_CREATEDATETIMERF , TYPE.UPDATEDATETIMERF AS TYPE_UPDATEDATETIMERF , TYPE.FILEHEADERGUIDRF AS TYPE_FILEHEADERGUIDRF , TYPE.UPDEMPLOYEECODERF AS TYPE_UPDEMPLOYEECODERF , TYPE.UPDASSEMBLYID1RF AS TYPE_UPDASSEMBLYID1RF , TYPE.UPDASSEMBLYID2RF AS TYPE_UPDASSEMBLYID2RF ,TYPE.LOGICALDELETECODERF AS TYPE_LOGICALDELETECODERF "
    						+ ", MNG.NOCODERF AS MNG_NOCODERF , TYPE.NOCODERF AS TYPE_NOCODERF "
    						+ "FROM NOTYPEMNGRF AS TYPE LEFT OUTER JOIN NOMNGSETRF AS MNG ON TYPE.ENTERPRISECODERF = MNG.ENTERPRISECODERF " 
    						+ "AND TYPE.NOCODERF = MNG.NOCODERF "
    						+ "WHERE TYPE.ENTERPRISECODERF=@FINDENTERPRISECODE ";
    				}

    				if( searchMode == 1 )
    				{
    					sqlCommand.CommandText += "AND TYPE.NUMBERINGDIVCDRF = "+ NUMBERINGDIVCD_ARI;
    				}

    				sqlCommand.CommandText += "ORDER BY TYPE.NOCODERF , MNG.SECTIONCODERF ";

    				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
    				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(enterpriseCode);

    				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    				while(myReader.Read())
    				{
    					NoMngSetWork wkNoMngSetWork = new NoMngSetWork();
    					NoTypeMngWork wkNoTypeMngWork = new NoTypeMngWork();

	    				wkNoTypeMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("TYPE_CREATEDATETIMERF"));
	    				wkNoTypeMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("TYPE_UPDATEDATETIMERF"));
	    				wkNoTypeMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
	    				wkNoTypeMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("TYPE_FILEHEADERGUIDRF"));
	    				wkNoTypeMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TYPE_UPDEMPLOYEECODERF"));
	    				wkNoTypeMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TYPE_UPDASSEMBLYID1RF"));
	    				wkNoTypeMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("TYPE_UPDASSEMBLYID2RF"));
	    				wkNoTypeMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TYPE_LOGICALDELETECODERF"));
	    				wkNoTypeMngWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TYPE_NOCODERF"));
	    				wkNoTypeMngWork.NoName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NONAMERF"));
	    				wkNoTypeMngWork.NoItemPatternCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOITEMPATTERNCDRF"));
	    				wkNoTypeMngWork.NoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOCHARCTERCOUNTRF"));
	    				wkNoTypeMngWork.ConsNoCharcterCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CONSNOCHARCTERCOUNTRF"));
	    				wkNoTypeMngWork.NoDispPositionDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NODISPPOSITIONDIVCDRF"));
	    				wkNoTypeMngWork.NumberingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGDIVCDRF"));
	    				wkNoTypeMngWork.NumberingTypeDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGTYPEDIVCDRF"));
    					wkNoTypeMngWork.NumberingAmbitDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERINGAMBITDIVCDRF"));
    					wkNoTypeMngWork.NoResetTimingDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NORESETTIMINGDIVCDRF"));
    					wkNoMngSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("MNG_CREATEDATETIMERF"));
    					wkNoMngSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("MNG_UPDATEDATETIMERF"));
    					wkNoMngSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
    					wkNoMngSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("MNG_FILEHEADERGUIDRF"));
    					wkNoMngSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MNG_UPDEMPLOYEECODERF"));
    					wkNoMngSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MNG_UPDASSEMBLYID1RF"));
    					wkNoMngSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MNG_UPDASSEMBLYID2RF"));
    					wkNoMngSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MNG_LOGICALDELETECODERF"));

	    				//���_�R�[�h�擾
	    				checkSectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
	    				//�ԍ��̔Ԕ͈͂�0(��ƒʔ�)�ŋ��_�R�[�h�������Ă���ꍇ
	    				if(wkNoTypeMngWork.NumberingAmbitDivCd == ENTERPRISE_SEQUENCE_NUMBER && checkSectionCode != "")
	    				{
	    					//���_�R�[�h��000000���Z�b�g
	    					wkNoMngSetWork.SectionCode = DEFAULT_SECTIONCODE;
	    				}
	    				else
	    				{
	    					//�擾�������_�R�[�h���Z�b�g
	    					wkNoMngSetWork.SectionCode = checkSectionCode;
	    				}
	
	    				wkNoMngSetWork.NoCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MNG_NOCODERF"));
	    				wkNoMngSetWork.NoPresentVal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("NOPRESENTVALRF"));
	    				wkNoMngSetWork.SettingStartNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SETTINGSTARTNORF"));
	    				wkNoMngSetWork.SettingEndNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SETTINGENDNORF"));
	    				wkNoMngSetWork.NoIncDecWidth = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOINCDECWIDTHRF"));

	    				//�ԍ��Ǘ��ݒ�f�[�^�ɋ��_�R�[�h�������Ă��Ȃ����ADD���Ȃ�
	    				if(wkNoMngSetWork.SectionCode != "")
	    				{
	    					mngList.Add(wkNoMngSetWork);
	    				}

	    				if(typeList.Count == 0)
	    				{
	    					typeList.Add(wkNoTypeMngWork);
	    				}
	    				else
	    				{
	    					if( ((NoTypeMngWork)typeList[typeList.Count -1]).NoCode != wkNoTypeMngWork.NoCode)
	    					{
	    						typeList.Add(wkNoTypeMngWork);
	    					}
	    				}

    					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
	    			}
                }
			}
			catch(SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"SecInfoSetDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
    			if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			retNoMngSet = (object)mngList;
			retNoTypeMng = (object)typeList;

			return status;
		}

        // 2008.05.28 del start --------------------------------------------------------->>
        /// <summary>
        /// �ԍ��Ǘ��ݒ���A�ԍ��v�f�Ǘ���񓯎��������ݗp���\�b�h
        /// </summary>
        /// <param name="paraNoMngSet">�ԍ��Ǘ��ݒ�I�u�W�F�N�g</param>
        /// <param name="paraNoElmntMng">�ԍ��v�f�Ǘ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int Write(ref byte[] paraNoMngSet , ref byte[] paraNoElmntMng) 
 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlTransaction sqlTransaction = null;

            try 
            {
                // XML�̓ǂݍ���
                NoMngSetWork NoMngSetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(paraNoMngSet,typeof(NoMngSetWork));
                NoElmntMngWork noelmntmngWork = (NoElmntMngWork)XmlByteSerializer.Deserialize(paraNoElmntMng,typeof(NoElmntMngWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                //sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.Serializable);
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //Select�R�}���h�̐���
                using( SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, NOCODERF FROM NOMNGSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE", sqlConnection,sqlTransaction) )
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaNoCode = sqlCommand.Parameters.Add("@FINDNOCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.SectionCode);
                    findParaNoCode.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.NoCode);

                    myReader = sqlCommand.ExecuteReader();
                    if(myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != NoMngSetWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (NoMngSetWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if(!myReader.IsClosed)myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }

                        sqlCommand.CommandText = "UPDATE NOMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , NOCODERF=@NOCODE , NOPRESENTVALRF=@NOPRESENTVAL , SETTINGSTARTNORF=@SETTINGSTARTNO , SETTINGENDNORF=@SETTINGENDNO , NOINCDECWIDTHRF=@NOINCDECWIDTH WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND NOCODERF=@FINDNOCODE";

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.SectionCode);
                        findParaNoCode.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.NoCode);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)NoMngSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd,obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (NoMngSetWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if(!myReader.IsClosed)myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }

                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = "INSERT INTO NOMNGSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, NOCODERF, NOPRESENTVALRF, SETTINGSTARTNORF, SETTINGENDNORF, NOINCDECWIDTHRF) "
                            +"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @NOCODE, @NOPRESENTVAL, @SETTINGSTARTNO, @SETTINGENDNO, @NOINCDECWIDTH)";

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)NoMngSetWork;
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
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraNoCode = sqlCommand.Parameters.Add("@NOCODE", SqlDbType.Int);
                    SqlParameter paraNoPresentVal = sqlCommand.Parameters.Add("@NOPRESENTVAL", SqlDbType.BigInt);
                    SqlParameter paraSettingStartNo = sqlCommand.Parameters.Add("@SETTINGSTARTNO", SqlDbType.BigInt);
                    SqlParameter paraSettingEndNo = sqlCommand.Parameters.Add("@SETTINGENDNO", SqlDbType.BigInt);
                    SqlParameter paraNoIncDecWidth = sqlCommand.Parameters.Add("@NOINCDECWIDTH", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(NoMngSetWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(NoMngSetWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(NoMngSetWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(NoMngSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(NoMngSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(NoMngSetWork.SectionCode);
                    paraNoCode.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.NoCode);
                    paraNoPresentVal.Value = SqlDataMediator.SqlSetInt64(NoMngSetWork.NoPresentVal);
                    paraSettingStartNo.Value = SqlDataMediator.SqlSetInt64(NoMngSetWork.SettingStartNo);
                    paraSettingEndNo.Value = SqlDataMediator.SqlSetInt64(NoMngSetWork.SettingEndNo);
                    paraNoIncDecWidth.Value = SqlDataMediator.SqlSetInt32(NoMngSetWork.NoIncDecWidth);

                    sqlCommand.ExecuteNonQuery();

                    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                    paraNoMngSet = XmlByteSerializer.Serialize(NoMngSetWork);

                }

                //Select�R�}���h�̐���
                using( SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, NOELEMENTCODERF FROM NOELMNTMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOELEMENTCODERF=@FINDNOELEMENTCODE",sqlConnection,sqlTransaction))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaNoElementCode = sqlCommand.Parameters.Add("@FINDNOELEMENTCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noelmntmngWork.EnterpriseCode);
                    findParaNoElementCode.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementCode);

                    myReader = sqlCommand.ExecuteReader();
                    if(myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != noelmntmngWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (noelmntmngWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if(!myReader.IsClosed)myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }

                        sqlCommand.CommandText = "UPDATE NOELMNTMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , NOELEMENTCODERF=@NOELEMENTCODE , NOELEMENTYEARRF=@NOELEMENTYEAR , NOELEMENTMONTHRF=@NOELEMENTMONTH WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOELEMENTCODERF=@FINDNOELEMENTCODE";

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noelmntmngWork.EnterpriseCode);
                        findParaNoElementCode.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementCode);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)noelmntmngWork;
                         FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd,obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (noelmntmngWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if(!myReader.IsClosed)myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }

                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = "INSERT INTO NOELMNTMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, NOELEMENTCODERF, NOELEMENTYEARRF, NOELEMENTMONTHRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @NOELEMENTCODE, @NOELEMENTYEAR, @NOELEMENTMONTH)";

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)noelmntmngWork;
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
                    SqlParameter paraNoElementCode = sqlCommand.Parameters.Add("@NOELEMENTCODE", SqlDbType.Int);
                    SqlParameter paraNoElementYear = sqlCommand.Parameters.Add("@NOELEMENTYEAR", SqlDbType.Int);
                    SqlParameter paraNoElementMonth = sqlCommand.Parameters.Add("@NOELEMENTMONTH", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noelmntmngWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noelmntmngWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noelmntmngWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(noelmntmngWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noelmntmngWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noelmntmngWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noelmntmngWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.LogicalDeleteCode);
                    paraNoElementCode.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementCode);
                    paraNoElementYear.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementYear);
                    paraNoElementMonth.Value = SqlDataMediator.SqlSetInt32(noelmntmngWork.NoElementMonth);

                    sqlCommand.ExecuteNonQuery();

                    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                    paraNoElmntMng = XmlByteSerializer.Serialize(noelmntmngWork);

                }

                // �R�~�b�g
                sqlTransaction.Commit();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex) 
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"NoMngSetDB.Write Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(myReader.IsClosed == false)myReader.Close();

                if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���[���o�b�N
                    sqlTransaction.Rollback();
                }
				
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            if(!myReader.IsClosed)myReader.Close();
            sqlConnection.Close();

            return status;
        }
        // 2008.05.28 del end -----------------------------------------------------------<<
		#endregion

	}
}
