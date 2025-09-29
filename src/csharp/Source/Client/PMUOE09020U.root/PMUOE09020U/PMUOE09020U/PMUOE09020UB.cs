//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �O�ԑΉ����[�J�[��ʐݒ�
// �v���O�����T�v   : �O�ԑΉ����[�J�[��ʐݒ���s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/10/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using System.Xml;
using System.Web;
using System.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �O�ԑΉ����[�J�[��ʐݒ�
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O�ԑΉ����[�J�[��ʐݒ�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/10/26</br>
    /// </remarks>
    public partial class PMUOE09020UB : Form
    {
        # region Constructor
        public PMUOE09020UB()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;

            this._makerAcs = new MakerAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }
        # endregion

        # region Private Members
        private bool _canClose;
        private bool bevalueFlag = true;
        private string _beMakerCd = string.Empty;
        private ImageList _imageList16 = null;
        private MakerAcs _makerAcs;                        // ���[�J�[�A�N�Z�X�N���X
        private string _enterpriseCode;                    // ��ƃR�[�h
        private ArrayList preList = new ArrayList();
        private UltraGridCell _preCell;

        /// <summary>�f�[�^�e�[�u��</summary>
        private DataTable _dt;

        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

        private const string MAKER_TABLE = "Maker_table";
        private const string SAVE_XML_NAME = "PMUOE09020U_Maker.xml";

        private const string MAKERNO = "No.";
        private const string MAKERCOL = "EmptyCol";
        private const string MAKERCODE = "MakerCode";
        private const string MAKERGUID = "Guide";
        // �v���O����ID
        private const string ASSEMBLY_ID = "PMUOE09020UB";
        public string _UOECdparameter = null;
        public List<UoeCdparameterList> tempList = new List<UoeCdparameterList>();
        public List<string> list = new List<string>();
        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return _canClose;
            }
            set
            {
                _canClose = value;
            }
        }
        # endregion

        # region Event Methods
        /// <summary>
        /// Form.Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : Form.Load�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void PMUOE09020UB_Load(object sender, EventArgs e)
        {
            this.Ok_Button.ImageList = this._imageList16;
            this.Cancel_Button.ImageList = this._imageList16;

            this.Ok_Button.Appearance.Image = (int)Size16_Index.SAVE;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.CLOSE;

            DataTableConstruction();
            InitialSetGridCol();
            SetData();
            tempList = XmlLoad();
            for (int index = 0; index < uGrid.Rows.Count; index++)
            {
                string prestring = this.uGrid.Rows[index].Cells[MAKERCODE].Value.ToString();
                preList.Add(prestring);
            }

        }
        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : Control.Click�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            this.Ok_Button.Focus();
            this.DataToXmlFile(_dt);
            
        }
        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : Control.Click�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Cancel_Button.Focus();
            if (!CompareOriginalScreen())
            {
                //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // �ۑ�����
                            Ok_Button_Click(sender, e);
                            int code = 0;
                            if (!CheckData(out code))
                            {
                                return;
                            }
                            this.DialogResult = DialogResult.OK;

                            break;
                        }
                    case DialogResult.No:
                        {
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        }
                    default:
                        {
                            this.Cancel_Button.Focus();
                            return;
                        }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// tArrowKeyControl1_ChangeFocus�C�x���g
        /// </summary>
        /// <param name= "sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name= "e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : tArrowKeyControl1_ChangeFocus�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            if (e.PrevCtrl == this.uGrid)
            {
                // �V�t�g�L�[�������Ȃ�
                if (!e.ShiftKey)
                {
                    // �A�N�e�B�u�Z�������݂���
                    if (this.uGrid.ActiveCell != null)
                    {
                        if ((this.uGrid.ActiveCell.Row.Index == this.uGrid.Rows.Count - 1
                           && this.uGrid.ActiveCell.Column.Key == MAKERGUID) ||
                           this.uGrid.ActiveCell.Column.Key == MAKERCODE
                           && this.uGrid.ActiveCell.Row.Index == this.uGrid.Rows.Count - 1
                           && !string.IsNullOrEmpty(this.uGrid.Rows[this.uGrid.ActiveCell.Row.Index].Cells[MAKERCODE].Value.ToString()))
                        {
                            e.NextCtrl = Ok_Button;
                        }
                        else if (this.uGrid.ActiveCell.Row.Index < this.uGrid.Rows.Count
                                && this.uGrid.ActiveCell.Column.Key == MAKERCODE
                           && !string.IsNullOrEmpty(this.uGrid.Rows[this.uGrid.ActiveCell.Row.Index].Cells[MAKERCODE].Value.ToString())
                                 && e.Key != Keys.LButton)
                        {

                            this.uGrid.ActiveCell = this.uGrid.Rows[this.uGrid.ActiveCell.Row.Index + 1].Cells[MAKERCODE];
                            this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            e.NextCtrl = null;
                        }
                        else if (this.uGrid.ActiveCell.Row.Index == this.uGrid.Rows.Count - 1)
                        {
                            if (this.uGrid.Rows.Count < 99 && e.Key != Keys.LButton)
                            {
                                DataRow dr = this._dt.NewRow();
                                dr[MAKERNO] = this.uGrid.Rows.Count + 1;
                                dr[MAKERCODE] = string.Empty;
                                this._dt.Rows.Add(dr);
                                InitialSetGridCol();
                                this.uGrid.ActiveCell = this.uGrid.Rows[this.uGrid.Rows.Count - 1].Cells[MAKERCODE];
                                this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                e.NextCtrl = null;
                            }
                        }
                        else if (e.Key != Keys.LButton)
                        {
                            // ���̃Z���Ɉړ�
                            this.uGrid.PerformAction(UltraGridAction.NextCellByTab);
                            e.NextCtrl = null;
                        }
                       
                    }
                }
                // �V�t�g�L�[������
                else
                {
                    // �A�N�e�B�u�Z�������݂���
                    if (this.uGrid.ActiveCell != null)
                    {
                        if (this.uGrid.ActiveCell.Row.Index == 0 && this.uGrid.ActiveCell.Column.Key == MAKERCODE)
                        {
                            e.NextCtrl = Cancel_Button;
                        }
                        else
                        {
                            // �O�̃Z���Ɉړ�
                            this.uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                            e.NextCtrl = null;
                        }
                    }
                }
            }
            if (e.PrevCtrl == this.Ok_Button)
            {
                if (e.ShiftKey)
                {
                    e.NextCtrl = this.uGrid;
                    this.uGrid.PerformAction(UltraGridAction.LastCellInGrid);
                }
            }
            if (e.PrevCtrl == this.Cancel_Button)
            {
                if (!e.ShiftKey && e.Key != Keys.LButton
                    && e.Key != Keys.Left
                    && e.Key != Keys.Up)
                {
                    e.NextCtrl = null;
                    this.uGrid.PerformAction(UltraGridAction.FirstCellInGrid);
                    this.uGrid.Rows[0].Cells[MAKERCODE].Activate();
                    this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }
        /// <summary>
        /// uGrid_AfterPerformAction�C�x���g
        /// </summary>
        /// <param name= "sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name= "e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : uGrid_AfterPerformAction���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    UltraGridCell ugCell = this.uGrid.ActiveCell;
                    if ((ugCell != null) &&
                        (ugCell.Column.CellActivation == Activation.AllowEdit) &&
                        (ugCell.Activation == Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.uGrid.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (this.uGrid.PerformAction(UltraGridAction.EnterEditMode))
                                    {
                                        if ((this.uGrid.ActiveCell.Value is System.DBNull) ||
                                            (this.uGrid.ActiveCell.Value == DBNull.Value))
                                        {
                                        }
                                        else
                                        {
                                            if (this.uGrid.ActiveCell.IsInEditMode)
                                            {
                                                // �S�I��
                                                this.uGrid.ActiveCell.SelectAll();
                                            }
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// uGrid_InitializeLayout�C�x���g
        /// </summary>
        /// <param name= "sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name= "e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : uGrid_FeeInfo_InitializeLayout�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            MakeKeyMappingForGrid(uGrid);
        }
        /// <summary>
        /// Timer.Tick �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///                   ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///	                  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.uGrid.ActiveCell = this._preCell;
            this.uGrid.PerformAction(UltraGridAction.EnterEditMode);
            this._preCell = null;
        }
        /// <summary>
        ///	ultraGrid.KeyPress �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃L�[�����C�x���g�����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid.ActiveCell;

            // ���[�J�[�R�[�h�̓��͌����`�F�b�N
            if (cell.Column.Key == MAKERCODE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Control.KeyDown �C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            // �A�N�e�B�u�Z����null�̎��͏������s�킸�I��
            if (this.uGrid.ActiveCell == null)
            {
                return;
            }

            // �O���b�h��Ԏ擾()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid.CurrentState;

            //�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ���L�[
                    case Keys.Up:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = MoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Down:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = MoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Left:
                        {
                            // left�̃Z���ֈړ�
                            if (this.uGrid.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                this.uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                            else
                            {
                                this.uGrid.PerformAction(UltraGridAction.ActivateCell);
                                e.Handled = true;
                            }
                           
                            break;
                        }
                    // ���L�[
                    case Keys.Right:
                        {
                            // right�̃Z���ֈړ�
                            if (this.uGrid.ActiveCell.StyleResolved != Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                this.uGrid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                            else
                            {
                                this.uGrid.PerformAction(UltraGridAction.ActivateCell);
                                e.Handled = true;
                            }
                         
                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.uGrid.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                uGrid_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }

                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }
        /// <summary>
        /// ���b�h�K�C�h�{�^��
        /// </summary>
        /// <param name= "sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name= "e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�K�C�h�{�^������</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            bevalueFlag = true;
            MakerUMnt makerUMnt; 
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            int index = e.Cell.Row.Index;
            if (e.Cell.Column.Key == MAKERGUID)
            {
                if (status == 0)
                {
                    // ���ʃZ�b�g
                    this.uGrid.Rows[index].Cells[MAKERCODE].Value = makerUMnt.GoodsMakerCd.ToString("0000");
                }
            }
        }
        /// <summary>
        /// uGrid_AfterCellUpdate�C�x���g
        /// </summary>
        /// <param name= "sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name= "e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : uGrid_AfterCellUpdate</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            string cellKey = e.Cell.Column.Key;
            bevalueFlag = true;
            this.uGrid.ImeMode = ImeMode.Disable;
            if (!string.IsNullOrEmpty(_beMakerCd))
            {
                _beMakerCd = _beMakerCd.PadLeft(4, '0');
            }
            if (cellKey == MAKERCODE)
            {
                string code = e.Cell.Row.Cells[MAKERCODE].Value.ToString();
                if (!String.IsNullOrEmpty(code))
                {
                    code = code.PadLeft(4, '0');
                }
                string name = string.Empty;
                if (!_beMakerCd.Equals(code) && code != "")
                {
                    name = GetGoodsMaker(code);
                    if (name != null)
                    {
                        if (tempList == null)
                        {
                            if (list.Count == 0)
                            {
                                list.Add(code);
                                e.Cell.Value = code;
                            }
                            else
                            {
                                if (list.Contains(code))
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    ASSEMBLY_ID,
                                    "�Y�����郁�[�J�[�R�[�h���d�����܂��B",
                                    -1,
                                    MessageBoxButtons.OK);
                                    bevalueFlag = false;
                                    e.Cell.Value = _beMakerCd;
                                    this._preCell = e.Cell;
                                    timer1.Enabled = true;
                                }
                                else
                                {
                                    list.Add(code);
                                    list.Remove(_beMakerCd);
                                    e.Cell.Value = code;
                                }
                            }
                        }
                        else
                        {
                            if (list.Count == 0)
                            {
                                list.Add(code);
                                e.Cell.Value = code;
                            }
                            else
                            {
                                if (list.Contains(code))
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    ASSEMBLY_ID,
                                    "�Y�����郁�[�J�[�R�[�h���d�����܂��B",
                                    -1,
                                    MessageBoxButtons.OK);
                                    bevalueFlag = false;
                                    e.Cell.Value = _beMakerCd;
                                    this._preCell = e.Cell;
                                    timer1.Enabled = true;
                                }
                                else
                                {
                                    list.Add(code);
                                    list.Remove(_beMakerCd);
                                    e.Cell.Value = code;
                                }
                            }
                        }
                    }
                    else
                    {
                        // �G���[���b�Z�[�W
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "�Y�����郁�[�J�[�R�[�h�����݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);
                        bevalueFlag = false;
                        e.Cell.Value = _beMakerCd;
                        this._preCell = e.Cell;
                        timer1.Enabled = true;
                    }
                }
                else
                {
                    if (code == "")
                    {
                        list.Remove(_beMakerCd);
                    }
                }
            }
        }
        /// <summary>
        /// uGrid_BeforeCellActivate�C�x���g
        /// </summary>
        /// <param name= "sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name= "e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : uGrid_BeforeCellActivate</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void uGrid_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (bevalueFlag)
            {
                _beMakerCd = e.Cell.Row.Cells[MAKERCODE].Value.ToString();
            }
        }
        # endregion 

        # region Private Methods
        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ� False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʓǍ����Ɖ�ʏI�����̃f�[�^���r���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            bool resflag = true;
            ArrayList list = new ArrayList();
            for (int index = 0; index < uGrid.Rows.Count; index++)
            {
                string str = this.uGrid.Rows[index].Cells[MAKERCODE].Value.ToString();
                list.Add(str);
            }
            if (preList.Count != list.Count)
            {
                resflag = false;
            }
            else
            {
                for (int i = 0; i < preList.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (preList[i] != list[j] && i == j)
                        {
                            resflag = false;
                        }
                    }
                }
            }
            return resflag;
        }
        /// <summary>
        /// CheckData
        /// </summary>
        /// <param name="errorindex">errorindex</param>
        /// <returns>resultflag</returns>
        /// <remarks>
        /// <br>Note       : CheckData</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private bool CheckData(out int errorindex)
        {
            bool resultflag = true;
            errorindex = 0;

            for (int i = 0; i < this.uGrid.Rows.Count; i++)
            {
                if (String.IsNullOrEmpty(this.uGrid.Rows[i].Cells[MAKERCODE].Value.ToString()))
                {
                    resultflag = false;
                    errorindex = i;
                    break;
                }
                if (!Int32.TryParse(this.uGrid.Rows[i].Cells[MAKERCODE].Value.ToString(), out errorindex))
                {
                    resultflag = false;
                    errorindex = i;
                    break;
                }

                if (this.uGrid.Rows[i].Cells[MAKERCODE].Value.ToString() == "0")
                {
                    this.uGrid.Rows[i].Cells[MAKERCODE].Value = DBNull.Value;
                }

                if (i != 0)
                {
                    if (this.uGrid.Rows[i].Cells[MAKERCODE].Value.ToString() != "")
                    {
                        resultflag = false;
                        errorindex = i;
                        break;
                    }
                }
            }
            return resultflag;
        }
        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                       // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }
        /// <summary>
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�L�[�}�b�s���O�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void MakeKeyMappingForGrid(UltraGrid grid)
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
            grid.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);
        }
        /// <summary>
        /// �f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u����ݒ肵�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void DataTableConstruction()
        {
            if (this._dt == null)
            {
                //// �e�[�u���̒�`
                this._dt = new DataTable(MAKER_TABLE);

                this._dt.Columns.Add(MAKERNO, typeof(int));
                this._dt.Columns.Add(MAKERCOL, typeof(string));
                this._dt.Columns.Add(MAKERCODE, typeof(string));
                this._dt.Columns.Add(MAKERGUID, typeof(string));
            }
            this.uGrid.DataSource = this._dt.DefaultView;
        }
        /// <summary>
        /// xml to datatable����
        /// </summary>
        /// <remarks>
        /// <br>Note       :datatable to xml�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private List<UoeCdparameterList> XmlLoad()
        {
            List<UoeCdparameterList> fromXmlUoeList = null;
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME)))
            {
                try
                {
                    // XML���璊�o�����A�C�e���N���X�z��Ƀf�V���A���C�Y����
                    fromXmlUoeList = UserSettingController.DeserializeUserSetting<List<UoeCdparameterList>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                }
                if (fromXmlUoeList.Count > 0 || fromXmlUoeList != null)
                {
                    for (int i = 0; i < fromXmlUoeList.Count; i++)
                    {
                        UoeCdparameterList fromXmlUoeCdList = (UoeCdparameterList)fromXmlUoeList[i];
                        if (fromXmlUoeCdList.UoeCdparameter.Equals(this._UOECdparameter))
                        {
                            for (int j = 0; j < fromXmlUoeCdList.MakerCdList.Count; j++)
                            {
                                this.uGrid.Rows[j].Cells[MAKERCODE].Value = fromXmlUoeCdList.MakerCdList[j];
                                this.uGrid.Rows[j].Activated = true;
                            }
                            this.uGrid.Rows[0].Activated = true;
                            list = fromXmlUoeCdList.MakerCdList;
                        }
                    }
                }
            }
            return fromXmlUoeList;
        }
        /// <summary>
        /// datatable to xml����
        /// </summary>
        /// <param name="dt"> �f�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       :datatable to xml�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void DataToXmlFile(DataTable dt)
        {
             List<UoeCdparameterList> uoeList = tempList;
           
            bool newflag = false;
            try
            {
                if (dt != null)
                {
                    // loop uoeList
                    if (uoeList == null)
                    {
                        uoeList = new List<UoeCdparameterList>();
                        UoeCdparameterList uoeCdList = new UoeCdparameterList();
                        uoeCdList.UoeCdparameter = this._UOECdparameter;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!String.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                            {
                                uoeCdList.MakerCdList.Add(dt.Rows[i][2].ToString());
                            }
                        }
                        uoeList.Add(uoeCdList);
                    }
                    else
                    {
                        for (int i = 0; i < uoeList.Count; i++)
                        {
                            UoeCdparameterList uoeCdList = (UoeCdparameterList)uoeList[i];
                            if (uoeCdList.UoeCdparameter.Equals(this._UOECdparameter))
                            {
                                newflag = true;
                                uoeCdList.MakerCdList = new List<string>();
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    if (!String.IsNullOrEmpty(dt.Rows[j][2].ToString()))
                                    {
                                        uoeCdList.MakerCdList.Add(dt.Rows[j][2].ToString());
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (!newflag)
                        {
                            if (uoeList == null)
                            {
                                uoeList = new List<UoeCdparameterList>();
                            }

                            UoeCdparameterList uoeCdList = new UoeCdparameterList();
                            uoeCdList.UoeCdparameter = this._UOECdparameter;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (!String.IsNullOrEmpty(dt.Rows[i][2].ToString()))
                                {
                                    uoeCdList.MakerCdList.Add(dt.Rows[i][2].ToString().PadLeft(4, '0'));                               
                                }
                            }
                            uoeList.Add(uoeCdList);
                        }
                    }
                  
                    // ���o�����A�C�e���N���X�z���XML�ɃV���A���C�Y����
                    UserSettingController.SerializeUserSetting(uoeList, Path.Combine(ConstantManagement_ClientDirectory.UISettings, SAVE_XML_NAME));
                    this.Close();
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[���� ���Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// <br></br>
        /// </remarks>
        private string GetGoodsMaker(string goodsMakerCd)
        {
            string CoodsMakerName = string.Empty;
            MakerUMnt makerUMnt;
            try
            {
                int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, Convert.ToInt32(goodsMakerCd));
                if (status == 0 && makerUMnt.LogicalDeleteCode == 0)
                {
                    // ���ʃZ�b�g
                    CoodsMakerName = makerUMnt.MakerName;
                }
                else
                {
                    // ���ʃZ�b�g
                    CoodsMakerName = null;
                }
            }
            catch
            {
                CoodsMakerName = null;
            }

            return CoodsMakerName;
        }
        /// <summary>
        /// ��ʂ̃O���g�f�[�^�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ̃O���g�f�[�^�ݒ���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void SetData()
        {
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = this._dt.NewRow();
                dr[MAKERNO] = i + 1;
                dr[MAKERCODE] = string.Empty;
                this._dt.Rows.Add(dr);
            }
        }
        /// <summary>
        /// ��̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid.CurrentState;


            // ��̃Z���Ɉړ�
            performActionResult = this.uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
            if (performActionResult)
            {
                if ((this.uGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            return null;
        }
        /// <summary>
        /// ���̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid.CurrentState;


            // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
            int prevCol = this.uGrid.ActiveCell.Column.Index;
            int prevRow = this.uGrid.ActiveCell.Row.Index;

            // ���̃Z���Ɉړ�
            performActionResult = this.uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
            if (performActionResult)
            {
                if ((this.uGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            return null;
        }
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
        /// <param name="NumberFlg">���l���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// Note		   : �����ꂽ�L�[�����l�̂ݗL���ɂ��鏈�����s���܂��B<br />
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            // �����ꂽ�L�[�����l�ȊO�A�����l�ȊO���͕s��
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
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
                // �}�C�i�X(�����_)�����͉\���H
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                // �����_�ȉ�������0���H
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // �����_�����ɑ��݂��邩�H
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // �����_�����ɑ��݂��邩�H
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // �����������͉\�����ȏ�ŁA�J�[�\���ʒu�������_�ȍ~
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // �������̌��������͉\�����𒴂���
                        return false;
                    }
                }
                else
                {
                    // �����_������O��ɐ������̌���������
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart) + key
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
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// �O���g�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ̃O���g�ݒ���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void InitialSetGridCol()
        {
            // �O���b�h�̔w�i�F
            this.uGrid.DisplayLayout.Appearance.BackColor = Color.White;
            this.uGrid.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.uGrid.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �s�̒ǉ��s��
            this.uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // �s�̃T�C�Y�ύX�s��
            this.uGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // �s�̍폜�s��
            this.uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // ��̈ړ��s��
            this.uGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            this.uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // ��̌����s��
            this.uGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // �t�B���^�̎g�p�s��
            this.uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �^�C�g���̊O�ϐݒ�
            this.uGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // �O���b�h�̑I����@��ݒ�i�Z���P�̂̑I���̂݋��j
            this.uGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // �݂��Ⴂ�̍s�̐F��ύX
            this.uGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White;
            // �s�Z���N�^�\������
            this.uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            this.uGrid.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.uGrid.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // �uID�v�͕ҏW�s�i�Œ荀�ڂƂ��Đݒ�j
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].TabStop = false;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].CellAppearance.ForeColor = Color.White;

            //�󔒗�̐ݒ�
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].TabStop = false;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].Header.Caption = string.Empty;

            // ���[�J�[�R�[�h��̐ݒ�
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].CellActivation = Activation.AllowEdit;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].TabStop = true;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].Header.Caption = string.Empty;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].MaxLength = 4;

            // �K�C�h�{�^���̐ݒ�
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellActivation = Activation.NoEdit;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].TabStop = true;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellAppearance.Cursor = Cursors.Hand;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].Header.Caption = string.Empty;

            // �Z���̕��̐ݒ�
            if (this.uGrid.Rows.Count > 10)
            {
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].Width = 50;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].Width = 24;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].Width = 116;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].Width = 24;
            }
            else
            {
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERNO].Width = 50;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCOL].Width = 25;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].Width = 132;
                this.uGrid.DisplayLayout.Bands[0].Columns[MAKERGUID].Width = 25;
            }

            // �I���s�̊O�ϐݒ�
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(7, 59, 150);

            // �A�N�e�B�u�s�̊O�ϐݒ�
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(89, 135, 214);
            this.uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(7, 59, 150);

            // �s�Z���N�^�̊O�ϐݒ�
            this.uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.uGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �r���̐F��ύX
            this.uGrid.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
        }
        /// <summary>
        /// �O�ԑΉ����[�J�[��ʕ\������
        /// </summary>
        /// <param name="str">������R�[�h</param>
        /// <remarks>
        /// <br>Note	   : �O�ԑΉ����[�J�[��ʕ\���������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        public void ShowDialog(string str)
        {
            this._UOECdparameter = str;
            this.ShowDialog();
        }
        # endregion 
    }
    /// <summary>
    /// UoeCdparameterList�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UoeCdparameterList�N���X�̏���</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/10/26</br>
    /// </remarks>
    public class UoeCdparameterList
    {
        private string _uoeCdparameter;
        private List<string> _makerCdList = new List<string>();
        /// <summary>
        /// ������R�[�h
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������R�[�h</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        public string UoeCdparameter
        { 
            get
            {
                return _uoeCdparameter;
            }
            set
            {
                _uoeCdparameter = value;
            }
        }
        /// <summary>
        /// ���[�J�[�R�[�h��list
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h��list</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        public List<string> MakerCdList
        {
            get
            {
                return _makerCdList;
            }
            set
            {
                _makerCdList = value;
            }
        }
    }
}