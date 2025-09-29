//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 問合せ一覧/受注検索ウィンドウ
// プログラム概要   : 問合せ一覧アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/04/16  修正内容 : キャンセル対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/04/23  修正内容 : 明細表示を行うとＳＦで入力した明細順番と逆順で表示される
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/06/17  修正内容 : キャンセル追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024 佐々木 健
// 作 成 日  2010/02/09  修正内容 : ＰＭ側で行追加した明細を表示できるように修正
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : qijh
// 作 成 日  2013/02/27  修正内容 : 2013/06/18配信 Redmine#34752 「PMSCMのNo.10385」BLPの対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    using SearchedResultPair = KeyValuePair<List<SCMInquiryDtlInqResultWork>, List<SCMInquiryDtlAnsResultWork>>;

    /// <summary>
    /// 問合せ・発注種別列挙型
    /// </summary>
    internal enum InqOrdDivCd : int
    {
        /// <summary>1:問合せ</summary>
        Inquiry = 1,
        /// <summary>2:発注</summary>
        Ordering = 2
    }

    /// <summary>
    /// 回答区分列挙型
    /// </summary>
    public enum AnswerDivCd : int
    {
        /// <summary>0:アクションなし</summary>
        NoAction = 0,
        /// <summary>10:一部回答</summary>
        PartAnswer = 10,
        /// <summary>20:回答完了</summary>
        AnswerCompletion = 20,
        /// <summary>30:承認</summary>
        Approval = 30,
        /// <summary>99:キャンセル</summary>
        Cancel = 99
    }

    /// <summary>
    /// 受注ステータス
    /// </summary>
    internal enum AcptAnOdrStatusState : int
    {
        /// <summary>見積</summary>
        Estimate = 10,
        /// <summary>単価見積</summary>
        UnitPriceEstimate = 15,
        /// <summary>検索見積</summary>
        SearchEstimate = 16,
        /// <summary>受注</summary>
        AcceptAnOrder = 20,
        /// <summary>売上</summary>
        Sales = 30,
        /// <summary>貸出</summary>
        Shipment = 40,
    }

    // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
    /// <summary>
    /// キャンセル状態区分
    /// </summary>
    public enum CancelCndtinDiv : short
    {
        /// <summary>0:キャンセルなし</summary>
        None = 0,
        /// <summary>10:キャンセル要求</summary>
        Cancelling = 10,
        /// <summary>20:キャンセル却下</summary>
        Rejected = 20,
        /// <summary>30:キャンセル確定</summary>
        Cancelled = 30
    }
    // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

    /// <summary>
    /// SCM受注系データアクセスの代理人クラス
    /// </summary>
    public sealed class SCMInquiryDBAgent
    {
        #region 本物のアクセサ

        /// <summary>本物のアクセサ</summary>
        private readonly ISCMInquiryDB _realAccesser = (ISCMInquiryDB)MediationSCMInquiryResultDB.GetSCMInquiryDB();
        /// <summary>本物のアクセサを取得します。</summary>
        internal ISCMInquiryDB RealAccesser { get { return _realAccesser; } }

        #endregion // 本物のアクセサ

        #region キャンセル処理

        // 2011/02/14 Del >>>
        ///// <summary>キャンセル処理</summary>
        //private readonly SCMCanceler _canceler;
        ///// <summary>キャンセル処理を取得します。</summary>
        //public SCMCanceler Canceler { get { return _canceler; } }
        // 2011/02/14 Del <<<

        #endregion // キャンセル処理

        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMInquiryDBAgent()
        {
            // 2011/02/14 >>>
            //_canceler = new SCMCanceler(this);
            // 2011/02/14 <<<
        }
        
        #endregion // Constructor

        #region SCM受注データ

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="scmInquiryResultWork">検索結果</param>
        /// <param name="scmInquiryOrderWork">検索条件</param>
        /// <param name="readMode">読込モード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>結果ステータス</returns>
        public int Search(
            out object scmInquiryResultWork,    // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryResultWork>>
            object scmInquiryOrderWork,         // SCMInquiryOrderWork
            int readMode,
            ConstantManagement.LogicalMode logicalMode
        )
        {
            // 2011/02/14 >>>
            //Canceler.ClearEntry((SCMInquiryOrderWork)scmInquiryOrderWork);
            // 2011/02/14 <<<
            return RealAccesser.Search(out scmInquiryResultWork, scmInquiryOrderWork, readMode, logicalMode);
        }

        #endregion // SCM受注データ

        #region SCM受注明細データ(問合せ・発注)／SCM受注明細データ(回答)

        /// <summary>
        /// 明細情報を検索します。
        /// </summary>
        /// <param name="scmInquiryResultWork">明細情報</param>
        /// <param name="objscmInquiryResultWork">検索条件</param>
        /// <param name="readMode">読込モード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>結果ステータス</returns>
        public int SearchDetail(
            out object scmInquiryResultWork,// CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlAnsResultWork または SCMInquiryDtlInqResultWork>>
            object objscmInquiryResultWork, // SCMInquiryResultWork
            int readMode,
            ConstantManagement.LogicalMode logicalMode
        )
        {
            return RealAccesser.SearchDetail(out scmInquiryResultWork, objscmInquiryResultWork, readMode, logicalMode);
        }

        /// <summary>
        /// 1つの伝票であるか判断します。
        /// </summary>
        /// <param name="header">ヘッダデータ</param>
        /// <returns>
        /// <c>true</c> :1つの伝票または伝票は登録されていません。<br/>
        /// <c>false</c>:複数の伝票です。
        /// </returns>
        public bool IsOneSlip(SCMInquiryResultWork header)
        {
            object detailData = null;   // 1パラ目
            SCMInquiryResultWork searchingCondition = ConvertSearchingDetailCondition(header);  // 2パラ目

            int status = SearchDetail(out detailData, searchingCondition, 0, ConstantManagement.LogicalMode.GetData0);

            CustomSerializeArrayList searchedDetailList = detailData as CustomSerializeArrayList;
            if (searchedDetailList == null) return true;

            string salesSlipNum = header.SalesSlipNum;
            foreach (CustomSerializeArrayList detailList in searchedDetailList)
            {
                foreach (object detail in detailList)
                {
                    string detailSalesSlipNum = GetSalesSlipNum(detail);
                    // 未回答のデータは伝票番号がないので、無視
                    if (string.IsNullOrEmpty(detailSalesSlipNum)) continue;
                    // 伝票番号が変化したので、複数伝票
                    if (!detailSalesSlipNum.Equals(salesSlipNum)) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ヘッダデータを明細データの検索条件に変換します。
        /// </summary>
        /// <param name="header">ヘッダデータ</param>
        /// <returns>明細データの検索条件</returns>
        private static SCMInquiryResultWork ConvertSearchingDetailCondition(SCMInquiryResultWork header)
        {
            SCMInquiryResultWork searchingCondition = new SCMInquiryResultWork();
            {
                searchingCondition.AcptAnOdrStatus = header.AcptAnOdrStatus;
                searchingCondition.AnswerDivCd = header.AnswerDivCd;
                searchingCondition.EnterpriseCode = header.EnterpriseCode;
                searchingCondition.InqOrdDivCd = header.InqOrdDivCd;
                searchingCondition.InqOriginalEpCd = header.InqOtherEpCd.Trim();//@@@@20230303
                searchingCondition.InqOriginalSecCd = header.InqOriginalSecCd;
                searchingCondition.InqOtherEpCd = header.InqOtherEpCd;
                searchingCondition.InqOtherSecCd = header.InqOtherSecCd;
                searchingCondition.InquiryNumber = header.InquiryNumber;
                searchingCondition.UpdateDate = header.UpdateDate;
                searchingCondition.UpdateTime = header.UpdateTime;
                // FIXME:明細データの検索条件に伝票番号は必要？
                searchingCondition.SalesSlipNum = header.SalesSlipNum;
            }
            return searchingCondition;
        }

        /// <summary>
        /// 明細情報を検索します。
        /// </summary>
        /// <param name="scmInquiryResultWork">明細情報</param>
        /// <param name="scmInquiryResultWorkCancel">明細情報(キャンセル分)</param>
        /// <param name="objscmInquiryResultWork">検索条件</param>
        /// <param name="readMode">読込モード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>結果ステータス</returns>
        public int SearchDetailAll(
            out object scmInquiryResultWork,        // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlAnsResultWork または SCMInquiryDtlInqResultWork>>
            out object scmInquiryResultWorkCancel,  // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlAnsResultWork または SCMInquiryDtlInqResultWork>>
            object objscmInquiryResultWork, // SCMInquiryResultWork
            int readMode,
            ConstantManagement.LogicalMode logicalMode
        )
        {
            return RealAccesser.SearchDetailAll(
                out scmInquiryResultWork,
                out scmInquiryResultWorkCancel,
                objscmInquiryResultWork,
                readMode,
                logicalMode
            );
        }

        #endregion // SCM受注明細データ(問合せ・発注)／SCM受注明細データ(回答)

        #region 対象件数

        /// <summary>
        /// 対象件数を検索します。
        /// </summary>
        /// <param name="readCnt">対象件数</param>
        /// <param name="objscmInquiryOrderWork">検索条件</param>
        /// <returns>結果ステータス</returns>
        public int SearchCnt(
            out int readCnt,
            object objscmInquiryOrderWork
        )
        {
            return RealAccesser.SearchCnt(out readCnt, objscmInquiryOrderWork);
        }

        #endregion // 対象件数

        /// <summary>
        /// 売上伝票番号を取得します。
        /// </summary>
        /// <param name="data">ヘッダデータまたは明細データ</param>
        /// <returns>SalesSlipNumプロパティを返します。</returns>
        private static string GetSalesSlipNum(object data)
        {
            if (data is SCMInquiryResultWork) return ((SCMInquiryResultWork)data).SalesSlipNum;
            if (data is SCMInquiryDtlInqResultWork) return ((SCMInquiryDtlInqResultWork)data).SalesSlipNum;
            if (data is SCMInquiryDtlAnsResultWork) return ((SCMInquiryDtlAnsResultWork)data).SalesSlipNum;
            return string.Empty;
        }

        /// <summary>
        /// 回答区分の名称を取得します。
        /// </summary>
        /// <param name="answerDivCd">回答区分</param>
        /// <returns>該当する回答区分の名称</returns>
        public static string GetAnswerDivCdName(int answerDivCd)
        {
            if (answerDivCd.Equals((int)AnswerDivCd.NoAction)) return "未回答";
            if (answerDivCd.Equals((int)AnswerDivCd.PartAnswer)) return "一部回答";
            if (answerDivCd.Equals((int)AnswerDivCd.AnswerCompletion)) return "回答完了";
            if (answerDivCd.Equals((int)AnswerDivCd.Approval)) return "承認";
            if (answerDivCd.Equals((int)AnswerDivCd.Cancel)) return "キャンセル";
            return string.Empty;
        }

        /// <summary>
        /// 伝票名称を取得します。
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <returns>該当する伝票名称</returns>
        public static string GetSlipName(int acptAnOdrStatus)
        {
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.Estimate)) return "見積";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.UnitPriceEstimate)) return "単価見積";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.SearchEstimate)) return "検索見積";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.AcceptAnOrder)) return "受注";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.Sales)) return "売上";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.Shipment)) return "貸出";
            return string.Empty;
        }

        // ADD 2010/04/23 明細表示を行うとＳＦで入力した明細順番と逆順で表示される ---------->>>>>
        /// <summary>
        /// 明細データの検索結果を合成します。
        /// </summary>
        /// <param name="searchedDetailResult">明細データの検索結果</param>
        /// <returns>回答データ + 回答データに含まれない(明細データ)のリスト</returns>
        // 2011/02/14 >>>
        //public static SortedList<string, object> JoinSearchedDetailResult(CustomSerializeArrayList searchedDetailResult)
        public static SortedList<string, object> JoinSearchedDetailResult(SCMInquiryResultWork condition, CustomSerializeArrayList searchedDetailResult, CustomSerializeArrayList searchedDetailResultCancel)
        // 2011/02/14 <<<
        {
            SortedList<string, object> joinList = new SortedList<string, object>();
            {
                // 2011/02/14 >>>
#if False
                SearchedResultPair searchedResult = SCMSearchedResultState.SplitSearchedResult(searchedDetailResult);
                // 回答データが存在する場合、回答データを優先的に設定
                if (searchedResult.Value.Count > 0)
                {
                #region 回答データのみ

                    if (searchedResult.Key.Count.Equals(0))
                    {
                        // 回答データのみの場合
                        searchedResult.Value.ForEach(delegate(SCMInquiryDtlAnsResultWork ans)
                        {
                            joinList.Add(GetResultSortKey(ans), ans);

                        });
                        return joinList;
                    }

                    #endregion // 回答データのみ

                    // 明細データと回答データが混在している場合
                    searchedResult.Key.ForEach(delegate(SCMInquiryDtlInqResultWork inq)
                    {
                        int ansIndex = searchedResult.Value.FindIndex(delegate(SCMInquiryDtlAnsResultWork ans)
                        {
                            // リモートの検索結果を前提としているので、問合せ行番号と問合せ行番号枝番のみの比較
                            return SCMSearchedResultState.IsParenthood(ans, inq);
                        });
                        if (ansIndex >= 0)
                        {
                            joinList.Add(GetResultSortKey(searchedResult.Value[ansIndex]), searchedResult.Value[ansIndex]);
                        }
                        else
                        {
                            joinList.Add(GetDetailSortKey(inq), inq);
                        }
                    });

                    return joinList;
                }

                #region 明細データのみ

                // 明細データのみの場合
                searchedResult.Key.ForEach(delegate(SCMInquiryDtlInqResultWork inq)
                {
                    joinList.Add(GetDetailSortKey(inq), inq);
                });

                #endregion // 明細データのみ
#endif
                List<SCMInquiryDtlInqResultWork> inqListAll = new List<SCMInquiryDtlInqResultWork>();
                List<SCMInquiryDtlAnsResultWork> ansListAll = new List<SCMInquiryDtlAnsResultWork>();

                // 問合せ分を分割
                CustomSerializeArrayList inqList = null;
                CustomSerializeArrayList ansList = null;
                SplitSearchedResult(searchedDetailResult, out inqList, out ansList);

                // キャンセル分を分割
                CustomSerializeArrayList inqList2 = null;
                CustomSerializeArrayList ansList2 = null;
                SplitSearchedResult(searchedDetailResultCancel, out inqList2, out ansList2);

                if (condition.AnswerDivCd != (int)AnswerDivCd.Cancel)
                {
                    if (inqList != null && inqList.Count > 0)
                    {
                        foreach (SCMInquiryDtlInqResultWork inq in inqList)
                        {
                            inqListAll.Add(inq);
                        }
                    }
                }
                else
                {
                    if (inqList2 != null && inqList2.Count > 0)
                    {
                        foreach (SCMInquiryDtlInqResultWork inq in inqList2)
                        {
                            inqListAll.Add(inq);
                        }
                    }
                }

                if (condition.AnswerDivCd != (int)AnswerDivCd.Cancel)
                {
                    if (ansList != null && ansList.Count > 0)
                    {
                        foreach (SCMInquiryDtlAnsResultWork ans in ansList)
                        {
                            if (ans.CancelCndtinDiv != (int)CancelCndtinDiv.None)
                            {
                                continue;
                            }
                            ansListAll.Add(ans);
                        }
                    }
                }
                else
                {
                    // このリストは実際入ってこない...
                    if (ansList2 != null && ansList2.Count > 0)
                    {
                        foreach (SCMInquiryDtlAnsResultWork ans in ansList2)
                        {
                            ansListAll.Add(ans);
                        }
                    }
                    // この時点で、通常とキャンセルの全明細のリストが生成される
                }

                // 問合せを行番号昇順、、更新日付・更新時間降順にソート
                inqListAll.Sort(new InqCompare());
                // 回答を行番号昇順、受注ステータス、更新日付・更新時間降順にソート
                ansListAll.Sort(new AnsCompare());


                // 先に問合せ明細からリストを生成
                foreach (SCMInquiryDtlInqResultWork inq in inqListAll)
                {
                    string key = GetDetailSortKey(inq);
                    if (joinList.ContainsKey(key)) continue;
                    joinList.Add(key, inq);
                }

                // 回答からリストを更新
                foreach (SCMInquiryDtlAnsResultWork ans in ansListAll)
                {
                    string key = GetResultSortKey(ans);

                    if (joinList.ContainsKey(key))
                    {
                        if (joinList[key] is SCMInquiryDtlInqResultWork)
                        {
                            SCMInquiryDtlInqResultWork inq = (SCMInquiryDtlInqResultWork)joinList[key];
                            if (( ans.UpdateDate > inq.UpdateDate ) ||
                                ( ( ans.UpdateDate == inq.UpdateDate ) && ( ans.UpdateTime >= inq.UpdateTime ) )
                                )
                            {
                                joinList[key] = ans;
                            }
                        }
                        // ------------ ADD START 2013/02/27 qijh #34752 ---------- >>>>>>
                        else
                        {
                            SCMInquiryDtlAnsResultWork sCMInquiryDtlAnsResultWork = (SCMInquiryDtlAnsResultWork)joinList[key];
                            if (sCMInquiryDtlAnsResultWork.InqRowNumber == ans.InqRowNumber &&
                                sCMInquiryDtlAnsResultWork.InqRowNumDerivedNo == ans.InqRowNumDerivedNo)
                            {
                                // PM主管現在個数 
                                sCMInquiryDtlAnsResultWork.PmMainMngPrsntCount = ans.PmMainMngPrsntCount;
                                // PM主管棚番
                                sCMInquiryDtlAnsResultWork.PmMainMngShelfNo = ans.PmMainMngShelfNo;
                                // PM主管倉庫コード
                                sCMInquiryDtlAnsResultWork.PmMainMngWarehouseCd = ans.PmMainMngWarehouseCd;
                                // PM主管倉庫名称
                                sCMInquiryDtlAnsResultWork.PmMainMngWarehouseName = ans.PmMainMngWarehouseName;
                                joinList[key] = sCMInquiryDtlAnsResultWork;
                            }
                        }
                        // ------------ ADD END 2013/02/27 qijh #34752 ---------- <<<<<<
                    }
                    else
                    {
                        joinList.Add(key, ans);
                    }
                }
                // 2011/02/14 <<<
            }
            return joinList;

        }

        // 2011/02/14 Add >>>
        /// <summary>
        /// 問合せ明細データをソートします。(問合せ行番号、問合せ行番号枝番の昇順、更新日付、更新時間は降順）
        /// </summary>
        private class InqCompare : Comparer<SCMInquiryDtlInqResultWork>
        {
            public override int Compare(SCMInquiryDtlInqResultWork x, SCMInquiryDtlInqResultWork y)
            {
                int result = x.InqRowNumber.CompareTo(y.InqRowNumber);
                if (result != 0) return result;

                result = x.InqRowNumDerivedNo.CompareTo(y.InqRowNumDerivedNo);
                if (result != 0) return result;

                result = y.UpdateDate.CompareTo(x.UpdateDate);
                if (result != 0) return result;

                result = y.UpdateTime.CompareTo(x.UpdateTime);
                if (result != 0) return result;

                return result;
            }
        }

        /// <summary>
        /// 回答明細データをソートします。(問合せ行番号、問合せ行番号枝番の昇順、受注ステータス、更新日付、更新時間は降順）
        /// </summary>
        private class AnsCompare : Comparer<SCMInquiryDtlAnsResultWork>
        {
            public override int Compare(SCMInquiryDtlAnsResultWork x, SCMInquiryDtlAnsResultWork y)
            {
                int result = x.InqRowNumber.CompareTo(y.InqRowNumber);
                if (result != 0) return result;

                result = x.InqRowNumDerivedNo.CompareTo(y.InqRowNumDerivedNo);
                if (result != 0) return result;

                result = y.AcptAnOdrStatus.CompareTo(x.AcptAnOdrStatus);
                if (result != 0) return result;


                result = y.UpdateDate.CompareTo(x.UpdateDate);
                if (result != 0) return result;

                result = y.UpdateTime.CompareTo(x.UpdateTime);
                if (result != 0) return result;
                return result;
            }
        }

        /// <summary>
        /// 検索結果の分割処理
        /// </summary>
        /// <param name="inqList"></param>
        /// <param name="cancelList"></param>
        internal  static void SplitSearchedResult(CustomSerializeArrayList searchedList, out CustomSerializeArrayList inqList, out CustomSerializeArrayList answerList)
        {
            inqList = null;
            answerList = null;
            if (searchedList == null) return;
            for (int index = 0; index < searchedList.Count; index++)
            {
                if (( (CustomSerializeArrayList)searchedList[index] ).Count > 0)
                {
                    if (( (CustomSerializeArrayList)searchedList[index] )[0] is SCMInquiryDtlInqResultWork)
                    {
                        inqList = (CustomSerializeArrayList)searchedList[index];
                    }
                    else if (( (CustomSerializeArrayList)searchedList[index] )[0] is SCMInquiryDtlAnsResultWork)
                    {
                        answerList = (CustomSerializeArrayList)searchedList[index];
                    }
                }
            }
        }
        // 2011/02/14 Add <<<


        /// <summary>
        /// 明細データの検索結果のソートキーを取得します。
        /// </summary>
        /// <param name="ans">検索結果の回答データ</param>
        /// <returns>問合せ行番号("00") + 問合せ行番号枝番("00")</returns>
        private static string GetResultSortKey(SCMInquiryDtlAnsResultWork ans)
        {
            return ans.InqRowNumber.ToString("d2") + ans.InqRowNumDerivedNo.ToString("d2");
        }

        /// <summary>
        /// 明細データの検索結果のソートキーを取得します。
        /// </summary>
        /// <param name="inq">検索結果の明細データ</param>
        /// <returns>問合せ行番号("00") + 問合せ行番号枝番("00")</returns>
        private static string GetDetailSortKey(SCMInquiryDtlInqResultWork inq)
        {
            return inq.InqRowNumber.ToString("d2") + inq.InqRowNumDerivedNo.ToString("d2");
        }
        // ADD 2010/04/23 明細表示を行うとＳＦで入力した明細順番と逆順で表示される ----------<<<<<
        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
        /// <summary>
        /// キャンセル状態区分の名称を取得します。
        /// </summary>
        /// <param name="cancelCndtinDiv">キャンセル状態区分</param>
        /// <returns>
        /// <c>0</c> :""
        /// <c>10</c>:"キャンセル要求"
        /// <c>20</c>:"キャンセル拒否"
        /// <c>30</c>:"キャンセル受付"
        /// </returns>
        public static string GetCancelCndtinDivName(short cancelCndtinDiv)
        {
            switch (cancelCndtinDiv)
            {
                case (short)CancelCndtinDiv.Cancelling:
                    return "キャンセル要求";
                case (short)CancelCndtinDiv.Rejected:
                    return "キャンセル拒否";
                case (short)CancelCndtinDiv.Cancelled:
                    return "キャンセル受付";
                default:
                    return string.Empty;
            }
        }
        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
    }
}
