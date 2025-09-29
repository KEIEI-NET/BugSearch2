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
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/31  修正内容 : 回答区分について、同一データの過去の回答も参照して判断するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優
// 作 成 日  2010/04/05  修正内容 : 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優
// 作 成 日  2010/04/15  修正内容 : 相場回答は自動回答できる場合のみ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : Web上のSCM受発注データ.確定日のチェックを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : ZHANGYH
// 作 成 日  2011/07/12  修正内容 : 1分問題対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2011/08/10  修正内容 : Web上のSCM受発注セット情報を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉立 For Redmine#25253
// 作 成 日  2011/09/19  修正内容 : PCCUOE PM側　自動回答時の処理順序の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉立 For Redmine#25340
// 作 成 日  2011/09/20  修正内容 : 【リモート伝票】既存SCMでリモート伝票が印刷される
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liusy
// 修 正 日  2011/11/17  修正内容 : Redmine#7921 PCCforNSで自動回答設定
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/01/04  修正内容 : SCM改良対応
//                                  1)純正情報設定対応
//                                  2)表示順位設定対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/02/12  修正内容 : SCM改良対応
//                                  BLPOS在庫確認でPCC品目設定マスタを有効にする
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/04/11  修正内容 : 高速化対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2012/04/19  修正内容 : RC-SCM速度改良の修正
//                                 （※検索結果が不正にならないようキャッシュクリアする）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22024 寺坂 誉志
// 作 成 日  2012/04/24  修正内容 : 状態表示対応(SF側)
//----------------------------------------------------------------------------//
// 管理番号  　　　　　　作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/05/09  修正内容 : 障害№132　自動回答時の締済みチェック（発注の場合のみ）
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/05/28  修正内容 : 障害№274 在庫確認でＰＣＣ品目設定が無くても自動回答する
//----------------------------------------------------------------------------//
// 管理番号  　　　　　　作成担当 : 30744 湯上 千加子
// 作 成 日  2012/05/28  修正内容 : 障害対応
//                                  BLPOS在庫確認で優良品の代替の時回答しない件の対応
//----------------------------------------------------------------------------//
// 管理番号  　　　　　　作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/13  修正内容 : 障害対応
//                                  型式にて在庫問い合わせを行うと、タイムアウトになる件の対応
//----------------------------------------------------------------------------//
// 管理番号  　　　　　　作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/20  修正内容 : 障害対応
//                                  優良品の代替品の時、純正メーカーコード、回答純正品番を取得できない件の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2012/06/24  修正内容 : 2012/06/28配信分障害一覧No125
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/06/26  修正内容 : 障害№274 削除(2012/06/28配信から除外)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/07/24  修正内容 : 2012/09/11配信分障害一覧No211
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM障害№76 自動回答時表示区分対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341,10364,10431対応 PCCforNS、BLPの自動回答判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/02/12  修正内容 : 2013/03/06配信 SCM障害№169対応  提供 特記事項 追加。それに伴う処理追加。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/05/09  修正内容 : 2013/06/18配信 SCM障害№10525対応  PCCforNS、状況通知改良。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/09/17  修正内容 : SCM仕掛一覧№210対応　表示順設定の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2014/01/17  修正内容 : SCM仕掛一覧№10628対応
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/13  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 13.フル型式固定番号からのＢＬコード検索回数改良対応
//                                : 14.明細取込区分の更新方法を改良対応
//                                : 15.SCM受発注データ（車両情報）取得方法改良対応
//                                : 16.純正品検索改良対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢
// 作 成 日  2015/06/18  修正内容 : SCM高速化 Redmine3941対応
//                                : Carpodtabで問合せをした際に高速化自動回答データの特記事項が消える障害対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 陳艶丹
// 修 正 日  2020/07/03  修正内容 : PMKOBETSU-3926 WebSyncに間するログ追加対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 陳艶丹
// 修 正 日  2020/07/28  修正内容 : PMKOBETSU-3926 リトライ追加対応
//----------------------------------------------------------------------------//

#define _ENABLED_PRINT_ // 伝票印刷処理を有効にするフラグ

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Auto;
using Broadleaf.Application.Controller.Manual;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Collections;
////////////////////////////////////////////// 20122/04/24 TERASAKA ADD STA //
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
// 2012/04/24 TERASAKA ADD END //////////////////////////////////////////////
using System.IO;// ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応

