using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 売掛情報取得リモート リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note		: 売掛情報取得リモートメインクラスです。</br>
	/// <br>Programmer	: 97036 amami</br>
	/// <br>Date		: 2007.05.08</br>
    /// <br></br>
    /// <br>Update Note : 980081  山田 明友</br>
    /// <br>            : 2007.12.04 流通基幹対応</br>
    /// <br></br>
    /// <br>Update Note: 2014/02/20 宮本 利明</br>
    /// <br>           : 仕掛一覧 №2294対応</br>
    /// <br>           : 売掛情報取得処理のStatusを返すように修正</br>
    /// </remarks>
	[Serializable]
	public class CustAccRecInfGetDB : RemoteDB, ICustAccRecInfGetDB
	{
		# region Constractor
		/// <summary>
		/// 売掛情報取得リモート リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売掛情報取得リモートの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
		/// </remarks>
		public CustAccRecInfGetDB()
			: base("MAKAU00184D", "Broadleaf.Application.Remoting.ParamData.CustAccRecInfGetWork", "CustAccRecRF")
		{
			// 売上情報取得DBリモートオブジェクト
			this._ledgerSalesSlipWorkDB = null;

			// 入金情報取得DBリモートオブジェクト
			this._ledgerDepsitMainWorkDB = null;

		}
		# endregion

		#region Private Member
		/// <summary>売上情報取得DBリモートオブジェクト</summary>
		private LedgerSalesSlipWorkDB _ledgerSalesSlipWorkDB;

		/// <summary>入金情報取得DBリモートオブジェクト</summary>
		private LedgerDepsitMainWorkDB _ledgerDepsitMainWorkDB;

		/// <summary>印刷タイプ</summary>
        private enum PrintMode
        {
            Slip = 0,
            Dtl = 1
        }
		#endregion

        /// <summary>
        /// 売掛情報取得処理
        /// </summary>
        /// <param name="objCustAccRecInfGetWorkList">得意先売掛金額クラスワークリスト</param>
        /// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
        /// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="custAccRecInfSearchParameter">売掛情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で得意先売掛情報を取得します。
        ///                : 主に得意先元帳にて使用します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchSlip(out object objCustAccRecInfGetWorkList, out object objLedgerSalesSlipWorkList,
            out object objLedgerDepsitMainWorkList, CustAccRecInfSearchParameter custAccRecInfSearchParameter)
        {
            int status = Search(out objCustAccRecInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, custAccRecInfSearchParameter, (int)PrintMode.Slip);

            return status;
        }

        /// <summary>
        /// 売掛情報取得処理
        /// </summary>
        /// <param name="objCustAccRecInfGetWorkList">得意先売掛金額クラスワークリスト</param>
        /// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
        /// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="custAccRecInfSearchParameter">売掛情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で得意先売掛情報を取得します。
        ///                : 主に得意先元帳にて使用します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchDtl(out object objCustAccRecInfGetWorkList, out object objLedgerSalesSlipWorkList,
            out object objLedgerDepsitMainWorkList, CustAccRecInfSearchParameter custAccRecInfSearchParameter)
        {
            return Search(out objCustAccRecInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, custAccRecInfSearchParameter, (int)PrintMode.Dtl);
        }

		/// <summary>
		/// 売掛情報取得処理
		/// </summary>
		/// <param name="objCustAccRecInfGetWorkList">得意先売掛金額クラスワークリスト</param>
		/// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
		/// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="custAccRecInfSearchParameter">売掛情報取得抽出条件パラメータクラス</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で得意先売掛情報を取得します。
		///                : 主に得意先元帳にて使用します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
		public int Search(out object objCustAccRecInfGetWorkList, out object objLedgerSalesSlipWorkList,
			out object objLedgerDepsitMainWorkList, CustAccRecInfSearchParameter custAccRecInfSearchParameter, int printMode)
		{
			// 得意先売掛金額マスタ取得処理
            CustomSerializeArrayList custAccRecInfGetWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerSalesSlipWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerDepsitMainWorkList = new CustomSerializeArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // --- UPD 2014/02/20 T.Miyamoto ------------------------------>>>>>
            //SearchPrc(ref custAccRecInfGetWorkList, ref ledgerSalesSlipWorkList, ref ledgerDepsitMainWorkList, custAccRecInfSearchParameter,printMode);

            //if (custAccRecInfGetWorkList.Count != 0)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            //else
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //    ledgerSalesSlipWorkList = new CustomSerializeArrayList();
            //    ledgerDepsitMainWorkList = new CustomSerializeArrayList();
            //}
            status = SearchPrc(ref custAccRecInfGetWorkList, ref ledgerSalesSlipWorkList, ref ledgerDepsitMainWorkList, custAccRecInfSearchParameter, printMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (custAccRecInfGetWorkList.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }
            // --- UPD 2014/02/20 T.Miyamoto ------------------------------<<<<<
           
            objCustAccRecInfGetWorkList = custAccRecInfGetWorkList;
            objLedgerSalesSlipWorkList = ledgerSalesSlipWorkList;
            objLedgerDepsitMainWorkList = ledgerDepsitMainWorkList;
            
            return status;
		}


		/// <summary>
		/// 売掛情報取得処理
		/// </summary>
        /// <param name="csCustAccRecInfGetWorkList">得意先売掛金額クラスワーク</param>
		/// <param name="csLedgerSalesSlipWorkList">売上情報リスト</param>
		/// <param name="csLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="parameter">検索パラメータ</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で得意先売掛情報を取得します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
        private int SearchPrc(ref CustomSerializeArrayList csCustAccRecInfGetWorkList, ref CustomSerializeArrayList csLedgerSalesSlipWorkList, ref CustomSerializeArrayList csLedgerDepsitMainWorkList, CustAccRecInfSearchParameter parameter, int printMode)
		{
			SqlConnection sqlConnection = null;
			//SqlEncryptInfo sqlEncryptInfo = null;

			// 戻り値の初期化
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			int st;

            ArrayList ledgerSalesSlipWorkList = new ArrayList();
            ArrayList ledgerDepsitMainWorkList = new ArrayList();

            try
			{
				// ユーザーDB[IndexCode_UserDB]コネクション文字列を取得
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return (int)ConstantManagement.DB_Status.ctDB_ERROR;

				// コネクション接続
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				// 暗号化対応部品
				//sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
				//sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //売掛履歴データ抽出
                st = this.SearchCustAccRecInfGetWork(ref csCustAccRecInfGetWorkList, parameter, sqlConnection);
                if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return st;
                }

                //売掛履歴をベースにデータを抽出
                foreach (CustAccRecInfGetWork accWork in csCustAccRecInfGetWorkList)
                {

                    // 売上データ取得処理
                    st = this.SearchLedgerSalesSlipWork(ref ledgerSalesSlipWorkList, accWork, ref sqlConnection, printMode);

                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        return st;
                    }

                    // 入金データ取得処理
                    st = this.SearchLedgerDepsitMainWork(ref ledgerDepsitMainWorkList, accWork, ref sqlConnection);
                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        return st;
                    }

                    //売掛履歴単位にArrayListを追加
                    if (ledgerSalesSlipWorkList == null)
                        ledgerSalesSlipWorkList = new ArrayList();
                    if (ledgerDepsitMainWorkList == null)
                        ledgerDepsitMainWorkList = new ArrayList();

                    csLedgerSalesSlipWorkList.Add(ledgerSalesSlipWorkList);
                    csLedgerDepsitMainWorkList.Add(ledgerDepsitMainWorkList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex)
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			finally
			{
				//if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen)) sqlEncryptInfo.CloseSymKey(ref sqlConnection);
				if (sqlConnection != null) sqlConnection.Close();
			}

			return status;
		}

        #region 売上データ作成処理
        /// <summary>
        /// 売上データ取得処理
        /// </summary>
        /// <param name="ledgerSalesSlipWorkList">売上データワーク</param>
        /// <param name="accWork">売掛履歴データ</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で売上データを取得します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        private int SearchLedgerSalesSlipWork(ref ArrayList ledgerSalesSlipWorkList, CustAccRecInfGetWork accWork, ref SqlConnection sqlConnection, int printMode)
        {
            if (this._ledgerSalesSlipWorkDB == null) this._ledgerSalesSlipWorkDB = new LedgerSalesSlipWorkDB();

            // 検索パラメータセット
            ArrayList addUpSecCodeList = new ArrayList();
            addUpSecCodeList.Add(accWork.AddUpSecCode);							// 計上拠点コード
            int startDay = TDateTime.DateTimeToLongDate("YYYYMMDD", accWork.StMonCAddUpUpdDate);
            int endDay = TDateTime.DateTimeToLongDate("YYYYMMDD", accWork.AddUpDate);

            int st = 0;
            // 売上データ検索処理
            object objLedgerSalesSlipWorkList = null;
            //引数の1は売上商品区分の判断に使用している。売掛で抽出する場合は消費税調整レコードは抽出しない
            if (printMode == (int)PrintMode.Slip)
            {
                st = this._ledgerSalesSlipWorkDB.SearchSlip(out objLedgerSalesSlipWorkList, accWork.EnterpriseCode, addUpSecCodeList, accWork.ClaimCode, accWork.ClaimCode, startDay, endDay, 0,ref sqlConnection);
            }
            else
            if (printMode == (int)PrintMode.Dtl)
            {
                st = this._ledgerSalesSlipWorkDB.SearchDtl(out objLedgerSalesSlipWorkList, accWork.EnterpriseCode, addUpSecCodeList, accWork.ClaimCode, accWork.ClaimCode, startDay, endDay, 0,ref sqlConnection);
            }

            ledgerSalesSlipWorkList = objLedgerSalesSlipWorkList as ArrayList;

            return st;
        }
        #endregion

        #region 入金データ取得
        /// <summary>
        /// 入金データ取得処理
        /// </summary>
        /// <param name="ledgerDepsitMainWorkList">入金データワーク</param>
        /// <param name="accWork">売掛履歴データワーク</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で入金データを取得します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        private int SearchLedgerDepsitMainWork(ref ArrayList ledgerDepsitMainWorkList, CustAccRecInfGetWork accWork, ref SqlConnection sqlConnection)
        {
            if (this._ledgerDepsitMainWorkDB == null) this._ledgerDepsitMainWorkDB = new LedgerDepsitMainWorkDB();

            // 検索パラメータセット
            ArrayList addUpSecCodeList = new ArrayList();
            addUpSecCodeList.Add(accWork.AddUpSecCode);							// 計上拠点コード
            int startDay = TDateTime.DateTimeToLongDate("YYYYMMDD", accWork.StMonCAddUpUpdDate);
            int endDay = TDateTime.DateTimeToLongDate("YYYYMMDD", accWork.AddUpDate);


            // 入金データ検索処理
            object objLedgerDepsitMainWorkList;
            int st = this._ledgerDepsitMainWorkDB.Search(out objLedgerDepsitMainWorkList, accWork.EnterpriseCode, addUpSecCodeList, accWork.ClaimCode, accWork.ClaimCode, startDay, endDay, ref sqlConnection);

            ledgerDepsitMainWorkList = objLedgerDepsitMainWorkList as ArrayList;

            return st;
        }
        #endregion

        #region 売掛金額マスタ取得
        /// <summary>
		/// 得意先売掛金額マスタ取得処理
		/// </summary>
		/// <param name="custAccRecInfGetWorkList">得意先売掛金額クラスワーク</param>
		/// <param name="parameter">検索パラメータ</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で得意先売掛金額マスタを取得します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>		
        private int SearchCustAccRecInfGetWork(ref CustomSerializeArrayList custAccRecInfGetWorkList, CustAccRecInfSearchParameter parameter, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			SqlDataReader myReader = null;
            CustomSerializeArrayList al = new CustomSerializeArrayList();

            string sqlText = string.Empty;
			try
			{
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   ACC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,ACC.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "  ,ACC.CLAIMCODERF" + Environment.NewLine;
                sqlText += "  ,ACC.CLAIMNAMERF" + Environment.NewLine;
                sqlText += "  ,ACC.CLAIMNAME2RF" + Environment.NewLine;
                sqlText += "  ,ACC.CLAIMSNMRF" + Environment.NewLine;
                sqlText += "  ,ACC.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,ACC.CUSTOMERNAMERF" + Environment.NewLine;
                sqlText += "  ,ACC.CUSTOMERNAME2RF" + Environment.NewLine;
                sqlText += "  ,ACC.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "  ,ACC.ADDUPDATERF" + Environment.NewLine;
                sqlText += "  ,ACC.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "  ,ACC.LASTTIMEACCRECRF" + Environment.NewLine;
                sqlText += "  ,ACC.ACPODRTTL2TMBFACCRECRF" + Environment.NewLine;
                sqlText += "  ,ACC.ACPODRTTL3TMBFACCRECRF" + Environment.NewLine;
                sqlText += "  ,ACC.THISTIMEDMDNRMLRF" + Environment.NewLine;
                sqlText += "  ,ACC.THISTIMETTLBLCACCRF" + Environment.NewLine;
                sqlText += "  ,ACC.OFSTHISTIMESALESRF" + Environment.NewLine;
                sqlText += "  ,ACC.OFSTHISSALESTAXRF" + Environment.NewLine;
                sqlText += "  ,ACC.THISSALESPRICRGDSRF" + Environment.NewLine;
                sqlText += "  ,ACC.THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                sqlText += "  ,ACC.THISSALESPRICDISRF" + Environment.NewLine;
                sqlText += "  ,ACC.THISSALESPRCTAXDISRF" + Environment.NewLine;
                sqlText += "  ,ACC.TAXADJUSTRF" + Environment.NewLine;
                sqlText += "  ,ACC.BALANCEADJUSTRF" + Environment.NewLine;
                sqlText += "  ,ACC.AFCALTMONTHACCRECRF" + Environment.NewLine;
                sqlText += "  ,ACC.MONTHADDUPEXPDATERF" + Environment.NewLine;
                sqlText += "  ,ACC.STMONCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "  ,ACC.LAMONCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "  ,ACC.SALESSLIPCOUNTRF" + Environment.NewLine;
                sqlText += "  ,ACC.THISTIMESALESRF" + Environment.NewLine;
                sqlText += "  ,ACC.THISSALESTAXRF" + Environment.NewLine;
                sqlText += "  ,ACC.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += "FROM CUSTACCRECRF AS ACC" + Environment.NewLine;

				SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

				// Where文作成処理
				bool result = this.MakeWhereStringForSelectCustAccRec(sqlCommand, parameter);
				if (!result) return status;

				// OrderBy追加
                sqlCommand.CommandText += " ORDER BY ACC.ADDUPDATERF";

				// データ読込
				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					CustAccRecInfGetWork custAccRecInfGetWork = new CustAccRecInfGetWork();

					// SQLデータリーダー→得意先売掛金額ワーク転記処理
					this.CopyToDataClassFromSelectData(ref custAccRecInfGetWork, myReader);

					al.Add(custAccRecInfGetWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			finally
			{
				if ((myReader != null) && (myReader.IsClosed == false)) myReader.Close();
			}


			foreach (CustAccRecInfGetWork val in al)
			{
				custAccRecInfGetWorkList.Add(val);
			}

			return status;
		}

		/// <summary>
		/// Where文作成処理（得意先売掛金額マスタ検索）
		/// </summary>
		/// <param name="sqlCommand">SqlCommand</param>
		/// <param name="parameter">検索パラメータ</param>
		/// <returns>true:正常, false:エラー</returns>
		/// <br>Note       : 得意先売掛金額マスタを検索するためのWhere文を作成します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>		
		private bool MakeWhereStringForSelectCustAccRec(SqlCommand sqlCommand, CustAccRecInfSearchParameter parameter)
		{
            string sqlString = " WHERE" + Environment.NewLine;

            // 企業コード
            sqlString += "ACC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);

            // 論理削除区分
            sqlString += "AND ACC.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);


            // 開始計上年月日
            if (parameter.StartAddUpYearMonth != DateTime.MinValue)
            {
                sqlString += "AND ACC.ADDUPYEARMONTHRF>=@FINDSTADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpDate = sqlCommand.Parameters.Add("@FINDSTADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(parameter.StartAddUpYearMonth);
            }

            // 開始計上年月日
            if (parameter.EndAddUpYearMonth != DateTime.MinValue)
            {
                sqlString += "AND ACC.ADDUPYEARMONTHRF<=@FINDEDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpDate = sqlCommand.Parameters.Add("@FINDEDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(parameter.EndAddUpYearMonth);
            }

			// 計上拠点
            //計上拠点コード
            if (parameter.AddUpSecCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in parameter.AddUpSecCodeList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    sqlString += "AND ACC.ADDUPSECCODERF IN (" + sectionString + ") ";
                }

                sqlString += Environment.NewLine;
            }

            // 開始得意先コード
            if (parameter.StartCustomerCode != 0)
            {
                sqlString += "AND ACC.CLAIMCODERF>=@FINDSTCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(parameter.StartCustomerCode);
            }

            // 終了得意先コード
            if (parameter.EndCustomerCode != 0)
            {
                sqlString += "AND ACC.CLAIMCODERF<=@FINDEDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(parameter.EndCustomerCode);
            }

            //集計レコードのみ抽出
            sqlString += " AND ACC.CUSTOMERCODERF=0 " + Environment.NewLine;

            sqlCommand.CommandText += sqlString;

			return true;
		}

		/// <summary>
		/// SQLデータリーダー→得意先売掛金額ワーク転記処理
		/// </summary>
		/// <param name="custAccRecInfGetWork">得意先売掛金額ワーク</param>
		/// <param name="myReader">SQLデータリーダー</param>
		/// <br>Note       : 得意先売掛金額ワークに転記します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>		
		private void CopyToDataClassFromSelectData(ref CustAccRecInfGetWork custAccRecInfGetWork, SqlDataReader myReader)
		{
            custAccRecInfGetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            custAccRecInfGetWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            custAccRecInfGetWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            custAccRecInfGetWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            custAccRecInfGetWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            custAccRecInfGetWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            custAccRecInfGetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            custAccRecInfGetWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            custAccRecInfGetWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            custAccRecInfGetWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            custAccRecInfGetWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            custAccRecInfGetWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            custAccRecInfGetWork.LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF"));
            custAccRecInfGetWork.AcpOdrTtl2TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFACCRECRF"));
            custAccRecInfGetWork.AcpOdrTtl3TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFACCRECRF"));
            custAccRecInfGetWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            custAccRecInfGetWork.ThisTimeTtlBlcAcc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACCRF"));
            custAccRecInfGetWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            custAccRecInfGetWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            custAccRecInfGetWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            custAccRecInfGetWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            custAccRecInfGetWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            custAccRecInfGetWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            custAccRecInfGetWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            custAccRecInfGetWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            custAccRecInfGetWork.AfCalTMonthAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALTMONTHACCRECRF"));
            custAccRecInfGetWork.MonthAddUpExpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHADDUPEXPDATERF"));
            custAccRecInfGetWork.StMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STMONCADDUPUPDDATERF"));
            custAccRecInfGetWork.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
            custAccRecInfGetWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            custAccRecInfGetWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            custAccRecInfGetWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            custAccRecInfGetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            // 締済フラグ
			custAccRecInfGetWork.CloseFlg = 1;

        }
        #endregion
    }
}
