//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 目標自動設定
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/07/07  修正内容 : PVCS#262 対象期の表示内容不正
//           2009/07/13
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 目標自動設定
    /// </summary>
    /// <remarks>
    /// Note       : 目標自動設定処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.04.02<br />
    /// </remarks>
    public partial class PMKHN09451UA : Form
    {
        #region ■ Const Memebers ■
        private const string ct_ClassID = "PMKHN09451UA";
        private const string ALL_SECTIONCODE = "00";
        private const string ALL_SECTIONNAME = "全社";
        #endregion

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKHN09451UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Execution"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._mainOfficeFunc = false;
            this._secInfoAcs = new SecInfoAcs(1);
            startMonthDt = new DateTime();
            nowDateTime = new DateTime();
            this._objAutoSetAcs = ObjAutoSetAcs.GetInstance();
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
        private SecInfoAcs _secInfoAcs;                         // 拠点マスタアクセスクラス
        private ObjAutoSetAcs _objAutoSetAcs;
        List<DateTime> yearMonth;
        DateTime startMonthDt;
        DateTime nowDateTime;
        Int32 appMonth = 0;
        string baseCodeTemp = "00";
        # endregion

        # region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
        private void PMKHN09451UA_Load(object sender, EventArgs e)
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
        /// <summary>
        /// 画面のフォーカス処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面のフォーカス処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.tce_CustomerDiv.Focus();
        }
        # endregion

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }
        # endregion ■ ボタン初期設定処理 ■

        #region ■ 画面データの初期化処理 ■
        /// <summary>
        /// 画面データの初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面データのを行う</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2008.12.01</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // 拠点
            this.tce_SectionDiv.SelectedIndex = 0;
            // 得意先
            this.tce_CustomerDiv.SelectedIndex = 0;
            // 担当者
            this.tce_TantowusyaDiv.SelectedIndex = 0;
            // 受注者
            this.tce_ReceiveOrderDiv.SelectedIndex = 0;
            // 発行者
            this.tce_PublisherDiv.SelectedIndex = 0;
            // 地区
            this.tce_DistrictDiv.SelectedIndex = 0;
            // 業種
            this.tce_TypeBusinessDiv.SelectedIndex = 0;
            // 販売区分
            this.tce_SalesDivisionDiv.SelectedIndex = 0;
            // 対象金額
            this.tce_ObjMoneyDiv.SelectedIndex = 0;
            // 対象期
            this.tce_ObjectPeriodDiv.SelectedIndex = 0;
            // 比率
            this.tce_RatioDiv.SelectedIndex = 0;
            // 単位
            this.tce_UnitDiv.SelectedIndex = 0;
            // 端数処理
            this.tce_FractionProDiv.SelectedIndex = 0;
            // 拠点コード
            this.tNedit_SectionCode.Text = "00";
            // 拠点名称
            this.uLabel_SectionName.Text = ALL_SECTIONNAME;
        }
        #endregion ■ 画面データの初期化処理 ■

        #region ■ 拠点ガイド処理 ■
        /// <summary>
        /// 拠点ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2008.11.26</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
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
                this.tNedit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                this.tce_ObjMoneyDiv.Focus();
            }
        }
        #endregion ■ 拠点ガイド処理 ■

        #region ■ ツールバーボタンクリックイベント処理 ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
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
                case "ButtonTool_Execution":
                    {

                        // 目標自動設定
                        bool inputCheck = this.ExecutBeforeCheck();
                        if (inputCheck)
                        {
                            if (this.tce_ObjectPeriodDiv.SelectedIndex == 1 && 0 >= this.tNedit_Past.GetInt())
                            {
                                // ADD 2009/07/13 --->>>
                                TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Text,
                                "適用月の指定に誤りがあります。",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                this.tNedit_Past.Focus();
                                // ADD 2009/07/13 ---<<<
                                break;
                            }

                            bool isExecution = this.Execution();

                            if (!isExecution)
                            {
                                TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Text,
                                this.Text + "目標自動設定が失敗しました。",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                // 登録完了
                                SaveCompletionDialog dialog = new SaveCompletionDialog();
                                dialog.ShowDialog(2);
                                this.tce_CustomerDiv.Focus();
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 対象期区分選択イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 対象期区分を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.05.26</br>
        /// </remarks>
        private void tce_ObjectPeriodDiv_ValueChanged(object sender, EventArgs e)
        {
            // 画面．対象期が「前期」の場合、適用月を入力できない。
            if (this.tce_ObjectPeriodDiv.SelectedIndex == 0)
            {
                this.tNedit_Past.Text = string.Empty;
                this.tNedit_Past.Enabled = false;
                if (this.tce_RatioDiv.Enabled == false)
                {
                    this.tce_RatioDiv.Enabled = true;
                }
            }
            else
            // 画面．対象期が「今期」の場合、比率が「平均」のみを選択できる
            {
                // 現在処理年月取得
                this._objAutoSetAcs.GetThisYearMonth(out nowDateTime);

                // 会計年度取得 当年 → 0
                this._objAutoSetAcs.GetCompanyInf(out yearMonth);

                if (null != yearMonth && yearMonth.Count > 0)
                {
                    startMonthDt = yearMonth[0];
                    Int32 startMonthInt = startMonthDt.Month;
                    Int32 nowDtMonthInt = nowDateTime.Month;
                    Int32 startYearInt = startMonthDt.Year;
                    Int32 nowDtYearInt = nowDateTime.Year;

                    if (nowDtYearInt != startYearInt)
                    {
                        appMonth = nowDtMonthInt - startMonthInt + 12;
                    }
                    else
                    {
                        appMonth = nowDtMonthInt - startMonthInt;
                    }
                }

                this.tNedit_Past.Enabled = true;
                this.tNedit_Past.Text = Convert.ToString(appMonth);
                this.tce_RatioDiv.SelectedIndex = 0;
                this.tce_RatioDiv.Enabled = false;
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.05.26</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = ALL_SECTIONNAME;
                return sectionName;
            }

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォームロードイベント処理発生します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.05.20</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 拠点コード
                case "tNedit_SectionCode":
                    {
                        string sectionCode = string.Empty;
                        // 入力無し
                        if (string.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
                        {
                            this.tNedit_SectionCode.Text = string.Empty;
                            this.uLabel_SectionName.Text = string.Empty;

                            baseCodeTemp = string.Empty;

                            break;
                        }
                        else
                        {
                            sectionCode = this.tNedit_SectionCode.Text;
                        }
                        
                        if (!string.IsNullOrEmpty(GetSectionName(sectionCode)))
                        {
                            // 結果を画面に設定
                            string baseName = GetSectionName(sectionCode);
                            this.uLabel_SectionName.Text = baseName;
                            baseCodeTemp = sectionCode;
                            if (e.ShiftKey)
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = tce_SalesDivisionDiv;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = tce_ObjMoneyDiv;
                                }
                            }

                        }
                        else
                        {
                            DialogResult dialogResult = TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            ct_ClassID,							// アセンブリID
                            "対象拠点がマスタに存在しません。",	// 表示するメッセージ
                            0,									    // ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン

                            this.tNedit_SectionCode.Text = baseCodeTemp;

                            // ↓ 2009.07.07 劉洋 modify PVCS NO.307
                            // e.NextCtrl = this.uButton_SectionGuide;
                            e.NextCtrl = e.PrevCtrl;
                            // ↑ 2009.07.07 劉洋　

                            return;
                        }
                        break;
                    }
                // ADD 譚洪 2009/07/07 --->>> 
                // 適用月
                case "tNedit_Past":
                    {
                        // 入力無し
                        if (string.IsNullOrEmpty(this.tNedit_Past.Text.Trim()))
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ct_ClassID,
                            "",
                            "",
                            "",
                            "適用月を指定してください。",
                            0,
                            null,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.OK)
                            {
                                e.NextCtrl = this.tNedit_Past;
                            }
                        }
                        break;
                    }
                // ADD 譚洪 2009/07/07 ---<<<
            }
        }

        #endregion

        #region ■ 目標自動設定処理 ■
        /// <summary>
        /// 出荷取消処理
        /// </summary>
        /// <returns>true:出荷取消完了 false:出荷取消未完了</returns>
        /// <remarks>
        /// <br>Note		: 日付入力のチェックを行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2008.12.01</br>
        /// </remarks>
        private bool Execution()
        {
            bool isExecution = false;

            // オフライン状態チェック						
            if (!_objAutoSetAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "画面初期化処理に失敗しました。",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }

            ObjAutoSetWork objAutoSetWork = new ObjAutoSetWork();
            // 企業コード
            objAutoSetWork.EnterpriseCode = _enterpriseCode;
            // 拠点コード
            objAutoSetWork.SecCode = this.tNedit_SectionCode.Text;
            // 拠点DRP
            objAutoSetWork.SecDrp = this.tce_SectionDiv.SelectedIndex;
            // 得意先DRP
            objAutoSetWork.CustomerDrp = this.tce_CustomerDiv.SelectedIndex;
            // 担当者DRP
            objAutoSetWork.TantosyaDrp = this.tce_TantowusyaDiv.SelectedIndex;
            // 受注者DRP
            objAutoSetWork.ReceOrdDrp = this.tce_ReceiveOrderDiv.SelectedIndex;
            // 発行者DRP
            objAutoSetWork.PublisherDrp = this.tce_PublisherDiv.SelectedIndex;
            // 地区DRP
            objAutoSetWork.DistrictDrp = this.tce_DistrictDiv.SelectedIndex;
            // 業種DRP
            objAutoSetWork.TypeBusinessDrp = this.tce_TypeBusinessDiv.SelectedIndex;
            // 販売区分DRP
            objAutoSetWork.SalesDivisionDrp = this.tce_SalesDivisionDiv.SelectedIndex;
            // 対象金額DRP
            objAutoSetWork.ObjMoneyDrp = this.tce_ObjMoneyDiv.SelectedIndex;
            // 対象期DRP
            objAutoSetWork.ObjPeriodDrp = this.tce_ObjectPeriodDiv.SelectedIndex;
            // 比率DRP
            objAutoSetWork.RatioDrp = this.tce_RatioDiv.SelectedIndex;
            // 単位DRP
            objAutoSetWork.UnitDrp = this.tce_UnitDiv.SelectedIndex;
            // 端数処理DRP
            objAutoSetWork.FractionProcDrp = this.tce_FractionProDiv.SelectedIndex;
            // 売上目標
            objAutoSetWork.SalesTarget = this.tNedit_SalesTargetObj.GetInt();
            // 粗利目標
            objAutoSetWork.GroMarginTarget = this.tNedit_GrossMarginObj.GetInt();
            // 数量目標
            objAutoSetWork.AmountTarget = this.tNedit_AmountObj.GetInt();
            // 過去
            objAutoSetWork.Past = this.tNedit_Past.GetInt();

            string baseCode = this.tNedit_SectionCode.Text.Trim();

            this.Cursor = Cursors.WaitCursor;

            int status = _objAutoSetAcs.ObjAutoSetProc(_enterpriseCode, baseCode, objAutoSetWork, yearMonth);

            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isExecution = true;
            }

            return isExecution;
        }
        #endregion ■ 目標自動設定処理 ■

        #region ■ 入力チェック処理 ■
        /// <summary>
        /// 目標自動設定前チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 目標自動設定前チェック処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2008.12.01</br>
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
        /// <br>Date		: 2008.12.01</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                ct_ClassID,
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
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2008.12.01</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_NoInput = "を指定してください。";
            const string ct_InputError = "の指定に誤りがあります。";

            // 拠点
            if (string.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
            {
                errMessage = string.Format("拠点{0}", ct_NoInput);
                errComponent = this.tNedit_SectionCode;
                status = false;

                return status;
            }
            // 売上目標
            if (this.tNedit_SalesTargetObj.GetInt() == 0)
            {
                errMessage = string.Format("売上目標{0}", ct_NoInput);
                errComponent = this.tNedit_SalesTargetObj;
                status = false;

                return status;
            }
            // 粗利目標
            if (this.tNedit_GrossMarginObj.GetInt() == 0)
            {
                errMessage = string.Format("粗利目標{0}", ct_NoInput);
                errComponent = this.tNedit_GrossMarginObj;
                status = false;

                return status;
            }
            // 数量目標
            if (this.tNedit_AmountObj.GetInt() == 0)
            {
                errMessage = string.Format("数量目標{0}", ct_NoInput);
                errComponent = this.tNedit_AmountObj;
                status = false;

                return status;
            }
            // 適用月チェック
            // 画面．対象期が「今期」の場合、１～初期表示された値。
            if (this.tce_ObjectPeriodDiv.SelectedIndex == 1)
            {
                if (this.tNedit_Past.GetInt() > appMonth)
                {
                    errMessage = string.Format("適用月{0}", ct_InputError);
                    errComponent = this.tNedit_Past;
                    status = false;

                    return status;
                }
            }
            // 画面項目の実行前チェック

            // 対象マスタ設定項目が全て「行わない」の場合、エラーとする。
            if (this.tce_SectionDiv.SelectedIndex == 0
                && this.tce_CustomerDiv.SelectedIndex == 0
                && this.tce_TantowusyaDiv.SelectedIndex == 0
                && this.tce_ReceiveOrderDiv.SelectedIndex == 0
                && this.tce_PublisherDiv.SelectedIndex == 0
                && this.tce_DistrictDiv.SelectedIndex == 0
                && this.tce_TypeBusinessDiv.SelectedIndex == 0
                && this.tce_SalesDivisionDiv.SelectedIndex == 0)
            {
                errMessage = "対象マスタを設定してください。";
                errComponent = this.tce_CustomerDiv;
                status = false;

                return status;
            }

            // 得意先の目標設定が「行う」の場合で、他の設定項目に「得意先の目標から再設定」が存在した場合はエラーとする。
            if (this.tce_CustomerDiv.SelectedIndex == 1
                && (this.tce_SectionDiv.SelectedIndex == 2
                || this.tce_TantowusyaDiv.SelectedIndex == 2
                || this.tce_DistrictDiv.SelectedIndex == 2
                || this.tce_TypeBusinessDiv.SelectedIndex == 2))
            {
                errMessage = string.Format("得意先{0}", ct_InputError);
                errComponent = this.tce_CustomerDiv;
                status = false;

                return status;
            }
            // 担当者の目標設定が「行う」の場合で、他の設定項目に「担当者の目標から再設定」が存在した場合はエラーとする。
            if (this.tce_TantowusyaDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 3)
            {
                errMessage = string.Format("担当者{0}", ct_InputError);
                errComponent = this.tce_TantowusyaDiv;
                status = false;

                return status;
            }
            // 発行者の目標設定が「行う」の場合で、他の設定項目に「発行者の目標から再設定」が存在した場合はエラーとする。
            if (this.tce_PublisherDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 5)
            {
                errMessage = string.Format("発行者{0}", ct_InputError);
                errComponent = this.tce_PublisherDiv;
                status = false;

                return status;
            }
            // 受注者の目標設定が「行う」の場合で、他の設定項目に「受注者の目標から再設定」が存在した場合はエラーとする。
            if (this.tce_ReceiveOrderDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 4)
            {
                errMessage = string.Format("受注者{0}", ct_InputError);
                errComponent = this.tce_ReceiveOrderDiv;
                status = false;

                return status;
            }
            // 地区の目標設定が「行う」の場合で、他の設定項目に「地区の目標から再設定」が存在した場合はエラーとする。
            if (this.tce_DistrictDiv.SelectedIndex == 1
                 && this.tce_SectionDiv.SelectedIndex == 6)
            {
                errMessage = string.Format("地区{0}", ct_InputError);
                errComponent = this.tce_DistrictDiv;
                status = false;

                return status;
            }
            // 業種の目標設定が「行う」の場合で、他の設定項目に「業種の目標から再設定」が存在した場合はエラーとする。
            if (this.tce_TypeBusinessDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 7)
            {
                errMessage = string.Format("業種{0}", ct_InputError);
                errComponent = this.tce_TypeBusinessDiv;
                status = false;

                return status;
            }
            // 販売区分の目標設定が「行う」の場合で、他の設定項目に「販売区分の目標から再設定」が存在した場合はエラーとする。
            if (this.tce_SalesDivisionDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 8)
            {
                errMessage = string.Format("販売区分{0}", ct_InputError);
                errComponent = this.tce_SalesDivisionDiv;
                status = false;

                return status;
            }
            // 対象期が「今期」の場合、適用月を入力しない、エラーとする。
            if (this.tce_ObjectPeriodDiv.SelectedIndex == 1
                && string.IsNullOrEmpty(this.tNedit_Past.Text.Trim()))
            {
                errMessage = string.Format("適用月{0}", ct_NoInput); ;
                errComponent = this.tNedit_Past;
                status = false;

                return status;
            }

            // 適用月 > 今回月次更新年月、エラーとする。
            if (this.tNedit_Past.GetInt() > appMonth)
            {
                errMessage = string.Format("適用月{0}", ct_NoInput); ;
                errComponent = this.tNedit_Past;
                status = false;

                return status;
            }

            return status;
        }
        #endregion ■ 入力チェック処理 ■

        #region ■ Control Event ■
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 譚洪</br>
        /// <br>Date		: 2009.05.07</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ObjMstSetGroup") ||
                (e.Group.Key == "DetailSetGroup"))
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.05.07</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ObjMstSetGroup") ||
                (e.Group.Key == "DetailSetGroup"))
            {
                e.Cancel = true;
            }
        }
        #endregion

    }
}