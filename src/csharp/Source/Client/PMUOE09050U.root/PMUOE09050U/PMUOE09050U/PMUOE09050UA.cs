//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : UOE�ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : UOE�ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : caowj
// �� �� ��  2010/07/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// UOE�ڑ�����}�X�^�����e�i���X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE�ڑ�����}�X�^���s���܂�
    ///					: IMasterMaintenanceSingleType���������Ă��܂�</br>
    /// <br>Programer	: caowj</br>
    /// <br>Date		: 2010/07/27</br>
    /// <br></br>
    /// <br>Update Note : </br>
    /// </remarks>
    public class PMUOE09050UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel SocketCommPort_Label;
        private Infragistics.Win.Misc.UltraLabel ReceiveComputerNm_Label;
        private Infragistics.Win.Misc.UltraLabel ClientTimeOut_Label;
        private Infragistics.Win.Misc.UltraLabel CashRegisterNo_Label;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Close_Button;
        private Broadleaf.Library.Windows.Forms.TEdit SocketCommPort_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit ReceiveComputerNm_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit CashRegisterNo_tEdit;
        private System.Windows.Forms.Timer timer1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private DataSet Bind_DataSet;
        private Infragistics.Win.Misc.UltraLabel CommAssemblyId_Label;
        private TEdit CommAssemblyId_tEdit;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private TEdit ClientTimeOut_tEdit;
        private Infragistics.Win.Misc.UltraLabel unit_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabe11;
        private System.ComponentModel.IContainer components;
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// PMUOE09050U�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: UOE�ڑ�����}�X�^�R���X�g���N�^�ł�</br>
        /// <br>Programer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        public PMUOE09050UA()
        {
            InitializeComponent();

            // DataSet����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            this._nextData = false;
            this._totalCount = 0;

            // uOEConnectInfo�N���X
            this._uOEConnectInfo = new UOEConnectInfo();
            // uOEConnectInfo�N���X�A�N�Z�X�N���X
            this._uOEConnectInfoAcs = new UOEConnectInfoAcs();

            this._uOEConnectInfoTable = new Hashtable();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ����\�t���O��ݒ肵�܂��B
            // Frame�̈���{�^���̕\����\���̐���Ɏg�p���܂��B
            this._canPrint = false;

            this._indexBuf = -2;
        }
        #endregion

        #region Private Member
        /// <summary>
        /// �O���[�o���ϐ��E�萔�錾
        /// </summary>
        private UOEConnectInfo _uOEConnectInfo;
        private UOEConnectInfoAcs _uOEConnectInfoAcs;
        private UOEConnectInfo _uOEConnectInfoClone; // �f�[�^��r�p        
        private string _enterpriseCode;

        //HashTable
        private Hashtable _uOEConnectInfoTable;

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private bool _nextData;
        //����
        private int _totalCount;

        private const string ASSEMBLY_ID = "PMUOE09050U";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";
        private const string VIEW_COMMASSEMBLYID = "�ʐM�A�Z���u��ID";
        private const string VIEW_CASHREGISTERNO = "�[���ԍ�";
        private const string VIEW_SOCKETCOMMPORT = "�ʐMPORT�ԍ�";
        private const string VIEW_RECEIVECOMPUTERNM = "�ڑ���R���s���[�^��";
        private const string VIEW_CLIENTTIMEOUT = "�N���C�A���g�^�C���A�E�g";

        //GUID
        private const string VIEW_FILEHEADERGUID = "Guid";

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        private int _indexBuf;

        #endregion

        #region Dispose
        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h

        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE09050UA));
            this.SocketCommPort_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ReceiveComputerNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ClientTimeOut_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CashRegisterNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.SocketCommPort_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ReceiveComputerNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CashRegisterNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.CommAssemblyId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CommAssemblyId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ClientTimeOut_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.unit_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabe11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.SocketCommPort_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveComputerNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommAssemblyId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTimeOut_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // SocketCommPort_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.SocketCommPort_Label.Appearance = appearance1;
            this.SocketCommPort_Label.Location = new System.Drawing.Point(12, 135);
            this.SocketCommPort_Label.Name = "SocketCommPort_Label";
            this.SocketCommPort_Label.Size = new System.Drawing.Size(125, 23);
            this.SocketCommPort_Label.TabIndex = 7;
            this.SocketCommPort_Label.Tag = "8";
            this.SocketCommPort_Label.Text = "�ʐM�|�[�g�ԍ�";
            // 
            // ReceiveComputerNm_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.ReceiveComputerNm_Label.Appearance = appearance2;
            this.ReceiveComputerNm_Label.Location = new System.Drawing.Point(12, 171);
            this.ReceiveComputerNm_Label.Name = "ReceiveComputerNm_Label";
            this.ReceiveComputerNm_Label.Size = new System.Drawing.Size(170, 23);
            this.ReceiveComputerNm_Label.TabIndex = 13;
            this.ReceiveComputerNm_Label.Tag = "13";
            this.ReceiveComputerNm_Label.Text = "�ڑ���R���s���[�^��";
            // 
            // ClientTimeOut_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ClientTimeOut_Label.Appearance = appearance3;
            this.ClientTimeOut_Label.Location = new System.Drawing.Point(12, 207);
            this.ClientTimeOut_Label.Name = "ClientTimeOut_Label";
            this.ClientTimeOut_Label.Size = new System.Drawing.Size(202, 23);
            this.ClientTimeOut_Label.TabIndex = 14;
            this.ClientTimeOut_Label.Tag = "14";
            this.ClientTimeOut_Label.Text = "�N���C�A���g�^�C���A�E�g";
            // 
            // CashRegisterNo_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.CashRegisterNo_Label.Appearance = appearance6;
            this.CashRegisterNo_Label.Location = new System.Drawing.Point(12, 91);
            this.CashRegisterNo_Label.Name = "CashRegisterNo_Label";
            this.CashRegisterNo_Label.Size = new System.Drawing.Size(79, 23);
            this.CashRegisterNo_Label.TabIndex = 17;
            this.CashRegisterNo_Label.Tag = "17";
            this.CashRegisterNo_Label.Text = "�[���ԍ�";
            // 
            // Mode_Label
            // 
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance7;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label.Location = new System.Drawing.Point(442, 2);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 18;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 289);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(554, 23);
            this.ultraStatusBar1.TabIndex = 21;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Close_Button
            // 
            this.Close_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Close_Button.Location = new System.Drawing.Point(417, 243);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(125, 34);
            this.Close_Button.TabIndex = 9;
            this.Close_Button.Text = "����(&X)";
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // SocketCommPort_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlignAsString = "Right";
            this.SocketCommPort_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            this.SocketCommPort_tEdit.Appearance = appearance9;
            this.SocketCommPort_tEdit.AutoSelect = true;
            this.SocketCommPort_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SocketCommPort_tEdit.DataText = "";
            this.SocketCommPort_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SocketCommPort_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SocketCommPort_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SocketCommPort_tEdit.Location = new System.Drawing.Point(220, 135);
            this.SocketCommPort_tEdit.MaxLength = 6;
            this.SocketCommPort_tEdit.Name = "SocketCommPort_tEdit";
            this.SocketCommPort_tEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SocketCommPort_tEdit.Size = new System.Drawing.Size(67, 24);
            this.SocketCommPort_tEdit.TabIndex = 3;
            // 
            // ReceiveComputerNm_tEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Left";
            this.ReceiveComputerNm_tEdit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            this.ReceiveComputerNm_tEdit.Appearance = appearance5;
            this.ReceiveComputerNm_tEdit.AutoSelect = true;
            this.ReceiveComputerNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ReceiveComputerNm_tEdit.DataText = "";
            this.ReceiveComputerNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ReceiveComputerNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.ReceiveComputerNm_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ReceiveComputerNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ReceiveComputerNm_tEdit.Location = new System.Drawing.Point(220, 171);
            this.ReceiveComputerNm_tEdit.MaxLength = 20;
            this.ReceiveComputerNm_tEdit.Name = "ReceiveComputerNm_tEdit";
            this.ReceiveComputerNm_tEdit.Size = new System.Drawing.Size(179, 24);
            this.ReceiveComputerNm_tEdit.TabIndex = 4;
            // 
            // CashRegisterNo_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.TextHAlignAsString = "Right";
            this.CashRegisterNo_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Right";
            this.CashRegisterNo_tEdit.Appearance = appearance19;
            this.CashRegisterNo_tEdit.AutoSelect = true;
            this.CashRegisterNo_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CashRegisterNo_tEdit.DataText = "";
            this.CashRegisterNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CashRegisterNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 32, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CashRegisterNo_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CashRegisterNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CashRegisterNo_tEdit.Location = new System.Drawing.Point(220, 91);
            this.CashRegisterNo_tEdit.MaxLength = 3;
            this.CashRegisterNo_tEdit.Name = "CashRegisterNo_tEdit";
            this.CashRegisterNo_tEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CashRegisterNo_tEdit.Size = new System.Drawing.Size(44, 24);
            this.CashRegisterNo_tEdit.TabIndex = 2;
            this.CashRegisterNo_tEdit.Leave += new System.EventHandler(this.CashRegisterNo_tEdit_Leave);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // CommAssemblyId_Label
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.CommAssemblyId_Label.Appearance = appearance12;
            this.CommAssemblyId_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CommAssemblyId_Label.Location = new System.Drawing.Point(12, 47);
            this.CommAssemblyId_Label.Name = "CommAssemblyId_Label";
            this.CommAssemblyId_Label.Size = new System.Drawing.Size(135, 23);
            this.CommAssemblyId_Label.TabIndex = 118;
            this.CommAssemblyId_Label.Text = "�ʐM�A�Z���u��ID";
            // 
            // CommAssemblyId_tEdit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Right";
            this.CommAssemblyId_tEdit.ActiveAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            this.CommAssemblyId_tEdit.Appearance = appearance21;
            this.CommAssemblyId_tEdit.AutoSelect = true;
            this.CommAssemblyId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CommAssemblyId_tEdit.DataText = "";
            this.CommAssemblyId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CommAssemblyId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CommAssemblyId_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CommAssemblyId_tEdit.Location = new System.Drawing.Point(220, 47);
            this.CommAssemblyId_tEdit.MaxLength = 4;
            this.CommAssemblyId_tEdit.Name = "CommAssemblyId_tEdit";
            this.CommAssemblyId_tEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CommAssemblyId_tEdit.Size = new System.Drawing.Size(51, 24);
            this.CommAssemblyId_tEdit.TabIndex = 1;
            this.CommAssemblyId_tEdit.Leave += new System.EventHandler(this.CommAssemblyId_tEdit_Leave);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(163, 243);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Revive_Button.Location = new System.Drawing.Point(290, 243);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 8;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(290, 243);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 7;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ClientTimeOut_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Right";
            this.ClientTimeOut_tEdit.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.ClientTimeOut_tEdit.Appearance = appearance11;
            this.ClientTimeOut_tEdit.AutoSelect = true;
            this.ClientTimeOut_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ClientTimeOut_tEdit.DataText = "";
            this.ClientTimeOut_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ClientTimeOut_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.ClientTimeOut_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ClientTimeOut_tEdit.Location = new System.Drawing.Point(220, 207);
            this.ClientTimeOut_tEdit.MaxLength = 6;
            this.ClientTimeOut_tEdit.Name = "ClientTimeOut_tEdit";
            this.ClientTimeOut_tEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClientTimeOut_tEdit.Size = new System.Drawing.Size(67, 24);
            this.ClientTimeOut_tEdit.TabIndex = 5;
            // 
            // unit_Label
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.unit_Label.Appearance = appearance26;
            this.unit_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.unit_Label.Location = new System.Drawing.Point(294, 208);
            this.unit_Label.Name = "unit_Label";
            this.unit_Label.Size = new System.Drawing.Size(80, 23);
            this.unit_Label.TabIndex = 120;
            this.unit_Label.Text = "1/1000�b";
            // 
            // ultraLabe11
            // 
            this.ultraLabe11.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabe11.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabe11.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabe11.Location = new System.Drawing.Point(12, 81);
            this.ultraLabe11.Name = "ultraLabe11";
            this.ultraLabe11.Size = new System.Drawing.Size(530, 3);
            this.ultraLabe11.TabIndex = 121;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(12, 125);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(530, 3);
            this.ultraLabel2.TabIndex = 122;
            // 
            // PMUOE09050UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(554, 312);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabe11);
            this.Controls.Add(this.unit_Label);
            this.Controls.Add(this.ClientTimeOut_tEdit);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.CommAssemblyId_tEdit);
            this.Controls.Add(this.CommAssemblyId_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SocketCommPort_tEdit);
            this.Controls.Add(this.ReceiveComputerNm_tEdit);
            this.Controls.Add(this.CashRegisterNo_tEdit);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.CashRegisterNo_Label);
            this.Controls.Add(this.ClientTimeOut_Label);
            this.Controls.Add(this.ReceiveComputerNm_Label);
            this.Controls.Add(this.SocketCommPort_Label);
            this.Controls.Add(this.Close_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PMUOE09050UA";
            this.Text = "UOE�ڑ����}�X�^";
            this.Load += new System.EventHandler(this.PMUOE09050UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMUOE09050UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMUOE09050UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.SocketCommPort_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveComputerNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommAssemblyId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTimeOut_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Main Entry Point
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMUOE09050UA());
        }
        #endregion

        #region IMasterMaintenanceMultiType�����o
        #region -- Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Properties --
        /*----------------------------------------------------------------------------------*/
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾���܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        #endregion

        #region -- Public Method --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList uOEConnectInfoList = null;

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._uOEConnectInfoAcs.Search(out uOEConnectInfoList, this._enterpriseCode);

                this._totalCount = uOEConnectInfoList.Count;
            }
            else
            {
                status = this._uOEConnectInfoAcs.SearchAll(
                    out uOEConnectInfoList,
                    out this._totalCount,
                    out this._nextData,
                    this._enterpriseCode,
                    readCount,
                    this._uOEConnectInfo);
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (uOEConnectInfoList.Count > 0)
                        {
                            // �ŏI��UOE�ڑ�����}�X�^���I�u�W�F�N�g��ޔ�����
                            this._uOEConnectInfo = ((UOEConnectInfo)uOEConnectInfoList[uOEConnectInfoList.Count - 1]).Clone();
                        }
                        int index = 0;
                        // �ǂݍ��񂾃C���X�^���X
                        foreach (UOEConnectInfo uOEConnectInfo in uOEConnectInfoList)
                        {
                            // DataSet�ɃZ�b�g����
                            UOEConnectInfoToDataSet(uOEConnectInfo.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �S���ǂݍ��݊����̏ꍇ�́A�������Ȃ�
                        break;
                    }
                default:
                    {
                        // �T�[�`
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "UOE�ڑ�����}�X�^�����e�i���X", // �v���O��������
                            "Search", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._uOEConnectInfoAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }
            totalCount = this._totalCount;
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            int status = 0;
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Delete()
        {
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            UOEConnectInfo uOEConnectInfo = (UOEConnectInfo)this._uOEConnectInfoTable[guid];

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // UOE�ڑ�����}�X�^���_���폜����
            status = this._uOEConnectInfoAcs.LogicalDelete(ref uOEConnectInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._uOEConnectInfoAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // UOE�ڑ�����}�X�^���N���X�f�[�^�Z�b�g�W�J����
            UOEConnectInfoToDataSet(uOEConnectInfo.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Print()
        {
            // ����p�A�Z���u�������[�h����i�������j
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            //�폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            //�ʐM�A�Z���u��ID
            appearanceTable.Add(VIEW_COMMASSEMBLYID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //�[���ԍ�
            appearanceTable.Add(VIEW_CASHREGISTERNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //�ʐM�|�[�g�ԍ�
            appearanceTable.Add(VIEW_SOCKETCOMMPORT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //�ڑ���R���s���[�^��
            appearanceTable.Add(VIEW_RECEIVECOMPUTERNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�N���C�A���g�^�C���A�E�g
            appearanceTable.Add(VIEW_CLIENTTIMEOUT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }
        #endregion
        #endregion

        #region Private Method
        /// <summary>
        /// UOE�ڑ�����}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="uOEConnectInfo">UOE�ڑ�����}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����}�X�^�����e�i���X�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void UOEConnectInfoToDataSet(UOEConnectInfo uOEConnectInfo, int index)
        {
            // index�̒l��DataSet�̊����s�������Ă��Ȃ�������
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

                // index�ɍs�̍ŏI�s�ԍ����Z�b�g����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }
            if (uOEConnectInfo.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = uOEConnectInfo.UpdateDateTimeJpInFormal;
            }

            // �ʐM�A�Z���u��ID
            if (uOEConnectInfo.CommAssemblyId.Trim().Length < 4)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMASSEMBLYID] = uOEConnectInfo.CommAssemblyId.Trim().PadLeft(4, '0');
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMASSEMBLYID] = uOEConnectInfo.CommAssemblyId.Trim();
            }
            // �[���ԍ�
            if (uOEConnectInfo.CashRegisterNo.ToString().Length < 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNO] = uOEConnectInfo.CashRegisterNo.ToString().PadLeft(3, '0');
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNO] = uOEConnectInfo.CashRegisterNo.ToString();
            }
            // �ʐM�|�[�g�ԍ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SOCKETCOMMPORT] = uOEConnectInfo.SocketCommPort.ToString();
            // �ڑ���R���s���[�^��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RECEIVECOMPUTERNM] = uOEConnectInfo.ReceiveComputerNm.Trim();
            // �N���C�A���g�^�C���A�E�g
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CLIENTTIMEOUT] = uOEConnectInfo.ClientTimeOut.ToString();
            //GUID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = uOEConnectInfo.FileHeaderGuid;

            // �C���X�^���X�e�[�u���ɂ��Z�b�g����
            if (this._uOEConnectInfoTable.ContainsKey(uOEConnectInfo.FileHeaderGuid) == true)
            {
                this._uOEConnectInfoTable.Remove(uOEConnectInfo.FileHeaderGuid);
            }
            this._uOEConnectInfoTable.Add(uOEConnectInfo.FileHeaderGuid, uOEConnectInfo);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable uOEConnectInfoTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            uOEConnectInfoTable.Columns.Add(DELETE_DATE, typeof(string));               //�폜��
            uOEConnectInfoTable.Columns.Add(VIEW_COMMASSEMBLYID, typeof(string));       //�ʐM�A�Z���u��ID
            uOEConnectInfoTable.Columns.Add(VIEW_CASHREGISTERNO, typeof(string));          //�[���ԍ�
            uOEConnectInfoTable.Columns.Add(VIEW_SOCKETCOMMPORT, typeof(int));          //�ʐM�|�[�g�ԍ�
            uOEConnectInfoTable.Columns.Add(VIEW_RECEIVECOMPUTERNM, typeof(string));    //�ڑ���R���s���[�^��
            uOEConnectInfoTable.Columns.Add(VIEW_CLIENTTIMEOUT, typeof(int));           //�N���C�A���g�^�C���A�E�g
            uOEConnectInfoTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));         //GUID

            this.Bind_DataSet.Tables.Add(uOEConnectInfoTable);
        }

        /// <summary>
        ///	��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // ��ʂ����������܂�
            EditClear();
        }

        /// <summary>
        /// �G�f�B�b�g�{�b�N�X����������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ����������܂�</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// </remarks>
        private void EditClear()
        {
            this.CommAssemblyId_tEdit.Text = string.Empty;              //�ʐM�A�Z���u��ID
            this.CashRegisterNo_tEdit.Text = string.Empty;				// �[���ԍ�
            this.SocketCommPort_tEdit.Text = string.Empty;				// �ʐM�|�[�g�ԍ�
            this.ReceiveComputerNm_tEdit.Text = string.Empty;		    // �ڑ���R���s���[�^��
            this.ClientTimeOut_tEdit.Text = string.Empty;				// �N���C�A���g�^�C���A�E�g
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                //_dataIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �ʐM�A�Z���u��ID�ݒ�
                this.CommAssemblyId_tEdit.Focus();
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                UOEConnectInfo uOEConnectInfo = (UOEConnectInfo)this._uOEConnectInfoTable[guid];

                // ��ʓW�J����
                UOEConnectInfoToScreen(uOEConnectInfo);

                if (uOEConnectInfo.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �N���[���쐬
                    this._uOEConnectInfoClone = uOEConnectInfo.Clone();
                    // ��ʏ��UOE�ڑ�����}�X�^�����e�i���X�N���X�i�[����
                    DispToUOEConnectInfo(ref this._uOEConnectInfoClone);

                    this.SocketCommPort_tEdit.Focus();
                    this.SocketCommPort_tEdit.SelectAll();
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// ��ʏ��UOE�ڑ�����}�X�^�����e�i���X�N���X�i�[����
        /// </summary>
        /// <param name="uOEConnectInfo">UOE�ڑ�����}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�UOE�ڑ�����}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void DispToUOEConnectInfo(ref UOEConnectInfo uOEConnectInfo)
        {
            if (uOEConnectInfo == null)
            {
                // �V�K�̏ꍇ
                uOEConnectInfo = new UOEConnectInfo();
            }

            // �e���ڂ̃Z�b�g
            // ��ƃR�[�h
            uOEConnectInfo.EnterpriseCode = this._enterpriseCode;
            // �ʐM�A�Z���u��ID
            uOEConnectInfo.CommAssemblyId = this.CommAssemblyId_tEdit.Text.Trim();
            // �[���ԍ�
            int cashRegisterNo = 0;
            if (int.TryParse(this.CashRegisterNo_tEdit.Text.Trim(), out cashRegisterNo))
            {
                uOEConnectInfo.CashRegisterNo = cashRegisterNo;
            }
            else
            {
                uOEConnectInfo.CashRegisterNo = 1000;            //�[���ԍ��̍ő包���{�P��ݒ�
            }
            // �ʐM�|�[�g�ԍ�
            int socketCommPort = 0;
            if (int.TryParse(this.SocketCommPort_tEdit.Text.Trim(), out socketCommPort))
            {
                uOEConnectInfo.SocketCommPort = socketCommPort;
            }
            else
            {
                uOEConnectInfo.SocketCommPort = 1000000;         //�ʐM�|�[�g�ԍ��̍ő包���{�P��ݒ�
            }
            // �ڑ���R���s���[�^��
            uOEConnectInfo.ReceiveComputerNm = this.ReceiveComputerNm_tEdit.Text.Trim();
            // �N���C�A���g�^�C���A�E�g
            int clientTimeOut = 0;
            if (int.TryParse(this.ClientTimeOut_tEdit.Text.Trim(), out clientTimeOut))
            {
                uOEConnectInfo.ClientTimeOut = clientTimeOut;
            }
            else
            {
                uOEConnectInfo.ClientTimeOut = 1000000;         //�N���C�A���g�^�C���A�E�g�̍ő包���{�P��ݒ�
            }
        }

        /// <summary>
        /// UOE�ڑ�����}�X�^�����e�i���X�N���X��ʓW�J����
        /// </summary>
        /// <param name="uOEConnectInfo">UOE�ڑ�����}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����}�X�^�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void UOEConnectInfoToScreen(UOEConnectInfo uOEConnectInfo)
        {
            // �e���ڂ̃Z�b�g
            // �ʐM�A�Z���u��ID
            this.CommAssemblyId_tEdit.Text = uOEConnectInfo.CommAssemblyId.Trim().PadLeft(4, '0');
            // �[���ԍ�
            this.CashRegisterNo_tEdit.Text = uOEConnectInfo.CashRegisterNo.ToString().PadLeft(3, '0');
            // �ʐM�|�[�g�ԍ�
            this.SocketCommPort_tEdit.Text = uOEConnectInfo.SocketCommPort.ToString();
            // �ڑ���R���s���[�^��
            this.ReceiveComputerNm_tEdit.Text = uOEConnectInfo.ReceiveComputerNm;
            // �N���C�A���g�^�C���A�E�g
            this.ClientTimeOut_tEdit.Text = uOEConnectInfo.ClientTimeOut.ToString();
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    // ���͍���
                    this.CommAssemblyId_tEdit.Enabled = true;
                    this.CashRegisterNo_tEdit.Enabled = true;
                    this.SocketCommPort_tEdit.Enabled = true;
                    this.ReceiveComputerNm_tEdit.Enabled = true;
                    this.ClientTimeOut_tEdit.Enabled = true;

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    break;
                case UPDATE_MODE:
                    // ���͍���
                    this.CommAssemblyId_tEdit.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = false;
                    this.SocketCommPort_tEdit.Enabled = true;
                    this.ReceiveComputerNm_tEdit.Enabled = true;
                    this.ClientTimeOut_tEdit.Enabled = true;

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    break;
                case DELETE_MODE:
                    // ���͍���
                    this.CommAssemblyId_tEdit.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = false;
                    this.SocketCommPort_tEdit.Enabled = false;
                    this.ReceiveComputerNm_tEdit.Enabled = false;
                    this.ClientTimeOut_tEdit.Enabled = false;

                    // �{�^��
                    this.Ok_Button.Visible = false;
                    this.Close_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// OK_Button_Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �ۑ��{�^���N���b�N�C�x���g</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �ۑ��O�f�[�^�`�F�b�N
            if (!IsValueCheck())
            {
                // �`�F�b�N�m�f�̏ꍇ�����I��
                return;
            }
            // �f�[�^�ۑ�
            if (!IsSaveProc())
            {
                // �ۑ��Ɏ��s�����Ƃ��͏����I��
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

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
        /// �ۑ��O�f�[�^�`�F�b�N���\�b�h
        /// </summary>
        /// <returns>�`�F�b�N���ʁotrue : �`�F�b�N�n�j | false : �`�F�b�N�m�f�p</returns>
        /// <remarks>
        /// <br>Note		: �ۑ��O�f�[�^�`�F�b�N���\�b�h</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private bool IsValueCheck()
        {
            string errorMsg = string.Empty;	// �G���[���b�Z�[�W�i�[
            int setFocusNum = 0;	// �t�H�[�J�X�Z�b�g���邽�߂̋敪

            try
            {
                // �G���[�`�F�b�N
                setFocusNum = CheckError(ref errorMsg);
            }
            finally
            {
                if (setFocusNum == 0)
                {
                    // ����
                }
                else
                {
                    // �x�����b�Z�[�W�̕\��
                    TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        ASSEMBLY_ID,							// �A�Z���u��ID
                        errorMsg,	                        �@�@// �\�����郁�b�Z�[�W
                        0,   									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��

                    // �t�H�[�J�X�Z�b�g
                    SetFocusToComponent(setFocusNum);
                }
            }
            if (setFocusNum == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �f�[�^�ۑ�����
        /// </summary>
        /// <returns>Status�o�����Ftrue �b ���s�Ffalse�p</returns>
        /// <remarks>
        /// <br>Note		: �f�[�^�̕ۑ��������s���܂��B</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private bool IsSaveProc()
        {
            UOEConnectInfo uOEConnectInfo = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                uOEConnectInfo = ((UOEConnectInfo)this._uOEConnectInfoTable[guid]).Clone();
            }
            else
            {
                uOEConnectInfo = new UOEConnectInfo();
            }

            this.DispToUOEConnectInfo(ref uOEConnectInfo);

            int status = this._uOEConnectInfoAcs.Write(ref uOEConnectInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�f�[�^�����ɑ��݂��Ă��܂��B",		// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��

                        this.CommAssemblyId_tEdit.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "UOE�ڑ�����}�X�^",							// �v���O��������
                            "IsSaveProc",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._uOEConnectInfoAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
            }

            // DataSet�W�J����
            UOEConnectInfoToDataSet(uOEConnectInfo, this.DataIndex);

            return true;

        }

        /// <summary>
        /// �G���[�`�F�b�N����
        /// </summary>
        /// <param name="errorMsg">�G���[���b�Z�[�W�i�[�p�ϐ��i�󂯎�莞�͋�j</param>
        /// <returns>�t�H�[�J�X���Z�b�g����R���|�[�l���g</returns>
        /// <remarks>
        /// <br>Note		: �R���|�[�l���g�Ƀt�H�[�J�X���Z�b�g���܂��B</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private int CheckError(ref string errorMsg)
        {
            // �t�H�[�J�X�Z�b�g����G�f�B�b�g�̔ԍ�
            int setFocusNum = 0;

            // �ʐM�A�Z���u��ID�����͂���Ă��Ȃ��ꍇ
            if (String.IsNullOrEmpty(this.CommAssemblyId_tEdit.DataText.Trim()))
            {
                errorMsg = "�ʐM�A�Z���u��ID����͂��Ă��������B";
                setFocusNum = 11;
                return setFocusNum;
            }
            int commAssemblyId = 0;
            if (!int.TryParse(this.CommAssemblyId_tEdit.DataText, out commAssemblyId))
            {
                errorMsg = "�ʐM�A�Z���u��ID�ɓ��͕�����̌`��������������܂���B";
                setFocusNum = 12;
                return setFocusNum;
            }

            // �[���ԍ��ꍇ��check
            if (String.IsNullOrEmpty(this.CashRegisterNo_tEdit.DataText.Trim()))
            {
                errorMsg = "�[���ԍ�����͂��Ă��������B";
                setFocusNum = 1;
                return setFocusNum;
            }
            int cashRegisterNo = 0;
            if (!int.TryParse(this.CashRegisterNo_tEdit.DataText, out cashRegisterNo))
            {
                errorMsg = "�[���ԍ��ɓ��͕�����̌`��������������܂���B";
                setFocusNum = 2;
                return setFocusNum; 
            }

            // �ʐM�|�[�g�ԍ����ݒ肳��Ă��Ȃ��Ƃ���
            if (String.IsNullOrEmpty(this.SocketCommPort_tEdit.DataText.Trim()))
            {
                errorMsg = "�ʐM�|�[�g�ԍ�����͂��Ă��������B";
                setFocusNum = 3;
                return setFocusNum;


            }
            int socketCommPort = 0;
            if (!int.TryParse(this.SocketCommPort_tEdit.DataText, out socketCommPort))
            {
                errorMsg = "�ʐM�|�[�g�ԍ��ɓ��͕�����̌`��������������܂���B";
                setFocusNum = 6;
                return setFocusNum;
            }

            // �ڑ���R���s���[�^�����ݒ肳��Ă��Ȃ��Ƃ���
            if (String.IsNullOrEmpty(this.ReceiveComputerNm_tEdit.DataText.Trim()))
            {
                errorMsg = "�ڑ���R���s���[�^������͂��Ă��������B";
                setFocusNum = 4;
                return setFocusNum;
            }

            // �N���C�A���g�^�C���A�E�g���ݒ肳��Ă��Ȃ��Ƃ���
            if (String.IsNullOrEmpty(this.ClientTimeOut_tEdit.DataText.Trim()))
            {
                errorMsg = "�N���C�A���g�^�C���A�E�g����͂��Ă��������B";
                setFocusNum = 5;
                return setFocusNum;
            }
            int clientTimeOut = 0;
            if (!int.TryParse(this.ClientTimeOut_tEdit.DataText, out clientTimeOut))
            {
                errorMsg = "�N���C�A���g�^�C���A�E�g�ɓ��͕�����̌`��������������܂���B";
                setFocusNum = 7;
                return setFocusNum;
            }

            return setFocusNum;
        }

        /// <summary>
        /// �t�H�[�J�X�Z�b�g����
        /// </summary>
        /// <param name="setFocusNum">�t�H�[�J�X�Z�b�g����R���|�[�l���g�ԍ�</param>
        /// <remarks>
        /// <br>Note		: �R���|�[�l���g�Ƀt�H�[�J�X���Z�b�g���܂��B</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private void SetFocusToComponent(int setFocusNum)
        {
            if (setFocusNum != 0)
            {
                //�t�H�[�J�X�Z�b�g
                switch (setFocusNum)
                {
                    case 11:
                        {
                            // �ʐM�A�Z���u��ID
                            this.CommAssemblyId_tEdit.Focus();
                            break;
                        }
                    case 12:
                        {
                            // �ʐM�A�Z���u��ID
                            this.CommAssemblyId_tEdit.Focus();
                            break;
                        }
                    case 1:
                        {
                            // �[���ԍ�
                            this.CashRegisterNo_tEdit.Focus();
                            break;
                        }
                    case 2:
                        {
                            // �[���ԍ�
                            this.CashRegisterNo_tEdit.Focus();
                            break;
                        }
                    case 3:
                        {
                            // �ʐM�|�[�g�ԍ�
                            this.SocketCommPort_tEdit.Focus();
                            break;
                        }
                    case 6:
                        {
                            // �ʐM�|�[�g�ԍ�
                            this.SocketCommPort_tEdit.Focus();
                            break;
                        }
                    case 4:
                        {
                            // �ڑ���R���s���[�^��
                            this.ReceiveComputerNm_tEdit.Focus();
                            break;
                        }
                    case 5:
                        {
                            // �N���C�A���g�^�C���A�E�g
                            this.ClientTimeOut_tEdit.Focus();
                            break;
                        }
                    case 7:
                        {
                            // �N���C�A���g�^�C���A�E�g
                            this.ClientTimeOut_tEdit.Focus();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return;
            }
            
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            "���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            "���ɑ��[�����폜����Ă��܂��B",	    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._dataIndex = -1;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #endregion Private Method End

        # region Control Events
        /// <summary>
        ///	Form.Load �C�x���g(PMUOE09050UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void PMUOE09050UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������			
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Close_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Close_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            // ��ʏ����ݒ菈��
            ScreenInitialSetting();
        }

        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMUOE09050UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ��ʂ̕\���A��\�����ς�������ɔ������܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void PMUOE09050UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();

                return;
            }

            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            timer1.Enabled = true;

            ScreenInitialSetting();
        }

        /// <summary>
        ///	Form.Load �C�x���g(PMUOE09050UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void Close_Button_Click(object sender, System.EventArgs e)
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                //��ʏ����擾����
                string CommAssemblyId = this.CommAssemblyId_tEdit.DataText.Trim();
                string CashRegisterNo = this.CashRegisterNo_tEdit.DataText.Trim();
                string SocketCommPort = this.SocketCommPort_tEdit.DataText.Trim();
                string ReceiveComputerNm = this.ReceiveComputerNm_tEdit.DataText.Trim();
                string ClientTimeOut = this.ClientTimeOut_tEdit.DataText.Trim();
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!String.IsNullOrEmpty(CommAssemblyId) || !String.IsNullOrEmpty(CashRegisterNo) || !String.IsNullOrEmpty(SocketCommPort) || !String.IsNullOrEmpty(ReceiveComputerNm) || !String.IsNullOrEmpty(ClientTimeOut))
                {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!IsValueCheck() || !IsSaveProc())
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
                                this.Close_Button.Focus();
                                return;
                            }
                    }
                }
            }
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            else if (this.Mode_Label.Text != DELETE_MODE)
            {
                //�ۑ��m�F
                UOEConnectInfo compareUOEConnectInfo = new UOEConnectInfo();
                compareUOEConnectInfo = this._uOEConnectInfoClone.Clone();
                //���݂̉�ʏ����擾����
                DispToUOEConnectInfo(ref compareUOEConnectInfo);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._uOEConnectInfoClone.Equals(compareUOEConnectInfo)))
                {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!IsValueCheck() || !IsSaveProc())
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
                                this.Close_Button.Focus();
                                return;
                            }
                    }
                }
            }

                this.DialogResult = DialogResult.Cancel;
                this._indexBuf = -2;

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
        /// Form.Closing�C�x���g(PMUOE09050UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���N���[�Y���̃C�x���g�ł�</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// </remarks>
        private void PMUOE09050UA_Closing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// �^�C�}�[����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : �^�C�}�[����</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;
            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,    // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.Yes)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            UOEConnectInfo uOEConnectInfo = ((UOEConnectInfo)this._uOEConnectInfoTable[guid]).Clone();

            // UOE�ڑ�����}�X�^�폜����
            int status = this._uOEConnectInfoAcs.Delete(uOEConnectInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._uOEConnectInfoTable.Remove(uOEConnectInfo.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        // �����폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._uOEConnectInfoAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // �����Ώۃf�[�^�擾
            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            UOEConnectInfo uOEConnectInfo = ((UOEConnectInfo)this._uOEConnectInfoTable[guid]).Clone();

            // UOE�ڑ�����}�X�^�_���폜��������
            int status = this._uOEConnectInfoAcs.Revival(ref uOEConnectInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        UOEConnectInfoToDataSet(uOEConnectInfo, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ReviveWarehouse",				    // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._uOEConnectInfoAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
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
        /// Leave  �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �ʐM�A�Z���u��ID�͂S�����s�����ɔ������܂��B</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/08/05</br>
        /// </remarks>
        private void CommAssemblyId_tEdit_Leave(object sender, EventArgs e)
        {
            this.CommAssemblyId_tEdit.DataText = this.CommAssemblyId_tEdit.DataText.Trim();

            // �S�����s�����A���Ɂu�O�v��⑫
            if (this.CommAssemblyId_tEdit.DataText.Length < 4 && this.CommAssemblyId_tEdit.DataText.Length > 0)
            {
                this.CommAssemblyId_tEdit.DataText = this.CommAssemblyId_tEdit.DataText.PadLeft(4, '0');
            }
        }

        /// <summary>
        /// Leave  �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �[���ԍ��͂R�����s�����ɔ������܂��B</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/08/05</br>
        /// </remarks>
        private void CashRegisterNo_tEdit_Leave(object sender, EventArgs e)
        {
            this.CashRegisterNo_tEdit.DataText = this.CashRegisterNo_tEdit.DataText.Trim();

            // 3�����s�����A���Ɂu�O�v��⑫
            if (this.CashRegisterNo_tEdit.DataText.Length < 3 && this.CashRegisterNo_tEdit.DataText.Length > 0)
            {
                this.CashRegisterNo_tEdit.DataText = this.CashRegisterNo_tEdit.DataText.PadLeft(3, '0');
            }
        }
        #endregion Control Events End
    }
}
