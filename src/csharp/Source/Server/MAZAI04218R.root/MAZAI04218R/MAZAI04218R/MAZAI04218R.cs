//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 棚卸マスタ検索DBリモートオブジェクト
// プログラム概要   : 棚卸マスタの検索を行うクラスです。。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋 弘憲
// 作 成 日  2007.04.06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012 畠中 啓次朗
// 作 成 日  2008.09.08  修正内容 : PM.NS 用に改造
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012　畠中 啓次朗
// 作 成 日  2008.12.05  修正内容 : 各種不具合修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012　畠中 啓次朗
// 作 成 日  2009.06.01  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012　畠中 啓次朗
// 作 成 日  2009/07/03  修正内容 : 仕様変更(MANTIS:13651)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/11/30  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/12/10  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/12/25  修正内容 : Redine#1994対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024 佐々木 健
// 作 成 日  2010/01/28  修正内容 : 差異表で、同一の企業・通番・拠点で倉庫違いの
//                                  データの過不足数が全て更新される不具合の修正(MANTIS[0014957])
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 呉元嘯
// 作 成 日  2010/02/20  修正内容 : PM1005の対応
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 楊明俊
// 作 成 日  2010/02/23  修正内容 : PM1005の対応
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 呉元嘯
// 作 成 日  2010/03/02  修正内容 : PM1005の対応
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 30517 夏野 駿希
// 作 成 日  2010/06/18  修正内容 : Mantis.15628　企業コードの数だけ帳簿数が加算される不具合の修正
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 :  liyp </br>
// 作 成 日  2011/01/11  修正内容 :　１、貸出分の印刷がされない不具合の修正  ２、出力条件に数量と棚番に関する条件指定を追加する（要望）</br>
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/01/11  修正内容 : 棚卸障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/01/11  修正内容 : 商品マスタに存在しないデータも新規登録出来る不具合修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/01/30  修正内容 : 障害報告 #18764
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/02/10  修正内容 : 障害報告 #18866
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/02/12  修正内容 : redmine#18877 棚卸障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhangyong
// 作 成 日  2012/03/23  修正内容 : redmine#29109 ReadUnCommitted の修正依頼
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李小路
// 作 成 日  2012/07/20  修正内容 : redmine#31158 「棚卸差異表」のサーバー負荷軽減と速度アップの調査
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2012/07/26  修正内容 : 印刷時エラーの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangyi
// 修 正 日  2012/08/08  修正内容 : redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査
// ---------------------------------------------------------------------//
// 管理番号  No1553      作成担当 : 22013 久保 将太
// 修 正 日  2013/02/19  修正内容 : VSS[012]仕掛一覧対応No.1553 「棚卸過不足更新」の速度向上対応
// ---------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangyi
// 修 正 日  2013/03/01  修正内容 : 20130326配信分の対応、Redmine#34175
//                                  棚卸業務のサーバー負荷軽減
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : yangyi
// 修 正 日  2013/10/09  修正内容 : redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 譚洪
// 修 正 日  2020/06/18  修正内容 : PMKOBETSU-4005 価格マスタ　定価数値変換対応
//----------------------------------------------------------------------------//
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
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using System.Collections.Generic;
using System.IO;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common; // ADD 2020/06/18 譚洪 PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 棚卸マスタ検索DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 棚卸マスタの検索を行うクラスです。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.04.06</br>
    /// <br></br>
    /// <br>Update Note: PM.NS 用に改造</br>
    /// <br>Date       : 2008.09.08</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 各種不具合修正</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.12.05</br>
    /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
    /// <br>             過不足更新済みのデータも印刷対象とするように変更</br>
    /// <br>Update Note : 2009/12/10 呉元嘯 保守依頼③対応</br>
    /// <br>             棚卸運用区分に従って、実施日帳簿数の算出方法を変更するように変更</br>
    /// <br>Update Note : 2009/12/25 呉元嘯 保守依頼③対応</br>
    /// <br>             Redine#1994対応</br>
    /// <br></br>
    /// <br>Update Note: 差異表で、同一の企業・通番・拠点で倉庫違いのデータの過不足数が全て更新される不具合の修正(MANTIS[0014957])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/01/28</br>
    /// <br>UpdateNote : 2010/02/20 呉元嘯</br>
    /// <br>             PM1005の対応</br>
    /// <br>             ＰＭ７同等以上の処理速度へ改良する</br>
    /// <br>UpdateNote : 2010/02/23 楊明俊</br>
    /// <br>             PM1005</br>
    /// <br>             データ抽出時に、商品マスタの存在チェックを行い処理対象外とするように変更する</br>
    /// <br>UpdateNote : 2010/03/02 呉元嘯</br>
    /// <br>             PM1005</br>
    /// <br>             棚卸表処理速度の対応</br>
    /// <br>UpdateNote : 2011/01/11 田建委</br>
    /// <br>             PM1101B</br>
    /// <br>             棚卸障害対応</br>
    /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
    /// <br>             商品マスタに存在しないデータも新規登録出来る不具合修正</br>
    /// <br>UpdateNote : 2011/01/30 鄧潘ハン</br>
    /// <br>             障害報告 #18764</br>
    /// <br>UpdateNote : 2011/02/10 鄧潘ハン</br>
	/// <br>             障害報告 #18866</br>
	/// <br>UpdateNote : 2011/02/12 田建委</br>
	/// <br>             redmine#18877 棚卸障害対応</br>
    /// <br>UpdateNote : 2012/07/20 李小路</br>
    /// <br>             redmine#31158 「棚卸差異表」のサーバー負荷軽減と速度アップの調査</br>
    /// <br>UpdateNote : 2012/07/26 高峰</br>
    /// <br>             印刷時エラーの対応</br>
    /// <br>UpdateNote : 2013/02/19 22013 久保 将太</br>
    /// <br>             ・VSS[012]仕掛一覧対応No.1553 「棚卸過不足更新」の速度向上対応</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/06/18</br>
    /// <br>             </br>
    /// </remarks> 
    [Serializable]
    public class InventInputSearchDB : RemoteDB, IInventInputSearchDB
    {
        /// <summary>
        /// 棚卸マスタ検索DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22035 三橋 弘憲　  </br>
        /// <br>Date       : 2007.04.06</br>
        /// </remarks>
        public InventInputSearchDB() :
            base("MAZAI04216D", "Broadleaf.Application.Remoting.ParamData.InventInputSearch", "INVENTORYDATARF")//基底クラスのコンストラクタ
        {
        }

        #region Search
        /// <summary>
        /// 棚卸検索
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸マスタの検索を行うメソッドです。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.06</br>
        /// <br>Update     : 2007.09.13 Yokokawa  流通.NS 用に改造</br>
        /// <br>Update Note: PM.NS 用に改造</br>
        /// <br>Date       : 2008.09.08</br>
        /// <br>           : 23012 畠中 啓次朗</br>

        public int Search(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retobj = new object();
            ArrayList al = new ArrayList();
            CustomSerializeArrayList cstmAl = new CustomSerializeArrayList();
            InventInputSearchCndtnWork _inventInputSearchCndtnWork = paraobj as InventInputSearchCndtnWork;
            SqlConnection sqlConnection = null;
            int ProductNumberOutPutDiv;
            int alElementType = 0;              // 0:InventoryDataUpdateWork、1:InventInputSearchResultWork   2008.03.21 Add

            try
            {

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                
                Dictionary<string, InventInputSearchResultWork> skipDic = new Dictionary<string, InventInputSearchResultWork>();
                //SkipSearch(out skipDic, _inventInputSearchCndtnWork, ref sqlConnection); // DEL 2009/06/01
                

                ProductNumberOutPutDiv = -1;
                //非グロスデータ取得実行部
                status = SearchNonGrossAction(ref al, ref sqlConnection, _inventInputSearchCndtnWork, ProductNumberOutPutDiv, logicalMode, skipDic);
                
                //在庫数設定
                if (_inventInputSearchCndtnWork.CalcStockAmountDiv == 1)
                {
                    alElementType = 0;
                    status = CalcStockTotal(ref al, ref sqlConnection, _inventInputSearchCndtnWork, alElementType);
                }

                cstmAl.Add(al);
                retobj = cstmAl;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.Search:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }
            return status;
        }
        #endregion

        #region SearchPrint
        /// <summary>
        /// 棚卸検索
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸マスタの検索を行うメソッドです。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.06</br>
        public int SearchPrint(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retobj = new object();
            ArrayList al = new ArrayList();
            CustomSerializeArrayList cstmAl = new CustomSerializeArrayList();
            InventInputSearchCndtnWork _inventInputSearchCndtnWork = paraobj as InventInputSearchCndtnWork;
            SqlConnection sqlConnection = null;            
            int ProductNumberOutPutDiv;
            int alElementType = 1;              // 0:InventoryDataUpdateWork、1:InventInputSearchResultWork   2008.03.21 Add

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                
                sqlConnection.Open();

                Dictionary<string, InventInputSearchResultWork> skipDic = new Dictionary<string, InventInputSearchResultWork>();
                // DEL 2009/06/01 >>>
                //if (_inventInputSearchCndtnWork.SelectedPaperKind == 0)
                //{
                //    SkipSearch(out skipDic, _inventInputSearchCndtnWork, ref sqlConnection);
                //}

                //{
                // DEL 2009/06/01 <<<
                ProductNumberOutPutDiv = 0;
                //グロスデータ取得実行部
                status = SearchGrossAction(ref al, ref sqlConnection, _inventInputSearchCndtnWork, ProductNumberOutPutDiv, logicalMode, skipDic);
                //在庫数設定
                if (_inventInputSearchCndtnWork.CalcStockAmountDiv == 1)
                {
                    alElementType = 1;
                    status = CalcStockTotal(ref al, ref sqlConnection, _inventInputSearchCndtnWork, alElementType);
                }
                //} DEL 2009/06/01 
                cstmAl.Add(al);
                retobj = cstmAl;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.SearchPrint:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }
            return status;
        }
        #endregion
        // --------------ADD 2009/12/25------------>>>>>
        /// <summary>
        /// 検索したデータソート処理
        /// </summary>
        /// <param name="resultList">検索結果ArrayList</param>
        /// <param name="al">ソート結果ArrayList</param>
        /// <remarks>
        /// <br>Note       : 検索したデータソートを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.25</br>
        /// <br></br>
        /// </remarks>
        private void SortData(ArrayList resultList, ref ArrayList al)
        {
            if (resultList.Count == 0) return;
            string wareCode = string.Empty;
            string goodNo = string.Empty;
            string currentData = string.Empty;
            int makerCode = 0;
            double stockTotal = 0;
            string sectioncode = string.Empty;
            int blgroupcode;
            int blgoodscode;
            int suppliercd;
            double listPriceTaxExcFl = 0;
            double salesunitcost;

            ArrayList arrayList = new ArrayList();
            foreach (InventInputSearchResultWork data in resultList)
            {
                // 倉庫
                wareCode = data.WarehouseCode.Trim();
                // 品
                goodNo = data.GoodsNoSrc.Trim();
                // メーカー
                makerCode = data.GoodsMakerCd;
                sectioncode = data.SectionCode.Trim();
                blgroupcode = data.BLGroupCode;
                blgoodscode = data.BLGoodsCode;
                suppliercd = data.SupplierCd;
                salesunitcost = data.StockUnitPriceFl;
                listPriceTaxExcFl = data.ListPriceFl;
                // 今回のデータの保存
                currentData = wareCode + "-" + goodNo + "-" + makerCode.ToString() + sectioncode + blgroupcode.ToString()
                    + blgoodscode.ToString() + suppliercd.ToString() + salesunitcost.ToString() + listPriceTaxExcFl.ToString();
                
                // 重複データではない場合(倉庫・品番・メーカー)
                if (arrayList.Count <= 0 || !arrayList.Contains(currentData))
                {
                    arrayList.Add(currentData);
                    foreach (InventInputSearchResultWork searchData in resultList)
                    {
                        string currentWareCode = searchData.WarehouseCode.Trim();
                        string currentGoodNo = searchData.GoodsNoSrc.Trim();
                        int currentMakerCode = searchData.GoodsMakerCd;
                        //倉庫・品番・メーカーが同じで、品名違いのデータが存在する場合
                        if ((currentWareCode.Equals(wareCode)) && (currentGoodNo.Equals(goodNo)) && (currentMakerCode == makerCode)
                            && (searchData.SectionCode.Trim().Equals(sectioncode)) && (searchData.BLGroupCode.Equals(blgroupcode))
                            && (searchData.BLGoodsCode.Equals(blgoodscode)) && (searchData.SupplierCd.Equals(suppliercd))
                            && (searchData.StockUnitPriceFl.Equals(salesunitcost)) && (searchData.ListPriceFl.Equals(listPriceTaxExcFl)))
                        {
                            //来勘
                            if ("ｻｷﾀﾞｼ".Equals(searchData.WarehouseShelfNo))
                            {
                                // 出荷数合計
                                stockTotal += searchData.ShipmentCnt;
                            }
                            //貸出
                            else if ("ｶｼﾀﾞｼ".Equals(searchData.WarehouseShelfNo))
                            {
                                // 帳簿数合計
                                stockTotal += searchData.StockTotal;
                            }
                        }
                    }
                    data.StockTotal = stockTotal;
                    al.Add(data);
                    stockTotal = 0;
                }
            }

            ArrayList arrayListCopy = new ArrayList();

            for (int i = 0; i < al.Count; i++)
            {
                InventInputSearchResultWork datawork = (InventInputSearchResultWork)al[i];
                if ("ｻｷﾀﾞｼ".Equals(datawork.WarehouseShelfNo) && (datawork.StockTotal == 0))
                {
                    //
                }
                else
                {
                    arrayListCopy.Add(datawork);
                }
            }

            al = arrayListCopy;
        }

        /// <summary>
        /// 検索したデータソート処理
        /// </summary>
        /// <param name="flag">検索結果ArrayList</param>
        /// <param name="al">ソート結果ArrayList</param>
        /// <remarks>
        /// <br>Note       : 検索したデータソートを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.25</br>
        /// <br></br>
        /// </remarks>
        private void SortDataOrder(ref ArrayList al)
        {
            Dictionary<String, InventInputSearchResultWork> dic = new Dictionary<String, InventInputSearchResultWork>();
            string Key = "";
            ArrayList alList = new ArrayList();

            foreach (InventInputSearchResultWork wkInventInputSearchResultWork in al)
            {
                if ("ｶｼﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo) || "ｻｷﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                {
                    wkInventInputSearchResultWork.GoodsNo = wkInventInputSearchResultWork.GoodsNo.PadRight(23, ' ');
                    //品番の先頭>22の場合
                    if (!string.IsNullOrEmpty(wkInventInputSearchResultWork.GoodsNo) && wkInventInputSearchResultWork.GoodsNo.Length > 22)
                    {
                        Key = KeyofDic(wkInventInputSearchResultWork.WarehouseCode,
                            wkInventInputSearchResultWork.GoodsMakerCd, wkInventInputSearchResultWork.GoodsNo.Substring(0, 22), wkInventInputSearchResultWork.WarehouseShelfNo);

                        string goodsNo = wkInventInputSearchResultWork.GoodsNo;

                        if (!dic.ContainsKey(Key))
                        {
                            dic.Add(Key, wkInventInputSearchResultWork);

                            if ("ｶｼﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                            {
                                wkInventInputSearchResultWork.GoodsNo = goodsNo.Substring(0, 22) + ".";
                            }
                            else
                            {
                                wkInventInputSearchResultWork.GoodsNo = goodsNo.Substring(0, 22) + "*";
                            }
                        }
                        else
                        {
                            int index = 0;
                            for (int i = 0; i < alList.Count; i++)
                            {
                                InventInputSearchResultWork tempwork = (InventInputSearchResultWork)alList[i];
                                if (tempwork.GoodsNo.Length > 22)
                                {
                                    if (tempwork.WarehouseCode.Equals(wkInventInputSearchResultWork.WarehouseCode)
                                        && (tempwork.GoodsMakerCd.Equals(wkInventInputSearchResultWork.GoodsMakerCd))
                                        && (tempwork.GoodsNo.Substring(0, 22).Equals(wkInventInputSearchResultWork.GoodsNo.Substring(0, 22)))
                                        && (tempwork.WarehouseShelfNo.Equals(wkInventInputSearchResultWork.WarehouseShelfNo)))
                                    {
                                        index++;
                                    }
                                }
                            }

                            if (index > 25)
                            {
                                if ("ｶｼﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                                {
                                    //「A」から順に付番する
                                    wkInventInputSearchResultWork.GoodsNo = wkInventInputSearchResultWork.GoodsNo.Substring(0, 22) + "." + Convert.ToChar('Z').ToString();
                                }
                                else
                                {
                                    //「A」から順に付番する
                                    wkInventInputSearchResultWork.GoodsNo = wkInventInputSearchResultWork.GoodsNo.Substring(0, 22) + "*" + Convert.ToChar('Z').ToString();
                                }
                            }
                            else
                            {
                                if ("ｶｼﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                                {
                                    //「A」から順に付番する
                                    wkInventInputSearchResultWork.GoodsNo = wkInventInputSearchResultWork.GoodsNo.Substring(0, 22) + "." + Convert.ToChar('A' + (index - 1)).ToString();
                                }
                                else
                                {
                                    //「A」から順に付番する
                                    wkInventInputSearchResultWork.GoodsNo = wkInventInputSearchResultWork.GoodsNo.Substring(0, 22) + "*" + Convert.ToChar('A' + (index - 1)).ToString();
                                }
                            }
                        }
                    }
                    alList.Add(wkInventInputSearchResultWork);
                }
            }
        }
        // --------------ADD 2009/12/25------------<<<<<
        #region 製番データ取得処理
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_inventInputSearchCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>UpdateNote : 2010/02/23 楊明俊</br>
        /// <br>             PM1005</br>
        /// <br>             データ抽出時に、商品マスタの存在チェックを行い処理対象外とするように変更する。</br>
        /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
        /// <br>             商品マスタに存在しないデータも新規登録出来る不具合修正</br>
        /// <br>UpdateNote : 2011/01/30 鄧潘ハン</br>
        /// <br>             障害報告 #18764</br>
        /// <br>UpdateNote : 2011/02/10 鄧潘ハン</br>
        /// <br>             障害報告 #18866</br>
        /// <br>UpdateNote : 2011/02/12 朱 猛</br>
        /// <br>             障害報告 #18877</br>
        /// <br></br>
        private int SearchNonGrossAction(ref ArrayList al, ref SqlConnection sqlConnection, InventInputSearchCndtnWork _inventInputSearchCndtnWork, int productNumberOutPutDiv, ConstantManagement.LogicalMode logicalMode, Dictionary<string, InventInputSearchResultWork> skipDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // 対象テーブル
                // INVENTORYDATARF IVD   棚卸データ
                string SelectDm = "";

                #region 2008.12.05 DEL
                /*
                SelectDm += "SELECT";

                //結果取得
                SelectDm += " IVD.CREATEDATETIMERF IVD_CREATEDATETIMERF";
                SelectDm += ", IVD.UPDATEDATETIMERF IVD_UPDATEDATETIMERF";
                SelectDm += ", IVD.ENTERPRISECODERF IVD_ENTERPRISECODERF";
                SelectDm += ", IVD.FILEHEADERGUIDRF IVD_FILEHEADERGUIDRF";
                SelectDm += ", IVD.UPDEMPLOYEECODERF IVD_UPDEMPLOYEECODERF";
                SelectDm += ", IVD.UPDASSEMBLYID1RF IVD_UPDASSEMBLYID1RF";
                SelectDm += ", IVD.UPDASSEMBLYID2RF IVD_UPDASSEMBLYID2RF";
                SelectDm += ", IVD.LOGICALDELETECODERF IVD_LOGICALDELETECODERF";
                SelectDm += ", IVD.SECTIONCODERF IVD_SECTIONCODERF";
                SelectDm += ", IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF";
                SelectDm += ", IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF";
                SelectDm += ", IVD.GOODSMAKERCDRF IVD_GOODSMAKERCDRF";
                SelectDm += ", IVD.GOODSNORF IVD_GOODSNORF";
                SelectDm += ", IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF";
                SelectDm += ", IVD.DUPLICATIONSHELFNO1RF IVD_DUPLICATIONSHELFNO1RF";
                SelectDm += ", IVD.DUPLICATIONSHELFNO2RF IVD_DUPLICATIONSHELFNO2RF";
                SelectDm += ", IVD.GOODSLGROUPRF IVD_GOODSLGROUPRF";
                SelectDm += ", IVD.GOODSMGROUPRF IVD_GOODSMGROUPRF";
                SelectDm += ", IVD.BLGROUPCODERF IVD_BLGROUPCODERF";
                SelectDm += ", IVD.ENTERPRISEGANRECODERF IVD_ENTERPRISEGANRECODERF";
                SelectDm += ", IVD.BLGOODSCODERF IVD_BLGOODSCODERF";
                SelectDm += ", IVD.SUPPLIERCDRF IVD_SUPPLIERCDRF";
                SelectDm += ", IVD.JANRF IVD_JANRF";
                SelectDm += ", IVD.STOCKUNITPRICEFLRF IVD_STOCKUNITPRICEFLRF";
                SelectDm += ", IVD.BFSTOCKUNITPRICEFLRF IVD_BFSTOCKUNITPRICEFLRF";
                SelectDm += ", IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF";
                SelectDm += ", IVD.STOCKDIVRF IVD_STOCKDIVRF";
                SelectDm += ", IVD.LASTSTOCKDATERF IVD_LASTSTOCKDATERF";
                SelectDm += ", IVD.STOCKTOTALRF IVD_STOCKTOTALRF";
                SelectDm += ", IVD.SHIPCUSTOMERCODERF IVD_SHIPCUSTOMERCODERF";
                SelectDm += ", IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF";
                SelectDm += ", IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF";
                SelectDm += ", IVD.INVENTORYPREPRDAYRF IVD_INVENTORYPREPRDAYRF";
                SelectDm += ", IVD.INVENTORYPREPRTIMRF IVD_INVENTORYPREPRTIMRF";
                SelectDm += ", IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF";
                SelectDm += ", IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF";
                SelectDm += ", IVD.INVENTORYNEWDIVRF IVD_INVENTORYNEWDIVRF";
                SelectDm += ", IVD.STOCKMASHINEPRICERF IVD_STOCKMASHINEPRICERF";
                SelectDm += ", IVD.INVENTORYSTOCKPRICERF IVD_INVENTORYSTOCKPRICERF";
                SelectDm += ", IVD.INVENTORYTLRNCPRICERF IVD_INVENTORYTLRNCPRICERF";
                SelectDm += ", IVD.INVENTORYDATERF IVD_INVENTORYDATERF";
                SelectDm += ", IVD.STOCKTOTALEXECRF IVD_STOCKTOTALEXECRF";
                SelectDm += ", IVD.TOLERANCEUPDATECDRF IVD_TOLERANCEUPDATECDRF";

                // 拠点情報設定マスタ・拠点ガイド名称
                SelectDm += ", SEC.SECTIONGUIDENMRF SEC_SECTIONGUIDENMRF";               
                // 倉庫マスタ・倉庫名称
                SelectDm += ", WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF";
                // メーカーマスタ・メーカー名称
                SelectDm += ", MAK.GOODSMAKERCDRF MAK_GOODSMAKERCDRF";
                // ユーザーガイドマスタ・大分類名称
                SelectDm += ", USRGDL.GUIDENAMERF USRGDL_GUIDENAMERF";
                // グループコードマスタ・グループコード名称
                SelectDm += ", BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF";
                // ユーザーガイドマスタ・自社分類名称
                SelectDm += ", USRGDE.GUIDENAMERF USRGDE_GUIDENAMERF";
                // 商品中分類マスタ・中分類名称
                SelectDm += ", GGR.GOODSMGROUPNAMERF GGR_GOODSMGROUPNAMERF";
                // 商品マスタ・商品名称
                SelectDm += ", GOODS.GOODSNAMERF GOODS_GOODSNAMERF";
                // 得意先マスタ・名称1・2
                SelectDm += ", CTM.NAMERF CTM_NAMERF";
                SelectDm += ", CTM.NAME2RF CTM_NAME2RF";
                // BLコードマスタ・BL商品名称
                SelectDm += ", BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF";

                SelectDm += " FROM INVENTORYDATARF AS IVD";

                // 拠点情報設定マスタ結合
                SelectDm += " LEFT JOIN SECINFOSETRF AS SEC ON SEC.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND SEC.SECTIONCODERF=IVD.SECTIONCODERF";
                
                // 倉庫マスタ結合
                SelectDm += " LEFT JOIN WAREHOUSERF AS WH ON WH.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND WH.WAREHOUSECODERF=IVD.WAREHOUSECODERF";
                // メーカーマスタ結合
                SelectDm += " LEFT JOIN MAKERURF AS MAK ON MAK.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND MAK.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF";
                // 商品マスタ結合
                SelectDm += " LEFT JOIN GOODSURF AS GOODS ON GOODS.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND GOODS.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF AND GOODS.GOODSNORF=IVD.GOODSNORF";
                // 商品中分類マスタ結合
                SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR ON GGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND GGR.GOODSMGROUPRF=IVD.GOODSMGROUPRF"; 
                // グループコードマスタ結合
                //SelectDm += " LEFT JOIN BLGROUPURF AS BLGR ON BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF"; // DEL 2008.12.05
                SelectDm += " LEFT JOIN BLGROUPURF AS BLGR ON BLGR.ENTERPRISECODERF = IVD.ENTERPRISECODERF AND BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF"; // ADD 2008.12.05

                // ユーザーガイドマスタ結合(大分類)
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL ON USRGDL.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND USRGDL.USERGUIDEDIVCDRF=70 AND USRGDL.GUIDECODERF=IVD.GOODSLGROUPRF"; 
                // ユーザーガイドマスタ結合(自社分類)
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE ON USRGDE.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND USRGDE.USERGUIDEDIVCDRF=41 AND USRGDE.GUIDECODERF=IVD.ENTERPRISEGANRECODERF";
                // 得意先マスタ結合
                SelectDm += " LEFT JOIN CUSTOMERRF AS CTM ON CTM.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND CTM.CUSTOMERCODERF = IVD.SHIPCUSTOMERCODERF";
                // BLコードマスタ結合
                SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD ON BLCD.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND BLCD.BLGOODSCODERF = IVD.BLGOODSCODERF";
                // ADD 2008.12.01 >>>
                // 在庫マスタ結合
                SelectDm += " LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine;
                SelectDm += " ON IVD.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSNORF = STOCK.GOODSNORF " + Environment.NewLine;
                // ADD 2008.12.01 <<<                
                */
                #endregion
                
                #region Select文作成
                #region  DEL 2009/06/01
                /*
                // ADD 2008.12.05 >>>
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += "         IVD.CREATEDATETIMERF IVD_CREATEDATETIMERF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDATEDATETIMERF IVD_UPDATEDATETIMERF" + Environment.NewLine;
                SelectDm += "        ,IVD.ENTERPRISECODERF IVD_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.FILEHEADERGUIDRF IVD_FILEHEADERGUIDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDEMPLOYEECODERF IVD_UPDEMPLOYEECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDASSEMBLYID1RF IVD_UPDASSEMBLYID1RF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDASSEMBLYID2RF IVD_UPDASSEMBLYID2RF" + Environment.NewLine;
                SelectDm += "        ,IVD.LOGICALDELETECODERF IVD_LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.SECTIONCODERF IVD_SECTIONCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF" + Environment.NewLine;
                SelectDm += "        ,IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSMAKERCDRF IVD_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSNORF IVD_GOODSNORF" + Environment.NewLine;
                SelectDm += "        ,IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += "        ,IVD.DUPLICATIONSHELFNO1RF IVD_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += "        ,IVD.DUPLICATIONSHELFNO2RF IVD_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSLGROUPRF IVD_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSMGROUPRF IVD_GOODSMGROUPRF" + Environment.NewLine;
                SelectDm += "        ,IVD.BLGROUPCODERF IVD_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.ENTERPRISEGANRECODERF IVD_ENTERPRISEGANRECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.BLGOODSCODERF IVD_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.SUPPLIERCDRF IVD_SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.JANRF IVD_JANRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKUNITPRICEFLRF IVD_STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "        ,IVD.BFSTOCKUNITPRICEFLRF IVD_BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKDIVRF IVD_STOCKDIVRF" + Environment.NewLine;
                SelectDm += "        ,IVD.LASTSTOCKDATERF IVD_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKTOTALRF IVD_STOCKTOTALRF" + Environment.NewLine;
                SelectDm += "        ,IVD.SHIPCUSTOMERCODERF IVD_SHIPCUSTOMERCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYPREPRDAYRF IVD_INVENTORYPREPRDAYRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYPREPRTIMRF IVD_INVENTORYPREPRTIMRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF" + Environment.NewLine;
                SelectDm += "        ,IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYNEWDIVRF IVD_INVENTORYNEWDIVRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKMASHINEPRICERF IVD_STOCKMASHINEPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSTOCKPRICERF IVD_INVENTORYSTOCKPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYTLRNCPRICERF IVD_INVENTORYTLRNCPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYDATERF IVD_INVENTORYDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKTOTALEXECRF IVD_STOCKTOTALEXECRF" + Environment.NewLine;
                SelectDm += "        ,IVD.TOLERANCEUPDATECDRF IVD_TOLERANCEUPDATECDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.ADJSTCALCCOSTRF IVD_ADJSTCALCCOSTRF" + Environment.NewLine; // ADD 2009/05/21
                SelectDm += "        ,SEC.SECTIONGUIDENMRF SEC_SECTIONGUIDENMRF" + Environment.NewLine;
                SelectDm += "        ,WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;
                SelectDm += "        ,MAK.GOODSMAKERCDRF MAK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "        ,USRGDL.GUIDENAMERF USRGDL_GUIDENAMERF" + Environment.NewLine;
                SelectDm += "        ,BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;
                SelectDm += "        ,USRGDE.GUIDENAMERF USRGDE_GUIDENAMERF" + Environment.NewLine;
                SelectDm += "        ,GGR.GOODSMGROUPNAMERF GGR_GOODSMGROUPNAMERF" + Environment.NewLine;
                SelectDm += "        ,GOODS.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                SelectDm += "        ,CTM.NAMERF CTM_NAMERF" + Environment.NewLine;
                SelectDm += "        ,CTM.NAME2RF CTM_NAME2RF" + Environment.NewLine;
                SelectDm += "        ,BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;
                SelectDm += "FROM" + Environment.NewLine;
                SelectDm += "(        " + Environment.NewLine;
                SelectDm += "SELECT IVD.CREATEDATETIMERF CREATEDATETIMERF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDATEDATETIMERF   UPDATEDATETIMERF" + Environment.NewLine;
                SelectDm += "        ,IVD.ENTERPRISECODERF   ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.FILEHEADERGUIDRF   FILEHEADERGUIDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDEMPLOYEECODERF   UPDEMPLOYEECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDASSEMBLYID1RF   UPDASSEMBLYID1RF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDASSEMBLYID2RF   UPDASSEMBLYID2RF" + Environment.NewLine;
                SelectDm += "        ,IVD.LOGICALDELETECODERF   LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.SECTIONCODERF   SECTIONCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSEQNORF   INVENTORYSEQNORF" + Environment.NewLine;
                SelectDm += "        ,IVD.WAREHOUSECODERF   WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSMAKERCDRF   GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSNORF   GOODSNORF        " + Environment.NewLine;
                SelectDm += "        ,(CASE WHEN STOCK.WAREHOUSESHELFNORF IS NOT Null THEN STOCK.WAREHOUSESHELFNORF ELSE '' END) WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += "        ,(CASE WHEN STOCK.DUPLICATIONSHELFNO1RF IS NOT Null THEN STOCK.DUPLICATIONSHELFNO1RF ELSE '' END) DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += "        ,(CASE WHEN STOCK.DUPLICATIONSHELFNO2RF IS NOT Null THEN STOCK.DUPLICATIONSHELFNO2RF ELSE '' END) DUPLICATIONSHELFNO2RF        " + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSLGROUPRF   GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSMGROUPRF   GOODSMGROUPRF" + Environment.NewLine;
                SelectDm += "        ,IVD.BLGROUPCODERF   BLGROUPCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.ENTERPRISEGANRECODERF   ENTERPRISEGANRECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.BLGOODSCODERF   BLGOODSCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.SUPPLIERCDRF   SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.JANRF   JANRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKUNITPRICEFLRF   STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "        ,IVD.BFSTOCKUNITPRICEFLRF   BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STKUNITPRICECHGFLGRF   STKUNITPRICECHGFLGRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKDIVRF   STOCKDIVRF" + Environment.NewLine;
                SelectDm += "        ,IVD.LASTSTOCKDATERF   LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKTOTALRF   STOCKTOTALRF" + Environment.NewLine;
                SelectDm += "        ,IVD.SHIPCUSTOMERCODERF   SHIPCUSTOMERCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSTOCKCNTRF   INVENTORYSTOCKCNTRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYTOLERANCCNTRF   INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYPREPRDAYRF   INVENTORYPREPRDAYRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYPREPRTIMRF   INVENTORYPREPRTIMRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYDAYRF   INVENTORYDAYRF" + Environment.NewLine;
                SelectDm += "        ,IVD.LASTINVENTORYUPDATERF   LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYNEWDIVRF   INVENTORYNEWDIVRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKMASHINEPRICERF   STOCKMASHINEPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSTOCKPRICERF   INVENTORYSTOCKPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYTLRNCPRICERF   INVENTORYTLRNCPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYDATERF   INVENTORYDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKTOTALEXECRF   STOCKTOTALEXECRF" + Environment.NewLine;
                SelectDm += "        ,IVD.TOLERANCEUPDATECDRF   TOLERANCEUPDATECDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.ADJSTCALCCOSTRF" + Environment.NewLine; // ADD 2009/05/21 
                SelectDm += " FROM INVENTORYDATARF AS IVD LEFT" + Environment.NewLine;
                SelectDm += " JOIN STOCKRF AS STOCK ON IVD.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                SelectDm += " " + Environment.NewLine;
                SelectDm += " ) IVD " + Environment.NewLine;
                SelectDm += " LEFT" + Environment.NewLine;
                SelectDm += " JOIN SECINFOSETRF AS SEC ON SEC.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND SEC.SECTIONCODERF=IVD.SECTIONCODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN WAREHOUSERF AS WH ON WH.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND WH.WAREHOUSECODERF=IVD.WAREHOUSECODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN MAKERURF AS MAK ON MAK.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND MAK.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF LEFT" + Environment.NewLine;
                SelectDm += " JOIN GOODSURF AS GOODS ON GOODS.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSNORF=IVD.GOODSNORF LEFT" + Environment.NewLine;
                SelectDm += " JOIN GOODSGROUPURF AS GGR ON GGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GGR.GOODSMGROUPRF=IVD.GOODSMGROUPRF LEFT" + Environment.NewLine;
                SelectDm += " JOIN BLGROUPURF AS BLGR ON BLGR.ENTERPRISECODERF = IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN USERGDBDURF AS USRGDL ON USRGDL.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND USRGDL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
                SelectDm += " AND USRGDL.GUIDECODERF=IVD.GOODSLGROUPRF LEFT" + Environment.NewLine;
                SelectDm += " JOIN USERGDBDURF AS USRGDE ON USRGDE.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND USRGDE.USERGUIDEDIVCDRF=41" + Environment.NewLine;
                SelectDm += " AND USRGDE.GUIDECODERF=IVD.ENTERPRISEGANRECODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN CUSTOMERRF AS CTM ON CTM.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND CTM.CUSTOMERCODERF = IVD.SHIPCUSTOMERCODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN BLGOODSCDURF AS BLCD ON BLCD.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLCD.BLGOODSCODERF = IVD.BLGOODSCODERF " + Environment.NewLine;
                // ADD 2008.12.05 <<<
                */
                #endregion 

                // ADD 2009/06/01 >>>
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += " IVD.CREATEDATETIMERF IVD_CREATEDATETIMERF" + Environment.NewLine;
                SelectDm += " ,IVD.UPDATEDATETIMERF IVD_UPDATEDATETIMERF" + Environment.NewLine;
                SelectDm += " ,IVD.ENTERPRISECODERF IVD_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.FILEHEADERGUIDRF IVD_FILEHEADERGUIDRF" + Environment.NewLine;
                SelectDm += " ,IVD.UPDEMPLOYEECODERF IVD_UPDEMPLOYEECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.UPDASSEMBLYID1RF IVD_UPDASSEMBLYID1RF" + Environment.NewLine;
                SelectDm += " ,IVD.UPDASSEMBLYID2RF IVD_UPDASSEMBLYID2RF" + Environment.NewLine;
                SelectDm += " ,IVD.LOGICALDELETECODERF IVD_LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.SECTIONCODERF IVD_SECTIONCODERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF" + Environment.NewLine;
                SelectDm += " ,IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.GOODSMAKERCDRF IVD_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " ,IVD.GOODSNORF IVD_GOODSNORF" + Environment.NewLine;
                SelectDm += " ,IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += " ,IVD.DUPLICATIONSHELFNO1RF IVD_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += " ,IVD.DUPLICATIONSHELFNO2RF IVD_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += " ,IVD.GOODSLGROUPRF IVD_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += " ,IVD.GOODSMGROUPRF IVD_GOODSMGROUPRF" + Environment.NewLine;
                SelectDm += " ,IVD.BLGROUPCODERF IVD_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += " ,IVD.ENTERPRISEGANRECODERF IVD_ENTERPRISEGANRECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.BLGOODSCODERF IVD_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += " ,IVD.SUPPLIERCDRF IVD_SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += " ,IVD.JANRF IVD_JANRF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKUNITPRICEFLRF IVD_STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += " ,IVD.BFSTOCKUNITPRICEFLRF IVD_BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += " ,IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKDIVRF IVD_STOCKDIVRF" + Environment.NewLine;
                SelectDm += " ,IVD.LASTSTOCKDATERF IVD_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKTOTALRF IVD_STOCKTOTALRF" + Environment.NewLine;
                SelectDm += " ,IVD.SHIPCUSTOMERCODERF IVD_SHIPCUSTOMERCODERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYPREPRDAYRF IVD_INVENTORYPREPRDAYRF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYPREPRTIMRF IVD_INVENTORYPREPRTIMRF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF" + Environment.NewLine;
                SelectDm += " ,IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYNEWDIVRF IVD_INVENTORYNEWDIVRF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKMASHINEPRICERF IVD_STOCKMASHINEPRICERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYSTOCKPRICERF IVD_INVENTORYSTOCKPRICERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYTLRNCPRICERF IVD_INVENTORYTLRNCPRICERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYDATERF IVD_INVENTORYDATERF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKTOTALEXECRF IVD_STOCKTOTALEXECRF" + Environment.NewLine;
                SelectDm += " ,IVD.TOLERANCEUPDATECDRF IVD_TOLERANCEUPDATECDRF" + Environment.NewLine;
                SelectDm += " ,IVD.ADJSTCALCCOSTRF IVD_ADJSTCALCCOSTRF " + Environment.NewLine;
                SelectDm += " ,SEC.SECTIONGUIDENMRF SEC_SECTIONGUIDENMRF" + Environment.NewLine;
                SelectDm += " ,WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;
                SelectDm += " ,MAK.GOODSMAKERCDRF MAK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " ,USRGDL.GUIDENAMERF USRGDL_GUIDENAMERF" + Environment.NewLine;
                SelectDm += " ,BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;
                SelectDm += " ,USRGDE.GUIDENAMERF USRGDE_GUIDENAMERF" + Environment.NewLine;
                SelectDm += " ,GGR.GOODSMGROUPNAMERF GGR_GOODSMGROUPNAMERF" + Environment.NewLine;
                //SelectDm += " ,GOODS.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine; // DEL 2011/01/11
                SelectDm += " ,IVD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine; // ADD 2011/01/11
                SelectDm += " ,GOODS.GOODSNAMERF GOODS_GOODSNAMERF_NEW" + Environment.NewLine; // ADD 2011/02/12
                //SelectDm += " ,IVD.LISTPRICEFLRF GOODS_LISTPRICERF" + Environment.NewLine; // ADD 2011/01/30 // DEL 2011/02/16
                //SelectDm += " ,GOODSPRICE.LISTPRICERF GOODSPRICE_LISTPRICERF" + Environment.NewLine; // ADD 2011/02/12 // DEL 2011/02/16
                SelectDm += " ,CTM.NAMERF CTM_NAMERF" + Environment.NewLine;
                SelectDm += " ,CTM.NAME2RF CTM_NAME2RF" + Environment.NewLine;
                SelectDm += " ,BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;
                // --- ADD 2010/02/23 ---------->>>>>
                SelectDm += " ,(CASE WHEN GOODS.LOGICALDELETECODERF IS NULL THEN 1 ELSE GOODS.LOGICALDELETECODERF END) AS IVD_GOODSDIVRF" + Environment.NewLine;
                // --- ADD 2010/02/23 ----------<<<<<
                //SelectDm += "FROM INVENTORYDATARF AS IVD" + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "FROM INVENTORYDATARF AS IVD WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼

                #region 結合
                //SelectDm += " LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON SEC.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND SEC.SECTIONCODERF=IVD.SECTIONCODERF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN WAREHOUSERF AS WH " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN WAREHOUSERF AS WH WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON WH.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND WH.WAREHOUSECODERF=IVD.WAREHOUSECODERF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON MAK.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND MAK.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN GOODSURF AS GOODS " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON GOODS.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND GOODS.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "  AND GOODS.GOODSNORF=IVD.GOODSNORF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON GGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND GGR.GOODSMGROUPRF=IVD.GOODSMGROUPRF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN BLGROUPURF AS BLGR " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN BLGROUPURF AS BLGR WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON BLGR.ENTERPRISECODERF = IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON USRGDL.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND USRGDL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
                SelectDm += "  AND USRGDL.GUIDECODERF=IVD.GOODSLGROUPRF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON USRGDE.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND USRGDE.USERGUIDEDIVCDRF=41" + Environment.NewLine;
                SelectDm += "  AND USRGDE.GUIDECODERF=IVD.ENTERPRISEGANRECODERF" + Environment.NewLine;
                //SelectDm += " LEFT JOIN CUSTOMERRF AS CTM " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN CUSTOMERRF AS CTM WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON CTM.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND CTM.CUSTOMERCODERF = IVD.SHIPCUSTOMERCODERF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON BLCD.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND BLCD.BLGOODSCODERF = IVD.BLGOODSCODERF " + Environment.NewLine;
                // ---------- DEL 2011/02/16 ------------------->>>>>
				//// --- ADD 2011/02/12 ---------->>>>>
				//SelectDm += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine;
				//SelectDm += " ON GOODSPRICE.ENTERPRISECODERF = IVD.ENTERPRISECODERF" + Environment.NewLine;
				//SelectDm += " AND GOODSPRICE.GOODSMAKERCDRF = IVD.GOODSMAKERCDRF" + Environment.NewLine;
				//SelectDm += " AND GOODSPRICE.GOODSNORF = IVD.GOODSNORF " + Environment.NewLine;
				//SelectDm += " AND GOODSPRICE.PRICESTARTDATERF  <= IVD.INVENTORYDATERF " + Environment.NewLine;
				//// --- ADD 2011/02/12 ----------<<<<<
                // ---------- DEL 2011/02/16 -------------------<<<<<
                #endregion
                // ADD 2009/06/01 <<<

                #endregion

                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _inventInputSearchCndtnWork, productNumberOutPutDiv, logicalMode);

                #region DEL 2009/06/01 
                //if (skipDic.Count > 0)
                //{
                //    int skipDicCount = 0;
                //    foreach (InventInputSearchResultWork skipInventInputSearchResultWork in skipDic.Values)
                //    {
                //        sqlCommand.CommandText += " AND (IVD.GOODSMAKERCDRF!=@GOODSMAKERCD" + skipDicCount.ToString() + " OR IVD.GOODSNORF!=@GOODSNO" + skipDicCount.ToString() + ")";
                //        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + skipDicCount.ToString(), SqlDbType.Int);
                //        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(skipInventInputSearchResultWork.GoodsMakerCd);
                //        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO" + skipDicCount.ToString(), SqlDbType.NVarChar);
                //        paraGoodsNo.Value = SqlDataMediator.SqlSetString(skipInventInputSearchResultWork.GoodsNo);
                //        skipDicCount++;
                //    }
                //}
                #endregion

                myReader = sqlCommand.ExecuteReader();

                //棚卸数入力の場合
                if ((productNumberOutPutDiv == 0) || (productNumberOutPutDiv == -1))
                {
                    while (myReader.Read())
                    {
                        #region 抽出結果-値セット
                        InventoryDataUpdateWork wkInventoryDataUpdateWork = new InventoryDataUpdateWork();

                        wkInventoryDataUpdateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("IVD_CREATEDATETIMERF"));
                        wkInventoryDataUpdateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("IVD_UPDATEDATETIMERF"));
                        wkInventoryDataUpdateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_ENTERPRISECODERF"));
                        wkInventoryDataUpdateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("IVD_FILEHEADERGUIDRF"));
                        wkInventoryDataUpdateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_UPDEMPLOYEECODERF"));
                        wkInventoryDataUpdateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_UPDASSEMBLYID1RF"));
                        wkInventoryDataUpdateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_UPDASSEMBLYID2RF"));
                        wkInventoryDataUpdateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_LOGICALDELETECODERF"));
                        wkInventoryDataUpdateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                        wkInventoryDataUpdateWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                        wkInventoryDataUpdateWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                        wkInventoryDataUpdateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                        wkInventoryDataUpdateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                        wkInventoryDataUpdateWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                        wkInventoryDataUpdateWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO1RF"));
                        wkInventoryDataUpdateWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO2RF"));
                        wkInventoryDataUpdateWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSLGROUPRF"));
                        wkInventoryDataUpdateWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMGROUPRF"));
                        wkInventoryDataUpdateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGROUPCODERF"));
                        wkInventoryDataUpdateWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_ENTERPRISEGANRECODERF"));
                        wkInventoryDataUpdateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGOODSCODERF"));
                        wkInventoryDataUpdateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SUPPLIERCDRF"));
                        wkInventoryDataUpdateWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_JANRF"));
                        wkInventoryDataUpdateWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                        wkInventoryDataUpdateWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                        wkInventoryDataUpdateWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                        wkInventoryDataUpdateWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STOCKDIVRF"));
                        wkInventoryDataUpdateWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTSTOCKDATERF"));
                        wkInventoryDataUpdateWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));
                        wkInventoryDataUpdateWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SHIPCUSTOMERCODERF"));
                        wkInventoryDataUpdateWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                        wkInventoryDataUpdateWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                        wkInventoryDataUpdateWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRDAYRF"));
                        wkInventoryDataUpdateWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRTIMRF"));
                        wkInventoryDataUpdateWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                        wkInventoryDataUpdateWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                        wkInventoryDataUpdateWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYNEWDIVRF"));
                        wkInventoryDataUpdateWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_STOCKMASHINEPRICERF"));
                        wkInventoryDataUpdateWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKPRICERF"));
                        wkInventoryDataUpdateWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYTLRNCPRICERF"));
                        wkInventoryDataUpdateWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDATERF"));
                        wkInventoryDataUpdateWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALEXECRF"));
                        wkInventoryDataUpdateWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_TOLERANCEUPDATECDRF"));
                        wkInventoryDataUpdateWork.StockAmount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));

                        wkInventoryDataUpdateWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));  // ADD 2009/04/13 <<<
                        //wkInventoryDataUpdateWork.Status = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STATUSRF"));
                        //wkInventoryDataUpdateWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODS_LISTPRICERF"));  // ADD 2011/01/30  // DEL 2011/02/16
                        // --- ADD 2011/02/12 ---------->>>>>
						// --- UPD 2011/02/16 --->>>>>
						//if ("".Equals(wkInventoryDataUpdateWork.GoodsName) && !"ｶｼﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
						if ("".Equals(wkInventoryDataUpdateWork.GoodsName))
						// --- UPD 2011/02/16 ---<<<<<
						{
                            wkInventoryDataUpdateWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF_NEW"));
							//wkInventoryDataUpdateWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF")); // DEL 2011/02/16
                        }
                        // --- ADD 2011/02/12 ----------<<<<<
                        // --- ADD 2010/02/23 ---------->>>>>
                        //商品チェックフラグ
                        wkInventoryDataUpdateWork.GoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSDIVRF"));
                        // --- ADD 2010/02/23 ----------<<<<<
                        wkInventoryDataUpdateWork.AdjstCalcCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_ADJSTCALCCOSTRF")); // 2009/05/21 >>>

                        #endregion   // 抽出結果-値セット

                        // ----- DEL 2011/02/16 --------->>>>>
						////--- ADD 2011/02/12----->>>>>
						//bool equalFlag = false;
						//foreach (InventoryDataUpdateWork inventoryDataUpdateWork in al)
						//{
						//    if (inventoryDataUpdateWork.SectionCode == wkInventoryDataUpdateWork.SectionCode
						//        && inventoryDataUpdateWork.WarehouseCode == wkInventoryDataUpdateWork.WarehouseCode
						//        && inventoryDataUpdateWork.WarehouseCode == wkInventoryDataUpdateWork.WarehouseCode
						//        && inventoryDataUpdateWork.GoodsMakerCd == wkInventoryDataUpdateWork.GoodsMakerCd
						//        && inventoryDataUpdateWork.GoodsNo == wkInventoryDataUpdateWork.GoodsNo
						//        && inventoryDataUpdateWork.SupplierCd == wkInventoryDataUpdateWork.SupplierCd
						//        && inventoryDataUpdateWork.ShipCustomerCode == wkInventoryDataUpdateWork.ShipCustomerCode
						//        && inventoryDataUpdateWork.StockUnitPriceFl == wkInventoryDataUpdateWork.StockUnitPriceFl
						//        && inventoryDataUpdateWork.StockDiv == wkInventoryDataUpdateWork.StockDiv
						//        && inventoryDataUpdateWork.WarehouseShelfNo == wkInventoryDataUpdateWork.WarehouseShelfNo)
						//    {
						//        equalFlag = true;
						//        break;
						//    }
						//}
						//if (equalFlag)
						//{
						//    continue;
						//}
						////--- ADD 2011/02/12-----<<<<<
                        // ----- DEL 2011/02/16 ---------<<<<<

                        //al.Add(wkInventoryDataUpdateWork);// DEL2011/01/11 
                        // ----- ADD 2011/01/11 ---------------------------------------------------------------------->>>>>
                        // ①貸出データ抽出区分（0:印刷しない,1:印刷する） ②来勘計上分データ抽出区分（0:印刷しない,1:印刷する）
                        if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                        {
                            al.Add(wkInventoryDataUpdateWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2011/02/10
                        }
                        else if (_inventInputSearchCndtnWork.LendExtraDiv == 0 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                        {
                            // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｶｼﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventoryDataUpdateWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2011/02/10
                            }
                        }
                        else if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 0)
                        {
                            // 棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｻｷﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventoryDataUpdateWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2011/02/10
                            }
                        }
                        else
                        {
                            // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｶｼﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventoryDataUpdateWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2011/02/10
                            }
                        }
                        // ----- ADD 2011/01/11 ---------------------------------------------------------------------->>>>>
                        //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// DEL 2011/02/10
                    }
                }
                else
                {
                    while (myReader.Read())
                    {
                        #region 抽出結果-値セット
                        InventInputSearchResultWork wkInventInputSearchResultWork = new InventInputSearchResultWork();

                        //製番在庫マスタ格納項目
                        wkInventInputSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                        wkInventInputSearchResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTIONGUIDENMRF"));
                        wkInventInputSearchResultWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                        wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                        wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH_WAREHOUSENAMERF"));
                        wkInventInputSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                        wkInventInputSearchResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAK_MAKERNAMERF"));
                        wkInventInputSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                        wkInventInputSearchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                        wkInventInputSearchResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                        wkInventInputSearchResultWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO1RF"));
                        wkInventInputSearchResultWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO2RF"));
                        wkInventInputSearchResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSLGROUPRF"));
                        wkInventInputSearchResultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRGDL_GOODSLGROUPNAMERF"));
                        wkInventInputSearchResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMGROUPRF"));
                        wkInventInputSearchResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GGR_GOODSMGROUPNAMERF"));
                        wkInventInputSearchResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGROUPCODERF"));
                        wkInventInputSearchResultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGR_BLGROUPNAMERF"));
                        wkInventInputSearchResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_ENTERPRISEGANRECODERF"));
                        wkInventInputSearchResultWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRGDE_GUIDENAMERF"));
                        wkInventInputSearchResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGOODSCODERF"));
                        wkInventInputSearchResultWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLCD_BLGOODSFULLNAMERF"));
                        wkInventInputSearchResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SUPPLIERCDRF"));
                        wkInventInputSearchResultWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_JANRF"));
                        wkInventInputSearchResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                        wkInventInputSearchResultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                        wkInventInputSearchResultWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                        wkInventInputSearchResultWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STOCKDIVRF"));
                        wkInventInputSearchResultWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTSTOCKDATERF"));
                        wkInventInputSearchResultWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));
                        wkInventInputSearchResultWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SHIPCUSTOMERCODERF"));
                        wkInventInputSearchResultWork.ShipCustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTM_SHIPCUSTOMERNAMERF"));
                        wkInventInputSearchResultWork.ShipCustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTM_SHIPCUSTOMERNAME2RF"));
                        wkInventInputSearchResultWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                        wkInventInputSearchResultWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                        wkInventInputSearchResultWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRDAYRF"));
                        wkInventInputSearchResultWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRTIMRF"));
                        wkInventInputSearchResultWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                        wkInventInputSearchResultWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                        wkInventInputSearchResultWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYNEWDIVRF"));
                        wkInventInputSearchResultWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_STOCKMASHINEPRICERF"));
                        wkInventInputSearchResultWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKPRICERF"));
                        wkInventInputSearchResultWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYTLRNCPRICERF"));
                        wkInventInputSearchResultWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDATERF"));
                        wkInventInputSearchResultWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALEXECRF"));
                        wkInventInputSearchResultWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_TOLERANCEUPDATECDRF"));
                        #endregion    // 抽出結果-値セット
                        al.Add(wkInventInputSearchResultWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                base.WriteErrorLog(ex, "InventInputSearchDB.SearchNonGrossAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            
            return status;
        }
        #endregion

        #region 非製番データ取得処理
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_inventInputSearchCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2009/11/30 張凱 保守依頼③対応</br>
        /// <br>Update Note: 2009/12/25 呉元嘯 Redmine#1994対応</br>
        /// <br>Update Note: 2010/03/02 呉元嘯 標準価格対応</br> 
        /// <br>Update Note: 2011/01/11 田建委 棚卸障害対応</br> 
		/// <br>Update Note: 2011/02/12 田建委 redmine#18877 棚卸障害対応</br> 
		/// <br>Update Note: 2011/02/15 田建委 redmine#18877 棚卸障害対応</br>
        /// <br>UpdateNote : 2012/07/26 高峰 印刷時エラーの対応</br>
        /// <br>Update Note: 2013/03/01 yangyi</br>
        /// <br>管理番号   : 10801804-00 2013/03/06配信分の緊急対応</br>
        /// <br>           : Redmine#34175 　棚卸業務のサーバー負荷軽減対策</br>
        private int SearchGrossAction(ref ArrayList al, ref SqlConnection sqlConnection, InventInputSearchCndtnWork _inventInputSearchCndtnWork, int productNumberOutPutDiv, ConstantManagement.LogicalMode logicalMode, Dictionary<string, InventInputSearchResultWork> skipDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList alcopy = new ArrayList();//2009/11/30
            Dictionary<string, InventInputSearchResultWork> filterDic = new Dictionary<string, InventInputSearchResultWork>();// 2010/03/02

            try
            {
                // 対象テーブル
                // INVENTORYDATARF IVD   棚卸データ
                string SelectDm = "";

                #region Select文作成

                SelectDm += "SELECT";

                //結果取得
                // 棚卸データ
                SelectDm += " IVD.SECTIONCODERF IVD_SECTIONCODERF";
                SelectDm += ", MAX(IVD.INVENTORYSEQNORF) IVD_INVENTORYSEQNORF";
                SelectDm += ", IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF";
                SelectDm += ", IVD.GOODSMAKERCDRF IVD_GOODSMAKERCDRF";
                SelectDm += ", IVD.GOODSNORF IVD_GOODSNORF";
                SelectDm += ", IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF";
                SelectDm += ", IVD.DUPLICATIONSHELFNO1RF IVD_DUPLICATIONSHELFNO1RF";
                SelectDm += ", IVD.DUPLICATIONSHELFNO2RF IVD_DUPLICATIONSHELFNO2RF";
                SelectDm += ", IVD.GOODSLGROUPRF IVD_GOODSLGROUPRF";
                SelectDm += ", IVD.GOODSMGROUPRF IVD_GOODSMGROUPRF";
                SelectDm += ", IVD.BLGROUPCODERF IVD_BLGROUPCODERF";
                SelectDm += ", IVD.ENTERPRISEGANRECODERF IVD_ENTERPRISEGANRECODERF";
                SelectDm += ", IVD.BLGOODSCODERF IVD_BLGOODSCODERF";
                SelectDm += ", IVD.SUPPLIERCDRF IVD_SUPPLIERCDRF";
                SelectDm += ", IVD.JANRF IVD_JANRF";
                SelectDm += ", IVD.SHIPCUSTOMERCODERF IVD_SHIPCUSTOMERCODERF"; 
                SelectDm += ", IVD.STOCKUNITPRICEFLRF IVD_STOCKUNITPRICEFLRF";
                SelectDm += ", IVD.BFSTOCKUNITPRICEFLRF IVD_BFSTOCKUNITPRICEFLRF";
                SelectDm += ", IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF";
                SelectDm += ", IVD.STOCKDIVRF IVD_STOCKDIVRF";
                SelectDm += ", IVD.LASTSTOCKDATERF IVD_LASTSTOCKDATERF";                
                SelectDm += ", SUM(IVD.STOCKTOTALRF) IVD_STOCKTOTALRF";
                SelectDm += ", SUM(IVD.INVENTORYSTOCKCNTRF) IVD_INVENTORYSTOCKCNTRF";
                SelectDm += ", SUM(IVD.INVENTORYTOLERANCCNTRF) IVD_INVENTORYTOLERANCCNTRF";
                SelectDm += ", IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF";
                SelectDm += ", IVD.INVENTORYNEWDIVRF IVD_INVENTORYNEWDIVRF";
                SelectDm += ", IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF";
                SelectDm += ", IVD.INVENTORYDATERF IVD_INVENTORYDATERF";
                SelectDm += ", IVD.STOCKTOTALEXECRF IVD_STOCKTOTALEXECRF";
                SelectDm += ", IVD.TOLERANCEUPDATECDRF IVD_TOLERANCEUPDATECDRF";

                SelectDm += ", IVD.STOCKMASHINEPRICERF IVD_STOCKMASHINEPRICERF";
                SelectDm += ", IVD.INVENTORYSTOCKPRICERF IVD_INVENTORYSTOCKPRICERF";
                SelectDm += ", IVD.INVENTORYTLRNCPRICERF IVD_INVENTORYTLRNCPRICERF";

                // 拠点情報設定マスタ・拠点ガイド名称
                SelectDm += ", SEC.SECTIONGUIDENMRF SEC_SECTIONGUIDENMRF";
                // 倉庫マスタ・倉庫名称
                SelectDm += ", WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF";
                // メーカーマスタ・メーカー名称
                SelectDm += ", MAK.MAKERNAMERF MAK_MAKERNAMERF";
                // ユーザーガイドマスタ・大分類名称
                SelectDm += ", USRGDL.GUIDENAMERF USRGDL_GUIDENAMERF";
                // グループコードマスタ・グループコード名称
                SelectDm += ", BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF";
                // ユーザーガイドマスタ・自社分類名称
                SelectDm += ", USRGDE.GUIDENAMERF USRGDE_GUIDENAMERF";
                // 商品中分類マスタ・中分類名称
                SelectDm += ", GGR.GOODSMGROUPNAMERF GGR_GOODSMGROUPNAMERF";
                // 商品マスタ・商品名称
                //SelectDm += ", GOODS.GOODSNAMERF GOODS_GOODSNAMERF"; // DEL 2011/01/11
                SelectDm += ", IVD.GOODSNAMERF GOODS_GOODSNAMERF"; // ADD 2011/01/11
                //SelectDm += ", GOODS.GOODSNAMERF GOODS_GOODSNAMERF_NEW"; // ADD 2011/02/12  //DEL yangyi 2013/03/01 Redmine#34175
                // 得意先マスタ・名称1・2
                SelectDm += ", CTM.NAMERF CTM_NAMERF";
                SelectDm += ", CTM.NAME2RF CTM_NAME2RF";
                // BLコードマスタ・BL商品名称
                SelectDm += ", BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF";

                if ((_inventInputSearchCndtnWork.SelectedPaperKind != 1) && (_inventInputSearchCndtnWork.SelectedPaperKind != 2))
                {
                    //SelectDm += ", IVD.LISTPRICEFLRF IVD_LISTPRICEFLRF"; // ADD 2011/01/11 // DEL 2011/02/15
                    SelectDm += ", IVD.INVENTORYPREPRDAYRF IVD_INVENTORYPREPRDAYRF";
                    SelectDm += ", IVD.INVENTORYPREPRTIMRF IVD_INVENTORYPREPRTIMRF";
                }
                // --------------ADD 2010/03/02------------->>>>>
                // 棚卸表
                if (_inventInputSearchCndtnWork.SelectedPaperKind == 2)
                {
                    //SelectDm += ", GOODSPRICE.PRICESTARTDATERF";// 価格開始日//DEL yangyi 2013/03/01 Redmine#34175
                    //SelectDm += ", GOODSPRICE.LISTPRICERF GPC_LISTPRICERF";// 定価（浮動） // DEL 2011/01/11
                    SelectDm += ", IVD.LISTPRICEFLRF GPC_LISTPRICERF";// 定価（浮動） // ADD 2011/01/11
                    //SelectDm += ", GOODSPRICE.LISTPRICERF GPC_LISTPRICERF_NEW";// 定価（浮動） // ADD 2011/02/12//DEL yangyi 2013/03/01 Redmine#34175
                }
                // --------------ADD 2010/03/02-------------<<<<<
                //SelectDm += " FROM INVENTORYDATARF AS IVD";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " FROM INVENTORYDATARF AS IVD WITH (READUNCOMMITTED) ";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼

                // 拠点情報設定マスタ結合
                //SelectDm += " LEFT JOIN SECINFOSETRF AS SEC ON SEC.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND SEC.SECTIONCODERF=IVD.SECTIONCODERF";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON SEC.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND SEC.SECTIONCODERF=IVD.SECTIONCODERF";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                // 倉庫マスタ結合
                //SelectDm += " LEFT JOIN WAREHOUSERF AS WH ON WH.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND WH.WAREHOUSECODERF=IVD.WAREHOUSECODERF";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN WAREHOUSERF AS WH WITH (READUNCOMMITTED) ON WH.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND WH.WAREHOUSECODERF=IVD.WAREHOUSECODERF";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                // メーカーマスタ結合
                //SelectDm += " LEFT JOIN MAKERURF AS MAK ON MAK.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND MAK.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) ON MAK.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND MAK.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼

                // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                //// 商品マスタ結合
                ////SelectDm += " LEFT JOIN GOODSURF AS GOODS ON GOODS.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND GOODS.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                //SelectDm += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) ON GOODS.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND GOODS.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                //SelectDm += " AND GOODS.GOODSNORF=IVD.GOODSNORF";
                // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                // 商品中分類マスタ結合
                //SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR ON GGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND GGR.GOODSMGROUPRF=IVD.GOODSMGROUPRF";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR WITH (READUNCOMMITTED) ON GGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND GGR.GOODSMGROUPRF=IVD.GOODSMGROUPRF";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                // グループコードマスタ結合
                //SelectDm += " LEFT JOIN BLGROUPURF AS BLGR ON BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN BLGROUPURF AS BLGR WITH (READUNCOMMITTED) ON BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                // 2010/06/18 Add >>>
                SelectDm += " AND BLGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF";
                // 2010/06/18 Add <<<
                // ユーザーガイドマスタ結合(大分類)
                //SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL ON USRGDL.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND USRGDL.USERGUIDEDIVCDRF=70";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL WITH (READUNCOMMITTED) ON USRGDL.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND USRGDL.USERGUIDEDIVCDRF=70";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " AND USRGDL.GUIDECODERF=IVD.GOODSLGROUPRF";
                // ユーザーガイドマスタ結合(自社分類)
                //SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE ON USRGDE.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND USRGDE.USERGUIDEDIVCDRF=41";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE WITH (READUNCOMMITTED) ON USRGDE.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND USRGDE.USERGUIDEDIVCDRF=41";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " AND USRGDE.GUIDECODERF=IVD.ENTERPRISEGANRECODERF";
                // 得意先マスタ結合
                //SelectDm += " LEFT JOIN CUSTOMERRF AS CTM ON CTM.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND CTM.CUSTOMERCODERF = IVD.SHIPCUSTOMERCODERF";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN CUSTOMERRF AS CTM WITH (READUNCOMMITTED) ON CTM.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND CTM.CUSTOMERCODERF = IVD.SHIPCUSTOMERCODERF";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                // BLコードマスタ結合
                //SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD ON BLCD.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND BLCD.BLGOODSCODERF = IVD.BLGOODSCODERF";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD WITH (READUNCOMMITTED) ON BLCD.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND BLCD.BLGOODSCODERF = IVD.BLGOODSCODERF";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                // ADD 2008.12.01 >>>
                // 在庫マスタ結合
                //SelectDm += " LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN STOCKRF AS STOCK  WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " ON IVD.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSNORF = STOCK.GOODSNORF " + Environment.NewLine;
                // ADD 2008.12.01 <<<                

                // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                //// -----------ADD 2010/03/02------------->>>>>
                //// 棚卸表
                //if (_inventInputSearchCndtnWork.SelectedPaperKind == 2)
                //{
                //    //SelectDm += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                //    SelectDm += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                //    SelectDm += " ON IVD.ENTERPRISECODERF = GOODSPRICE.ENTERPRISECODERF" + Environment.NewLine;
                //    SelectDm += " AND IVD.GOODSMAKERCDRF = GOODSPRICE.GOODSMAKERCDRF" + Environment.NewLine;
                //    SelectDm += " AND IVD.GOODSNORF = GOODSPRICE.GOODSNORF " + Environment.NewLine;
                //    //SelectDm += " AND GOODSPRICE.PRICESTARTDATERF  <= CONVERT(varchar(100), GETDATE(), 112)" + Environment.NewLine; // DEL 2011/02/17
                //    SelectDm += " AND GOODSPRICE.PRICESTARTDATERF  <= IVD.INVENTORYDATERF" + Environment.NewLine; // ADD 2011/02/17
                //}
                //// -----------ADD 2010/03/02-------------<<<<<
                // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                #endregion

                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _inventInputSearchCndtnWork, productNumberOutPutDiv, logicalMode);

                // DEL 2009/06/01 >>>
                //if (skipDic.Count > 0)
                //{
                //    int skipDicCount = 0;
                //    foreach (InventInputSearchResultWork skipInventInputSearchResultWork in skipDic.Values)
                //    {
                //        sqlCommand.CommandText += " AND (IVD.GOODSMAKERCDRF!=@GOODSMAKERCD" + skipDicCount.ToString() + " OR IVD.GOODSNORF!=@GOODSNO" + skipDicCount.ToString() + ")";

                //        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + skipDicCount.ToString(), SqlDbType.Int);
                //        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(skipInventInputSearchResultWork.GoodsMakerCd);
                //        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO" + skipDicCount.ToString(), SqlDbType.NVarChar);
                //        paraGoodsNo.Value = SqlDataMediator.SqlSetString(skipInventInputSearchResultWork.GoodsNo);
                        
                //        skipDicCount++;
                //    }
                //}
                // DEL 2009/06/01 <<<

                //GROUP文の追加
                // 帳票種別       SelectedPaperKind: 0:棚卸記入表、1:棚卸差異表、2:棚卸表
                // 差異分抽出区分 DifCntExtraDiv   : 0:全て,1:数未入力分のみ,2:数入力分のみ,3:差異分のみ
                if ((_inventInputSearchCndtnWork.SelectedPaperKind != 1) && (_inventInputSearchCndtnWork.SelectedPaperKind != 2))
                {
                    // 0:棚卸記入表
                    if (_inventInputSearchCndtnWork.DifCntExtraDiv != 0)
                    {                     
                        #region GROUP ①
                        //sqlCommand.CommandText += " GROUP BY IVD.SECTIONCODERF, SEC.SECTIONGUIDENMRF, IVD.WAREHOUSECODERF, IVD.WAREHOUSENAMERF, IVD.WAREHOUSESHELFNORF, IVD.DUPLICATIONSHELFNO1RF, IVD.DUPLICATIONSHELFNO2RF, IVD.GOODSMAKERCDRF, IVD.MAKERNAMERF, IVD.GOODSNORF, IVD.GOODSNAMERF, IVD.LARGEGOODSGANRECODERF, IVD.LARGEGOODSGANRENAMERF, IVD.MEDIUMGOODSGANRECODERF, IVD.MEDIUMGOODSGANRENAMERF, IVD.DETAILGOODSGANRECODERF, IVD.DETAILGOODSGANRENAMERF, IVD.ENTERPRISEGANRECODERF, IVD.ENTERPRISEGANRENAMERF, IVD.BLGOODSCODERF, IVD.SUPPLIERCDRF, IVD.CUSTOMERNAMERF, IVD.CUSTOMERNAME2RF, IVD.JANRF, IVD.STOCKUNITPRICEFLRF, IVD.BFSTOCKUNITPRICEFLRF, IVD.STKUNITPRICECHGFLGRF, IVD.LASTSTOCKDATERF, IVD.INVENTORYPREPRDAYRF, IVD.INVENTORYPREPRTIMRF, IVD.INVENTORYDAYRF, IVD.LASTINVENTORYUPDATERF, IVD.STOCKUNITPRICEFLRF, IVD.INVENTORYDATERF, IVD.STOCKTOTALEXECRF, IVD.TOLERANCEUPDATECDRF, IVD.STOCKDIVRF  HAVING SUM(IVD.INVENTORYTOLERANCCNTRF) <> 0";
                        sqlCommand.CommandText += " GROUP BY IVD.SECTIONCODERF";
                        sqlCommand.CommandText += ", IVD.WAREHOUSECODERF";
                        sqlCommand.CommandText += ", IVD.GOODSMAKERCDRF";
                        sqlCommand.CommandText += ", IVD.GOODSNORF";
                        sqlCommand.CommandText += ", IVD.WAREHOUSESHELFNORF";
                        sqlCommand.CommandText += ", IVD.DUPLICATIONSHELFNO1RF";
                        sqlCommand.CommandText += ", IVD.DUPLICATIONSHELFNO2RF";
                        sqlCommand.CommandText += ", IVD.GOODSLGROUPRF";
                        sqlCommand.CommandText += ", IVD.GOODSMGROUPRF";
                        sqlCommand.CommandText += ", IVD.BLGROUPCODERF";
                        sqlCommand.CommandText += ", IVD.ENTERPRISEGANRECODERF";
                        sqlCommand.CommandText += ", IVD.BLGOODSCODERF";
                        sqlCommand.CommandText += ", IVD.SUPPLIERCDRF";
                        sqlCommand.CommandText += ", IVD.JANRF";
                        sqlCommand.CommandText += ", IVD.STOCKUNITPRICEFLRF";
                        sqlCommand.CommandText += ", IVD.BFSTOCKUNITPRICEFLRF";
                        sqlCommand.CommandText += ", IVD.STKUNITPRICECHGFLGRF";
                        sqlCommand.CommandText += ", IVD.STOCKDIVRF";
                        sqlCommand.CommandText += ", IVD.LASTSTOCKDATERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYDAYRF";
                        sqlCommand.CommandText += ", IVD.LISTPRICEFLRF"; // ADD 2011/01/11
                        sqlCommand.CommandText += ", IVD.INVENTORYPREPRDAYRF";
                        sqlCommand.CommandText += ", IVD.INVENTORYPREPRTIMRF";
                        sqlCommand.CommandText += ", IVD.LASTINVENTORYUPDATERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYDATERF";
                        sqlCommand.CommandText += ", IVD.STOCKTOTALEXECRF";
                        sqlCommand.CommandText += ", IVD.TOLERANCEUPDATECDRF";
                        sqlCommand.CommandText += ", IVD.SHIPCUSTOMERCODERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYNEWDIVRF";
                        sqlCommand.CommandText += ", SEC.SECTIONGUIDENMRF";
                        sqlCommand.CommandText += ", WH.WAREHOUSENAMERF";
                        sqlCommand.CommandText += ", MAK.MAKERNAMERF";
                        sqlCommand.CommandText += ", USRGDL.GUIDENAMERF";
                        sqlCommand.CommandText += ", BLGR.BLGROUPNAMERF";
                        sqlCommand.CommandText += ", USRGDE.GUIDENAMERF";
                        sqlCommand.CommandText += ", GGR.GOODSMGROUPNAMERF";
                        //sqlCommand.CommandText += ", GOODS.GOODSNAMERF"; // DEL 2011/01/11
                        sqlCommand.CommandText += ", IVD.GOODSNAMERF"; // ADD 2011/01/11
                        //sqlCommand.CommandText += ", GOODS.GOODSNAMERF"; // ADD 2011/02/12   //DEL yangyi 2013/03/01 Redmine#34175
                        sqlCommand.CommandText += ", CTM.NAMERF";
                        sqlCommand.CommandText += ", CTM.NAME2RF";
                        sqlCommand.CommandText += ", BLCD.BLGOODSFULLNAMERF";
                        sqlCommand.CommandText += ",IVD.STOCKMASHINEPRICERF";
                        sqlCommand.CommandText += ",IVD.INVENTORYSTOCKPRICERF";
                        sqlCommand.CommandText += ",IVD.INVENTORYTLRNCPRICERF";
                        sqlCommand.CommandText += " HAVING SUM(IVD.INVENTORYTOLERANCCNTRF) <> 0";


                        #endregion
                    }
                    else
                    {
                        #region GROUP ②
                        //sqlCommand.CommandText += " GROUP BY IVD.SECTIONCODERF, SEC.SECTIONGUIDENMRF, IVD.WAREHOUSECODERF, IVD.WAREHOUSENAMERF, IVD.WAREHOUSESHELFNORF, IVD.DUPLICATIONSHELFNO1RF, IVD.DUPLICATIONSHELFNO2RF, IVD.GOODSMAKERCDRF, IVD.MAKERNAMERF, IVD.GOODSNORF, IVD.GOODSNAMERF, IVD.LARGEGOODSGANRECODERF, IVD.LARGEGOODSGANRENAMERF, IVD.MEDIUMGOODSGANRECODERF, IVD.MEDIUMGOODSGANRENAMERF, IVD.DETAILGOODSGANRECODERF, IVD.DETAILGOODSGANRENAMERF, IVD.ENTERPRISEGANRECODERF, IVD.ENTERPRISEGANRENAMERF, IVD.BLGOODSCODERF, IVD.SUPPLIERCDRF, IVD.CUSTOMERNAMERF, IVD.CUSTOMERNAME2RF, IVD.JANRF, IVD.STOCKUNITPRICEFLRF, IVD.BFSTOCKUNITPRICEFLRF, IVD.STKUNITPRICECHGFLGRF, IVD.LASTSTOCKDATERF, IVD.INVENTORYPREPRDAYRF, IVD.INVENTORYPREPRTIMRF, IVD.INVENTORYDAYRF, IVD.LASTINVENTORYUPDATERF, IVD.STOCKUNITPRICEFLRF, IVD.INVENTORYDATERF, IVD.STOCKTOTALEXECRF, IVD.TOLERANCEUPDATECDRF, IVD.STOCKDIVRF";
                        sqlCommand.CommandText += " GROUP BY IVD.SECTIONCODERF";
                        sqlCommand.CommandText += ", IVD.WAREHOUSECODERF";
                        sqlCommand.CommandText += ", IVD.GOODSMAKERCDRF";
                        sqlCommand.CommandText += ", IVD.GOODSNORF";
                        sqlCommand.CommandText += ", IVD.WAREHOUSESHELFNORF";
                        sqlCommand.CommandText += ", IVD.DUPLICATIONSHELFNO1RF";
                        sqlCommand.CommandText += ", IVD.DUPLICATIONSHELFNO2RF";
                        sqlCommand.CommandText += ", IVD.GOODSLGROUPRF";
                        sqlCommand.CommandText += ", IVD.GOODSMGROUPRF";
                        sqlCommand.CommandText += ", IVD.BLGROUPCODERF";
                        sqlCommand.CommandText += ", IVD.ENTERPRISEGANRECODERF";
                        sqlCommand.CommandText += ", IVD.BLGOODSCODERF";
                        sqlCommand.CommandText += ", IVD.SUPPLIERCDRF";
                        sqlCommand.CommandText += ", IVD.JANRF";
                        sqlCommand.CommandText += ", IVD.STOCKUNITPRICEFLRF";
                        sqlCommand.CommandText += ", IVD.BFSTOCKUNITPRICEFLRF";
                        sqlCommand.CommandText += ", IVD.STKUNITPRICECHGFLGRF";
                        sqlCommand.CommandText += ", IVD.STOCKDIVRF";
                        sqlCommand.CommandText += ", IVD.LASTSTOCKDATERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYDAYRF";
                        sqlCommand.CommandText += ", IVD.LASTINVENTORYUPDATERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYDATERF";
                        sqlCommand.CommandText += ", IVD.LISTPRICEFLRF"; // ADD 2011/01/11
                        sqlCommand.CommandText += ", IVD.INVENTORYPREPRDAYRF";
                        sqlCommand.CommandText += ", IVD.INVENTORYPREPRTIMRF";
                        sqlCommand.CommandText += ", IVD.STOCKTOTALEXECRF";
                        sqlCommand.CommandText += ", IVD.TOLERANCEUPDATECDRF";
                        sqlCommand.CommandText += ", IVD.SHIPCUSTOMERCODERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYNEWDIVRF";
                        sqlCommand.CommandText += ", SEC.SECTIONGUIDENMRF";
                        sqlCommand.CommandText += ", WH.WAREHOUSENAMERF";
                        sqlCommand.CommandText += ", MAK.MAKERNAMERF";
                        sqlCommand.CommandText += ", USRGDL.GUIDENAMERF";
                        sqlCommand.CommandText += ", BLGR.BLGROUPNAMERF";
                        sqlCommand.CommandText += ", USRGDE.GUIDENAMERF";
                        sqlCommand.CommandText += ", GGR.GOODSMGROUPNAMERF";
                        //sqlCommand.CommandText += ", GOODS.GOODSNAMERF"; // DEL 2011/01/11
                        sqlCommand.CommandText += ", IVD.GOODSNAMERF"; // ADD 2011/01/11
                        //sqlCommand.CommandText += ", GOODS.GOODSNAMERF"; // ADD 2011/02/12    //DEL yangyi 2013/03/01 Redmine#34175
                        sqlCommand.CommandText += ", CTM.NAMERF";
                        sqlCommand.CommandText += ", CTM.NAME2RF";
                        sqlCommand.CommandText += ", BLCD.BLGOODSFULLNAMERF";
                        sqlCommand.CommandText += ",IVD.STOCKMASHINEPRICERF";
                        sqlCommand.CommandText += ",IVD.INVENTORYSTOCKPRICERF";
                        sqlCommand.CommandText += ",IVD.INVENTORYTLRNCPRICERF";
                        #endregion
                    }
                }
                else
                {
                    // 1:棚卸差異表、2:棚卸表
                    if (_inventInputSearchCndtnWork.DifCntExtraDiv != 0)
                    {                       
                        #region GROUP ③
                        //sqlCommand.CommandText += " GROUP BY IVD.SECTIONCODERF, SEC.SECTIONGUIDENMRF, IVD.WAREHOUSECODERF, IVD.WAREHOUSENAMERF, IVD.WAREHOUSESHELFNORF, IVD.DUPLICATIONSHELFNO1RF, IVD.DUPLICATIONSHELFNO2RF, IVD.GOODSMAKERCDRF, IVD.MAKERNAMERF, IVD.GOODSNORF, IVD.GOODSNAMERF, IVD.LARGEGOODSGANRECODERF, IVD.LARGEGOODSGANRENAMERF, IVD.MEDIUMGOODSGANRECODERF, IVD.MEDIUMGOODSGANRENAMERF, IVD.DETAILGOODSGANRECODERF, IVD.DETAILGOODSGANRENAMERF, IVD.ENTERPRISEGANRECODERF, IVD.ENTERPRISEGANRENAMERF, IVD.BLGOODSCODERF, IVD.SUPPLIERCDRF, IVD.CUSTOMERNAMERF, IVD.CUSTOMERNAME2RF, IVD.JANRF, IVD.STOCKUNITPRICEFLRF, IVD.BFSTOCKUNITPRICEFLRF, IVD.STKUNITPRICECHGFLGRF, IVD.LASTSTOCKDATERF, IVD.INVENTORYDAYRF, IVD.LASTINVENTORYUPDATERF, IVD.STOCKUNITPRICEFLRF, IVD.INVENTORYDATERF, IVD.STOCKTOTALEXECRF, IVD.TOLERANCEUPDATECDRF, IVD.STOCKDIVRF HAVING SUM(IVD.INVENTORYTOLERANCCNTRF) <> 0";
                        sqlCommand.CommandText += " GROUP BY IVD.SECTIONCODERF";
                        sqlCommand.CommandText += ", IVD.WAREHOUSECODERF";
                        sqlCommand.CommandText += ", IVD.GOODSMAKERCDRF";
                        sqlCommand.CommandText += ", IVD.GOODSNORF";
                        sqlCommand.CommandText += ", IVD.WAREHOUSESHELFNORF";
                        sqlCommand.CommandText += ", IVD.DUPLICATIONSHELFNO1RF";
                        sqlCommand.CommandText += ", IVD.DUPLICATIONSHELFNO2RF";
                        sqlCommand.CommandText += ", IVD.GOODSLGROUPRF";
                        sqlCommand.CommandText += ", IVD.GOODSMGROUPRF";
                        sqlCommand.CommandText += ", IVD.BLGROUPCODERF";
                        sqlCommand.CommandText += ", IVD.ENTERPRISEGANRECODERF";
                        sqlCommand.CommandText += ", IVD.BLGOODSCODERF";
                        sqlCommand.CommandText += ", IVD.SUPPLIERCDRF";
                        sqlCommand.CommandText += ", IVD.JANRF";
                        sqlCommand.CommandText += ", IVD.STOCKUNITPRICEFLRF";
                        sqlCommand.CommandText += ", IVD.BFSTOCKUNITPRICEFLRF";
                        sqlCommand.CommandText += ", IVD.STKUNITPRICECHGFLGRF";
                        sqlCommand.CommandText += ", IVD.STOCKDIVRF";
                        sqlCommand.CommandText += ", IVD.LASTSTOCKDATERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYDAYRF";
                        sqlCommand.CommandText += ", IVD.LASTINVENTORYUPDATERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYDATERF";
                        sqlCommand.CommandText += ", IVD.STOCKTOTALEXECRF";
                        sqlCommand.CommandText += ", IVD.TOLERANCEUPDATECDRF";
                        sqlCommand.CommandText += ", IVD.SHIPCUSTOMERCODERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYNEWDIVRF";
                        sqlCommand.CommandText += ", SEC.SECTIONGUIDENMRF";
                        sqlCommand.CommandText += ", WH.WAREHOUSENAMERF";
                        sqlCommand.CommandText += ", MAK.MAKERNAMERF";
                        sqlCommand.CommandText += ", USRGDL.GUIDENAMERF";
                        sqlCommand.CommandText += ", BLGR.BLGROUPNAMERF";
                        sqlCommand.CommandText += ", USRGDE.GUIDENAMERF";
                        sqlCommand.CommandText += ", GGR.GOODSMGROUPNAMERF";
                        //sqlCommand.CommandText += ", GOODS.GOODSNAMERF"; // DEL 2011/01/11
                        sqlCommand.CommandText += ", IVD.GOODSNAMERF"; // ADD 2011/01/11
                        //sqlCommand.CommandText += ", GOODS.GOODSNAMERF"; // ADD 2011/02/12   //DEL yangyi 2013/03/01 Redmine#34175
                        sqlCommand.CommandText += ", CTM.NAMERF";
                        sqlCommand.CommandText += ", CTM.NAME2RF";
                        sqlCommand.CommandText += ", BLCD.BLGOODSFULLNAMERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYSTOCKPRICERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYTLRNCPRICERF";
                        sqlCommand.CommandText += " HAVING SUM(IVD.INVENTORYTOLERANCCNTRF) <> 0";
                        #endregion
                    }
                    else
                    {                       
                        #region GROUP ④
                        //sqlCommand.CommandText += " GROUP BY IVD.SECTIONCODERF, SEC.SECTIONGUIDENMRF, IVD.WAREHOUSECODERF, IVD.WAREHOUSENAMERF, IVD.WAREHOUSESHELFNORF, IVD.DUPLICATIONSHELFNO1RF, IVD.DUPLICATIONSHELFNO2RF, IVD.GOODSMAKERCDRF, IVD.MAKERNAMERF, IVD.GOODSNORF, IVD.GOODSNAMERF, IVD.LARGEGOODSGANRECODERF, IVD.LARGEGOODSGANRENAMERF, IVD.MEDIUMGOODSGANRECODERF, IVD.MEDIUMGOODSGANRENAMERF, IVD.DETAILGOODSGANRECODERF, IVD.DETAILGOODSGANRENAMERF, IVD.ENTERPRISEGANRECODERF, IVD.ENTERPRISEGANRENAMERF, IVD.BLGOODSCODERF, IVD.SUPPLIERCDRF, IVD.CUSTOMERNAMERF, IVD.CUSTOMERNAME2RF, IVD.JANRF, IVD.STOCKUNITPRICEFLRF, IVD.BFSTOCKUNITPRICEFLRF, IVD.STKUNITPRICECHGFLGRF, IVD.LASTSTOCKDATERF, IVD.INVENTORYDAYRF, IVD.LASTINVENTORYUPDATERF, IVD.STOCKUNITPRICEFLRF, IVD.INVENTORYDATERF, IVD.STOCKTOTALEXECRF, IVD.TOLERANCEUPDATECDRF, IVD.STOCKDIVRF";
                        sqlCommand.CommandText += " GROUP BY IVD.SECTIONCODERF";
                        sqlCommand.CommandText += ", IVD.WAREHOUSECODERF";
                        sqlCommand.CommandText += ", IVD.GOODSMAKERCDRF";
                        sqlCommand.CommandText += ", IVD.GOODSNORF";
                        sqlCommand.CommandText += ", IVD.WAREHOUSESHELFNORF";
                        sqlCommand.CommandText += ", IVD.DUPLICATIONSHELFNO1RF";
                        sqlCommand.CommandText += ", IVD.DUPLICATIONSHELFNO2RF";
                        sqlCommand.CommandText += ", IVD.GOODSLGROUPRF";
                        sqlCommand.CommandText += ", IVD.GOODSMGROUPRF";
                        sqlCommand.CommandText += ", IVD.BLGROUPCODERF";
                        sqlCommand.CommandText += ", IVD.ENTERPRISEGANRECODERF";
                        sqlCommand.CommandText += ", IVD.BLGOODSCODERF";
                        sqlCommand.CommandText += ", IVD.SUPPLIERCDRF";
                        sqlCommand.CommandText += ", IVD.JANRF";
                        sqlCommand.CommandText += ", IVD.STOCKUNITPRICEFLRF";
                        sqlCommand.CommandText += ", IVD.BFSTOCKUNITPRICEFLRF";
                        sqlCommand.CommandText += ", IVD.STKUNITPRICECHGFLGRF";
                        sqlCommand.CommandText += ", IVD.STOCKDIVRF";
                        sqlCommand.CommandText += ", IVD.LASTSTOCKDATERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYDAYRF";
                        sqlCommand.CommandText += ", IVD.LASTINVENTORYUPDATERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYDATERF";
                        sqlCommand.CommandText += ", IVD.STOCKTOTALEXECRF";
                        sqlCommand.CommandText += ", IVD.TOLERANCEUPDATECDRF";
                        sqlCommand.CommandText += ", IVD.SHIPCUSTOMERCODERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYNEWDIVRF";
                        sqlCommand.CommandText += ", SEC.SECTIONGUIDENMRF";
                        sqlCommand.CommandText += ", WH.WAREHOUSENAMERF";
                        sqlCommand.CommandText += ", MAK.MAKERNAMERF";
                        sqlCommand.CommandText += ", USRGDL.GUIDENAMERF";
                        sqlCommand.CommandText += ", BLGR.BLGROUPNAMERF";
                        sqlCommand.CommandText += ", USRGDE.GUIDENAMERF";
                        sqlCommand.CommandText += ", GGR.GOODSMGROUPNAMERF";
                        //sqlCommand.CommandText += ", GOODS.GOODSNAMERF"; // DEL 2011/01/11
                        sqlCommand.CommandText += ", IVD.GOODSNAMERF"; // ADD 2011/01/11
                        //sqlCommand.CommandText += ", GOODS.GOODSNAMERF"; // ADD 2011/02/12   //DEL yangyi 2013/03/01 Redmine#34175
                        sqlCommand.CommandText += ", CTM.NAMERF";
                        sqlCommand.CommandText += ", CTM.NAME2RF";
                        sqlCommand.CommandText += ", BLCD.BLGOODSFULLNAMERF";
                        sqlCommand.CommandText += ", IVD.STOCKMASHINEPRICERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYSTOCKPRICERF";
                        sqlCommand.CommandText += ", IVD.INVENTORYTLRNCPRICERF";
                        // -------------ADD 2010/03/02------------->>>>>
                        // 棚卸表
                        if (_inventInputSearchCndtnWork.SelectedPaperKind == 2)
                        {
                            //sqlCommand.CommandText += ", GOODSPRICE.PRICESTARTDATERF";  //DEL yangyi 2013/03/01 Redmine#34175
                            //sqlCommand.CommandText += ", GOODSPRICE.LISTPRICERF" + Environment.NewLine; // DEL 2011/01/11
                            sqlCommand.CommandText += ", IVD.LISTPRICEFLRF" + Environment.NewLine; // ADD 2011/01/11
                            //sqlCommand.CommandText += ", GOODSPRICE.LISTPRICERF" + Environment.NewLine; // ADD 2011/02/12  //DEL yangyi 2013/03/01 Redmine#34175
                            sqlCommand.CommandText += " ORDER BY IVD_SECTIONCODERF, IVD_WAREHOUSECODERF, IVD_GOODSMAKERCDRF, IVD_GOODSNORF, IVD_WAREHOUSESHELFNORF";
                            sqlCommand.CommandText +=", IVD_DUPLICATIONSHELFNO1RF, IVD_DUPLICATIONSHELFNO2RF, IVD_GOODSLGROUPRF, IVD_GOODSMGROUPRF";
                            sqlCommand.CommandText +=", IVD_BLGROUPCODERF, IVD_ENTERPRISEGANRECODERF, IVD_BLGOODSCODERF, IVD_SUPPLIERCDRF, IVD_JANRF";
                            sqlCommand.CommandText +=", IVD_STOCKUNITPRICEFLRF, IVD_BFSTOCKUNITPRICEFLRF, IVD_STKUNITPRICECHGFLGRF, IVD_STOCKDIVRF, IVD_LASTSTOCKDATERF";
                            sqlCommand.CommandText +=", IVD_INVENTORYDAYRF, IVD_LASTINVENTORYUPDATERF, IVD_INVENTORYDATERF, IVD_STOCKTOTALEXECRF";
                            sqlCommand.CommandText +=", IVD_TOLERANCEUPDATECDRF, IVD_SHIPCUSTOMERCODERF, IVD_INVENTORYNEWDIVRF, SEC_SECTIONGUIDENMRF";
                            sqlCommand.CommandText +=", WH_WAREHOUSENAMERF, MAK_MAKERNAMERF, USRGDL_GUIDENAMERF, BLGR_BLGROUPNAMERF, USRGDE_GUIDENAMERF";
                            // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                            //sqlCommand.CommandText +=", GGR_GOODSMGROUPNAMERF, GOODS_GOODSNAMERF, CTM_NAMERF, CTM_NAME2RF, BLCD_BLGOODSFULLNAMERF";
                            //sqlCommand.CommandText +=", IVD_STOCKMASHINEPRICERF, IVD_INVENTORYSTOCKPRICERF, IVD_INVENTORYTLRNCPRICERF, GOODSPRICE.PRICESTARTDATERF DESC";
                            // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
                            // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                            sqlCommand.CommandText += ", GGR_GOODSMGROUPNAMERF, CTM_NAMERF, CTM_NAME2RF, BLCD_BLGOODSFULLNAMERF";
                            sqlCommand.CommandText += ", IVD_STOCKMASHINEPRICERF, IVD_INVENTORYSTOCKPRICERF, IVD_INVENTORYTLRNCPRICERF DESC";
                            // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
                        }
                        // -------------ADD 2010/03/02-------------<<<<<
                        #endregion
                    }
                }

                sqlCommand.CommandTimeout = 300; // ADD 2012/07/26 高峰 印刷時エラーの対応
                //結果取得
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    InventInputSearchResultWork wkInventInputSearchResultWork = new InventInputSearchResultWork();

                    wkInventInputSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                    wkInventInputSearchResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTIONGUIDENMRF"));
                    wkInventInputSearchResultWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                    wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                    wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH_WAREHOUSENAMERF"));
                    wkInventInputSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                    wkInventInputSearchResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAK_MAKERNAMERF"));
                    wkInventInputSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                    wkInventInputSearchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                    wkInventInputSearchResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                    wkInventInputSearchResultWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO1RF"));
                    wkInventInputSearchResultWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO2RF"));
                    wkInventInputSearchResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSLGROUPRF"));
                    wkInventInputSearchResultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRGDL_GUIDENAMERF"));
                    wkInventInputSearchResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMGROUPRF"));
                    wkInventInputSearchResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GGR_GOODSMGROUPNAMERF"));
                    wkInventInputSearchResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGROUPCODERF"));
                    wkInventInputSearchResultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGR_BLGROUPNAMERF"));
                    wkInventInputSearchResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_ENTERPRISEGANRECODERF"));
                    wkInventInputSearchResultWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRGDE_GUIDENAMERF"));
                    wkInventInputSearchResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGOODSCODERF"));
                    wkInventInputSearchResultWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLCD_BLGOODSFULLNAMERF"));
                    wkInventInputSearchResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SUPPLIERCDRF"));
                    wkInventInputSearchResultWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_JANRF"));
                    wkInventInputSearchResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                    wkInventInputSearchResultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                    wkInventInputSearchResultWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                    wkInventInputSearchResultWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STOCKDIVRF"));
                    wkInventInputSearchResultWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTSTOCKDATERF"));
                    wkInventInputSearchResultWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));
                    wkInventInputSearchResultWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SHIPCUSTOMERCODERF"));
                    wkInventInputSearchResultWork.ShipCustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTM_NAMERF"));
                    wkInventInputSearchResultWork.ShipCustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTM_NAME2RF"));
                    wkInventInputSearchResultWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                    wkInventInputSearchResultWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                    wkInventInputSearchResultWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                    wkInventInputSearchResultWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                    wkInventInputSearchResultWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYNEWDIVRF"));
                    // 2008.12.01 復活 >>>
                    wkInventInputSearchResultWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_STOCKMASHINEPRICERF"));
                    wkInventInputSearchResultWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKPRICERF"));
                    wkInventInputSearchResultWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYTLRNCPRICERF"));
                    // 2008.12.01 復活 <<<
                    wkInventInputSearchResultWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDATERF"));
                    wkInventInputSearchResultWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALEXECRF"));
                    wkInventInputSearchResultWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_TOLERANCEUPDATECDRF"));

                    if ((_inventInputSearchCndtnWork.SelectedPaperKind != 1) && (_inventInputSearchCndtnWork.SelectedPaperKind != 2))
                    {
						//wkInventInputSearchResultWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_LISTPRICEFLRF")); // ADD 2011/01/11 // DEL 2011/02/15
                        wkInventInputSearchResultWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRDAYRF"));
                        wkInventInputSearchResultWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRTIMRF"));
                    }
                    // --------------ADD 2010/03/02------------>>>>>
                    wkInventInputSearchResultWork.ListPrice = 0.0;
                    // 棚卸表
                    if (_inventInputSearchCndtnWork.SelectedPaperKind == 2)
                    {
                        wkInventInputSearchResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPC_LISTPRICERF"));// ADD 2010/03/02
                    }
                    // --------------ADD 2010/03/02------------<<<<<

                    // ---------- ADD 2011/02/12 -------------------->>>>>
                    // 棚卸データを取得時、１レコード目の品名が空白（NULL）だった場合は、既存の処理で品名・定価を取得する。
					// --------------------- UPD 2011/02/15 ------------------------>>>>>
					//if (wkInventInputSearchResultWork.GoodsName == string.Empty && !"ｶｼﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))

                    // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                    //// --------------------- UPD 2011/02/15 ------------------------<<<<<
                    //if (wkInventInputSearchResultWork.GoodsName == string.Empty)
                    //{
                    //    wkInventInputSearchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF_NEW"));

                    //    // 棚卸表
                    //    if (_inventInputSearchCndtnWork.SelectedPaperKind == 2)
                    //    {
                    //        wkInventInputSearchResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPC_LISTPRICERF_NEW"));
                    //    }
                    //}
                    //// ---------- ADD 2011/02/12 --------------------<<<<<
                    // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                    #endregion

                    // --------------UPD 2010/03/02------------>>>>>
                    //al.Add(wkInventInputSearchResultWork);
                    //alcopy.Add(wkInventInputSearchResultWork);// ADD 2009/11/30
                    // 棚卸表
                    if (_inventInputSearchCndtnWork.SelectedPaperKind == 2)
                    {
                        string key = KeySet(wkInventInputSearchResultWork);
                        if (!filterDic.ContainsKey(key))
                        {
                            // ----- UPD 2011/01/11 ------------------------------------------------------->>>>>
                            //filterDic.Add(key, wkInventInputSearchResultWork);
                            //al.Add(wkInventInputSearchResultWork);
                            //alcopy.Add(wkInventInputSearchResultWork);// ADD 2009/11/30

                            // ①貸出データ抽出区分（0:印刷しない,1:印刷する） ②来勘計上分データ抽出区分（0:印刷しない,1:印刷する）
                            if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                            {
                                filterDic.Add(key, wkInventInputSearchResultWork);
                                al.Add(wkInventInputSearchResultWork);
                                alcopy.Add(wkInventInputSearchResultWork);
                            }
                            else if (_inventInputSearchCndtnWork.LendExtraDiv == 0 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                            {
                                // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。
                                if (!"ｶｼﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                                {
                                    filterDic.Add(key, wkInventInputSearchResultWork);
                                    al.Add(wkInventInputSearchResultWork);
                                    alcopy.Add(wkInventInputSearchResultWork);
                                }
                            }
                            else if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 0)
                            {
                                // 棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                                if (!"ｻｷﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                                {
                                    filterDic.Add(key, wkInventInputSearchResultWork);
                                    al.Add(wkInventInputSearchResultWork);
                                    alcopy.Add(wkInventInputSearchResultWork);
                                }
                            }
                            else
                            {
                                // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                                if (!"ｶｼﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                                {
                                    filterDic.Add(key, wkInventInputSearchResultWork);
                                    al.Add(wkInventInputSearchResultWork);
                                    alcopy.Add(wkInventInputSearchResultWork);
                                }
                            }
                            // ----- UPD 2011/01/11 -------------------------------------------------------<<<<<
                        }
                    }
                    // ----- UPD 2011/01/11 ---------------------------------------------------------------------->>>>>
                    // 棚卸差異表と棚卸調査表
                    else
                    {
                        // ①貸出データ抽出区分（0:印刷しない,1:印刷する） ②来勘計上分データ抽出区分（0:印刷しない,1:印刷する）
                        if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                        {
                            al.Add(wkInventInputSearchResultWork);
                            alcopy.Add(wkInventInputSearchResultWork);
                        }
                        else if (_inventInputSearchCndtnWork.LendExtraDiv == 0 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1) 
                        {
                            // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｶｼﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventInputSearchResultWork);
                                alcopy.Add(wkInventInputSearchResultWork);
                            }
                        }
                        else if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 0)
                        {
                            // 棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｻｷﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventInputSearchResultWork);
                                alcopy.Add(wkInventInputSearchResultWork);
                            }
                        }
                        else
                        {
                            // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｶｼﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(wkInventInputSearchResultWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventInputSearchResultWork);
                                alcopy.Add(wkInventInputSearchResultWork);
                            }
                        }
                    }
                    //else
                    //{
                    //    al.Add(wkInventInputSearchResultWork);
                    //    alcopy.Add(wkInventInputSearchResultWork);// ADD 2009/11/30
                    //}
                    // ----- UPD 2011/01/11 ----------------------------------------------------------------------<<<<<
                    // --------------UPD 2010/03/02------------<<<<<
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // ----- DEL 2011/01/11 ---------------------------------------------------------------------->>>>>
                #region 削除分
                //// ADD 2008/09/09 >>>
                //// 棚卸調査表
                //if (_inventInputSearchCndtnWork.SelectedPaperKind == 0)
                //{
                //    #region 貸出分データ抽出
                //    // 貸出データ抽出区分  0:印刷しない,1:印刷する
                    
                //    if (_inventInputSearchCndtnWork.LendExtraDiv == 1)
                //    {
                //        if (!myReader.IsClosed) myReader.Close();
                //        myReader = null;
                //        sqlCommand = null;
                //        ArrayList resultList = new ArrayList();// ADD 2009/12/25

                //        // 対象テーブル 売上データ・売上明細データ
                //        // SalesSlipRF・SalesDetailRF 
                //        SelectDm = "";

                //        #region SELECT分作成
                //        SelectDm += "SELECT" + Environment.NewLine;
                //        SelectDm += " MAIN.ENTERPRISECODERF MAIN_ENTERPRISECODERF" + Environment.NewLine;   // 企業コード
                //        SelectDm += ", MAIN.SECTIONCODERF MAIN_SECTIONCODERF" + Environment.NewLine;        // 拠点コード
                //        SelectDm += ", MAIN.WAREHOUSECODERF MAIN_WAREHOUSECODERF" + Environment.NewLine;    // 倉庫コード
                //        SelectDm += ", MAIN.GOODSMAKERCDRF MAIN_GOODSMAKERCDRF" + Environment.NewLine;      // 商品メーカーコード
                //        SelectDm += ", MAIN.GOODSNORF MAIN_GOODSNORF" + Environment.NewLine;                // 商品コード
                //        SelectDm += ", MAIN.BLGROUPCODERF MAIN_BLGROUPCODERF" + Environment.NewLine;        // BLグループコード
                //        SelectDm += ", MAIN.BLGOODSCODERF MAIN_BLGOODSCODERF" + Environment.NewLine;        // BLコード
                //        SelectDm += ", MAIN.SUPPLIERCDRF MAIN_SUPPLIERCDRF" + Environment.NewLine;          // 仕入先コード
                //        SelectDm += ", ACPTANODRREMAINCNTRF" + Environment.NewLine;                         // 発注残数
                //        SelectDm += ", WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称
                //        SelectDm += ", MAK.MAKERNAMERF MAK_MAKERNAMERF" + Environment.NewLine;              // メーカーマスタ・メーカー名称
                //        SelectDm += ", BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;        // グループコードマスタ・グループコード名称
                //        //SelectDm += ", GOODS.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;          // BLコードマスタ・BLコード名称  //DEL 2009/11/30
                //        SelectDm += ", BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;// 商品マスタ・商品名称
                //        SelectDm += ", SEC.SECTWAREHOUSECD1RF SEC_SECTWAREHOUSECD1RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫１
                //        SelectDm += ", WH1.WAREHOUSENAMERF WH1_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫１)
                //        SelectDm += ", SEC.SECTWAREHOUSECD2RF SEC_SECTWAREHOUSECD2RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫２
                //        SelectDm += ", WH2.WAREHOUSENAMERF WH2_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫２)
                //        SelectDm += ", SEC.SECTWAREHOUSECD3RF SEC_SECTWAREHOUSECD3RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫３
                //        SelectDm += ", WH3.WAREHOUSENAMERF WH3_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫３)
                //        // --- ADD 2009/11/30 ---------->>>>>
                //        SelectDm += ", MAIN.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;           //原価単価
                //        SelectDm += ", MAIN.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                //        SelectDm += ", MAIN.GOODS_GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                //        // --- ADD 2009/11/30 ----------<<<<<

                //        SelectDm += "FROM" + Environment.NewLine;
                //        SelectDm += "(" + Environment.NewLine;
                //        SelectDm += "SELECT" + Environment.NewLine;
                //        SelectDm += "SLS.ENTERPRISECODERF ENTERPRISECODERF" + Environment.NewLine;
                //        SelectDm += ", SLS.SECTIONCODERF SECTIONCODERF" + Environment.NewLine;
                //        SelectDm += ", SLD.WAREHOUSECODERF WAREHOUSECODERF" + Environment.NewLine;
                //        SelectDm += ", SLD.GOODSMAKERCDRF GOODSMAKERCDRF" + Environment.NewLine;
                //        SelectDm += ", SLD.GOODSNORF GOODSNORF" + Environment.NewLine;
                //        SelectDm += ", SLD.BLGROUPCODERF BLGROUPCODERF" + Environment.NewLine;
                //        SelectDm += ", SLD.BLGOODSCODERF BLGOODSCODERF" + Environment.NewLine;
                //        SelectDm += ", SLD.SUPPLIERCDRF SUPPLIERCDRF" + Environment.NewLine;
                //        SelectDm += ", SUM(SLD.ACPTANODRREMAINCNTRF) ACPTANODRREMAINCNTRF" + Environment.NewLine;
                //        // --- ADD 2009/11/30 ---------->>>>>
                //        SelectDm += ", SLD.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;
                //        SelectDm += ", SLD.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                //        SelectDm += ", SLD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                //        // --- ADD 2009/11/30 ----------<<<<<

                //        SelectDm += " FROM SALESSLIPRF AS SLS" + Environment.NewLine;
                //        SelectDm += "LEFT JOIN " + Environment.NewLine;
                //        SelectDm += " SALESDETAILRF AS SLD" + Environment.NewLine;
                //        SelectDm += " ON" + Environment.NewLine;
                //        SelectDm += " SLS.ENTERPRISECODERF = SLD.ENTERPRISECODERF AND" + Environment.NewLine;
                //        SelectDm += " SLS.ACPTANODRSTATUSRF = SLD.ACPTANODRSTATUSRF AND" + Environment.NewLine;
                //        SelectDm += " SLS.SALESSLIPNUMRF = SLD.SALESSLIPNUMRF" + Environment.NewLine;
                //        #endregion

                //        #region WHERE文の作成
                //        SelectDm += " WHERE" + Environment.NewLine;
                //        SelectDm += " SLS.ACPTANODRSTATUSRF = 40 AND " + Environment.NewLine;
                //        SelectDm += " SLD.GOODSNORF  != ''" + Environment.NewLine;

                //        sqlCommand = new SqlCommand(SelectDm, sqlConnection);


                //        //企業コード設定
                //        sqlCommand.CommandText += " AND SLS.ENTERPRISECODERF=@ENTERPRISECODE";
                //        SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                //        paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.EnterpriseCode);

                //        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                //            (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                //        {
                //            sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                //        }
                //        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                //        {
                //            sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                //            if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                //            else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                //        }
                //        // DEL 2009/06/01 貸出データは全ての日付期間を有効にする >>>
                //        ////棚卸日
                //        //if (_inventInputSearchCndtnWork.InventoryDate != DateTime.MinValue)
                //        //{
                //        //    int InventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", _inventInputSearchCndtnWork.InventoryDate);
                //        //    sqlCommand.CommandText += " AND SLS.SHIPMENTDAYRF <= " + InventoryDate.ToString() + Environment.NewLine;
                //        //}
                //        // DEL 2009/06/01 <<<
                //        if (_inventInputSearchCndtnWork.WarehouseDiv == 0) // 倉庫指定区分 0:範囲,1:単独
                //        {

                //            //倉庫コード設定
                //            if (_inventInputSearchCndtnWork.St_WarehouseCode != "")
                //            {
                //                sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                //                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                //                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseCode);
                //            }
                //            if (_inventInputSearchCndtnWork.Ed_WarehouseCode != "")
                //            {
                //                //sqlCommand.CommandText += " AND (SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE OR SLD.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)" + Environment.NewLine; // 2008.10.08 DEL 
                //                sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE " + Environment.NewLine;                                                 // 2008.10.08 ADD
                //                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                //                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseCode + "%");
                //            }
                //        }
                //        else
                //        {
                //            #region 倉庫１～10
                //            if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd09 != "" || _inventInputSearchCndtnWork.WarehouseCd10 != "")
                //            {
                //                sqlCommand.CommandText += " AND ( ";
                //            }

                //            //倉庫コード01設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd01 != "")
                //            {
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD01";
                //                SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                //                paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd01);
                //            }

                //            //倉庫コード02設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd02 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD02";
                //                SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                //                paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd02);
                //            }

                //            //倉庫コード03設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd03 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }

                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD03";
                //                SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                //                paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd03);
                //            }

                //            //倉庫コード04設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd04 != "")
                //            {

                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD04";
                //                SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                //                paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd04);
                //            }

                //            //倉庫コード05設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd05 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD05";
                //                SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                //                paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd05);
                //            }

                //            //倉庫コード06設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd06 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }

                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD06";
                //                SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                //                paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd06);
                //            }

                //            //倉庫コード07設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd07 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD07";
                //                SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                //                paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd07);
                //            }

                //            //倉庫コード08設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd08 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd07 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD08";
                //                SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                //                paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd08);
                //            }

                //            //倉庫コード09設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd09 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD09";
                //                SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                //                paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd09);
                //            }

                //            //倉庫コード10設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd10 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd09 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD10";
                //                SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                //                paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd10);
                //            }
                //            if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd09 != "" || _inventInputSearchCndtnWork.WarehouseCd10 != "")
                //            {
                //                sqlCommand.CommandText += " ) ";
                //            }
                //            #endregion
                //        }

                //        //棚番設定
                //        if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
                //        {
                //            sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                //            SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                //            paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
                //        {
                //            //sqlCommand.CommandText += " AND (SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR SLD.WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO)" + Environment.NewLine; // 2008.10.08 DEL
                //            sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO " + Environment.NewLine;   // 2008.10.08 ADD 
                //            SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                //            //paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo + "%"); // 2008.10.08 DEL
                //            paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo );        // 2008.10.08 ADD 
                //        }

                //        //仕入先コード設定
                //        if (_inventInputSearchCndtnWork.St_SupplierCd != 0)
                //        {
                //            sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
                //            SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                //            paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_SupplierCd);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_SupplierCd != 999999)
                //        {
                //            sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
                //            SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                //            paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_SupplierCd);
                //        }
                //        //ＢＬ商品コード設定
                //        if (_inventInputSearchCndtnWork.St_BLGoodsCode != 0)
                //        {
                //            sqlCommand.CommandText += " AND SLD.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                //            SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                //            paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_BLGoodsCode);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_BLGoodsCode != 99999)
                //        {
                //            sqlCommand.CommandText += " AND SLD.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                //            SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                //            paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_BLGoodsCode);
                //        }

                //        // グループコード設定
                //        if (_inventInputSearchCndtnWork.St_BLGroupCode != 0)
                //        {
                //            sqlCommand.CommandText += " AND SLD.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                //            SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                //            paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_BLGroupCode);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_BLGroupCode != 99999)
                //        {
                //            sqlCommand.CommandText += " AND SLD.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                //            SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                //            paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_BLGroupCode);
                //        }
                //        //メーカーコード設定
                //        if (_inventInputSearchCndtnWork.St_MakerCode != 0)
                //        {
                //            sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF>=@STMAKERCODE" + Environment.NewLine;
                //            SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                //            paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_MakerCode);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_MakerCode != 9999)
                //        {
                //            sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF<=@EDMAKERCODE" + Environment.NewLine;
                //            SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                //            paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_MakerCode);
                //        }

                //        // --- ADD 2009/11/30 ---------->>>>>
                //        //受注残数(AcptAnOdrRemainCntRF＝0）は印刷対象外
                //        sqlCommand.CommandText += " AND SLD.ACPTANODRREMAINCNTRF != 0 " + Environment.NewLine;
                //        // --- ADD 2009/11/30 ----------<<<<<
                //        #endregion

                //        #region GROUP文の作成
                //        sqlCommand.CommandText += "GROUP BY " + Environment.NewLine;
                //        sqlCommand.CommandText += "SLS.ENTERPRISECODERF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLS.SECTIONCODERF" + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.WAREHOUSECODERF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.GOODSMAKERCDRF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.GOODSNORF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.BLGROUPCODERF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.BLGOODSCODERF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.SUPPLIERCDRF " + Environment.NewLine;
                //        // --- ADD 2009/11/30 ---------->>>>>
                //        sqlCommand.CommandText += ", SLD.SALESUNITCOSTRF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.LISTPRICETAXEXCFLRF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.GOODSNAMERF " + Environment.NewLine;
                //        // --- ADD 2009/11/30 ----------<<<<<
                //        sqlCommand.CommandText += ")AS MAIN " + Environment.NewLine;
                //        #endregion

                //        #region LEFT JOIN文の作成
                //        // 拠点情報設定マスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " SEC.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                //        sqlCommand.CommandText += " SEC.SECTIONCODERF=MAIN.SECTIONCODERF" + Environment.NewLine;
                //        // 倉庫マスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " WH.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                //        sqlCommand.CommandText += " WH.WAREHOUSECODERF=MAIN.WAREHOUSECODERF" + Environment.NewLine;
                //        // 倉庫マスタ結合(優先倉庫１)
                //        sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " WH1.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                //        sqlCommand.CommandText += " WH1.WAREHOUSECODERF=SEC.SECTWAREHOUSECD1RF" + Environment.NewLine;
                //        // 倉庫マスタ結合(優先倉庫２)
                //        sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " WH2.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                //        sqlCommand.CommandText += " WH2.WAREHOUSECODERF=SEC.SECTWAREHOUSECD2RF" + Environment.NewLine;
                //        // 倉庫マスタ結合(優先倉庫３)
                //        sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " WH3.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                //        sqlCommand.CommandText += " WH3.WAREHOUSECODERF=SEC.SECTWAREHOUSECD3RF" + Environment.NewLine;
                //        // メーカーマスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " MAK.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                //        sqlCommand.CommandText += " MAK.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF" + Environment.NewLine;

                //        // --- DEL 2009/11/30 ---------->>>>>
                //        // 商品マスタ結合
                //        //sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS ON" + Environment.NewLine;
                //        //sqlCommand.CommandText += " GOODS.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                //        //sqlCommand.CommandText += " GOODS.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF AND" + Environment.NewLine;
                //        //sqlCommand.CommandText += " GOODS.GOODSNORF=MAIN.GOODSNORF" + Environment.NewLine;
                //        // --- DEL 2009/11/30 ----------<<<<<

                //        // グループコードマスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " BLGR.BLGROUPCODERF=MAIN.BLGROUPCODERF" + Environment.NewLine;
                //        // 2010/06/18 Add >>>
                //        sqlCommand.CommandText += " AND BLGR.ENTERPRISECODERF=MAIN.ENTERPRISECODERF";
                //        // 2010/06/18 Add <<<
                //        // BLコードマスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " BLCD.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                //        sqlCommand.CommandText += " BLCD.BLGOODSCODERF = MAIN.BLGOODSCODERF" + Environment.NewLine;

                //        #endregion
                        
                //        //結果取得
                //        myReader = sqlCommand.ExecuteReader();

                //        while (myReader.Read())
                //        {
                //            #region 抽出結果セット
                //            InventInputSearchResultWork wkInventInputSearchResultWork = new InventInputSearchResultWork();
                //            wkInventInputSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));
                //            wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF"));
                //            wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH_WAREHOUSENAMERF"));
                //            wkInventInputSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));
                //            wkInventInputSearchResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAK_MAKERNAMERF"));
                //            wkInventInputSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                //            // -------------ADD 2009/12/25------------>>>>>
                //            wkInventInputSearchResultWork.GoodsNoSrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                //            // -------------ASS 2009/12/25------------<<<<<
                //            wkInventInputSearchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                //            wkInventInputSearchResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));
                //            wkInventInputSearchResultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGR_BLGROUPNAMERF"));
                //            wkInventInputSearchResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));
                //            wkInventInputSearchResultWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLCD_BLGOODSFULLNAMERF"));
                //            wkInventInputSearchResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_SUPPLIERCDRF"));
                //            wkInventInputSearchResultWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                //            wkInventInputSearchResultWork.InventoryDate = _inventInputSearchCndtnWork.InventoryDate;
                //            wkInventInputSearchResultWork.WarehouseShelfNo = "ｶｼﾀﾞｼ";
                //            // --- ADD 2009/11/30 ---------->>>>>
                //            wkInventInputSearchResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                //            wkInventInputSearchResultWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                //            // --- ADD 2009/11/30 ----------<<<<<

                //            // --- UPD 2009/11/30 ---------->>>>>
                //            //if (wkInventInputSearchResultWork.WarehouseCode == null)
                //            if (string.IsNullOrEmpty(wkInventInputSearchResultWork.WarehouseCode))
                //            {
                //                wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD1RF"));
                //                wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH1_WAREHOUSENAMERF"));
                //            }
                //            //if (wkInventInputSearchResultWork.WarehouseCode == null)
                //            if (string.IsNullOrEmpty(wkInventInputSearchResultWork.WarehouseCode))
                //            {
                //                wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD2RF"));
                //                wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH2_WAREHOUSENAMERF"));                               
                //            }
                //            //if (wkInventInputSearchResultWork.WarehouseCode == null)
                //            if (string.IsNullOrEmpty(wkInventInputSearchResultWork.WarehouseCode))
                //            {
                //                wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD3RF"));
                //                wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH3_WAREHOUSENAMERF"));
                //            }

                //            //if (wkInventInputSearchResultWork.WarehouseCode != null)
                //            if (!string.IsNullOrEmpty(wkInventInputSearchResultWork.WarehouseCode))
                //            // --- UPD 2009/11/30 ----------<<<<<
                //            {
                //                // --- UPD 2009/11/30 ---------->>>>>
                //                //al.Add(wkInventInputSearchResultWork);
                //                resultList.Add(wkInventInputSearchResultWork);
                //                // --- UPD 2009/11/30 ----------<<<<<
                //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //            }
                //            #endregion
                //        }

                //        SortData(resultList, ref al);// ADD 2009/12/25

                //        SortDataOrder(ref al);// ADD 2009/12/25
                //    }
                //    #endregion
                    
                //    #region 来勘計上分データ抽出
                //    // 来勘計上分データ抽出区分  0:印刷しない,1:印刷する
                //    if (_inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                //    {
                //        if (!myReader.IsClosed) myReader.Close(); 
                //        myReader = null;
                //        sqlCommand = null;
                //        ArrayList resultList = new ArrayList();// ADD 2009/12/25

                //        // 対象テーブル 売上データ・売上明細データ
                //        // SalesSlipRF・SalesDetailRF 
                //        SelectDm = "";

                //        #region SELECT分作成
                //        SelectDm += "SELECT" + Environment.NewLine;
                //        SelectDm += " MAIN.ENTERPRISECODERF MAIN_ENTERPRISECODERF" + Environment.NewLine;   // 企業コード
                //        SelectDm += ", MAIN.SECTIONCODERF MAIN_SECTIONCODERF" + Environment.NewLine;        // 拠点コード
                //        SelectDm += ", MAIN.WAREHOUSECODERF MAIN_WAREHOUSECODERF" + Environment.NewLine;    // 倉庫コード
                //        SelectDm += ", MAIN.GOODSMAKERCDRF MAIN_GOODSMAKERCDRF" + Environment.NewLine;      // 商品メーカーコード
                //        SelectDm += ", MAIN.GOODSNORF MAIN_GOODSNORF" + Environment.NewLine;                // 商品コード
                //        SelectDm += ", MAIN.BLGROUPCODERF MAIN_BLGROUPCODERF" + Environment.NewLine;        // BLグループコード
                //        SelectDm += ", MAIN.BLGOODSCODERF MAIN_BLGOODSCODERF" + Environment.NewLine;        // BLコード
                //        SelectDm += ", MAIN.SUPPLIERCDRF MAIN_SUPPLIERCDRF" + Environment.NewLine;          // 仕入先コード
                //        SelectDm += ", ACPTANODRREMAINCNTRF" + Environment.NewLine;                         // 発注残数
                //        SelectDm += ", WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称
                //        SelectDm += ", MAK.MAKERNAMERF MAK_MAKERNAMERF" + Environment.NewLine;              // メーカーマスタ・メーカー名称
                //        SelectDm += ", BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;        // グループコードマスタ・グループコード名称
                //        //SelectDm += ", GOODS.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;          // BLコードマスタ・BLコード名称
                //        SelectDm += ", BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;// 商品マスタ・商品名称
                //        SelectDm += ", SEC.SECTWAREHOUSECD1RF SEC_SECTWAREHOUSECD1RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫１
                //        SelectDm += ", WH1.WAREHOUSENAMERF WH1_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫１)
                //        SelectDm += ", SEC.SECTWAREHOUSECD2RF SEC_SECTWAREHOUSECD2RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫２
                //        SelectDm += ", WH2.WAREHOUSENAMERF WH2_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫２)
                //        SelectDm += ", SEC.SECTWAREHOUSECD3RF SEC_SECTWAREHOUSECD3RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫３
                //        SelectDm += ", WH3.WAREHOUSENAMERF WH3_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫３)
                //        // --- ADD 2009/11/30 ---------->>>>>
                //        SelectDm += ", MAIN.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;
                //        SelectDm += ", MAIN.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                //        SelectDm += ", MAIN.GOODS_GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                //        SelectDm += ", SHIPMENTCNTRF " + Environment.NewLine;
                //        // --- ADD 2009/11/30 ----------<<<<<

                //        SelectDm += "FROM" + Environment.NewLine;
                //        SelectDm += "(" + Environment.NewLine;
                //        SelectDm += "SELECT" + Environment.NewLine;
                //        SelectDm += "SLS.ENTERPRISECODERF ENTERPRISECODERF" + Environment.NewLine;
                //        SelectDm += ", SLS.SECTIONCODERF SECTIONCODERF" + Environment.NewLine;
                //        SelectDm += ", SLD.WAREHOUSECODERF WAREHOUSECODERF" + Environment.NewLine;
                //        SelectDm += ", SLD.GOODSMAKERCDRF GOODSMAKERCDRF" + Environment.NewLine;
                //        SelectDm += ", SLD.GOODSNORF GOODSNORF" + Environment.NewLine;
                //        SelectDm += ", SLD.BLGROUPCODERF BLGROUPCODERF" + Environment.NewLine;
                //        SelectDm += ", SLD.BLGOODSCODERF BLGOODSCODERF" + Environment.NewLine;
                //        SelectDm += ", SLD.SUPPLIERCDRF SUPPLIERCDRF" + Environment.NewLine;
                //        SelectDm += ", SUM(SLD.ACPTANODRREMAINCNTRF) ACPTANODRREMAINCNTRF" + Environment.NewLine;
                //        // --- ADD 2009/11/30 ---------->>>>>
                //        SelectDm += ", SUM(SLD.SHIPMENTCNTRF) SHIPMENTCNTRF" + Environment.NewLine;
                //        SelectDm += ", SLD.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;
                //        SelectDm += ", SLD.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                //        SelectDm += ", SLD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                //        // --- ADD 2009/11/30 ----------<<<<<

                //        SelectDm += " FROM SALESSLIPRF AS SLS" + Environment.NewLine;
                //        SelectDm += "LEFT JOIN " + Environment.NewLine;
                //        SelectDm += " SALESDETAILRF AS SLD" + Environment.NewLine;
                //        SelectDm += " ON" + Environment.NewLine;
                //        SelectDm += " SLS.ENTERPRISECODERF = SLD.ENTERPRISECODERF AND" + Environment.NewLine;
                //        SelectDm += " SLS.ACPTANODRSTATUSRF = SLD.ACPTANODRSTATUSRF AND" + Environment.NewLine;
                //        SelectDm += " SLS.SALESSLIPNUMRF = SLD.SALESSLIPNUMRF" + Environment.NewLine;
                //        #endregion

                //        #region WHERE文の作成
                //        SelectDm += " WHERE" + Environment.NewLine;
                //        SelectDm += " SLS.ACPTANODRSTATUSRF = 30 AND " + Environment.NewLine;
                //        SelectDm += " SLD.GOODSNORF  != ''" + Environment.NewLine;

                //        sqlCommand = new SqlCommand(SelectDm, sqlConnection);


                //        //企業コード設定
                //        sqlCommand.CommandText += " AND SLS.ENTERPRISECODERF=@ENTERPRISECODE";
                //        SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                //        paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.EnterpriseCode);

                //        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                //            (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                //        {
                //            sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                //        }
                //        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                //        {
                //            sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                //            if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                //            else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                //        }

                //        //棚卸日
                //        if (_inventInputSearchCndtnWork.InventoryDate != DateTime.MinValue)
                //        {
                //            int InventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", _inventInputSearchCndtnWork.InventoryDate);
                //            sqlCommand.CommandText += " AND SLS.ADDUPADATERF > " + InventoryDate.ToString() + Environment.NewLine;
                //        }
                //        // DEL 2009/06/01 棚卸日+1 以降を全て対象に変更 >>>>
                //        //// 棚卸実施日(システム日付)
                //        //if (DateTime.Now != DateTime.MinValue)
                //        //{
                //        //    int InventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.Now) ;
                //        //    sqlCommand.CommandText += " AND SLS.ADDUPADATERF <= " + InventoryDate.ToString() + Environment.NewLine;
                //        //}
                //        // DEL 2009/06/01 <<<

                //        if (_inventInputSearchCndtnWork.WarehouseDiv == 0) // 倉庫指定区分 0:範囲,1:単独
                //        {
                //            //倉庫コード設定
                //            if (_inventInputSearchCndtnWork.St_WarehouseCode != "")
                //            {
                //                sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                //                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                //                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseCode);
                //            }
                //            if (_inventInputSearchCndtnWork.Ed_WarehouseCode != "")
                //            {
                //                //sqlCommand.CommandText += " AND (SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE OR SLD.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)" + Environment.NewLine; // 2008.10.08 DEL
                //                sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE " + Environment.NewLine;   // 2008.10.08 ADD 
                //                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                //                //paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseCode + "%"); // 2008.10.08 DEL
                //                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseCode);   // 2008.10.08 ADD
                //            }
                //        }
                //        else
                //        {
                //            #region 単独倉庫指定
                //            if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd09 != "" || _inventInputSearchCndtnWork.WarehouseCd10 != "")
                //            {
                //                sqlCommand.CommandText += " AND ( ";
                //            }

                //            //倉庫コード01設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd01 != "")
                //            {
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD01";
                //                SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                //                paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd01);
                //            }

                //            //倉庫コード02設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd02 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD02";
                //                SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                //                paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd02);
                //            }

                //            //倉庫コード03設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd03 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }

                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD03";
                //                SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                //                paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd03);
                //            }

                //            //倉庫コード04設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd04 != "")
                //            {

                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD04";
                //                SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                //                paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd04);
                //            }

                //            //倉庫コード05設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd05 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD05";
                //                SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                //                paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd05);
                //            }

                //            //倉庫コード06設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd06 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }

                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD06";
                //                SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                //                paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd06);
                //            }

                //            //倉庫コード07設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd07 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD07";
                //                SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                //                paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd07);
                //            }

                //            //倉庫コード08設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd08 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd07 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD08";
                //                SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                //                paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd08);
                //            }

                //            //倉庫コード09設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd09 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD09";
                //                SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                //                paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd09);
                //            }

                //            //倉庫コード10設定
                //            if (_inventInputSearchCndtnWork.WarehouseCd10 != "")
                //            {
                //                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                //                    _inventInputSearchCndtnWork.WarehouseCd09 != "")
                //                {
                //                    sqlCommand.CommandText += " OR ";
                //                }
                //                sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD10";
                //                SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                //                paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd10);
                //            }
                //            if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                //                _inventInputSearchCndtnWork.WarehouseCd09 != "" || _inventInputSearchCndtnWork.WarehouseCd10 != "")
                //            {
                //                sqlCommand.CommandText += " ) ";
                //            }
                //            #endregion

                //        }

                //        //棚番設定
                //        if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
                //        {
                //            sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                //            SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                //            paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
                //        {
                //            //sqlCommand.CommandText += " AND (SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR SLD.WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO)" + Environment.NewLine; // 2008.10.08 DEL
                //            sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO " + Environment.NewLine;                                                       // 2008.10.08 ADD 
                //            SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                //            //paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo );    // 2008.10.08 DEL            
                //            paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo );      // 2008.10.08 ADD
                //        }

                //        //仕入先コード設定
                //        if (_inventInputSearchCndtnWork.St_SupplierCd != 0)
                //        {
                //            sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
                //            SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                //            paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_SupplierCd);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_SupplierCd != 999999)
                //        {
                //            sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
                //            SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                //            paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_SupplierCd);
                //        }
                //        //ＢＬ商品コード設定
                //        if (_inventInputSearchCndtnWork.St_BLGoodsCode != 0)
                //        {
                //            sqlCommand.CommandText += " AND SLD.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                //            SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                //            paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_BLGoodsCode);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_BLGoodsCode != 99999)
                //        {
                //            sqlCommand.CommandText += " AND SLD.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                //            SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                //            paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_BLGoodsCode);
                //        }

                //        // グループコード設定
                //        if (_inventInputSearchCndtnWork.St_BLGroupCode != 0)
                //        {
                //            sqlCommand.CommandText += " AND SLD.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                //            SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                //            paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_BLGroupCode);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_BLGroupCode != 99999)
                //        {
                //            sqlCommand.CommandText += " AND SLD.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                //            SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                //            paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_BLGroupCode);
                //        }
                //        //メーカーコード設定
                //        if (_inventInputSearchCndtnWork.St_MakerCode != 0)
                //        {
                //            sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF>=@STMAKERCODE" + Environment.NewLine;
                //            SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                //            paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_MakerCode);
                //        }
                //        if (_inventInputSearchCndtnWork.Ed_MakerCode != 999)
                //        {
                //            sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF<=@EDMAKERCODE" + Environment.NewLine;
                //            SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                //            paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_MakerCode);
                //        }

                //        #endregion

                //        #region GROUP文の作成
                //        sqlCommand.CommandText += "GROUP BY " + Environment.NewLine;
                //        sqlCommand.CommandText += "SLS.ENTERPRISECODERF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLS.SECTIONCODERF" + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.WAREHOUSECODERF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.GOODSMAKERCDRF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.GOODSNORF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.BLGROUPCODERF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.BLGOODSCODERF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.SUPPLIERCDRF " + Environment.NewLine;
                //        // --- ADD 2009/11/30 ---------->>>>>
                //        sqlCommand.CommandText += ", SLD.SALESUNITCOSTRF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.LISTPRICETAXEXCFLRF " + Environment.NewLine;
                //        sqlCommand.CommandText += ", SLD.GOODSNAMERF " + Environment.NewLine;
                //        // --- ADD 2009/11/30 ----------<<<<<
                //        sqlCommand.CommandText += ")AS MAIN " + Environment.NewLine;
                //        #endregion

                //        #region LEFT JOIN文の作成
                //        // 拠点情報設定マスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " SEC.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                //        sqlCommand.CommandText += " SEC.SECTIONCODERF=MAIN.SECTIONCODERF" + Environment.NewLine;
                //        // 倉庫マスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " WH.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                //        sqlCommand.CommandText += " WH.WAREHOUSECODERF=MAIN.WAREHOUSECODERF" + Environment.NewLine;
                //        // 倉庫マスタ結合(優先倉庫１)
                //        sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " WH1.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                //        sqlCommand.CommandText += " WH1.WAREHOUSECODERF=SEC.SECTWAREHOUSECD1RF" + Environment.NewLine;
                //        // 倉庫マスタ結合(優先倉庫２)
                //        sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " WH2.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                //        sqlCommand.CommandText += " WH2.WAREHOUSECODERF=SEC.SECTWAREHOUSECD2RF" + Environment.NewLine;
                //        // 倉庫マスタ結合(優先倉庫３)
                //        sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " WH3.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                //        sqlCommand.CommandText += " WH3.WAREHOUSECODERF=SEC.SECTWAREHOUSECD3RF" + Environment.NewLine;
                //        // メーカーマスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " MAK.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                //        sqlCommand.CommandText += " MAK.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF" + Environment.NewLine;
                //        // --- DEL 2009/11/30 ---------->>>>>
                //        // 商品マスタ結合
                //        //sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS ON" + Environment.NewLine;
                //        //sqlCommand.CommandText += " GOODS.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                //        //sqlCommand.CommandText += " GOODS.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF AND" + Environment.NewLine;
                //        //sqlCommand.CommandText += " GOODS.GOODSNORF=MAIN.GOODSNORF" + Environment.NewLine;
                //        // --- DEL 2009/11/30 ----------<<<<<
                //        // グループコードマスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " BLGR.BLGROUPCODERF=MAIN.BLGROUPCODERF" + Environment.NewLine;
                //        // 2010/06/18 Add >>>
                //        sqlCommand.CommandText += " AND BLGR.ENTERPRISECODERF=MAIN.ENTERPRISECODERF";
                //        // 2010/06/18 Add <<<
                //        // BLコードマスタ結合
                //        sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD ON" + Environment.NewLine;
                //        sqlCommand.CommandText += " BLCD.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                //        sqlCommand.CommandText += " BLCD.BLGOODSCODERF = MAIN.BLGOODSCODERF" + Environment.NewLine;

                //        #endregion


                //        //結果取得
                //        myReader = sqlCommand.ExecuteReader();

                //        while (myReader.Read())
                //        {
                //            #region 抽出結果セット
                //            InventInputSearchResultWork wkInventInputSearchResultWork = new InventInputSearchResultWork();
                //            wkInventInputSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));
                //            wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF"));
                //            wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH_WAREHOUSENAMERF"));
                //            wkInventInputSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));
                //            wkInventInputSearchResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAK_MAKERNAMERF"));
                //            wkInventInputSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                //            // -------------ADD 2009/12/25------------>>>>>
                //            wkInventInputSearchResultWork.GoodsNoSrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                //            // -------------ASS 2009/12/25------------<<<<<
                //            wkInventInputSearchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                //            wkInventInputSearchResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));
                //            wkInventInputSearchResultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGR_BLGROUPNAMERF"));
                //            wkInventInputSearchResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));
                //            wkInventInputSearchResultWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLCD_BLGOODSFULLNAMERF"));
                //            wkInventInputSearchResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_SUPPLIERCDRF"));
                //            wkInventInputSearchResultWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                //            wkInventInputSearchResultWork.InventoryDate = _inventInputSearchCndtnWork.InventoryDate;
                //            wkInventInputSearchResultWork.WarehouseShelfNo = "ｻｷﾀﾞｼ";
                //            // --- ADD 2009/11/30 ---------->>>>>
                //            wkInventInputSearchResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                //            wkInventInputSearchResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                //            wkInventInputSearchResultWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                //            // --- ADD 2009/11/30 ----------<<<<<

                //            // --- UPD 2009/11/30 ---------->>>>>
                //            //if (wkInventInputSearchResultWork.WarehouseCode == null)
                //            if (string.IsNullOrEmpty(wkInventInputSearchResultWork.WarehouseCode))
                //            {
                //                wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD1RF"));
                //                wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH1_WAREHOUSENAMERF"));
                //            }
                //            //if (wkInventInputSearchResultWork.WarehouseCode == null)
                //            if (string.IsNullOrEmpty(wkInventInputSearchResultWork.WarehouseCode))
                //            {
                //                wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD2RF"));
                //                wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH2_WAREHOUSENAMERF"));
                //            }
                //            //if (wkInventInputSearchResultWork.WarehouseCode == null)
                //            if (string.IsNullOrEmpty(wkInventInputSearchResultWork.WarehouseCode))
                //            {
                //                wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD3RF"));
                //                wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH3_WAREHOUSENAMERF"));
                //            }

                //            //if (wkInventInputSearchResultWork.WarehouseCode != null)
                //            if (!string.IsNullOrEmpty(wkInventInputSearchResultWork.WarehouseCode))
                //            // --- UPD 2009/11/30 ----------<<<<<
                //            {
                //                // -----------UPD 2009/12/25----------->>>>>
                //                //al.Add(wkInventInputSearchResultWork);
                //                resultList.Add(wkInventInputSearchResultWork);
                //                // -----------UPD 2009/12/25-----------<<<<<
                //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //            }
                //            #endregion
                //        }
                //        SortData(resultList, ref al);// ADD 2009/12/25

                //        SortDataOrder(ref al);// ADD 2009/12/25
                //    }
                //    #endregion
                     
                //}
                //// ADD 2008/09/09 <<<
                #endregion
                // ----- DEL 2011/01/11 ----------------------------------------------------------------------<<<<<

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.SearchGrossAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// ディクショナリキー
        /// </summary>
        /// <param name="WarehouseCode">倉庫コード</param>
        /// <param name="GoodsMakerCd">メーカーコード</param>
        /// <param name="GoodsNo">商品番号</param>
        /// <returns>dicキー</returns>
        /// <remarks>
        /// <br>Note       : ディクショナリキー処理します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.11.30</br>
        /// </remarks>
        private string KeyofDic(string WarehouseCode, int GoodsMakerCd, string GoodsNo, string WarehouseShelfNo)
        {
            return (WarehouseCode + "." + GoodsMakerCd.ToString("%06d") + "." + GoodsNo + WarehouseShelfNo);
        }

        /// <summary>
        /// ディクショナリキー
        /// </summary>
        /// <param name="InventInputSearchResultWork">結果work</param>
        /// <returns>dicキー</returns>
        /// <remarks>
        /// <br>Note       : ディクショナリキー処理します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/02</br>
        /// </remarks>
        private string KeySet(InventInputSearchResultWork work)
        {
            return (work.SectionCode + "-" + work.SectionGuideNm + "-" + work.InventorySeqNo + "-" +
                work.WarehouseCode + "-" + work.WarehouseName + "-" + work.GoodsMakerCd + "-" +
            work.MakerName + "-" + work.GoodsNo + "-" + work.GoodsName + "-" +
            work.WarehouseShelfNo + "-" + work.DuplicationShelfNo1 + "-" + work.DuplicationShelfNo2 + "-" +
            work.GoodsLGroup + "-" + work.GoodsLGroupName + "-" + work.GoodsMGroup + "-" +
            work.GoodsMGroupName + "-" + work.BLGroupCode + "-" + work.BLGroupName + "-" +
            work.EnterpriseGanreCode + "-" + work.EnterpriseGanreName + "-" + work.BLGoodsCode + "-" +
            work.BLGoodsName + "-" + work.SupplierCd + "-" + work.Jan + "-" +
            work.StockUnitPriceFl + "-" + work.BfStockUnitPriceFl + "-" + work.StkUnitPriceChgFlg + "-" +
            work.StockDiv + "-" + work.LastStockDate + "-" + work.StockTotal + "-" +
            work.ShipCustomerCode + "-" + work.ShipCustomerName + "-" + work.ShipCustomerName2 + "-" +
            work.InventoryStockCnt + "-" + work.InventoryDay + "-" + work.LastInventoryUpdate + "-" +
            work.InventoryNewDiv + "-" + work.StockMashinePrice + "-" + work.InventoryStockPrice + "-" +
            work.InventoryTlrncPrice + "-" + work.InventoryDate + "-" + work.StockTotalExec + "-" +
            work.ToleranceUpdateCd + "-" + work.InventoryTolerancCnt);
        }
        #endregion

        #region SearchCount
        /// <summary>
        /// 棚卸件数検索
        /// </summary>
        /// <param name="count">棚卸マスタ件数</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸マスタの件数検索を行うメソッドです。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.06</br>
        /// <br>Update     : 2007.09.13 Yokokawa  流通.NS 用に改造</br>
        public int SearchCount(out int count, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            return this.SearchCountProc(out count, paraobj, readMode, logicalMode);
        }

        /// <summary>
        /// 棚卸件数検索
        /// </summary>
        /// <param name="count">棚卸マスタ件数</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸マスタの件数検索を行うメソッドです。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.06</br>
        /// <br>Update     : 2007.09.13 Yokokawa  流通.NS 用に改造</br>
        private int SearchCountProc( out int count, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode )
        {
            count = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList al = new ArrayList();
            InventInputSearchCndtnWork _inventInputSearchCndtnWork = paraobj as InventInputSearchCndtnWork;
            SqlConnection sqlConnection = null;
            int ProductNumberOutPutDiv = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                // DEL 2009/06/01 >>>
                //Dictionary<string, InventInputSearchResultWork> skipDic = new Dictionary<string, InventInputSearchResultWork>();
                //if (_inventInputSearchCndtnWork.SelectedPaperKind == 0)
                //{
                //    SkipSearch(out skipDic, _inventInputSearchCndtnWork, ref sqlConnection);
                //}
                // DEL 2009/06/01 <<<

                // 対象テーブル
                // INVENTORYDATARF 棚卸データ
                //string SelectDm = " SELECT COUNT(*) INVENTORYDATA_COUNT FROM INVENTORYDATARF IVD";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                string SelectDm = " SELECT COUNT(*) INVENTORYDATA_COUNT FROM INVENTORYDATARF IVD WITH (READUNCOMMITTED) ";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼

                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _inventInputSearchCndtnWork, ProductNumberOutPutDiv, logicalMode);

                // DEL 2009/06/01 過不足更新区分を参照するように修正 >>>
                //if (skipDic.Count > 0)
                //{
                //    int skipDicCount = 0;
                //    foreach (InventInputSearchResultWork skipInventInputSearchResultWork in skipDic.Values)
                //    {
                //        sqlCommand.CommandText += " AND (IVD.GOODSMAKERCDRF!=@GOODSMAKERCD" + skipDicCount.ToString() + " OR IVD.GOODSNORF!=@GOODSNO" + skipDicCount.ToString() + ")";

                //        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + skipDicCount.ToString(), SqlDbType.Int);
                //        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(skipInventInputSearchResultWork.GoodsMakerCd);
                //        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO" + skipDicCount.ToString(), SqlDbType.NVarChar);
                //        paraGoodsNo.Value = SqlDataMediator.SqlSetString(skipInventInputSearchResultWork.GoodsNo);
                //        skipDicCount++;
                //    }
                //} 
                // DEL 2009/06/01 <<<

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    count = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYDATA_COUNT"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.SearchCount:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (( myReader != null ) && ( myReader.IsClosed == false ))
                    myReader.Close();

                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }
            return status;
        }
        #endregion

        #region SkipSearch
        /// <summary>
        /// 棚卸関連非表示項目検索
        /// </summary>
        /// <param name="skipDic">棚卸マスタ件数</param>
        /// <param name="_inventInputSearchCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸マスタの非表示項目を取得するクラスです。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.07.24</br>
        /// <br>Update     : 2007.09.13 Yokokawa  流通.NS 用に改造</br>
        private int SkipSearch(out Dictionary<string, InventInputSearchResultWork> skipDic, InventInputSearchCndtnWork _inventInputSearchCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            skipDic = new Dictionary<string, InventInputSearchResultWork>();

            try
            {
                // 対象テーブル
                // INVENTORYDATARF 棚卸データ
                // 2008/09/09 修正 >>>
                // string SelectDm = " SELECT GOODSMAKERCDRF IVD_GOODSMAKERCDRF, GOODSNORF IVD_GOODSNORF  FROM INVENTORYDATARF IVD WHERE IVD.ENTERPRISECODERF=@ENTERPRISECODE AND IVD.SECTIONCODERF=@SECTIONCODE AND (IVD.LASTINVENTORYUPDATERF!=10101 OR IVD.LASTINVENTORYUPDATERF IS NOT NULL)";
                //string SelectDm = " SELECT GOODSMAKERCDRF IVD_GOODSMAKERCDRF, GOODSNORF IVD_GOODSNORF  FROM INVENTORYDATARF IVD WHERE IVD.ENTERPRISECODERF=@ENTERPRISECODE AND (IVD.LASTINVENTORYUPDATERF!=10101 OR IVD.LASTINVENTORYUPDATERF IS NOT NULL)";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                string SelectDm = " SELECT GOODSMAKERCDRF IVD_GOODSMAKERCDRF, GOODSNORF IVD_GOODSNORF  FROM INVENTORYDATARF IVD WITH (READUNCOMMITTED) WHERE IVD.ENTERPRISECODERF=@ENTERPRISECODE AND (IVD.LASTINVENTORYUPDATERF!=10101 OR IVD.LASTINVENTORYUPDATERF IS NOT NULL)";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                // 2008/09/09 <<<

                //拠点コード設定
                if ((_inventInputSearchCndtnWork.St_SectionCode != "00") && (_inventInputSearchCndtnWork.St_SectionCode != ""))
                {
                    SelectDm += " AND IVD.SECTIONCODERF>=@STSECTIONCODE " + Environment.NewLine;
                    SqlParameter findParaStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                    findParaStSectionCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_SectionCode);

                }
                if ((_inventInputSearchCndtnWork.Ed_SectionCode != "00") && (_inventInputSearchCndtnWork.Ed_SectionCode != ""))
                {
                    SelectDm += " AND IVD.SECTIONCODERF<=@EDSECTIONCODE " + Environment.NewLine;
                    SqlParameter findParaEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                    findParaEdSectionCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_SectionCode);
                }
                // 2008/09/09 <<<

                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.EnterpriseCode);
                // DEL 2008/09/09 範囲指定になるため削除 >>>
                //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                //findParaSectionCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.SectionCode);
                // DEL 2008/09/09 <<<

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    InventInputSearchResultWork inventInputSearchResultWork = new InventInputSearchResultWork();
                    inventInputSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                    inventInputSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));

                    if (!skipDic.ContainsKey(inventInputSearchResultWork.GoodsMakerCd + "-" + inventInputSearchResultWork.GoodsNo))
                    {
                        skipDic.Add(inventInputSearchResultWork.GoodsMakerCd + "-" + inventInputSearchResultWork.GoodsNo, inventInputSearchResultWork);
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.SkipSearch:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 横川 昌令</br>
        /// <br>Date       : 2007.09.13</br>
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
        #endregion


        #region WHERE文作成
        /// <summary>
        /// 検索条件文作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_inventInputSearchCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns></returns>
        public string MakeWhereString(ref SqlCommand sqlCommand, InventInputSearchCndtnWork _inventInputSearchCndtnWork, int productNumberOutPutDiv, ConstantManagement.LogicalMode logicalMode)
        {
            return this.MakeWhereStringProc(ref sqlCommand, _inventInputSearchCndtnWork, productNumberOutPutDiv, logicalMode);
        }

        /// <summary>
        /// 検索条件文作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_inventInputSearchCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns></returns>
        /// <br>Update Note: 2009/11/30 張凱 保守依頼③対応</br>
        /// <br>Update Note: 2011/01/11 liyp １、貸出分の印刷がされない不具合の修正  ２、出力条件に数量と棚番に関する条件指定を追加する（要望）</br>
        private string MakeWhereStringProc( ref SqlCommand sqlCommand, InventInputSearchCndtnWork _inventInputSearchCndtnWork, int productNumberOutPutDiv, ConstantManagement.LogicalMode logicalMode )
        {
            string retstring = " WHERE ";

            //企業コード設定
            retstring += " IVD.ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.EnterpriseCode);

            if (( logicalMode == ConstantManagement.LogicalMode.GetData0 ) || ( logicalMode == ConstantManagement.LogicalMode.GetData1 ) ||
                ( logicalMode == ConstantManagement.LogicalMode.GetData2 ) || ( logicalMode == ConstantManagement.LogicalMode.GetData3 ))
            {
                retstring += " AND IVD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if (( logicalMode == ConstantManagement.LogicalMode.GetData01 ) || ( logicalMode == ConstantManagement.LogicalMode.GetData012 ))
            {
                retstring += " AND IVD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //拠点コード設定
            if (( _inventInputSearchCndtnWork.St_SectionCode != "00" ) && ( _inventInputSearchCndtnWork.St_SectionCode != "" ))
            {
                retstring += " AND IVD.SECTIONCODERF>=@STSECTIONCODE ";
                SqlParameter findParaStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                findParaStSectionCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_SectionCode);
            }
            if ((_inventInputSearchCndtnWork.Ed_SectionCode != "00") && (_inventInputSearchCndtnWork.Ed_SectionCode != ""))
            {
                retstring += " AND IVD.SECTIONCODERF<=@EDSECTIONCODE ";
                SqlParameter findParaEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                findParaEdSectionCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_SectionCode);
            }

            //メーカーコード設定
            if (_inventInputSearchCndtnWork.St_MakerCode != 0)
            {
                retstring += " AND IVD.GOODSMAKERCDRF>=@STMAKERCODE";
                SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_MakerCode);
            }
            if( (_inventInputSearchCndtnWork.Ed_MakerCode != 9999) && (_inventInputSearchCndtnWork.Ed_MakerCode != 0) )
            {
                retstring += " AND IVD.GOODSMAKERCDRF<=@EDMAKERCODE";
                SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_MakerCode);
            }

            //商品番号設定
            if (_inventInputSearchCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND IVD.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_GoodsNo);
            }
            if (_inventInputSearchCndtnWork.Ed_GoodsNo != "")
            {
                //retstring += " AND (IVD.GOODSNORF<=@EDGOODSNO OR IVD.GOODSNORF LIKE @EDGOODSNO)"; // 2008.10.08 DEL
                retstring += " AND IVD.GOODSNORF<=@EDGOODSNO ";                                     // 2008.10.08 ADD
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_GoodsNo + "%");
            }
