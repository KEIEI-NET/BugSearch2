//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCMポップアップ
// プログラム概要   : ポップアップ処理の操作を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/01  修正内容 : 新着取得方法の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/02  修正内容 : 新着件数が累積される不具合の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/19  修正内容 : 新着通知と受渡データの変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/28  修正内容 : 新着データ取得リモートのパラメータに日付を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/12/27  修正内容 : ポップアップのキャンセル処理対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/18  修正内容 : キャンセルデータの仕様変更対応
//                                 返品拒否データをサーバーに送信するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/25  修正内容 : 返品拒否データ保存時、回答作成区分に2:手動(その他)をセットする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/02/26  修正内容 : 2013/03/06配信予定 redmine34863対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/04/19  修正内容 : 2013/05/22配信予定 SCM障害№10521対応 車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/06/24  修正内容 : タブレット対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : 2013/06/18配信　SCM障害№10384対応 入庫予定日追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/24  修正内容 : 2013/06/18配信 SCM障害№10537対応 車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/06/10  修正内容 : 2013/06/18配信分 システムテスト障害№32対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/07/22  修正内容 : SFの返品要求に対して、PMからキャンセルデータが来た場合、
//                                  SF-PM連携指示書番号が空白になる障害の対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/10/18  修正内容 : 2013/06/18配信 システムテスト障害対応 №84、94
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/12/02  修正内容 : 商品保証部Redmine#783対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応 自動回答方式の追加
//----------------------------------------------------------------------------//
// 管理番号　11170130-00 作成担当 : 譚洪
// 修正日    2015/08/28    修正内容：Redmine#47284 SCM仕掛一覧№10722対応
//                         前回受信日時を保管するファイルが破損防止対応（PMのユーザーDBにデータを登録する機能となる）
// ---------------------------------------------------------------------------//
// 管理番号 11275206-00  作成担当 : 陳艶丹
// 作 成 日  2016/09/18  修正内容 : SCM高負荷クエリの対応
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Messenger;
using Broadleaf.Application.Controller.NetworkConfig;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

using Broadleaf.Library.Globarization;  // 2010/12/27 Add

#if DEBUG
// ダミー参照
//using SCMAcOdrData = Broadleaf.Application.UIData.StubDB.SCMAcOdrData;
//using SCMAcOdrDtlIq = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlIq;
//using SCMAcOdrDtlAs = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlAs;
//using SCMAcOdrDtCar = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtCar;
using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;

#else
    using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
    using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
    using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
