using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 複数手形選択フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 複数の手形から選択を行う為のＵＩクラスです。</br>
    /// <br>Programmer : zhuhh</br>
    /// <br>Date       : 2013/01/10</br>
    /// </remarks>
    public partial class PMTEG09101UC : Form
    {
        #region Constructor
        /// <summary>
        /// 複数手形選択フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 複数手形選択フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        public PMTEG09101UC()
        {
            InitializeComponent();

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
        }
        #endregion

        #region Constant

        #region < グリッド列用 >
        /// <summary>抽出結果</summary>
        private const string CT_SELECT_TBL = "SelectTable";

        private const string CT_DraftNo = "DraftNo";
        private const string CT_BankAndBranchCd = "BankAndBranchCd";
        private const string CT_BankAndBranchNm = "BankAndBranchNm";
        private const string CT_DraftDrawingDate = "DraftDrawingDate";
        private const string CT_RcvDraftData = "RcvDraftData";
        private const string CT_PayDraftData = "PayDraftData";
        #endregion

        #region < ツールバーキー情報 >
        // ツールバーキー情報    
        private const string CT_TOOLBAR_DECISION_KEY = "Decision_ButtonTool";
        private const string CT_TOOLBAR_BACK_KEY = "Back_ButtonTool";
        #endregion

        #region <enum>
        private enum DraftModeDiv
        {
            rcvDraft = 0,
            payDraft = 1,
        }
        #endregion

        #region Private Members
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        /// <summary>複数受取手形選択用データテーブル</summary>
        private DataTable _selDataTable;

        /// <summary>複数受取手形選択用データビュー</summary>
        private DataView _selDataView;

        /// <summary>表示データリスト</summary>
        private List<RcvDraftData> _rcvDispDraftDataLst;

        /// <summary>選択データリスト</summary>
        private RcvDraftData _rcvDraftDataLst;

        /// <summary>表示データリスト</summary>
        private List<PayDraftData> _payDispDraftDataLst;

        /// <summary>選択データリスト</summary>
        private PayDraftData _payDraftDataLst;

        /// <summary>Mode</summary>
        private int modeFlag;

        #endregion

        #endregion

        #region Public Methods
        /// <summary>選択データリスト</summary>
        public RcvDraftData RcvDraftDataLst
        {
            get { return this._rcvDraftDataLst; }
            set { }
        }

        /// <summary>選択データリスト</summary>
        public PayDraftData PayDraftDataLst
        {
            get { return this._payDraftDataLst; }
            set { }
        }

        /// <summary>
        /// 複数手形選択ガイド起動
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="goodsUnitDataLst">手形連結データリスト</param>
        /// <returns>DialogResult</returns>
        public DialogResult SelectGoodsGuideShow(IWin32Window owner, ref List<RcvDraftData> rcvDraftData)
        {
            this.modeFlag = (int)DraftModeDiv.rcvDraft;

            this._rcvDispDraftDataLst = rcvDraftData;

            DialogResult dr = this.ShowDialog();

            return dr;
        }

        /// <summary>
        /// 複数手形選択ガイド起動
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="goodsUnitDataLst">手形連結データリスト</param>
        /// <returns>DialogResult</returns>
        public DialogResult SelectGoodsGuideShow(IWin32Window owner, ref List<PayDraftData> payDraftData)
        {
            this.modeFlag = (int)DraftModeDiv.payDraft;

            this._payDispDraftDataLst = payDraftData;
            DialogResult dr = this.ShowDialog();

            return dr;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーの初期設定を行います。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void InitializeToolbarsSetting()
        {
            // イメージリスト設定
            this.Main_UToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;


            // 確定ボタンのアイコン設定
            ButtonTool decButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_DECISION_KEY] as ButtonTool;
            if (decButton != null)
            {
                decButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            }

            // 戻るボタンのアイコン設定
            ButtonTool backButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_BACK_KEY] as ButtonTool;
            if (backButton != null)
            {
                backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            }
        }

        /// <summary>
        /// 選択用データテーブル作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataTableの設定を行います。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void CreatSelectDadaTable()
        {
            // ----------------------------------------

            // DataTableの作成
            this._selDataTable = new DataTable(CT_SELECT_TBL);
            this._selDataView = new DataView();

            // ----------------------------------------
            // DataColumnの作成

            // 手形品番
            DataColumn colDraftNo = new DataColumn(CT_DraftNo, typeof(string), "", MappingType.Element);
            colDraftNo.Caption = "手形番号";

            // 銀行／支店コード
            DataColumn colBankAndBranchCd = new DataColumn(CT_BankAndBranchCd, typeof(string), "", MappingType.Element);
            colBankAndBranchCd.Caption = "銀行／支店コード";

            // 銀行／支店名称
            DataColumn colBankAndBranchNm = new DataColumn(CT_BankAndBranchNm, typeof(string), "", MappingType.Element);
            colBankAndBranchNm.Caption = "銀行／支店名称";

            // 入金日
            DataColumn colDraftDrawingDate = new DataColumn(CT_DraftDrawingDate, typeof(string), "", MappingType.Element);
            colDraftDrawingDate.Caption = "振出日";

            // 受取手形連結データ
            DataColumn colRcvDraftData = new DataColumn(CT_RcvDraftData, typeof(RcvDraftData), "", MappingType.Element);
            colRcvDraftData.Caption = "受取手形連結データクラス格納";

            // 支払手形連結データ
            DataColumn colPayDraftData = new DataColumn(CT_PayDraftData, typeof(PayDraftData), "", MappingType.Element);
            colPayDraftData.Caption = "支払手形連結データクラス格納";

            // ----------------------------------------
            // DataTableの初期化
            this._selDataTable.Columns.AddRange(new DataColumn[] {
				colDraftNo,
                colBankAndBranchCd,
                colBankAndBranchNm,
                colDraftDrawingDate,
                colRcvDraftData,
                colPayDraftData});

            this._selDataView.Table = this._selDataTable;

        }

        /// <summary>
        /// 選択用グリッドカラム情報設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 選択用グリッドに表示するカラム情報を設定します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingSelGridColumn()
        {
            // バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.SELECTGrid.DisplayLayout.Bands[0];
            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = band.Columns;
            band.Override.DefaultRowHeight = 24;

            //---------------------------------------------------------------------
            //　テキストの表示位置
            //---------------------------------------------------------------------
            columns[CT_DraftNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[CT_DraftNo].Width = 120;

            columns[CT_BankAndBranchCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[CT_BankAndBranchCd].Width = 80;

            columns[CT_BankAndBranchNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[CT_BankAndBranchNm].Width = 120;

            columns[CT_DraftDrawingDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[CT_DraftDrawingDate].Width = 90;

            columns[CT_RcvDraftData].Hidden = true;
            columns[CT_PayDraftData].Hidden = true;
        }

        /// <summary>
        /// グリッドのセッティング描画処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド全体のセルスタイル・文字色を設定する</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingGridRowEditor()
        {
            int cnt = this.SELECTGrid.Rows.Count;

            // 描画を一時停止
            this.SELECTGrid.BeginUpdate();
            try
            {
                this.SELECTGrid.Rows[0].Selected = true;
                for (int i = 0; i < cnt; i++)
                {
                    SettingGridRowEditor(i);
                }
            }
            finally
            {
                // 描画を開始
                this.SELECTGrid.EndUpdate();
            }
        }

        /// <summary>
        /// 表示グリッド行単位でのセル描画処理
        /// </summary>
        /// <param name="row">指定行</param>
        /// <remarks>
        /// <br>Note       : グリッド全体のセルスタイル・文字色を設定する。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingGridRowEditor(int row)
        {
            // デフォルト行の前景色
            this.SELECTGrid.Rows[row].Appearance.ForeColor = Color.Black;
            this.SELECTGrid.Rows[row].Appearance.ForeColorDisabled = Color.Black;
        }

        /// <summary>
        /// 選択用テーブル作成
        /// </summary>
        /// <param name="rcvDraftDataList">受取手形連結データリスト</param>
        /// <remarks>
        /// <br>Note       : 選択用テーブルを作成します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingSelRcvDraftDataDataTable(List<RcvDraftData> rcvDraftDataList)
        {
            foreach (RcvDraftData data in rcvDraftDataList)
            {
                DataRow row = this.SetRcvDraftDataDataRow(data);

                if (row != null)
                    this._selDataTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// 選択用テーブル作成
        /// </summary>
        /// <param name="rcvDraftDataList">支払手形連結データリスト</param>
        /// <remarks>
        /// <br>Note       : 選択用テーブルを作成します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingSelPayDraftDataDataTable(List<PayDraftData> payDraftDataDataTable)
        {
            foreach (PayDraftData data in payDraftDataDataTable)
            {
                DataRow row = this.SetPayDraftDataDataRow(data);

                if (row != null)
                    this._selDataTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// 受取手形連結マスタ(rcvDraftDataList)　⇒　選択用テーブルDataRow
        /// </summary>
        /// <param name="rcvDraftDataList">手形連結マスタ</param>
        /// <remarks>
        /// <br>Note       : 選択用テーブルのDataRowを作成します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private DataRow SetRcvDraftDataDataRow(RcvDraftData rcvDraftData)
        {
            DataRow row = this._selDataTable.NewRow();

            // 手形品番
            row[CT_DraftNo] = rcvDraftData.RcvDraftNo;

            // 銀行／支店コード
            row[CT_BankAndBranchCd] = (rcvDraftData.BankAndBranchCd / 1000+"").PadLeft(4,'0') + "‐" + (rcvDraftData.BankAndBranchCd % 1000+"").PadLeft(3,'0');

            // 銀行／支店名称
            row[CT_BankAndBranchNm] = rcvDraftData.BankAndBranchNm;

            // 振出日
            row[CT_DraftDrawingDate] = rcvDraftData.DraftDrawingDate.ToString("yyyy年MM月dd日");

            //受取手形連結データクラス格納
            row[CT_RcvDraftData] = rcvDraftData.Clone();

            return row;
        }

        /// <summary>
        /// 支払手形連結マスタ(rcvDraftDataList)　⇒　選択用テーブルDataRow
        /// </summary>
        /// <param name="rcvDraftDataList">手形連結マスタ</param>
        /// <remarks>
        /// <br>Note       : 選択用テーブルのDataRowを作成します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private DataRow SetPayDraftDataDataRow(PayDraftData payDraftData)
        {
            DataRow row = this._selDataTable.NewRow();

            // 手形品番
            row[CT_DraftNo] = payDraftData.PayDraftNo;

            // 銀行／支店コード
            row[CT_BankAndBranchCd] = (payDraftData.BankAndBranchCd / 1000+"").PadLeft(4,'0') + "‐" + (payDraftData.BankAndBranchCd % 1000+"").PadLeft(3,'0');
          
            // 銀行／支店名称
            row[CT_BankAndBranchNm] = payDraftData.BankAndBranchNm;

            // 振出日
            row[CT_DraftDrawingDate] = payDraftData.DraftDrawingDate.ToString("yyyy年MM月dd日");

            //支払手形連結データクラス格納
            row[CT_PayDraftData] = payDraftData.Clone();

            return row;
        }

        #endregion

        #region Control Event
        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMTEG09101UC_Load(object sender, EventArgs e)
        {
            try
            {
                // ツールバー初期設定 
                this.InitializeToolbarsSetting();

                // データテーブルの作成
                this.CreatSelectDadaTable();

                // データソース設定
                this.SELECTGrid.DataSource = this._selDataView;

                // データリストから表示用のデータテーブル作成
                if (this.modeFlag == (int)DraftModeDiv.rcvDraft)
                {
                    this.SettingSelRcvDraftDataDataTable(this._rcvDispDraftDataLst);
                }
                else
                {
                    this.SettingSelPayDraftDataDataTable(this._payDispDraftDataLst);
                }

                // データ再設定
                this.SELECTGrid.DataBind();

                // グリッドの描画
                this.SettingGridRowEditor();

            }
            catch (Exception ex)
            {
                // メッセージ表示
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,      // エラーレベル
                    this.GetType().ToString(),            // アセンブリＩＤまたはクラスＩＤ
                    this.Text,                            // プログラム名称
                    "Load",                               // 処理名称
                    "",                                   // オペレーション
                    ex.Message,                           // 表示するメッセージ
                    -1,                                   // ステータス値
                    null,                                 // エラーが発生したオブジェクト
                    MessageBoxButtons.OK,                 // 表示するボタン
                    MessageBoxDefaultButton.Button1);     // 初期表示ボタン
            }
            finally
            {
            }
        }

        /// <summary>
        /// グリッドレイアウト初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SELECTGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            // スクロールバースタイル
            e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Deferred;

            // 列の自動サイ調整
            e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            // 列ヘッダの表示スタイル
            e.Layout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Default;

            // データ行の追加許可
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // データ行の削除許可
            e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            // データ行の更新許可
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            // 列移動の変更
            e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // 固定列ヘッダ
            e.Layout.UseFixedHeaders = false;
            // セルクリック時実行アクション
            e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            // 行選択時は、全ての列の文字色は黒とする(この記述ないと白色になって見難いとの批判があったため。)
            e.Layout.Override.SelectedRowAppearance.ForeColor = Color.Black;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.ListIndex;

            this.SettingSelGridColumn();
        }



        /// <summary>
        /// 
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void Main_UToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case CT_TOOLBAR_DECISION_KEY:
                    {
                        // データ選択                        
                        if (this.SELECTGrid.ActiveRow == null) return;

                        if (modeFlag == (int)DraftModeDiv.rcvDraft)
                        {
                            RcvDraftData rcvDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_RcvDraftData].Value != DBNull.Value) ? (RcvDraftData)this.SELECTGrid.ActiveRow.Cells[CT_RcvDraftData].Value : null;
                            if (rcvDraftData != null)
                            {
                                this._rcvDraftDataLst = rcvDraftData.Clone();

                                this.DialogResult = DialogResult.OK;
                            }
                        }
                        else
                        {
                            PayDraftData payDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value != DBNull.Value) ? (PayDraftData)this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value : null;
                            if (payDraftData != null)
                            {
                                this._payDraftDataLst = payDraftData.Clone();

                                this.DialogResult = DialogResult.OK;
                            }
                        }

                        break;
                    }
                case CT_TOOLBAR_BACK_KEY:
                    {
                        this.DialogResult = DialogResult.Cancel;

                        break;
                    }
            }
        }

        /// <summary>
        /// グリッドだ物クリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : 一覧グリッドがダブルクリックされた際に発生します。</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SELECTGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow = targetGrid.ActiveRow;

            if (objRow != null)
            {
                // 商品連結データクラス格納
                if (modeFlag == (int)DraftModeDiv.rcvDraft)
                {
                    RcvDraftData rcvDraftData = (objRow.Cells[CT_RcvDraftData].Value != DBNull.Value) ? (RcvDraftData)objRow.Cells[CT_RcvDraftData].Value : null;

                    if (rcvDraftData != null)
                    {

                        this._rcvDraftDataLst = rcvDraftData.Clone();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    PayDraftData payDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value != DBNull.Value) ? (PayDraftData)this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value : null;
                    if (payDraftData != null)
                    {
                        this._payDraftDataLst = payDraftData.Clone();

                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : zhuhh</br>
        /// <br>Date        : 2013/01/10</br>
        /// </remarks>
        private void SELECTGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.SELECTGrid.ActiveRow == null) return;
                if (modeFlag == (int)DraftModeDiv.rcvDraft)
                {
                    RcvDraftData rcvDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_RcvDraftData].Value != DBNull.Value) ? (RcvDraftData)this.SELECTGrid.ActiveRow.Cells[CT_RcvDraftData].Value : null;
                    if (rcvDraftData != null)
                    {
                        this._rcvDraftDataLst = rcvDraftData.Clone();

                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    PayDraftData payDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value != DBNull.Value) ? (PayDraftData)this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value : null;
                    if (payDraftData != null)
                    {
                        this._payDraftDataLst = payDraftData.Clone();

                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
        #endregion
    }
}