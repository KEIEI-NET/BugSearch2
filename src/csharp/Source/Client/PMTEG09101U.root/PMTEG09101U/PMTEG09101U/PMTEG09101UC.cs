using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ������`�I���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����̎�`����I�����s���ׂ̂t�h�N���X�ł��B</br>
    /// <br>Programmer : zhuhh</br>
    /// <br>Date       : 2013/01/10</br>
    /// </remarks>
    public partial class PMTEG09101UC : Form
    {
        #region Constructor
        /// <summary>
        /// ������`�I���t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������`�I���t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        public PMTEG09101UC()
        {
            InitializeComponent();

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
        }
        #endregion

        #region Constant

        #region < �O���b�h��p >
        /// <summary>���o����</summary>
        private const string CT_SELECT_TBL = "SelectTable";

        private const string CT_DraftNo = "DraftNo";
        private const string CT_BankAndBranchCd = "BankAndBranchCd";
        private const string CT_BankAndBranchNm = "BankAndBranchNm";
        private const string CT_DraftDrawingDate = "DraftDrawingDate";
        private const string CT_RcvDraftData = "RcvDraftData";
        private const string CT_PayDraftData = "PayDraftData";
        #endregion

        #region < �c�[���o�[�L�[��� >
        // �c�[���o�[�L�[���    
        private const string CT_TOOLBAR_DECISION_KEY = "Decision_ButtonTool";
        private const string CT_TOOLBAR_BACK_KEY = "Back_ButtonTool";
        #endregion

        #region <enum>
        private enum DraftModeDiv
        {
            rcvDraft = 0,
            payDraft = 1,
        }
        #endregion

        #region Private Members
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        /// <summary>��������`�I��p�f�[�^�e�[�u��</summary>
        private DataTable _selDataTable;

        /// <summary>��������`�I��p�f�[�^�r���[</summary>
        private DataView _selDataView;

        /// <summary>�\���f�[�^���X�g</summary>
        private List<RcvDraftData> _rcvDispDraftDataLst;

        /// <summary>�I���f�[�^���X�g</summary>
        private RcvDraftData _rcvDraftDataLst;

        /// <summary>�\���f�[�^���X�g</summary>
        private List<PayDraftData> _payDispDraftDataLst;

        /// <summary>�I���f�[�^���X�g</summary>
        private PayDraftData _payDraftDataLst;

        /// <summary>Mode</summary>
        private int modeFlag;

        #endregion

        #endregion

        #region Public Methods
        /// <summary>�I���f�[�^���X�g</summary>
        public RcvDraftData RcvDraftDataLst
        {
            get { return this._rcvDraftDataLst; }
            set { }
        }

        /// <summary>�I���f�[�^���X�g</summary>
        public PayDraftData PayDraftDataLst
        {
            get { return this._payDraftDataLst; }
            set { }
        }

        /// <summary>
        /// ������`�I���K�C�h�N��
        /// </summary>
        /// <param name="owner">�I�[�i�[�t�H�[��</param>
        /// <param name="goodsUnitDataLst">��`�A���f�[�^���X�g</param>
        /// <returns>DialogResult</returns>
        public DialogResult SelectGoodsGuideShow(IWin32Window owner, ref List<RcvDraftData> rcvDraftData)
        {
            this.modeFlag = (int)DraftModeDiv.rcvDraft;

            this._rcvDispDraftDataLst = rcvDraftData;

            DialogResult dr = this.ShowDialog();

            return dr;
        }

        /// <summary>
        /// ������`�I���K�C�h�N��
        /// </summary>
        /// <param name="owner">�I�[�i�[�t�H�[��</param>
        /// <param name="goodsUnitDataLst">��`�A���f�[�^���X�g</param>
        /// <returns>DialogResult</returns>
        public DialogResult SelectGoodsGuideShow(IWin32Window owner, ref List<PayDraftData> payDraftData)
        {
            this.modeFlag = (int)DraftModeDiv.payDraft;

            this._payDispDraftDataLst = payDraftData;
            DialogResult dr = this.ShowDialog();

            return dr;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// �c�[���o�[�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void InitializeToolbarsSetting()
        {
            // �C���[�W���X�g�ݒ�
            this.Main_UToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;


            // �m��{�^���̃A�C�R���ݒ�
            ButtonTool decButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_DECISION_KEY] as ButtonTool;
            if (decButton != null)
            {
                decButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            }

            // �߂�{�^���̃A�C�R���ݒ�
            ButtonTool backButton = this.Main_UToolbarsManager.Tools[CT_TOOLBAR_BACK_KEY] as ButtonTool;
            if (backButton != null)
            {
                backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            }
        }

        /// <summary>
        /// �I��p�f�[�^�e�[�u���쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataTable�̐ݒ���s���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void CreatSelectDadaTable()
        {
            // ----------------------------------------

            // DataTable�̍쐬
            this._selDataTable = new DataTable(CT_SELECT_TBL);
            this._selDataView = new DataView();

            // ----------------------------------------
            // DataColumn�̍쐬

            // ��`�i��
            DataColumn colDraftNo = new DataColumn(CT_DraftNo, typeof(string), "", MappingType.Element);
            colDraftNo.Caption = "��`�ԍ�";

            // ��s�^�x�X�R�[�h
            DataColumn colBankAndBranchCd = new DataColumn(CT_BankAndBranchCd, typeof(string), "", MappingType.Element);
            colBankAndBranchCd.Caption = "��s�^�x�X�R�[�h";

            // ��s�^�x�X����
            DataColumn colBankAndBranchNm = new DataColumn(CT_BankAndBranchNm, typeof(string), "", MappingType.Element);
            colBankAndBranchNm.Caption = "��s�^�x�X����";

            // ������
            DataColumn colDraftDrawingDate = new DataColumn(CT_DraftDrawingDate, typeof(string), "", MappingType.Element);
            colDraftDrawingDate.Caption = "�U�o��";

            // ����`�A���f�[�^
            DataColumn colRcvDraftData = new DataColumn(CT_RcvDraftData, typeof(RcvDraftData), "", MappingType.Element);
            colRcvDraftData.Caption = "����`�A���f�[�^�N���X�i�[";

            // �x����`�A���f�[�^
            DataColumn colPayDraftData = new DataColumn(CT_PayDraftData, typeof(PayDraftData), "", MappingType.Element);
            colPayDraftData.Caption = "�x����`�A���f�[�^�N���X�i�[";

            // ----------------------------------------
            // DataTable�̏�����
            this._selDataTable.Columns.AddRange(new DataColumn[] {
				colDraftNo,
                colBankAndBranchCd,
                colBankAndBranchNm,
                colDraftDrawingDate,
                colRcvDraftData,
                colPayDraftData});

            this._selDataView.Table = this._selDataTable;

        }

        /// <summary>
        /// �I��p�O���b�h�J�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I��p�O���b�h�ɕ\������J��������ݒ肵�܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingSelGridColumn()
        {
            // �o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.SELECTGrid.DisplayLayout.Bands[0];
            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = band.Columns;
            band.Override.DefaultRowHeight = 24;

            //---------------------------------------------------------------------
            //�@�e�L�X�g�̕\���ʒu
            //---------------------------------------------------------------------
            columns[CT_DraftNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[CT_DraftNo].Width = 120;

            columns[CT_BankAndBranchCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[CT_BankAndBranchCd].Width = 80;

            columns[CT_BankAndBranchNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[CT_BankAndBranchNm].Width = 120;

            columns[CT_DraftDrawingDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[CT_DraftDrawingDate].Width = 90;

            columns[CT_RcvDraftData].Hidden = true;
            columns[CT_PayDraftData].Hidden = true;
        }

        /// <summary>
        /// �O���b�h�̃Z�b�e�B���O�`�揈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�S�̂̃Z���X�^�C���E�����F��ݒ肷��</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingGridRowEditor()
        {
            int cnt = this.SELECTGrid.Rows.Count;

            // �`����ꎞ��~
            this.SELECTGrid.BeginUpdate();
            try
            {
                this.SELECTGrid.Rows[0].Selected = true;
                for (int i = 0; i < cnt; i++)
                {
                    SettingGridRowEditor(i);
                }
            }
            finally
            {
                // �`����J�n
                this.SELECTGrid.EndUpdate();
            }
        }

        /// <summary>
        /// �\���O���b�h�s�P�ʂł̃Z���`�揈��
        /// </summary>
        /// <param name="row">�w��s</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�S�̂̃Z���X�^�C���E�����F��ݒ肷��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingGridRowEditor(int row)
        {
            // �f�t�H���g�s�̑O�i�F
            this.SELECTGrid.Rows[row].Appearance.ForeColor = Color.Black;
            this.SELECTGrid.Rows[row].Appearance.ForeColorDisabled = Color.Black;
        }

        /// <summary>
        /// �I��p�e�[�u���쐬
        /// </summary>
        /// <param name="rcvDraftDataList">����`�A���f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �I��p�e�[�u�����쐬���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingSelRcvDraftDataDataTable(List<RcvDraftData> rcvDraftDataList)
        {
            foreach (RcvDraftData data in rcvDraftDataList)
            {
                DataRow row = this.SetRcvDraftDataDataRow(data);

                if (row != null)
                    this._selDataTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// �I��p�e�[�u���쐬
        /// </summary>
        /// <param name="rcvDraftDataList">�x����`�A���f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �I��p�e�[�u�����쐬���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SettingSelPayDraftDataDataTable(List<PayDraftData> payDraftDataDataTable)
        {
            foreach (PayDraftData data in payDraftDataDataTable)
            {
                DataRow row = this.SetPayDraftDataDataRow(data);

                if (row != null)
                    this._selDataTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// ����`�A���}�X�^(rcvDraftDataList)�@�ˁ@�I��p�e�[�u��DataRow
        /// </summary>
        /// <param name="rcvDraftDataList">��`�A���}�X�^</param>
        /// <remarks>
        /// <br>Note       : �I��p�e�[�u����DataRow���쐬���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private DataRow SetRcvDraftDataDataRow(RcvDraftData rcvDraftData)
        {
            DataRow row = this._selDataTable.NewRow();

            // ��`�i��
            row[CT_DraftNo] = rcvDraftData.RcvDraftNo;

            // ��s�^�x�X�R�[�h
            row[CT_BankAndBranchCd] = (rcvDraftData.BankAndBranchCd / 1000+"").PadLeft(4,'0') + "�]" + (rcvDraftData.BankAndBranchCd % 1000+"").PadLeft(3,'0');

            // ��s�^�x�X����
            row[CT_BankAndBranchNm] = rcvDraftData.BankAndBranchNm;

            // �U�o��
            row[CT_DraftDrawingDate] = rcvDraftData.DraftDrawingDate.ToString("yyyy�NMM��dd��");

            //����`�A���f�[�^�N���X�i�[
            row[CT_RcvDraftData] = rcvDraftData.Clone();

            return row;
        }

        /// <summary>
        /// �x����`�A���}�X�^(rcvDraftDataList)�@�ˁ@�I��p�e�[�u��DataRow
        /// </summary>
        /// <param name="rcvDraftDataList">��`�A���}�X�^</param>
        /// <remarks>
        /// <br>Note       : �I��p�e�[�u����DataRow���쐬���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private DataRow SetPayDraftDataDataRow(PayDraftData payDraftData)
        {
            DataRow row = this._selDataTable.NewRow();

            // ��`�i��
            row[CT_DraftNo] = payDraftData.PayDraftNo;

            // ��s�^�x�X�R�[�h
            row[CT_BankAndBranchCd] = (payDraftData.BankAndBranchCd / 1000+"").PadLeft(4,'0') + "�]" + (payDraftData.BankAndBranchCd % 1000+"").PadLeft(3,'0');
          
            // ��s�^�x�X����
            row[CT_BankAndBranchNm] = payDraftData.BankAndBranchNm;

            // �U�o��
            row[CT_DraftDrawingDate] = payDraftData.DraftDrawingDate.ToString("yyyy�NMM��dd��");

            //�x����`�A���f�[�^�N���X�i�[
            row[CT_PayDraftData] = payDraftData.Clone();

            return row;
        }

        #endregion

        #region Control Event
        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMTEG09101UC_Load(object sender, EventArgs e)
        {
            try
            {
                // �c�[���o�[�����ݒ� 
                this.InitializeToolbarsSetting();

                // �f�[�^�e�[�u���̍쐬
                this.CreatSelectDadaTable();

                // �f�[�^�\�[�X�ݒ�
                this.SELECTGrid.DataSource = this._selDataView;

                // �f�[�^���X�g����\���p�̃f�[�^�e�[�u���쐬
                if (this.modeFlag == (int)DraftModeDiv.rcvDraft)
                {
                    this.SettingSelRcvDraftDataDataTable(this._rcvDispDraftDataLst);
                }
                else
                {
                    this.SettingSelPayDraftDataDataTable(this._payDispDraftDataLst);
                }

                // �f�[�^�Đݒ�
                this.SELECTGrid.DataBind();

                // �O���b�h�̕`��
                this.SettingGridRowEditor();

            }
            catch (Exception ex)
            {
                // ���b�Z�[�W�\��
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,      // �G���[���x��
                    this.GetType().ToString(),            // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text,                            // �v���O��������
                    "Load",                               // ��������
                    "",                                   // �I�y���[�V����
                    ex.Message,                           // �\�����郁�b�Z�[�W
                    -1,                                   // �X�e�[�^�X�l
                    null,                                 // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,                 // �\������{�^��
                    MessageBoxDefaultButton.Button1);     // �����\���{�^��
            }
            finally
            {
            }
        }

        /// <summary>
        /// �O���b�h���C�A�E�g������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SELECTGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            // �X�N���[���o�[�X�^�C��
            e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Deferred;

            // ��̎����T�C����
            e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            // ��w�b�_�̕\���X�^�C��
            e.Layout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Default;

            // �f�[�^�s�̒ǉ�����
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // �f�[�^�s�̍폜����
            e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            // �f�[�^�s�̍X�V����
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            // ��ړ��̕ύX
            e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // �Œ��w�b�_
            e.Layout.UseFixedHeaders = false;
            // �Z���N���b�N�����s�A�N�V����
            e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            // �s�I�����́A�S�Ă̗�̕����F�͍��Ƃ���(���̋L�q�Ȃ��Ɣ��F�ɂȂ��Č���Ƃ̔ᔻ�����������߁B)
            e.Layout.Override.SelectedRowAppearance.ForeColor = Color.Black;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.ListIndex;

            this.SettingSelGridColumn();
        }



        /// <summary>
        /// 
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void Main_UToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case CT_TOOLBAR_DECISION_KEY:
                    {
                        // �f�[�^�I��                        
                        if (this.SELECTGrid.ActiveRow == null) return;

                        if (modeFlag == (int)DraftModeDiv.rcvDraft)
                        {
                            RcvDraftData rcvDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_RcvDraftData].Value != DBNull.Value) ? (RcvDraftData)this.SELECTGrid.ActiveRow.Cells[CT_RcvDraftData].Value : null;
                            if (rcvDraftData != null)
                            {
                                this._rcvDraftDataLst = rcvDraftData.Clone();

                                this.DialogResult = DialogResult.OK;
                            }
                        }
                        else
                        {
                            PayDraftData payDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value != DBNull.Value) ? (PayDraftData)this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value : null;
                            if (payDraftData != null)
                            {
                                this._payDraftDataLst = payDraftData.Clone();

                                this.DialogResult = DialogResult.OK;
                            }
                        }

                        break;
                    }
                case CT_TOOLBAR_BACK_KEY:
                    {
                        this.DialogResult = DialogResult.Cancel;

                        break;
                    }
            }
        }

        /// <summary>
        /// �O���b�h�����N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �ꗗ�O���b�h���_�u���N���b�N���ꂽ�ۂɔ������܂��B</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// </remarks>
        private void SELECTGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow = targetGrid.ActiveRow;

            if (objRow != null)
            {
                // ���i�A���f�[�^�N���X�i�[
                if (modeFlag == (int)DraftModeDiv.rcvDraft)
                {
                    RcvDraftData rcvDraftData = (objRow.Cells[CT_RcvDraftData].Value != DBNull.Value) ? (RcvDraftData)objRow.Cells[CT_RcvDraftData].Value : null;

                    if (rcvDraftData != null)
                    {

                        this._rcvDraftDataLst = rcvDraftData.Clone();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    PayDraftData payDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value != DBNull.Value) ? (PayDraftData)this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value : null;
                    if (payDraftData != null)
                    {
                        this._payDraftDataLst = payDraftData.Clone();

                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : zhuhh</br>
        /// <br>Date        : 2013/01/10</br>
        /// </remarks>
        private void SELECTGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.SELECTGrid.ActiveRow == null) return;
                if (modeFlag == (int)DraftModeDiv.rcvDraft)
                {
                    RcvDraftData rcvDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_RcvDraftData].Value != DBNull.Value) ? (RcvDraftData)this.SELECTGrid.ActiveRow.Cells[CT_RcvDraftData].Value : null;
                    if (rcvDraftData != null)
                    {
                        this._rcvDraftDataLst = rcvDraftData.Clone();

                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    PayDraftData payDraftData = (this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value != DBNull.Value) ? (PayDraftData)this.SELECTGrid.ActiveRow.Cells[CT_PayDraftData].Value : null;
                    if (payDraftData != null)
                    {
                        this._payDraftDataLst = payDraftData.Clone();

                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
        #endregion
    }
}