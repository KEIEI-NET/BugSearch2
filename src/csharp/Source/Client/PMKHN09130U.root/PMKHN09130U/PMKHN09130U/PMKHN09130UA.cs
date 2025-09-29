//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定UI：操作権限設定マスタ
// プログラム概要   : 操作権限設定マスタの更新を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/07/08  修正内容 : Mantis.15765　明細部並び順を表示順へ変更
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 操作権限設定フォーム
    /// </summary>
    public partial class PMKHN09130UA : Form, ISecurityManagementForm, ISecurityManagementSetting, IStatusBarShowable
    {
        #region <Const/>

        /// <summary>職種設定タブのキー</summary>
        private const string TAB_JOB_TYPE_SETTING_KEY = "TAB_JOB_TYPE_SETTING";

        /// <summary>雇用形態設定タブのキー</summary>
        private const string TAB_EMPLOYMENT_FORM_SETTING_KEY = "TAB_EMPLOYMENT_FORM_SETTING";

        /// <summary>従業員設定タブのキー</summary>
        private const string TAB_EMPLOYEE_SETTING_KEY = "TAB_EMPLOYEE_SETTING";

        /// <summary>許可するツールボタンのキー</summary>
        private const string BUTTON_TOOL_ADMIT_KEY = "Admit";

        /// <summary>許可する(ログ記録)ツールボタンのキー</summary>
        private const string BUTTON_TOOL_ADMIT_AND_WRITE_LOG_KEY = "AdmitAndWriteLog";

        /// <summary>許可しないツールボタンのキー</summary>
        private const string BUTTON_TOOL_NOT_ADMIT_KEY = "NotAdmit";

        #endregion  // <Const/>

        #region <Private Member/>
        OperationAuthoritySettingAcs _operationAuthoritySettingAcs;
        SettingDataSet.SettingDataTable _settingDataTable;

        private bool _dataChanged;
        #endregion

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMKHN09130UA()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            this._operationAuthoritySettingAcs = OperationAuthoritySettingAcs.Instance;
            this._settingDataTable = this._operationAuthoritySettingAcs.SettingSet.Setting;
            this._dataChanged = false;
        }

        #endregion  // <Constructor/>

        #region <ISecurityManagementForm メンバ/>

        /// <summary>
        /// 保存ボタンを表示するフラグ
        /// </summary>
        /// <value>保存ボタンを表示</value>
        public bool CanWrite
        {
            get { return true; }
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
        /// <remarks>
        /// リモート呼び出しによる書き込みを実行します。
        /// </remarks>
        /// <returns>成功時に 0(=(int)ResultCode.Normal) を返します。 </returns>
        public int Write()
        {
            return this._operationAuthoritySettingAcs.WriteOperationStDB();
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
            UpdateSettingGrid(CurrentFilter, CurrentSort);
        }

        #endregion  // <ISecurityManagementForm メンバ/>

        #region <ISecurityManagementSetting メンバ/>

        /// <summary>
        /// 引数OperationStに対応するグリッド行を選択状態にする処理を行います。
        /// </summary>
        /// <param name="operationSt">選択すべき行に対応するオペレーション設定情報</param>
        public void Select(OperationSt operationSt)
        {
            UltraGridRow selectedGridRow = (UltraGridRow)operationSt.SelectedGridRow;
            int selectedOperationStDiv = (int)selectedGridRow.Cells[(int)SettingDataSet.ClmIdx.OperationStDiv].Value;
            int selectedJobType = (int)selectedGridRow.Cells[(int)SettingDataSet.ClmIdx.AuthorityLevel1].Value;
            int selectedEmploymentForm = (int)selectedGridRow.Cells[(int)SettingDataSet.ClmIdx.AuthorityLevel2].Value;
            string selectedEmployeeCode = (string)selectedGridRow.Cells[(int)SettingDataSet.ClmIdx.EmployeeCode].Value;

            // 設定対象グリッドを選択
            if (selectedOperationStDiv.Equals((int)OperationSettingMasterDataSet.OperationStDiv.AuthorityLevel1))
            {
                this.ultraTabControl.Tabs[TAB_JOB_TYPE_SETTING_KEY].Selected = true;
                // TODO:もっと効率のよい検索
                for (int i = 0; i < this.jobTypeGrid.Rows.Count; i++)
                {
                    int jobType = (int)this.jobTypeGrid.Rows[i].Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
                    if (jobType.Equals(selectedJobType))
                    {
                        this.jobTypeGrid.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            else if (selectedOperationStDiv.Equals((int)OperationSettingMasterDataSet.OperationStDiv.AuthorityLevel2))
            {
                this.ultraTabControl.Tabs[TAB_EMPLOYMENT_FORM_SETTING_KEY].Selected = true;
                // TODO:もっと効率のよい検索
                for (int i = 0; i < this.employmentFormGrid.Rows.Count; i++)
                {
                    int employmentForm = (int)this.employmentFormGrid.Rows[i].Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
                    if (employmentForm.Equals(selectedEmploymentForm))
                    {
                        this.employmentFormGrid.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            else if (selectedOperationStDiv.Equals((int)OperationSettingMasterDataSet.OperationStDiv.EmployeeCode))
            {
                this.ultraTabControl.Tabs[TAB_EMPLOYEE_SETTING_KEY].Selected = true;
                // TODO:もっと効率のよい検索
                for (int i = 0; i < this.employeeGrid.Rows.Count; i++)
                {
                    string employeeCode = (string)this.employeeGrid.Rows[i].Cells[(int)EmployeeMasterDataSet.ClmIdx.EmployeeCode].Value;
                    if (employeeCode.Equals(selectedEmployeeCode))
                    {
                        this.employeeGrid.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            return; // UNDONE:グリッドのクリックイベントが発生しない？
#if false
            // 操作権限設定グリッドを選択
            int index = GetSettingGridIndexOf(selectedGridRow);
            if (index > 0)
            {
                this.settingGrid.Rows[index].Selected = true;
            }
            else
            {
                // TODO:該当行がない場合の処理（設計的にはありえない）
                Debug.Assert(false, "該当行がありません。");
            }
#endif
        }

#if false
        /// <summary>
        /// 該当するグリッド行のインデックスを取得します。
        /// </summary>
        /// <param name="gridRow">グリッド行</param>
        /// <returns>
        /// 該当するグリッド行のインデックス（該当する行がない場合、<code>-1</code>を返します。）
        /// </returns>
        [Obsolete("要改造：もっと効率のよい検索")]
        private int GetSettingGridIndexOf(UltraGridRow gridRow)
        {
            int selectedIndex = (int)Math.Abs((long)gridRow.Cells[(int)SettingDataSet.ClmIdx.Index].Value);
            int i = -1; // 該当行なし
            foreach (UltraGridRow row in this.settingGrid.Rows)
            {
                i++;
                int idx = (int)Math.Abs((long)row.Cells[(int)SettingDataSet.ClmIdx.Index].Value);
                if (selectedIndex.Equals(idx))
                {
                    return i;
                }
            }
            return -1;  // 該当行なし
        }
#endif
        #endregion  // <ISecurityManagementSetting メンバ/>

        #region <IStatusBarShowable メンバ/>

        /// <summary>ステータスバーに表示するイベント</summary>
        public event ValueIsInvalidEventHandler ShowStatusBar;

        #endregion  // <IStatusBarShowable メンバ/>

        #region <フォーム/>

        /// <summary>
        /// 操作権限設定フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMKHN09130UA_Load(object sender, EventArgs e)
        {
            this.settingDB = this._operationAuthoritySettingAcs.SettingSet;

#if false
            // 権限レベルマスタ系データグリッド（職種、雇用形態）
            string authorityLevelGridSort = AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd.ToString() + ADOUtil.DESC;
            // 職種データグリッド
            DataView jobTypeView = this._operationAuthoritySettingAcs.AuthorityLevelMasterDB.JobTypeTbl.DefaultView;
            jobTypeView.Sort = authorityLevelGridSort;
            this.jobTypeGrid.DataSource = jobTypeView;
            // 雇用形態データグリッド
            DataView employmentFormView = this._operationAuthoritySettingAcs.AuthorityLevelMasterDB.EmploymentFormTbl.DefaultView;
            employmentFormView.Sort = authorityLevelGridSort;
            this.employmentFormGrid.DataSource = employmentFormView;

            // 従業員データグリッド
            string employeeGridSort = EmployeeMasterDataSet.ClmIdx.BelongSectionCode.ToString();
            employeeGridSort += ADOUtil.COMMA;
            employeeGridSort += EmployeeMasterDataSet.ClmIdx.EmployeeCode.ToString();
            DataView employeeView = this._operationAuthoritySettingAcs.EmployeeMasterDB.Tbl.DefaultView;
            employeeView.Sort = employeeGridSort;
            this.employeeGrid.DataSource = employeeView;
#endif

            // 権限レベルマスタ系データグリッド（職種、雇用形態）
            //this.jobTypeGrid.DataSource = this._operationAuthoritySettingAcs.ActivitySettingTable;  // 2010/07/08 Del
            // 2010/07/08 Add >>>
            StringBuilder settingGridSort = new StringBuilder();
            settingGridSort.Append(SettingDataSet.ClmIdx.CategoryDspOdr);
            settingGridSort.Append(ADOUtil.COMMA);
            settingGridSort.Append(SettingDataSet.ClmIdx.PgDspOdr);
            settingGridSort.Append(ADOUtil.COMMA);
            settingGridSort.Append(SettingDataSet.ClmIdx.OperationDspOdr);
            DataView jobTypeView = this._operationAuthoritySettingAcs.ActivitySettingTable.DefaultView;
            jobTypeView.Sort = settingGridSort.ToString();
            this.jobTypeGrid.DataSource = jobTypeView;
            // 2010/07/08 Add <<<

            // 雇用形態データグリッド
            //this.employmentFormGrid.DataSource = this._operationAuthoritySettingAcs.AuthoritySettingTable;  // 2010/07/08 Del
            // 2010/07/08 Add >>>
            settingGridSort = new StringBuilder();
            settingGridSort.Append(SettingDataSet.ClmIdx.CategoryDspOdr);
            settingGridSort.Append(ADOUtil.COMMA);
            settingGridSort.Append(SettingDataSet.ClmIdx.PgDspOdr);
            settingGridSort.Append(ADOUtil.COMMA);
            settingGridSort.Append(SettingDataSet.ClmIdx.OperationDspOdr);
            DataView employmentFormView = this._operationAuthoritySettingAcs.AuthoritySettingTable.DefaultView;
            employmentFormView.Sort = settingGridSort.ToString();
            this.employmentFormGrid.DataSource = employmentFormView;
            // 2010/07/08 Add <<<
            
            // 従業員データグリッド
            //this.employeeGrid.DataSource = this._operationAuthoritySettingAcs.EmployeeSettingTable; // 2010/07/08 Del
            // 2010/07/08 Add >>>
            settingGridSort = new StringBuilder();
            settingGridSort.Append(SettingDataSet.ClmIdx.CategoryDspOdr);
            settingGridSort.Append(ADOUtil.COMMA);
            settingGridSort.Append(SettingDataSet.ClmIdx.PgDspOdr);
            settingGridSort.Append(ADOUtil.COMMA);
            settingGridSort.Append(SettingDataSet.ClmIdx.OperationDspOdr);
            DataView employeeView = this._operationAuthoritySettingAcs.EmployeeSettingTable.DefaultView;
            employeeView.Sort = settingGridSort.ToString();
            this.employeeGrid.DataSource = employeeView;
            // 2010/07/08 Add <<<

#if false
            // 操作権限設定データグリッド
            StringBuilder settingGridFilter = new StringBuilder();
            if (this.jobTypeGrid.Rows.Count > 0)
            {
                int jobType = (int)this.jobTypeGrid.ActiveRow.Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
                settingGridFilter.Append(SettingDataSet.ClmIdx.AuthorityLevel1);
                settingGridFilter.Append(ADOUtil.EQ);
                settingGridFilter.Append(jobType);
            }
            else if (this.employmentFormGrid.Rows.Count > 0)
            {
                int employmentForm = (int)this.employmentFormGrid.ActiveRow.Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
                settingGridFilter.Append(SettingDataSet.ClmIdx.AuthorityLevel2);
                settingGridFilter.Append(ADOUtil.EQ);
                settingGridFilter.Append(employmentForm);
            }
            else if (this.employeeGrid.Rows.Count > 0)
            {
                string employeeCode = (string)this.employmentFormGrid.ActiveRow.Cells[(int)EmployeeMasterDataSet.ClmIdx.EmployeeCode].Value;
                settingGridFilter.Append(SettingDataSet.ClmIdx.EmployeeCode);
                settingGridFilter.Append(ADOUtil.EQ);
                settingGridFilter.Append(employeeCode);
            }
            StringBuilder settingGridSort = new StringBuilder();
            settingGridSort.Append(SettingDataSet.ClmIdx.CategoryDspOdr);
            settingGridSort.Append(ADOUtil.COMMA);
            settingGridSort.Append(SettingDataSet.ClmIdx.PgDspOdr);
            settingGridSort.Append(ADOUtil.COMMA);
            settingGridSort.Append(SettingDataSet.ClmIdx.OperationDspOdr);
            UpdateSettingGrid(settingGridFilter.ToString(), settingGridSort.ToString());
#endif
        }

        # endregion // <フォーム/>

        #region <職種/>

        /// <summary>
        /// 職種データグリッドのInitializeLayoutイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void jobTypeGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
#if false
            // 列幅自動調整
            this.jobTypeGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // 表示するカラムを設定
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList = new List<Pair<int, string>>();
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelNm,
                GetAuthorityLevelName(AuthorityLevelMasterDataSet.AuthorityLevelDiv.JobType)
            ));
            FormControlUtil.SetDataGridColumnHidden(this.jobTypeGrid, columnIndexAndCaptionThatHiddenIsFalseList);

#endif

            // 列幅自動調整
            this.jobTypeGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            //this.jobTypeGrid.DisplayLayout.Scrollbars = Scrollbars.Horizontal;
            // バンドを取得
            UltraGridBand band = this.jobTypeGrid.DisplayLayout.Bands[0];

            // 表示するカラムを設定
            band.Columns[this._settingDataTable.CategoryCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.CategoryDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgIdColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationDspOdrColumn.ColumnName].Hidden = true;

            // 結合設定
            // カテゴリ
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            // 機能
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluator = new MergedCategoryPgCellEvaluator(this._settingDataTable);
            // 操作
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;


            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.Fixed = true;

            // 固定列区切り線設定
            this.jobTypeGrid.DisplayLayout.Override.FixedCellSeparatorColor = this.jobTypeGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;

            if (this.jobTypeGrid.Rows.Count > 0) this.jobTypeGrid.Rows[0].Selected = true;
        }

        /// <summary>
        /// 職種データグリッド DoubleClickCellイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void jobTypeGrid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            OperationLimit operationLimit = OperationAuthoritySettingAcs.GetNextOpertaionLimit((string)e.Cell.Value);
            this.SelectJobTypeSettingCell(e.Cell.Row.Index, e.Cell.Column.Key, operationLimit);
        }

        /// <summary>
        /// 職種グリッドの選択値変更処理
        /// </summary>
        private void SelectJobTypeSettingCell(int rowIndex, string columnKey, OperationLimit operationLimit)
        {
            if (this.jobTypeGrid.DisplayLayout.Bands[0].Columns[columnKey].Header.Fixed) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.jobTypeGrid.Rows[rowIndex];
            bool changed = this._operationAuthoritySettingAcs.ActivitySettingSelectValue((int)row.Cells[this._settingDataTable.CategoryCodeColumn.ColumnName].Value, (string)row.Cells[this._settingDataTable.PgIdColumn.ColumnName].Value, (int)row.Cells[this._settingDataTable.OperationCodeColumn.ColumnName].Value, columnKey, operationLimit);
            if (!_dataChanged) this._dataChanged = changed;
        }

        /// <summary>
        /// 職種グリッドの選択処理
        /// </summary>
        /// <param name="operationLimit">操作権限</param>
        private void SelectJobTypeSettingCells(OperationLimit operationLimit)
        {
            this.jobTypeGrid.BeginUpdate();
            foreach (UltraGridCell cell in this.jobTypeGrid.Selected.Cells)
            {
                SelectJobTypeSettingCell(cell.Row.Index, cell.Column.Key, operationLimit);
            }
            // add 2008.12.24 [8678]
            foreach (Infragistics.Win.UltraWinGrid.ColumnHeader col in this.jobTypeGrid.Selected.Columns)
            {
                foreach (UltraGridRow row in this.jobTypeGrid.Rows)
                {
                    SelectJobTypeSettingCell(row.Index, col.Column.Key, operationLimit);
                }
            }
            foreach (UltraGridRow row in this.jobTypeGrid.Selected.Rows)
            {
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (cell.Column.Index > 8)
                    {
                        SelectJobTypeSettingCell(cell.Row.Index, cell.Column.Key, operationLimit);
                    }
                }
            }
            // add 2008.12.24 [8678]
            this.jobTypeGrid.EndUpdate();
        }

          /// <summary>
        /// 職種データグリッドのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void jobTypeGrid_Click(object sender, EventArgs e)
        {
            int jobType = (int)this.jobTypeGrid.ActiveRow.Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
            UpdateGridByJobType(jobType);
        }

        /// <summary>
        /// 職種データグリッドのAfterSelectChangeイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void jobTypeGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            for (int i = 0; i < this.jobTypeGrid.Rows.Count; i++)
            {
                if (this.jobTypeGrid.Rows[i].Selected)
                {
                    int jobType = (int)this.jobTypeGrid.Rows[i].Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
                    UpdateGridByJobType(jobType);
                    break;
                }
            }
        }

        /// <summary>
        /// 職種(権限レベル1)で操作権限設定グリッドを更新します。
        /// </summary>
        /// <param name="jobType">職種(権限レベル1)</param>
        private void UpdateGridByJobType(int jobType)
        {
            StringBuilder rowFilter = new StringBuilder(
                GetBaseSettingGridRowFilter(OperationSettingMasterDataSet.OperationStDiv.AuthorityLevel1)
            );
            rowFilter.Append(ADOUtil.AND);
            rowFilter.Append(SettingDataSet.ClmIdx.AuthorityLevel1).Append(ADOUtil.EQ).Append(jobType);

            UpdateSettingGrid(rowFilter.ToString(), string.Empty);
        }

        #endregion  // <職種/>

        #region <雇用形態/>

        /// <summary>
        /// 雇用形態データグリッドのInitializeLayoutイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void employmentFormGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
#if false
            // 列幅自動調整
            this.employmentFormGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // 表示するカラムを設定
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList = new List<Pair<int, string>>();
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelNm,
                GetAuthorityLevelName(AuthorityLevelMasterDataSet.AuthorityLevelDiv.EmploymentForm)
            ));
            FormControlUtil.SetDataGridColumnHidden(this.employmentFormGrid, columnIndexAndCaptionThatHiddenIsFalseList);

#endif
            // 列幅自動調整
            this.employmentFormGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            //this.jobTypeGrid.DisplayLayout.Scrollbars = Scrollbars.Horizontal;
            // バンドを取得
            UltraGridBand band = this.employmentFormGrid.DisplayLayout.Bands[0];

            // 表示するカラムを設定
            band.Columns[this._settingDataTable.CategoryCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.CategoryDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgIdColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationDspOdrColumn.ColumnName].Hidden = true;

            // 結合設定
            // カテゴリ
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            // 機能
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluator = new MergedCategoryPgCellEvaluator(this._settingDataTable);
            // 操作
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;


            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.Fixed = true;

            // 固定列区切り線設定
            this.employmentFormGrid.DisplayLayout.Override.FixedCellSeparatorColor = this.employmentFormGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;

            if (this.employmentFormGrid.Rows.Count > 0) this.employmentFormGrid.Rows[0].Selected = true;
        }

        /// <summary>
        /// 雇用形態データグリッドのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void employmentFormGrid_Click(object sender, EventArgs e)
        {
            int employmentForm = (int)this.employmentFormGrid.ActiveRow.Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
            UpdateGridByEmploymentForm(employmentForm);
        }

        /// <summary>
        /// 雇用形態データグリッド DoubleClickCellイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void employmentFormGrid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            OperationLimit operationLimit = OperationAuthoritySettingAcs.GetNextOpertaionLimit((string)e.Cell.Value);
            this.SelectEmploymentFormSettingCell(e.Cell.Row.Index, e.Cell.Column.Key, operationLimit);
        }

        /// <summary>
        /// 雇用形態グリッドの選択値変更処理
        /// </summary>
        private void SelectEmploymentFormSettingCell(int rowIndex, string columnKey, OperationLimit operationLimit)
        {
            if (this.employmentFormGrid.DisplayLayout.Bands[0].Columns[columnKey].Header.Fixed) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.employmentFormGrid.Rows[rowIndex];

            bool changed = this._operationAuthoritySettingAcs.AuthoritySettingSelectValue((int)row.Cells[this._settingDataTable.CategoryCodeColumn.ColumnName].Value, (string)row.Cells[this._settingDataTable.PgIdColumn.ColumnName].Value, (int)row.Cells[this._settingDataTable.OperationCodeColumn.ColumnName].Value, columnKey, operationLimit);
            if (!_dataChanged) this._dataChanged = changed;
        }

        /// <summary>
        /// 雇用形態グリッドの選択処理（複数行）
        /// </summary>
        /// <param name="operationLimit">操作権限</param>
        private void SelectEmploymentFormSettingCells(OperationLimit operationLimit)
        {
            this.employmentFormGrid.BeginUpdate();
            foreach (UltraGridCell cell in this.employmentFormGrid.Selected.Cells)
            {
                SelectEmploymentFormSettingCell(cell.Row.Index, cell.Column.Key, operationLimit);
            }
            // add 2008.12.24 [8678]
            foreach (Infragistics.Win.UltraWinGrid.ColumnHeader col in this.employmentFormGrid.Selected.Columns)
            {
                foreach (UltraGridRow row in this.employmentFormGrid.Rows)
                {
                    SelectEmploymentFormSettingCell(row.Index, col.Column.Key, operationLimit);
                }
            }
            foreach (UltraGridRow row in this.employmentFormGrid.Selected.Rows)
            {
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (cell.Column.Index > 8)
                    {
                        SelectEmploymentFormSettingCell(cell.Row.Index, cell.Column.Key, operationLimit);
                    }
                }
            }
            // add 2008.12.24 [8678]
            this.employmentFormGrid.EndUpdate();
        }

        /// <summary>
        /// 雇用形態データグリッドのAfterSelectChangeイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void employmentFormGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            for (int i = 0; i < this.employmentFormGrid.Rows.Count; i++)
            {
                if (this.employmentFormGrid.Rows[i].Selected)
                {
                    int employmentForm = (int)this.employmentFormGrid.Rows[i].Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
                    UpdateGridByEmploymentForm(employmentForm);
                    break;
                }
            }
        }

        /// <summary>
        /// 雇用形態(権限レベル2)で操作権限設定グリッドを更新します。
        /// </summary>
        /// <param name="employmentForm">職種(権限レベル1)</param>
        private void UpdateGridByEmploymentForm(int employmentForm)
        {
            StringBuilder rowFilter = new StringBuilder(
                GetBaseSettingGridRowFilter(OperationSettingMasterDataSet.OperationStDiv.AuthorityLevel2)
            );
            rowFilter.Append(ADOUtil.AND);
            rowFilter.Append(SettingDataSet.ClmIdx.AuthorityLevel2).Append(ADOUtil.EQ).Append(employmentForm);

            UpdateSettingGrid(rowFilter.ToString(), string.Empty);
        }

        #endregion  // <雇用形態/>

        #region <従業員/>

        /// <summary>
        /// 従業員データグリッドのInitializeLayoutイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void employeeGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
