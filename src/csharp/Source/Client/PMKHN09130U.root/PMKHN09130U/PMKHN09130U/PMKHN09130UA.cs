//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�UI�F���쌠���ݒ�}�X�^
// �v���O�����T�v   : ���쌠���ݒ�}�X�^�̍X�V���s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2010/07/08  �C�����e : Mantis.15765�@���ו����я���\�����֕ύX
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
    /// ���쌠���ݒ�t�H�[��
    /// </summary>
    public partial class PMKHN09130UA : Form, ISecurityManagementForm, ISecurityManagementSetting, IStatusBarShowable
    {
        #region <Const/>

        /// <summary>�E��ݒ�^�u�̃L�[</summary>
        private const string TAB_JOB_TYPE_SETTING_KEY = "TAB_JOB_TYPE_SETTING";

        /// <summary>�ٗp�`�Ԑݒ�^�u�̃L�[</summary>
        private const string TAB_EMPLOYMENT_FORM_SETTING_KEY = "TAB_EMPLOYMENT_FORM_SETTING";

        /// <summary>�]�ƈ��ݒ�^�u�̃L�[</summary>
        private const string TAB_EMPLOYEE_SETTING_KEY = "TAB_EMPLOYEE_SETTING";

        /// <summary>������c�[���{�^���̃L�[</summary>
        private const string BUTTON_TOOL_ADMIT_KEY = "Admit";

        /// <summary>������(���O�L�^)�c�[���{�^���̃L�[</summary>
        private const string BUTTON_TOOL_ADMIT_AND_WRITE_LOG_KEY = "AdmitAndWriteLog";

        /// <summary>�����Ȃ��c�[���{�^���̃L�[</summary>
        private const string BUTTON_TOOL_NOT_ADMIT_KEY = "NotAdmit";

        #endregion  // <Const/>

        #region <Private Member/>
        OperationAuthoritySettingAcs _operationAuthoritySettingAcs;
        SettingDataSet.SettingDataTable _settingDataTable;

        private bool _dataChanged;
        #endregion

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
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

        #region <ISecurityManagementForm �����o/>

        /// <summary>
        /// �ۑ��{�^����\������t���O
        /// </summary>
        /// <value>�ۑ��{�^����\��</value>
        public bool CanWrite
        {
            get { return true; }
        }

        /// <summary>
        /// �\���X�V�{�^����\������t���O
        /// </summary>
        /// <value>�\���X�V�{�^�����\��</value>
        public bool CanUpdateDisplay
        {
            get { return false; }
        }

        /// <summary>
        /// �ۑ��{�^���������̏������s���܂��B
        /// </summary>
        /// <remarks>
        /// �����[�g�Ăяo���ɂ�鏑�����݂����s���܂��B
        /// </remarks>
        /// <returns>�������� 0(=(int)ResultCode.Normal) ��Ԃ��܂��B </returns>
        public int Write()
        {
            return this._operationAuthoritySettingAcs.WriteOperationStDB();
        }

        /// <summary>
        /// �\���X�V�{�^���������̏������s���܂��B
        /// </summary>
        /// <remarks>
        /// �������܂���B
        /// </remarks>
        public void UpdateDisplay() { }

        /// <summary>
        /// �Ή�����^�u���A�N�e�B�u�ɂȂ������̏������s���܂��B
        /// </summary>
        public void Active()
        {
            UpdateSettingGrid(CurrentFilter, CurrentSort);
        }

        #endregion  // <ISecurityManagementForm �����o/>

        #region <ISecurityManagementSetting �����o/>

        /// <summary>
        /// ����OperationSt�ɑΉ�����O���b�h�s��I����Ԃɂ��鏈�����s���܂��B
        /// </summary>
        /// <param name="operationSt">�I�����ׂ��s�ɑΉ�����I�y���[�V�����ݒ���</param>
        public void Select(OperationSt operationSt)
        {
            UltraGridRow selectedGridRow = (UltraGridRow)operationSt.SelectedGridRow;
            int selectedOperationStDiv = (int)selectedGridRow.Cells[(int)SettingDataSet.ClmIdx.OperationStDiv].Value;
            int selectedJobType = (int)selectedGridRow.Cells[(int)SettingDataSet.ClmIdx.AuthorityLevel1].Value;
            int selectedEmploymentForm = (int)selectedGridRow.Cells[(int)SettingDataSet.ClmIdx.AuthorityLevel2].Value;
            string selectedEmployeeCode = (string)selectedGridRow.Cells[(int)SettingDataSet.ClmIdx.EmployeeCode].Value;

            // �ݒ�ΏۃO���b�h��I��
            if (selectedOperationStDiv.Equals((int)OperationSettingMasterDataSet.OperationStDiv.AuthorityLevel1))
            {
                this.ultraTabControl.Tabs[TAB_JOB_TYPE_SETTING_KEY].Selected = true;
                // TODO:�����ƌ����̂悢����
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
                // TODO:�����ƌ����̂悢����
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
                // TODO:�����ƌ����̂悢����
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
            return; // UNDONE:�O���b�h�̃N���b�N�C�x���g���������Ȃ��H
#if false
            // ���쌠���ݒ�O���b�h��I��
            int index = GetSettingGridIndexOf(selectedGridRow);
            if (index > 0)
            {
                this.settingGrid.Rows[index].Selected = true;
            }
            else
            {
                // TODO:�Y���s���Ȃ��ꍇ�̏����i�݌v�I�ɂ͂��肦�Ȃ��j
                Debug.Assert(false, "�Y���s������܂���B");
            }
#endif
        }

#if false
        /// <summary>
        /// �Y������O���b�h�s�̃C���f�b�N�X���擾���܂��B
        /// </summary>
        /// <param name="gridRow">�O���b�h�s</param>
        /// <returns>
        /// �Y������O���b�h�s�̃C���f�b�N�X�i�Y������s���Ȃ��ꍇ�A<code>-1</code>��Ԃ��܂��B�j
        /// </returns>
        [Obsolete("�v�����F�����ƌ����̂悢����")]
        private int GetSettingGridIndexOf(UltraGridRow gridRow)
        {
            int selectedIndex = (int)Math.Abs((long)gridRow.Cells[(int)SettingDataSet.ClmIdx.Index].Value);
            int i = -1; // �Y���s�Ȃ�
            foreach (UltraGridRow row in this.settingGrid.Rows)
            {
                i++;
                int idx = (int)Math.Abs((long)row.Cells[(int)SettingDataSet.ClmIdx.Index].Value);
                if (selectedIndex.Equals(idx))
                {
                    return i;
                }
            }
            return -1;  // �Y���s�Ȃ�
        }
#endif
        #endregion  // <ISecurityManagementSetting �����o/>

        #region <IStatusBarShowable �����o/>

        /// <summary>�X�e�[�^�X�o�[�ɕ\������C�x���g</summary>
        public event ValueIsInvalidEventHandler ShowStatusBar;

        #endregion  // <IStatusBarShowable �����o/>

        #region <�t�H�[��/>

        /// <summary>
        /// ���쌠���ݒ�t�H�[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMKHN09130UA_Load(object sender, EventArgs e)
        {
            this.settingDB = this._operationAuthoritySettingAcs.SettingSet;

#if false
            // �������x���}�X�^�n�f�[�^�O���b�h�i�E��A�ٗp�`�ԁj
            string authorityLevelGridSort = AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd.ToString() + ADOUtil.DESC;
            // �E��f�[�^�O���b�h
            DataView jobTypeView = this._operationAuthoritySettingAcs.AuthorityLevelMasterDB.JobTypeTbl.DefaultView;
            jobTypeView.Sort = authorityLevelGridSort;
            this.jobTypeGrid.DataSource = jobTypeView;
            // �ٗp�`�ԃf�[�^�O���b�h
            DataView employmentFormView = this._operationAuthoritySettingAcs.AuthorityLevelMasterDB.EmploymentFormTbl.DefaultView;
            employmentFormView.Sort = authorityLevelGridSort;
            this.employmentFormGrid.DataSource = employmentFormView;

            // �]�ƈ��f�[�^�O���b�h
            string employeeGridSort = EmployeeMasterDataSet.ClmIdx.BelongSectionCode.ToString();
            employeeGridSort += ADOUtil.COMMA;
            employeeGridSort += EmployeeMasterDataSet.ClmIdx.EmployeeCode.ToString();
            DataView employeeView = this._operationAuthoritySettingAcs.EmployeeMasterDB.Tbl.DefaultView;
            employeeView.Sort = employeeGridSort;
            this.employeeGrid.DataSource = employeeView;
#endif

            // �������x���}�X�^�n�f�[�^�O���b�h�i�E��A�ٗp�`�ԁj
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

            // �ٗp�`�ԃf�[�^�O���b�h
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
            
            // �]�ƈ��f�[�^�O���b�h
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
            // ���쌠���ݒ�f�[�^�O���b�h
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

        # endregion // <�t�H�[��/>

        #region <�E��/>

        /// <summary>
        /// �E��f�[�^�O���b�h��InitializeLayout�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void jobTypeGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
#if false
            // �񕝎�������
            this.jobTypeGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // �\������J������ݒ�
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList = new List<Pair<int, string>>();
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelNm,
                GetAuthorityLevelName(AuthorityLevelMasterDataSet.AuthorityLevelDiv.JobType)
            ));
            FormControlUtil.SetDataGridColumnHidden(this.jobTypeGrid, columnIndexAndCaptionThatHiddenIsFalseList);

#endif

            // �񕝎�������
            this.jobTypeGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            //this.jobTypeGrid.DisplayLayout.Scrollbars = Scrollbars.Horizontal;
            // �o���h���擾
            UltraGridBand band = this.jobTypeGrid.DisplayLayout.Bands[0];

            // �\������J������ݒ�
            band.Columns[this._settingDataTable.CategoryCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.CategoryDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgIdColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationDspOdrColumn.ColumnName].Hidden = true;

            // �����ݒ�
            // �J�e�S��
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            // �@�\
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluator = new MergedCategoryPgCellEvaluator(this._settingDataTable);
            // ����
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;


            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.Fixed = true;

            // �Œ���؂���ݒ�
            this.jobTypeGrid.DisplayLayout.Override.FixedCellSeparatorColor = this.jobTypeGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;

            if (this.jobTypeGrid.Rows.Count > 0) this.jobTypeGrid.Rows[0].Selected = true;
        }

        /// <summary>
        /// �E��f�[�^�O���b�h DoubleClickCell�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void jobTypeGrid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            OperationLimit operationLimit = OperationAuthoritySettingAcs.GetNextOpertaionLimit((string)e.Cell.Value);
            this.SelectJobTypeSettingCell(e.Cell.Row.Index, e.Cell.Column.Key, operationLimit);
        }

        /// <summary>
        /// �E��O���b�h�̑I��l�ύX����
        /// </summary>
        private void SelectJobTypeSettingCell(int rowIndex, string columnKey, OperationLimit operationLimit)
        {
            if (this.jobTypeGrid.DisplayLayout.Bands[0].Columns[columnKey].Header.Fixed) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.jobTypeGrid.Rows[rowIndex];
            bool changed = this._operationAuthoritySettingAcs.ActivitySettingSelectValue((int)row.Cells[this._settingDataTable.CategoryCodeColumn.ColumnName].Value, (string)row.Cells[this._settingDataTable.PgIdColumn.ColumnName].Value, (int)row.Cells[this._settingDataTable.OperationCodeColumn.ColumnName].Value, columnKey, operationLimit);
            if (!_dataChanged) this._dataChanged = changed;
        }

        /// <summary>
        /// �E��O���b�h�̑I������
        /// </summary>
        /// <param name="operationLimit">���쌠��</param>
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
        /// �E��f�[�^�O���b�h��Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void jobTypeGrid_Click(object sender, EventArgs e)
        {
            int jobType = (int)this.jobTypeGrid.ActiveRow.Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
            UpdateGridByJobType(jobType);
        }

        /// <summary>
        /// �E��f�[�^�O���b�h��AfterSelectChange�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
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
        /// �E��(�������x��1)�ő��쌠���ݒ�O���b�h���X�V���܂��B
        /// </summary>
        /// <param name="jobType">�E��(�������x��1)</param>
        private void UpdateGridByJobType(int jobType)
        {
            StringBuilder rowFilter = new StringBuilder(
                GetBaseSettingGridRowFilter(OperationSettingMasterDataSet.OperationStDiv.AuthorityLevel1)
            );
            rowFilter.Append(ADOUtil.AND);
            rowFilter.Append(SettingDataSet.ClmIdx.AuthorityLevel1).Append(ADOUtil.EQ).Append(jobType);

            UpdateSettingGrid(rowFilter.ToString(), string.Empty);
        }

        #endregion  // <�E��/>

        #region <�ٗp�`��/>

        /// <summary>
        /// �ٗp�`�ԃf�[�^�O���b�h��InitializeLayout�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void employmentFormGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
