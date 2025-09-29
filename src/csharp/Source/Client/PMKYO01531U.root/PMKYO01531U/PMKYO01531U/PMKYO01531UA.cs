//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ユーザーガイドマスタ（販売区分）抽出条件画面
// プログラム概要   : ユーザーガイドマスタ（販売区分）抽出条件の設定・参照処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東 隆史
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
    /// ユーザーガイドマスタ（販売区分）抽出条件画面フォームクラス
    /// </summary>
    /// <remarks>
    /// Note       : ユーザーガイドマスタ（販売区分）抽出条件の設定・参照処理です。<br />
    /// Programmer : FSI東 隆史<br />
    /// Date       : 2012.07.26<br />
    /// </remarks>
    public partial class PMKYO01531UA : Form
    {

        #region ■ Const Memebers ■

        private const string PROGRAM_ID = "PMKYO01531UA";
        
        #endregion ■ Const Memebers ■

        # region ■ Private field ■

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        // ユーザーガイドアクセスクラス
        private UserGuideAcs _userGuideAcs;

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
        /// APUserGdBuyDivUProcParamWork
        /// </summary>
        public APUserGdBuyDivUProcParamWork _userGdBuyDivUProcParam;

        #endregion ■ Public Memebers ■

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : FSI東 隆史</br>
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
        public PMKYO01531UA()
        {
            InitializeComponent();

            // ユーザーガイド用アクセスクラス
            this._userGuideAcs = new UserGuideAcs();

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
        /// <br>Programmer	: FSI東 隆史</br>	
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void PMKYO01201UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            // 参照モード
            if (this.Mode == 2)
            {
                this._saveButton.SharedProps.Visible = false;
                this._clearButton.SharedProps.Visible = false;

                // 販売区分
                this.tNedit_SalesCode_St.Enabled = false;
                this.tNedit_SalesCode_Ed.Enabled = false;
                this.SalesStGuide_Button.Enabled = false;
                this.SalesEdGuide_Button.Enabled = false;
            }
            // 新規モード
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;

                // 販売区分
                this.tNedit_SalesCode_St.Enabled = true;
                this.tNedit_SalesCode_Ed.Enabled = true;
                this.SalesStGuide_Button.Enabled = true;
                this.SalesEdGuide_Button.Enabled = true;
            }
            
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SalesStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

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
        /// <br>Programmer	: FSI東 隆史</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._userGdBuyDivUProcParam != null)
            {
                // 販売区分
                this.tNedit_SalesCode_St.SetInt(_userGdBuyDivUProcParam.GuideCodeBeginRF);
                this.tNedit_SalesCode_Ed.SetInt(_userGdBuyDivUProcParam.GuideCodeEndRF);
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
        /// <br>Programmer	: FSI東 隆史</br>	
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
                        // 保存処理
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
        /// <br>Programmer	: FSI東 隆史</br>	
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
                // フォーカスをエラー項目へ移動
                if (null != errCtrl && errCtrl.Enabled)
                {
                    errCtrl.Focus();
                }
                return;
            }
            if (_userGdBuyDivUProcParam == null)
            {
                _userGdBuyDivUProcParam = new APUserGdBuyDivUProcParamWork();
            }
            else
            {
                // 販売区分
                _userGdBuyDivUProcParam.GuideCodeBeginRF = this.tNedit_SalesCode_St.GetInt();
                _userGdBuyDivUProcParam.GuideCodeEndRF = this.tNedit_SalesCode_Ed.GetInt();
            }

            //保存成功したら画面を閉じる
            this.Close();
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: クリア処理です。</br>
        /// <br>Programmer	: FSI東 隆史</br>	
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void Clear()
        {
            // 販売区分
            this.tNedit_SalesCode_St.SetInt(0);
            this.tNedit_SalesCode_Ed.SetInt(0);

            this.tNedit_SalesCode_St.Focus();
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
        /// <br>Programmer	: FSI東 隆史</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // 販売区分(開始)
                case "tNedit_SalesCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tNedit_SalesCode_St.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_SalesCode_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.SalesStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // 販売区分(終了)
                case "tNedit_SalesCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tNedit_SalesCode_Ed.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_SalesCode_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.SalesEdGuide_Button;
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
        /// <br>Programmer	: FSI東 隆史</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private bool ScreenInputCheck(out Control errCtrl, ref string errMessage)
        {
            bool status = true;
            errCtrl = null;
            const string ct_RangeError = "の範囲が不正です。";

            // 一括ゼロ詰め処理
            uiSetControl1.SettingAllControlsZeroPaddedText();

            // 販売区分範囲チェック
            if (this.tNedit_SalesCode_Ed.GetInt() > 0 &&
                this.tNedit_SalesCode_St.GetInt() > this.tNedit_SalesCode_Ed.GetInt())
            {
                errMessage = this.ultraLabel_Sales.Text + ct_RangeError;
                errCtrl = tNedit_SalesCode_St;
                status = false;
                return status;
            }
            return status;
        }

        /// <summary>
        /// Control.Click イベント(SalesGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 販売区分ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : FSI東 隆史</br>
        /// <br>Date        : 2012.07.26</br>
        /// </remarks>
        private void SalesGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd = new UserGdHd();
                UserGdBd userGdBd = new UserGdBd();

                status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);
                if (status == 0)
                {
                    // 取得した販売区分コードを画面に表示する
                    if ("SalesStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_SalesCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesCode_Ed.Focus();
                    }
                    else if ("SalesEdGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_SalesCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesCode_St.Focus();
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
        /// <br>Programmer	: FSI東 隆史</br>
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