//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/03/11  修正内容 : 品番検索時、メーカーコードが指定されていれば
//                                  結合選択ウインドウを表示しないように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/30  修正内容 : 手動回答の表示区分プロセス対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/31  修正内容 : 回答区分について、同一データの過去の回答も参照して判断するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018  鈴木 正臣
// 作 成 日  2010/06/28  修正内容 : 成果物統合 品名表示に対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健
// 作 成 日  2011/01/11  修正内容 : 提供データ・商品に未登録の部品も売上伝票入力に展開されるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健
// 作 成 日  2011/03/08  修正内容 : 型式選択ＵＩで年式・車台番号絞込みできるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/03/08  修正内容 : 車輌検索の修正（車台番号での絞込みを追加、年式、カラー、トリムの絞り込みを修正）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : BLコード枝番追加等の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744　湯上 千加子
// 作 成 日  2012/06/06  修正内容 : 障害№178 車両検索で型式選択画面表示時、車台番号での抽出する件についての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/11/01  修正内容 : 11/14配信 システムテスト障害№22対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/12  修正内容 : SCM改良№10423対応 PCCforNS、BLPの委託在庫・参照在庫の判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/02/01  修正内容 : 2013/03/06配信予定 SCM障害№92　車両情報の装備情報を考慮した部品絞込みを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/02/20  修正内容 : 2013/03/06配信予定 SCM障害№92対応時の不具合（手動回答時のみ）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2013/05/08  修正内容 : 2013/06/08配信分 システムテスト障害№10328対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/11/12  修正内容 : VSS[019] システムテスト障害№10対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/12/25  修正内容 : SCM仕掛一覧№10605対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/02/06  修正内容 : SCM仕掛一覧№10632対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/05/30  修正内容 : 商品保証課Redmine#1581対応
//----------------------------------------------------------------------------//
// 管理番号 11070148-00  作成担当 : 杜志剛
// 作 成 日  2014/07/28  修正内容 : BLPの部品検索障害(№10370)
//----------------------------------------------------------------------------//
// 管理番号 11070148-00  作成担当 : 杜志剛
// 作 成 日  2014/08/08  修正内容 : 検証／総合テスト障害対応No.3
//----------------------------------------------------------------------------//
// 管理番号 11070184-00  作成担当 : 譚洪
// 作 成 日  2014/09/01  修正内容 : SFから問合せの車輌情報・備考を売上伝票入力に表示する
//----------------------------------------------------------------------------//
// 管理番号  11070184-00 作成担当 : 30973 鹿庭 一郎
// 修 正 日  2014/09/22  修正内容 : 11070184-00 SCM仕掛一覧No.10598 文字列車台番号での発注・問合せ対応
//----------------------------------------------------------------------------//
// 管理番号  11170206-00 作成担当 : 顧棟
// 作 成 日  2016/01/13  修正内容 : Redmine#47845 2016年2月配信分
//                                : フタバ倉庫引当てオプションオン：既存のままで行う対応
//                                : フタバ倉庫引当てオプションオフ：SCM手動回答時、部品に充てる在庫について、優先的に充てる倉庫が
//                                :                                 BLﾊﾟｰﾂｵｰﾀﾞｰ自社設定の委託倉庫と参照倉庫になってしまうの障害対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 田建委
// 修 正 日  2020/05/15  修正内容 : PMKOBETSU-3932 BLP障害（ログ強化）
//                                : 既存コードのログ出力強化を行う
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;   // 2011/03/08 Add

using System.Threading;  // ADD 譚洪 2014/09/01 FOR Redmine#43289
using System.Data;       // ADD 譚洪 2014/09/01 FOR Redmine#43289

namespace Broadleaf.Application.Controller.Manual
{
    using SCMOrderHeaderRecordType = ISCMOrderHeaderRecord;    // SCM受注データ
    using SCMOrderCarRecordType = ISCMOrderCarRecord;       // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType = ISCMOrderAnswerRecord;    // SCM受注明細データ(回答)

    // 2010/03/30 Add >>>
    using CustRateGroupServer = SingletonInstance<CustRateGroupAgent>;          // 得意先掛率グループマスタ  
    using PriceSelectSetAgentServer = SingletonInstance<PriceSelectSetAgent>;   // 表示区分マスタ
    // 2010/03/30 Add <<<

    /// <summary>
    /// SCM手動用検索処理クラス
    /// </summary>
    public sealed class SCMManualSearcher : SCMSearcher
    {
        private const string MY_NAME = "SCMManualSearcher"; // ログ用
        private const string LinkBreak = "\r\n";  //改行

        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
        //Thread中、車両情報SOLT名
        private const string CARINFOSOLT = "CARINFOSOLT";
        private LocalDataStoreSlot carInfoSolt = null;
        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

        #region <手動回答処理のコンフィグ>

        /// <summary>手動回答処理のコンフィグ</summary>
        private SCMManualConfig _manualConfig;
        /// <summary>手動回答処理のコンフィグ</summary>
        private SCMManualConfig ManualConfig { get { return _manualConfig; } }

        /// <summary>
        /// 所有者フォームを取得または設定します。
        /// </summary>
        private IWin32Window OwnerForm
        {
            get { return ManualConfig.OwnerForm; }
        }

        /// <summary>
        /// 手動検索条件を取得します。
        /// </summary>
        private GoodsCndtn SeachingConditionManually
        {
            get { return ManualConfig.SeachingConditionManually; }
        }

        #endregion // </手動回答処理のコンフィグ>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="headerRecordList">SCM受注データのレコードリスト</param>
        /// <param name="carRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="detailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <param name="orgAnswerRecordList"></param>
        /// <param name="orgDetailRecordList"></param>
        /// <param name="manualConfig">手動回答処理のコンフィグ</param>
        // 2010/03/31 >>>
        //public SCMManualSearcher(
        //    IList<SCMOrderHeaderRecordType> headerRecordList,
        //    IList<SCMOrderCarRecordType> carRecordList,
        //    IList<SCMOrderDetailRecordType> detailRecordList,
        //    SCMManualConfig manualConfig
        //) : base(headerRecordList, carRecordList, detailRecordList)
        public SCMManualSearcher(
            IList<SCMOrderHeaderRecordType> headerRecordList,
            IList<SCMOrderCarRecordType> carRecordList,
            IList<SCMOrderDetailRecordType> detailRecordList,
            IList<SCMOrderAnswerRecordType> orgAnswerRecordList,
            IList<SCMOrderDetailRecordType> orgDetailRecordList,
            SCMManualConfig manualConfig
            )
            : base(headerRecordList, carRecordList, detailRecordList, orgAnswerRecordList, orgDetailRecordList)
        // 2010/03/31 <<<
        {
            const string METHOD_NAME = "Constructor()";

            _manualConfig = manualConfig;

            #region <Log>

            // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
            #region 削除コード

            //string msg = LogHelper.GetDataMsg(
            //    "インプットSCM受注データ",
            //    HeaderRecordList,
            //    CarRecordList,
            //    DetailRecordList
            //);

            #endregion // 削除コード
            // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
            string msg = LogHelper.GetDataMsg(
                "インプットSCM受注データ",
                HeaderRecordList,
                CarRecordList,
                DetailRecordList,
                OrgAnswerRecordList,
                OrgDetailRecordList
            );
            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, msg);

