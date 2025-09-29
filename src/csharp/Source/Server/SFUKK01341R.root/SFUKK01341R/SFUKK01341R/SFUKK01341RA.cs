using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// KINGET�p�����f�[�^���oDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����f�[�^���o�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 18023 ����@����</br>
	/// <br>Date       : 2005.07.27</br>
	/// <br></br>
	/// <br>Update Note: 2007.01.22 18322 T.Kimura  MA.NS�p�ɕύX</br>
    /// <br>             2007.05.14 18322 T.Kimura  �T�[�r�X�`�[�敪(ServiceSlipCd)��ǉ�</br>
    /// <br>             2007.10.11 980081 A.Yamada DC.NS�p�ɕύX</br>
    /// <br>             2007.12.10 980081 A.Yamada EdiTakeInDate(EDI�捞��)��Int32��DateTime�ɕύX</br>
    /// <br>             --------------------------------------------------------------------------</br>    
    /// <br>             2008.06.26 21112 �{�����[�g�͑����g�p����Ă��Ȃ��̂ŁA�C���͕ۗ��Ƃ���B</br>
    /// <br></br>
	/// </remarks>
	[Serializable]
	public class KingetDepsitMainDB : RemoteDB, IRemoteDB
	{
		#region Constructor
		/// <summary>
		/// KINGET�p�������oDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.27</br>
		/// </remarks>
		public KingetDepsitMainDB() :
			base("SFUKK01343D", "Broadleaf.Application.Remoting.ParamData.DepsitMainWork", "DEPSITMAINRF")
		{
		}
		#endregion

		# region Private Const

        // �� 2007.10.11 980081 c
        #region MA �����}�X�^SELECT��(�R�����g�A�E�g)
        // �� 20070122 18322 c MA.NS�p�ɕύX
        #region SF �����}�X�^SELECT���i�R�����g�A�E�g�j
        //private const string SELECT_DEPSITMAIN =
		//	"SELECT CREATEDATETIMERF,UPDATEDATETIMERF,ENTERPRISECODERF,FILEHEADERGUIDRF,UPDEMPLOYEECODERF,UPDASSEMBLYID1RF,UPDASSEMBLYID2RF,LOGICALDELETECODERF"
		//	+",DEPOSITDEBITNOTECDRF,DEPOSITSLIPNORF,DEPOSITKINDCODERF,CUSTOMERCODERF,DEPOSITCDRF,DEPOSITTOTALRF"
		//	+",OUTLINERF,ACCEPTANORDERSALESNORF,INPUTDEPOSITSECCDRF,DEPOSITDATERF,ADDUPSECCODERF,ADDUPADATERF"
		//	+",UPDATESECCDRF,DEPOSITKINDNAMERF,DEPOSITALLOWANCERF,DEPOSITALWCBLNCERF,DEPOSITAGENTCODERF"
		//	+",DEPOSITKINDDIVCDRF,FEEDEPOSITRF,DISCOUNTDEPOSITRF,CREDITORLOANCDRF,CREDITCOMPANYCODERF,DEPOSITRF"
		//	+",DRAFTDRAWINGDATERF,DRAFTPAYTIMELIMITRF,DEBITNOTELINKDEPONORF,LASTRECONCILEADDUPDTRF,AUTODEPOSITCDRF"
		//	+",ACPODRDEPOSITRF,ACPODRCHARGEDEPOSITRF,ACPODRDISDEPOSITRF,VARIOUSCOSTDEPOSITRF,VARCOSTCHARGEDEPOSITRF"
		//	+",VARCOSTDISDEPOSITRF,ACPODRDEPOSITALWCRF,VARCOSTDEPOALWCRF,VARCOSTDEPOALWCBLNCERF"
        //	+" FROM DEPSITMAINRF";
        #endregion

        //private const string SELECT_DEPSITMAIN =
        //    "SELECT CREATEDATETIMERF"
        //        + ",UPDATEDATETIMERF"
        //        + ",ENTERPRISECODERF"
        //        + ",FILEHEADERGUIDRF"
        //        + ",UPDEMPLOYEECODERF"
        //        + ",UPDASSEMBLYID1RF"
        //        + ",UPDASSEMBLYID2RF"
        //        + ",LOGICALDELETECODERF"
        //        + ",DEPOSITDEBITNOTECDRF"
        //        + ",DEPOSITSLIPNORF"
        //        + ",ACCEPTANORDERNORF"
        //        + ",SERVICESLIPCDRF"
        //        + ",INPUTDEPOSITSECCDRF"
        //        + ",ADDUPSECCODERF"
        //        + ",UPDATESECCDRF"
        //        + ",DEPOSITDATERF"
        //        + ",ADDUPADATERF"
        //        + ",DEPOSITKINDCODERF"
        //        + ",DEPOSITKINDNAMERF"
        //        + ",DEPOSITKINDDIVCDRF"
        //        + ",DEPOSITTOTALRF"
        //        + ",DEPOSITRF"
        //        + ",FEEDEPOSITRF"
        //        + ",DISCOUNTDEPOSITRF"
        //        + ",REBATEDEPOSITRF"
        //        + ",AUTODEPOSITCDRF"
        //        + ",DEPOSITCDRF"
        //        + ",CREDITORLOANCDRF"
        //        + ",CREDITCOMPANYCODERF"
        //        + ",DRAFTDRAWINGDATERF"
        //        + ",DRAFTPAYTIMELIMITRF"
        //        + ",DEPOSITALLOWANCERF"
        //        + ",DEPOSITALWCBLNCERF"
        //        + ",DEBITNOTELINKDEPONORF"
        //        + ",LASTRECONCILEADDUPDTRF"
        //        + ",DEPOSITAGENTCODERF"
        //        + ",DEPOSITAGENTNMRF"
        //        + ",CUSTOMERCODERF"
        //        + ",CUSTOMERNAMERF"
        //        + ",CUSTOMERNAME2RF"
        //        + ",CLAIMCODERF"
        //        + ",CLAIMNAME1RF"
        //        + ",CLAIMNAME2RF"
        //        + ",OUTLINERF"
        //   + " FROM DEPSITMAINRF";
        // �� 20070122 18322 c
        #endregion
        private const string SELECT_DEPSITMAIN =
            "SELECT CREATEDATETIMERF"
                + ",UPDATEDATETIMERF"
                + ",ENTERPRISECODERF"
                + ",FILEHEADERGUIDRF"
                + ",UPDEMPLOYEECODERF"
                + ",UPDASSEMBLYID1RF"
                + ",UPDASSEMBLYID2RF"
                + ",LOGICALDELETECODERF"
                + ",ACPTANODRSTATUSRF"
                + ",DEPOSITDEBITNOTECDRF"
                + ",DEPOSITSLIPNORF"
                + ",SALESSLIPNUMRF"
                + ",INPUTDEPOSITSECCDRF"
                + ",ADDUPSECCODERF"
                + ",UPDATESECCDRF"
                + ",SUBSECTIONCODERF"
                + ",MINSECTIONCODERF"
                + ",DEPOSITDATERF"
                + ",ADDUPADATERF"
                + ",DEPOSITKINDCODERF"
                + ",DEPOSITKINDNAMERF"
                + ",DEPOSITKINDDIVCDRF"
                + ",DEPOSITTOTALRF"
                + ",DEPOSITRF"
                + ",FEEDEPOSITRF"
                + ",DISCOUNTDEPOSITRF"
                + ",AUTODEPOSITCDRF"
                //+ ",DEPOSITCDRF"
                + ",DRAFTDRAWINGDATERF"
                + ",DRAFTPAYTIMELIMITRF"
                + ",DRAFTKINDRF"
                + ",DRAFTKINDNAMERF"
                + ",DRAFTDIVIDERF"
                + ",DRAFTDIVIDENAMERF"
                + ",DRAFTNORF"
                + ",DEPOSITALLOWANCERF"
                + ",DEPOSITALWCBLNCERF"
                + ",DEBITNOTELINKDEPONORF"
                + ",LASTRECONCILEADDUPDTRF"
                + ",DEPOSITAGENTCODERF"
                + ",DEPOSITAGENTNMRF"
                + ",DEPOSITINPUTAGENTCDRF"
                + ",DEPOSITINPUTAGENTNMRF"
                + ",CUSTOMERCODERF"
                + ",CUSTOMERNAMERF"
                + ",CUSTOMERNAME2RF"
                + ",CUSTOMERSNMRF"
                + ",CLAIMCODERF"
                + ",CLAIMNAMERF"
                + ",CLAIMNAME2RF"
                + ",CLAIMSNMRF"
                + ",OUTLINERF"
                + ",BANKCODERF"
                + ",BANKNAMERF"
                + ",EDISENDDATERF"
                + ",EDITAKEINDATERF"
           + " FROM DEPSITMAINRF";
        // �� 2007.10.11 980081 c
		#endregion

        #region Public Methods
        /// <summary>
		/// �������擾����
		/// </summary>
		/// <param name="depsitDataList">������񃊃X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="startAddUpDate">�v����t(�J�n)</param>
		/// <param name="endAddUpDate">�v����t(�I��)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.27</br>
		public int Search(out ArrayList depsitDataList, string enterpriseCode, ArrayList addUpSecCodeList,
			int customerCode, int startAddUpDate, int endAddUpDate)
		{		
			return this.SearchProc(out depsitDataList, enterpriseCode, addUpSecCodeList, customerCode, startAddUpDate, endAddUpDate);
		}

		/// <summary>
		/// �������擾����
		/// </summary>
		/// <param name="depsitDataList">������񃊃X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="startAddUpDate">�v����t(�J�n)</param>
		/// <param name="endAddUpDate">�v����t(�I��)</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.27</br>
		public int Search(out ArrayList depsitDataList, string enterpriseCode, ArrayList addUpSecCodeList,
			int customerCode, int startAddUpDate, int endAddUpDate, SqlConnection sqlConnection)
		{		
			return this.SearchProc(out depsitDataList, enterpriseCode, addUpSecCodeList, customerCode, startAddUpDate, endAddUpDate, sqlConnection);
		}

		#endregion

		#region Private Methods
		/// <summary>
		/// �������擾����
		/// </summary>
        /// <param name="depsitMainWorkList">������񃊃X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="startAddUpDate">�v����t(�J�n)</param>
		/// <param name="endAddUpDate">�v����t(�I��)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.27</br>
		private int SearchProc(out ArrayList depsitMainWorkList, string enterpriseCode, ArrayList addUpSecCodeList,
			int customerCode, int startAddUpDate, int endAddUpDate)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			// �������i�[�p���X�g
			depsitMainWorkList = null;
            
			//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
			SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
			if (connectionText == null || connectionText == "") return status;
			
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionText))
				{
					try
					{
						sqlConnection.Open();

						// �������擾����
						status = this.SearchProc(out depsitMainWorkList, enterpriseCode, addUpSecCodeList, customerCode,
							startAddUpDate, endAddUpDate, sqlConnection);
					}
					finally
					{
						if (sqlConnection != null) sqlConnection.Close();
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			return status;
		}
		
		/// <summary>
		/// �������擾����
		/// </summary>
        /// <param name="depsitMainWorkList">������񃊃X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="startAddUpDate">�v����t(�J�n)</param>
		/// <param name="endAddUpDate">�v����t(�I��)</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.27</br>
		private int SearchProc(out ArrayList depsitMainWorkList, string enterpriseCode, ArrayList addUpSecCodeList,
			int customerCode, int startAddUpDate, int endAddUpDate, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			// �������i�[�p���X�g
			depsitMainWorkList = new ArrayList();

			bool isOpened = true;
            
			try
			{
				if (sqlConnection.State != ConnectionState.Open)
				{
					isOpened = false;
					sqlConnection.Open();
				}

				// �����}�X�^����
				status = this.SelectDepsitMain(ref depsitMainWorkList, sqlConnection, enterpriseCode, addUpSecCodeList,
					customerCode, startAddUpDate, endAddUpDate);
			}
			finally
			{
				if (!isOpened) sqlConnection.Close();
			}

			return status;
		}
		
		/// <summary>
		/// �����}�X�^��������
		/// </summary>
        /// <param name="depsitMainWorkList">������񃊃X�g</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCodeList">���_�R�[�h���X�g</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="startAddUpDate">�v����t(�J�n)</param>
		/// <param name="endAddUpDate">�v����t(�I��)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����}�X�^���������A������񃊃X�g��Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.27</br>		
		private int SelectDepsitMain(ref ArrayList depsitMainWorkList, SqlConnection sqlConnection, string enterpriseCode,
			ArrayList addUpSecCodeList, int customerCode, int startAddUpDate, int endAddUpDate)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
			using (SqlCommand sqlCommand = new SqlCommand(SELECT_DEPSITMAIN, sqlConnection))
			{
				// Where���̍쐬
				bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, customerCode, startAddUpDate, endAddUpDate);
				if (!result) return status;

				// OrderBy�ǉ�
				sqlCommand.CommandText += " ORDER BY ADDUPSECCODERF,CUSTOMERCODERF,ADDUPADATERF";

				using (SqlDataReader myReader = sqlCommand.ExecuteReader())
				{
					try
					{
						this.SetListFromSQLReader(ref status, ref depsitMainWorkList, myReader);
					}
					finally
					{
						if (myReader != null) myReader.Close();
					}
				}
			}
			
			return status;
		}

		/// <summary>
		/// Where���쐬����
		/// </summary>
		/// <param name="sqlCommand"></param>
		/// <param name="enterpriseCode"></param>
		/// <param name="addUpSecCodeList"></param>
		/// <param name="customerCode"></param>
		/// <param name="startAddUpDate"></param>
		/// <param name="endAddUpDate"></param>
		/// <returns></returns>
		/// <br>Note       : �����}�X�^�i���ݗp��Where�����쐬���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.27</br>
		private bool MakeWhereString(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int customerCode, 
			int startAddUpDate, int endAddUpDate)
		{
			StringBuilder whereSB = new StringBuilder(" WHERE");

			// ��ƃR�[�h
			whereSB.Append(" ENTERPRISECODERF=@FINDENTERPRISECODE");
			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

			// �_���폜�敪
			whereSB.Append(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
			SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

			// ���Ӑ�R�[�h
			whereSB.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE");
			SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
			paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);

			// �v����t
			if (startAddUpDate <= endAddUpDate)
			{
				if (startAddUpDate == endAddUpDate)
				{
					whereSB.Append(" AND ADDUPADATERF=@FINDADDUPADATE");
					SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPADATE", SqlDbType.Int);
					paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
				}
				else
				{
					whereSB.Append(" AND ADDUPADATERF>=@FINDSTARTADDUPADATE AND ADDUPADATERF<=@FINDENDADDUPADATE");
					SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTADDUPADATE", SqlDbType.Int);
					paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
					SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDADDUPADATE", SqlDbType.Int);
					paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endAddUpDate);
				}
			}
			else
			{
				return false;
			}

			// �v�㋒�_
			StringBuilder whereSectionCode = new StringBuilder();
			if (addUpSecCodeList.Count > 0)
			{
				if (addUpSecCodeList.Count == 1)
				{
					whereSectionCode.Append(" AND ADDUPSECCODERF='" + addUpSecCodeList[0] + "'");
				}
				else
				{
					whereSectionCode.Append(" AND ADDUPSECCODERF IN (");
					for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
					{
						if (ix != 0)
						{
							whereSectionCode.Append(",");
						}
						whereSectionCode.Append("'" + addUpSecCodeList[ix] + "'");
					}					
					whereSectionCode.Append(")");
				}
			}
			whereSB.Append(whereSectionCode.ToString());

			sqlCommand.CommandText += whereSB.ToString();

			return true;
		}

		/// <summary>
		/// �������X�g�i�[����
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
        /// <param name="depsitMainWorkList">�������X�g</param>
		/// <param name="myReader">SQLDataReader</param>
		/// <br>Note       : SQLDataReader�̏���������X�g�ɃZ�b�g���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.27</br>		
		private void SetListFromSQLReader(ref int status, ref ArrayList depsitMainWorkList, SqlDataReader myReader)
		{
			if (depsitMainWorkList == null)
			{
				depsitMainWorkList = new ArrayList();
			}
			
			while (myReader.Read())
			{
				DepsitMainWork depsitMainWork = new DepsitMainWork();
				this.CopyToDataClassFromSelectData(ref depsitMainWork, myReader);
				depsitMainWorkList.Add(depsitMainWork);
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
		}
		
		/// <summary>
		/// SQL�f�[�^���[�_�[�������}�X�^���[�N
		/// </summary>
		/// <param name="depsitMainWork">�������[�N</param>
		/// <param name="myReader">SQL�f�[�^���[�_�[</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e��������[�N�ɃR�s�[���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.27</br>		
		private void CopyToDataClassFromSelectData(ref DepsitMainWork depsitMainWork, SqlDataReader myReader)
        {
            # region --- DEL 2008/06/26 M.Kubota ---
# if false
            // �� 2007.10.11 980081 c
            #region MA SQL�f�[�^���[�_�[�������}�X�^���[�N�i�S�ăR�����g�A�E�g�j
            // �� 20070122 18322 c MA.NS�p�ɕύX
            #region SF SQL�f�[�^���[�_�[�������}�X�^���[�N�i�S�ăR�����g�A�E�g�j
            //depsitMainWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
			//depsitMainWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
			//depsitMainWork.EnterpriseCode		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ENTERPRISECODERF"		));
			//depsitMainWork.FileHeaderGuid		= SqlDataMediator.SqlGetGuid	(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"		));
			//depsitMainWork.UpdEmployeeCode		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"		));
			//depsitMainWork.UpdAssemblyId1		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"		));
			//depsitMainWork.UpdAssemblyId2		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"		));
			//depsitMainWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"	));
			//depsitMainWork.DepositDebitNoteCd	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"	));
			//depsitMainWork.DepositSlipNo		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"		));
			//depsitMainWork.DepositKindCode		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"		));
			//depsitMainWork.CustomerCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTOMERCODERF"			));
			//depsitMainWork.DepositCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("DEPOSITCDRF"			));
			//depsitMainWork.DepositTotal			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"			));
			//depsitMainWork.Outline				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OUTLINERF"				));
			//depsitMainWork.AcceptAnOrderSalesNo	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ACCEPTANORDERSALESNORF"	));
			//depsitMainWork.InputDepositSecCd	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"	));
			//depsitMainWork.DepositDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"	));
			//depsitMainWork.AddUpSecCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDUPSECCODERF"			));
			//depsitMainWork.AddUpADate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"	));
			//depsitMainWork.UpdateSecCd			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("UPDATESECCDRF"			));
			//depsitMainWork.DepositKindName		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"		));
			//depsitMainWork.DepositAllowance		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"		));
			//depsitMainWork.DepositAlwcBlnce		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"		));
			//depsitMainWork.DepositAgentCode		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"		));
			//depsitMainWork.DepositKindDivCd		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("DEPOSITKINDDIVCDRF"		));
			//depsitMainWork.FeeDeposit			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("FEEDEPOSITRF"			));
			//depsitMainWork.DiscountDeposit		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"		));
			//depsitMainWork.CreditOrLoanCd		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"		));
			//depsitMainWork.CreditCompanyCode	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"	));
			//depsitMainWork.Deposit				= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("DEPOSITRF"				));
			//depsitMainWork.DraftDrawingDate		= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"	));
			//depsitMainWork.DraftPayTimeLimit	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
			//depsitMainWork.DebitNoteLinkDepoNo	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"	));
			//depsitMainWork.LastReconcileAddUpDt	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"	));
			//depsitMainWork.AutoDepositCd		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"		));
			//depsitMainWork.AcpOdrDeposit		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRDEPOSITRF"		));
			//depsitMainWork.AcpOdrChargeDeposit	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRCHARGEDEPOSITRF"	));
			//depsitMainWork.AcpOdrDisDeposit		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRDISDEPOSITRF"		));
			//depsitMainWork.VariousCostDeposit	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARIOUSCOSTDEPOSITRF"	));
			//depsitMainWork.VarCostChargeDeposit	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCOSTCHARGEDEPOSITRF"	));
			//depsitMainWork.VarCostDisDeposit	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCOSTDISDEPOSITRF"	));
			//depsitMainWork.AcpOdrDepositAlwc	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRDEPOSITALWCRF"	));
			//depsitMainWork.VarCostDepoAlwc		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCOSTDEPOALWCRF"		));
            //depsitMainWork.VarCostDepoAlwcBlnce	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCOSTDEPOALWCBLNCERF"	)); 
            #endregion

            //// �쐬����
            //depsitMainWork.CreateDateTime           = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
            //// �X�V����
            //depsitMainWork.UpdateDateTime           = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
            //// ��ƃR�[�h
            //depsitMainWork.EnterpriseCode           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //// GUID
            //depsitMainWork.FileHeaderGuid           = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //// �X�V�]�ƈ��R�[�h
            //depsitMainWork.UpdEmployeeCode          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //// �X�V�A�Z���u��ID1
            //depsitMainWork.UpdAssemblyId1           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //// �X�V�A�Z���u��ID2
            //depsitMainWork.UpdAssemblyId2           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //// �_���폜�敪
            //depsitMainWork.LogicalDeleteCode        = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //// �����ԍ��敪
            //depsitMainWork.DepositDebitNoteCd       = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
            //// �����`�[�ԍ�
            //depsitMainWork.DepositSlipNo            = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITSLIPNORF"));
            //// �󒍔ԍ�
            //depsitMainWork.AcceptAnOrderNo          = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            //// �T�[�r�X�`�[�敪
            //depsitMainWork.ServiceSlipCd            = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SERVICESLIPCDRF"));
            //// �������͋��_�R�[�h
            //depsitMainWork.InputDepositSecCd        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
            //// �v�㋒�_�R�[�h
            //depsitMainWork.AddUpSecCode             = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            //// �X�V���_�R�[�h
            //depsitMainWork.UpdateSecCd              = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            //// �������t
            //depsitMainWork.DepositDate              = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("DEPOSITDATERF"));
            //// �v����t
            //depsitMainWork.AddUpADate               = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("ADDUPADATERF"));
            //// ��������R�[�h
            //depsitMainWork.DepositKindCode          = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITKINDCODERF"));
            //// �������햼��
            //depsitMainWork.DepositKindName          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
            //// ��������敪
            //depsitMainWork.DepositKindDivCd         = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
            //// �����v
            //depsitMainWork.DepositTotal             = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DEPOSITTOTALRF"));
            //// �������z
            //depsitMainWork.Deposit                  = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DEPOSITRF"));
            //// �萔�������z
            //depsitMainWork.FeeDeposit               = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("FEEDEPOSITRF"));
            //// �l�������z
            //depsitMainWork.DiscountDeposit          = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
            //// ���x�[�g�����z
            //depsitMainWork.RebateDeposit            = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("REBATEDEPOSITRF"));
            //// ���������敪
            //depsitMainWork.AutoDepositCd            = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("AUTODEPOSITCDRF"));
            //// �a����敪
            //depsitMainWork.DepositCd                = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITCDRF"));
            //// �N���W�b�g�^���[���敪
            //depsitMainWork.CreditOrLoanCd           = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("CREDITORLOANCDRF"));
            //// �N���W�b�g��ЃR�[�h
            //depsitMainWork.CreditCompanyCode        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
            //// ��`�U�o��
            //depsitMainWork.DraftDrawingDate         = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
            //// ��`�x������
            //depsitMainWork.DraftPayTimeLimit        = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
            //// ���������z
            //depsitMainWork.DepositAllowance         = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DEPOSITALLOWANCERF"));
            //// ���������c��
            //depsitMainWork.DepositAlwcBlnce         = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
            //// �ԍ������A���ԍ�
            //depsitMainWork.DebitNoteLinkDepoNo      = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
            //// �ŏI�������݌v���
            //depsitMainWork.LastReconcileAddUpDt     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
            //// �����S���҃R�[�h
            //depsitMainWork.DepositAgentCode         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
            //// �����S���Җ���
            //depsitMainWork.DepositAgentNm           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
            //// ���Ӑ�R�[�h
            //depsitMainWork.CustomerCode             = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("CUSTOMERCODERF"));
            //// ���Ӑ於��
            //depsitMainWork.CustomerName             = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            //// ���Ӑ於��2
            //depsitMainWork.CustomerName2            = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            //// �`�[�E�v
            //depsitMainWork.Outline                  = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            //// �� 20070122 18322 c
            #endregion
            depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
            depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
            depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
            depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            depsitMainWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
            depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
            depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            depsitMainWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
            depsitMainWork.DepositKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
            depsitMainWork.DepositKindDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
            depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
            depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
            depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
            depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
            depsitMainWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
            depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
            depsitMainWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
            depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
            depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
            depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
            depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
            depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
            depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
            depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
            depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
            depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
            depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
            depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
            depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
            depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
            depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
            depsitMainWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
            // �� 2007.12.10 980081 c
            //depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
            depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
            // �� 2007.12.10 980081 c
            // �� 2007.10.11 980081 c
# endif
            #endregion

            depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
            depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
            depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
            depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
            depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
            depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
            depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
            //depsitMainWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
            depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
            depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
            depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
            depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
            depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
            depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
            depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
            depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
            depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
            depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
            depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
            depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
            depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
        }
        # endregion
    }
}