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
	/// KINGET用入金データ抽出DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金データ抽出の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 18023 樋口　政成</br>
	/// <br>Date       : 2005.07.27</br>
	/// <br></br>
	/// <br>Update Note: 2007.01.22 18322 T.Kimura  MA.NS用に変更</br>
    /// <br>             2007.05.14 18322 T.Kimura  サービス伝票区分(ServiceSlipCd)を追加</br>
    /// <br>             2007.10.11 980081 A.Yamada DC.NS用に変更</br>
    /// <br>             2007.12.10 980081 A.Yamada EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更</br>
    /// <br>             --------------------------------------------------------------------------</br>    
    /// <br>             2008.06.26 21112 本リモートは他より使用されていないので、修正は保留とする。</br>
    /// <br></br>
	/// </remarks>
	[Serializable]
	public class KingetDepsitMainDB : RemoteDB, IRemoteDB
	{
		#region Constructor
		/// <summary>
		/// KINGET用入金抽出DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.27</br>
		/// </remarks>
		public KingetDepsitMainDB() :
			base("SFUKK01343D", "Broadleaf.Application.Remoting.ParamData.DepsitMainWork", "DEPSITMAINRF")
		{
		}
		#endregion

		# region Private Const

        // ↓ 2007.10.11 980081 c
        #region MA 入金マスタSELECT文(コメントアウト)
        // ↓ 20070122 18322 c MA.NS用に変更
        #region SF 入金マスタSELECT文（コメントアウト）
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
        // ↑ 20070122 18322 c
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
        // ↑ 2007.10.11 980081 c
		#endregion

        #region Public Methods
        /// <summary>
		/// 入金情報取得処理
		/// </summary>
		/// <param name="depsitDataList">入金情報リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCodeList">拠点コードリスト</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="startAddUpDate">計上日付(開始)</param>
		/// <param name="endAddUpDate">計上日付(終了)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 入金マスタDBより検索パラメータの条件でデータを取得し返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.27</br>
		public int Search(out ArrayList depsitDataList, string enterpriseCode, ArrayList addUpSecCodeList,
			int customerCode, int startAddUpDate, int endAddUpDate)
		{		
			return this.SearchProc(out depsitDataList, enterpriseCode, addUpSecCodeList, customerCode, startAddUpDate, endAddUpDate);
		}

		/// <summary>
		/// 入金情報取得処理
		/// </summary>
		/// <param name="depsitDataList">入金情報リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCodeList">拠点コードリスト</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="startAddUpDate">計上日付(開始)</param>
		/// <param name="endAddUpDate">計上日付(終了)</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 入金マスタDBより検索パラメータの条件でデータを取得し返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.27</br>
		public int Search(out ArrayList depsitDataList, string enterpriseCode, ArrayList addUpSecCodeList,
			int customerCode, int startAddUpDate, int endAddUpDate, SqlConnection sqlConnection)
		{		
			return this.SearchProc(out depsitDataList, enterpriseCode, addUpSecCodeList, customerCode, startAddUpDate, endAddUpDate, sqlConnection);
		}

		#endregion

		#region Private Methods
		/// <summary>
		/// 入金情報取得処理
		/// </summary>
        /// <param name="depsitMainWorkList">入金情報リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCodeList">拠点コードリスト</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="startAddUpDate">計上日付(開始)</param>
		/// <param name="endAddUpDate">計上日付(終了)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 入金マスタDBより検索パラメータの条件でデータを取得し返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.27</br>
		private int SearchProc(out ArrayList depsitMainWorkList, string enterpriseCode, ArrayList addUpSecCodeList,
			int customerCode, int startAddUpDate, int endAddUpDate)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			// 入金情報格納用リスト
			depsitMainWorkList = null;
            
			//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
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

						// 入金情報取得処理
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
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			return status;
		}
		
		/// <summary>
		/// 入金情報取得処理
		/// </summary>
        /// <param name="depsitMainWorkList">入金情報リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCodeList">拠点コードリスト</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="startAddUpDate">計上日付(開始)</param>
		/// <param name="endAddUpDate">計上日付(終了)</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 入金マスタDBより検索パラメータの条件でデータを取得し返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.27</br>
		private int SearchProc(out ArrayList depsitMainWorkList, string enterpriseCode, ArrayList addUpSecCodeList,
			int customerCode, int startAddUpDate, int endAddUpDate, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			// 入金情報格納用リスト
			depsitMainWorkList = new ArrayList();

			bool isOpened = true;
            
			try
			{
				if (sqlConnection.State != ConnectionState.Open)
				{
					isOpened = false;
					sqlConnection.Open();
				}

				// 入金マスタ検索
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
		/// 入金マスタ検索処理
		/// </summary>
        /// <param name="depsitMainWorkList">入金情報リスト</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCodeList">拠点コードリスト</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="startAddUpDate">計上日付(開始)</param>
		/// <param name="endAddUpDate">計上日付(終了)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 入金マスタを検索し、入金情報リストを返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.27</br>		
		private int SelectDepsitMain(ref ArrayList depsitMainWorkList, SqlConnection sqlConnection, string enterpriseCode,
			ArrayList addUpSecCodeList, int customerCode, int startAddUpDate, int endAddUpDate)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
			using (SqlCommand sqlCommand = new SqlCommand(SELECT_DEPSITMAIN, sqlConnection))
			{
				// Where文の作成
				bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, customerCode, startAddUpDate, endAddUpDate);
				if (!result) return status;

				// OrderBy追加
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
		/// Where文作成処理
		/// </summary>
		/// <param name="sqlCommand"></param>
		/// <param name="enterpriseCode"></param>
		/// <param name="addUpSecCodeList"></param>
		/// <param name="customerCode"></param>
		/// <param name="startAddUpDate"></param>
		/// <param name="endAddUpDate"></param>
		/// <returns></returns>
		/// <br>Note       : 入金マスタ絞込み用のWhere文を作成します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.27</br>
		private bool MakeWhereString(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int customerCode, 
			int startAddUpDate, int endAddUpDate)
		{
			StringBuilder whereSB = new StringBuilder(" WHERE");

			// 企業コード
			whereSB.Append(" ENTERPRISECODERF=@FINDENTERPRISECODE");
			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

			// 論理削除区分
			whereSB.Append(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
			SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

			// 得意先コード
			whereSB.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE");
			SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
			paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);

			// 計上日付
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

			// 計上拠点
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
		/// 入金リスト格納処理
		/// </summary>
		/// <param name="status">ステータス</param>
        /// <param name="depsitMainWorkList">入金リスト</param>
		/// <param name="myReader">SQLDataReader</param>
		/// <br>Note       : SQLDataReaderの情報を入金リストにセットします。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
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
		/// SQLデータリーダー→入金マスタワーク
		/// </summary>
		/// <param name="depsitMainWork">入金ワーク</param>
		/// <param name="myReader">SQLデータリーダー</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : SQLデータリーダーに保持している内容を入金ワークにコピーします。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.27</br>		
		private void CopyToDataClassFromSelectData(ref DepsitMainWork depsitMainWork, SqlDataReader myReader)
        {
            # region --- DEL 2008/06/26 M.Kubota ---
# if false
            // ↓ 2007.10.11 980081 c
            #region MA SQLデータリーダー→入金マスタワーク（全てコメントアウト）
            // ↓ 20070122 18322 c MA.NS用に変更
            #region SF SQLデータリーダー→入金マスタワーク（全てコメントアウト）
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

            //// 作成日時
            //depsitMainWork.CreateDateTime           = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
            //// 更新日時
            //depsitMainWork.UpdateDateTime           = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
            //// 企業コード
            //depsitMainWork.EnterpriseCode           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //// GUID
            //depsitMainWork.FileHeaderGuid           = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //// 更新従業員コード
            //depsitMainWork.UpdEmployeeCode          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //// 更新アセンブリID1
            //depsitMainWork.UpdAssemblyId1           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //// 更新アセンブリID2
            //depsitMainWork.UpdAssemblyId2           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //// 論理削除区分
            //depsitMainWork.LogicalDeleteCode        = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //// 入金赤黒区分
            //depsitMainWork.DepositDebitNoteCd       = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
            //// 入金伝票番号
            //depsitMainWork.DepositSlipNo            = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITSLIPNORF"));
            //// 受注番号
            //depsitMainWork.AcceptAnOrderNo          = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            //// サービス伝票区分
            //depsitMainWork.ServiceSlipCd            = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SERVICESLIPCDRF"));
            //// 入金入力拠点コード
            //depsitMainWork.InputDepositSecCd        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
            //// 計上拠点コード
            //depsitMainWork.AddUpSecCode             = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            //// 更新拠点コード
            //depsitMainWork.UpdateSecCd              = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            //// 入金日付
            //depsitMainWork.DepositDate              = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("DEPOSITDATERF"));
            //// 計上日付
            //depsitMainWork.AddUpADate               = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("ADDUPADATERF"));
            //// 入金金種コード
            //depsitMainWork.DepositKindCode          = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITKINDCODERF"));
            //// 入金金種名称
            //depsitMainWork.DepositKindName          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
            //// 入金金種区分
            //depsitMainWork.DepositKindDivCd         = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
            //// 入金計
            //depsitMainWork.DepositTotal             = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DEPOSITTOTALRF"));
            //// 入金金額
            //depsitMainWork.Deposit                  = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DEPOSITRF"));
            //// 手数料入金額
            //depsitMainWork.FeeDeposit               = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("FEEDEPOSITRF"));
            //// 値引入金額
            //depsitMainWork.DiscountDeposit          = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
            //// リベート入金額
            //depsitMainWork.RebateDeposit            = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("REBATEDEPOSITRF"));
            //// 自動入金区分
            //depsitMainWork.AutoDepositCd            = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("AUTODEPOSITCDRF"));
            //// 預り金区分
            //depsitMainWork.DepositCd                = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEPOSITCDRF"));
            //// クレジット／ローン区分
            //depsitMainWork.CreditOrLoanCd           = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("CREDITORLOANCDRF"));
            //// クレジット会社コード
            //depsitMainWork.CreditCompanyCode        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
            //// 手形振出日
            //depsitMainWork.DraftDrawingDate         = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
            //// 手形支払期日
            //depsitMainWork.DraftPayTimeLimit        = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
            //// 入金引当額
            //depsitMainWork.DepositAllowance         = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DEPOSITALLOWANCERF"));
            //// 入金引当残高
            //depsitMainWork.DepositAlwcBlnce         = SqlDataMediator.SqlGetInt64(myReader,  myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
            //// 赤黒入金連結番号
            //depsitMainWork.DebitNoteLinkDepoNo      = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
            //// 最終消し込み計上日
            //depsitMainWork.LastReconcileAddUpDt     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,  myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
            //// 入金担当者コード
            //depsitMainWork.DepositAgentCode         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
            //// 入金担当者名称
            //depsitMainWork.DepositAgentNm           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
            //// 得意先コード
            //depsitMainWork.CustomerCode             = SqlDataMediator.SqlGetInt32(myReader,  myReader.GetOrdinal("CUSTOMERCODERF"));
            //// 得意先名称
            //depsitMainWork.CustomerName             = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            //// 得意先名称2
            //depsitMainWork.CustomerName2            = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            //// 伝票摘要
            //depsitMainWork.Outline                  = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            //// ↑ 20070122 18322 c
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
            // ↓ 2007.12.10 980081 c
            //depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
            depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
            // ↑ 2007.12.10 980081 c
            // ↑ 2007.10.11 980081 c
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