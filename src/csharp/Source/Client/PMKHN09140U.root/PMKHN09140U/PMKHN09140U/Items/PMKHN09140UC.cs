//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : �����n��ʂ̋��ʋ@�\
// �v���O�����T�v   : UI�̋��ʏ������������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms.Items
{
    using DateTimeUIType        = Broadleaf.Library.Windows.Forms.TDateEdit;
    using EmployeeUIType        = Broadleaf.Library.Windows.Forms.TEdit;
    using LogDataKindUIType     = Broadleaf.Library.Windows.Forms.TComboEditor;
    using LogDataKindItemType   = CodeNamePair<int>;
    using GridType              = Infragistics.Win.UltraWinGrid.UltraGrid;
    using AutoFillToGridUIType  = Infragistics.Win.UltraWinEditors.UltraCheckEditor;
    using FontSizeUIType        = Broadleaf.Library.Windows.Forms.TComboEditor;

    /// <summary>
    /// UI���[�e�B���e�B
    /// </summary>
    internal static class UIUtil
    {
        #region <����/>

        /// <summary>
        /// ����UI�����������܂��B
        /// </summary>
        /// <param name="from">�J�n����</param>
        /// <param name="to">�I������</param>
        public static void InitializeDateTimeUI(
            DateTimeUIType from,
            DateTimeUIType to
        )
        {
            DateTime now = DateTime.Now;

            from.SetDateTime(now);
            to.SetDateTime(now);
        }

        /// <summary>
        /// ���͓��t���`�F�b�N���܂��B(�͈̓`�F�b�N�Ȃ��A������OK)
        /// </summary>
        /// <remarks>
        /// �R�s�[���F�d���m�F�\::MAKON02240UA.CallCheckInputDateRange()
        /// </remarks>
        /// <param name="fromDateUI">�J�n���t��UI</param>
        /// <param name="toDateUI">�I�����t��UI</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>
        /// <c>true</c> :OK<br/>
        /// <c>false</c>:NG
        /// </returns>
        public static bool IsOKThatInputDateRangeCheck(
            TDateEdit fromDateUI,
            TDateEdit toDateUI,
            out string message
        )
        {
            message = string.Empty;

            const int MAX_MONTH_SPAN= 3;            // �ő�3�����͈̔�
            const string FROM_DATE  = "�J�n��{0}";  // LITERAL:
            const string TO_DATE    = "�I����{0}";  // LITERAL:
            const string DATE_TIME  = "����{0}";    // LITERAL:
            const string INPUT_ERROR= "�̓��͂��s���ł�";                   // LITERAL:
            const string RANGE_ERROR= "�͈͎̔w��Ɍ�肪����܂�";         // LITERAL:
            const string RANGE_OVER = "�͂R�����͈͓̔��œ��͂��ĉ�����";   // LITERAL:

            DateGetAcs.CheckDateRangeResult result = DateGetAcs.GetInstance().CheckDateRange(
                DateGetAcs.YmdType.YearMonth,
                MAX_MONTH_SPAN, // �͈�
                ref fromDateUI,
                ref toDateUI,
                true            // ���[�h�H
            );
            switch (result)
            {
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    return true;
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                {
                    message = string.Format(FROM_DATE, INPUT_ERROR);
                    fromDateUI.Focus();
                    break;
                }
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    return true;
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                {
                    message = string.Format(TO_DATE, INPUT_ERROR);
                    toDateUI.Focus();
                    break;
                }
                case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                {
                    message = string.Format(DATE_TIME, RANGE_ERROR);
                    fromDateUI.Focus();
                    break;
                }
                case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                {
                    message = string.Format(DATE_TIME, RANGE_OVER);
                    fromDateUI.Focus();
                    break;
                }
            }
            return result.Equals(DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// TDateEdit�R���g���[�����\������A�C�e���̃C���f�b�N�X�񋓑�
        /// </summary>
        public enum TDateEditItemIndex : int
        {
            /// <summary>���A�C�e��</summary>
            Day = 3,
            /// <summary>���A�C�e��</summary>
            Month = 4,
            /// <summary>�N�A�C�e��</summary>
            Year = 5
        }

        /// <summary>
        /// TDateEdit�̓��t�A�C�e�����擾���܂��B
        /// </summary>
        /// <param name="tDateEdit">TDateEdit�I�u�W�F�N�g</param>
        /// <param name="itemIndex">TDateEdit�R���g���[�����\������A�C�e���̃C���f�b�N�X</param>
        /// <returns>�Y��������t�A�C�e��</returns>
        public static TNedit GetDateItem(
            TDateEdit tDateEdit,
            TDateEditItemIndex itemIndex
        )
        {
            return (TNedit)tDateEdit.Controls[(int)itemIndex];
        }

        /// <summary>
        /// ���L�[���������Ƃ��̃C�x���g�n���h��
        /// </summary>
        /// <param name="e">�L�[�������̃C�x���g�p�����[�^</param>
        /// <param name="previousControl">�O�̃R���g���[��</param>
        /// <param name="nextControl">���̃R���g���[��</param>
        public static void OnArrowKeyDown(
            KeyEventArgs e,
            Control previousControl,
            Control nextControl
        )
        {
            if (!e.Shift) return;

            switch (e.KeyCode)
            {
                case Keys.Left: // ���L�[
                    previousControl.Focus();
                    break;
                case Keys.Right:// ���L�[
                    nextControl.Focus();
                    break;
            }
        }

        #endregion  // <����/>

        #region <�]�ƈ�/>

        /// <summary>
        /// �]�ƈ��̃R�[�h�Ɩ��O����͂��܂����܂��B
        /// </summary>
        /// <param name="uiCode">�R�[�hUI�I�u�W�F�N�g</param>
        /// <param name="uiName">���OUI�I�u�W�F�N�g</param>
        public static void InputEmployeeCodeAndName(
            EmployeeUIType uiCode,
            EmployeeUIType uiName
        )
        {
            Employee employee = null;
            int status = OperationHistoryAcs.Instance.EmployeeMasterDB.RealAccesser.ExecuteGuid(
                LoginInfoAcquisition.EnterpriseCode,
                true,
                out employee
            );
            if (status.Equals((int)DBAccessStatus.Normal))
            {
                uiCode.Text = employee.EmployeeCode;
                uiName.Text = employee.Name;
            }
        }

        /// <summary>
        /// �]�ƈ������擾���܂��B
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ���<br/>���Y������]�ƈ��R�[�h���Ȃ��ꍇ�A<c>string.Empty</c>��Ԃ��܂��B</returns>
        public static string GetEmployeeName(string employeeCode)
        {
            string dbEmployeeCode = EmployeeAcsAgent.ConvertEmployeeCodeInDBFormat(employeeCode);
            if (OperationHistoryAcs.Instance.EmployeeMasterDB.RecordMap.ContainsKey(dbEmployeeCode))
            {
                return OperationHistoryAcs.Instance.EmployeeMasterDB.RecordMap[dbEmployeeCode].Name;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion  // <�]�ƈ�/>

        #region <�O���b�h/>

        /// <summary>
        /// �J�����T�C�Y�𒲐����܂��B
        /// </summary>
        /// <param name="grid">�O���b�h</param>
        public static void DoColumnPerformAutoResize(GridType grid)
        {
            // �J�����T�C�Y����
            for (int i = 0; i < grid.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                grid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(PerformAutoSizeType.VisibleRows, true);
            }
        }

        #endregion  // <�O���b�h/>

        #region <��T�C�Y�̎�������/>

        /// <summary>
        /// ��T�C�Y�̎����������s���܂��B
        /// </summary>
        /// <param name="autoFillUI">��������UI</param>
        /// <param name="grid">�O���b�h</param>
        public static void DoAutoFillToGridColumn(
            AutoFillToGridUIType autoFillUI,
            GridType grid
        )
        {
            if (autoFillUI.Checked)
            {
                // �񕝂��I�[�g�ɐݒ�
                grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                grid.Refresh();
            }

            // �J�����T�C�Y����
            DoColumnPerformAutoResize(grid);
        }

        #endregion  // <��T�C�Y�̎�������/>

        #region <�����T�C�Y/>

        /// <summary>
        /// �����T�C�YUI�����������܂��B
        /// </summary>
        /// <remarks>
        /// �f�t�H���g�T�C�Y��11
        /// </remarks>
        /// <param name="ui">�����T�C�Y�ݒ�UI�I�u�W�F�N�g</param>
        public static void InitializeFontSizeUI(FontSizeUIType ui)
        {
            int[] fontPitchSizes = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
            foreach (int iFontPitchSize in fontPitchSizes) ui.Items.Add(iFontPitchSize, iFontPitchSize.ToString());
        }

        /// <summary>
        /// �O���b�h�̕\�������T�C�Y��ύX���܂��B
        /// </summary>
        /// <param name="ui">�����T�C�YUI�I�u�W�F�N�g</param>
        /// <param name="grid">�O���b�h</param>
        public static void ChangeFontSize(
            FontSizeUIType ui,
            GridType grid
        )
        {
            float fontPoint = float.Parse(ui.Value.ToString());

            grid.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            grid.Refresh();

            DoColumnPerformAutoResize(grid);
        }

        #endregion  // <�����T�C�Y/>

        #region <UI�̔w�i�F/>

        /// <summary>
        /// UI�̔w�i�F���[�e�B���e�B
        /// </summary>
        public static class UIColor
        {
            /// <summary>
            /// �f�t�H���g�w�i�F
            /// </summary>
            /// <value>�f�t�H���g�w�i�F</value>
            private static Color DefaultBackColor
            {
                get { return Color.FromName("Window"); }
            }

            /// <summary>
            /// �t�H�[�J�X���̔w�i�F
            /// </summary>
            private static Color FocusedBackColor
            {
                get { return Color.FromArgb(247, 227, 156); }
            }

            /// <summary>
            /// �t�H�[�J�X�J�ڎ��̃C�x���g�n���h��
            /// </summary>
            /// <param name="e">�C�x���g�p�����[�^</param>
            public static void OnFocusChanged(Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
            {
                if (e.PrevCtrl is ComboBox || e.PrevCtrl is TextBox)
                {
                    e.PrevCtrl.BackColor = DefaultBackColor;
                }

                if (e.NextCtrl is ComboBox || e.NextCtrl is TextBox)
                {
                    e.NextCtrl.BackColor = FocusedBackColor;
                }
            }
        }

        #endregion  // <UI�̔w�i�F/>
    }
}
