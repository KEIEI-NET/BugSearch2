//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 従業員設定マスタ抽出条件画面
// プログラム概要   : 従業員設定マスタ抽出条件の設定・参照処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI菅原 庸平
// 作 成 日   2012.07.26 修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 従業員設定マスタ抽出条件画面フォームクラス
    /// </summary>
    /// <remarks>
    /// Note       : 従業員設定マスタ抽出条件の設定・参照処理です。<br />
    /// Programmer : FSI菅原 庸平<br />
    /// Date       : 2012.07.26<br />
    /// </remarks>
    public partial class PMKYO01511UA : Form
    {

        #region ■ Const Memebers ■

        private const string PROGRAM_ID = "PMKYO01511UA";
        
        #endregion ■ Const Memebers ■

        # region ■ Private field ■

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        // 拠点マスタアクセス
        SecInfoSetAcs _secInfoSetAcs;
        // 従業員マスタアクセス
        private EmployeeAcs _employeeAcs;
        
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

        # endregion ■ Private field ■

        #region ■ Public Memebers ■
        /// <summary>
        /// 1:新規モード 2:参照モード
        /// </summary>
        public int Mode;
        /// <summary>
        /// APEmployeeProcParamWork
        /// </summary>
        public APEmployeeProcParamWork _employeeProcParam;

        #endregion ■ Public Memebers ■

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2012.07.26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        # endregion ■ ボタン初期設定処理 ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKYO01511UA()
        {
            InitializeComponent();

            // 拠点ガイド用アクセスクラス
            this._secInfoSetAcs = new SecInfoSetAcs();
            // 従業員ガイド用アクセスクラス
            this._employeeAcs = new EmployeeAcs();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();

        }
        # endregion ■ コンストラクタ ■

        # region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>	
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void PMKYO01201UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            //参照モード
            if (this.Mode == 2)
            {
                this._saveButton.SharedProps.Visible = false;
                this._clearButton.SharedProps.Visible = false;

                // 拠点
                this.tEdit_SectionCode_St.Enabled = false;
                this.tEdit_SectionCode_Ed.Enabled = false;
                this.SectionStGuide_Button.Enabled = false;
                this.SectionEdGuide_Button.Enabled = false;

                // 従業員
                this.tEdit_EmployeeCode_St.Enabled = false;
                this.tEdit_EmployeeCode_Ed.Enabled = false;
                this.EmployeeStGuide_Button.Enabled = false;
                this.EmployeeEdGuide_Button.Enabled = false;

            }
            //新規モード
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;

                // 拠点
                this.tEdit_SectionCode_St.Enabled = true;
                this.tEdit_SectionCode_Ed.Enabled = true;
                this.SectionStGuide_Button.Enabled = true;
                this.SectionEdGuide_Button.Enabled = true;

                // 従業員
                this.tEdit_EmployeeCode_St.Enabled = true;
                this.tEdit_EmployeeCode_Ed.Enabled = true;
                this.EmployeeStGuide_Button.Enabled = true;
                this.EmployeeEdGuide_Button.Enabled = true;
            }
            
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            this.timer_InitialSetFocus.Enabled = true;
        }
        # endregion ■ フォームロード ■

        # region ■ 画面初期化後イベント ■
        /// <summary>
        /// 画面初期化後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化後イベント処理発生します。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._employeeProcParam != null)
            {
                // 拠点
                this.tEdit_SectionCode_St.DataText = _employeeProcParam.BelongSectionCdBeginRF.Trim();
                this.tEdit_SectionCode_Ed.DataText = _employeeProcParam.BelongSectionCdEndRF.Trim();

                // 従業員
                this.tEdit_EmployeeCode_St.DataText = _employeeProcParam.EmployeeCdBeginRF;
                this.tEdit_EmployeeCode_Ed.DataText = _employeeProcParam.EmployeeCdEndRF;
            }            
        }
        #endregion

        # region ■ ツールバー処理 ■

        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>	
        /// <br>Date		: 2012.07.26</br>
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
                case "ButtonTool_Save":
                    {
                        //保存処理
                        this.Save();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // クリア処理
                        this.Clear();
                        break;
                    }
            }
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 保存処理です。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>	
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void Save()
        {
            string errMessage = "";
            Control errCtrl = null;
            // 画面データチェック処理
            if (!this.ScreenInputCheck(out errCtrl, ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                //フォーカスをエラー項目へ移動
                if (null != errCtrl && errCtrl.Enabled)
                {
                    errCtrl.Focus();
                }
                return;
            }
            if (_employeeProcParam == null)
            {
                _employeeProcParam = new APEmployeeProcParamWork();
            }
            else
            {
                // 開始条件1(拠点)
                _employeeProcParam.BelongSectionCdBeginRF = this.tEdit_SectionCode_St.DataText;
                // 終了条件1(拠点)
                _employeeProcParam.BelongSectionCdEndRF = this.tEdit_SectionCode_Ed.DataText;

                // 開始条件2(従業員)
                _employeeProcParam.EmployeeCdBeginRF = this.tEdit_EmployeeCode_St.DataText;
                // 終了条件2(従業員)
                _employeeProcParam.EmployeeCdEndRF = this.tEdit_EmployeeCode_Ed.DataText;
            }

            //保存成功したら画面を閉じる
            this.Close();
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: クリア処理です。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>	
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void Clear()
        {
            // 拠点
            this.tEdit_SectionCode_St.DataText = string.Empty;
            this.tEdit_SectionCode_Ed.DataText = string.Empty;

            // 従業員
            this.tEdit_EmployeeCode_St.DataText = string.Empty;
            this.tEdit_EmployeeCode_Ed.DataText = string.Empty;

            this.tEdit_SectionCode_St.Focus();
        }

        #endregion region ■ ツールバー処理 ■

        #region ■ Private Method ■

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォームロードイベント処理発生します。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //拠点(開始)
                case "tEdit_SectionCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_SectionCode_St.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_SectionCode_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.SectionStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //拠点(終了)
                case "tEdit_SectionCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_SectionCode_Ed.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_EmployeeCode_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.SectionEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //担当者(開始)
                case "tEdit_EmployeeCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_EmployeeCode_St.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.EmployeeStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //担当者(終了)
                case "tEdit_EmployeeCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_EmployeeCode_Ed.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_SectionCode_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.EmployeeEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errCtrl">Control</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private bool ScreenInputCheck(out Control errCtrl, ref string errMessage)
        {
            bool status = true;
            errCtrl = null;
            const string ct_RangeError = "の範囲が不正です。";

            // 一括ゼロ詰め処理
            uiSetControl1.SettingAllControlsZeroPaddedText();

            //拠点範囲チェック
            if (!string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText.Trim()) &&
                0 < this.tEdit_SectionCode_St.DataText.CompareTo(this.tEdit_SectionCode_Ed.DataText))
            {
                errMessage = this.ultraLabel_Section.Text + ct_RangeError;
                errCtrl = tEdit_SectionCode_St;
                status = false;
                return status;
            }
            //担当者範囲チェック
            if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText.Trim()) &&
                0 < this.tEdit_EmployeeCode_St.DataText.CompareTo(this.tEdit_EmployeeCode_Ed.DataText))
            {
                errMessage = this.ultraLabel_Employee.Text + ct_RangeError;
                errCtrl = tEdit_EmployeeCode_St;
                status = false;
                return status;
            }
            return status;
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : FSI菅原 庸平</br>
        /// <br>Date        : 2012.07.26</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet = new SecInfoSet();

                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    //取得した拠点コードを画面に表示する
                    if ("SectionStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tEdit_SectionCode_St.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionCode_Ed.Focus();
                    }
                    else
                    {
                        this.tEdit_SectionCode_Ed.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_EmployeeCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(EmployeeGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 担当者ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : FSI菅原 庸平</br>
        /// <br>Date        : 2012.07.26</br>
        /// </remarks>
        private void EmployeeGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee = new Employee();

                status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
                if (status == 0)
                {
                    //取得した担当者コードを画面に表示する
                    if ("EmployeeStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_EmployeeCode_Ed.Focus();
                    }
                    else
                    {
                        this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_SectionCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// エラーメッセージ処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">STATUS</param>
        /// <returns>true:チェック完了 false:チェック未完了</returns>
        /// <remarks>
        /// <br>Note		: エラーメッセージを行う。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date		: 2012.07.26</br>
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

        #endregion Private Method

		# region ■ ExplorerBarの縮小・展開処理 ■
		/// <summary>
		/// グループ展開
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// 常にキャンセル
			e.Cancel = true;
		}
		/// <summary>
		/// グループ縮小
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// 常にキャンセル
			e.Cancel = true;
		}
		# endregion ■  ■
    }
}