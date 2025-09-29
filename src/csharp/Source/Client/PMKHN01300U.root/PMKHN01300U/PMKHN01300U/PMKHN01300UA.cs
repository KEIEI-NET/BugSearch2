//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先変換ツール
// プログラム概要   : 商品管理情報マスタの最適化の為、不要なレコードを削除する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/07/13  修正内容 : 新規作成
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

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仕入先変換処理
    /// </summary>
    /// <remarks>
    /// Note       : 仕入先変換処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009/07/13<br />
    /// </remarks>
    public partial class PMKHN01300UA : Form
    {
        #region ■ Const Memebers ■
        private const string PROGRAM_ID = "PMKHN01300U";
        #endregion

        # region ■ private field ■
        private ControlScreenSkin _controlScreenSkin;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executeButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private SupplierChangeAcs _supplierChangeAcs;
        #endregion

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.07.13</br>
        /// </remarks>
        public PMKHN01300UA()
        {
            InitializeComponent();
            // 変数初期化
            this._controlScreenSkin = new ControlScreenSkin();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Execute"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._supplierChangeAcs = SupplierChangeAcs.GetInstance();
        }
        #endregion

        # region ■ 画面初期化後イベント ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.07.13</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }
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
        /// <br>Date		: 2009.07.13</br>
        /// </remarks>
        private void PMKHN01300UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }
        #endregion

        #region ■ 仕入先変換処理メッソド関連 ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.07.13</br>
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
                case "ButtonTool_Execute":
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "仕入先変換処理を実行します。\r\n\r\nよろしいですか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // 実行処理
                            this.ExecuteProcess();
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 仕入先変換処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 仕入先変換処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.07.13</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            int readCount = 0;
            int delCount = 0;

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "仕入先変換ツール";
            form.Message = "現在、仕入先変換処理中です。";

            this.Cursor = Cursors.WaitCursor;
            // ダイアログ表示
            form.Show(); 

            int status = _supplierChangeAcs.SupplierChangeProc(_enterpriseCode, out readCount, out delCount);

            // ダイアログを閉じる
            form.Close();
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "仕入先変換処理が完了しました。",
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
                    "変換処理中にエラーが発生しました。",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion
    }
}