//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 結合マスタ抽出条件画面
// プログラム概要   : 結合マスタ抽出条件の設定・参照処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI上北田 秀樹
// 作 成 日  2012/07/26  修正内容 : 新規作成
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
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 結合マスタ抽出条件画面フォームクラス
    /// </summary>
    /// <remarks>
    /// Note       : 結合マスタ抽出条件の設定・参照処理です。<br />
    /// Programmer : FSI上北田 秀樹<br />
    /// Date       : 2012/07/26<br />
    /// </remarks>
    public partial class PMKYO01521UA : Form
    {

        #region ■ Const Memebers ■

        private const string PROGRAM_ID = "PMKYO01521UA";
        
        #endregion ■ Const Memebers ■

        # region ■ Private field ■

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        private MakerAcs _makerAcs;             // メーカー用


        private string _loginName;
        private string _enterpriseCode;
        private string _loginEmplooyCode;
        private string _loginSectionCode;

        # endregion ■ Private field ■

        #region ■ Public Memebers ■
        /// <summary>
        /// 1:新規モード 2:参照モード
        /// </summary>
        public int Mode; 
        /// <summary>
        /// APJoinPartsUProcParamWork
        /// </summary>
        public APJoinPartsUProcParamWork _joinPartsUProcParam;

        #endregion ■ Public Memebers ■

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 2012/07/26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.JoinSourceMakerCdStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.JoinSourceMakerCdEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            this.JoinDestMakerCdStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.JoinDestMakerCdEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }
        # endregion ■ ボタン初期設定処理 ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKYO01521UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._makerAcs = new MakerAcs();

            this._loginName = LoginInfoAcquisition.Employee.Name;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

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
        /// <br>Programmer	: FSI上北田 秀樹</br>	
        /// <br>Date		: 2012/07/26</br>
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

                // 結合元品番
                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;

                // 結合元メーカーコード
                this.tNedit_JoinSourceMakerCd_St.Enabled = false;
                this.tNedit_JoinSourceMakerCd_Ed.Enabled = false;
                this.JoinSourceMakerCdStGuide_Button.Enabled = false;
                this.JoinSourceMakerCdEdGuide_Button.Enabled = false;

                // 結合表示順位
                this.tNedit_JoinDispOrder_St.Enabled = false;
                this.tNedit_JoinDispOrder_Ed.Enabled = false;

                // 結合先メーカーコード
                this.tNedit_JoinDestMakerCd_St.Enabled = false;
                this.tNedit_JoinDestMakerCd_Ed.Enabled = false;
                this.JoinDestMakerCdStGuide_Button.Enabled = false;
                this.JoinDestMakerCdEdGuide_Button.Enabled = false;
            }
            //新規モード
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;

                // 結合元品番
                this.tEdit_GoodsNo_St.Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;

                // 結合元メーカーコード
                this.tNedit_JoinSourceMakerCd_St.Enabled = true;
                this.tNedit_JoinSourceMakerCd_Ed.Enabled = true;
                this.JoinSourceMakerCdStGuide_Button.Enabled = true;
                this.JoinSourceMakerCdEdGuide_Button.Enabled = true;

                // 結合表示順位
                this.tNedit_JoinDispOrder_St.Enabled = true;
                this.tNedit_JoinDispOrder_Ed.Enabled = true;

                // 結合先メーカーコード
                this.tNedit_JoinDestMakerCd_St.Enabled = true;
                this.tNedit_JoinDestMakerCd_Ed.Enabled = true;
                this.JoinDestMakerCdStGuide_Button.Enabled = true;
                this.JoinDestMakerCdEdGuide_Button.Enabled = true;

            }

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
        /// <br>Programmer	: FSI上北田 秀樹</br>
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._joinPartsUProcParam != null)
            {

                // 結合元品番
                this.tEdit_GoodsNo_St.Text = _joinPartsUProcParam.JoinSourPartsNoWithHBeginRF;
                this.tEdit_GoodsNo_Ed.Text = _joinPartsUProcParam.JoinSourPartsNoWithHEndRF;

                // 結合元メーカーコード
                this.tNedit_JoinSourceMakerCd_St.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinSourceMakerCodeBeginRF));
                this.tNedit_JoinSourceMakerCd_Ed.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinSourceMakerCodeEndRF));

                // 結合表示順位
                this.tNedit_JoinDispOrder_St.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinDispOrderBeginRF));
                this.tNedit_JoinDispOrder_Ed.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinDispOrderEndRF));

                // 結合先メーカーコード
                this.tNedit_JoinDestMakerCd_St.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinDestMakerCodeBeginRF));
                this.tNedit_JoinDestMakerCd_Ed.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinDestMakerCodeEndRF));
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
        /// <br>Programmer	: FSI上北田 秀樹</br>	
        /// <br>Date		: 2012/07/26</br>
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
        /// <br>Programmer	: FSI上北田 秀樹</br>	
        /// <br>Date		: 2012/07/26</br>
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
            if (_joinPartsUProcParam == null)
            {
                _joinPartsUProcParam = new APJoinPartsUProcParamWork();
            }
            else
            {
                // 結合元品番
                _joinPartsUProcParam.JoinSourPartsNoWithHBeginRF = this.tEdit_GoodsNo_St.Text;
                _joinPartsUProcParam.JoinSourPartsNoWithHEndRF = this.tEdit_GoodsNo_Ed.Text;
  
                // 結合元メーカーコード
                _joinPartsUProcParam.JoinSourceMakerCodeBeginRF = this.tNedit_JoinSourceMakerCd_St.GetInt();
                _joinPartsUProcParam.JoinSourceMakerCodeEndRF = this.tNedit_JoinSourceMakerCd_Ed.GetInt();

                // 結合表示順位
                _joinPartsUProcParam.JoinDispOrderBeginRF = this.tNedit_JoinDispOrder_St.GetInt();
                _joinPartsUProcParam.JoinDispOrderEndRF = this.tNedit_JoinDispOrder_Ed.GetInt();

                // 結合先メーカーコード
                _joinPartsUProcParam.JoinDestMakerCodeBeginRF = this.tNedit_JoinDestMakerCd_St.GetInt();
                _joinPartsUProcParam.JoinDestMakerCodeEndRF = this.tNedit_JoinDestMakerCd_Ed.GetInt();
            }

            //保存成功したら画面を閉じる
            this.Close();
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: クリア処理です。</br>
        /// <br>Programmer	: FSI上北田 秀樹</br>	
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private void Clear()
        {
            // 結合元品番
            this.tEdit_GoodsNo_St.Text = String.Empty;
            this.tEdit_GoodsNo_Ed.Text = String.Empty;
            // 結合元メーカーコード
            this.tNedit_JoinSourceMakerCd_St.SetInt(0);
            this.tNedit_JoinSourceMakerCd_Ed.SetInt(0);
            // 結合表示順位
            this.tNedit_JoinDispOrder_St.SetInt(0);
            this.tNedit_JoinDispOrder_Ed.SetInt(0);
            // 結合先メーカーコード
            this.tNedit_JoinDestMakerCd_St.SetInt(0);
            this.tNedit_JoinDestMakerCd_Ed.SetInt(0);

            this.tEdit_GoodsNo_St.Focus();
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
        /// <br>Programmer	: FSI上北田 秀樹</br>
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // 結合元品番　終了
                case "tEdit_GoodsNo_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定(結合元メーカーコード　開始)
                                e.NextCtrl = this.tNedit_JoinSourceMakerCd_St;
                            }
                        }
                        break;
                    }
                // 結合元メーカーコード　開始
                case "tNedit_JoinSourceMakerCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_JoinSourceMakerCd_St.GetInt() > 0)
                                {
                                    // フォーカス設定(結合元メーカーコード　終了)
                                    e.NextCtrl = this.tNedit_JoinSourceMakerCd_Ed;
                                }
                                else
                                {
                                    // フォーカス設定(結合元メーカーコード　開始ガイドボタン)
                                    e.NextCtrl = this.JoinSourceMakerCdStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // 結合元メーカーコード　終了
                case "tNedit_JoinSourceMakerCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_JoinSourceMakerCd_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定(結合表示順位)
                                    e.NextCtrl = this.tNedit_JoinDispOrder_St;
                                }
                                else
                                {
                                    // フォーカス設定(結合元メーカーコード　終了ガイドボタン)
                                    e.NextCtrl = this.JoinSourceMakerCdEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // 結合表示順位　終了
                case "tNedit_JoinDispOrder_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定(結合先メーカーコード 開始)
                                e.NextCtrl = this.tNedit_JoinDestMakerCd_St;
                            }
                        }
                        break;
                    }
                // 結合先メーカーコード　開始
                case "tNedit_JoinDestMakerCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_JoinDestMakerCd_St.GetInt() > 0 )
                                {
                                    // フォーカス設定(結合先メーカーコード　終了)
                                    e.NextCtrl = this.tNedit_JoinDestMakerCd_Ed;
                                }
                                else
                                {
                                    // フォーカス設定(結合先メーカーコード　開始ガイドボタン)
                                    e.NextCtrl = this.JoinDestMakerCdStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // 結合先メーカーコード　終了
                case "tNedit_JoinDestMakerCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_JoinDestMakerCd_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定(結合元品番　開始)
                                    e.NextCtrl = this.tEdit_GoodsNo_St;
                                }
                                else
                                {
                                    // フォーカス設定(結合先メーカーコード　終了ガイドボタン)
                                    e.NextCtrl = this.JoinDestMakerCdEdGuide_Button;
                                }
                            }

                        }
                        break;
                    }

                // 結合先メーカーコード　終了ガイドボタン
                case "JoinDestMakerCdEdGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定(結合元品番　開始)
                                e.NextCtrl = this.tEdit_GoodsNo_St;
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
        /// <param name="errCtrl"></param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: FSI上北田 秀樹</br>
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private bool ScreenInputCheck(out Control errCtrl, ref string errMessage)
        {
            bool status = true;
            errCtrl = null;
            const string ct_RangeError = "の範囲が不正です。";

            // 一括ゼロ詰め処理
            uiSetControl1.SettingAllControlsZeroPaddedText();

            // 結合元品番
            if (String.Compare(this.tEdit_GoodsNo_Ed.Text, "0") > 0 && String.Compare(this.tEdit_GoodsNo_St.Text, this.tEdit_GoodsNo_Ed.Text) > 0)
            {
                errMessage = "結合元品番" + ct_RangeError;
                status = false;
                errCtrl = tEdit_GoodsNo_St;
                return status;
            }
            // 結合元メーカーコード
            if (this.tNedit_JoinSourceMakerCd_Ed.GetInt() > 0 && this.tNedit_JoinSourceMakerCd_St.GetInt() > this.tNedit_JoinSourceMakerCd_Ed.GetInt())
            {
                errMessage = "結合元メーカーコード" + ct_RangeError;
                status = false;
                errCtrl = tNedit_JoinSourceMakerCd_St;
                return status;
            }
            // 結合表示順位
            if (this.tNedit_JoinDispOrder_Ed.GetInt() > 0 && this.tNedit_JoinDispOrder_St.GetInt() > this.tNedit_JoinDispOrder_Ed.GetInt())
            {
                errMessage = "表示順位" + ct_RangeError;
                status = false;
                errCtrl = tNedit_JoinDispOrder_St;
                return status;
            }
            // 結合先メーカーコード
            if (this.tNedit_JoinDestMakerCd_Ed.GetInt() > 0 && this.tNedit_JoinDestMakerCd_St.GetInt() > this.tNedit_JoinDestMakerCd_Ed.GetInt())
            {
                errMessage = "結合先メーカーコード" + ct_RangeError;
                status = false;
                errCtrl = tNedit_JoinDestMakerCd_St;
                return status;
            }
            return status;
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
        /// <br>Programmer	: FSI上北田 秀樹</br>
        /// <br>Date		: 2012/07/26</br>
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
		private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// 常にキャンセル
			e.Cancel = true;
		}
		/// <summary>
		/// グループ縮小
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// 常にキャンセル
			e.Cancel = true;
		}
		# endregion ■  ■

        /// <summary>
        /// Control.Click イベント(SourceMakerCdStGuide_Button , SourceMakerCdEdGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 結合元メーカーコード　開始ガイドボタン・終了ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : FSI上北田 秀樹</br>
        /// <br>Date        : 2012/07/26</br>
        /// </remarks>
        private void JoinSourceMakerCdStGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            MakerUMnt makerUMnt;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if ("JoinSourceMakerCdStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_JoinSourceMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                        this.JoinSourceMakerCdStGuide_Button.Focus();
                    }
                    else if ("JoinSourceMakerCdEdGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_JoinSourceMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                        this.JoinSourceMakerCdEdGuide_Button.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(DestMakerCdStGuide_Button , DestMakerCdEdGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 結合先メーカーコード　開始ガイドボタン・終了ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : FSI上北田 秀樹</br>
        /// <br>Date        : 2012/07/26</br>
        /// </remarks>
        private void JoinDestMakerCdStGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            MakerUMnt makerUMnt;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if ("JoinDestMakerCdStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_JoinDestMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                        this.JoinDestMakerCdStGuide_Button.Focus();
                    }
                    else if ("JoinDestMakerCdEdGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_JoinDestMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                        this.JoinDestMakerCdEdGuide_Button.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}