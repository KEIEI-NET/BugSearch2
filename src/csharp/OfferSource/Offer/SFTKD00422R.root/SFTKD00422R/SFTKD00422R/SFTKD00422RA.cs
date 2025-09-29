using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �Z�������[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: 2006.11.28 23011 ���</br>
    /// <br>             �ʐM�f�[�^���k�Ή�</br>
	/// </remarks>
	[Serializable]
	public class OfferAddressInfoDB : RemoteDB, IRemoteDB, IOfferAddressInfo
	{
		
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
		public OfferAddressInfoDB() : base( "SFTKD00424D", "Broadleaf.Application.Remoting.ParamData.AddressWork", "ADDRESSRF" )
		{
		}
		
		#region �Z���f�[�^��SQL���[�_�[����Z���f�[�^�N���X�ɃR�s�[���郁�\�b�h
		
        /// <summary>
        /// SQL�f�[�^���[�_�[����f�[�^�N���X�Ƀf�[�^���R�s�[���܂�
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="awResult"></param>
		private void ReadAddressWork( SqlDataReader myReader, ref AddressWork awResult )
		{
            awResult.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            awResult.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            awResult.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            awResult.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            awResult.AddressCode1Upper = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSCODE1UPPERRF"));
            awResult.AddressCode1Lower = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSCODE1LOWERRF"));
            awResult.AddressCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSCODE2RF"));
            awResult.AddressCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSCODE3RF"));
            awResult.OldPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDPOSTNORF"));
            awResult.OldAddressCode11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDADDRESSCODE11RF"));
            awResult.OldAddressCode12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDADDRESSCODE12RF"));
            awResult.OldAddressCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDADDRESSCODE2RF"));
            awResult.OldAddressCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDADDRESSCODE3RF"));
            awResult.AddressName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSNAMERF"));
            awResult.AddressKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSKANARF"));
            awResult.AddrConnectCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRCONNECTCD1RF"));
            awResult.DivAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIVADDRESS1RF"));
            awResult.AddrConnectCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRCONNECTCD2RF"));
            awResult.DivAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIVADDRESS2RF"));
            awResult.AddrConnectCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRCONNECTCD3RF"));
            awResult.DivAddress3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIVADDRESS3RF"));
            awResult.AddrConnectCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRCONNECTCD4RF"));
            awResult.DivAddress4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIVADDRESS4RF"));
            awResult.AddrConnectCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRCONNECTCD5RF"));
            awResult.DivAddress5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIVADDRESS5RF"));
		}
		
		#endregion
		
		#region �p�����[�^����R�}���h�𐶐�����
		
		/// <summary>
		/// �p�����[�^����Z���R�[�h�Ŏ擾����Select���𐶐�����
		/// </summary>
        /// <param name="connection"></param>
        /// <param name="addrIndex"></param>
		/// <returns></returns>
		private SqlCommand CreateAddrConnectCdCommand( SqlConnection connection, AddressWork addrIndex )
		{
			 SqlCommand command = null;
			
			//�Z���A���R�[�h�P���Ȃ��ꍇ�͊Y���͂Ȃ��B�������Ȃ�
			if( addrIndex.AddrConnectCd1 <= 0 )
			{
			}
			else if( addrIndex.AddrConnectCd2 <= 0 )
			{
				command = new SqlCommand( this.strAddrConnectCd1, connection );
				
				//�Z���A���R�[�h�P�����w�肳��Ă���ꍇ
				SqlParameter param1 = command.Parameters.Add("@ADDRCONNECTCD1", SqlDbType.Int);
				param1.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd1);
				
			}
			else if( addrIndex.AddrConnectCd3 <= 0 )
			{
				command = new SqlCommand( this.strAddrConnectCd2, connection );
				
				//�Z���A���R�[�h�Q�܂Ŏw�肳��Ă���ꍇ
				SqlParameter param1 = command.Parameters.Add("@ADDRCONNECTCD1", SqlDbType.Int);
				param1.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd1);
				
				SqlParameter param2 = command.Parameters.Add("@ADDRCONNECTCD2", SqlDbType.Int);
				param2.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd2);

			}
			else if( addrIndex.AddrConnectCd4 <= 0 )
			{
				command = new SqlCommand( this.strAddrConnectCd3, connection );
				
				//�Z���A���R�[�h�R�܂Ŏw�肳��Ă���ꍇ
				SqlParameter param1 = command.Parameters.Add("@ADDRCONNECTCD1", SqlDbType.Int);
				param1.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd1);
				
				SqlParameter param2 = command.Parameters.Add("@ADDRCONNECTCD2", SqlDbType.Int);
				param2.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd2);
				
				SqlParameter param3 = command.Parameters.Add("@ADDRCONNECTCD3", SqlDbType.Int);
				param3.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd3);

			}
			else if( addrIndex.AddrConnectCd5 <= 0 )
			{
				command = new SqlCommand( this.strAddrConnectCd4, connection );
				
				//�Z���A���R�[�h�S�܂Ŏw�肳��Ă���ꍇ
				SqlParameter param1 = command.Parameters.Add("@ADDRCONNECTCD1", SqlDbType.Int);
				param1.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd1);
				
				SqlParameter param2 = command.Parameters.Add("@ADDRCONNECTCD2", SqlDbType.Int);
				param2.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd2);
				
				SqlParameter param3 = command.Parameters.Add("@ADDRCONNECTCD3", SqlDbType.Int);
				param3.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd3);

				SqlParameter param4 = command.Parameters.Add("@ADDRCONNECTCD4", SqlDbType.Int);
				param4.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd4);
				
			}
			else
			{
				command = new SqlCommand( this.strAddrConnectCd5, connection );
				
				//�Z���A���R�[�h�T�܂Ŏw�肳��Ă���ꍇ
				SqlParameter param1 = command.Parameters.Add("@ADDRCONNECTCD1", SqlDbType.Int);
				param1.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd1);
				
				SqlParameter param2 = command.Parameters.Add("@ADDRCONNECTCD2", SqlDbType.Int);
				param2.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd2);
				
				SqlParameter param3 = command.Parameters.Add("@ADDRCONNECTCD3", SqlDbType.Int);
				param3.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd3);
				
				SqlParameter param4 = command.Parameters.Add("@ADDRCONNECTCD4", SqlDbType.Int);
				param4.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd4);
				
				SqlParameter param5 = command.Parameters.Add("@ADDRCONNECTCD5", SqlDbType.Int);
				param5.Value = SqlDataMediator.SqlSetInt32((int)addrIndex.AddrConnectCd5);
				
			}
			
			return command;
		}
		
		#endregion
		
		#region SQL�R�}���h������
		
        private readonly string strAddrConnectCd1 = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, POSTNORF, ADDRESSCODE1UPPERRF, ADDRESSCODE1LOWERRF, ADDRESSCODE2RF, ADDRESSCODE3RF, OLDPOSTNORF, OLDADDRESSCODE11RF, OLDADDRESSCODE12RF, OLDADDRESSCODE2RF, OLDADDRESSCODE3RF, CAST(DECRYPTBYKEY(ADDRESSNAMERF) AS NVARCHAR(75)) AS ADDRESSNAMERF, CAST(DECRYPTBYKEY(ADDRESSKANARF) AS NVARCHAR(300)) AS ADDRESSKANARF, ADDRCONNECTCD1RF, DIVADDRESS1RF, ADDRCONNECTCD2RF, DIVADDRESS2RF, ADDRCONNECTCD3RF, CAST(DECRYPTBYKEY(DIVADDRESS3RF) AS NVARCHAR(15)) AS DIVADDRESS3RF, ADDRCONNECTCD4RF, CAST(DECRYPTBYKEY(DIVADDRESS4RF) AS NVARCHAR(15)) AS DIVADDRESS4RF, ADDRCONNECTCD5RF, DIVADDRESS5RF FROM ADDRESSRF WHERE ADDRCONNECTCD1RF = @ADDRCONNECTCD1 ORDER BY ADDRCONNECTCD1RF, ADDRCONNECTCD2RF, ADDRCONNECTCD3RF, ADDRCONNECTCD4RF, ADDRCONNECTCD5RF";

        private readonly string strAddrConnectCd2 = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, POSTNORF, ADDRESSCODE1UPPERRF, ADDRESSCODE1LOWERRF, ADDRESSCODE2RF, ADDRESSCODE3RF, OLDPOSTNORF, OLDADDRESSCODE11RF, OLDADDRESSCODE12RF, OLDADDRESSCODE2RF, OLDADDRESSCODE3RF, CAST(DECRYPTBYKEY(ADDRESSNAMERF) AS NVARCHAR(75)) AS ADDRESSNAMERF, CAST(DECRYPTBYKEY(ADDRESSKANARF) AS NVARCHAR(300)) AS ADDRESSKANARF, ADDRCONNECTCD1RF, DIVADDRESS1RF, ADDRCONNECTCD2RF, DIVADDRESS2RF, ADDRCONNECTCD3RF, CAST(DECRYPTBYKEY(DIVADDRESS3RF) AS NVARCHAR(15)) AS DIVADDRESS3RF, ADDRCONNECTCD4RF, CAST(DECRYPTBYKEY(DIVADDRESS4RF) AS NVARCHAR(15)) AS DIVADDRESS4RF, ADDRCONNECTCD5RF, DIVADDRESS5RF FROM ADDRESSRF WHERE ADDRCONNECTCD1RF = @ADDRCONNECTCD1 AND ADDRCONNECTCD2RF = @ADDRCONNECTCD2 ORDER BY ADDRCONNECTCD1RF, ADDRCONNECTCD2RF, ADDRCONNECTCD3RF, ADDRCONNECTCD4RF, ADDRCONNECTCD5RF";

        private readonly string strAddrConnectCd3 = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, POSTNORF, ADDRESSCODE1UPPERRF, ADDRESSCODE1LOWERRF, ADDRESSCODE2RF, ADDRESSCODE3RF, OLDPOSTNORF, OLDADDRESSCODE11RF, OLDADDRESSCODE12RF, OLDADDRESSCODE2RF, OLDADDRESSCODE3RF, CAST(DECRYPTBYKEY(ADDRESSNAMERF) AS NVARCHAR(75)) AS ADDRESSNAMERF, CAST(DECRYPTBYKEY(ADDRESSKANARF) AS NVARCHAR(300)) AS ADDRESSKANARF, ADDRCONNECTCD1RF, DIVADDRESS1RF, ADDRCONNECTCD2RF, DIVADDRESS2RF, ADDRCONNECTCD3RF, CAST(DECRYPTBYKEY(DIVADDRESS3RF) AS NVARCHAR(15)) AS DIVADDRESS3RF, ADDRCONNECTCD4RF, CAST(DECRYPTBYKEY(DIVADDRESS4RF) AS NVARCHAR(15)) AS DIVADDRESS4RF, ADDRCONNECTCD5RF, DIVADDRESS5RF WHERE ADDRCONNECTCD1RF = @ADDRCONNECTCD1 AND ADDRCONNECTCD2RF = @ADDRCONNECTCD2 AND ADDRCONNECTCD3RF = @ADDRCONNECTCD3 ORDER BY ADDRCONNECTCD1RF, ADDRCONNECTCD2RF, ADDRCONNECTCD3RF, ADDRCONNECTCD4RF, ADDRCONNECTCD5RF";

        private readonly string strAddrConnectCd4 = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, POSTNORF, ADDRESSCODE1UPPERRF, ADDRESSCODE1LOWERRF, ADDRESSCODE2RF, ADDRESSCODE3RF, OLDPOSTNORF, OLDADDRESSCODE11RF, OLDADDRESSCODE12RF, OLDADDRESSCODE2RF, OLDADDRESSCODE3RF, CAST(DECRYPTBYKEY(ADDRESSNAMERF) AS NVARCHAR(75)) AS ADDRESSNAMERF, CAST(DECRYPTBYKEY(ADDRESSKANARF) AS NVARCHAR(300)) AS ADDRESSKANARF, ADDRCONNECTCD1RF, DIVADDRESS1RF, ADDRCONNECTCD2RF, DIVADDRESS2RF, ADDRCONNECTCD3RF, CAST(DECRYPTBYKEY(DIVADDRESS3RF) AS NVARCHAR(15)) AS DIVADDRESS3RF, ADDRCONNECTCD4RF, CAST(DECRYPTBYKEY(DIVADDRESS4RF) AS NVARCHAR(15)) AS DIVADDRESS4RF, ADDRCONNECTCD5RF, DIVADDRESS5RF FROM ADDRESSRF WHERE ADDRCONNECTCD1RF = @ADDRCONNECTCD1 AND ADDRCONNECTCD2RF = @ADDRCONNECTCD2 AND ADDRCONNECTCD3RF = @ADDRCONNECTCD3 AND ADDRCONNECTCD4RF = @ADDRCONNECTCD4 ORDER BY ADDRCONNECTCD1RF, ADDRCONNECTCD2RF, ADDRCONNECTCD3RF, ADDRCONNECTCD4RF, ADDRCONNECTCD5RF";

        private readonly string strAddrConnectCd5 = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, POSTNORF, ADDRESSCODE1UPPERRF, ADDRESSCODE1LOWERRF, ADDRESSCODE2RF, ADDRESSCODE3RF, OLDPOSTNORF, OLDADDRESSCODE11RF, OLDADDRESSCODE12RF, OLDADDRESSCODE2RF, OLDADDRESSCODE3RF, CAST(DECRYPTBYKEY(ADDRESSNAMERF) AS NVARCHAR(75)) AS ADDRESSNAMERF, CAST(DECRYPTBYKEY(ADDRESSKANARF) AS NVARCHAR(300)) AS ADDRESSKANARF, ADDRCONNECTCD1RF, DIVADDRESS1RF, ADDRCONNECTCD2RF, DIVADDRESS2RF, ADDRCONNECTCD3RF, CAST(DECRYPTBYKEY(DIVADDRESS3RF) AS NVARCHAR(15)) AS DIVADDRESS3RF, ADDRCONNECTCD4RF, CAST(DECRYPTBYKEY(DIVADDRESS4RF) AS NVARCHAR(15)) AS DIVADDRESS4RF, ADDRCONNECTCD5RF, DIVADDRESS5RF FROM ADDRESSRF WHERE ADDRCONNECTCD1RF = @ADDRCONNECTCD1 AND ADDRCONNECTCD2RF = @ADDRCONNECTCD2 AND ADDRCONNECTCD3RF = @ADDRCONNECTCD3 AND ADDRCONNECTCD4RF = @ADDRCONNECTCD4 AND ADDRCONNECTCD5RF = @ADDRCONNECTCD5 ORDER BY ADDRCONNECTCD1RF, ADDRCONNECTCD2RF, ADDRCONNECTCD3RF, ADDRCONNECTCD4RF, ADDRCONNECTCD5RF";
				
		#endregion
		
		#region IOfferAddressInfo �����o

        /// <summary>
        /// �Z�������擾���܂��BCustomSerializeArrayList���g�p���邱�ƂŒʐM�f�[�^�Ɉ��k��������܂�
        /// </summary>
        /// <param name="paraAddressWork"></param>
        /// <param name="retList"></param>
        /// <returns></returns>
        public int SearchAddressWork(AddressWork paraAddressWork, out object retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            object resultObj = null;
            CustomSerializeArrayList resultCustomSerializeArrayList = new CustomSerializeArrayList();
            retList = resultCustomSerializeArrayList;

            try
            {
                //�f�[�^�擾
                status = GetAddressWork(paraAddressWork, out resultObj);

                //���ʂ������CustomSerializeArrayList�ɒǉ�
                if (resultObj != null && resultObj is ArrayList)
                {
                    resultCustomSerializeArrayList.Add(resultObj as ArrayList);
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SFTKD00422R OfferAddressInfoDB.SearchAddressWork()�ɂăG���[���������܂����B");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        
        /// <summary>
		/// �w��̏Z���C���f�b�N�X�}�X�^�ɑΉ�����Z���}�X�^���������A
		/// �Y������Z���}�X�^�̏���ArrayList�ɒǉ�����
		/// �A���R�[�h���O�ȉ��̏ꍇ�̓f�[�^�͂Ȃ����̂Ƃ��Č��������ɓ���Ȃ�
		/// </summary>
		/// <param name="addrIndex">�����������}�X�^�̏�������AddressWork</param>
        /// <param name="objResult">�������ʂ�����ArrayList</param>
		/// <returns>�G���[�R�[�h</returns>
		public int GetAddressWork( AddressWork addrIndex, out object objResult )
		{
			objResult = null;
			ArrayList alResult = null;
			
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			
			SqlConnection sqlConnection		= null;
			SqlDataReader myReader			= null;
			SqlCommand sqlCommand			= null;
            SqlEncryptInfo sqlEncryptInfo = null;

			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);

				if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB, new string[] { "ADDRESSRF" });
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);

				//�������̎w�肪�Ȃ��ꍇ�͖߂�
				if( ( sqlCommand = this.CreateAddrConnectCdCommand( sqlConnection, addrIndex ) ) == null )
				{
					return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
				
				myReader = sqlCommand.ExecuteReader();
				
				while(myReader.Read())
				{
					AddressWork awResult = new AddressWork();
					
					this.ReadAddressWork( myReader, ref awResult );
					
					if( alResult == null )
					{
						alResult = new ArrayList();
						//�ύX�𔽉f
						objResult = alResult;
					}
					
					alResult.Add(awResult);
					
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch( Exception ex )
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				base.WriteErrorLog( ex, "OfferAddressInfoDB.GetAddressWork( AddressWork addrIndex, out object objResult )" );
			}
			finally
			{
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null )
                {
                    myReader.Close();
                    myReader.Dispose();
                }
                if (sqlEncryptInfo != null)
                {
                    if (sqlEncryptInfo.IsOpen)
                    {
                        sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                    }
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
			}
			
			return status;
		}
		
        #endregion


        #region IOfferAddressInfo �����o(�C���f�b�N�X�n�}�X�^)

        /// <summary>
        /// �Z���}�X�^�X�V�Ǘ��}�X�^��S���擾����
        /// </summary>
        /// <param name="objAddrUpdMngList"></param>
        /// <returns></returns>
        public int SearchAddrUpdMng(out object objAddrUpdMngList)
        {
            return this.SearchAddrUpdMngProc(out objAddrUpdMngList);
        }
        /// <summary>
        /// �Z���}�X�^�X�V�Ǘ��}�X�^��S���擾����
        /// </summary>
        /// <param name="objAddrUpdMngList"></param>
        /// <returns></returns>
        private int SearchAddrUpdMngProc(out object objAddrUpdMngList)
        {   

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList list = new ArrayList();

            //���ʂ������Ƃ�
            objAddrUpdMngList = list;

            try
            {
                //�R�l�N�V������������擾
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL�R�l�N�V�����I�u�W�F�N�g�쐬
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, ADDRCONNECTCD1RF, ADDRUPDATEDATETIMERF FROM ADDRUPDMNGRF", sqlConnection);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AddrUpdMngWork addrUpdMngWork = new AddrUpdMngWork();

                    #region �����

                    addrUpdMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    addrUpdMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    addrUpdMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    addrUpdMngWork.AddrConnectCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRCONNECTCD1RF"));
                    addrUpdMngWork.AddrUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("ADDRUPDATEDATETIMERF"));

                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    list.Add(addrUpdMngWork);
                }

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SFTKD00422R OfferAddressInfoDB.SearchAddrUpdMng(out object objAddrUpdMngList)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �Z���R�[�h�C���f�b�N�X�}�X�^�ƗX�֔ԍ��C���f�b�N�X�}�X�^���擾����
        /// </summary>
        /// <param name="objAddrCdIndxList"></param>
        /// <param name="objPostNoIndxList"></param>
        /// <returns></returns>
        public int SearchAddrCdIndxAndPostNoIndx(out object objAddrCdIndxList, out object objPostNoIndxList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            objAddrCdIndxList = null;
            objPostNoIndxList = null;

            try
            {
                //�R�l�N�V������������擾
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL�R�l�N�V�����I�u�W�F�N�g�쐬
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�Z���R�[�h�C���f�b�N�X�}�X�^���擾����
                status = this.SearchAddrCdIndxInner(out objAddrCdIndxList, ref sqlConnection);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //�X�֔ԍ��C���f�b�N�X�}�X�^���擾����
                status = this.SearchPostNoIndxInner(out objPostNoIndxList, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SFTKD00422R OfferAddressInfoDB.SearchAddrCdIndx(out object objAddrCdIndxList, out object objPostNoIndxList)");
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
        /// �Z���}�X�^�Z���R�[�h�C���f�b�N�X�}�X�^��S���擾����
        /// </summary>
        /// <param name="objAddrCdIndxList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchAddrCdIndxInner(out object objAddrCdIndxList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList list = new ArrayList();

            //���ʂ������Ƃ�
            objAddrCdIndxList = list;

            try
            {
                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, ADDRESSCODE1UPPERRF, ADDRCONNECTCD1RF FROM ADDRCDINDXRF", sqlConnection);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AddrCdIndxWork addrCdIndxWork = new AddrCdIndxWork();

                    #region �����

                    addrCdIndxWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    addrCdIndxWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    addrCdIndxWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    addrCdIndxWork.AddressCode1Upper = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSCODE1UPPERRF"));
                    addrCdIndxWork.AddrConnectCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRCONNECTCD1RF"));

                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    list.Add(addrCdIndxWork);
                }

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SFTKD00422R OfferAddressInfoDB.SearchAddrCdIndxInner(out object objAddrCdIndxList, ref SqlConnection sqlConnection))");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �Z���}�X�^�X�֔ԍ��C���f�b�N�X�}�X�^��S���擾����
        /// </summary>
        /// <param name="objPostNoIndxList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPostNoIndxInner(out object objPostNoIndxList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList list = new ArrayList();

            //���ʂ������Ƃ�
            objPostNoIndxList = list;

            try
            {
                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, POSTNOINITIALCHARRF, ADDRCONNECTCD1RF FROM POSTNOINDXRF", sqlConnection);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PostNoIndxWork postNoIndxWork = new PostNoIndxWork();

                    #region �����

                    postNoIndxWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    postNoIndxWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    postNoIndxWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    postNoIndxWork.PostNoInitialChar = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNOINITIALCHARRF"));
                    postNoIndxWork.AddrConnectCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRCONNECTCD1RF"));

                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    list.Add(postNoIndxWork);
                }

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SFTKD00422R OfferAddressInfoDB.SearchPostNoIndxInner(out object objPostNoIndxList, ref SqlConnection sqlConnection)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

    }
}