// DEL 2008/09/08 テーブルレイアウト変更により削除  >>>
 /*
            //商品区分グループコード設定
            if (_inventInputSearchCndtnWork.St_LargeGoodsGanreCode != "")
            {
                retstring += " AND IVD.LARGEGOODSGANRECODERF>=@STLARGEGOODSGANRECODE";
                SqlParameter paraStLargeGoodsGanreCode = sqlCommand.Parameters.Add("@STLARGEGOODSGANRECODE", SqlDbType.NChar);
                paraStLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_LargeGoodsGanreCode);
            }
            if (_inventInputSearchCndtnWork.Ed_LargeGoodsGanreCode != "")
            {
                retstring += " AND IVD.LARGEGOODSGANRECODERF<=@EDLARGEGOODSGANRECODE";
                SqlParameter paraEdLargeGoodsGanreCode = sqlCommand.Parameters.Add("@EDLARGEGOODSGANRECODE", SqlDbType.NChar);
                paraEdLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_LargeGoodsGanreCode);
            }

            //商品区分コード設定
            if (_inventInputSearchCndtnWork.St_MediumGoodsGanreCode != "")
            {
                retstring += " AND IVD.MEDIUMGOODSGANRECODERF>=@STMEDIUMGOODSGANRECODE";
                SqlParameter paraStMediumGoodsGanreCode = sqlCommand.Parameters.Add("@STMEDIUMGOODSGANRECODE", SqlDbType.NChar);
                paraStMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_MediumGoodsGanreCode);
            }
            if (_inventInputSearchCndtnWork.Ed_MediumGoodsGanreCode != "")
            {
                retstring += " AND IVD.MEDIUMGOODSGANRECODERF<=@EDMEDIUMGOODSGANRECODE";
                SqlParameter paraEdMediumGoodsGanreCode = sqlCommand.Parameters.Add("@EDMEDIUMGOODSGANRECODE", SqlDbType.NChar);
                paraEdMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_MediumGoodsGanreCode);
            }

            //商品区分詳細コード設定
            if (_inventInputSearchCndtnWork.St_DetailGoodsGanreCode != "")
            {
                retstring += " AND IVD.DETAILGOODSGANRECODERF>=@STDETAILGOODSGANRECODE";
                SqlParameter paraStDetailGoodsGanreCode = sqlCommand.Parameters.Add("@STDETAILGOODSGANRECODE", SqlDbType.NChar);
                paraStDetailGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_DetailGoodsGanreCode);
            }
            if (_inventInputSearchCndtnWork.Ed_DetailGoodsGanreCode != "")
            {
                retstring += " AND IVD.DETAILGOODSGANRECODERF<=@EDDETAILGOODSGANRECODE";
                SqlParameter paraEdDetailGoodsGanreCode = sqlCommand.Parameters.Add("@EDDETAILGOODSGANRECODE", SqlDbType.NChar);
                paraEdDetailGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_DetailGoodsGanreCode);
            }
 */ 
