using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌Ɏd���`�[�Ɖ�׃O���b�h�R���g���[���N���X�i�`�[���j
    /// </summary>
    /// <remarks>
    /// Note       : �݌Ɏd���`�[�̈ꗗ�\�����s���O���b�h���܂ރ��[�U�[�R���g���[���ł��B<br />
    /// Programmer : 22018 ��� ���b<br />
    /// Date       : 2008.09.02<br />
    /// <br />
    /// Update Note: 2009/04/03 �Ɠc �M�u�@�s��Ή�[12857]<br />
    /// <br>         </br>
    /// </remarks>
	public partial class PMZAI04001UB : UserControl
	{
		#region ��Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
		public PMZAI04001UB()
		{
			InitializeComponent();

            this._searchSlipAcs = StockAdjRefAcs.GetInstance();
            this._dataSet = this._searchSlipAcs.DataSet;
            this.uGrid_Details.DataSource = this._dataSet.StockAdjust;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._stockAdjRefSearchRetWork = new StockAdjRefSearchRetWork();
			this._stockAdjRefSearchParaWork = new StockAdjRefSearchParaWork();
		}
		#endregion

		#region ��Private Members
		private StockAdjRefAcs _searchSlipAcs;
		private StockAdjDataSet _dataSet;
		private ImageList _imageList16 = null;									// �C���[�W���X�g
		private int _startMovment = 0;											// �N�����[�h 0:�G���g���[ 1:���j���[

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
		#endregion

		#region ��Public Members
		public StockAdjRefSearchRetWork _stockAdjRefSearchRetWork;
		public StockAdjRefSearchParaWork _stockAdjRefSearchParaWork = null;
		#endregion

		#region ��Delegate
		// �f���Q�[�g����
        //internal event SettingRaedParaEventHandler ReadParaSetting;
        //internal delegate void SettingRaedParaEventHandler(out IOWriteMASIRReadWork retIOWriteMASIRReadWork);

        internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        internal delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        internal event CloseMainEventHandler CloseMain;
        internal delegate void CloseMainEventHandler();

        internal event SetDialogResEventHandler SetMainDialogResult;
        internal delegate void SetDialogResEventHandler(DialogResult dialogRes);

        internal event SettingDecisionButtonEnableEventHandler DecisionButtonEnableSet;
        internal delegate void SettingDecisionButtonEnableEventHandler(bool enableSet);
		#endregion

		#region ��Properties
		/// <summary>
		/// �N�����샂�[�h
		/// </summary>
		public int StartMovment
		{
			get { return this._startMovment; }
			set { this._startMovment = value; }
		}
		
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>�`�[��ʃv���p�e�B</summary>
        //public int SupplierFormal
        //{
        //    get { return this._stockAdjRefSearchParaWork.SupplierFormal; }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		#endregion

		#region ��Public Methods
		/// <summary>
		/// ��ʃ��[�h�ݒ�
		/// </summary>
		public void DisplayModeSetting()
		{
			// �O���b�h�񏉊��ݒ菈��
			this.GridColInitialSetting();
		}
		#endregion

        # region [�����ݒ�]
        /// <summary>
		/// �O���b�h�񏉊��ݒ菈��
		/// </summary>
		private void GridColInitialSetting()
		{
            const string moneyFormat = "#,##0;-#,##0;''";

			for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				// ���͋��ݒ�
				//this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].AutoEdit = false;

				// �\����\���ݒ�
				this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden = true;
				this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			}


            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            int visiblePosition = 0;

            # region [�J�����ݒ�]

            // ��
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Header.Caption = "��";
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Width = 30;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i��ƃR�[�h�j
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].Header.Caption = "��ƃR�[�h";
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �������t
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Hidden = false;
            //band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Header.Caption = "�쐬��";            //DEL 2009/04/03 �s��Ή�[12857]
            //band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Width = 150;                          //DEL 2009/04/03 �s��Ή�[12857]
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Header.Caption = "�d����";              //ADD 2009/04/03 �s��Ή�[12857]  
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Width = 100;                            //ADD 2009/04/03 �s��Ή�[12857]
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �݌ɒ����`�[�ԍ�
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Format = this.GetSlipNoFormat();
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i�󕥌��`�[�敪�R�[�h�j
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].Header.Caption = "�`�[�敪�R�[�h";
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �󕥌��`�[�敪����
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].Header.Caption = "�`�[�敪";
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i�󕥌�����敪�R�[�h�j
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].Header.Caption = "����敪�R�[�h";
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i�󕥌�����敪���́j
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].Header.Caption = "����敪";
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i�d���S���҃R�[�h�j
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].Header.Caption = "�S���҃R�[�h";
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �d���S���Җ���
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].Header.Caption = "�S���Җ�";
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �d�����z���v
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Header.Caption = "�d�����z";
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Format = moneyFormat;

            // ���͓��t
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Header.Caption = "���͓�";
            //band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Width = 150;                //DEL 2009/04/03 �s��Ή�[12857]
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Width = 100;                  //ADD 2009/04/03 �s��Ή�[12857]              
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �`�[���l
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].Header.Caption = "�`�[���l";
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].Width = 180;
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i���_�R�[�h�j
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].Header.Caption = "���_�R�[�h";
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���_�K�C�h����
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].Header.Caption = "���_��";
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i�q�ɃR�[�h�j
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].Header.Caption = "�q�ɃR�[�h";
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �q�ɖ���
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].Header.Caption = "�q�ɖ�";
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            # endregion
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
        /// <summary>
        /// �`�[�ԍ��t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetSlipNoFormat()
        {
            Broadleaf.Library.Windows.Forms.UiSet uiSet;
            const string ct_SlipNoEditName = "tNedit_SupplierSlipNo";

            // �t�h���ʂw�l�k���猅�����擾����
            if ( uiSetControl1.ReadUISet( out uiSet, ct_SlipNoEditName ) == 0 )
            {
                return new string( '0', uiSet.Column );
            }
            else
            {
                return string.Empty;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
       
		/// <summary>
		/// �O���b�h�s�����ݒ菈��
		/// </summary>
		private void GridRowInitialSetting()
		{
            if (this._searchSlipAcs.GetStockSlipTableCache() == null)
            {
                this._dataSet.StockAdjust.Rows.Clear();
            }

			if (this.uGrid_Details.Rows.Count != 0)
			{
				this.uButton_StockSearch.Enabled = true;
			}
			else
			{
				this.uButton_StockSearch.Enabled = false;
			}
		}

		/// <summary>
		/// �{�^�������ݒ菈��
		/// </summary>
		private void ButtonInitialSetting()
		{
            this.uButton_StockSearch.ImageList = this._imageList16;
            this.uButton_StockSearch.Appearance.Image = (int)Size16_Index.DETAILS;
        }
        # endregion

        # region [�`�[�I��]
        /// <summary>
		/// �I��`�[���ݒ�
		/// </summary>
        public bool ReturnSelectData()
        {
            if ((uGrid_Details.ActiveRow == null) ||
                (uGrid_Details.ActiveRow.Index < 0) ||
                (uGrid_Details.ActiveRow.Selected == false))
            {
                this.StatusBarMessageSetting(this, "�`�[���I������Ă��܂���B");
                return false;
            }

			// �I���s����
			this.SelectRow();

            return true;
        }

        /// <summary>
        /// �I��`�[���ݒ�
        /// </summary>
        public bool SetGridEnable()
        {
            bool enable = false;

            if (this.uGrid_Details.Rows.Count == 0)
            {
                enable = false;
            }
            else
            {
                enable = true;
            }
            this.uGrid_Details.Enabled = enable;

            return enable;
        }
        # endregion

        # region �R���g���[���C�x���g���\�b�h
        /// <summary>
        /// ���[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputDetails_Load( object sender, EventArgs e )
        {
            // �O���b�h�񏉊��ݒ菈��
            this.GridColInitialSetting();

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // �O���b�h�s�����ݒ菈��
            this.GridRowInitialSetting();
        }


        /// <summary>
        /// �O���b�h�G���^�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Details.Rows.Count != 0)
            {
                this.uButton_StockSearch.Enabled = true;
                this.DecisionButtonEnableSet(true);
            }

            if (this.uGrid_Details.ActiveRow != null)
            {
                this.uGrid_Details.ActiveRow.Selected = true;
            }
        }

        /// <summary>
        /// �O���b�h�t�H�[�J�X���E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            if (this.uGrid_Details.Rows.Count == 0)
            {
                this.uButton_StockSearch.Enabled = false;
            }
            this.DecisionButtonEnableSet(false);
        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;

            // Enter�L�[
            if (e.KeyCode == Keys.Enter)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
            
                // �I���s����
				this.SelectRow();
			}

            // �ŏ�s�ł́��L�[
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                    e.Handled = true;
                    this.uButton_StockSearch.Focus();
                }
            }

            // �����L�[
            if (e.KeyCode == Keys.Right)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                // �O���b�h�\�����E�ɃX�N���[��
                this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
            }

            // �����L�[
            if (e.KeyCode == Keys.Left)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                    this.uButton_StockSearch.Focus();
                }
                else
                {
                    // �O���b�h�\�������ɃX�N���[��
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }

            // Home�L�[
            if (e.KeyCode == Keys.Home)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;

                // ���L�[�Ƃ̑g���������̏ꍇ
                if (e.Modifiers == Keys.None)
                {
                    // �O���b�h�\�������擪�ɃX�N���[��
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Control�L�[�Ƃ̑g�����̏ꍇ
                if (e.Modifiers == Keys.Control)
                {
                    // �O���b�h�\�������擪�ɃX�N���[��
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                    // �擪�s�Ɉړ�
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
            }

            // End�L�[
            if (e.KeyCode == Keys.End)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;

                // ���L�[�Ƃ̑g���������̏ꍇ
                if (e.Modifiers == Keys.None)
                {
                    // �O���b�h�\�������擪�ɃX�N���[��
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Control�L�[�Ƃ̑g�����̏ꍇ
                if (e.Modifiers == Keys.Control)
                {
                    // �O���b�h�\�����E�����ɃX�N���[��
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                    // �ŏI�s�Ɉړ�
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
        }

        /// <summary>
        /// �O���b�h�s�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
			// �I���s����
			this.SelectRow();
		}

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
        }

        /// <summary>
        /// �I���s���擾�^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
			this.timer_SelectRow.Enabled = false;
            if (this.uGrid_Details.ActiveRow != null)
            {
				// �I���s�̃C���f�b�N�X���擾
				CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
				int index = cm.Position;
				
				this._stockAdjRefSearchRetWork = this._searchSlipAcs.GetSelectedRowData(index);
                this.SetMainDialogResult(DialogResult.OK);
                this.CloseMain();
            }
        }

        /// <summary>
        /// �s�I������
        /// </summary>
		public void SelectRow()
		{
			if (StartMovment == 1) return;

			if (this.uGrid_Details.ActiveRow != null)
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
				int index = cm.Position;

				this._stockAdjRefSearchRetWork = this._searchSlipAcs.GetSelectedRowData(index);
				this.SetMainDialogResult(DialogResult.OK);
				this.CloseMain();
			}
		}

        /// <summary>
        /// �O���b�h(����)�t�H�[�J�X�ݒ�^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_GridSetFocus_Tick(object sender, EventArgs e)
        {
            this.uGrid_Details.Focus();

            if (this.uGrid_Details.ActiveRow != null)
            {
                this.uGrid_Details.ActiveRow.Selected = true;
            }

            this.timer_GridSetFocus.Enabled = false;
        }

        /// <summary>
        /// ���׏��{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_StockSearch_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

			CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
			int index = cm.Position;
			
			// ���ݑI���s�̎d���`�[���擾
            StockAdjRefSearchRetWork stockAdjRefSearchRetWork = this._searchSlipAcs.GetSelectedRowData(index);

            // ���׎Q�Ɖ�ʂ��N��
            PMZAI04001UC searchDetail = new PMZAI04001UC(stockAdjRefSearchRetWork);
            DialogResult dialogResult = searchDetail.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                this._stockAdjRefSearchRetWork = this._searchSlipAcs.GetSelectedRowData(index);
                this.SetMainDialogResult(DialogResult.OK);
                this.CloseMain();
            }
        }

        # endregion

    }
}
