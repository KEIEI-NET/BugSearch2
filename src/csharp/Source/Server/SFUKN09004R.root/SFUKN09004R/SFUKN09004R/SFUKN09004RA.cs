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
	/// ���Џ��ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Џ��ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
    /// <br></br>
    /// <br>Update Note: ���В��X�P�W���[���Ǘ��}�X�^�̎��В����ύX�����[�g�͎g�p���Ȃ��iSFUKK06184R�j</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.05.18</br>
    /// <br></br>
    /// <br>Update Note: ��v�N�x�E����N�����E�J�n�N�敪�E�I���N�敪��ǉ�</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.09.26</br>
    /// <br></br>
    /// <br>Update Note: �����Ǘ��敪��ǉ�</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2008.01.10</br>
    /// <br>Update Note: PM.NS�p�ɕύX</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.05.20</br>
    /// <br>UpdateNote : �A�� 42 zhouyu 
    /// <br>             2011/07/12 �����X�V�ŁA�Â��f�[�^���폜s�̑Ή�</br>
    /// <br>Update Note: �f�[�^�N���A���ԏ����ǉ�</br>
    /// <br>Programmer : LDNS wangqx</br>
    /// <br>Date       : 2011.07.14</br>
    /// <br></br>
    /// </remarks>
	[Serializable]
	public class CompanyInfDB : RemoteDB, IRemoteDB, ICompanyInfDB
	{
		/// <summary>
		/// ���Џ��ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public CompanyInfDB() :
		base("SFUKN09006D", "Broadleaf.Application.Remoting.ParamData.CompanyInfWork", "COMPANYINFRF")
		{
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:CompanyInfWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ�LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
//			return SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status =  SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"CompanyInfDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:CompanyInfWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ�LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			CompanyInfWork companyinfWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();

			try 
			{	
				// XML�̓ǂݍ���
				companyinfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));

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

                string sqlTxt = string.Empty; // 2008.05.20 add 

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.20 upd start --------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);

                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM COMPANYINFRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.20 upd end -----------------------------------------------<<
                    
                    //�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.20 upd start ------------------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);

                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM COMPANYINFRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.20 upd end ---------------------------------------------------------<<
                    
                    //�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else										    				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
                    // 2008.05.20 upd start ------------------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);

                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM COMPANYINFRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.20 upd end ---------------------------------------------------------<<
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);

				//�f�[�^���[�h
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"CompanyInfDB.SearchCntProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            sqlConnection.Close();			

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
//			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status =  SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"CompanyInfDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
//			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
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
                base.WriteErrorLog(ex,"CompanyInfDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			CompanyInfWork companyinfWork = new CompanyInfWork();
			companyinfWork = null;

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
				// XML�̓ǂݍ���
				companyinfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));

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

                string sqlTxt = string.Empty; // 2008.05.20 add

				//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
				if ((readCnt > 0)&&(companyinfWork.CompanyCode == 0))
				{
					SqlCommand sqlCommandCount;
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.20 upd start ------------------------------------------------->>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);

                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM COMPANYINFRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.20 upd end ---------------------------------------------------<<
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.20 upd start ------------------------------------------------->>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);

                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM COMPANYINFRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
						// 2008.05.20 upd end ---------------------------------------------------<<
                        //�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else					    									paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
                        // 2008.05.20 upd start ------------------------------------------------->>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);

                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM COMPANYINFRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.20 upd end ---------------------------------------------------<<
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

		//		SqlCommand sqlCommand;

                sqlTxt = string.Empty; // 2008.05.20 add

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//�����w�薳���̏ꍇ
					if (readCnt == 0)
					{
                        // 2008.05.20 upd start -------------------------------------------------->>
						//sqlCommand = new SqlCommand("SELECT * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY COMPANYCODERF",sqlConnection);

                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                        sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                        sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                        sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                        //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                        sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                        //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                        sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.20 upd end ----------------------------------------------------<<					
                    }
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if ((companyinfWork.CompanyCode == 0))
						{
                            // 2008.05.20 upd start ---------------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY COMPANYCODERF",sqlConnection);

                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                            sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                            sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                            sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                            //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                            sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                            //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                            sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.20 upd end ------------------------------------------------<<						
                        }
						//Next���[�h�̏ꍇ
						else
						{
                            // 2008.05.20 upd start ---------------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM COMPANYINFRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND COMPANYCODERF>@FINDCOMPANYCODE ORDER BY COMPANYCODERF",sqlConnection);

                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                            sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                            sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                            sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                            //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                            sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                            //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                            sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND COMPANYCODERF>@FINDCOMPANYCODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.20 upd end ------------------------------------------------<<
                            SqlParameter paraCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);
							paraCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);
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
                        // 2008.05.20 upd start -------------------------------------------------->>
						//sqlCommand = new SqlCommand("SELECT * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY COMPANYCODERF",sqlConnection);

                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                        sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                        sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                        sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                        //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                        sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                        //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                        sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.20 upd end ----------------------------------------------------<<					
                    }
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if ((companyinfWork.CompanyCode == 0))
						{
                            // 2008.05.20 upd start ---------------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY COMPANYCODERF",sqlConnection);

                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                            sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                            sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                            sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                            //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                            sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                            //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                            sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.20 upd end ------------------------------------------------<<
                        }
						//Next���[�h�̏ꍇ
						else
						{
                            // 2008.05.20 upd start ---------------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM COMPANYINFRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND COMPANYCODERF>@FINDCOMPANYCODE ORDER BY COMPANYCODERF",sqlConnection);

                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                            sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                            sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                            sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                            //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                            sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                            //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                            sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND COMPANYCODERF>@FINDCOMPANYCODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.20 upd end ------------------------------------------------<<
                            SqlParameter paraCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);
							paraCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);
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
                        // 2008.05.20 upd start -------------------------------------------------->>
						//sqlCommand = new SqlCommand("SELECT * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY COMPANYCODERF",sqlConnection);

                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                        sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                        sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                        sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                        //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                        sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                        //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                        sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.20 upd end ----------------------------------------------------<<
                    }
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if ((companyinfWork.CompanyCode == 0))
						{
                            // 2008.05.20 upd start ---------------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY COMPANYCODERF",sqlConnection);

                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                            sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                            sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                            sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                            //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                            sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                            //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                            sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.20 upd end ------------------------------------------------<<						
                        }
						else
						{
                            // 2008.05.20 upd start ---------------------------------------------->>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF>@FINDCOMPANYCODE ORDER BY COMPANYCODERF",sqlConnection);

                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                            sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                            sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                            sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                            sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                            //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                            sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                            sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                            sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                            //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                            sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND COMPANYCODERF>@FINDCOMPANYCODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.20 upd end ------------------------------------------------<<
                            SqlParameter paraCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);
							paraCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);
						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);

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
					CompanyInfWork wkCompanyInfWork = new CompanyInfWork();

                    wkCompanyInfWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkCompanyInfWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkCompanyInfWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkCompanyInfWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkCompanyInfWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkCompanyInfWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkCompanyInfWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkCompanyInfWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkCompanyInfWork.CompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYCODERF"));
                    wkCompanyInfWork.CompanyTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYTOTALDAYRF"));
                    wkCompanyInfWork.CompanyBiginMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTHRF"));
                    wkCompanyInfWork.CompanyBiginMonth2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTH2RF"));
                    wkCompanyInfWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                    wkCompanyInfWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                    // �� 2007.09.14 980081 a
                    wkCompanyInfWork.FinancialYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FINANCIALYEARRF"));
                    wkCompanyInfWork.CompanyBiginDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINDATERF"));
                    wkCompanyInfWork.StartYearDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTYEARDIVRF"));
                    wkCompanyInfWork.StartMonthDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTMONTHDIVRF"));
                    // �� 2007.09.14 980081 a
                    // �� 2008.01.10 980081 a
                    wkCompanyInfWork.SecMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGDIVRF"));
                    // �� 2008.01.10 980081 a
                    wkCompanyInfWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                    wkCompanyInfWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                    //wkCompanyInfWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF"));
                    wkCompanyInfWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                    wkCompanyInfWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                    wkCompanyInfWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
                    wkCompanyInfWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
                    wkCompanyInfWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
                    wkCompanyInfWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
                    wkCompanyInfWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
                    wkCompanyInfWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
                    //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                    wkCompanyInfWork.DataSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATASAVEMONTHSRF"));
                    wkCompanyInfWork.DataCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACOMPRESSDTRF"));
                    wkCompanyInfWork.ResultDtSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RESULTDTSAVEMONTHSRF"));
                    wkCompanyInfWork.ResultDtCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RESULTDTCOMPRESSDTRF"));
                    wkCompanyInfWork.CaPrtsDtSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAPRTSDTSAVEMONTHSRF"));
                    wkCompanyInfWork.CaPrtsDtCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAPRTSDTCOMPRESSDTRF"));
                    wkCompanyInfWork.MasterSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTERSAVEMONTHSRF"));
                    wkCompanyInfWork.MasterCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTERCOMPRESSDTRF"));
                    wkCompanyInfWork.RatePriorityDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEPRIORITYDIVRF"));
                    //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<

					al.Add(wkCompanyInfWork);

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
                base.WriteErrorLog(ex,"CompanyInfDB.SearchProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if(sqlCommand != null)sqlCommand.Dispose();
                if(!myReader.IsClosed)myReader.Close();
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

			// XML�֕ϊ����A������̃o�C�i����
			CompanyInfWork[] CompanyInfWorks = (CompanyInfWork[])al.ToArray(typeof(CompanyInfWork));
			retbyte = XmlByteSerializer.Serialize(CompanyInfWorks);

			return status;
		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retList">��������</param>
		/// <param name="companyinfWork">�����p�����[�^</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2006.02.07</br>
		public int Search(out ArrayList retList, CompanyInfWork companyinfWork, ref SqlConnection sqlConnection)
        {
            return this.SearchProc(out retList, companyinfWork, ref sqlConnection);
        }

        private int SearchProc(out ArrayList retList, CompanyInfWork companyinfWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			retList = null;

			ArrayList al = new ArrayList();
			try 
			{	
                // 2008.05.20 upd start --------------------------------------->>
				//sqlCommand = new SqlCommand("SELECT * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY COMPANYCODERF",sqlConnection);

                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += " ORDER BY COMPANYCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.20 upd end -----------------------------------------<<
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader();
				while(myReader.Read())
				{
					CompanyInfWork wkCompanyInfWork = new CompanyInfWork();

                    wkCompanyInfWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkCompanyInfWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkCompanyInfWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkCompanyInfWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkCompanyInfWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkCompanyInfWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkCompanyInfWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkCompanyInfWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkCompanyInfWork.CompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYCODERF"));
                    wkCompanyInfWork.CompanyTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYTOTALDAYRF"));
                    wkCompanyInfWork.CompanyBiginMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTHRF"));
                    wkCompanyInfWork.CompanyBiginMonth2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTH2RF"));
                    wkCompanyInfWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                    wkCompanyInfWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                    // �� 2007.09.14 980081 a
                    wkCompanyInfWork.FinancialYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FINANCIALYEARRF"));
                    wkCompanyInfWork.CompanyBiginDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINDATERF"));
                    wkCompanyInfWork.StartYearDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTYEARDIVRF"));
                    wkCompanyInfWork.StartMonthDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTMONTHDIVRF"));
                    // �� 2007.09.14 980081 a
                    // �� 2008.01.10 980081 a
                    wkCompanyInfWork.SecMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGDIVRF"));
                    // �� 2008.01.10 980081 a
                    wkCompanyInfWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                    wkCompanyInfWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                    //wkCompanyInfWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF"));
                    wkCompanyInfWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                    wkCompanyInfWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                    wkCompanyInfWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
                    wkCompanyInfWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
                    wkCompanyInfWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
                    wkCompanyInfWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
                    wkCompanyInfWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
                    wkCompanyInfWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
                    //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                    wkCompanyInfWork.DataSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATASAVEMONTHSRF"));
                    wkCompanyInfWork.DataCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACOMPRESSDTRF"));
                    wkCompanyInfWork.ResultDtSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RESULTDTSAVEMONTHSRF"));
                    wkCompanyInfWork.ResultDtCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RESULTDTCOMPRESSDTRF"));
                    wkCompanyInfWork.CaPrtsDtSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAPRTSDTSAVEMONTHSRF"));
                    wkCompanyInfWork.CaPrtsDtCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAPRTSDTCOMPRESSDTRF"));
                    wkCompanyInfWork.MasterSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTERSAVEMONTHSRF"));
                    wkCompanyInfWork.MasterCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTERCOMPRESSDTRF"));
                    wkCompanyInfWork.RatePriorityDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEPRIORITYDIVRF"));
                    //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<


					al.Add(wkCompanyInfWork);

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
				base.WriteErrorLog(ex,"CompanyInfDB.SearchProc Exception="+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}

			retList = al;
			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
            CompanyInfWork companyinfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte, typeof(CompanyInfWork));

            int status = this.ReadProc(ref companyinfWork, readMode);

            // XML�֕ϊ����A������̃o�C�i����
            parabyte = XmlByteSerializer.Serialize(companyinfWork);

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        public int Read(ref object paraobj, int readMode)
        {
            CompanyInfWork paraWork = paraobj as CompanyInfWork;

            return this.ReadProc(ref paraWork, readMode);
        }

        private int ReadProc(ref CompanyInfWork companyinfWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

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
                // 2008.05.20 upd start --------------------------------------------------------->>
				//sqlCommand = new SqlCommand("SELECT * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE", sqlConnection);

                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.20 upd end -----------------------------------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);
				findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
                    companyinfWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    companyinfWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    companyinfWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    companyinfWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    companyinfWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    companyinfWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    companyinfWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    companyinfWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    companyinfWork.CompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYCODERF"));
                    companyinfWork.CompanyTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYTOTALDAYRF"));
                    companyinfWork.CompanyBiginMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTHRF"));
                    companyinfWork.CompanyBiginMonth2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTH2RF"));
                    companyinfWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                    companyinfWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                    // �� 2007.09.14 980081 a
                    companyinfWork.FinancialYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FINANCIALYEARRF"));
                    companyinfWork.CompanyBiginDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINDATERF"));
                    companyinfWork.StartYearDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTYEARDIVRF"));
                    companyinfWork.StartMonthDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTMONTHDIVRF"));
                    // �� 2007.09.14 980081 a
                    // �� 2008.01.10 980081 a
                    companyinfWork.SecMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGDIVRF"));
                    // �� 2008.01.10 980081 a
                    companyinfWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                    companyinfWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                    //companyinfWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF"));
                    companyinfWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                    companyinfWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                    companyinfWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
                    companyinfWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
                    companyinfWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
                    companyinfWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
                    companyinfWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
                    companyinfWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
                    //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                    companyinfWork.DataSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATASAVEMONTHSRF"));
                    companyinfWork.DataCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACOMPRESSDTRF"));
                    companyinfWork.ResultDtSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RESULTDTSAVEMONTHSRF"));
                    companyinfWork.ResultDtCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RESULTDTCOMPRESSDTRF"));
                    companyinfWork.CaPrtsDtSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAPRTSDTSAVEMONTHSRF"));
                    companyinfWork.CaPrtsDtCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAPRTSDTCOMPRESSDTRF"));
                    companyinfWork.MasterSaveMonths = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTERSAVEMONTHSRF"));
                    companyinfWork.MasterCompressDt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTERCOMPRESSDTRF"));
                    companyinfWork.RatePriorityDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEPRIORITYDIVRF"));
                    //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<

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
                base.WriteErrorLog(ex,"SectionInfo.SearchSecInfoSetProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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

		/// <summary>
		/// ���Џ��ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Џ��ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Write(ref byte[] parabyte)
		{
            return this.WriteProc(ref parabyte);
        }
        private int WriteProc(ref byte[] parabyte)
        {


			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlTransaction sqlTransaction = null;
			ControlExclusiveOrderAccess _ControlExclusiveOrderAccess = null;

			int beforTotalDay = 0;
			//bool totalDayChgflg;


			try
			{
				try 
				{
					// XML�̓ǂݍ���
					CompanyInfWork companyinfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));
	
					//�`�[�r������
					_ControlExclusiveOrderAccess = new ControlExclusiveOrderAccess();
					// DEL 2008.10.27 >>>
                    //status = _ControlExclusiveOrderAccess.LockAllDB(companyinfWork.EnterpriseCode);
					//if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)return status;
                    // DEL 2008.10.27 <<<

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
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

					//Select�R�}���h�̐���
                    // 2008.05.20 upd start ---------------------------------------------------->>
                    //SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, COMPANYCODERF, COMPANYTOTALDAYRF, COMPANYBIGINMONTHRF,COMPANYBIGINMONTH2RF FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE", sqlConnection, sqlTransaction);

                    string sqlTxt = string.Empty;

                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                    sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODE" + Environment.NewLine;

                    SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    // 2008.05.20 upd end ------------------------------------------------------<<

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);
					findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);

   					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						beforTotalDay = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("COMPANYTOTALDAYRF"));
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != companyinfWork.UpdateDateTime)
						{
							//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
							if (companyinfWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
							else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
                        // del 2007.05.16 Saitoh >>>>>>>>>>
                        //sqlCommand.CommandText = "UPDATE COMPANYINFRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMPANYCODERF=@COMPANYCODE , COMPANYTOTALDAYRF=@COMPANYTOTALDAY , COMPANYBIGINMONTHRF=@COMPANYBIGINMONTH ,COMPANYBIGINMONTH2RF=@COMPANYBIGINMONTH2 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE";
                        // del 2007.05.16 Saitoh <<<<<<<<<<

                        // �� 2008.01.10 980081 c
                        //// �� 2007.09.14 980081 c
                        ////// add 2007.05.16 Saitoh >>>>>>>>>>
                        ////sqlCommand.CommandText = "UPDATE COMPANYINFRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMPANYCODERF=@COMPANYCODE , COMPANYTOTALDAYRF=@COMPANYTOTALDAY , COMPANYBIGINMONTHRF=@COMPANYBIGINMONTH , COMPANYBIGINMONTH2RF=@COMPANYBIGINMONTH2 , COMPANYNAME1RF=@COMPANYNAME1 , COMPANYNAME2RF=@COMPANYNAME2 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE";
                        ////// add 2007.05.16 Saitoh <<<<<<<<<<
                        //sqlCommand.CommandText = "UPDATE COMPANYINFRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMPANYCODERF=@COMPANYCODE , COMPANYTOTALDAYRF=@COMPANYTOTALDAY , COMPANYBIGINMONTHRF=@COMPANYBIGINMONTH , COMPANYBIGINMONTH2RF=@COMPANYBIGINMONTH2 , COMPANYNAME1RF=@COMPANYNAME1 , COMPANYNAME2RF=@COMPANYNAME2 , FINANCIALYEARRF=@FINANCIALYEAR , COMPANYBIGINDATERF=@COMPANYBIGINDATE , STARTYEARDIVRF=@STARTYEARDIV , STARTMONTHDIVRF=@STARTMONTHDIV  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE";
                        //// �� 2007.09.14 980081 c
                        // 2008.05.20 upd start ----------------------------------------------->>
                        //sqlCommand.CommandText = "UPDATE COMPANYINFRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMPANYCODERF=@COMPANYCODE , COMPANYTOTALDAYRF=@COMPANYTOTALDAY , COMPANYBIGINMONTHRF=@COMPANYBIGINMONTH , COMPANYBIGINMONTH2RF=@COMPANYBIGINMONTH2 , SECMNGDIVRF=@SECMNGDIV , COMPANYNAME1RF=@COMPANYNAME1 , COMPANYNAME2RF=@COMPANYNAME2 , FINANCIALYEARRF=@FINANCIALYEAR , COMPANYBIGINDATERF=@COMPANYBIGINDATE , STARTYEARDIVRF=@STARTYEARDIV , STARTMONTHDIVRF=@STARTMONTHDIV  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE";
                        sqlTxt = string.Empty;
                        sqlTxt += "UPDATE COMPANYINFRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , COMPANYCODERF=@COMPANYCODE" + Environment.NewLine;
                        sqlTxt += " , COMPANYTOTALDAYRF=@COMPANYTOTALDAY" + Environment.NewLine;
                        sqlTxt += " , FINANCIALYEARRF=@FINANCIALYEAR" + Environment.NewLine;
                        sqlTxt += " , COMPANYBIGINMONTHRF=@COMPANYBIGINMONTH" + Environment.NewLine;
                        sqlTxt += " , COMPANYBIGINMONTH2RF=@COMPANYBIGINMONTH2" + Environment.NewLine;
                        sqlTxt += " , COMPANYBIGINDATERF=@COMPANYBIGINDATE" + Environment.NewLine;
                        sqlTxt += " , STARTYEARDIVRF=@STARTYEARDIV" + Environment.NewLine;
                        sqlTxt += " , STARTMONTHDIVRF=@STARTMONTHDIV" + Environment.NewLine;
                        sqlTxt += " , COMPANYNAME1RF=@COMPANYNAME1" + Environment.NewLine;
                        sqlTxt += " , COMPANYNAME2RF=@COMPANYNAME2" + Environment.NewLine;
                        sqlTxt += " , POSTNORF=@POSTNO" + Environment.NewLine;
                        sqlTxt += " , ADDRESS1RF=@ADDRESS1" + Environment.NewLine;
                        sqlTxt += " , ADDRESS3RF=@ADDRESS3" + Environment.NewLine;
                        sqlTxt += " , ADDRESS4RF=@ADDRESS4" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELNO1RF=@COMPANYTELNO1" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELNO2RF=@COMPANYTELNO2" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELNO3RF=@COMPANYTELNO3" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELTITLE1RF=@COMPANYTELTITLE1" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELTITLE2RF=@COMPANYTELTITLE2" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELTITLE3RF=@COMPANYTELTITLE3" + Environment.NewLine;
                        sqlTxt += " , SECMNGDIVRF=@SECMNGDIV" + Environment.NewLine;
                        //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                        sqlTxt += " , DATASAVEMONTHSRF=@DATASAVEMONTHS" + Environment.NewLine;
                        sqlTxt += " , DATACOMPRESSDTRF=@DATACOMPRESSDT" + Environment.NewLine;
                        sqlTxt += " , RESULTDTSAVEMONTHSRF=@RESULTDTSAVEMONTHS" + Environment.NewLine;
                        sqlTxt += " , RESULTDTCOMPRESSDTRF=@RESULTDTCOMPRESSDT" + Environment.NewLine;
                        sqlTxt += " , CAPRTSDTSAVEMONTHSRF=@CAPRTSDTSAVEMONTHS" + Environment.NewLine;
                        sqlTxt += " , CAPRTSDTCOMPRESSDTRF=@CAPRTSDTCOMPRESSDT" + Environment.NewLine;
                        sqlTxt += " , MASTERSAVEMONTHSRF=@MASTERSAVEMONTHS" + Environment.NewLine;
                        sqlTxt += " , MASTERCOMPRESSDTRF=@MASTERCOMPRESSDT" + Environment.NewLine;
                        sqlTxt += " , RATEPRIORITYDIVRF=@RATEPRIORITYDIV" + Environment.NewLine;
                        //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.20 upd end -------------------------------------------------<<
                        // �� 2008.01.10 980081 c

						//KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);
						findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)companyinfWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
						if (companyinfWork.UpdateDateTime > DateTime.MinValue)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
                        
						//�V�K�쐬����SQL���𐶐�
                        // del 2007.05.16 Saitoh >>>>>>>>>>
                        //sqlCommand.CommandText = "INSERT INTO COMPANYINFRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYCODERF, COMPANYTOTALDAYRF, COMPANYBIGINMONTHRF,COMPANYBIGINMONTH2RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYCODE, @COMPANYTOTALDAY, @COMPANYBIGINMONTH, @COMPANYBIGINMONTH2)";
                        // del 2007.05.16 Saitoh <<<<<<<<<<

                        // �� 2008.01.10 980081 c
                        //// �� 2007.09.14 980081 a
                        ////// add 2007.05.16 Saitoh >>>>>>>>>>
                        ////sqlCommand.CommandText = "INSERT INTO COMPANYINFRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYCODERF, COMPANYTOTALDAYRF, COMPANYBIGINMONTHRF, COMPANYBIGINMONTH2RF, COMPANYNAME1RF, COMPANYNAME2RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYCODE, @COMPANYTOTALDAY, @COMPANYBIGINMONTH, @COMPANYBIGINMONTH2, @COMPANYNAME1, @COMPANYNAME2)";
                        ////// add 2007.05.16 Saitoh <<<<<<<<<<
                        //sqlCommand.CommandText = "INSERT INTO COMPANYINFRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYCODERF, COMPANYTOTALDAYRF, COMPANYBIGINMONTHRF, COMPANYBIGINMONTH2RF, COMPANYNAME1RF, COMPANYNAME2RF, FINANCIALYEARRF, COMPANYBIGINDATERF, STARTYEARDIVRF, STARTMONTHDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYCODE, @COMPANYTOTALDAY, @COMPANYBIGINMONTH, @COMPANYBIGINMONTH2, @COMPANYNAME1, @COMPANYNAME2, @FINANCIALYEAR, @COMPANYBIGINDATE, @STARTYEARDIV, @STARTMONTHDIV)";
                        //// �� 2007.09.14 980081 a
                        // 2008.05.20 upd start ---------------------------------------------------------->>
                        //sqlCommand.CommandText = "INSERT INTO COMPANYINFRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYCODERF, COMPANYTOTALDAYRF, COMPANYBIGINMONTHRF, COMPANYBIGINMONTH2RF, SECMNGDIVRF, COMPANYNAME1RF, COMPANYNAME2RF, FINANCIALYEARRF, COMPANYBIGINDATERF, STARTYEARDIVRF, STARTMONTHDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYCODE, @COMPANYTOTALDAY, @COMPANYBIGINMONTH, @COMPANYBIGINMONTH2, @SECMNGDIV, @COMPANYNAME1, @COMPANYNAME2, @FINANCIALYEAR, @COMPANYBIGINDATE, @STARTYEARDIV, @STARTMONTHDIV)";
                        sqlTxt = string.Empty;
                        sqlTxt += "INSERT INTO COMPANYINFRF" + Environment.NewLine;
                        sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                        sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                        sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                        sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                        //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                        sqlTxt += "    ,DATASAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,DATACOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,RESULTDTSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,RESULTDTCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,CAPRTSDTSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,CAPRTSDTCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,MASTERSAVEMONTHSRF" + Environment.NewLine;
                        sqlTxt += "    ,MASTERCOMPRESSDTRF" + Environment.NewLine;
                        sqlTxt += "    ,RATEPRIORITYDIVRF" + Environment.NewLine;
                        //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
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
                        sqlTxt += "    ,@COMPANYCODE" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTOTALDAY" + Environment.NewLine;
                        sqlTxt += "    ,@FINANCIALYEAR" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYBIGINMONTH" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYBIGINMONTH2" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYBIGINDATE" + Environment.NewLine;
                        sqlTxt += "    ,@STARTYEARDIV" + Environment.NewLine;
                        sqlTxt += "    ,@STARTMONTHDIV" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYNAME1" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYNAME2" + Environment.NewLine;
                        sqlTxt += "    ,@POSTNO" + Environment.NewLine;
                        sqlTxt += "    ,@ADDRESS1" + Environment.NewLine;
                        sqlTxt += "    ,@ADDRESS3" + Environment.NewLine;
                        sqlTxt += "    ,@ADDRESS4" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELNO1" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELNO2" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELNO3" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELTITLE1" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELTITLE2" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELTITLE3" + Environment.NewLine;
                        sqlTxt += "    ,@SECMNGDIV" + Environment.NewLine;
                        //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                        sqlTxt += "    ,@DATASAVEMONTHS" + Environment.NewLine;
                        sqlTxt += "    ,@DATACOMPRESSDT" + Environment.NewLine;
                        sqlTxt += "    ,@RESULTDTSAVEMONTHS" + Environment.NewLine;
                        sqlTxt += "    ,@RESULTDTCOMPRESSDT" + Environment.NewLine;
                        sqlTxt += "    ,@CAPRTSDTSAVEMONTHS" + Environment.NewLine;
                        sqlTxt += "    ,@CAPRTSDTCOMPRESSDT" + Environment.NewLine;
                        sqlTxt += "    ,@MASTERSAVEMONTHS" + Environment.NewLine;
                        sqlTxt += "    ,@MASTERCOMPRESSDT" + Environment.NewLine;
                        sqlTxt += "    ,@RATEPRIORITYDIV" + Environment.NewLine;
                        //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                        sqlTxt += " )" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.20 upd end ------------------------------------------------------------<<
                        // �� 2008.01.10 980081 c

						//�o�^�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)companyinfWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetInsertHeader(ref flhd,obj);
					}
					if(!myReader.IsClosed)myReader.Close();

                    #region �l�Z�b�g
                    
					//Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraCompanyCode = sqlCommand.Parameters.Add("@COMPANYCODE", SqlDbType.Int);
                    SqlParameter paraCompanyTotalDay = sqlCommand.Parameters.Add("@COMPANYTOTALDAY", SqlDbType.Int);
                    SqlParameter paraCompanyBiginMonth = sqlCommand.Parameters.Add("@COMPANYBIGINMONTH", SqlDbType.Int);
                    SqlParameter paraCompanyBiginMonth2 = sqlCommand.Parameters.Add("@COMPANYBIGINMONTH2", SqlDbType.Int);
                    SqlParameter paraCompanyName1 = sqlCommand.Parameters.Add("@COMPANYNAME1", SqlDbType.NVarChar);
                    SqlParameter paraCompanyName2 = sqlCommand.Parameters.Add("@COMPANYNAME2", SqlDbType.NVarChar);
                    // �� 2007.09.14 980081
                    SqlParameter paraFinancialYear = sqlCommand.Parameters.Add("@FINANCIALYEAR", SqlDbType.Int);
                    SqlParameter paraCompanyBiginDate = sqlCommand.Parameters.Add("@COMPANYBIGINDATE", SqlDbType.Int);
                    SqlParameter paraStartYearDiv = sqlCommand.Parameters.Add("@STARTYEARDIV", SqlDbType.Int);
                    SqlParameter paraStartMonthDiv = sqlCommand.Parameters.Add("@STARTMONTHDIV", SqlDbType.Int);
                    // �� 2007.09.14 980081
                    // �� 2008.01.10 980081 a
                    SqlParameter paraSecMngDiv = sqlCommand.Parameters.Add("@SECMNGDIV", SqlDbType.Int);
                    // �� 2008.01.10 980081 a
                    SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                    SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                    //SqlParameter paraAddress2 = sqlCommand.Parameters.Add("@ADDRESS2", SqlDbType.Int);
                    SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                    SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelNo1 = sqlCommand.Parameters.Add("@COMPANYTELNO1", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelNo2 = sqlCommand.Parameters.Add("@COMPANYTELNO2", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelNo3 = sqlCommand.Parameters.Add("@COMPANYTELNO3", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelTitle1 = sqlCommand.Parameters.Add("@COMPANYTELTITLE1", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelTitle2 = sqlCommand.Parameters.Add("@COMPANYTELTITLE2", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelTitle3 = sqlCommand.Parameters.Add("@COMPANYTELTITLE3", SqlDbType.NVarChar);
                    //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                    SqlParameter paraDataSaveMonths = sqlCommand.Parameters.Add("@DATASAVEMONTHS", SqlDbType.NVarChar);
                    SqlParameter paraDataCompressDt = sqlCommand.Parameters.Add("@DATACOMPRESSDT", SqlDbType.NVarChar);
                    SqlParameter paraResultDtSaveMonths = sqlCommand.Parameters.Add("@RESULTDTSAVEMONTHS", SqlDbType.NVarChar);
                    SqlParameter paraResultDtCompressDt = sqlCommand.Parameters.Add("@RESULTDTCOMPRESSDT", SqlDbType.NVarChar);
                    SqlParameter paraCaPrtsDtSaveMonths = sqlCommand.Parameters.Add("@CAPRTSDTSAVEMONTHS", SqlDbType.NVarChar);
                    SqlParameter paraCaPrtsDtCompressDt = sqlCommand.Parameters.Add("@CAPRTSDTCOMPRESSDT", SqlDbType.NVarChar);
                    SqlParameter paraMasterSaveMonths = sqlCommand.Parameters.Add("@MASTERSAVEMONTHS", SqlDbType.NVarChar);
                    SqlParameter paraMasterCompressDt = sqlCommand.Parameters.Add("@MASTERCOMPRESSDT", SqlDbType.NVarChar);
                    SqlParameter paraRatePriorityDiv = sqlCommand.Parameters.Add("@RATEPRIORITYDIV", SqlDbType.NVarChar);
                    //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<



					//Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companyinfWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companyinfWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(companyinfWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(companyinfWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(companyinfWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(companyinfWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.LogicalDeleteCode);
                    paraCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);
                    paraCompanyTotalDay.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyTotalDay);
                    paraCompanyBiginMonth.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyBiginMonth);
                    paraCompanyBiginMonth2.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyBiginMonth2);
                    paraCompanyName1.Value = SqlDataMediator.SqlSetString(companyinfWork.CompanyName1);
                    paraCompanyName2.Value = SqlDataMediator.SqlSetString(companyinfWork.CompanyName2);
                    // �� 2007.09.14 980081
                    paraFinancialYear.Value = SqlDataMediator.SqlSetInt32(companyinfWork.FinancialYear);
                    paraCompanyBiginDate.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyBiginDate);
                    paraStartYearDiv.Value = SqlDataMediator.SqlSetInt32(companyinfWork.StartYearDiv);
                    paraStartMonthDiv.Value = SqlDataMediator.SqlSetInt32(companyinfWork.StartMonthDiv);
                    // �� 2007.09.14 980081
                    // �� 2008.01.10 980081 a
                    paraSecMngDiv.Value = SqlDataMediator.SqlSetInt32(companyinfWork.SecMngDiv);
                    // �� 2008.01.10 980081 a
                    paraPostNo.Value = SqlDataMediator.SqlSetString(companyinfWork.PostNo);
                    paraAddress1.Value = SqlDataMediator.SqlSetString(companyinfWork.Address1);
                    //paraAddress2.Value = SqlDataMediator.SqlSetInt32(companyinfWork.Address2);
                    paraAddress3.Value = SqlDataMediator.SqlSetString(companyinfWork.Address3);
                    paraAddress4.Value = SqlDataMediator.SqlSetString(companyinfWork.Address4);
                    paraCompanyTelNo1.Value = SqlDataMediator.SqlSetString(companyinfWork.CompanyTelNo1);
                    paraCompanyTelNo2.Value = SqlDataMediator.SqlSetString(companyinfWork.CompanyTelNo2);
                    paraCompanyTelNo3.Value = SqlDataMediator.SqlSetString(companyinfWork.CompanyTelNo3);
                    paraCompanyTelTitle1.Value = SqlDataMediator.SqlSetString(companyinfWork.CompanyTelTitle1);
                    paraCompanyTelTitle2.Value = SqlDataMediator.SqlSetString(companyinfWork.CompanyTelTitle2);
                    paraCompanyTelTitle3.Value = SqlDataMediator.SqlSetString(companyinfWork.CompanyTelTitle3);
                    //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                    paraDataSaveMonths.Value = SqlDataMediator.SqlSetInt32(companyinfWork.DataSaveMonths);
                    paraDataCompressDt.Value = SqlDataMediator.SqlSetInt32(companyinfWork.DataCompressDt);
                    paraResultDtSaveMonths.Value = SqlDataMediator.SqlSetInt32(companyinfWork.ResultDtSaveMonths);
                    paraResultDtCompressDt.Value = SqlDataMediator.SqlSetInt32(companyinfWork.ResultDtCompressDt);
                    paraCaPrtsDtSaveMonths.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CaPrtsDtSaveMonths);
                    paraCaPrtsDtCompressDt.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CaPrtsDtCompressDt);
                    paraMasterSaveMonths.Value = SqlDataMediator.SqlSetInt32(companyinfWork.MasterSaveMonths);
                    paraMasterCompressDt.Value = SqlDataMediator.SqlSetInt32(companyinfWork.MasterCompressDt);
                    paraRatePriorityDiv.Value = SqlDataMediator.SqlSetInt32(companyinfWork.RatePriorityDiv);
                    //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<

                    #endregion

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(companyinfWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    // del 2007.05.18 Saitoh >>>>>>>>>>
					//�����ύX����
					//ChangeCompanyTotalDay _ChangeCompanyTotalDay = new ChangeCompanyTotalDay();
					//status = _ChangeCompanyTotalDay.ChangeProc(companyinfWork.EnterpriseCode,beforTotalDay,companyinfWork.CompanyTotalDay,out totalDayChgflg,ref sqlConnection,ref sqlTransaction);
                    // del 2007.05.18 Saitoh <<<<<<<<<<

				}
				catch (SqlException ex) 
				{
					//���N���X�ɗ�O��n���ď������Ă��炤
					status = base.WriteSQLErrorLog(ex);
				}
                catch(Exception ex)
                {
                    base.WriteErrorLog(ex,"CompanyInfDB.Write Exception="+ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

				// �R�~�b�g
				sqlTransaction.Commit();
			
				if(!myReader.IsClosed)myReader.Close();
				sqlConnection.Close();
			}
			finally
			{
				if(_ControlExclusiveOrderAccess != null)	_ControlExclusiveOrderAccess.UnlockDB();
			}


			return status;
		}

		/// <summary>
		/// ���Џ���_���폜���܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Џ���_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteCompanyInfProc(ref parabyte,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteCompanyInfProc(ref parabyte,0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"CompanyInfDB.LogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �_���폜���Џ��𕜊����܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���Џ��𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
