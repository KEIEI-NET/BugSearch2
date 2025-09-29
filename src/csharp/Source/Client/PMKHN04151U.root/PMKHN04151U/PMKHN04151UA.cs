//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール送信履歴表示
// プログラム概要   : メール送信履歴表示一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : メール送信履歴表示
// 作 成 日  2010/05/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//


using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using System.Net.NetworkInformation;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// メール送信履歴表示 入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メール送信履歴表示入力フォームクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2010/05/25</br>
    /// </remarks>
    public partial class PMKHN04151UA : Form
    {

        #region ■ private member
        /// <summary>イメージリスト</summary>
        /// <remarks></remarks>
        private ImageList _imageList16 = null;

        /// <summary>PMKHN04151UBオブジェクト</summary>
        /// <remarks></remarks>
        private PMKHN04151UB _inputDetails;

        /// <summary>自拠点</summary>
        /// <remarks></remarks>
        private string _loginSectionCode;

        /// <summary>企業コード</summary>
        /// <remarks></remarks>
        private string _enterpriseCode;

        /// <summary>メール送信履歴表示 条件データ</summary>
        /// <remarks></remarks>
        private QrMailHistSearchCond _qrMailHistSearchCond;

        /// <summary>メール送信履歴表示 テーブルアクセスクラス</summary>
        /// <remarks></remarks> 
        private MailHistAcs _mailHistAcs = null;

        //日付取得部品
        private DateGetAcs _dateGet;

        //エラー条件メッセージ
        const string ct_InputError = "の入力が不正です。";
        const string ct_NoInput = "を入力して下さい。";
        const string ct_RangeError = "の範囲指定に誤りがあります。";
        #endregion

        #region ■ Constroctors
        /// <summary>
        /// メール送信履歴表示 入力フォームクラスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : メール送信履歴表示 入力フォームクラスクラスのコンストラクタです</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public PMKHN04151UA()
        {
            InitializeComponent();

            _qrMailHistSearchCond = new QrMailHistSearchCond();
            this._mailHistAcs = MailHistAcs.GetInstance();

            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

            this._inputDetails = new PMKHN04151UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._inputDetails.GridKeyDownTopRow += new EventHandler(this.uGrid_Details_GridKeyDownTopRow);
        }
        #endregion

        #region ■ private mothod
        /// <summary>
        /// アイコンの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : アイコンを設定する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            Infragistics.Win.UltraWinToolbars.ButtonTool clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            Infragistics.Win.UltraWinToolbars.LabelTool sectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            Infragistics.Win.UltraWinToolbars.LabelTool loginLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];

            closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            loginLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }

        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        /// <returns>Control</returns>
        /// <remarks>
        /// <br>Note       : 入力項目チェック処理を行う。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private Control CheckInputPara()
        {
            string errMessage = null;

            # region 必須入力チェック

            //日付
            DateGetAcs.CheckDateRangeResult cdrResult;

           // 期間（開始～終了）
            if (CallCheckDateForYearMonthDayRange(out cdrResult, ref tDateEdit_St_During, ref tDateEdit_Ed_During) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始日{0}", ct_NoInput);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_St_During.Focus();
                            return tDateEdit_St_During;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始日{0}", ct_InputError);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_St_During.Focus();
                            return tDateEdit_St_During;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了日{0}", ct_NoInput);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_Ed_During.Focus();
                            return tDateEdit_Ed_During;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了日{0}", ct_InputError);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_Ed_During.Focus();
                            return tDateEdit_Ed_During;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象日{0}", ct_RangeError);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_Ed_During.Focus();
                            return tDateEdit_Ed_During;
                        }
                }
            }

            # endregion 必須入力チェック

            return null;
           }

        /// <summary>
       /// 日付(YYYYMMDD)チェック処理呼び出し
       /// </summary>
       /// <param name="cdrResult"></param>
       /// <param name="tde_St_OrderDataCreateDate"></param>
       /// <param name="tde_Ed_OrderDataCreateDate"></param>
       /// <returns>入力チェック結果</returns>
       /// <remarks>
       /// <br>Note       : 日付の入力チェックを行います。</br>
       /// <br>Programmer : 呉元嘯</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
        private bool CallCheckDateForYearMonthDayRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
       {
           cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, true);
           return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
       }

        /// <summary>
       /// ログオン時オンライン状態チェック処理
       /// </summary>
       /// <returns>チェック処理結果</returns>
       /// <remarks>
       /// <br>Note       : ログオン時オンライン状態チェック処理を行う。 </br>
       /// <br>Programmer : 呉元嘯</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
        private bool CheckOnline()
       {
           if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
           {
               return false;
           }
           else
           {
               // ローカルエリア接続状態によるオンライン判定
               if (CheckRemoteOn() == false)
               {
                   return false;
               }
           }

           return true;
       }

        /// <summary>
       /// リモート接続可能判定
       /// </summary>
       /// <returns>判定結果</returns>
       /// <remarks>
       /// <br>Note       : リモート接続可能判定処理を行う。 </br>
       /// <br>Programmer : 呉元嘯</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
        private bool CheckRemoteOn()
       {
           bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

           if (isLocalAreaConnected == false)
           {
               // インターネット接続不能状態
               return false;
           }
           else
           {
               return true;
           }
       }

        /// <summary>
       /// 画面ヘッダクリア処理
       /// </summary>
       /// <returns></returns>
       /// <remarks>
       /// <br>Note       : 画面ヘッダクリア処理を行う。 </br>
       /// <br>Programmer : 呉元嘯</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
        private void Clear()
       {
           this.tDateEdit_St_During.SetDateTime(DateTime.Today);
           this.tDateEdit_Ed_During.SetDateTime(DateTime.Today);

           this._mailHistAcs.ClearMailHisResultDataTable();
       }

       /// <summary>
       /// グリッド最上位行キーダウンイベント
       /// </summary>
       /// <param name="sender">対象オブジェクト</param>
       /// <param name="e">イベントパラメータクラス</param>
       /// <remarks>
       /// <br>Note       : 画面ヘッダクリア処理を行う。 </br>
       /// <br>Programmer : 呉元嘯</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
       private void uGrid_Details_GridKeyDownTopRow(object sender, EventArgs e)
       {
           this.tDateEdit_Ed_During.Focus();
       }

        # region [検索]
        /// <summary>
        /// メール送信履歴検索実行処理
        /// </summary>
        /// <returns>Control</returns>
        /// <remarks>
        /// <br>Note       : メール送信履歴検索を行う。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private Control SearchMailHisResults()
        {
            // 入力項目チェック処理
            Control control = this.CheckInputPara();

            if (control != null)
            {
                return control;
            }

            this._mailHistAcs.ClearMailHisResultDataTable();

            // 読込条件パラメータクラス設定処理
            this.SetReadPara(ref _qrMailHistSearchCond);

            // オフライン状態チェック	
            if (!CheckOnline())
            {
                // オフライン状態チェック	
                if (!CheckOnline())
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,
                        "メール送信履歴",
                        "メール送信履歴" + "データ読み込みに失敗しました。",
                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                return control;
            }

            string errMess = string.Empty;
            int status = this._mailHistAcs.SearchQRMailHist(_qrMailHistSearchCond, out errMess);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._inputDetails.uGrid_Details.Focus();
                this._inputDetails.uGrid_Details.ActiveRow = this._inputDetails.uGrid_Details.Rows[0];
                this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "該当データが存在しません。",
                            0,
                            MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            this.Name,
                            errMess,
                            0,
                            MessageBoxButtons.OK);
            }
            return null;
        }

        /// <summary>
        /// 読込条件パラメータ設定処理
        /// </summary>
        /// <param name="qrMailHistSearchCond">検索条件</param>
        /// <remarks>
        /// <br>Note        : 読込条件パラメータ設定を行う</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/05/25</br>
        /// </remarks>
        public void SetReadPara(ref QrMailHistSearchCond qrMailHistSearchCond)
        {
            // 検索条件を格納するパラメータクラスのインスタンスを作成
            qrMailHistSearchCond = new QrMailHistSearchCond();
            qrMailHistSearchCond.TransmitDateSt = this.tDateEdit_St_During.GetDateTime();
            qrMailHistSearchCond.TransmitDateEd = this.tDateEdit_Ed_During.GetDateTime();
        }
        # endregion

        #endregion

        #region ■ event
        /// <summary>フォームロード</summary>
        /// <param name="sender">イベントのソース</param>
        /// <param name="e">イベントデータを格納している</param>
        /// <remarks>
        /// <br>Note        : フォームロード処理を行う</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/05/25</br>
        /// </remarks>
        private void PMKHN04151UA_Load(object sender, EventArgs e)
        {
            this.panel_Detail.Controls.Add(this._inputDetails);
            this._inputDetails.Dock = DockStyle.Fill;
            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 自拠点コードを取得する
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();

            this.ButtonInitialSetting();

            // 元に戻す処理
            this.Clear();

            this.timer_InitialSetFocus.Enabled = true;

        }

        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMKHN04151UA_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 矢印キーでのフォーカス移動イベントを行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //-----------------------------------------------------
                // 送信日（開始）
                //-----------------------------------------------------
                case "tDateEdit_St_During":
                    {
                        # region [フォーカス制御]
                        // フォーカス制御
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this._inputDetails.uGrid_Details;
                                        if ((this._inputDetails.uGrid_Details.ActiveRow == null) && (this._inputDetails.uGrid_Details.Rows.Count != 0))
                                        {
                                            this._inputDetails.uGrid_Details.ActiveRow = this._inputDetails.uGrid_Details.Rows[0];
                                            this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
                                        }
                                        else if (this._inputDetails.uGrid_Details.Rows.Count == 0)
                                        {
                                            this.SearchMailHisResults();
                                            if (this._inputDetails.uGrid_Details.Rows.Count == 0)
                                            {
                                                e.NextCtrl = null;
                                            }
                                        }
                                        else
                                        {
                                            this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
                                        } 
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
                //-----------------------------------------------------
                // 送信日（終了）
                //-----------------------------------------------------
                case "tDateEdit_Ed_During":
                    {
                        # region [フォーカス制御]
                        // フォーカス制御
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // 移動しない
                                        e.NextCtrl = this._inputDetails.uGrid_Details;
                                        if ((this._inputDetails.uGrid_Details.ActiveRow == null) && (this._inputDetails.uGrid_Details.Rows.Count != 0))
                                        {
                                            this._inputDetails.uGrid_Details.ActiveRow = this._inputDetails.uGrid_Details.Rows[0];
                                            this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
                                        }
                                        else if (this._inputDetails.uGrid_Details.Rows.Count == 0)
                                        {
                                            this.SearchMailHisResults();
                                            if (this._inputDetails.uGrid_Details.Rows.Count == 0)
                                            {
                                                e.NextCtrl = null;
                                            }
                                        }
                                        else
                                        {
                                            this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
                                        }
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
                //-----------------------------------------------------
                // 明細
                //-----------------------------------------------------
                case "uGrid_Details":
                    {
                        # region [フォーカス制御]
                        // フォーカス制御
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        if (this._inputDetails.uGrid_Details.ActiveRow != null)
                                        {
                                            // メール内容表示画面の表示
                                            this._inputDetails.ShowMailContent();
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
            }

            if (e.Key == Keys.Up && _inputDetails.uGrid_Details.ActiveRow != null)
            {
                // 最上行での↑キー
                if (this._inputDetails.uGrid_Details.ActiveRow.Index == 0)
                {
                    e.NextCtrl = tDateEdit_St_During;
                }
            }

        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        :ツールバーボタンクリックイベントを行う。 </br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/05/25</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        SearchMailHisResults();
                        break;

                    }
                case "ButtonTool_Clear":
                    {
                        this.Clear();
                        // 初期フォーカス
                        this.tDateEdit_St_During.Focus();
                        break;
                    }
            }

        }

        /// <summary>
        /// timer_InitialSetFocus_Tickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        :timer_InitialSetFocus_Tickイベントを行う。 </br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/05/25</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            // 初期化フォーカス
            this.timer_InitialSetFocus.Enabled = false;
            this.tDateEdit_St_During.Focus();
        }
        #endregion

    }

}