//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/10/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/20  修正内容 : 2012/12/12配信予定システムテスト障害№30対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/20  修正内容 : 2012/12/12配信予定システムテスト障害№47対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/30  修正内容 : 2012/12/12配信予定システムテスト障害№91対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/02/05  修正内容 : SCM仕掛一覧№10627対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡
// 作 成 日  2014/05/09  修正内容 : 速度改善フェーズ２№11,№12 絞込タイミング変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/06/06  修正内容 : 商品保証課Redmine#1581対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 田建委
// 修 正 日  2020/05/15  修正内容 : PMKOBETSU-3932 BLP障害（ログ強化）
//                                : 既存コードのログ出力強化を行う
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType = AutoAnsItemStAcs;
    using RecordType = List<AutoAnsItemSt>;

    /// <summary>
    /// 自動回答品目設定マスタアクセスの代理人クラス
    /// </summary>
    public sealed class AutoAnsItemStAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "AutoAnsItemStAgent";    // ログ用
        private const string LinkBreak = "\r\n";  //改行
        /// <summary>
        /// 自動回答区分列挙型
        /// </summary>
        public enum AutoAnswerDiv : int
        {
            /// <summary>0:しない(全て手動回答)</summary>
            None = 0,
            /// <summary>1:する(全て自動回答)</summary>
            All = 1,
            /// <summary>2:する(優先順位)</summary>
            Priority = 2
        }

        /// <summary>
        /// 自動回答区分の名称を取得します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <returns></returns>
        public static string GetAutoAnswerDivName(AutoAnsItemSt autoAnsItemSt)
        {
            if (autoAnsItemSt == null) return string.Empty;

            switch (autoAnsItemSt.AutoAnswerDiv)
            {
                case (int)AutoAnswerDiv.None:
                    return "しない(全て手動回答)";
                case (int)AutoAnswerDiv.All:
                    return "する(全て自動回答)";
                case (int)AutoAnswerDiv.Priority:
                    return "する(優先順位)";
                default:
                    return string.Empty;
            }
        }

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        // UPD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
        //public AutoAnsItemStAgent() { }
        public AutoAnsItemStAgent() : base() { }
        // UPD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

        #endregion // </Constructor>

        /// <summary>
        /// 自動回答品目設定を取得します。
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>検索結果(自動回答品目設定マスタのレコードリスト)</returns>
        public RecordType Search(List<GoodsUnitData> goodsUnitDataList, int customerCode)
        {
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            string key = goodsUnitDataList[0].EnterpriseCode.Trim() + goodsUnitDataList[0].SectionCode.Trim() + customerCode.ToString().Trim();
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<
            // 1パラ目
            AutoAnsItemStOrder searchingCondition = new AutoAnsItemStOrder();
            {
                // 企業コード
                searchingCondition.EnterpriseCode = goodsUnitDataList[0].EnterpriseCode;

                // 拠点コード
                searchingCondition.SectionCode = goodsUnitDataList[0].SectionCode;

                // 得意先コード
                searchingCondition.St_CustomerCode = customerCode;
                searchingCondition.Ed_CustomerCode = customerCode;

                // 商品中分類コード
                searchingCondition.St_GoodsMGroup = 0;
                searchingCondition.Ed_GoodsMGroup = int.MaxValue;

                // BL商品コード
                searchingCondition.St_BLGoodsCode = 0;
                searchingCondition.Ed_BLGoodsCode = int.MaxValue;

                // 商品メーカーコード
                searchingCondition.St_GoodsMakerCd = 0;
                searchingCondition.Ed_GoodsMakerCd = int.MaxValue;

                // BLグループコード
                searchingCondition.St_BLGroupCode = 0;
                searchingCondition.Ed_BLGroupCode = int.MaxValue;
            }

            // 2パラ目
            List<AutoAnsItemSt> searchedList = null;

            // 3パラ目
            string msg = string.Empty;

            // 検索
            RealAccesser.EnterpriseCode = goodsUnitDataList[0].EnterpriseCode;
            RealAccesser.SectionCode = goodsUnitDataList[0].SectionCode;
            EasyLogger.Write(MY_NAME, "Search", "検索　開始" + "パラメータ：" + GetOrderSearchCondition(searchingCondition));  // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            int status = RealAccesser.SearchAll(searchingCondition, out searchedList, out msg);
            if (searchedList == null && customerCode > 0)
            {
                // 得意先コードで検索していた場合、拠点コードで再検索
                searchingCondition.St_CustomerCode = 0;
                searchingCondition.Ed_CustomerCode = 0;
                searchingCondition.SectionCode = goodsUnitDataList[0].SectionCode;
                status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            }
            EasyLogger.Write(MY_NAME, "Search", "検索　完了");  // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            // TODO:全検索結果をダンプ
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            FoundRecordMap.Add(key, searchedList ?? new List<AutoAnsItemSt>());
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

            return searchedList ?? new List<AutoAnsItemSt>();
        }


        /// <summary>
        /// 自動回答品目設定を取得します。
        /// </summary>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データリスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>検索結果(自動回答品目設定マスタのレコードリスト)</returns>
        public RecordType Search(IList<SCMGoodsUnitData> scmGoodsUnitDataList, int customerCode)
        {
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            string key = scmGoodsUnitDataList[0].RealGoodsUnitData.EnterpriseCode + scmGoodsUnitDataList[0].RealGoodsUnitData.SectionCode.Trim() + customerCode.ToString();
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

            // 1パラ目
            AutoAnsItemStOrder searchingCondition = new AutoAnsItemStOrder();
            {
                // 企業コード
                searchingCondition.EnterpriseCode = scmGoodsUnitDataList[0].RealGoodsUnitData.EnterpriseCode;

                // 拠点コード
                searchingCondition.SectionCode = scmGoodsUnitDataList[0].RealGoodsUnitData.SectionCode;

                // 得意先コード
                searchingCondition.St_CustomerCode = customerCode;
                searchingCondition.Ed_CustomerCode = customerCode;

                // 商品中分類コード
                searchingCondition.St_GoodsMGroup = 0;
                searchingCondition.Ed_GoodsMGroup = int.MaxValue;

                // BL商品コード
                searchingCondition.St_BLGoodsCode = 0;
                searchingCondition.Ed_BLGoodsCode = int.MaxValue;

                // 商品メーカーコード
                searchingCondition.St_GoodsMakerCd = 0;
                searchingCondition.Ed_GoodsMakerCd = int.MaxValue;

                // BLグループコード
                searchingCondition.St_BLGroupCode = 0;
                searchingCondition.Ed_BLGroupCode = int.MaxValue;
            }

            // 2パラ目
            List<AutoAnsItemSt> searchedList = null;

            // 3パラ目
            string msg = string.Empty;

            // 検索
            RealAccesser.EnterpriseCode = scmGoodsUnitDataList[0].RealGoodsUnitData.EnterpriseCode;
            RealAccesser.SectionCode = scmGoodsUnitDataList[0].RealGoodsUnitData.SectionCode;
            int status = RealAccesser.SearchAll(searchingCondition, out searchedList, out msg);
            if (searchedList == null && customerCode > 0)
            {
                // 得意先コードで検索していた場合、拠点コードで再検索
                searchingCondition.St_CustomerCode = 0;
                searchingCondition.Ed_CustomerCode = 0;
                searchingCondition.SectionCode = scmGoodsUnitDataList[0].RealGoodsUnitData.SectionCode;
                status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            }

            // TODO:全検索結果をダンプ
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            FoundRecordMap.Add(key, searchedList ?? new List<AutoAnsItemSt>());
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

            return searchedList ?? new List<AutoAnsItemSt>();
        }

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="foundAutoAnsItemStList">自動回答品目設定リスト</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>検索結果(自動回答品目設定)</returns>
        public AutoAnsItemSt Find(
            List<AutoAnsItemSt> foundAutoAnsItemStList,
            GoodsUnitData goodsUnitData,
            int customerCode
        )
        {
            const string METHOD_NAME = "Find(List<AutoAnsItemSt>, GoodsUnitData, int)";  // ログ用

            // 検索結果
            AutoAnsItemSt retAutoAnsItemSt = new AutoAnsItemSt();

            // 一括検索結果より優先順位に合わせて検索結果を抽出
            if (customerCode > 0)
            {
                #region  優先順位1:得意先＋中分類＋BLコード＋メーカー

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority1(AutoAnsItemSt, goodsUnitData, customerCode);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位1:得意先(={0})＋中分類(={1})＋BLコード(={2})＋メーカー(={3}) で検索されました。",
                        customerCode,
                        goodsUnitData.GoodsMGroup,
                        goodsUnitData.BLGoodsCode,
                        goodsUnitData.GoodsMakerCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                // ADD 2012/11/30 2012/12/12配信予定システムテスト障害№91対応 ------------------------>>>>>
                #region  優先順位2:得意先＋中分類（共通）＋BLコード＋メーカー

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority2(AutoAnsItemSt, goodsUnitData, customerCode);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位1:得意先(={0})＋中分類(={1})＋BLコード(={2})＋メーカー(={3}) で検索されました。",
                        customerCode,
                        goodsUnitData.GoodsMGroup,
                        goodsUnitData.BLGoodsCode,
                        goodsUnitData.GoodsMakerCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion
                // ADD 2012/11/30 2012/12/12配信予定システムテスト障害№91対応 ------------------------<<<<<

                // DEL 2012/11/20 2012/12/12配信予定システムテスト障害№47対応 ------------------------>>>>>
                #region 削除
                //#region 優先順位2:得意先＋中分類＋BLコード

                //retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                //    delegate(AutoAnsItemSt AutoAnsItemSt)
                //    {
                //        return IsPriority2(AutoAnsItemSt, goodsUnitData, customerCode);
                //    }
                //);
                //if (retAutoAnsItemSt != null)
                //{
                //    #region <Log>

                //    string msg = string.Format(
                //        "優先順位2:得意先(={0})＋中分類(={1})＋BLコード(={2}) で検索されました。",
                //        customerCode,
                //        goodsUnitData.GoodsMGroup,
                //        goodsUnitData.BLGoodsCode
                //    );
                //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //    #endregion // </Log>

                //    return retAutoAnsItemSt;
                //}

                //#endregion
                #endregion //削除
                // DEL 2012/11/20 2012/12/12配信予定システムテスト障害№47対応 ------------------------<<<<<

                #region 優先順位3:得意先＋中分類＋メーカー

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority3(AutoAnsItemSt, goodsUnitData, customerCode);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位3:得意先(={0})＋中分類(={1}) で検索されました。",
                        customerCode,
                        goodsUnitData.GoodsMGroup
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                #region 優先順位4:得意先＋メーカー

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority4(AutoAnsItemSt, goodsUnitData, customerCode);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位4:得意先(={0}) で検索されました。",
                        customerCode
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion
            }
            if (!string.IsNullOrEmpty(goodsUnitData.SectionCode.Trim()))
            {
                #region 優先順位5:拠点＋中分類＋BLコード＋メーカー

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority5(AutoAnsItemSt, goodsUnitData);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位5:拠点(={0})＋中分類(={1})＋BLコード(={2})＋メーカー(={3}) で検索されました。",
                        goodsUnitData.SectionCode,
                        goodsUnitData.GoodsMGroup,
                        goodsUnitData.BLGoodsCode,
                        goodsUnitData.GoodsMakerCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                // ADD 2012/11/30 2012/12/12配信予定システムテスト障害№91対応 ------------------------>>>>>
                #region 優先順位6:拠点＋中分類（共通）＋BLコード＋メーカー

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority6(AutoAnsItemSt, goodsUnitData);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位5:拠点(={0})＋中分類(={1})＋BLコード(={2})＋メーカー(={3}) で検索されました。",
                        goodsUnitData.SectionCode,
                        goodsUnitData.GoodsMGroup,
                        goodsUnitData.BLGoodsCode,
                        goodsUnitData.GoodsMakerCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion
                // ADD 2012/11/30 2012/12/12配信予定システムテスト障害№91対応 ------------------------<<<<<

                // DEL 2012/11/20 2012/12/12配信予定システムテスト障害№47対応 ------------------------>>>>>
                #region 削除
                //#region 優先順位6:拠点＋中分類＋BLコード

                //retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                //    delegate(AutoAnsItemSt AutoAnsItemSt)
                //    {
                //        return IsPriority6(AutoAnsItemSt, goodsUnitData);
                //    }
                //);
                //if (retAutoAnsItemSt != null)
                //{
                //    #region <Log>

                //    string msg = string.Format(
                //        "優先順位6:拠点(={0})＋中分類(={1})＋BLコード(={2}) で検索されました。",
                //        goodsUnitData.SectionCode,
                //        goodsUnitData.GoodsMGroup,
                //        goodsUnitData.BLGoodsCode
                //    );
                //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //    #endregion // </Log>

                //    return retAutoAnsItemSt;
                //}

                //#endregion
                #endregion
                // DEL 2012/11/20 2012/12/12配信予定システムテスト障害№47対応 ------------------------<<<<<

                #region 優先順位7:拠点＋中分類＋メーカー

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority7(AutoAnsItemSt, goodsUnitData);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位7:拠点(={0})＋中分類(={1}) で検索されました。",
                        goodsUnitData.SectionCode,
                        goodsUnitData.GoodsMGroup
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                #region 優先順位8:拠点＋メーカー

                retAutoAnsItemSt = foundAutoAnsItemStList.Find(
                    delegate(AutoAnsItemSt AutoAnsItemSt)
                    {
                        return IsPriority8(AutoAnsItemSt, goodsUnitData);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位8:拠点(={0}) で検索されました。",
                        goodsUnitData.SectionCode
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion
            }
            else
            {
                retAutoAnsItemSt = null;
                return retAutoAnsItemSt;
            }

            int sectionCode = int.Parse(goodsUnitData.SectionCode.Trim());
            if (sectionCode > 0)
            {
                // UPD 2012/11/20 2012/12/12配信予定 システムテスト障害№30対応 -------------------------->>>>> 
                //goodsUnitData.SectionCode = "00";    // 全社で再検索
                //return Find(foundAutoAnsItemStList, goodsUnitData, customerCode);
                GoodsUnitData retryGoodsUnitData = new GoodsUnitData();
                retryGoodsUnitData = goodsUnitData.Clone();
                retryGoodsUnitData.SectionCode = "00"; //全社で再検索
                return Find(foundAutoAnsItemStList, retryGoodsUnitData, customerCode);
                // UPD 2012/11/20 2012/12/12配信予定 システムテスト障害№30対応 --------------------------<<<<< 
            }

            return retAutoAnsItemSt;
        }

        #region 優先順位の判断

        /// <summary>
        /// 優先順位1:得意先＋中分類＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>
        /// <c>true</c> :優先順位1です。<br/>
        /// <c>false</c>:優先順位1ではありません。
        /// </returns>
        private static bool IsPriority1(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData, int customerCode)
        {
            if ( autoAnsItemSt.PrmSetDtlNo2 == 0 || 
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                // UPD 2012/11/20 2012/12/12配信予定 システムテスト障害№47対応 --------------------->>>>>
                //return (
                //    autoAnsItemSt.CustomerCode == customerCode
                //        &&
                //    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                //);
                // UPD 2012/11/30 2012/12/12配信予定 システムテスト障害№91対応 --------------------->>>>>
                //return (
                //    (autoAnsItemSt.CustomerCode == customerCode
                //        &&
                //    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd) ||

                //    (autoAnsItemSt.CustomerCode == customerCode
                //        &&
                //    autoAnsItemSt.GoodsMGroup == 0
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd)

                //);
                return (
                    autoAnsItemSt.CustomerCode == customerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
                // UPD 2012/11/30 2012/12/12配信予定 システムテスト障害№91対応 ---------------------<<<<<
                // UPD 2012/11/20 2012/12/12配信予定 システムテスト障害№47対応 ---------------------<<<<<
            }
            return false;
        }

        // DEL 2012/11/20 2012/12/12配信予定 システムテスト障害№47対応 --------------------->>>>>
        #region 削除
        ///// <summary>
        ///// 優先順位2:得意先＋中分類＋BLコードであるか判断します。
        ///// </summary>
        ///// <param name="autoAnsItemSt">自動回答品目設定</param>
        ///// <param name="goodsUnitData">商品連結データ</param>
        ///// <param name="customerCode">得意先コード</param>
        ///// <returns>
        ///// <c>true</c> :優先順位2です。<br/>
        ///// <c>false</c>:優先順位2ではありません。
        ///// </returns>
        //private static bool IsPriority2(AutoAnsItemSt autoAnsItemSt,  GoodsUnitData goodsUnitData, int customerCode)
        //{
        //    if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
        //        (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
        //    {
        //        return (
        //            autoAnsItemSt.CustomerCode == customerCode
        //                &&
        //            autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
        //                &&
        //            autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
        //                &&
        //            autoAnsItemSt.GoodsMakerCd == 0
        //        );
        //    }
        //    return false;
        //}
        #endregion
        // DEL 2012/11/20 2012/12/12配信予定 システムテスト障害№47対応 ---------------------<<<<<

        // ADD 2012/11/30 2012/12/12配信予定 システムテスト障害№91対応 --------------------->>>>>
        /// <summary>
        /// 優先順位2:得意先＋中分類（共通）＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>
        /// <c>true</c> :優先順位2です。<br/>
        /// <c>false</c>:優先順位2ではありません。
        /// </returns>
        private static bool IsPriority2(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData, int customerCode)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd

                );
            }
            return false;
        }
        // ADD 2012/11/30 2012/12/12配信予定 システムテスト障害№91対応 ---------------------<<<<<

        /// <summary>
        /// 優先順位3:得意先＋中分類＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>
        /// <c>true</c> :優先順位3です。<br/>
        /// <c>false</c>:優先順位3ではありません。
        /// </returns>
        private static bool IsPriority3(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData, int customerCode)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 優先順位4:得意先＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>
        /// <c>true</c> :優先順位4です。<br/>
        /// <c>false</c>:優先順位4ではありません。
        /// </returns>
        private static bool IsPriority4(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData, int customerCode)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 優先順位5:拠点＋中分類＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :優先順位5です。<br/>
        /// <c>false</c>:優先順位5ではありません。
        /// </returns>
        private static bool IsPriority5(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                // UPD 2012/11/20 2012/12/12配信予定 システムテスト障害№47対応 --------------------->>>>>
                //return (
                //    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                //        &&
                //    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                //);
                // UPD 2012/11/30 2012/12/12配信予定 システムテスト障害№91対応 --------------------->>>>>
                //return (
                //    (autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                //        &&
                //    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd) ||

                //    (autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                //        &&
                //    autoAnsItemSt.GoodsMGroup == 0
                //        &&
                //    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                //        &&
                //    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd)

                //);
                return (
                    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
                // UPD 2012/11/30 2012/12/12配信予定 システムテスト障害№91対応 ---------------------<<<<<
                // UPD 2012/11/20 2012/12/12配信予定 システムテスト障害№47対応 ---------------------<<<<<
            }
            return false;
        }

        // DEL 2012/11/20 2012/12/12配信予定 システムテスト障害№47対応 --------------------->>>>>
        #region 削除
        ///// <summary>
        ///// 優先順位6:拠点＋中分類＋BLコードであるか判断します。
        ///// </summary>
        ///// <param name="AutoAnsItemSt">自動回答品目設定</param>
        ///// <param name="AutoAnsItemStOrder">自動回答品目設定条件</param>
        ///// <returns>
        ///// <c>true</c> :優先順位6です。<br/>
        ///// <c>false</c>:優先順位6ではありません。
        ///// </returns>
        //private static bool IsPriority6(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        //{
        //    if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
        //        (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
        //    {
        //        return (
        //            autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
        //                &&
        //            autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
        //                &&
        //            autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
        //                &&
        //            autoAnsItemSt.GoodsMakerCd == 0
        //        );
        //    }
        //    return false;
        //}
        #endregion
        // DEL 2012/11/20 2012/12/12配信予定 システムテスト障害№47対応 ---------------------<<<<<

        // ADD 2012/11/30 2012/12/12配信予定 システムテスト障害№91対応 --------------------->>>>>
        /// <summary>
        /// 優先順位6:拠点＋中分類（共通）＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :優先順位6です。<br/>
        /// <c>false</c>:優先順位6ではありません。
        /// </returns>
        private static bool IsPriority6(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == goodsUnitData.BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd

                );
            }
            return false;
        }
        // ADD 2012/11/30 2012/12/12配信予定 システムテスト障害№91対応 ---------------------<<<<<

        /// <summary>
        /// 優先順位7:拠点＋中分類であるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :優先順位7です。<br/>
        /// <c>false</c>:優先順位7ではありません。
        /// </returns>
        private static bool IsPriority7(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == goodsUnitData.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 優先順位8:拠点であるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :優先順位8です。<br/>
        /// <c>false</c>:優先順位8ではありません。
        /// </returns>
        private static bool IsPriority8(AutoAnsItemSt autoAnsItemSt, GoodsUnitData goodsUnitData)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == goodsUnitData.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == goodsUnitData.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                );
            }
            return false;
        }

        #endregion // 優先順位の判断

        // ADD 2014/06/06 商品保証課Redmine#1581対応 --------------------------------------------------------->>>>>
        /// <summary>
        /// 自動回答品目設定キャッシュリストをクリアします。
        /// </summary>
        /// <returns></returns> 
        public void Clear()
        {
            if (FoundRecordMap != null && FoundRecordMap.Count != 0)
            {
                FoundRecordMap.Clear();
            }
            return;
        }
        // ADD 2014/06/06 商品保証課Redmine#1581対応 ---------------------------------------------------------<<<<<

        // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 自動回答品目設定を取得します。
        /// </summary>
        /// <param name="epCd">企業コード</param>
        /// <param name="secCd">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>自動回答品目設定リスト</returns>
        public RecordType Search(string epCd, string secCd, int customerCode)
        {
            string key = epCd.Trim() + secCd.Trim() + customerCode.ToString().Trim();
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            // 1パラ目
            AutoAnsItemStOrder searchingCondition = new AutoAnsItemStOrder();
            {
                // 企業コード
                searchingCondition.EnterpriseCode = epCd;

                // 拠点コード
                searchingCondition.SectionCode = secCd;

                // 得意先コード
                searchingCondition.St_CustomerCode = customerCode;
                searchingCondition.Ed_CustomerCode = customerCode;

                // 商品中分類コード
                searchingCondition.St_GoodsMGroup = 0;
                searchingCondition.Ed_GoodsMGroup = int.MaxValue;

                // BL商品コード
                searchingCondition.St_BLGoodsCode = 0;
                searchingCondition.Ed_BLGoodsCode = int.MaxValue;

                // 商品メーカーコード
                searchingCondition.St_GoodsMakerCd = 0;
                searchingCondition.Ed_GoodsMakerCd = int.MaxValue;

                // BLグループコード
                searchingCondition.St_BLGroupCode = 0;
                searchingCondition.Ed_BLGroupCode = int.MaxValue;
            }

            // 2パラ目
            List<AutoAnsItemSt> searchedList = null;

            // 3パラ目
            string msg = string.Empty;

            // 検索
            RealAccesser.EnterpriseCode = epCd;
            RealAccesser.SectionCode = secCd;
            int status = RealAccesser.SearchAll(searchingCondition, out searchedList, out msg);
            if (searchedList == null && customerCode > 0)
            {
                // 得意先コードで検索していた場合、拠点コードで再検索
                searchingCondition.St_CustomerCode = 0;
                searchingCondition.Ed_CustomerCode = 0;
                searchingCondition.SectionCode = secCd;
                status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            }

            FoundRecordMap.Add(key, searchedList ?? new List<AutoAnsItemSt>());

            return searchedList ?? new List<AutoAnsItemSt>();
        }

        // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化） --------->>>>>
        /// <summary>
        /// 自動回答品目設定検索条件文字列生成
        /// </summary>
        /// <param name="searchingCondition">検索条件</param>
        /// <returns>検索条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定検索条件文字列生成処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/05/15</br>
        /// </remarks>
        public string GetOrderSearchCondition(AutoAnsItemStOrder searchingCondition)
        {
            string carString = string.Empty;
            try
            {
                carString = LinkBreak + "EnterpriseCode:" + searchingCondition.EnterpriseCode.ToString() + LinkBreak
                     + "St_BLGoodsCode:" + searchingCondition.St_BLGoodsCode.ToString() + LinkBreak
                     + "Ed_BLGoodsCode:" + searchingCondition.Ed_BLGoodsCode.ToString() + LinkBreak
                     + "St_BLGroupCode:" + searchingCondition.St_BLGroupCode.ToString() + LinkBreak
                     + "Ed_BLGroupCode" + searchingCondition.Ed_BLGroupCode.ToString() + LinkBreak
                     + "St_CustomerCode:" + searchingCondition.St_CustomerCode.ToString() + LinkBreak
                     + "Ed_CustomerCode:" + searchingCondition.Ed_CustomerCode.ToString();
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