//			return LogicalDeleteCompanyInfProc(ref parabyte,1);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status =  LogicalDeleteCompanyInfProc(ref parabyte,1);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"CompanyInfDB.RevivalLogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// ���Џ��̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Џ��̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		private int LogicalDeleteCompanyInfProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try		
			{
				// XML�̓ǂݍ���
				CompanyInfWork companyinfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.20 upd start ----------------------------------------------------->>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, COMPANYCODERF FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.20 upd end -------------------------------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);
				findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);

                sqlTxt = string.Empty;  // 2008.05.20 add

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != companyinfWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                    
                    // 2008.05.20 upd start --------------------------------------------------->>
					//sqlCommand.CommandText = "UPDATE COMPANYINFRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE";

                    sqlTxt += "UPDATE COMPANYINFRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , COMPANYCODERF=@COMPANYCODE" + Environment.NewLine;
                    sqlTxt += " , COMPANYTOTALDAYRF=@COMPANYTOTALDAY" + Environment.NewLine;
                    sqlTxt += " , FINANCIALYEARRF=@FINANCIALYEAR" + Environment.NewLine;
                    sqlTxt += " , COMPANYBIGINMONTHRF=@COMPANYBIGINMONTH" + Environment.NewLine;
                    sqlTxt += " , COMPANYBIGINMONTH2RF=@COMPANYBIGINMONTH2" + Environment.NewLine;
                    sqlTxt += " , COMPANYBIGINDATERF=@COMPANYBIGINDATE" + Environment.NewLine;
                    sqlTxt += " , STARTYEARDIVRF=@STARTYEARDIV" + Environment.NewLine;
                    sqlTxt += " , STARTMONTHDIVRF=@STARTMONTHDIV" + Environment.NewLine;
                    sqlTxt += " , COMPANYNAME1RF=@COMPANYNAME1" + Environment.NewLine;
                    sqlTxt += " , COMPANYNAME2RF=@COMPANYNAME2" + Environment.NewLine;
                    sqlTxt += " , POSTNORF=@POSTNO" + Environment.NewLine;
                    sqlTxt += " , ADDRESS1RF=@ADDRESS1" + Environment.NewLine;
                    sqlTxt += " , ADDRESS2RF=@ADDRESS2" + Environment.NewLine;
                    sqlTxt += " , ADDRESS3RF=@ADDRESS3" + Environment.NewLine;
                    sqlTxt += " , ADDRESS4RF=@ADDRESS4" + Environment.NewLine;
                    sqlTxt += " , COMPANYTELNO1RF=@COMPANYTELNO1" + Environment.NewLine;
                    sqlTxt += " , COMPANYTELNO2RF=@COMPANYTELNO2" + Environment.NewLine;
                    sqlTxt += " , COMPANYTELNO3RF=@COMPANYTELNO3" + Environment.NewLine;
                    sqlTxt += " , COMPANYTELTITLE1RF=@COMPANYTELTITLE1" + Environment.NewLine;
                    sqlTxt += " , COMPANYTELTITLE2RF=@COMPANYTELTITLE2" + Environment.NewLine;
                    sqlTxt += " , COMPANYTELTITLE3RF=@COMPANYTELTITLE3" + Environment.NewLine;
                    sqlTxt += " , SECMNGDIVRF=@SECMNGDIV" + Environment.NewLine;
                    //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
                    sqlTxt += " , DATASAVEMONTHSRF=@DATASAVEMONTHS" + Environment.NewLine;
                    sqlTxt += " , DATACOMPRESSDTRF=@DATACOMPRESSDT" + Environment.NewLine;
                    sqlTxt += " , RESULTDTSAVEMONTHSRF=@RESULTDTSAVEMONTHS" + Environment.NewLine;
                    sqlTxt += " , RESULTDTCOMPRESSDTRF=@RESULTDTCOMPRESSDT" + Environment.NewLine;
                    sqlTxt += " , CAPRTSDTSAVEMONTHSRF=@CAPRTSDTSAVEMONTHS" + Environment.NewLine;
                    sqlTxt += " , CAPRTSDTCOMPRESSDTRF=@CAPRTSDTCOMPRESSDT" + Environment.NewLine;
                    sqlTxt += " , MASTERSAVEMONTHSRF=@MASTERSAVEMONTHS" + Environment.NewLine;
                    sqlTxt += " , MASTERCOMPRESSDTRF=@MASTERCOMPRESSDT" + Environment.NewLine;
                    //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.20 upd end -----------------------------------------------------<<
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);
					findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)companyinfWork;
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
					else if	(logicalDelCd == 0)	companyinfWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						companyinfWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	companyinfWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companyinfWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(companyinfWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(companyinfWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(companyinfWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(companyinfWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"CompanyInfDB.LogicalDeleteCompanyInfProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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

		/// <summary>
		/// ���Џ��𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���Џ��I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : ���Џ��𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		public int Delete(byte[] parabyte)
		{
            return this.DeleteProc(parabyte);
        }
        private int DeleteProc(byte[] parabyte)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
				// XML�̓ǂݍ���
				CompanyInfWork companyinfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));

                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.20 upd start ---------------------------------------------------------->>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, COMPANYCODERF FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.20 upd end ------------------------------------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);
				findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != companyinfWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
                    // 2008.05.20 upd start -------------------------------------------->>
					//sqlCommand.CommandText = "DELETE FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "DELETE" + Environment.NewLine;
                    sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.20 upd end ----------------------------------------------<<
                    //KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);
					findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyinfWork.CompanyCode);
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
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"CompanyInfDB.Delete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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

        // -- ADD 2011/07/14 ------------------------------------------->>>
        /// <summary>
        /// ���Џ��Ƀf�[�^�N���A���ԍX�V���܂�
        /// </summary>
        /// <param name="paraobj">�X�V����</param>
        /// <param name="DelYMD">�f�[�^�N���A�N����</param>
        /// <param name="DelHMSXXX">�f�[�^�N���A�����b�~���b</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Џ��Ƀf�[�^�N���A���ԍX�V���܂�</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        public int WriteClearTime( object paraobj, String DelYMD, String DelHMSXXX, out string errMsg)
        {
            CompanyInfWork companyInf = paraobj as CompanyInfWork;
            return this.WriteClearTimeProc(companyInf, DelYMD, DelHMSXXX, out errMsg);
        }
        /// <summary>
        /// ���Џ��Ƀf�[�^�N���A���ԍX�V���܂�
        /// </summary>
        /// <param name="companyinfWork">��Ə��</param>
        /// <param name="DelYMD">�f�[�^�N���A�N����</param>
        /// <param name="DelHMSXXX">�f�[�^�N���A�����b�~���b</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Џ��Ƀf�[�^�N���A���ԍX�V���܂�</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        private int WriteClearTimeProc(CompanyInfWork companyinfWork, String DelYMD, String DelHMSXXX, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMsg = string.Empty;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ControlExclusiveOrderAccess _ControlExclusiveOrderAccess = null;

            try
            {
                try
                {
                    //�`�[�r������
                    _ControlExclusiveOrderAccess = new ControlExclusiveOrderAccess();

                    //�R�l�N�V����������擾
                    //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    string sqlTxt = string.Empty;

                    sqlTxt = string.Empty;
                    sqlTxt += "UPDATE COMPANYINFRF SET DATACLREXECDATERF=@DATACLREXECDATE, DATACLREXECTIMERF=@DATACLREXECTIME WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE ";

                    SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                    #region �l�Z�b�g

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraDelYMD = sqlCommand.Parameters.Add("@DATACLREXECDATE", SqlDbType.Int);
                    SqlParameter paraDelHMSXXX = sqlCommand.Parameters.Add("@DATACLREXECTIME", SqlDbType.Int);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraDelYMD.Value = SqlDataMediator.SqlSetInt32(Int32.Parse(DelYMD));
                    paraDelHMSXXX.Value = SqlDataMediator.SqlSetInt32(Int32.Parse(DelHMSXXX));
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyinfWork.EnterpriseCode);
                    paraCompanyCode.Value = SqlDataMediator.SqlSetInt32(0);

                    #endregion

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "CompanyInfDB.WriteClearTimeProc Exception=" + ex.Message);
                    errMsg = "CompanyInfDB.WriteClearTimeProc Exception=" + ex.Message;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                // �R�~�b�g
                sqlTransaction.Commit();

                sqlConnection.Close();
            }
            finally
            {
                if (_ControlExclusiveOrderAccess != null) _ControlExclusiveOrderAccess.UnlockDB();
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃f�[�^�N���A���Ԃ�߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="DelYMD">�f�[�^�N���A�N����</param>
        /// <param name="DelHMSXXX">�f�[�^�N���A�����b�~���b</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃f�[�^�N���A���Ԃ�߂��܂�</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        public int ReadClearTime(string enterpriseCode, out Int32 DelYMD, out Int32 DelHMSXXX)
        {
            return this.ReadProc(enterpriseCode, out DelYMD, out DelHMSXXX);
        }

        private int ReadProc(string enterpriseCode, out Int32 DelYMD, out Int32 DelHMSXXX)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            DelYMD = 0;
            DelHMSXXX = 0;
            try
            {   
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Select�R�}���h�̐���

                string sqlTxt = string.Empty;

                sqlTxt += " SELECT DATACLREXECDATERF ";
                sqlTxt += " ,DATACLREXECTIMERF ";
                sqlTxt += " FROM COMPANYINFRF ";
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                sqlTxt += " AND COMPANYCODERF=@FINDCOMPANYCODE ";
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaCompanyCode.Value = SqlDataMediator.SqlSetInt(0);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    DelYMD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACLREXECDATERF"));
                    DelHMSXXX = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACLREXECTIMERF"));
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
                base.WriteErrorLog(ex, "SectionInfo.SearchSecInfoSetProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        // -- ADD 2011/07/14 -------------------------------------------<<<
	}

}

