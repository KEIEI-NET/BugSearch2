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
	/// ���l�K�C�hDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���l�K�C�h�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.10.13</br>
	/// <br></br>
    /// <br>Update Note: 2007.05.29 iwa �R���X�g���N�^���s���f�o�b�N�폜</br>
	/// <br>Update Note: 2008.09.17 men VSS536 �i�ǑΉ�</br>
	/// </remarks>
	[Serializable]
	public class NoteGuidBdDB : RemoteDB , INoteGuidBdDB
	{
		/// <summary>
		/// ���l�K�C�hDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		/// </remarks>
		public NoteGuidBdDB() :
			base("SFTOK09406D", "Broadleaf.Application.Remoting.ParamData.NoteGuidBdWork", "NOTEGUIDBDRF")
		{
			//Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));//2007.05.29 iwa del
			//Debug.WriteLine(this.ToString() + " Constructer");//2007.05.29 iwa del
		}

		#region ���l�K�C�h�w�b�_�[���\�b�h
		/// <summary>
		/// ���l�K�C�h�w�b�_�[LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�hLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchCntHeader(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntHeaderProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// ���l�K�C�h�w�b�_�[LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:NoteGuidBdWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�hLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		private int SearchCntHeaderProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
														  
			NoteGuidHdWork noteguidhdWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);

				//�f�[�^���[�h
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchCntHeaderProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			sqlConnection.Close();			

			return status;
		}

		/// <summary>
		/// ���l�K�C�h�w�b�_�[LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h�w�b�_�[LIST��S�Ė߂��܂��B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchHeader(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchHeaderProc(out retobj,paraobj,readMode,logicalMode);
		}

        /// <summary>
        /// ���l�K�C�h�w�b�_�[LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���l�K�C�h�w�b�_�[LIST��S�Ė߂��܂��B</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.10.13</br>
        public int SearchHeader(out ArrayList retList, NoteGuidHdWork noteGuidHdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            retList = null;
            return SearchHeaderProc(out retList, noteGuidHdWork, readMode, logicalMode, ref sqlConnection);
        }
        
        /// <summary>
		/// ���l�K�C�h�w�b�_�[LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�}�X�^�̂̃K�C�hLIST��S�Ė߂��܂��B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		/// </remarks>
		private int SearchHeaderProc(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidHdWork noteguidhdWork = new NoteGuidHdWork();
			noteguidhdWork = null;													

			retobj = null;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				noteguidhdWork = paraobj as NoteGuidHdWork;
																								 
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
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF",sqlConnection);
					
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF",sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY NOTEGUIDEDIVCODERF",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

				while(myReader.Read())
				{
					NoteGuidHdWork wkNoteGuidHdWork = new NoteGuidHdWork();

					wkNoteGuidHdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkNoteGuidHdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkNoteGuidHdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkNoteGuidHdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkNoteGuidHdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkNoteGuidHdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkNoteGuidHdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkNoteGuidHdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkNoteGuidHdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
					wkNoteGuidHdWork.NoteGuideDivName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDEDIVNAMERF"));

					al.Add(wkNoteGuidHdWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchHeaderProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			retobj = al;

			return status;
		}

        /// <summary>
        /// ���l�K�C�h�w�b�_�[LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�}�X�^�̂̃K�C�hLIST��S�Ė߂��܂��B</br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.10.13</br>
        /// </remarks>
        private int SearchHeaderProc(out ArrayList retList, NoteGuidHdWork noteGuidHdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            retList = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlCommand sqlCommand;

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY NOTEGUIDEDIVCODERF", sqlConnection);
                }
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteGuidHdWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    NoteGuidHdWork wkNoteGuidHdWork = new NoteGuidHdWork();

                    wkNoteGuidHdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkNoteGuidHdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkNoteGuidHdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkNoteGuidHdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkNoteGuidHdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkNoteGuidHdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkNoteGuidHdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkNoteGuidHdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkNoteGuidHdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
                    wkNoteGuidHdWork.NoteGuideDivName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTEGUIDEDIVNAMERF"));

                    al.Add(wkNoteGuidHdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "NoteGuidBdDB.SearchHeaderProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            myReader.Close();

            retList = al;

            return status;
        }
        
        /// <summary>
		/// �w�肳�ꂽ�R�[�h�̔��l�K�C�h�w�b�_�[��߂��܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�R�[�h�̔��l�K�C�h��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int ReadHeader(ref byte[] parabyte , int readMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidHdWork noteguidhdWork = new NoteGuidHdWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE", sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					noteguidhdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					noteguidhdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					noteguidhdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					noteguidhdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					noteguidhdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					noteguidhdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					noteguidhdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					noteguidhdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					noteguidhdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
					noteguidhdWork.NoteGuideDivName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDEDIVNAMERF"));

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.ReadHeader:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(noteguidhdWork);

			return status;
		}

		/// <summary>
		/// ���l�K�C�h�w�b�_�[����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h�w�b�_�[����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int WriteHeader(ref byte[] parabyte)
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
				NoteGuidHdWork noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE", sqlConnection);
	
				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != noteguidhdWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (noteguidhdWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "UPDATE NOTEGUIDHDRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , NOTEGUIDEDIVCODERF=@NOTEGUIDEDIVCODE , NOTEGUIDEDIVNAMERF=@NOTEGUIDEDIVNAME " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidhdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (noteguidhdWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
					sqlCommand.CommandText = "INSERT INTO NOTEGUIDHDRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, NOTEGUIDEDIVCODERF, NOTEGUIDEDIVNAMERF) " +
						"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @NOTEGUIDEDIVCODE, @NOTEGUIDEDIVNAME)";
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidhdWork;
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
				SqlParameter paraNoteGuideDivCode = sqlCommand.Parameters.Add("@NOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter paraNoteGuideDivName = sqlCommand.Parameters.Add("@NOTEGUIDEDIVNAME", SqlDbType.NVarChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidhdWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidhdWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(noteguidhdWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.LogicalDeleteCode);
				paraNoteGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);
				paraNoteGuideDivName.Value = SqlDataMediator.SqlSetString(noteguidhdWork.NoteGuideDivName);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(noteguidhdWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.WriteHeader:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// ���l�K�C�h�w�b�_�[����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int LogicalDeleteHeader(ref byte[] parabyte)
		{
			return LogicalDeleteHeaderProc(ref parabyte,0);
		}

		/// <summary>
		/// �_���폜���l�K�C�h�w�b�_�[���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">�p�����[�^�[Work�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���l�K�C�h�w�b�_�[���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int RevivalLogicalDeleteHeader(ref byte[] parabyte)
		{
			return LogicalDeleteHeaderProc(ref parabyte,1);
		}

		/// <summary>
		/// ���l�K�C�h�{�f�B(���[�U�[�ύX��)���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h���̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		private int LogicalDeleteHeaderProc(ref byte[] parabyte,int procMode)
		{
		//	Debug.WriteLine("LogicalDeleteNoteGuidBdU");

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
				NoteGuidHdWork noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE", sqlConnection);
				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != noteguidhdWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE NOTEGUIDHDRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidhdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	noteguidhdWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						noteguidhdWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	noteguidhdWork.LogicalDeleteCode = 0;//�_���폜�t���O������
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
						myReader.Close();
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidhdWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noteguidhdWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(noteguidhdWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.LogicalDeleteHeaderProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// ���l�K�C�h�{�f�B(���[�U�[�ύX��)���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���l�K�C�h�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int DeleteHeader(byte[] parabyte)
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
				NoteGuidHdWork noteguidhdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE", sqlConnection);
				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
					if (_updateDateTime != noteguidhdWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM NOTEGUIDHDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidhdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidhdWork.NoteGuideDivCode);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					sqlConnection.Close();
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
				base.WriteErrorLog(ex,"NoteGuidBdDB.DeleteHeader:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;
		}
		#endregion

		#region ���l�K�C�h�{�f�B���\�b�h
		/// <summary>
		/// ���l�K�C�h�{�f�BLIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:NoteGuidBdWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h�{�f�BLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchCntBody(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntBodyProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// ���l�K�C�h�{�f�BLIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:NoteGuidBdWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�hLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		private int SearchCntBodyProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
														  
			NoteGuidBdWork noteguidbdWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",sqlConnection);
					//�_���폜�敪�ݒ�
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand("SELECT COUNT (*) FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);

				//�f�[�^���[�h
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchCntBodyProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			
			sqlConnection.Close();			

			return status;
		}

		/// <summary>
		/// ���l�K�C�h�{�f�BLIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�hLIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchBody(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			retobj = null;
			return SearchBodyProc(out retobj, paraobj ,readMode,logicalMode);
		}

		/// <summary>
		/// ���l�K�C�h�{�f�BLIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�hLIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		private int SearchBodyProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidBdWork noteguidbdWork = new NoteGuidBdWork();
			noteguidbdWork = null;

			retobj = null;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				noteguidbdWork = paraobj as NoteGuidBdWork;

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
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);
																																											   
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				while(myReader.Read())
				{
					NoteGuidBdWork wkNoteGuidBdWork = new NoteGuidBdWork();

					wkNoteGuidBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkNoteGuidBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkNoteGuidBdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkNoteGuidBdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkNoteGuidBdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkNoteGuidBdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkNoteGuidBdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkNoteGuidBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkNoteGuidBdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
					wkNoteGuidBdWork.NoteGuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDECODERF"));
					wkNoteGuidBdWork.NoteGuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDENAMERF"));
					
					al.Add(wkNoteGuidBdWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchBodyProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			retobj = al;

			return status;

		}
		
		/// <summary>
		/// ���l�K�C�h�{�f�BLIST���w��敪�R�[�h���߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�hLIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int SearchGuideDivCode(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			return SearchGuideDivCodeProc(out retobj, paraobj ,readMode,logicalMode);
		}

		/// <summary>
		/// ���l�K�C�h�{�f�BLIST���w��敪�R�[�h���߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�hLIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 21052 �R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		private int SearchGuideDivCodeProc(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidBdWork noteguidbdWork = new NoteGuidBdWork();
			noteguidbdWork = null;

			retobj = null;

			ArrayList al = new ArrayList();
			try 
			{	
				ArrayList noteGuidBdWorkList = paraobj as ArrayList;
				if((noteGuidBdWorkList != null)&&(noteGuidBdWorkList.Count > 0))
				{
					string strsql = "";
					for(int iCnt=0; iCnt < noteGuidBdWorkList.Count; iCnt++)
					{
						if(iCnt == 0)																						
						{
							strsql = "SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE" + iCnt.ToString();
						}
						else
						{
							strsql = strsql + " UNION SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE" + iCnt.ToString();
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

					SqlCommand sqlCommand;
					noteguidbdWork = noteGuidBdWorkList[0] as NoteGuidBdWork;

					//�f�[�^�Ǎ�
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||	  
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS NOTEGUIDBD ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);

						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS NOTEGUIDBD ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);

						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
						sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS NOTEGUIDBD ORDER BY NOTEGUIDEDIVCODERF, NOTEGUIDECODERF",sqlConnection);
					}

					SqlParameter[] paraGuideDivCode = new SqlParameter[noteGuidBdWorkList.Count];
					for(int iCnt=0; iCnt < noteGuidBdWorkList.Count; iCnt++)
					{
						paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE" + iCnt.ToString(), SqlDbType.Int);
						paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((NoteGuidBdWork)noteGuidBdWorkList[iCnt]).NoteGuideDivCode);
					}
					SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					while(myReader.Read())
					{
						NoteGuidBdWork wkNoteGuidBdWork = new NoteGuidBdWork();

						wkNoteGuidBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkNoteGuidBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkNoteGuidBdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkNoteGuidBdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkNoteGuidBdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkNoteGuidBdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkNoteGuidBdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkNoteGuidBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkNoteGuidBdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
						wkNoteGuidBdWork.NoteGuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDECODERF"));
						wkNoteGuidBdWork.NoteGuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDENAMERF"));

						al.Add(wkNoteGuidBdWork);

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
				base.WriteErrorLog(ex,"NoteGuidBdDB.SearchGuideDivCodeProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if (myReader != null)		// 2008.09.17 men add
			{							// 2008.09.17 men add
				myReader.Close();
			}							// 2008.09.17 men add

			if (sqlConnection != null)	// 2008.09.17 men add
			{							// 2008.09.17 men add
				sqlConnection.Close();
			}							// 2008.09.17 men add

			retobj = al;

			return status;

		}

		/// <summary>
		/// �w�肳�ꂽ�L�[�̔��l�K�C�h�{�f�B��߂��܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�h��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int ReadBody(ref byte[] parabyte , int readMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			NoteGuidBdWork noteguidbdWork = new NoteGuidBdWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE", sqlConnection);

				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter findParaNoteGuideCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDECODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					noteguidbdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					noteguidbdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					noteguidbdWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					noteguidbdWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					noteguidbdWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					noteguidbdWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					noteguidbdWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					noteguidbdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					noteguidbdWork.NoteGuideDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDEDIVCODERF"));
					noteguidbdWork.NoteGuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NOTEGUIDECODERF"));
					noteguidbdWork.NoteGuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NOTEGUIDENAMERF"));

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.ReadBody:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			// XML�֕ϊ����A������̃o�C�i����
			parabyte = XmlByteSerializer.Serialize(noteguidbdWork);

			return status;
		}		

		/// <summary>
		/// ���l�K�C�h�{�f�B(���[�U�[�ύX��)����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int WriteBody(ref byte[] parabyte)
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
				NoteGuidBdWork noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF, NOTEGUIDECODERF FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE", sqlConnection);
	
				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter findParaNoteGuideCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDECODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != noteguidbdWork.UpdateDateTime)
					{
						//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (noteguidbdWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "UPDATE NOTEGUIDBDRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , NOTEGUIDEDIVCODERF=@NOTEGUIDEDIVCODE , NOTEGUIDECODERF=@NOTEGUIDECODE , NOTEGUIDENAMERF=@NOTEGUIDENAME " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
					findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidbdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (noteguidbdWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//�V�K�쐬����SQL���𐶐�
					sqlCommand.CommandText = "INSERT INTO NOTEGUIDBDRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, NOTEGUIDEDIVCODERF, NOTEGUIDECODERF, NOTEGUIDENAMERF) " +
						"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @NOTEGUIDEDIVCODE, @NOTEGUIDECODE, @NOTEGUIDENAME)";
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidbdWork;
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
				SqlParameter paraNoteGuideDivCode = sqlCommand.Parameters.Add("@NOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter paraNoteGuideCode = sqlCommand.Parameters.Add("@NOTEGUIDECODE", SqlDbType.Int);
				SqlParameter paraNoteGuideName = sqlCommand.Parameters.Add("@NOTEGUIDENAME", SqlDbType.NVarChar);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidbdWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidbdWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(noteguidbdWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.LogicalDeleteCode);
				paraNoteGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				paraNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);
				paraNoteGuideName.Value = SqlDataMediator.SqlSetString(noteguidbdWork.NoteGuideName);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(noteguidbdWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.WriteBody:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// ���l�K�C�h�{�f�B(���[�U�[�ύX��)����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int LogicalDeleteBody(ref byte[] parabyte)
		{
			return LogicalDeleteBodyProc(ref parabyte,0);
		}

		/// <summary>
		/// �_���폜���l�K�C�h�{�f�B(���[�U�[�ύX��)���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">�p�����[�^�[Work�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���l�K�C�h���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int RevivalLogicalDeleteBody(ref byte[] parabyte)
		{
			return LogicalDeleteBodyProc(ref parabyte,1);
		}

		/// <summary>
		/// ���l�K�C�h�{�f�B(���[�U�[�ύX��)���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h���̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		private int LogicalDeleteBodyProc(ref byte[] parabyte,int procMode)
		{
		//	Debug.WriteLine("LogicalDeleteNoteGuidBdU");

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
				NoteGuidBdWork noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE", sqlConnection);
				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter findParaNoteGuideCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDECODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					if (_updateDateTime != noteguidbdWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//���݂̘_���폜�敪���擾
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE NOTEGUIDBDRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
					findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)noteguidbdWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
						myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	noteguidbdWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
					else						noteguidbdWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
				}
				else
				{
					if		(logicalDelCd == 1)	noteguidbdWork.LogicalDeleteCode = 0;//�_���폜�t���O������
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
						myReader.Close();
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(noteguidbdWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(noteguidbdWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				parabyte = XmlByteSerializer.Serialize(noteguidbdWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"NoteGuidBdDB.LogicalDeleteBodyProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// ���l�K�C�h�{�f�B(���[�U�[�ύX��)���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���l�K�C�h�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		public int DeleteBody(byte[] parabyte)
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
				NoteGuidBdWork noteguidbdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, NOTEGUIDEDIVCODERF FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE", sqlConnection);
				//Prameter�I�u�W�F�N�g�̍쐬
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDEDIVCODE", SqlDbType.Int);
				SqlParameter findParaNoteGuideCode = sqlCommand.Parameters.Add("@FINDNOTEGUIDECODE", SqlDbType.Int);

				//Parameter�I�u�W�F�N�g�֒l�ݒ�
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
				findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
				findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
					if (_updateDateTime != noteguidbdWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM NOTEGUIDBDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND NOTEGUIDEDIVCODERF=@FINDNOTEGUIDEDIVCODE AND NOTEGUIDECODERF=@FINDNOTEGUIDECODE";
					//KEY�R�}���h���Đݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(noteguidbdWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideDivCode);
					findParaNoteGuideCode.Value = SqlDataMediator.SqlSetInt32(noteguidbdWork.NoteGuideCode);
				}
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					sqlConnection.Close();
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
				base.WriteErrorLog(ex,"NoteGuidBdDB.DeleteBody:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			myReader.Close();
			sqlConnection.Close();

			return status;
		}
		#endregion

	}
}