// DEL 2008/09/08 <<<

            if (_inventInputSearchCndtnWork.WarehouseDiv == 0) // 倉庫指定区分 0:範囲,1:単独
            {
                //倉庫コード設定
                if (_inventInputSearchCndtnWork.St_WarehouseCode != "")
                {
                    retstring += " AND IVD.WAREHOUSECODERF>=@STWAREHOUSECODE";
                    SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                    paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseCode);
                }
                if (_inventInputSearchCndtnWork.Ed_WarehouseCode != "")
                {
                    //retstring += " AND (IVD.WAREHOUSECODERF<=@EDWAREHOUSECODE OR IVD.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)"; // 2008.10.08 DEL
                    retstring += " AND IVD.WAREHOUSECODERF<=@EDWAREHOUSECODE";                                                  // 2008.10.08 ADD
                    SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                    //paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseCode + "%");  // 2008.10.08 DEL
                    paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseCode);         // 2008.10.08 ADD   
                }
            }
            else
            {
                #region 倉庫1～10
                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd09 != "" || _inventInputSearchCndtnWork.WarehouseCd10 != "")
                {
                    retstring += " AND ( ";
                }

                //倉庫コード01設定
                if (_inventInputSearchCndtnWork.WarehouseCd01 != "")
                {
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD01";
                    SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                    paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd01);
                }

                //倉庫コード02設定
                if (_inventInputSearchCndtnWork.WarehouseCd02 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "")
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD02";
                    SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                    paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd02);
                }

                //倉庫コード03設定
                if (_inventInputSearchCndtnWork.WarehouseCd03 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" )
                    {
                        retstring += " OR ";
                    }

                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD03";
                    SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                    paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd03);
                }

                //倉庫コード04設定
                if (_inventInputSearchCndtnWork.WarehouseCd04 != "")
                {

                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "")
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD04";
                    SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                    paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd04);
                }

                //倉庫コード05設定
                if (_inventInputSearchCndtnWork.WarehouseCd05 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" )
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD05";
                    SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                    paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd05);
                }

                //倉庫コード06設定
                if (_inventInputSearchCndtnWork.WarehouseCd06 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "" )
                    {
                        retstring += " OR ";
                    }

                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD06";
                    SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                    paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd06);
                }

                //倉庫コード07設定
                if (_inventInputSearchCndtnWork.WarehouseCd07 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" )
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD07";
                    SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                    paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd07);
                }

                //倉庫コード08設定
                if (_inventInputSearchCndtnWork.WarehouseCd08 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd07 != "" )
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD08";
                    SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                    paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd08);
                }

                //倉庫コード09設定
                if (_inventInputSearchCndtnWork.WarehouseCd09 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" )
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD09";
                    SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                    paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd09);
                }

                //倉庫コード10設定
                if (_inventInputSearchCndtnWork.WarehouseCd10 != "")
                {
                    if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                        _inventInputSearchCndtnWork.WarehouseCd09 != "" )
                    {
                        retstring += " OR ";
                    }
                    retstring += " IVD.WAREHOUSECODERF=@WAREHOUSECD10";
                    SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                    paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.WarehouseCd10);
                }
                if (_inventInputSearchCndtnWork.WarehouseCd01 != "" || _inventInputSearchCndtnWork.WarehouseCd02 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd03 != "" || _inventInputSearchCndtnWork.WarehouseCd04 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd05 != "" || _inventInputSearchCndtnWork.WarehouseCd06 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd07 != "" || _inventInputSearchCndtnWork.WarehouseCd08 != "" ||
                    _inventInputSearchCndtnWork.WarehouseCd09 != "" || _inventInputSearchCndtnWork.WarehouseCd10 != "")
                {
                    retstring += " ) ";
                }
                #endregion
            }
            
            // -----------UDP 2011/01/11 ------------------------------->>>>>
            //棚卸表のみ
            if (_inventInputSearchCndtnWork.SelectedPaperKind == 2)
            {
                //棚番出力区分  1:棚番なしのみ出力  2: 棚番なし以外出力
                if (_inventInputSearchCndtnWork.WarehouseShelfOutputDiv != 0)
                {
                    if (_inventInputSearchCndtnWork.WarehouseShelfOutputDiv == 1)
                    {
						// ---------- UPD 2011/02/15 ---------------------------------------->>>>>
                        retstring += " AND IVD.WAREHOUSESHELFNORF IS NULL ";
                        //SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        //paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);
						
						if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
						{
							retstring += " AND IVD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
							SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
							paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
						}
						if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
						{
							retstring += " AND IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO";
							SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
							paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);
						}
						// ---------- UPD 2011/02/15 ----------------------------------------<<<<<
                    }
                    else if (_inventInputSearchCndtnWork.WarehouseShelfOutputDiv == 2)
                    {
                        //棚番設定
                        if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
                        {
                            retstring += " AND IVD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                            SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
                        }
                        if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
                        {
                            retstring += " AND IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO";
                            SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);
                        }
                        if (_inventInputSearchCndtnWork.St_WarehouseShelfNo == "" && _inventInputSearchCndtnWork.Ed_WarehouseShelfNo == "")
                        {
                            retstring += " AND IVD.WAREHOUSESHELFNORF IS NOT NULL ";
							// ---------- DEL 2011/02/15 ---------------------------------------->>>>>
							//SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
							//paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);
							// ---------- DEL 2011/02/15 ----------------------------------------<<<<<
                        }
                    }
                }
                else
                {
                    //棚番設定
                    if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
                    {
                        retstring += " AND IVD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                        SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
                    }
                    if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
                    {
                        //retstring += " AND (IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR IVD.WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO)"; // 2008.10.08 DEL
                        retstring += " AND (IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR IVD.WAREHOUSESHELFNORF IS NULL )";                                                        // 2008.10.08 ADD
                        SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        //paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo + "%");  // 2008.10.08 DEL
                        paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);    // 2008.10.08 ADD 
                    }
                }
            }
            // 棚卸調査表と棚卸差異表
            else
            {
                //棚番設定
                if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
                {
                    retstring += " AND IVD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                    SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
                }
                if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
                {
                    retstring += " AND (IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR IVD.WAREHOUSESHELFNORF IS NULL )";
                    SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);
                }
            }

            ////棚番設定
            //if (_inventInputSearchCndtnWork.St_WarehouseShelfNo != "")
            //{
            //    retstring += " AND IVD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
            //    SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
            //    paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.St_WarehouseShelfNo);
            //}
            //if (_inventInputSearchCndtnWork.Ed_WarehouseShelfNo != "")
            //{
            //    //retstring += " AND (IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR IVD.WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO)"; // 2008.10.08 DEL
            //    retstring += " AND (IVD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR IVD.WAREHOUSESHELFNORF IS NULL )";                                                        // 2008.10.08 ADD
            //    SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
            //    //paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo + "%");  // 2008.10.08 DEL
            //    paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo);    // 2008.10.08 ADD 
            //}
           
            // -----------UDP 2011/01/11 -------------------------------<<<<<

            //自社分類コード設定
            if (_inventInputSearchCndtnWork.St_EnterpriseGanreCode != 0)
            {
                retstring += " AND IVD.ENTERPRISEGANRECODERF>=@STENTERPRISEGANRECODE";
                SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STENTERPRISEGANRECODE", SqlDbType.Int);
                paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_EnterpriseGanreCode);
            }
            if ((_inventInputSearchCndtnWork.Ed_EnterpriseGanreCode != 9999) && (_inventInputSearchCndtnWork.Ed_EnterpriseGanreCode != 0))
            {
                retstring += " AND IVD.ENTERPRISEGANRECODERF<=@EDENTERPRISEGANRECODE";
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_EnterpriseGanreCode);
            }

            //ＢＬ商品コード設定
            if (_inventInputSearchCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND IVD.BLGOODSCODERF>=@STBLGOODSCODE";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_BLGoodsCode);
            }
            if ((_inventInputSearchCndtnWork.Ed_BLGoodsCode != 99999) && (_inventInputSearchCndtnWork.Ed_BLGoodsCode != 0))
            {
                retstring += " AND IVD.BLGOODSCODERF<=@EDBLGOODSCODE";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_BLGoodsCode);
            }

            //仕入先コード設定
            if (_inventInputSearchCndtnWork.St_SupplierCd != 0)
            {
                retstring += " AND IVD.SUPPLIERCDRF>=@STSUPPLIERCD";
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_SupplierCd);
            }
            if ((_inventInputSearchCndtnWork.Ed_SupplierCd != 999999) && (_inventInputSearchCndtnWork.Ed_SupplierCd != 0)) 
            {
                retstring += " AND IVD.SUPPLIERCDRF<=@EDSUPPLIERCD";
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_SupplierCd);
            }
