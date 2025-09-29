//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 在庫移動の各子画面を制御するメインフレームです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20008 伊藤 豊
// 作 成 日  2007/01/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2007/09/05  修正内容 : 流通.NS用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2008/07/14  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/04  修正内容 : 移動データ拠点管理対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/23  修正内容 : 不具合対応[13614]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 修 正 日  2009.07.07  修正内容 : MANTIS[0013679]の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2010/06/10  修正内容 : 移動伝票の[発行する]オプションの初期値を設定
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤　恵優
// 修 正 日  2010/06/11  修正内容 : 入荷取消の確認は1回だけ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤　恵優
// 修 正 日  2010/06/15  修正内容 : MANTIS対応[15317]：保存後も[最新情報]ボタンを操作可能に
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/11/15  修正内容 : 障害改良対応「５，６，７」の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2010/11/15  修正内容 : 障害改良対応「3」の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2010/11/15  修正内容 : MANTIS対応[15617]：入荷処理後の確認メッセージの変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/12/09  修正内容 : 新規入力時で、保存実行後に「新規ボタン」押下時のメッセージの有無判断追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2011/05/10  修正内容 : redmine #20901
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日 K2013/09/11  修正内容 : フタバ個別対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 在庫移動入力メインフレーム
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫移動の各子画面を制御するメインフレームです。</br>br>
	/// <br>Programer  : 20008 伊藤 豊</br>
	/// <br>Date       : 2007.01.23<br/>
    /// <br>Note       : 流通.NS用に変更</br>
    /// <br>Programer  : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.05</br>
    /// <br>Update Date: 2008/07/14 30414 忍 幸史</br>
    /// <br>           : Partsman用に変更</br>
    /// <br>           : 2009/06/04 照田 貴志　移動データ拠点管理対応</br>
    /// <br>           : 2009/06/23 照田 貴志　不具合対応[13614]</br>
    /// <br>           : 2009.07.07 佐々木 健　MANTIS対応[0013679]</br>
    /// <br>           : 2010/11/15 曹文傑 障害改良対応「５，６，７」の対応</br>
    /// <br>           : 2010/11/15 tianjw 障害改良対応「3」の対応</br>
    /// <br>           : 2010/12/09 曹文傑 新規入力時で、保存実行後に「新規ボタン」押下時のメッセージの有無判断追加</br>
    /// <br>Update Date: K2013/09/11 田建委</br>
    /// <br>           : フタバ個別対応</br>
    /// <br>           : テキスト変換後のデータを修正・削除不可とする。</br>
    /// </remarks>
    public partial class MAZAI04100UA : Form
    {
        //----------------------------------------------------------------------------------------------------
        //  コンストラクタ
        //----------------------------------------------------------------------------------------------------
        # region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAZAI04100UA()
        {
            InitializeComponent();

            // スキンインスタンスの生成
            _controlScreenSkin = new ControlScreenSkin();

            // イメージインスタンスの生成
            this._imageList16 = IconResourceManagement.ImageList16;

            // ボタンインスタンスの生成
            this._closeButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Close"];
            this._saveButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Save"];
            this._newButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_New"];
            this._deleteButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Delete"];
            this._loadButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Load"];
            this._renewalButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Renewal"];

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            this._outPutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"];
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            this._retryButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_undo"];
            this._StockMoveInputButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"];
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            this._StockMoveFixInputButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_StockDecision"];
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            this._StockMoveArrivalGoodsInputButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._setupButton = (ButtonTool)this.ToolbarsManager_Main.Tools["ButtonTool_Setup"];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            this._sectionTitleLabel = (LabelTool)this.ToolbarsManager_Main.Tools["LabelTool_SectionTitle"];
            this._sectionLabel = (LabelTool)this.ToolbarsManager_Main.Tools["LabelTool_Section"];
            this._loginEmployeeLabel = (LabelTool)this.ToolbarsManager_Main.Tools["LabelTool_LoginNameTitle"];
            this._loginEmployeeName = (LabelTool)this.ToolbarsManager_Main.Tools["LabelTool_LoginName"];

            // フレームから呼び出される各子画面のインスタンスの生成
            this._StockMoveInput = new MAZAI04120UA();

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // 拠点コード変更イベント登録
            _StockMoveInput.SectionChange += new EventHandler( StockMoveInput_SectionChange );
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            this._StockMoveInputAcs = StockMoveInputAcs.GetInstance();
            this._StockMoveDataTable = _StockMoveInputAcs.StockMoveDataTable;
            
            // 初期値情報
            _StockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();
            
            // ヘッダ情報
            _StockMoveHeader = _StockMoveInputInitAcs.StockMoveHeader;

            // テーブル情報
            _StockMoveDataTable = _StockMoveInputAcs.StockMoveDataTable;

            // 初期データ取得処理
            this._StockMoveInputInitAcs.ReadInitData(LoginInfoAcquisition.EnterpriseCode);

            //this._StockMoveFixInput = new MAZAI04128UA();
            //this._StockMoveArrivalGoodsInput = new MAZAI04129UA();
            _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            this._StockMoveInput.enterGoodsNoColumn += new MAZAI04120UA.EnterGoodsNoColumnEventHandler(this.EnterGoodsNoColumn);
            this._StockMoveInput.changeFocusFooter += new MAZAI04120UA.ChangeFocusFooterEventHandler(this.ChangeFocusFooter);
            this._StockMoveInput.loadSlipGuide += new MAZAI04120UA.LoadSlipGuideEventHandler(this.SlipLoad);
            this._StockMoveInput.setSlipInfo += new MAZAI04120UA.SetSlipInfoEventHandler(this.SetDisplay);
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<
            // 2009.04.02 30413 犬飼 保存用イベント追加 >>>>>>START
            this._StockMoveInput.save += new MAZAI04120UA.SaveEventHandler(Save);
            // 2009.04.02 30413 犬飼 保存用イベント追加 <<<<<<END
        }
        # endregion

        //----------------------------------------------------------------------------------------------------
        //  プライベイトメンバ
        //----------------------------------------------------------------------------------------------------
        # region プライベイトメンバ

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;

        // 在庫移動入力画面
        private MAZAI04120UA _StockMoveInput;
        private StockMoveInputDataSet.StockMoveDataTable _StockMoveDataTable;
        private StockMoveInputAcs _StockMoveInputAcs;

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // 在庫確定処理入力画面
        private MAZAI04128UA _StockMoveFixInput;
        //private MAZAI04128UB _StockMoveFixInputGrid;
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        // 在庫移動入荷処理入力画面
        private MAZAI04129UA _StockMoveArrivalGoodsInput;
        //private MAZAI04129UB _StockMoveArrivalGoodsInputGrid;

        // 初期値情報
        private StockMoveInputInitDataAcs _StockMoveInputInitAcs;

        //----- ADD K2013/09/11 田建委 ---------->>>>>
        /// <summary>フタバ出力済伝票制御（個別）</summary>
        private int _opt_FutabaCtrl;
        //----- ADD K2013/09/11 田建委 ----------<<<<<

        // ヘッダ情報
        private StockMoveHeader _StockMoveHeader;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // ツールバーキャプション設定
        private ToolBarCaptionAcs _toolBarCaptionAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        private ImageList _imageList16 = null;				    // イメージリスト
        private ButtonTool _closeButton;			            // 終了ボタン
        private ButtonTool _saveButton;			                // 保存ボタン
        private ButtonTool _retryButton;			            // 元に戻すボタン
        private ButtonTool _newButton;			                // 新規ボタン
        private ButtonTool _deleteButton;			            // 伝票削除ボタン
        private ButtonTool _loadButton;			                // 伝票呼出ボタン
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _outPutButton;                     // 伝票出力ボタン
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        //private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;			        // ガイドボタン
        private ButtonTool _StockMoveInputButton;	            // 出荷処理ボタン
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _StockMoveFixInputButton;	        // 在庫移動確定ボタン
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        private ButtonTool _StockMoveArrivalGoodsInputButton;	// 入荷処理ボタン
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private ButtonTool _setupButton;                        // 設定ボタン
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        private ButtonTool _renewalButton;

        private LabelTool _sectionTitleLabel;                   // 拠点コードラベル
        private LabelTool _sectionLabel;                        // 拠点名ラベル
        private LabelTool _loginEmployeeLabel;                  // ログイン担当者ラベル
        private LabelTool _loginEmployeeName;                   // ログイン担当者名ラベル

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // 印刷可不可フラグ(true:利用可 false:利用不可)
        private bool printCheck = true;

        ///// <summary>OLEコントロール制御部品</summary>
        //private OLEPrintController _olePrtController;

        /// <summary>IPrintインタフェース</summary>
        public SFCMN06002C _sfcmn06002C = new SFCMN06002C();
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        private bool _isNewFlag = false; // 新規、修正フラグ（保存用）// ADD 2010/11/15
        # endregion

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// オペレーションコード
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>修正</summary>
            Revision = 10,
            /// <summary>削除</summary>
            Delete = 11,
        }

        // 操作権限の制御オブジェクトの保有
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("MAZAI04100U", this);
                }
                return _operationAuthority;
            }
        }

        private bool GetOperationAuthority()
        {
            if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
            {
                return (true);
            }

            return (false);
        }

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        private void BeginControllingByOperationAuthority()
        {
            // 伝票削除ボタン
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Visible = false;
                ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Shortcut = Shortcut.None;
            }
        }

        private void SetButtonDispAfterSearchArrival()
        {
            this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = true;
        }
        /// <summary>
        /// グリッド品番列Enter時処理
        /// </summary>
        /// <param name="goodsNoFlg">品番列フラグ(True:品番 False:品番以外)</param>
        private void EnterGoodsNoColumn(Boolean goodsNoFlg)
        {
            if (goodsNoFlg == true)
            {
                this.ultraStatusBar1.Panels[0].Text = "前方一致検索：最後に*を入力[例:A*]";
            }
            else
            {
                this.ultraStatusBar1.Panels[0].Text = "";
            }
        }

        private void ChangeFocusFooter(Boolean changeFlg)
        {
            if (changeFlg == true)
            {
                this._saveButton.SharedProps.Caption = "保存(F10)";
            }
            else
            {
                this._saveButton.SharedProps.Caption = "確定(F10)";
            }
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        //----------------------------------------------------------------------------------------------------
        //  コントロールイベントハンドラ
        //----------------------------------------------------------------------------------------------------
        # region コントロールイベントハンドラ
        /// <summary>
        /// フォームロードイベントハンドラ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void MAZAI04100UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            this.Panel_Detail.Controls.Add(this._StockMoveInput);
            this._StockMoveInput.Dock = DockStyle.Fill;
            this._StockMoveInput.Visible = true;

            // ボタン初期設定処理
            ButtonInitialSetting();

            BeginControllingByOperationAuthority();

            // ログイン情報表示
            this._sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            this._loginEmployeeName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            // ファンクションキー対応
            this._toolBarCaptionAcs = new ToolBarCaptionAcs();
            this._toolBarCaptionAcs.GetToolbarCaptionsFileInfoList();
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// フォームロードイベントハンドラ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// Note       : フォームがロードされた時に発動します<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.24<br />
        /// </remarks>
        private void MAZAI04100UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            this.Panel_Detail.Controls.Add(this._StockMoveInput);
            this._StockMoveInput.Dock = DockStyle.Fill;
            this._StockMoveInput.Visible = true;

            // 仮に他の画面を非表示にする。(後々はパラメータによって制御する。)
            //this._StockMoveFixInput.Visible = false;
            //this._StockMoveArrivalGoodsInput.Visible = false;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // ログイン情報表示
            _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            _loginEmployeeName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            // OPOS使用準備
            // 端末がPOSに設定されている場合のときのみ実行
            //if (_StockMoveInputInitAcs.POSPCTermCd == 1)
            //{
            //int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// OLEControllerのインスタンス生成
            //this._olePrtController = new OLEPrintController();
            //try
            //{
            //    #region -- OLEControllerのロード処理 --
            //    string message = "";
            //    status = this._olePrtController.LoadOleControl(_StockMoveInputInitAcs.POSPCTermCd, ref message);
            //    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //    {
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
            //                    "MAZAI04100U",
            //                    "プリンタ初期化にてエラーが発生しました。\n" + message + "\n",
            //                    status,
            //                    MessageBoxButtons.OK);

            //        TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_INFO,
            //                this.Name,
            //                "プリンタの初期化に失敗したため、移動伝票は印刷できません。",
            //                -1,
            //                MessageBoxButtons.OK);

            //        this.printCheck = false;
            //        _StockMoveInput.CheckBoxEnableChange();

            //        return;
            //    }
            //    #endregion

            //    #region -- デバイスのオープン処理 --
            //    status = this._olePrtController.Open(ref message);
            //    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //    {
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
            //                    "MAZAI04100U",
            //                    "プリンタ初期化にてエラーが発生しました。\n" + message,
            //                    status,
            //                    MessageBoxButtons.OK);

            //        TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_INFO,
            //                this.Name,
            //                "プリンタの初期化に失敗したため、移動伝票は印刷できません。",
            //                -1,
            //                MessageBoxButtons.OK);

            //        this.printCheck = false;
            //        _StockMoveInput.CheckBoxEnableChange();

            //        return;
            //    }
            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    string msg = ex.Message;
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
            //                    "MAZAI04100U",
            //                    "プリンタ初期化にてエラーが発生しました。\n" + msg + "\n",
            //                    status,
            //                    MessageBoxButtons.OK);

            //    TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "プリンタの初期化に失敗したため、移動伝票は印刷できません。",
            //            -1,
            //            MessageBoxButtons.OK);

            //    this.printCheck = false;
            //    _StockMoveInput.CheckBoxEnableChange();

            //}

            //..保留　伝票印刷はfalse固定

            //this.printCheck = false;
            //_StockMoveInput.CheckBoxEnableChange();


            // ファンクションキー対応
            _toolBarCaptionAcs = new ToolBarCaptionAcs();
            _toolBarCaptionAcs.GetToolbarCaptionsFileInfoList();

            this.ReflectSetup();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>
        /// 設定フォーム設定適用
        /// </summary>
        private void ReflectSetup ()
        {
            StockMoveInputConstructionAcs stockMoveInputConstructionAcs = new StockMoveInputConstructionAcs();
            int index = stockMoveInputConstructionAcs.FunctionMode;

            // ツールバー設定
            try
            {
                if ( _toolBarCaptionAcs.DisplayNameList.Count > index )
                {
                    _toolBarCaptionAcs.SettingToolBarCaptions( index, "MAZAI04100UA", ref this.ToolbarsManager_Main );
                }
            }
            catch
            {
                // 設定時エラー
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更
        # endregion

        //----------------------------------------------------------------------------------------------------
        //  プライベートメソッド
        //----------------------------------------------------------------------------------------------------
        # region プライベートメソッド
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.ToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._retryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            this._newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._loadButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
            this._StockMoveInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._StockMoveArrivalGoodsInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._renewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;

            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // ボタン制御
            if (_StockMoveInput != null)
            {
                StockMoveButtonSettings("ButtonTool_StockMove");
            }
            if (_StockMoveArrivalGoodsInput != null)
            {
                StockMoveButtonSettings("ButtonTool_StockArrivalGoods");
            }
        }

        // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
        private int _printOutOptionValueBackup = -1;

        private int PrintOutOptionValueBackup
        {
            get { return _printOutOptionValueBackup; }
            set { _printOutOptionValueBackup = value; }
        }
        // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<

        /// <summary>
        /// 在庫移動画面表示
        /// </summary>
        /// <returns>ステータス</returns>
        private int StockMoveDisplay()
        {
            Boolean successFlg = false;

            //-------------------------------------------------
            // 在庫移動画面以外の画面は非表示にする。
            //-------------------------------------------------

            // 入荷処理画面
            if (_StockMoveArrivalGoodsInput != null)
            {
                successFlg = StockMoveArrivalGoodsInputClose();
                if (successFlg == true)
                {
                    this._StockMoveArrivalGoodsInput = null;
                }
            }

            if (successFlg == true)
            {
                this._StockMoveInput = new MAZAI04120UA();

                this._StockMoveInput.enterGoodsNoColumn += new MAZAI04120UA.EnterGoodsNoColumnEventHandler(EnterGoodsNoColumn);
                this._StockMoveInput.changeFocusFooter += new MAZAI04120UA.ChangeFocusFooterEventHandler(ChangeFocusFooter);
                this._StockMoveInput.loadSlipGuide += new MAZAI04120UA.LoadSlipGuideEventHandler(this.SlipLoad);
                this._StockMoveInput.setSlipInfo += new MAZAI04120UA.SetSlipInfoEventHandler(this.SetDisplay);
                // 2009.04.02 30413 犬飼 保存用イベント追加 >>>>>>START
                this._StockMoveInput.save += new MAZAI04120UA.SaveEventHandler(Save);
                // 2009.04.02 30413 犬飼 保存用イベント追加 <<<<<<END

                this.Panel_Detail.Controls.Add(this._StockMoveInput);
                this._StockMoveInput.Dock = DockStyle.Fill;
                this._StockMoveInput.DataTableSettings();
                this._StockMoveInput.Visible = true;
                // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
                this._StockMoveInput.SetPrintOutOptionValue(PrintOutOptionValueBackup);
                // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<

                // ボタン制御
                StockMoveButtonSettings("ButtonTool_StockMove");
                this._sectionLabel.SharedProps.Caption = this._StockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
                ChangeFocusFooter(false);
            }

            return 0;
        }

        /// <summary>
        /// 在庫移動入荷画面表示
        /// </summary>
        /// <returns>ステータス</returns>
        private int StockArrivalGoodsDisplay()
        {
            Boolean successFlg = false;

            ChangeFocusFooter(true);

            //-------------------------------------------------
            // 在庫移動入荷画面以外の画面は非表示にする。
            //-------------------------------------------------

            // 出荷処理画面
            if (_StockMoveInput != null)
            {
                // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
                PrintOutOptionValueBackup = this._StockMoveInput.GetPrintOutOptionValue();
                // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<

                successFlg = StockMoveInputClose();
                if (successFlg == true)
                {
                    this._StockMoveInput = null;
                }
            }

            if (successFlg == true)
            {
                this._StockMoveArrivalGoodsInput = new MAZAI04129UA();
                this._StockMoveArrivalGoodsInput.searchAfter += new MAZAI04129UA.SearchAfterEventHandler(SetButtonDispAfterSearchArrival);

                this.Panel_Detail.Controls.Add(this._StockMoveArrivalGoodsInput);
                this._StockMoveArrivalGoodsInput.Dock = DockStyle.Fill;
                this._StockMoveArrivalGoodsInput.DataTableSettings();
                this._StockMoveArrivalGoodsInput.Visible = true;

                // ボタン制御
                StockMoveButtonSettings("ButtonTool_StockArrivalGoods");

                this._sectionLabel.SharedProps.Caption = this._StockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            }
            return 0;
        }

        /// <summary>
        /// 設定フォーム表示
        /// </summary>
        private void SetupFormDisplay()
        {
            ArrayList userSettingList;
            this._StockMoveInput.GetUserSetting(out userSettingList);

            // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            //StockMoveInputSetUp setupForm = new StockMoveInputSetUp(userSettingList);
            // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            StockMoveInputSetUp setupForm = new StockMoveInputSetUp(userSettingList, this._StockMoveInput);
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<

            DialogResult res = setupForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                userSettingList = setupForm.UserSettingList;
                this._StockMoveInput.SetUserSetting(userSettingList);
                // ----- ADD 2010/11/15 ---------------->>>>>
                // グリッド情報XML保存
                this._StockMoveInput.SaveXmlData();
                // ----- ADD 2010/11/15 ----------------<<<<<
            }
        }

        /// <summary>
        /// 在庫移動画面表示ボタン制御
        /// </summary>
        /// <returns>ステータス</returns>
        private void StockMoveButtonSettings(string displayName)
        {
            switch (displayName)
            {
                case "ButtonTool_StockMove":
                    {
                        this._StockMoveInputInitAcs.ReadStockMngTtlSt();        //ADD 2009/06/04　在庫管理全体設定読み込み

                        // 現在表示されている画面のボタンを非表示にし、それ以外を表示する。
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Visible = false;
                        //this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Visible = true;       //DEL 2009/06/04
                        // ---ADD 2009/06/04 --------------------------------------------------------------------->>>>>
                        // 入荷処理(F8)ボタン設定　在庫管理全体設定の在庫移動確定区分に従う
                        if (this._StockMoveInputInitAcs.StockMoveFixCode == 1)
                        {
                            this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Visible = true;
                            this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = true;     //ADD 2009/06/23 不具合対応[13614]  非表示でもF8押下で遷移してしまう為
                        }
                        else
                        {
                            this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Visible = false;
                            this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = false;    //ADD 2009/06/23 不具合対応[13614]  非表示でもF8押下で遷移してしまう為
                        }
                        // ---ADD 2009/06/04 ---------------------------------------------------------------------<<<<<

                        // 伝票呼出、削除、設定ボタン
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;

                        break;
                    }
                case "ButtonTool_StockArrivalGoods":
                    {
                        // 現在表示されている画面のボタンを非表示にし、それ以外を表示する。
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Visible = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Visible = false;

                        // 伝票呼出、削除、設定ボタン
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;

                        break;
                    }
            }
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.ToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._retryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            this._newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._loadButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
            this._outPutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINTOUT;
            //this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._StockMoveInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._StockMoveFixInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._StockMoveArrivalGoodsInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 移動伝票出力ボタン
            this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

            // ボタン制御
            //if (_StockMoveInput.Visible == true)
            if (_StockMoveInput != null)
            {
                this.StockMoveButtonSettings("ButtonTool_StockMove");
            }

            //if (_StockMoveFixInput.Visible == true)
            if (_StockMoveFixInput != null)
            {
                this.StockMoveButtonSettings("ButtonTool_StockDecision");
            }

            //if (_StockMoveArrivalGoodsInput.Visible == true)
            if (_StockMoveArrivalGoodsInput != null)
            {
                this.StockMoveButtonSettings("ButtonTool_StockArrivalGoods");
            }
        }

        /// <summary>
        /// 在庫移動画面表示
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// Note       : 在庫移動画面を表示します。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private int StockMoveDisplay()
        {
            Boolean successFlg = false;

            // 在庫移動画面以外の画面は非表示にする。

            if (_StockMoveFixInput != null)
            {
                successFlg = this.StockMoveInputFixClose();
                if (successFlg == true)
                {
                    this._StockMoveFixInput = null;
                }
            }

            if (_StockMoveArrivalGoodsInput != null)
            {
                successFlg = this.StockMoveArrivalGoodsInputClose();
                if (successFlg == true)
                {
                    this._StockMoveArrivalGoodsInput = null;
                }
            }

            if (successFlg == true)
            {
                _StockMoveInput = new MAZAI04120UA();

                // 拠点コード変更イベント登録
                _StockMoveInput.SectionChange += new EventHandler( StockMoveInput_SectionChange );

                this.Panel_Detail.Controls.Add(this._StockMoveInput);
                this._StockMoveInput.Dock = DockStyle.Fill;
                _StockMoveInput.DataTableSettings();
                this._StockMoveInput.Visible = true;

                // ボタン制御
                this.StockMoveButtonSettings("ButtonTool_StockMove");
                _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );
            }

            return 0;
        }

        /// <summary>
        /// 在庫移動確定画面表示
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// Note       : 在庫移動確定画面を表示します。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private int StockDecisionDisplay()
        {
            Boolean successFlg = false;

            // 在庫移動確定画面以外の画面は非表示にする。
            if (_StockMoveInput != null)
            {
                successFlg = this.StockMoveInputClose();
                if (successFlg == true)
                {
                    this._StockMoveInput = null;
                }
            }

            if (_StockMoveArrivalGoodsInput != null)
            {
                successFlg = this.StockMoveArrivalGoodsInputClose();
                if (successFlg == true)
                {
                    this._StockMoveArrivalGoodsInput = null;
                }
            }

            if (successFlg == true)
            {
                // 画面インスタンスの生成
                _StockMoveFixInput = new MAZAI04128UA();

                // 拠点変更イベント
                _StockMoveFixInput.SectionChange += new EventHandler( StockMoveInput_SectionChange );

                this.Panel_Detail.Controls.Add(this._StockMoveFixInput);
                this._StockMoveFixInput.Dock = DockStyle.Fill;
                _StockMoveFixInput.DataTableSettings();
                this._StockMoveFixInput.Visible = true;

                // ボタン制御
                this.StockMoveButtonSettings("ButtonTool_StockDecision");

                _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );
            } 
            return 0;
        }
        
        /// <summary>
        /// 在庫移動入荷画面表示
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// Note       : 在庫移動入荷画面を表示します。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private int StockArrivalGoodsDisplay()
        {
            Boolean successFlg = false;

            // 在庫移動入荷画面以外の画面は非表示にする。
            if (_StockMoveInput != null)
            {
                successFlg = this.StockMoveInputClose();
                if (successFlg == true)
                {
                    this._StockMoveInput = null;
                }
            }

            if (this._StockMoveFixInput != null)
            {
                successFlg = this.StockMoveInputFixClose();
                if (successFlg == true)
                {
                    this._StockMoveFixInput = null;
                }
            }

            if (successFlg == true)
            {
                _StockMoveArrivalGoodsInput = new MAZAI04129UA();

                _StockMoveArrivalGoodsInput.SectionChange += new EventHandler( StockMoveInput_SectionChange );

                this.Panel_Detail.Controls.Add(this._StockMoveArrivalGoodsInput);
                this._StockMoveArrivalGoodsInput.Dock = DockStyle.Fill;
                _StockMoveArrivalGoodsInput.DataTableSettings();
                this._StockMoveArrivalGoodsInput.Visible = true;

                // ボタン制御
                this.StockMoveButtonSettings("ButtonTool_StockArrivalGoods");

                _sectionLabel.SharedProps.Caption = _StockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );
            }
            return 0;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 設定フォーム表示
        /// </summary>
        private void SetupFormDisplay ()
        {
            // 設定フォームを表示
            StockMoveInputSetUp setupForm = new StockMoveInputSetUp( _toolBarCaptionAcs.DisplayNameList );
            setupForm.ShowDialog();
            
            // 設定内容をメインフレームに適用
            this.ReflectSetup();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// 在庫移動画面表示ボタン制御
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// Note       : 表示されている画面によってボタンの制御を行います。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private void StockMoveButtonSettings(string displayName)
        {
            switch (displayName)
            {
                case "ButtonTool_StockMove":
                    {
                        // ボタンのグループヘッダを変更する。
                        //_StockMoveInputButton.InstanceProps.IsFirstInGroup = false;
                        //_StockMoveFixInputButton.InstanceProps.IsFirstInGroup = true;
                        //_StockMoveArrivalGoodsInputButton.InstanceProps.IsFirstInGroup = false;

                        // 現在表示されている画面のボタンを非表示にし、それ以外を表示する。
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockDecision"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = true;

                        // 伝票呼出、削除ボタンを表示
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

                        // 移動伝票出力ボタンを非表示
                        this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                        // 移動伝票出力ラジオボタン表示非表示
                        if (this.printCheck == false)
                        {
                            _StockMoveInput.CheckBoxEnableChange();
                        }

                        break;
                    }
                case "ButtonTool_StockDecision":
                    {
                        // ボタンのグループヘッダを変更する。
                        //_StockMoveInputButton.InstanceProps.IsFirstInGroup = true;
                        //_StockMoveFixInputButton.InstanceProps.IsFirstInGroup = false;
                        //_StockMoveArrivalGoodsInputButton.InstanceProps.IsFirstInGroup = false;

                        // 現在表示されている画面のボタンを非表示にし、それ以外を表示する。
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockDecision"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = true;

                        // 伝票呼出、削除ボタンを非表示
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;

                        // 移動伝票出力ボタンを非表示
                        this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                        break;

                    }
                case "ButtonTool_StockArrivalGoods":
                    {
                        // ボタンのグループヘッダを変更する。
                        //_StockMoveInputButton.InstanceProps.IsFirstInGroup = true;
                        //_StockMoveFixInputButton.InstanceProps.IsFirstInGroup = false;
                        //_StockMoveArrivalGoodsInputButton.InstanceProps.IsFirstInGroup = false;

                        // 現在表示されている画面のボタンを非表示にし、それ以外を表示する。
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockMove"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockDecision"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_StockArrivalGoods"].SharedProps.Enabled = false;

                        // 伝票呼出、削除ボタンを非表示
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;

                        // 移動伝票出力ボタンを非表示
                        this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                        break;
                    }
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note : 2011/05/10 tianjw redmine #20901</br>
        private void ToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close(true);
                        break;
                    }
                case "ButtonTool_New":
                    {
                        // 新規処理
                        New();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // ----- ADD 2011/05/10 tianjw ------------------->>>>>
                        if (this._StockMoveArrivalGoodsInput != null)
                        {
                            EventArgs ex = new EventArgs();
                            this._StockMoveArrivalGoodsInput.ArrivalGoodsDay_tDateEdit_Leave(this, ex);
                        }
                        // ----- ADD 2011/05/10 tianjw -------------------<<<<<
                        // 保存処理
                        this.Save();

                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 元に戻す処理
                        this.Retry();

                        break;
                    }
                case "ButtonTool_Load":
                    {
                        // 伝票区分「-1:項目非表示、0:出庫伝票、1:入庫伝票」(保存処理前にAクラスにセットする必要有り)
                        this._StockMoveInputAcs.SlipDiv = this._StockMoveInput.GetSlipDiv();        //ADD 2009/06/04

                        // 伝票呼出処理
                        this.SlipLoad();

                        break;
                    }
                case "ButtonTool_Delete":
                    {
                        // 伝票削除処理
                        this.Delete();

                        break;
                    }
                /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
                case "ButtonTool_OutPut":
                    {
                        // 移動伝票出力
                        this.SlipOutput();

                        break;
                    }
                   --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
                case "ButtonTool_StockMove":
                    {
                        // 在庫移動画面表示処理
                        this.StockMoveDisplay();
                        break;
                    }
                /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
                case "ButtonTool_StockDecision":
                    {
                        // 在庫移動確定画面表示処理
                        this.StockDecisionDisplay();
                        break;
                    }
                   --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
                case "ButtonTool_StockArrivalGoods":
                    {
                        // 在庫移動入荷画面表示処理
                        this.StockArrivalGoodsDisplay();
                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                case "ButtonTool_Setup":
                    {
                        // 設定ＵＩ
                        this.SetupFormDisplay();
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                case "ButtonTool_Renewal":
                    {
                        // 在庫移動入力画面にて最新情報ボタンが押下された場合
                        if (this._StockMoveInput != null)
                        {
                            _StockMoveInput.Renewal();
                        }

                        // 在庫移動入荷入力にて最新情報ボタンが押下された場合
                        if (this._StockMoveArrivalGoodsInput != null)
                        {
                            _StockMoveArrivalGoodsInput.Renewal();
                        }

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                             "最新情報を取得しました。",
                                             0,
                                             MessageBoxButtons.OK,
                                             MessageBoxDefaultButton.Button1);
                        break;
                    }
            }
        }

        /// <summary>
        /// 画面クローズ処理
        /// </summary>
        /// <returns>ステータス</returns>
        private void Close(bool boolean)
        {
            Boolean status = false;

            // 在庫移動入力画面にてクローズボタンが押下された場合
            if (_StockMoveInput != null)
            {
                status = StockMoveInputClose();
            }

            // 在庫移動入荷入力にてクローズボタンが押下された場合
            if (_StockMoveArrivalGoodsInput != null)
            {
                status = StockMoveArrivalGoodsInputClose();
            }

            if (status == true)
            {
                Close();
            }
        }

        /// <summary>
        /// 新規処理
        /// </summary>
        /// <br>Update Note: 2010/12/09 曹文傑 新規入力時で、保存実行後に「新規ボタン」押下時のメッセージの有無判断追加</br>
        private void New()
        {
            // 在庫移動入力画面にて新規ボタンが押下された場合
            if (this._StockMoveInput != null)
            {
                if (!_StockMoveInput.CompareBeforeNewProc())
                {
                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                          "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                                          "初期状態に戻しますか？",
                                                          0,
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxDefaultButton.Button1);

                    if (res != DialogResult.Yes)
                    {
                        return;
                    }

                    // ツールバーボタンの初期化
                    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = true;   // TODO:[最新情報]ボタン

                    // ヘッダの情報を削除
                    this._StockMoveInputInitAcs.StockMoveHeaderClear();
                    this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    // 画面の初期化
                    this._StockMoveInput.HeaderClear();

                    // データテーブルの内容を削除
                    this._StockMoveInput.Clear();
                }
                // ---ADD 2010/12/09------->>>>>
                else
                {
                    if (_isNewFlag)
                    {
                        // ツールバーボタンの初期化
                        this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;
                        this.ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = true;

                        // ヘッダの情報を削除
                        this._StockMoveInputInitAcs.StockMoveHeaderClear();
                        this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                        // 画面の初期化
                        this._StockMoveInput.HeaderClear();

                        // データテーブルの内容を削除
                        this._StockMoveInput.Clear();
                        _isNewFlag = false;
                    }
                }
                // ---ADD 2010/12/09-------<<<<<
            }

            // 在庫移動入荷入力にて新規ボタンが押下された場合
            if (this._StockMoveArrivalGoodsInput != null)
            {
                if (!this._StockMoveArrivalGoodsInput.CompareBeforeNewProc())
                {
                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                          "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                                          "初期状態に戻しますか？",
                                                          0,
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxDefaultButton.Button1);


                    if (res != DialogResult.Yes)
                    {
                        return;
                    }

                    // ツールバーボタンの初期化
                    this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;

                    // ヘッダの情報を削除
                    this._StockMoveInputInitAcs.StockMoveHeaderClear();
                    this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    // 画面の初期化
                    this._StockMoveArrivalGoodsInput.HeaderClear();

                    // データテーブルの内容を削除
                    this._StockMoveArrivalGoodsInput.Clear();
                }
            }
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <br>Update Note : 2010/11/15 曹文傑 障害改良対応「５，６，７」の対応</br>
        private void Save()
        {
            if (this._saveButton.SharedProps.Caption == "確定(F10)")
            {
                if (this._StockMoveInput.ActiveControl.Parent == this._StockMoveInput.Detail_panel)
                {
                    ChangeFocusFooter(true);
                    this._StockMoveInput.Outline_tEdit.Focus();
                }
                else
                {
                    this._StockMoveInput._stockMoveInput.ReturnKeyDownEnterFocus();
                }
                return;
            }

            DialogResult dr = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                             "登録してもよろしいですか？",
                                             0,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.No)
            {
                return;
            }

            // 在庫移動入力画面にて保存ボタンが押下された場合
            if (this._StockMoveInput != null)
            {
                // グリッド編集確定
                this._StockMoveInput.DetailReturnKeyDown();

                // 保存処理
                if (StockMoveInputSave() == true)
                {
                    this._StockMoveInput.SetTableUpdateFlg();

                    // 伝票印刷処理
                    if (_StockMoveInput.GetPrintCheck() == true)
                    {
                        this.SlipOutput();
                    }

                    // ---UPD 2010/11/15---------------->>>>>
                    // 画面をクリア
                    //this._StockMoveInput.Clear();

                    // 画面をクリア
                    if (this._isNewFlag == false)
                    {
                        this._StockMoveInput.Clear();
                    }
                    else
                    {
                        this._StockMoveInput.ClearAfterSave();
                    }
                    // ---UPD 2010/11/15----------------<<<<<

                    // 前回伝票番号設定
                    this._StockMoveInput.SetLastSlipNo(this._StockMoveInputAcs.StockMoveSlipNo);

                    // 削除ボタンを無効
                    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;

                    // ---UPD 2010/11/15---------------->>>>>
                    // フォーカスの移動
                    //this._StockMoveInput.ChangeFocus("SAVE");

                    // フォーカスの移動
                    if (this._isNewFlag == false)
                    {
                        this._StockMoveInput.ChangeFocus("SAVE");
                    }
                    else
                    {
                        // 新規入力時の保存実行後のフォーカスは、明細１行目の品番へ移動する
                        this._StockMoveInput.ChangeFocusAfterSave();
                    }
                    // ---UPD 2010/11/15----------------<<<<<
                }
            }

            // 在庫移動入荷入力にて保存ボタンが押下された場合
            if (this._StockMoveArrivalGoodsInput != null)
            {
                // ヘッダ、フッタ情報の格納をチェック
                if (this._StockMoveArrivalGoodsInput.HeaderFooterCheck() == true)
                {
                    // ヘッダ、フッタ情報を格納
                    this._StockMoveArrivalGoodsInput.SetHeaderFooterInfoFromDisplay();

                    StockArrivalGoodsInputSave();

                    this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;
                }
                _StockMoveArrivalGoodsInput.Clear();//ADD 2010/11/15
            }

            
        }

        /// <summary>
        /// 元に戻す処理
        /// </summary>
        private void Retry()
        {
            // 在庫移動入力画面にて元に戻すボタンが押下された場合
            if (this._StockMoveInput != null)
            {
                this.StockMoveInputRetry();
            }

            // 在庫移動入荷入力にて元に戻すボタンが押下された場合
            if (this._StockMoveArrivalGoodsInput != null)
            {
                this.StockArrivalGoodsInputRetry();
            }
        }

        /// <summary>
        /// 伝票呼出処理
        /// </summary>
        private void SlipLoad()
        {
            MAZAI04120UD StockMoveSlipSearch = new MAZAI04120UD();

            // 在庫移動伝票検索画面表示
            this._StockMoveInput.GuideShow();

            SetDisplay();
        }

        private void SetDisplay()
        {
            // ガイドから選択された場合のみ登録
            if (this._StockMoveInputInitAcs.GuideSelected == true)
            {
                if (this._StockMoveDataTable.Count > 0)
                {
                    this._StockMoveInputInitAcs.RegistMode = 1;
                }
                else
                {
                    this._StockMoveInputInitAcs.RegistMode = 0;
                }

                this._StockMoveInput.FixAndArrivalCheck();

                // 保存ボタン、削除ボタンを押下可能にする。
                this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

                //// 確定済みか入荷済みのチェック(確定データ、入荷データは削除や変更はできない)
                //if (this._StockMoveInput.FixAndArrivalCheck() == false)
                //{
                //    // 保存ボタン、削除ボタンを押下不能にする。
                //    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                //    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                //}
                //else
                //{
                //    // 保存ボタン、削除ボタンを押下可能にする。
                //    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                //    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
                //}

                // 元に戻すボタン
                this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = true;
                // DEL 2010/06/15 MANTIS対応[15317]：保存後も[最新情報]ボタンを操作可能に ---------->>>>>
                // TODO:[最新情報]ボタン
                //this.ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = false;
                // DEL 2010/06/15 MANTIS対応[15317]：保存後も[最新情報]ボタンを操作可能に ----------<<<<<

                // データテーブルから取得したデータをヘッダ情報に格納
                // 2009.07.07 >>>
                //this._StockMoveInput.setHeader(_StockMoveHeader.StockMvEmpCode,
                //                          _StockMoveHeader.StockMvEmpName,
                //                          _StockMoveHeader.ShipmentScdlDay,
                //                          _StockMoveHeader.AfSectionCode,
                //                          _StockMoveHeader.AfSectionGuideName,
                //                          _StockMoveHeader.AfEnterWarehCode,
                //                          _StockMoveHeader.AfEnterWarehName,
                //                          _StockMoveHeader.BfSectionCode,
                //                          _StockMoveHeader.BfSectionGuideName,
                //                          _StockMoveHeader.BfEnterWarehCode,
                //                          _StockMoveHeader.BfEnterWarehName,
                //                          _StockMoveHeader.OutLine,
                //                          _StockMoveHeader.StockMoveSlipNo);

                // 入荷伝票の場合には、入荷日を表示する為、移動形式を取得して判断する
                int stockMoveFormal = this._StockMoveInput.GetReadDataStockMoveFormal();
                DateTime date = ( stockMoveFormal > 2 ) ? _StockMoveHeader.ArrivalGoodsDay : _StockMoveHeader.ShipmentScdlDay;

                this._StockMoveInput.setHeader(_StockMoveHeader.StockMvEmpCode,
                                          _StockMoveHeader.StockMvEmpName,
                                          date,
                                          _StockMoveHeader.AfSectionCode,
                                          _StockMoveHeader.AfSectionGuideName,
                                          _StockMoveHeader.AfEnterWarehCode,
                                          _StockMoveHeader.AfEnterWarehName,
                                          _StockMoveHeader.BfSectionCode,
                                          _StockMoveHeader.BfSectionGuideName,
                                          _StockMoveHeader.BfEnterWarehCode,
                                          _StockMoveHeader.BfEnterWarehName,
                                          _StockMoveHeader.OutLine,
                                          _StockMoveHeader.StockMoveSlipNo);
                // 2009.07.07 <<<

                // ガイド選択フラグを初期化
                this._StockMoveInputInitAcs.GuideSelected = false;

                // 合計金額更新
                this._StockMoveInput.SetDisplayTotalMoveingPrice();

                this._StockMoveInput.SetRowDeleteEnable(false);
            }
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面クローズ処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// Note       : 画面をクローズした際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private void Close(bool boolean)
        {
            Boolean status = false;

            // 在庫移動入力画面にてクローズボタンが押下された場合
            if (_StockMoveInput != null)
            {
                status = this.StockMoveInputClose();
            }

            // 在庫移動確定画面にてクローズボタンが押下された場合
            if (_StockMoveFixInput != null)
            {
                status = this.StockMoveInputFixClose();
            }

            // 在庫移動入荷入力にてクローズボタンが押下された場合
            if (_StockMoveArrivalGoodsInput != null)
            {
                status = this.StockMoveArrivalGoodsInputClose();
            }

            if (status == true)
            {
                this.Close();
            }
        }
        
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// Note       : 保存ボタンを押下した際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private void Save()
        {
            // 在庫移動入力画面にて保存ボタンが押下された場合
            if (_StockMoveInput != null)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // グリッド編集確定
                _StockMoveInput.DetailReturnKeyDown();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // ヘッダ、フッタ情報の格納をチェック
                if (_StockMoveInput.HeaderFooterCheck() == true)
                {
                    // ヘッダ、フッタ情報を格納
                    _StockMoveInput.SetHeaderFooterInfoFromDisplay();

                    // 本社機能制限チェック
                    if (_StockMoveInput.MainOfficeFuncCheck() == false)
                    {
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "他拠点の倉庫移動はできません。",
                                -1,
                                MessageBoxButtons.OK);
                        return;
                    }

                    // 移動先拠点、移動先倉庫整合性チェック
                    if (_StockMoveInput.AfIntegrationCheck() == false)
                    {
                        TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "移動先倉庫が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                        return;
                    }

                    // 受託在庫の利用可能チェック
                    switch (_StockMoveInput.TrustStockCheck())
                    {
                        case 1:
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "受託在庫の拠点間移動が許可されていません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                return;
                            }
                        case 2:
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "受託在庫の倉庫間移動が許可されていません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                return;
                            }
                    }

                    if (this.StockMoveInputSave() == true)
                    {
                        _StockMoveInput.SetTableUpdateFlg();

                        // 伝票印刷処理
                        if (_StockMoveInput.PrintCheck == true)
                        {
                            this.SlipOutput();
                        }

                        // 画面をクリア
                        _StockMoveInput.Clear();

                        // フォーカスの移動
                        _StockMoveInput.ChangeFocus("SAVE");
                    }
                }

                // 移動伝票出力ボタンを非表示
                this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;
            }

            // 在庫移動確定画面にて保存ボタンが押下された場合
            if (_StockMoveFixInput != null)
            {
                // ヘッダ、フッタ情報の格納をチェック
                if (_StockMoveFixInput.HeaderFooterCheck() == true)
                {
                    // ヘッダ、フッタ情報を格納
                    _StockMoveFixInput.SetHeaderFooterInfoFromDisplay();

                    this.StockMoveFixInputSave();
                }
            }

            // 在庫移動入荷入力にて保存ボタンが押下された場合
            if (_StockMoveArrivalGoodsInput != null)
            {
                // ヘッダ、フッタ情報の格納をチェック
                if (_StockMoveArrivalGoodsInput.HeaderFooterCheck() == true)
                {
                    // ヘッダ、フッタ情報を格納
                    _StockMoveArrivalGoodsInput.SetHeaderFooterInfoFromDisplay();

                    this.StockArrivalGoodsInputSave();
                }
            }
        }
        
        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <remarks>
        /// Note       : 元に戻すボタンを押下した際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.23<br />
        /// </remarks>
        private void Retry()
        {
            // 在庫移動入力画面にて元に戻すボタンが押下された場合
            if (_StockMoveInput != null)
            {
                this.StockMoveInputRetry();
            }

            // 在庫移動確定画面にて元に戻すボタンが押下された場合
            if (_StockMoveFixInput != null)
            {
                this.StockMoveFixInputRetry();
            }

            // 在庫移動入荷入力にて元に戻すボタンが押下された場合
            if (_StockMoveArrivalGoodsInput != null)
            {
                this.StockArrivalGoodsInputRetry();
            }
        }

        /// <summary>
        /// 伝票呼出処理
        /// </summary>
        /// <remarks>
        /// Note       : 伝票呼出ボタンを押下した際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.03.03<br />
        /// </remarks>
        private void SlipLoad()
        {
            MAZAI04120UD StockMoveSlipSearch = new MAZAI04120UD();

            // 在庫移動伝票検索画面表示
            _StockMoveInput.GuideShow();

            // ガイドから選択された場合のみ登録
            if (_StockMoveInputInitAcs.GuideSelected == true)
            {
                if (_StockMoveDataTable.Count > 0)
                {
                    _StockMoveInputInitAcs.RegistMode = 1;
                }
                else
                {
                    _StockMoveInputInitAcs.RegistMode = 0;
                }

                // 確定済みか入荷済みのチェック(確定データ、入荷データは削除や変更はできない)
                if (this._StockMoveInput.FixAndArrivalCheck() == false)
                {
                    // 保存ボタン、削除ボタンを押下不能にする。
                    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                }
                else
                {
                    // 保存ボタン、削除ボタンを押下可能にする。
                    this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
                }

                // 移動伝票出力ボタンを表示
                if (this.printCheck == true)
                {
                    this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = true;
                }
                else
                {
                    this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;
                }

                // 最終レコードに空きレコードを1件作成
                // 最終行の場合は、１行追加する
                this._StockMoveInputAcs.AddStockDetailRow();

                string[] splitString = _StockMoveDataTable[0].ShipmentScdlDay.Split('/');
                DateTime convShipmentScdlDay = new DateTime(Int32.Parse(splitString[0]), Int32.Parse(splitString[1]), Int32.Parse(splitString[2]));

                // データテーブルから取得したデータをヘッダ情報に格納
                _StockMoveInput.setHeader(_StockMoveHeader.StockMvEmpCode,
                                          _StockMoveHeader.StockMvEmpName,
                                          _StockMoveHeader.ShipmentScdlDay,
                                          _StockMoveHeader.AfSectionCode,
                                          _StockMoveHeader.AfSectionGuideName,
                                          _StockMoveHeader.AfEnterWarehCode,
                                          _StockMoveHeader.AfEnterWarehName,
                                          _StockMoveHeader.BfSectionCode,
                                          _StockMoveHeader.BfSectionGuideName,
                                          _StockMoveHeader.BfEnterWarehCode,
                                          _StockMoveHeader.BfEnterWarehName,
                                          _StockMoveHeader.OutLine,
                                          _StockMoveHeader.StockMoveSlipNo);

                // ガイド選択フラグを初期化
                _StockMoveInputInitAcs.GuideSelected = false;

                // 合計金額更新
                _StockMoveInput.SetDisplayTotalPriceInfo();

                _StockMoveInput.SetRowDeleteEnable(false);
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        #region DEL 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 拠点コード変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StockMoveInput_SectionChange( object sender, EventArgs e )
        {
            // 拠点名称
            string sectionName = string.Empty;

            // 拠点名称を取得する
            if ( sender == _StockMoveInput )
            {
                // 移動入力
                sectionName = _StockMoveInput.GetSectionName();
            }
            else if ( sender == _StockMoveFixInput )
            {
                // 移動確定
                sectionName = _StockMoveFixInput.GetSectionName();
            }
            else if ( sender == _StockMoveArrivalGoodsInput )
            {
                // 移動入庫
                sectionName = _StockMoveArrivalGoodsInput.GetSectionName();
            }


            // 正常に取得できれば、拠点名称を書きかえる
            if ( !string.IsNullOrEmpty( sectionName ) )
            {
                _sectionLabel.SharedProps.Caption = sectionName;
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 使用していないのでコメントアウト

        /// <summary>
        /// 伝票削除処理
        /// </summary>
        private void Delete()
        {
            Boolean saveCheck = false;
            int stockMoveSlipNo = 0;

            foreach (StockMoveInputDataSet.StockMoveRow row in this._StockMoveDataTable)
            {
                if (row.GoodsNo != null || row.GoodsNo != "")
                {
                    saveCheck = true;
                    stockMoveSlipNo = row.StockMoveSlipNo;
                }
            }

            if (saveCheck == true && stockMoveSlipNo != 0)
            {
                // 読み込まれた伝票を削除する
                DialogResult dialogResult = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                           "表示中の移動伝票" + "を削除します。" + "\r\n" + "\r\n" +
                                                           "よろしいですか？",
                                                           0,
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxDefaultButton.Button1);

                // 編集データを登録して閉じる場合
                if (dialogResult == DialogResult.Yes)
                {
                    DateTime targetDate;

                    if (!this._StockMoveInputInitAcs.CheckHisTotalDayMonthly(this._StockMoveInputInitAcs.StockMoveHeader.BfSectionCode.Trim(), this._StockMoveInput.GetSlipmentDay(), out targetDate))
                    {
                        string errMsg = "出荷日が前回月次更新日以前になっている為、削除できません。" + "\r\n\r\n" + "  前回月次更新日：" + targetDate.ToString("yyyy年MM月dd日");
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                               errMsg,
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);
                        return;
                    }
                    //----- ADD K2013/09/11 田建委 ---------->>>>>
                    if (CheckStockMoveData(this._StockMoveInputAcs.StockMoveDataTable[0].StockMoveSlipNo) == false)
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        "テキスト変換済みのデータの為、更新できません。",
                                        0,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);

                        return;
                    }
                    //----- ADD K2013/09/11 田建委 ----------<<<<<

                    int slipNo;
                    int status = this._StockMoveInputAcs.DeleteStockMove(out slipNo);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                               "移動伝票を削除しました。",
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);

                                // ログ出力
                                if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Delete))
                                {
                                    MyOpeCtrl.Logger.WriteOperationLog(
                                        "Delete",
                                        (int)OperationCode.Delete,
                                        0,
                                        string.Format("{0}伝票、伝票番号:{1}を削除", "在庫移動", slipNo.ToString("000000000")));
                                }

                                // 画面初期化
                                this._StockMoveInput.Clear();

                                // フォーカス移動
                                this._StockMoveInput.ChangeFocus("DELETE");

                                // 削除ボタンを無効
                                this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                                this.ToolbarsManager_Main.Tools["ButtonTool_Undo"].SharedProps.Enabled = false;
                                return;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            {
                                ExclusiveTransaction(status);
                                return;
                            }
                        // 企業ロックタイムアウト
                        case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                            {
                                TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "削除に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                                    "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                                return;
                            }
                        // 拠点ロックタイムアウト
                        case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                            {
                                TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "削除に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                                    "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                                return;
                            }
                        // 倉庫ロックタイムアウト
                        case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                            {
                                TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "削除に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                                    "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                                return;
                            }
                        default:
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                               "Delete",
                                               "移動伝票の削除に失敗しました。",
                                               status,
                                               MessageBoxButtons.OK);
                                return;
                            }
                    }
                }
                // 編集データを登録せずに閉じる場合
                else if (dialogResult == DialogResult.No)
                {
                    // 何もしない
                }
            }
            else
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "削除する移動伝票がありません。",
                               -1,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
            }
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 伝票削除処理
        /// </summary>
        /// <remarks>
        /// Note       : 伝票削除ボタンを押下した際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.03.03<br />
        /// </remarks>
        private void Delete()
        {
            Boolean saveCheck = false;
            int stockMoveSlipNo= 0;

            foreach (StockMoveInputDataSet.StockMoveRow row in _StockMoveDataTable) 
            {
                if ( row.GoodsNo != null || row.GoodsNo != "" ) 
                {
                    saveCheck = true;
                    stockMoveSlipNo = row.StockMoveSlipNo;
                }
            }

            if (saveCheck == true && stockMoveSlipNo != 0) 
            {
                // 読み込まれた伝票を削除する
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "表示中の移動伝票" + "を削除します。" + "\r\n" + "\r\n" +
                    "よろしいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                // 編集データを登録して閉じる場合
                if (dialogResult == DialogResult.Yes)
                {
                    int status = _StockMoveInputAcs.DeleteStockMove();
                    // 登録に成功した場合にのみ、画面を閉じる。
                    if (status == 0)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "移動伝票を削除しました。",
                            -1,
                            MessageBoxButtons.OK);

                        // 画面初期化
                        _StockMoveInput.Clear();

                        // フォーカス移動
                        _StockMoveInput.ChangeFocus("DELETE");
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "移動伝票の削除に失敗しました。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                }
                // 編集データを登録せずに閉じる場合
                else if (dialogResult == DialogResult.No) 
                {
                    // 何もしない
                }
            }
            else {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "削除する移動伝票がありません。",
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 在庫移動伝票出力処理
        /// </summary>
        /// <remarks>
        /// Note       : 在庫移動伝票を出力します。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.07.11<br />
        /// </remarks>
        private void SlipOutput()
        {
            try
            {
                MAZAI02172PA _MAZAI02172PA = new MAZAI02172PA();

                //_MAZAI04123PA._outputMode = outputMode;

                _MAZAI02172PA.Printinfo = _sfcmn06002C;

                _MAZAI02172PA.Printinfo.rdData = _StockMoveInputAcs.StockMoveDataTable;

                _MAZAI02172PA.Printinfo.prevkbn = 1;//PreViewする

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 排他アクセス権取得
                //this.GetOLEControlClaim();

                //// デバイスコントローラを渡す
                //_MAZAI02172PA.DeviceHandle = this._olePrtController;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                _MAZAI02172PA.StartPrint();
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// OPOSデバイスコントロールアクセス権破棄
                //this.ReleaseOLEControlClaim();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // データテーブルソートのクリア
                _StockMoveInputAcs.StockMoveDataTable.DefaultView.Sort = "";
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫移動伝票出力処理
        /// </summary>
        /// <remarks>
        /// Note       : 在庫移動伝票を出力します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/10/03<br />
        /// </remarks>
        private void SlipOutput()
        {
            try
            {
                // 在庫移動伝票 印刷条件設定
                StockMoveSlipPrintCndtn cndtn = new StockMoveSlipPrintCndtn();
                cndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                cndtn.StockMoveSlipKeyList = new List<StockMoveSlipPrintCndtn.StockMoveSlipKey>();

                int stockMoveFormal;
                int stockMoveSlipNo;

                if (this._StockMoveInput.GetSlipNo() == "")
                {
                    // 新規保存後に伝票出力する場合
                    stockMoveFormal = this._StockMoveInputAcs.StockMoveFormal; 
                    stockMoveSlipNo = this._StockMoveInputAcs.StockMoveSlipNo;
                    cndtn.ReissueDiv = false;
                }
                else
                {
                    // 伝票呼出後に伝票出力する場合
                    stockMoveFormal = this._StockMoveInput.GetStockMoveFormal();
                    stockMoveSlipNo = int.Parse(this._StockMoveInput.GetSlipNo());
                    cndtn.ReissueDiv = true;
                }

                cndtn.StockMoveSlipKeyList.Add(new StockMoveSlipPrintCndtn.StockMoveSlipKey(stockMoveFormal, stockMoveSlipNo));

                // 在庫移動伝票 印刷
                DCCMN02000UA slipPrtDialog = new DCCMN02000UA();
                slipPrtDialog.Print(cndtn);
            }
            finally
            {
                // データテーブルソートのクリア
                _StockMoveInputAcs.StockMoveDataTable.DefaultView.Sort = "";
            }
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 在庫移動入力画面時クローズ処理
        /// </summary>
        /// <remarks>
        /// Note       : 在庫移動入力画面時に閉じるボタンが押下された際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private Boolean StockMoveInputClose()
        {
            // 編集中か確認
            if (!_StockMoveInput.CompareBeforeNewProc())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                "登録してもよろしいですか？",
                0,
                MessageBoxButtons.YesNoCancel,
                MessageBoxDefaultButton.Button1);

                // 編集データを登録して閉じる場合
                if (dialogResult == DialogResult.Yes)
                {
                    Boolean status = this.StockMoveInputSave();

                    // 登録に成功した場合にのみ、画面を閉じる。
                    if (status == true)
                    {
                        // ヘッダ及び検索条件を初期化
                        _StockMoveInputInitAcs.StockMoveHeaderClear();
                        _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                        _StockMoveInput.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // 編集データを登録せずに閉じる場合
                else if (dialogResult == DialogResult.No)
                {
                    // ヘッダ及び検索条件を初期化
                    _StockMoveInputInitAcs.StockMoveHeaderClear();
                    _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    _StockMoveInput.Close();
                    return true;
                }
                // キャンセルされた場合
                else
                {
                    return false;
                }
            }
            // 編集中でない場合はそのまま閉じる。
            else
            {
                // ヘッダ及び検索条件を初期化
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                _StockMoveInput.Close();
                return true;
            }
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫移動確定画面時クローズ処理
        /// </summary>
        /// <remarks>
        /// Note       : 在庫移動確定画面時に閉じるボタンが押下された際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private Boolean StockMoveInputFixClose()
        {
            // 編集中か確認
            if (_StockMoveFixInput.CloseDataCheck())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                "登録してもよろしいですか？",
                0,
                MessageBoxButtons.YesNoCancel,MessageBoxDefaultButton.Button1);

                // 編集データを登録して閉じる場合
                if (dialogResult == DialogResult.Yes)
                {
                    Boolean status = this.StockMoveFixInputSave();

                    // 登録に成功した場合にのみ、画面を閉じる。
                    if (status == true)
                    {
                        // ヘッダ及び検索条件を初期化
                        _StockMoveInputInitAcs.StockMoveHeaderClear();
                        _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                        _StockMoveFixInput.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // 編集データを登録せずに閉じる場合
                else if (dialogResult == DialogResult.No)
                {
                    // ヘッダ及び検索条件を初期化
                    _StockMoveInputInitAcs.StockMoveHeaderClear();
                    _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    _StockMoveFixInput.Close();
                    return true;
                }
                // キャンセルされた場合
                else
                {
                    return false;
                }
            }
            // 編集中でない場合はそのまま閉じる。
            else
            {
                // ヘッダ及び検索条件を初期化
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                _StockMoveFixInput.Close();
                return true;
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "MAZAI04100U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,				            // プログラム名称
                            "ExclusiveTransaction", 			// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "既に他端末より更新されています。", // 表示するメッセージ
                            status, 							// ステータス値
                            this._StockMoveInputAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "MAZAI04100U", 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,				            // プログラム名称
                            "ExclusiveTransaction", 			// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "既に他端末より削除されています。", // 表示するメッセージ
                            status, 							// ステータス値
                            this._StockMoveInputAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// 在庫移動入荷入力画面時クローズ処理
        /// </summary>
        /// <remarks>
        /// Note       : 在庫移動入荷入力画面時にクローズボタンが押下された際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private Boolean StockMoveArrivalGoodsInputClose()
        {
            // 編集中か確認
            if (!_StockMoveArrivalGoodsInput.CompareBeforeNewProc())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                "登録してもよろしいですか？",
                0,
                MessageBoxButtons.YesNoCancel,
                MessageBoxDefaultButton.Button1);

                // 編集データを登録して閉じる場合
                if (dialogResult == DialogResult.Yes)
                {
                    Boolean status = this.StockArrivalGoodsInputSave();

                    // 登録に成功した場合にのみ、画面を閉じる。
                    if (status == true)
                    {
                        // ヘッダ及び検索条件を初期化
                        _StockMoveInputInitAcs.StockMoveHeaderClear();
                        _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                        _StockMoveArrivalGoodsInput.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // 編集データを登録せずに閉じる場合
                else if (dialogResult == DialogResult.No)
                {
                    // ヘッダ及び検索条件を初期化
                    _StockMoveInputInitAcs.StockMoveHeaderClear();
                    _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    _StockMoveArrivalGoodsInput.Close();
                    return true;
                }
                // キャンセルされた場合
                else
                {
                    return false;
                }
            }
            // 編集中でない場合はそのまま閉じる。
            else
            {
                // ヘッダ及び検索条件を初期化
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                _StockMoveArrivalGoodsInput.Close();
                return true;
            }
        }

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 出荷処理保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Update Date: K2013/09/11 田建委</br>
        /// <br>           : フタバ個別対応</br>
        /// <br>           : テキスト変換後のデータを修正・削除不可とする。</br>
        /// </remarks>
        private Boolean StockMoveInputSave()
        {
            // 伝票修正時
            if (_StockMoveInput.GetEnabledSupplierSlipNo() == false)
            {
                if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                               "セキュリティにより伝票修正が制限されています。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                    return (false);
                }
            }

            // 入力チェック
            if (this._StockMoveInput.CheckInputScreen() == false)
            {
                return (false);
            }

            // ヘッダ、フッタ情報を格納
            this._StockMoveInput.SetHeaderFooterInfoFromDisplay();

            Boolean saveCheck = false;
            foreach (StockMoveInputDataSet.StockMoveRow row in this._StockMoveDataTable)
            {
                if (row.GoodsNo != null && row.GoodsNo != "")
                {
                    saveCheck = true;
                    break;
                }
            }

            if (saveCheck == false)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "保存するデータが存在しません。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (false);
            }

            //----- ADD K2013/09/11 田建委 ---------->>>>>
            if (CheckStockMoveData(this._StockMoveInputAcs.StockMoveDataTable[0].StockMoveSlipNo) == false)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "テキスト変換済みのデータの為、更新できません。",
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);

                return (false);
            }
            //----- ADD K2013/09/11 田建委 ----------<<<<<

            // 伝票印刷区分(保存処理前にAクラスにセットする必要有り)
            _StockMoveInputAcs.SlipPrint = _StockMoveInput.GetPrintCheck();

            // 伝票区分「-1:項目非表示、0:出庫伝票、1:入庫伝票」(保存処理前にAクラスにセットする必要有り)
            this._StockMoveInputAcs.SlipDiv = this._StockMoveInput.GetSlipDiv();        //ADD 2009/06/04

            // 保存処理 
            bool isNew;
            int status = this._StockMoveInputAcs.WriteStockMove(out isNew);
            this._isNewFlag = isNew; // ADD 2010/11/15
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (!isNew)
                        {
                            // ログ出力
                            if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Revision))
                            {
                                MyOpeCtrl.Logger.WriteOperationLog(
                                    "Revision",
                                    (int)OperationCode.Revision,
                                    0,
                                    string.Format("{0}伝票、伝票番号:{1}を修正", "在庫移動", this._StockMoveInputAcs.StockMoveSlipNo.ToString("000000000")));
                            }
                        }

                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // 保存に成功したら更新モードを新規に変更
                        this._StockMoveInputInitAcs.RegistMode = 0;
                        
                        // 画面を初期化
                        this._StockMoveInputInitAcs.StockMoveHeaderClear();

                        return (true);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        ExclusiveTransaction(status);
                        return (false);
                    }
                // 企業ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "保存に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                                    "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                // 拠点ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "保存に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                                    "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                // 倉庫ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "保存に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                                    "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                case -2:
                case -9:
                    {
                        string errMsg;
                        if (status == -2)
                        {
                            errMsg = "更新データ内に既に確定済のデータが存在します。";
                        }
                        else
                        {
                            errMsg = "更新データ内に既に入荷済のデータが存在します。";
                        }

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               errMsg,
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "StockMoveInputSave",
                                       "保存に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }
        }

        /// <summary>
        /// 入荷処理保存処理
        /// </summary>
        /// <return>
        /// true: 登録成功, false: 登録失敗
        /// </return>
        /// <remarks>
        /// <br>Update Date: K2013/09/11 田建委</br>
        /// <br>           : フタバ個別対応</br>
        /// <br>           : テキスト変換後のデータを修正・削除不可とする。</br>
        /// </remarks>
        private Boolean StockArrivalGoodsInputSave()
        {
            // 登録データチェック
            if (this._StockMoveDataTable.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "保存するデータが存在しません。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (false);
            }

            // 入荷日
            DateTime targetDate = this._StockMoveArrivalGoodsInput.GetArrivalGoodsDay();

            for (int index = 0; index < this._StockMoveInputAcs.StockMoveDataTable.Rows.Count; index++)
            {
                // 変更データ
                if (this._StockMoveInputAcs.StockMoveDataTable[index].ArrivalFlag !=
                    this._StockMoveInputAcs.StockMoveDataTableBackup[index].ArrivalFlag)
                {
                    // 入庫拠点
                    string sectionCode = this._StockMoveInputAcs.StockMoveDataTable[index].AfSectionCode;

                    DateTime prevTotalDay;

                    if (!this._StockMoveInputInitAcs.CheckHisTotalDayMonthly(sectionCode, targetDate, out prevTotalDay))
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                               "入荷日が前回月次更新日以前になっている為、登録できません。" + "\r\n\r\n" + "  前回月次更新日：" + prevTotalDay.ToString("yyyy年MM月dd日"),
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                        return (false);
                    }
                }

            }

            bool existsCancelData = false;  // ADD 2010/06/11 入荷取消の確認は1回だけ
            //----- ADD K2013/09/11 田建委 ---------->>>>>
            bool canSaveFlg = true;
            ArrayList errorSlipNoList = new ArrayList();
            ArrayList stockMoveSlipNoList = new ArrayList();
            //----- ADD K2013/09/11 田建委 ----------<<<<<
            for (int index = 0; index < this._StockMoveInputAcs.StockMoveDataTable.Rows.Count; index++)
            {
                if (this._StockMoveInputAcs.StockMoveDataTable[index].ArrivalFlag !=
                    this._StockMoveInputAcs.StockMoveDataTableBackup[index].ArrivalFlag)
                {
                    if (this._StockMoveInputAcs.StockMoveDataTable[index].MoveStatus != 9)
                    {
                        
                        // DEL 2010/06/11 入荷取消の確認は1回だけ ---------->>>>>
                        //DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                        //                                  "入荷取消を行うデータが含まれていますが、よろしいですか？",
                        //                                  0,
                        //                                  MessageBoxButtons.OKCancel,
                        //                                  MessageBoxDefaultButton.Button1);
                        //if (res == DialogResult.Cancel)
                        //{
                        //    return (false);
                        //}
                        // DEL 2010/06/11 入荷取消の確認は1回だけ ----------<<<<<
                        // ADD 2010/06/11 入荷取消の確認は1回だけ ---------->>>>>
                        existsCancelData = true;
                        // ADD 2010/06/11 入荷取消の確認は1回だけ ----------<<<<<
                        //----- ADD K2013/09/11 田建委 ---------->>>>>
                        if (!stockMoveSlipNoList.Contains(this._StockMoveInputAcs.StockMoveDataTable[index].StockMoveSlipNo))
                        {
                            if (CheckStockMoveData(this._StockMoveInputAcs.StockMoveDataTable[index].StockMoveSlipNo) == false)
                            {
                                canSaveFlg = false;
                                errorSlipNoList.Add(this._StockMoveInputAcs.StockMoveDataTable[index].StockMoveSlipNo);
                            }
                            stockMoveSlipNoList.Add(this._StockMoveInputAcs.StockMoveDataTable[index].StockMoveSlipNo);
                        }
                        //----- ADD K2013/09/11 田建委 ----------<<<<<
                    }
                }
            }
            // ADD 2010/06/11 入荷取消の確認は1回だけ ---------->>>>>
            if (existsCancelData)
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                      "入荷取消を行うデータが含まれていますが、よろしいですか？",
                                      0,
                                      MessageBoxButtons.OKCancel,
                                      MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Cancel)
                {
                    return (false);
                }
            }
            // ADD 2010/06/11 入荷取消の確認は1回だけ ----------<<<<<
            //----- ADD K2013/09/11 田建委 ---------->>>>>
            if (!canSaveFlg)
            {
                string stockMoveSlipNo = string.Empty;
                errorSlipNoList.Sort();
                if (errorSlipNoList.Count > 0)
                {
                    for (int i = 0; i < errorSlipNoList.Count; i++)
                    {
                        stockMoveSlipNo += "【伝票番号：" + errorSlipNoList[i].ToString().PadLeft(9, '0') + "】";
                        if (i != errorSlipNoList.Count - 1)
                        {
                            stockMoveSlipNo += Environment.NewLine;
                        }
                    }
                }
                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "入荷取消対象にテキスト変換済みのデータが存在する為、入荷取消できません。" + Environment.NewLine + stockMoveSlipNo,
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);

                return (false);
            }
            //----- ADD K2013/09/11 田建委 ----------<<<<<
            // 保存処理
            ArrayList stockMoveWorkList;
            int status = this._StockMoveInputAcs.WriteStockMoveArrival(out stockMoveWorkList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //foreach (StockMoveWork stockMoveWork in stockMoveWorkList)
                        //{
                        //    // ログ出力
                        //    if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Revision))
                        //    {
                        //        MyOpeCtrl.Logger.WriteOperationLog(
                        //            "Revision",
                        //            (int)OperationCode.Revision,
                        //            0,
                        //            string.Format("{0}伝票、伝票番号:{1}を修正", "在庫移動", stockMoveWork.StockMoveSlipNo.ToString("000000000")));
                        //    }
                        //}

                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        ExclusiveTransaction(status);
                        return (false);
                    }
                // 企業ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "保存に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                                    "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                // 拠点ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "保存に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                                    "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                // 倉庫ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "保存に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                                    "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                        return (false);
                    }
                case -1:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "該当データが存在しません。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "StockArrivalGoodsInputSave",
                                       "保存に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// 在庫移動入力画面時元に戻す処理
        /// </summary>
        private void StockMoveInputRetry()
        {
            if (!_StockMoveInput.CompareBeforeRetry())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                      "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                                      "初期状態に戻しますか？",
                                                      0,
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxDefaultButton.Button1);

                if (res != DialogResult.Yes)
                {
                    return;
                }

                _StockMoveInput.RetryProc();

                //// ツールバーボタンの初期化
                //this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                //this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;

                //// ヘッダの情報を削除
                //this._StockMoveInputInitAcs.StockMoveHeaderClear();
                //this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                //// 画面の初期化
                //this._StockMoveInput.HeaderClear();

                //// データテーブルの内容を削除
                //this._StockMoveInput.Clear();

            }
        }

        /// <summary>
        /// 在庫移動入荷入力画面時元に戻す処理
        /// </summary>
        private void StockArrivalGoodsInputRetry()
        {
            if (!this._StockMoveArrivalGoodsInput.CompareBeforeRetry())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                      "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                                      "初期状態に戻しますか？",
                                                      0,
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxDefaultButton.Button1);


                if (res != DialogResult.Yes)
                {
                    return;
                }

                _StockMoveArrivalGoodsInput.RetryProc();
                //// ヘッダの情報を削除
                //this._StockMoveInputInitAcs.StockMoveHeaderClear();
                //this._StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                //// 画面の初期化
                //this._StockMoveArrivalGoodsInput.HeaderClear();

                //// データテーブルの内容を削除
                //this._StockMoveArrivalGoodsInput.Clear();
            }
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAZAI04100UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._StockMoveInput != null)
            {
                this._StockMoveInput.Close();
            }
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         "MAZAI04100U",                     // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         "MAZAI04100U", 		  　　		// アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._StockMoveInputAcs,			// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        /// <summary>
        /// 終了ボタンクリックイベント(Escキーがクリックされた時に発生します)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンを「Visible = False」にすると、イベントが発生しないため、
            // サイズを「1, 1」にし、実質的に見えないようにする

            DialogResult dResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "終了してもよろしいですか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                this.Close(true);
            }
        }

        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫移動入力画面時保存処理
        /// </summary>
        /// <return>
        /// true: 登録成功, false: 登録失敗
        /// </return>
        /// <remarks>
        /// Note       : 在庫移動入力画面時に保存ボタンが押下された際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.26<br />
        /// </remarks>
        private Boolean StockMoveInputSave()
        {
            // 移動元倉庫コード入力チェック
            if (_StockMoveInput.bfEnterwarehCodeCheck() == false)
            {
                return false;
            }

            Boolean saveCheck = false;

            foreach (StockMoveInputDataSet.StockMoveRow row in _StockMoveDataTable)
            {
                if ( row.GoodsNo != null && row.GoodsNo != "" )
                {
                    saveCheck = true;
                }
            }

            // １レコードでも商品コードあるものがあれば登録
            if (saveCheck == true)
            {
                // 在庫移動データ登録 
                int status = _StockMoveInputAcs.WriteStockMove();

                if (status == 0)
                {
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);

                    // 保存に成功したら更新モードを新規に変更
                    _StockMoveInputInitAcs.RegistMode = 0;

                    // 画面を初期化
                    _StockMoveInputInitAcs.StockMoveHeaderClear();

                    return true;

                }
                else if (status == 5)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "在庫数量が不足しています。",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -2)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "更新データ内に既に確定済のデータが存在します。",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -3)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "同一倉庫への在庫移動処理はできません。",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -4)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "登録するレコード内に出荷数0が存在します。",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -5)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "マスタに登録されていないメーカーコードが存在します。",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -6)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "マスタに登録されていないBL商品コードが存在します。",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else if (status == -9)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "更新データ内に既に入荷済のデータが存在します。",
                        status,
                        MessageBoxButtons.OK);

                    return false;
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "保存に失敗しました。(" + status + ")",
                        status,
                        MessageBoxButtons.OK);

                    return false;

                }
            }
            // 無ければ登録データはない
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "保存するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }
        }
        
        /// <summary>
        /// 在庫移動確定画面時保存処理
        /// </summary>
        /// <return>
        /// true: 登録成功, false: 登録失敗
        /// </return>
        /// <remarks>
        /// Note       : 在庫移動確定画面時に保存ボタンが押下された際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.26<br />
        /// </remarks>
        private Boolean StockMoveFixInputSave()
        {
            // 登録データチェック
            if (_StockMoveDataTable.Count == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "保存するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            int status = _StockMoveInputAcs.WriteStockMoveFix();

            if (status == 0)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);

                return true;

            }
            else if (status == -1)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当データがありません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "保存に失敗しました。(" + status + ")",
                    status,
                    MessageBoxButtons.OK);

                return false;

            }
        }

        /// <summary>
        /// 在庫移動入荷入力画面時保存処理
        /// </summary>
        /// <return>
        /// true: 登録成功, false: 登録失敗
        /// </return>
        /// <remarks>
        /// Note       : 在庫移動入荷入力画面時に保存ボタンが押下された際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.01.26<br />
        /// </remarks>
        private Boolean StockArrivalGoodsInputSave()
        {
            // 登録データチェック
            if (_StockMoveDataTable.Count == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "保存するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }

            int status = _StockMoveInputAcs.WriteStockMoveArrival();

            if (status == 0)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);

                return true;

            }
            else if (status == -1)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当データがありません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "保存に失敗しました。(" + status + ")",
                    status,
                    MessageBoxButtons.OK);

                return false;

            }
        }

        /// <summary>
        /// 在庫移動入力画面時元に戻す処理
        /// </summary>
        /// <remarks>
        /// Note       : 在庫移動入力画面時に元に戻すボタンが押下された際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private void StockMoveInputRetry()
        {
            if (_StockMoveInput.CloseDataCheck())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "初期状態に戻しますか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                // ツールバーボタンの初期化
                this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

                // 移動伝票出力ボタンを非表示
                this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                // ヘッダの情報を削除
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                // 画面の初期化
                _StockMoveInput.HeaderClear();

                // データテーブルの内容を削除
                _StockMoveInput.Clear();

            }
            else
            {
                // ツールバーボタンの初期化
                this.ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                this.ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

                // 移動伝票出力ボタンを非表示
                this.ToolbarsManager_Main.Tools["ButtonTool_OutPut"].SharedProps.Enabled = false;

                // ヘッダの情報を削除
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                // 画面の初期化
                _StockMoveInput.HeaderClear();

                // データテーブルの内容を削除
                _StockMoveInput.Clear();
            }
        }

        /// <summary>
        /// 在庫移動確定画面時元に戻す処理
        /// </summary>
        /// <remarks>
        /// Note       : 在庫移動確定画面時に元に戻すボタンが押下された際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private void StockMoveFixInputRetry()
        {
            if (_StockMoveFixInput.CloseDataCheck())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "初期状態に戻しますか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                // ヘッダの情報を削除
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                // 画面の初期化
                _StockMoveFixInput.HeaderClear();

                // データテーブルの内容を削除
                _StockMoveFixInput.Clear();

            }
        }

        /// <summary>
        /// 在庫移動入荷入力画面時元に戻す処理
        /// </summary>
        /// <remarks>
        /// Note       : 在庫移動入荷入力画面時に元に戻すボタンが押下された際に行われる処理です。<br />
        /// Programer  : 20008 伊藤 豊<br />
        /// Date       : 2007.02.20<br />
        /// </remarks>
        private void StockArrivalGoodsInputRetry()
        {
            if (_StockMoveArrivalGoodsInput.CloseDataCheck())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "初期状態に戻しますか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                // ヘッダの情報を削除
                _StockMoveInputInitAcs.StockMoveHeaderClear();
                _StockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                // 画面の初期化
                _StockMoveArrivalGoodsInput.HeaderClear();

                // データテーブルの内容を削除
                _StockMoveArrivalGoodsInput.Clear();
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// OPOS排他アクセス権取得
        /// </summary>
        private void GetOLEControlClaim()
        {
            //#region < OPOS排他アクセス権取得 >
            //int OPOSstatus = (int)OPOSConstantManagement.emOPOS.OPOS_E_NOSERVICE;
            //string message = "";

            //// OPOSの排他アクセス権を取得
            //OPOSstatus = this._olePrtController.ClaimDevice(0, ref message);
            //if (OPOSstatus != (int)OPOSConstantManagement.emOPOS.OPOS_SUCCESS)
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
            //                "MAZAI04100U",
            //                "排他アクセス権の取得に失敗しました。\n" + message,
            //                OPOSstatus,
            //                MessageBoxButtons.OK);
            //    return;
            //}
            //#endregion

            //#region < デバイス使用区分(True) >
            //// デバイスを使用するためのプロパティをTrueにする
            //this._olePrtController.DeviceEnabled = true;
            //#endregion
        }

        /// <summary>
        /// OPOS排他アクセス権破棄
        /// </summary>
        private void ReleaseOLEControlClaim()
        {
            //#region < OPOS排他アクセス権開放 >
            //string errMessage = "";
            //this._olePrtController.DeviceEnabled = false;
            //this._olePrtController.ReleaseDevice(ref errMessage);
            //#endregion
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        # endregion

        //----- ADD K2013/09/11 田建委 ---------->>>>>
        #region ■フタバ個別対応■
        #region ■列挙体■
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        #endregion

        #region ■オプション情報キャッシュ■
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●フタバ出力済伝票制御（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaOutSlipCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FutabaCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_FutabaCtrl = (int)Option.OFF;
            }
            #endregion
        }
        #endregion

        #region ■フタバ売上移動出力データの取得■
        /// <summary>
        /// フタバ売上移動出力データの取得
        /// </summary>
        /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : フタバ売上移動出力データを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        private bool CheckStockMoveData(int stockMoveSlipNo)
        {
            bool canSaveFlg = true;
            // オプション情報キャッシュ
            CacheOptionInfo();

            if (_opt_FutabaCtrl == (int)Option.ON)
            {
                int status = this._StockMoveInputAcs.CheckFTStockMoveData(stockMoveSlipNo);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    canSaveFlg = false;
                }
            }

            return canSaveFlg;
        }
        #endregion
        #endregion
        //----- ADD K2013/09/11 田建委 ----------<<<<<
    }
}
