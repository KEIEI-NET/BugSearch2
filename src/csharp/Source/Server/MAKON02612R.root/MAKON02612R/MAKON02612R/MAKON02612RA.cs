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
	/// 買掛情報取得リモート リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note		: 買掛情報取得リモートメインクラスです。</br>
	/// <br>Programmer	: 22035 三橋 弘憲</br>
	/// <br>Date		: 2007.05.14</br>
    /// <br></br>
    /// <br>Update Note : 980081  山田 明友</br>
    /// <br>            : 2007.12.04 流通基幹対応</br>
    /// <br>Update Note : 30365　宮津銀次郎</br>
    /// <br>            : 09/01/28 ctDB_EOFでもlistにAddしてたのを修正</br>
    /// <br>            : 　　　　 AND文周りのバグを修正</br>
    /// <br>Update Note : FSI斎藤 和宏</br>
    /// <br>Date        : 2012/10/02 仕入先総括対応</br>
    /// </remarks>
	[Serializable]
	public class SuplAccInfGetDB : RemoteDB, ISuplAccInfGetDB
	{
		# region Constractor
		/// <summary>
		/// 買掛情報取得リモート リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 買掛情報取得リモートの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.14</br>
		/// </remarks>
		public SuplAccInfGetDB()
			: base("MAKON02614D", "Broadleaf.Application.Remoting.ParamData.SuplAccInfGetWork", "SUPLACCPAYRF")
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

        /// <summary>印刷タイプ</summary>
        private enum PrintMode
        {
            Slip = 0,
            Dtl = 1
        }

        #endregion

        #region メイン
        /// <summary>
        /// 買掛情報取得処理（明細）
        /// </summary>
        /// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplAccInfGetParameter">買掛情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
        ///                : 主に仕入先元帳にて使用します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.14</br>
        public int SearchSlip(out object objSuplAccInfGetWorkList, out object objLedgerStockSlipWorkList,
            out object objLedgerPaymentSlpWorkList, SuplAccInfGetParameter objSuplAccInfGetParameter)
        {
            return Search(out objSuplAccInfGetWorkList, out objLedgerStockSlipWorkList, out objLedgerPaymentSlpWorkList, objSuplAccInfGetParameter, (int)PrintMode.Slip);
        }

        /// <summary>
        /// 買掛情報取得処理（明細）
        /// </summary>
        /// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplAccInfGetParameter">買掛情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
        ///                : 主に仕入先元帳にて使用します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.14</br>
        public int SearchDtl(out object objSuplAccInfGetWorkList, out object objLedgerStockSlipWorkList,
            out object objLedgerPaymentSlpWorkList, SuplAccInfGetParameter objSuplAccInfGetParameter)
        {
            return Search(out objSuplAccInfGetWorkList, out objLedgerStockSlipWorkList, out objLedgerPaymentSlpWorkList, objSuplAccInfGetParameter, (int)PrintMode.Dtl);
        }

        /// <summary>
		/// 買掛情報取得処理[鑑＋明細]
		/// </summary>
		/// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
		/// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
		/// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
		/// <param name="objSuplAccInfGetParameter">買掛情報取得抽出条件パラメータクラス</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。
		///                : 主に仕入先元帳にて使用します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.14</br>
		private int Search(out object objSuplAccInfGetWorkList, out object objLedgerStockSlipWorkList,
			out object objLedgerPaymentSlpWorkList, SuplAccInfGetParameter objSuplAccInfGetParameter,int printMode)
		{
            // 得意先売掛金額マスタ取得処理
            CustomSerializeArrayList suplAccInfGetWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerStockSlipWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerPaymentSlpWorkList = new CustomSerializeArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SearchPrc(ref suplAccInfGetWorkList, ref ledgerStockSlipWorkList, ref ledgerPaymentSlpWorkList, objSuplAccInfGetParameter, printMode);

            if (suplAccInfGetWorkList.Count != 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                ledgerStockSlipWorkList = new CustomSerializeArrayList();
                ledgerPaymentSlpWorkList = new CustomSerializeArrayList();
            }

            objSuplAccInfGetWorkList = suplAccInfGetWorkList;
            objLedgerStockSlipWorkList = ledgerStockSlipWorkList;
            objLedgerPaymentSlpWorkList = ledgerPaymentSlpWorkList;

            return status;
		}

        /// <summary>
        /// 買掛情報取得処理
        /// </summary>
        /// <param name="csSuplAccInfGetWorkList">仕入先買掛金額クラスワーク</param>
        /// <param name="csLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="csLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="parameter">検索パラメータ</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.14</br>
        private int SearchPrc(ref CustomSerializeArrayList csSuplAccInfGetWorkList, ref CustomSerializeArrayList csLedgerStockSlipWorkList, ref CustomSerializeArrayList csLedgerPaymentSlpWorkList, SuplAccInfGetParameter parameter, int printMode)
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

                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);


                // 仕入先買掛金額マスタ取得処理
                st = this.SearchSuplAccInfGetWork(ref csSuplAccInfGetWorkList, parameter, ref sqlConnection);
                if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return st;
                }

                foreach (SuplAccInfGetWork supWork in csSuplAccInfGetWorkList)
                {

                    // 仕入データ取得処理
                    st = this.SearchLedgerStockSlipWork(ref ledgerStockSlipWorkList, supWork, ref sqlConnection, printMode);
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

        #region 買掛金額マスタ取得
		/// <summary>
		/// 仕入先買掛金額マスタ取得処理
		/// </summary>
		/// <param name="suplAccInfGetWorkList">仕入先買掛金額クラスワーク</param>
		/// <param name="parameter">検索パラメータ</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で仕入先買掛金額マスタを取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.14</br>		
        private int SearchSuplAccInfGetWork(ref CustomSerializeArrayList suplAccInfGetWorkList, SuplAccInfGetParameter parameter, ref SqlConnection sqlConnection)
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
                sqlText += "  ,SUP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,SUP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += "  ,SUP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,SUP.ADDUPDATERF" + Environment.NewLine;
                sqlText += "  ,SUP.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "  ,SUP.LASTTIMEACCPAYRF" + Environment.NewLine;
                sqlText += "  ,SUP.STCKTTL2TMBFBLACCPAYRF" + Environment.NewLine;
                sqlText += "  ,SUP.STCKTTL3TMBFBLACCPAYRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISTIMEPAYNRMLRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                sqlText += "  ,SUP.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                sqlText += "  ,SUP.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCKPRICRGDSRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCKPRICDISRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCPRCTAXDISRF" + Environment.NewLine;
                sqlText += "  ,SUP.TAXADJUSTRF" + Environment.NewLine;
                sqlText += "  ,SUP.BALANCEADJUSTRF" + Environment.NewLine;
                sqlText += "  ,SUP.STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                sqlText += "  ,SUP.MONTHADDUPEXPDATERF" + Environment.NewLine;
                sqlText += "  ,SUP.STMONCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "  ,SUP.LAMONCADDUPUPDDATERF" + Environment.NewLine;
                sqlText += "  ,SUP.STOCKSLIPCOUNTRF" + Environment.NewLine;
                sqlText += "  ,SUP.THISTIMESTOCKPRICERF" + Environment.NewLine;
                sqlText += "  ,SUP.THISSTCPRCTAXRF" + Environment.NewLine;
                sqlText += "FROM SUPLACCPAYRF AS SUP" + Environment.NewLine;

				SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

				// Where文作成処理
				bool result = this.MakeWhereStringForSelectSuplAcc(sqlCommand, parameter);
				if (!result) return status;

				// OrderBy追加
                sqlCommand.CommandText += " ORDER BY SUP.ADDUPDATERF";

				// データ読込
				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					SuplAccInfGetWork suplAccInfGetWork = new SuplAccInfGetWork();

					// SQLデータリーダー→仕入先買掛金額ワーク転記処理
					this.CopyToDataClassFromSelectData(ref suplAccInfGetWork, myReader);

					al.Add(suplAccInfGetWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			finally
			{
				if ((myReader != null) && (myReader.IsClosed == false)) myReader.Close();
			}


			foreach (SuplAccInfGetWork val in al)
			{
				suplAccInfGetWorkList.Add(val);
			}

			return status;
		}

        /// <summary>
        /// Where文作成処理（仕入先買掛金額マスタ検索）
        /// </summary>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <param name="parameter">検索パラメータ</param>
        /// <returns>true:正常, false:エラー</returns>
        /// <br>Note       : 仕入先買掛金額マスタを検索するためのWhere文を作成します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.14</br>		
        private bool MakeWhereStringForSelectSuplAcc(SqlCommand sqlCommand, SuplAccInfGetParameter parameter)
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

            // 開始計上年月日
            if (parameter.StartAddUpYearMonth != DateTime.MinValue)
            {
                sqlString += "AND SUP.ADDUPYEARMONTHRF>=@FINDSTADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpDate = sqlCommand.Parameters.Add("@FINDSTADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(parameter.StartAddUpYearMonth);
            }

            // 開始計上年月日
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
                sqlString += "AND SUP.PAYEECODERF>=@FINDSTSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@FINDSTSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(parameter.StartSupplierCd);
            }

            // 終了仕入先コード
            if (parameter.EndSupplierCd != 0)
            {
                sqlString += "AND SUP.PAYEECODERF<=@FINDEDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@FINDEDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(parameter.EndSupplierCd);
            }

            sqlString += " AND SUP.SUPPLIERCDRF=0 " + Environment.NewLine;

            sqlCommand.CommandText += sqlString;

            return true;
        }

        /// <summary>
        /// SQLデータリーダー→仕入先買掛金額ワーク転記処理
        /// </summary>
        /// <param name="suplAccInfGetWork">仕入先買掛金額ワーク</param>
        /// <param name="myReader">SQLデータリーダー</param>
        /// <br>Note       : 仕入先買掛金額ワークに転記します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.14</br>		
        private void CopyToDataClassFromSelectData(ref SuplAccInfGetWork suplAccInfGetWork, SqlDataReader myReader)
        {
            suplAccInfGetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            suplAccInfGetWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            suplAccInfGetWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            suplAccInfGetWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            suplAccInfGetWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            suplAccInfGetWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            suplAccInfGetWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            suplAccInfGetWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            suplAccInfGetWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            suplAccInfGetWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            suplAccInfGetWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            suplAccInfGetWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            suplAccInfGetWork.LastTimeAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCPAYRF"));
            suplAccInfGetWork.StckTtl2TmBfBlAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTL2TMBFBLACCPAYRF"));
            suplAccInfGetWork.StckTtl3TmBfBlAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTL3TMBFBLACCPAYRF"));
            suplAccInfGetWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            suplAccInfGetWork.ThisTimeTtlBlcAcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACPAYRF"));
            suplAccInfGetWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            suplAccInfGetWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            suplAccInfGetWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            suplAccInfGetWork.ThisStcPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRGDSRF"));
            suplAccInfGetWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            suplAccInfGetWork.ThisStcPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXDISRF"));
            suplAccInfGetWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            suplAccInfGetWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            suplAccInfGetWork.StckTtlAccPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTLACCPAYBALANCERF"));
            suplAccInfGetWork.MonthAddUpExpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHADDUPEXPDATERF"));
            suplAccInfGetWork.StMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STMONCADDUPUPDDATERF"));
            suplAccInfGetWork.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
            suplAccInfGetWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            suplAccInfGetWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            suplAccInfGetWork.ThisStcPrcTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRF"));

            // 締済フラグ
            suplAccInfGetWork.CloseFlg = 1;
        }

        #endregion

        #region 仕入データ取得
        /// <summary>
		/// 仕入データ取得処理
		/// </summary>
		/// <param name="ledgerStockSlipWorkList">仕入データワーク</param>
        /// <param name="supWork">買掛履歴データ</param>
		/// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">印刷タイプ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で仕入データを取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.14</br>
        private int SearchLedgerStockSlipWork(ref ArrayList ledgerStockSlipWorkList, SuplAccInfGetWork supWork,ref SqlConnection sqlConnection,int printMode)
		{
			if (this._ledgerStockSlipWorkDB == null) this._ledgerStockSlipWorkDB = new LedgerStockSlipWorkDB();

            // 検索パラメータセット
            ArrayList addUpSecCodeList = new ArrayList();
            addUpSecCodeList.Add(supWork.AddUpSecCode);							// 計上拠点コード
            int startDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.StMonCAddUpUpdDate);
            int endDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.AddUpDate);

            int st = 0;
            // 仕入データ検索処理
            object objLedgerStockSlipWorkList = null;

            if (printMode == (int)PrintMode.Slip)
            {
                st = this._ledgerStockSlipWorkDB.SearchSlip(out objLedgerStockSlipWorkList, supWork.EnterpriseCode, addUpSecCodeList, supWork.PayeeCode, supWork.PayeeCode, startDay, endDay, 0, ref sqlConnection);
            }
            else
                if (printMode == (int)PrintMode.Dtl)
                {
                    st = this._ledgerStockSlipWorkDB.SearchDtl(out objLedgerStockSlipWorkList, supWork.EnterpriseCode, addUpSecCodeList, supWork.PayeeCode, supWork.PayeeCode, startDay, endDay, 0, ref sqlConnection);
                }

            ledgerStockSlipWorkList = objLedgerStockSlipWorkList as ArrayList;

            return st;

		}
        #endregion

        #region 支払データ取得
        /// <summary>
		/// 支払伝票データ取得処理
		/// </summary>
		/// <param name="ledgerPaymentSlpWorkList">支払伝票データワーク</param>
        /// <param name="supWork">買掛履歴データ</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <br>Note       : 条件パラメータの内容で支払伝票データを取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.14</br>
        private int SearchLedgerPaymentSlpWork(ref ArrayList ledgerPaymentSlpWorkList,SuplAccInfGetWork supWork ,ref SqlConnection sqlConnection)
		{
			if (this._ledgerPaymentSlpWorkDB == null) this._ledgerPaymentSlpWorkDB = new LedgerPaymentSlpWorkDB();

            // 検索パラメータセット
            ArrayList addUpSecCodeList = new ArrayList();
            addUpSecCodeList.Add(supWork.AddUpSecCode);							// 計上拠点コード
            int startDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.StMonCAddUpUpdDate);
            int endDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.AddUpDate);


            // 入金データ検索処理
            object objLedgerPaymentSlpWorkList;
            int st = this._ledgerPaymentSlpWorkDB.Search(out objLedgerPaymentSlpWorkList, supWork.EnterpriseCode, addUpSecCodeList, supWork.PayeeCode, supWork.PayeeCode, startDay, endDay, ref sqlConnection);

            ledgerPaymentSlpWorkList = objLedgerPaymentSlpWorkList as ArrayList;

            return st;

		}

        #endregion

        // --- ADD 2012/10/02 ---------->>>>>
        #region 仕入先総括有効
        /// <summary>
        /// 買掛情報取得処理（明細）
        /// </summary>
        /// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplAccInfGetParameter">買掛情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。</br>
        /// <br>           : 仕入先総括オプション有効時にコールされます。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        public int SearchSlipSumSupp(out object objSuplAccInfGetWorkList, out object objLedgerStockSlipWorkList,
            out object objLedgerPaymentSlpWorkList, SuplAccInfGetParameter objSuplAccInfGetParameter)
        {
            return SearchSumSupp(out objSuplAccInfGetWorkList, out objLedgerStockSlipWorkList, out objLedgerPaymentSlpWorkList, objSuplAccInfGetParameter, (int)PrintMode.Slip);
        }

        /// <summary>
        /// 買掛情報取得処理（明細）
        /// </summary>
        /// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplAccInfGetParameter">買掛情報取得抽出条件パラメータクラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。</br>
        /// <br>           : 仕入先総括オプション有効時にコールされます。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        public int SearchDtlSumSupp(out object objSuplAccInfGetWorkList, out object objLedgerStockSlipWorkList,
            out object objLedgerPaymentSlpWorkList, SuplAccInfGetParameter objSuplAccInfGetParameter)
        {
            return SearchSumSupp(out objSuplAccInfGetWorkList, out objLedgerStockSlipWorkList, out objLedgerPaymentSlpWorkList, objSuplAccInfGetParameter, (int)PrintMode.Dtl);
        }

        /// <summary>
        /// 買掛情報取得処理[鑑＋明細]
        /// </summary>
        /// <param name="objSuplAccInfGetWorkList">仕入先買掛金額クラスワークリスト</param>
        /// <param name="objLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="objLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="objSuplAccInfGetParameter">買掛情報取得抽出条件パラメータクラス</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入先情報を取得します。</br>
        /// <br>           : 仕入先総括オプション有効時にコールされます。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        private int SearchSumSupp(out object objSuplAccInfGetWorkList, out object objLedgerStockSlipWorkList,
            out object objLedgerPaymentSlpWorkList, SuplAccInfGetParameter objSuplAccInfGetParameter, int printMode)
        {
            // 得意先売掛金額マスタ取得処理
            CustomSerializeArrayList suplAccInfGetWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerStockSlipWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList ledgerPaymentSlpWorkList = new CustomSerializeArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SearchPrcSumSupp(ref suplAccInfGetWorkList, ref ledgerStockSlipWorkList, ref ledgerPaymentSlpWorkList, objSuplAccInfGetParameter, printMode);

            if (suplAccInfGetWorkList.Count != 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                ledgerStockSlipWorkList = new CustomSerializeArrayList();
                ledgerPaymentSlpWorkList = new CustomSerializeArrayList();
            }

            objSuplAccInfGetWorkList = suplAccInfGetWorkList;
            objLedgerStockSlipWorkList = ledgerStockSlipWorkList;
            objLedgerPaymentSlpWorkList = ledgerPaymentSlpWorkList;

            return status;
        }

        /// <summary>
        /// 買掛情報取得処理
        /// </summary>
        /// <param name="csSuplAccInfGetWorkList">仕入先買掛金額クラスワーク</param>
        /// <param name="csLedgerStockSlipWorkList">仕入情報リスト</param>
        /// <param name="csLedgerPaymentSlpWorkList">支払伝票情報リスト</param>
        /// <param name="parameter">検索パラメータ</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>           : 仕入先総括オプション有効時にコールされます。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        private int SearchPrcSumSupp(ref CustomSerializeArrayList csSuplAccInfGetWorkList, ref CustomSerializeArrayList csLedgerStockSlipWorkList, ref CustomSerializeArrayList csLedgerPaymentSlpWorkList, SuplAccInfGetParameter parameter, int printMode)
        {
            SqlConnection sqlConnection = null;

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

                // 仕入先買掛金額マスタ取得処理
                st = this.SearchSuplAccInfGetWork(ref csSuplAccInfGetWorkList, parameter, ref sqlConnection);
                if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return st;
                }

                foreach (SuplAccInfGetWork supWork in csSuplAccInfGetWorkList)
                {

                    // 仕入データ取得処理
                    st = this.SearchLedgerStockSlipWorkSumSupp(ref ledgerStockSlipWorkList, supWork, ref sqlConnection, printMode);
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

        /// <summary>
        /// 仕入データ取得処理
        /// </summary>
        /// <param name="ledgerStockSlipWorkList">仕入データワーク</param>
        /// <param name="supWork">買掛履歴データ</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <br>Note       : 条件パラメータの内容で仕入データを取得します。</br>
        /// <br>           : 仕入先総括オプション有効時にコールされます。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        private int SearchLedgerStockSlipWorkSumSupp(ref ArrayList ledgerStockSlipWorkList, SuplAccInfGetWork supWork, ref SqlConnection sqlConnection, int printMode)
        {
            if (this._ledgerStockSlipWorkDB == null) this._ledgerStockSlipWorkDB = new LedgerStockSlipWorkDB();

            // 検索パラメータセット
            ArrayList addUpSecCodeList = new ArrayList();
            addUpSecCodeList.Add(supWork.AddUpSecCode);							// 計上拠点コード
            int startDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.StMonCAddUpUpdDate);
            int endDay = TDateTime.DateTimeToLongDate("YYYYMMDD", supWork.AddUpDate);

            int st = 0;
            // 仕入データ検索処理
            object objLedgerStockSlipWorkList = null;

            if (printMode == (int)PrintMode.Slip)
            {
                st = this._ledgerStockSlipWorkDB.SearchSlipSumSupp(out objLedgerStockSlipWorkList, supWork.EnterpriseCode, addUpSecCodeList, supWork.PayeeCode, supWork.PayeeCode, startDay, endDay, 0, ref sqlConnection);
            }
            else
                if (printMode == (int)PrintMode.Dtl)
                {
                    st = this._ledgerStockSlipWorkDB.SearchDtlSumSupp(out objLedgerStockSlipWorkList, supWork.EnterpriseCode, addUpSecCodeList, supWork.PayeeCode, supWork.PayeeCode, startDay, endDay, 0, ref sqlConnection);
                }

            ledgerStockSlipWorkList = objLedgerStockSlipWorkList as ArrayList;

            return st;

        }
        #endregion 仕入先総括有効
        // --- ADD 2012/10/02 ----------<<<<<
    }
}
