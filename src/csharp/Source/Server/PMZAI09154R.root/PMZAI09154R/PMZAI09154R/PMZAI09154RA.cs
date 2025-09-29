//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   在庫履歴現在庫数設定DBリモートオブジェクト
//                  :   PMZAI09154R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   李占川
// Date             :   2009/12/24
//----------------------------------------------------------------------
// Update Note      :   李占川　2010/01/06　redmine#2182 名称の登録を修正
//----------------------------------------------------------------------
// Update Note      :   李占川　2010/01/12　redmine#2291 在庫履歴の最大年月の判断を修正
//----------------------------------------------------------------------
// Update Note      :   李占川　2010/01/12　redmine#2335 在庫履歴の判断を修正
//----------------------------------------------------------------------
// Update Note      :   田村顕成 2024/01/26 在庫月次帳票集計範囲障害修正
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using System.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;
using System.Globalization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫履歴現在庫数設定DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫履歴現在庫数設定の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009/12/24</br>
    /// <br>UpdateNote : 2010/01/06 李占川 ＰＭ．ＮＳ保守依頼④</br>
    /// <br>             redmine#2182 名称の登録を修正</br>
    /// <br>UpdateNote : 2010/01/12 李占川 ＰＭ．ＮＳ保守依頼④</br>
    /// <br>             redmine#2291 在庫履歴の最大年月の判断を修正</br>
    /// <br>UpdateNote : 2010/01/13 李占川 ＰＭ．ＮＳ保守依頼④</br>
    /// <br>             redmine#2335 在庫履歴の判断を修正</br>
    /// </remarks>
    [Serializable]
    public class StockHistoryUpdateDB : RemoteWithAppLockDB, IStockHistoryUpdateDB
    {
        /// <summary>
        /// 在庫履歴現在庫数設定DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public StockHistoryUpdateDB()
            : base("PMZAI09156D", "Broadleaf.Application.Remoting.ParamData.StockHistoryUpdateWork", "STOCKHISTORYRF")
        {

        }

        private MonthlyAddUpDB _monthlyAddUpDB = new MonthlyAddUpDB();
        private CompanyInfWork _CompanyInfWork = null;

        #region [再集計処理]
        /// <summary>
        /// 指定された条件に基づいて、在庫履歴現在庫数を再集計します。
        /// </summary>
        /// <param name="stockHistoryUpdateWork">StockHistoryUpdateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件に基づいて、在庫履歴現在庫数を再集計します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// <br>UpdateNote : 2010/01/06 李占川 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>             redmine#2182 名称の登録を修正</br>
        /// <br>UpdateNote : 2010/01/12 李占川 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>             redmine#2291 在庫履歴の最大年月の判断を修正</br>
        /// <br>UpdateNote : 2010/01/13 李占川 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>             redmine#2335 在庫履歴の判断を修正</br>
        /// </remarks>
        public int ReCount(StockHistoryUpdateWork stockHistoryUpdateWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //コネクション・トランザクション
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlDataReader reader = null;

            ShareCheckInfo info = new ShareCheckInfo();

            try
            {
                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                using (sqlConnection = new SqlConnection(connectionText))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                    #region 在庫履歴データ内の計上年月の最大値
                    // 在庫履歴データ内の計上年月の最大値
                    DateTime maxAddUpYearMonth = DateTime.MinValue;

                    string sqlText = string.Empty;
                    sqlText += "SELECT MAX(ADDUPYEARMONTHRF) MAXADDUPYEARMONTHRF";
                    sqlText += " FROM STOCKHISTORYRF";
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = stockHistoryUpdateWork.EnterpriseCode;

                    reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        maxAddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(reader, reader.GetOrdinal("MAXADDUPYEARMONTHRF"));
                    }
                    maxAddUpYearMonth = DateTime.ParseExact(maxAddUpYearMonth.ToString("yyyyMM"), "yyyyMM", CultureInfo.InvariantCulture);

                    if (reader.IsClosed == false) reader.Close();
                    sqlCommand.Parameters.Clear();
                    #endregion

                    // --- ADD 2010/01/12 ---------->>>>>
                    if (Convert.ToInt32(maxAddUpYearMonth.ToString("yyyyMM")) < stockHistoryUpdateWork.AddUpYearMonth)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    // --- ADD 2010/01/12 ----------<<<<<

                    #region 前回月次更新年月度の締め日を日付取得部品より取得
                    // 日付取得部品を利用する
                    FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(stockHistoryUpdateWork.EnterpriseCode));

                    DateTime tmpStart;
                    DateTime tmpEnd;
                    // 前回月次更新日を取得
                    dateGetAcs.GetDaysFromMonth(maxAddUpYearMonth, out tmpStart, out tmpEnd);

                    #endregion

                    #region 最終月次更新日以降の在庫履歴を月次集計モジュールを使用して取得する
                    List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();

                    MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();
                    bool msgDiv;
                    string retMsg;

                    // 企業コード
                    monthlyAddUpWork.EnterpriseCode = stockHistoryUpdateWork.EnterpriseCode;
                    // 開始計上日付
                    //monthlyAddUpWork.AddUpDateSt = tmpEnd;// --- DEL 2024/01/26 在庫月次帳票集計範囲障害修正
                    monthlyAddUpWork.AddUpDateSt = tmpEnd.AddDays(1);// --- ADD 2024/01/26 在庫月次帳票集計範囲障害修正
                    // 終了計上日付
                    monthlyAddUpWork.AddUpDateEd = DateTime.MaxValue;
                    // 計上年月日
                    monthlyAddUpWork.AddUpDate = DateTime.MaxValue;
                    // 前回月次処理日
                    monthlyAddUpWork.LstMonAddUpProcDay = maxAddUpYearMonth;
                    // 計上年月
                    monthlyAddUpWork.AddUpYearMonth = maxAddUpYearMonth.AddMonths(1);

                    status = this._monthlyAddUpDB.MakeStockHistoryParameters(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);
                    if (status != 0)
                    {
                        return status;
                    }
                    #endregion

                    //●トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                    #region 排他制御
                    //システムロック(企業)
                    info.Keys.Add(stockHistoryUpdateWork.EnterpriseCode, ShareCheckType.Enterprise, "", "");
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                    if (status != 0)
                    {
                        return status;
                    }
                    #endregion

                    #region 在庫マスタの抽出処理
                    // 在庫マスタの抽出処理
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF";
                    sqlText += " FROM STOCKRF";
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = stockHistoryUpdateWork.EnterpriseCode;

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    reader = sqlCommand.ExecuteReader();

                    List<StockWork> stockWorkList = new List<StockWork>();
                    while (reader.Read())
                    {
                        stockWorkList.Add(this.CopyToStockWorkFromReader(reader));
                    }

                    sqlCommand.Parameters.Clear();

                    if (stockWorkList.Count == 0)
                    {
                        // 在庫マスタの抽出で該当データがない場合
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                    if (reader.IsClosed == false) reader.Close();
                    #endregion

                    #region 在庫履歴データを抽出
                    // 仕在庫履歴データを抽出
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPYEARMONTHRF, WAREHOUSECODERF, WAREHOUSENAMERF, SECTIONCODERF, GOODSNORF, GOODSNAMERF, GOODSMAKERCDRF, MAKERNAMERF, LMONTHSTOCKCNTRF, LMONTHSTOCKPRICERF, LMONTHPPTYSTOCKCNTRF, LMONTHPPTYSTOCKPRICERF, SALESTIMESRF, SALESCOUNTRF, SALESMONEYTAXEXCRF, SALESRETGOODSTIMESRF, SALESRETGOODSCNTRF, SALESRETGOODSPRICERF, GROSSPROFITRF, STOCKTIMESRF, STOCKCOUNTRF, STOCKPRICETAXEXCRF, STOCKRETGOODSTIMESRF, STOCKRETGOODSCNTRF, STOCKRETGOODSPRICERF, MOVEARRIVALCNTRF, MOVEARRIVALPRICERF, MOVESHIPMENTCNTRF, MOVESHIPMENTPRICERF, ADJUSTCOUNTRF, ADJUSTPRICERF, ARRIVALCNTRF, ARRIVALPRICERF, SHIPMENTCNTRF, SHIPMENTPRICERF, TOTALARRIVALCNTRF, TOTALARRIVALPRICERF, TOTALSHIPMENTCNTRF, TOTALSHIPMENTPRICERF, STOCKUNITPRICEFLRF, STOCKTOTALRF, STOCKMASHINEPRICERF, PROPERTYSTOCKCNTRF, PROPERTYSTOCKPRICERF";
                    sqlText += " FROM STOCKHISTORYRF";
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPYEARMONTHRF>=@FINDADDUPYEARMONTH";
                    sqlText += " ORDER BY ADDUPYEARMONTHRF DESC";
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = stockHistoryUpdateWork.EnterpriseCode;
                    findParaAddUpYearMonth.Value = stockHistoryUpdateWork.AddUpYearMonth;

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    reader = sqlCommand.ExecuteReader();

                    ArrayList stockHistoryWorkArrList = new ArrayList();
                    while (reader.Read())
                    {
                        stockHistoryWorkArrList.Add(this.CopyToStockHistoryWorkFromReader(reader));
                    }
                    sqlCommand.Parameters.Clear();
                    if (reader.IsClosed == false) reader.Close();
                    #endregion

                    #region 更新と新規データの準備
                    // 在庫総数差分数
                    double stockCntDiff = 0;
                    // 自社在庫数差分数
                    double propertyStockCntDiff = 0;

                    List<StockHistoryWork> updateList = new List<StockHistoryWork>();
                    foreach (StockWork stockWork in stockWorkList)
                    {
                        // 倉庫
                        string warehouseCode = stockWork.WarehouseCode;
                        // 品番
                        string goodsNo = stockWork.GoodsNo;
                        // メーカー
                        int goodsMakerCd = stockWork.GoodsMakerCd;

                        StockHistoryWork tempStockHistoryWork = this.GetStockHistoryWork(stockHistoryWorkList, warehouseCode, goodsNo, goodsMakerCd);
                        ArrayList tempStockHistoryWorkArrList = this.FilterStockHistoryWorkList(stockHistoryWorkArrList, warehouseCode, goodsNo, goodsMakerCd);

                        if (tempStockHistoryWork == null)
                        {
                            if (tempStockHistoryWorkArrList.Count != 0   // 在庫履歴データが存在する
                                || stockWork.ShipmentPosCnt == 0)        // 出荷可能数が０です
                            {
                                continue;
                            }
                            #region 不正なデータの場合①
                            // 原価算出用
                            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();

                            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // 原価計算パラメータオブジェクトリスト
                            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // 商品連結データオブジェクトリスト
                            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // 原価計算結果リスト
                            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

                            #region 原価算出用SQL
                            sqlText = string.Empty;
                            sqlText += "  SELECT" + Environment.NewLine;
                            sqlText += "   GOODS.BLGOODSCODERF,  -- BL商品コード" + Environment.NewLine;
                            sqlText += "   BL.BLGROUPCODERF, -- BLグループコード" + Environment.NewLine;
                            sqlText += "   BLG.GOODSMGROUPRF, -- 商品中分類" + Environment.NewLine;
                            sqlText += "   GOODS.GOODSRATERANKRF -- 商品掛率ランク" + Environment.NewLine;
                            sqlText += "  FROM" + Environment.NewLine;
                            sqlText += "  GOODSURF AS GOODS " + Environment.NewLine;
                            sqlText += " LEFT JOIN BLGOODSCDURF AS BL -- BLマスタ" + Environment.NewLine;
                            sqlText += "  ON  GOODS.ENTERPRISECODERF = BL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  AND GOODS.BLGOODSCODERF = BL.BLGOODSCODERF" + Environment.NewLine;
                            sqlText += " LEFT JOIN BLGROUPURF AS BLG -- BLグループコードマスタ" + Environment.NewLine;
                            sqlText += "  ON GOODS.ENTERPRISECODERF = BLG.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  AND BL.BLGROUPCODERF = BLG.BLGROUPCODERF" + Environment.NewLine;
                            sqlText += "  WHERE GOODS.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND GOODS.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlText += "  AND GOODS.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                            sqlText += "  AND GOODS.LOGICALDELETECODERF = 0" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            #endregion
                            //Prameterオブジェクトの作成
                            findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = stockWork.EnterpriseCode;
                            findParaGoodsMakerCd.Value = stockWork.GoodsMakerCd;
                            findParaGoodsNo.Value = stockWork.GoodsNo;

                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            reader = sqlCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                                GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // 商品連結データオブジェクトリスト
                                GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();

                                #region 商品仕入取得データクラス
                                goodsSupplierDataWork.EnterpriseCode = stockWork.EnterpriseCode;
                                goodsSupplierDataWork.SectionCode = stockWork.SectionCode;
                                goodsSupplierDataWork.GoodsMakerCd = stockWork.GoodsMakerCd;
                                goodsSupplierDataWork.GoodsNo = stockWork.GoodsNo;
                                goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("BLGOODSCODERF"));  // BL商品コード
                                goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("GOODSMGROUPRF"));  // 商品中分類コード
                                GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);
                                #endregion

                                #region 単価算出モジュール計算用パラメータ
                                unitPriceCalcParam.SectionCode = stockWork.SectionCode;
                                unitPriceCalcParam.GoodsMakerCd = stockWork.GoodsMakerCd;
                                unitPriceCalcParam.GoodsNo = stockWork.GoodsNo;
                                unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("GOODSMGROUPRF")); // 商品中分類コード
                                unitPriceCalcParam.BLGroupCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("BLGROUPCODERF"));      // BLグループコード
                                unitPriceCalcParam.BLGoodsCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("BLGOODSCODERF"));      // BL商品コード
                                unitPriceCalcParam.GoodsRateRank = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("GOODSRATERANKRF"));  // 商品掛率ランク
                                unitPriceCalcParam.PriceApplyDate = DateTime.Now;
                                unitPriceCalcParamList.Add(unitPriceCalcParam);
                                #endregion

                                #region 商品連結データリスト
                                goodsUnitData.EnterpriseCode = stockWork.EnterpriseCode;
                                goodsUnitData.GoodsNo = stockWork.GoodsNo;
                                goodsUnitData.GoodsMakerCd = stockWork.GoodsMakerCd;
                                goodsUnitDataList.Add(goodsUnitData);
                                #endregion
                            }
                            sqlCommand.Parameters.Clear();
                            if (reader.IsClosed == false) reader.Close();

                            if (GoodsSupplierDataWorkList.Count > 0)
                            {
                                // 仕入先取得用
                                GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();

                                // 商品仕入先情報取得処理 実行
                                goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                                // 商品仕入先情報取得処理により取得した仕入先を
                                // 単価算出パラメータにセット
                                for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // 商品仕入取得データクラス
                                {
                                    for (int j = 0; j < unitPriceCalcParamList.Count; j++) // 単価算出モジュール計算用パラメータ
                                    {
                                        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // 商品メーカー
                                            (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // 商品番号
                                            (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL商品コード
                                        {
                                            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                                            {
                                                unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                                            }
                                        }
                                    }
                                }

                                //原価算出処理 実行
                                unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
                            }

                            // 単価計算結果
                            double stockUnitPriceFl = 0;
                            for (int i = 0; i < unitPriceCalcRetList.Count; i++)
                            {
                                if ((unitPriceCalcRetList[i].GoodsMakerCd == stockWork.GoodsMakerCd) && // 商品メーカー
                                    (unitPriceCalcRetList[i].GoodsNo == stockWork.GoodsNo))     // BL商品コード
                                {
                                    stockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                    break;
                                }
                            }

                            // --- ADD 2010/01/06 ---------->>>>>
                            // 倉庫マスタデータを抽出
                            sqlText = string.Empty;
                            sqlText += "SELECT WAREHOUSENAMERF";
                            sqlText += " FROM WAREHOUSERF";
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                            sqlText += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE";
                            sqlCommand.CommandText = sqlText;

                            //Prameterオブジェクトの作成
                            findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = stockWork.EnterpriseCode;
                            findParaWarehouseCode.Value = stockWork.WarehouseCode;

                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            reader = sqlCommand.ExecuteReader();

                            string warehouseName = string.Empty;
                            if (reader.Read())
                            {
                                warehouseName = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("WAREHOUSENAMERF"));  // 倉庫名称
                            }
                            sqlCommand.Parameters.Clear();

                            // 商品マスタデータを抽出
                            sqlText = string.Empty;
                            sqlText += "SELECT GOODSNAMERF";
                            sqlText += " FROM GOODSURF";
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                            sqlText += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD";
                            sqlText += " AND GOODSNORF=@FINDGOODSNO";
                            sqlCommand.CommandText = sqlText;

                            //Prameterオブジェクトの作成
                            findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                            findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = stockWork.EnterpriseCode;
                            findParaGoodsMakerCd.Value = stockWork.GoodsMakerCd;
                            findParaGoodsNo.Value = stockWork.GoodsNo;

                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            reader = sqlCommand.ExecuteReader();

                            string goodsName = string.Empty;
                            if (reader.Read())
                            {
                                goodsName = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("GOODSNAMERF"));  // 商品名称
                            }
                            sqlCommand.Parameters.Clear();

                            // メーカーマスタデータを抽出
                            sqlText = string.Empty;
                            sqlText += "SELECT MAKERNAMERF";
                            sqlText += " FROM MAKERURF";
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                            sqlText += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD";
                            sqlCommand.CommandText = sqlText;

                            //Prameterオブジェクトの作成
                            findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = stockWork.EnterpriseCode;
                            findParaGoodsMakerCd.Value = stockWork.GoodsMakerCd;

                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            reader = sqlCommand.ExecuteReader();

                            string makerName = string.Empty;
                            if (reader.Read())
                            {
                                makerName = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("MAKERNAMERF"));  // メーカー名称
                            }
                            sqlCommand.Parameters.Clear();
                            if (reader.IsClosed == false) reader.Close();
                            // --- ADD 2010/01/06 ----------<<<<<

                            DateTime date = DateTime.ParseExact(stockHistoryUpdateWork.AddUpYearMonth.ToString() + "01", "yyyyMMdd", CultureInfo.InvariantCulture);
                            while (Convert.ToInt32(date.ToString("yyyyMM")) <= Convert.ToInt32(maxAddUpYearMonth.ToString("yyyyMM")))
                            {
                                tempStockHistoryWork = new StockHistoryWork();
                                tempStockHistoryWork.EnterpriseCode = stockWork.EnterpriseCode;
                                tempStockHistoryWork.WarehouseCode = stockWork.WarehouseCode;
                                tempStockHistoryWork.SectionCode = stockWork.SectionCode;
                                tempStockHistoryWork.GoodsNo = stockWork.GoodsNo;
                                tempStockHistoryWork.GoodsMakerCd = stockWork.GoodsMakerCd;
                                // --- ADD 2010/01/06 ---------->>>>>
                                // 倉庫名称
                                tempStockHistoryWork.WarehouseName = warehouseName;
                                // 商品名称
                                tempStockHistoryWork.GoodsName = goodsName;
                                    // メーカー名称
                                tempStockHistoryWork.MakerName = makerName;
                                // --- ADD 2010/01/06 ----------<<<<<

                                // 計上年月
                                tempStockHistoryWork.AddUpYearMonth = date;
                                // 仕入単価
                                tempStockHistoryWork.StockUnitPriceFl = stockUnitPriceFl;
                                // 前月末在庫数
                                tempStockHistoryWork.LMonthStockCnt = stockWork.ShipmentPosCnt;
                                // 前月末自社在庫数
                                tempStockHistoryWork.LMonthPptyStockCnt = stockWork.ShipmentPosCnt;
                                // 在庫総数
                                tempStockHistoryWork.StockTotal = stockWork.ShipmentPosCnt;
                                // 自社在庫数
                                tempStockHistoryWork.PropertyStockCnt = stockWork.ShipmentPosCnt;

                                this.MoneyFracCalc(ref tempStockHistoryWork);
                                updateList.Add(tempStockHistoryWork);

                                date = date.AddMonths(1);
                            }
                            #endregion
                        }
                        else
                        {
                            // --- ADD 2010/01/03 ---------->>>>>
                            if (tempStockHistoryWorkArrList.Count == 0)
                            {
                                continue;
                            }
                            // --- ADD 2010/01/03 ----------<<<<<

                            #region 不正なデータの場合②
                            // 在庫総数差分数 ＝ (在庫マスタ:出荷可能数＋受注数) － 月次集計結果.在庫総数
                            stockCntDiff = (stockWork.ShipmentPosCnt + stockWork.AcpOdrCount) - tempStockHistoryWork.StockTotal;
                            // 自社在庫数差分数 ＝ (在庫マスタ:出荷可能数＋受注数＋出荷数（未計上）) － 月次集計結果.自社在庫総数
                            propertyStockCntDiff = (stockWork.ShipmentPosCnt + stockWork.AcpOdrCount + stockWork.ShipmentCnt) - tempStockHistoryWork.PropertyStockCnt;

                            // 在庫総数差分数 ≠ 0 ＯＲ 自社在庫数差分数 ≠ 0の場合
                            if (stockCntDiff != 0 || propertyStockCntDiff != 0)
                            {
                                StockHistoryWork work = tempStockHistoryWorkArrList[0] as StockHistoryWork;

                                // 前月末在庫数     ＝ 前月末在庫数 ＋ 在庫総数差
                                work.LMonthStockCnt = work.LMonthStockCnt + stockCntDiff;
                                // 前月末自社在庫数 ＝ 前月末自社在庫数 ＋ 自社在庫数差分
                                work.LMonthPptyStockCnt = work.LMonthPptyStockCnt + propertyStockCntDiff;
                                // 在庫総数 ＝ 在庫総数 ＋ 在庫総数差分
                                work.StockTotal = work.StockTotal + stockCntDiff;
                                // 自社在庫数 ＝ 自社在庫数 ＋ 自社在庫数差分
                                work.PropertyStockCnt = work.PropertyStockCnt + propertyStockCntDiff;

                                this.MoneyFracCalc(ref work);
                                updateList.Add(work);

                                StockHistoryWork diffStockHistoryWork = work;

                                int i = 0;
                                foreach (StockHistoryWork workTemp in tempStockHistoryWorkArrList)
                                {
                                    if (i == 0)
                                    {
                                        i++;
                                        continue;
                                    }
                                    // 在庫総数差分数 ＝ 差分適用レコード.前月末在庫数 － １か月前.在庫総数
                                    stockCntDiff = diffStockHistoryWork.LMonthStockCnt - workTemp.StockTotal;
                                    // 自社在庫数差分数 ＝ 差分適用レコード.前月末自社在庫数 － １か月前.自社在庫数
                                    propertyStockCntDiff = diffStockHistoryWork.LMonthPptyStockCnt - workTemp.PropertyStockCnt;

                                    if (stockCntDiff != 0 || propertyStockCntDiff != 0)
                                    {
                                        // 前月末在庫数     ＝ 前月末在庫数 ＋ 在庫総数差
                                        workTemp.LMonthStockCnt = workTemp.LMonthStockCnt + stockCntDiff;
                                        // 前月末自社在庫数 ＝ 前月末自社在庫数 ＋ 自社在庫数差分
                                        workTemp.LMonthPptyStockCnt = workTemp.LMonthPptyStockCnt + propertyStockCntDiff;
                                        // 在庫総数 ＝ 在庫総数 ＋ 在庫総数差分
                                        workTemp.StockTotal = workTemp.StockTotal + stockCntDiff;
                                        // 自社在庫数 ＝ 自社在庫数 ＋ 自社在庫数差分
                                        workTemp.PropertyStockCnt = workTemp.PropertyStockCnt + propertyStockCntDiff;

                                        diffStockHistoryWork = workTemp;
                                        this.MoneyFracCalc(ref diffStockHistoryWork);
                                        updateList.Add(diffStockHistoryWork);
                                    }
                                    else
                                    {
                                        // このレコード以前のレコードも処理せずに、次の在庫品の判定を行う。
                                        break;
                                    }
                                    i++;
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #region 更新処理
                    // 更新処理
                    status = this.WriteStockHistory(ref updateList, ref sqlConnection, ref sqlTransaction);
                    #endregion

                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }

                    //システムロック解除
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                    {
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockHistoryUpdateDB.Write Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    reader.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region 在庫履歴データの更新処理
        /// <summary>
        /// 在庫履歴データを更新します
        /// </summary>
        /// <param name="stockHistoryWorkList">在庫履歴データList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫履歴データを更新します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private int WriteStockHistory(ref List<StockHistoryWork> stockHistoryWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;
                foreach (StockHistoryWork stockHistoryWork in stockHistoryWorkList)
                {
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPYEARMONTHRF, WAREHOUSECODERF, WAREHOUSENAMERF, SECTIONCODERF, GOODSNORF, GOODSNAMERF, GOODSMAKERCDRF, MAKERNAMERF, LMONTHSTOCKCNTRF, LMONTHSTOCKPRICERF, LMONTHPPTYSTOCKCNTRF, LMONTHPPTYSTOCKPRICERF, SALESTIMESRF, SALESCOUNTRF, SALESMONEYTAXEXCRF, SALESRETGOODSTIMESRF, SALESRETGOODSCNTRF, SALESRETGOODSPRICERF, GROSSPROFITRF, STOCKTIMESRF, STOCKCOUNTRF, STOCKPRICETAXEXCRF, STOCKRETGOODSTIMESRF, STOCKRETGOODSCNTRF, STOCKRETGOODSPRICERF, MOVEARRIVALCNTRF, MOVEARRIVALPRICERF, MOVESHIPMENTCNTRF, MOVESHIPMENTPRICERF, ADJUSTCOUNTRF, ADJUSTPRICERF, ARRIVALCNTRF, ARRIVALPRICERF, SHIPMENTCNTRF, SHIPMENTPRICERF, TOTALARRIVALCNTRF, TOTALARRIVALPRICERF, TOTALSHIPMENTCNTRF, TOTALSHIPMENTPRICERF, STOCKUNITPRICEFLRF, STOCKTOTALRF, STOCKMASHINEPRICERF, PROPERTYSTOCKCNTRF, PROPERTYSTOCKPRICERF";
                    sqlText += " FROM STOCKHISTORYRF";
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSNORF=@FINDGOODSNO AND GOODSMAKERCDRF=@FINDGOODSMAKERCD";
                    //sqlCommand.CommandText = sqlText;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = stockHistoryWork.EnterpriseCode;
                    findParaAddUpYearMonth.Value = Convert.ToInt32(stockHistoryWork.AddUpYearMonth.ToString("yyyyMM"));
                    findParaWarehouseCode.Value = stockHistoryWork.WarehouseCode;
                    findParaSectionCode.Value = stockHistoryWork.SectionCode;
                    findParaGoodsNo.Value = stockHistoryWork.GoodsNo;
                    findParaGoodsMakerCd.Value = stockHistoryWork.GoodsMakerCd;

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != stockHistoryWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (stockHistoryWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        #region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE STOCKHISTORYRF";
                        sqlText += " SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , ADDUPYEARMONTHRF=@ADDUPYEARMONTH , WAREHOUSECODERF=@WAREHOUSECODE , WAREHOUSENAMERF=@WAREHOUSENAME , SECTIONCODERF=@SECTIONCODE , GOODSNORF=@GOODSNO , GOODSNAMERF=@GOODSNAME , GOODSMAKERCDRF=@GOODSMAKERCD , MAKERNAMERF=@MAKERNAME , LMONTHSTOCKCNTRF=@LMONTHSTOCKCNT , LMONTHSTOCKPRICERF=@LMONTHSTOCKPRICE , LMONTHPPTYSTOCKCNTRF=@LMONTHPPTYSTOCKCNT , LMONTHPPTYSTOCKPRICERF=@LMONTHPPTYSTOCKPRICE , SALESTIMESRF=@SALESTIMES , SALESCOUNTRF=@SALESCOUNT , SALESMONEYTAXEXCRF=@SALESMONEYTAXEXC , SALESRETGOODSTIMESRF=@SALESRETGOODSTIMES , SALESRETGOODSCNTRF=@SALESRETGOODSCNT , SALESRETGOODSPRICERF=@SALESRETGOODSPRICE , GROSSPROFITRF=@GROSSPROFIT , STOCKTIMESRF=@STOCKTIMES , STOCKCOUNTRF=@STOCKCOUNT , STOCKPRICETAXEXCRF=@STOCKPRICETAXEXC , STOCKRETGOODSTIMESRF=@STOCKRETGOODSTIMES , STOCKRETGOODSCNTRF=@STOCKRETGOODSCNT , STOCKRETGOODSPRICERF=@STOCKRETGOODSPRICE , MOVEARRIVALCNTRF=@MOVEARRIVALCNT , MOVEARRIVALPRICERF=@MOVEARRIVALPRICE , MOVESHIPMENTCNTRF=@MOVESHIPMENTCNT , MOVESHIPMENTPRICERF=@MOVESHIPMENTPRICE , ADJUSTCOUNTRF=@ADJUSTCOUNT , ADJUSTPRICERF=@ADJUSTPRICE , ARRIVALCNTRF=@ARRIVALCNT , ARRIVALPRICERF=@ARRIVALPRICE , SHIPMENTCNTRF=@SHIPMENTCNT , SHIPMENTPRICERF=@SHIPMENTPRICE , TOTALARRIVALCNTRF=@TOTALARRIVALCNT , TOTALARRIVALPRICERF=@TOTALARRIVALPRICE , TOTALSHIPMENTCNTRF=@TOTALSHIPMENTCNT , TOTALSHIPMENTPRICERF=@TOTALSHIPMENTPRICE , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL , STOCKTOTALRF=@STOCKTOTAL , STOCKMASHINEPRICERF=@STOCKMASHINEPRICE , PROPERTYSTOCKCNTRF=@PROPERTYSTOCKCNT , PROPERTYSTOCKPRICERF=@PROPERTYSTOCKPRICE";
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSNORF=@FINDGOODSNO AND GOODSMAKERCDRF=@FINDGOODSMAKERCD";
                        #endregion
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                        findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = stockHistoryWork.EnterpriseCode;
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(stockHistoryWork.AddUpYearMonth);
                        findParaWarehouseCode.Value = stockHistoryWork.WarehouseCode;
                        findParaSectionCode.Value = stockHistoryWork.SectionCode;
                        findParaGoodsNo.Value = stockHistoryWork.GoodsNo;
                        findParaGoodsMakerCd.Value = stockHistoryWork.GoodsMakerCd;

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockHistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (stockHistoryWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        #region [INSERT文]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO STOCKHISTORYRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += "    ,WAREHOUSECODERF" + Environment.NewLine;
                        sqlText += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                        sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,GOODSNORF" + Environment.NewLine;
                        sqlText += "    ,GOODSNAMERF" + Environment.NewLine;
                        sqlText += "    ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += "    ,MAKERNAMERF" + Environment.NewLine;
                        sqlText += "    ,LMONTHSTOCKCNTRF" + Environment.NewLine;
                        sqlText += "    ,LMONTHSTOCKPRICERF" + Environment.NewLine;
                        sqlText += "    ,LMONTHPPTYSTOCKCNTRF" + Environment.NewLine;
                        sqlText += "    ,LMONTHPPTYSTOCKPRICERF" + Environment.NewLine;
                        sqlText += "    ,SALESTIMESRF" + Environment.NewLine;
                        sqlText += "    ,SALESCOUNTRF" + Environment.NewLine;
                        sqlText += "    ,SALESMONEYTAXEXCRF" + Environment.NewLine;
                        sqlText += "    ,SALESRETGOODSTIMESRF" + Environment.NewLine;
                        sqlText += "    ,SALESRETGOODSCNTRF" + Environment.NewLine;
                        sqlText += "    ,SALESRETGOODSPRICERF" + Environment.NewLine;
                        sqlText += "    ,GROSSPROFITRF" + Environment.NewLine;
                        sqlText += "    ,STOCKTIMESRF" + Environment.NewLine;
                        sqlText += "    ,STOCKCOUNTRF" + Environment.NewLine;
                        sqlText += "    ,STOCKPRICETAXEXCRF" + Environment.NewLine;
                        sqlText += "    ,STOCKRETGOODSTIMESRF" + Environment.NewLine;
                        sqlText += "    ,STOCKRETGOODSCNTRF" + Environment.NewLine;
                        sqlText += "    ,STOCKRETGOODSPRICERF" + Environment.NewLine;
                        sqlText += "    ,MOVEARRIVALCNTRF" + Environment.NewLine;
                        sqlText += "    ,MOVEARRIVALPRICERF" + Environment.NewLine;
                        sqlText += "    ,MOVESHIPMENTCNTRF" + Environment.NewLine;
                        sqlText += "    ,MOVESHIPMENTPRICERF" + Environment.NewLine;
                        sqlText += "    ,ADJUSTCOUNTRF" + Environment.NewLine;
                        sqlText += "    ,ADJUSTPRICERF" + Environment.NewLine;
                        sqlText += "    ,ARRIVALCNTRF" + Environment.NewLine;
                        sqlText += "    ,ARRIVALPRICERF" + Environment.NewLine;
                        sqlText += "    ,SHIPMENTCNTRF" + Environment.NewLine;
                        sqlText += "    ,SHIPMENTPRICERF" + Environment.NewLine;
                        sqlText += "    ,TOTALARRIVALCNTRF" + Environment.NewLine;
                        sqlText += "    ,TOTALARRIVALPRICERF" + Environment.NewLine;
                        sqlText += "    ,TOTALSHIPMENTCNTRF" + Environment.NewLine;
                        sqlText += "    ,TOTALSHIPMENTPRICERF" + Environment.NewLine;
                        sqlText += "    ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                        sqlText += "    ,STOCKTOTALRF" + Environment.NewLine;
                        sqlText += "    ,STOCKMASHINEPRICERF" + Environment.NewLine;
                        sqlText += "    ,PROPERTYSTOCKCNTRF" + Environment.NewLine;
                        sqlText += "    ,PROPERTYSTOCKPRICERF" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "    ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "    ,@WAREHOUSECODE" + Environment.NewLine;
                        sqlText += "    ,@WAREHOUSENAME" + Environment.NewLine;
                        sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                        sqlText += "    ,@GOODSNO" + Environment.NewLine;
                        sqlText += "    ,@GOODSNAME" + Environment.NewLine;
                        sqlText += "    ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += "    ,@MAKERNAME" + Environment.NewLine;
                        sqlText += "    ,@LMONTHSTOCKCNT" + Environment.NewLine;
                        sqlText += "    ,@LMONTHSTOCKPRICE" + Environment.NewLine;
                        sqlText += "    ,@LMONTHPPTYSTOCKCNT" + Environment.NewLine;
                        sqlText += "    ,@LMONTHPPTYSTOCKPRICE" + Environment.NewLine;
                        sqlText += "    ,@SALESTIMES" + Environment.NewLine;
                        sqlText += "    ,@SALESCOUNT" + Environment.NewLine;
                        sqlText += "    ,@SALESMONEYTAXEXC" + Environment.NewLine;
                        sqlText += "    ,@SALESRETGOODSTIMES" + Environment.NewLine;
                        sqlText += "    ,@SALESRETGOODSCNT" + Environment.NewLine;
                        sqlText += "    ,@SALESRETGOODSPRICE" + Environment.NewLine;
                        sqlText += "    ,@GROSSPROFIT" + Environment.NewLine;
                        sqlText += "    ,@STOCKTIMES" + Environment.NewLine;
                        sqlText += "    ,@STOCKCOUNT" + Environment.NewLine;
                        sqlText += "    ,@STOCKPRICETAXEXC" + Environment.NewLine;
                        sqlText += "    ,@STOCKRETGOODSTIMES" + Environment.NewLine;
                        sqlText += "    ,@STOCKRETGOODSCNT" + Environment.NewLine;
                        sqlText += "    ,@STOCKRETGOODSPRICE" + Environment.NewLine;
                        sqlText += "    ,@MOVEARRIVALCNT" + Environment.NewLine;
                        sqlText += "    ,@MOVEARRIVALPRICE" + Environment.NewLine;
                        sqlText += "    ,@MOVESHIPMENTCNT" + Environment.NewLine;
                        sqlText += "    ,@MOVESHIPMENTPRICE" + Environment.NewLine;
                        sqlText += "    ,@ADJUSTCOUNT" + Environment.NewLine;
                        sqlText += "    ,@ADJUSTPRICE" + Environment.NewLine;
                        sqlText += "    ,@ARRIVALCNT" + Environment.NewLine;
                        sqlText += "    ,@ARRIVALPRICE" + Environment.NewLine;
                        sqlText += "    ,@SHIPMENTCNT" + Environment.NewLine;
                        sqlText += "    ,@SHIPMENTPRICE" + Environment.NewLine;
                        sqlText += "    ,@TOTALARRIVALCNT" + Environment.NewLine;
                        sqlText += "    ,@TOTALARRIVALPRICE" + Environment.NewLine;
                        sqlText += "    ,@TOTALSHIPMENTCNT" + Environment.NewLine;
                        sqlText += "    ,@TOTALSHIPMENTPRICE" + Environment.NewLine;
                        sqlText += "    ,@STOCKUNITPRICEFL" + Environment.NewLine;
                        sqlText += "    ,@STOCKTOTAL" + Environment.NewLine;
                        sqlText += "    ,@STOCKMASHINEPRICE" + Environment.NewLine;
                        sqlText += "    ,@PROPERTYSTOCKCNT" + Environment.NewLine;
                        sqlText += "    ,@PROPERTYSTOCKPRICE" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        #endregion
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockHistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    #region Parameterオブジェクト作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                    SqlParameter paraLMonthStockCnt = sqlCommand.Parameters.Add("@LMONTHSTOCKCNT", SqlDbType.Float);
                    SqlParameter paraLMonthStockPrice = sqlCommand.Parameters.Add("@LMONTHSTOCKPRICE", SqlDbType.BigInt);
                    SqlParameter paraLMonthPptyStockCnt = sqlCommand.Parameters.Add("@LMONTHPPTYSTOCKCNT", SqlDbType.Float);
                    SqlParameter paraLMonthPptyStockPrice = sqlCommand.Parameters.Add("@LMONTHPPTYSTOCKPRICE", SqlDbType.BigInt);
                    SqlParameter paraSalesTimes = sqlCommand.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                    SqlParameter paraSalesCount = sqlCommand.Parameters.Add("@SALESCOUNT", SqlDbType.Float);
                    SqlParameter paraSalesMoneyTaxExc = sqlCommand.Parameters.Add("@SALESMONEYTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesRetGoodsTimes = sqlCommand.Parameters.Add("@SALESRETGOODSTIMES", SqlDbType.Int);
                    SqlParameter paraSalesRetGoodsCnt = sqlCommand.Parameters.Add("@SALESRETGOODSCNT", SqlDbType.Float);
                    SqlParameter paraSalesRetGoodsPrice = sqlCommand.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                    SqlParameter paraGrossProfit = sqlCommand.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);
                    SqlParameter paraStockTimes = sqlCommand.Parameters.Add("@STOCKTIMES", SqlDbType.Int);
                    SqlParameter paraStockCount = sqlCommand.Parameters.Add("@STOCKCOUNT", SqlDbType.Float);
                    SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                    SqlParameter paraStockRetGoodsTimes = sqlCommand.Parameters.Add("@STOCKRETGOODSTIMES", SqlDbType.Int);
                    SqlParameter paraStockRetGoodsCnt = sqlCommand.Parameters.Add("@STOCKRETGOODSCNT", SqlDbType.Float);
                    SqlParameter paraStockRetGoodsPrice = sqlCommand.Parameters.Add("@STOCKRETGOODSPRICE", SqlDbType.BigInt);
                    SqlParameter paraMoveArrivalCnt = sqlCommand.Parameters.Add("@MOVEARRIVALCNT", SqlDbType.Float);
                    SqlParameter paraMoveArrivalPrice = sqlCommand.Parameters.Add("@MOVEARRIVALPRICE", SqlDbType.BigInt);
                    SqlParameter paraMoveShipmentCnt = sqlCommand.Parameters.Add("@MOVESHIPMENTCNT", SqlDbType.Float);
                    SqlParameter paraMoveShipmentPrice = sqlCommand.Parameters.Add("@MOVESHIPMENTPRICE", SqlDbType.BigInt);
                    SqlParameter paraAdjustCount = sqlCommand.Parameters.Add("@ADJUSTCOUNT", SqlDbType.Float);
                    SqlParameter paraAdjustPrice = sqlCommand.Parameters.Add("@ADJUSTPRICE", SqlDbType.BigInt);
                    SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                    SqlParameter paraArrivalPrice = sqlCommand.Parameters.Add("@ARRIVALPRICE", SqlDbType.BigInt);
                    SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                    SqlParameter paraShipmentPrice = sqlCommand.Parameters.Add("@SHIPMENTPRICE", SqlDbType.BigInt);
                    SqlParameter paraTotalArrivalCnt = sqlCommand.Parameters.Add("@TOTALARRIVALCNT", SqlDbType.Float);
                    SqlParameter paraTotalArrivalPrice = sqlCommand.Parameters.Add("@TOTALARRIVALPRICE", SqlDbType.BigInt);
                    SqlParameter paraTotalShipmentCnt = sqlCommand.Parameters.Add("@TOTALSHIPMENTCNT", SqlDbType.Float);
                    SqlParameter paraTotalShipmentPrice = sqlCommand.Parameters.Add("@TOTALSHIPMENTPRICE", SqlDbType.BigInt);
                    SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                    SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                    SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                    SqlParameter paraPropertyStockCnt = sqlCommand.Parameters.Add("@PROPERTYSTOCKCNT", SqlDbType.Float);
                    SqlParameter paraPropertyStockPrice = sqlCommand.Parameters.Add("@PROPERTYSTOCKPRICE", SqlDbType.BigInt);
                    #endregion

                    #region Parameterオブジェクト設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockHistoryWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockHistoryWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockHistoryWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.LogicalDeleteCode);
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(stockHistoryWork.AddUpYearMonth);
                    paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.WarehouseCode);
                    paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockHistoryWork.WarehouseName);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.SectionCode);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockHistoryWork.GoodsNo);
                    paraGoodsName.Value = SqlDataMediator.SqlSetString(stockHistoryWork.GoodsName);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.GoodsMakerCd);
                    paraMakerName.Value = SqlDataMediator.SqlSetString(stockHistoryWork.MakerName);
                    paraLMonthStockCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.LMonthStockCnt);
                    paraLMonthStockPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.LMonthStockPrice);
                    paraLMonthPptyStockCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.LMonthPptyStockCnt);
                    paraLMonthPptyStockPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.LMonthPptyStockPrice);
                    paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SalesTimes);
                    paraSalesCount.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.SalesCount);
                    paraSalesMoneyTaxExc.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.SalesMoneyTaxExc);
                    paraSalesRetGoodsTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SalesRetGoodsTimes);
                    paraSalesRetGoodsCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.SalesRetGoodsCnt);
                    paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.SalesRetGoodsPrice);
                    paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.GrossProfit);
                    paraStockTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.StockTimes);
                    paraStockCount.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockCount);
                    paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.StockPriceTaxExc);
                    paraStockRetGoodsTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.StockRetGoodsTimes);
                    paraStockRetGoodsCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockRetGoodsCnt);
                    paraStockRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.StockRetGoodsPrice);
                    paraMoveArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.MoveArrivalCnt);
                    paraMoveArrivalPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.MoveArrivalPrice);
                    paraMoveShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.MoveShipmentCnt);
                    paraMoveShipmentPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.MoveShipmentPrice);
                    paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.AdjustCount);
                    paraAdjustPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.AdjustPrice);
                    paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.ArrivalCnt);
                    paraArrivalPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.ArrivalPrice);
                    paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.ShipmentCnt);
                    paraShipmentPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.ShipmentPrice);
                    paraTotalArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.TotalArrivalCnt);
                    paraTotalArrivalPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.TotalArrivalPrice);
                    paraTotalShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.TotalShipmentCnt);
                    paraTotalShipmentPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.TotalShipmentPrice);
                    paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockUnitPriceFl);
                    paraStockTotal.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockTotal);
                    paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.StockMashinePrice);
                    paraPropertyStockCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.PropertyStockCnt);
                    paraPropertyStockPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.PropertyStockPrice);
                    #endregion

                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.Parameters.Clear();
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockWork</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理 Reader → StockWorkを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromReader(SqlDataReader myReader)
        {
            StockWork stockWork = new StockWork();

            stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
            stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
            stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
            stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
            stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
            stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
            stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
            stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
            stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
            stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

            return stockWork;
        }


        /// <summary>
        /// クラス格納処理 Reader → StockHistoryWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockHistoryWork</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理 Reader → StockHistoryWorkを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private StockHistoryWork CopyToStockHistoryWorkFromReader(SqlDataReader myReader)
        {
            StockHistoryWork stockHistoryWork = new StockHistoryWork();

            stockHistoryWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            stockHistoryWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            stockHistoryWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            stockHistoryWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            stockHistoryWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            stockHistoryWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            stockHistoryWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            stockHistoryWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            stockHistoryWork.AddUpYearMonth = DateTime.ParseExact(SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString("yyyyMM"), "yyyyMM", CultureInfo.InvariantCulture);
            stockHistoryWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            stockHistoryWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            stockHistoryWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            stockHistoryWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            stockHistoryWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            stockHistoryWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            stockHistoryWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            stockHistoryWork.LMonthStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LMONTHSTOCKCNTRF"));
            stockHistoryWork.LMonthStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LMONTHSTOCKPRICERF"));
            stockHistoryWork.LMonthPptyStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LMONTHPPTYSTOCKCNTRF"));
            stockHistoryWork.LMonthPptyStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LMONTHPPTYSTOCKPRICERF"));
            stockHistoryWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));
            stockHistoryWork.SalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
            stockHistoryWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
            stockHistoryWork.SalesRetGoodsTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESRETGOODSTIMESRF"));
            stockHistoryWork.SalesRetGoodsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRETGOODSCNTRF"));
            stockHistoryWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
            stockHistoryWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));
            stockHistoryWork.StockTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKTIMESRF"));
            stockHistoryWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            stockHistoryWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            stockHistoryWork.StockRetGoodsTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKRETGOODSTIMESRF"));
            stockHistoryWork.StockRetGoodsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRETGOODSCNTRF"));
            stockHistoryWork.StockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKRETGOODSPRICERF"));
            stockHistoryWork.MoveArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVEARRIVALCNTRF"));
            stockHistoryWork.MoveArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVEARRIVALPRICERF"));
            stockHistoryWork.MoveShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVESHIPMENTCNTRF"));
            stockHistoryWork.MoveShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVESHIPMENTPRICERF"));
            stockHistoryWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
            stockHistoryWork.AdjustPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ADJUSTPRICERF"));
            stockHistoryWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            stockHistoryWork.ArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ARRIVALPRICERF"));
            stockHistoryWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            stockHistoryWork.ShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SHIPMENTPRICERF"));
            stockHistoryWork.TotalArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALARRIVALCNTRF"));
            stockHistoryWork.TotalArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALARRIVALPRICERF"));
            stockHistoryWork.TotalShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSHIPMENTCNTRF"));
            stockHistoryWork.TotalShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALSHIPMENTPRICERF"));
            stockHistoryWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            stockHistoryWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));
            stockHistoryWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMASHINEPRICERF"));
            stockHistoryWork.PropertyStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PROPERTYSTOCKCNTRF"));
            stockHistoryWork.PropertyStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROPERTYSTOCKPRICERF"));

            return stockHistoryWork;
        }
        #endregion

        #region 検索結果の処理
        /// <summary>
        /// 月次集計モジュールから、在庫履歴データの取込
        /// </summary>
        /// <param name="stockHistoryWorkList">月次集計モジュール</param>
        /// <param name="goodsMakerCd">メーカー</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="warehouseCode">倉庫</param>
        /// <returns>StockHistoryWork</returns>
        /// <remarks>
        /// <br>Note       : 月次集計モジュールから、在庫履歴データの取込を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private StockHistoryWork GetStockHistoryWork(List<StockHistoryWork> stockHistoryWorkList, string warehouseCode, string goodsNo, int goodsMakerCd)
        {
            foreach (StockHistoryWork work in stockHistoryWorkList)
            {
                // キー項目は、倉庫、品番、メーカー
                if (warehouseCode == work.WarehouseCode
                    && goodsNo == work.GoodsNo
                    && goodsMakerCd == work.GoodsMakerCd)
                {
                    return work;
                }
            }
            return null;
        }

        /// <summary>
        /// 在庫履歴データListから、在庫履歴データの取込
        /// </summary>
        /// <param name="stockHistoryWorkArrList">在庫履歴データList</param>
        /// <param name="goodsMakerCd">メーカー</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="warehouseCode">倉庫</param>
        /// <returns>StockHistoryWork</returns>
        /// <remarks>
        /// <br>Note       : 在庫履歴データListから、在庫履歴データの取込を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private ArrayList FilterStockHistoryWorkList(ArrayList stockHistoryWorkArrList, string warehouseCode, string goodsNo, int goodsMakerCd)
        {
            ArrayList list = new ArrayList();

            for (int i = 0; i < stockHistoryWorkArrList.Count; i++)
            {
                StockHistoryWork work = stockHistoryWorkArrList[i] as StockHistoryWork;

                // キー項目は、倉庫、品番、メーカー
                if (warehouseCode == work.WarehouseCode
                    && goodsNo == work.GoodsNo
                    && goodsMakerCd == work.GoodsMakerCd)
                {
                    list.Add(work);
                }
            }

            return list;
        }
        #endregion

        #region 自社情報マスタの取込
        /// <summary>
        /// 自社情報マスタの取込
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>自社設定マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : 各自社設定マスタの取込を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private CompanyInfWork GetCompanyInformation(string enterpriseCode)
        {
            if (this._CompanyInfWork == null)
            {
                CompanyInfDB companyInfDB = new CompanyInfDB();

                CompanyInfWork companyInfWork = new CompanyInfWork();

                companyInfWork.EnterpriseCode = enterpriseCode;
                companyInfWork.CompanyCode = 0;

                byte[] paraByte = XmlByteSerializer.Serialize(companyInfWork);

                int status = companyInfDB.Read(ref paraByte, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._CompanyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(paraByte, typeof(CompanyInfWork));
                }
            }

            return this._CompanyInfWork;
        }
        #endregion

        #region 各金額項目の算出
        /// <summary>
        /// 各金額項目の算出
        /// </summary>
        /// <param name="stockHistoryWork">在庫履歴データワーク</param>
        /// <remarks>
        /// <br>Note       : 各金額項目の算出を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private void MoneyFracCalc(ref StockHistoryWork stockHistoryWork)
        {
            int FractionProcCd = 0;
            long calcPrice = 0;

            // 前月末在庫額
            this.FracCalc(stockHistoryWork.LMonthStockCnt * stockHistoryWork.StockUnitPriceFl, 1, FractionProcCd, out calcPrice);
            stockHistoryWork.LMonthStockPrice = calcPrice;
            // 前月末自社在庫金額
            this.FracCalc(stockHistoryWork.LMonthPptyStockCnt * stockHistoryWork.StockUnitPriceFl, 1, FractionProcCd, out calcPrice);
            stockHistoryWork.LMonthPptyStockPrice = calcPrice;
            // マシン在庫額
            this.FracCalc(stockHistoryWork.StockTotal * stockHistoryWork.StockUnitPriceFl, 1, FractionProcCd, out calcPrice);
            stockHistoryWork.StockMashinePrice = calcPrice;
            // 自社在庫金額
            this.FracCalc(stockHistoryWork.PropertyStockCnt * stockHistoryWork.StockUnitPriceFl, 1, FractionProcCd, out calcPrice);
            stockHistoryWork.PropertyStockPrice = calcPrice;
        }
        #endregion

        #region [FracCalc 消費税端数処理]
        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="inputNumerical">数値</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultNumerical">算出金額</param>
        /// <remarks>
        /// <br>Note       : 端数処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out Int64 resultNumerical)
        {
            // 初期値セット
            resultNumerical = (Int64)inputNumerical;

            inputNumerical = (double)((decimal)inputNumerical - ((decimal)inputNumerical % (decimal)0.000001));	// 小数点6桁以下切捨
            fractionUnit = (double)((decimal)fractionUnit - ((decimal)fractionUnit % (decimal)0.000001));		// 小数点6桁以下切捨

            // 端数単位で除算
            decimal tmpKin = (decimal)inputNumerical / (decimal)fractionUnit;

            // マイナス補正
            bool sign = false;
            if (tmpKin < 0)
            {
                sign = true;
                tmpKin = tmpKin * (-1);
            }

            // 小数部1桁取得
            decimal tmpDecimal = (tmpKin - (decimal)((long)tmpKin)) * 10;

            // tmpKin 端数指定
            bool wRoundFlg = true; // 切捨
            switch (fractionProcess)
            {
                //--------------------------------------
                // 1:切捨
                //--------------------------------------
                case 1:
                    {
                        wRoundFlg = true; // 切捨
                        break;
                    }
                //--------------------------------------
                // 2:四捨五入
                //--------------------------------------
                case 2: // 四捨五入
                    {
                        if (tmpDecimal >= 5)
                        {
                            wRoundFlg = false; // 切上
                        }
                        break;
                    }
                //--------------------------------------
                // 3:切上
                //--------------------------------------
                case 3: // 切上
                    {
                        if (tmpDecimal > 0)
                        {
                            wRoundFlg = false; // 切上
                        }
                        break;
                    }
            }

            // 端数処理
            if (wRoundFlg == false)
            {
                tmpKin = tmpKin + 1;
            }

            // 小数部切捨
            tmpKin = (decimal)(long)tmpKin;

            // マイナス補正
            if (sign == true)
            {
                tmpKin = tmpKin * (-1);
            }

            decimal a = tmpKin * (decimal)fractionUnit;

            // 算出値セット
            resultNumerical = (Int64)((decimal)tmpKin * (decimal)fractionUnit);

        }
        #endregion
    }
}
