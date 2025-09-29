//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�UI�F���쌠���ݒ�}�X�^
// �v���O�����T�v   : ���쌠���ݒ�}�X�^�̎擾�A�\�����s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/25  �C�����e : �V�K�쐬
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
    /// ���쌠���ꗗ�\���t�H�[��
    /// </summary>
    public partial class PMKHN09130UB : Form, ISecurityManagementForm, ISecurityManagementView
    {
        #region <Private Member/>
        OperationAuthoritySettingAcs _operationAuthoritySettingAcs;
        #endregion

        #region <ISecurityManagementForm �����o/>

        /// <summary>
        /// �ۑ��{�^����\������t���O
        /// </summary>
        /// <value>�ۑ��{�^�����\��</value>
        public bool CanWrite
        {
            get { return false; }
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
        /// <remarks>�������܂���B</remarks>
        /// <returns>�������� 0(=(int)ResultCode.Normal) ��Ԃ��܂��B </returns>
        public int Write()
        {
            return (int)ResultCode.Normal;
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
            RefleshGrid();
        }

        #endregion  // <ISecurityManagementForm �����o/>

        #region <ISecurityManagementView �����o/>

        /// <summary>�s�_�u���N���b�N���ꂽ�Ƃ��ɔ���������C�x���g</summary>
        public event GridSelectedEventHandler Selected;

        #endregion  // <ISecurityManagementView �����o/>

        #region <Constructor/>

        /// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public PMKHN09130UB()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            this._operationAuthoritySettingAcs = OperationAuthoritySettingAcs.Instance;
        }

        #endregion  // <Constructor/>

        #region <�t�H�[��/>

        /// <summary>
        /// ���쌠���ꗗ�\���t�H�[���R���g���[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PMKHN09130UB_Load(object sender, EventArgs e)
        {
            // ���ɂȂ�
        }

        # endregion // <�t�H�[��/>

        #region <�O���b�h/>

        /// <summary>
        /// �O���b�h��InitializeLayout�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void viewGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

            // �o���h���擾
            UltraGridBand band = this.viewGrid.DisplayLayout.Bands[0];

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



            if (this.viewGrid.Rows.Count > 0)
            {
                this.viewGrid.Rows[0].Selected = true;
            }

            // �񕝎�������
            this.viewGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // �w�b�_�[�I�����̃\�[�g���֎~
            this.viewGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            #region <�J�X�^�}�C�Y�p�T���v��/>

            //// TODO:��
            //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Width = 90;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Width = 90;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Width = 200;

            //// TODO:�\����
            //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].Header.VisiblePosition = 0;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].Header.VisiblePosition = 1;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].Header.VisiblePosition = 2;

            //// TODO:�\���ʒu
            //band.Columns[PrimeSettingInfo.COL_MAKERDISPORDER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //band.Columns[PrimeSettingInfo.COL_PARTSMAKERFULLNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //// TODO:�����ݒ�
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellAppearance.BackColor = Color.Lavender;
            //// --- ADD 2008/07/01 -------------------------------->>>>>
            ////band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            ////band.Columns[PrimeSettingInfo.COL_TBSPARTSCODE].MergedCellEvaluator = new MergedCell();
            //// --- ADD 2008/07/01 --------------------------------<<<<< 

            //// TODO:�����ݒ�
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellAppearance.BackColor = Color.Lavender;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            //band.Columns[PrimeSettingInfo.COL_TBSPARTSFULLNAME].MergedCellEvaluator = new MergedCell();

            //// TODO:�����ݒ�
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellAppearance.BackColor = Color.Lavender;
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            //band.Columns[PrimeSettingInfo.COL_SELECTNAME].MergedCellEvaluator = new MergedCell();

            //// --- ADD 2008/07/01 -------------------------------->>>>>
            //// TODO:�����ݒ�
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellAppearance.BackColor = Color.Lavender;
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
            //band.Columns[PrimeSettingInfo.COL_PRIMEKINDNAME].MergedCellEvaluator = new MergedCell();
            //// --- ADD 2008/07/01 --------------------------------<<<<< 

            //// TODO:�l���X�g�����������A�O���b�h�֒ǉ����܂��B
            //grid.DisplayLayout.ValueLists.Clear();
            //Infragistics.Win.ValueList vl1 = grid.DisplayLayout.ValueLists.Add();
            //vl1.ValueListItems.Add(0, "�\����");
            //vl1.ValueListItems.Add(1, "���i&����");
            //vl1.ValueListItems.Add(2, "���i");
            //vl1.ValueListItems[1].Appearance.BackColor = Color.SkyBlue;
            //vl1.ValueListItems[1].Appearance.BackColor2 = Color.White;
            //vl1.ValueListItems[1].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //vl1.ValueListItems[2].Appearance.BackColor = Color.MediumAquamarine;
            //vl1.ValueListItems[2].Appearance.BackColor2 = Color.White;
            //vl1.ValueListItems[2].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].ValueList = vl1;
            //band.Columns[PrimeSettingInfo.COL_PRIMEDISPLAYCODE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;


            //// TODO:�L�[����}�b�s���O��ǉ�
            //grid.KeyActionMappings.Add(
            //    new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //        Keys.Enter,	//Enter�L�[
            //        Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
            //        0,
            //        Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
            //        Infragistics.Win.SpecialKeys.None,
            //        0)
            //    );

            #endregion  // <�J�X�^�}�C�Y�p�T���v��/>

#endif

            // �񕝎�������
            this.viewGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // �w�b�_�[�I�����̃\�[�g���֎~
            this.viewGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            UltraGridBand band = this.viewGrid.DisplayLayout.Bands[0];

            // �\������J������ݒ�
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelDivColumn.ColumnName].Hidden = true;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelColumn.ColumnName].Hidden = true;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.BelongSectionCodeColumn.ColumnName].Hidden = true;

            int index = 0;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelDivNameColumn.ColumnName].Header.VisiblePosition = index++;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelNameColumn.ColumnName].Header.VisiblePosition = index++;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.EmployeeCodeColumn.ColumnName].Header.VisiblePosition = index++;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.EmployeeNameColumn.ColumnName].Header.VisiblePosition = index++;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.BelongSectionNmColumn.ColumnName].Header.VisiblePosition = index++;
            
            // �����ݒ�
            // �敪
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelDivNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelDivNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            // ���[��
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.Always;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelNameColumn.ColumnName].MergedCellAppearance.BackColor = Color.Lavender;
            band.Columns[this._operationAuthoritySettingAcs.SettingSet.EmployeeAuthority.AuthorityLevelNameColumn.ColumnName].CellAppearance.BackColor = Color.Lavender;
        }

        /// <summary>
        /// �O���b�h��DoubleClickRow�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void viewGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Selected(this, new OperationSt(e.Row));
        }

        /// <summary>
        /// �O���b�h���ĕ\�����܂��B
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
            // HACK:�S�~�|��
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

            // �񕝎�������
            this.viewGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
#endif
        }

        #endregion  // <�O���b�h/>
    }
}