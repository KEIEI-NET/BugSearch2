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
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/15  修正内容 : ①回答納期で、設定時間範囲外の場合は空白を返す
//                                 ②売上明細データの回答納期がセットされない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2010/03/17  修正内容 : 高速化
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/01/11  修正内容 : 納期回答設定マスタのレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/10/11  修正内容 : Redmine#25765の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲　30745
// 作 成 日  2012/08/30  修正内容 : 2012/10月配信予定SCM障害№10345対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲　30745
// 作 成 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
// 2010/03/12 Add >>>
using System.Collections;
// 2010/03/12 Add <<<

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SCMDeliDateStAcs;
    using RecordType        = SCMDeliDateSt;

    /// <summary>
    /// SCM納期設定アクセスの代理人クラス
    /// </summary>
    public class SCMDeliveryDateSettingAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCM納期設定マスタ";

        /// <summary>全得意先</summary>
        private const int ALL_CUSTOMER_CODE = 0;
        /// <summary>全社</summary>
        private const string ALL_SECTION_CODE = SecInfoSetAgent.ALL_SECTION_CODE;

        /// <summary>得意先コードのフォーマット</summary>
        private const string CUSTOMER_CODE_FORMAT = "000000000";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMDeliveryDateSettingAgent() : base() { }

        #endregion // </Constructor>

        // 2010/03/17 Add >>>
        List<RecordType> _allList;

        /// <summary>
        /// SCM納期設定を、得意先コード、拠点コード逆順にソートする
        /// </summary>
        /// <remarks></remarks>
        private class EstiamteDefSetComparer : Comparer<RecordType>
        {
            public override int Compare(RecordType x, RecordType y)
            {
                int result = y.CustomerCode.CompareTo(x.CustomerCode);
                if (result != 0) return result;

                result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        // 2010/03/17 Add <<<

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>該当するSCM相場価格設定</returns>
        private RecordType Find(
            string enterpriseCode,
            string sectionCode,
            int customerCode
        )
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode)
                + customerCode.ToString(CUSTOMER_CODE_FORMAT);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            // 2010/03/17 >>>
            //// 得意先コードを優先
            //string param2SectionCode= (customerCode > 0 ? string.Empty : sectionCode);
            //int param3CustomerCode  = customerCode;

            //int status = RealAccesser.Read(out foundRecord, enterpriseCode, param2SectionCode, param3CustomerCode);
            //if (customerCode > 0 && status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    // 件数0件の場合、拠点コードで再検索
            //    param2SectionCode   = sectionCode;
            //    param3CustomerCode  = 0;
            //    status = RealAccesser.Read(out foundRecord, enterpriseCode, param2SectionCode, param3CustomerCode);
            //}

            //if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
            //    return null;
            //}

            //if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            //{
            //    FoundRecordMap.Add(key, foundRecord);
            //}

            RecordType foundRecord = null;
            if (_allList == null)
            {
                _allList = new List<SCMDeliDateSt>();
                ArrayList al;
                int status = RealAccesser.Search(out al, enterpriseCode);
                if (status.Equals((int)ResultUtil.ResultCode.Normal))
                {
                    if (al != null && al.Count > 0)
                    {
                        foreach (SCMDeliDateSt rec in al)
                        {
                            _allList.Add(rec);
                        }

                        _allList.Sort(new EstiamteDefSetComparer());
                    }
                }
            }

            foundRecord = _allList.Find(
                delegate(RecordType rec)
                {
                    if (rec.CustomerCode == customerCode)
                    {
                        return true;
                    }

                    if (rec.SectionCode.Trim() == sectionCode.Trim() || rec.SectionCode.Trim() == "00")
                    {
                        return true;
                    }
                    return false;
                });

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            // 2010/03/17 <<<

            return foundRecord ?? new RecordType();
        }

        /// <summary>
        /// 回答納期を検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="isStock">在庫フラグ</param>
        /// <param name="isTrustStock">委託フラグ</param>
        /// <param name="isPriorityStock">優先フラグ</param>
        /// <param name="shelfNo">棚番</param>
        /// <param name="ansDeliDateDiv">回答納期区分</param>
        /// <returns>該当する回答納期</returns>
        public string FindAnswerDelivDate(
            string enterpriseCode,
            string sectionCode,
            // 2011/01/11 >>>
            //int customerCode
            int customerCode,
            bool isStock,
            bool isTrustStock,
            bool isPriorityStock, // ADD 2011/10/11
            string shelfNo
            // 2011/01/11 <<<
            , out short ansDeliDateDiv  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
        )
        {
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // ※ 当メソッド使用PGは自動回答のみで他PGからの参照は無し
            ansDeliDateDiv = 0;
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            SCMDeliDateSt foundDeriveryDateSetting = Find(enterpriseCode, sectionCode, customerCode);
            if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
            if (foundDeriveryDateSetting == null)
            {
                // 無ければ、全得意先で検索
                foundDeriveryDateSetting = Find(enterpriseCode, sectionCode, ALL_CUSTOMER_CODE);
                if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
                if (foundDeriveryDateSetting == null)
                {
                    // 無ければ、全社で検索
                    foundDeriveryDateSetting = Find(enterpriseCode, ALL_SECTION_CODE, ALL_CUSTOMER_CODE);
                    if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
                    if (foundDeriveryDateSetting == null) return string.Empty;
                }
            }

            // 2011/01/11 Add >>>
            // 委託在庫の場合
            if (isTrustStock)
            {
                // 委託在庫回答納期区分を参照して決定
                switch (foundDeriveryDateSetting.EntStckAnsDeliDtDiv)
                {
                    case 1:  // 1:棚番
                        return shelfNo;
                        break;
                    case 2:  // 2:委託用に設定
                        return foundDeriveryDateSetting.EntStckAnsDeliDate;
                        break;
                    default: // 上記以外は通常の在庫と同じ回答納期を使用する
                        break;
                }
            }
            // 2011/01/11 Add <<<

            // ----- ADD 2011/10/11 ----- >>>>>
            // 優先在庫回答納期を参照し、回答納期を設定する。
            // 優先在庫の場合
            if (isPriorityStock)
            {
                // 優先在庫回答納期区分を参照して決定
                switch (foundDeriveryDateSetting.PriStckAnsDeliDtDiv)
                {
                    case 1:  // 1:優先用に設定
                        return foundDeriveryDateSetting.PriStckAnsDeliDate;
                        break;
                    default: // 上記以外は通常の在庫と同じ回答納期を使用する
                        break;
                }
            }
            // ----- ADD 2011/10/11 ----- <<<<<

            // 回答納期のリスト…回答締切時刻でソート
            // 2011/01/11 >>>
            //SortedList<int, string> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting);
            // SortedList<int, string> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting, isStock);  // DEL 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            // string[]→2件のみ 1番目：回答納期  2番目：回答納期区分 Int16をstringにキャストした状態                      // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            SortedList<int, string[]> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting, isStock);  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            // 2011/01/11 <<<

            // 現在の時刻から回答納期を判定
            int now = int.Parse(DateTime.Now.ToString("HHmmss"));
            string answerDelivDate = string.Empty;
            bool find = false;  // 2011/03/11 Add 
            // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //foreach (KeyValuePair<int, string> answerDelivPair in answerDelivDateList)
            //{
            //    Debug.WriteLine(answerDelivPair.Key.ToString() + " " + answerDelivPair.Value);

            //    //if (string.IsNullOrEmpty(answerDelivDate)) answerDelivDate = answerDelivPair.Value;     // 2010/03/15 Del 

            //    if (answerDelivPair.Key >= now)
            //    {
            //        answerDelivDate = answerDelivPair.Value;
            //        find = true;  // 2011/03/11 Add 
            //        break;
            //    }
            //}
            //if (!find && answerDelivDateList.Count > 0) answerDelivDate = answerDelivDateList.Values[0]; // 2011/03/11 Add
            #endregion
            // ※ 当メソッドは「取寄」の場合のみ　
            // 「取寄」の場合は、必ずisTrustStock、isPriorityStockがfalseになります
            // 上記、「委託在庫の場合」と「優先在庫の場合」で回答納期区分の設定は必要無く、以下で設定してあればOK
            foreach (KeyValuePair<int, string[]> answerDelivPair in answerDelivDateList)
            {
                Debug.WriteLine(answerDelivPair.Key.ToString() + " " + answerDelivPair.Value[0]);

                if (answerDelivPair.Key >= now)
                {
                    answerDelivDate = answerDelivPair.Value[0];
                    Int16.TryParse(answerDelivPair.Value[1], out ansDeliDateDiv);
                    find = true;  
                    break;
                }
            }

            if (!find && answerDelivDateList.Count > 0)
            {
                answerDelivDate = answerDelivDateList.Values[0][0];
                Int16.TryParse(answerDelivDateList.Values[0][1], out ansDeliDateDiv);
            }
            // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return answerDelivDate;
        }

        // 2012/08/30 ADD T.Yoshioka 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 回答納期を検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="isStock">在庫フラグ</param>
        /// <param name="isTrustStock">委託フラグ</param>
        /// <param name="isPriorityStock">優先フラグ</param>
        /// <param name="salesOrderCount">発注数</param>
        /// <param name="stockQty">在庫数量</param>
        /// <param name="ansDeliDateDiv">回答納期区分</param>
        /// <returns>該当する回答納期</returns>
        public string FindAnswerDelivDate2(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            bool isStock,
            bool isTrustStock,
            bool isPriorityStock,
            double salesOrderCount,
            double stockQty
            ,out Int16 ansDeliDateDiv  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
        )
        {
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // ※ 当メソッド使用PGは自動回答のみで他PGからの参照は無し
            ansDeliDateDiv = 0;
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            SCMDeliDateSt foundDeriveryDateSetting = Find(enterpriseCode, sectionCode, customerCode);
            if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
            if (foundDeriveryDateSetting == null)
            {
                // 無ければ、全得意先で検索
                foundDeriveryDateSetting = Find(enterpriseCode, sectionCode, ALL_CUSTOMER_CODE);
                if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
                if (foundDeriveryDateSetting == null)
                {
                    // 無ければ、全社で検索
                    foundDeriveryDateSetting = Find(enterpriseCode, ALL_SECTION_CODE, ALL_CUSTOMER_CODE);
                    if (!SCMDataHelper.IsAvailableRecord(foundDeriveryDateSetting)) foundDeriveryDateSetting = null;
                    if (foundDeriveryDateSetting == null) return string.Empty;
                }
            }

            // 委託在庫の場合
            if (isTrustStock)
            {
                // 委託在庫回答納期区分＝委託用に設定　の場合（）
                if (foundDeriveryDateSetting.EntStckAnsDeliDtDiv == 2)
                {
                    if (stockQty <= 0)
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.EntAnsDelDtWioDiv; // ADD ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                        // 在庫数無し　の場合（在庫数量が０以下）
                        return foundDeriveryDateSetting.EntStcAnsDelDatWiout;
                    }
                    else if ((stockQty - salesOrderCount) < 0)
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.EntAnsDelDtShoDiv; // ADD ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                        // 在庫不足　の場合
                        return foundDeriveryDateSetting.EntStcAnsDelDatShort;
                    }
                    else
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.EntAnsDelDtStcDiv; // ADD ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                        // 在庫数有り　の場合
                        return foundDeriveryDateSetting.EntStckAnsDeliDate;
                    }
                }
            }

            // 優先在庫の場合
            if (isPriorityStock)
            {
                // 委託在庫回答納期区分＝委託用に設定　の場合（）
                if (foundDeriveryDateSetting.PriStckAnsDeliDtDiv == 1)
                {
                    if (stockQty <= 0)
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.PriAnsDelDtWioDiv; // ADD ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                        // 在庫数無し　の場合（在庫数量が０以下）
                        return foundDeriveryDateSetting.PriStcAnsDelDatWiout;
                    }
                    else if ((stockQty - salesOrderCount) < 0)
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.PriAnsDelDtShoDiv; // ADD ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                        // 在庫不足　の場合
                        return foundDeriveryDateSetting.PriStcAnsDelDatShort;
                    }
                    else
                    {
                        ansDeliDateDiv = foundDeriveryDateSetting.PriAnsDelDtStcDiv; // ADD ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                        // 在庫数有り　の場合
                        return foundDeriveryDateSetting.PriStckAnsDeliDate;
                    }
                }
            }

            // その他在庫の場合
            // 委託在庫回答納期区分＝委託用に設定　の場合（）
            if (stockQty <= 0)
            {
                ansDeliDateDiv = foundDeriveryDateSetting.AnsDelDtWioStcDiv; // ADD ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                // 在庫数無し　の場合（在庫数量が０以下）
                return foundDeriveryDateSetting.AnsDelDatWithoutStc;
            }
            else if ((stockQty - salesOrderCount) < 0)
            {
                ansDeliDateDiv = foundDeriveryDateSetting.AnsDelDtShoStcDiv; // ADD ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                // 在庫不足　の場合
                return foundDeriveryDateSetting.AnsDelDatShortOfStc;
            }

            // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// 回答納期のリスト…回答締切時刻でソート
            //SortedList<int, string> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting, isStock);
            //// 現在の時刻から回答納期を判定
            //int now = int.Parse(DateTime.Now.ToString("HHmmss"));
            //string answerDelivDate = string.Empty;
            //bool find = false;
            //foreach (KeyValuePair<int, string> answerDelivPair in answerDelivDateList)
            //{
            //    Debug.WriteLine(answerDelivPair.Key.ToString() + " " + answerDelivPair.Value);

            //    if (answerDelivPair.Key >= now)
            //    {
            //        answerDelivDate = answerDelivPair.Value;
            //        find = true;
            //        break;
            //    }
            //}
            //if (!find && answerDelivDateList.Count > 0) answerDelivDate = answerDelivDateList.Values[0];
            #endregion
            // 回答納期のリスト…回答締切時刻でソート   string[]→2件のみ 1番目：回答納期  2番目：回答納期区分 Int16をstringにキャストした状態
            SortedList<int, string[]> answerDelivDateList = CreateAnswerDelivDateList(foundDeriveryDateSetting, isStock);

            // 現在の時刻から回答納期を判定
            int now = int.Parse(DateTime.Now.ToString("HHmmss"));
            string answerDelivDate = string.Empty;
            bool find = false;
            foreach (KeyValuePair<int, string[]> answerDelivPair in answerDelivDateList)
            {
                Debug.WriteLine(answerDelivPair.Key.ToString() + " " + answerDelivPair.Value[0]);

                if (answerDelivPair.Key >= now)
                {
                    answerDelivDate = answerDelivPair.Value[0];
                    Int16.TryParse(answerDelivPair.Value[1], out ansDeliDateDiv);
                    find = true;
                    break;
                }
            }
            if (!find && answerDelivDateList.Count > 0)
            {
                answerDelivDate = answerDelivDateList.Values[0][0];
                Int16.TryParse(answerDelivDateList.Values[0][1], out ansDeliDateDiv);
            }
            // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return answerDelivDate;
        }
        // 2012/08/30 ADD T.Yoshioka 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #region <回答納期>

        /// <summary>
        /// 回答締切時刻でソートされた回答納期リストを生成します。
        /// </summary>
        /// <param name="deriveryDateSetting">SCM納期設定</param>
        /// <param name="isStock">在庫フラグ</param>
        /// <returns>回答締切時刻でソートされた回答納期リスト</returns>
        // 2011/01/11 >>>
        //private static SortedList<int, string> CreateAnswerDelivDateList(SCMDeliDateSt deriveryDateSetting)
        // private static SortedList<int, string> CreateAnswerDelivDateList(SCMDeliDateSt deriveryDateSetting, bool isStock) // DEL 2015/02/10 吉岡 SCM高速化 回答納期区分対応
        private static SortedList<int, string[]> CreateAnswerDelivDateList(SCMDeliDateSt deriveryDateSetting, bool isStock)  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
        // 2011/01/11 <<<
        {
            // SortedList<int, string> answerDelivDateList = new SortedList<int, string>(); // DEL 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            SortedList<int, string[]> answerDelivDateList = new SortedList<int, string[]>(); // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            {
                // 2011/01/11 >>>
                //// 回答締切時刻1/回答納期1
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime1,
                //    deriveryDateSetting.AnswerDelivDate1
                //);
                //// 回答締切時刻2/回答納期2
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime2,
                //    deriveryDateSetting.AnswerDelivDate2
                //);
                //// 回答締切時刻3/回答納期3
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime3,
                //    deriveryDateSetting.AnswerDelivDate3
                //);
                //// 回答締切時刻4/回答納期4
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime4,
                //    deriveryDateSetting.AnswerDelivDate4
                //);
                //// 回答締切時刻5/回答納期5
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime5,
                //    deriveryDateSetting.AnswerDelivDate5
                //);
                //// 回答締切時刻6/回答納期6
                //AddItem(
                //    answerDelivDateList,
                //    deriveryDateSetting.AnswerDeadTime6,
                //    deriveryDateSetting.AnswerDelivDate6
                //);

                if (!isStock)
                {
                    // 回答締切時刻1/回答納期1
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime1,
                        deriveryDateSetting.AnswerDelivDate1
                        , deriveryDateSetting.AnsDelDtDiv1  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻2/回答納期2
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime2,
                        deriveryDateSetting.AnswerDelivDate2
                        , deriveryDateSetting.AnsDelDtDiv2  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻3/回答納期3
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime3,
                        deriveryDateSetting.AnswerDelivDate3
                        , deriveryDateSetting.AnsDelDtDiv3  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻4/回答納期4
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime4,
                        deriveryDateSetting.AnswerDelivDate4
                        , deriveryDateSetting.AnsDelDtDiv4  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻5/回答納期5
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime5,
                        deriveryDateSetting.AnswerDelivDate5
                        , deriveryDateSetting.AnsDelDtDiv5  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻6/回答納期6
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime6,
                        deriveryDateSetting.AnswerDelivDate6
                        , deriveryDateSetting.AnsDelDtDiv6  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                }
                else
                {
                    // 回答締切時刻1/回答納期1
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime1Stc,
                        deriveryDateSetting.AnswerDelivDate1Stc
                        , deriveryDateSetting.AnsDelDtDiv1Stc  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻2/回答納期2
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime2Stc,
                        deriveryDateSetting.AnswerDelivDate2Stc
                        , deriveryDateSetting.AnsDelDtDiv2Stc  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻3/回答納期3
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime3Stc,
                        deriveryDateSetting.AnswerDelivDate3Stc
                        , deriveryDateSetting.AnsDelDtDiv3Stc  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻4/回答納期4
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime4Stc,
                        deriveryDateSetting.AnswerDelivDate4Stc
                        , deriveryDateSetting.AnsDelDtDiv4Stc  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻5/回答納期5
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime5Stc,
                        deriveryDateSetting.AnswerDelivDate5Stc
                        , deriveryDateSetting.AnsDelDtDiv5Stc  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                    // 回答締切時刻6/回答納期6
                    AddItem(
                        answerDelivDateList,
                        deriveryDateSetting.AnswerDeadTime6Stc,
                        deriveryDateSetting.AnswerDelivDate6Stc
                        , deriveryDateSetting.AnsDelDtDiv6Stc  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                    );
                }
                // 2011/01/11 <<<
            }
            return answerDelivDateList;
        }

        /// <summary>
        /// 回答納期のリストに項目を追加します。
        /// </summary>
        /// <remarks>
        /// <c>SortedList</c>のヘルパ関数
        /// </remarks>
        /// <param name="answerDelivDateList">回答納期のリスト</param>
        /// <param name="answerDeadTime">回答締切時刻</param>
        /// <param name="answerDelivDate">回答納期</param>
        /// <param name="ansDeliDateDiv">回答納期区分</param>
        private static void AddItem(
            // SortedList<int, string> answerDelivDateList, // DEL 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            SortedList<int, string[]> answerDelivDateList,  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            int answerDeadTime,
            string answerDelivDate
            , Int16 ansDeliDateDiv  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            )
        {
            // 回答締切時刻が0の場合、無視
            if (answerDeadTime.Equals(0)) return;

            // 未登録の場合、回答締切時刻と回答納期を追加
            if (!answerDelivDateList.ContainsKey(answerDeadTime))
            {
                // answerDelivDateList.Add(answerDeadTime, answerDelivDate); // DEL 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                answerDelivDateList.Add(answerDeadTime, new string[] { answerDelivDate, ansDeliDateDiv.ToString() });  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応

                return;
            }

            // 登録済の場合
            // 回答納期が空の場合、無視
            if (string.IsNullOrEmpty(answerDelivDate)) return;

            // 登録済みの回答納期が空の場合、再登録
            // if (string.IsNullOrEmpty(answerDelivDateList[answerDeadTime])) // DEL 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            if (string.IsNullOrEmpty(answerDelivDateList[answerDeadTime][0])) // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            {
                answerDelivDateList.Remove(answerDeadTime);
                // answerDelivDateList.Add(answerDeadTime, answerDelivDate);  // DEL 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                answerDelivDateList.Add(answerDeadTime, new string[] { answerDelivDate, ansDeliDateDiv.ToString() });  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            }
        }

        #endregion // </回答納期>
    }
}
