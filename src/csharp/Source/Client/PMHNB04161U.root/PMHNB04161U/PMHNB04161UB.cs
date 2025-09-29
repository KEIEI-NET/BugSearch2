//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 担当者別実績照会
// プログラム概要   : 担当者別実績照会一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 担当者別実績照会コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 担当者別実績照会表示を行うコントロールクラスです。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public partial class PMHNB04161UB : UserControl
    {
        #region ■ Private Members

        /// <summary>担当者別実績照会データセット</summary>
        /// <remarks></remarks>
        private EmployeeResultsDataSet _dataSet;

        /// <summary>担当者別実績照会アクセス</summary>
        /// <remarks></remarks>
        private EmployeeResultsAcs _employeeResultsAcs;

        #endregion

        #region ■ Constroctors
        /// <summary>
        /// 担当者別実績照会クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 担当者別実績照会クラスコンストラクタです。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public PMHNB04161UB()
        {
            InitializeComponent();
            this._employeeResultsAcs = EmployeeResultsAcs.GetInstance();
            this._dataSet = this._employeeResultsAcs.DataSet;
            this.uGrid_Details.DataSource = this._dataSet.EmployeeResults;

        }
        #endregion

        #region ■ Event
        /// <summary>
        /// コントロールロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : コントロールロードイベントを行う</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void InputDetails_Load(object sender, EventArgs e)
        {
            // グリッド列初期設定処理
            this.InitialSettingGridCol(1);

            // グリッド行初期設定処理
            this.GridRowInitialSetting();

        }

        /// <summary>
        /// グリッド行初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールロードイベントを行う</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void GridRowInitialSetting()
        {
            this._dataSet.EmployeeResults.Rows.Clear();
        }

        /// <summary>
        /// グリッドの初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドの初期化イベントを行う</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.InitialSettingGridCol(1);

        }
        #endregion

        #region ■ Private Methods
        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列初期設定処理を行う</br>
        /// <br>Programer  : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public void InitialSettingGridCol(int flg)
        {
            const string moneyFormat = "#,##0;-#,##0;''";

            const string pctFormat = "0.00%;-0.00%;''";

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            band.UseRowLayout = true;
            int visiblePosition = 0;

            if (band == null)
            {
                return;
            }

            // --- ADD 2010/07/20-------------------------------->>>>>
            // 拠点コード
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Hidden = true;
            // 拠点名称
            band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Hidden = true;
            // 開始年月日
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Hidden = true;
            // 終了年月日
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Hidden = true;
            // --- ADD 2010/07/20--------------------------------<<<<<

            # region [カラム設定]
            //head
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Width = 30;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Header.Caption = "No.";
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].RowLayoutColumnInfo.OriginX = 0;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].RowLayoutColumnInfo.SpanX = 2;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].RowLayoutColumnInfo.SpanY = 4;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;


            //ｺｰﾄﾞ
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "ｺｰﾄﾞ";
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].RowLayoutColumnInfo.OriginX = 2;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;




            //売上金額
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Header.Caption = "売上金額";
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginX = 4;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;



            //返品額
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Header.Caption = "返品額";
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginX = 6;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //値引額
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Header.Caption = "値引額";
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginX = 8;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //純売上
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Header.Caption = "純売上";
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].RowLayoutColumnInfo.OriginX = 10;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;


            //伝票枚数

            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Hidden = false;
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Header.Caption = "伝票枚数";
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Header.Caption = string.Empty;
            }
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Width = 50;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].RowLayoutColumnInfo.OriginX = 12;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //売上目標
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Header.Caption = "売上目標額";
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].RowLayoutColumnInfo.OriginX = 14;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //売上構成
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Hidden = true;
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Hidden = false;
            }
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Header.Caption = "売上構成";
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Width = 50;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].RowLayoutColumnInfo.OriginX = 16;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].RowLayoutColumnInfo.OriginY = 2;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //名称
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "名称";
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 2;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //原価
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Header.Caption = "原価";
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].RowLayoutColumnInfo.OriginX = 4;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //返品率
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Header.Caption = "返品率";
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].RowLayoutColumnInfo.OriginX = 6;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //値引率
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Header.Caption = "値引率";
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].RowLayoutColumnInfo.OriginX = 8;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //粗利額
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Header.Caption = "粗利額";
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].RowLayoutColumnInfo.OriginX = 10;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //粗利率
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Header.Caption = "粗利率";
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].RowLayoutColumnInfo.OriginX = 12;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //目標達成率
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Header.Caption = "目標達成率";
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].RowLayoutColumnInfo.OriginX = 14;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //返品構成
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Hidden = true;
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Hidden = false;
            }
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Header.Caption = "返品構成";
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].RowLayoutColumnInfo.OriginX = 16;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].RowLayoutColumnInfo.OriginY = 4;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            # endregion

        }
        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// グリッド列初期設定処理(出力用)
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列初期設定処理を行う</br>
        /// <br>Programer  : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        // --- UPD 2010/09/09 ---------->>>>>
        //public void InitialSettingGridColForOutput(int flg)
        public void InitialSettingGridColForOutput(int flg, int referDiv)
        // --- UPD 2010/09/09 ----------<<<<<
        {
            const string moneyFormat = "#,##0;-#,##0;''";

            const string pctFormat = "0.00%;-0.00%;''";

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            band.UseRowLayout = false;
            int visiblePosition = 1;

            if (band == null)
            {
                return;
            }

            # region [カラム設定]

            //No.
            band.Columns[this._dataSet.EmployeeResults.HeaderColumn.ColumnName].Hidden = true;

            // --- UPD 2010/09/09 ---------->>>>>
            //拠点
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Hidden = false;
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Header.Caption = "拠点";
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Width = 150;
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //band.Columns[this._dataSet.EmployeeResults.SectionNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Header.Caption = "拠点";
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Width = 150;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SectionCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            // --- UPD 2010/09/09 ----------<<<<<


            //担当者ｺｰﾄﾞ
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Hidden = false;
            // --- UPD 2010/09/09 ---------->>>>>
            //band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "担当者";
            if (referDiv == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "担当者";
            }
            else if (referDiv == 2)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "受注者";
            }
            else if (referDiv == 3)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.Caption = "発行者";
            }
            // --- UPD 2010/09/09 ----------<<<<<
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.EmployeeCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            
            //担当者名
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Hidden = false;
            // --- UPD 2010/09/09 ---------->>>>>
            //band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "担当者名";
            if (referDiv == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "担当者名";
            }
            else if (referDiv == 2)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "受注者名";
            }
            else if (referDiv == 3)
            {
                band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.Caption = "発行者名";
            }
            // --- UPD 2010/09/09 ----------<<<<<
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Width = 420;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.EmployeeNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            
            //開始年月日
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Hidden = false;
            if (flg == 1)
                band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Header.Caption = "開始年月日";
            else
                band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Header.Caption = "開始年月";
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.DuringStColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //終了年月日
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Hidden = false;
            if (flg == 1)
                band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Header.Caption = "終了年月日";
            else
                band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Header.Caption = "終了年月";
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.DuringEdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //売上金額
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Header.Caption = "売上金額";
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.BackSalesTotalTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //返品額
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Header.Caption = "返品額";
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodSalesTotalTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //返品率
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Header.Caption = "返品率";
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //値引額
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Header.Caption = "値引額";
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.BackSalesDisTtlTaxExcColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            
            //値引率
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Header.Caption = "値引率";
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.DisTtlPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //純売上
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Header.Caption = "純売上";
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.PureSalesColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 伝票枚数を隠す
            band.Columns[this._dataSet.EmployeeResults.SlipNumCountColumn.ColumnName].Hidden = true;

            //売上目標
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Header.Caption = "売上目標額";
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.SalesTargetMoneyColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //目標達成率
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Header.Caption = "売上目標達成率";
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.TargetPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //粗利額
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Header.Caption = "粗利額";
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //粗利率
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Header.Caption = "粗利率";
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.GrossProfitPctColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //原価
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Header.Caption = "原価";
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Width = 130;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].Format = moneyFormat;
            band.Columns[this._dataSet.EmployeeResults.TotalCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //売上構成比
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Hidden = true;
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Hidden = false;
            }
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Header.Caption = "売上構成比";
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.SalesStructureColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //返品構成比
            if (flg == 1)
            {
                band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Hidden = true;
            }
            else
            {
                band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Hidden = false;
            }
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Header.Caption = "返品構成比";
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Format = pctFormat;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.EmployeeResults.RetGoodsStructureColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            # endregion

        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        #endregion

        #region ■ オフライン状態チェック処理

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う</br>
        /// <br>Programer  : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note       : リモート接続可能判定処理を行う</br>
        /// <br>Programer  : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}