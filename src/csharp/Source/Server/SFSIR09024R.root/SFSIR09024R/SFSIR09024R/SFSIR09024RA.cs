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
	/// �x���ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �x���ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.04.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class PaymentSetDB : RemoteDB, IRemoteDB, IPaymentSetDB
	{
		/// <summary>
		/// �x���ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		/// </remarks>
		public PaymentSetDB() :
		base("SFSIR09026D", "Broadleaf.Application.Remoting.ParamData.PaymentSetWork", "PAYMENTSETRF")
		{
		}
		#region ���N���X���p���������\�b�h
//		/// <summary>
//		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂�
//		/// </summary>
//		/// <param name="retbyte">��������</param>
//		/// <param name="parabyte">�����p�����[�^</param>
//		/// <param name="readMode">�����敪</param>
//		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂�</br>
//		/// <br>Programmer : 21015�@�����@�F��</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,int readCnt)
//		{
//			return base.SearchDB(out retbyte, parabyte, readMode);
//		}
//
//		/// <summary>
//		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ��߂��܂�
//		/// </summary>
//		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
//		/// <param name="readMode">�����敪</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ��߂��܂�</br>
//		/// <br>Programmer : 21015�@�����@�F��</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int Read(ref byte[] parabyte , int readMode)
//		{
//			return base.ReadDB(ref parabyte, readMode);
//		}
//
//		/// <summary>
//		/// ���Џ��ݒ����o�^�A�X�V���܂�
//		/// </summary>
//		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
//		/// <param name="writeMode">�o�^�A�X�V���[�h</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : ���Џ��ݒ����o�^�A�X�V���܂�</br>
//		/// <br>Programmer : 21015�@�����@�F��</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int Write(ref byte[] parabyte, int writeMode)
//		{
//			return base.WriteDB(ref parabyte, writeMode);
//		}
//
//		/// <summary>
//		/// ���Џ���_���폜���܂�
//		/// </summary>
//		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
//		/// <param name="deleteMode">�폜���[�h</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : ���Џ���_���폜���܂�</br>
//		/// <br>Programmer : 21015�@�����@�F��</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int LogicalDelete(ref byte[] parabyte, int deleteMode)
//		{
//			return base.LogicalDelete(ref parabyte, deleteMode);
//		}
//		
//		/// <summary>
//		/// ���Џ��𕨗��폜���܂�
//		/// </summary>
//		/// <param name="parabyte">���Џ��I�u�W�F�N�g</param>
//		/// <param name="deleteMode">�폜���[�h</param>
//		/// <returns></returns>
//		/// <br>Note       : ���Џ��𕨗��폜���܂�</br>
//		/// <br>Programmer : 21015�@�����@�F��</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int Delete(byte[] parabyte, int deleteMode)
//		{
//			return base.Delete(ref parabyte, deleteMode);
//		}

		#endregion

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎x���ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:PaymentSetWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎x���ݒ�LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎x���ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:PaymentSetWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎x���ݒ�LIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;

			PaymentSetWork paymentsetWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT COUNT (*) FROM PAYMENTSETRF " + 
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
						"SELECT COUNT (*) FROM PAYMENTSETRF " + 
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
						"SELECT COUNT (*) FROM PAYMENTSETRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

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
				base.WriteErrorLog(ex,"PaymentSetDB.SearchCntProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎x��LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎x��LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
		}

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎x��LIST��S�Ė߂��܂��i�_���폜�����j�R�l�N�V�����w��^
        /// </summary>
        /// <param name="retbyte">��������</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎x��LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.04.13</br>
        public int Search(out PaymentSetWork[] outpaymentSetWork, PaymentSetWork paymentsetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int retTotalCnt;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommandCount = null;
            SqlCommand sqlCommand = null;

            //PaymentSetWork paymentsetWork = new PaymentSetWork();
            outpaymentSetWork = null;

            //retbyte = null;

            //��������0�ŏ�����
            retTotalCnt = 0;

            //�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
            int _readCnt = 0;
            int readCnt = 0;
            if (_readCnt > 0) _readCnt += 1;
            //�����R�[�h�����ŏ�����
            //nextData = false;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
                if (readCnt > 0)
                {
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommandCount = new SqlCommand(
                            "SELECT COUNT (*) FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",
                            sqlConnection);
                        //�_���폜�敪�ݒ�
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommandCount = new SqlCommand(
                            "SELECT COUNT (*) FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",
                            sqlConnection);
                        //�_���폜�敪�ݒ�
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommandCount = new SqlCommand(
                            "SELECT COUNT (*) FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",
                            sqlConnection);
                    }
                    SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

                    retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                }

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    //�����w�薳���̏ꍇ
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand(
                            "SELECT * FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY PAYSTMNGNORF",
                            sqlConnection);
                    }
                    else
                    {
                        //�ꌏ�ڃ��[�h�̏ꍇ
                        if (paymentsetWork.PayStMngNo == 0)
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                        }
                        //Next���[�h�̏ꍇ
                        else
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                            SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
                            paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    //�����w�薳���̏ꍇ
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand(
                            "SELECT * FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
                            "ORDER BY PAYSTMNGNORF",
                            sqlConnection);
                    }
                    else
                    {
                        //�ꌏ�ڃ��[�h�̏ꍇ
                        if (paymentsetWork.PayStMngNo == 0)
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                        }
                        //Next���[�h�̏ꍇ
                        else
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                            SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
                            paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    //�����w�薳���̏ꍇ
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand(
                            "SELECT * FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
                            "ORDER BY PAYSTMNGNORF",
                            sqlConnection);
                    }
                    else
                    {
                        //�ꌏ�ڃ��[�h�̏ꍇ
                        if (paymentsetWork.PayStMngNo == 0)
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                        }
                        else
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                            SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
                            paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
                        }
                    }
                }
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

                //myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                myReader = sqlCommand.ExecuteReader();
                int retCnt = 0;
                while (myReader.Read())
                {
                    //�߂�l�J�E���^�J�E���g
                    retCnt += 1;
                    if (readCnt > 0)
                    {
                        //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
                        if (readCnt < retCnt)
                        {
                            //nextData = true;
                            break;
                        }
                    }
                    PaymentSetWork wkPaymentSetWork = new PaymentSetWork();

                    wkPaymentSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkPaymentSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkPaymentSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkPaymentSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkPaymentSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkPaymentSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkPaymentSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkPaymentSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkPaymentSetWork.PayStMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMNGNORF"));
                    wkPaymentSetWork.PayStMoneyKindCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD1RF"));
                    wkPaymentSetWork.PayStMoneyKindCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD2RF"));
                    wkPaymentSetWork.PayStMoneyKindCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD3RF"));
                    wkPaymentSetWork.PayStMoneyKindCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD4RF"));
                    wkPaymentSetWork.PayStMoneyKindCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD5RF"));
                    wkPaymentSetWork.PayStMoneyKindCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD6RF"));
                    wkPaymentSetWork.PayStMoneyKindCd7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD7RF"));
                    wkPaymentSetWork.PayStMoneyKindCd8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD8RF"));
                    wkPaymentSetWork.PayStMoneyKindCd9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD9RF"));
                    wkPaymentSetWork.PayStMoneyKindCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD10RF"));

                    al.Add(wkPaymentSetWork);

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
                base.WriteErrorLog(ex, "PaymentSetDB.SearchProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader.IsClosed == false) myReader.Close();

                if (sqlCommandCount != null)
                {
                    sqlCommandCount.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                /*
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
                 */
            }

            // XML�֕ϊ����A������̃o�C�i����
            outpaymentSetWork = (PaymentSetWork[])al.ToArray(typeof(PaymentSetWork));
            
            return status;

        }

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎x��LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎x��LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎x��LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎x��LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommandCount = null;
			SqlCommand sqlCommand = null;

			PaymentSetWork paymentsetWork = new PaymentSetWork();
			paymentsetWork = null;

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
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
				if (readCnt > 0)
				{
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommandCount = new SqlCommand(
							"SELECT COUNT (*) FROM PAYMENTSETRF " + 
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",
							sqlConnection);
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommandCount = new SqlCommand(
							"SELECT COUNT (*) FROM PAYMENTSETRF " + 
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",
							sqlConnection);
						//�_���폜�敪�ݒ�
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
						sqlCommandCount = new SqlCommand(
							"SELECT COUNT (*) FROM PAYMENTSETRF " + 
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",
							sqlConnection);
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//�����w�薳���̏ꍇ
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand(
							"SELECT * FROM PAYMENTSETRF " +
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY PAYSTMNGNORF",
							sqlConnection);
					}
					else
					{	
						//�ꌏ�ڃ��[�h�̏ꍇ
						if (paymentsetWork.PayStMngNo == 0)
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " + 
								"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
						}
							//Next���[�h�̏ꍇ
						else
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
							SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
							paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
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
						sqlCommand = new SqlCommand(
							"SELECT * FROM PAYMENTSETRF " +
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
							"ORDER BY PAYSTMNGNORF",
							sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if (paymentsetWork.PayStMngNo == 0)
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
						}
							//Next���[�h�̏ꍇ
						else
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
							SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
							paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
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
						sqlCommand = new SqlCommand(
							"SELECT * FROM PAYMENTSETRF " +
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
							"ORDER BY PAYSTMNGNORF",
							sqlConnection);
					}
					else
					{
						//�ꌏ�ڃ��[�h�̏ꍇ
						if (paymentsetWork.PayStMngNo == 0)
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY PAYSTMNGNORF",
								sqlConnection);
						}
						else
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
							SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
							paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

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
					PaymentSetWork wkPaymentSetWork = new PaymentSetWork();

					wkPaymentSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkPaymentSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkPaymentSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkPaymentSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkPaymentSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkPaymentSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkPaymentSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkPaymentSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkPaymentSetWork.PayStMngNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMNGNORF"));
					wkPaymentSetWork.PayStMoneyKindCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD1RF"));
					wkPaymentSetWork.PayStMoneyKindCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD2RF"));
    				wkPaymentSetWork.PayStMoneyKindCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD3RF"));
					wkPaymentSetWork.PayStMoneyKindCd4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD4RF"));
					wkPaymentSetWork.PayStMoneyKindCd5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD5RF"));
					wkPaymentSetWork.PayStMoneyKindCd6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD6RF"));
					wkPaymentSetWork.PayStMoneyKindCd7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD7RF"));
					wkPaymentSetWork.PayStMoneyKindCd8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD8RF"));
					wkPaymentSetWork.PayStMoneyKindCd9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD9RF"));
                    wkPaymentSetWork.PayStMoneyKindCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD10RF"));

					al.Add(wkPaymentSetWork);

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
				base.WriteErrorLog(ex,"PaymentSetDB.SearchProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommandCount != null)
				{
					sqlCommandCount.Dispose();
				}
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			// XML�֕ϊ����A������̃o�C�i����
			PaymentSetWork[] PaymentSetWorks = (PaymentSetWork[])al.ToArray(typeof(PaymentSetWork));
			retbyte = XmlByteSerializer.Serialize(PaymentSetWorks);

			return status;

		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎x���ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎x���ݒ��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		public int Read(ref byte[] parabyte , int readMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			PaymentSetWork paymentsetWork = new PaymentSetWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				sqlCommand = new SqlCommand(
					"SELECT * FROM PAYMENTSETRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO",
					sqlConnection);
				//Parameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					paymentsetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					paymentsetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					paymentsetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					paymentsetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					paymentsetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					paymentsetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					paymentsetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					paymentsetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					paymentsetWork.PayStMngNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMNGNORF"));
					paymentsetWork.PayStMoneyKindCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD1RF"));
					paymentsetWork.PayStMoneyKindCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD2RF"));
					paymentsetWork.PayStMoneyKindCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD3RF"));
					paymentsetWork.PayStMoneyKindCd4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD4RF"));
					paymentsetWork.PayStMoneyKindCd5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD5RF"));
					paymentsetWork.PayStMoneyKindCd6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD6RF"));
					paymentsetWork.PayStMoneyKindCd7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD7RF"));
					paymentsetWork.PayStMoneyKindCd8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD8RF"));
					paymentsetWork.PayStMoneyKindCd9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD9RF"));
                    paymentsetWork.PayStMoneyKindCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD10RF"));

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
				base.WriteErrorLog(ex,"PaymentSetDB.Read:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(paymentsetWork);

			return status;
		}

		/// <summary>
		/// �x���ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �x���ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				PaymentSetWork paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, PAYSTMNGNORF FROM PAYMENTSETRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO", 
					sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
				
				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
				
				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != paymentsetWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (paymentsetWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}

					sqlCommand.CommandText = "UPDATE PAYMENTSETRF SET " +
                        "CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PAYSTMNGNORF=@PAYSTMNGNO , PAYSTMONEYKINDCD1RF=@PAYSTMONEYKINDCD1 , PAYSTMONEYKINDCD2RF=@PAYSTMONEYKINDCD2 , PAYSTMONEYKINDCD3RF=@PAYSTMONEYKINDCD3 , PAYSTMONEYKINDCD4RF=@PAYSTMONEYKINDCD4 , PAYSTMONEYKINDCD5RF=@PAYSTMONEYKINDCD5 , PAYSTMONEYKINDCD6RF=@PAYSTMONEYKINDCD6 , PAYSTMONEYKINDCD7RF=@PAYSTMONEYKINDCD7 , PAYSTMONEYKINDCD8RF=@PAYSTMONEYKINDCD8 , PAYSTMONEYKINDCD9RF=@PAYSTMONEYKINDCD9 , PAYSTMONEYKINDCD10RF=@PAYSTMONEYKINDCD10 " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
					findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
					
					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)paymentsetWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (paymentsetWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
					sqlCommand.CommandText = "INSERT INTO PAYMENTSETRF " +
                        "(CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYSTMNGNORF, PAYSTMONEYKINDCD1RF, PAYSTMONEYKINDCD2RF, PAYSTMONEYKINDCD3RF, PAYSTMONEYKINDCD4RF, PAYSTMONEYKINDCD5RF, PAYSTMONEYKINDCD6RF, PAYSTMONEYKINDCD7RF, PAYSTMONEYKINDCD8RF, PAYSTMONEYKINDCD9RF , PAYSTMONEYKINDCD10RF ) " +
                        "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PAYSTMNGNO, @PAYSTMONEYKINDCD1, @PAYSTMONEYKINDCD2, @PAYSTMONEYKINDCD3, @PAYSTMONEYKINDCD4, @PAYSTMONEYKINDCD5, @PAYSTMONEYKINDCD6, @PAYSTMONEYKINDCD7, @PAYSTMONEYKINDCD8, @PAYSTMONEYKINDCD9, @PAYSTMONEYKINDCD10)";
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)paymentsetWork;
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
				SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@PAYSTMNGNO", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd1 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD1", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd2 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD2", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd3 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD3", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd4 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD4", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd5 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD5", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd6 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD6", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd7 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD7", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd8 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD8", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd9 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD9", SqlDbType.Int);
                SqlParameter paraPayStMoneyKindCd10 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD10", SqlDbType.Int);
				
				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentsetWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentsetWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentsetWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.LogicalDeleteCode);
				paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
				paraPayStMoneyKindCd1.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd1);
				paraPayStMoneyKindCd2.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd2);
				paraPayStMoneyKindCd3.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd3);
				paraPayStMoneyKindCd4.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd4);
				paraPayStMoneyKindCd5.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd5);
				paraPayStMoneyKindCd6.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd6);
				paraPayStMoneyKindCd7.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd7);
				paraPayStMoneyKindCd8.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd8);
				paraPayStMoneyKindCd9.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd9);
                paraPayStMoneyKindCd10.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd10);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(paymentsetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"PaymentSetDB.Write:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;

		}

		/// <summary>
		/// �x������_���폜���܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �x������_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,0);
		}

		/// <summary>
		/// �_���폜�x�����𕜊����܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�x�����𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,1);
		}

		/// <summary>
		/// �x�����̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �x�����̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			try		
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				PaymentSetWork paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, PAYSTMNGNORF FROM PAYMENTSETRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO",
					sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != paymentsetWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE PAYMENTSETRF SET " +
						"UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
					findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)paymentsetWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					return status;
				}
				if(myReader.IsClosed == false)myReader.Close();

				//�_���폜���[�h�̏ꍇ
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
						return status;
					}
					else if	(logicalDelCd == 0)	paymentsetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						paymentsetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	paymentsetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentsetWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(paymentsetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"PaymentSetDB.LogicalDeleteProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;

		}

		/// <summary>
		/// �x�����𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">�x���I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : �x�����𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				PaymentSetWork paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, PAYSTMNGNORF FROM PAYMENTSETRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO", 
					sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
					if (_updateDateTime != paymentsetWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM PAYMENTSETRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
					findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
				base.WriteErrorLog(ex,"PaymentSetDB.Delete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;
		}
	}
}
