//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�c�_��������
// �v���O�����T�v   : �}�c�_�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : �����
// �� �� ��  2011/05/18  �C�����e : �V�K�쐬
//                                  �}�c�_WebUOE�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^����}�c�_�p�V�X�e���A�g�A�h���X�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : wangyl
// �C �� ��  2013/02/06  �C�����e : 10900690-00 2013/03/13�z�M���ً̋}�Ή�
//                                  Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �}�c�_�������� ���׃R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �}�c�_���������̖��ד��͂��s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
    /// <br>              Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
    /// </remarks>
    public partial class PMUOE01541UB : UserControl
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constroctors
        /// <summary>
        /// ���͖��ד��̓R���g���[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͖��ד��̓R���g���[���N���X �f�t�H���g���s���R���g���[���N���X�ł��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public PMUOE01541UB()
        {
            InitializeComponent();

            // �{�^��������
            this._rowSelectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowSelect"];
            this._rowCancellButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_RowCancell"];

            this._imageList16 = IconResourceManagement.ImageList16;
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this._mazdaOrderProcAcs = MazdaOrderProcAcs.GetInstance();
            this._orderDataTable = this._mazdaOrderProcAcs.OrderDataTable;

            this._uOEGuideNameAcs = new UOEGuideNameAcs();
            this._boCodeTable = new Hashtable();
            this._deliGoodsDivTable = new Hashtable();
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members

        private Image _guideButtonImage;
        //�{�^����`
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowSelectButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rowCancellButton;

        //�J���[��`
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        private ImageList _imageList16 = null;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private MazdaOrderProcAcs _mazdaOrderProcAcs;
        private MazdaOrderProcDataSet.OrderExpansionDataTable _orderDataTable;

        //�w�b�_�[����ʓ��̓N���X
        private MazdaInpHedDisplay _inpHedDisplay = null;

        //�Ɩ��敪
        private int _businessCode = ctTerminalDiv_Order;

        //�O���b�h���͑O�l
        private double _beforeAcceptAnOrderCnt = 0;	//����

        private UOEGuideNameAcs _uOEGuideNameAcs;    // UOE�K�C�h���̃}�X�^ �A�N�Z�X�N���X

        private string _beforeBoCode = "";			//�a�n�敪

        private Hashtable _deliGoodsDivTable;
        private Hashtable _boCodeTable;
        # endregion

        #region static �ϐ�
        /// <summary>������R�[�h</summary>
        public static int _supplierCd;
        /// <summary>���_�R�[�h</summary>
        public static string _sectionCode;
        /// <summary>���ʉ��̓t���O</summary>
        public static bool _countFlg = false;
        /// <summary>�莩���t���O�i�O�F�蓮�P�F�����j</summary>
        public static int _inqOrdDivCdFlg;
        /// <summary>�����f�[�^�����݃t���O</summary>
        public static bool _searchNoDateFlg = false;
        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        # region �Ɩ��敪
        /// <summary>
        /// �Ɩ��敪
        /// </summary>
        public int BusinessCode
        {
            get
            {
                return this._businessCode;
            }
            set
            {
                this._businessCode = value;
            }
        }
        # endregion
        # endregion

        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        # region Const Members
        //�Ɩ��敪
        private const Int32 ctTerminalDiv_Order = 1;	//����
        private const Int32 ctTerminalDiv_Cancel = 2;//�������

        //�V�X�e���敪
        private const Int32 ctSysDiv_Input = 0;	//�����
        private const Int32 ctSysDiv_Slip = 1;	//�`������
        private const Int32 ctSysDiv_Srch = 2;	//��������
        private const Int32 ctSysDiv_stock = 3;	//�݌Ɉꊇ
        # endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region private Control Event Methods

        #region ��Load�C�x���g
        /// <summary>
        /// ���Load�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Load�C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void PMUOE01541UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.DataSource = this._orderDataTable;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // �O���b�h�L�[�}�b�s���O�ݒ菈��
            this.MakeKeyMappingForGrid(this.uGrid_Details);

            // �N���A����
            this.Clear();
        }
        #endregion

        # region ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        internal void Clear()
        {
            // DataTable�s�N���A����
            this._orderDataTable.Rows.Clear();

            // ���׃O���b�h�Z���ݒ菈��
            this.SettingGrid();

            this.CacheUOEGuideName_01531();

        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        internal void Clear1()
        {
            // DataTable�s�N���A����
            this._orderDataTable.Rows.Clear();

            // ���׃O���b�h�Z���ݒ菈��
            this.SettingGrid();

        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        internal void ClearUltr()
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_Details.ActiveCell == null))
                {
                    if (this.uGrid_Details.Rows.Count > 0)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._orderDataTable.GoodsNoColumn.ColumnName];
                        // �����͉\�Z���ړ�����
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }
        }

        /// <summary>
        /// �[�i�敪����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �[�i�敪�������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        internal void ComBoClear()
        {
            this.CacheUOEGuideName_01531();
        }

        /// <summary>
        /// BO�敪�̃`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BO�敪�̃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        internal bool BoCodeCheck(int businessCode, int systemDivCd)
        {
            // B0�敪�̖�����
            foreach (MazdaOrderProcDataSet.OrderExpansionRow row in this._orderDataTable)
            {
                if (row.InpSelect == true)
                {
                    // �V�X�e���敪���݌Ɉꊇ���A���ʂɂO��ݒ肳�ꂽ���ׂ��폜����
                    if (systemDivCd == 3 && row.AcceptAnOrderCnt == 0)
                    {
                        continue;
                    }

                    // BO�敪�̃`�F�b�N
                    // �����̏ꍇ
                    if ((businessCode == ctTerminalDiv_Order)
                        && !_boCodeTable.ContainsKey(row.BoCode))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        # endregion

        # region �{�^�������ݒ菈��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            //ImageList
            this.uButton_Select.ImageList = this._imageList16;
            this.uButton_Cancell.ImageList = this._imageList16;
            this.uButton_Guide.ImageList = this._imageList16;
            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;

            //Appearance.Image
            this.uButton_Select.Appearance.Image = (int)Size16_Index.SELECT;
            this.uButton_Cancell.Appearance.Image = (int)Size16_Index.DELETE;
            this.uButton_Guide.Appearance.Image = (int)Size16_Index.GUIDE;

            //�I�����ݒ�
            this.uButton_Select.Enabled = false;
            this.uButton_Cancell.Enabled = false;
            this.uButton_Guide.Enabled = false;

            //Appearance.Image
            this._rowSelectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SELECT;
            this._rowCancellButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
        }

        # endregion �{�^�������ݒ菈��

        # region �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// <summary>
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <param name="grid">�ݒ�Ώۂ̃O���b�h</param>
        /// <remarks>
        /// <br>Note       :  �O���b�h�L�[�}�b�s���O�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);
        }
        # endregion

        # region �� �w�b�_�[���̃N���A
        /// <summary>
        /// �w�b�_�[���̃N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w�b�_�[���̃N���A�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void ClearHedaerItem()
        {
            _inpHedDisplay = null;

            this.tEdit_UoeRemark1.Clear();

            this.tEdit_UoeRemark1.Enabled = false; //�t�n�d���}�[�N�P
            this.tComboEditor_BoCode.Enabled = false;
        }
        # endregion

        # region ���׃O���b�h�ݒ菈��
        /// <summary>
        /// ���׃O���b�h�ݒ菈��
        /// </summary>
        /// <param name="businessCode">�Ɩ��敪</param>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        internal void SettingGrid(int businessCode)
        {
            BusinessCode = businessCode;
            SettingGrid();
            // �Ɩ��敪�������̏ꍇ:�I���������ɂȂ�
            if (businessCode == ctTerminalDiv_Order)
            {
                //�I�����ݒ�
                this.uButton_Select.Enabled = false;
                this.uButton_Cancell.Enabled = false;
            }
        }

        /// <summary>
        /// ���׃O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        internal void SettingGrid()
        {
            try
            {
                // �`����ꎞ��~
                this.uGrid_Details.BeginUpdate();

                // ���ʉ��̓`�F�b�N
                if (_countFlg)
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }

                //if (_inqOrdDivCdFlg == 0)
                //{
                //    this.tEdit_UoeRemark1.Enabled = false;
                //    this.tComboEditor_BoCode.Enabled = false;
                //    this.uButton_Guide.Enabled = false;

                //    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._orderDataTable.BoCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                //}
                //else 
                if (_searchNoDateFlg == false)
                {
                    this.tEdit_UoeRemark1.Enabled = true;
                    this.tComboEditor_BoCode.Enabled = true;

                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._orderDataTable.BoCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    this.uGrid_Details_Enter(this.uGrid_Details, new EventArgs()); // uGrid_Details.Focus()����������
                }

                this.tToolbarsManager_Main.Enabled = true;

                // �`�悪�K�v�Ȗ��׌������擾����B
                int cnt = this._orderDataTable.Count;

                // �e�s���Ƃ̐ݒ�
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }

                // �\���p�s�ԍ���������
                this.AdjustRowNo();

                // �Z���A�N�e�B�u���{�^���L�������R���g���[������
                this.ActiveCellButtonEnabledControl(null);

                //�����t�H�[�J�X�ʒu
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);

            }
            finally
            {
                // �`����J�n
                this.uGrid_Details.EndUpdate();
            }
        }
        # endregion

        # region ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// <summary>
        /// ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// </summary>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�E�s�P�ʂł̃Z���ݒ���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �Z�������擾
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                if ((cell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled) &&
                    (cell.Column.CellActivation != Infragistics.Win.UltraWinGrid.Activation.Disabled))
                {
                    if ((cell.Activation == Infragistics.Win.UltraWinGrid.Activation.NoEdit) ||
                            (cell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit))
                    {
                        cell.Appearance.BackColor = READONLY_CELL_COLOR;
                    }
                }
            }

        }
        # endregion

        # region �\���p�s�ԍ���������
        /// <summary>
        /// �\���p�s�ԍ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �\���p�s�ԍ������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void AdjustRowNo()
        {
            int no = 1;
            foreach (MazdaOrderProcDataSet.OrderExpansionRow row in this._orderDataTable)
            {
                if (row != null)
                {
                    row.OrderNo = no;
                    no++;
                }
            }
        }
        # endregion

        # region �w�b�_�[����ʓ���
        /// <summary>
        /// �w�b�_�[����ʓ���
        /// </summary>
        public MazdaInpHedDisplay inpHedDisplay
        {
            get
            {
                return this._inpHedDisplay;
            }
            set
            {
                this._inpHedDisplay = value;
            }
        }
        # endregion

        # region �Z���A�N�e�B�u���{�^���L�������R���g���[������
        /// <summary>
        /// �Z���A�N�e�B�u���{�^���L�������R���g���[������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Z���A�N�e�B�u���{�^���L�������R���g���[���������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void ActiveCellButtonEnabledControl(string colKey)
        {
            //�Ɩ��敪���������
            if (this._mazdaOrderProcAcs.IsDataChanged != false)
            {
                this.uButton_Select.Enabled = true;
                this.uButton_Cancell.Enabled = true;
            }
            else
            {
                this.uButton_Select.Enabled = false;
                this.uButton_Cancell.Enabled = false;
            }

            // �K�C�h�{�^���̗L��������ݒ肷��
            if (colKey != null && _inqOrdDivCdFlg == 1)
            {
                this.uButton_Guide.Enabled = true;
                this.uButton_Guide.Tag = colKey;
            }
            else
            {
                this.uButton_Guide.Enabled = false;
            }

        }
        # endregion

        /// <summary>
        /// UOE�K�C�h���̏��擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̏��擾�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void CacheUOEGuideName_01531()
        {
            //-----------------------------------------------------------
            //UOE�K�C�h���̏����擾
            //-----------------------------------------------------------
            ArrayList rturnUOEGuideName;
            UOEGuideName uOEGuideName = new UOEGuideName();

            uOEGuideName.EnterpriseCode = _enterpriseCode;
            uOEGuideName.SectionCode = _sectionCode;
            uOEGuideName.UOESupplierCd = _supplierCd;

            int status = this._uOEGuideNameAcs.SearchAll(out rturnUOEGuideName, uOEGuideName);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tComboEditor_BoCode.Items.Clear();

                _deliGoodsDivTable.Clear();
                _boCodeTable.Clear();

                bool uoeGuideDivSpaceFlg = false;

                foreach (UOEGuideName guideName in rturnUOEGuideName)
                {
                    if (guideName.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0)
                    {
                        continue;
                    }

                    // �[�i�敪
                    if (2 == guideName.UOEGuideDivCd
                        && _supplierCd == guideName.UOESupplierCd)
                    {
                        _deliGoodsDivTable.Add(guideName.UOEGuideCode, guideName.UOEGuideNm);
                    }

                    // BO�敪
                    if (1 == guideName.UOEGuideDivCd
                        && _supplierCd == guideName.UOESupplierCd
                        && !_boCodeTable.ContainsKey(guideName.UOEGuideCode))
                    {
                        if (string.IsNullOrEmpty(guideName.UOEGuideCode))
                        {
                            uoeGuideDivSpaceFlg = true;
                        }

                        tComboEditor_BoCode.Items.Add(guideName.UOEGuideCode, guideName.UOEGuideNm);
                        _boCodeTable.Add(guideName.UOEGuideCode, guideName.UOEGuideNm);
                    }
                }

                if (!uoeGuideDivSpaceFlg)
                {
                    tComboEditor_BoCode.Items.Add("", "");
                }
            }
        }

        #region ���O���b�h�񏉊��ݒ菈��
        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�������C�A�E�g�ݒ�C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
        }

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�񏉊��ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
        /// <br>              RRedmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
        /// </remarks>
        private void InitialSettingGridCol(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            //�\������
            int currentPosition = 0;

            string codeFormat = "#;";
            string codeFormat_GoodsMakerCd = "0000;";
            string codeFormat_CashRegisterNo = "000;";
            string codeFormat_OnlineNo = "000000000;";
            string numFormat = "##0;";
            string _dateFormat = "yyyy/MM/dd";

            // ���ו�
            //[No.]
            #region [No.]
            //�\������
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Width = 44;
            //�Œ��
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.Fixed = true;
            //�^�C�g������
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.Caption = "No.";
            //���͋���
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            // CellAppearance�ݒ�
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._orderDataTable.OrderNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            //�I��
            #region [�I��]
            //�\������
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Width = 44;
            //�Œ��
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Header.Fixed = true;			// �Œ荀��
            //�^�C�g������
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Header.Caption = "�I��";
            //Style
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].AutoEdit = true;
            //���͋���
            Columns[this._orderDataTable.InpSelectColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            #endregion

            #region [�[��]
            //[�[��]
            //�\������
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Width = 50;
            //�Œ��
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Header.Caption = "�[��";
            //���͋���
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // �t�H�[�}�b�g�ݒ�
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].Format = codeFormat_CashRegisterNo;
            // MaxLength�ݒ�
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].MaxLength = 3;
            //CellAppearance
            Columns[this._orderDataTable.CashRegisterNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            #region [�ďo�ԍ�]
            //[�ďo�ԍ�] OrderNumber
            //�\������
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Width = 80;
            //�Œ��
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Header.Caption = "�ďo�ԍ�";
            //���͋���
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // �t�H�[�}�b�g�ݒ�
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].Format = codeFormat_OnlineNo;
            // MaxLength�ݒ�
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].MaxLength = 20;
            //CellAppearance
            Columns[this._orderDataTable.OnlineNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //���͓�
            #region [���͓�]
            //[������] OrderDataCreateDate
            //�\������
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Width = 90;
            //�Œ��
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Header.Caption = "���͓�";
            //���͋���
            Columns[this._orderDataTable.InputDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            Columns[this._orderDataTable.InputDayColumn.ColumnName].Format = _dateFormat;
            //CellAppearance
            Columns[this._orderDataTable.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
            //�q�ɖ�
            #region [�q��]
            //[�q�ɖ�] WareHouseName
            //�\������
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Width = 100;
            //�Œ��
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Header.Caption = "�q��";
            //���͋���
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.WarehouseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            #endregion
            //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<

            //���Ӑ�
            #region [���Ӑ於]
            //[���Ӑ於] SalesCustomerSnm
            //�\������
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            //Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Width = 130;// DEL wangyl 2013/02/06 Redmine#34578
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Width = 60;// ADD wangyl 2013/02/06 Redmine#34578
            //�Œ��
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Header.Caption = "���Ӑ�";
            //���͋���
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.CustomerSnmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            #endregion

            //�i��
            #region [�i��]
            //�\������
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            //Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Width = 160;// DEL wangyl 2013/02/06 Redmine#34578
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Width = 130;// ADD wangyl 2013/02/06 Redmine#34578
            //�Œ��
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
            //���͋���
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // �t�H�[�}�b�g�ݒ�
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Format = codeFormat;
            // MaxLength�ݒ�
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].MaxLength = 40;
            //CellAppearance
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._orderDataTable.GoodsNoColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
            #endregion

            //���[�J�[
            #region [���[�J�[]
            //�\������
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Width = 60;
            //�Œ��
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Header.Caption = "Ұ��";
            //���͋���
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // �t�H�[�}�b�g�ݒ�
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].Format = codeFormat_GoodsMakerCd;
            // MaxLength�ݒ�
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].MaxLength = 4;
            //CellAppearance
            Columns[this._orderDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //�i��
            #region [�i��]
            //�\������
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Width = 170;
            //�Œ��
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
            //���͋���
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // MaxLength�ݒ�
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].MaxLength = 100;
            // CellAppearance�ݒ�
            Columns[this._orderDataTable.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            #endregion

            //����
            #region [����]
            //[����] InpAcceptAnOrderCnt
            //�\������
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Width = 50;
            //�Œ��
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Header.Caption = "����";
            //���͋���
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Style
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            // �t�H�[�}�b�g�ݒ�
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].Format = numFormat;
            // MaxLength�ݒ�
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].MaxLength = 3;
            //CellAppearance
            Columns[this._orderDataTable.AcceptAnOrderCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            #endregion

            //BO�敪
            #region [BO�敪]
            //[����] BoCodeColumn
            //�\������
            Columns[this._orderDataTable.BoCodeColumn.ColumnName].Header.VisiblePosition = currentPosition++;
            //�\����
            Columns[this._orderDataTable.BoCodeColumn.ColumnName].Width = 70;
            //�Œ��
            Columns[this._orderDataTable.BoCodeColumn.ColumnName].Header.Fixed = false;
            //�^�C�g������
            Columns[this._orderDataTable.BoCodeColumn.ColumnName].Header.Caption = "BO�敪";
            //���͋���
            Columns[this._orderDataTable.BoCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Style
            Columns[this._orderDataTable.BoCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // MaxLength�ݒ�
            Columns[this._orderDataTable.BoCodeColumn.ColumnName].MaxLength = 1;
            //CellAppearance
            Columns[this._orderDataTable.BoCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            #endregion

            //--------------------------------------
            // ��\��
            //--------------------------------------
            Columns[this._orderDataTable.BoCodeColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.UoeRemark1Column.ColumnName].Hidden = true;
            Columns[this._orderDataTable.EmployeeCodeColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.EmployeeNameColumn.ColumnName].Hidden = true;

            Columns[this._orderDataTable.OnlineRowNoColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.UOEKindColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.CommonSeqNoColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.SupplierFormalColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.StockSlipDtlNumColumn.ColumnName].Hidden = true;

            Columns[this._orderDataTable.UOEDeliGoodsDivColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.UOEResvdSectionColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.FollowDeliGoodsDivColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.UOEDeliGoodsDivNmColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.FollowDeliGoodsDivNmColumn.ColumnName].Hidden = true;
            Columns[this._orderDataTable.UOEResvdSectionNmColumn.ColumnName].Hidden = true;
        }

        #endregion

        #region ���S�I���{�^���N���b�N�C�x���g
        /// <summary>
        /// �S�I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �S�I���{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uButton_Select_Click(object sender, EventArgs e)
        {
            this._orderDataTable.AcceptChanges();

            // �t�B���^�[���O�s���擾      
            Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
                this.uGrid_Details.Rows.GetFilteredInNonGroupByRows();

            // �\���s�͑��݂��邩�H
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
            {
                int uniqueID = (int)_row.Cells[_orderDataTable.OrderNoColumn.ColumnName].Value;
                this._mazdaOrderProcAcs.SelectedRow(uniqueID, true);
            }
        }

        # endregion

        #region ���S�����{�^���N���b�N�C�x���g
        /// <summary>
        /// �S�����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �S�����{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uButton_Cancell_Click(object sender, EventArgs e)
        {
            this._orderDataTable.AcceptChanges();

            Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
                this.uGrid_Details.Rows.GetFilteredInNonGroupByRows();

            // �\���s�͑��݂��邩�H
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
            {
                int uniqueID = (int)_row.Cells[_orderDataTable.OrderNoColumn.ColumnName].Value;
                this._mazdaOrderProcAcs.SelectedRow(uniqueID, false);
            }
        }

        #endregion

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�N�e�B�u�㔭���C�x���g���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            //�w�b�_�[���̃f�[�^�ݒ�
            Int32 onlineNo = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.OnlineNoColumn.ColumnName].Value);
            SettingHedaerItem(onlineNo);

            // �Z���A�N�e�B�u���{�^���L�������R���g���[������
            if (BusinessCode != ctTerminalDiv_Order)
            {
                this.ActiveCellButtonEnabledControl(null);
            }

            //�a�n�敪
            if (cell.Column.Key == this._orderDataTable.BoCodeColumn.ColumnName && _inqOrdDivCdFlg == 1)
            {
                this.uButton_Guide.Enabled = true;
                this.uButton_Guide.Tag = cell.Column.Key;
            }
            else
            {
                this.uButton_Guide.Enabled = false;
            }
        }

        # region �� �w�b�_�[���̃f�[�^�ݒ�
        /// <summary>
        /// �� �w�b�_�[���̃f�[�^�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w�b�_�[���̃f�[�^�ݒ���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void SettingHedaerItem(Int32 onlineNo)
        {
            //���ݕҏW���̃w�b�_�[���Ɠ���̏ꍇ�͉������Ȃ�
            if ((_inpHedDisplay != null)
            && (onlineNo == _inpHedDisplay.OnlineNo)) return;

            if (this.uGrid_Details.ActiveRow != null)
            {
                _inpHedDisplay = new MazdaInpHedDisplay();
                // ���}�[�N1
                _inpHedDisplay.UoeRemark1 = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UoeRemark1Column.ColumnName].Value);
                // ���}�[�N1
                tEdit_UoeRemark1.Text = (string)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.UoeRemark1Column.ColumnName].Value);

                tComboEditor_BoCode.Value = (this.uGrid_Details.ActiveRow.Cells[_orderDataTable.BoCodeColumn.ColumnName].Value.ToString().Trim());
                _inpHedDisplay.UOEDeliGoodsDiv = (this.uGrid_Details.ActiveRow.Cells[_orderDataTable.BoCodeColumn.ColumnName].Value.ToString().Trim());

                _inpHedDisplay.OnlineNo = (int)(this.uGrid_Details.ActiveRow.Cells[_orderDataTable.OnlineNoColumn.ColumnName].Value);
            }


            // BO�敪
            this.tEdit_UoeRemark1.Enabled = true;                   //�t�n�d���}�[�N�P
            this.tComboEditor_BoCode.Enabled = true;
        }
        #endregion

        #region ���O���b�h���C�x���g�i�O���b�h�i���E�E�o�֘A�j
        /// <summary>
        /// �O���b�h�G���^�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�G���^�[�C�x���g���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_Details.ActiveCell == null))
                {
                    if (this.uGrid_Details.Rows.Count > 0)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._orderDataTable.GoodsNoColumn.ColumnName];
                        // �����͉\�Z���ړ�����
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                }
                else if ((!this.uGrid_Details.ActiveCell.IsInEditMode) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // �����͉\�Z���ړ�����
                    this.MoveNextAllowEditCell(true);
                }
            }

            // �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
            uGrid_Details_AfterCellActivate(sender, e);
        }
        #endregion

        # region Return�L�[�_�E������
        /// <summary>
        /// Return�L�[�_�E������
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : Return�L�[�_�E���������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            bool canMove = true;

            canMove = this.MoveNextAllowEditCell(false);

            return canMove;
        }

        #endregion Return�L�[�_�E������

        # region �����͉\�Z���ړ�����
        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // �X�V�J�n�i�`��X�g�b�v�j
                this.uGrid_Details.BeginUpdate();

                if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (this.uButton_Select.Enabled)
                    {
                        this.uButton_Select.Focus();
                    }
                    else
                    {
                        this.tEdit_UoeRemark1.Focus();
                    }
                    this.uButton_Guide.Enabled = false;
                }
            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }
        # endregion

        /// <summary>
        /// �O���b�h�s�A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�s�A�N�e�B�u�㔭���C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = false;
        }

        /// <summary>
        /// �i�C�x���g�j���}�[�N�P�d��������
        /// </summary>
        /// <param name="sender">�I�u�W�F�N�g</param>
        /// <param name="e">�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���}�[�N�P�d���������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tEdit_UoeRemark1_Enter(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = false;
        }

        /// <summary>
        /// �i�C�x���g�j�S�I���d��������
        /// </summary>
        /// <param name="sender">�I�u�W�F�N�g</param>
        /// <param name="e">�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �S�I���d���������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uButton_Select_Enter(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = false;
        }

        /// <summary>
        /// �i�C�x���g�j�S�����d��������
        /// </summary>
        /// <param name="sender">�I�u�W�F�N�g</param>
        /// <param name="e">�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �S�����d���������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uButton_Cancell_Enter(object sender, EventArgs e)
        {
            this.uButton_Guide.Enabled = false;
        }

        # region ActiveRow�C���f�b�N�X�擾����
        /// <summary>
        /// ActiveRow�C���f�b�N�X�擾����
        /// </summary>
        /// <returns>ActiveRow�C���f�b�N�X</returns>
        /// <remarks>
        /// <br>Note       : ActiveRow�C���f�b�N�X�擾�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                return this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                return this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }
        # endregion

        /// <summary>
        /// �i�C�x���g�j���}�[�N�P�k��������
        /// </summary>
        /// <param name="sender">�I�u�W�F�N�g</param>
        /// <param name="e">�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���}�[�N�P�k���������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void tEdit_UoeRemark1_Leave(object sender, EventArgs e)
        {
            if (inpHedDisplay == null) return;
            _inpHedDisplay.UoeRemark1 = tEdit_UoeRemark1.Text;

            if (tComboEditor_BoCode.SelectedItem != null)
            {
                _inpHedDisplay.UOEDeliGoodsDiv = tComboEditor_BoCode.SelectedItem.DataValue.ToString();
                //_inpHedDisplay.DeliveredGoodsDivNm = tComboEditor_BoCode.SelectedItem.DisplayText.ToString().Trim();
            }

            this._mazdaOrderProcAcs.UpdtHedaerItem(_inpHedDisplay);
        }

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�b�v�f�[�g��C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            int OrderNo = this._orderDataTable[cell.Row.Index].OrderNo;
            int rowIndex = e.Cell.Row.Index;

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

            //-----------------------------------------------------------
            // ����
            //-----------------------------------------------------------
            if (cell.Column.Key == this._orderDataTable.AcceptAnOrderCntColumn.ColumnName)
            {
                # region ����
                double columnData = (double)cell.Value;	//���͒l

                //���̓G���[��
                if (columnData < 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���ʂ̓��͒l���}�C�i�X�ł��B",
                        -1,
                        MessageBoxButtons.OK);

                    // �����������ɖ߂�
                    this._orderDataTable[rowIndex].AcceptAnOrderCnt = this._beforeAcceptAnOrderCnt;
                }
                else
                {
                    this._orderDataTable[rowIndex].AcceptAnOrderCnt = columnData;
                }
                # endregion
            }

            if (cell.Column.Key == this._orderDataTable.BoCodeColumn.ColumnName)
            {
                # region �a�n�敪
                string boCode = (string)this._orderDataTable[rowIndex].BoCode;

                if (!string.IsNullOrEmpty(boCode))
                {
                    if (_boCodeTable.ContainsKey(boCode))
                    {
                        //�a�n�敪
                        this._orderDataTable[rowIndex].BoCode = (string)cell.Value;
                    }
                    //���̓G���[
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "UOE�K�C�h���̃}�X�^�ɑ��݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);

                        // �a�n�敪�����ɖ߂�
                        this._orderDataTable[rowIndex].BoCode = this._beforeBoCode;

                    }
                }
                # endregion
            }

        }

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�b�v�f�[�g��C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            this._orderDataTable.AcceptChanges();
            if (e.Cell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            int OnlineNo = this._orderDataTable[cell.Row.Index].OnlineNo;
            int rowIndex = e.Cell.Row.Index;
            bool check;

            if (BusinessCode == ctTerminalDiv_Order)
            {
                string checkString = this.uGrid_Details.Rows[cell.Row.Index].Cells[_orderDataTable.InpSelectColumn.ColumnName].Text;
                if ("True".Equals(checkString))
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
                //-----------------------------------------------------------
                // �I��
                //-----------------------------------------------------------
                if (cell.Column.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        int uniqueOnlineNo = (int)row.Cells[_orderDataTable.OnlineNoColumn.ColumnName].Value;
                        int uniqueID = (int)row.Cells[_orderDataTable.OrderNoColumn.ColumnName].Value;

                        if (OnlineNo == uniqueOnlineNo)
                        {
                            this._mazdaOrderProcAcs.SelectedRow(uniqueID, check);
                        }
                        else
                        {
                            this._mazdaOrderProcAcs.SelectedRow(uniqueID, false);
                        }
                    }

                }
            }
            else
            {
                string checkStringDel = this.uGrid_Details.Rows[cell.Row.Index].Cells[_orderDataTable.InpSelectColumn.ColumnName].Text;
                if ("True".Equals(checkStringDel))
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
                //-----------------------------------------------------------
                // �I��
                //-----------------------------------------------------------
                if (cell.Column.Key == this._orderDataTable.InpSelectColumn.ColumnName)
                {
                    this._mazdaOrderProcAcs.SelectedRow(this._orderDataTable[cell.Row.Index].OrderNo, check);
                }
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int colIndex = uGrid.ActiveCell.Column.Index;
            string colKey = uGrid.ActiveCell.Column.Key;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            //
                        }
                        else
                        {
                            e.Handled = true;
                            uGrid.Rows[rowIndex - 1].Cells[colIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex != uGrid.Rows.Count - 1)
                        {
                            uGrid.Rows[rowIndex + 1].Cells[colIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�b�v�f�[�g�O�C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            //ActiveCell���u���ʁv�̏ꍇ
            if (cell.Column.Key == this._orderDataTable.AcceptAnOrderCntColumn.ColumnName)
            {
                if ((e.Cell.Value != null) && (e.Cell.Value != DBNull.Value) && (e.Cell.Value.ToString() != ""))
                {
                    _beforeAcceptAnOrderCnt = (double)e.Cell.Value;

                    if (_beforeAcceptAnOrderCnt < 0)
                    {
                        _beforeAcceptAnOrderCnt = _beforeAcceptAnOrderCnt * -1;
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    _beforeAcceptAnOrderCnt = 0;
                }
            }

            if (cell.Column.Key == this._orderDataTable.BoCodeColumn.ColumnName)
            {
                if (e.Cell.Value != null)
                {
                    this._beforeBoCode = e.Cell.Value.ToString();
                }
                else
                {
                    this._beforeBoCode = "";
                }
            }
        }

        /// <summary>
        /// �Z���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // �ʏ����
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
            }
        }

        /// <summary>
        /// �O���b�h�L�[�v���X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // ActiveCell�����ʂ̏ꍇInpAcceptAnOrderCntColumn
            if (cell.Column.Key == this._orderDataTable.AcceptAnOrderCntColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        # region ���l���̓`�F�b�N����
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
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
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
        # endregion

        /// <summary>
        /// �K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���N���b�N�C�x���g�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void uButton_Guide_Click(object sender, EventArgs e)
        {
            int status = -1;

            Control control = null;

            this.uButton_Guide.Focus();

            this._orderDataTable.AcceptChanges();

            // ActiveRow�C���f�b�N�X�擾����
            int rowIndex = this.GetActiveRowIndex();

            if (this.uButton_Guide.Tag == null) return;

            //-----------------------------------------------------------------------------------
            //�a�n�敪�K�C�h
            //-----------------------------------------------------------------------------------
            # region �a�n�敪�K�C�h
            if (this.uButton_Guide.Tag.ToString() == this._orderDataTable.BoCodeColumn.ColumnName)
            {
                if (rowIndex == -1) return;

                UOEGuideName uoeGuideName = null;
                UOEGuideName inUOEGuideName = new UOEGuideName();
                inUOEGuideName.UOEGuideDivCd = 1;
                inUOEGuideName.EnterpriseCode = _enterpriseCode;
                inUOEGuideName.SectionCode = _sectionCode;
                inUOEGuideName.UOESupplierCd = _supplierCd;

                UOEGuideNameAcs _uOEGuideNameAcs = new UOEGuideNameAcs();                       // UOE�K�C�h���̃}�X�^ �A�N�Z�X�N���X

                status = _uOEGuideNameAcs.ExecuteGuid(inUOEGuideName, out uoeGuideName);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uoeGuideName != null))
                {
                    //�a�n�敪
                    this._orderDataTable[rowIndex].BoCode = uoeGuideName.UOEGuideCode;

                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._orderDataTable.BoCodeColumn.ColumnName];
                }

                control = this.uGrid_Details;
            }
            # endregion

            //-----------------------------------------------------------------------------------
            // �t�H�[�J�X�ړ�
            //-----------------------------------------------------------------------------------
            if (control != null)
            {
                control.Focus();
            }
        }
        # endregion
    }

}
