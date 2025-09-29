//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 見積・受注データ受信
// プログラム概要   : 見積・受注データの受信処理を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/30  修正内容 : ＣＭＴ対応（ＣＭＴ接続中の場合は自動回答対象外とする）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/07/09  修正内容 : データ受信時、PM7データが受信できない件の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/12/27  修正内容 : 2010/03/30の対応を削除(DBにCMT連携区分追加の為）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/14  修正内容 : 新着取得後、WebDBのステータスを更新しないように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/03/03  修正内容 : 回答済みデータの受信日時更新を削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/03/18  修正内容 : 得意先未登録のＳＦから受信時にエラーになる件の修正
//----------------------------------------------------------------------------//
// 管理番号 10703242-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2011/05/25   修正内容 : 回答区分項目追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22024 寺坂 誉志
// 作 成 日  2012.04.10  修正内容 : 高速化対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/08/24  修正内容 : 2012/12月配信予定 SCM障害№10340の対応 
//----------------------------------------------------------------------------//
// 管理番号  11170130-00　　作成担当：譚洪
// 修正日    2015/08/28    修正内容：SCM課題一覧No35 ポップアップ異常終了対応
//----------------------------------------------------------------------------//
// 管理番号 11275206-00  作成担当 : 陳艶丹
// 作 成 日  2016/09/18  修正内容 : SCM高負荷クエリの対応
//----------------------------------------------------------------------------//
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;  // ADD 譚洪 Redmine#47284 SCM仕掛一覧№10722対応
using Broadleaf.Application.Controller.Messenger;
using Broadleaf.Application.Controller.NetworkConfig;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 見積・受注データ受信UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 見積・受注データの受信処理を行います。</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/05/21</br>
	/// <br></br>
	/// <br>Update Note	: 2012.04.10 22024 寺坂　誉志</br>
	/// <br>			: １．高速化対応</br>
    /// <br>Update Note	: 2015/08/28 譚洪</br>
    /// <br>			: SCM課題一覧No35 ポップアップ異常終了対応</br>
	/// </remarks>
	public partial class SCMCheckerForm : Form, IRunable
    {
        #region private定数
        // app.config Key
        private const string CT_Conf_RetryWaitTime = "RetryWaitTime"; // リトライ待機時間(ミリ秒)
        private const string CT_Conf_RetryMaxCount = "RetryMaxCount"; // リトライ最大回数
        private const string CT_Conf_PortNumber = "PortNumber"; // 通信用ポート番号
        private const string CT_Conf_WatchingSpan = "WatchingSpan"; // 監視する期間(日)
        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private const string CT_Conf_AnswerMode = "AnswerMode"; //回答モード "0":通常モード "1":手動回答モード
        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #region <IRunable メンバ>

        /// <summary>
        /// 起動します。
        /// </summary>
        /// <see cref="IRunable"/>
        public void Run()
        {
            try
            {
                // 基本情報のチェック
                if (!Checher.CheckInitialInfo().Equals((int)Result.Code.Normal)) return;

                // 新着情報取得処理
                this.RunSCMNewDataCheck();

                // 受信日時更新処理 
                this.RunReceiveDateUpdate();
            }
            catch (Exception e)
            {
                string ErrMsg = "■例外エラーが発生しました（SCMCheckerForm.Run()）■" + Environment.NewLine;
                ErrMsg += e.Message + Environment.NewLine;
                ErrMsg += e.StackTrace;

                LogWriter.LogWrite(ErrMsg);
            }
            
        }

        /// <summary>
        /// 新着情報取得処理
        /// </summary>
        private void RunSCMNewDataCheck()
        {
			#region 2012.04.10 TERASAKA DEL STA
//            // SCM Webサーバに新着を問い合わせる。
//            if (Checher.GetNewOrderCount().Equals(0)) return;
			#endregion

            // データをダウンロードする。
			#region 2012.04.10 TERASAKA DEL STA
//            if (!Checher.DownloadWebDB().Equals((int)Result.Code.Normal)) return;
			#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			if (!Checher.DownloadWebDB(true).Equals((int)Result.Code.Normal)) return;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

            //>>>2010/07/09
            //// ダウンロードしたデータをローカルDBに書込む。
            //if (!Checher.CopyToLocal().Equals((int)Result.Code.Normal)) return;

            //// SCM Web-DBのステータスを更新する。
            //if (!Checher.UpdateWebDBStatus().Equals((int)Result.Code.Normal)) return;

            //// 2010/03/30 Add >>>
            //// CMTで接続中のリストを取得する。
            //if (!Checher.GetSimplInqCnectInfoList().Equals((int)Result.Code.Normal)) return;
            //// 2010/03/30 Add <<<

            //// データの振分け後、自動回答、CSV出力を行う。
            //if (!Checher.ExecuteAutoReplyOrCSVOutput().Equals((int)Result.Code.Normal)) return;

			#region 2012.04.10 TERASAKA DEL STA
//            bool iSt;
			#endregion
            // ダウンロードしたデータをローカルDBに書込む。
            // 2011/03/08 >>>
            //iSt = Checher.CopyToLocal().Equals((int)Result.Code.Normal);
            //if (iSt)

            Result.Code result = (Result.Code)Checher.CopyToLocal();
            if (result == Result.Code.Normal)
            // 2011/03/08 <<<
            {
                // 2011/02/14 Del >>>
                //// SCM Web-DBのステータスを更新する。
                //if (!Checher.UpdateWebDBStatus().Equals((int)Result.Code.Normal)) return;
                // 2011/02/14 Del <<<
                
                if (!Checher.UpdateWebDBStatus().Equals((int)Result.Code.Normal)) return; // 2011/05/25

                // 2010/12/27 Del >>>
                //// 2010/03/30 Add >>>
                //// CMTで接続中のリストを取得する。
                //if (!Checher.GetSimplInqCnectInfoList().Equals((int)Result.Code.Normal)) return;
                //// 2010/03/30 Add <<<
                // 2010/12/27 Del <<<
            }
            // 2011/03/18 Add >>>
            // 得意先が存在しない場合には以降の処理はしない
            else if (result == Result.Code.NotFound)
            {
                return;
            }
            // 2011/03/18 Add <<<
            // データの振分け後、自動回答、CSV出力を行う。
            if (!Checher.ExecuteAutoReplyOrCSVOutput().Equals((int)Result.Code.Normal)) return;
            //<<<2010/07/09

            //>>>2010/07/30
            //// ポップアップを表示させる。
            //if (!Checher.SendShowingPopup().Equals((int)Result.Code.Normal)) return;
            //<<<2010/07/30
        }

        /// <summary>
        /// 受信日時取得処理
        /// </summary>
        private void RunReceiveDateUpdate()
        {
            return;// 2011/03/03 Add

            // 受信日時の設定のない受注データを取得
            if (!Checher.SearchSCMAcOdrDataAtNoReceiveDate().Equals((int)Result.Code.Normal)) return;

            // 受発注データをダウンロードする
            if (!Checher.SearchScmOdrDataAtNoReceiveDate().Equals((int)Result.Code.Normal)) return;

            // 受注データを更新する
            if (!Checher.UpdateSCMAcOdrDataAtReceiveDate().Equals((int)Result.Code.Normal)) return;
        }
        #endregion // </IRunable メンバ>

        #region <SCMチェッカー>

        /// <summary>SCMチェッカー</summary>
        private ISCMChecker _checher;

        /// <summary>SCMチェッカーを取得します。</summary>
        private ISCMChecker Checher
        {
            get
            {
                if (_checher == null)
                {
                    _checher = new SCMChecker(GetInitialSettings());
                }
                return _checher;
            }
        }

        #region <初期情報の取得>
        /// <summary>
        /// 初期情報取得処理
        /// </summary>
        private List<string> GetInitialSettings()
        {
            List<string> settingList = new List<string>();

            // 企業コード取得
            settingList.Add(LoginInfoAcquisition.EnterpriseCode);

            // リトライ待機時間、最大回数の取得
            settingList.Add(ConfigurationManager.AppSettings[CT_Conf_RetryWaitTime]);
            settingList.Add(ConfigurationManager.AppSettings[CT_Conf_RetryMaxCount]);

            // ポップアップ命令送受信用のポート番号
            settingList.Add(ConfigurationManager.AppSettings[CT_Conf_PortNumber]);

            // 監視する期間
            settingList.Add(ConfigurationManager.AppSettings[CT_Conf_WatchingSpan]);

            // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //回答モード "0":通常モード "1":手動回答モード
            settingList.Add(ConfigurationManager.AppSettings[CT_Conf_AnswerMode]);
            // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 -------------------->>>>>
            // ログイン情報より自拠点を取得
            settingList.Add(LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'));
            // --- ADD 2016/09/18 陳艶丹 Redmine#48846 SCM高負荷クエリの対応 --------------------<<<<<

            return settingList;
        }
        #endregion

        #endregion // </SCMチェッカー>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMCheckerForm() : base()
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>
        }

        #endregion // </Constructor>

        #region <フォーム>

        /// <summary>
        /// フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SCMCheckerForm_Load(object sender, EventArgs e)
        {
        //#if DEBUG
        //    // ネットワーク設定を取得
        //    INetworkConfig networkConfig = NetworkConfigFactory.Create(NetworkConfigType.Default);
        //    {
        //        this.txtIPAddress.Text = networkConfig.IPAddress.ToString();
        //        this.txtPortNumber.Text= networkConfig.PortNumber.ToString();
        //    }
        //#else
        //    Visible = false;
        //#endif
        }

        #endregion // </フォーム>

        #region <デバッグ>

        /// <summary>
        /// 送信ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            ITextMessageSendable textSender = MessengerFactory.CreateTextSender(
                ProtcolType.TCP,
                this.txtIPAddress.Text.Trim(),
                int.Parse(this.txtPortNumber.Text.Trim())
            );
            textSender.Send(this.txtMessage.Text);

            this.txtResponse.Text = textSender.Response;
        }

        /// <summary>
        /// 隠すボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnHide_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        /// <summary>
        /// 通知アイコンのMouseClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Visible = true;
        }

        #endregion // </デバッグ>

    }
}