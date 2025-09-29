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
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
using Broadleaf.Application.Remoting.ParamData;

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
    public partial class PMKYO01101UB : UserControl
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constroctors
        /// <summary>
        /// �O���b�h����
        /// </summary>
        public PMKYO01101UB()
        {
            InitializeComponent();

            // �ϐ�������
            this._dataReceiveInputAcs = DataReceiveInputAcs.GetInstance();
            _datareceive = this._dataReceiveInputAcs.DataReceive;
            this._resultDataTable = _datareceive.Setting;
        }

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private DataReceive.SettingDataTable _resultDataTable;
        private DataReceive _datareceive;
        private DataReceiveInputAcs _dataReceiveInputAcs;
        private readonly Color DISABLE_COLOR = Color.Gainsboro;
        private readonly Color DISABLE_FONT_COLOR = Color.Black;

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
        private void PMKYO01101UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Result.DataSource = this._datareceive.Tables["DataReceiveResult"];
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void ultraGridResult_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._resultDataTable.ResultRowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            // �\�����ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultRowNoColumn.ColumnName].Width = 30;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultNameColumn.ColumnName].Width = 204;

            // �Œ��ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultRowNoColumn.ColumnName].Header.Fixed = true;	     // ��
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultNameColumn.ColumnName].Header.Fixed = true;

            // CellAppearance�ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // ���͋��ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultRowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;// No
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._resultDataTable.ResultNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //DEL 2011/07/28 SCM�Ή�-���_�Ǘ� ------------------------------------------------------>>>>>
            //foreach (APSecMngSetWork secMngSetWork in this._dataReceiveInputAcs.SecMngSetWorkList)
            //{
            //    this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.SectionCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //    this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.SectionCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //    this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.SectionCode].Width = 150;
            //}
            //DEL 2011/07/28 SCM�Ή�-���_�Ǘ� ------------------------------------------------------<<<<<
            //ADD 2011/07/28 SCM�Ή�-���_�Ǘ� ------------------------------------------------------<<<<<
            foreach (SndRcvHisWork secMngSetWork in this._dataReceiveInputAcs.SecMngSetWorkList)  
            {
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.uGrid_Result.DisplayLayout.Bands[0].Columns[secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()].Width = 150;
            }
            this.uGrid_Result.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            //ADD 2011/07/28 SCM�Ή�-���_�Ǘ� ------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        internal void Clear()
        {
            // �f�[�^��MDataTable�s�N���A����
            this._resultDataTable.Rows.Clear();

            // �O���b�h�s�����ݒ菈��
            this._dataReceiveInputAcs.DataReceiveResultRowInitialSetting();
        }

        #endregion
    }
}