#if false
            // 列幅自動調整
            this.employeeGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // 表示するカラムを設定
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList = new List<Pair<int, string>>();
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)EmployeeMasterDataSet.ClmIdx.BelongSectionName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)EmployeeMasterDataSet.ClmIdx.Name,
                string.Empty
            ));
            FormControlUtil.SetDataGridColumnHidden(this.employeeGrid, columnIndexAndCaptionThatHiddenIsFalseList);

            // 表示順を設定
            FormControlUtil.SetDataGridColumnHeaderVisiblePosition(this.employeeGrid, columnIndexAndCaptionThatHiddenIsFalseList);



            // バンドを取得
            UltraGridBand band = this.employeeGrid.DisplayLayout.Bands[0];

            // 結合設定
            int[] columnIndexArrayThatMergedCellStyleIsAlways = new int[] {
                (int)EmployeeMasterDataSet.ClmIdx.BelongSectionName
            };
            foreach (int iClm in columnIndexArrayThatMergedCellStyleIsAlways)
            {
                band.Columns[iClm].MergedCellStyle = MergedCellStyle.Always;
            }
#endif
            // 列幅自動調整
            this.employeeGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            //this.jobTypeGrid.DisplayLayout.Scrollbars = Scrollbars.Horizontal;
            // バンドを取得
            UltraGridBand band = this.employeeGrid.DisplayLayout.Bands[0];

            // 表示するカラムを設定
            band.Columns[this._settingDataTable.CategoryCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.CategoryDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgIdColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationDspOdrColumn.ColumnName].Hidden = true;

            // 結合設定
            // カテゴリ
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            // 機能
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluator = new MergedCategoryPgCellEvaluator(this._settingDataTable);
            // 操作
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;


            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.Fixed = true;

            // 固定列区切り線設定
            this.employeeGrid.DisplayLayout.Override.FixedCellSeparatorColor = this.employeeGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;

            if (this.employeeGrid.Rows.Count > 0) this.employeeGrid.Rows[0].Selected = true;
        }

        /// <summary>
        /// 従業員別設定グリッドのDoubleClickCellイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void employeeGrid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            OperationLimit operationLimit = OperationAuthoritySettingAcs.GetNextOpertaionLimit((string)e.Cell.Value);
            this.SelectEmployeeSettingCell(e.Cell.Row.Index, e.Cell.Column.Key, operationLimit);
        }

        /// <summary>
        /// 従業員別設定グリッドの選択値変更処理
        /// </summary>
        private void SelectEmployeeSettingCell(int rowIndex, string columnKey, OperationLimit operationLimit)
        {
            if (this.employeeGrid.DisplayLayout.Bands[0].Columns[columnKey].Header.Fixed) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.employeeGrid.Rows[rowIndex];

            bool changed = this._operationAuthoritySettingAcs.EmployeeSettingSelectValue((int)row.Cells[this._settingDataTable.CategoryCodeColumn.ColumnName].Value, (string)row.Cells[this._settingDataTable.PgIdColumn.ColumnName].Value, (int)row.Cells[this._settingDataTable.OperationCodeColumn.ColumnName].Value, columnKey, operationLimit);
            if (!_dataChanged) this._dataChanged = changed;
        }

        /// <summary>
        /// 従業員別設定グリッドの選択処理（複数行）
        /// </summary>
        /// <param name="operationLimit">操作権限</param>
        private void SelectEmployeeSettingCells(OperationLimit operationLimit)
        {
            this.employeeGrid.BeginUpdate();
            foreach (UltraGridCell cell in this.employeeGrid.Selected.Cells)
            {
                SelectEmployeeSettingCell(cell.Row.Index, cell.Column.Key, operationLimit);
            }
            // add 2008.12.24 [8678]
            foreach (Infragistics.Win.UltraWinGrid.ColumnHeader col in this.employeeGrid.Selected.Columns)
            {
                foreach (UltraGridRow row in this.employeeGrid.Rows)
                {
                    SelectEmployeeSettingCell(row.Index, col.Column.Key, operationLimit);
                }
            }
            foreach (UltraGridRow row in this.employeeGrid.Selected.Rows)
            {
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (cell.Column.Index > 8)
                    {
                        SelectEmployeeSettingCell(cell.Row.Index, cell.Column.Key, operationLimit);
                    }
                }
            }
            // add 2008.12.24 [8678]
            this.employeeGrid.EndUpdate();
        }

        /// <summary>
        /// 従業員データグリッドのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void employeeGrid_Click(object sender, EventArgs e)
        {
            string employeeCode = (string)this.employeeGrid.ActiveRow.Cells[EmployeeMasterDataSet.ClmIdx.EmployeeCode.ToString()].Value;
            UpdateGridByEmployeeCode(employeeCode);
        }

        /// <summary>
        /// 従業員データグリッドのAfterSelectChangeイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void employeeGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            for (int i = 0; i < this.employeeGrid.Rows.Count; i++)
            {
                if (this.employeeGrid.Rows[i].Selected)
                {
                    string employeeCode = (string)this.employeeGrid.Rows[i].Cells[EmployeeMasterDataSet.ClmIdx.EmployeeCode.ToString()].Value;
                    UpdateGridByEmployeeCode(employeeCode);
                    break;
                }
            }
        }

        /// <summary>
        /// 従業員コードで操作権限設定グリッドを更新します。
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        private void UpdateGridByEmployeeCode(string employeeCode)
        {
            StringBuilder rowFilter = new StringBuilder(
                GetBaseSettingGridRowFilter(OperationSettingMasterDataSet.OperationStDiv.EmployeeCode)
            );
            rowFilter.Append(ADOUtil.AND);
            rowFilter.Append(SettingDataSet.ClmIdx.EmployeeCode).Append(ADOUtil.EQ).Append(ADOUtil.GetString(employeeCode));

            UpdateSettingGrid(rowFilter.ToString(), string.Empty);
        }

        #endregion  // <従業員/>

        /// <summary>
        /// 基本となる操作権限設定データグリッドの行フィルタを取得します。
        /// </summary>
        /// <param name="operationStDiv">オペレーション設定区分</param>
        /// <returns>基本となる行フィルタ</returns>
        private static string GetBaseSettingGridRowFilter(OperationSettingMasterDataSet.OperationStDiv operationStDiv)
        {
            StringBuilder rowFilter = new StringBuilder();

            rowFilter.Append(SettingDataSet.ClmIdx.OperationStDiv);
            rowFilter.Append(ADOUtil.EQ);
            rowFilter.Append((int)operationStDiv);

            return rowFilter.ToString();
        }

        #region <セルの結合判定/>

        /// <summary>
        /// カテゴリ、機能セルの結合判定者クラス
        /// </summary>
        internal class MergedCategoryPgCellEvaluator : IMergedCellEvaluator
        {
            #region <グリッドにバインドしているテーブル/>

            /// <summary>グリッドにバインドしているテーブル</summary>
            private readonly SettingDataSet.SettingDataTable _settingTable;
            /// <summary>
            /// グリッドにバインドしているテーブルを取得します。
            /// </summary>
            private SettingDataSet.SettingDataTable SettingTable { get { return _settingTable; } }

            #endregion  // <グリッドにバインドしているテーブル/>

            #region <Constructor/>

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="settingTable">グリッドにバインドしているテーブル</param>
            public MergedCategoryPgCellEvaluator(SettingDataSet.SettingDataTable settingTable)
            {
                _settingTable = settingTable;
            }

            #endregion  // <Constructor/>

            /// <summary>
            /// 結合するか判定します。
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public bool ShouldCellsBeMerged(
                Infragistics.Win.UltraWinGrid.UltraGridRow row1,
                Infragistics.Win.UltraWinGrid.UltraGridRow row2,
                Infragistics.Win.UltraWinGrid.UltraGridColumn column
            )
            {
                if (
                    column.Key.Equals(SettingTable.CategoryNameColumn.ColumnName)
                        ||
                    column.Key.Equals(SettingTable.PgNameColumn.ColumnName)
                )
                {
                    string text1 = (string)row1.Cells[column.Key].Text;
                    string text2 = (string)row2.Cells[column.Key].Text;

                    // どちらかが空白なら結合しない
                    if (string.IsNullOrEmpty(text1)) return false;
                    if (string.IsNullOrEmpty(text2)) return false;

                    if (column.Key.Equals(SettingTable.CategoryNameColumn.ColumnName))
                    {
                        // カテゴリは両方同じ値なら結合する
                        if (text1.Equals(text2)) return true;
                    }
                    else
                    {
                        // 機能は カテゴリ + 機能 の値で結合する
                        string category1 = (string)row1.Cells[SettingTable.CategoryNameColumn.ColumnName].Text;
                        string category2 = (string)row2.Cells[SettingTable.CategoryNameColumn.ColumnName].Text;

                        string pg1 = category1.Trim() + text1.Trim();
                        string pg2 = category2.Trim() + text2.Trim();
                        if (pg1.Equals(pg2)) return true;
                    }
                }
                return false;
            }
        }

        #endregion  // <セルの結合判定/>

        #region <操作権限設定/>

        /// <summary>
        /// 現在の操作権限設定行を取得します。
        /// </summary>
        private SettingDataSet.SettingRow CurrentSettingDataRow
        {
            get
            {
#if false
                long currentIndex = Math.Abs((long)this.settingGrid.ActiveRow.Cells[(int)SettingDataSet.ClmIdx.Index].Value);
                return this.settingDB.Setting[(int)currentIndex - 1];   // TODO:データ量がintのサイズを超えると...
#endif
                return null;
            }
        }

        /// <summary>
        /// 操作権限設定データグリッドのInitializeLayoutイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void settingGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
                (int)SettingDataSet.ClmIdx.Admission,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.SettingApp,
                string.Empty
            ));

            #region <Debug/>

            AddGridColumnForDebug(columnIndexAndCaptionThatHiddenIsFalseList);

            #endregion  // <Debug/>

            FormControlUtil.SetDataGridColumnHidden(this.settingGrid, columnIndexAndCaptionThatHiddenIsFalseList);

            // バンドを取得
            UltraGridBand band = this.settingGrid.DisplayLayout.Bands[0];

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

            if (this.settingGrid.Rows.Count > 0) this.settingGrid.Rows[0].Selected = true;

            // 列幅自動調整
            this.settingGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // ヘッダー選択時のソートを禁止
            this.settingGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
