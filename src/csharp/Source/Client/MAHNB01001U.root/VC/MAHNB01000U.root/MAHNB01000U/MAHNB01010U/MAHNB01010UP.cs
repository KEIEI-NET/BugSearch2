using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �֘A����`�[�\���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �֘A����`�[�̕\�����s���܂��B</br>
    /// <br>Programmer  : �k���r</br>
    /// <br>Date        : 2010/11/25</br>
    /// <br>UpdateNote  : 2010/11/30 yangmj ��Q���ǑΉ�</br>
    /// <br>UpdateNote  : 2010/12/01 yangmj ��Q���ǑΉ�</br>
    /// </remarks>
    public partial class MAHNB01010UP : Form
    {
        //================================================================================
        //  �R���X�g���N�^
        //================================================================================
        #region Constructor
        /// <summary>
        /// �֘A����`�[�\���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �֘A����`�[�\���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer  : �k���r</br>
        /// <br>Date        : 2010/11/25</br>
        /// </remarks>
        public MAHNB01010UP()
        {
            InitializeComponent();
            _delDetailDataTable = new SalesInputDataSet.DelDetailDataTable();
            _salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
        }
        #endregion

        //================================================================================
        //  ���������o�[
        //================================================================================
        #region Private Members

        private SalesInputDataSet.DelDetailDataTable _delDetailDataTable;
        private SalesInputDataSet.SalesDetailDataTable _salesDetailDataTable;
        private SalesSlipInputAcs _salesSlipInputAcs;
        private List<SalesDetail> _salesDetailListSrc;
        // -----ADD 2010/11/30----->>>>>
        private List<SalesDetail> _salesDetailList; // ���㖾�׃f�[�^�I�u�W�F�N�g���X�g
        private int _type;�@//����s�x�o�d�@0�F�폜�`�[�@1�F�ԕi�@2�F�ԓ`
        // -----ADD 2010/11/30-----<<<<<

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private DataView _delDetailView = null;

        //---UPD 2010/11/30----->>>>>
        //private DialogResult _dialogRes = DialogResult.Cancel;                  // �_�C�A���O���U���g
        private DialogResult _dialogRes = DialogResult.No;                  // �_�C�A���O���U���g
        //---UPD 2010/11/30-----<<<<<

        #endregion

        //================================================================================
        //  �R���g���[���C�x���g
        //================================================================================
        #region Control Event
        #region < Form_Load�C�x���g >
        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote  : 2010/11/30 yangmj ��Q���ǑΉ�</br>
        /// <br>UpdateNote  : 2010/12/01 yangmj ��Q���ǑΉ�</br>
        private void MAHNB01010UP_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();
            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �O���b�h���ݒ�
            this._delDetailView = this._delDetailDataTable.DefaultView;
            this.ultraGrid_DetailControl.DataSource = this._delDetailView;

            // ��ʏ����ݒ菈��
            this.InitializeDisplaySetting();

            this.Btn_No.Focus();
            this.ActiveControl = this.Btn_No;

            //---ADD 2010/11/30----->>>>>
            if (_type == 0)
            {
                this.ultraLabel_Message.Visible = true;
                this.ultraLabel_Message1.Visible = false;
                //---ADD 2010/12/01----->>>>>
                this.ultraLabel_Message.Text = "�֘A����f�[�^�����݂��܂��B" + "\r\n" + "�\�����̓`�[���폜���Ă���낵���ł����H";
                //---ADD 2010/12/01-----<<<<<
            }
            else if (_type == 1)
            {
                this.ultraLabel_Message1.Visible = true;
                this.ultraLabel_Message.Visible = false;
                //---UPD 2010/12/01----->>>>>
                //this.ultraLabel_Message1.Text = "�֘A����f�[�^�����݂��܂��B       �ԕi�������s���Ă���낵���ł����B";
                this.ultraLabel_Message1.Text = "�֘A����f�[�^�����݂��܂��B" + "\r\n" + "�ԕi�������s���Ă���낵���ł����H";
                //---UPD 2010/12/01-----<<<<<
            }
            else if (_type == 2)
            {
                this.ultraLabel_Message1.Visible = true;
                this.ultraLabel_Message.Visible = false;
                //---UPD 2010/12/01----->>>>>
                //this.ultraLabel_Message1.Text = "�֘A����f�[�^�����݂��܂��B       �ԓ`�������s���Ă���낵���ł����B";
                this.ultraLabel_Message1.Text = "�֘A����f�[�^�����݂��܂��B" + "\r\n" + "�ԓ`�������s���Ă���낵���ł����H";
                //---UPD 2010/12/01-----<<<<<
            }
            //---ADD 2010/11/30-----<<<<<
        }
        #endregion

        /// <summary>
        /// �͂��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void Btn_OK_Click(object sender, EventArgs e)
        {
            _dialogRes = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// �������{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <br>UpdateNote  : 2010/11/30 yangmj ��Q���ǑΉ�</br>
        private void Btn_No_Click(object sender, EventArgs e)
        {
            //---UPD 2010/11/30----->>>>>
            //_dialogRes = DialogResult.Cancel;
            _dialogRes = DialogResult.No;
            //---UPD 2010/11/30-----<<<<<
            this.Close();
        }

        /// <summary>
        /// ���o���ʃO���b�h���C�A�E�g������ �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �f�[�^�\�[�X����R���g���[���Ƀf�[�^�����[�h�����Ƃ��ȂǁA
        ///                   �\�����C�A�E�g�������������Ƃ��ɔ������܂��B </br>
        /// <br>Programmer  : �k���r</br>
        /// <br>Date        : 2010/11/25</br>
        /// <br>UpdateNote  : 2010/11/30 yangmj ��Q���ǑΉ�</br>
        /// <br>UpdateNote  : 2010/12/01 yangmj ��Q���ǑΉ�</br>
        /// </remarks>
        private void ultraGrid_DetailControl_InitializeLayout_1(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_DetailControl.DisplayLayout.Bands[0].Columns;

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

            this.ultraGrid_DetailControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
         

            // �s��
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.ultraGrid_DetailControl.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;

            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Hidden = false;
            //---UPD 2010/12/01----->>>>>
            //Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Width = 55;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Width = 25;
            //---UPD 2010/12/01-----<<<<<
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //---UPD 2010/12/01----->>>>>
            //Columns[this._delDetailDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //---UPD 2010/12/01-----<<<<<
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //---ADD 2010/12/01----->>>>>
            Columns[this._delDetailDataTable.RowNoColumn.ColumnName].Header.Caption = "No.";
            //---ADD 2010/12/01-----<<<<<

            //---DEL 2010/11/30----->>>>>
            //// �`�[�ԍ�
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Hidden = false;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Width = 55;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //---DEL 2010/11/30-----<<<<<

            // �`�[���
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Hidden = false;
            //---UPD 2010/12/01----->>>>>
            //Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Width = 55;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Width = 70;
            //---UPD 2010/12/01-----<<<<<
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._delDetailDataTable.SlipTypeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //---ADD 2010/11/30----->>>>>
            // �`�[�ԍ�
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Hidden = false;
            //---UPD 2010/12/01----->>>>>
            //Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Width = 55;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Width = 70;
            //---UPD 2010/12/01-----<<<<<
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._delDetailDataTable.SlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //---ADD 2010/11/30-----<<<<<

            // �Œ���؂���ݒ�
            this.ultraGrid_DetailControl.DisplayLayout.Override.FixedCellSeparatorColor = this.ultraGrid_DetailControl.DisplayLayout.Override.RowAppearance.BorderColor;

        }

        /// <summary>
        /// ChangeFocus �C�x���g(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2010/11/25</br>
        /// <br>UpdateNote  : 2010/11/30 yangmj ��Q���ǑΉ�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                e.NextCtrl = this.Btn_No;
                return;
            } 

            switch (e.PrevCtrl.Name)
            {
                case "Btn_No":
                    {
                        switch (e.Key)
                        {
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.ultraGrid_DetailControl;
                                    this.ultraGrid_DetailControl.ActiveRow = this.ultraGrid_DetailControl.Rows[0];
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                            case Keys.Return:
                                {
                                    // -----UPD 2010/11/30----->>>>>
                                    //_dialogRes = DialogResult.Cancel;
                                    _dialogRes = DialogResult.No;
                                    // -----UPD 2010/11/30-----<<<<<
                                    this.Close();
                                    break;
                                }
                        }
                        break;
                    }
                case "Btn_OK":
                    {
                        switch (e.Key)
                        {
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.ultraGrid_DetailControl;
                                    this.ultraGrid_DetailControl.ActiveRow = this.ultraGrid_DetailControl.Rows[0];
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                            case Keys.Return:
                                {
                                    _dialogRes = DialogResult.Yes;
                                    this.Close();
                                    break;
                                }
                        }
                        break;
                    }
                //---------------------------------------------------------------
                // ���ו�
                //---------------------------------------------------------------
                case "ultraGrid_DetailControl":
                    {
                        int afterRowIndex = this.ultraGrid_DetailControl.ActiveRow.Index;

                        switch (e.Key)
                        {
                            case Keys.Left:
                            case Keys.Right:
                                {
                                    this.ultraGrid_DetailControl.ActiveRow = this.ultraGrid_DetailControl.Rows[afterRowIndex];
                                    break;
                                }
                        }
                        break;
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
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2010/11/25</br>
        /// </remarks>
        private void ultraGrid_DetailControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    {
                        int afterRowIndex = this.ultraGrid_DetailControl.ActiveRow.Index;                       
                        this.ultraGrid_DetailControl.ActiveRow = this.ultraGrid_DetailControl.Rows[afterRowIndex];
                        e.Handled = true;
                        break;
                    }
            }

        }

        #endregion

        //================================================================================
        //  �����֐�
        //================================================================================
        #region Private Methods

        // --------------------------------------------------
        #region < ��ʕ\���ݒ蓙 >
		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : �k���r</br>
		/// <br>Date       : 2010/11/25</br>
        /// <br>UpdateNote : 2010/11/30 yangmj ��Q���ǑΉ�</br>
        /// <br>UpdateNote : 2010/12/01 yangmj ��Q���ǑΉ�</br>
        /// </remarks>
        private void InitializeDisplaySetting()
        {
            int rowNo = 1;
            this._delDetailDataTable.Clear();
            // -----ADD 2010/11/30----->>>>>
            // ���㖾�׃f�[�^�I�u�W�F�N�g���X�g������̏ꍇ�A�ԕi�^�ԓ`���ŁA�ΏۂƂȂ閾�ׂ̌v�㌳���ׂ����݂���ꍇ�ɕ\�����郁�b�Z�[�W�̐ݒ�
            if (_salesDetailList != null)
            {
                foreach (SalesDetail salesDetail in _salesDetailList)
                {
                    SalesInputDataSet.DelDetailRow row = this._delDetailDataTable.NewDelDetailRow();
                    SalesDetail salesDetailSrc = _salesDetailListSrc.Find(
                        delegate(SalesDetail src)
                        {
                            if ((salesDetail.AcptAnOdrStatusSrc == src.AcptAnOdrStatus) &&
                                (salesDetail.SalesSlipDtlNumSrc == src.SalesSlipDtlNum))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                    if ((_salesDetailListSrc == null) || (salesDetailSrc == null)) continue;
                    // -----UPD 2010/12/01----->>>>>
                    //row.RowNo = string.Format("{0}�s��", salesDetail.SalesRowNo);
                    row.RowNo = string.Format("{0}", salesDetail.SalesRowNo);
                    // -----UPD 2010/12/01-----<<<<<
                    row.SlipNo = salesDetailSrc.SalesSlipNum;
                    row.SlipType = this._salesSlipInputAcs.GetAcptAnOdrStatusName(salesDetailSrc.AcptAnOdrStatus) + "�`�[";
                    this._delDetailDataTable.AddDelDetailRow(row);
                }
            }
            // ��ʖ��׃f�[�^������̏ꍇ�A�`�[�폜�ŁA�ΏۂƂȂ閾�ׂ̌v�㌳���ׂ����݂���ꍇ�ɕ\�����郁�b�Z�[�W�̐ݒ�
            // -----ADD 2010/11/30-----<<<<<
            else if (_salesDetailListSrc != null && _salesDetailListSrc.Count > 0)
            {
                foreach (SalesInputDataSet.SalesDetailRow salesDetailRow in _salesDetailDataTable)
                {
                    SalesInputDataSet.DelDetailRow row = this._delDetailDataTable.NewDelDetailRow();

                    SalesDetail salesDetailSrc = _salesDetailListSrc.Find(
                        delegate(SalesDetail src)
                        {
                            if ((salesDetailRow.AcptAnOdrStatusSrc == src.AcptAnOdrStatus) &&
                                (salesDetailRow.SalesSlipDtlNumSrc == src.SalesSlipDtlNum))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                    if ((_salesDetailListSrc == null) || (salesDetailSrc == null)) continue;

                    // -----UPD 2010/12/01----->>>>>
                    //row.RowNo = string.Format("{0}�s��", salesDetailRow.SalesRowNo);
                    row.RowNo = string.Format("{0}", salesDetailRow.SalesRowNo);
                    // -----UPD 2010/12/01-----<<<<<
                    row.SlipNo = salesDetailSrc.SalesSlipNum;
                    row.SlipType = this._salesSlipInputAcs.GetAcptAnOdrStatusName(salesDetailSrc.AcptAnOdrStatus) + "�`�[";
                    this._delDetailDataTable.AddDelDetailRow(row);
                    rowNo++;
                }
            }
        }
        #endregion
        // --------------------------------------------------
        #endregion

        //================================================================================
        //  �O���񋟊֐�
        //================================================================================
        #region Public Methods
        /// <summary>
        /// ���� �|������`�[���́��N��
        /// </summary>
        /// <param name="owner">owner</param>
        /// <param name="salesDetailListSrc">�v�㌳���דǍ�</param>
        /// <param name="type">����s�x�o�d�@0�F�폜�`�[�@1�F�ԕi�@2�F�ԓ`</param>
        /// /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2010/11/25</br>
        /// <br>UpdateNote : 2010/11/30 yangmj ��Q���ǑΉ�</br>
        /// </remarks>
        public DialogResult Show(IWin32Window owner, List<SalesDetail> salesDetailList, List<SalesDetail> salesDetailListSrc, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, int type)
        {
            _salesDetailListSrc = salesDetailListSrc;
            _salesDetailDataTable = salesDetailDataTable;
            //---ADD 2010/11/30----->>>>>
            _type = type;
            _salesDetailList = salesDetailList;
            //---ADD 2010/11/30-----<<<<<

            DialogResult dr = base.ShowDialog(owner);
            // -----UPD 2010/11/30----->>>>>
            //if (_dialogRes != DialogResult.Yes)
            //{
            //    _dialogRes = DialogResult.Cancel;
            //}
            if (dr != DialogResult.Cancel)
            {
                _dialogRes = DialogResult.No;
            }
            // -----UPD 2010/11/30-----<<<<<
            return _dialogRes;
        }
        #endregion

    }
    /// <summary>
    /// �t�b�^���t�H�[�J�X�ړ��ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �t�b�^���̃t�H�[�J�X�ړ����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : �k���r</br>
    /// <br>Date       : 2010/11/25</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class DelDetailConstruction
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private string _rowNo;
        private string _slipNo;
        private string _slipType;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �폜���׃N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �폜���׃N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2010/11/25</br>
        /// </remarks>
        public DelDetailConstruction()
        {
            this._rowNo = string.Empty;
            this._slipNo = string.Empty;
            this._slipType = string.Empty;
        }

        /// <summary>
        /// �폜���׃N���X
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="caption">�L���v�V����</param>
        /// <param name="enterStop">�ړ��L��</param>
        /// <remarks>
        /// <br>Note       : �폜���׃N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2010/11/25</br>
        /// </remarks>
        public DelDetailConstruction(string rowNo, string slipNo, string slipType)
        {
            this._rowNo = rowNo;
            this._slipNo = slipNo;
            this._slipType = slipType;
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�s��</summary>
        public string RowNo
        {
            get { return this._rowNo; }
            set { this._rowNo = value; }
        }
        /// <summary>�`�[�ԍ�</summary>
        public string SlipNo
        {
            get { return this._slipNo; }
            set { this._slipNo = value; }
        }
        /// <summary>�`�[���</summary>
        public string SlipType
        {
            get { return this._slipType; }
            set { this._slipType = value; }
        }
        # endregion
    }
}