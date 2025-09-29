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
// 作 成 日  2009/06/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2009.07.21  修正内容 : 受注明細データ(回答)更新条件変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/03/05  修正内容 : 車輌情報再読込時の条件変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2010/03/08  修正内容 : ＣＭＴの送信メッセージの修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/02/16  修正内容 : 明細取込区分更新メソッドを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2011/02/22  修正内容 : 回答区分のセット仕様を修正。(回答済みor一部回答の判断)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024 佐々木 健
// 作 成 日  2011/03/02  修正内容 : ・ＣＭＴ連携データのみプラグインにメッセージを送る
//                                 ・回答区分のセットの不具合修正（伝票が2伝票以上になると一部回答になる)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2011/05/25  修正内容 : 受発注データ確定済チェック処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : ZHANGYH
// 作 成 日  2011/07/12  修正内容 : 1分問題対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/06  修正内容 : Websync PCCUOEのチャンネルを追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/06/29  修正内容 : 改良No10296
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/08/10  修正内容 : 改良No10296システム障害対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/09/26  修正内容 : SCM障害№10373対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/27  修正内容 : 2013/03/13配信 SCM障害№10378対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/01/28  修正内容 : 2013/03/13配信 SCM障害№10475対応　速度改善
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/03/25  修正内容 : 2013/04/10配信分 SCM障害№10493対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/03/07  修正内容 : 2013/04/10配信 SCM障害№10501対応　
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/07/31  修正内容 : 2013/08/09配信 システムテスト障害一覧№14対応　
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2014/01/06  修正内容 : SCM障害№10618対応　
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2014/04/03  修正内容 : SCM障害№10618対応 追加修正
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/13  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 13.フル型式固定番号からのＢＬコード検索回数改良対応
//                                : 14.明細取込区分の更新方法を改良対応
//                                : 15.SCM受発注データ（車両情報）取得方法改良対応
//                                : 16.純正品検索改良対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上
// 修 正 日  2014/09/09  修正内容 : SCM高速化 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応
//                                : PM-SCM速度改良 フェーズ２ 
//                                : 14.明細取込区分の更新方法を改良対応,15.SCM受発注データ（車両情報）取得方法改良対応のデグレ 
//----------------------------------------------------------------------------//
// 管理番号  11070221-00 作成担当 : 脇田 靖之
// 作 成 日  2014/10/14  修正内容 : SCM障害№10535対応
//                                : PM-SCMセット部品情報表示対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/11/26  修正内容 : SCM仕掛一覧№10707対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/06/30  修正内容 : ②SCM仕掛一覧№10707 ログ出力の追加
//----------------------------------------------------------------------------//

#define _LOCAL_DEBUG_

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Application.UIData.WebDB;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting; // ADD m.suzuki 2011/02/22
using Broadleaf.Application.Remoting.Adapter; // ADD m.suzuki 2011/02/22
using Broadleaf.Application.Common;
using System.Windows;
using Broadleaf.Library.Collections; // ADD m.suzuki 2011/02/22
using Broadleaf.Library.Resources;



namespace Broadleaf.Application.Controller.Agent
{
#if DEBUG
    using WebHeaderRecordType   = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType      = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType   = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType   = Broadleaf.Application.UIData.ScmOdDtAns;
    // -- ADD 2011/08/10   ------ >>>>>>
    using WebSetDtRecordType = Broadleaf.Application.UIData.ScmOdSetDt;
    // -- ADD 2011/08/10   ------ <<<<<<
#else
    using WebHeaderRecordType   = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType      = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType   = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType   = Broadleaf.Application.UIData.ScmOdDtAns;
    // -- ADD 2011/08/10   ------ >>>>>>
    using WebSetDtRecordType    = Broadleaf.Application.UIData.ScmOdSetDt;
    // -- ADD 2011/08/10   ------ <<<<<<
#endif

    using RealAccesserType  = ScmOdrDataAcs2;
    using RecordType        = Broadleaf.Application.UIData.ScmOdrData;
    using System.Threading; // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応

    /// <summary>
    /// SCM Webサーバアクセサの代理人クラス
    /// </summary>
    public class SCMWebAcsAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCMWebAcsAgent";    // ログ用

        // --- ADD m.suzuki 2011/02/22 ---------->>>>>
        private IIOWriteScmDB _ioWriteScmDB;

        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
        // 設定情報
        private SCMSendSettingInformation _settingInfo = null;

        /// <summary>設定情報を取得または設定します。</summary>
        public SCMSendSettingInformation SettingInformation
        {
            get { return _settingInfo; }
            set { _settingInfo = value; }
        }
        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

        /// <summary>
        /// SCM-IOWriter
        /// </summary>
        protected IIOWriteScmDB IOWriteScmDB
        {
            get 
            { 
                if (_ioWriteScmDB == null)
                {
                    _ioWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
                }
                return _ioWriteScmDB;
            }
        }
        // --- ADD m.suzuki 2011/02/22 ----------<<<<<

        #region <ログ>

        /// <summary>ロガー</summary>
        private ILogable _logger;
        /// <summary>ロガーを取得または設定します。</summary>
        public ILogable Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        /// <summary>
        /// ログを書込みます。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        private void WriteLog(string msg)
        {
            if (Logger == null) return;

            Logger.WriteLog(msg);
        }

        #endregion // </ログ>

        #region <書込み結果>

        /// <summary>書込み結果</summary>
        private Triple<IList<ISCMOrderHeaderRecord>, IList<ISCMOrderCarRecord>, IList<ISCMOrderAnswerRecord>> _writedResult;
        /// <summary>書込み結果を取得します。</summary>
        public Triple<IList<ISCMOrderHeaderRecord>, IList<ISCMOrderCarRecord>, IList<ISCMOrderAnswerRecord>> WritedResult
        {
            get
            {
                if (_writedResult == null)
                {
                    _writedResult = new Triple<IList<ISCMOrderHeaderRecord>, IList<ISCMOrderCarRecord>, IList<ISCMOrderAnswerRecord>>();
                    _writedResult.First = new List<ISCMOrderHeaderRecord>();
                    _writedResult.Second = new List<ISCMOrderCarRecord>();
                    _writedResult.Third = new List<ISCMOrderAnswerRecord>();
                }
                return _writedResult;
            }
        }
        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// 書込み結果 SCMセット部品データ
        /// </summary>
        private IList<ISCMAcOdSetDtRecord> _writedResultSetDt;

        /// <summary>
        /// 書込み結果 SCMセット部品データ取得
        /// </summary>
        public IList<ISCMAcOdSetDtRecord> WritedResultSetDt
        {
            get
            {
                if (_writedResultSetDt == null)
                {
                    _writedResultSetDt = new List<ISCMAcOdSetDtRecord>();
                }

                return _writedResultSetDt;
            }
        }
        // -- ADD 2011/08/10   ------ <<<<<<
        #endregion // </書込み結果>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMWebAcsAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// SCM受発注明細データ(回答)を書込みます。
        /// </summary>
        /// <param name="scmIO">SCM I/O</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果コード</returns>
        // 2011.07.12 ZHANGYH EDT STA >>>>>>
        //public int WriteAnswerData(SCMIOAgent scmIO, ref string errMsg)
        // 2011.09.06 zhouzy UPDATE STA >>>>>>
        //public int WriteAnswerData(SCMIOAgent scmIO, ref string errMsg, out List<string> sendEnterpriseCodeList, out List<string> sendSectionCodeList)
        public int WriteAnswerData(SCMIOAgent scmIO, ref string errMsg, out List<string> sendEnterpriseCodeList, out List<string> sendSectionCodeList, out List<SCMAcOdrDataWork> scmAcOdrDataList)
        // 2011.09.06 zhouzy UPDATE END <<<<<<
        // 2011.07.12 ZHANGYH EDT END <<<<<<
        {
            // 2011.07.12 ZHANGYH EDT STA >>>>>>
            sendEnterpriseCodeList = new List<string>();
            sendSectionCodeList = new List<string>();
            Dictionary<string, string> sendEpScDict = new Dictionary<string, string>();
            // 2011.07.12 ZHANGYH EDT END <<<<<<

            const string METHOD_NAME = "WriteAnswerData()"; // ログ用

            errMsg = string.Empty;

            // 回答対象データの取得            
            // 2011.09.06 zhouzy DELETE STA >>>>>>
            //List<SCMAcOdrDataWork> scmAcOdrDataList;
            // 2011.09.06 zhouzy DELETE END <<<<<<
            List<SCMAcOdrDtCarWork> scmAcOdrDtCarWorkList;
            List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsWorkList;
            // -- ADD 2011/08/10   ------ >>>>>>
            List<SCMAcOdSetDtWork> scmAcOdrSetDtWorkList;
            // -- ADD 2011/08/10   ------ <<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, "回答対象データ取得"); // ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707
            //status = this.GetSendTargetList(scmIO, out scmAcOdrDataList, out scmAcOdrDtCarWorkList, out scmAcOdrDtlAsWorkList);                               // DEL 2011/08/12 
            status = this.GetSendTargetList(scmIO, out scmAcOdrDataList, out scmAcOdrDtCarWorkList, out scmAcOdrDtlAsWorkList, out scmAcOdrSetDtWorkList);      // ADD 2011/08/12 
            SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, string.Format("回答対象データ取得：status = [{0}]", status)); // ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707
            if (status != (int)ResultUtil.ResultCode.Normal)
            {
                #region <Log>

                WriteLog("未送信データはありませんでした。");
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg("未送信データはありませんでした。"));

                #endregion // </Log>

