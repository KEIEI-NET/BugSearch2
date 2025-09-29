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
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �]�ƈ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �]�ƈ��̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 96137�@�R�c�@�\</br>
	/// <br>Date       : 2005.03.17</br>
	/// <br></br>
	/// <br>Update Note:</br>
	/// <br>20050705 yamada  �J�X�^���V���A���C�Y�Ή� </br>
    /// <br></br>
    /// <br>Update Note: �]�ƈ��ʖڕW�l�����[�g���g�p���Ȃ��iSFANL09084R O,D�j</br>
    /// <br>           : 2007.05.31 �v�ۓc Read���\�b�h�Ř_���폜�ް���NotFound��߂��i�]�ƈ����O�C���p�j</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.05.18</br>
    /// <br></br>
    /// <br>Update Note: 20081  �D�c �E�l</br>
    /// <br>Date       : 2008.05.29</br>
    /// <br>           : �o�l.�m�r�p�ɕύX</br>
	/// <br>Update Note: 2012.05.29 30182 ���J�@����</br>
	/// <br>           :  �u����`�[���͋N�������v�u���Ӑ�d�q�����N�������v���ڒǉ�</br>
	/// </remarks>
	[Serializable]
    public class EmployeeDB : RemoteDB, IEmployeeDB, IGetSyncdataList
	{
		/// <summary>
		/// �]�ƈ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 96137�@�R�c�@�\</br>
		/// <br>Date       : 2005.03.17</br>
		/// </remarks>
		public EmployeeDB() : base("SFTOK09386D","Broadleaf.Application.Remoting.ParamData.EmployeeWork", "EMPLOYEERF")
		{
			//�R�l�N�V����������擾�Ή�����������
			//�����ӁF�R���X�g���N�^�ŃR�l�N�V������������擾���Ȃ�
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:EmployeeWork�N���X�F��ƃR�[�h)</param>	
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			try
			{
                // XML�̓ǂݍ���
                EmployeeWork employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));

                int status = SearchCntProc(out retCnt, employeeWork, readMode, logicalMode);

                return status;
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.SearchCnt Exception = "+ex.Message);
				retCnt = 0;
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST�̌�����߂��܂�
        /// </summary>
        /// <param name="retCnt">�Y���f�[�^����</param>
        /// <param name="paraobj">�����p�����[�^(readMode=0:EmployeeWork�N���X�F��ƃR�[�h)</param>	
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int SearchCnt(out int retCnt, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                EmployeeWork employeeWork = paraobj as EmployeeWork;

                return SearchCntProc(out retCnt, employeeWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.SearchCnt Exception = " + ex.Message);
                retCnt = 0;
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }
        
        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST�̌�����߂��܂�
		/// </summary>
        /// <param name="retCnt">��������</param>
        /// <param name="employeeWork">�����p�����[�^(readMode=0:EmployeeWork�N���X�F��ƃR�[�h)</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
        private int SearchCntProc(out int retCnt, EmployeeWork employeeWork, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;

            string sqlTxt = string.Empty; // 2008.05.29 add

			retCnt = 0;

			ArrayList al = new ArrayList();
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

				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.29 upd start ------------------------------------------>>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
                    sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                    sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.29 upd end --------------------------------------------<<
                    
                    //�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.29 upd start ------------------------------------------>>
					//sqlCommand = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
                    sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                    sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.29 upd end --------------------------------------------<<
                    //�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
                    // 2008.05.29 upd start ------------------------------------------>>
                    //sqlCommand = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
                    sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                    sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.29 upd end --------------------------------------------<<
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

				//�f�[�^���[�h
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="employeeWork">��������</param>
		/// <param name="paraemployeeWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		public int Search(out object employeeWork,object paraemployeeWork, int readMode,ConstantManagement.LogicalMode logicalMode)
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		{	
			try
			{
				bool nextData;
				int retTotalCnt;
				////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				//			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
				return SearchProc(out employeeWork,out retTotalCnt,out nextData,paraemployeeWork ,readMode,logicalMode,0);
				////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Search Exception = "+ex.Message);
				employeeWork = new ArrayList();
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="employeeWork">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraemployeeWork">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
//		{		
//			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
//		}
		public int SearchSpecification(out object employeeWork,out int retTotalCnt,out bool nextData,object paraemployeeWork,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{	
			try
			{
				return SearchProc(out employeeWork,out retTotalCnt,out nextData,paraemployeeWork, readMode,logicalMode,readCnt);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.SearchSpecification Exception = "+ex.Message);
				employeeWork = new ArrayList();
				nextData = false;
				retTotalCnt = 0;
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="objemployeeWork">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraemployeeWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		private int SearchProc(out object objemployeeWork,out int retTotalCnt,out bool nextData,object paraemployeeWork, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommandCount = null;
			SqlCommand sqlCommand = null;

			EmployeeWork employeeWork = new EmployeeWork();
			employeeWork = null;

////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//			retbyte = null;
			objemployeeWork = null;
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//�����R�[�h�����ŏ�����
			nextData = false;
            string sqlTxt = string.Empty; // 2008.05.29 add

			ArrayList al = new ArrayList();
			try 
			{	
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//				// XML�̓ǂݍ���
//				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
				ArrayList employeeWorkList = paraemployeeWork as ArrayList;
				if(employeeWorkList == null)
				{
					employeeWork = paraemployeeWork as EmployeeWork;
				}
				else
				{	
					if(employeeWorkList.Count > 0)
						employeeWork = employeeWorkList[0] as EmployeeWork;
				}
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
				if ((readCnt > 0)&&((employeeWork.EmployeeCode == null)||(employeeWork.EmployeeCode == "")))
				{
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                        //�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
								(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                        //�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += "    FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

                sqlTxt = string.Empty; // 2008.05.29 add

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//�����w�薳���̏ꍇ
					if (readCnt == 0)
					{
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMERF" + Environment.NewLine;
                        sqlTxt += "    ,KANARF" + Environment.NewLine;
                        sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                        sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                        sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                        sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                        sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                        sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                        sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
						// -- Add St 2012.05.29 30182 R.Tachiya --
						sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
						sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
						// -- Add Ed 2012.05.29 30182 R.Tachiya --
						sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                    }
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if ((employeeWork.EmployeeCode == null)||(employeeWork.EmployeeCode == ""))
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            //sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                        }
							//Next���[�h�̏ꍇ
						else
						{
                            // 2008.05.29 upd start ------------------------------>>
							sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND EMPLOYEECODERF>@FINDEMPLOYEECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND EMPLOYEECODERF>@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
							paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
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
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMERF" + Environment.NewLine;
                        sqlTxt += "    ,KANARF" + Environment.NewLine;
                        sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                        sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                        sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                        sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                        sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                        sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                        sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
						// -- Add St 2012.05.29 30182 R.Tachiya --
						sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
						sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
						// -- Add Ed 2012.05.29 30182 R.Tachiya --
						sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                    }
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if ((employeeWork.EmployeeCode == null)||(employeeWork.EmployeeCode == ""))
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                        }
							//Next���[�h�̏ꍇ
						else
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND EMPLOYEECODERF>@FINDEMPLOYEECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND EMPLOYEECODERF>@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
							paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
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
                        // 2008.05.29 upd start ------------------------------>>
						//sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMERF" + Environment.NewLine;
                        sqlTxt += "    ,KANARF" + Environment.NewLine;
                        sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                        sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                        sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                        sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                        sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                        sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                        sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
						// -- Add St 2012.05.29 30182 R.Tachiya --
						sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
						sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
						// -- Add Ed 2012.05.29 30182 R.Tachiya --
						sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end --------------------------------<<
                    }
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if ((employeeWork.EmployeeCode == null)||(employeeWork.EmployeeCode == ""))
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                        }
						else
						{
                            // 2008.05.29 upd start ------------------------------>>
							//sqlCommand = new SqlCommand("SELECT TOP "+_readCnt.ToString()+" * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF>@FINDEMPLOYEECODE ORDER BY EMPLOYEECODERF",sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
							//sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;// -- Del 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    CREATEDATETIMERF" + Environment.NewLine;// -- Add 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
							// -- Add St 2012.05.29 30182 R.Tachiya --
							sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
							sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
							// -- Add Ed 2012.05.29 30182 R.Tachiya --
							sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND EMPLOYEECODERF>@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end --------------------------------<<
                            SqlParameter paraEmployeeCode2 = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
							paraEmployeeCode2.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

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
					EmployeeWork wkEmployeeWork = new EmployeeWork();

					wkEmployeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkEmployeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkEmployeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkEmployeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkEmployeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkEmployeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkEmployeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkEmployeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkEmployeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("EMPLOYEECODERF"));
					wkEmployeeWork.Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NAMERF"));
					wkEmployeeWork.Kana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("KANARF"));
					wkEmployeeWork.ShortName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SHORTNAMERF"));
					wkEmployeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SEXCODERF"));
					wkEmployeeWork.SexName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SEXNAMERF"));
					wkEmployeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("BIRTHDAYRF"));
					wkEmployeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("COMPANYTELNORF"));
					wkEmployeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("PORTABLETELNORF"));
					wkEmployeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("POSTCODERF"));
					wkEmployeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BUSINESSCODERF"));
					wkEmployeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FRONTMECHACODERF"));
					wkEmployeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
					wkEmployeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BELONGSECTIONCODERF"));
					wkEmployeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTGENERALRF"));
					wkEmployeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
					wkEmployeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
					wkEmployeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
					wkEmployeeWork.LoginId = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINIDRF"));
					wkEmployeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINPASSWORDRF"));
					wkEmployeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERADMINFLAGRF"));
					wkEmployeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ENTERCOMPANYDATERF"));
					wkEmployeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RETIREMENTDATERF"));
                    // add 2007.05.23 saito >>>>>>>>>>
                    wkEmployeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                    wkEmployeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                    // add 2007.05.23 saito <<<<<<<<<<
					// -- Add St 2012.05.29 30182 R.Tachiya --
					wkEmployeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
					wkEmployeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
					// -- Add Ed 2012.05.29 30182 R.Tachiya --

                    al.Add(wkEmployeeWork); 

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
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

////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//			// XML�֕ϊ����A������̃o�C�i����
//			EmployeeWork[] EmployeeWorks = (EmployeeWork[])al.ToArray(typeof(EmployeeWork));
//			retbyte = XmlByteSerializer.Serialize(EmployeeWorks);
			objemployeeWork = al;
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			return status;

		}

		/// <summary>
		/// �w�肳�ꂽ�]�ƈ�Guid�̏]�ƈ���߂��܂�
		/// </summary>
		/// <param name="parabyte">EmployeeWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		public int Read(ref byte[] parabyte , int readMode)
		{
			try
			{
				EmployeeWork employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));

				int status = ReadProc(ref employeeWork,readMode);
				// XML�֕ϊ����A������̃o�C�i����
				parabyte = XmlByteSerializer.Serialize(employeeWork);

				return status;
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Read Exception = "+ex.Message);
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// �w�肳�ꂽ�]�ƈ�Guid�̏]�ƈ���߂��܂�
		/// </summary>
		/// <param name="parabyte">EmployeeWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		public int Read(ref object parabyte , int readMode)
		{
			try
			{
				EmployeeWork employeeWork = parabyte as EmployeeWork;

				return ReadProc(ref employeeWork,readMode);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Read Exception = "+ex.Message);
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// �w�肳�ꂽ�]�ƈ�Guid�̏]�ƈ���߂��܂�
		/// </summary>
		/// <param name="parabyte">EmployeeWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		public int Read(ref EmployeeWork parabyte , int readMode)
		{
			try
			{
				return ReadProc(ref parabyte,readMode);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Read Exception = "+ex.Message);
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// �w�肳�ꂽ�]�ƈ�Guid�̏]�ƈ���߂��܂�
		/// </summary>
		/// <param name="employeeWork">EmployeeWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		private int ReadProc(ref EmployeeWork employeeWork, int readMode)
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

                // 2008.05.29 upd start -------------------------------->>
				//sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE " ,sqlConnection);
                string sqlTxt = string.Empty; 
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                sqlTxt += "    ,KANARF" + Environment.NewLine;
                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
				// -- Add St 2012.05.29 30182 R.Tachiya --
				sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
				sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
				// -- Add Ed 2012.05.29 30182 R.Tachiya --
				sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 upd end ----------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
								
				//���O�C���h�c�������Ă�����
				if(employeeWork.LoginId != "")
				{
					sqlCommand.CommandText += "AND LOGINIDRF=@FINDLOGINID";
					SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);
					findParaLoginId.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);
				}
				else
				{
					sqlCommand.CommandText += "AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
					SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				}

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("EMPLOYEECODERF"));
					employeeWork.Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NAMERF"));
					employeeWork.Kana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("KANARF"));
					employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SHORTNAMERF"));
					employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SEXCODERF"));
					employeeWork.SexName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SEXNAMERF"));
					employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("BIRTHDAYRF"));
					employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("COMPANYTELNORF"));
					employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("PORTABLETELNORF"));
					employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("POSTCODERF"));
					employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BUSINESSCODERF"));
					employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FRONTMECHACODERF"));
					employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
					employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BELONGSECTIONCODERF"));
					employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTGENERALRF"));
					employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
					employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
					employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
					employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINIDRF"));
					employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINPASSWORDRF"));
					employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERADMINFLAGRF"));
					employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ENTERCOMPANYDATERF"));
					employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RETIREMENTDATERF"));
                    // add 2007.05.23 saitoh >>>>>>>>>>
                    employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                    employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                    // add 2007.05.23 saitoh <<<<<<<<<<
					// -- Add St 2012.05.29 30182 R.Tachiya --
					employeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
					employeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
					// -- Add Ed 2012.05.29 30182 R.Tachiya --
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
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
		/// �w�肳�ꂽ�]�ƈ�Guid�̏]�ƈ���߂��܂�
		/// </summary>
		/// <param name="employeeWork">EmployeeWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		public int Read(ref EmployeeWork employeeWork, int readMode , ref SqlConnection sqlConnection)
		{
            return this.ReadProc(ref employeeWork, readMode, ref sqlConnection);
        }
        /// <summary>
        /// �w�肳�ꂽ�]�ƈ�Guid�̏]�ƈ���߂��܂�
        /// </summary>
        /// <param name="employeeWork">EmployeeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        private int ReadProc(ref EmployeeWork employeeWork, int readMode, ref SqlConnection sqlConnection)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;

			try 
			{
                // 2008.05.29 upd start -------------------------------->>
				//SqlCommand sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE " ,sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                sqlTxt += "    ,KANARF" + Environment.NewLine;
                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
				// -- Add St 2012.05.29 30182 R.Tachiya --
				sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
				sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
				// -- Add Ed 2012.05.29 30182 R.Tachiya --
				sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 upd end ----------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
								
				//���O�C���h�c�������Ă�����
				if(employeeWork.LoginId != "")
				{
					sqlCommand.CommandText += "AND LOGINIDRF=@FINDLOGINID";
					SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);
					findParaLoginId.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);
				}
				else
				{
					sqlCommand.CommandText += "AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
					SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				}

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
                    if (employeeWork.LogicalDeleteCode == SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF")))//2007.05.31 add �v�ۓc
                    {
                        employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        employeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        employeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                        employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                        employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
                        employeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
                        employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
                        employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
                        employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                        employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
                        employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                        employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
                        employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
                        employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                        employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
                        employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
                        employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
                        employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
                        employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
                        employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
                        employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
                        employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
                        employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
                        employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                        employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
						// -- Add St 2012.05.29 30182 R.Tachiya --
						employeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
						employeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
						// -- Add Ed 2012.05.29 30182 R.Tachiya --

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Read Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();

			return status;
		}

		/// <summary>
		/// ���������w�肳�ꂽ��ƃR�[�h�A�]�ƈ��R�[�h�̏]�ƈ�����߂��܂�
		/// </summary>
		/// <param name="retList">��������List</param>
		/// <param name="paraList">��������List</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		public int ReadList(out ArrayList retList, ArrayList paraList , int readMode)
		{
            return this.ReadListProc(out retList, paraList, readMode);

        }
        /// <summary>
        /// ���������w�肳�ꂽ��ƃR�[�h�A�]�ƈ��R�[�h�̏]�ƈ�����߂��܂�
        /// </summary>
        /// <param name="retList">��������List</param>
        /// <param name="paraList">��������List</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        private int ReadListProc(out ArrayList retList, ArrayList paraList, int readMode)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			EmployeeWork employeeWork = null;
			retList = new ArrayList();
			ArrayList al = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.29 add

			try 
			{		
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				foreach(EmployeeWork item in paraList)
				{
                    // 2008.05.29 upd start -------------------------------->>
                    //SqlCommand sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE "
                    //    + "AND EMPLOYEECODERF=@FINDEMPLOYEECODE ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMERF" + Environment.NewLine;
                    sqlTxt += "    ,KANARF" + Environment.NewLine;
                    sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                    sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                    sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                    sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                    sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                    sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                    sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
					sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
					sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
					// -- Add Ed 2012.05.29 30182 R.Tachiya --
					sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    sqlTxt = string.Empty;
                    // 2008.05.29 upd end ----------------------------------<< 
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);								
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						employeeWork = new EmployeeWork();
						employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("EMPLOYEECODERF"));
						employeeWork.Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NAMERF"));
						employeeWork.Kana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("KANARF"));
						employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SHORTNAMERF"));
						employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SEXCODERF"));
						employeeWork.SexName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SEXNAMERF"));
						employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("BIRTHDAYRF"));
						employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("COMPANYTELNORF"));
						employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("PORTABLETELNORF"));
						employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("POSTCODERF"));
						employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BUSINESSCODERF"));
						employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FRONTMECHACODERF"));
						employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
						employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BELONGSECTIONCODERF"));
						employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTGENERALRF"));
						employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
						employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
						employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
						employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINIDRF"));
						employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("LOGINPASSWORDRF"));
						employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERADMINFLAGRF"));
						employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ENTERCOMPANYDATERF"));
						employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RETIREMENTDATERF"));
                        // add 2007.05.17 saitoh >>>>>>>>>>
                        employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                        employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                        // add 2007.05.17 saitoh <<<<<<<<<<
						// -- Add St 2012.05.29 30182 R.Tachiya --
						employeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
						employeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
						// -- Add Ed 2012.05.29 30182 R.Tachiya --
						al.Add(employeeWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
					if(myReader.IsClosed == false)myReader.Close();
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.ReadList Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			retList = al;
			return status;
		}

		/// <summary>
		/// �]�ƈ�����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">EmployeeWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			EmployeeWork employeeWork = null;

			try
			{
				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));

				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//SQL�R�l�N�V�����I�u�W�F�N�g�쐬
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				//�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				status = Write(ref employeeWork, ref sqlConnection, ref sqlTransaction);
			}
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Write:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{				
				// ���R�l�N�V�����j��
				if (sqlConnection.State == ConnectionState.Open) 
				{
					if(sqlTransaction.Connection != null)
					{
						// ���R�~�b�gor���[���o�b�N
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							sqlTransaction.Commit();
						else
							sqlTransaction.Rollback();
					}
					sqlTransaction.Dispose();
					sqlConnection.Close();
				}
			}
			parabyte = XmlByteSerializer.Serialize(employeeWork);

			return status;
		}

        /// <summary>
        /// �]�ƈ�����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">EmployeeWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int Write(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            EmployeeWork employeeWork = null;

            try
            {
                employeeWork = paraobj as EmployeeWork;

                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL�R�l�N�V�����I�u�W�F�N�g�쐬
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = Write(ref employeeWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.Write:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ���R�l�N�V�����j��
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        // ���R�~�b�gor���[���o�b�N
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            sqlTransaction.Commit();
                        else
                            sqlTransaction.Rollback();
                    }
                    sqlTransaction.Dispose();
                    sqlConnection.Close();
                }
            }

            return status;
        }
        
        /// <summary>
		/// �]�ƈ�����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">EmployeeWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int LogicalDelete(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			EmployeeWork employeeWork = null;

			try 
			{
				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
				status = LogicalDelete(ref employeeWork, 0, ref sqlConnection, ref sqlTransaction);

                // del 2007.05.18 Saitoh >>>>>>>>>>
				//if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//{								  
				//	EmplTargetDB emplTargetDB = new EmplTargetDB();
				//	EmplTargetWork emplTargetWork = new EmplTargetWork();

				//	emplTargetWork.EnterpriseCode = employeeWork.EnterpriseCode;
				//	emplTargetWork.EmployeeCode = employeeWork.EmployeeCode;

				//	status = emplTargetDB.LogicalDeleteProc(emplTargetWork, 0, ref sqlConnection, ref sqlTransaction);
				//}
                // del 2007.05.18 Saitoh <<<<<<<<<<
			}
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.LogicalDelete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{				
				// ���R�l�N�V�����j��
				if (sqlConnection != null) 
				{
					// ���R�~�b�gor���[���o�b�N
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						sqlTransaction.Commit();
					else
						sqlTransaction.Rollback();
					sqlTransaction.Dispose();
					sqlConnection.Close();
				}
			}

			parabyte = XmlByteSerializer.Serialize(employeeWork);
			return status;
		}

        /// <summary>
        /// �]�ƈ�����_���폜���܂�
        /// </summary>
        /// <param name="paraobj">EmployeeWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int LogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            EmployeeWork employeeWork = null;

            try
            {
                employeeWork = paraobj as EmployeeWork;
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                status = LogicalDelete(ref employeeWork, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.LogicalDelete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ���R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    // ���R�~�b�gor���[���o�b�N
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                    sqlTransaction.Dispose();
                    sqlConnection.Close();
                }
            }

            return status;
        }
        
        /// <summary>
		/// �_���폜�]�ƈ����𕜊����܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			EmployeeWork employeeWork = null;
			try 
			{
				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
				status = LogicalDelete(ref employeeWork, 1, ref sqlConnection, ref sqlTransaction);

                // del 2007.05.18 Saitoh >>>>>>>>>>
				//if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//{								  
				//	EmplTargetDB emplTargetDB = new EmplTargetDB();
				//	EmplTargetWork emplTargetWork = new EmplTargetWork();

				//	emplTargetWork.EnterpriseCode = employeeWork.EnterpriseCode;
				//	emplTargetWork.EmployeeCode = employeeWork.EmployeeCode;
				//	status = emplTargetDB.LogicalDeleteProc(emplTargetWork, 1, ref sqlConnection, ref sqlTransaction);
				//}
                // del 2007.05.18 Saitoh <<<<<<<<<<
			}
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.LogicalDelete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{				
				// ���R�l�N�V�����j��
				if (sqlConnection != null) 
				{
					// ���R�~�b�gor���[���o�b�N
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						sqlTransaction.Commit();
					else
						sqlTransaction.Rollback();
					sqlTransaction.Dispose();
					sqlConnection.Close();
				}
			}
			parabyte = XmlByteSerializer.Serialize(employeeWork);
			return status;
		}

        /// <summary>
        /// �_���폜�]�ƈ����𕜊����܂�
        /// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int RevivalLogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            EmployeeWork employeeWork = null;
            try
            {
                employeeWork = paraobj as EmployeeWork;
                //�R�l�N�V����������擾�Ή�����������
                //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                //�R�l�N�V����������擾�Ή�����������

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                status = LogicalDelete(ref employeeWork, 1, ref sqlConnection, ref sqlTransaction);

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.LogicalDelete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ���R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    // ���R�~�b�gor���[���o�b�N
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                    sqlTransaction.Dispose();
                    sqlConnection.Close();
                }
            }
            return status;
        }
        
        /// <summary>
		/// �]�ƈ����̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">EmployeeWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			EmployeeWork employeeWork = null;

			try 
			{
				// XML�̓ǂݍ���
				employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
				//�R�l�N�V����������擾�Ή�����������
				//���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				//�R�l�N�V����������擾�Ή�����������

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.29 upd start ------------------------------->>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 upd end ---------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != employeeWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // 2008.05.29 upd start ------------------------------->>
					//sqlCommand.CommandText = "UPDATE EMPLOYEERF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    sqlTxt = string.Empty;
                    sqlTxt += "UPDATE EMPLOYEERF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end ---------------------------------<<
                    //KEY�R�}���h���Đݒ�
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

					//�R�l�N�V����������擾�Ή�����������
					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)employeeWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
					//�R�l�N�V����������擾�Ή�����������
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					myReader.Close();
					sqlConnection.Close();
					return status;
				}
				myReader.Close();

				//�_���폜���[�h�̏ꍇ
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
						sqlCommand.Cancel();
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	employeeWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						employeeWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	employeeWork.LogicalDeleteCode = 0;//�_���폜�t���O������
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
						sqlCommand.Cancel();
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
				}

				//Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
				SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdemployeecode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
				paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.UpdateDateTime);
				paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.UpdEmployeeCode);
				paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId1);
				paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId2);
				paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(employeeWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(employeeWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
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
		/// �]�ƈ�����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="employeeWork">employeeWork</param>
		/// <param name="sqlConnection">Sql�ڑ����</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �]�ƈ�����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2006.02.04</br>
		private int Write(ref EmployeeWork employeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                // 2008.05.29 upd start ------------------------------------------------>>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, EMPLOYEECODERF FROM EMPLOYEERF WHERE (ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE) OR (ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGINIDRF=@FINDLOGINID)", sqlConnection, sqlTransaction);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE" + Environment.NewLine;
                sqlTxt += "    (ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "        AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                sqlTxt += "    )" + Environment.NewLine;
                sqlTxt += "    OR" + Environment.NewLine;
                sqlTxt += "    (ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "        AND LOGINIDRF=@FINDLOGINID" + Environment.NewLine;
                sqlTxt += "    )" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                // 2008.05.29 upd end --------------------------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				findParaLoginId.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != employeeWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (employeeWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
							//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						return status;
					}
                    // 2008.05.29 upd start ------------------------------------------------>>
                    //sqlCommand.CommandText = "UPDATE EMPLOYEERF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , EMPLOYEECODERF=@EMPLOYEECODE , NAMERF=@NAME , KANARF=@KANA , SHORTNAMERF=@SHORTNAME , SEXCODERF=@SEXCODE , SEXNAMERF=@SEXNAME , BIRTHDAYRF=@BIRTHDAY , COMPANYTELNORF=@COMPANYTELNO , PORTABLETELNORF=@PORTABLETELNO , POSTCODERF=@POSTCODE , BUSINESSCODERF=@BUSINESSCODE , FRONTMECHACODERF=@FRONTMECHACODE , INOUTSIDECOMPANYCODERF=@INOUTSIDECOMPANYCODE , BELONGSECTIONCODERF=@BELONGSECTIONCODE , LVRRTCSTGENERALRF=@LVRRTCSTGENERAL , LVRRTCSTCARINSPECTRF=@LVRRTCSTCARINSPECT , LVRRTCSTBODYPAINTRF=@LVRRTCSTBODYPAINT , LVRRTCSTBODYREPAIRRF=@LVRRTCSTBODYREPAIR , LOGINIDRF=@LOGINID , LOGINPASSWORDRF=@LOGINPASSWORD , USERADMINFLAGRF=@USERADMINFLAG , ENTERCOMPANYDATERF=@ENTERCOMPANYDATE , RETIREMENTDATERF=@RETIREMENTDATE , AUTHORITYLEVEL1RF=@AUTHORITYLEVEL1 , AUTHORITYLEVEL2RF=@AUTHORITYLEVEL2 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    sqlTxt = string.Empty;
                    sqlTxt += "UPDATE EMPLOYEERF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , NAMERF=@NAME" + Environment.NewLine;
                    sqlTxt += " , KANARF=@KANA" + Environment.NewLine;
                    sqlTxt += " , SHORTNAMERF=@SHORTNAME" + Environment.NewLine;
                    sqlTxt += " , SEXCODERF=@SEXCODE" + Environment.NewLine;
                    sqlTxt += " , SEXNAMERF=@SEXNAME" + Environment.NewLine;
                    sqlTxt += " , BIRTHDAYRF=@BIRTHDAY" + Environment.NewLine;
                    sqlTxt += " , COMPANYTELNORF=@COMPANYTELNO" + Environment.NewLine;
                    sqlTxt += " , PORTABLETELNORF=@PORTABLETELNO" + Environment.NewLine;
                    sqlTxt += " , POSTCODERF=@POSTCODE" + Environment.NewLine;
                    sqlTxt += " , BUSINESSCODERF=@BUSINESSCODE" + Environment.NewLine;
                    sqlTxt += " , FRONTMECHACODERF=@FRONTMECHACODE" + Environment.NewLine;
                    sqlTxt += " , INOUTSIDECOMPANYCODERF=@INOUTSIDECOMPANYCODE" + Environment.NewLine;
                    sqlTxt += " , BELONGSECTIONCODERF=@BELONGSECTIONCODE" + Environment.NewLine;
                    sqlTxt += " , LVRRTCSTGENERALRF=@LVRRTCSTGENERAL" + Environment.NewLine;
                    sqlTxt += " , LVRRTCSTCARINSPECTRF=@LVRRTCSTCARINSPECT" + Environment.NewLine;
                    sqlTxt += " , LVRRTCSTBODYPAINTRF=@LVRRTCSTBODYPAINT" + Environment.NewLine;
                    sqlTxt += " , LVRRTCSTBODYREPAIRRF=@LVRRTCSTBODYREPAIR" + Environment.NewLine;
                    sqlTxt += " , LOGINIDRF=@LOGINID" + Environment.NewLine;
                    sqlTxt += " , LOGINPASSWORDRF=@LOGINPASSWORD" + Environment.NewLine;
                    sqlTxt += " , USERADMINFLAGRF=@USERADMINFLAG" + Environment.NewLine;
                    sqlTxt += " , ENTERCOMPANYDATERF=@ENTERCOMPANYDATE" + Environment.NewLine;
                    sqlTxt += " , RETIREMENTDATERF=@RETIREMENTDATE" + Environment.NewLine;
                    sqlTxt += " , AUTHORITYLEVEL1RF=@AUTHORITYLEVEL1" + Environment.NewLine;
                    sqlTxt += " , AUTHORITYLEVEL2RF=@AUTHORITYLEVEL2" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
					sqlTxt += " , SALSLIPINPBOOTCNTRF=@SALSLIPINPBOOTCNTRF" + Environment.NewLine;
					sqlTxt += " , CUSTLEDGERBOOTCNTRF=@CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
					// -- Add Ed 2012.05.29 30182 R.Tachiya --
					sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end --------------------------------------------------<<
                    //KEY�R�}���h���Đݒ�
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

					//�R�l�N�V����������擾�Ή�����������
					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)employeeWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
					//�R�l�N�V����������擾�Ή�����������
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (employeeWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						myReader.Close();
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
                    // 2008.05.29 upd start ------------------------------------------------>>
                    //sqlCommand.CommandText = "INSERT INTO EMPLOYEERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, NAMERF, KANARF, SHORTNAMERF, SEXCODERF, SEXNAMERF, BIRTHDAYRF, COMPANYTELNORF, PORTABLETELNORF, POSTCODERF, BUSINESSCODERF, FRONTMECHACODERF, INOUTSIDECOMPANYCODERF, BELONGSECTIONCODERF, LVRRTCSTGENERALRF, LVRRTCSTCARINSPECTRF, LVRRTCSTBODYPAINTRF, LVRRTCSTBODYREPAIRRF, LOGINIDRF, LOGINPASSWORDRF, USERADMINFLAGRF, ENTERCOMPANYDATERF, RETIREMENTDATERF, AUTHORITYLEVEL1RF, AUTHORITYLEVEL2RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @NAME, @KANA, @SHORTNAME, @SEXCODE, @SEXNAME, @BIRTHDAY, @COMPANYTELNO, @PORTABLETELNO, @POSTCODE, @BUSINESSCODE, @FRONTMECHACODE, @INOUTSIDECOMPANYCODE, @BELONGSECTIONCODE, @LVRRTCSTGENERAL, @LVRRTCSTCARINSPECT, @LVRRTCSTBODYPAINT, @LVRRTCSTBODYREPAIR, @LOGINID, @LOGINPASSWORD, @USERADMINFLAG, @ENTERCOMPANYDATE, @RETIREMENTDATE, @AUTHORITYLEVEL1, @AUTHORITYLEVEL2)";
                    sqlTxt = string.Empty;
                    sqlTxt += "INSERT INTO EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMERF" + Environment.NewLine;
                    sqlTxt += "    ,KANARF" + Environment.NewLine;
                    sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                    sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                    sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                    sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                    sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                    sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                    sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
					sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
					sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
					// -- Add Ed 2012.05.29 30182 R.Tachiya --
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
                    sqlTxt += "    ,@EMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += "    ,@NAME" + Environment.NewLine;
                    sqlTxt += "    ,@KANA" + Environment.NewLine;
                    sqlTxt += "    ,@SHORTNAME" + Environment.NewLine;
                    sqlTxt += "    ,@SEXCODE" + Environment.NewLine;
                    sqlTxt += "    ,@SEXNAME" + Environment.NewLine;
                    sqlTxt += "    ,@BIRTHDAY" + Environment.NewLine;
                    sqlTxt += "    ,@COMPANYTELNO" + Environment.NewLine;
                    sqlTxt += "    ,@PORTABLETELNO" + Environment.NewLine;
                    sqlTxt += "    ,@POSTCODE" + Environment.NewLine;
                    sqlTxt += "    ,@BUSINESSCODE" + Environment.NewLine;
                    sqlTxt += "    ,@FRONTMECHACODE" + Environment.NewLine;
                    sqlTxt += "    ,@INOUTSIDECOMPANYCODE" + Environment.NewLine;
                    sqlTxt += "    ,@BELONGSECTIONCODE" + Environment.NewLine;
                    sqlTxt += "    ,@LVRRTCSTGENERAL" + Environment.NewLine;
                    sqlTxt += "    ,@LVRRTCSTCARINSPECT" + Environment.NewLine;
                    sqlTxt += "    ,@LVRRTCSTBODYPAINT" + Environment.NewLine;
                    sqlTxt += "    ,@LVRRTCSTBODYREPAIR" + Environment.NewLine;
                    sqlTxt += "    ,@LOGINID" + Environment.NewLine;
                    sqlTxt += "    ,@LOGINPASSWORD" + Environment.NewLine;
                    sqlTxt += "    ,@USERADMINFLAG" + Environment.NewLine;
                    sqlTxt += "    ,@ENTERCOMPANYDATE" + Environment.NewLine;
                    sqlTxt += "    ,@RETIREMENTDATE" + Environment.NewLine;
                    sqlTxt += "    ,@AUTHORITYLEVEL1" + Environment.NewLine;
                    sqlTxt += "    ,@AUTHORITYLEVEL2" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
					sqlTxt += "    ,@SALSLIPINPBOOTCNTRF" + Environment.NewLine;
					sqlTxt += "    ,@CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
					// -- Add St 2012.05.29 30182 R.Tachiya --
                    sqlTxt += " )" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end --------------------------------------------------<<

                    //�R�l�N�V����������擾�Ή�����������
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)employeeWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
					//�R�l�N�V����������擾�Ή�����������
				}
				myReader.Close();

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter paraCreatedatetime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraEnterprisecode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
				SqlParameter paraFileheaderguid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
				SqlParameter paraUpdemployeecode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
				SqlParameter paraEmployeecode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
				SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
				SqlParameter paraShortname = sqlCommand.Parameters.Add("@SHORTNAME", SqlDbType.NVarChar);
				SqlParameter paraSexcode = sqlCommand.Parameters.Add("@SEXCODE", SqlDbType.Int);
				SqlParameter paraSexname = sqlCommand.Parameters.Add("@SEXNAME", SqlDbType.NVarChar);
				SqlParameter paraBirthday = sqlCommand.Parameters.Add("@BIRTHDAY", SqlDbType.Int);
				SqlParameter paraCompanytelno = sqlCommand.Parameters.Add("@COMPANYTELNO", SqlDbType.NVarChar);
				SqlParameter paraPortabletelno = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
				SqlParameter paraPostcode = sqlCommand.Parameters.Add("@POSTCODE", SqlDbType.Int);
				SqlParameter paraBusinesscode = sqlCommand.Parameters.Add("@BUSINESSCODE", SqlDbType.Int);
				SqlParameter paraFrontmechacode = sqlCommand.Parameters.Add("@FRONTMECHACODE", SqlDbType.Int);
				SqlParameter paraInoutsidecompanycode = sqlCommand.Parameters.Add("@INOUTSIDECOMPANYCODE", SqlDbType.Int);
				SqlParameter paraBelongsectioncode = sqlCommand.Parameters.Add("@BELONGSECTIONCODE", SqlDbType.NChar);
				SqlParameter paraLvrRtCstGeneral = sqlCommand.Parameters.Add("@LVRRTCSTGENERAL", SqlDbType.BigInt);
				SqlParameter paraLvrRtCstCarInspect = sqlCommand.Parameters.Add("@LVRRTCSTCARINSPECT", SqlDbType.BigInt);
				SqlParameter paraLvrRtCstBodyPaint = sqlCommand.Parameters.Add("@LVRRTCSTBODYPAINT", SqlDbType.BigInt);
				SqlParameter paraLvrRtCstBodyRepair = sqlCommand.Parameters.Add("@LVRRTCSTBODYREPAIR", SqlDbType.BigInt);
				SqlParameter paraLoginid = sqlCommand.Parameters.Add("@LOGINID", SqlDbType.NVarChar);
				SqlParameter paraLoginpassword = sqlCommand.Parameters.Add("@LOGINPASSWORD", SqlDbType.NVarChar);
				SqlParameter paraUserAdminFlag = sqlCommand.Parameters.Add("@USERADMINFLAG", SqlDbType.Int);
				SqlParameter paraEntercompanydate = sqlCommand.Parameters.Add("@ENTERCOMPANYDATE", SqlDbType.Int);
				SqlParameter paraRetirementdate = sqlCommand.Parameters.Add("@RETIREMENTDATE", SqlDbType.Int);
                // add 2007.05.23 saitoh >>>>>>>>>>
                SqlParameter paraAuthorityLevel1 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL1", SqlDbType.Int);
                SqlParameter paraAuthorityLevel2 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL2", SqlDbType.Int);
                // add 2007.05.23 saitoh <<<<<<<<<<
				// -- Add St 2012.05.29 30182 R.Tachiya --
				SqlParameter paraSalSlipInpBootCnt = sqlCommand.Parameters.Add("@SALSLIPINPBOOTCNTRF", SqlDbType.Int);
				SqlParameter paraCustLedgerBootCnt = sqlCommand.Parameters.Add("@CUSTLEDGERBOOTCNTRF", SqlDbType.Int);
				// -- Add Ed 2012.05.29 30182 R.Tachiya --

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
				paraCreatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.CreateDateTime);
				paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.UpdateDateTime);
				paraEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				paraFileheaderguid.Value = SqlDataMediator.SqlSetGuid(employeeWork.FileHeaderGuid);
				paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.UpdEmployeeCode);
				paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId1);
				paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId2);
				paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(employeeWork.LogicalDeleteCode);
				paraEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				paraName.Value = SqlDataMediator.SqlSetString(employeeWork.Name);
				paraKana.Value = SqlDataMediator.SqlSetString(employeeWork.Kana);
				paraShortname.Value = SqlDataMediator.SqlSetString(employeeWork.ShortName);
				paraSexcode.Value = SqlDataMediator.SqlSetInt32(employeeWork.SexCode);
				paraSexname.Value = SqlDataMediator.SqlSetString(employeeWork.SexName);
				paraBirthday.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeWork.Birthday);
				paraCompanytelno.Value = SqlDataMediator.SqlSetString(employeeWork.CompanyTelNo);
				paraPortabletelno.Value = SqlDataMediator.SqlSetString(employeeWork.PortableTelNo);
				paraPostcode.Value = SqlDataMediator.SqlSetInt32(employeeWork.PostCode);
				paraBusinesscode.Value = SqlDataMediator.SqlSetInt32(employeeWork.BusinessCode);
				paraFrontmechacode.Value = SqlDataMediator.SqlSetInt32(employeeWork.FrontMechaCode);
				paraInoutsidecompanycode.Value = SqlDataMediator.SqlSetInt32(employeeWork.InOutsideCompanyCode);
				paraBelongsectioncode.Value = SqlDataMediator.SqlSetString(employeeWork.BelongSectionCode);
				paraLvrRtCstGeneral.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstGeneral);
				paraLvrRtCstCarInspect.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstCarInspect);
				paraLvrRtCstBodyPaint.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstBodyPaint);
				paraLvrRtCstBodyRepair.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstBodyRepair);
				paraLoginid.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);
				paraLoginpassword.Value = SqlDataMediator.SqlSetString(employeeWork.LoginPassword);
				paraUserAdminFlag.Value = SqlDataMediator.SqlSetInt32(employeeWork.UserAdminFlag);
				paraEntercompanydate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeWork.EnterCompanyDate);
				paraRetirementdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeWork.RetirementDate);
                // add 2007.05.23 saitoh >>>>>>>>>>
                paraAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(employeeWork.AuthorityLevel1);
                paraAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(employeeWork.AuthorityLevel2);
                // add 2007.05.23 saitoh <<<<<<<<<<
				// -- Add St 2012.05.29 30182 R.Tachiya --
				paraSalSlipInpBootCnt.Value = SqlDataMediator.SqlSetInt32(employeeWork.SalSlipInpBootCnt);
				paraCustLedgerBootCnt.Value = SqlDataMediator.SqlSetInt32(employeeWork.CustLedgerBootCnt);
				// -- Add Ed 2012.05.29 30182 R.Tachiya --

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Write Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}

			return status;
		}

		/// <summary>
		/// �]�ƈ��E�]�ƈ��ڕW���ѐݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">�]�ƈ��I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : �]�ƈ��E�]�ƈ��ڕW���ѐݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2006.02.04</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

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
				EmployeeWork employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				status = Delete(employeeWork, ref sqlConnection, ref sqlTransaction);
				
                // del 2007.05.18 Saitoh >>>>>>>>>>
                //if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//{
				//	EmplTargetDB emplTargetDB = new EmplTargetDB();
				//	EmplTargetWork emplTargetWork = new EmplTargetWork();
				//	emplTargetWork.EnterpriseCode = employeeWork.EnterpriseCode;
				//	emplTargetWork.EmployeeCode = employeeWork.EmployeeCode;
					
				//	status = emplTargetDB.Delete(emplTargetWork, ref sqlConnection, ref sqlTransaction);
				//}
                // del 2007.05.18 Saitoh <<<<<<<<<<
			}
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Delete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{				
				// ���R�l�N�V�����j��
				if (sqlConnection != null) 
				{
					// ���R�~�b�gor���[���o�b�N
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						sqlTransaction.Commit();
					else
						sqlTransaction.Rollback();
					sqlTransaction.Dispose();
					sqlConnection.Close();
				}
			}

			return status;
		}

        /// <summary>
        /// �]�ƈ��E�]�ƈ��ڕW���ѐݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">�]�ƈ��I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �]�ƈ��E�]�ƈ��ڕW���ѐݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2006.02.04</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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
                EmployeeWork employeeWork = paraobj as EmployeeWork;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = Delete(employeeWork, ref sqlConnection, ref sqlTransaction);

                // del 2007.05.18 Saitoh >>>>>>>>>>
                //if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //	EmplTargetDB emplTargetDB = new EmplTargetDB();
                //	EmplTargetWork emplTargetWork = new EmplTargetWork();
                //	emplTargetWork.EnterpriseCode = employeeWork.EnterpriseCode;
                //	emplTargetWork.EmployeeCode = employeeWork.EmployeeCode;

                //	status = emplTargetDB.Delete(emplTargetWork, ref sqlConnection, ref sqlTransaction);
                //}
                // del 2007.05.18 Saitoh <<<<<<<<<<
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.Delete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ���R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    // ���R�~�b�gor���[���o�b�N
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                    sqlTransaction.Dispose();
                    sqlConnection.Close();
                }
            }

            return status;
        }
        
        /// <summary>
		/// �]�ƈ����𕨗��폜���܂�
		/// </summary>
		/// <param name="employeeWork">EmployeeWork</param>
		/// <param name="sqlConnection">Sql�ڑ����</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns></returns>
		/// <br>Note       : �]�ƈ����𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2006.02.04</br>
		public int Delete(EmployeeWork employeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
            return this.DeleteProc(employeeWork, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �]�ƈ����𕨗��폜���܂�
        /// </summary>
        /// <param name="employeeWork">EmployeeWork</param>
        /// <param name="sqlConnection">Sql�ڑ����</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns></returns>
        /// <br>Note       : �]�ƈ����𕨗��폜���܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2006.02.04</br>
        private int DeleteProc(EmployeeWork employeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                // 2008.05.29 upd start ---------------------------------->> 
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE",sqlConnection, sqlTransaction);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                // 2008.05.29 upd end ------------------------------------<<

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
					if (_updateDateTime != employeeWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						return status;
					}

                    // 2008.05.29 upd start ---------------------------------->>
					//sqlCommand.CommandText = "DELETE FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    sqlTxt = string.Empty;
                    sqlTxt += "DELETE" + Environment.NewLine;
                    sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end ------------------------------------<<
                    //KEY�R�}���h���Đݒ�
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					return status;
				}
				myReader.Close();

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"EmployeeDB.Delete Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}

			return status;
		}

		/// <summary>
		/// �]�ƈ����̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="employeeWork">EmployeeWork</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <param name="sqlConnection">Sql�ڑ����</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �]�ƈ����̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2006.02.04</br>
		private int LogicalDelete(ref EmployeeWork employeeWork,int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			try 
			{
                // 2008.05.29 upd start ---------------------------------->>
				//sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE", sqlConnection, sqlTransaction);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                // 2008.05.29 upd end ------------------------------------<<
				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
				findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != employeeWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // 2008.05.29 upd start ---------------------------------->>
					//sqlCommand.CommandText = "UPDATE EMPLOYEERF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    sqlTxt = string.Empty;
                    sqlTxt += "UPDATE EMPLOYEERF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.29 upd end ------------------------------------<<
                    //KEY�R�}���h���Đݒ�
					findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
					findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

					//�R�l�N�V����������擾�Ή�����������
					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)employeeWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
					//�R�l�N�V����������擾�Ή�����������
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					return status;
				}
				myReader.Close();

				//�_���폜���[�h�̏ꍇ
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
						myReader.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	employeeWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						employeeWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	employeeWork.LogicalDeleteCode = 0;//�_���폜�t���O������
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
						myReader.Close();
						return status;
					}
				}

				//Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
				SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdemployeecode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
				paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.UpdateDateTime);
				paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.UpdEmployeeCode);
				paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId1);
				paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId2);
				paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(employeeWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}

			return status;

		}

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.29 upd start ------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF  ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                sqlTxt += "    ,KANARF" + Environment.NewLine;
                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
				// -- Add St 2012.05.29 30182 R.Tachiya --
				sqlTxt += "    ,SALSLIPINPBOOTCNTRF" + Environment.NewLine;
				sqlTxt += "    ,CUSTLEDGERBOOTCNTRF" + Environment.NewLine;
				// -- Add Ed 2012.05.29 30182 R.Tachiya --
				sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 upd end --------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToEmployeeWorkFromReader(ref myReader));

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
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }
        #endregion
        
        #region [�V���N�pWhere���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� EmployeeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmployeeWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2006.12.06</br>
        /// </remarks>
        private EmployeeWork CopyToEmployeeWorkFromReader(ref SqlDataReader myReader)
        {
            EmployeeWork wkEmployeeWork = new EmployeeWork();

            #region �N���X�֊i�[
            wkEmployeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkEmployeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkEmployeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkEmployeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkEmployeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkEmployeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkEmployeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkEmployeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkEmployeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkEmployeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            wkEmployeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
            wkEmployeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
            wkEmployeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
            wkEmployeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
            wkEmployeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
            wkEmployeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
            wkEmployeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
            wkEmployeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
            wkEmployeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
            wkEmployeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
            wkEmployeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
            wkEmployeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
            wkEmployeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
            wkEmployeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
            wkEmployeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
            wkEmployeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
            wkEmployeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
            wkEmployeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
            wkEmployeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
            wkEmployeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
            wkEmployeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
            // add 2007.05.23 saitoh >>>>>>>>>>
            wkEmployeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
            wkEmployeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
            // add 2007.05.23 saitoh <<<<<<<<<<
			// -- Add St 2012.05.29 30182 R.Tachiya --
			wkEmployeeWork.SalSlipInpBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALSLIPINPBOOTCNTRF"));
			wkEmployeeWork.CustLedgerBootCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLEDGERBOOTCNTRF"));
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

            #endregion

            return wkEmployeeWork;
        }
        #endregion



	}
}
