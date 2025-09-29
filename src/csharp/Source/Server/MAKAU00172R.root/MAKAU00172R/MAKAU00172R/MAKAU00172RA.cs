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
	/// 請求情報取得リモート リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note		: 請求情報取得リモートメインクラスです。</br>
	/// <br>Programmer	: 97036 amami</br>
	/// <br>Date		: 2007.05.08</br>
    /// <br></br>
    /// <br>Update Note : 980081  山田 明友</br>
    /// <br>            : 2007.12.04 流通基幹対応</br>
    /// </remarks>
	[Serializable]
	public class CustDmdPrcInfGetDB : RemoteDB, ICustDmdPrcInfGetDB
	{
		# region Constractor
		/// <summary>
		/// 請求情報取得リモート リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 請求情報取得リモートの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
		/// </remarks>
        public CustDmdPrcInfGetDB()
			: base("MAKAU00174D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcInfGetWork", "CustDmdPrcRF")
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

        private enum PrintMode
        {
            Slip = 0,
            Dtl = 1
        }
		#endregion

        #region メイン
		/// <summary>
		/// 請求情報取得処理
		/// </summary>
		/// <param name="objCustDmdPrcInfGetWorkList">得意先請求金額クラスワークリスト</param>
		/// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
		/// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
		/// <param name="custDmdPrcInfSearchParameter">請求情報取得抽出条件パラメータクラス</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で得意先請求情報を取得します。
		///                : 主に得意先元帳にて使用します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
        public int SearchSlip(out object objCustDmdPrcInfGetWorkList, out object objLedgerSalesSlipWorkList,
            out object objLedgerDepsitMainWorkList, CustDmdPrcInfSearchParameter custDmdPrcInfSearchParameter)
        {
            return Search(out objCustDmdPrcInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, custDmdPrcInfSearchParameter, (int)PrintMode.Slip);
        }

        /// <summary>
        /// 請求情報取得処理
        /// </summary>
        /// <param name="objCustDmdPrcInfGetWorkList">得意先請求金額クラスワークリスト</param>
        /// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
        /// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="custDmdPrcInfSearchParameter">請求情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で得意先請求情報を取得します。
        ///                : 主に得意先元帳にて使用します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchDtl(out object objCustDmdPrcInfGetWorkList, out object objLedgerSalesSlipWorkList,
            out object objLedgerDepsitMainWorkList, CustDmdPrcInfSearchParameter custDmdPrcInfSearchParameter)
        {
            return Search(out objCustDmdPrcInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, custDmdPrcInfSearchParameter, (int)PrintMode.Dtl);
        }

		/// <summary>
		/// 請求情報取得処理
		/// </summary>
		/// <param name="objCustDmdPrcInfGetWorkList">得意先請求金額クラスワークリスト</param>
		/// <param name="objLedgerSalesSlipWorkList">売上情報リスト</param>
		/// <param name="objLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="custDmdPrcInfSearchParameter">請求情報取得抽出条件パラメータクラス</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で得意先請求情報を取得します。
		///                : 主に得意先元帳にて使用します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
		public int Search(out object objCustDmdPrcInfGetWorkList, out object objLedgerSalesSlipWorkList,
			out object objLedgerDepsitMainWorkList, CustDmdPrcInfSearchParameter custDmdPrcInfSearchParameter ,int printMode)
		{
            //// 得意先請求金額マスタ取得処理
            CustomSerializeArrayList custDmdPrcInfGetWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerSalesSlipWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerDepsitMainWorkList = new CustomSerializeArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SearchPrc(ref custDmdPrcInfGetWorkList, ref ledgerSalesSlipWorkList, ref ledgerDepsitMainWorkList, custDmdPrcInfSearchParameter, printMode);
            
            if (custDmdPrcInfGetWorkList.Count != 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                ledgerSalesSlipWorkList = new CustomSerializeArrayList();
                ledgerDepsitMainWorkList = new CustomSerializeArrayList();
            }

            objCustDmdPrcInfGetWorkList = custDmdPrcInfGetWorkList;
            objLedgerSalesSlipWorkList = ledgerSalesSlipWorkList;
            objLedgerDepsitMainWorkList = ledgerDepsitMainWorkList;

            return status;
        }

        /// <summary>
        /// 請求情報取得処理
        /// </summary>
        /// <param name="csCustDmdPrcInfGetWorkList">得意先請求金額クラスワーク</param>
        /// <param name="csLedgerSalesSlipWorkList">売上情報リスト</param>
        /// <param name="csLedgerDepsitMainWorkList">入金情報リスト</param>
        /// <param name="parameter">検索パラメータ</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で得意先請求情報を取得します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        private int SearchPrc(ref CustomSerializeArrayList csCustDmdPrcInfGetWorkList, ref CustomSerializeArrayList csLedgerSalesSlipWorkList, ref CustomSerializeArrayList csLedgerDepsitMainWorkList, CustDmdPrcInfSearchParameter parameter, int printMode)
        {
            SqlConnection sqlConnection = null;
            //			SqlEncryptInfo sqlEncryptInfo = null;

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
                //				sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //				sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //請求履歴データ抽出
                st = this.SearchCustDmdPrcInfGetWork(ref csCustDmdPrcInfGetWorkList, parameter, sqlConnection);
                if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return st;
                }

                //請求履歴をベースにデータを抽出
                foreach (CustDmdPrcInfGetWork dmdWork in csCustDmdPrcInfGetWorkList)
                {

                    // 売上データ取得処理
                    st = this.SearchLedgerSalesSlipWork(ref ledgerSalesSlipWorkList, dmdWork, ref sqlConnection, printMode);

                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        return st;
                    }

                    // 入金データ取得処理
                    st = this.SearchLedgerDepsitMainWork(ref ledgerDepsitMainWorkList, dmdWork, ref sqlConnection);
                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        return st;
                    }

                    //請求履歴単位にArrayListを追加
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
                //				if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen)) sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                if (sqlConnection != null) sqlConnection.Close();
            }

            return status;
        }

        #endregion

        #region 売上データ作成処理
        /// <summary>
        /// 売上データ取得処理
        /// </summary>
        /// <param name="ledgerSalesSlipWorkList">売上データワーク</param>
        /// <param name="dmdWork">請求履歴データ</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で売上データを取得します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        private int SearchLedgerSalesSlipWork(ref ArrayList ledgerSalesSlipWorkList, CustDmdPrcInfGetWork dmdWork, ref SqlConnection sqlConnection, int printMode)
        {
            if (this._ledgerSalesSlipWorkDB == null) this._ledgerSalesSlipWorkDB = new LedgerSalesSlipWorkDB();

            // 検索パラメータセット
            ArrayList addUpSecCodeList = new ArrayList();
            addUpSecCodeList.Add(dmdWork.AddUpSecCode);							// 計上拠点コード
            int startDay = TDateTime.DateTimeToLongDate("YYYYMMDD", dmdWork.StartCAddUpUpdDate);
            int endDay = TDateTime.DateTimeToLongDate("YYYYMMDD", dmdWork.AddUpDate);

            int st = 0;
            // 売上データ検索処理
            object objLedgerSalesSlipWorkList = null;
            //引数の1は売上商品区分の判断に使用している。請求で抽出する場合は消費税調整レコードは抽出しない
            if (printMode == (int)PrintMode.Slip)
            {
                st = this._ledgerSalesSlipWorkDB.SearchSlip(out objLedgerSalesSlipWorkList, dmdWork.EnterpriseCode, addUpSecCodeList, dmdWork.ClaimCode, dmdWork.ClaimCode, startDay, endDay, 1,ref sqlConnection);
            }
            else
            if (printMode == (int)PrintMode.Dtl)
            {
                st = this._ledgerSalesSlipWorkDB.SearchDtl(out objLedgerSalesSlipWorkList, dmdWork.EnterpriseCode, addUpSecCodeList, dmdWork.ClaimCode, dmdWork.ClaimCode, startDay, endDay, 1,ref sqlConnection);
            }

            ledgerSalesSlipWorkList = objLedgerSalesSlipWorkList as ArrayList;

            return st;
        }
        #endregion


        #region 請求金額マスタ取得
        /// <summary>
		/// 得意先請求金額マスタ取得処理
		/// </summary>
		/// <param name="custDmdPrcInfGetWorkList">得意先請求金額クラスワーク</param>
		/// <param name="parameter">検索パラメータ</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で得意先請求金額マスタを取得します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>		
		private int SearchCustDmdPrcInfGetWork(ref CustomSerializeArrayList custDmdPrcInfGetWorkList, CustDmdPrcInfSearchParameter parameter, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			SqlDataReader myReader = null;

            CustomSerializeArrayList al = new CustomSerializeArrayList();
            string sqlText = string.Empty;

			try
			{
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   DMD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,DMD.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "  ,DMD.CLAIMCODERF" + Environment.NewLine;
                sqlText += "  ,DMD.CLAIMNAMERF" + Environment.NewLine;
                sqlText += "  ,DMD.CLAIMNAME2RF" + Environment.NewLine;
                sqlText += "  ,DMD.CLAIMSNMRF" + Environment.NewLine;
                sqlText += "  ,DMD.RESULTSSECTCDRF" + Environment.NewLine;
                sqlText += "  ,DMD.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,DMD.CUSTOMERNAMERF" + Environment.NewLine;
                sqlText += "  ,DMD.CUSTOMERNAME2RF" + Environment.NewLine;
                sqlText += "  ,DMD.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "  ,DMD.ADDUPDATERF" + Environment.NewLine;
                sqlText += "  ,DMD.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "  ,DMD.LASTTIMEDEMANDRF" + Environment.NewLine;
                sqlText += "  ,DMD.ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                sqlText += "  ,DMD.ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                sqlText += "  ,DMD.THISTIMEDMDNRMLRF" + Environment.NewLine;
                sqlText += "  ,DMD.THISTIMETTLBLCDMDRF" + Environment.NewLine;
                sqlText += "  ,DMD.OFSTHISTIMESALESRF" + Environment.NewLine;
                sqlText += "  ,DMD.OFSTHISSALESTAXRF" + Environment.NewLine;
                sqlText += "  ,DMD.THISSALESPRICRGDSRF" + Environment.NewLine;
                sqlText += "  ,DMD.THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                sqlText += "  ,DMD.THISSALESPRICDISRF" + Environment.NewLine;
                sqlText += "  ,DMD.THISSALESPRCTAXDISRF" + Environment.NewLine;
                sqlText += "  ,DMD.TAXADJUSTRF" + Environment.NewLine;
                sqlText += "  ,DMD.BALANCEADJUSTRF" + Environment.NewLine;
                sqlText += "  ,DMD.AFCALDEMANDPRICERF" + Environment.NewLine;
                sqlText += "  ,DMD.CADDUPUPDEXECDATERF" + Environment.NewLine;
                sqlText += "  ,DMD.STARTCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "  ,DMD.LASTCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "  ,DMD.SALESSLIPCOUNTRF" + Environment.NewLine;
                sqlText += "  ,DMD.THISTIMESALESRF" + Environment.NewLine;
                sqlText += "  ,DMD.THISSALESTAXRF" + Environment.NewLine;
                sqlText += "  ,DMD.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += "FROM CUSTDMDPRCRF AS DMD" + Environment.NewLine;

				SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

				// Where文作成処理
				bool result = this.MakeWhereStringForSelectCustDmdPrc(sqlCommand, parameter);
				if (!result) return status;

				// OrderBy追加
				sqlCommand.CommandText += " ORDER BY ADDUPDATERF";

				// データ読込
				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					CustDmdPrcInfGetWork custDmdPrcInfGetWork = new CustDmdPrcInfGetWork();

					// SQLデータリーダー→得意先請求金額ワーク転記処理
					this.CopyToDataClassFromSelectData(ref custDmdPrcInfGetWork, myReader);

					al.Add(custDmdPrcInfGetWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			finally
			{
				if ((myReader != null) && (myReader.IsClosed == false)) myReader.Close();
			}

            custDmdPrcInfGetWorkList = al;
            
			return status;
        }

        /// <summary>
        /// Where文作成処理（得意先請求金額マスタ検索）
        /// </summary>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <param name="parameter">検索パラメータ</param>
        /// <returns>true:正常, false:エラー</returns>
        /// <br>Note       : 得意先請求金額マスタを検索するためのWhere文を作成します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>		
        private bool MakeWhereStringForSelectCustDmdPrc(SqlCommand sqlCommand, CustDmdPrcInfSearchParameter parameter)
        {
            string sqlString = " WHERE" + Environment.NewLine;

            // 企業コード
            sqlString += "DMD.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);

            // 論理削除区分
            sqlString += "AND DMD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            // 開始計上年月日
            if (parameter.StartAddUpYearMonth != DateTime.MinValue)
            {
                sqlString += "AND DMD.ADDUPYEARMONTHRF>=@FINDSTADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpDate = sqlCommand.Parameters.Add("@FINDSTADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(parameter.StartAddUpYearMonth);
            }

            // 開始計上年月日
            if (parameter.EndAddUpYearMonth != DateTime.MinValue)
            {
                sqlString += "AND DMD.ADDUPYEARMONTHRF<=@FINDEDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpDate = sqlCommand.Parameters.Add("@FINDEDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(parameter.EndAddUpYearMonth);
            }

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
                    sqlString += "AND DMD.ADDUPSECCODERF IN (" + sectionString + ") ";
                }

                sqlString += Environment.NewLine;
            }

            // 開始得意先コード
            if (parameter.StartCustomerCode != 0)
            {
                sqlString += "AND DMD.CLAIMCODERF>=@FINDSTCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(parameter.StartCustomerCode);
            }

            // 終了得意先コード
            if (parameter.EndCustomerCode != 0)
            {
                sqlString += "AND DMD.CLAIMCODERF<=@FINDEDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(parameter.EndCustomerCode);
            }

            //集計レコードのみ抽出
            sqlString += " AND DMD.CUSTOMERCODERF=0 " + Environment.NewLine;

            sqlCommand.CommandText += sqlString;

            return true;
        }

        /// <summary>
        /// Where文作成処理（得意先マスタ検索）
        /// </summary>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>true:正常, false:エラー</returns>
        /// <br>Note       : 得意先マスタを検索するためのWhere文を作成します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>		
        private bool MakeWhereStringForSelectCustomer(SqlCommand sqlCommand, string enterpriseCode, int customerCode)
        {
            StringBuilder resultSB = new StringBuilder(" WHERE");

            // 企業コード
            resultSB.Append(" CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            // 論理削除区分
            resultSB.Append(" AND CUSTOMERRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            // 得意先コード
            resultSB.Append(" AND CUSTOMERRF.CUSTOMERCODERF=@FINDCUSTOMERCODE");
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Char);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);


            sqlCommand.CommandText += resultSB.ToString();

            return true;
        }


        /// <summary>
        /// SQLデータリーダー→得意先請求金額ワーク転記処理
        /// </summary>
        /// <param name="custDmdPrcInfGetWork">得意先請求金額ワーク</param>
        /// <param name="myReader">SQLデータリーダー</param>
        /// <br>Note       : 得意先請求金額ワークに転記します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>		
        private void CopyToDataClassFromSelectData(ref CustDmdPrcInfGetWork custDmdPrcInfGetWork, SqlDataReader myReader)
        {
            custDmdPrcInfGetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            custDmdPrcInfGetWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            custDmdPrcInfGetWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            custDmdPrcInfGetWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            custDmdPrcInfGetWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            custDmdPrcInfGetWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            custDmdPrcInfGetWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF"));
            custDmdPrcInfGetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            custDmdPrcInfGetWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            custDmdPrcInfGetWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            custDmdPrcInfGetWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            custDmdPrcInfGetWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            custDmdPrcInfGetWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            custDmdPrcInfGetWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
            custDmdPrcInfGetWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
            custDmdPrcInfGetWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));
            custDmdPrcInfGetWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            custDmdPrcInfGetWork.ThisTimeTtlBlcDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCDMDRF"));
            custDmdPrcInfGetWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            custDmdPrcInfGetWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            custDmdPrcInfGetWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            custDmdPrcInfGetWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            custDmdPrcInfGetWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            custDmdPrcInfGetWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            custDmdPrcInfGetWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            custDmdPrcInfGetWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            custDmdPrcInfGetWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
            custDmdPrcInfGetWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            custDmdPrcInfGetWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            custDmdPrcInfGetWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            custDmdPrcInfGetWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            custDmdPrcInfGetWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            custDmdPrcInfGetWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            custDmdPrcInfGetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));

            // 締済フラグ
            custDmdPrcInfGetWork.CloseFlg = 1;
        }
        #endregion

        #region 入金データ取得
        /// <summary>
		/// 入金データ取得処理
		/// </summary>
        /// <param name="ledgerDepsitMainWorkList">入金データワーク</param>
        /// <param name="dmdWork">請求履歴データワーク</param>
        /// <param name="sqlConnection">SQLConnection</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で入金データを取得します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.05.08</br>
		private int SearchLedgerDepsitMainWork(ref ArrayList ledgerDepsitMainWorkList, CustDmdPrcInfGetWork dmdWork, ref SqlConnection sqlConnection)
		{
			if (this._ledgerDepsitMainWorkDB == null) this._ledgerDepsitMainWorkDB = new LedgerDepsitMainWorkDB();

			// 検索パラメータセット
			ArrayList addUpSecCodeList	= new ArrayList();
			addUpSecCodeList.Add(dmdWork.AddUpSecCode);							// 計上拠点コード
            int startDay = TDateTime.DateTimeToLongDate("YYYYMMDD", dmdWork.StartCAddUpUpdDate);
            int endDay = TDateTime.DateTimeToLongDate("YYYYMMDD", dmdWork.AddUpDate);
            

			// 入金データ検索処理
			object objLedgerDepsitMainWorkList;
            int st = this._ledgerDepsitMainWorkDB.Search(out objLedgerDepsitMainWorkList, dmdWork.EnterpriseCode, addUpSecCodeList, dmdWork.ClaimCode, dmdWork.ClaimCode, startDay, endDay, ref sqlConnection);

            ledgerDepsitMainWorkList = objLedgerDepsitMainWorkList as ArrayList;

			return st;
        }
        #endregion

	}
}
       