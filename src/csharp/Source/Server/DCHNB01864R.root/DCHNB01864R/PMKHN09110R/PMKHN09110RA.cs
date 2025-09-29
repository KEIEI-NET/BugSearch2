//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   IOWriteGoodsUserリモートオブジェクト
//                  :   PMKHN09110R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112 久保田
// Date             :   2008/06/06
//----------------------------------------------------------------------
// Update Note      :   2010/11/05  22018  鈴木 正臣
//                  :     ・商品管理情報マスタの重複エラーを発生させないよう修正。
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    public class IOWriteGoodsUser : RemoteWithAppLockDB
    {
        private GoodsMngDB _GoodsMngDB = null;

        private GoodsMngDB GoodsMngDb
        {
            get
            {
                if (this._GoodsMngDB == null)
                {
                    this._GoodsMngDB = new GoodsMngDB();
                }

                return this._GoodsMngDB;
            }
        }

        # region [Write]

        /// <summary>
        /// 売上・仕入明細を元に、商品マスタ(ユーザー)に未登録の商品データを作成します。
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="addListPos">商品情報リストインデックス</param>
        /// <param name="sqlConnection">データベース接続情報オブジェクト</param>        
        /// <param name="sqlTransaction">トランザクション情報オブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報オブジェクト</param>
        /// <returns>STATUS</returns>
        public int Write(ref CustomSerializeArrayList paraList, out int addListPos, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            ArrayList list = paraList as ArrayList;

            return Write(ref list, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// 売上・仕入明細を元に、商品マスタ(ユーザー)に未登録の商品データを作成します。
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="addListPos">商品情報リストインデックス</param>
        /// <param name="sqlConnection">データベース接続情報オブジェクト</param>        
        /// <param name="sqlTransaction">トランザクション情報オブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報オブジェクト</param>
        /// <returns>STATUS</returns>
        public int Write(ref ArrayList paraList, out int addListPos, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            addListPos = -1;

            try
            {
                ArrayList goodsUnitDtList = new ArrayList();

                // 売上明細データを分離
                ArrayList orgSlsDtlList = ListUtils.Find(paraList, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                // ArrayList.BinarySearch において、比較対象項目が同じアイテムがリスト内に複数存在した場合
                // 正しいインデックス値を返せない問題を回避する為にジェネリックにコピーして以降の処理を行う
                List<SalesDetailWork> slsDtlList = new List<SalesDetailWork>();

                if (orgSlsDtlList != null)
                {
                    slsDtlList.AddRange((SalesDetailWork[])orgSlsDtlList.ToArray(typeof(SalesDetailWork)));
                }

                // 仕入明細データ を分離
                ArrayList orgStkDtlList = ListUtils.Find(paraList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                // ArrayList.BinarySearch において、比較対象項目が同じアイテムがリスト内に複数存在した場合
                // 正しいインデックス値を返せない問題を回避する為にジェネリックにコピーして以降の処理を行う
                List<StockDetailWork> stkDtlList = new List<StockDetailWork>();

                if (orgStkDtlList != null)
                {
                    stkDtlList.AddRange((StockDetailWork[])orgStkDtlList.ToArray(typeof(StockDetailWork)));
                }

                // 伝票明細追加情報を分離
                SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();
                ArrayList slpDtlAdInfList = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                if (ListUtils.IsNotEmpty(slpDtlAdInfList))
                {
                    slpDtlAdInfList.Sort(DtlRelationGuidComp);

                    # region [売上明細データ → 商品マスタ(ユーザー)データ作成]

                    if (slsDtlList.Count > 0)
                    {
                        foreach (SalesDetailWork slsDtlWrk in slsDtlList)
                        {
                            // 売上明細に紐付く伝票明細追加情報を取得
                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(slsDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                            SlipDetailAddInfoWork slpDtlAdInfWrk = null;

                            if (slpDtlAdInfPos > -1)
                            {
                                slpDtlAdInfWrk = slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork;
                            }

                            // 伝票明細追加情報が存在し、且つ商品登録区分が 1:登録 の場合
                            if (slpDtlAdInfWrk != null && slpDtlAdInfWrk.GoodsEntryDiv == 1)
                            {
                                # region 商品連結データの作成
                                // 商品連結データを作成する
                                GoodsUnitDataWork GoodsUnitDtWrk = new GoodsUnitDataWork();
                                GoodsUnitDtWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;               // 企業コード
                                GoodsUnitDtWrk.LogicalDeleteCode = slsDtlWrk.LogicalDeleteCode;         // 論理削除区分
                                GoodsUnitDtWrk.GoodsMakerCd = slsDtlWrk.GoodsMakerCd;                   // 商品メーカーコード
                                GoodsUnitDtWrk.GoodsNo = slsDtlWrk.GoodsNo;                             // 商品番号
                                GoodsUnitDtWrk.GoodsName = slsDtlWrk.GoodsName;                         // 商品名称
                                GoodsUnitDtWrk.GoodsNameKana = slsDtlWrk.GoodsNameKana;                 // 商品名称カナ
                                //GoodsUnitDtWrk.Jan =                                                  // JANコード
                                GoodsUnitDtWrk.BLGoodsCode = slsDtlWrk.BLGoodsCode;                     // BL商品コード
                                GoodsUnitDtWrk.DisplayOrder = 0;                                        // 表示順位
                                GoodsUnitDtWrk.GoodsRateRank = slsDtlWrk.GoodsRateRank;                 // 商品掛率ランク
                                GoodsUnitDtWrk.TaxationDivCd = slsDtlWrk.TaxationDivCd;                 // 課税区分
                                GoodsUnitDtWrk.GoodsNoNoneHyphen = slsDtlWrk.GoodsNo.Replace("-", "");  // ハイフン無商品番号
                                GoodsUnitDtWrk.OfferDate = slpDtlAdInfWrk.GoodsOfferDate;               // 提供日付
                                GoodsUnitDtWrk.GoodsKindCode = slsDtlWrk.GoodsKindCode;                 // 商品属性
                                GoodsUnitDtWrk.GoodsNote1 = "";                                         // 商品備考１
                                GoodsUnitDtWrk.GoodsNote2 = "";                                         // 商品備考２
                                GoodsUnitDtWrk.GoodsSpecialNote = "";                                   // 商品規格・特記事項
                                GoodsUnitDtWrk.EnterpriseGanreCode = slsDtlWrk.EnterpriseGanreCode;     // 自社分類コード
                                GoodsUnitDtWrk.UpdateDate = DateTime.Now;                               // 更新年月日
                                GoodsUnitDtWrk.PriceList = null;                                        // 価格リスト
                                GoodsUnitDtWrk.StockList = null;                                        // 在庫リスト
                                # endregion

                                # region 商品価格データの作成
                                // 商品価格データを作成する
                                GoodsPriceUWork godsPrcUsrWrk = new GoodsPriceUWork();
                                godsPrcUsrWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;                // 企業コード
                                godsPrcUsrWrk.LogicalDeleteCode = slsDtlWrk.LogicalDeleteCode;          // 論理削除フラグ
                                godsPrcUsrWrk.GoodsMakerCd = slsDtlWrk.GoodsMakerCd;                    // 商品メーカーコード
                                godsPrcUsrWrk.GoodsNo = slsDtlWrk.GoodsNo;                              // 商品番号
                                godsPrcUsrWrk.PriceStartDate = slpDtlAdInfWrk.PriceStartDate;           // 価格開始日
                                godsPrcUsrWrk.ListPrice = slsDtlWrk.ListPriceTaxExcFl;                  // 定価(税抜)
                                godsPrcUsrWrk.SalesUnitCost = slsDtlWrk.SalesUnitCost;                  // 原価単価
                                godsPrcUsrWrk.StockRate = 0;                                            // 仕入率
                                godsPrcUsrWrk.OpenPriceDiv = slsDtlWrk.OpenPriceDiv;                    // オープン価格区分
                                godsPrcUsrWrk.OfferDate = slpDtlAdInfWrk.PriceOfferDate;                // 提供日付
                                godsPrcUsrWrk.UpdateDate = DateTime.Now;                                // 更新日付
                                # endregion

                                // 商品連結データと商品価格データの重複を省いてリストに追加
                                this.SetGoodsUnitData(ref goodsUnitDtList, GoodsUnitDtWrk, godsPrcUsrWrk);
                            }
                        }
                    }

                    # endregion

                    # region [仕入明細データ → 商品マスタ(ユーザー)データ作成]

                    if (stkDtlList.Count > 0)
                    {
                        foreach (StockDetailWork stkDtlWrk in stkDtlList)
                        {
                            // 仕入明細に紐付く伝票明細追加情報を取得
                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(stkDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                            SlipDetailAddInfoWork slpDtlAdInfWrk = null;

                            if (slpDtlAdInfPos > -1)
                            {
                                slpDtlAdInfWrk = slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork;
                            }

                            // 伝票明細追加情報が存在し、且つ商品登録区分が 1:登録 の場合
                            if (slpDtlAdInfWrk != null && slpDtlAdInfWrk.GoodsEntryDiv == 1)
                            {
                                // 商品価格マスタに対して登録を行うのは、商品マスタに対して新規登録
                                // された商品のみとする為、ここで強制的に価格更新区分を 0:非更新 にする。
                                slpDtlAdInfWrk.PriceUpdateDiv = 0;

                                # region 商品連結データの作成
                                // 商品連結データを作成する
                                GoodsUnitDataWork GoodsUnitDtWrk = new GoodsUnitDataWork();
                                GoodsUnitDtWrk.EnterpriseCode = stkDtlWrk.EnterpriseCode;               // 企業コード
                                GoodsUnitDtWrk.LogicalDeleteCode = stkDtlWrk.LogicalDeleteCode;         // 論理削除区分
                                GoodsUnitDtWrk.GoodsMakerCd = stkDtlWrk.GoodsMakerCd;                   // 商品メーカーコード
                                GoodsUnitDtWrk.GoodsNo = stkDtlWrk.GoodsNo;                             // 商品番号
                                GoodsUnitDtWrk.GoodsName = stkDtlWrk.GoodsName;                         // 商品名称
                                //GoodsUnitDtWrk.GoodsNameKana =                                        // 商品名称カナ
                                //GoodsUnitDtWrk.Jan =                                                  // JANコード
                                GoodsUnitDtWrk.BLGoodsCode = stkDtlWrk.BLGoodsCode;                     // BL商品コード
                                GoodsUnitDtWrk.DisplayOrder = 0;                                        // 表示順位
                                GoodsUnitDtWrk.GoodsRateRank = stkDtlWrk.GoodsRateRank;                 // 商品掛率ランク
                                GoodsUnitDtWrk.TaxationDivCd = stkDtlWrk.TaxationCode;                  // 課税区分
                                GoodsUnitDtWrk.GoodsNoNoneHyphen = stkDtlWrk.GoodsNo.Replace("-", "");  // ハイフン無商品番号
                                GoodsUnitDtWrk.OfferDate = slpDtlAdInfWrk.GoodsOfferDate;               // 提供日付
                                GoodsUnitDtWrk.GoodsKindCode = stkDtlWrk.GoodsKindCode;                 // 商品属性
                                GoodsUnitDtWrk.GoodsNote1 = "";                                         // 商品備考１
                                GoodsUnitDtWrk.GoodsNote2 = "";                                         // 商品備考２
                                GoodsUnitDtWrk.GoodsSpecialNote = "";                                   // 商品規格・特記事項
                                GoodsUnitDtWrk.EnterpriseGanreCode = stkDtlWrk.EnterpriseGanreCode;     // 自社分類コード
                                GoodsUnitDtWrk.UpdateDate = DateTime.Now;                               // 更新年月日
                                GoodsUnitDtWrk.PriceList = null;                                        // 価格リスト
                                GoodsUnitDtWrk.StockList = null;                                        // 在庫リスト
                                # endregion

                                # region 商品価格データの作成
                                // 商品価格データを作成する
                                GoodsPriceUWork godsPrcUsrWrk = new GoodsPriceUWork();
                                godsPrcUsrWrk.EnterpriseCode = stkDtlWrk.EnterpriseCode;                // 企業コード
                                godsPrcUsrWrk.LogicalDeleteCode = stkDtlWrk.LogicalDeleteCode;          // 論理削除フラグ
                                godsPrcUsrWrk.GoodsMakerCd = stkDtlWrk.GoodsMakerCd;                    // 商品メーカーコード
                                godsPrcUsrWrk.GoodsNo = stkDtlWrk.GoodsNo;                              // 商品番号
                                godsPrcUsrWrk.PriceStartDate = slpDtlAdInfWrk.PriceStartDate;           // 価格開始日
                                godsPrcUsrWrk.ListPrice = stkDtlWrk.ListPriceTaxExcFl;                  // 定価(税抜)

                                if (stkDtlWrk.StockRate == 0)
                                {
                                    godsPrcUsrWrk.SalesUnitCost = stkDtlWrk.StockUnitPriceFl;           // 原価単価
                                    godsPrcUsrWrk.StockRate = 0;                                        // 仕入率
                                }
                                else
                                {
                                    godsPrcUsrWrk.SalesUnitCost = 0;                                    // 原価単価
                                    godsPrcUsrWrk.StockRate = stkDtlWrk.StockRate;                      // 仕入率
                                }
                                
                                godsPrcUsrWrk.OpenPriceDiv = stkDtlWrk.OpenPriceDiv;                    // オープン価格区分
                                godsPrcUsrWrk.OfferDate = slpDtlAdInfWrk.PriceOfferDate;                // 提供日付
                                godsPrcUsrWrk.UpdateDate = DateTime.Now;                                // 更新日付
                                # endregion

                                // 商品連結データと商品価格データの重複を省いてリストに追加
                                this.SetGoodsUnitData(ref goodsUnitDtList, GoodsUnitDtWrk, godsPrcUsrWrk);
                            }
                        }
                    }

                    # endregion
                }

                if (ListUtils.IsNotEmpty(goodsUnitDtList))
                {
                    // 商品マスタ(ユーザー)に登録
                    UsrJoinPartsSearchDB usrJoinPartsSearchDB = new UsrJoinPartsSearchDB();

                    // パラメータが CustomSerializeArrayList を想定して作られているので変換して渡す
                    object paramList = new CustomSerializeArrayList();
                    (paramList as CustomSerializeArrayList).Add(goodsUnitDtList);
                    status = usrJoinPartsSearchDB.ReadNewWriteRelation(ref paramList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (ListUtils.IsNotEmpty((paramList as CustomSerializeArrayList)))
                        {
                            // 登録処理に成功した場合にのみ、パラメータリストに商品情報を追加する
                            goodsUnitDtList.Clear();
                            goodsUnitDtList.AddRange((paramList as CustomSerializeArrayList)[0] as ArrayList);

                            //addListPos = paraList.Add(goodsUnitDtList);  // 自動登録された商品連結情報を本当に返す必要がある場合はコメントを外す

                            SalesDetailWork slsDtlWrk = new SalesDetailWork();  // ワーク的意味合いで使用
                            StockDetailWork stkDtlWrk = new StockDetailWork();  // 　　　　　〃

                            StockSlipWork stkSlipWrk = null;                    // ワーク的な意味合いで使用

                            if (stkDtlList.Count > 0)
                            {
                                // 仕入明細データが登録されている場合は、紐付いている仕入伝票を取得する
                                stkSlipWrk = ListUtils.Find(paraList, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                            }

                            List<GoodsMngWork> GoodsMngGeneric = new List<GoodsMngWork>();           // 商品管理情報マスタ 登録用リスト

                            // 商品マスタ(ユーザー)に登録された商品情報を持つ明細追加情報の価格更新フラグをクリア(0)する
                            foreach (GoodsUnitDataWork goodsUnit in goodsUnitDtList)
                            {
                                # region [商品マスタ(ユーザー)データをキーに売上明細データを検索]
                                if (slsDtlList.Count > 0)
                                {
                                    int idx = 0;
                                    int pos = -1;

                                    do
                                    {
                                        // 検索用にダミーの売上明細データ(商品情報)をセット
                                        slsDtlWrk = new SalesDetailWork();
                                        slsDtlWrk.EnterpriseCode = goodsUnit.EnterpriseCode;
                                        slsDtlWrk.GoodsMakerCd = goodsUnit.GoodsMakerCd;
                                        slsDtlWrk.GoodsNo = goodsUnit.GoodsNo;

                                        // 同じ商品情報を持つ売上明細データを、検索範囲を指定して検索する
                                        pos = slsDtlList.FindIndex(idx, slsDtlList.Count - idx,
                                                                   delegate(SalesDetailWork item)
                                                                   {
                                                                       return (item.EnterpriseCode == slsDtlWrk.EnterpriseCode &&
                                                                               item.GoodsMakerCd == slsDtlWrk.GoodsMakerCd &&
                                                                               item.GoodsNo == slsDtlWrk.GoodsNo);
                                                                   });

                                        if (pos > -1)
                                        {
                                            // 売上明細データから関連する明細追加情報を取得し、価格更新区分を 0:非更新 にする
                                            slsDtlWrk = slsDtlList[pos] as SalesDetailWork;

                                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(slsDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                                            if (slpDtlAdInfPos > -1)
                                            {
                                                (slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork).PriceUpdateDiv = 0;
                                            }

                                            idx = pos + 1;

                                            // 売上明細データから商品管理情報データを作成する
                                            // 商品管理情報の取得優先順位を踏まえて、BLコードは設定しない。(拠点+商品メーカーコード+商品番号)
                                            GoodsMngWork GoodsMngWrk = new GoodsMngWork();
                                            GoodsMngWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;  // 企業コード
                                            GoodsMngWrk.SectionCode = slsDtlWrk.SectionCode;        // 拠点コード
                                            GoodsMngWrk.GoodsMakerCd = slsDtlWrk.GoodsMakerCd;      // 商品メーカーコード
                                            GoodsMngWrk.GoodsNo = slsDtlWrk.GoodsNo;                // 商品番号
                                            GoodsMngWrk.SupplierCd = slsDtlWrk.SupplierCd;          // 仕入先コード
                                            
                                            if (!GoodsMngGeneric.Exists(delegate (GoodsMngWork item)
                                                                    {
                                                                        return (item.EnterpriseCode == GoodsMngWrk.EnterpriseCode &&
                                                                                item.SectionCode == GoodsMngWrk.SectionCode &&
                                                                                item.GoodsMakerCd == GoodsMngWrk.GoodsMakerCd &&
                                                                                item.GoodsNo == GoodsMngWrk.GoodsNo);
                                                                    }))
                                            {
                                                // --- UPD m.suzuki 2010/11/05 ---------->>>>>
                                                //GoodsMngGeneric.Add(goodsMngWork);

                                                // 商品管理情報マスタに未登録である事を確認する。
                                                if ( !ExistsGoodsMng( ref GoodsMngWrk, ref sqlConnection, ref sqlTransaction ) )
                                                {
                                                    GoodsMngGeneric.Add( GoodsMngWrk );
                                                }
                                                // --- UPD m.suzuki 2010/11/05 ----------<<<<<
                                            }
                                        }

                                    } while (pos > -1);
                                }
                                # endregion

                                # region [商品マスタ(ユーザー)データをキーに仕入明細データを検索]
                                if (stkDtlList.Count > 0)
                                {
                                    int idx = 0;
                                    int pos = -1;

                                    do
                                    {
                                        // 検索用にダミーの仕入明細データ(商品情報)をセット
                                        stkDtlWrk = new StockDetailWork();
                                        stkDtlWrk.EnterpriseCode = goodsUnit.EnterpriseCode;
                                        stkDtlWrk.GoodsMakerCd = goodsUnit.GoodsMakerCd;
                                        stkDtlWrk.GoodsNo = goodsUnit.GoodsNo;

                                        // 同じ商品情報を持つ仕入明細データを、検索範囲を指定して検索する
                                        pos = stkDtlList.FindIndex(idx, stkDtlList.Count - idx,
                                                                   delegate(StockDetailWork item)
                                                                   {
                                                                       return (item.EnterpriseCode == stkDtlWrk.EnterpriseCode &&
                                                                               item.GoodsMakerCd == stkDtlWrk.GoodsMakerCd &&
                                                                               item.GoodsNo == stkDtlWrk.GoodsNo);
                                                                   });

                                        if (pos > -1)
                                        {
                                            // 仕入明細データから関連する明細追加情報を取得し、価格更新区分を 0:非更新 に設定する
                                            stkDtlWrk = stkDtlList[pos] as StockDetailWork;

                                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(stkDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                                            if (slpDtlAdInfPos > -1)
                                            {
                                                (slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork).PriceUpdateDiv = 0;
                                            }

                                            idx = pos + 1;

                                            // 仕入明細データから商品管理情報データを作成する
                                            // 商品管理情報の取得優先順位を踏まえて、BLコードは設定しない。(拠点+商品メーカーコード+商品番号)
                                            GoodsMngWork GoodsMngWrk = new GoodsMngWork();
                                            GoodsMngWrk.EnterpriseCode = stkDtlWrk.EnterpriseCode;  // 企業コード
                                            GoodsMngWrk.SectionCode = stkDtlWrk.SectionCode;        // 拠点コード
                                            GoodsMngWrk.GoodsMakerCd = stkDtlWrk.GoodsMakerCd;      // 商品メーカーコード
                                            GoodsMngWrk.GoodsNo = stkDtlWrk.GoodsNo;                // 商品番号
                                            
                                            if (stkSlipWrk != null)
                                            {
                                                GoodsMngWrk.SupplierCd = stkSlipWrk.SupplierCd;     // 仕入先コード
                                            }

                                            if (!GoodsMngGeneric.Exists(delegate(GoodsMngWork item)
                                                                    {
                                                                        return (item.EnterpriseCode == GoodsMngWrk.EnterpriseCode &&
                                                                                item.SectionCode == GoodsMngWrk.SectionCode &&
                                                                                item.GoodsMakerCd == GoodsMngWrk.GoodsMakerCd &&
                                                                                item.GoodsNo == GoodsMngWrk.GoodsNo);
                                                                    }))
                                            {
                                                // --- UPD m.suzuki 2010/11/05 ---------->>>>>
                                                //GoodsMngGeneric.Add(goodsMngWork);

                                                // 商品管理情報マスタに未登録である事を確認する。
                                                if ( !ExistsGoodsMng( ref GoodsMngWrk, ref sqlConnection, ref sqlTransaction ) )
                                                {
                                                    GoodsMngGeneric.Add( GoodsMngWrk );
                                                }
                                                // --- UPD m.suzuki 2010/11/05 ----------<<<<<
                                            }
                                        }

                                    } while (pos > -1);
                                }
                                # endregion
                            }

                            // --- UPD m.suzuki 2010/11/05 ---------->>>>>
                            //// 商品管理情報マスタに登録
                            //ArrayList goodsMngList = new ArrayList(GoodsMngGeneric);
                            //status = this.GoodsMngDb.WriteGoodsMngProc(ref goodsMngList, ref sqlConnection, ref sqlTransaction);
                            
                            if ( GoodsMngGeneric != null && GoodsMngGeneric.Count > 0 )
                            {
                                // 商品管理情報マスタに登録
                                ArrayList goodsMngList = new ArrayList( GoodsMngGeneric );
                                status = this.GoodsMngDb.WriteGoodsMngProc( ref goodsMngList, ref sqlConnection, ref sqlTransaction );
                            }
                            // --- UPD m.suzuki 2010/11/05 ----------<<<<<
                        }
                    }
                }
                else
                {
                    // 商品マスタに登録すべきデータが存在しない場合は ctDB_NORMAL とする。
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;            
        }

        // --- ADD m.suzuki 2010/11/05 ---------->>>>>
        /// <summary>
        /// 商品管理情報マスタ存在チェック
        /// </summary>
        /// <param name="goodsMngWork">GoodsMngWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns></returns>
        private bool ExistsGoodsMng( ref GoodsMngWork goodsMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            bool result = false;
            try
            {
                int goodsMngStatus = this.GoodsMngDb.ReadProc( ref goodsMngWork, 0, ref sqlConnection, ref sqlTransaction );
                if ( goodsMngStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 存在しない
                    return false;
                }

                if ( goodsMngWork.LogicalDeleteCode != 0 )
                {
                    // 論理削除済み⇒復旧する
                    goodsMngWork.LogicalDeleteCode = 0;
                    return false;
                }

                return true;
            }
            catch ( Exception ex )
            {
            }
            finally
            {
            }

            return result;
        }
        // --- ADD m.suzuki 2010/11/05 ----------<<<<<

        private void SetGoodsUnitData(ref ArrayList goodsUnitDtList, GoodsUnitDataWork GoodsUnitDtWrk, GoodsPriceUWork godsPrcUsrWrk)
        {
            // 商品連結データリストに格納する前に重複する商品連結データの存在をチェックする
            GoodsUnitDataComparer GoodsUnitDtComp = new GoodsUnitDataComparer();
            
            goodsUnitDtList.Sort(GoodsUnitDtComp);

            int goodsUnitIdx = goodsUnitDtList.BinarySearch(GoodsUnitDtWrk, GoodsUnitDtComp);

            if (goodsUnitIdx < 0)
            {
                // 重複する商品連結データが存在しない場合は、作成した商品価格データを
                // 価格リストに格納して商品連結データリストに追加する
                GoodsUnitDtWrk.PriceList = new ArrayList();
                GoodsUnitDtWrk.PriceList.Add(godsPrcUsrWrk);
                goodsUnitDtList.Add(GoodsUnitDtWrk);
            }
            else
            {
                // 重複する商品連結データが存在している場合は商品連結データの追加は行わない。
                // 但し価格リスト内に重複する商品価格データが無いかどうかをチェックし、
                // 重複する商品価格データが存在しない場合は商品価格データのみを追加する
                GoodsUnitDataWork GoodsUnitDtTmp = goodsUnitDtList[goodsUnitIdx] as GoodsUnitDataWork;

                GoodsPriceUComparer GoodsPriceUComp = new GoodsPriceUComparer();
                GoodsUnitDtTmp.PriceList.Sort(GoodsPriceUComp);

                int goodsPriceIdx = GoodsUnitDtTmp.PriceList.BinarySearch(godsPrcUsrWrk, GoodsPriceUComp);

                if (goodsPriceIdx < 0)
                {
                    GoodsUnitDtWrk.PriceList.Add(godsPrcUsrWrk);
                }
            }

        }

        # endregion

        # region [各種比較用クラス]

        /// <summary>
        /// 商品連結データ(主に商品データ)比較クラス
        /// </summary>
        private class GoodsUnitDataComparer : IComparer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                GoodsUnitDataWork xGoods = x as GoodsUnitDataWork;
                GoodsUnitDataWork yGoods = y as GoodsUnitDataWork;

                int ret = (xGoods == null ? 0 : 1) - (yGoods == null ? 0 : 1);

                if (ret == 0 && xGoods != null)
                {
                    // 企業コードで比較
                    ret = xGoods.EnterpriseCode.CompareTo(yGoods.EnterpriseCode);

                    // 商品メーカーコードで比較
                    if (ret == 0)
                    {
                        ret = xGoods.GoodsMakerCd - yGoods.GoodsMakerCd;
                    }

                    // 商品番号で比較
                    if (ret == 0)
                    {
                        ret = xGoods.GoodsNo.CompareTo(yGoods.GoodsNo);
                    }
                }

                return ret;
            }
        }

        /// <summary>
        /// 商品価格データ比較クラス
        /// </summary>
        private class GoodsPriceUComparer : IComparer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                GoodsPriceUWork xPrice = x as GoodsPriceUWork;
                GoodsPriceUWork yPrice = y as GoodsPriceUWork;

                int ret = (xPrice == null ? 0 : 1) - (yPrice == null ? 0 : 1);

                if (ret == 0 && xPrice != null)
                {
                    // 企業コードで比較
                    ret = xPrice.EnterpriseCode.CompareTo(yPrice.EnterpriseCode);

                    // 商品メーカーコードで比較
                    if (ret == 0)
                    {
                        ret = xPrice.GoodsMakerCd - yPrice.GoodsMakerCd;
                    }

                    // 商品番号で比較
                    if (ret == 0)
                    {
                        ret = xPrice.GoodsNo.CompareTo(yPrice.GoodsNo);
                    }

                    // 価格更新日
                    if (ret == 0)
                    {
                        ret = xPrice.PriceStartDate.CompareTo(yPrice.PriceStartDate);
                    }
                }

                return ret;
            }
        }

        # endregion
    }
}
