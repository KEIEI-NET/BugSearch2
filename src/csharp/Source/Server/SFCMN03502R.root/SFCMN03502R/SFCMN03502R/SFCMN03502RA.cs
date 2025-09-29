using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �t�F���J�Ǘ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�F���J�Ǘ��̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 22011�@�������l</br>
	/// <br>Date       : 2008.10.30</br>
    /// <br></br>
    /// <br>Update Note: 2010.02.18  22018 ��� ���b</br>
    /// <br>           : PM.NS�Ή�</br>
    /// <br>           : �@�ENSServiceJobAccess���g�p���Ȃ��悤�ɕύX�B(SFCMN00060C.dll�̎Q�Ƃ��폜)</br>
    /// </remarks>
	[Serializable]
	public class FeliCaMngDB : RemoteDB , IFeliCaMngDB
	{
		/// <summary>
		/// �t�F���J�Ǘ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 22011�@�������l</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		public FeliCaMngDB() : base("SFCMN03504D","Broadleaf.Application.Remoting.ParamData.FeliCaMngWork", "FELICAMNGRF")
		{
			//�R�l�N�V����������擾�Ή�����������
			//�����ӁF�R���X�g���N�^�ŃR�l�N�V������������擾���Ȃ�
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃t�F���J�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="felicaMngWork">��������</param>
        /// <param name="parafelicaMngWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int Search(out object felicaMngWork, object parafelicaMngWork, ConstantManagement.LogicalMode logicalMode)
        {
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Search");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            felicaMngWork = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                FeliCaMngWork paraFelicaMngWk = parafelicaMngWork as FeliCaMngWork;
                //SQL�R�l�N�V�����I�u�W�F�N�g�쐬
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("Search Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", paraFelicaMngWk.EnterpriseCode, paraFelicaMngWk.FeliCaIDm, paraFelicaMngWk.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<
                
                status = Search(out felicaMngWork, paraFelicaMngWk, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FeliCaMngDB.Search Exception = " + ex.Message);
                felicaMngWork = new ArrayList();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = "FeliCaMngDB.Search Exception = " + ex.Message;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                // ���R�l�N�V�����j��
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃t�F���J�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="felicaMngWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        public int Search(out object retList, FeliCaMngWork felicaMngWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Search2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            ArrayList felicaMngLs = new ArrayList();
            try
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("Search Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
                }

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);

                //FeliCa�Ǘ���ʂ����ʂłȂ����
                if (felicaMngWork.FeliCaMngKind != 0)
                {
                    sqlCommand.CommandText += " AND FELICAMNGKINDRF = @FELICAMNGKIND";
                    SqlParameter findParaFelicaMngKind = sqlCommand.Parameters.Add("@FELICAMNGKIND", SqlDbType.Int);
                    findParaFelicaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);
                }

                // �^�C���A�E�g���Ԃ�ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    FeliCaMngWork wkFeliCaMngWork = new FeliCaMngWork();

                    wkFeliCaMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFeliCaMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFeliCaMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFeliCaMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFeliCaMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFeliCaMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFeliCaMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFeliCaMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFeliCaMngWork.FeliCaIDm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FELICAIDMRF"));
                    wkFeliCaMngWork.FeliCaMngKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FELICAMNGKINDRF"));
                    wkFeliCaMngWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));

                    felicaMngLs.Add(wkFeliCaMngWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
                errMsg = "FeliCaMngDB.Search Exception = " + ex.Message;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            retList = felicaMngLs;

            return status;
        }

		/// <summary>
		/// �w�肳�ꂽ�t�F���J�Ǘ�Guid�̃t�F���J�Ǘ���߂��܂�
		/// </summary>
		/// <param name="paraObj">FeliCaMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int Read(ref object paraObj )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Read");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

			try
			{
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				
                //SQL�R�l�N�V�����I�u�W�F�N�g�쐬
				sqlConnection = new SqlConnection( connectionText );
				sqlConnection.Open();
				FeliCaMngWork felicaMngWork = paraObj as FeliCaMngWork;

                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("Read Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

				return Read(ref felicaMngWork, ref sqlConnection);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"FeliCaMngDB.Read Exception = "+ex.Message);
                errMsg = "FeliCaMngDB.Read Exception = " + ex.Message;
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, string.Empty, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                // ���R�l�N�V�����j��
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
		}

		/// <summary>
		/// �w�肳�ꂽ�t�F���J�Ǘ�Guid�̃t�F���J�Ǘ���߂��܂�
		/// </summary>
		/// <param name="felicaMngWork">FeliCaMngWork�I�u�W�F�N�g</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		public int Read(ref FeliCaMngWork felicaMngWork , ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Read2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("Read Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND", sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFeliCaIDm = sqlCommand.Parameters.Add("@FINDFELICAIDM", SqlDbType.NChar);
                SqlParameter findParaFeliCaMngKind = sqlCommand.Parameters.Add("@FINDFELICAMNGKIND", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                // �^�C���A�E�g���Ԃ�ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    felicaMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    felicaMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    felicaMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    felicaMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    felicaMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    felicaMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    felicaMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    felicaMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    felicaMngWork.FeliCaIDm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FELICAIDMRF"));
                    felicaMngWork.FeliCaMngKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FELICAMNGKINDRF"));
                    felicaMngWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.Search Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                errMsg = "FeliCaMngDB.Search Exception = " + ex.Message;
                base.WriteErrorLog(ex, "FeliCaMngDB.Read Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            }
            myReader.Close();
			return status;
		}

		/// <summary>
		/// �t�F���J�Ǘ�����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="paraobj">FeliCaMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �t�F���J�Ǘ�����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 22011 �������l</br>
		/// <br>Date       : 2008.10.30</br>
		public int Write(ref object paraobj)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Write");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

			try
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
				if ( connectionText == null || connectionText == "" ) return status;

				//SQL�R�l�N�V�����I�u�W�F�N�g�쐬
				sqlConnection = new SqlConnection( connectionText );
				sqlConnection.Open();
				//�g�����U�N�V�����J�n
				sqlTransaction = sqlConnection.BeginTransaction( ( IsolationLevel )ConstantManagement.DB_IsolationLevel.ctDB_Default );

				foreach( FeliCaMngWork felicaMngWork in (List<FeliCaMngWork>)paraobj )
				{
                    // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                    //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                    //jobAcs.StartWriteServiceJob(string.Format("Write Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
					// --- DEL m.suzuki 2009/00/00 ----------<<<<<
                    status = Write(felicaMngWork, ref sqlConnection, ref sqlTransaction);
					if( status != 0 ) break;
				}
			}
			catch( SqlException ex)
			{
                errMsg = "FeliCaMngDB.Write Exception = " + ex.Message;
				status = base.WriteSQLErrorLog( ex );
			}
			catch( Exception ex )
			{
                errMsg = "FeliCaMngDB.Write Exception = " + ex.Message;
				base.WriteErrorLog( ex, "FeliCaMngDB.Write:"+ex.Message );
				status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

				// ���R�l�N�V�����j��
				if ( sqlConnection.State == ConnectionState.Open ) 
				{
					if( sqlTransaction.Connection != null )
					{
						// ���R�~�b�gor���[���o�b�N
						if ( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL)
							sqlTransaction.Commit();
						else
							sqlTransaction.Rollback();
					}
					sqlTransaction.Dispose();
					sqlConnection.Close();
                    sqlConnection.Dispose();
				}
			}

			return status;
		}

        /// <summary>
        /// �t�F���J�Ǘ�����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="felicaMngWork">felicaMngWork</param>
        /// <param name="sqlConnection">Sql�ڑ����</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �t�F���J�Ǘ�����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22011�@�������l</br>
        /// <br>Date       : 2008.10.30</br>
        public int Write(FeliCaMngWork felicaMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Write2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("Wite Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FELICAIDMRF, FELICAMNGKINDRF FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND", sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFeliCaIDm = sqlCommand.Parameters.Add("@FINDFELICAIDM", SqlDbType.NChar);
                SqlParameter findParaFeliCaMngKind = sqlCommand.Parameters.Add("@FINDFELICAMNGKIND", SqlDbType.Int);
      
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                // �^�C���A�E�g���Ԃ�ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != felicaMngWork.UpdateDateTime)
                    {
                        //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                        if (felicaMngWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        myReader.Close();
                        return status;
                    }

                    sqlCommand.CommandText = "UPDATE FELICAMNGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , FELICAIDMRF=@FELICAIDM , FELICAMNGKINDRF=@FELICAMNGKIND , EMPLOYEECODERF=@EMPLOYEECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND";
                    //KEY�R�}���h���Đݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                    findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                    findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)felicaMngWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (felicaMngWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        myReader.Close();
                        return status;
                    }

                    //�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = "INSERT INTO FELICAMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FELICAIDMRF, FELICAMNGKINDRF, EMPLOYEECODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FELICAIDM, @FELICAMNGKIND, @EMPLOYEECODE)";

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)felicaMngWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }

                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraFeliCaIDm = sqlCommand.Parameters.Add("@FELICAIDM", SqlDbType.NChar);
                SqlParameter paraFeliCaMngKind = sqlCommand.Parameters.Add("@FELICAMNGKIND", SqlDbType.Int);
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(felicaMngWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(felicaMngWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(felicaMngWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.LogicalDeleteCode);
                paraFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                paraFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EmployeeCode);


                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.Write Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                errMsg = "FeliCaMngDB.Write Exception = " + ex.Message;
                base.WriteErrorLog(ex, "FeliCaMngDB.Write Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

		/// <summary>
		/// �t�F���J�Ǘ�����_���폜���܂�
		/// </summary>
		/// <param name="paraObj">FeliCaMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		public int LogicalDelete(ref object paraObj)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			FeliCaMngWork felicaMngWork = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.LogicalDelete");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

			try 
			{
				felicaMngWork = paraObj as FeliCaMngWork;
				
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;
				
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("LogicalDelete Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                status = LogicalDelete(ref felicaMngWork, 0, ref sqlConnection, ref sqlTransaction);
			}
			catch(SqlException ex)
			{
                errMsg = "FeliCaMngDB.LogicalDelete Exception = " + ex.Message;
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
                errMsg = "FeliCaMngDB.LogicalDelete Exception = " + ex.Message;
				base.WriteErrorLog(ex,"FeliCaMngDB.LogicalDelete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

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
                    sqlConnection.Dispose();
				}
			}

			paraObj = (object)felicaMngWork;
			return status;
		}

        /// <summary>
        /// �_���폜�t�F���J�Ǘ����𕜊����܂�
        /// </summary>
        /// <param name="paraObj">WorkerWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int RevivalLogicalDelete(ref object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            FeliCaMngWork felicaMngWork = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Revival");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                felicaMngWork = paraObj as FeliCaMngWork;

                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("Revival Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<
                status = LogicalDelete(ref felicaMngWork, 1, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.Revival Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                errMsg = "FeliCaMngDB.Revival Exception = " + ex.Message;
                base.WriteErrorLog(ex, "FeliCaMngDB.RevivalLogicalDelete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

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
                    sqlConnection.Dispose();
                }
            }
            paraObj = (object)felicaMngWork;
            return status;
        }

        /// <summary>
        /// �t�F���J�Ǘ����̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="felicaMngWork">FeliCaMngWork</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">Sql�ڑ����</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �t�F���J�Ǘ����̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 22011�@�������l</br>
        /// <br>Date       : 2008.10.30</br>
        public int LogicalDelete(ref FeliCaMngWork felicaMngWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.LogicalDelete2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("LogicalDelete Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}, procMode{3}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind, procMode), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF , FELICAIDMRF, FELICAMNGKINDRF FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND", sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFeliCaIDm = sqlCommand.Parameters.Add("@FINDFELICAIDM", SqlDbType.NChar);
                SqlParameter findParaFeliCaMngKind = sqlCommand.Parameters.Add("@FINDFELICAMNGKIND", SqlDbType.Int);
                
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                // �^�C���A�E�g���Ԃ�ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != felicaMngWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        myReader.Close();
                        return status;
                    }
                    //���݂̘_���폜�敪���擾
                    logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    sqlCommand.CommandText = "UPDATE FELICAMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND";
					
                    //KEY�R�}���h���Đݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                    findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                    findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)felicaMngWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                    return status;
                }

                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();

                //�_���폜���[�h�̏ꍇ
                if (procMode == 0)
                {
                    if (logicalDelCd == 3)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                        myReader.Close();
                        if (sqlCommand != null) sqlCommand.Dispose();
                        return status;
                    }
                    else if (logicalDelCd == 0) felicaMngWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                    else felicaMngWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                }
                else
                {
                    if (logicalDelCd == 1) felicaMngWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                    else
                    {
                        if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                        else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                        myReader.Close();
                        if (sqlCommand != null) sqlCommand.Dispose();
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
                paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(felicaMngWork.UpdateDateTime);
                paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdEmployeeCode);
                paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdAssemblyId1);
                paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(felicaMngWork.UpdAssemblyId2);
                paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.LogicalDeleteCode);
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.LogicalDelete Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;

        }

        /// <summary>
        /// �t�F���J�Ǘ��ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraObj">�t�F���J�Ǘ��I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �t�F���J�Ǘ��ݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : 22011�@�������l</br>
        /// <br>Date       : 2008.10.30</br>
        public int Delete(object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Delete");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // �p�����[�^�𕜌�
                FeliCaMngWork felicaMngWork = paraObj as FeliCaMngWork ;
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("Delete Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                status = Delete(felicaMngWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                errMsg = "FeliCaMngDB.Delete Exception = " + ex.Message;
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                errMsg = "FeliCaMngDB.Delete Exception = " + ex.Message;
                base.WriteErrorLog(ex, "FelicaMngDB.Delete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<
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
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

		/// <summary>
		/// �t�F���J�Ǘ����𕨗��폜���܂�
		/// </summary>
		/// <param name="felicaMngWork">FeliCaMngWork</param>
		/// <param name="sqlConnection">Sql�ڑ����</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns></returns>
		/// <br>Note       : �t�F���J�Ǘ����𕨗��폜���܂�</br>
		/// <br>Programmer : 22011�@�������l</br>
		/// <br>Date       : 2008.10.30</br>
		public int Delete(FeliCaMngWork felicaMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

            // --- DEL m.suzuki 2009/00/00 ---------->>>>>
            //// PGID�ƃ��\�b�h����n���ăT�[�r�X�W���u�A�N�Z�X�N���X�̃C���X�^���X���N��
            //NSServiceJobAccess jobAcs = new NSServiceJobAccess("SFCMN03502R", "FelicaMng.Delete2");
            // --- DEL m.suzuki 2009/00/00 ----------<<<<<
            string errMsg = string.Empty;

			try 
			{
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// ���\�b�h�ŗL���ƃR�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //jobAcs.StartWriteServiceJob(string.Format("Delete Para: EnterpriseCode {0},FeliCaIdm {1},FeliCaMngKind{2}", felicaMngWork.EnterpriseCode, felicaMngWork.FeliCaIDm, felicaMngWork.FeliCaMngKind), sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, FELICAIDMRF, FELICAMNGKINDRF FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND", sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFeliCaIDm = sqlCommand.Parameters.Add("@FINDFELICAIDM", SqlDbType.NChar);
                SqlParameter findParaFeliCaMngKind = sqlCommand.Parameters.Add("@FINDFELICAMNGKIND", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);

                // �^�C���A�E�g���Ԃ�ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
					if (_updateDateTime != felicaMngWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						myReader.Close();
						return status;
					}

                    sqlCommand.CommandText = "DELETE FROM FELICAMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FELICAIDMRF=@FINDFELICAIDM AND FELICAMNGKINDRF=@FINDFELICAMNGKIND";
					//KEY�R�}���h���Đݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(felicaMngWork.EnterpriseCode);
                    findParaFeliCaIDm.Value = SqlDataMediator.SqlSetString(felicaMngWork.FeliCaIDm);
                    findParaFeliCaMngKind.Value = SqlDataMediator.SqlSetInt32(felicaMngWork.FeliCaMngKind);
                }
				else
				{
					//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					myReader.Close();
					return status;
				}

                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
				
                sqlCommand.ExecuteNonQuery();
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}
			catch (SqlException ex) 
			{
                errMsg = "FeliCaMngDB.Delete Exception = " + ex.Message;
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
                errMsg = "FeliCaMngDB.Delete Exception = " + ex.Message;
				base.WriteErrorLog(ex,"FeliCaMngDB.Delete Exception = "+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
                // --- DEL m.suzuki 2009/00/00 ---------->>>>>
                //// �X�e�[�^�X�A���b�Z�[�W�A���\�b�h�ŗL���A�R�l�N�V������n���ăT�[�r�X�W���u�e�[�u���֏�������
                //if (jobAcs != null) jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                // --- DEL m.suzuki 2009/00/00 ----------<<<<<

				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
			}

			return status;
		}	
	}
}