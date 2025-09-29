using System;
using System.Collections;
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
    /// �݌Ɏd���`�[�Ɖ� ���׏��t�H�[���N���X�i���ז��j
    /// </summary>
    /// <remarks>
    /// Note       : �݌Ɏd���`�[�̖��׏��\���t�H�[���N���X�ł��B<br />
    /// Programmer : 22018 ��� ���b<br />
    /// Date       : 2008.09.02<br />
    /// <br />
    /// Update Note: 2009/02/16 30414 �E �K�j ��QID:10825�Ή�<br />
    /// </remarks>
	public partial class PMZAI04001UC : Form
    {
        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="stockAdjRefSearchRetWork"></param>
        public PMZAI04001UC(StockAdjRefSearchRetWork stockAdjRefSearchRetWork)
		{
			InitializeComponent();

            if (stockAdjRefSearchRetWork != null)
            {
                this._stockAdjRefSearchRetWork = stockAdjRefSearchRetWork;
            }
            this._searchMain = new PMZAI04001UA();
            this._searchSlipAcs = StockAdjRefAcs.GetInstance();
            this._dataSet = this._searchSlipAcs.DataSet;
			this.uGrid_ViewDetails.DataSource = this._dataSet.StockAdjustDtl;

            this._imageList16 = IconResourceManagement.ImageList16;
            this._returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_ViewDetail.Tools["ButtonTool_Return"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_ViewDetail.Tools["ButtonTool_Decision"];
        }
        # endregion

        # region [private �t�B�[���h]
        private PMZAI04001UA _searchMain;
        private StockAdjRefAcs _searchSlipAcs;
        private StockAdjDataSet _dataSet;
		private ImageList _imageList16 = null;									// �C���[�W���X�g
        private StockAdjRefSearchRetWork _stockAdjRefSearchRetWork;
        private string[] _supplierFormalStr = new string[3];                    // �d���`��
        SortedList _supplierSlipCdStr = new SortedList();                       // �`�[�`��
        private string[] _stockGoodsCdStr = new string[7];                      // ���i�敪
        private string[] _accPayDivCdStr = new string[2];                       // ���|�敪

        private Infragistics.Win.UltraWinToolbars.ButtonTool _returnButton;		// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// �m��{�^��

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        # endregion

        # region [�����ݒ菈��]

        /// <summary>
        /// �w�b�_�����ݒ菈��
        /// </summary>
        private void SetHeaderInfo()
        {

            this.uLabel_SectionCode.Text = _stockAdjRefSearchRetWork.SectionCode;
            this.uLabel_SectionName.Text = _stockAdjRefSearchRetWork.SectionGuideSnm;
            // --- DEL 2009/02/16 ��QID:10825�Ή�------------------------------------------------------>>>>>
            //this.uLabel_WarehouseCd.Text = _stockAdjRefSearchRetWork.WarehouseCode;
            //this.uLabel_WarehouseName.Text = _stockAdjRefSearchRetWork.WarehouseName;
            // --- DEL 2009/02/16 ��QID:10825�Ή�------------------------------------------------------<<<<<
            this.uLabel_AcPaySlipCdNm.Text = _searchSlipAcs.GetAcPaySlipCdName(_stockAdjRefSearchRetWork.AcPaySlipCd);
            this.uLabel_InputDay.Text = this.GetDateText( _stockAdjRefSearchRetWork.InputDay );
            this.uLabel_AdjustDate.Text = this.GetDateText( _stockAdjRefSearchRetWork.AdjustDate );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 DEL
            //this.uLabel_StockAdjustSlipNo.Text = _stockAdjRefSearchRetWork.StockAdjustSlipNo.ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
            this.uLabel_StockAdjustSlipNo.Text = this.GetSlipNoText( _stockAdjRefSearchRetWork.StockAdjustSlipNo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
            this.uLabel_StockAgentCode.Text = _stockAdjRefSearchRetWork.StockAgentCode;
            this.uLabel_StockAgentName.Text = _stockAdjRefSearchRetWork.StockAgentName;

        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
        /// <summary>
        /// �`�[�ԍ��e�L�X�g�擾(�[���l)
        /// </summary>
        /// <param name="slipNo"></param>
        /// <returns></returns>
        private string GetSlipNoText( int slipNo )
        {
            const string ct_SlipNoEditName = "tNedit_SupplierSlipNo";

            // �t�h���ʐݒ�XML���猅�����擾����
            Broadleaf.Library.Windows.Forms.UiSet uiSet;
            if ( this.uiSetControl1.ReadUISet( out uiSet, ct_SlipNoEditName ) == 0 )
            {
                return slipNo.ToString( new string( '0', uiSet.Column ) );
            }
            else
            {
                return slipNo.ToString();
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD

        /// <summary>
		/// �O���b�h�񏉊��ݒ菈��
		/// </summary>
		private void GridColInitialSetting()
		{
			string priceFormat = "#,##0;-#,##0;''";
			string floatFormat = "#,##0.00;-#,##0.00;''";

			// �Œ���؂���ݒ�
			this.uGrid_ViewDetails.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor2;

			// ���͋��ݒ�
			for (int i = 0; i < this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[i].AutoEdit = false;
				this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[i].Hidden = true;
			}


            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_ViewDetails.DisplayLayout.Bands[0];
            int visiblePosition = 0;

            # region [�J�����ݒ�]

            // �O���b�h�s�ԍ�
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Header.Caption = "��";
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Width = 30;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor2;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���i�ԍ�
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���i����
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���[�J�[����
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].Header.Caption = "���[�J�[��";
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // BL���i�R�[�h
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].Header.Caption = "BL����";
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].Width = 55;
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i�艿�i�����j�j
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Header.Caption = "";
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Format = floatFormat;

            // �i�I�[�v�����i�敪�j
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].Header.Caption = "";
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �艿�i�\���p�j
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].Header.Caption = "�W�����i";
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ������
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Header.Caption = "����";
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Format = floatFormat;

            // �d���P���i�Ŕ�,�����j
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Header.Caption = "���P��";
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Format = floatFormat;

            // �d�����z�i�Ŕ����j
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Header.Caption = "�d�����z";
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Format = priceFormat;

            // ���ה��l
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].Header.Caption = "���ה��l";
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // --- ADD 2009/02/16 ��QID:10825�Ή�------------------------------------------------------>>>>>
            // �q�ɃR�[�h
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].Header.Caption = "�q�ɃR�[�h";
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �q�ɖ�
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].Header.Caption = "�q�ɖ�";
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/16 ��QID:10825�Ή�------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
            // �I��
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].Header.Caption = "�I��";
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD

            # endregion
        }

        /// <summary>
		/// �O���b�h�s�����ݒ菈��
		/// </summary>
		private void GridRowInitialSetting()
		{
			this._dataSet.StockAdjustDtl.Rows.Clear();
		}

		/// <summary>
		/// �{�^�������ݒ菈��
		/// </summary>
		private void ButtonInitialSetting()
		{
            this.tToolbarsManager_ViewDetail.ImageListSmall = this._imageList16;
            this._returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }
        # endregion

        # region �R���g���[���C�x���g���\�b�h

        /// <summary>
        /// �O���b�h�G���^�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_ViewDetails.Rows.Count != 0)
            {
                //this.uButton_StockSearch.Enabled = true;
            }

            timer_InitialSetSelect.Enabled = true;
        }

        /// <summary>
        /// �O���b�h�t�H�[�J�X���E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_ViewDetails.ActiveRow == null) return;

            // Enter�L�[
            if (e.KeyCode == Keys.Enter)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
            }

            // �ŏ�s�ł́��L�[
            if (this.uGrid_ViewDetails.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                    e.Handled = true;
                    //this.uButton_StockSearch.Focus();
                }
            }

            // �����L�[
            if (e.KeyCode == Keys.Right)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                // �O���b�h�\�����E�ɃX�N���[��
                this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position + 40;
            }

            // �����L�[
            if (e.KeyCode == Keys.Left)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                if (this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                    //this.uButton_StockSearch.Focus();
                }
                else
                {
                    // �O���b�h�\�������ɃX�N���[��
                    this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position - 40;
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
                    this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Control�L�[�Ƃ̑g�����̏ꍇ
                if (e.Modifiers == Keys.Control)
                {
                    // �O���b�h�\�������擪�ɃX�N���[��
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                    // �擪�s�Ɉړ�
                    this.uGrid_ViewDetails.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
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
                    this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Control�L�[�Ƃ̑g�����̏ꍇ
                if (e.Modifiers == Keys.Control)
                {
                    // �O���b�h�\�����E�����ɃX�N���[��
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                    // �ŏI�s�Ɉړ�
                    this.uGrid_ViewDetails.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
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
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tToolbarsManager_ViewDetail_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Return":
                    {
                        // �I������
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // �m�菈��
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                       
                        break;
                    }
            }
        }

        /// <summary>
        /// �O���b�h�s�I��ݒ�^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_InitialSetSelect_Tick(object sender, EventArgs e)
        {
            if (this.uGrid_ViewDetails.ActiveRow != null)
            {
                this.uGrid_ViewDetails.ActiveRow.Selected = true;
            }
            timer_InitialSetSelect.Enabled = false;
        }


        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI04001UC_Load( object sender, EventArgs e )
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin( this );

            // �O���b�h�񏉊��ݒ菈��
            this.GridColInitialSetting();

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // �O���b�h�s�����ݒ菈��
            this.GridRowInitialSetting();

            // �w�b�_�����ݒ菈��
            this.SetHeaderInfo();

            // �Ώۓ`�[�̖��׏����擾
            this._searchSlipAcs.SetDetailData( this._stockAdjRefSearchRetWork.StockAdjustSlipNo );
        }
        # endregion

        # region [�ėp����]
        /// <summary>
        /// ���t������擾����
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string GetDateText( DateTime dateTime )
        {
            const string dateFormat = "yyyy�NMM��dd��";

            if ( dateTime != DateTime.MinValue )
            {
                return dateTime.ToString( dateFormat );
            }
            else
            {
                return string.Empty;
            }
        }
        # endregion

    }
}
