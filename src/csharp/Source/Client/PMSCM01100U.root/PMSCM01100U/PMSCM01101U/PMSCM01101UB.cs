//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理の画面
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杉村 利彦
// 作 成 日  2006/10/10  修正内容 : 新規作成：ＴＳＰ送受信処理【ＰＭ側】(SFMIT02850U)
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/29  修正内容 : SCM用にアレンジ
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信処理(明細表示)フォーム
    /// </summary>
	public partial class PMSCM01101UB : Form
	{
        /// <summary>デフォルトx座標</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>デフォルトy座標</summary>
        private const int DEFAULT_Y = 100000;

        /// <summary>明細グリッドのタイトルフォーマット</summary>
        const string DETAIL_GRID_TITLE_FORMAT = "伝票番号[{0}] 伝票合計金額[ \\{1}]";  // LITERAL:

        #region <回答送信処理>

        /// <summary>回答送信処理</summary>
        private readonly SCMSendController _scmController;
        /// <summary>回答送信処理を取得します。</summary>
        private SCMSendController SCMController { get { return _scmController; } }

        #endregion // </回答送信処理>

        #region <現在の送信伝票リストのID>

        /// <summary>現在の送信伝票リストのID</summary>
        private long _currentHeaderID;
        /// <summary>現在の送信伝票リストのIDを取得または設定します。</summary>
        public long CurrentHeaderID
        {
            get { return _currentHeaderID; }
            set { _currentHeaderID = value; }
        }

        #endregion // </現在の送信伝票リストのID>

        #region <Constructor>

        /// <summary>
		/// カスタムコンストラクタ
		/// </summary>
        public PMSCM01101UB(SCMSendController scmController)
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _scmController = scmController;
            this.sendingAnswerGrid.DataSource = _scmController.SendingDetailTable.DefaultView;
        }

        #endregion // </Constructor>

        /// <summary>
        /// 送信処理(明細表示)フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
		private void PMSCM01101UB_Load(object sender, EventArgs e)
        {
            //// 初期位置を設定（ちらつき防止の為、10000にしています）
            //SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

            // タイトルを設定
            DataRow[] foundHeaderRows = SCMController.SendingHeaderTable.Select(
                SCMController.SendingHeaderTable.IDColumn.ColumnName + " = " + CurrentHeaderID.ToString()
            );
            if (foundHeaderRows.Length.Equals(0))
            {
                Debug.Assert(false, "該当するSCM受注データが存在しません。(ID=" + CurrentHeaderID.ToString() + ")");
                return;
            }
            this.sendingAnswerGrid.Text = string.Format(
                DETAIL_GRID_TITLE_FORMAT,
                ((SCMSendViewDataSet.SendingSlipHeaderRow)foundHeaderRows[0]).SalesSlipNum,
                ((SCMSendViewDataSet.SendingSlipHeaderRow)foundHeaderRows[0]).SalesTotal.ToString("n0")
            );

            // 現在の伝票(SCM受注データ)でフィルタリング
            string rowFilter = SCMController.SendingDetailTable.HeaderIDColumn.ColumnName + "=" + CurrentHeaderID.ToString();
            SCMController.SendingDetailTable.DefaultView.RowFilter = rowFilter;
        }

        /// <summary>
        /// 明細グリッドのInitializeLayoutイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingAnswerGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = sendingAnswerGrid;

            // バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            // 列幅自動調整
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // カラムのキー
            string idKey        = SCMController.SendingDetailTable.IDColumn.ColumnName;         // IDカラムのキー
            string headerIdKey  = SCMController.SendingDetailTable.HeaderIDColumn.ColumnName;   // HeaderIDカラムのキー
            string blCodeKey    = SCMController.SendingDetailTable.BLGoodsCodeColumn.ColumnName;// BLコードカラムのキー
            string goodsNoKey   = SCMController.SendingDetailTable.GoodsNoColumn.ColumnName;    // 品番カラムのキー
            string goodsNameKey = SCMController.SendingDetailTable.GoodsNameColumn.ColumnName;  // 品名カラムのキー
            string deliveredGoodsCountKey = SCMController.SendingDetailTable.DeliveredGoodsCountColumn.ColumnName;   // 数量カラムのキー
            string unitPriceKey = SCMController.SendingDetailTable.UnitPriceColumn.ColumnName;  // 単価カラムのキー
            string salesTotalKey= SCMController.SendingDetailTable.SalesTotalColumn.ColumnName; // 金額カラムのキー

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in band.Columns)
            {
                // 表示位置(vertical)
                column.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                // クリック時は行セレクト
                column.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

                // 編集不可
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

                // ソート不可
                column.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;

                // 一度全て非表示にする。
                column.Hidden = true;
            }
            
            // 表示項目
            band.Columns[blCodeKey].Hidden = false;     	// BLコード
            band.Columns[goodsNoKey].Hidden = false;    	// 品番
            band.Columns[goodsNameKey].Hidden = false;      // 品名
            band.Columns[deliveredGoodsCountKey].Hidden = false;    // 数量
            band.Columns[unitPriceKey].Hidden = false;  	// 単価
            band.Columns[salesTotalKey].Hidden = false;	    // 合計

            // 表示順
            band.Columns[blCodeKey].Header.VisiblePosition      = 0;	// BLコード
            band.Columns[goodsNoKey].Header.VisiblePosition     = 1;	// 品番
            band.Columns[goodsNameKey].Header.VisiblePosition   = 2;    // 品名
            band.Columns[deliveredGoodsCountKey].Header.VisiblePosition = 3;    // 数量
            band.Columns[unitPriceKey].Header.VisiblePosition   = 4;	// 単価
            band.Columns[salesTotalKey].Header.VisiblePosition  = 5;	// 合計

            // カラム幅
            band.Columns[blCodeKey].Width       = 80;   // BLコード
            band.Columns[goodsNoKey].Width      = 180;	// 品番
            band.Columns[goodsNameKey].Width    = 240;	// 品名
            band.Columns[deliveredGoodsCountKey].Width = 50;	// 数量
            band.Columns[unitPriceKey].Width    = 90;	// 単価
            band.Columns[salesTotalKey].Width   = 90;	// 合計

            // 書式
            band.Columns[blCodeKey].Format      = "00000";// "#####;";  // BLコード
            band.Columns[unitPriceKey].Format   = "#,##0;-#,##0;";	    // 単価
            band.Columns[salesTotalKey].Format  = "#,##0;-#,##0;";	    // 合計

            // 表示位置
            band.Columns[blCodeKey].CellAppearance.TextHAlign       = Infragistics.Win.HAlign.Right;// BLコード
            band.Columns[goodsNoKey].CellAppearance.TextHAlign      = Infragistics.Win.HAlign.Left;	// 品番
            band.Columns[goodsNameKey].CellAppearance.TextHAlign    = Infragistics.Win.HAlign.Left;	// 品名
            band.Columns[deliveredGoodsCountKey].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// 数量
            band.Columns[unitPriceKey].CellAppearance.TextHAlign    = Infragistics.Win.HAlign.Right;// 単価
            band.Columns[salesTotalKey].CellAppearance.TextHAlign   = Infragistics.Win.HAlign.Right;// 合計

            // キー動作マッピングを追加
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	// Enterキー
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0
                )
            );
        }
	}
}