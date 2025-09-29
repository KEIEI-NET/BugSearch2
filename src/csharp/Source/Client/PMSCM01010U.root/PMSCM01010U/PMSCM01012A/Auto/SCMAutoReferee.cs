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
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優 
// 作 成 日  2010/04/22  修正内容 : 作成される売上データが「受注」となる(受注ステータスが「受注」となる)場合、自動回答の対象としない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/05/21  修正内容 : 相場情報オプション対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2010/08/06  修正内容 : Redmine#23307
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaofeng
// 作 成 日  2011/08/10  修正内容 : PCCUOEの対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/04/17  修正内容 : 障害№166 発注時に在庫の確認を行うように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/06/20  修正内容 : SCM障害№166、システム障害№98の戻し
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/27  修正内容 : SCM障害№166の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341,10364,10431対応 PCCforNS、BLPの自動回答判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡
// 作 成 日  2013/10/18  修正内容 : 商品保証課Redmine#551対応
//----------------------------------------------------------------------------//
#define _ENABLED_MARKET_PRICE_ANSWER_DIV_CHECK_ // 相場価格回答区分のチェックを有効にするフラグ ※通常は有効にしておくこと！
#define _ENABLED_MARKET_PRICE_OPTION_CHECK_ // 相場オプションのチェックを有効にするフラグ　※通常は有効にすること　2010/05/21 Add

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
// 2010/05/21 Add >>>
using Broadleaf.Application.Remoting.ParamData; 
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
// 2010/05/21 Add <<<