// DEL 2008/09/08 テーブルレイアウト変更のため削除 >>> 
 /*
            //出荷先得意先コード設定
            if (_inventInputSearchCndtnWork.St_ShipCustomerCode != 0)
            {
                retstring += " AND IVD.SHIPCUSTOMERCODERF>=@STSHIPCUSTOMERCODE";
                SqlParameter paraStShipCustomerCode = sqlCommand.Parameters.Add("@STSHIPCUSTOMERCODE", SqlDbType.Int);
                paraStShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_ShipCustomerCode);
            }
            if (_inventInputSearchCndtnWork.Ed_ShipCustomerCode != 999999999)
            {
                retstring += " AND IVD.SHIPCUSTOMERCODERF<=@EDSHIPCUSTOMERCODE";
                SqlParameter paraEdShipCustomerCode = sqlCommand.Parameters.Add("@EDSHIPCUSTOMERCODE", SqlDbType.Int);
                paraEdShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_ShipCustomerCode);
            }
  */ 
// DEL 2008/09/08 <<<

            //棚卸準備処理日設定
            if (_inventInputSearchCndtnWork.St_InventoryPreprDay != DateTime.MinValue)
            {
                int startymdInventoryPreprDay = TDateTime.DateTimeToLongDate("YYYYMMDD", _inventInputSearchCndtnWork.St_InventoryPreprDay);
                retstring += " AND IVD.INVENTORYPREPRDAYRF >= " + startymdInventoryPreprDay.ToString();
            }
            if (_inventInputSearchCndtnWork.Ed_InventoryPreprDay != DateTime.MinValue)
            {
                if (_inventInputSearchCndtnWork.St_InventoryPreprDay == DateTime.MinValue)
                {
                    retstring += " AND (IVD.INVENTORYPREPRDAYRF IS NULL OR";
                }
                else
                {
                    retstring += " AND";
                }

                int endymdInventoryPreprDay = TDateTime.DateTimeToLongDate("YYYYMMDD", _inventInputSearchCndtnWork.Ed_InventoryPreprDay);
                retstring += " IVD.INVENTORYPREPRDAYRF <= " + endymdInventoryPreprDay.ToString();

                if (_inventInputSearchCndtnWork.St_InventoryPreprDay == DateTime.MinValue)
                {
                    retstring += " ) ";
                }
            }

            //棚卸日
            if (_inventInputSearchCndtnWork.InventoryDate != DateTime.MinValue)
            {
                int InventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", _inventInputSearchCndtnWork.InventoryDate);
                retstring += " AND IVD.INVENTORYDATERF = " + InventoryDate.ToString();
            }

            //通番設定
            if (_inventInputSearchCndtnWork.St_InventorySeqNo != 0)
            {
                retstring += " AND IVD.INVENTORYSEQNORF>=@STINVENTORYSEQNO";
                SqlParameter paraStInventorySeqNo = sqlCommand.Parameters.Add("@STINVENTORYSEQNO", SqlDbType.Int);
                paraStInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_InventorySeqNo);
            }
            if ((_inventInputSearchCndtnWork.Ed_InventorySeqNo != 999999) && (_inventInputSearchCndtnWork.Ed_InventorySeqNo != 0))
            {
                retstring += " AND IVD.INVENTORYSEQNORF<=@EDINVENTORYSEQNO";
                SqlParameter paraEdInventorySeqNo = sqlCommand.Parameters.Add("@EDINVENTORYSEQNO", SqlDbType.Int);
                paraEdInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_InventorySeqNo);
            }
