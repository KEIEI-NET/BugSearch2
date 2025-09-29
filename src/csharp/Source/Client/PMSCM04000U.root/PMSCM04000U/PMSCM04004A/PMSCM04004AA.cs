//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 問合せ一覧/受注検索ウィンドウ
// プログラム概要   : 問合せ一覧アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/03/31  修正内容 : 検索条件に一部回答を含む場合、未回答の明細データが表示されない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/04/16  修正内容 : キャンセル対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/04/23  修正内容 : 明細表示を行うとＳＦで入力した明細順番と逆順で表示される
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024 佐々木 健
// 作 成 日  2010/05/27  修正内容 : ①明細のセット元データを判別できるように修正
//                                  ②キャンセル不可機能を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/06/17  修正内容 : キャンセル追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/01/24  修正内容 : ・明細単位で回答状況を表示するように修正
//                                 ・問合/発注を別明細で表示するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/02/14  修正内容 : ・取消対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/02/17  修正内容 : ・キャンセル拒否時、問合せ明細を更新しない（回答区分は「回答完了」）にする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/02/18  修正内容 : ・返品拒否データを送信するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/03/07  修正内容 : 返品拒否時、キャンセルデータを読み込むように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/03/14  修正内容 : 返品入力したデータの明細が表示されない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 久保田 誠
// 作 成 日  2011/05/26  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  10703242-00 作成担当 : 22018 鈴木 正臣
// 作 成 日  2011/06/13  修正内容 : ①抽出条件を問合せ日⇒更新日に変更
//                                 ②グリッドに「更新日」を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 作 成 日  2011/11/12  修正内容 : Redmine 26534 受発注種別を追加し、PCCforNSとBLパーツオーダーシステムの判断を可能とする
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/10/10  修正内容 : 2012/11/14配信分 SCM障害№32 一覧に「車台番号」追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/10/10  修正内容 : 2012/11/14配信 SCM障害№176対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : pengs
// 作 成 日  2013/02/19  修正内容 : 2013/03/13配信分 システム障害管理№10433対応 
//                                  一覧に「車台番号」の表示は、「-」後の文字列になるように修正する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/03/29  修正内容 : SCM障害№10503対応
//----------------------------------------------------------------------------//
// 管理番号 　　　　　　 作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/04/05  修正内容 : 2013/99/9配信 SCM障害№50 SPK対応
//----------------------------------------------------------------------------//
// 管理番号 　　　　　　 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : 2013/06/18配信　SCM障害№10384対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : qijh
// 作 成 日  2013/02/27  修正内容 : 2013/06/18配信 Redmine#34752 「PMSCMのNo.10385」BLPの対応
//----------------------------------------------------------------------------//
// 管理番号 　　　　　　 作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/06/04  修正内容 : 2013/06/18配信　システムテスト障害№19対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/12/02  修正内容 : 商品保証部Redmine#783対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 吉岡
// 作 成 日  2015/02/20  修正内容 : SCM高速化 C向け種別特記対応
//----------------------------------------------------------------------------//
// 管理番号  11470076-00 作成担当 : 譚洪
// 作 成 日  2019/01/08  修正内容 : 新元号の対応
//----------------------------------------------------------------------------//
// 管理番号  11770032-00 作成担当 : 譚洪
// 作 成 日  2021/08/26  修正内容 : PMKOBETSU-4182 BLPフル型式消失障害対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Globarization; // ADD BY 譚洪 2019/01/08 FOR 新元号の対応

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 問合せ一覧/受注検索ウィンドウアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM受注データ、SCM受注明細データの取得を行う。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2009.05.27</br>
    /// <br>Update Note: 2021/08/26 譚洪</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4182 BLPフル型式消失障害対応</br> 
    /// <br></br>
    public class SCMInquiryOrderAcs
    {
        #region ■private変数
        private static SCMInquiryOrderAcs _scmInquiryOrderAcs; // 問合せ一覧アクセスクラス

        private MakerAcs _makerAcs; // メーカーアクセスクラス

        // DEL 2010/04/16 キャンセル対応 ---------->>>>>
        //// リモートDB
        //private readonly ISCMInquiryDB _scmInquiryDB = (ISCMInquiryDB)MediationSCMInquiryResultDB.GetSCMInquiryDB();
        ///// <summary>リモートDBを取得します。</summary>
        //private ISCMInquiryDB SCMInquiryDB { get { return _scmInquiryDB; } }
        // DEL 2010/04/16 キャンセル対応 ----------<<<<<
        // ADD 2010/04/16 キャンセル対応 ---------->>>>>
        // リモートDB
        private readonly SCMInquiryDBAgent _scmInquiryDB = new SCMInquiryDBAgent();
        /// <summary>リモートDBを取得します。</summary>
        private SCMInquiryDBAgent SCMInquiryDB { get { return _scmInquiryDB; } }

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
        /// ③回答区分が「未回答」or「一部回答」で、未回答明細が取消
        /// </returns>
        public bool CanInputSalesSlip(
            // 2011/02/14 >>>
            //long inquiryNumber,
            //int answerDivCd
            Guid dtlGuid
            // 2011/02/14 <<<
        )
        {
            // 2011/02/14 >>>
            //return SCMInquiryDB.Canceler.CanInputSalesSlip(inquiryNumber, answerDivCd);

            return this.CanInputSalesSlipProc(dtlGuid);
            // 2011/02/14 <<<
        }
        // ADD 2010/04/16 キャンセル対応 ----------<<<<<

        // 2011/02/14 Add >>>
        private Dictionary<Guid, bool> _canInputSalesSlipDictionary = new Dictionary<Guid, bool>();
        private bool CanInputSalesSlipProc(
            Guid dtlGuid
        )
        {
            if (_canInputSalesSlipDictionary.ContainsKey(dtlGuid)) return _canInputSalesSlipDictionary[dtlGuid];

            SCMAcOdrDataDataSet.SCMInquiryResultRow row = _scmInquiryResultDataTable.FindByDetailGuid(dtlGuid);
            if (row == null) return false;

            if (row.AnswerDivCd == (int)(int)AnswerDivCd.AnswerCompletion)
            {
                this._canInputSalesSlipDictionary.Add(dtlGuid, false);
                return this._canInputSalesSlipDictionary[dtlGuid];
            }


            object detailData = null;   // 1パラ目
            object cancelData = null;   // 2パラ目

            SCMInquiryResultWork condition = CreateSearchingHeaderConditionWithoutCancel(row);

            int status = this.ExecuteSearchDetailAll(
                condition,
                out detailData, // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlInqResultWork または SCMInquiryDtlAnsResultWork>>
                out cancelData // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlInqResultWork または SCMInquiryDtlAnsResultWork>>
            );

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                bool judge = CheckCanSalesSlip(condition, (CustomSerializeArrayList)detailData, (CustomSerializeArrayList)cancelData);
                this._canInputSalesSlipDictionary.Add(dtlGuid, judge);
                return judge;
            }
            return false;
        }
        /// <summary>
        /// ヘッダデータ(SCM受注データ)の検索条件(キャンセル以外)を生成します。
        /// </summary>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <returns>現在のヘッダデータ(SCM受注データ)の検索条件をもとにキャンセル以外の条件を生成します。</returns>
        private SCMInquiryResultWork CreateSearchingHeaderConditionWithoutCancel(SCMAcOdrDataDataSet.SCMInquiryResultRow row)
        {
            SCMInquiryResultWork searchingCondition = new SCMInquiryResultWork();
            {
                // 問合せ番号
                searchingCondition.InquiryNumber = row.InquiryNumber;

                searchingCondition.InqOrdDivCd = row.InqOrdDivCd;

                searchingCondition.EnterpriseCode = row.EnterpriseCode;
                searchingCondition.InqOriginalEpCd = row.InqOriginalEpCd.Trim();//@@@@20230303
                searchingCondition.InqOriginalSecCd = row.InqOriginalSecCd;
                searchingCondition.InqOtherEpCd = row.InqOtherEpCd;
                searchingCondition.InqOtherSecCd = row.InqOtherSecCd;
                searchingCondition.InqOtherEpCd = row.InqOtherEpCd;
                searchingCondition.AnswerDivCd = row.AnswerDivCd;
            }
            return searchingCondition;
        }

        /// <summary>
        /// 売上伝票入力を起動できるかチェックします。
        /// </summary>
        /// <param name="answerDivCd"></param>
        /// <param name="detailList"></param>
        /// <param name="cancelList"></param>
        /// <returns></returns>
        private bool CheckCanSalesSlip(SCMInquiryResultWork serachCondition, CustomSerializeArrayList detailList, CustomSerializeArrayList cancelList)
        {

            SortedList<string, object> joinSearchedDetailList = SCMInquiryDBAgent.JoinSearchedDetailResult(serachCondition, detailList, cancelList);

            bool existsNoAnswerData = false;
            foreach (string key in joinSearchedDetailList.Keys)
            {
                if (joinSearchedDetailList[key] is SCMInquiryDtlInqResultWork)
                {
                    if (( (SCMInquiryDtlInqResultWork)joinSearchedDetailList[key] ).CancelCndtinDiv != (int)CancelCndtinDiv.Cancelled)
                    {
                        existsNoAnswerData = true;
                        break;
                    }
                }
            }
            return existsNoAnswerData;
        }

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
            CustomSerializeArrayList searchedDetailItemList = null;
            CustomSerializeArrayList searchedAnswerItemList = null;

            SCMInquiryDBAgent.SplitSearchedResult(searchedDetailList, out searchedDetailItemList, out searchedAnswerItemList);


            bool noAnswerExists = false;
            if (searchedDetailItemList != null)
            {
                foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
                {
                    if (detail.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;

                    bool existsAnswer = false;

                    // 回答データを取得できなかった場合は未回答あり
                    if (searchedAnswerItemList == null)
                    {
                        noAnswerExists = true;
                        break;
                    }
                    foreach (SCMInquiryDtlAnsResultWork answer in searchedAnswerItemList)
                    {
                        // ∴問合せ行番号と問合せ行番号枝番の比較のみ
                        if (SCMSearchedResultState.IsParenthood(detail, answer))
                        {
                            existsAnswer = true;
                            break;
                        }
                    }
                    if (!existsAnswer)
                    {
                        noAnswerExists = true;
                        break;
                    }
                }
            }
            return noAnswerExists;
        }

        /// <summary>
        /// 未回答データの存在チェック
        /// </summary>
        /// <param name="searchedDetailList"></param>
        /// <param name="searchedCancelList"></param>
        /// <returns>True:未回答データが存在します</returns>
        private static bool IsExistsCancelNoAnswerData(CustomSerializeArrayList searchedDetailList)
        {
            // 回答データが存在すらしない場合はFalse
            if (( searchedDetailList != null ) && ( searchedDetailList.Count == 0 ))
            {
                return false;
            }
            CustomSerializeArrayList searchedDetailItemList = null;
            CustomSerializeArrayList searchedAnswerItemList = null;
            SCMInquiryDBAgent.SplitSearchedResult(searchedDetailList, out searchedDetailItemList, out searchedAnswerItemList);

            bool noAnswerExists = false;
            if (searchedDetailItemList != null)
            {
                foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
                {
                    if (detail.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;
                    if (detail.CancelCndtinDiv == (int)CancelCndtinDiv.Rejected) continue;

                    // 回答データを取得できなかった場合は未回答あり
                    if (searchedAnswerItemList == null)
                    {
                        noAnswerExists = true;
                        break;
                    }
                    bool existsAnswer = false;
                    foreach (SCMInquiryDtlAnsResultWork answer in searchedAnswerItemList)
                    {
                        // ∴問合せ行番号と問合せ行番号枝番の比較のみ
                        if (SCMSearchedResultState.IsParenthood(detail, answer))
                        {
                            existsAnswer = true;
                            break;
                        }
                    }
                    if (!existsAnswer)
                    {
                        noAnswerExists = true;
                        break;
                    }
                }
            }

            return noAnswerExists;
        }

        // 2011/02/14 Add <<<

        // リモート抽出結果保持用DataTable
        private SCMAcOdrDataDataSet.SCMInquiryResultDataTable _scmInquiryResultDataTable;
        private SCMAcOdrDataDataSet.SCMInquiryDetailResultDataTable _scmInquiryDetailResultDataTable;

        private string _enterpriseCode; // 自企業コード
        #endregion

        #region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMInquiryOrderAcs()
        {
            this._makerAcs = new MakerAcs();

            this._scmInquiryResultDataTable = new SCMAcOdrDataDataSet.SCMInquiryResultDataTable();
            this._scmInquiryDetailResultDataTable = new SCMAcOdrDataDataSet.SCMInquiryDetailResultDataTable();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>インスタンス</returns>
        public static SCMInquiryOrderAcs GetInstance()
        {
            if (_scmInquiryOrderAcs == null)
            {
                _scmInquiryOrderAcs = new SCMInquiryOrderAcs();
            }

            return _scmInquiryOrderAcs;
        }

        #endregion

        #region ■publicプロパティ
        /// <summary>
        /// SCM受注データ(伝票)テーブル
        /// </summary>
        public SCMAcOdrDataDataSet.SCMInquiryResultDataTable SCMInquiryResultDataTable
        {
            get { return _scmInquiryResultDataTable; }
        }

        /// <summary>
        /// SCM受注データ(明細)テーブル
        /// </summary>
        public SCMAcOdrDataDataSet.SCMInquiryDetailResultDataTable SCMInquiryDetailResultDataTable
        {
            get { return _scmInquiryDetailResultDataTable; }
        }
        #endregion

        #region ■publicメソッド

        /// <summary>
        /// 該当件数取得
        /// </summary>
        /// <param name="scmInquiryOrder"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public int SearchCnt(SCMInquiryOrder scmInquiryOrder, out int count)
        {
            // 検索実行
            int status = this.ExecuteSearchCnt(scmInquiryOrder, out count);

            //Object retArray;
            //count = ((CustomSerializeArrayList)retArray).Count;

            return status;
        }

        // 2010/05/27 Add >>>
        /// <summary>
        /// 明細に未回答データが存在するかチェック
        /// </summary>
        /// <returns></returns>
        public bool DetailExistsNonAnswer()
        {
            SCMAcOdrDataDataSet.SCMInquiryDetailResultRow[] rows = (SCMAcOdrDataDataSet.SCMInquiryDetailResultRow[])this._scmInquiryDetailResultDataTable.Select(string.Format("{0}=0", this._scmInquiryDetailResultDataTable.SetSrcColumn.ColumnName));
            return ( rows != null && rows.Length > 0 );
        }

        /// <summary>
        /// 明細検索（明細表示で使用しているメソッドを利用）
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int SearchDetail(SCMInquiryOrder cndtn, out string msg)
        {
            SCMInquiryResultWork searchCndtn = new SCMInquiryResultWork();

            searchCndtn.EnterpriseCode = cndtn.EnterpriseCode;

            if (cndtn.AcptAnOdrStatus.Length > 0) searchCndtn.AcptAnOdrStatus = cndtn.AcptAnOdrStatus[0];
            if (cndtn.AnswerDivCd.Length > 0) searchCndtn.AnswerDivCd = cndtn.AnswerDivCd[0];
            if (cndtn.InqOrdDivCd.Length > 0) searchCndtn.InqOrdDivCd = cndtn.InqOrdDivCd[0];
            searchCndtn.InqOriginalEpCd = cndtn.InqOriginalEpCd.Trim();//@@@@20230303
            searchCndtn.InqOriginalSecCd = cndtn.InqOriginalSecCd;
            searchCndtn.InqOtherEpCd = cndtn.InqOtherEpCd;
            searchCndtn.InqOtherSecCd = cndtn.InqOtherSecCd;
            searchCndtn.InquiryNumber = cndtn.St_InquiryNumber;
            searchCndtn.SalesSlipNum = cndtn.SalesSlipNum;
            searchCndtn.UpdateDate = cndtn.UpdateDate;
            searchCndtn.UpdateTime = cndtn.UpdateTime;
            return this.SearchDetail(searchCndtn, out msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
        //public int ReturnedGoodsRefusal(SCMInquiryOrder cndtn)
        // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
        public int ReturnedGoodsRefusal(SCMInquiryOrder cndtn, short cancelCndtinDiv)
        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
        {
            return this.ReturnedGoodsRefusalProc(cndtn, cancelCndtinDiv);
        }
        // 2010/05/27 Add <<<

        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
        /// <summary>
        /// 未回答のSCM受注明細データ(問合せ・発注)の「キャンセル状態区分」を更新します。
        /// </summary>
        /// <param name="searchingCondition">検索条件</param>
        /// <param name="cancelCndtinDiv">キャンセル状態区分の値</param>
        /// <returns>処理結果ステータス</returns>
        public int UpdateCancelCndtinDivOfNotAnswered(
            SCMInquiryOrder searchingCondition,
            short cancelCndtinDiv
        )
        {
            // 2パラ目：0…未回答分を対象／1…回答済分を対象
            return UpdateCancelCndtinDiv(searchingCondition, 0, cancelCndtinDiv);
        }
        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

        /// <summary>
        /// 検索処理(明細)
        /// </summary>
        /// <param name="scmInquiryOrder"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public int SearchDetail(SCMInquiryResultWork scmInquiryResultWork, out string errMsg)
        {
            // 初期化
            //this._scmInquiryResultDataTable.Clear();
            this._scmInquiryDetailResultDataTable.Clear();

            errMsg = string.Empty;

            // 検索実行
            Object retArray;
            // 2011/02/14 >>>
            //int status = this.ExecuteSearchDetail(scmInquiryResultWork, out retArray);

            Object retArray2;
            int status = this.ExecuteSearchDetailAll(scmInquiryResultWork, out retArray, out retArray2);
            // 2011/02/14 <<<

            // 2011/03/14 >>>
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
            //    && ( (ArrayList)retArray ).Count != 0)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && ((((ArrayList)retArray ).Count != 0 ) || (((ArrayList)retArray2 ).Count != 0))) 
            // 2011/03/14 <<<
            {
                // 2011/02/14 >>>
                //// DEL 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
                ////this.ExpandRetArrayForDetail((ArrayList)retArray);
                //// DEL 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<
                //// ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
                //this.ExpandRetArrayForDetail((ArrayList)retArray, scmInquiryResultWork);
                //// ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<

                this.ExpandRetArrayForDetail(scmInquiryResultWork, (CustomSerializeArrayList)retArray, (CustomSerializeArrayList)retArray2);
                // 2011/02/14 <<<
            }
            else if (
                (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                // 2011/03/14 >>>
                //&& ((ArrayList)retArray).Count == 0)
                && ( (((ArrayList)retArray ).Count == 0 ) && 
                     (((ArrayList)retArray2 ).Count == 0 )) 
                )
                // 2011/03/14 <<<
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                // 該当なし
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                errMsg = "検索条件に該当するデータが存在しません";
            }
            else
            {
                errMsg = "検索処理でエラーが発生しました";
            }

            return status;
        }
        
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="scmInquiryOrder"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public int Search(SCMInquiryOrder scmInquiryOrder, out string errMsg)
        {
            // 初期化
            this._scmInquiryResultDataTable.Clear();
            this._scmInquiryDetailResultDataTable.Clear();
            this._canInputSalesSlipDictionary.Clear();  // 2011/02/14 Add

            errMsg = string.Empty;

            // 検索実行
            Object retArray;
            int status = this.ExecuteSearch(scmInquiryOrder, out retArray);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && ((CustomSerializeArrayList)retArray).Count != 0)
            {
                this.ExpandRetArray((CustomSerializeArrayList)retArray);
            }
            else if (
                (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && ((ArrayList)retArray).Count == 0)
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                // 該当なし
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                errMsg = "検索条件に該当するデータが存在しません";
            }
            else
            {
                errMsg = "検索処理でエラーが発生しました";
            }

            return status;
        }

        /// <summary>
        /// 検索結果の全行数、自動回答行数、手動回答行数を取得する
        /// </summary>
        /// <param name="allRowCount"></param>
        /// <param name="autoCount"></param>
        /// <param name="manualCount"></param>
        public void GetResultRowCount(out int allRowCount, out int autoCount, out int manualCount)
        {
            allRowCount = 0;
            autoCount = 0;
            manualCount = 0;

            allRowCount = this._scmInquiryResultDataTable.Rows.Count;

            autoCount = this._scmInquiryResultDataTable.Select(
                SCMInquiryResultDataTable.AnswerMethodColumn.ColumnName + " = 0").Length;

            manualCount = allRowCount - autoCount;
        }

        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
        /// <summary>
        /// 明細に「キャンセル要求」が存在するか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :明細にキャンセル状態区分が「10:キャンセル要求」のものが存在します。<br/>
        /// <c>false</c>:明細にキャンセル状態区分が「10:キャンセル要求」のものが存在しません。
        /// </returns>
        public bool ExistsCancellingDetails()
        {
            SCMAcOdrDataDataSet.SCMInquiryDetailResultRow[] rows = (SCMAcOdrDataDataSet.SCMInquiryDetailResultRow[])this._scmInquiryDetailResultDataTable.Select(
                string.Format(
                    "{0}='{1}'",
                    this._scmInquiryDetailResultDataTable.StateColumn.ColumnName,
                    SCMInquiryDBAgent.GetCancelCndtinDivName((short)CancelCndtinDiv.Cancelling)
                )
            );
            return (rows != null && rows.Length > 0);
        }
        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

        #endregion

        #region ■privateメソッド

        /// <summary>
        /// リモート 明細情報取得処理
        /// </summary>
        /// <param name="scmInquiryOrder"></param>
        /// <returns></returns>
        private int ExecuteSearchDetail(SCMInquiryResultWork scmInquiryResultWork, out object retArray)
        {
            retArray = new CustomSerializeArrayList();

            //// リモート抽出条件作成
            //SCMInquiryOrderWork scmInquiryOrderWork;
            //this.SetSCMInquiryOrderWork(scmInquiryResultWork, out scmInquiryOrderWork);

            int status;

            try
            {
                // テストデータ
                status = this.SCMInquiryDB.SearchDetail(out retArray, scmInquiryResultWork, 0, ConstantManagement.LogicalMode.GetData0);
            }
            catch
            {
                status = 1000;
            }

            return status;
        }

        // 2011/02/14 Add >>>
        /// <summary>
        /// リモート 明細情報取得処理
        /// </summary>
        /// <param name="scmInquiryOrder"></param>
        /// <returns></returns>
        private int ExecuteSearchDetailAll(SCMInquiryResultWork scmInquiryResultWork, out object inquiryResultList, out object cancelResultList)
        {
            int status;

            inquiryResultList = null;
            cancelResultList = null;
            try
            {
                status = this.SCMInquiryDB.SearchDetailAll(out inquiryResultList, out cancelResultList, scmInquiryResultWork, 0, ConstantManagement.LogicalMode.GetData0);
            }
            catch
            {
                status = 1000;
            }

            return status;
        }
        // 2011/02/14 Add <<<

        /// <summary>
        /// リモート 対象件数取得処理
        /// </summary>
        /// <param name="scmInquiryOrder"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        private int ExecuteSearchCnt(SCMInquiryOrder scmInquiryOrder, out int cnt)
        {
            cnt = 0;

            // リモート抽出条件作成
            SCMInquiryOrderWork scmInquiryOrderWork;
            this.SetSCMInquiryOrderWork(scmInquiryOrder, out scmInquiryOrderWork);

            int status;

            try
            {
                status = this.SCMInquiryDB.SearchCnt(out cnt, scmInquiryOrder);
            }
            catch
            {
                status = 1000;
            }

            return status;
        }

        /// <summary>
        /// リモート検索処理実行
        /// </summary>
        /// <param name="scmInquiryOrder"></param>
        /// <returns></returns>
        private int ExecuteSearch(SCMInquiryOrder scmInquiryOrder, out object retArray)
        {
            retArray = new CustomSerializeArrayList();

            // リモート抽出条件作成
            SCMInquiryOrderWork scmInquiryOrderWork;
            this.SetSCMInquiryOrderWork(scmInquiryOrder, out scmInquiryOrderWork);

            int status;

            try
            {
                // テストデータ
                //status = this.GetTestData(out retArray);
                status = this.SCMInquiryDB.Search(out retArray, scmInquiryOrderWork, 0, ConstantManagement.LogicalMode.GetData0);
            }
            catch
            {
                status = 1000;
            }

            return status;
        }

        /// <summary>
        /// リモート抽出条件作成
        /// </summary>
        /// <param name="scmInquiryOrder">UI画面データ保持クラス</param>
        /// <param name="scmInquiryOrderWork">リモート抽出条件</param>
        private void SetSCMInquiryOrderWork(SCMInquiryOrder scmInquiryOrder, out SCMInquiryOrderWork scmInquiryOrderWork)
        {
            scmInquiryOrderWork = new SCMInquiryOrderWork();

            scmInquiryOrderWork.EnterpriseCode = scmInquiryOrder.EnterpriseCode; // 共通ヘッダの企業コード
            scmInquiryOrderWork.AnswerDivCd = scmInquiryOrder.AnswerDivCd; // 回答区分

            // --- UPD m.suzuki 2011/06/13 ---------->>>>>
            //scmInquiryOrderWork.St_InquiryDate = scmInquiryOrder.St_InquiryDate; // 問合せ日(開始)
            //scmInquiryOrderWork.Ed_InquiryDate = scmInquiryOrder.Ed_InquiryDate; // 問合せ日(終了)
            scmInquiryOrderWork.St_UpdateDate = scmInquiryOrder.St_InquiryDate; // 更新日(開始)
            scmInquiryOrderWork.Ed_UpdateDate = scmInquiryOrder.Ed_InquiryDate; // 更新日(終了)
            // --- UPD m.suzuki 2011/06/13 ----------<<<<<

            scmInquiryOrderWork.InqOtherEpCd = scmInquiryOrder.InqOtherEpCd; // 問合せ先企業コード
            // 問合せ先拠点コード
            if (scmInquiryOrder.InqOtherSecCd == "00")
            {
                scmInquiryOrderWork.InqOtherSecCd = string.Empty;
            }
            else
            {
                scmInquiryOrderWork.InqOtherSecCd = scmInquiryOrder.InqOtherSecCd;
            }

            scmInquiryOrderWork.St_CustomerCode = scmInquiryOrder.St_CustomerCode; // 得意先コード(開始)
            scmInquiryOrderWork.Ed_CustomerCode = scmInquiryOrder.Ed_CustomerCode; // 得意先コード(終了)

            scmInquiryOrderWork.AwnserMethod = scmInquiryOrder.AwnserMethod; // 回答方法
            scmInquiryOrderWork.AcptAnOdrStatus = scmInquiryOrder.AcptAnOdrStatus; // 受注ステータス
            scmInquiryOrderWork.St_SalesSlipNum = scmInquiryOrder.St_SalesSlipNum; // 伝票番号(開始)
            scmInquiryOrderWork.Ed_SalesSlipNum = scmInquiryOrder.Ed_SalesSlipNum; // 伝票番号(終了)

            scmInquiryOrderWork.InqOrdDivCd = scmInquiryOrder.InqOrdDivCd; // 問合せ・発注種別

            scmInquiryOrderWork.St_InquiryNumber = scmInquiryOrder.St_InquiryNumber; // 問合せ番号(開始)
            scmInquiryOrderWork.Ed_InquiryNumber = scmInquiryOrder.Ed_InquiryNumber; // 問合せ番号(終了)
            // -----ADD gezh 2011 --------------------------------------------------------------------->>>>
            scmInquiryOrderWork.CooperationOptionDiv = scmInquiryOrder.CooperationOptionDiv;// 連携対象区分
            // -----ADD gezh 2011 ---------------------------------------------------------------------<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            scmInquiryOrderWork.St_ExpectedCeDate = scmInquiryOrder.St_ExpectedCeDate; // 入庫予定日（開始）
            scmInquiryOrderWork.Ed_ExpectedCeDate = scmInquiryOrder.Ed_ExpectedCeDate; // 入庫予定日（終了）
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        }

        /// <summary>
        /// TODO:リモート抽出結果展開
        /// </summary>
        /// <param name="retArray"></param>
        private void ExpandRetArray(ArrayList retArray)
        {
            int linkKey = 1;

            foreach (ArrayList salesSlipList in retArray)
            {
                for (int i = 0; i < salesSlipList.Count; i++)
                {
                    //if (i == 0)
                    //{
                        // 問合せ一覧(伝票)結果クラス
                        SCMInquiryResultWork scmInquiryResultWork = (SCMInquiryResultWork)salesSlipList[i];

                        // 問合せ一覧(伝票)テーブルに展開
                        this.SCMInquiryResultDt(scmInquiryResultWork, linkKey);

                        // 2011/02/14 Del >>>
                        //// ADD 2010/04/16 キャンセル対応 ---------->>>>>
                        //// FIXME:全キャンセルを判定するためにキャンセル処理に登録
                        //SCMInquiryDB.Canceler.Entry(scmInquiryResultWork);
                        //// ADD 2010/04/16 キャンセル対応 ----------<<<<<
                        // 2011/02/14 Del <<<
                    //}
                    //else
                    //{
                        //// 問合せ一覧(明細)テーブルに展開
                        //if (salesSlipList[i] is SCMInquiryDtlInqResultWork)
                        //{
                        //    // 明細(問合せ・受注)
                        //    this.SCMInquiryDetailResultDt((SCMInquiryDtlInqResultWork)salesSlipList[i], linkKey);
                        //}
                        //else
                        //{
                        //    // 明細(回答)
                        //    this.SCMInquiryDetailResultDt((SCMInquiryDtlAnsResultWork)salesSlipList[i], linkKey);
                        //}
                    //}
                }

                linkKey++;
            }

            // ソート
            this.SortSCMInquiryResultDataTable();

            // ソート後に行番号を設定
            int rowNumber = 1;
            foreach (DataRow dr in this._scmInquiryResultDataTable.Rows)
            {
                dr[this._scmInquiryResultDataTable.RowNumberColumn.ColumnName] = rowNumber;
                rowNumber++;
            }

        }

        // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
        #region 一部回答用の処理

        /// <summary>空の売上伝票番号</summary>
        private const string NULL_SALES_SLIP_NUM = "000000000";
        /// <summary>空の売上伝票番号を取得します。</summary>
        public static string NullSalesSlipNum { get { return NULL_SALES_SLIP_NUM; } }

        /// <summary>
        /// 回答区分が｢一部回答｣であるか判断します。
        /// </summary>
        /// <param name="answerDivCd">回答区分</param>
        /// <returns>
        /// <c>true</c> :回答区分が 10 の場合、｢一部回答｣と判断します。
        /// </returns>
        public static bool IsPartAnswer(int answerDivCd)
        {
            return answerDivCd.Equals((int)UIData.SCMInquiryOrder.AnswerDivState.Part);
        }

        // ADD 2013/03/29 SCM障害№10503対応 --------------------------------------------->>>>>
        /// <summary>
        /// 回答区分が｢キャンセル｣であるか判断します。
        /// </summary>
        /// <param name="answerDivCd">回答区分</param>
        /// <returns>
        /// <c>true</c> :回答区分が 99 の場合、｢キャンセル｣と判断します。
        /// </returns>
        public static bool IsCancelAnswer(int answerDivCd)
        {
            return answerDivCd.Equals((int)UIData.SCMInquiryOrder.AnswerDivState.Cancel);
        }
        // ADD 2013/03/29 SCM障害№10503対応 ---------------------------------------------<<<<<

        /// <summary>
        /// 検索条件に｢一部回答｣が存在するか判断します。
        /// </summary>
        /// <param name="scmInquiryResultWork">検索条件</param>
        /// <returns>
        /// <c>true</c> :｢一部回答｣が存在します。<br/>
        /// <c>false</c>:｢一部回答｣は存在しません。
        /// </returns>
        /// <exception cref="ArgumentNullException"><c>scmInquiryResultWork</c>が<c>null</c>です。</exception>
        private static bool ExistsPartAnswer(SCMInquiryResultWork scmInquiryResultWork)
        {
            #region GuardPhrase

            if (scmInquiryResultWork == null) throw new ArgumentNullException("scmInquiryResultWork");

            #endregion // GuardPhrase

            return IsPartAnswer(scmInquiryResultWork.AnswerDivCd);
        }

        /// <summary>企業コードの桁数</summary>
        private const int ENTERPRISE_CODE_DIGITS = 16;

        /// <summary>拠点コードの桁数</summary>
        private const int SECTION_CODE_DIGITS = 6;

        /// <summary>問合せ番号の数値フォーマット</summary>
        private const string INQUIRY_NUMBER_FORMAT = "d10";

        /// <summary>問合せ行番号の数値フォーマット</summary>
        private const string INQ_ROW_NUMBER_FORMAT = "d2";

        /// <summary>
        /// 回答済みキーを取得します。
        /// </summary>
        /// <param name="answerData">回答データ</param>
        /// <returns>
        /// 企業コード + 問合せ元企業コード + 問合せ元拠点コード + 問合せ先企業コード + 問合せ先拠点コード + 問合せ番号 + 問合せ行番号
        /// </returns>
        private static string GetAnsweredKey(SCMInquiryDtlAnsResultWork answerData)
        {
            if (answerData == null) return string.Empty;

            StringBuilder key = new StringBuilder();
            {
                key.Append(answerData.EnterpriseCode.PadLeft(ENTERPRISE_CODE_DIGITS, ' '));     // 企業コード
                key.Append(answerData.InqOriginalEpCd.Trim().PadLeft(ENTERPRISE_CODE_DIGITS, ' '));    // 問合せ元企業コード//@@@@20230303
                key.Append(answerData.InqOriginalSecCd.PadLeft(SECTION_CODE_DIGITS, ' '));      // 問合せ元拠点コード
                key.Append(answerData.InqOtherEpCd.PadLeft(ENTERPRISE_CODE_DIGITS, ' '));       // 問合せ先企業コード
                key.Append(answerData.InqOtherSecCd.PadLeft(SECTION_CODE_DIGITS, ' '));         // 問合せ先拠点コード
                key.Append(answerData.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT));           // 問合せ番号
                key.Append(answerData.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));            // 問合せ行番号
            }
            return key.ToString();
        }

        /// <summary>
        /// 回答済みキーを取得します。
        /// </summary>
        /// <param name="detailData">明細データ</param>
        /// <returns>
        /// 企業コード + 問合せ元企業コード + 問合せ元拠点コード + 問合せ先企業コード + 問合せ先拠点コード + 問合せ番号 + 問合せ行番号
        /// </returns>
        private static string GetAnsweredKey(SCMInquiryDtlInqResultWork detailData)
        {
            if (detailData == null) return string.Empty;

            StringBuilder key = new StringBuilder();
            {
                key.Append(detailData.EnterpriseCode.PadLeft(ENTERPRISE_CODE_DIGITS, ' '));     // 企業コード
                key.Append(detailData.InqOriginalEpCd.Trim().PadLeft(ENTERPRISE_CODE_DIGITS, ' '));    // 問合せ元企業コード//@@@@20230303
                key.Append(detailData.InqOriginalSecCd.PadLeft(SECTION_CODE_DIGITS, ' '));      // 問合せ元拠点コード
                key.Append(detailData.InqOtherEpCd.PadLeft(ENTERPRISE_CODE_DIGITS, ' '));       // 問合せ先企業コード
                key.Append(detailData.InqOtherSecCd.PadLeft(SECTION_CODE_DIGITS, ' '));         // 問合せ先拠点コード
                key.Append(detailData.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT));           // 問合せ番号
                key.Append(detailData.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));            // 問合せ行番号
            }
            return key.ToString();
        }

        /// <summary>
        /// 明細データのデータテーブルをソートします。
        /// </summary>
        private void SortSCMInquiryDetailResultDataTable()
        {
            #region GuardPhrase

            if (SCMInquiryDetailResultDataTable.Count < 1) return;

            #endregion // GuardPhrase

            // ソート条件文字列の作成
            StringBuilder orderBy = new StringBuilder();
            {
                // 問合せ行番号
                orderBy.Append(SCMInquiryDetailResultDataTable.RowNumberColumn.ColumnName).Append(" DESC");
            }
            DataView detailView = new DataView(SCMInquiryDetailResultDataTable.Copy());
            detailView.Sort = orderBy.ToString();

            SCMInquiryDetailResultDataTable.Clear();

            foreach (DataRowView dataRowView in detailView)
            {
                SCMInquiryDetailResultDataTable.ImportRow(dataRowView.Row);
            }
        }

        #endregion // 一部回答用の処理
        // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<

        /// <summary>
        /// リモート抽出結果明細情報展開展開
        /// </summary>
        /// <param name="retArray"></param>
        /// <param name="seachingCondition">検索条件</param>
        // 2011/02/14 >>>
        //// DEL 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
        ////private void ExpandRetArrayForDetail(ArrayList retArray)
        //// DEL 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<
        //// ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
        //private void ExpandRetArrayForDetail(ArrayList retArray, SCMInquiryResultWork seachingCondition)
        //// ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<

        private void ExpandRetArrayForDetail(SCMInquiryResultWork seachingCondition, CustomSerializeArrayList inqArrayList, CustomSerializeArrayList cancelArrayList)
        // 2011/02/14 <<<
        {
            // DEL 2010/04/23 明細表示を行うとＳＦで入力した明細順番と逆順で表示される ---------->>>>>
            // キャンセル対応にて、リモートが返す明細データの検索結果内容が変更になったので、これまでの処理は廃止
            #region 削除コード

            //int linkKey = 1;

            //List<SCMInquiryDtlAnsResultWork> ansList = new List<SCMInquiryDtlAnsResultWork>();
            //List<SCMInquiryDtlInqResultWork> inqList = new List<SCMInquiryDtlInqResultWork>();

            //// ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
            //// 回答済み明細データマップ ※検索条件に｢一部回答｣を含む場合に有効です。
            //Dictionary<string, SCMInquiryDtlInqResultWork> answeredDetailMap = new Dictionary<string, SCMInquiryDtlInqResultWork>();
            //// ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<

            //foreach (ArrayList salesSlipList in retArray)
            //{
            //    for (int i = 0; i < salesSlipList.Count; i++)
            //    {
            //        #region 削除コード

            //        //if (i == 0)
            //        //{
            //        //    // 問合せ一覧(伝票)結果クラス
            //        //    SCMInquiryResultWork scmInquiryResultWork = (SCMInquiryResultWork)salesSlipList[i];

            //        //    // 問合せ一覧(伝票)テーブルに展開
            //        //    this.SCMInquiryResultDt(scmInquiryResultWork, linkKey);
            //        //}
            //        //else
            //        //{

            //        //// 問合せ一覧(明細)テーブルに展開
            //        //if (salesSlipList[i] is SCMInquiryDtlAnsResultWork)
            //        //{
            //        //    // 明細(回答)
            //        //    this.SCMInquiryDetailResultDt((SCMInquiryDtlAnsResultWork)salesSlipList[i], linkKey);
            //        //}
            //        //else if (salesSlipList[i] is SCMInquiryDtlInqResultWork)
            //        //{
            //        //    // 明細(問合せ・受注)
            //        //    this.SCMInquiryDetailResultDt((SCMInquiryDtlInqResultWork)salesSlipList[i], linkKey);
            //        //}
            //        //}

            //        #endregion // 削除コード

            //        // 問合せ一覧(明細)テーブルに展開
            //        if (salesSlipList[i] is SCMInquiryDtlAnsResultWork)
            //        {
            //            // 明細(回答)
            //            ansList.Add((SCMInquiryDtlAnsResultWork)salesSlipList[i]);
            //            // ansList.Add((SCMInquiryDtlInqResultWork)salesSlipList[i]);

            //            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
            //            #region 一部回答用の処理

            //            if (ExistsPartAnswer(seachingCondition))
            //            {
            //                // 回答済み明細データマップにキーを登録
            //                string answeredKey = GetAnsweredKey((SCMInquiryDtlAnsResultWork)salesSlipList[i]);
            //                if (!answeredDetailMap.ContainsKey(answeredKey))
            //                {
            //                    answeredDetailMap.Add(answeredKey, null);
            //                }
            //            }

            //            #endregion // 一部回答用の処理
            //            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<
            //        }
            //        else if (salesSlipList[i] is SCMInquiryDtlInqResultWork)
            //        {
            //            // 明細(問合せ・受注)
            //            inqList.Add((SCMInquiryDtlInqResultWork)salesSlipList[i]);

            //            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
            //            #region 一部回答用の処理

            //            if (ExistsPartAnswer(seachingCondition))
            //            {
            //                // 回答済み明細データマップに値を登録
            //                string answeredKey = GetAnsweredKey((SCMInquiryDtlInqResultWork)salesSlipList[i]);
            //                if (answeredDetailMap.ContainsKey(answeredKey))
            //                {
            //                    answeredDetailMap[answeredKey] = (SCMInquiryDtlInqResultWork)salesSlipList[i];
            //                }
            //            }

            //            #endregion // 一部回答用の処理
            //            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<
            //        }
            //    }

            //    linkKey++;
            //}

            //// 明細テーブルを構築
            //if (ansList.Count != 0)
            //{
            //    foreach (SCMInquiryDtlAnsResultWork detail in ansList)
            //    {
            //        this.SCMInquiryDetailResultDt(detail, 0);
            //    }

            //    // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
            //    #region 一部回答用の処理

            //    // 検索条件に｢一部回答｣がある場合、未回答となっている明細データを明細テーブルに追加する
            //    if (ExistsPartAnswer(seachingCondition))
            //    {
            //        // 未回答となっている明細データを明細テーブルに追加
            //        inqList.ForEach(delegate(SCMInquiryDtlInqResultWork detailInq)
            //        {
            //            if (!answeredDetailMap.ContainsKey(GetAnsweredKey(detailInq)))
            //            {
            //                this.SCMInquiryDetailResultDt(detailInq, 0);
            //            }
            //        });
            //    }

            //    #endregion // 一部回答用の処理
            //    // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<
            //}
            //else if (inqList.Count != 0)
            //{
            //    foreach (SCMInquiryDtlInqResultWork detail in inqList)
            //    {
            //        this.SCMInquiryDetailResultDt(detail, 0);
            //    }
            //}

            //// ソート
            //this.SortSCMInquiryResultDataTable();

            //// ソート後に行番号を設定
            //int rowNumber = 1;
            //foreach (DataRow dr in this._scmInquiryResultDataTable.Rows)
            //{
            //    dr[this._scmInquiryResultDataTable.RowNumberColumn.ColumnName] = rowNumber;
            //    rowNumber++;
            //}

            //// ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
            //// 未回答分明細データを後付けで追加しているので、明細テーブルをソート
            //if (answeredDetailMap.Count > 0)
            //{
            //    SortSCMInquiryDetailResultDataTable();
            //}
            //// ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<

            #endregion // 削除コード
            // DEL 2010/04/23 明細表示を行うとＳＦで入力した明細順番と逆順で表示される ----------<<<<<
            // ADD 2010/04/23 明細表示を行うとＳＦで入力した明細順番と逆順で表示される ---------->>>>>
            // 2011/02/14 >>>
            //CustomSerializeArrayList searchedResultList = (CustomSerializeArrayList)retArray;
            //SortedList<string, object> joinSearchedDetailList = SCMInquiryDBAgent.JoinSearchedDetailResult(searchedResultList);
            // ------------ ADD START 2013/02/27 qijh #34752 ---------- >>>>>>
            CustomSerializeArrayList ansList = null;
            // 検索結果の分割処理
            SplitSearchedResult(inqArrayList, out ansList);
            // ------------ ADD END 2013/02/27 qijh #34752 ---------- <<<<<<

            SortedList<string, object> joinSearchedDetailList = SCMInquiryDBAgent.JoinSearchedDetailResult(seachingCondition, inqArrayList, cancelArrayList);
            // 2011/02/14 <<<
            foreach (KeyValuePair<string, object> answerOrDetail in joinSearchedDetailList)
            {
                if (answerOrDetail.Value is SCMInquiryDtlAnsResultWork)
                {
                    // 2011/02/14 >>>
                    //SCMInquiryDetailResultDt((SCMInquiryDtlAnsResultWork)answerOrDetail.Value, 0);
                    //SCMInquiryDetailResultDt((SCMInquiryDtlInqResultWork)answerOrDetail.Value, seachingCondition);// DEL  2013/02/27 qijh #34752
                    // --- ADD 2013/06/04 三戸 2013/06/18配信分 システムテスト障害№19 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    SCMInquiryDetailResultDt((SCMInquiryDtlAnsResultWork)answerOrDetail.Value, seachingCondition);
                    // --- ADD 2013/06/04 三戸 2013/06/18配信分 システムテスト障害№19 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2011/02/14 <<<
                }
                else
                {
                    // 2011/02/14 >>>
                    //SCMInquiryDetailResultDt((SCMInquiryDtlInqResultWork)answerOrDetail.Value, 0);
                    // --- DEL 2013/06/04 三戸 2013/06/18配信分 システムテスト障害№19 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //SCMInquiryDetailResultDt((SCMInquiryDtlInqResultWork)answerOrDetail.Value, seachingCondition);
                    // --- DEL 2013/06/04 三戸 2013/06/18配信分 システムテスト障害№19 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2011/02/14 <<<
                    // ------------ ADD START 2013/02/27 qijh #34752 ---------- >>>>>>
                    SCMInquiryDtlInqResultWork sCMInquiryDtlInqResultWork = (SCMInquiryDtlInqResultWork)answerOrDetail.Value;
                    if (ansList != null && ansList.Count > 0)
                    {
                        // 問合せデータの設定
                        for (int i = 0; i < ansList.Count; i++)
                        {
                            SCMInquiryDtlAnsResultWork sCMInquiryDtlAnsResultWork = (SCMInquiryDtlAnsResultWork)ansList[i];
                            if (sCMInquiryDtlAnsResultWork.InqRowNumber == sCMInquiryDtlInqResultWork.InqRowNumber &&
                                sCMInquiryDtlAnsResultWork.InqRowNumDerivedNo == sCMInquiryDtlInqResultWork.InqRowNumDerivedNo &&
                                sCMInquiryDtlAnsResultWork.InqOrdDivCd == sCMInquiryDtlInqResultWork.InqOrdDivCd)
                            {
                                // PM主管現在個数 
                                sCMInquiryDtlInqResultWork.PmMainMngPrsntCount = sCMInquiryDtlAnsResultWork.PmMainMngPrsntCount;
                                // PM主管棚番
                                sCMInquiryDtlInqResultWork.PmMainMngShelfNo = sCMInquiryDtlAnsResultWork.PmMainMngShelfNo;
                                // PM主管倉庫コード
                                sCMInquiryDtlInqResultWork.PmMainMngWarehouseCd = sCMInquiryDtlAnsResultWork.PmMainMngWarehouseCd;
                                // PM主管倉庫名称
                                sCMInquiryDtlInqResultWork.PmMainMngWarehouseName = sCMInquiryDtlAnsResultWork.PmMainMngWarehouseName;
                                break;
                            }
                        }
                    }
                    SCMInquiryDetailResultDt(sCMInquiryDtlInqResultWork, seachingCondition);
                    // ------------ ADD END 2013/02/27 qijh #34752 ---------- <<<<<<
                }
            }
            // ADD 2010/04/23 明細表示を行うとＳＦで入力した明細順番と逆順で表示される ----------<<<<<
        }

        // ------------ ADD START 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>
        /// 検索結果の分割処理
        /// </summary>
        /// <param name="inqList"></param>
        /// <param name="cancelList"></param>
        internal static void SplitSearchedResult(CustomSerializeArrayList searchedList, out CustomSerializeArrayList answerList)
        {
            answerList = null;
            if (searchedList == null) return;
            for (int index = 0; index < searchedList.Count; index++)
            {
                if (((CustomSerializeArrayList)searchedList[index]).Count > 0)
                {
                    if (((CustomSerializeArrayList)searchedList[index])[0] is SCMInquiryDtlAnsResultWork)
                    {
                        answerList = (CustomSerializeArrayList)searchedList[index];
                    }
                }
            }
        }
        // ------------ ADD END 2013/02/27 qijh #34752 ---------- <<<<<<

        /// <summary>
        /// SCM受注データ、SCM受注データ(車両情報)の展開処理
        /// </summary>
        /// <br>UpdateNote   2019/01/08  譚洪</br>
        /// <br>修正内容     新元号の対応</br>
        /// <param name="scmInquiryResultWork"></param>
        /// <param name="linkKey"></param>
        /// <remarks>
        /// <br>Update Note: 2021/08/26 譚洪</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>           : PMKOBETSU-4182 BLPフル型式消失障害対応</br> 
        /// </remarks>
        private void SCMInquiryResultDt(SCMInquiryResultWork scmInquiryResultWork, int linkKey)
        {
            DataRow row = this._scmInquiryResultDataTable.NewRow();

            row[SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName] = scmInquiryResultWork.AnswerDivCd;
            // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            row[SCMInquiryResultDataTable.AnswerDivCdNameColumn.ColumnName] = SCMInquiryDBAgent.GetAnswerDivCdName(scmInquiryResultWork.AnswerDivCd);
            // ADD 2010/04/16 キャンセル対応 ----------<<<<<
            row[SCMInquiryResultDataTable.InqOtherEpCdColumn.ColumnName] = scmInquiryResultWork.InqOtherEpCd;
            row[SCMInquiryResultDataTable.InqOtherSecCdColumn.ColumnName] = scmInquiryResultWork.InqOtherSecCd;
            row[SCMInquiryResultDataTable.InqOriginalEpCdColumn.ColumnName] = scmInquiryResultWork.InqOriginalEpCd.Trim();//@@@@20230303
            row[SCMInquiryResultDataTable.InqOriginalSecCdColumn.ColumnName] = scmInquiryResultWork.InqOriginalSecCd;
            row[SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName] = scmInquiryResultWork.InqOrdDivCd;
            row[SCMInquiryResultDataTable.UpdateDateColumn.ColumnName] = scmInquiryResultWork.UpdateDate;
            row[SCMInquiryResultDataTable.UpdateTimeColumn.ColumnName] = scmInquiryResultWork.UpdateTime;

            // 回答作成区分
            row[SCMInquiryResultDataTable.AnswerMethodColumn.ColumnName] = scmInquiryResultWork.AwnserMethod;
            // UPD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------------------------------------->>>>>
            //row[SCMInquiryResultDataTable.AnswerMethodNmColumn.ColumnName] = this.GetAnswerMethodName(scmInquiryResultWork.AwnserMethod);
            row[SCMInquiryResultDataTable.AnswerMethodNmColumn.ColumnName] = this.GetAnswerMethodName(scmInquiryResultWork.AwnserMethod,
                                                                                                      scmInquiryResultWork.AutoAnswerCount,
                                                                                                      scmInquiryResultWork.ManualAnswerCount);
            // UPD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------------------------------------<<<<<
            // 更新年月日／更新時分秒ミリ秒
            row[SCMInquiryResultDataTable.UpdateDateColumn.ColumnName] = scmInquiryResultWork.UpdateDate;
            row[SCMInquiryResultDataTable.UpdateTimeColumn.ColumnName] = scmInquiryResultWork.UpdateTime;

            string updateTime = Convert.ToString(scmInquiryResultWork.UpdateTime).PadLeft(9, '0');

            row[SCMInquiryResultDataTable.UpdateDateTimeForDispColumn.ColumnName]
                = scmInquiryResultWork.UpdateDate.ToString("yyyy/MM/dd")
                + " "
                + updateTime.Substring(0, 2) + ":" // 時
                + updateTime.Substring(2, 2) + ":" // 分
                + updateTime.Substring(4, 2) + "." // 秒
                + updateTime.Substring(6, 3); // ミリ秒

            // 発注種別
            row[SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName] = scmInquiryResultWork.InqOrdDivCd;
            row[SCMInquiryResultDataTable.InqOrdDivNameColumn.ColumnName] = this.GetInqOrdDivCdName(scmInquiryResultWork.InqOrdDivCd);

            // 問合せ番号
            row[SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName] = scmInquiryResultWork.InquiryNumber;
            // 得意先
            row[SCMInquiryResultDataTable.CustomerCodeColumn.ColumnName] = scmInquiryResultWork.CustomerCode;
            row[SCMInquiryResultDataTable.CustomerNameColumn.ColumnName] = scmInquiryResultWork.CustomerName;
            // 担当者
            row[SCMInquiryResultDataTable.AnsEmployeeCdColumn.ColumnName] = scmInquiryResultWork.AnsEmployeeCd;
            row[SCMInquiryResultDataTable.AnsEmployeeNmColumn.ColumnName] = scmInquiryResultWork.AnsEmployeeNm;
            // 問合せ日
            if (scmInquiryResultWork.InquiryDate >= 10000000)
            {
                string yyyyMMdd = scmInquiryResultWork.InquiryDate.ToString();
                try
                {
                    int year    = int.Parse(yyyyMMdd.Substring(0, 4));
                    int month   = int.Parse(yyyyMMdd.Substring(4, 2));
                    int day     = int.Parse(yyyyMMdd.Substring(6, 2));
                    DateTime inquiryDateTime = new DateTime(year, month, day);
                    row[SCMInquiryResultDataTable.FormatedInquiryDateColumn.ColumnName] = inquiryDateTime.ToString("yyyy/MM/dd");
                }
                catch
                {
                    // 何もしない
                }
            }
            // 受注ステータス
            row[SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName] = scmInquiryResultWork.AcptAnOdrStatus;
            row[SCMInquiryResultDataTable.AcptAnOdrStatusNmColumn.ColumnName] = this.GetAcptAnOdrStatusName(scmInquiryResultWork.AcptAnOdrStatus);

            // 伝票番号
            row[SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName] = scmInquiryResultWork.SalesSlipNum;
            // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            row[SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName] = GetSalesSlipNumIf(scmInquiryResultWork);
            // ADD 2010/04/16 キャンセル対応 ----------<<<<<

            // 類別番号
            row[SCMInquiryResultDataTable.CategoryNoColumn.ColumnName] = scmInquiryResultWork.CategoryNo;
            // 車種名
            row[SCMInquiryResultDataTable.ModelNameColumn.ColumnName] = scmInquiryResultWork.ModelName;
            // 型式指定番号
            row[SCMInquiryResultDataTable.ModelDesignationNoColumn.ColumnName] = scmInquiryResultWork.ModelDesignationNo;
            // 車両登録番号（プレート番号）
            row[SCMInquiryResultDataTable.NumberPlate4Column.ColumnName] = scmInquiryResultWork.NumberPlate4;
            // 型式(フル型)
            // --- UPD 2021/08/26 譚洪 PMKOBETSU-4182 BLPフル型式消失障害対応 ----->>>>>
            //row[SCMInquiryResultDataTable.FullModelColumn.ColumnName] = scmInquiryResultWork.FullModel;
            if (!string.IsNullOrEmpty(scmInquiryResultWork.FullModel))
            {
                // 型式(フル型)
                row[SCMInquiryResultDataTable.FullModelColumn.ColumnName] = scmInquiryResultWork.FullModel;
            }
            else
            {
                // 車検証型式
                row[SCMInquiryResultDataTable.FullModelColumn.ColumnName] = scmInquiryResultWork.CarInspectCertModel;
            }
            // --- UPD 2021/08/26 譚洪 PMKOBETSU-4182 BLPフル型式消失障害対応 -----<<<<<
            // --- ADD 2012/10/10 三戸 2012/11/14配信分 SCM障害№32 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //車台番号
            // row[SCMInquiryResultDataTable.FrameNoColumn.ColumnName] = scmInquiryResultWork.FrameNo; // DEL 2013/02/19 pengs SCM障害№10433
            // --- ADD 2013/02/19 pengs SCM障害№10433 --------->>>>>>>>>>>>>>>>>>>>>>>>
            int status = 1;
            string frameModel = null;
            string chassisNo = null;
            if (!String.IsNullOrEmpty(scmInquiryResultWork.FrameNo))
            {
                status = SCMSalesDataMaker.GenerateChassisNoFrameFromFrameNo(scmInquiryResultWork.FrameNo, out frameModel, out chassisNo);
            }
            if (status == 0)
                row[SCMInquiryResultDataTable.FrameNoColumn.ColumnName] = chassisNo;
            else
                row[SCMInquiryResultDataTable.FrameNoColumn.ColumnName] = String.Empty;
            // --- ADD 2013/02/19 pengs SCM障害№10433 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/04/05 吉岡 2013/99/99配信 SCM障害№50 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 上記処理の結果、車台番号に何も設定されていない場合は、scmInquiryResultWork.FrameNoを未編集で設定する
            if (row[SCMInquiryResultDataTable.FrameNoColumn.ColumnName].ToString().Equals(string.Empty))
            {
                row[SCMInquiryResultDataTable.FrameNoColumn.ColumnName] = scmInquiryResultWork.FrameNo;
            }
            // ADD 2013/04/05 吉岡 2013/99/99配信 SCM障害№50 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // --- ADD 2012/10/10 三戸 2012/11/14配信分 SCM障害№32 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // 生産年式(YYYYMM)
            row[SCMInquiryResultDataTable.ProduceTypeOfYearNumColumn.ColumnName] = scmInquiryResultWork.ProduceTypeOfYearNum;
            if (scmInquiryResultWork.ProduceTypeOfYearNum >= 100000)
            {
                string yyyymm   = scmInquiryResultWork.ProduceTypeOfYearNum.ToString();
                string yyyy     = yyyymm.Substring(0, 4);
                string mm       = yyyymm.Substring(4, 2);
                if (int.Parse(mm) >= 1 && int.Parse(mm) <= 12)
                {
                    DateTime produceTypeOfYear = new DateTime(int.Parse(yyyy), int.Parse(mm), 1);
                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                    //CultureInfo culture = new CultureInfo("ja-JP", true);
                    //culture.DateTimeFormat.Calendar = new JapaneseCalendar();

                    //row[SCMInquiryResultDataTable.ProduceTypeOfYearStringColumn.ColumnName] = produceTypeOfYear.ToString("ggyy年MM月", culture);
                    row[SCMInquiryResultDataTable.ProduceTypeOfYearStringColumn.ColumnName] = TDateTime.DateTimeToString("GGYYMM", produceTypeOfYear);
                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                }
            }

            // 売上伝票合計（税込み）
            row[SCMInquiryResultDataTable.SalesTotalTaxIncColumn.ColumnName] = scmInquiryResultWork.SalesTotalTaxInc;
            // 明細とのリンクキー
            row[SCMInquiryResultDataTable.DetailLinkKeyNumberColumn.ColumnName] = linkKey;

            // 類別
            row[SCMInquiryResultDataTable.ModelCategoryColumn.ColumnName] = GetModelCategoryText(scmInquiryResultWork);

            // プレートNo
            row[SCMInquiryResultDataTable.PlateNoColumn.ColumnName] = GetPlateNoText(scmInquiryResultWork);
            // 2011/02/14 Add >>>
            row[SCMInquiryResultDataTable.DetailGuidColumn.ColumnName] = Guid.NewGuid();
            row[SCMInquiryResultDataTable.EnterpriseCodeColumn.ColumnName] = scmInquiryResultWork.EnterpriseCode;
            // 2011/02/14 Add <<<
            //--- ADD 2011/05/26 -------------------------------------------------------------------------->>>
            row[SCMInquiryResultDataTable.InqOrdNoteColumn.ColumnName] = scmInquiryResultWork.InqOrdNote;
            row[SCMInquiryResultDataTable.SfPmCprtInstSlipNoColumn.ColumnName] = scmInquiryResultWork.SfPmCprtInstSlipNo;
            //--- ADD 2011/05/26 --------------------------------------------------------------------------<<<
            //--- ADD gezh 2011/11/12 -------------------------------------------------------------------------->>>>>
            //連携対象区分
            row[SCMInquiryResultDataTable.CooperationOptionDivColumn.ColumnName] = scmInquiryResultWork.CooperationOptionDiv;
            if (scmInquiryResultWork.CooperationOptionDiv == 0)
            {
                row[SCMInquiryResultDataTable.CooperationOptionDivColumn.ColumnName] = "PCCforNS";
            }
            else
            {
                row[SCMInquiryResultDataTable.CooperationOptionDivColumn.ColumnName] = "BLﾊﾟｰﾂｵｰﾀﾞｰ";
            }
            //--- ADD gezh 2011/11/12 --------------------------------------------------------------------------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            // 入庫予定日(YYYYMMDD)
            if (scmInquiryResultWork.ExpectedCeDate >= 10000000)
            {
                string yyyyMMdd = scmInquiryResultWork.ExpectedCeDate.ToString();
                try
                {
                    int year = int.Parse(yyyyMMdd.Substring(0, 4));
                    int month = int.Parse(yyyyMMdd.Substring(4, 2));
                    int day = int.Parse(yyyyMMdd.Substring(6, 2));
                    DateTime expectedCeDateTime = new DateTime(year, month, day);
                    row[SCMInquiryResultDataTable.FormatedExpectedCeDateColumn.ColumnName] = expectedCeDateTime.ToString("yyyy/MM/dd");
                }
                catch
                {
                    // 何もしない
                }
            }
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
            this._scmInquiryResultDataTable.Rows.Add(row);
        }

        // ADD 2010/04/16 キャンセル対応 ---------->>>>>
        /// <summary>
        /// 売上伝票番号を取得します。
        /// </summary>
        /// <param name="scmInquiryResultWork">検索されたヘッダデータ</param>
        /// <returns>
        /// ヘッダデータが｢回答完了｣で対応する明細データが複数の伝票に分割されている場合、<c>string.Empty</c>を返します。
        /// それ以外は<c>scmInquiryResultWork.SalesSlipNum</c>を返します。
        /// </returns>
        private string GetSalesSlipNumIf(SCMInquiryResultWork scmInquiryResultWork)
        {
            if (scmInquiryResultWork.AnswerDivCd.Equals((int)AnswerDivCd.AnswerCompletion))
            {
                return SCMInquiryDB.IsOneSlip(scmInquiryResultWork) ? scmInquiryResultWork.SalesSlipNum : string.Empty;
            }
            return scmInquiryResultWork.SalesSlipNum;
        }
        // ADD 2010/04/16 キャンセル対応 ----------<<<<<

        /// <summary>
        /// 類別のテキストを取得します。
        /// </summary>
        /// <param name="scmInquiryResultWork"></param>
        /// <returns>型式指定番号 + 類別番号</returns>
        private static string GetModelCategoryText(SCMInquiryResultWork scmInquiryResultWork)
        {
            return scmInquiryResultWork.ModelDesignationNo.ToString("00000")
                    + "-" +
                    scmInquiryResultWork.CategoryNo.ToString("0000");
        }

        /// <summary>
        /// プレートNoのテキストを取得します。
        /// </summary>
        /// <param name="scmInquiryResultWork"></param>
        /// <returns>
        /// ４項目を連結して表示する
        /// ＸＸＸＸ  999  Ｘ  9999
        /// 例：札幌 300 は 3100
        /// 陸運事務所名称 + 車両登録番号（種別）+車両登録番号（カナ）車両登録番号（プレート番号）
        /// 文字間は半角スペース
        /// </returns>
        private static string GetPlateNoText(SCMInquiryResultWork scmInquiryResultWork)
        {
            const char DELIM = ' ';

            StringBuilder text = new StringBuilder();
            {
                text.Append(scmInquiryResultWork.NumberPlate1Name.Trim()).Append(DELIM);
                text.Append(scmInquiryResultWork.NumberPlate2.Trim()).Append(DELIM);
                text.Append(scmInquiryResultWork.NumberPlate3.Trim()).Append(DELIM);
                if (scmInquiryResultWork.NumberPlate4 != 0) text.Append(scmInquiryResultWork.NumberPlate4.ToString("0000"));
            }
            return text.ToString().Trim().Equals("0") ? string.Empty : text.ToString();
        }

        /// <summary>
        /// SCM受注明細データ(問合せ・発注)の展開処理
        /// </summary>
        /// <param name="scmInquiryResultWork"></param>
        /// <param name="linkKey"></param>
        // 2011/02/14 >>>
        //private void SCMInquiryDetailResultDt(SCMInquiryDtlInqResultWork scmInquiryDtlInqResultWork, int linkKey)
        private void SCMInquiryDetailResultDt(SCMInquiryDtlInqResultWork scmInquiryDtlInqResultWork, SCMInquiryResultWork condition)
        // 2011/02/14 <<<
        {
            DataRow row = this._scmInquiryDetailResultDataTable.NewRow();

            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
            // 問合せ行番号
            row[SCMInquiryDetailResultDataTable.RowNumberColumn.ColumnName] = scmInquiryDtlInqResultWork.InqRowNumber;
            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<

            // BL商品コード
            row[SCMInquiryDetailResultDataTable.BLGoodsCodeColumn.ColumnName] = scmInquiryDtlInqResultWork.BLGoodsCode;
            // 問発商品名
            row[SCMInquiryDetailResultDataTable.GoodsNameColumn.ColumnName] = scmInquiryDtlInqResultWork.InqGoodsName;
            // 商品番号
            row[SCMInquiryDetailResultDataTable.GoodsNoColumn.ColumnName] = scmInquiryDtlInqResultWork.GoodsNo;
            // 商品メーカーコード
            row[SCMInquiryDetailResultDataTable.MakerCodeColumn.ColumnName] = scmInquiryDtlInqResultWork.GoodsMakerCd;
            // メーカー名
            row[SCMInquiryDetailResultDataTable.MakerNameColumn.ColumnName] = this.GetMakerName(scmInquiryDtlInqResultWork.GoodsMakerCd);
            // 発注数
            row[SCMInquiryDetailResultDataTable.SalesOrderCountColumn.ColumnName] = scmInquiryDtlInqResultWork.SalesOrderCount;
            // 納品数
            row[SCMInquiryDetailResultDataTable.DeliveredGoodsCountColumn.ColumnName] = scmInquiryDtlInqResultWork.DeliveredGoodsCount;
            // 定価
            row[SCMInquiryDetailResultDataTable.ListPriceColumn.ColumnName] = scmInquiryDtlInqResultWork.ListPrice;
            // 単価
            row[SCMInquiryDetailResultDataTable.UnitPriceColumn.ColumnName] = scmInquiryDtlInqResultWork.UnitPrice;
            // 売上金額
            row[SCMInquiryDetailResultDataTable.SalesMoneyColumn.ColumnName] = scmInquiryDtlInqResultWork.SalesMoneyTaxExc + scmInquiryDtlInqResultWork.SalesPriceConsTax;
            // 売上金額消費税額
            row[SCMInquiryDetailResultDataTable.SalesPriceConsTaxColumn.ColumnName] = scmInquiryDtlInqResultWork.SalesPriceConsTax;
            // 棚番
            //row[SCMInquiryDetailResultDataTable.ShelfNoColumn.ColumnName] = scmInquiryDtlInqResultWork.ShelfNo;  //DEL 2011/05/26

            //--- ADD 2011/05/26 ------------------------------------------------------>>>
            // 倉庫名
            row[SCMInquiryDetailResultDataTable.WarehouseNameColumn.ColumnName] = scmInquiryDtlInqResultWork.WarehouseName;
            
            // 棚番
            row[SCMInquiryDetailResultDataTable.WarehouseShelfNoColumn.ColumnName] = scmInquiryDtlInqResultWork.WarehouseShelfNo;
            //--- ADD 2011/05/26 ------------------------------------------------------<<<
            
            // 2011/02/14 Del >>>
            //// 明細とのリンクキー
            //row[SCMInquiryDetailResultDataTable.DetailLinkKeyNumberColumn.ColumnName] = linkKey;
            // 2011/02/14 Del <<<

            // 明細備考
            row[SCMInquiryDetailResultDataTable.CommentDtlColumn.ColumnName] = scmInquiryDtlInqResultWork.CommentDtl;

            // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            // 受注ステータス
            row[SCMInquiryDetailResultDataTable.AcptAnOdrStatusColumn.ColumnName] = scmInquiryDtlInqResultWork.AcptAnOdrStatus;
            // 伝票区分
            row[SCMInquiryDetailResultDataTable.SlipNameColumn.ColumnName] = SCMInquiryDBAgent.GetSlipName(scmInquiryDtlInqResultWork.AcptAnOdrStatus);
            // 伝票番号
            row[SCMInquiryDetailResultDataTable.SalesSlipNumColumn.ColumnName] = scmInquiryDtlInqResultWork.SalesSlipNum;
            // ADD 2010/04/16 キャンセル対応 ----------<<<<<

            // 2010/05/27 Add >>>
            row[SCMInquiryDetailResultDataTable.RowNumDerivedNoColumn.ColumnName] = scmInquiryDtlInqResultWork.InqRowNumDerivedNo;
            // 2010/05/27 Add <<<

            // 2011/02/14 >>>
            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            // UNDONE:状態列
            row[SCMInquiryDetailResultDataTable.StateColumn.ColumnName] = SCMInquiryDBAgent.GetCancelCndtinDivName(scmInquiryDtlInqResultWork.CancelCndtinDiv);
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
            
            row[SCMInquiryDetailResultDataTable.CancelCndtinDivColumn.ColumnName] = scmInquiryDtlInqResultWork.CancelCndtinDiv;
            if (condition.AnswerDivCd != 99 && scmInquiryDtlInqResultWork.CancelCndtinDiv == (short)CancelCndtinDiv.Cancelled)
            {
                row[SCMInquiryDetailResultDataTable.InqAnsDivNameColumn.ColumnName] = "取消";
            }
            else
            {
                row[SCMInquiryDetailResultDataTable.StateColumn.ColumnName] = SCMInquiryDBAgent.GetCancelCndtinDivName(scmInquiryDtlInqResultWork.CancelCndtinDiv);
                row[SCMInquiryDetailResultDataTable.InqAnsDivNameColumn.ColumnName] = "未回答";
            }
            // 2011/02/14 <<<
            // ------------ ADD START 2013/02/27 qijh #34752 ---------- >>>>>>
            // PM主管倉庫コード
            row[SCMInquiryDetailResultDataTable.PmMainMngWarehouseCdColumn.ColumnName] = scmInquiryDtlInqResultWork.PmMainMngWarehouseCd;
            // PM主管倉庫名称
            row[SCMInquiryDetailResultDataTable.PmMainMngWarehouseNameColumn.ColumnName] = scmInquiryDtlInqResultWork.PmMainMngWarehouseName;
            // PM主管棚番
            row[SCMInquiryDetailResultDataTable.PmMainMngShelfNoColumn.ColumnName] = scmInquiryDtlInqResultWork.PmMainMngShelfNo;
            // PM主管倉庫ある場合
            if (!scmInquiryDtlInqResultWork.PmMainMngWarehouseCd.Equals(string.Empty))
            {
                // PM主管現在個数
                row[SCMInquiryDetailResultDataTable.PmMainMngPrsntCountColumn.ColumnName] = scmInquiryDtlInqResultWork.PmMainMngPrsntCount;
            }
            // ------------ ADD END 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
            // 商品規格・特記事項(工場向け)
            row[SCMInquiryDetailResultDataTable.GoodsSpecialNtForFacColumn.ColumnName] = scmInquiryDtlInqResultWork.GoodsSpecialNtForFac;
            // 商品規格・特記事項(カーオーナー向け)
            row[SCMInquiryDetailResultDataTable.GoodsSpecialNtForCOwColumn.ColumnName] = scmInquiryDtlInqResultWork.GoodsSpecialNtForCOw;
            // 優良設定詳細名称２(工場向け)
            row[SCMInquiryDetailResultDataTable.PrmSetDtlName2ForFacColumn.ColumnName] = scmInquiryDtlInqResultWork.PrmSetDtlName2ForFac;
            // 優良設定詳細名称２(カーオーナー向け)
            row[SCMInquiryDetailResultDataTable.PrmSetDtlName2ForCOwColumn.ColumnName] = scmInquiryDtlInqResultWork.PrmSetDtlName2ForCOw;
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<

            this._scmInquiryDetailResultDataTable.Rows.Add(row);
        }

        /// <summary>
        /// SCM受注明細データ(回答)の展開処理
        /// </summary>
        /// <param name="scmInquiryResultWork"></param>
        /// <param name="linkKey"></param>
        // 2011/02/14 >>>
        //private void SCMInquiryDetailResultDt(SCMInquiryDtlAnsResultWork scmInquiryDtlAnsResultWork, int linkKey)
        private void SCMInquiryDetailResultDt(SCMInquiryDtlAnsResultWork scmInquiryDtlAnsResultWork, SCMInquiryResultWork condition)
        // 2011/02/14 <<<
        {
            DataRow row = this._scmInquiryDetailResultDataTable.NewRow();

            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ---------->>>>>
            // 問合せ行番号
            row[SCMInquiryDetailResultDataTable.RowNumberColumn.ColumnName] = scmInquiryDtlAnsResultWork.InqRowNumber;
            // ADD 2010/03/31 検索条件に一部回答を含む場合、未回答の明細データが表示されない ----------<<<<<

            // BL商品コード
            row[SCMInquiryDetailResultDataTable.BLGoodsCodeColumn.ColumnName] = scmInquiryDtlAnsResultWork.BLGoodsCode;
            // 回答商品名
            row[SCMInquiryDetailResultDataTable.GoodsNameColumn.ColumnName] = scmInquiryDtlAnsResultWork.AnsGoodsName;
            // 商品番号
            row[SCMInquiryDetailResultDataTable.GoodsNoColumn.ColumnName] = scmInquiryDtlAnsResultWork.GoodsNo;
            // 商品メーカーコード
            row[SCMInquiryDetailResultDataTable.MakerCodeColumn.ColumnName] = scmInquiryDtlAnsResultWork.GoodsMakerCd;
            // メーカー名
            row[SCMInquiryDetailResultDataTable.MakerNameColumn.ColumnName] = this.GetMakerName(scmInquiryDtlAnsResultWork.GoodsMakerCd);
            // 発注数
            row[SCMInquiryDetailResultDataTable.SalesOrderCountColumn.ColumnName] = scmInquiryDtlAnsResultWork.SalesOrderCount;
            // 納品数
            row[SCMInquiryDetailResultDataTable.DeliveredGoodsCountColumn.ColumnName] = scmInquiryDtlAnsResultWork.DeliveredGoodsCount;
            // 定価
            row[SCMInquiryDetailResultDataTable.ListPriceColumn.ColumnName] = scmInquiryDtlAnsResultWork.ListPrice;
            // 単価
            row[SCMInquiryDetailResultDataTable.UnitPriceColumn.ColumnName] = scmInquiryDtlAnsResultWork.UnitPrice;
            // 売上金額
            row[SCMInquiryDetailResultDataTable.SalesMoneyColumn.ColumnName] = scmInquiryDtlAnsResultWork.SalesMoneyTaxExc + scmInquiryDtlAnsResultWork.SalesPriceConsTax;
            // 売上金額消費税額
            row[SCMInquiryDetailResultDataTable.SalesPriceConsTaxColumn.ColumnName] = scmInquiryDtlAnsResultWork.SalesPriceConsTax;
            // 棚番
            //row[SCMInquiryDetailResultDataTable.ShelfNoColumn.ColumnName] = scmInquiryDtlAnsResultWork.ShelfNo;  //DEL 2011/05/26

            //--- ADD 2011/05/26 ------------------------------------------------------>>>
            // 倉庫名
            row[SCMInquiryDetailResultDataTable.WarehouseNameColumn.ColumnName] = scmInquiryDtlAnsResultWork.WarehouseName;

            // 棚番
            row[SCMInquiryDetailResultDataTable.WarehouseShelfNoColumn.ColumnName] = scmInquiryDtlAnsResultWork.WarehouseShelfNo;
            //--- ADD 2011/05/26 ------------------------------------------------------<<<
            
            // 2011/02/14 Del >>>
            //// 明細とのリンクキー
            //row[SCMInquiryDetailResultDataTable.DetailLinkKeyNumberColumn.ColumnName] = linkKey;
            // 2011/02/14 Del <<<

            // リサイクル種別コード
            row[SCMInquiryDetailResultDataTable.RecyclePrtKindCodeColumn.ColumnName] = scmInquiryDtlAnsResultWork.RecyclePrtKindCode;
            // リサイクル種別名称
            row[SCMInquiryDetailResultDataTable.RecyclePrtKindNameColumn.ColumnName] = scmInquiryDtlAnsResultWork.RecyclePrtKindName;
            // 明細備考
            row[SCMInquiryDetailResultDataTable.CommentDtlColumn.ColumnName] = scmInquiryDtlAnsResultWork.CommentDtl;

            // ADD 2010/04/16 キャンセル対応 ---------->>>>>
            // 受注ステータス
            row[SCMInquiryDetailResultDataTable.AcptAnOdrStatusColumn.ColumnName] = scmInquiryDtlAnsResultWork.AcptAnOdrStatus;
            // 伝票区分
            row[SCMInquiryDetailResultDataTable.SlipNameColumn.ColumnName] = SCMInquiryDBAgent.GetSlipName(scmInquiryDtlAnsResultWork.AcptAnOdrStatus);
            // 伝票番号
            row[SCMInquiryDetailResultDataTable.SalesSlipNumColumn.ColumnName] = scmInquiryDtlAnsResultWork.SalesSlipNum;
            // ADD 2010/04/16 キャンセル対応 ----------<<<<<

            // 2010/05/27 Add >>>
            row[SCMInquiryDetailResultDataTable.SetSrcColumn.ColumnName] = 1;
            row[SCMInquiryDetailResultDataTable.RowNumDerivedNoColumn.ColumnName] = scmInquiryDtlAnsResultWork.InqRowNumDerivedNo;
            // 2010/05/27 Add <<<
            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            // UNDONE:状態列
            row[SCMInquiryDetailResultDataTable.StateColumn.ColumnName] = SCMInquiryDBAgent.GetCancelCndtinDivName(scmInquiryDtlAnsResultWork.CancelCndtinDiv);
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
            // 2011/01/24 Add >>>
            row[SCMInquiryDetailResultDataTable.InqAnsDivNameColumn.ColumnName] = "回答完了";
            // 2011/01/24 Add <<<
            // ------------ ADD START 2013/02/27 qijh #34752 ---------- >>>>>>
            // PM主管倉庫コード
            row[SCMInquiryDetailResultDataTable.PmMainMngWarehouseCdColumn.ColumnName] = scmInquiryDtlAnsResultWork.PmMainMngWarehouseCd;
            // PM主管倉庫名称
            row[SCMInquiryDetailResultDataTable.PmMainMngWarehouseNameColumn.ColumnName] = scmInquiryDtlAnsResultWork.PmMainMngWarehouseName;
            // PM主管棚番
            row[SCMInquiryDetailResultDataTable.PmMainMngShelfNoColumn.ColumnName] = scmInquiryDtlAnsResultWork.PmMainMngShelfNo;
            // PM主管倉庫ある場合
            if (!scmInquiryDtlAnsResultWork.PmMainMngWarehouseCd.Equals(string.Empty))
            {
                // PM主管現在個数
                row[SCMInquiryDetailResultDataTable.PmMainMngPrsntCountColumn.ColumnName] = scmInquiryDtlAnsResultWork.PmMainMngPrsntCount;
            }
            // ------------ ADD END 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
            // 商品規格・特記事項(工場向け)
            row[SCMInquiryDetailResultDataTable.GoodsSpecialNtForFacColumn.ColumnName] = scmInquiryDtlAnsResultWork.GoodsSpecialNtForFac;
            // 商品規格・特記事項(カーオーナー向け)
            row[SCMInquiryDetailResultDataTable.GoodsSpecialNtForCOwColumn.ColumnName] = scmInquiryDtlAnsResultWork.GoodsSpecialNtForCOw;
            // 優良設定詳細名称２(工場向け)
            row[SCMInquiryDetailResultDataTable.PrmSetDtlName2ForFacColumn.ColumnName] = scmInquiryDtlAnsResultWork.PrmSetDtlName2ForFac;
            // 優良設定詳細名称２(カーオーナー向け)
            row[SCMInquiryDetailResultDataTable.PrmSetDtlName2ForCOwColumn.ColumnName] = scmInquiryDtlAnsResultWork.PrmSetDtlName2ForCOw;
            // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<

            this._scmInquiryDetailResultDataTable.Rows.Add(row);
        }

        /// <summary>
        /// ソート処理
        /// </summary>
        private void SortSCMInquiryResultDataTable()
        {
            // ソート条件文字列の作成
            StringBuilder sortSb = new StringBuilder();
            //>>>2010/03/10
            //sortSb.Append(this._scmInquiryResultDataTable.InqOtherEpCdColumn.ColumnName); // 先企業
            //sortSb.Append(", ");
            //sortSb.Append(this._scmInquiryResultDataTable.InqOtherSecCdColumn.ColumnName); // 先拠点
            //sortSb.Append(", ");
            //sortSb.Append(this._scmInquiryResultDataTable.CustomerCodeColumn.ColumnName);　// 得意先
            //sortSb.Append(", ");
            //sortSb.Append(this._scmInquiryResultDataTable.InquiryNumberColumn.ColumnName); // 問合せ番号
            //sortSb.Append(", ");
            //sortSb.Append(this._scmInquiryResultDataTable.InqOrdDivCdColumn.ColumnName);// 問合せ・発注種別

            sortSb.Append(this._scmInquiryResultDataTable.InquiryNumberColumn.ColumnName); // 問合せ番号
            sortSb.Append(" DESC , ");
            sortSb.Append(this._scmInquiryResultDataTable.UpdateDateColumn.ColumnName);// 更新日付
            sortSb.Append(" DESC, ");
            sortSb.Append(this._scmInquiryResultDataTable.UpdateTimeColumn.ColumnName);// 更新時刻
            sortSb.Append(" DESC");
            //<<<2010/03/10
            DataView dv = new DataView(this._scmInquiryResultDataTable.Copy());
            dv.Sort = sortSb.ToString();

            this._scmInquiryResultDataTable.Clear();

            foreach (DataRowView drv in dv)
            {
                this._scmInquiryResultDataTable.ImportRow(drv.Row);
            }
        }

        // 2010/05/27 Add >>>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
        //private int ReturnedGoodsRefusalProc(SCMInquiryOrder cndtn)
        // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
        private int ReturnedGoodsRefusalProc(SCMInquiryOrder cndtn, short cancelCndtionDiv)
        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
        {
            #region データを一旦読み込む

            IOWriteSCMReadWork readPara = new IOWriteSCMReadWork();
            readPara.EnterpriseCode = cndtn.EnterpriseCode;
            readPara.InquiryNumber = cndtn.St_InquiryNumber;
            readPara.InqOtherSecCd = cndtn.InqOtherSecCd;
            readPara.InqOriginalEpCd = cndtn.InqOriginalEpCd.Trim();//@@@@20230303
            readPara.InqOriginalSecCd = cndtn.InqOriginalSecCd;
            readPara.AnswerDivCds = cndtn.AnswerDivCd;
            readPara.CancelDivs = new short[] { 1 };    // 2011/03/07 Add

            IIOWriteScmDB ioWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
            object retObj = new CustomSerializeArrayList();
            int status = ioWriteScmDB.ScmRead(ref retObj, (object)readPara);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
            SCMAcOdrDataWork scmHeaderWork;
            SCMAcOdrDtCarWork scmCarWork;
            List<SCMAcOdrDtlIqWork> scmDetailWorkList = new List<SCMAcOdrDtlIqWork>();
            List<SCMAcOdrDtlAsWork> scmAnswerWorkList = new List<SCMAcOdrDtlAsWork>();

            //-----------------------------------------------------------------------------
            // データ分割
            //-----------------------------------------------------------------------------
            IOWriterUtil.ExpandSCMReadRet(retObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmCarWork);

            #endregion

            #region SCMReadは、全キャンセルデータが抽出されるので、読み込んだ中から今回キャンセル拒否するデータを抽出

            // 抽出済みの明細から、未回答分のデータを取得する
            List<SCMAcOdrDtlIqWork> targetDetailWorkList = new List<SCMAcOdrDtlIqWork>();
            SCMAcOdrDataDataSet.SCMInquiryDetailResultRow[] rows = (SCMAcOdrDataDataSet.SCMInquiryDetailResultRow[])this._scmInquiryDetailResultDataTable.Select(string.Format("{0}=0", this._scmInquiryDetailResultDataTable.SetSrcColumn.ColumnName));

            foreach (SCMAcOdrDataDataSet.SCMInquiryDetailResultRow row in rows)
            {
                SCMAcOdrDtlIqWork target = scmDetailWorkList.Find(
                    delegate(SCMAcOdrDtlIqWork data)
                    {
                        // 他のキー項目が一致していることが前提
                        if (data.InqRowNumber == row.RowNumber &&
                            data.InqRowNumDerivedNo == row.RowNumDerivedNo) return true;

                        return false;
                    });
                if (target != null) targetDetailWorkList.Add(target);
            }

            // この時点で、今回キャンセル拒否する分に絞り込まれる

            #endregion

            #region 書込みパラメータの生成
            
            DateTime today = DateTime.Today;
            int now = DateTime.Now.TimeOfDay.Hours * 10000000 + DateTime.Now.TimeOfDay.Minutes * 100000 + DateTime.Now.TimeOfDay.Seconds * 1000 + DateTime.Now.TimeOfDay.Milliseconds;

            // ヘッダ
            SCMAcOdrDataWork writeHeader = this.CreateSCMAcOdrDataWork(scmHeaderWork, today, now);

            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            // 明細（問合せ・発注）
            targetDetailWorkList.ForEach(delegate(SCMAcOdrDtlIqWork data)
            {
                data.CancelCndtinDiv = cancelCndtionDiv;
            });
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

            // 明細（回答）
            List<SCMAcOdrDtlAsWork> writeDetailList = new List<SCMAcOdrDtlAsWork>();
            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            // 「キャンセル状態区分」に「20:キャンセル却下」を設定する場合のみ回答データを更新
            if (cancelCndtionDiv == (short)CancelCndtinDiv.Rejected)
            {
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
                foreach (SCMAcOdrDtlIqWork work in targetDetailWorkList)
                {
                    SCMAcOdrDtlAsWork writeData = this.CreateSCMAcOdrDtlAsWork(work, today, now);

                    SCMAcOdrDtlAsWork justbeforeAnswer = scmAnswerWorkList.Find(
                        delegate(SCMAcOdrDtlAsWork data)
                        {
                            if (data.InqOrdDivCd == 2 &&
                                data.InqRowNumber == work.InqRowNumber &&
                                data.InqRowNumDerivedNo == work.InqRowNumDerivedNo) return true;
                            return false;
                        });

                    if (justbeforeAnswer != null)
                    {
                        writeData.StockDiv = justbeforeAnswer.StockDiv;
                    }

                    writeDetailList.Add(writeData);
                }
            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            }
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

            // 車両
            SCMAcOdrDtCarWork writeCar = this.CreateSCMAcOdrDtCarWork(scmCarWork, today, now);

            CustomSerializeArrayList writePara = new CustomSerializeArrayList();

            CustomSerializeArrayList oneInquiryList = new CustomSerializeArrayList();
            // ヘッダ
            oneInquiryList.Add(writeHeader);
            // 車両（重複するので追加しない）
            //oneInquiryList.Add(writeCar);

            // 2011/02/17 Del >>>
            // 問合せ・発注側は更新しない
            //// ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            //// 明細（問合せ・発注）
            //ArrayList writeIqDetailList = new ArrayList();
            //foreach (SCMAcOdrDtlIqWork work in targetDetailWorkList)
            //{
            //    writeIqDetailList.Add(work);
            //}
            //oneInquiryList.Add(writeIqDetailList);
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
            // 2011/02/17 Del <<<

            // 明細（回答）
            ArrayList al = new ArrayList();
            foreach (SCMAcOdrDtlAsWork work in writeDetailList)
            {
                al.Add(work);
            }
            if (al.Count > 0)   // ADD 2010/06/17 キャンセル追加対応
            {
                oneInquiryList.Add(al);
            }

            writePara.Add(oneInquiryList);
            #endregion

            object paraObj = (object)writePara;
            status = ioWriteScmDB.ScmWrite(ref paraObj, 1);

            // 2011/02/18 Add >>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SCMAcOdrDataWork witescmHeaderWork;
                SCMAcOdrDtCarWork witescmCarWork;
                List<SCMAcOdrDtlIqWork> witescmDetailWorkList = new List<SCMAcOdrDtlIqWork>();
                List<SCMAcOdrDtlAsWork> witescmAnswerWorkList = new List<SCMAcOdrDtlAsWork>();

                //-----------------------------------------------------------------------------
                // データ分割
                //-----------------------------------------------------------------------------
                ExpandSCMWriteRet(paraObj, out witescmHeaderWork, out witescmDetailWorkList, out witescmAnswerWorkList, out witescmCarWork);

                List<ISCMOrderHeaderRecord> sendHeaderList = null;
                List<ISCMOrderAnswerRecord> sendAnswerList = null;
                List<ISCMOrderDetailRecord> sendDetailList = new List<ISCMOrderDetailRecord>();
                List<ISCMOrderCarRecord> sendCarList = null;
                if (witescmHeaderWork != null)
                {
                    sendHeaderList = new List<ISCMOrderHeaderRecord>();
                    sendHeaderList.Add(new UserSCMOrderHeaderRecord(witescmHeaderWork));
                }
                if (witescmAnswerWorkList != null)
                {
                    sendAnswerList = new List<ISCMOrderAnswerRecord>();
                    foreach (SCMAcOdrDtlAsWork ans in witescmAnswerWorkList)
                    {
                        sendAnswerList.Add(new UserSCMOrderAnswerRecord(ans));
                    }
                }
                sendCarList = new List<ISCMOrderCarRecord>();
                sendCarList.Add(new UserSCMOrderCarRecord(writeCar));
                //if (witescmCarWork != null)
                //{
                //    sendCarList = new List<ISCMOrderCarRecord>();
                //    sendCarList.Add(new UserSCMOrderCarRecord(writeCar));
                //}

                if (sendHeaderList != null)
                {
                    SCMSendController sender = new SCMMethodCalledController(
                        sendHeaderList,
                        sendCarList,
                        sendDetailList,
                        sendAnswerList);

                    sender.OpenLog();
                    status = sender.Send();
                    sender.CloseLog();
                }
            }
            // 2011/02/18 Add <<<

            return status;
        }

        // 2011/02/18 Add >>>
        /// <summary>
        /// IOWriter.SCMWriteの戻り値の展開処理
        /// </summary>
        /// <param name="header"></param>
        /// <param name="detail"></param>
        /// <param name="answer"></param>
        /// <param name="car"></param>
        /// <param name="retObject">IOWriter.SCMReadの戻り値</param>
        private static void ExpandSCMWriteRet(object retObject, out SCMAcOdrDataWork header, out List<SCMAcOdrDtlIqWork> detail, out List<SCMAcOdrDtlAsWork> answer, out SCMAcOdrDtCarWork car)
        {
            header = new SCMAcOdrDataWork();
            detail = new List<SCMAcOdrDtlIqWork>();
            answer = new List<SCMAcOdrDtlAsWork>();
            car = new SCMAcOdrDtCarWork();

            CustomSerializeArrayList retList = (CustomSerializeArrayList)retObject;

            foreach (object ret in retList)
            {
                if (ret is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList oneList = (CustomSerializeArrayList)ret;

                    foreach (object work in oneList)
                    {
                        if (work is SCMAcOdrDataWork)
                        {
                            header = (SCMAcOdrDataWork)work;
                        }
                        else if (work is SCMAcOdrDtCarWork)
                        {
                            car = (SCMAcOdrDtCarWork)work;
                        }
                        else
                        {
                            foreach (object dtl in (ArrayList)work)
                            {
                                if (dtl is SCMAcOdrDtlIqWork)
                                {
                                    detail.Add((SCMAcOdrDtlIqWork)dtl);
                                }
                                else
                                {
                                    answer.Add((SCMAcOdrDtlAsWork)dtl);
                                }
                            }
                        }

                    }
                }
            }
        }       
        // 2011/02/18 Add <<<

        // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
        /// <summary>
        /// UNDONE:SCM受注明細データ(問合せ・発注)の「キャンセル状態区分」を更新します。
        /// </summary>
        /// <remarks>ReturnedGoodsRefusalProc()メソッドを参考</remarks>
        /// <param name="cndtn">検索条件</param>
        /// <param name="setSrc">
        /// <c>0</c>:未回答分を対象
        /// <c>1</c>:回答済分を対象
        /// </param>
        /// <param name="cancelCndtinDiv">キャンセル状態区分の値</param>
        /// <returns>処理結果ステータス</returns>
        private int UpdateCancelCndtinDiv(
            SCMInquiryOrder cndtn,
            int setSrc,
            short cancelCndtinDiv
        )
        {
            #region データを一旦読み込む

            IOWriteSCMReadWork readPara = new IOWriteSCMReadWork();
            readPara.EnterpriseCode = cndtn.EnterpriseCode;
            readPara.InquiryNumber = cndtn.St_InquiryNumber;
            readPara.InqOtherSecCd = cndtn.InqOtherSecCd;
            readPara.InqOriginalEpCd = cndtn.InqOriginalEpCd.Trim();//@@@@20230303
            readPara.InqOriginalSecCd = cndtn.InqOriginalSecCd;
            readPara.AnswerDivCds = cndtn.AnswerDivCd;

            IIOWriteScmDB ioWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
            object retObj = new CustomSerializeArrayList();
            int status = ioWriteScmDB.ScmRead(ref retObj, (object)readPara);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
            SCMAcOdrDataWork scmHeaderWork;
            SCMAcOdrDtCarWork scmCarWork;
            List<SCMAcOdrDtlIqWork> scmDetailWorkList = new List<SCMAcOdrDtlIqWork>();
            List<SCMAcOdrDtlAsWork> scmAnswerWorkList = new List<SCMAcOdrDtlAsWork>();

            //-----------------------------------------------------------------------------
            // データ分割
            //-----------------------------------------------------------------------------
            IOWriterUtil.ExpandSCMReadRet(retObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmCarWork);

            #endregion

            #region SCMReadは、全データが抽出されるので、読み込んだ中から今回対象とするデータを抽出

            // 抽出済みの明細から、未回答分のデータを取得する
            List<SCMAcOdrDtlIqWork> targetDetailWorkList = new List<SCMAcOdrDtlIqWork>();
            SCMAcOdrDataDataSet.SCMInquiryDetailResultRow[] rows = (SCMAcOdrDataDataSet.SCMInquiryDetailResultRow[])this._scmInquiryDetailResultDataTable.Select(
                string.Format(
                    "{0}={1}",
                    this._scmInquiryDetailResultDataTable.SetSrcColumn.ColumnName,
                    setSrc
                )
            );

            foreach (SCMAcOdrDataDataSet.SCMInquiryDetailResultRow row in rows)
            {
                SCMAcOdrDtlIqWork target = scmDetailWorkList.Find(
                    delegate(SCMAcOdrDtlIqWork data)
                    {
                        // 他のキー項目が一致していることが前提
                        if (data.InqRowNumber == row.RowNumber &&
                            data.InqRowNumDerivedNo == row.RowNumDerivedNo) return true;

                        return false;
                    });
                if (target != null) targetDetailWorkList.Add(target);
            }

            // この時点で、今回対象とする分に絞り込まれる

            #endregion

            #region 書込みパラメータの生成

            DateTime today = DateTime.Today;
            int now = DateTime.Now.TimeOfDay.Hours * 10000000 + DateTime.Now.TimeOfDay.Minutes * 100000 + DateTime.Now.TimeOfDay.Seconds * 1000 + DateTime.Now.TimeOfDay.Milliseconds;

            // ヘッダ
            SCMAcOdrDataWork writeHeader = this.CreateSCMAcOdrDataWork(scmHeaderWork, today, now);

            // 明細
            targetDetailWorkList.ForEach(delegate(SCMAcOdrDtlIqWork idrDtlIqWork)
            {
                // キャンセル要求となっている明細の「キャンセル区分」を変更する
                if (idrDtlIqWork.CancelCndtinDiv.Equals((int)CancelCndtinDiv.Cancelling))
                {
                    idrDtlIqWork.CancelCndtinDiv = cancelCndtinDiv;
                }
            });

            // 車両
            SCMAcOdrDtCarWork writeCar = this.CreateSCMAcOdrDtCarWork(scmCarWork, today, now);

            CustomSerializeArrayList writePara = new CustomSerializeArrayList();

            CustomSerializeArrayList oneInquiryList = new CustomSerializeArrayList();
            // ヘッダ
            oneInquiryList.Add(writeHeader);
            // 車両（重複するので追加しない）
            //oneInquiryList.Add(writeCar);

            // 明細
            ArrayList al = new ArrayList();
            foreach (SCMAcOdrDtlIqWork work in targetDetailWorkList)
            {
                al.Add(work);
            }

            oneInquiryList.Add(al);

            writePara.Add(oneInquiryList);
            #endregion

            object paraObj = (object)writePara;
            status = ioWriteScmDB.ScmWrite(ref paraObj, 1);

            return status;
        }
        // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

        /// <summary>
        /// SCM受注データの生成
        /// </summary>
        /// <param name="src">元データ(キャンセルデータ)</param>
        /// <param name="updateDate">更新日付</param>
        /// <param name="updateTime">更新時間</param>
        /// <returns></returns>
        private SCMAcOdrDataWork CreateSCMAcOdrDataWork(SCMAcOdrDataWork src, DateTime updateDate, int updateTime)
        {
            SCMAcOdrDataWork retValue = new SCMAcOdrDataWork();

            #region 元データからセットできる項目
            //retValue.CreateDateTime = src.CreateDateTime;               // 作成日時
            //retValue.UpdateDateTime = src.UpdateDateTime;               // 更新日時
            retValue.EnterpriseCode = src.EnterpriseCode;               // 企業コード
            //retValue.FileHeaderGuid = src.FileHeaderGuid;               // GUID
            //retValue.UpdEmployeeCode = src.UpdEmployeeCode;             // 更新従業員コード
            //retValue.UpdAssemblyId1 = src.UpdAssemblyId1;               // 更新アセンブリID1
            //retValue.UpdAssemblyId2 = src.UpdAssemblyId2;               // 更新アセンブリID2
            //retValue.LogicalDeleteCode = src.LogicalDeleteCode;         // 論理削除区分
            retValue.InqOriginalEpCd = src.InqOriginalEpCd.Trim();             // 問合せ元企業コード//@@@@20230303
            retValue.InqOriginalSecCd = src.InqOriginalSecCd;           // 問合せ元拠点コード
            retValue.InqOtherEpCd = src.InqOtherEpCd;                   // 問合せ先企業コード
            retValue.InqOtherSecCd = src.InqOtherSecCd;                 // 問合せ先拠点コード
            retValue.InquiryNumber = src.InquiryNumber;                 // 問合せ番号
            retValue.CustomerCode = src.CustomerCode;                   // 得意先コード
            //retValue.UpdateDate = src.UpdateDate;                       // 更新年月日
            //retValue.UpdateTime = src.UpdateTime;                       // 更新時間
            retValue.AnswerDivCd = src.AnswerDivCd;                     // 回答区分
            retValue.JudgementDate = src.JudgementDate;                 // 確定日
            retValue.InqOrdNote = src.InqOrdNote;                       // 問合せ・発注備考
            retValue.AppendingFile = src.AppendingFile;                 // 添付ファイル
            retValue.AppendingFileNm = src.AppendingFileNm;             // 添付ファイル名
            retValue.InqEmployeeCd = src.InqEmployeeCd;                 // 問合せ従業員コード
            retValue.InqEmployeeNm = src.InqEmployeeNm;                 // 問合せ従業員名称
            //retValue.AnsEmployeeCd = src.AnsEmployeeCd;                 // 回答従業員コード
            //retValue.AnsEmployeeNm = src.AnsEmployeeNm;                 // 回答従業員名称
            retValue.InquiryDate = src.InquiryDate;                     // 問合せ日
            //retValue.AcptAnOdrStatus = src.AcptAnOdrStatus;             // 受注ステータス
            //retValue.SalesSlipNum = src.SalesSlipNum;                   // 売上伝票番号
            //retValue.SalesTotalTaxInc = src.SalesTotalTaxInc;           // 売上伝票合計（税込み）
            //retValue.SalesSubtotalTax = src.SalesSubtotalTax;           // 売上小計（税）
            retValue.InqOrdDivCd = src.InqOrdDivCd;                     // 問合せ・発注種別
            //retValue.InqOrdAnsDivCd = src.InqOrdAnsDivCd;               // 問発・回答種別
            retValue.ReceiveDateTime = src.ReceiveDateTime;             // 受信日時
            //retValue.AnswerCreateDiv = src.AnswerCreateDiv;             // 回答作成区分
            retValue.CancelDiv = src.CancelDiv;                         // キャンセル区分
            retValue.CMTCooprtDiv = src.CMTCooprtDiv;                   // CMT連携区分
            retValue.AnswerDivCd = (int)AnswerDivCd.AnswerCompletion;   // 2011/02/18 Add
            // --- ADD 2013/10/18 Y.Wakita №84 ---------->>>>>
            retValue.AcceptOrOrderKind = src.AcceptOrOrderKind;         // 受発注種別
            // --- ADD 2013/10/18 Y.Wakita №84 ----------<<<<<

            #endregion

            #region 補正する項目

            // 2011/02/18 Del >>>
            //retValue.UpdateDate = updateDate;       // 更新年月日
            //retValue.UpdateTime = updateTime;       // 更新時間
            // 2011/02/18 Del <<<

            retValue.AcptAnOdrStatus = 0;           // 受注ステータス
            retValue.SalesSlipNum = "000000000";    // 売上伝票番号

            retValue.InqOrdAnsDivCd = 2;            // 問発・回答種別
            retValue.AnswerCreateDiv = 1;           // 回答作成区分

            retValue.SalesTotalTaxInc = 0;           // 売上伝票合計（税込み）
            retValue.SalesSubtotalTax = 0;           // 売上小計（税）

            CustomerInfo customerInfo = this.GetCustomerInfo(src.CustomerCode);
            if (customerInfo != null)
            {
                retValue.AnsEmployeeCd = customerInfo.CustomerAgentCd;  // 回答従業員コード
                retValue.AnsEmployeeNm = customerInfo.CustomerAgentNm;  // 回答従業員名称
            }
            // ADD 2013/12/02 商品保証部Redmine#783対応 ----------------------------------------->>>>>
            if (retValue.AnsEmployeeCd.Trim().Length == 0)
            {
                retValue.AnsEmployeeCd = LoginInfoAcquisition.Employee.EmployeeCode; // 回答従業員コード
                retValue.AnsEmployeeNm = LoginInfoAcquisition.Employee.Name;         // 回答従業員名称
            }
            // ADD 2013/12/02 商品保証部Redmine#783対応 -----------------------------------------<<<<<


            // 従業員はどうする？

            #endregion

            return retValue;
        }

        /// <summary>
        /// SCM受発注明細データ(回答)の生成
        /// </summary>
        /// <param name="src">問合せデータ(キャンセルデータ)</param>
        /// <param name="updateDate">更新日付</param>
        /// <param name="updateTime">更新時間</param>
        /// <returns></returns>
        private SCMAcOdrDtlAsWork CreateSCMAcOdrDtlAsWork(SCMAcOdrDtlIqWork src, DateTime updateDate, int updateTime)
        {
            SCMAcOdrDtlAsWork retValue = new SCMAcOdrDtlAsWork();

            #region 元データからそのままセットする項目

            //retValue.CreateDateTime = src.CreateDateTime;               // 作成日時
            //retValue.UpdateDateTime = src.UpdateDateTime;               // 更新日時
            retValue.EnterpriseCode = src.EnterpriseCode;               // 企業コード
            //retValue.FileHeaderGuid = src.FileHeaderGuid;               // GUID
            //retValue.UpdEmployeeCode = src.UpdEmployeeCode;             // 更新従業員コード
            //retValue.UpdAssemblyId1 = src.UpdAssemblyId1;               // 更新アセンブリID1
            //retValue.UpdAssemblyId2 = src.UpdAssemblyId2;               // 更新アセンブリID2
            //retValue.LogicalDeleteCode = src.LogicalDeleteCode;         // 論理削除区分
            retValue.InqOriginalEpCd = src.InqOriginalEpCd.Trim();             // 問合せ元企業コード//@@@@20230303
            retValue.InqOriginalSecCd = src.InqOriginalSecCd;           // 問合せ元拠点コード
            retValue.InqOtherEpCd = src.InqOtherEpCd;                   // 問合せ先企業コード
            retValue.InqOtherSecCd = src.InqOtherSecCd;                 // 問合せ先拠点コード
            retValue.InquiryNumber = src.InquiryNumber;                 // 問合せ番号
            //retValue.UpdateDate = src.UpdateDate;                       // 更新年月日
            //retValue.UpdateTime = src.UpdateTime;                       // 更新時間
            retValue.InqRowNumber = src.InqRowNumber;                   // 問合せ行番号
            retValue.InqRowNumDerivedNo = src.InqRowNumDerivedNo;       // 問合せ行番号枝番
            retValue.InqOrgDtlDiscGuid = src.InqOrgDtlDiscGuid;         // 問合せ元明細識別GUID
            retValue.InqOthDtlDiscGuid = src.InqOthDtlDiscGuid;         // 問合せ先明細識別GUID
            retValue.GoodsDivCd = src.GoodsDivCd;                       // 商品種別
            retValue.RecyclePrtKindCode = src.RecyclePrtKindCode;       // リサイクル部品種別
            retValue.RecyclePrtKindName = src.RecyclePrtKindName;       // リサイクル部品種別名称
            retValue.DeliveredGoodsDiv = src.DeliveredGoodsDiv;         // 納品区分
            retValue.HandleDivCode = src.HandleDivCode;                 // 取扱区分
            retValue.GoodsShape = src.GoodsShape;                       // 商品形態
            retValue.DelivrdGdsConfCd = src.DelivrdGdsConfCd;           // 納品確認区分
            retValue.DeliGdsCmpltDueDate = src.DeliGdsCmpltDueDate;     // 納品完了予定日
            retValue.AnswerDeliveryDate = src.AnswerDeliveryDate;       // 回答納期
            retValue.BLGoodsCode = src.BLGoodsCode;                     // BL商品コード
            retValue.BLGoodsDrCode = src.BLGoodsDrCode;                 // BL商品コード枝番
            retValue.InqGoodsName = src.InqGoodsName;                   // 問発商品名
            retValue.AnsGoodsName = src.AnsGoodsName;                   // 回答商品名
            retValue.SalesOrderCount = src.SalesOrderCount;             // 発注数
            retValue.DeliveredGoodsCount = src.DeliveredGoodsCount;     // 納品数
            retValue.GoodsNo = src.GoodsNo;                             // 商品番号
            retValue.GoodsMakerCd = src.GoodsMakerCd;                   // 商品メーカーコード
            retValue.GoodsMakerNm = src.GoodsMakerNm;                   // 商品メーカー名称
            retValue.PureGoodsMakerCd = src.PureGoodsMakerCd;           // 純正商品メーカーコード
            retValue.InqPureGoodsNo = src.InqPureGoodsNo;               // 問発純正商品番号
            retValue.AnsPureGoodsNo = src.AnsPureGoodsNo;               // 回答純正商品番号
            retValue.ListPrice = src.ListPrice;                         // 定価
            retValue.UnitPrice = src.UnitPrice;                         // 単価
            retValue.GoodsAddInfo = src.GoodsAddInfo;                   // 商品補足情報
            retValue.RoughRrofit = src.RoughRrofit;                     // 粗利額
            retValue.RoughRate = src.RoughRate;                         // 粗利率
            retValue.AnswerLimitDate = src.AnswerLimitDate;             // 回答期限
            retValue.CommentDtl = src.CommentDtl;                       // 備考(明細)
            retValue.AppendingFileDtl = src.AppendingFileDtl;           // 添付ファイル(明細)
            retValue.AppendingFileNmDtl = src.AppendingFileNmDtl;       // 添付ファイル名(明細)
            retValue.ShelfNo = src.ShelfNo;                             // 棚番
            retValue.AdditionalDivCd = src.AdditionalDivCd;             // 追加区分
            retValue.CorrectDivCD = src.CorrectDivCD;                   // 訂正区分
            //retValue.AcptAnOdrStatus = src.AcptAnOdrStatus;             // 受注ステータス
            //retValue.SalesSlipNum = src.SalesSlipNum;                   // 売上伝票番号
            //retValue.SalesRowNo = src.SalesRowNo;                       // 売上行番号
            //retValue.CampaignCode = src.CampaignCode;                   // キャンペーンコード
            //retValue.StockDiv = src.StockDiv;                           // 在庫区分
            retValue.InqOrdDivCd = src.InqOrdDivCd;                     // 問合せ・発注種別
            retValue.DisplayOrder = src.DisplayOrder;                   // 表示順位
            //retValue.GoodsMngNo = src.GoodsMngNo;                       // 商品管理番号
            retValue.CancelCndtinDiv = src.CancelCndtinDiv;             // キャンセル状態区分
            // --- ADD 2013/10/18 Y.Wakita №94 (SCM障害№10410 対応漏れ) ---------->>>>>
            retValue.DataInputSystem = src.DataInputSystem;             // データ入力システム
            // --- ADD 2013/10/18 Y.Wakita №94 (SCM障害№10410 対応漏れ) ----------<<<<<
            #endregion

            #region 補正する項目

            // 2011/02/18 Del >>>
            //retValue.UpdateDate = updateDate;                           // 更新年月日
            //retValue.UpdateTime = updateTime;                           // 更新時間
            // 2011/02/18 Del <<<

            retValue.AcptAnOdrStatus = 0;                               // 受注ステータス
            retValue.SalesSlipNum = "000000000";                        // 売上伝票番号

            // 2011/02/18 >>>
            //retValue.CommentDtl = "キャンセルを受付けませんでした。";   // 備考(明細)
            // 2011/02/18 <<<
            #endregion

            return retValue;
        }

        /// <summary>
        /// SCM受注データ(車輌情報)の生成
        /// </summary>
        /// <param name="src">SCM受注データ(車輌情報)(キャンセルデータ)</param>
        /// <param name="updateDate">更新日付</param>
        /// <param name="updateTime">更新時間</param>
        /// <returns></returns>
        private SCMAcOdrDtCarWork CreateSCMAcOdrDtCarWork(SCMAcOdrDtCarWork src, DateTime updateDate, int updateTime)
        {
            SCMAcOdrDtCarWork retValue = new SCMAcOdrDtCarWork();

            #region 元データからそのままセットする項目

            //retValue.CreateDateTime = src.CreateDateTime;               // 作成日時
            //retValue.UpdateDateTime = src.UpdateDateTime;               // 更新日時
            retValue.EnterpriseCode = src.EnterpriseCode;               // 企業コード
            //retValue.FileHeaderGuid = src.FileHeaderGuid;               // GUID
            //retValue.UpdEmployeeCode = src.UpdEmployeeCode;             // 更新従業員コード
            //retValue.UpdAssemblyId1 = src.UpdAssemblyId1;               // 更新アセンブリID1
            //retValue.UpdAssemblyId2 = src.UpdAssemblyId2;               // 更新アセンブリID2
            //retValue.LogicalDeleteCode = src.LogicalDeleteCode;         // 論理削除区分
            retValue.InqOriginalEpCd = src.InqOriginalEpCd.Trim();             // 問合せ元企業コード//@@@@20230303
            retValue.InqOriginalSecCd = src.InqOriginalSecCd;           // 問合せ元拠点コード
            retValue.InquiryNumber = src.InquiryNumber;                 // 問合せ番号
            retValue.NumberPlate1Code = src.NumberPlate1Code;           // 陸運事務所番号
            retValue.NumberPlate1Name = src.NumberPlate1Name;           // 陸運事務局名称
            retValue.NumberPlate2 = src.NumberPlate2;                   // 車両登録番号（種別）
            retValue.NumberPlate3 = src.NumberPlate3;                   // 車両登録番号（カナ）
            retValue.NumberPlate4 = src.NumberPlate4;                   // 車両登録番号（プレート番号）
            retValue.ModelDesignationNo = src.ModelDesignationNo;       // 型式指定番号
            retValue.CategoryNo = src.CategoryNo;                       // 類別番号
            retValue.MakerCode = src.MakerCode;                         // メーカーコード
            retValue.ModelCode = src.ModelCode;                         // 車種コード
            retValue.ModelSubCode = src.ModelSubCode;                   // 車種サブコード
            retValue.ModelName = src.ModelName;                         // 車種名
            retValue.CarInspectCertModel = src.CarInspectCertModel;     // 車検証型式
            retValue.FullModel = src.FullModel;                         // 型式（フル型）
            retValue.FrameNo = src.FrameNo;                             // 車台番号
            retValue.FrameModel = src.FrameModel;                       // 車台型式
            retValue.ChassisNo = src.ChassisNo;                         // シャシーNo
            retValue.CarProperNo = src.CarProperNo;                     // 車両固有番号
            retValue.ProduceTypeOfYearNum = src.ProduceTypeOfYearNum;   // 生産年式（NUMタイプ）
            retValue.Comment = src.Comment;                             // コメント
            retValue.RpColorCode = src.RpColorCode;                     // リペアカラーコード
            retValue.ColorName1 = src.ColorName1;                       // カラー名称1
            retValue.TrimCode = src.TrimCode;                           // トリムコード
            retValue.TrimName = src.TrimName;                           // トリム名称
            retValue.Mileage = src.Mileage;                             // 車両走行距離
            retValue.EquipObj = src.EquipObj;                           // 装備オブジェクト
            //retValue.AcptAnOdrStatus = src.AcptAnOdrStatus;             // 受注ステータス
            //retValue.SalesSlipNum = src.SalesSlipNum;                   // 売上伝票番号


            #endregion

            #region 補正する項目

            //retValue.UpdateDate = updateDate;                           // 更新年月日
            //retValue.UpdateTime = updateTime;                           // 更新時間

            retValue.AcptAnOdrStatus = 0;                          // 受注ステータス
            retValue.SalesSlipNum = "000000000";                   // 売上伝票番号
            #endregion

            return retValue;
        }

        /// <summary>
        /// 得意先情報の取得
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerInfo GetCustomerInfo(int customerCode)
        {
            CustomerInfo info;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, false, true, out info);

            return info;
        }

        // 2010/05/27 Add <<<
        
        #region 名称取得処理
        /// <summary>
        /// 回答方法の名称取得
        /// </summary>
        /// <param name="awnserMethod"></param>
        /// <returns></returns>
        // UPD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------------------------------------->>>>>
        //private string GetAnswerMethodName(int awnserMethod)
        private string GetAnswerMethodName(int awnserMethod, int autoAnswerCount, int manualAnswerCount)
        // UPD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------------------------------------<<<<<
        {
            string answerMethodName;

            switch (awnserMethod)
            {
                case 0:
                    {
                        answerMethodName = "自動";
                        break;
                    }
                case 1:
                    {
                        answerMethodName = "手動(Web)";
                        break;
                    }
                case 2:
                    {
                        answerMethodName = "手動(その他)";
                        break;
                    }
                default:
                    {
                        answerMethodName = string.Empty;
                        break;
                    }
            }
            // UPD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ---------------------------------------->>>>>
            // 自動回答件数と手動回答件数がともにゼロ以外の時は混在とする
            if (autoAnswerCount != 0 && manualAnswerCount != 0)
            {
                answerMethodName = "自動手動混在";
            }
            // UPD 2012/10/10 2012/11/14配信予定 SCM障害№176対応 ----------------------------------------<<<<<
            return answerMethodName;
        }

        /// <summary>
        /// 発注種別の名称取得
        /// </summary>
        /// <param name="inqOrdDivCd"></param>
        /// <returns></returns>
        private string GetInqOrdDivCdName(int inqOrdDivCd)
        {
            string inqOrdDivCdName;

            switch (inqOrdDivCd)
            {
                case 1:
                    {
                        inqOrdDivCdName = "見積";
                        break;
                    }
                case 2:
                    {
                        inqOrdDivCdName = "受注";
                        break;
                    }
                default:
                    {
                        inqOrdDivCdName = string.Empty;
                        break;
                    }
            }

            return inqOrdDivCdName;
        }

        /// <summary>
        /// 受注ステータスの名称取得
        /// </summary>
        /// <param name="inqOrdDivCd"></param>
        /// <returns></returns>
        private string GetAcptAnOdrStatusName(int acptAnOdrStatus)
        {
            string acptAnOdrStatusName;

            switch (acptAnOdrStatus)
            {
                case 10:
                    {
                        acptAnOdrStatusName = "見積";
                        break;
                    }
                case 20:
                    {
                        acptAnOdrStatusName = "受注";
                        break;
                    }
                case 30:
                    {
                        acptAnOdrStatusName = "売上";
                        break;
                    }
                default:
                    {
                        acptAnOdrStatusName = string.Empty;
                        break;
                    }
            }

            return acptAnOdrStatusName;
        }

        /// <summary>
        /// メーカー名称取得
        /// </summary>
        /// <param name="inqOrdDivCd"></param>
        /// <returns></returns>
        private string GetMakerName(int makerCode)
        {
            MakerUMnt makerUmnt;
            int status = this._makerAcs.Read(out makerUmnt, this._enterpriseCode, makerCode);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                && makerUmnt != null)
            {
                return makerUmnt.MakerName;
            }

            return string.Empty;
        }
        #endregion

        #endregion

        #region テストデータ
        //private int GetTestData(out object ret)
        //{
        //    ret = new CustomSerializeArrayList();

        //    CustomSerializeArrayList inqList1 = new CustomSerializeArrayList();

        //    // ヘッダ
        //    SCMInquiryResultWork testHeader1 = new SCMInquiryResultWork();

        //    testHeader1.AwnserMethod = 0;// 回答方法
        //    testHeader1.UpdateDate = DateTime.Now;// 更新年月日
        //    testHeader1.UpdateTime = 155555111;// 更新時分秒
        //    testHeader1.InqOrdDivCd = 1; // 発注種別
        //    testHeader1.InquiryNumber = 200;// 問合せ番号
        //    testHeader1.CustomerCode = 555;// 得意先
        //    testHeader1.CustomerName = "テスト得意";
        //    testHeader1.AnsEmployeeCd = "0001";// 担当者
        //    testHeader1.AnsEmployeeNm = "テスト担当";
        //    testHeader1.AcptAnOdrStatus = 10;// 受注ステータス
        //    testHeader1.SalesSlipNum = "100000000";// 伝票番号
        //    testHeader1.CategoryNo = 1;// 類別番号
        //    testHeader1.ModelName = "車種";// 車種名
        //    testHeader1.ModelDesignationNo = 1234;// 型式指定番号
        //    testHeader1.NumberPlate4 = 4129;// 車両登録番号（プレート番号）
        //    testHeader1.ProduceTypeOfYearNum = 200906;// 生産年式
        //    testHeader1.SalesTotalTaxInc = 10500;// 売上伝票合計（税込み）

        //    inqList1.Add(testHeader1);

        //    SCMInquiryDtlInqResultWork testInq1 = new SCMInquiryDtlInqResultWork();

        //    // BL商品コード
        //    testInq1.BLGoodsCode = 1;
        //    // 商品名（カナ）
        //    //testInq1.GoodsName = "かな";
        //    // 商品番号
        //    testInq1.GoodsNo = "TESTUENO";
        //    // 商品メーカーコード
        //    testInq1.GoodsMakerCd = 1;
        //    // 発注数
        //    testInq1.SalesOrderCount = 15;
        //    // 納品数
        //    testInq1.DeliveredGoodsCount = 10;
        //    // 定価
        //    testInq1.ListPrice = 10000;
        //    // 単価
        //    testInq1.UnitPrice = 1000;
        //    // 売上金額税抜き？
        //    testInq1.SalesMoneyTaxExc = 10000;
        //    // 売上金額消費税額
        //    testInq1.SalesPriceConsTax = 500;
        //    // 棚番
        //    testInq1.ShelfNo = "Tana";

        //    inqList1.Add(testInq1);

        //    SCMInquiryDtlAnsResultWork testAns1 = new SCMInquiryDtlAnsResultWork();

        //    // BL商品コード
        //    testAns1.BLGoodsCode = 1;
        //    // 商品名（カナ）
        //    //testAns1.GoodsName = "かな";
        //    // 商品番号
        //    testAns1.GoodsNo = "TESTUENO";
        //    // 商品メーカーコード
        //    testAns1.GoodsMakerCd = 1;
        //    // 発注数
        //    testAns1.SalesOrderCount = 15;
        //    // 納品数
        //    testAns1.DeliveredGoodsCount = 10;
        //    // 定価
        //    testAns1.ListPrice = 10000;
        //    // 単価
        //    testAns1.UnitPrice = 1000;
        //    // 売上金額税抜き？
        //    testAns1.SalesMoneyTaxExc = 10000;
        //    // 売上金額消費税額
        //    testAns1.SalesPriceConsTax = 500;
        //    // 棚番
        //    testAns1.ShelfNo = "Tana";

        //    inqList1.Add(testAns1);

        //    ((CustomSerializeArrayList)ret).Add(inqList1);


        //    CustomSerializeArrayList inqList2 = new CustomSerializeArrayList();

        //    // ヘッダ
        //    SCMInquiryResultWork testHeader2 = new SCMInquiryResultWork();

        //    testHeader2.AwnserMethod = 1;// 回答方法
        //    testHeader2.UpdateDate = DateTime.Now;// 更新年月日
        //    testHeader2.UpdateTime = 155555111;// 更新時分秒
        //    testHeader2.InqOrdDivCd = 1; // 発注種別
        //    testHeader2.InquiryNumber = 100;// 問合せ番号
        //    testHeader2.CustomerCode = 555;// 得意先
        //    testHeader2.CustomerName = "テスト得意";
        //    testHeader2.AnsEmployeeCd = "0001";// 担当者
        //    testHeader2.AnsEmployeeNm = "テスト担当";
        //    testHeader2.AcptAnOdrStatus = 10;// 受注ステータス
        //    testHeader2.SalesSlipNum = "100000000";// 伝票番号
        //    testHeader2.CategoryNo = 555;// 類別番号
        //    testHeader2.ModelName = "車種";// 車種名
        //    testHeader2.ModelDesignationNo = 1234;// 型式指定番号
        //    testHeader2.NumberPlate4 = 4129;// 車両登録番号（プレート番号）
        //    testHeader2.ProduceTypeOfYearNum = 200906;// 生産年式
        //    testHeader2.SalesTotalTaxInc = 10500;// 売上伝票合計（税込み）

        //    inqList2.Add(testHeader2);

        //    SCMInquiryDtlInqResultWork testInq2 = new SCMInquiryDtlInqResultWork();

        //    // BL商品コード
        //    testInq2.BLGoodsCode = 1;
        //    // 商品名（カナ）
        //    //testInq2.GoodsName = "かな";
        //    // 商品番号
        //    testInq2.GoodsNo = "TESTUENO";
        //    // 商品メーカーコード
        //    testInq2.GoodsMakerCd = 1;
        //    // 発注数
        //    testInq2.SalesOrderCount = 15;
        //    // 納品数
        //    testInq2.DeliveredGoodsCount = 10;
        //    // 定価
        //    testInq2.ListPrice = 10000;
        //    // 単価
        //    testInq2.UnitPrice = 1000;
        //    // 売上金額税抜き？
        //    testInq2.SalesMoneyTaxExc = 10000;
        //    // 売上金額消費税額
        //    testInq2.SalesPriceConsTax = 500;
        //    // 棚番
        //    testInq2.ShelfNo = "Tana";

        //    inqList2.Add(testInq2);

        //    ((CustomSerializeArrayList)ret).Add(inqList2);


        //    return 0;
        //}
        #endregion
    }
}