#endif

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCMポップアップアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: ポップアップ受信処理の操作を行います。</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/05/21</br>
    /// </remarks>
    public sealed class SCMTerminal : ISCMTerminal
    {
        #region <ISCMTerminal メンバ>

        #region <メッセージ受信者>

        /// <summary>メッセージ受信者</summary>
        private ITextMessageReceivable _messageReceiver;
        /// <summary>メッセージ受信者を取得します。</summary>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        /// <see cref="ISCMTerminal"/>
        public ITextMessageReceivable MessageReceiver
        {
            get
            {
                #region <Guard Phrase>

                if (Disposed) throw new ObjectDisposedException("This is disposed.");

                #endregion // </Guard Phrase>

                if (_messageReceiver == null)
                {
                    INetworkConfig iNetworkConfig = NetworkConfigFactory.Create(NetworkConfigType.Default);

                    ((DefaultNetworkConfig)iNetworkConfig).GetLocalIPAddressInfo(this._portNumber);

                    IIterator<INetworkConfig> iter = iNetworkConfig.CreateIterator();

                    // 自端末かつ1LAN環境なので実質一つ。
                    if (iter.HasNext())
                    {
                        INetworkConfig config = iter.GetNext();

                        _messageReceiver = MessengerFactory.CreateTextReceiver(
                        ProtcolType.TCP,
                        config
                        );

                        // 自端末のIPアドレスを保持
                        this._localIPAddress = config.IPAddress.ToString();

                        _messageReceiver.Received += new ReceivedEventHandler(SetReceivedMessage);
                    }
                }
                return _messageReceiver;
            }
        }

        #endregion // </メッセージ受信者>

        /// <summary>
        /// 受信を開始します。
        /// </summary>
        /// <returns>結果コード</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        /// <see cref="ISCMTerminal"/>
        public int StartReceiving()
        {
            #region <Guard Phrase>

            if (Disposed) throw new ObjectDisposedException("This is disposed.");

            #endregion // </Guard Phrase>

            MessageReceiver.StartReceiving();
            return (int)Result.Code.Normal;
        }

        // 2010/04/19 Del >>>
#if False
        /// <summary>
        /// 新着件数を取得します。
        /// </summary>
        /// <returns>新着件数</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        /// <see cref="ISCMTerminal"/>
        public int GetNewOrderCount()
        {
            const string AUTHOR = "ポップアップ";   // ログ用
            const string TAB = "\t";                // ログ用
            const string COMMA = ", ";              // ログ用

            #region <Guard Phrase>

            if (Disposed) throw new ObjectDisposedException("This is disposed.");

            #endregion // </Guard Phrase>

            // 新着件数取得処理
            IOWriteSCMReadWork scmReadWork = new IOWriteSCMReadWork();
            scmReadWork.EnterpriseCode = this._enterpriseCd;
            scmReadWork.InqOtherSecCd = this._sectionCd;
            // 2010/03/01 Del >>>
            //Int32[] answerDivCdList = new Int32[2] { 0, 10 };
            //scmReadWork.AnswerDivCds = answerDivCdList; // 未回答と一部回答
            // 2010/03/01 Del <<<

            #region <Log>

            StringBuilder before = new StringBuilder();
            {
                before.Append("新着件数を取得します。IIOWriteScmDB.ScmSearch(ref object, object)").Append(Environment.NewLine);
                before.Append(TAB).Append("企業コード：[").Append(scmReadWork.EnterpriseCode).Append("]").Append(Environment.NewLine);
                before.Append(TAB).Append("拠点コード：[").Append(scmReadWork.InqOtherSecCd).Append("]").Append(Environment.NewLine);
                //before.Append(TAB).Append("回答区分：[").Append(scmReadWork.AnswerDivCds[0]).Append(COMMA).Append(scmReadWork.AnswerDivCds[1]).Append("]"); // 2010/03/01 Del
            }
            LogWriter.WriteDebugLog(AUTHOR, before.ToString());

            #endregion // </Log>

            // 2010/03/01 >>>
            //object retSCMScObj = new CustomSerializeArrayList();

            //int status = this._iIOWriteScmDB.ScmSearch(ref retSCMScObj, (object)scmReadWork);

            object retSCMScObj = null;

            int status = this._iIOWriteScmDB.GetOrderNewCount(out retSCMScObj, (object)scmReadWork);

            if (retSCMScObj != null && ( retSCMScObj as CustomSerializeArrayList ).Count == 0)
            {
                retSCMScObj = null;
            }
            // 2010/03/01 <<<
            
            #region <Log>

            StringBuilder after = new StringBuilder();
            {
                after.Append("検索結果(ステータス：").Append(status).Append(")").Append(Environment.NewLine);
                after.Append(TAB).Append("件数：((CustomSerializeArrayList)retSCMScObj).Count=");
                if (retSCMScObj != null)
                {
                    after.Append(((CustomSerializeArrayList)retSCMScObj).Count);
                }
            }
            LogWriter.WriteDebugLog(AUTHOR, after.ToString());

            #endregion // </Log>

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retSCMScObj != null)
            {
                return SCMSearchedResultHelper.GetCountOfToday(retSCMScObj);
                //return ((CustomSerializeArrayList)retSCMScObj).Count;
            }
            else
            {
                return 0;
            }
        }
