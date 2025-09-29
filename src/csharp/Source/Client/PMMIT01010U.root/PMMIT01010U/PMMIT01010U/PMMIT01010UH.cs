using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Collections;


namespace Broadleaf.Windows.Forms
{
    public partial class PMMIT01010UH : UserControl
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="estimateInputAcs"></param>
        public PMMIT01010UH( EstimateInputAcs estimateInputAcs )
        {
            InitializeComponent();

            this._estimateInputAcs = estimateInputAcs;

            this._primeInfoView = this._estimateInputAcs.PrimeInfoView;
            this._primeInfoDataTable = this._estimateInputAcs.PrimeInfoDataTable;
            this.uGrid_PrimeInfo.DataSource = this._primeInfoView;
            this._estimateInputAcs.PimeInfoFilterChanged += new EventHandler(this.PrimeInfoChanged);
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ��Private Member

        private EstimateInputAcs _estimateInputAcs;
        private EstimateInputDataSet.PrimeInfoDataTable _primeInfoDataTable;
        private DataView _primeInfoView;

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region ��Properties
        /// <summary>�D�ǃf�[�^��</summary>
        internal int PrimeDataCount
        {
            get { return this.uGrid_PrimeInfo.Rows.Count; }
        }
        #endregion

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        #region ��Control Event

        /// <summary>
        /// �O���b�h InitializeLayout�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_PrimeInfo_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
        {
            string moneyFormat = "#,##0;-#,##0;''";
            string decimalFormat = "#,##0.00;-#,##0.00;''";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_PrimeInfo.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.Header.Fixed = false;
                //���͋��ݒ�
                //column.AutoEdit = false;
            }

            int visiblePosition = 1;
            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------
            #region �J�������̐ݒ�

            //this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, false, 54));					// BL�R�[�h
            //this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, false, 140));					// ���i��
            //this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, false, 140));					// �i��
            //this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, false, 48));				// ���[�J�[�R�[�h
            //this._estimateDetailDataTable.MakerNameColumn.ColumnName, visiblePosition++, false, 100));					// ���[�J�[����
            //this._estimateDetailDataTable.ShipmentCntDisplayColumn.ColumnName, visiblePosition++, false, 40));			// QTY
            //this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, false, 90));			// �艿
            //this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, false, 30));			// OP
            //this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, false, 45));				// �q��
            //this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, false, 72));			// �I��
            //this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, visiblePosition++, false, 55));				// ���݌ɐ�
            //this._estimateDetailDataTable.SetExistsColumn.ColumnName, visiblePosition++, false, 42));					// �Z�b�g
            //this._estimateDetailDataTable.SupplierCdColumn.ColumnName, visiblePosition++, false, 72));					// �d����
            //this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, false, 42));					// ���
            //this._estimateDetailDataTable.OrderSelectColumn.ColumnName, visiblePosition++, false, 42));					// ����

            // �I���t���O
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].AutoEdit = true;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.SelectionStateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �i��
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.GoodsNoColumn.ColumnName].Width = 140;

            // �i��
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.GoodsNameColumn.ColumnName].Width = 140;

            // ���[�J�[�R�[�h
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.GoodsMakerCdColumn.ColumnName].Width = 48;

            // ���[�J�[��
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].Header.Fixed = true;
            Columns[this._primeInfoDataTable.MakerNameColumn.ColumnName].Width = 140;

            // �W�����i
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].Format = moneyFormat;
            Columns[this._primeInfoDataTable.ListPriceDisplayColumn.ColumnName].Width = 90;

            // QTY
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].Format = decimalFormat;
            Columns[this._primeInfoDataTable.ShipmentCntColumn.ColumnName].Width = 60;

            // �q��
            Columns[this._primeInfoDataTable.WarehouseCodeColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.WarehouseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.WarehouseCodeColumn.ColumnName].Width = 45;

            // �I��
            Columns[this._primeInfoDataTable.WarehouseShelfNoColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.WarehouseShelfNoColumn.ColumnName].Width = 72;

            // ���݌ɐ�
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].Format = decimalFormat;
            Columns[this._primeInfoDataTable.ShipmentPosCntColumn.ColumnName].Width = 55;

            // �Z�b�g�L��
            Columns[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Width = 42;

            // �����I��L��
            Columns[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.OrderSelectColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Width = 42;

            // �������l
            Columns[this._primeInfoDataTable.JoinSpecialNoteColumn.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.JoinSpecialNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.JoinSpecialNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.JoinSpecialNoteColumn.ColumnName].Width = 200;

            // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // ���
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].Hidden = false;
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].Width = 200;
            Columns[this._primeInfoDataTable.PrmSetDtlName2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion

            // �Œ���؂���ݒ�
            this.uGrid_PrimeInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_PrimeInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
            
        }

        /// <summary>
        /// �O���b�h Click�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : ���N�n�� 2011/11/24</br>
        /// <br>            : redmine#8034,�O�ԃf�[�^�̕��i�����ŕW�����i�I���̕i�ԕ\���Ō��i�Ԃ��\�������̏C��</br>
        private void uGrid_PrimeInfo_Click( object sender, EventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElement���擾����B
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow != null)
            {
                Guid primeRelationGuid = (Guid)objRow.Cells[this._primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName].Value;
                int joinDispOrder = (Int32)objRow.Cells[this._primeInfoDataTable.JoinDispOrderColumn.ColumnName].Value;
                //---------ADD 2009/11/13-------->>>>>
                EstimateInputDataSet.PrimeInfoRow primeInfoRow = this._estimateInputAcs.PrimeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeRelationGuid, joinDispOrder);
                if (primeRelationGuid == Guid.Empty || primeInfoRow == null) return;
                if (primeInfoRow.SelectionState == true) return;
                //---------ADD 2009/11/13--------<<<<<
                this._estimateInputAcs.SelectPrimeInfo(primeRelationGuid, joinDispOrder);
                //-----------ADD 2009/10/22-------->>>>>
                EstimateInputDataSet.PrimeInfoRow row = this._estimateInputAcs.PrimeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeRelationGuid, joinDispOrder);

                if (row != null)
                {
                    #region �W�����i�I���E�C���h�E
                    // ��ʓ��͒l�̕W�����i�I�����u����v�̏ꍇ
                    if (this._estimateInputAcs._priceSelectValue == 1)
                    {
                        // ���o�����ݒ�
                        GoodsCndtn cndtn = new GoodsCndtn();
                        cndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        cndtn.SectionCode = this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd;
                        cndtn.GoodsMakerCd = row.GoodsMakerCd;
                        cndtn.GoodsNo = row.GoodsNo;

                        //-----------UPD 2009/11/05--------->>>>>
                        PartsInfoDataSet _partsInfoDataSet = null;
                        ArrayList custRateGroupList;
                        ArrayList displayDivList;

                        // ����������
                        if (this._estimateInputAcs._primeRelationDic.ContainsKey(row.PrimeInfoRelationGuid))
                        {
                            _partsInfoDataSet = this._estimateInputAcs._primeRelationDic[row.PrimeInfoRelationGuid];
                        }
                        if (_partsInfoDataSet == null) return;
                        // ���Ӑ�|���O���[�v�R�[�h�}�X�^�̑S���擾
                        this._estimateInputAcs.GetCustRateGrpList(out custRateGroupList, cndtn.EnterpriseCode);
                        // �W�����i�I��ݒ�}�X�^�̎擾
                        this._estimateInputAcs.GetDisplayDivList(out displayDivList, cndtn.EnterpriseCode);
                        List<PriceSelectSet> priceSelectSet = new List<PriceSelectSet>((PriceSelectSet[])displayDivList.ToArray(typeof(PriceSelectSet)));

                        //������������عް�
                        if (_partsInfoDataSet.SearchPartsForSrcParts == null)
                        {
                            _partsInfoDataSet.SearchPartsForSrcParts += new PartsInfoDataSet.SearchPartsForSrcPartsCallBack(this._estimateInputAcs.SearchPartsForSrcParts);
                        }
                        //���Ӑ�|����ٰ�ߎ擾��عް�
                        if (_partsInfoDataSet.GetCustRateGrp == null)
                        {
                            _partsInfoDataSet.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(this._estimateInputAcs.GetCustRateGrp);
                        }
                        //�\���敪�擾��عް�
                        if (_partsInfoDataSet.GetDisplayDiv == null)
                        {
                            _partsInfoDataSet.GetDisplayDiv += new PartsInfoDataSet.GetDisplayDivCallBack(this._estimateInputAcs.GetDisplayDiv);
                        }
                        // ����������
                        _partsInfoDataSet.SettingSrcPartsInfo(cndtn);
                        if (_partsInfoDataSet.PartsInfoDataSetSrcParts == null) return;
                        // ���Ӑ�|����ٰ�ߺ��ގ擾
                        _partsInfoDataSet.SettingCustRateGrpCode(custRateGroupList, this._estimateInputAcs.SalesSlip.CustomerCode, row.GoodsNo, row.GoodsMakerCd);
                        PartsInfoDataSet.UsrGoodsInfoRow urrentRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.GoodsNo);
                        // �\���敪�擾ގ擾
                        _partsInfoDataSet.SettingDisplayDiv(priceSelectSet, row.GoodsNo, row.GoodsMakerCd, row.BLGoodsCode, this._estimateInputAcs.SalesSlip.CustomerCode, urrentRow.CustRateGrpCode);
                        urrentRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.GoodsNo);

                        _partsInfoDataSet.GoodsNoSel = this._estimateInputAcs.GoodsEstimateNo;// ADD ���N�n�� 2011/11/24 Redmine#8034
                        // �W�����i�I���E�C���h�E�\������
                        SelectionListPrice selectionListPrice = new SelectionListPrice(row.GoodsMakerCd, row.MakerName, row.GoodsNo, row.GoodsName, row.ListPriceTaxExcFl, _partsInfoDataSet, urrentRow.PriceSelectDiv);
                        selectionListPrice.ShowDialog(this);
                        //-----------UPD 2009/11/05---------<<<<<

                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow = _partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.GoodsNo);
                        // 1:�艿(�I��)���g�p����
                        if (usrGoodsInfoRow.SelectedListPriceDiv == 1)
                        {
                            row.ListPriceDisplay = usrGoodsInfoRow.SelectedListPrice;
                            //-------UPD 2009/11/12------->>>>>
                            EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])this._estimateInputAcs.EstimateDetailDataTable.Select(string.Format("{0}='{1}'", this._estimateInputAcs.EstimateDetailDataTable.PrimeInfoRelationGuidColumn.ColumnName, row.PrimeInfoRelationGuid));
                            if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                            {

                                estimateDetailRows[0].ListPriceDisplay_Prime = usrGoodsInfoRow.SelectedListPrice;
                                estimateDetailRows[0].AcceptChanges();
                                this._estimateInputAcs.EstimateDetailRowListPriceSetting(estimateDetailRows[0].SalesRowNo, EstimateInputAcs.TargetData.PrimeParts, EstimateInputAcs.PriceInputType.PriceDisplay, estimateDetailRows[0].ListPriceDisplay_Prime);// ADD 2009/11/13

                            }
                            //-------UPD 2009/11/12-------<<<<<
                            row.AcceptChanges();
                        }
                    }

                    #endregion
                }
                //-----------ADD 2009/10/22--------<<<<<
            }
        }

        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region ��Public Methods

        /// <summary>
        /// �O���b�h�ĕ`�揈��
        /// </summary>
        public void GridRefresh()
        {
            this.PrimeInfoChanged(this.uGrid_PrimeInfo, new EventArgs());
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods

        /// <summary>
        /// �D�ǃf�[�^�r���[�̃t�B���^�[���ύX���ꂽ���ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeInfoChanged( object sender, EventArgs e )
        {
            try
            {
                this.uGrid_PrimeInfo.BeginUpdate();
                for (int index = 0; index < this.uGrid_PrimeInfo.Rows.Count; index++)
                {
                    this.PrimeInfoIconSetting(index);
                }
            }
            finally
            {
                this.uGrid_PrimeInfo.EndUpdate();
            }
        }

        /// <summary>
        /// �O���b�h�A�C�R���ݒ�
        /// </summary>
        /// <param name="rowIndex"></param>
        private void PrimeInfoIconSetting(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_PrimeInfo.DisplayLayout.Bands[0];

			if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                if (col.Key == this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName)
                {
                    this.DisplayExistSetInfo(rowIndex);
                }
                if (col.Key == this._primeInfoDataTable.OrderSelectColumn.ColumnName)
                {
                    this.DisplayExistUOEOrderInfo(rowIndex);
                }
            }
        }

        /// <summary>
        /// �Z�b�g���A�C�R���\��
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayExistSetInfo( int rowIndex )
        {
            if (rowIndex == -1) return;
            if (this._primeInfoView[rowIndex] != null)
            {
                if ((bool)this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.ExistSetInfoColumn.ColumnName].Value == true)
                {
                    this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.ExistSetInfo_DisplayColumn.ColumnName].Appearance.Image = null;
                }
            }
        }

        /// <summary>
        /// �����A�C�R���\��
        /// </summary>
        /// <param name="rowIndex"></param>
        private void DisplayExistUOEOrderInfo(int rowIndex)
        {
            if (rowIndex == -1) return;
            if (this._primeInfoView[rowIndex] != null)
            {
                if ((Guid)this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.UOEOrderGuidColumn.ColumnName].Value != Guid.Empty)
                {
                    this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                }
                else
                {
                    this.uGrid_PrimeInfo.Rows[rowIndex].Cells[this._primeInfoDataTable.OrderSelectColumn.ColumnName].Appearance.Image = null;
                }
            }
        }    

        #endregion
    }
}
