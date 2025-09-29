using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 相場価格選択フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2010/06/17</br>
    /// </remarks>
    public partial class SelectionMarketPrice : Form
    {
        #region [ Private フィールド ]
        private int _searchStatus;
        private SelectionMarketPriceAcs _selectionMarketPriceAcs;

        private List<int> _makerList = null;
        private bool isDialogShown = false;
        private List<MarketPriceInfo> _marketPriceInfoList;
        private MarketPriceAcqCond _condition;
        # endregion

        # region [ public プロパティ ]
        /// <summary> 
        /// ダイアログ表示可否フラグ（データ数により自動判定） 
        /// </summary>
        public bool IsDialogShown
        {
            get 
            { 
                return isDialogShown; 
            }
        }
        /// <summary>
        /// 選択結果の相場価格情報リスト
        /// </summary>
        public List<MarketPriceInfo> MarketPriceInfoList
        {
            get 
            {
                if ( _marketPriceInfoList == null )
                {
                    _marketPriceInfoList = new List<MarketPriceInfo>();
                }
                return _marketPriceInfoList; 
            }
        }
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="cndtn"></param>
        public SelectionMarketPrice( MarketPriceAcqCond cndtn )
        {
            // 検索実行
            _selectionMarketPriceAcs = new SelectionMarketPriceAcs();
            string errMsg;
            _condition = cndtn;
            _searchStatus = _selectionMarketPriceAcs.MarketPriceSearch( cndtn, out errMsg );
            
            // フォーム表示判定(データが無い時は非表示)
            isDialogShown = (_searchStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL);

            if ( IsDialogShown )
            {
                // UI初期化
                InitializeComponent();
            }
        }
        # endregion

        # region [表示]
        /// <summary>
        /// 相場価格選択UIを表示する
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog( IWin32Window owner )
        {
            if ( !IsDialogShown )
            {
                return DialogResult.Cancel;
            }
            Initialize();
            return base.ShowDialog( owner );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            if ( !IsDialogShown )
            {
                return DialogResult.Cancel;
            }
            Initialize();
            return base.ShowDialog();
        }
        # endregion

        # region [初期化処理]
        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            // 検索が正常に終了していない場合は処理しない
            if ( _searchStatus != 0 )
            {
                return;
            }

            // 画面表示（ヘッダ部）
            txtBLCode.Text = _condition.BLGoodsCode.ToString( "00000" );
            txtPartName.Text = _condition.BLGoodsName.Trim();

            # region [ツールバーの初期化]
            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            # endregion

            # region [Grid初期化]
            const string ct_PriceFormat = "#,##0;-#,##0;;";

            // Grid更新開始＞＞＞
            gridSoba.BeginUpdate();

            // データソース設定
            gridSoba.DataSource = _selectionMarketPriceAcs.PriceInfoDataTable.DefaultView;

            # region [カラム設定]
            // 選択用カラム追加
            UltraGridColumn col = gridSoba.DisplayLayout.Bands[0].Columns.Add( "SelectState", "選択" );
            col.DataType = typeof( Image );
            col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

            // カラム非表示
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.PriorityColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceAreaCdColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceAreaNmColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceKindCdColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceQualityCdColumn.ColumnName].Hidden = true;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.DstrMarketPriceColumn.ColumnName].Hidden = true;

            // 表示順
            int position = 0;
            gridSoba.DisplayLayout.Bands[0].Columns["SelectState"].Header.VisiblePosition = position++;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceKindNmColumn.ColumnName].Header.VisiblePosition = position++;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceQualityNmColumn.ColumnName].Header.VisiblePosition = position++;
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceColumn.ColumnName].Header.VisiblePosition = position++;

            // カラム幅
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName].Width = 50;

            // 左右位置
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // フォーマット
            gridSoba.DisplayLayout.Bands[0].Columns[_selectionMarketPriceAcs.PriceInfoDataTable.MarketPriceColumn.ColumnName].Format = ct_PriceFormat;
            # endregion

            // Grid更新終了＜＜＜
            gridSoba.EndUpdate();
            # endregion
        }
        # endregion

        #region [ フォームイベント処理 ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionSamePartsNoParts_Shown( object sender, EventArgs e )
        {
            if ( gridSoba.Rows.Count == 0 )
                return;
            // 先頭行にフォーカスセットする
            gridSoba.Focus();
            gridSoba.Rows[0].Activate();
            gridSoba.Rows[0].Selected = true;
        }
        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionSamePartsNoParts_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Escape )
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
        {
            UltraGridRow activeRow = gridSoba.ActiveRow;
            switch ( e.Tool.Key )
            {
                case "Button_Select":
                    // 選択されている行を確定する
                    SetSelectDecision();
                    // 確定
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_Back":
                    // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }
        #endregion

        #region [ メイングリッドイベント処理 ]
        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドのレイアウト初期化処理</br>
        /// </remarks>
        private void gridParts_InitializeLayout( object sender, InitializeLayoutEventArgs e )
        {
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // 行セレクタの幅
            e.Layout.Override.RowSelectorWidth = 25;
        }

        /// <summary>
        /// アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParts_AfterSelectChange( object sender, AfterSelectChangeEventArgs e )
        {
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        private void gridParts_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            SetSelect( false );
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParts_KeyDown( object sender, KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.Enter:
                    SetSelect( true );
                    break;
                case Keys.Space:
                    SetSelect( true );
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [ その他メソッド ]
        /// <summary>
        /// 選択状態設定処理
        /// </summary>
        private void SetSelect( bool moveNext )
        {
            UltraGridRow activeRow = gridSoba.ActiveRow;
            if ( activeRow != null )
            {
                try
                {
                    // 選択反転する
                    bool selectState = (bool)activeRow.Cells[_selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName].Value;
                    activeRow.Cells[_selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName].Value = !selectState;

                    // チェックマーク表示
                    if ( !selectState == true )
                    {
                        activeRow.Cells["SelectState"].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    }
                    else
                    {
                        activeRow.Cells["SelectState"].Value = DBNull.Value;
                    }


                    // 次行へ移動
                    if ( moveNext )
                    {
                        int rowIndex = activeRow.Index;
                        if ( gridSoba.Rows.Count > rowIndex + 1 )
                        {
                            gridSoba.Rows[rowIndex + 1].Activate();
                            gridSoba.Rows[rowIndex + 1].Selected = true;
                        }
                    }
                }
                catch
                {
                }
                // 変更を適用
                _selectionMarketPriceAcs.PriceInfoDataTable.AcceptChanges();
            }
        }

        /// <summary>
        /// 選択確定処理
        /// </summary>
        private void SetSelectDecision()
        {
            // リスト初期化
            _marketPriceInfoList = new List<MarketPriceInfo>();

            // 変更適用
            _selectionMarketPriceAcs.PriceInfoDataTable.AcceptChanges();

            // 選択済みだけで絞り込み
            _selectionMarketPriceAcs.PriceInfoDataTable.DefaultView.RowFilter = string.Format( "{0} = {1}",
                    _selectionMarketPriceAcs.PriceInfoDataTable.SelectedColumn.ColumnName, true );

            // リストに格納
            foreach ( DataRowView rowView in _selectionMarketPriceAcs.PriceInfoDataTable.DefaultView )
            {
                MarketPriceInfoDataSet.MarketPriceInfoRow row = (MarketPriceInfoDataSet.MarketPriceInfoRow)rowView.Row;
                _marketPriceInfoList.Add( CopyToMarketPriceInfoFromRow( row ) );
            }
        }
        /// <summary>
        /// DataRow ⇒ Result変換
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private MarketPriceInfo CopyToMarketPriceInfoFromRow( MarketPriceInfoDataSet.MarketPriceInfoRow row )
        {
            MarketPriceInfo data = new MarketPriceInfo();

            data.DstrMarketPrice = row.DstrMarketPrice;
            data.MarketPrice = row.MarketPrice;
            data.MarketPriceAreaCd = row.MarketPriceAreaCd;
            data.MarketPriceAreaNm = row.MarketPriceAreaNm;
            data.MarketPriceKindCd = row.MarketPriceKindCd;
            data.MarketPriceKindNm = row.MarketPriceKindNm;
            data.MarketPriceQualityCd = row.MarketPriceQualityCd;
            data.MarketPriceQualityNm = row.MarketPriceQualityNm;

            data.BLGoodsCode = _condition.BLGoodsCode;
            data.BLGoodsName = _condition.BLGoodsName;

            string goodsName = GetSobaGoodsName( _condition, row ); // 品名
            data.GoodsNameKana = ToKanaHalf( goodsName ); // 品名カナ

            return data;
        }
        /// <summary>
        /// 相場情報 品名取得
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetSobaGoodsName( MarketPriceAcqCond cndtn, MarketPriceInfoDataSet.MarketPriceInfoRow row )
        {
            StringBuilder sb = new StringBuilder();

            // <BLｺｰﾄﾞ名> + <ｽﾍﾟｰｽ> + <種別名> + <品質名>
            // "フロントバンパ リビルド極上品"
            sb.Append( cndtn.BLGoodsName.Trim() );
            sb.Append( " " );
            sb.Append( row.MarketPriceKindNm.Trim() );
            sb.Append( row.MarketPriceQualityNm.Trim() );
            
            return sb.ToString();
        }
        /// <summary>
        /// 半角カナ変換
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private string ToKanaHalf( string orgString )
        {
            // 全角⇒半角変換（途中に含まれる変換できない文字はそのまま）
            return Microsoft.VisualBasic.Strings.StrConv( orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0 );
        }
        #endregion
    }
}
