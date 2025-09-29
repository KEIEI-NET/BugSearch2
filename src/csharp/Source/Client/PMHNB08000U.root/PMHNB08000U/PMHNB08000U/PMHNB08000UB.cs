//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 印刷品番選択画面
// プログラム概要   : 部品検索結果データセットから画面表示を行い、選択された定価を反映させる。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/10/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/11/13  修正内容 : redmine#1265 印刷品番有効区分設定の追加
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 李侠
// 修 正 日  2010/02/04  修正内容 : PM1003・四次改良 ESCボタンで画面を終了する
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 21024　佐々木 健
// 修 正 日  2010/11/01  修正内容 : ①右端に表示されているボタンでTab押下時、フォーカスが消える不具合を修正(MANTIS[0016549])
//                                  ②Windowsタスクバーに画面が表示される不具合の修正(MANTIS[0016550])
//----------------------------------------------------------------------------//
// 管理番号  10806792-00 作成担当 : 脇田 靖之 						
// 修 正 日  2012/12/27  修正内容 : 自社品番印字対応				
//----------------------------------------------------------------------------// 						
// 管理番号  10806792-00 作成担当 : 西 毅 						
// 修 正 日  2013/01/09  修正内容 : 自社品番印字対応デフォルト値の変更
//----------------------------------------------------------------------------// 						
// 管理番号  10806792-00 作成担当 : 脇田 靖之 						
// 修 正 日  2013/01/15  修正内容 : 自社品番印字対応フォーカス移動不具合対応				
//----------------------------------------------------------------------------// 						
// 管理番号  10806792-00 作成担当 : 脇田 靖之 						
// 修 正 日  2013/01/15  修正内容 : 自社品番印字対応仕様変更対応				
//----------------------------------------------------------------------------// 						
// 管理番号  11070100-00 作成担当 : 宮本 利明
// 修 正 日  2014/06/16  修正内容 : LDNS #37904 対応分(2014/06/05)をマージ
//----------------------------------------------------------------------------// 						
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 印刷品番選択画面フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 印刷品番選択画面フォームクラスです。</br>
    /// <br>Programmer  : 李占川</br>
    /// <br>Date        : 2009/10/23</br>
    /// <br>Update Note : 李占川 2009/11/13</br>
    /// <br>            : redmine#1265 印刷品番有効区分設定の追加</br>
    /// <br>Update Note : 2010/02/04 李侠</br>
    /// <br>            : PM1003・四次改良 ESCボタンで画面を終了する</br>
    /// </remarks>
    public partial class SelectionPrtGoodsNo : Form
    {
        #region ■ コンストラクタ ■
        /// <summary>
        /// 印刷品番選択画面UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 印刷品番選択画面UIクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        public SelectionPrtGoodsNo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 印刷品番選択画面UIクラスコンストラクタ
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsMakerName">メーカー名称</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="partsInfoDataSet">部品検索結果データセット</param>
        /// <param name="goodsMakerCode">メーカーコード（自社）</param>
        /// <param name="goodsMakerName">メーカー名称（自社）</param>
        /// <param name="goodsNo">品番（自社）</param>
        /// <param name="goodsNo">自社品番印字区分</param>
        /// <param name="goodsNo">印字品番初期値</param>
        /// <remarks>
        /// <br>Note        : 印刷品番選択画面UIクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
        //// --- UPD 2012/12/27 Y.Wakita ---------->>>>>
        ////public SelectionPrtGoodsNo(int goodsMakerCode, string goodsMakerName, string goodsNo, PartsInfoDataSet partsInfoDataSet)
        //public SelectionPrtGoodsNo(int goodsMakerCode, string goodsMakerName, string goodsNo, PartsInfoDataSet partsInfoDataSet, int goodsMakerCode2, string goodsMakerName2, string goodsNo2, int epPartsNoPrtCd)
        //// --- UPD 2012/12/27 Y.Wakita ----------<<<<<
        public SelectionPrtGoodsNo(int goodsMakerCode, string goodsMakerName, string goodsNo, PartsInfoDataSet partsInfoDataSet, int goodsMakerCode2, string goodsMakerName2, string goodsNo2, int epPartsNoPrtCd, int printGoodsNoDef)
        // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
        {
            InitializeComponent();

            this._goodsMakerCd = goodsMakerCode;
            this._goodsMakeNm = goodsMakerName;
            this._gooosNo = goodsNo;
            this._partsInfo = partsInfoDataSet;

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 自社
            this._goodsMakerCd2 = goodsMakerCode2;
            this._goodsMakeNm2 = goodsMakerName2;
            this._gooosNo2 = goodsNo2;

            this._epPartsNoPrtCd = epPartsNoPrtCd;
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            this._printGoodsNoDef = printGoodsNoDef;
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<

            // 初期画面データ設定
            this.InitializeData();
        }

        #endregion

        #region ■ private定数 ■

        #endregion

        #region ■ private変数 ■
        // メーカーコード
        int _goodsMakerCd = 0;
        // メーカー名称
        string _goodsMakeNm = string.Empty;
        // 品番
        string _gooosNo = string.Empty;
        // 部品検索結果データセット
        PartsInfoDataSet _partsInfo;

        private PartsDataSet _priceParts = null;
        PartsDataSet.PrintInfoDataTable _printInfoTable = null;
        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        // メーカーコード（自社）
        int _goodsMakerCd2 = 0;
        // メーカー名称（自社）
        string _goodsMakeNm2 = string.Empty;
        // 品番（自社）
        string _gooosNo2 = string.Empty;
        // 自社品番印字区分
        int _epPartsNoPrtCd = 0; // 0:しない　1:する
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        // 自社品番印字区分
        int _printGoodsNoDef = 0; // 0:優先　1:自社　2:無し
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
        #endregion

        #region ■ コントロールイベント ■
        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void uGrid_PrintInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = DefaultableBoolean.False;
            e.Layout.Override.RowSelectors = DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_PrintInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.UseRowLayout = true;
            editBand.Indentation = 0;

            // ヘッダクリックアクションの設定(ソート処理)
            editBand.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
            // 行フィルター設定
            editBand.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // 複数行選択可
            editBand.Layout.Override.SelectTypeRow = SelectType.None;

            editBand.ColHeadersVisible = true;

            PartsDataSet.PrintInfoDataTable table = this._printInfoTable;
            ColumnsCollection columns = editBand.Columns;

            // グリッド列表示非表示設定処理
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
            }
            columns[table.SelectButtonColumn.ColumnName].Hidden = false;
            columns[table.GoodsNoColumn.ColumnName].Hidden = false;
            columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false;

            //--------------------------------------
            // キャプション
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].Header.Caption = "選択";
            columns[table.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "メーカー";


            //--------------------------------------
            // 入力不可
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].CellActivation = Activation.AllowEdit;
            columns[table.GoodsNoColumn.ColumnName].CellActivation = Activation.Disabled;
            columns[table.GoodsMakerNmColumn.ColumnName].CellActivation = Activation.Disabled;

            columns[table.GoodsNoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;

            //--------------------------------------
            // 列幅
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].Width = 70;
            columns[table.GoodsNoColumn.ColumnName].Width = 150;
            columns[table.GoodsMakerNmColumn.ColumnName].Width = 150;

            //--------------------------------------
            // テキスト位置(HAlign)
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // テキスト位置(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // ボタン設定
            //--------------------------------------
            columns[table.SelectButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[table.SelectButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[table.SelectButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// ClickCellButton イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルボタンをクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void uGrid_PrintInfo_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            int rowIndex = e.Cell.Row.Index;
            int columnIndex = e.Cell.Column.Index;

            switch (e.Cell.Column.Key)
            {
                // 選択
                case "SelectButton":
                    {
                        // 0:無し
                        if (rowIndex == 0)
                        {
                            this.SetPrintInfo(0);
                        }
                        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                        // 2:純正
                        else if (rowIndex == 2)
                        {
                            this.SetPrintInfo(2);
                        }
                        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                        // 1:優良
                        else
                        {
                            this.SetPrintInfo(1);
                        }
                        break;
                    }
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // 選択番号
                case "tEdit_SelectNo":
                    {
                        // ---DEL zhujw　2014/06/05 ------------------------------------>>>>>
                        //// 選択にフォーカスがある状態で[Enter]キーを入力した場合
                        //if (e.Key == Keys.Enter)
                        //{
                        //    int selectNo = Int32.Parse(this.tEdit_SelectNo.Text);
                        //    if (selectNo == 0)
                        //    {
                        //        // 確定処理を行う
                        //        this.SetPrintInfo(0);
                        //    }
                        //    else if (selectNo == 1)
                        //    {
                        //        // 確定処理を行う
                        //        this.SetPrintInfo(1);
                        //    }
                        //    // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                        //    else if (selectNo == 2)
                        //    {
                        //        if (_epPartsNoPrtCd == 1)
                        //        {
                        //            // 確定処理を行う
                        //            this.SetPrintInfo(2);
                        //        }
                        //        else
                        //        {
                        //            // 表示値を「1」とし、全選択状態とする
                        //            this.tEdit_SelectNo.Text = "1";
                        //            e.NextCtrl = this.tEdit_SelectNo;
                        //        }
                        //    }
                        //    // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                        //    else
                        //    {
                        //        // 表示値を「1」とし、全選択状態とする
                        //        this.tEdit_SelectNo.Text = "1";
                        //        e.NextCtrl = this.tEdit_SelectNo;
                        //    }
                        //}
                        //else if (e.Key == Keys.Tab)
                        // ---DEL zhujw　2014/06/05 ------------------------------------<<<<<
                        // ---ADD zhujw　2014/06/05 ------------------------------------>>>>>
                        if (e.Key == Keys.Tab)
                        // ---ADD zhujw　2014/06/05 ------------------------------------<<<<<
                        {
                            e.NextCtrl = this.uGrid_PrintInfo;
                        }
                        else if (e.Key == Keys.Up || e.Key == Keys.Down)
                        {
                            e.NextCtrl = this.tEdit_SelectNo;
                        }
                        // --- ADD 2014/06/16 T.Miyamoto ------------------------------>>>>>
                        else if (e.Key == Keys.Enter)
                        {
                            e.NextCtrl = this.tEdit_SelectNo;
                            //void tEdit_SelectNo_KeyPress(object sender, KeyPressEventArgs e)
                        }
                        // --- ADD 2014/06/16 T.Miyamoto ------------------------------<<<<<

                        break;
                    }
                // グリッド
                case "uGrid_PrintInfo":
                    {
                        if (this.uGrid_PrintInfo.Rows.Count == 0)
                        {
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // グリッドタブ移動制御
                                this.SetGridTabFocus(ref e);
                            }

                            if (e.Key == Keys.Enter)
                            {
                                uGrid_PrintInfo_ClickCellButton(this.uGrid_PrintInfo, new CellEventArgs(uGrid_PrintInfo.ActiveCell));
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // グリッドシフトタブ移動制御
                                this.SetGridShiftTabFocus(ref e);
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "uGrid_PrintInfo":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // グリッドタブ移動制御
                                this.SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // グリッドタブ移動制御
                                this.SetGridShiftTabFocus(ref e);
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void uGrid_PrintInfo_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if ((uGrid.Rows.Count == 0) ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                return;
            }

            int rowIndex = uGrid.ActiveRow.Index;

            switch (e.KeyCode)
            {
                case Keys.Space:
                case Keys.Enter:
                    {
                        uGrid_PrintInfo_ClickCellButton(this.uGrid_PrintInfo, new CellEventArgs(uGrid_PrintInfo.ActiveCell));
                        break;
                    }

                // --- UPD 2013/01/15 Y.Wakita ---------->>>>>
                //case Keys.Up:
                //case Keys.Down:
                //    {
                //        if (rowIndex == 0)
                //        {
                //            uGrid.Rows[1].Cells[0].Activate();
                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        else
                //        {
                //            uGrid.Rows[0].Cells[0].Activate();
                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //        }
                //        break;
                //    }
                case Keys.Up:
                    {
                        // 自社品番印字区分を「する」場合
                        if (_epPartsNoPrtCd == 1)
                        {
                            if (rowIndex == 0)
                            {
                                uGrid.Rows[2].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (rowIndex == 1)
                            {
                                uGrid.Rows[0].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (rowIndex == 2)
                            {
                                uGrid.Rows[1].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                        else
                        {
                            if (rowIndex == 0)
                            {
                                uGrid.Rows[1].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Rows[0].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    }

                case Keys.Down:
                    {
                        // 自社品番印字区分をする場合
                        if (_epPartsNoPrtCd == 1)
                        {
                            if (rowIndex == 0)
                            {
                                uGrid.Rows[1].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (rowIndex == 1)
                            {
                                uGrid.Rows[2].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (rowIndex == 2)
                            {
                                uGrid.Rows[0].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                        else
                        {
                            if (rowIndex == 0)
                            {
                                uGrid.Rows[1].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Rows[0].Cells[0].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    
                    }
                // --- UPD 2013/01/15 Y.Wakita ----------<<<<<
            }
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : Leave時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks>
        private void uGrid_PrintInfo_Leave(object sender, EventArgs e)
        {
            this.uGrid_PrintInfo.ActiveCell = null;
            this.uGrid_PrintInfo.ActiveRow = null;
            this.uGrid_PrintInfo.Selected.Rows.Clear();
        }

        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : 画面Closed時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks> 
        private void SelectionPrtGoodsNo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }
        }
        #endregion

        #region ■ privateメソッド ■
        /// <summary>
        /// 初期画面データ設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks> 
        private void InitializeData()
        {
            this._priceParts = new PartsDataSet();
            this._printInfoTable = this._priceParts.PrintInfo;

            // [0:無し]行
            PartsDataSet.PrintInfoRow row = this._printInfoTable.NewPrintInfoRow();
            row[this._printInfoTable.SelectButtonColumn.ColumnName] = "0:無し";
            row.GoodsNo = string.Empty;
            row.GoodsMakerCode = 0;
            row.GoodsMakerNm = string.Empty;
            this._printInfoTable.AddPrintInfoRow(row);

            // [1:優良]行
            row = this._printInfoTable.NewPrintInfoRow();
            row[this._printInfoTable.SelectButtonColumn.ColumnName] = "1:優良";
            row.GoodsNo = this._gooosNo;
            row.GoodsMakerNm = this._goodsMakeNm;
            row.GoodsMakerCode = this._goodsMakerCd;
            this._printInfoTable.AddPrintInfoRow(row);

            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 自社品番印字区分をする場合
            if (_epPartsNoPrtCd == 1)
            {
                // [2:自社]行
                row = this._printInfoTable.NewPrintInfoRow();
                row[this._printInfoTable.SelectButtonColumn.ColumnName] = "2:自社";
                row.GoodsNo = this._gooosNo2;
                // メーカーは非表示
                //row.GoodsMakerNm = this._goodsMakeNm2;
                //row.GoodsMakerCode = this._goodsMakerCd2;
                row.GoodsMakerNm = string.Empty;
                row.GoodsMakerCode = 0;
                this._printInfoTable.AddPrintInfoRow(row);

                // フォームサイズ変更
                this.Size = new System.Drawing.Size(574, 160);
                // 一覧サイズ変更
                this.uGrid_PrintInfo.Size = new System.Drawing.Size(558, 88);
                // 選択項目位置変更
                this.ultraLabel1.Location = new System.Drawing.Point(455, 92);
                this.tEdit_SelectNo.Location = new System.Drawing.Point(500, 92);
            }
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

            // --- UPD 2013/01/09 T.Nishi ---------->>>>>
            //this.tEdit_SelectNo.Text = "1";
            //印字品番初期値の値でデフォルト値変更
            // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
            //if (_epPartsNoPrtCd == 1)//自社の場合
            if (_printGoodsNoDef == 1)//自社の場合
            // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
            {
                this.tEdit_SelectNo.Text = "2";
            }
            // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
            //else if (_epPartsNoPrtCd == 2)//無しの場合
            else if (_printGoodsNoDef == 2)//無しの場合
            // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
            {
                this.tEdit_SelectNo.Text = "0";
            }
            else//それ以外（優良品）の場合
            {
                this.tEdit_SelectNo.Text = "1";
            }
            // --- UPD 2013/01/09 T.Nishi ----------<<<<<

            this._priceParts.AcceptChanges();
            this.uGrid_PrintInfo.DataSource = this._printInfoTable.DefaultView;
        }

        /// <summary>
        /// 印刷品番、印刷用メーカーコード、印刷用メーカー名称の設定。
        /// </summary>
        /// <param name="mode">0:無し;1:優良</param>
        /// <remarks>
        /// <br>Note        : 選択内容に従い、部品検索結果データセットの印刷品番、印刷用メーカーコード、印刷用メーカー名称を設定する。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// <br>Update Note : 李占川 2009/11/13</br>
        /// <br>            : redmine#1265 印刷品番有効区分設定の追加</br>
        /// </remarks> 
        private void SetPrintInfo(int mode)
        {
            // 0:無し
            if (mode == 0)
            {
                this._partsInfo.UsrGoodsInfo.BeginLoadData();
                PartsInfoDataSet.UsrGoodsInfoRow row = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(this._goodsMakerCd, this._gooosNo);

                if (row != null)
                {
                    row.SelectedGoodsNoDiv = 1; // ADD 2009/11/13
                    row.PrtGoodsNo = string.Empty;
                    row.PrtMakerCode = 0;
                    row.PrtMakerName = string.Empty;
                }

                this._partsInfo.UsrGoodsInfo.EndLoadData();
            }
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 2:自社
            else if (mode == 2)
            {
                this._partsInfo.UsrGoodsInfo.BeginLoadData();
                PartsInfoDataSet.UsrGoodsInfoRow row = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(this._goodsMakerCd, this._gooosNo);

                if (row != null)
                {
                    row.SelectedGoodsNoDiv = 1; // ADD 2009/11/13
                    // 印刷品番選択の品番(下段)に表示している品番を設定
                    row.PrtGoodsNo = (string)this.uGrid_PrintInfo.Rows[2].Cells[this._printInfoTable.GoodsNoColumn.ColumnName].Value;
                    // 印刷品番選択のメーカー(下段)に対応するメーカーコードを設定
                    row.PrtMakerCode = (int)this.uGrid_PrintInfo.Rows[2].Cells[this._printInfoTable.GoodsMakerCodeColumn.ColumnName].Value;
                    // 印刷品番選択のメーカー(下段)に表示しているメーカー名称を設定
                    row.PrtMakerName = (string)this.uGrid_PrintInfo.Rows[2].Cells[this._printInfoTable.GoodsMakerNmColumn.ColumnName].Value;
                }

                this._partsInfo.UsrGoodsInfo.EndLoadData();
            }
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // 1:優良
            else
            {
                this._partsInfo.UsrGoodsInfo.BeginLoadData();
                PartsInfoDataSet.UsrGoodsInfoRow row = this._partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(this._goodsMakerCd, this._gooosNo);

                if (row != null)
                {
                    row.SelectedGoodsNoDiv = 1; // ADD 2009/11/13
                    // 印刷品番選択の品番(下段)に表示している品番を設定
                    row.PrtGoodsNo = (string)this.uGrid_PrintInfo.Rows[1].Cells[this._printInfoTable.GoodsNoColumn.ColumnName].Value;
                    // 印刷品番選択のメーカー(下段)に対応するメーカーコードを設定
                    row.PrtMakerCode = (int)this.uGrid_PrintInfo.Rows[1].Cells[this._printInfoTable.GoodsMakerCodeColumn.ColumnName].Value;
                    // 印刷品番選択のメーカー(下段)に表示しているメーカー名称を設定
                    row.PrtMakerName = (string)this.uGrid_PrintInfo.Rows[1].Cells[this._printInfoTable.GoodsMakerNmColumn.ColumnName].Value;
                }

                this._partsInfo.UsrGoodsInfo.EndLoadData();
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// グリッドタブ移動制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドタブ移動制御を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            // 次フォーカス先カラム名
            string nextFocusColumn;
            int activationColIndex = 0;
            int activationRowIndex = 0;

            if (this.uGrid_PrintInfo.ActiveCell == null)
            {
                // アクティブなし または 行アクティブ
                e.NextCtrl = null;
                this.uGrid_PrintInfo.Focus();

                int rowIndex = 0;

                if (this.uGrid_PrintInfo.ActiveRow != null)
                {
                    rowIndex = this.uGrid_PrintInfo.ActiveRow.Index;
                }

                nextFocusColumn = "SelectButton";
                activationRowIndex = rowIndex;

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_PrintInfo.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_PrintInfo.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            else
            {
                // セルアクティブ
                int rowIndex = this.uGrid_PrintInfo.ActiveCell.Row.Index;
                int colIndex = this.uGrid_PrintInfo.ActiveCell.Column.Index;

                // グリッド脱出時用のコントロールを保持
                e.NextCtrl = null;
                this.uGrid_PrintInfo.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_PrintInfo.Focus();

                // 1行目の最初の入力可能行にフォーカス
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_PrintInfo.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_PrintInfo.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.tEdit_SelectNo.Focus();
                }
            }
        }

        /// <summary>
        /// グリッドシフトタブ制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドシフトタブ制御を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/10/23</br>
        /// </remarks>
        internal void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            // 次フォーカス先カラム名
            string nextFocusColumn;
            int activationColIndex;
            int activationRowIndex;

            if (this.uGrid_PrintInfo.ActiveCell == null)
            {
                // アクティブなし または 行アクティブ
                e.NextCtrl = null;
                this.uGrid_PrintInfo.Focus();

                int colIndex = this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns.Count - 1;
                int rowIndex = this.uGrid_PrintInfo.Rows.Count - 1;

                if (this.uGrid_PrintInfo.ActiveRow != null)
                {
                    colIndex = 0;
                    rowIndex = uGrid_PrintInfo.ActiveRow.Index;
                }

                // 1行目の最後の入力可能行にフォーカス
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_PrintInfo.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_PrintInfo.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.tEdit_SelectNo.Focus();
                }

                return;
            }
            else
            {
                // セルアクティブ
                int rowIndex = this.uGrid_PrintInfo.ActiveCell.Row.Index;
                int columnIndex = this.uGrid_PrintInfo.ActiveCell.Column.Index;

                // グリッド脱出時用のコントロールを保持
                e.NextCtrl = null;
                this.uGrid_PrintInfo.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_PrintInfo.Focus();

                // 次セル取得
                nextFocusColumn = GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_PrintInfo.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_PrintInfo.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.tEdit_SelectNo.Focus();
                }
            }
        }

        /// <summary>
        /// 次の入力可能列のKeyを取得する
        /// </summary>
        /// <param name="colIndex">チェック開始列index、Activation可能列を返す</param>
        /// <param name="rowIndex">チェック開始行index、Activation可能行を返す</param>
        /// <param name="isShift">true:シフトあり false:シフトなし</param>
        /// <param name="ActivationColIndex">Activation可能列Index</param>
        /// <param name="ActivationRowIndex">Activation可能行Index</param>
        /// <returns>Activation可能列のキー。ない場合はstring.Empty</returns>
        /// <remarks>
        /// <br>Note       : 次の入力可能列のKeyを取得を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/10/23</br>
        /// </remarks>
        private string GetNextFocusColumnKey(int colIndex, int rowIndex, bool isShift, out int ActivationColIndex, out int ActivationRowIndex)
        {
            ActivationColIndex = 0;
            ActivationRowIndex = 0;

            // 指定列の次の入力可能列を検索
            if (!isShift)
            {
                // シフト無
                for (int j = rowIndex; j < this.uGrid_PrintInfo.Rows.Count; j++)
                {
                    if (!this.uGrid_PrintInfo.Rows[j].IsFilteredOut)
                    {
                        if (j == rowIndex)
                        {
                            // 指定行は指定カラムから先をチェック
                            for (int i = colIndex + 1; i < this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            // 次行以降はカラムを順にチェック
                            for (int i = 0; i < this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // シフトあり
                for (int j = rowIndex; j >= 0; j--)
                {
                    if (!this.uGrid_PrintInfo.Rows[j].IsFilteredOut)
                    {
                        if (j == rowIndex)
                        {
                            for (int i = colIndex - 1; i >= 0; i--)
                            {
                                if (this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            for (int i = this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                            {

                                if (this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_PrintInfo.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer  : 李侠</br>
        /// <br>Date        : 2010/02/04</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンは隠れてます
            // ESCボタンで画面を終了する
            this.Close();
        }
        #endregion

        #region ■ publicメソッド ■
        /// <summary>
        /// 画面表示
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 画面表示時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/10/23</br>
        /// </remarks> 
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            // 画面表示
            return base.ShowDialog(owner);
        }
        #endregion

        // ---ADD zhujw　2014/06/05 ------------------------------------>>>>>
        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>fdsa
        /// <br>Note		: キーが押された時に発生します。</br>
        /// <br>Programmer	: zhujw</br>
        /// <br>Date		: 2014/06/04</br>
        /// </remarks>
        private void tEdit_SelectNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)10:
                case (char)13:

                    int selectNo = 0;
                    //空白や文字列が含まれる場合は1:優良を初期値としてセット
                    if (Int32.TryParse(this.tEdit_SelectNo.Text, out selectNo) == false)
                    {
                        this.tEdit_SelectNo.Text = "1";
                        break;
                    }
                    if (selectNo == 0)
                    {
                        // 確定処理を行う
                        this.SetPrintInfo(0);
                    }
                    else if (selectNo == 1)
                    {
                        // 確定処理を行う
                        this.SetPrintInfo(1);
                    }
                    else if (selectNo == 2)
                    {
                        if (_epPartsNoPrtCd == 1)
                        {
                            // 確定処理を行う
                            this.SetPrintInfo(2);
                        }
                        else
                        {
                            // 表示値を「1」とし、全選択状態とする
                            this.tEdit_SelectNo.Text = "1";
                            this.tEdit_SelectNo.Focus();
                        }
                    }
                    else
                    {
                        // 表示値を「1」とし、全選択状態とする
                        this.tEdit_SelectNo.Text = "1";
                        this.tEdit_SelectNo.Focus();
                    }
                    
                    break;
                default:
                    break;
            }
        }
        // ---ADD zhujw　2014/06/05 ------------------------------------<<<<<
   }
}