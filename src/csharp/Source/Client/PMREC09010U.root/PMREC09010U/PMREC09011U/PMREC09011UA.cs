//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リコメンド商品関連設定マスタ
// プログラム概要   : リコメンド商品関連設定マスタの保守を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/01/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/02/10  修正内容 : ④設定マスタ該当無し時のサンプル取込画面に
//                                    基本条件の拠点・得意先を初期表示
// 作 成 日  2015/02/10  修正内容 : システムテスト障害#174
//                                  ・拠点:"00"入力時に"全社共通"を表示
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/02/12  修正内容 : システムテスト障害#195,196
//                                  ・新規行に基本情報の得意先表示時に問合せ元企業・拠点をセット
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/02/13  修正内容 : システムテスト障害#193
//                                  ・拠点(基本条件)の制御変更
//                                    空白→全件検索、"00"→全社共通のみ、コード入力→対象コードのみ
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/02  修正内容 : サンプル取込時の登録済チェックに新規入力明細を含める
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/03  修正内容 : Redmine#302 データ更新後、印刷ボタンを無効にする
//                                  Redmine#308 得意先の全得意先対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/04  修正内容 : Redmine#193 拠点(基本条件)が空白の場合、リモートパラメータも空白渡し
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田靖之
// 作 成 日  2015/03/05  修正内容 : Redmine#326 削除モード時にサンプル取込ボタンが有効になる
// 　　　　　　　　　　　　　　　　 Redmine#328 データ更新後にサンプル取込ボタンが有効になる
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/06  修正内容 : Redmine#338 全得意先設定内容を定数化
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田靖之
// 作 成 日  2015/03/11  修正内容 : Redmine#355 論理削除ができない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田靖之
// 作 成 日  2015/03/12  修正内容 : 基本条件の拠点し検索した場合、新規行の拠点がゼロパディングされない
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// リコメンド商品関連設定マスタ UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : リコメンド商品関連設定マスタUIフォームクラス</br>
    /// <br>Programmer : 宮本利明</br>
    /// <br>Date       : 2015/01/20</br>
    /// </remarks>
    public partial class PMREC09011UA : Form
    {
        # region Private Members
        private PMREC09011UB _detailInput;
        private ImageList _imageList16 = null;                                                // イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;                    // クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;                    // ガイドボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;                  // 最新情報ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _sampleButton;                   // サンプル取込ボタン // ADD 2015/02/06 T.Miyamoto サンプル取込機能追加
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ログイン担当者
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;              // ログイン担当者名称
        // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _printButton;                    // 印刷ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _pdfButton;                    // PDF表示
        // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
        private ControlScreenSkin _controlScreenSkin;
        private Control _prevControl = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private RecGoodsLkStAcs _recGoodsLkStAcs = null;

        private UserGuideAcs _userGuideAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;

        // 得意先関連
        private CustomerSearchAcs _customerSearchAcs;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private bool _cusotmerGuideSelected; // 得意先ガイド選択フラグ
        private int _prevCusotmerCd = 0;

        //拠点関連
        private SecInfoSetAcs _secInfoSetAcs;
        private Dictionary<int, SecInfoSet> _sectionSearchRetDic;
        private bool _sectionGuideSelected; // 拠点ガイド選択フラグ
        private string _prevSectionCd = string.Empty;

        /// <summary>伝票表示タブ 列サイズ自動調整値</summary>
        private bool _columnWidthAutoAdjust = false;

        private SearchCondition _searchCondition = null;
        private bool _isButtonClick = false;

        // 検索条件格納
        private SearchCondition _extrInfoForPrint; // ADD 2014/03/05 田建委 Redmine#42247
        #endregion

        #region const
        // アセンブリID
        private const string ASSMBLY_ID = "PMREC09011U";

        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// 終了
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";					// 検索
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// 保存
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// クリア
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// ガイド
        private const string TOOLBAR_RENEWALBUTTON_KEY = "ButtonTool_ReNewal";					// 最新情報
        private const string TOOLBAR_SAMPLEBUTTON_KEY = "ButtonTool_Sample";                    // サンプル取込ボタン // ADD 2015/02/06 T.Miyamoto サンプル取込機能追加
        // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
        private const string TOOLBAR_PRINT_KEY = "ButtonTool_Print";  //印刷
        private const string TOOLBAR_PDF_KEY = "ButtonTool_PDF";  //PDF
        // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<

        /// <summary>表示：初期フォントサイズ</summary>
        private const int CT_DEF_FONT_SIZE = 10;

        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        /// <summary>文字サイズ</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        /// <summary>明細データ抽出最大件数</summary>
        private const long DATA_COUNT_MAX = 20000;
        #endregion

        # region Constroctors
        /// <summary>
        ///  リコメンド商品関連設定マスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : リコメンド商品関連設定マスタフォームクラス デフォルトコンストラクタ</br>
        /// <br>Programmer : 宮本利明</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks>
        public PMREC09011UA()
        {
            InitializeComponent();

            // 変数初期化
            this._detailInput = new PMREC09011UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Search"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_ReNewal"];
            this._sampleButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Sample"]; // ADD 2015/02/06 T.Miyamoto サンプル取込機能追加
            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            this._printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Print"];
            this._pdfButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_PDF"];
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<

            this._detailInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
            this._loginEmployeeLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._detailInput.SetGuidButton += new PMREC09011UB.SetGuidButtonEventHandler(this.SetGuidButton);
            this._detailInput.GetCustomerInfo += new PMREC09011UB.GetCustomerInfoEventHandler(this.GetCustomerInfo);
            this._detailInput.GetSectionInfo += new PMREC09011UB.GetSectionInfoEventHandler(this.GetSectionInfo);
            this._detailInput.SetSampleButton += new PMREC09011UB.SetSampleButtonEventHandler(this.SetSampleButton); // ADD 2015/02/06 T.Miyamoto サンプル取込機能追加

            this._recGoodsLkStAcs = this._detailInput.RecGoodsLkStAcs;
            this._userGuideAcs = new UserGuideAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();

            // 設定読み込み
            this._detailInput.Deserialize();

            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09011UA_Load(object sender, EventArgs e)
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

            this._recGoodsLkStAcs.LoadMstData();

            while (this._recGoodsLkStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }

            // 文字サイズ設定
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }

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
                this._detailInput.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (float)CT_DEF_FONT_SIZE;
                this._detailInput.uGrid_Details.Refresh();
            }
            this.tComboEditor_StatusBar_FontSize.ValueChanged += tComboEditor_StatusBar_FontSize_ValueChanged;

            this._detailInput.LoadSettings();

            // 得意先情報読込処理
            this.ReadCustomerSearchRet();

            // 拠点情報読込処理
            this.ReadSectionSearchRet();

            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            adjustButtonEnable();
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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
            this._sampleButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1; // ADD 2015/02/06 T.Miyamoto サンプル取込機能追加
            this._loginNameLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;  // 印刷
            this._pdfButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;  // PDF表示
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
           
            #region ガイドボタン
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGoodsCodeSt.ImageList = this._imageList16;
            this.uButton_BlGoodsCodeSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGoodsCodeEd.ImageList = this._imageList16;
            this.uButton_BlGoodsCodeEd.Appearance.Image = (int)Size16_Index.STAR1;
            #endregion

            this.SetSampleButton(false);
        }

        /// <summary>
        /// フォーカス変換処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォーカス変換処理。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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
                                            e.NextCtrl = this.tComboEditor_DeleteFlag;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SectionCodeAllowZero;
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
                case "PMREC09011UB":
                    {
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.Name == "uButton_RowDelete"
                                || e.NextCtrl.Name == "uButton_AllRowDelete"
                                || e.NextCtrl.Name == "uButton_Revival"
                                || e.NextCtrl.Name == "uButton_GetPriceDate"
                                || e.NextCtrl.Name == "_PMREC09011UA_Toolbars_Dock_Area_Top"
                                || e.NextCtrl.Name == "_PMREC09011UB_Toolbars_Dock_Area_Top")
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

                #region 得意先コード
                case "tNedit_CustomerCodeAllowZero":
                    {
                        // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                        //if (!this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()))
                        if (!this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.DataText))
                        // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                        {
                            e.NextCtrl = e.PrevCtrl; //フォーカス移動無し
                            break;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                                    //if (this.tNedit_CustomerCodeAllowZero.GetInt() == 0)
                                    if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() == string.Empty)
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                                    {
                                        e.NextCtrl = this.uButton_CustomerGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                    }
                                }
                                else
                                {
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                                    //this.Search();
                                    //e.NextCtrl = null;
                                    if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() == string.Empty)
                                    {
                                        e.NextCtrl = this.uButton_CustomerGuide;
                                    }
                                    else
                                    {
                                        this.Search();
                                        e.NextCtrl = null;
                                    }
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
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
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_SectionCodeAllowZero;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region 得意先ガイドボタン
                case "uButton_CustomerGuide":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                                //e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                if (this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                }
                                else
                                {
                                    this.Search();
                                    e.NextCtrl = null;
                                }
                                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
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
                                e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion

                #region 拠点コード
                case "tNedit_SectionCodeAllowZero":
                    {
                        // --- UPD 2015/02/13 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#193 ------------------------------>>>>>
                        //string sectionCode = this.tNedit_SectionCodeAllowZero.DataText.PadLeft(2, '0');
                        string sectionCode = this.tNedit_SectionCodeAllowZero.DataText.Trim();
                        // --- UPD 2015/02/13 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#193 ------------------------------<<<<<
                        if (!this.SectionCheck(sectionCode))
                        {
                            e.NextCtrl = e.PrevCtrl; //フォーカス移動無し
                            this.tNedit_SectionCodeAllowZero.SelectAll();
                            break;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
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
                        break;
                    }
                #endregion

                #region 拠点ガイドボタン
                case "uButton_SectionGuide":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
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
                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion


                #region 推奨元BLコード（開始）
                case "tEdit_BlGoodsCodeSt":
                    {
                        bool hasValue = true;
                        int blGoodsCodeSt = 0;

                        // 入力値を取得
                        Int32.TryParse(this.tEdit_BlGoodsCodeSt.Text.Trim(), out blGoodsCodeSt);

                        if (blGoodsCodeSt != 0)
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt = null;
                            if (this._recGoodsLkStAcs.BLGoodsCdDic.ContainsKey(blGoodsCodeSt))
                            {
                                blGoodsCdUMnt = this._recGoodsLkStAcs.BLGoodsCdDic[blGoodsCodeSt];
                            }

                            if (blGoodsCdUMnt != null)
                            {
                                this.tEdit_BlGoodsCodeSt.Text = blGoodsCdUMnt.BLGoodsCode.ToString().PadLeft(5, '0');
                                this.uLabel_BlGoodsNameSt.Text = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            else
                            {
                                this.uLabel_BlGoodsNameSt.Text = string.Empty;
                            }
                        }
                        else
                        {
                            this.tEdit_BlGoodsCodeSt.Text = string.Empty;
                            this.uLabel_BlGoodsNameSt.Text = string.Empty;
                        }

                        // フォーカス設定
                        if (hasValue)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this.tEdit_BlGoodsCodeSt.Text.Trim() == string.Empty)
                                    {
                                        e.NextCtrl = this.uButton_BlGoodsCodeSt;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                                    }
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                                    //if (this.tNedit_CustomerCodeAllowZero.GetInt() == 0)
                                    if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() == string.Empty)
                                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                                    {
                                        e.NextCtrl = this.uButton_CustomerGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion

                #region 推奨元BLコードガイドボタン（開始）
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

                #region 推奨先BLコード（終了）
                case "tEdit_BlGoodsCodeEd":
                    {
                        bool hasValue = true;
                        int blGoodsCodeEd = 0;

                        // 入力値を取得
                        Int32.TryParse(this.tEdit_BlGoodsCodeEd.Text.Trim(), out blGoodsCodeEd);

                        if (blGoodsCodeEd != 0)
                        {
                            BLGoodsCdUMnt blGoodsCdUMnt = null;
                            if (this._recGoodsLkStAcs.BLGoodsCdDic.ContainsKey(blGoodsCodeEd))
                            {
                                blGoodsCdUMnt = this._recGoodsLkStAcs.BLGoodsCdDic[blGoodsCodeEd];
                            }

                            if (blGoodsCdUMnt != null)
                            {
                                this.tEdit_BlGoodsCodeEd.Text = blGoodsCdUMnt.BLGoodsCode.ToString().PadLeft(5, '0');
                                this.uLabel_BlGoodsNameEd.Text = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            else
                            {
                                this.uLabel_BlGoodsNameEd.Text = string.Empty;
                            }
                        }
                        else
                        {
                            this.tEdit_BlGoodsCodeEd.Text = string.Empty;
                            this.uLabel_BlGoodsNameEd.Text = string.Empty;
                        }

                        // フォーカス設定
                        if (hasValue)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this.tEdit_BlGoodsCodeEd.Text.Trim() == string.Empty)
                                    {
                                        e.NextCtrl = this.uButton_BlGoodsCodeEd;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_DeleteFlag;
                                    }
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (this.tEdit_BlGoodsCodeSt.Text.Trim() == string.Empty)
                                    {
                                        e.NextCtrl = this.uButton_BlGoodsCodeSt;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_BlGoodsCodeSt;
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion

                #region 推奨先BLコードガイドボタン（終了）
                case "uButton_BlGoodsCodeEd":
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
                                e.NextCtrl = this.tEdit_BlGoodsCodeEd;
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
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BlGoodsCodeEd.Text.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_BlGoodsCodeEd;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BlGoodsCodeEd;
                                }
                                // --- UPD ① T.Miyamoto --------------------<<<<<
                            }
                        }
                        break;
                    }
                #endregion

                #region グループボックス（得意先コード）
                case "uExGroupBox_CommonCondition":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                if (!this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    this.Search();
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    }
                #endregion

                #region グループボックス（BLコード）
                case "uExGroupBox_ExtraCondition":
                    {
                        
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    }
                #endregion
            }

            #region ■検索処理
            if (e.NextCtrl != null)  
            {
                if (e.PrevCtrl.Name != "PMREC09011UB")
                {
                    switch (e.NextCtrl.Name)
                    {
                        case "uGrid_Details":
                            {
                                this.Search();
                                e.NextCtrl = null;
                                break;
                            }
                    }
                }
            }
            #endregion

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
                    case "tNedit_SectionCodeAllowZero":
                    case "tNedit_CustomerCodeAllowZero":
                    case "tEdit_BlGoodsCodeSt":
                    case "tEdit_BlGoodsCodeEd":
                        {
                            SetGuidButton(true);
                            break;
                        }
                    case "uGrid_Details":
                        {
                            this._detailInput.SetGridGuid();
                            break;
                        }
                    case "_PMREC09011UA_Toolbars_Dock_Area_Top":
                    case "_PMREC09011UB_Toolbars_Dock_Area_Top":
                        break;
                    default:
                        SetGuidButton(false);
                        break;
                }
            }
            #endregion

            // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
            #region ■サンプル取込の有効無効設定
            if (e.NextCtrl == this.uStatusBar_Main)
            {
                e.NextCtrl = e.PrevCtrl;
                return;
            }
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_SectionCodeAllowZero":
                    case "tNedit_CustomerCodeAllowZero":
                    case "tEdit_BlGoodsCodeSt":
                    case "tEdit_BlGoodsCodeEd":
                        {
                            this.SetSampleButton(false);
                            break;
                        }
                    case "uGrid_Details":
                        {
                            this.SetSampleButton(true);
                            break;
                        }
                    case "_PMREC09011UA_Toolbars_Dock_Area_Top":
                    case "_PMREC09011UB_Toolbars_Dock_Area_Top":
                        break;
                    default:
                        this.SetSampleButton(false);
                        break;
                }
            }
            #endregion
            // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------<<<<<
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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
                        if (this.tNedit_SectionCodeAllowZero.Focused)
                        {
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_SectionCodeAllowZero, this.tNedit_SectionCodeAllowZero));
                        }
                        else if (this.tNedit_CustomerCodeAllowZero.Focused)
                        {
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_CustomerCodeAllowZero, this.tNedit_CustomerCodeAllowZero));
                        }
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
                        // --- DEL 2015/03/11 Y.Wakita Redmine#355 ---------->>>>>
                        //else
                        //{
                        //    this.Save();
                        //}
                        // --- DEL 2015/03/11 Y.Wakita Redmine#355 ----------<<<<<
                        this.Save();    // ADD 2015/03/11 Y.Wakita Redmine#355
                        break;
                    }
                // クリア
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        this.Clear();
                        RecGoodsLkSt recGoodsLkSt = null;
                        this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows[this._recGoodsLkStAcs.RecGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                        this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();
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
                // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
                // サンプル取込
                case TOOLBAR_SAMPLEBUTTON_KEY:
                    {
                        // --- UPD 2015/02/10④ T.Miyamoto ------------------------------>>>>>
                        //this.SampleSetting();
                        this.SampleSetting(false);
                        // --- UPD 2015/02/10④ T.Miyamoto ------------------------------<<<<<
                        break;
                    }
                // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                case TOOLBAR_PRINT_KEY:
                    {
                        // 印刷
                        Print(false);
                        break;
                    }
                case TOOLBAR_PDF_KEY:
                    {
                        // PDF表示
                        Print(true);
                        break;
                    }
                // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            }
        }
        // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
        /// <summary>
        /// 印刷(PDF表示)
        /// </summary>
        /// <param name="pdfOut">PDF表示するかどうか</param>
        /// <remarks>
        /// <br>Note        : 印刷(PDF表示)</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void Print(bool pdfOut)
        {
            // 明細一覧が存在しない場合は実行不能
            if (this._detailInput.uGrid_Details.Rows.Count == 0)
            {
                return;
            }

            // 印刷オブジェクト呼び出し
            SFCMN06001U printDialog = new SFCMN06001U();
            SFCMN06002C printInfo = new SFCMN06002C();

            printInfo.printmode = (pdfOut) ? 2 : 1;　// 2：PDF表示のみ、1：印刷のみ
            printInfo.pdfopen = false;
            printInfo.pdftemppath = "";

            // 直接印刷バージョン
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ASSMBLY_ID;　// 起動PGID
            // PDF出力履歴用
            printInfo.prpnm = "";

            // 検索条件格納
            if (_extrInfoForPrint != null)
            {
                printInfo.jyoken = _extrInfoForPrint;
            }

            // 印刷データ作成
            DataTable dt = null;
            GetPrintDataSetFromDataView(out dt);

            DataView dtView = new DataView(dt);
            printInfo.rdData = dtView;
            printInfo.key = dtView.Table.TableName;

            printDialog.PrintInfo = printInfo;

            DialogResult result = printDialog.ShowDialog(this);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // PDF表示の場合
            if (printInfo.pdfopen)
            {
                /*
                PMZAI04201UB pdfForm = new PMZAI04201UB(this.Parent as Form);

                try
                {
                    pdfForm.PDFShow(printInfo.pdftemppath);
                }
                finally
                {
                    pdfForm.Close();
                    pdfForm.Dispose();
                }
                 */ 
            }
        }

        /// <summary>
        /// 印刷用データテーブル生成
        /// </summary>
        /// <param name="dt"></param>
        /// <remarks>
        /// <br>Note        : 印刷用データテーブル生成</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void GetPrintDataSetFromDataView(out DataTable dt)
        {
            dt = new DataTable("InventoryDataDsp");

            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RowNoColumn.ColumnName, typeof(string));  // №
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName, typeof(string));  // 削除日
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName, typeof(string));  // 拠点コード
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName, typeof(string));  // 拠点略称
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName, typeof(string));  // 得意先コード
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName, typeof(string));  // 得意先略称
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName, typeof(string));  // 推奨元BLコード
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName, typeof(string));  // 推奨元BLコード名
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName, typeof(string));  // 推奨先BLコード
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName, typeof(string));  // 推奨先BLコード名
            dt.Columns.Add(this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName, typeof(string));  // 商品コメント

            DataRow row = null;

            for (int i = 0; i < this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows.Count; i++)
            {
                if (this._recGoodsLkStAcs.RecGoodsLkDataTable[i].FilterGuid != Guid.Empty)
                {
                    row = dt.NewRow();

                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].InqOtherSecCd.ToString().Trim().PadLeft(2, '0');  // 拠点コード
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].InqOtherSecNm.Trim();  // 拠点略称
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].CustomerCode.ToString().Trim().PadLeft(6, '0');  // 得意先コード
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].CustomerSnm.Trim();  // 得意先略称
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].RecSourceBLGoodsCd.ToString().Trim().PadLeft(5, '0');  // 推奨元BLコード
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].RecSourceBLGoodsNm.Trim();  // 推奨元BLコード名
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].RecDestBLGoodsCd.ToString().Trim().PadLeft(5, '0');  // 推奨先BLコード
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].RecDestBLGoodsNm.Trim();  // 推奨先BLコード名
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName] = this._recGoodsLkStAcs.RecGoodsLkDataTable[i].GoodsComment.Trim();  // 商品コメント

                    dt.Rows.Add(row);
                }
            }
            
            /*
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this._detailInput.uGrid_Details.Rows)
            {
                if ((Guid)gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.FilterGuidColumn.ColumnName].Value != Guid.Empty)
                {
                    row = dt.NewRow();

                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RowNoColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RowNoColumn.ColumnName].Value;  // №
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName].Value;  // 削除日
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString().PadLeft(2,'0');  // 拠点コード
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value;  // 拠点略称
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value.ToString().PadLeft(6, '0');  // 得意先コード
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value;  // 得意先略称
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value.ToString().PadLeft(5, '0');  // 推奨元BLコード
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value;  // 推奨元BLコード名
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value.ToString().PadLeft(5, '0');  // 推奨先BLコード
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value;  // 推奨先BLコード名
                    row[this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName] = gridRow.Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName].Value;  // 商品コメント

                    dt.Rows.Add(row);
                }
            }
             */ 
        }

        /// <summary>
        /// ボタンの有効/無効切替
        /// </summary>
        /// <remarks>
        /// <br>Note        : ボタンの有効/無効切替</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void adjustButtonEnable()
        {
            bool bDataFlg = false;
            for (int i = 0; i < this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows.Count; i++)
            {
                if (this._recGoodsLkStAcs.RecGoodsLkDataTable[i].FilterGuid == Guid.Empty)
                {
                    continue;
                }
                bDataFlg = true;
                break;
            }

            if (bDataFlg == true)
            {
                // 印刷
                this.tToolsManager_MainMenu.Tools[TOOLBAR_PRINT_KEY].SharedProps.Enabled = true;
                // PDF出力
                this.tToolsManager_MainMenu.Tools[TOOLBAR_PDF_KEY].SharedProps.Enabled = true;
            }
            else
            {
                // 印刷
                this.tToolsManager_MainMenu.Tools[TOOLBAR_PRINT_KEY].SharedProps.Enabled = false;
                // PDF出力
                this.tToolsManager_MainMenu.Tools[TOOLBAR_PDF_KEY].SharedProps.Enabled = false;
            }
        }
        // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<

        /// <summary>
        /// 得意先ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタン</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        /// <summary>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // フォーカス設定
                if (this._cusotmerGuideSelected == true)
                {
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                    //if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()))
                    if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.DataText))
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                    {
                        tEdit_BlGoodsCodeSt.Focus();
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        /// <summary>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tNedit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim();
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                    tNedit_CustomerCodeAllowZero.Focus();
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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
                        this.uLabel_BlGoodsNameSt.Text = blGoodsUnit.BLGoodsHalfName;
                        this.tEdit_BlGoodsCodeEd.Focus();
                    }
                    else if ((Control)sender == this.tEdit_BlGoodsCodeEd
                        || (Control)sender == this.uButton_BlGoodsCodeEd)
                    {
                        this.tEdit_BlGoodsCodeEd.Text = blGoodsUnit.BLGoodsCode.ToString().PadLeft(5, '0');
                        this.uLabel_BlGoodsNameEd.Text = blGoodsUnit.BLGoodsHalfName;
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
        /// BLコードAfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ＢＬコードイベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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

        #region 列幅自動調整
        /// <summary>
        /// 列幅自動調整チェックボックスの変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 列幅自動調整チェックボックスの変更。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RowNoColumn.ColumnName].Width = 40;            // №
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName].Width = 80;       // 削除日
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Width = 60;     // 拠点コード
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Width = 180;     // 拠点略称
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Width = 80;     // 得意先コード
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Width = 180;     // 得意先略称
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Width = 70; // 推奨元BLコード
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Width = 240; // 推奨元BLコード名
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Width = 70;    // 推奨先BLコード
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Width = 240;   // 推奨先BLコード名
                editBand.Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.GoodsCommentColumn.ColumnName].Width = 400;   // 商品コメント
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
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
                    if (this._recGoodsLkStAcs.CompareSearchCondition(this._searchCondition, searchCondition))
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

            this._extrInfoForPrint = searchCondition; // ADD 2014/03/05 田建委 Redmine#42247

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "検索処理中";
            msgForm.Message = "検索処理中です。";
            msgForm.Show();

            string errMess = string.Empty;
            int count = 0;
            // 検索処理
            int status = this._recGoodsLkStAcs.Search(searchCondition,out count, out errMess);

            msgForm.Close();

            // ソート設定の解除
            this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
            this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.RefreshSort(true);

            #region 検索結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //削除指定区分=通常の場合
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.LeftFocusFlg = false;
                }
                else
                {
                    this._detailInput.LeftFocusFlg = true;
                }

                this._searchCondition = searchCondition;
                // 検索後、明細部設定処理
                this._detailInput.GridSettingAfterSearch(this._recGoodsLkStAcs.DeleteSearchMode);
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    if (this.tNedit_SectionCodeAllowZero.GetInt() != 0)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            // --- UPD 2015/03/12 Y.Wakita ---------->>>>>
                            //this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.GetInt();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.DataText;
                            // --- UPD 2015/03/12 Y.Wakita ----------<<<<<
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                            if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                            {
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                            }
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(false);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    else if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
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
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(true);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    // --- ADD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#196 ------------------------------>>>>>
                    if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                    {
                        this._detailInput.CustomerCheck_Detail(this.tNedit_CustomerCodeAllowZero.GetInt(), this._detailInput.uGrid_Details.Rows.Count - 1);
                    }
                    // --- ADD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#196 ------------------------------<<<<<
                    RecGoodsLkSt recGoodsLkSt = null;
                    this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows[this._recGoodsLkStAcs.RecGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                    this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();
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
                // --- UPD 2015/02/09 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
                //TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_INFO,
                //            this.Name,
                //            "検索条件に該当するデータが存在しません。",
                //            0,
                //            MessageBoxButtons.OK);
                if (searchCondition.RecSourceBLGoodsCdSt == 0 &&
                    searchCondition.RecSourceBLGoodsCdEd == 99999 &&
                    searchCondition.DeleteFlag == 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(this
                                                             , emErrorLevel.ERR_LEVEL_INFO
                                                             , this.Name
                                                             , "検索条件に該当するデータが存在しません。" + "\r\n" + "\r\n" +
                                                               "サンプル取込を実行しますか？"
                                                             , 0
                                                             , MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // --- UPD 2015/02/10④ T.Miyamoto ------------------------------>>>>>
                        //this.SampleSetting();
                        this.SampleSetting(true);
                        // --- UPD 2015/02/10④ T.Miyamoto ------------------------------<<<<<
                        return;

                        // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                        adjustButtonEnable();
                        // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
                    }
                }
                else
                {
                    TMsgDisp.Show(this
                                 ,emErrorLevel.ERR_LEVEL_INFO
                                 ,this.Name
                                 ,"検索条件に該当するデータが存在しません。"
                                 ,0
                                 ,MessageBoxButtons.OK);
                }
                // --- UPD 2015/02/09 T.Miyamoto サンプル取込機能追加 ------------------------------<<<<<

                this._searchCondition = searchCondition;
                // 検索後、明細部設定処理
                this._detailInput.GridSettingAfterSearch(this._recGoodsLkStAcs.DeleteSearchMode);

                //削除指定区分=通常の場合
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.Clear(true);
                    this._detailInput.SetButtonEnabled(1);

                    if (this.tNedit_SectionCodeAllowZero.GetInt() != 0)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            // --- UPD 2015/03/12 Y.Wakita ---------->>>>>
                            //this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.GetInt();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.DataText;
                            // --- UPD 2015/03/12 Y.Wakita ----------<<<<<
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                            if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                            {
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                                this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                            }
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(false);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    else if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                    {
                        if (this._detailInput.uGrid_Details.Rows.Count > 0)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();

                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
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
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            SetGuidButton(true);
                        }
                        else
                        {
                            SetGuidButton(false);
                        }
                    }
                    // --- ADD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#196 ------------------------------>>>>>
                    if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                    {
                        this._detailInput.CustomerCheck_Detail(this.tNedit_CustomerCodeAllowZero.GetInt(), this._detailInput.uGrid_Details.Rows.Count - 1);
                    }
                    // --- ADD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#196 ------------------------------<<<<<
                    RecGoodsLkSt recGoodsLkSt = null;
                    this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows[this._recGoodsLkStAcs.RecGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                    this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();
                }
                //削除指定区分=削除分のみの場合
                else
                {
                    this._detailInput.SetButtonEnabled(3);

                    this._recGoodsLkStAcs.PrevRecGoodsLkDic.Clear();
                    // 明細DataTable行クリア処理
                    this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows.Clear();

                    this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkStAcs.RecGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = true;

                    this.tNedit_SectionCodeAllowZero.Focus();
                    SetGuidButton(true);
                }
            }
            else
            {
                // サーチ
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                    "PMREC09011U", 						// アセンブリＩＤまたはクラスＩＤ
                    "リコメンド商品関連設定マスタ",     // プログラム名称
                    "Search", 							// 処理名称
                    TMsgDisp.OPE_GET, 					// オペレーション
                    "読み込みに失敗しました。", 		// 表示するメッセージ
                    status, 							// ステータス値
                    this._recGoodsLkStAcs,               // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				// 表示するボタン
                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン
            }
            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            adjustButtonEnable();
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            #endregion
        }

        /// <summary>
        /// 検索前、チェック処理
        /// </summary>
        /// <param name="searchCondition">検索条件</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 検索前、チェック処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private bool SearchCheck(SearchCondition searchCondition)
        {
            List<RecGoodsLkSt> deleteList;
            List<RecGoodsLkSt> updateList;

            // 削除指定区分=0の場合
            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
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

            // 推奨元BLコードの範囲チェック
            if (searchCondition.RecSourceBLGoodsCdSt > searchCondition.RecSourceBLGoodsCdEd)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "推奨元BLコードの範囲指定に誤りがあります。",
                            0,
                            MessageBoxButtons.OK);
                this.tEdit_BlGoodsCodeSt.Focus();
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private int Save()
        {
            List<RecGoodsLkSt> deleteList;
            List<RecGoodsLkSt> updateList;

            int status = 0;
            RecGoodsLkSt errorRecGoodsLkObj = null;
            // 削除指定区分=0の場合
            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
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

                status = this._recGoodsLkStAcs.SaveProc(deleteList, updateList, out errorRecGoodsLkObj);

                string errorMsg = string.Empty;
                if (errorRecGoodsLkObj != null)
                {
                    TMsgDisp.Show(this
                                 ,emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 ,this.Name
                                 ,"同一の商品設定が既に登録されています。" + "\r\n" +
                                  "・拠点ｺｰﾄﾞ  　：" + errorRecGoodsLkObj.InqOtherSecCd.PadLeft(2, '0') + "\r\n" +
                                  "・得意先ｺｰﾄﾞ　：" + errorRecGoodsLkObj.CustomerCode.ToString().PadLeft(8, '0') + "\r\n" +
                                  "・推奨元BLｺｰﾄﾞ：" + errorRecGoodsLkObj.RecSourceBLGoodsCd.ToString().PadLeft(5, '0') + "\r\n" +
                                  "・推奨先BLｺｰﾄﾞ：" + errorRecGoodsLkObj.RecDestBLGoodsCd.ToString().PadLeft(5, '0')
                                 ,0
                                 ,MessageBoxButtons.OK);
                        return -1;
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

                status = this._recGoodsLkStAcs.SaveProc(deleteList, updateList, out errorRecGoodsLkObj);
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
                        this.tNedit_SectionCodeAllowZero.Focus();
                        this.SetGuidButton(true);
                        this.SetSampleButton(false); // ADD 2015/03/05 Y.Wakita Redmine#328

                        adjustButtonEnable(); // ADD 2015/03/03 T.Miyamoto Redmine#302

                        RecGoodsLkSt recGoodsLkSt = null;
                        this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows[this._recGoodsLkStAcs.RecGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                        this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "PMREC09011U",				        	// アセンブリＩＤまたはクラスＩＤ
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
                            "PMREC09011U",				        	// アセンブリＩＤまたはクラスＩＤ
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
                            "PMREC09011U", 						// アセンブリＩＤまたはクラスＩＤ
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
                            "PMREC09011U", 						// アセンブリＩＤまたはクラスＩＤ
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
                           "PMREC09011U",                        // アセンブリＩＤまたはクラスＩＤ
                           "リコメンド商品関連設定マスタ",       // プログラム名称
                           "Save",                               // 処理名称
                           TMsgDisp.OPE_UPDATE,                  // オペレーション
                           "登録に失敗しました。",               // 表示するメッセージ
                           status,                               // ステータス値
                           this._recGoodsLkStAcs,                 // エラーが発生したオブジェクト
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void Clear()
        {
            bool clearFlg = false;
            #region クリア処理前、編集行チェック
            List<RecGoodsLkSt> deleteList;
            List<RecGoodsLkSt> updateList;

            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
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

                //// ソート設定の解除
                //this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

                // 初期フォーカス設定
                //ヘッダの状態によってフォーカス位置を調整
                //グループボックス（得意先）が開いている場合は得意先コードにフォーカス遷移
                if (this.uExGroupBox_CommonCondition.Expanded == true)
                {
                    this.tNedit_SectionCodeAllowZero.Focus();
                }
                else
                {
                  //グループボックス（得意先）が開いておらず、
                    //グループボックス（BLコード）が開いている場合はBLコード（開始）にフォーカス遷移
                    if (this.uExGroupBox_ExtraCondition.Expanded == true)
                    {
                        this.tEdit_BlGoodsCodeSt.Focus();
                    }
                    else
                    //グループボックスが開いていない場合はグループボックス（得意先）にフォーカス遷移
                    {
                        this.uExGroupBox_CommonCondition.Focus();
                    }
                }
                this.SetGuidButton(true);
                this.SetSampleButton(false); // ADD 2015/02/06 T.Miyamoto サンプル取込機能追加

                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                adjustButtonEnable(); 
                // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            }
        }

        /// <summary>
        /// 検索条件部を初期化する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索条件部を初期化する</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void ConditionClear()
        {
            #region 基本条件クリア
            this.tNedit_SectionCodeAllowZero.Clear();
            this.uLabel_SectionName.Text = string.Empty;
            this.tNedit_CustomerCodeAllowZero.Clear();
            this.uLabel_CustomerName.Text = string.Empty;
            #endregion

            #region 抽出条件クリア
            this.tEdit_BlGoodsCodeSt.Clear();
            this.uLabel_BlGoodsNameSt.Text = string.Empty;
            this.tEdit_BlGoodsCodeEd.Clear();
            this.uLabel_BlGoodsNameEd.Text = string.Empty;
            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
            #endregion
        }
        
        /// <summary>
        /// 画面クローズ処理
        /// </summary>
        /// <param name="boolean">boolean</param>
        /// <remarks>
        /// <br>Note       : 画面クローズ処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void Close(bool boolean)
        {
            List<RecGoodsLkSt> deleteList;
            List<RecGoodsLkSt> updateList;

            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
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

        /// <summary>
        /// ガイド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイド起動処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void GuideStart()
        {
            // 拠点
            if (this.tNedit_SectionCodeAllowZero.Focused)
            {
                this.uButton_SectionGuide_Click(this.tNedit_SectionCodeAllowZero, new EventArgs());
            }
            // 得意先
            else if (this.tNedit_CustomerCodeAllowZero.Focused)
            {
                this.uButton_CustomerGuide_Click(this.tNedit_CustomerCodeAllowZero, new EventArgs());
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
            // グリッド
            else
            {

                int rowIndex = -1;
                string keyName = this._detailInput.GetFocusColumnKey(out rowIndex);
                if (!string.Empty.Equals(keyName))
                {
                    switch (keyName)
                    {
                        case "InqOtherSecCd":
                            {
                                this._detailInput.SectionCodeGuide(rowIndex);
                                break;
                            }
                        case "CustomerCode":
                            {
                                this._detailInput.CustomerCodeGuide(rowIndex);
                                break;
                            }
                        case "RecSourceBLGoodsCd":
                        case "RecDestBLGoodsCd":
                            {
                                this._detailInput.BLGoodsCodeGuide(rowIndex, keyName);
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
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void ReNewal()
        {
            ReadCustomerSearchRet(); // 得意先情報読込処理

            SFCMN00299CA processingDialog = new SFCMN00299CA();
            try
            {
                processingDialog.Title = "最新情報取得";
                processingDialog.Message = "現在、最新情報取得中です。";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);

                this._recGoodsLkStAcs.LoadMstData();

                while (this._recGoodsLkStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
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

        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
        /// <summary>
        /// サンプル取込取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : サンプル取込処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private void SampleSetting(bool SetFlg)
        {
            // 拠点・得意先入力画面表示
            PMREC09011UC SampleDialog = new PMREC09011UC();
            // --- ADD 2015/02/10④ T.Miyamoto ------------------------------>>>>>
            SampleDialog.SampleSecCd = string.Empty;
            SampleDialog.SampleSecNm = string.Empty;
            SampleDialog.SampleCustomerInfo = new CustomerInfo();
            SampleDialog.SampleCustomerInfo.CustomerCode = -1; // ADD 2015/03/03 T.Miyamoto Redmine#308
            if (SetFlg)
            {
                SampleDialog.SampleSecCd = this.tNedit_SectionCodeAllowZero.DataText.Trim();
                SampleDialog.SampleSecNm = this.uLabel_SectionName.Text.Trim();
                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                //SampleDialog.SampleCustomerInfo.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();
                if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() != string.Empty)
                {
                    SampleDialog.SampleCustomerInfo.CustomerCode = this.tNedit_CustomerCodeAllowZero.GetInt();
                }
                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                SampleDialog.SampleCustomerInfo.CustomerSnm = this.uLabel_CustomerName.Text.Trim();
            }
            // --- ADD 2015/02/10④ T.Miyamoto ------------------------------<<<<<
            DialogResult dialogResult = SampleDialog.ShowDialog();
            SampleDialog.Close();
            if (dialogResult == DialogResult.OK)
            {
                this.SampleDataSet(SampleDialog.SampleSecCd, SampleDialog.SampleSecNm, SampleDialog.SampleCustomerInfo);
            }
        }

        /// <summary>
        /// サンプル取込データ（提供）読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : サンプル取込処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private void SampleDataSet(string sampleSecCd, string sampleSecNm, CustomerInfo sampleCustomerInfo)
        {
            int status = 0;
            string errMess = string.Empty;
            this._recGoodsLkStAcs.SampleSecCd = sampleSecCd;
            this._recGoodsLkStAcs.SampleSecNm = sampleSecNm;
            this._recGoodsLkStAcs.SampleCustomerInfo = sampleCustomerInfo;
            

            // --- UPD 2015/03/02 T.Miyamoto ------------------------------>>>>>
            //status = this._recGoodsLkStAcs.SampleCheck(out errMess);
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (!this._detailInput.CheckSampleData(sampleSecCd, sampleSecNm, sampleCustomerInfo))
            {
                status = this._recGoodsLkStAcs.SampleCheck(out errMess);
            }
            // --- UPD 2015/03/02 T.Miyamoto ------------------------------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_INFO
                             , this.Name
                             , "既に商品関連設定が登録されています。"
                             , 0
                             , MessageBoxButtons.OK);
                return;
            }

            status = this._recGoodsLkStAcs.SampleSearch(out errMess);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // サンプル設定取込後、明細部設定処理
                this._detailInput.GridSettingAfterSampleSet();

                // 新規行に基本情報の拠点・得意先をセット
                if (this.tNedit_SectionCodeAllowZero.GetInt() != 0)
                {
                    // --- UPD 2015/03/12 Y.Wakita ---------->>>>>
                    //this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.GetInt();
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.DataText;
                    // --- UPD 2015/03/12 Y.Wakita ----------<<<<<
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                }
                if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
                {
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.tNedit_CustomerCodeAllowZero.GetInt();
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = this.uLabel_CustomerName.Text.Trim();
                    // --- ADD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#196 ------------------------------>>>>>
                    this._detailInput.CustomerCheck_Detail(this.tNedit_CustomerCodeAllowZero.GetInt(), this._detailInput.uGrid_Details.Rows.Count - 1);
                    // --- ADD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#196 ------------------------------<<<<<
                }

                // 新規行にフォーカスセット
                if (this.tNedit_SectionCodeAllowZero.GetInt() == 0)
                {
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                }
                else if (this.tNedit_CustomerCodeAllowZero.GetInt() == 0)
                {
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                }
                else
                {
                    this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkStAcs.RecGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                }
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this
                             ,emErrorLevel.ERR_LEVEL_INFO
                             ,this.Name
                             ,"検索条件に該当するデータが存在しません。"
                             ,0
                             ,MessageBoxButtons.OK);
            }
            else
            {
                // サーチ
                TMsgDisp.Show(this
                             ,emErrorLevel.ERR_LEVEL_STOP
                             ,"PMREC09011U"
                             ,"リコメンド商品関連設定マスタ"
                             , "SampleSetting"
                             ,TMsgDisp.OPE_GET
                             ,"読み込みに失敗しました。"
                             ,status
                             ,this._recGoodsLkStAcs
                             ,MessageBoxButtons.OK
                             ,MessageBoxDefaultButton.Button1);
            }
        }
        // --- ADD 2015/02/06 T.Miyamoto ｻﾝﾌﾟﾙ取込機能追加 ------------------------------<<<<<

        /// <summary>
        /// 詳細グリッド最上位行アプイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 詳細グリッド最上位行アプウン時に発生します。</br>      
        /// <br>Programmer : 宮本利明</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks> 
        private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        {
            Control control = null;
            if (this.uExGroupBox_ExtraCondition.Expanded == false)
            {
                control = this.tNedit_SectionCodeAllowZero;
                this.SetGuidButton(true);
            }
            else
            {
                control = this.tComboEditor_DeleteFlag;
                this.SetGuidButton(true);
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
        /// <br>Programmer : 宮本利明</br>                                  
        /// <br>Date       : 2015/01/20</br> 
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
            searchCondition.InqOtherEpCd = this._enterpriseCode;
            // 拠点コード
            flag = int.TryParse(this.tNedit_SectionCodeAllowZero.Text, out code);
            if (flag)
            {
                // --- UPD 2015/03/04 T.Miyamoto Redmine#193 ------------------------------>>>>>
                //searchCondition.InqOtherSecCd = code.ToString().PadLeft(2, '0');
                //// --- UPD 2015/02/10 ｼｽﾃﾑﾃｽﾄ#174 T.Miyamoto -------------------->>>>>
                ////SecInfoSet secInfoSet = this._recGoodsLkStAcs.SecInfoSetDic[code.ToString().PadLeft(2, '0')];
                //if (searchCondition.InqOtherSecCd == "00")
                //{
                //    searchCondition.InqOtherSecCd = "";
                //}
                //else
                //{
                //    SecInfoSet secInfoSet = this._recGoodsLkStAcs.SecInfoSetDic[code.ToString().PadLeft(2, '0')];
                //}
                //// --- UPD 2015/02/10 ｼｽﾃﾑﾃｽﾄ#174 T.Miyamoto --------------------<<<<<
                if (code.ToString().Trim() == string.Empty)
                {
                    searchCondition.InqOtherSecCd = string.Empty;
                }
                else
                {
                    searchCondition.InqOtherSecCd = code.ToString().PadLeft(2, '0');
                    if (searchCondition.InqOtherSecCd != "00")
                    {
                        SecInfoSet secInfoSet = this._recGoodsLkStAcs.SecInfoSetDic[code.ToString().PadLeft(2, '0')];
                    }
                }
                // --- UPD 2015/03/04 T.Miyamoto Redmine#193 ------------------------------<<<<<
            }
            else
            {
                searchCondition.InqOtherSecCd = "";
            }

            // 得意先コード
            flag = int.TryParse(this.tNedit_CustomerCodeAllowZero.Text, out code);
            if (flag)
            {
                searchCondition.CustomerCode = code;
                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                //CustomerInfo customerInfo = this._recGoodsLkStAcs.CustomerDic[code];
                //searchCondition. InqOriginalEpCd = customerInfo.CustomerEpCode; //得意先企業コード
                //searchCondition.InqOriginalSecCd = customerInfo.CustomerSecCode; //得意先拠点コード
                if (code == 0)
                {
                    searchCondition.InqOriginalEpCd = "0000000000000000"; //得意先企業コード
                    searchCondition.InqOriginalSecCd = "000000";           //得意先拠点コード
                }
                else
                {
                    CustomerInfo customerInfo = this._recGoodsLkStAcs.CustomerDic[code];
                    searchCondition.InqOriginalEpCd = customerInfo.CustomerEpCode; //得意先企業コード
                    searchCondition.InqOriginalSecCd = customerInfo.CustomerSecCode; //得意先拠点コード
                }
                // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
            }
            else
            {
                searchCondition.CustomerCode = 0;
            }

            // 推奨元BLコード（開始）
            flag = int.TryParse(this.tEdit_BlGoodsCodeSt.Text, out code);
            if (flag)
            {
                searchCondition.RecSourceBLGoodsCdSt = code;
            }
            else
            {
                searchCondition.RecSourceBLGoodsCdSt = 0;
            }

            // 推奨元BLコード（終了）
            flag = int.TryParse(this.tEdit_BlGoodsCodeEd.Text, out code);
            if (flag)
            {
                searchCondition.RecSourceBLGoodsCdEd = code;
            }
            else
            {
                searchCondition.RecSourceBLGoodsCdEd = 99999;
            }

            // 削除指定区分
            searchCondition.DeleteFlag = this.tComboEditor_DeleteFlag.SelectedIndex;
        }

        /// <summary>
        /// ガイドボタン設定処理
        /// </summary>
        /// <param name="enable">enable</param>
        /// <remarks>
        /// <br>Note       : ガイドボタン設定処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks>
        public void SetGuidButton(bool enable)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = enable;
        }
        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
        /// <summary>
        /// サンプル取込ボタン設定処理
        /// </summary>
        /// <param name="enable">enable</param>
        /// <remarks>
        /// <br>Note       : サンプル取込ボタン設定処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>                                  
        /// <br>Date       : 2015/02/06</br> 
        /// </remarks>
        public void SetSampleButton(bool enable)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Sample"].SharedProps.Enabled = enable;
            // --- ADD 2015/03/05 Y.Wakita Redmine#326 ---------->>>>>
            if (this.tComboEditor_DeleteFlag.SelectedIndex == 1)
            {
                // 1:削除分のみ
                this.tToolsManager_MainMenu.Tools["ButtonTool_Sample"].SharedProps.Enabled = false;
            }
            // --- ADD 2015/03/05 Y.Wakita Redmine#326 ----------<<<<<
        }
        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------<<<<<

        /// <summary>
        /// 画面初期化の時、フォーカスを設定する。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化の時、フォーカスを設定する。</br>
        /// <br>Programmer : 宮本利明</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks>
        public void SetInitFocus()
        {
            this.tNedit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// 画面の得意先情報を取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の得意先情報を取得処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void GetCustomerInfo(out Int32 customerCode, out string customerName)
        {
            customerCode = 0;
            customerName = string.Empty;
            if (this.tNedit_CustomerCodeAllowZero.GetInt() != 0)
            {
                customerCode = this.tNedit_CustomerCodeAllowZero.GetInt();
                customerName = this.uLabel_CustomerName.Text.Trim();
            }
        }
        /// <summary>
        /// 画面の拠点情報を取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の拠点情報を取得処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void GetSectionInfo(out string sectionCode, out string sectionName)
        {
            sectionCode = string.Empty;
            sectionName = string.Empty;
            if (this.tNedit_SectionCodeAllowZero.GetInt() != 0)
            {
                sectionCode = this.tNedit_SectionCodeAllowZero.GetInt().ToString();
                sectionName = this.uLabel_SectionName.Text.Trim();
            }
        }

        #endregion

        /// <summary>
        /// 得意先情報読込処理
        /// </summary>
        private void ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }
        
        /// <summary>
        /// 拠点情報読込処理
        /// </summary>
        private void ReadSectionSearchRet()
        {
            this._sectionSearchRetDic = new Dictionary<int, SecInfoSet>();

            try
            {
                ArrayList retArray = new ArrayList();

                int status = this._secInfoSetAcs.Search(out retArray, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (SecInfoSet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._sectionSearchRetDic.Add(int.Parse(ret.SectionCode), ret);
                        }
                    }
                }
            }
            catch
            {
                this._sectionSearchRetDic = new Dictionary<int, SecInfoSet>();
            }
        }
        
        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // 得意先コード
            this.tNedit_CustomerCodeAllowZero.SetInt(customerSearchRet.CustomerCode);

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// 得意先チェック処理
        /// </summary>
        // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
        //public bool CustomerCheck(int customerCode)
        public bool CustomerCheck(string sCustomerCode)
        // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
        {
            string errMsg;
            CustomerInfo retCustomerInfo;

            // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
            if (sCustomerCode.Trim() == string.Empty)
            {
                this.tNedit_CustomerCodeAllowZero.Clear();
                this.uLabel_CustomerName.Text = "";
                return true;
            }
            int customerCode = int.Parse(sCustomerCode);
            // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<

            bool checkResult = this._recGoodsLkStAcs.CheckCustomer(customerCode, false, out errMsg, out retCustomerInfo);
            if (checkResult)
            {
                //得意先クリア
                this.tNedit_CustomerCodeAllowZero.Clear();
                this.uLabel_CustomerName.Text = "";

                this._prevCusotmerCd = 0;
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                if (customerCode == 0)
                {
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                    //this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //得意先コード
                    this.tNedit_CustomerCodeAllowZero.DataText = customerCode.ToString().PadLeft(8, '0');
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                    //this.uLabel_CustomerName.Text = "全得意先"; //得意先略称
                    this.uLabel_CustomerName.Text = RecGoodsLkStAcs.ALL_CUSTOMERNAME; //得意先略称
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                }
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                else if (retCustomerInfo != null)
                {
                    this._prevCusotmerCd = customerCode;
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                    //this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //得意先コード
                    this.tNedit_CustomerCodeAllowZero.DataText = customerCode.ToString().PadLeft(8, '0');
                    // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                    this.uLabel_CustomerName.Text = retCustomerInfo.CustomerSnm; //得意先略称
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                this.tNedit_CustomerCodeAllowZero.SetInt(this._prevCusotmerCd);
            }
            return checkResult;
        }
        /// <summary>
        /// 拠点チェック処理
        /// </summary>
        public bool SectionCheck(string sectionCode)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                //拠点クリア
                this.tNedit_SectionCodeAllowZero.Clear();
                this.uLabel_SectionName.Text = "";

                this._prevSectionCd = "";
                // --- ADD 2015/02/13 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#193 ------------------------------>>>>>
                if (sectionCode != "")
                {
                    sectionCode = sectionCode.PadLeft(2, '0');
                }
                // --- ADD 2015/02/13 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#193 ------------------------------<<<<<
                // --- ADD 2015/02/10 ｼｽﾃﾑﾃｽﾄ#174 T.Miyamoto -------------------->>>>>
                if (sectionCode == "00")
                {
                    this._prevSectionCd = sectionCode;
                    this.tNedit_SectionCodeAllowZero.Text = sectionCode;
                    this.uLabel_SectionName.Text = "全社共通";
                }
                // --- ADD 2015/02/10 ｼｽﾃﾑﾃｽﾄ#174 T.Miyamoto --------------------<<<<<
                if (retSectionInfo != null)
                {
                    this._prevSectionCd = sectionCode;
                    this.tNedit_SectionCodeAllowZero.Text = retSectionInfo.SectionCode; //拠点コード
                    this.uLabel_SectionName.Text = retSectionInfo.SectionGuideNm; //拠点名
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                this.tNedit_SectionCodeAllowZero.Text = this._prevSectionCd; //拠点コード
            }
            return checkResult;
        }
    }
}