//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC-UOE���[�����b�Z�[�W�ݒ菈��
// �v���O�����T�v   : PCC-UOE���[�����b�Z�[�W�ݒ菈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �� �� ��              �C�����e :
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC-UOE���[�����b�Z�[�W�ݒ菈���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC-UOE���[�����b�Z�[�W�ݒ菈���̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.08</br>
    /// <br></br>
    /// </remarks>
    public partial class PMPCC01001UA : Form
    {
        # region ��Constructors
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMPCC01001UA()
        {
            InitializeComponent();
            //��ƃR�[�h
            _erterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._nextCustomerButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_NextCustomer"];
            this._preCustomerButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PreCustomer"];
            this._nextShowButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_NextShow"];
            this._preShowButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PreShow"];
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"];
            this._newButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_New"];

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            // ���O�C���S����
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._pccMailDtAcs = new PccMailDtAcs();
            //PCC���Аݒ�}�X�^�����e�A�N�Z�X�N���X
            this._pccCmpnyStAcs = new PccCmpnyStAcs();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
            // ��ʏ������O���b�h
            //���Ӑ�f�[�^�̔ԍ�
            _customerDataIndex = -1;
            //���[�������ꗗ�f�[�^�̔ԍ�
            _messageDelDataIndex = -1;

            //���Ӑ�O���b�h
            this.InitCustomerDateSet();
            this.InitCustomerGrid();
            // ���[�������ꗗ�f�[�^�Z�b�g
            this.InitMessageDelDateSet();
            this.InitMailNoDateSet();
            this.InitMessageDelGrid();
            this.uCheckEditor_DeleteShow.Checked = false;
        }
        # endregion
       
        # region ��Private Members
        private PccMailDtAcs _pccMailDtAcs;
        
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;             // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _nextCustomerButton;      // �����Ӑ�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _preCustomerButton;       // �O���Ӑ�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _nextShowButton;          // ���\���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _preShowButton;           // �O�\���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;            // �폜�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _newButton;               // �V�K�쐬�{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;          // ���O�C���S���҃��x��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		   // ���O�C���S���Җ���
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        private string _erterpriseCode = null;
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        private string _sectionCode = null;
        /// <summary>
        /// ���Ӑ�O���b�h�f�[�^�Z�b�g
        /// </summary>
        private DataSet _customerDateSet = null;
        /// <summary>
        /// ���[�������ꗗALL�f�[�^�Z�b�g
        /// </summary>
        private DataSet _messageDelAllDateSet = null;

        /// <summary>
        /// ���[�������ꗗ�f�[�^�Z�b�g
        /// </summary>
        private DataSet _messageDelDateSet = null;
        /// <summary>
        /// ���[�������ꗗ�f�[�^�Z�b�g
        /// </summary>
        private DataView _messageDataView = null;

        /// <summary>
        /// ���[�����Ȃ��̃f�[�^�Z�b�g
        /// </summary>
        private DataSet _messageNoFileDateSet = null;

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�A�N�Z�X�N���X
        /// </summary>
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        /// <summary>
        /// ���Ӑ�f�[�^�̔ԍ�
        /// </summary>
        private int _customerDataIndex;
        /// <summary>
        /// ���[�������ꗗ�f�[�^�̔ԍ�
        /// </summary>
        private int _messageDelDataIndex;
        // ���Ӑ�e�[�v��
        private Hashtable _customerHTable;
        // ���[�������ꗗ�e�[�v��
        private Hashtable _messageDelHTable;
        //���t�擾���i
        private DateGetAcs _dateGet;
        private Dictionary<string, Dictionary<string, PccMailDt>> _pccMailDtDic = null;
        //�O�Ώۓ��J�n
        private int preDateSt = 0;
        //�O�Ώۓ��I��
        private int preDateEd = 0;
        //�폜�{�^���\��FLAG
        private bool _showDeleBtFlg = false;
        #endregion

        #region ��Const Members
        private const string ASSEMBLY_ID = "PMPCC01001U";
        private const string DELETE_DATE = "�폜��";
        private const string PCCCUSTOMERCODE_TITLE = "PCC���Ӑ�R�[�h";
        //private const string PCCCUSTOMERNAME_TITLE = "PCC���Ӑ�";  //DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
        private const string PCCCUSTOMERNAME_TITLE = "���Ӑ�";  //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PCCMAILTITLE_TITLE = "����";
        private const string UPDATEDATETIME_TITLE = "���M����";
        //�⍇������A
        private const string INQCONDITION_TITLEA = "GUID";
        //�⍇������B
        private const string INQCONDITION_TITLEB = "GUID";
        private const string CUSTOMER_TABLE = "CUSTOMER_TABLE";
        private const string MESSAGEDEL_TABLE = "MESSAGEDEL_TABLE";
        private const string INF_NOT_FOUND = "�Y������f�[�^������܂���B";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";
        //private const string MAIL_NOTEXSIT_MSG = "���[��������܂���B";�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
        private const string MAIL_NOTEXSIT_MSG = "���b�Z�[�W������܂���B";�@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
        #endregion

        # region ��Control Event Methods
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : PCC-UOE���[�����b�Z�[�W�ݒ�����������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08/</br>
        /// </remarks>
        private void PMPCC01001UA_Load(object sender, EventArgs e)
        {
            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();
            //���Ӑ�O���b�h�����ݒ菈��
            this.InitCustomerDate();

           
            // �������t�H�[�J�X�ݒ�
            this.tDateEdit_UpdateDateSt.Focus();
            //�Ώۓ��̏����l�̓V�X�e�����t�|�V���`�V�X�e�����t
            this.tDateEdit_UpdateDateSt.SetDateTime(DateTime.Now.AddDays(-7));
            this.tDateEdit_UpdateDateEd.SetDateTime(DateTime.Now);
            //�O�Ώۓ��J�n
            preDateSt = this.tDateEdit_UpdateDateSt.GetLongDate();
            //�O�Ώۓ��I��
            preDateEd = this.tDateEdit_UpdateDateEd.GetLongDate();
            
            //���[�������ꗗ�O���b�h�����ݒ菈��
            this.GetPccMailDtDic();
           
            this.timer_Slide.Enabled = true;
        }

        /// <summary>
        ///Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08/</br>
        /// </remarks>
        private void timer_Slide_Tick(object sender, EventArgs e)
        {
            this.timer_Slide.Enabled = false;
            //��ʋ����䏈��
            ScreenInputPermissionControl();
        }

        /// <summary>
        ///�폜�ς݃f�[�^�̕\�� �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �폜�ς݃f�[�^�̕\�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08/</br>
        /// </remarks>
        private void uCheckEditor_DeleteShow_CheckedChanged(object sender, EventArgs e)
        {
            UltraGridBand editBand = this.uGrid_MessageDel.DisplayLayout.Bands[MESSAGEDEL_TABLE];
            if (this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].DefaultView.Count == 0)
            {
                if (editBand.Columns[DELETE_DATE].Hidden)
                {
                    editBand.Columns[DELETE_DATE].Hidden = false;
                }
                else
                {
                    editBand.Columns[DELETE_DATE].Hidden = true;
                }
                return;
            }
            //�I�������̍s
            int avtiveIndex = 0;
            string infoCondtion = string.Empty;
            bool isDeleteShow = this.uCheckEditor_DeleteShow.Checked;
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0)
            {
                if (this.uGrid_MessageDel.ActiveRow != null)
                {
                    infoCondtion = (string)this.uGrid_MessageDel.ActiveRow.Cells[INQCONDITION_TITLEA].Value;
                }
            }         
            //�폜�ς݃f�[�^�̕\��
            if (isDeleteShow)
            {
                editBand.Columns[DELETE_DATE].Hidden = false;
                this.uGrid_MessageDel.DataSource = this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                _showDeleBtFlg = true;
            }
            else
            {
                editBand.Columns[DELETE_DATE].Hidden = true;
                if (this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count > 0)
                {
                    this.uGrid_MessageDel.DataSource = this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                    _showDeleBtFlg = true;
                }
                else
                {
                    this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                    this.tEdit_PccMailDocCnts.Text = string.Empty;
                    this.tEdit_PccMailTitle.Text = string.Empty;
                    _showDeleBtFlg = false;
                }
            }
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0)
            {
                for (int i = 0; i < this.uGrid_MessageDel.Rows.Count; i++)
                {
                    string infoCondtionNew = (string)this.uGrid_MessageDel.Rows[i].Cells[INQCONDITION_TITLEA].Value;
                    if (infoCondtionNew.Equals(infoCondtion))
                    {
                        avtiveIndex = i;
                        break;
                    }
                }
                this._messageDelDataIndex = avtiveIndex;
                this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
            }
            else
            {
                this.tEdit_PccMailDocCnts.Text = string.Empty;
                this.tEdit_PccMailTitle.Text = string.Empty;

            }
            //��ʋ����䏈��
            ScreenInputPermissionControl();
        }

        /// <summary>���C���c�[���o�[�}�l�[�W���[ToolClick</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// Note       : ���C���c�[���o�[�}�l�[�W���[��ToolClick�����ł��B<br />
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //�A�N�e�B�u��ԂɂȂ��Ă���c�[���̃t�H�[�J�X���N���A����
            e.Tool.IsActiveTool = false;
            switch (e.Tool.Key)
            {
                // ����{�^��
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                //�����Ӑ�{�^��
                case "ButtonTool_NextCustomer":
                    {
                        this.NextCustomerProc();
                        break;
                    }
                //�O���Ӑ�{�^��
                case "ButtonTool_PreCustomer":
                    {
                        this.PreCustomerProc();
                        break;
                    }
                //���\���{�^��
                case "ButtonTool_NextShow":
                    {
                        this.NextShowProc();
                        break;
                    }
                //�O�\���{�^��
                case "ButtonTool_PreShow":
                    {
                        this.PreShowProc();
                        break;
                    }
                //�폜�{�^��
                case "ButtonTool_Delete":
                    {
                        this.DeleteProc();
                        break;
                    }
                //�V�K�쐬�{�^��
                case "ButtonTool_New":
                    {
                        this.NewProc();
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            string message = string.Empty;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            // PrevCtrl�ݒ�
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
           
            switch (prevCtrl.Name)
            {
                //���Ӑ�O���b�h
                case "uGrid_Customer":
                    {
                        
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = tDateEdit_UpdateDateSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = uCheckEditor_DeleteShow;
                            }
                        }
                        break;
                    }
                //���[�������ꗗ�O���b�h
                case "uGrid_MessageDel":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = uCheckEditor_DeleteShow;
                            }
                        }
                        else
                        {
                            {
                                e.NextCtrl = tDateEdit_UpdateDateEd;
                            }
                        }
                        break;
                    }
                //�Ώۓ��J�n
                case "tDateEdit_UpdateDateSt":
                    {
                        if (!("tDateEdit_UpdateDateEd".Equals(e.NextCtrl.Name)))
                        {
                            Control errControl = null;

                            bool result = this.ScreenInputCheck(out message, ref errControl);
                            if (!result)
                            {
                                // ���b�Z�[�W��\��
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, message, -1, MessageBoxButtons.OK);
                                e.NextCtrl = errControl;
                                return;
                            }
                            else
                            {
                                PccMailDt parsePccMailDt = new PccMailDt();
                                parsePccMailDt.InqOtherEpCd = this._erterpriseCode;
                                parsePccMailDt.InqOtherSecCd = this._sectionCode;
                                parsePccMailDt.UpdateDateSt = tDateEdit_UpdateDateSt.GetLongDate();
                                parsePccMailDt.UpdateDateEd = tDateEdit_UpdateDateEd.GetLongDate();
                                if (preDateSt != this.tDateEdit_UpdateDateSt.GetLongDate() || preDateEd != this.tDateEdit_UpdateDateEd.GetLongDate())
                                {
                                    if (this._pccMailDtAcs == null)
                                    {
                                        _pccMailDtAcs = new PccMailDtAcs();
                                    }

                                    //�O�Ώۓ��J�n
                                    preDateSt = this.tDateEdit_UpdateDateSt.GetLongDate();
                                    //�O�Ώۓ��I��
                                    preDateEd = this.tDateEdit_UpdateDateEd.GetLongDate();
                                    int status = this._pccMailDtAcs.Search(ref this._pccMailDtDic, parsePccMailDt, 0, ConstantManagement.LogicalMode.GetData01);
                                    // ���[�������ꗗ�f�[�^�Z�b�g
                                    this._messageDelDataIndex = -1;
                                    this.InitPccMailDtDate();
                                    this.timer_Slide.Enabled = true;
                                }

                            }

                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = tDateEdit_UpdateDateEd;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = uGrid_Customer;
                                }
                            }
                        }
                        break;
                    }
                //�Ώۓ��I��
                case "tDateEdit_UpdateDateEd":
                    {
                        if (!("tDateEdit_UpdateDateSt".Equals(e.NextCtrl.Name)))
                        {
                            Control errControl = null;
                            bool result = this.ScreenInputCheck(out message, ref errControl);
                            if (!result)
                            {
                                // ���b�Z�[�W��\��
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, message, -1, MessageBoxButtons.OK);
                                e.NextCtrl = errControl;
                                return;
                            }
                            else
                            {
                                PccMailDt parsePccMailDt = new PccMailDt();
                                parsePccMailDt.InqOtherEpCd = this._erterpriseCode;
                                parsePccMailDt.InqOtherSecCd = this._sectionCode;
                                parsePccMailDt.UpdateDateSt = tDateEdit_UpdateDateSt.GetLongDate();
                                parsePccMailDt.UpdateDateEd = tDateEdit_UpdateDateEd.GetLongDate();
                                if (preDateSt != this.tDateEdit_UpdateDateSt.GetLongDate() || preDateEd != this.tDateEdit_UpdateDateEd.GetLongDate())
                                {
                                    if (this._pccMailDtAcs == null)
                                    {
                                        _pccMailDtAcs = new PccMailDtAcs();
                                    }

                                    //�O�Ώۓ��J�n
                                    preDateSt = this.tDateEdit_UpdateDateSt.GetLongDate();
                                    //�O�Ώۓ��I��
                                    preDateEd = this.tDateEdit_UpdateDateEd.GetLongDate();
                                    int status = this._pccMailDtAcs.Search(ref this._pccMailDtDic, parsePccMailDt, 0, ConstantManagement.LogicalMode.GetData01);
                                    // ���[�������ꗗ�f�[�^�Z�b�g
                                    this._messageDelDataIndex = -1;
                                    this.InitPccMailDtDate();
                                    this.timer_Slide.Enabled = true;                                   
                                }
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = uGrid_MessageDel;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = tDateEdit_UpdateDateSt;
                            }
                        }
                        
                        break;
                    }
            }

            switch (e.NextCtrl.Name)
            {
                //���[�������ꗗ�O���b�h
                case "uGrid_MessageDel":
                    {
                        if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && this._showDeleBtFlg)
                        {
                            this._preShowButton.SharedProps.Enabled = true;
                            this._nextShowButton.SharedProps.Enabled = true;
                            this._deleteButton.SharedProps.Enabled = true;
                        }
                        else
                        {
                            this._preShowButton.SharedProps.Enabled = false;
                            this._nextShowButton.SharedProps.Enabled = false;
                            this._deleteButton.SharedProps.Enabled = false;
                        }
                        break;
                    }

            }
        }

        /// <summary>
        ///  ���Ӑ�O���b�h�Z���A�b�v�f�[�g�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       :  ���Ӑ�O���b�h�Z���A�b�v�f�[�g�O�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void uGrid_Customer_AfterRowActivate(object sender, EventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            int rowIndex = ultraGrid.ActiveRow.Index;
            this._customerDataIndex = rowIndex;
            _messageDelDataIndex = -1;
            this.InitPccMailDtDate();
            //��ʋ����䏈��
            ScreenInputPermissionControl();
        }

        /// <summary>
        ///  ���[�������ꗗ�O���b�h�Z���A�b�v�f�[�g�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       :  ���[�������ꗗ�O���b�h�Z���A�b�v�f�[�g�O�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void uGrid_MessageDel_AfterRowActivate(object sender, EventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            int rowIndex = ultraGrid.ActiveRow.Index;
            this._messageDelDataIndex = rowIndex;
            string inqCondition = (string)this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Cells[INQCONDITION_TITLEA].Value;
            if (!string.IsNullOrEmpty(inqCondition))
            {
                if (this._messageDelHTable.ContainsKey(inqCondition))
                {
                    PccMailDt pccMailDt = ((PccMailDt)this._messageDelHTable[inqCondition]).Clone();
                    this.tEdit_PccMailDocCnts.Text = pccMailDt.PccMailDocCnts;
                    this.tEdit_PccMailTitle.Text = pccMailDt.PccMailTitle;
                }
                else
                {
                    this.tEdit_PccMailDocCnts.Text = string.Empty;
                    this.tEdit_PccMailTitle.Text = string.Empty;
                }
            } 
            //��ʋ����䏈��
            ScreenInputPermissionControl();
        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�L�[�_�E�����ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void uGrid_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
             //�A�N�e�B�u�Z�������݂���Ƃ�
            if (ultraGrid.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                    this.uGrid_MessageDel.Focus();
                    if (this.uGrid_MessageDel.ActiveRow == null && this.uGrid_MessageDel.Rows.Count > 0)
                    {
                        this.uGrid_MessageDel.Rows[0].Activated = true;
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�L�[�_�E�����ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void uGrid_MessageDel_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            //�A�N�e�B�u�Z�������݂���Ƃ�
            if (ultraGrid.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Left)
                {
                    e.Handled = true;
                    this.uGrid_Customer.Focus();
                    if ( this.uGrid_Customer.ActiveRow == null && this.uGrid_Customer.Rows.Count > 0)
                    {
                        this.uGrid_Customer.Rows[0].Activated = true;
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                }
            }
        }
        #endregion
        
        #region ��Private Methods
        
        /// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : ���C��</br>
		/// <br>Date       : 2011.07.20</br>
		/// </remarks>
        private void ScreenInputPermissionControl()
        {
            if (this.uGrid_Customer != null && this.uGrid_Customer.Rows.Count > 0)
            {
                _nextCustomerButton.SharedProps.Enabled = true;
                _preCustomerButton.SharedProps.Enabled = true;
                _newButton.SharedProps.Enabled = true;
            }
            else
            {
                _nextCustomerButton.SharedProps.Enabled = false;
                _preCustomerButton.SharedProps.Enabled = false;

                _newButton.SharedProps.Enabled = false;
            }

            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && _showDeleBtFlg && this.uGrid_MessageDel.ActiveRow != null)
            {
                _preShowButton.SharedProps.Enabled = true;
                _nextShowButton.SharedProps.Enabled = true;
                _deleteButton.SharedProps.Enabled = true;
            }
            else
            {
                _preShowButton.SharedProps.Enabled = false;
                _nextShowButton.SharedProps.Enabled = false;
                _deleteButton.SharedProps.Enabled = false;
            }
           
        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._nextCustomerButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;
            this._preCustomerButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._nextShowButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT2;
            this._preShowButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE2;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// ���Ӑ�O���b�h�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�O���b�h�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitCustomerDateSet()
        {
            _customerDateSet = new DataSet();
            
            // �e�[�u���̒�`
            DataTable customerDt = new DataTable(CUSTOMER_TABLE);
            customerDt.Columns.Add(PCCCUSTOMERCODE_TITLE, typeof(int));
            customerDt.Columns.Add(PCCCUSTOMERNAME_TITLE, typeof(string));
            customerDt.Columns.Add(INQCONDITION_TITLEB, typeof(string));
            this._customerDateSet.Tables.Add(customerDt);
               
        }

        /// <summary>
        /// ���[�������ꗗ�O���b�h�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�������ꗗ�O���b�h�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitMessageDelDateSet()
        {
            _messageDelAllDateSet = new DataSet();
            // �e�[�u���̒�`
            DataTable messageDelDt = new DataTable(MESSAGEDEL_TABLE);
            messageDelDt.Columns.Add(DELETE_DATE, typeof(string));
            messageDelDt.Columns.Add(PCCMAILTITLE_TITLE, typeof(string));
            messageDelDt.Columns.Add(UPDATEDATETIME_TITLE, typeof(string));
            messageDelDt.Columns.Add(INQCONDITION_TITLEA, typeof(string));
            this._messageDelAllDateSet.Tables.Add(messageDelDt);

        }

        /// <summary>
        /// ���[�����Ȃ��̃f�[�^�Z�b�g�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�����Ȃ��̃f�[�^�Z�b�g�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitMailNoDateSet()
        {
            this._messageNoFileDateSet = this._messageDelAllDateSet.Copy();
            PccMailDt pm = new PccMailDt();
            pm.PccMailTitle = MAIL_NOTEXSIT_MSG;
            pm.UpdateDate = 0;
            pm.UpdateTime = 0;
            PccMailDtToDataSet(this._messageNoFileDateSet, pm.Clone(), 0);
        }

        /// <summary>
        /// ���Ӑ�O���b�h�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�O���b�h�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void InitCustomerGrid()
        {
            if (_customerDateSet.Tables[CUSTOMER_TABLE] != null)
            {
                this.uGrid_Customer.DataSource = _customerDateSet.Tables[CUSTOMER_TABLE].DefaultView;
                UltraGridBand editBand = this.uGrid_Customer.DisplayLayout.Bands[CUSTOMER_TABLE];
                this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
                this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
                //��̕\��Style�ݒ�
                editBand.Columns[PCCCUSTOMERCODE_TITLE].Header.Caption = PCCCUSTOMERCODE_TITLE;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].Header.Caption = PCCCUSTOMERNAME_TITLE;
                editBand.Columns[INQCONDITION_TITLEB].Header.Caption = INQCONDITION_TITLEB;

                editBand.Columns[PCCCUSTOMERNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[PCCCUSTOMERCODE_TITLE].Hidden = true;
                editBand.Columns[INQCONDITION_TITLEB].Hidden = true;

               
            }
        }

        /// <summary>
        /// ���[�������ꗗ�O���b�h�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�������ꗗ�O���b�h�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void InitMessageDelGrid()
        {
            if (_messageDelAllDateSet.Tables[MESSAGEDEL_TABLE] != null)
            {
                this._messageDelDateSet = _messageDelAllDateSet.Copy();
                _messageDataView = this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                _messageDataView.RowFilter = DELETE_DATE + "= ''";
                this.uGrid_MessageDel.DataSource = _messageDataView;
                UltraGridBand editBand = this.uGrid_MessageDel.DisplayLayout.Bands[MESSAGEDEL_TABLE];
                this.uGrid_MessageDel.DisplayLayout.Override.EditCellAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
                this.uGrid_MessageDel.DisplayLayout.Override.EditCellAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
                //��̕\��Style�ݒ�
                editBand.Columns[DELETE_DATE].Header.Caption = DELETE_DATE;
                editBand.Columns[PCCMAILTITLE_TITLE].Header.Caption = PCCMAILTITLE_TITLE;
                editBand.Columns[UPDATEDATETIME_TITLE].Header.Caption = UPDATEDATETIME_TITLE;
                editBand.Columns[INQCONDITION_TITLEA].Header.Caption = INQCONDITION_TITLEA;

                editBand.Columns[DELETE_DATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[DELETE_DATE].CellAppearance.ForeColor = System.Drawing.Color.Red;
                
                editBand.Columns[PCCMAILTITLE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[UPDATEDATETIME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[PCCMAILTITLE_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[UPDATEDATETIME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[INQCONDITION_TITLEA].Hidden = true;
                editBand.Columns[DELETE_DATE].Hidden = true;
                
                
                editBand.Columns[DELETE_DATE].Width = 100;
                editBand.Columns[PCCMAILTITLE_TITLE].Width = 421;
                editBand.Columns[UPDATEDATETIME_TITLE].Width = 200;
            }
        }

        /// <summary>
        /// ���Ӑ�O���b�h�f�[�^�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�O���b�h�f�[�^�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitCustomerDate()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
            parsePccCmpnySt.InqOtherEpCd = this._erterpriseCode;
            parsePccCmpnySt.InqOtherSecCd = this._sectionCode;
            List<PccCmpnySt> pccCmpnyStList = null;
            int index = 0;
            if (this._pccCmpnyStAcs == null)
            {
                _pccCmpnyStAcs = new PccCmpnyStAcs();
            }
            status = this._pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (this._customerHTable == null)
                {
                    this._customerHTable = new Hashtable();
                }
                else
                {
                    this._customerHTable.Clear();
                }
                string inqCondition = string.Empty;
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    //�x�[�X�ݒ�ΏۊO
                    if(string.IsNullOrEmpty(pccCmpnySt.InqOriginalEpCd.Trim()) || string.IsNullOrEmpty(pccCmpnySt.InqOriginalSecCd.TrimEnd())) //@@@@20230303
                    {
                        continue;
                    }
                    inqCondition = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                        + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
                    if (!this._customerHTable.ContainsKey(inqCondition))
                    {
                        // �N���X�f�[�^�Z�b�g�W�J����
                        PccCmpnyStToDataSet(pccCmpnySt.Clone(), index);
                        index++;
                    }
                    
                }
                this._customerDataIndex = 0;
                this.uGrid_Customer.Rows[this._customerDataIndex].Activate();
                this.uGrid_Customer.Rows[this._customerDataIndex].Selected = true;
            }
        }

        /// <summary>
        /// ���Ӑ�O���b�h�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="pccCmpnySt">PCC���Аݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�O���b�h�f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PccCmpnyStToDataSet(PccCmpnySt pccCmpnySt, int index)
        {
            string inqCondition = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                       + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
            if ((index < 0) || (this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this._customerDateSet.Tables[CUSTOMER_TABLE].NewRow();
                this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Count - 1;
            }

            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][PCCCUSTOMERCODE_TITLE] = pccCmpnySt.PccCompanyCode;
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][PCCCUSTOMERNAME_TITLE] = pccCmpnySt.PccCompanyName;
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][INQCONDITION_TITLEA] = inqCondition;

            if (this._customerHTable.ContainsKey(inqCondition))
            {
                this._customerHTable.Remove(inqCondition);
            }
            this._customerHTable.Add(inqCondition, pccCmpnySt);

        }

        /// <summary>
        /// ���[�������ꗗ�O���b�h�f�[�^�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�������ꗗ�O���b�h�f�[�^�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void GetPccMailDtDic()
        {
            PccMailDt parsePccMailDt = new PccMailDt();
            parsePccMailDt.InqOtherEpCd = this._erterpriseCode;
            parsePccMailDt.InqOtherSecCd = this._sectionCode;
            parsePccMailDt.UpdateDateSt = tDateEdit_UpdateDateSt.GetLongDate();
            parsePccMailDt.UpdateDateEd = tDateEdit_UpdateDateEd.GetLongDate();
            if (this._pccMailDtAcs == null)
            {
                _pccMailDtAcs = new PccMailDtAcs();
            }
            int status = this._pccMailDtAcs.Search(ref this._pccMailDtDic, parsePccMailDt, 0, ConstantManagement.LogicalMode.GetData01);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���[�������ꗗ�f�[�^�Z�b�g
                this._messageDelDataIndex = -1;
                this.InitPccMailDtDate();
                ScreenInputPermissionControl();
            }
            
        }

        /// <summary>
        /// ���[�������ꗗ�O���b�h�f�[�^�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�������ꗗ�O���b�h�f�[�^�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitPccMailDtDate()
        {
           Dictionary<string, PccMailDt> pccMailDtDic = null;
            string inqConditionCus = string.Empty;
            int index = 0;
            this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Clear();
            this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Clear();
            
             PccCmpnySt pccCmpnySt = null;
            if (this._customerDataIndex >= 0)
            {
                string guid = (string)this.uGrid_Customer.Rows[this._customerDataIndex].Cells[INQCONDITION_TITLEB].Value;
                pccCmpnySt = ((PccCmpnySt)this._customerHTable[guid]).Clone();
                inqConditionCus = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                       + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
                //PCC���[���f�[�^
                if (this._pccMailDtDic != null && this._pccMailDtDic.ContainsKey(inqConditionCus))
                {
                    pccMailDtDic = this._pccMailDtDic[inqConditionCus];
                }
                
            }

            if (pccMailDtDic != null && pccMailDtDic.Count > 0)
            {
                if (this._messageDelHTable == null)
                {
                    this._messageDelHTable = new Hashtable();
                }
                else
                {
                    this._messageDelHTable.Clear();
                }

                string inqCondition = string.Empty;
                foreach (KeyValuePair<string, PccMailDt> pccMailDtPair in pccMailDtDic)
                {
                    PccMailDt pccMailDt = pccMailDtPair.Value;
                    inqCondition = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                       + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd() + pccMailDt.UpdateDate + pccMailDt.UpdateTime;
                    if (!this._messageDelHTable.ContainsKey(inqCondition))
                    {
                        PccMailDtToDataSet(this._messageDelAllDateSet, pccMailDt.Clone(), index);
                        if (pccMailDt.LogicalDeleteCode == 0)
                        {
                            PccMailDtToDataSet(this._messageDelDateSet, pccMailDt.Clone(), index);
                        }
                        index++;
                    }
                   
                    // �N���X�f�[�^�Z�b�g�W�J����
                }
                bool messShowFlag = false;
                int messShowIndex = 0;
                //�폜�ς݃f�[�^�̕\�����Ȃ�
                if (uCheckEditor_DeleteShow.Checked == false)
                {
                    PccMailDt pccMailDtLog = null;
                    string guidLog = string.Empty;
                    for (int i = 0; i < this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count; i++)
                    { //�_���폜�敪=1:�_���폜
                        guidLog = (string)this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows[i][INQCONDITION_TITLEA];
                        pccMailDtLog = ((PccMailDt)this._messageDelHTable[guidLog]).Clone();

                        if (pccMailDtLog.LogicalDeleteCode == 0)
                        {
                            messShowFlag = true;
                            messShowIndex = i;
                            break;
                        }
                    }
                    if (messShowFlag)
                    {
                        this.uGrid_MessageDel.DataSource = this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                        this._messageDelDataIndex = messShowIndex;
                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                        guidLog = (string)this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Cells[INQCONDITION_TITLEA].Value;
                        pccMailDtLog = ((PccMailDt)this._messageDelHTable[guidLog]).Clone();

                        this.tEdit_PccMailDocCnts.Text = pccMailDtLog.PccMailDocCnts;
                        this.tEdit_PccMailTitle.Text = pccMailDtLog.PccMailTitle;
                        this._showDeleBtFlg = true;
                        
                    }
                    else
                    {
                        this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                        this.tEdit_PccMailDocCnts.Text = string.Empty;
                        this.tEdit_PccMailTitle.Text = string.Empty;
                        this._showDeleBtFlg = false;
                       
                    }
                }
                else
                {
                    this._messageDelDataIndex = 0;
                    if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0)
                    {
                        this.uGrid_MessageDel.DataSource = this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                        string guidLog2 = (string)this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Cells[INQCONDITION_TITLEA].Value;
                        PccMailDt pccMailDtFirst = ((PccMailDt)this._messageDelHTable[guidLog2]).Clone();

                        this.tEdit_PccMailDocCnts.Text = pccMailDtFirst.PccMailDocCnts;
                        this.tEdit_PccMailTitle.Text = pccMailDtFirst.PccMailTitle;
                        this._showDeleBtFlg = true;
                    }
                }

            }
            else
            {
                this.tEdit_PccMailDocCnts.Text = string.Empty;
                this.tEdit_PccMailTitle.Text = string.Empty;
                this._showDeleBtFlg = false;
                this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
            }
            
               
        }

        /// <summary>
        ///���[�������ꗗ�O���b�h�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="messageDelAllDateSet">�f�[�^�Z�b�g</param>
        /// <param name="pccMailDt">PCC���[���f�[�^</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[�������ꗗ�O���b�h�f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PccMailDtToDataSet(DataSet messageDelAllDateSet, PccMailDt pccMailDt, int index)
        {
            string inqCondition = string.Empty;
            if (!string.IsNullOrEmpty(pccMailDt.InqOriginalEpCd.Trim()))	//@@@@20230303
            {
                 inqCondition = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                           + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd() + pccMailDt.UpdateDate + pccMailDt.UpdateTime;

            }
            else
            {
                inqCondition = "";
            }
            if ((index < 0) || (messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].NewRow();
                messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count - 1;
            }
            if (pccMailDt.LogicalDeleteCode == 0)
            {
                messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][DELETE_DATE] = pccMailDt.UpdateDateTimeJpInFormal;
            }

            messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][PCCMAILTITLE_TITLE] = pccMailDt.PccMailTitle;
            string time1 = string.Empty;
            string time2 = string.Empty;
            if (!MAIL_NOTEXSIT_MSG.Equals(pccMailDt.PccMailTitle.TrimEnd()))
            {
                time1 = TDateTime.LongDateToString("yyyy�NMM��dd��", pccMailDt.UpdateDate);
                time2 = TDateTime.LongDateToString("HHmmssfff", "HH:mm:ss:fff", pccMailDt.UpdateTime);
                string time2Temp = pccMailDt.UpdateTime.ToString().PadLeft(9, '0').Substring(0, 6);
                time2 = time2Temp.Insert(2, ":").Insert(5, ":");
            }
            messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][UPDATEDATETIME_TITLE] = time1 + " " + time2;
            messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][INQCONDITION_TITLEB] = inqCondition;
            if (!string.IsNullOrEmpty(inqCondition))
            {
                if (this._messageDelHTable.ContainsKey(inqCondition))
                {
                    this._messageDelHTable.Remove(inqCondition);
                }           
                this._messageDelHTable.Add(inqCondition, pccMailDt);
             }

        }

        /// <summary>
        ///�����Ӑ�{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����Ӑ�{�^�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void NextCustomerProc()
        {
            //�O���b�hB�̃J�[�\����1���Ɉړ�,���[�������ꗗ���X�V����B
            if (this.uGrid_Customer != null && this.uGrid_Customer.Rows.Count > 0 && this.uGrid_Customer.ActiveRow != null)
            {
                int rowIndex = this.uGrid_Customer.ActiveRow.Index;
                if (rowIndex != this.uGrid_Customer.Rows.Count - 1)
                {
                    this.uGrid_Customer.Rows[this._customerDataIndex].Activated = false;
                    this.uGrid_Customer.Selected.Rows.Clear();
                    this._customerDataIndex = rowIndex + 1;
                    this.uGrid_Customer.Rows[this._customerDataIndex].Activate();
                    this.uGrid_Customer.Rows[this._customerDataIndex].Selected = true;
                    //��ʋ����䏈��
                    ScreenInputPermissionControl();
                }
            }
        }

        /// <summary>
        ///�O���Ӑ�{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���Ӑ�{�^�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PreCustomerProc()
        {
            //�O���b�hB�̃J�[�\����1���Ɉړ�,���[�������ꗗ���X�V����B
            if (this.uGrid_Customer != null && this.uGrid_Customer.Rows.Count > 0 && this.uGrid_Customer.ActiveRow != null)
            {
                int rowIndex = this.uGrid_Customer.ActiveRow.Index;
                if (rowIndex > 0)
                {
                    this.uGrid_Customer.Rows[this._customerDataIndex].Activated = false;
                    this.uGrid_Customer.Selected.Rows.Clear();
                    this._customerDataIndex = rowIndex -1;
                    this.uGrid_Customer.Rows[this._customerDataIndex].Activate();
                    this.uGrid_Customer.Rows[this._customerDataIndex].Selected = true;
                    //��ʋ����䏈��
                    ScreenInputPermissionControl();
                }
            }
        }

        /// <summary>
        ///���\���{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���\���{�^�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void NextShowProc()
        {
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && this.uGrid_MessageDel.ActiveRow != null)
            {
                int rowIndex = this.uGrid_MessageDel.ActiveRow.Index;
                string inqCondition = string.Empty;
                if (rowIndex != this.uGrid_MessageDel.Rows.Count - 1)
                {
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = false;
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activated = false;
                    this._messageDelDataIndex = rowIndex;
                    if (uCheckEditor_DeleteShow.Checked == false)
                    {
                        for (int i = rowIndex + 1; i < this.uGrid_MessageDel.Rows.Count; i++)
                        {
                            inqCondition = (string)this.uGrid_MessageDel.Rows[i].Cells[INQCONDITION_TITLEA].Value;

                            PccMailDt pccMailDtDl = ((PccMailDt)this._messageDelHTable[inqCondition]).Clone();
                            if (pccMailDtDl.LogicalDeleteCode == 0)
                            {
                                this._messageDelDataIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        this._messageDelDataIndex = rowIndex + 1;
                    }
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                }
            }
        }

        /// <summary>
        ///�O�\���{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O�\���{�^�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PreShowProc()
        {
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && this.uGrid_MessageDel.ActiveRow != null)
            {
                int rowIndex = this.uGrid_MessageDel.ActiveRow.Index;
                string inqCondition = string.Empty;
                if (rowIndex > 0)
                {
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = false;
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activated = false;
                    this._messageDelDataIndex = rowIndex;
                    if (uCheckEditor_DeleteShow.Checked == false)
                    {
                        for (int i = rowIndex - 1; i >= 0; i--)
                        {
                            inqCondition = (string)this.uGrid_MessageDel.Rows[i].Cells[INQCONDITION_TITLEA].Value;

                            PccMailDt pccMailDtDl = ((PccMailDt)this._messageDelHTable[inqCondition]).Clone();
                            if (pccMailDtDl.LogicalDeleteCode == 0)
                            {
                                this._messageDelDataIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        this._messageDelDataIndex = rowIndex - 1;
                    }
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                }
            }
        }

        /// <summary>
        ///�폜�{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �폜�{�^�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void DeleteProc()
        {
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && this.uGrid_MessageDel.ActiveRow != null)
            {
                DialogResult result = TMsgDisp.Show(
               this, 								// �e�E�B���h�E�t�H�[��
               emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
               ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
               "�f�[�^���폜���܂��B" + "\r\n" +
               "��낵���ł����H", 				// �\�����郁�b�Z�[�W
               0, 									// �X�e�[�^�X�l
               MessageBoxButtons.YesNo,
               MessageBoxDefaultButton.Button2);	// �\������{�^��

                if (result != DialogResult.Yes)
                {
                    return;
                }
                //�I�������̍s
                int rowIndex = this.uGrid_MessageDel.ActiveRow.Index;
                this._messageDelDataIndex = rowIndex;
                string inqCondition = string.Empty;
                inqCondition = (string)this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Cells[INQCONDITION_TITLEA].Value;

                PccMailDt pccMailDt = ((PccMailDt)this._messageDelHTable[inqCondition]).Clone();
                PccMailDt pccMailDtOld = pccMailDt;
                int status = 0;
                if (pccMailDt.LogicalDeleteCode == 0)
                {
                    //�I�𒆂̃��[����_���폜
                    status = this._pccMailDtAcs.LogicalDelete(ref pccMailDt);
                }
                else
                {
                    //�I�𒆂̃��[�����_���폜���̏ꍇ�A�����폜
                    status = this._pccMailDtAcs.Delete(ref pccMailDt);
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            string inqConditionFather = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                                + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd();
                            if (this._pccMailDtDic != null && this._pccMailDtDic.ContainsKey(inqConditionFather))
                            {
                                //DataSet�X�V
                                Dictionary<string,  PccMailDt> pccMailDtDicOld = this._pccMailDtDic[inqConditionFather];
                                if (pccMailDtDicOld != null && pccMailDtDicOld.ContainsKey(inqCondition))
                                {
                                    pccMailDtDicOld.Remove(inqCondition);
                                }
                                if (pccMailDtOld.LogicalDeleteCode == 0)
                                {
                                    pccMailDtDicOld.Add(inqCondition, pccMailDt);
                                    this.PccMailDtToDataSet(this._messageDelAllDateSet, pccMailDt, rowIndex);
                                    if (!this.uCheckEditor_DeleteShow.Checked)
                                    {
                                        // DataSet�X�V
                                        this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows[rowIndex].Delete();

                                        if (this._messageDelDataIndex > 0)
                                        {
                                            this._messageDelDataIndex = this._messageDelDataIndex - 1;
                                            this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                                            this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                                            this._showDeleBtFlg = true;
                                            this.uGrid_MessageDel.DataSource = this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                                        }
                                        else
                                        {
                                            this._messageDelDataIndex = -1;
                                            //���[���\���X�V
                                            this.tEdit_PccMailDocCnts.Text = string.Empty;
                                            this.tEdit_PccMailTitle.Text = string.Empty;
                                        }
                                        if (this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count == 0)
                                        {
                                            this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                                            //���[���\���X�V
                                            this.tEdit_PccMailDocCnts.Text = string.Empty;
                                            this.tEdit_PccMailTitle.Text = string.Empty;
                                            this._showDeleBtFlg = false;
                                        }
                                    }
                                    else
                                    {
                                        //_messageDelDateSet�X�V
                                        if (_messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count > 0)
                                        {
                                            for (int rowIndexDel = 0; rowIndexDel < _messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count; rowIndexDel++)
                                            {
                                                String guidInqCondition = (string)_messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows[rowIndexDel][INQCONDITION_TITLEB];
                                                if (inqCondition.Equals(guidInqCondition))
                                                {
                                                    _messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows[rowIndexDel].Delete();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // _messageDelAllDateSetDataSet�X�V
                                    this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[rowIndex].Delete();
                                    // �n�b�V���e�[�u������폜���܂�
                                    if (this._messageDelHTable.ContainsKey(inqCondition) == true)
                                    {
                                        this._messageDelHTable.Remove(inqCondition);
                                    }
                                    
                                    if (this._messageDelDataIndex > 0)
                                    {
                                        _showDeleBtFlg = true;
                                        this._messageDelDataIndex = this._messageDelDataIndex - 1;
                                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                                        this.uGrid_MessageDel.DataSource = this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                                    }
                                    else
                                    {
                                        this._messageDelDataIndex = -1;
                                        //���[���\���X�V
                                        this.tEdit_PccMailDocCnts.Text = string.Empty;
                                        this.tEdit_PccMailTitle.Text = string.Empty;
                                    }
                                    if (this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count == 0)
                                    {
                                        _showDeleBtFlg = false;
                                        this._deleteButton.SharedProps.Enabled = _showDeleBtFlg;
                                        this._preShowButton.SharedProps.Enabled = _showDeleBtFlg;
                                        this._nextShowButton.SharedProps.Enabled = _showDeleBtFlg;
                                        this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                                        //���[���\���X�V
                                        this.tEdit_PccMailDocCnts.Text = string.Empty;
                                        this.tEdit_PccMailTitle.Text = string.Empty;
                                    }
                                }
                                this._pccMailDtDic.Remove(inqConditionFather);
                                this._pccMailDtDic.Add(inqConditionFather, pccMailDtDicOld);
                            }

                           break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            // �r������
                            ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccMailDtAcs);
                            // �N���X�f�[�^�Z�b�g�W�J����
                            break;
                        }
                    case -2:
                        {
                            //���Ɛݒ�Ŏg�p��
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                ASSEMBLY_ID,
                                "���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
                                status,
                                MessageBoxButtons.OK);
                            this.Hide();
                            break;
                        }

                    default:
                        {
                            TMsgDisp.Show(
                                this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                this.Text,							// �v���O��������
                                "Delete",							// ��������
                                TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                                ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                                status,								// �X�e�[�^�X�l
                                this._pccMailDtAcs,					// �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				// �\������{�^��
                                MessageBoxDefaultButton.Button1);	// �����\���{�^��
                            // �N���X�f�[�^�Z�b�g�W�J����
                            break;
                            
                        }
                }
                ScreenInputPermissionControl();
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_800_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_801_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }
        }

        /// <summary>
        ///�V�K�쐬�{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�쐬�{�^�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void NewProc()
        {
            PMPCC01001UB pMPCC01001UB = new PMPCC01001UB();
            pMPCC01001UB.ShowDialog();
            DialogResult dialogResult = pMPCC01001UB.DialogResult;
            if (DialogResult.OK == dialogResult)
            {
                this.GetPccMailDtDic();
            }
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.10.14</br>
        /// </remarks>
        private bool ScreenInputCheck(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;
            //�G���[�������b�Z�[�W
            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            const string ct_InputPlease = "����͂��Ă��������B";
            //���Y���t�͈̓`�F�b�N
            DateGetAcs.CheckDateRangeResult cdrResult;

            if (CallCheckDateRange(out cdrResult, ref tDateEdit_UpdateDateSt, ref tDateEdit_UpdateDateEd) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("�J�n��{0}", ct_InputError);
                            errControl = this.tDateEdit_UpdateDateSt;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            message = string.Format("�J�n��{0}", ct_InputPlease);
                            errControl = this.tDateEdit_UpdateDateSt;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("�I����{0}", ct_InputError);
                            errControl = this.tDateEdit_UpdateDateEd;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            message = string.Format("�I����{0}", ct_InputPlease);
                            errControl = this.tDateEdit_UpdateDateEd;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("���t{0}", ct_RangeError);
                            errControl = this.tDateEdit_UpdateDateEd;
                            result = false;
                        }
                        break;
                }
                return result;
            }
            return true;
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo���i�����͑ΏۊO�j
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_Date"></param>
        /// <param name="tde_Ed_Date"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_Date, ref TDateEdit tde_Ed_Date)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_Date, ref tde_Ed_Date, false);

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        #endregion
    }
}