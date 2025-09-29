using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ꎮ���I���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ꎮ���I���̃t�H�[���N���X�ł��B(�ꎮ���גǉ����Ɏg�p)</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.11.12</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.11.12 20056 ���n ��� �V�K�쐬</br>
    /// </remarks>
    public partial class MAHNB01010UI : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        public MAHNB01010UI()
        {
            InitializeComponent();

            _salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            _salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();

            this._completeInfoDataTable = _salesSlipInputAcs.CompleteInfoDataTable;

            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Decision"];
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private SalesInputDataSet.CompleteInfoDataTable _completeInfoDataTable;
        private DataView _completeInfoView = null;
        private ImageList _imageList16 = null;									// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// �m��{�^��
        private DialogResult _dialogRes = DialogResult.Cancel;                  // �_�C�A���O���U���g
        # endregion

        // ===================================================================================== //
        // �e��R���|�[�l���g�C�x���g�����S
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// �t�H�[��Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UI_Load(object sender, EventArgs e)
        {
            // �c�[���o�[�{�^�������ݒ�
            this.ButtonInitialSetting();

            // �����ݒ�^�C�}�[�N��
            this.Initial_Timer.Enabled = true;

            // �O���b�h���ݒ�
            this._completeInfoView = this._completeInfoDataTable.DefaultView;
            this.uGrid_CompleteInfo.DataSource = this._completeInfoView;

        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///	                 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///	                 �X���b�h�Ŏ��s����܂��B</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �����ݒ�^�C�}�[����
            this.Initial_Timer.Enabled = false;

            // �����t�H�[�J�X�ʒu�w��
            this.uGrid_CompleteInfo.Focus();
            this.uGrid_CompleteInfo.Rows[0].Selected = true;
        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // ���ו�
                //---------------------------------------------------------------
                case "uGrid_CompleteInfo":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    int completeInfoIndex = uGrid_CompleteInfo.ActiveRow.Index;
                                    this._salesSlipInputAcs.TargetIndex = completeInfoIndex;
                                    this._salesSlipInputAcs.TargetRowNo = this._salesSlipInputAcs.GetCmpltSalesRowNo(completeInfoIndex);
                                    this.SetDialogRes(DialogResult.OK);
                                    this.CloseForm();
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {

                //--------------------------------------------
                // �I��
                //--------------------------------------------
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        this.CloseForm();
                        break;
                    }
                //--------------------------------------------
                // �m��
                //--------------------------------------------
                case "ButtonTool_Decision":
                    {

                        int completeInfoIndex = uGrid_CompleteInfo.ActiveRow.Index;
                        this._salesSlipInputAcs.TargetIndex = completeInfoIndex;
                        this._salesSlipInputAcs.TargetRowNo = this._salesSlipInputAcs.GetCmpltSalesRowNo(completeInfoIndex);
                        this.SetDialogRes(DialogResult.OK);
                        this.CloseForm();
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[���N���[�Y�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_CompleteInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_CompleteInfo.DisplayLayout.Bands[0].Columns;


            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------
            this.uGrid_CompleteInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // ��
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._completeInfoDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �ꎮ����
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Width = 100;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._completeInfoDataTable.CmpltGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ����
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].Hidden = false;
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].Width = 80;
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._completeInfoDataTable.CmpltShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // ������z
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].Hidden = false;
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].Width = 100;
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._completeInfoDataTable.CmpltSalesMoneyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // �Œ���؂���ݒ�
            this.uGrid_CompleteInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_CompleteInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// �O���b�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_CompleteInfo_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            int completeInfoIndex = e.Row.Index;
            this._salesSlipInputAcs.TargetIndex = completeInfoIndex;
            this._salesSlipInputAcs.TargetRowNo = this._salesSlipInputAcs.GetCmpltSalesRowNo(completeInfoIndex);

            this.SetDialogRes(DialogResult.OK);
            this.CloseForm();
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        private void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// �_�C�A���O���U���g�ݒ菈��
        /// </summary>
        /// <param name="dialogRes">�_�C�A���O���U���g</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }
        # endregion

    }
}