#endif
        // 2010/04/19 Del <<<

        // 2010/03/02 Add >>>
        /// <summary>
        /// 新着件数を取得します。
        /// </summary>
        /// <returns>新着件数</returns>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        /// <see cref="ISCMTerminal"/>
        // 2010/04/19 >>>
        //public object GetNewOrderList()
        public object GetNewOrderList(DateTime lastUpdateDate, int lastUpdateTime)
        // 2010/04/19 <<<
        {
            const string AUTHOR = "ポップアップ";   // ログ用
            const string TAB = "\t";                // ログ用
            const string COMMA = ", ";              // ログ用

            #region <Guard Phrase>

            if (Disposed) throw new ObjectDisposedException("This is disposed.");

            #endregion // </Guard Phrase>

            // 新着件数取得処理
            IOWriteSCMReadWork scmReadWork = new IOWriteSCMReadWork();
            scmReadWork.EnterpriseCode = this._enterpriseCd;
            scmReadWork.InqOtherSecCd = this._sectionCd;
            // 2010/04/28 Add >>>
            if (lastUpdateDate != DateTime.MinValue) scmReadWork.UpdateDateOver = lastUpdateDate;
            // 2010/04/28 Add <<<

            #region <Log>

            StringBuilder before = new StringBuilder();
            {
                before.Append("新着件数を取得します。IIOWriteScmDB.ScmSearch(ref object, object)").Append(Environment.NewLine);
                before.Append(TAB).Append("企業コード：[").Append(scmReadWork.EnterpriseCode).Append("]").Append(Environment.NewLine);
                before.Append(TAB).Append("拠点コード：[").Append(scmReadWork.InqOtherSecCd).Append("]").Append(Environment.NewLine);
            }
            LogWriter.WriteDebugLog(AUTHOR, before.ToString());

            #endregion // </Log>

            object retSCMScObj = null;

            int status = this._iIOWriteScmDB.GetOrderNewCount(out retSCMScObj, (object)scmReadWork);

            if (retSCMScObj != null && ( retSCMScObj as CustomSerializeArrayList ).Count == 0)
            {
                retSCMScObj = null;
            }

            #region <Log>

            StringBuilder after = new StringBuilder();
            {
                after.Append("検索結果(ステータス：").Append(status).Append(")").Append(Environment.NewLine);
                after.Append(TAB).Append("件数：((CustomSerializeArrayList)retSCMScObj).Count=");
                if (retSCMScObj != null)
                {
                    after.Append(( (CustomSerializeArrayList)retSCMScObj ).Count);
                }
            }
            LogWriter.WriteDebugLog(AUTHOR, after.ToString());

            #endregion // </Log>

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retSCMScObj != null)
            {
                return (object)SCMSearchedResultHelper.GetNewList(retSCMScObj, lastUpdateDate, lastUpdateTime);
            }
            else
            {
                return null;
            }
        }
        // 2010/03/02 Add <<<

        // 2010/12/27 Add >>>
        /// <summary>
        /// SCMデータの取得
        /// </summary>
        /// <param name="scmHeader"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int GetSCMData(object reardPara, out object scmHeader, out object scmCar, out object scmDtlList, out object scmAnsList)
        {
            const string AUTHOR = "ポップアップ";   // ログ用
            const string TAB = "\t";                // ログ用
            const string COMMA = ", ";              // ログ用

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            scmHeader = null;
            scmCar = null;
            scmDtlList = null;
            scmAnsList = null;

            if (reardPara == null || !( reardPara is ISCMOrderHeaderRecord )) return status;

            #region <Guard Phrase>

            if (Disposed) throw new ObjectDisposedException("This is disposed.");

            #endregion // </Guard Phrase>

            // データ取得
            IOWriteSCMReadWork scmReadWork = new IOWriteSCMReadWork();
            scmReadWork.EnterpriseCode = ( (ISCMOrderHeaderRecord)reardPara ).EnterpriseCode;
            scmReadWork.InqOtherSecCd = ( (ISCMOrderHeaderRecord)reardPara ).InqOtherSecCd;
            scmReadWork.InqOriginalEpCd = ( (ISCMOrderHeaderRecord)reardPara ).InqOriginalEpCd.Trim();//@@@@20230303
            scmReadWork.InqOriginalSecCd = ( (ISCMOrderHeaderRecord)reardPara ).InqOriginalSecCd;
            scmReadWork.InquiryNumber = ( (ISCMOrderHeaderRecord)reardPara ).InquiryNumber;
            // 2011/02/18 Add >>>
            //scmReadWork.AnswerDivCds = new int[] { ( (ISCMOrderHeaderRecord)reardPara ).AnswerDivCd };
            scmReadWork.CancelDivs = new short[] { ( (ISCMOrderHeaderRecord)reardPara ).CancelDiv };
            // 2011/02/18 Add <<<
            // ADD 2013/02/26 T.Yoshioka 2013/03/06配信予定 redmine34863 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (((ISCMOrderHeaderRecord)reardPara).CancelDiv.Equals((short)CancelDiv.ExistsCancel))
            {
                scmReadWork.InqOrdDivCd = ((ISCMOrderHeaderRecord)reardPara).InqOrdDivCd;
            }
            // ADD 2013/02/26 T.Yoshioka 2013/03/06配信予定 redmine34863 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            SCMAcOdrDataWork scmHeaderWork;
            SCMAcOdrDtCarWork scmCarWork;
            List<SCMAcOdrDtlIqWork> scmDetailWorkList = new List<SCMAcOdrDtlIqWork>();
            List<SCMAcOdrDtlAsWork> scmAnswerWorkList = new List<SCMAcOdrDtlAsWork>();

            status = this.ReadProc(scmReadWork, out scmHeaderWork, out scmCarWork, out scmDetailWorkList, out scmAnswerWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                UserSCMOrderHeaderRecord scmHeaderWk;
                UserSCMOrderCarRecord scmCarWk;
                List<UserSCMOrderAnswerRecord> scmAnswerListWk = new List<UserSCMOrderAnswerRecord>();
                List<UserSCMOrderDetailRecord> scmDetailListWk = new List<UserSCMOrderDetailRecord>();

                scmHeaderWk = new UserSCMOrderHeaderRecord(scmHeaderWork);
                scmCarWk = new UserSCMOrderCarRecord(scmCarWork);
                foreach (SCMAcOdrDtlIqWork iqWork in scmDetailWorkList) scmDetailListWk.Add(new UserSCMOrderDetailRecord(iqWork));
                foreach (SCMAcOdrDtlAsWork asWork in scmAnswerWorkList) scmAnswerListWk.Add(new UserSCMOrderAnswerRecord(asWork));

                scmHeader = (object)scmHeaderWk;
                scmCar = (object)scmCarWk;
                scmDtlList = (object)scmDetailListWk;
                scmAnsList = (object)scmAnswerListWk;
            }

            return status;
        }

        /// <summary>
        /// キャンセル承認処理
        /// </summary>
        /// <param name="writePara"></param>
        /// <param name="cancelCndtionDiv"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public int ReturnedGoodsApproval(object writePara, short cancelCndtionDiv, out string errorMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errorMsg=string.Empty;

            if (writePara == null || !( writePara is UserSCMOrderHeaderRecord )) return status;

            #region <Guard Phrase>

            if (Disposed) throw new ObjectDisposedException("This is disposed.");

            #endregion

            return this.ReturnedGoodsApprovalProc((UserSCMOrderHeaderRecord)writePara, cancelCndtionDiv, out errorMsg);
        }


        /// <summary>
        /// 年式表示文字列取得処理
        /// </summary>
        /// <param name="produceTypeOfYear"></param>
        /// <returns></returns>
        public string GetProduceTypeOfYearString(int produceTypeOfYear)
        {
            string retString = string.Empty;

            // 全体初期表示設定がnull時はマスタを取得
            if (this._allDetSet == null) this.GetAllDefSet();

            string formatString = ( this._allDetSet != null && this._allDetSet.EraNameDispCd1 == 1 ) ? "ggYY.MM" : "YYYY.MM";

            if (produceTypeOfYear > 0)
            {
                int year = produceTypeOfYear / 100;
                int month = produceTypeOfYear % 100;

                if (month < 1 && month > 12)
                {
                    month = 1;
                    formatString = ( this._allDetSet != null && this._allDetSet.EraNameDispCd1 == 1 ) ? "ggYY" : "YYYY";
                }
                retString = TDateTime.DateTimeToString(formatString, new DateTime(year, month, 1));
            }
            return retString;
        }
        // 2010/12/27 Add <<<

        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// SCMデータの取得
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="scmTimeData">SCM新着データ表示管理データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 新着データの最終取得日時を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2015/08/28</br>
        public int SearchScmTimeData(int cashRegisterNo, out object scmTimeData)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            const string TAB = "\t";                // ログ用
            scmTimeData = null;
            ScmTimeDataWork scmTimeDataWork = null;

            try
            {
                // 新着件数取得処理
                scmTimeDataWork = new ScmTimeDataWork();
                scmTimeDataWork.EnterpriseCode = this._enterpriseCd;
                scmTimeDataWork.SectionCode = this._sectionCd;
                scmTimeDataWork.CashRegisterNo = cashRegisterNo;

                #region <Log>

                StringBuilder before = new StringBuilder();
                {
                    before.Append("新着データの最終取得日付と最終取得時間を取得します。IIOWriteScmDB.SearchScmTimeData(ref object, object)").Append(Environment.NewLine);
                    before.Append(TAB).Append("企業コード：[").Append(scmTimeDataWork.EnterpriseCode).Append("]").Append(Environment.NewLine);
                    before.Append(TAB).Append("拠点コード：[").Append(scmTimeDataWork.SectionCode).Append("]").Append(Environment.NewLine);
                    before.Append(TAB).Append("端末番号：[").Append(scmTimeDataWork.CashRegisterNo).Append("]").Append(Environment.NewLine);
                }
                LogWriter.LogWrite(before.ToString());

                #endregion // </Log>

                Object retscmTimeDataObj = null;
                status = this._iIOWriteScmDB.SearchScmTimeData(scmTimeDataWork, out retscmTimeDataObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && retscmTimeDataObj != null)
                {
                    scmTimeData = retscmTimeDataObj;
                }
            }
            catch (Exception e)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                LogWriter.LogWrite("新着データの最終取得日時取得処理でエラーが発生しました。");
                LogWriter.LogWrite(e.Message);
            }
            

            #region <Log>

            StringBuilder after = new StringBuilder();
            {
                after.Append("検索結果(ステータス：").Append(status).Append(")").Append(Environment.NewLine);
            }
            LogWriter.LogWrite(after.ToString());

            #endregion // </Log>
            return status;
        }

        /// <summary>
        /// 新着データの最終取得日時更新処理
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="lastUpdateDate">前回取得日付</param>
        /// <param name="lastUpdateTime">前回取得時間</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 新着データの最終取得日時更新処理</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2015/04/27</br>
        public int UpdateScmTimeData(int cashRegisterNo, DateTime lastUpdateDate, int lastUpdateTime)
        {
            const string TAB = "\t";                // ログ用
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ScmTimeDataWork scmReadWork = null;

            try
            {
                scmReadWork = new ScmTimeDataWork();
                scmReadWork.EnterpriseCode = this._enterpriseCd;
                scmReadWork.SectionCode = this._sectionCd;
                scmReadWork.CashRegisterNo = cashRegisterNo;
                scmReadWork.LastGetDate = lastUpdateDate;
                scmReadWork.LastGetTime = lastUpdateTime;

                #region <Log>

                StringBuilder before = new StringBuilder();
                {
                    before.Append("新着データの最終取得日付と最終取得時間を更新します。IIOWriteScmDB.UpdateScmTimeData(ref object, object)").Append(Environment.NewLine);
                    before.Append(TAB).Append("端末番号：[").Append(scmReadWork.CashRegisterNo).Append("]").Append(Environment.NewLine);
                    before.Append(TAB).Append("最終取得日付：[").Append(scmReadWork.LastGetDate).Append("]").Append(Environment.NewLine);
                    before.Append(TAB).Append("最終取得時間：[").Append(scmReadWork.LastGetTime).Append("]").Append(Environment.NewLine);
                }
                LogWriter.LogWrite(before.ToString());

                #endregion // </Log>

                status = this._iIOWriteScmDB.UpdateScmTimeData(scmReadWork);
            }
            catch (Exception e)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                LogWriter.LogWrite("新着データの最終取得日時保存処理でエラーが発生しました。");
                LogWriter.LogWrite(e.Message);
            }

            #region <Log>

            StringBuilder after = new StringBuilder();
            {
                after.Append("更新結果(ステータス：").Append(status).Append(")").Append(Environment.NewLine);
            }
            LogWriter.LogWrite(after.ToString());

            #endregion // </Log>
            return status;
        }
        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion // </ISCMTerminal メンバ>

        #region <IDisposable メンバ>

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <see cref="IDisposable"/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _disposed = true;
        }

        #region <IDisposable Idiom>

        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        /// <summary>処分済みフラグを取得します。</summary>
        private bool Disposed { get { return _disposed; } }

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <param name="disposing">マネージオブジェクトを処分するフラグ</param>
        private void Dispose(bool disposing)
        {
            // マネージオブジェクト
            if (disposing)
            {
            }
            // アンマネージオブジェクト
            if (_messageReceiver != null) _messageReceiver.Dispose();
            _messageReceiver = null;
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~SCMTerminal() { Dispose(false); }

        #endregion // <IDisposable Idiom>

        #endregion // </IDisposable メンバ>

        #region <受信メッセージ>

        /// <summary>受信メッセージ</summary>
        private string _receivedMessage;
        /// <summary>受信メッセージのアクセサ</summary>
        private string ReceivedMessage
        {
            get { return _receivedMessage; }
            set { _receivedMessage = value; }
        }

        /// <summary>
        /// 受信メッセージを設定するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SetReceivedMessage(
            object sender,
            ReceivedEventArgs e
        )
        {
            ReceivedMessage = e.Text;
        }

        #endregion // <受信メッセージ>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMTerminal(List<string> settingList)
        {
            this._enterpriseCd = settingList[0];
            this._sectionCd = settingList[1];
            if (!Int32.TryParse(settingList[2], out this._portNumber))
            {
                this._portNumber = -1;
            }
            //PM.NSのときだけ
            if (settingList[3] == "1")
            {
                this._iIOWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB(); // IOWriter
                this._scmTtlStAcs = new SCMTtlStAcs(); // 全体設定マスタ
            }
        }

        // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 -------------------->>>>>
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sectionCd">拠点コード</param>
        /// <br>Note		: デフォルトコンストラクタ</br>
        /// <br>Programmer	: 陳艶丹</br>
        /// <br>Date		: 2016/09/18</br>
        /// </remarks>
        public SCMTerminal(string enterpriseCd, string sectionCd)
        {
            // 企業コード
            this._enterpriseCd = enterpriseCd;
            // 拠点コード
            this._sectionCd = sectionCd;

            this._iIOWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB(); // IOWriter
           
        }
        // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 --------------------<<<<<

        #endregion // </Constructor>

        #region Public Enum
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
        #endregion

        #region private変数
        private string _enterpriseCd; // 企業コード
        private string _sectionCd; // 拠点コード
        private string _localIPAddress; // 自端末のIPアドレス
        private int _portNumber; // ポップアップ受信用ポート番号

        private IIOWriteScmDB _iIOWriteScmDB; // I/O Writer
        private SCMTtlStAcs _scmTtlStAcs; // 全体設定マスタアクセス
        // 2010/12/27 Add >>>
        private AllDefSet _allDetSet;       
        // 2010/12/27 Add <<<
        #endregion

        #region privateメソッド

        // 2010/12/27 Add >>>

        /// <summary>
        /// データ読み込み処理
        /// </summary>
        /// <param name="scmReadWork"></param>
        /// <param name="scmHeaderWork"></param>
        /// <param name="scmCarWork"></param>
        /// <param name="scmDetailWorkList"></param>
        /// <param name="scmAnswerWorkList"></param>
        /// <returns></returns>
        private int ReadProc(IOWriteSCMReadWork scmReadWork, out SCMAcOdrDataWork scmHeaderWork, out SCMAcOdrDtCarWork scmCarWork, out List<SCMAcOdrDtlIqWork> scmDetailWorkList, out List<SCMAcOdrDtlAsWork> scmAnswerWorkList)
        {
            const string AUTHOR = "ポップアップ";   // ログ用
            const string TAB = "\t";                // ログ用
            const string COMMA = ", ";              // ログ用

            scmHeaderWork = null;
            scmCarWork = null;
            scmDetailWorkList = null;
            scmAnswerWorkList = null;

            #region <Log>
            StringBuilder before = new StringBuilder();
            {
                before.Append("ＳＣＭ受発注データを取得します。IIOWriteScmDB.ScmRead(ref object, object)").Append(Environment.NewLine);
                before.Append(TAB).Append("企業コード：[").Append(scmReadWork.EnterpriseCode).Append("]").Append(Environment.NewLine);
                before.Append(TAB).Append("拠点コード：[").Append(scmReadWork.InqOtherSecCd).Append("]").Append(Environment.NewLine);
                before.Append(TAB).Append("問合せ元企業コード：[").Append(scmReadWork.InqOriginalEpCd.Trim()).Append("]").Append(Environment.NewLine);//@@@@20230303
                before.Append(TAB).Append("問合せ元拠点コード：[").Append(scmReadWork.InqOriginalSecCd).Append("]").Append(Environment.NewLine);
                before.Append(TAB).Append("問合せ番号：[").Append(scmReadWork.InquiryNumber.ToString()).Append("]").Append(Environment.NewLine);
                // 2011/02/18 Add >>>
                //before.Append(TAB).Append("回答区分：[").Append(scmReadWork.AnswerDivCds[0].ToString()).Append("]").Append(Environment.NewLine);
                before.Append(TAB).Append("キャンセル区分：[").Append(scmReadWork.CancelDivs[0].ToString()).Append("]").Append(Environment.NewLine);
                // 2011/02/18 Add <<<
            }
            LogWriter.WriteDebugLog(AUTHOR, before.ToString());
            #endregion // </Log>

            object retSCMScObj = new CustomSerializeArrayList();

            int status = this._iIOWriteScmDB.ScmRead(ref retSCMScObj, (object)scmReadWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                IOWriterUtil.ExpandSCMReadRet(retSCMScObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmCarWork);
            }

            #region <Log>
            StringBuilder after = new StringBuilder();
            {
                after.Append("検索結果(ステータス：").Append(status).Append(")").Append(Environment.NewLine);
                after.Append(TAB).Append("件数：((CustomSerializeArrayList)retSCMScObj).Count=");
                if (retSCMScObj != null)
                {
                    after.Append(( (CustomSerializeArrayList)retSCMScObj ).Count);
                }
            }
            LogWriter.WriteDebugLog(AUTHOR, after.ToString());
            #endregion // </Log>

            return status;
        }

        /// <summary>
        /// 全体初期表示設定マスタ取得
        /// </summary>
        private void GetAllDefSet()
        {
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();

            ArrayList retAllDefSetList;
            int status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCd, AllDefSetAcs.SearchMode.Remote);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                List<AllDefSet> allDefSetList = new List<AllDefSet>();
                foreach (AllDefSet record in retAllDefSetList)
                {
                    allDefSetList.Add(record);
                }
                // 拠点逆順にソート
                allDefSetList.Sort(new AllDefSetComparer());

                // 自拠点or全社設定を取得（拠点の逆順にソート済みなので、拠点別設定を優先的に取得）
                this._allDetSet = allDefSetList.Find(
                                    delegate(AllDefSet rec)
                                    {
                                        if (rec.SectionCode.Trim() == this._sectionCd.Trim() || rec.SectionCode.Trim() == "00")
                                        {
                                            return true;
                                        }
                                        return false;
                                    });
            }
            else
            {
                this._allDetSet = new AllDefSet();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scmOrderHeaderRecord"></param>
        /// <param name="cancelCndtionDiv"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private int ReturnedGoodsApprovalProc(UserSCMOrderHeaderRecord scmOrderHeaderRecord, short cancelCndtionDiv, out string errorMsg)
        {
            errorMsg = string.Empty;
            #region データを一旦読み込む

            IOWriteSCMReadWork readPara = new IOWriteSCMReadWork();
            readPara.EnterpriseCode = scmOrderHeaderRecord.EnterpriseCode;
            readPara.InquiryNumber = scmOrderHeaderRecord.InquiryNumber;
            readPara.InqOtherSecCd = scmOrderHeaderRecord.InqOtherSecCd;
            readPara.InqOriginalEpCd = scmOrderHeaderRecord.InqOriginalEpCd.Trim();//@@@@20230303
            readPara.InqOriginalSecCd = scmOrderHeaderRecord.InqOriginalSecCd;
            // 2011/02/18 Add >>>
            //readPara.AnswerDivCds = new int[] { scmOrderHeaderRecord.AnswerDivCd };
            readPara.CancelDivs = new short[] { scmOrderHeaderRecord.CancelDiv };
            // 2011/02/18 Add <<<

            SCMAcOdrDataWork scmHeaderWork;
            SCMAcOdrDtCarWork scmCarWork;
            List<SCMAcOdrDtlIqWork> scmDetailWorkList = new List<SCMAcOdrDtlIqWork>();
            List<SCMAcOdrDtlAsWork> scmAnswerWorkList = new List<SCMAcOdrDtlAsWork>();

            int status = this.ReadProc(readPara, out scmHeaderWork, out scmCarWork, out scmDetailWorkList, out scmAnswerWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

            if (scmHeaderWork.UpdateDate != scmOrderHeaderRecord.UpdateDate ||
                scmHeaderWork.UpdateTime != scmOrderHeaderRecord.UpdateTime)
            {
                return -1;
            }

            #endregion

            #region SCMReadは、全キャンセルデータが抽出されるので、読み込んだ中から今回キャンセル拒否するデータを抽出

            // 抽出済みの明細から、未回答分のデータを取得する
            // 2011/03/03 >>>
            //List<SCMAcOdrDtlIqWork> targetDetailWorkList = scmDetailWorkList.FindAll(
            //        delegate(SCMAcOdrDtlIqWork data)
            //        {
            //            // 他のキー項目が一致していることが前提
            //            if (data.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelling) return true;

            //            return false;
            //        });

            List<SCMAcOdrDtlIqWork> targetDetailWorkList = new List<SCMAcOdrDtlIqWork>();

            foreach (SCMAcOdrDtlIqWork inq in scmDetailWorkList)
            {
                if (scmAnswerWorkList != null)
                {
                    SCMAcOdrDtlAsWork ans = scmAnswerWorkList.Find(
                        delegate(SCMAcOdrDtlAsWork target)
                        {
                            if (( target.InqRowNumber == inq.InqRowNumber ) &&
                                ( target.InqRowNumDerivedNo == inq.InqRowNumDerivedNo) &&
                                ( ( target.UpdateDate > inq.UpdateDate ) || ( ( target.UpdateDate == inq.UpdateDate ) && ( target.UpdateDateTime > inq.UpdateDateTime ) ) )
                                )
                            {
                                return true;
                            }
                            return false;
                        });
                    if (ans != null) continue;

                }
                targetDetailWorkList.Add(inq);
            }
            // 2011/03/03 <<<
            // この時点で、今回キャンセル拒否する分に絞り込まれる
            #endregion

            #region 書込みパラメータの生成

            DateTime today = DateTime.Today;
            int now = DateTime.Now.TimeOfDay.Hours * 10000000 + DateTime.Now.TimeOfDay.Minutes * 100000 + DateTime.Now.TimeOfDay.Seconds * 1000 + DateTime.Now.TimeOfDay.Milliseconds;

            // ヘッダ
            SCMAcOdrDataWork writeHeader = this.CreateSCMAcOdrDataWork(scmHeaderWork, today, now);

            // 明細（問合せ・発注）
            targetDetailWorkList.ForEach(delegate(SCMAcOdrDtlIqWork data)
            {
                data.CancelCndtinDiv = cancelCndtionDiv;
            });

            // 明細（回答）
            List<SCMAcOdrDtlAsWork> writeDetailList = new List<SCMAcOdrDtlAsWork>();

            // 「キャンセル状態区分」に「20:キャンセル却下」を設定する場合のみ回答データを更新
            if (cancelCndtionDiv == (short)CancelCndtinDiv.Rejected)
            {
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
                        // --- ADD 2013/06/10 三戸 2013/06/18配信分 システムテスト障害№32 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        writeData.DataInputSystem = 10;
                        // --- ADD 2013/06/10 三戸 2013/06/18配信分 システムテスト障害№32 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    }

                    writeDetailList.Add(writeData);
                }
            }

            // 車両
            SCMAcOdrDtCarWork writeCar = this.CreateSCMAcOdrDtCarWork(scmCarWork, today, now);

            CustomSerializeArrayList writePara = new CustomSerializeArrayList();

            CustomSerializeArrayList oneInquiryList = new CustomSerializeArrayList();
            // ヘッダ
            oneInquiryList.Add(writeHeader);
            // 車両（重複するので追加しない）
            //oneInquiryList.Add(writeCar);

            // 2011/02/18 Del >>>
            //// 明細（問合せ・発注）
            //ArrayList writeIqDetailList = new ArrayList();
            //foreach (SCMAcOdrDtlIqWork work in targetDetailWorkList)
            //{
            //    writeIqDetailList.Add(work);
            //}
            //oneInquiryList.Add(writeIqDetailList);
            // 2011/02/18 Del <<<

            // 明細（回答）
            ArrayList al = new ArrayList();
            foreach (SCMAcOdrDtlAsWork work in writeDetailList)
            {
                al.Add(work);
            }
            if (al.Count > 0)
            {
                oneInquiryList.Add(al);
            }

            writePara.Add(oneInquiryList);
            #endregion

            object paraObj = (object)writePara;
            status = _iIOWriteScmDB.ScmWrite(ref paraObj, 1);

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

        #region SCM受注データワーククラス生成
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
            // --- ADD 2013/07/22 Y.Wakita ---------->>>>>
            retValue.SfPmCprtInstSlipNo = src.SfPmCprtInstSlipNo;       // SF-PM連携指示書番号
            // --- ADD 2013/07/22 Y.Wakita ----------<<<<<
            // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
            retValue.TabUseDiv = src.TabUseDiv;                         // タブレット使用区分
            // --- ADD 2013/06/21 Y.Wakita ----------<<<<<
            // ADD 2013/05/24 SCM障害№10537対応 ---------------------------------->>>>>
            retValue.CarMngCode = src.CarMngCode;                       // 車両管理コード
            // ADD 2013/05/24 SCM障害№10537対応 ----------------------------------<<<<<
            // --- ADD 2013/10/18 Y.Wakita №84 ---------->>>>>
            retValue.AcceptOrOrderKind = src.AcceptOrOrderKind;         // 受発注種別
            // --- ADD 2013/10/18 Y.Wakita №84 ----------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            retValue.AutoAnsMthd = src.AutoAnsMthd;                     // 自動回答方式
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
            #endregion

            #region 補正する項目

            // 2011/02/18 Del >>>
            //retValue.UpdateDate = updateDate;       // 更新年月日
            //retValue.UpdateTime = updateTime;       // 更新時間
            // 2011/02/18 Del <<<

            retValue.AcptAnOdrStatus = 0;           // 受注ステータス
            retValue.SalesSlipNum = "000000000";    // 売上伝票番号

            retValue.InqOrdAnsDivCd = 2;            // 問発・回答種別
            // 2011/02/25 >>>
            //retValue.AnswerCreateDiv = 1;           // 回答作成区分
            retValue.AnswerCreateDiv = 2;           // 回答作成区分
            // 2011/02/25 <<<

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
        #endregion

        #region SCM受注データ(回答)ワーククラス生成
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
            // --- ADD 2013/10/18 Y.Wakita  №94 (SCM障害№10410 対応漏れ) ---------->>>>>
            retValue.DataInputSystem = src.DataInputSystem;             // データ入力システム
            // --- ADD 2013/10/18 Y.Wakita  №94 (SCM障害№10410 対応漏れ) ----------<<<<<
            #endregion

            #region 補正する項目

            // 2011/02/18 Del >>>
            //retValue.UpdateDate = updateDate;                           // 更新年月日
            //retValue.UpdateTime = updateTime;                           // 更新時間
            // 2011/02/18 Del <<<

            retValue.AcptAnOdrStatus = 0;                               // 受注ステータス
            retValue.SalesSlipNum = "000000000";                        // 売上伝票番号

            // 2011/02/18 Del >>>
            //retValue.CommentDtl = "キャンセルを受付けませんでした。";   // 備考(明細)
            // 2011/02/18 Del <<<
            #endregion

            return retValue;
        }
        #endregion

        #region SCM受注データ(車輌情報)ワーククラス生成
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
            // --- ADD 2013/04/19 三戸 2013/05/22配信分 SCM障害№10521 --------->>>>>>>>>>>>>>>>>>>>>>>>
            retValue.CarMngCode = src.CarMngCode;                       // 車両管理コード
            // --- ADD 2013/04/19 三戸 2013/05/22配信分 SCM障害№10521 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            retValue.ExpectedCeDate = src.ExpectedCeDate;               // 入庫予定日
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

            #endregion

            #region 補正する項目

            //retValue.UpdateDate = updateDate;                           // 更新年月日
            //retValue.UpdateTime = updateTime;                           // 更新時間

            retValue.AcptAnOdrStatus = 0;                          // 受注ステータス
            retValue.SalesSlipNum = "000000000";                   // 売上伝票番号
            #endregion

            return retValue;
        }
        #endregion

        /// <summary>
        /// 得意先情報の取得
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerInfo GetCustomerInfo(int customerCode)
        {
            CustomerInfo info;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, _enterpriseCd, customerCode, false, true, out info);

            return info;
        }
        // 2010/12/27 Add <<<

        #endregion


        #region □ Private Class
        // 2010/12/27 Add >>>
        /// <summary>
        /// 全体初期表示設定を、拠点コード逆順にソートする
        /// </summary>
        /// <remarks></remarks>
        private class AllDefSetComparer : Comparer<AllDefSet>
        {
            public override int Compare(AllDefSet x, AllDefSet y)
            {
                int result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        // 2010/12/27 Add <<<
        #endregion
    }
}