#if false
            // �񕝎�������
            this.employmentFormGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // �\������J������ݒ�
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList = new List<Pair<int, string>>();
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelNm,
                GetAuthorityLevelName(AuthorityLevelMasterDataSet.AuthorityLevelDiv.EmploymentForm)
            ));
            FormControlUtil.SetDataGridColumnHidden(this.employmentFormGrid, columnIndexAndCaptionThatHiddenIsFalseList);

#endif
            // �񕝎�������
            this.employmentFormGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            //this.jobTypeGrid.DisplayLayout.Scrollbars = Scrollbars.Horizontal;
            // �o���h���擾
            UltraGridBand band = this.employmentFormGrid.DisplayLayout.Bands[0];

            // �\������J������ݒ�
            band.Columns[this._settingDataTable.CategoryCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.CategoryDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgIdColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationDspOdrColumn.ColumnName].Hidden = true;

            // �����ݒ�
            // �J�e�S��
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            // �@�\
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluator = new MergedCategoryPgCellEvaluator(this._settingDataTable);
            // ����
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;


            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.Fixed = true;

            // �Œ���؂���ݒ�
            this.employmentFormGrid.DisplayLayout.Override.FixedCellSeparatorColor = this.employmentFormGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;

            if (this.employmentFormGrid.Rows.Count > 0) this.employmentFormGrid.Rows[0].Selected = true;
        }

        /// <summary>
        /// �ٗp�`�ԃf�[�^�O���b�h��Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void employmentFormGrid_Click(object sender, EventArgs e)
        {
            int employmentForm = (int)this.employmentFormGrid.ActiveRow.Cells[(int)AuthorityLevelMasterDataSet.ClmIdx.AuthorityLevelCd].Value;
            UpdateGridByEmploymentForm(employmentForm);
        }

        /// <summary>
        /// �ٗp�`�ԃf�[�^�O���b�h DoubleClickCell�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void employmentFormGrid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            OperationLimit operationLimit = OperationAuthoritySettingAcs.GetNextOpertaionLimit((string)e.Cell.Value);
            this.SelectEmploymentFormSettingCell(e.Cell.Row.Index, e.Cell.Column.Key, operationLimit);
        }

        /// <summary>
        /// �ٗp�`�ԃO���b�h�̑I��l�ύX����
        /// </summary>
        private void SelectEmploymentFormSettingCell(int rowIndex, string columnKey, OperationLimit operationLimit)
        {
            if (this.employmentFormGrid.DisplayLayout.Bands[0].Columns[columnKey].Header.Fixed) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.employmentFormGrid.Rows[rowIndex];

            bool changed = this._operationAuthoritySettingAcs.AuthoritySettingSelectValue((int)row.Cells[this._settingDataTable.CategoryCodeColumn.ColumnName].Value, (string)row.Cells[this._settingDataTable.PgIdColumn.ColumnName].Value, (int)row.Cells[this._settingDataTable.OperationCodeColumn.ColumnName].Value, columnKey, operationLimit);
            if (!_dataChanged) this._dataChanged = changed;
        }

        /// <summary>
        /// �ٗp�`�ԃO���b�h�̑I�������i�����s�j
        /// </summary>
        /// <param name="operationLimit">���쌠��</param>
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
        /// �ٗp�`�ԃf�[�^�O���b�h��AfterSelectChange�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
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
        /// �ٗp�`��(�������x��2)�ő��쌠���ݒ�O���b�h���X�V���܂��B
        /// </summary>
        /// <param name="employmentForm">�E��(�������x��1)</param>
        private void UpdateGridByEmploymentForm(int employmentForm)
        {
            StringBuilder rowFilter = new StringBuilder(
                GetBaseSettingGridRowFilter(OperationSettingMasterDataSet.OperationStDiv.AuthorityLevel2)
            );
            rowFilter.Append(ADOUtil.AND);
            rowFilter.Append(SettingDataSet.ClmIdx.AuthorityLevel2).Append(ADOUtil.EQ).Append(employmentForm);

            UpdateSettingGrid(rowFilter.ToString(), string.Empty);
        }

        #endregion  // <�ٗp�`��/>

        #region <�]�ƈ�/>

        /// <summary>
        /// �]�ƈ��f�[�^�O���b�h��InitializeLayout�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void employeeGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