#endif
        }

        ///// <summary>
        ///// 操作権限設定データグリッドのDoubleClickRowイベント
        ///// </summary>
        ///// <param name="sender">イベントソース</param>
        ///// <param name="e">イベントパラメータ</param>
        //private void settingGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        //{
        //    int operationLimit = ++CurrentSettingDataRow.OperationLimit;
        //    if (operationLimit > (int)OperationLimit.Disable)
        //    {
        //        operationLimit = (int)OperationLimit.EnableWithLog;
        //    }
        //    SetSettingState((OperationLimit)operationLimit);
        //}

        #region <現在のグリッド表示の条件/>

        /// <summary>現在のグリッド表示のフィルタ</summary>
        /// <remarks><c>UpdateSettingGrid()</c>メソッドで更新されます。</remarks>
        private string _currentFilter;
        /// <summary>
        /// 現在のグリッド表示のフィルタのアクセサ
        /// </summary>
        /// <value>現在のグリッド表示のフィルタ</value>
        private string CurrentFilter
        {
            get { return _currentFilter; }
            set { _currentFilter = value; }
        }

        /// <summary>現在のグリッド表示のソート</summary>
        /// <remarks><c>UpdateSettingGrid()</c>メソッドで更新されます。</remarks>
        private string _currentSort;
        /// <summary>
        /// 現在のグリッド表示のソートのアクセサ
        /// </summary>
        /// <value>現在のグリッド表示のソート</value>
        private string CurrentSort
        {
            get { return _currentSort; }
            set { _currentSort = value; }
        }

        #endregion  // <現在のグリッド表示の条件/>

        /// <summary>
        /// 操作権限設定データグリッドの表示を更新します。
        /// </summary>
        /// <param name="rowFilter">行フィルタ</param>
        /// <param name="sort">ソート</param>
        private void UpdateSettingGrid(
            string rowFilter,
            string sort
        )
        {
#if false
            DataView dataView = this._settingDataTable.DefaultView;

            if (!string.IsNullOrEmpty(rowFilter)) dataView.RowFilter = rowFilter;
            if (!string.IsNullOrEmpty(sort)) dataView.Sort = sort;

            this.settingGrid.DataSource = dataView;

            CurrentFilter   = rowFilter;
            CurrentSort     = sort;
#endif
        }

        #endregion  // <操作権限設定/>

        #region <設定対象タブ/>

        /// <summary>
        /// タブのSelectedTabChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ultraTabControl_SelectedTabChanged(
            object sender,
            Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e
        )
        {
            try
            {
                if (e.Tab.Key == TAB_EMPLOYEE_SETTING_KEY)
                {
                    if (this._dataChanged)
                    {
                        switch (e.PreviousSelectedTab.Key)
                        {
                            case TAB_JOB_TYPE_SETTING_KEY:
                                this._operationAuthoritySettingAcs.ActivitySettingToEmployeeSettingReflection();
                                break;

                            case TAB_EMPLOYMENT_FORM_SETTING_KEY:
                                this._operationAuthoritySettingAcs.AuthoritySettingToEmployeeSettingReflection();
                                break;
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                Debug.WriteLine("フォーム構築時は例外が発生します。");
            }
        }

        #endregion  // <設定対象タブ/>

        #region <ツールバー/>

        /// <summary>フレーム表示用エラーメッセージ</summary>
        private string _errorMessageForFrame;
        /// <summary>
        /// フレーム表示用エラーメッセージのアクセサ
        /// </summary>
        /// <value>フレーム表示用エラーメッセージ</value>
        private string ErrorMessageForFrame
        {
            get { return _errorMessageForFrame; }
            set { _errorMessageForFrame = value; }
        }

        /// <summary>
        /// ツールバーのToolClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void toolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case BUTTON_TOOL_ADMIT_KEY:
                    {
                        if (this.ultraTabControl.SelectedTab.Key == TAB_EMPLOYEE_SETTING_KEY)
                        {
                            this.SelectEmployeeSettingCells(OperationLimit.EnableWithLog);
                        }
                        else if (this.ultraTabControl.SelectedTab.Key == TAB_JOB_TYPE_SETTING_KEY)
                        {
                            this.SelectJobTypeSettingCells(OperationLimit.EnableWithLog);
                        }
                        else if (this.ultraTabControl.SelectedTab.Key == TAB_EMPLOYMENT_FORM_SETTING_KEY)
                        {
                            this.SelectEmploymentFormSettingCells(OperationLimit.EnableWithLog);
                        }
                        break;
                    }
                case BUTTON_TOOL_NOT_ADMIT_KEY:
                    {
                        if (this.ultraTabControl.SelectedTab.Key == TAB_EMPLOYEE_SETTING_KEY)
                        {
                            this.SelectEmployeeSettingCells(OperationLimit.Disable);
                        }
                        else if (this.ultraTabControl.SelectedTab.Key == TAB_JOB_TYPE_SETTING_KEY)
                        {
                            this.SelectJobTypeSettingCells(OperationLimit.Disable);
                        }
                        else if (this.ultraTabControl.SelectedTab.Key == TAB_EMPLOYMENT_FORM_SETTING_KEY)
                        {
                            this.SelectEmploymentFormSettingCells(OperationLimit.Disable);
                        }

                        break;
                    }
            }
#if false
            ErrorMessageForFrame = string.Empty;

            switch (e.Tool.Key)
            {
                case BUTTON_TOOL_ADMIT_KEY:
                {
                    SetSettingStateToSelectedRows(OperationLimit.Enable);
                    break;
                }
                case BUTTON_TOOL_ADMIT_AND_WRITE_LOG_KEY:
                {
                    SetSettingStateToSelectedRows(OperationLimit.EnableWithLog);
                    break;
                }
                case BUTTON_TOOL_NOT_ADMIT_KEY:
                {
                    SetSettingStateToSelectedRows(OperationLimit.Disable);
                    break;
                }
            }

            if (!string.IsNullOrEmpty(ErrorMessageForFrame)) ShowStatusBar(this, new StatusBarMsg(ErrorMessageForFrame));
#endif
        }
#if false
        /// <summary>
        /// 選択された行に対して操作権限設定の状態を設定します。
        /// </summary>
        /// <param name="operationLimit">操作権限</param>
        private void SetSettingStateToSelectedRows(OperationLimit operationLimit)
        {
            for (int i = 0; i < this.settingGrid.Selected.Rows.Count; i++)
            {
                this.settingGrid.Selected.Rows[i].Activate();
                SetSettingState(operationLimit);
            }
        }
#endif
        /// <summary>
        /// 操作権限設定の状態を設定します。
        /// </summary>
        /// <param name="operationLimit">操作権限</param>
        private void SetSettingState(OperationLimit operationLimit)
        {
            OperationLimit operationLimitOfAllCategoryOnGrid = GetOperationLimitOfAllCategoryOnGrid(
                CurrentSettingDataRow.CategoryCode,
                CurrentSettingDataRow.OperationCode
            );
            Debug.WriteLine(CurrentSettingDataRow.CategoryName + ":" + operationLimitOfAllCategoryOnGrid.ToString());

            SettingState settingState = null;
            switch (this.ultraTabControl.ActiveTab.Key)
            {
                case TAB_JOB_TYPE_SETTING_KEY:
                    settingState = new JobTypeSettingState(CurrentSettingDataRow);
                    break;
                case TAB_EMPLOYMENT_FORM_SETTING_KEY:
                    settingState = new EmploymentFormSettingState(CurrentSettingDataRow);
                    break;
                case TAB_EMPLOYEE_SETTING_KEY:
                    settingState = new EmployeeSettingState(CurrentSettingDataRow);
                    break;
            }
            settingState.OperationLimitOfAllcategoryOnGrid = operationLimitOfAllCategoryOnGrid;

            try
            {
                ShowStatusBar(this, new StatusBarMsg());

                settingState.OperationLimit = operationLimit;

                CurrentSettingDataRow.Admission = settingState.Admission;
                //CurrentSettingDataRow.SettingApp = settingState.SettingApp;
                CurrentSettingDataRow.OperationLimit = (int)settingState.OperationLimit;
                CurrentSettingDataRow.Limitation = settingState.Limitation;

                // 操作権限を変更した印をつける
                if (CurrentSettingDataRow.Index > 0)
                {
                    CurrentSettingDataRow.Index = (-1) * CurrentSettingDataRow.Index;
                }
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.Message);
                ErrorMessageForFrame = e.Message;
            }
        }

        /// <summary>
        /// カテゴリ全体の操作権限をグリッドより取得します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>カテゴリ全体の操作権限</returns>
        private OperationLimit GetOperationLimitOfAllCategoryOnGrid(
            int categoryCode,
            int operationCode
        )
        {
#if false
            foreach (UltraGridRow gridRow in this.settingGrid.Rows)
            {
                int categoryCodeOnGrid  = (int)gridRow.Cells[SettingDataSet.ClmIdx.CategoryCode.ToString()].Value;
                string pgIdOnGrid       = (string)gridRow.Cells[SettingDataSet.ClmIdx.PgId.ToString()].Value;
                int operationCodeOnGrid = (int)gridRow.Cells[SettingDataSet.ClmIdx.OperationCode.ToString()].Value;
                if (
                    categoryCodeOnGrid.Equals(categoryCode)
                        &&
                    string.IsNullOrEmpty(pgIdOnGrid)
                        &&
                    operationCodeOnGrid.Equals(operationCode)
                )
                {
                    return (OperationLimit)((int)gridRow.Cells[SettingDataSet.ClmIdx.OperationLimit.ToString()].Value);
                }
            }
#endif
            return OperationLimit.EnableWithLog;
        }

        # endregion // <ツールバー/>

        #region <Debug/>

        /// <summary>
        /// デバッグ用グリッド表示
        /// </summary>
        [Conditional("DEBUG")]
        private void AddGridColumnForDebug(IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList)
        {/*
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.PgId,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.OperationStDiv,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.AuthorityLevel1,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.AuthorityLevel2,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.EmployeeCode,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)SettingDataSet.ClmIdx.OperationLimit,
                string.Empty
            ));*/
        }

        #endregion  // <Debug/>
    }
}