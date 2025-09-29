//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ
// プログラム概要   : キャンペーン対象商品設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10701342-00 作成担当 : 曹文傑
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/07  修正内容 : Redmine#22810 ①明細項目の幅・文字サイズは変更時に保存の対応
//                                                ②左右端の項目で止まるように修正
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/12  修正内容 : Redmine#22919 ①初回起動時の文字サイズと項目幅の変更
//                                                ②明細のキャンペーンコードに初期表示するように変更
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/14  修正内容 : Redmine#22984 最終行の情報がデータ登録されない
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/21  修正内容 : Redmine#23199 ヘッダでキャンペーンコードを入力後に、検索実行後、１件もデータがない場合に、明細内容指定不正の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許雁波
// 修 正 日  2011/08/12  修正内容 : Redmine#23556 初期化ロードは並べて処理して、時間が減少するように修正する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30973　鹿庭
// 更 新 日  2015/01/29  修正内容 : レコメンド対応 お買得商品設定呼出し追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30973　鹿庭
// 更 新 日  2015/06/02  修正内容 : レコメンド対応 お買得商品設定呼出しの使用停止
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Collections;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;
using System.Threading;
// DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 ----------------------------------->>>>>
//using Broadleaf.Application.Resources;  // ADD 2015/01/29 鹿庭
// DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 -----------------------------------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタUIフォームクラス</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22810 ①明細項目の幅・文字サイズは変更時に保存の対応</br>
    /// <br>　　　　　　　　　　　　　　　　　　　　　 ②左右端の項目で止まるように修正</br>
    /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ①初回起動時の文字サイズと項目幅の変更</br>
    /// <br>　　　　　　　　　　　　　　　　　　　　　 ②明細のキャンペーンコードに初期表示するように変更</br>
    /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
    /// <br>UpdateNote : 2011/07/21 譚洪 Redmine#23199 ヘッダでキャンペーンコードを入力後に、検索実行後、１件もデータがない場合に、明細内容指定不正の修正</br>
    /// </remarks>
    public partial class PMKHN09621UA : Form
    {
        # region Private Members
        private PMKHN09621UB _detailInput;
        private ImageList _imageList16 = null;                                                // イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;                    // クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;                    // ガイドボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;                    // 最新情報ボタン
        // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 ----------------------------------->>>>>
        //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 ----------------------------------->>>>>
        //private Infragistics.Win.UltraWinToolbars.ButtonTool _recBgnItmStButton;              // お買得商品設定ボタン
        //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 -----------------------------------<<<<<
        // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 -----------------------------------<<<<<
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ログイン担当者
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;                  // ログイン担当者名称
        private ControlScreenSkin _controlScreenSkin;
        private Control _prevControl = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private CampaignObjGoodsStAcs _campaignObjGoodsStAcs = null;
        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        private CampaignLinkAcs _campaignLinkAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private UserGuideAcs _userGuideAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;
        private BLGroupUAcs _blGroupUAcs;

        /// <summary>伝票表示タブ 列サイズ自動調整値</summary>
        private bool _columnWidthAutoAdjust = false;

        private int _prevSectionCd = 0;
        private int _prevCampaignCd = 0;
        private bool _masterCheckFlg = false;
        private SearchCondition _searchCondition = null;
        private bool _isButtonClick = false;

        // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 ----------------------------------->>>>>
        //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 ----------------------------------->>>>>
        ///// <summary>SCMオプション</summary>
        //private int _opt_Scm;
        ///// <summary>オプション有効有無</summary>
        //private enum Option : int
        //{
        //    /// <summary>無効</summary>
        //    OFF = 0,
        //    /// <summary>有効</summary>
        //    ON = 1,
        //}
        //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 -----------------------------------<<<<<
        // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 -----------------------------------<<<<<

        #endregion

        #region const
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// 終了
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";					// 検索
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// 保存
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// クリア
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// ガイド
        private const string TOOLBAR_RENEWALBUTTON_KEY = "ButtonTool_ReNewal";					// 最新情報
        private const string TOOLBAR_SHOWMASTERBUTTON_KEY = "ButtonTool_ShowMaster";			// キャンペーン名称設定
        // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 ----------------------------------->>>>>
        //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 ----------------------------------->>>>>
        //private const string TOOLBAR_SHORECBGNITMST_KEY = "ButtonTool_RecBgnItmSt";	            // お買得商品設定
        //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 -----------------------------------<<<<<
        // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 -----------------------------------<<<<<

        /// <summary>表示：初期フォントサイズ</summary>
        //private const int CT_DEF_FONT_SIZE = 11;   // DEL 2011/07/12
        private const int CT_DEF_FONT_SIZE = 10;     // ADD 2011/07/12

        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        /// <summary>文字サイズ</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        /// <summary>明細データ抽出最大件数</summary>
        private const long DATA_COUNT_MAX = 20000;
        #endregion

        # region Constroctors
        /// <summary>
        ///  キャンペーン対象商品設定マスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定マスタフォームクラス デフォルトコンストラクタ</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22810 明細項目の幅・文字サイズは変更時に保存の対応</br>
        /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ①初回起動時の文字サイズと項目幅の変更</br>
        /// <br>　　　　　　　　　　　　　　　　　　　　　 ②明細のキャンペーンコードに初期表示するように変更</br>
        /// </remarks>
        public PMKHN09621UA()
        {
            InitializeComponent();

            // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 ----------------------------------->>>>>
            //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 ----------------------------------->>>>>
            //// オプション情報
            //this.CacheOptionInfo();
            //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 -----------------------------------<<<<<
            // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 -----------------------------------<<<<<

            // 変数初期化
            this._detailInput = new PMKHN09621UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Search"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_ReNewal"];
            // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 ----------------------------------->>>>>
            //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 ----------------------------------->>>>>
            //this._recBgnItmStButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_RecBgnItmSt"];
            //// SCMオプション有効時のみ有効
            //if (this._opt_Scm == (int)Option.OFF)
            //{
            //    this._recBgnItmStButton.SharedProps.Visible = false;
            //    this._recBgnItmStButton.SharedProps.Enabled = false;
            //}
            //else
            //{ 
            //    this._recBgnItmStButton.SharedProps.Visible = true;
            //    this._recBgnItmStButton.SharedProps.Enabled = true;
            //}
            //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 -----------------------------------<<<<<
            // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 -----------------------------------<<<<<
            this._detailInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
            this._loginEmployeeLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._detailInput.SetGuidButton += new PMKHN09621UB.SetGuidButtonEventHandler(this.SetGuidButton);
            this._detailInput.GetCampaignInfo += new PMKHN09621UB.GetCampaignInfoEventHandler(this.GetCampaignInfo); // ADD 2011/07/12

            this._campaignObjGoodsStAcs = this._detailInput.CampaignObjGoodsStAcs;
            this._makerAcs = new MakerAcs();
            this._campaignLinkAcs = new CampaignLinkAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();

            // 設定読み込み
            this._detailInput.Deserialize();   // ADD K2011/07/07 

            this.uExGroupBox_ExtraCondition.Expanded = false;
            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
            this.tComboEditor_PriceFl.SelectedIndex = 0;
            this.tComboEditor_RateVal.SelectedIndex = 0;
            this.tComboEditor_DiscountRate.SelectedIndex = 0;
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = 0;
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = this._detailInput.UserSetting.OutputStyle;
        }
        #endregion

        #region イベント
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームロードイベント処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22810 明細項目の幅・文字サイズは変更時に保存の対応</br>
        /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ①初回起動時の文字サイズと項目幅の変更</br>
        /// </remarks>
        private void PMKHN09621UA_Load(object sender, EventArgs e)
        {
            // Skin設定
            this._controlScreenSkin.LoadSkin();

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExGroupBox_CommonCondition.Name);
            controlNameList.Add(this.uExGroupBox_ExtraCondition.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);

            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._detailInput);

            this.panel_DetailInput.Controls.Add(this._detailInput);
            this._detailInput.Dock = DockStyle.Fill;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            this._campaignObjGoodsStAcs.LoadMstData();
            // ------------------- ADD Redmine#23556 2011/08/12 ------------------------>>>>>
            while (this._campaignObjGoodsStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            while (this._campaignObjGoodsStAcs.GoodsAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            // ------------------- ADD Redmine#23556 2011/08/12 ------------------------<<<<<

            // 文字サイズ設定
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }
            // ----- UPD K2011/07/07 ------- >>>>>>>>>
            this.tComboEditor_StatusBar_FontSize.ValueChanged -= tComboEditor_StatusBar_FontSize_ValueChanged;
            if (this._detailInput.UserSetting.OutputStyle != 0)
            {
                this.tComboEditor_StatusBar_FontSize.Text = this._detailInput.UserSetting.OutputStyle.ToString();
                this._detailInput.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (float)this._detailInput.UserSetting.OutputStyle;
                this._detailInput.uGrid_Details.Refresh();
            }
            else
            {
                this.tComboEditor_StatusBar_FontSize.Text = CT_DEF_FONT_SIZE.ToString();
                // ---ADD 2011/07/12---------------->>>>>
                this._detailInput.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (float)CT_DEF_FONT_SIZE;
                this._detailInput.uGrid_Details.Refresh();
                // ---ADD 2011/07/12----------------<<<<<
            }
            this.tComboEditor_StatusBar_FontSize.ValueChanged += tComboEditor_StatusBar_FontSize_ValueChanged;
            // ----- UPD K2011/07/07 ------- <<<<<<<<<

            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.uLabel_SectionName.Text = "全社";

            this._detailInput.LoadSettings();  // ADD K2011/07/07
        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            //tToolbarsManager_MainMenu
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            this._reNewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            this._loginNameLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 ----------------------------------->>>>>
            //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 ----------------------------------->>>>>
            //this._recBgnItmStButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 -----------------------------------<<<<<
            // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 -----------------------------------<<<<<
            
            #region ガイドボタン
            this.uButton_CampaignGuide.ImageList = this._imageList16;
            this.uButton_CampaignGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SalesCodeSt.ImageList = this._imageList16;
            this.uButton_SalesCodeSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SalesCodeEd.ImageList = this._imageList16;
            this.uButton_SalesCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_BlGoodsCodeSt.ImageList = this._imageList16;
            this.uButton_BlGoodsCodeSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGoodsCodeEd.ImageList = this._imageList16;
            this.uButton_BlGoodsCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_BLGroupCdSt.ImageList = this._imageList16;
            this.uButton_BLGroupCdSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BLGroupCdEd.ImageList = this._imageList16;
            this.uButton_BLGroupCdEd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_MakerCdSt.ImageList = this._imageList16;
            this.uButton_MakerCdSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_MakerCdEd.ImageList = this._imageList16;
            this.uButton_MakerCdEd.Appearance.Image = (int)Size16_Index.STAR1;
            #endregion
        }

        /// <summary>
        /// フォーカス変換処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォーカス変換処理。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // フッタ項目へ移動した場合は移動キャンセル
            if (e.NextCtrl == this.tComboEditor_StatusBar_FontSize)
            {
                if (!e.ShiftKey && (e.Key == Keys.Down || e.Key == Keys.Right || e.Key == Keys.Tab || e.Key == Keys.Return))
                {
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
            }
            
            // 名前により分岐
            switch (e.PrevCtrl.Name)
            {
                #region 明細部
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                this._detailInput.ReturnKeyDown(ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this._detailInput.uGrid_Details.ActiveCell != null)
                                {
                                    if (this._detailInput.uGrid_Details.ActiveCell.Row.Index == 0)
                                    {
                                        if (this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
                                            }
                                            if (this.uExGroupBox_ExtraCondition.Expanded == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_PriceFl;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                            }
                                            break;
                                        }
                                        else if (this._campaignObjGoodsStAcs.PrevCampaignMngDic.Count > 0
                                            && this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
                                            }
                                            if (this.uExGroupBox_ExtraCondition.Expanded == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_PriceFl;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                            }
                                            break;
                                        }
                                        else if (this._campaignObjGoodsStAcs.PrevCampaignMngDic != null
                                            && this._campaignObjGoodsStAcs.PrevCampaignMngDic.Count <= 0
                                            && this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
                                            }
                                            if (this.uExGroupBox_ExtraCondition.Expanded == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_PriceFl;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                            }
                                            break;
                                        }
                                    }
                                }
                                else if (this._detailInput.uGrid_Details.ActiveRow != null)
                                {
                                    if (this._detailInput.uGrid_Details.ActiveRow.Selected && this._detailInput.uGrid_Details.ActiveRow.Index == 0)
                                    {
                                        this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                        this._detailInput.uGrid_Details.ActiveRow = null;
                                        if (this.uExGroupBox_ExtraCondition.Expanded == true)
                                        {
                                            e.NextCtrl = this.tComboEditor_PriceFl;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        break;
                                    }
                                }

                                this._detailInput.ShiftKeyDown(ref e);
                            }
                        }
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl != this._detailInput.uGrid_Details)
                            {
                                if (this._detailInput.uGrid_Details.ActiveCell != null)
                                {
                                    this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                    this._detailInput.uGrid_Details.ActiveCell = null;
                                }
                                if (this._detailInput.uGrid_Details.ActiveRow != null)
                                {
                                    this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                    this._detailInput.uGrid_Details.ActiveRow = null;
                                }
                            }
                        }
                        break;
                    }
                case "PMKHN09621UB":
                    {
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.Name == "uButton_RowDelete"
                                || e.NextCtrl.Name == "uButton_AllRowDelete"
                                || e.NextCtrl.Name == "uButton_Revival"
                                || e.NextCtrl.Name == "uButton_GetPriceDate"
                                || e.NextCtrl.Name == "_PMKHN09621UA_Toolbars_Dock_Area_Top"
                                || e.NextCtrl.Name == "_PMKHN09621UB_Toolbars_Dock_Area_Top")
                            {
                                break;
                            }
                            if (e.NextCtrl != this._detailInput.uGrid_Details)
                            {
                                if (this._detailInput.uGrid_Details.ActiveCell != null)
                                {
                                    this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                    this._detailInput.uGrid_Details.ActiveCell = null;
                                }
                                if (this._detailInput.uGrid_Details.ActiveRow != null)
                                {
                                    this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                    this._detailInput.uGrid_Details.ActiveRow = null;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region キャンペーンコード
                case "tEdit_CampaignCode":
                    {
                        bool checkFlg = true;
                        int campaignCd = 0;
                        // 空の場合
                        if (this.tEdit_CampaignCode.Text.Trim() == string.Empty)
                        {
                            this._prevCampaignCd = 0;

                            this.tEdit_CampaignCode.Clear();
                            this.uLabel_CampaignName.Text = string.Empty;
                            this.uLabel_YearSt.Text = string.Empty;
                            this.uLabel_YearEd.Text = string.Empty;
                            this.uLabel_MonthSt.Text = string.Empty;
                            this.uLabel_MonthEd.Text = string.Empty;
                            this.uLabel_DateSt.Text = string.Empty;
                            this.uLabel_DateEd.Text = string.Empty;
                            this.uLabel_ObjCustomerDiv.Text = string.Empty;
                        }
                        // 前回値と不同の場合
                        else if (!this._prevCampaignCd.ToString().PadLeft(6, '0').Equals(this.tEdit_CampaignCode.Text.Trim().PadLeft(6, '0')))
                        {
                            if (int.TryParse(this.tEdit_CampaignCode.Text, out campaignCd))
                            {
                                // 値を存在の場合
                                if (this._campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaignCd))
                                {
                                    CampaignSt campaignSt = null;
                                    campaignSt = this._campaignObjGoodsStAcs.CampaignStDic[campaignCd];

                                    if (campaignSt.LogicalDeleteCode == 0)
                                    {
                                        // 結果セット
                                        this.tEdit_CampaignCode.Text = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                                        this.uLabel_CampaignName.Text = campaignSt.CampaignName;
                                        this.uLabel_YearSt.Text = campaignSt.ApplyStaDate.Year.ToString().PadLeft(4, '0');
                                        this.uLabel_MonthSt.Text = campaignSt.ApplyStaDate.Month.ToString().PadLeft(2, '0');
                                        this.uLabel_DateSt.Text = campaignSt.ApplyStaDate.Day.ToString().PadLeft(2, '0');
                                        this.uLabel_YearEd.Text = campaignSt.ApplyEndDate.Year.ToString().PadLeft(4, '0');
                                        this.uLabel_MonthEd.Text = campaignSt.ApplyEndDate.Month.ToString().PadLeft(2, '0');
                                        this.uLabel_DateEd.Text = campaignSt.ApplyEndDate.Day.ToString().PadLeft(2, '0');
                                        this.tEdit_SectionCodeAllowZero.Text = campaignSt.SectionCode.Trim().PadLeft(2, '0');
                                        this._prevSectionCd = Convert.ToInt32(campaignSt.SectionCode);
                                        this._prevCampaignCd = campaignSt.CampaignCode;

                                        if (Convert.ToInt32(campaignSt.SectionCode) == 0)
                                        {
                                            this.uLabel_SectionName.Text = "全社";
                                        }
                                        else
                                        {
                                            SecInfoSet secInfoSet = null;
                                            int statusFlg = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, campaignSt.SectionCode.Trim());
                                            if (statusFlg == 0)
                                            {
                                                this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                                            }
                                        }

                                        if (campaignSt.CampaignObjDiv == 0)
                                        {
                                            this.uLabel_ObjCustomerDiv.Text = "全得意先";
                                        }
                                        else if (campaignSt.CampaignObjDiv == 1)
                                        {
                                            this.uLabel_ObjCustomerDiv.Text = "指定得意先";
                                        }
                                        else
                                        {
                                            this.uLabel_ObjCustomerDiv.Text = string.Empty;
                                        }
                                    }
                                    // 値不存在の場合
                                    else
                                    {
                                        TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "キャンペーンコードが存在しません。",
                                                -1,
                                                MessageBoxButtons.OK);
                                        if (this._prevCampaignCd != 0)
                                        {
                                            this.tEdit_CampaignCode.Text = this._prevCampaignCd.ToString().PadLeft(6, '0');
                                        }
                                        else
                                        {
                                            this.tEdit_CampaignCode.Text = string.Empty;
                                        }
                                        checkFlg = false;
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                                // 値不存在の場合
                                else
                                {
                                    TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "キャンペーンコードが存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                    if (this._prevCampaignCd != 0)
                                    {
                                        this.tEdit_CampaignCode.Text = this._prevCampaignCd.ToString().PadLeft(6, '0');
                                    }
                                    else
                                    {
                                        this.tEdit_CampaignCode.Text = string.Empty;
                                    }
                                    checkFlg = false;
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "キャンペーンコードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                if (this._prevCampaignCd != 0)
                                {
                                    this.tEdit_CampaignCode.Text = this._prevCampaignCd.ToString().PadLeft(6, '0');
                                }
                                else
                                {
                                    this.tEdit_CampaignCode.Text = string.Empty;
                                }
                                checkFlg = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            if (this._prevCampaignCd != 0)
                            {
                                this.tEdit_CampaignCode.Text = this._prevCampaignCd.ToString().PadLeft(6, '0');
                            }
                            else
                            {
                                this.tEdit_CampaignCode.Text = string.Empty;
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_CampaignCode.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_CampaignGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }

                        if (!checkFlg)
                        {
                            _masterCheckFlg = true;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            _masterCheckFlg = false;
                        }
                        break;
                    }
                #endregion

                #region キャンペーンコードガイド
                case "uButton_CampaignGuide":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                 e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_CampaignCode;
                            }
                        }
                        break;
                    }
                #endregion

                #region 拠点
                case "tEdit_SectionCodeAllowZero":
                    {
                        bool checkFlg = true;
                        int sectionCd = 0;
                        // 空の場合
                        if (this.tEdit_SectionCodeAllowZero.Text.Trim() == string.Empty)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = "00";
                            this.uLabel_SectionName.Text = "全社";
                            this._prevSectionCd = 0;
                        }
                        // 前回値と不同の場合
                        else if (!this._prevSectionCd.ToString().PadLeft(2, '0').Equals(this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0')))
                        {
                            if (int.TryParse(this.tEdit_SectionCodeAllowZero.Text, out sectionCd))
                            {
                                if (sectionCd == 0)
                                {
                                    this.tEdit_SectionCodeAllowZero.Text = "00";
                                    this.uLabel_SectionName.Text = "全社";
                                    this._prevSectionCd = 0;
                                }
                                else
                                {
                                    // 値を存在の場合
                                    if (this._campaignObjGoodsStAcs.SecInfoSetDic.ContainsKey(sectionCd.ToString().Trim().PadLeft(2, '0')))
                                    {
                                        SecInfoSet secInfoSet = null;
                                        secInfoSet = this._campaignObjGoodsStAcs.SecInfoSetDic[sectionCd.ToString().Trim().PadLeft(2, '0')];

                                        this.tEdit_SectionCodeAllowZero.Text = sectionCd.ToString().PadLeft(2, '0');
                                        this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                                        this._prevSectionCd = sectionCd;
                                    }
                                    // 値を不存在の場合
                                    else
                                    {
                                        TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "拠点が存在しません。",
                                                -1,
                                                MessageBoxButtons.OK);
                                        this.tEdit_SectionCodeAllowZero.Text = this._prevSectionCd.ToString();
                                        this.tEdit_SectionCodeAllowZero.SelectAll();
                                        checkFlg = false;
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "拠点が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                this.tEdit_SectionCodeAllowZero.Text = this._prevSectionCd.ToString();
                                this.tEdit_SectionCodeAllowZero.SelectAll();
                                checkFlg = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            this.tEdit_SectionCodeAllowZero.Text = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            if (this.tEdit_SectionCodeAllowZero.Text == "00")
                            {
                                this.uLabel_SectionName.Text = "全社";
                            }
                            this._prevSectionCd = 0;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeSt;
                                }
                                else
                                {
                                    if (checkFlg)
                                    {
                                        this.Search();
                                    }
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                if (!this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    if (checkFlg)
                                    {
                                        this.Search();
                                    }
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_CampaignCode.Text.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_CampaignGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_CampaignCode;
                                }
                            }
                        }

                        if (!checkFlg)
                        {
                            _masterCheckFlg = true;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            _masterCheckFlg = false;
                        }
                        break;
                    }
                #endregion

                #region 拠点ガイド
                case "uButton_SectionGuide":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (!this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    this.Search();
                                    e.NextCtrl = null;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeSt;
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                if (!this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    this.Search();
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion

                #region 販売区分（開始）
                case "tEdit_SalesCodeSt":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_SalesCodeSt.Text.Trim()))
                        {
                            this.tEdit_SalesCodeSt.Text = this.tEdit_SalesCodeSt.Text.PadLeft(4, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_SalesCodeSt;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion

                #region 販売区分ガイド（開始）
                case "uButton_SalesCodeSt":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SalesCodeEd;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SalesCodeSt;
                            }
                        }
                        break;
                    }
                #endregion

                #region 販売区分（終了）
                case "tEdit_SalesCodeEd":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_SalesCodeEd.Text.Trim()))
                        {
                            this.tEdit_SalesCodeEd.Text = this.tEdit_SalesCodeEd.Text.PadLeft(4, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_SalesCodeEd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SalesCodeSt.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SalesCodeSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeSt; 
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region 販売区分ガイド（終了）
                case "uButton_SalesCodeEd":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SalesCodeEd;
                            }
                        }
                        break;
                    }
                #endregion

                #region ＢＬコード（開始）
                case "tEdit_BlGoodsCodeSt":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_BlGoodsCodeSt.Text.Trim()))
                        {
                            this.tEdit_BlGoodsCodeSt.Text = this.tEdit_BlGoodsCodeSt.Text.PadLeft(5, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeSt;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SalesCodeEd.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SalesCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SalesCodeEd;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ＢＬコードガイド（開始）
                case "uButton_BlGoodsCodeSt":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                            }
                        }
                        break;
                    }
                #endregion

                #region ＢＬコード（終了）
                case "tEdit_BlGoodsCodeEd":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_BlGoodsCodeEd.Text.Trim()))
                        {
                            this.tEdit_BlGoodsCodeEd.Text = this.tEdit_BlGoodsCodeEd.Text.PadLeft(5, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_GoodsNo;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeEd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BlGoodsCodeSt.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region ＢＬコードガイド（終了）
                case "uButton_BlGoodsCodeEd":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                            }
                        }
                        break;
                    }
                #endregion

                #region 品番*
                case "tEdit_GoodsNo":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BLGroupCdSt;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BlGoodsCodeEd.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region グループ（開始）
                case "tEdit_BLGroupCdSt":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_BLGroupCdSt.Text.Trim()))
                        {
                            this.tEdit_BLGroupCdSt.Text = this.tEdit_BLGroupCdSt.Text.PadLeft(5, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_BLGroupCdEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_BLGroupCdSt;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }
                        }
                        break;
                    }
                #endregion

                #region グループガイド（開始）
                case "uButton_BLGroupCdSt":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BLGroupCdEd;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BLGroupCdSt;
                            }
                        }
                        break;
                    }
                #endregion

                #region グループ（終了）
                case "tEdit_BLGroupCdEd":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_BLGroupCdEd.Text.Trim()))
                        {
                            this.tEdit_BLGroupCdEd.Text = this.tEdit_BLGroupCdEd.Text.PadLeft(5, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_MakerCdSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_BLGroupCdEd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BLGroupCdSt.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BLGroupCdSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BLGroupCdSt; 
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region グループガイド（終了）
                case "uButton_BLGroupCdEd":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_MakerCdSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_BLGroupCdEd;
                            }
                        }
                        break;
                    }
                #endregion

                #region メーカー（開始）
                case "tEdit_MakerCdSt":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_MakerCdSt.Text.Trim()))
                        {
                            this.tEdit_MakerCdSt.Text = this.tEdit_MakerCdSt.Text.PadLeft(4, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tEdit_MakerCdEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_MakerCdSt;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BLGroupCdEd.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BLGroupCdEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BLGroupCdEd;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region メーカーガイド（開始）
                case "uButton_MakerCdSt":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_MakerCdEd;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_MakerCdSt;
                            }
                        }
                        break;
                    }
                #endregion

                #region メーカー（終了）
                case "tEdit_MakerCdEd":
                    {
                        bool hasValue = true;
                        if (!string.Empty.Equals(this.tEdit_MakerCdEd.Text.Trim()))
                        {
                            this.tEdit_MakerCdEd.Text = this.tEdit_MakerCdEd.Text.PadLeft(4, '0');
                        }
                        else
                        {
                            hasValue = false;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (hasValue)
                                {
                                    e.NextCtrl = this.tComboEditor_DeleteFlag;
                                }
                                else
                                {
                                    e.NextCtrl = this.uButton_MakerCdEd;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_MakerCdSt.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_MakerCdSt;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_MakerCdSt;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region メーカーガイド（終了）
                case "uButton_MakerCdEd":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_DeleteFlag;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_MakerCdEd;
                            }
                        }
                        break;
                    }
                #endregion

                #region 削除指定区分
                case "tComboEditor_DeleteFlag":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_DiscountRate;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.tEdit_MakerCdSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_MakerCdEd.Text == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_MakerCdEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_MakerCdEd;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region 値引率
                case "tEdit_DiscountRate":
                    {
                        double inputValue = 0;
                        if (double.TryParse(this.tEdit_DiscountRate.Text.Trim(), out inputValue))
                        {
                            if (inputValue == 0.00)
                            {
                                this.tEdit_DiscountRate.Clear();
                            }
                            else
                            {
                                this.tEdit_DiscountRate.Text = inputValue.ToString("#,##0.00");
                            }
                        }
                        else
                        {
                            this.tEdit_DiscountRate.Clear();
                        }


                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_DiscountRate;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_DeleteFlag;
                            }
                        }
                        break;
                    }
                #endregion

                #region 値引率区分
                case "tComboEditor_DiscountRate":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_RateVal;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_DiscountRate;
                            }
                        }
                        break;
                    }
                #endregion

                #region 売価率
                case "tEdit_RateVal":
                    {
                        double inputValue = 0;
                        if (double.TryParse(this.tEdit_RateVal.Text.Trim(), out inputValue))
                        {
                            if (inputValue == 0.00)
                            {
                                this.tEdit_RateVal.Clear();
                            }
                            else
                            {
                                this.tEdit_RateVal.Text = inputValue.ToString("#,##0.00");
                            }
                        }
                        else
                        {
                            this.tEdit_RateVal.Clear();
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_RateVal;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_DiscountRate;
                            }
                        }
                        break;
                    }
                #endregion

                #region 売価率区分
                case "tComboEditor_RateVal":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_PriceFl;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_RateVal;
                            }
                        }
                        break;
                    }
                #endregion

                #region 売価額
                case "tEdit_PriceFl":
                    {
                        double inputValue = 0;
                        if (double.TryParse(this.tEdit_PriceFl.Text.Trim(), out inputValue))
                        {
                            if (inputValue == 0.00)
                            {
                                this.tEdit_PriceFl.Clear();
                            }
                            else
                            {
                                this.tEdit_PriceFl.Text = inputValue.ToString("#,##0.00");
                            }
                        }
                        else
                        {
                            this.tEdit_PriceFl.Clear();
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_PriceFl;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_RateVal;
                            }
                        }
                        break;
                    }
                #endregion

                #region 売価額区分
                case "tComboEditor_PriceFl":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            else if (e.Key == Keys.Down)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_PriceFl;
                            }
                        }
                        break;
                    }
                #endregion
            }

            #region ■ガイド有効無効の設定
            if (e.NextCtrl == this.uStatusBar_Main)
            {
                e.NextCtrl = e.PrevCtrl;
                return;
            }
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_CampaignCode":
                    case "tEdit_SectionCodeAllowZero":
                    case "tEdit_SalesCodeSt":
                    case "tEdit_SalesCodeEd":
                    case "tEdit_BlGoodsCodeSt":
                    case "tEdit_BlGoodsCodeEd":
                    case "tEdit_BLGroupCdSt":
                    case "tEdit_BLGroupCdEd":
                    case "tEdit_MakerCdSt":
                    case "tEdit_MakerCdEd":
                        SetGuidButton(true);
                        break;
                    case "uGrid_Details":
                        {
                            this._detailInput.SetGridGuid();
                            break;
                        }
                    case "_PMKHN09621UA_Toolbars_Dock_Area_Top":
                    case "_PMKHN09621UB_Toolbars_Dock_Area_Top":
                        break;
                    default:
                        SetGuidButton(false);
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        this.Close(true);
                        break;
                    }
                // 検索
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        if (this.tEdit_CampaignCode.Focused)
                        {
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_CampaignCode, this.tEdit_CampaignCode));
                        }
                        else if (this.tEdit_SectionCodeAllowZero.Focused)
                        {
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Up, this.tEdit_SectionCodeAllowZero, this.tEdit_SectionCodeAllowZero));
                        }
                        if (this._masterCheckFlg == true)
                        {
                            this._masterCheckFlg = false;
                            return;
                        }
                        this.uLabel_SectionName.Focus();
                        this._isButtonClick = true;
                        this.Search();
                        break;
                    }
                // 保存
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                        if (this._detailInput.FocusFlg == false)
                        {
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        this.Save();
                        break;
                    }
                // クリア
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        this.Clear();
                        // ---ADD 2011/07/14------------->>>>>
                        CampaignObjGoodsSt campaignObjGoodsSt = null;
                        this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows[this._campaignObjGoodsStAcs.CampaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                        this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                        // ---ADD 2011/07/14-------------<<<<<
                        break;
                    }
                // ガイド
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        this.GuideStart();
                        break;
                    }
                // 最新情報
                case TOOLBAR_RENEWALBUTTON_KEY:
                    {
                        this.ReNewal();
                        break;
                    }
                case TOOLBAR_SHOWMASTERBUTTON_KEY:
                    {
                        //起動時パス
                        string directoryName = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

                        if (directoryName.Length > 0)
                        {
                            if (directoryName[directoryName.Length - 1] != '\\')
                            {
                                directoryName = directoryName + "\\";
                            }
                        }
                        string startInfoFileName = directoryName + "SFCMN09000U.EXE";

                        //起動時パラメータ
                        string param = Environment.GetCommandLineArgs()[1] + " " +
                                       Environment.GetCommandLineArgs()[2];

                        Process.Start(startInfoFileName, param + " " + "22");

                        break;
                    }
                // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 ----------------------------------->>>>>
                //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 ----------------------------------->>>>>
                //// お買得商品設定
                //case TOOLBAR_SHORECBGNITMST_KEY:
                //    {
                //        //起動時パス
                //        string directoryName = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

                //        if (directoryName.Length > 0)
                //        {
                //            if (directoryName[directoryName.Length - 1] != '\\')
                //            {
                //                directoryName = directoryName + "\\";
                //            }
                //        }
                //        string startInfoFileName = directoryName + "PMREC09020U.EXE";

                //        //起動時パラメータ
                //        string param = Environment.GetCommandLineArgs()[1] + " " +
                //                       Environment.GetCommandLineArgs()[2];

                //        Process.Start(startInfoFileName, param);

                //        break;
                //    }
                //// ADD 2015/01/29 鹿庭 お買得商品設定呼出し追加 -----------------------------------<<<<<
                // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 -----------------------------------<<<<<
            }
        }

        /// <summary>
        /// キャンペーンコードガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : キャンペーンコードイドボタン</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_CampaignGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // ガイド起動
                int status = this._campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    SecInfoSet secInfoSet;
                    CampaignSt campaignStObj;
                    int sts = this._campaignLinkAcs.CampaignStAcs.Read(out campaignStObj, this._enterpriseCode, campaignSt.CampaignCode);

                    if (sts == 0)
                    {
                        // 結果セット
                        this.tEdit_CampaignCode.Text = campaignStObj.CampaignCode.ToString().PadLeft(6, '0');
                        this.uLabel_CampaignName.Text = campaignStObj.CampaignName;
                        this.uLabel_YearSt.Text = campaignStObj.ApplyStaDate.Year.ToString().PadLeft(4, '0');
                        this.uLabel_MonthSt.Text = campaignStObj.ApplyStaDate.Month.ToString().PadLeft(2, '0');
                        this.uLabel_DateSt.Text = campaignStObj.ApplyStaDate.Day.ToString().PadLeft(2, '0');
                        this.uLabel_YearEd.Text = campaignStObj.ApplyEndDate.Year.ToString().PadLeft(4, '0');
                        this.uLabel_MonthEd.Text = campaignStObj.ApplyEndDate.Month.ToString().PadLeft(2, '0');
                        this.uLabel_DateEd.Text = campaignStObj.ApplyEndDate.Day.ToString().PadLeft(2, '0');
                        this.tEdit_SectionCodeAllowZero.Text = campaignStObj.SectionCode.Trim().PadLeft(2, '0');
                        this._prevSectionCd = Convert.ToInt32(campaignStObj.SectionCode);
                        this._prevCampaignCd = campaignStObj.CampaignCode;

                        if (Convert.ToInt32(campaignStObj.SectionCode) == 0)
                        {
                            this.uLabel_SectionName.Text = "全社";
                        }
                        else
                        {
                            int statusFlg = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, campaignStObj.SectionCode.Trim());
                            if (statusFlg == 0)
                            {
                                this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                            }
                        }

                        if (campaignStObj.CampaignObjDiv == 0)
                        {
                            this.uLabel_ObjCustomerDiv.Text = "全得意先";
                        }
                        else if (campaignStObj.CampaignObjDiv == 1)
                        {
                            this.uLabel_ObjCustomerDiv.Text = "指定得意先";
                        }
                        else
                        {
                            this.uLabel_ObjCustomerDiv.Text = string.Empty;
                        }

                        // 次フォーカス
                        this.tEdit_SectionCodeAllowZero.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタン</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 拠点ガイド呼び出し
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.ToString().Trim().PadLeft(2, '0');
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                    this._prevSectionCd = Convert.ToInt32(secInfoSet.SectionCode);

                    if (sender != null)
                    {
                        if (!this.uExGroupBox_ExtraCondition.Expanded)
                        {
                            // 検索を行う
                            this.Search();
                        }
                        else
                        {
                            this.tEdit_SalesCodeSt.Focus();
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 販売区分ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 販売区分ガイドボタン</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_SalesCode_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int userGuideDivCd_SalesCode = 71;  // 販売区分：71

                // コードから名称へ変換
                UserGdHd userGuideHdInfo;
                UserGdBd userGuideBdInfo;
                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, userGuideDivCd_SalesCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if ((Control)sender == this.tEdit_SalesCodeSt
                        || (Control)sender == this.uButton_SalesCodeSt)
                    {
                        this.tEdit_SalesCodeSt.Text = userGuideBdInfo.GuideCode.ToString().PadLeft(4, '0');
                        this.tEdit_SalesCodeEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_SalesCodeEd
                        || (Control)sender == this.uButton_SalesCodeEd)
                    {
                        this.tEdit_SalesCodeEd.Text = userGuideBdInfo.GuideCode.ToString().PadLeft(4, '0');
                        this.tEdit_BlGoodsCodeSt.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// BLコードガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : BLコードガイドボタン</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_BlGoodsCode_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コードから名称へ変換
                BLGoodsCdUMnt blGoodsUnit;
                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if ((Control)sender == this.tEdit_BlGoodsCodeSt
                        || (Control)sender == this.uButton_BlGoodsCodeSt)
                    {
                        this.tEdit_BlGoodsCodeSt.Text = blGoodsUnit.BLGoodsCode.ToString().PadLeft(5, '0');
                        this.tEdit_BlGoodsCodeEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_BlGoodsCodeEd
                        || (Control)sender == this.uButton_BlGoodsCodeEd)
                    {
                        this.tEdit_BlGoodsCodeEd.Text = blGoodsUnit.BLGoodsCode.ToString().PadLeft(5, '0');
                        this.tEdit_GoodsNo.Focus();
                        this.SetGuidButton(false);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// グループコードガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グループコードガイドボタン</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_BLGroupCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ガイド表示
                BLGroupU blGroupUInfo;
                int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupUInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if ((Control)sender == this.tEdit_BLGroupCdSt
                        || (Control)sender == this.uButton_BLGroupCdSt)
                    {
                        this.tEdit_BLGroupCdSt.Text = blGroupUInfo.BLGroupCode.ToString().PadLeft(5, '0');
                        this.tEdit_BLGroupCdEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_BLGroupCdEd
                        || (Control)sender == this.uButton_BLGroupCdEd)
                    {
                        this.tEdit_BLGroupCdEd.Text = blGroupUInfo.BLGroupCode.ToString().PadLeft(5, '0');
                        this.tEdit_MakerCdSt.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// メーカーコードガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : メーカーコードガイドボタン</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void uButton_MakerCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コードから名称へ変換
                MakerUMnt makerInfo;
                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if ((Control)sender == this.tEdit_MakerCdSt
                        || (Control)sender == this.uButton_MakerCdSt)
                    {
                        this.tEdit_MakerCdSt.Text = makerInfo.GoodsMakerCd.ToString().PadLeft(4, '0');
                        this.tEdit_MakerCdEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_MakerCdEd
                        || (Control)sender == this.uButton_MakerCdEd)
                    {
                        this.tEdit_MakerCdEd.Text = makerInfo.GoodsMakerCd.ToString().PadLeft(4, '0');
                        this.tComboEditor_DeleteFlag.Focus();
                        this.SetGuidButton(false);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 売価率入力イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 売価率入力イベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_RateVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this._detailInput.KeyPressNumCheck(6, 2, this.tEdit_RateVal.Text, e.KeyChar, this.tEdit_RateVal.SelectionStart, this.tEdit_RateVal.SelectionLength, false))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 売価額入力イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 売価額入力イベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_PriceFl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                if ((this.tEdit_PriceFl.Text.Contains("-") && this.tEdit_PriceFl.SelectionLength == 14)
                    || (!this.tEdit_PriceFl.Text.Contains("-") && this.tEdit_PriceFl.SelectionLength == 13))
                {
                    return;
                }

                if (this.tEdit_PriceFl.Text.Contains("-") || this.tEdit_PriceFl.SelectionStart != 0)
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                if (e.KeyChar != '.')
                {
                    if (this.tEdit_PriceFl.Text.Contains("-"))
                    {
                        if (this.tEdit_PriceFl.SelectionStart == 11)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }

                if (this.tEdit_PriceFl.Text.Contains("-"))
                {
                    if (!this._detailInput.KeyPressNumCheck(14, 2, this.tEdit_PriceFl.Text, e.KeyChar, this.tEdit_PriceFl.SelectionStart, this.tEdit_PriceFl.SelectionLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    if (!this._detailInput.KeyPressNumCheck(13, 2, this.tEdit_PriceFl.Text, e.KeyChar, this.tEdit_PriceFl.SelectionStart, this.tEdit_PriceFl.SelectionLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 値引率入力イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 値引率入力イベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_DiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this._detailInput.KeyPressNumCheck(5, 2, this.tEdit_DiscountRate.Text, e.KeyChar, this.tEdit_DiscountRate.SelectionStart, this.tEdit_DiscountRate.SelectionLength, false))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 売価額AfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 売価額イベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_PriceFl_AfterEnterEditMode(object sender, EventArgs e)
        {
            this.tEdit_PriceFl.Text = this.tEdit_PriceFl.Text.Replace(",", "");
            double inputValue = 0;
            if (double.TryParse(this.tEdit_PriceFl.Text, out inputValue))
            {
                this.tEdit_PriceFl.Text = inputValue.ToString();
                this.tEdit_PriceFl.SelectAll();
            }
            else
            {
                this.tEdit_PriceFl.SelectAll();
            }
        }

        /// <summary>
        /// キャンペーンコードAfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : キャンペーンコードイベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_CampaignCode_AfterEnterEditMode(object sender, EventArgs e)
        {
            this.tEdit_CampaignCode.SelectAll();
        }

        /// <summary>
        /// 拠点AfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 拠点イベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_AfterEnterEditMode(object sender, EventArgs e)
        {
            int inputValue = 0;
            if (int.TryParse(this.tEdit_SectionCodeAllowZero.Text, out inputValue))
            {
                this.tEdit_SectionCodeAllowZero.Text = inputValue.ToString();
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Clear();
            }

            this.tEdit_SectionCodeAllowZero.SelectAll();
        }

        /// <summary>
        /// 販売区分AfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 販売区分イベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_SalesCode_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (((Control)sender).Name == this.tEdit_SalesCodeSt.Name)
            {
                this.tEdit_SalesCodeSt.SelectAll();
            }
            else if (((Control)sender).Name == this.tEdit_SalesCodeEd.Name)
            {
                this.tEdit_SalesCodeEd.SelectAll();
            }
            else
            {
                //なし。
            }
        }

        /// <summary>
        /// ＢＬコードAfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ＢＬコードイベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_BlGoodsCode_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (((Control)sender).Name == this.tEdit_BlGoodsCodeSt.Name)
            {
                this.tEdit_BlGoodsCodeSt.SelectAll();
            }
            else if (((Control)sender).Name == this.tEdit_BlGoodsCodeEd.Name)
            {
                this.tEdit_BlGoodsCodeEd.SelectAll();
            }
            else
            {
                //なし。
            }
        }

        /// <summary>
        /// グループコードAfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グループコードイベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_BLGroupCd_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (((Control)sender).Name == this.tEdit_BLGroupCdSt.Name)
            {
                this.tEdit_BLGroupCdSt.SelectAll();
            }
            else if (((Control)sender).Name == this.tEdit_BLGroupCdEd.Name)
            {
                this.tEdit_BLGroupCdEd.SelectAll();
            }
            else
            {
                //なし。
            }
        }

        /// <summary>
        /// メーカーAfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : メーカーイベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_MakerCd_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (((Control)sender).Name == this.tEdit_MakerCdSt.Name)
            {
                this.tEdit_MakerCdSt.SelectAll();
            }
            else if (((Control)sender).Name == this.tEdit_MakerCdEd.Name)
            {
                this.tEdit_MakerCdEd.SelectAll();
            }
            else
            {
                //なし。
            }
        }

        /// <summary>
        /// 値引率AfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 値引率イベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_DiscountRate_AfterEnterEditMode(object sender, EventArgs e)
        {
            double inputValue = 0;
            if (double.TryParse(this.tEdit_DiscountRate.Text, out inputValue))
            {
                this.tEdit_DiscountRate.Text = inputValue.ToString();
                this.tEdit_DiscountRate.SelectAll();
            }
            else
            {
                this.tEdit_DiscountRate.SelectAll();
            }
        }

        /// <summary>
        /// 売価率AfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 売価率イベント</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void tEdit_RateVal_AfterEnterEditMode(object sender, EventArgs e)
        {
            double inputValue = 0;
            if (double.TryParse(this.tEdit_RateVal.Text, out inputValue))
            {
                this.tEdit_RateVal.Text = inputValue.ToString();
                this.tEdit_RateVal.SelectAll();
            }
            else
            {
                this.tEdit_RateVal.SelectAll();
            }
        }

        #region 列幅自動調整
        /// <summary>
        /// 列幅自動調整チェックボックスの変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 列幅自動調整チェックボックスの変更。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br></br>
        /// </remarks>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            this._columnWidthAutoAdjust = this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked;
            autoColumnAdjust(this._columnWidthAutoAdjust);
        }

        /// <summary>
        /// 列幅自動調整
        /// </summary>
        /// <param name="autoAdjust">自動調整するかどうか</param>
        /// <remarks>
        /// <br>Note       : 列幅自動調整。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ①初回起動時の文字サイズと項目幅の変更</br>
        /// <br></br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust)
        {
            if (this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                 this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) return;

            // 自動調整プロパティを調整
            if (autoAdjust)
            {
                this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }
            // 全ての列でサイズ調整
            for (int i = 0; i < this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }
            if (!autoAdjust)
            {
                #region ●表示幅設定
                Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this._detailInput.uGrid_Details.DisplayLayout.Bands[0];
                if (editBand == null) return;
                // ---UPD 2011/07/12-------------------->>>>>
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.RowNoColumn.ColumnName].Width = 55;		            // №
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // 削除日
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Width = 70;			    // ｺｰﾄﾞ
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignNameColumn.ColumnName].Width = 120;			// 名称
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName].Width = 40;		    	// 拠点
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignSettingKindColumn.ColumnName].Width = 140;		// 設定種別
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Width = 50;		    // ﾒｰｶｰ
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsMakerNameColumn.ColumnName].Width = 180;			// ﾒｰｶｰ名
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsNoColumn.ColumnName].Width = 150;	                // 品番
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.BLGoodsCodeColumn.ColumnName].Width = 60;		        // BLｺｰﾄﾞ
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsNameColumn.ColumnName].Width = 150;				// 品名
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.BLGroupCodeColumn.ColumnName].Width = 60;			    // ｸﾞﾙｰﾌﾟ
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SalesCodeColumn.ColumnName].Width = 80;			    // 販売区分
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Width = 75;		    // 売価区分
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CustomerCodeColumn.ColumnName].Width = 80;		        // 得意先
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.DiscountRateColumn.ColumnName].Width = 60;		        // 値引率
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.RateValColumn.ColumnName].Width = 60;				    // 売価率
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceFlColumn.ColumnName].Width = 150;			        // 売価額
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceStartDateColumn.ColumnName].Width = 90;			// 価格開始日
                //editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceEndDateColumn.ColumnName].Width = 90;			// 価格終了日

                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.RowNoColumn.ColumnName].Width = 40;		            // №
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // 削除日
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Width = 55;			    // ｺｰﾄﾞ
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignNameColumn.ColumnName].Width = 120;			// 名称
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName].Width = 35;		    	// 拠点
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignSettingKindColumn.ColumnName].Width = 125;		// 設定種別
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsMakerCodeColumn.ColumnName].Width = 40;		    // ﾒｰｶｰ
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsMakerNameColumn.ColumnName].Width = 85;			// ﾒｰｶｰ名
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsNoColumn.ColumnName].Width = 115;	                // 品番
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.BLGoodsCodeColumn.ColumnName].Width = 50;		        // BLｺｰﾄﾞ
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.GoodsNameColumn.ColumnName].Width = 150;				// 品名
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.BLGroupCodeColumn.ColumnName].Width = 50;			    // ｸﾞﾙｰﾌﾟ
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SalesCodeColumn.ColumnName].Width = 60;			    // 販売区分
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.SalesPriceSetDivColumn.ColumnName].Width = 70;		    // 売価区分
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.CustomerCodeColumn.ColumnName].Width = 65;		        // 得意先
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.DiscountRateColumn.ColumnName].Width = 50;		        // 値引率
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.RateValColumn.ColumnName].Width = 55;				    // 売価率
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceFlColumn.ColumnName].Width = 130;			        // 売価額
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceStartDateColumn.ColumnName].Width = 75;			// 価格開始日
                editBand.Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.PriceEndDateColumn.ColumnName].Width = 75;			// 価格終了日
                // ---UPD 2011/07/12--------------------<<<<<
                #endregion
            }
            return;
        }
        #endregion 列幅自動調整

        #region フォントサイズ調整
        /// <summary>
        /// フォントサイズ変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォントサイズ変更。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_StatusBar_FontSize_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.tComboEditor_StatusBar_FontSize.Value, CT_DEF_FONT_SIZE);
            float fontPoint = (float)a;

            this._detailInput.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            this._detailInput.uGrid_Details.Refresh();
        }

        /// <summary>
        /// StrToInt変化処理
        /// </summary>
        /// <param name="obj">obj</param>
        /// <param name="defaultNo">defaultNo</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note       : StrToInt変化処理。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br></br>
        /// </remarks>
        private int StrToIntDefOfValue(object obj, int defaultNo)
        {
            try
            {
                return (int)obj;
            }
            catch
            {
                return defaultNo;
            }
        }
        #endregion
        #endregion

        #region Private Method
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22810 左右端の項目で止まるように修正</br>
        /// <br>UpdateNote : 2011/07/12 曹文傑 Redmine#22919 ②明細のキャンペーンコードに初期表示するように変更</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
        /// <br>UpdateNote : 2011/07/21 譚洪 Redmine#23199 ヘッダでキャンペーンコードを入力後に、検索実行後、１件もデータがない場合に、明細内容指定不正の修正</br>
        /// </remarks>
        private void Search()
        {
            SearchCondition searchCondition = null;
            // 検索条件取得処理
            this.ScreenToSearchCondition(ref searchCondition);

            if (this._isButtonClick == false)
            {
                if (this._searchCondition != null)
                {
                    if (this._campaignObjGoodsStAcs.CompareSearchCondition(this._searchCondition, searchCondition))
                    {
                        this._detailInput.SetFocusAfterSearch();
                        return;
                    }
                }
            }
            else
            {
                this._isButtonClick = false;
            }


            // 検索前、チェック処理
            if (!this.SearchCheck(searchCondition))
            {
                return;
            }

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "検索処理中";
            msgForm.Message = "検索処理中です。";
            msgForm.Show();

            string errMess = string.Empty;
            int count = 0;
            // 検索処理
            int status = this._campaignObjGoodsStAcs.Search(searchCondition,out count, out errMess);

            msgForm.Close();

            // ソート設定の解除
            this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
            this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.RefreshSort(true);

            #region 検索結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD 2011/07/07 ------- <<<<<<<<<
                //削除指定区分=通常の場合
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.LeftFocusFlg = false;
                }
                else
                {
                    this._detailInput.LeftFocusFlg = true;
                }
                // ----- ADD 2011/07/07 ------- >>>>>>>>>

                this._searchCondition = searchCondition;
                // 検索後、明細部設定処理
                this._detailInput.GridSettingAfterSearch(this._campaignObjGoodsStAcs.DeleteSearchMode);
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    // ---UPD 2011/07/12--------------->>>>>
                    //SetGuidButton(true);

                    if (this.tEdit_CampaignCode.Text.Trim() != string.Empty)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Value = this.tEdit_CampaignCode.Text.Trim().PadLeft(6, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignNameColumn.ColumnName].Value = this.uLabel_CampaignName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName].Value = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(false);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    else
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(true);
                        }
                        else
                        {
                            SetGuidButton(false); 
                        }
                    }
                    // ---ADD 2011/07/14------------->>>>>
                    CampaignObjGoodsSt campaignObjGoodsSt = null;
                    this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows[this._campaignObjGoodsStAcs.CampaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                    this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                    // ---ADD 2011/07/14-------------<<<<<
                    // ---UPD 2011/07/12---------------<<<<<
                }
                else
                {
                    SetGuidButton(false);
                }
                if (count > DATA_COUNT_MAX)
                {
                    TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                string.Format("データ件数が{0:#,##0}件を超えました。", DATA_COUNT_MAX) + "\r\n" +
                                "条件を絞り込んで再度検索して下さい。",
                                0,
                                MessageBoxButtons.OK);
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "検索条件に該当するデータが存在しません。",
                            0,
                            MessageBoxButtons.OK);

                this._searchCondition = searchCondition;

                //削除指定区分=通常の場合
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.Clear(true);
                    this._detailInput.SetButtonEnabled(1);
                    // ---UPD 2011/07/21--------------->>>>>
                    //this._detailInput.uGrid_Details.Rows[0].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                    //this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                    if (this.tEdit_CampaignCode.Text.Trim() != string.Empty)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();

                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Value = this.tEdit_CampaignCode.Text.Trim().PadLeft(6, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignNameColumn.ColumnName].Value = this.uLabel_CampaignName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.SectionCodeColumn.ColumnName].Value = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignSettingKindColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(false);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    else
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(true);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    CampaignObjGoodsSt campaignObjGoodsSt = null;
                    this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows[this._campaignObjGoodsStAcs.CampaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                    this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                    // ---UPD 2011/07/21---------------<<<<<

                }
                //削除指定区分=削除分のみの場合
                else
                {
                    this._detailInput.SetButtonEnabled(3);

                    this._campaignObjGoodsStAcs.PrevCampaignMngDic.Clear();
                    // 明細DataTable行クリア処理
                    this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows.Clear();

                    this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns[this._campaignObjGoodsStAcs.CampaignMngDataTable.UpdateTimeColumn.ColumnName].Hidden = true;

                    this.tEdit_CampaignCode.Focus();
                    SetGuidButton(true);
                }
            }
            else
            {
                // サーチ
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                    "PMKHN09621U", 						// アセンブリＩＤまたはクラスＩＤ
                    "キャンペーン対象商品設定マスタ", // プログラム名称
                    "Search", 							// 処理名称
                    TMsgDisp.OPE_GET, 					// オペレーション
                    "読み込みに失敗しました。", 		// 表示するメッセージ
                    status, 							// ステータス値
                    this._campaignObjGoodsStAcs, 			// エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				// 表示するボタン
                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン
            }
            #endregion
        }

        /// <summary>
        /// 検索前、チェック処理
        /// </summary>
        /// <param name="searchCondition">検索条件</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 検索前、チェック処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private bool SearchCheck(SearchCondition searchCondition)
        { 
            List<CampaignObjGoodsSt> deleteList;
            List<CampaignObjGoodsSt> updateList;

            // 削除指定区分=0の場合
            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
            {
                // 登録データ取得
                this._detailInput.GetSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                        "破棄してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult != DialogResult.Yes) return false;
                }
            }
            // 削除指定区分=1の場合
            else
            {
                // 登録データ取得
                this._detailInput.ReturnSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                        "破棄してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult != DialogResult.Yes) return false;
                }
            }


            // 販売区分の範囲チェック
            if (searchCondition.SalesCodeSt > searchCondition.SalesCodeEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "販売区分の範囲指定に誤りがあります。",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_SalesCodeSt.Focus();
                return false;
            }
            // ＢＬコードの範囲チェック
            if (searchCondition.BLGoodsCodeSt > searchCondition.BLGoodsCodeEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "ＢＬコードの範囲指定に誤りがあります。",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_BlGoodsCodeSt.Focus();
                return false;
            }
            // グループコードの範囲チェック
            if (searchCondition.BLGroupCodeSt > searchCondition.BLGroupCodeEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "グループコードの範囲指定に誤りがあります。",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_BLGroupCdSt.Focus();
                return false;
            }
            // メーカーの範囲チェック
            if (searchCondition.GoodsMakerCdSt > searchCondition.GoodsMakerCdEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "メーカーの範囲指定に誤りがあります。",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_MakerCdSt.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
        /// </remarks>
        private int Save()
        {
            // マスタデータ再取得
            //this._campaignObjGoodsStAcs.LoadMstData();   // DEL Redmine#23556 2011/08/12

            List<CampaignObjGoodsSt> deleteList;
            List<CampaignObjGoodsSt> updateList;

            int status = 0;
            CampaignObjGoodsSt errorCampaignObj = null;
            // 削除指定区分=0の場合
            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
            {
                // 登録データ取得
                if (!this._detailInput.CheckSaveDate(out deleteList, out updateList))
                {
                    if (updateList.Count <= 0)
                    {
                        TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "更新対象のデータが存在しません。",
                                    0,
                                    MessageBoxButtons.OK);
                    }
                    return -1;
                }

                status = this._campaignObjGoodsStAcs.SaveProc(deleteList, updateList, out errorCampaignObj);

                string errorMsg = string.Empty;
                if (errorCampaignObj != null)
                {
                    if (errorCampaignObj.SalesPriceSetDiv == 0)
                    {
                        switch (errorCampaignObj.CampaignSettingKind)
                        {
                            case 1:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 1：ﾒｰｶｰ+品番、ﾒｰｶｰ：" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "、品番：" + errorCampaignObj.GoodsNo.Trim();
                                    break;
                                }
                            case 2:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 2：ﾒｰｶｰ+BLｺｰﾄﾞ、ﾒｰｶｰ：" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "、BLｺｰﾄﾞ：" + errorCampaignObj.BLGoodsCode.ToString().PadLeft(5, '0');
                                    break;
                                }
                            case 3:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ、ﾒｰｶｰ：" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "、ｸﾞﾙｰﾌﾟ：" + errorCampaignObj.BLGroupCode.ToString().PadLeft(5, '0');
                                    break;
                                }
                            case 4:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 4：ﾒｰｶｰ、ﾒｰｶｰ：" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0');
                                    break;
                                }
                            case 5:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 5：BLｺｰﾄﾞ、BLｺｰﾄﾞ：" + errorCampaignObj.BLGoodsCode.ToString().PadLeft(5, '0');
                                    break;
                                }
                            case 6:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 6：販売区分、販売区分：" + errorCampaignObj.SalesCode.ToString().PadLeft(4, '0');
                                    break;
                                } 
                        }
                    }
                    else
                    {
                        switch (errorCampaignObj.CampaignSettingKind)
                        {
                            case 1:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 1：ﾒｰｶｰ+品番、ﾒｰｶｰ："+ errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "、品番：" + errorCampaignObj.GoodsNo.Trim()
                                        + "、得意先：" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "、価格日：" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "～" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 2:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 2：ﾒｰｶｰ+BLｺｰﾄﾞ、ﾒｰｶｰ："+ errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "、BLｺｰﾄﾞ：" + errorCampaignObj.BLGoodsCode.ToString().PadLeft(5, '0')
                                        + "、得意先：" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "、価格日：" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "～" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 3:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ、ﾒｰｶｰ：" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "、ｸﾞﾙｰﾌﾟ：" + errorCampaignObj.BLGroupCode.ToString().PadLeft(5, '0')
                                        + "、得意先：" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "、価格日：" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "～" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 4:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 4：ﾒｰｶｰ、ﾒｰｶｰ：" + errorCampaignObj.GoodsMakerCd.ToString().PadLeft(4, '0')
                                        + "、得意先：" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "、価格日：" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "～" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 5:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 5：BLｺｰﾄﾞ、BLｺｰﾄﾞ：" + errorCampaignObj.BLGoodsCode.ToString().PadLeft(5, '0')
                                        + "、得意先：" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "、価格日：" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "～" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                            case 6:
                                {
                                    errorMsg = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ：" + errorCampaignObj.CampaignCode.ToString().PadLeft(6, '0')
                                        + "、設定種別 6：販売区分、販売区分：" + errorCampaignObj.SalesCode.ToString().PadLeft(4, '0')
                                        + "、得意先：" + errorCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                                        + "、価格日：" + errorCampaignObj.PriceStartDate.ToString().PadLeft(6, '0')
                                        + "～" + errorCampaignObj.PriceEndDate.ToString().PadLeft(6, '0');
                                    break;
                                }
                        }
                    }

                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "同一の商品設定が既に登録されています。" + "\r\n" +
                         errorMsg,
                         0,
                         MessageBoxButtons.OK);

                    int rowIndex = -1;
                    //行番号を取得
                    foreach (UltraGridRow row in this._detailInput.uGrid_Details.Rows)
                    {
                        if (errorCampaignObj.RowIndex == (int)row.Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    if (rowIndex >= 0 && rowIndex < this._detailInput.uGrid_Details.Rows.Count)
                    {
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._campaignObjGoodsStAcs.CampaignMngDataTable.CampaignCodeColumn.ColumnName].Activate();
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        return -1;
                    }
                }
            }
            // 削除指定区分=1の場合
            else
            {
                // 登録データ取得
                this._detailInput.ReturnSaveDate(out deleteList, out updateList);

                if (deleteList.Count == 0 && updateList.Count == 0)
                {
                    TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "更新対象のデータが存在しません。",
                                0,
                                MessageBoxButtons.OK);
                    return -1;
                }

                if (deleteList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                this.Name,
                                "削除指定したデータは完全削除します。よろしいですか？",
                                0,
                                MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // なし。
                    }
                    else
                    {
                        return 0;
                    }
                }

                status = this._campaignObjGoodsStAcs.SaveProc(deleteList, updateList, out errorCampaignObj);
            }

            #region < 登録後処理 >
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 登録完了ダイアログ表示
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        //検索条件部を初期化する
                        this.ConditionClear();

                        this._searchCondition = null;

                        // グリッド初期設定処理
                        this._detailInput.Clear(true);
                        this.tEdit_CampaignCode.Focus();
                        this.SetGuidButton(true);
                        // ---ADD 2011/07/14------------->>>>>
                        CampaignObjGoodsSt campaignObjGoodsSt = null;
                        this._campaignObjGoodsStAcs.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignObjGoodsStAcs.CampaignMngDataTable.Rows[this._campaignObjGoodsStAcs.CampaignMngDataTable.Count - 1], ref campaignObjGoodsSt);
                        this._campaignObjGoodsStAcs.NewCampaignObj = campaignObjGoodsSt.Clone();
                        // ---ADD 2011/07/14-------------<<<<<
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "PMKHN09621U",				        	// アセンブリＩＤまたはクラスＩＤ
                            "更新対象のデータが存在しません。",     // 表示するメッセージ 
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "PMKHN09621U",				        	// アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。",  	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "PMKHN09621U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "PMKHN09621U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                           this,                                 // 親ウィンドウフォーム
                           emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                           "PMKHN09621U",                        // アセンブリＩＤまたはクラスＩＤ
                           "キャンペーン対象商品設定マスタ",     // プログラム名称
                           "Save",                               // 処理名称
                           TMsgDisp.OPE_UPDATE,                  // オペレーション
                           "登録に失敗しました。",               // 表示するメッセージ
                           status,                               // ステータス値
                           this._campaignObjGoodsStAcs,          // エラーが発生したオブジェクト
                           MessageBoxButtons.OK,                 // 表示するボタン
                           MessageBoxDefaultButton.Button1);     // 初期表示ボタン
                        break;
                    }
            }
            #endregion

            return status;
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : クリア処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void Clear()
        {
            bool clearFlg = false;
            #region クリア処理前、編集行チェック
            List<CampaignObjGoodsSt> deleteList;
            List<CampaignObjGoodsSt> updateList;

            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
            {
                this._detailInput.GetSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                        "登録してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (this.Save() == 0)
                        {
                            clearFlg = true;
                        }
                        else
                        {
                            clearFlg = false;
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        clearFlg = true;
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        clearFlg = false;
                    }
                }
                else
                {
                    clearFlg = true;
                }
            }
            else
            {
                this._detailInput.ReturnSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                        "登録してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (this.Save() == 0)
                        {
                            clearFlg = true;
                        }
                        else
                        {
                            clearFlg = false;
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        clearFlg = true;
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        clearFlg = false;
                    }
                }
                else
                {
                    clearFlg = true;
                }
            }
            #endregion

            if (clearFlg == true)
            {
                this._searchCondition = null;

                //検索条件部を初期化する
                this.ConditionClear();

                // グリッド初期設定処理
                this._detailInput.Clear(true);

                // ソート設定の解除
                this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
                // 初期フォーカス設定
                this.tEdit_CampaignCode.Focus();
                this.SetGuidButton(true);
            }
        }

        /// <summary>
        /// 検索条件部を初期化する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索条件部を初期化する</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ConditionClear()
        {
            #region 基本条件クリア
            this.tEdit_CampaignCode.Clear();
            this.uLabel_CampaignName.Text = string.Empty;
            this.uLabel_YearSt.Text = string.Empty;
            this.uLabel_YearEd.Text = string.Empty;
            this.uLabel_MonthSt.Text = string.Empty;
            this.uLabel_MonthEd.Text = string.Empty;
            this.uLabel_DateSt.Text = string.Empty;
            this.uLabel_DateEd.Text = string.Empty;
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.uLabel_SectionName.Text = "全社";
            this.uLabel_ObjCustomerDiv.Text = string.Empty;

            this._prevCampaignCd = 0;
            this._prevSectionCd = 0;
            #endregion

            #region 抽出条件クリア
            this.tEdit_SalesCodeSt.Clear();
            this.tEdit_SalesCodeEd.Clear();
            this.tEdit_BlGoodsCodeSt.Clear();
            this.tEdit_BlGoodsCodeEd.Clear();
            this.tEdit_GoodsNo.Clear();
            this.tEdit_BLGroupCdSt.Clear();
            this.tEdit_BLGroupCdEd.Clear();
            this.tEdit_MakerCdSt.Clear();
            this.tEdit_MakerCdEd.Clear();
            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
            this.tComboEditor_RateVal.SelectedIndex = 0;
            this.tComboEditor_PriceFl.SelectedIndex = 0;
            this.tComboEditor_DiscountRate.SelectedIndex = 0;
            this.tEdit_RateVal.Clear();
            this.tEdit_PriceFl.Clear();
            this.tEdit_DiscountRate.Clear();
            #endregion
        }
        
        /// <summary>
        /// 画面クローズ処理
        /// </summary>
        /// <param name="boolean">boolean</param>
        /// <remarks>
        /// <br>Note       : 画面クローズ処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void Close(bool boolean)
        {
            List<CampaignObjGoodsSt> deleteList;
            List<CampaignObjGoodsSt> updateList;

            if (this._campaignObjGoodsStAcs.DeleteSearchMode == false)
            {
                this._detailInput.GetSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                        "登録してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (this.Save() == 0)
                        {
                            this.Close();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        //なし。
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this._detailInput.ReturnSaveDate(out deleteList, out updateList);
                if (deleteList.Count > 0 || updateList.Count > 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                        "登録してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (this.Save() == 0)
                        {
                            this.Close();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        //なし。
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        // ----- ADD K2011/07/07 ------- >>>>>>>>>
        /// <summary>
        /// フォームクローズ前処理
        /// </summary>
        /// <remarks>FormClosingイベントだと×ボタン時に抜けてしまうので、Parentでウィンドウメッセージを扱う</remarks>
        public void BeforeFormClose()
        {
            //-----------------------------------------
            // フォームを閉じる時(×ボタンも含む)
            //-----------------------------------------
            // ユーザー設定保存(→XML書き込み)
            this._detailInput.SaveSettings((int)this.tComboEditor_StatusBar_FontSize.Value, this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked);

            this._detailInput.Serialize();
        }
        // ----- ADD K2011/07/07 ------- <<<<<<<<<

        /// <summary>
        /// ガイド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイド起動処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void GuideStart()
        {
            // キャンペーンコード
            if (this.tEdit_CampaignCode.Focused)
            {
                this.uButton_CampaignGuide_Click(this.tEdit_CampaignCode, new EventArgs());
            }
            // 拠点
            else if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                this.uButton_SectionGuide_Click(this.tEdit_SectionCodeAllowZero, new EventArgs());
            }
            // 販売区分（開始）
            else if (this.tEdit_SalesCodeSt.Focused)
            {
                this.uButton_SalesCode_Click(this.tEdit_SalesCodeSt, new EventArgs());
            }
            // 販売区分（終了）
            else if (this.tEdit_SalesCodeEd.Focused)
            {
                this.uButton_SalesCode_Click(this.tEdit_SalesCodeEd, new EventArgs());
            }
            // ＢＬコード（開始）
            else if (this.tEdit_BlGoodsCodeSt.Focused)
            {
                this.uButton_BlGoodsCode_Click(this.tEdit_BlGoodsCodeSt, new EventArgs());
            }
            // ＢＬコード（終了）
            else if (this.tEdit_BlGoodsCodeEd.Focused)
            {
                this.uButton_BlGoodsCode_Click(this.tEdit_BlGoodsCodeEd, new EventArgs());
            }
            // グループコード（開始）
            else if (this.tEdit_BLGroupCdSt.Focused)
            {
                this.uButton_BLGroupCd_Click(this.tEdit_BLGroupCdSt, new EventArgs());
            }
            // グループコード（終了）
            else if (this.tEdit_BLGroupCdEd.Focused)
            {
                this.uButton_BLGroupCd_Click(this.tEdit_BLGroupCdEd, new EventArgs());
            }
            // メーカー（開始）
            else if (this.tEdit_MakerCdSt.Focused)
            {
                this.uButton_MakerCd_Click(this.tEdit_MakerCdSt, new EventArgs());
            }
            // メーカー（終了）
            else if (this.tEdit_MakerCdEd.Focused)
            {
                this.uButton_MakerCd_Click(this.tEdit_MakerCdEd, new EventArgs());
            }
            // グリッド
            else
            {
                int rowIndex = -1;
                string keyName = this._detailInput.GetFocusColumnKey(out rowIndex);
                if (!string.Empty.Equals(keyName))
                {
                    switch (keyName)
                    {
                        case "CampaignCode":
                            {
                                this._detailInput.CampaignCodeGuide(rowIndex);
                                break;
                            }
                        case "SectionCode":
                            {
                                this._detailInput.SectionCodeGuide(rowIndex);
                                break;
                            }
                        case "GoodsMakerCode":
                            {
                                this._detailInput.GoodsMakerCodeGuide(rowIndex);
                                break;
                            }
                        case "BLGoodsCode":
                            {
                                this._detailInput.BLGoodsCodeGuide(rowIndex);
                                break;
                            }
                        case "BLGroupCode":
                            {
                                this._detailInput.BLGroupCodeGuide(rowIndex);
                                break;
                            }
                        case "SalesCode":
                            {
                                this._detailInput.SalesCodeGuide(rowIndex);
                                break;
                            }
                        case "CustomerCode":
                            {
                                this._detailInput.CustomerCodeGuide(rowIndex);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 最新情報取得処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ReNewal()
        {
            SFCMN00299CA processingDialog = new SFCMN00299CA();
            try
            {
                processingDialog.Title = "最新情報取得";
                processingDialog.Message = "現在、最新情報取得中です。";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);

                this._campaignObjGoodsStAcs.LoadMstData();
                // ------------------- ADD Redmine#23556 2011/08/12 ------------------------>>>>>
                while (this._campaignObjGoodsStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
                while (this._campaignObjGoodsStAcs.GoodsAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
                // ------------------- ADD Redmine#23556 2011/08/12 ------------------------<<<<<
            }
            finally
            {
                processingDialog.Dispose();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "最新情報を取得しました。　　",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// 詳細グリッド最上位行アプイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 詳細グリッド最上位行アプウン時に発生します。</br>      
        /// <br>Programmer : 曹文傑</br>                                  
        /// <br>Date       : 2011/04/26</br> 
        /// </remarks> 
        private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        {
            Control control = null;
            if (this.uExGroupBox_ExtraCondition.Expanded == false)
            {
                control = this.tEdit_SectionCodeAllowZero;
                this.SetGuidButton(true);
            }
            else
            {
                control = this.tEdit_GoodsNo;
                this.SetGuidButton(false);
            }

            if (control != null)
            {
                control.Focus();
            }

            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <param name="searchCondition">自動調整するかどうか</param>
        /// <remarks>
        /// <br>Note       : 最新情報取得処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void ScreenToSearchCondition(ref SearchCondition searchCondition)
        {
            int code = 0;
            bool flag = false;
            double dd = 0;

            if (searchCondition == null)
            {
                searchCondition = new SearchCondition();
            }

            searchCondition.EnterpriseCode = this._enterpriseCode;

            // キャンペーンコード
            flag = int.TryParse(this.tEdit_CampaignCode.Text, out code);
            if (flag)
            {
                searchCondition.CampaignCode = code;
            }
            else
            {
                searchCondition.CampaignCode = 0;
            }

            // 拠点
            flag = int.TryParse(this.tEdit_SectionCodeAllowZero.Text, out code);
            if (flag)
            {
                searchCondition.SectionCode = code.ToString();
            }
            else
            {
                searchCondition.SectionCode = "00";
            }

            // 販売区分（開始）
            flag = int.TryParse(this.tEdit_SalesCodeSt.Text, out code);
            if (flag)
            {
                searchCondition.SalesCodeSt = code;
            }
            else
            {
                searchCondition.SalesCodeSt = 0;
            }

            // 販売区分（終了）
            flag = int.TryParse(this.tEdit_SalesCodeEd.Text, out code);
            if (flag)
            {
                searchCondition.SalesCodeEd = code;
            }
            else
            {
                searchCondition.SalesCodeEd = 9999;
            }

            // ＢＬコード（開始）
            flag = int.TryParse(this.tEdit_BlGoodsCodeSt.Text, out code);
            if (flag)
            {
                searchCondition.BLGoodsCodeSt = code;
            }
            else
            {
                searchCondition.BLGoodsCodeSt = 0;
            }

            // ＢＬコード（終了）
            flag = int.TryParse(this.tEdit_BlGoodsCodeEd.Text, out code);
            if (flag)
            {
                searchCondition.BLGoodsCodeEd = code;
            }
            else
            {
                searchCondition.BLGoodsCodeEd = 99999;
            }

            // 品番*
            searchCondition.GoodsNo = this.tEdit_GoodsNo.Text.Trim();

            // グループコード（開始）
            flag = int.TryParse(this.tEdit_BLGroupCdSt.Text, out code);
            if (flag)
            {
                searchCondition.BLGroupCodeSt = code;
            }
            else
            {
                searchCondition.BLGroupCodeSt = 0;
            }

            // グループコード（終了）
            flag = int.TryParse(this.tEdit_BLGroupCdEd.Text, out code);
            if (flag)
            {
                searchCondition.BLGroupCodeEd = code;
            }
            else
            {
                searchCondition.BLGroupCodeEd = 99999;
            }

            // メーカー（開始）
            flag = int.TryParse(this.tEdit_MakerCdSt.Text, out code);
            if (flag)
            {
                searchCondition.GoodsMakerCdSt = code;
            }
            else
            {
                searchCondition.GoodsMakerCdSt = 0;
            }

            // メーカー（終了）
            flag = int.TryParse(this.tEdit_MakerCdEd.Text, out code);
            if (flag)
            {
                searchCondition.GoodsMakerCdEd = code;
            }
            else
            {
                searchCondition.GoodsMakerCdEd = 9999;
            }

            // 削除指定区分
            searchCondition.DeleteFlag = this.tComboEditor_DeleteFlag.SelectedIndex;

            // 値引率
            flag = double.TryParse(this.tEdit_DiscountRate.Text, out dd);
            if (flag)
            {
                searchCondition.DiscountRate = dd;
            }
            else
            {
                searchCondition.DiscountRate = 0;
            }

            // 値引率区分
            searchCondition.DiscountRateDiv = this.tComboEditor_DiscountRate.SelectedIndex;

            // 売価率
            flag = double.TryParse(this.tEdit_RateVal.Text, out dd);
            if (flag)
            {
                searchCondition.RateVal = dd;
            }
            else
            {
                searchCondition.RateVal = 0;
            }

            // 売価率区分
            searchCondition.RateValDiv = this.tComboEditor_RateVal.SelectedIndex;

            // 売価額
            flag = double.TryParse(this.tEdit_PriceFl.Text, out dd);
            if (flag)
            {
                searchCondition.PriceFl = dd;
            }
            else
            {
                searchCondition.PriceFl = 0;
            }

            // 売価額区分
            searchCondition.PriceFlDiv = this.tComboEditor_PriceFl.SelectedIndex;
        }

        /// <summary>
        /// ガイドボタン設定処理
        /// </summary>
        /// <param name="enable">enable</param>
        /// <remarks>
        /// <br>Note       : ガイドボタン設定処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void SetGuidButton(bool enable)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = enable;
        }

        /// <summary>
        /// 画面初期化の時、フォーカスを設定する。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化の時、フォーカスを設定する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void SetInitFocus()
        {
            this.tEdit_CampaignCode.Focus();
        }

        // ---ADD 2011/07/12-------------->>>>>
        /// <summary>
        /// 画面のキャンペーン情報を取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面のキャンペーン情報を取得処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/07/12</br>
        /// </remarks>
        public void GetCampaignInfo(out string campaignCode, out string campaignName, out string sectionCode)
        {
            campaignCode = string.Empty;
            campaignName = string.Empty;
            sectionCode = string.Empty;
            if (this.tEdit_CampaignCode.Text.Trim() != string.Empty)
            {
                campaignCode = this.tEdit_CampaignCode.Text.Trim().PadLeft(6, '0');
                campaignName = this.uLabel_CampaignName.Text.Trim();
                sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            }
        }
        // ---ADD 2011/07/12--------------<<<<<
        #endregion

        // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 ----------------------------------->>>>>
        ///// <summary>
        ///// オプション情報をキャッシュ
        ///// </summary>
        //private void CacheOptionInfo()
        //{
        //    Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

        //    #region SCMオプション
        //    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
        //    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
        //    {
        //        this._opt_Scm = (int)Option.ON;
        //    }
        //    else
        //    {
        //        this._opt_Scm = (int)Option.OFF;
        //    }
        //    #endregion

        //}
        // DEL 2015/06/02 鹿庭 お買得商品設定呼出しの使用停止 -----------------------------------<<<<<
    
    }
}