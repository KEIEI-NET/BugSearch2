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

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ��������ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ��������ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.07.20</br>
	/// <br></br>
	/// <br>Update Note: �t�@�C�����C�A�E�g�ύX</br>
    /// <br>Note       : 20036�@�ē��@�떾</br>
    /// <br>Programmer : 2007.06.27</br>
    /// <br></br>
    /// <br>Update Note: 22008 ���� PM.NS�Ή�</br>
    /// <br></br>
    /// </remarks>
	[Serializable]
	public class BillPrtStDB : RemoteDB, IRemoteDB, IBillPrtStDB
	{
		/// <summary>
		/// ��������ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>																	 
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>												
		/// </remarks>
		public BillPrtStDB() :																	
		base("SFUKK09086D", "Broadleaf.Application.Remoting.ParamData.BillPrtStWork", "BILLPRTSTRF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Debug.WriteLine("BillPrtStDB�R���X�g���N�^");
		}
																						   
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̐�������ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobject">��������</param>
		/// <param name="paraobject">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐�������ݒ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>
		public int Search(out object retobject,object paraobject, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			Debug.WriteLine("Search");
            return SearchProc(out retobject,paraobject ,readMode,logicalMode);

        }

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̐�������ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobject">��������</param>
		/// <param name="paraobject">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐�������ݒ�LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>
        public int SearchProc(out object retobject, object paraobject, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retobject = null;
            try 
			{	

				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
                
                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchProc(out retobject, paraobject, readMode, logicalMode, ref sqlConnection);
            }

            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BillPrtStDB.SearchProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// �w�肳�ꂽ��ƃR�[�h�̐�������ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobject">��������</param>
        /// <param name="paraobject">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐�������ݒ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.07.20</br>
        public int SearchProc(out object retobject, object paraobject, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
             return SearchProcProc(out retobject, paraobject, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐�������ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobject">��������</param>
        /// <param name="paraobject">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐�������ݒ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.07.20</br>
        private int SearchProcProc(out object retobject, object paraobject, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;

			BillPrtStWork billprtstWork = new BillPrtStWork();
			billprtstWork = null;

			retobject = null;

			ArrayList al = new ArrayList();
			try 
			{	   
				// XML�̓ǂݍ���
				billprtstWork = paraobject as BillPrtStWork;
			
				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM BILLPRTSTRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " +
						"ORDER BY BILLPRTSTMNGCDRF",
						sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM BILLPRTSTRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
						"ORDER BY BILLPRTSTMNGCDRF",
						sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM BILLPRTSTRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
						"ORDER BY BILLPRTSTMNGCDRF",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader();
				while(myReader.Read())
				{
					BillPrtStWork wkBillPrtStWork = new BillPrtStWork();

                    wkBillPrtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkBillPrtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkBillPrtStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkBillPrtStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkBillPrtStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkBillPrtStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkBillPrtStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkBillPrtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkBillPrtStWork.BillPrtStMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPRTSTMNGCDRF"));
                    wkBillPrtStWork.BillTableOutCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLTABLEOUTCDRF"));
                    wkBillPrtStWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));
                    wkBillPrtStWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));
                    wkBillPrtStWork.BillLastDayPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLLASTDAYPRTDIVRF"));
                    wkBillPrtStWork.BillCoNmPrintOutCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLCONMPRINTOUTCDRF"));
                    wkBillPrtStWork.BillBankNmPrintOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLBANKNMPRINTOUTRF"));
                    wkBillPrtStWork.CustTelNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTTELNOPRTDIVCDRF"));

					al.Add(wkBillPrtStWork);
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
				base.WriteErrorLog(ex,"BillPrtStDB.SearchProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();

			// XML�֕ϊ����A������̃o�C�i����
			retobject = al;

			return status;

		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̐�������ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">BillPrtStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐�������ݒ��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
            return this.ReadProc(ref parabyte, readMode);
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐�������ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">BillPrtStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐�������ݒ��߂��܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.07.20</br>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
			Debug.WriteLine("Read");			

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			BillPrtStWork billprtstWork = new BillPrtStWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				billprtstWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand(
					"SELECT * FROM BILLPRTSTRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD",
					sqlConnection);
				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findparaBillPrtStMngCd = sqlCommand.Parameters.Add("@FINDBILLPRTSTMNGCD", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
				findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);
				
				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
                    // del 2007.06.27 saito ���ꕔ���ڍ폜
                    billprtstWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    billprtstWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    billprtstWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    billprtstWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    billprtstWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    billprtstWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    billprtstWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    billprtstWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    billprtstWork.BillPrtStMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPRTSTMNGCDRF"));
                    billprtstWork.BillTableOutCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLTABLEOUTCDRF"));
                    billprtstWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));
                    billprtstWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));
                    billprtstWork.BillLastDayPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLLASTDAYPRTDIVRF"));
                    billprtstWork.BillCoNmPrintOutCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLCONMPRINTOUTCDRF"));
                    billprtstWork.BillBankNmPrintOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLBANKNMPRINTOUTRF"));
                    billprtstWork.CustTelNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTTELNOPRTDIVCDRF"));

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
				base.WriteErrorLog(ex,"BillPrtStDB.Read:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(billprtstWork);

			return status;
		}

		/// <summary>
		/// ��������ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">BillPrtStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ��������ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>
		public int Write(ref byte[] parabyte)
		{
            return this.WriteProc(ref parabyte);
        }
        /// <summary>
        /// ��������ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">BillPrtStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��������ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.07.20</br>
        private int WriteProc(ref byte[] parabyte)
        {
			Debug.WriteLine("Write");
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				BillPrtStWork billprtstWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF FROM BILLPRTSTRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD",
					sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaBillPrtStMngCd = sqlCommand.Parameters.Add("@FINDBILLPRTSTMNGCD", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
				findParaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != billprtstWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (billprtstWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

                    sqlCommand.CommandText = "UPDATE BILLPRTSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , BILLPRTSTMNGCDRF=@BILLPRTSTMNGCD , BILLTABLEOUTCDRF=@BILLTABLEOUTCD , TOTALBILLOUTPUTDIVRF=@TOTALBILLOUTPUTDIV , DETAILBILLOUTPUTCODERF=@DETAILBILLOUTPUTCODE , BILLLASTDAYPRTDIVRF=@BILLLASTDAYPRTDIV , BILLCONMPRINTOUTCDRF=@BILLCONMPRINTOUTCD , BILLBANKNMPRINTOUTRF=@BILLBANKNMPRINTOUT , CUSTTELNOPRTDIVCDRF=@CUSTTELNOPRTDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD ";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
					findParaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)billprtstWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (billprtstWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = "INSERT INTO BILLPRTSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BILLPRTSTMNGCDRF, BILLTABLEOUTCDRF, TOTALBILLOUTPUTDIVRF, DETAILBILLOUTPUTCODERF, BILLLASTDAYPRTDIVRF, BILLCONMPRINTOUTCDRF, BILLBANKNMPRINTOUTRF, CUSTTELNOPRTDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @BILLPRTSTMNGCD, @BILLTABLEOUTCD, @TOTALBILLOUTPUTDIV, @DETAILBILLOUTPUTCODE, @BILLLASTDAYPRTDIV, @BILLCONMPRINTOUTCD, @BILLBANKNMPRINTOUT, @CUSTTELNOPRTDIVCD) ";
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)billprtstWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(myReader.IsClosed == false)myReader.Close();

                //Prameter�I�u�W�F�N�g�̍쐬
                // del 2007.06.27 saito ���ꕔ���ڍ폜
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraBillPrtStMngCd = sqlCommand.Parameters.Add("@BILLPRTSTMNGCD", SqlDbType.Int);
                SqlParameter paraBillTableOutCd = sqlCommand.Parameters.Add("@BILLTABLEOUTCD", SqlDbType.Int);
                SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                SqlParameter paraBillLastDayPrtDiv = sqlCommand.Parameters.Add("@BILLLASTDAYPRTDIV", SqlDbType.Int);
                SqlParameter paraBillCoNmPrintOutCd = sqlCommand.Parameters.Add("@BILLCONMPRINTOUTCD", SqlDbType.Int);
                SqlParameter paraBillBankNmPrintOut = sqlCommand.Parameters.Add("@BILLBANKNMPRINTOUT", SqlDbType.Int);
                SqlParameter paraCustTelNoPrtDivCd = sqlCommand.Parameters.Add("@CUSTTELNOPRTDIVCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                // del 2007.06.27 saito ���ꕔ���ڍ폜
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billprtstWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billprtstWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(billprtstWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(billprtstWork.LogicalDeleteCode);
                paraBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);
                paraBillTableOutCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillTableOutCd);
                paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(billprtstWork.TotalBillOutputDiv);
                paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(billprtstWork.DetailBillOutputCode);
                paraBillLastDayPrtDiv.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillLastDayPrtDiv);
                paraBillCoNmPrintOutCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillCoNmPrintOutCd);
                paraBillBankNmPrintOut.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillBankNmPrintOut);
                paraCustTelNoPrtDivCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.CustTelNoPrtDivCd);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(billprtstWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"BillPrtStDB.Write:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// ��������ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">BillPrtStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ��������ݒ����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,0);
		}

		/// <summary>
		/// �_���폜��������ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">BillPrtStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜��������ݒ���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,1);
		}

		/// <summary>
		/// ��������ݒ���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">BillPrtStWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ��������ݒ���̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			Debug.WriteLine("LogicalDelete");

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
				BillPrtStWork billprtstWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM BILLPRTSTRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD",
					sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findparaBillPrtStMngCd = sqlCommand.Parameters.Add("@FINDBILLPRTSTMNGCD", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
				findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != billprtstWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE BILLPRTSTRF SET " +
						"UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
					findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)billprtstWork;
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
					else if	(logicalDelCd == 0)	billprtstWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						billprtstWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	billprtstWork.LogicalDeleteCode = 0;//�_���폜�t���O������
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billprtstWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(billprtstWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(billprtstWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(billprtstWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"BillPrtStDB.LogicalDeleteProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// ��������ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">��������ݒ�I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : ��������ݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.07.20</br>
		public int Delete(byte[] parabyte)
		{
            return this.DeleteProc(parabyte);
        }
        /// <summary>
        /// ��������ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">��������ݒ�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ��������ݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.07.20</br>
        private int DeleteProc(byte[] parabyte)
        {
			Debug.WriteLine("Delete");

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				BillPrtStWork billprtstWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF FROM BILLPRTSTRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD",
					sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findparaBillPrtStMngCd = sqlCommand.Parameters.Add("@FINDBILLPRTSTMNGCD", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
				findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
					if (_updateDateTime != billprtstWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
																			 
					sqlCommand.CommandText = "DELETE FROM BILLPRTSTRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLPRTSTMNGCDRF=@FINDBILLPRTSTMNGCD";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billprtstWork.EnterpriseCode);
					findparaBillPrtStMngCd.Value = SqlDataMediator.SqlSetInt32(billprtstWork.BillPrtStMngCd);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
				base.WriteErrorLog(ex,"BillPrtStDB.Delete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;
		}
	}
}
