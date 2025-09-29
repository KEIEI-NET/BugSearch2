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
using System;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    using SearchedResultPair = KeyValuePair<List<SCMInquiryDtlInqResultWork>, List<SCMInquiryDtlAnsResultWork>>;

    /// <summary>
    /// SCM受注データの検索結果の状態クラス
    /// </summary>
    public abstract class SCMSearchedResultState
    {
        #region 検索条件

        /// <summary>問合せ番号</summary>
        private readonly long _inquiryNumber;
        /// <summary>問合せ番号を取得します。</summary>
        protected long InquiryNumber { get { return _inquiryNumber; } }

        /// <summary>回答区分</summary>
        private readonly int _answerDivCode;
        /// <summary>回答区分を取得します。</summary>
        protected int AnswerDivCode { get { return _answerDivCode; } }

        #endregion // 検索条件

        #region 検索結果

        /// <summary>明細データの検索結果</summary>
        private readonly CustomSerializeArrayList _searchedDetailList;
        /// <summary>明細データの検索結果を取得します。</summary>
        protected CustomSerializeArrayList SearchedDetailList { get { return _searchedDetailList; } } 

        /// <summary>キャンセル明細データの検索結果</summary>
        private readonly CustomSerializeArrayList _searchedCancelList;
        /// <summary>キャンセル明細データの検索結果を取得します。</summary>
        protected CustomSerializeArrayList SearchedCancelList { get { return _searchedCancelList; } }

        #endregion // 検索結果

        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <param name="answerDivCd">回答区分</param>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <param name="searchedCancelList">キャンセル明細データの検索結果</param>
        protected SCMSearchedResultState(
            long inquiryNumber,
            int answerDivCd,
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            _inquiryNumber = inquiryNumber;
            _answerDivCode = answerDivCd;
            _searchedDetailList = searchedDetailList;
            _searchedCancelList = searchedCancelList;
        }

        #endregion // Constructor

        /// <summary>
        /// 売上伝票入力が可能であるか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :売上伝票入力が可能です。<br/>
        /// <c>false</c>:売上伝票入力が付加です。
        /// </returns>
        public abstract bool CanInputSalesSlip();

        /// <summary>
        /// 回答区分が「回答完了」であるか判断します。
        /// </summary>
        /// <param name="answerDivCd">回答区分</param>
        /// <returns>
        /// <c>true</c> :「回答完了」です。<br/>
        /// <c>false</c>:「回答完了」ではありません。
        /// </returns>
        public static bool IsAnswerCompletion(int answerDivCd)
        {
            return answerDivCd.Equals((int)AnswerDivCd.AnswerCompletion);
        }

        /// <summary>
        /// 回答区分が「キャンセル」であるか判断します。
        /// </summary>
        /// <param name="answerDivCd">回答区分</param>
        /// <returns>
        /// <c>true</c> :「キャンセル」です。<br/>
        /// <c>false</c>:「キャンセル」ではありません。
        /// </returns>
        public static bool IsCancel(int answerDivCd)
        {
            return answerDivCd.Equals((int)AnswerDivCd.Cancel);
        }

        /// <summary>
        /// 問合せ。発注種別が「発注」であるか判断します。
        /// </summary>
        /// <param name="inqOrdDivCd">問合せ・発注種別</param>
        /// <returns>
        /// <c>true</c> :「発注」です。<br/>
        /// <c>false</c>:「発注」ではありません。
        /// </returns>
        protected static bool IsOrdering(int inqOrdDivCd)
        {
            return inqOrdDivCd.Equals((int)InqOrdDivCd.Ordering);
        }

        /// <summary>
        /// 明細データが存在するか判断します。
        /// </summary>
        /// <param name="searchedResultList">明細データ(キャンセル明細データ)の検索結果</param>
        /// <returns>
        /// <c>true</c> :明細データが存在します。<br/>
        /// <c>false</c>:明細データが存在しません。
        /// </returns>
        protected static bool ExistsDetailData(CustomSerializeArrayList searchedResultList)
        {
            // searchedDetailList:CustomSerializeArrayList
            // ├[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>…明細データ（問合せ・発注）
            // └[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>…明細データ（回答）

            if (searchedResultList == null || searchedResultList.Count.Equals(0)) return false;

            return true;
        }

        /// <summary>
        /// 回答データが存在するか判断します。
        /// </summary>
        /// <param name="searchedResultList">明細データ(キャンセル明細データ)の検索結果</param>
        /// <returns>
        /// <c>true</c> :回答データが存在します。<br/>
        /// <c>false</c>:回答データが存在しません。
        /// </returns>
        protected static bool ExistsAnswerData(CustomSerializeArrayList searchedResultList)
        {
            // searchedDetailList:CustomSerializeArrayList
            // ├[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>…明細データ（問合せ・発注）
            // └[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>…明細データ（回答）

            if (searchedResultList == null || searchedResultList.Count < 2) return false;

            return true;
        }

        #region 対応するかの判定

        /// <summary>
        /// 対応するか判定します。
        /// </summary>
        /// <param name="ans">検索結果の回答データ</param>
        /// <param name="inq">検索結果の明細データ</param>
        /// <returns>
        /// ※リモートの検索結果を前提としてるため、問合せ行番号と問合せ行番号枝番の比較のみです・
        /// <c>true</c> :対応します。<br/>
        /// <c>false</c>:対応しません。
        /// </returns>
        internal static bool IsParenthood(
            SCMInquiryDtlAnsResultWork ans,
            SCMInquiryDtlInqResultWork inq
        )
        {
            // 2011/01/11 >>>
            //return ans.InqRowNumber.Equals(inq.InqRowNumber) && ans.InqRowNumDerivedNo.Equals(inq.InqRowNumDerivedNo);
            if (ans.InqRowNumber.Equals(inq.InqRowNumber) && ans.InqRowNumDerivedNo.Equals(inq.InqRowNumDerivedNo))
            {
                if (ans.UpdateDate > inq.UpdateDate)
                {
                    return true;
                }
                else if (ans.UpdateDate == inq.UpdateDate)
                {
                    return ( ans.UpdateTime > inq.UpdateTime );
                }
            }
            return false;
            // 2011/01/11 <<<
        }

        /// <summary>
        /// 対応するか判定します。
        /// </summary>
        /// <param name="inq">検索結果の明細データ</param>
        /// <param name="ans">検索結果の回答データ</param>
        /// <returns>
        /// ※リモートの検索結果を前提としてるため、問合せ行番号と問合せ行番号枝番の比較のみです・
        /// <c>true</c> :対応します。<br/>
        /// <c>false</c>:対応しません。
        /// </returns>
        internal static bool IsParenthood(
            SCMInquiryDtlInqResultWork inq,
            SCMInquiryDtlAnsResultWork ans
        )
        {
            return IsParenthood(ans, inq);
        }

        /// <summary>
        /// 対応するか判定します。
        /// </summary>
        /// <param name="lhs">検索結果の明細データ</param>
        /// <param name="rhs">検索結果の明細データ</param>
        /// <returns>
        /// ※リモートの検索結果を前提としてるため、問合せ行番号と問合せ行番号枝番の比較のみです・
        /// <c>true</c> :対応します。<br/>
        /// <c>false</c>:対応しません。
        /// </returns>
        protected static bool IsParenthood(
            SCMInquiryDtlInqResultWork lhs,
            SCMInquiryDtlInqResultWork rhs
        )
        {
            return lhs.InqRowNumber.Equals(rhs.InqRowNumber) && lhs.InqRowNumDerivedNo.Equals(rhs.InqRowNumDerivedNo);
        }

        /// <summary>
        /// 対応するか判定します。
        /// </summary>
        /// <param name="lhs">検索結果の回答データ</param>
        /// <param name="rhs">検索結果の回答データ</param>
        /// <returns>
        /// ※リモートの検索結果を前提としてるため、問合せ行番号と問合せ行番号枝番の比較のみです・
        /// <c>true</c> :対応します。<br/>
        /// <c>false</c>:対応しません。
        /// </returns>
        protected static bool IsParenthood(
            SCMInquiryDtlAnsResultWork lhs,
            SCMInquiryDtlAnsResultWork rhs
        )
        {
            return lhs.InqRowNumber.Equals(rhs.InqRowNumber) && lhs.InqRowNumDerivedNo.Equals(rhs.InqRowNumDerivedNo);
        }

        #endregion // 対応するかの判定

        /// <summary>
        /// 明細データ(キャンセル明細データ)に対して回答データが全て存在するか判断します。
        /// </summary>
        /// <param name="searchedResultList">明細データ(キャンセル明細データ)の検索結果</param>
        /// <returns>
        /// <c>true</c> :明細データ(キャンセル明細データ)に対して回答データが全て存在します。<br/>
        /// <c>false</c>:未回答の明細データ(キャンセル明細データ)が存在します。
        /// </returns>
        protected static bool ExistsAllAnswer(CustomSerializeArrayList searchedResultList)
        {
            #region Guard Phrase

            if (searchedResultList == null || searchedResultList.Count <= 1) return false;

            #endregion // Guard Phrase

            // searchedResultList:CustomSerializeArrayList
            // ├[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>…明細データ（問合せ・発注）
            // └[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>…明細データ（回答）
            CustomSerializeArrayList inqList = searchedResultList[0] as CustomSerializeArrayList;
            CustomSerializeArrayList ansList = searchedResultList[1] as CustomSerializeArrayList;

            if (inqList == null || inqList.Count.Equals(0)) return true;
            if (ansList == null || ansList.Count.Equals(0)) return false;

            int targetInqCount = 0;
            int foundAnsCount = 0;
            foreach (SCMInquiryDtlInqResultWork inq in inqList)
            {
                // 問合せ・発注区分が「発注」のものを対象
                if (!IsOrdering(inq.InqOrdDivCd)) continue;

                targetInqCount++;

                foreach (SCMInquiryDtlAnsResultWork ans in ansList)
                {
                    // 問合せ・発注区分が「発注」のものを対象
                    if (!IsOrdering(ans.InqOrdDivCd)) continue;

                    // 引数はリモートの検索結果を前提としているため、問合せ番号や企業コード等は同一とみなす
                    // ∴問合せ行番号と問合せ行番号枝番の比較のみ
                    if (IsParenthood(ans, inq))
                    {
                        foundAnsCount++;
                        break;
                    }
                }
            }
            return foundAnsCount.Equals(targetInqCount);
        }

        /// <summary>
        /// 検索結果から明細データと回答データを分割します。
        /// </summary>
        /// <param name="searchedResultList">検索結果</param>
        /// <returns>Key:明細データとValue:回答データ</returns>
        internal static SearchedResultPair SplitSearchedResult(CustomSerializeArrayList searchedResultList)
        {
            List<SCMInquiryDtlInqResultWork> detailList = new List<SCMInquiryDtlInqResultWork>();
            List<SCMInquiryDtlAnsResultWork> answerList = new List<SCMInquiryDtlAnsResultWork>();
            {
                foreach (CustomSerializeArrayList resultList in searchedResultList)
                {
                    if (resultList == null || resultList.Count.Equals(0)) continue;

                    if (resultList[0] is SCMInquiryDtlInqResultWork)
                    {
                        foreach (SCMInquiryDtlInqResultWork inquiry in resultList)
                        {
                            detailList.Add(inquiry);
                        }
                    }
                    else
                    {
                        foreach (SCMInquiryDtlAnsResultWork answer in resultList)
                        {
                            answerList.Add(answer);
                        }
                    }
                }
            }
            return new SearchedResultPair(detailList, answerList);
        }

        #region 日時(数値)

        /// <summary>
        /// 日時(数値)を取得します。
        /// </summary>
        /// <param name="inq">検索結果(明細データ)</param>
        /// <returns>更新日付(yyyyMMdd) + 更新時間(HHmmssxxx)</returns>
        protected static long GetUpdateDateAndTime(SCMInquiryDtlInqResultWork inq)
        {
            return long.Parse(inq.UpdateDate.ToString("yyyyMMdd") + inq.UpdateTime.ToString("d9"));
        }

        /// <summary>
        /// 日時(数値)を取得します。
        /// </summary>
        /// <param name="inq">検索結果(回答データ)</param>
        /// <returns>更新日付(yyyyMMdd) + 更新時間(HHmmssxxx)</returns>
        protected static long GetUpdateDateAndTime(SCMInquiryDtlAnsResultWork ans)
        {
            return long.Parse(ans.UpdateDate.ToString("yyyyMMdd") + ans.UpdateTime.ToString("d9"));
        }

        #endregion // 日時(数値)
    }

    #region 「未回答」

    /// <summary>
    /// SCM受注データの検索結果の「未回答」状態クラス
    /// </summary>
    public sealed class SCMNoActionState : SCMSearchedResultState
    {
        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <param name="answerDivCd">回答区分</param>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <param name="searchedCancelList">キャンセル明細データの検索結果</param>
        public SCMNoActionState(
            long inquiryNumber,
            int answerDivCd,
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
            : base(inquiryNumber, answerDivCd, searchedDetailList, searchedCancelList) { }

        #endregion // Constructor

        /// <summary>
        /// 売上伝票入力が可能であるか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :売上伝票入力が可能です。<br/>
        /// <c>false</c>:売上伝票入力が付加です。
        /// </returns>
        /// <see cref="SCMSearchedResultState"/>
        public override bool CanInputSalesSlip()
        {
            // 回答区分が「回答完了」…回答する必要がない
            if (IsAnswerCompletion(AnswerDivCode)) return false;

            // 回答区分が「キャンセル」…返品する必要がない∵未回答（回答データが存在しない）
            if (IsCancel(AnswerDivCode)) return false;

            // 2011/02/14 Add >>>
            if (!IsExistsNoAnswerData(SearchedDetailList)) return false;
            // 2011/02/14 Add <<<

            // 回答区分が「未回答」
            // 明細データとキャンセル明細データを比較し、全てキャンセル明細データに該当した場合、
            // 回答する必要がない（未回答で全キャンセルは回答の必要なし）
            return !IsAllNotAnsweredCancel(SearchedDetailList, SearchedCancelList);
        }

        // 2011/02/14 Add >>>
        /// <summary>
        /// 未回答データの存在チェック
        /// </summary>
        /// <param name="searchedDetailList"></param>
        /// <param name="searchedCancelList"></param>
        /// <returns>True:未回答データが存在します</returns>
        private static bool IsExistsNoAnswerData(CustomSerializeArrayList searchedDetailList)
        {
            // 回答データが存在すらしない場合はFalse
            if (( searchedDetailList != null ) && ( searchedDetailList.Count == 0 ))
            {
                return false;
            }
            CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[0];

            CustomSerializeArrayList searchedAnswerItemList = ( searchedDetailList.Count > 1 ) ? (CustomSerializeArrayList)searchedDetailList[1] : new CustomSerializeArrayList();

            bool noAnswerExists = false;
            foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
            {
                if (detail.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;

                bool existsAnswer = false;
                foreach (SCMInquiryDtlAnsResultWork answer in searchedAnswerItemList)
                {
                    // ∴問合せ行番号と問合せ行番号枝番の比較のみ
                    if (IsParenthood(detail, answer))
                    {
                        existsAnswer = true;
                        break;
                    }
                }
                if (!existsAnswer)
                {
                    noAnswerExists = true;
                }
            }

            return noAnswerExists;
        }
        // 2011/02/14 Add <<<

        /// <summary>
        /// 未回答の明細データが全てキャンセルされているか判断します。（「未回答」であることが前提）
        /// </summary>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <param name="searchedCancelList">キャンセル明細データの検索結果</param>
        /// <returns>
        /// <c>true</c> :未回答の明細データが全てキャンセルされています。<br/>
        /// <c>false</c>:回答データが存在します。または回答の必要な明細データが存在します。
        /// </returns>
        private static bool IsAllNotAnsweredCancel(
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            // そもそもキャンセルしていない
            if (searchedCancelList == null || searchedCancelList.Count.Equals(0)) return false;

            // 回答データの存在
            if (SCMSearchedResultState.ExistsAnswerData(searchedDetailList)) return false; // 回答データが存在する
            if (SCMSearchedResultState.ExistsAnswerData(searchedCancelList)) return false; // 返品データが存在する(未回答ではない)

            // 明細データとキャンセル明細データの対応関係
            // searchedDetailList:CustomSerializeArrayList
            // ├[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>…明細データ（問合せ・発注）
            // └[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>…明細データ（回答）
            CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[0];
            CustomSerializeArrayList searchedCancelItemList = (CustomSerializeArrayList)searchedCancelList[0];
            int foundCanceledDetailCount = 0;  // キャンセルとなった明細数
            foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
            {
                foreach (SCMInquiryDtlInqResultWork cancel in searchedCancelItemList)
                {
                    // 引数はリモートの検索結果を前提としているため、問合せ番号や企業コード等は同一とみなす
                    // ∴問合せ行番号と問合せ行番号枝番の比較のみ
                    if (IsParenthood(detail, cancel))
                    {
                        foundCanceledDetailCount++;
                        break;
                    }
                }
            }
            return foundCanceledDetailCount.Equals(searchedDetailItemList.Count);
        }

        /// <summary>
        /// 「未回答」状態であるか判断します。
        /// </summary>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <returns>
        /// <c>true</c> :「未回答」状態です。<br/>
        /// <c>false</c>:「未回答」状態ではありません。
        /// </returns>
        public static bool IsNoActionState(CustomSerializeArrayList searchedDetailList)
        {
            return !ExistsAnswerData(searchedDetailList);
        }
    }

    #endregion // 「未回答」

    #region 「回答完了」

    /// <summary>
    /// SCM受注データの検索結果の「回答完了」状態クラス
    /// </summary>
    public sealed class SCMAnswerCompletionState : SCMSearchedResultState
    {
        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <param name="answerDivCd">回答区分</param>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <param name="searchedCancelList">キャンセル明細データの検索結果</param>
        public SCMAnswerCompletionState(
            long inquiryNumber,
            int answerDivCd,
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
            : base(inquiryNumber, answerDivCd, searchedDetailList, searchedCancelList) { }

        #endregion // Constructor

        /// <summary>
        /// 売上伝票入力が可能であるか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :売上伝票入力が可能です。<br/>
        /// <c>false</c>:売上伝票入力が付加です。
        /// </returns>
        /// <see cref="SCMSearchedResultState"/>
        public override bool CanInputSalesSlip()
        {
            // 回答区分が「回答完了」…回答する必要がない
            if (IsAnswerCompletion(AnswerDivCode)) return false;

            // 回答区分が「キャンセル」…返品する必要がある
            // 全て返品済みの場合、返品の必要なし
            return !IsAllReturnedGoods(SearchedDetailList, SearchedCancelList);
        }

        /// <summary>
        /// 回答データが全てキャンセル(返品)されているか判断します。（「回答完了」であることが前提）
        /// </summary>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <param name="searchedCancelList">キャンセル明細データの検索結果</param>
        /// <returns>
        /// <c>true</c> :回答データが全てキャンセル(返品)されています。<br/>
        /// <c>false</c>:返品データが存在しません。または返品の必要な回答データが存在します。
        /// </returns>
        private static bool IsAllReturnedGoods(
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            // 返品データの存在
            if (!SCMSearchedResultState.ExistsAnswerData(searchedCancelList))
            {
                // 返品データが存在しない
                // 2011/02/14 >>>
                //// 過去にキャンセルされたデータであるか判定
                //long cancelingDateTime = GetLatestDateTime(searchedCancelList); // 直近のキャンセル日時

                //SearchedResultPair searchedDetailResult = SplitSearchedResult(searchedDetailList);
                //long answeringDateTime = GetLatsetAnswerDateTime(searchedDetailResult.Value);   // 直近の回答日時

                //// キャンセルより後の回答で「回答完了」となっているので、返品済とみなせる
                //return answeringDateTime > cancelingDateTime;

                CustomSerializeArrayList cancelList = (CustomSerializeArrayList)searchedCancelList[0];

                bool existsNoAnswer=false;
                foreach (SCMInquiryDtlInqResultWork cancel in cancelList)
                {
                    if (( cancel.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelling ) ||
                        ( cancel.CancelCndtinDiv == (int)CancelCndtinDiv.None ))
                    {
                        existsNoAnswer = true;
                        break;
                    }
                }
                return !existsNoAnswer;
                // 2011/02/14 <<<
            }
            if (!SCMSearchedResultState.ExistsAnswerData(searchedDetailList)) return false; // 回答データが存在しない

            // 2011/02/14 >>>
            //// 回答データとキャンセル回答(返品)データの対応関係
            //// searchedDetailList:CustomSerializeArrayList
            //// ├[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>…明細データ（問合せ・発注）
            //// └[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>…明細データ（回答）
            //CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[1];
            //CustomSerializeArrayList searchedCancelItemList = (CustomSerializeArrayList)searchedCancelList[1];
            //int targetDetailCount = 0;          // 対象とする明細数
            //int foundReturnedDetailCount = 0;   // 返品となった明細数
            //foreach (SCMInquiryDtlAnsResultWork detail in searchedDetailItemList)
            //{
            //    // 問合せ・発注種別が「発注」のものを対象
            //    if (!detail.InqOrdDivCd.Equals((int)InqOrdDivCd.Ordering)) continue;

            //    targetDetailCount++;

            //    foreach (SCMInquiryDtlAnsResultWork cancel in searchedCancelItemList)
            //    {
            //        // 問合せ・発注種別が「発注」のものを対象
            //        if (!cancel.InqOrdDivCd.Equals((int)InqOrdDivCd.Ordering)) continue;

            //        // 引数はリモートの検索結果を前提としているため、問合せ番号や企業コード等は同一とみなす
            //        // ∴問合せ行番号と問合せ行番号枝番の比較のみ
            //        if (IsParenthood(detail, cancel))
            //        {
            //            foundReturnedDetailCount++;
            //            break;
            //        }
            //    }
            //}
            //return foundReturnedDetailCount.Equals(targetDetailCount);
            return !IsExistsNoAnswerData(searchedCancelList);
            // 2011/02/14 <<<
        }

        // 2011/02/14 Add >>>
        /// <summary>
        /// 未回答データの存在チェック
        /// </summary>
        /// <param name="searchedDetailList"></param>
        /// <param name="searchedCancelList"></param>
        /// <returns>True:未回答データが存在します</returns>
        private static bool IsExistsNoAnswerData(CustomSerializeArrayList searchedDetailList)
        {
            // 回答データが存在すらしない場合はFalse
            if (( searchedDetailList != null ) && ( searchedDetailList.Count == 0 ))
            {
                return false;
            }
            CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[0];

            CustomSerializeArrayList searchedAnswerItemList = ( searchedDetailList.Count > 1 ) ? (CustomSerializeArrayList)searchedDetailList[1] : new CustomSerializeArrayList();

            bool noAnswerExists = false;
            foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
            {
                if (detail.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;

                bool existsAnswer = false;
                foreach (SCMInquiryDtlAnsResultWork answer in searchedAnswerItemList)
                {
                    // ∴問合せ行番号と問合せ行番号枝番の比較のみ
                    if (IsParenthood(detail, answer))
                    {
                        existsAnswer = true;
                        break;
                    }
                }
                if (!existsAnswer)
                {
                    noAnswerExists = true;
                }
            }

            return noAnswerExists;
        }
        // 2011/02/14 Add <<<

        // 2011/02/14 Del >>>
        ///// <summary>
        ///// 最新の日時(数値)を取得します。
        ///// </summary>
        ///// <param name="searchedResultList">検索結果</param>
        ///// <returns>
        ///// 検索結果の明細データと回答データの中から最新の日時(数値:yyyyMMddHHmmssxxx)を返します。
        ///// </returns>
        //private static long GetLatestDateTime(CustomSerializeArrayList searchedResultList)
        //{
        //    SearchedResultPair searchedResult = SplitSearchedResult(searchedResultList);

        //    long latestDateTime = 0;
        //    searchedResult.Key.ForEach(delegate(SCMInquiryDtlInqResultWork inq)
        //    {
        //        long inqDateTime = GetUpdateDateAndTime(inq);
        //        if (inqDateTime >= latestDateTime)
        //        {
        //            latestDateTime = inqDateTime;
        //        }
        //    });
        //    searchedResult.Value.ForEach(delegate(SCMInquiryDtlAnsResultWork ans)
        //    {
        //        long ansDateTime = GetUpdateDateAndTime(ans);
        //        if (ansDateTime >= latestDateTime)
        //        {
        //            latestDateTime = ansDateTime;
        //        }
        //    });
        //    return latestDateTime;
        //}
        // 2011/02/14 Del <<<

        /// <summary>
        /// 検索結果(回答データ)から最新の日時(数値)を取得します。
        /// </summary>
        /// <param name="answerList">検索結果(回答データ)</param>
        /// <returns>検索結果(回答データ)から最新の日時(数値)</returns>
        private static long GetLatsetAnswerDateTime(List<SCMInquiryDtlAnsResultWork> answerList)
        {
            long latestDateTime = 0;
            answerList.ForEach(delegate(SCMInquiryDtlAnsResultWork ans)
            {
                long ansDateTime = GetUpdateDateAndTime(ans);
                if (ansDateTime >= latestDateTime)
                {
                    latestDateTime = ansDateTime;
                }
            });
            return latestDateTime;
        }

        /// <summary>
        /// 「回答完了」状態であるか判断します。
        /// </summary>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <returns>
        /// <c>true</c> :「回答完了」状態です。<br/>
        /// <c>false</c>:「回答完了」状態ではありません。
        /// </returns>
        public static bool IsAnswerCompletionState(CustomSerializeArrayList searchedDetailList)
        {
            return ExistsAllAnswer(searchedDetailList);
        }
    }

    #endregion // 「回答完了」

    #region 「一部回答」

    /// <summary>
    /// SCM受注データの検索結果の「一部回答」状態クラス
    /// </summary>
    public sealed class SCMPartAnswerState : SCMSearchedResultState
    {
        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <param name="answerDivCd">回答区分</param>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <param name="searchedCancelList">キャンセル明細データの検索結果</param>
        public SCMPartAnswerState(
            long inquiryNumber,
            int answerDivCd,
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        ) : base(inquiryNumber, answerDivCd, searchedDetailList, searchedCancelList) { }

        #endregion // Constructor

        /// <summary>
        /// 売上伝票入力が可能であるか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :売上伝票入力が可能です。<br/>
        /// <c>false</c>:売上伝票入力が付加です。
        /// </returns>
        /// <see cref="SCMSearchedResultState"/>
        public override bool CanInputSalesSlip()
        {
            // 回答区分が「回答完了」…売伝に戻る必要なし
            if (IsAnswerCompletion(AnswerDivCode)) return false;

            // 回答区分が「キャンセル」を選択している
            if (IsCancel(AnswerDivCode))
            {
                // 回答データが存在しなければ、売伝に戻る必要なし
                // (キャンセル分に対して何もしなくてよい）
                if (!ExistsAnswerData(SearchedDetailList)) return false;
                
                // キャンセル分の回答データが全て存在すれば、売伝に戻る必要なし
                // (全て返品しているため、キャンセル分に対して何もしなくてよい）
                if (ExistsAllAnswer(SearchedCancelList)) return false;

                // 返品が必要なキャンセル明細データを取得
                List<SCMInquiryDtlInqResultWork> cancelingDataList = FindCancelingData(
                    SearchedDetailList,
                    SearchedCancelList
                );

                // 返品が必要なキャンセル明細データがあれば、売伝に戻る
                return cancelingDataList.Count > 0;
            }

            // 回答区分が「一部回答」を選択している

            if (!IsExistsNoAnswerData(SearchedDetailList, SearchedCancelList)) return false; // 2011/02/14 Add

            // キャンセルデータが存在しなければ、売伝に戻る
            if (!ExistsDetailData(SearchedCancelList)) return true;

            // 回答が必要な明細データを取得
            List<SCMInquiryDtlInqResultWork> answeringDataList = FindAnsweringData(
                SearchedDetailList,
                SearchedCancelList
            );

            // 回答が必要な明細データがある場合、売伝に戻る
            return answeringDataList.Count > 0;
        }

        // 2011/02/14 Add >>>
        /// <summary>
        /// 未回答データの存在チェック
        /// </summary>
        /// <param name="searchedDetailList"></param>
        /// <param name="searchedCancelList"></param>
        /// <returns>True:未回答データが存在します</returns>
        private static bool IsExistsNoAnswerData(CustomSerializeArrayList searchedDetailList, CustomSerializeArrayList searchedCancelList)
        {
            // 回答データが存在すらしない場合はFalse
            if (( searchedDetailList != null ) && ( searchedDetailList.Count == 0 ))
            {
                return false;
            }
            CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[0];

            CustomSerializeArrayList searchedAnswerItemList = ( searchedDetailList.Count > 1 ) ? (CustomSerializeArrayList)searchedDetailList[1] : new CustomSerializeArrayList();

            bool noAnswerExists = false;
            foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
            {
                if (detail.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;

                bool existsAnswer = false;
                foreach (SCMInquiryDtlAnsResultWork answer in searchedAnswerItemList)
                {
                    // ∴問合せ行番号と問合せ行番号枝番の比較のみ
                    if (IsParenthood(detail, answer))
                    {
                        existsAnswer = true;
                        break;
                    }
                }
                if (!existsAnswer)
                {
                    noAnswerExists = true;
                }
            }

            return noAnswerExists;
        }
        // 2011/02/14 Add <<<

        /// <summary>
        /// 回答が必要なキャンセル明細データを取得します。
        /// </summary>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <param name="searchedCancelList">キャンセル明細データの検索結果</param>
        /// <returns>
        /// 回答済みではない明細データとキャンセル明細データの検索結果を比較し、該当しないものを返します。
        /// </returns>
        private static List<SCMInquiryDtlInqResultWork> FindAnsweringData(
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            List<SCMInquiryDtlInqResultWork> foundList = new List<SCMInquiryDtlInqResultWork>();
            {
                List<SCMInquiryDtlInqResultWork> notAnsweringDataList = FindNotAnsweredInqData(searchedDetailList);
                {
                    notAnsweringDataList.ForEach(delegate(SCMInquiryDtlInqResultWork notAnsweringData)
                    {
                        bool found = false;
                        CustomSerializeArrayList cancelList = (CustomSerializeArrayList)searchedCancelList[0];
                        foreach (SCMInquiryDtlInqResultWork cancelData in cancelList)
                        {
                            // リモートの検索結果であることを前提としているため、問合せ行番号と問合せ行番号枝番のみを比較
                            if (
                                cancelData.InqRowNumber.Equals(notAnsweringData.InqRowNumber)
                                    &&
                                cancelData.InqRowNumDerivedNo.Equals(notAnsweringData.InqRowNumDerivedNo)
                            )
                            {
                                // 問合せ・発注種別が「発注」のものを対象
                                if (IsOrdering(cancelData.InqOrdDivCd))
                                {
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (!found) foundList.Add(notAnsweringData);
                    });
                }
            }
            return foundList;
        }

        /// <summary>
        /// 返品が必要なキャンセル明細データを取得します。
        /// </summary>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <param name="searchedCancelList">キャンセル明細データの検索結果</param>
        /// <returns>
        /// 返品済みではないキャンセル明細データと回答データの検索結果を比較し、該当するものを返します。
        /// </returns>
        private static List<SCMInquiryDtlInqResultWork> FindCancelingData(
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            List<SCMInquiryDtlInqResultWork> foundList = new List<SCMInquiryDtlInqResultWork>();
            {
                List<SCMInquiryDtlInqResultWork> notReturningDataList = FindNotAnsweredInqData(searchedCancelList);
                {
                    notReturningDataList.ForEach(delegate(SCMInquiryDtlInqResultWork notReturningData)
                    {
                        bool found = false;
                        CustomSerializeArrayList searchedAnswerList = (CustomSerializeArrayList)searchedDetailList[1];
                        foreach (SCMInquiryDtlAnsResultWork answerData in searchedAnswerList)
                        {
                            // リモートの検索結果であることを前提としているため、問合せ行番号と問合せ行番号枝番のみを比較
                            if (
                                answerData.InqRowNumber.Equals(notReturningData.InqRowNumber)
                                    &&
                                answerData.InqRowNumDerivedNo.Equals(notReturningData.InqRowNumDerivedNo)
                            )
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found) foundList.Add(notReturningData);
                    });
                }
            }
            return foundList;
        }

        /// <summary>
        /// 回答済みではない明細データを取得します。
        /// </summary>
        /// <param name="searchedDetailList">明細データの検索結果</param>
        /// <returns>
        /// 明細データの検索結果の回答データに存在しない明細データのリストを返します。
        /// </returns>
        private static List<SCMInquiryDtlInqResultWork> FindNotAnsweredInqData(CustomSerializeArrayList searchedDetailList)
        {
            List<SCMInquiryDtlInqResultWork> foundList = new List<SCMInquiryDtlInqResultWork>();
            {
                foreach (SCMInquiryDtlInqResultWork detailData in (CustomSerializeArrayList)searchedDetailList[0])
                {
                    // 問合せ・発注種別が「発注」のものを対象
                    if (!IsOrdering(detailData.InqOrdDivCd)) continue;

                    if (searchedDetailList.Count <= 1)
                    {
                        // 回答データが存在しない
                        foundList.Add(detailData);
                        continue;
                    }

                    bool founds = false;
                    CustomSerializeArrayList searchedAnswerList = (CustomSerializeArrayList)searchedDetailList[1];
                    foreach (SCMInquiryDtlAnsResultWork answerData in searchedAnswerList)
                    {
                        // リモートの検索結果であることを前提としているため、問合せ行番号と問合せ行番号枝番のみを比較
                        if (
                            answerData.InqRowNumber.Equals(detailData.InqRowNumber)
                                &&
                            answerData.InqRowNumDerivedNo.Equals(detailData.InqRowNumDerivedNo)
                        )
                        {
                            founds = true;
                            break;
                        }
                    }   // foreach (SCMInquiryDtlAnsResultWork answerData in (CustomSerializeArrayList)searchedCancelList[1])
                    if (!founds) foundList.Add(detailData);
                }   // foreach (SCMInquiryDtlInqResultWork cancelData in (CustomSerializeArrayList)searchedCancelList[0])
            }
            return foundList;
        }
    }

    #endregion // 「一部回答」

    #region ファクトリクラス

    /// <summary>
    /// SCM受注データの検索結果の状態のファクトリクラス
    /// </summary>
    public static class SCMSearchedResultStateFactory
    {
        /// <summary>
        /// SCM受注データの検索結果の状態を生成します。
        /// </summary>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <param name="answerDivCd">回答区分</param>
        /// <param name="searchingHeader">検索条件</param>
        /// <param name="searchedDerailData">明細データの検索結果</param>
        /// <param name="searchedCancelData">キャンセル明細データの検索結果</param>
        /// <returns>
        /// 「未回答」または「回答完了」または「一部回答」
        /// </returns>
        public static SCMSearchedResultState Create(
            long inquiryNumber,
            int answerDivCd,
            SCMInquiryResultWork searchingHeader,
            CustomSerializeArrayList searchedDerailData,
            CustomSerializeArrayList searchedCancelData
        )
        {
            switch (searchingHeader.AnswerDivCd) // 検索条件の回答区分が...
            {
                case (int)AnswerDivCd.NoAction:         // 「未回答」
                    return new SCMNoActionState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);

                case (int)AnswerDivCd.AnswerCompletion: // 「回答完了」
                    return new SCMAnswerCompletionState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);

                case (int)AnswerDivCd.PartAnswer:       // 「一部回答」
                    return new SCMPartAnswerState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);
                default:
                    break;
            }

            // 「未回答」
            if (SCMNoActionState.IsNoActionState(searchedDerailData))
            {
                return new SCMNoActionState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);
            }

            // 「回答完了」
            if (SCMAnswerCompletionState.IsAnswerCompletionState(searchedDerailData))
            {
                return new SCMAnswerCompletionState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);
            }

            // 「一部回答」
            return new SCMPartAnswerState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);
        }
    }

    #endregion // ファクトリクラス
}