#if false
            // �񕝎�������
            this.employeeGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // �\������J������ݒ�
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

            // �\������ݒ�
            FormControlUtil.SetDataGridColumnHeaderVisiblePosition(this.employeeGrid, columnIndexAndCaptionThatHiddenIsFalseList);



            // �o���h���擾
            UltraGridBand band = this.employeeGrid.DisplayLayout.Bands[0];

            // �����ݒ�
            int[] columnIndexArrayThatMergedCellStyleIsAlways = new int[] {
                (int)EmployeeMasterDataSet.ClmIdx.BelongSectionName
            };
            foreach (int iClm in columnIndexArrayThatMergedCellStyleIsAlways)
            {
                band.Columns[iClm].MergedCellStyle = MergedCellStyle.Always;
            }
#endif
            // �񕝎�������
            this.employeeGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            //this.jobTypeGrid.DisplayLayout.Scrollbars = Scrollbars.Horizontal;
            // �o���h���擾
            UltraGridBand band = this.employeeGrid.DisplayLayout.Bands[0];

            // �\������J������ݒ�
            band.Columns[this._settingDataTable.CategoryCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.CategoryDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgIdColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.PgDspOdrColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._settingDataTable.OperationDspOdrColumn.ColumnName].Hidden = true;

            // �����ݒ�
            // �J�e�S��
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            // �@�\
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].MergedCellEvaluator = new MergedCategoryPgCellEvaluator(this._settingDataTable);
            // ����
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;


            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            band.Columns[this._settingDataTable.CategoryNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.PgNameColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._settingDataTable.OperationNameColumn.ColumnName].Header.Fixed = true;

            // �Œ���؂���ݒ�
            this.employeeGrid.DisplayLayout.Override.FixedCellSeparatorColor = this.employeeGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;

            if (this.employeeGrid.Rows.Count > 0) this.employeeGrid.Rows[0].Selected = true;
        }

        /// <summary>
        /// �]�ƈ��ʐݒ�O���b�h��DoubleClickCell�C�x���g�n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void employeeGrid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            OperationLimit operationLimit = OperationAuthoritySettingAcs.GetNextOpertaionLimit((string)e.Cell.Value);
            this.SelectEmployeeSettingCell(e.Cell.Row.Index, e.Cell.Column.Key, operationLimit);
        }

        /// <summary>
        /// �]�ƈ��ʐݒ�O���b�h�̑I��l�ύX����
        /// </summary>
        private void SelectEmployeeSettingCell(int rowIndex, string columnKey, OperationLimit operationLimit)
        {
            if (this.employeeGrid.DisplayLayout.Bands[0].Columns[columnKey].Header.Fixed) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.employeeGrid.Rows[rowIndex];

            bool changed = this._operationAuthoritySettingAcs.EmployeeSettingSelectValue((int)row.Cells[this._settingDataTable.CategoryCodeColumn.ColumnName].Value, (string)row.Cells[this._settingDataTable.PgIdColumn.ColumnName].Value, (int)row.Cells[this._settingDataTable.OperationCodeColumn.ColumnName].Value, columnKey, operationLimit);
            if (!_dataChanged) this._dataChanged = changed;
        }

        /// <summary>
        /// �]�ƈ��ʐݒ�O���b�h�̑I�������i�����s�j
        /// </summary>
        /// <param name="operationLimit">���쌠��</param>
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
        /// �]�ƈ��f�[�^�O���b�h��Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void employeeGrid_Click(object sender, EventArgs e)
        {
            string employeeCode = (string)this.employeeGrid.ActiveRow.Cells[EmployeeMasterDataSet.ClmIdx.EmployeeCode.ToString()].Value;
            UpdateGridByEmployeeCode(employeeCode);
        }

        /// <summary>
        /// �]�ƈ��f�[�^�O���b�h��AfterSelectChange�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
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
        /// �]�ƈ��R�[�h�ő��쌠���ݒ�O���b�h���X�V���܂��B
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        private void UpdateGridByEmployeeCode(string employeeCode)
        {
            StringBuilder rowFilter = new StringBuilder(
                GetBaseSettingGridRowFilter(OperationSettingMasterDataSet.OperationStDiv.EmployeeCode)
            );
            rowFilter.Append(ADOUtil.AND);
            rowFilter.Append(SettingDataSet.ClmIdx.EmployeeCode).Append(ADOUtil.EQ).Append(ADOUtil.GetString(employeeCode));

            UpdateSettingGrid(rowFilter.ToString(), string.Empty);
        }

        #endregion  // <�]�ƈ�/>

        /// <summary>
        /// ��{�ƂȂ鑀�쌠���ݒ�f�[�^�O���b�h�̍s�t�B���^���擾���܂��B
        /// </summary>
        /// <param name="operationStDiv">�I�y���[�V�����ݒ�敪</param>
        /// <returns>��{�ƂȂ�s�t�B���^</returns>
        private static string GetBaseSettingGridRowFilter(OperationSettingMasterDataSet.OperationStDiv operationStDiv)
        {
            StringBuilder rowFilter = new StringBuilder();

            rowFilter.Append(SettingDataSet.ClmIdx.OperationStDiv);
            rowFilter.Append(ADOUtil.EQ);
            rowFilter.Append((int)operationStDiv);

            return rowFilter.ToString();
        }

        #region <�Z���̌�������/>

        /// <summary>
        /// �J�e�S���A�@�\�Z���̌�������҃N���X
        /// </summary>
        internal class MergedCategoryPgCellEvaluator : IMergedCellEvaluator
        {
            #region <�O���b�h�Ƀo�C���h���Ă���e�[�u��/>

            /// <summary>�O���b�h�Ƀo�C���h���Ă���e�[�u��</summary>
            private readonly SettingDataSet.SettingDataTable _settingTable;
            /// <summary>
            /// �O���b�h�Ƀo�C���h���Ă���e�[�u�����擾���܂��B
            /// </summary>
            private SettingDataSet.SettingDataTable SettingTable { get { return _settingTable; } }

            #endregion  // <�O���b�h�Ƀo�C���h���Ă���e�[�u��/>

            #region <Constructor/>

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            /// <param name="settingTable">�O���b�h�Ƀo�C���h���Ă���e�[�u��</param>
            public MergedCategoryPgCellEvaluator(SettingDataSet.SettingDataTable settingTable)
            {
                _settingTable = settingTable;
            }

            #endregion  // <Constructor/>

            /// <summary>
            /// �������邩���肵�܂��B
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

                    // �ǂ��炩���󔒂Ȃ猋�����Ȃ�
                    if (string.IsNullOrEmpty(text1)) return false;
                    if (string.IsNullOrEmpty(text2)) return false;

                    if (column.Key.Equals(SettingTable.CategoryNameColumn.ColumnName))
                    {
                        // �J�e�S���͗��������l�Ȃ猋������
                        if (text1.Equals(text2)) return true;
                    }
                    else
                    {
                        // �@�\�� �J�e�S�� + �@�\ �̒l�Ō�������
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

        #endregion  // <�Z���̌�������/>

        #region <���쌠���ݒ�/>

        /// <summary>
        /// ���݂̑��쌠���ݒ�s���擾���܂��B
        /// </summary>
        private SettingDataSet.SettingRow CurrentSettingDataRow
        {
            get
            {
#if false
                long currentIndex = Math.Abs((long)this.settingGrid.ActiveRow.Cells[(int)SettingDataSet.ClmIdx.Index].Value);
                return this.settingDB.Setting[(int)currentIndex - 1];   // TODO:�f�[�^�ʂ�int�̃T�C�Y�𒴂����...
#endif
                return null;
            }
        }

        /// <summary>
        /// ���쌠���ݒ�f�[�^�O���b�h��InitializeLayout�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void settingGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
#if false
            // �\������J������ݒ�
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

            // �o���h���擾
            UltraGridBand band = this.settingGrid.DisplayLayout.Bands[0];

            // �����ݒ�
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

            // �񕝎�������
            this.settingGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // �w�b�_�[�I�����̃\�[�g���֎~
            this.settingGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
#endif
        }

        ///// <summary>
        ///// ���쌠���ݒ�f�[�^�O���b�h��DoubleClickRow�C�x���g
        ///// </summary>
        ///// <param name="sender">�C�x���g�\�[�X</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        //private void settingGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        //{
        //    int operationLimit = ++CurrentSettingDataRow.OperationLimit;
        //    if (operationLimit > (int)OperationLimit.Disable)
        //    {
        //        operationLimit = (int)OperationLimit.EnableWithLog;
        //    }
        //    SetSettingState((OperationLimit)operationLimit);
        //}

        #region <���݂̃O���b�h�\���̏���/>

        /// <summary>���݂̃O���b�h�\���̃t�B���^</summary>
        /// <remarks><c>UpdateSettingGrid()</c>���\�b�h�ōX�V����܂��B</remarks>
        private string _currentFilter;
        /// <summary>
        /// ���݂̃O���b�h�\���̃t�B���^�̃A�N�Z�T
        /// </summary>
        /// <value>���݂̃O���b�h�\���̃t�B���^</value>
        private string CurrentFilter
        {
            get { return _currentFilter; }
            set { _currentFilter = value; }
        }

        /// <summary>���݂̃O���b�h�\���̃\�[�g</summary>
        /// <remarks><c>UpdateSettingGrid()</c>���\�b�h�ōX�V����܂��B</remarks>
        private string _currentSort;
        /// <summary>
        /// ���݂̃O���b�h�\���̃\�[�g�̃A�N�Z�T
        /// </summary>
        /// <value>���݂̃O���b�h�\���̃\�[�g</value>
        private string CurrentSort
        {
            get { return _currentSort; }
            set { _currentSort = value; }
        }

        #endregion  // <���݂̃O���b�h�\���̏���/>

        /// <summary>
        /// ���쌠���ݒ�f�[�^�O���b�h�̕\�����X�V���܂��B
        /// </summary>
        /// <param name="rowFilter">�s�t�B���^</param>
        /// <param name="sort">�\�[�g</param>
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

        #endregion  // <���쌠���ݒ�/>

        #region <�ݒ�Ώۃ^�u/>

        /// <summary>
        /// �^�u��SelectedTabChanged�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
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
                Debug.WriteLine("�t�H�[���\�z���͗�O���������܂��B");
            }
        }

        #endregion  // <�ݒ�Ώۃ^�u/>

        #region <�c�[���o�[/>

        /// <summary>�t���[���\���p�G���[���b�Z�[�W</summary>
        private string _errorMessageForFrame;
        /// <summary>
        /// �t���[���\���p�G���[���b�Z�[�W�̃A�N�Z�T
        /// </summary>
        /// <value>�t���[���\���p�G���[���b�Z�[�W</value>
        private string ErrorMessageForFrame
        {
            get { return _errorMessageForFrame; }
            set { _errorMessageForFrame = value; }
        }

        /// <summary>
        /// �c�[���o�[��ToolClick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
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
        /// �I�����ꂽ�s�ɑ΂��đ��쌠���ݒ�̏�Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="operationLimit">���쌠��</param>
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
        /// ���쌠���ݒ�̏�Ԃ�ݒ肵�܂��B
        /// </summary>
        /// <param name="operationLimit">���쌠��</param>
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

                // ���쌠����ύX�����������
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
        /// �J�e�S���S�̂̑��쌠�����O���b�h���擾���܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>�J�e�S���S�̂̑��쌠��</returns>
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

        # endregion // <�c�[���o�[/>

        #region <Debug/>

        /// <summary>
        /// �f�o�b�O�p�O���b�h�\��
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