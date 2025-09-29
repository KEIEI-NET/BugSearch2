//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/07/28  �C�����e : SCM�Ή� ���_�Ǘ�(10704767-00)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/01  �C�����e : redmine#26228 ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��M�f�[�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����͂̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.21 men �V�K�쐬(DC.NS���痬�p)</br>
    /// </remarks>
    public partial class PMKYO01101UC : UserControl
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constroctors
        /// <summary>
        /// �O���b�h����
        /// </summary>
        public PMKYO01101UC()
        {
            InitializeComponent();

            // �ϐ�������
            this._dataReceiveInputAcs = DataReceiveInputAcs.GetInstance();
        }

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private DataReceiveInputAcs _dataReceiveInputAcs;
        private readonly Color DISABLE_COLOR = Color.Gainsboro;
        private readonly Color DISABLE_FONT_COLOR = Color.Black;
        private DateTime dataTime = DateTime.MinValue;

        # endregion

        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        # region Const Members

        # endregion


        // ===================================================================================== //
        // �v���C�x�[�g�E�C���^�[�i�����\�b�h
        // ===================================================================================== //
        # region Private Methods and Internal Methods

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void ultraGridCondition_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Condition.DisplayLayout.Bands[0];
            if (editBand == null) return;
            int iIndex = 1;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //UPD 2011/07/28 SCM�Ή�-���_�Ǘ� -------------------------------------------------------------------------->>>>>
                //// �uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                //if (col.Key != this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName)
                //{
                //    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                //    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                //}
                if (col.Key != this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName
                    && col.Key != this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionCdColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
                else
                {
                    col.Hidden = true;
                }
                //UPD 2011/07/28 SCM�Ή�-���_�Ǘ� --------------------------------------------------------------------------<<<<<
               
                //if (iIndex > 6)//DEL 2011/07/28 SCM�Ή�-���_�Ǘ� 
                //if (iIndex > 8)  //ADD 2011/07/28 SCM�Ή�-���_�Ǘ�  //DEL 2011/11/01 xupz redmine#26228
                if (iIndex > 9)  //ADD 2011/11/01 xupz redmine#26228
                {
                    col.Hidden = true;
                }
                iIndex++;
            }

            // �O���b�h
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center; // ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;//ADD 2011.07.30 sundx

            // �\�����ݒ�
            //this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].Width = 70;   //DEL 2011.07.30 sundx
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].Width = 153;//ADD 2011.07.30 sundx
            //this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].Width = 235;  //DEL 2011.07.30 sundx
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].Width = 152;    //ADD 2011.07.30 sundx
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].Width = 140;    //ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].Width = 134;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].Width = 133;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].Width = 133;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].Width = 133;

            // �Œ��ݒ�
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;	     // ��
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;  //ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;//ADD 2011.07.30 sundx

            // CellAppearance�ݒ�
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;//ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;//ADD 2011.07.30 sundx


            // ���͋��ݒ�
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionSectionNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //ADD 2011/07/28 SCM�Ή�-���_�Ǘ� ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------>>>>>
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionDestSectionNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionExtraConDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;//ADD 2011/11/01 xupz
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //ADD 2011/07/28 SCM�Ή�-���_�Ǘ� ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------<<<<<

            // style
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.uGrid_Condition.DisplayLayout.Bands[0].Columns[this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMKYO01101UC_Load(object sender, EventArgs e)
        {
            this.uGrid_Condition.DataSource = this._dataReceiveInputAcs.DataReceive.DataReceiveCondition;
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        internal void Clear()
        {
            // �f�[�^��MDataTable�s�N���A����
            this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.Rows.Clear();

            // �O���b�h�s�����ݒ菈��
            this._dataReceiveInputAcs.DataReceiveConditionRowInitialSetting();
        }

        /// <summary>
        /// Enter�L�[�̏���
        /// </summary>
        /// <param name="sender">�I���Z��</param>
        /// <param name="e">���[�h</param>
        /// <remarks>
        /// <br>Note		: Enter�L�[���N�b���N���鎞�A�������s���܂��B</br>
        /// <br>Programmer	: ���m</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void uGrid_Condition_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();

                // �ϊ�
                if (value.Length == 8)
                {
                    this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionStartTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            else if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();

                // �ϊ�
                if (value.Length == 8)
                {
                    this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionEndTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            // �� 2009.05.20 liuyang add
            else if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName
                    || cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName)
            {
                if (cell.Value is DBNull)
                {
                    this.dataTime = DateTime.MinValue;
                }
                else
                {
                    this.dataTime = Convert.ToDateTime(cell.Value);
                }
            }
            // �� 2009.05.20 liuyang add
        }

        /// <summary>
        /// Enter�L�[�̏���
        /// </summary>
        /// <param name="sender">�I���Z��</param>
        /// <param name="e">���[�h</param>
        /// <remarks>
        /// <br>Note		: Enter�L�[���N�b���N���鎞�A�������s���܂��B</br>
        /// <br>Programmer	: ���m</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void uGrid_Condition_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                
                // �ϊ�
                if (value.Length == 6)
                {
                    this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionStartTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();

                // �ϊ�
                if (value.Length == 6)
                {
                    this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionEndTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Conditon_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            if (e.Cell.Value is DBNull)
            {
                if ((e.Cell.Column.DataType == typeof(Int32)) ||
                    (e.Cell.Column.DataType == typeof(Int64)))
                {
                    e.Cell.Value = 0;
                }
                else if (e.Cell.Column.DataType == typeof(double))
                {
                    e.Cell.Value = 0.0;
                }
                else if (e.Cell.Column.DataType == typeof(string))
                {
                    e.Cell.Value = "";
                }
            }

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName)
            {
                string startTime = cell.Value.ToString().Trim();
                // �`�F�b�N����
                if (!string.IsNullOrEmpty(startTime))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < startTime.Length; i++)
                    {
                        if (!char.IsNumber(startTime, i))
                        {
                            inputFlg = false;
                            break;
                        }
                    }

                    if (!inputFlg)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "�J�n���Ԃ͎���6���œ��͂��ĉ������B",
                           -1,
                           MessageBoxButtons.OK);
                        cell.Value = string.Empty;
                    }
                    else
                    {
                        // ���`�F�b�N
                        if (startTime.Length != 6)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�J�n���Ԃ͎���6���œ��͂��ĉ������B",
                                -1,
                                MessageBoxButtons.OK);
                            cell.Value = string.Empty;
                        }
                        else
                        {
                            // ���ԗL�����`�F�b�N
                            int hour = Convert.ToInt32(startTime.Substring(0, 2));
                            int minute = Convert.ToInt32(startTime.Substring(2, 2));
                            int second = Convert.ToInt32(startTime.Substring(4, 2));
                            if (hour >= 24 || minute >= 60 || second >= 60)
                            {
                                TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "�J�n���Ԃ͎���6���œ��͂��ĉ������B",
                                   -1,
                                   MessageBoxButtons.OK);
                                cell.Value = string.Empty;
                            }
                            else
                            {
                                this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionStartTime = startTime.Substring(0, 2) + ":" +
                                    startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                            }
                        }
                    }
                }
            }
            else if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName)
            {
                string endTime = cell.Value.ToString().Trim();
                // �`�F�b�N����
                if (!string.IsNullOrEmpty(endTime))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < endTime.Length; i++)
                    {
                        if (!char.IsNumber(endTime, i))
                        {
                            inputFlg = false;
                            break;
                        }
                    }

                    if (!inputFlg)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "�I�����Ԃ͎���6���œ��͂��ĉ������B",
                           -1,
                           MessageBoxButtons.OK);
                        cell.Value = string.Empty;
                    }
                    else
                    {
                        // ���`�F�b�N
                        if (endTime.Length != 6)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�I�����Ԃ͎���6���œ��͂��ĉ������B",
                                -1,
                                MessageBoxButtons.OK);
                            cell.Value = string.Empty;
                        }
                        else
                        {
                            // ���ԗL�����`�F�b�N
                            int hour = Convert.ToInt32(endTime.Substring(0, 2));
                            int minute = Convert.ToInt32(endTime.Substring(2, 2));
                            int second = Convert.ToInt32(endTime.Substring(4, 2));
                            if (hour >= 24 || minute >= 60 || second >= 60)
                            {
                                TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "�I�����Ԃ͎���6���œ��͂��ĉ������B",
                                   -1,
                                   MessageBoxButtons.OK);
                                cell.Value = string.Empty;
                            }
                            else
                            {
                                this._dataReceiveInputAcs.DataReceive.DataReceiveCondition[rowIndex].ConditionEndTime = endTime.Substring(0, 2) + ":" +
                                    endTime.Substring(2, 2) + ":" + endTime.Substring(4, 2);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Condition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;

            // ActiveCell���P���̏ꍇ
            if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartTimeColumn.ColumnName
                || cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndTimeColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Conditon_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;
                // Shift�L�[�̏ꍇ
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Condition.ActiveCell = null;
                                this.uGrid_Condition.ActiveRow = cell.Row;
                                this.uGrid_Condition.Selected.Rows.Clear();
                                this.uGrid_Condition.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Condition.ActiveCell = null;
                                this.uGrid_Condition.ActiveRow = cell.Row;
                                this.uGrid_Condition.Selected.Rows.Clear();
                                this.uGrid_Condition.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_Condition.ActiveCell != null) && (this.uGrid_Condition.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_Condition.ActiveCell != null) && (this.uGrid_Condition.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                // EnterNextEditableCellDetail(cell, -1);
                                break;
                            }
                    }
                }
                // Alt�L�[�̏ꍇ
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                // s
                                break;
                            }
                    }
                }
                else
                {
                    // �ҏW���ł������ꍇ
                    if (cell.IsInEditMode)
                    {
                        // �Z���̃X�^�C���ɂĔ���
                        switch (this.uGrid_Condition.ActiveCell.StyleResolved)
                        {
                            // �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            if (this.uGrid_Condition.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.uGrid_Condition.ActiveCell.SelStart >= this.uGrid_Condition.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                            // ��L�ȊO�̃X�^�C��
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            {
                                                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.uGrid_Condition.ActiveCell != null) && (this.uGrid_Condition.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                if ((this.uGrid_Condition.ActiveCell != null) && (this.uGrid_Condition.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                // EnterNextEditableCellDetail(cell, 1);
                                break;
                            }
                    }
                }
            }

            else if (this.uGrid_Condition.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Condition.ActiveRow;

                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        {
                            // Del�L�[�̑���
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Enter�L�[�̏���
        /// </summary>
        /// <param name="activeCell">�I���Z��</param>
        /// <param name="mode">���[�h</param>
        /// <remarks>
        /// <br>Note		: Enter�L�[���N�b���N���鎞�A�������s���܂��B</br>
        /// <br>Programmer	: ���m</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void EnterNextEditableCellDetail(Infragistics.Win.UltraWinGrid.UltraGridCell activeCell, int mode)
        {
            int curRowIndex = activeCell.Row.Index;
            int curColIndex = activeCell.Column.Index;
            int rowCount = this.uGrid_Condition.Rows.Count;
            int colCount = this.uGrid_Condition.Rows[curRowIndex].Cells.Count;
            switch (mode)
            {
                case -1:
                    {
                        bool found = false;
                        for (int i = curRowIndex; i >= 0; i--)
                        {
                            int j = colCount - 1;
                            if (i == curRowIndex && curColIndex > 0)
                            {
                                j = curColIndex - 1;
                            }
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell;
                            for (; j >= 0; j--)
                            {
                                cell = this.uGrid_Condition.Rows[i].Cells[j];
                                if (cell.Activation == Activation.AllowEdit && cell.Column.CellActivation == Activation.AllowEdit
                                    && cell.CanEnterEditMode && !cell.Hidden && !cell.Column.Hidden)
                                {
                                    cell.Activated = true;
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        bool found = false;
                        for (int i = curRowIndex; i < rowCount; i++)
                        {
                            int j = 0;
                            if (i == curRowIndex)
                            {
                                j = curColIndex + 1;
                            }
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell;
                            for (; j < colCount; j++)
                            {
                                cell = this.uGrid_Condition.Rows[i].Cells[j];
                                if (cell.Activation == Activation.AllowEdit && cell.Column.CellActivation == Activation.AllowEdit
                                    && cell.CanEnterEditMode && !cell.Hidden && !cell.Column.Hidden)
                                {
                                    cell.Activated = true;
                                    this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        break;
                    }
            }
        }


        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        public bool ReturnKeyDown()
        {
            return MoveNextAllowEditCell(false);
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_Condition.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Condition.ActiveCell != null))
            {
                if ((!this.uGrid_Condition.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Condition.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Condition.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                //if (this.uGrid_Condition.ActiveCell != null)
                //{
                //    //int editMode = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._dspcInstsDtlDataTable.EditStatusColumn.ColumnName].Value;
                //    int editMode = BODspcInstsDtlAcs.EDITSTATUS_AllOK;
                //    if ((editMode == BODspcInstsDtlAcs.EDITSTATUS_AllDisable) || (editMode == BODspcInstsDtlAcs.EDITSTATUS_AllReadOnly))
                //    {
                //        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

                //        if ((performActionResult) && (this.uGrid_Details.ActiveRow != null))
                //        {
                //            int index = this.uGrid_Details.ActiveRow.Index;

                //            if (!(this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dspcInstsDtlDataTable.GoodsCodeColumn.ColumnName].Hidden))
                //            {
                //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._dspcInstsDtlDataTable.GoodsCodeColumn.ColumnName];
                //            }
                //            else
                //            {
                //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._dspcInstsDtlDataTable.GoodsNameColumn.ColumnName];
                //            }

                //            // �ċA����
                //            this.MoveNextAllowEditCell(true);

                //            return true;
                //        }
                //    }
                //}

                performActionResult = this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_Condition.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Condition.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_Condition.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_Condition.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="sender">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <param name="e"></param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private void uGrid_Condition_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Condition.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_Condition.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Condition.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Condition.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Condition.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Condition.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�				
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Condition.ActiveCell.Value = 0;
                    }
                    // �ʏ����				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Condition.ActiveCell.Column.DataType);
                            this.uGrid_Condition.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Condition.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�	
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
                else if (this.uGrid_Condition.ActiveCell.Column.DataType == typeof(TimeSpan))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Condition.ActiveCell.EditorResolved;

                        if (editorBase.TextLength == 6)
                        {
                            string value = editorBase.CurrentEditText;

                            editorBase.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                            this.uGrid_Condition.ActiveCell.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�f�[�^�l���X�V�ł��܂���:�G�f�B�^�̒l�͖����ł��B",
                                -1,
                                MessageBoxButtons.OK);

                            editorBase.Value = null;
                            this.uGrid_Condition.ActiveCell.Value = null;
                        }
                    }
                    catch
                    {

                    }
                }
                // �� 2009.05.20 ���m add
                else if (this.uGrid_Condition.ActiveCell.Column.DataType == typeof(DateTime))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Condition.ActiveCell.EditorResolved;
                        Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Condition.ActiveCell;

                        if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionStartDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�J�n���t�͓��t8���œ��͂��ĉ������B",
                                -1,
                                MessageBoxButtons.OK);

                            if (this.dataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.uGrid_Condition.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this.dataTime;
                                this.uGrid_Condition.ActiveCell.Value = this.dataTime;
                            }
                        }
                        else if (cell.Column.Key == this._dataReceiveInputAcs.DataReceive.DataReceiveCondition.ConditionEndDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "�I�����t�͓��t8���œ��͂��ĉ������B",
                               -1,
                               MessageBoxButtons.OK);

                            if (this.dataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.uGrid_Condition.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this.dataTime;
                                this.uGrid_Condition.ActiveCell.Value = this.dataTime;
                            }
                        }
                    }
                    catch
                    {

                    }

                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�	
                }
                // �� 2009.05.20 ���m add
            }
        }

        #endregion
    }
}
