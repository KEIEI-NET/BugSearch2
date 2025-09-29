//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCCUOEリモート伝票発行アクセスクラス
// プログラム概要   : PCCUOEリモート伝票発行を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10702938-02 作成担当 : zhouzy
// 作 成 日  K2011/08/11 作成内容 : PCCUOEリモート伝票発行
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/13  修正内容 : リモート伝票発行、ＳＦ側に渡す条件の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/14  修正内容 : リモート伝票発行、ActiveReportバージョン交換性問題の対応
//                                  SF側はActiveReport2.0→ActiveReport3.0
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : wangqx
// 作 成 日  2011/09/28  修正内容 : Readmine#25623対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : x_chenjm
// 作 成 日  2011/10/12  修正内容 : Readmine#25623対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2012/06/22  修正内容 : RC-SCM対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhubj
// 作 成 日  2013/06/17  修正内容 : Redmine #36594対応 №10542 SCM
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhubj
// 作 成 日  2013/07/28  修正内容 : Redmine #36594対応 №10542 SCM NO.10の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhubj
// 作 成 日  2013/07/30  修正内容 : Redmine #36594対応 №10542 SCM NO.12、NO.13の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上
// 作 成 日  2013/09/19  修正内容 : Redmine #40342対応 リモート伝票発行時エラー対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/09/20  修正内容 : ランテルUOE送信処理 速度遅延対応
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 30973 鹿庭
// 作 成 日  2014/12/25  修正内容 : 九州SSKリモート伝票対応 リモート伝票印刷済区分(ＰＭ納品書)初期値設定
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 宮本 利明
// 作 成 日  2015/11/20  修正内容 : リモ伝障害対応
//                                  ①SCM-DB更新処理にリトライ制御を追加
//                                  ②エラー・例外時の通知、処理経過のログ出力を追加
//----------------------------------------------------------------------------//