// ADD 2008/09/08  抽出条件追加 >>>
            // グループコード設定
            if (_inventInputSearchCndtnWork.St_BLGroupCode != 0)
            {
                retstring += " AND IVD.BLGROUPCODERF>=@STBLGROUPCODE";
                SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.St_BLGroupCode);
            }
            if ((_inventInputSearchCndtnWork.Ed_BLGroupCode != 99999) && (_inventInputSearchCndtnWork.Ed_BLGroupCode != 0))
            {
                retstring += " AND IVD.BLGROUPCODERF<=@EDBLGROUPCODE";
                SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(_inventInputSearchCndtnWork.Ed_BLGroupCode);
            }

            // 在庫区分設定
            if (_inventInputSearchCndtnWork.StockDiv != 0)
            {
                switch (_inventInputSearchCndtnWork.StockDiv)
                {
                    case 1:     // 自社分のみ
                        retstring += " AND IVD.STOCKDIVRF=0";
                        break;
                    case 2:     // 受託分のみ     
                        retstring += " AND IVD.STOCKDIVRF!=0";
                        break;
                }
            }
            // ADD 2008/09/08  <<<
            //差異分抽出区分
            if (_inventInputSearchCndtnWork.DifCntExtraDiv  != 0)
            {
                // 修正 2008/09/08 >>>
                #region 修正前
                /*
                switch (_inventInputSearchCndtnWork.DifCntExtraDiv)
                {
                    case 1:     // 数未入力分のみ   !!!! これでは入力した数値が０のものも検索される   
                        retstring += " AND IVD.INVENTORYSTOCKCNTRF=0";
                        break;
                    case 2:     // 数入力分のみ     !!!! これでは入力した数値が０のとき検索から漏れる
                        retstring += " AND IVD.INVENTORYSTOCKCNTRF!=0";
                        break;
                    case 3:     // 差異分のみ
                        retstring += " AND IVD.INVENTORYSTOCKCNTRF!=IVD.STOCKTOTALRF";
                        break;
                }
                */
                #endregion
                switch (_inventInputSearchCndtnWork.DifCntExtraDiv)
                {
                    case 1:     // 数未入力分のみ 棚卸実施日が[Null]の場合
                        retstring += " AND IVD.INVENTORYDAYRF IS Null";
                        break;
                    case 2:     // 数入力分のみ   棚卸実施日が[Null]以外の場合
                        retstring += " AND IVD.INVENTORYDAYRF IS NOT Null" + Environment.NewLine;
                        break;
                    case 3:     // 差異分のみ
                        retstring += " AND IVD.INVENTORYSTOCKCNTRF!=IVD.STOCKTOTALRF" + Environment.NewLine;
                        break;
                }                
            }
            // ADD 2008/09/08 <<<

            // ADD 2008.12.01 >>>
            // 出力指定区分 0:全て,1:棚卸未入力分のみ,2:差異分のみ,3:重複棚番ありのみ
            if (_inventInputSearchCndtnWork.OutputAppointDiv != 0)
            {
                switch (_inventInputSearchCndtnWork.OutputAppointDiv)
                {
                    case 1:     // 数未入力分のみ 棚卸実施日が[Null]の場合
                        retstring += " AND IVD.INVENTORYDAYRF IS Null" + Environment.NewLine;
                        break;
                    case 2:     // 差異分のみ
                        retstring += " AND IVD.INVENTORYSTOCKCNTRF!=IVD.STOCKTOTALRF" + Environment.NewLine;
                        break;
                    case 3:     // 重複棚番ありのみ
                        retstring += " AND ( IVD.DUPLICATIONSHELFNO1RF IS NOT Null " + Environment.NewLine;
                        retstring += "      OR IVD.DUPLICATIONSHELFNO2RF IS NOT Null) " + Environment.NewLine;
                        break;
                }
            }
            // ADD 2008.12.01 <<<
            //在庫数0抽出区分
            if (_inventInputSearchCndtnWork.StockCntZeroExtraDiv != 0)
            {
                retstring += " AND IVD.STOCKTOTALRF!=0" + Environment.NewLine;
            }

            //棚卸在庫数0抽出区分
            if (_inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv != 0)
            {
                retstring += " AND IVD.INVENTORYSTOCKCNTRF!=0" + Environment.NewLine;
            }

            //基準日設定
            if (_inventInputSearchCndtnWork.TargetDateExtraDiv == 0)
            {
                //棚卸準備処理日が初期値以外
                int ymdInventoryPreprday = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.MinValue);
                retstring += " AND IVD.INVENTORYPREPRDAYRF!=" + ymdInventoryPreprday.ToString();
            }
            else if (_inventInputSearchCndtnWork.TargetDateExtraDiv == 1)
            {
                //棚卸日が初期値以外
                // 2008.03.07 Update >>>>>>>>
                //int ymdInventoryDay = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.MinValue);
                //retstring += " AND IVD.INVENTORYDAYRF!=" + ymdInventoryDay.ToString();
                int ymdInventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.MinValue);
                retstring += " AND IVD.INVENTORYDATERF!=" + ymdInventoryDate.ToString();
                // 2008.03.07 Update <<<<<<<<
            }
            else if (_inventInputSearchCndtnWork.TargetDateExtraDiv == 2)
            {
                //棚卸更新日が初期値以外
                int ymdInventoryUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.MinValue);
                retstring += " AND IVD.LASTINVENTORYUPDATERF!=" + ymdInventoryUpDate.ToString();
            }
            // ADD 2009.01.29 >>>
            // 棚卸差異表の場合、棚卸数未入力は出力対象外とする
            if (_inventInputSearchCndtnWork.SelectedPaperKind == 1)
            {
                retstring += " AND IVD.INVENTORYDAYRF IS NOT NULL " + Environment.NewLine;
            }
            // ADD 2009.01.29 <<<
            // ADD 2009/06/01 >>>
            if ((_inventInputSearchCndtnWork.SelectedPaperKind != -1) && (_inventInputSearchCndtnWork.SelectedPaperKind != 2) ) // 棚卸表以外
            {
                // --- DEL 2009/11/30 ---------->>>>>
                // 棚卸表以外は過不足更新が行われていないデータを抽出
                //retstring += " AND IVD.TOLERANCEUPDATECDRF = 0" + Environment.NewLine;
                // --- DEL 2009/11/30 ----------<<<<<
            }
            // ADD 2009/06/01 <<<
            return retstring;
        }
        #endregion    // Where文作成

        // CalcStockTotalに渡されるalは、SearchNonGrossActionで作成されたものとSearchGrossActionで作成されたものの
        // ２種類あることに注意。
        // SearchNonGrossActionでは、alの要素のタイプはInventoryDataUpdateWork
        // SearchGrossActionでは、alの要素のタイプはInventInputSearchResultWork
        // alElementType  0:InventoryDataUpdateWork、1:InventInputSearchResultWork   2008.03.21 Add
        /// <summary>
        /// 在庫総数を計算
        /// </summary>
        /// <param name="al">InventoryDataUpdateWork or InventInputSearchResultWorkのList。alElementTypeで判断する</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="inventInputSearchCndtnWork">検索条件</param>
        /// <param name="alElementType">0:InventoryDataUpdateWork、1:InventInputSearchResultWork</param>
        /// <returns></returns>
        private int CalcStockTotal(ref ArrayList al, ref SqlConnection sqlConnection, 
            InventInputSearchCndtnWork inventInputSearchCndtnWork, int alElementType)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            int lastAddUpYearMonth = 0;
            DateTime lastAddUpDate = DateTime.MinValue;
            double stockUnitPriceFl = 0.0;
            double stockTotal = 0.0;
            double arrivalCnt = 0.0;
            double shipmentCnt = 0.0;
            InventoryDataUpdateWork ivtDataUpdWork = null;
            InventInputSearchResultWork ivtInputSearchResultWork = null;
            string EnterpriseCode = "";
            string WarehouseCode = "";
            string SectionCode = "";
            string GoodsNo = "";
            int GoodsMakerCd = 0;
            DateTime targetDate = inventInputSearchCndtnWork.CalcStockAmountDate;
            int SelectedPaper = inventInputSearchCndtnWork.SelectedPaperKind; // ADD 2008/09/09 <<<
            //ADD 2012/07/20 李小路 Redmine#31158 ----------->>>>>
            int FractionProcCd = 0;     // 端数処理区分取得
            int inventoryMngDiv = 0;    // 棚卸運用区分取得
            //ADD 2012/07/20 李小路 Redmine#31158 -----------<<<<<

            // -----------ADD 2010/02/20------------>>>>>
            // 在庫履歴データ
            Dictionary<string, StockHistoryWork> stockHistWorkDic = new Dictionary<string, StockHistoryWork>();
            // 月次締更新履歴データ
            //ArrayList monthlyAddupHisWorkList = new ArrayList();  // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
            // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 *-------------------->>>
            //List<MonthlyAddUpHisWork> monthlyAddupHisWorkList = null; 
            MonthlyAddUpHisWork monthlyAddupHisWork = null;
            // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 <<<--------------------*

            // 在庫受払履歴データ
            List<StockAcPayHistWork> stockAcpayHistWorkList = new List<StockAcPayHistWork>();
            if (al.Count > 0)
            {
                string enterpriseCode = string.Empty;
                // alElementType  0:InventoryDataUpdateWork
                if (alElementType == 0)
                {
                    enterpriseCode = ((InventoryDataUpdateWork)al[0]).EnterpriseCode;
                }
                else
                {
                    enterpriseCode = inventInputSearchCndtnWork.EnterpriseCode;
                }

                #region DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
                // 過不足更新処理の高速化対応
                //// 在庫履歴データ全件検索
                //status = StockHistoryDataSearch(out stockHistWorkDic, enterpriseCode, ref sqlConnection);
                //// 月次締更新履歴マスタ検索
                //status = MonthlyAddupHisDataSearch(out monthlyAddupHisWorkList, enterpriseCode, ref sqlConnection);
                //// 在庫受払履歴データ全件検索
                //status = StockAcPayHisSearch(out stockAcpayHistWorkList, enterpriseCode, ref sqlConnection);
                #endregion

                // ADD 2012/02/15 22013 久保@仕掛一覧 No1552対応 *-------------------->>>
                // 月次締更新履歴マスタ検索
                status = MonthlyAddupHisDataSearch(out monthlyAddupHisWork, enterpriseCode, ref sqlConnection);
                // 在庫履歴データ全件検索
                status = StockHistoryDataSearch(out stockHistWorkDic, enterpriseCode, monthlyAddupHisWork, ref sqlConnection);
                // 在庫受払履歴データ全件検索
                status = StockAcPayHisSearch(out stockAcpayHistWorkList, enterpriseCode, monthlyAddupHisWork, ref sqlConnection);

                // エラー処理
                // 正常時：ctDB_NORMAL、件数ゼロ：ctDB_EOF ⇒処理続行
                // 異常時⇒処理終了
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    return status;
                }
                // ADD 2012/02/15 22013 久保@仕掛一覧 No1552対応 <<<--------------------*

                //ADD 2012/07/20 李小路 Redmine#31158 ----------->>>>>
                if (alElementType != 0 && SelectedPaper == 1)
                {
                    StockMngTtlStDB _stockMngTtlStDB = new StockMngTtlStDB();
                    StockMngTtlStWork _stockMngTtlStWork = new StockMngTtlStWork();
                    ArrayList _stockMngTtlStWorkList = new ArrayList();

                    _stockMngTtlStWork.EnterpriseCode = enterpriseCode; // 企業コード設定
                    _stockMngTtlStWork.SectionCode = "00"; // 企業コード設定 全社固定
                    status = _stockMngTtlStDB.SearchStockMngTtlStProc(out _stockMngTtlStWorkList, _stockMngTtlStWork, 0, 0, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 端数処理区分取得
                        FractionProcCd = ((StockMngTtlStWork)_stockMngTtlStWorkList[0]).FractionProcCd;// 端数処理区分　1：切捨て,2：四捨五入,3:切上げ
                        // 棚卸運用区分取得
                        inventoryMngDiv = ((StockMngTtlStWork)_stockMngTtlStWorkList[0]).InventoryMngDiv;// 棚卸運用区分 0：ＰＭ．ＮＳ,1：ＰＭ７

                    }
                }
                //ADD 2012/07/20 李小路 Redmine#31158 -----------<<<<<
            }

            // -----------ADD 2010/02/20------------<<<<<
            for (int i = 0; i < al.Count; i++)
            {
                stockTotal = 0.0;
                arrivalCnt = 0.0;
                shipmentCnt = 0.0;

                if (alElementType == 0)
                {
                    ivtDataUpdWork = (InventoryDataUpdateWork)al[i];
                    EnterpriseCode = ivtDataUpdWork.EnterpriseCode;
                    WarehouseCode = ivtDataUpdWork.WarehouseCode;
                    SectionCode = ivtDataUpdWork.SectionCode;
                    GoodsNo = ivtDataUpdWork.GoodsNo;
                    GoodsMakerCd = ivtDataUpdWork.GoodsMakerCd;
                    if (inventInputSearchCndtnWork.CalcStockAmountDate == null ||
                        inventInputSearchCndtnWork.CalcStockAmountDate == DateTime.MinValue)
                    {
                        targetDate = ivtDataUpdWork.InventoryDay;
                    }
                }
                else
                {
                    ivtInputSearchResultWork = (InventInputSearchResultWork)al[i];
                    EnterpriseCode = inventInputSearchCndtnWork.EnterpriseCode;
                    WarehouseCode = ivtInputSearchResultWork.WarehouseCode;
                    SectionCode = ivtInputSearchResultWork.SectionCode;
                    GoodsNo = ivtInputSearchResultWork.GoodsNo;
                    GoodsMakerCd = ivtInputSearchResultWork.GoodsMakerCd;
                    if (inventInputSearchCndtnWork.CalcStockAmountDate == null ||
                        inventInputSearchCndtnWork.CalcStockAmountDate == DateTime.MinValue)
                    {
                        targetDate = ivtInputSearchResultWork.InventoryDay;
                    }
                }

                // -----------UPD 2010/02/20------------>>>>>
                #region DEL
                //status = GetStockHistoryData(EnterpriseCode, WarehouseCode, SectionCode, GoodsNo, GoodsMakerCd,
                //ref lastAddUpYearMonth, ref stockUnitPriceFl, ref stockTotal, ref sqlConnection);
                //status = GetLastAddUpDate(EnterpriseCode, lastAddUpYearMonth, ref lastAddUpDate, ref sqlConnection);
                #endregion
                // 在庫履歴データから在庫の前回締日と仕入単価と在庫総数を取得する
                GetStockHistoryData(stockHistWorkDic, WarehouseCode, GoodsNo, GoodsMakerCd, ref lastAddUpYearMonth, ref stockUnitPriceFl, ref stockTotal);

                // 月次締次更新履歴マスタの月次更新年月と在庫の前回締年月が一致している場合、
                // 前回月次更新年月日に月次締次更新履歴マスタの月次更新日をセットする。

                // 在庫履歴データ全件検索メソッドで「在庫履歴.計上年月 >= 月次締次更新履歴マスタ. 月次更新年月」と
                // 指定しているので、このメソッドからは「月次締次更新履歴マスタ. 月次更新年月」しか返ってこない
                GetLastAddUpDate(monthlyAddupHisWork, lastAddUpYearMonth, ref lastAddUpDate);
                // -----------UPD 2010/02/20------------<<<<<
                if (targetDate != DateTime.MinValue && targetDate >= lastAddUpDate)
                {
                    #region DEL
                    // -----------UPD 2010/02/20------------>>>>>
                    //status = GetStockAcPayHistData(EnterpriseCode, WarehouseCode, SectionCode, GoodsNo, GoodsMakerCd,
                    //lastAddUpDate, targetDate, ref arrivalCnt, ref shipmentCnt, ref sqlConnection);
                    //GetStockAcPayHistData(stockAcpayHistWorkList, WarehouseCode, GoodsNo, GoodsMakerCd, lastAddUpDate, targetDate, ref arrivalCnt, ref shipmentCnt);  // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
                    // -----------UPD 2010/02/20------------<<<<<
                    #endregion
                    // 在庫受払履歴データから入荷数と出荷数を取得する
                    GetStockAcPayHistData(
                        stockAcpayHistWorkList, WarehouseCode, GoodsNo, GoodsMakerCd, lastAddUpDate,
                        targetDate, monthlyAddupHisWork, ref arrivalCnt, ref shipmentCnt);
                    
                }

                if (alElementType == 0)
                {
                    // 在庫総数：stockTotal, 入荷数：arrivalCnt, 出荷数：shipmentCnt
                    if (((InventoryDataUpdateWork)al[i]).InventoryDate != ((InventoryDataUpdateWork)al[i]).InventoryDay)
                    {
                        ((InventoryDataUpdateWork)al[i]).StockAmount = stockTotal + arrivalCnt - shipmentCnt;
                    }
                    else if (((InventoryDataUpdateWork)al[i]).InventoryDate == ((InventoryDataUpdateWork)al[i]).InventoryDay)
                    {
                        ((InventoryDataUpdateWork)al[i]).StockAmount = ((InventoryDataUpdateWork)al[i]).StockTotal;
                    }
                }
                else
                {
                    // 修正 2009/06/01 >>>
                    //if (((InventInputSearchResultWork)al[i]).InventoryDate != ((InventInputSearchResultWork)al[i]).InventoryDay)
                    //{
                    //    ((InventInputSearchResultWork)al[i]).StockAmount = stockTotal + arrivalCnt - shipmentCnt;
                    //}
                    //else if (((InventInputSearchResultWork)al[i]).InventoryDate == ((InventInputSearchResultWork)al[i]).InventoryDay)
                    //{
                    //    ((InventInputSearchResultWork)al[i]).StockAmount = ((InventInputSearchResultWork)al[i]).StockTotal;
                    //}
                    ((InventInputSearchResultWork)al[i]).StockAmount = stockTotal + arrivalCnt - shipmentCnt;
                    // 修正 2009/06/01 <<<

                    // ADD 2008/09/09 >>>
                    // 棚卸差異表の場合、過不足数・過不足金額の更新を行う。
                    if (SelectedPaper == 1)
                    {
                        // 2010/01/28 >>>
                        //status = UpdateInventoryData(ref al, i, EnterpriseCode, SectionCode, ivtInputSearchResultWork.InventorySeqNo, ref sqlConnection);
                        //status = UpdateInventoryData(ref al, i, EnterpriseCode, SectionCode, ivtInputSearchResultWork.InventorySeqNo, WarehouseCode, ref sqlConnection);  //DEL 2012/07/20 李小路 Redmine#31158
                        status = UpdateInventoryData(ref al, i, EnterpriseCode, SectionCode, ivtInputSearchResultWork.InventorySeqNo, WarehouseCode, FractionProcCd, inventoryMngDiv, ref sqlConnection);    //ADD 2012/07/20 李小路 Redmine#31158
                        // 2010/01/28 <<<

                    }
                    // ADD 2008/09/09 <<<
                }

                
            }

            return status;
        }

        #region 在庫履歴データ全件検索
        /// <summary>
        /// 在庫履歴データ全件検索
        /// </summary>
        /// <param name="stockHisDic">在庫履歴データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="monthlyAddupHisWork">月次締更新履歴マスタ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 在庫履歴データ全件検索を行いします。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/02/20</br>
        /// <br>Update Note: 2012/08/08 yangyi</br>
        /// <br>             redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査</br>
        /// </remarks>
        private int StockHistoryDataSearch(out Dictionary<string, StockHistoryWork> stockHisDic, string enterpriseCode, MonthlyAddUpHisWork monthlyAddupHisWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            //Dictionary<string, StockHistoryWork> dic = new Dictionary<string, StockHistoryWork>();      // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
            stockHisDic = new Dictionary<string, StockHistoryWork>();      // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応
            try
            {
                string sText = "";
                sText += "SELECT WAREHOUSECODERF, GOODSNORF, GOODSMAKERCDRF, ADDUPYEARMONTHRF, STOCKUNITPRICEFLRF, STOCKTOTALRF ";
                //sText += "FROM STOCKHISTORYRF ";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                sText += "FROM STOCKHISTORYRF WITH (READUNCOMMITTED) ";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                sText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                sText += "AND LOGICALDELETECODERF=0 ";
                sText += "AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTHRF ";// ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応
                sText += "ORDER BY ADDUPYEARMONTHRF DESC ";

                sqlCommand = new SqlCommand(sText, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTHRF", SqlDbType.Int);    // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(monthlyAddupHisWork.MonthAddUpYearMonth);    // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応

                sqlCommand.CommandTimeout = 3600; // ADD 2012/08/08
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //CopyToStockHistWorkFromReader(ref myReader, ref dic); // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
                    CopyToStockHistWorkFromReader(ref myReader, ref stockHisDic);   // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.StockHistoryDataSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            //stockHisDic = dic;    // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → stockHistWorkDic
        /// </summary>
        /// <param name="myReader">myReader</param>
        /// <param name="stockHistWorkDic">stockHistWorkDic</param>
        /// <returns>stockHistWorkDic</returns>
        /// <remarks>
        /// <br>Note		: 在庫履歴クラス格納処理を行いします。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private Dictionary<string, StockHistoryWork> CopyToStockHistWorkFromReader(ref SqlDataReader myReader, ref Dictionary<string, StockHistoryWork> stockHistWorkDic)
        {
            StockHistoryWork work = new StockHistoryWork();

            #region クラスへ格納
            work.AddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            work.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            work.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            work.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            work.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            work.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));

            string key = work.WarehouseCode + "-" + work.GoodsNo + "-" + work.GoodsMakerCd;
            if (!stockHistWorkDic.ContainsKey(key))
            {
                stockHistWorkDic.Add(key, work);
            }

            #endregion

            return stockHistWorkDic;
        }
        #endregion  // 在庫履歴データ全件検索

        #region 月次締更新履歴マスタ全件検索
        /// <summary>
        /// 月次締更新履歴マスタ全件検索
        /// </summary>
        /// <param name="monthlyAddupHisWork">月次締更新履歴マスタ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 月次締更新履歴マスタデータ全件検索を行いします。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/02/20</br>
        /// <br>Update Note: 2012/08/08 yangyi</br>
        /// <br>             redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査</br>
        /// <br>Update Note: 2013/02/15 22013 久保 将太</br>
        /// <br>             仕掛一覧No1552対応 過不足更新の高速化・効率化対応</br>
        /// </remarks>
        //private int MonthlyAddupHisDataSearch(out ArrayList monthlyAddupHisWorkList, string enterpriseCode, ref SqlConnection sqlConnection)
        private int MonthlyAddupHisDataSearch(out MonthlyAddUpHisWork monthlyAddupHisWork, string enterpriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            //ArrayList al = new ArrayList();   // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
            monthlyAddupHisWork = new MonthlyAddUpHisWork(); // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応
            try
            {
                string sText = "";

                //sText += "SELECT DISTINCT MONTHLYADDUPDATERF, MONTHADDUPYEARMONTHRF FROM MONTHLYADDUPHISRF ";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                //sText += "SELECT DISTINCT MONTHLYADDUPDATERF, MONTHADDUPYEARMONTHRF FROM MONTHLYADDUPHISRF WITH (READUNCOMMITTED) ";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼   // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応


                // TOP1で最終締を取得する
                sText += "SELECT DISTINCT TOP 1 MONTHLYADDUPDATERF, MONTHADDUPYEARMONTHRF FROM MONTHLYADDUPHISRF WITH (READUNCOMMITTED) ";// ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 「TOP1」追加
                sText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                sText += "AND LOGICALDELETECODERF=0 ";
                sText += "AND PROCDIVCDRF=0 ";
                sText += "AND HISTCTLCDRF=0 ";
                sText += "ORDER BY MONTHADDUPYEARMONTHRF DESC ";

                sqlCommand = new SqlCommand(sText, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                sqlCommand.CommandTimeout = 3600; // ADD 2012/08/08
                myReader = sqlCommand.ExecuteReader();

                #region // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
                //while (myReader.Read())
                //{
                //    al.Add(CopyToMonthlyAddupHisWorkFromReader(ref myReader));

                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
                #endregion

                // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 *-------------------->>>
                // 繰り返しが不要になりました。
                if(myReader.Read())
                {
                    monthlyAddupHisWork = CopyToMonthlyAddupHisWorkFromReader(ref myReader);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 <<<--------------------*

            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.MonthlyAddupHisDataSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            //monthlyAddupHisWorkList = al;

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → MonthlyAddUpHisWork
        /// </summary>
        /// <param name="myReader">myReader</param>
        /// <returns>StockHistoryWork</returns>
        /// <remarks>
        /// <br>Note		: 月次締更新履歴マスタクラス格納処理を行いします。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private MonthlyAddUpHisWork CopyToMonthlyAddupHisWorkFromReader(ref SqlDataReader myReader)
        {
            MonthlyAddUpHisWork monthlyAddUpHisWork = new MonthlyAddUpHisWork();

            #region クラスへ格納
            monthlyAddUpHisWork.MonthlyAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));
            monthlyAddUpHisWork.MonthAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHADDUPYEARMONTHRF"));
            #endregion

            return monthlyAddUpHisWork;
        }
        #endregion  // 月次締更新履歴マスタデータ全件検索

        #region 在庫受払履歴データ全件検索
        /// <summary>
        /// 在庫受払履歴データ全件検索
        /// </summary>
        /// <param name="stockHistWorkList">在庫受払履歴データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 在庫受払履歴データ全件検索を行いします。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/02/20</br>
        /// <br>Update Note: 2012/08/08 yangyi</br>
        /// <br>             redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査</br>
        /// </remarks>
        private int StockAcPayHisSearch(out List<StockAcPayHistWork> stockAcPayHistWorkList, string enterpriseCode, MonthlyAddUpHisWork monthlyAddupHisWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            //List<StockAcPayHistWork> al = new List<StockAcPayHistWork>();     // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
            stockAcPayHistWorkList = new List<StockAcPayHistWork>();    // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応
            try
            {
                string sText = "";

                sText += "SELECT ARRIVALCNTRF, SHIPMENTCNTRF, IOGOODSDAYRF, ADDUPADATERF, WAREHOUSECODERF, GOODSNORF, GOODSMAKERCDRF ";
                //sText += "FROM STOCKACPAYHISTRF ";//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                sText += "FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) ";//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                sText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                sText += "AND LOGICALDELETECODERF= 0 ";
                sText += "AND (ADDUPADATERF>@FINDADDUPADATERF or ADDUPADATERF is null)";// ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応
                sText += "ORDER BY ADDUPADATERF DESC "; // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応(NSでソートしないことによる障害が発生したことがあったので、ソート条件を設定する）

                sqlCommand = new SqlCommand(sText, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpData = sqlCommand.Parameters.Add("@FINDADDUPADATERF", SqlDbType.Int);    // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaAddUpData.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(monthlyAddupHisWork.MonthlyAddUpDate));    // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応

                sqlCommand.CommandTimeout = 3600; // ADD 2012/08/08
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //al.Add(CopyToStockAcPayHistWorkFromReader(ref myReader));      // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
                    stockAcPayHistWorkList.Add(CopyToStockAcPayHistWorkFromReader(ref myReader));    // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.StockAcPayHisSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            //stockAcPayHistWorkList = al;    // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → stockAcPayHistWork
        /// </summary>
        /// <param name="myReader">myReader</param>
        /// <returns>StockHistoryWork</returns>
        /// <remarks>
        /// <br>Note		: 在庫受払履歴データクラス格納処理を行いします。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private StockAcPayHistWork CopyToStockAcPayHistWorkFromReader(ref SqlDataReader myReader)
        {
            StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();

            #region クラスへ格納
            stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IOGOODSDAYRF"));
            stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            stockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            #endregion

            return stockAcPayHistWork;
        }
        #endregion  // 在庫受払履歴データ全件検索

        #region 在庫履歴データ検索
        // --------------DEL 2010/02/20-------------->>>>>
        ///// <summary>
        ///// 在庫履歴データ検索
        ///// </summary>
        ///// <param name="ivtDataWork"></param>
        ///// <param name="addUpYearMonth"></param>
        ///// <param name="stockTotal"></param>
        ///// <returns></returns>
        //private int GetStockHistoryData(string EnterpriseCode, string WarehouseCode, string SectionCode,
        //    string GoodsNo, int GoodsMakerCd,
        //    ref int lastAddUpYearMonth, ref double stockUnitPriceFl, ref double stockTotal,
        //    ref SqlConnection sqlConnection)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlCommand sqlCommand = null;
        //    SqlDataReader myReader = null;

        //    try
        //    {
        //        string sText = "";

        //        sText += "SELECT TOP 1 ADDUPYEARMONTHRF, STOCKUNITPRICEFLRF, STOCKTOTALRF FROM STOCKHISTORYRF ";
        //        sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
        //        sText += "AND LOGICALDELETECODERF=0 ";
        //        sText += "AND WAREHOUSECODERF=@WAREHOUSECODE ";
        //        //sText += "AND SECTIONCODERF=@SECTIONCODE "; // DEL 2009/07/03
        //        sText += "AND GOODSNORF=@GOODSNO ";
        //        sText += "AND GOODSMAKERCDRF=@GOODSMAKERCD ";
        //        sText += "ORDER BY ADDUPYEARMONTHRF DESC ";

        //        sqlCommand = new SqlCommand(sText, sqlConnection);

        //        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
        //        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
        //        //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // DEL 2009/07/03
        //        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
        //        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);

        //        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
        //        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(WarehouseCode);
        //        //paraSectionCode.Value = SqlDataMediator.SqlSetString(SectionCode); // DEL 2009/07/03
        //        paraGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsNo);
        //        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsMakerCd);

        //        lastAddUpYearMonth = 0;
        //        stockUnitPriceFl = 0.0;
        //        stockTotal = 0.0;

        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            lastAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
        //            stockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
        //            stockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));
        //        }

        //        if (!myReader.IsClosed) myReader.Close();
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        base.WriteErrorLog(ex, "InventoryExtDB.GetStockHistoryData Exception=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null) sqlCommand.Dispose();
        //        if (myReader != null && !myReader.IsClosed) myReader.Close();
        //    }
        //    return status;
        //}
        // --------------DEL 2010/02/20--------------<<<<<
        /// <summary>
        /// 在庫履歴データ検索
        /// </summary>
        /// <param name="dic">在庫履歴データ全件</param>
        /// <param name="WarehouseCode">倉庫コード</param>
        /// <param name="GoodsNo">品番</param>
        /// <param name="GoodsMakerCd">メーカーコード</param>
        /// <param name="lastAddUpYearMonth">計上年月</param>
        /// <param name="stockUnitPriceFl">仕入単価（税抜，浮動）</param>
        /// <param name="stockTotal">在庫総数</param>
        /// <remarks>
        /// <br>Note		: 指定した在庫履歴データを取得する。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private void GetStockHistoryData(Dictionary<string,StockHistoryWork> dic, string WarehouseCode, string GoodsNo, int GoodsMakerCd,
            ref int lastAddUpYearMonth, ref double stockUnitPriceFl, ref double stockTotal)
        {
            string tempKey = WarehouseCode +"-" + GoodsNo +"-" + GoodsMakerCd.ToString();
            // 計上年月
            lastAddUpYearMonth = 0;
            // 仕入単価
            stockUnitPriceFl = 0.0;
            // 在庫総数
            stockTotal = 0;
            if (dic.ContainsKey(tempKey))
            {
                StockHistoryWork work = (StockHistoryWork)dic[tempKey];
                lastAddUpYearMonth = work.AddUpYearMonth;
                stockUnitPriceFl = work.StockUnitPriceFl;
                stockTotal = work.StockTotal;
            }
        }

        #endregion  // 在庫履歴データ検索

        #region 前回月次更新日取得
        // --------------DEL 2010/02/20-------------->>>>>
        //private int GetLastAddUpDate(string EnterpriseCode, int lastAddUpYearMonth, ref DateTime lastAddUpDate,
        //    ref SqlConnection sqlConnection)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlCommand sqlCommand = null;
        //    SqlDataReader myReader = null;
        //    int monthAddUpYearMonth = 0;

        //    lastAddUpDate = DateTime.MinValue;

        //    try
        //    {
        //        string sText = "";

        //        sText += "SELECT DISTINCT MONTHLYADDUPDATERF, MONTHADDUPYEARMONTHRF FROM MONTHLYADDUPHISRF ";
        //        sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
        //        sText += "AND LOGICALDELETECODERF=0 ";
        //        sText += "AND PROCDIVCDRF=0 ";
        //        sText += "AND HISTCTLCDRF=0 ";
        //        sText += "ORDER BY MONTHADDUPYEARMONTHRF DESC ";

        //        sqlCommand = new SqlCommand(sText, sqlConnection);

        //        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);

        //        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);

        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            monthAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHADDUPYEARMONTHRF"));
        //            if (monthAddUpYearMonth == lastAddUpYearMonth)
        //            {
        //                lastAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));
        //                break;
        //            }
        //        }

        //        if (!myReader.IsClosed) myReader.Close();
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        base.WriteErrorLog(ex, "InventoryExtDB.GetLastAddUpDate Exception=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null) sqlCommand.Dispose();
        //        if (myReader != null && !myReader.IsClosed) myReader.Close();
        //    }
        //    return status;

        //}
        // --------------DEL 2010/02/20--------------<<<<<
        /// <summary>
        /// 前回月次更新日取得
        /// </summary>
        /// <param name="dic">月次締更新履歴データ全件</param>
        /// <param name="WarehouseCode">倉庫コード</param>
        /// <param name="lastAddUpYearMonth">月次更新年月</param>
        /// <param name="lastAddUpDate">月次更新年月日</param>
        /// <remarks>
        /// <br>Note		: 前回月次更新日を取得する。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        //private void GetLastAddUpDate(ArrayList monthlyAddupHisWorkList, int lastAddUpYearMonth, ref DateTime lastAddUpDate)  // DEL 2013/02/15 22013 久保@仕掛一覧 No.1552対応
        private void GetLastAddUpDate(MonthlyAddUpHisWork monthlyAddupHisWork, int lastAddUpYearMonth, ref DateTime lastAddUpDate)    // ADD 2013/02/15 22013 久保@仕掛一覧 No.1552対応
        {
            // 月次更新年月日
            lastAddUpDate = DateTime.MinValue;

            #region DEL 2013/02/15 22013 久保@仕掛一覧 No.1552対応
            //foreach (MonthlyAddUpHisWork work in monthlyAddupHisWorkList)
            //{
            //    // 「月次更新年月=計上年月」の場合
            //    if (work.MonthAddUpYearMonth == lastAddUpYearMonth)
            //    {
            //        lastAddUpDate = work.MonthlyAddUpDate;
            //        break;
            //    }
            //}
            #endregion

            // ADD 2013/02/15 22013 久保@仕掛一覧 No.1552対応 *-------------------->>>
            // 「月次更新年月=計上年月」の場合
            if (monthlyAddupHisWork.MonthAddUpYearMonth == lastAddUpYearMonth)
            {
                lastAddUpDate = monthlyAddupHisWork.MonthlyAddUpDate;
            }
            // ADD 2013/02/15 22013 久保@仕掛一覧 No.1552対応 <<<--------------------*
        }
        #endregion // 前回月次更新日取得

        // ADD 2008/09/09 >>>
        #region 棚卸データ更新処理(過不足数・過不足金額)
        // 2010/01/28 >>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="al"></param>
        /// <param name="i"></param>
        /// <param name="EnterpriseCode"></param>
        /// <param name="SectionCode"></param>
        /// <param name="InventorySeqNo"></param>
        /// <param name="warehouseCode"></param>
        /// <param name="FractionProcCd"></param>
        /// <param name="inventoryMngDiv"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        //private int UpdateInventoryData(ref ArrayList al, int i, string EnterpriseCode, string SectionCode, Int32 InventorySeqNo,
        //    ref SqlConnection sqlConnection)
        //private int UpdateInventoryData(ref ArrayList al, int i, string EnterpriseCode, string SectionCode, Int32 InventorySeqNo, string warehouseCode,
        //    ref SqlConnection sqlConnection)      //DEL 2012/07/20 李小路 Redmine#31158
        private int UpdateInventoryData(ref ArrayList al, int i, string EnterpriseCode, string SectionCode, Int32 InventorySeqNo, string warehouseCode, int FractionProcCd, int inventoryMngDiv,
            ref SqlConnection sqlConnection)        //ADD 2012/07/20 李小路 Redmine#31158
        // 2010/01/28 <<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            InventInputSearchResultWork ivtInputSearchResultWork = null;
            ivtInputSearchResultWork = (InventInputSearchResultWork)al[i];

            // --------- ADD 2009/12/10 ----------->>>>>
            // 過不足更新済み
            if (ivtInputSearchResultWork.ToleranceUpdateCd == 1)
            {
                // 実施日帳簿数 = 棚卸データ.在庫総数（実施日）
                ivtInputSearchResultWork.StockAmount = ivtInputSearchResultWork.StockTotalExec;
                return 0;
            }
            // --------- ADD 2009/12/10 -----------<<<<<
            // ADD 2009/07/14 >>>
            #region 在庫管理全体設定マスタ LIST取得

            //DEL 2012/07/20 李小路 Redmine#31158 ------------->>>>>
            //StockMngTtlStDB _stockMngTtlStDB = new StockMngTtlStDB();
            //StockMngTtlStWork _stockMngTtlStWork = new StockMngTtlStWork();
            //ArrayList _stockMngTtlStWorkList = new ArrayList();
            //int FractionProcCd = 0;
            //DEL 2012/07/20 李小路 Redmine#31158 -------------<<<<<

            long resultNumerical = 0;

            //DEL 2012/07/20 李小路 Redmine#31158 ------------->>>>>
            //_stockMngTtlStWork.EnterpriseCode = EnterpriseCode; // 企業コード設定
            //_stockMngTtlStWork.SectionCode = "00"; // 企業コード設定 全社固定
            //status = _stockMngTtlStDB.SearchStockMngTtlStProc(out _stockMngTtlStWorkList, _stockMngTtlStWork, 0, 0, ref sqlConnection);
            // 端数処理区分取得
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    FractionProcCd = ((StockMngTtlStWork)_stockMngTtlStWorkList[0]).FractionProcCd;// 端数処理区分　1：切捨て,2：四捨五入,3:切上げ
            //}
            //int inventoryMngDiv = 0;
            // --------- ADD 2009/12/10 ----------->>>>>
            // 棚卸運用区分取得
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    inventoryMngDiv = ((StockMngTtlStWork)_stockMngTtlStWorkList[0]).InventoryMngDiv;// 棚卸運用区分 0：ＰＭ．ＮＳ,1：ＰＭ７
            //}
            // --------- ADD 2009/12/10 -----------<<<<<
            //DEL 2012/07/20 李小路 Redmine#31158 -------------<<<<<
            #endregion
            // ADD 2009/07/14 <<<

            SqlCommand sqlCommand = null;           

            string sText = "";
            double InventoryTolerancCnt = 0.0;
            double InventoryTlrncPrice = 0.0; 
            DateTime LastInventoryUpdate = new DateTime();
            LastInventoryUpdate = DateTime.Now;


            #region UPDATE文 作成
            sText = "UPDATE INVENTORYDATARF SET" + Environment.NewLine;
            sText += " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;               // 更新日時
            sText += ", INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT" + Environment.NewLine;　// 棚卸過不足数
            sText += ", INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE" + Environment.NewLine;    // 棚卸過不足金額
            sText += ", STOCKTOTALEXECRF=@STOCKTOTALEXEC" + Environment.NewLine;              // 実施日帳簿数 2009.01.28
            sText += ", LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;    // 最終棚卸更新日 2009/06/01
            sText += " WHERE" + Environment.NewLine; ;
            sText += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sText += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            sText += " AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO" + Environment.NewLine;
            sText += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;   // 2010/01/28 Add
            #endregion 

            sqlCommand = new SqlCommand(sText, sqlConnection);

            #region Parameterオブジェクトの作成
            //Parameterオブジェクトの作成(更新用)
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
            SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
            SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
            SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int); // ADD 2009/06/01

            //Parameterオブジェクトの作成(検索用)
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);  // 2010/01/28 Add
            #endregion

            #region Parameterオブジェクトへ値設定
            // Parameterオブジェクトへ値設定(更新用)
            // 更新日付

            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(DateTime.Now);
            // --------- ADD 2009/12/10 --------->>>>>
            // 棚卸運用区分＝ＰＭ７
            if (inventoryMngDiv == 1)
            {
                // 棚卸データ.在庫総数（実施日）へ「棚卸データ.在庫総数」をセットする
                ivtInputSearchResultWork.StockAmount = ivtInputSearchResultWork.StockTotal;
            }
            // --------- ADD 2009/12/10 ---------<<<<<
            // 棚卸過不足数 = 棚卸数 - 実施日帳簿数
            // 修正 2009.01.28 >>>
            //InventoryTolerancCnt = ivtInputSearchResultWork.StockTotal - ivtInputSearchResultWork.StockAmount;
            InventoryTolerancCnt = ivtInputSearchResultWork.InventoryStockCnt - ivtInputSearchResultWork.StockAmount;
            paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(ivtInputSearchResultWork.StockAmount);　// 実施日帳簿数
            // 修正 2009.01.28 <<<
            paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(InventoryTolerancCnt);
            // 棚卸過不足金額 = 棚卸過不足数 × 仕入単価           
            // 修正 2009/07/14 >>>
            //paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetDouble(InventoryTolerancCnt * ivtInputSearchResultWork.StockUnitPriceFl);
            FracCalc(InventoryTolerancCnt * ivtInputSearchResultWork.StockUnitPriceFl, 1, FractionProcCd, out resultNumerical);
            paraInventoryTlrncPrice.Value = resultNumerical;
            // 修正 2009/07/14 <<<

            
            paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( LastInventoryUpdate); // ADD 2009/06/01

            InventoryTlrncPrice = InventoryTolerancCnt * ivtInputSearchResultWork.StockUnitPriceFl;

            //Parameterオブジェクトへ値設定(検索用)
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
            findParaSectionCode.Value    = SqlDataMediator.SqlSetString(SectionCode);
            findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(InventorySeqNo);
            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseCode);    // 2010/01/28 Add
            #endregion

            try
            {
                sqlCommand.ExecuteNonQuery();              
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // ADD 2008.12.01 >>>
                ((InventInputSearchResultWork)al[i]).InventoryTolerancCnt = InventoryTolerancCnt;
                // 修正 2009/07/14 >>>
                //((InventInputSearchResultWork)al[i]).InventoryTlrncPrice = Convert.ToInt64(InventoryTlrncPrice);
                FracCalc(InventoryTolerancCnt * ivtInputSearchResultWork.StockUnitPriceFl, 1, FractionProcCd, out resultNumerical);
                ((InventInputSearchResultWork)al[i]).InventoryTlrncPrice = resultNumerical;

                // 修正 2009/07/14 <<<

                // ADD 2008.12.01 <<<
                ((InventInputSearchResultWork)al[i]).LastInventoryUpdate = LastInventoryUpdate; // ADD 2009/06/02
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.UpdateInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();               
            }
            return status;       

        }
        #endregion
        // ADD 2008/09/09 <<<


        #region 在庫受払履歴データ検索
        // --------------DEL 2010/02/20-------------->>>>>
        //private int GetStockAcPayHistData(string EnterpriseCode, string WarehouseCode, string SectionCode,
        //    string GoodsNo, int GoodsMakerCd,
        //    DateTime lastAddUpDate, DateTime targetDate,
        //    ref double arrivalCnt, ref double shipmentCnt,
        //    ref SqlConnection sqlConnection)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlCommand sqlCommand = null;
        //    SqlDataReader myReader = null;

        //    string sText = "";

        //    sText += "SELECT SUM(ARRIVALCNTRF) AS S_ARRIVALCNTRF, ";
        //    sText += "SUM(SHIPMENTCNTRF) AS S_SHIPMENTCNTRF ";
        //    sText += "FROM STOCKACPAYHISTRF ";
        //    sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
        //    sText += "AND LOGICALDELETECODERF=0 ";
        //    // 修正 2009/07/06 >>>
        //    //sText += "AND IOGOODSDAYRF>@LASTADDUPDATE ";
        //    //sText += "AND IOGOODSDAYRF<=@TARGETDATE ";
        //    sText += "AND ( (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END)>@LASTADDUPDATE ";
        //    sText += "     AND (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END)<=@TARGETDATE)";
        //    // 修正 2009/07/06 <<<
        //    sText += "AND WAREHOUSECODERF=@WAREHOUSECODE ";
        //    //sText += "AND SECTIONCODERF=@SECTIONCODE "; // DEL 2009/07/03
        //    sText += "AND GOODSNORF=@GOODSNO ";
        //    sText += "AND GOODSMAKERCDRF=@GOODSMAKERCD ";

        //    sqlCommand = new SqlCommand(sText, sqlConnection);

        //    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
        //    SqlParameter paraLastAddUpDate = sqlCommand.Parameters.Add("@LASTADDUPDATE", SqlDbType.Int);
        //    SqlParameter paraTargetDate = sqlCommand.Parameters.Add("@TARGETDATE", SqlDbType.Int);
        //    SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
        //    //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // DEL 2009/07/03
        //    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
        //    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);

        //    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
        //    if (lastAddUpDate == DateTime.MinValue)
        //    {
        //        paraLastAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(new DateTime(2000,01,01));
        //    }
        //    else
        //    {
        //        paraLastAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(lastAddUpDate);
        //    }
        //    paraTargetDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(targetDate);
        //    paraWarehouseCode.Value = SqlDataMediator.SqlSetString(WarehouseCode);
        //    //paraSectionCode.Value = SqlDataMediator.SqlSetString(SectionCode); // DEL 2009/07/03
        //    paraGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsNo);
        //    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsMakerCd);


        //    try
        //    {
        //        myReader = sqlCommand.ExecuteReader();

        //        if (myReader.Read())
        //        {
        //            arrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("S_ARRIVALCNTRF"));
        //            shipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("S_SHIPMENTCNTRF"));
        //        }
        //        else
        //        {
        //            arrivalCnt = 0.0;
        //            shipmentCnt = 0.0;
        //        }
        //        if (!myReader.IsClosed) myReader.Close();
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        base.WriteErrorLog(ex, "InventoryExtDB.GetStockAcPayHistData Exception=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null) sqlCommand.Dispose();
        //        if (myReader != null && !myReader.IsClosed) myReader.Close();
        //    }
        //    return status;
        //}
        // --------------DEL 2010/02/20--------------<<<<<
        /// <summary>
        /// 在庫受払履歴データ取得
        /// </summary>
        /// <param name="stockAcpayHistWorkList">在庫受払履歴データ全件</param>
        /// <param name="WarehouseCode">倉庫コード</param>
        /// <param name="GoodsNo">品番</param>
        /// <param name="GoodsMakerCd">メーカーコード</param>
        /// <param name="lastAddUpDate">月次更新年月日</param>
        /// <param name="targetDate">棚卸日</param>
        /// <param name="arrivalCnt">入荷数</param>
        /// <param name="shipmentCnt">出荷数</param>
        /// <remarks>
        /// <br>Note		: 指定した在庫受払履歴データを取得する。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private void GetStockAcPayHistData(List<StockAcPayHistWork> stockAcpayHistWorkList, string WarehouseCode, string GoodsNo, int GoodsMakerCd, DateTime lastAddUpDate,
                DateTime targetDate, MonthlyAddUpHisWork monthlyAddUpHisWork, ref double arrivalCnt, ref double shipmentCnt)
        {
            // 入荷数
            arrivalCnt = 0.0;
            // 出荷数
            shipmentCnt = 0.0;

            // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 *-------------------->>>
            // 入荷数
            double arrivalCntWork = 0.0;
            // 出荷数
            double shipmentCntWork = 0.0;
            // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 <<<--------------------*

            if (lastAddUpDate == DateTime.MinValue)
            {
                lastAddUpDate = new DateTime(2000, 01, 01);
            }

            List<StockAcPayHistWork> newList = stockAcpayHistWorkList.FindAll(
                delegate(StockAcPayHistWork stockAcPayHistWork)
                {
                    if (stockAcPayHistWork.WarehouseCode == WarehouseCode
                        && stockAcPayHistWork.GoodsNo == GoodsNo
                        && stockAcPayHistWork.GoodsMakerCd.Equals(GoodsMakerCd))
                    {
                        //[計上日付 = NULL]の場合
                        if (stockAcPayHistWork.AddUpADate == DateTime.MinValue)
                        {
                            //if (stockAcPayHistWork.IoGoodsDay > lastAddUpDate                         // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
                            if (stockAcPayHistWork.IoGoodsDay > monthlyAddUpHisWork.MonthlyAddUpDate    // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応
                              && stockAcPayHistWork.IoGoodsDay <= targetDate)
                            {
                                // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 *-------------------->>>
                                // FindAllの結果をもう一度回すのは無駄
                                arrivalCntWork += stockAcPayHistWork.ArrivalCnt;
                                shipmentCntWork += stockAcPayHistWork.ShipmentCnt;
                                // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 <<<--------------------*
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        // [計上日付 != NULL]の場合
                        else
                        {
                            //if (stockAcPayHistWork.AddUpADate > lastAddUpDate                         // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
                            if (stockAcPayHistWork.AddUpADate > monthlyAddUpHisWork.MonthlyAddUpDate    // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応
                                && stockAcPayHistWork.AddUpADate <= targetDate)
                            {
                                // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 *-------------------->>>
                                // FindAllの結果をもう一度回すのは無駄
                                arrivalCntWork += stockAcPayHistWork.ArrivalCnt;
                                shipmentCntWork += stockAcPayHistWork.ShipmentCnt;
                                // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 <<<--------------------*
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            #region // DEL 2013/02/15 22013 久保@仕掛一覧 No1552対応
            //// 入荷数と出荷数の取得
            //foreach (StockAcPayHistWork work in newList)
            //{
            //    arrivalCnt += work.ArrivalCnt;
            //    shipmentCnt += work.ShipmentCnt;
            //}
	        #endregion        

            // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 *-------------------->>>
            arrivalCnt = arrivalCntWork;
            shipmentCnt = shipmentCntWork;
            // ADD 2013/02/15 22013 久保@仕掛一覧 No1552対応 <<<--------------------*
        }
        #endregion  // 在庫受払履歴データ検索

        // ADD 2009/07/14 >>>
        #region [FracCalc 端数処理]
        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="inputNumerical">数値</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultNumerical">算出金額</param>
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
        // ADD 2009/07/14 <<<

        // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
        #region SearchInvent
        /// <summary>
        /// 棚卸検索(過不足專用)
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸マスタの検索を行うメソッドです。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/10/09</br>
        public int SearchInvent(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out object dicPrice)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retobj = new object();

            dicPrice = new object();

            ArrayList al = new ArrayList();
            CustomSerializeArrayList cstmAl = new CustomSerializeArrayList();
            InventInputSearchCndtnWork _inventInputSearchCndtnWork = paraobj as InventInputSearchCndtnWork;
            SqlConnection sqlConnection = null;
            int ProductNumberOutPutDiv;
            int alElementType = 0;              // 0:InventoryDataUpdateWork、1:InventInputSearchResultWork   2008.03.21 Add

            try
            {

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                Dictionary<string, InventInputSearchResultWork> skipDic = new Dictionary<string, InventInputSearchResultWork>();
                //SkipSearch(out skipDic, _inventInputSearchCndtnWork, ref sqlConnection); // DEL 2009/06/01

                ProductNumberOutPutDiv = -1;
                //非グロスデータ取得実行部
                status = SearchNonGrossActionInvent(ref al, ref sqlConnection, _inventInputSearchCndtnWork, ProductNumberOutPutDiv, logicalMode, skipDic, ref dicPrice);

                //在庫数設定
                if (_inventInputSearchCndtnWork.CalcStockAmountDiv == 1)
                {
                    alElementType = 0;
                    status = CalcStockTotal(ref al, ref sqlConnection, _inventInputSearchCndtnWork, alElementType);
                }

                cstmAl.Add(al);
                retobj = cstmAl;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.Search:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }
            return status;
        }
        #endregion

        #region 製番データ取得処理
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_inventInputSearchCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br></br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchNonGrossActionInvent(ref ArrayList al, ref SqlConnection sqlConnection, InventInputSearchCndtnWork _inventInputSearchCndtnWork, int productNumberOutPutDiv, ConstantManagement.LogicalMode logicalMode, Dictionary<string, InventInputSearchResultWork> skipDic, ref object dicPriceObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            Dictionary<string, GoodsPriceUWork> dicPrice = new Dictionary<string, GoodsPriceUWork>();
            Dictionary<string, List<GoodsPriceUWork>> dicPriceRet = new Dictionary<string, List<GoodsPriceUWork>>();
            Dictionary<string, InventoryDataUpdateWork> dicInvent = new Dictionary<string, InventoryDataUpdateWork>();

            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

            try
            {
                // 対象テーブル
                // INVENTORYDATARF IVD   棚卸データ
                string SelectDm = "";

                #region 2008.12.05 DEL
                /*
                SelectDm += "SELECT";

                //結果取得
                SelectDm += " IVD.CREATEDATETIMERF IVD_CREATEDATETIMERF";
                SelectDm += ", IVD.UPDATEDATETIMERF IVD_UPDATEDATETIMERF";
                SelectDm += ", IVD.ENTERPRISECODERF IVD_ENTERPRISECODERF";
                SelectDm += ", IVD.FILEHEADERGUIDRF IVD_FILEHEADERGUIDRF";
                SelectDm += ", IVD.UPDEMPLOYEECODERF IVD_UPDEMPLOYEECODERF";
                SelectDm += ", IVD.UPDASSEMBLYID1RF IVD_UPDASSEMBLYID1RF";
                SelectDm += ", IVD.UPDASSEMBLYID2RF IVD_UPDASSEMBLYID2RF";
                SelectDm += ", IVD.LOGICALDELETECODERF IVD_LOGICALDELETECODERF";
                SelectDm += ", IVD.SECTIONCODERF IVD_SECTIONCODERF";
                SelectDm += ", IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF";
                SelectDm += ", IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF";
                SelectDm += ", IVD.GOODSMAKERCDRF IVD_GOODSMAKERCDRF";
                SelectDm += ", IVD.GOODSNORF IVD_GOODSNORF";
                SelectDm += ", IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF";
                SelectDm += ", IVD.DUPLICATIONSHELFNO1RF IVD_DUPLICATIONSHELFNO1RF";
                SelectDm += ", IVD.DUPLICATIONSHELFNO2RF IVD_DUPLICATIONSHELFNO2RF";
                SelectDm += ", IVD.GOODSLGROUPRF IVD_GOODSLGROUPRF";
                SelectDm += ", IVD.GOODSMGROUPRF IVD_GOODSMGROUPRF";
                SelectDm += ", IVD.BLGROUPCODERF IVD_BLGROUPCODERF";
                SelectDm += ", IVD.ENTERPRISEGANRECODERF IVD_ENTERPRISEGANRECODERF";
                SelectDm += ", IVD.BLGOODSCODERF IVD_BLGOODSCODERF";
                SelectDm += ", IVD.SUPPLIERCDRF IVD_SUPPLIERCDRF";
                SelectDm += ", IVD.JANRF IVD_JANRF";
                SelectDm += ", IVD.STOCKUNITPRICEFLRF IVD_STOCKUNITPRICEFLRF";
                SelectDm += ", IVD.BFSTOCKUNITPRICEFLRF IVD_BFSTOCKUNITPRICEFLRF";
                SelectDm += ", IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF";
                SelectDm += ", IVD.STOCKDIVRF IVD_STOCKDIVRF";
                SelectDm += ", IVD.LASTSTOCKDATERF IVD_LASTSTOCKDATERF";
                SelectDm += ", IVD.STOCKTOTALRF IVD_STOCKTOTALRF";
                SelectDm += ", IVD.SHIPCUSTOMERCODERF IVD_SHIPCUSTOMERCODERF";
                SelectDm += ", IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF";
                SelectDm += ", IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF";
                SelectDm += ", IVD.INVENTORYPREPRDAYRF IVD_INVENTORYPREPRDAYRF";
                SelectDm += ", IVD.INVENTORYPREPRTIMRF IVD_INVENTORYPREPRTIMRF";
                SelectDm += ", IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF";
                SelectDm += ", IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF";
                SelectDm += ", IVD.INVENTORYNEWDIVRF IVD_INVENTORYNEWDIVRF";
                SelectDm += ", IVD.STOCKMASHINEPRICERF IVD_STOCKMASHINEPRICERF";
                SelectDm += ", IVD.INVENTORYSTOCKPRICERF IVD_INVENTORYSTOCKPRICERF";
                SelectDm += ", IVD.INVENTORYTLRNCPRICERF IVD_INVENTORYTLRNCPRICERF";
                SelectDm += ", IVD.INVENTORYDATERF IVD_INVENTORYDATERF";
                SelectDm += ", IVD.STOCKTOTALEXECRF IVD_STOCKTOTALEXECRF";
                SelectDm += ", IVD.TOLERANCEUPDATECDRF IVD_TOLERANCEUPDATECDRF";

                // 拠点情報設定マスタ・拠点ガイド名称
                SelectDm += ", SEC.SECTIONGUIDENMRF SEC_SECTIONGUIDENMRF";               
                // 倉庫マスタ・倉庫名称
                SelectDm += ", WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF";
                // メーカーマスタ・メーカー名称
                SelectDm += ", MAK.GOODSMAKERCDRF MAK_GOODSMAKERCDRF";
                // ユーザーガイドマスタ・大分類名称
                SelectDm += ", USRGDL.GUIDENAMERF USRGDL_GUIDENAMERF";
                // グループコードマスタ・グループコード名称
                SelectDm += ", BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF";
                // ユーザーガイドマスタ・自社分類名称
                SelectDm += ", USRGDE.GUIDENAMERF USRGDE_GUIDENAMERF";
                // 商品中分類マスタ・中分類名称
                SelectDm += ", GGR.GOODSMGROUPNAMERF GGR_GOODSMGROUPNAMERF";
                // 商品マスタ・商品名称
                SelectDm += ", GOODS.GOODSNAMERF GOODS_GOODSNAMERF";
                // 得意先マスタ・名称1・2
                SelectDm += ", CTM.NAMERF CTM_NAMERF";
                SelectDm += ", CTM.NAME2RF CTM_NAME2RF";
                // BLコードマスタ・BL商品名称
                SelectDm += ", BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF";

                SelectDm += " FROM INVENTORYDATARF AS IVD";

                // 拠点情報設定マスタ結合
                SelectDm += " LEFT JOIN SECINFOSETRF AS SEC ON SEC.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND SEC.SECTIONCODERF=IVD.SECTIONCODERF";
                
                // 倉庫マスタ結合
                SelectDm += " LEFT JOIN WAREHOUSERF AS WH ON WH.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND WH.WAREHOUSECODERF=IVD.WAREHOUSECODERF";
                // メーカーマスタ結合
                SelectDm += " LEFT JOIN MAKERURF AS MAK ON MAK.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND MAK.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF";
                // 商品マスタ結合
                SelectDm += " LEFT JOIN GOODSURF AS GOODS ON GOODS.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND GOODS.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF AND GOODS.GOODSNORF=IVD.GOODSNORF";
                // 商品中分類マスタ結合
                SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR ON GGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND GGR.GOODSMGROUPRF=IVD.GOODSMGROUPRF"; 
                // グループコードマスタ結合
                //SelectDm += " LEFT JOIN BLGROUPURF AS BLGR ON BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF"; // DEL 2008.12.05
                SelectDm += " LEFT JOIN BLGROUPURF AS BLGR ON BLGR.ENTERPRISECODERF = IVD.ENTERPRISECODERF AND BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF"; // ADD 2008.12.05

                // ユーザーガイドマスタ結合(大分類)
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL ON USRGDL.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND USRGDL.USERGUIDEDIVCDRF=70 AND USRGDL.GUIDECODERF=IVD.GOODSLGROUPRF"; 
                // ユーザーガイドマスタ結合(自社分類)
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE ON USRGDE.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND USRGDE.USERGUIDEDIVCDRF=41 AND USRGDE.GUIDECODERF=IVD.ENTERPRISEGANRECODERF";
                // 得意先マスタ結合
                SelectDm += " LEFT JOIN CUSTOMERRF AS CTM ON CTM.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND CTM.CUSTOMERCODERF = IVD.SHIPCUSTOMERCODERF";
                // BLコードマスタ結合
                SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD ON BLCD.ENTERPRISECODERF=IVD.ENTERPRISECODERF AND BLCD.BLGOODSCODERF = IVD.BLGOODSCODERF";
                // ADD 2008.12.01 >>>
                // 在庫マスタ結合
                SelectDm += " LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine;
                SelectDm += " ON IVD.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSNORF = STOCK.GOODSNORF " + Environment.NewLine;
                // ADD 2008.12.01 <<<                
                */
                #endregion

                #region Select文作成
                #region  DEL 2009/06/01
                /*
                // ADD 2008.12.05 >>>
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += "         IVD.CREATEDATETIMERF IVD_CREATEDATETIMERF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDATEDATETIMERF IVD_UPDATEDATETIMERF" + Environment.NewLine;
                SelectDm += "        ,IVD.ENTERPRISECODERF IVD_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.FILEHEADERGUIDRF IVD_FILEHEADERGUIDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDEMPLOYEECODERF IVD_UPDEMPLOYEECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDASSEMBLYID1RF IVD_UPDASSEMBLYID1RF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDASSEMBLYID2RF IVD_UPDASSEMBLYID2RF" + Environment.NewLine;
                SelectDm += "        ,IVD.LOGICALDELETECODERF IVD_LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.SECTIONCODERF IVD_SECTIONCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF" + Environment.NewLine;
                SelectDm += "        ,IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSMAKERCDRF IVD_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSNORF IVD_GOODSNORF" + Environment.NewLine;
                SelectDm += "        ,IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += "        ,IVD.DUPLICATIONSHELFNO1RF IVD_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += "        ,IVD.DUPLICATIONSHELFNO2RF IVD_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSLGROUPRF IVD_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSMGROUPRF IVD_GOODSMGROUPRF" + Environment.NewLine;
                SelectDm += "        ,IVD.BLGROUPCODERF IVD_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.ENTERPRISEGANRECODERF IVD_ENTERPRISEGANRECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.BLGOODSCODERF IVD_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.SUPPLIERCDRF IVD_SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.JANRF IVD_JANRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKUNITPRICEFLRF IVD_STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "        ,IVD.BFSTOCKUNITPRICEFLRF IVD_BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKDIVRF IVD_STOCKDIVRF" + Environment.NewLine;
                SelectDm += "        ,IVD.LASTSTOCKDATERF IVD_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKTOTALRF IVD_STOCKTOTALRF" + Environment.NewLine;
                SelectDm += "        ,IVD.SHIPCUSTOMERCODERF IVD_SHIPCUSTOMERCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYPREPRDAYRF IVD_INVENTORYPREPRDAYRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYPREPRTIMRF IVD_INVENTORYPREPRTIMRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF" + Environment.NewLine;
                SelectDm += "        ,IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYNEWDIVRF IVD_INVENTORYNEWDIVRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKMASHINEPRICERF IVD_STOCKMASHINEPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSTOCKPRICERF IVD_INVENTORYSTOCKPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYTLRNCPRICERF IVD_INVENTORYTLRNCPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYDATERF IVD_INVENTORYDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKTOTALEXECRF IVD_STOCKTOTALEXECRF" + Environment.NewLine;
                SelectDm += "        ,IVD.TOLERANCEUPDATECDRF IVD_TOLERANCEUPDATECDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.ADJSTCALCCOSTRF IVD_ADJSTCALCCOSTRF" + Environment.NewLine; // ADD 2009/05/21
                SelectDm += "        ,SEC.SECTIONGUIDENMRF SEC_SECTIONGUIDENMRF" + Environment.NewLine;
                SelectDm += "        ,WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;
                SelectDm += "        ,MAK.GOODSMAKERCDRF MAK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "        ,USRGDL.GUIDENAMERF USRGDL_GUIDENAMERF" + Environment.NewLine;
                SelectDm += "        ,BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;
                SelectDm += "        ,USRGDE.GUIDENAMERF USRGDE_GUIDENAMERF" + Environment.NewLine;
                SelectDm += "        ,GGR.GOODSMGROUPNAMERF GGR_GOODSMGROUPNAMERF" + Environment.NewLine;
                SelectDm += "        ,GOODS.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                SelectDm += "        ,CTM.NAMERF CTM_NAMERF" + Environment.NewLine;
                SelectDm += "        ,CTM.NAME2RF CTM_NAME2RF" + Environment.NewLine;
                SelectDm += "        ,BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;
                SelectDm += "FROM" + Environment.NewLine;
                SelectDm += "(        " + Environment.NewLine;
                SelectDm += "SELECT IVD.CREATEDATETIMERF CREATEDATETIMERF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDATEDATETIMERF   UPDATEDATETIMERF" + Environment.NewLine;
                SelectDm += "        ,IVD.ENTERPRISECODERF   ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.FILEHEADERGUIDRF   FILEHEADERGUIDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDEMPLOYEECODERF   UPDEMPLOYEECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDASSEMBLYID1RF   UPDASSEMBLYID1RF" + Environment.NewLine;
                SelectDm += "        ,IVD.UPDASSEMBLYID2RF   UPDASSEMBLYID2RF" + Environment.NewLine;
                SelectDm += "        ,IVD.LOGICALDELETECODERF   LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.SECTIONCODERF   SECTIONCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSEQNORF   INVENTORYSEQNORF" + Environment.NewLine;
                SelectDm += "        ,IVD.WAREHOUSECODERF   WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSMAKERCDRF   GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSNORF   GOODSNORF        " + Environment.NewLine;
                SelectDm += "        ,(CASE WHEN STOCK.WAREHOUSESHELFNORF IS NOT Null THEN STOCK.WAREHOUSESHELFNORF ELSE '' END) WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += "        ,(CASE WHEN STOCK.DUPLICATIONSHELFNO1RF IS NOT Null THEN STOCK.DUPLICATIONSHELFNO1RF ELSE '' END) DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += "        ,(CASE WHEN STOCK.DUPLICATIONSHELFNO2RF IS NOT Null THEN STOCK.DUPLICATIONSHELFNO2RF ELSE '' END) DUPLICATIONSHELFNO2RF        " + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSLGROUPRF   GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += "        ,IVD.GOODSMGROUPRF   GOODSMGROUPRF" + Environment.NewLine;
                SelectDm += "        ,IVD.BLGROUPCODERF   BLGROUPCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.ENTERPRISEGANRECODERF   ENTERPRISEGANRECODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.BLGOODSCODERF   BLGOODSCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.SUPPLIERCDRF   SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.JANRF   JANRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKUNITPRICEFLRF   STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "        ,IVD.BFSTOCKUNITPRICEFLRF   BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STKUNITPRICECHGFLGRF   STKUNITPRICECHGFLGRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKDIVRF   STOCKDIVRF" + Environment.NewLine;
                SelectDm += "        ,IVD.LASTSTOCKDATERF   LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKTOTALRF   STOCKTOTALRF" + Environment.NewLine;
                SelectDm += "        ,IVD.SHIPCUSTOMERCODERF   SHIPCUSTOMERCODERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSTOCKCNTRF   INVENTORYSTOCKCNTRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYTOLERANCCNTRF   INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYPREPRDAYRF   INVENTORYPREPRDAYRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYPREPRTIMRF   INVENTORYPREPRTIMRF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYDAYRF   INVENTORYDAYRF" + Environment.NewLine;
                SelectDm += "        ,IVD.LASTINVENTORYUPDATERF   LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYNEWDIVRF   INVENTORYNEWDIVRF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKMASHINEPRICERF   STOCKMASHINEPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYSTOCKPRICERF   INVENTORYSTOCKPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYTLRNCPRICERF   INVENTORYTLRNCPRICERF" + Environment.NewLine;
                SelectDm += "        ,IVD.INVENTORYDATERF   INVENTORYDATERF" + Environment.NewLine;
                SelectDm += "        ,IVD.STOCKTOTALEXECRF   STOCKTOTALEXECRF" + Environment.NewLine;
                SelectDm += "        ,IVD.TOLERANCEUPDATECDRF   TOLERANCEUPDATECDRF" + Environment.NewLine;
                SelectDm += "        ,IVD.ADJSTCALCCOSTRF" + Environment.NewLine; // ADD 2009/05/21 
                SelectDm += " FROM INVENTORYDATARF AS IVD LEFT" + Environment.NewLine;
                SelectDm += " JOIN STOCKRF AS STOCK ON IVD.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND IVD.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                SelectDm += " " + Environment.NewLine;
                SelectDm += " ) IVD " + Environment.NewLine;
                SelectDm += " LEFT" + Environment.NewLine;
                SelectDm += " JOIN SECINFOSETRF AS SEC ON SEC.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND SEC.SECTIONCODERF=IVD.SECTIONCODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN WAREHOUSERF AS WH ON WH.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND WH.WAREHOUSECODERF=IVD.WAREHOUSECODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN MAKERURF AS MAK ON MAK.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND MAK.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF LEFT" + Environment.NewLine;
                SelectDm += " JOIN GOODSURF AS GOODS ON GOODS.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSNORF=IVD.GOODSNORF LEFT" + Environment.NewLine;
                SelectDm += " JOIN GOODSGROUPURF AS GGR ON GGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GGR.GOODSMGROUPRF=IVD.GOODSMGROUPRF LEFT" + Environment.NewLine;
                SelectDm += " JOIN BLGROUPURF AS BLGR ON BLGR.ENTERPRISECODERF = IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN USERGDBDURF AS USRGDL ON USRGDL.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND USRGDL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
                SelectDm += " AND USRGDL.GUIDECODERF=IVD.GOODSLGROUPRF LEFT" + Environment.NewLine;
                SelectDm += " JOIN USERGDBDURF AS USRGDE ON USRGDE.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND USRGDE.USERGUIDEDIVCDRF=41" + Environment.NewLine;
                SelectDm += " AND USRGDE.GUIDECODERF=IVD.ENTERPRISEGANRECODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN CUSTOMERRF AS CTM ON CTM.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND CTM.CUSTOMERCODERF = IVD.SHIPCUSTOMERCODERF LEFT" + Environment.NewLine;
                SelectDm += " JOIN BLGOODSCDURF AS BLCD ON BLCD.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLCD.BLGOODSCODERF = IVD.BLGOODSCODERF " + Environment.NewLine;
                // ADD 2008.12.05 <<<
                */
                #endregion

                // ADD 2009/06/01 >>>
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += " IVD.CREATEDATETIMERF IVD_CREATEDATETIMERF" + Environment.NewLine;
                SelectDm += " ,IVD.UPDATEDATETIMERF IVD_UPDATEDATETIMERF" + Environment.NewLine;
                SelectDm += " ,IVD.ENTERPRISECODERF IVD_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.FILEHEADERGUIDRF IVD_FILEHEADERGUIDRF" + Environment.NewLine;
                SelectDm += " ,IVD.UPDEMPLOYEECODERF IVD_UPDEMPLOYEECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.UPDASSEMBLYID1RF IVD_UPDASSEMBLYID1RF" + Environment.NewLine;
                SelectDm += " ,IVD.UPDASSEMBLYID2RF IVD_UPDASSEMBLYID2RF" + Environment.NewLine;
                SelectDm += " ,IVD.LOGICALDELETECODERF IVD_LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.SECTIONCODERF IVD_SECTIONCODERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF" + Environment.NewLine;
                SelectDm += " ,IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.GOODSMAKERCDRF IVD_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " ,IVD.GOODSNORF IVD_GOODSNORF" + Environment.NewLine;
                SelectDm += " ,IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += " ,IVD.DUPLICATIONSHELFNO1RF IVD_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += " ,IVD.DUPLICATIONSHELFNO2RF IVD_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += " ,IVD.GOODSLGROUPRF IVD_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += " ,IVD.GOODSMGROUPRF IVD_GOODSMGROUPRF" + Environment.NewLine;
                SelectDm += " ,IVD.BLGROUPCODERF IVD_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += " ,IVD.ENTERPRISEGANRECODERF IVD_ENTERPRISEGANRECODERF" + Environment.NewLine;
                SelectDm += " ,IVD.BLGOODSCODERF IVD_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += " ,IVD.SUPPLIERCDRF IVD_SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += " ,IVD.JANRF IVD_JANRF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKUNITPRICEFLRF IVD_STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += " ,IVD.BFSTOCKUNITPRICEFLRF IVD_BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += " ,IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKDIVRF IVD_STOCKDIVRF" + Environment.NewLine;
                SelectDm += " ,IVD.LASTSTOCKDATERF IVD_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKTOTALRF IVD_STOCKTOTALRF" + Environment.NewLine;
                SelectDm += " ,IVD.SHIPCUSTOMERCODERF IVD_SHIPCUSTOMERCODERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYPREPRDAYRF IVD_INVENTORYPREPRDAYRF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYPREPRTIMRF IVD_INVENTORYPREPRTIMRF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF" + Environment.NewLine;
                SelectDm += " ,IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYNEWDIVRF IVD_INVENTORYNEWDIVRF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKMASHINEPRICERF IVD_STOCKMASHINEPRICERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYSTOCKPRICERF IVD_INVENTORYSTOCKPRICERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYTLRNCPRICERF IVD_INVENTORYTLRNCPRICERF" + Environment.NewLine;
                SelectDm += " ,IVD.INVENTORYDATERF IVD_INVENTORYDATERF" + Environment.NewLine;
                SelectDm += " ,IVD.STOCKTOTALEXECRF IVD_STOCKTOTALEXECRF" + Environment.NewLine;
                SelectDm += " ,IVD.TOLERANCEUPDATECDRF IVD_TOLERANCEUPDATECDRF" + Environment.NewLine;
                SelectDm += " ,IVD.ADJSTCALCCOSTRF IVD_ADJSTCALCCOSTRF " + Environment.NewLine;
                SelectDm += " ,SEC.SECTIONGUIDENMRF SEC_SECTIONGUIDENMRF" + Environment.NewLine;
                SelectDm += " ,WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;
                SelectDm += " ,MAK.GOODSMAKERCDRF MAK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " ,USRGDL.GUIDENAMERF USRGDL_GUIDENAMERF" + Environment.NewLine;
                SelectDm += " ,BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;
                SelectDm += " ,USRGDE.GUIDENAMERF USRGDE_GUIDENAMERF" + Environment.NewLine;
                SelectDm += " ,GGR.GOODSMGROUPNAMERF GGR_GOODSMGROUPNAMERF" + Environment.NewLine;
                //SelectDm += " ,GOODS.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine; // DEL 2011/01/11
                SelectDm += " ,IVD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine; // ADD 2011/01/11
                SelectDm += " ,GOODS.GOODSNAMERF GOODS_GOODSNAMERF_NEW" + Environment.NewLine; // ADD 2011/02/12
                //SelectDm += " ,IVD.LISTPRICEFLRF GOODS_LISTPRICERF" + Environment.NewLine; // ADD 2011/01/30 // DEL 2011/02/16

                SelectDm += " ,GOODSPRICE.LISTPRICERF GOODSPRICE_LISTPRICERF" + Environment.NewLine; // ADD 2011/02/12 // DEL 2011/02/16
                SelectDm += " ,GOODSPRICE.PRICESTARTDATERF GOODSPRICE_PRICESTARTDATERF" + Environment.NewLine; // ADD 2011/02/12 // DEL 2011/02/16

                SelectDm += " ,CTM.NAMERF CTM_NAMERF" + Environment.NewLine;
                SelectDm += " ,CTM.NAME2RF CTM_NAME2RF" + Environment.NewLine;
                SelectDm += " ,BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;
                // --- ADD 2010/02/23 ---------->>>>>
                SelectDm += " ,(CASE WHEN GOODS.LOGICALDELETECODERF IS NULL THEN 1 ELSE GOODS.LOGICALDELETECODERF END) AS IVD_GOODSDIVRF" + Environment.NewLine;
                // --- ADD 2010/02/23 ----------<<<<<
                //SelectDm += "FROM INVENTORYDATARF AS IVD" + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "FROM INVENTORYDATARF AS IVD WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼

                #region 結合
                //SelectDm += " LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON SEC.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND SEC.SECTIONCODERF=IVD.SECTIONCODERF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN WAREHOUSERF AS WH " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN WAREHOUSERF AS WH WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON WH.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND WH.WAREHOUSECODERF=IVD.WAREHOUSECODERF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON MAK.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND MAK.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN GOODSURF AS GOODS " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON GOODS.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND GOODS.GOODSMAKERCDRF=IVD.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "  AND GOODS.GOODSNORF=IVD.GOODSNORF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN GOODSGROUPURF AS GGR WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON GGR.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND GGR.GOODSMGROUPRF=IVD.GOODSMGROUPRF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN BLGROUPURF AS BLGR " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN BLGROUPURF AS BLGR WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON BLGR.ENTERPRISECODERF = IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND BLGR.BLGROUPCODERF=IVD.BLGROUPCODERF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDL WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON USRGDL.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND USRGDL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
                SelectDm += "  AND USRGDL.GUIDECODERF=IVD.GOODSLGROUPRF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN USERGDBDURF AS USRGDE WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON USRGDE.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND USRGDE.USERGUIDEDIVCDRF=41" + Environment.NewLine;
                SelectDm += "  AND USRGDE.GUIDECODERF=IVD.ENTERPRISEGANRECODERF" + Environment.NewLine;
                //SelectDm += " LEFT JOIN CUSTOMERRF AS CTM " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN CUSTOMERRF AS CTM WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON CTM.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND CTM.CUSTOMERCODERF = IVD.SHIPCUSTOMERCODERF " + Environment.NewLine;
                //SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD " + Environment.NewLine;//Del 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += " LEFT JOIN BLGOODSCDURF AS BLCD WITH (READUNCOMMITTED) " + Environment.NewLine;//Add 2012/03/23 zhangyong for Redmine#29109 ReadUnCommitted の修正依頼
                SelectDm += "  ON BLCD.ENTERPRISECODERF=IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += "  AND BLCD.BLGOODSCODERF = IVD.BLGOODSCODERF " + Environment.NewLine;

                SelectDm += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine;
                SelectDm += " ON GOODSPRICE.ENTERPRISECODERF = IVD.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODSPRICE.GOODSMAKERCDRF = IVD.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODSPRICE.GOODSNORF = IVD.GOODSNORF " + Environment.NewLine;

                #endregion
                // ADD 2009/06/01 <<<

                #endregion

                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _inventInputSearchCndtnWork, productNumberOutPutDiv, logicalMode);

                #region DEL 2009/06/01
                //if (skipDic.Count > 0)
                //{
                //    int skipDicCount = 0;
                //    foreach (InventInputSearchResultWork skipInventInputSearchResultWork in skipDic.Values)
                //    {
                //        sqlCommand.CommandText += " AND (IVD.GOODSMAKERCDRF!=@GOODSMAKERCD" + skipDicCount.ToString() + " OR IVD.GOODSNORF!=@GOODSNO" + skipDicCount.ToString() + ")";
                //        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + skipDicCount.ToString(), SqlDbType.Int);
                //        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(skipInventInputSearchResultWork.GoodsMakerCd);
                //        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO" + skipDicCount.ToString(), SqlDbType.NVarChar);
                //        paraGoodsNo.Value = SqlDataMediator.SqlSetString(skipInventInputSearchResultWork.GoodsNo);
                //        skipDicCount++;
                //    }
                //}
                #endregion

                myReader = sqlCommand.ExecuteReader();

                //棚卸数入力の場合
                if ((productNumberOutPutDiv == 0) || (productNumberOutPutDiv == -1))
                {
                    while (myReader.Read())
                    {
                        #region 抽出結果-値セット
                        InventoryDataUpdateWork wkInventoryDataUpdateWork = new InventoryDataUpdateWork();

                        wkInventoryDataUpdateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("IVD_CREATEDATETIMERF"));
                        wkInventoryDataUpdateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("IVD_UPDATEDATETIMERF"));
                        wkInventoryDataUpdateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_ENTERPRISECODERF"));
                        wkInventoryDataUpdateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("IVD_FILEHEADERGUIDRF"));
                        wkInventoryDataUpdateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_UPDEMPLOYEECODERF"));
                        wkInventoryDataUpdateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_UPDASSEMBLYID1RF"));
                        wkInventoryDataUpdateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_UPDASSEMBLYID2RF"));
                        wkInventoryDataUpdateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_LOGICALDELETECODERF"));
                        wkInventoryDataUpdateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                        wkInventoryDataUpdateWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                        wkInventoryDataUpdateWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                        wkInventoryDataUpdateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                        wkInventoryDataUpdateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                        wkInventoryDataUpdateWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                        wkInventoryDataUpdateWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO1RF"));
                        wkInventoryDataUpdateWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO2RF"));
                        wkInventoryDataUpdateWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSLGROUPRF"));
                        wkInventoryDataUpdateWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMGROUPRF"));
                        wkInventoryDataUpdateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGROUPCODERF"));
                        wkInventoryDataUpdateWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_ENTERPRISEGANRECODERF"));
                        wkInventoryDataUpdateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGOODSCODERF"));
                        wkInventoryDataUpdateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SUPPLIERCDRF"));
                        wkInventoryDataUpdateWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_JANRF"));
                        wkInventoryDataUpdateWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                        wkInventoryDataUpdateWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                        wkInventoryDataUpdateWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                        wkInventoryDataUpdateWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STOCKDIVRF"));
                        wkInventoryDataUpdateWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTSTOCKDATERF"));
                        wkInventoryDataUpdateWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));
                        wkInventoryDataUpdateWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SHIPCUSTOMERCODERF"));
                        wkInventoryDataUpdateWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                        wkInventoryDataUpdateWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                        wkInventoryDataUpdateWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRDAYRF"));
                        wkInventoryDataUpdateWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRTIMRF"));
                        wkInventoryDataUpdateWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                        wkInventoryDataUpdateWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                        wkInventoryDataUpdateWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYNEWDIVRF"));
                        wkInventoryDataUpdateWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_STOCKMASHINEPRICERF"));
                        wkInventoryDataUpdateWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKPRICERF"));
                        wkInventoryDataUpdateWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYTLRNCPRICERF"));
                        wkInventoryDataUpdateWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDATERF"));
                        wkInventoryDataUpdateWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALEXECRF"));
                        wkInventoryDataUpdateWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_TOLERANCEUPDATECDRF"));
                        wkInventoryDataUpdateWork.StockAmount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));

                        wkInventoryDataUpdateWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));  // ADD 2009/04/13 <<<
                        //wkInventoryDataUpdateWork.Status = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STATUSRF"));
                        //wkInventoryDataUpdateWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODS_LISTPRICERF"));  // ADD 2011/01/30  // DEL 2011/02/16


                        DateTime priceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICE_PRICESTARTDATERF"));  // ADD 2011/01/30  // DEL 2011/02/16
                        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                        //double listPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF")); // DEL 2011/02/16
                        convertDoubleRelease.EnterpriseCode = wkInventoryDataUpdateWork.EnterpriseCode;
                        convertDoubleRelease.GoodsMakerCd = wkInventoryDataUpdateWork.GoodsMakerCd;
                        convertDoubleRelease.GoodsNo = wkInventoryDataUpdateWork.GoodsNo;
                        convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF"));

                        // 変換処理実行
                        convertDoubleRelease.ReleaseProc();

                        double listPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

                        // --- ADD 2011/02/12 ---------->>>>>
                        // --- UPD 2011/02/16 --->>>>>
                        //if ("".Equals(wkInventoryDataUpdateWork.GoodsName) && !"ｶｼﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                        if ("".Equals(wkInventoryDataUpdateWork.GoodsName))
                        // --- UPD 2011/02/16 ---<<<<<
                        {
                            wkInventoryDataUpdateWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF_NEW"));
                            //wkInventoryDataUpdateWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF")); // DEL 2011/02/16
                        }
                        // --- ADD 2011/02/12 ----------<<<<<
                        // --- ADD 2010/02/23 ---------->>>>>
                        //商品チェックフラグ
                        wkInventoryDataUpdateWork.GoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSDIVRF"));
                        // --- ADD 2010/02/23 ----------<<<<<
                        wkInventoryDataUpdateWork.AdjstCalcCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_ADJSTCALCCOSTRF")); // 2009/05/21 >>>

                        #endregion   // 抽出結果-値セット

                        int priceStartDateValue = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSPRICE_PRICESTARTDATERF"));  // ADD 2011/01/30  // DEL 2011/02/16
                        //価格情報の取得
                        string keyStr = wkInventoryDataUpdateWork.GoodsNo + "," + wkInventoryDataUpdateWork.GoodsMakerCd.ToString() + "," + priceStartDateValue.ToString();
                        if (!dicPrice.ContainsKey(keyStr))
                        {
                            GoodsPriceUWork goodsPrice = new GoodsPriceUWork();
                            goodsPrice.GoodsNo = wkInventoryDataUpdateWork.GoodsNo;
                            goodsPrice.GoodsMakerCd = wkInventoryDataUpdateWork.GoodsMakerCd;
                            goodsPrice.ListPrice = listPrice;
                            goodsPrice.PriceStartDate = priceStartDate;

                            dicPrice.Add(keyStr, goodsPrice);
                        }

                        string inventKey = wkInventoryDataUpdateWork.EnterpriseCode + "," + wkInventoryDataUpdateWork.SectionCode + ","
                                         + wkInventoryDataUpdateWork.InventorySeqNo.ToString() + "," + wkInventoryDataUpdateWork.WarehouseCode;
                        if (dicInvent.ContainsKey(inventKey))
                        {
                            continue;
                        }
                        else
                        {
                            dicInvent.Add(inventKey, wkInventoryDataUpdateWork);
                        }

                        // ----- DEL 2011/02/16 --------->>>>>
                        ////--- ADD 2011/02/12----->>>>>
                        //bool equalFlag = false;
                        //foreach (InventoryDataUpdateWork inventoryDataUpdateWork in al)
                        //{
                        //    if (inventoryDataUpdateWork.SectionCode == wkInventoryDataUpdateWork.SectionCode
                        //        && inventoryDataUpdateWork.WarehouseCode == wkInventoryDataUpdateWork.WarehouseCode
                        //        && inventoryDataUpdateWork.WarehouseCode == wkInventoryDataUpdateWork.WarehouseCode
                        //        && inventoryDataUpdateWork.GoodsMakerCd == wkInventoryDataUpdateWork.GoodsMakerCd
                        //        && inventoryDataUpdateWork.GoodsNo == wkInventoryDataUpdateWork.GoodsNo
                        //        && inventoryDataUpdateWork.SupplierCd == wkInventoryDataUpdateWork.SupplierCd
                        //        && inventoryDataUpdateWork.ShipCustomerCode == wkInventoryDataUpdateWork.ShipCustomerCode
                        //        && inventoryDataUpdateWork.StockUnitPriceFl == wkInventoryDataUpdateWork.StockUnitPriceFl
                        //        && inventoryDataUpdateWork.StockDiv == wkInventoryDataUpdateWork.StockDiv
                        //        && inventoryDataUpdateWork.WarehouseShelfNo == wkInventoryDataUpdateWork.WarehouseShelfNo)
                        //    {
                        //        equalFlag = true;
                        //        break;
                        //    }
                        //}
                        //if (equalFlag)
                        //{
                        //    continue;
                        //}
                        ////--- ADD 2011/02/12-----<<<<<
                        // ----- DEL 2011/02/16 ---------<<<<<

                        //al.Add(wkInventoryDataUpdateWork);// DEL2011/01/11 
                        // ----- ADD 2011/01/11 ---------------------------------------------------------------------->>>>>
                        // ①貸出データ抽出区分（0:印刷しない,1:印刷する） ②来勘計上分データ抽出区分（0:印刷しない,1:印刷する）
                        if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                        {
                            al.Add(wkInventoryDataUpdateWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2011/02/10
                        }
                        else if (_inventInputSearchCndtnWork.LendExtraDiv == 0 && _inventInputSearchCndtnWork.DelayPaymentDiv == 1)
                        {
                            // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｶｼﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventoryDataUpdateWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2011/02/10
                            }
                        }
                        else if (_inventInputSearchCndtnWork.LendExtraDiv == 1 && _inventInputSearchCndtnWork.DelayPaymentDiv == 0)
                        {
                            // 棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｻｷﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventoryDataUpdateWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2011/02/10
                            }
                        }
                        else
                        {
                            // 棚卸データ．棚番が"ｶｼﾀﾞｼ"のデータは抽出対象外とする。棚卸データ．棚番が"ｻｷﾀﾞｼ"のデータは抽出対象外とする。
                            if (!"ｶｼﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(wkInventoryDataUpdateWork.WarehouseShelfNo))
                            {
                                al.Add(wkInventoryDataUpdateWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2011/02/10
                            }
                        }
                        // ----- ADD 2011/01/11 ---------------------------------------------------------------------->>>>>
                        //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// DEL 2011/02/10
                    }
                }
                else
                {
                    while (myReader.Read())
                    {
                        #region 抽出結果-値セット
                        InventInputSearchResultWork wkInventInputSearchResultWork = new InventInputSearchResultWork();

                        //製番在庫マスタ格納項目
                        wkInventInputSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                        wkInventInputSearchResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTIONGUIDENMRF"));
                        wkInventInputSearchResultWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                        wkInventInputSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                        wkInventInputSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WH_WAREHOUSENAMERF"));
                        wkInventInputSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                        wkInventInputSearchResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAK_MAKERNAMERF"));
                        wkInventInputSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                        wkInventInputSearchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                        wkInventInputSearchResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                        wkInventInputSearchResultWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO1RF"));
                        wkInventInputSearchResultWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_DUPLICATIONSHELFNO2RF"));
                        wkInventInputSearchResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSLGROUPRF"));
                        wkInventInputSearchResultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRGDL_GOODSLGROUPNAMERF"));
                        wkInventInputSearchResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMGROUPRF"));
                        wkInventInputSearchResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GGR_GOODSMGROUPNAMERF"));
                        wkInventInputSearchResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGROUPCODERF"));
                        wkInventInputSearchResultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGR_BLGROUPNAMERF"));
                        wkInventInputSearchResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_ENTERPRISEGANRECODERF"));
                        wkInventInputSearchResultWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USRGDE_GUIDENAMERF"));
                        wkInventInputSearchResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_BLGOODSCODERF"));
                        wkInventInputSearchResultWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLCD_BLGOODSFULLNAMERF"));
                        wkInventInputSearchResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SUPPLIERCDRF"));
                        wkInventInputSearchResultWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_JANRF"));
                        wkInventInputSearchResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                        wkInventInputSearchResultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                        wkInventInputSearchResultWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                        wkInventInputSearchResultWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STOCKDIVRF"));
                        wkInventInputSearchResultWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTSTOCKDATERF"));
                        wkInventInputSearchResultWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALRF"));
                        wkInventInputSearchResultWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_SHIPCUSTOMERCODERF"));
                        wkInventInputSearchResultWork.ShipCustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTM_SHIPCUSTOMERNAMERF"));
                        wkInventInputSearchResultWork.ShipCustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTM_SHIPCUSTOMERNAME2RF"));
                        wkInventInputSearchResultWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                        wkInventInputSearchResultWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                        wkInventInputSearchResultWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRDAYRF"));
                        wkInventInputSearchResultWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYPREPRTIMRF"));
                        wkInventInputSearchResultWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                        wkInventInputSearchResultWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                        wkInventInputSearchResultWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYNEWDIVRF"));
                        wkInventInputSearchResultWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_STOCKMASHINEPRICERF"));
                        wkInventInputSearchResultWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKPRICERF"));
                        wkInventInputSearchResultWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_INVENTORYTLRNCPRICERF"));
                        wkInventInputSearchResultWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDATERF"));
                        wkInventInputSearchResultWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKTOTALEXECRF"));
                        wkInventInputSearchResultWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_TOLERANCEUPDATECDRF"));
                        #endregion    // 抽出結果-値セット
                        al.Add(wkInventInputSearchResultWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }


                foreach (GoodsPriceUWork goodsPriceUWork in dicPrice.Values)
                {
                    string keyStr = goodsPriceUWork.GoodsNo + "," + goodsPriceUWork.GoodsMakerCd.ToString();
                    if (dicPriceRet.ContainsKey(keyStr))
                    {
                        GoodsPriceUWork goodsPrice = new GoodsPriceUWork();

                        goodsPrice.ListPrice = goodsPriceUWork.ListPrice;
                        goodsPrice.PriceStartDate = goodsPriceUWork.PriceStartDate;

                        dicPriceRet[keyStr].Add(goodsPrice);
                    }
                    else
                    {
                        List<GoodsPriceUWork> goodsPriceList = new List<GoodsPriceUWork>();

                        GoodsPriceUWork goodsPrice = new GoodsPriceUWork();

                        goodsPrice.ListPrice = goodsPriceUWork.ListPrice;
                        goodsPrice.PriceStartDate = goodsPriceUWork.PriceStartDate;

                        goodsPriceList.Add(goodsPrice);
                        dicPriceRet.Add(keyStr, goodsPriceList);
                    }
                }

                dicPriceObj = dicPriceRet;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventInputSearchDB.SearchNonGrossAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion
        // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<
    }
}
