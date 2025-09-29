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
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先元帳仕入データ抽出DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先元帳仕入データ抽出の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.05.08</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>           : 2007.12.04 流通基幹対応</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>           : 2008.03.13 買掛モードの際に消費税調整・残高調整も戻すよう修正</br>
    /// <br>Update Note: 30290</br>
    /// <br>           : 2008.04.24 得意先・仕入先切り分け</br>
    /// <br>Update Note: 22008 長内 数馬</br>
    /// <br>           : 2008.10.07 PM.NS用に修正</br>
    /// <br>Update Note: FSI斎藤 和宏</br>
    /// <br>           : 2012/10/02 仕入先総括対応</br>
    /// <br>UpdateNote : 2015/10/21 田思春</br>
    /// <br>管理番号   : 11170187-00</br>
    /// <br>           : Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応</br>
    /// <br>UpdateNote : 2015/12/10 田思春</br>
    /// <br>管理番号   : 11170204-00</br>
    /// <br>           : Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応</br>
    /// <br>UpdateNote : 2015/12/17 田思春</br>
    /// <br>管理番号   : 11170204-00</br>
    /// <br>           : Redmine#47545 システムテスト障害一覧_#47545の指摘NO.2 抽出条件を支払先から仕入先に変更した後、既存の変数名が変更しない対応</br>
    /// </remarks>
    [Serializable]
    public class LedgerStockSlipWorkDB : RemoteDB
    {
        /// <summary>
        /// 仕入先元帳仕入データ抽出DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        /// </remarks>
        public LedgerStockSlipWorkDB()
            :
        base("MAKON02411D", "Broadleaf.Application.Remoting.ParamData.LedgerStockSlipWork", "STOCKSLIPHISTRF") //基底クラスのコンストラクタ
        {
        }

        private enum PrintMode
        {
            Slip = 0,
            Dtl = 1
        }

        #region 仕入取得処理

        #region メイン

        // --- ADD 2012/10/02 ---------->>>>>
        /// <summary>
        /// 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="ledgerStockSlipWork">検索結果（売上）</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="goodsCdMode">商品区分 1:支払</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="sumSuppEnable">仕入先総括利用可否 0:利用不可 1:利用可</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br>UpdateNote : 仕入先総括対応</br>
        /// <br>Programer  : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        public int SearchSlip(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection, int sumSuppEnable)
        {
            return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Slip, sumSuppEnable);
        }
        // --- ADD 2012/10/02 ----------<<<<<

        /// <summary>
        /// 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="ledgerStockSlipWork">検索結果（売上）</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="goodsCdMode">商品区分 1:支払</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchSlip(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection)
        {
            // --- ADD 2012/10/02 ---------->>>>>
            //return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Slip);
            return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Slip, 0);
            // --- ADD 2012/10/02 ----------<<<<<
        }

        // --- ADD 2012/10/02 ---------->>>>>
        /// <summary>
        /// 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="ledgerStockSlipWork">検索結果（売上）</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="goodsCdMode">商品区分 1:支払</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="sumSuppEnable">仕入先総括利用可否 0:利用不可 1:利用可</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入先元帳の仕入データ抽出LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br>UpdateNote : 仕入先総括対応</br>
        /// <br>Programer  : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        public int SearchDtl(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection, int sumSuppEnable)
        {
            return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Dtl, sumSuppEnable);
        }
        // --- ADD 2012/10/02 ----------<<<<<

        /// <summary>
        /// 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="ledgerStockSlipWork">検索結果（売上）</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="goodsCdMode">商品区分 1:支払</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入先元帳の仕入データ抽出LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        public int SearchDtl(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode ,ref SqlConnection sqlConnection)
        {
            // --- ADD 2012/10/02 ----------<<<<<
            //return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Dtl;
            return Search(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, (int)PrintMode.Dtl, 0);
            // --- ADD 2012/10/02 ----------<<<<<
        }

        /// <summary>
        /// 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="ledgerStockSlipWork">検索結果（売上）</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="goodsCdMode">商品区分 1:支払</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <param name="sumSuppEnable">仕入先総括利用可否 0:利用不可 1:利用可</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        private int Search(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode, ref SqlConnection sqlConnection, int printMode, int sumSuppEnable)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ledgerStockSlipWork = null;

            try
            {
                if (printMode == (int)PrintMode.Slip)
                {
                    status = SearchSlipProc(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, printMode, sumSuppEnable);
                }
                else
                {
                    status = SearchDtlProc(out ledgerStockSlipWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode, ref sqlConnection, printMode, sumSuppEnable);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerStockSlipWorkDB.Search Exception=" + ex.Message);
                ledgerStockSlipWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion

        #region 伝票タイプ
        /// <summary>
        /// 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します
        /// </summary>
        /// <param name="ledgerStockSlipWork">検索結果（売上）</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="goodsCdMode">商品区分モード 0:通常 1:支払(4,5,10が除外) 2:買掛</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <param name="sumSuppEnable">仕入先総括利用可否 0:利用不可 1:利用可</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br></br>
        /// <br>Update Note: 消費税転嫁方式が反映されずに表示される問題対応</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/11/01 </br>
        private int SearchSlipProc(out object ledgerStockSlipWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode, ref SqlConnection sqlConnection, int printMode, int sumSuppEnable)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ledgerStockSlipWork = null;
            ArrayList al = new ArrayList();   //抽出結果

            string sqlText = string.Empty;

            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "  ,SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += "  ,SLIP.DEBITNLNKSUPPSLIPNORF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.INPUTDAYRF" + Environment.NewLine;
                sqlText += "  ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKDATERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKINPUTCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKINPUTNAMERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;
                sqlText += "  ,SLIP.PAYEECODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.PAYEESNMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;
                sqlText += "  ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
                sqlText += "  ,SLIP.UOEREMARK1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.UOEREMARK2RF" + Environment.NewLine;
                sqlText += "FROM STOCKSLIPHISTRF AS SLIP" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    // --- ADD 2012/10/02 ---------->>>>>
                    if (sumSuppEnable == 1)
                    {
                        // Where文の作成
                        bool result = this.MakeWhereStringSumSupp(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode);
                        if (!result) return status;
                    }
                    else
                    {
                        // Where文の作成
                        bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode);
                        if (!result) return status;
                    }
                    // --- ADD 2012/10/02 ----------<<<<<

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            this.SetListFromSQLReader(ref status, ref al, myReader, printMode, sumSuppEnable);
                        }
                        finally
                        {
                            if (myReader != null) myReader.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerStockSlipWorkDB.SearchSlipProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            ledgerStockSlipWork = al;

            return status;
        }

        /// <summary>
        /// SQLデータリーダー→仕入先元帳仕入データワーク
        /// </summary>
        /// <param name="_ledgerStockSlipWork">仕入先元帳仕入データワーク</param>
        /// <param name="myReader">SQLデータリーダー</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQLデータリーダーに保持している内容を仕入先元帳仕入データワークにコピーします。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>		
        /// <br></br>
        /// <br>Update Note: 消費税転嫁方式が反映されずに表示される問題対応</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/11/01 </br>
        private void CopyToDataClassFromSelectData(ref LedgerStockSlipWork _ledgerStockSlipWork, SqlDataReader myReader)
        {
            #region 仕入先元帳仕入データワークへ格納
            _ledgerStockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerStockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerStockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerStockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerStockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerStockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            _ledgerStockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            _ledgerStockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            _ledgerStockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));          
            _ledgerStockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            _ledgerStockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            _ledgerStockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            _ledgerStockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            _ledgerStockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            _ledgerStockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            _ledgerStockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            _ledgerStockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            _ledgerStockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            _ledgerStockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            _ledgerStockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            _ledgerStockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerStockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerStockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerStockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerStockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            _ledgerStockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            _ledgerStockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            _ledgerStockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerStockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            _ledgerStockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            _ledgerStockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerStockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            #endregion

        }
        #endregion

        #region 明細タイプ

        /// <summary>
        /// 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します
        /// </summary>
        /// <param name="ledgerStockDetailWork">検索結果（仕入明細）</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="goodsCdMode">商品区分モード 0:通常 1:支払(4,5,10が除外) 2:買掛</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <param name="sumSuppEnable">仕入先総括利用可否 0:利用不可 1:利用可</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入先元帳仕入データ抽出LISTを全て戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: 消費税転嫁方式が反映されずに表示される問題対応</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/11/01 </br>
        private int SearchDtlProc(out object ledgerStockDetailWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, int goodsCdMode, ref SqlConnection sqlConnection, int printMode, int sumSuppEnable)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ledgerStockDetailWork = null;
            ArrayList al = new ArrayList();     //抽出結果

            string sqlText = string.Empty;

            try
            {

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "  ,SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += "  ,SLIP.DEBITNLNKSUPPSLIPNORF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.INPUTDAYRF" + Environment.NewLine;
                sqlText += "  ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKDATERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKINPUTCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKINPUTNAMERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;
                sqlText += "  ,SLIP.PAYEECODERF" + Environment.NewLine;
                sqlText += "  ,SLIP.PAYEESNMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
                sqlText += "  ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;
                sqlText += "  ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
                sqlText += "  ,SLIP.UOEREMARK1RF" + Environment.NewLine;
                sqlText += "  ,SLIP.UOEREMARK2RF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKROWNORF" + Environment.NewLine;
                sqlText += "  ,DETAIL.COMMONSEQNORF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.GOODSNORF" + Environment.NewLine;
                sqlText += "  ,DETAIL.GOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,DETAIL.GOODSNAMEKANARF" + Environment.NewLine;
                sqlText += "  ,DETAIL.SALESCUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,DETAIL.SALESCUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKCOUNTRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKUNITPRICEFLRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKPRICETAXEXCRF" + Environment.NewLine;
                sqlText += "  ,DETAIL.STOCKPRICECONSTAXRF AS DTL_STOCKPRICECONSTAXRF" + Environment.NewLine;
                sqlText += "FROM STOCKSLIPHISTRF SLIP" + Environment.NewLine;
                sqlText += "LEFT JOIN STOCKSLHISTDTLRF AS DETAIL ON (SLIP.ENTERPRISECODERF=DETAIL.ENTERPRISECODERF AND SLIP.SUPPLIERFORMALRF=DETAIL.SUPPLIERFORMALRF AND SLIP.SUPPLIERSLIPNORF=DETAIL.SUPPLIERSLIPNORF ) " + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    if (sumSuppEnable == 1)
                    {
                        // Where文の作成
                        bool result = this.MakeWhereStringSumSupp(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode);
                        if (!result) return status;
                    }
                    else
                    {
                        // Where文の作成
                        bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, goodsCdMode);
                        if (!result) return status;
                    }
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            this.SetListFromSQLReader(ref status, ref al, myReader, (int)PrintMode.Dtl, sumSuppEnable);
                        }
                        finally
                        {
                            if (myReader != null) myReader.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerStockSlipWorkDB.SearchDtlProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            ledgerStockDetailWork = al;

            return status;
        }

        /// <summary>
        /// SQLデータリーダー→仕入先元帳仕入データワーク
        /// </summary>
        /// <param name="_ledgerStockDetailWork">仕入先元帳仕入データワーク</param>
        /// <param name="myReader">SQLデータリーダー</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQLデータリーダーに保持している内容を仕入先元帳仕入データワークにコピーします。</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        private void CopyToDataClassFromSelectDataDetail(ref LedgerStockDetailWork _ledgerStockDetailWork, SqlDataReader myReader)
        {
            #region 仕入先元帳仕入データワークへ格納
            _ledgerStockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerStockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerStockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerStockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerStockDetailWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerStockDetailWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            _ledgerStockDetailWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            _ledgerStockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            _ledgerStockDetailWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            _ledgerStockDetailWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            _ledgerStockDetailWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            _ledgerStockDetailWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            _ledgerStockDetailWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            _ledgerStockDetailWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            _ledgerStockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            _ledgerStockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            _ledgerStockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            _ledgerStockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            _ledgerStockDetailWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            _ledgerStockDetailWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            _ledgerStockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerStockDetailWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerStockDetailWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerStockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerStockDetailWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            _ledgerStockDetailWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            _ledgerStockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            _ledgerStockDetailWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerStockDetailWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            _ledgerStockDetailWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            _ledgerStockDetailWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerStockDetailWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            _ledgerStockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            _ledgerStockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            _ledgerStockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
            _ledgerStockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            _ledgerStockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            _ledgerStockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            _ledgerStockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
            _ledgerStockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
            _ledgerStockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            _ledgerStockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            _ledgerStockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            _ledgerStockDetailWork.Dtl_StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTL_STOCKPRICECONSTAXRF"));
            #endregion

            // --- ADD 2012/11/01 ---------->>>>>
            //_ledgerStockDetailWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            // --- ADD 2012/11/01 ----------<<<<<
        }
        #endregion

        /// <summary>
        /// 仕入先元帳仕入データリスト格納処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="al">仕入先元帳仕入データリスト</param>
        /// <param name="myReader">SQLDataReader</param>
        /// <param name="printMode">印刷タイプ</param>
        /// <param name="sumSuppEnable">仕入先総括利用可否 0:利用不可 1:利用可</param>
        /// <br>Note       : SQLDataReaderの情報を仕入先元帳仕入データリストにセットします。</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        private void SetListFromSQLReader(ref int status, ref ArrayList al, SqlDataReader myReader, int printMode, int sumSuppEnable)
        {
            if (al == null)
            {
                al = new ArrayList();
            }

            LedgerStockSlipWork _ledgerStockSlipWork;
            LedgerStockDetailWork _ledgerStockDetailWork;

            while (myReader.Read())
            {
                _ledgerStockSlipWork = new LedgerStockSlipWork();
                _ledgerStockDetailWork = new LedgerStockDetailWork();

                //SQLデータリーダー→仕入先元帳仕入データワーク
                if (printMode == (int)PrintMode.Slip)
                {
                    // --- ADD 2012/10/02 ---------->>>>>
                    if (sumSuppEnable == 1)
                    {
                        this.CopyToDataClassFromSelectDataSumSupp(ref _ledgerStockSlipWork, myReader);
                    }
                    else
                    {
                        this.CopyToDataClassFromSelectData(ref _ledgerStockSlipWork, myReader);
                    }
                    // --- ADD 2012/10/02 ----------<<<<<
                    al.Add(_ledgerStockSlipWork);
                }
                else
                if (printMode == (int)PrintMode.Dtl)
                {
                    // --- ADD 2012/10/02 ---------->>>>>
                    if (sumSuppEnable == 1)
                    {
                        this.CopyToDataClassFromSelectDataDetailSumSupp(ref _ledgerStockDetailWork, myReader);
                    }
                    else
                    {
                    this.CopyToDataClassFromSelectDataDetail(ref _ledgerStockDetailWork, myReader);
                    }
                    // --- ADD 2012/10/02 ----------<<<<<
                    al.Add(_ledgerStockDetailWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SQLConnection</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="goodsCdMode">商品区分モード 0:通常 1:支払(4,5,10が除外) 2:買掛</param>
        /// <returns>Where条件文字列</returns>
        /// <br>UpdateNote : 2015/10/21 田思春</br>
        /// <br>管理番号   : 11170187-00</br>
        /// <br>           : Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応</br> 
        private bool MakeWhereString(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int startSupplierCd, int endSupplierCd, 
            int startAddUpDate, int endAddUpDate, int goodsCdMode)
        {
            #region WHERE文作成
            sqlCommand.CommandText += " WHERE";

            // 企業コード
            sqlCommand.CommandText += " SLIP.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            // 論理削除区分
            sqlCommand.CommandText += " AND SLIP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //支払先コード
            if (startSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND SLIP.PAYEECODERF>=@STPAYEECODE";
                SqlParameter paraStPayeeCode = sqlCommand.Parameters.Add("@STPAYEECODE", SqlDbType.Int);
                paraStPayeeCode.Value = SqlDataMediator.SqlSetInt32(startSupplierCd);
            }
            if (endSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND SLIP.PAYEECODERF<=@EDPAYEECODE";
                SqlParameter paraEdPayeeCode = sqlCommand.Parameters.Add("@EDPAYEECODE", SqlDbType.Int);
                paraEdPayeeCode.Value = SqlDataMediator.SqlSetInt32(endSupplierCd);
            }

            // 仕入計上日付
            if (startAddUpDate <= endAddUpDate)
            {
                if (startAddUpDate == endAddUpDate)
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKADDUPADATERF=@FINDSTOCKADDUPADATE";
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATE", SqlDbType.Int);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                }
                else
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKADDUPADATERF>=@FINDSTARTSTOCKADDUPADATE AND SLIP.STOCKADDUPADATERF<=@FINDENDSTOCKADDUPADATE";
                    SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTSTOCKADDUPADATE", SqlDbType.Int);
                    paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                    SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDSTOCKADDUPADATE", SqlDbType.Int);
                    paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endAddUpDate);
                }
            }
            else
            {
                return false;
            }

            // ---------- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ---------->>>>>
            //// 仕入計上拠点
            //StringBuilder whereSectionCode = new StringBuilder();
            //if (addUpSecCodeList.Count > 0)
            //{
            //    if (addUpSecCodeList.Count == 1)
            //    {
            //        sqlCommand.CommandText += " AND SLIP.STOCKADDUPSECTIONCDRF='" + addUpSecCodeList[0] + "'";
            //    }
            //    else
            //    {
            //        sqlCommand.CommandText += " AND SLIP.STOCKADDUPSECTIONCDRF IN (";

            //        string str = "";
            //        for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
            //        {
            //            if (ix != 0)
            //            {
            //                str += ",";
            //            }
            //            str += "'" + addUpSecCodeList[ix] + "'";
            //        }
            //        sqlCommand.CommandText += str + ")";
            //    }
            //}
            // ---------- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ----------<<<<<

            //仕入商品区分のチェック
            if (goodsCdMode == 1)
            {
                sqlCommand.CommandText += " AND SLIP.STOCKGOODSCDRF!=4 AND SLIP.STOCKGOODSCDRF!=5 AND SLIP.STOCKGOODSCDRF!=10";
            }
            else if (goodsCdMode == 2)
            {
            }

            #endregion
            return true;
        }

        // --- ADD 2012/10/02 ---------->>>>>
        #region 仕入先総括有効時
        /// <summary>
        /// SQLデータリーダー→仕入先元帳仕入データワーク
        /// </summary>
        /// <param name="_ledgerStockSlipWork">仕入先元帳仕入データワーク</param>
        /// <param name="myReader">SQLデータリーダー</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQLデータリーダーに保持している内容を仕入先元帳仕入データワークにコピーします。</br>
        /// <br>           : 仕入先総括オプション有効時にコールされます。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>	
        /// <br>UpdateNote : 2015/12/10 田思春</br>
        /// <br>管理番号   : 11170204-00</br>
        /// <br>           : Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応</br>
        private void CopyToDataClassFromSelectDataSumSupp(ref LedgerStockSlipWork _ledgerStockSlipWork, SqlDataReader myReader)
        {
            #region 仕入先元帳仕入データワークへ格納
            _ledgerStockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerStockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerStockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerStockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerStockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerStockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            _ledgerStockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            _ledgerStockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            _ledgerStockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));

            // 仕入総括有効時は計上拠点に対して仕入拠点コードを入れる
            _ledgerStockSlipWork.StockAddUpSectionCd = _ledgerStockSlipWork.StockSectionCd;

            _ledgerStockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            _ledgerStockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            _ledgerStockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            _ledgerStockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            _ledgerStockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            _ledgerStockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            _ledgerStockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            _ledgerStockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            // ------- DEL 2015/12/10 田思春 For Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応 ------->>>>>
            //_ledgerStockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            //_ledgerStockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            // ------- DEL 2015/12/10 田思春 For Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応 -------<<<<<
            _ledgerStockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerStockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerStockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerStockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerStockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            _ledgerStockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            _ledgerStockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            _ledgerStockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerStockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            _ledgerStockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            _ledgerStockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerStockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            // ------- ADD 2015/12/10 田思春 For Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応 ------->>>>>
            _ledgerStockSlipWork.PayeeCode = _ledgerStockSlipWork.SupplierCd;
            _ledgerStockSlipWork.PayeeSnm = _ledgerStockSlipWork.SupplierSnm;
            // ------- ADD 2015/12/10 田思春 For Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応 -------<<<<<
			#endregion
        }

        /// <summary>
        /// SQLデータリーダー→仕入先元帳仕入データワーク
        /// </summary>
        /// <param name="_ledgerStockDetailWork">仕入先元帳仕入データワーク</param>
        /// <param name="myReader">SQLデータリーダー</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQLデータリーダーに保持している内容を仕入先元帳仕入データワークにコピーします。</br>
        /// <br>           : 仕入先総括オプション有効時にコールされます。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        /// <br>UpdateNote : 2015/12/10 田思春</br>
        /// <br>管理番号   : 11170204-00</br>
        /// <br>           : Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応</br>
        private void CopyToDataClassFromSelectDataDetailSumSupp(ref LedgerStockDetailWork _ledgerStockDetailWork, SqlDataReader myReader)
        {
            #region 仕入先元帳仕入データワークへ格納
            _ledgerStockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerStockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerStockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerStockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _ledgerStockDetailWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerStockDetailWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            _ledgerStockDetailWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            _ledgerStockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            _ledgerStockDetailWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));

            // 仕入総括有効時は計上拠点に対して仕入拠点コードを入れる
            _ledgerStockDetailWork.StockAddUpSectionCd = _ledgerStockDetailWork.StockSectionCd;

            _ledgerStockDetailWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            _ledgerStockDetailWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            _ledgerStockDetailWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            _ledgerStockDetailWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            _ledgerStockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            _ledgerStockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            _ledgerStockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            _ledgerStockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            // ------- DEL 2015/12/10 田思春 For Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応 ------->>>>>
            //_ledgerStockDetailWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            //_ledgerStockDetailWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            // ------- DEL 2015/12/10 田思春 For Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応 -------<<<<<
            _ledgerStockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerStockDetailWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerStockDetailWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerStockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerStockDetailWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            _ledgerStockDetailWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            _ledgerStockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            _ledgerStockDetailWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            _ledgerStockDetailWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            _ledgerStockDetailWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            _ledgerStockDetailWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            _ledgerStockDetailWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            _ledgerStockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            _ledgerStockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            _ledgerStockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
            _ledgerStockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            _ledgerStockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            _ledgerStockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            _ledgerStockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
            _ledgerStockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
            _ledgerStockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            _ledgerStockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            _ledgerStockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            _ledgerStockDetailWork.Dtl_StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTL_STOCKPRICECONSTAXRF"));
            // ------- ADD 2015/12/10 田思春 For Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応 ------->>>>>
            _ledgerStockDetailWork.PayeeCode = _ledgerStockDetailWork.SupplierCd;
            _ledgerStockDetailWork.PayeeSnm = _ledgerStockDetailWork.SupplierSnm;
            // ------- ADD 2015/12/10 田思春 For Redmine#47545 障害１ 仕入総括オプション有効時、仕入先元帳の明細部(仕入先親)に親子両方の明細が印字されるの障害対応 -------<<<<<
			#endregion
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SQLConnection</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="goodsCdMode">商品区分モード 0:通常 1:支払(4,5,10が除外) 2:買掛</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : 検索条件文字列生成＋条件値設定処理。</br>
        /// <br>           : 仕入先総括オプション有効時にコールされます。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/10/02</br>
        /// <br>UpdateNote : 2015/12/17 田思春</br>
        /// <br>管理番号   : 11170204-00</br>
        /// <br>           : Redmine#47545 システムテスト障害一覧_#47545の指摘NO.2 抽出条件を支払先から仕入先に変更した後、既存の変数名が変更しない対応</br>
        private bool MakeWhereStringSumSupp(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int startSupplierCd, int endSupplierCd,
            int startAddUpDate, int endAddUpDate, int goodsCdMode)
        {
            #region WHERE文作成
            sqlCommand.CommandText += " WHERE";

            // 企業コード
            sqlCommand.CommandText += " SLIP.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            // 論理削除区分
            sqlCommand.CommandText += " AND SLIP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            // ------- DEL 2015/12/17 田思春 For Redmine#47545 システムテスト障害一覧_#47545の指摘NO.2 抽出条件を支払先から仕入先に変更した後、既存の変数名が変更しない対応 ------->>>>>
            ////支払先コード
            //if (startSupplierCd != 0)
            //{
            //    sqlCommand.CommandText += " AND SLIP.PAYEECODERF>=@STPAYEECODE";
            //    SqlParameter paraStPayeeCode = sqlCommand.Parameters.Add("@STPAYEECODE", SqlDbType.Int);
            //    paraStPayeeCode.Value = SqlDataMediator.SqlSetInt32(startSupplierCd);
            //}
            //if (endSupplierCd != 0)
            //{
            //    sqlCommand.CommandText += " AND SLIP.PAYEECODERF<=@EDPAYEECODE";
            //    SqlParameter paraEdPayeeCode = sqlCommand.Parameters.Add("@EDPAYEECODE", SqlDbType.Int);
            //    paraEdPayeeCode.Value = SqlDataMediator.SqlSetInt32(endSupplierCd);
            //}
            // ------- DEL 2015/12/17 田思春 For Redmine#47545 システムテスト障害一覧_#47545の指摘NO.2 抽出条件を支払先から仕入先に変更した後、既存の変数名が変更しない対応 -------<<<<<

            // ------- ADD 2015/12/17 田思春 For Redmine#47545 システムテスト障害一覧_#47545の指摘NO.2 抽出条件を支払先から仕入先に変更した後、既存の変数名が変更しない対応 ------->>>>>
            //仕入先コード
            if (startSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND SLIP.SUPPLIERCDRF>=@STSUPPLIERCODE";
                SqlParameter paraStSupplierCode = sqlCommand.Parameters.Add("@STSUPPLIERCODE", SqlDbType.Int);
                paraStSupplierCode.Value = SqlDataMediator.SqlSetInt32(startSupplierCd);
            }
            if (endSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND SLIP.SUPPLIERCDRF<=@EDSUPPLIERCODE";
                SqlParameter paraEdSupplierCode = sqlCommand.Parameters.Add("@EDSUPPLIERCODE", SqlDbType.Int);
                paraEdSupplierCode.Value = SqlDataMediator.SqlSetInt32(endSupplierCd);
            }
            // ------- ADD 2015/12/17 田思春 For Redmine#47545 システムテスト障害一覧_#47545の指摘NO.2 抽出条件を支払先から仕入先に変更した後、既存の変数名が変更しない対応 -------<<<<<

            // 仕入計上日付
            if (startAddUpDate <= endAddUpDate)
            {
                if (startAddUpDate == endAddUpDate)
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKADDUPADATERF=@FINDSTOCKADDUPADATE";
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATE", SqlDbType.Int);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                }
                else
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKADDUPADATERF>=@FINDSTARTSTOCKADDUPADATE AND SLIP.STOCKADDUPADATERF<=@FINDENDSTOCKADDUPADATE";
                    SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTSTOCKADDUPADATE", SqlDbType.Int);
                    paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                    SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDSTOCKADDUPADATE", SqlDbType.Int);
                    paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endAddUpDate);
                }
            }
            else
            {
                return false;
            }

            // 仕入拠点
            StringBuilder whereSectionCode = new StringBuilder();
            if (addUpSecCodeList.Count > 0)
            {
                if (addUpSecCodeList.Count == 1)
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKSECTIONCDRF='" + addUpSecCodeList[0] + "'";
                }
                else
                {
                    sqlCommand.CommandText += " AND SLIP.STOCKSECTIONCDRF IN (";
                    
                    string str = "";
                    for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
                    {
                        if (ix != 0)
                        {
                            str += ",";
                        }
                        str += "'" + addUpSecCodeList[ix] + "'";
                    }
                    sqlCommand.CommandText += str + ")";
                }
            }

            //仕入商品区分のチェック
            if (goodsCdMode == 1)
            {
                sqlCommand.CommandText += " AND SLIP.STOCKGOODSCDRF!=4 AND SLIP.STOCKGOODSCDRF!=5 AND SLIP.STOCKGOODSCDRF!=10";
            }
            else if (goodsCdMode == 2)
            {
            }

            #endregion
            return true;
        }
        
        #endregion 仕入先総括有効時
        // --- ADD 2012/10/02 ----------<<<<<

    }
}
