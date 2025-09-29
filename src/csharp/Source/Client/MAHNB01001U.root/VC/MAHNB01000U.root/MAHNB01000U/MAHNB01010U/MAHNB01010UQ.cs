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
    /// �`�[�ԍ��I���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �`�[�ԍ��I���̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2011/02/14</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2011/02/14 20056 ���n ��� �V�K�쐬</br>
    /// <br>Update Note: 2013/07/23 �O�� �L��</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             SCM��Q��10554�Ή��i���������j</br>
    /// </remarks>
    public partial class MAHNB01010UQ : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;
        private ScmDataSet.SalesSlipNumDataTable _salesSlipNumDataTable;
        private DataView _salesSlipNumView = null;
        private DialogResult _dialogRes = DialogResult.Cancel;

        private String _salesSlipNum;
        private ArrayList _salesSlipNumList;
        private Int64 _inqueryNumber;

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�`�[�ԍ�</summary>
        public string SalesSlipNum
        {
            get { return this._salesSlipNum; }
        }

        /// <summary>�`�[�ԍ����X�g</summary>
        public ArrayList SalesSlipNumList
        {
            get { return this._salesSlipNumList; }
            set { this._salesSlipNumList = value; }
        }

        /// <summary>�⍇���ԍ�</summary>
        public Int64 InqueryNumber
        {
            get { return this._inqueryNumber; }
            set { this._inqueryNumber = value; }
        }
        # endregion

        // ===================================================================================== //
        // �O���ɒ񋟂���萔�Q
        // ===================================================================================== //
        # region Public Readonly Members
        /// <summary>�ǉ��s���e����</summary>
        public static readonly string ctAddPositionName = "�V�K�⍇��";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// MAHNB01010UQ
        /// </summary>
        public MAHNB01010UQ()
        {
            InitializeComponent();

            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._salesSlipNumDataTable = new ScmDataSet.SalesSlipNumDataTable();
        }
        # endregion

        // ===================================================================================== //
        // �e��R���|�[�l���g�C�x���g�����S
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// MAHNB01010UQ_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UQ_Load(object sender, EventArgs e)
        {
            
            //---------------------------------------------------------
            // �����ݒ�^�C�}�[�N��
            //---------------------------------------------------------
            this.Initial_Timer.Enabled = true;

            //---------------------------------------------------------
            // ����`�[�ԍ��f�[�^�e�[�u��
            //---------------------------------------------------------
            int i = 1;
            foreach (string salesSlipNum in this._salesSlipNumList)
            {
                ScmDataSet.SalesSlipNumRow row = (ScmDataSet.SalesSlipNumRow)this._salesSlipNumDataTable.NewRow();
                row.RowNo = i;
                if (salesSlipNum == SalesSlipInputAcs.ctDefaultSalesSlipNum)
                {
                    row.SalesSlipNum = ctAddPositionName;
                }
                else
                {
                    row.SalesSlipNum = salesSlipNum;
                }
                this._salesSlipNumDataTable.AddSalesSlipNumRow(row);
                i++;
            }

            //---------------------------------------------------------
            // �⍇���ԍ�
            //---------------------------------------------------------
            this.tNedit_InqueryNumber.SetValue(this._inqueryNumber);

            //---------------------------------------------------------
            // �O���b�h���ݒ�
            //---------------------------------------------------------
            this._salesSlipNumView = this._salesSlipNumDataTable.DefaultView;
            this.uGrid_SalesSlipNum.DataSource = this._salesSlipNumView;

            //---------------------------------------------------------
            // �A�C�R���ݒ�
            //---------------------------------------------------------
            Bitmap icon = new Bitmap(32, 32);
            Graphics graphics = Graphics.FromImage(icon);
            try
            {
                graphics.DrawIcon(SystemIcons.Information, 0, 0);
            }
            finally
            {
                if (graphics != null) graphics.Dispose();
            }
            pictureBox1.Image = icon;
        }

        /// <summary>
        /// tArrowKeyControl1_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // ���ו�
                //---------------------------------------------------------------
                case "uGrid_SalesSlipNum":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // �A�N�e�B�u�s�I���^�C�}�[�N��
                                    this.timer_SelectRow.Enabled = true;
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Initial_Timer_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �����ݒ�^�C�}�[����
            this.Initial_Timer.Enabled = false;

            // �����t�H�[�J�X�ʒu�w��
            this.uGrid_SalesSlipNum.Focus();
            this.uGrid_SalesSlipNum.Rows[0].Selected = true;
        }

        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>ESC�ŉ�ʏI�����s���Ƃ��Ɏg�p</remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // �{�^���͉B��Ă܂�
            this.SetDialogRes(DialogResult.Cancel);
            this.CloseForm();
        }

        /// <summary>
        /// ultraGrid1_InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_SalesSlipNum.DisplayLayout.Bands[0].Columns;

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
            this.uGrid_SalesSlipNum.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_SalesSlipNum.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_SalesSlipNum.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_SalesSlipNum.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_SalesSlipNum.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_SalesSlipNum.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // ��
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2013/07/23 �O�� 2013/08/07�z�M�� SCM��Q��10554 --------->>>>>>>>>>>>>>>>>>>>>>>>
            Columns[this._salesSlipNumDataTable.RowNoColumn.ColumnName].Header.Caption = "��";
            // --- ADD 2013/07/23 �O�� 2013/08/07�z�M�� SCM��Q��10554 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // �`�[�ԍ�
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Hidden = false;
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Width = 150;
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // --- ADD 2013/07/23 �O�� 2013/08/07�z�M�� SCM��Q��10554 --------->>>>>>>>>>>>>>>>>>>>>>>>
            Columns[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
            // --- ADD 2013/07/23 �O�� 2013/08/07�z�M�� SCM��Q��10554 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // �󒍃X�e�[�^�X
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].Hidden = true;
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].Width = 150;
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._salesSlipNumDataTable.AcptAnOdrStatusColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // �I��
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].Hidden = true;
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].Width = 150;
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._salesSlipNumDataTable.CheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            
            // �Œ���؂���ݒ�
            this.uGrid_SalesSlipNum.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_SalesSlipNum.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// uGrid_SelectBLGoodsDr_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_SalesSlipNum_DoubleClick(object sender, EventArgs e)
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

            if (objRow == null) return;

            // �`�[�ԍ��ݒ�
            this.SetSalesSlipNum(objRow);
            this.SetDialogRes(DialogResult.OK);
            this.CloseForm();
        }

        /// <summary>
        /// timer_SelectRow_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
            this.timer_SelectRow.Enabled = false;
            if (this.uGrid_SalesSlipNum.ActiveRow != null)
            {
                this.SetSalesSlipNum(this.uGrid_SalesSlipNum.ActiveRow);
                this.SetDialogRes(DialogResult.OK);
                this.CloseForm();
            }
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// ��ʏI������
        /// </summary>
        private void CloseForm()
        {
            if (this._dialogRes == DialogResult.Cancel) this._salesSlipNum = string.Empty;
            this.DialogResult = this._dialogRes;
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

        /// <summary>
        /// �`�[�ԍ��ݒ菈��
        /// </summary>
        /// <param name="objRow"></param>
        private void SetSalesSlipNum(Infragistics.Win.UltraWinGrid.UltraGridRow objRow)
        {
            if ((string)objRow.Cells[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Value == ctAddPositionName)
            {
                this._salesSlipNum = SalesSlipInputAcs.ctDefaultSalesSlipNum;
            }
            else
            {
                this._salesSlipNum = (string)objRow.Cells[this._salesSlipNumDataTable.SalesSlipNumColumn.ColumnName].Value;
            }
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region Public Methods
        #endregion

    }
}