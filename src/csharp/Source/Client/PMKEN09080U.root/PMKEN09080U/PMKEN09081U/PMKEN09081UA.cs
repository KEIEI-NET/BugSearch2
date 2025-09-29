//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ��փ}�X�^�V���֘A�\��
// �v���O�����T�v   : ��փ}�X�^�V���֘A�̈ꗗ�\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2008/10/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2008/12/25  �C�����e : �������̑q�ɃR�[�h�������ꍇ�A�\�����Ȃ������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2009/01/19  �C�����e : ��Q�Ή�9135�iGroupBox���폜�j
//                                : ��Q�Ή�10153�i���[�J�[�K�C�h�ʒu�����[�J�[���̂̉E�ɕύX�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �� �� ��  2009/03/12  �C�����e : ��Q�Ή�12308
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2009/03/16  �C�����e : ��Q�Ή�12343
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/22  �C�����e : MANTIS�y13573�z
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �� �� ��  2009/07/16  �C�����e : MANTIS�y13573�z
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �� �� ��  2009/08/04  �C�����e : MANTIS�y13836�z
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��փ}�X�^�V���֘A�\���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��փ}�X�^�V���֘A�̈ꗗ�\�����s���t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.10.27</br>
    /// <br>Update Note: 2008.12.25 30452 ��� �r��</br>
    /// <br>            �E�������̑q�ɃR�[�h�������ꍇ�A�\�����Ȃ������ǉ��B</br>
    /// <br>Update Note: 2009.01.19 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�9135�iGroupBox���폜�j</br>
    /// <br>            �E��Q�Ή�10153�i���[�J�[�K�C�h�ʒu�����[�J�[���̂̉E�ɕύX�j</br>
    /// <br>Update Note: 2009.03.12 30414 �E �K�j</br>
    /// <br>            �E��Q�Ή�12308</br>
    /// <br>Update Note: 2009/03/16 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12343</br>
    /// </remarks>
    public partial class PMKEN09081U : Form
    {
        #region ��private�萔
        // ��֐�^�u��
        private const string TABKEY_DEST = "uTabDest";
        // ��֌��^�u��
        private const string TABKEY_SRC = "uTabSrc";
        #endregion

        #region ��private�ϐ�
        // ��ƃR�[�h
        private string _enterpriseCode;
        // �����_�R�[�h
        private string _sectionCode;

        // ���@�\����̑J�ڂ�
        private bool _isFromOthers = false;
        // ���@�\����n����鏤�i���
        private GoodsUnitData _goodsUnitData;
        // ���@�\����n������֐悩��֌����̏��(0:��֐�A1:��֌�)
        private int _initialSearchDiv;
        // ADD 2009/06/22 ------>>>
        // ���@�\����̑J�ڎ��̏��������I����(true:���������ρAfalse:������)
        private bool _firstSearchFromOthers = false;
        // ADD 2009/06/22 ------<<<
        
        // ���i�K�C�h
        private GoodsAcs _goodsAcs;
        // ���[�J�[�K�C�h
        private MakerAcs _makerAcs;
        // ��փ}�X�^�����A�N�Z�X�N���X
        private PartsSubstUSearchAcs _partsSubstUSearchAcs;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ��֐�f�[�^�e�[�u��
        private DataTable _destDataTable;
        // ��֐�f�[�^�r���[
        private DataView _destDataView;
        // ��֌��f�[�^�e�[�u��
        private DataTable _srcDataTable;
        // ��֌��f�[�^�r���[
        private DataView _srcDataView;

        // �ύX�O�̕i��
        private string _tmpGoodsNo;
        // �ύX�O�̃��[�J�[�R�[�h
        private int _tmpGoodsMakerCode;

        // �����������σt���O(���������̃C�x���g����p)
        private bool _initializeFinish;

        // �����T�C�Y�ݒ�l
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };

        #endregion

        #region ���R���X�g���N�^
        public PMKEN09081U()
        {
            InitializeComponent();

            // ���O�C�����擾
            this.GetLoginInfo();

            // �K�C�h������
            this.GetGuideInstance();
        }
        #endregion

        #region ��public���\�b�h
        /// <summary>
        /// ��փ}�X�^�V���֘A�\����ʋN��
        /// </summary>
        /// <param name="owner">�I�[�i�[�t�H�[��</param>
        /// <param name="data">�Ώۃf�[�^</param>
        /// <param name="initialSearchDiv">0:��֐�A1:��֌�</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowDialog(IWin32Window owner, GoodsUnitData data, int initialSearchDiv)
        {
            if (data == null || string.IsNullOrEmpty(data.GoodsNo) || data.GoodsMakerCd == 0)
            {
                // ���i�f�[�^�̕s��������΃G���[
                return DialogResult.Cancel;
            }

            // ����ʂ���̋N���t���O
            this._isFromOthers = true;
            // ���i���̕ێ�
            this._goodsUnitData = data;
            // �\���Ώۂ̕ێ�
            this._initialSearchDiv = initialSearchDiv;
            // ADD 2009/06/22 ------>>>
            // ���@�\����̑J�ڎ��̏��������I���t���O
            this._firstSearchFromOthers = false;
            // ADD 2009/06/22 ------<<<

            // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (this._isFromOthers)
            {
                // �R���g���[��������
                this.InitializeScreen();

                // ��ʃC���[�W����
                List<string> controlNameList = new List<string>();
                //controlNameList.Add(this.uExGroupBox_ExtractCondition.Name); // DEL 2009/01/19
                this._controlScreenSkin.SetExceptionCtrl(controlNameList);
                this._controlScreenSkin.LoadSkin();
                this._controlScreenSkin.SettingScreenSkin(this);

                // ���@�\����̑J�ڂ̏ꍇ�A�����������s���B
                this.SearchProc();
            }
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //DialogResult dr = base.ShowDialog(owner);

            DialogResult dr = DialogResult.OK;

            //���@�\����̑J�ڂ̏ꍇ�A�\���f�[�^���P�����Ȃ��ꍇ�ɂ͉�ʂ�\�����Ȃ��B
            if (!(this._isFromOthers && _srcDataTable.Rows.Count == 0 && _destDataTable.Rows.Count == 0))
            {

                dr = base.ShowDialog(owner);

            }
            else
            {
                dr = DialogResult.Cancel;
            }
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            return dr;
        }
        #endregion

        #region ��private���\�b�h

        #region �����\���֘A
        /// <summary>
        /// ���O�C�����擾
        /// </summary>
        private void GetLoginInfo()
        {
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �����_�R�[�h
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }

        /// <summary>
        /// �A�N�Z�X�N���X������
        /// </summary>
        private void GetGuideInstance()
        {
            this._goodsAcs = new GoodsAcs();
            this._makerAcs = new MakerAcs();
            this._partsSubstUSearchAcs = new PartsSubstUSearchAcs();
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        private void InitializeScreen()
        {
            // ������������(�C�x���g����)
            this._initializeFinish = false;

            // �c�[���o�[�A�C�R���ݒ�
            tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this.tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.tToolbarsManager1.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this.tToolbarsManager1.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

            // �K�C�h�{�^���A�C�R���ݒ�
            this.SetIconImage(this.uButton_GoodsMakerCdGuide, Size16_Index.STAR1);

            // �q�ɁA�q�ɒI�ԁA�d���I�P�A�d���I�Q�A���݌ɐ��N���A
            this.uLabel_WarehouseCd.Text = string.Empty;
            this.uLabel_WarehouseShelfNo.Text = string.Empty;
            this.uLabel_DuplicationShelfNo1.Text = string.Empty;
            this.uLabel_DuplicationShelfNo2.Text = string.Empty;
            this.uLabel_ShipmentPosCnt.Text = string.Empty;

            // �񕝎����������Ȃ�
            this.AutoFillToGridColumn_CheckEditor.Checked = false;

            // �I���\�ȕ����T�C�Y�ݒ�
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.FontSize_tComboEditor.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }
            // �����T�C�Y�̏����l��11pt (�����l�ݒ莞�A�J�����̎����������s��Ȃ�)
            this.FontSize_tComboEditor.SelectedIndex = 4;
            
            if (this._isFromOthers)
            {
                // ���@�\����Ă΂ꂽ�ꍇ
                // �N���A�{�^���s��
                this.tToolbarsManager1.Tools["ButtonTool_Clear"].SharedProps.Enabled = false;

                // ���͍��ڂ͕s��
                this.tEdit_GoodsNo.Enabled = false;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.uButton_GoodsMakerCdGuide.Enabled = false;

                // �n���ꂽ�����l��ݒ�
                this.tEdit_GoodsNo.DataText = this._goodsUnitData.GoodsNo;
                this.uLabel_GoodsNm.Text = this._goodsUnitData.GoodsName;
                this.tNedit_GoodsMakerCd.SetInt(this._goodsUnitData.GoodsMakerCd);
                this.uLabel_GoodsMakerNm.Text = this._goodsUnitData.MakerName;

                this._tmpGoodsNo = this._goodsUnitData.GoodsNo;
                this._tmpGoodsMakerCode = this._goodsUnitData.GoodsMakerCd;

                // �^�u�̏����\���ݒ�
                if (this._initialSearchDiv == 0) this.uTab_DestSrc.Tabs[TABKEY_DEST].Selected = true;
                else this.uTab_DestSrc.Tabs[TABKEY_SRC].Selected = true;
            }
            else
            {
                // �e�R���g���[���ݒ�l������
                this.tEdit_GoodsNo.Text = string.Empty;
                this.uLabel_GoodsNm.Text = string.Empty;
                this.tNedit_GoodsMakerCd.SetInt(0);
                this.uLabel_GoodsMakerNm.Text = string.Empty;

                this._tmpGoodsNo = string.Empty;
                this._tmpGoodsMakerCode = 0;

                this.uTab_DestSrc.Tabs[TABKEY_DEST].Selected = true;

            }

            // �O���b�h�̏����� 
            this.InitializeDataGrid();

            // ��������������
            this._initializeFinish = true;
        }

        /// <summary>
        /// �K�C�h�{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        /// <summary>
        /// DataGrid�ADataView�ADataTable������
        /// </summary>
        private void InitializeDataGrid()
        {
            // ��֐�
            this._destDataTable = new DataTable(PartsSubstUSearchAcs.TABLE_DESTPARTSSUBST);
            
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_ORDER_TITLE, typeof(Int32));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_MAKERCODE_TITLE, typeof(Int32));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE, typeof(string));
            _destDataTable.Columns.Add(PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE, typeof(double));

            this._destDataView = new DataView(_destDataTable);
            this.uGrid_Dest.DataSource = this._destDataView;

            // ��֌�
            this._srcDataTable = new DataTable(PartsSubstUSearchAcs.TABLE_SRCPARTSSUBST);

            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_MAKERCODE_TITLE, typeof(Int32));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE, typeof(string));
            _srcDataTable.Columns.Add(PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE, typeof(double));
            
            this._srcDataView = new DataView(_srcDataTable);
            this.uGrid_Src.DataSource = this._srcDataView;

            // �O���b�h��̐ݒ�
            this.InitializeGridColumns();
        }

        /// <summary>
        /// �O���b�h��̏�����(�O�ϐݒ�)
        /// </summary>
        /// <param name="Columns"></param>
        private void InitializeGridColumns()
        {
            #region ��֐�Grid
            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.uGrid_Dest.DisplayLayout.Bands[0].Columns;

            // �\���ʒu�����l
            int visiblePosition = 1;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            // �\������ �t�H�[�}�b�g�F���l
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Header.Caption = "�\������";
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_ORDER_TITLE].Header.VisiblePosition = visiblePosition++;

            // ��֐�i�� �t�H�[�}�b�g�F������
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Width = 200;
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Header.Caption = "��֐�i��";
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_CHGDESTGOODSNO_TITLE].Header.VisiblePosition = visiblePosition++;

            // ���[�J�[ �t�H�[�}�b�g�F���l 4��0�l��
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Format = "0000";
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.Caption = "���[�J�[";
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.VisiblePosition = visiblePosition++;

            // �q�� �t�H�[�}�b�g�F������i���l�j4��0�l
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Width = 65;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.Caption = "�q��";
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.VisiblePosition = visiblePosition++;

            // �q�ɒI�� �t�H�[�}�b�g�F������i���l�j
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.Caption = "�q�ɒI��";
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.VisiblePosition = visiblePosition++;

            // �d���I1 �t�H�[�}�b�g�F������i���l�j
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.Caption = "�d���I�P";
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.VisiblePosition = visiblePosition++;

            // �d���I2 �t�H�[�}�b�g�F������i���l�j
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.Caption = "�d���I�Q";
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.VisiblePosition = visiblePosition++;

            // ���݌ɐ� �t�H�[�}�b�g�F���l(ZZZ,ZZ9.99)
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Hidden = false;
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Width = 95;
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Format = "#,##0.00";
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.Caption = "���݌ɐ�";
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.VisiblePosition = visiblePosition++;

            #endregion

            #region ��֌�Grid
            Infragistics.Win.UltraWinGrid.ColumnsCollection columns_src = this.uGrid_Src.DisplayLayout.Bands[0].Columns;

            // �\���ʒu�����l
            visiblePosition = 1;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column_src in columns_src)
            {
                //��\���ݒ�
                column_src.Hidden = true;
                column_src.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                column_src.AutoEdit = false;
                column_src.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            // ��֌��i�� �t�H�[�}�b�g�F������
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Width = 200;
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Header.Caption = "��֌��i��";
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_CHGSRCGOODSNO_TITLE].Header.VisiblePosition = visiblePosition++;

            // ���[�J�[ �t�H�[�}�b�g�F���l 4��0�l��
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Format = "0000";
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.Caption = "���[�J�[";
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_MAKERCODE_TITLE].Header.VisiblePosition = visiblePosition++;

            // �q�� �t�H�[�}�b�g�F������i���l�j4��0�l
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Width = 65;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.Caption = "�q��";
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSECODE_TITLE].Header.VisiblePosition = visiblePosition++;

            // �q�ɒI�� �t�H�[�}�b�g�F������i���l�j
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.Caption = "�q�ɒI��";
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_WAREHOUSESHELF_TITLE].Header.VisiblePosition = visiblePosition++;

            // �d���I1 �t�H�[�}�b�g�F������i���l�j
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.Caption = "�d���I�P";
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF1_TITLE].Header.VisiblePosition = visiblePosition++;

            // �d���I2 �t�H�[�}�b�g�F������i���l�j
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.Caption = "�d���I�Q";
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_DUPLICATIONSHELF2_TITLE].Header.VisiblePosition = visiblePosition++;

            // ���݌ɐ� �t�H�[�}�b�g�F���l(ZZZ,ZZ9.99)
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Hidden = false;
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Width = 95;
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Format = "#,##0.00";
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.Caption = "���݌ɐ�";
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns_src[PartsSubstUSearchAcs.COL_SHIPMENTPOSCNT_TITLE].Header.VisiblePosition = visiblePosition++;

            #endregion
        }

        /// <summary>
        /// �J�����T�C�Y����
        /// </summary>
        private void ColumnPerformAutoResize()
        {
            // ���������������Ă��Ȃ��ꍇ�̓J�������������s��Ȃ�
            if (this._initializeFinish)
            {
                if (!this.AutoFillToGridColumn_CheckEditor.Checked)
                {
                    for (int i = 0; i < this.uGrid_Dest.DisplayLayout.Bands[0].Columns.Count; i++)
                    {
                        this.uGrid_Dest.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
                    }

                    for (int j = 0; j < this.uGrid_Src.DisplayLayout.Bands[0].Columns.Count; j++)
                    {
                        this.uGrid_Src.DisplayLayout.Bands[0].Columns[j].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
                    }
                }
            }
        }

        #endregion

        #region ���i���擾�֘A
        // --- ADD 2009/03/16 -------------------------------->>>>>
        /// <summary>
        /// ���i���擾(���[�J�[��������)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private int GetGoodsInfo(out List<GoodsUnitData> list, out string msg)
        {
            return GetGoodsInfo(out list, true, out msg);
        }
        // --- ADD 2009/03/16 --------------------------------<<<<<

        /// <summary>
        /// ���i���擾
        /// </summary>
        /// <param name="list"></param>
        /// <param name="searchMaker">���[�J�[�����������ɐݒ肷�邩</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        //private int GetGoodsInfo(out List<GoodsUnitData> list, out string msg) // DEL 2009/03/16
        private int GetGoodsInfo(out List<GoodsUnitData> list, bool searchMaker, out string msg) // ADD 2009/03/16
        {
            // �i�Ԍ���
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            list = new List<GoodsUnitData>();

            // �����i��(*��������������)
            string searchCd;

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.SectionCode = this._sectionCode;
            if (searchMaker) // ADD 2009/03/16
            {
                goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                goodsCndtn.MakerName = this.uLabel_GoodsMakerNm.Text;
            }
            goodsCndtn.GoodsNo = this.tEdit_GoodsNo.DataText;
            goodsCndtn.GoodsNoSrchTyp = this.GetSearchType(this.tEdit_GoodsNo.DataText, out searchCd);

            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, true, out list, out msg);

            return status;
        }

        /// <summary>
        /// �i�Ԍ����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v����</returns>
        /// </remarks>
        private int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                // �O����v�̂ݑΉ�
                if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                // *�����݂��Ȃ����ߊ��S��v����
                return 0;
            }
        }

        #endregion

        #region ���������֘A

        /// <summary>
        /// ���������i�G���[�`�F�b�N�ƃ����[�g�ďo���j
        /// </summary>
        private void SearchProc()
        {
            // ���͏����`�F�b�N
            if (!this.SearchBeforeCheck())
            {
                return;
            }

            // �����������s
            this.ExecuteSearch();
        }

        /// <summary>
        /// �����O���̓`�F�b�N����
        /// </summary>
        /// <returns></returns>
        private bool SearchBeforeCheck()
        {
            bool status = true;
            string errMsg = "";
            Control errCtl = null;

            // �K�{���̓`�F�b�N
            // �i��
            if (this.tEdit_GoodsNo.DataText == string.Empty)
            {
                if (this.uTab_DestSrc.SelectedTab.Key == TABKEY_DEST)
                {
                    errMsg = "��֌��i�Ԃ���͂��Ă�������";
                }
                else
                {
                    errMsg = "��֐�i�Ԃ���͂��Ă�������";
                }

                errCtl = this.tEdit_GoodsNo;
                status = false;
            }
            else if (this.tNedit_GoodsMakerCd.GetInt() == 0)
            {
                errMsg = "���[�J�[����͂��Ă�������";
                errCtl = this.tNedit_GoodsMakerCd;
                status = false;
            }

            if (!status)
            {
                // �G���[���b�Z�[�W�\��
                TMsgDisp.Show(
                                this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                errMsg,                                             // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);								// �\������{�^��

                // �G���[�R���g���[���Ƀt�H�[�J�X
                errCtl.Focus();
            }

            return status;
        }

        /// <summary>
        /// �����������s
        /// </summary>
        private void ExecuteSearch()
        {
            int status;

            // �O�񏈗����ʂ̃N���A
            this.ClearLastResult();

            // ��������List�쐬
            ArrayList inParam = new ArrayList();

            // ��ƃR�[�h
            inParam.Add(this._enterpriseCode);
            // �����敪
            if (this.uTab_DestSrc.SelectedTab.Key.ToString() == TABKEY_DEST) inParam.Add(0);
            else inParam.Add(1);
            // ���_�R�[�h
            inParam.Add(this._sectionCode);
            // �ϊ������[�J�[�R�[�h
            inParam.Add(this.tNedit_GoodsMakerCd.GetInt());
            // �ϊ������i�ԍ�
            inParam.Add(this.tEdit_GoodsNo.DataText);

            ArrayList outParam = new ArrayList();

            // �����������s
            if (this.uTab_DestSrc.SelectedTab.Key.ToString() == TABKEY_DEST)
            {
                // ��֐挟��
                status = this._partsSubstUSearchAcs.Search(inParam, ref outParam, ref this._destDataTable);

                // ADD 2009/06/22 ------>>>
                // ���@�\����J�ڎ��A��֐�f�[�^��������Α�֌�������
                if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF ||
                     status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                     this._isFromOthers &&
                     !this._firstSearchFromOthers)
                {
                    // -- 2009/08/04 ------------------------>>>
                    uTab_DestSrc.SelectedTabChanged -= new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(uTab_DestSrc_SelectedTabChanged);
                    // -- 2009/08/04 ------------------------<<<

                    this.uTab_DestSrc.Tabs[TABKEY_SRC].Selected = true;

                    // -- 2009/08/04 ------------------------>>>
                    uTab_DestSrc.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(uTab_DestSrc_SelectedTabChanged);
                    // -- 2009/08/04 ------------------------<<<

                    this._firstSearchFromOthers = true;
                    inParam[1] = 1;
                    // ��֌�����
                    status = this._partsSubstUSearchAcs.Search(inParam, ref outParam, ref this._srcDataTable);
                }
                // ADD 2009/06/22 ------<<<
            }
            else
            {
                // ��֌�����
                status = this._partsSubstUSearchAcs.Search(inParam, ref outParam, ref this._srcDataTable);

                // ADD 2009/06/22 ------>>>
                // ���@�\����J�ڎ��A��֌��f�[�^��������Α�֐������
                if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF ||
                     status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                     this._isFromOthers &&
                     !this._firstSearchFromOthers)
                {
                    this.uTab_DestSrc.Tabs[TABKEY_DEST].Selected = true;
                    this._firstSearchFromOthers = true;
                    inParam[1] = 0;
                    // ��֐挟��
                    status = this._partsSubstUSearchAcs.Search(inParam, ref outParam, ref this._destDataTable);
                }
                // ADD 2009/06/22 ------<<<
            }

            // 2009/08/04 ----------------------------->>>
            //���@�\����J�ڎ��̏��������t���O��True�ɂ���
            if (this._isFromOthers)
            {
                this._firstSearchFromOthers = true;
            }
            // 2009/08/04 -----------------------------<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���������̐ݒ�
                if (!string.IsNullOrEmpty(outParam[0].ToString())) // ADD 2008/12/25
                {
                    this.uLabel_WarehouseCd.Text = outParam[0].ToString();
                    this.uLabel_WarehouseShelfNo.Text = outParam[1].ToString();
                    this.uLabel_DuplicationShelfNo1.Text = outParam[2].ToString();
                    this.uLabel_DuplicationShelfNo2.Text = outParam[3].ToString();
                    this.uLabel_ShipmentPosCnt.Text = ((double)outParam[4]).ToString("#,##0.00");
                }
                else
                {
                    this.uLabel_WarehouseCd.Text = string.Empty;
                    this.uLabel_WarehouseShelfNo.Text = string.Empty;
                    this.uLabel_DuplicationShelfNo1.Text = string.Empty;
                    this.uLabel_DuplicationShelfNo2.Text = string.Empty;
                    this.uLabel_ShipmentPosCnt.Text = string.Empty;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // �Y��0��
                TMsgDisp.Show(
                                this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�����ɍ��v����f�[�^�����݂��܂���", �@�@�@// �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);								// �\������{�^��
                return;
            }
            else
            {
                // �G���[
                TMsgDisp.Show(
                                this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "��փ}�X�^�V���֘A���̎擾�Ɏ��s���܂���",   // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);								// �\������{�^��
                return;
            }
        }

        /// <summary>
        /// �O�񌟍����ʂ̃N���A
        /// </summary>
        private void ClearLastResult()
        {
            // �q�ɁA�q�ɒI�ԁA�d���I�P�A�d���I�Q�A���݌ɐ��N���A
            this.uLabel_WarehouseCd.Text = string.Empty;
            this.uLabel_WarehouseShelfNo.Text = string.Empty;
            this.uLabel_DuplicationShelfNo1.Text = string.Empty;
            this.uLabel_DuplicationShelfNo2.Text = string.Empty;
            this.uLabel_ShipmentPosCnt.Text = string.Empty;

            // �������ʕێ��e�[�u���̍s�N���A
            this._srcDataTable.Rows.Clear();
            this._destDataTable.Rows.Clear();
        }
        #endregion

        #endregion

        #region ���R���g���[���C�x���g

        #region �����\���֘A
        /// <summary>
        /// PMKEN09081U_Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKEN09081U_Load(object sender, EventArgs e)
        {
            // 2007/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>
            if (!this._isFromOthers) 
            {
            // 2007/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<
                // �R���g���[��������
                this.InitializeScreen();

                // ��ʃC���[�W����
                List<string> controlNameList = new List<string>();
                //controlNameList.Add(this.uExGroupBox_ExtractCondition.Name); // DEL 2009/01/19
                this._controlScreenSkin.SetExceptionCtrl(controlNameList);
                this._controlScreenSkin.LoadSkin();
                this._controlScreenSkin.SettingScreenSkin(this);

            } //2007/07/16

            // 2009/07/16 ShowDialog�Ɉړ�>>>>>>>>>>>
            //if (this._isFromOthers)
            //{
            //    // ���@�\����̑J�ڂ̏ꍇ�A�����������s���B
            //    this.SearchProc();
            //}
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// DataGrid_InitializeLayout�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = sender as Infragistics.Win.UltraWinGrid.UltraGrid;
            if (grid == null) return;

            // �X�N���[���o�[�X�^�C��
            e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            e.Layout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

            // ��w�b�_�̕\���X�^�C��
            e.Layout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Default;

            // �Z���̋��E���X�^�C���̐ݒ� 
            e.Layout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Default;

            // �s�̋��E���X�^�C���̐ݒ� 
            e.Layout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Default;

            // �f�[�^�s�̒ǉ�����
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // �f�[�^�s�̍폜����
            e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            // �f�[�^�s�̍X�V����
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            // ��ړ��̕ύX
            e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.Default;

            // �Œ��w�b�_
            e.Layout.UseFixedHeaders = true;

            // �Z���N���b�N�����s�A�N�V����
            e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;

            // �w�b�_�N���b�N�A�N�V�����̐ݒ�
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

            // 1�s�����̊O�ϐݒ�
            e.Layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // �s�Z���N�^�[�̕\����\��
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            // �s�I��ݒ� �s�I�𖳂����[�h(�A�N�e�B�u�̂�)
            e.Layout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            e.Layout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;

            // �s�t�B���^�[�̐ݒ�
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

            // �e�L�X�g�̃����^�����O�ݒ�
            e.Layout.Override.CellAppearance.TextTrimming = Infragistics.Win.TextTrimming.Character;
        }

        /// <summary>
        /// Initial_Timer_Tick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // �����t�H�[�J�X�Z�b�g
            if (!this._isFromOthers)
            {
                this.tEdit_GoodsNo.Focus();
            }
            else
            {
                // ���@�\����̑J�ڎ�
                this.uTab_DestSrc.Focus();
            }
        }
        #endregion

        #region �{�^�������֘A
        /// <summary>
        /// ���[�J�[�K�C�h�����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;

            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {

                if (this._tmpGoodsMakerCode == makerUMnt.GoodsMakerCd)
                {
                    // ���͒l�̕ύX���Ȃ���Ό����͍s��Ȃ�
                    return;
                }

                // ���ʂ���ʂɐݒ�
                this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                this.uLabel_GoodsMakerNm.Text = makerUMnt.MakerName;

                // �ݒ�l��ۑ�
                this._tmpGoodsMakerCode = makerUMnt.GoodsMakerCd;

                // �t�H�[�J�X����
                this.uTab_DestSrc.Focus();
            }
            else
            {
                // �ݒ�l��ۑ�
                this._tmpGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                // ���[�J�[���̂��N���A
                this.uLabel_GoodsMakerNm.Text = string.Empty;
                // �O�񌟍����ʂ̃N���A
                this.ClearLastResult();
            }

            // ���i��������Ɏ擾�o���Ȃ��P�[�X������̂ŏ��i�}�X�^�`�F�b�N
            // (�قȂ郁�[�J�[�ɑ��݂��铯���i��)
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                List<GoodsUnitData> list = new List<GoodsUnitData>();
                string msg;

                // ���i���擾
                status = this.GetGoodsInfo(out list, out msg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    GoodsUnitData goodsUnitData = (GoodsUnitData)list[0];

                    // ���ʂ���ʂɐݒ�
                    this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                    this.uLabel_GoodsNm.Text = goodsUnitData.GoodsName;
                    this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                    this.uLabel_GoodsMakerNm.Text = goodsUnitData.MakerName;

                    // �ݒ�l��ۑ�
                    this._tmpGoodsNo = goodsUnitData.GoodsNo;
                    this._tmpGoodsMakerCode = goodsUnitData.GoodsMakerCd;
                }
            }

            // �i�Ԃ̓��͂�����Ό����������s
            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText))
            {
                // �����������s
                this.SearchProc();
            }
        }

        /// <summary>
        /// tToolbarsManager1_ToolClick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I���{�^��
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                // �����{�^��
                case "ButtonTool_Search":
                    {
                        // ��������
                        this.SearchProc();

                        break;
                    }
                // ����{�^��
                case "ButtonTool_Clear":
                    {
                        // ��ʂ̏�����
                        this.InitializeScreen();

                        this.Initial_Timer.Enabled = true;

                        break;
                    }
            }
        }
        #endregion

        #region �t�H�[�J�X�J�ڊ֘A
        /// <summary>
        /// ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            // ��������
            int status;

            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // �i��
                case "tEdit_GoodsNo":
                    {
                        if (this.tEdit_GoodsNo.DataText == string.Empty)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpGoodsNo = "";
                            this.uLabel_GoodsNm.Text = string.Empty;

                            break;
                        }

                        if (this.tEdit_GoodsNo.DataText == this._tmpGoodsNo)
                        {
                            // ���͂��ς���Ă��Ȃ���Ή������Ȃ�
                            break;
                        }

                        List<GoodsUnitData> list = new List<GoodsUnitData>();
                        string msg;

                        // ���i���擾
                        //status = this.GetGoodsInfo(out list, out msg); // DEL 2009/03/16
                        status = this.GetGoodsInfo(out list, false, out msg); // ADD 2009/03/16

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            GoodsUnitData goodsUnitData = (GoodsUnitData)list[0];

                            // ���ʂ���ʂɐݒ�
                            this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                            this.uLabel_GoodsNm.Text = goodsUnitData.GoodsName;
                            this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                            this.uLabel_GoodsMakerNm.Text = goodsUnitData.MakerName;

                            // �ݒ�l��ۑ�
                            this._tmpGoodsNo = goodsUnitData.GoodsNo;
                            this._tmpGoodsMakerCode = goodsUnitData.GoodsMakerCd;
                        }
                        else
                        {
                            // �ݒ�l��ۑ�
                            this._tmpGoodsNo = this.tEdit_GoodsNo.DataText;
                            // �i�Ԗ��̂��N���A
                            this.uLabel_GoodsNm.Text = "";
                            // �O�񌟍����ʂ̃N���A
                            this.ClearLastResult();
                        }

                        // ���[�J�[�̓��͂�����Ό������s
                        if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                        {
                            // �����������s
                            this.SearchProc();
                        }

                        break;
                    }
                // ���[�J�[�R�[�h
                case "tNedit_GoodsMakerCd":
                    {
                        // ���͖���
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpGoodsMakerCode = 0;
                            this.uLabel_GoodsMakerNm.Text = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_GoodsMakerCd.GetInt() == this._tmpGoodsMakerCode)
                        {
                            if (e.NextCtrl == this.uButton_GoodsMakerCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.uTab_DestSrc;
                            }

                            break;
                        }

                        MakerUMnt makerUMnt;

                        status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            this.uLabel_GoodsMakerNm.Text = makerUMnt.MakerName;

                            // �ݒ�l��ۑ�
                            this._tmpGoodsMakerCode = makerUMnt.GoodsMakerCd;
                        }
                        else
                        {
                            // �ݒ�l��ۑ�
                            this._tmpGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                            // ���[�J�[���̂��N���A
                            this.uLabel_GoodsMakerNm.Text = string.Empty;
                            // �O�񌟍����ʂ̃N���A
                            this.ClearLastResult();
                        }

                        // ���i��������Ɏ擾�o���Ȃ��P�[�X������̂ŏ��i�}�X�^�`�F�b�N
                        // (�قȂ郁�[�J�[�ɑ��݂��铯���i��)
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            List<GoodsUnitData> list = new List<GoodsUnitData>();
                            string msg;

                            // ���i���擾
                            status = this.GetGoodsInfo(out list, out msg);

                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                GoodsUnitData goodsUnitData = (GoodsUnitData)list[0];

                                // ���ʂ���ʂɐݒ�
                                this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                                this.uLabel_GoodsNm.Text = goodsUnitData.GoodsName;
                                this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                                this.uLabel_GoodsMakerNm.Text = goodsUnitData.MakerName;

                                // �ݒ�l��ۑ�
                                this._tmpGoodsNo = goodsUnitData.GoodsNo;
                                this._tmpGoodsMakerCode = goodsUnitData.GoodsMakerCd;
                            }
                        }

                        // �i�Ԃ̓��͂�����Ό����������s
                        if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText))
                        {
                            // �����������s
                            this.SearchProc();
                        }

                        // �t�H�[�J�X����
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_GoodsMakerCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab))
                        {
                            // ���[�J�[�����݂��� ���� �����K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            e.NextCtrl = this.uTab_DestSrc;
                        }

                        break;
                    }
                case "uTab_DestSrc":
                    {
                        // Shift + Tab�ŃK�C�h�ɗ���P�[�X
                        if (e.NextCtrl == this.uButton_GoodsMakerCdGuide
                            && this.tNedit_GoodsMakerCd.GetInt() != 0
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Left))
                        {
                            e.NextCtrl = this.tNedit_GoodsMakerCd;
                        }
                        break;
                    }
            }
        }
        #endregion

        #region �l�ύX�A�I��ύX�֘A
        /// <summary>
        /// uTab_DestSrc_SelectedTabChanged�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTab_DestSrc_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab.Key.ToString() == TABKEY_DEST)
            {
                // �i�ԃ��x�����̕ύX
                this.uLabel_GoodsTitle.Text = "��֌��i��";
            }
            else if (e.Tab.Key.ToString() == TABKEY_SRC)
            {
                // �i�ԃ��x�����̕ύX
                this.uLabel_GoodsTitle.Text = "��֐�i��";
            }

            // ���͍��ڂ���A�����������ς̏ꍇ�����������s
            if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text)
                && this.tNedit_GoodsMakerCd.GetInt() != 0
                && this._initializeFinish)
            {
                // ��������
                this.SearchProc();
            }
        }

        /// <summary>
        /// AutoFillToGridColumn_CheckEditor_CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoFillToGridColumn_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.AutoFillToGridColumn_CheckEditor.Checked)
            {
                // �񕝂��I�[�g�ɐݒ�
                this.uGrid_Dest.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                this.uGrid_Src.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Dest.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                this.uGrid_Dest.Refresh();
                this.uGrid_Src.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                this.uGrid_Src.Refresh();
            }

            // �J�����T�C�Y����
            this.ColumnPerformAutoResize();

        }

        /// <summary>
        /// FontSize_tComboEditor_ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // �O���b�h�̃t�H���g�T�C�Y�ύX
            int fontSize = Convert.ToInt32(this.FontSize_tComboEditor.Value);

            this.uGrid_Dest.DisplayLayout.Appearance.FontData.SizeInPoints = (float)fontSize;
            this.uGrid_Dest.Refresh();
            this.uGrid_Src.DisplayLayout.Appearance.FontData.SizeInPoints = (float)fontSize;
            this.uGrid_Src.Refresh();
            // �J�����T�C�Y����
            this.ColumnPerformAutoResize();

        }

        #endregion

        #endregion

    }
}