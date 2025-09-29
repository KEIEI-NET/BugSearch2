//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 代替マスタ新旧関連表示
// プログラム概要   : 代替マスタ新旧関連の一覧表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2008/10/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2008/12/25  修正内容 : 検索元の倉庫コードが無い場合、表示しない制御を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/01/19  修正内容 : 障害対応9135（GroupBoxを削除）
//                                : 障害対応10153（メーカーガイド位置をメーカー名称の右に変更）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/03/12  修正内容 : 障害対応12308
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/03/16  修正内容 : 障害対応12343
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/22  修正内容 : MANTIS【13573】
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/07/16  修正内容 : MANTIS【13573】
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/08/04  修正内容 : MANTIS【13836】
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 代替マスタ新旧関連表示フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 代替マスタ新旧関連の一覧表示を行うフォームクラスです。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.10.27</br>
    /// <br>Update Note: 2008.12.25 30452 上野 俊治</br>
    /// <br>            ・検索元の倉庫コードが無い場合、表示しない制御を追加。</br>
    /// <br>Update Note: 2009.01.19 30452 上野 俊治</br>
    /// <br>            ・障害対応9135（GroupBoxを削除）</br>
    /// <br>            ・障害対応10153（メーカーガイド位置をメーカー名称の右に変更）</br>
    /// <br>Update Note: 2009.03.12 30414 忍 幸史</br>
    /// <br>            ・障害対応12308</br>
    /// <br>Update Note: 2009/03/16 30452 上野 俊治</br>
    /// <br>            ・障害対応12343</br>
    /// </remarks>
    public partial class PMKEN09081U : Form
    {
        #region ■private定数
        // 代替先タブ名
        private const string TABKEY_DEST = "uTabDest";
        // 代替元タブ名
        private const string TABKEY_SRC = "uTabSrc";
        #endregion

        #region ■private変数
        // 企業コード
        private string _enterpriseCode;
        // 自拠点コード
        private string _sectionCode;

        // 他機能からの遷移か
        private bool _isFromOthers = false;
        // 他機能から渡される商品情報
        private GoodsUnitData _goodsUnitData;
        // 他機能から渡される代替先か代替元かの情報(0:代替先、1:代替元)
        private int _initialSearchDiv;
        // ADD 2009/06/22 ------>>>
        // 他機能からの遷移時の初期検索終了か(true:初期検索済、false:未検索)
        private bool _firstSearchFromOthers = false;
        // ADD 2009/06/22 ------<<<
        
        // 商品ガイド
        private GoodsAcs _goodsAcs;
        // メーカーガイド
        private MakerAcs _makerAcs;
        // 代替マスタ検索アクセスクラス
        private PartsSubstUSearchAcs _partsSubstUSearchAcs;

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 代替先データテーブル
        private DataTable _destDataTable;
        // 代替先データビュー
        private DataView _destDataView;
        // 代替元データテーブル
        private DataTable _srcDataTable;
        // 代替元データビュー
        private DataView _srcDataView;

        // 変更前の品番
        private string _tmpGoodsNo;
        // 変更前のメーカーコード
        private int _tmpGoodsMakerCode;

        // 初期化処理済フラグ(初期化中のイベント制御用)
        private bool _initializeFinish;

        // 文字サイズ設定値
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };

        #endregion

        #region ■コンストラクタ
        public PMKEN09081U()
        {
            InitializeComponent();

            // ログイン情報取得
            this.GetLoginInfo();

            // ガイド初期化
            this.GetGuideInstance();
        }
        #endregion

        #region ■publicメソッド
        /// <summary>
        /// 代替マスタ新旧関連表示画面起動
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="data">対象データ</param>
        /// <param name="initialSearchDiv">0:代替先、1:代替元</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowDialog(IWin32Window owner, GoodsUnitData data, int initialSearchDiv)
        {
            if (data == null || string.IsNullOrEmpty(data.GoodsNo) || data.GoodsMakerCd == 0)
            {
                // 商品データの不足があればエラー
                return DialogResult.Cancel;
            }

            // 他画面からの起動フラグ
            this._isFromOthers = true;
            // 商品情報の保持
            this._goodsUnitData = data;
            // 表示対象の保持
            this._initialSearchDiv = initialSearchDiv;
            // ADD 2009/06/22 ------>>>
            // 他機能からの遷移時の初期検索終了フラグ
            this._firstSearchFromOthers = false;
            // ADD 2009/06/22 ------<<<

            // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (this._isFromOthers)
            {
                // コントロール初期化
                this.InitializeScreen();

                // 画面イメージ統一
                List<string> controlNameList = new List<string>();
                //controlNameList.Add(this.uExGroupBox_ExtractCondition.Name); // DEL 2009/01/19
                this._controlScreenSkin.SetExceptionCtrl(controlNameList);
                this._controlScreenSkin.LoadSkin();
                this._controlScreenSkin.SettingScreenSkin(this);

                // 他機能からの遷移の場合、検索処理を行う。
                this.SearchProc();
            }
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //DialogResult dr = base.ShowDialog(owner);

            DialogResult dr = DialogResult.OK;

            //多機能からの遷移の場合、表示データが１件もない場合には画面を表示しない。
            if (!(this._isFromOthers && _srcDataTable.Rows.Count == 0 && _destDataTable.Rows.Count == 0))
            {

                dr = base.ShowDialog(owner);

            }
            else
            {
                dr = DialogResult.Cancel;
            }
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            return dr;
        }
        #endregion

        #region ■privateメソッド

        #region 初期表示関連
        /// <summary>
        /// ログイン情報取得
        /// </summary>
        private void GetLoginInfo()
        {
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 自拠点コード
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }

        /// <summary>
        /// アクセスクラス初期化
        /// </summary>
        private void GetGuideInstance()
        {
            this._goodsAcs = new GoodsAcs();
            this._makerAcs = new MakerAcs();
            this._partsSubstUSearchAcs = new PartsSubstUSearchAcs();
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        private void InitializeScreen()
        {
            // 初期化処理中(イベント制御)
            this._initializeFinish = false;

            // ツールバーアイコン設定
            tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this.tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.tToolbarsManager1.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this.tToolbarsManager1.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

            // ガイドボタンアイコン設定
            this.SetIconImage(this.uButton_GoodsMakerCdGuide, Size16_Index.STAR1);

            // 倉庫、倉庫棚番、重複棚１、重複棚２、現在庫数クリア
            this.uLabel_WarehouseCd.Text = string.Empty;
            this.uLabel_WarehouseShelfNo.Text = string.Empty;
            this.uLabel_DuplicationShelfNo1.Text = string.Empty;
            this.uLabel_DuplicationShelfNo2.Text = string.Empty;
            this.uLabel_ShipmentPosCnt.Text = string.Empty;

            // 列幅自動調整しない
            this.AutoFillToGridColumn_CheckEditor.Checked = false;

            // 選択可能な文字サイズ設定
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.FontSize_tComboEditor.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }
            // 文字サイズの初期値は11pt (初期値設定時、カラムの自動調整を行わない)
            this.FontSize_tComboEditor.SelectedIndex = 4;
            
            if (this._isFromOthers)
            {
                // 他機能から呼ばれた場合
                // クリアボタン不可
                this.tToolbarsManager1.Tools["ButtonTool_Clear"].SharedProps.Enabled = false;

                // 入力項目は不可
                this.tEdit_GoodsNo.Enabled = false;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.uButton_GoodsMakerCdGuide.Enabled = false;

                // 渡された初期値を設定
                this.tEdit_GoodsNo.DataText = this._goodsUnitData.GoodsNo;
                this.uLabel_GoodsNm.Text = this._goodsUnitData.GoodsName;
                this.tNedit_GoodsMakerCd.SetInt(this._goodsUnitData.GoodsMakerCd);
                this.uLabel_GoodsMakerNm.Text = this._goodsUnitData.MakerName;

                this._tmpGoodsNo = this._goodsUnitData.GoodsNo;
                this._tmpGoodsMakerCode = this._goodsUnitData.GoodsMakerCd;

                // タブの初期表示設定
                if (this._initialSearchDiv == 0) this.uTab_DestSrc.Tabs[TABKEY_DEST].Selected = true;
                else this.uTab_DestSrc.Tabs[TABKEY_SRC].Selected = true;
            }
            else
            {
                // 各コントロール設定値初期化
                this.tEdit_GoodsNo.Text = string.Empty;
                this.uLabel_GoodsNm.Text = string.Empty;
                this.tNedit_GoodsMakerCd.SetInt(0);
                this.uLabel_GoodsMakerNm.Text = string.Empty;

                this._tmpGoodsNo = string.Empty;
                this._tmpGoodsMakerCode = 0;

                this.uTab_DestSrc.Tabs[TABKEY_DEST].Selected = true;

            }

            // グリッドの初期化 
            this.InitializeDataGrid();

            // 初期化処理完了
            this._initializeFinish = true;
        }

        /// <summary>
        /// ガイドボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        /// <summary>
        /// DataGrid、DataView、DataTable初期化
        /// </summary>
        private void InitializeDataGrid()
        {
            // 代替先
            this._destDataTable = new DataTable(PartsSubstUSearchAcs.TABLE_DESTPARTSSUBST);
            
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_ORDER_TITLE, typeof(Int32));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_MAKERCODE_TITLE, typeof(Int32));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE, typeof(double));

            this._destDataView = new DataView(_destDataTable);
            this.uGrid_Dest.DataSource = this._destDataView;

            // 代替元
            this._srcDataTable = new DataTable(PartsSubstUSearchAcs.TABLE_SRCPARTSSUBST);

            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_MAKERCODE_TITLE, typeof(Int32));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE, typeof(double));
            
            this._srcDataView = new DataView(_srcDataTable);
            this.uGrid_Src.DataSource = this._srcDataView;

            // グリッド列の設定
            this.InitializeGridColumns();
        }

        /// <summary>
        /// グリッド列の初期化(外観設定)
        /// </summary>
        /// <param name="Columns"></param>
        private void InitializeGridColumns()
        {
            #region 代替先Grid
            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.uGrid_Dest.DisplayLayout.Bands[0].Columns;

            // 表示位置初期値
            int visiblePosition = 1;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                //非表示設定
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            // 表示順位 フォーマット：数値
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Header.Caption = "表示順位";
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Header.VisiblePosition = visiblePosition++;

            // 代替先品番 フォーマット：文字列
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Width = 200;
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Header.Caption = "代替先品番";
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Header.VisiblePosition = visiblePosition++;

            // メーカー フォーマット：数値 4桁0詰め
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Format = "0000";
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.Caption = "メーカー";
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.VisiblePosition = visiblePosition++;

            // 倉庫 フォーマット：文字列（数値）4桁0詰
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Width = 65;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.Caption = "倉庫";
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.VisiblePosition = visiblePosition++;

            // 倉庫棚番 フォーマット：文字列（数値）
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.Caption = "倉庫棚番";
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.VisiblePosition = visiblePosition++;

            // 重複棚1 フォーマット：文字列（数値）
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.Caption = "重複棚１";
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.VisiblePosition = visiblePosition++;

            // 重複棚2 フォーマット：文字列（数値）
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.Caption = "重複棚２";
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.VisiblePosition = visiblePosition++;

            // 現在庫数 フォーマット：数値(ZZZ,ZZ9.99)
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Format = "#,##0.00";
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.Caption = "現在庫数";
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.VisiblePosition = visiblePosition++;

            #endregion

            #region 代替元Grid
            Infragistics.Win.UltraWinGrid.ColumnsCollection columns_src = this.uGrid_Src.DisplayLayout.Bands[0].Columns;

            // 表示位置初期値
            visiblePosition = 1;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column_src in columns_src)
            {
                //非表示設定
                column_src.Hidden = true;
                column_src.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                column_src.AutoEdit = false;
                column_src.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            // 代替元品番 フォーマット：文字列
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Width = 200;
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Header.Caption = "代替元品番";
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Header.VisiblePosition = visiblePosition++;

            // メーカー フォーマット：数値 4桁0詰め
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Format = "0000";
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.Caption = "メーカー";
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.VisiblePosition = visiblePosition++;

            // 倉庫 フォーマット：文字列（数値）4桁0詰
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Width = 65;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.Caption = "倉庫";
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.VisiblePosition = visiblePosition++;

            // 倉庫棚番 フォーマット：文字列（数値）
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.Caption = "倉庫棚番";
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.VisiblePosition = visiblePosition++;

            // 重複棚1 フォーマット：文字列（数値）
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.Caption = "重複棚１";
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.VisiblePosition = visiblePosition++;

            // 重複棚2 フォーマット：文字列（数値）
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.Caption = "重複棚２";
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.VisiblePosition = visiblePosition++;

            // 現在庫数 フォーマット：数値(ZZZ,ZZ9.99)
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Format = "#,##0.00";
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.Caption = "現在庫数";
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.VisiblePosition = visiblePosition++;

            #endregion
        }

        /// <summary>
        /// カラムサイズ調整
        /// </summary>
        private void ColumnPerformAutoResize()
        {
            // 初期化が完了していない場合はカラム幅調整を行わない
            if (this._initializeFinish)
            {
                if (!this.AutoFillToGridColumn_CheckEditor.Checked)
                {
                    for (int i = 0; i < this.uGrid_Dest.DisplayLayout.Bands[0].Columns.Count; i++)
                    {
                        this.uGrid_Dest.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
                    }

                    for (int j = 0; j < this.uGrid_Src.DisplayLayout.Bands[0].Columns.Count; j++)
                    {
                        this.uGrid_Src.DisplayLayout.Bands[0].Columns[j].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
                    }
                }
            }
        }

        #endregion

        #region 商品情報取得関連
        // --- ADD 2009/03/16 -------------------------------->>>>>
        /// <summary>
        /// 商品情報取得(メーカー条件あり)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private int GetGoodsInfo(out List<GoodsUnitData> list, out string msg)
        {
            return GetGoodsInfo(out list, true, out msg);
        }
        // --- ADD 2009/03/16 --------------------------------<<<<<

        /// <summary>
        /// 商品情報取得
        /// </summary>
        /// <param name="list"></param>
        /// <param name="searchMaker">メーカーを検索条件に設定するか</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        //private int GetGoodsInfo(out List<GoodsUnitData> list, out string msg) // DEL 2009/03/16
        private int GetGoodsInfo(out List<GoodsUnitData> list, bool searchMaker, out string msg) // ADD 2009/03/16
        {
            // 品番検索
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            list = new List<GoodsUnitData>();

            // 検索品名(*を除いた文字列)
            string searchCd;

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.SectionCode = this._sectionCode;
            if (searchMaker) // ADD 2009/03/16
            {
                goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                goodsCndtn.MakerName = this.uLabel_GoodsMakerNm.Text;
            }
            goodsCndtn.GoodsNo = this.tEdit_GoodsNo.DataText;
            goodsCndtn.GoodsNoSrchTyp = this.GetSearchType(this.tEdit_GoodsNo.DataText, out searchCd);

            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, true, out list, out msg);

            return status;
        }

        /// <summary>
        /// 品番検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索</returns>
        /// </remarks>
        private int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                // 前方一致のみ対応
                if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                // *が存在しないため完全一致検索
                return 0;
            }
        }

        #endregion

        #region 検索処理関連

        /// <summary>
        /// 検索処理（エラーチェックとリモート呼出し）
        /// </summary>
        private void SearchProc()
        {
            // 入力条件チェック
            if (!this.SearchBeforeCheck())
            {
                return;
            }

            // 検索処理実行
            this.ExecuteSearch();
        }

        /// <summary>
        /// 検索前入力チェック処理
        /// </summary>
        /// <returns></returns>
        private bool SearchBeforeCheck()
        {
            bool status = true;
            string errMsg = "";
            Control errCtl = null;

            // 必須入力チェック
            // 品番
            if (this.tEdit_GoodsNo.DataText == string.Empty)
            {
                if (this.uTab_DestSrc.SelectedTab.Key == TABKEY_DEST)
                {
                    errMsg = "代替元品番を入力してください";
                }
                else
                {
                    errMsg = "代替先品番を入力してください";
                }

                errCtl = this.tEdit_GoodsNo;
                status = false;
            }
            else if (this.tNedit_GoodsMakerCd.GetInt() == 0)
            {
                errMsg = "メーカーを入力してください";
                errCtl = this.tNedit_GoodsMakerCd;
                status = false;
            }

            if (!status)
            {
                // エラーメッセージ表示
                TMsgDisp.Show(
                                this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                errMsg,                                             // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン

                // エラーコントロールにフォーカス
                errCtl.Focus();
            }

            return status;
        }

        /// <summary>
        /// 検索処理実行
        /// </summary>
        private void ExecuteSearch()
        {
            int status;

            // 前回処理結果のクリア
            this.ClearLastResult();

            // 検索条件List作成
            ArrayList inParam = new ArrayList();

            // 企業コード
            inParam.Add(this._enterpriseCode);
            // 検索区分
            if (this.uTab_DestSrc.SelectedTab.Key.ToString() == TABKEY_DEST) inParam.Add(0);
            else inParam.Add(1);
            // 拠点コード
            inParam.Add(this._sectionCode);
            // 変換元メーカーコード
            inParam.Add(this.tNedit_GoodsMakerCd.GetInt());
            // 変換元商品番号
            inParam.Add(this.tEdit_GoodsNo.DataText);

            ArrayList outParam = new ArrayList();

            // 検索処理実行
            if (this.uTab_DestSrc.SelectedTab.Key.ToString() == TABKEY_DEST)
            {
                // 代替先検索
                status = this._partsSubstUSearchAcs.Search(inParam, ref outParam, ref this._destDataTable);

                // ADD 2009/06/22 ------>>>
                // 他機能から遷移時、代替先データが無ければ代替元を検索
                if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF ||
                     status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                     this._isFromOthers &&
                     !this._firstSearchFromOthers)
                {
                    // -- 2009/08/04 ------------------------>>>
                    uTab_DestSrc.SelectedTabChanged -= new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(uTab_DestSrc_SelectedTabChanged);
                    // -- 2009/08/04 ------------------------<<<

                    this.uTab_DestSrc.Tabs[TABKEY_SRC].Selected = true;

                    // -- 2009/08/04 ------------------------>>>
                    uTab_DestSrc.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(uTab_DestSrc_SelectedTabChanged);
                    // -- 2009/08/04 ------------------------<<<

                    this._firstSearchFromOthers = true;
                    inParam[1] = 1;
                    // 代替元検索
                    status = this._partsSubstUSearchAcs.Search(inParam, ref outParam, ref this._srcDataTable);
                }
                // ADD 2009/06/22 ------<<<
            }
            else
            {
                // 代替元検索
                status = this._partsSubstUSearchAcs.Search(inParam, ref outParam, ref this._srcDataTable);

                // ADD 2009/06/22 ------>>>
                // 他機能から遷移時、代替元データが無ければ代替先を検索
                if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF ||
                     status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                     this._isFromOthers &&
                     !this._firstSearchFromOthers)
                {
                    this.uTab_DestSrc.Tabs[TABKEY_DEST].Selected = true;
                    this._firstSearchFromOthers = true;
                    inParam[1] = 0;
                    // 代替先検索
                    status = this._partsSubstUSearchAcs.Search(inParam, ref outParam, ref this._destDataTable);
                }
                // ADD 2009/06/22 ------<<<
            }

            // 2009/08/04 ----------------------------->>>
            //他機能から遷移時の初期検索フラグをTrueにする
            if (this._isFromOthers)
            {
                this._firstSearchFromOthers = true;
            }
            // 2009/08/04 -----------------------------<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 検索元情報の設定
                if (!string.IsNullOrEmpty(outParam[0].ToString())) // ADD 2008/12/25
                {
                    this.uLabel_WarehouseCd.Text = outParam[0].ToString();
                    this.uLabel_WarehouseShelfNo.Text = outParam[1].ToString();
                    this.uLabel_DuplicationShelfNo1.Text = outParam[2].ToString();
                    this.uLabel_DuplicationShelfNo2.Text = outParam[3].ToString();
                    this.uLabel_ShipmentPosCnt.Text = ((double)outParam[4]).ToString("#,##0.00");
                }
                else
                {
                    this.uLabel_WarehouseCd.Text = string.Empty;
                    this.uLabel_WarehouseShelfNo.Text = string.Empty;
                    this.uLabel_DuplicationShelfNo1.Text = string.Empty;
                    this.uLabel_DuplicationShelfNo2.Text = string.Empty;
                    this.uLabel_ShipmentPosCnt.Text = string.Empty;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // 該当0件
                TMsgDisp.Show(
                                this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "条件に合致するデータが存在しません", 　　　// 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン
                return;
            }
            else
            {
                // エラー
                TMsgDisp.Show(
                                this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "代替マスタ新旧関連情報の取得に失敗しました",   // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン
                return;
            }
        }

        /// <summary>
        /// 前回検索結果のクリア
        /// </summary>
        private void ClearLastResult()
        {
            // 倉庫、倉庫棚番、重複棚１、重複棚２、現在庫数クリア
            this.uLabel_WarehouseCd.Text = string.Empty;
            this.uLabel_WarehouseShelfNo.Text = string.Empty;
            this.uLabel_DuplicationShelfNo1.Text = string.Empty;
            this.uLabel_DuplicationShelfNo2.Text = string.Empty;
            this.uLabel_ShipmentPosCnt.Text = string.Empty;

            // 処理結果保持テーブルの行クリア
            this._srcDataTable.Rows.Clear();
            this._destDataTable.Rows.Clear();
        }
        #endregion

        #endregion

        #region ■コントロールイベント

        #region 初期表示関連
        /// <summary>
        /// PMKEN09081U_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKEN09081U_Load(object sender, EventArgs e)
        {
            // 2007/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>
            if (!this._isFromOthers) 
            {
            // 2007/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<
                // コントロール初期化
                this.InitializeScreen();

                // 画面イメージ統一
                List<string> controlNameList = new List<string>();
                //controlNameList.Add(this.uExGroupBox_ExtractCondition.Name); // DEL 2009/01/19
                this._controlScreenSkin.SetExceptionCtrl(controlNameList);
                this._controlScreenSkin.LoadSkin();
                this._controlScreenSkin.SettingScreenSkin(this);

            } //2007/07/16

            // 2009/07/16 ShowDialogに移動>>>>>>>>>>>
            //if (this._isFromOthers)
            //{
            //    // 他機能からの遷移の場合、検索処理を行う。
            //    this.SearchProc();
            //}
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// DataGrid_InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = sender as Infragistics.Win.UltraWinGrid.UltraGrid;
            if (grid == null) return;

            // スクロールバースタイル
            e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            e.Layout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

            // 列ヘッダの表示スタイル
            e.Layout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Default;

            // セルの境界線スタイルの設定 
            e.Layout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Default;

            // 行の境界線スタイルの設定 
            e.Layout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Default;

            // データ行の追加許可
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // データ行の削除許可
            e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            // データ行の更新許可
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            // 列移動の変更
            e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.Default;

            // 固定列ヘッダ
            e.Layout.UseFixedHeaders = true;

            // セルクリック時実行アクション
            e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;

            // ヘッダクリックアクションの設定
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

            // 1行おきの外観設定
            e.Layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // 行セレクターの表示非表示
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            // 行選択設定 行選択無しモード(アクティブのみ)
            e.Layout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            e.Layout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;

            // 行フィルターの設定
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

            // テキストのレンタリング設定
            e.Layout.Override.CellAppearance.TextTrimming = Infragistics.Win.TextTrimming.Character;
        }

        /// <summary>
        /// Initial_Timer_Tickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 初期フォーカスセット
            if (!this._isFromOthers)
            {
                this.tEdit_GoodsNo.Focus();
            }
            else
            {
                // 他機能からの遷移時
                this.uTab_DestSrc.Focus();
            }
        }
        #endregion

        #region ボタン押下関連
        /// <summary>
        /// メーカーガイド押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;

            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {

                if (this._tmpGoodsMakerCode == makerUMnt.GoodsMakerCd)
                {
                    // 入力値の変更がなければ検索は行わない
                    return;
                }

                // 結果を画面に設定
                this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                this.uLabel_GoodsMakerNm.Text = makerUMnt.MakerName;

                // 設定値を保存
                this._tmpGoodsMakerCode = makerUMnt.GoodsMakerCd;

                // フォーカス制御
                this.uTab_DestSrc.Focus();
            }
            else
            {
                // 設定値を保存
                this._tmpGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                // メーカー名称をクリア
                this.uLabel_GoodsMakerNm.Text = string.Empty;
                // 前回検索結果のクリア
                this.ClearLastResult();
            }

            // 商品名が正常に取得出来ないケースがあるので商品マスタチェック
            // (異なるメーカーに存在する同商品名)
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                List<GoodsUnitData> list = new List<GoodsUnitData>();
                string msg;

                // 商品情報取得
                status = this.GetGoodsInfo(out list, out msg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    GoodsUnitData goodsUnitData = (GoodsUnitData)list[0];

                    // 結果を画面に設定
                    this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                    this.uLabel_GoodsNm.Text = goodsUnitData.GoodsName;
                    this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                    this.uLabel_GoodsMakerNm.Text = goodsUnitData.MakerName;

                    // 設定値を保存
                    this._tmpGoodsNo = goodsUnitData.GoodsNo;
                    this._tmpGoodsMakerCode = goodsUnitData.GoodsMakerCd;
                }
            }

            // 品番の入力があれば検索処理実行
            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText))
            {
                // 検索処理実行
                this.SearchProc();
            }
        }

        /// <summary>
        /// tToolbarsManager1_ToolClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了ボタン
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                // 検索ボタン
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        this.SearchProc();

                        break;
                    }
                // 取消ボタン
                case "ButtonTool_Clear":
                    {
                        // 画面の初期化
                        this.InitializeScreen();

                        this.Initial_Timer.Enabled = true;

                        break;
                    }
            }
        }
        #endregion

        #region フォーカス遷移関連
        /// <summary>
        /// ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            // 処理結果
            int status;

            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 品番
                case "tEdit_GoodsNo":
                    {
                        if (this.tEdit_GoodsNo.DataText == string.Empty)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpGoodsNo = "";
                            this.uLabel_GoodsNm.Text = string.Empty;

                            break;
                        }

                        if (this.tEdit_GoodsNo.DataText == this._tmpGoodsNo)
                        {
                            // 入力が変わっていなければ何もしない
                            break;
                        }

                        List<GoodsUnitData> list = new List<GoodsUnitData>();
                        string msg;

                        // 商品情報取得
                        //status = this.GetGoodsInfo(out list, out msg); // DEL 2009/03/16
                        status = this.GetGoodsInfo(out list, false, out msg); // ADD 2009/03/16

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            GoodsUnitData goodsUnitData = (GoodsUnitData)list[0];

                            // 結果を画面に設定
                            this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                            this.uLabel_GoodsNm.Text = goodsUnitData.GoodsName;
                            this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                            this.uLabel_GoodsMakerNm.Text = goodsUnitData.MakerName;

                            // 設定値を保存
                            this._tmpGoodsNo = goodsUnitData.GoodsNo;
                            this._tmpGoodsMakerCode = goodsUnitData.GoodsMakerCd;
                        }
                        else
                        {
                            // 設定値を保存
                            this._tmpGoodsNo = this.tEdit_GoodsNo.DataText;
                            // 品番名称をクリア
                            this.uLabel_GoodsNm.Text = "";
                            // 前回検索結果のクリア
                            this.ClearLastResult();
                        }

                        // メーカーの入力があれば検索実行
                        if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                        {
                            // 検索処理実行
                            this.SearchProc();
                        }

                        break;
                    }
                // メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        // 入力無し
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpGoodsMakerCode = 0;
                            this.uLabel_GoodsMakerNm.Text = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_GoodsMakerCd.GetInt() == this._tmpGoodsMakerCode)
                        {
                            if (e.NextCtrl == this.uButton_GoodsMakerCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.uTab_DestSrc;
                            }

                            break;
                        }

                        MakerUMnt makerUMnt;

                        status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            this.uLabel_GoodsMakerNm.Text = makerUMnt.MakerName;

                            // 設定値を保存
                            this._tmpGoodsMakerCode = makerUMnt.GoodsMakerCd;
                        }
                        else
                        {
                            // 設定値を保存
                            this._tmpGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                            // メーカー名称をクリア
                            this.uLabel_GoodsMakerNm.Text = string.Empty;
                            // 前回検索結果のクリア
                            this.ClearLastResult();
                        }

                        // 商品名が正常に取得出来ないケースがあるので商品マスタチェック
                        // (異なるメーカーに存在する同商品名)
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            List<GoodsUnitData> list = new List<GoodsUnitData>();
                            string msg;

                            // 商品情報取得
                            status = this.GetGoodsInfo(out list, out msg);

                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                GoodsUnitData goodsUnitData = (GoodsUnitData)list[0];

                                // 結果を画面に設定
                                this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                                this.uLabel_GoodsNm.Text = goodsUnitData.GoodsName;
                                this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                                this.uLabel_GoodsMakerNm.Text = goodsUnitData.MakerName;

                                // 設定値を保存
                                this._tmpGoodsNo = goodsUnitData.GoodsNo;
                                this._tmpGoodsMakerCode = goodsUnitData.GoodsMakerCd;
                            }
                        }

                        // 品番の入力があれば検索処理実行
                        if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText))
                        {
                            // 検索処理実行
                            this.SearchProc();
                        }

                        // フォーカス制御
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_GoodsMakerCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab))
                        {
                            // メーカーが存在する かつ 次がガイドボタンの場合、ガイドボタンは飛ばす
                            e.NextCtrl = this.uTab_DestSrc;
                        }

                        break;
                    }
                case "uTab_DestSrc":
                    {
                        // Shift + Tabでガイドに来るケース
                        if (e.NextCtrl == this.uButton_GoodsMakerCdGuide
                            && this.tNedit_GoodsMakerCd.GetInt() != 0
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Left))
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd;
                        }
                        break;
                    }
            }
        }
        #endregion

        #region 値変更、選択変更関連
        /// <summary>
        /// uTab_DestSrc_SelectedTabChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTab_DestSrc_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab.Key.ToString() == TABKEY_DEST)
            {
                // 品番ラベル名称変更
                this.uLabel_GoodsTitle.Text = "代替元品番";
            }
            else if (e.Tab.Key.ToString() == TABKEY_SRC)
            {
                // 品番ラベル名称変更
                this.uLabel_GoodsTitle.Text = "代替先品番";
            }

            // 入力項目あり、初期化処理済の場合検索処理実行
            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text)
                && this.tNedit_GoodsMakerCd.GetInt() != 0
                && this._initializeFinish)
            {
                // 検索処理
                this.SearchProc();
            }
        }

        /// <summary>
        /// AutoFillToGridColumn_CheckEditor_CheckedChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoFillToGridColumn_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.AutoFillToGridColumn_CheckEditor.Checked)
            {
                // 列幅をオートに設定
                this.uGrid_Dest.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                this.uGrid_Src.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Dest.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                this.uGrid_Dest.Refresh();
                this.uGrid_Src.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                this.uGrid_Src.Refresh();
            }

            // カラムサイズ調整
            this.ColumnPerformAutoResize();

        }

        /// <summary>
        /// FontSize_tComboEditor_ValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // グリッドのフォントサイズ変更
            int fontSize = Convert.ToInt32(this.FontSize_tComboEditor.Value);

            this.uGrid_Dest.DisplayLayout.Appearance.FontData.SizeInPoints = (float)fontSize;
            this.uGrid_Dest.Refresh();
            this.uGrid_Src.DisplayLayout.Appearance.FontData.SizeInPoints = (float)fontSize;
            this.uGrid_Src.Refresh();
            // カラムサイズ調整
            this.ColumnPerformAutoResize();

        }

        #endregion

        #endregion

    }
}