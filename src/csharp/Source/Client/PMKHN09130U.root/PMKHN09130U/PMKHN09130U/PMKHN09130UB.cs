//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定UI：操作権限設定マスタ
// プログラム概要   : 操作権限設定マスタの取得、表示を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 操作権限一覧表示フォーム
    /// </summary>
    public partial class PMKHN09130UB : Form, ISecurityManagementForm, ISecurityManagementView
    {
        #region <Private Member/>
        OperationAuthoritySettingAcs _operationAuthoritySettingAcs;
        #endregion

        #region <ISecurityManagementForm メンバ/>

        /// <summary>
        /// 保存ボタンを表示するフラグ
        /// </summary>
        /// <value>保存ボタンを非表示</value>
        public bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// 表示更新ボタンを表示するフラグ
        /// </summary>
        /// <value>表示更新ボタンを非表示</value>
        public bool CanUpdateDisplay
        {
            get { return false; }
        }

        /// <summary>
        /// 保存ボタン押下時の処理を行います。
        /// </summary>
        /// <remarks>何もしません。</remarks>
        /// <returns>成功時に 0(=(int)ResultCode.Normal) を返します。 </returns>
        public int Write()
        {
            return (int)ResultCode.Normal;
        }

        /// <summary>
        /// 表示更新ボタン押下時の処理を行います。
        /// </summary>
        /// <remarks>
        /// 何もしません。
        /// </remarks>
        public void UpdateDisplay() { }

        /// <summary>
        /// 対応するタブがアクティブになった時の処理を行います。
        /// </summary>
        public void Active()
        {
            RefleshGrid();
        }

        #endregion  // <ISecurityManagementForm メンバ/>

        #region <ISecurityManagementView メンバ/>

        /// <summary>行ダブルクリックされたときに発生させるイベント</summary>
        public event GridSelectedEventHandler Selected;

        #endregion  // <ISecurityManagementView メンバ/>

        #region <Constructor/>

        /// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public PMKHN09130UB()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            this._operationAuthoritySettingAcs = OperationAuthoritySettingAcs.Instance;
        }

        #endregion  // <Constructor/>

        #region <フォーム/>

        /// <summary>
        /// 操作権限一覧表示フォームコントロールのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMKHN09130UB_Load(object sender, EventArgs e)
        {
            // 特になし
        }

        # endregion // <フォーム/>

        #region <グリッド/>

        /// <summary>
        /// グリッドのInitializeLayoutイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void viewGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
#if false
            // 表示するカラムを設定
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList = new List<Pair<int, string>>();
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.CategoryName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.PgName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.OperationName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.Limitation,
                string.Empty
            ));

            #region <Debug/>

            //#if DEBUG
            //    columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
            //        (int)SettingDataSet.ClmIdx.OperationCode,
            //        string.Empty
            //    ));
            //    columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
            //        (int)SettingDataSet.ClmIdx.OperationStDiv,
            //        string.Empty
            //    ));
            //    columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
            //        (int)SettingDataSet.ClmIdx.AuthorityLevel1,
            //        string.Empty
            //    ));
            //    columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
            //            (int)SettingDataSet.ClmIdx.AuthorityLevel2,
            //            string.Empty
            //    ));
            //    columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
            //            (int)SettingDataSet.ClmIdx.EmployeeCode,
            //            string.Empty
            //    ));
            //    columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
            //        (int)SettingDataSet.ClmIdx.OperationLimit,
            //        string.Empty
            //    ));
            //#endif

            #endregion // <Debug/>

            FormControlUtil.SetDataGridColumnHidden(this.viewGrid, columnIndexAndCaptionThatHiddenIsFalseList);

            // バンドを取得
            UltraGridBand band = this.viewGrid.DisplayLayout.Bands[0];

            // 結合設定
            int[] columnIndexArrayThatMergedCellStyleIsAlways = new int[] {
                (int)SettingDataSet.ClmIdx.CategoryName,
                (int)SettingDataSet.ClmIdx.PgName,
                (int)SettingDataSet.ClmIdx.OperationName
            };
            foreach (int iClm in columnIndexArrayThatMergedCellStyleIsAlways)
            {
                band.Columns[iClm].MergedCellStyle = MergedCellStyle.Always;
            }



            if (this.viewGrid.Rows.Count > 0)
            {
                this.viewGrid.Rows[0].Selected = true;
            }

            // 列幅自動調整
            this.viewGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // ヘッダー選択時のソートを禁止
            this.viewGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            #region <カスタマイズ用サンプル/>

            //// TODO:列幅
            //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Width = 90;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = 90;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Width = 200;

            //// TODO:表示順
            //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.VisiblePosition = 0;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Header.VisiblePosition = 1;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Header.VisiblePosition = 2;

            //// TODO:表示位置
            //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //// TODO:結合設定
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellAppearance.BackColor = Color.Lavender;
            //// --- ADD 2008/07/01 -------------------------------->>>>>
            ////band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            ////band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellEvaluator = new MergedCell();
            //// --- ADD 2008/07/01 --------------------------------<<<<< 

            //// TODO:結合設定
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellAppearance.BackColor = Color.Lavender;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellEvaluator = new MergedCell();

            //// TODO:結合設定
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellAppearance.BackColor = Color.Lavender;
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluator = new MergedCell();

            //// --- ADD 2008/07/01 -------------------------------->>>>>
            //// TODO:結合設定
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellAppearance.BackColor = Color.Lavender;
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellEvaluator = new MergedCell();
            //// --- ADD 2008/07/01 --------------------------------<<<<< 

            //// TODO:値リストを初期化し、グリッドへ追加します。
            //grid.DisplayLayout.ValueLists.Clear();
            //Infragistics.Win.ValueList vl1 = grid.DisplayLayout.ValueLists.Add();
            //vl1.ValueListItems.Add(0, "表示無");
            //vl1.ValueListItems.Add(1, "部品&結合");
            //vl1.ValueListItems.Add(2, "部品");
            //vl1.ValueListItems[1].Appearance.BackColor = Color.SkyBlue;
            //vl1.ValueListItems[1].Appearance.BackColor2 = Color.White;
            //vl1.ValueListItems[1].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //vl1.ValueListItems[2].Appearance.BackColor = Color.MediumAquamarine;
            //vl1.ValueListItems[2].Appearance.BackColor2 = Color.White;
            //vl1.ValueListItems[2].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].ValueList = vl1;
            //band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;


            //// TODO:キー動作マッピングを追加
            //grid.KeyActionMappings.Add(
            //    new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //        Keys.Enter,	//Enterキー
            //        Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
            //        0,
            //        Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
            //        Infragistics.Win.SpecialKeys.None,
            //        0)
            //    );

            #endregion  // <カスタマイズ用サンプル/>

