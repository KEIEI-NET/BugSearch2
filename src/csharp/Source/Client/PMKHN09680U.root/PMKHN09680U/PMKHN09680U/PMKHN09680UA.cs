//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタコンバート
// プログラム概要   : 在庫管理全体設定の現在庫表示区分より、出荷可能数を更新する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/08/26  修正内容 : 連番No.1016 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Broadleaf.Application.Common;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫マスタコンバート処理
    /// </summary>
    /// <remarks>
    /// Note       : 在庫マスタコンバート処理です。<br />
    /// Programmer : 李占川<br />
    /// Date       : 2011/08/26<br />
    /// </remarks>
    public partial class PMKHN09680UA : Form
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
        private StockConvertAcs _stockConvertAcs;
        private StockMngTtlStAcs _stockMngTtlStAcs = null;              //在庫全体設定マスタアクセス
        private StockMngTtlSt _stockMngTtlSt = null;                    //在庫管理全体設定
        #endregion

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        public PMKHN09680UA()
        {
            InitializeComponent();
            // 変数初期化
            this._controlScreenSkin = new ControlScreenSkin();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Execute"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._stockConvertAcs = StockConvertAcs.GetInstance();

            // 在庫全体管理設定読み込み
            this.ReadStockMngTtlSt();
        }
        #endregion

        # region ■ 画面初期化後イベント ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// 在庫管理全体設定の現在庫表示区分に従う、画面の表示の変更。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定の現在庫表示区分に従う、画面の表示を変更する</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private void StockDivSetting()
        {
            // 在庫管理全体設定の現在庫表示区分に従う。
            if (_stockMngTtlSt.PreStckCntDspDiv == 0)
            {
                this.StockDiv_uLabel.Text = "在庫管理全体設定の現在庫表示区分は「0:受注分含む」です。";
            }
            else
            {
                this.StockDiv_uLabel.Text = "在庫管理全体設定の現在庫表示区分は「1:受注分含まない」です。";
            }
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
        /// <br>Programmer	: 李占川</br>	
        /// <br>Date		: 2011/08/26</br>
        /// </remarks>
        private void PMKHN01300UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // ボタン初期設定処理
            this.ButtonInitialSetting();
            // 画面の表示の変更
            this.StockDivSetting();

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }
        #endregion

        #region ■ 在庫マスタコンバート処理メッソド関連 ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 李占川</br>	
        /// <br>Date		: 2011/08/26</br>
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
                            "在庫マスタコンバート処理を実行します。\r\n\r\nよろしいですか？",
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
        /// 在庫マスタコンバート処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 在庫マスタコンバート処理を行う。</br>
        /// <br>Programmer	: 李占川</br>	
        /// <br>Date		: 2011/08/26</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            int stockCount = 0;
            int stockAcPayHistCount = 0;

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "在庫マスタコンバート";
            form.Message = "現在、在庫マスタコンバート処理中です。";

            this.Cursor = Cursors.WaitCursor;
            // ダイアログ表示
            form.Show();

            int status = _stockConvertAcs.StockConvertProc(_enterpriseCode,this._stockMngTtlSt.PreStckCntDspDiv, out stockCount, out stockAcPayHistCount);

            // ダイアログを閉じる
            form.Close();
            this.Cursor = Cursors.Default;

            this.StockCount_uLabel.Text = stockCount.ToString("#,##0") + " 件";
            this.StockAcPayHist_uLabel.Text = stockAcPayHistCount.ToString("#,##0") + " 件";

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "在庫マスタコンバート処理が完了しました。",
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
                    "コンバート処理にエラーが発生しました。",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        #region ReadStockMngTtlSt(在庫全体管理設定読み込み)
        /// <summary>
        /// 在庫全体管理設定読み込み
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private void ReadStockMngTtlSt()
        {
            ArrayList retList;

            if (_stockMngTtlStAcs == null)
            {
                _stockMngTtlStAcs = new StockMngTtlStAcs();
            }

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        this._stockMngTtlSt = stockMngTtlSt;
                        break;
                    }
                }
            }
            else
            {
                this._stockMngTtlSt = new StockMngTtlSt();
            }
        }
        #endregion
    }
}