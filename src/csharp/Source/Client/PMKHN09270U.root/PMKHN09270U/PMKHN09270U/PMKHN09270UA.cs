//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 一括リアル更新
// プログラム概要   : 一括リアル更新フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/12/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 一括リアル更新
    /// </summary>
    /// <remarks>
    /// Note       : 一括リアル更新処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009/12/24<br />
    /// </remarks>
    public partial class PMKHN09270UA : Form
    {
        #region ■ Const Memebers ■
        private const string PROGRAM_ID = "PMKHN09270U";
        #endregion

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>		
        /// <br>Note		: コンストラクタの処理化を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        public PMKHN09270UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._mainOfficeFunc = false;
            this._objAutoSetAcs = ObjAutoSetAcs.GetInstance();
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
            this._allRealUpdToolAcs = AllRealUpdToolAcs.GetInstance();
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
        private string _enterpriseCode;                         // 企業コード
        private bool _mainOfficeFunc;                           // 本社/拠点情報
        private ObjAutoSetAcs _objAutoSetAcs;
        //日付取得部品
        private DateGetAcs _dateGet;
        private AllRealUpdToolAcs _allRealUpdToolAcs;
        #endregion

        # region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void PMKHN09270UA_Load(object sender, EventArgs e)
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
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.uButton_SectionGuideStr.ImageList = this._imageList16;
            this.uButton_SectionGuideStr.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SectionGuideEnd.ImageList = this._imageList16;
            this.uButton_SectionGuideEnd.Appearance.Image = (int)Size16_Index.STAR1;
        }
        # endregion

        #region ■ 画面データの初期化処理 ■
        /// <summary>
        /// 画面データの初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面データのを行う</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // 拠点
            this.tComboEditor_ProcDiv.SelectedIndex = 0;

            // 処理年月を取得
            this.TargetDateSt_tDateEdit.DateFormat = emDateFormat.df4Y2M;
            this.TargetDateEd_tDateEdit.DateFormat = emDateFormat.df4Y2M;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                // 売上今回月次更新日を設定
                this.TargetDateSt_tDateEdit.SetDateTime(currentTotalMonth);
                this.TargetDateEd_tDateEdit.SetDateTime(currentTotalMonth);
            }
            else
            {
                // 当月を設定
                DateTime nowYearMonth;
                this._dateGet.GetThisYearMonth(out nowYearMonth);

                this.TargetDateSt_tDateEdit.SetDateTime(nowYearMonth);
                this.TargetDateEd_tDateEdit.SetDateTime(nowYearMonth);
            }
        }
        #endregion

        #region ■ 拠点ガイド処理 ■
        /// <summary>
        /// 拠点ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void uButton_SectionGuideStr_Click(object sender, EventArgs e)
        {
            if (!_objAutoSetAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                "拠点ガイド画面初期化処理に失敗しました。",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCodeStr.Text = secInfoSet.SectionCode.Trim();
            }
        }

        /// <summary>
        /// 拠点ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void uButton_SectionGuideEnd_Click(object sender, EventArgs e)
        {
            if (!_objAutoSetAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                "拠点ガイド画面初期化処理に失敗しました。",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCodeEnd.Text = secInfoSet.SectionCode.Trim();
            }
        }
        #endregion
        #endregion

        #region ■ 一括リアル更新処理メッソド関連 ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009/12/24</br>
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
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 拠点コード
                case "tNedit_SectionCodeStr":
                    {
                        if ("00".Equals(this.tNedit_SectionCodeStr.Text)
                            || "0".Equals(this.tNedit_SectionCodeStr.Text))
                        {
                            this.tNedit_SectionCodeStr.Text = string.Empty;
                        }
                        break;
                    }
                case "tNedit_SectionCodeEnd":
                    {
                        if ("00".Equals(this.tNedit_SectionCodeEnd.Text)
                            || "0".Equals(this.tNedit_SectionCodeEnd.Text))
                        {
                            this.tNedit_SectionCodeEnd.Text = string.Empty;
                        }
                        break;
                    }
            }
        }

        #region ■ 入力チェック処理 ■
        /// <summary>
        /// 一括リアル更新前チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 一括リアル更新前チェック処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009/12/24</br>
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
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009/12/24</br>
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
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

            const string ct_NoInput = "を指定してください。";
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";

            // 拠点開始
            string sectionCodeStr = this.tNedit_SectionCodeStr.Text;
            int resultStr = 0;
            if (!string.IsNullOrEmpty(sectionCodeStr) && !int.TryParse(sectionCodeStr, out resultStr))
            {
                message = string.Format("拠点{0}", ct_InputError);
                errControl = this.tNedit_SectionCodeStr;
                result = false;
                return result;
            }

            // 拠点終了
            string sectionCodeEnd = this.tNedit_SectionCodeEnd.Text;
            int resultEnd = 0;
            if (!string.IsNullOrEmpty(sectionCodeEnd) && !int.TryParse(sectionCodeEnd, out resultEnd))
            {
                message = string.Format("拠点{0}", ct_InputError);
                errControl = this.tNedit_SectionCodeEnd;
                result = false;
                return result;
            }

            // 拠点大小チェック
            if (!string.IsNullOrEmpty(sectionCodeStr) && !string.IsNullOrEmpty(sectionCodeEnd) && resultStr > resultEnd)
            {
                message = string.Format("拠点{0}", ct_RangeError);
                errControl = this.tNedit_SectionCodeStr;
                result = false;
                return result;
            }

            DateGetAcs.CheckDateRangeResult cdrResult;
            // 対象年月
            if (CallCheckDateRange(out cdrResult, ref TargetDateSt_tDateEdit, ref TargetDateEd_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            message = string.Format("開始対象年月{0}", ct_NoInput);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("開始対象年月{0}", ct_InputError);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            message = string.Format("終了対象年月{0}", ct_NoInput);
                            errControl = this.TargetDateEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("終了対象年月{0}", ct_InputError);
                            errControl = this.TargetDateEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("対象年月{0}", ct_RangeError);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                }
                return result;
            }
            return true;
        }

        /// <summary>
        /// 日付(YYYYMMDD)チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="TargetDateSt_tDateEdit"></param>
        /// <param name="TargetDateEd_tDateEdit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 日付(YYYYMMDD)チェックを行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit TargetDateSt_tDateEdit, ref TDateEdit TargetDateEd_tDateEdit)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref TargetDateSt_tDateEdit, ref TargetDateEd_tDateEdit, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        #endregion
        #endregion

        #region ■ 一括リアル更新 ■
        /// <summary>
        /// 一括リアル更新処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 一括リアル更新処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            // 処理区分
            int procDiv = this.tComboEditor_ProcDiv.SelectedIndex;
            // 処理区分が「売上」の場合
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork = new MTtlSalesUpdParaWork();
            mTtlSalesUpdParaWork.EnterpriseCode = this._enterpriseCode;
            mTtlSalesUpdParaWork.AddUpSecCodeSt = this.tNedit_SectionCodeStr.Text.Trim();
            mTtlSalesUpdParaWork.AddUpSecCodeEd = this.tNedit_SectionCodeEnd.Text.Trim();
            mTtlSalesUpdParaWork.AddUpYearMonthSt = (this.TargetDateSt_tDateEdit.GetLongDate() / 100);
            mTtlSalesUpdParaWork.AddUpYearMonthEd = (this.TargetDateEd_tDateEdit.GetLongDate() / 100);
            mTtlSalesUpdParaWork.SlipRegDiv = 1;
            mTtlSalesUpdParaWork.MTtlSalesPrcFlg = 1;
            mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg = 1;
            // 処理区分が「仕入」の場合
            MTtlStockUpdParaWork mTtlStockUpdParaWork = new MTtlStockUpdParaWork();
            mTtlStockUpdParaWork.EnterpriseCode = this._enterpriseCode;
            mTtlStockUpdParaWork.StockSectionCdSt = this.tNedit_SectionCodeStr.Text.Trim();
            mTtlStockUpdParaWork.StockSectionCdEd = this.tNedit_SectionCodeEnd.Text.Trim();
            mTtlStockUpdParaWork.StockDateYmSt = (this.TargetDateSt_tDateEdit.GetLongDate() / 100);
            mTtlStockUpdParaWork.StockDateYmEd = (this.TargetDateEd_tDateEdit.GetLongDate() / 100);
            mTtlStockUpdParaWork.SlipRegDiv = 1;

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "一括リアル更新";
            form.Message = "現在、処理中です。";

            this.Cursor = Cursors.WaitCursor;
            // ダイアログ表示
            form.Show();

            int status = _allRealUpdToolAcs.AllRealUpdToolProc(mTtlSalesUpdParaWork, mTtlStockUpdParaWork, procDiv);

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
    }
}