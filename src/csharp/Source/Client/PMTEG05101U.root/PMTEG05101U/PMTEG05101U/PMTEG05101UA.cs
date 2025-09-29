//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 決済手形消込処理
// プログラム概要   : 決済手形消込処理フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 決済手形消込処理
    /// </summary>
    /// <remarks>
    /// Note       : 決済手形消込の処理を行う。<br />
    /// Programmer : 張義<br />
    /// Date       : 2010/04/22<br />
    /// </remarks>
    public partial class PMTEG05101UA : Form
    {
        #region ■ Const Memebers ■
        private const string PROGRAM_ID = "PMTEG05101U";
        /// <summary>チェック時メッセージ「売上月次締日取得の初期処理でエラーが発生しました。」</summary>
        private const string MSG_TOTALDAYREC_INITIALIE_FAILED = "売上月次締日取得の初期処理でエラーが発生しました。";
        /// <summary>チェック時メッセージ「仕入月次締日取得の初期処理でエラーが発生しました。」</summary>
        private const string MSG_TOTALDAYPAY_INITIALIE_FAILED = "仕入月次締日取得の初期処理でエラーが発生しました。";
        #endregion

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>		
        /// <br>Note		: コンストラクタの初期化を行う。</br>
        /// <br>Programmer	: 張義</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        public PMTEG05101UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._objAutoSetAcs = ObjAutoSetAcs.GetInstance();
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
            this._settlementBillDelAcs = SettlementBillDelAcs.GetInstance();
        }
        # endregion

        # region ■ private field ■
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executionButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        // 企業コード
        private string _enterpriseCode;
        // 前回締処理月
        private DateTime _prevTotalMonth;
        private ObjAutoSetAcs _objAutoSetAcs;
        //日付取得部品
        private DateGetAcs _dateGet;
        //決済手形消込処理アクセスクラス
        private SettlementBillDelAcs _settlementBillDelAcs;
        #endregion

        # region ■ フォームロード ■
        /// <summary>
        /// 画面の初期化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の初期化を行う。</br>
        /// <br>Programmer	: 張義</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void PMTEG05101UA_Load(object sender, EventArgs e)
        {
            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // ボタン初期設定処理
            this.ButtonInitialSetting();
            // 画面データの初期化設定
            this.InitializeScreen();
        }

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理を行う</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this.Main_UTabControl.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2];

        }
        # endregion

        #region ■ 画面データの初期化処理 ■
        /// <summary>
        /// 画面データの初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面データの初期化処理を行う</br>
        /// <br>Programmer	: 張義</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // 手形区分
            this.BillDiv_tComboEditor.SelectedIndex = 0;

            // 処理年月を取得
            this.ProcessDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;

            //仕入支払管理オプション
            PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            //買掛有の場合、初期フォーカスは手形区分とする
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this.BillDiv_tComboEditor.Focus();
            }
            else
            {
                this.BillDiv_tComboEditor.Enabled = false;
                this.BillDiv_tComboEditor.Appearance.BackColor = Color.Gray;
                this.ProcessDate_tDateEdit.Focus();
            }
            //前回月次更新日
            GetHisTotalDayProc();
        }
        #endregion

        #endregion

        #region ■ 前回月次更新日取得初期処理 ■
        /// <summary>
        /// 前回月次更新日取得初期処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 前回月次更新日取得初期処理です。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        private void GetHisTotalDayProc()
        {
            int status;

            // 前回月次更新日取得前初期処理
            //前回月次更新日
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            status = totalDayCalculator.InitializeHisMonthlyAccRec();

            int billDivIndex = this.BillDiv_tComboEditor.SelectedIndex;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 今回および前回の締め日/月を取得(月と日は異なる場合がある)
                //受取手形
                if (billDivIndex == 0)
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }
                else
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccPay(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }
                if (prevTotalDay == DateTime.MinValue)
                {
                    // 当月を設定
                    DateTime nowYearMonth;
                    this._dateGet.GetThisYearMonth(out nowYearMonth);

                    this.ProcessDate_tDateEdit.SetDateTime(nowYearMonth);
                }
                else
                {
                    // 売上前回月次更新日を設定
                    this.ProcessDate_tDateEdit.SetDateTime(prevTotalDay);
                }
                this._prevTotalMonth = this.ProcessDate_tDateEdit.GetDateTime();
            }
            else
            {
                // 初期処理失敗
                //受取手形
                if (billDivIndex == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYREC_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYPAY_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
            }
        }
        #endregion

        #region ■ 決済手形消込処理メッソド関連 ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 張義</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Run":
                    {
                        bool inputCheck = this.ExecutBeforeCheck();

                        if (inputCheck)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "処理を実行しますか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // 実行処理
                                this.ExecuteProcess();
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォームロードイベント処理発生します。</br>
        /// <br>Programmer	: 張義</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
        }

        #region ■ 入力チェック処理 ■
        /// <summary>
        /// 決済手形消込処理前チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 決済手形消込処理前チェック処理を行う。</br>
        /// <br>Programmer	: 張義</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private bool ExecutBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);


                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 張義</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                PROGRAM_ID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="errControl">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 張義</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string message, ref Control errControl)
        {
            message = "";
            bool result = true;
            errControl = null;

            DateGetAcs.CheckDateResult cdrResult;
            // 対象年月
            if (!CallCheckDateRange(out cdrResult, ref ProcessDate_tDateEdit))
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            message = "処理日を指定してください。";
                            result = false;
                            errControl = this.ProcessDate_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            message = "処理日の入力が不正です。";
                            result = false;
                            errControl = this.ProcessDate_tDateEdit;
                        }
                        break;
                }
                return result;
            }
            //入力日付＞前回月次更新日の場合はエラーとして再入力とする
            if (this.ProcessDate_tDateEdit.GetDateTime().CompareTo(this._prevTotalMonth) > 0)
            {
                message = "処理日は前回月次更新日以前（同日も含む）です。";
                result = false;
                errControl = this.ProcessDate_tDateEdit;
                this.ProcessDate_tDateEdit.SetDateTime(this._prevTotalMonth);
                return result;
            }

            return result;
        }

        /// <summary>
        /// 日付(YYYYMMDD)チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="TargetDate_tDateEdit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 日付(YYYYMMDD)チェックを行います。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateResult cdrResult, ref TDateEdit TargetDate_tDateEdit)
        {
            cdrResult = _dateGet.CheckDate(ref TargetDate_tDateEdit);
            return (cdrResult == DateGetAcs.CheckDateResult.OK);
        }
        #endregion
        #endregion

        #region ■ 決済手形消込処理 ■
        /// <summary>
        /// 決済手形消込処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 決済手形消込処理を行う。</br>
        /// <br>Programmer	: 張義</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            // 処理区分
            int procDiv = this.BillDiv_tComboEditor.SelectedIndex;

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "決済手形消込処理";
            form.Message = "現在、決済手形の消込処理中です。\r\nしばらくお待ちください";

            this.Cursor = Cursors.WaitCursor;
            // ダイアログ表示
            form.Show();
            int pieceDelete;
            int totalpiece;
            int status = this._settlementBillDelAcs.SettlementBillDelProc(this._enterpriseCode, this.ProcessDate_tDateEdit.GetLongDate(), 
                            TDateTime.DateTimeToLongDate(this._prevTotalMonth), this.BillDiv_tComboEditor.SelectedIndex, out pieceDelete, out totalpiece);

            // ダイアログを閉じる
            form.Close();
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "処理が完了しました。",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
                string totalpieceStr = string.Format("{0:N}", totalpiece);
                string pieceDeleteStr = string.Format("{0:N}", pieceDelete);
                this.PieceDelete_TextEditor.Text = pieceDeleteStr.Substring(0, pieceDeleteStr.Length - 3);
                this.PieceTotal_TextEditor.Text = totalpieceStr.Substring(0, totalpieceStr.Length - 3);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "該当データがありません。",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "処理中にエラーが発生しました。（" + status.ToString() + "）",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        #region ■ 手形区分コンボボックス変更 ■
        /// <summary>
        /// 手形区分コンボボックス変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 手形区分コンボボックス変更処理を行う。</br>
        /// <br>Programmer	: 張義</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void BillDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            //前回月次更新日取得初期処理
            GetHisTotalDayProc();
            this.PieceDelete_TextEditor.Clear();
            this.PieceTotal_TextEditor.Clear();
        }
        #endregion

        #region ■ 処理日変更 ■
        /// <summary>
        /// 処理日変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 処理日変更処理を行う。</br>
        /// <br>Programmer	: 張義</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void ProcessDate_tDateEdit_ValueChanged(object sender, EventArgs e)
        {
            this.PieceDelete_TextEditor.Clear();
            this.PieceTotal_TextEditor.Clear();
        }
        #endregion
    }
}