            #endregion // </Log>
        }

        #endregion // </Constructor>

        // --- ADD 2016/01/13 顧棟 Redmine#47845 フタバ倉庫引当てオプション  （個別）：OPT-CPM0100を追加する ----->>>>>
        /// <summary>
        ///  フタバ倉庫引当てオプションチェック
        /// </summary>
        /// <returns></returns>
        private static bool CheckFutabaWarehAllocOption()
        {
            USBOptionAgent usbOptin = new USBOptionAgent();
            return usbOptin.EnabledFutabaWarehAllocOption();
        }
        // --- ADD 2016/01/13 顧棟 Redmine#47845 フタバ倉庫引当てオプション  （個別）：OPT-CPM0100を追加する -----<<<<<

        #region <Override>

        #region <検索を行えるかの判定>

        /// <summary>
        /// 検索を行えるか判断します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="answerList">SCM受注明細データ(回答)のリスト</param>
        /// <returns>
        /// <c>true</c> :検索を行えます。<br/>
        /// <c>false</c>:検索を行えません。
        /// </returns>
        /// <see cref="SCMSearcher"/>
        // 2011/02/14 >>>
        //protected override bool CanSearch(ISCMOrderDetailRecord scmOrderDetailRecord)
        protected override bool CanSearch(ISCMOrderDetailRecord scmOrderDetailRecord, List<ISCMOrderAnswerRecord> answerList)
        // 2011/02/14 <<<
        {
            return true;
        }

        #endregion // </検索を行えるかの判定>

        /// <summary>
        /// 品番検索条件を編集します。
        /// </summary>
        /// <param name="searchingCondition">品番検索条件</param>
        /// <returns>編集した品番検索条件</returns>
        protected override GoodsCndtn EditSearchingGoodsCondition(GoodsCndtn searchingCondition)
        {
            // 検索画面制御区分…0:PM7, 1:PM.NS エントリからの部品検索時のみ有効
            searchingCondition.SearchUICntDivCd = 1;    // 自動は1 手動は引数あり 
            searchingCondition.SearchUICntDivCd = 0;

            // エンターキー処理区分…0:PM7(セットのみ), 1:選択, 2:次画面 エントリからの部品検索時のみ有効
            searchingCondition.EnterProcDivCd = 0;      // 自動は0 手動は引数あり

            // 手動回答処理のコンフィグ値を設定
            if (SeachingConditionManually != null)
            {
                // 検索画面制御区分
                searchingCondition.SearchUICntDivCd = SeachingConditionManually.SearchUICntDivCd;

                // エンターキー処理区分
                searchingCondition.EnterProcDivCd = SeachingConditionManually.EnterProcDivCd;
            }

            // 品番検索区分…0:PM7(セットのみ), 1:結合・セット・代替あり エントリからの部品検索時のみ有効
            searchingCondition.PartsNoSearchDivCd = 1;  // 手動でも1

            // ↑品番検索区分が0のとき有効
            // 品番結合制御区分…初期値"." エントリからの部品検索時のみ有効
            //condition.PartsJoinCntDivCd = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;

            return searchingCondition;
        }

        #region <品番検索>

