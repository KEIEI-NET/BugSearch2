//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品設定マスタ
// プログラム概要   : お買得商品設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/03  修正内容 : RedMine#304 画像をドラッグ&ドロップするたびに
//                                              メモリ使用量が増える
//                                  RedMine#312 「削除分のみ」で検索後、クリアしても
//                                              イメージ・公開情報が入力できないままになる
//                                  RedMine#313 抽出条件チェック後のフォーカス移動が不正
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/09  修正内容 : 品質保証部のRedMine#3091
//                                  画像参照からのアップロードに失敗するケースあり
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/16  修正内容 : 障害 検索表示時に公開区分がOFFの場合、項目が非活性にならない
//                                       また行移動時も同様
//                                  要望 公開区分をOFFにした場合に非活性項目の値をクリアしない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/24  修正内容 : 品証Redmine#3093 課題管理表№35
//                                  メーカー希望価格・標準価格の再計算機能を実装する
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
using System.Reflection;
using System.Xml.XPath;
using System.Xml.Xsl;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// お買得商品設定マスタ UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買得商品設定マスタUIフォームクラス</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public partial class PMREC09021UA : Form
    {
        # region Private Members
        private PMREC09021UB _detailInput;
        private ImageList _imageList16 = null;                                                // イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;                   // 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;                    // クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;                    // ガイドボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;                  // 最新情報ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _moveButton;                     // 移動ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;                  // ログイン担当者
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;              // ログイン担当者名称
        private ControlScreenSkin _controlScreenSkin;
        private Control _prevControl = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private CustomerInfoAcs _customerInfoAcs = null;
        private RecBgnGdsAcs _recBgnGdsAcs = null;

        private CustomerSearchRet _customerSearchRet = null;
        /// <summary> お買得商品グループ検索結果</summary>
        private RecBgnGrpRet _recBgnGrpRet = null;

        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;
        private UserGuideAcs _userGuideAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;
        private BLGroupUAcs _blGroupUAcs;

        /// <summary>日付取得部品</summary>
        private DateGetAcs _dateGetAcs;

        /// <summary>伝票表示タブ 列サイズ自動調整値</summary>
        private bool _columnWidthAutoAdjust = false;

        private string _prevSectionCd = string.Empty;   
        private int _prevApplyStaDate = 0;
        private int _prevApplyEndDate = 0;

        private bool _masterCheckFlg = false;
        private bool _isButtonClick = false;

        private RecBgnGdsSearchPara _recBgnGdsSearchPara = null;

        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;

        private string _NSDirectory; // NSシステムのPath
        #endregion

        #region const
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// 終了
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";					// 検索
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// 保存
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// クリア
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// ガイド
        private const string TOOLBAR_RENEWALBUTTON_KEY = "ButtonTool_ReNewal";					// 最新情報
        private const string TOOLBAR_MOVEBUTTON_KEY = "ButtonTool_Move";						// 移動

        /// <summary>表示：初期フォントサイズ</summary>
        private const int CT_DEF_FONT_SIZE = 10;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        /// <summary>文字サイズ</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        /// <summary>明細データ抽出最大件数</summary>
        private const long DATA_COUNT_MAX = 20000;
        /// <summary>全社設定</summary>
        private const string ALL_SECTION_CODE = "00";
        private const string ALL_SECTION_NAME = "全社共通";

        // ファイル名
        private const string PDF_HELP_FILE = "image\\PMREC09020U\\PMREC09020U.pdf";     // 「お勧め運用ご紹介」ヘルプファイル
        private const string IMG_SAMPLE_FILE = "image\\PMREC09020U\\SampleImage.png";   // 「お客様側表示イメージ」サンプル
        private const string IMG_DRAGDROP_FILE = "image\\PMREC09020U\\DragDrop.png";    // ドラッグ＆ドロップ画像

        // DataSet名
        private const string DATASET_NAME = "Base";

        // 部品イメージ格納サイズ
        //private const int GOODSIMG_SAVE_WIDTH = 200;
        //private const int GOODSIMG_SAVE_HEIGHT = 150;
        private const int GOODSIMG_SAVE_WIDTH = 640;
        private const int GOODSIMG_SAVE_HEIGHT = 640;
        #endregion

        # region Constroctors
        /// <summary>
        ///  お買得商品設定マスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタフォームクラス デフォルトコンストラクタ</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public PMREC09021UA()
        {
            InitializeComponent();

            // 変数初期化
            this._detailInput = new PMREC09021UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Search"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_ReNewal"];
            this._moveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Move"];
            this._detailInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
            this._loginEmployeeLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._detailInput.SetGuidButton += new PMREC09021UB.SetGuidButtonEventHandler(this.SetGuidButton);
            this._detailInput.GetBaseInfo += new PMREC09021UB.GetBaseInfoEventHandler(this.GetBaseInfo);
            this._detailInput.OpenGoodsImgFile += new PMREC09021UB.OpenGoodsImgFileEventHandler(this.OpenGoodsImgFile);
            this._detailInput.GoodsInfoPreview += new PMREC09021UB.GoodsInfoPreviewEventHandler(this.GoodsInfoPreview);
            this._detailInput.PreviewColumnSync += new PMREC09021UB.PreviewColumnSyncEventHandler(this.PreviewColumnSync);
            this._detailInput.GoodsInfoPreviewClear += new PMREC09021UB.GoodsInfoPreviewClearEventHandler(this.GoodsInfoPreviewClear);

            this._recBgnGdsAcs = this._detailInput.RecBgnGdsAcs;
            this._makerAcs = new MakerAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._customerInfoAcs = new CustomerInfoAcs();

            // 設定読み込み
            this._detailInput.Deserialize();

            this.uExGroupBox_ExtraCondition.Expanded = false;
            this.tComboEditor_DeleteFlag.SelectedIndex = 0;
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = 0;
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = this._detailInput.UserSetting.OutputStyle;

            _NSDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory; // NSシステムのPath
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09021UA_Load(object sender, EventArgs e)
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

            this._recBgnGdsAcs.LoadMstData();

            while (this._recBgnGdsAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            while (this._recBgnGdsAcs.GoodsAcsThread.ThreadState == System.Threading.ThreadState.Running)
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

            // 得意先
            if (this._recBgnGdsAcs.CustomerDic.Count > 0)
            {
                _secCusSetDataTable = new RecBgnGdsDataSet.SecCusSetDataTable();

                _secCusSetDataTable.BeginLoadData();
                foreach (int key in this._recBgnGdsAcs.CustomerDic.Keys)
                {
                    CustomerInfo customerInfo = null;
                    customerInfo = this._recBgnGdsAcs.CustomerDic[key];

                    RecBgnGdsDataSet.SecCusSetRow newRow = _secCusSetDataTable.NewSecCusSetRow();
                    newRow.CustomerCode = customerInfo.CustomerCode.ToString();
                    newRow.CustomerName = customerInfo.CustomerSnm;
                    _secCusSetDataTable.AddSecCusSetRow(newRow);
                }
                _secCusSetDataTable.EndLoadData();
            }

            // 検索条件部を初期化
            this.ConditionClear();

            // 明細情報プレビュー表示部を初期化
            this.GoodsInfoPreviewClear();

            // 得意先別設定削除
            this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Clear();

            // ツールバーF6用
            this.ChangeToolsMove(0);

            this._detailInput.LoadSettings();

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

            // 商品イメージをＤ＆Ｄを有効にする
            pictureBox_GoodsImage.AllowDrop = true;

            // サンプル画像
            string samplePath = Path.Combine(_NSDirectory, IMG_SAMPLE_FILE);
            if (File.Exists(samplePath))
            {
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                //pictureBox1.Image = new Bitmap(im);

                using (FileStream fs = File.OpenRead(samplePath))
                {
                    using (Image img = Image.FromStream(fs, false, false))
                    {
                        pictureBox1.Image = new Bitmap(img);
                    }
                }
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<

            }

            // ドラッグ＆ドロップ画像
            string ddPath = Path.Combine(_NSDirectory, IMG_DRAGDROP_FILE);
            if (File.Exists(ddPath))
            {
                // 2015/03/03
                using (FileStream fs = File.OpenRead(ddPath))
                {
                    using (Image img = Image.FromStream(fs, false, false))
                    {
                        pictureBox_GoodsImage.BackgroundImage = new Bitmap(img);
                    }
                }
                //pictureBox_GoodsImage.BackgroundImage = new Bitmap(ddPath);
            }

            string sPath = Path.Combine(_NSDirectory, PDF_HELP_FILE);
            if (!File.Exists(sPath))
            {
                this.uButton_HelpGuide.Enabled = false;
            }

            // イメージ入力部表示
            panel_SaleImage.Visible = true;
            uExGroupBox_Image.Text = "お客様側表示イメージ";

        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
            this._moveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;

            this._loginNameLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            
            #region ガイドボタン
            // 拠点
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // ﾒｰｶｰ（開始－終了）
            this.uButton_MakerCdSt.ImageList = this._imageList16;
            this.uButton_MakerCdSt.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_MakerCdEd.ImageList = this._imageList16;
            this.uButton_MakerCdEd.Appearance.Image = (int)Size16_Index.STAR1;
            // お買得商品ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            this.uButton_BrgnGoodsGrpCodeGuide.ImageList = this._imageList16;
            this.uButton_BrgnGoodsGrpCodeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            #endregion
        }

        /// <summary>
        /// フォーカス変換処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォーカス変換処理。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
                                        if (this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
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
                                                e.NextCtrl = this.tComboEditor_DeleteFlag;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
                                            }
                                            break;
                                        }
                                        else if (this._recBgnGdsAcs.PrevRecBgnGdsDic != null
                                              && this._recBgnGdsAcs.PrevRecBgnGdsDic.Count <= 0
                                              && this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
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
                                                e.NextCtrl = this.tComboEditor_DeleteFlag;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
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
                case "PMREC09021UB":
                    {
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.Name == "uButton_RowDelete"
                             || e.NextCtrl.Name == "uButton_AllRowDelete"
                             || e.NextCtrl.Name == "uButton_Revival"
                             || e.NextCtrl.Name == "uButton_Recapture"   // ADD 2015/03/24 Y.Wakita
                             || e.NextCtrl.Name == "_PMREC09021UA_Toolbars_Dock_Area_Top"
                             || e.NextCtrl.Name == "_PMREC09021UB_Toolbars_Dock_Area_Top")
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

                #region 拠点
                case "tNedit_SectionCodeAllowZero":
                    {
                        bool checkFlg = true;
                        string sectionCode = this.tNedit_SectionCodeAllowZero.DataText.Trim();
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
                                if (this.uExGroupBox_ExtraCondition.Expanded)
                                {
                                    e.NextCtrl = this.tEdit_MakerCdSt;
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
                                    e.NextCtrl = this.tEdit_MakerCdSt;
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
                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
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
                                e.NextCtrl = this.tNedit_SectionCodeAllowZero;
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
                                    e.NextCtrl = this.tEdit_GoodsNo;
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
                                e.NextCtrl = this.tEdit_GoodsNo;
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

                #region 品番*
                case "tEdit_GoodsNo":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tDateEdit_OpenDateSt;
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

                #region 公開日（開始）
                case "tDateEdit_OpenDateSt":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tDateEdit_OpenDateEd;
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

                #region 公開日（終了）
                case "tDateEdit_OpenDateEd":
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
                                e.NextCtrl = this.tDateEdit_OpenDateSt;
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
                                e.NextCtrl = this.tDateEdit_OpenDateEd;
                            }
                        }
                        break;
                    }
                #endregion
                
                #region 全得意先設定

                #region 品名
                case "tEdit_GoodsName":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        // 品名
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = this.tEdit_GoodsName.Text.Trim();

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 商品コメント
                                e.NextCtrl = this.tEdit_GoodsComment;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // 品名
                                this._detailInput.uGrid_Details.Focus();
                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 明細の品名へ移動
                                e.NextCtrl = this.panel_DetailInput;
                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                #endregion

                #region 商品コメント
                case "tEdit_GoodsComment":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        // 商品コメント
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value = this.tEdit_GoodsComment.Text.Trim();

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 商品イメージ
                                e.NextCtrl = this.uButton_FolderOpen;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 品名
                                e.NextCtrl = this.tEdit_GoodsName;
                            }
                        }

                        break;
                    }
                #endregion

                #region 商品イメージ
                case "uButton_FolderOpen":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 公開開始日
                                e.NextCtrl = this.tDateEdit_ApplyStaDate;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 商品コメント
                                e.NextCtrl = this.tEdit_GoodsComment;
                            }
                        }

                        break;
                    }
                #endregion

                #region 公開開始日
                case "tDateEdit_ApplyStaDate":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        this._detailInput.SetApplyStaDate = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
                        if (this.tDateEdit_ApplyStaDate.LongDate != 0)
                        {
                            if (this._prevApplyStaDate != this.tDateEdit_ApplyStaDate.LongDate)
                            {
                                string date_St = this.tDateEdit_ApplyStaDate.LongDate.ToString();
                                // 日付チェック
                                bool chkFlg = this._detailInput.CheckDateValue(ref date_St);
                                if (!chkFlg)
                                {
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "公開開始日に誤りがあります。",
                                                0,
                                                MessageBoxButtons.OK);

                                    e.NextCtrl = this.tDateEdit_ApplyStaDate;

                                    break;
                                }
                                this.tDateEdit_ApplyStaDate.LongDate = int.Parse(date_St.Replace("/", ""));

                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value = date_St;
                                this._prevApplyStaDate = this.tDateEdit_ApplyStaDate.LongDate;

                                //if (this.tDateEdit_ApplyEndDate.LongDate != 0)
                                //{
                                //    string date_Ed = this.DateFormat(this.tDateEdit_ApplyEndDate.LongDate.ToString());
                                //    this.DispApplyDate(date_St, date_Ed);
                                //}
                            }
                        }
                        else
                        {
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value = string.Empty;
                            this._prevApplyStaDate = this.tDateEdit_ApplyStaDate.LongDate;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 公開終了日
                                e.NextCtrl = this.tDateEdit_ApplyEndDate;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 商品イメージ
                                e.NextCtrl = this.uButton_FolderOpen;
                            }
                        }

                        break;
                    }
                #endregion

                #region 公開終了日
                case "tDateEdit_ApplyEndDate":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        this._detailInput.SetApplyEndDate = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();
                        if (this.tDateEdit_ApplyEndDate.LongDate != 0)
                        {
                            if (this._prevApplyEndDate != this.tDateEdit_ApplyEndDate.LongDate)
                            {
                                string date_Ed = this.tDateEdit_ApplyEndDate.LongDate.ToString();
                                // 日付チェック
                                bool chkFlg = this._detailInput.CheckDateValue(ref date_Ed);
                                if (!chkFlg)
                                {
                                    TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "公開終了日に誤りがあります。",
                                                0,
                                                MessageBoxButtons.OK);

                                    e.NextCtrl = this.tDateEdit_ApplyEndDate;

                                    break;
                                }
                                this.tDateEdit_ApplyEndDate.LongDate = int.Parse(date_Ed.Replace("/", ""));

                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value = date_Ed;
                                this._prevApplyEndDate = this.tDateEdit_ApplyEndDate.LongDate;

                                //if (this.tDateEdit_ApplyEndDate.LongDate != 0)
                                //{
                                //    string date_St = this.DateFormat(this.tDateEdit_ApplyStaDate.LongDate.ToString());
                                //    this.DispApplyDate(date_St, date_Ed);
                                //}
                            }
                        }
                        else
                        {
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value = string.Empty;
                            this._prevApplyEndDate = this.tDateEdit_ApplyEndDate.LongDate;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 表示区分
                                e.NextCtrl = this.uCheckEditor_DisplayDivCode;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 公開開始日
                                e.NextCtrl = this.tDateEdit_ApplyStaDate;
                            }
                        }

                        break;
                    }
                #endregion

                #region 表示区分
                case "uCheckEditor_DisplayDivCode":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        //if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString() != string.Empty)
                        //{
                        //    // 表示区分
                        //    this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Value = Convert.ToInt32(this.uCheckEditor_DisplayDivCode.Checked).ToString();
                        //}

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // お買得商品ｸﾞﾙｰﾌﾟ
                                e.NextCtrl = this.tEdit_BrgnGoodsGrpCode;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // 表示区分
                                this._detailInput.uGrid_Details.Focus();
                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 公開終了日
                                e.NextCtrl = this.tDateEdit_ApplyEndDate;
                            }
                        }

                        break;
                    }
                #endregion

                #region お買得商品ｸﾞﾙｰﾌﾟ
                case "tEdit_BrgnGoodsGrpCode":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        this._detailInput.SetBrgnGoodsGrpCode = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString());

                        if (this.tEdit_BrgnGoodsGrpCode.Text != string.Empty)
                        {
                            // お買得商品ｸﾞﾙｰﾌﾟ
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this.tEdit_BrgnGoodsGrpCode.Text.Trim();
                            // お買得商品ｸﾞﾙｰﾌﾟ名
                            this.uLabel_BrgnGoodsGrpName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();
                        }
                        else
                        {
                            // お買得商品ｸﾞﾙｰﾌﾟ
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 売価率
                                e.NextCtrl = this.tNedit_UnitCalcRate;
                            }
                            else if (e.Key == Keys.Up)
                            {
                                // お買得商品ｸﾞﾙｰﾌﾟ
                                this._detailInput.uGrid_Details.Focus();
                                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 表示区分
                                e.NextCtrl = this.uCheckEditor_DisplayDivCode;
                            }
                        }

                        break;
                    }
                #endregion

                #region 売価率
                case "tNedit_UnitCalcRate":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        if (this.tNedit_UnitCalcRate.Text != string.Empty)
                        {
                            // 売価率
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = double.Parse(this.tNedit_UnitCalcRate.Text);
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 売単価
                                e.NextCtrl = this.tNedit_UnitPrice;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // お買得商品ｸﾞﾙｰﾌﾟ
                                e.NextCtrl = this.tEdit_BrgnGoodsGrpCode;
                            }
                        }

                        break;
                    }
                #endregion

                #region 売単価
                case "tNedit_UnitPrice":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        if (this.tNedit_UnitPrice.Text != string.Empty)
                        {
                            // 売単価
                            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = long.Parse(this.tNedit_UnitPrice.Text.Replace(",",""));
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 個別設定
                                e.NextCtrl = this.uButton_OpenRecBgnCust;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 売価率
                                e.NextCtrl = this.tNedit_UnitCalcRate;
                            }
                        }

                        break;
                    }
                #endregion

                #region 得意先別設定
                case "uButton_OpenRecBgnCust":
                    {
                        int rowIndex = this._detailInput.RowIndex;
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 個別設定
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    if (rowIndex == _detailInput.uGrid_Details.Rows.Count - 1)
                                    {
                                        if (this._detailInput.CheckDateForDown())
                                        {
                                            this._detailInput.NewRowAdd();

                                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = this._detailInput.uGrid_Details;
                                        
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_OpenRecBgnCust;
                                        }
                                    }
                                    else
                                    {
                                        this._detailInput.uGrid_Details.Rows[rowIndex + 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = this._detailInput.uGrid_Details;
                                    }
                                }

                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // 売単価
                                e.NextCtrl = this.tNedit_UnitPrice;
                            }
                        }

                        break;
                    }
                #endregion

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
                    case "tEdit_MakerCdSt":
                    case "tEdit_MakerCdEd":
                    case "tNedit_SectionCodeAllowZero":
                        SetGuidButton(true);
                        // ツールバーF6切り替え
                        this.ChangeToolsMove(0);
                        break;
                    case "uGrid_Details":
                        {
                            this._detailInput.SetGridGuid();
                            // ツールバーF6切り替え
                            this.ChangeToolsMove(1);
                            break;
                        }
                    case "_PMREC09021UA_Toolbars_Dock_Area_Top":
                    case "_PMREC09021UB_Toolbars_Dock_Area_Top":
                        break;
                    case "tEdit_BrgnGoodsGrpCode":
                        {
                            SetGuidButton(true);
                            // ツールバーF6切り替え
                            this.ChangeToolsMove(2);
                            break;
                        }
                    case "tEdit_GoodsName":
                    case "tEdit_GoodsComment":
                    case "pictureBox_GoodsImage":
                    case "uCheckEditor_DisplayDivCode":
                    case "tDateEdit_ApplyStaDate":
                    case "tDateEdit_ApplyEndDate":
                    case "tNedit_UnitCalcRate":
                    case "tNedit_UnitPrice":
                        {
                            // ツールバーF6切り替え
                            this.ChangeToolsMove(2);
                            break;
                        }
                    default:
                        SetGuidButton(false);
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// メインメニューツールボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : メインメニューツールボタン</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
                            this.tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Up, this.tNedit_SectionCodeAllowZero, this.tNedit_SectionCodeAllowZero));
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
                        RecBgnGds recBgnGds = null;
                        this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                        this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();
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

                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "画面情報はクリアされます。" + "\r\n" + "\r\n" +
                            "よろしいですか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.No) break;

                        this.ReNewal();
                        break;
                    }
                // 移動
                case TOOLBAR_MOVEBUTTON_KEY:
                    {
                        this.MoveToGridImage();
                        break;
                    }
            }
        }

        #region 拠点ガイド
        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタン</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
                    this.tNedit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.ToString().Trim().PadLeft(2, '0');
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;
                    this._prevSectionCd = secInfoSet.SectionCode;

                    if (sender != null)
                    {
                        if (!this.uExGroupBox_ExtraCondition.Expanded)
                        {
                            // 検索を行う
                            this.Search();
                        }
                        else
                        {
                            this.tEdit_MakerCdSt.Focus();
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion // 拠点ガイド

        #region メーカーコードガイド
        /// <summary>
        /// メーカーコードガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : メーカーコードガイドボタン</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
        #endregion // メーカーコードガイド

        /// <summary>
        /// メーカーAfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : メーカーイベント</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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

        #region 列幅自動調整
        /// <summary>
        /// 列幅自動調整チェックボックスの変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 列幅自動調整チェックボックスの変更。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// <br></br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust)
        {
            if (this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust
             || this._detailInput.uGrid_Details.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) return;

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

                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.RowNoColumn.ColumnName].Width = 40;		        // №
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UpdateTimeColumn.ColumnName].Width = 80;		    // 削除日
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Width = 35;		// 拠点
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Width = 85;		// 拠点名
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Width = 115;	        // 品番
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Width = 150;			// 品名
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Width = 40;		// ﾒｰｶｰ
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Width = 85;		// ﾒｰｶｰ名
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Width = 200;		// 商品ｺﾒﾝﾄ
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Width = 45;		// 商品ｲﾒｰｼﾞﾎﾞﾀﾝ
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Width = 65;	// お買得商品ｸﾞﾙｰﾌﾟ
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Width = 85;	// お買得商品ｸﾞﾙｰﾌﾟ名
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Width = 45;	    // 商品公開区分
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Width = 80;		// 公開開始日
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Width = 80;		// 公開終了日
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Width = 75;	// ﾒｰｶｰ希望小売価格
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Width = 50;       // 売掛率
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Width = 75;          // 売単価
                editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.RecBgnCustColumn.ColumnName].Width = 45;         // 得意先別


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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void Search()
        {
            RecBgnGdsSearchPara recBgnGdsSearchPara = null;

            //this.uCheckEditor_DisplayDivCode.CheckedChanged -= new EventHandler(uCheckEditor_DisplayDivCode_CheckedChanged);

            // 検索条件取得処理
            this.ScreenToRecBgnGdsSearchPara(ref recBgnGdsSearchPara);

            if (this._isButtonClick == false)
            {
                if (this._recBgnGdsSearchPara != null)
                {
                    if (this._recBgnGdsAcs.CompareRecBgnGdsSearchPara(this._recBgnGdsSearchPara, recBgnGdsSearchPara))
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
            if (!this.SearchCheck(recBgnGdsSearchPara))
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
            int status = this._recBgnGdsAcs.Search(recBgnGdsSearchPara, out count, out errMess);

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
                    this.uExGroupBox_Image.Enabled = true;
                }
                else
                {
                    this._detailInput.LeftFocusFlg = true;
                    this.uExGroupBox_Image.Enabled = false;
                }
                
                this._recBgnGdsSearchPara = recBgnGdsSearchPara;
                // 検索後、明細部設定処理
                this._detailInput.GridSettingAfterSearch(this._recBgnGdsAcs.DeleteSearchMode);
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    if (this._detailInput.uGrid_Details.Rows.Count > 0)
                    {
                        // グリッド列不可入力色設定
                        this._detailInput.DetailGridInitSetting();

                        // 拠点
                        if (this.tNedit_SectionCodeAllowZero.Text != ALL_SECTION_CODE)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                        }

                        this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        SetGuidButton(true);
                        this.ChangeToolsMove(1);

                        // --- ADD 2015/03/16 Y.Wakita 障害 ---------->>>>>
                        foreach (UltraGridRow row in this._detailInput.uGrid_Details.Rows)
                        {
                            int inputValue = 0;
                            // 入力値を取得
                            Int32.TryParse(row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text, out inputValue);
                            this._detailInput.ChangeDisplayDiv(row.Index, inputValue);
                        }
                        // --- ADD 2015/03/16 Y.Wakita 障害 ----------<<<<<
                    }
                    else
                    {
                        SetGuidButton(false);
                        this.ChangeToolsMove(0);
                    }

                    RecBgnGds recBgnGds = null;
                    this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                    this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();
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

                this._recBgnGdsSearchPara = recBgnGdsSearchPara;

                //削除指定区分=通常の場合
                if (this.tComboEditor_DeleteFlag.SelectedIndex == 0)
                {
                    this._detailInput.Clear(true);
                    this._detailInput.SetButtonEnabled(1);

                    if (this._detailInput.uGrid_Details.Rows.Count > 0)
                    {
                        // 拠点
                        if (this.tNedit_SectionCodeAllowZero.Text != ALL_SECTION_CODE)
                        {
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = this.tNedit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                            this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = this.uLabel_SectionName.Text.Trim();
                        }
                        this._detailInput.uGrid_Details.Rows[this._detailInput.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        SetGuidButton(true);
                    }
                    else
                    {
                        SetGuidButton(false);
                    }

                    RecBgnGds recBgnGds = null;
                    this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                    this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();
                }
                //削除指定区分=削除分のみの場合
                else
                {
                    this._detailInput.SetButtonEnabled(3);

                    this._recBgnGdsAcs.PrevRecBgnGdsDic.Clear();
                    // 明細DataTable行クリア処理
                    this._recBgnGdsAcs.RecBgnGdsDataTable.Rows.Clear();

                    this._detailInput.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = true;

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
                    "PMREC09021U", 						// アセンブリＩＤまたはクラスＩＤ
                    "お買得商品設定マスタ",           // プログラム名称
                    "Search", 							// 処理名称
                    TMsgDisp.OPE_GET, 					// オペレーション
                    "読み込みに失敗しました。", 		// 表示するメッセージ
                    status, 							// ステータス値
                    this._recBgnGdsAcs, 			// エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				// 表示するボタン
                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン
            }
            #endregion

            //this.uCheckEditor_DisplayDivCode.CheckedChanged += new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);

        }

        /// <summary>
        /// 検索前、チェック処理
        /// </summary>
        /// <param name="recBgnGdsSearchPara">検索条件</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 検索前、チェック処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private bool SearchCheck(RecBgnGdsSearchPara recBgnGdsSearchPara)
        {
            List<RecBgnGds> deleteList;
            List<RecBgnGds> updateList;

            // 削除指定区分=0の場合
            if (this._recBgnGdsAcs.DeleteSearchMode == false)
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

            // メーカーの範囲チェック
            if (recBgnGdsSearchPara.GoodsMakerCdSt > recBgnGdsSearchPara.GoodsMakerCdEd)
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

            // 公開日チェック
            Control errorControl = null;
            DateGetAcs.CheckDateRangeResult cdrResult;
            if (CheckDateRangeForSlip(ref this.tDateEdit_OpenDateSt, ref this.tDateEdit_OpenDateEd, out cdrResult, true) == false)
            {
                string errorMessage = string.Empty;
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        errorMessage = "公開日（開始）が不正です。";
                        errorControl = this.tDateEdit_OpenDateSt;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        errorMessage = "公開日（終了）が不正です。";
                        errorControl = this.tDateEdit_OpenDateEd;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        errorMessage = "公開日の範囲指定に誤りがあります。";
                        errorControl = this.tDateEdit_OpenDateSt;
                        break;
                }

                if (errorMessage != string.Empty && errorControl != null)
                {
                    // メッセージ表示
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 
                        this.Name,
                        errorMessage,
                        0,
                        MessageBoxButtons.OK);

                    // --- UPD 2015/03/03 Y.Wakita Redmine#313 ---------->>>>>
                    //this.tEdit_MakerCdSt.Focus();
                    errorControl.Focus();
                    // --- UPD 2015/03/03 Y.Wakita Redmine#313 ----------<<<<<

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 日付範囲チェック処理
        /// </summary>
        /// <param name="stEdit"></param>
        /// <param name="edEdit"></param>
        /// <param name="result"></param>
        /// <param name="allowNoInput"></param>
        /// <returns></returns>
        private bool CheckDateRangeForSlip(ref TDateEdit stEdit, ref TDateEdit edEdit, out DateGetAcs.CheckDateRangeResult result, bool allowNoInput)
        {
            int range = 3;
            if (allowNoInput) range = 0;

            result = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, range, ref stEdit, ref edEdit, allowNoInput);
            return (result == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private int Save()
        {
            List<RecBgnGds> deleteList;
            List<RecBgnGds> updateList;
            List<RecBgnCust> updateCustList;

            int status = 0;
            RecBgnGds errorRecBgnGds = null;
            // 削除指定区分=0の場合
            if (this._recBgnGdsAcs.DeleteSearchMode == false)
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

                // 得意先個別設定
                this._recBgnGdsAcs.SetGdsToCust2(updateList, out updateCustList);

                status = this._recBgnGdsAcs.SaveProc(deleteList, updateList, updateCustList, out errorRecBgnGds);

                string errorMsg = string.Empty;
                if (errorRecBgnGds != null)
                {
                    errorMsg = "拠点：" + errorRecBgnGds.InqOtherSecCd.ToString().PadLeft(2, '0')
                           + "、品番：" + errorRecBgnGds.GoodsNo.Trim()
                           + "、ﾒｰｶｰ：" + errorRecBgnGds.GoodsMakerCd.ToString().PadLeft(4, '0')
                           + "、公開日：" + errorRecBgnGds.ApplyStaDate.ToString().PadLeft(6, '0')
                           + "～" + errorRecBgnGds.ApplyEndDate.ToString().PadLeft(6, '0');
        
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "同一の商品設定が既に登録されています。" + "\r\n" +
                         errorMsg,
                         0,
                         MessageBoxButtons.OK);

                    foreach (UltraGridRow row in this._detailInput.uGrid_Details.Rows)
                    {
                        int startDate;
                        if (!int.TryParse(row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text.Replace("/", ""), out startDate)) startDate = 0;

                        if ((errorRecBgnGds.InqOtherEpCd == row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherEpCdColumn.ColumnName].Value.ToString())
                        && (errorRecBgnGds.InqOtherSecCd == row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString())
                        && (errorRecBgnGds.GoodsNo == row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString())
                        && (errorRecBgnGds.GoodsMakerCd == int.Parse(row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString()))
                        && (errorRecBgnGds.ApplyStaDate == startDate))
                        {
                            row.Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            break;
                        }
                    }
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

                // 得意先個別設定
                this._recBgnGdsAcs.SetGdsToCust2(updateList, out updateCustList);

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

                status = this._recBgnGdsAcs.SaveProc(deleteList, updateList, updateCustList, out errorRecBgnGds);
            }

            #region < 登録後処理 >
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 登録完了ダイアログ表示
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // 検索条件部を初期化する
                        this.ConditionClear();

                        // 明細情報プレビュー表示部を初期化
                        this.GoodsInfoPreviewClear();

                        // 得意先別設定削除
                        this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Clear();

                        // ツールバーF6用
                        this.ChangeToolsMove(0);

                        this._recBgnGdsSearchPara = null;

                        // グリッド初期設定処理
                        this._detailInput.Clear(true);
                        this.tNedit_SectionCodeAllowZero.Focus();
                        this.SetGuidButton(true);

                        RecBgnGds recBgnGds = null;

                        this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                        this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "PMREC09021U",				        	// アセンブリＩＤまたはクラスＩＤ
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
                            "PMREC09021U",				        	// アセンブリＩＤまたはクラスＩＤ
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
                            "PMREC09021U", 						// アセンブリＩＤまたはクラスＩＤ
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
                            "PMREC09021U", 						// アセンブリＩＤまたはクラスＩＤ
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
                           "PMREC09021U",                        // アセンブリＩＤまたはクラスＩＤ
                           "お買得商品設定マスタ",     // プログラム名称
                           "Save",                               // 処理名称
                           TMsgDisp.OPE_UPDATE,                  // オペレーション
                           "登録に失敗しました。",               // 表示するメッセージ
                           status,                               // ステータス値
                           this._recBgnGdsAcs,          // エラーが発生したオブジェクト
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void Clear()
        {
            bool clearFlg = false;
            #region クリア処理前、編集行チェック
            List<RecBgnGds> deleteList;
            List<RecBgnGds> updateList;

            if (this._recBgnGdsAcs.DeleteSearchMode == false)
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
                this._recBgnGdsSearchPara = null;

                //検索条件部を初期化する
                this.ConditionClear();

                // 明細情報プレビュー表示部を初期化
                this.GoodsInfoPreviewClear();

                // 得意先別設定削除
                this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Clear();

                // ツールバーF6用
                this.ChangeToolsMove(0);

                // グリッド初期設定処理
                this._detailInput.Clear(true);

                // ソート設定の解除
                this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

                // 初期フォーカス設定
                this.tNedit_SectionCodeAllowZero.Focus();

                // ガイドボタン設定
                this.SetGuidButton(true);
            }
        }

        /// <summary>
        /// 検索条件部を初期化する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索条件部を初期化する</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void ConditionClear()
        {
            #region 基本情報クリア
            this.tNedit_SectionCodeAllowZero.Clear();        // 拠点コード
            this.uLabel_SectionName.Text = string.Empty;    // 拠点名称
            this._prevSectionCd = string.Empty;
            #endregion

            #region 抽出条件クリア          
            this.tEdit_MakerCdSt.Clear();       // メーカー（開始）
            this.tEdit_MakerCdEd.Clear();       // メーカー（終了）
            this.tEdit_GoodsNo.Clear();         // 品番
            this.tDateEdit_OpenDateSt.LongDate = int.Parse(DateTime.Now.Date.ToString("yyyyMMdd")); // 公開日（開始）
            this.tDateEdit_OpenDateEd.Clear();  // 公開日（終了）
            this.tComboEditor_DeleteFlag.SelectedIndex = 0; // 削除指定区分
            #endregion
        }

        /// <summary>
        /// 明細情報プレビュー表示部を初期化する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細情報プレビュー表示部を初期化する</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void GoodsInfoPreviewClear()
        {
            this.tEdit_GoodsName.Clear();                       // 品名
            this.tEdit_GoodsComment.Clear();                    // 商品コメント
            this.pictureBox_GoodsImage.Image = null;            // 商品イメージ
            this.tDateEdit_ApplyStaDate.Clear();                // 公開日（開始）
            this.tDateEdit_ApplyEndDate.Clear();                // 公開日（終了）
            this.uCheckEditor_DisplayDivCode.Checked = true;    // 表示区分
            this.tEdit_BrgnGoodsGrpCode.Clear();                // お買得商品グループ
            this.uLabel_BrgnGoodsGrpName.Text = string.Empty;   // お買得商品グループ名
            this.uLabel_MkrSuggestRtPric.Text = string.Empty;   // ﾒｰｶｰ希望小売価格
            this.uLabel_MkrSuggestRtPric2.Text = string.Empty;  // ﾒｰｶｰ希望小売価格
            this.tNedit_UnitCalcRate.Clear();                   // 売価率
            this.tNedit_UnitPrice.Clear();                      // 売単価
            this.uLabel_ApplyDate.Text = string.Empty;          // 公開日（開始～終了）
            this.uLabel_RecBgnCust.Visible = false;             // 得意先設定あり
            // --- ADD 2015/03/03 Y.Wakita Redmine#312 ---------->>>>>
            // ｲﾒｰｼﾞ入力部活性
            this.uExGroupBox_Image.Enabled = true;
            // --- ADD 2015/03/03 Y.Wakita Redmine#312 ----------<<<<<
        }
       
        /// <summary>
        /// 画面クローズ処理
        /// </summary>
        /// <param name="boolean">boolean</param>
        /// <remarks>
        /// <br>Note       : 画面クローズ処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void Close(bool boolean)
        {
            List<RecBgnGds> deleteList;
            List<RecBgnGds> updateList;

            if (this._recBgnGdsAcs.DeleteSearchMode == false)
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void GuideStart()
        {
            // 拠点
            if (this.tNedit_SectionCodeAllowZero.Focused)
            {
                this.uButton_SectionGuide_Click(this.tNedit_SectionCodeAllowZero, new EventArgs());
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
            // お買得商品ｸﾞﾙｰﾌﾟ
            else if (this.tEdit_BrgnGoodsGrpCode.Focused)
            {
                this.uButton_BrgnGoodsGrpCodeGuide_Click(this.tEdit_BrgnGoodsGrpCode, new EventArgs());
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
                        case "GoodsMakerCode":
                            {
                                this._detailInput.GoodsMakerCodeGuide(rowIndex);
                                break;
                            }
                        //case "CustomerCode":
                        //    {
                        //        this._detailInput.CustomerCodeGuide(rowIndex);
                        //        break;
                        //    }
                        case "InqOtherSecCd":
                            {
                                this._detailInput.SectionGuide(rowIndex);
                                break;
                            }
                        case "BrgnGoodsGrpCode":
                            {
                                this._detailInput.SetGdsGrpCodeGuide(rowIndex, 0);
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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

                this._recBgnGdsAcs.LoadMstData();

                while (this._recBgnGdsAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
                while (this._recBgnGdsAcs.GoodsAcsThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    Thread.Sleep(100);
                }

                this._recBgnGdsSearchPara = null;

                //検索条件部を初期化する
                this.ConditionClear();

                // 明細情報プレビュー表示部を初期化
                this.GoodsInfoPreviewClear();

                // 得意先別設定削除
                this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Clear();

                // ツールバーF6用
                this.ChangeToolsMove(0);

                // グリッド初期設定処理
                this._detailInput.Clear(true);

                // ソート設定の解除
                this._detailInput.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

                // 初期フォーカス設定
                this.tNedit_SectionCodeAllowZero.Focus();

                // ガイドボタン設定
                this.SetGuidButton(true);

                RecBgnGds recBgnGds = null;
                this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsAcs.RecBgnGdsDataTable.Rows[this._recBgnGdsAcs.RecBgnGdsDataTable.Count - 1], ref recBgnGds);
                this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();

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
        /// 移動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 移動処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void MoveToGridImage()
        {
            int rowIndex = this._detailInput.RowIndex;

            // ツールバーF6切り替え
            this.ChangeToolsMove(1);

            // 品名
            if (this.tEdit_GoodsName.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // 商品コメント
            if (this.tEdit_GoodsComment.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // 商品イメージ
            if (this.uButton_FolderOpen.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // 公開開始日
            if (this.tDateEdit_ApplyStaDate.ContainsFocus)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // 公開終了日
            if (this.tDateEdit_ApplyEndDate.ContainsFocus)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // 表示区分
            if (this.uCheckEditor_DisplayDivCode.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // お買得商品ｸﾞﾙｰﾌﾟ
            if (this.tEdit_BrgnGoodsGrpCode.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // 売価率
            if (this.tNedit_UnitCalcRate.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // 売単価
            if (this.tNedit_UnitPrice.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // 得意先別設定
            if (this.uButton_FolderOpen.Focused)
            {
                this._detailInput.uGrid_Details.Focus();
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.RecBgnCustColumn.ColumnName].Activate();
                this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // グリッド
            else
            {
                // ツールバーF6切り替え
                this.ChangeToolsMove(2);

                string keyName = this._detailInput.GetFocusColumnKey(out rowIndex);
                if (!string.Empty.Equals(keyName))
                {
                    switch (keyName)
                    {
                        // 品名
                        case "GoodsName":
                            {
                                this.tEdit_GoodsName.Focus();
                                break;
                            }
                        // 商品コメント
                        case "GoodsComment":
                            {
                                this.tEdit_GoodsComment.Focus();
                                break;
                            }
                        // 商品イメージ
                        case "GoodsImageDmy":
                            {
                                this.uButton_FolderOpen.Focus();
                                break;
                            }
                        // 公開開始日
                        case "ApplyStaDate":
                            {
                                this.tDateEdit_ApplyStaDate.Focus();
                                break;
                            }
                        // 公開終了日
                        case "ApplyEndDate":
                            {
                                this.tDateEdit_ApplyEndDate.Focus();
                                break;
                            }
                        // 表示区分
                        case "DisplayDivCode":
                            {
                                this.uCheckEditor_DisplayDivCode.Focus();
                                break;
                            }
                        // お買得商品ｸﾞﾙｰﾌﾟ
                        case "BrgnGoodsGrpCode":
                            {
                                this.tEdit_BrgnGoodsGrpCode.Focus();
                                break;
                            }
                        // 売価率
                        case "UnitCalcRate":
                            {
                                this.tNedit_UnitCalcRate.Focus();
                                break;
                            }
                        // 売単価
                        case "UnitPrice":
                            {
                                this.tNedit_UnitPrice.Focus();
                                break;
                            }
                        // 得意先別設定
                        case "RecBgnCust":
                            {
                                this.uButton_FolderOpen.Focus();
                                break;
                            }
                            
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 詳細グリッド最上位行アプイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 詳細グリッド最上位行アプウン時に発生します。</br>      
        /// <br>Programmer : 脇田 靖之</br>                                  
        /// <br>Date       : 2015/02/20</br> 
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
        /// <param name="recBgnGdsSearchPara">自動調整するかどうか</param>
        /// <remarks>
        /// <br>Note       : 最新情報取得処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void ScreenToRecBgnGdsSearchPara(ref RecBgnGdsSearchPara recBgnGdsSearchPara)
        {
            int code = 0;
            bool flag = false;

            if (recBgnGdsSearchPara == null)
            {
                recBgnGdsSearchPara = new RecBgnGdsSearchPara();
            }

            // 問合せ先企業コード
            recBgnGdsSearchPara.InqOtherEpCd = this._enterpriseCode;

            // 問合せ先拠点コード
            flag = int.TryParse(this.tNedit_SectionCodeAllowZero.Text, out code);
            if (flag)
            {
                code = int.Parse(this.tNedit_SectionCodeAllowZero.Text);
                recBgnGdsSearchPara.InqOtherSecCd = code.ToString().PadLeft(2, '0');
            }
            else
            {
                recBgnGdsSearchPara.InqOtherSecCd = string.Empty;
            }

            // メーカー（開始）
            flag = int.TryParse(this.tEdit_MakerCdSt.Text, out code);
            if (flag)
            {
                recBgnGdsSearchPara.GoodsMakerCdSt = code;
            }
            else
            {
                recBgnGdsSearchPara.GoodsMakerCdSt = 0;
            }

            // メーカー（終了）
            flag = int.TryParse(this.tEdit_MakerCdEd.Text, out code);
            if (flag)
            {
                recBgnGdsSearchPara.GoodsMakerCdEd = code;
            }
            else
            {
                recBgnGdsSearchPara.GoodsMakerCdEd = 9999;
            }

            // 品番*
            recBgnGdsSearchPara.GoodsNo = this.tEdit_GoodsNo.Text.Trim();

            // 公開日（開始）
            recBgnGdsSearchPara.ApplyDateSt = this.tDateEdit_OpenDateSt.LongDate;

            // 公開日（終了）
            recBgnGdsSearchPara.ApplyDateEd = this.tDateEdit_OpenDateEd.LongDate;

            // 削除指定区分
            recBgnGdsSearchPara.DeleteFlag = this.tComboEditor_DeleteFlag.SelectedIndex;
        }

        /// <summary>
        /// ガイドボタン設定処理
        /// </summary>
        /// <param name="enable">enable</param>
        /// <remarks>
        /// <br>Note       : ガイドボタン設定処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void SetInitFocus()
        {
            this.tNedit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// 画面の基本情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の基本情報を取得処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void GetBaseInfo(out string sectionCode, out string sectionName)
        {
            sectionCode = this.tNedit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            sectionName = this.uLabel_SectionName.Text;
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : 得意先選択時に発生します。</br>
        /// <br>Programmer	: 脇田 靖之</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._customerSearchRet = null;
                return;
            }
            this._customerSearchRet = customerSearchRet;
        }
        #endregion

        /// <summary>
        /// 画像ファイル選択処理
        /// </summary>
        /// <param name="dats">画像ファイルバイナリデータ</param>
        /// <remarks>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/28</br>
        /// </remarks>
        public void OpenGoodsImgFile(out Byte[] dats)
        {
            dats = null;

            string filePath = string.Empty;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
           
            this.openFileDialog1.FileName = filePath;
            this.openFileDialog1.Filter = "画像ファイル(*.jpg;*.jpeg)|*.jpg;*.jpeg";
            if (this.openFileDialog1.InitialDirectory == string.Empty)
                this.openFileDialog1.InitialDirectory = path;

            DialogResult openResult = this.openFileDialog1.ShowDialog();
            if (openResult == DialogResult.OK)
            {
                string msg = string.Empty;
                Bitmap bmp = null;
                bool status = this.DatsFromBitmap(openFileDialog1.FileName, out bmp, out dats, out msg);
                if (status)
                {
                    this.openFileDialog1.InitialDirectory = openFileDialog1.FileName.Replace(openFileDialog1.SafeFileName, "");
                }
                else
                {
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         msg,
                         0,
                         MessageBoxButtons.OK);
                }
                if (bmp != null)
                    bmp.Dispose();
            }
        }
        /// <summary>
        /// 変換サイズ取得処理
        /// </summary>
        public void SaveSizeGet(ref int saveWidth, ref int saveHeight)
        {
            int iWidth = saveWidth;
            int iHeight = saveHeight;
            int dif = 0;

            // 縦横で長い方を基準に変更サイズを計算する
            if ((iWidth > iHeight) && (iWidth > GOODSIMG_SAVE_WIDTH)) // 横が縦よりも長い場合
                {
                // 最大値との差を計算
                dif = iWidth - GOODSIMG_SAVE_WIDTH;
                // 差を縦横同一比率でセットする
                saveWidth = saveWidth - dif;
                saveHeight = saveHeight - (int)(((double)iHeight / (double)iWidth) * dif);
            }
            else if ((iWidth < iHeight) && (iHeight > GOODSIMG_SAVE_HEIGHT)) // 縦が横よりも長い場合
            {
                // 最大値との差を計算
                dif = iHeight - GOODSIMG_SAVE_HEIGHT;
                // 差を縦横同一比率でセットする
                // --- UPD 2015/03/09 Y.Wakita Redmine#3091 ---------->>>>>
                //saveWidth = saveWidth - (int)(((double)iHeight / (double)iWidth) * dif);
                saveWidth = saveWidth - (int)(((double)iWidth / (double)iHeight) * dif);
                // --- UPD 2015/03/09 Y.Wakita Redmine#3091 ----------<<<<<
                saveHeight = saveHeight - dif;
                }
            else if ((iWidth == iHeight) && (iWidth > GOODSIMG_SAVE_WIDTH)) // 縦と横が同一の場合
            {
                // 最大値との差を計算
                dif = iWidth - GOODSIMG_SAVE_WIDTH;
                // 差を縦横同一比率でセットする
                saveWidth = saveWidth - dif;
                saveHeight = saveHeight - dif;
            }
        }

        private bool DatsFromBitmap(string fileName, out Bitmap bmp, out Byte[] dats, out string msg)
        {
            bmp = null;
            dats = null;
            msg = string.Empty;

            if (System.IO.Path.GetExtension(fileName) == ".jpg"
             || System.IO.Path.GetExtension(fileName) == ".jpeg"
             || System.IO.Path.GetExtension(fileName) == ".JPG"
             || System.IO.Path.GetExtension(fileName) == ".JPEG")
            {
                // Bitmap生成
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                //Bitmap bmpSrc = new Bitmap(fileName);

                Bitmap bmpSrc = null;
                using (FileStream fs = File.OpenRead(fileName))
                {
                    using (Image img = Image.FromStream(fs, false, false))
                    {
                        bmpSrc = new Bitmap(img);
                    }
                }
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<

                int saveWidth = bmpSrc.Size.Width;
                int saveHeight = bmpSrc.Size.Height;

                // 保存サイズ取得
                SaveSizeGet(ref saveWidth, ref saveHeight);

                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                //Bitmap bmpDest = new Bitmap(bmpSrc, saveWidth, saveHeight);
                //System.IO.MemoryStream mms = new System.IO.MemoryStream();
                //bmpDest.Save(mms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //dats = mms.GetBuffer();
                ////mms.Close();
                //mms.Dispose();
                //bmp = bmpDest;

                ////bmpSrc.Dispose();
                ////bmpDest.Dispose();

                using (Bitmap bmpDest = new Bitmap(bmpSrc, saveWidth, saveHeight))
                {
                    using (MemoryStream mms = new MemoryStream())
                    {
                bmpDest.Save(mms, System.Drawing.Imaging.ImageFormat.Jpeg);
                dats = mms.GetBuffer();
                        bmp = (Bitmap)bmpDest.Clone();
                    }
                }
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<
            }
            else
            {
                msg = "選択したファイルは使用できません。" + "\r\n" +
                      "画像ファイル（拡張子：.jpg、.jpeg）を選択して下さい。";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 明細情報プレビュー表示
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/28</br>
        /// </remarks>
        public void GoodsInfoPreview(int rowIndex)
        {
            try
            {
                this.uCheckEditor_DisplayDivCode.CheckedChanged -= new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);

                // --- DEL 2015/03/24 Y.Wakita ---------->>>>>
                //// ツール（明細入力⇔ｲﾒｰｼﾞ入力ボタン）設定
                //this._detailInput.tToolbarsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = false;
                // --- DEL 2015/03/24 Y.Wakita ----------<<<<<

                if (rowIndex >= 0 && rowIndex < this._detailInput.uGrid_Details.Rows.Count)
                {
                    // --- DEL 2015/03/24 Y.Wakita ---------->>>>>
                    //// ツール（明細入力⇔ｲﾒｰｼﾞ入力ボタン）設定
                    //this._detailInput.tToolbarsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = true;
                    // --- DEL 2015/03/24 Y.Wakita ----------<<<<<

                    int rowNo = rowIndex + 1;
                    uExGroupBox_Image.Text = "№" + rowNo.ToString() + "　得意先でのイメージ";
                    panel_SaleImage.Visible = true;

                    // 品名
                    this.tEdit_GoodsName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Value.ToString().Trim();

                    // 商品コメント
                    this.tEdit_GoodsComment.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value.ToString().Trim();

                    // 部品イメージ
                    Byte[] dats = new byte[0];
                    if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Length != 0)
                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                    if (dats.Length != 0)
                    {
                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;
                        if (dats != null)
                        {
                            // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                            //Bitmap bmp = new Bitmap(im);
                            //im.Dispose();
                            ////ms.Close();

                            //this.pictureBox_GoodsImage.Image = bmp;
                            //bmp.Dispose();

                            using (MemoryStream ms = new MemoryStream(dats))
                            {
                                using (Image img = Image.FromStream(ms, false, false))
                                {
                                    Bitmap bmp = new Bitmap(img);
                                    this.pictureBox_GoodsImage.Image = bmp;
                                }
                            }
                            // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<
                        }
                    }
                    else
                    {
                        this.pictureBox_GoodsImage.Image = null;
                    }

                    // お買得商品ｸﾞﾙｰﾌﾟ
                    if (int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString()) == 0)
                    {
                        this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;
                        this.uLabel_BrgnGoodsGrpName.Text = string.Empty;
                    }
                    else
                    {
                        this.tEdit_BrgnGoodsGrpCode.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString();
                        this.uLabel_BrgnGoodsGrpName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();
                    }

                    // 表示区分
                    if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text == "0")
                    {
                        this.uCheckEditor_DisplayDivCode.Checked = false;
                        // --- ADD 2015/03/16 Y.Wakita 障害 ---------->>>>>
                        // 項目非活性
                        this.tEdit_BrgnGoodsGrpCode.Enabled = false;
                        this.uButton_BrgnGoodsGrpCodeGuide.Enabled = false;
                        this.tNedit_UnitCalcRate.Enabled = false;
                        this.tNedit_UnitPrice.Enabled = false;
                        // --- ADD 2015/03/16 Y.Wakita 障害 ----------<<<<<
                    }
                    else
                    {
                        this.uCheckEditor_DisplayDivCode.Checked = true;
                        // --- ADD 2015/03/16 Y.Wakita 障害 ---------->>>>>
                        // 項目活性
                        this.tEdit_BrgnGoodsGrpCode.Enabled = true;
                        this.uButton_BrgnGoodsGrpCodeGuide.Enabled = true;
                        this.tNedit_UnitCalcRate.Enabled = true;
                        this.tNedit_UnitPrice.Enabled = true;
                        // --- ADD 2015/03/16 Y.Wakita 障害 ----------<<<<<
                    }

                    // 公開開始日
                    string date_St = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
                    if (date_St == string.Empty)
                        this.tDateEdit_ApplyStaDate.LongDate = 0;
                    else
                        this.tDateEdit_ApplyStaDate.LongDate = int.Parse(date_St.Replace("/", ""));

                    // 公開終了日
                    string date_Ed = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();
                    if (date_Ed == string.Empty)
                        this.tDateEdit_ApplyEndDate.LongDate = 0;
                    else
                        this.tDateEdit_ApplyEndDate.LongDate = int.Parse(date_Ed.Replace("/", ""));

                    this.DispApplyDate(date_St, date_Ed);

                    // メーカー希望小売価格
                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                    this.uLabel_MkrSuggestRtPric.Text = "￥" + makerPrice.ToString("#,###");
                    this.uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                    // 単価算出掛率
                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                    this.tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                    // 単価
                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                    this.tNedit_UnitPrice.Text = unitPrice.ToString("#,###");

                    // 得意先別設定
                    string recBgnCust = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value.ToString();
                    if (recBgnCust == string.Empty)
                        this.uLabel_RecBgnCust.Visible = false;
                    else
                        this.uLabel_RecBgnCust.Visible = true;
                }
            }
            finally
            {
                this.uCheckEditor_DisplayDivCode.CheckedChanged += new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);
            }
        
        }

        /// <summary>
        /// 明細情報プレビュー表示
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/28</br>
        /// </remarks>
        public void PreviewColumnSync(int rowIndex, string columnKeyName)
        {
            try
            {
                this.uCheckEditor_DisplayDivCode.CheckedChanged -= new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);

                // --- DEL 2015/03/24 Y.Wakita ---------->>>>>
                //// ツール（明細入力⇔ｲﾒｰｼﾞ入力ボタン）設定
                //this._detailInput.tToolbarsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = false;
                // --- DEL 2015/03/24 Y.Wakita ----------<<<<<

                if (rowIndex >= 0 && rowIndex < this._detailInput.uGrid_Details.Rows.Count)
                {
                    //if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString().Trim() != string.Empty)
                    //{
                        // --- DEL 2015/03/24 Y.Wakita ---------->>>>>
                        //// ツール（明細入力⇔ｲﾒｰｼﾞ入力ボタン）設定
                        //this._detailInput.tToolbarsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = true;
                        ////this._detailInput.uButton_Move.Enabled = true;
                        // --- DEL 2015/03/24 Y.Wakita ----------<<<<<

                        int rowNo = rowIndex + 1;
                        uExGroupBox_Image.Text = "№" + rowNo.ToString() + "　得意先でのイメージ";
                        panel_SaleImage.Visible = true;

                        switch (columnKeyName)
                        {
                            // 品番
                            case "GoodsNo":
                                {
                                    // 品名
                                    this.tEdit_GoodsName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Value.ToString().Trim();
                                    // 商品コメント
                                    this.tEdit_GoodsComment.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value.ToString().Trim();
                                    
                                    #region 部品イメージ処理

                                    Byte[] dats = new byte[0];
                                    if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Length != 0)
                                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                                    if (dats.Length != 0)
                                    {
                                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;
                                        if (dats != null)
                                        {
                                            using (MemoryStream ms = new MemoryStream(dats))
                                            {
                                                using (Image img = Image.FromStream(ms, false, false))
                                                {
                                                    Bitmap bmp = new Bitmap(img);
                                                    this.pictureBox_GoodsImage.Image = bmp;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.pictureBox_GoodsImage.Image = null;
                                    }
                                    #endregion

                                    string brgnGoodsGrpCode = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString();
                                    string brgnGoodsGrpName = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();
                                    if (int.Parse(brgnGoodsGrpCode) == 0)
                                    {
                                        this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;
                                        this.uLabel_BrgnGoodsGrpName.Text = string.Empty;
                                    }
                                    else
                                    {
                                        this.tEdit_BrgnGoodsGrpCode.Text = brgnGoodsGrpCode;
                                        this.uLabel_BrgnGoodsGrpName.Text = brgnGoodsGrpName;
                                    }
                                    
                        			// --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                                    #region 売価率処理
                                    // メーカー希望小売価格
                                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    uLabel_MkrSuggestRtPric.Text = "￥" + makerPrice.ToString("#,###");
                                    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    // 単価算出掛率
                                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                                    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    // 単価
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    #endregion
                        			// --- ADD 2015/03/24 Y.Wakita ----------<<<<<

                                    break;
                                }
                        	// --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                            // メーカー
                            case "GoodsMakerCode":
                                {
                                    #region 売価率処理
                                    // メーカー希望小売価格
                                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    uLabel_MkrSuggestRtPric.Text = "￥" + makerPrice.ToString("#,###");
                                    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    // 単価算出掛率
                                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                                    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    // 単価
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    #endregion

                                    break;
                                }
                        	// --- ADD 2015/03/24 Y.Wakita ----------<<<<<
                            // 品名
                            case "GoodsName":
                                {
                                    this.tEdit_GoodsName.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value.ToString().Trim();
                                    break;
                                }
                            // 商品コメント
                            case "GoodsComment": 
                                {
                                    this.tEdit_GoodsComment.Text = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value.ToString().Trim();
                                    break;
                                }
                            // 部品イメージ
                            case "GoodsImage":
                                {
                                    #region 部品イメージ処理

                                    Byte[] dats = new byte[0];
                                    if (this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value.ToString().Length != 0)
                                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value;

                                    if (dats.Length != 0)
                                    {
                                        dats = (Byte[])this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value;
                                        if (dats != null)
                                        {
                                            // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                                            //Bitmap bmp = new Bitmap(im);
                                            //im.Dispose();
                                            ////ms.Close();

                                            //this.pictureBox_GoodsImage.Image = bmp;
                                            //bmp.Dispose();

                                            using (MemoryStream ms = new MemoryStream(dats))
                                            {
                                                using (Image img = Image.FromStream(ms, false, false))
                                                {
                                                    Bitmap bmp = new Bitmap(img);
                                                    this.pictureBox_GoodsImage.Image = bmp;
                                                }
                                            }
                                            // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<
                                        }
                                    }
                                    else
                                    {
                                        this.pictureBox_GoodsImage.Image = null;
                                    }
                                    break;

                                    #endregion
                                }
                            // お買得商品ｸﾞﾙｰﾌﾟ
                            case "BrgnGoodsGrpCode":
                                {
                                    #region お買得商品ｸﾞﾙｰﾌﾟ処理
                                    // お買得商品ｸﾞﾙｰﾌﾟ・お買得商品ｸﾞﾙｰﾌﾟ名
                                    string brgnGoodsGrpCode = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString();
                                    string brgnGoodsGrpName = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();
                                    if (int.Parse(brgnGoodsGrpCode) == 0)
                                    {
                                        this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;
                                        this.uLabel_BrgnGoodsGrpName.Text = string.Empty;
                                    }
                                    else
                                    {
                                        this.tEdit_BrgnGoodsGrpCode.Text = brgnGoodsGrpCode;
                                        this.uLabel_BrgnGoodsGrpName.Text = brgnGoodsGrpName;
                                    }
                                    break;
                                    #endregion
                                }
                            // 表示区分
                            case "DisplayDivCode":
                                {
                                    #region  表示区分処理
                                    bool isChecked = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Text == "0" ? false: true;
                                    this.uCheckEditor_DisplayDivCode.Checked = isChecked;

                                    // --- ADD 2015/03/16 Y.Wakita 障害 ---------->>>>>
                                    if (isChecked)
                                    {
                                        // 項目活性
                                        this.tEdit_BrgnGoodsGrpCode.Enabled = true;
                                        this.uButton_BrgnGoodsGrpCodeGuide.Enabled = true;
                                        this.tNedit_UnitCalcRate.Enabled = true;
                                        this.tNedit_UnitPrice.Enabled = true;
                                    }
                                    else
                                    {
                                        // 項目非活性
                                        this.tEdit_BrgnGoodsGrpCode.Enabled = false;
                                        this.uButton_BrgnGoodsGrpCodeGuide.Enabled = false;
                                        this.tNedit_UnitCalcRate.Enabled = false;
                                        this.tNedit_UnitPrice.Enabled = false;
                                    }
                                    // --- ADD 2015/03/16 Y.Wakita 障害 ----------<<<<<

                                    // お買得商品ｸﾞﾙｰﾌﾟ・お買得商品ｸﾞﾙｰﾌﾟ名
                                    string brgnGoodsGrpCode = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString();
                                    string brgnGoodsGrpName = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value.ToString();

                                    // --- DEL 2015/03/16 Y.Wakita 要望 ---------->>>>>
                                    //if (isChecked)
                                    //{
                                    //    // 商品グループ
                                    //    if (int.Parse(brgnGoodsGrpCode) == 0)
                                    //    {
                                    //        this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;
                                    //        this.uLabel_BrgnGoodsGrpName.Text = string.Empty;
                                    //    }
                                    //    else
                                    //    {
                                    //        this.tEdit_BrgnGoodsGrpCode.Text = brgnGoodsGrpCode;
                                    //        this.uLabel_BrgnGoodsGrpName.Text = brgnGoodsGrpName;
                                    //    }

                                    //    // メーカー希望小売価格
                                    //    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    //    uLabel_MkrSuggestRtPric.Text = "￥" + makerPrice.ToString("#,###");
                                    //    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    //    // 単価算出掛率
                                    //    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                                    //    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    //    // 単価
                                    //    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    //    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    //}
                                    //else
                                    //{
                                    //    this.tEdit_BrgnGoodsGrpCode.Text = string.Empty;    // 商品ｸﾞﾙｰﾌﾟ
                                    //    this.uLabel_BrgnGoodsGrpName.Text = string.Empty;   // 商品ｸﾞﾙｰﾌﾟ名
                                    //    uLabel_MkrSuggestRtPric.Text = string.Empty;        // メーカー希望小売価格
                                    //    tNedit_UnitCalcRate.Text = string.Empty;            // 単価算出掛率
                                    //    tNedit_UnitPrice.Text = string.Empty;               // 単価
                                    //}
                                    // --- DEL 2015/03/16 Y.Wakita 要望 ----------<<<<<
                                    break;
                                    #endregion
                                }
                            // 公開開始日・終了日
                            case "ApplyStaDate":
                            case "ApplyEndDate":
                                {
                                    #region 公開開始・終了日処理

                                    // 公開開始日
                                    string date_St = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
                                    if (date_St == string.Empty)
                                        this.tDateEdit_ApplyStaDate.LongDate = 0;
                                    else
                                        this.tDateEdit_ApplyStaDate.LongDate = int.Parse(date_St.Replace("/", ""));

                                    // 公開終了日
                                    string date_Ed = this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();
                                    if (date_Ed == string.Empty)
                                        this.tDateEdit_ApplyEndDate.LongDate = 0;
                                    else
                                        this.tDateEdit_ApplyEndDate.LongDate = int.Parse(date_Ed.Replace("/", ""));

                                    this.DispApplyDate(date_St, date_Ed);

                                    // メーカー希望小売価格
                                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    uLabel_MkrSuggestRtPric.Text = "￥" + makerPrice.ToString("#,###");
                                    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    // 単価算出掛率
                                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value;
                                    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    // 単価
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");

                                    break;

                                    #endregion
                                }
                            // 単価算出掛率
                            case "UnitCalcRate":
                                {
                                    #region 売価率処理
                                    // メーカー希望小売価格
                                    long makerPrice = (Int64)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value;
                                    uLabel_MkrSuggestRtPric.Text = "￥" + makerPrice.ToString("#,###");
                                    uLabel_MkrSuggestRtPric2.Text = makerPrice.ToString("#,###");

                                    // 単価算出掛率
                                    double unitCalcRate = (Double)this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value;
                                    tNedit_UnitCalcRate.Text = unitCalcRate.ToString("###.##");

                                    // 単価
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    break;
                                    #endregion
                                }
                            // 単価
                            case "UnitPrice":
                                {
                                    long unitPrice = int.Parse(this._detailInput.uGrid_Details.Rows[rowIndex].Cells[columnKeyName].Value.ToString());
                                    tNedit_UnitPrice.Text = unitPrice.ToString("#,###");
                                    break;
                                }
                            // 得意先別設定
                            case "RecBgnCust":
                                {
                                    uLabel_RecBgnCust.Visible = true;
                                    break;
                                }
                        }
                    //}
                }
            }
            finally
            {
                this.uCheckEditor_DisplayDivCode.CheckedChanged += new EventHandler(this.uCheckEditor_DisplayDivCode_CheckedChanged);
            }
        }

        ///// <summary>
        ///// Clickイベント
        ///// </summary>
        private void uButton_FolderOpen_Click(object sender, EventArgs e)
        {
            Byte[] dats = new byte[0];

            this.OpenGoodsImgFile(out dats);

            if (dats != null)
            {
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ---------->>>>>
                //MemoryStream ms = new MemoryStream(dats);
                //Bitmap bmp = new Bitmap(ms);
                ////ms.Close();

                //this.setGoodsImage(bmp, dats);
                //bmp.Dispose();

                using (MemoryStream ms = new MemoryStream(dats))
                {
                    using (Image img = Image.FromStream(ms, false, false))
                    {
                        Bitmap bmp = new Bitmap(img);
                        this.setGoodsImage(bmp, dats);
                    }
                }
                // --- UPD 2015/03/03 Y.Wakita Redmine#304 ----------<<<<<
            }
        }

        ///// <summary>
        ///// DragDropイベント
        ///// </summary>
        private void pictureBox_GoodsImage_DragDrop(object sender, DragEventArgs e)
        {
            string filename = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

            string msg = string.Empty;
            Bitmap bmp = null;
            Byte[] dats = new Byte[0];
            bool status = this.DatsFromBitmap(filename, out bmp, out dats, out msg);
            if (status)
            {
                // 画像設定
                this.setGoodsImage(bmp, dats);
                //bmp.Dispose();
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    msg,
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        ///// <summary>
        ///// DragEnterイベント
        ///// </summary>
        private void pictureBox_GoodsImage_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        ///// <summary>
        ///// 商品イメージ設定処理
        ///// </summary>
        private void setGoodsImage(Bitmap bmp, Byte[] dats)
        {
            this.pictureBox_GoodsImage.Image = bmp;

            int rowIndex = this._detailInput.RowIndex;
            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageColumn.ColumnName].Value = dats;
            this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value = "有";
        }

        ///// <summary>
        ///// 商品コメントKeyDownイベント
        ///// </summary>
        private void tEdit_GoodsComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && (e.KeyCode == Keys.Enter))
            {
                e.Handled = true;
                this.tEdit_GoodsComment.Text += System.Environment.NewLine;
                this.tEdit_GoodsComment.SelectionStart = tEdit_GoodsComment.Text.Length;
            }
        }

        /// <summary>
        /// おすすめ運用ご紹介ボタン
        /// </summary>
        private void uButton_HelpGuide_Click(object sender, EventArgs e)
        {
            string sPath = Path.Combine(_NSDirectory, PDF_HELP_FILE);
            if (!File.Exists(sPath))
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_INFO
                             , this.Name
                             , "ヘルプファイルが存在しません。"
                             , 0
                             , MessageBoxButtons.OK);
                return;
            }
            System.Diagnostics.Process.Start(sPath);
        }

        /// <summary>
        /// 拠点チェック処理
        /// </summary>
        public bool SectionCheck(string sectionCode)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recBgnGdsAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                //拠点クリア
                this.tNedit_SectionCodeAllowZero.Clear();
                this.uLabel_SectionName.Text = "";

                this._prevSectionCd = "";
                if (sectionCode != "")
                {
                    sectionCode = sectionCode.PadLeft(2, '0');
                }
                if (sectionCode == ALL_SECTION_CODE)
                {
                    this._prevSectionCd = sectionCode;
                    this.tNedit_SectionCodeAllowZero.Text = sectionCode;
                    this.uLabel_SectionName.Text = ALL_SECTION_NAME;
                }
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

        /// <summary>
        /// 日付編集処理
        /// </summary>
        private string DateFormat(string date)
        {
            string dateWk = string.Empty;

            if (date != string.Empty)
            {
                string year = date.Substring(0, 4);
                string month = date.Substring(4, 2);
                string day = date.Substring(6, 2);

                dateWk = year + "/" + month + "/" + day;
            }
            return dateWk; 
        }

        /// <summary>
        /// 公開範囲のイメージ表示用
        /// </summary>
        private void DispApplyDate(string date_St, string date_Ed)
        {
            if (date_St != string.Empty && date_Ed != string.Empty)
            {
                date_St = DateTime.Parse(date_St).ToString("yyyy/M/d");
                date_Ed = DateTime.Parse(date_Ed).ToString("yyyy/M/d");
                if (date_St.Substring(1, 4) == date_Ed.Substring(1, 4))
                {
                    date_Ed = date_Ed.Substring(5);
                }
                this.uLabel_ApplyDate.Text = date_St + "～" + date_Ed + "まで";
            }
            else
            {
                this.uLabel_ApplyDate.Text = string.Empty;
            }
        }

        #region お買得商品グループガイド
        /// <summary>
        /// お買得商品グループガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : お買得商品グループガイドボタン</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uButton_BrgnGoodsGrpCodeGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int customerCode = 0;

                PMREC09030UA recBgnGrpSearchForm = new PMREC09030UA(PMREC09030UA.GUIDETYPE_NORMAL, customerCode, new ArrayList(this._recBgnGdsAcs.CustomerSearchRetList));
                recBgnGrpSearchForm.RecBgnGrpSelect += new PMREC09030UA.RecBgnGrpSelectEventHandler(this.RecBgnGrpSearchForm_RecBgnGrpSelect);
                recBgnGrpSearchForm.ShowDialog(this);

                if (this._recBgnGrpRet != null)
                {
                    string errMsg = string.Empty;

                    // 値が存在の場合
                    if (this._recBgnGdsAcs.CheckRecBgnGrp(this._recBgnGrpRet.InqOriginalEpCd, this._recBgnGrpRet.InqOriginalSecCd, this._recBgnGrpRet.BrgnGoodsGrpCode, false, out errMsg))
                    {
                        // 結果セット
                        this.tEdit_BrgnGoodsGrpCode.Text = this._recBgnGrpRet.BrgnGoodsGrpCode.ToString().PadLeft(4, '0');
                        this.uLabel_BrgnGoodsGrpName.Text = this._recBgnGrpRet.BrgnGoodsGrpTitle;

                        this._recBgnGrpRet = null;

                        if (sender != null)
                        {
                            this.uCheckEditor_DisplayDivCode.Focus();
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

                        // お買得商品グループのクリア
                        this.tEdit_BrgnGoodsGrpCode.Clear();
                        this.uLabel_BrgnGoodsGrpName.Text=string.Empty;
                    }

                    int rowIndex = this._detailInput.RowIndex;
                    if (this.tEdit_BrgnGoodsGrpCode.Text != string.Empty)
                    {
                        // お買得商品ｸﾞﾙｰﾌﾟ
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this.tEdit_BrgnGoodsGrpCode.Text.Trim();
                        // お買得商品ｸﾞﾙｰﾌﾟ名
                        this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = this.uLabel_BrgnGoodsGrpName.Text.Trim();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// お買得商品グループ選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">お買得商品グループ検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : お買得商品グループ選択時に発生します。</br>
        /// <br>Programmer	: 脇田 靖之</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void RecBgnGrpSearchForm_RecBgnGrpSelect(object sender, RecBgnGrpRet recBgnGrpRet)
        {
            if (recBgnGrpRet == null)
            {
                this._recBgnGrpRet = null;
                return;
            }
            this._recBgnGrpRet = recBgnGrpRet;
        }

        #endregion

        /// <summary>
        /// 公開範囲のイメージ表示用
        /// </summary>
        private void uButton_OpenRecBgnCust_Click(object sender, EventArgs e)
        {
            // 得意先個別設定画面呼び出し
            int Row = this._detailInput.RowIndex;
            this._detailInput.OpenRecBgnCustDialog(Row);
        }

        #region お買得商品ｸﾞﾙｰﾌﾟ状況照会
        /// <summary>
        /// お買得商品ｸﾞﾙｰﾌﾟ状況照会ボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : お買得商品ｸﾞﾙｰﾌﾟ状況照会ボタン</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uButton_CategoryGuide_Click(object sender, EventArgs e)
        {
                this.Cursor = Cursors.WaitCursor;
                int customerCode = 0;

                PMREC09030UA recBgnGrpSearchForm = new PMREC09030UA(PMREC09030UA.GUIDETYPE_READONLY, customerCode, new ArrayList(this._recBgnGdsAcs.CustomerSearchRetList));
                recBgnGrpSearchForm.RecBgnGrpSelect += new PMREC09030UA.RecBgnGrpSelectEventHandler(this.RecBgnGrpSearchForm_RecBgnGrpSelect);
                recBgnGrpSearchForm.ShowDialog(this);
                recBgnGrpSearchForm.Close();
        }
        #endregion

        /// <summary>
        /// ツールバーのF6の切り替え用
        /// </summary>
        private void ChangeToolsMove(int mode)
        {
            switch (mode)
            {
                case 1:

                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = true;
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Caption = "ｲﾒｰｼﾞ入力(F6)";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerCaption = "ｲﾒｰｼﾞ入力ボタン";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerDescription = "ｲﾒｰｼﾞ入力ボタン";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.ToolTipText = "イメージの項目へ移動します。";
                    break;

                case 2:

                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = true;
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Caption = "明細入力(F6)";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerCaption = "明細入力ボタン";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerDescription = "明細入力ボタン";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.ToolTipText = "明細の項目へ移動します。";
                    break;

                default:
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Enabled = false;
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.Caption = "ｲﾒｰｼﾞ入力(F6)";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerCaption = "ｲﾒｰｼﾞ入力ボタン";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.CustomizerDescription = "ｲﾒｰｼﾞ入力ボタン";
                    this.tToolsManager_MainMenu.Tools["ButtonTool_Move"].SharedProps.ToolTipText = "ｲﾒｰｼﾞの項目へ移動します。";
                    break;
            }
        }

        /// <summary>
        /// 公開区分ON/OFFイベント
        /// </summary>
        private void uCheckEditor_DisplayDivCode_CheckedChanged(object sender, EventArgs e)
        {

            int rowIndex = this._detailInput.RowIndex;

            if (this.uCheckEditor_DisplayDivCode.Checked == true)
            {
                // 項目活性
                this.tEdit_BrgnGoodsGrpCode.Enabled = true;
                this.uButton_BrgnGoodsGrpCodeGuide.Enabled = true;
                this.tNedit_UnitCalcRate.Enabled = true;
                this.tNedit_UnitPrice.Enabled = true;

                // 明細に反映
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Value = "1";
            }
            else
            {
                // 項目非活性
                this.tEdit_BrgnGoodsGrpCode.Enabled = false;
                this.uButton_BrgnGoodsGrpCodeGuide.Enabled = false;
                this.tNedit_UnitCalcRate.Enabled = false;
                this.tNedit_UnitPrice.Enabled = false;

                // 明細に反映
                this._detailInput.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Value = "0";
            }
        }

        /// <summary>
        /// 公開開始日Enterイベント
        /// </summary>
        private void tDateEdit_ApplyStaDate_Enter(object sender, EventArgs e)
        {
            if (this.tDateEdit_ApplyStaDate.LongDate == 0)
            {
                string dateNow = DateTime.Now.ToString("yyyyMMdd");
                this.tDateEdit_ApplyStaDate.LongDate = int.Parse(dateNow);
            }
        }
        /// <summary>
        /// 公開終了日Enterイベント
        /// </summary>
        private void tDateEdit_ApplyEndDate_Enter(object sender, EventArgs e)
        {
            if (this.tDateEdit_ApplyEndDate.LongDate == 0)
            {
                string dateNow = DateTime.Now.ToString("yyyyMMdd");
                this.tDateEdit_ApplyEndDate.LongDate = int.Parse(dateNow);
            }
        }
    }
}