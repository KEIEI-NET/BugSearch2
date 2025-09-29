using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 詳細部(選択ボタン、グリッド)制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 選択ボタン、明細グリッドの制御を行うクラスです。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/11/10</br>
    /// <br>UpdateNote : 2009/01/13 照田 貴志　不具合対応[9872]</br>
    /// <br>           : 2009/01/21 照田 貴志　不具合対応[9876]</br>
    /// <br></br>
    /// <br>UpdateNote : 2012/07/13 30517 夏野 駿希</br>
    /// <br>             仕入原価を小数点以下表示可能に修正</br>
    /// </remarks>
	public partial class PMUOE04201UB : UserControl
	{
        #region ■定数、変数、構造体
        private const string FILENAME_COLDISPLAYSTATUS = "PMUOE04201U_ColSetting.DAT";	// 列表示状態セッティングXMLファイル名
        private readonly Color SELECTED_BACKCOLOR = Color.FromArgb(216, 235, 253);      // 選択時背景色1
        private readonly Color SELECTED_BACKCOLOR2 = Color.FromArgb(101, 144, 218);     // 選択時背景色2
        private readonly Color ACTIVEROW_BACKCOLOR = Color.FromArgb(251, 230, 148);     // 行アクティブ時背景色1
        private readonly Color ACTIVEROW_BACKCOLOR2 = Color.FromArgb(238, 149, 21);     // 行アクティブ時背景色2

        private ControlScreenSkin _controlScreenSkin = null;            // 画面デザイン変更クラス
        private PMUOE04203AA _uoeReplyIndicateAcs = null;               // UOE回答表示アクセスクラス
        private ColDisplayStatusList _colDisplayStatusList = null;      // 列表示コレクションクラス
        #endregion

        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="UOEReplyIndicateAcs">アクセスクラス</param>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04201UB(PMUOE04203AA uoeReplyIndicateAcs)
        {
            InitializeComponent();

            // 画面デザイン変更クラスインスタンス化
            this._controlScreenSkin = new ControlScreenSkin();

            // 列定義
            this._uoeReplyIndicateAcs = uoeReplyIndicateAcs;
            this.uGrid_Details.DataSource = this._uoeReplyIndicateAcs.UOEReplyDataSet.Tables[PMUOE04202EA.ct_Tbl_UOEReply];

            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(FILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList);
        }
        #endregion ■Constructor - end

        #region ■イベント
        #region ▼PMUOE04201UB_Load(ロード時)
        /// <summary>
        /// コントロールロード イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドの初期設定を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void PMUOE04201UB_Load(object sender, EventArgs e)
        {
            // グリッド列設定
            this.GridInitialSetting();

            // 明細使用可/不可設定
            this.SetGridEnable();
        }
        #endregion

        #region ▼Select_Button_Click(全て選択/解除ボタンクリック時)
        /// <summary>
        /// 全て選択/解除ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 全て選択/解除ボタンがクリックされた際に発生します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void Select_Button_Click(object sender, EventArgs e)
        {
            // 選択
            if (sender == this.Select_Button)
            {
                this._uoeReplyIndicateAcs.SetRowSelectedAll(true);
                this.ChangedSelectColorAll(true);
            }
            // 非選択
            if (sender == this.UnSelect_Button)
            {
                this._uoeReplyIndicateAcs.SetRowSelectedAll(false);
                this.ChangedSelectColorAll(false);
            }
        }
        #endregion

        #region ▼uGrid_Details_InitializeLayout(グリッドイニシャライズ時)
        /// <summary>
        /// グリッドイニシャライズ　イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドの列を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // Timer_GridSetFocusをやめて下記の通りとする　※流れが分かりにくい為
            // どちらもグリッドがアクティブ(1行目アクティブ)になった時にアクティブ色をつける処理
            e.Layout.Override.ActiveRowAppearance.BackColor = ACTIVEROW_BACKCOLOR;
            e.Layout.Override.ActiveRowAppearance.BackColor2 = ACTIVEROW_BACKCOLOR2;
            e.Layout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            e.Layout.Override.ActiveRowAppearance.ForeColor = Color.Black;
        }
        #endregion

        #region ▼uGrid_Details_Enter(グリッドアクティブ時)
        /// <summary>
        /// グリッドエンター イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : アクティブな行がある場合、選択状態にします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow != null)
            {
                this.uGrid_Details.ActiveRow.Selected = true;
            }

            // 文字色変更
            UltraGrid ultraGrid = (UltraGrid)sender;
            foreach (UltraGridRow ultraGridRow in ultraGrid.Rows)
            {
                //this.ChangeForeColor(ultraGridRow);       //DEL 2009/01/13 不具合対応[9872]
                this.ChangeBackColor(ultraGridRow);         //ADD 2009/01/13
            }
        }
        #endregion

        #region ▼uGrid_Details_KeyDown(グリッドキー押下時)
        /// <summary>
        /// グリッドキーダウン イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 選択行なし->処理を行わない。</br>
        /// <br>             Enter     ->グリッドデフォルトの動作キャンセル。</br>
        /// <br>             ↑(先頭行)->グリッド外にフォーカスを移す。</br>
        /// <br>             →        ->右スクロール。</br>
        /// <br>             ←        ->左スクロール。</br>
        /// <br>             Homeのみ  ->スクロールを一番左へ。</br>
        /// <br>               +Control->先頭行へ。</br>
        /// <br>             Endのみ   ->スクロールを一番右へ。</br>
        /// <br>               +Control->最下行へ。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            // 選択行なし
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            #region Enter押下
            if (e.KeyCode == Keys.Enter)
            {
                // グリッドデフォルトの動作をキャンセル
                e.Handled = true;
            }
            #endregion

            #region ↑押下(最上行)
            if ((this.uGrid_Details.ActiveRow.Index == 0) && (e.KeyCode == Keys.Up))
            {
                if (this.PrintExtra_Panel.Visible)
                {
                    this.Select_Button.Focus();
                }

                // グリッドデフォルトの動作をキャンセル
                e.Handled = true;
            }
            #endregion

            #region →押下
            if (e.KeyCode == Keys.Right)
            {
                // グリッドデフォルトの動作をキャンセル
                e.Handled = true;

                // グリッド表示を右にスクロール
                this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
            }
            #endregion

            #region ←押下
            if (e.KeyCode == Keys.Left)
            {
                // グリッドデフォルトの動作をキャンセル
                e.Handled = true;

                // グリッド表示を左にスクロール
                if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position != 0)
                {
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }
            #endregion

            #region Home(Home + Control)押下
            if (e.KeyCode == Keys.Home)
            {
                // グリッドデフォルトの動作をキャンセル
                e.Handled = true;

                // Homeキーのみ
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Home + Controlキー
                if (e.Modifiers == Keys.Control)
                {
                    // 先頭行に移動
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
            }
            #endregion

            #region End(End + Control)押下
            if (e.KeyCode == Keys.End)
            {
                // グリッドデフォルトの動作をキャンセル
                e.Handled = true;

                // Endキーのみ
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を最右にスクロール
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                }

                // End + Controlキー
                if (e.Modifiers == Keys.Control)
                {
                    // 最終行に移動
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
            #endregion
        }
        #endregion

        #region ▼uGrid_Details_Click(グリッドクリック時)
        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 一覧グリッドがクリックされた際に発生します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_Click(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
            {
                return;
            }

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));
            if (objHeader != null)
            {
                return;
            }

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
            if (objRow == null)
            {
                return;
            }

            // マウスポインターが選択セル上にあるか？
            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
            if (objCell == null)
            {
                return;
            }

            // 選択列
            if (objCell.Column.Key == PMUOE04202EA.ct_Col_SelectFlg)
            {
                // 選択/解除設定
                this.ChangedSelect(objRow);
            }
        }
        #endregion
        # endregion ■イベント - end

		#region ■Public
        #region ▼SetGridEnable(グリッド使用可/不可判定)
        /// <summary>
        /// グリッド使用可/不可判定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細情報の使用可/不可を判定し、設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SetGridEnable()
        {
            bool enable = true;
            if (this.uGrid_Details.Rows.Count == 0)
            {
                enable = false;
            }

            // 使用可/不可設定
            this.uGrid_Details.Enabled = enable;        // グリッド
            this.PrintExtra_Panel.Enabled = enable;     // 全て選択/解除ボタン

            return enable;
        }
        #endregion

        #region ▼Closing(クローズ時処理)
        /// <summary>
		/// クローズ処理
		/// </summary>
        /// <remarks>
        /// <br>Note       : 列表示状態をXMLにシリアライズします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        internal void Closing()
		{
			// 列表示状態クラスリスト構築処理
			List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

			// 列表示状態クラスリストをXMLにシリアライズする
			ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
        }
        #endregion
        #endregion ■Public - end

        #region ■Private
        #region ▼GridInitialSetting(グリッド列初期設定)
        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドの列を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            string moneyFormat = "#,##0;-#,##0;''";
            string moneyFormat2 = "#,##0.00;-#,##0.00;''";  // add 2012/07/13
            string dateFormat = "yyyy/MM/dd";
            string timeFormat = "hh:mm:ss";

            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // カラム設定
            #region カラム情報設定
            // No.
            columns[PMUOE04202EA.ct_Col_No].Hidden = true;
            columns[PMUOE04202EA.ct_Col_No].Header.Caption = "No.";
            columns[PMUOE04202EA.ct_Col_No].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 選択フラグ
            columns[PMUOE04202EA.ct_Col_SelectFlg].Hidden = false;
            columns[PMUOE04202EA.ct_Col_SelectFlg].Header.Caption = "選択";
            columns[PMUOE04202EA.ct_Col_SelectFlg].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            columns[PMUOE04202EA.ct_Col_SelectFlg].AutoEdit = true;
            // 受信日付
            columns[PMUOE04202EA.ct_Col_ReceiveDate].Hidden = false;
            columns[PMUOE04202EA.ct_Col_ReceiveDate].Header.Caption = "受信日付";
            columns[PMUOE04202EA.ct_Col_ReceiveDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[PMUOE04202EA.ct_Col_ReceiveDate].Format = dateFormat;
            // 受信時刻
            columns[PMUOE04202EA.ct_Col_ReceiveTime].Hidden = false;
            columns[PMUOE04202EA.ct_Col_ReceiveTime].Header.Caption = "受信時刻";
            columns[PMUOE04202EA.ct_Col_ReceiveTime].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[PMUOE04202EA.ct_Col_ReceiveTime].Format = timeFormat;
            // 発注回答番号
            columns[PMUOE04202EA.ct_Col_UOESalesOrderNo].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOESalesOrderNo].Header.Caption = "発注番号";
            columns[PMUOE04202EA.ct_Col_UOESalesOrderNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 発注回答行番号
            columns[PMUOE04202EA.ct_Col_UOESalesOrderRowNo].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOESalesOrderRowNo].Header.Caption = "発注行番号";
            columns[PMUOE04202EA.ct_Col_UOESalesOrderRowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 発注先コード
            columns[PMUOE04202EA.ct_Col_UOESupplierCd].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOESupplierCd].Header.Caption = "発注先ｺｰﾄﾞ";
            columns[PMUOE04202EA.ct_Col_UOESupplierCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 発注先名称
            columns[PMUOE04202EA.ct_Col_UOESupplierName].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOESupplierName].Header.Caption = "発注先名称";
            columns[PMUOE04202EA.ct_Col_UOESupplierName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // UOE納品区分
            columns[PMUOE04202EA.ct_Col_UOEDeliGoodsDiv].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOEDeliGoodsDiv].Header.Caption = "納品区分";
            columns[PMUOE04202EA.ct_Col_UOEDeliGoodsDiv].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // フォロー納品区分
            columns[PMUOE04202EA.ct_Col_FollowDeliGoodsDiv].Hidden = false;
            columns[PMUOE04202EA.ct_Col_FollowDeliGoodsDiv].Header.Caption = "ﾌｫﾛｰ納品区分";
            columns[PMUOE04202EA.ct_Col_FollowDeliGoodsDiv].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // BO区分
            columns[PMUOE04202EA.ct_Col_BOCode].Hidden = false;
            columns[PMUOE04202EA.ct_Col_BOCode].Header.Caption = "BO区分";
            columns[PMUOE04202EA.ct_Col_BOCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 依頼者コード
            columns[PMUOE04202EA.ct_Col_EmployeeCode].Hidden = false;
            columns[PMUOE04202EA.ct_Col_EmployeeCode].Header.Caption = "依頼者ｺｰﾄﾞ";
            columns[PMUOE04202EA.ct_Col_EmployeeCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 依頼者名称
            columns[PMUOE04202EA.ct_Col_EmployeeName].Hidden = false;
            columns[PMUOE04202EA.ct_Col_EmployeeName].Header.Caption = "依頼者名称";
            columns[PMUOE04202EA.ct_Col_EmployeeName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 得意先コード
            columns[PMUOE04202EA.ct_Col_CustomerCode].Hidden = false;
            columns[PMUOE04202EA.ct_Col_CustomerCode].Header.Caption = "得意先ｺｰﾄﾞ";
            columns[PMUOE04202EA.ct_Col_CustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 得意先名称
            columns[PMUOE04202EA.ct_Col_CustomerSnm].Hidden = false;
            columns[PMUOE04202EA.ct_Col_CustomerSnm].Header.Caption = "得意先名称";
            columns[PMUOE04202EA.ct_Col_CustomerSnm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 品番
            columns[PMUOE04202EA.ct_Col_GoodsNo].Hidden = false;
            columns[PMUOE04202EA.ct_Col_GoodsNo].Header.Caption = "品番";
            columns[PMUOE04202EA.ct_Col_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // メーカー
            columns[PMUOE04202EA.ct_Col_GoodsMakerCd].Hidden = false;
            columns[PMUOE04202EA.ct_Col_GoodsMakerCd].Header.Caption = "ﾒｰｶｰ";
            columns[PMUOE04202EA.ct_Col_GoodsMakerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 品名
            columns[PMUOE04202EA.ct_Col_GoodsName].Hidden = false;
            columns[PMUOE04202EA.ct_Col_GoodsName].Header.Caption = "品名";
            columns[PMUOE04202EA.ct_Col_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // リマーク1
            columns[PMUOE04202EA.ct_Col_UOERemark1].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOERemark1].Header.Caption = "ﾘﾏｰｸ1";
            columns[PMUOE04202EA.ct_Col_UOERemark1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // リマーク2
            columns[PMUOE04202EA.ct_Col_UOERemark2].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOERemark2].Header.Caption = "ﾘﾏｰｸ2";
            columns[PMUOE04202EA.ct_Col_UOERemark2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PMUOE04202EA.ct_Col_UOERemark2].Format = dateFormat;
            // 発注数量
            columns[PMUOE04202EA.ct_Col_AcceptAnOrderCnt].Hidden = false;
            columns[PMUOE04202EA.ct_Col_AcceptAnOrderCnt].Header.Caption = "発注数量";
            columns[PMUOE04202EA.ct_Col_AcceptAnOrderCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PMUOE04202EA.ct_Col_AcceptAnOrderCnt].Format = moneyFormat;
            // 拠点出庫数
            columns[PMUOE04202EA.ct_Col_UOESectOutGoodsCnt].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOESectOutGoodsCnt].Header.Caption = "拠点出庫数";
            columns[PMUOE04202EA.ct_Col_UOESectOutGoodsCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PMUOE04202EA.ct_Col_UOESectOutGoodsCnt].Format = moneyFormat;
            // 拠点伝票番号
            columns[PMUOE04202EA.ct_Col_UOESectionSlipNo].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOESectionSlipNo].Header.Caption = "拠点伝票番号";
            columns[PMUOE04202EA.ct_Col_UOESectionSlipNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // フォロー1
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt1].Hidden = false;
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt1].Header.Caption = "ﾌｫﾛｰ1";
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt1].Format = moneyFormat;
            // フォロー伝票番号1
            columns[PMUOE04202EA.ct_Col_BOSlipNo1].Hidden = false;
            columns[PMUOE04202EA.ct_Col_BOSlipNo1].Header.Caption = "ﾌｫﾛｰ伝票番号1";
            columns[PMUOE04202EA.ct_Col_BOSlipNo1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // フォロー2
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt2].Hidden = false;
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt2].Header.Caption = "ﾌｫﾛｰ2";
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt2].Format = moneyFormat;
            // フォロー伝票番号2
            columns[PMUOE04202EA.ct_Col_BOSlipNo2].Hidden = false;
            columns[PMUOE04202EA.ct_Col_BOSlipNo2].Header.Caption = "ﾌｫﾛｰ伝票番号2";
            columns[PMUOE04202EA.ct_Col_BOSlipNo2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // フォロー3
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt3].Hidden = false;
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt3].Header.Caption = "ﾌｫﾛｰ3";
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PMUOE04202EA.ct_Col_BOShipmentCnt3].Format = moneyFormat;
            // フォロー伝票番号3
            columns[PMUOE04202EA.ct_Col_BOSlipNo3].Hidden = false;
            columns[PMUOE04202EA.ct_Col_BOSlipNo3].Header.Caption = "ﾌｫﾛｰ伝票番号3";
            columns[PMUOE04202EA.ct_Col_BOSlipNo3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // メーカーフォロー数
            columns[PMUOE04202EA.ct_Col_MakerFollowCnt].Hidden = false;
            columns[PMUOE04202EA.ct_Col_MakerFollowCnt].Header.Caption = "ﾒｰｶｰﾌｫﾛｰ数";
            columns[PMUOE04202EA.ct_Col_MakerFollowCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PMUOE04202EA.ct_Col_MakerFollowCnt].Format = moneyFormat;
            // 定価
            columns[PMUOE04202EA.ct_Col_ListPrice].Hidden = false;
            columns[PMUOE04202EA.ct_Col_ListPrice].Header.Caption = "定価";
            columns[PMUOE04202EA.ct_Col_ListPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PMUOE04202EA.ct_Col_ListPrice].Format = moneyFormat;
            // 仕切単価
            columns[PMUOE04202EA.ct_Col_SalesUnitCost].Hidden = false;
            columns[PMUOE04202EA.ct_Col_SalesUnitCost].Header.Caption = "仕切単価";
            columns[PMUOE04202EA.ct_Col_SalesUnitCost].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // upd 2012/07/13 >>>
            //columns[PMUOE04202EA.ct_Col_SalesUnitCost].Format = moneyFormat;
            columns[PMUOE04202EA.ct_Col_SalesUnitCost].Format = moneyFormat2;
            // upd 2012/07/13 <<<
            // 代替区分
            columns[PMUOE04202EA.ct_Col_UOESubstMark].Hidden = false;
            columns[PMUOE04202EA.ct_Col_UOESubstMark].Header.Caption = "代替区分";
            columns[PMUOE04202EA.ct_Col_UOESubstMark].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 層別(日産)
            columns[PMUOE04202EA.ct_Col_PartsLayerCd].Hidden = false;
            columns[PMUOE04202EA.ct_Col_PartsLayerCd].Header.Caption = "層別(日産)";
            columns[PMUOE04202EA.ct_Col_PartsLayerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // EO管理番号(日産)
            columns[PMUOE04202EA.ct_Col_BOManagementNo].Hidden = false;
            columns[PMUOE04202EA.ct_Col_BOManagementNo].Header.Caption = "EO管理番号(日産)";
            columns[PMUOE04202EA.ct_Col_BOManagementNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // EO発注数(日産)
            columns[PMUOE04202EA.ct_Col_EOAlwcCount].Hidden = false;
            columns[PMUOE04202EA.ct_Col_EOAlwcCount].Header.Caption = "EO発注数(日産)";
            columns[PMUOE04202EA.ct_Col_EOAlwcCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PMUOE04202EA.ct_Col_EOAlwcCount].Format = moneyFormat;
            // 拠点コード(マツダ)
            columns[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd1].Hidden = false;
            columns[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd1].Header.Caption = "拠点ｺｰﾄﾞ(ﾏﾂﾀﾞ)";
            columns[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // フォローコード1(マツダ)
            columns[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd2].Hidden = false;
            columns[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd2].Header.Caption = "ﾌｫﾛｰｺｰﾄﾞ1(ﾏﾂﾀﾞ)";
            columns[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // フォローコード2(マツダ)
            columns[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd3].Hidden = false;
            columns[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd3].Header.Caption = "ﾌｫﾛｰｺｰﾄﾞ2(ﾏﾂﾀﾞ)";
            columns[PMUOE04202EA.ct_Col_MazdaUOEShipSectCd3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // エラーメッセージ
            columns[PMUOE04202EA.ct_Col_LineErrorMessage].Hidden = false;
            //columns[PMUOE04202EA.ct_Col_LineErrorMessage].Header.Caption = "ｴﾗｰﾒｯｾｰｼﾞ";           //DEL 2009/01/21 不具合対応[9876]
            columns[PMUOE04202EA.ct_Col_LineErrorMessage].Header.Caption = "ｺﾒﾝﾄ";                  //ADD 2009/01/21 不具合対応[9876]
            columns[PMUOE04202EA.ct_Col_LineErrorMessage].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 出荷元コード(ホンダ)
            columns[PMUOE04202EA.ct_Col_SourceShipment].Hidden = false;
            columns[PMUOE04202EA.ct_Col_SourceShipment].Header.Caption = "出荷元ｺｰﾄﾞ(ﾎﾝﾀﾞ)";
            columns[PMUOE04202EA.ct_Col_SourceShipment].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 拠点コード(※帳票用項目)
            columns[PMUOE04202EA.ct_Col_SectionCode].Hidden = true;
            columns[PMUOE04202EA.ct_Col_SectionCode].Header.Caption = "拠点ｺｰﾄﾞ";
            columns[PMUOE04202EA.ct_Col_SectionCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 拠点名称(※帳票用項目)
            columns[PMUOE04202EA.ct_Col_SectionName].Hidden = true;
            columns[PMUOE04202EA.ct_Col_SectionName].Header.Caption = "拠点名称";
            columns[PMUOE04202EA.ct_Col_SectionName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 表示文字色
            columns[PMUOE04202EA.ct_Col_ForeColor].Hidden = true;
            columns[PMUOE04202EA.ct_Col_ForeColor].Header.Caption = "表示文字色";
            columns[PMUOE04202EA.ct_Col_ForeColor].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            #endregion

            // 幅、表示位置、列固定の設定
            foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
            {
                if (columns.Exists(colDisplayStatus.Key))
                {
                    columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                    columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
                }
            }

            // 固定列区切り線設定
            this.uGrid_Details.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }
        #endregion

        #region ▼ChangedSelectColorAll(全ての行の背景色を変更)
        /// <summary>
        /// 全ての行の背景色変更
        /// </summary>
        /// <param name="isSelected">True：選択、False：非選択</param>
        /// <remarks>
        /// <br>Note       : 全ての行に対して背景色を変更します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void ChangedSelectColorAll(bool isSelected)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Details.Rows)
            {
                this.ChangedSelectColor(isSelected, gridRow);
            }
        }
        #endregion

        #region ▼ChangedSelect(選択/非選択設定-反転)
        /// <summary>
		/// 選択・非選択変更処理（反転）
		/// </summary>
		/// <param name="gridRow">対象行</param>
        /// <remarks>
        /// <br>Note       : グリッドの背景色を変更し、アクセスクラス内の情報を更新します。</bir>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void ChangedSelect(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
		{
            bool newSelectedValue = !(bool)gridRow.Cells[PMUOE04202EA.ct_Col_SelectFlg].Value;

            // テーブル更新
            this._uoeReplyIndicateAcs.SetRowSelected((int)gridRow.Cells[PMUOE04202EA.ct_Col_No].Value, newSelectedValue);

            // 背景色を変更
            this.ChangedSelectColor(newSelectedValue, gridRow);
        }
        #endregion

        #region ▼ChangedSelectColor(選択/非選択設定-背景色のみ)
        /// <summary>
		/// 選択・非選択変更処理（背景色のみ）
		/// </summary>
		/// <param name="isSelected">True：選択、False：非選択</param>
		/// <param name="gridRow">対象行</param>
        /// <remarks>
        /// <br>Note       : グリッドの背景色を変更します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void ChangedSelectColor(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
		{
            if (gridRow == null)
            {
                return;
            }

			// 対象行の選択色を設定する
			if (isSelected)
			{
				gridRow.Appearance.BackColor = SELECTED_BACKCOLOR;
				gridRow.Appearance.BackColor2 = SELECTED_BACKCOLOR2;
				gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			}
			else
			{
				if (gridRow.Index % 2 == 1)
				{
					gridRow.Appearance.BackColor = Color.Lavender;
				}
				else
				{
					gridRow.Appearance.BackColor = Color.White;
				}
				gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			}

            //// 前景色設定
            //this.ChangeForeColor(gridRow);        //DEL 2009/01/13 不具合対応[9872]
            this.ChangeBackColor(gridRow);          //ADD 2009/01/13
        }
        #endregion

        /* --- DEL 2009/01/13 不具合対応[9872] ---------------------------------------------------------------------->>>>>
        #region ▼ChangeForeColor(前景色設定)
        /// <summary>
        /// 前景色設定
        /// </summary>
        /// <param name="gridRow">対象行</param>
        /// <remarks>
        /// <br>Note       : グリッドの前景色を変更します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void ChangeForeColor(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            // 文字色変更
            switch (gridRow.Cells[PMUOE04202EA.ct_Col_ForeColor].Value.ToString())
            {
                case "YELLOW":
                    {
                        gridRow.Appearance.ForeColor = Color.Orange;
                        break;
                    }
                case "GREEN":
                    {
                        gridRow.Appearance.ForeColor = Color.FromArgb(51, 153, 102);
                        break;
                    }
                case "BLUE":
                    {
                        gridRow.Appearance.ForeColor = Color.FromArgb(0, 0, 255);
                        break;
                    }
                case "RED":
                    {
                        gridRow.Appearance.ForeColor = Color.FromArgb(255, 0, 0);
                        break;
                    }
                default:
                    gridRow.Appearance.ForeColor = Color.Black;
                    break;
            }
        }
        #endregion
           --- DEL 2009/01/13 不具合対応[9872] ----------------------------------------------------------------------<<<<< */
        // --- ADD 2009/01/13 不具合対応[9872] ---------------------------------------------------------------------->>>>>
        #region ▼ChangeForeColor(背景色設定)
        /// <summary>
        /// 背景色設定
        /// </summary>
        /// <param name="gridRow">対象行</param>
        /// <remarks>
        /// <br>Note       : グリッドの背景色を変更します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void ChangeBackColor(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            // 文字色変更
            switch (gridRow.Cells[PMUOE04202EA.ct_Col_ForeColor].Value.ToString())
            {
                case "YELLOW":
                    {
                        gridRow.Appearance.BackColor = Color.FromArgb(240, 240, 180);
                        break;
                    }
                case "GREEN":
                    {
                        gridRow.Appearance.BackColor = Color.FromArgb(150, 255, 150);
                        break;
                    }
                case "BLUE":
                    {
                        gridRow.Appearance.BackColor = Color.FromArgb(180, 200, 253);
                        break;
                    }
                case "RED":
                    {
                        gridRow.Appearance.BackColor = Color.FromArgb(253, 200, 200);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
        // --- ADD 2009/01/13 不具合対応[9872] ----------------------------------------------------------------------<<<<<


        #region ▼ColDisplayStatusListConstruction(グリッド→列表示状態クラスリスト作成)
        /// <summary>
        /// 列表示状態クラスリスト構築処理
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドから列表示状態クラスリストを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // グリッドから列表示状態クラスリストを構築
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;
                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }
        #endregion
        #endregion ■Private - end
    }
}