        /// <summary>
        /// 品番検索アクセサを用いて品番検索を行います。
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.SearchPartsFromGoodsNo() 1445行目より移植</remarks>
        /// <param name="searchingCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromGoodsNo(
            GoodsCndtn searchingCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        )
        {
            const string METHOD_NAME = "SearchPartsFromGoodsNo()";  // ログ用

            Debug.WriteLine("\t手動回答処理：GoodsAccesser.SearchPartsFromGoodsNo()");

            // 品番検索(結合検索有り)
            // 2010/03/11 >>>
            //int status = GoodsAccesser.SearchPartsFromGoodsNo(
            //    searchingCondition,
            //    out partsInfoDB,
            //    out goodsUnitDataList,
            //    out msg
            //);

            int status = (int)ResultUtil.ResultCode.Normal;
            EasyLogger.Write(MY_NAME, METHOD_NAME, "品番検索 開始" + "パラメータ:" + GetGoodsSearchCondition(searchingCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            if (searchingCondition.GoodsMakerCd == 0)
            {
                status = GoodsAccesser.SearchPartsFromGoodsNo(
                    searchingCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out msg);
            }
            else
            {
                searchingCondition.PartsNoSearchDivCd = 0;
                searchingCondition.JoinSearchDiv = 0;
                searchingCondition.PartsJoinCntDivCd = ".";
                status = GoodsAccesser.SearchPartsFromGoodsNo(
                    searchingCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out msg);
            }
            EasyLogger.Write(MY_NAME, METHOD_NAME, "品番検索 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            // 2010/03/11 <<<

            if (!status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                #region <Log>

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetErrorMsg(msg, status));

                string message = "品番検索(結合検索有り)…品番=" + searchingCondition.GoodsNo;
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(message));

                #endregion // </Log>

                // 検索されなかった場合、手動回答では
                // SCM受注明細データ(問合せ・発注)より売上データを作成するので、
                // 1件だけ検索されたことにする
                if (ListUtil.IsNullOrEmpty<GoodsUnitData>(goodsUnitDataList))
                {
                    goodsUnitDataList = new List<GoodsUnitData>();
                    {
                        goodsUnitDataList.Add(new NullGoodsUnitData());
                    }
                    status = (int)ResultUtil.ResultCode.Normal;
                }
                return status;
            }
            if (partsInfoDB != null)
            {
                // --- ADD 2016/01/13 顧棟 Redmine#47845 手動回答優先倉庫表示不正の障害対応 ----->>>>>
                // フタバ倉庫引当てオプションオンのみの場合、既存と同じ仕様で行う
                if (CheckFutabaWarehAllocOption())
                {
                // --- ADD 2016/01/13 顧棟 Redmine#47845 手動回答優先倉庫表示不正の障害対応 -----<<<<<
                    // 検索結果が複数ある場合
                    // UPD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
                    //// 優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を設定
                    //partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseList(CurrentHeaderRecord);
                    // 優先倉庫リスト(PCCUOE)を設定
                    partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
                    // UPD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<
                // --- ADD 2016/01/13 顧棟 Redmine#47845 手動回答優先倉庫表示不正の障害対応 ----->>>>>
                }
                else
                {
                    //手動回答の場合、回答部品情報の優先倉庫は得意先マスタの優先倉庫と拠点設定の倉庫１～３を設定する。
                    partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseList(CurrentHeaderRecord);
                }
                // --- ADD 2016/01/13 顧棟 Redmine#47845 手動回答優先倉庫表示不正の障害対応 -----<<<<<

                // 品名表示区分
                SalesTtlSt foundSsalesTtlSt = SalesTtlStDB.Find(
                    searchingCondition.EnterpriseCode,
                    searchingCondition.SectionCode
                );
                if (foundSsalesTtlSt != null)
                {
                    // --- UPD m.suzuki 2010/06/28 ---------->>>>>
                    //partsInfoDB.PartsNameDspDivCd = foundSsalesTtlSt.PartsNameDspDivCd;
                    partsInfoDB.SetPartsNameDisplayPattern(foundSsalesTtlSt);
                    // --- UPD m.suzuki 2010/06/28 ----------<<<<<
                }
            }
            // PartsInfoDataSetに価格計算のデリゲートを追加
            EasyLogger.Write(MY_NAME, METHOD_NAME, "価格計算のデリゲートを追加 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            SetCalculator(partsInfoDB);
            EasyLogger.Write(MY_NAME, METHOD_NAME, "価格計算のデリゲートを追加 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）

            // 部品選択UIを表示(処理モードを自動回答モードとして起動)
            EasyLogger.Write(MY_NAME, METHOD_NAME, "部品選択UIを表示 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            TakePartsInfoByManualOperation(partsInfoDB, null);
            EasyLogger.Write(MY_NAME, METHOD_NAME, "部品選択UIを表示 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索アクセサを用いて品番検索を行います。
        /// </summary>
        /// <remarks></remarks>
        /// <param name="searchingConditionList">検索条件</param>
        /// <param name="partsInfoDBList">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromGoodsNo(
            List<GoodsCndtn> searchingConditionList,
            out List<PartsInfoDataSet> partsInfoDBList,
            out List<List<GoodsUnitData>> goodsUnitDataList,
            out string msg
        )
        {
            const string METHOD_NAME = "SearchPartsFromGoodsNo()";  // ログ用

            Debug.WriteLine("\t手動回答処理：GoodsAccesser.SearchPartsFromGoodsNo()");

            int status = (int)ResultUtil.ResultCode.Normal;
            if (searchingConditionList[0].GoodsMakerCd == 0)
            {
                status = GoodsAccesser.SearchPartsFromGoodsNo(
                    searchingConditionList,
                    out partsInfoDBList,
                    out goodsUnitDataList,
                    out msg);
            }
            else
            {
                searchingConditionList[0].PartsNoSearchDivCd = 0;
                searchingConditionList[0].JoinSearchDiv = 0;
                searchingConditionList[0].PartsJoinCntDivCd = ".";
                status = GoodsAccesser.SearchPartsFromGoodsNo(
                    searchingConditionList,
                    out partsInfoDBList,
                    out goodsUnitDataList,
                    out msg);
            }
            if (!status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                #region <Log>

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetErrorMsg(msg, status));

                string message = "品番検索(結合検索有り)…品番=" + searchingConditionList[0].GoodsNo;
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(message));

                #endregion // </Log>

                // 検索されなかった場合、手動回答では
                // SCM受注明細データ(問合せ・発注)より売上データを作成するので、
                // 1件だけ検索されたことにする
                if (ListUtil.IsNullOrEmpty<GoodsUnitData>(goodsUnitDataList[0]))
                {
                    goodsUnitDataList = new List<List<GoodsUnitData>>();
                    {
                        List<GoodsUnitData> goodsUnitDataListTemp = new List<GoodsUnitData>();
                        goodsUnitDataListTemp.Add(new NullGoodsUnitData());
                        goodsUnitDataList.Add(goodsUnitDataListTemp);
                    }
                    status = (int)ResultUtil.ResultCode.Normal;
                }
                return status;
            }
            if (partsInfoDBList != null && partsInfoDBList.Count != 0)
            {
                List<string> priorWarehouseList = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
                // 品名表示区分
                SalesTtlSt foundSsalesTtlSt = SalesTtlStDB.Find(
                    searchingConditionList[0].EnterpriseCode,
                    searchingConditionList[0].SectionCode
                );

                foreach (PartsInfoDataSet partsInfoDB in partsInfoDBList)
                {
                    // 検索結果が複数ある場合
                    // 優先倉庫リスト(PCCUOE)を設定
                    partsInfoDB.ListPriorWarehouse = priorWarehouseList;
                    if (foundSsalesTtlSt != null)
                    {
                        partsInfoDB.SetPartsNameDisplayPattern(foundSsalesTtlSt);
                    }
                    // PartsInfoDataSetに価格計算のデリゲートを追加
                    SetCalculator(partsInfoDB);
                    // 部品選択UIを表示(処理モードを自動回答モードとして起動)
                    TakePartsInfoByManualOperation(partsInfoDB, null);

                }
            }

            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        #endregion // </品番検索>

        #region <車両検索>

        /// <summary>
        /// 車両を検索します。
        /// </summary>
        /// <remarks>
        /// MAHNB01010UA.cs::MAHNB01010UA.CarSearch()を参考
        /// </remarks>
        /// <param name="searchingCarCondition">検索条件</param>
        /// <param name="carRecord">SCM受注データ(車両情報)のレコード</param>
        /// <param name="searchedCarInfo">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <see cref="SCMSearcher"/>
        protected override CarSearchResultReport SearchCar(
            CarSearchCondition searchingCarCondition,
            // 2011/03/08 >>>
            ISCMOrderCarRecord carRecord,
            // 2011/03/08 <<<
            ref PMKEN01010E searchedCarInfo
        )
        {
            // 検索結果が複数あった場合、選択ウィンドウを表示
            // 2011/03/08 >>>
            //CarSearchResultReport resultReport = base.SearchCar(searchingCarCondition, ref searchedCarInfo);
            CarSearchResultReport resultReport = base.SearchCar(searchingCarCondition, carRecord, ref searchedCarInfo);
            // 2011/03/08 <<<

            // 車種選択画面を起動
            if (resultReport.Equals(CarSearchResultReport.retMultipleCarKind))
            {
                // UPD 2013/12/25 SCM仕掛一覧№10605対応 ------------------------------------------>>>>>
                //// UPD 2013/11/12 吉岡 VSS[019] システムテスト障害№10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //// if (SelectionCarKind.ShowDialog(searchedCarInfo.CarKindInfo, searchingCarCondition).Equals(DialogResult.OK))
                //if (SelectionCarKind.ShowDialog(OwnerForm,searchedCarInfo.CarKindInfo, searchingCarCondition).Equals(DialogResult.OK))
                //// UPD 2013/11/12 吉岡 VSS[019] システムテスト障害№10  ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                //{
                //    resultReport = CarAccesser.Search(searchingCarCondition, ref searchedCarInfo);
                //}
                //else
                //{
                //    return resultReport;
                //}

                if (searchedCarInfo.CarKindInfo != null &&
                    searchedCarInfo.CarKindInfo.Count > 0)
                {
                    if (searchingCarCondition.ModelCode != 0 || searchingCarCondition.ModelSubCode != -1)
                    {
                        for (int iCnt = 0; iCnt < searchedCarInfo.CarKindInfo.Count; iCnt++)
                        {
                            if (searchedCarInfo.CarKindInfo[iCnt].ModelCode == searchingCarCondition.ModelCode &&
                                searchedCarInfo.CarKindInfo[iCnt].ModelSubCode == searchingCarCondition.ModelSubCode)
                            {
                                searchedCarInfo.CarKindInfo[iCnt].SelectionState = true;
                                break;
                            }
                        }
                        resultReport = base.SearchCar(searchingCarCondition, carRecord, ref searchedCarInfo);
                    }
                }
                if (resultReport.Equals(CarSearchResultReport.retMultipleCarKind))
                {
                    if (SelectionCarKind.ShowDialog(OwnerForm, searchedCarInfo.CarKindInfo, searchingCarCondition).Equals(DialogResult.OK))
                    {
                        resultReport = CarAccesser.Search(searchingCarCondition, ref searchedCarInfo);
                    }
                    else
                    {
                        return resultReport;
                    }
                }
                // UPD 2013/12/25 SCM仕掛一覧№10605対応 ------------------------------------------<<<<<
            }
            // 2011/03/08 Add >>>
            // UPD 2012/06/06 -------------------------->>>>>
            //int searchFrameNo = TStrConv.StrToIntDef(carRecord.ChassisNo, 0);
            // --- UPD 2012/11/01 三戸 2012/11/14配信分 システムテスト障害№22 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //int searchFrameNo = TStrConv.StrToIntDef(carRecord.FrameNo, 0);
            int searchFrameNo = this.GetsearchFrameNo(carRecord.FrameNo);
            // --- UPD 2012/11/01 三戸 2012/11/14配信分 システムテスト障害№22 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // UPD 2012/06/06 --------------------------<<<<<
            //int produceTypeOfYearNum = carRecord.ProduceTypeOfYearNum;// Del 2014/07/28 duzg For BLPの部品検索障害(№10370)
            // 2011/03/08 Add <<<

            // Add 2014/07/28 duzg For BLPの部品検索障害(№10370) ------>>>>>>>>>>>>>>>>
            // SFの[生産年式]=0 の場合は、[車台番号]より[生産年式]を取得する
            int produceTypeOfYearNum = 0;
            if (carRecord.ProduceTypeOfYearNum.Equals(0))
            {
                produceTypeOfYearNum = searchedCarInfo.GetProduceTypeOfYear(searchFrameNo);
            }
            else
            {
                produceTypeOfYearNum = carRecord.ProduceTypeOfYearNum;
            }

            // SCM受注データ(車両情報)に、取得した生産年式を返す（ただし、SFで未設定のときだけ）
            //if (carRecord.ProduceTypeOfYearNum.Equals(0) && !produceTypeOfYearNum.Equals(0))// Del 2014/08/08 duzg For 検証／総合テスト障害対応
            if (carRecord.ProduceTypeOfYearNum.Equals(0) && produceTypeOfYearNum > 0)// Add 2014/08/08 duzg For 検証／総合テスト障害対応
            {
                carRecord.ProduceTypeOfYearNum = produceTypeOfYearNum;
            }
            // Add 2014/07/28 duzg For BLPの部品検索障害(№10370) ------<<<<<<<<<<<<<<<<

            // ADD 2012/06/06 -------------------------->>>>>
            // 生産年式、車台番号で絞り込み
            int selectedCnt = 0;
            if (produceTypeOfYearNum > 0)
            {
                selectedCnt = searchedCarInfo.SelectCarModelProduceTypeOfYear(produceTypeOfYearNum);
            }
            else if (searchFrameNo > 0)
            {
                selectedCnt = searchedCarInfo.SelectCarModelSearchFrameNo(searchFrameNo);
            }
            // 絞り込みの結果ゼロ件の時は抽出条件なしで型式選択画面を起動する
            if (selectedCnt == 0)
            {
                searchFrameNo = 0;
                produceTypeOfYearNum = 0;
            }

            // ADD 2012/06/06 --------------------------<<<<<

            // 型式選択画面を起動
            if (resultReport.Equals(CarSearchResultReport.retMultipleCarModel))
            {
                // 2011/03/08 >>>
                //if (SelectionCarModel.ShowDialog(searchedCarInfo).Equals(DialogResult.OK))
                // --- UPD 2013/05/08 三戸 2013/06/18配信分 SCM障害№10328 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //if (SelectionCarModel.ShowDialog(searchedCarInfo, produceTypeOfYearNum, searchFrameNo).Equals(DialogResult.OK))
                if (SelectionCarModel.ShowDialog(OwnerForm, searchedCarInfo, produceTypeOfYearNum, searchFrameNo).Equals(DialogResult.OK))
                // --- UPD 2013/05/08 三戸 2013/06/18配信分 SCM障害№10328 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                // 2011/03/08 <<<
                {
                    resultReport = CarAccesser.Search(searchingCarCondition, ref searchedCarInfo);
                }
                else
                {
                    return resultReport;
                }
            }
            // 2011/03/08 Add >>>
            else
            {
                if (searchedCarInfo.CarModelInfoSummarized != null && searchedCarInfo.CarModelInfoSummarized.Rows.Count > 0)
                {
                    PMKEN01010E.CarModelInfoRow row = searchedCarInfo.CarModelInfoSummarized[0];

                    // 年式の絞込み
                    if (produceTypeOfYearNum != 0)
                    {
                        int stDate = ( ( ( row.StProduceTypeOfYear / 100 ) == 9999 ) || ( ( row.StProduceTypeOfYear % 100 ) == 99 ) ) ? 0 : row.StProduceTypeOfYear;
                        int edDate = ( ( ( row.EdProduceTypeOfYear / 100 ) == 9999 ) || ( ( row.EdProduceTypeOfYear % 100 ) == 99 ) ) ? 0 : row.EdProduceTypeOfYear;

                        if (stDate != 0 || edDate != 0)
                        {
                            edDate = ( edDate == 0 ) ? 999999 : edDate;

                            if (stDate <= produceTypeOfYearNum && produceTypeOfYearNum <= edDate)
                            {
                                searchedCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = produceTypeOfYearNum;
                            }
                        }
                    }

                    if (searchFrameNo != 0)
                    {
                        if (( row.StProduceFrameNo != 0 && row.StProduceFrameNo > searchFrameNo ) ||
                            ( row.EdProduceFrameNo != 0 && row.EdProduceFrameNo < searchFrameNo ))
                        {
                        }
                        else
                        {
                            searchedCarInfo.CarModelUIData[0].FrameNo = searchFrameNo.ToString();
                            searchedCarInfo.CarModelUIData[0].SearchFrameNo = searchFrameNo;
                        }
                    }
                }
            }

            // カラーの絞込み
            if (!string.IsNullOrEmpty(carRecord.RpColorCode))
            {
                PMKEN01010E.ColorCdInfoRow[] colorRows = (PMKEN01010E.ColorCdInfoRow[])searchedCarInfo.ColorCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.ColorCdInfo.ColorCodeColumn.ColumnName, carRecord.RpColorCode));
                if (colorRows.Length > 0)
                {
                    colorRows[0].SelectionState = true;
                }
            }

            // トリムの絞込み
            if (!string.IsNullOrEmpty(carRecord.TrimCode))
            {
                PMKEN01010E.TrimCdInfoRow[] trimRows = (PMKEN01010E.TrimCdInfoRow[])searchedCarInfo.TrimCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.TrimCdInfo.TrimCodeColumn.ColumnName, carRecord.TrimCode));
                if (trimRows.Length > 0)
                {
                    trimRows[0].SelectionState = true;
                }
            }
            // 2011/03/08 Add <<<

            return resultReport;
        }

        #endregion // </車両検索>

        #region <BL検索>

        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromBLCode(
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        )
        {
            Debug.WriteLine("\t手動回答処理：GoodsAccesser.SearchPartsFromBLCode()");

            // --- UPD m.suzuki 2011/05/23 ---------->>>>> // BLｺｰﾄﾞ枝番を使用するメソッドに変更
            //int status = GoodsAccesser.SearchPartsFromBLCode(
            //    searchingGoodsCondition,
            //    out partsInfoDB,
            //    out goodsUnitDataList,
            //    out msg
            //);
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCode", "BLコード検索 開始" + "パラメータ：" + GetGoodsSearchCondition(searchingGoodsCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            int status = GoodsAccesser.SearchPartsFromBLCodeForAutoSearch(
                searchingGoodsCondition,
                out partsInfoDB,
                out goodsUnitDataList,
                out msg
            );
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCode", "BLコード検索 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<
            if (!status.Equals((int)ResultUtil.ResultCode.Normal)) return status;

            if (partsInfoDB != null)
            {
                EasyLogger.Write(MY_NAME, "SearchPartsFromBLCode", "優先倉庫リストの設定 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                // --- ADD 2016/01/13 顧棟 Redmine#47845 手動回答優先倉庫表示不正の障害対応 ----->>>>>
                // フタバ倉庫引当てオプションオンのみの場合、既存と同じ仕様で行う
                if (CheckFutabaWarehAllocOption())
                {
                // --- ADD 2016/01/13 顧棟 Redmine#47845 手動回答優先倉庫表示不正の障害対応 -----<<<<<
                    // UPD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
                    //// 優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を設定
                    //partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseList(CurrentHeaderRecord);
                    // 優先倉庫リスト(PCCUOE)を設定
                    partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
                    // UPD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<
                // --- ADD 2016/01/13 顧棟 Redmine#47845 手動回答優先倉庫表示不正の障害対応 ----->>>>>
                }
                else
                {
                    //手動回答の場合、回答部品情報の優先倉庫は得意先マスタの優先倉庫と拠点設定の倉庫１～３を設定する。
                    partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseList(CurrentHeaderRecord);
                }
                EasyLogger.Write(MY_NAME, "SearchPartsFromBLCode", "優先倉庫リストの設定 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                // --- ADD 2016/01/13 顧棟 Redmine#47845 手動回答優先倉庫表示不正の障害対応 -----<<<<<

                // 品名表示区分
                SalesTtlSt foundSalesTtlSt = SalesTtlStDB.Find(
                    searchingGoodsCondition.EnterpriseCode,
                    searchingGoodsCondition.SectionCode
                );
                if (foundSalesTtlSt != null)
                {
                    // --- UPD m.suzuki 2010/06/28 ---------->>>>>
                    //partsInfoDB.PartsNameDspDivCd = foundSalesTtlSt.PartsNameDspDivCd;
                    partsInfoDB.SetPartsNameDisplayPattern(foundSalesTtlSt);
                    // --- UPD m.suzuki 2010/06/28 ----------<<<<<
                    // 2010/03/30 Add >>>
                    partsInfoDB.PriceSelectDispDiv = foundSalesTtlSt.PriceSelectDispDiv;
                    partsInfoDB.UnPrcNonSettingDiv = foundSalesTtlSt.UnPrcNonSettingDiv;
                    // 2010/03/30 Add <<<
                }

                // HACK:BLコード枝番
            }

            // 検索結果が複数ある場合
            // PartsInfoDataSetに価格計算のデリゲートを追加
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCode", "価格計算のデリゲートを追加 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            SetCalculator(partsInfoDB);
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCode", "価格計算のデリゲートを追加 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            // 2010/03/30 Add >>>
            // 得意先
            partsInfoDB.CustomerCode = CurrentHeaderRecord.CustomerCode;
            // 得意先掛率グループコードリスト
            partsInfoDB.CustRateGrpCodeList = CustRateGroupServer.Singleton.Instance.FindList(searchingGoodsCondition.EnterpriseCode);
            // 表示区分マスタのリスト
            partsInfoDB.PriceSelectDivList = PriceSelectSetAgentServer.Singleton.Instance.FindList(searchingGoodsCondition.EnterpriseCode);

            // 検索系デリゲートのセット
            SetSearcher(partsInfoDB);
            // 2010/03/30 Add <<<

            // 部品選択UIを表示(処理モードを自動回答モードとして起動)
            // 2011/01/11 >>>
            //TakePartsInfoByManualOperation(partsInfoDB, CurrentCarInfo);
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCode", "部品選択UIを表示 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            DialogResult ret = TakePartsInfoByManualOperation(partsInfoDB, CurrentCarInfo);
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCode", "部品選択UIを表示 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            if (ret != DialogResult.OK)
            {
                goodsUnitDataList = new List<GoodsUnitData>();
                status = (int)ResultUtil.ResultCode.Abort;
            }
            // 2011/01/11 <<<

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsConditionList">検索条件</param>
        /// <param name="partsInfoDBList">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromBLCode(
            List<GoodsCndtn> searchingGoodsConditionList,
            out List<PartsInfoDataSet> partsInfoDBList,
            out List<List<GoodsUnitData>> goodsUnitDataList,
            out string msg
        )
        {
            Debug.WriteLine("\t手動回答処理：GoodsAccesser.SearchPartsFromBLCode()");

            int status = GoodsAccesser.SearchPartsFromBLCodeForAutoSearch(
                searchingGoodsConditionList,
                out partsInfoDBList,
                out goodsUnitDataList,
                out msg
            );

            if (!status.Equals((int)ResultUtil.ResultCode.Normal)) return status;

            if (partsInfoDBList != null && partsInfoDBList.Count != 0)
            {
                List<string> priorWarehouse = new List<string>();
                priorWarehouse = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
                // 品名表示区分
                SalesTtlSt foundSalesTtlSt = SalesTtlStDB.Find(
                    searchingGoodsConditionList[0].EnterpriseCode,
                    searchingGoodsConditionList[0].SectionCode
                );

                foreach (PartsInfoDataSet partsInfoDB in partsInfoDBList)
                {
                    // 優先倉庫リスト(PCCUOE)を設定
                    partsInfoDB.ListPriorWarehouse = priorWarehouse;
                    if (foundSalesTtlSt != null)
                    {
                        partsInfoDB.SetPartsNameDisplayPattern(foundSalesTtlSt);
                        partsInfoDB.PriceSelectDispDiv = foundSalesTtlSt.PriceSelectDispDiv;
                        partsInfoDB.UnPrcNonSettingDiv = foundSalesTtlSt.UnPrcNonSettingDiv;
                    }
                    // 検索結果が複数ある場合
                    // PartsInfoDataSetに価格計算のデリゲートを追加
                    SetCalculator(partsInfoDB);
                    // 得意先
                    partsInfoDB.CustomerCode = CurrentHeaderRecord.CustomerCode;
                    // 得意先掛率グループコードリスト
                    partsInfoDB.CustRateGrpCodeList = CustRateGroupServer.Singleton.Instance.FindList(searchingGoodsConditionList[0].EnterpriseCode);
                    // 表示区分マスタのリスト
                    partsInfoDB.PriceSelectDivList = PriceSelectSetAgentServer.Singleton.Instance.FindList(searchingGoodsConditionList[0].EnterpriseCode);
                    // 検索系デリゲートのセット
                    SetSearcher(partsInfoDB);
                    // 部品選択UIを表示(処理モードを自動回答モードとして起動)
                    DialogResult ret = TakePartsInfoByManualOperation(partsInfoDB, CurrentCarInfo);
                    if (ret != DialogResult.OK)
                    {
                        goodsUnitDataList = new List<List<GoodsUnitData>>();
                        List<GoodsUnitData> goodsUnitDataListTemp = new List<GoodsUnitData>();
                        goodsUnitDataList.Add(goodsUnitDataListTemp);
                        status = (int)ResultUtil.ResultCode.Abort;
                    }
                }

            }
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        #endregion // </BL検索>

        // ----- 2011/08/10 ----- >>>>>
        #region <用品処理>

        /// <summary>
        /// 用品入力を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecord">検索条件</param>
        /// <param name="searchedType">検索種別</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromGoodsName(
            SCMOrderDetailRecordType scmOrderDetailRecord,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        )
        {
            partsInfoDB = null;
            goodsUnitDataList = null;
            msg = string.Empty;
            return (int)ResultUtil.ResultCode.Normal;
        }
        
        #endregion </用品処理>
        // ----- 2011/08/10 ----- <<<<<

        // 2011/01/11 Add >>>
        /// <summary>
        /// 商品連結情報リストの取得
        /// </summary>
        /// <param name="searchStatus">検索ステータス</param>
        /// <param name="scmOrderDetailRecord"></param>
        /// <param name="goodsUnitDataList"></param>
        protected override void GetGoodsUnitDataList(int searchStatus, SCMOrderDetailRecordType scmOrderDetailRecord, ref List<GoodsUnitData> goodsUnitDataList)
        {
            // 検索でキャンセルやエラーが発生した場合は空リスト
            if (searchStatus == (int)ResultUtil.ResultCode.Abort)
            {
                goodsUnitDataList = new List<GoodsUnitData>();
            }
            else
            {
                if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                {
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    goodsUnitData.BLGoodsCode = scmOrderDetailRecord.BLGoodsCode;
                    goodsUnitData.GoodsNo = scmOrderDetailRecord.GoodsNo;
                    goodsUnitData.GoodsMakerCd = scmOrderDetailRecord.GoodsMakerCd;
                    goodsUnitData.GoodsName = scmOrderDetailRecord.InqGoodsName;
                    goodsUnitData.GoodsNameKana = scmOrderDetailRecord.InqGoodsName;
                    goodsUnitData.StockList = new List<Stock>();

                    goodsUnitDataList = new List<GoodsUnitData>();
                    goodsUnitDataList.Add(goodsUnitData);
                }
            }
        }
        // 2011/01/11 Add <<<

        #endregion // </Override>

        /// <summary>
        /// 価格算出系デリゲートを設定します。
        /// </summary>
        /// <param name="partsInfoDB">部品情報</param>
        private void SetCalculator(PartsInfoDataSet partsInfoDB)
        {
            //
            if (partsInfoDB.CalculateGoodsPrice == null)
            {
                partsInfoDB.CalculateGoodsPrice += new PartsInfoDataSet.CalculateGoodsPriceCallback(
                    PriceCalculator.CalculateUnitPrice
                );
            }
            //
            if (partsInfoDB.CalculatePrice == null)
            {
                partsInfoDB.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(
                    PriceCalculator.CalcPrice
                );
            }
            // キャンペーン価格適用処理追加
            if (partsInfoDB.ReflectCampaign == null)
            {
                partsInfoDB.ReflectCampaign += new PartsInfoDataSet.ReflectCampaignCallback(
                    PriceCalculator.ReflectCampaign
                );
            }
            // 自動連携値引き適用処理追加
            if (partsInfoDB.ReflectAutoDiscount == null)
            {
                partsInfoDB.ReflectAutoDiscount += new PartsInfoDataSet.ReflectAutoDiscountCallback(
                    PriceCalculator.ReflectAutoDiscount
                );
            }
        }

        /// <summary>
        /// 手動操作で部品情報を取得します。
        /// </summary>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="carInfo">車両情報</param>
        // 2011/01/11 >>>
        //private void TakePartsInfoByManualOperation(
        //    PartsInfoDataSet partsInfoDB,
        //    PMKEN01010E carInfo
        //)

        private DialogResult TakePartsInfoByManualOperation(
            PartsInfoDataSet partsInfoDB,
            PMKEN01010E carInfo
        )
        // 2011/01/11 <<<
        {
            // 2011/01/11 Add >>>
            DialogResult retDialogResult = DialogResult.None;
            // 2011/01/11 Add <<<
            const string METHOD_NAME = "TakePartsInfoByManualOperation()";  // ログ用

            EasyLogger.Dump(carInfo, "【手動部品情報取得窓】PMKEN01010E");
            EasyLogger.Dump(partsInfoDB, "【手動部品情報取得窓】PartsInfoDataSet");

            // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
            // Thread中、車両情報を取得します
            carInfoSolt = Thread.GetNamedDataSlot(CARINFOSOLT);
            string carInfoStr = string.Empty;
            // Thread中、車両情報を取得できる場合、
            if (Thread.GetData(carInfoSolt) != null)
            {
                CarInfoThreadData carInfoThreadData = (CarInfoThreadData)Thread.GetData(carInfoSolt);

                if (carInfo != null && carInfo.CarModelUIData.Count > 0)
                {
                    // 類別(PMの情報)
                    carInfoThreadData.ModelDesignationNo = carInfo.CarModelUIData[0].ModelDesignationNo;
                    // 番号(PMの情報)
                    carInfoThreadData.CategoryNo = carInfo.CarModelUIData[0].CategoryNo;
                    // 車台番号(PMの情報)
                    if (carInfo.CarModelUIData[0].DomesticForeignCode == 2)
                    {
                        // 外車の場合
                        carInfoThreadData.FrameNo = carInfoThreadData.FrameNoSF;
                    }
                    else
                    {
                        // 国産の場合
                        carInfoThreadData.FrameNo = GetFrameNo(carInfoThreadData.FrameNoSF, carInfoThreadData.ChassisNoSF);
                    }
                    // 国産／外車区分(PMの情報)車輌管理マスタ「1:国産,2:外車」
                    carInfoThreadData.FrameNoKubun = carInfo.CarModelUIData[0].DomesticForeignCode;
                    // 年式(PMの情報)
                    carInfoThreadData.FirstEntryDate = carInfo.CarModelUIData[0].ProduceTypeOfYearInput; // 初年度
                    if (carInfoThreadData.FirstEntryDate == 0)
                    {
                        // 車両検索で取得できなかった時、SCM受注データ(車両情報)より設定
                        carInfoThreadData.FirstEntryDate = carInfoThreadData.FirstEntryDateSF;
                    }
                }
                else
                {
                    // 類別
                    carInfoThreadData.ModelDesignationNo = carInfoThreadData.ModelDesignationNoSF;
                    // 番号
                    carInfoThreadData.CategoryNo = carInfoThreadData.CategoryNoSF;
                    // 国産の場合
                    carInfoThreadData.FrameNo = GetFrameNo(carInfoThreadData.FrameNoSF, carInfoThreadData.ChassisNoSF);
                    // 車両検索で取得できなかった時、SCM受注データ(車両情報)より設定
                    carInfoThreadData.FirstEntryDate = carInfoThreadData.FirstEntryDateSF;
                }

                if (carInfo != null && carInfo.CarModelInfoSummarized.Count > 0)
                {
                    PMKEN01010E.CarModelInfoRow[] row = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfoSummarized.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                    if (row.Length > 0)
                    {
                        // メーカー(PMの情報)
                        carInfoThreadData.MakerCode = row[0].MakerCode;
                        // 車種(PMの情報)(PMの情報)
                        carInfoThreadData.ModelCode = row[0].ModelCode;
                        // 車種サブコード(PMの情報)
                        carInfoThreadData.ModelSubCode = row[0].ModelSubCode;
                        // 車種名(PMの情報)
                        carInfoThreadData.ModelFullName = row[0].ModelFullName;
                        // 型式(フル型)
                        carInfoThreadData.FullModel = row[0].FullModel;

                        if (string.IsNullOrEmpty(row[0].FullModel))
                        {
                            // 型式(フル型)
                            carInfoThreadData.FullModel = carInfoThreadData.CarInspectCertModelSF;
                        }
                    }
                }
                else
                {
                    // メーカー
                    carInfoThreadData.MakerCode = carInfoThreadData.MakerCodeSF;
                    // 車種コード
                    carInfoThreadData.ModelCode = carInfoThreadData.ModelCodeSF;
                    // 車種サブコード
                    carInfoThreadData.ModelSubCode = carInfoThreadData.ModelSubCodeSF;
                    // 車種名
                    carInfoThreadData.ModelFullName = carInfoThreadData.ModelFullNameSF;
                    // 型式(フル型)
                    carInfoThreadData.FullModel = carInfoThreadData.CarInspectCertModelSF;
                }

                // SOLTを使う前に、FREE処理を実行します。
                Thread.FreeNamedDataSlot(CARINFOSOLT);
                carInfoSolt = Thread.AllocateNamedDataSlot(CARINFOSOLT);
                Thread.SetData(carInfoSolt, carInfoThreadData);
            }
            // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

            const int LIMIT = 5;
            for (int i = 1; i <= LIMIT; i++)
            {
                try
                {
                    // 2011/01/11 >>>
                    //DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(OwnerForm, carInfo, partsInfoDB);
                    //return;
                    retDialogResult = UIDisplayControl.ProcessPartsSearch(OwnerForm, carInfo, partsInfoDB);
                    break;
                    // 2011/01/11 <<<
                }
                catch (IndexOutOfRangeException)
                {
                    if (i >= LIMIT) throw;
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("部品選択画面を表示中...@OutOfRange"));
                    System.Threading.Thread.Sleep(1000);
                }
                catch (NullReferenceException)
                {
                    if (i >= LIMIT) throw;
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("部品選択画面を表示中...@NullRef"));
                    System.Threading.Thread.Sleep(1000);
                }
            }
            // 2011/01/11 Add >>>
            return retDialogResult;
            // 2011/01/11 Add <<<
        }

        // 2010/03/30 Add >>>
        /// <summary>
        /// 検索系デリゲートをセットします。
        /// </summary>
        /// <param name="partsInfoDB"></param>
        private void SetSearcher(PartsInfoDataSet partsInfoDB)
        {
            // 結合元検索
            if (partsInfoDB.SearchPartsForSrcParts == null)
            {
                partsInfoDB.SearchPartsForSrcParts += new PartsInfoDataSet.SearchPartsForSrcPartsCallBack(this.SearchPartsForSrcPartsPrc);
            }

            // 得意先掛率グループマスタ検索
            if (partsInfoDB.GetCustRateGrp == null)
            {
                partsInfoDB.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(CustRateGroupServer.Singleton.Instance.GetCustRateGrpCode);
            }

            // 表示区分マスタ検索
            if (partsInfoDB.GetDisplayDiv == null)
            {
                partsInfoDB.GetDisplayDiv += new PartsInfoDataSet.GetDisplayDivCallBack(PriceSelectSetAgentServer.Singleton.Instance.GetDisplayDiv);
            }
        }

        /// <summary>
        /// 結合元検索処理（デリゲートに使用）
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="cndtn"></param>
        /// <param name="partsInfoDataSet"></param>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="msg"></param>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/30</br>
        private void SearchPartsForSrcPartsPrc(int mode, GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            partsInfoDataSet = new PartsInfoDataSet();
            goodsUnitDataList = new List<GoodsUnitData>();
            msg = string.Empty;

            if (cndtn == null) return;

            //-----------------------------------------------------------------------------
            // 結合元検索
            //-----------------------------------------------------------------------------
            GoodsAcs goodsAcs = new GoodsAcs();

            goodsAcs.SearchInitial(cndtn.EnterpriseCode, cndtn.SectionCode, out msg);
            int status = goodsAcs.SearchPartsForSrcParts(mode, cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

            // 価格算出系のデリゲートセット
            SetCalculator(partsInfoDataSet);

            partsInfoDataSet.PriceApplyDate = cndtn.PriceApplyDate;
        }
        // 2010/03/30 Add <<<

        // --- ADD 2012/11/01 三戸 2012/11/14配信分 システムテスト障害№22 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 車台番号を数値に変換
        /// （SCMSalesDataMaker　の　GenerateChassisNoFrameFromFrameNo「車台番号→シャシー№生成処理」を参考にした）
        /// </summary>
        /// <param name="frameNo">車台番号</param>
        /// <returns>数値</returns>
        /// <br>Update Note: 2012/11/01 三戸　伸悟</br>
        private int GetsearchFrameNo(string frameNo)
        {
            if (frameNo == "") return 0;
            if (frameNo == null) return 0;

            string[] split = frameNo.Split(new Char[] { '-' });

            if (split.Length == 1)
            {
                return TStrConv.StrToIntDef(frameNo, 0);
            }
            else if (split.Length == 2)
            {
                return TStrConv.StrToIntDef(split[1], 0);
            }

            return 0;
        }
        // --- ADD 2012/11/01 三戸 2012/11/14配信分 システムテスト障害№22 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD 譚洪 2014/09/01 Redmine#43289 -------------------- >>>
        // SCMSearcher.csから共通メソッド「GetFrameNo」を参照します。
        /// <summary>
        /// 車台番号を取得します。
        /// </summary>
        /// <param name="paraFrameNo">車台番号</param>
        /// <param name="paraChassisNo">シャシー№</param>
        /// <returns>
        /// シャシーNoが数値の場合、シャシーNoを返します。<br/>
        /// シャシーNoが数値ではない場合、<c>string.Empty</c>を返します。
        /// </returns>
        private string GetFrameNo(string paraFrameNo, string paraChassisNo)
        {
            string frameModel = "";
            string chassisNo = "";
            int status = GenerateChassisNoFrameFromFrameNoBak(paraFrameNo, out  frameModel, out  chassisNo);
            if (status == 0)
            {
                return chassisNo;
            }
            else
            {
                int chassisNumber = 0;
                if (int.TryParse(paraChassisNo, out chassisNumber))
                {
                    return paraChassisNo;
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 車台番号→シャシー№生成処理
        /// </summary>
        /// <param name="frameNo">車台番号</param>
        /// <param name="frameModel">車台型式</param>
        /// <param name="chassisNo">シャシNo</param>
        /// <returns>STATUS [0:生成完了 0以外:生成失敗]</returns>
        /// <br>Update Note: K2011/12/22 鄧潘ハン</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分NAC個別対応</br>
        /// <br>             Redmine#27446   PMSF連携／PCCforNS BLﾊﾟｰﾂｵｰﾀﾞｰ 障害対応の修正</br>
        /// <br>Update Note: 2014/09/22 鹿庭 一郎</br>
        /// <br>管理番号   ：11070184-00 SCM仕掛一覧No.10598　文字列車台番号での発注・問合せ対応</br>
        private int GenerateChassisNoFrameFromFrameNoBak(string frameNo, out string frameModel, out string chassisNo)
        {
            frameModel = "";
            chassisNo = "";

            if (frameNo == "")
            {
                frameModel = "";
                chassisNo = "";
                return 0;
            }

            // 全角文字列が含まれている場合は生成不能
            if (!IsOneByteChar(frameNo.Trim()))
            {
                frameModel = "";
                chassisNo = "";
                return 0;
            }

            int length = frameNo.Length;
            int chassisNoCache = 0;
            string[] split = frameNo.Split(new Char[] { '-' });

            if (split.Length < 0)
            {
                // 分割した結果の配列数が1以下の場合は算定不能
                return 1;
            }

            #region "-----DEL 2014/09/22 鹿庭 ------>>>>>"
            //else if (split.Length == 1)
            //{
            //    frameModel = split[0];					// 車台型式

            //    chassisNo = split[0];
            //    if (!int.TryParse(chassisNo, out chassisNoCache))
            //    {
            //        chassisNo = "";
            //    }
            //}
            //else if (split.Length == 2)
            //{
            //    frameModel = split[0];					// 車台型式
            //    chassisNo = split[1];					// シャシーNo

            //    if (!int.TryParse(chassisNo, out chassisNoCache))
            //    {
            //        chassisNo = "";
            //    }
            //}
            //else
            //{

            //    chassisNo = "";

            //    frameModel = split[0];					// 車台型式
            //}
            #endregion "-----DEL 2014/09/22 鹿庭 ------<<<<<"

            // -----ADD 2014/09/22 鹿庭 ------>>>>>
            else if (split.Length == 1)
            {
                // 分割なし
                frameModel = split[0];					// 車台型式
                chassisNo = split[0];                   // シャシーNo
            }
            else if (split.Length == 2)
            {
                // ２分割
                frameModel = split[0];					// 車台型式
                chassisNo = split[1];                   // シャシーNo
            }
            else
            {
                // ３分割以上
                frameModel = split[0];					// 車台型式
                chassisNo = split[1];                   // シャシーNo
                for (int i = 2; i < split.Length; i++)
                {
                    // 2つ目以降のハイフンは文字列とする
                    chassisNo += "-" + split[i];
                }
            }

            // シャシーNo.が全て数値の場合はint範囲以内に制限（文字列含む場合はそのまま）
            if (System.Text.RegularExpressions.Regex.IsMatch(chassisNo, "^[0-9]+$"))
            {
                if (!int.TryParse(chassisNo, out chassisNoCache))
                {
                    chassisNo = "";
                }
            }
            // -----ADD 2014/09/22 鹿庭 ------>>>>>

            // 桁数チェック
            if (frameModel.Length > 16)
            {
                frameModel = frameModel.Remove(16, frameModel.Length - 16);
            }
            // -----DEL 2014/09/22 鹿庭 ------>>>>>
            //if (chassisNo.Length > 18)
            //{
            //    chassisNo = chassisNo.Remove(18, chassisNo.Length - 18);
            //}
            // -----DEL 2014/09/22 鹿庭 ------<<<<<

            return 0;
        }

        /// <summary>
        /// 1バイト文字で構成された文字列であるか判定 
        /// 1バイト文字のみで構成された文字列 : True 
        /// 2バイト文字が含まれている文字列 : False
        /// </summary>
        /// <param name="str"></param>
        /// <returns>status</returns>
        private static bool IsOneByteChar(string str)
        {
            byte[] byte_data = System.Text.Encoding.GetEncoding(932).GetBytes(str);
            if (byte_data.Length == str.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // --- ADD 譚洪 2014/09/01 Redmine#43289 -------------------- <<<


        // ADD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// carInfoは未使用
        /// </summary>
        /// <param name="searchingGoodsCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="carInfo">車両情報</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromBLCodeCarInfo(
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
            , PMKEN01010E carInfo
        )
        {
            // UPD 2013/02/20 T.Yoshioka 2013/03/06配信予定 №92対応時の不具合 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// ダミー　未使用メソッド
            //partsInfoDB = new PartsInfoDataSet();
            //goodsUnitDataList = new List<GoodsUnitData>();
            //msg = "";
            //return 0;
            #endregion

            return SearchPartsFromBLCode(searchingGoodsCondition, out partsInfoDB, out goodsUnitDataList, out msg);
            // UPD 2013/02/20 T.Yoshioka 2013/03/06配信予定  №92対応時の不具合---------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        // ADD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// carInfoは未使用
        /// </summary>
        /// <param name="searchingGoodsConditionList">検索条件</param>
        /// <param name="partsInfoDBList">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="statusList">各明細の検索結果リスト</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="carInfo">車両情報</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromBLCodeCarInfo(
            List<GoodsCndtn> searchingGoodsConditionList,
            out List<PartsInfoDataSet> partsInfoDBList,
            out List<List<GoodsUnitData>> goodsUnitDataList,
            // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
            out List<int> statusList,
            // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
            out string msg
            , PMKEN01010E carInfo
        )
        {
            // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
            statusList = new List<int>();
            // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
            return SearchPartsFromBLCode(searchingGoodsConditionList, out partsInfoDBList, out goodsUnitDataList, out msg);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化） --------->>>>>
        /// <summary>
        /// 商品情報検索条件文字列生成
        /// </summary>
        /// <param name="searchingCondition">商品情報検索条件</param>
        /// <returns>商品情報検索条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 商品情報検索条件文字列生成処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/05/15</br>
        /// </remarks>
        public string GetGoodsSearchCondition(GoodsCndtn searchingCondition)
        {
            string carString = string.Empty;
            try
            {
                carString = LinkBreak + "BLGoodsCode:" + searchingCondition.BLGoodsCode.ToString() + LinkBreak
                    + "BLGoodsDrCode:" + searchingCondition.BLGoodsDrCode.ToString() + LinkBreak
                    + "BLGoodsName:" + searchingCondition.BLGoodsName.ToString() + LinkBreak
                    + "BLGroupCode:" + searchingCondition.BLGroupCode.ToString() + LinkBreak
                    + "BLGroupName:" + searchingCondition.BLGroupName.ToString() + LinkBreak
                    + "EnterpriseCode:" + searchingCondition.EnterpriseCode.ToString() + LinkBreak
                    + "GoodsMakerCd:" + searchingCondition.GoodsMakerCd.ToString() + LinkBreak
                    + "GoodsNo:" + searchingCondition.GoodsNo.ToString() + LinkBreak
                    + "WarehouseCode:" + searchingCondition.WarehouseCode.ToString();
            }
            catch (Exception ex) 
            {
                carString = LinkBreak + "＃＃＃例外＃＃＃" + LinkBreak + ex.ToString();
            }
            return carString;
        }
        // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化） ---------<<<<<
    }
}