namespace Broadleaf.Application.Controller
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM受注データ
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM受注明細データ(回答)

    #region <Facade>

    /// <summary>
    /// 自動回答処理の窓口クラス
    /// </summary>
    public static class AutoFacade
    {
        #region <起動モード>

        /// <summary>
        /// 起動モード列挙型
        /// </summary>
        public enum RunningMode
        {
            /// <summary>自動</summary>
            Auto,
            /// <summary>手動</summary>
            Manual
        }

        #endregion // </起動モード>

        /// <summary>
        /// 手動または自動回答処理を生成します。
        /// </summary>
        /// <param name="runningMode">起動モード</param>
        /// <param name="headerRecordList">SCM受注データのレコードリスト</param>
        /// <param name="carRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="detailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <param name="orgAnswerRecordList"></param>
        /// <param name="orgDetailRecordList"></param>
        /// <returns>手動または自動回答処理</returns>
        public static SCMRespondent CreateSCMRespondent(
            RunningMode runningMode,
            IList<SCMOrderHeaderRecordType> headerRecordList,
            IList<SCMOrderCarRecordType> carRecordList,
            IList<SCMOrderDetailRecordType> detailRecordList
            // 2010/03/31 Add >>>
            , IList<SCMOrderAnswerRecordType> orgAnswerRecordList
            , IList<SCMOrderDetailRecordType> orgDetailRecordList
            // 2010/03/31 Add <<<
        )
        {
            return CreateSCMRespondent(
                runningMode,
                headerRecordList,
                carRecordList,
                detailRecordList,
                // 2010/03/31 Add >>>
                orgAnswerRecordList,
                orgDetailRecordList,
                // 2010/03/31 Add <<<
                new SCMManualConfig(null, null)
            );
        }

        /// <summary>
        /// 手動または自動回答処理を生成します。
        /// </summary>
        /// <param name="runningMode">起動モード</param>
        /// <param name="headerRecordList">SCM受注データのレコードリスト</param>
        /// <param name="carRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="detailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <param name="orgAnswerRecordList"></param>
        /// <param name="orgDetailRecordList"></param>
        /// <param name="manualConfig">手動回答処理のコンフィグ</param>
        /// <returns>手動または自動回答処理</returns>
        public static SCMRespondent CreateSCMRespondent(
            RunningMode runningMode,
            IList<SCMOrderHeaderRecordType> headerRecordList,
            IList<SCMOrderCarRecordType> carRecordList,
            IList<SCMOrderDetailRecordType> detailRecordList,
            // 2010/03/31 Add >>>
            IList<SCMOrderAnswerRecordType> orgAnswerRecordList,    
            IList<SCMOrderDetailRecordType> orgDetailRecordList,
            // 2010/03/31 Add <<<
            SCMManualConfig manualConfig
        )
        {
            switch (runningMode)
            {
                // 手動回答処理
                case RunningMode.Manual:
                    {
                        SCMSearcher searcher = new SCMManualSearcher(
                            headerRecordList,
                            carRecordList,
                            detailRecordList,
                            // 2010/03/31 Add >>>
                            orgAnswerRecordList,   
                            orgDetailRecordList,
                            // 2010/03/31 Add <<<
                            manualConfig ?? new SCMManualConfig(null, null)
                        );
                        SCMReferee referee = new SCMManualReferee(searcher);
                        SCMSalesDataMaker salesDataMaker = new SCMManualSalesDataMaker(referee);
                        // ----- ADD 2011/11/17 ----- <<<<<
                        salesDataMaker.runMode = 0;
                        return new SCMManualRespondent(
                            searcher,
                            referee,
                            salesDataMaker
                        );
                    }
                // 自動回答処理
                default:
                    {
                        SCMSearcher searcher = new SCMAutoSearcher(
                            headerRecordList,
                            carRecordList,
                            detailRecordList
                            // 2010/03/31 Add >>>
                            , orgAnswerRecordList 
                            , orgDetailRecordList
                            // 2010/03/31 Add <<<
                        );
                        SCMReferee referee = new SCMAutoReferee(searcher);
                        SCMSalesDataMaker salesDataMaker = new SCMAutoSalesDataMaker(referee);
                        // ----- ADD 2011/11/17 ----- <<<<<
                        salesDataMaker.runMode = 1;
                        return new SCMAutoRespondent(
                            searcher,
                            referee,
                            salesDataMaker
                        );
                    }
            }
        }

        /// <summary>
        /// 手動または自動回答処理を生成します。
        /// </summary>
        /// <param name="runningMode">起動モード</param>
        /// <param name="headerRecordList">SCM受注データのレコードリスト</param>
        /// <param name="carRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="detailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <param name="orgAnswerRecordList"></param>
        /// <param name="orgDetailRecordList"></param>
        /// <param name="ownerForm">所有者フォーム</param>
        /// <returns>手動または自動回答処理</returns>
        [Obsolete("CreateSCMRespondent(RunningMode, IList<SCMOrderHeaderRecordType>, IList<SCMOrderCarRecordType>, IList<SCMOrderDetailRecordType>, SCMManualConfig) を使用して下さい。")]
        public static SCMRespondent CreateSCMRespondent(
            RunningMode runningMode,
            IList<SCMOrderHeaderRecordType> headerRecordList,
            IList<SCMOrderCarRecordType> carRecordList,
            IList<SCMOrderDetailRecordType> detailRecordList,
            // 2010/03/31 Add >>> 
            IList<SCMOrderAnswerRecordType> orgAnswerRecordList,
            IList<SCMOrderDetailRecordType> orgDetailRecordList,
            // 2010/03/31 Add <<<
            IWin32Window ownerForm
        )
        {
            return CreateSCMRespondent(
                runningMode,
                headerRecordList,
                carRecordList,
                detailRecordList,
                // 2010/03/31 Add >>> 
                orgAnswerRecordList,
                orgDetailRecordList,
                // 2010/03/31 Add <<<
                new SCMManualConfig(ownerForm, null)
            );
        }
    }

    #endregion // </Facade>

    /// <summary>
    /// SCM回答処理クラス
    /// </summary>
    public abstract class SCMRespondent
    {
        /// <summary>
        /// 売上データ書き込みフラグ
        /// </summary>
        public bool WriteFlg = true; // 2012/04/11

        #region <ログ用定数>

        /// <summary>クラス名称</summary>
        private const string MY_NAME = "SCMRespondent";

        // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ------>>>>>
        // リトライ情報
        private RetrySet retrySettingInfo = null;
        // リトライ設定XMLファイル
        private const string xmlFileName = "WebSync_RetrySetting.xml";
        // リトライ回数-デフォルト：10回
        private const int retryCountTemp = 10;
        // リトライ間隔-デフォルト：1秒
        private const int retryIntervalTemp = 1000;
        // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ------<<<<<

        #endregion // </ログ用定数>

        #region <SCM受注データ>

        // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        #region 削除コード

        ///// <summary>SCM受注データのレコードリスト</summary>
        //private readonly IList<SCMOrderHeaderRecordType> _headerRecordList;
        ///// <summary>SCM受注データのレコードリストを取得します。</summary>
        //protected IList<SCMOrderHeaderRecordType> HeaderRecordList { get { return _headerRecordList; } }

        ///// <summary>SCM受注データ(車両情報)のレコードリスト</summary>
        //private readonly IList<SCMOrderCarRecordType> _carRecordList;
        ///// <summary>SCM受注データ(車両情報)のレコードリストを取得します。</summary>
        //protected IList<SCMOrderCarRecordType> CarRecordList { get { return _carRecordList; } } 

        ///// <summary>SCM受注明細データ(問合せ・発注)のレコードリスト</summary>
        //private readonly IList<SCMOrderDetailRecordType> _detailRecordList;
        ///// <summary>SCM受注明細データ(問合せ・発注)のレコードリストを取得します。</summary>
        //protected IList<SCMOrderDetailRecordType> DetailRecordList { get { return _detailRecordList; } }

        #endregion // 削除コード
        // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        /// <summary>SCM受注データのレコードリストを取得します。</summary>
        protected IList<SCMOrderHeaderRecordType> HeaderRecordList
        {
            get { return Searcher.HeaderRecordList; }
        }

        /// <summary>SCM受注データ(車両情報)のレコードリストを取得します。</summary>
        protected IList<SCMOrderCarRecordType> CarRecordList
        {
            get { return Searcher.CarRecordList; }
        }

        /// <summary>SCM受注明細データ(問合せ・発注)のレコードリストを取得します。</summary>
        protected IList<SCMOrderDetailRecordType> DetailRecordList
        {
            get { return Searcher.DetailRecordList; }
        }

        /// <summary>前回の回答レコードリストを取得します。</summary>
        protected IList<SCMOrderAnswerRecordType> OrgAnswerRecordList
        {
            get { return Searcher.OrgAnswerRecordList; }
        }

        /// <summary>前回の明細レコードリストを取得します。</summary>
        protected IList<SCMOrderDetailRecordType> OrgDetailRecordList
        {
            get { return Searcher.OrgDetailRecordList; }
        }
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

        #endregion // </SCM受注データ>

        /// <summary>
        /// 回答します。
        /// </summary>
        /// <param name="sendEnterpriceCodeList">企業コードリスト</param>
        /// <param name="sendSectionCodeList">拠点コードリスト</param>
        /// <returns>結果コード</returns>
        // 2011.07.12 ZHANGYH EDT STA >>>>>>
        //public int Reply()
        public int Reply(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList)
        // 2011.07.12 ZHANGYH EDT STA <<<<<<
        {
            const string METHOD_NAME = "Reply()";   // ログ用
            // 2011.07.12 ZHANGYH EDT STA >>>>>>
            sendEnterpriceCodeList = null;
            sendSectionCodeList = null;
            // 2011.07.12 ZHANGYH EDT STA <<<<<<
             
            #region <Log>

            // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
            #region 削除コード

            //string msg = LogHelper.GetDataMsg(
            //    "インプットSCM受注データ",
            //    HeaderRecordList,
            //    CarRecordList,
            //    DetailRecordList
            //);

            #endregion // 削除コード
            // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
            string msg = LogHelper.GetDataMsg(
                "インプットSCM受注データ",
                HeaderRecordList,
                CarRecordList,
                DetailRecordList,
                OrgAnswerRecordList,
                OrgDetailRecordList
            );
            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, msg);

            #endregion // </Log>

            string stepName = string.Empty;
            try
            {
                GetXmlInfo(); // ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応
                int resultCode = (int)ResultUtil.ResultCode.Normal;

                stepName = "検索処理";
                Debug.WriteLine("\nSTEP1:検索処理を行います。");
                #region <検索処理>
                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetStartMsg(stepName));

                ////////////////////////////////////////////// 2012/04/24 TERASAKA ADD STA //

                // --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (_scmPushClient == null)
                {
                    ClientArgs clientArgs = new ClientArgs();

                    // PushサーバーURLの設定
                    string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
                    string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
                    string webSyncUrl = wkStr1 + wkStr2;
                    clientArgs.Url = webSyncUrl;

                    _scmPushClient = new SFCMN01501CA(clientArgs);

                    ConnectArgs connectArgs = new ConnectArgs();
                    connectArgs.StayConnected = true; // 接続が切断場合、自動的に再接続する
                    connectArgs.ReconnectInterval = 5000; // 5秒　接続失敗場合、再接続間隔を指定する

                    connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
                        delegate(IScmPushClient client, ConnectFailureEventArgs args)
                        {
                            // 新着チェッカーが起動する時、Pushサーバーを接続できなければ、このメソッドを呼びられる
                            // 接続した後、Pushサーバーと通信エラー場合、OnStreamFailureイベントだけを呼びられる

                            // 接続が失敗すれば、Pushサーバーへ再接続
                            args.Reconnect = true;
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("WebSyncサーバーへ再接続 WebSyncUrl:" + webSyncUrl));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                        }
                    );
                    _scmPushClient.Connect(connectArgs);
                }
                // --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                List<string> groupByList = new List<string>();

                foreach (SCMOrderHeaderRecordType headerRecord in HeaderRecordList)
                {
                    if (headerRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                    {
                        // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        //string key = string.Format("{0}:{1}:{2}:{3}", headerRecord.InqOriginalEpCd, headerRecord.InqOriginalSecCd, headerRecord.InquiryNumber, ((int)NoticeMode.Processing).ToString());
                        string key = string.Format("{0}:{1}:{2}:{3}:{4}", headerRecord.InqOriginalEpCd.Trim(), headerRecord.InqOriginalSecCd, headerRecord.InquiryNumber, ((int)NoticeMode.Processing).ToString(), _scmPushClient.WEBSYNC_CHANNEL_PCCUOE);//@@@@20230303
                        // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        if (!groupByList.Exists(delegate(string str) { if (key == str)return true; else return false; }))
                        {
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 開始(BLP) 送信パラメータ:" + key));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(NotifyOtherSidePCCUOEStatus), key);
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 終了"));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            groupByList.Add(key);
                        }
                    }
                    // --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    else
                    {
                        string key = string.Format("{0}:{1}:{2}:{3}:{4}", headerRecord.InqOriginalEpCd.Trim(), headerRecord.InqOriginalSecCd, headerRecord.InquiryNumber, ((int)NoticeMode.Processing).ToString(), _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM);//@@@@20230303
                        if (!groupByList.Exists(delegate(string str) { if (key == str)return true; else return false; }))
                        {
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 開始(通常SCM) 送信パラメータ:" + key));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(NotifyOtherSidePCCUOEStatus), key);
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 終了"));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            groupByList.Add(key);
                        }
                    }
                    // --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // 2012/04/24 TERASAKA ADD END //////////////////////////////////////////////

                resultCode = Searcher.Search();
                if (!resultCode.Equals((int)ResultUtil.ResultCode.Normal))
                {
                    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetErrorMsg(stepName, resultCode));
                    return resultCode;
                }

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg(stepName, resultCode));

                #endregion // </検索処理>

                stepName = "回答判定処理";
                Debug.WriteLine("\nSTEP2:回答判定処理を行います。");
                #region <回答判定処理>

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetStartMsg(stepName));

                // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                if ( !Referee.CanReply() )
                {
                    EasyLogger.Write( MY_NAME, METHOD_NAME, LogHelper.GetInfoMsg( "回答できるものがありませんでした。" ) );
                    EasyLogger.Write( MY_NAME, METHOD_NAME, LogHelper.GetEndMsg( stepName, resultCode ) );
                    return resultCode;
                }
                // --- ADD m.suzuki 2011/05/23 ----------<<<<<

                if (!Referee.CanReplyAutomatically())
                {
                    EasyLogger.Write( MY_NAME, METHOD_NAME, LogHelper.GetInfoMsg( "自動回答できるものがありませんでした。" ) );
                    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg(stepName, resultCode));
                    return resultCode;
                }
                EasyLogger.Write( MY_NAME, METHOD_NAME, LogHelper.GetEndMsg( stepName, resultCode ) );

                // --- ADD 吉岡 2012/05/09 №132 ---------->>>>>
                // 締日チェック
                if (!Referee.CheckAddUp())
                {
                    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetInfoMsg("締チェックエラーにて、自動回答できるものがありませんでした。"));
                    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg(stepName, resultCode));
                    return resultCode;
                }
                // --- ADD 吉岡 2012/05/09 №132 ----------<<<<<

                #endregion // </回答判定処理>

                stepName = "売上データ作成";
                Debug.WriteLine("\nSTEP3:売上データ作成を行います。");
                #region <売上データ作成>

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetStartMsg(stepName));

                resultCode = MakeSalesData();
                if (!resultCode.Equals((int)ResultUtil.ResultCode.Normal))
                {
                    EasyLogger.Write( MY_NAME, METHOD_NAME, LogHelper.GetErrorMsg( stepName, resultCode ) );
                    return resultCode;
                }

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg(stepName, resultCode));

                #endregion // </売上データ作成>

                // -- DEL 2011/09/19   ------ >>>>>>
                #region DEL 2011/09/19
                //    stepName = "伝票印刷処理";
            //    Debug.WriteLine("\nSTEP4:伝票印刷処理を行います。");
            //#if _ENABLED_PRINT_
            //    #region <伝票印刷処理>

            //    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetStartMsg(stepName));
            //    // -- ADD 2011/08/10   ------ >>>>>>
            //    // PCCUOE 在庫確認場合、印刷処理を行わない
            //    if (!(HeaderRecordList[0].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
            //        HeaderRecordList[0].InqOrdDivCd == (int)InqOrdDivCd.Inquiry))
            //    {
            //        // -- ADD 2011/08/10   ------ <<<<<<
            //        PrintSalesData();
            //        // -- ADD 2011/08/10   ------ >>>>>>
            //    }
            //    // -- ADD 2011/08/10   ------ <<<<<<
            //    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg(stepName, resultCode));

            //    #endregion // </伝票印刷処理>
            //#else
            //    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg("伝票印刷処理は無効になっています。", resultCode));
            //#endif
                
                //stepName = "回答送信処理";
                //Debug.WriteLine("\nSTEP5:回答送信処理を行います。");
                #endregion
                // -- DEL 2011/09/19   ------ <<<<<<

                // -- ADD 2011/09/19   ------ >>>>>>
                stepName = "回答送信処理";
                Debug.WriteLine("\nSTEP4:回答送信処理を行います。");
                // -- ADD 2011/09/19   ------ <<<<<<

                #region <回答送信処理>

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetStartMsg(stepName));

                ////////////////////////////////////////////// 2012/04/24 TERASAKA ADD STA //
                groupByList = new List<string>();

                foreach (SCMOrderHeaderRecordType headerRecord in HeaderRecordList)
                {
                    if (headerRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                    {
                        // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        //string key = string.Format("{0}:{1}:{2}:{3}", headerRecord.InqOriginalEpCd, headerRecord.InqOriginalSecCd, headerRecord.InquiryNumber, ((int)NoticeMode.Sending).ToString());
                        string key = string.Format("{0}:{1}:{2}:{3}:{4}", headerRecord.InqOriginalEpCd.Trim(), headerRecord.InqOriginalSecCd, headerRecord.InquiryNumber, ((int)NoticeMode.Sending).ToString(), _scmPushClient.WEBSYNC_CHANNEL_PCCUOE);//@@@@20230303
                        // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        if (!groupByList.Exists(delegate(string str) { if (key == str)return true; else return false; }))
                        {
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 開始(BLP) 送信パラメータ:" + key));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(NotifyOtherSidePCCUOEStatus), key);
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 終了"));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            groupByList.Add(key);
                        }
                    }
                    // --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    else
                    {
                        string key = string.Format("{0}:{1}:{2}:{3}:{4}", headerRecord.InqOriginalEpCd.Trim(), headerRecord.InqOriginalSecCd, headerRecord.InquiryNumber, ((int)NoticeMode.Sending).ToString(), _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM);//@@@@20230303
                        if (!groupByList.Exists(delegate(string str) { if (key == str)return true; else return false; }))
                        {
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 開始(通常SCM) 送信パラメータ:" + key));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(NotifyOtherSidePCCUOEStatus), key);
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 終了"));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            groupByList.Add(key);
                        }
                    }
                    // --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // 2012/04/24 TERASAKA ADD END //////////////////////////////////////////////
                // 2011.07.12 ZHANGYH EDT STA >>>>>>
                //resultCode = SendAnswer();
                // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ---------------------------------->>>>>
                //resultCode = SendAnswer(out sendEnterpriceCodeList, out sendSectionCodeList);
                resultCode = SendAnswer(out sendEnterpriceCodeList, out sendSectionCodeList, this.Referee.ScmOdDtCarList);
                // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ----------------------------------<<<<<
                // 2011.07.12 ZHANGYH EDT STA <<<<<<
                if (!resultCode.Equals((int)ResultUtil.ResultCode.Normal))
                {
                    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetErrorMsg(stepName, resultCode));
                    // ADD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    EasyLogger.debugIniFlg = -1;
                    // ADD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    return resultCode;
                }

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg(stepName, resultCode));

                #endregion // </回答送信処理>

                // -- ADD 2011/09/19   ------ >>>>>>
                stepName = "伝票印刷処理";
                Debug.WriteLine("\nSTEP5:伝票印刷処理を行います。");
                #if _ENABLED_PRINT_
                #region <伝票印刷処理>

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetStartMsg(stepName));
                // -- DEL 2011/09/20   ------ >>>>>>
                //// PCCUOE 在庫確認場合、印刷処理を行わない
                //if (!(HeaderRecordList[0].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
                //    HeaderRecordList[0].InqOrdDivCd == (int)InqOrdDivCd.Inquiry))
                //{
                //    PrintSalesData();
                //}
                // -- DEL 2011/09/20   ------ <<<<<<
                // -- ADD 2011/09/20   ------ >>>>>>
                // PCCUOEの場合
                if (HeaderRecordList[0].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                {
                    // 発注のみ、印刷を行う
                    if (HeaderRecordList[0].InqOrdDivCd == (int)InqOrdDivCd.Order)
                    {
                        PrintSalesData(); 
                    }
                }
                else // SCMの場合
                {
                    PrintSalesData();
                }
                // -- ADD 2011/09/20   ------ <<<<<<
                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg(stepName, resultCode));

                #endregion // </伝票印刷処理>
                #else
                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg("伝票印刷処理は無効になっています。", resultCode));
                #endif
                // -- ADD 2011/09/19   ------ <<<<<<

                // ADD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                EasyLogger.debugIniFlg = -1;
                // ADD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                return resultCode;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(MY_NAME, METHOD_NAME, stepName, ex);

                // ADD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                EasyLogger.debugIniFlg = -1;
                // ADD 2014/01/17 SCM障害№10628 吉岡 配信日未定 自動回答速度改善 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                return (int)ResultUtil.ResultCode.Error;
            }
        }

        // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 --------->>>>>
        /// <summary>
        /// XML情報取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2020/07/28</br>
        /// </remarks>
        private void GetXmlInfo()
        {
            try
            {
                retrySettingInfo = new RetrySet();

                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName)))
                {
                    // XMLからリトライ回数とリトライ間隔を取得する
                    retrySettingInfo = UserSettingController.DeserializeUserSetting<RetrySet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName));
                }
                else
                {
                    // リトライ回数-デフォルト：10回
                    retrySettingInfo.RetryCount = retryCountTemp;
                    // リトライ間隔-デフォルト：1秒
                    retrySettingInfo.RetryInterval = retryIntervalTemp;
                }
            }
            catch
            {
                if (retrySettingInfo == null) retrySettingInfo = new RetrySet();
                // リトライ回数-デフォルト：10回
                retrySettingInfo.RetryCount = retryCountTemp;
                // リトライ間隔-デフォルト：1秒
                retrySettingInfo.RetryInterval = retryIntervalTemp;
            }
        }

        /// <summary>
        /// 指定のSF.NS端末への返答送信処理
        /// </summary>
        /// <param name="sender">パラメータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note         : 指定のSF.NS端末への返答送信処理を行う</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2020/07/28</br>
        /// </remarks>
        private bool RetryNotifyOtherSidePCCUOEStatus(object sender, out string errMsg)
        {
            // 送信結果
            bool resultCode = true;
            // エラーメッセージ
            errMsg = string.Empty;

            // オプション制御
            bool canNotify = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract;
            if (!canNotify) return resultCode;

            try
            {
                if (_scmPushClient == null)
                {
                    ClientArgs clientArgs = new ClientArgs();

                    // PushサーバーURLの設定
                    string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
                    string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
                    string webSyncUrl = wkStr1 + wkStr2;
                    clientArgs.Url = webSyncUrl;

                    _scmPushClient = new SFCMN01501CA(clientArgs);

                    ConnectArgs connectArgs = new ConnectArgs();
                    connectArgs.StayConnected = true; // 接続が切断場合、自動的に再接続する
                    connectArgs.ReconnectInterval = 5000; // 5秒　接続失敗場合、再接続間隔を指定する

                    connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
                        delegate(IScmPushClient client, ConnectFailureEventArgs args)
                        {
                            // 新着チェッカーが起動する時、Pushサーバーを接続できなければ、このメソッドを呼びられる
                            // 接続した後、Pushサーバーと通信エラー場合、OnStreamFailureイベントだけを呼びられる

                            // 接続が失敗すれば、Pushサーバーへ再接続
                            args.Reconnect = true;
                            EasyLogger.WriteDebugLog(MY_NAME, "RetryNotifyOtherSidePCCUOEStatus", LogHelper.GetDebugMsg("WebSyncサーバーへ再接続 WebSyncUrl:" + webSyncUrl));
                        }
                    );
                    _scmPushClient.Connect(connectArgs);
                }

                string[] para = sender.ToString().Split(':');

                string inqOriginalEpCd = para[0].Trim();//@@@@20230303
                string inqOriginalSecCd = para[1];
                long inquiryNumber;
                long.TryParse(para[2], out inquiryNumber);
                int noticeMode;
                int.TryParse(para[3], out noticeMode);
                string pushClient = para[4];

                ScmPushData payload = new ScmPushData();
                payload.OrigEnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                payload.OrigSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                payload.InquiryNumber = inquiryNumber;
                payload.NoticeMode = noticeMode;
                payload.IsReply = true;

                PublishArgs publishArgs = new PublishArgs();
                publishArgs.Payload = payload;
                // 指定のSF.NS端末への返答送信処理
                publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", pushClient, inqOriginalEpCd.Trim(), inqOriginalSecCd.Trim());	//@@@@20230303
                EasyLogger.WriteDebugLog(MY_NAME, "RetryNotifyOtherSidePCCUOEStatus", LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 送信のパラメータ:" + sender.ToString()));
                _scmPushClient.Publish(publishArgs);
            }
            catch (Exception ex)
            {
                resultCode = false;
                errMsg = ex.ToString();
            }

            return resultCode;
        }
        // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------<<<<<

        // 2011.07.12 ZHANGYH ADD STA >>>>>>
        /// <summary>
        /// 回答します。
        /// </summary>
        /// <returns>結果コード</returns>
        public int Reply()
        {
            List<string> sendEnterpriceCodeList;
            List<string> sendSectionCodeList;
            return Reply(out sendEnterpriceCodeList, out sendSectionCodeList);
        }
        // 2011.07.12 ZHANGYH ADD STA >>>>>>

        #region <Constructor>

        // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        #region 削除コード

        ///// <summary>
        ///// カスタムコンストラクタ
        ///// </summary>
        ///// <param name="headerRecordList">SCM受注データのレコードリスト</param>
        ///// <param name="carRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        ///// <param name="detailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        ///// <param name="searcher">SCM検索処理</param>
        ///// <param name="referee">SCM回答判定処理</param>
        ///// <param name="salesDataMaker">SCM売上データ作成処理</param>
        //protected SCMRespondent(
        //    IList<SCMOrderHeaderRecordType> headerRecordList,
        //    IList<SCMOrderCarRecordType> carRecordList,
        //    IList<SCMOrderDetailRecordType> detailRecordList,
        //    SCMSearcher searcher,
        //    SCMReferee referee,
        //    SCMSalesDataMaker salesDataMaker
        //)
        //{
        //    _headerRecordList   = headerRecordList; // SCM受注データ
        //    _carRecordList      = carRecordList;    // SCM受注データ(車両情報)
        //    _detailRecordList   = detailRecordList; // SCM受注明細データ(問合せ・発注)

        //    _searcher       = searcher;         // SCM検索処理
        //    _referee        = referee;          // SCM回答判定処理
        //    _salesDataMaker = salesDataMaker;   // SCM売上データ作成処理
        //    _answerSender   = new SCMAnswerSender(_salesDataMaker); // 回答送信処理
        //}

        #endregion // 削除コード
        // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="searcher">SCM検索処理</param>
        /// <param name="referee">SCM回答判定処理</param>
        /// <param name="salesDataMaker">SCM売上データ作成処理</param>
        protected SCMRespondent(
            SCMSearcher searcher,
            SCMReferee referee,
            SCMSalesDataMaker salesDataMaker
        )
        {
            _searcher       = searcher;         // SCM検索処理
            _referee        = referee;          // SCM回答判定処理
            _salesDataMaker = salesDataMaker;   // SCM売上データ作成処理
            _answerSender   = new SCMAnswerSender(_salesDataMaker); // 回答送信処理
        }
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

        #endregion // </Constructor>

        #region <検索処理>

        /// <summary>SCM検索処理</summary>
        private readonly SCMSearcher _searcher;
        /// <summary>SCM検索処理を取得します。</summary>
        protected SCMSearcher Searcher { get { return _searcher; } }

        /// <summary>
        /// 検索処理を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>結果コード(0:正常終了)</returns>
        public int Search(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            const string METHOD_NAME = "Search(SCMOrderDetailRecordType)";  // ログ用

            string stepName = "検索処理";
            try
            {
                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetStartMsg(stepName));

                int status = Searcher.Search(scmOrderDetailRecord);

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetEndMsg(stepName, status));

                return status;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(MY_NAME, METHOD_NAME, stepName, ex);
                return (int)ResultUtil.ResultCode.Error;
            }
        }

        #endregion // </検索処理>

        #region <回答判定処理>

        /// <summary>SCM回答判定処理</summary>
        private readonly SCMReferee _referee;
        /// <summary>SCM回答判定処理を取得します。</summary>
        protected SCMReferee Referee { get { return _referee; } }

        #endregion // </回答判定処理>

        #region <売上データ作成>

        /// <summary>SCM売上データ作成処理</summary>
        private readonly SCMSalesDataMaker _salesDataMaker;
        /// <summary>SCM売上データ作成処理を取得します。</summary>
        protected SCMSalesDataMaker SalesDataMaker { get { return _salesDataMaker; } } 

        /// <summary>
        /// 売上データを作成します。
        /// </summary>
        /// <returns>結果コード</returns>
        protected int MakeSalesData()
        {
            // 売上データ作成
            CustomSerializeArrayList salesData = CreateSalesData();

            // ADD 2015/06/18 豊沢 SCM高速化 Redmine3941対応 --------------------->>>>>
            // 売上データ補正
            this.SalesDataMaker.AdjustSCMAnswerData(salesData);
            // ADD 2015/06/18 豊沢 SCM高速化 Redmine3941対応 ---------------------<<<<<

            // 売上データ書込み
            int status = WriteSalesData(salesData);

            return status;
        }

        /// <summary>
        /// 売上データを生成します。（※事前に検索処理を実行していること）
        /// </summary>
        /// <returns>売上データ（※データが無い場合、空の<c>CustomSerializeArrayList</c>を返します）</returns>
        public virtual CustomSerializeArrayList CreateSalesData()
        {
            const string METHOD_NAME = "CreateSalesData()";   // ログ用

            string stepName = "売上データ作成";
            try
            {
                Referee.InitializeIfSCMGoodsUnitDataMapIsEmpty();
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("商品連結データの初期化：完了"));

                //>>>2012/01/04
                if (Referee.SCMGoodsUnitDataMap != null && Referee.SCMGoodsUnitDataMap.Count > 0)
                {
                    foreach (ISCMOrderDetailRecord enmDetailRecord in Referee.Searcher.DetailRecordList)
                    {
                        string detailKey = enmDetailRecord.ToKey();

                        //>>>2012/06/24
                        //IList<SCMGoodsUnitData> scmGoodsUnitDataList = Referee.SCMGoodsUnitDataMap[detailKey];
                        IList<SCMGoodsUnitData> scmGoodsUnitDataList = null;
                        if (Referee.SCMGoodsUnitDataMap.ContainsKey(detailKey))
                        {
                            scmGoodsUnitDataList = Referee.SCMGoodsUnitDataMap[detailKey];
                        }
                        else
                        {
                            continue;
                        }
                        //<<<2012/06/24
                        IList<SCMGoodsUnitData> retScmGoodsUnitDataList = new List<SCMGoodsUnitData>();

                        // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ---------------------------------->>>>>
                        List<SCMGoodsUnitData> pureGoodsUnitDataList = new List<SCMGoodsUnitData>();
                        foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                        {
                            // 純正品の時、純正品番リストに格納
                            if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                            {
                                pureGoodsUnitDataList.Add(scmGoodsUnitData);
                            }
                        }
                        // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ----------------------------------<<<<<

                        foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                        {
                            List<GoodsUnitData> goodsUnitDataList = Searcher.ResultMap[detailKey].GoodsUnitDataList;
                            GoodsUnitData targetGoods = goodsUnitDataList.Find(
                                delegate(GoodsUnitData goodsUnitData)
                                {
                                    if ((goodsUnitData.GoodsNo == scmGoodsUnitData.RealGoodsUnitData.GoodsNo) &&
                                        (goodsUnitData.GoodsMakerCd == scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            );
                            PartsInfoDataSet partsInfoDataSet = Searcher.ResultMap[detailKey].PartsInfoDB;
                            // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            // 特記事項が空白（商品在庫マスタの登録が無い 又は 商品在庫マスタの特記事項が空白） かつ
                            // 提供データの特記事項があれば、提供データの特記事項をセットする
                            if (partsInfoDataSet != null && partsInfoDataSet.UsrGoodsInfo != null)
                            {
                                foreach (PartsInfoDataSet.UsrGoodsInfoRow row in partsInfoDataSet.UsrGoodsInfo)
                                {
                                    // メーカー、商品番号が一致
                                    if (row.GoodsMakerCd == scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd &&
                                        row.GoodsNo != null && row.GoodsNo == scmGoodsUnitData.RealGoodsUnitData.GoodsNo)
                                    {
                                        // 商品在庫マスタの登録が無い、又は、商品在庫マスタの特記事項が空白
                                        // かつ　提供データの特記事項が有り
                                        if (scmGoodsUnitData.RealGoodsUnitData.GoodsSpecialNote != null &&
                                            scmGoodsUnitData.RealGoodsUnitData.GoodsSpecialNote == string.Empty &&
                                            row.GoodsSpecialNoteOffer != null &&
                                            row.GoodsSpecialNoteOffer != string.Empty)
                                        {
                                            scmGoodsUnitData.RealGoodsUnitData.GoodsSpecialNote = row.GoodsSpecialNoteOffer;
                                        }
                                        break;
                                    }
                                }
                            }
                            // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                            //if (Referee.Searcher.HeaderRecordList[0].InqOrdDivCd == (int)InqOrdDivCd.Inquiry &&
                            //    Referee.Searcher.HeaderRecordList[0].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                            //{
                            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                                // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
                                // 表示区分による定価設定によりすでに回答純正品番設定時は以降の処理は行わない
                                if (scmGoodsUnitData.AnsPureGoodsNo.Trim().Length != 0 && scmGoodsUnitData.PureGoodsMakerCd != 0)
                                {
                                    retScmGoodsUnitDataList.Add(scmGoodsUnitData);
                                    continue;
                                }
                                // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<
                                int j = 0;
                                while (true)
                                {
                                    int pureGoodsMakerCd = 0;
                                    string ansPureGoodsNo = string.Empty;
                                    bool ret = false;
                                    if ((targetGoods != null) && (partsInfoDataSet != null))
                                    {
                                        ret = this.GetPureInfo(partsInfoDataSet, targetGoods.GoodsMakerCd, targetGoods.GoodsNo, j, out pureGoodsMakerCd, out ansPureGoodsNo);
                                        if (pureGoodsMakerCd == 0) pureGoodsMakerCd = targetGoods.GoodsMakerCd;
                                        if (ansPureGoodsNo == string.Empty) ansPureGoodsNo = targetGoods.GoodsNo;
                                    }

                                    //>>>2012/02/12
                                    //scmGoodsUnitData.RetDisplayOrder = targetGoods.JoinDispOrder;
                                    if (targetGoods != null) scmGoodsUnitData.RetDisplayOrder = targetGoods.JoinDispOrder;
                                    //<<<2012/02/12
                                    scmGoodsUnitData.PureGoodsMakerCd = pureGoodsMakerCd;
                                    scmGoodsUnitData.AnsPureGoodsNo = ansPureGoodsNo;

                                    // DEL 2012/05/28 --------------------------------------------------------------------->>>>>
                                    //if ((!IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData)) && (ret == false)) break;
                                    // DEL 2012/05/28 ---------------------------------------------------------------------<<<<<
                                    // ADD 2012/06/13 --------------------------------------------------------------------->>>>>
                                    if ((!IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData)) && (ret == false))
                                    {
                                        retScmGoodsUnitDataList.Add(scmGoodsUnitData);
                                        break;
                                    }
                                    // ADD 2012/06/13 ---------------------------------------------------------------------<<<<<

                                    // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ---------------------------------->>>>>
                                    bool pureFlg = false;
                                    // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ----------------------------------<<<<<
                                    bool bFlg = false;

                                    if (!IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                                    {
                                        foreach (SCMGoodsUnitData loopUnitData in retScmGoodsUnitDataList)
                                        {
                                            if ((loopUnitData.AnsPureGoodsNo == scmGoodsUnitData.AnsPureGoodsNo) &&
                                                (loopUnitData.PureGoodsMakerCd == scmGoodsUnitData.PureGoodsMakerCd) &&
                                                (loopUnitData.RealGoodsUnitData.GoodsNo == scmGoodsUnitData.RealGoodsUnitData.GoodsNo) &&
                                                (loopUnitData.RealGoodsUnitData.GoodsMakerCd == scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd))
                                            {
                                                bFlg = true;
                                            }
                                        }
                                        // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ---------------------------------->>>>>
                                        // 回答純正品番が回答対象データに含まれているか
                                        foreach (SCMGoodsUnitData pureUnitData in pureGoodsUnitDataList)
                                        {
                                            if (pureUnitData.RealGoodsUnitData.GoodsNo == scmGoodsUnitData.AnsPureGoodsNo &&
                                                pureUnitData.RealGoodsUnitData.GoodsMakerCd == scmGoodsUnitData.PureGoodsMakerCd)
                                            {
                                                pureFlg = true;
                                            }
                                        }
                                        // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ----------------------------------<<<<<
                                    }
                                    // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ---------------------------------->>>>>
                                    else
                                    {
                                        pureFlg = true;
                                    }
                                    // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ----------------------------------<<<<<


                                    // UPD 2012/11/07 2012/11/14配信 システムテスト障害対応 ---------------------------------->>>>>
                                    //if (bFlg == false)
                                    // 回答純正品番に重複が存在しない時
                                    if (bFlg == false && pureFlg == true)
                                    // UPD 2012/11/07 2012/11/14配信 システムテスト障害対応 ----------------------------------<<<<<
                                    {
                                        retScmGoodsUnitDataList.Add(scmGoodsUnitData);
                                        break;
                                    }
                                    j++;
                                }
                                //>>>2012/06/26
                                //// --- ADD 三戸 2012/05/28 №274 ---------->>>>>
                                //if (retScmGoodsUnitDataList.Count == 0)
                                //{
                                //    retScmGoodsUnitDataList.Add(scmGoodsUnitData);
                                //}
                                //// --- ADD 三戸 2012/05/28 №274 ----------<<<<<
                                //<<<2012/06/26
                            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                            #region 削除(SCM改良のため)
                            //}
                            //else
                            //{
                            //    int pureGoodsMakerCd = 0;
                            //    string ansPureGoodsNo = string.Empty;
                            //    bool ret = false;
                            //    if ((targetGoods != null) && (partsInfoDataSet != null))
                            //    {
                            //        ret = this.GetPureInfo(partsInfoDataSet, targetGoods.GoodsMakerCd, targetGoods.GoodsNo, 0, out pureGoodsMakerCd, out ansPureGoodsNo);
                            //        if (pureGoodsMakerCd == 0) pureGoodsMakerCd = targetGoods.GoodsMakerCd;
                            //        if (ansPureGoodsNo == string.Empty) ansPureGoodsNo = targetGoods.GoodsNo;
                            //    }

                            //    //>>>2012/02/12
                            //    //scmGoodsUnitData.RetDisplayOrder = targetGoods.JoinDispOrder;
                            //    if (targetGoods != null) scmGoodsUnitData.RetDisplayOrder = targetGoods.JoinDispOrder;
                            //    //<<<2012/02/12
                            //    scmGoodsUnitData.PureGoodsMakerCd = pureGoodsMakerCd;
                            //    scmGoodsUnitData.AnsPureGoodsNo = ansPureGoodsNo;

                            //    retScmGoodsUnitDataList.Add(scmGoodsUnitData);
                            //}
                            #endregion
                            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                        }

                        // DEL 2013/09/17 SCM仕掛一覧№210対応 --------------------------------------->>>>>
                        //// 表示順位再設定
                        //Dictionary<int, int> dispDic = new Dictionary<int, int>();
                        //List<DispOrderClass> dispOrderClassList = new List<DispOrderClass>();
                        //foreach (SCMGoodsUnitData scmGoods in retScmGoodsUnitDataList)
                        //{
                        //    DispOrderClass disp = new DispOrderClass();
                        //    disp.RetDisplayOrder = scmGoods.RetDisplayOrder;
                        //    disp.GoodsMakerCd = scmGoods.RealGoodsUnitData.GoodsMakerCd;
                        //    disp.GoodsNo = scmGoods.RealGoodsUnitData.GoodsNo;
                        //    if (!dispOrderClassList.Contains(disp))
                        //    {
                        //        dispOrderClassList.Add(disp);
                        //    }
                        //}
                        //dispOrderClassList.Sort(new DispOrderClassComparer());


                        //int i = 1;
                        //foreach (DispOrderClass dispLoop in dispOrderClassList)
                        //{
                        //    if (!dispDic.ContainsKey(dispLoop.RetDisplayOrder))
                        //    {
                        //        dispDic.Add(dispLoop.RetDisplayOrder, i);
                        //        i++;
                        //    }
                        //}

                        //foreach (SCMGoodsUnitData scmGoods in retScmGoodsUnitDataList)
                        //{
                        //    int retDispOrder = dispDic[scmGoods.RetDisplayOrder];
                        //    scmGoods.RetDisplayOrder = retDispOrder;
                        //}

                        //Referee.SCMGoodsUnitDataMap[detailKey] = retScmGoodsUnitDataList;
                        // DEL 2013/09/17 SCM仕掛一覧№210対応 ---------------------------------------<<<<<
                    }
                }
                //<<<2012/01/04

                return SalesDataMaker.CreateSalesData();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(MY_NAME, METHOD_NAME, stepName, ex);
                return new CustomSerializeArrayList();
            }
        }

        //>>>2012/01/04
        /// <summary>
        /// 表示順クラス
        /// </summary>
        public class DispOrderClass
        {
            // ===================================================================================== //
            // プライベート変数
            // ===================================================================================== //
            # region Private Members
            private int _retDisplayOrder;
            private int _goodsMakerCd;
            private string _goodsNo;
            # endregion

            // ===================================================================================== //
            // コンストラクタ
            // ===================================================================================== //
            # region Constructors
            /// <summary>
            /// 表示順クラスデフォルトコンストラクタ
            /// </summary>
            public DispOrderClass()
            {
                this._retDisplayOrder = 0;
                this._goodsMakerCd = 0;
                this._goodsNo = string.Empty;
            }
            /// <summary>
            /// 表示順コンストラクタ
            /// </summary>
            /// <param name="retDisplayOrder"></param>
            /// <param name="goodsMakerCd"></param>
            /// <param name="goodsNo"></param>
            public DispOrderClass(int retDisplayOrder, int goodsMakerCd, string goodsNo)
            {
                this._retDisplayOrder = retDisplayOrder;
                this._goodsMakerCd = goodsMakerCd;
                this._goodsNo = goodsNo;
            }
            # endregion

            // ===================================================================================== //
            // プロパティ
            // ===================================================================================== //
            # region Properties
            /// <summary>
            /// 表示順
            /// </summary>
            public int RetDisplayOrder
            {
                get { return this._retDisplayOrder; }
                set { this._retDisplayOrder = value; }
            }
            /// <summary>
            /// メーカーコード
            /// </summary>
            public int GoodsMakerCd
            {
                get { return this._goodsMakerCd; }
                set { this._goodsMakerCd = value; }
            }
            /// <summary>
            /// 品番
            /// </summary>
            public string GoodsNo
            {
                get { return this._goodsNo; }
                set { this._goodsNo = value; }
            }
            # endregion
        }

        /// <summary>
        /// DispOrderClassクラス(表示順位(昇順)・メーカー(昇順)・品番(昇順))
        /// </summary>
        private class DispOrderClassComparer : Comparer<DispOrderClass>
        {
            public override int Compare(DispOrderClass x, DispOrderClass y)
            {
                int result = x.RetDisplayOrder.CompareTo(y.RetDisplayOrder);
                if (result != 0) return result;

                result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                if (result != 0) return result;

                result = x.GoodsNo.CompareTo(y.GoodsNo);
                return result;
            }
        }

        /// <summary>
        /// 純正情報取得処理
        /// </summary>
        /// <param name="partsInfoDataSet"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="i"></param>
        /// <param name="pureGoodsMakerCd"></param>
        /// <param name="ansPureGoodsNo"></param>
        private bool GetPureInfo(PartsInfoDataSet partsInfoDataSet, int goodsMakerCd, string goodsNo, int i, out int pureGoodsMakerCd, out string ansPureGoodsNo)
        {
            bool ret = false;
            PartsInfoDataSet.UsrJoinPartsDataTable usrJoinPartsDataTable = (PartsInfoDataSet.UsrJoinPartsDataTable)partsInfoDataSet.UsrJoinParts.Copy();
            PartsInfoDataSet.UsrGoodsInfoDataTable usrGoodsInfoDataTable = (PartsInfoDataSet.UsrGoodsInfoDataTable)partsInfoDataSet.UsrGoodsInfo.Copy();
            pureGoodsMakerCd = 0;
            ansPureGoodsNo = string.Empty;

            if (usrJoinPartsDataTable == null) return ret;

            string filter = string.Format("{0}={1} AND {2}='{3}'", usrJoinPartsDataTable.JoinDestMakerCdColumn.ColumnName,
                                                                   goodsMakerCd,
                                                                   usrJoinPartsDataTable.JoinDestPartsNoColumn.ColumnName,
                                                                   goodsNo);
            PartsInfoDataSet.UsrJoinPartsRow[] usrJoinPartsRows = (PartsInfoDataSet.UsrJoinPartsRow[])usrJoinPartsDataTable.Select(filter);

            if ((usrJoinPartsRows != null) && (usrJoinPartsRows.Length >= i+1) && (usrGoodsInfoDataTable != null))
            {
                filter = string.Format("{0}={1} AND {2}='{3}'", usrGoodsInfoDataTable.GoodsMakerCdColumn.ColumnName,
                                                                      usrJoinPartsRows[i].JoinSourceMakerCode,
                                                                      usrGoodsInfoDataTable.GoodsNoColumn.ColumnName,
                                                                      usrJoinPartsRows[i].JoinSrcPartsNoWithH);
                PartsInfoDataSet.UsrGoodsInfoRow[] usrGoodsInfoRows = (PartsInfoDataSet.UsrGoodsInfoRow[])usrGoodsInfoDataTable.Select(filter);

                if ((usrGoodsInfoRows != null) && (usrGoodsInfoRows.Length != 0))
                {
                    pureGoodsMakerCd = usrGoodsInfoRows[0].GoodsMakerCd;
                    if (usrGoodsInfoRows[0].NewGoodsNo.Trim() != string.Empty)
                    {
                        ansPureGoodsNo = usrGoodsInfoRows[0].NewGoodsNo;
                    }
                    else
                    {
                        // UPD 2012/07/24 SCM障害№212 2012/09/11配信 ---------------------->>>>>
                        //ansPureGoodsNo = usrJoinPartsRows[0].JoinSrcPartsNoWithH;
                        ansPureGoodsNo = usrJoinPartsRows[i].JoinSrcPartsNoWithH;
                        // UPD 2012/07/24 SCM障害№212 2012/09/11配信 ----------------------<<<<<
                    }
                    ret = true;
                }
            }
            // ADD 2012/06/20 ------------------------------------->>>>>
            // 純正品番が取得できなかった時、代替品の検索を行い代替品該当時は代替元品番で純正品番を取得する
            if (!ret)
            {
                PartsInfoDataSet.UsrSubstPartsDataTable usrSubstPartsDataTable = (PartsInfoDataSet.UsrSubstPartsDataTable)partsInfoDataSet.UsrSubstParts.Copy();

                filter = string.Format("{0}={1} AND {2}='{3}'", usrSubstPartsDataTable.ChgDestMakerCdColumn.ColumnName,
                                                                goodsMakerCd,
                                                                usrSubstPartsDataTable.ChgDestGoodsNoColumn.ColumnName,
                                                                goodsNo);
                PartsInfoDataSet.UsrSubstPartsRow[] usrSubstPartsRows = (PartsInfoDataSet.UsrSubstPartsRow[])usrSubstPartsDataTable.Select(filter);

                if ((usrSubstPartsRows != null) && (usrSubstPartsRows.Length != 0) && !usrSubstPartsRows[0].OfferKubun)
                {
                    usrJoinPartsRows = null;
                    filter = string.Format("{0}={1} AND {2}='{3}'", usrJoinPartsDataTable.JoinDestMakerCdColumn.ColumnName,
                                                                    usrSubstPartsRows[0].ChgSrcMakerCd,
                                                                    usrJoinPartsDataTable.JoinDestPartsNoColumn.ColumnName,
                                                                    usrSubstPartsRows[0].ChgSrcGoodsNo);
                    usrJoinPartsRows = (PartsInfoDataSet.UsrJoinPartsRow[])usrJoinPartsDataTable.Select(filter);

                    if ((usrJoinPartsRows != null) && (usrJoinPartsRows.Length >= i + 1) && (usrGoodsInfoDataTable != null))
                    {
                        filter = string.Format("{0}={1} AND {2}='{3}'", usrGoodsInfoDataTable.GoodsMakerCdColumn.ColumnName,
                                                                        usrJoinPartsRows[i].JoinSourceMakerCode,
                                                                        usrGoodsInfoDataTable.GoodsNoColumn.ColumnName,
                                                                        usrJoinPartsRows[i].JoinSrcPartsNoWithH);
                        PartsInfoDataSet.UsrGoodsInfoRow[] usrGoodsInfoRows = (PartsInfoDataSet.UsrGoodsInfoRow[])usrGoodsInfoDataTable.Select(filter);

                        if ((usrGoodsInfoRows != null) && (usrGoodsInfoRows.Length != 0))
                        {
                            pureGoodsMakerCd = usrGoodsInfoRows[0].GoodsMakerCd;
                            if (usrGoodsInfoRows[0].NewGoodsNo.Trim() != string.Empty)
                            {
                                ansPureGoodsNo = usrGoodsInfoRows[0].NewGoodsNo;
                            }
                            else
                            {
                                // UPD 2012/07/24 SCM障害№212 2012/09/11配信 ---------------------->>>>>
                                //ansPureGoodsNo = usrJoinPartsRows[0].JoinSrcPartsNoWithH;
                                ansPureGoodsNo = usrJoinPartsRows[i].JoinSrcPartsNoWithH;
                                // UPD 2012/07/24 SCM障害№212 2012/09/11配信 ----------------------<<<<<
                            }
                            ret = true;
                        }
                    }
                }
            }
            // ADD 2012/06/20 -------------------------------------<<<<<
            return ret;
        }

        /// <summary>
        /// 純正であるか判断します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :純正です。<br/>
        /// <c>false</c>:純正ではありません。
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">提供区分の値が範囲外です。</exception>
        protected static bool IsPureAtOfferKubun(GoodsUnitData goodsUnitData)
        {
            switch (goodsUnitData.OfferKubun)
            {
                case 0: // ユーザー登録
                    {
                        // 0:純正
                        if (goodsUnitData.GoodsKindCode == 0)
                        {
                            return true;
                        }
                        // 1:その他
                        else if (goodsUnitData.GoodsKindCode == 1)
                        {
                            return false;
                        }
                        return false;
                    }
                case 1: return true;    // 1:提供純正編集
                case 2: return false;   // 2:提供優良編集
                case 3: return true;    // 3:提供純正
                case 4: return false;   // 4:提供優良
                case 5: return false;   // 5:TBO
                case 7: return false;   // 7:オリジナル部品
                default:
                    throw new ArgumentOutOfRangeException(
                        string.Format("提供区分の値が範囲外です。(={0})", goodsUnitData.OfferKubun)
                    );
            }
        }
        //<<<2012/01/04

        /// <summary>
        /// 売上データを書き込みます。
        /// </summary>
        /// <param name="salesData">売上データ</param>
        /// <returns>結果コード</returns>
        protected int WriteSalesData(CustomSerializeArrayList salesData)
        {
            const string METHOD_NAME = "WriteSalesData()";  // ログ用

            Debug.WriteLine("\t2.売上データを書き込みます。");

            //>>>2012/04/11
            //KeyValuePair<int, object> result = SalesSlipIOAgent.Write(salesData);
            KeyValuePair<int, object> result = SalesSlipIOAgent.Write(salesData, WriteFlg);
            //<<<2012/04/11

            if (SalesDataMaker.IsSobaAnswerOnly)
            {
                SalesSlipWriterParameter salesSlipWriterParameter = new SalesSlipWriterParameter(
                    SalesDataMaker.SobaOnlySCMOrderDataParameterList
                );

                // 回答データのみをSCM I/O WriterにてDB書込み
                result = SCMIOWriterAgent.Write(salesSlipWriterParameter.ToSCMIOWriterParameter());

                // 回答送信処理へ回答データを展開
                AnswerSender.WritedSalesSlipParameter = salesSlipWriterParameter;
            }
            else
            {
                // ADD 2010/04/15 相場回答は自動回答できる場合のみ ---------->>>>>
                // 書込むデータが存在しなかった場合、何もしない
                if (result.Value == null)
                {
                    #region <Log>

                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("書込むデータが存在しないので、伝票印刷処理および回答送信処理を省略します。"));

                    #endregion // </Log>

                    return result.Key;
                }
                // ADD 2010/04/15 相場回答は自動回答できる場合のみ ----------<<<<<

                // 売伝リモートの書込み結果を展開
                // 伝票印刷処理へ
                SalesDataPrinter.WritedSalesSlipParameter = new SalesSlipWriterParameter(
                    result.Value as CustomSerializeArrayList
                );
                // 回答送信処理へ
                AnswerSender.WritedSalesSlipParameter = new SalesSlipWriterParameter(
                    result.Value as CustomSerializeArrayList
                );
            }
            return result.Key;
        }

        #endregion // </売上データ作成処理>

        #region <伝票印刷処理>

        /// <summary>伝票印刷処理</summary>
        private SCMSalesDataPrinter _salesDataPrinter;
        /// <summary>伝票印刷処理を取得します。</summary>
        protected SCMSalesDataPrinter SalesDataPrinter
        {
            get
            {
                if (_salesDataPrinter == null)
                {
                    _salesDataPrinter = new SCMSalesDataPrinter();
                }
                return _salesDataPrinter;
            }
        }

        /// <summary>
        /// 伝票印刷処理を行います。
        /// </summary>
        /// <returns>結果コード</returns>
        protected void PrintSalesData()
        {
            SalesDataPrinter.Print();
        }

        #endregion // </伝票印刷処理>

        #region <回答送信処理>

        /// <summary>SCM回答送信処理</summary>
        private readonly SCMAnswerSender _answerSender;
        /// <summary>SCM回答送信処理</summary>
        protected SCMAnswerSender AnswerSender { get { return _answerSender; } } 

        /// <summary>
        /// 回答送信処理を行います。
        /// </summary>
        /// <returns>結果コード</returns>
        protected int SendAnswer()
        {
            return AnswerSender.SendToWebServer();
        }

        // 2011.07.12 ZHANGYH ADD STA >>>>>>
        /// <summary>
        /// 回答送信処理を行います。
        /// </summary>
        /// <param name="sendEnterpriceCodeList">企業コードリスト</param>
        /// <param name="sendSectionCodeList">拠点コードリスト</param>
        /// <param name="scmOdDtCarList">SCM受発注データ（車両情報）リスト</param>
        /// <returns>結果コード</returns>
        // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ---------------------------------->>>>>
        //protected int SendAnswer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList)
        protected int SendAnswer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList, List<ScmOdDtCar> scmOdDtCarList)
        // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ----------------------------------<<<<<
        {
            //>>>2012/04/11
            //return AnswerSender.SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList);
            // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ---------------------------------->>>>>
            //return AnswerSender.SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList, WriteFlg);
            return AnswerSender.SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList, WriteFlg, scmOdDtCarList);
            // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ----------------------------------<<<<<
            //<<<2012/04/11
        }
        // 2011.07.12 ZHANGYH ADD STA >>>>>>

        #endregion // </回答送信処理>

        ////////////////////////////////////////////// 2012/04/24 TERASAKA ADD STA //
        private static Broadleaf.Application.Common.SFCMN01501CA _scmPushClient;

        private void NotifyOtherSidePCCUOEStatus(object sender)
        {
            // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 --------->>>>>
            // 送信結果
            bool resultCode = false;
            // エラーメッセージ
            string errMsg = string.Empty;
            // リトライ回数より送信処理を行う
            for (int i = 1; i <= retrySettingInfo.RetryCount; i++)
            {
                // 指定のSF.NS端末への返答送信処理
                resultCode = RetryNotifyOtherSidePCCUOEStatus(sender, out errMsg);

                // 送信成功場合
                if (resultCode)
            {
                    break;
                }
                // 送信失敗場合
                else
                {
                    EasyLogger.WriteDebugLog(MY_NAME, "RetryNotifyOtherSidePCCUOEStatus", LogHelper.GetDebugMsg("例外内容：" + errMsg + "  リトライ回数：" + i.ToString()));
                }
            }

            //// オプション制御
            //bool canNotify = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract;
            //if (!canNotify) return;
            //// --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
            //try
            //{
            //// --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
            //    if (_scmPushClient == null)
            //    {
            //        ClientArgs clientArgs = new ClientArgs();

            //        // PushサーバーURLの設定
            //        string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
            //        string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
            //        string webSyncUrl = wkStr1 + wkStr2;
            //        clientArgs.Url = webSyncUrl;

            //        _scmPushClient = new SFCMN01501CA(clientArgs);

            //        ConnectArgs connectArgs = new ConnectArgs();
            //        connectArgs.StayConnected = true; // 接続が切断場合、自動的に再接続する
            //        connectArgs.ReconnectInterval = 5000; // 5秒　接続失敗場合、再接続間隔を指定する

            //        connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
            //            delegate(IScmPushClient client, ConnectFailureEventArgs args)
            //            {
            //                // 新着チェッカーが起動する時、Pushサーバーを接続できなければ、このメソッドを呼びられる
            //                // 接続した後、Pushサーバーと通信エラー場合、OnStreamFailureイベントだけを呼びられる

            //                // 接続が失敗すれば、Pushサーバーへ再接続
            //                args.Reconnect = true;
            //                EasyLogger.WriteDebugLog(MY_NAME, "NotifyOtherSidePCCUOEStatus", LogHelper.GetDebugMsg("WebSyncサーバーへ再接続 WebSyncUrl:" + webSyncUrl));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
            //            }
            //        );
            //        _scmPushClient.Connect(connectArgs);
            //    }

            //    string[] para = sender.ToString().Split(':');

            //    string inqOriginalEpCd = para[0];
            //    string inqOriginalSecCd = para[1];
            //    long inquiryNumber;
            //    long.TryParse(para[2], out inquiryNumber);
            //    int noticeMode;
            //    int.TryParse(para[3], out noticeMode);
            //    // --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //    string pushClient = para[4];
            //    // --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            //    ScmPushData payload = new ScmPushData();
            //    payload.OrigEnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //    payload.OrigSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            //    payload.InquiryNumber = inquiryNumber;
            //    payload.NoticeMode = noticeMode;
            //    payload.IsReply = true;

            //    PublishArgs publishArgs = new PublishArgs();
            //    publishArgs.Payload = payload;
            //    // 指定のSF.NS端末への返答送信処理
            //    // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //    //publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE, inqOriginalEpCd, inqOriginalSecCd.Trim());
            //    publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", pushClient, inqOriginalEpCd, inqOriginalSecCd.Trim());
            //    // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            //    EasyLogger.WriteDebugLog(MY_NAME, "NotifyOtherSidePCCUOEStatus", LogHelper.GetDebugMsg("指定のSF.NS端末への返答送信処理 送信のパラメータ:" + sender.ToString()));// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
            //    _scmPushClient.Publish(publishArgs);
            //// --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
            //}
            //catch(Exception ex)
            //{
            //    EasyLogger.WriteDebugLog(MY_NAME, "NotifyOtherSidePCCUOEStatus", LogHelper.GetDebugMsg("WebSync処理に失敗しました。" + "\r\n" + "例外内容：" + ex.ToString()));
            //    throw ex;
            //}
            //// --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
            // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------<<<<<
        }
        // 2012/04/24 TERASAKA ADD END //////////////////////////////////////////////

        // --- ADD m.suzuki 2012/04/19 ---------->>>>>
        /// <summary>
        /// 強制的に検索結果をクリアする処理
        /// </summary>
        public void ClearSearchResult()
        {
            if ( _referee != null )
            {
                _referee.ClearSearchResult();
                // _referee.ClearSearchResult()から_searcher.ClearSearchResult()が呼ばれる
            }
            else
            {
                _searcher.ClearSearchResult();
            }
        }
        // --- ADD m.suzuki 2012/04/19 ----------<<<<<
    }

    // ---ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ----->>>>>
    # region
    /// <summary>
    /// リトライ設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : リトライ設定クラス</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/07/28</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RetrySet
    {
        // リトライ回数
        private int _retryCount;

        // リトライ間隔
        private int _retryInterval;

        /// <summary>
        /// リトライ設定クラス
        /// </summary>
        public RetrySet()
        {

        }

        /// <summary>リトライ回数</summary>
        public int RetryCount
        {
            get { return this._retryCount; }
            set { this._retryCount = value; }
        }

        /// <summary>リトライ間隔</summary>
        public int RetryInterval
        {
            get { return this._retryInterval; }
            set { this._retryInterval = value; }
        }
    }
    # endregion
    // ---ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 -----<<<<<
}
