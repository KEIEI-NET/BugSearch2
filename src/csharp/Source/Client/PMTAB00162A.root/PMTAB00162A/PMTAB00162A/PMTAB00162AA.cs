//**********************************************************************//
// システム         ：PM.NS                                             //
// プログラム名称   ：得意先電子元帳データ取得アクセスクラス            //
// プログラム概要   ：得意先電子元帳データ取得アクセスクラス            //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴                                                                 //
//----------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : licb                                //
// 作 成 日  2013/05/29  作成内容 : 新規作成                            //
//----------------------------------------------------------------------//
// 修正内容  #37126の対応               　      
// 管理番号  10902622-01 作成担当 : licb                                   
// 作 成 日  2013/06/24  作成内容 : 得意先伝票履歴画面 伝票区分「全て」にすると表示されない
//----------------------------------------------------------------------//
// 修正内容  #37231の対応               　      
// 管理番号  10902622-01 作成担当 : licb                                   
// 作 成 日  2013/06/24  作成内容 : タブレットログ対応
//----------------------------------------------------------------------//
// 修正内容  #37133の対応               　      
// 管理番号  10902622-01 作成担当 : licb                                   
// 作 成 日  2013/06/29  作成内容 : 初期検索時４９伝票しか表示されない
//----------------------------------------------------------------------//
// 修正内容  #37693の対応               　      
// 管理番号  10902622-01 作成担当 : licb                                   
// 作 成 日  2013/07/02  作成内容 : 正常に動作しない場合がある
//----------------------------------------------------------------------//
// 修正内容  #37785の対応               　      
// 管理番号  10902622-01 作成担当 : licb                                   
// 作 成 日  2013/07/09  作成内容 : 次の50件が有効になりません
//----------------------------------------------------------------------//
// 修正内容  #38047の対応               　      
// 管理番号  10902622-01 作成担当 : licb                                   
// 作 成 日  2013/07/09  作成内容 : 入金伝票の明細表示がPMNSと異なる
//----------------------------------------------------------------------//
// 修正内容  #38182の対応               　      
// 管理番号  10902622-01 作成担当 : licb                                   
// 作 成 日  2013/07/11  作成内容 : 【自動回答処理(得意先電子元帳)】ソート
//----------------------------------------------------------------------//
// 修正内容  #38220の対応               　      
// 管理番号  10902622-01 作成担当 : licb                                   
// 作 成 日  2013/07/11  作成内容 : 不必要なログ出力の削除
//----------------------------------------------------------------------//
// 修正内容  #38430の対応               　      
// 管理番号  10902622-01 作成担当 : wangl2                                   
// 作 成 日  2013/07/16  作成内容 : 得意先伝票履歴　表示順の変更
//----------------------------------------------------------------------//
// 修正内容  指摘・確認事項一覧_社内確認用№385
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/07/22  作成内容 : 検索条件の拠点　ログイン拠点→パラメータの拠点
//----------------------------------------------------------------------//
// 修正内容  Redmine#38877
// 管理番号  10902622-01 作成担当 : 鄭慕鈞
// 作 成 日  2013/07/23  作成内容 : タブレット 得意先電子元帳の売上入力者名称をカット
//----------------------------------------------------------------------//
// 修正内容  ログ見直し
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/07/29  作成内容 : ログ見直し
//----------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先電子元帳データ取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先電子元帳データ取得アクセスクラス</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/05/29</br>
    /// <br>Update Note: ソースチェック確認事項一覧NO.9の対応</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/06/11</br>
    /// <br>Update Note: #37126の対応、得意先伝票履歴画面 伝票区分「全て」にすると表示されない</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/06/24</br>
    /// <br>Update Note: Redmine#37231 FOR タブレットログ対応</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/06/25</br>
    /// <br>Update Note: Redmine#37133 FOR 初期検索時４９伝票しか表示されない</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/06/29</br>
    /// <br>Update Note: Redmine#37693 FOR 正常に動作しない場合がある</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/02</br>
    /// <br>Update Note: Redmine#37785 FOR 次の50件が有効になりません</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/09</br>
    /// <br>Update Note: Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/09</br>
    /// <br>Update Note: Redmine#38182 FOR 【自動回答処理(得意先電子元帳)】ソート</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/11</br>
    /// <br>Update Note: Redmine#38220 FOR 不必要なログ出力の削除</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/11</br>
    /// </remarks>
    public class CustPrtSlipTabSearchAcs
    {
        #region ■ Private Members

        private ICustPrtPprWorkDB _iCustPrtPprWorkDB;  //得意先電子元帳リモート
        private IPmTabPrtPprRsltDB _iPmTabPrtPprRsltDB; //PMTAB得意先電子元帳リモート

        // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
        private const string CLASS_NAME = "CustPrtSlipTabSearchAcs";
        // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
       
        #endregion ■ Private Members
        /// <summary>
        /// 常駐処理にお知らせる為の変数
        /// </summary>
        public event NotifyTabletByPublishEventHandler notifyTabletByPublish;
        /// <summary>
        /// 常駐処理にお知らせる為のメソッド
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <param name="pmTabSearchGuid"></param>
        public delegate void NotifyTabletByPublishEventHandler(int status, string msg, string pmTabSearchGuid); 

        #region ■ Constructor
        /// <summary>
        /// 得意先電子元帳データ取得アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先電子元帳データ取得アクセスクラス</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        public CustPrtSlipTabSearchAcs()
        {
            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
            // コンストラクタでログ出力用ディレクトリを作成
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
            try
            {
                // リモートインスタンス取得
                this._iCustPrtPprWorkDB = MediationCustPrtPprWorkDB.GetCustPrtPprWorkDB();
                this._iPmTabPrtPprRsltDB = MediationPmTabPrtPprRsltDB.GetPmTabPrtPprRsltDB();

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCustPrtPprWorkDB = null;
            }
        }
        #endregion ■ Constructor

        #region ■ Public Methods

        #region 検索処理

        #region 検索処理(得意先電子元帳PM_USER_DB)
        /// <summary>
        /// 検索処理(得意先電子元帳PM_USER_DB)
        /// </summary>
        /// <param name="enterpriseCode">得意先電子元帳リスト</param>
        /// <param name="sectionCode">得意先電子元帳検索条件</param>
        /// <param name="custPrtPprWork"></param>
        /// <param name="pmTabSearchGuid"></param>
        /// <param name="callCount"></param>
        /// <param name="msg"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先電子元帳マスタを検索します。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/05/29</br>
        /// <br>Update Note: ソースチェック確認事項一覧NO.9の対応</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/11</br>
        /// <br>Update Note: #37126の対応、得意先伝票履歴画面 伝票区分「全て」にすると表示されない</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/24</br>
        /// <br>Update Note: Redmine#37231 FOR タブレットログ対応</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/25</br>
        /// <br>Update Note: Redmine#37133 FOR 初期検索時４９伝票しか表示されない</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/29</br>
        /// <br>Update Note: Redmine#37693 FOR 正常に動作しない場合がある</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/02</br>
        /// <br>Update Note: Redmine#37785 FOR 次の50件が有効になりません</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        /// <br>Update Note: Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        /// <br>Update Note: Redmine#38182 FOR 【自動回答処理(得意先電子元帳)】ソート</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/11</br>
        /// </remarks>
        public int SearchPmToScm(string enterpriseCode, string sectionCode, CustPrtPprWork custPrtPprWork, string pmTabSearchGuid, int callCount, out string msg)
        {
            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
            const string methodName = "SearchPmToScm";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "▼▼▼▼▼自動回答処理(得意先電子元帳)処理　開始▼▼▼▼▼");
            EasyLogger.Write(CLASS_NAME, methodName, "▼自動回答処理(得意先電子元帳)処理　開始▼");
            // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName,
                "検索条件　企業コード：" + enterpriseCode
                + "  拠点コード：" + sectionCode
                + "  AcptAnOdrStatus：" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.AcptAnOdrStatus)
                + "  St_SalesDate：" + custPrtPprWork.St_SalesDate.ToString()
                + "  Ed_SalesDate：" + custPrtPprWork.Ed_SalesDate.ToString()
                + "  SectionCode：" + string.Join(",", custPrtPprWork.SectionCode)
                + "  SalesSlipCd：" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.SalesSlipCd)
                + "  SearchType：" + custPrtPprWork.SearchType.ToString()
                + "  PMTAB検索GUID：" + pmTabSearchGuid
                + "  通知件数：" + callCount.ToString()
                );
            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
            ArrayList pmTabPrtPprRsltWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            msg = string.Empty;
            bool msgDiv = false;// ADD  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応

            try
            {
                if (!string.IsNullOrEmpty(pmTabSearchGuid))
                {
                    // 残高照会に表示するので１件のみ
                    CustPrtPprBlDspRsltWork custPrtPprBlDspRsltWork = new CustPrtPprBlDspRsltWork();
                    object custPrtPprBlDspRsltWorkObj = (object)custPrtPprBlDspRsltWork;

                    // 明細なのでrecordCount件数配列で帰ってくる
                    CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork = new CustPrtPprSalTblRsltWork();
                    object custPrtPprSalTblRsltWorkObj = (object)custPrtPprSalTblRsltWork;

                    // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№385 ------------>>>>>>>>>>>>
                    // this.SetSearchCondition(ref custPrtPprWork, enterpriseCode, sectionCode);
                    this.SetSearchCondition(ref custPrtPprWork, enterpriseCode, custPrtPprWork.SectionCode[0]);
                    // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№385 ------------<<<<<<<<<<<<

                    long counter = 0;

                    // 検索処理
                    // 削除分を含まない場合はGetData0を指定(削除フラグ=0のデータを返す)
                    status = this._iCustPrtPprWorkDB.SearchRef(ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData0);

                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) //DEL licb 2013/06/24 部品検索時に空白メッセージが表示される　#37126の対応
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)//ADD licb 2013/06/24 部品検索時に空白メッセージが表示される　#37126の対応
                    {
                        // パラメータが渡って来ているか確認
                        ArrayList retList = custPrtPprSalTblRsltWorkObj as ArrayList;
                        if (retList == null)
                        {
                            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
                            // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(得意先電子元帳)処理　終了▲▲▲▲▲");
                            EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(得意先電子元帳)処理　終了▲");
                            // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　status：" + status.ToString() + " 得意先電子元帳検索結果が存在しません");
                            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
                            return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                        }

                        if (counter == 0)
                        {
                            msg = "該当するデータがありません。";
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
                            // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(得意先電子元帳)処理　終了▲▲▲▲▲");
                            EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(得意先電子元帳)処理　終了▲");
                            // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　status：" + status.ToString() + " " + msg);
                            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
                            return status;

                        }
                        // --------------- DEL START 2013/06/29 licb  Redmine#37133 FOR 初期検索時４９伝票しか表示されない------>>>>
                        #region DEL
                        //// データ変換
                        //if (counter <= callCount)
                        //{

                        //    for (int i = 0; i < retList.Count; i++)
                        //    {
                        //        CustPrtPprSalTblRsltWork tempCustPrtPprSalTblRsltWork = retList[i] as CustPrtPprSalTblRsltWork;
                        //        int rowNo = i; //PMTAB検索行番
                        //        // クラスメンバコピー処理
                        //        pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt(tempCustPrtPprSalTblRsltWork, pmTabSearchGuid, rowNo, sectionCode, enterpriseCode));
 
                        //    }

                        //    // status = this.Write(pmTabPrtPprRsltWorkList, out msg);// DEL  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                        //    status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);// ADD  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        msg = "検索完了しました。";
                        //    }

                        //}
                        //else
                        //{
                        //    //通知件数がある場合
                        //    if (callCount != 0 && callCount != -1)
                        //    {　　//回数
                        //        long tempCnt = counter / callCount;
                        //        int tempCnt2 = 1;
                        //        for (int temp = 1; temp <= tempCnt; temp++)
                        //        {

                        //            for (int i = callCount * (tempCnt2 - 1); i < callCount * temp; i++)
                        //            {
                        //                //クラスメンバコピー処理
                        //                pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt((CustPrtPprSalTblRsltWork)retList[i], pmTabSearchGuid, i, sectionCode, enterpriseCode));
                        //            }
                        //            //status = this.Write(pmTabPrtPprRsltWorkList, out msg);// DEL  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                        //            status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);// ADD  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                        //            pmTabPrtPprRsltWorkList.Clear();
                        //            string strCount = Convert.ToString(callCount);
                        //            if (!((counter == tempCnt * callCount) && (temp == tempCnt)))
                        //            {
                        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //                {
                        //                    msg = strCount + "件検索しました。";
                        //                }
                        //                notifyTabletByPublish(status, msg, pmTabSearchGuid);
                        //            }
                        //            else
                        //            {
                        //                msg = "検索完了しました。";
                        //            }
                        //            tempCnt2 = tempCnt2 + 1;
                        //        }
                        //        if (counter > tempCnt * callCount)
                        //        {
                        //            pmTabPrtPprRsltWorkList.Clear();

                        //            for (int j = Convert.ToInt32(tempCnt * callCount); j < counter; j++)
                        //            {
                        //                //クラスメンバコピー処理
                        //                pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt((CustPrtPprSalTblRsltWork)retList[j], pmTabSearchGuid, j, sectionCode, enterpriseCode));

                        //            }
                        //            //status = this.Write(pmTabPrtPprRsltWorkList, out msg);// DEL  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                        //            status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);// ADD  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                        //            pmTabPrtPprRsltWorkList.Clear();
                        //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //            {
                        //                msg = "検索完了しました。";
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        foreach (CustPrtPprSalTblRsltWork tempCustPrtPprSalTblRsltWork in retList)
                        //        {
                        //            int rowNo = 0; //PMTAB検索行番
                        //            // クラスメンバコピー処理
                        //            pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt(tempCustPrtPprSalTblRsltWork, pmTabSearchGuid, rowNo, sectionCode, enterpriseCode));
                        //        }

                        //        //status = this.Write(pmTabPrtPprRsltWorkList, out msg);// DEL  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                        //        status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);// ADD  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //        {
                        //            msg = "検索完了しました。";
                        //        }

                        //    }

                        //}
                        #endregion DEL
                        // --------------- DEL END 2013/06/29 licb  Redmine#37133 FOR 初期検索時４９伝票しか表示されない------<<<<
                        // --------------- ADD START 2013/06/29 licb  Redmine#37133 FOR 初期検索時４９伝票しか表示されない------>>>>
                        Dictionary<string, List<CustPrtPprSalTblRsltWork>> RsltWorkDic = new Dictionary<string, List<CustPrtPprSalTblRsltWork>>();


                        // --------------- ADD START 2013/07/11 licb  Redmine#38182 FOR 【自動回答処理(得意先電子元帳)】ソート------>>>>
                        List<CustPrtPprSalTblRsltWork> sortWk = new List<CustPrtPprSalTblRsltWork>((CustPrtPprSalTblRsltWork[])retList.ToArray(typeof(CustPrtPprSalTblRsltWork)));
                        sortWk.Sort(delegate(CustPrtPprSalTblRsltWork x, CustPrtPprSalTblRsltWork y)
                        {
                            int st = 0;
                            //st = x.SalesDate.CompareTo(y.SalesDate);// DEL 2013/07/16 wangl2  Redmine#38430
                            st = (-1) * x.SalesDate.CompareTo(y.SalesDate);// ADD 2013/07/16 wangl2  Redmine#38430
                            if (st != 0) return st;
                            st = x.DataDiv.CompareTo(y.DataDiv);
                            if (st != 0) return st;
                            //st = x.SalesSlipNum.CompareTo(y.SalesSlipNum);// DEL 2013/07/16 wangl2  Redmine#38430
                            st = (-1) * x.SalesSlipNum.CompareTo(y.SalesSlipNum);// ADD 2013/07/16 wangl2  Redmine#38430
                            if (st != 0) return st;
                            st = x.AcptAnOdrStatus.CompareTo(y.AcptAnOdrStatus);
                            if (st != 0) return st;
                            st = x.SalesSlipCd.CompareTo(y.SalesSlipCd);
                            if (st != 0) return st;
                            st = x.SalesRowNo.CompareTo(y.SalesRowNo);
                            return st;
                        });
                        retList = new ArrayList();
                        retList.AddRange(sortWk);
                        // --------------- ADD START 2013/07/11 licb  Redmine#38182 FOR 【自動回答処理(得意先電子元帳)】ソート------<<<<

                         // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------>>>>
                        // 伝票単位は、「伝票番号」及び「受注ステータス」が同一のものをひとつのくくりとして判定する
                        CustPrtPprSalTblRsltWork prevRsltTempWork = null; // 1つ前の検索結果
                        List<CustPrtPprSalTblRsltWork> listWk = null;
                        // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------<<<<
                        foreach (CustPrtPprSalTblRsltWork rsltTempWork in retList)
                        {
                             // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------>>>>
                            listWk = new List<CustPrtPprSalTblRsltWork>();
                            if (rsltTempWork.DataDiv == 1 && string.IsNullOrEmpty(rsltTempWork.GoodsName))
                            {
                                // 入金かつ 手数料、値引きのみの場合
                                listWk = AddFeeAndDiscountRow(rsltTempWork);
                            }
                            else
                            {
                                listWk.Add(rsltTempWork);
                            }
                            // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------<<<<

                             // --------------- DEL START 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------>>>>
                            # region 旧ソース
                            //string key = rsltTempWork.SalesSlipNum;//DEL 2013/07/02 licb  Redmine#37693 FOR 正常に動作しない場合がある
                            //string key = rsltTempWork.SalesSlipNum + rsltTempWork.AcptAnOdrStatus;//ADD 2013/07/02 licb  Redmine#37693 FOR 正常に動作しない場合がある
                            //if (RsltWorkDic.ContainsKey(key))
                            //{
                            //    RsltWorkDic[key].Add(rsltTempWork);
                            //}
                            //else
                            //{
                            //    List<CustPrtPprSalTblRsltWork> list = new List<CustPrtPprSalTblRsltWork>();
                            //    list.Add(rsltTempWork);
                            //    RsltWorkDic.Add(key, list);
                            //}
                            #endregion
                            // --------------- DEL END 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------<<<<

                             // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------>>>>
                            // 登録処理用ディクショナリ作成
                            MakeRsltWorkDic(ref RsltWorkDic, listWk);
                            // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------<<<<

                             // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------>>>>
                            // 1つ前の伝票が入金の場合にprevRsltTempWorkが作成されている
                            if (prevRsltTempWork != null)
                            {
                                // 1つ前の検索結果と伝票が変わった場合
                                if ((!rsltTempWork.SalesSlipNum.Equals(prevRsltTempWork.SalesSlipNum) || rsltTempWork.AcptAnOdrStatus != prevRsltTempWork.AcptAnOdrStatus))
                                {
                                    listWk = null;
                                    // 手数料、値引きのデータを生成し、ディクショナリに追加
                                    listWk = AddFeeAndDiscountRow(prevRsltTempWork);
                                    MakeRsltWorkDic(ref RsltWorkDic, listWk);

                                    prevRsltTempWork = null;
                                }
                            }

                            // 入金の場合、手数料、値引きの明細は伝票が変わったタイミングで生成するので、保管する
                            // 但し、手数料、値引きのみの場合は対象外
                            if (prevRsltTempWork == null && rsltTempWork.DataDiv == 1 && !string.IsNullOrEmpty(rsltTempWork.GoodsName))
                            {
                                prevRsltTempWork = rsltTempWork;
                            }
                            // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------<<<<
                        }
                         // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------>>>>
                        // 最後のの伝票が入金の場合にprevRsltTempWorkが作成されている
                        if (prevRsltTempWork != null)
                        {
                            listWk = null;
                            // 手数料、値引きのデータを生成し、ディクショナリに追加
                            listWk = AddFeeAndDiscountRow(prevRsltTempWork);
                            MakeRsltWorkDic(ref RsltWorkDic, listWk);

                            prevRsltTempWork = null;
                        }
                        // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------<<<<
                        int salesSlipCount = RsltWorkDic.Count; //伝票枚数;

                        callCount = callCount * 2;//ADD 2013/07/09 licb  Redmine#37785 FOR 次の50件が有効になりません

                        #region 登録処理
                        // データ変換
                        if (salesSlipCount <= callCount)//通知件数より伝票枚数は小さい場合
                        {

                            int rowNo = 0; //PMTAB検索行番

                            foreach (KeyValuePair<string, List<CustPrtPprSalTblRsltWork>> tempKeyValue in RsltWorkDic)
                            {

                                List<CustPrtPprSalTblRsltWork> custPrtPprSalTblRsltWorkList = tempKeyValue.Value;

                                for (int listCount = 0; listCount < custPrtPprSalTblRsltWorkList.Count; listCount++)
                                {
                                    // クラスメンバコピー処理
                                    pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt(custPrtPprSalTblRsltWorkList[listCount], pmTabSearchGuid, rowNo, sectionCode, enterpriseCode));
                                }
                                ++rowNo;

                            }

                            status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                msg = "検索完了しました。";
                            }

                        }
                        else//通知件数より伝票枚数は大きい場合
                        {
                            //通知件数がある場合
                            if (callCount > 0)
                            {
                                int rowNo = 0;//PMTAB検索行番号
                                int keyCount = 0;//当前件数
                                foreach (KeyValuePair<string, List<CustPrtPprSalTblRsltWork>> tempKeyValue in RsltWorkDic)
                                {
                                    List<CustPrtPprSalTblRsltWork> custPrtPprSalTblRsltWorkList = tempKeyValue.Value;

                                    if (keyCount == callCount)
                                    {
                                        status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            if (rowNo == salesSlipCount)
                                            {
                                                msg = "検索完了しました。";
                                            }
                                            else
                                            {
                                                msg = callCount.ToString() + "件検索しました。";

                                                notifyTabletByPublish(status, msg, pmTabSearchGuid);
                                                pmTabPrtPprRsltWorkList.Clear();
                                            }
                                        }

                                        keyCount = 0;//当前件数
                                    }

                                    for (int listCount = 0; listCount < custPrtPprSalTblRsltWorkList.Count; listCount++)
                                    {
                                        // クラスメンバコピー処理
                                        pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt(custPrtPprSalTblRsltWorkList[listCount], pmTabSearchGuid, rowNo, sectionCode, enterpriseCode));
                                    }

                                    ++rowNo;
                                    ++keyCount;
                                }

                                if (pmTabPrtPprRsltWorkList.Count > 0)
                                {
                                    status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        msg = "検索完了しました。";
                                    }

                                }


                            }

                        }

                        #endregion　登録処理

                        // --------------- ADD END 2013/06/29 licb  Redmine#37133 FOR 初期検索時４９伝票しか表示されない------<<<<

                    }　

                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    msg = "得意先電子元帳検索失敗しました";
 
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
               // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
               // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
            }

            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
            // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(得意先電子元帳)処理　終了▲▲▲▲▲");
            EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(得意先電子元帳)処理　終了▲");
            // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　status：" + status.ToString() + " " + msg);
            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<

            return (status);
        }

        // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------>>>>

        /// <summary>
        /// 登録処理用ディクショナリ作成
        /// </summary>
        /// <param name="RsltWorkDic">登録処理用ディクショナリ</param>
        /// <param name="listWk">登録対象得意先電子元帳データリスト</param>
        /// <br>Note       : 登録処理用ディクショナリ作成。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        private void MakeRsltWorkDic(ref Dictionary<string, List<CustPrtPprSalTblRsltWork>> RsltWorkDic, List<CustPrtPprSalTblRsltWork> listWk)
        {
            if (listWk.Count <= 0) return;

            string key = listWk[0].SalesSlipNum + listWk[0].AcptAnOdrStatus;
            if (RsltWorkDic.ContainsKey(key))
            {
                foreach (CustPrtPprSalTblRsltWork wk in listWk)
                {
                    RsltWorkDic[key].Add(wk);
                }
            }
            else
            {
                RsltWorkDic.Add(key, listWk);
            }
        }

        /// <summary>
        /// 手数料、値引き 追加処理
        /// </summary>
        /// <param name="data"></param>
        /// <br>Note       : 手数料、値引き 追加処理。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        private List<CustPrtPprSalTblRsltWork> AddFeeAndDiscountRow(CustPrtPprSalTblRsltWork data)
        {
            List<CustPrtPprSalTblRsltWork> listTemp = new List<CustPrtPprSalTblRsltWork>();

            // 手数料明細追加
            if (data.FeeDeposit != 0)
            {
                CustPrtPprSalTblRsltWork wk = new CustPrtPprSalTblRsltWork();
                #region 手数料用明細作成
                wk.DataDiv = data.DataDiv;
                wk.SalesDate = data.SalesDate;
                wk.SalesSlipNum = data.SalesSlipNum;
                wk.SalesRowNo = 1000;
                wk.AcptAnOdrStatus = data.AcptAnOdrStatus;
                wk.SalesEmployeeNm = data.SalesEmployeeNm;
                wk.SalesSlipCd = data.SalesSlipCd;
                wk.SalesTotalTaxExc = data.SalesTotalTaxExc;
                wk.GoodsName = "手数料";
                wk.GoodsNo = data.GoodsNo;
                wk.BLGoodsCode = data.BLGoodsCode;
                wk.BLGroupCode = data.BLGroupCode;
                wk.SalesMoneyTaxExc = data.FeeDeposit;
                wk.SlipNote = data.SlipNote;
                wk.SlipNote2 = data.SlipNote2;
                wk.SlipNote3 = data.SlipNote3;
                wk.FrontEmployeeNm = data.FrontEmployeeNm;
                wk.SalesInputName = data.SalesInputName;
                wk.CustomerCode = data.CustomerCode;
                wk.CustomerSnm = data.CustomerSnm;
                wk.GuideName = data.GuideName;
                wk.DtlNote = this.GetValidityTerm(data.DtlNote); // 明細備考←有効期限をセット
                if (data.AddUpADate != DateTime.MinValue)
                {
                    wk.AddUpADate = data.AddUpADate;
                }
                wk.DebitNoteDiv = data.DebitNoteDiv;
                // 入力日
                if (data.InputDay != DateTime.MinValue)
                {
                    wk.InputDay = data.InputDay;
                }
                #endregion
                listTemp.Add(wk);
            }

            if (data.DiscountDeposit != 0)
            {
                CustPrtPprSalTblRsltWork wk = new CustPrtPprSalTblRsltWork();
                #region 値引用明細作成
                wk.DataDiv = data.DataDiv;
                wk.SalesDate = data.SalesDate;
                wk.SalesSlipNum = data.SalesSlipNum;
                wk.SalesRowNo = 1001;
                wk.AcptAnOdrStatus = data.AcptAnOdrStatus;
                wk.SalesEmployeeNm = data.SalesEmployeeNm;
                wk.SalesSlipCd = data.SalesSlipCd;
                wk.SalesTotalTaxExc = data.SalesTotalTaxExc;
                wk.GoodsName = "値引";
                wk.GoodsNo = data.GoodsNo;
                wk.BLGoodsCode = data.BLGoodsCode;
                wk.BLGroupCode = data.BLGroupCode;
                wk.SalesMoneyTaxExc = data.DiscountDeposit;
                wk.SlipNote = data.SlipNote;
                wk.SlipNote2 = data.SlipNote2;
                wk.SlipNote3 = data.SlipNote3;
                wk.FrontEmployeeNm = data.FrontEmployeeNm;
                wk.SalesInputName = data.SalesInputName;
                wk.CustomerCode = data.CustomerCode;
                wk.CustomerSnm = data.CustomerSnm;
                wk.GuideName = data.GuideName;
                wk.DtlNote = this.GetValidityTerm(data.DtlNote); // 明細備考←有効期限をセット
                if (data.AddUpADate != DateTime.MinValue)
                {
                    wk.AddUpADate = data.AddUpADate;
                }
                wk.DebitNoteDiv = data.DebitNoteDiv;
                // 入力日
                if (data.InputDay != DateTime.MinValue)
                {
                    wk.InputDay = data.InputDay;
                }
                #endregion
                listTemp.Add(wk);
            }

            return listTemp;
        }
        /// <summary>
        /// 有効期限取得処理
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <br>Note       : 有効期限取得処理。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        private string GetValidityTerm(string originText)
        {
            int validityTerm = 0;
            DateTime date;
            try
            {
                validityTerm = Int32.Parse(originText);
                date = GetDateTimeFromLongDate(validityTerm);
            }
            catch
            {
                date = DateTime.MinValue;
            }

            if (date == DateTime.MinValue)
            {
                // 空白にする
                return string.Empty;
            }
            else
            {
                // yyyy/mm/ddでセット
                return date.ToString("yyyy/MM/dd");
            }
        }
        /// <summary>
        /// 日付取得処理（int→DateTime変換）
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        /// <br>Note       : 日付取得処理（int→DateTime変換）。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        private DateTime GetDateTimeFromLongDate(int longDate)
        {
            try
            {
                return new DateTime((longDate / 10000), ((longDate / 100) % 100), (longDate % 100));
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR 入金伝票の明細表示がPMNSと異なる------<<<<

        #endregion 検索処理(得意先電子元帳PM_USER_DB)

        #endregion
        #endregion■ Public Methods

        #region■ 登録処理(得意先電子元帳)
        /// <summary>
        /// 更新処理(得意先電子元帳)
        /// </summary>
        /// <param name="pmTabPrtPprRsltWorkList">得意先電子元帳リスト</param>
        /// <param name="msg"></param>
        /// <param name="msgDiv">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先電子元帳マスタを更新します。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/05/29</br>
        /// <br>Update Note: ソースチェック確認事項一覧NO.9の対応</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/11</br>
        /// <br>Update Note: Redmine#37231 FOR タブレットログ対応</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/25</br>
        /// </remarks>
        //private int Write(ArrayList pmTabPrtPprRsltWorkList, out string msg)// DEL  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
        private int Write(ArrayList pmTabPrtPprRsltWorkList, out bool msgDiv, out string msg)// ADD  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
        {
            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
            const string methodName = "Write";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = string.Empty;
            msgDiv = false;// ADD  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
            object paraPmTabPrtPprRsltObj = (object)pmTabPrtPprRsltWorkList;
            try
            {
                  // 更新処理
                //status = this._iPmTabPrtPprRsltDB.Write(ref paraPmTabPrtPprRsltObj);// DEL  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                status = this._iPmTabPrtPprRsltDB.Write(ref paraPmTabPrtPprRsltObj, out msgDiv, out msg);// ADD  2013/06/11 licb FOR ソースチェック確認事項一覧NO.9の対応
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // パラメータが渡って来ているか確認
                        ArrayList retList = paraPmTabPrtPprRsltObj as ArrayList;
                        if (retList == null)
                        {
                           // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
                            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ConstantManagement.DB_Status.ctDB_ERROR");
                           // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
                            return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                        } 
                   }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
               // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
               // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
            }

           // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
           // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
            return status;
        }
        #endregion     
               
        #region ■ Private Methods

        #region クラスメンバコピー処理
        /// <summary>
        /// クラスメンバコピー処理
        /// </summary>
        /// <param name="custPrtPprSalTblRsltWork">得意先電子元帳マスタ</param>
        /// <param name="pmTabSearchGuid"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="rowNo"></param>
        /// <param name="sectionCode"></param>
        /// <returns>得意先電子元帳マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/05/29</br>
        /// <br>Update Note: Redmine#37231 FOR タブレットログ対応</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/25</br>
        /// <br>Update Note: Redmine#37133 FOR 初期検索時４９伝票しか表示されない</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/29</br>
        /// <br>Update Note: Redmine#38220 FOR 不必要なログ出力の削除</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/11</br>
        /// </remarks>
        private PmTabPrtPprRsltWork CopyToPmTabPrtFromCustPrt(CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork, string pmTabSearchGuid, int rowNo, string sectionCode, string enterpriseCode)
        {
            // --------------- DEL START 2013/07/11 licb  Redmine#38220 FOR 不必要なログ出力の削除----->>>>
           //// --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
           // const string methodName = "CopyToPmTabPrtFromCustPrt";
           // EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
           //// --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
            // --------------- DEL END 2013/07/11 licb  Redmine#38220 FOR 不必要なログ出力の削除------<<<<
            PmTabPrtPprRsltWork pmTabPrtPprRsltWork = new PmTabPrtPprRsltWork();

            pmTabPrtPprRsltWork.UpdateDateTime = new DateTime(custPrtPprSalTblRsltWork.UpdateDateTime);//更新日時
            pmTabPrtPprRsltWork.EnterpriseCode = enterpriseCode;
            pmTabPrtPprRsltWork.SearchSectionCode = sectionCode;	//検索拠点コード	
            pmTabPrtPprRsltWork.PmTabSearchGuid = pmTabSearchGuid;	//PMTAB検索GUID	
            // --------------- ADD START 2013/06/29 licb  Redmine#37133 FOR 初期検索時４９伝票しか表示されない------>>>>
            pmTabPrtPprRsltWork.PmTabSearchSlipNum = rowNo + 1;
            // --------------- ADD END 2013/06/29 licb  Redmine#37133 FOR 初期検索時４９伝票しか表示されない------<<<<
            //pmTabPrtPprRsltWork.PmTabSearchRowNum = rowNo + 1;	//PMTAB検索行番号//DEL 2013/06/29 licb  Redmine#37133 FOR 初期検索時４９伝票しか表示されない	
            pmTabPrtPprRsltWork.PmTabSearchRowNum = custPrtPprSalTblRsltWork.SalesRowNo; //PMTAB検索行番号//ADD 2013/06/29 licb  Redmine#37133 FOR 初期検索時４９伝票しか表示されない
            pmTabPrtPprRsltWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));//データ削除予定日	
	        pmTabPrtPprRsltWork.SalesDepoDiv = custPrtPprSalTblRsltWork.DataDiv;	//売上入金区分	
            pmTabPrtPprRsltWork.SalesDate = Convert.ToInt32(custPrtPprSalTblRsltWork.SalesDate.ToString("yyyyMMdd"));	//売上日付	
	        pmTabPrtPprRsltWork.SalesSlipNum = custPrtPprSalTblRsltWork.SalesSlipNum;	//売上伝票番号	
	        pmTabPrtPprRsltWork.SalesRowNo = custPrtPprSalTblRsltWork.SalesRowNo;	//売上行番号	
	        pmTabPrtPprRsltWork.AcptAnOdrStatus = custPrtPprSalTblRsltWork.AcptAnOdrStatus;//受注ステータス	
	        pmTabPrtPprRsltWork.SalesSlipCd = custPrtPprSalTblRsltWork.SalesSlipCd;//売上伝票区分	
	        pmTabPrtPprRsltWork.SalesEmployeeNm = custPrtPprSalTblRsltWork.SalesEmployeeNm;//販売従業員名称	
	        pmTabPrtPprRsltWork.SalesTotalTaxExc = custPrtPprSalTblRsltWork.SalesTotalTaxExc;	//売上伝票合計（税抜き）	
	        pmTabPrtPprRsltWork.GoodsName = custPrtPprSalTblRsltWork.GoodsName;	//商品名称	
	        pmTabPrtPprRsltWork.GoodsNo = custPrtPprSalTblRsltWork.GoodsNo;	//商品番号	
	        pmTabPrtPprRsltWork.BLGoodsCode = custPrtPprSalTblRsltWork.BLGoodsCode;	//BL商品コード	
	        pmTabPrtPprRsltWork.BlGroupCode = custPrtPprSalTblRsltWork.BLGroupCode;	//BLグループコード	
	        pmTabPrtPprRsltWork.ShipmentCnt = custPrtPprSalTblRsltWork.ShipmentCnt;	//出荷数	
	        pmTabPrtPprRsltWork.ListPriceTaxExcFl = custPrtPprSalTblRsltWork.ListPriceTaxExcFl;	//定価（税抜，浮動）	
	        pmTabPrtPprRsltWork.CostRate = custPrtPprSalTblRsltWork.CostRate;	//原価率	
	        pmTabPrtPprRsltWork.SalesRate = custPrtPprSalTblRsltWork.SalesRate;	//売価率	
	        pmTabPrtPprRsltWork.OpenPriceDiv = custPrtPprSalTblRsltWork.OpenPriceDiv;	//オープン価格区分	
	        pmTabPrtPprRsltWork.SalesUnPrcTaxExcFl = custPrtPprSalTblRsltWork.SalesUnPrcTaxExcFl;	//売上単価（税抜，浮動）	
	        pmTabPrtPprRsltWork.SalesUnitCost = custPrtPprSalTblRsltWork.SalesUnitCost;	//原価単価	
	        pmTabPrtPprRsltWork.SalesMoneyTaxExc = custPrtPprSalTblRsltWork.SalesMoneyTaxExc;	//売上金額（税抜き）	
	        pmTabPrtPprRsltWork.ConsTaxLayMethod = custPrtPprSalTblRsltWork.ConsTaxLayMethod;	//消費税転嫁方式	
	        pmTabPrtPprRsltWork.SalesTotalTaxInc = custPrtPprSalTblRsltWork.SalesTotalTaxInc;	//売上伝票合計（税込み）	
	        pmTabPrtPprRsltWork.SalesPriceConsTax = custPrtPprSalTblRsltWork.SalesPriceConsTax;	//売上金額消費税額	
	        pmTabPrtPprRsltWork.TotalCost = custPrtPprSalTblRsltWork.TotalCost;	//原価金額計	
	        pmTabPrtPprRsltWork.ModelDesignationNo = custPrtPprSalTblRsltWork.ModelDesignationNo;	//型式指定番号	
	        pmTabPrtPprRsltWork.CategoryNo = custPrtPprSalTblRsltWork.CategoryNo;	//類別番号	
	        pmTabPrtPprRsltWork.ModelFullName = custPrtPprSalTblRsltWork.ModelFullName;	//車種全角名称	
	        pmTabPrtPprRsltWork.FirstEntryDate = custPrtPprSalTblRsltWork.FirstEntryDate;	//初年度	
	        pmTabPrtPprRsltWork.PmFrameNo = custPrtPprSalTblRsltWork.SearchFrameNo;	//PM車台番号	
	        pmTabPrtPprRsltWork.FullModel = custPrtPprSalTblRsltWork.FullModel;	//型式（フル型）	
	        pmTabPrtPprRsltWork.SlipNote = custPrtPprSalTblRsltWork.SlipNote;	//伝票備考	
	        pmTabPrtPprRsltWork.SlipNote2 = custPrtPprSalTblRsltWork.SlipNote2;	//伝票備考２	
	        pmTabPrtPprRsltWork.SlipNote3 = custPrtPprSalTblRsltWork.SlipNote3;	//伝票備考３	
	        pmTabPrtPprRsltWork.FrontEmployeeNm = custPrtPprSalTblRsltWork.FrontEmployeeNm;	//受付従業員名称	
            //pmTabPrtPprRsltWork.SalesInputName = custPrtPprSalTblRsltWork.SalesInputName;	//売上入力者名称	// DEL 鄭慕鈞 2013/07/23 Redmine#38877 タブレット 得意先電子元帳の売上入力者名称をカット
            // ----- 鄭慕鈞 2013/07/23 Redmine#38877 タブレット 得意先電子元帳の売上入力者名称をカット----->>>>>
            if (custPrtPprSalTblRsltWork.SalesInputName.Length > 16)
            {
                pmTabPrtPprRsltWork.SalesInputName = custPrtPprSalTblRsltWork.SalesInputName.Substring(0,16);	//売上入力者名称	
            }
            else
            {
                pmTabPrtPprRsltWork.SalesInputName = custPrtPprSalTblRsltWork.SalesInputName;	//売上入力者名称	
            }
            // -----ADD 鄭慕鈞 2013/07/23 Redmine#38877 タブレット 得意先電子元帳の売上入力者名称をカット-----<<<<<
	        pmTabPrtPprRsltWork.CustomerCode = custPrtPprSalTblRsltWork.CustomerCode;	//得意先コード	
	        pmTabPrtPprRsltWork.CustomerSnm = custPrtPprSalTblRsltWork.CustomerSnm;	//得意先略称	
	        pmTabPrtPprRsltWork.SupplierCd = custPrtPprSalTblRsltWork.SupplierCd;	//仕入先コード	
	        pmTabPrtPprRsltWork.SupplierSnm = custPrtPprSalTblRsltWork.SupplierSnm;	//仕入先略称	
	        pmTabPrtPprRsltWork.PartySaleSlipNum = custPrtPprSalTblRsltWork.PartySaleSlipNum;	//相手先伝票番号	
	        pmTabPrtPprRsltWork.CarMngCode = custPrtPprSalTblRsltWork.CarMngCode;	//車両管理コード	
	        pmTabPrtPprRsltWork.AcceptAnOrderNo = custPrtPprSalTblRsltWork.AcceptAnOrderNo;	//受注番号	
	        pmTabPrtPprRsltWork.ShipmSalesSlipNum = custPrtPprSalTblRsltWork.ShipmSalesSlipNum;	//計上元出荷伝票番号	
	        pmTabPrtPprRsltWork.SrcSaleSlipNum = custPrtPprSalTblRsltWork.SrcSalesSlipNum;	//元売上伝票番号	
            pmTabPrtPprRsltWork.SalesOrderDivCd = custPrtPprSalTblRsltWork.SalesOrderDivCd;	//売上在庫取寄せ区分	
	        pmTabPrtPprRsltWork.WarehouseName = custPrtPprSalTblRsltWork.WarehouseName;	//倉庫名称	
	        pmTabPrtPprRsltWork.SupplierSlipNo = custPrtPprSalTblRsltWork.SupplierSlipNo;	//仕入伝票番号	
	        pmTabPrtPprRsltWork.UOESupplierCd = custPrtPprSalTblRsltWork.UOESupplierCd;	//UOE発注先コード	
	        pmTabPrtPprRsltWork.UOESupplierName = custPrtPprSalTblRsltWork.UOESupplierSnm;	//UOE発注先名称	
	        pmTabPrtPprRsltWork.UoeRemark1 = custPrtPprSalTblRsltWork.UoeRemark1;	//ＵＯＥリマーク１	
	        pmTabPrtPprRsltWork.UoeRemark2 = custPrtPprSalTblRsltWork.UoeRemark2;	//ＵＯＥリマーク２	
	        pmTabPrtPprRsltWork.GuideName = custPrtPprSalTblRsltWork.GuideName;	//ガイド名称	
	        pmTabPrtPprRsltWork.SectionGuideNm = custPrtPprSalTblRsltWork.SectionGuideNm;	//拠点ガイド名称	
	        pmTabPrtPprRsltWork.DtlNote = custPrtPprSalTblRsltWork.DtlNote;	//明細備考	
	        pmTabPrtPprRsltWork.ColorName1 = custPrtPprSalTblRsltWork.ColorName1;	//カラー名称1	
	        pmTabPrtPprRsltWork.TrimName = custPrtPprSalTblRsltWork.TrimName;	//トリム名称	
	        pmTabPrtPprRsltWork.StdUnPrcLPrice = custPrtPprSalTblRsltWork.StdUnPrcLPrice;	//基準単価（定価）	
	        pmTabPrtPprRsltWork.StdUnPrcSalUnPrc = custPrtPprSalTblRsltWork.StdUnPrcSalUnPrc;	//基準単価（売上単価）	
	        pmTabPrtPprRsltWork.StdUnPrcUnCst = custPrtPprSalTblRsltWork.StdUnPrcUnCst;	//基準単価（原価単価）	
	        pmTabPrtPprRsltWork.BfSalesUnitPrice = custPrtPprSalTblRsltWork.BfSalesUnitPrice;	//変更前売価	
	        pmTabPrtPprRsltWork.BfUnitCost = custPrtPprSalTblRsltWork.BfUnitCost;	//変更前原価	
	        pmTabPrtPprRsltWork.BfListPrice = custPrtPprSalTblRsltWork.BfListPrice;	//変更前定価	
	        pmTabPrtPprRsltWork.GoodsMakerCd = custPrtPprSalTblRsltWork.GoodsMakerCd;	//商品メーカーコード	
	        pmTabPrtPprRsltWork.MakerName = custPrtPprSalTblRsltWork.MakerName;	//メーカー名称	
	        pmTabPrtPprRsltWork.Cost = custPrtPprSalTblRsltWork.Cost;	//原価	
	        pmTabPrtPprRsltWork.CustSlipNo = custPrtPprSalTblRsltWork.CustSlipNo;	//得意先伝票番号	
	        pmTabPrtPprRsltWork.AddUpADate = Convert.ToInt32(custPrtPprSalTblRsltWork.AddUpADate.ToString("yyyyMMdd"));	//計上日付	
	        pmTabPrtPprRsltWork.AccRecDivCd = custPrtPprSalTblRsltWork.AccRecDivCd;	//売掛区分	
	        pmTabPrtPprRsltWork.DebitNoteDiv = custPrtPprSalTblRsltWork.DebitNoteDiv;	//赤伝区分	
	        pmTabPrtPprRsltWork.SectionCode = custPrtPprSalTblRsltWork.SectionCode;	//拠点コード	
	        pmTabPrtPprRsltWork.WarehouseCode = custPrtPprSalTblRsltWork.WarehouseCode;	//倉庫コード	
	        pmTabPrtPprRsltWork.TotalAmountDispWayCd = custPrtPprSalTblRsltWork.TotalAmountDispWayCd;	//総額表示方法区分	
	        pmTabPrtPprRsltWork.TaxationDivCd = custPrtPprSalTblRsltWork.TaxationDivCd;//課税区分	
            pmTabPrtPprRsltWork.StockPartySaleSlipNum = custPrtPprSalTblRsltWork.StockPartySaleSlipNum;	//仕入先伝票番号	
	        pmTabPrtPprRsltWork.AddresseeCode = custPrtPprSalTblRsltWork.AddresseeCode;	//納品先コード	
	        pmTabPrtPprRsltWork.AddresseeName = custPrtPprSalTblRsltWork.AddresseeName;	//納品先名称	
	        pmTabPrtPprRsltWork.AddresseeName2 = custPrtPprSalTblRsltWork.AddresseeName2;	//納品先名称2	
	        pmTabPrtPprRsltWork.FrameNo = custPrtPprSalTblRsltWork.FrameNo;	//車台番号	
	        pmTabPrtPprRsltWork.AcptAnOdrRemainCnt = custPrtPprSalTblRsltWork.AcptAnOdrRemainCnt;	//受注残数	
	        pmTabPrtPprRsltWork.EnterpriseGanreCode = custPrtPprSalTblRsltWork.EnterpriseGanreCode;	//自社分類コード	
	        pmTabPrtPprRsltWork.FeeDeposit = custPrtPprSalTblRsltWork.FeeDeposit;	//手数料入金額	
	        pmTabPrtPprRsltWork.DiscountDeposit = custPrtPprSalTblRsltWork.DiscountDeposit;	//値引入金額	
	        pmTabPrtPprRsltWork.InputDay = Convert.ToInt32(custPrtPprSalTblRsltWork.InputDay.ToString(("yyyyMMdd")));	//入力日	
	        pmTabPrtPprRsltWork.GoodsKindCode = custPrtPprSalTblRsltWork.GoodsKindCode;	//商品属性	
	        pmTabPrtPprRsltWork.GoodsLGroup = custPrtPprSalTblRsltWork.GoodsLGroup;	//商品大分類コード	
	        pmTabPrtPprRsltWork.GoodsMGroup = custPrtPprSalTblRsltWork.GoodsMGroup;	//商品中分類コード	
	        pmTabPrtPprRsltWork.WarehouseShelfNo = custPrtPprSalTblRsltWork.WarehouseShelfNo;	//倉庫棚番	
	        pmTabPrtPprRsltWork.SalesSlipCdDtl = custPrtPprSalTblRsltWork.SalesSlipCdDtl;	//売上伝票区分（明細）	
	        pmTabPrtPprRsltWork.GoodsLGroupName = custPrtPprSalTblRsltWork.GoodsLGroupName;	//商品大分類名称	
	        pmTabPrtPprRsltWork.GoodsMGroupName = custPrtPprSalTblRsltWork.GoodsMGroupName;	//商品中分類名称	
	        pmTabPrtPprRsltWork.CarMngNo = custPrtPprSalTblRsltWork.CarMngNo;	//車両管理番号	
	        pmTabPrtPprRsltWork.MakerCode = custPrtPprSalTblRsltWork.MakerCode;	//メーカーコード	
	        pmTabPrtPprRsltWork.ModelCode = custPrtPprSalTblRsltWork.ModelCode;	//車種コード	
	        pmTabPrtPprRsltWork.ModelSubCode = custPrtPprSalTblRsltWork.ModelSubCode;	//車種サブコード	
	        pmTabPrtPprRsltWork.EngineModelNm = custPrtPprSalTblRsltWork.EngineModelNm;	//エンジン型式名称	
	        pmTabPrtPprRsltWork.ColorCode = custPrtPprSalTblRsltWork.ColorCode;	//カラーコード	
	        pmTabPrtPprRsltWork.TrimCode = custPrtPprSalTblRsltWork.TrimCode;	//トリムコード	
	        pmTabPrtPprRsltWork.DeliveredGoodsDiv = custPrtPprSalTblRsltWork.DeliveredGoodsDiv;	//納品区分	
	        pmTabPrtPprRsltWork.SalesInputCode = custPrtPprSalTblRsltWork.SalesInputCode;	//売上入力者コード	
	        pmTabPrtPprRsltWork.FrontEmployeeCd = custPrtPprSalTblRsltWork.FrontEmployeeCd;	//受付従業員コード	
	        pmTabPrtPprRsltWork.HistoryDiv = custPrtPprSalTblRsltWork.HistoryDiv;	//履歴区分	
	        pmTabPrtPprRsltWork.Mileage = custPrtPprSalTblRsltWork.Mileage;	//車両走行距離	
	        pmTabPrtPprRsltWork.CarNote = custPrtPprSalTblRsltWork.CarNote;	//車輌備考	
	        pmTabPrtPprRsltWork.RetUpperCnt = custPrtPprSalTblRsltWork.Retuppercnt;	//返品上限数	
	        pmTabPrtPprRsltWork.RetupperCntDiv = custPrtPprSalTblRsltWork.RetuppercntDiv;	//返品上限数存在フラグ	
	        pmTabPrtPprRsltWork.HisDtlSlipNum = custPrtPprSalTblRsltWork.HisDtlSlipNum;	//売上伝票番号(履歴)	
	        pmTabPrtPprRsltWork.AcptAnOdrStatusSrc = custPrtPprSalTblRsltWork.AcptAnOdrStatusSrc;	//受注ステータス（元）	
	        pmTabPrtPprRsltWork.AutoAnswerDivSCM = custPrtPprSalTblRsltWork.AutoAnswerDivSCM;	//自動回答区分(SCM)	
            pmTabPrtPprRsltWork.InquiryNumber = custPrtPprSalTblRsltWork.InquiryNumber;	//問合せ番号	

            // --------------- DEL START 2013/07/11 licb  Redmine#38220 FOR 不必要なログ出力の削除----->>>>
           //// --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
           // EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
           //// --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
            // --------------- DEL END 2013/07/11 licb  Redmine#38220 FOR 不必要なログ出力の削除------<<<<
            return pmTabPrtPprRsltWork;
        }
     
        #endregion クラスメンバコピー処理

        /// <summary>
        /// 抽出条件をセット
        /// </summary>
        /// <param name="custPrtPprWork">抽出条件</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件をセット。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/18</br>
        /// <br>Update Note: Redmine#37231 FOR タブレットログ対応</br>
        /// <br>管理番号   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/25</br>
        /// </remarks>
        private void SetSearchCondition(ref CustPrtPprWork custPrtPprWork, string enterpriseCode, string sectionCode)
        {
           // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
            const string methodName = "SetSearchCondition";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
           // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
            custPrtPprWork.EnterpriseCode = enterpriseCode;
            custPrtPprWork.SectionCode = new string[] { sectionCode };
            custPrtPprWork.SalesOrderDivCd = -1;
            custPrtPprWork.SearchCnt = 20001;
            custPrtPprWork.WarehouseCode = string.Empty;
            custPrtPprWork.SupplierSlipNo = string.Empty;
            custPrtPprWork.GoodsKindCode = -1;
            custPrtPprWork.FrameNo = string.Empty;
　          custPrtPprWork.GoodsKindCode = -1;
          // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------>>>>
           EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
          // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR タブレットログ対応------<<<<
        }
               
        #endregion ■ Private Methods
    }
}
