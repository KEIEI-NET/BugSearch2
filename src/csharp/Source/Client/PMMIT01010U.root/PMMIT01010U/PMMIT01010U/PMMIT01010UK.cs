using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������� �����I����̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ς�UOE�������s���t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.10.17 men �V�K�쐬</br>
    /// <br>Update     : 2011/02/14 dingjx</br>
    /// <br>Note       : �����I�����̐��ʃ`�F�b�N�����ǉ�</br>
    /// <br>Update     : 2011/03/08 dingjx</br>
    /// <br>Note       : ��Q�� #19686</br>
    /// <br>Update Note  : 2013/04/22 donggy</br>
    /// <br>�Ǘ��ԍ�     : 10900691-00 2013/05/15�z�M��</br>
    /// <br>               Redmine#35020�@�u�������ρv�́u�����I����ʁv�̃K�C�h�C��</br>
    /// </remarks>
    public partial class PMMIT01010UK : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructors

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMMIT01010UK(EstimateInputAcs estimateInputAcs)
        {
            InitializeComponent();

            this._estimateInputOrderSelectAcs = new EstimateInputOrderSelectAcs();
            this._uOESupplierAcs = new UOESupplierAcs();

            this._detailInput = new PMMIT01010UL(this._estimateInputOrderSelectAcs);
            this._detailInput.GridKeyDownTopRow += new EventHandler(this.DetailInput_GridKeyDownTopRow);
            this._detailInput.DetailDataChanged += new PMMIT01010UL.DetailDataChangedEventHandler(this.DetailDataChenged);

            this._controlScreenSkin = new ControlScreenSkin();
            this._currentUOESupplier = new UOESupplier();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();

            this._imageList16 = IconResourceManagement.ImageList16;
            this._backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Back"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Decision"];
            this._nextSupplierButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_NextSupplier"];
            this._orderCancelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_OrderCancel"];
            this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_Guide"];

            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
            this._backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._nextSupplierButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            this._orderCancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INTERRUPTION;
            this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ��Privaete Members

        private string _enterpriseCode;
        private UOESupplierAcs _uOESupplierAcs;
        private UOESupplier _currentUOESupplier;
        private DialogResult _dialogResult = DialogResult.Cancel;
        private EstimateInputDataSet.UOEOrderDataTable _uoeOrderDataTable;
        private EstimateInputDataSet.UOEOrderDetailDataTable _uoeOrderDetailDataTable;

        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        private EstimateInputOrderSelectAcs _estimateInputOrderSelectAcs;

        private ImageList _imageList16 = null;                                                  // �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _backButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _nextSupplierButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _orderCancelButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;


        private PMMIT01010UL _detailInput;

        private ControlScreenSkin _controlScreenSkin;

        #region ��Static Members

        #endregion

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region ��Properties
        /// <summary>�t�n�d�����f�[�^�e�[�u��</summary>
        public EstimateInputDataSet.UOEOrderDataTable UOEOrderDataTable
        {
            get { return this._uoeOrderDataTable; }
        }

        /// <summary>�t�n�d�������׃f�[�^�e�[�u��</summary>
        public EstimateInputDataSet.UOEOrderDetailDataTable UOEOrderDetailDataTable
        {
            get { return this._uoeOrderDetailDataTable; }
        }
        #endregion

        // ===================================================================================== //
        // �p�u���b�N ���\�b�h
        // ===================================================================================== //
        #region ��Public Methods

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="owner">�I�[�i�[�t�H�[��</param>
        /// <param name="estimateDetailDataTable">���ϖ��׃e�[�u��</param>
        /// <param name="primeInfoDataTable">�D�ǃf�[�^�e�[�u��</param>
        /// <param name="uoeOrderDataTable"></param>
        /// <param name="uoeOrderDetailDataTable"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(IWin32Window owner, EstimateInputDataSet.EstimateDetailDataTable estimateDetailDataTable, EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable, EstimateInputDataSet.UOEOrderDataTable uoeOrderDataTable, EstimateInputDataSet.UOEOrderDetailDataTable uoeOrderDetailDataTable)
        {
            this._estimateInputOrderSelectAcs.CreateOrderSelectDataTable(estimateDetailDataTable, primeInfoDataTable, uoeOrderDataTable, uoeOrderDetailDataTable);

            if (!this._estimateInputOrderSelectAcs.ExistData())
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                   this.Name,
                   "�����ΏۂƂȂ�f�[�^�����݂��܂���B",
                   0,
                   MessageBoxButtons.OK);
                return DialogResult.None;
            }
            
            return this.ShowDialog(owner);
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g ���\�b�h
        // ===================================================================================== //
        #region ��Private Methods

        /// <summary>
        /// ���׃O���b�h�ŏ�ʍs�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void DetailInput_GridKeyDownTopRow(object sender, EventArgs e)
        {
            tComboEditor_UOEResvdSection.Focus();
        }

        /// <summary>
        /// ��ʕ`�揈��
        /// </summary>
        /// <param name="rowIndex"></param>
        private void SetDisplay(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Supplier.Rows[rowIndex];
            //DataRowView drv = this._orderSelectHdView[rowIndex];
            if (row == null)
            {
                return;
            }
            this.tNedit_UOESupplierCd.BeginUpdate();
            this.uLabel_UOESupplierName.BeginUpdate();
            this.tEdit_UoeRemark1.BeginUpdate();
            this.tEdit_UoeRemark2.BeginUpdate();
            this.tComboEditor_DeliveredGoodsDiv.BeginUpdate();
            this.tComboEditor_FollowDeliGoodsDiv.BeginUpdate();
            this.tComboEditor_UOEResvdSection.BeginUpdate();
            this.uLabel_DeliveredGoodsDivTitle.BeginUpdate();
            this.uLabel_FollowDeliGoodsDivTitle.BeginUpdate();
            this.uLabel_UOEResvdSectionTitle.BeginUpdate();

            UOESupplier uOESupplier = (UOESupplier)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier].Value;
            if (uOESupplier == null) uOESupplier = new UOESupplier();
            try
            {
                this.tNedit_UOESupplierCd.SetInt((int)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd].Value);
                this.uLabel_UOESupplierName.Text = ( (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierName].Value );
                this.tEdit_UoeRemark1.Text = ( (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark1].Value );
                this.tEdit_UoeRemark2.Text = ( (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark2].Value );
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_DeliveredGoodsDiv, ( (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv].Value ).ToString(), true);
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_FollowDeliGoodsDiv, (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDiv].Value, true);
                ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_UOEResvdSection, (string)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSection].Value, true);

                this.tEdit_UoeRemark1.Visible = UOESupplierAcs.EnabledUOERemark1(uOESupplier.CommAssemblyId);
                this.tEdit_UoeRemark1.MaxLength = UOESupplierAcs.MaxLengthUOERemark1(uOESupplier.CommAssemblyId);
                this.tEdit_UoeRemark2.Visible = UOESupplierAcs.EnabledUOERemark2(uOESupplier.CommAssemblyId);
                this.tEdit_UoeRemark2.MaxLength = UOESupplierAcs.MaxLengthUOERemark2(uOESupplier.CommAssemblyId);
                this.tComboEditor_DeliveredGoodsDiv.Visible= UOESupplierAcs.EnabledDeliveredGoodsDiv(uOESupplier.CommAssemblyId);
                this.uLabel_DeliveredGoodsDivTitle.Visible = UOESupplierAcs.EnabledDeliveredGoodsDiv(uOESupplier.CommAssemblyId);
                this.tComboEditor_FollowDeliGoodsDiv.Visible = UOESupplierAcs.EnabledFollowDeliGoodsDiv(uOESupplier.CommAssemblyId);
                this.uLabel_FollowDeliGoodsDivTitle.Visible = UOESupplierAcs.EnabledFollowDeliGoodsDiv(uOESupplier.CommAssemblyId);
                this.tComboEditor_UOEResvdSection.Visible = UOESupplierAcs.EnabledUOEResvdSection(uOESupplier.CommAssemblyId);
                this.uLabel_UOEResvdSectionTitle.Visible = UOESupplierAcs.EnabledUOEResvdSection(uOESupplier.CommAssemblyId);
            }
            finally
            {
                this.tNedit_UOESupplierCd.EndUpdate();
                this.uLabel_UOESupplierName.EndUpdate();
                this.tEdit_UoeRemark1.EndUpdate();
                this.tEdit_UoeRemark2.EndUpdate();
                this.tComboEditor_DeliveredGoodsDiv.EndUpdate();
                this.tComboEditor_FollowDeliGoodsDiv.EndUpdate();
                this.tComboEditor_UOEResvdSection.EndUpdate();
                this.uLabel_DeliveredGoodsDivTitle.EndUpdate();
                this.uLabel_FollowDeliGoodsDivTitle.EndUpdate();
                this.uLabel_UOEResvdSectionTitle.EndUpdate();
            }
        }


        /// <summary>
        /// �c�[���o�[�{�^��Enabled�ݒ�
        /// </summary>
        /// <br>Update Note: 2013/04/22 donggy</br>
        /// <br>�Ǘ��ԍ�   : 10900691-00 2013/05/15�z�M��</br>
        /// <br>             Redmine#35020�@�u�������ρv�́u�����I����ʁv�̃K�C�h�C��</br>
        private void SettingToolBarButtonEnabled(Control nextContrl)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Supplier.Rows[this.uGrid_Supplier.ActiveRow.Index];
                this._orderCancelButton.SharedProps.Enabled = ( (bool)row.Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder].Value );

                //DataRowView drv = this._orderSelectHdView[this.uGrid_Supplier.ActiveRow.Index];
                //this._orderCancelButton.SharedProps.Enabled = ( (bool)drv[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder] );
            }
            else
            {
                this._orderCancelButton.SharedProps.Enabled = false;
            }
            this._guideButton.SharedProps.Enabled = ( ( nextContrl == this.tNedit_UOESupplierCd ) || ( nextContrl == this.uButton_UOESupplierGuide ) );
            // --- ADD donggy 2013/04/22 for Redmine#35020 --->>>>>
            // �t�H�[�J�X��������R�[�h�e�L�X�g�{�b�N�X�E������K�C�h�ɂ���ꍇ
            if ((this.tNedit_UOESupplierCd.Focused
                || this.uButton_UOESupplierGuide.Focused)
                && nextContrl.Equals(this.uGrid_Supplier))
            {
                this._guideButton.SharedProps.Enabled = true;
            }
            // --- ADD donggy 2013/04/22 for Redmine#35020 ---<<<<<
        }
        /// <summary>
        /// �e�R���{�G�f�B�^�̐ݒ�
        /// </summary>
        /// <param name="uoeSupplier"></param>
        private void ComboEditorSetting(int rowIndex)
        {
            this.ComboEditorSetting((UOESupplier)this.uGrid_Supplier.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier].Value);
        }

        /// <summary>
        /// �e�R���{�G�f�B�^�̐ݒ�
        /// </summary>
        /// <param name="uoeSupplier"></param>
        private void ComboEditorSetting(UOESupplier uoeSupplier)
        {
            // �[�i�敪�̃R���{�G�f�B�^�A�C�e���ݒ�
            this._estimateInputInitDataAcs.SetUOEGuideNameComboEditor(ref this.tComboEditor_DeliveredGoodsDiv, EstimateInputInitDataAcs.ctUOEGuideDivCd_DeliveredGoodsDiv, uoeSupplier.UOESupplierCd);
            // �g�[�i�敪�̃R���{�G�f�B�^�A�C�e���ݒ�
            this._estimateInputInitDataAcs.SetUOEGuideNameComboEditor(ref this.tComboEditor_FollowDeliGoodsDiv, EstimateInputInitDataAcs.ctUOEGuideDivCd_DeliveredGoodsDiv, uoeSupplier.UOESupplierCd);
            // �w�苒�_�̃R���{�G�f�B�^�A�C�e���ݒ�
            this._estimateInputInitDataAcs.SetUOEGuideNameComboEditor(ref this.tComboEditor_UOEResvdSection, EstimateInputInitDataAcs.ctUOEGuideDivCd_UOEResvdSection, uoeSupplier.UOESupplierCd);
        }

        /// <summary>
        /// �[�i�敪�ύX����
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True:�[�i�敪�ύX�L</returns>
        private bool ChangeDeliveredGoodsDiv(int index)
        {
            if (( this.tComboEditor_DeliveredGoodsDiv.Items == null ) ||
                ( this.tComboEditor_DeliveredGoodsDiv.Items.Count == 0 ))
            {
                return false;
            }

            bool isChanged = false;

            DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);

            string oldValue = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv];
            string newValue = (string)tComboEditor_DeliveredGoodsDiv.SelectedItem.DataValue;

            if (oldValue != newValue)
            {
                isChanged = true;
                string newName = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_DeliveredGoodsDiv, newValue);

                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = newValue;
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = newName;
                //row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEDeliGoodsDiv] = newCode;
                //row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_DeliveredGoodsDivNm] = newName;
            }

            return isChanged;
        }

        /// <summary>
        /// H�[�i�敪�ύX����
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True:H�[�i�敪�ύX�L</returns>
        private bool ChangeFollowDeliGoodsDiv(int index)
        {
            if (( this.tComboEditor_FollowDeliGoodsDiv.Items == null ) ||
                ( this.tComboEditor_FollowDeliGoodsDiv.Items.Count == 0 ))
            {
                return false;
            }

            DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);

            bool isChanged = false;
            string oldCode = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDiv];
            string newValue = (string)tComboEditor_FollowDeliGoodsDiv.SelectedItem.DataValue;

            if (oldCode != newValue)
            {
                isChanged = true;
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDiv] = newValue;
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_FollowDeliGoodsDivNm] = tComboEditor_FollowDeliGoodsDiv.SelectedItem.DisplayText;
            }

            return isChanged;
        }

        /// <summary>
        /// �w�苒�_�ύX����
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True:H�[�i�敪�ύX�L</returns>
        private bool ChangeUOEResvdSection(int index)
        {
            if (( this.tComboEditor_UOEResvdSection.Items == null ) ||
                ( this.tComboEditor_UOEResvdSection.Items.Count == 0 ))
            {
                return false;
            }

            DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);

            bool isChanged = false;
            string oldCode = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSection];
            string newValue = (string)tComboEditor_UOEResvdSection.SelectedItem.DataValue;
            if (oldCode != newValue)
            {
                isChanged = true;

                string newName = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_UOEResvdSection, newValue);
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSection] = newValue;
                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOEResvdSectionNm] = tComboEditor_UOEResvdSection.SelectedItem.DisplayText;
            }

            return isChanged;
        }

        /// <summary>
        /// ���d����I��
        /// </summary>
        private void SelectNextSupplier()
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                int rowIndex = 0;
                if (( this.uGrid_Supplier.ActiveRow.Index + 1 ) < this.uGrid_Supplier.Rows.Count)
                {
                    rowIndex = this.uGrid_Supplier.ActiveRow.Index + 1;
                }
                this.uGrid_Supplier.Rows[rowIndex].Selected = true;
                this.uGrid_Supplier.ActiveRow = this.uGrid_Supplier.Rows[rowIndex];

            }
        }

        /// <summary>
        /// ���וύX���C�x���g
        /// </summary>
        /// <param name="supplierCd">�d����</param>
        private void DetailDataChenged(int supplierCd)
        {
            this._estimateInputOrderSelectAcs.DetailDataChenged(supplierCd);
            
            this.SettingGrid();
        }

        /// <summary>
        /// ���׃O���b�h�ݒ菈��
        /// </summary>
        internal void SettingGrid()
        {
            try
            {
                // �`����ꎞ��~
                this.uGrid_Supplier.BeginUpdate();

                // �`�悪�K�v�Ȗ��׌������擾����B
                int cnt = this.uGrid_Supplier.Rows.Count;

                // �e�s���Ƃ̐ݒ�
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }
            }
            finally
            {
                // �`����J�n
                this.uGrid_Supplier.EndUpdate();
            }
        }

        /// <summary>
        /// ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// </summary>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        /// <param name="stockSlip">�d���f�[�^�N���X�I�u�W�F�N�g</param>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Supplier.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �Z�������擾
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Supplier.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                cell.Row.Hidden = false;

                // �A���_�[���C����S�ẴZ���ɑ΂��Ĕ�\���Ƃ���
                cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                // �����L�����擾
                bool existOrder = (bool)this.uGrid_Supplier.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrder].Value;

                #region �Z���A�C�R���Z�b�g

                if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay)
                {
                    if (existOrder)
                    {
                        cell.Appearance.Image = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    }
                    else
                    {
                        cell.Appearance.Image = null;
                    }
                }
                #endregion
            }
        }

        //  ADD 2011/02/14  >>>
        /// <summary>
        /// �����I�����̐��ʃ`�F�b�N
        /// </summary>
        private bool OrderSelectCheck()
        {
            bool flag = false;
            string eMessage = null;

            for (int i = 0; i < this._estimateInputOrderSelectAcs.HeaderView.Count; i++)
            {
                int supplierCd = (int)this._estimateInputOrderSelectAcs.HeaderView[i].Row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
                String supplierName = (this._estimateInputOrderSelectAcs.HeaderView[i].Row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm]).ToString();

                string message = this._estimateInputOrderSelectAcs.CheckDetail(supplierCd);
                if (message != null)
                {
                    eMessage += "\r\n  �d����  " + supplierName + "\r\n";
                    eMessage += message;
                }
            }

            // ADD 2011/03/08   >>>
            DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[this.uGrid_Supplier.ActiveRow.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);
            int tempSupplier = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
            this._estimateInputOrderSelectAcs.ChangeSupplier(tempSupplier);
            // ADD 2011/03/08   <<<

            if (eMessage != null)
            {
                flag = true;
                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "��������999�ȓ��œ��͂��ĉ������B\r\n" + eMessage,
                                    -1,
                                    MessageBoxButtons.OK);
            }
            
            return flag;
        }
        //  ADD 2011/02/14  <<<

        #endregion

        // ===================================================================================== //
        // �R���g���[���̃C�x���g
        // ===================================================================================== //
        #region ��Control Events

        /// <summary>
        /// �t�H�[�� Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._detailInput);

            this.uGrid_Supplier.DataSource = this._estimateInputOrderSelectAcs.HeaderView;

            //this.uGrid_Supplier.DataSource = this._orderSelectHdTable;

            //this._detailInput.DataSource = this._orderSelectDtlTable;

            this.panel_Detail.Controls.Add(this._detailInput);
            this._detailInput.Dock = DockStyle.Fill;

            this.uGrid_Supplier.Rows[0].Selected = true;
            this.uGrid_Supplier.ActiveRow = this.uGrid_Supplier.Rows[0];
            this.SettingToolBarButtonEnabled(this.uGrid_Supplier);

            this.uButton_UOESupplierGuide.ImageList = this._imageList16;
            this.uButton_UOESupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.SettingGrid();
        }

        /// <summary>
        /// �t�H�[�� Closed�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = this._dialogResult;
        }

        /// <summary>
        /// ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2013/04/22 donggy</br>
        /// <br>�Ǘ��ԍ�   : 10900691-00 2013/05/15�z�M��</br>
        /// <br>             Redmine#35020�@�u�������ρv�́u�����I����ʁv�̃K�C�h�C��</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            bool isChanged = false;
            if (this._detailInput.Contains(e.PrevCtrl))
            {
                switch (e.PrevCtrl.Name)
                {
                    #region ���׃O���b�h
                    //---------------------------------------------------------------
                    // ���׃O���b�h
                    //---------------------------------------------------------------
                    case "uGrid_Details":
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        if (this._detailInput.uGrid_Details.ActiveCell != null)
                                        {
                                            if (this._detailInput.ReturnKeyDown())
                                            {
                                                e.NextCtrl = null;
                                            }
                                        }

                                        break;
                                    }
                            }
                            break;
                        }
                    #endregion
                }
            }
            else
            {
                int index = this.uGrid_Supplier.ActiveRow.Index;
                DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);
                //DataRowView row = this._orderSelectHdView[index];
                switch (e.PrevCtrl.Name)
                {
                    #region ������R�[�h
                    case "tNedit_UOESupplierCd":
                        {
                            bool isError = false;

                            int supplierCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
                            int oldCode = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd];
                            int newCode = this.tNedit_UOESupplierCd.GetInt();
                            if (oldCode != newCode)
                            {
                                UOESupplier uOESupplier = new UOESupplier();
                                if (newCode == 0)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�����悪���͂���Ă��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);
                                    e.NextCtrl = e.PrevCtrl;
                                    isError = true;
                                }
                                else if (newCode != 0)
                                {
                                    int status = this._uOESupplierAcs.Read(out uOESupplier, this._enterpriseCode, newCode, LoginInfoAcquisition.Employee.BelongSectionCode);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "�Y�����锭���悪���݂��܂���B",
                                            -1,
                                            MessageBoxButtons.OK);
                                        e.NextCtrl = e.PrevCtrl;

                                        isError = true;
                                    }
                                }
                                else
                                {
                                    uOESupplier = new UOESupplier();
                                }

                                if (!isError)
                                {
                                    //this.UOESupplierInfoDefaultSetting(supplierCd, uOESupplier);
                                    this._estimateInputOrderSelectAcs.UOESupplierInfoDefaultSetting(supplierCd, uOESupplier);
                                    this._estimateInputOrderSelectAcs.DetailOrderCancel(supplierCd);
                                    this._detailInput.SettingGrid();
                                    this.ComboEditorSetting(uOESupplier);
                                    this._estimateInputOrderSelectAcs.DetailDataChenged(supplierCd);
                                    this.SettingGridRow(index);
                                    this._detailInput.UOESupplier = uOESupplier;
                                }
                                isChanged = true;
                            }

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ((int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd] == 0)
                                            {
                                                e.NextCtrl = this.uButton_UOESupplierGuide;
                                            }
                                            else if (!isError)
                                            {
                                                e.NextCtrl = this.tEdit_UoeRemark1;
                                            }
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                    #endregion

                    #region ������K�C�h
                    case "uButton_UOESupplierGuide":
                        {
                            break;
                        }
                    #endregion

                    #region �t�n�d���}�[�N�P
                    case "tEdit_UoeRemark1":
                        {
                            string oldValue = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark1];
                            string newValue = tEdit_UoeRemark1.Text;

                            if (newValue != oldValue)
                            {
                                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark1] = newValue;
                                isChanged = true;
                            }
                            
                            break;
                        }
                    #endregion

                    #region �t�n�d���}�[�N�Q
                    case "tEdit_UoeRemark2":
                        {
                            string oldValue = (string)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark2];
                            string newValue = tEdit_UoeRemark2.Text;
                            if (newValue != oldValue)
                            {
                                row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UoeRemark2] = newValue;
                                isChanged = true;
                            }
                            break;
                        }
                    #endregion

                    #region �[�i�敪
                    case "tComboEditor_DeliveredGoodsDiv":
                        {
                            this.tComboEditor_DeliveredGoodsDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_DeliveredGoodsDiv_SelectionChangeCommitted);

                            isChanged = this.ChangeDeliveredGoodsDiv(index);

                            this.tComboEditor_DeliveredGoodsDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_DeliveredGoodsDiv_SelectionChangeCommitted);
                            break;
                        }
                    #endregion

                    #region �t�H���[�[�i�敪
                    case "tComboEditor_FollowDeliGoodsDiv":
                        {
                            this.tComboEditor_FollowDeliGoodsDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_FollowDeliGoodsDiv_SelectionChangeCommitted);

                            isChanged = this.ChangeFollowDeliGoodsDiv(index);

                            this.tComboEditor_FollowDeliGoodsDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_FollowDeliGoodsDiv_SelectionChangeCommitted);
                            break;
                        }
                    #endregion

                    #region �w�苒�_
                    case "tComboEditor_UOEResvdSection":
                        {
                            this.tComboEditor_UOEResvdSection.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_UOEResvdSection_SelectionChangeCommitted);

                            isChanged = this.ChangeUOEResvdSection(index);

                            this.tComboEditor_UOEResvdSection.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_UOEResvdSection_SelectionChangeCommitted);
                            break;
                        }
                    #endregion
                }
            }

            if (isChanged)
            {
                this.SetDisplay(this.uGrid_Supplier.ActiveRow.Index);
            }

            this.SettingToolBarButtonEnabled(e.NextCtrl);
            // --- ADD donggy 2013/04/22 for Redmine#35020 --->>>>>
            // �t�H�[�J�X��������R�[�h�e�L�X�g�{�b�N�X�E������K�C�h�ɂ���ꍇ
            if ((e.PrevCtrl.Name == "tNedit_UOESupplierCd"
                || e.PrevCtrl.Name == "uButton_UOESupplierGuide")
                && (e.NextCtrl is Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea))
            {
                this._guideButton.SharedProps.Enabled = true;
            }
            if ((e.PrevCtrl.Name == "tNedit_UOESupplierCd"
                || e.PrevCtrl.Name == "uButton_UOESupplierGuide")
                && (!(e.NextCtrl is Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea)
                    && e.NextCtrl.Name != "uButton_UOESupplierGuide"
                    && e.NextCtrl.Name != "tNedit_UOESupplierCd"))
            {
                this._guideButton.SharedProps.Enabled = false;
            }
            // --- ADD donggy 2013/04/22 for Redmine#35020 ---<<<<<
        }

        /// <summary>
        /// �t�n�d������K�C�h�{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2013/04/22 donggy</br>
        /// <br>�Ǘ��ԍ�   : 10900691-00 2013/05/15�z�M��</br>
        /// <br>             Redmine#35020�@�u�������ρv�́u�����I����ʁv�̃K�C�h�C��</br>
        private void uButton_UOESupplierGuide_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow == null) return;
            UOESupplier uOESupplier;

            int rowIndex = this.uGrid_Supplier.ActiveRow.Index;

            int status = this._uOESupplierAcs.ExecuteGuid(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out uOESupplier);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);
                int supplierCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
                int uoeSupplierCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplierCd];

                if (uoeSupplierCd != uOESupplier.UOESupplierCd)
                {
                    this._estimateInputOrderSelectAcs.UOESupplierInfoDefaultSetting(supplierCd, uOESupplier);
                    this._estimateInputOrderSelectAcs.DetailOrderCancel(supplierCd);
                    this._estimateInputOrderSelectAcs.DetailDataChenged(supplierCd);
                    this.ComboEditorSetting(uOESupplier);
                    this._detailInput.SettingGrid();
                    this.SettingGridRow(rowIndex);
                    this._detailInput.UOESupplier = uOESupplier;
                    this.SetDisplay(rowIndex);
                }
                // --- ADD donggy 2013/04/22 for Redmine#35020 --->>>>>>>
                if (this.tNedit_UOESupplierCd.Focused
                   || this.uButton_UOESupplierGuide.Focused)
                {
                    this._guideButton.SharedProps.Enabled = true;
                }
                else
                {
                    this._guideButton.SharedProps.Enabled = false;
                }
                // --- ADD donggy 2013/04/22 for Redmine#35020 ---<<<<<<<
            }
        }

        /// <summary>
        /// �O���b�h InitializeLayout�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Supplier_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Supplier.DisplayLayout.Bands[0].Columns;

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

            // �����L��
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Header.Caption = "����";
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_ExistOrderDisplay].Width = 60;

            // �d����
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].Header.Caption = "�d����";
            Columns[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierSnm].Width = 140;

            #endregion

            // �Œ���؂���ݒ�
            this.uGrid_Supplier.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Supplier.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_Supplier.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        /// <summary>
        /// �O���b�h�s�A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Supplier_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                DataRow row = this._estimateInputOrderSelectAcs.GetOrderSelectHeaderRow((int)this.uGrid_Supplier.Rows[this.uGrid_Supplier.ActiveRow.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value);
                int supplierCd = (int)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd];
                UOESupplier uOESupplier = (UOESupplier)row[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_UOESupplier];

                this._estimateInputOrderSelectAcs.ChangeSupplier(supplierCd);
                this._detailInput.SupplierCd = supplierCd;
                this._detailInput.UOESupplier = uOESupplier;
                this.ComboEditorSetting(uOESupplier);
                this.SetDisplay(this.uGrid_Supplier.ActiveRow.Index);
                this.SettingToolBarButtonEnabled(this.uGrid_Supplier);
            }
        }

        /// <summary>
        /// �t�H���[�[�i�敪�I���m��㔭���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_FollowDeliGoodsDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                this.ChangeFollowDeliGoodsDiv(this.uGrid_Supplier.ActiveRow.Index);
            }
        }

        /// <summary>
        /// �[�i�敪�I���m��㔭���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DeliveredGoodsDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                this.ChangeDeliveredGoodsDiv(this.uGrid_Supplier.ActiveRow.Index);
            }
        }

        /// <summary>
        /// �w�苒�_�I���m��㔭���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_UOEResvdSection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.uGrid_Supplier.ActiveRow != null)
            {
                this.ChangeUOEResvdSection(this.uGrid_Supplier.ActiveRow.Index);
            }
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2013/04/22 donggy</br>
        /// <br>�Ǘ��ԍ�   : 10900691-00 2013/05/15�z�M��</br>
        /// <br>             Redmine#35020�@�u�������ρv�́u�����I����ʁv�̃K�C�h�C��</br>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �߂�
                case "ButtonTool_Back":
                    {
                        this.Close();
                        break;
                    }
                // �m��
                case "ButtonTool_Decision":
                    {
                        //  UPD 2011/02/14  >>>
                        if (! this.OrderSelectCheck())
                        {
                            this._estimateInputOrderSelectAcs.GetOrderSelectData(out this._uoeOrderDataTable, out this._uoeOrderDetailDataTable);

                            this._dialogResult = DialogResult.OK;
                            this.Close();
                        }
                        //  UPD 2011/02/14  <<<
                        break;
                    }
                // ���̎d����
                case "ButtonTool_NextSupplier":
                    {
                        this.SelectNextSupplier();
                        break;
                    }
                // �������
                case "ButtonTool_OrderCancel":
                    {
                        if (this.uGrid_Supplier.ActiveRow != null)
                        {
                            int supplierCd = (int)this.uGrid_Supplier.Rows[this.uGrid_Supplier.ActiveRow.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd].Value;
                            this._estimateInputOrderSelectAcs.OrderCancel(supplierCd);
                            //this.OrderCancel((int)this._orderSelectHdView[this.uGrid_Supplier.ActiveRow.Index][EstimateInputOrderSelectAcs.OrderSelectHdTable.ctColName_SupplierCd]);
                            this.ComboEditorSetting(this.uGrid_Supplier.ActiveRow.Index);
                            this.SettingGridRow(this.uGrid_Supplier.ActiveRow.Index);
                            this.SetDisplay(this.uGrid_Supplier.ActiveRow.Index);
                            this._detailInput.SettingGrid();
                        }
                        break;
                    }
                // �K�C�h
                case "ButtonTool_Guide":
                    {
                        uButton_UOESupplierGuide_Click(this.uButton_UOESupplierGuide, new EventArgs ()); // ADD donggy 2013/04/22 for Redmine#35020
                        break;
                    }
            }
        }

        #endregion

        /// <summary>
        /// �t�H�[���L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UK_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        // ===================================================================================== //
        // �v���C�x�[�g �X�^�e�B�b�N ���\�b�h
        // ===================================================================================== //
        #region ��Private Static Methods
       
        #endregion
    }

}