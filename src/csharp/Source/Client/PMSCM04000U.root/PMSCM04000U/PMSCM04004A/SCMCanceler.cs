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
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    // 2011/02/14 このクラスは使用しない >>>
    #if False
    /// <summary>
    /// キャンセル処理クラス
    /// </summary>
    public sealed class SCMCanceler
    {
        #region 検索処理

        /// <summary>検索処理</summary>
        private readonly SCMInquiryDBAgent _searcher;
        /// <summary>検索処理を取得します。</summary>
        private SCMInquiryDBAgent Searcher { get { return _searcher; } }

        #endregion //　検索処理

        #region ヘッダデータ(SCM受注データ)の検索条件

        /// <summary>現在のヘッダデータ(SCM受注データ)の検索条件</summary>
        private SCMInquiryOrderWork _currentSearchingHeaderCondition;
        /// <summary>現在のヘッダデータ(SCM受注データ)の検索条件を取得します。</summary>
        private SCMInquiryOrderWork CurrentSearchingHeaderCondition
        {
            get { return _currentSearchingHeaderCondition; }
            set { _currentSearchingHeaderCondition = value; }
        }

        /// <summary>
        /// ヘッダデータ(SCM受注データ)の検索条件をコピーします。
        /// </summary>
        /// <param name="src">コピー元</param>
        /// <returns>コピーしたヘッダデータ(SCM受注データ)の検索条件</returns>
        private static SCMInquiryOrderWork Copy(SCMInquiryOrderWork src)
        {
            SCMInquiryOrderWork copy = new SCMInquiryOrderWork();
            {
                //copy.AcptAnOdrStatus = src.AcptAnOdrStatus;
                copy.AcptAnOdrStatus = new int[src.AcptAnOdrStatus.Length];
                Array.Copy(src.AcptAnOdrStatus, copy.AcptAnOdrStatus, copy.AcptAnOdrStatus.Length);
                
                copy.AnsEmployeeCd      = src.AnsEmployeeCd;
                copy.AnsEmployeeNm      = src.AnsEmployeeNm;

                //copy.AnswerDivCd = src.AnswerDivCd;
                copy.AnswerDivCd = new int[src.AnswerDivCd.Length];
                Array.Copy(src.AnswerDivCd, copy.AnswerDivCd, copy.AnswerDivCd.Length);

                //copy.AwnserMethod = src.AwnserMethod;
                copy.AwnserMethod = new int[src.AwnserMethod.Length];
                Array.Copy(src.AwnserMethod, copy.AwnserMethod, copy.AwnserMethod.Length);

                copy.CustomerCode       = src.CustomerCode;
                copy.Ed_CustomerCode    = src.Ed_CustomerCode;
                copy.Ed_InquiryDate     = src.Ed_InquiryDate;
                copy.Ed_InquiryNumber   = src.Ed_InquiryNumber;
                copy.Ed_SalesSlipNum    = src.Ed_SalesSlipNum;
                copy.EnterpriseCode     = src.EnterpriseCode;
                copy.InqEmployeeCd      = src.InqEmployeeCd;
                copy.InqEmployeeNm      = src.InqEmployeeNm;

                //copy.InqOrdDivCd = src.InqOrdDivCd;
                copy.InqOrdDivCd = new int[src.InqOrdDivCd.Length];
                Array.Copy(src.InqOrdDivCd, copy.InqOrdDivCd, copy.InqOrdDivCd.Length);

                copy.InqOrdNote         = src.InqOrdNote;
                copy.InqOriginalEpCd    = src.InqOriginalEpCd.Trim();//@@@@20230303
                copy.InqOriginalSecCd   = src.InqOriginalSecCd;
                copy.InqOtherEpCd       = src.InqOtherEpCd;
                copy.InqOtherSecCd      = src.InqOtherSecCd;
                copy.JudgementDate      = src.JudgementDate;
                copy.SalesTotalTaxInc   = src.SalesTotalTaxInc;
                copy.St_CustomerCode    = src.St_CustomerCode;
                copy.St_InquiryDate     = src.St_InquiryDate;
                copy.St_InquiryNumber   = src.St_InquiryNumber;
                copy.St_SalesSlipNum    = src.St_SalesSlipNum;
                copy.UpdateDate         = src.UpdateDate;
                copy.UpdateTime         = src.UpdateTime;
            }
            return copy;
        }

        /// <summary>
        /// ヘッダデータ(SCM受注データ)の検索条件(キャンセル以外)を生成します。
        /// </summary>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <returns>現在のヘッダデータ(SCM受注データ)の検索条件をもとにキャンセル以外の条件を生成します。</returns>
        private SCMInquiryOrderWork CreateSearchingHeaderConditionWithoutCancel(long inquiryNumber)
        {
            SCMInquiryOrderWork searchingCondition = Copy(CurrentSearchingHeaderCondition);
            {
                // 回答区分
                searchingCondition.AnswerDivCd = new int[] {
                    (int)AnswerDivCd.AnswerCompletion,  // 回答完了
                    (int)AnswerDivCd.NoAction,          // 未回答(アクションなし)
                    (int)AnswerDivCd.PartAnswer,        // 一部回答
                    (int)AnswerDivCd.Approval           // 承認
                };

                // 問合せ番号
                searchingCondition.St_InquiryNumber = inquiryNumber;
                searchingCondition.Ed_InquiryNumber = inquiryNumber;
            }
            return searchingCondition;
        }

        #endregion // ヘッダデータ(SCM受注データ)の検索条件

        #region 登録されたSCM受注データの検索結果

        /// <summary>最初に登録されたSCM受注データの検索結果マップ</summary>
        private readonly Dictionary<long, SCMInquiryResultWork> _firstEntryMap = new Dictionary<long, SCMInquiryResultWork>();
        /// <summary>最初に登録されたSCM受注データの検索結果マップを取得します。</summary>
        /// <remarks>キー：問合せ番号</remarks>
        private Dictionary<long, SCMInquiryResultWork> FirstEntryMap { get { return _firstEntryMap; } }

        /// <summary>重複して登録したSCM受注データの検索結果(キャンセル分あり)マップ</summary>
        private readonly Dictionary<long, SCMInquiryResultWork> _secondEntryMap = new Dictionary<long, SCMInquiryResultWork>();
        /// <summary>重複して登録したSCM受注データの検索結果(キャンセル分あり)マップを取得します。</summary>
        /// <remarks>キー：問合せ番号</remarks>
        private Dictionary<long, SCMInquiryResultWork> SecondEntryMap { get { return _secondEntryMap; } }

        /// <summary>
        /// 登録されたSCM受注データの検索結果をクリアします。
        /// </summary>
        /// <param name="currentSearchingHeaderCondition">現在のヘッダデータ(SCM受注データ)の検索条件</param>
        public void ClearEntry(SCMInquiryOrderWork currentSearchingHeaderCondition)
        {
            FirstEntryMap.Clear();
            SecondEntryMap.Clear();
            CurrentSearchingHeaderCondition = Copy(currentSearchingHeaderCondition);
        }

        /// <summary>
        /// SCM受注データの検索結果を登録します。
        /// </summary>
        /// <param name="scmHeader">SCM受注データの検索結果</param>
        public void Entry(SCMInquiryResultWork scmHeader)
        {
            #region Guard Phrase

            if (scmHeader == null) return;

            #endregion // Guard Phrase

            if (!FirstEntryMap.ContainsKey(scmHeader.InquiryNumber))
            {
                FirstEntryMap.Add(scmHeader.InquiryNumber, scmHeader);
                return;
            }

            // 重複したSCM受注データ(キャンセル分あり)
            if (!SecondEntryMap.ContainsKey(scmHeader.InquiryNumber))
            {
                SecondEntryMap.Add(scmHeader.InquiryNumber, scmHeader);
                return;
            }
        }

        #endregion // 登録されたSCM受注データの検索結果

        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="searcher">検索処理</param>
        public SCMCanceler(SCMInquiryDBAgent searcher)
        {
            _searcher = searcher;
        }

        #endregion // Constructor

        /// <summary>
        /// 売上伝票入力を行えるか判断します。
        /// </summary>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <param name="answerDivCd">回答区分</param>
        /// <returns>
        /// <c>true</c> :売上伝票入力を行えます。
        /// <c>false</c>:以下の場合、売上伝票入力を行えません。
        /// ①回答区分が｢回答完了｣
        /// ②回答区分が｢キャンセル｣で『未回答データが全てキャンセル』または『全て返品済み』
        /// </returns>
        public bool CanInputSalesSlip(
            long inquiryNumber,
            int answerDivCd
        )
        {
            // 回答区分が「回答完了」…売上伝票入力を行う必要はない
            if (SCMSearchedResultState.IsAnswerCompletion(answerDivCd)) return false;

            // キャンセル分を含む全明細データ(回答データを含む）を取得
            object detailData = null;   // 1パラ目
            object cancelData = null;   // 2パラ目

            // 3パラ目
            SCMInquiryResultWork searchingHeader = null;
            if (SecondEntryMap.ContainsKey(inquiryNumber))
            {
                // 回答区分の検索条件に「キャンセル」を含む場合
                SCMInquiryResultWork firstHeader = FirstEntryMap[inquiryNumber];
                SCMInquiryResultWork secondHeader= SecondEntryMap[inquiryNumber];
                // 回答区分がキャンセルではない方を採用
                searchingHeader = SCMSearchedResultState.IsCancel(firstHeader.AnswerDivCd) ? secondHeader : firstHeader;
            }
            else if (!SCMSearchedResultState.IsCancel(answerDivCd))
            {
                // 回答区分がキャンセルではない方を採用
                searchingHeader = FirstEntryMap[inquiryNumber];
            }
            else
            {
                // 検索条件が「キャンセル」のみの場合、その対となるヘッダデータを取得
                // ∵このデータで明細データを検索しないと、回答データが取得できない
                object otherHeaderData = null;  // 1パラ目
                SCMInquiryOrderWork searchingOtherHeader = CreateSearchingHeaderConditionWithoutCancel(inquiryNumber);  // 2パラ目

                // 代理人で検索すると登録データがクリアされるので、本物で検索
                Searcher.RealAccesser.Search(out otherHeaderData, searchingOtherHeader, 0, ConstantManagement.LogicalMode.GetData0);
                
                CustomSerializeArrayList searchedOtherHeaderData = otherHeaderData as CustomSerializeArrayList;
                if (searchedOtherHeaderData == null || searchedOtherHeaderData.Count.Equals(0))
                {
                    // このケースはありえない(キャンセルヘッダの対になるヘッダは必ずあるはず)
                    searchingHeader = FirstEntryMap[inquiryNumber];
                }
                CustomSerializeArrayList searchedOtherHeaderList = searchedOtherHeaderData[0] as CustomSerializeArrayList;
                if (searchedOtherHeaderList == null || searchedOtherHeaderList.Count.Equals(0))
                {
                    // このケースはありえない(キャンセルヘッダの対になるヘッダは必ずあるはず)
                    searchingHeader = FirstEntryMap[inquiryNumber];
                }
                Entry((SCMInquiryResultWork)searchedOtherHeaderList[0]);    // リモートは最新のものを返すので、必ず1件のはず

                // 再判定
                return CanInputSalesSlip(inquiryNumber, answerDivCd);
            }

            const string FORMAT = "問合せ番号[{0}]：{1} -> {2}";
            string debugInfo = string.Format(FORMAT,
                searchingHeader.InquiryNumber,
                SCMInquiryDBAgent.GetAnswerDivCdName(answerDivCd),
                SCMInquiryDBAgent.GetAnswerDivCdName(searchingHeader.AnswerDivCd)
            );

            Debug.WriteLine(debugInfo);
            int status = Searcher.SearchDetailAll(
                out detailData, // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlInqResultWork または SCMInquiryDtlAnsResultWork>>
                out cancelData, // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlInqResultWork または SCMInquiryDtlAnsResultWork>>
                searchingHeader,
                0,
                ConstantManagement.LogicalMode.GetData0
            );

            // 検索結果の状態クラスを生成
            SCMSearchedResultState searchedResultState = SCMSearchedResultStateFactory.Create(
                inquiryNumber, 
                answerDivCd, 
                searchingHeader, 
                (CustomSerializeArrayList)detailData, 
                (CustomSerializeArrayList)cancelData
            );
            return searchedResultState.CanInputSalesSlip();
        }
    }
    #endif
    // 2011/02/14 Del <<<
}

