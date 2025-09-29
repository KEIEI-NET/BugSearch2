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
    public partial class PMREC09021UD : Form
    {

        # region Private Members

        /// <summary></summary>
        private PMREC09021UE _detailInput;
        /// <summary>イメージリスト</summary>
        private ImageList _imageList16 = null;
        /// <summary></summary>
        private ControlScreenSkin _controlScreenSkin;
        ///// <summary></summary>
        //private Control _prevControl = null;

        #region Grid関連

        /// <summary>伝票表示タブ 列サイズ自動調整値</summary>
        private bool _columnWidthAutoAdjust = false;
        /// <summary>表示：初期フォントサイズ</summary>
        private const int CT_DEF_FONT_SIZE = 10;
        /// <summary>ReadOnlyセル背景色</summary>
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        /// <summary>文字サイズ</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        /// <summary>明細データ抽出最大件数</summary>
        private const long DATA_COUNT_MAX = 20000;

        #endregion

        #region ツールバーボタン

        /// <summary>終了</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;                    // 終了ボタン
        /// <summary>確定</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;                     // 保存ボタン
        /// <summary>ガイド</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;                    // ガイドボタン

        /// <summary>終了:キー文字列</summary>
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// 終了
        /// <summary>確定:キー文字列</summary>
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// 保存
        /// <summary>ガイド:キー文字列</summary>
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// ガイド

        #endregion

        #region アクセスクラス

        /// <summary>得意先情報</summary>
        private CustomerInfoAcs _customerInfoAcs = null;
        /// <summary>お買得設定</summary>
        private RecBgnGdsAcs _recBgnGdsAcs = null;
        ///// <summary>メーカー</summary>
        //private MakerAcs _makerAcs = null;
        /// <summary>拠点</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>ユーザーガイド</summary>
        private UserGuideAcs _userGuideAcs;
        /// <summary>日付取得部品</summary>
        private DateGetAcs _dateGetAcs;

        #endregion

        /// <summary>ログイン企業コード</summary>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        /// <summary>ログイン拠点コード</summary>
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>全社設定：拠点コード</summary>
        private const string ALL_SECTION_CODE = "00";
        /// <summary>全社設定：拠点名</summary>
        private const string ALL_SECTION_NAME = "全社";

        /// <summary>得意先検索戻り値</summary>
        private CustomerSearchRet _customerSearchRet = null;

        /// <summary>拠点・問合せデータテーブル</summary>
        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;

        /// <summary>お買得商品個別設定データテーブル</summary>
        private RecBgnGdsDataSet.RecBgnCustDataTable _recBgnCustDataTable;


        #endregion

        #region Public Property

        /// <summary>
        /// お買得商品設定マスタ アクセスクラスプロパティ
        /// </summary>
        public RecBgnGdsDataSet.RecBgnCustDataTable RecBgnCustDataTable
        {
            get { return this._recBgnCustDataTable; }
        }

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
        public PMREC09021UD(RecBgnGdsCustInfo recBgnGdsCustInfo)
        {
            InitializeComponent();

            // 変数初期化
            this._recBgnCustDataTable = (RecBgnGdsDataSet.RecBgnCustDataTable)recBgnGdsCustInfo.recBgnCust.Copy();
            this._detailInput = new PMREC09021UE(recBgnGdsCustInfo);
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            //this._detailInput.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
            this._detailInput.SetGuidButton += new PMREC09021UE.SetGuidButtonEventHandler(this.SetGuidButton);

            this._recBgnGdsAcs = this._detailInput.RecBgnGdsAcs;
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._customerInfoAcs = new CustomerInfoAcs();

            // 設定読み込み
            this._detailInput.Deserialize();

        }
        #endregion

        #region イベント

        #region フォーム

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
        private void PMREC09021UD_Load(object sender, EventArgs e)
        {
            
            // Skin設定
            this._controlScreenSkin.LoadSkin();

            List<string> controlNameList = new List<string>();
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

            // グリッド
            this._detailInput.LoadSettings();

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

        }

        /// <summary>
        /// フォーム　Shownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09021UD_Shown(object sender, EventArgs e)
        {
            this._detailInput.Select();
            this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
        }

        #endregion

        #region ボタン

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
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
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
                // 確定
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                        this._detailInput.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        if (this.Save() == 0) DialogResult = DialogResult.OK;

                        break;
                    }
                // ガイド
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        this.GuideStart();
                        break;
                    }
            }
        }

        #endregion

        #region フォーカス制御

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
                                        if (this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
                                            }
                                            break;
                                        }
                                        else if (this._recBgnGdsAcs.PrevRecBgnGdsDic != null
                                              && this._recBgnGdsAcs.PrevRecBgnGdsDic.Count <= 0
                                              && this._detailInput.uGrid_Details.ActiveCell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                                        {
                                            this._detailInput.uGrid_Details.ActiveCell.Selected = false;
                                            this._detailInput.uGrid_Details.ActiveCell = null;
                                            if (this._detailInput.uGrid_Details.ActiveRow != null)
                                            {
                                                this._detailInput.uGrid_Details.ActiveRow.Selected = false;
                                                this._detailInput.uGrid_Details.ActiveRow = null;
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
                case "PMREC09021UE":
                    {
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.Name == "uButton_RowDelete"
                             || e.NextCtrl.Name == "_PMREC09021UD_Toolbars_Dock_Area_Top"
                             || e.NextCtrl.Name == "_PMREC09021UE_Toolbars_Dock_Area_Top")
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
                    case "uGrid_Details":
                        {
                            this._detailInput.SetGridGuid();
                            break;
                        }
                    case "_PMREC09021UD_Toolbars_Dock_Area_Top":
                    case "_PMREC09021UE_Toolbars_Dock_Area_Top":
                        break;
                    default:
                        SetGuidButton(false);
                        break;
                }
            }
            #endregion
        }

        #endregion 

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

                editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Width = 40;		            // №
                editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Width = 80;		        // 削除日
                editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Width = 65;		    // 得意先
                editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Width = 130;		    // 得意先名
                editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Width = 65;	    // お買得商品グループコード
                editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Width = 100;	    // お買得商品グループ名
                editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Width = 40;	        // 表示区分
                editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Width = 80;		    // 公開開始日
                editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Width = 80;		    // 公開終了日
                editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Width = 90;	    // ﾒｰｶｰ希望小売価格
                editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Width = 90;	            // 定価
                editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Width = 75;           // 単価算出掛率
                editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Width = 90;              // 売上単価
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
        /// 確定処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 確定処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private int Save()
        {

            int status = -1;

            // 登録データ取得
            RecBgnGdsDataSet.RecBgnCustDataTable recBgnCust = null;
            if (this._detailInput.CheckSaveDate(out recBgnCust))
            {
                // 返却データをセット
                this._recBgnCustDataTable = this._detailInput.GetResultRecBgnCust();
                status = 0;
            }
            
            return status;
        }

        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <returns>DialogResult</returns>
        internal new DialogResult ShowDialog()
        {
            DialogResult ret = base.ShowDialog();
            return ret;
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
            if(this._detailInput.IsUpdated())
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
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
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
            // グリッド
            int rowIndex = -1;
            RecBgnGdsDataSet.RecBgnCustRow dataRow = null;
            string keyName = this._detailInput.GetFocusColumnKey(out rowIndex, out dataRow);
            if (!string.Empty.Equals(keyName))
            {
                switch (keyName)
                {
                    case "CustomerCode":
                        {
                            this._detailInput.SetCustomerCodeGuide(rowIndex);
                            break;
                        }
                    case "BrgnGoodsGrpCode":
                        {
                            if (!dataRow.CustomerCode.Trim().Equals(string.Empty)) this._detailInput.SetGdsGrpCodeGuide(rowIndex, int.Parse(dataRow.CustomerCode.Trim()));
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        ///// <summary>
        ///// 詳細グリッド最上位行アップイベント処理
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータクラス</param>
        ///// <remarks>
        ///// <br>Note       : 詳細グリッド最上位行アプウン時に発生します。</br>      
        ///// <br>Programmer : 脇田 靖之</br>                                  
        ///// <br>Date       : 2015/02/20</br> 
        ///// </remarks> 
        //private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        //{
        //    Control control = null;

        //    if (control != null)
        //    {
        //        control.Focus();
        //    }

        //    this._prevControl = this.ActiveControl;
        //}

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

        ///// <summary>
        ///// 画面初期化の時、フォーカスを設定する。
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 画面初期化の時、フォーカスを設定する。</br>
        ///// <br>Programmer : 脇田 靖之</br>
        ///// <br>Date       : 2015/02/20</br>
        ///// </remarks>
        //public void SetInitFocus()
        //{
        //    // this.tNedit_SectionCodeAllowZero.Focus();
        //}

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

    }
}