//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCMポップアップ
// プログラム概要   : ポップアップ処理の操作を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2009/09/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/02  修正内容 : 新着件数が累積される不具合の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/19  修正内容 : 新着通知の受渡データの変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/01/27  修正内容 : 新着データからCMT連携分を除外するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/25  修正内容 : 新着分と回答分を取得するように修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Application.UIData; // 2010/03/02 Add
using System.Collections;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// SCM I/O Writer::ScmSearch()メソッドの検索結果ヘルパクラス
    /// </summary>
    public sealed class SCMSearchedResultHelper
    {
        #region <カウンタ>

        /// <summary>カウンタ</summary>
        private int _count;
        /// <summary>カウンタを取得します。</summary>
        public int Count { get { return _count; } }

        // 2010/04/19 >>>
        //// 2010/03/02 Add >>>
        ///// <summary>データリスト</summary>
        //private List<ScmOdrData> _dataList = new List<ScmOdrData>();

        ///// <summary>データリスト</summary>
        //public List<ScmOdrData> DataList
        //{
        //    get { return _dataList; }
        //    set { _dataList = value; }
        //}
        //// 2010/03/02 Add <<<

        /// <summary>データリスト</summary>
        private List<ISCMOrderHeaderRecord> _dataList = new List<ISCMOrderHeaderRecord>();

        /// <summary>データリスト</summary>
        public List<ISCMOrderHeaderRecord> DataList
        {
            get { return _dataList; }
            set { _dataList = value; }
        }
        // 2010/04/19 <<<

        // 2011/02/18 Add >>>
        /// <summary>データリスト</summary>
        private List<ISCMOrderHeaderRecord> _answerdDataList = new List<ISCMOrderHeaderRecord>();

        /// <summary>データリスト</summary>
        public List<ISCMOrderHeaderRecord> AnswerdDataList
        {
            get { return _answerdDataList; }
            set { _answerdDataList = value; }
        }
        // 2011/02/18 Add <<<

        #endregion // </カウンタ>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMSearchedResultHelper() { }

        #endregion // </Constructor>

        // 2010/04/19 Add >>>
        /// <summary>前回取得更新日</summary>
        private DateTime _lastUpdateDate;
        /// <summary>前回取得更新時間</summary>
        private int _lastUpdateTime;

        public DateTime LastUpdateDate
        {
            get { return _lastUpdateDate; }
            set { _lastUpdateDate = value; }
        }


        public int LastUpdateTime
        {
            get { return _lastUpdateTime; }
            set { _lastUpdateTime = value; }
        }

        // 2010/04/19 Add <<<

        // 2010/03/02 >>>
        #region 削除
        ///// <summary>
        ///// 本日分の項目を数えます。
        ///// </summary>
        ///// <param name="scmSearchedResultListItem">SCM I/O Writer::ScmSearch()の検索結果の項目</param>
        //public void CountToday(CustomSerializeArrayList scmSearchedResultListItem)
        //{
        //    #region <Guard Phrase>

        //    if (scmSearchedResultListItem == null || scmSearchedResultListItem.Count.Equals(0)) return;

        //    #endregion // </Guard Phrase>

        //    SCMAcOdrDataWork scmHeaderData = scmSearchedResultListItem[0] as SCMAcOdrDataWork;
        //    if (scmHeaderData == null) return;

        //    int year    = scmHeaderData.UpdateDate.Year;
        //    int month   = scmHeaderData.UpdateDate.Month;
        //    int day     = scmHeaderData.UpdateDate.Day;

        //    DateTime today = DateTime.Today;
        //    if (year.Equals(today.Year) && month.Equals(today.Month) && day.Equals(today.Day))
        //    {
        //        _count++;
        //    }
        //}
        #endregion

        /// <summary>
        /// 本日分の項目を数えます。
        /// </summary>
        /// <param name="scmHeaderData">SCM I/O Writer::GetOrderNewCount()の検索結果の項目</param>
        // 2010/04/19 >>>
        //public void CountToday(SCMAcOdrDataWork scmHeaderData)
        public void GetNewData(SCMAcOdrDataWork scmHeaderData)
        // 2010/04/19 <<<
        {
            if (scmHeaderData == null) return;

            // 2011/02/25 Del >>>
            //if (scmHeaderData.CMTCooprtDiv == 1) return;    // 2011/01/27 Add
            // 2011/02/25 Del <<<

            // 2010/04/19 >>>
            //int year = scmHeaderData.UpdateDate.Year;
            //int month = scmHeaderData.UpdateDate.Month;
            //int day = scmHeaderData.UpdateDate.Day;

            //DateTime today = DateTime.Today;
            //if (year.Equals(today.Year) && month.Equals(today.Month) && day.Equals(today.Day))

            if (( scmHeaderData.UpdateDate > _lastUpdateDate ) ||
                ( scmHeaderData.UpdateDate == _lastUpdateDate && scmHeaderData.UpdateTime > _lastUpdateTime ))
            // 2010/04/19 <<<
            {
                _count++;

                // 2010/04/19 >>>
                //// 2010/03/02 Add >>>
                //_dataList.Add(new ScmOdrData(
                //    scmHeaderData.CreateDateTime, 
                //    scmHeaderData.UpdateDateTime, 
                //    scmHeaderData.LogicalDeleteCode, 
                //    scmHeaderData.InqOriginalEpCd, 
                //    scmHeaderData.InqOriginalSecCd, 
                //    scmHeaderData.InqOtherEpCd, 
                //    scmHeaderData.InqOtherSecCd, 
                //    scmHeaderData.InquiryNumber, 
                //    scmHeaderData.UpdateDate,
                //    scmHeaderData.UpdateTime, 
                //    scmHeaderData.AnswerDivCd, 
                //    scmHeaderData.JudgementDate, 
                //    scmHeaderData.InqOrdNote, 
                //    scmHeaderData.InqEmployeeCd, 
                //    scmHeaderData.InqEmployeeNm, 
                //    scmHeaderData.AnsEmployeeCd, 
                //    scmHeaderData.AnsEmployeeNm, 
                //    scmHeaderData.InquiryDate, 
                //    scmHeaderData.InqOrdDivCd, 
                //    scmHeaderData.InqOrdAnsDivCd, 
                //    scmHeaderData.ReceiveDateTime, 
                //    0
                //    ));
                //// 2010/03/02 Add <<<

                // 2011/02/25 >>>
                //_dataList.Add(new UserSCMOrderHeaderRecord(scmHeaderData));
                if (scmHeaderData.AnswerDivCd == 20 || scmHeaderData.AnswerCreateDiv == 2) 
                {
                    // 回答済みデータリストに追加
                    _answerdDataList.Add(new UserSCMOrderHeaderRecord(scmHeaderData));
                }
                else
                {
                    // CMT連携データは対象外
                    if (scmHeaderData.CMTCooprtDiv == 1) return;

                    // 回答完了データは対象外
                    //if (scmHeaderData.AnswerDivCd == 20) return;

                    // 回答完了データは対象外
                    //if (scmHeaderData.AnswerCreateDiv == 0 && scmHeaderData.AnswerDivCd == 10) return;


                    // 新着データリストに追加
                    _dataList.Add(new UserSCMOrderHeaderRecord(scmHeaderData));
                }
            
                // 2011/02/25 <<<
                // 2010/04/19 <<<
            }
        }

        // 2010/03/02 <<<

        // 2010/04/19 >>>
        #region 削除

        ///// <summary>
        ///// 本日の件数を取得します。
        ///// </summary>
        ///// <param name="scmSearchedResult">SCM I/O Writer::ScmSearch()の検索結果</param>
        ///// <returns>検索結果からSCM受注データ.更新年月日が本日であるものの件数を返します。</returns>
        //public static int GetCountOfToday(object scmSearchedResult)
        //{
        //    #region <Guard Phrase>

        //    if (scmSearchedResult == null) return 0;

        //    #endregion // </Guard Phrase>

        //    CustomSerializeArrayList scmSearchedResultListSource = scmSearchedResult as CustomSerializeArrayList;
        //    if (scmSearchedResultListSource == null || scmSearchedResultListSource.Count.Equals(0)) return 0;

        //    // 2010/03/02 >>>
        //    //List<CustomSerializeArrayList> scmSearchedResultList = new List<CustomSerializeArrayList>(
        //    //    (CustomSerializeArrayList[])scmSearchedResultListSource.ToArray(typeof(CustomSerializeArrayList))
        //    //);
        //    List<SCMAcOdrDataWork> scmSearchedResultList = new List<SCMAcOdrDataWork>(
        //        (SCMAcOdrDataWork[])scmSearchedResultListSource.ToArray(typeof(SCMAcOdrDataWork))
        //    );
        //    // 2010/03/02 <<<

        //    SCMSearchedResultHelper helper = new SCMSearchedResultHelper();
        //    scmSearchedResultList.ForEach(helper.CountToday);

        //    return helper.Count;
        //}

        //// 2010/03/02 Add >>>
        ///// <summary>
        ///// 本日の件数を取得します。
        ///// </summary>
        ///// <param name="scmSearchedResult">SCM I/O Writer::ScmSearch()の検索結果</param>
        ///// <returns>検索結果からSCM受注データ.更新年月日が本日であるものの件数を返します。</returns>
        //public static List<ScmOdrData> GetListOfToday(object scmSearchedResult)
        //{
        //    #region <Guard Phrase>

        //    if (scmSearchedResult == null) return null;

        //    #endregion // </Guard Phrase>

        //    CustomSerializeArrayList scmSearchedResultListSource = scmSearchedResult as CustomSerializeArrayList;
        //    if (scmSearchedResultListSource == null || scmSearchedResultListSource.Count.Equals(0)) return null;

        //    // 2010/03/02 >>>
        //    //List<CustomSerializeArrayList> scmSearchedResultList = new List<CustomSerializeArrayList>(
        //    //    (CustomSerializeArrayList[])scmSearchedResultListSource.ToArray(typeof(CustomSerializeArrayList))
        //    //);
        //    List<SCMAcOdrDataWork> scmSearchedResultList = new List<SCMAcOdrDataWork>(
        //        (SCMAcOdrDataWork[])scmSearchedResultListSource.ToArray(typeof(SCMAcOdrDataWork))
        //    );
        //    // 2010/03/02 <<<

            
        //    SCMSearchedResultHelper helper = new SCMSearchedResultHelper();
        //    scmSearchedResultList.ForEach(helper.CountToday);

        //    return helper.DataList;
        //}
        //// 2010/03/02 Add <<<
        #endregion

        /// <summary>
        /// 本日の件数を取得します。
        /// </summary>
        /// <param name="scmSearchedResult">SCM I/O Writer::ScmSearch()の検索結果</param>
        /// <returns>検索結果からSCM受注データ.更新年月日が本日であるものの件数を返します。</returns>
        // 2011/02/25 >>>
        //public static List<ISCMOrderHeaderRecord> GetNewList(object scmSearchedResult, DateTime lastUpdateDate, int lastUpdateTime)
        public static ArrayList GetNewList(object scmSearchedResult, DateTime lastUpdateDate, int lastUpdateTime)
        // 2011/02/25 <<<
        {
            #region <Guard Phrase>

            if (scmSearchedResult == null) return null;

            #endregion // </Guard Phrase>

            CustomSerializeArrayList scmSearchedResultListSource = scmSearchedResult as CustomSerializeArrayList;
            if (scmSearchedResultListSource == null || scmSearchedResultListSource.Count.Equals(0)) return null;

            List<SCMAcOdrDataWork> scmSearchedResultList = new List<SCMAcOdrDataWork>(
                (SCMAcOdrDataWork[])scmSearchedResultListSource.ToArray(typeof(SCMAcOdrDataWork))
            );

            SCMSearchedResultHelper helper = new SCMSearchedResultHelper();
            helper.LastUpdateDate = lastUpdateDate;
            helper.LastUpdateTime = lastUpdateTime;
            scmSearchedResultList.ForEach(helper.GetNewData);

            // 2011/02/25 Add >>>
            //return helper.DataList;

            ArrayList retList = new ArrayList();
            retList.Add(helper.DataList);
            retList.Add(helper.AnswerdDataList);
            return retList;
            // 2011/02/25 Add <<<
        }
        // 2010/04/19 <<<
    }
}