                return (int)ResultUtil.ResultCode.Error;
            }

            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 戻り値の保持リスト
            List<SCMAcOdrDataWork> retHeaderList    = new List<SCMAcOdrDataWork>();
            List<SCMAcOdrDtCarWork> retCarList      = new List<SCMAcOdrDtCarWork>();
            List<SCMAcOdrDtlAsWork> retAnswerList   = new List<SCMAcOdrDtlAsWork>();
            // -- ADD 2011/08/10   ------ >>>>>>
            List<SCMAcOdSetDtWork> retSetDtList = new List<SCMAcOdSetDtWork>();
            // -- ADD 2011/08/10   ------ <<<<<<

            // 2010/02/13 Add >>>
            bool first = true;
            // 2010/02/13 Add <<<

            // DEL 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
            #region 削除（仮）
            //>>>2012/06/29
            //#region 処理モード設定
            //// iMode0,1:問合せ番号指定無しの送信(PM起点データの送信)or回答送信処理単体起動
            //// iMode2:問合せ番号ありの送信(SF起点データの送信)
            //int iMode = 0;
            //List<long> InquiryNumberList = new List<long>();
            //if ((scmAcOdrDataList != null) && (scmAcOdrDataList.Count != 0))
            //{
            //    foreach (SCMAcOdrDataWork tempHeader in scmAcOdrDataList)
            //    {
            //        if (tempHeader.InquiryNumber == 0)
            //        {
            //            iMode = 1; // →問合せ番号＝未設定のレコードあり
            //            break;
            //        }
            //        if (!InquiryNumberList.Contains(tempHeader.InquiryNumber))
            //        {
            //            InquiryNumberList.Add(tempHeader.InquiryNumber);
            //        }
            //    }
            //    // →問合せ番号＝未設定のレコード無し　送信対象の問合せ番号が１つ
            //    if ((iMode == 0) && (InquiryNumberList.Count == 1)) iMode = 2;
            //}
            //#endregion
            //<<<2012/06/29
            #endregion
            // DEL 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<

            // ADD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
            #region 送信処理単位振り分け
            List<SCMAcOdrDataWork> InquiryUnitList = new List<SCMAcOdrDataWork>();
            List<SCMAcOdrDataWork> SalesSlipUnitList = new List<SCMAcOdrDataWork>();

            if ((scmAcOdrDataList != null) && (scmAcOdrDataList.Count != 0))
            {
                foreach (SCMAcOdrDataWork tempHeader in scmAcOdrDataList)
                {
                    // 問合せ番号未設定は売上伝票単位（既存処理で送信）
                    if (tempHeader.InquiryNumber == 0)
                    {
                        SalesSlipUnitList.Add(tempHeader);
                    }
                    else
                    // 問合せ番号設定時は問合せ番号単位で送信
                    {
                        int retFind = 0;
                        foreach (SCMAcOdrDataWork tempInquiry in InquiryUnitList)
                        {
                            if (tempInquiry.InquiryNumber == tempHeader.InquiryNumber)
                            {
                                retFind = 1;
                                break;
                            }
                        }
                        if (retFind == 0)
                        {
                            InquiryUnitList.Add(tempHeader);
                        }
                    }
                }
            }
            #endregion
            // ADD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<

            //>>>2012/06/29
            #region 削除
            //// 送信処理開始
            //// --- UPD m.suzuki 2011/02/22 ---------->>>>>
            ////foreach (SCMAcOdrDataWork userHeader in scmAcOdrDataList)
            //for ( int index = 0; index < scmAcOdrDataList.Count; index++ )
            //// --- UPD m.suzuki 2011/02/22 ----------<<<<<
            //{
            //    // --- ADD m.suzuki 2011/02/22 ---------->>>>>
            //    SCMAcOdrDataWork userHeader = scmAcOdrDataList[index];
            //    // --- ADD m.suzuki 2011/02/22 ----------<<<<<

            //    List<SCMAcOdrDtlAsWork> userAnswerList;
            //    // -- ADD 2011/08/10   ------ >>>>>>
            //    List<SCMAcOdSetDtWork> userSetDtList;
            //    // -- ADD 2011/08/10   ------ <<<<<<
            //    SCMAcOdrDtCarWork userCar;

            //    // 同ヘッダ情報を取得
            //    //--- DEL 2011/08/12 -------------------------------------------->>>
            //    //this.GetRelatedSCMOdrData(userHeader, scmAcOdrDtlAsWorkList, scmAcOdrDtCarWorkList,
            //    //                            out userAnswerList, out userCar);
            //    //--- DEL 2011/08/12 --------------------------------------------<<<
            //    // -- ADD 2011/08/10   ------ >>>>>>
            //    this.GetRelatedSCMOdrData(
            //                                userHeader, 
            //                                scmAcOdrDtlAsWorkList, 
            //                                scmAcOdrDtCarWorkList,
            //                                scmAcOdrSetDtWorkList,
            //                                out userAnswerList, 
            //                                out userCar,
            //                                out userSetDtList);
            //    // -- ADD 2011/08/10   ------ <<<<<<

            //    // --- ADD m.suzuki 2011/02/22 ---------->>>>>
            //    // web登録用SCM受注データ(header)の更新
            //    // 2011/03/02 >>>
            //    //this.ReflectSCMAcOdrData( ref userHeader, userAnswerList );
            //    this.ReflectSCMAcOdrData(ref userHeader, scmAcOdrDtlAsWorkList);
            //    // 2011/03/02 <<<
            //    // --- ADD m.suzuki 2011/02/22 ----------<<<<<

            //    // Web-DB型へ変換
            //    List<WebHeaderRecordType> webHeaderList = new List<WebHeaderRecordType>();
            //    WebCarRecordType webCar;
            //    List<WebAnswerRecordType> webAnswerList = new List<WebAnswerRecordType>();
            //    // -- ADD 2011/08/10   ------ >>>>>>
            //    List<WebSetDtRecordType> webSetDtList = new List<WebSetDtRecordType>();
            //    // -- ADD 2011/08/10   ------ <<<<<<
            //    {
            //        // SCM受発注データ
            //        UserSCMOrderHeaderRecord userSCMOrderHeaderRecord = new UserSCMOrderHeaderRecord(userHeader);
            //        webHeaderList.Add(userSCMOrderHeaderRecord.CopyToWebSCMOrderHeaderRecord().RealRecord);

            //        // SCM受発注データ(車両情報)
            //        if (userCar == null)
            //        {
            //            webCar = null;
            //        }
            //        else
            //        {
            //            UserSCMOrderCarRecord userSCMOrderCarRecord = new UserSCMOrderCarRecord(userCar);
            //            // PM側でSCM受発注データ(車両情報)のヘッダ情報を保持していないことにより、
            //            // Web-DBのSCM受発注データ(車両情報)を更新できないため、一度、再取得し、ヘッダ情報を設定する。
            //            webCar = ConvertWebCarRecordIf(userSCMOrderCarRecord, userSCMOrderHeaderRecord);
            //        }

            //        // SCM受発注明細データ(回答)
            //        foreach (SCMAcOdrDtlAsWork userAnswer in userAnswerList)
            //        {
            //            UserSCMOrderAnswerRecord userSCMOrderAnswerRecord = new UserSCMOrderAnswerRecord(userAnswer);
            //            webAnswerList.Add(userSCMOrderAnswerRecord.CopyToWebSCMOrderAnswerRecord().RealRecord);
            //        }

            //        // -- ADD 2011/08/10   ------ >>>>>>
            //        if (userSetDtList != null && userSetDtList.Count > 0)
            //        {
            //            // SCMセットマスタ
            //            foreach (SCMAcOdSetDtWork userSetDt in userSetDtList)
            //            {
            //                UserSCMAcOdSetDtRecord userSCMAcOdSetDtRecord = new UserSCMAcOdSetDtRecord(userSetDt);
            //                webSetDtList.Add(userSCMAcOdSetDtRecord.CopyToWebSCMAcOdSetDtRecord().RealRecord);
            //            }
            //        }
            //        // -- ADD 2011/08/10   ------ <<<<<<
            //    }
            //    try
            //    {
            //        #region <Log>

            //        StringBuilder dataCSV = new StringBuilder();
            //        {
            //            dataCSV.Append("売上伝票番号【").Append(userHeader.SalesSlipNum).Append("】を送信します。" + Environment.NewLine);
            //            dataCSV.Append("[SCM受発注データ]").Append(Environment.NewLine);
            //            dataCSV.Append(MsgUtil.ConvertCSV(webHeaderList)).Append(Environment.NewLine);
            //            dataCSV.Append("[SCM受発注データ(車両情報)]").Append(Environment.NewLine);
            //            dataCSV.Append(MsgUtil.ConvertCSV(webCar)).Append(Environment.NewLine);
            //            dataCSV.Append("[SCM受発注明細データ(回答)]").Append(Environment.NewLine);
            //            // -- ADD 2011/08/10   ------ >>>>>>
            //            if (userSetDtList != null && userSetDtList.Count > 0)
            //            {
            //                dataCSV.Append("[SCMセット部品データ]").Append(Environment.NewLine);
            //            }
            //            // -- ADD 2011/08/10   ------ <<<<<<
            //        }
            //        WriteLog(dataCSV.ToString());

            //        #endregion // </Log>

            //        // -- ADD 2011/08/10   ------ >>>>>>
            //        if (userHeader.AcceptOrOrderKind == 0)
            //        {
            //        // -- ADD 2011/08/10   ------ <<<<<<
            //        // SCM Web-DB に書込み
            //        status = RealAccesser.WriteAnsWithCar(ref webHeaderList, ref webCar, ref webAnswerList);
            //        // -- ADD 2011/08/10   ------ >>>>>>
            //        }
            //        else
            //        {
            //            // SCM Web-DB に書込み
            //            status = RealAccesser.WriteAnsWithCarAndSet(ref webHeaderList, ref webCar, ref webAnswerList, ref webSetDtList);
            //        }
            //        // -- ADD 2011/08/10   ------ <<<<<<

            //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //        {
            //            // 2010/02/13 Add >>>
            //            // 2011/03/02 >>>
            //            //if (first)
            //            // CMT連携しているデータはＣＭＴに通知する
            //            if (userHeader.CMTCooprtDiv == 1)
            //            // 2011/03/02 <<<
            //            {
            //                // 2010/03/11 >>>
            //                //const string ctProtcol_send = "pmscmsend";
            //                const string ctProtcol_SBpipe = "pmcmtpipe";
            //                // 2010/03/11 <<<

            //                // 商談ツールに結果を返す
            //                string errorMsg;
            //                //System.Windows.Forms.MessageBox.Show("送信前");

            //                // 2010/03/11 >>>
            //                //// 2010/03/08 >>>
            //                ////// 2010/03/01 >>>
            //                //////status = SimpleInquiryPipeMessage.Send(ctProtcol_send + ":" + webHeaderList[0].InquiryNumber.ToString(), 30000, out errorMsg);
            //                ////status = SimpleInquiryPipeMessage.Send(ctProtcol_send + ":" + webHeaderList[0].InqOriginalEpCd + ":" + webHeaderList[0].InqOriginalSecCd + ":" + webHeaderList[0].InqOtherEpCd + ":" + webHeaderList[0].InqOtherSecCd + ":" + webHeaderList[0].InquiryNumber + ":" + webHeaderList[0].InqOrdDivCd.ToString(), 30000, out errorMsg);
            //                ////// 2010/03/01 <<<

            //                //status = SimpleInquiryPipeMessage.Send(ctProtcol_send + ":" + webHeaderList[0].InqOriginalEpCd + ":" + webHeaderList[0].InqOriginalSecCd + ":" + webHeaderList[0].InqOtherEpCd + ":" + webHeaderList[0].InqOtherSecCd + ":" + webHeaderList[0].InqOrdDivCd.ToString() + ":" + webHeaderList[0].InquiryNumber, 30000, out errorMsg);
            //                //// 2010/03/08 <<<

            //                status = SimpleInquiryPipeMessage.Send(ctProtcol_SBpipe + ":" + webHeaderList[0].InqOriginalEpCd + ":" + webHeaderList[0].InqOriginalSecCd + ":" + webHeaderList[0].InqOtherEpCd + ":" + webHeaderList[0].InqOtherSecCd + ":" + webHeaderList[0].InqOrdDivCd.ToString() + ":" + webHeaderList[0].InquiryNumber, 30000, out errorMsg);

            //                // 2010/03/11 <<<
            //                //System.Windows.Forms.MessageBox.Show("送信後" + Environment.NewLine +
            //                //    "message:" + ctProtcol_send + ":" + webHeaderList[0].InquiryNumber.ToString() + Environment.NewLine +
            //                //    "status:" + status.ToString() + Environment.NewLine +
            //                //    "errorMsg" + errorMsg);
            //                //errMsg = errMsg + Environment.NewLine + string.Format("命令:{0}", ( ctProtcol_send + ":" + webHeaderList[0].InquiryNumber.ToString() ));
            //                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //                {
            //                    errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】問い合わせ番号【{1}】のＣＭＴ送信処理でエラーが発生しました。status【{2}】", userHeader.SalesSlipNum, webHeaderList[0].InquiryNumber + " " + errorMsg, status);
            //                }
            //                first = false;
            //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //            }
            //            // 2010/02/13 Add <<<

            //            // 戻り値の反映
            //            #region 受注データ
            //            // 問合せ番号
            //            if (userHeader.InquiryNumber == 0)
            //            {
            //                userHeader.InquiryNumber = webHeaderList[0].InquiryNumber;
            //            }
            //            userHeader.UpdateDate = webHeaderList[0].UpdateDate; // 更新年月日
            //            userHeader.UpdateTime = webHeaderList[0].UpdateTime; // 更新時分秒ミリ秒
            //            #endregion

            //            #region 受注データ（車両情報）
            //            if (userCar.InquiryNumber == 0)
            //            {
            //                userCar.InquiryNumber = webCar.InquiryNumber;
            //            }
            //            #endregion

            //            #region 受注明細データ(回答)
            //            int i = 0;
            //            foreach (SCMAcOdrDtlAsWork userAnswer in userAnswerList)
            //            {
            //                // 2009.07.21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //                //WebAnswerRecordType webAnswer
            //                //    = webAnswerList.Find(delegate(WebAnswerRecordType webAns)
            //                //    {
            //                //        if (userAnswer.InqRowNumber == webAns.InqRowNumber
            //                //            && userAnswer.InqRowNumDerivedNo == webAns.InqRowNumDerivedNo)
            //                //        {
            //                //            return true;
            //                //        }
            //                //        else
            //                //        {
            //                //            return false;
            //                //        }
            //                //    }
            //                //);
            //                //if (userAnswer.InquiryNumber == 0)
            //                //{
            //                //    userAnswer.InquiryNumber = webAnswer.InquiryNumber;
            //                //}
            //                //userAnswer.UpdateDate = webAnswer.UpdateDate; // 更新年月日
            //                //userAnswer.UpdateTime = webAnswer.UpdateTime; // 更新時分秒ミリ秒

            //                if (userAnswer.InquiryNumber == 0)
            //                {
            //                    #region <Log>

            //                    string msg = string.Format(
            //                        "伝票番号：{0}\t…問合せ番号を更新：[{1}]→[{2}]",
            //                        userAnswer.SalesSlipNum,
            //                        userAnswer.InquiryNumber,
            //                        webHeaderList[0].InquiryNumber
            //                    );
            //                    SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

            //                    #endregion // </Log>

            //                    userAnswer.InquiryNumber = webHeaderList[0].InquiryNumber;
            //                }

            //                #region <Log>

            //                string message = string.Format(
            //                    "伝票番号：{0}\t…更新年月日を更新：[{1}]→[{2}]",
            //                    userAnswer.SalesSlipNum,
            //                    userAnswer.UpdateDate,
            //                    webHeaderList[0].UpdateDate
            //                );
            //                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(message));

            //                message = string.Format(
            //                    "伝票番号：{0}\t…更新時分秒を更新：[{1}]→[{2}]",
            //                    userAnswer.SalesSlipNum,
            //                    userAnswer.UpdateTime,
            //                    webHeaderList[0].UpdateTime
            //                );
            //                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(message));

            //                #endregion // </Log>
                            
            //                userAnswer.UpdateDate = webHeaderList[0].UpdateDate; // 更新年月日
            //                userAnswer.UpdateTime = webHeaderList[0].UpdateTime; // 更新時分秒
            //                // 2009.07.21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //                // 問合せ行番号 ∵電話発注の場合、-1となっている
            //                if (userAnswer.InqRowNumber < 0)
            //                {
            //                    #region <Log>
                                
            //                    string msg = string.Format(
            //                        "伝票番号：{0}\t…問合せ行番号を更新：[{1}]→[{2}]",
            //                        userAnswer.SalesSlipNum,
            //                        userAnswer.InqRowNumber,
            //                        webAnswerList[i].InqRowNumber
            //                    );
            //                    SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

            //                    #endregion // </Log>

            //                    userAnswer.InqRowNumber = webAnswerList[i].InqRowNumber;
            //                }
            //                // 問合せ行番号枝番 ∵NSは負の値で採番している
            //                if (userAnswer.InqRowNumDerivedNo < 0)
            //                {
            //                    #region <Log>

            //                    string msg = string.Format(
            //                        "伝票番号：{0}\t…問合せ行番号枝番を更新：[{1}]→[{2}]",
            //                        userAnswer.SalesSlipNum,
            //                        userAnswer.InqRowNumDerivedNo,
            //                        webAnswerList[i].InqRowNumDerivedNo
            //                    );
            //                    SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

            //                    #endregion // </Log>

            //                    userAnswer.InqRowNumDerivedNo = webAnswerList[i].InqRowNumDerivedNo;
            //                }
            //                i++;
            //            }
            //            #endregion
            //            // -- ADD 2011/08/10   ------ >>>>>>
            //            #region SCMセットマスタ
            //            foreach (SCMAcOdSetDtWork userSetDt in userSetDtList)
            //            {
            //                if (userSetDt.InquiryNumber == 0)
            //                {
            //                    userSetDt.InquiryNumber = webHeaderList[0].InquiryNumber;
            //                }
            //            }
            //            #endregion
            //            // -- ADD 2011/08/10   ------ <<<<<<
            //            // 戻り値の保存
            //            retHeaderList.Add(userHeader);
            //            retCarList.Add(userCar);
            //            retAnswerList.AddRange(userAnswerList);
            //            // 2011.07.12 ZHANGYH ADD STA >>>>>>
            //            // 問合せ先企業コードリストと拠点コードリストを戻る
            //            string sendEpScDictKey = userHeader.InqOriginalEpCd.Trim() + "," + userHeader.InqOriginalSecCd.Trim();
            //            if (!sendEpScDict.ContainsKey(sendEpScDictKey))
            //            {
            //                sendEnterpriseCodeList.Add(userHeader.InqOriginalEpCd.Trim());
            //                sendSectionCodeList.Add(userHeader.InqOriginalSecCd.Trim());
            //                sendEpScDict.Add(sendEpScDictKey, null);
            //            }
            //            // 2011.07.12 ZHANGYH ADD END <<<<<<
            //            // -- ADD 2011/08/10   ------ >>>>>>
            //            retSetDtList.AddRange(userSetDtList);
            //            // -- ADD 2011/08/10   ------ <<<<<<
            //            errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】のWeb更新処理は正常終了しました。status【{1}】", userHeader.SalesSlipNum, status);
            //        }
            //        else
            //        {
            //            errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】のWeb更新処理でエラーが発生しました。status【{1}】", userHeader.SalesSlipNum, status);
            //            continue;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】のWeb更新処理で例外が発生しました。", userHeader.SalesSlipNum);
            //        errMsg += Environment.NewLine + ex.ToString();

            //        continue;
            //    }
            //    finally
            //    {
            //        // 次回の送信時に同一のSCM受発注データ(車両情報)を更新することがあるので、
            //        // 送信ごとにSCM受発注データ(車両情報)のキャッシュをクリア
            //        WebCarReaccessionMap.Clear();
            //    }
            //}
            #endregion

            // ADD 2012/09/26 SCM障害№10373対応 -------------------------------->>>>>
            try
            {
            // ADD 2012/09/26 SCM障害№10373対応 --------------------------------<<<<<

                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                int retryLimit = 0;              // リトライ回数
                int sleepMS = 0;  // 待ち
                if (SettingInformation != null)
                {
                    // 設定情報プロパティが設定されている場合リトライ設定を取得する
                    retryLimit = SettingInformation.SendRetry;
                    // ThreadSleepの精度ミリ秒なので1000倍する
                    sleepMS = SettingInformation.SendSleepSec * 1000;
                }
                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

                // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                //if (iMode <= 1)
                if ((SalesSlipUnitList != null) && (SalesSlipUnitList.Count != 0))
                // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                {
                    #region 売上伝票単位に送信(既存処理)
                    // 送信処理開始
                    // --- UPD m.suzuki 2011/02/22 ---------->>>>>
                    //foreach (SCMAcOdrDataWork userHeader in scmAcOdrDataList)
                    // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                    //for (int index = 0; index < scmAcOdrDataList.Count; index++)
                    for (int index = 0; index < SalesSlipUnitList.Count; index++)
                    // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                    // --- UPD m.suzuki 2011/02/22 ----------<<<<<
                    {
                        // --- ADD m.suzuki 2011/02/22 ---------->>>>>
                        // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                        //SCMAcOdrDataWork userHeader = scmAcOdrDataList[index];
                        SCMAcOdrDataWork userHeader = SalesSlipUnitList[index];
                        // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                        // --- ADD m.suzuki 2011/02/22 ----------<<<<<

                        List<SCMAcOdrDtlAsWork> userAnswerList;
                        // -- ADD 2011/08/10   ------ >>>>>>
                        List<SCMAcOdSetDtWork> userSetDtList;
                        // -- ADD 2011/08/10   ------ <<<<<<
                        SCMAcOdrDtCarWork userCar;

                        // 同ヘッダ情報を取得
                        //--- DEL 2011/08/12 -------------------------------------------->>>
                        //this.GetRelatedSCMOdrData(userHeader, scmAcOdrDtlAsWorkList, scmAcOdrDtCarWorkList,
                        //                            out userAnswerList, out userCar);
                        //--- DEL 2011/08/12 --------------------------------------------<<<
                        // -- ADD 2011/08/10   ------ >>>>>>
                        this.GetRelatedSCMOdrData(
                                                    userHeader,
                                                    scmAcOdrDtlAsWorkList,
                                                    scmAcOdrDtCarWorkList,
                                                    scmAcOdrSetDtWorkList,
                                                    out userAnswerList,
                                                    out userCar,
                                                    out userSetDtList);
                        // -- ADD 2011/08/10   ------ <<<<<<

                        // --- ADD m.suzuki 2011/02/22 ---------->>>>>
                        // web登録用SCM受注データ(header)の更新
                        // 2011/03/02 >>>
                        //this.ReflectSCMAcOdrData( ref userHeader, userAnswerList );
                        this.ReflectSCMAcOdrData(ref userHeader, scmAcOdrDtlAsWorkList);
                        // 2011/03/02 <<<
                        // --- ADD m.suzuki 2011/02/22 ----------<<<<<

                        // --- DEL 2014/01/06 Y.Wakita ---------->>>>>
                        //// --- ADD 2013/07/31 Y.Wakita ---------->>>>>
                        //if (userHeader.InqEmployeeCd == null)
                        //{
                        //    // --- ADD 2013/07/31 Y.Wakita ----------<<<<<
                        // --- DEL 2014/01/06 Y.Wakita ----------<<<<<

                        // --- ADD 2013/03/07 三戸 2013/04/10配信分 SCM障害№10501対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        // いきなり回答の時、受発注種別を再取得する
                        // 1:PCC-UOE(BLﾊﾟｰﾂｵｰﾀﾞｰ)のはずが、0:通常(PCCforNS)に設定されている場合がある
                        StringBuilder dataLog = new StringBuilder();
                        dataLog.Append(Environment.NewLine);
                        dataLog.Append("受発注種別の再取得を行います").Append(Environment.NewLine);
                        dataLog.Append("  問合せ元企業コード=").Append(userHeader.InqOriginalEpCd.Trim()).Append(Environment.NewLine);//@@@@20230303
                        dataLog.Append("  問合せ元拠点コード=").Append(userHeader.InqOriginalSecCd).Append(Environment.NewLine);
                        dataLog.Append("  問合せ先企業コード=").Append(userHeader.InqOtherEpCd).Append(Environment.NewLine);
                        dataLog.Append("  問合せ先拠点コード=").Append(userHeader.InqOtherSecCd).Append(Environment.NewLine);
                        dataLog.Append("  売上伝票番号=").Append(userHeader.SalesSlipNum.ToString()).Append(Environment.NewLine);
                        dataLog.Append("  問合せ番号=").Append(userHeader.InquiryNumber.ToString()).Append(Environment.NewLine);
                        dataLog.Append("  再設定前  受発注種別=").Append(userHeader.AcceptOrOrderKind.ToString()).Append(Environment.NewLine);

                        short AcceptOrOrderKindSave = userHeader.AcceptOrOrderKind;
                        bool msgDiv;
                        string errMsg2;
                        ScmEpScCnt scmEpScCnt = null;
                        ScmEpScCntAcs scmEpScCntAcs = new ScmEpScCntAcs();
                        //ＰＣＣ接続情報の取得
                        status = scmEpScCntAcs.ReadScmEpScCnt(userHeader.InqOriginalEpCd.Trim(), userHeader.InqOriginalSecCd, userHeader.InqOtherEpCd, userHeader.InqOtherSecCd, out scmEpScCnt, out msgDiv, out errMsg2);  // ADD 2011/11/12//@@@@20230303

                        dataLog.Append(Environment.NewLine);
                        dataLog.Append("  ＰＣＣ接続情報の取得").Append(Environment.NewLine);
                        dataLog.Append("    ステータス=").Append(status).Append(Environment.NewLine);
                        dataLog.Append("    エラーメッセージ=").Append(errMsg2).Append(Environment.NewLine);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // UPD 2014/04/03 吉岡 №10618  ---------->>>>>>>>>>>>>>>
                            #region 旧ソース
                            //if (scmEpScCnt.PccUoeCommMethod == 1)
                            //{
                            //    userHeader.AcceptOrOrderKind = 1;
                            //}
                            #endregion
                            userHeader.AcceptOrOrderKind = scmEpScCnt.PccUoeCommMethod;
                            // UPD 2014/04/03 吉岡 №10618  ----------<<<<<<<<<<<<<<<
                            dataLog.Append("    識別区分=").Append(scmEpScCnt.DiscDivCd).Append(Environment.NewLine);
                            dataLog.Append("    通信方式(SCM)=").Append(scmEpScCnt.ScmCommMethod).Append(Environment.NewLine);
                            dataLog.Append("    通信方式(PCC-UOE)=").Append(scmEpScCnt.PccUoeCommMethod).Append(Environment.NewLine);
                        }

                        dataLog.Append("  再設定後  受発注種別=").Append(userHeader.AcceptOrOrderKind.ToString()).Append(Environment.NewLine);

                        // --- ADD 2014/01/06 Y.Wakita ---------->>>>>
                        // SFからの発注をUOE回答(分納)でする場合、
                        // 受発注種別を再設定せず値を引き継ぐようにする
                        if (userHeader.InqEmployeeCd != "")
                        {
                            // 問合せ従業員コードが設定されている場合
                            userHeader.AcceptOrOrderKind = AcceptOrOrderKindSave;
                        }
                        // --- ADD 2014/01/06 Y.Wakita ----------<<<<<

                        if (AcceptOrOrderKindSave != userHeader.AcceptOrOrderKind) dataLog.Append("異常：受発注種別が変更されました").Append(Environment.NewLine);
                        SimpleLogger.Write(MY_NAME, METHOD_NAME, dataLog.ToString());
                        // --- ADD 2013/03/07 三戸 2013/04/10配信分 SCM障害№10501対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        // --- DEL 2014/01/06 Y.Wakita ---------->>>>>
                        //// --- ADD 2013/07/31 Y.Wakita ---------->>>>>
                        //}
                        //// --- ADD 2013/07/31 Y.Wakita ----------<<<<<
                        // --- DEL 2014/01/06 Y.Wakita ----------<<<<<

                        // Web-DB型へ変換
                        List<WebHeaderRecordType> webHeaderList = new List<WebHeaderRecordType>();
                        WebCarRecordType webCar;
                        List<WebAnswerRecordType> webAnswerList = new List<WebAnswerRecordType>();
                        // -- ADD 2011/08/10   ------ >>>>>>
                        List<WebSetDtRecordType> webSetDtList = new List<WebSetDtRecordType>();
                        // -- ADD 2011/08/10   ------ <<<<<<
                        {
                            // SCM受発注データ
                            UserSCMOrderHeaderRecord userSCMOrderHeaderRecord = new UserSCMOrderHeaderRecord(userHeader);
                            webHeaderList.Add(userSCMOrderHeaderRecord.CopyToWebSCMOrderHeaderRecord().RealRecord);

                            // SCM受発注データ(車両情報)
                            if (userCar == null)
                            {
                                webCar = null;
                            }
                            else
                            {
                                UserSCMOrderCarRecord userSCMOrderCarRecord = new UserSCMOrderCarRecord(userCar);
                                // PM側でSCM受発注データ(車両情報)のヘッダ情報を保持していないことにより、
                                // Web-DBのSCM受発注データ(車両情報)を更新できないため、一度、再取得し、ヘッダ情報を設定する。
                                webCar = ConvertWebCarRecordIf(userSCMOrderCarRecord, userSCMOrderHeaderRecord);
                            }

                            // SCM受発注明細データ(回答)
                            foreach (SCMAcOdrDtlAsWork userAnswer in userAnswerList)
                            {
                                UserSCMOrderAnswerRecord userSCMOrderAnswerRecord = new UserSCMOrderAnswerRecord(userAnswer);
                                webAnswerList.Add(userSCMOrderAnswerRecord.CopyToWebSCMOrderAnswerRecord().RealRecord);
                            }

                            // -- ADD 2011/08/10   ------ >>>>>>
                            if (userSetDtList != null && userSetDtList.Count > 0)
                            {
                                // SCMセットマスタ
                                foreach (SCMAcOdSetDtWork userSetDt in userSetDtList)
                                {
                                    UserSCMAcOdSetDtRecord userSCMAcOdSetDtRecord = new UserSCMAcOdSetDtRecord(userSetDt);
                                    webSetDtList.Add(userSCMAcOdSetDtRecord.CopyToWebSCMAcOdSetDtRecord().RealRecord);
                                }
                            }
                            // -- ADD 2011/08/10   ------ <<<<<<
                        }
                        try
                        {
                            #region <Log>

                            StringBuilder dataCSV = new StringBuilder();
                            {
                                dataCSV.Append("売上伝票番号【").Append(userHeader.SalesSlipNum).Append("】を送信します。" + Environment.NewLine);
                                dataCSV.Append("[SCM受発注データ]").Append(Environment.NewLine);
                                dataCSV.Append(MsgUtil.ConvertCSV(webHeaderList)).Append(Environment.NewLine);
                                dataCSV.Append("[SCM受発注データ(車両情報)]").Append(Environment.NewLine);
                                dataCSV.Append(MsgUtil.ConvertCSV(webCar)).Append(Environment.NewLine);
                                dataCSV.Append("[SCM受発注明細データ(回答)]").Append(Environment.NewLine);
                                // ADD 2012/08/09 2012/08/23配信障害対応 yugami -------------->>>>>
                                dataCSV.Append("【売上伝票単位に送信(既存処理)】").Append(Environment.NewLine);
                                dataCSV.Append("【SCM受発注明細データ(回答)レコード件数】").Append(userAnswerList.Count).Append("件" + Environment.NewLine);
                                // ADD 2012/08/09 2012/08/23配信障害対応 yugami --------------<<<<<
                                // -- ADD 2011/08/10   ------ >>>>>>
                                if (userSetDtList != null && userSetDtList.Count > 0)
                                {
                                    dataCSV.Append("[SCMセット部品データ]").Append(Environment.NewLine);
                                }
                                // -- ADD 2011/08/10   ------ <<<<<<0
                            }
                            WriteLog(dataCSV.ToString());

                            #endregion // </Log>

                            // --- DEL 2014/10/14 Y.Wakita ---------->>>>>
                            //// -- ADD 2011/08/10   ------ >>>>>>
                            //if (userHeader.AcceptOrOrderKind == 0)
                            //{
                            //    // -- ADD 2011/08/10   ------ <<<<<<
                            //    // SCM Web-DB に書込み
                            //    status = RealAccesser.WriteAnsWithCar(ref webHeaderList, ref webCar, ref webAnswerList);
                            //    // -- ADD 2011/08/10   ------ >>>>>>
                            //}
                            //else
                            //{
                            //    // SCM Web-DB に書込み
                            //    status = RealAccesser.WriteAnsWithCarAndSet(ref webHeaderList, ref webCar, ref webAnswerList, ref webSetDtList);
                            //}
                            //// -- ADD 2011/08/10   ------ <<<<<<
                            // --- DEL 2014/10/14 Y.Wakita ----------<<<<<

                            // DEL 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                            //// --- ADD 2014/10/14 Y.Wakita ---------->>>>>
                            //// SCM Web-DB に書込み
                            //status = RealAccesser.WriteAnsWithCarAndSet(ref webHeaderList, ref webCar, ref webAnswerList, ref webSetDtList);
                            //// --- ADD 2014/10/14 Y.Wakita ----------<<<<<
                            // DEL 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<
                            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                            // SCM Web-DB書込み処理の戻り値が正常以外の時は指定回数までリトライする
                            // Exception発生時はリトライではなく終了する
                            SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, "SCM Web-DB 書込み"); // ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707
                            int count = 0;
                            for (count = 0; count <= retryLimit; count++)
                            {
                                // SCM Web-DB に書込み
                                status = RealAccesser.WriteAnsWithCarAndSet(ref webHeaderList, ref webCar, ref webAnswerList, ref webSetDtList);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;

                                Thread.Sleep(sleepMS);
                            }
                            SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, string.Format("リトライ回数:{0}", count));
                            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 2010/02/13 Add >>>
                                // 2011/03/02 >>>
                                //if (first)
                                // CMT連携しているデータはＣＭＴに通知する
                                if (userHeader.CMTCooprtDiv == 1)
                                // 2011/03/02 <<<
                                {
                                    // 2010/03/11 >>>
                                    //const string ctProtcol_send = "pmscmsend";
                                    const string ctProtcol_SBpipe = "pmcmtpipe";
                                    // 2010/03/11 <<<

                                    // 商談ツールに結果を返す
                                    string errorMsg;
                                    //System.Windows.Forms.MessageBox.Show("送信前");

                                    // 2010/03/11 >>>
                                    //// 2010/03/08 >>>
                                    ////// 2010/03/01 >>>
                                    //////status = SimpleInquiryPipeMessage.Send(ctProtcol_send + ":" + webHeaderList[0].InquiryNumber.ToString(), 30000, out errorMsg);
                                    ////status = SimpleInquiryPipeMessage.Send(ctProtcol_send + ":" + webHeaderList[0].InqOriginalEpCd + ":" + webHeaderList[0].InqOriginalSecCd + ":" + webHeaderList[0].InqOtherEpCd + ":" + webHeaderList[0].InqOtherSecCd + ":" + webHeaderList[0].InquiryNumber + ":" + webHeaderList[0].InqOrdDivCd.ToString(), 30000, out errorMsg);
                                    ////// 2010/03/01 <<<

                                    //status = SimpleInquiryPipeMessage.Send(ctProtcol_send + ":" + webHeaderList[0].InqOriginalEpCd + ":" + webHeaderList[0].InqOriginalSecCd + ":" + webHeaderList[0].InqOtherEpCd + ":" + webHeaderList[0].InqOtherSecCd + ":" + webHeaderList[0].InqOrdDivCd.ToString() + ":" + webHeaderList[0].InquiryNumber, 30000, out errorMsg);
                                    //// 2010/03/08 <<<

                                    status = SimpleInquiryPipeMessage.Send(ctProtcol_SBpipe + ":" + webHeaderList[0].InqOriginalEpCd.Trim() + ":" + webHeaderList[0].InqOriginalSecCd + ":" + webHeaderList[0].InqOtherEpCd + ":" + webHeaderList[0].InqOtherSecCd + ":" + webHeaderList[0].InqOrdDivCd.ToString() + ":" + webHeaderList[0].InquiryNumber, 30000, out errorMsg);//@@@@20230303

                                    // 2010/03/11 <<<
                                    //System.Windows.Forms.MessageBox.Show("送信後" + Environment.NewLine +
                                    //    "message:" + ctProtcol_send + ":" + webHeaderList[0].InquiryNumber.ToString() + Environment.NewLine +
                                    //    "status:" + status.ToString() + Environment.NewLine +
                                    //    "errorMsg" + errorMsg);
                                    //errMsg = errMsg + Environment.NewLine + string.Format("命令:{0}", ( ctProtcol_send + ":" + webHeaderList[0].InquiryNumber.ToString() ));
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】問い合わせ番号【{1}】のＣＭＴ送信処理でエラーが発生しました。status【{2}】", userHeader.SalesSlipNum, webHeaderList[0].InquiryNumber + " " + errorMsg, status);
                                    }
                                    first = false;
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                // 2010/02/13 Add <<<

                                // 戻り値の反映
                                #region 受注データ
                                // 問合せ番号
                                if (userHeader.InquiryNumber == 0)
                                {
                                    userHeader.InquiryNumber = webHeaderList[0].InquiryNumber;
                                }
                                userHeader.UpdateDate = webHeaderList[0].UpdateDate; // 更新年月日
                                userHeader.UpdateTime = webHeaderList[0].UpdateTime; // 更新時分秒ミリ秒
                                #endregion

                                #region 受注データ（車両情報）
                                if (userCar.InquiryNumber == 0)
                                {
                                    userCar.InquiryNumber = webCar.InquiryNumber;
                                }
                                #endregion

                                #region 受注明細データ(回答)
                                int i = 0;
                                foreach (SCMAcOdrDtlAsWork userAnswer in userAnswerList)
                                {
                                    // 2009.07.21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                    //WebAnswerRecordType webAnswer
                                    //    = webAnswerList.Find(delegate(WebAnswerRecordType webAns)
                                    //    {
                                    //        if (userAnswer.InqRowNumber == webAns.InqRowNumber
                                    //            && userAnswer.InqRowNumDerivedNo == webAns.InqRowNumDerivedNo)
                                    //        {
                                    //            return true;
                                    //        }
                                    //        else
                                    //        {
                                    //            return false;
                                    //        }
                                    //    }
                                    //);
                                    //if (userAnswer.InquiryNumber == 0)
                                    //{
                                    //    userAnswer.InquiryNumber = webAnswer.InquiryNumber;
                                    //}
                                    //userAnswer.UpdateDate = webAnswer.UpdateDate; // 更新年月日
                                    //userAnswer.UpdateTime = webAnswer.UpdateTime; // 更新時分秒ミリ秒

                                    if (userAnswer.InquiryNumber == 0)
                                    {
                                        #region <Log>

                                        string msg = string.Format(
                                            "伝票番号：{0}\t…問合せ番号を更新：[{1}]→[{2}]",
                                            userAnswer.SalesSlipNum,
                                            userAnswer.InquiryNumber,
                                            webHeaderList[0].InquiryNumber
                                        );
                                        SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        userAnswer.InquiryNumber = webHeaderList[0].InquiryNumber;
                                    }

                                    #region <Log>

                                    string message = string.Format(
                                        "伝票番号：{0}\t…更新年月日を更新：[{1}]→[{2}]",
                                        userAnswer.SalesSlipNum,
                                        userAnswer.UpdateDate,
                                        webHeaderList[0].UpdateDate
                                    );
                                    SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(message));

                                    message = string.Format(
                                        "伝票番号：{0}\t…更新時分秒を更新：[{1}]→[{2}]",
                                        userAnswer.SalesSlipNum,
                                        userAnswer.UpdateTime,
                                        webHeaderList[0].UpdateTime
                                    );
                                    SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(message));

                                    #endregion // </Log>

                                    userAnswer.UpdateDate = webHeaderList[0].UpdateDate; // 更新年月日
                                    userAnswer.UpdateTime = webHeaderList[0].UpdateTime; // 更新時分秒
                                    // 2009.07.21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    // 問合せ行番号 ∵電話発注の場合、-1となっている
                                    if (userAnswer.InqRowNumber < 0)
                                    {
                                        #region <Log>

                                        string msg = string.Format(
                                            "伝票番号：{0}\t…問合せ行番号を更新：[{1}]→[{2}]",
                                            userAnswer.SalesSlipNum,
                                            userAnswer.InqRowNumber,
                                            webAnswerList[i].InqRowNumber
                                        );
                                        SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        userAnswer.InqRowNumber = webAnswerList[i].InqRowNumber;
                                    }
                                    // 問合せ行番号枝番 ∵NSは負の値で採番している
                                    if (userAnswer.InqRowNumDerivedNo < 0)
                                    {
                                        #region <Log>

                                        string msg = string.Format(
                                            "伝票番号：{0}\t…問合せ行番号枝番を更新：[{1}]→[{2}]",
                                            userAnswer.SalesSlipNum,
                                            userAnswer.InqRowNumDerivedNo,
                                            webAnswerList[i].InqRowNumDerivedNo
                                        );
                                        SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        userAnswer.InqRowNumDerivedNo = webAnswerList[i].InqRowNumDerivedNo;
                                    }
                                    i++;
                                }
                                #endregion
                                // -- ADD 2011/08/10   ------ >>>>>>
                                #region SCMセットマスタ
                                foreach (SCMAcOdSetDtWork userSetDt in userSetDtList)
                                {
                                    if (userSetDt.InquiryNumber == 0)
                                    {
                                        userSetDt.InquiryNumber = webHeaderList[0].InquiryNumber;
                                    }
                                }
                                #endregion
                                // -- ADD 2011/08/10   ------ <<<<<<
                                // 戻り値の保存
                                retHeaderList.Add(userHeader);
                                retCarList.Add(userCar);
                                retAnswerList.AddRange(userAnswerList);
                                // 2011.07.12 ZHANGYH ADD STA >>>>>>
                                // 問合せ先企業コードリストと拠点コードリストを戻る
                                string sendEpScDictKey = userHeader.InqOriginalEpCd.Trim() + "," + userHeader.InqOriginalSecCd.Trim();
                                if (!sendEpScDict.ContainsKey(sendEpScDictKey))
                                {
                                    sendEnterpriseCodeList.Add(userHeader.InqOriginalEpCd.Trim());
                                    sendSectionCodeList.Add(userHeader.InqOriginalSecCd.Trim());
                                    sendEpScDict.Add(sendEpScDictKey, null);
                                }
                                // 2011.07.12 ZHANGYH ADD END <<<<<<
                                // -- ADD 2011/08/10   ------ >>>>>>
                                retSetDtList.AddRange(userSetDtList);
                                // -- ADD 2011/08/10   ------ <<<<<<
                                // --- UPD 2013/03/25 三戸 2013/04/10配信分 SCM障害№10493 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                //errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】のWeb更新処理は正常終了しました。status【{1}】", userHeader.SalesSlipNum, status);
                                errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】問合せ番号【{1}】のWeb更新処理は正常終了しました。status【{2}】", userHeader.SalesSlipNum, userHeader.InquiryNumber, status);
                                // --- UPD 2013/03/25 三戸 2013/04/10配信分 SCM障害№10493 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            }
                            else
                            {
                                // --- UPD 2013/03/25 三戸 2013/04/10配信分 SCM障害№10493 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                //errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】のWeb更新処理でエラーが発生しました。status【{1}】", userHeader.SalesSlipNum, status);
                                errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】問合せ番号【{1}】のWeb更新処理でエラーが発生しました。status【{2}】", userHeader.SalesSlipNum, userHeader.InquiryNumber, status);
                                // --- UPD 2013/03/25 三戸 2013/04/10配信分 SCM障害№10493 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                continue;
                            }
                        }
                        catch (Exception ex)
                        {
                            errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】のWeb更新処理で例外が発生しました。", userHeader.SalesSlipNum);
                            errMsg += Environment.NewLine + ex.ToString();

                            continue;
                        }
                        finally
                        {
                            // 次回の送信時に同一のSCM受発注データ(車両情報)を更新することがあるので、
                            // 送信ごとにSCM受発注データ(車両情報)のキャッシュをクリア
                            WebCarReaccessionMap.Clear();
                        }
                    }
                    #endregion
                }
                // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                //else
                if ((InquiryUnitList != null) && (InquiryUnitList.Count != 0))
                // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                {
                    #region 問合せ番号単位に送信
                    // 送信処理開始
                    // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                    //if ((scmAcOdrDataList != null) && (scmAcOdrDataList.Count != 0))
                    //{
                    for (int index2 = 0; index2 < InquiryUnitList.Count; index2++)
                    {
                        // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<

                        // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                        //SCMAcOdrDataWork userHeader = scmAcOdrDataList[0];
                        SCMAcOdrDataWork userHeader = InquiryUnitList[index2];
                        // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<

                        List<SCMAcOdrDtlAsWork> userAnswerList;
                        // -- ADD 2011/08/10   ------ >>>>>>
                        List<SCMAcOdSetDtWork> userSetDtList;
                        // -- ADD 2011/08/10   ------ <<<<<<
                        SCMAcOdrDtCarWork userCar;

                        // 同ヘッダ情報を取得
                        //--- DEL 2011/08/12 -------------------------------------------->>>
                        //this.GetRelatedSCMOdrData(userHeader, scmAcOdrDtlAsWorkList, scmAcOdrDtCarWorkList,
                        //                            out userAnswerList, out userCar);
                        //--- DEL 2011/08/12 --------------------------------------------<<<
                        // -- ADD 2011/08/10   ------ >>>>>>
                        this.GetRelatedSCMOdrData2(
                                                    userHeader,
                                                    scmAcOdrDtlAsWorkList,
                                                    scmAcOdrDtCarWorkList,
                                                    scmAcOdrSetDtWorkList,
                                                    out userAnswerList,
                                                    out userCar,
                                                    out userSetDtList);
                        // -- ADD 2011/08/10   ------ <<<<<<

                        // --- ADD m.suzuki 2011/02/22 ---------->>>>>
                        // web登録用SCM受注データ(header)の更新
                        // 2011/03/02 >>>
                        //this.ReflectSCMAcOdrData( ref userHeader, userAnswerList );
                        this.ReflectSCMAcOdrData(ref userHeader, scmAcOdrDtlAsWorkList);
                        // 2011/03/02 <<<
                        // --- ADD m.suzuki 2011/02/22 ----------<<<<<

                        // Web-DB型へ変換
                        List<WebHeaderRecordType> webHeaderList = new List<WebHeaderRecordType>();
                        WebCarRecordType webCar;
                        List<WebAnswerRecordType> webAnswerList = new List<WebAnswerRecordType>();
                        // -- ADD 2011/08/10   ------ >>>>>>
                        List<WebSetDtRecordType> webSetDtList = new List<WebSetDtRecordType>();
                        // -- ADD 2011/08/10   ------ <<<<<<
                        {
                            // SCM受発注データ
                            UserSCMOrderHeaderRecord userSCMOrderHeaderRecord = new UserSCMOrderHeaderRecord(userHeader);
                            webHeaderList.Add(userSCMOrderHeaderRecord.CopyToWebSCMOrderHeaderRecord().RealRecord);

                            // SCM受発注データ(車両情報)
                            if (userCar == null)
                            {
                                webCar = null;
                            }
                            else
                            {
                                UserSCMOrderCarRecord userSCMOrderCarRecord = new UserSCMOrderCarRecord(userCar);
                                // PM側でSCM受発注データ(車両情報)のヘッダ情報を保持していないことにより、
                                // Web-DBのSCM受発注データ(車両情報)を更新できないため、一度、再取得し、ヘッダ情報を設定する。
                                webCar = ConvertWebCarRecordIf(userSCMOrderCarRecord, userSCMOrderHeaderRecord);
                            }

                            // SCM受発注明細データ(回答)
                            foreach (SCMAcOdrDtlAsWork userAnswer in userAnswerList)
                            {
                                UserSCMOrderAnswerRecord userSCMOrderAnswerRecord = new UserSCMOrderAnswerRecord(userAnswer);
                                webAnswerList.Add(userSCMOrderAnswerRecord.CopyToWebSCMOrderAnswerRecord().RealRecord);
                            }

                            // -- ADD 2011/08/10   ------ >>>>>>
                            if (userSetDtList != null && userSetDtList.Count > 0)
                            {
                                // SCMセットマスタ
                                foreach (SCMAcOdSetDtWork userSetDt in userSetDtList)
                                {
                                    UserSCMAcOdSetDtRecord userSCMAcOdSetDtRecord = new UserSCMAcOdSetDtRecord(userSetDt);
                                    webSetDtList.Add(userSCMAcOdSetDtRecord.CopyToWebSCMAcOdSetDtRecord().RealRecord);
                                }
                            }
                            // -- ADD 2011/08/10   ------ <<<<<<
                        }
                        try
                        {
                            #region <Log>

                            StringBuilder dataCSV = new StringBuilder();
                            {
                                dataCSV.Append("売上伝票番号【").Append(userHeader.SalesSlipNum).Append("】を送信します。" + Environment.NewLine);
                                dataCSV.Append("[SCM受発注データ]").Append(Environment.NewLine);
                                dataCSV.Append(MsgUtil.ConvertCSV(webHeaderList)).Append(Environment.NewLine);
                                dataCSV.Append("[SCM受発注データ(車両情報)]").Append(Environment.NewLine);
                                dataCSV.Append(MsgUtil.ConvertCSV(webCar)).Append(Environment.NewLine);
                                dataCSV.Append("[SCM受発注明細データ(回答)]").Append(Environment.NewLine);
                                // ADD 2012/08/09 2012/08/23配信障害対応 yugami -------------->>>>>
                                dataCSV.Append("【問合せ番号単位に送信】").Append(Environment.NewLine);
                                dataCSV.Append("【SCM受発注明細データ(回答)レコード件数】").Append(userAnswerList.Count).Append("件" + Environment.NewLine);
                                // ADD 2012/08/09 2012/08/23配信障害対応 yugami --------------<<<<<
                                // -- ADD 2011/08/10   ------ >>>>>>
                                if (userSetDtList != null && userSetDtList.Count > 0)
                                {
                                    dataCSV.Append("[SCMセット部品データ]").Append(Environment.NewLine);
                                }
                                // -- ADD 2011/08/10   ------ <<<<<<
                            }
                            WriteLog(dataCSV.ToString());

                            #endregion // </Log>

                            // --- DEL 2014/10/14 Y.Wakita ---------->>>>>
                            //// -- ADD 2011/08/10   ------ >>>>>>
                            //if (userHeader.AcceptOrOrderKind == 0)
                            //{
                            //    // -- ADD 2011/08/10   ------ <<<<<<
                            //    // SCM Web-DB に書込み
                            //    status = RealAccesser.WriteAnsWithCar(ref webHeaderList, ref webCar, ref webAnswerList);
                            //    // -- ADD 2011/08/10   ------ >>>>>>
                            //}
                            //else
                            //{
                            //    // SCM Web-DB に書込み
                            //    status = RealAccesser.WriteAnsWithCarAndSet(ref webHeaderList, ref webCar, ref webAnswerList, ref webSetDtList);
                            //}
                            //// -- ADD 2011/08/10   ------ <<<<<<
                            // --- DEL 2014/10/14 Y.Wakita ----------<<<<<

                            // DEL 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                            //// --- ADD 2014/10/14 Y.Wakita ---------->>>>>
                            //// SCM Web-DB に書込み
                            //status = RealAccesser.WriteAnsWithCarAndSet(ref webHeaderList, ref webCar, ref webAnswerList, ref webSetDtList);
                            //// --- ADD 2014/10/14 Y.Wakita ----------<<<<<
                            // DEL 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<
                            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                            // SCM Web-DB書込み処理の戻り値が正常以外の時は指定回数までリトライする
                            // Exception発生時はリトライではなく終了する
                            int count = 0;
                            for (count = 0; count <= retryLimit; count++)
                            {
                                // SCM Web-DB に書込み
                                status = RealAccesser.WriteAnsWithCarAndSet(ref webHeaderList, ref webCar, ref webAnswerList, ref webSetDtList);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;

                                Thread.Sleep(sleepMS);
                            }
                            SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, string.Format("リトライ回数:{0}", count));
                            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 2010/02/13 Add >>>
                                // 2011/03/02 >>>
                                //if (first)
                                // CMT連携しているデータはＣＭＴに通知する
                                if (userHeader.CMTCooprtDiv == 1)
                                // 2011/03/02 <<<
                                {
                                    // 2010/03/11 >>>
                                    //const string ctProtcol_send = "pmscmsend";
                                    const string ctProtcol_SBpipe = "pmcmtpipe";
                                    // 2010/03/11 <<<

                                    // 商談ツールに結果を返す
                                    string errorMsg;
                                    //System.Windows.Forms.MessageBox.Show("送信前");

                                    // 2010/03/11 >>>
                                    //// 2010/03/08 >>>
                                    ////// 2010/03/01 >>>
                                    //////status = SimpleInquiryPipeMessage.Send(ctProtcol_send + ":" + webHeaderList[0].InquiryNumber.ToString(), 30000, out errorMsg);
                                    ////status = SimpleInquiryPipeMessage.Send(ctProtcol_send + ":" + webHeaderList[0].InqOriginalEpCd + ":" + webHeaderList[0].InqOriginalSecCd + ":" + webHeaderList[0].InqOtherEpCd + ":" + webHeaderList[0].InqOtherSecCd + ":" + webHeaderList[0].InquiryNumber + ":" + webHeaderList[0].InqOrdDivCd.ToString(), 30000, out errorMsg);
                                    ////// 2010/03/01 <<<

                                    //status = SimpleInquiryPipeMessage.Send(ctProtcol_send + ":" + webHeaderList[0].InqOriginalEpCd + ":" + webHeaderList[0].InqOriginalSecCd + ":" + webHeaderList[0].InqOtherEpCd + ":" + webHeaderList[0].InqOtherSecCd + ":" + webHeaderList[0].InqOrdDivCd.ToString() + ":" + webHeaderList[0].InquiryNumber, 30000, out errorMsg);
                                    //// 2010/03/08 <<<

                                    status = SimpleInquiryPipeMessage.Send(ctProtcol_SBpipe + ":" + webHeaderList[0].InqOriginalEpCd.Trim() + ":" + webHeaderList[0].InqOriginalSecCd + ":" + webHeaderList[0].InqOtherEpCd + ":" + webHeaderList[0].InqOtherSecCd + ":" + webHeaderList[0].InqOrdDivCd.ToString() + ":" + webHeaderList[0].InquiryNumber, 30000, out errorMsg);//@@@@20230303

                                    // 2010/03/11 <<<
                                    //System.Windows.Forms.MessageBox.Show("送信後" + Environment.NewLine +
                                    //    "message:" + ctProtcol_send + ":" + webHeaderList[0].InquiryNumber.ToString() + Environment.NewLine +
                                    //    "status:" + status.ToString() + Environment.NewLine +
                                    //    "errorMsg" + errorMsg);
                                    //errMsg = errMsg + Environment.NewLine + string.Format("命令:{0}", ( ctProtcol_send + ":" + webHeaderList[0].InquiryNumber.ToString() ));
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】問い合わせ番号【{1}】のＣＭＴ送信処理でエラーが発生しました。status【{2}】", userHeader.SalesSlipNum, webHeaderList[0].InquiryNumber + " " + errorMsg, status);
                                    }
                                    first = false;
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                // 2010/02/13 Add <<<

                                // 戻り値の反映
                                #region 受注データ
                                // 問合せ番号
                                if (userHeader.InquiryNumber == 0)
                                {
                                    userHeader.InquiryNumber = webHeaderList[0].InquiryNumber;
                                }
                                userHeader.UpdateDate = webHeaderList[0].UpdateDate; // 更新年月日
                                userHeader.UpdateTime = webHeaderList[0].UpdateTime; // 更新時分秒ミリ秒
                                #endregion

                                #region 受注データ（車両情報）
                                if (userCar.InquiryNumber == 0)
                                {
                                    userCar.InquiryNumber = webCar.InquiryNumber;
                                }
                                #endregion

                                #region 受注明細データ(回答)
                                int i = 0;
                                foreach (SCMAcOdrDtlAsWork userAnswer in userAnswerList)
                                {
                                    // 2009.07.21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                    //WebAnswerRecordType webAnswer
                                    //    = webAnswerList.Find(delegate(WebAnswerRecordType webAns)
                                    //    {
                                    //        if (userAnswer.InqRowNumber == webAns.InqRowNumber
                                    //            && userAnswer.InqRowNumDerivedNo == webAns.InqRowNumDerivedNo)
                                    //        {
                                    //            return true;
                                    //        }
                                    //        else
                                    //        {
                                    //            return false;
                                    //        }
                                    //    }
                                    //);
                                    //if (userAnswer.InquiryNumber == 0)
                                    //{
                                    //    userAnswer.InquiryNumber = webAnswer.InquiryNumber;
                                    //}
                                    //userAnswer.UpdateDate = webAnswer.UpdateDate; // 更新年月日
                                    //userAnswer.UpdateTime = webAnswer.UpdateTime; // 更新時分秒ミリ秒

                                    if (userAnswer.InquiryNumber == 0)
                                    {
                                        #region <Log>

                                        string msg = string.Format(
                                            "伝票番号：{0}\t…問合せ番号を更新：[{1}]→[{2}]",
                                            userAnswer.SalesSlipNum,
                                            userAnswer.InquiryNumber,
                                            webHeaderList[0].InquiryNumber
                                        );
                                        SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        userAnswer.InquiryNumber = webHeaderList[0].InquiryNumber;
                                    }

                                    #region <Log>

                                    string message = string.Format(
                                        "伝票番号：{0}\t…更新年月日を更新：[{1}]→[{2}]",
                                        userAnswer.SalesSlipNum,
                                        userAnswer.UpdateDate,
                                        webHeaderList[0].UpdateDate
                                    );
                                    SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(message));

                                    message = string.Format(
                                        "伝票番号：{0}\t…更新時分秒を更新：[{1}]→[{2}]",
                                        userAnswer.SalesSlipNum,
                                        userAnswer.UpdateTime,
                                        webHeaderList[0].UpdateTime
                                    );
                                    SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(message));

                                    #endregion // </Log>

                                    userAnswer.UpdateDate = webHeaderList[0].UpdateDate; // 更新年月日
                                    userAnswer.UpdateTime = webHeaderList[0].UpdateTime; // 更新時分秒
                                    // 2009.07.21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    // 問合せ行番号 ∵電話発注の場合、-1となっている
                                    if (userAnswer.InqRowNumber < 0)
                                    {
                                        #region <Log>

                                        string msg = string.Format(
                                            "伝票番号：{0}\t…問合せ行番号を更新：[{1}]→[{2}]",
                                            userAnswer.SalesSlipNum,
                                            userAnswer.InqRowNumber,
                                            webAnswerList[i].InqRowNumber
                                        );
                                        SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        userAnswer.InqRowNumber = webAnswerList[i].InqRowNumber;
                                    }
                                    // 問合せ行番号枝番 ∵NSは負の値で採番している
                                    if (userAnswer.InqRowNumDerivedNo < 0)
                                    {
                                        #region <Log>

                                        string msg = string.Format(
                                            "伝票番号：{0}\t…問合せ行番号枝番を更新：[{1}]→[{2}]",
                                            userAnswer.SalesSlipNum,
                                            userAnswer.InqRowNumDerivedNo,
                                            webAnswerList[i].InqRowNumDerivedNo
                                        );
                                        SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                                        #endregion // </Log>

                                        userAnswer.InqRowNumDerivedNo = webAnswerList[i].InqRowNumDerivedNo;
                                    }
                                    i++;
                                }
                                #endregion
                                // -- ADD 2011/08/10   ------ >>>>>>
                                #region SCMセットマスタ
                                foreach (SCMAcOdSetDtWork userSetDt in userSetDtList)
                                {
                                    if (userSetDt.InquiryNumber == 0)
                                    {
                                        userSetDt.InquiryNumber = webHeaderList[0].InquiryNumber;
                                    }
                                }
                                #endregion
                                // -- ADD 2011/08/10   ------ <<<<<<
                                // 戻り値の保存
                                // DEL 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                                //retHeaderList.Add(userHeader);
                                // DEL 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                                #region 全ヘッダ情報更新
                                // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                                //if ((scmAcOdrDataList != null) && (scmAcOdrDataList.Count >= 2))
                                if ((scmAcOdrDataList != null) && (scmAcOdrDataList.Count != 0))
                                // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                                {
                                    for (int index = 0; index < scmAcOdrDataList.Count; index++)
                                    {
                                        // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                                        //if (index == 0) continue;
                                        //SCMAcOdrDataWork userHeaderTemp = null;
                                        //userHeaderTemp = scmAcOdrDataList[index];

                                        //if (userHeaderTemp.InquiryNumber == 0)
                                        //{
                                        //    userHeaderTemp.InquiryNumber = webHeaderList[0].InquiryNumber;
                                        //}
                                        //userHeaderTemp.UpdateDate = webHeaderList[0].UpdateDate; // 更新年月日
                                        //userHeaderTemp.UpdateTime = webHeaderList[0].UpdateTime; // 更新時分秒ミリ秒

                                        //retHeaderList.Add(userHeaderTemp);

                                        SCMAcOdrDataWork userHeaderTemp = null;
                                        userHeaderTemp = scmAcOdrDataList[index];
                                        // 同一問合せ番号のみ更新
                                        if (userHeaderTemp.InquiryNumber == userHeader.InquiryNumber)
                                        {
                                            userHeaderTemp.UpdateDate = webHeaderList[0].UpdateDate; // 更新年月日
                                            userHeaderTemp.UpdateTime = webHeaderList[0].UpdateTime; // 更新時分秒ミリ秒
                                            retHeaderList.Add(userHeaderTemp);
                                        }
                                        // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                                    }
                                }
                                #endregion
                                // DEL 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                                //retCarList.Add(userCar);
                                // DEL 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                                #region 全車輌情報更新
                                // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                                //if ((scmAcOdrDtCarWorkList != null) && (scmAcOdrDtCarWorkList.Count >= 2))
                                if ((scmAcOdrDtCarWorkList != null) && (scmAcOdrDtCarWorkList.Count != 0))
                                // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                                {
                                    for (int index = 0; index < scmAcOdrDtCarWorkList.Count; index++)
                                    {
                                        // UPD 2012/08/10 改良No10296対応 yugami ---------------------------->>>>>
                                        //if (index == 0) continue;
                                        //SCMAcOdrDtCarWork userCarTemp = null;
                                        //userCarTemp = scmAcOdrDtCarWorkList[index];

                                        //if (userCarTemp.InquiryNumber == 0)
                                        //{
                                        //    userCarTemp.InquiryNumber = webCar.InquiryNumber;
                                        //}
                                        //retCarList.Add(userCarTemp);
                                        SCMAcOdrDtCarWork userCarTemp = null;
                                        userCarTemp = scmAcOdrDtCarWorkList[index];
                                        // 同一問合せ番号のみ更新
                                        if (userCarTemp.InquiryNumber == userCar.InquiryNumber)
                                        {
                                            retCarList.Add(userCarTemp);
                                        }
                                        // UPD 2012/08/10 改良No10296対応 yugami ----------------------------<<<<<
                                    }
                                }
                                #endregion
                                retAnswerList.AddRange(userAnswerList);
                                // 2011.07.12 ZHANGYH ADD STA >>>>>>
                                // 問合せ先企業コードリストと拠点コードリストを戻る
                                string sendEpScDictKey = userHeader.InqOriginalEpCd.Trim() + "," + userHeader.InqOriginalSecCd.Trim();
                                if (!sendEpScDict.ContainsKey(sendEpScDictKey))
                                {
                                    sendEnterpriseCodeList.Add(userHeader.InqOriginalEpCd.Trim());
                                    sendSectionCodeList.Add(userHeader.InqOriginalSecCd.Trim());
                                    sendEpScDict.Add(sendEpScDictKey, null);
                                }
                                // 2011.07.12 ZHANGYH ADD END <<<<<<
                                // -- ADD 2011/08/10   ------ >>>>>>
                                retSetDtList.AddRange(userSetDtList);
                                // -- ADD 2011/08/10   ------ <<<<<<
                                errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】のWeb更新処理は正常終了しました。status【{1}】", userHeader.SalesSlipNum, status);
                            }
                            else
                            {
                                errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】のWeb更新処理でエラーが発生しました。status【{1}】", userHeader.SalesSlipNum, status);
                                // UPD 2012/09/26 SCM障害№10373対応 -------------------------------->>>>>
                                //return status;
                                continue;
                                // UPD 2012/09/26 SCM障害№10373対応 --------------------------------<<<<<
                            }
                        }
                        catch (Exception ex)
                        {
                            errMsg = errMsg + Environment.NewLine + string.Format("売上伝票番号【{0}】のWeb更新処理で例外が発生しました。", userHeader.SalesSlipNum);
                            errMsg += Environment.NewLine + ex.ToString();

                            // UPD 2012/09/26 SCM障害№10373対応 -------------------------------->>>>>
                            //return status;
                            continue;
                            // UPD 2012/09/26 SCM障害№10373対応 --------------------------------<<<<<
                        }
                        finally
                        {
                            // 次回の送信時に同一のSCM受発注データ(車両情報)を更新することがあるので、
                            // 送信ごとにSCM受発注データ(車両情報)のキャッシュをクリア
                            WebCarReaccessionMap.Clear();
                        }
                    }
                    #endregion
                }
                //<<<2012/06/29
            // ADD 2012/09/26 SCM障害№10373対応 -------------------------------->>>>>
            }
            finally
            {
            // ADD 2012/09/26 SCM障害№10373対応 --------------------------------<<<<<
                // -- ADD 2011/08/10   ------ >>>>>>
                // SCMセット部品データの書込み結果
                foreach (SCMAcOdSetDtWork userSetDtRecord in retSetDtList)
                {
                    WritedResultSetDt.Add(new UserSCMAcOdSetDtRecord(userSetDtRecord));
                }
                // -- ADD 2011/08/10   ------ <<<<<<

                // 書込み結果を保持
                CopyToWritedResult(retHeaderList, retCarList, retAnswerList);

            // ADD 2012/09/26 SCM障害№10373対応 -------------------------------->>>>>
            }
            // ADD 2012/09/26 SCM障害№10373対応 --------------------------------<<<<<
            return status;
        }

        // 2011.07.12 ZHANGYH ADD STA >>>>>>
        /// <summary>
        /// SCM受発注明細データ(回答)を書込みます。
        /// </summary>
        /// <param name="scmIO">SCM I/O</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果コード</returns>
        public int WriteAnswerData(SCMIOAgent scmIO, ref string errMsg)
        {
            List<string> sendEnterpriseCodeList;
            List<string> sendSectionCodeList;
            // 2011.09.06 zhouzy UPDATE STA >>>>>>
            List<SCMAcOdrDataWork> scmAcOdrDataList;
            //return WriteAnswerData(scmIO, ref errMsg, out sendEnterpriseCodeList, out sendSectionCodeList);
            return WriteAnswerData(scmIO, ref errMsg, out sendEnterpriseCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            // 2011.09.06 zhouzy UPDATE END <<<<<<
        }
        // 2011.07.12 ZHANGYH ADD END <<<<<<

        // --- ADD m.suzuki 2011/02/22 ---------->>>>>
        /// <summary>
        /// 登録用SCM受注データ更新(header)
        /// </summary>
        /// <param name="header"></param>
        /// <param name="answerList"></param>
        private void ReflectSCMAcOdrData( ref SCMAcOdrDataWork header, List<SCMAcOdrDtlAsWork> answerList )
        {
            //----------------------------------------
            // UserDB読み込み
            //----------------------------------------
            # region [UserDB読み込み]
            // 条件設定
            IOWriteSCMReadWork readPara = new IOWriteSCMReadWork();
            readPara.EnterpriseCode = header.EnterpriseCode;
            readPara.InquiryNumber = header.InquiryNumber;
            readPara.InqOtherSecCd = header.InqOtherSecCd;
            readPara.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
            readPara.InqOriginalSecCd = header.InqOriginalSecCd;
            readPara.AnswerDivCds = new int[] { 0, 10, 20 }; // 0:アクションなし,10:一部回答,20:回答完了
            // (問合せ・発注を区別しない)

            // 読み込み
            object retObj = new CustomSerializeArrayList();
            int status = this.IOWriteScmDB.ScmRead( ref retObj, (object)readPara );

            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) return;
            SCMAcOdrDataWork scmHeaderWork;
            SCMAcOdrDtCarWork scmCarWork;
            List<SCMAcOdrDtlIqWork> scmDetailWorkList;
            List<SCMAcOdrDtlAsWork> scmAnswerWorkList;

            // データ分割
            IOWriterUtil.ExpandSCMReadRet( retObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmCarWork );
            # endregion

            //----------------------------------------
            // 問い合わせと回答の付き合わせ
            //----------------------------------------
            // 2011/03/02 >>>
            //bool existsAllAnswer = this.ExistsAllAnswer( header, answerList, scmDetailWorkList, scmAnswerWorkList );
            bool existsAllAnswer = this.ExistsAllAnswer(header, FilterTargetData(header, answerList), scmDetailWorkList, scmAnswerWorkList);
            // 2011/03/02 <<<

            //----------------------------------------
            // header更新
            //----------------------------------------
            // 回答区分(10:一部回答,20:回答完了)
            if ( existsAllAnswer )
            {
                header.AnswerDivCd = 20; // 20:回答完了
            }
            else
            {
                header.AnswerDivCd = 10; // 10:一部回答
            }
        }

        // 2011/03/02 Add >>>
        /// <summary>
        /// 対象データに絞り込みます（Web側データは、問合せ・発注種別等は考慮しません）
        /// </summary>
        /// <param name="header"></param>
        /// <param name="answerList"></param>
        /// <returns></returns>
        private List<SCMAcOdrDtlAsWork> FilterTargetData(SCMAcOdrDataWork header, List<SCMAcOdrDtlAsWork> answerList)
        {
            List<SCMAcOdrDtlAsWork> retList = answerList.FindAll(
                delegate(SCMAcOdrDtlAsWork answer)
                {
                    if (header.InqOriginalEpCd.Trim().Equals(answer.InqOriginalEpCd.Trim()) && //@@@@20230303
                        header.InqOriginalSecCd.Equals(answer.InqOriginalSecCd) &&
                        header.InqOtherSecCd.Equals(answer.InqOtherSecCd) &&
                        header.InquiryNumber.Equals(answer.InquiryNumber))
                    {
                        if (answer.AcptAnOdrStatus != 20) return true;
                    }
                    return false;
                });

            if (retList == null ) retList = new List<SCMAcOdrDtlAsWork>();

            return retList;
        }
        // 2011/03/02 Add <<<

        /// <summary>
        /// 回答済みチェック処理処理
        /// </summary>
        /// <param name="header"></param>
        /// <param name="answerList"></param>
        /// <param name="scmDetailWorkList"></param>
        /// <param name="scmAnswerWorkList"></param>
        /// <returns>true: 明細に対して回答が全て存在する。／false: まだ未回答の明細がある。</returns>
        private bool ExistsAllAnswer( SCMAcOdrDataWork header, List<SCMAcOdrDtlAsWork> answerList, List<SCMAcOdrDtlIqWork> scmDetailWorkList, List<SCMAcOdrDtlAsWork> scmAnswerWorkList )
        {
            // 問い合わせゼロ件なら全て回答済みとみなす
            if ( scmDetailWorkList == null || scmDetailWorkList.Count.Equals( 0 ) ) return true;

            // それ以外で回答ゼロ件なら未回答ありとみなす。
            if ( (answerList == null || answerList.Count.Equals( 0 )) &&
                 (scmAnswerWorkList == null || scmAnswerWorkList.Count.Equals( 0 )) ) return false;


            foreach ( SCMAcOdrDtlIqWork inq in scmDetailWorkList )
            {
                // 30:キャンセル確定はチェック対象外(回答不要の為)
                if ( inq.CancelCndtinDiv == 30 ) continue;

                bool existsAns = false;

                // 今回更新する回答リストから探す
                foreach ( SCMAcOdrDtlAsWork ans in answerList )
                {
                    if ( IsParenthoodRowNumber( ans, inq ) )
                    {
                        existsAns = true;
                        break;
                    }
                }

                if ( !existsAns )
                {
                    // 既にUserDBに存在する回答リストから探す
                    foreach ( SCMAcOdrDtlAsWork ans in scmAnswerWorkList )
                    {
                        if ( IsParenthood( ans, inq ) )
                        {
                            existsAns = true;
                            break;
                        }
                    }
                }

                // 回答が無い明細が１件でもあればfalse ⇒ 一部回答
                if ( !existsAns )
                {
                    return false;
                }
            }

            // 全件回答がある ⇒ 回答済み
            return true;
        }
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
        internal static bool IsParenthood( SCMAcOdrDtlAsWork ans, SCMAcOdrDtlIqWork inq )
        {
            // 2011/03/02 Add >>>
            // 受注ステータス=20(受注はUOE発注するデータなので対象外)
            if (ans.AcptAnOdrStatus == 20) return false;
            // 2011/03/02 Add <<<
            if (ans.InqRowNumber.Equals(inq.InqRowNumber) && ans.InqRowNumDerivedNo.Equals(inq.InqRowNumDerivedNo))
            {
                if ( ans.UpdateDate > inq.UpdateDate )
                {
                    return true;
                }
                else if ( ans.UpdateDate == inq.UpdateDate )
                {
                    return (ans.UpdateTime > inq.UpdateTime);
                }
            }
            return false;
        }
        /// <summary>
        /// 対応するか判定します。(行番号・行番号枝番のみで判定)
        /// </summary>
        /// <param name="ans"></param>
        /// <param name="inq"></param>
        /// <returns></returns>
        internal static bool IsParenthoodRowNumber( SCMAcOdrDtlAsWork ans, SCMAcOdrDtlIqWork inq )
        {
            if ( ans.InqRowNumber.Equals( inq.InqRowNumber ) && ans.InqRowNumDerivedNo.Equals( inq.InqRowNumDerivedNo ) )
            {
                return true;
            }
            return false;
        }
        // --- ADD m.suzuki 2011/02/22 ----------<<<<<

        /// <summary>
        /// 送信対象データの取得
        /// </summary>
        /// <param name="scmIO"></param>
        /// <param name="scmAcOdrDataList"></param>
        /// <param name="scmAcOdrDtCarWorkList"></param>
        /// <param name="scmAcOdrDtlAsWorkList"></param>
        /// <param name="scmAcOdrSetDtWorkList"></param>
        /// <returns></returns>
        private int GetSendTargetList(SCMIOAgent scmIO,
                                      out List<SCMAcOdrDataWork> scmAcOdrDataList, 
                                      out List<SCMAcOdrDtCarWork> scmAcOdrDtCarWorkList,
                                      out List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsWorkList,
                                      out List<SCMAcOdSetDtWork> scmAcOdrSetDtWorkList      // ADD 2011/08/12
                                    )
        {
            scmAcOdrDataList = new List<SCMAcOdrDataWork>();
            scmAcOdrDtCarWorkList = new List<SCMAcOdrDtCarWork>();
            scmAcOdrDtlAsWorkList = new List<SCMAcOdrDtlAsWork>();
            // -- ADD 2011/08/10   ------ >>>>>>
            scmAcOdrSetDtWorkList = new List<SCMAcOdSetDtWork>();
            // -- ADD 2011/08/10   ------ <<<<<<

            // 画面表示していた全データの取得
            // SCM受注データ
            List<SCMAcOdrDataWork> allSCMAcOdrDataList = scmIO.CreateUserHeaderRecordList();
            if (allSCMAcOdrDataList == null || allSCMAcOdrDataList.Count.Equals(0))
            {
                return (int)ResultUtil.ResultCode.Error;
            }

            // SCM受注データ(車両情報)
            List<SCMAcOdrDtCarWork> allSCMAcOdrDtCarWorkList = scmIO.CreateUserCarRecordList();
            if (allSCMAcOdrDtCarWorkList == null || allSCMAcOdrDtCarWorkList.Count.Equals(0))
            {
                return (int)ResultUtil.ResultCode.Error;
            }

            // SCM受注明細データ(回答)
            List<SCMAcOdrDtlAsWork> allSCMAcOdrDtlAsWorkList = scmIO.CreateUserAnswerRecordList();

            allSCMAcOdrDataList.RemoveAll(
                delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                {
                    if (scmAcOdrDataWork.UpdateDate != DateTime.MinValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // SCM受注明細データ(問合せ・発注)
            allSCMAcOdrDtlAsWorkList.RemoveAll(
                delegate(SCMAcOdrDtlAsWork scmAcOdrDtlAsWork)
                {
                    if (scmAcOdrDtlAsWork.UpdateDate != DateTime.MinValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // 受注データと同キー
            allSCMAcOdrDtCarWorkList.RemoveAll(
                delegate(SCMAcOdrDtCarWork scmAcOdrDtCarWork)
                {
                    if (!allSCMAcOdrDataList.Exists(
                            delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                            {
                                if (scmAcOdrDtCarWork.InqOriginalEpCd.Trim() == scmAcOdrDataWork.InqOriginalEpCd.Trim()
                                    && scmAcOdrDtCarWork.InqOriginalSecCd.Trim() == scmAcOdrDataWork.InqOriginalSecCd.Trim()
                                    && scmAcOdrDtCarWork.InquiryNumber == scmAcOdrDataWork.InquiryNumber
                                    && scmAcOdrDtCarWork.AcptAnOdrStatus == scmAcOdrDataWork.AcptAnOdrStatus
                                    && scmAcOdrDtCarWork.SalesSlipNum == scmAcOdrDataWork.SalesSlipNum)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        )
                    )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // -- ADD 2011/08/10   ------ >>>>>>
            List<SCMAcOdSetDtWork> allSCMAcOdrSetDtWorkList = scmIO.CreateUserSetDtRecordList();

            if (allSCMAcOdrSetDtWorkList != null && allSCMAcOdrSetDtWorkList.Count > 0)
            {
                scmAcOdrSetDtWorkList.AddRange(allSCMAcOdrSetDtWorkList);
            }
            // -- ADD 2011/08/10   ------ <<<<<<

            scmAcOdrDataList.AddRange(allSCMAcOdrDataList);
            scmAcOdrDtCarWorkList.AddRange(allSCMAcOdrDtCarWorkList);
            scmAcOdrDtlAsWorkList.AddRange(allSCMAcOdrDtlAsWorkList);

            return (int)ResultUtil.ResultCode.Normal;
        }

        /// <summary>
        /// 書込み結果にコピーします。
        /// </summary>
        /// <param name="scmOdrDataList">SCM受発注データの書込み結果</param>
        /// <param name="scmOdDtCarList">SCM受発注データ(車両情報)の書込み結果</param>
        /// <param name="scmOdDtAnsList">SCM受発注明細データ(回答)の書込み結果</param>
        private void CopyToWritedResult(
            List<SCMAcOdrDataWork> scmOdrDataList,
            List<SCMAcOdrDtCarWork> scmOdDtCarList,
            List<SCMAcOdrDtlAsWork> scmOdDtAnsList
        )
        {
            // SCM受発注データの書込み結果
            foreach (SCMAcOdrDataWork userHeaderRecord in scmOdrDataList)
            {
                WritedResult.First.Add(new UserSCMOrderHeaderRecord(userHeaderRecord));
            }

            foreach (SCMAcOdrDtCarWork userCarRecord in scmOdDtCarList)
            {
                // SCM受発注データ(車両情報)の書込み結果
                WritedResult.Second.Add(new UserSCMOrderCarRecord(userCarRecord));
            }

            // SCM受発注明細データ(回答)の書込み結果
            foreach (SCMAcOdrDtlAsWork userAnswerRecord in scmOdDtAnsList)
            {
                WritedResult.Third.Add(new UserSCMOrderAnswerRecord(userAnswerRecord));
            }
        }

        /// <summary>
        /// ステータスを変換します。
        /// </summary>
        /// <param name="webStatus">WEBアクセス時のステータス</param>
        /// <returns>結果コード</returns>
        private static int ConvertStatus(int webStatus)
        {
            int status = (int)ResultUtil.ResultCode.Normal;

        #if _LOCAL_DEBUG_

            // Webサービスが仮のため、強制的に正常とみなす
            if (webStatus.Equals( (int)ResultUtil.ResultCode.DBError))
            {
                status = (int)ResultUtil.ResultCode.Normal;
            }

        #else

            // オリジナルが結果コード"-1"をエラーとみなす作りとなっているため、
            // 強制的に"-1"に修正する
            if (!webStatus.Equals((int)ResultUtil.ResultCode.Normal))
            {
                status = (int)ResultUtil.ResultCode.Error;
            }

        #endif

            return status;
        }

        /// <summary>
        /// SCM受発注データと同キーの明細(回答)リスト、車両情報を取得する。
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <param name="scmOdDtAnsList"></param>
        /// <param name="scmAcOdrSetDtList"></param>
        /// <param name="scmOdDtCarList"></param>
        /// <param name="relatedSCMOdDtAnsList"></param>
        /// <param name="relatedSCMOdDtCar"></param>
        /// <param name="relatedScmAcOdrSetDtList"></param>
        //--- DEL 2011/08/12 -------------------------------------------->>>
        //private void GetRelatedSCMOdrData(
        //    SCMAcOdrDataWork scmOdrData, List<SCMAcOdrDtlAsWork> scmOdDtAnsList, List<SCMAcOdrDtCarWork> scmOdDtCarList,
        //    out List<SCMAcOdrDtlAsWork> relatedSCMOdDtAnsList, out SCMAcOdrDtCarWork relatedSCMOdDtCar)
        //--- DEL 2011/08/12 --------------------------------------------<<<
        // -- ADD 2011/08/10   ------ >>>>>>
        private void GetRelatedSCMOdrData(
                                            SCMAcOdrDataWork scmOdrData, 
                                            List<SCMAcOdrDtlAsWork> scmOdDtAnsList, 
                                            List<SCMAcOdrDtCarWork> scmOdDtCarList,
                                            List<SCMAcOdSetDtWork> scmAcOdrSetDtList,
                                            out List<SCMAcOdrDtlAsWork> relatedSCMOdDtAnsList, 
                                            out SCMAcOdrDtCarWork relatedSCMOdDtCar,
                                            out List<SCMAcOdSetDtWork> relatedScmAcOdrSetDtList)
        // -- ADD 2011/08/10   ------ <<<<<<
        {
            relatedSCMOdDtAnsList = new List<SCMAcOdrDtlAsWork>();
            relatedSCMOdDtCar = new SCMAcOdrDtCarWork();

            // キー項目の取得
            string inqOriginalEpCd = scmOdrData.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            string inqOriginalSecCd = scmOdrData.InqOriginalSecCd; // 問合せ元拠点コード
            string inqOtherEpCd = scmOdrData.InqOtherEpCd; // 問合せ先企業コード
            string inqOtherSecCd = scmOdrData.InqOtherSecCd; // 問合せ先拠点コード
            Int64 inquiryNumber = scmOdrData.InquiryNumber; // 問合せ番号
            int acptAnOdrStatus = scmOdrData.AcptAnOdrStatus; // 受注ステータス
            string salesSlipNum = scmOdrData.SalesSlipNum; // 売上伝票番号
            int inqOrdDivCd = scmOdrData.InqOrdDivCd; // 見積・発注種別
            
            // 明細(回答)データ取得
            relatedSCMOdDtAnsList = scmOdDtAnsList.FindAll(
                delegate(SCMAcOdrDtlAsWork scmOdDtAns)
                {
                    if (scmOdDtAns.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtAns.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtAns.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && scmOdDtAns.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && scmOdDtAns.InquiryNumber == inquiryNumber
                        && scmOdDtAns.AcptAnOdrStatus == acptAnOdrStatus
                        && scmOdDtAns.SalesSlipNum == salesSlipNum
                        && scmOdDtAns.InqOrdDivCd == inqOrdDivCd
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // 車両情報取得
            relatedSCMOdDtCar = scmOdDtCarList.Find(
                delegate(SCMAcOdrDtCarWork scmOdDtCar)
                {
                    if (scmOdDtCar.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtCar.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtCar.InquiryNumber == inquiryNumber
                        && scmOdDtCar.AcptAnOdrStatus == acptAnOdrStatus
                        && scmOdDtCar.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // -- ADD 2011/08/10   ------ >>>>>>
            relatedScmAcOdrSetDtList = scmAcOdrSetDtList.FindAll(
                delegate(SCMAcOdSetDtWork scmAcOdSetDt)
                {
                    if (scmAcOdSetDt.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmAcOdSetDt.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmAcOdSetDt.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && scmAcOdSetDt.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && scmAcOdSetDt.InquiryNumber == inquiryNumber
                        && scmAcOdSetDt.PMAcptAnOdrStatus == acptAnOdrStatus
                        //&& scmAcOdSetDt.PMSalesSlipNum == Int32.Parse(salesSlipNum)
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            // -- ADD 2011/08/10   ------ <<<<<<
        }

        //>>>2012/06/29
        /// <summary>
        /// SCM受発注データと同キーの明細(回答)リスト、車両情報を取得する。
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <param name="scmOdDtAnsList"></param>
        /// <param name="scmOdDtCarList"></param>
        /// <param name="scmAcOdrSetDtList"></param>
        /// <param name="relatedSCMOdDtAnsList"></param>
        /// <param name="relatedSCMOdDtCar"></param>
        /// <param name="relatedScmAcOdrSetDtList"></param>
        private void GetRelatedSCMOdrData2(
                                            SCMAcOdrDataWork scmOdrData,
                                            List<SCMAcOdrDtlAsWork> scmOdDtAnsList,
                                            List<SCMAcOdrDtCarWork> scmOdDtCarList,
                                            List<SCMAcOdSetDtWork> scmAcOdrSetDtList,
                                            out List<SCMAcOdrDtlAsWork> relatedSCMOdDtAnsList,
                                            out SCMAcOdrDtCarWork relatedSCMOdDtCar,
                                            out List<SCMAcOdSetDtWork> relatedScmAcOdrSetDtList)
        {
            relatedSCMOdDtAnsList = new List<SCMAcOdrDtlAsWork>();
            relatedSCMOdDtCar = new SCMAcOdrDtCarWork();

            // キー項目の取得
            string inqOriginalEpCd = scmOdrData.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            string inqOriginalSecCd = scmOdrData.InqOriginalSecCd; // 問合せ元拠点コード
            string inqOtherEpCd = scmOdrData.InqOtherEpCd; // 問合せ先企業コード
            string inqOtherSecCd = scmOdrData.InqOtherSecCd; // 問合せ先拠点コード
            Int64 inquiryNumber = scmOdrData.InquiryNumber; // 問合せ番号
            int acptAnOdrStatus = scmOdrData.AcptAnOdrStatus; // 受注ステータス
            string salesSlipNum = scmOdrData.SalesSlipNum; // 売上伝票番号
            int inqOrdDivCd = scmOdrData.InqOrdDivCd; // 見積・発注種別

            // 明細(回答)データ取得
            relatedSCMOdDtAnsList = scmOdDtAnsList.FindAll(
                delegate(SCMAcOdrDtlAsWork scmOdDtAns)
                {
                    if (scmOdDtAns.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtAns.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtAns.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && scmOdDtAns.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && scmOdDtAns.InquiryNumber == inquiryNumber
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // 車両情報取得
            relatedSCMOdDtCar = scmOdDtCarList.Find(
                delegate(SCMAcOdrDtCarWork scmOdDtCar)
                {
                    if (scmOdDtCar.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtCar.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtCar.InquiryNumber == inquiryNumber
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            relatedScmAcOdrSetDtList = scmAcOdrSetDtList.FindAll(
                delegate(SCMAcOdSetDtWork scmAcOdSetDt)
                {
                    if (scmAcOdSetDt.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmAcOdSetDt.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmAcOdSetDt.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && scmAcOdSetDt.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && scmAcOdSetDt.InquiryNumber == inquiryNumber
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
        }
        //<<<2012/06/29

        /// <summary>
        /// SCM受発注データ(車両情報)に変換します。
        /// ※問合せ番号が<c>0</c>以外の場合、Web-DBよりSCM受発注データ(車両情報)をダウンロードし、
        /// ヘッダ情報を設定します。
        /// </summary>
        /// <param name="userCarRecord">SCM受注データ(車両情報)のレコード</param>
        /// <param name="userHeaderRecord">SCM受注データのレコード</param>
        /// <returns>
        /// ヘッダ情報付きSCM受発注データ(車両情報) ※問合せ番号が<c>0</c>の場合、ヘッダ情報は未設定
        /// </returns>
        private WebCarRecordType ConvertWebCarRecordIf(
            UserSCMOrderCarRecord userCarRecord,
            UserSCMOrderHeaderRecord userHeaderRecord
        )
        {
            WebCarRecordType webCarRecord = userCarRecord.CopyToWebSCMOrderCarRecord().RealRecord;
            {
                if (webCarRecord.InquiryNumber.Equals(0)) return webCarRecord;

                // ヘッダ情報を設定するため、Web-DBから再取得
                // 1パラ目
                ScmOdReadParam scmOdReadParam = new ScmOdReadParam();
                {
                    scmOdReadParam.InqOriginalEpCd  = webCarRecord.InqOriginalEpCd.Trim();//@@@@20230303
                    scmOdReadParam.InqOriginalSecCd = webCarRecord.InqOriginalSecCd;
                    scmOdReadParam.InqOtherEpCd     = userHeaderRecord.InqOtherEpCd;
                    scmOdReadParam.InqOtherSecCd    = userHeaderRecord.InqOtherSecCd;
                    //>>>2010/03/05
                    //scmOdReadParam.InquiryNumber    = webCarRecord.InquiryNumber;
                    scmOdReadParam.InquiryNumber    = webCarRecord.InquiryNumber;
                    //<<<2010/03/05
                    //scmOdReadParam.UpdateDate = DateTime.MinValue;
                    //scmOdReadParam.UpdateTime = 0;
                    scmOdReadParam.LatestDiscCode   = -1;   // 最新識別区分(-1:指定なし, 0:最新, 1:回答)
                    scmOdReadParam.InqOrdAnsDivCd   = 1;    // 問発・回答種別(1:問発, 2:回答)
                }

                #region 再取得済みの場合、キャッシュより設定

                string reaccessionKey = GetReaccessionKey(scmOdReadParam);
                if (WebCarReaccessionMap.ContainsKey(reaccessionKey))
                {
                    ScmOdDtCar webCar = FindScmOdDtCarFromCache(scmOdReadParam, userCarRecord);
                    if (webCar != null)
                    {
                        webCarRecord.CreateDateTime     = webCar.CreateDateTime;    // 作成日時
                        webCarRecord.UpdateDateTime     = webCar.UpdateDateTime;    // 更新日時
                        webCarRecord.LogicalDeleteCode  = webCar.LogicalDeleteCode; // 論理削除区分
                    }
                    return webCarRecord;
                }

                #endregion // 再取得済みの場合、キャッシュより設定

                // DEL 2013/01/28 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //#region 問発・回答種別：1:問発で取得

                //List<ScmOdrData> scmOdrDataList1 = null; // 2パラ目
                //List<ScmOdDtInq> scmOdDtInqList1 = null; // 3パラ目
                //List<ScmOdDtAns> scmOdDtAnsList1 = null; // 4パラ目
                //List<ScmOdDtCar> scmOdDtCarList1 = null; // 5パラ目
                //int status = RealAccesser.ReadWithCar(
                //    scmOdReadParam,
                //    out scmOdrDataList1,
                //    out scmOdDtInqList1,
                //    out scmOdDtAnsList1,
                //    out scmOdDtCarList1
                //);

                //// 何も取得されなければ、2:回答で再取得
                //if (IsNullOrEmptyList(scmOdDtCarList1))
                //{
                //    scmOdReadParam.InqOrdAnsDivCd = 2;  // 問発・回答種別(1:問発, 2:回答)
                //    status = RealAccesser.ReadWithCar(
                //        scmOdReadParam,
                //        out scmOdrDataList1,
                //        out scmOdDtInqList1,
                //        out scmOdDtAnsList1,
                //        out scmOdDtCarList1
                //    );
                //}

                //#endregion // 問発・回答種別：1:問発で取得

                //#region 問発・回答種別：2:回答で取得

                //// 2:回答で検索していなければ、再検索
                //if (!scmOdReadParam.InqOrdAnsDivCd.Equals(2))
                //{
                //    // 1パラ目
                //    scmOdReadParam.InqOrdAnsDivCd = 2;  // 問発・回答種別(1:問発, 2:回答)

                //    List<ScmOdrData> scmOdrDataList2 = null; // 2パラ目
                //    List<ScmOdDtInq> scmOdDtInqList2 = null; // 3パラ目
                //    List<ScmOdDtAns> scmOdDtAnsList2 = null; // 4パラ目
                //    List<ScmOdDtCar> scmOdDtCarList2 = null; // 5パラ目

                //    status = RealAccesser.ReadWithCar(
                //        scmOdReadParam,
                //        out scmOdrDataList2,
                //        out scmOdDtInqList2,
                //        out scmOdDtAnsList2,
                //        out scmOdDtCarList2
                //    );
                //    // scmOdDtCarList1に統合
                //    if (!IsNullOrEmptyList(scmOdDtCarList2))
                //    {
                //        if (scmOdDtCarList1 == null)
                //        {
                //            scmOdDtCarList1 = scmOdDtCarList2;
                //        }
                //        else
                //        {
                //            scmOdDtCarList1.AddRange(scmOdDtCarList2);
                //        }
                //    }
                //}

                //#endregion // 問発・回答種別：2:回答で取得
                #endregion 旧ソース
                // DEL 2013/01/28 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // ADD 2013/01/28 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                SimpleLogger.WriteDebugLog(MY_NAME, "ConvertWebCarRecordIf", "start RealAccesser.ReadWithCar");
                List<ScmOdReadParam> scmOdReadParamList = new List<ScmOdReadParam>();
                scmOdReadParamList.Add(scmOdReadParam.Clone());
                scmOdReadParam.InqOrdAnsDivCd = 2;  // 問発・回答種別(1:問発, 2:回答)
                scmOdReadParamList.Add(scmOdReadParam.Clone());

                List<ScmOdrData> scmOdrDataList1 = null; // 2パラ目
                List<ScmOdDtInq> scmOdDtInqList1 = null; // 3パラ目
                List<ScmOdDtAns> scmOdDtAnsList1 = null; // 4パラ目
                List<ScmOdDtCar> scmOdDtCarList1 = null; // 5パラ目
                int status = RealAccesser.ReadWithCar(
                    scmOdReadParamList,
                    out scmOdrDataList1,
                    out scmOdDtInqList1,
                    out scmOdDtAnsList1,
                    out scmOdDtCarList1
                );
                SimpleLogger.WriteDebugLog(MY_NAME, "ConvertWebCarRecordIf", "end RealAccesser.ReadWithCar");
                // ADD 2013/01/28 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // 問合せ番号を検索
                if (!IsNullOrEmptyList(scmOdDtCarList1))
                {
                    // 検索結果を保持
                    WebCarReaccessionMap.Add(reaccessionKey, scmOdDtCarList1);

                    ScmOdDtCar webCar = FindScmOdDtCarFromCache(scmOdReadParam, userCarRecord);
                    if (webCar != null)
                    {
                        webCarRecord.CreateDateTime = webCar.CreateDateTime;        // 作成日時
                        webCarRecord.UpdateDateTime = webCar.UpdateDateTime;        // 更新日時
                        webCarRecord.LogicalDeleteCode = webCar.LogicalDeleteCode;  // 論理削除区分
                    }

                    return webCarRecord;
                }
                else
                {
                    StringBuilder msg = new StringBuilder();
                    {
                        msg.Append("Web-DBアクセス(ReadWithCar())に失敗？：status=").Append(status);
                        msg.Append(Environment.NewLine).Append("問合せ番号=").Append(scmOdReadParam.InquiryNumber);
                    }

                    Debug.Assert(false, msg.ToString());
                }
            }
            return webCarRecord;
        }

        // 2011/02/16 Add >>>
        /// <summary>
        /// 明細取込区分の更新を行います
        /// </summary>
        /// <param name="header"></param>
        /// <param name="detailList"></param>
        /// <returns></returns>
        public int UpdateInqDtlTakeinDiv(ISCMOrderHeaderRecord header, List<ISCMOrderDetailRecord> detailList)
        {
            const string METHOD_NAME = "UpdateInqDtlTakeinDiv()"; // ログ用

            ScmOdReadParam para = new ScmOdReadParam();
            para.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
            para.InqOriginalSecCd = header.InqOriginalSecCd;
            para.InqOtherEpCd = header.InqOtherEpCd;
            para.InqOtherSecCd = header.InqOtherSecCd;
            para.InquiryNumber = header.InquiryNumber;
            //para.InqOrdAnsDivCd = 1;  // 問発・回答種別 1:問発 
            para.InqOrdAnsDivCd = -1;  // 問発・回答種別 1:問発 
            para.LatestDiscCode = 0;      // 最新識別区分 0:最新

            List<ScmOdrData> scmOdrDataList;
            List<ScmOdDtInq> scmOdDtInqList;
            List<ScmOdDtAns> scmOdDtAnsList;
            List<ScmOdDtCar> scmOdDtCarList;
            List<ScmOdDtInq> updateDtInqList;

            int status = RealAccesser.ReadWithCar(para, out scmOdrDataList, out scmOdDtInqList, out scmOdDtAnsList, out scmOdDtCarList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                bool check = true;
                updateDtInqList = new List<ScmOdDtInq>();
                foreach (ISCMOrderDetailRecord userInq in detailList)
                {
                    // 対応する明細を探す（更新日時までチェック）
                    ScmOdDtInq webInq = scmOdDtInqList.Find(
                        delegate(ScmOdDtInq inq)
                        {
                            return ( ( inq.InqRowNumber.Equals(userInq.InqRowNumber) ) &&
                                     ( inq.InqRowNumDerivedNo.Equals(userInq.InqRowNumDerivedNo) ) &&
                                     ( inq.InqOrdDivCd.Equals(userInq.InqOrdDivCd) ) &&
                                     ( inq.UpdateDate.Equals(userInq.UpdateDate) ) &&
                                     ( inq.UpdateTime.Equals(userInq.UpdateTime) )
                                    );
                        });
                    // 明細が無い（もしくは更新されている）場合は、エラー
                    if (webInq == null)
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        // 伝票修正時にロックがかかったままなのでチェックしない
                        //// 明細が既に取込済みの場合はエラー
                        //if (webInq.DtlTakeinDivCd == 1)
                        //{
                        //    check = false;
                        //    break;
                        //}
                        // 明細取込区分を1にして、更新リストに追加
                        webInq.DtlTakeinDivCd = 1;
                        updateDtInqList.Add(webInq);
                    }
                }

                // 明細が更新されているかもしれない（ＰＭ側は車両で排他チェックできない）
                // UPD 2012/12/27 2013/03/13配信 SCM障害№10378対応 --------------------------------------->>>>>
                //if (!check) return (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                if (!check)
                {
                    // エラー時ログ出力
                    #region <Log>

                    StringBuilder dataCSV = new StringBuilder();
                    {
                        dataCSV.Append("SCM_DBで該当する明細が見つかりませんでした（他端末による更新済）ステータス：").Append(ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE.ToString()).Append(Environment.NewLine);
                    }
                    SimpleLogger.Write(MY_NAME, METHOD_NAME, dataCSV.ToString());

                    #endregion // </Log>

                    return (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                // UPD 2012/12/27 2013/03/13配信 SCM障害№10378対応 ---------------------------------------<<<<<

                status = RealAccesser.UpdateInqDtlTakeinDivCd(scmOdDtCarList[0], ref updateDtInqList);

                // ADD 2012/12/27 2013/03/13配信 SCM障害№10378対応 --------------------------------------->>>>>
                // エラー時ログ出力
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    #region <Log>
                    StringBuilder dataCSV = new StringBuilder();
                    {
                        dataCSV.Append("SCM_DBのデータ更新時にエラーが発生しました。ステータス：").Append(status.ToString()).Append(Environment.NewLine);
                        dataCSV.Append("[パラメータ]").Append(Environment.NewLine);
                        dataCSV.Append("[SCM受発注データ(車両情報)]").Append(Environment.NewLine);
                        dataCSV.Append(MsgUtil.ConvertCSV(scmOdDtCarList[0])).Append(Environment.NewLine);
                        dataCSV.Append("[SCM受発注明細データ(問合せ・発注)]").Append(Environment.NewLine);
                        dataCSV.Append(MsgUtil.ConvertCSV(updateDtInqList)).Append(Environment.NewLine);
                    }
                    SimpleLogger.Write(MY_NAME, METHOD_NAME, dataCSV.ToString());
                    #endregion // </Log>
                }
                // ADD 2012/12/27 2013/03/13配信 SCM障害№10378対応 ---------------------------------------<<<<<
            }
            // ADD 2012/12/27 2013/03/13配信 SCM障害№10378対応 --------------------------------------->>>>>
            else
            {
                // エラー時ログ出力
                #region <Log>

                StringBuilder dataCSV = new StringBuilder();
                {
                    dataCSV.Append("SCM_DBのデータ取得時にエラーが発生しました。ステータス：").Append(status.ToString()).Append(Environment.NewLine);
                    dataCSV.Append("[パラメータ]").Append(Environment.NewLine);
                    dataCSV.Append("問合せ元企業コード=").Append(para.InqOriginalEpCd.Trim()).Append(Environment.NewLine);//@@@@20230303
                    dataCSV.Append("問合せ元拠点コード=").Append(para.InqOriginalSecCd).Append(Environment.NewLine);
                    dataCSV.Append("問合せ先企業コード=").Append(para.InqOtherEpCd).Append(Environment.NewLine);
                    dataCSV.Append("問合せ先拠点コード=").Append(para.InqOtherSecCd).Append(Environment.NewLine);
                    dataCSV.Append("問合せ番号=").Append(para.InquiryNumber.ToString()).Append(Environment.NewLine);
                    dataCSV.Append("問発・回答種別=").Append(para.InqOrdAnsDivCd.ToString()).Append(Environment.NewLine);
                    dataCSV.Append("最新識別区分=").Append(para.LatestDiscCode.ToString()).Append(Environment.NewLine);
                }
                SimpleLogger.Write(MY_NAME, METHOD_NAME, dataCSV.ToString());

                #endregion // </Log>
            }
            // ADD 2012/12/27 2013/03/13配信 SCM障害№10378対応 ---------------------------------------<<<<<

            return status;
        }
        // 2011/02/16 Add <<<

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№14.明細取込区分の更新方法を改良対応 ---------------------------------->>>>>
        /// <summary>
        /// 明細取込区分の更新を行います（自動回答専用）
        /// </summary>
        /// <param name="header"></param>
        /// <param name="detailList"></param>
        /// <returns></returns>
        public int UpdateInqDtlTakeinDiv(ISCMOrderHeaderRecord header, List<ISCMOrderDetailRecord> detailList, List<ScmOdDtInq> scmOdDtInqList, List<ScmOdDtCar> scmOdDtCarList)
        {
            const string METHOD_NAME = "UpdateInqDtlTakeinDiv()"; // ログ用

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            bool check = true;
            List<ScmOdDtInq> updateDtInqList = new List<ScmOdDtInq>();
            foreach (ISCMOrderDetailRecord userInq in detailList)
            {
                // 対応する明細を探す（更新日時までチェック）
                ScmOdDtInq webInq = scmOdDtInqList.Find(
                    delegate(ScmOdDtInq inq)
                    {
                        return ((inq.InqRowNumber.Equals(userInq.InqRowNumber)) &&
                                 (inq.InqRowNumDerivedNo.Equals(userInq.InqRowNumDerivedNo)) &&
                                 (inq.InqOrdDivCd.Equals(userInq.InqOrdDivCd)) &&
                                 (inq.UpdateDate.Equals(userInq.UpdateDate)) &&
                                 (inq.UpdateTime.Equals(userInq.UpdateTime))
                                );
                    });
                // 明細が無い（もしくは更新されている）場合は、エラー
                if (webInq == null)
                {
                    check = false;
                    break;
                }
                else
                {
                    // 明細取込区分を1にして、更新リストに追加
                    webInq.DtlTakeinDivCd = 1;
                    updateDtInqList.Add(webInq);
                }
            }

            // ADD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 ---------------------------------->>>>>
            List<ScmOdDtCar> updateDtCarList = new List<ScmOdDtCar>();
            // 対応する明細を探す
            updateDtCarList = scmOdDtCarList.FindAll(
                delegate(ScmOdDtCar car)
                {
                    return ((car.InqOriginalEpCd.Trim().Equals(header.InqOriginalEpCd.Trim())) && //@@@@20230303
                             (car.InqOriginalSecCd.Equals(header.InqOriginalSecCd)) &&
                             (car.InquiryNumber.Equals(header.InquiryNumber))
                            );
                });
            // ADD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 ----------------------------------<<<<<

            // 該当明細がない場合はSCM-DBから再読み込み
            if (!check)
            {
                ScmOdReadParam para = new ScmOdReadParam();
                para.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
                para.InqOriginalSecCd = header.InqOriginalSecCd;
                para.InqOtherEpCd = header.InqOtherEpCd;
                para.InqOtherSecCd = header.InqOtherSecCd;
                para.InquiryNumber = header.InquiryNumber;
                //para.InqOrdAnsDivCd = 1;  // 問発・回答種別 1:問発 
                para.InqOrdAnsDivCd = -1;  // 問発・回答種別 1:問発 
                para.LatestDiscCode = 0;      // 最新識別区分 0:最新

                List<ScmOdrData> scmOdrDataListWork;
                List<ScmOdDtInq> scmOdDtInqListWork;
                List<ScmOdDtAns> scmOdDtAnsListWork;
                List<ScmOdDtCar> scmOdDtCarListWork;

                status = RealAccesser.ReadWithCar(para, out scmOdrDataListWork, out scmOdDtInqListWork, out scmOdDtAnsListWork, out scmOdDtCarListWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    updateDtInqList.Clear();
                    check = true;
                    foreach (ISCMOrderDetailRecord userInq in detailList)
                    {
                        // 対応する明細を探す（更新日時までチェック）
                        ScmOdDtInq webInq = scmOdDtInqListWork.Find(
                            delegate(ScmOdDtInq inq)
                            {
                                return ((inq.InqRowNumber.Equals(userInq.InqRowNumber)) &&
                                         (inq.InqRowNumDerivedNo.Equals(userInq.InqRowNumDerivedNo)) &&
                                         (inq.InqOrdDivCd.Equals(userInq.InqOrdDivCd)) &&
                                         (inq.UpdateDate.Equals(userInq.UpdateDate)) &&
                                         (inq.UpdateTime.Equals(userInq.UpdateTime))
                                        );
                            });
                        // 明細が無い（もしくは更新されている）場合は、エラー
                        if (webInq == null)
                        {
                            check = false;
                            break;
                        }
                        else
                        {
                            // 明細取込区分を1にして、更新リストに追加
                            webInq.DtlTakeinDivCd = 1;
                            updateDtInqList.Add(webInq);
                        }
                    }
                    // UPD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 ---------------------------------->>>>>
                    //scmOdDtCarList.Clear();
                    //scmOdDtCarList = scmOdDtCarListWork;
                    updateDtCarList.Clear();
                    updateDtCarList.AddRange(scmOdDtCarListWork);
                    // UPD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 ----------------------------------<<<<<
                }
                else
                {
                    // エラー時ログ出力
                    #region <Log>

                    StringBuilder dataCSV = new StringBuilder();
                    {
                        dataCSV.Append("SCM_DBのデータ取得時にエラーが発生しました。ステータス：").Append(status.ToString()).Append(Environment.NewLine);
                        dataCSV.Append("[パラメータ]").Append(Environment.NewLine);
                        dataCSV.Append("問合せ元企業コード=").Append(para.InqOriginalEpCd.Trim()).Append(Environment.NewLine);//@@@@20230303
                        dataCSV.Append("問合せ元拠点コード=").Append(para.InqOriginalSecCd).Append(Environment.NewLine);
                        dataCSV.Append("問合せ先企業コード=").Append(para.InqOtherEpCd).Append(Environment.NewLine);
                        dataCSV.Append("問合せ先拠点コード=").Append(para.InqOtherSecCd).Append(Environment.NewLine);
                        dataCSV.Append("問合せ番号=").Append(para.InquiryNumber.ToString()).Append(Environment.NewLine);
                        dataCSV.Append("問発・回答種別=").Append(para.InqOrdAnsDivCd.ToString()).Append(Environment.NewLine);
                        dataCSV.Append("最新識別区分=").Append(para.LatestDiscCode.ToString()).Append(Environment.NewLine);
                    }
                    SimpleLogger.Write(MY_NAME, METHOD_NAME, dataCSV.ToString());

                    #endregion // </Log>
                }
            }

            if (!check)
            {
                // エラー時ログ出力
                #region <Log>

                StringBuilder dataCSV = new StringBuilder();
                {
                    dataCSV.Append("SCM_DBで該当する明細が見つかりませんでした（他端末による更新済）ステータス：").Append(ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE.ToString()).Append(Environment.NewLine);
                }
                SimpleLogger.Write(MY_NAME, METHOD_NAME, dataCSV.ToString());

                #endregion // </Log>

                return (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
            }

            // UPD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 ---------------------------------->>>>>
            //status = RealAccesser.UpdateInqDtlTakeinDivCd(scmOdDtCarList[0], ref updateDtInqList);
            status = RealAccesser.UpdateInqDtlTakeinDivCd(updateDtCarList[0], ref updateDtInqList);
            // UPD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 ----------------------------------<<<<<

            // エラー時ログ出力
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                #region <Log>
                StringBuilder dataCSV = new StringBuilder();
                {
                    dataCSV.Append("SCM_DBのデータ更新時にエラーが発生しました。ステータス：").Append(status.ToString()).Append(Environment.NewLine);
                    dataCSV.Append("[パラメータ]").Append(Environment.NewLine);
                    dataCSV.Append("[SCM受発注データ(車両情報)]").Append(Environment.NewLine);
                    dataCSV.Append(MsgUtil.ConvertCSV(scmOdDtCarList[0])).Append(Environment.NewLine);
                    dataCSV.Append("[SCM受発注明細データ(問合せ・発注)]").Append(Environment.NewLine);
                    dataCSV.Append(MsgUtil.ConvertCSV(updateDtInqList)).Append(Environment.NewLine);
                }
                SimpleLogger.Write(MY_NAME, METHOD_NAME, dataCSV.ToString());
                #endregion // </Log>
            }

            return status;
        }
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№14.明細取込区分の更新方法を改良対応 ----------------------------------<<<<<

        //>>>2011/05/25
        /// <summary>
        /// 受発注データ確定済チェック処理
        /// </summary>
        /// <param name="header"></param>
        /// <param name="isFixed"></param>
        /// <returns></returns>
        public int CheckScmOdrDataFixed(ISCMOrderHeaderRecord header, out bool isFixed)
        {
            const string METHOD_NAME = "CheckScmOdrDataFixed()"; // ログ用
            isFixed = false;
            ScmOdReadParam para = new ScmOdReadParam();
            para.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
            para.InqOriginalSecCd = header.InqOriginalSecCd;
            para.InqOtherEpCd = header.InqOtherEpCd;
            para.InqOtherSecCd = header.InqOtherSecCd;
            para.InquiryNumber = header.InquiryNumber;
            para.InqOrdAnsDivCd = -1;  // 問発・回答種別 1:問発 
            para.LatestDiscCode = 0;      // 最新識別区分 0:最新

            List<ScmOdrData> scmOdrDataList;
            List<ScmOdDtInq> scmOdDtInqList;
            List<ScmOdDtAns> scmOdDtAnsList;
            List<ScmOdDtCar> scmOdDtCarList;
            List<ScmOdDtInq> updateDtInqList;

            int status = RealAccesser.ReadWithCar(para, out scmOdrDataList, out scmOdDtInqList, out scmOdDtAnsList, out scmOdDtCarList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if ((scmOdrDataList != null) || (scmOdrDataList.Count != 0))
                {
                    status = RealAccesser.CheckScmOdrDataFixed(scmOdrDataList[0], out isFixed);
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            return status;
        }
        //<<<2011/05/25

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２対応 14.明細取込区分の更新方法を改良対応 ---------------------------------->>>>>
        /// <summary>
        /// 受発注データ確定済チェック処理
        /// </summary>
        /// <param name="header"></param>
        /// <param name="isFixed"></param>
        /// <returns></returns>
        // UPD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 ----------------------------------------------------------->>>>>
        #region 削除
        //public int CheckScmOdrDataFixed(ISCMOrderHeaderRecord header, out bool isFixed, out List<ScmOdDtInq> scmOdDtInqList, out List<ScmOdDtCar> scmOdDtCarList)
        //{
        //    const string METHOD_NAME = "CheckScmOdrDataFixed()"; // ログ用
        //    isFixed = false;
        //    ScmOdReadParam para = new ScmOdReadParam();
        //    para.InqOriginalEpCd = header.InqOriginalEpCd;
        //    para.InqOriginalSecCd = header.InqOriginalSecCd;
        //    para.InqOtherEpCd = header.InqOtherEpCd;
        //    para.InqOtherSecCd = header.InqOtherSecCd;
        //    para.InquiryNumber = header.InquiryNumber;
        //    para.InqOrdAnsDivCd = -1;  // 問発・回答種別 1:問発 
        //    para.LatestDiscCode = 0;      // 最新識別区分 0:最新
        //    List<ScmOdrData> scmOdrDataList;
        //    //List<ScmOdDtInq> scmOdDtInqList; // 戻り値として使用のため除外
        //    List<ScmOdDtAns> scmOdDtAnsList;
        //    //List<ScmOdDtCar> scmOdDtCarList; // 戻り値として使用のため除外
        //    List<ScmOdDtInq> updateDtInqList;

        //    int status = RealAccesser.ReadWithCar(para, out scmOdrDataList, out scmOdDtInqList, out scmOdDtAnsList, out scmOdDtCarList);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        if ((scmOdrDataList != null) || (scmOdrDataList.Count != 0))
        //        {
        //            status = RealAccesser.CheckScmOdrDataFixed(scmOdrDataList[0], out isFixed);
        //        }
        //        else
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        }
        //    }
        //    return status;
        //}
        #endregion
        public int CheckScmOdrDataFixed(List<ISCMOrderHeaderRecord> headerList, out bool isFixed, out List<ScmOdDtInq> retSCMOdDtInqList, out List<ScmOdDtCar> retSCMOdDtCarList)
        {
            const string METHOD_NAME = "CheckScmOdrDataFixed()"; // ログ用
            isFixed = false;

            retSCMOdDtInqList = new List<ScmOdDtInq>();
            retSCMOdDtCarList = new List<ScmOdDtCar>();

            // ヘッダーリストがない場合エラー
            if (headerList == null || headerList.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            foreach (ISCMOrderHeaderRecord header in headerList)
            {
                ScmOdReadParam para = new ScmOdReadParam();
                para.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
                para.InqOriginalSecCd = header.InqOriginalSecCd;
                para.InqOtherEpCd = header.InqOtherEpCd;
                para.InqOtherSecCd = header.InqOtherSecCd;
                para.InquiryNumber = header.InquiryNumber;
                para.InqOrdAnsDivCd = -1;  // 問発・回答種別 1:問発 
                para.LatestDiscCode = 0;      // 最新識別区分 0:最新
                List<ScmOdrData> scmOdrDataList;
                List<ScmOdDtInq> scmOdDtInqList;
                List<ScmOdDtAns> scmOdDtAnsList;
                List<ScmOdDtCar> scmOdDtCarList;
                List<ScmOdDtInq> updateDtInqList;

                status = RealAccesser.ReadWithCar(para, out scmOdrDataList, out scmOdDtInqList, out scmOdDtAnsList, out scmOdDtCarList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (scmOdrDataList != null && scmOdrDataList.Count != 0)
                    {
                        status = RealAccesser.CheckScmOdrDataFixed(scmOdrDataList[0], out isFixed);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        break;
                    }
                    // 問合せデータ、車両情報データ存在時、戻り値に追加
                    if (scmOdDtCarList != null && scmOdDtCarList.Count != 0)
                    {
                        retSCMOdDtCarList.AddRange(scmOdDtCarList);
                    }
                    if (scmOdDtInqList != null && scmOdDtInqList.Count != 0)
                    {
                        retSCMOdDtInqList.AddRange(scmOdDtInqList);
                    }
                }
                // 1件でも読込エラー時は処理終了
                else
                {
                    break;
                }
            }
            return status;
        }
        // UPD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 -----------------------------------------------------------<<<<<
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２対応 14.明細取込区分の更新方法を改良対応 ----------------------------------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        private static bool IsNullOrEmptyList<T>(IList<T> list) where T : class
        {
            return list == null || list.Count.Equals(0);
        }

        #region <Web-DBの再取得結果のキャッシュ>

        /// <summary>SCM受発注データ(車両情報)のWeb-DB再取得マップ</summary>
        private IDictionary<string, List<ScmOdDtCar>> _webCarReaccessionMap;
        /// <summary>SCM受発注データ(車両情報)のWeb-DB再取得マップを取得します。</summary>
        private IDictionary<string, List<ScmOdDtCar>> WebCarReaccessionMap
        {
            get
            {
                if (_webCarReaccessionMap == null)
                {
                    _webCarReaccessionMap = new Dictionary<string, List<ScmOdDtCar>>();
                }
                return _webCarReaccessionMap;
            }
        }

        /// <summary>
        /// SCM受発注データ(車両情報)を検索します。
        /// </summary>
        /// <param name="scmOdReadParam"></param>
        /// <param name="userCarRecord"></param>
        /// <returns></returns>
        private ScmOdDtCar FindScmOdDtCarFromCache(
            ScmOdReadParam scmOdReadParam,
            UserSCMOrderCarRecord userCarRecord
        )
        {
            string key = GetReaccessionKey(scmOdReadParam);
            if (WebCarReaccessionMap.ContainsKey(key))
            {
                foreach (ScmOdDtCar webCar in WebCarReaccessionMap[key])
                {
                    Debug.WriteLine("問合せ番号=" + webCar.InquiryNumber.ToString());
                    if (webCar.InquiryNumber.Equals(userCarRecord.InquiryNumber))
                    {
                        return webCar;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 再取得キーを取得します。
        /// </summary>
        /// <param name="scmOdReadParam">Web-DBアクセスパラメータ</param>
        /// <returns>scmOdReadParam.InqOtherEpCd + scmOdReadParam.InquiryNumber.ToString("0000000000")</returns>
        private static string GetReaccessionKey(ScmOdReadParam scmOdReadParam)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(SCMEntityUtil.FormatEnterpriseCode(scmOdReadParam.InqOriginalEpCd.Trim()));	//@@@@20230303
                key.Append(SCMEntityUtil.FormatSectionCode(scmOdReadParam.InqOriginalSecCd));
                key.Append(SCMEntityUtil.FormatEnterpriseCode(scmOdReadParam.InqOtherEpCd));
                key.Append(SCMEntityUtil.FormatSectionCode(scmOdReadParam.InqOtherSecCd));
            }
            return key.ToString();
        }

        #endregion // </Web-DBの再取得結果のキャッシュ>

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ---------------------------------->>>>>
        /// <summary>
        /// SCM受発注データ(車両情報)をキャッシュします（自動回答処理専用）
        /// </summary>
        /// <param name="userCarRecord">SCM受注データ(車両情報)のレコード</param>
        /// <param name="userHeaderRecord">SCM受注データのレコード</param>
        /// <returns>
        /// ヘッダ情報付きSCM受発注データ(車両情報) ※問合せ番号が<c>0</c>の場合、ヘッダ情報は未設定
        /// </returns>
        public void SetWebCarReaccessionMap(
            List<ScmOdDtCar> scmOdDtCarList,
            ISCMOrderHeaderRecord headerRecord
        )
        {
            ScmOdReadParam scmOdReadParam = new ScmOdReadParam();
            scmOdReadParam.InqOriginalEpCd = scmOdDtCarList[0].InqOriginalEpCd.Trim();//@@@@20230303
            scmOdReadParam.InqOriginalSecCd = scmOdDtCarList[0].InqOriginalSecCd;
            scmOdReadParam.InqOtherEpCd = headerRecord.InqOtherEpCd;
            scmOdReadParam.InqOtherSecCd = headerRecord.InqOtherSecCd;

            // キャッシュアクセス用キー生成
            string reaccessionKey = GetReaccessionKey(scmOdReadParam);
            // キャッシュ存在チェック
            if (!WebCarReaccessionMap.ContainsKey(reaccessionKey))
            {
                WebCarReaccessionMap.Add(reaccessionKey, scmOdDtCarList);
            }

            return;
        }
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ----------------------------------<<<<<
    }
}
