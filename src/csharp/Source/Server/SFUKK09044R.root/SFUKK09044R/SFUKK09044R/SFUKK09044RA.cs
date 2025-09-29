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
using System.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���z��ʐݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���z��ʐݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.05.09</br>
	/// <br></br>
	/// <br>Update Note: 2007.05.09�@�����@�V���N�����ǉ�</br>
    /// <br>---------------------------------------------------------</br>
    /// <br>Update Note: �t�@�C�����C�A�E�g�ύX</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.05.17</br>
    /// <br></br>
    /// <br>Update Note: 22008 ���� PM.NS�p�ɏC��</br>
    /// </remarks>
	[Serializable]
	public class MoneyKindDB : RemoteDB, IRemoteDB, IMoneyKindDB, IGetSyncdataList
	{
		/// <summary>
		/// ���z��ʐݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		/// </remarks>
		public MoneyKindDB() :																		  
		base("SFUKK09046D", "Broadleaf.Application.Remoting.ParamData.MoneyKindWork", "MONEYKINDURF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));				 
			Debug.WriteLine("MoneyKindDB�R���X�g���N�^");
		}
	
		#region ���ʉ����\�b�h
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z��ʐݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:MoneyKindWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��z��ʐݒ�LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " SearchCnt" + "(" + getdatatype.ToString() + ")");
			retCnt = 0;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retCnt = 0;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = SearchCntMoneyKindUProc(out retCnt, parabyte, readMode, logicalMode);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;
		}                           

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��z���LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode, GetMoneyKindDataType getdatatype)
		{		
			Debug.WriteLine(this.ToString() + " Search" + "(" + getdatatype.ToString() + ")");
			retbyte = null;


            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
                case GetMoneyKindDataType.UserMoneyKindData:
                    {
                        // XML�̓ǂݍ���
                        MoneyKindWork moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork));
                        ArrayList retList = null;

                        status = SearchMoneyKindUProc(out retList, moneykinduWork, readMode, logicalMode, 0);

                        // XML�֕ϊ����A������̃o�C�i����
                        MoneyKindWork[] MoneyKinduWorks = (MoneyKindWork[])retList.ToArray(typeof(MoneyKindWork));
                        retbyte = XmlByteSerializer.Serialize(MoneyKinduWorks);
                            
                        break;
                    }
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}


			return status;	
		}

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̋��z���LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="getdatatype">�擾�Ώۃf�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��z���LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.05.09</br>
        public int Search(out object retList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode, GetMoneyKindDataType getdatatype)
        {
            Debug.WriteLine(this.ToString() + " Search" + "(" + getdatatype.ToString() + ")");

            ArrayList moneykinduList = new ArrayList();
            retList = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            switch (getdatatype)
            {
                case GetMoneyKindDataType.UserMoneyKindData:
                    {
                        // XML�̓ǂݍ���
                        MoneyKindWork moneykinduWork = paraWork as MoneyKindWork;

                        status = SearchMoneyKindUProc(out moneykinduList, moneykinduWork, readMode, logicalMode, 0);

                        retList = moneykinduList;

                        break;
                    }
                case GetMoneyKindDataType.OfferMoneyKindData:
                    break;
            }

            return status;
        }

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z���LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��z���LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt, GetMoneyKindDataType getdatatype)
		{		
			retbyte = null;
			retTotalCnt = 0;
			nextData = false;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			return status;	
		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z��ʂ�߂��܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��z��ʂ�߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public int Read(ref byte[] parabyte , int readMode, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " Read" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = ReadMoneyKindUProc(ref parabyte, readMode);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		/// <summary>
		/// ���z��ʐݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���z��ʐݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public int Write(ref byte[] parabyte, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " Write" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = WriteMoneyKindUProc(ref parabyte);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		/// <summary>
		/// ���z��ʐݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���z��ʐݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public 	int Delete(byte[] parabyte, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " Delete" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = DeleteMoneyKindUProc(parabyte);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		/// <summary>
		/// ���z��ʐݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���z��ʐݒ����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public 	int LogicalDelete(ref byte[] parabyte, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " LogicalDelete" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = LogicalDeleteMoneyKindUProc(ref parabyte, 0);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		/// <summary>
		/// �_���폜���z��ʐݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���z��ʐݒ���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public 	int RevivalLogicalDelete(ref byte[] parabyte, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " Write" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = LogicalDeleteMoneyKindUProc(ref parabyte, 1);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		#endregion

		#region ���z���(���[�U�[�o�^)���\�b�h
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z���(���[�U�[�o�^)LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:MoneyKindWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��z���(���[�U�[�o�^)LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		private int SearchCntMoneyKindUProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			MoneyKindWork moneykinduWork = null;

			retCnt = 0;														   

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT COUNT (*) FROM MONEYKINDURF " + 
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",
						sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand(
						"SELECT COUNT (*) FROM MONEYKINDURF " + 
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",
						sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand(
						"SELECT COUNT (*) FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);

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
				base.WriteErrorLog(ex,"MoneyKindDB.SearchCntMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			
			sqlConnection.Close();			

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z���LIST��S�Ė߂��܂�
		/// </summary>
        /// <param name="retList">��������</param>
        /// <param name="moneykinduWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��z���LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
        private int SearchMoneyKindUProc(out ArrayList retList, MoneyKindWork moneykinduWork, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;

			ArrayList al = new ArrayList();
            retList = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
						"ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
						"ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);

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
							break;
						}
					}
					MoneyKindWork wkMoneyKinduWork = new MoneyKindWork();

					wkMoneyKinduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkMoneyKinduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkMoneyKinduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkMoneyKinduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkMoneyKinduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkMoneyKinduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkMoneyKinduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkMoneyKinduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkMoneyKinduWork.PriceStCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PRICESTCODERF"));
					wkMoneyKinduWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDCODERF"));
					wkMoneyKinduWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MONEYKINDNAMERF"));
					wkMoneyKinduWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDDIVRF"));

					al.Add(wkMoneyKinduWork);

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
				base.WriteErrorLog(ex,"MoneyKindDB.SearchMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

            retList = al;

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z���LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retList">��������</param>
		/// <param name="moneykinduWork">�����p�����[�^</param>
		/// <param name="sqlConnection"></param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��z���LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public int SearchMoneyKindUProc(out ArrayList retList, MoneyKindWork moneykinduWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			retList = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			ArrayList al = new ArrayList();
			try 
			{	
				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
						"ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
						"ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader();
				while(myReader.Read())
				{
					MoneyKindWork wkMoneyKinduWork = new MoneyKindWork();

					wkMoneyKinduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkMoneyKinduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkMoneyKinduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkMoneyKinduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkMoneyKinduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkMoneyKinduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkMoneyKinduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkMoneyKinduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkMoneyKinduWork.PriceStCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PRICESTCODERF"));
					wkMoneyKinduWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDCODERF"));
					wkMoneyKinduWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MONEYKINDNAMERF"));
					wkMoneyKinduWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDDIVRF"));

					al.Add(wkMoneyKinduWork);

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
				base.WriteErrorLog(ex,"MoneyKindDB.SearchMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				if(sqlCommand != null)sqlCommand.Dispose();
			}
			retList = al;

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z���(���[�U�[�o�^)��߂��܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̋��z���(���[�U�[�o�^)��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		private int ReadMoneyKindUProc(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			MoneyKindWork moneykinduWork = new MoneyKindWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand(
					"SELECT * FROM MONEYKINDURF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE",
					sqlConnection);
				//Parameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPriceStCode = sqlCommand.Parameters.Add("@FINDPRICESTCODE", SqlDbType.Int);
				SqlParameter findParaMoneyKindCode = sqlCommand.Parameters.Add("@FINDMONEYKINDCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);
				
				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					moneykinduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					moneykinduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					moneykinduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					moneykinduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					moneykinduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					moneykinduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					moneykinduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					moneykinduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					moneykinduWork.PriceStCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PRICESTCODERF"));
					moneykinduWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDCODERF"));
					moneykinduWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MONEYKINDNAMERF"));
					moneykinduWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDDIVRF"));

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
				base.WriteErrorLog(ex,"MoneyKindDB.ReadMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(moneykinduWork);

			return status;
		}

		/// <summary>
		/// ���z��ʐݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���z��ʐݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		public int WriteMoneyKindUProc(ref byte[] parabyte)
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
				MoneyKindWork moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF FROM MONEYKINDURF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE",
					sqlConnection);

				//Parameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPriceStCode = sqlCommand.Parameters.Add("@FINDPRICESTCODE", SqlDbType.Int);
				SqlParameter findParaMoneyKindCode = sqlCommand.Parameters.Add("@FINDMONEYKINDCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != moneykinduWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (moneykinduWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "UPDATE MONEYKINDURF SET " +
						"CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , " +
						"PRICESTCODERF=@PRICESTCODE , MONEYKINDCODERF=@MONEYKINDCODE , MONEYKINDNAMERF=@MONEYKINDNAME , MONEYKINDDIVRF=@MONEYKINDDIV " +
                        "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE ";
					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
					findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
					findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)moneykinduWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (moneykinduWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
					sqlCommand.CommandText = "INSERT INTO MONEYKINDURF " +
						"(CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, " +
                        "PRICESTCODERF, MONEYKINDCODERF, MONEYKINDNAMERF, MONEYKINDDIVRF) " +
						"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, " +
                        "@PRICESTCODE, @MONEYKINDCODE, @MONEYKINDNAME, @MONEYKINDDIV)";
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)moneykinduWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(myReader.IsClosed == false)myReader.Close();

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
				SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
				SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
				SqlParameter paraPriceStCode = sqlCommand.Parameters.Add("@PRICESTCODE", SqlDbType.Int);
				SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
				SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
				SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
				
				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(moneykinduWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(moneykinduWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(moneykinduWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.LogicalDeleteCode);
				paraPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);
				paraMoneyKindName.Value = SqlDataMediator.SqlSetString(moneykinduWork.MoneyKindName);
				paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindDiv);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(moneykinduWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"MoneyKindDB.WriteMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// ���z��ʏ��̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���z��ʏ��̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		private int LogicalDeleteMoneyKindUProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try		
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				MoneyKindWork moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM MONEYKINDURF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE",
					sqlConnection);

				//Parameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPriceStCode = sqlCommand.Parameters.Add("@FINDPRICESTCODE", SqlDbType.Int);
				SqlParameter findParaMoneyKindCode = sqlCommand.Parameters.Add("@FINDMONEYKINDCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != moneykinduWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                    
					sqlCommand.CommandText = "UPDATE MONEYKINDURF SET " +
						"UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE ";

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
					findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
					findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)moneykinduWork;
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
					else if	(logicalDelCd == 0)	moneykinduWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						moneykinduWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	moneykinduWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(moneykinduWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(moneykinduWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"MoneyKindDB.LogicalDeleteMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// ���z��ʏ��𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���z��ʃI�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : ���z��ʏ��𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		///	<remark>�C���^�[�t�F�C�X���������ׁ̈A�߂�lNORMAL�̂�</remark>
		public int DeleteMoneyKindUProc(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				MoneyKindWork moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM MONEYKINDURF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE",
					sqlConnection);

				//Parameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPriceStCode = sqlCommand.Parameters.Add("@FINDPRICESTCODE", SqlDbType.Int);
				SqlParameter findParaMoneyKindCode = sqlCommand.Parameters.Add("@FINDMONEYKINDCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
					if (_updateDateTime != moneykinduWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE";

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
					findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
					findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);
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
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"MoneyKindDB.DeleteMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;
		}
		#endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̋��z��ʃ}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.08</br>
        public int GetSyncdataList(out ArrayList arraylistdata,SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM MONEYKINDURF  ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToMoneyKindWorkFromReader(ref myReader));

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
        /// �N���X�i�[���� Reader �� MoneyKindWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>MoneyKindWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096 �����@����</br>
        /// <br>Date       : 2007.05.09</br>
        /// </remarks>
        private MoneyKindWork CopyToMoneyKindWorkFromReader(ref SqlDataReader myReader)
        {
            MoneyKindWork wkMoneykinduWork = new MoneyKindWork();

            #region �N���X�֊i�[
            wkMoneykinduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkMoneykinduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkMoneykinduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkMoneykinduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkMoneykinduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkMoneykinduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkMoneykinduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkMoneykinduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkMoneykinduWork.PriceStCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTCODERF"));
            wkMoneykinduWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkMoneykinduWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkMoneykinduWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            #endregion

            return wkMoneykinduWork;
        }
        #endregion


    }
}
