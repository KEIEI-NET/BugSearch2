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
	/// 支払情報取得リモート リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note		: 支払情報取得リモートメインクラスです。</br>
	/// <br>Programmer	: 22035 三橋 弘憲</br>
	/// <br>Date		: 2007.05.11</br>
    /// <br></br>
    /// <br>Update Note : 980081  山田 明友</br>
    /// <br>            : 2007.12.04 流通基幹対応</br>
    /// <br>Update Note : 30365　宮津銀次郎</br>
    /// <br>            : 09/01/28 ctDB_EOFでもlistにAddしてたのを修正</br>
    /// <br>            : 　　　　 AND文周りのバグを修正</br>
    /// <br>Update Note : FSI斎藤 和宏</br>
    /// <br>Date        : 2012/10/02 仕入先総括対応</br>
    /// <br>Update Note : FSI斎藤 和宏</br>
    /// <br>Date        : 2012/11/01 仕入先抽出条件不正対応</br>
    /// <br>            : 　　　　   消費税転嫁方式が反映されずに表示される問題対応</br>
    /// </remarks>
	[Serializable]
	public class SuplierPayInfGetDB : RemoteDB, ISuplierPayInfGetDB
	{
		# region Constractor
		/// <summary>
		/// 支払情報取得リモート リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払情報取得リモートの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.11</br>
		/// </remarks>
		public SuplierPayInfGetDB()
			: base("SFKON02514D", "Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetWork", "SUPLIERPAYRF")
		{
			// 仕入情報取得DBリモートオブジェクト
			this._ledgerStockSlipWorkDB = null;

			// 支払伝票情報取得DBリモートオブジェクト
			this._ledgerPaymentSlpWorkDB = null;

    	}
		# endregion

		#region Private Member

		/// <summary>仕入情報取得DBリモートオブジェクト</summary>
		private LedgerStockSlipWorkDB _ledgerStockSlipWorkDB;

		/// <summary>支払伝票情報取得DBリモートオブジェクト</summary>
		private LedgerPaymentSlpWorkDB _ledgerPaymentSlpWorkDB;

        private enum PrintMode
        {
            Slip = 0,
            Dtl = 1
        }
        #endregion

        # region メイン
        /// <summary>
        /// 支払金額情報取得処理(伝票)
        /// </summary>
        /// <param name="objSuplierPayInfGetWorkList">仕入先支払金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払情報リスト</param>
        /// <param name="objSuplierPayInfGetParameter">支払履歴情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先支払情報を取得します。
        ///                : 主に仕入先元帳にて使用します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchSlip(out object objSuplierPayInfGetWorkList, out object objLedgerStockSlipWorkList,
            out object objLedgerPaymentSlpWorkList, SuplierPayInfGetParameter objSuplierPayInfGetParameter)
        {
            return Search(out objSuplierPayInfGetWorkList, out objLedgerStockSlipWorkList, out objLedgerPaymentSlpWorkList, objSuplierPayInfGetParameter, (int)PrintMode.Slip);
        }

        /// <summary>
        /// 支払金額情報取得処理(明細)
        /// </summary>
        /// <param name="objSuplierPayInfGetWorkList">仕入先支払金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払情報リスト</param>
        /// <param name="objSuplierPayInfGetParameter">支払履歴情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先支払情報を取得します。
        ///                : 主に仕入先元帳にて使用します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchDtl(out object objSuplierPayInfGetWorkList, out object objLedgerStockSlipWorkList,
            out object objLedgerPaymentSlpWorkList, SuplierPayInfGetParameter objSuplierPayInfGetParameter)
        {
            return Search(out objSuplierPayInfGetWorkList, out objLedgerStockSlipWorkList, out objLedgerPaymentSlpWorkList, objSuplierPayInfGetParameter, (int)PrintMode.Dtl);
        }

        /// <summary>
		/// 支払履歴情報取得処理
		/// </summary>
		/// <param name="objSuplierPayInfGetWorkList">仕入先支払金額クラスワークリスト</param>
		/// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
		/// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplierPayInfGetParameter">支払情報取得抽出条件パラメータクラス</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
		///                : 主に仕入先元帳にて使用します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.11</br>
		private int Search(out object objSuplierPayInfGetWorkList, out object objLedgerStockSlipWorkList,
			out object objLedgerPaymentSlpWorkList, SuplierPayInfGetParameter objSuplierPayInfGetParameter, int printMode)
		{
			// 仕入先支払金額マスタ取得処理
            CustomSerializeArrayList suplierPayInfGetWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerStockSlipWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerPaymentSlpWorkList = new CustomSerializeArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SearchPrc(ref suplierPayInfGetWorkList, ref ledgerStockSlipWorkList, ref ledgerPaymentSlpWorkList, objSuplierPayInfGetParameter, printMode);

            if (suplierPayInfGetWorkList.Count != 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                //該当データ無し
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                ledgerStockSlipWorkList = new CustomSerializeArrayList();
                ledgerPaymentSlpWorkList = new CustomSerializeArrayList();
            }
            
            objSuplierPayInfGetWorkList = suplierPayInfGetWorkList;
            objLedgerStockSlipWorkList = ledgerStockSlipWorkList;
            objLedgerPaymentSlpWorkList = ledgerPaymentSlpWorkList;

            return status;
		}

		/// <summary>
		/// 支払情報取得処理
		/// </summary>
        /// <param name="csSuplierPayInfGetWorkList">仕入先支払金額クラスワーク</param>
        /// <param name="csLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="csLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="parameter">検索パラメータ</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.11</br>
        private int SearchPrc(ref CustomSerializeArrayList csSuplierPayInfGetWorkList, ref CustomSerializeArrayList csLedgerStockSlipWorkList, ref CustomSerializeArrayList csLedgerPaymentSlpWorkList, SuplierPayInfGetParameter parameter, int printMode)
		{
			SqlConnection sqlConnection = null;
			//SqlEncryptInfo sqlEncryptInfo = null;

			// 戻り値の初期化
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			int st;

            ArrayList ledgerStockSlipWorkList = new ArrayList();
            ArrayList ledgerPaymentSlpWorkList = new ArrayList();

			try
			{
				// ユーザーDB[IndexCode_UserDB]コネクション文字列を取得
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return (int)ConstantManagement.DB_Status.ctDB_ERROR;

				// コネクション接続
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
				//sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                // 仕入先支払金額マスタ取得処理
                st = this.SearchSuplierPayInfGetWork(ref csSuplierPayInfGetWorkList, parameter, sqlConnection);
                if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return st;
                }

                foreach (SuplierPayInfGetWork supWork in csSuplierPayInfGetWorkList)
                {
                    // 仕入データ取得処理
                    st = this.SearchLedgerStockSlipWork(ref ledgerStockSlipWorkList, supWork, ref sqlConnection, printMode, parameter.SumSuppEnable);
                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        return st;
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>> 09/01/28 G.Miyatsu ADD
                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        csLedgerStockSlipWorkList.Add(ledgerStockSlipWorkList);
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 支払伝票データ取得処理
                    st = this.SearchLedgerPaymentSlpWork(ref ledgerPaymentSlpWorkList, supWork, ref sqlConnection);
                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        return st;
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>> 09/01/28 G.Miyatsu ADD
                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        csLedgerPaymentSlpWorkList.Add(ledgerPaymentSlpWorkList);
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //csLedgerStockSlipWorkList.Add(ledgerStockSlipWorkList);
                    //csLedgerPaymentSlpWorkList.Add(ledgerPaymentSlpWorkList);
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

        # endregion

        #region 支払金額マスタ取得
        /// <summary>
		/// 仕入先支払金額マスタ取得処理
		/// </summary>
		/// <param name="suplierPayInfGetWorkList">仕入先支払金額クラスワーク</param>
		/// <param name="parameter">検索パラメータ</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で仕入先支払金額マスタを取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.11</br>		
        private int SearchSuplierPayInfGetWork(ref CustomSerializeArrayList suplierPayInfGetWorkList, SuplierPayInfGetParameter parameter, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			SqlDataReader myReader = null;

			CustomSerializeArrayList al = new CustomSerializeArrayList();
            string sqlText = string.Empty;
			try
			{
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   SUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,SUP.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "  ,SUP.PAYEECODERF" + Environment.NewLine;
                sqlText += "  ,SUP.PAYEENAMERF" + Environment.NewLine;
                sqlText += "  ,SUP.PAYEENAME2RF" + Environment.NewLine;
                sqlText += "  ,SUP.PAYEESNMRF" + Environment.NewLine;
                sqlText += "  ,SUP.RESULTSSECTCDRF" + Environment.NewLine;
                sqlText += "  ,SUP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,SUP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += "  ,SUP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,SUP.ADDUPDATERF" + Environment.NewLine;
                sqlText += "  ,SUP.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "  ,SUP.LASTTIMEPAYMENTRF" + Environment.NewLine;
                sqlText += "  ,SUP.STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                sqlText += "  ,SUP.STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISTIMEPAYNRMLRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISTIMETTLBLCPAYRF" + Environment.NewLine;
                sqlText += "  ,SUP.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                sqlText += "  ,SUP.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCKPRICRGDSRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCKPRICDISRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCPRCTAXDISRF" + Environment.NewLine;
                sqlText += "  ,SUP.TAXADJUSTRF" + Environment.NewLine;
                sqlText += "  ,SUP.BALANCEADJUSTRF" + Environment.NewLine;
                sqlText += "  ,SUP.STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                sqlText += "  ,SUP.CADDUPUPDEXECDATERF" + Environment.NewLine;
                sqlText += "  ,SUP.STARTCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "  ,SUP.LASTCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "  ,SUP.STOCKSLIPCOUNTRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISTIMESTOCKPRICERF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCPRCTAXRF" + Environment.NewLine;
                // --- ADD 2012/11/01 ---------->>>>>
                // 消費税転嫁率を取得
                sqlText += "  ,CASE" + Environment.NewLine;
                sqlText += "    WHEN SUPMAS.SUPPCTAXLAYREFCDRF = 0 THEN TAX.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += "    WHEN SUPMAS.SUPPCTAXLAYREFCDRF = 1 THEN SUPMAS.SUPPCTAXLAYCDRF" + Environment.NewLine;
                sqlText += "    ELSE 1 END AS SUPPCTAXLAYCDRF" + Environment.NewLine;
                // --- ADD 2012/11/01 ----------<<<<<
                sqlText += "FROM SUPLIERPAYRF AS SUP" + Environment.NewLine;
                // --- ADD 2012/11/01 ---------->>>>>
                // 消費税転嫁率を取得するテーブルをJOIN
                sqlText += " LEFT JOIN SUPPLIERRF AS SUPMAS ON" + Environment.NewLine;
                sqlText += "     (SUP.ENTERPRISECODERF = SUPMAS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND SUP.PAYEECODERF = SUPMAS.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  AND SUPMAS.LOGICALDELETECODERF = 0)" + Environment.NewLine;
                sqlText += " LEFT JOIN TAXRATESETRF AS TAX ON" + Environment.NewLine;
                sqlText += "     (SUP.ENTERPRISECODERF = TAX.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND TAX.LOGICALDELETECODERF = 0)" + Environment.NewLine;
                // --- ADD 2012/11/01 ----------<<<<<

				SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

				// Where文作成処理
				bool result = this.MakeWhereStringForSelectSuplierPay(sqlCommand, parameter);
				if (!result) return status;

				// OrderBy追加
				sqlCommand.CommandText += " ORDER BY SUP.ADDUPDATERF";

				// データ読込
				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					SuplierPayInfGetWork suplierPayInfGetWork = new SuplierPayInfGetWork();

					// SQLデータリーダー→仕入先支払金額ワーク転記処理
					this.CopyToDataClassFromSelectData(ref suplierPayInfGetWork, myReader);

					al.Add(suplierPayInfGetWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			finally
			{
				if ((myReader != null) && (myReader.IsClosed == false)) myReader.Close();
			}


			foreach (SuplierPayInfGetWork val in al)
			{
				suplierPayInfGetWorkList.Add(val);
			}

			return status;
        }

        /// <summary>
        /// Where文作成処理（仕入先支払金額マスタ検索）
        /// </summary>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <param name="parameter">検索パラメータ</param>
        /// <returns>true:正常, false:エラー</returns>
        /// <br>Note       : 仕入先支払金額マスタを検索するためのWhere文を作成します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.11</br>		
        /// <br></br>
        /// <br>Update Note: 980081  山田 明友</br>
        /// <br>           : 2007.12.04 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: FSI斎藤 和宏</br>
        /// <br>           : 2012/11/01 仕入先抽出条件不正対応</br>
        private bool MakeWhereStringForSelectSuplierPay(SqlCommand sqlCommand, SuplierPayInfGetParameter parameter)
        {
            string sqlString = " WHERE" + Environment.NewLine;

            // 企業コード
            sqlString += " SUP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);

            // 論理削除区分
            sqlString += " AND SUP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            // 開始計上年月
            if (parameter.StartAddUpYearMonth != DateTime.MinValue)
            {
                sqlString += "AND SUP.ADDUPYEARMONTHRF>=@FINDSTADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpDate = sqlCommand.Parameters.Add("@FINDSTADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(parameter.StartAddUpYearMonth);
            }

            // 開始計上年月
            if (parameter.EndAddUpYearMonth != DateTime.MinValue)
            {
                sqlString += "AND SUP.ADDUPYEARMONTHRF<=@FINDEDADDUPYEARMONTH" + Environment.NewLine;
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
                    sqlString += "AND SUP.ADDUPSECCODERF IN (" + sectionString + ") ";
                }
            }

            // 開始仕入先コード
            if (parameter.StartSupplierCd != 0)
            {
                // --- ADD 2012/11/01 ---------->>>>>
                //sqlString += " AND SUP.PAYEECODERF=@FINDSTSUPPLIERCD" + Environment.NewLine;
                sqlString += " AND SUP.PAYEECODERF>=@FINDSTSUPPLIERCD" + Environment.NewLine;
                // --- ADD 2012/11/01 ----------<<<<<
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@FINDSTSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(parameter.StartSupplierCd);
            }

            // 終了仕入先コード
            if (parameter.EndSupplierCd != 0)
            {
                // --- ADD 2012/11/01 ---------->>>>>
                //sqlString += " AND SUP.PAYEECODERF=@FINDEDSUPPLIERCD" + Environment.NewLine;
                sqlString += " AND SUP.PAYEECODERF<=@FINDEDSUPPLIERCD" + Environment.NewLine;
                // --- ADD 2012/11/01 ----------<<<<<
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@FINDEDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(parameter.EndSupplierCd);
            }
                
            sqlString += " AND SUP.SUPPLIERCDRF=0 " + Environment.NewLine;

            sqlCommand.CommandText += sqlString;

            return true;
        }

        /// <summary>
        /// SQLデータリーダー→仕入先支払金額ワーク転記処理
        /// </summary>
        /// <param name="suplierPayInfGetWork">仕入先支払金額ワーク</param>
        /// <param name="myReader">SQLデータリーダー</param>
        /// <br>Note       : 仕入先支払金額ワークに転記します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.11</br>		
        /// <br></br>
        /// <br>Update Note: 980081  山田 明友</br>
        /// <br>           : 2007.12.04 流通基幹対応</br>
        /// <br>Update Note: FSI斎藤 和宏</br>
        /// <br>           : 2012/11/01 消費税転嫁方式が反映されずに表示される問題対応</br>
        private void CopyToDataClassFromSelectData(ref SuplierPayInfGetWork suplierPayInfGetWork, SqlDataReader myReader)
        {
            suplierPayInfGetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            suplierPayInfGetWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            suplierPayInfGetWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            suplierPayInfGetWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            suplierPayInfGetWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            suplierPayInfGetWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            suplierPayInfGetWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF"));
            suplierPayInfGetWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            suplierPayInfGetWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            suplierPayInfGetWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            suplierPayInfGetWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            suplierPayInfGetWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            suplierPayInfGetWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            suplierPayInfGetWork.LastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
            suplierPayInfGetWork.StockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF"));
            suplierPayInfGetWork.StockTtl3TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL3TMBFBLPAYRF"));
            suplierPayInfGetWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            suplierPayInfGetWork.ThisTimeTtlBlcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCPAYRF"));
            suplierPayInfGetWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            suplierPayInfGetWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            suplierPayInfGetWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            suplierPayInfGetWork.ThisStcPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRGDSRF"));
            suplierPayInfGetWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            suplierPayInfGetWork.ThisStcPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXDISRF"));
            suplierPayInfGetWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            suplierPayInfGetWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            suplierPayInfGetWork.StockTotalPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPAYBALANCERF"));
            suplierPayInfGetWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            suplierPayInfGetWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            suplierPayInfGetWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            suplierPayInfGetWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            suplierPayInfGetWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            suplierPayInfGetWork.ThisStcPrcTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRF"));

            // 締済フラグ
            suplierPayInfGetWork.CloseFlg = 1;

            // --- ADD 2012/11/01 ---------->>>>>
            suplierPayInfGetWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            // --- ADD 2012/11/01 ----------<<<<<
        }

        #endregion

        #region 仕入データ取得
        /// <summary>
        /// 仕入データ取得処理
        /// </summary>
        /// <param name="ledgerStockSlipWorkList">仕入データワーク</param>
        /// <param name="supWork">支払履歴データ</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <param name="sumSuppEnable">仕入先総括利用可否 0:利用不可 1:利用可</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入データを取得します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.11</br>
        private int SearchLedgerStockSlipWork(ref ArrayList ledgerStockSlipWorkList, SuplierPayInfGetWork supWork, ref SqlConnection sqlConnection, int printMode, int sumSuppEnable)
        {
            if (this._ledgerStockSlipWorkDB == null) this._ledgerStockSlipWorkDB = new LedgerStockSlipWorkDB();

            // 検索パラメータセット
            ArrayList addUpSecCodeList = new ArrayList();
            addUpSecCodeList.Add(supWork.AddUpSecCode);							// 計上拠点コード
            int startDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.StartCAddUpUpdDate);
            int endDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.AddUpDate);

            int st = 0;
            // 仕入データ検索処理
            object objLedgerStockSlipWorkList = null;

            //引数の1は売上商品区分の判断に使用している。支払で抽出する場合は消費税調整レコードは抽出しない
            if (printMode == (int)PrintMode.Slip)
            {
                st = this._ledgerStockSlipWorkDB.SearchSlip(out objLedgerStockSlipWorkList, supWork.EnterpriseCode, addUpSecCodeList, supWork.PayeeCode, supWork.PayeeCode, startDay, endDay, 1, ref sqlConnection, sumSuppEnable);
            }
            else
                if (printMode == (int)PrintMode.Dtl)
                {
                    st = this._ledgerStockSlipWorkDB.SearchDtl(out objLedgerStockSlipWorkList, supWork.EnterpriseCode, addUpSecCodeList, supWork.PayeeCode, supWork.PayeeCode, startDay, endDay, 1, ref sqlConnection, sumSuppEnable);
                }

            ledgerStockSlipWorkList = objLedgerStockSlipWorkList as ArrayList;

            return st;
        }
        #endregion

        #region 支払データ取得
        /// <summary>
        /// 支払伝票データ取得処理
        /// </summary>
        /// <param name="ledgerPaymentSlpWorkList">支払データワーク</param>
        /// <param name="supWork">請求履歴データワーク</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で支払データを取得します。</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.05.08</br>
        private int SearchLedgerPaymentSlpWork(ref ArrayList ledgerPaymentSlpWorkList, SuplierPayInfGetWork supWork, ref SqlConnection sqlConnection)
        {
            if (this._ledgerPaymentSlpWorkDB == null) this._ledgerPaymentSlpWorkDB = new LedgerPaymentSlpWorkDB();

            // 検索パラメータセット
            ArrayList addUpSecCodeList = new ArrayList();
            addUpSecCodeList.Add(supWork.AddUpSecCode);							// 計上拠点コード
            int startDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.StartCAddUpUpdDate);
            int endDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.AddUpDate);


            // 支払データ検索処理
            object objLedgerPaymentSlpWorkList;
            int st = this._ledgerPaymentSlpWorkDB.Search(out objLedgerPaymentSlpWorkList, supWork.EnterpriseCode, addUpSecCodeList, supWork.PayeeCode, supWork.PayeeCode, startDay, endDay, ref sqlConnection);

            ledgerPaymentSlpWorkList = objLedgerPaymentSlpWorkList as ArrayList;

            return st;
        }
        #endregion
    }
}
