using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 棚卸表示DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 棚卸表示の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.08</br>
    /// <br></br>
    /// <br>Update Note: 削除済み倉庫は抽出対象外に変更</br>
    /// <br>Date       : 23012 畠中　啓次朗</br>
    /// <br>           : 2008.12.02</br>
    /// <br>Update Note: 2011/03/22 曹文傑</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br>Update Note: 2012/02/24 30517 夏野 駿希</br>
    /// <br>             不具合対応：２レコード以降も正常に金額が表示される様に修正。</br>
    /// <br>Update Note: 2012/03/26 wangf </br>
    /// <br>             redmine#29109の対応</br>
    /// <br>Update Note: 2013/10/14 汪権来</br>
    /// <br>管理番号   : 10904597-00 </br>
    /// <br>           : Redmine#40178 　棚卸表示の原価計算の障害解除(№2115)</br>
    /// <br>Update Note: 2014/03/05 田建委</br>
    /// <br>           : Redmine#42247 印刷機能の追加</br>
    /// <br>Update Note: 2014/03/10 汪権来</br>
    /// <br>管理番号   : 10904597-00 </br>
    /// <br>           : Redmine#40178 　棚卸表示の原価計算の障害解除(№2115)の25</br>
    /// <br>Update Note: 2014/03/20 田建委</br>
    /// <br>管理番号   : 10904597-00 </br>
    /// <br>           : Redmine#40178 棚卸表示と棚卸表で棚卸金額に差異が生じる対応</br>
    /// <br>Update Note: 2014/05/13 田建委</br>
    /// <br>管理番号   : 11070071-00 </br>
    /// <br>           : Redmine#36564 棚卸表示の速度改善(#1989)</br>
    /// <br>Update Note: 2014/07/01 田建委</br>
    /// <br>管理番号   : 11070071-00 </br>
    /// <br>           : Redmine#42984 横浜商工(棚卸表示)の障害対応</br>
    /// <br>Update Note: 2015/03/13 caohh</br>
    /// <br>管理番号   : 11070149-00 </br>
    /// <br>           : Redmine#44951 棚卸表示の不具合(No.3)対応</br>
    /// <br>           : 原価計算の掛率グループのパラメータの設定を修正</br>
    /// <br>           : （グループコードマスタの商品中分類->BLコードマスタの商品中分類に変更）</br>
    /// <br>Update Note: 2020/06/17 梶谷 貴士</br>
    /// <br>管理番号   : 11670219-00 </br>
    /// <br>           : ＥＢＥ対策</br>
    /// <br>Update Note: 2020/10/20 譚洪</br>
    /// <br>管理番号   : 11675035-00</br>
    /// <br>             PMKOBETSU-3551 棚卸表示を実行すると処理に失敗する現象の解除</br>
    /// <br>Update Note: 2021/03/16 譚洪</br>
    /// <br>管理番号   : 11770024-00</br>
    /// <br>             PMKOBETSU-3551 棚卸表示の障害対応</br> 
    /// <br>           : ①GoodsUnitDataの企業コードが空の件</br>
    /// <br>           : ②掛率優先管理マスタの拠点指定が【全社共通】の場合、拠点分の掛率データを使用されてしまう件</br>
    /// <br>           : ③拠点分の単品設定の掛率データがあり、掛率優先管理マスタに[6A]が存在しない場合、拠点分の単品設定の掛率データを使用されてしまう件</br>
    /// </remarks>
    [Serializable]
    public class InventoryDtDspDB : RemoteDB, IInventoryDtDspDB
    {
        // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
        /// <summary>DICキーフォーマット</summary>
        private const string ctDicKeyFmt = "{0}-{1:D4}-{2}";
        /// <summary>全社</summary>
        private const string ctALLSection = "00";
        // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
        /// <summary>
        /// 棚卸表示DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.08</br>
        /// </remarks>
        public InventoryDtDspDB()
            :
            base("PMZAI04207D", "Broadleaf.Application.Remoting.ParamData.InventoryDataDspResultWork", "STOCKRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の棚卸表示データを戻します
        /// </summary>
        /// <param name="inventoryDataDspResultWork">検索結果</param>
        /// <param name="inventoryDataDspParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸表示データを戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.08</br>
        public int Search(out object inventoryDataDspResultWork, object inventoryDataDspParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            inventoryDataDspResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchInventoryDtDsp(out inventoryDataDspResultWork, inventoryDataDspParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryDtDspDB.Search");
                inventoryDataDspResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の棚卸表示データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objInventoryDataDspResultWork">検索結果</param>
        /// <param name="objInventoryDataDspParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸表示データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.08</br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        /// <br>Update Note: 2013/10/14 汪権来</br>
        /// <br>管理番号   : 10904597-00 </br>
        /// <br>           : Redmine#40178 　棚卸表示の原価計算の障害解除(№2115)</br>
        private int SearchInventoryDtDsp(out object objInventoryDataDspResultWork, object objInventoryDataDspParamWork, ref SqlConnection sqlConnection)
        {
            InventoryDataDspParamWork paramWork = null;

            ArrayList paramWorkList = objInventoryDataDspParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objInventoryDataDspParamWork as InventoryDataDspParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as InventoryDataDspParamWork;
            }

            ArrayList inventoryDataDspResultWork = null;

            // ---ADD 2011/03/22---------->>>>>
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paramWork.EnterpriseCode, "棚卸表示", "抽出開始");
            // ---ADD 2011/03/22----------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 棚卸表示データを取得
            //status = SearchInventoryDtDspProc(out inventoryDataDspResultWork, paramWork, ref sqlConnection);//DEL 汪権来 2013/10/14 for Redmine#40178
            // --- ADD 汪権来 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
            Dictionary<int, SupplierWork> supplierDic = new Dictionary<int, SupplierWork>(); ;    // 仕入先マスタ情報Dictionary
            SupplierDB _supplierDB = new SupplierDB();  // 仕入先マスタDBリモートオブジェクトクラスコンストラクタ
            ArrayList supplierList = new ArrayList();
            SupplierWork supplierWork = new SupplierWork();
            supplierWork.EnterpriseCode = paramWork.EnterpriseCode;  // 企業コード
            SqlTransaction sqlTrans = null;
            // 仕入先マスタ情報を取得する
            _supplierDB.Search(out supplierList, supplierWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTrans);　// 仕入先マスタ情報のリストを取得します
            // 仕入先マスタ情報Dictionaryを作成
            foreach (SupplierWork supplierwork in supplierList)
            {
                if (!supplierDic.ContainsKey(supplierwork.SupplierCd))
                {
                    supplierDic.Add(supplierwork.SupplierCd, supplierwork);
                }
            }
            status = SearchInventoryDtDspProc(out inventoryDataDspResultWork, paramWork, ref sqlConnection, supplierDic);
            // --- ADD 汪権来 2013/10/14 for Redmine#40178 -------<<<<<<<<<<< 

            // ---ADD 2011/03/22---------->>>>>
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paramWork.EnterpriseCode, "棚卸表示", "抽出終了");
            // ---ADD 2011/03/22----------<<<<<
            objInventoryDataDspResultWork = inventoryDataDspResultWork;
            return status;

        }
        #endregion  //Search

        #region [SearchInventoryDtDspProc]
        /// <summary>
        /// 指定された条件の棚卸表示データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="inventoryDataDspResultWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸表示データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.08</br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        /// <br>Update Note: 2013/10/14 汪権来</br>
        /// <br>管理番号   : 10904597-00 </br>
        /// <br>           : Redmine#40178 　棚卸表示の原価計算の障害解除(№2115)</br>
        /// <br>Update Note: 2014/03/05 田建委</br>
        /// <br>           : Redmine#42247 印刷機能の追加</br>
        /// <br>Update Note: 2014/03/10 汪権来</br>
        /// <br>管理番号   : 10904597-00 </br>
        /// <br>           : Redmine#40178 　棚卸表示の原価計算の障害解除(№2115)の25</br>
        /// <br>Update Note: 2014/03/20 田建委</br>
        /// <br>管理番号   : 10904597-00 </br>
        /// <br>           : Redmine#40178 棚卸表示と棚卸表で棚卸金額に差異が生じる対応</br>
        /// <br>Update Note: 2014/05/13 田建委</br>
        /// <br>管理番号   : 11070071-00 </br>
        /// <br>           : Redmine#36564 棚卸表示の速度改善(#1989)</br>
        /// <br>Update Note: 2014/07/01 田建委</br>
        /// <br>管理番号   : 11070071-00 </br>
        /// <br>           : Redmine#42984 横浜商工(棚卸表示)の障害No.98対応</br>
        /// <br>Update Note: 2015/03/12 caohh</br>
        /// <br>管理番号   : 11070149-00 </br>
        /// <br>           : Redmine#44951 棚卸表示の不具合(No.3)対応</br>
        /// <br>           : 原価計算の掛率グループのパラメータの設定を修正</br>
        /// <br>           : （グループコードマスタの商品中分類->BLコードマスタの商品中分類に変更）</br>
        /// <br>Update Note: 2020/06/17 梶谷 貴士</br>
        /// <br>管理番号   : 11670219-00 </br>
        /// <br>           : ＥＢＥ対策</br>
        /// <br>Update Note: 2020/10/20 譚洪</br>
        /// <br>管理番号   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551 棚卸表示を実行すると処理に失敗する現象の解除</br>
        /// <br>Update Note: 2021/03/16 譚洪</br>
        /// <br>管理番号   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 棚卸表示の障害対応</br>  
        //private int SearchInventoryDtDspProc(out ArrayList inventoryDataDspResultWorkList, InventoryDataDspParamWork paramWork, ref SqlConnection sqlConnection)//DEL 汪権来 2013/10/14 for Redmine#40178
        private int SearchInventoryDtDspProc(out ArrayList inventoryDataDspResultWorkList, InventoryDataDspParamWork paramWork, ref SqlConnection sqlConnection, Dictionary<int, SupplierWork> supplierDic)// ADD 汪権来 2013/10/14 for Redmine#40178
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            inventoryDataDspResultWorkList = new ArrayList();//ADD 田建委 2014/05/13 for Redmine#36564
            ArrayList al = new ArrayList();

            // 修正 2009/04/27 >>>
            //ArrayList ResultWorkList = new ArrayList();//DEL 田建委 2014/05/13 for Redmine#36564
            List<InventoryDataDspResultWork> ResultWorkList = null;//ADD 田建委 2014/05/13 for Redmine#36564

            // 仕入先取得用
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();

            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // 原価算出用
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            // --- DEL 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
            //List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // 原価計算パラメータオブジェクトリスト
            //List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // 商品連結データオブジェクトリスト
            // --- DEL 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<< 
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // 原価計算結果リスト 
            //----- ADD 2014/05/13 田建委 for Redmine#36564 ------->>>>>
            List<UnitPriceCalcParamWork> beUnitPriceCalcParamWorkList = new List<UnitPriceCalcParamWork>();
            List<GoodsUnitDataWork> beGoodsUnitDataWorkList = new List<GoodsUnitDataWork>();
            List<GoodsPriceUWork> beGoodsPriceUWorkList = new List<GoodsPriceUWork>();
            //----- ADD 2014/05/13 田建委 for Redmine#36564 -------<<<<<
            // 修正 2009/04/27 <<<
            List<string> warehouseCodeList = new List<string>();//ADD 汪権来 2013/10/14 for Redmine#40178
            string sqlText = string.Empty;
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();   // 単品掛率Dic// ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 
            // --- ADD START 梶谷 2020/06/17 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD END   梶谷 2020/06/17 ----------<<<<<

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                // 修正 2009/04/27 >>>
                #region DEL 2009/04/27
                /*
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                #region [SELECT]
                sqlCommand.CommandText = "SELECT" + Environment.NewLine;
                sqlCommand.CommandText += "	MAIN.ENTERPRISECODE AS ENTERPRISECODE " + Environment.NewLine;
                sqlCommand.CommandText += "	,MAIN.WAREHOUSECODE  AS WAREHOUSECODE" + Environment.NewLine;
                sqlCommand.CommandText += "	,WAREHOUSE.WAREHOUSENAMERF AS WAREHOUSENAME" + Environment.NewLine;
                sqlCommand.CommandText += "	,MAIN.GOODSCOUNT AS GOODSCOUNT" + Environment.NewLine;
                sqlCommand.CommandText += "	,MAIN.INVENTORYMONEY AS INVENTORYMONEY" + Environment.NewLine;
                sqlCommand.CommandText += "	,MAIN.MAXIMUMINVENTORYMONEY AS MAXIMUMINVENTORYMONEY" + Environment.NewLine;
                sqlCommand.CommandText += "FROM" + Environment.NewLine;
                sqlCommand.CommandText += "(" + Environment.NewLine;
                sqlCommand.CommandText += "	SELECT" + Environment.NewLine;
                sqlCommand.CommandText += "		ENTERPRISECODERF AS ENTERPRISECODE" + Environment.NewLine;
                sqlCommand.CommandText += "		,WAREHOUSECODERF AS WAREHOUSECODE" + Environment.NewLine;
                sqlCommand.CommandText += "		,COUNT(*) AS GOODSCOUNT" + Environment.NewLine;
                sqlCommand.CommandText += "		,SUM(SHIPMENTPOSCNTRF * STOCKUNITPRICEFLRF ) AS INVENTORYMONEY" + Environment.NewLine;
                sqlCommand.CommandText += "		,SUM(MAXIMUMSTOCKCNTRF * STOCKUNITPRICEFLRF) AS MAXIMUMINVENTORYMONEY" + Environment.NewLine;
                sqlCommand.CommandText += "	FROM" + Environment.NewLine;
                sqlCommand.CommandText += "		STOCKRF" + Environment.NewLine;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, paramWork);
                sqlCommand.CommandText += "	GROUP BY" + Environment.NewLine;
                sqlCommand.CommandText += "		ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += "		,WAREHOUSECODERF" + Environment.NewLine;
                sqlCommand.CommandText += ") AS MAIN " + Environment.NewLine;
                sqlCommand.CommandText += "LEFT JOIN " + Environment.NewLine;
                sqlCommand.CommandText += "	WAREHOUSERF AS WAREHOUSE " + Environment.NewLine;
                sqlCommand.CommandText += " ON " + Environment.NewLine;
                sqlCommand.CommandText += "	MAIN.ENTERPRISECODE = WAREHOUSE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += "	AND MAIN.WAREHOUSECODE = WAREHOUSE.WAREHOUSECODERF" + Environment.NewLine;
                // ADD 2008.12.02 >>>
                sqlCommand.CommandText += " WHERE" + Environment.NewLine;
                sqlCommand.CommandText += " WAREHOUSE.LOGICALDELETECODERF = 0" + Environment.NewLine;
                // ADD 2008.12.02 <<<

                #endregion
#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToInventoryDtDspWorkFromReader(ref myReader, paramWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                */
                #endregion

                #region SELECT文作成
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " STOCK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,STOCK.SECTIONCODERF -- 拠点コード" + Environment.NewLine;
                sqlText += " ,STOCK.WAREHOUSECODERF -- 倉庫コード" + Environment.NewLine;
                //sqlText += " ,WAREHOUSE.WAREHOUSENAMERF -- 倉庫名称_倉庫マスタ" + Environment.NewLine;// DEL 2014/03/05 田建委 Redmine#42247
                //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
                sqlText += " ,CASE WHEN WAREHOUSE.WAREHOUSECODERF IS NULL THEN '未登録' -- 倉庫名称_倉庫マスタ" + Environment.NewLine;
                sqlText += " WHEN WAREHOUSE.LOGICALDELETECODERF = 1 THEN '＊' + WAREHOUSE.WAREHOUSENAMERF ELSE WAREHOUSE.WAREHOUSENAMERF END WAREHOUSENAMERF -- 倉庫名称_倉庫マスタ" + Environment.NewLine;
                //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<
                sqlText += " ,STOCK.GOODSMAKERCDRF -- 商品メーカー" + Environment.NewLine;
                sqlText += " ,STOCK.GOODSNORF  -- 品番" + Environment.NewLine;
                //sqlText += " ,STOCK.SHIPMENTPOSCNTRF -- 出荷可能数" + Environment.NewLine;//DEL 汪権来 2014/03/10 for Redmine#40178の25
                //----ADD 汪権来 2014/03/10 for Redmine#40178の25 ------->>>>>>>>>>>
                sqlText += " ,STOCK.SUPPLIERSTOCKRF -- 仕入在庫数" + Environment.NewLine;
                sqlText += " ,STOCK.MOVINGSUPLISTOCKRF -- 移動中仕入在庫数" + Environment.NewLine;
                sqlText += " ,STOCK.SHIPMENTCNTRF -- 出荷数（未計上）" + Environment.NewLine;
                sqlText += " ,STOCK.ARRIVALCNTRF -- 入荷数（未計上）" + Environment.NewLine;
                //----ADD 汪権来 2014/03/10 for Redmine#40178の25 -------<<<<<<<<<<<
                sqlText += " ,STOCK.MAXIMUMSTOCKCNTRF -- 最高在庫数" + Environment.NewLine;
                sqlText += " ,STOCK.STOCKUNITPRICEFLRF -- 仕入単価 " + Environment.NewLine;
                sqlText += " ,GOODS.BLGOODSCODERF  -- BLコード_商品マスタ" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSRATERANKRF AS GOODSRATERANKRF" + Environment.NewLine;//ADD 汪権来 2013/10/14 for Redmine#40178
                sqlText += " ,BLGOODS.BLGROUPCODERF -- BLグループコード_BLコードマスタ" + Environment.NewLine;
                sqlText += " ,BLGOODS.GOODSRATEGRPCODERF -- 商品掛率グループコード_BLコードマスタ" + Environment.NewLine; // ADD caohh 2015/03/13 for Redmine#44951
                sqlText += " ,BLGROUP.GOODSMGROUPRF -- 商品中分類コード_BLグループコードマスタ" + Environment.NewLine;
                // --- ADD 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                sqlText += " ,GOODSPRICEURF.CREATEDATETIMERF AS GPRICEU_CREATEDATETIMERF,GOODSPRICEURF.UPDATEDATETIMERF AS GPRICEU_UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.ENTERPRISECODERF AS GPRICEU_ENTERPRISECODERF,GOODSPRICEURF.FILEHEADERGUIDRF AS GPRICEU_FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.UPDEMPLOYEECODERF AS GPRICEU_UPDEMPLOYEECODERF,GOODSPRICEURF.UPDASSEMBLYID1RF AS GPRICEU_UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.UPDASSEMBLYID2RF AS GPRICEU_UPDASSEMBLYID2RF,GOODSPRICEURF.LOGICALDELETECODERF AS GPRICEU_LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.GOODSMAKERCDRF AS GPRICEU_GOODSMAKERCDRF,GOODSPRICEURF.GOODSNORF AS GPRICEU_GOODSNORF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.PRICESTARTDATERF AS GPRICEU_PRICESTARTDATERF,GOODSPRICEURF.LISTPRICERF AS GPRICEU_LISTPRICERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.SALESUNITCOSTRF AS GPRICEU_SALESUNITCOSTRF,GOODSPRICEURF.STOCKRATERF AS GPRICEU_STOCKRATERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.OPENPRICEDIVRF AS GPRICEU_OPENPRICEDIVRF,GOODSPRICEURF.OFFERDATERF AS GPRICEU_OFFERDATERF" + Environment.NewLine;
                sqlText += " ,GOODSPRICEURF.UPDATEDATERF AS GPRICEU_UPDATEDATERF " + Environment.NewLine;
                // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------>>>>>
                sqlText += " ,RATE.PRICEFLRF AS RATE_PRICEFLRF " + Environment.NewLine;
                sqlText += " ,RATE.RATEVALRF AS RATE_RATEVALRF " + Environment.NewLine;
                // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                sqlText += " ,RATE.UNPRCFRACPROCUNITRF AS RATE_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                sqlText += " ,RATE.UNPRCFRACPROCDIVRF AS RATE_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                sqlText += " ,RATE.RATESETTINGDIVIDERF AS RATE_RATESETTINGDIVIDERF " + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGGOODSCDRF AS RATE_RATEMNGGOODSCDRF " + Environment.NewLine;
                sqlText += " ,RATE.RATEMNGCUSTCDRF AS RATE_RATEMNGCUSTCDRF " + Environment.NewLine;
                sqlText += " ,RATE.SECTIONCODERF AS RATE_SECTIONCODERF " + Environment.NewLine;
                sqlText += " ,RATE.LOTCOUNTRF AS RATE_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                sqlText += " ,RATE2.PRICEFLRF AS RATE2_PRICEFLRF " + Environment.NewLine;
                sqlText += " ,RATE2.RATEVALRF AS RATE2_RATEVALRF " + Environment.NewLine;
                sqlText += " ,RATE2.UNPRCFRACPROCUNITRF AS RATE2_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                sqlText += " ,RATE2.UNPRCFRACPROCDIVRF AS RATE2_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                sqlText += " ,RATE2.RATESETTINGDIVIDERF AS RATE2_RATESETTINGDIVIDERF " + Environment.NewLine;
                sqlText += " ,RATE2.RATEMNGGOODSCDRF AS RATE2_RATEMNGGOODSCDRF " + Environment.NewLine;
                sqlText += " ,RATE2.RATEMNGCUSTCDRF AS RATE2_RATEMNGCUSTCDRF " + Environment.NewLine;
                sqlText += " ,RATE2.SECTIONCODERF AS RATE2_SECTIONCODERF " + Environment.NewLine;
                sqlText += " ,RATE2.LOTCOUNTRF AS RATE2_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------<<<<<
                // --- ADD 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                sqlText += "FROM" + Environment.NewLine;
                //sqlText += " STOCKRF AS STOCK" + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += " STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " -- 商品" + Environment.NewLine;
                //sqlText += "INNER JOIN GOODSURF AS GOODS" + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += "INNER JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " ON STOCK.ENTERPRISECODERF = GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSNORF = GOODS.GOODSNORF" + Environment.NewLine;
                sqlText += "-- BLコード " + Environment.NewLine;
                //sqlText += "LEFT JOIN BLGOODSCDURF AS BLGOODS" + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += "LEFT JOIN BLGOODSCDURF AS BLGOODS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " ON STOCK.ENTERPRISECODERF = BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GOODS.BLGOODSCODERF = BLGOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "-- BLグループ" + Environment.NewLine;
                //sqlText += "LEFT JOIN BLGROUPURF AS BLGROUP" + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += "LEFT JOIN BLGROUPURF AS BLGROUP WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " ON STOCK.ENTERPRISECODERF = BLGROUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND BLGOODS.BLGROUPCODERF = BLGROUP.BLGROUPCODERF" + Environment.NewLine;
                sqlText += "-- 倉庫マスタ" + Environment.NewLine;
                //sqlText += "LEFT JOIN WAREHOUSERF AS WAREHOUSE " + Environment.NewLine; // DEL wangf 2012/03/26 FOR Redmine#29109
                sqlText += "LEFT JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/26 FOR Redmine#29109
                sqlText += " ON STOCK.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND STOCK.WAREHOUSECODERF = WAREHOUSE.WAREHOUSECODERF" + Environment.NewLine;
                // ---  ADD 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                sqlText += " LEFT JOIN GOODSPRICEURF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += " ON GOODSPRICEURF.ENTERPRISECODERF = STOCK.ENTERPRISECODERF AND GOODSPRICEURF.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                // ---  ADD 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<< 
                // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------>>>>>
                sqlText += " LEFT JOIN RATERF AS RATE WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += " ON STOCK.ENTERPRISECODERF = RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND STOCK.SECTIONCODERF = RATE.SECTIONCODERF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSNORF = RATE.GOODSNORF" + Environment.NewLine;
                sqlText += " AND STOCK.LOGICALDELETECODERF = RATE.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " AND RATE.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlText += " AND RATE.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlText += " AND RATE.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlText += " AND RATE.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlText += " AND RATE.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlText += " AND RATE.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlText += " AND RATE.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlText += " AND RATE.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlText += " AND RATE.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                sqlText += " LEFT JOIN RATERF AS RATE2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += " ON STOCK.ENTERPRISECODERF = RATE2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND RATE2.SECTIONCODERF = '00'" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSMAKERCDRF = RATE2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND STOCK.GOODSNORF = RATE2.GOODSNORF" + Environment.NewLine;
                sqlText += " AND STOCK.LOGICALDELETECODERF = RATE2.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " AND RATE2.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlText += " AND RATE2.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlText += " AND RATE2.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlText += " AND RATE2.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlText += " AND RATE2.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlText += " AND RATE2.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlText += " AND RATE2.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlText += " AND RATE2.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlText += " AND RATE2.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------<<<<<
                #endregion

                sqlText += MakeWhereString(ref sqlCommand, paramWork);

                //sqlText += " ORDER BY STOCK.WAREHOUSECODERF" + Environment.NewLine;//DEL 田建委 2014/05/13 for Redmine#36564
                sqlText += " ORDER BY STOCK.SECTIONCODERF ASC, STOCK.WAREHOUSECODERF ASC, STOCK.GOODSMAKERCDRF ASC, STOCK.GOODSNORF ASC, GOODSPRICEURF.PRICESTARTDATERF DESC";// ADD 田建委 2014/05/13 for Redmine#36564

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 3600;// ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応
                myReader = sqlCommand.ExecuteReader();
                // --- ADD 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                InventoryDataDspResultWork beInventoryDataWork = null;
                GoodsSupplierDataWork beGoodsSupplierDataWork = null;
                UnitPriceCalcParamWork beUnitPriceCalcParamWork = null;
                GoodsUnitDataWork beGoodsUnitDataWork = null;
                GoodsPriceUWork beGoodsPriceUWork = null;

                GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
                string enterpriseCode = "";
                DateTime priceStartDate = DateTime.MinValue;
                //仕入金額処理区分マスタ読み込み
                List<StockProcMoneyWork> stockProcMoneyList = new List<StockProcMoneyWork>();
                unitPriceCalculation.SearchStockProcMoneyForInventory(paramWork.EnterpriseCode, out stockProcMoneyList);

                // 消費税の端数処理単位、端数処理区分を取得
                double taxFractionProcUnit;
                int taxFractionProcCd;
                this.GetStockFractionProcInfo(1, 0, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);
                List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
                unitPriceCalculation.SearchRateProtyMngForInventory(paramWork.EnterpriseCode, out rateProtyMngAllList);

                ArrayList secList = new ArrayList();
                ArrayList list = new ArrayList();
                ArrayList arrList = new ArrayList(); // ADD 田建委 2014/07/01 for Redmine#42984
                // --- ADD 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                //----ADD 汪権来 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
                Dictionary<string, GoodsMngWork> goodsMngDic1 = null;     //拠点＋メーカー＋品番
                Dictionary<string, GoodsMngWork> goodsMngDic2 = null;     //拠点＋中分類＋メーカー＋ＢＬ
                Dictionary<string, GoodsMngWork> goodsMngDic3 = null;     //拠点＋中分類＋メーカー
                Dictionary<string, GoodsMngWork> goodsMngDic4 = null;     //拠点＋メーカー

                goodsSupplierGetter.GetGoodsMngInfo(paramWork.EnterpriseCode, ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4);
                // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------>>>>>
                string sectionCode = string.Empty;
                //int goodsMakerCd = 0;// DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応
                //string goodsNo = string.Empty;// DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応
                string keyValue = string.Empty;
                RateWork rateAllSec = null;
                // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------<<<<<
                //----ADD 汪権来 2013/10/14 for Redmine#40178 -------<<<<<<<<<<<
                while (myReader.Read())
                {
                    //al.Add(CopyToInventoryDtDspWorkFromReader(ref myReader, paramWork));//DEL 田建委 2014/05/13 for Redmine#36564
                    // --- ADD 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                    InventoryDataDspResultWork wkInventoryDataWork = new InventoryDataDspResultWork();
                    wkInventoryDataWork = CopyToInventoryDtDspWorkFromReader(ref myReader, paramWork);
                    // --- ADD 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                    UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                    GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // 商品連結データオブジェクトリスト
                    goodsPriceUWork = new GoodsPriceUWork();      //ADD 田建委 2014/05/13 for Redmine#36564

                    #region 商品仕入取得データクラス
                    goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); //企業コード
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
                    //----- ADD 2014/05/13 田建委 for Redmine#36564 ------->>>>>
                    if (!secList.Contains(goodsSupplierDataWork.SectionCode))
                    {
                        secList.Add(goodsSupplierDataWork.SectionCode);
                    }
                    //----- ADD 2014/05/13 田建委 for Redmine#36564 -------<<<<<
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // 商品メーカー
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          // 商品番号
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));   // BL商品コード
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));   // 商品中分類
                    //GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);//DEL 田建委 2014/05/13 for Redmine#36564
                    #endregion

                    //----ADD 汪権来 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
                    goodsMngDic1 = goodsMngDic1 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic1;
                    goodsMngDic2 = goodsMngDic2 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic2;
                    goodsMngDic3 = goodsMngDic3 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic3;
                    goodsMngDic4 = goodsMngDic4 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic4;
                    goodsSupplierGetter.GetSupplierInfo(ref goodsSupplierDataWork, goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4);
                    //----ADD 汪権来 2013/10/14 for Redmine#40178 -------<<<<<<<<<<<

                    #region 単価算出モジュール計算用パラメータ
                    if (SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF")) == 0) // 在庫マスタ・仕入単価が0のレコードのみを対象とする
                    {
                        //unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); //企業コード DEL 汪権来 2013/09/16 for Redmine#40178
                        unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); //拠点コード ADD 汪権来 2013/09/16 for Redmine#40178
                        unitPriceCalcParam.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // 商品メーカー
                        unitPriceCalcParam.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          // 商品番号
                        //unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));   // 商品中分類 // DEL caohh 2015/03/13 for Redmine#44951
                        unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));// 商品掛率グループコード// ADD caohh 2015/03/13 for Redmine#44951
                        unitPriceCalcParam.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));   // BLグループコード
                        unitPriceCalcParam.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));   // BL商品コード
                        unitPriceCalcParam.PriceApplyDate = DateTime.Now;
                        //----ADD 汪権来 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
                        unitPriceCalcParam.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));  // 層別　
                        warehouseCodeList.Add(SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF")));
                        unitPriceCalcParam.SupplierCd = goodsSupplierDataWork.SupplierCd;
                        if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParam.SupplierCd))
                        {
                            unitPriceCalcParam.StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParam.SupplierCd].StockUnPrcFrcProcCd;
                        }
                        //----ADD 汪権来 2013/10/14 for Redmine#40178 -------<<<<<<<<<<<
                        //unitPriceCalcParamList.Add(unitPriceCalcParam);//DEL 田建委 2014/05/13 for Redmine#36564
                    }
                    #endregion

                    #region 商品連結データリスト
                    if (SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF")) == 0)// 在庫マスタ・仕入単価が0のレコードのみを対象とする
                    {
                        goodsUnitData.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); //企業コード
                        goodsUnitData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          // 商品番号
                        goodsUnitData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // 商品メーカー
                        //goodsUnitDataList.Add(goodsUnitData);//DEL 田建委 2014/05/13 for Redmine#36564
                    }
                    #endregion

                    // --- ADD 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                    enterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_ENTERPRISECODERF"));
                    if (enterpriseCode != null && enterpriseCode != "")
                    {
                        priceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_PRICESTARTDATERF"));
                        if (priceStartDate < DateTime.Now)
                        {
                            if (priceStartDate > goodsPriceUWork.PriceStartDate)
                            {
                                goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GPRICEU_CREATEDATETIMERF"));
                                goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GPRICEU_UPDATEDATETIMERF"));
                                goodsPriceUWork.EnterpriseCode = enterpriseCode;
                                goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("GPRICEU_FILEHEADERGUIDRF"));
                                goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDEMPLOYEECODERF"));
                                goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDASSEMBLYID1RF"));
                                goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDASSEMBLYID2RF"));
                                goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_LOGICALDELETECODERF"));
                                goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_GOODSMAKERCDRF"));
                                goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_GOODSNORF"));
                                goodsPriceUWork.PriceStartDate = priceStartDate;

                                // --- UPD START 梶谷 2020/06/17 ---------->>>>>
                                //goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));
                                convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
                                convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
                                convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
                                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));

                                // 変換処理実行
                                convertDoubleRelease.ReleaseProc();

                                goodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                                // --- UPD END   梶谷 2020/06/17 ----------<<<<<

                                goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_SALESUNITCOSTRF"));
                                goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_STOCKRATERF"));
                                goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_OPENPRICEDIVRF"));
                                goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_OFFERDATERF"));
                                goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_UPDATEDATERF"));
                            }
                        }
                        // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------>>>>>
                        // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                        //// 当商品の価格未設定の場合、単品掛率の価格、仕入率をセットする
                        ////if ((goodsPriceUWork.SalesUnitCost == 0) && ((goodsPriceUWork.StockRate == 0 || goodsPriceUWork.ListPrice == 0)))
                        //{
                        //    goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                        //    if (goodsPriceUWork.LogicalDeleteCode == 0)
                        //    {
                        //        goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                        //    }
                        //}
                        // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<

                        #region 単品掛率リスト

                        // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                        //拠点分単品掛率
                        keyValue = string.Format(ctDicKeyFmt, wkInventoryDataWork.SectionCode.Trim(), wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_SECTIONCODERF"));
                        //当商品の拠点分単品がある場合、単品dicに追加
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<

                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                        //goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));     // メーカーコード
                        //goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));           // 商品番号
                        //keyValue = "00" + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        keyValue = string.Format(ctDicKeyFmt, ctALLSection, wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_SECTIONCODERF"));
                        //全社単品がある場合、単品dicに追加
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_LOTCOUNTRF"));

                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        #endregion
                        // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------<<<<<
                    }

                    if (beInventoryDataWork != null)
                    {
                        if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                            && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                            && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                            && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                            && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                            && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode)
                        {
                            if (goodsPriceUWork.EnterpriseCode != "")
                            {
                                if (beGoodsPriceUWork == null || goodsPriceUWork.PriceStartDate > beGoodsPriceUWork.PriceStartDate)
                                {
                                    beGoodsPriceUWork = goodsPriceUWork;
                                }

                            }

                            // 1レコード前と同じだった場合
                            continue; // 次へ 
                        }
                    }
                    else
                    {
                        // BeforeData
                        beInventoryDataWork = wkInventoryDataWork;
                        beGoodsSupplierDataWork = goodsSupplierDataWork;
                        beUnitPriceCalcParamWork = unitPriceCalcParam;
                        beGoodsUnitDataWork = goodsUnitData;
                        beGoodsPriceUWork = goodsPriceUWork;
                        //ArrayList arrList = new ArrayList(); // DEL 田建委 2014/07/01 for Redmine#42984
                        arrList = new ArrayList(); // ADD 田建委 2014/07/01 for Redmine#42984
                        if (!arrList.Contains(beGoodsPriceUWork))
                        {
                            arrList.Add(beGoodsPriceUWork);
                            beGoodsUnitDataWork.PriceList = arrList;
                        }
                        continue;
                    }

                    // 1レコード前と変わった場合、BeforeDataをリストに追加
                    al.Add(beInventoryDataWork);
                    GoodsSupplierDataWorkList.Add(beGoodsSupplierDataWork);

                    beUnitPriceCalcParamWorkList.Add(beUnitPriceCalcParamWork);
                    beGoodsUnitDataWorkList.Add(beGoodsUnitDataWork);
                    beGoodsPriceUWorkList.Add(beGoodsPriceUWork);
                    //----- ADD 田建委 2014/07/01 for Redmine#42984 ----->>>>>
                    arrList = new ArrayList();
                    if (!arrList.Contains(beGoodsPriceUWork))
                    {
                        arrList.Add(beGoodsPriceUWork);
                        beGoodsUnitDataWork.PriceList = arrList;
                    }
                    //----- ADD 田建委 2014/07/01 for Redmine#42984 -----<<<<<

                    // 現在のレコードをBeforeDataにセット
                    beInventoryDataWork = wkInventoryDataWork;
                    beGoodsSupplierDataWork = goodsSupplierDataWork;
                    beUnitPriceCalcParamWork = unitPriceCalcParam;
                    beGoodsUnitDataWork = goodsUnitData;
                    if (goodsPriceUWork.EnterpriseCode != "")
                    {
                        beGoodsPriceUWork = goodsPriceUWork;
                        //----- DEL 田建委 2014/07/01 for Redmine#42984 ----->>>>>
                        //ArrayList arrList = new ArrayList();
                        //if (!arrList.Contains(beGoodsPriceUWork))
                        //{
                        //    arrList.Add(beGoodsPriceUWork);
                        //    beGoodsUnitDataWork.PriceList = arrList;
                        //}
                        //----- DEL 田建委 2014/07/01 for Redmine#42984 -----<<<<<
                    }
                    else
                    {
                        beGoodsPriceUWork = null;
                    }
                    // --- ADD 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                }

                // --- ADD 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                // 最後のBeforeDataをリストに追加する
                if (beInventoryDataWork != null)
                {
                    al.Add(beInventoryDataWork);
                    GoodsSupplierDataWorkList.Add(beGoodsSupplierDataWork);

                    beUnitPriceCalcParamWorkList.Add(beUnitPriceCalcParamWork);
                    beGoodsUnitDataWorkList.Add(beGoodsUnitDataWork);
                    beGoodsPriceUWorkList.Add(beGoodsPriceUWork);

                    //----- ADD 田建委 2014/07/01 for Redmine#42984 ----->>>>>
                    arrList = new ArrayList();
                    if (!arrList.Contains(beGoodsPriceUWork))
                    {
                        arrList.Add(beGoodsPriceUWork);
                        beGoodsUnitDataWork.PriceList = arrList;
                    }
                    //----- ADD 田建委 2014/07/01 for Redmine#42984 -----<<<<<
                }
                // --- ADD 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<

                // ---ADD 2011/03/22---------->>>>>
                if (GoodsSupplierDataWorkList.Count == 0)
                {
                    inventoryDataDspResultWorkList = new ArrayList();
                    return status;
                }
                // ---ADD 2011/03/22----------<<<<<

                //----- ADD 2014/05/13 田建委 for Redmine#36564 ------->>>>>
                List<RateWork> rateList;
                List<UnitPriceCalculation.UnitPriceKind> unitPriceKindList = new List<UnitPriceCalculation.UnitPriceKind>();
                unitPriceKindList.Add(UnitPriceCalculation.UnitPriceKind.UnitCost);
                // --- UPD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------>>>>>
                //unitPriceCalculation.SearchRateForInventoryDis(paramWork.EnterpriseCode, secList, out rateList);
                unitPriceCalculation.SearchRateForInventoryDis2(paramWork.EnterpriseCode, secList, out rateList);
                // --- UPD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------<<<<<

                for (int i = 0; i < beUnitPriceCalcParamWorkList.Count; i++)
                {
                    // --- UPD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------>>>>>
                    //unitPriceCalculation.CalculateUnitCostPrice(ref unitPriceCalcRetList, beGoodsPriceUWorkList[i], taxFractionProcUnit, taxFractionProcCd
                    //               , beUnitPriceCalcParamWorkList[i], stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWorkList[i], rateList);
                    unitPriceCalculation.CalculateUnitCostPrice2(ref unitPriceCalcRetList, beGoodsPriceUWorkList[i], taxFractionProcUnit, taxFractionProcCd
                                   , beUnitPriceCalcParamWorkList[i], stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWorkList[i], rateList, rateWorkByGoodsNoDic);
                    // --- UPD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------<<<<<
                }
                //----- ADD 2014/05/13 田建委 for Redmine#36564 -------<<<<<

                #region 仕入単価取得処理
                //----DEL 汪権来 2013/10/14 for Redmine#40178 ------->>>>>>>>>>>
                //// 商品仕入先情報取得処理 実行
                //goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                //// 商品仕入先情報取得処理により取得した仕入先を
                //// 単価算出パラメータにセット
                //for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // 商品仕入取得データクラス
                //{
                //    for (int j = 0; j < unitPriceCalcParamList.Count; j++) // 単価算出モジュール計算用パラメータ
                //    {
                //        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // 商品メーカー
                //            (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // 商品番号
                //            (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL商品コード
                //        {
                //            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                //            {
                //                unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                //            }
                //        }
                //    }
                //}
                //----DEL 汪権来 2013/10/14 for Redmine#40178 -------<<<<<<<<<<<
                // --- DEL 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                /*//原価算出処理 実行
                unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

                // 原価算出処理により取得した原価を
                // 棚卸表示データクラスにセット
                for (int i = 0; i < unitPriceCalcRetList.Count; i++) // 単価計算結果
                {
                    for (int j = 0; j < al.Count; j++) // 棚卸表示データクラス
                    {
                        if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataDspResultWork)al[j]).GoodsMakerCd) && // 商品メーカー
                            (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataDspResultWork)al[j]).GoodsNo) &&           // BL商品コード
                            (warehouseCodeList[i] == ((InventoryDataDspResultWork)al[j]).WarehouseCode) &&           //倉庫コード ADD 汪権来 2013/10/14 for Redmine#40178
                            (((InventoryDataDspResultWork)al[j]).StockUnitPriceFl == 0))
                        {
                            // 仕入単価
                            ((InventoryDataDspResultWork)al[j]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        }
                    }
                }*/
                // --- DEL 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                // --- ADD 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
                // 原価算出処理により取得した原価を
                // 棚卸表示データクラスにセット
                for (int i = 0; i < unitPriceCalcRetList.Count; i++) // 単価計算結果
                {

                    if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataDspResultWork)al[i]).GoodsMakerCd) && // 商品メーカー
                        (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataDspResultWork)al[i]).GoodsNo) &&           // BL商品コード
                        (((InventoryDataDspResultWork)al[i]).StockUnitPriceFl == 0))
                    {
                        // 仕入単価
                        ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                    }
                }
                // --- ADD 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
                #endregion

                #region 金額計算処理
                InventoryDataDspResultWork ResultWork = new InventoryDataDspResultWork();
                ResultWorkList = new List<InventoryDataDspResultWork>();//ADD 田建委 2014/05/13 for Redmine#36564
                int UpFlg = 0;

                for (int i = 0; i < al.Count; i++)
                {
                    UpFlg = 0;
                    ResultWork = new InventoryDataDspResultWork();
                    if (ResultWorkList.Count == 0)
                    {
                        ResultWork.EnterpriseCode = ((InventoryDataDspResultWork)al[i]).EnterpriseCode; // 企業コード
                        ResultWork.WarehouseCode = ((InventoryDataDspResultWork)al[i]).WarehouseCode; // 倉庫コード
                        ResultWork.WarehouseName = ((InventoryDataDspResultWork)al[i]).WarehouseName; // 倉庫名称
                        ResultWork.InventoryItemCnt = 1; // ｱｲﾃﾑ数
                        //----DEL 汪権来 2014/03/10 for Redmine#40178の25 ------->>>>>>>>>>>
                        //// 棚卸金額 = 出荷可能数 × 仕入単価
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).ShipmentPosCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl;
                        //----DEL 汪権来 2014/03/10 for Redmine#40178の25 -------<<<<<<<<<<<
                        //----ADD 汪権来 2014/03/10 for Redmine#40178の25 ------->>>>>>>>>>>
                        // 棚卸金額 = 在庫数 × 仕入単価
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 田建委 Redmine#40178
                        ResultWork.InventoryMoney = Math.Floor(((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 田建委 Redmine#40178
                        //----ADD 汪権来 2014/03/10 for Redmine#40178の25 -------<<<<<<<<<<<

                        // 最高棚卸金額 = 最高在庫数 × 仕入単価
                        //ResultWork.MaximumInventoryMoney = ((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 田建委 Redmine#40178
                        ResultWork.MaximumInventoryMoney = Math.Floor(((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 田建委 Redmine#40178

                        ResultWorkList.Add(ResultWork);
                        continue;
                    }

                    for (int j = 0; j < ResultWorkList.Count; j++)
                    {
                        if (((InventoryDataDspResultWork)ResultWorkList[j]).WarehouseCode.Trim() == ((InventoryDataDspResultWork)al[i]).WarehouseCode.Trim())
                        {
                            UpFlg = 1;
                            //----DEL 汪権来 2014/03/10 for Redmine#40178の25 ------->>>>>>>>>>>
                            //// 棚卸金額 += 出荷可能数 × 仕入単価
                            //((InventoryDataDspResultWork)ResultWorkList[j]).InventoryMoney += ((InventoryDataDspResultWork)al[i]).ShipmentPosCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl;
                            //----DEL 汪権来 2014/03/10 for Redmine#40178の25 -------<<<<<<<<<<<
                            //----ADD 汪権来 2014/03/10 for Redmine#40178の25 ------->>>>>>>>>>>
                            // 棚卸金額 += 在庫数 × 仕入単価
                            //((InventoryDataDspResultWork)ResultWorkList[j]).InventoryMoney += ((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 田建委 Redmine#40178
                            ((InventoryDataDspResultWork)ResultWorkList[j]).InventoryMoney += Math.Floor(((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 田建委 Redmine#40178
                            //----ADD 汪権来 2014/03/10 for Redmine#40178の25 -------<<<<<<<<<<<
                            // 最高棚卸金額 = 最高在庫数 × 仕入単価
                            //((InventoryDataDspResultWork)ResultWorkList[j]).MaximumInventoryMoney += ((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 田建委 Redmine#40178
                            ((InventoryDataDspResultWork)ResultWorkList[j]).MaximumInventoryMoney += Math.Floor(((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 田建委 Redmine#40178
                            // ｱｲﾃﾑ数
                            ((InventoryDataDspResultWork)ResultWorkList[j]).InventoryItemCnt += 1;
                            break;
                        }
                    }
                    if (UpFlg == 0)
                    {
                        ResultWork.EnterpriseCode = ((InventoryDataDspResultWork)al[i]).EnterpriseCode; // 企業コード
                        ResultWork.WarehouseCode = ((InventoryDataDspResultWork)al[i]).WarehouseCode; // 倉庫コード
                        ResultWork.WarehouseName = ((InventoryDataDspResultWork)al[i]).WarehouseName; // 倉庫名称
                        ResultWork.InventoryItemCnt = 1; // ｱｲﾃﾑ数
                        //----DEL 汪権来 2014/03/10 for Redmine#40178の25 ------->>>>>>>>>>>
                        //// 棚卸金額 = 出荷可能数 × 仕入単価
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).ShipmentPosCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl;
                        //----DEL 汪権来 2014/03/10 for Redmine#40178の25 -------<<<<<<<<<<<
                        //----ADD 汪権来 2014/03/10 for Redmine#40178の25 ------->>>>>>>>>>>
                        // 棚卸金額 = 在庫数 × 仕入単価
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 田建委 Redmine#40178
                        ResultWork.InventoryMoney = Math.Floor(((InventoryDataDspResultWork)al[i]).StockTotal * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 田建委 Redmine#40178
                        //----ADD 汪権来 2014/03/10 for Redmine#40178の25 -------<<<<<<<<<<<
                        // 最高棚卸金額 = 最高在庫数 × 仕入単価
                        // 2012/02/24 >>>
                        //ResultWork.InventoryMoney = ((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl;
                        //ResultWork.MaximumInventoryMoney = ((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl; // DEL 2014/03/20 田建委 Redmine#40178
                        ResultWork.MaximumInventoryMoney = Math.Floor(((InventoryDataDspResultWork)al[i]).MaximumStockCnt * ((InventoryDataDspResultWork)al[i]).StockUnitPriceFl + 0.5); // ADD 2014/03/20 田建委 Redmine#40178
                        // 2012/02/24 <<<
                        ResultWorkList.Add(ResultWork);
                    }
                }

                #endregion
                // 修正 2009/04/27 <<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                // --- ADD START 梶谷 2020/06/17 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                // --- ADD END   梶谷 2020/06/17 ----------<<<<<
            }
            // --- ADD 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
            ResultWorkList.Sort(
                delegate(InventoryDataDspResultWork a, InventoryDataDspResultWork b)
                {
                    return
                        a.WarehouseCode.CompareTo(b.WarehouseCode);
                });
            Array array = ResultWorkList.ToArray();
            inventoryDataDspResultWorkList = new ArrayList(array);
            // --- ADD 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
            // 修正 2009/04/27 >>>
            //inventoryDataDspResultWorkList = al;
            //inventoryDataDspResultWorkList = ResultWorkList;//DEL 田建委 2014/05/13 for Redmine#36564
            // 修正 2009/04/27 <<<
            return status;
        }
        #endregion  //SearchInventoryDtDspProc

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="inventoryDataDspParamWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.08</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, InventoryDataDspParamWork inventoryDataDspParamWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            // 企業コード設定
            retString.Append("STOCK.ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.EnterpriseCode);

            //論理削除区分
            retString.Append("AND STOCK.LOGICALDELETECODERF=0 ");

            if (inventoryDataDspParamWork.WarehouseDiv == 0) // 0:範囲,1:単独
            {
                //倉庫コード設定
                if (inventoryDataDspParamWork.StWarehouseCode != "")
                {
                    retString.Append(" AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine);
                    SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                    paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.StWarehouseCode);
                }
                if (inventoryDataDspParamWork.EdWarehouseCode != "")
                {
                    retString.Append(" AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE " + Environment.NewLine);
                    SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                    paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.EdWarehouseCode + "%");
                }
            }
            else
            {
                if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                    inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                    inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                    inventoryDataDspParamWork.WarehouseCd07 != "" || inventoryDataDspParamWork.WarehouseCd08 != "" ||
                    inventoryDataDspParamWork.WarehouseCd09 != "" || inventoryDataDspParamWork.WarehouseCd10 != "") 
                {
                    retString.Append(" AND ( ");
                }

                //倉庫コード01設定
                if (inventoryDataDspParamWork.WarehouseCd01 != "")
                {
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD01" + Environment.NewLine);
                    SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                    paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd01);
                }

                //倉庫コード02設定
                if (inventoryDataDspParamWork.WarehouseCd02 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "") 
                    {
                        retString.Append(" OR");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD02" + Environment.NewLine);
                    SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                    paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd02);
                }

                //倉庫コード03設定
                if (inventoryDataDspParamWork.WarehouseCd03 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD03" + Environment.NewLine);
                    SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                    paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd03);
                }

                //倉庫コード04設定
                if (inventoryDataDspParamWork.WarehouseCd04 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD04" + Environment.NewLine);
                    SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                    paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd04);
                }

                //倉庫コード05設定
                if (inventoryDataDspParamWork.WarehouseCd05 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD05" + Environment.NewLine);
                    SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                    paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd05);
                }

                //倉庫コード06設定
                if (inventoryDataDspParamWork.WarehouseCd06 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "")
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD06" + Environment.NewLine);
                    SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                    paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd06);
                }

                //倉庫コード07設定
                if (inventoryDataDspParamWork.WarehouseCd07 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD07" + Environment.NewLine);
                    SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                    paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd07);
                }

                //倉庫コード08設定
                if (inventoryDataDspParamWork.WarehouseCd08 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                        inventoryDataDspParamWork.WarehouseCd07 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD08" + Environment.NewLine);
                    SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                    paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd08);
                }

                //倉庫コード09設定
                if (inventoryDataDspParamWork.WarehouseCd09 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                        inventoryDataDspParamWork.WarehouseCd07 != "" || inventoryDataDspParamWork.WarehouseCd08 != "" )
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD09" + Environment.NewLine);
                    SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                    paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd09);
                }

                //倉庫コード10設定
                if (inventoryDataDspParamWork.WarehouseCd10 != "")
                {
                    if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                        inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                        inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                        inventoryDataDspParamWork.WarehouseCd07 != "" || inventoryDataDspParamWork.WarehouseCd08 != "" ||
                        inventoryDataDspParamWork.WarehouseCd09 != "")
                    {
                        retString.Append(" OR ");
                    }
                    retString.Append(" STOCK.WAREHOUSECODERF=@WAREHOUSECD10" + Environment.NewLine);
                    SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                    paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(inventoryDataDspParamWork.WarehouseCd10);
                }
                if (inventoryDataDspParamWork.WarehouseCd01 != "" || inventoryDataDspParamWork.WarehouseCd02 != "" ||
                    inventoryDataDspParamWork.WarehouseCd03 != "" || inventoryDataDspParamWork.WarehouseCd04 != "" ||
                    inventoryDataDspParamWork.WarehouseCd05 != "" || inventoryDataDspParamWork.WarehouseCd06 != "" ||
                    inventoryDataDspParamWork.WarehouseCd07 != "" || inventoryDataDspParamWork.WarehouseCd08 != "" ||
                    inventoryDataDspParamWork.WarehouseCd09 != "" || inventoryDataDspParamWork.WarehouseCd10 != "")
                {
                    retString.Append(" ) ");
                }

            }

            //メーカーコード設定
            if (inventoryDataDspParamWork.GoodsMakerCd != 0)
            {
                retString.Append(" AND STOCK.GOODSMAKERCDRF=@MAKERCODE" + Environment.NewLine);
                SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                paraMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataDspParamWork.GoodsMakerCd);
            }

            // 表示区分
            if (inventoryDataDspParamWork.ListDiv == 1)　// 0:全て,1:自社在庫,2:受託在庫
            {
                retString.Append(" AND STOCK.STOCKDIVRF = 0 " + Environment.NewLine);
            }
            if (inventoryDataDspParamWork.ListDiv == 2)　// 0:全て,1:自社在庫,2:受託在庫
            {
                retString.Append(" AND STOCK.STOCKDIVRF = 1 " + Environment.NewLine);
            }

            // 表示タイプ
            if (inventoryDataDspParamWork.ListTypeDiv == 1)　// 0:通常,1:ｱｲﾃﾑ数=0はｶｳﾝﾄしない,2:最大
            {
                retString.Append(" AND STOCK.SUPPLIERSTOCKRF != 0 " + Environment.NewLine);
            }

            return retString.ToString();
        }
        # endregion

        #region [クラス格納]
        /// <summary>
        /// クラス格納処理 Reader → InventoryDataDspResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>InventoryDataDspResultWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.08</br>
        /// <br>Update Note: 2014/03/10 汪権来</br>
        /// <br>管理番号   : 10904597-00 </br>
        /// <br>           : Redmine#40178 　棚卸表示の原価計算の障害解除(№2115)の25</br>
        /// </remarks>
        private InventoryDataDspResultWork CopyToInventoryDtDspWorkFromReader(ref SqlDataReader myReader, InventoryDataDspParamWork paramWork)
        {
            InventoryDataDspResultWork inventoryDataDspResultWork = new InventoryDataDspResultWork();

            if (myReader != null)
            {
                // 修正 2009/04/27 >>>
                #region DEL 2009/04/27 
                /*
                # region クラスへ格納
                inventoryDataDspResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODE"));
                inventoryDataDspResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
                inventoryDataDspResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAME"));
                inventoryDataDspResultWork.InventoryItemCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSCOUNT"));               
                inventoryDataDspResultWork.MaximumInventoryMoney = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMINVENTORYMONEY"));
                inventoryDataDspResultWork.InventoryMoney = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYMONEY"));
                # endregion
                */
                #endregion
                inventoryDataDspResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); //企業コード
                inventoryDataDspResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); 　// 拠点コード
                inventoryDataDspResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF")); 　// 倉庫コード
                inventoryDataDspResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));// 倉庫名称
                inventoryDataDspResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // 商品メーカー
                inventoryDataDspResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          // 商品番号
                inventoryDataDspResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));   // BL商品コード
                inventoryDataDspResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));   // BLグループコード
                inventoryDataDspResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));   // 商品中分類
                //inventoryDataDspResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF")); // 出荷可能数//DEL 汪権来 2014/03/10 for Redmine#40178の25
                inventoryDataDspResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF")); // 最高在庫数
                inventoryDataDspResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF")); // 仕入単価
                // 修正 2009/04/27 <<<
                //----ADD 汪権来 2014/03/10 for Redmine#40178の25 ------->>>>>>>>>>>
                double supplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF")); // 仕入在庫数
                double movingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF")); // 移動中仕入在庫数
                double shipMentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF")); // 出荷数（未計上）
                double arrivalcnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF")); // 入荷数（未計上）
                //在庫総数=在庫マスタ.仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－ 移動中仕入在庫数
                inventoryDataDspResultWork.StockTotal = supplierStock + arrivalcnt - shipMentCnt - movingSupliStock;
                //----ADD 汪権来 2014/03/10 for Redmine#40178の25 -------<<<<<<<<<<<
            }

            return inventoryDataDspResultWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.08</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion  //コネクション生成処理

        // --- ADD 田建委 2014/05/13 for Redmine#36564 ------->>>>>>>>>>>
        #region GetStockFractionProcInfo
        /// <summary>
        /// 仕入金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="price">対象金額</param>
        /// <param name="_stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        private void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, List<StockProcMoneyWork> _stockProcMoneyList, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = FractionProcMoney.GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = FractionProcMoney.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoneyWork> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoneyWork stockProcMoney)
                                        {
                                            if ((stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                (stockProcMoney.FractionProcCode == fractionProcCode) &&
                                                (stockProcMoney.UpperLimitPrice >= price))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
        }
        #endregion
        // --- ADD 田建委 2014/05/13 for Redmine#36564 -------<<<<<<<<<<<
    }

}