#endif

            // 列幅自動調整
            this.viewGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // ヘッダー選択時のソートを禁止
            this.viewGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            UltraGridBand band = this.viewGrid.DisplayLayout.Bands[0];

            // 表示するカラムを設定
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelDivColumn.ColumnName].Hidden = true;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelColumn.ColumnName].Hidden = true;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.BelongSectionCodeColumn.ColumnName].Hidden = true;

            int index = 0;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelDivNameColumn.ColumnName].Header.VisiblePosition = index++;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelNameColumn.ColumnName].Header.VisiblePosition = index++;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.EmployeeCodeColumn.ColumnName].Header.VisiblePosition = index++;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.EmployeeNameColumn.ColumnName].Header.VisiblePosition = index++;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.BelongSectionNmColumn.ColumnName].Header.VisiblePosition = index++;
            
            // 結合設定
            // 区分
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelDivNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelDivNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            // ロール
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelNameColumn.ColumnName].CellAppearance.BackColor = Color.Lavender;
        }

        /// <summary>
        /// グリッドのDoubleClickRowイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void viewGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Selected(this, new OperationSt(e.Row));
        }

        /// <summary>
        /// グリッドを再表示します。
        /// </summary>
        private void RefleshGrid()
        {
            DataView dataView = this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.DefaultView;
            dataView.Sort = string.Empty;

            StringBuilder viewGridSort = new StringBuilder();
            viewGridSort.Append(this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelDivColumn.ColumnName);
            viewGridSort.Append(ADOUtil.COMMA);
            viewGridSort.Append(this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelColumn.ColumnName);
            viewGridSort.Append(ADOUtil.COMMA);
            viewGridSort.Append(this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.EmployeeCodeColumn.ColumnName);

            dataView.RowFilter = string.Empty;
            dataView.Sort = viewGridSort.ToString();

            this.viewGrid.DataSource = dataView;

#if false
            DataView dataView = this._operationAuthoritySettingAcs.ViewTable.DefaultView;
            dataView.RowFilter = string.Empty;

            StringBuilder sqlWhere = new StringBuilder();
            // HACK:ゴミ掃除
            sqlWhere.Append(SettingDataSet.ClmIdx.OperationLimit);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)OperationLimit.EnableWithLog);
            sqlWhere.Append(ADOUtil.OR);
            sqlWhere.Append(SettingDataSet.ClmIdx.OperationLimit);
            sqlWhere.Append(ADOUtil.EQ);
            sqlWhere.Append((int)OperationLimit.Disable);

            StringBuilder viewGridSort = new StringBuilder();
            viewGridSort.Append(SettingDataSet.ClmIdx.CategoryDspOdr);
            viewGridSort.Append(ADOUtil.COMMA);
            viewGridSort.Append(SettingDataSet.ClmIdx.PgDspOdr);
            viewGridSort.Append(ADOUtil.COMMA);
            viewGridSort.Append(SettingDataSet.ClmIdx.OperationDspOdr);

            dataView.RowFilter  = sqlWhere.ToString();
            dataView.Sort       = viewGridSort.ToString();

            this.viewGrid.DataSource = dataView;

            // 列幅自動調整
            this.viewGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
#endif
        }

        #endregion  // <グリッド/>
    }
}