namespace Broadleaf.Application.Controller.Auto
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM受注データ
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM受注明細データ(回答)

    using SCMMarketPriceServer = SingletonInstance<SCMMarketPriceAgent>;    // SCM相場価格設定マスタ

    /// <summary>
    /// SCM自動用回答判定処理クラス
    /// </summary>
    public sealed class SCMAutoReferee : SCMReferee
    {
        private const string MY_NAME = "SCMAutoReferee";    // ログ用

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="searcher">SCM検索処理</param>
        public SCMAutoReferee(SCMSearcher searcher) : base(searcher) { }

        #endregion // </Constructor>

        #region <SCM相場価格設定マスタ>

        /// <summary>
        /// SCM相場価格設定マスタを取得します。
        /// </summary>
        private static SCMMarketPriceAgent MarketPriceDB
        {
            get { return SCMMarketPriceServer.Singleton.Instance; }
        }

        #endregion // </SCM相場価格設定マスタ>

        #region <Override>

        /// <summary>
        /// 回答用SCM情報付商品連結データが空の場合、初期化します。
        /// </summary>
        /// <see cref="SCMReferee"/>
        public override void InitializeIfSCMGoodsUnitDataMapIsEmpty()
        {
            if (SCMGoodsUnitDataMap.Count.Equals(0))
            {
                CanReplyAutomatically();
            }
        }

        #region <相場回答用のSCM情報付商品連結データ構築>

        /// <summary>
        /// 相場情報付き回答用SCM情報付商品連結データのリストを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>相場情報付き回答用SCM情報付商品連結データのリスト</returns>
        /// <see cref="SCMReferee"/>
        protected override IList<SCMGoodsUnitData> GetSCMGoodsUnitDataListHavingSobaResponse(SCMOrderDetailRecordType detailRecord)
        {
            const string METHOD_NAME = "GetSCMGoodsUnitDataListHavingSobaResponse()";   // ログ用

            #region <Guard Phrase>

            // ヘッダがない
            if (!RelationalHeaderMap.ContainsKey(detailRecord.ToRelationKey()))
            {
                Debug.Assert(false, string.Format("明細のヘッダが存在しません。：{0}", detailRecord.ToRelationKey()));
                return new List<SCMGoodsUnitData>();
            }
            else
            {
                // SCM受注データ.問合せ・発注種別が「1:問合せ」でなければ処理しない
                if (!RelationalHeaderMap[detailRecord.ToRelationKey()].InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry))
                {
                    return new List<SCMGoodsUnitData>();
                }
            }

            // 検索結果がない
            if (!Searcher.ResultMap.ContainsKey(detailRecord.ToKey()))
            {
                return new List<SCMGoodsUnitData>();
            }

            #endregion // </Guard Phrase>

            // 2010/05/21 Add >>>

            #region 相場情報オプションのチェック
        #if _ENABLED_MARKET_PRICE_OPTION_CHECK_

            PurchaseStatus psMarketInfo = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_MarketInfo);
            if (psMarketInfo != PurchaseStatus.Contract && psMarketInfo != PurchaseStatus.Trial_Contract)
            {
                #region <Log>

                string msg = "相場情報オプションが契約されていません。";
                msg += Environment.NewLine + SCMDataHelper.GetLabel(detailRecord);
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return new List<SCMGoodsUnitData>();
            }
        #endif
            #endregion
            // 2010/05/21 Add <<<

            #region <相場価格回答区分のチェック>

        #if _ENABLED_MARKET_PRICE_ANSWER_DIV_CHECK_

            // SCM相場価格設定マスタに登録がないまたは相場価格回答区分が「0:しない」の場合、終了
            SCMMrktPriSt scmMarketPriceSetting = SCMMarketPriceServer.Singleton.Instance.Find(
                detailRecord.InqOtherEpCd,
                detailRecord.InqOtherSecCd
            );
            if (!SCMDataHelper.IsAvailableRecord(scmMarketPriceSetting)) scmMarketPriceSetting = null;
            if (
                scmMarketPriceSetting == null
                    ||
                scmMarketPriceSetting.MarketPriceAnswerDiv.Equals((int)MarketPriceAnswerDiv.None)
            )
            {
                #region <Log>

                string msg = "SCM相場価格設定マスタに登録がない または SCM相場価格設定マスタ.相場価格回答区分が「0:しない」です。";
                msg += Environment.NewLine + SCMDataHelper.GetLabel(detailRecord);
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return new List<SCMGoodsUnitData>();
            }

        #endif

            #endregion // </相場価格回答区分のチェック>

            IList<SCMGoodsUnitData> scmGoodsUnitDataList = new List<SCMGoodsUnitData>();
            {
                // 相場情報を取得
                string relevanceModel = GetRelevanceModel(detailRecord);
                if (string.IsNullOrEmpty(relevanceModel.Trim()))
                {
                    #region <Log>

                    string msg = "「品番検索のため車両検索結果が無い」または「車両検索結果に類別型式が複数ある」ため、相場情報の取得を中断しました。";
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return scmGoodsUnitDataList;
                }

                Debug.WriteLine("明細キー：" + detailRecord.ToKey() + ", BLコード：" + detailRecord.BLGoodsCode.ToString());
                foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)
                {
                    // 相場情報を取得用SCM情報付商品連結データ
                    SCMGoodsUnitData gettingCondition = new SCMGoodsUnitData(
                        goodsUnitData,
                        Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                        detailRecord,
                        GetCustomerCode(detailRecord)
                    );
                    // 相場情報を取得
                    IList<SCMSobaResponseHelper> foundSobaResponseList = MarketPriceDB.GetSobaResponse(
                        detailRecord,
                        relevanceModel,
                        gettingCondition
                    );
                    // 相場価格種別の設定数分の相場情報が返ってくるので、
                    // その件数分の回答用SCM情報付商品連結データを生成する
                    foreach (SCMSobaResponseHelper sobaResponse in foundSobaResponseList)
                    {
                        if (!sobaResponse.Exists) continue;

                        SCMGoodsUnitData scmGoodsUnitData = new SCMGoodsUnitData(
                            goodsUnitData,
                            Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                            detailRecord,
                            GetCustomerCode(detailRecord)
                        );
                        scmGoodsUnitData.AddSobaResponse(sobaResponse);

                        scmGoodsUnitDataList.Add(scmGoodsUnitData);
                    }

                    // 1明細分(1BLコード分)でよいので、強制的に終了
                    return scmGoodsUnitDataList;
                }   // foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)
            }
            return scmGoodsUnitDataList;
        }

        #endregion // </相場回答用のSCM情報付商品連結データ構築>

        // ADD 2010/04/22 作成される売上データが「受注」となる(受注ステータスが「受注」となる)場合、自動回答の対象としない ---------->>>>>
        #region <売上データを作成できるかの判定>

        /// <summary>
        /// 売上データを作成できるか判断します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM用の情報付商品連結データのリスト</param>
        /// <returns>
        /// <c>true</c> :売上データを作成できます。<br/>
        /// <c>false</c>:売上データを作成できません。(受注ステータスが「受注」となる商品を含みます)
        /// </returns>
        protected override bool CanMakeSalesData(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            const string METHOD_NAME = "CanMakeSalesData()";    // ログ用

            #region <Guard Phrase>

            if (detailRecord == null || ListUtil.IsNullOrEmpty(scmGoodsUnitDataList)) return false;

            #endregion // </Guard Phrase>
            // --- Add  2011/08/02 duzg for Redmine#23307 --->>>
            // SCM全体設定を取得
            SCMTtlSt foundSCMTtlSt = TtlStSettingDB.Find(
                 detailRecord.InqOtherEpCd,
                 detailRecord.InqOtherSecCd
                );
            // --- Add  2011/08/02 duzg for Redmine#23307 ---<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            // 優先設定の絞り込み結果、純正１品番か
            bool onePureGoodsFlag = IsOnePureGoods(scmGoodsUnitDataList);
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                int acptAnOdrStatus = scmGoodsUnitData.GetAcptAnOdrStatus();
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                #region 削除(SCM改良の為)
                //// ----- 2011/08/10 ----- >>>>>
                //// SCMの場合
                //if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
                //{
                //// ----- 2011/08/10 ----- <<<<<
                //    if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                //    {
                //        #region <手動回答>

                //        #region <Log>

                //        string msg = "受注ステータスが「受注」となるため、手動回答としました。";
                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </手動回答>

                //        return false;
                //    }
                //    // --- Add 2011/08/06 duzg for Redmine#23307 --->>>
                //    else if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales) && scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Trust
                //        && scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Customer
                //        && scmGoodsUnitData.GetStockDiv() != (int)StockDiv.PriorityWarehouse && foundSCMTtlSt.AutoAnswerDiv != 3)
                //    {
                //        #region <手動回答>

                //        #region <Log>

                //        string msg = "委託在庫ではないので、手動回答としました。";
                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </手動回答>

                //        return false;
                //    }
                //    // --- Add 2011/08/06 duzg for Redmine#23307 ---<<<
                //    /* --- Del 2011/08/06 duzg for Redmine#23307 --->>>
                //    // 2011/02/18 Add >>>
                //    else if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales) && scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Trust)
                //    {
                //        #region <手動回答>

                //        #region <Log>

                //        string msg = "委託在庫ではないので、手動回答としました。";
                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </手動回答>

                //        return false;
                //    }
                //    // 2011/02/18 Add <<<
                //     --- Del 2011/08/06 duzg for Redmine#23307 ---<<<*/
                //// ----- 2011/08/10 ----- >>>>>
                //}
                //// PCCUOEの場合
                //else
                //{
                //    if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                //    {
                //        #region <手動回答>

                //        #region <Log>

                //        string msg = "受注ステータスが「受注」となるため、手動回答としました。";
                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </手動回答>

                //        return false;
                //    }
                //    // 発注の場合、非委託在庫又は在庫不足
                //    else if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales) 
                //        && (scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Trust
                //        // UPD 2012/06/27 SCM障害№166 在庫情報取得----------------------------------->>>>>
                //        // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ---------->>>>>
                //        //    || detailRecord.PmPrsntCount < detailRecord.SalesOrderCount))
                //        // --- UPD 三戸 2012/04/17 №166 ---------->>>>>
                //        //|| scmGoodsUnitData.GetStockQty() < detailRecord.SalesOrderCount))
                //        // --- UPD 三戸 2012/04/17 №166 ----------<<<<<
                //        // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ----------<<<<<
                //        || scmGoodsUnitData.GetStockQty() < detailRecord.SalesOrderCount))
                //        // UPD 2012/06/27 SCM障害№166 在庫情報取得-----------------------------------<<<<<
                //    {
                //        #region <手動回答>
                //        string msg = string.Empty;
                //        // 非委託在庫
                //        if (scmGoodsUnitData.GetStockDiv() != (int)StockDiv.Trust)
                //        {
                //            msg = "委託在庫ではないので、手動回答としました。";
                //        }
                //        // 在庫不足
                //        else if (scmGoodsUnitData.GetStockQty() < detailRecord.SalesOrderCount)
                //        {
                //            msg = "在庫不足なので、手動回答としました。";
                //        }

                //        #region <Log>

                //        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>

                //        // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                //        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                //        {
                //            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                //        }

                //        #endregion // </手動回答>

                //        return false;
                //    }
                //}
                //// ----- 2011/08/10 ----- <<<<<
                #endregion

                // 受注ステータスが「受注」の時
                if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                {
                    #region <手動回答>

                    #region <Log>

                    string msg = "受注ステータスが「受注」となるため、手動回答としました。";
                    string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                    #endregion // </Log>

                    // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                    if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                    {
                        ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                    }

                    #endregion // </手動回答>

                    return false;
                }

                // 問合せでPCC全体設定の自動回答区分（問合せ）が「する（絞り込み時自動回答）」の時
                if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Estimate)
                    && foundSCMTtlSt.AutoAnsInquiryDiv.Equals((int)AutoAnsInquiryDiv.SelectAuto))
                {
                    // 優先設定での絞り込みが純正１品番ではない時、手動回答
                    if (!onePureGoodsFlag)
                    {
                        #region <手動回答>

                        #region <Log>

                        string msg = "優先設定による絞り込みで純正１品番ではないため、手動回答としました。";
                        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                        #endregion // </Log>

                        // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                        {
                            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                        }

                        #endregion // </手動回答>

                        return false;

                    }
                }
                // 発注でPCC全体設定の自動回答区分（発注）が「する（委託倉庫分のみ自動回答）」の時
                if (acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales)
                    && foundSCMTtlSt.AutoAnsOrderDiv.Equals((int)AutoAnsOrderDiv.TrustAuto))
                {
                    // 在庫区分が委託在庫以外の時、手動回答
                    if (!scmGoodsUnitData.GetStockDiv().Equals((int)StockDiv.Trust))
                    {
                        #region <手動回答>

                        #region <Log>

                        string msg = "委託在庫ではないので、手動回答としました。";
                        string label = SCMDataHelper.GetLabel(detailRecord) + Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitData.RealGoodsUnitData);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                        #endregion // </Log>

                        // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                        if (!ManualSCMDetailRecordMap.ContainsKey(detailRecord.ToKey()))
                        {
                            ManualSCMDetailRecordMap.Add(detailRecord.ToKey(), detailRecord);
                        }

                        #endregion // </手動回答>

                        return false;
                    }
                }
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            }
            return true;
        }

        #endregion // </売上データを作成できるかの判定>
        // ADD 2010/04/22 作成される売上データが「受注」となる(受注ステータスが「受注」となる)場合、自動回答の対象としない ----------<<<<<

        #endregion // </Override>

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
        #region <純正１品番の判定>
        /// <summary>
        /// 純正1品番か判断します。
        /// </summary>
        /// <param name="detailRecordList">SCM用の情報付商品連結データリスト</param>
        /// <returns>
        /// <c>true</c> :純正1品番です。<br/>
        /// <c>false</c>:純正1品番ではありません。
        /// </returns>
        protected bool IsOnePureGoods(IList<SCMGoodsUnitData> detailRecordList)
        {
            const string METHOD_NAME = "IsOnePureGoods()";  // ログ用

            #region <Guard Phrase>

            // リストがない時、false
            if (detailRecordList == null)
            {
                return false;
            }

            #endregion // </Guard Phrase>

            #region <Log>

            string title = "純正1品番であるか判定中...";
            title += Environment.NewLine + SCMDataHelper.GetProfile(detailRecordList);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(title));

            #endregion // </Log>

            // 純正が2件以上存在した場合、false
            int pureCount = 0;
            foreach (SCMGoodsUnitData scmgoodsUnitData in detailRecordList)
            {
                GoodsUnitData goodsUnitData = (GoodsUnitData)scmgoodsUnitData.RealGoodsUnitData;
                #region 見積計上用処理

                // 前回、｢見積｣で回答済み商品はチェック対象としない
                if (goodsUnitData is AnsweredGoodsUnitData)
                {
                    #region <Log>

                    string msg = "純正1品番の判定を省略します。∵前回、｢見積｣で回答済み商品です";
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    continue;
                }

                #endregion // 見積計上用処理
                // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

                // DEL 2013/10/18 吉岡 商品保証課Redmine#551 ---------->>>>>>>>>>
                //// 商品連結データの商品種別(複数あり)がセット子の場合、純正1品番ではない（手動回答）
                //if (ContainsSetChildAtGoodsKind(goodsUnitData))
                //{
                //    #region <Log>

                //    string msg = "純正1品番ではありません。∵商品連結データの商品種別(複数あり)がセット子";
                //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //    #endregion // </Log>

                //    return false;
                //}
                // DEL 2013/10/18 吉岡 商品保証課Redmine#551 ----------<<<<<<<<<< 

                // 商品連結データの商品種別(複数あり)が親または代替または代替互換で、
                // 「提供区分(OfferKubun)：純正」のデータが2件以上存在した場合、
                // 純正1品番ではない（手動回答）
                if (ContainsParentAtGoodsKind(goodsUnitData) && IsPureAtOfferKubun(goodsUnitData))
                {
                    pureCount++;

                    #region <Log>

                    string msg = "商品連結データの商品種別(複数あり)が親 または 代替 または 代替互換で、「提供区分(OfferKubun)：純正」のデータ";
                    msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(goodsUnitData);
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    if (pureCount > 1)
                    {
                        #region <Log>

                        msg = "純正1品番ではありません。";
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return false;
                    }
                }
            }

            #region <Log>

            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("純正1品番です。"));

            #endregion // </Log>

            return true;
        }
        #endregion
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

    }
}