//extern alias SFCMN02501alias; // 2012/06/22// DEL 2013/07/28 zhubj FOR Redmine #36594
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Web.Services;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;//zhouzy add 2011.09.13
using Broadleaf.Library.Globarization;//zhouzy add 2011.09.13
// --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
using System.Windows.Forms;
using Broadleaf.Application.Controller.Util;
// --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PCCUOEリモート伝票発行アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: PCCUOEリモート伝票発行を行う</br>
    /// <br>Programmer : zhouzy</br>
    /// <br>Date       : K2011/08/11</br>
    /// <br>管理番号   : 10702938-02 SCM改良(PCC-UOE・リモート伝発)</br>
    /// <br>Update Note: 2013/07/28  zhubj</br>
    /// <br>           : Redmine #36594</br>
    /// <br>           : №10542 SCM NO.10の対応</br>
    /// <br>Update Note: 2013/07/30 zhubj</br>
    /// <br>           : Redmine #36594</br>
    /// <br>           : №10542 SCM NO.12、NO.13対応</br>
    /// </remarks>
    public class ScmRtPrtDtAcs
    {
        #region Private Member
        /// <summary>
        /// 認証コード
        /// </summary> 
        private const string ctAuthenticateCode_SFCMN02555A = "e44f2f5a-7e2c-4368-86b0-ab355887c926";
        /// <summary>
        /// 認証コード
        /// </summary> 
        private const string ctAuthenticateCode_SFCMN02501A = "00cd03ea-b30f-409e-a3df-0abd531648f3";
        /// <summary>
        /// リモート伝発設定マスタ取得用
        /// </summary>
        private IRmSlpPrtStDB _iRmSlpPrtStDB;
        /// <summary>
        /// SCMリモート伝票印刷データ取得用
        /// </summary>
        //private IScmRtPrtDtDB _iScmRtPrtDtDB;
        /// <summary>
        /// SCM受発注 サービス リモートオブジェクト
        /// </summary>
        private IScmOdrDataDB _iScmOdrDataDB;// ADD 2013/07/28 zhubj FOR Redmine #36594
        /// <summary>
        /// リモート伝票用リモートオブジェクト
        /// </summary>
        private IScmRtPrtDtDB _iScmRtPrtDtDB;// ADD 2013/07/28 zhubj FOR Redmine #36594
        /// <summary>
        /// 売上番号リスト
        /// </summary>
        // UPD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
        //private static List<string> _slipNumlist = null;
        private List<string> _slipNumlist;
        // UPD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
        /// <summary>
        /// 問い合わせ番号リスト
        /// </summary>
        // UPD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
        //private static List<string> _inquiryNumList = null;// ADD 2013/07/30 zhubj FOR Redmine #36594
        private List<string> _inquiryNumList;
        // UPD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
        // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
        ScmRtPrtDtSrchRstWork _scmRtPrtDtInfo = null;  　// 印刷情報
        private int _CMTCooprtDiv;　                   　// SCM受注データ・CMT連携区分
        private const int ctCMTCooprtDiv_AutoInq = 11;   // SCM受注データ・CMT連携区分の規定値(11:問合せ自動回答)
        private const int ctCMTCooprtDiv_AutoOrder = 12; // SCM受注データ・CMT連携区分の規定値(12:発注自動回答)
        // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<
        #endregion

        #region プロパティ
        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private List<List<object>> _printDataList = new List<List<object>>();
        /// <summary>
        /// 複数伝票分のデータリスト
        /// index0:伝票番号　index1:更新日(UpdateDate)　index2:更新時間(UpdateTime)
        /// </summary>
        public List<List<object>> PrintDataList
        {
            get { return _printDataList; }
            set { _printDataList = value; }
        }
        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //// --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
        // 設定情報
        private SCMSendSettingInformation _settingInfo = null;

        /// <summary>設定情報を取得または設定します。</summary>
        public SCMSendSettingInformation SettingInformation
        {
            get { return _settingInfo; }
            set { _settingInfo = value; }
        }
        //// --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<
        #endregion

        #region public method

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ScmRtPrtDtAcs()
        {
            _iRmSlpPrtStDB = MediationRmSlpPrtStDB.GetRmSlpPrtStDB();
            _iScmOdrDataDB = (IScmOdrDataDB)MediationGetScmOdrDataDB.GetScmOdrDataDB();// ADD 2013/07/28 zhubj FOR Redmine #36594
            _iScmRtPrtDtDB = (IScmRtPrtDtDB)MediationGetScmRtPrtDtDB.GetScmRtPrtDtDB();// ADD 2013/07/28 zhubj FOR Redmine #36594
        }

        // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
        /// <summary>
        /// SCMリモート伝票印刷データを登録する
        /// </summary>
        /// <param name="prtObj">印刷オブジェクト</param>
        /// <param name="printData">印刷データ</param>
        /// <param name="rmSlpPrtStWork">リモート伝票印刷データ</param>
        /// <param name="isOnlyOneSlip">売上伝票数量は１件フラグ（false:１件以上、true:１件）</param>
        /// <param name="isLastSlip">最後送信の売上伝票フラグ（false:最後ではない、true:最後）</param>
        /// <param name="isKeyChangeFlag">リモート伝票最新識別区分KEY変更フラグ（false:変更しない、true:変更する）</param>// ADD 2013/07/28 zhubj FOR Redmine #36594
        /// <param name="errMsg">エラー</param>
        /// <returns>ステータス</returns>
        //public int WriteScmRtPrtDt(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, bool isOnlyOneSlip, bool isLastSlip, out string errMsg)//DEL 2013/07/28 zhubj FOR Redmine #36594
        // UPD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
        //public int WriteScmRtPrtDt(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, bool isOnlyOneSlip, bool isLastSlip, bool isKeyChangeFlag, out string errMsg)//ADD 2013/07/28 zhubj FOR Redmine #36594
        public int WriteScmRtPrtDt(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, bool isOnlyOneSlip, bool isLastSlip, bool isKeyChangeFlag, List<string> slipNumlist, List<string> inquiryNumList, out string errMsg)//ADD 2013/07/28 zhubj FOR Redmine #36594
        // UPD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //// 情報取得　通知に必要な情報もあるので、今回の伝票が送信対象じゃなくても実施する
            ScmRtPrtDtSrchRstWork scmRtPrtDtWorkResult = null;
            status = getScmRtPrtDtWorkResult(prtObj, printData, rmSlpPrtStWork, out scmRtPrtDtWorkResult, out errMsg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
            try
            {
            // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<

            errMsg = string.Empty;
            // 送信処理未実施の場合はリモ伝出力処理を実施しないで、通知だけ返す 問合せ番号が採番されていれば、送信処理実施済みとする
            bool send = false;
            if (printData != null && printData.Count > 0 && printData[0] != null && printData[0].Count > 1)
            {
                send = (printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>)[0].SALESDETAILRF_INQUIRYNUMBERRF > 0;
            }
            if (send)
            {
            // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // DEL 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // ScmRtPrtDtSrchRstWork scmRtPrtDtWorkResult = null;
                // status = getScmRtPrtDtWorkResult(prtObj, printData, rmSlpPrtStWork, out scmRtPrtDtWorkResult, out errMsg);
                // DEL 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                if (status == 0)
                {
                    // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
                    // 該当リモート伝票はＤＢで存在する場合、第一番リモートデータのKEYより、最新識別区分更新処理を行い
                    // 第一番リモートデータのKEY以外のデータは、最新識別区分更新処理を行わない
                    if (isKeyChangeFlag)
                    {
                        ScmRtPrtDtParamWork scmRtPrtDtParam = new ScmRtPrtDtParamWork();
                        //問合せ元企業コード
                        scmRtPrtDtParam.InqOriginalEpCd = scmRtPrtDtWorkResult.InqOriginalEpCd.Trim();//@@@@20230303
                        //問合せ元拠点コード
                        scmRtPrtDtParam.InqOriginalSecCd = scmRtPrtDtWorkResult.InqOriginalSecCd;
                        //問合せ先企業コード
                        scmRtPrtDtParam.InqOtherEpCd = scmRtPrtDtWorkResult.InqOtherEpCd;
                        //問合せ先拠点コード
                        scmRtPrtDtParam.InqOtherSecCd = scmRtPrtDtWorkResult.InqOtherSecCd;
                        //問合せ番号 
                        scmRtPrtDtParam.InquiryNumber = scmRtPrtDtWorkResult.InquiryNumber;
                        //データ入力システム:[10：PM]
                        scmRtPrtDtParam.DataInputSystem = 10;
                        //売上伝票番号
                        scmRtPrtDtParam.SalesSlipNum = scmRtPrtDtWorkResult.SalesSlipNum;
                        //最新識別区分
                        scmRtPrtDtParam.LatestDiscCode = 0;
                        IScmRtPrtDtDB iScmRtPrtDtDB = (IScmRtPrtDtDB)MediationGetScmRtPrtDtDB.GetScmRtPrtDtDB();
                        ScmRtPrtDtSrchRstWork[] scmRtPrtDtSrchRstWorkArray;
                        ScmOdDtCarWork scmOdDtCarWork;
                        //SCMリモート伝票印刷データを登録する
                        bool msgDiv;
                        status = iScmRtPrtDtDB.ReadScmRtPrtDt(ctAuthenticateCode_SFCMN02555A, scmRtPrtDtParam, out scmRtPrtDtSrchRstWorkArray, out scmOdDtCarWork, out msgDiv, out errMsg);
                        if (status == 0)
                        {
                            scmRtPrtDtWorkResult.UpdateLatestDiscDivCd = 0;
                        }
                        else
                        {
                            scmRtPrtDtWorkResult.UpdateLatestDiscDivCd = 1;
                        }
                    }
                    else
                    {
                        scmRtPrtDtWorkResult.UpdateLatestDiscDivCd = 1;
                    }

                    // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
                    //SCMリモート伝票印刷データを登録する
                     status = WriteRmSlpPrtSt(ref scmRtPrtDtWorkResult, out errMsg, printData);
                    // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        if (scmRtPrtDtWorkResult != null)
                        {
                            if (PrintDataList == null)
                            {
                                PrintDataList = new List<List<object>>();
                            }
                            List<object> wk = new List<object>();
                            wk.Add(scmRtPrtDtWorkResult.SalesSlipNum);
                            wk.Add(scmRtPrtDtWorkResult.UpdateDate);
                            wk.Add(scmRtPrtDtWorkResult.UpdateTime);
                            PrintDataList.Add(wk);
                        }
                    }
                    // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // １件売上番号場合
            if (isOnlyOneSlip)
            {
                //Websyncを利用して、整備側に通知します
                // UPD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // if (status == 0)
                if (status == 0 && send)
                // UPD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    int updateTime = TDateTime.DateTimeToLongDate("HHMMSS", scmRtPrtDtWorkResult.UpdateDate) * 1000 + scmRtPrtDtWorkResult.UpdateDate.Millisecond;
                    SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd.Trim(), scmRtPrtDtWorkResult.InqOriginalSecCd,//@@@@20230303
                        scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, (int)SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmRtPrtDtWorkResult.UpdateDate),
                        updateTime, scmRtPrtDtWorkResult.SlipPrtKind, scmRtPrtDtWorkResult.SalesSlipNum);
                }
            }
            else
            {
                if (status == 0)
                {
                    // 最後売上場合、整備側に通知します
                    if (isLastSlip)
                    {
                        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // 送信対象が1件も無ければ通知しない
                        bool send2 = false;
                        int sendCnt = 0;
                        string sendSalesSlipNum = string.Empty;
                        foreach (string wk in inquiryNumList)
                        {
                            if(!string.IsNullOrEmpty(wk.Trim().Replace("0",string.Empty)))
                            {
                                send2 = true;
                                break;
                            }
                        }

                        if (send2)
                        {
                        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                            // ADD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
                            _slipNumlist = new List<string>();
                            _inquiryNumList = new List<string>();
                            _slipNumlist = slipNumlist;
                            _inquiryNumList = inquiryNumList;
                            // ADD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<

                            string salesSlipNums = "";
                            // DEL 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
                            //_slipNumlist.Add(scmRtPrtDtWorkResult.SalesSlipNum);
                            //_inquiryNumList.Add(scmRtPrtDtWorkResult.InquiryNumber.ToString());//ADD 2013/07/30 zhubj FOR Redmine#36594
                            // DEL 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
                            if (_slipNumlist != null)
                            {
                                int index = 0;
                                #region DEL 2013/07/30 zhubj FOR Redmine#36594
                                //// 売上番号は通知内容へ追加
                                //_slipNumlist.ForEach(delegate(string slipNum)
                                //{
                                //    if (index == 0) salesSlipNums = slipNum;
                                //    else salesSlipNums += "_" + slipNum;
                                //    index++;
                                //});
                                //// 問い合わせ番号は通知内容へ追加
                                //salesSlipNums += "_" + scmRtPrtDtWorkResult.InquiryNumber;
                                #endregion
                                // --------------- ADD START 2013/07/30 zhubj FOR Redmine#36594-------->>>>
                                // 売上番号、問い合わせ番号は通知内容へ追加
                                for (int indexNm = 0; indexNm < _slipNumlist.Count; indexNm++)
                                {
                                    // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                    // 送信対象外は省く
                                    if (string.IsNullOrEmpty(_inquiryNumList[indexNm].Trim().Replace("0", string.Empty)))
                                    {
                                        continue;
                                    }
                                    sendCnt++;
                                    sendSalesSlipNum = _slipNumlist[indexNm];
                                    // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                                    // UPD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                    // if (indexNm == 0) salesSlipNums = _slipNumlist[indexNm] + "_" + _inquiryNumList[indexNm];
                                    // else salesSlipNums += "_" + _slipNumlist[indexNm] + "_" + _inquiryNumList[indexNm];
                                    if (salesSlipNums.Trim() == string.Empty)
                                    {
                                        salesSlipNums = _slipNumlist[indexNm] + "_" + _inquiryNumList[indexNm];
                                    }
                                    else
                                    {
                                        salesSlipNums += "_" + _slipNumlist[indexNm] + "_" + _inquiryNumList[indexNm];
                                    }
                                    // UPD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                                // --------------- ADD END 2013/07/30 zhubj FOR Redmine#36594--------<<<<
                            }

                            // UPD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            // 整備側に通知します
                            //SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd, scmRtPrtDtWorkResult.InqOriginalSecCd,
                            //    scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, 0,
                            //    0, scmRtPrtDtWorkResult.SlipPrtKind, salesSlipNums);
                            if (sendCnt == 1)
                            {
                                // １件の場合

                                // 送信対象をPrintDataListから探す
                                ScmRtPrtDtSrchRstWork wkScmRtPrtDtWorkResult = new ScmRtPrtDtSrchRstWork();
                                if (scmRtPrtDtWorkResult.SalesSlipNum == sendSalesSlipNum)
                                {
                                    // 今回伝票が送信対象の場合
                                    wkScmRtPrtDtWorkResult = scmRtPrtDtWorkResult;
                                }
                                else
                                {
                                    //問合せ元企業コード
                                    wkScmRtPrtDtWorkResult.InqOriginalEpCd = scmRtPrtDtWorkResult.InqOriginalEpCd.Trim();//@@@@20230303
                                    //問合せ元拠点コード
                                    wkScmRtPrtDtWorkResult.InqOriginalSecCd = scmRtPrtDtWorkResult.InqOriginalSecCd;
                                    //問合せ先企業コード
                                    wkScmRtPrtDtWorkResult.InqOtherEpCd = LoginInfoAcquisition.EnterpriseCode;
                                    //問合せ先拠点コード
                                    wkScmRtPrtDtWorkResult.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                                    //伝票番号
                                    wkScmRtPrtDtWorkResult.SalesSlipNum = sendSalesSlipNum;
                                    //伝票印刷種別
                                    wkScmRtPrtDtWorkResult.SlipPrtKind = 30;

                                    foreach (List<object> wk in PrintDataList)
                                    {
                                        if ((string)wk[0] == sendSalesSlipNum)
                                        {
                                            //更新年月日
                                            wkScmRtPrtDtWorkResult.UpdateDate = (DateTime)wk[1];
                                            //更新時間
                                            wkScmRtPrtDtWorkResult.UpdateTime = (int)wk[2];
                                            break;
                                        }
                                    }
                                }

                                SCMChecker.NotifyOtherSidePCCUOERslip(wkScmRtPrtDtWorkResult.InqOriginalEpCd.Trim(), wkScmRtPrtDtWorkResult.InqOriginalSecCd,//@@@@20230303
                                    wkScmRtPrtDtWorkResult.InqOtherEpCd, wkScmRtPrtDtWorkResult.InqOtherSecCd, (int)SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkScmRtPrtDtWorkResult.UpdateDate),
                                    wkScmRtPrtDtWorkResult.UpdateTime, wkScmRtPrtDtWorkResult.SlipPrtKind, wkScmRtPrtDtWorkResult.SalesSlipNum);
                            }
                            else
                            {
                                // 複数伝票の場合
                                SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd.Trim(), scmRtPrtDtWorkResult.InqOriginalSecCd,//@@@@20230303
                                    scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, 0,
                                    0, scmRtPrtDtWorkResult.SlipPrtKind, salesSlipNums);
                            }
                            // UPD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        }
                        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        // DEL 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
                        //// 整備側に通知した。メモリをクリア
                        //_slipNumlist = null;
                        //_inquiryNumList = null;//ADD 2013/07/30 zhubj FOR Redmine#36594
                        // DEL 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
                    }
                    // DEL 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
                    //else
                    //{
                        //// 最後売上明細以外場合、メモリへ保存する
                        //if (_slipNumlist == null) _slipNumlist = new List<string>();
                        //_slipNumlist.Add(scmRtPrtDtWorkResult.SalesSlipNum);
                        //if (_inquiryNumList == null) _inquiryNumList = new List<string>();//ADD 2013/07/30 zhubj FOR Redmine#36594
                        //_inquiryNumList.Add(scmRtPrtDtWorkResult.InquiryNumber.ToString());//ADD 2013/07/30 zhubj FOR Redmine#36594
                    //}
                    // DEL 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
                }
            }
            // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
            }
            catch (Exception ex)
            {
                this.WriteOperationLog("PMKHN02102A", "WriteScmRtPrtDt", "リモート伝票印刷データ登録エラー：例外【" + ex.Message + "】");
                
                errMsg = "リモート伝票印刷データ登録中に例外が発生しました。" + Environment.NewLine
                       + ex.Message + Environment.NewLine + Environment.NewLine
                       + "得意先にリモート伝票が発行されていない可能性があります。" + Environment.NewLine 
                       + "担当サポートへ連絡をお願い致します。";
                this.errMessageBoxShow(errMsg);
            }
            // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<

            return status;
        }
        // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<

        /// <summary>
        /// SCMリモート伝票印刷データを登録する
        /// </summary>
        /// <param name="prtObj">印刷オブジェクト</param>
        /// <param name="printData">印刷データ</param>
        /// <param name="rmSlpPrtStWork">リモート伝票印刷データ</param>
        /// <returns>ステータス</returns>
        public int WriteScmRtPrtDt(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ScmRtPrtDtSrchRstWork scmRtPrtDtWorkResult = null;
            status = getScmRtPrtDtWorkResult(prtObj, printData, rmSlpPrtStWork, out scmRtPrtDtWorkResult, out errMsg);
            if (status == 0)
            {
                // update by wangqx 20110928  begin
                //SCMリモート伝票印刷データを登録する
                //status = WriteRmSlpPrtSt(ref scmRtPrtDtWorkResult, out errMsg);
                status = WriteRmSlpPrtSt(ref scmRtPrtDtWorkResult, out errMsg, printData);
                // update by wangqx 20110928  end
            }

            //Websyncを利用して、整備側に通知します
            //zhouzy update 2011.09.13 begin
            //SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd, scmRtPrtDtWorkResult.InqOriginalSecCd,
            //    scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, scmRtPrtDtWorkResult.InquiryNumber);
            if (status == 0)
            {
                int updateTime = TDateTime.DateTimeToLongDate("HHMMSS", scmRtPrtDtWorkResult.UpdateDate) * 1000 + scmRtPrtDtWorkResult.UpdateDate.Millisecond;
                SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd.Trim(), scmRtPrtDtWorkResult.InqOriginalSecCd,//@@@@20230303
                    scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, (int)SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmRtPrtDtWorkResult.UpdateDate),
                    updateTime, scmRtPrtDtWorkResult.SlipPrtKind, scmRtPrtDtWorkResult.SalesSlipNum);
            }
            //zhouzy update 2011.09.13 end

            return status;
        }
        #endregion

        #region private method
        /// <summary>
        /// SCMリモート伝票印刷データを作成する
        /// </summary>
        /// <param name="prtObj">印刷オブジェクト</param>
        /// <param name="printData">印刷データ</param>
        /// <param name="rmSlpPrtStWork">リモート伝票印刷データ</param>
        /// <returns>リモート伝票印刷データ</returns>
        private int getScmRtPrtDtWorkResult(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, out ScmRtPrtDtSrchRstWork scmRtPrtDtWorkResult, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            scmRtPrtDtWorkResult = new ScmRtPrtDtSrchRstWork();
            errMsg = null;

            //リモート伝票印刷データ
            MemoryStream ms = new MemoryStream();
            try
            {
                //zhouzy update 2011.09.14 begin
                //((ISlipPrintProc)prtObj).PrintDocument.Save(ms, DataDynamics.ActiveReports.Document.RdfFormat.AR20);
                ((ISlipPrintProc)prtObj).PrintDocument.Save(ms);
                //zhouzy update 2011.09.14 end
                ms.Position = 0;
                //印刷データを保存する
                scmRtPrtDtWorkResult.RmtPrintData = ms.ToArray();

                //印刷データ
                List<ArrayList> printDataWk = printData;

                // 売上伝票の場合
                FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
                List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printDataWk[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;

                // 得意先ガイド初期化
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                Broadleaf.Application.UIData.CustomerInfo customerInfo;
                customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, true, out customerInfo);
                //問合せ元企業コード
                scmRtPrtDtWorkResult.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                //問合せ元拠点コード
                scmRtPrtDtWorkResult.InqOriginalSecCd = customerInfo.CustomerSecCode;
                //問合せ先企業コード
                scmRtPrtDtWorkResult.InqOtherEpCd = LoginInfoAcquisition.EnterpriseCode;
                //問合せ先拠点コード
                scmRtPrtDtWorkResult.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                //問合せ番号 
                scmRtPrtDtWorkResult.InquiryNumber = frePSalesDetailWorkList[0].SALESDETAILRF_INQUIRYNUMBERRF;
                //更新年月日
                scmRtPrtDtWorkResult.UpdateDate = new DateTime(slipWork.SALESSLIPRF_UPDATEDATETIMERF);
                //データ入力システム:[10：PM]
                scmRtPrtDtWorkResult.DataInputSystem = 10;
                //伝票印刷種別
                scmRtPrtDtWorkResult.SlipPrtKind = 30;
                //伝票印刷設定用帳票ID
                scmRtPrtDtWorkResult.SlipPrtSetPaperId = rmSlpPrtStWork.SlipPrtSetPaperId;
                //売上伝票番号
                scmRtPrtDtWorkResult.SalesSlipNum = slipWork.SALESSLIPRF_SALESSLIPNUMRF;
                //送信担当者コード
                scmRtPrtDtWorkResult.SendEmployeeCd = LoginInfoAcquisition.Employee.EmployeeCode;
                //送信担当者名称
                scmRtPrtDtWorkResult.SenEmployeeNm = LoginInfoAcquisition.Employee.Name;
                //赤黒返品伝票区分
                scmRtPrtDtWorkResult.RdBlkRetSlpDivCd = getRdBlkRetSlpDivCd(printDataWk);
                // ADD 2014/12/25 鹿庭 九州SSKリモート伝票対応 ---------------------------------------------->>>>>
                scmRtPrtDtWorkResult.PrtFinishDivCd = 1; // リモート伝票印刷済区分(ＰＭ納品書) 1:未印刷を設定
                // ADD 2014/12/25 鹿庭 九州SSKリモート伝票対応 ----------------------------------------------<<<<<
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
            finally
            {
                _CMTCooprtDiv = -1; // CMT連携区分
                _scmRtPrtDtInfo = scmRtPrtDtWorkResult; // 印刷情報の待避
            }
            // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<
            return status;
        }

        /// <summary>
        /// SCMリモート伝票印刷データを登録する
        /// </summary>
        /// <param name="scmRtPrtDtWork">リモート伝票印刷データ</param>
        /// <returns>ステータス</returns>
        // update by wangqx 20110928  begin
        //private int WriteRmSlpPrtSt(ref ScmRtPrtDtSrchRstWork scmRtPrtDtWork, out string errMsg)
        private int WriteRmSlpPrtSt(ref ScmRtPrtDtSrchRstWork scmRtPrtDtWork, out string errMsg, List<ArrayList> printData)
        // update by wangqx 20110928 end
        {
            SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "リモート伝票印刷データ登録処理"); // ADD 2015/11/20 T.Miyamoto リモ伝障害対応
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            #region　SCM企業連結情報を取得する
            int i = 0;
            ScmEpCnectWork[] scmEpCnectWorks = null;
            ScmEpScCntWork[] scmEpScCntWorks = null;
            ScmEpCnectWork aimScmEpCnectWork = null;
            ScmEpScCntWork aimScmEpScCntWork = null;
            bool msgDiv;
            try
            {
                SFCMN02564AServices sfcmn02564aservices = GetSFCMN02564AServices();

                //問合せ元の企業コードは存在する場合
                if (!string.IsNullOrEmpty(scmRtPrtDtWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                {
                    SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "SCM連結設定情報を取得中…"); // ADD 2015/11/20 T.Miyamoto リモ伝障害対応
                    //SCM連結設定情報を取得する
                    sfcmn02564aservices.SearchAll(scmRtPrtDtWork.InqOriginalEpCd.Trim(), scmRtPrtDtWork.InqOriginalSecCd, 0,//@@@@20230303
                        out  scmEpCnectWorks, out scmEpScCntWorks, out msgDiv, out errMsg);
                    //SCM企業連結データを探す
                    if (null != scmEpCnectWorks && scmEpCnectWorks.Length > 0)
                    {
                        for (i = 0; i < scmEpCnectWorks.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(scmEpCnectWorks[i].CnectOtherEpCd)
                                && !string.IsNullOrEmpty(scmRtPrtDtWork.InqOtherEpCd)
                                && scmEpCnectWorks[i].CnectOtherEpCd.Trim().Equals(scmRtPrtDtWork.InqOtherEpCd.Trim()))
                            {
                                aimScmEpCnectWork = scmEpCnectWorks[i];
                                break;
                            }
                        }
                        if (null != aimScmEpCnectWork)
                        {
                            //契約企業名
                            scmRtPrtDtWork.CntrctntEpName = aimScmEpCnectWork.CnectOtherEpNm;
                            //取引先契約企業名
                            scmRtPrtDtWork.TransCntrctntEpName = aimScmEpCnectWork.CnectOriginalEpNm;
                        }
                    }

                    //SCM企業拠点連結データを探す
                    if (null != scmEpScCntWorks && scmEpScCntWorks.Length > 0)
                    {
                        for (i = 0; i < scmEpScCntWorks.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(scmEpScCntWorks[i].CnectOtherSecCd)
                                && !string.IsNullOrEmpty(scmRtPrtDtWork.InqOtherSecCd)
                                && scmEpScCntWorks[i].CnectOtherEpCd.Trim().Equals(scmRtPrtDtWork.InqOtherEpCd.Trim())
                                && scmEpScCntWorks[i].CnectOtherSecCd.Trim().Equals(scmRtPrtDtWork.InqOtherSecCd.Trim()))
                            {
                                aimScmEpScCntWork = scmEpScCntWorks[i];
                                break;
                            }
                        }
                        if (null != aimScmEpScCntWork)
                        {
                            //契約拠点名
                            scmRtPrtDtWork.SectionName = aimScmEpScCntWork.CnectOtherSecNm;
                            //取引先契約拠点名
                            scmRtPrtDtWork.TransSectionName = aimScmEpScCntWork.CnectOriginalSecNm;
                        }
                    }
                    SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "SCM連結設定情報の取得が完了しました。"); // ADD 2015/11/20 T.Miyamoto リモ伝障害対応
                }

            #endregion

                #region SCMまたはPCCUOEで回答したデータを取得する
                SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "問合せ回答情報を取得中…"); // ADD 2015/11/20 T.Miyamoto リモ伝障害対応
                //>>>2012/06/22
                //SFCMN02501AServices sfcmn02501aservices = GetSFCMN02501AServices();
                //SFCMN02501alias.Broadleaf.Web.Services.SFCMN02501AServices sfcmn02501aservices = GetSFCMN02501AServices();// DEL 2013/07/28 zhubj FOR Redmine #36594
                //<<<2012/06/22

                //>>>2012/06/22
                //ScmOdReadParamWork scmOdReadParamWork = new ScmOdReadParamWork();

                //ScmOdrDataWork[] scmOdrDataWorkArray;
                //ScmOdDtInqWork[] scmOdDtInqWorkArray;
                //ScmOdDtAnsWork[] scmOdDtAnsWorkArray;
                //ScmOdDtCarWork[] scmOdDtCarWorkArray;

                //SFCMN02501alias::ScmOdReadParamWork scmOdReadParamWork = new SFCMN02501alias::ScmOdReadParamWork();// DEL 2013/07/28 zhubj FOR Redmine #36594

                //SFCMN02501alias::ScmOdrDataWork[] scmOdrDataWorkArray = null;// DEL 2013/07/28 zhubj FOR Redmine #36594
                //SFCMN02501alias::ScmOdDtInqWork[] scmOdDtInqWorkArray = null;// DEL 2013/07/28 zhubj FOR Redmine #36594
                //SFCMN02501alias::ScmOdDtAnsWork[] scmOdDtAnsWorkArray = null;// DEL 2013/07/28 zhubj FOR Redmine #36594
                //SFCMN02501alias::ScmOdDtCarWork[] scmOdDtCarWorkArray = null;// DEL 2013/07/28 zhubj FOR Redmine #36594

                ScmOdReadParamWork scmOdReadParamWork = new ScmOdReadParamWork();// ADD 2013/07/28 zhubj FOR Redmine #36594

                ScmOdrDataWork[] scmOdrDataWorkArray = null;// ADD 2013/07/28 zhubj FOR Redmine #36594
                ScmOdDtInqWork[] scmOdDtInqWorkArray = null;// ADD 2013/07/28 zhubj FOR Redmine #36594
                ScmOdDtAnsWork[] scmOdDtAnsWorkArray = null;// ADD 2013/07/28 zhubj FOR Redmine #36594
                ScmOdDtCarWork[] scmOdDtCarWorkArray = null;// ADD 2013/07/28 zhubj FOR Redmine #36594
                //<<<2012/06/22

                scmOdReadParamWork.InqOriginalEpCd = scmRtPrtDtWork.InqOriginalEpCd.Trim();//@@@@20230303
                scmOdReadParamWork.InqOriginalSecCd = scmRtPrtDtWork.InqOriginalSecCd;
                scmOdReadParamWork.InqOtherEpCd = scmRtPrtDtWork.InqOtherEpCd;
                // uodate by x_chenjm 20111012 for 25623 begin
                // update by wangqx 20110928  begin
                scmOdReadParamWork.InqOtherSecCd = scmRtPrtDtWork.InqOtherSecCd;
                ////印刷データ
                //List<ArrayList> printDataWk = printData;
                //// 売上伝票の場合
                //FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
                //scmOdReadParamWork.InqOtherSecCd = slipWork.SALESSLIPRF_RESULTSADDUPSECCDRF;
                // update by wangqx 20110928 end
                // uodate by x_chenjm 20111012 end
                scmOdReadParamWork.InquiryNumber = scmRtPrtDtWork.InquiryNumber;
                // 1:問合せ・発注 2:回答
                scmOdReadParamWork.InqOrdAnsDivCd = 2;
                // 最新識別区分(-1:指定無し 0:最新データ 1:旧データ)
                scmOdReadParamWork.LatestDiscCode = 0;
                //問合せ回答情報を取得する
                //status = sfcmn02501aservices.ReadWithCar(ctAuthenticateCode_SFCMN02501A, scmOdReadParamWork, out scmOdrDataWorkArray, out scmOdDtInqWorkArray, out scmOdDtAnsWorkArray, out scmOdDtCarWorkArray, out msgDiv, out errMsg);// DEL 2013/07/28 zhubj FOR Redmine #36594
                status = _iScmOdrDataDB.ReadWithCar(ctAuthenticateCode_SFCMN02501A, scmOdReadParamWork, out scmOdrDataWorkArray, out scmOdDtInqWorkArray, out scmOdDtAnsWorkArray, out scmOdDtCarWorkArray, out msgDiv, out errMsg);// ADD 2013.07.28 zhubj FOR Redmine #36594
                SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "問合せ回答情報の取得が完了しました。"); // ADD 2015/11/20 T.Miyamoto リモ伝障害対応
                #endregion
                if (status == 0)
                {
                    if (null != scmOdrDataWorkArray && scmOdrDataWorkArray.Length > 0)
                    {
                        //>>>2012/06/22
                        //ScmOdrDataWork scmOdrDataWork = scmOdrDataWorkArray[0];
                        //SFCMN02501alias::ScmOdrDataWork scmOdrDataWork = scmOdrDataWorkArray[0];// DEL 2013/07/28 zhubj FOR Redmine #36594
                        ScmOdrDataWork scmOdrDataWork = scmOdrDataWorkArray[0];// ADD 2013.07.28 zhubj FOR Redmine #36594
                        //<<<2012/06/22
                        //課金発生日
                        scmRtPrtDtWork.BillingAccuralDate = scmOdrDataWork.UpdateDate;
                        //課金発生時間
                        scmRtPrtDtWork.BillingAccuralTime = scmOdrDataWork.UpdateTime;
                        //課金発生月
                        scmRtPrtDtWork.BillingOccurMonth = scmOdrDataWork.UpdateDate.Month;
                        // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
                        //CMT連携区分
                        _CMTCooprtDiv = scmOdrDataWork.CMTCooprtDiv;
                        // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<
                    }
                    ScmRtPrtDtSrchRstWork[] scmRtPrtDtWorks = new ScmRtPrtDtSrchRstWork[1];
                    scmRtPrtDtWorks[0] = scmRtPrtDtWork;
                    // --- UPD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
                    ////SFCMN02555AServices services = GetSFCMN02555AServices();// DEL 2013/07/28 zhubj FOR Redmine #36594
                    ////status = services.Write(ctAuthenticateCode_SFCMN02555A, ref scmRtPrtDtWorks, out msgDiv, out errMsg);// DEL 2013/07/28 zhubj FOR Redmine #36594
                    //status = _iScmRtPrtDtDB.Write(ctAuthenticateCode_SFCMN02555A, ref scmRtPrtDtWorks, out msgDiv, out errMsg);// ADD 2013/07/28 zhubj FOR Redmine #36594
                    //【PMSCM01103A.config】からリトライ回数・待ち時間を取得
                    SCMSendSettingInformation SettingInfo = new SCMSendSettingInformation();
                    SettingInfo.Load();
                    int Limit = SettingInfo.DbRetry;           // リトライ回数
                    int SleepMS = SettingInfo.SleepSec * 1000; // 待ち

                    SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "SCM-DB更新処理(リトライ" + Limit.ToString() + "回、" + SettingInfo.SleepSec.ToString() + "秒待ち)");
                    SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "伝票番号：" + scmRtPrtDtWorks[0].SalesSlipNum + "、問合せ番号：" + scmRtPrtDtWorks[0].InquiryNumber);

                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    int iCnt = 0;
                    for (iCnt = 0; iCnt <= Limit; iCnt++)
                    {
                        if (iCnt > 0)
                        {
                            SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "リトライ" + iCnt.ToString() + "回目 status=" + status.ToString());
                        }

                        status = _iScmRtPrtDtDB.Write(ctAuthenticateCode_SFCMN02555A, ref scmRtPrtDtWorks, out msgDiv, out errMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "SCM-DB更新処理が正常終了しました。");
                            break;
                        }
                        System.Threading.Thread.Sleep(SleepMS);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.WriteOperationLog("PMKHN02102A", "WriteRmSlpPrtSt", "リモート伝票印刷データ登録エラー：売上伝票番号【" + scmRtPrtDtWorks[0].SalesSlipNum + "】ステータス【" + status.ToString() + "】");

                        errMsg = "リモート伝票印刷データ登録中にエラーが発生しました。" + Environment.NewLine
                               + "(SCM-DB更新エラー)" + Environment.NewLine 
                               + "売上伝票番号【" + scmRtPrtDtWorks[0].SalesSlipNum + "】" + Environment.NewLine
                               + "ステータス【" + status.ToString() + "】"+ Environment.NewLine + Environment.NewLine
                               + "得意先にリモート伝票が発行されていない可能性があります。" + Environment.NewLine 
                               + "担当サポートへ連絡をお願い致します。";
                        this.errMessageBoxShow(errMsg);
                    }
                    // --- UPD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<

                    //>>>2012/06/22
                    if (status == 0)
                    {
                        if (scmEpCnectWorks != null && scmEpCnectWorks.Length != 0)
                        {
                            scmRtPrtDtWork = scmRtPrtDtWorks[0];
                        }
                    }
                    //<<<2012/06/22
                }
            }
            catch (Exception ex)
            {
                // --- UPD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
                //errMsg = ex.Message;
                //status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                this.WriteOperationLog("PMKHN02102A", "WriteRmSlpPrtSt", "リモート伝票印刷データ登録エラー：例外【" + ex.Message + "】");

                errMsg = "リモート伝票印刷データ登録中に例外が発生しました。" + Environment.NewLine
                       + ex.Message + Environment.NewLine + Environment.NewLine
                       + "得意先にリモート伝票が発行されていない可能性があります。" + Environment.NewLine 
                       + "担当サポートへ連絡をお願い致します。";
                this.errMessageBoxShow(errMsg);
                // --- UPD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<
            }
            return status;
        }

        /// <summary>
        /// 赤黒返品伝票区分を判断する
        /// 0:黒伝 1:赤伝 2:返品
        /// </summary>
        /// <param name="printDataWk">印刷データワーク</param>
        /// <returns>ステータス</returns>
        private int getRdBlkRetSlpDivCd(List<ArrayList> printDataWk)
        {
            // 売上伝票データワーク
            FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
            // 売上明細データワーク
            FrePSalesDetailWork salesDetailWork = null;
            List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printDataWk[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
            int iResult = -1;
            //売上伝票区分[0:売上]の場合
            if (slipWork.SALESSLIPRF_SALESSLIPCDRF == 0)
            {
                for (int i = 0; i < frePSalesDetailWorkList.Count; i++)
                {
                    salesDetailWork = frePSalesDetailWorkList[i];
                    if (salesDetailWork.SALESDETAILRF_SHIPMENTCNTRF == 0)
                    {
                        //出荷数0以外の場合、次の明細を参照する
                        //黒伝
                        iResult = 0;
                        continue;
                    }
                    else
                    {
                        if (salesDetailWork.SALESDETAILRF_SHIPMENTCNTRF > 0)
                        {
                            //出荷数0以上の場合
                            if (salesDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF != 2)
                            {
                                //売上伝票区分（明細）[2:返品]以外の場合,黒伝
                                iResult = 0;
                                break;
                            }
                            else
                            {
                                //赤伝
                                iResult = 1;
                                break;
                            }
                        }
                        else
                        {
                            //出荷数0以上の場合
                            if (salesDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF != 2)
                            {
                                //売上伝票区分（明細）[2:返品]以外の場合,赤伝
                                iResult = 1;
                                break;
                            }
                            else
                            {
                                //黒伝
                                iResult = 0;
                                break;
                            }
                        }
                    }
                }
                iResult = 0;
            }
            else
            {
                //返品の場合
                iResult = 2;
            }
            return iResult;
        }

        #region DEL 2013/07/28 zhubj FOR Redmine#36594
        ///// <summary>
        ///// リモート伝票データ発行用サービスを取得する
        ///// </summary>
        ///// <returns>リモート伝票データ発行用サービス</returns>
        //private SFCMN02555AServices GetSFCMN02555AServices()
        //{
        //    string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);
        //    string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

        //    SFCMN02555AServices result = new SFCMN02555AServices(wkStr1 + wkStr2 + "SFCMN02555AA.asmx");
        //    //タイムアウト10分
        //    result.Timeout = 600000;

        //    return result;
        //}
        #endregion

        /// <summary>
        /// SCM連結設定情報サービスを取得する
        /// </summary>
        /// <returns>SCM連結設定情報サービス</returns>
        private SFCMN02564AServices GetSFCMN02564AServices()
        {
            string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);
            string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

            SFCMN02564AServices result = new SFCMN02564AServices(wkStr1 + wkStr2 + "SFCMN02564AA.asmx");

            //タイムアウト10分
            result.Timeout = 600000;

            return result;
        }

        #region DEL 2013/07/28 zhubj FOR Redmine#36594
        ///// <summary>
        ///// 問合せ回答情報取得用サービスを取得する
        ///// </summary>
        ///// <returns>問合せ回答情報</returns>
        //>>>2012/06/22
        //private SFCMN02501AServices GetSFCMN02501AServices()
        //private SFCMN02501alias.Broadleaf.Web.Services.SFCMN02501AServices GetSFCMN02501AServices()
        ////<<<2012/06/22
        //{
        //    string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);
        //    string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

        //    //>>>2012/06/22
        //    //SFCMN02501AServices result = new SFCMN02501AServices(wkStr1 + wkStr2 + "SFCMN02501AA.asmx");
        //    SFCMN02501alias.Broadleaf.Web.Services.SFCMN02501AServices result = new SFCMN02501alias.Broadleaf.Web.Services.SFCMN02501AServices(wkStr1 + wkStr2 + "SFCMN02501AA.asmx");
        //    //<<<2012/06/22

        //    //タイムアウト10分
        //    result.Timeout = 600000;

        //    return result;
        //}
        #endregion

        // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------>>>>>
        /// <summary>
        /// オペレーションログを書込みます。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void WriteOperationLog(string className, string methodName, string msg)
        {
            SimpleLogger.Write(className, methodName, msg);

            OperationHistoryLog log = new OperationHistoryLog();
            log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, "PMKHN02102A", "リモート伝票発行アクセスクラス", string.Empty, 0, 0, msg, string.Empty);
            log = null;
        }

        /// <summary>
        /// エラー発生時にメッセージダイアログを表示します
        /// </summary>
        public void errMessageBoxShow(string dspMsg)
        {
            try
            {
                // 自動回答未確認の場合はSCM受注データを取得
                if (_CMTCooprtDiv < 0)
                {
                    bool msgDiv;
                    string errMsg;
                    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

                    ScmOdReadParamWork scmOdReadParamWork = new ScmOdReadParamWork();

                    ScmOdrDataWork[] scmOdrDataWorkArray = null;
                    ScmOdDtInqWork[] scmOdDtInqWorkArray = null;
                    ScmOdDtAnsWork[] scmOdDtAnsWorkArray = null;
                    ScmOdDtCarWork[] scmOdDtCarWorkArray = null;

                    scmOdReadParamWork.InqOriginalEpCd = _scmRtPrtDtInfo.InqOriginalEpCd.Trim();   //問合せ元企業コード//@@@@20230303
                    scmOdReadParamWork.InqOriginalSecCd = _scmRtPrtDtInfo.InqOriginalSecCd; //問合せ元拠点コード
                    scmOdReadParamWork.InqOtherEpCd = _scmRtPrtDtInfo.InqOtherEpCd;         //問合せ先企業コード
                    scmOdReadParamWork.InqOtherSecCd = _scmRtPrtDtInfo.InqOtherSecCd;       //問合せ先拠点コード
                    scmOdReadParamWork.InquiryNumber = _scmRtPrtDtInfo.InquiryNumber;       //問合せ番号
                    scmOdReadParamWork.InqOrdAnsDivCd = 2;                                  //問発・回答種別(1:問合せ・発注 2:回答)
                    scmOdReadParamWork.LatestDiscCode = 0;                                  //最新識別区分(0:最新データ 1:旧データ)
                    //問合せ回答情報を取得する
                    status = _iScmOdrDataDB.ReadWithCar(ctAuthenticateCode_SFCMN02501A, scmOdReadParamWork, out scmOdrDataWorkArray, out scmOdDtInqWorkArray, out scmOdDtAnsWorkArray, out scmOdDtCarWorkArray, out msgDiv, out errMsg);
                    if (status == 0)
                    {
                        if (null != scmOdrDataWorkArray && scmOdrDataWorkArray.Length > 0)
                        {
                            //CMT連携区分
                            _CMTCooprtDiv = scmOdrDataWorkArray[0].CMTCooprtDiv;
                        }
                    }
                }
                if ((_CMTCooprtDiv < 0) || ((_CMTCooprtDiv != ctCMTCooprtDiv_AutoInq) && (_CMTCooprtDiv != ctCMTCooprtDiv_AutoOrder)))
                {
                    // 自動回答以外の場合はエラーメッセージを表示する
                    MessageBox.Show(dspMsg, "リモート伝票発行処理", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                this.WriteOperationLog("PMKHN02102A", "autoAnsCheck", "SCM受注データ取得エラー：例外【" + ex.Message + "】");
            }
        }
        // --- ADD 2015/11/20 T.Miyamoto リモ伝障害対応 ------------------------------<<<<<
        #endregion
    }
}
