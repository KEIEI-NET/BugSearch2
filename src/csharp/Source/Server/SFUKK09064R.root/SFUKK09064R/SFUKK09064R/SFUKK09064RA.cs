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
	/// �����ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 90027�@�����@��</br>
	/// <br>Date       : 2005.07.23</br>
	/// <br></br>
	/// <br>Update Note: 22008 ���� PM.NS�p�ɏC��</br>
	/// </remarks>
	[Serializable]
	public class DepositStDB : RemoteDB , IDepositStDB
	{
//		private string _connectionText;		//�R�l�N�V����������i�[�p

		/// <summary>
		/// �����ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		/// </remarks>
		public DepositStDB() :
		base("SFUKK09066D", "Broadleaf.Application.Remoting.ParamData.DepositStWork", "DEPOSITSTRF") //���N���X�̃R���X�g���N�^
		{
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:DepositStWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status =  SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:DepositStWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			DepositStWork depositstWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();

            try
            {
			try 
			{	
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else										    				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

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
                base.WriteErrorLog(ex,"DepositStDB.SearchCntProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status =  SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retbyte = null;
            try
            {
                status =  SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			DepositStWork depositstWork = new DepositStWork();
			depositstWork = null;

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
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
                if ((readCnt > 0)&&(depositstWork.DepositStMngCd == 0))
                {
					SqlCommand sqlCommandCount;
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else												    		paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value        = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//�����w�薳���̏ꍇ
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
							//Next���[�h�̏ꍇ
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
							SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
							paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
						}
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					//�����w�薳���̏ꍇ
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
							//Next���[�h�̏ꍇ
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
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
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
                        }
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value        = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

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

					DepositStWork wkDepositStWork = new DepositStWork();

					wkDepositStWork.CreateDateTime         = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkDepositStWork.UpdateDateTime         = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkDepositStWork.EnterpriseCode         = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkDepositStWork.FileHeaderGuid         = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkDepositStWork.UpdEmployeeCode        = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkDepositStWork.UpdAssemblyId1         = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkDepositStWork.UpdAssemblyId2         = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkDepositStWork.LogicalDeleteCode      = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    wkDepositStWork.DepositStMngCd         = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                    wkDepositStWork.DepositInitDspNo       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                    wkDepositStWork.InitSelMoneyKindCd     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INITSELMONEYKINDCDRF"));
                    wkDepositStWork.DepositStKindCd1       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                    wkDepositStWork.DepositStKindCd2       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                    wkDepositStWork.DepositStKindCd3       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                    wkDepositStWork.DepositStKindCd4       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                    wkDepositStWork.DepositStKindCd5       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                    wkDepositStWork.DepositStKindCd6       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                    wkDepositStWork.DepositStKindCd7       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                    wkDepositStWork.DepositStKindCd8       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                    wkDepositStWork.DepositStKindCd9       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                    wkDepositStWork.DepositStKindCd10      = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                    wkDepositStWork.AlwcDepoCallMonthsCd   = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));

					al.Add(wkDepositStWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			DepositStWork[] DepositStWorks = (DepositStWork[])al.ToArray(typeof(DepositStWork));
			retbyte = XmlByteSerializer.Serialize(DepositStWorks);


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ��߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			DepositStWork depositstWork = new DepositStWork();

            try
            {
			try 
			{			
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value    = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                    findParaDepositStMngCd.Value    = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

					if(myReader.Read())
					{
						depositstWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						depositstWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						depositstWork.EnterpriseCode       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						depositstWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						depositstWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						depositstWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						depositstWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						depositstWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        depositstWork.DepositStMngCd       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                        depositstWork.DepositInitDspNo     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                        depositstWork.InitSelMoneyKindCd   = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INITSELMONEYKINDCDRF"));
                        depositstWork.DepositStKindCd1     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                        depositstWork.DepositStKindCd2     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                        depositstWork.DepositStKindCd3     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                        depositstWork.DepositStKindCd4     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                        depositstWork.DepositStKindCd5     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                        depositstWork.DepositStKindCd6     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                        depositstWork.DepositStKindCd7     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                        depositstWork.DepositStKindCd8     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                        depositstWork.DepositStKindCd9     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                        depositstWork.DepositStKindCd10    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                        depositstWork.AlwcDepoCallMonthsCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));


						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(depositstWork);


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Read Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// �����ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try 
			{
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				DepositStWork depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, DEPOSITSTMNGCDRF   FROM DEPOSITSTRF   WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value    = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                    findParaDepositStMngCd.Value    = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

					myReader = sqlCommand.ExecuteReader();

					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != depositstWork.UpdateDateTime)
						{
							//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
							if (depositstWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
							else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

						sqlCommand.CommandText = "UPDATE DEPOSITSTRF  SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DEPOSITSTMNGCDRF=@DEPOSITSTMNGCD , DEPOSITINITDSPNORF=@DEPOSITINITDSPNO , INITSELMONEYKINDCDRF=@INITSELMONEYKINDCD , DEPOSITSTKINDCD1RF=@DEPOSITSTKINDCD1 , DEPOSITSTKINDCD2RF=@DEPOSITSTKINDCD2 , DEPOSITSTKINDCD3RF=@DEPOSITSTKINDCD3 , DEPOSITSTKINDCD4RF=@DEPOSITSTKINDCD4 , DEPOSITSTKINDCD5RF=@DEPOSITSTKINDCD5 , DEPOSITSTKINDCD6RF=@DEPOSITSTKINDCD6 , DEPOSITSTKINDCD7RF=@DEPOSITSTKINDCD7 , DEPOSITSTKINDCD8RF=@DEPOSITSTKINDCD8 , DEPOSITSTKINDCD9RF=@DEPOSITSTKINDCD9 , DEPOSITSTKINDCD10RF=@DEPOSITSTKINDCD10 , ALWCDEPOCALLMONTHSCDRF=@ALWCDEPOCALLMONTHSCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD";

						//KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                        findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)depositstWork;
                        FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						if (depositstWork.UpdateDateTime > DateTime.MinValue)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

						//�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = "INSERT INTO DEPOSITSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEPOSITSTMNGCDRF, DEPOSITINITDSPNORF, INITSELMONEYKINDCDRF, DEPOSITSTKINDCD1RF, DEPOSITSTKINDCD2RF, DEPOSITSTKINDCD3RF, DEPOSITSTKINDCD4RF, DEPOSITSTKINDCD5RF, DEPOSITSTKINDCD6RF, DEPOSITSTKINDCD7RF, DEPOSITSTKINDCD8RF, DEPOSITSTKINDCD9RF, DEPOSITSTKINDCD10RF, ALWCDEPOCALLMONTHSCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DEPOSITSTMNGCD, @DEPOSITINITDSPNO, @INITSELMONEYKINDCD, @DEPOSITSTKINDCD1, @DEPOSITSTKINDCD2, @DEPOSITSTKINDCD3, @DEPOSITSTKINDCD4, @DEPOSITSTKINDCD5, @DEPOSITSTKINDCD6, @DEPOSITSTKINDCD7, @DEPOSITSTKINDCD8, @DEPOSITSTKINDCD9, @DEPOSITSTKINDCD10, @ALWCDEPOCALLMONTHSCD)";

						//�o�^�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)depositstWork;
                        FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetInsertHeader(ref flhd,obj);
					}
					if(!myReader.IsClosed)myReader.Close();

                    #region �l�Z�b�g
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter paraCreateDateTime       = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdateDateTime       = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraEnterpriseCode       = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
					SqlParameter paraFileHeaderGuid       = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
					SqlParameter paraUpdEmployeeCode      = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1       = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2       = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					SqlParameter paraLogicalDeleteCode    = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    SqlParameter paraDepositStMngCd       = sqlCommand.Parameters.Add("@DEPOSITSTMNGCD", SqlDbType.Int);
                    SqlParameter paraDepositInitDspNo     = sqlCommand.Parameters.Add("@DEPOSITINITDSPNO", SqlDbType.Int);
                    SqlParameter paraInitSelMoneyKindCd   = sqlCommand.Parameters.Add("@INITSELMONEYKINDCD", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd1     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD1", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd2     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD2", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd3     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD3", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd4     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD4", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd5     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD5", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd6     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD6", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd7     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD7", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd8     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD8", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd9     = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD9", SqlDbType.Int);
                    SqlParameter paraDepositStKindCd10    = sqlCommand.Parameters.Add("@DEPOSITSTKINDCD10", SqlDbType.Int);
                    SqlParameter paraAlwcDepoCallMonthsCd = sqlCommand.Parameters.Add("@ALWCDEPOCALLMONTHSCD", SqlDbType.Int);


                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value       = SqlDataMediator.SqlSetDateTimeFromTicks(depositstWork.CreateDateTime);
                    paraUpdateDateTime.Value       = SqlDataMediator.SqlSetDateTimeFromTicks(depositstWork.UpdateDateTime);
                    paraEnterpriseCode.Value       = SqlDataMediator.SqlSetString(           depositstWork.EnterpriseCode);
                    paraFileHeaderGuid.Value       = SqlDataMediator.SqlSetGuid(             depositstWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value      = SqlDataMediator.SqlSetString(           depositstWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value       = SqlDataMediator.SqlSetString(           depositstWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value       = SqlDataMediator.SqlSetString(           depositstWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value    = SqlDataMediator.SqlSetInt32(            depositstWork.LogicalDeleteCode);

                    paraDepositStMngCd.Value       = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStMngCd);
                    paraDepositInitDspNo.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositInitDspNo);
                    paraInitSelMoneyKindCd.Value   = SqlDataMediator.SqlSetInt32(            depositstWork.InitSelMoneyKindCd);
                    paraDepositStKindCd1.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd1);
                    paraDepositStKindCd2.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd2);
                    paraDepositStKindCd3.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd3);
                    paraDepositStKindCd4.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd4);
                    paraDepositStKindCd5.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd5);
                    paraDepositStKindCd6.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd6);
                    paraDepositStKindCd7.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd7);
                    paraDepositStKindCd8.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd8);
                    paraDepositStKindCd9.Value     = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd9);
                    paraDepositStKindCd10.Value    = SqlDataMediator.SqlSetInt32(            depositstWork.DepositStKindCd10);
                    paraAlwcDepoCallMonthsCd.Value = SqlDataMediator.SqlSetInt32(            depositstWork.AlwcDepoCallMonthsCd);
                    #endregion

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(depositstWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Write Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// �����ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����ݒ����_���폜���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteProc(ref parabyte,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteProc(ref parabyte,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.LogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �_���폜�����ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�����ݒ���𕜊����܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteProc(ref parabyte,1);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteProc(ref parabyte,1);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.RevivalLogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// �����ݒ���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����ݒ���̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try		
			{
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				DepositStWork depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, DEPOSITSTMNGCDRF FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                    findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != depositstWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						//���݂̘_���폜�敪���擾
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

						sqlCommand.CommandText = "UPDATE DEPOSITSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD";
						//KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                        findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)depositstWork;
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
						else if	(logicalDelCd == 0)	depositstWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
						else						depositstWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
					}
					else
					{
						if		(logicalDelCd == 1)	depositstWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
					SqlParameter paraUpdateDateTime    = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdEmployeeCode   = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1    = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2    = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
					paraUpdateDateTime.Value    = SqlDataMediator.SqlSetDateTimeFromTicks(depositstWork.UpdateDateTime);
					paraUpdEmployeeCode.Value   = SqlDataMediator.SqlSetString(depositstWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value    = SqlDataMediator.SqlSetString(depositstWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value    = SqlDataMediator.SqlSetString(depositstWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositstWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(depositstWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.LogicalDeleteProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// �����ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">�����ݒ�I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : �����ݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			try 
			{
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				// XML�̓ǂݍ���
				DepositStWork depositstWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepositStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, DEPOSITSTMNGCDRF FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                    findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
						if (_updateDateTime != depositstWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

						sqlCommand.CommandText = "DELETE FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD";
						//KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);
                        findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
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

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Delete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}



		#region �J�X�^���V���A���C�Y

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
//			return SearchProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retobj = null;
            try
            {
                status =  SearchProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraobj">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int SearchSpecification(out object retobj,out int retTotalCnt,out bool nextData,object paraobj,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
//			return SearchProc(out retobj,out retTotalCnt,out nextData,paraobj, readMode,logicalMode,readCnt);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retobj = null;
            try
            {
                status =  SearchProc(out retobj,out retTotalCnt,out nextData,paraobj, readMode,logicalMode,readCnt);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		private int SearchProc(out object retobj,out int retTotalCnt,out bool nextData,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			DepositStWork depositstWork = new DepositStWork();
			depositstWork = null;

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
			try 
			{	
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				depositstWork = paraobj as DepositStWork;

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
                if ((readCnt > 0)&&(depositstWork.DepositStMngCd == 0))
				{
					SqlCommand sqlCommandCount;
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else												    		paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
						sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value        = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//�����w�薳���̏ꍇ
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
							//Next���[�h�̏ꍇ
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

						}
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					//�����w�薳���̏ꍇ
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
							//Next���[�h�̏ꍇ
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);
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
						sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
                        if (depositstWork.DepositStMngCd == 0)
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
						}
						else
						{
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF>@FINDDEPOSITSTMNGCD ORDER BY DEPOSITSTMNGCDRF",sqlConnection);
                            SqlParameter paraDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);
                            paraDepositStMngCd.Value        = SqlDataMediator.SqlSetInt32(depositstWork.DepositStMngCd);

						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value        = SqlDataMediator.SqlSetString(depositstWork.EnterpriseCode);

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
					DepositStWork wkDepositStWork = new DepositStWork();

					wkDepositStWork.CreateDateTime             = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkDepositStWork.UpdateDateTime             = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkDepositStWork.EnterpriseCode             = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkDepositStWork.FileHeaderGuid             = SqlDataMediator.SqlGetGuid(             myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkDepositStWork.UpdEmployeeCode            = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkDepositStWork.UpdAssemblyId1             = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkDepositStWork.UpdAssemblyId2             = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkDepositStWork.LogicalDeleteCode          = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    wkDepositStWork.DepositStMngCd             = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                    wkDepositStWork.DepositInitDspNo           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                    wkDepositStWork.InitSelMoneyKindCd         = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("INITSELMONEYKINDCDRF"));
                    wkDepositStWork.DepositStKindCd1           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                    wkDepositStWork.DepositStKindCd2           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                    wkDepositStWork.DepositStKindCd3           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                    wkDepositStWork.DepositStKindCd4           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                    wkDepositStWork.DepositStKindCd5           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                    wkDepositStWork.DepositStKindCd6           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                    wkDepositStWork.DepositStKindCd7           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                    wkDepositStWork.DepositStKindCd8           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                    wkDepositStWork.DepositStKindCd9           = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                    wkDepositStWork.DepositStKindCd10          = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                    wkDepositStWork.AlwcDepoCallMonthsCd       = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));

					al.Add(wkDepositStWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			retobj = al;


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.SearchProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ��߂��܂�
		/// </summary>
		/// <param name="depositStWork">DepositStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ��߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int Read(ref object depositStWork, int readMode)
		{
			DepositStWork wkDepositStWork = depositStWork as DepositStWork;
			if(wkDepositStWork == null)return (int)ConstantManagement.DB_Status.ctDB_ERROR;
//			return ReadDepositStWork(readMode , 0 , wkDepositStWork.EnterpriseCode , wkDepositStWork.DepositStMngCd , out depositStWork);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  ReadDepositStWork(readMode , 0 , wkDepositStWork.EnterpriseCode , wkDepositStWork.DepositStMngCd , out depositStWork);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.Read Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }	

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ��߂��܂�
		/// </summary>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="depositStMngCd">�����ݒ�Ǘ��R�[�h</param>
		/// <param name="depositStWork">�擾�f�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ��߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		public int ReadDepositStWork(int readMode, ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int depositStMngCd, out object depositStWork)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			DepositStWork wkdepositStWork = new DepositStWork();

            depositStWork = null;

            try
            {
			try 
			{			
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
				using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DEPOSITSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSTMNGCDRF=@FINDDEPOSITSTMNGCD", sqlConnection))
				{
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositStMngCd = sqlCommand.Parameters.Add("@FINDDEPOSITSTMNGCD", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaDepositStMngCd.Value = SqlDataMediator.SqlSetInt32(depositStMngCd);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					if(myReader.Read())
					{
						wkdepositStWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkdepositStWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkdepositStWork.EnterpriseCode       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkdepositStWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkdepositStWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkdepositStWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkdepositStWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkdepositStWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        wkdepositStWork.DepositStMngCd       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                        wkdepositStWork.DepositInitDspNo     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                        wkdepositStWork.InitSelMoneyKindCd   = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INITSELMONEYKINDCDRF"));
                        wkdepositStWork.DepositStKindCd1     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                        wkdepositStWork.DepositStKindCd2     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                        wkdepositStWork.DepositStKindCd3     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                        wkdepositStWork.DepositStKindCd4     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                        wkdepositStWork.DepositStKindCd5     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                        wkdepositStWork.DepositStKindCd6     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                        wkdepositStWork.DepositStKindCd7     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                        wkdepositStWork.DepositStKindCd8     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                        wkdepositStWork.DepositStKindCd9     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                        wkdepositStWork.DepositStKindCd10    = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                        wkdepositStWork.AlwcDepoCallMonthsCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(!myReader.IsClosed)myReader.Close();
			sqlConnection.Close();

			depositStWork = wkdepositStWork;


            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositStDB.ReadDepositStWork Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		#endregion


	}

}
