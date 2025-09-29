//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提供データ削除処理
// プログラム概要   : データセンターに対して削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/06/15  修正内容 : 新規作成
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
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 提供データ削除処理
    /// </summary>
    /// <remarks>
    /// Note       : 提供データ削除処理です。<br />
    /// Programmer : 呉元嘯<br />
    /// Date       : 2009.06.15<br />
    /// </remarks>
    public partial class PMKHN01100UA : Form
    {
        #region ■ Const Memebers ■
        private const string ct_ClassID = "PMKHN01100UA";
        #endregion ■ Const Memebers ■

        # region ■ private field ■

        private ImageList _imageList16 = null;
        // クローズボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        // 実行ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _runButton;
        // ログイン担当者
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;
        // 提供データ削除処理インターフェース対象
        private OfferDataDeleteAcs _offerDataDeleteAcs;
        // ログイン担当者名称
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        // デフォルト行の外観設定
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

        # endregion ■ private field ■

        # region ■ Constructor ■
        /// <summary>
        /// 提供データ削除処理UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 提供データ削除処理UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        /// <br></br>
        /// </remarks>
        public PMKHN01100UA()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._runButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._offerDataDeleteAcs = new OfferDataDeleteAcs();

        }
        # endregion ■ Constructor ■

        #region  ■ Control Event ■
        # region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.06.15</br>
        /// </remarks>
        private void PMKHN01100UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // ボタン初期化
            this.ButtonInitialSetting();

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

        }
        # endregion ■ フォームロード ■

        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.06.15</br>
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
                        // 実行確認メッセージ表示
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "提供データ削除処理を実行します。\r\nよろしいですか？",
                            0,
                            MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // 実行処理
                            this.DeleteProcess();
                        }
                        break;
                    }
            }
        }
        #endregion

        #region  ■ Private Method ■
        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: データ削除処理を行う。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.06.15</br>
        /// </remarks>
        private void DeleteProcess()
        {
            // 抽出中画面部品のインスタンスを作成
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            SFCMN00299CA form = new SFCMN00299CA();
            // 表示文字を設定
            form.Title = "提供データ削除処理";
            form.Message = "現在、提供データ削除中です。";
            // ダイアログ表示
            form.Show();
            string errMsg = string.Empty;
            // データ削除処理
            status = this._offerDataDeleteAcs.Delete(out errMsg);
            // ダイアログを閉じる
            form.Close();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "提供データ削除処理が完了しました。",
                    -1,
                    MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_STOPDISP,
                   this.Name,
                   errMsg,
                   -1,
                   MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "提供データ削除処理中にエラーが発生しました。\r\nセキュリティ管理のログ表示で\r\nシステムログを確認して下さい。",
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.15</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            // 終了ボタン
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 実行ボタン
            this._runButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // ログイン担当者レーベル
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        # endregion ■ ボタン初期設定処理 ■
        #endregion  ■ Private Method ■


    }
}